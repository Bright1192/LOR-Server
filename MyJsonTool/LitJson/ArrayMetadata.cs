using System;

namespace LitJson
{
	// Token: 0x0200000C RID: 12
	internal struct ArrayMetadata
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000026ED File Offset: 0x000008ED
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x0000270B File Offset: 0x0000090B
		public Type ElementType
		{
			get
			{
				if (this.element_type == null)
				{
					return typeof(JsonData);
				}
				return this.element_type;
			}
			set
			{
				this.element_type = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002714 File Offset: 0x00000914
		// (set) Token: 0x060000BB RID: 187 RVA: 0x0000271C File Offset: 0x0000091C
		public bool IsArray
		{
			get
			{
				return this.is_array;
			}
			set
			{
				this.is_array = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00002725 File Offset: 0x00000925
		// (set) Token: 0x060000BD RID: 189 RVA: 0x0000272D File Offset: 0x0000092D
		public bool IsList
		{
			get
			{
				return this.is_list;
			}
			set
			{
				this.is_list = value;
			}
		}

		// Token: 0x04000025 RID: 37
		private Type element_type;

		// Token: 0x04000026 RID: 38
		private bool is_array;

		// Token: 0x04000027 RID: 39
		private bool is_list;
	}
}
