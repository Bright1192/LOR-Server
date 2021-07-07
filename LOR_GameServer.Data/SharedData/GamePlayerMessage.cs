using System;

namespace LOR_GameServer.SharedData
{
	// Token: 0x02000009 RID: 9
	public class GamePlayerMessage : GameMessage
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002093 File Offset: 0x00000293
		public GamePlayerMessage()
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000209B File Offset: 0x0000029B
		public GamePlayerMessage(int code, GamePlayer u)
		{
			this.stateCode = code;
			this.player = u;
		}

		// Token: 0x04000019 RID: 25
		public GamePlayer player;
	}
}
