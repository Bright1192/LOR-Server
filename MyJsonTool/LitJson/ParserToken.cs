using System;

namespace LitJson
{
	// Token: 0x0200001E RID: 30
	internal enum ParserToken
	{
		// Token: 0x040000B7 RID: 183
		None = 65536,
		// Token: 0x040000B8 RID: 184
		Number,
		// Token: 0x040000B9 RID: 185
		True,
		// Token: 0x040000BA RID: 186
		False,
		// Token: 0x040000BB RID: 187
		Null,
		// Token: 0x040000BC RID: 188
		CharSeq,
		// Token: 0x040000BD RID: 189
		Char,
		// Token: 0x040000BE RID: 190
		Text,
		// Token: 0x040000BF RID: 191
		Object,
		// Token: 0x040000C0 RID: 192
		ObjectPrime,
		// Token: 0x040000C1 RID: 193
		Pair,
		// Token: 0x040000C2 RID: 194
		PairRest,
		// Token: 0x040000C3 RID: 195
		Array,
		// Token: 0x040000C4 RID: 196
		ArrayPrime,
		// Token: 0x040000C5 RID: 197
		Value,
		// Token: 0x040000C6 RID: 198
		ValueRest,
		// Token: 0x040000C7 RID: 199
		String,
		// Token: 0x040000C8 RID: 200
		End,
		// Token: 0x040000C9 RID: 201
		Epsilon
	}
}
