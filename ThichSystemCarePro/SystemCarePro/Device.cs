using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using SystemCarePro.Helper;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using maxcare;
using maxcare.Helper;
using MCommon;
using Newtonsoft.Json.Linq;

namespace SystemCarePro
{
	public class Device
	{
		public enum KeyEvent
		{
			KEYCODE_0 = 0,
			KEYCODE_SOFT_LEFT = 1,
			KEYCODE_SOFT_RIGHT = 2,
			KEYCODE_HOME = 3,
			KEYCODE_BACK = 4,
			KEYCODE_CALL = 5,
			KEYCODE_ENDCALL = 6,
			KEYCODE_0_ = 7,
			KEYCODE_1 = 8,
			KEYCODE_2 = 9,
			KEYCODE_3 = 10,
			KEYCODE_4 = 11,
			KEYCODE_5 = 12,
			KEYCODE_6 = 13,
			KEYCODE_7 = 14,
			KEYCODE_8 = 0xF,
			KEYCODE_9 = 0x10,
			KEYCODE_STAR = 17,
			KEYCODE_POUND = 18,
			KEYCODE_DPAD_UP = 19,
			KEYCODE_DPAD_DOWN = 20,
			KEYCODE_DPAD_LEFT = 21,
			KEYCODE_DPAD_RIGHT = 22,
			KEYCODE_DPAD_CENTER = 23,
			KEYCODE_VOLUME_UP = 24,
			KEYCODE_VOLUME_DOWN = 25,
			KEYCODE_POWER = 26,
			KEYCODE_CAMERA = 27,
			KEYCODE_CLEAR = 28,
			KEYCODE_A = 29,
			KEYCODE_B = 30,
			KEYCODE_C = 0x1F,
			KEYCODE_D = 0x20,
			KEYCODE_E = 33,
			KEYCODE_F = 34,
			KEYCODE_G = 35,
			KEYCODE_H = 36,
			KEYCODE_I = 37,
			KEYCODE_J = 38,
			KEYCODE_K = 39,
			KEYCODE_L = 40,
			KEYCODE_M = 41,
			KEYCODE_N = 42,
			KEYCODE_O = 43,
			KEYCODE_P = 44,
			KEYCODE_Q = 45,
			KEYCODE_R = 46,
			KEYCODE_S = 47,
			KEYCODE_T = 48,
			KEYCODE_U = 49,
			KEYCODE_V = 50,
			KEYCODE_W = 51,
			KEYCODE_X = 52,
			KEYCODE_Y = 53,
			KEYCODE_Z = 54,
			KEYCODE_COMMA = 55,
			KEYCODE_PERIOD = 56,
			KEYCODE_ALT_LEFT = 57,
			KEYCODE_ALT_RIGHT = 58,
			KEYCODE_SHIFT_LEFT = 59,
			KEYCODE_SHIFT_RIGHT = 60,
			KEYCODE_TAB = 61,
			KEYCODE_SPACE = 62,
			KEYCODE_SYM = 0x3F,
			KEYCODE_EXPLORER = 0x40,
			KEYCODE_ENVELOPE = 65,
			KEYCODE_ENTER = 66,
			KEYCODE_DEL = 67,
			KEYCODE_GRAVE = 68,
			KEYCODE_MINUS = 69,
			KEYCODE_EQUALS = 70,
			KEYCODE_LEFT_BRACKET = 71,
			KEYCODE_RIGHT_BRACKET = 72,
			KEYCODE_BACKSLASH = 73,
			KEYCODE_SEMICOLON = 74,
			KEYCODE_APOSTROPHE = 75,
			KEYCODE_SLASH = 76,
			KEYCODE_AT = 77,
			KEYCODE_NUM = 78,
			KEYCODE_HEADSETHOOK = 79,
			KEYCODE_FOCUS = 80,
			KEYCODE_PLUS = 81,
			KEYCODE_MENU = 82,
			KEYCODE_NOTIFICATION = 83,
			KEYCODE_APP_SWITCH = 187
		}

		public int IndexDevice = -1;

		public bool isRunning = false;

		public int demDisconnect = 0;

		public int maxDisconnect = 3;

		public List<string> lstPackages = new List<string>();

		private string link_notifications = "fb://notifications";

		private string link_search = "fb://search";

		private string link_watch = "fb://watch";

		private string link_friends = "fb://friends";

		private string link_profile = "fb://profile";

		private string link_group = "fb://group";

		private string link_page = "fb://page";

		private string link_feed = "fb://feed";

		private string link_syncContact = "com.facebook.katana/com.facebook.growth.friendfinder.FriendFinderStartActivity";

		private int countOpenAppAgain = 0;

		public string DeviceId { get; set; }

		public string PathLDPlayer { get; set; }

		public Process process { get; set; }

		private Random rd { get; set; }

		public Device(string pathLDPlayer, string indexDevice)
		{
			IndexDevice = Convert.ToInt32(indexDevice);
			PathLDPlayer = pathLDPlayer;
			rd = new Random();
		}

