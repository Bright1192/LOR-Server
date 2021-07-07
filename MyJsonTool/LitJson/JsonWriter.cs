using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LitJson
{
	// Token: 0x0200001A RID: 26
	public class JsonWriter
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00002B07 File Offset: 0x00000D07
		// (set) Token: 0x06000129 RID: 297 RVA: 0x00002B0F File Offset: 0x00000D0F
		public int IndentValue
		{
			get
			{
				return this.indent_value;
			}
			set
			{
				this.indentation = this.indentation / this.indent_value * value;
				this.indent_value = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00002B2D File Offset: 0x00000D2D
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00002B35 File Offset: 0x00000D35
		public bool PrettyPrint
		{
			get
			{
				return this.pretty_print;
			}
			set
			{
				this.pretty_print = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00002B3E File Offset: 0x00000D3E
		public TextWriter TextWriter
		{
			get
			{
				return this.writer;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00002B46 File Offset: 0x00000D46
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00002B4E File Offset: 0x00000D4E
		public bool Validate
		{
			get
			{
				return this.validate;
			}
			set
			{
				this.validate = value;
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00002B63 File Offset: 0x00000D63
		public JsonWriter()
		{
			this.inst_string_builder = new StringBuilder();
			this.writer = new StringWriter(this.inst_string_builder);
			this.Init();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002B8D File Offset: 0x00000D8D
		public JsonWriter(StringBuilder sb) : this(new StringWriter(sb))
		{
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002B9B File Offset: 0x00000D9B
		public JsonWriter(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.writer = writer;
			this.Init();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005828 File Offset: 0x00003A28
		private void DoValidation(Condition cond)
		{
			if (!this.context.ExpectingValue)
			{
				this.context.Count++;
			}
			if (!this.validate)
			{
				return;
			}
			if (this.has_reached_end)
			{
				throw new JsonException("A complete JSON symbol has already been written");
			}
			switch (cond)
			{
			case Condition.InArray:
				if (!this.context.InArray)
				{
					throw new JsonException("Can't close an array here");
				}
				break;
			case Condition.InObject:
				if (!this.context.InObject || this.context.ExpectingValue)
				{
					throw new JsonException("Can't close an object here");
				}
				break;
			case Condition.NotAProperty:
				if (this.context.InObject && !this.context.ExpectingValue)
				{
					throw new JsonException("Expected a property");
				}
				break;
			case Condition.Property:
				if (!this.context.InObject || this.context.ExpectingValue)
				{
					throw new JsonException("Can't add a property here");
				}
				break;
			case Condition.Value:
				if (!this.context.InArray && (!this.context.InObject || !this.context.ExpectingValue))
				{
					throw new JsonException("Can't add a value here");
				}
				break;
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000598C File Offset: 0x00003B8C
		private void Init()
		{
			this.has_reached_end = false;
			this.hex_seq = new char[4];
			this.indentation = 0;
			this.indent_value = 4;
			this.pretty_print = false;
			this.validate = true;
			this.ctx_stack = new Stack<WriterContext>();
			this.context = new WriterContext();
			this.ctx_stack.Push(this.context);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000059F0 File Offset: 0x00003BF0
		private static void IntToHex(int n, char[] hex)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = n % 16;
				if (num < 10)
				{
					hex[3 - i] = (char)(48 + num);
				}
				else
				{
					hex[3 - i] = (char)(65 + (num - 10));
				}
				n >>= 4;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00002BC1 File Offset: 0x00000DC1
		private void Indent()
		{
			if (this.pretty_print)
			{
				this.indentation += this.indent_value;
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00005A40 File Offset: 0x00003C40
		private void Put(string str)
		{
			if (this.pretty_print && !this.context.ExpectingValue)
			{
				for (int i = 0; i < this.indentation; i++)
				{
					this.writer.Write(' ');
				}
			}
			this.writer.Write(str);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00002BE1 File Offset: 0x00000DE1
		private void PutNewline()
		{
			this.PutNewline(true);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005A98 File Offset: 0x00003C98
		private void PutNewline(bool add_comma)
		{
			if (add_comma && !this.context.ExpectingValue && this.context.Count > 1)
			{
				this.writer.Write(',');
			}
			if (this.pretty_print && !this.context.ExpectingValue)
			{
				this.writer.Write('\n');
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00005B04 File Offset: 0x00003D04
		private void PutString(string str)
		{
			this.Put(string.Empty);
			this.writer.Write('"');
			int length = str.Length;
			for (int i = 0; i < length; i++)
			{
				char c = str[i];
				switch (c)
				{
				case '\b':
					this.writer.Write("\\b");
					break;
				case '\t':
					this.writer.Write("\\t");
					break;
				case '\n':
					this.writer.Write("\\n");
					break;
				default:
					if (c != '"' && c != '\\')
					{
						if (str[i] >= ' ' && str[i] <= '~')
						{
							this.writer.Write(str[i]);
						}
						else
						{
							JsonWriter.IntToHex((int)str[i], this.hex_seq);
							this.writer.Write("\\u");
							this.writer.Write(this.hex_seq);
						}
					}
					else
					{
						this.writer.Write('\\');
						this.writer.Write(str[i]);
					}
					break;
				case '\f':
					this.writer.Write("\\f");
					break;
				case '\r':
					this.writer.Write("\\r");
					break;
				}
			}
			this.writer.Write('"');
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00002BEA File Offset: 0x00000DEA
		private void Unindent()
		{
			if (this.pretty_print)
			{
				this.indentation -= this.indent_value;
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00002C0A File Offset: 0x00000E0A
		public override string ToString()
		{
			if (this.inst_string_builder == null)
			{
				return string.Empty;
			}
			return this.inst_string_builder.ToString();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005C80 File Offset: 0x00003E80
		public void Reset()
		{
			this.has_reached_end = false;
			this.ctx_stack.Clear();
			this.context = new WriterContext();
			this.ctx_stack.Push(this.context);
			if (this.inst_string_builder != null)
			{
				this.inst_string_builder.Remove(0, this.inst_string_builder.Length);
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00002C28 File Offset: 0x00000E28
		public void Write(bool boolean)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put((!boolean) ? "false" : "true");
			this.context.ExpectingValue = false;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00002C5E File Offset: 0x00000E5E
		public void Write(decimal number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00005CE0 File Offset: 0x00003EE0
		public void Write(double number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			string text = Convert.ToString(number, JsonWriter.number_format);
			this.Put(text);
			if (text.IndexOf('.') == -1 && text.IndexOf('E') == -1)
			{
				this.writer.Write(".0");
			}
			this.context.ExpectingValue = false;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00002C8A File Offset: 0x00000E8A
		public void Write(int number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00002CB6 File Offset: 0x00000EB6
		public void Write(long number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00002CE2 File Offset: 0x00000EE2
		public void Write(string str)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			if (str == null)
			{
				this.Put("null");
			}
			else
			{
				this.PutString(str);
			}
			this.context.ExpectingValue = false;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00002D1A File Offset: 0x00000F1A
		[CLSCompliant(false)]
		public void Write(ulong number)
		{
			this.DoValidation(Condition.Value);
			this.PutNewline();
			this.Put(Convert.ToString(number, JsonWriter.number_format));
			this.context.ExpectingValue = false;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00005D48 File Offset: 0x00003F48
		public void WriteArrayEnd()
		{
			this.DoValidation(Condition.InArray);
			this.PutNewline(false);
			this.ctx_stack.Pop();
			if (this.ctx_stack.Count == 1)
			{
				this.has_reached_end = true;
			}
			else
			{
				this.context = this.ctx_stack.Peek();
				this.context.ExpectingValue = false;
			}
			this.Unindent();
			this.Put("]");
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00005DBC File Offset: 0x00003FBC
		public void WriteArrayStart()
		{
			this.DoValidation(Condition.NotAProperty);
			this.PutNewline();
			this.Put("[");
			this.context = new WriterContext();
			this.context.InArray = true;
			this.ctx_stack.Push(this.context);
			this.Indent();
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00005E10 File Offset: 0x00004010
		public void WriteObjectEnd()
		{
			this.DoValidation(Condition.InObject);
			this.PutNewline(false);
			this.ctx_stack.Pop();
			if (this.ctx_stack.Count == 1)
			{
				this.has_reached_end = true;
			}
			else
			{
				this.context = this.ctx_stack.Peek();
				this.context.ExpectingValue = false;
			}
			this.Unindent();
			this.Put("}");
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005E84 File Offset: 0x00004084
		public void WriteObjectStart()
		{
			this.DoValidation(Condition.NotAProperty);
			this.PutNewline();
			this.Put("{");
			this.context = new WriterContext();
			this.context.InObject = true;
			this.ctx_stack.Push(this.context);
			this.Indent();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005ED8 File Offset: 0x000040D8
		public void WritePropertyName(string property_name)
		{
			this.DoValidation(Condition.Property);
			this.PutNewline();
			this.PutString(property_name);
			if (this.pretty_print)
			{
				if (property_name.Length > this.context.Padding)
				{
					this.context.Padding = property_name.Length;
				}
				for (int i = this.context.Padding - property_name.Length; i >= 0; i--)
				{
					this.writer.Write(' ');
				}
				this.writer.Write(": ");
			}
			else
			{
				this.writer.Write(':');
			}
			this.context.ExpectingValue = true;
		}

		// Token: 0x0400007D RID: 125
		private static NumberFormatInfo number_format = NumberFormatInfo.InvariantInfo;

		// Token: 0x0400007E RID: 126
		private WriterContext context;

		// Token: 0x0400007F RID: 127
		private Stack<WriterContext> ctx_stack;

		// Token: 0x04000080 RID: 128
		private bool has_reached_end;

		// Token: 0x04000081 RID: 129
		private char[] hex_seq;

		// Token: 0x04000082 RID: 130
		private int indentation;

		// Token: 0x04000083 RID: 131
		private int indent_value;

		// Token: 0x04000084 RID: 132
		private StringBuilder inst_string_builder;

		// Token: 0x04000085 RID: 133
		private bool pretty_print;

		// Token: 0x04000086 RID: 134
		private bool validate;

		// Token: 0x04000087 RID: 135
		private TextWriter writer;
	}
}
