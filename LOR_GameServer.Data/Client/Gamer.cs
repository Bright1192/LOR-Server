using System;

namespace LOR_GameServer.Client
{
	/// <summary>
	/// 客户端玩家数据
	/// </summary>
	public class Gamer
	{
		// Token: 0x06000056 RID: 86 RVA: 0x0000233F File Offset: 0x0000053F
		

		/// <summary>
		/// 其他玩家的此参数为Null
		/// </summary>
		public RoomClientSimulator client;

		// Token: 0x0400003D RID: 61
		public string id;

		// Token: 0x0400003E RID: 62
		public int Dmg;

		// Token: 0x0400003F RID: 63
		public int Play_Over_time;
	}
}
