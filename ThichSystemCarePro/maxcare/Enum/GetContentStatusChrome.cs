namespace maxcare.Enum
{
	public class GetContentStatusChrome
	{
		public static string GetContent(StatusChromeAccount status)
		{
			string result = "";
			switch (status)
			{
			case StatusChromeAccount.ChromeClosed:
				result = "Chrome đã bị đóng!";
				break;
			case StatusChromeAccount.Checkpoint:
				result = "Checkpoint!";
				break;
			case StatusChromeAccount.NoInternet:
				result = "Mất kết nối Internet!";
				break;
			case StatusChromeAccount.Blocked:
				result = "Facebook Block tính năng!";
				break;
			}
			return result;
		}
	}
}
