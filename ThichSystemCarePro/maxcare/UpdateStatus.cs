using System.Collections.Generic;
using System.Data;
using System.Linq;
using MCommon;

namespace maxcare
{
	internal class UpdateStatus
	{
		private static Dictionary<string, string> dicIdStatus = new Dictionary<string, string>();

		public static bool isSaveSettings = false;

		public static string GetStatusById(string id)
		{
			if (!isSaveSettings)
			{
				return "";
			}
			string result = "";
			if (dicIdStatus.ContainsKey(id))
			{
				result = dicIdStatus[id];
			}
			return result;
		}

		public static void SetStatusById(string id, string status)
		{
			if (isSaveSettings)
			{
				if (dicIdStatus.ContainsKey(id))
				{
					dicIdStatus[id] = status;
				}
				else
				{
					dicIdStatus.Add(id, status);
				}
			}
		}

		public static void GetValueFromDatabase()
		{
			if (isSaveSettings)
			{
				DataTable idStatus = CommonSQL.GetIdStatus();
				dicIdStatus = idStatus.AsEnumerable().ToDictionary((DataRow row) => row[0].ToString(), (DataRow row) => row[1].ToString());
			}
		}

		public static void SetValueFromDatabase()
		{
			if (isSaveSettings)
			{
				List<string> lstId_FieldValue = dicIdStatus.Where(delegate(KeyValuePair<string, string> x)
				{
					KeyValuePair<string, string> keyValuePair2 = x;
					return keyValuePair2.Value.Trim() != "";
				}).Select(delegate(KeyValuePair<string, string> x)
				{
					KeyValuePair<string, string> keyValuePair = x;
					string key = keyValuePair.Key;
					keyValuePair = x;
					return key + "|" + keyValuePair.Value;
				}).ToList();
				CommonSQL.UpdateMultiField("status", lstId_FieldValue);
			}
		}
	}
}
