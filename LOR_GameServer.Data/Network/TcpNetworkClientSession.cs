using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LOR_GameServer.Network
{
	/// <summary>
	/// TCP适配服务器实现
	/// </summary>
	public class TcpNetworkClientSession : INetworkClientSession
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00002142 File Offset: 0x00000342
		public TcpNetworkClientSession(TcpClient c)
		{
			this.client = c;
			this._recieveThread = new Thread(delegate(object o)
			{
				try
				{
					for (;;)
					{
						byte[] array = new byte[1024];
						int count = this.client.Client.Receive(array);
						string @string = Encoding.UTF8.GetString(array, 0, count);
						this.OnReceiveMsg(@string);
					}
				}
				catch
				{
					Close();
				}
			});
			this._recieveThread.Start();
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002173 File Offset: 0x00000373
		public bool Connected
		{
			get
			{
				return this.client.Connected;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002180 File Offset: 0x00000380
		public void Close()
		{
			this._recieveThread.Abort();
			this.client.Close();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002198 File Offset: 0x00000398
		public string GetRemoteConnectStr()
		{
			return this.client.Client.RemoteEndPoint.ToString();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021AF File Offset: 0x000003AF
		public void SendMsg(string msg)
		{
			if (msg == null)
			{
				return;
			}
			this.client.Client.Send(Encoding.UTF8.GetBytes(msg));
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600002D RID: 45 RVA: 0x0000261C File Offset: 0x0000081C
		// (remove) Token: 0x0600002E RID: 46 RVA: 0x00002654 File Offset: 0x00000854
		public event Action<string> OnReceiveMsg;

		// Token: 0x04000025 RID: 37
		private TcpClient client;

		// Token: 0x04000026 RID: 38
		private Thread _recieveThread;
	}
}
