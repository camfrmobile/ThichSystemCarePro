using System;
using System.Collections.Generic;
using System.Linq;

namespace maxcare.Helper
{
	public class CollectionHelper
	{
		public static bool ComparyTwoList(List<string> lst1, List<string> lst2)
		{
			List<string> source = lst1.Except(lst2).ToList();
			List<string> source2 = lst2.Except(lst1).ToList();
			return !source.Any() && !source2.Any();
		}

		public static List<string> ShuffleList(List<string> lst)
		{
			string text = "";
			int num = lst.Count;
			int num2 = 0;
			while (num != 0)
			{
				num2 = Base.rd.Next(0, lst.Count);
				num--;
				text = lst[num];
				lst[num] = lst[num2];
				lst[num2] = text;
			}
			return lst;
		}

		public static List<string> CloneList(List<string> lstFrom)
		{
			List<string> list = new List<string>();
			try
			{
				for (int i = 0; i < lstFrom.Count; i++)
				{
					list.Add(lstFrom[i]);
				}
			}
			catch
			{
			}
			return list;
		}

		public static List<List<string>> SplitList(List<string> lstInput, int numberOfItemPerList)
		{
			List<List<string>> list = new List<List<string>>();
			try
			{
				int num = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)lstInput.Count * 1.0 / (double)numberOfItemPerList)));
				for (int i = 0; i < num; i++)
				{
					list.Add(lstInput.GetRange(numberOfItemPerList * i, (numberOfItemPerList * i + numberOfItemPerList <= lstInput.Count) ? numberOfItemPerList : (lstInput.Count % numberOfItemPerList)));
				}
			}
			catch
			{
			}
			return list;
		}

		public static string ConvertListToString(List<string> lstInput, string separatorString = "\r\n")
		{
			return string.Join(separatorString, lstInput);
		}
	}
}
