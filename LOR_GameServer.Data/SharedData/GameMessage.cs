using System;

namespace LOR_GameServer.SharedData
{
	/// <summary>
	/// 所有Msg的基类
	/// </summary>
	[Serializable]
	public class GameMessage
	{
		/// <summary>
		/// 用于区分是何种Msg
		/// </summary>
		public int stateCode;

		/// <summary>
		/// 携带的其他信息
		/// </summary>
		public string content;
	}
}
