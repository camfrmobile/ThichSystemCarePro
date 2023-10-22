using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace License.RNCryptor
{
	public class Encryptor : Cryptor
	{
		private Schema defaultSchemaVersion = Schema.V2;

		public string Encrypt(string plaintext, string password)
		{
			try
			{
				return Base64Encode(Encrypt(plaintext, password, defaultSchemaVersion));
			}
			catch
			{
				return "null";
			}
		}

		public static string Base64Encode(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}

		public string Encrypt(string plaintext, string password, Schema schemaVersion)
		{
			configureSettings(schemaVersion);
			byte[] bytes = base.TextEncoding.GetBytes(plaintext);
			PayloadComponents components = default(PayloadComponents);
			components.schema = new byte[1] { (byte)schemaVersion };
			components.options = new byte[1] { (byte)options };
			components.salt = generateRandomBytes(8);
			components.hmacSalt = generateRandomBytes(8);
			components.iv = generateRandomBytes(16);
			byte[] key = generateKey(components.salt, password);
			switch (aesMode)
			{
			case AesMode.CBC:
				components.ciphertext = encryptAesCbcPkcs7(bytes, key, components.iv);
				break;
			case AesMode.CTR:
				components.ciphertext = encryptAesCtrLittleEndianNoPadding(bytes, key, components.iv);
				break;
			}
			components.hmac = generateHmac(components, password);
			List<byte> list = new List<byte>();
			list.AddRange(assembleHeader(components));
			list.AddRange(components.ciphertext);
			list.AddRange(components.hmac);
			return Convert.ToBase64String(list.ToArray());
		}

		private byte[] encryptAesCbcPkcs7(byte[] plaintext, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = aes.CreateEncryptor(key, iv);
			using MemoryStream memoryStream = new MemoryStream();
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
			{
				cryptoStream.Write(plaintext, 0, plaintext.Length);
			}
			return memoryStream.ToArray();
		}

		private byte[] generateRandomBytes(int length)
		{
			byte[] array = new byte[length];
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			rNGCryptoServiceProvider.GetBytes(array);
			return array;
		}
	}
}
