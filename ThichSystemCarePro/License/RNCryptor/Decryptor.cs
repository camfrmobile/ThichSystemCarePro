using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace License.RNCryptor
{
	public class Decryptor : Cryptor
	{
		public string Decrypt(string encryptedBase64, string password)
		{
			try
			{
				PayloadComponents components = unpackEncryptedBase64Data(encryptedBase64);
				if (!hmacIsValid(components, password))
				{
					return "";
				}
				byte[] key = generateKey(components.salt, password);
				byte[] bytes = new byte[0];
				switch (aesMode)
				{
				case AesMode.CBC:
					bytes = decryptAesCbcPkcs7(components.ciphertext, key, components.iv);
					break;
				case AesMode.CTR:
					bytes = encryptAesCtrLittleEndianNoPadding(components.ciphertext, key, components.iv);
					break;
				}
				return Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				return "null";
			}
		}

		private byte[] decryptAesCbcPkcs7(byte[] encrypted, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = aes.CreateDecryptor(key, iv);
			string s;
			using (MemoryStream stream = new MemoryStream(encrypted))
			{
				using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(stream2);
				s = streamReader.ReadToEnd();
			}
			return base.TextEncoding.GetBytes(s);
		}

		private PayloadComponents unpackEncryptedBase64Data(string encryptedBase64)
		{
			List<byte> list = new List<byte>();
			list.AddRange(Convert.FromBase64String(encryptedBase64));
			int num = 0;
			PayloadComponents result = default(PayloadComponents);
			result.schema = list.GetRange(0, 1).ToArray();
			num = 1;
			configureSettings((Schema)list[0]);
			result.options = list.GetRange(1, 1).ToArray();
			num = 2;
			result.salt = list.GetRange(2, 8).ToArray();
			num = 2 + result.salt.Length;
			result.hmacSalt = list.GetRange(num, 8).ToArray();
			num += result.hmacSalt.Length;
			result.iv = list.GetRange(num, 16).ToArray();
			num = (result.headerLength = num + result.iv.Length);
			result.ciphertext = list.GetRange(num, list.Count - 32 - result.headerLength).ToArray();
			num += result.ciphertext.Length;
			result.hmac = list.GetRange(num, 32).ToArray();
			return result;
		}

		private bool hmacIsValid(PayloadComponents components, string password)
		{
			byte[] array = generateHmac(components, password);
			if (array.Length != components.hmac.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < components.hmac.Length)
				{
					if (array[num] != components.hmac[num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}
}
