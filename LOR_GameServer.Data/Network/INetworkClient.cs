using System;

namespace LOR_GameServer.Network
{
	/// <summary>
	/// 客户端接口
	/// </summary>
	public interface INetworkClient
	{
		/// <summary>
		/// 连接服务器
		/// </summary>
		void Connect(string connectStr);

		/// <summary>
		/// 是否连接
		/// </summary>
		bool Connected { get; }

		/// <summary>
		/// 关闭连接
		/// </summary>
		void Close();

		/// <summary>
		/// 发送数据
		/// </summary>
		void SendMsg(string msg);

		/// <summary>
		/// 消息处理器
		/// </summary>
		event Action<string> OnReceiveMsg;
	}
}
