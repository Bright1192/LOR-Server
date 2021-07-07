using System;

namespace LOR_GameServer.SharedData
{
	/// <summary>
	/// 玩家加入Msg
	/// </summary>
	public class ClientJoinMessage : GameMessage
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002083 File Offset: 0x00000283
		public ClientJoinMessage()
		{
			this.stateCode = 100;
		}

		// Token: 0x04000018 RID: 24
		public string id;
	}
}
