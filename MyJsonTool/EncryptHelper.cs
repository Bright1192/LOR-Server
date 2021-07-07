using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MyJsonTool
{
	/// <summary>
	/// 更简单的使用RSA加解密
	/// </summary>
	public static class EncryptHelper
	{
		/// <summary>
		/// 生成新的密钥
		/// </summary>
		/// <param name="PrivateKey">私钥</param>
		/// <param name="PublicKey">公钥</param>
		public static void RSAKey(out string PrivateKey, out string PublicKey)
		{
			RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider();
			PrivateKey = rsacryptoServiceProvider.ToXmlString(true);
			PublicKey = rsacryptoServiceProvider.ToXmlString(false);
		}

		/// <summary>
		/// 使用公钥加密文本
		/// </summary>
		/// <param name="rawInput">待加密的文本</param>
		/// <param name="publicKey">公钥</param>
		/// <returns>加密后的文本</returns>
		public static string RsaEncrypt(string rawInput, string publicKey)
		{
			if (string.IsNullOrEmpty(rawInput))
			{
				return string.Empty;
			}
			if (string.IsNullOrWhiteSpace(publicKey))
			{
				throw new ArgumentException("Invalid Public Key");
			}
			string result;
			using (RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider())
			{
				byte[] bytes = Encoding.UTF8.GetBytes(rawInput);
				rsacryptoServiceProvider.FromXmlString(publicKey);
				int num = rsacryptoServiceProvider.KeySize / 8 - 11;
				byte[] array = new byte[num];
				using (MemoryStream memoryStream = new MemoryStream(bytes))
				{
					using (MemoryStream memoryStream2 = new MemoryStream())
					{
						for (;;)
						{
							int num2 = memoryStream.Read(array, 0, num);
							if (num2 <= 0)
							{
								break;
							}
							byte[] array2 = new byte[num2];
							Array.Copy(array, 0, array2, 0, num2);
							byte[] array3 = rsacryptoServiceProvider.Encrypt(array2, false);
							memoryStream2.Write(array3, 0, array3.Length);
						}
						result = Convert.ToBase64String(memoryStream2.ToArray());
					}
				}
			}
			return result;
		}

		/// <summary>
		/// 使用私钥解密文本
		/// </summary>
		/// <param name="encryptedInput">待解密的文本</param>
		/// <param name="privateKey">私钥</param>
		/// <returns>解密后的文本</returns>
		public static string RsaDecrypt(string encryptedInput, string privateKey)
		{
			if (string.IsNullOrEmpty(encryptedInput))
			{
				return string.Empty;
			}
			if (string.IsNullOrWhiteSpace(privateKey))
			{
				throw new ArgumentException("Invalid Private Key");
			}
			string @string;
			using (RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider())
			{
				byte[] buffer = Convert.FromBase64String(encryptedInput);
				rsacryptoServiceProvider.FromXmlString(privateKey);
				int num = rsacryptoServiceProvider.KeySize / 8;
				byte[] array = new byte[num];
				using (MemoryStream memoryStream = new MemoryStream(buffer))
				{
					using (MemoryStream memoryStream2 = new MemoryStream())
					{
						for (;;)
						{
							int num2 = memoryStream.Read(array, 0, num);
							if (num2 <= 0)
							{
								break;
							}
							byte[] array2 = new byte[num2];
							Array.Copy(array, 0, array2, 0, num2);
							byte[] array3 = rsacryptoServiceProvider.Decrypt(array2, false);
							memoryStream2.Write(array3, 0, array3.Length);
						}
						@string = Encoding.UTF8.GetString(memoryStream2.ToArray());
					}
				}
			}
			return @string;
		}
	}
}
