using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using LOR_GameServer.debug;

namespace LOR_GameServer.Network
{
	/// <summary>
	/// TCP适配服务器实现
	/// </summary>
	public class TcpNetworkServer : INetworkServer
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000030 RID: 48 RVA: 0x000026E8 File Offset: 0x000008E8
		// (remove) Token: 0x06000031 RID: 49 RVA: 0x00002720 File Offset: 0x00000920
		public event Action<INetworkClientSession> OnNewClient;

		// Token: 0x06000032 RID: 50 RVA: 0x000021D1 File Offset: 0x000003D1
		public void Shutdown()
		{
			this.__listener.Stop();
			this.__listenThread.Abort();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002758 File Offset: 0x00000958
		public void StartListen(string connectStr)
		{
			string ipString = connectStr.Split(new char[]
			{
				':'
			}, StringSplitOptions.None)[0];
			int port = int.Parse(connectStr.Split(new char[]
			{
				':'
			}, StringSplitOptions.None)[1]);
			IPAddress localaddr = IPAddress.Parse(ipString);
			this.__listener = new TcpListener(localaddr, port);
			this.__listener.Start();
			this.__listenThread = new Thread(delegate()
			{
				Debug.LogandWrite("等待玩家加入..");
				try
				{
					for (;;)
					{
						TcpNetworkClientSession tcpNetworkClientSession = new TcpNetworkClientSession(this.__listener.AcceptTcpClient());
						Debug.LogandWrite("新玩家加入:" + tcpNetworkClientSession.GetRemoteConnectStr());
						this.OnNewClient(tcpNetworkClientSession);
					}
				}
				catch (Exception ex)
				{
					Debug.Error(ex.Message + "\n" + ex.StackTrace);
				}
			});
			this.__listenThread.Start();
		}

		// Token: 0x04000028 RID: 40
		private TcpListener __listener;

		// Token: 0x04000029 RID: 41
		private Thread __listenThread;
	}
}
