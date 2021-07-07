using System;

namespace LitJson
{
	// Token: 0x0200000A RID: 10
	public class JsonException : ApplicationException
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x0000266E File Offset: 0x0000086E
		public JsonException()
		{
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002676 File Offset: 0x00000876
		internal JsonException(ParserToken token) : base(string.Format("Invalid token '{0}' in input string", token))
		{
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000268E File Offset: 0x0000088E
		internal JsonException(ParserToken token, Exception inner_exception) : base(string.Format("Invalid token '{0}' in input string", token), inner_exception)
		{
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000026A7 File Offset: 0x000008A7
		internal JsonException(int c) : base(string.Format("Invalid character '{0}' in input string", (char)c))
		{
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000026C0 File Offset: 0x000008C0
		internal JsonException(int c, Exception inner_exception) : base(string.Format("Invalid character '{0}' in input string", (char)c), inner_exception)
		{
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000026DA File Offset: 0x000008DA
		public JsonException(string message) : base(message)
		{
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000026E3 File Offset: 0x000008E3
		public JsonException(string message, Exception inner_exception) : base(message, inner_exception)
		{
		}
	}
}
