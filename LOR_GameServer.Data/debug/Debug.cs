using System;
using System.IO;
using LOR_GameServer.Core;
using LOR_GameServer.Server;

namespace LOR_GameServer.debug
{
    // Token: 0x0200001D RID: 29
    public static class Debug
	{
		// Token: 0x0600005D RID: 93 RVA: 0x0000333C File Offset: 0x0000153C
		public static void Log(string log)
		{
			using (StreamWriter streamWriter = new StreamWriter(Debug.path + "netdebug-" + DateTime.Now.ToString("yyyy-MM-dd-HH") + ".log", true))
			{
				streamWriter.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + log + "\n");
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000023A6 File Offset: 0x000005A6
		public static void LogandWrite(string msg)
		{
			Debug.Log(msg);
			Console.WriteLine(msg);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000023B4 File Offset: 0x000005B4
		public static void Error(string msg)
		{
			Debug.Log(msg);
			Debug.WriteColorLine(msg, ConsoleColor.Red);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000023C4 File Offset: 0x000005C4
		public static void WriteColorLine(string msg, ConsoleColor color)
		{
			ConsoleColor foregroundColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(msg);
			Console.ForegroundColor = foregroundColor;
		}

		// Token: 0x04000045 RID: 69
		public static string path = string.Empty;

		// Token: 0x04000046 RID: 70
		public static LOR_GameManager gameManager;

		// Token: 0x04000047 RID: 71
		public static GameServer Server;
	}
}
