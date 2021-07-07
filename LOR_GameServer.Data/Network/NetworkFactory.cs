using System;

namespace LOR_GameServer.Network
{
	// Token: 0x02000010 RID: 16
	public static class NetworkFactory
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000020DE File Offset: 0x000002DE
		public static INetworkServer CreateNetworkServer<T>() where T : INetworkServer, new()
		{
			return Activator.CreateInstance<T>();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000020DE File Offset: 0x000002DE
		public static INetworkClient CreateNetworkClient<T>() where T : INetworkClient, new()
		{
			return Activator.CreateInstance<T>();
		}
	}
}
