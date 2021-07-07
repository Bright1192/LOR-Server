using System;

namespace LitJson
{
	// Token: 0x02000016 RID: 22
	public enum JsonToken
	{
		// Token: 0x04000057 RID: 87
		None,
		// Token: 0x04000058 RID: 88
		ObjectStart,
		// Token: 0x04000059 RID: 89
		PropertyName,
		// Token: 0x0400005A RID: 90
		ObjectEnd,
		// Token: 0x0400005B RID: 91
		ArrayStart,
		// Token: 0x0400005C RID: 92
		ArrayEnd,
		// Token: 0x0400005D RID: 93
		Int,
		// Token: 0x0400005E RID: 94
		Long,
		// Token: 0x0400005F RID: 95
		Double,
		// Token: 0x04000060 RID: 96
		String,
		// Token: 0x04000061 RID: 97
		Boolean,
		// Token: 0x04000062 RID: 98
		Null
	}
}
