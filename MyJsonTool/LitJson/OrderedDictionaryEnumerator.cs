using System;
using System.Collections;
using System.Collections.Generic;

namespace LitJson
{
	// Token: 0x02000009 RID: 9
	internal class OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00002638 File Offset: 0x00000838
		public object Current
		{
			get
			{
				return this.Entry;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003A24 File Offset: 0x00001C24
		public DictionaryEntry Entry
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return new DictionaryEntry(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003A50 File Offset: 0x00001C50
		public object Key
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Key;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00003A70 File Offset: 0x00001C70
		public object Value
		{
			get
			{
				KeyValuePair<string, JsonData> keyValuePair = this.list_enumerator.Current;
				return keyValuePair.Value;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002645 File Offset: 0x00000845
		public OrderedDictionaryEnumerator(IEnumerator<KeyValuePair<string, JsonData>> enumerator)
		{
			this.list_enumerator = enumerator;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002654 File Offset: 0x00000854
		public bool MoveNext()
		{
			return this.list_enumerator.MoveNext();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002661 File Offset: 0x00000861
		public void Reset()
		{
			this.list_enumerator.Reset();
		}

		// Token: 0x04000021 RID: 33
		private IEnumerator<KeyValuePair<string, JsonData>> list_enumerator;
	}
}
