using System;

namespace LOR_GameServer.Network
{
	// Token: 0x0200000F RID: 15
	public interface INetworkServer
	{
		// Token: 0x06000018 RID: 24
		void StartListen(string connectStr);

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000019 RID: 25
		// (remove) Token: 0x0600001A RID: 26
		event Action<INetworkClientSession> OnNewClient;

		// Token: 0x0600001B RID: 27
		void Shutdown();
	}
}
