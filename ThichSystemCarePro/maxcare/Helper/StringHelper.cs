using System;

namespace maxcare.Helper
{
	public class StringHelper
	{
		public static bool CheckStringIsNumber(string content)
		{
			try
			{
				Convert.ToInt32(content);
				return true;
			}
			catch
			{
			}
			return false;
		}
	}
}
