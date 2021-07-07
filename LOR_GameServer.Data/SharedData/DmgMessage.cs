using System;

namespace LOR_GameServer.SharedData
{
	/// <summary>
	/// 伤害Msg
	/// </summary>
	public class DmgMessage : GameMessage
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000020CF File Offset: 0x000002CF
		public DmgMessage()
		{
			this.stateCode = 5;
		}

		// Token: 0x0400001E RID: 30
		public int dmg;

		// Token: 0x0400001F RID: 31
		public string ID;
	}
}
