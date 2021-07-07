using System;

namespace LOR_GameServer.SharedData
{
	// Token: 0x02000007 RID: 7
	public static class MsgCode
	{
		// Token: 0x0400000F RID: 15
		public const int USER_JOIN = 1;

		// Token: 0x04000010 RID: 16
		public const int USER_STATE_UPDATE = 2;

		// Token: 0x04000011 RID: 17
		public const int USER_QUIT = 3;

		// Token: 0x04000012 RID: 18
		public const int SYNC = 7;

		// Token: 0x04000013 RID: 19
		public const int SYNC_TIME = 8;

		// Token: 0x04000014 RID: 20
		public const int HIT = 5;

		// Token: 0x04000015 RID: 21
		public const int CLIENT_JOIN = 100;

		// Token: 0x04000016 RID: 22
		public const int CLIENT_MOVE = 101;

		// Token: 0x04000017 RID: 23
		public const int CLIENT_QUIT = 102;
	}
}
