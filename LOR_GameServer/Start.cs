using System;
using LOR_GameServer.Core;
using LOR_GameServer.debug;
using LOR_GameServer.Server;

namespace LOR_GameServer
{
    // Token: 0x02000003 RID: 3
    public class Start
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002085 File Offset: 0x00000285
		public Start()
		{
			this.start();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002094 File Offset: 0x00000294
		public void start()
		{
			try
			{
				Console.Title = "LOR-Server";
				Debug.LogandWrite("请输入IP和端口(默认127.0.0.1:7777)");
				string text = Console.ReadLine();
				if (string.IsNullOrEmpty(text))
				{
					text = "127.0.0.1:7777";
				}
				Debug.LogandWrite("是服务器?(y/n)");
				string text2 = Console.ReadLine();
				if (string.IsNullOrEmpty(text2) || text2 == "y" || text2 == "Y" || text2 == "是")
				{
					Debug.Server = new GameServer();
					Debug.Server.Start(text);
				}
				else
				{
					Console.Title = "LOR-DebugClient";
					Debug.LogandWrite("输入您的名字");
					string text3 = Console.ReadLine();
					if (string.IsNullOrEmpty(text3))
					{
						text3 = "游客";
					}
					LOR_GameManager.MyId = text3;
					LOR_GameManager.ServerEndpoint = text;
					Debug.gameManager = new LOR_GameManager();
					Debug.gameManager.Start();
				}
			}
			catch (Exception ex)
			{
				Debug.Error(ex.Message + "\n" + ex.StackTrace);
				this.start();
			}
		}
	}
}
