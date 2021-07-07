using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using MyJsonTool;
using LOR_GameServer.debug;
using LOR_GameServer.Network;
using LOR_GameServer.SharedData;
using LOR_GameServer.Core;

namespace LOR_GameServer.Server
{
    /// <summary>
	/// 服务器主逻辑
	/// </summary>
    public class GameServer
	{
		// Token: 0x0600003B RID: 59 RVA: 0x000021F6 File Offset: 0x000003F6
		public int GetPlayersCount()
		{
			return this._players.Count;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000029D4 File Offset: 0x00000BD4
		private void FixedUpdate()
		{
			this.__disConnectedPlayers.Clear();
			//分发所有消息
			while (this._msgQueue.Count > 0)
			{
				ServerMessageCarrior serverMessageCarrior = this._msgQueue.Dequeue();
				foreach (KeyValuePair<string, GamePlayerSession> keyValuePair in this._players)
				{
					if ((string.IsNullOrEmpty(serverMessageCarrior.sendto) || serverMessageCarrior.sendto == keyValuePair.Key) && (string.IsNullOrEmpty(serverMessageCarrior.except) || serverMessageCarrior.except != keyValuePair.Key))
					{
						INetworkClientSession client = keyValuePair.Value.client;
						if (client.Connected)
						{
							try
							{
								client.SendMsg(serverMessageCarrior.msg);
							}
							catch
							{
								this.__disConnectedPlayers.Add(keyValuePair.Key);
							}
						}
					}
				}
			}			
			foreach (string id in this.__disConnectedPlayers)
			{
				this.PlayerDropped(id);
			}
		}

		/// <summary>
		/// 踢出玩家
		/// </summary>
		/// <param name="id">玩家ID</param>
		public void PlayerDropped(string id)
		{
			if (this._players.ContainsKey(id))
			{
				this.DispatchMsg(new GamePlayerMessage(3, this._players[id].user).ToJson(false), "", "");
				this._players[id].Close();
				this._players.Remove(id);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002B88 File Offset: 0x00000D88
		public int NewPlayer(string id, GamePlayerSession session)
		{
			int result = 0;
			try
			{
				if (this._players.ContainsKey(id))
				{
					result = 1000;
				}
				else
				{
					GamePlayer gamePlayer = new GamePlayer();
					gamePlayer.id = id;
					session.user = gamePlayer;
					//给其他玩家分发玩家加入消息
					this.DispatchMsg(new GamePlayerMessage(1, gamePlayer).ToJson(false), "", id);
					this._players.Add(id, session);
					//给自己全量同步
					this.DispatchMsg(this.GenerateSyncMessage().ToJson(false), id, "");
					result = 0;
				}
			}
			catch (Exception ex)
			{
				Debug.Error(ex.Message + "\n" + ex.StackTrace);
			}
			return result;
		}

		/// <summary>
		/// 生成全量同步的信息
		/// </summary>
		/// <returns></returns>
		public SyncMessage GenerateSyncMessage()
		{
			SyncMessage syncMessage = new SyncMessage();
			syncMessage.players = new List<GamePlayer>();
			foreach (GamePlayerSession gamePlayerSession in this._players.Values)
			{
				syncMessage.players.Add(gamePlayerSession.user.Clone());
			}
			syncMessage.time = this.Total_time;
			return syncMessage;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002CBC File Offset: 0x00000EBC
		public int Quit(string id)
		{
			if (!this._players.ContainsKey(id))
			{
				return 1001;
			}
			GamePlayerSession gamePlayerSession = this._players[id];
			gamePlayerSession.Close();
			this._players.Remove(id);
			this.DispatchMsg(new GamePlayerMessage(3, gamePlayerSession.user).ToJson(false), "", "");
			return 0;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002D20 File Offset: 0x00000F20
		private void FrameLogic()
		{
			lock (this)
			{
				//处理所有客户端请求
				while (this.PlayerMessageQueue.Count > 0)
				{
					ClientMessageCarrior msg;
					this.PlayerMessageQueue.TryDequeue(out msg);
					PlayerMessage.Execute(msg, this);
				}
				this.FixedUpdate();
			}
		}

		/// <summary>
		/// 主循环
		/// </summary>
		public void LoopFun()
		{
			int num = 20;
			int num2 = num;
			int tickCount = Environment.TickCount;
			int num3 = 0;
			int num4 = 0;
			for (;;)
			{
				try
				{
					num4++;
					int tickCount2 = Environment.TickCount;
					this.FrameLogic();
					num3 = Environment.TickCount - tickCount2;
					//修正计算时间
					num2 = num - num3;
					if (num2 < 0)
					{
						num2 = 0;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
				Thread.Sleep(num2);
				int num5 = num3 + num2;
				this.Total_time += num5;
				//500毫秒发送一次时间同步信息
				if (num4 * num % 500 == 0)
				{
					this.DispatchMsg(new TimeMessage
					{
						Total_time = this.Total_time,
						Over_time = num5
					}.ToJson(false), "", "");
					foreach (GamePlayerSession gamePlayerSession in this._players.Values)
					{
						gamePlayerSession.user.Play_Over_time += num5;
					}
				}
				//2秒统计一次
				if (num4 * num % 2000 == 0)
				{
					Debug.Log(string.Format("players:{0},PlayerMessageQueue:{1},sendQueue:{2},每帧计算时间:{3}", new object[]
					{
						this.GetPlayersCount(),
						this.PlayerMessageQueue.Count,
						this._msgQueue.Count,
						num3
					}));
				}
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002203 File Offset: 0x00000403
		public void Start(string conn)
		{
			INetworkServer networkServer = NetworkFactory.CreateNetworkServer<TcpNetworkServer>();
			networkServer.OnNewClient += delegate(INetworkClientSession client)
			{
				new GamePlayerSession(client, this);
			};
			networkServer.StartListen(conn);
			this.LoopFun();
		}

		/// <summary>
		/// 分发消息
		/// </summary>
		/// <param name="msg">消息</param>
		/// <param name="sendto">只需要发的人</param>
		/// <param name="except">需要剔除的人</param>
		public void DispatchMsg(string msg, string sendto = "", string except = "")
		{
			ServerMessageCarrior serverMessageCarrior = new ServerMessageCarrior();
			serverMessageCarrior.sendto = sendto;
			serverMessageCarrior.except = except;
			serverMessageCarrior.msg = msg;
			Queue<ServerMessageCarrior> msgQueue = this._msgQueue;
			lock (msgQueue)
			{
				this._msgQueue.Enqueue(serverMessageCarrior);
			}
		}

		/// <summary>
		/// 服务器运行时间
		/// </summary>
		public int Total_time;

		/// <summary>
		/// 玩家请求的消息队列
		/// </summary>
		public ConcurrentQueue<ClientMessageCarrior> PlayerMessageQueue = new ConcurrentQueue<ClientMessageCarrior>();

		/// <summary>
		/// 全体玩家连接
		/// </summary>
		public Dictionary<string, GamePlayerSession> _players = new Dictionary<string, GamePlayerSession>();

		/// <summary>
		/// 消息发送队列
		/// </summary>
		public Queue<ServerMessageCarrior> _msgQueue = new Queue<ServerMessageCarrior>();

		// Token: 0x04000035 RID: 53
		public List<string> __disConnectedPlayers = new List<string>();
	}
}
