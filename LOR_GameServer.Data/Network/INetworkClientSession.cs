using System;

namespace LOR_GameServer.Network
{
	/// <summary>
	/// 客户端在服务端这边的连接，每个客户端对应一个此类
	/// </summary>
	public interface INetworkClientSession
	{
		// Token: 0x06000012 RID: 18
		void Close();

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000013 RID: 19
		bool Connected { get; }

		// Token: 0x06000014 RID: 20
		string GetRemoteConnectStr();

		// Token: 0x06000015 RID: 21
		void SendMsg(string msg);

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000016 RID: 22
		// (remove) Token: 0x06000017 RID: 23
		event Action<string> OnReceiveMsg;
	}
}
