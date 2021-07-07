using System;

namespace LOR_GameServer.SharedData
{
	// Token: 0x0200000B RID: 11
	public class TimeMessage : GameMessage
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000020C0 File Offset: 0x000002C0
		public TimeMessage()
		{
			this.stateCode = 8;
		}

		/// <summary>
		/// 总计时间
		/// </summary>
		public int Total_time;

		/// <summary>
		/// 经过时间
		/// </summary>
		public int Over_time;
	}
}