		public void GrantPermission()
		{
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_CALENDAR");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_CONTACTS");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_LOCATION");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.ACCESS_BACKGROUND_LOCATION");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.ACCESS_COARSE_LOCATION");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.ACCESS_FINE_LOCATION");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.RECORD_AUDIO");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.CALL_PHONE");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_EXTERNAL_STORAGE");
			ExecuteCMD("shell pm grant com.facebook.katana android.permission.WRITE_EXTERNAL_STORAGE");
		}

		public void ChangeHardwareLDPlayer()
		{
			List<string> list = new List<string>
			{
				"xiaomi 6|xiaomi", "google Pixel 2|google", "xiaomi 8|xiaomi", "huawei Honor V9|huawei", "vivo X9 Plus|vivo", "oppo r11|oppo", "oppo r11 plus|oppo", "oppo R11 Plus|oppo", "oppo R17 Pro|oppo", "meizu PRO 7 Plus|meizu",
				"meizu PRO 6 Plus|meizu", "xiaomi mix|xiaomi", "mi 3|xiaomi"
			};
			Random random = new Random();
			string text = list[random.Next(0, list.Count - 1)];
			string text2 = text.Split('|')[0];
			string text3 = text.Split('|')[1];
			string text4 = "+849";
			string text5 = text4 + random.Next(10000000, 99999999);
			Process process = new Process();
			string arguments = "modify --index " + IndexDevice + " --imei auto --model \"" + text2 + "\" --manufacturer " + text3 + " --pnumber " + text5;
			process.StartInfo = new ProcessStartInfo
			{
				FileName = PathLDPlayer + "\\dnconsole.exe",
				Arguments = arguments,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};
			process.Start();
			process.WaitForExit(5000);
		}

		private List<string> GetListInfoDevice()
		{
			new List<string>();
			string text = MCommon.Common.Base64Decode("QXN1c3xBbGNhdGVsIFBpeGkgNCAoNSkqQXN1c3xBc3VzIFJPRyBQaG9uZSpBc3VzfEFzdXMgWmVuZm9uZSAyIExhc2VyKkFzdXN8QXN1cyBaZW5Gb25lIDMqQXN1c3xBc3VzIFplbmZvbmUgMypBc3VzfEFzdXMgWmVuZm9uZSAzIERlbHV4ZSA1LjUqQXN1c3xBc3VzIFplbmZvbmUgMyBMYXNlcipBc3VzfEFzdXMgWmVuZm9uZSAzIE1heCpBc3VzfEFzdXMgWmVuZm9uZSAzIFVsdHJhKkFzdXN8QXN1cyBaZW5mb25lIDMgWm9vbSpBc3VzfEFzdXMgWmVuZm9uZSAzcyBNYXgqQXN1c3xBc3VzIFplbkZvbmUgNCAoWkU1NTRLTCkqQXN1c3xBc3VzIFplbkZvbmUgNCBNYXgqQXN1c3xBc3VzIFplbkZvbmUgNCBNYXggUHJvIChaQzU1NEtMKSpBc3VzfEFzdXMgWmVuRm9uZSA0IFBybypBc3VzfEFzdXMgWmVuRm9uZSA0IFNlbGZpZSAoWkQ1NTNLTCkqQXN1c3xBc3VzIFplbkZvbmUgNCBTZWxmaWUgUHJvIChaRDU1MktMKSpBc3VzfEFzdXMgWmVuZm9uZSA1KkFzdXN8QXN1cyBaZW5mb25lIDUgTGl0ZSpBc3VzfEFzdXMgWmVuZm9uZSA1USpBc3VzfEFzdXMgWmVuZm9uZSA1WipBc3VzfEFzdXMgWmVuZm9uZSBBUipBc3VzfEFzdXMgWmVuZm9uZSBHbypBc3VzfEFzdXMgWmVuZm9uZSBHbyAoWkI1NTJLTCkqQXN1c3xBc3VzIFplbkZvbmUgTGl2ZSAoTDEpIFpBNTUwS0wqQXN1c3xBc3VzIFplbmZvbmUgTGl2ZSAoWkI1MDFLTCkqQXN1c3xBc3VzIFplbmZvbmUgTWF4KkFzdXN8QXN1cyBaZW5mb25lIE1heCAoTTEpIFpCNTU1S0wqQXN1c3xBc3VzIFplbmZvbmUgTWF4IFBsdXMgKE0xKSBaQjU3MFRMKkFzdXN8QXN1cyBaZW5mb25lIE1heCBQcm8gKE0xKSBaQjYwMUtMKkFzdXN8QXN1cyBaZW5mb25lIE1heCBQcm8gTTEqQXN1c3xBc3VzIFplbkZvbmUgTWF4IFBybyBNMSpBc3VzfEFzdXMgWmVuZm9uZSBWIFY1MjBLTCpBc3VzfEFzdXMgWmVuUGFkIDNzIDEwKkFzdXN8QXN1cyBaZW5QYWQgM3MgOC4wKkFzdXN8QXN1cyBaZW5QYWQgWjEwKkFzdXN8QXN1cyBaZW5wYWQgWjhzIChaVDU4MktMKSpBc3VzfEJsdWJvbyBENipBc3VzfEJRIEFxdWFyaXMgTTUqQXN1c3xEb29nZWUgWDUgTWF4KkFzdXN8RWxlcGhvbmUgVSBQcm8qQXN1c3xFc3NlbnRpYWwgUGhvbmUgUEgtMSpBc3VzfEdlbmVyYWwgTW9iaWxlIEdNIDUqR29vZ2xlfEdvb2dsZSBOZXh1cyAxMCpHb29nbGV8R29vZ2xlIE5leHVzIDQqR29vZ2xlfEdvb2dsZSBOZXh1cyA1Kkdvb2dsZXxHb29nbGUgTmV4dXMgNipHb29nbGV8R29vZ2xlIE5leHVzIDZQKkdvb2dsZXxHb29nbGUgUGl4ZWwqR29vZ2xlfEdvb2dsZSBQaXhlbCAyKkdvb2dsZXxHb29nbGUgUGl4ZWwgMiBYTCpHb29nbGV8R29vZ2xlIFBpeGVsIEMqR29vZ2xlfEdvb2dsZSBQaXhlbCBYTCpIVEN8SFRDIDEwKkhUQ3xIVEMgMTAgRXZvKkhUQ3xIVEMgMTAgTGlmZXN0eWxlKkhUQ3xIVEMgRGVzaXJlIDEwIExpZmVzdHlsZSpIVEN8SFRDIERlc2lyZSAxMCBQcm8qSFRDfEhUQyBEZXNpcmUgMTIqSFRDfEhUQyBEZXNpcmUgMTIrKkhUQ3xIVEMgT25lIE04KkhUQ3xIVEMgT25lIE05KkhUQ3xIVEMgVSBQbGF5KkhUQ3xIVEMgVSBVbHRyYSpIVEN8SFRDIFUxMSpIVEN8SFRDIFUxMSBFeWVzKkhUQ3xIVEMgVTExIExpZmUqSFRDfEhUQyBVMTErKkhUQ3xIVEMgVTEyIGxpZmUqSFRDfEhUQyBVMTIrKkh1YXdlaXxIdWF3ZWkgR1IzICgyMDE3KSpIdWF3ZWl8SHVhd2VpIEhvbm9yIDEwKkh1YXdlaXxIdWF3ZWkgSG9ub3IgNlgqSHVhd2VpfEh1YXdlaSBIb25vciA3QSpIdWF3ZWl8SHVhd2VpIEhvbm9yIDdzKkh1YXdlaXxIdWF3ZWkgSG9ub3IgN1gqSHVhd2VpfEh1YXdlaSBIb25vciA4IExpdGUqSHVhd2VpfEh1YXdlaSBIb25vciA4IFBybypIdWF3ZWl8SHVhd2VpIEhvbm9yIDkqSHVhd2VpfEh1YXdlaSBIb25vciA5IExpdGUqSHVhd2VpfEh1YXdlaSBIb25vciA5TiAoOWkpKkh1YXdlaXxIdWF3ZWkgSG9ub3IgTm90ZSAxMCpIdWF3ZWl8SHVhd2VpIEhvbm9yIFBsYXkqSHVhd2VpfEh1YXdlaSBIb25vciBWaWV3IDEwKkh1YXdlaXxIdWF3ZWkgTWF0ZSAxMCpIdWF3ZWl8SHVhd2VpIE1hdGUgMTAgTGl0ZSpIdWF3ZWl8SHVhd2VpIE1hdGUgMTAgUHJvKkh1YXdlaXxIdWF3ZWkgTWF0ZSAyMCBMaXRlKkh1YXdlaXxIdWF3ZWkgTWF0ZSA4Kkh1YXdlaXxIdWF3ZWkgTWF0ZSA5Kkh1YXdlaXxIdWF3ZWkgTWF0ZSA5IFBvcnNjaGUgRGVzaWduKkh1YXdlaXxIdWF3ZWkgTWF0ZSA5IFBybypIdWF3ZWl8SHVhd2VpIE5vdmEgMipIdWF3ZWl8SHVhd2VpIE5vdmEgMiBQbHVzKkh1YXdlaXxIdWF3ZWkgTm92YSAyaSpIdWF3ZWl8SHVhd2VpIG5vdmEgMypIdWF3ZWl8SHVhd2VpIE5vdmEgM2UqSHVhd2VpfEh1YXdlaSBub3ZhIDNpKkh1YXdlaXxIdWF3ZWkgTm92YSBMaXRlKkh1YXdlaXxIdWF3ZWkgUCBzbWFydCpIdWF3ZWl8SHVhd2VpIFAgU21hcnQrKkh1YXdlaXxIdWF3ZWkgUDEwKkh1YXdlaXxIdWF3ZWkgUDEwIExpdGUqSHVhd2VpfEh1YXdlaSBQMTAgUGx1cypIdWF3ZWl8SHVhd2VpIFAyMCpIdWF3ZWl8SHVhd2VpIFAyMCBMaXRlKkh1YXdlaXxIdWF3ZWkgUDIwIFBybypIdWF3ZWl8SHVhd2VpIFA4IExpdGUgKDIwMTcpKkh1YXdlaXxIdWF3ZWkgUDggTGl0ZSAyMDE3Kkh1YXdlaXxIdWF3ZWkgUDkgTGl0ZSpIdWF3ZWl8SHVhd2VpIFA5IExpdGUgKDIwMTcpKkh1YXdlaXxIdWF3ZWkgUDkgTGl0ZSAyMDE3Kkh1YXdlaXxIdWF3ZWkgWTMgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTUgUHJpbWUgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTYgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTcgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTcgUHJpbWUqSHVhd2VpfEh1YXdlaSBZNyBQcmltZSAyMDE4Kkh1YXdlaXxIdWF3ZWkgWTcgUHJvICgyMDE4KSpIdWF3ZWl8SVVOSSBVMipMZUVjb3xMZUVjbyBMZSAxcypMZUVjb3xMZUVjbyBMZSAyKkxlRWNvfExlRWNvIExlIE1heCAyKkxlRWNvfExlRWNvIExlIFBybyAzKkxlbm92b3xMZW5vdm8gQTUqTGVub3ZvfExlbm92byBBNjAwMCpMZW5vdm98TGVub3ZvIEE2MDAwIFBsdXMqTGVub3ZvfExlbm92byBBNjYwMCBQbHVzKkxlbm92b3xMZW5vdm8gSzMyMHQqTGVub3ZvfExlbm92byBLNSpMZW5vdm98TGVub3ZvIEs1IE5vdGUgKDIwMTgpKkxlbm92b3xMZW5vdm8gSzUgcGxheSpMZW5vdm98TGVub3ZvIEs2Kkxlbm92b3xMZW5vdm8gSzYgTm90ZSpMZW5vdm98TGVub3ZvIEs2IFBvd2VyKkxlbm92b3xMZW5vdm8gSzgqTGVub3ZvfExlbm92byBLOCBOb3RlKkxlbm92b3xMZW5vdm8gSzggUGx1cypMZW5vdm98TGVub3ZvIFAyKkxlbm92b3xMZW5vdm8gUzUqTGVub3ZvfExlbm92byBaNSpMZW5vdm98TGVub3ZvIFp1ayBFZGdlKkxlbm92b3xMZW5vdm8gWnVrIFoxKkxlbm92b3xMZW5vdm8gWnVrIFoyKkxlbm92b3xMZW5vdm8gWlVLIFoyIChQbHVzKSpMZW5vdm98TGVub3ZvIFp1ayBaMiBQcm8qTEd8TEcgQXJpc3RvIDIqTEd8TEcgRzIqTEd8TEcgRzMqTEd8TEcgRzUqTEd8TEcgRzYqTEd8TEcgRzcgRml0KkxHfExHIEc3IE9uZSpMR3xMRyBHNyBUaGluUSpMR3xMRyBHNyBUaGluUSBQbHVzKkxHfExHIEsxMCAyMDE4KkxHfExHIEsxMSBQbHVzKkxHfExHIEszMCpMR3xMRyBLOCAyMDE4KkxHfExHIE5leHVzIDVYKkxHfExHIFBhZCBJViA4LjAqTEd8TEcgUSBTdHlsdXMqTEd8TEcgUTYqTEd8TEcgUTcqTEd8TEcgUTgqTEd8TEcgVjEwKkxHfExHIFYyMCpMR3xMRyBWMzAqTEd8TEcgVjMwUyBUaGluUSpMR3xMRyBWMzUgVGhpblEqTEd8TEcgWCBWZW50dXJlKkxHfExHIFpvbmUgNCpNb3Rvcm9sYXxNb3RvIEMqTW90b3JvbGF8TW90byBFIDIwMTUqTW90b3JvbGF8TW90byBFNCpNb3Rvcm9sYXxNb3RvIEU0IFBsdXMqTW90b3JvbGF8TW90byBFNSpNb3Rvcm9sYXxNb3RvIEU1IFBsYXkqTW90b3JvbGF8TW90byBFNSBQbGF5IEdvKk1vdG9yb2xhfE1vdG8gRTUgUGx1cypNb3Rvcm9sYXxNb3RvIEcgMjAxMypNb3Rvcm9sYXxNb3RvIEcgMjAxNCpNb3Rvcm9sYXxNb3RvIEcgMjAxNSpNb3Rvcm9sYXxNb3RvIEc0Kk1vdG9yb2xhfE1vdG8gRzQgUGx1cypNb3Rvcm9sYXxNb3RvIEc1Kk1vdG9yb2xhfE1vdG8gRzUgUGx1cypNb3Rvcm9sYXxNb3RvIEc1UypNb3Rvcm9sYXxNb3RvIEc1UyBQbHVzKk1vdG9yb2xhfE1vdG8gRzYqTW90b3JvbGF8TW90byBHNiBQbGF5Kk1vdG9yb2xhfE1vdG8gRzYgUGx1cypNb3Rvcm9sYXxNb3RvIE0qTW90b3JvbGF8TW90byBYIFB1cmUqTW90b3JvbGF8TW90byBYNCpNb3Rvcm9sYXxNb3RvIFoqTW90b3JvbGF8TW90byBaIEZvcmNlKk1vdG9yb2xhfE1vdG8gWiBQbGF5Kk1vdG9yb2xhfE1vdG8gWjIgRm9yY2UqTW90b3JvbGF8TW90byBaMiBQbGF5Kk1vdG9yb2xhfE1vdG8gWjMqTW90b3JvbGF8TW90byBaMyBQbGF5Kk1vdG9yb2xhfE1vdG9yb2xhIE1vdG8gRTQqTW90b3JvbGF8TW90b3JvbGEgTW90byBHNiBQbHVzKk1vdG9yb2xhfE1vdG9yb2xhIE1vdG8gWCBQbGF5Kk1vdG9yb2xhfE1vdG9yb2xhIE9uZSBQb3dlcipNb3Rvcm9sYXxNb3Rvcm9sYSBQMzAqTW90b3JvbGF8TmV4dXMgNVgqTW90b3JvbGF8TmV4dXMgNlAqTW90b3JvbGF8TmV4dXMgUGxheWVyKk5va2lhfE5va2lhIDEqTm9raWF8Tm9raWEgMipOb2tpYXxOb2tpYSAyLjEqTm9raWF8Tm9raWEgMypOb2tpYXxOb2tpYSAzLjEqTm9raWF8Tm9raWEgNSpOb2tpYXxOb2tpYSA1LjEqTm9raWF8Tm9raWEgNS4xIFBsdXMqTm9raWF8Tm9raWEgNipOb2tpYXxOb2tpYSA2LjEqTm9raWF8Tm9raWEgNi4xIFBsdXMqTm9raWF8Tm9raWEgNypOb2tpYXxOb2tpYSA3IFBsdXMqTm9raWF8Tm9raWEgNy4xKk5va2lhfE5va2lhIDgqTm9raWF8Tm9raWEgOCBTaXJvY2NvKk5va2lhfE5va2lhIFg1Kk5va2lhfE5va2lhIFg2Kk5va2lhfE51YmlhIFoxNypPbmVQbHVzfE9uZVBsdXMgMipPbmVQbHVzfE9uZVBsdXMgMypPbmVQbHVzfE9uZVBsdXMgM1QqT25lUGx1c3xPbmVQbHVzIDUqT25lUGx1c3xPbmVQbHVzIDUvNVQqT25lUGx1c3xPbmVQbHVzIDVUKk9uZVBsdXN8T25lUGx1cyBPbmUqT25lUGx1c3xPbmVQbHVzIFgqUmVkbWl8UmVkbWkgM3MvM3gvUHJpbWUqUmVkbWl8UmVkbWkgNCBQcmltZSpSZWRtaXxSZWRtaSA0WCpSZWRtaXxSZWRtaSA1IFBsdXMqUmVkbWl8UmVkbWkgTm90ZSA1KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTMgKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTUgKDIwMTYpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTUgKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTYgMjAxOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE2KyAyMDE4KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTcgKDIwMTYpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTcgKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTggKDIwMTYpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTggKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTggMjAxOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE4IFN0YXIqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBBOCsgMjAxOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE5IFBybypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE5IFN0YXIqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBBbHBoYSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEM3IFBybypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEM5IFBybypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEdyYW5kIFByaW1lKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSipTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEoyIENvcmUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKMiBQcm8gKDIwMTgpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjMgKDIwMTgpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjQgKDIwMTgpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNSAoMjAxNykqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNiAoMjAxOCkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyAoMjAxOCkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyBEdW8qU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyBNYXggKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjcgUHJpbWUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyBQcmltZSAyKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjcgUHJvICgyMDE3KSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEo3IFYqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKOCAoMjAxOCkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBNZWdhIDYuMypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgMypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgOSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgRkUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBPbjYqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTMipTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFM0KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzQgTWluaSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFM1IFtrbHRlXSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFM2KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzcqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTNyBBY3RpdmUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTNyBFZGdlKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzgqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTOCBBY3RpdmUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTOCBQbHVzKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTOSBQbHVzKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgVGFiIEEgMTAuNSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBBIDkuNypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBFIDkuNipTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBTMypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBTNCAxMC41KlNvbnl8U29ueSBYcGVyaWEgRTUqU29ueXxTb255IFhwZXJpYSBMMSpTb255fFNvbnkgWHBlcmlhIFIxIChQbHVzKSpTb255fFNvbnkgWHBlcmlhIFRvdWNoKlNvbnl8U29ueSBYcGVyaWEgWCpTb255fFNvbnkgWHBlcmlhIFggQ29tcGFjdCpTb255fFNvbnkgWHBlcmlhIFggUGVyZm9ybWFuY2UqU29ueXxTb255IFhwZXJpYSBYQSpTb255fFNvbnkgWHBlcmlhIFhBIFVsdHJhKlNvbnl8U29ueSBYcGVyaWEgWEExKlNvbnl8U29ueSBYcGVyaWEgWEExIFBsdXMqU29ueXxTb255IFhwZXJpYSBYQTEgVWx0cmEqU29ueXxTb255IFhwZXJpYSBYQTIqU29ueXxTb255IFhwZXJpYSBYQTIgUGx1cypTb255fFNvbnkgWHBlcmlhIFhBMiBVbHRyYSpTb255fFNvbnkgWHBlcmlhIFhaKlNvbnl8U29ueSBYcGVyaWEgWFogUHJlbWl1bSpTb255fFNvbnkgWHBlcmlhIFhaMSpTb255fFNvbnkgWHBlcmlhIFhaMSBDb21wYWN0KlNvbnl8U29ueSBYcGVyaWEgWFoyKlNvbnl8U29ueSBYcGVyaWEgWFoyIENvbXBhY3QqU29ueXxTb255IFhwZXJpYSBYWjIgUHJlbWl1bSpTb255fFNvbnkgWHBlcmlhIFhacypTb255fFNvbnkgWHBlcmlhIFoxKlNvbnl8U29ueSBYcGVyaWEgWjUqU29ueXxTb255IFhwZXJpYSBaNSBQcmVtaXVtKlNvbnl8U3ByaW50IEdhbGF4eSBUYWIgRSA4LjAqVml2b3x2aXZvIE5FWCpWaXZvfHZpdm8gTkVYIEEqVml2b3x2aXZvIE5FWCBTKlZpdm98dml2byBWMTEqVml2b3x2aXZvIFYxMSBQcm8qVml2b3x2aXZvIFYxMWkqVml2b3x2aXZvIFY3KlZpdm98dml2byBWNyBQbHVzKlZpdm98dml2byBWOSpWaXZvfHZpdm8gVjkgWW91dGgqVml2b3x2aXZvIFgyMCpWaXZvfHZpdm8gWDIwIFBsdXMqVml2b3x2aXZvIFgyMCBVRCpWaXZvfHZpdm8gWDIxKlZpdm98dml2byBYMjEgVUQqVml2b3x2aXZvIFgyMWkqVml2b3x2aXZvIFgyMypWaXZvfFZpdm8gWDkqVml2b3xWaXZvIFg5IFBsdXMqVml2b3xWaXZvIFg5cypWaXZvfFZpdm8gWDlzIFBsdXMqVml2b3x2aXZvIFk1M2kqVml2b3x2aXZvIFk3MSpWaXZvfHZpdm8gWTcxaSpWaXZvfHZpdm8gWTgxKlZpdm98dml2byBZODMqVml2b3x2aXZvIFk4MyBQcm8qVml2b3x2aXZvIFk5NypWaXZvfHZpdm8gWjEqVml2b3x2aXZvIFoxaSpWaXZvfFdpbGV5Zm94IFN3aWZ0KlhpYW9taXxYaWFvbWkgTWkgMypYaWFvbWl8WGlhb21pIE1pIDQqWGlhb21pfFhpYW9taSBNaSA1KlhpYW9taXxYaWFvbWkgTWkgNipYaWFvbWl8WGlhb21pIE1pIEExKlhpYW9taXxYaWFvbWkgTWkgQTIgTGl0ZSpYaWFvbWl8WGlhb21pIE1pIE1heCpYaWFvbWl8WGlhb21pIFBvY28gRjEqWGlhb21pfFhpYW9taSBSZWRtaSAyKlhpYW9taXxYaWFvbWkgUmVkbWkgNCBQcmltZSpYaWFvbWl8WGlhb21pIFJlZG1pIDRYKlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSAzKlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSA0KlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSA1KlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSA1IFBsdXMqWGlhb21pfFhpYW9taSBSZWRtaSBOb3RlIDUgUHJvKllVfFl1IEFjZSpZVXxZdSBZdW5pY29ybipZVXxZVSBZdW5pcXVlKllVfFl1IFl1bmlxdWUgMipZVXxZVSBZdXBob3JpYSpZVXxZVSBZdXJla2EqWVV8WVUgWXVyZWthIEJsYWNrKllVfFl1IFl1cmVrYSBOb3RlKllVfFl1IFl1cmVrYSBTKlpURXxaVEUgQXhvbiA3KlpURXxaVEUgQXhvbiA3IE1pbmkqWlRFfFpURSBBeG9uIDdzKlpURXxaVEUgQXhvbiA5IFBybypaVEV8WlRFIEF4b24gRWxpdGUqWlRFfFpURSBBeG9uIE1pbmkqWlRFfFpURSBBeG9uIFBybypaVEV8WlRFIEJsYWRlIEEzKlpURXxaVEUgQmxhZGUgQTYqWlRFfFpURSBCbGFkZSBWNypaVEV8WlRFIEJsYWRlIFY4KlpURXxaVEUgQmxhZGUgVjkqWlRFfFpURSBCbGFkZSBWOSBNaW5pKlpURXxaVEUgTWF2ZW4gMipaVEV8WlRFIE1heCBYTCpaVEV8WlRFIE51YmlhIFoxNypaVEV8WlRFIFRlbXBvIEdvKnhpYW9taXx4aWFvbWkgNipnb29nbGV8Z29vZ2xlIFBpeGVsIDIqeGlhb21pfHhpYW9taSA4Kmh1YXdlaXxodWF3ZWkgSG9ub3IgVjkqdml2b3x2aXZvIFg5IFBsdXMqb3Bwb3xvcHBvIHIxMSpvcHBvfG9wcG8gcjExIHBsdXMqb3Bwb3xvcHBvIFIxMSBQbHVzKm9wcG98b3BwbyBSMTcgUHJvKm1laXp1fG1laXp1IFBSTyA3IFBsdXMqbWVpenV8bWVpenUgUFJPIDYgUGx1cyp4aWFvbWl8eGlhb21pIG1peCp4aWFvbWl8bWkgMw==");
			return text.Split('*').ToList();
		}

		public void ChangeHardwareLDPlayer2()
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			Random random = new Random();
			List<string> listInfoDevice = GetListInfoDevice();
			string text8 = listInfoDevice[random.Next(0, listInfoDevice.Count)];
			text2 = text8.Split('|')[1];
			text = text8.Split('|')[0];
			text4 = "86516602" + MCommon.Common.CreateRandomNumber(7, random);
			text5 = "46000" + MCommon.Common.CreateRandomNumber(10, random);
			text6 = "898600" + MCommon.Common.CreateRandomNumber(14, random);
			text7 = MCommon.Common.Md5Encode(MCommon.Common.CreateRandomStringNumber(32, random), "x2").Substring(random.Next(0, 16), 16);
			string[] array = "+8486|+8496|+8497|+8498|+8432|+8433|+8434|+8435|+8436|+8437|+8438|+8439|+8488|+8491|+8494|+8483|+8484|+8485|+8481|+8482|+8489|+8490|+8493|+8470|+8479|+8477|+8476|+8478|+8492|+8456|+8458|+8499|+8459".Split('|');
			text3 = array[random.Next(array.Length)] + MCommon.Common.CreateRandomNumber(7, random);
			string arguments = "modify --index " + IndexDevice + " --imei " + text4 + " --model \"" + text2 + "\" --manufacturer " + text + " --pnumber " + text3 + " --imsi " + text5 + " --simserial " + text6 + " --androidid " + text7 + " --mac";
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = ConfigHelper.GetPathLDPlayer() + "\\dnconsole.exe",
				Arguments = arguments,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};
			process.Start();
			process.WaitForExit(5000);
		}

		public bool ChangeFileConfig()
		{
			try
			{
				JSON_Settings jSON_Settings = new JSON_Settings("configLDPlayer");
				string path = PathLDPlayer + "/vms/config/leidian" + IndexDevice + ".config";
				string json = File.ReadAllText(path);
				JObject jObject;
				try
				{
					jObject = JObject.Parse(json);
				}
				catch
				{
					jObject = new JObject();
				}
				jObject["statusSettings.playerName"] = (JToken)("LDPlayer-" + IndexDevice);
				int valueInt = jSON_Settings.GetValueInt("nudSizeW", 320);
				int valueInt2 = jSON_Settings.GetValueInt("nudSizeH", 480);
				int valueInt3 = jSON_Settings.GetValueInt("nudDPI", 120);
				int num = Convert.ToInt32(jSON_Settings.GetValue("cbbCPU", "1 cores (Khuyê\u0301n nghi\u0323)").Split(' ')[0]);
				int num2 = Convert.ToInt32(jSON_Settings.GetValue("cbbRAM", "1024M (Khuyê\u0301n nghi\u0323)").Split('M')[0]);
				if (!jObject.ContainsKey("advancedSettings.resolution"))
				{
					jObject.Add("advancedSettings.resolution", new JObject
					{
						{
							"width",
							(JToken)valueInt
						},
						{
							"height",
							(JToken)valueInt2
						}
					});
				}
				else
				{
					jObject["advancedSettings.resolution"]!["width"] = (JToken)valueInt;
					jObject["advancedSettings.resolution"]!["height"] = (JToken)valueInt2;
				}
				jObject["advancedSettings.resolutionDpi"] = (JToken)valueInt3;
				jObject["advancedSettings.cpuCount"] = (JToken)num;
				jObject["advancedSettings.memorySize"] = (JToken)num2;
				File.WriteAllText(path, jObject.ToString());
				return true;
			}
			catch
			{
			}
			return false;
		}

		public void Restore()
		{
		}

		public bool CheckOpenedDevice(int timeout = 60)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < timeout; i++)
				{
					if (!CheckIsLive())
					{
						break;
					}
					List<string> devices = ADBHelper.GetDevices();
					List<string> lstDeviceIdCheck = new List<string>
					{
						"127.0.0.1:" + (IndexDevice * 2 + 5555),
						"emulator-" + (IndexDevice * 2 + 5554)
					};
					list = devices.Where((string x) => lstDeviceIdCheck.Contains(x)).ToList();
					if (list.Count <= 0)
					{
						if (i == 30)
						{
							for (int j = 0; j < lstDeviceIdCheck.Count; j++)
							{
								ADBHelper.DisconnectDevice(lstDeviceIdCheck[j]);
							}
							ADBHelper.ConnectDevice(lstDeviceIdCheck[0]);
						}
						DelayTime(1.0);
						continue;
					}
					DeviceId = list[0];
					for (int k = 0; k < 60; k++)
					{
						if (!CheckIsLive())
						{
							break;
						}
						string activity = GetActivity();
						if (!(activity == "com.android.launcher3/com.android.launcher3.Launcher") && !(activity != ""))
						{
							Thread.Sleep(1000);
							continue;
						}
						return true;
					}
					return false;
				}
			}
			catch
			{
			}
			return false;
		}

		public bool DoubleTap(int x, int y)
		{
			if (CheckBoundsContainLocation("[0,0][320,480]", x, y))
			{
				ExecuteCMD($"shell \"input tap {x} {y} & sleep 0.1; input tap {x} {y}\"");
				return true;
			}
			return false;
		}

		public bool DoubleTap(Point p)
		{
			if (CheckBoundsContainLocation("[0,0][320,480]", p.X, p.Y))
			{
				ExecuteCMD($"shell \"input tap {p.X} {p.Y} & sleep 0.1; input tap {p.X} {p.Y}\"");
				return true;
			}
			return false;
		}

		public string CheckIP()
		{
			return ADBHelper.Curl(DeviceId, "https://api64.ipify.org/").Trim();
		}

		public void Close()
		{
			try
			{
				ADBHelper.QuitDevice(PathLDPlayer, IndexDevice);
			}
			catch
			{
			}
		}

		public void Open(int timeout = 120)
		{
			ADBHelper.LaunchDevice(PathLDPlayer, IndexDevice);
			int tickCount = Environment.TickCount;
			try
			{
				int num = 0;
				do
				{
					process = (from x in Process.GetProcessesByName("dnplayer")
						where x.MainWindowTitle.Equals("LDPlayer-" + IndexDevice)
						select x).FirstOrDefault();
					if (process == null)
					{
						num++;
						if (num % 5 == 0)
						{
							ADBHelper.LaunchDevice(PathLDPlayer, IndexDevice);
						}
						DelayTime(1.0);
						continue;
					}
					break;
				}
				while (Environment.TickCount - tickCount <= timeout * 1000);
			}
			catch
			{
			}
		}

		public string ScreenShoot(string pathFolder = "", string fileName = "*.png")
		{
			try
			{
				if (!string.IsNullOrEmpty(pathFolder))
				{
					Directory.CreateDirectory(pathFolder);
				}
				fileName = Path.GetFileNameWithoutExtension(fileName) + Path.GetExtension(fileName);
				ADBHelper.ScreenCap(DeviceId, "/sdcard/" + fileName);
				if (string.IsNullOrEmpty(pathFolder))
				{
					pathFolder = FileHelper.GetPathToCurrentFolder();
				}
				PullFile("/sdcard/" + fileName, pathFolder);
				ExecuteCMD("shell rm /sdcard/*.png");
				return pathFolder + "\\" + fileName;
			}
			catch
			{
			}
			return "";
		}

		public Bitmap ScreenShoot()
		{
			Bitmap result = null;
			try
			{
				string fileName = ScreenShoot("", CreateRandomString(10, "a") + ".png");
				result = GetBitmapFromFile(fileName);
			}
			catch
			{
			}
			return result;
		}

		private Bitmap GetBitmapFromFile(string fileName, bool isDeleteFile = true)
		{
			Bitmap result = null;
			try
			{
				using FileStream stream = File.OpenRead(fileName);
				result = (Bitmap)Image.FromStream(stream);
			}
			catch
			{
			}
			if (isDeleteFile)
			{
				MCommon.Common.DeleteFile(fileName);
			}
			return result;
		}

		public void PushImageToDevice(string filePath)
		{
			DeleteFolder("/sdcard/launcher/ad");
			DeleteFolder("/sdcard/Pictures");
			PushFile(filePath, "/sdcard/Pictures");
			ExecuteCMD("shell rm /sdcard/*.png");
			ExecuteCMD("shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures");
		}

		public bool ClosePopup(ref string html)
		{
			if (ClosePopup(html))
			{
				html = GetHtml();
				return true;
			}
			return false;
		}

		public bool ClosePopup(string html = "")
		{
			bool flag = false;
			if (CheckExistImage("DataClick\\image\\x"))
			{
				TapByImageWait("DataClick\\image\\x", 0, 3);
				flag = true;
			}
			else
			{
				if (html == "")
				{
					html = GetHtml();
				}
				string text = CheckExistTextsV2(html, 0.0, GetListTextClosePopup().ToArray());
				if (text != "" && (!(text == "\"cancel\"") || !CheckExistText("request sent", html)))
				{
					TapByText(text, html);
				}
			}
			if (flag)
			{
				DelayTime(1.0);
				if (CheckExistImage("DataClick\\image\\stop"))
				{
					TapByImageWait("DataClick\\image\\stop");
				}
				else
				{
					html = GetHtml();
					if (CheckExistText("\"stop\"", html))
					{
						TapByText("\"stop\"", html);
					}
				}
			}
			return flag;
		}

		public int CheckStatusDevice(ref string html, bool isAllowClickImageX = true)
		{
			try
			{
				if (!CheckIsLive())
				{
					return -2;
				}
				Bitmap bitmap_screen = ScreenShoot();
				if (CheckExistImage("DataClick\\image\\logout", bitmap_screen))
				{
					return -11;
				}
				if (CheckExistImage("DataClick\\image\\checkpoint", bitmap_screen))
				{
					return 2;
				}
				if (CheckExistImage("DataClick\\image\\openappagain", bitmap_screen))
				{
					countOpenAppAgain++;
					if (countOpenAppAgain >= 3)
					{
						return -4;
					}
					TapByImageWait("DataClick\\image\\openappagain");
					return 1;
				}
				string activity = GetActivity();
				if (activity.Contains("Launcher"))
				{
					OpenAppFacebook();
					return 1;
				}
				if (activity == "Application")
				{
					return -4;
				}
				Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>
				{
					{
						1,
						GetListActivityCheckpointFacebook()
					},
					{
						2,
						GetListActivityNotLoginFacebook()
					}
				};
				switch (CheckStringContainText(activity, dic))
				{
				default:
				{
					html = GetHtml();
					ClosePopup(ref html);
					List<string> listText = GetListText(html);
					if (listText.Count == 2 && listText.Contains("back") && (listText.Contains("search") || listText.Contains("web view")))
					{
						return -13;
					}
					if (listText.Count == 3 && listText.Contains("back") && listText.Contains("facebook") && listText.Contains("web view"))
					{
						return -14;
					}
					Dictionary<int, List<string>> dic2 = new Dictionary<int, List<string>>
					{
						{
							1,
							GetListTextCheckpointFacebook()
						},
						{
							4,
							new List<string> { "session expired", "please log in again." }
						}
					};
					switch (CheckStringContainText(html, dic2))
					{
					default:
					{
						bool flag = true;
						for (int i = 0; i < 2; i++)
						{
							html = GetHtml();
							if (CheckExistText("\"tap to retry\"", html))
							{
								TapByText("\"tap to retry\"", html);
								DelayTime(1.0);
								continue;
							}
							flag = false;
							break;
						}
						if (!flag)
						{
							demDisconnect = 0;
						}
						else if (demDisconnect < maxDisconnect)
						{
							demDisconnect++;
							flag = false;
						}
						if (flag)
						{
							return 7;
						}
						break;
					}
					case 1:
						return 2;
					case 2:
						return -4;
					case 3:
						return 7;
					case 4:
						return -15;
					}
					break;
				}
				case 2:
					return -12;
				case 1:
					return 2;
				}
			}
			catch
			{
			}
			return 0;
		}

		private int CheckStringContainText(string sChuoi, Dictionary<int, List<string>> dic)
		{
			foreach (KeyValuePair<int, List<string>> item in dic)
			{
				foreach (string item2 in item.Value)
				{
					if (Regex.IsMatch(sChuoi, item2) || sChuoi.Contains(item2))
					{
						return item.Key;
					}
				}
			}
			return 0;
		}

		private bool CheckItemIsExistInList(string item, List<string> lst)
		{
			int num = 0;
			while (true)
			{
				if (num < lst.Count)
				{
					if (item.Contains(lst[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		private int CheckStatusLoginFacebookByActivity(string activity)
		{
			int result = -1;
			try
			{
				if (CheckItemIsExistInList(activity, GetListActivityLoginedFacebook()))
				{
					result = 1;
				}
				else if (CheckItemIsExistInList(activity, GetListActivityCheckpointFacebook()))
				{
					result = 2;
				}
				else if (CheckItemIsExistInList(activity, GetListActivityLoginedNoveryFacebook()))
				{
					result = 8;
				}
				else if (CheckItemIsExistInList(activity, GetListActivityNotLoginFacebook()))
				{
					result = 0;
				}
			}
			catch
			{
			}
			return result;
		}

		private int CheckStatusLoginFacebookByText(string xml)
		{
			int result = 0;
			try
			{
				if (xml == "")
				{
					xml = GetHtml();
				}
				ClosePopup(ref xml);
				if (CheckExistTexts(xml, 0.0, GetListTextLoginedFacebook().ToArray()) != 0)
				{
					result = 1;
				}
				else if (CheckExistTexts(xml, 0.0, GetListTextCheckpointFacebook().ToArray()) != 0)
				{
					result = 2;
				}
				else if (CheckExistTexts(xml, 0.0, GetListTextLoginedNoveryFacebook().ToArray()) != 0)
				{
					result = 8;
				}
				else if (CheckExistTexts(xml, 0.0, "session expired", "please log in again.") != 0)
				{
					result = 11;
				}
			}
			catch
			{
			}
			return result;
		}

		private List<string> GetListActivityNotLoginFacebook()
		{
			return new List<string> { "com.facebook.katana/com.facebook.katana.dbl.activity.DeviceBasedLoginActivity" };
		}

		private List<string> GetListActivityLoginedFacebook()
		{
			return new List<string> { "com.facebook.katana/com.facebook.katana.activity.FbMainTabActivity", "com.facebook.katana/com.facebook.location.optin.DeviceLocationSettingsOptInActivity", "com.facebook.katana/com.facebook.location.optin.AccountLocationSettingsOptInActivity", "com.facebook.katana/com.facebook.account.switcher.nux.ActivateDeviceBasedLoginNuxActivity" };
		}

		private List<string> GetListActivityCheckpointFacebook()
		{
			return new List<string> { "com.facebook.katana/com.facebook.checkpoint.CheckpointActivity", "checkpoint" };
		}

		private List<string> GetListActivityLoginedNoveryFacebook()
		{
			return new List<string> { "com.facebook.confirmation.activity.SimpleConfirmAccountActivity" };
		}

		private static List<string> GetListTextLoginedFacebook()
		{
			return new List<string>
			{
				"\"search facebook\"", "\"go to profile\"", "\"make a post on facebook\"", "\"live\"", "\"messaging\"", "\"photo\"", "\"check in\"", "\"stories\"", "\"marketplace\"", "\"notifications,",
				"\"save your login info\""
			};
		}

		private static List<string> GetListTextCheckpointFacebook()
		{
			return new List<string>
			{
				"your account is temporarily unavailable", "your account is temporarily locked", "your account has been disabled", "your account has been locked", "\"learn more\"", "download your information", "go to community standards", "choose a security check", "provide your birthday", "identify photos of friends",
				"get a code sent to your email", "enter number", "check the login details shown. was it you?"
			};
		}

		private static List<string> GetListTextLoginedNoveryFacebook()
		{
			return new List<string> { "\"confirmation code\"", "\"change phone number\"", "\"confirm by email\"", "\"change email address\"", "\"confirm by phone number\"" };
		}

		public static List<string> GetListTextClosePopup()
		{
			return new List<string> { "\"close\"", "\"skip\"", "\"cancel\"", "\"got it\"" };
		}

		public void OpenAppFacebook()
		{
			GrantPermission();
			OpenApp("com.facebook.katana");
			string text = "";
			for (int i = 0; i < 10; i++)
			{
				text = GetActivity();
				if (!text.Contains("com.facebook.katana"))
				{
					if (text.Contains("Launcher"))
					{
						TapByText("facebook");
					}
					else
					{
						OpenApp("com.facebook.katana");
					}
					DelayTime(3.0);
					continue;
				}
				break;
			}
		}

		public void CloseAppFacebook()
		{
			CloseApp("com.facebook.katana");
		}

		public bool SyncContactByFb()
		{
			bool result = true;
			string html = "";
			try
			{
				OpenActivity("com.facebook.katana/com.facebook.katana.settings.activity.SettingsActivity");
				for (int i = 0; i < 2; i++)
				{
					switch (CheckExistTexts("", 5.0, "continuous contacts upload, off, switch", "continuous contacts upload, on, switch"))
					{
					case 2:
					{
						bool flag2 = false;
						int num4 = 1;
						do
						{
							switch (num4)
							{
							case 1:
								flag2 = TapByText("continuous contacts upload, on, switch");
								goto IL_00ab;
							case 2:
								flag2 = TapByText("turn off", "", 5);
								goto IL_00ab;
							}
							break;
							IL_00ab:
							num4++;
						}
						while (flag2);
						break;
					}
					case 1:
					{
						i++;
						bool flag = false;
						int num = 1;
						int num2 = 1;
						int num3 = 1;
						while (true)
						{
							IL_0237:
							flag = TapByText("continuous contacts upload, off, switch");
							while (true)
							{
								num++;
								if (flag)
								{
									switch (num)
									{
									case 2:
										break;
									case 3:
										goto IL_01d0;
									case 1:
										goto IL_0237;
									default:
										goto IL_0253;
									}
									flag = CheckExistTexts(ref html, 5.0, "\"contacts upload\"", "\"get started\"") switch
									{
										2 => TapByText("\"get started\"", html), 
										1 => TapByText("\"contacts upload\"", html), 
										_ => false, 
									};
									continue;
								}
								break;
								IL_01d0:
								for (int j = 0; j < 30; j++)
								{
									html = GetHtml();
									if (CheckExistText("people you may know", html))
									{
										break;
									}
									DelayTime(1.0);
								}
								continue;
								IL_0253:
								if (num < 4)
								{
									ExportError(null, "SyncContactByFb: step " + num);
								}
								break;
							}
							break;
						}
						break;
					}
					}
				}
				return result;
			}
			catch
			{
				return false;
			}
		}

		public bool ClickReactions(int typeReaction = 1)
		{
			try
			{
				List<string> list = new List<string> { "like", "love", "haha", "wow", "sad", "angry" };
				if (typeReaction == 6)
				{
					typeReaction = GetRandomInt(0, 4);
				}
				TapByImage("DataClick\\image\\reaction\\" + list[typeReaction]);
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		public string OpenFacebookAndCheckStatusLogin(int timeout = 120)
		{
			string result = "0|";
			try
			{
				string text = "";
				string html = "";
				int num = -1;
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (CheckIsLive())
					{
						text = GetActivity();
						if (text.Contains("Launcher"))
						{
							OpenAppFacebook();
						}
						else
						{
							if (text == "Application")
							{
								result = "2|";
								break;
							}
							if (text == "")
							{
								if (!ClosePopup(html))
								{
									if (CheckExistText("\"close", html))
									{
										TapByText("\"close", html);
										TapByText("\"back\"");
									}
									else
									{
										OpenAppFacebook();
									}
								}
							}
							else
							{
								List<string> list = new List<string> { "com.facebook.katana/com.facebook.katana.app.FacebookSplashScreenActivity", "com.facebook.katana/com.facebook.deeplinking.activity.StoryDeepLinkLoadingActivity", "com.facebook.katana/com.facebook.resources.impl.WaitingForStringsActivity" };
								if (!list.Contains(text))
								{
									Bitmap bitmap_screen = ScreenShoot();
									string boundsByImage = GetBoundsByImage("DataClick\\image\\phoneoremail", bitmap_screen);
									string boundsByImage2 = GetBoundsByImage("DataClick\\image\\password", bitmap_screen);
									string boundsByImage3 = GetBoundsByImage("DataClick\\image\\login", bitmap_screen);
									if (boundsByImage != "" && boundsByImage2 != "" && boundsByImage3 != "")
									{
										result = "1|0";
										break;
									}
									if (CheckExistImage("DataClick\\image\\checkpoint"))
									{
										num = 2;
									}
									else
									{
										html = "";
										if (CheckExistImage("DataClick\\image\\ok") && !CheckExistImage("DataClick\\image\\facebook"))
										{
											TapByImageWait("DataClick\\image\\ok");
										}
										else if (CheckExistText("\"ok\"", ref html))
										{
											TapByText("\"ok\"", html);
										}
										else if (!ClosePopup(html) && CheckExistText("\"close", html))
										{
											TapByText("\"close", html);
											TapByText("\"back\"");
										}
										num = CheckStatusLoginFacebookByActivity(text);
										if (num == -1)
										{
											html = GetHtml();
											num = CheckStatusLoginFacebookByText(html);
										}
									}
									if (Environment.TickCount - tickCount >= timeout * 1000)
									{
										goto IL_0305;
									}
								}
							}
						}
						if (num == -1)
						{
							continue;
						}
					}
					goto IL_0305;
					IL_0305:
					if (num != -1)
					{
						result = "1|" + num;
					}
					break;
				}
			}
			catch
			{
			}
			return result;
		}

		public void CheckDevice(string activity = "", string html = "", string folderPath = "")
		{
			if (fViewLD.remote != null)
			{
				fViewLD.remote.ExportLog(IndexDevice, activity, html, folderPath);
			}
		}

		public void LoadStatusLD(string content)
		{
			if (fViewLD.remote != null)
			{
				fViewLD.remote.LoadStatus(IndexDevice, content);
			}
		}

		public void LoadHanhDongLD(string content)
		{
			if (fViewLD.remote != null)
			{
				fViewLD.remote.LoadHanhDong(IndexDevice, content);
			}
		}

		public int LoginFacebook(string username, string password, string fa2, int timeOut = 180)
		{
			int num = 0;
			int tickCount = Environment.TickCount;
			string text = "";
			string text2 = "";
			int num2 = -1;
			int num3 = 0;
			int num4 = 0;
			while (num == 0 && Environment.TickCount - tickCount < timeOut * 1000 && CheckIsLive())
			{
				text2 = GetActivity();
				if (text2.Contains("Launcher"))
				{
					OpenAppFacebook();
					continue;
				}
				List<string> list = new List<string> { "", "com.facebook.katana/com.facebook.deeplinking.activity.StoryDeepLinkLoadingActivity", "com.facebook.katana/com.facebook.katana.app.FacebookSplashScreenActivity", "com.facebook.katana/com.facebook.resources.impl.WaitingForStringsActivity" };
				if (list.Contains(text2))
				{
					if (!(text2 == "com.facebook.katana/com.facebook.resources.impl.WaitingForStringsActivity") && text2 == "")
					{
						ClosePopup();
					}
					continue;
				}
				if (text2 == "com.facebook.katana/com.facebook.katana.dbl.activity.DeviceBasedLoginActivity")
				{
					Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>
					{
						{
							1,
							new List<string> { "\"lần tới đăng nhập" }
						},
						{
							2,
							new List<string> { "sai thông tin đăng nhập", "session expired", "please log in again." }
						},
						{
							3,
							new List<string> { "xác nhận danh tính của bạn" }
						},
						{
							4,
							new List<string> { "log into another account" }
						},
						{
							5,
							new List<string> { "\"log in\"" }
						},
						{
							6,
							new List<string> { "\"tap to retry\"" }
						},
						{
							7,
							new List<string> { "\"login code required", "\"login code", "\"cần mã", "\"lỗi xác thực\"", "yêu cầu xác thực hai yếu tố" }
						},
						{
							8,
							new List<string> { "your account is temporarily unavailable" }
						}
					};
					text = GetHtml();
					switch (CheckExistTexts(text, 0.0, dic))
					{
					default:
						if (CheckExistImage("DataClick\\image\\ok") && !CheckExistImage("DataClick\\image\\facebook"))
						{
							TapByImageWait("DataClick\\image\\ok");
						}
						continue;
					case 1:
						TapByText("\"close\"", text);
						continue;
					case 2:
						TapByText("\"ok\"", text);
						continue;
					case 3:
						TapByText("\"get started\"", text);
						continue;
					case 4:
					{
						Point locationFromBounds = GetLocationFromBounds(GetBoundsByText("log into another account", text));
						if (!locationFromBounds.IsEmpty)
						{
							Tap(locationFromBounds.X, locationFromBounds.Y - 49);
							DelayTime(1.0);
						}
						continue;
					}
					case 5:
						InputText(password);
						TapByText("\"log in\"", text);
						continue;
					case 6:
						if (num4 < 3)
						{
							TapByText("\"tap to retry\"", text);
							num4++;
							continue;
						}
						break;
					case 7:
						if (string.IsNullOrEmpty(fa2))
						{
							num = 3;
							continue;
						}
						num3++;
						if (num3 <= 2)
						{
							TapByText("\"ok\"", text);
							text = GetHtml();
							LoadStatusLD("Get 2FA...");
							string totp = MCommon.Common.GetTotp(fa2);
							if (!string.IsNullOrEmpty(totp))
							{
								TapByText("\"login code\"", text);
								InputText(totp);
								TapByText("\"continue\"", text);
								continue;
							}
							num = 6;
						}
						else
						{
							num = 6;
						}
						break;
					case 8:
						TapByText("\"ok\"", text);
						TapByText("another account", "", 5);
						continue;
					}
					break;
				}
				num2 = CheckStatusLoginFacebookByActivity(text2);
				if (num2 == 0 || num2 == -1)
				{
					bool flag = false;
					Bitmap bitmap_screen = ScreenShoot();
					string boundsByImage = GetBoundsByImage("DataClick\\image\\phoneoremail", bitmap_screen);
					string boundsByImage2 = GetBoundsByImage("DataClick\\image\\password", bitmap_screen);
					string boundsByImage3 = GetBoundsByImage("DataClick\\image\\login", bitmap_screen);
					if (boundsByImage != "" && boundsByImage2 != "" && boundsByImage3 != "")
					{
						flag = true;
					}
					if (!flag)
					{
						text = GetHtml();
						num2 = CheckStatusLoginFacebookByText(text);
						if (num2 != 0)
						{
							num = num2;
							break;
						}
					}
					if (!flag && CheckExistTexts(text, 0.0, "session expired", "please log in again.") != 0)
					{
						TapByText("\"ok\"", text);
						DelayTime(3.0);
						continue;
					}
					if (!flag && CheckExistText("lúc khác", text))
					{
						TapByText("\"ok\"", text);
						DelayTime(1.0);
						continue;
					}
					if (!flag && CheckExistText("\"continue\"", text))
					{
						TapByText("\"continue\"", text);
						DelayTime(1.0);
						continue;
					}
					if (!flag && CheckExistImage("DataClick\\image\\ok") && !CheckExistImage("DataClick\\image\\facebook"))
					{
						TapByImageWait("DataClick\\image\\ok");
						DelayTime(1.0);
						continue;
					}
					if (!flag)
					{
						bitmap_screen = ScreenShoot();
						boundsByImage = GetBoundsByImage("DataClick\\image\\phoneoremail", bitmap_screen);
						boundsByImage2 = GetBoundsByImage("DataClick\\image\\password", bitmap_screen);
						boundsByImage3 = GetBoundsByImage("DataClick\\image\\login", bitmap_screen);
						if (boundsByImage == "" || boundsByImage2 == "" || boundsByImage3 == "")
						{
							num2 = CheckStatusLoginFacebookByText("");
							if (num2 != 0)
							{
								num = num2;
							}
							else
							{
								CheckDevice(text2, text);
							}
							break;
						}
					}
					TapByBounds(boundsByImage);
					InputText(username);
					DelayTime(1.0);
					TapByBounds(boundsByImage);
					DelayTime(1.0);
					TapByBounds(boundsByImage2);
					InputTextWithUnicode(password);
					DelayTime(1.0);
					TapByBounds(boundsByImage3);
					Dictionary<int, List<string>> dic2 = new Dictionary<int, List<string>>
					{
						{
							18,
							new List<string> { "use this feature right now", "login failed" }
						},
						{
							1,
							new List<string> { "can't find account", "need help finding your account?" }
						},
						{
							17,
							new List<string> { "đã xảy ra lỗi khi đăng nhập. vui lòng thử lại sau." }
						},
						{
							2,
							new List<string> { "incorrect password", "mật khẩu cũ", "older password" }
						},
						{
							3,
							new List<string> { "login code required", "\"two-factor authentication", "\"authentication error\"", "yêu cầu xác thực hai yếu tố" }
						},
						{
							5,
							new List<string> { "logging in…", "loading…" }
						},
						{
							6,
							new List<string> { "kiểm tra kết nối" }
						},
						{
							7,
							new List<string> { "\"skip\"" }
						},
						{
							11,
							new List<string> { "\"no thanks\"" }
						},
						{
							8,
							new List<string> { "\"continue\"" }
						},
						{
							9,
							new List<string> { "save your login info" }
						},
						{
							12,
							GetListTextLoginedNoveryFacebook()
						},
						{
							13,
							GetListTextLoginedFacebook()
						},
						{
							14,
							new List<string> { "tải danh bạ lên", "\"lúc khác\"" }
						},
						{
							15,
							new List<string> { "tap to retry" }
						},
						{
							16,
							new List<string> { "thêm số di động vào tài khoản của bạn" }
						},
						{
							20,
							new List<string> { "confirm your identity" }
						},
						{
							21,
							new List<string> { "allow facebook to access your location?", "\"deny\"" }
						},
						{
							22,
							new List<string> { "allow contacts access to find people to follow" }
						},
						{
							4,
							GetListTextCheckpointFacebook()
						}
					};
					while (Environment.TickCount - tickCount < timeOut * 1000 && CheckIsLive())
					{
						text = GetHtml();
						num2 = CheckExistTexts(text, 0.0, dic2);
						switch (num2)
						{
						case 1:
							num = 4;
							goto IL_10ec;
						case 2:
							num = 5;
							goto IL_10ec;
						case 4:
							num = 2;
							goto IL_10ec;
						case 6:
							num = 7;
							goto IL_10ec;
						case 7:
							TapByText("\"skip\"", text);
							goto IL_10ec;
						case 3:
						case 8:
							if (num2 == 8 && !CheckExistText("\"login code\"", text))
							{
								TapByText("\"continue\"", text);
							}
							else if (string.IsNullOrEmpty(fa2))
							{
								num = 3;
							}
							else
							{
								num3++;
								if (num3 > 2)
								{
									num = 6;
									break;
								}
								if (num2 == 3)
								{
									TapByText("\"ok\"", text);
									text = GetHtml();
								}
								LoadStatusLD("Get 2FA...");
								string totp2 = MCommon.Common.GetTotp(fa2);
								if (string.IsNullOrEmpty(totp2))
								{
									num = 6;
									break;
								}
								TapByText("\"login code\"", text);
								InputText(totp2);
								TapByText("\"continue\"", text);
							}
							goto IL_10ec;
						case 9:
							TapByText("\"ok\"", text);
							goto IL_10ec;
						case 11:
							if (TapByText("\"no thanks\""))
							{
								TapByImage("DataClick\\image\\sudungdulieu", null, 10);
							}
							goto IL_10ec;
						case 12:
							num = 8;
							goto IL_10ec;
						case 13:
							num = 1;
							goto IL_10ec;
						case 14:
							TapByText("\"lúc khác\"", text);
							goto IL_10ec;
						case 15:
							if (num4 >= 3)
							{
								break;
							}
							TapByText("\"tap to retry\"", text);
							num4++;
							goto IL_10ec;
						case 16:
							num = 9;
							goto IL_10ec;
						case 18:
							if (CheckExistText("please check your internet connection", text))
							{
								TapByText("\"ok\"", text);
								TapByImage("DataClick\\image\\login", null, 10);
							}
							else
							{
								num = 10;
							}
							goto IL_10ec;
						default:
							text2 = GetActivity();
							if (CheckExistImage("DataClick\\image\\sudungdulieu"))
							{
								TapByImage("DataClick\\image\\sudungdulieu");
							}
							else if (CheckExistImage("DataClick\\image\\skip"))
							{
								TapByImage("DataClick\\image\\skip");
							}
							else if (CheckExistImage("DataClick\\image\\ok") && !CheckExistImage("DataClick\\image\\facebook"))
							{
								TapByImageWait("DataClick\\image\\ok");
							}
							else if (CheckExistText("web view", text) && (text2.Contains("activity.ImmersiveActivity") || text2.Contains("LoggedOutWebViewActivity")))
							{
								num = 2;
							}
							else if (text2 == "com.facebook.katana/com.facebook.location.optin.AccountLocationSettingsOptInActivity")
							{
								if (CheckExistText("\"deny\"", text))
								{
									TapByText("\"deny\"", text);
								}
								else if (CheckExistImage("DataClick\\image\\notnow"))
								{
									TapByImage("DataClick\\image\\notnow");
								}
								else if (CheckExistImage("DataClick\\image\\deny"))
								{
									TapByImage("DataClick\\image\\deny");
								}
							}
							else
							{
								text = GetHtml();
								List<string> listText = GetListText(text);
								if (listText.Count == 1 && listText.Contains("get started"))
								{
									num = 2;
								}
							}
							goto IL_10ec;
						case 20:
							if (CheckExistText("\"get started\""))
							{
								TapByText("\"get started\"", text);
							}
							else
							{
								num = 2;
							}
							goto IL_10ec;
						case 21:
							if (CheckExistText("\"deny\"", text))
							{
								TapByText("\"deny\"", text);
							}
							else
							{
								TapByImage("DataClick\\image\\deny");
							}
							goto IL_10ec;
						case 22:
							TapByImage("DataClick\\image\\skip");
							goto IL_10ec;
						case 5:
							goto IL_10ec;
						case 17:
							break;
						}
						break;
						IL_10ec:
						if (num != 0)
						{
							break;
						}
					}
					break;
				}
				num = num2;
				break;
			}
			return num;
		}

		public string GetTokenCookie()
		{
			string text = "";
			string text2 = "";
			try
			{
				string input = ReadFile("data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/authentication");
				text = Regex.Match(input, "EAAAAU\\S+").Value;
				string value = Regex.Match(text, "\u0005(.*?)$").Value;
				text = text.Replace(value, "");
				string json = "{\"data\": [" + Regex.Match(input, "\\[(.*?)\\]").Groups[1].Value + "]}";
				JObject jObject = JObject.Parse(json);
				for (int i = 0; i < jObject["data"].Count(); i++)
				{
					text2 = text2 + jObject["data"]![i]!["name"]!.ToString() + "=" + jObject["data"]![i]!["value"]!.ToString() + ";";
				}
			}
			catch
			{
			}
			return text + "|" + text2;
		}

		public bool WaitForLoaded(int timeWait_Second)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (CheckExistXpath("/[@class='android.widget.progressbar']"))
					{
						if (Environment.TickCount - tickCount < timeWait_Second * 1000)
						{
							DelayTime(1.0);
							continue;
						}
						break;
					}
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public void RestoreAccountFacebook(string uid)
		{
			if (!CheckIsLive() || string.IsNullOrEmpty(uid))
			{
				return;
			}
			string text = FileHelper.GetPathToCurrentFolder() + "\\profile";
			string text2 = text + "\\" + uid;
			string text3 = text2 + ".zip";
			string text4 = text2 + "\\1";
			string text5 = text2 + "\\2";
			string text6 = text2 + "\\3";
			ClearDataAppFacebook();
			if (File.Exists(text3))
			{
				MCommon.Common.UnZipFolder(text3, text2);
			}
			string text7 = text2 + "\\data.tar.gz";
			if (File.Exists(text7))
			{
				DeleteFile("/data/data.tar.gz");
				PushFile(text7, "/data/");
				DelayTime(1.0);
				UnZipFile("/data/data.tar.gz");
				DelayTime(5.0);
			}
			else if (File.Exists(text3) || (Directory.Exists(text4) && Directory.Exists(text5) && Directory.Exists(text6)))
			{
				ExecuteCMD("adb shell mkdir /data/data/com.facebook.katana/app_light_prefs && adb shell mkdir /data/data/com.facebook.katana/app_light_prefs/com.facebook.katana && adb shell mkdir /data/data/com.facebook.katana/shared_prefs && adb shell mkdir /data/data/com.facebook.katana/databases");
				string cmd = "adb push \"" + text4 + "\" /data/data/com.facebook.katana/app_light_prefs/com.facebook.katana";
				string cmd2 = "adb push \"" + text5 + "\" /data/data/com.facebook.katana/shared_prefs";
				string cmd3 = "adb push \"" + text6 + "\" /data/data/com.facebook.katana/databases";
				ADBHelper.RunCMD(DeviceId, cmd);
				ADBHelper.RunCMD(DeviceId, cmd2);
				int valueInt = new JSON_Settings("configLDPlayer").GetValueInt("typeBackupDataFb");
				if (valueInt == 1)
				{
					ADBHelper.RunCMD(DeviceId, cmd3, 3);
				}
			}
			ExecuteCMD("shell chmod -R 7777 /data/data/com.facebook.katana/");
			DelayTime(1.0);
			MCommon.Common.DeleteFolder(text2);
		}

		public void BackupAccountFacebook(string uid, string pass, string fa2)
		{
			if (!CheckIsLive() || string.IsNullOrEmpty(uid))
			{
				return;
			}
			string text = FileHelper.GetPathToCurrentFolder() + "\\profile";
			string text2 = text + "\\" + uid;
			string text3 = text2 + "\\1";
			string text4 = text2 + "\\2";
			string text5 = text2 + "\\3";
			Directory.CreateDirectory(text);
			Directory.CreateDirectory(text2);
			Directory.CreateDirectory(text3);
			Directory.CreateDirectory(text4);
			Directory.CreateDirectory(text5);
			try
			{
				File.WriteAllText(text2 + "\\account.txt", uid + "|" + pass + "|" + fa2);
			}
			catch
			{
			}
			CloseAppFacebook();
			DelayTime(1.0);
			ADBHelper.RunCMD(PathLDPlayer + $"\\dnconsole.exe killapp --index {IndexDevice} --packagename com.facebook.katana");
			DelayTime(1.0);
			string text6 = text2 + ".zip";
			int valueInt = new JSON_Settings("configLDPlayer").GetValueInt("typeBackupDataFb");
			if (valueInt == 2)
			{
				string fileName = text2 + "\\data.tar.gz";
				for (int i = 0; i < 3; i++)
				{
					DeleteFile("/data/data.tar.gz");
					ZipFile("/data/data/com.facebook.katana --exclude=dex --exclude=lib-xzs --exclude=app_compactdisk --exclude=app_js-bundles --exclude=app_restricks --exclude=files --exclude=app_overtheair --exclude=cache --exclude=app_models_data --exclude=app_graphservice --exclude=modules --exclude=app_msqrd_effect_asset_disk_cache_fixed_sessionless --exclude=app_msqrd_model_asset_disk_cache_sessionless --exclude=app_strings --exclude=app_errorreporting --exclude=app_feedback_reactions --exclude=app_file_poolreports --exclude=app_downloadservice_cache --exclude=app_analytics --exclude=app_webview", "/data/data.tar.gz");
					DelayTime(1.0);
					PullFile("/data/data.tar.gz", text2);
					int num = 0;
					while (num < 10)
					{
						if (new FileInfo(fileName).Length <= 0L)
						{
							DelayTime(1.0);
							num++;
							continue;
						}
						goto IL_02f8;
					}
				}
			}
			else
			{
				ExecuteCMD("adb shell rm /data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/AppModules::* && adb shell rm -r /data/data/com.facebook.katana/app_light_prefs/com.facebook.katana:*");
				DelayTime(1.0);
				string cmd = "adb pull /data/data/com.facebook.katana/app_light_prefs/com.facebook.katana \"" + text3 + "\"";
				string cmd2 = "adb pull /data/data/com.facebook.katana/shared_prefs \"" + text4 + "\"";
				string cmd3 = "adb pull /data/data/com.facebook.katana/databases \"" + text5 + "\"";
				ADBHelper.RunCMD(DeviceId, cmd);
				ADBHelper.RunCMD(DeviceId, cmd2);
				if (valueInt == 1)
				{
					ADBHelper.RunCMD(DeviceId, cmd3, 3);
				}
			}
			goto IL_02f8;
			IL_02f8:
			DelayTime(1.0);
			MCommon.Common.DeleteFile(text6);
			MCommon.Common.ZipFolder(text2, text6);
			MCommon.Common.DeleteFolder(text2);
		}

		public void BackupConfigDevice(string uid)
		{
			Directory.CreateDirectory("device");
			Directory.CreateDirectory("device\\" + uid);
			File.Copy(PathLDPlayer + "\\vms\\config\\leidian" + IndexDevice + ".config", "device\\" + uid + "\\config", overwrite: true);
		}

		public void RestoreConfigDevice(string uid)
		{
			string sourceFileName = FileHelper.GetPathToCurrentFolder() + "\\device\\" + uid + "\\config";
			File.Copy(sourceFileName, PathLDPlayer + "\\vms\\config\\leidian" + IndexDevice + ".config", overwrite: true);
		}

		public void GotoNewFeedQuick()
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_feed, "com.facebook.katana"), 3);
		}

		public void GotoNotificationQuick()
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_notifications, "com.facebook.katana"));
		}

		public void GotoSearchQuick()
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_search, "com.facebook.katana"));
		}

		public void GotoWatchQuick()
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_watch, "com.facebook.katana"));
		}

		public void GotoFriendsQuick()
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_friends, "com.facebook.katana"));
		}

		public void GotoProfileQuick(string uid = "")
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_profile + ((uid == "") ? "" : ("/" + uid)), "com.facebook.katana"));
		}

		public void GotoPageQuick(string id)
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_page + "/" + id, "com.facebook.katana"));
		}

		public void GotoGroupQuick(string id)
		{
			ExecuteCMD(string.Format(ADBCommands.VIEW, link_group + "/" + id, "com.facebook.katana"));
		}

		public void GotoSyncContactQuick()
		{
			ExecuteCMD(string.Format(ADBCommands.OPEN_LINK, link_syncContact));
		}

		public void GotoBack(int times = 1, double timeDelay_seconds = 0.0)
		{
			for (int i = 0; i < times; i++)
			{
				InputKey(KeyEvent.KEYCODE_BACK);
				DelayTime(timeDelay_seconds);
			}
		}

		public bool OpenLink(string link, int timeout = 10)
		{
			try
			{
				ExecuteCMD(string.Format(ADBCommands.VIEW, link.Replace("&", "\\&"), "com.facebook.katana"), timeout);
				if (link.StartsWith("fb://") || link.StartsWith("https://facebook.com") || link.StartsWith("https://www.facebook.com") || link.StartsWith("https://web.facebook.com"))
				{
					for (int i = 0; i < 30; i++)
					{
						if (!CheckExistImage("DataClick\\image\\openappagain"))
						{
							if (GetActivity().Contains("com.facebook.katana"))
							{
								break;
							}
							string html = GetHtml();
							if (CheckExistText("open with", html))
							{
								TapByText("facebook", html);
								DelayRandom(1.0, 1.5);
								TapByText("always", html);
								DelayRandom(3.0, 5.0);
							}
							continue;
						}
						TapByImageWait("DataClick\\image\\openappagain");
						break;
					}
				}
				return true;
			}
			catch
			{
			}
			return false;
		}

		public bool OpenActivity(string activity)
		{
			try
			{
				ExecuteCMD(string.Format(ADBCommands.OPEN_LINK, activity), 3);
				return true;
			}
			catch
			{
			}
			return false;
		}

		public bool GotoListFriend()
		{
			GotoNewFeedQuick();
			bool flag = false;
			int num = 1;
			int num2 = 1;
			int num3 = 1;
			while (true)
			{
				IL_0076:
				flag = TapByImage("DataClick\\image\\menu", null, 3);
				while (true)
				{
					num++;
					if (flag)
					{
						switch (num)
						{
						case 2:
							break;
						case 3:
							goto IL_0050;
						case 1:
							goto IL_0076;
						default:
							goto IL_0096;
						}
						flag = TapByImage("DataClick\\image\\banbe", null, 5);
						continue;
					}
					GotoFriendsQuick();
					goto IL_0096;
					IL_0096:
					return flag;
					IL_0050:
					flag = TapByText("all friends", "", 3);
				}
			}
		}

		public bool GotoListGroup()
		{
			GotoNewFeedQuick();
			bool flag = false;
			int num = 1;
			int num2 = 1;
			int num3 = 1;
			while (true)
			{
				IL_0076:
				flag = TapByImage("DataClick\\image\\menu", null, 3);
				while (true)
				{
					num++;
					if (flag)
					{
						switch (num)
						{
						case 2:
							break;
						case 3:
							goto IL_0050;
						case 1:
							goto IL_0076;
						default:
							goto IL_008d;
						}
						flag = TapByImage("DataClick\\image\\nhom", null, 5);
						continue;
					}
					goto IL_008d;
					IL_0050:
					flag = TapByText("your groups", "", 3);
					continue;
					IL_008d:
					return flag;
				}
			}
		}

		public bool GotoFriendSuggest()
		{
			GotoNewFeedQuick();
			bool flag = false;
			int num = 1;
			int num2 = 1;
			int num3 = 1;
			while (true)
			{
				IL_00e4:
				flag = TapByImage("DataClick\\image\\menu", null, 5);
				while (true)
				{
					num++;
					if (flag)
					{
						switch (num)
						{
						case 2:
							break;
						case 3:
							goto IL_0056;
						case 1:
							goto IL_00e4;
						default:
							goto IL_00fb;
						}
						flag = TapByImage("DataClick\\image\\banbe", null, 5);
						continue;
					}
					goto IL_00fb;
					IL_0056:
					flag = CheckExistTexts("", 5.0, "\"suggestions\"", "as a friend\"") switch
					{
						2 => true, 
						1 => TapByText("\"suggestions\""), 
						_ => false, 
					};
					continue;
					IL_00fb:
					return flag;
				}
			}
		}

		public bool GotoAcceptFriend()
		{
			GotoNewFeedQuick();
			bool flag = false;
			int num = 1;
			int num2 = 1;
			int num3 = 1;
			while (true)
			{
				IL_00e4:
				flag = TapByImage("DataClick\\image\\menu", null, 5);
				while (true)
				{
					num++;
					if (flag)
					{
						switch (num)
						{
						case 2:
							break;
						case 3:
							goto IL_0056;
						case 1:
							goto IL_00e4;
						default:
							goto IL_00fb;
						}
						flag = TapByImage("DataClick\\image\\banbe", null, 5);
						continue;
					}
					goto IL_00fb;
					IL_0056:
					flag = CheckExistTexts("", 5.0, "\"confirm", "\"friend request\"") switch
					{
						2 => TapByText("\"friend request\""), 
						1 => true, 
						_ => false, 
					};
					continue;
					IL_00fb:
					return flag;
				}
			}
		}

		public bool GotoWall()
		{
			GotoNewFeedQuick();
			bool flag = false;
			int num = 1;
			while (true)
			{
				switch (num)
				{
				case 1:
					flag = TapByImage("DataClick\\image\\menu", null, 3);
					goto IL_002c;
				case 2:
					flag = TapByImage("DataClick\\image\\xemtrangcanhancuaban", null, 3);
					goto IL_002c;
				}
				break;
				IL_002c:
				num++;
				if (!flag)
				{
					GotoProfileQuick();
					flag = true;
					break;
				}
			}
			return flag;
		}

		public bool GotoWatch()
		{
			GotoNewFeedQuick();
			bool flag = false;
			int num = 1;
			while (true)
			{
				switch (num)
				{
				case 1:
					flag = TapByImage("DataClick\\image\\menu", null, 3);
					goto IL_002c;
				case 2:
					flag = TapByText("video trên watch", "", 3);
					goto IL_002c;
				}
				break;
				IL_002c:
				num++;
				if (!flag)
				{
					GotoWatchQuick();
					flag = true;
					break;
				}
			}
			return flag;
		}

		public bool GotoSearch(string tuKhoa = "", string typeSearch = "mọi người")
		{
			GotoNewFeedQuick();
			bool flag;
			if (!(flag = TapByText("search")))
			{
				GotoSearchQuick();
				flag = true;
			}
			if (flag && tuKhoa != "")
			{
				DelayRandom(1.0, 1.5);
				InputTextWithUnicode(tuKhoa, 0.1);
				DelayRandom(1.0, 1.5);
				InputKey(KeyEvent.KEYCODE_ENTER);
				DelayRandom(1.5, 2.5);
				TapByText(typeSearch, "", 10);
			}
			return flag;
		}

		public string ClearDataAppFacebook()
		{
			if (CheckExistImage("DataClick\\image\\phoneoremail"))
			{
				return "";
			}
			return ClearDataApp("com.facebook.katana");
		}

		public void GotoPageHead()
		{
			ScrollShort(300);
			GotoBack();
		}

		public string GetHtml()
		{
			string result = "";
			try
			{
				if (GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
				{
					return "";
				}
				result = ADBHelper.GetXML(DeviceId);
			}
			catch
			{
			}
			return result;
		}

		public string ZipFile(string sourceFile, string toFile, int timeOut = 30)
		{
			return ADBHelper.ZipFile(DeviceId, sourceFile, toFile, timeOut);
		}

		public string UnZipFile(string filePath, int timeOut = 30)
		{
			return ADBHelper.UnZipFile(DeviceId, filePath, timeOut);
		}

		public string DumpScreen(string filePath)
		{
			return ADBHelper.DumpScreen(DeviceId, filePath);
		}

		public string ReadFile(string filePath)
		{
			return ADBHelper.ReadFile(DeviceId, filePath);
		}

		public string DeleteFile(string filePath)
		{
			return ADBHelper.DeleteFile(DeviceId, filePath);
		}

		public string DeleteFolder(string folderPath)
		{
			return ADBHelper.DeleteFolder(DeviceId, folderPath);
		}

		public string ClearDataApp(string package)
		{
			return ADBHelper.ClearDataApp(DeviceId, package);
		}

		public string PullFile(string fromFilePath, string toFilePath)
		{
			return ADBHelper.PullFile(DeviceId, fromFilePath, toFilePath);
		}

		public string PushFile(string fromFilePath, string toFilePath)
		{
			return ADBHelper.PushFile(DeviceId, fromFilePath, toFilePath);
		}

		public string ScreenCap(string filePath)
		{
			return ADBHelper.ScreenCap(DeviceId, filePath);
		}

		public string View(string link)
		{
			return ADBHelper.View(DeviceId, link);
		}

		public void ImportContact(List<string> lstPhoneNumber)
		{
			List<string> contents = ConvertLstPhoneNumberToLstContact(lstPhoneNumber);
			string text = CreateRandomString(10) + ".vcf";
			File.WriteAllLines(text, contents);
			try
			{
				ClearDataApp("com.android.contacts");
				ClearDataApp("com.android.providers.contacts");
				using (File.OpenRead(text))
				{
					PushFile(text, "/sdcard/contact.vcf");
				}
				ExecuteCMD("shell pm grant com.android.contacts android.permission.READ_EXTERNAL_STORAGE");
				ADBHelper.ImportContact(DeviceId, "/sdcard/contact.vcf");
				string html = "";
				if (CheckExistText("import contacts from vcard", ref html, 10.0))
				{
					TapByText("\"ok\"", html);
				}
				File.Delete(text);
			}
			catch
			{
			}
		}

		public void ImportContact(string filePath = "contact.vcf")
		{
			try
			{
				ClearDataApp("com.android.contacts");
				ClearDataApp("com.android.providers.contacts");
				using (File.OpenRead(filePath))
				{
					PushFile(filePath, "/sdcard/contact.vcf");
				}
				ADBHelper.ImportContact(DeviceId, "/sdcard/contact.vcf");
				File.Delete(filePath);
			}
			catch
			{
			}
		}

		private List<string> ConvertLstPhoneNumberToLstContact(List<string> lstPhone)
		{
			Random random = new Random();
			List<string> list = new List<string>();
			try
			{
				lstPhone = MCommon.Common.RemoveEmptyItems(lstPhone);
				string text = "BEGIN:VCARD" + Environment.NewLine + "VERSION:3.0" + Environment.NewLine + "N:{{fname}};;;" + Environment.NewLine + "FN:{{lname}}" + Environment.NewLine + "TEL;TYPE=CELL;TYPE=PREF:{{phone}}" + Environment.NewLine + "END:VCARD";
				for (int i = 0; i < lstPhone.Count; i++)
				{
					string newValue = lstPhone[i];
					string newValue2 = SetupFolder.first_name[random.Next(0, SetupFolder.first_name.Length)];
					string newValue3 = SetupFolder.last_name[random.Next(0, SetupFolder.last_name.Length)];
					string text2 = text;
					text2 = text2.Replace("{{fname}}", newValue2);
					text2 = text2.Replace("{{lname}}", newValue3);
					text2 = text2.Replace("{{phone}}", newValue);
					list.Add(text2);
				}
			}
			catch
			{
			}
			return list;
		}

		private string ConnectHttpProxy(string proxy)
		{
			return ADBHelper.ConnectHttpProxy(DeviceId, proxy);
		}

		public bool ConnectProxy(string proxy)
		{
			if (!CheckIsLive())
			{
				return false;
			}
			bool result = false;
			if (!string.IsNullOrEmpty(proxy.Trim()))
			{
				switch (proxy.Split(':').Count())
				{
				case 2:
					ConnectHttpProxy(proxy);
					result = true;
					break;
				}
			}
			return result;
		}

		public void RemoveProxy()
		{
			if (CheckIsLive())
			{
				ADBHelper.RemoveHttpProxy(DeviceId);
			}
		}

		public bool CheckIsLive()
		{
			if (process != null)
			{
				return !process.HasExited;
			}
			return true;
		}

		public void Swipe(int x1, int y1, int x2, int y2, int duration = 100)
		{
			ADBHelper.Swipe(DeviceId, x1, y1, x2, y2, duration);
		}

		public bool SwipeByBounds(string bounds1, string bounds2, int duration = 100)
		{
			try
			{
				Point locationFromBounds = GetLocationFromBounds(bounds1);
				int x = locationFromBounds.X;
				int y = locationFromBounds.Y;
				Point locationFromBounds2 = GetLocationFromBounds(bounds2);
				int x2 = locationFromBounds2.X;
				int y2 = locationFromBounds2.Y;
				Swipe(x, y, x2, y2, duration);
				return true;
			}
			catch
			{
			}
			return false;
		}

		public bool Scroll(int timeScroll = 1000, int typeScroll = 1)
		{
			bool result = false;
			try
			{
				string text = "[100,391][219,423]";
				string text2 = "[181,195][286,226]";
				if (typeScroll == 1)
				{
					result = SwipeByBounds(text, text2, timeScroll);
					return result;
				}
				result = SwipeByBounds(text2, text, timeScroll);
				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}

		public bool ScrollShort(int timeScroll = 1000, int typeScroll = 1)
		{
			bool result = false;
			try
			{
				string text = "[100,391][219,423]";
				string text2 = "[181,295][286,326]";
				if (typeScroll == 1)
				{
					result = SwipeByBounds(text, text2, timeScroll);
					return result;
				}
				result = SwipeByBounds(text2, text, timeScroll);
				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}

		public bool ScrollAndCheckScreenNotChange(int timeScroll = 1000, int typeScroll = 1, string bounds1 = "[100,391][219,423]", string bounds2 = "[181,195][286,226]", string boundsCheck = "[72,165][216,294]")
		{
			try
			{
				int num = 3;
				Bitmap bitmap = ScreenShoot();
				if (bitmap != null)
				{
					Bitmap bitmap2 = Crop(bitmap, boundsCheck);
					for (int i = 0; i < num; i++)
					{
						if (typeScroll == 1)
						{
							SwipeByBounds(bounds1, bounds2, timeScroll);
						}
						else
						{
							SwipeByBounds(bounds2, bounds1, timeScroll);
						}
						DelayTime(1.0);
						string boundsByImage = GetBoundsByImage(bitmap2);
						if (boundsCheck != boundsByImage)
						{
							return false;
						}
					}
				}
				else
				{
					for (int j = 0; j < num; j++)
					{
						string html = GetHtml();
						if (typeScroll == 1)
						{
							SwipeByBounds(bounds1, bounds2, timeScroll);
						}
						else
						{
							SwipeByBounds(bounds2, bounds1, timeScroll);
						}
						string html2 = GetHtml();
						if (html != html2)
						{
							return false;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return true;
		}

		public Bitmap Crop(Bitmap bm, string bounds)
		{
			string[] array = bounds.Split('[', ',', ']');
			return bm.Clone(new Rectangle(Convert.ToInt32(array[1]), Convert.ToInt32(array[2]), Convert.ToInt32(array[4]) - Convert.ToInt32(array[1]), Convert.ToInt32(array[5]) - Convert.ToInt32(array[2])), bm.PixelFormat);
		}

		private Point? FindOutPoint(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			try
			{
				Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
				Image<Bgr, byte> template = new Image<Bgr, byte>(subBitmap);
				Point? result = null;
				using (Image<Gray, float> image2 = image.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
				{
					image2.MinMax(out var _, out var maxValues, out var _, out var maxLocations);
					if (maxValues[0] > percent)
					{
						result = maxLocations[0];
					}
				}
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private List<Point> FindOutPoints(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
			Image<Bgr, byte> image2 = new Image<Bgr, byte>(subBitmap);
			List<Point> list = new List<Point>();
			while (true)
			{
				using Image<Gray, float> image3 = image.MatchTemplate(image2, TemplateMatchingType.CcoeffNormed);
				image3.MinMax(out var _, out var maxValues, out var _, out var maxLocations);
				if (!(maxValues[0] > percent))
				{
					break;
				}
				Rectangle rect = new Rectangle(maxLocations[0], image2.Size);
				image.Draw(rect, new Bgr(Color.Blue), -1);
				list.Add(maxLocations[0]);
				continue;
			}
			return list;
		}

		public Point FindImage(Bitmap btn, Bitmap bitmap_screen = null, double percent = 0.9)
		{
			Point result;
			try
			{
				if (bitmap_screen == null)
				{
					bitmap_screen = ScreenShoot();
				}
				Point? point = FindOutPoint(bitmap_screen, btn, percent);
				if (point.HasValue)
				{
					return new Point(rd.Next(point.Value.X, point.Value.X + btn.Width), rd.Next(point.Value.Y, point.Value.Y + btn.Height));
				}
				result = default(Point);
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public Point? FindImage(string ImagePath, Bitmap bitmap_screen = null)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(ImagePath);
				FileInfo[] files = directoryInfo.GetFiles();
				if (bitmap_screen == null)
				{
					bitmap_screen = ScreenShoot();
				}
				Point? point = null;
				FileInfo[] array = files;
				foreach (FileInfo fileInfo in array)
				{
					Bitmap bitmap = (Bitmap)Image.FromFile(fileInfo.FullName);
					point = FindOutPoint(bitmap_screen, bitmap);
					if (point.HasValue)
					{
						Point value = point.Value;
						if (value.X != 0 && value.Y != 0)
						{
							return new Point(rd.Next(value.X, value.X + bitmap.Width), rd.Next(value.Y, value.Y + bitmap.Height));
						}
					}
				}
			}
			catch
			{
			}
			return null;
		}

		public string GetBoundsByImage(string ImagePath, Bitmap bitmap_screen = null, int timeWait_Second = 0)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(ImagePath);
				FileInfo[] files = directoryInfo.GetFiles();
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (bitmap_screen == null)
					{
						bitmap_screen = ScreenShoot();
					}
					Point? point = null;
					FileInfo[] array = files;
					foreach (FileInfo fileInfo in array)
					{
						Bitmap bitmap = (Bitmap)Image.FromFile(fileInfo.FullName);
						point = FindOutPoint(bitmap_screen, bitmap);
						if (point.HasValue)
						{
							Point value = point.Value;
							if (value.X != 0 && value.Y != 0)
							{
								return $"[{value.X},{value.Y}][{value.X + bitmap.Width},{value.Y + bitmap.Height}]";
							}
						}
					}
					if (Environment.TickCount - tickCount < timeWait_Second * 1000)
					{
						DelayTime(1.0);
						bitmap_screen = ScreenShoot();
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			return "";
		}

		public string GetBoundsByImage(Bitmap bitmap, Bitmap bitmap_screen = null, int timeWait_Second = 0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (bitmap_screen == null)
					{
						bitmap_screen = ScreenShoot();
					}
					Point? point = null;
					point = FindOutPoint(bitmap_screen, bitmap);
					if (point.HasValue)
					{
						Point value = point.Value;
						if (value.X != 0 && value.Y != 0)
						{
							return $"[{value.X},{value.Y}][{value.X + bitmap.Width},{value.Y + bitmap.Height}]";
						}
					}
					if (Environment.TickCount - tickCount < timeWait_Second * 1000)
					{
						DelayTime(1.0);
						bitmap_screen = ScreenShoot();
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			return "";
		}

		public List<string> GetListBoundsByImage(string ImagePath, Bitmap bitmap_screen = null, int timeWait_Second = 0)
		{
			List<string> list = new List<string>();
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(ImagePath);
				FileInfo[] files = directoryInfo.GetFiles();
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (bitmap_screen == null)
					{
						bitmap_screen = ScreenShoot();
					}
					List<Point> list2 = new List<Point>();
					FileInfo[] array = files;
					foreach (FileInfo fileInfo in array)
					{
						Bitmap bitmap = (Bitmap)Image.FromFile(fileInfo.FullName);
						list2 = FindOutPoints(bitmap_screen, bitmap);
						if (list2.Count <= 0)
						{
							continue;
						}
						for (int j = 0; j < list2.Count; j++)
						{
							if (list2[j].X != 0 && list2[j].Y != 0)
							{
								list.Add($"[{list2[j].X},{list2[j].Y}][{list2[j].X + bitmap.Width},{list2[j].Y + bitmap.Height}]");
							}
						}
						return list;
					}
					if (Environment.TickCount - tickCount < timeWait_Second * 1000)
					{
						DelayTime(1.0);
						bitmap_screen = ScreenShoot();
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		public bool TapByImage(string imagePath, Bitmap bitmap_screen = null, int timeWait = 0)
		{
			try
			{
				LoadStatusLD("Find Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
				string boundsByImage = GetBoundsByImage(imagePath, bitmap_screen, timeWait);
				if (boundsByImage != "")
				{
					LoadStatusLD("Click Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
					return TapByBounds(boundsByImage);
				}
			}
			catch
			{
			}
			return false;
		}

		public bool TapByImageWait(string imagePath, int timeWaitSearch = 0, int times = 10)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (CheckIsLive())
				{
					LoadStatusLD("Find Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
					string boundsByImage = GetBoundsByImage(imagePath);
					if (boundsByImage != "")
					{
						LoadStatusLD("Click Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
						int num = 0;
						while (num < times)
						{
							if (CheckIsLive())
							{
								TapByBounds(boundsByImage);
								DelayTime(1.0);
								string boundsByImage2 = GetBoundsByImage(imagePath);
								if (!(boundsByImage2 == "") && !(boundsByImage2 != boundsByImage))
								{
									num++;
									continue;
								}
								return true;
							}
							goto end_IL_0001;
						}
					}
					if (Environment.TickCount - tickCount < timeWaitSearch * 1000)
					{
						DelayTime(1.0);
						continue;
					}
					break;
				}
				end_IL_0001:;
			}
			catch
			{
			}
			return false;
		}

		public bool WaitForImageAppear(string imagePath, double timeWait_Second = 0.0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					string boundsByImage = GetBoundsByImage(imagePath);
					if (!(boundsByImage != ""))
					{
						if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
						{
							DelayTime(1.0);
							continue;
						}
						break;
					}
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public bool WaitForImageDisappear(string imagePath, double timeWait_Second = 0.0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					string boundsByImage = GetBoundsByImage(imagePath);
					if (!(boundsByImage == ""))
					{
						if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
						{
							DelayTime(1.0);
							continue;
						}
						break;
					}
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public bool CheckExistImage(string imagePath, Bitmap bitmap_screen = null, int timeWait = 0)
		{
			try
			{
				string boundsByImage = GetBoundsByImage(imagePath, bitmap_screen, timeWait);
				return boundsByImage != "";
			}
			catch (Exception)
			{
			}
			return false;
		}

		public void InputKey(KeyEvent key)
		{
			ExecuteCMD("shell input keyevent " + key);
		}

		public void InputText(string text)
		{
			LoadStatusLD("Send: " + text);
			ADBHelper.InputText(DeviceId, text);
		}

		public void InputTextWithUnicode(string text, double timeDelay = 0.0)
		{
			ADBHelper.SwitchAdbkeyboard(DeviceId);
			LoadStatusLD("Send: " + text);
			if (timeDelay == 0.0)
			{
				ExecuteCMD("shell am broadcast -a ADB_INPUT_B64 --es msg '" + Convert.ToBase64String(Encoding.UTF8.GetBytes(text.ToString())) + "'");
			}
			else
			{
				timeDelay = ((timeDelay > 0.35) ? (timeDelay - 0.35) : 0.0);
				for (int i = 0; i < text.Length; i++)
				{
					ExecuteCMD("shell am broadcast -a ADB_INPUT_B64 --es msg '" + Convert.ToBase64String(Encoding.UTF8.GetBytes(text[i].ToString())) + "'");
					DelayTime(timeDelay);
				}
			}
			ADBHelper.SwitchAndroidKeyboard(DeviceId, lstPackages);
		}

		public bool CheckExistText(string text, string html = "", double timeWait_Second = 0.0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (html == "")
					{
						html = GetHtml();
					}
					if (!Regex.IsMatch(html, text + "(.*?)/>"))
					{
						if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
						{
							DelayTime(1.0);
							html = GetHtml();
							continue;
						}
						break;
					}
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public bool CheckExistText(string text, ref string html, double timeWait_Second = 0.0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (string.IsNullOrEmpty(html))
					{
						html = GetHtml();
					}
					if (!Regex.IsMatch(html, text + "(.*?)/>"))
					{
						if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
						{
							DelayTime(1.0);
							html = GetHtml();
							continue;
						}
						break;
					}
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		public string CheckExistTextsV2(string html, double timeWait_Second, params string[] text)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (html == "")
					{
						html = GetHtml();
					}
					for (int i = 0; i < text.Length; i++)
					{
						if (Regex.IsMatch(html, text[i] + "(.*?)/>"))
						{
							return text[i];
						}
					}
					if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
					{
						DelayTime(1.0);
						html = GetHtml();
						continue;
					}
					break;
				}
			}
			catch
			{
			}
			return "";
		}

		public int CheckExistTexts(ref string html, double timeWait_Second = 0.0, params string[] text)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (html == "")
					{
						html = GetHtml();
					}
					for (int i = 0; i < text.Length; i++)
					{
						if (Regex.IsMatch(html, text[i] + "(.*?)/>"))
						{
							return i + 1;
						}
					}
					if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
					{
						DelayTime(1.0);
						html = GetHtml();
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		public int CheckExistTexts(string html = "", double timeWait_Second = 0.0, params string[] text)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (html == "")
					{
						html = GetHtml();
					}
					for (int i = 0; i < text.Length; i++)
					{
						if (Regex.IsMatch(html, text[i] + "(.*?)/>"))
						{
							return i + 1;
						}
					}
					if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
					{
						DelayTime(1.0);
						html = GetHtml();
						continue;
					}
					break;
				}
			}
			catch
			{
			}
			return result;
		}

		public int CheckExistTexts(string html, double timeWait_Second, Dictionary<int, List<string>> dic)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (html == "")
					{
						html = GetHtml();
					}
					foreach (KeyValuePair<int, List<string>> item in dic)
					{
						foreach (string item2 in item.Value)
						{
							if (Regex.IsMatch(html, item2 + "(.*?)/>"))
							{
								return item.Key;
							}
						}
					}
					if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
					{
						DelayTime(1.0);
						html = GetHtml();
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		public int CheckExistTexts(string html, double timeWait_Second, Dictionary<int, string> dic)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (html == "")
					{
						html = GetHtml();
					}
					foreach (KeyValuePair<int, string> item in dic)
					{
						if (Regex.IsMatch(html, item.Value + "(.*?)/>"))
						{
							return item.Key;
						}
					}
					if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
					{
						DelayTime(1.0);
						html = GetHtml();
						continue;
					}
					break;
				}
			}
			catch
			{
			}
			return result;
		}

		public bool WaitForTextAppear(double timeWait_Second = 0.0, params string[] text)
		{
			try
			{
				string text2 = "";
				int tickCount = Environment.TickCount;
				while (true)
				{
					text2 = GetHtml();
					for (int i = 0; i < text.Length; i++)
					{
						if (Regex.IsMatch(text2, text[i] + "(.*?)/>"))
						{
							return true;
						}
					}
					if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
					{
						DelayTime(1.0);
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public bool WaitForTextDisappear(double timeWait_Second = 0.0, params string[] text)
		{
			try
			{
				string text2 = "";
				int tickCount = Environment.TickCount;
				while (true)
				{
					text2 = GetHtml();
					for (int i = 0; i < text.Length; i++)
					{
						if (!Regex.IsMatch(text2, text[i] + "(.*?)/>"))
						{
							return true;
						}
					}
					if (!((double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0))
					{
						DelayTime(1.0);
						continue;
					}
					break;
				}
			}
			catch
			{
			}
			return false;
		}

		public string GetBoundsByText(string text, string html = "", int timeWait_Second = 0)
		{
			try
			{
				LoadStatusLD("Find Text: " + text);
				int tickCount = Environment.TickCount;
				while (CheckIsLive())
				{
					if (html == "")
					{
						html = GetHtml();
					}
					string value = Regex.Match(html, text.Replace("[", "\\[").Replace("]", "\\]") + "(.*?)/>").Groups[1].Value;
					if (!(value != ""))
					{
						if (Environment.TickCount - tickCount < timeWait_Second * 1000)
						{
							DelayTime(1.0);
							html = GetHtml();
							continue;
						}
						break;
					}
					return Regex.Match(value, "bounds=\"(.*?)\"").Groups[1].Value;
				}
			}
			catch (Exception)
			{
			}
			return "";
		}

		public List<string> GetListBoundsByText(string text, string html = "", int timeWait_Second = 0)
		{
			List<string> list = new List<string>();
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (html == "")
					{
						html = GetHtml();
					}
					MatchCollection matchCollection = Regex.Matches(html, text.Replace("[", "\\[").Replace("]", "\\]") + "(.*?)/>");
					for (int i = 0; i < matchCollection.Count; i++)
					{
						list.Add(Regex.Match(matchCollection[i].Value, "bounds=\"(.*?)\"").Groups[1].Value);
					}
					if (list.Count <= 0 && Environment.TickCount - tickCount < timeWait_Second * 1000)
					{
						DelayTime(1.0);
						html = GetHtml();
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		public bool CheckBoundsContainBounds(string bounds, string subBounds)
		{
			string[] array = subBounds.Split('[', ',', ']');
			return CheckBoundsContainLocation(bounds, Convert.ToInt32(array[1]), Convert.ToInt32(array[2])) && CheckBoundsContainLocation(bounds, Convert.ToInt32(array[4]), Convert.ToInt32(array[5]));
		}

		public bool CheckBoundsContainLocation(string bounds, Point point)
		{
			int x = point.X;
			int y = point.Y;
			return CheckBoundsContainLocation(bounds, x, y);
		}

		public bool CheckBoundsContainLocation(string bounds, int x, int y)
		{
			string[] array = bounds.Split('[', ',', ']');
			return x >= Convert.ToInt32(array[1]) && x <= Convert.ToInt32(array[4]) && y >= Convert.ToInt32(array[2]) && y <= Convert.ToInt32(array[5]);
		}

		public bool Tap(int x, int y, int delay = 1)
		{
			if (CheckBoundsContainLocation("[0,0][320,480]", x, y))
			{
				ADBHelper.Tap(DeviceId, x, y);
				DelayTime(delay);
				return true;
			}
			return false;
		}

		public bool Tap(Point point, int delay = 1)
		{
			if (CheckBoundsContainLocation("[0,0][320,480]", point.X, point.Y))
			{
				ADBHelper.Tap(DeviceId, point.X, point.Y);
				DelayTime(delay);
				return true;
			}
			return false;
		}

		public Point GetLocationFromBounds(string bounds)
		{
			try
			{
				string[] array = bounds.Split('[', ',', ']');
				int x = rd.Next(Convert.ToInt32(array[1]), Convert.ToInt32(array[4]));
				int y = rd.Next(Convert.ToInt32(array[2]), Convert.ToInt32(array[5]));
				return new Point(x, y);
			}
			catch
			{
			}
			return default(Point);
		}

		public bool TapByBounds(string bounds, string onlyInBounds = "")
		{
			try
			{
				Point locationFromBounds = GetLocationFromBounds(bounds);
				int x = locationFromBounds.X;
				int y = locationFromBounds.Y;
				if (onlyInBounds == "" || CheckBoundsContainLocation(onlyInBounds, x, y))
				{
					return Tap(x, y);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public bool TapByText(string text, string html = "", int timeWait_Second = 0)
		{
			string boundsByText = GetBoundsByText(text, html, timeWait_Second);
			if (!string.IsNullOrEmpty(boundsByText))
			{
				LoadStatusLD("Click Text: " + text);
				return TapByBounds(boundsByText);
			}
			return false;
		}

		public bool TapByXpath(string xPath, string html = "", int timeWait_Second = 0)
		{
			string text = "";
			int tickCount = Environment.TickCount;
			while (CheckIsLive())
			{
				if (html == "")
				{
					html = GetHtml();
				}
				text = GetValueByXpath(html, xPath, "bounds");
				if (!(text != "") && Environment.TickCount - tickCount < timeWait_Second * 1000)
				{
					DelayTime(1.0);
					html = GetHtml();
					continue;
				}
				if (string.IsNullOrEmpty(text))
				{
					break;
				}
				return TapByBounds(text);
			}
			return false;
		}

		public bool TapLong(int x, int y, int duration = -1)
		{
			if (CheckBoundsContainLocation("[0,0][320,480]", x, y))
			{
				if (duration == -1)
				{
					duration = GetRandomInt(1000, 3000);
				}
				ADBHelper.TapLong(DeviceId, x, y, duration);
				return true;
			}
			return false;
		}

		public bool TapLongByBounds(string bounds, string onlyInBounds = "")
		{
			try
			{
				Point locationFromBounds = GetLocationFromBounds(bounds);
				int x = locationFromBounds.X;
				int y = locationFromBounds.Y;
				if (onlyInBounds == "" || CheckBoundsContainLocation(onlyInBounds, x, y))
				{
					return TapLong(x, y, 3000);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public bool TapLongByText(string text, string html = "", int timeWaitForSearch_Second = 0)
		{
			string boundsByText = GetBoundsByText(text, html, timeWaitForSearch_Second);
			if (!string.IsNullOrEmpty(boundsByText))
			{
				return TapLongByBounds(boundsByText);
			}
			return false;
		}

		public string GetValueByXpath(string xml, string xpath, string attribute)
		{
			string result = "";
			try
			{
				if (xml == "")
				{
					xml = GetHtml();
				}
				xml = Regex.Match(xml, "<\\?xml(.*?)</hierarchy>").Value;
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(xml);
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes(xpath);
				result = xmlNodeList[xmlNodeList.Count - 1].Attributes[attribute].Value;
			}
			catch
			{
			}
			return result;
		}

		public bool CheckExistXpath(string xpath, string xml = "")
		{
			try
			{
				if (xml == "")
				{
					xml = GetHtml();
				}
				xml = Regex.Match(xml, "<\\?xml(.*?)</hierarchy>").Value;
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(xml);
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes(xpath);
				if (xmlNodeList.Count > 0)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		public bool ClearText(string defaultValue = "", string xpath = "//*[@class='android.widget.edittext']", string attribute = "text")
		{
			try
			{
				string text = "";
				string text2 = "";
				for (int i = 0; i < 10; i++)
				{
					text = GetHtml();
					text2 = GetValueByXpath(text, xpath, attribute);
					if (!(text2 == defaultValue) && text2.Length != 0)
					{
						string[] array = GetValueByXpath(text, xpath, "bounds").Split('[', ',', ']');
						Point point = new Point(int.Parse(array[4]) - 1, int.Parse(array[5]) - 1);
						Tap(point);
						DelayTime(1.0);
						int num = text2.Length / 30 + ((text2.Length % 30 > 0) ? 1 : 0);
						string text3 = "";
						for (int j = 0; j < 30; j++)
						{
							text3 += "input keyevent KEYCODE_DEL && ";
						}
						text3 = "shell \"" + text3.TrimEnd(' ', '&') + "\"";
						for (int k = 0; k < num; k++)
						{
							ExecuteCMD(text3);
						}
						continue;
					}
					if (defaultValue != "")
					{
						TapByText(defaultValue, text);
					}
					break;
				}
			}
			catch
			{
			}
			return false;
		}

		public string GetActivity()
		{
			try
			{
				if (!CheckIsLive())
				{
					return "";
				}
				return ADBHelper.DumpActivity(DeviceId).Split('{', '}')[1].Split(' ')[2];
			}
			catch
			{
			}
			return "";
		}

		public void OpenApp(string package)
		{
			if (CheckIsLive())
			{
				ADBHelper.OpenApp(DeviceId, package);
			}
		}

		public void CloseApp(string package)
		{
			if (CheckIsLive())
			{
				ADBHelper.CloseApp(DeviceId, package);
			}
		}

		public bool InstallApp(string fileApkFromComputer)
		{
			if (!CheckIsLive())
			{
				return false;
			}
			ADBHelper.InstallApp(DeviceId, fileApkFromComputer);
			return true;
		}

		public bool UninstallApp(string package)
		{
			if (!CheckIsLive())
			{
				return false;
			}
			return ADBHelper.UninstallApp(DeviceId, package).Trim().ToLower() == "success";
		}

		public List<string> GetListPackages()
		{
			return ADBHelper.GetListPackages(DeviceId);
		}

		public List<string> GetListText(string html = "", int type = 0)
		{
			if (html == "")
			{
				html = GetHtml();
			}
			List<string> listRegexGroup = GetListRegexGroup1(html, "text=\"(.*?)\"");
			List<string> listRegexGroup2 = GetListRegexGroup1(html, "content-desc=\"(.*?)\"");
			List<string> listRegexGroup3 = GetListRegexGroup1(html, "text='(.*?)'");
			List<string> listRegexGroup4 = GetListRegexGroup1(html, "content-desc='(.*?)'");
			List<string> list = new List<string>();
			switch (type)
			{
			case 0:
				list.AddRange(listRegexGroup);
				list.AddRange(listRegexGroup2);
				list.AddRange(listRegexGroup3);
				list.AddRange(listRegexGroup4);
				break;
			case 1:
				list.AddRange(listRegexGroup);
				list.AddRange(listRegexGroup3);
				break;
			case 2:
				list.AddRange(listRegexGroup2);
				list.AddRange(listRegexGroup4);
				break;
			}
			return list;
		}

		private List<string> GetListRegexGroup1(string input, string pattern)
		{
			List<string> list = new List<string>();
			try
			{
				MatchCollection matchCollection = Regex.Matches(input, pattern);
				for (int i = 0; i < matchCollection.Count; i++)
				{
					if (!string.IsNullOrEmpty(matchCollection[i].Groups[1].Value))
					{
						list.Add(matchCollection[i].Groups[1].Value);
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		public void InputKeyBackspace()
		{
			InputKey(KeyEvent.KEYCODE_DEL);
		}

		public void InputKeyBackspace(int times = 1)
		{
			string text = "";
			for (int i = 0; i < times; i++)
			{
				text += "input keyevent KEYCODE_DEL && ";
			}
			text = "shell \"" + text.TrimEnd(' ', '&') + "\"";
			ExecuteCMD(text);
		}

		public string ExecuteCMD(string cmd, int timeout = 10)
		{
			if (!CheckIsLive())
			{
				return "";
			}
			if (GetActivity() != "com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity" && cmd.Contains(ADBCommands.VIEW.Substring(0, ADBCommands.VIEW.IndexOf("\""))))
			{
				ClosePopup();
			}
			return ADBHelper.RunCMD(DeviceId, cmd, timeout);
		}

		public void DelayTime(double second)
		{
			if (CheckIsLive())
			{
				Application.DoEvents();
				Thread.Sleep(Convert.ToInt32(second * 1000.0));
			}
		}

		public void DelayRandom(double timeFrom, double timeTo)
		{
			if (CheckIsLive())
			{
				Thread.Sleep(rd.Next(Convert.ToInt32(timeFrom * 1000.0), Convert.ToInt32(timeTo * 1000.0 + 1.0)));
				Application.DoEvents();
			}
		}

		public int GetRandomInt(int from, int to)
		{
			try
			{
				return rd.Next(from, to + 1);
			}
			catch
			{
				return (from + to) / 2;
			}
		}

		public string CreateRandomString(int lengText)
		{
			string text = "";
			string text2 = "abcdefghijklmnopqrstuvwxyz";
			for (int i = 0; i < lengText; i++)
			{
				text += text2[rd.Next(0, text2.Length)];
			}
			return text;
		}

		public string CreateRandomString(int lengText = 32, string format = "0_a_A", Random random = null)
		{
			string text = "";
			string[] source = format.Split('_');
			if (source.Contains("A"))
			{
				text += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			}
			if (source.Contains("a"))
			{
				text += "abcdefghijklmnopqrstuvwxyz";
			}
			if (source.Contains("0"))
			{
				text += "0123456789";
			}
			char[] array = new char[lengText];
			if (random == null)
			{
				random = rd;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			return new string(array);
		}

		public bool SwipeAndCheckScreenChange(int x1, int y1, int x2, int y2, int duration, int timeDelaySwipe = 1000, int loop = 1)
		{
			bool result = false;
			for (int i = 0; i < loop; i++)
			{
				string html = GetHtml();
				ADBHelper.Swipe(DeviceId, x1, y1, x2, y2, MCommon.Common.GetRandInt(500, 1000));
				Thread.Sleep(timeDelaySwipe);
				string html2 = GetHtml();
				if (html != html2)
				{
					result = true;
				}
			}
			return result;
		}

		public void ExportError(Exception ex, string error = "")
		{
			try
			{
				if (!CheckIsLive())
				{
					return;
				}
				string text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
				string text2 = IndexDevice + "_" + text.Replace("/", "_").Replace(" ", "_").Replace(":", "_");
				Directory.CreateDirectory("log");
				if (!string.IsNullOrEmpty(DeviceId))
				{
					File.WriteAllText("log\\" + text2 + ".xml", GetHtml());
					ScreenShoot("log", text2 + ".png");
				}
				using StreamWriter streamWriter = new StreamWriter("log\\log.txt", append: true);
				streamWriter.WriteLine("-----------------------------------------------------------------------------");
				streamWriter.WriteLine("Date: " + text);
				streamWriter.WriteLine("LDPlayer: " + text2);
				if (error != "")
				{
					streamWriter.WriteLine("Error: " + error);
				}
				streamWriter.WriteLine();
				if (ex != null)
				{
					streamWriter.WriteLine("Type: " + ex.GetType().FullName);
					streamWriter.WriteLine("Message: " + ex.Message);
					streamWriter.WriteLine("StackTrace: " + ex.StackTrace);
				}
			}
			catch
			{
			}
		}

		public bool TapByTextWithPopupAppear(int countCheck, string textCheck, string[] arrText)
		{
			bool result = false;
			string text = "";
			for (int i = 0; i < countCheck; i++)
			{
				text = GetHtml();
				List<string> list = new List<string> { textCheck };
				list.AddRange(arrText);
				int num = CheckExistTexts(text, 0.0, list.ToArray());
				if (num != 0)
				{
					TapByText(list[num - 1], text);
				}
				if (num != 1)
				{
					DelayTime(1.0);
					continue;
				}
				result = true;
				break;
			}
			return result;
		}
	}
}
