using System.Windows.Forms;

namespace maxcare.Helper
{
	public class MessageBoxHelper
	{
		public static void ShowMessageBox(object s, int type = 1)
		{
			switch (type)
			{
			case 1:
				MessageBox.Show(s.ToString(), Language.GetValue("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				break;
			case 2:
				MessageBox.Show(s.ToString(), Language.GetValue("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				break;
			case 3:
				MessageBox.Show(s.ToString(), Language.GetValue("Thông báo"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				break;
			}
		}

		public static DialogResult ShowMessageBoxWithQuestion(string content)
		{
			return MessageBox.Show(content, Language.GetValue("Thông báo"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}
	}
}
