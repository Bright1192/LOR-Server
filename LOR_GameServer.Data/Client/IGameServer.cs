using System;

namespace LOR_GameServer.Client
{
	// Token: 0x02000017 RID: 23
	public interface IGameServer
	{
		// Token: 0x06000047 RID: 71
		int Quit(string id);

		// Token: 0x06000048 RID: 72
		int NewPlayer(string id);

		// Token: 0x06000049 RID: 73
		void Send(string msg);
	}
}
