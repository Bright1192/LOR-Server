using System;

namespace LOR_GameServer.SharedData
{
	/// <summary>
	/// 服务器端玩家数据
	/// </summary>
	[Serializable]
	public class GamePlayer
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002058 File Offset: 0x00000258
		public GamePlayer Clone()
		{
			return new GamePlayer
			{
				id = this.id,
				Dmg = this.Dmg,
				Play_Over_time = this.Play_Over_time
			};
		}

		// Token: 0x04000009 RID: 9
		public string id;

		// Token: 0x0400000A RID: 10
		public int Dmg;

		// Token: 0x0400000B RID: 11
		public int Play_Over_time;
	}
}
