using System;
using System.Configuration;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace License
{
	public class Hardware
	{
		private string maHoa(string sChuoi)
		{
			MD5 mD = MD5.Create();
			byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(sChuoi));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append($"{array[i]:x2}");
			}
			return stringBuilder.ToString();
		}

		public string getHDD()
		{
			string result = "";
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator())
			{
				object obj2;
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					object obj = managementObject["SerialNumber"];
					if (obj == null)
					{
						obj2 = null;
					}
					else
					{
						obj2 = obj.ToString();
						if (obj2 != null)
						{
							goto IL_005a;
						}
					}
					obj2 = "";
					goto IL_005a;
				}
				goto end_IL_0022;
				IL_005a:
				result = maHoa(EncryptHDD((string)obj2, useHashing: true)).ToUpper();
				end_IL_0022:;
			}
			return result;
		}

		private static string EncryptHDD(string toEncrypt, bool useHashing)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
			new AppSettingsReader();
			string s = "#HiepdepTrai#";
			byte[] key;
			if (useHashing)
			{
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
				mD5CryptoServiceProvider.Clear();
			}
			else
			{
				key = Encoding.UTF8.GetBytes(s);
			}
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
			tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
			byte[] array = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			tripleDESCryptoServiceProvider.Clear();
			return Convert.ToBase64String(array, 0, array.Length);
		}
	}
}
