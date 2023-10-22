using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MCommon;
using Newtonsoft.Json.Linq;

namespace maxcare.Helper
{
	internal class JsonHelper
	{
		private string PathFileSetting;

		private JObject json;

		public JsonHelper(string jsonStringOrPathFile, bool isJsonString = false)
		{
			if (isJsonString)
			{
				if (jsonStringOrPathFile.Trim() == "")
				{
					jsonStringOrPathFile = "{}";
				}
				json = JObject.Parse(jsonStringOrPathFile);
				return;
			}
			try
			{
				PathFileSetting = "settings\\" + jsonStringOrPathFile + ".json";
				if (!File.Exists(PathFileSetting))
				{
					using (File.AppendText(PathFileSetting))
					{
					}
				}
				json = JObject.Parse(File.ReadAllText(PathFileSetting));
			}
			catch
			{
				json = new JObject();
			}
		}

		public static Dictionary<string, object> ConvertToDictionary(JObject jObject)
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			try
			{
				dic = jObject.ToObject<Dictionary<string, object>>();
				List<string> list = (from r in dic
									 select new
									 {
										 value = r,
										 key = r.Key
									 } into x
									 where x.value.GetType() == typeof(JObject)
									 select x.key).ToList();
				List<string> list2 = (from r in dic
									  select new
									  {
										  value = r,
										  key = r.Key
									  } into x
									  where x.value.GetType() == typeof(JObject)
									  select x.key).ToList();
				list2.ForEach(delegate (string key)
				{
					dic[key] = (from x in ((JArray)dic[key]).Values()
								select ((JValue)x).Value).ToArray();
				});
				list.ForEach(delegate (string key)
				{
					dic[key] = ConvertToDictionary(dic[key] as JObject);
				});
			}
			catch
			{
			}
			return dic;
		}

		public JsonHelper()
		{
			json = new JObject();
		}

		public string GetValue(string key, string valueDefault = "")
		{
			string result = valueDefault;
			try
			{
				result = ((json[key] == null) ? valueDefault : json[key]!.ToString());
			}
			catch
			{
			}
			return result;
		}

		public List<string> GetValueList(string key, int typeSplitString = 0)
		{
			List<string> list = new List<string>();
			try
			{
				list = ((typeSplitString != 0) ? GetValue(key).Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : GetValue(key).Split('\n').ToList());
				list = MCommon.Common.RemoveEmptyItems(list);
			}
			catch
			{
			}
			return list;
		}

		public int GetValueInt(string key, int valueDefault = 0)
		{
			int result = valueDefault;
			try
			{
				result = ((json[key] == null) ? valueDefault : Convert.ToInt32(json[key]!.ToString()));
			}
			catch
			{
			}
			return result;
		}

		public bool GetValueBool(string key, bool valueDefault = false)
		{
			bool result = valueDefault;
			try
			{
				result = ((json[key] == null) ? valueDefault : Convert.ToBoolean(json[key]!.ToString()));
				return result;
			}
			catch
			{
				return result;
			}
		}

		public void Add(string key, string value)
		{
			try
			{
				if (!json.ContainsKey(key))
				{
					json.Add(key, (JToken)value);
				}
				else
				{
					json[key] = (JToken)value;
				}
			}
			catch (Exception)
			{
			}
		}

		public void Update(string key, object value)
		{
			try
			{
				json[key] = (JToken)value.ToString();
			}
			catch
			{
			}
		}

		public void Update(string key, List<string> lst)
		{
			try
			{
				json[key] = (JToken)string.Join("\n", lst).ToString();
			}
			catch
			{
			}
		}

		public void Remove(string key)
		{
			try
			{
				json.Remove(key);
			}
			catch
			{
			}
		}

		public void Save(string pathFileSetting = "")
		{
			try
			{
				if (pathFileSetting == "")
				{
					pathFileSetting = PathFileSetting;
				}
				File.WriteAllText(pathFileSetting, json.ToString());
			}
			catch
			{
			}
		}

		public string GetFullString()
		{
			string result = "";
			try
			{
				result = json.ToString().Replace("\r\n", "");
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
