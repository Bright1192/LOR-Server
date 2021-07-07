using System;
using System.Collections.Generic;

namespace LitJson
{
	// Token: 0x0200000D RID: 13
	internal struct ObjectMetadata
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00002736 File Offset: 0x00000936
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00002754 File Offset: 0x00000954
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

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x0000275D File Offset: 0x0000095D
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00002765 File Offset: 0x00000965
		public bool IsDictionary
		{
			get
			{
				return this.is_dictionary;
			}
			set
			{
				this.is_dictionary = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000276E File Offset: 0x0000096E
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00002776 File Offset: 0x00000976
		public IDictionary<string, PropertyMetadata> Properties
		{
			get
			{
				return this.properties;
			}
			set
			{
				this.properties = value;
			}
		}

		// Token: 0x04000028 RID: 40
		private Type element_type;

		// Token: 0x04000029 RID: 41
		private bool is_dictionary;

		// Token: 0x0400002A RID: 42
		private IDictionary<string, PropertyMetadata> properties;
	}
}
