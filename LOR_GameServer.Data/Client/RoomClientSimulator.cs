using System;

namespace LOR_GameServer.Client
{
	// Token: 0x0200001A RID: 26
	public class RoomClientSimulator
	{
		// Token: 0x06000052 RID: 82 RVA: 0x000022F2 File Offset: 0x000004F2
		public RoomClientSimulator(IGameServer s, string id)
		{
			this._server = s;
			this._id = id;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002308 File Offset: 0x00000508
		public bool Connect()
		{
			return this._server.NewPlayer(this._id) == 0;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000231E File Offset: 0x0000051E
		public int Quit()
		{
			return this._server.Quit(this._id);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002331 File Offset: 0x00000531
		public void Send(string msg)
		{
			this._server.Send(msg);
		}

		// Token: 0x0400003A RID: 58
		public IGameServer _server;

		// Token: 0x0400003B RID: 59
		private string _id;
	}
}
