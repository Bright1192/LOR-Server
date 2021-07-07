using System;
using MyJsonTool;
using LOR_GameServer.debug;
using LOR_GameServer.Network;
using LOR_GameServer.SharedData;
using LOR_GameServer.Core;

namespace LOR_GameServer.Client
{
    // Token: 0x02000018 RID: 24
    public class DemoTcpClient : IGameServer
	{
		// Token: 0x0600004A RID: 74 RVA: 0x00002F50 File Offset: 0x00001150
		private void Connect(string endpoint)
		{
			this.client = NetworkFactory.CreateNetworkClient<TcpNetworkClient>();
			this.client.OnReceiveMsg += delegate(string msg)
			{
				Debug.gameManager.OnRecieveMsg(msg);
			};
			this.client.Connect(endpoint);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002271 File Offset: 0x00000471
		public int Quit(string id)
		{
			this.Send(new GameMessage
			{
				stateCode = 102
			}.ToJson(false));
			this.client.Close();
			return 0;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002298 File Offset: 0x00000498
		public int NewPlayer(string id)
		{
			this.Connect(LOR_GameManager.ServerEndpoint);
			this.Send(new ClientJoinMessage
			{
				id = id
			}.ToJson(false));
			return 0;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000022BE File Offset: 0x000004BE
		public void Send(string msg)
		{
			if (this.client.Connected)
			{
				this.client.SendMsg(msg);
			}
		}

		// Token: 0x04000036 RID: 54
		private Action<GameMessage> _msgHander;

		// Token: 0x04000037 RID: 55
		private INetworkClient client;
	}
}
