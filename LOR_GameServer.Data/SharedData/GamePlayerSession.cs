using System;
using MyJsonTool;
using LOR_GameServer.Network;
using LOR_GameServer.Server;

namespace LOR_GameServer.SharedData
{
	// Token: 0x02000015 RID: 21
	public class GamePlayerSession
	{
		// Token: 0x06000038 RID: 56 RVA: 0x000028E8 File Offset: 0x00000AE8
		public GamePlayerSession(INetworkClientSession c, GameServer s)
		{
			this.server = s;
			this.client = c;
			this.client.OnReceiveMsg += this.OnMessage;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000021E9 File Offset: 0x000003E9
		public void Close()
		{
			this.client.Close();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002938 File Offset: 0x00000B38
		private void OnMessage(string msg)
		{
			if (msg == null)
			{
				this.server.PlayerDropped(this.id);
				return;
			}
			if (!string.IsNullOrEmpty(this.id))
			{
				
				this.server.PlayerMessageQueue.Enqueue(new ClientMessageCarrior
				{
					id = this.id,
					Msg = msg
				});
				return;
			}
			if (msg.ToObject<GameMessage>().stateCode == 100)
			{
				ClientJoinMessage clientJoinMessage = msg.ToObject<ClientJoinMessage>();
				this.id = clientJoinMessage.id;
				this.server.NewPlayer(this.id, this);
				return;
			}
		}

		// Token: 0x0400002B RID: 43


		// Token: 0x0400002C RID: 44
		public string id = "";

		// Token: 0x0400002D RID: 45
		public GamePlayer user;

		// Token: 0x0400002E RID: 46
		public GameServer server;

		// Token: 0x0400002F RID: 47
		public INetworkClientSession client;
	}
}
