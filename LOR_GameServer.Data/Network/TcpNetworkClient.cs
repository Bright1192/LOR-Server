using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using LOR_GameServer.debug;

namespace LOR_GameServer.Network
{
	/// <summary>
	/// TCP适配服务器实现
	/// </summary>
	public class TcpNetworkClient : INetworkClient
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000023E8 File Offset: 0x000005E8
		public void Connect(string connectStr)
		{
			try
			{
				this.ip = connectStr.Split(new char[]
				{
					':'
				}, StringSplitOptions.None)[0];
				this.port = int.Parse(connectStr.Split(new char[]
				{
					':'
				}, StringSplitOptions.None)[1]);
				IPAddress address = IPAddress.Parse(this.ip);
				this.clientSocket.Connect(new IPEndPoint(address, this.port));
				Debug.LogandWrite("链接成功");
				this._recieveThread = new Thread(delegate(object o)
				{
					try
					{
						for (;;)
						{
							byte[] array = new byte[1024];
							int count = this.clientSocket.Receive(array);
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
			catch (Exception ex)
			{				
				this.TryConnect(this.ip, this.port);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000020EA File Offset: 0x000002EA
		public void Close()
		{
			this._recieveThread.Abort();
			this.clientSocket.Close();
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002102 File Offset: 0x00000302
		public bool Connected
		{
			get
			{
				return this.clientSocket.Connected;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024C0 File Offset: 0x000006C0
		public void TryConnect(string ip, int point)
		{
			try
			{
				IPAddress address = Dns.GetHostEntry(ip).AddressList[0];
				this.clientSocket.Connect(new IPEndPoint(address, this.port));
				Debug.LogandWrite("链接成功");
				this._recieveThread = new Thread(delegate(object o)
				{
					try
					{
						for (;;)
						{
							byte[] array = new byte[1024];
							int count = this.clientSocket.Receive(array);
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
			catch (Exception ex)
			{
				Debug.Error(ex.Message + "\n" + ex.StackTrace);
				Debug.Error("错误的IP");
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002125 File Offset: 0x00000325
		public void SendMsg(string msg)
		{
			if (msg == null)
			{
				return;
			}
			this.clientSocket.Send(Encoding.UTF8.GetBytes(msg));
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000024 RID: 36 RVA: 0x00002558 File Offset: 0x00000758
		// (remove) Token: 0x06000025 RID: 37 RVA: 0x00002590 File Offset: 0x00000790
		public event Action<string> OnReceiveMsg;

		// Token: 0x04000020 RID: 32
		public Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		// Token: 0x04000021 RID: 33
		private Thread _recieveThread;

		// Token: 0x04000022 RID: 34
		public int port;

		// Token: 0x04000023 RID: 35
		public string ip;
	}
}
