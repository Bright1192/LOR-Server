using System;
using System.Collections;
using System.Collections.Specialized;

namespace LitJson
{
	// Token: 0x02000007 RID: 7
	public class JsonMockWrapper : IJsonWrapper, IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002120 File Offset: 0x00000320
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002120 File Offset: 0x00000320
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700000A RID: 10
		object IList.this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002128 File Offset: 0x00000328
		int ICollection.Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002128 File Offset: 0x00000328
		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002123 File Offset: 0x00000323
		object ICollection.SyncRoot
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002120 File Offset: 0x00000320
		bool IDictionary.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002120 File Offset: 0x00000320
		bool IDictionary.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002123 File Offset: 0x00000323
		ICollection IDictionary.Keys
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002123 File Offset: 0x00000323
		ICollection IDictionary.Values
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000012 RID: 18
		object IDictionary.this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000013 RID: 19
		object IOrderedDictionary.this[int idx]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002128 File Offset: 0x00000328
		public bool IsArray
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002128 File Offset: 0x00000328
		public bool IsBoolean
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002128 File Offset: 0x00000328
		public bool IsDouble
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002128 File Offset: 0x00000328
		public bool IsInt
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002128 File Offset: 0x00000328
		public bool IsLong
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002128 File Offset: 0x00000328
		public bool IsObject
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002128 File Offset: 0x00000328
		public bool IsString
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002128 File Offset: 0x00000328
		public bool GetBoolean()
		{
			return false;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002133 File Offset: 0x00000333
		public double GetDouble()
		{
			return 0.0;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002128 File Offset: 0x00000328
		public int GetInt()
		{
			return 0;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002128 File Offset: 0x00000328
		public JsonType GetJsonType()
		{
			return JsonType.None;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000213E File Offset: 0x0000033E
		public long GetLong()
		{
			return 0L;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002142 File Offset: 0x00000342
		public string GetString()
		{
			return "";
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002126 File Offset: 0x00000326
		public void SetBoolean(bool val)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002126 File Offset: 0x00000326
		public void SetDouble(double val)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002126 File Offset: 0x00000326
		public void SetInt(int val)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002126 File Offset: 0x00000326
		public void SetJsonType(JsonType type)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002126 File Offset: 0x00000326
		public void SetLong(long val)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002126 File Offset: 0x00000326
		public void SetString(string val)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002142 File Offset: 0x00000342
		public string ToJson()
		{
			return "";
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002126 File Offset: 0x00000326
		public void ToJson(JsonWriter writer)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002128 File Offset: 0x00000328
		int IList.Add(object value)
		{
			return 0;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002126 File Offset: 0x00000326
		void IList.Clear()
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002128 File Offset: 0x00000328
		bool IList.Contains(object value)
		{
			return false;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002149 File Offset: 0x00000349
		int IList.IndexOf(object value)
		{
			return -1;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002126 File Offset: 0x00000326
		void IList.Insert(int i, object v)
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002126 File Offset: 0x00000326
		void IList.Remove(object value)
		{
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002126 File Offset: 0x00000326
		void IList.RemoveAt(int index)
		{
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002126 File Offset: 0x00000326
		void ICollection.CopyTo(Array array, int index)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002123 File Offset: 0x00000323
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002126 File Offset: 0x00000326
		void IDictionary.Add(object k, object v)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002126 File Offset: 0x00000326
		void IDictionary.Clear()
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002128 File Offset: 0x00000328
		bool IDictionary.Contains(object key)
		{
			return false;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002126 File Offset: 0x00000326
		void IDictionary.Remove(object key)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002123 File Offset: 0x00000323
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002123 File Offset: 0x00000323
		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			return null;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002126 File Offset: 0x00000326
		void IOrderedDictionary.Insert(int i, object k, object v)
		{
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002126 File Offset: 0x00000326
		void IOrderedDictionary.RemoveAt(int i)
		{
		}
	}
}
