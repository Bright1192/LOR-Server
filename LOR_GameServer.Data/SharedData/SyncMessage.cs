using System;
using System.Collections.Generic;

namespace LOR_GameServer.SharedData
{
	/// <summary>
	/// 全量同步
	/// </summary>
	public class SyncMessage : GameMessage
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000020B1 File Offset: 0x000002B1
		public SyncMessage()
		{
			this.stateCode = 7;
		}

		// Token: 0x0400001A RID: 26
		public List<GamePlayer> players;

		// Token: 0x0400001B RID: 27
		public int time;
	}
}
