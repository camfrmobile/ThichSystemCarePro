using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SystemCarePro;
using SystemCarePro.Helper;
using Bunifu.Framework.UI;
using Common;
using DeviceId;
using maxcare.Enum;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;
using MetroFramework;
using MetroFramework.Controls;
using Newtonsoft.Json.Linq;
using WindowsFormsControlLibrary1;

namespace maxcare
{
	public class fShareBai : Form
	{
		private Random rd = new Random();

		private bool isStop;

		private JSON_Settings setting_general;

		private JSON_Settings setting_InteractGeneral;

		private JSON_Settings setting_LDPlayer;

		private JSON_Settings setting_ShowDtgv;

		private int icheck1 = 0;

		private List<Thread> lstThread = null;

		private List<TinsoftProxy> listTinsoft = null;

		private List<XproxyProxy> listxProxy = null;

		private List<TMProxy> listTMProxy = null;

		private List<ProxyWeb> listProxyWeb = null;

		private List<ShopLike> listShopLike = null;

		private List<string> listApiTinsoft = null;

		private List<string> listProxyXproxy = null;

		private List<string> listProxyTMProxy = null;

		private List<string> listProxyProxyv6 = null;

		private List<string> listProxyShopLike = null;

		private int checkDelayLD = 0;

		private object lock_checkDelayLD = new object();

		private bool isOpeningDevice = false;

		private object lock_checkDelayCreateDevice = new object();

		private int checkDelayLD_MoLDPLayer = 0;

		private object lock_checkDelayLD_MoLDPLayer = new object();

		private bool isOpeningDevice_MoLDPLayer = false;

		private object lock_checkDelayCreateDevice_MoLDPLayer = new object();

		private bool isReloginIfLogout = false;

		private List<string> lstNoiDung = null;

		private List<Device> lstDevice = null;

		private List<string> lstIdGroupShared = null;

		private object lock_StartProxy = new object();

		private object lock_FinishProxy = new object();

		private object lock_restoreDevice = new object();

		private object lock_useImage = new object();

		private object lock_fileig = new object();

		private object _lockbackup = new object();

		private object lockStatus = new object();

		private int indexCbbThuMucOld = -1;

		private bool isExcute_CbbThuMuc_SelectedIndexChanged = true;

		private object objLock = new object();

		private object _lock = new object();

		private object _lock2 = new object();

		private object _lock3 = new object();

		private object _lock4 = new object();

		private int indexCbbTinhTrangOld = -1;

		private bool isExcute_CbbTinhTrang_SelectedIndexChanged = true;

		private bool isCountCheckAccountWhenChayTuongTac = false;

		private object lock_CreateDevice = new object();

		private IContainer components = null;

		public DataGridView dtgvAcc;

		private BunifuDragControl bunifuDragControl1;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private Button button2;

		private Button button1;

		private Button btnMinimize;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem hệThốngToolStripMenuItem;

		private GroupBox grQuanLyThuMuc;

		private Label label1;

		private MetroComboBox cbbThuMuc;

		private MetroContextMenu ctmsAcc;

		private ToolStripMenuItem chọnLiveToolStripMenuItem;

		private ToolStripMenuItem liveToolStripMenuItem;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem tokenToolStripMenuItem;

		private ToolStripMenuItem cookieToolStripMenuItem;

		private ToolStripMenuItem uidPassToolStripMenuItem;

		private ToolStripMenuItem uidPassTokenCookieToolStripMenuItem;

		private ToolStripMenuItem xóaTàiKhoảnToolStripMenuItem;

		private ToolStripMenuItem chuyểnThưMụcToolStripMenuItem;

		private ToolStripMenuItem checkCookieToolStripMenuItem;

		private ToolStripMenuItem tấtCảToolStripMenuItem;

		private ToolStripMenuItem bỏChọnTấtCảToolStripMenuItem;

		private ToolStripMenuItem passToolStripMenuItem;

		private Button btnInteract;

		private ToolStripMenuItem kiểmTraCookieToolStripMenuItem;

		private ToolStripMenuItem kiểmTraTokenToolStripMenuItem;

		private ToolStripMenuItem tảiLạiDanhSáchToolStripMenuItem;

		private Button btnPause;

		private ToolStripMenuItem chứcNăngToolStripMenuItem1;

		private ToolStripMenuItem mailPassMailToolStripMenuItem;

		private ToolStripMenuItem uidPassTokenCookieMailPassMailToolStripMenuItem;

		private ToolStripMenuItem trạngTháiToolStripMenuItem;

		private ToolStripMenuItem kiểmTraWallToolStripMenuItem;

		private GroupBox grTimKiem;

		private BunifuCustomTextbox txbSearch;

		private ToolStripMenuItem mailToolStripMenuItem;

		private ToolStripMenuItem uidPassTokenCookieMailPassMail2faToolStripMenuItem;

		private ToolStripMenuItem fAToolStripMenuItem;

		private ToolStripMenuItem tinhTrangToolStripMenuItem;

		private ToolStripMenuItem locTrungToolStripMenuItem;

		private ToolStripMenuItem uidPass2FaToolStripMenuItem;

		private BunifuDragControl bunifuDragControl2;

		private ToolTip toolTip1;

		private ToolStripMenuItem đinhDangKhacToolStripMenuItem;

		private ToolStripMenuItem câpNhâtThôngTinCaNhânToolStripMenuItem;

		private ToolStripMenuItem sưDungTokenTrungGianToolStripMenuItem;

		private ToolStripMenuItem maBaoMât6SôToolStripMenuItem;

		private ToolStripMenuItem thoátToolStripMenuItem;

		private ToolStripMenuItem useragentToolStripMenuItem1;

		private ToolStripMenuItem proxyToolStripMenuItem1;

		private ComboBox cbbSearch;

		private MetroButton AddFileAccount;

		private MetroButton btnDeleteFile;

		private MetroButton btnLoadAcc;

		private MetroComboBox cbbTinhTrang;

		private Label label2;

		private ToolStripMenuItem kiểmTraMailpassMailToolStripMenuItem;

		private ToolStripMenuItem loginHotmailToolStripMenuItem;

		private MetroButton BtnSearch;

		private ToolStripMenuItem uidToolStripMenuItem;

		private ToolStripMenuItem checkAvatarToolStripMenuItem;

		private ToolStripMenuItem checkProxyToolStripMenuItem;

		private ToolStripMenuItem tảiXuốngAvatarToolStripMenuItem;

		private ToolStripMenuItem checkInfoUIDToolStripMenuItem;

		private ToolStripMenuItem checkBackupToolStripMenuItem1;

		private MetroButton btnEditFile;

		private ToolStripMenuItem sửDụngCookieTrungGianToolStripMenuItem;

		private ToolStripMenuItem lToolStripMenuItem;

		private ToolStripMenuItem loginYandexToolStripMenuItem;

		private DataGridViewCheckBoxColumn cChose;

		private DataGridViewTextBoxColumn cStt;

		private DataGridViewTextBoxColumn cId;

		private DataGridViewTextBoxColumn cUid;

		private DataGridViewTextBoxColumn cToken;

		private DataGridViewTextBoxColumn cCookies;

		private DataGridViewTextBoxColumn cEmail;

		private DataGridViewTextBoxColumn cPhone;

		private DataGridViewTextBoxColumn cName;

		private DataGridViewTextBoxColumn cFollow;

		private DataGridViewTextBoxColumn cFriend;

		private DataGridViewTextBoxColumn cGroup;

		private DataGridViewTextBoxColumn cBirthday;

		private DataGridViewTextBoxColumn cGender;

		private DataGridViewTextBoxColumn cPassword;

		private DataGridViewTextBoxColumn cMailRecovery;

		private DataGridViewTextBoxColumn cPassMail;

		private DataGridViewTextBoxColumn cBackup;

		private DataGridViewTextBoxColumn cFa2;

		private DataGridViewTextBoxColumn cUseragent;

		private DataGridViewTextBoxColumn cProxy;

		private DataGridViewTextBoxColumn cDateCreateAcc;

		private DataGridViewTextBoxColumn cAvatar;

		private DataGridViewTextBoxColumn cProfile;

		private DataGridViewTextBoxColumn cThuMuc;

		private DataGridViewTextBoxColumn cInteractEnd;

		private DataGridViewTextBoxColumn cDevice;

		private DataGridViewTextBoxColumn cInfo;

		private DataGridViewTextBoxColumn cGhiChu;

		private DataGridViewTextBoxColumn cStatus;

		private System.Windows.Forms.Timer timer1;

		public BunifuCustomLabel bunifuCustomLabel1;

		private Label lblTrangThai;

		private Panel plTrangThai;

		private Panel panel1;

		private StatusStrip statusStrip1;

		private ToolStripMenuItem càiĐặtToolStripMenuItem;

		private ToolStripStatusLabel toolStripStatusLabel5;

		private ToolStripStatusLabel lblCountSelect;

		private ToolStripStatusLabel toolStripStatusLabel7;

		private ToolStripStatusLabel lblCountTotal;

		public fShareBai()
		{
			InitializeComponent();
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(hệThốngToolStripMenuItem);
			Language.GetValue(btnInteract);
			Language.GetValue(btnPause);
			Language.GetValue(grTimKiem);
			Language.GetValue(grQuanLyThuMuc);
			Language.GetValue(label1);
			Language.GetValue(label2);
			Language.GetValue(càiĐặtToolStripMenuItem);
			Language.GetValue(thoátToolStripMenuItem);
			foreach (DataGridViewColumn column in dtgvAcc.Columns)
			{
				Language.GetValue(column);
			}
			Language.GetValue(chọnLiveToolStripMenuItem);
			Language.GetValue(tấtCảToolStripMenuItem);
			Language.GetValue(liveToolStripMenuItem);
			Language.GetValue(tinhTrangToolStripMenuItem);
			Language.GetValue(trạngTháiToolStripMenuItem);
			Language.GetValue(bỏChọnTấtCảToolStripMenuItem);
			Language.GetValue(maBaoMât6SôToolStripMenuItem);
			Language.GetValue(xóaTàiKhoảnToolStripMenuItem);
			Language.GetValue(checkCookieToolStripMenuItem);
			Language.GetValue(câpNhâtThôngTinCaNhânToolStripMenuItem);
			Language.GetValue(sưDungTokenTrungGianToolStripMenuItem);
			Language.GetValue(sửDụngCookieTrungGianToolStripMenuItem);
			Language.GetValue(chuyểnThưMụcToolStripMenuItem);
			Language.GetValue(chứcNăngToolStripMenuItem1);
			Language.GetValue(locTrungToolStripMenuItem);
			Language.GetValue(tảiXuốngAvatarToolStripMenuItem);
			Language.GetValue(lToolStripMenuItem);
			Language.GetValue(tảiLạiDanhSáchToolStripMenuItem);
			Language.GetValue(toolStripStatusLabel5);
			Language.GetValue(toolStripStatusLabel7);
		}

		protected override void OnLoad(EventArgs args)
		{
			Application.Idle += OnLoaded;
		}

		private void OnLoaded(object sender, EventArgs e)
		{
			Application.Idle -= OnLoaded;
			LoadcbbSearch();
			LoadSetting();
			LoadConfigManHinh();
			LoadCbbThuMuc();
			LoadCbbTinhTrang();
			Base.width = base.Width;
			Base.heigh = base.Height;
			menuStrip1.Cursor = Cursors.Hand;
		}

		private void LoadcbbSearch()
		{
			Dictionary<string, string> dataSource = new Dictionary<string, string>
			{
				{ "cUid", "UID" },
				{
					"cPassword",
					Language.GetValue("Mật khẩu")
				},
				{
					"cName",
					Language.GetValue("Tên")
				},
				{
					"cBirthday",
					Language.GetValue("Ngày sinh")
				},
				{
					"cGender",
					Language.GetValue("Giới tính")
				},
				{ "cToken", "Token" },
				{ "cCookies", "Cookie" },
				{ "cEmail", "Email" },
				{ "cPassMail", "Pass email" },
				{ "cFa2", "2FA" },
				{
					"cGhiChu",
					Language.GetValue("Ghi chu\u0301")
				},
				{
					"cInteractEnd",
					Language.GetValue("Tương ta\u0301c cuô\u0301i")
				}
			};
			cbbSearch.DataSource = new BindingSource(dataSource, null);
			cbbSearch.ValueMember = "Key";
			cbbSearch.DisplayMember = "Value";
		}

		private void LoadCbbThuMuc()
		{
			isExcute_CbbThuMuc_SelectedIndexChanged = false;
			DataTable allFilesFromDatabase = CommonSQL.GetAllFilesFromDatabase(isShowAll: true);
			cbbThuMuc.DataSource = allFilesFromDatabase;
			cbbThuMuc.ValueMember = "id";
			cbbThuMuc.DisplayMember = "name";
			isExcute_CbbThuMuc_SelectedIndexChanged = true;
		}

		private void LoadCbbTinhTrang(List<string> lstIdFile = null)
		{
			try
			{
				DataTable allInfoFromAccount = CommonSQL.GetAllInfoFromAccount(lstIdFile);
				cbbTinhTrang.DataSource = allInfoFromAccount;
				cbbTinhTrang.ValueMember = "id";
				cbbTinhTrang.DisplayMember = "name";
			}
			catch
			{
			}
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (base.Width == Screen.PrimaryScreen.WorkingArea.Width && base.Height == Screen.PrimaryScreen.WorkingArea.Height)
			{
				base.Width = Base.width;
				base.Height = Base.heigh;
				base.Top = Base.top;
				base.Left = Base.left;
			}
			else
			{
				Base.top = base.Top;
				Base.left = base.Left;
				base.Top = 0;
				base.Left = 0;
				base.Width = Screen.PrimaryScreen.WorkingArea.Width;
				base.Height = Screen.PrimaryScreen.WorkingArea.Height;
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void BtnLoadAcc_Click(object sender, EventArgs e)
		{
			string text = "";
			if (cbbThuMuc.SelectedValue != null)
			{
				text = cbbThuMuc.SelectedValue.ToString();
			}
			LoadCbbThuMuc();
			if (text != "999999" && text != "-1")
			{
				indexCbbThuMucOld = -1;
				cbbThuMuc.SelectedValue = text;
				return;
			}
			isExcute_CbbThuMuc_SelectedIndexChanged = false;
			cbbThuMuc.SelectedValue = text;
			isExcute_CbbThuMuc_SelectedIndexChanged = true;
			LoadCbbTinhTrang(fChonThuMuc.lstChooseIdFiles);
		}

		private List<string> GetIdFile()
		{
			List<string> result = null;
			try
			{
				string text = cbbThuMuc.SelectedValue.ToString();
				string text2 = text;
				if (!(text2 == "-1"))
				{
					result = ((text2 == "999999") ? CollectionHelper.CloneList(fChonThuMuc.lstChooseIdFiles) : new List<string> { cbbThuMuc.SelectedValue.ToString() });
				}
			}
			catch
			{
			}
			return result;
		}

		private void LoadAccountFromFile(List<string> lstIdFile = null, string info = "")
		{
			try
			{
				dtgvAcc.Rows.Clear();
				if (info == "[Tất cả tình trạng]" || info == Language.GetValue("[Tất cả tình trạng]"))
				{
					info = "";
				}
				DataTable accFromFile = CommonSQL.GetAccFromFile(lstIdFile, info);
				LoadDtgvAccFromDatatable(accFromFile);
			}
			catch (Exception)
			{
			}
		}

		private void LoadDtgvAccFromDatatable(DataTable tableAccount)
		{
			DatagridviewHelper.LoadDtgvAccFromDatatable(dtgvAcc, tableAccount);
			CountCheckedAccount(0);
			SetRowColor();
			CountTotalAccount();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "";
				if (cbbThuMuc.SelectedValue != null)
				{
					text = cbbThuMuc.SelectedValue.ToString();
				}
				MCommon.Common.ShowForm(new fImportAccount(text));
				if (fImportAccount.isAddAccount || fImportAccount.isAddFile)
				{
					LoadCbbThuMuc();
					indexCbbThuMucOld = -1;
					if (fImportAccount.isAddAccount)
					{
						cbbThuMuc.SelectedValue = fImportAccount.idFileAdded;
					}
					else
					{
						cbbThuMuc.SelectedValue = text;
					}
				}
			}
			catch
			{
			}
		}

		private int GetIndexRowFromCondition(string id)
		{
			int result = -1;
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (dtgvAcc.Rows[i].Cells["cId"].Value.ToString().Equals(id))
				{
					result = i;
					break;
				}
			}
			return result;
		}

		private void ChoseRowInDatagrid(string modeChose)
		{
			switch (modeChose)
			{
			case "ToggleCheck":
			{
				for (int k = 0; k < dtgvAcc.SelectedRows.Count; k++)
				{
					int index = dtgvAcc.SelectedRows[k].Index;
					SetCellAccount(index, "cChose", !Convert.ToBoolean(GetCellAccount(index, "cChose")));
				}
				CountCheckedAccount();
				break;
			}
			case "SelectHighline":
			{
				DataGridViewSelectedRowCollection selectedRows = dtgvAcc.SelectedRows;
				for (int j = 0; j < selectedRows.Count; j++)
				{
					SetCellAccount(selectedRows[j].Index, "cChose", true);
				}
				CountCheckedAccount();
				break;
			}
			case "UnAll":
			{
				for (int l = 0; l < dtgvAcc.RowCount; l++)
				{
					SetCellAccount(l, "cChose", false);
				}
				CountCheckedAccount(0);
				break;
			}
			case "All":
			{
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					SetCellAccount(i, "cChose", true);
				}
				CountCheckedAccount(dtgvAcc.RowCount);
				break;
			}
			}
		}

		private void CopyRowDatagrid(string modeCopy)
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(GetCellAccount(i, "cChose")))
					{
						list.Add(GetCellAccount(i, "cId"));
						break;
					}
				}
				if (list.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox("Vui lòng chọn danh sách tài khoản muốn copy thông tin!", 3);
					return;
				}
				switch (modeCopy)
				{
				case "uid|pass|token|cookie":
				{
					for (int k = 0; k < dtgvAcc.RowCount; k++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[k].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(k, "cUid") + "|" + GetCellAccount(k, "cPassword") + "|" + GetCellAccount(k, "cToken") + "|" + GetCellAccount(k, "cCookies") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass":
				{
					for (int num5 = 0; num5 < dtgvAcc.RowCount; num5++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num5].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num5, "cUid") + "|" + GetCellAccount(num5, "cPassword") + "\r\n";
						}
					}
					break;
				}
				case "mail|passmail":
				{
					for (int num9 = 0; num9 < dtgvAcc.RowCount; num9++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num9].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num9, "cEmail") + "|" + GetCellAccount(num9, "cPassMail") + "\r\n";
						}
					}
					break;
				}
				case "ma2fa":
				{
					for (int num = 0; num < dtgvAcc.RowCount; num++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							text = text + MCommon.Common.GetTotp(GetCellAccount(num, "cFa2")) + "\r\n";
						}
					}
					break;
				}
				case "2fa":
				{
					for (int num11 = 0; num11 < dtgvAcc.RowCount; num11++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num11].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num11, "cFa2") + "\r\n";
						}
					}
					break;
				}
				case "uid":
				{
					for (int num7 = 0; num7 < dtgvAcc.RowCount; num7++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num7].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num7, "cUid") + "\r\n";
						}
					}
					break;
				}
				case "pass":
				{
					for (int num3 = 0; num3 < dtgvAcc.RowCount; num3++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num3, "cPassword") + "\r\n";
						}
					}
					break;
				}
				case "cookie":
				{
					for (int m = 0; m < dtgvAcc.RowCount; m++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[m].Cells["cChose"].Value))
						{
							string cellAccount = GetCellAccount(m, "cCookies");
							text = text + cellAccount + "\r\n";
						}
					}
					break;
				}
				case "useragent":
				{
					for (int num12 = 0; num12 < dtgvAcc.RowCount; num12++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num12].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num12, "cUseragent") + "\r\n";
						}
					}
					break;
				}
				case "proxy":
				{
					for (int num10 = 0; num10 < dtgvAcc.RowCount; num10++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num10].Cells["cChose"].Value))
						{
							string text2 = GetCellAccount(num10, "cProxy");
							if (text2.EndsWith("*0") || text2.EndsWith("*1"))
							{
								text2 = text2.Substring(0, text2.Length - 2);
							}
							text = text + text2 + "\r\n";
						}
					}
					break;
				}
				case "token":
				{
					for (int num8 = 0; num8 < dtgvAcc.RowCount; num8++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num8].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num8, "cToken") + "\r\n";
						}
					}
					break;
				}
				case "name":
				{
					for (int num6 = 0; num6 < dtgvAcc.RowCount; num6++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num6].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num6, "cName") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass|2fa":
				{
					for (int num4 = 0; num4 < dtgvAcc.RowCount; num4++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num4, "cUid") + "|" + GetCellAccount(num4, "cPassword") + "|" + GetCellAccount(num4, "cFa2") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass|token|cookie|mail|passmail":
				{
					for (int num2 = 0; num2 < dtgvAcc.RowCount; num2++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(num2, "cUid") + "|" + GetCellAccount(num2, "cPassword") + "|" + GetCellAccount(num2, "cToken") + "|" + GetCellAccount(num2, "cCookies") + "|" + GetCellAccount(num2, "cEmail") + "|" + GetCellAccount(num2, "cPassMail") + "\r\n";
						}
					}
					break;
				}
				case "birthday":
				{
					for (int n = 0; n < dtgvAcc.RowCount; n++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[n].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(n, "cBirthday") + "\r\n";
						}
					}
					break;
				}
				case "mail":
				{
					for (int l = 0; l < dtgvAcc.RowCount; l++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[l].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(l, "cEmail") + "\r\n";
						}
					}
					break;
				}
				case "uid|pass|token|cookie|mail|passmail|fa2":
				{
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							text = text + GetCellAccount(j, "cUid") + "|" + GetCellAccount(j, "cPassword") + "|" + GetCellAccount(j, "cToken") + "|" + GetCellAccount(j, "cCookies") + "|" + GetCellAccount(j, "cEmail") + "|" + GetCellAccount(j, "cPassMail") + "|" + GetCellAccount(j, "cFa2") + "\r\n";
						}
					}
					break;
				}
				}
				Clipboard.SetText(text.TrimEnd('\r', '\n'));
			}
			catch
			{
			}
		}

		private string ConvertCookie(string cookie)
		{
			string text = "";
			string value = Regex.Match(cookie + ";", "sb=(.*?);").Groups[1].Value;
			if (value != "")
			{
				text = text + "sb=" + value + ";";
			}
			string value2 = Regex.Match(cookie + ";", "wd=(.*?);").Groups[1].Value;
			if (value2 != "")
			{
				text = text + "wd=" + value2 + ";";
			}
			string value3 = Regex.Match(cookie + ";", "datr=(.*?);").Groups[1].Value;
			if (value3 != "")
			{
				text = text + "datr=" + value3 + ";";
			}
			string value4 = Regex.Match(cookie + ";", "locale=(.*?);").Groups[1].Value;
			if (value4 != "")
			{
				text = text + "locale=" + value4 + ";";
			}
			string value5 = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
			if (value5 != "")
			{
				text = text + "c_user=" + value5 + ";";
			}
			string value6 = Regex.Match(cookie + ";", "xs=(.*?);").Groups[1].Value;
			if (value6 != "")
			{
				text = text + "xs=" + value6 + ";";
			}
			string value7 = Regex.Match(cookie + ";", "fr=(.*?);").Groups[1].Value;
			if (value7 != "")
			{
				text = text + "fr=" + value7 + ";";
			}
			string value8 = Regex.Match(cookie + ";", "spin=(.*?);").Groups[1].Value;
			if (value8 != "")
			{
				text = text + "spin=" + value8 + ";";
			}
			return text;
		}

		private void TấtCảToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChoseRowInDatagrid("All");
		}

		private void LiveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChoseRowInDatagrid("SelectHighline");
		}

		private void BỏChọnTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChoseRowInDatagrid("UnAll");
		}

		private void TokenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("token");
		}

		private void CookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("cookie");
		}

		private void UidToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid");
		}

		private void PassToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("pass");
		}

		private void UidPassToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass");
		}

		private void UidPassTokenCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie");
		}

		private void AddFileAccount_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fAddFile());
			if (fAddFile.isAdd)
			{
				LoadCbbThuMuc();
				cbbThuMuc.SelectedIndex = cbbThuMuc.Items.Count - 2;
			}
		}

		private void DeleteAccountDatagridFromId()
		{
			for (int i = 0; i < dtgvAcc.SelectedRows.Count; i++)
			{
				dtgvAcc.Rows.RemoveAt(dtgvAcc.SelectedRows[i].Index);
			}
		}

		private void FMain_Load(object sender, EventArgs e)
		{
		}

		private void CtmsAcc_Opening(object sender, CancelEventArgs e)
		{
			chuyểnThưMụcToolStripMenuItem.DropDownItems.Clear();
			DataTable allFilesFromDatabase = CommonSQL.GetAllFilesFromDatabase();
			int num = 0;
			for (int i = 0; i < allFilesFromDatabase.Rows.Count; i++)
			{
				DataRow dataRow = allFilesFromDatabase.Rows[i];
				if (dataRow["id"].ToString() != ((cbbThuMuc.SelectedValue == null) ? "" : cbbThuMuc.SelectedValue.ToString()))
				{
					chuyểnThưMụcToolStripMenuItem.DropDownItems.Add(dataRow["name"].ToString());
					chuyểnThưMụcToolStripMenuItem.DropDownItems[i - num].Tag = dataRow["id"];
					chuyểnThưMụcToolStripMenuItem.DropDownItems[i - num].Click += TransfomerAccount;
				}
				else
				{
					num++;
				}
			}
			trạngTháiToolStripMenuItem.DropDownItems.Clear();
			List<string> list = new List<string>();
			string text = "";
			string text2 = "";
			for (int j = 0; j < dtgvAcc.RowCount; j++)
			{
				text = GetCellAccount(j, "cStatus");
				if (text != "")
				{
					text2 = Regex.Match(text, "\\(IP: (.*?)\\)").Value;
					if (text2 != "")
					{
						text = text.Replace(text2, "").Trim();
					}
					text2 = Regex.Match(text, "\\[(.*?)\\]").Value;
					if (text2 != "")
					{
						text = text.Replace(text2, "").Trim();
					}
					if (text != "" && !list.Contains(text))
					{
						list.Add(text);
					}
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				trạngTháiToolStripMenuItem.DropDownItems.Add(list[k]);
				trạngTháiToolStripMenuItem.DropDownItems[k].Click += SelectGridByStatus;
			}
			tinhTrangToolStripMenuItem.DropDownItems.Clear();
			list = new List<string>();
			string text3 = "";
			for (int l = 0; l < dtgvAcc.RowCount; l++)
			{
				text3 = GetCellAccount(l, "cInfo");
				if (!text3.Equals("") && !list.Contains(text3))
				{
					list.Add(text3);
				}
			}
			for (int m = 0; m < list.Count; m++)
			{
				tinhTrangToolStripMenuItem.DropDownItems.Add(list[m]);
				tinhTrangToolStripMenuItem.DropDownItems[m].Click += SelectGridByInfo;
			}
		}

		private void SelectGridByInfo(object sender, EventArgs e)
		{
			ChooseAccountByValue("cInfo", (sender as ToolStripMenuItem).Text);
		}

		private void SelectGridByStatus(object sender, EventArgs e)
		{
			ChooseAccountByValue("cStatus", (sender as ToolStripMenuItem).Text);
		}

		private void ChooseAccountByValue(string column, string value)
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				dtgvAcc.Rows[i].Cells["cChose"].Value = GetCellAccount(i, column).Contains(value);
			}
			CountCheckedAccount();
		}

		private void TransfomerAccount(object sender, EventArgs e)
		{
			if (Convert.ToInt32(lblCountSelect.Text) == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chuyển!"), 3);
				return;
			}
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có thực sự muốn chuyển {0} tài khoản sang thư mục [{1}]?"), lblCountSelect.Text, toolStripMenuItem.Text)) == DialogResult.Yes)
			{
				TransfomAccountToOrtherFile(toolStripMenuItem.Tag.ToString());
			}
		}

		private void TransfomAccountToOrtherFile(string idFileTo)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
					}
				}
				if (CommonSQL.UpdateFieldToAccount(list, "idfile", idFileTo))
				{
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							dtgvAcc.Rows.RemoveAt(j--);
						}
					}
					SetRowColor();
					UpdateSttOnDatatable();
					CountCheckedAccount(0);
					CountTotalAccount();
					MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Chuyển thành công {0} tài khoản!"), list.Count));
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Chuyển thất bại, vui lòng thử lại sau!"), 2);
				}
			}
			catch
			{
			}
		}

		private void DeleteAccount(bool isDeleteProfile)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
				}
			}
			if (list.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản cần xóa!"));
			}
			else
			{
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có muốn xóa {0} tài khoản đã chọn?"), CountChooseRowInDatagridview()) + "\r\n" + Language.GetValue("(Đồng thời xóa luôn LDPlayer của tài khoản)") + "\r\n" + Language.GetValue("(Ta\u0300i khoa\u0309n sau khi xo\u0301a se\u0303 đươ\u0323c lưu ta\u0323i mu\u0323c [Ta\u0300i khoa\u0309n đa\u0303 xo\u0301a])")) != DialogResult.Yes)
				{
					return;
				}
				if (isDeleteProfile)
				{
					int iThread = 0;
					int num = 0;
					while (num < dtgvAcc.Rows.Count)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < 10)
							{
								Interlocked.Increment(ref iThread);
								int row = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row, Language.GetValue("Đang xo\u0301a profile..."));
									DeleteProfile(row);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num++;
						}
					}
					while (iThread > 0)
					{
						MCommon.Common.DelayTime(1.0);
					}
				}
				if (CommonSQL.DeleteAccountToDatabase(list))
				{
					CommonSQL.UpdateMultiFieldToAccount(list, "device", "");
					LoadSetting();
					bool valueBool = setting_general.GetValueBool("isRunSwap");
					string pathLDPlayer = ConfigHelper.GetPathLDPlayer();
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							continue;
						}
						if (!valueBool)
						{
							string cellAccount = GetCellAccount(j, "cDevice");
							if (cellAccount != "" && Directory.Exists(pathLDPlayer + "\\vms\\leidian" + cellAccount))
							{
								try
								{
									Directory.Delete(pathLDPlayer + "\\vms\\leidian" + cellAccount, recursive: true);
								}
								catch
								{
								}
							}
						}
						dtgvAcc.Rows.RemoveAt(j--);
					}
					UpdateSttOnDatatable();
					CountTotalAccount();
					CountCheckedAccount(0);
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Xóa thất bại, vui lòng thử lại sau!"), 2);
				}
			}
		}

		public List<string> GetListKeyTinsoft()
		{
			List<string> list = new List<string>();
			try
			{
				if (setting_general.GetValueInt("typeApiTinsoft") == 0)
				{
					RequestXNet requestXNet = new RequestXNet("", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)", "", 0);
					string json = requestXNet.RequestGet("http://proxy.tinsoftsv.com/api/getUserKeys.php?key=" + setting_general.GetValue("txtApiUser"));
					JObject jObject = JObject.Parse(json);
					foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
					{
						if (Convert.ToBoolean(item["success"]!.ToString()))
						{
							list.Add(item["key"]!.ToString());
						}
					}
				}
				else
				{
					List<string> valueList = setting_general.GetValueList("txtApiProxy");
					foreach (string item2 in valueList)
					{
						if (TinsoftProxy.CheckApiProxy(item2))
						{
							list.Add(item2);
						}
					}
				}
			}
			catch
			{
			}
			return list;
		}

		private bool CheckIsUidFacebook(string uid)
		{
			return MCommon.Common.IsNumber(uid) && !uid.StartsWith("0");
		}

		private void OpenFormViewLD(bool isRunSwap)
		{
			if (!MCommon.Common.CheckFormIsOpenning("fViewLD"))
			{
				fViewLD obj = new fViewLD();
				obj.isRunSwap = false;
				obj.Show();
			}
		}

		private void CloseFormViewLD()
		{
			MCommon.Common.CloseForm("fViewLD");
		}

		private bool ConnectProxy(Device device, string text)
		{
			bool result = false;
			device.OpenApp("com.cell47.College_Proxy");
			for (int i = 0; i < 5; i++)
			{
				if (device.GetActivity() == "com.cell47.College_Proxy/com.cell47.College_Proxy.ui.MainActivity")
				{
					break;
				}
				device.DelayTime(1.0);
			}
			if (device.WaitForTextDisappear(30.0, "please wait"))
			{
				string html = device.GetHtml();
				if (device.CheckExistText("stop proxy service", html))
				{
					device.TapByText("stop proxy service", html);
					device.DelayTime(1.0);
					html = device.GetHtml();
				}
				string text2 = device.CheckIP();
				List<string> list = new List<string> { "125,90", "125,125", "125,160", "125,195" };
				for (int j = 0; j < 4; j++)
				{
					device.DoubleTap(Convert.ToInt32(list[j].Split(',')[0]), Convert.ToInt32(list[j].Split(',')[1]));
					device.DelayTime(1.0);
					device.InputText(text.Split(':')[j].ToString());
					device.DelayTime(1.0);
				}
				device.TapByText("start proxy service", html);
				for (int k = 0; k < 10; k++)
				{
					html = device.GetHtml();
					switch (device.CheckExistTexts(html, 0.0, "connection request", "stop proxy service"))
					{
					case 0:
						continue;
					case 1:
						device.TapByText("ok", html);
						device.DelayTime(1.0);
						break;
					}
					break;
				}
				string deviceId = "127.0.0.1:" + (device.IndexDevice * 2 + 5555);
				ADBHelper.ConnectDevice(deviceId);
				string text3 = "";
				for (int l = 0; l < 10; l++)
				{
					text3 = device.CheckIP();
					if (text3 != "" && !text3.Contains("error"))
					{
						break;
					}
					Thread.Sleep(1000);
				}
				result = text2 != text3 && !text3.Contains("error") && text3 != "";
			}
			return result;
		}

		private void BtnInteract_Click(object sender, EventArgs e)
		{
			lstDevice = new List<Device>();
			Thread threadRefreshDeviceId = null;
			try
			{
				threadRefreshDeviceId = new Thread((ThreadStart)delegate
				{
					while (true)
					{
						try
						{
							if (fMain.remote.isResetAdb && lstDevice.Count > 0)
							{
								bool flag = false;
								while (!flag)
								{
									flag = true;
									for (int num11 = 0; num11 < lstDevice.Count; num11++)
									{
										string deviceByIndex = ADBHelper.GetDeviceByIndex(lstDevice[num11].IndexDevice);
										if (string.IsNullOrEmpty(deviceByIndex))
										{
											flag = false;
										}
										else
										{
											lstDevice[num11].DeviceId = deviceByIndex;
										}
									}
								}
								fMain.remote.isResetAdb = false;
							}
						}
						catch
						{
						}
						MCommon.Common.DelayTime(5.0);
					}
				});
				threadRefreshDeviceId.IsBackground = true;
				threadRefreshDeviceId.Start();
			}
			catch
			{
			}
			try
			{
				if (CountChooseRowInDatagridview() == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chạy!"), 3);
					return;
				}
				LoadSetting();
				isReloginIfLogout = setting_InteractGeneral.GetValueBool("ckbReloginIfLogout");
				bool isRunSwap = setting_general.GetValueBool("isRunSwap");
				string pathLD = ConfigHelper.GetPathLDPlayer();
				if (!Directory.Exists(pathLD))
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer không hợp lệ!"), 3);
					return;
				}
				int maxThread = setting_general.GetValueInt("nudInteractThread", 3);
				maxThread = ((CountChooseRowInDatagridview() < maxThread) ? CountChooseRowInDatagridview() : maxThread);
				switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
				{
				case 7:
				{
					listApiTinsoft = GetListKeyTinsoft();
					if (listApiTinsoft.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy Tinsoft không đủ, vui lòng mua thêm!"), 2);
						return;
					}
					listTinsoft = new List<TinsoftProxy>();
					for (int l = 0; l < listApiTinsoft.Count; l++)
					{
						TinsoftProxy item4 = new TinsoftProxy(listApiTinsoft[l], setting_general.GetValueInt("nudLuongPerIPTinsoft"), setting_general.GetValueInt("cbbLocationTinsoft"));
						listTinsoft.Add(item4);
					}
					if (listApiTinsoft.Count * setting_general.GetValueInt("nudLuongPerIPTinsoft") < maxThread)
					{
						maxThread = listApiTinsoft.Count * setting_general.GetValueInt("nudLuongPerIPTinsoft");
					}
					break;
				}
				case 8:
				{
					listProxyXproxy = setting_general.GetValueList("txtListProxy");
					if (listProxyXproxy.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy không đủ, vui lòng cấu hình lại!"), 2);
						return;
					}
					listxProxy = new List<XproxyProxy>();
					for (int m = 0; m < listProxyXproxy.Count; m++)
					{
						XproxyProxy item5 = new XproxyProxy(setting_general.GetValue("txtServiceURLXProxy"), listProxyXproxy[m], setting_general.GetValueInt("typeProxy"), setting_general.GetValueInt("nudLuongPerIPXProxy"));
						listxProxy.Add(item5);
					}
					if (listProxyXproxy.Count * setting_general.GetValueInt("nudLuongPerIPXProxy") < maxThread)
					{
						maxThread = listProxyXproxy.Count * setting_general.GetValueInt("nudLuongPerIPXProxy");
					}
					break;
				}
				case 10:
				{
					listProxyTMProxy = setting_general.GetValueList("txtApiKeyTMProxy");
					if (listProxyTMProxy.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy không đủ, vui lòng mua thêm!"), 2);
						return;
					}
					listTMProxy = new List<TMProxy>();
					for (int j = 0; j < listProxyTMProxy.Count; j++)
					{
						TMProxy item2 = new TMProxy(listProxyTMProxy[j], 0, setting_general.GetValueInt("nudLuongPerIPTMProxy"));
						listTMProxy.Add(item2);
					}
					if (listProxyTMProxy.Count * setting_general.GetValueInt("nudLuongPerIPTMProxy") < maxThread)
					{
						maxThread = listProxyTMProxy.Count * setting_general.GetValueInt("nudLuongPerIPTMProxy");
					}
					break;
				}
				case 11:
				{
					listProxyProxyv6 = setting_general.GetValueList("txtListProxyv6");
					if (listProxyProxyv6.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy không đủ, vui lòng cấu hình lại!"), 2);
						return;
					}
					listProxyWeb = new List<ProxyWeb>();
					for (int k = 0; k < listProxyProxyv6.Count; k++)
					{
						ProxyWeb item3 = new ProxyWeb(setting_general.GetValue("txtApiProxyv6"), listProxyProxyv6[k], 0, setting_general.GetValueInt("nudLuongPerIPProxyv6"));
						listProxyWeb.Add(item3);
					}
					if (listProxyProxyv6.Count * setting_general.GetValueInt("nudLuongPerIPProxyv6") < maxThread)
					{
						maxThread = listProxyProxyv6.Count * setting_general.GetValueInt("nudLuongPerIPProxyv6");
					}
					break;
				}
				case 12:
				{
					listProxyShopLike = setting_general.GetValueList("txtApiShopLike");
					if (listProxyShopLike.Count == 0)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Proxy không đủ, vui lòng mua thêm!"), 2);
						return;
					}
					listShopLike = new List<ShopLike>();
					for (int i = 0; i < listProxyShopLike.Count; i++)
					{
						ShopLike item = new ShopLike(listProxyShopLike[i], 0, setting_general.GetValueInt("nudLuongPerIPShopLike"));
						listShopLike.Add(item);
					}
					if (listProxyShopLike.Count * setting_general.GetValueInt("nudLuongPerIPShopLike") < maxThread)
					{
						maxThread = listProxyShopLike.Count * setting_general.GetValueInt("nudLuongPerIPShopLike");
					}
					break;
				}
				}
				lstNoiDung = setting_InteractGeneral.GetValueList("txtNoiDung", setting_InteractGeneral.GetValueInt("typeNganCach"));
				List<int> lstPossition = new List<int>();
				for (int n = 0; n < maxThread; n++)
				{
					lstPossition.Add(0);
				}
				isOpeningDevice = false;
				checkDelayLD = 0;
				cControl("start");
				lstIdGroupShared = new List<string>();
				if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
				{
					OpenFormViewLD(isRunSwap);
					for (int num = 0; num < maxThread; num++)
					{
						fViewLD.remote.AddPanelDevice(num + 1);
					}
				}
				isCountCheckAccountWhenChayTuongTac = true;
				isStop = false;
				int curChangeIp = 0;
				bool isChangeIPSuccess = false;
				lstThread = new List<Thread>();
				new Thread((ThreadStart)delegate
				{
					try
					{
						string text = "";
						int num2 = setting_InteractGeneral.GetValueInt("nudSoLuotChay", 1);
						if (num2 == 0)
						{
							num2 = 1;
						}
						int num3 = 0;
						while (num3 < num2)
						{
							if (setting_InteractGeneral.GetValueBool("ckbRepeatAll"))
							{
								text = ((num2 > 1) ? string.Format(Language.GetValue("Lượt {0}/{1}..."), num3 + 1, num2) : "");
								if (text != "")
								{
									ShowTrangThai(text);
								}
							}
							if (!isStop)
							{
								if (setting_InteractGeneral.GetValueBool("ckbRandomThuTuTaiKhoan"))
								{
									dtgvAcc.Invoke((MethodInvoker)delegate
									{
										RandomThuTuTaiKhoan();
									});
								}
								int num4 = 0;
								while (true)
								{
									if (num4 < dtgvAcc.Rows.Count && !isStop)
									{
										if (!Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
										{
											num4++;
											goto IL_0703;
										}
										if (!isStop)
										{
											if (lstThread.Count < maxThread)
											{
												if (!isStop)
												{
													int row = num4++;
													Thread thread = new Thread((ThreadStart)delegate
													{
														try
														{
															int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
															ExcuteOneThread(row, indexOfPossitionApp + 1, isRunSwap, pathLD);
															MCommon.Common.FillIndexPossition(ref lstPossition, indexOfPossitionApp);
														}
														catch (Exception ex3)
														{
															MCommon.Common.ExportError(null, ex3);
														}
														if (!setting_InteractGeneral.GetValueBool("ckbRepeatAll"))
														{
															SetCellAccount(row, "cChose", false);
														}
													})
													{
														Name = row.ToString()
													};
													lock (lstThread)
													{
														lstThread.Add(thread);
													}
													MCommon.Common.DelayTime(1.0);
													thread.Start();
													goto IL_0703;
												}
											}
											else if (!isStop)
											{
												if ((setting_general.GetValueInt("ip_iTypeChangeIp") == 7 && setting_general.GetValueBool("ckbWaitDoneAllTinsoft")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 8 && setting_general.GetValueBool("ckbWaitDoneAllXproxy")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 10 && setting_general.GetValueBool("ckbWaitDoneAllTMProxy")))
												{
													for (int num5 = 0; num5 < lstThread.Count; num5++)
													{
														lstThread[num5].Join();
														lock (lstThread)
														{
															lstThread.RemoveAt(num5--);
														}
													}
												}
												else if (setting_general.GetValueInt("ip_iTypeChangeIp") != 0 && setting_general.GetValueInt("ip_iTypeChangeIp") != 7 && setting_general.GetValueInt("ip_iTypeChangeIp") != 8 && setting_general.GetValueInt("ip_iTypeChangeIp") != 9 && setting_general.GetValueInt("ip_iTypeChangeIp") != 10 && setting_general.GetValueInt("ip_iTypeChangeIp") != 11 && setting_general.GetValueInt("ip_iTypeChangeIp") != 12)
												{
													for (int num6 = 0; num6 < lstThread.Count; num6++)
													{
														lstThread[num6].Join();
														lock (lstThread)
														{
															lstThread.RemoveAt(num6--);
														}
													}
													if (isStop)
													{
														goto IL_0738;
													}
													Interlocked.Increment(ref curChangeIp);
													if (curChangeIp >= setting_general.GetValueInt("ip_nudChangeIpCount", 1))
													{
														for (int num7 = 0; num7 < 3; num7++)
														{
															isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValueInt("typeDcom"), setting_general.GetValue("ip_txtProfileNameDcom"), setting_general.GetValue("txtUrlHilink"), setting_general.GetValueInt("ip_cbbHostpot"), setting_general.GetValue("ip_txtNordVPN"));
															if (isChangeIPSuccess)
															{
																break;
															}
														}
														if (!isChangeIPSuccess)
														{
															MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 2);
															break;
														}
														curChangeIp = 0;
													}
												}
												else
												{
													for (int num8 = 0; num8 < lstThread.Count; num8++)
													{
														if (!lstThread[num8].IsAlive)
														{
															lock (lstThread)
															{
																lstThread.RemoveAt(num8--);
															}
														}
													}
												}
												goto IL_0703;
											}
										}
									}
									goto IL_0738;
									IL_0738:
									for (int num9 = 0; num9 < lstThread.Count; num9++)
									{
										lstThread[num9].Join();
									}
									if (isStop || !setting_InteractGeneral.GetValueBool("ckbRepeatAll") || isStop)
									{
										break;
									}
									if (num3 + 1 < num2)
									{
										int num10 = Base.rd.Next(setting_InteractGeneral.GetValueInt("nudDelayTurnFrom"), setting_InteractGeneral.GetValueInt("nudDelayTurnTo") + 1) * 60;
										int tickCount = Environment.TickCount;
										while ((Environment.TickCount - tickCount) / 1000 - num10 < 0)
										{
											ShowTrangThai(text + string.Format(Language.GetValue("Chạy lượt tiếp theo sau {time} giây...").Replace("{time}", (num10 - (Environment.TickCount - tickCount) / 1000).ToString())));
											MCommon.Common.DelayTime(0.5);
											if (isStop)
											{
												break;
											}
										}
									}
									if (isStop)
									{
										break;
									}
									num3++;
									goto IL_08bf;
									IL_0703:
									if (!isStop)
									{
										continue;
									}
									goto IL_0738;
								}
							}
							break;
							IL_08bf:;
						}
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2);
					}
					setting_InteractGeneral.Update("txtNoiDung", lstNoiDung);
					setting_InteractGeneral.Save();
					HideTrangThai();
					if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
					{
						CloseFormViewLD();
					}
					cControl("stop");
					isCountCheckAccountWhenChayTuongTac = false;
					try
					{
						threadRefreshDeviceId.Abort();
					}
					catch
					{
					}
				}).Start();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				cControl("stop");
				isCountCheckAccountWhenChayTuongTac = false;
			}
			int x = ((File.Exists("settings\\language.txt") && File.ReadAllText("settings\\language.txt").StartsWith("1")) ? 1 : 0);
			if (x != 0)
			{
			}
		}

		private bool ReviewTag(Chrome chrome)
		{
			bool result = true;
			try
			{
				CommonChrome.GoToSetting_TimelineAndTagging(chrome);
				string cssSelector = chrome.GetCssSelector("a", "href", "/privacy/touch/tags/review/");
				if (cssSelector != "" && chrome.Click(4, cssSelector) == 1)
				{
					chrome.DelayThaoTacNho();
					if (!Convert.ToBoolean(chrome.ExecuteScript("return document.querySelector('input[type=\"checkbox\"]').checked+''").ToString()))
					{
						chrome.Click(4, "form div[role=\"button\"]");
					}
					return true;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private int LoginFacebook(Device device, int indexRow, string statusProxy)
		{
			int result = -1;
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cEmail");
			string cellAccount3 = GetCellAccount(indexRow, "cPassword");
			string cellAccount4 = GetCellAccount(indexRow, "cFa2");
			if (setting_InteractGeneral.GetValueInt("typeLogin") == 0)
			{
				if (cellAccount.Trim() == "" || cellAccount3.Trim() == "")
				{
					if (cellAccount.Trim() == "")
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y UID!"));
					}
					else if (cellAccount3.Trim() == "")
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"));
					}
				}
				else
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đăng nhập bằng Uid|Pass..."));
					result = device.LoginFacebook(cellAccount, cellAccount3, cellAccount4);
				}
			}
			else if (cellAccount2.Trim() == "" || cellAccount3.Trim() == "")
			{
				if (cellAccount2.Trim() == "")
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Email!"));
				}
				else if (cellAccount3.Trim() == "")
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"));
				}
			}
			else
			{
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đăng nhập bằng Email|Pass..."));
				result = device.LoginFacebook(cellAccount2, cellAccount3, cellAccount4);
			}
			return result;
		}

		private int CheckStatusDevice(Device device, int indexRow, string statusProxy, bool isAllowLogin = false)
		{
			device.LoadStatusLD("Check status...");
			string html = "";
			int num = device.CheckStatusDevice(ref html);
			device.LoadStatusLD($"Check status: {num}...");
			if ((num.ToString() ?? "").StartsWith("-1"))
			{
				if (device.CheckExistText("\"ok\"", html))
				{
					device.TapByText("\"ok\"", html);
				}
				else if (device.CheckExistText("DataClick\\image\\ok"))
				{
					device.TapByImageWait("DataClick\\image\\ok");
				}
				num = -1;
			}
			int num2 = num;
			int num3 = num2;
			if (num3 != -1)
			{
				return num;
			}
			if (isReloginIfLogout || isAllowLogin)
			{
				device.CloseAppFacebook();
				string text = "";
				for (int i = 0; i < 10; i++)
				{
					text = device.OpenFacebookAndCheckStatusLogin(0).Split('|')[1];
					if (text == "0")
					{
						break;
					}
				}
				if (text != "1" && LoginFacebook(device, indexRow, statusProxy) == 1)
				{
					return 1;
				}
			}
			return -1;
		}

		private void ExcuteOneThread(int indexRow, int indexPos, bool isRunSwap, string pathLD)
		{
			int num = 0;
			string text = "";
			int num2 = 0;
			string text2 = "";
			int typeProxy = 0;
			string text3 = "";
			TinsoftProxy tinsoftProxy = null;
			XproxyProxy xproxyProxy = null;
			TMProxy tMProxy = null;
			ProxyWeb proxyWeb = null;
			ShopLike shopLike = null;
			bool flag = false;
			string text4 = "";
			Device device = null;
			int num3 = 0;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int sttTaiKhoan = Convert.ToInt32(GetCellAccount(indexRow, "cStt"));
			string text5 = GetCellAccount(indexRow, "cUid");
			string cellAccount = GetCellAccount(indexRow, "cId");
			GetCellAccount(indexRow, "cEmail");
			string cellAccount2 = GetCellAccount(indexRow, "cFa2");
			string cellAccount3 = GetCellAccount(indexRow, "cPassword");
			string cellAccount4 = GetCellAccount(indexRow, "cCookies");
			GetCellAccount(indexRow, "cToken");
			if (text5 == "")
			{
				text5 = Regex.Match(cellAccount4 + ";", "c_user=(.*?);").Groups[1].Value;
			}
			try
			{
				if (setting_InteractGeneral.GetValueBool("ckbCheckLiveUid", valueDefault: true) && CheckIsUidFacebook(text5) && CommonRequest.CheckLiveWall(text5).StartsWith("0|"))
				{
					SetStatusAccount(indexRow, Language.GetValue("Tài khoản Die!"));
					SetInfoAccount(cellAccount, indexRow, "Die");
					num3 = 1;
				}
				else if (isStop)
				{
					SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
					num3 = 1;
				}
				else
				{
					List<string> lstNhomTuNhap;
					while (true)
					{
						switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
						{
						case 12:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy Proxy ShopLike ..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									shopLike = null;
									while (!isStop)
									{
										foreach (ShopLike item3 in listShopLike)
										{
											if (shopLike == null || item3.daSuDung < shopLike.daSuDung)
											{
												shopLike = item3;
											}
										}
										if (shopLike.daSuDung != shopLike.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (shopLike.daSuDung > 0 || shopLike.ChangeProxy())
									{
										text = shopLike.proxy;
										if (text == "")
										{
											text = shopLike.GetProxy();
										}
										ShopLike shopLike2 = shopLike;
										shopLike2.dangSuDung++;
										shopLike2 = shopLike;
										shopLike2.daSuDung++;
										break;
									}
								}
								if (!isStop)
								{
									bool flag5 = true;
									if (setting_general.GetValueInt("nudDelayCheckIP") > 0)
									{
										SetStatusAccount(indexRow, text2 + "Delay check IP...");
										MCommon.Common.DelayTime(setting_general.GetValueInt("nudDelayCheckIP"));
									}
									if (!setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										text2 = "(IP: " + text.Split(':')[0] + ") ";
										SetStatusAccount(indexRow, text2 + "Check IP...");
										text3 = MCommon.Common.CheckProxy(text, 0);
										if (text3 == "")
										{
											flag5 = false;
										}
									}
									if (!flag5)
									{
										ShopLike shopLike2 = shopLike;
										shopLike2.dangSuDung--;
										shopLike2 = shopLike;
										shopLike2.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0140;
						case 11:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy Proxyv6..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									proxyWeb = null;
									while (!isStop)
									{
										foreach (ProxyWeb item4 in listProxyWeb)
										{
											if (proxyWeb == null || item4.daSuDung < proxyWeb.daSuDung)
											{
												proxyWeb = item4;
											}
										}
										if (proxyWeb.daSuDung != proxyWeb.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (proxyWeb.daSuDung > 0 || proxyWeb.ChangeProxy())
									{
										text = proxyWeb.proxy;
										typeProxy = proxyWeb.typeProxy;
										ProxyWeb proxyWeb2 = proxyWeb;
										proxyWeb2.dangSuDung++;
										proxyWeb2 = proxyWeb;
										proxyWeb2.daSuDung++;
										break;
									}
								}
								bool flag9;
								if (isStop)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
									num3 = 1;
								}
								else
								{
									flag9 = true;
									if (setting_general.GetValueInt("nudDelayCheckIP") > 0)
									{
										SetStatusAccount(indexRow, text2 + "Delay check IP...");
										MCommon.Common.DelayTime(setting_general.GetValueInt("nudDelayCheckIP"));
									}
									if (setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										goto IL_07ce;
									}
									text2 = "(IP: " + text.Split(':')[0] + ") ";
									SetStatusAccount(indexRow, text2 + "Check IP...");
									string proxy = text.Split(':')[0] + ":" + text.Split(':')[1];
									int num5 = 0;
									while (true)
									{
										if (num5 < 30)
										{
											MCommon.Common.DelayTime(1.0);
											text3 = MCommon.Common.CheckProxy(proxy, typeProxy);
											if (!(text3 != ""))
											{
												if (!isStop)
												{
													num5++;
													continue;
												}
												SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
												num3 = 1;
												break;
											}
										}
										if (text3 == "")
										{
											flag9 = false;
										}
										goto IL_07ce;
									}
								}
								goto end_IL_04de;
								IL_07ce:
								if (!flag9)
								{
									ProxyWeb proxyWeb2 = proxyWeb;
									proxyWeb2.dangSuDung--;
									proxyWeb2 = proxyWeb;
									proxyWeb2.daSuDung--;
									continue;
								}
								text = text.Split(':')[0] + ":" + text.Split(':')[1];
								break;
								end_IL_04de:;
							}
							goto end_IL_0140;
						case 10:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy TMProxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tMProxy = null;
									while (!isStop)
									{
										foreach (TMProxy item5 in listTMProxy)
										{
											if (tMProxy == null || item5.daSuDung < tMProxy.daSuDung)
											{
												tMProxy = item5;
											}
										}
										if (tMProxy.daSuDung != tMProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (tMProxy.daSuDung > 0 || tMProxy.ChangeProxy())
									{
										text = tMProxy.proxy;
										if (text == "")
										{
											text = tMProxy.GetProxy();
										}
										TMProxy tMProxy2 = tMProxy;
										tMProxy2.dangSuDung++;
										tMProxy2 = tMProxy;
										tMProxy2.daSuDung++;
										break;
									}
								}
								if (!isStop)
								{
									bool flag8 = true;
									if (!setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										text2 = "(IP: " + text.Split(':')[0] + ") ";
										SetStatusAccount(indexRow, text2 + "Check IP...");
										text3 = MCommon.Common.CheckProxy(text, 0);
										if (text3 == "")
										{
											flag8 = false;
										}
									}
									if (!flag8)
									{
										TMProxy tMProxy2 = tMProxy;
										tMProxy2.dangSuDung--;
										tMProxy2 = tMProxy;
										tMProxy2.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0140;
						case 8:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy Xproxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									xproxyProxy = null;
									while (!isStop)
									{
										foreach (XproxyProxy item6 in listxProxy)
										{
											if (xproxyProxy == null || (item6.isProxyLive && item6.daSuDung < xproxyProxy.daSuDung))
											{
												xproxyProxy = item6;
											}
										}
										if (xproxyProxy.daSuDung != xproxyProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (!xproxyProxy.isProxyLive || (xproxyProxy.daSuDung <= 0 && !xproxyProxy.ChangeProxy()))
									{
										xproxyProxy.isProxyLive = false;
										continue;
									}
									text = xproxyProxy.proxy;
									typeProxy = xproxyProxy.typeProxy;
									XproxyProxy xproxyProxy2 = xproxyProxy;
									xproxyProxy2.dangSuDung++;
									xproxyProxy2 = xproxyProxy;
									xproxyProxy2.daSuDung++;
									break;
								}
								bool flag7;
								if (isStop)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
									num3 = 1;
								}
								else
								{
									flag7 = true;
									if (setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										goto IL_0d7d;
									}
									text2 = "(IP: " + text.Split(':')[0] + ") ";
									SetStatusAccount(indexRow, text2 + "Check IP...");
									int num4 = 0;
									while (true)
									{
										if (num4 < 30)
										{
											MCommon.Common.DelayTime(1.0);
											text3 = MCommon.Common.CheckProxy(text, typeProxy);
											if (!(text3 != ""))
											{
												if (!isStop)
												{
													num4++;
													continue;
												}
												SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
												num3 = 1;
												break;
											}
										}
										if (text3 == "")
										{
											flag7 = false;
										}
										goto IL_0d7d;
									}
								}
								goto end_IL_0b04;
								IL_0d7d:
								if (!flag7)
								{
									XproxyProxy xproxyProxy2 = xproxyProxy;
									xproxyProxy2.dangSuDung--;
									xproxyProxy2 = xproxyProxy;
									xproxyProxy2.daSuDung--;
									continue;
								}
								break;
								end_IL_0b04:;
							}
							goto end_IL_0140;
						case 7:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy proxy Tinsoft..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tinsoftProxy = null;
									while (!isStop)
									{
										foreach (TinsoftProxy item7 in listTinsoft)
										{
											if (tinsoftProxy == null || item7.daSuDung < tinsoftProxy.daSuDung)
											{
												tinsoftProxy = item7;
											}
										}
										if (tinsoftProxy.daSuDung != tinsoftProxy.limit_theads_use)
										{
											break;
										}
									}
									if (isStop)
									{
										break;
									}
									if (tinsoftProxy.daSuDung > 0 || tinsoftProxy.ChangeProxy())
									{
										text = tinsoftProxy.proxy;
										if (text == "")
										{
											text = tinsoftProxy.GetProxy();
										}
										TinsoftProxy tinsoftProxy2 = tinsoftProxy;
										tinsoftProxy2.dangSuDung++;
										tinsoftProxy2 = tinsoftProxy;
										tinsoftProxy2.daSuDung++;
										break;
									}
								}
								if (!isStop)
								{
									bool flag6 = true;
									if (!setting_general.GetValueBool("ckbKhongCheckIP"))
									{
										text2 = "(IP: " + text.Split(':')[0] + ") ";
										SetStatusAccount(indexRow, text2 + "Check IP...");
										text3 = MCommon.Common.CheckProxy(text, 0);
										if (text3 == "")
										{
											flag6 = false;
										}
									}
									if (!flag6)
									{
										TinsoftProxy tinsoftProxy2 = tinsoftProxy;
										tinsoftProxy2.dangSuDung--;
										tinsoftProxy2 = tinsoftProxy;
										tinsoftProxy2.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0140;
						case 9:
							text = GetCellAccount(indexRow, "cProxy");
							typeProxy = (text.EndsWith("*1") ? 1 : 0);
							if (text.EndsWith("*0") || text.EndsWith("*1"))
							{
								text = text.Substring(0, text.Length - 2);
							}
							break;
						}
						if (isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						if (!setting_general.GetValueBool("ckbKhongCheckIP"))
						{
							if (setting_general.GetValueInt("ip_iTypeChangeIp") != 7 && setting_general.GetValueInt("ip_iTypeChangeIp") != 8 && setting_general.GetValueInt("ip_iTypeChangeIp") != 10 && setting_general.GetValueInt("ip_iTypeChangeIp") != 11 && setting_general.GetValueInt("ip_iTypeChangeIp") != 12)
							{
								if (text != "")
								{
									text2 = "(IP: " + text.Split(':')[0] + ") ";
								}
								SetStatusAccount(indexRow, text2 + "Check IP...");
								bool flag10 = false;
								int num6 = 0;
								while (true)
								{
									if (num6 < 30)
									{
										MCommon.Common.DelayTime(1.0);
										text3 = MCommon.Common.CheckProxy(text, typeProxy);
										if (!(text3 != ""))
										{
											if (!isStop)
											{
												num6++;
												continue;
											}
											SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
											num3 = 1;
											break;
										}
										flag10 = true;
									}
									if (!flag10)
									{
										if (text != "")
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không thể kết nối proxy!"));
										}
										else
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không có kết nối Internet!"));
										}
										num3 = 1;
										break;
									}
									goto IL_132c;
								}
								break;
							}
							goto IL_132c;
						}
						goto IL_133e;
						IL_132c:
						text2 = "(IP: " + text3 + ") ";
						goto IL_133e;
						IL_133e:
						if (isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
							num3 = 1;
							break;
						}
						num = Environment.TickCount;
						if (isRunSwap)
						{
							device = new Device(pathLD, indexPos.ToString() ?? "");
							if (!Directory.Exists(pathLD + "\\vms\\leidian" + indexPos))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Create LDPlayer..."));
								for (int i = 0; i < 2; i++)
								{
									ADBHelper.AddDevice(pathLD);
									if (Directory.Exists(pathLD + "\\vms\\leidian" + indexPos))
									{
										break;
									}
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Configs LDPlayer..."));
								lock (lock_restoreDevice)
								{
									device.Restore();
								}
								device.ChangeHardwareLDPlayer2();
								device.ChangeFileConfig();
							}
						}
						else
						{
							string text6 = GetCellAccount(indexRow, "cDevice");
							if (text6 == "" || !Directory.Exists(pathLD + "\\vms\\leidian" + text6))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Create LDPlayer, Waiting for turn..."));
								lock (lock_checkDelayCreateDevice)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Create LDPlayer..."));
									List<string> listIndexLDPlayer = ADBHelper.GetListIndexLDPlayer(pathLD);
									ADBHelper.AddDevice(pathLD);
									for (int j = 0; j < 30; j++)
									{
										text6 = ADBHelper.GetListIndexLDPlayer(pathLD).Except(listIndexLDPlayer).First();
										if (text6 != "")
										{
											break;
										}
									}
									if (text6 == "")
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Create LDPlayer fail!"));
										num3 = 1;
										goto IL_51f1;
									}
								}
								device = new Device(pathLD, text6);
								SetCellAccount(indexRow, "cDevice", text6);
								CommonSQL.UpdateFieldToAccount(cellAccount, "device", text6);
								SetStatusAccount(indexRow, text2 + Language.GetValue("Configs LDPlayer..."));
								lock (lock_restoreDevice)
								{
									device.Restore();
								}
								device.ChangeHardwareLDPlayer2();
								device.ChangeFileConfig();
							}
							else
							{
								device = new Device(pathLD, text6 ?? "");
							}
						}
						if (File.Exists(FileHelper.GetPathToCurrentFolder() + "\\device\\" + text5 + "\\config"))
						{
							device.RestoreConfigDevice(text5);
						}
						else
						{
							device.ChangeHardwareLDPlayer2();
						}
						device.ChangeFileConfig();
						SetStatusAccount(indexRow, text2 + Language.GetValue("Chờ đến lượt..."));
						lock (lock_checkDelayLD)
						{
							if (setting_general.GetValueInt("typeOpenDevice") == 0)
							{
								while (true)
								{
									if (isOpeningDevice)
									{
										MCommon.Common.DelayTime(0.5);
										if (!isStop)
										{
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										num3 = 1;
										goto IL_51f1;
									}
									isOpeningDevice = true;
									break;
								}
							}
							else if (checkDelayLD > 0)
							{
								int num7 = rd.Next(setting_general.GetValueInt("nudDelayOpenDeviceFrom", 1), setting_general.GetValueInt("nudDelayOpenDeviceTo", 1) + 1);
								if (num7 > 0)
								{
									int tickCount = Environment.TickCount;
									while ((Environment.TickCount - tickCount) / 1000 - num7 < 0)
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiê\u0301t bi\u0323 sau {time}s...".Replace("{time}", (num7 - (Environment.TickCount - tickCount) / 1000).ToString())));
										device.LoadStatusLD("Open device after {time}s...".Replace("{time}", (num7 - (Environment.TickCount - tickCount) / 1000).ToString()));
										MCommon.Common.DelayTime(0.5);
										if (!isStop)
										{
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										num3 = 1;
										goto IL_51f1;
									}
								}
							}
							else
							{
								checkDelayLD++;
							}
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Open LDPlayer..."));
						device.LoadStatusLD("Open device...");
						device.Open();
						if (device.process == null)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Open LDPlayer fail!"));
							isOpeningDevice = false;
							num3 = 1;
							break;
						}
						if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
						{
							fViewLD.remote.AddLDIntoPanel(device.process.MainWindowHandle, device.IndexDevice, sttTaiKhoan);
						}
						if (!device.CheckOpenedDevice())
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Open LDPlayer fail!"));
							isOpeningDevice = false;
							num3 = 1;
							break;
						}
						isOpeningDevice = false;
						SetStatusAccount(indexRow, text2 + Language.GetValue("Open LDPlayer success!"));
						if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
						{
							fViewLD.remote.ShowPicTurnOffDevice(device.IndexDevice, device.DeviceId);
						}
						device.LoadStatusLD("Open device success...");
						lstDevice.Add(device);
						for (int k = 0; k < 5; k++)
						{
							device.lstPackages = device.GetListPackages();
							if (device.lstPackages.Contains("com.facebook.katana") && device.lstPackages.Contains("com.android.adbkeyboard"))
							{
								break;
							}
							if (!device.lstPackages.Contains("com.facebook.katana"))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Install App Facebook..."), device);
								device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\facebook.apk");
							}
							if (!device.lstPackages.Contains("com.android.adbkeyboard"))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Install App Keyboard..."), device);
								device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\ADBKeyboard.apk");
							}
						}
						if (!device.lstPackages.Contains("com.facebook.katana") || !device.lstPackages.Contains("com.android.adbkeyboard"))
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Error Install App!"), device);
							num3 = 1;
							break;
						}
						if (setting_LDPlayer.GetValueBool("ckbEnableGPS"))
						{
							device.ExecuteCMD("shell settings put secure location_providers_allowed +gps");
						}
						else
						{
							device.ExecuteCMD("shell settings put secure location_providers_allowed -gps");
						}
						device.RemoveProxy();
						if (text != "")
						{
							device.LoadStatusLD("Connect proxy...");
							SetStatusAccount(indexRow, text2 + Language.GetValue("Connect proxy..."));
							if (text.Split(':').Length == 2)
							{
								device.ConnectProxy(text);
							}
							else
							{
								if (!Base.isUseProxyUserPass)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Chưa hô\u0303 trơ\u0323 proxy da\u0323ng user pass!"));
									num3 = 1;
									break;
								}
								for (int l = 0; l < 5; l++)
								{
									device.lstPackages = device.GetListPackages();
									if (device.lstPackages.Contains("com.cell47.College_Proxy"))
									{
										break;
									}
									if (!device.lstPackages.Contains("com.cell47.College_Proxy"))
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Install App Proxy..."));
										device.LoadStatusLD("Install App Proxy...");
										device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\collegeproxy.apk");
									}
								}
								if (!device.lstPackages.Contains("com.cell47.College_Proxy"))
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Error Install App Proxy!"));
									break;
								}
								device.ClearDataApp("com.cell47.College_Proxy");
								SetStatusAccount(indexRow, text2 + Language.GetValue("Connect Proxy..."));
								device.LoadStatusLD("Connect Proxy...");
								if (!ConnectProxy(device, text))
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Error Connect Proxy!"));
									break;
								}
								device.InputKey(Device.KeyEvent.KEYCODE_HOME);
							}
						}
						if (isRunSwap)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Restore data Fb..."), device);
							device.RestoreAccountFacebook(text5);
						}
						flag4 = true;
						SetStatusAccount(indexRow, text2 + Language.GetValue("Share..."), device);
						bool valueBool = setting_InteractGeneral.GetValueBool("ckbShareBaiLenTuong");
						bool valueBool2 = setting_InteractGeneral.GetValueBool("ckbShareBaiLenNhom");
						bool valueBool3 = setting_InteractGeneral.GetValueBool("ckbShareNhomNangCao");
						bool flag11 = false;
						bool flag12 = false;
						bool flag13 = false;
						if (valueBool3)
						{
							flag11 = setting_InteractGeneral.GetValueBool("ckbChiShareNhomKKD");
							flag12 = setting_InteractGeneral.GetValueBool("ckbUuTienShareNhomNhieuThanhVien");
							flag13 = setting_InteractGeneral.GetValueBool("ckbKhongShareTrungNhom");
						}
						int valueInt = setting_InteractGeneral.GetValueInt("typeNhomToShare");
						lstNhomTuNhap = setting_InteractGeneral.GetValueList("lstNhomTuNhap");
						lstNhomTuNhap = MCommon.Common.RemoveEmptyItems(lstNhomTuNhap);
						int valueInt2 = setting_InteractGeneral.GetValueInt("nudCountGroupFrom");
						int valueInt3 = setting_InteractGeneral.GetValueInt("nudCountGroupTo");
						int randomInt = device.GetRandomInt(valueInt2, valueInt3);
						int valueInt4 = setting_InteractGeneral.GetValueInt("nudDelayFrom");
						int valueInt5 = setting_InteractGeneral.GetValueInt("nudDelayTo");
						List<string> valueList = setting_InteractGeneral.GetValueList("txtLinkChiaSe");
						valueList = MCommon.Common.RemoveEmptyItems(valueList);
						int valueInt6 = setting_InteractGeneral.GetValueInt("typeShareLink");
						string text7 = "";
						text7 = ((valueInt6 != 0) ? valueList[indexRow % valueList.Count] : valueList.OrderBy((string t) => Guid.NewGuid()).First());
						int valueInt7 = setting_InteractGeneral.GetValueInt("typeLinkShare");
						bool valueBool4 = setting_InteractGeneral.GetValueBool("ckbVanBan");
						List<string> valueList2 = setting_InteractGeneral.GetValueList("txtNoiDung");
						bool valueBool5 = setting_InteractGeneral.GetValueBool("ckbTuongTacTruocKhiShare");
						int valueInt8 = setting_InteractGeneral.GetValueInt("nudSoLuongFrom");
						int valueInt9 = setting_InteractGeneral.GetValueInt("nudSoLuongTo");
						bool valueBool6 = setting_InteractGeneral.GetValueBool("ckbInteract");
						string value = setting_InteractGeneral.GetValue("typeReaction");
						bool valueBool7 = setting_InteractGeneral.GetValueBool("ckbComment");
						List<string> valueList3 = setting_InteractGeneral.GetValueList("txtComment");
						bool valueBool8 = setting_InteractGeneral.GetValueBool("ckbBinhLuanNhieuLan");
						int valueInt10 = setting_InteractGeneral.GetValueInt("nudBinhLuanNhieuLanDelayFrom");
						int valueInt11 = setting_InteractGeneral.GetValueInt("nudBinhLuanNhieuLanDelayTo");
						int num8 = 0;
						string html = "";
						List<string> list = new List<string>();
						if (valueBool5)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Tương ta\u0301c..."), device);
							List<string> list2 = CloneList(valueList3);
							string text8 = "";
							int randomInt2 = device.GetRandomInt(valueInt8, valueInt9);
							if (valueInt7 == 0)
							{
								try
								{
									while (true)
									{
										num2 = GoToLivestream(device, indexRow, text2, text7);
										if (num2 == 0 || num2 == 3)
										{
											break;
										}
										if (num2 == 2)
										{
											continue;
										}
										int tickCount2 = Environment.TickCount;
										device.DelayTime(2.0);
										while (valueBool6)
										{
											string text9 = "[165,445][195,470]";
											string text10 = "[35,445][65,470]";
											device.SwipeByBounds(text9, text10, 500);
											device.DelayRandom(1.0, 1.5);
											if (device.ClosePopup(ref html))
											{
												continue;
											}
											int typeReaction = Convert.ToInt32(value[device.GetRandomInt(0, value.Length - 1)].ToString());
											device.ClickReactions(typeReaction);
											device.DelayRandom(1.0, 1.5);
											if (device.CheckExistImage("DataClick\\image\\youcantusereaction"))
											{
												device.TapByImageWait("DataClick\\image\\ok");
												device.DelayTime(1.0);
												if (device.CheckExistImage("DataClick\\image\\notnowthank"))
												{
													device.TapByImageWait("DataClick\\image\\notnowthank");
													device.DelayTime(1.0);
													GoToLivestream(device, indexRow, text2, text7);
												}
											}
											device.SwipeByBounds(text10, text9, 500);
											device.DelayRandom(1.0, 1.5);
											break;
										}
										switch (CheckStatusDevice(device, indexRow, text2))
										{
										case 1:
											break;
										default:
											goto end_IL_2232;
										case 0:
										{
											int num9 = 0;
											SetStatusAccount(indexRow, "Đang xem live...");
											while (Environment.TickCount - tickCount2 < randomInt2 * 1000 && device.CheckIsLive())
											{
												if (valueBool7 && (num9 == 0 || valueBool8))
												{
													html = device.GetHtml();
													if (device.CheckExistText("write a comment…", html))
													{
														SetStatusAccount(indexRow, "Đang comment...");
														if (list2.Count == 0)
														{
															list2 = MCommon.Common.CloneList(valueList3);
														}
														text8 = list2[device.GetRandomInt(0, list2.Count - 1)];
														list2.Remove(text8);
														text8 = MCommon.Common.SpinText(text8, rd);
														text8 = GetIconFacebook.ProcessString(text8, rd);
														List<string> listBoundsByText = device.GetListBoundsByText("write a comment…", html);
														if (device.TapByBounds(listBoundsByText[listBoundsByText.Count - 1]))
														{
															device.DelayRandom(1.0, 2.0);
															device.InputTextWithUnicode(text8);
															device.DelayRandom(1.0, 2.0);
															if (device.TapByText("send"))
															{
																device.DelayRandom(3.0, 5.0);
															}
															num9++;
															SetStatusAccount(indexRow, "Đang xem live...");
															device.DelayRandom(valueInt10, valueInt11);
														}
													}
													else
													{
														device.ClosePopup(ref html);
													}
												}
												else
												{
													int num10 = (Environment.TickCount - tickCount2) / 1000;
													SetStatusAccount(indexRow, "Đang xem live, còn " + (randomInt2 - num10) + "s...", device);
													device.DelayTime(1.0);
												}
											}
											goto IL_265e;
										}
										}
									}
									end_IL_2232:;
								}
								catch
								{
									goto IL_265e;
								}
								break;
							}
							try
							{
								device.LoadStatusLD("Open video");
								while (true)
								{
									num2 = GoToVideo(device, indexRow, text2, text7);
									if (num2 == 0 || num2 == 3)
									{
										break;
									}
									if (num2 == 2)
									{
										continue;
									}
									if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
									{
										if (valueBool6)
										{
											device.LoadStatusLD("Interact");
											for (int m = 0; m < 3; m++)
											{
												List<string> listBoundsByImage = device.GetListBoundsByImage("DataClick\\image\\like");
												if (listBoundsByImage.Count <= 0)
												{
													if (device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
													{
														break;
													}
													continue;
												}
												string text11 = listBoundsByImage.LastOrDefault();
												if (!string.IsNullOrEmpty(text11))
												{
													SetStatusAccount(indexRow, "Đang thả cảm xúc video...");
													if (device.TapLongByBounds(text11, "[0,100][320,480]"))
													{
														device.DelayRandom(1.0, 1.5);
														int typeReaction2 = Convert.ToInt32(value[rd.Next(0, value.Length)].ToString() ?? "");
														device.ClickReactions(typeReaction2);
														device.DelayRandom(1.0, 2.0);
													}
												}
												break;
											}
										}
										device.LoadStatusLD("Watch Video");
										int num11 = 0;
										int tickCount3 = Environment.TickCount;
										SetStatusAccount(indexRow, "Đang xem video...");
										while (Environment.TickCount - tickCount3 < randomInt2 * 1000 && device.CheckIsLive())
										{
											if (valueBool7 && (num11 == 0 || valueBool8))
											{
												string boundsByImage = device.GetBoundsByImage("DataClick\\image\\comment");
												if (string.IsNullOrEmpty(boundsByImage))
												{
													continue;
												}
												device.LoadStatusLD("Comment");
												SetStatusAccount(indexRow, "Đang comment...");
												if (list2.Count == 0)
												{
													list2 = MCommon.Common.CloneList(valueList3);
												}
												text8 = list2[device.GetRandomInt(0, list2.Count - 1)];
												list2.Remove(text8);
												text8 = MCommon.Common.SpinText(text8, rd);
												text8 = GetIconFacebook.ProcessString(text8, rd);
												if (device.TapByBounds(boundsByImage, "[0,100][320,480]"))
												{
													device.DelayRandom(1.0, 2.0);
													device.InputTextWithUnicode(text8);
													device.DelayRandom(1.0, 2.0);
													if (device.TapByText("send"))
													{
														device.DelayRandom(3.0, 5.0);
													}
													device.GotoBack(2, 0.3);
													num11++;
													SetStatusAccount(indexRow, "Đang xem video...");
													device.DelayRandom(valueInt10, valueInt11);
												}
											}
											else
											{
												int num12 = (Environment.TickCount - tickCount3) / 1000;
												SetStatusAccount(indexRow, "Đang xem video, còn " + (randomInt2 - num12) + "s...", device);
												device.DelayTime(1.0);
											}
										}
									}
									else
									{
										device.LoadStatusLD("Interact");
										if (valueBool6)
										{
											for (int n = 0; n < 4; n++)
											{
												List<string> list3 = device.GetListBoundsByText("double tap and hold to");
												if (list3.Count == 0)
												{
													list3 = device.GetListBoundsByImage("DataClick\\image\\like");
												}
												if (list3.Count <= 0)
												{
													if (device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
													{
														break;
													}
													continue;
												}
												string text12 = list3.FirstOrDefault();
												if (!string.IsNullOrEmpty(text12))
												{
													SetStatusAccount(indexRow, "Đang thả cảm xúc video...");
													if (device.TapLongByBounds(text12, "[0,100][320,480]"))
													{
														device.DelayRandom(1.0, 1.5);
														int typeReaction3 = Convert.ToInt32(value[rd.Next(0, value.Length)].ToString() ?? "");
														device.ClickReactions(typeReaction3);
														device.DelayRandom(1.0, 2.0);
													}
												}
												break;
											}
										}
										device.LoadStatusLD("Watch Video");
										int num13 = 0;
										int tickCount4 = Environment.TickCount;
										SetStatusAccount(indexRow, "Đang xem video...");
										while (Environment.TickCount - tickCount4 < randomInt2 * 1000 && device.CheckIsLive())
										{
											if (valueBool7 && (num13 == 0 || valueBool8))
											{
												html = device.GetHtml();
												num2 = device.CheckExistTexts(html, 0.0, "write a comment…", "comment button");
												string text13 = "";
												switch (num2)
												{
												case 1:
													text13 = device.GetBoundsByText("write a comment…", html);
													break;
												case 2:
													text13 = device.GetListBoundsByText("comment button").LastOrDefault();
													break;
												default:
													text13 = device.GetBoundsByImage("DataClick\\image\\comment");
													if (!string.IsNullOrEmpty(text13))
													{
														num2 = 2;
													}
													break;
												}
												if (string.IsNullOrEmpty(text13))
												{
													continue;
												}
												device.LoadStatusLD("Comment");
												SetStatusAccount(indexRow, "Đang comment...");
												if (list2.Count == 0)
												{
													list2 = MCommon.Common.CloneList(valueList3);
												}
												text8 = list2[device.GetRandomInt(0, list2.Count - 1)];
												list2.Remove(text8);
												text8 = MCommon.Common.SpinText(text8, rd);
												text8 = GetIconFacebook.ProcessString(text8, rd);
												switch (num2)
												{
												case 1:
												{
													Bitmap bitmap = device.Crop(device.ScreenShoot(), "[44,72][153,96]");
													if (!device.TapByBounds(text13))
													{
														break;
													}
													device.DelayRandom(1.0, 2.0);
													device.InputTextWithUnicode(text8);
													device.DelayRandom(1.0, 2.0);
													if (device.TapByText("send"))
													{
														device.DelayRandom(3.0, 5.0);
													}
													for (int num14 = 0; num14 < 5; num14++)
													{
														if (device.GetBoundsByImage(bitmap, device.ScreenShoot()) != "")
														{
															break;
														}
														if (device.ScrollAndCheckScreenNotChange(200, -1))
														{
															break;
														}
														device.DelayTime(1.0);
													}
													num13++;
													SetStatusAccount(indexRow, "Đang xem video...");
													device.DelayRandom(valueInt10, valueInt11);
													break;
												}
												case 2:
													if (device.TapByBounds(text13, "[0,100][320,480]"))
													{
														device.DelayRandom(1.0, 2.0);
														device.InputTextWithUnicode(text8);
														device.DelayRandom(1.0, 2.0);
														if (device.TapByText("send"))
														{
															device.DelayRandom(3.0, 5.0);
														}
														device.GotoBack(2, 0.3);
														num13++;
														SetStatusAccount(indexRow, "Đang xem video...");
														device.DelayRandom(valueInt10, valueInt11);
													}
													break;
												}
											}
											else
											{
												int num15 = (Environment.TickCount - tickCount4) / 1000;
												SetStatusAccount(indexRow, "Đang xem video, còn " + (randomInt2 - num15) + "s...", device);
												device.DelayTime(1.0);
											}
										}
									}
									goto IL_3082;
								}
							}
							catch
							{
								goto IL_3082;
							}
							break;
						}
						goto IL_3095;
						IL_265e:
						SetStatusAccount(indexRow, "Xem Live xong...");
						goto IL_3095;
						IL_4576:
						if (!valueBool2)
						{
							break;
						}
						List<string> list4;
						if ((valueBool3 || valueInt == 1) && list4.Count == 0)
						{
							SetStatusAccount(indexRow, "No Group!", device);
							num3 = 1;
							break;
						}
						int num16 = 0;
						while (num16 < randomInt + 5 && num8 < randomInt)
						{
							SetStatusAccount(indexRow, "Share groups...", device);
							while ((!valueBool3 && valueInt != 1) || list4.Count != 0)
							{
								device.LoadStatusLD("Open post");
								num2 = GoToVideo(device, indexRow, text2, text7);
								if (num2 == 0 || num2 == 3)
								{
									break;
								}
								if (num2 == 2)
								{
									continue;
								}
								device.LoadStatusLD("Loading2");
								bool flag14 = false;
								int num17 = 0;
								while (true)
								{
									if (num17 < 10)
									{
										if (!device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
										{
											if (!(device.GetActivity() != "com.facebook.katana/com.facebook.deeplinking.activity.StoryDeepLinkLoadingActivity"))
											{
												if (!device.CheckExistText("\"can't post"))
												{
													switch (CheckStatusDevice(device, indexRow, text2))
													{
													case 0:
														goto IL_46ed;
													case 1:
														break;
													default:
														goto end_IL_0140;
													}
													break;
												}
											}
											else
											{
												flag14 = true;
											}
										}
										else
										{
											flag14 = true;
										}
									}
									if (flag14)
									{
										device.LoadStatusLD("Find share");
										bool flag15 = false;
										int num18 = 0;
										while (true)
										{
											if (num18 >= 5)
											{
												goto IL_48ad;
											}
											if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
											{
												if (!device.TapByImage("DataClick\\image\\share"))
												{
													if (!device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
													{
														device.DelayTime(1.0);
														goto IL_4875;
													}
												}
												else
												{
													flag15 = true;
												}
												goto IL_48ad;
											}
											num2 = CheckStatusDevice(device, indexRow, text2);
											if (num2 == 1)
											{
												break;
											}
											if (num2 == 0)
											{
												string html2 = "";
												if (!device.TapByImage("DataClick\\image\\share") && !device.TapByText("\"share button", html2))
												{
													device.ClosePopup(html2);
													if (!device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
													{
														device.DelayTime(1.0);
														goto IL_4875;
													}
												}
												else
												{
													flag15 = true;
												}
												goto IL_48ad;
											}
											goto end_IL_0140;
											IL_4875:
											num18++;
											continue;
											IL_48ad:
											if (flag15)
											{
												goto IL_48bd;
											}
											goto IL_515e;
										}
										break;
									}
									goto IL_5169;
									IL_4d1c:
									int num19 = 0;
									string text14;
									while (true)
									{
										if (num19 < 5)
										{
											List<string> list5 = new List<string>();
											for (int num20 = 0; num20 < 2; num20++)
											{
												html = device.GetHtml();
												list5 = device.GetListText(html, 2);
												list5.Remove("back");
												if (list5.Count != 0 || (!valueBool3 && valueInt != 1) || num20 >= 1)
												{
													break;
												}
												device.InputKeyBackspace(5);
												device.DelayTime(2.0);
											}
											if (list5.Count != 0)
											{
												if (valueBool3 || valueInt == 1)
												{
													text14 = ((!list5.Contains(text14.ToLower())) ? list5[0] : text14.ToLower());
												}
												else
												{
													text14 = (from t in list5.Except(list)
														orderby Guid.NewGuid()
														select t).FirstOrDefault();
													if (string.IsNullOrEmpty(text14))
													{
														device.ScrollAndCheckScreenNotChange(device.GetRandomInt(400, 500));
														num19++;
														continue;
													}
												}
											}
											else if (valueBool3 || valueInt == 1)
											{
												break;
											}
										}
										if (!string.IsNullOrEmpty(text14))
										{
											goto IL_4f16;
										}
										goto end_IL_0140;
									}
									break;
									IL_4f16:
									device.DelayTime(2.0);
									if (!device.TapByText("content-desc=\"" + text14, html))
									{
										goto IL_5169;
									}
									list.Add(text14);
									device.DelayTime(1.0);
									string text15 = "";
									for (int num21 = 0; num21 < 10; num21++)
									{
										html = device.GetHtml();
										text15 = device.GetBoundsByText("\"post", html);
										if (text15 == "")
										{
											text15 = device.GetBoundsByImage("DataClick\\image\\dang");
										}
										if (text15 != "")
										{
											break;
										}
										device.DelayTime(1.0);
									}
									if (!(text15 != ""))
									{
										goto IL_5169;
									}
									if (valueBool4 && valueList2.Count > 0 && (device.TapByImage("DataClick\\image\\banvietgidi") || device.TapByText("\"write something…\"", html)))
									{
										string text16 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
										text16 = MCommon.Common.SpinText(text16, rd);
										text16 = GetIconFacebook.ProcessString(text16, rd);
										device.InputTextWithUnicode(text16);
										device.DelayTime(1.0);
									}
									if (!device.TapByBounds(text15))
									{
										goto IL_5169;
									}
									num8++;
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đang") + $" share post ({num8}/{randomInt})...");
									device.LoadStatusLD("Posted");
									device.DelayRandom(valueInt4, valueInt5);
									if (!device.CheckExistImage("DataClick\\image\\cantpost"))
									{
										goto IL_5169;
									}
									goto end_IL_0140;
									IL_48bd:
									device.LoadStatusLD("Find share group");
									for (int num22 = 0; num22 < 2; num22++)
									{
										if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
										{
											bool flag16 = false;
											int num23 = 0;
											while (num23 < 5)
											{
												if (device.TapByImageWait("DataClick\\image\\sharegroup", 3))
												{
													flag16 = true;
													break;
												}
												if (!(device.GetActivity() == "Application"))
												{
													device.DelayTime(1.0);
													num23++;
													continue;
												}
												goto end_IL_0140;
											}
											if (flag16)
											{
												break;
											}
											if (num22 == 0)
											{
												string bounds = "[220,415][260,455]";
												string bounds2 = "[35,415][65,455]";
												device.SwipeByBounds(bounds, bounds2);
											}
											else if (num8 <= 0)
											{
												break;
											}
											continue;
										}
										bool flag17 = false;
										for (int num24 = 0; num24 < 5; device.DelayTime(1.0), num24++)
										{
											html = "";
											if (device.TapByImageWait("DataClick\\image\\sharegroup", 3) || device.TapByText("share to a group", html))
											{
												flag17 = true;
												break;
											}
											if (!(device.GetActivity() == "Application"))
											{
												switch (CheckStatusDevice(device, indexRow, text2))
												{
												case 0:
													continue;
												case 1:
													break;
												default:
													goto end_IL_0140;
												}
												goto IL_4eca;
											}
											goto end_IL_0140;
										}
										if (flag17)
										{
											break;
										}
										if (num22 == 0)
										{
											string bounds3 = "[220,415][260,455]";
											string bounds4 = "[35,415][65,455]";
											device.SwipeByBounds(bounds3, bounds4);
										}
										else if (num8 <= 0)
										{
											break;
										}
									}
									bool flag18 = false;
									for (int num25 = 0; num25 < 10; num25++)
									{
										if (!(device.GetActivity() == "com.facebook.katana/com.facebook.composer.groups.selector.GroupSelectorActivity"))
										{
											device.DelayTime(1.0);
											continue;
										}
										device.DelayTime(1.0);
										for (int num26 = 0; num26 < 10; num26++)
										{
											if (device.CheckExistXpath("//*[@class='android.widget.progressbar']"))
											{
												device.DelayTime(1.0);
												continue;
											}
											flag18 = true;
											break;
										}
										break;
									}
									if (!flag18)
									{
										goto IL_5169;
									}
									text14 = "";
									if (!valueBool3 && valueInt != 1)
									{
										goto IL_4d1c;
									}
									while (list4.Count != 0)
									{
										string item = list4[0].Split('|')[0];
										text14 = list4[0].Split('|')[1];
										list4.RemoveAt(0);
										if (flag13)
										{
											lock (lstIdGroupShared)
											{
												if (lstIdGroupShared.Contains(item))
												{
													continue;
												}
												lstIdGroupShared.Add(item);
												goto IL_4ce1;
											}
										}
										goto IL_4ce1;
										IL_4ce1:
										device.TapByText("\"search\"");
										device.InputTextWithUnicode(text14);
										device.DelayTime(2.0);
										goto IL_4d1c;
									}
									goto end_IL_0140;
									IL_5169:
									num16++;
									goto IL_517b;
									IL_46ed:
									device.DelayTime(2.0);
									num17++;
									continue;
									IL_515e:
									if (num8 > 0)
									{
										goto IL_5169;
									}
									goto end_IL_0140;
								}
								IL_4eca:;
							}
							break;
							IL_517b:;
						}
						break;
						IL_3095:
						list4 = new List<string>();
						if (valueBool2 && (valueBool3 || valueInt == 1))
						{
							int num27 = 0;
							while (num27 < 2)
							{
								if (num27 != 1)
								{
									goto IL_34a5;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Mở app Facebook..."), device);
								string text17 = device.OpenFacebookAndCheckStatusLogin();
								if (!(text17.Split('|')[0] == "0"))
								{
									if (!(text17.Split('|')[0] == "2"))
									{
										num2 = ((!(text17.Split('|')[1] == "0") && !(text17.Split('|')[1] == "11")) ? Convert.ToInt32(text17.Split('|')[1]) : LoginFacebook(device, indexRow, text2));
										switch (num2)
										{
										case 0:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhập thất bại!"));
											break;
										case 1:
											SetInfoAccount(cellAccount, indexRow, "Live");
											break;
										case 2:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Checkpoint!"));
											SetInfoAccount(cellAccount, indexRow, "Checkpoint!");
											break;
										case 3:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không có 2fa!"));
											break;
										case 4:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Tài khoản không đúng!"));
											break;
										case 5:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Mật khẩu không đúng!"));
											SetInfoAccount(cellAccount, indexRow, "Changed pass!");
											break;
										case 6:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Mã 2FA không đúng!"));
											break;
										case 7:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi kết nối Internet!"));
											break;
										case 8:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Tài khoản chưa xác minh!"));
											break;
										case 9:
										{
											device.CloseAppFacebook();
											for (int num28 = 0; num28 < 10; num28++)
											{
												text17 = device.OpenFacebookAndCheckStatusLogin();
												if (!(text17.Split('|')[1] == "1"))
												{
													device.DelayTime(1.0);
													continue;
												}
												num2 = 1;
												break;
											}
											if (num2 != 1)
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Facebook bắt add sđt!"));
											}
											break;
										}
										case 10:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không thê\u0309 login!"));
											break;
										}
										if (num2 == 1)
										{
											goto IL_34a5;
										}
										num3 = 1;
										device.CheckDevice("", "", "log\\loginfail" + num2);
									}
									else
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi đăng nhập swap!"));
										num3 = 1;
									}
								}
								else
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở app Facebook!"));
									num3 = 1;
								}
								goto end_IL_0140;
								IL_34a5:
								SetStatusAccount(indexRow, text2 + Language.GetValue("Scan group..."), device);
								cellAccount4 = device.GetTokenCookie().Split('|')[1];
								if (!(cellAccount4.Trim() == ""))
								{
									List<string> listGroup = CommonRequest.GetListGroup(cellAccount4, text, typeProxy, flag11);
									list4 = ((!flag11) ? listGroup.Select((string x) => x).ToList() : listGroup.Where((string x) => x.Split('|')[3].ToLower() == "false").ToList());
									if (flag12)
									{
										list4.Sort((string x, string y) => int.Parse(y.Split('|')[2]).CompareTo(int.Parse(x.Split('|')[2])));
									}
									else
									{
										list4 = list4.OrderBy((string t) => Guid.NewGuid()).ToList();
									}
									if (valueInt == 1)
									{
										listGroup = MCommon.Common.CloneList(list4);
										list4 = listGroup.Where((string x) => lstNhomTuNhap.Contains(x.Split('|')[0])).ToList();
									}
									if (list4.Count > 0)
									{
										break;
									}
								}
								num27++;
							}
						}
						if (valueInt7 == 0)
						{
							while (true)
							{
								IL_41b9:
								device.LoadStatusLD("Open livestream...");
								num2 = GoToLivestream(device, indexRow, text2, text7);
								if (num2 == 0 || num2 == 3)
								{
									break;
								}
								switch (num2)
								{
								case 2:
									continue;
								case 4:
									SetStatusAccount(indexRow, "Checkpoint!", device);
									num3 = 1;
									goto end_IL_0140;
								}
								if (valueBool)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Share Wall..."));
									bool flag19 = false;
									int num29 = 0;
									do
									{
										flag19 = false;
										num29++;
										if (num29 != 1)
										{
											if (num29 == 2)
											{
												for (int num30 = 0; num30 < 10; device.DelayTime(2.0), num30++)
												{
													if (!device.TapByImage("DataClick\\image\\chiase"))
													{
														continue;
													}
													device.DelayTime(1.0);
													if (device.CheckExistImage("DataClick\\image\\chiase"))
													{
														switch (CheckStatusDevice(device, indexRow, text2))
														{
														default:
															goto end_IL_0140;
														case 0:
															continue;
														case 1:
															break;
														}
														goto IL_41b9;
													}
													if (!device.TapByImageWait("DataClick\\image\\vietbai"))
													{
														device.GotoBack();
														continue;
													}
													flag19 = true;
													break;
												}
												continue;
											}
											if (num29 == 3)
											{
												if (valueBool4 && valueList2.Count > 0 && (device.TapByImage("DataClick\\image\\banvietgidi") || device.TapByText("\"write something…\"")))
												{
													string text18 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
													text18 = MCommon.Common.SpinText(text18, rd);
													text18 = GetIconFacebook.ProcessString(text18, rd);
													device.InputTextWithUnicode(text18);
													device.DelayTime(1.0);
												}
												if (device.TapByImageWait("DataClick\\image\\dang"))
												{
													flag19 = true;
													continue;
												}
												string text19 = device.GetListBoundsByText("\"post\"").LastOrDefault();
												if (!string.IsNullOrEmpty(text19))
												{
													flag19 = true;
													device.TapByBounds(text19);
												}
												continue;
											}
											flag19 = true;
											break;
										}
										for (int num31 = 0; num31 < 30; num31++)
										{
											if (device.CheckExistImage("DataClick\\image\\theodoi"))
											{
												device.GotoBack();
											}
											else
											{
												if (device.CheckExistImage("DataClick\\image\\chiase"))
												{
													flag19 = true;
													break;
												}
												if (!device.ClosePopup())
												{
													device.SwipeByBounds("[35,445][65,470]", "[165,445][195,470]", 500);
												}
											}
											device.DelayTime(1.0);
										}
									}
									while (flag19);
								}
								if (valueBool2)
								{
									if ((!valueBool3 && valueInt != 1) || list4.Count != 0)
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Share Groups..."));
										bool flag20 = false;
										int num32 = 0;
										do
										{
											flag20 = false;
											num32++;
											if (num32 != 1)
											{
												if (num32 == 2)
												{
													for (int num33 = 0; num33 < 10; device.DelayTime(2.0), num33++)
													{
														if (!device.TapByImage("DataClick\\image\\chiase"))
														{
															continue;
														}
														device.DelayTime(1.0);
														if (device.CheckExistImage("DataClick\\image\\chiase"))
														{
															switch (CheckStatusDevice(device, indexRow, text2))
															{
															default:
																goto end_IL_0140;
															case 0:
																continue;
															case 1:
																break;
															}
															goto IL_41b9;
														}
														if (!device.TapByImageWait("DataClick\\image\\chiaselennhom"))
														{
															device.GotoBack();
															continue;
														}
														flag20 = true;
														break;
													}
													continue;
												}
												if (num32 == 3)
												{
													if (valueBool4 && valueList2.Count > 0)
													{
														for (int num34 = 0; num34 < 10; num34++)
														{
															if (!device.TapByImage("DataClick\\image\\viettinnhan"))
															{
																html = device.GetHtml();
																switch (device.CheckExistTexts(ref html, 0.0, "write a message…", "\"close\""))
																{
																default:
																	continue;
																case 2:
																	device.TapByText("\"close\"", html);
																	num32 = 0;
																	break;
																case 1:
																{
																	device.TapByText("write a message…", html);
																	string text20 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
																	text20 = MCommon.Common.SpinText(text20, rd);
																	text20 = GetIconFacebook.ProcessString(text20, rd);
																	device.InputTextWithUnicode(text20);
																	device.DelayTime(1.0);
																	break;
																}
																}
															}
															else
															{
																string text21 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
																text21 = MCommon.Common.SpinText(text21, rd);
																text21 = GetIconFacebook.ProcessString(text21, rd);
																device.InputTextWithUnicode(text21);
																device.DelayTime(1.0);
															}
															break;
														}
													}
													int num35 = 0;
													while (num8 < randomInt)
													{
														num35++;
														if (num35 % 4 == 0)
														{
															switch (CheckStatusDevice(device, indexRow, text2))
															{
															case 0:
																break;
															case 1:
																goto IL_41b9;
															default:
																goto end_IL_0140;
															}
														}
														if (!valueBool3 && valueInt != 1)
														{
															goto IL_3fa2;
														}
														while (list4.Count != 0)
														{
															string item2 = list4[0].Split('|')[0];
															string text22 = list4[0].Split('|')[1];
															list4.RemoveAt(0);
															if (flag13)
															{
																lock (lstIdGroupShared)
																{
																	if (lstIdGroupShared.Contains(item2))
																	{
																		continue;
																	}
																	lstIdGroupShared.Add(item2);
																	goto IL_3f67;
																}
															}
															goto IL_3f67;
															IL_3f67:
															device.ClearText("search");
															device.InputTextWithUnicode(text22);
															device.DelayTime(2.0);
															goto IL_3fa2;
														}
														goto end_IL_0140;
														IL_3fa2:
														if (!device.TapByImage("DataClick\\image\\chiasexanh"))
														{
															if (!valueBool3 && valueInt != 1 && device.ScrollAndCheckScreenNotChange(rd.Next(1000, 1100), 1, "[115,429][210,460]", "[154,292][246,312]", "[27,253][296,454]"))
															{
																break;
															}
															continue;
														}
														num8++;
														SetStatusAccount(indexRow, text2 + Language.GetValue($"Chia sẻ lên nhóm {num8}/{randomInt}..."));
														if (num8 >= randomInt)
														{
															break;
														}
														device.DelayRandom(valueInt4, valueInt5);
														if (device.CheckExistImage("DataClick\\image\\posted") || device.CheckExistText("posted"))
														{
															continue;
														}
														goto end_IL_0140;
													}
													continue;
												}
												flag20 = true;
												break;
											}
											for (int num36 = 0; num36 < 30; num36++)
											{
												if (device.CheckExistImage("DataClick\\image\\theodoi"))
												{
													device.GotoBack();
												}
												else
												{
													if (device.CheckExistImage("DataClick\\image\\chiase"))
													{
														flag20 = true;
														break;
													}
													if (!device.ClosePopup())
													{
														device.SwipeByBounds("[35,445][65,470]", "[165,445][195,470]", 500);
													}
												}
												device.DelayTime(1.0);
											}
										}
										while (flag20);
									}
									else
									{
										SetStatusAccount(indexRow, "No Group!", device);
										num3 = 1;
									}
								}
								goto end_IL_0140;
							}
							break;
						}
						if (valueBool)
						{
							SetStatusAccount(indexRow, "Share tươ\u0300ng...", device);
							while (true)
							{
								device.LoadStatusLD("Open post");
								num2 = GoToVideo(device, indexRow, text2, text7);
								if (num2 == 0 || num2 == 3)
								{
									break;
								}
								if (num2 == 2)
								{
									continue;
								}
								bool flag21 = false;
								for (int num37 = 0; num37 < 5; num37++)
								{
									string html3 = "";
									if (!device.TapByImage("DataClick\\image\\share") && !device.TapByText("\"share button", html3))
									{
										device.ClosePopup(ref html3);
										if (device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
										{
											break;
										}
										device.DelayTime(1.0);
										continue;
									}
									flag21 = true;
									break;
								}
								if (!flag21)
								{
									break;
								}
								if (device.TapByText("write post"))
								{
									html = device.GetHtml();
									if (!device.CheckExistText("choose privacy public", html) && device.TapByText("choose privacy", html))
									{
										if (device.TapByText("public", "", 5))
										{
											device.DelayRandom(1.0, 1.5);
											device.TapByText("\"done\"");
											device.DelayRandom(1.0, 1.5);
										}
										else
										{
											device.TapByText("back");
											device.DelayRandom(1.0, 1.5);
										}
										html = device.GetHtml();
									}
									if (device.CheckExistText("\"post", ref html, 8.0))
									{
										if (valueBool4 && valueList2.Count > 0 && device.CheckExistText("write something…", html))
										{
											device.TapByText("write something…", html);
											string text23 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
											text23 = MCommon.Common.SpinText(text23, rd);
											text23 = GetIconFacebook.ProcessString(text23, rd);
											device.InputTextWithUnicode(text23);
											device.DelayTime(1.0);
										}
										device.TapByText("\"post", html);
									}
								}
								goto IL_4576;
							}
							break;
						}
						goto IL_4576;
						IL_3082:
						SetStatusAccount(indexRow, "Xem video xong...");
						goto IL_3095;
					}
				}
				end_IL_0140:;
			}
			catch (Exception ex)
			{
				device.ExportError(ex, "Lô\u0303i không xa\u0301c đi\u0323nh!");
				SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				num3 = 1;
				MCommon.Common.ExportError(null, ex, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
			}
			goto IL_51f1;
			IL_51f1:
			string text24 = "";
			if (num3 == 1)
			{
				text24 = GetStatusAccount(indexRow);
			}
			else if (CheckIsUidFacebook(text5) && CommonRequest.CheckLiveWall(text5).StartsWith("0|"))
			{
				SetInfoAccount(cellAccount, indexRow, "Die");
				text24 = Language.GetValue("Tài khoản Die!");
			}
			try
			{
				int num38 = rd.Next(setting_general.GetValueInt("nudDelayCloseDeviceFrom"), setting_general.GetValueInt("nudDelayCloseDeviceTo") + 1);
				if (num38 > 0)
				{
					int tickCount5 = Environment.TickCount;
					while ((Environment.TickCount - tickCount5) / 1000 - num38 < 0)
					{
						if (!isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đóng LD sau {time}s...").Replace("{time}", (num38 - (Environment.TickCount - tickCount5) / 1000).ToString()));
							MCommon.Common.DelayTime(0.5);
							continue;
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
						break;
					}
				}
				if (flag4)
				{
					device.BackupConfigDevice(text5);
					if (isRunSwap && device.CheckIsLive())
					{
						SetStatusAccount(indexRow, text2 + Language.GetValue("Backup data Fb..."), device);
						device.BackupAccountFacebook(text5, cellAccount3, cellAccount2);
						CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
						SetCellAccount(indexRow, "cProfile", "Yes");
						device.ClearDataAppFacebook();
					}
				}
				device.CloseAppFacebook();
				if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
				{
					fViewLD.remote.RemovePanelDevice(device.IndexDevice);
				}
				else
				{
					device.Close();
				}
			}
			catch
			{
			}
			string text25 = text24;
			string text26 = text25;
			if (!(text26 == ""))
			{
				SetStatusAccount(indexRow, text2 + text24 + (flag3 ? "- Lô\u0303i mơ\u0309 link" : "") + (flag2 ? "- Facebook blocked" : ""));
			}
			else
			{
				SetStatusAccount(indexRow, text2 + Language.GetValue("Đã tương tác xong!") + (flag3 ? "- Lô\u0303i mơ\u0309 link" : "") + (flag2 ? "- Facebook blocked" : "") + " [" + MCommon.Common.ConvertSecondsToTime((Environment.TickCount - num) / 1000) + "(s)]");
				SetCellAccount(indexRow, "cInteractEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				CommonSQL.UpdateFieldToAccount(cellAccount, "interactEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				SetInfoAccount(cellAccount, indexRow, "Live");
			}
			if (flag && Directory.Exists("profile\\" + text4) && !string.IsNullOrEmpty(text4))
			{
				string text27 = "profile\\" + text4;
				string pathTo = "profile\\" + text5;
				if (!MCommon.Common.MoveFolder(text27, pathTo) && MCommon.Common.CopyFolder(text27, pathTo))
				{
					MCommon.Common.DeleteFolder(text27);
				}
			}
			lock (lock_FinishProxy)
			{
				switch (setting_general.GetValueInt("ip_iTypeChangeIp"))
				{
				case 7:
					tinsoftProxy?.DecrementDangSuDung();
					break;
				case 8:
					xproxyProxy?.DecrementDangSuDung();
					break;
				case 10:
					tMProxy?.DecrementDangSuDung();
					break;
				case 11:
					proxyWeb?.DecrementDangSuDung();
					break;
				case 12:
					shopLike?.DecrementDangSuDung();
					break;
				case 9:
					break;
				}
			}
		}

		private int GoToLivestream(Device device, int indexRow, string statusProxy, string linkLivestream)
		{
			int result = 0;
			string text = "";
			int num = 0;
			if (device.OpenLink(linkLivestream))
			{
				for (int i = 0; i < 10; i++)
				{
					if (!device.CheckExistImage("DataClick\\image\\chiase"))
					{
						if (!device.TapByImageWait("DataClick\\image\\livestream"))
						{
							if (device.CheckExistImage("DataClick\\image\\theodoi"))
							{
								device.GotoBack();
							}
							else
							{
								text = device.GetHtml();
								if (device.CheckExistText("\"ok\"", text))
								{
									device.TapByText("\"ok\"", text);
								}
								else if (device.CheckExistText("\"video\"", text))
								{
									device.TapByText("\"video\"", text);
								}
								else if (device.CheckExistText("viewers\"", text))
								{
									device.TapByText("viewers\"", text);
								}
								else if (device.CheckExistText("\"toggle video sound", text))
								{
									string boundsByText = device.GetBoundsByText("\"toggle video sound", text);
									if (boundsByText != "")
									{
										Point locationFromBounds = device.GetLocationFromBounds(boundsByText);
										device.Tap(locationFromBounds.X - 120, locationFromBounds.Y);
									}
								}
								else if (device.CheckExistText("write a comment…", text))
								{
									string boundsByText2 = device.GetBoundsByText("write a comment…", text);
									if (boundsByText2 != "")
									{
										Point locationFromBounds2 = device.GetLocationFromBounds(boundsByText2);
										device.Tap(locationFromBounds2.X, locationFromBounds2.Y - 50);
									}
								}
								else
								{
									device.ClosePopup(text);
								}
							}
						}
						num = CheckStatusDevice(device, indexRow, statusProxy, isAllowLogin: true);
						if (num != 2)
						{
							if (num != 1)
							{
								if (num != 0 && num != -3)
								{
									result = 3;
									break;
								}
								continue;
							}
							result = 2;
							break;
						}
						result = 4;
						break;
					}
					result = 1;
					break;
				}
			}
			return result;
		}

		private int GoToVideo(Device device, int indexRow, string statusProxy, string linkVideo)
		{
			int result = 0;
			string text = "";
			int num = 0;
			int num2 = 0;
			if (device.OpenLink(linkVideo))
			{
				device.LoadStatusLD("Loading1");
				for (int i = 0; i < 30; i++)
				{
					if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.activity.DeprecatedFullscreenVideoPlayerActivity"))
					{
						num2++;
						if (num2 == 5)
						{
							break;
						}
						device.CloseAppFacebook();
						if (!device.OpenLink(linkVideo))
						{
							break;
						}
					}
					else
					{
						if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
						{
							result = 1;
							break;
						}
						if (device.CheckExistImage("DataClick\\image\\share"))
						{
							result = 1;
							break;
						}
						text = device.GetHtml();
						if (device.CheckExistText("\"ok\"", text))
						{
							device.TapByText("\"ok\"", text);
						}
						else
						{
							if (device.CheckExistTexts(text, 0.0, "\"share", "\"video\"", "\"toggle video sound", "\"write a") > 0)
							{
								result = 1;
								break;
							}
							device.ClosePopup(text);
						}
					}
					num = CheckStatusDevice(device, indexRow, statusProxy, isAllowLogin: true);
					if (num != 2)
					{
						if (num != 1)
						{
							if (num != 0 && num != -3)
							{
								result = 3;
								break;
							}
							continue;
						}
						result = 2;
						break;
					}
					result = 4;
					break;
				}
			}
			return result;
		}

		private int HDNghiGiaiLao(int indexRow, string statusProxy, int delayFrom, int delayTo, string tenHanhDong)
		{
			try
			{
				int num = rd.Next(delayTo, delayTo + 1);
				if (num > 0)
				{
					int tickCount = Environment.TickCount;
					while ((Environment.TickCount - tickCount) / 1000 - num < 0 && !isStop)
					{
						SetStatusAccount(indexRow, statusProxy + string.Format(Language.GetValue("Đang {0}, đợi {{time}}s..."), tenHanhDong).Replace("{time}", (num - (Environment.TickCount - tickCount) / 1000).ToString()));
						MCommon.Common.DelayTime(0.5);
					}
				}
				return 1;
			}
			catch
			{
			}
			return 0;
		}

		private void ScreenCaptureError(Chrome chrome, string uid, int type)
		{
			try
			{
				if (chrome != null)
				{
					string text = Application.StartupPath + "\\log_capture";
					switch (type)
					{
					case 0:
						text += "\\checkpoint";
						break;
					case 1:
						text += "\\loginfail";
						break;
					case 2:
						text += "\\disconnect";
						break;
					}
					MCommon.Common.CreateFolder(text);
					chrome.ScreenCapture(text, uid);
					File.WriteAllText(text + "\\" + uid + ".txt", chrome.GetURL());
					File.WriteAllText(text + "\\" + uid + ".html", chrome.GetPageSource());
				}
			}
			catch
			{
			}
		}

		private bool LinkToInstagram(Chrome chrome)
		{
			bool flag = false;
			try
			{
				chrome.GotoURL("https://www.instagram.com/");
				DelayThaoTacNho();
				switch (chrome.CheckExistElements(10.0, "[href=\"/accounts/activity/\"]", "form button"))
				{
				case 2:
					chrome.Click(4, "form button", 1);
					switch (chrome.CheckExistElements(10.0, "[href=\"/accounts/activity/\"]", "[name=\"__CONFIRM__\"]", "[name=\"username\"]"))
					{
					case 2:
					{
						chrome.DelayTime(1.0);
						chrome.Click(2, "__CONFIRM__");
						string text = "minsoft" + MCommon.Common.CreateRandomString(3, rd) + MCommon.Common.CreateRandomString(5, rd);
						chrome.SendKeys(2, "username", text);
						MCommon.Common.DelayTime(1.0);
						string text2 = "Minsoft_" + MCommon.Common.CreateRandomString(6, rd);
						chrome.SendKeys(2, "password", text2);
						DelayThaoTacNho();
						chrome.Click(4, "form button[type=\"submit\"]");
						DelayThaoTacNho();
						if (chrome.CheckExistElement("[href=\"/accounts/activity/\"]", 10.0) == 1)
						{
							flag = true;
						}
						if (!flag && chrome.CheckExistElement("[type=\"button\"]") == 1)
						{
							flag = true;
						}
						if (flag)
						{
							lock (lock_fileig)
							{
								File.AppendAllText("account_ig.txt", text + "|" + text2 + Environment.NewLine);
								return flag;
							}
						}
						return flag;
					}
					default:
						return flag;
					case 1:
					case 3:
						return flag;
					}
				case 1:
					flag = true;
					return flag;
				default:
					return flag;
				}
			}
			catch
			{
				return flag;
			}
		}

		private void Logout(Chrome chrome)
		{
			try
			{
				CommonChrome.GoToHome(chrome);
				if (chrome.CheckExistElement("#bookmarks_jewel a", 3.0) != 1)
				{
					return;
				}
				DelayThaoTacNho();
				chrome.Click(4, "#bookmarks_jewel a");
				DelayThaoTacNho(1);
				if (chrome.CheckExistElementv2("document.querySelector('[data-sigil=\"logout\"]')", 3.0) == 1)
				{
					chrome.ScrollSmooth("document.querySelector('[data-sigil=\"logout\"]')");
					DelayThaoTacNho(1);
					chrome.Click(4, "[data-sigil=\"logout\"]");
					DelayThaoTacNho();
					if (chrome.CheckExistElement("[name=\"m_savepass\"]", 3.0) == 1)
					{
						chrome.Click(2, "m_savepass");
						DelayThaoTacNho();
					}
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(chrome, ex, "Logout error");
			}
		}

		private bool LogoutOldDevice(Chrome chrome)
		{
			bool result = false;
			try
			{
				chrome.GotoURL("https://m.facebook.com/settings/security_login/sessions/log_out_all/confirm/");
				chrome.DelayTime(1.0);
				string text = "";
				for (int i = 0; i < 10; i++)
				{
					text = chrome.ExecuteScript("return document.documentElement.innerHTML.match(new RegExp('/security/settings/sessions/log_out_all/(.*?)\"'))[0].replace('\"','').split('amp;').join('');").ToString();
					if (!(text != ""))
					{
						chrome.DelayTime(1.0);
						continue;
					}
					chrome.GotoURL("https://m.facebook.com" + text);
					result = true;
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		private bool AllowFollow(Chrome chrome)
		{
			bool result = false;
			try
			{
				chrome.GotoURL("https://m.facebook.com/settings/subscribe/");
				chrome.DelayTime(1.0);
				if (chrome.CheckExistElement("[data-sigil=\"audience-options-list\"]>label", 10.0) == 1)
				{
					if (!Convert.ToBoolean(chrome.ExecuteScript("return document.querySelector('[data-sigil=\"audience-options-list\"]>label').getAttribute('data-sigil').includes('selected')+''")))
					{
						if (chrome.Click(4, "[data-sigil=\"audience-options-list\"]>label") == 1)
						{
							result = true;
							return result;
						}
						return result;
					}
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		private bool CheckStringIsExistInList(string s, List<string> lst)
		{
			bool result = false;
			try
			{
				for (int i = 0; i < lst.Count; i++)
				{
					if (MCommon.Common.ConvertToUnSign(s).ToLower().Contains(MCommon.Common.ConvertToUnSign(lst[i]).ToLower()))
					{
						result = true;
						return result;
					}
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		public int HDKetBanThanhVienNhom(int indexRow, string statusProxy, Chrome chrome, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, List<string> lstUid, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			try
			{
				num2 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
				num4 = ((num2 >= 100) ? 10 : 5);
				string text = "";
				while (lstUid.Count > 0)
				{
					text = lstUid[rd.Next(0, lstUid.Count)];
					lstUid.Remove(text);
					int num6;
					do
					{
						chrome.GotoURL("https://m.facebook.com/browse/group/members/?id=" + text + "&start=0&listType=list_nonfriend_nonadmin");
						DelayThaoTacNho();
						num6 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
					}
					while (num6 == 1);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num6))
					{
						if (chrome.CheckExistElement("[data-sigil=\"m-add-friend-flyout\"]") != 1)
						{
							continue;
						}
						num5 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"m-add-friend-flyout\"]').length+''"));
						int num7 = 0;
						while (num7 < num5)
						{
							chrome.ScrollSmooth("document.querySelectorAll('[data-sigil=\"m-add-friend-flyout\"]')[" + num7 + "]");
							DelayThaoTacNho();
							chrome.Click(4, "[data-sigil=\"m-add-friend-flyout\"] a", num7);
							DelayThaoTacNho();
							num3 = (CommonChrome.SkipNotifyWhenAddFriend(chrome) ? (num3 + 1) : 0);
							if (num3 < num4)
							{
								num++;
								SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
								if (num < num2)
								{
									chrome.DelayTime(rd.Next(nudDelayFrom, nudDelayTo + 1));
									num7++;
									continue;
								}
							}
							goto end_IL_005b;
						}
						continue;
					}
					return -1;
				}
				end_IL_005b:;
			}
			catch
			{
			}
			return num;
		}

		public List<string> GetNameFriend(string token, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				RequestXNet requestXNet = new RequestXNet("", "", proxy, typeProxy);
				string json = requestXNet.RequestGet("https://graph.facebook.com/v3.0/me/friends?access_token=" + token + "&limit=5000&fields=id,name");
				JObject jObject = JObject.Parse(json);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
				{
					list.Add(item["name"]!.ToString());
				}
			}
			catch
			{
			}
			return list;
		}

		public int HDMoiBanBeVaoNhom(int indexRow, string statusProxy, Chrome chrome, string token, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, List<string> lstId, int typeInvite, string proxy, int typeProxy, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			string useragent = chrome.GetUseragent().Split('$')[0];
			string cookieFromChrome = chrome.GetCookieFromChrome();
			if (token == "" || !CommonRequest.CheckLiveToken(cookieFromChrome, token, useragent, proxy, typeProxy))
			{
				token = CommonChrome.GetTokenEAAAAZ(chrome);
			}
			List<string> nameFriend = GetNameFriend(token, proxy, typeProxy);
			List<string> list = new List<string>();
			string text = "";
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			try
			{
				int num7 = 0;
				while (num7 < lstId.Count)
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num7 + 1}/{lstId.Count})...");
					num6 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
					list = CloneList(nameFriend);
					while (true)
					{
						IL_033a:
						chrome.GotoURL("https://m.facebook.com/groups/members/search/?group_id=" + lstId[num7]);
						DelayThaoTacNho(1);
						int num8 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num8 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num8))
						{
							if (typeInvite != 0)
							{
								while (true)
								{
									if (chrome.CheckExistElement("[data-sigil=\"touchable efs-item\"]", 10.0) == 1)
									{
										num2 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"touchable efs-item\"]').length").ToString());
										if (num >= num6)
										{
											break;
										}
										num8 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
										if (num8 != 1)
										{
											if (!new List<int> { -3, -2, -1, 2 }.Contains(num8))
											{
												int num9 = 0;
												while (true)
												{
													if (num9 >= num2)
													{
														chrome.Refresh();
														break;
													}
													chrome.Click(4, "[data-sigil=\"touchable efs-item\"]");
													num++;
													if (num < num6)
													{
														chrome.DelayTime(rd.Next(nudDelayFrom, nudDelayTo + 1));
														num9++;
														continue;
													}
													goto end_IL_0105;
												}
												continue;
											}
											return -1;
										}
										goto IL_033a;
									}
									num3++;
									if (num3 != 1)
									{
										chrome.Refresh();
										continue;
									}
									goto end_IL_0105;
								}
							}
							else if (chrome.CheckExistElement("[data-sigil=\" tokenizer-input focus-receiver\"]", 5.0) == 1)
							{
								while (list.Count > 0)
								{
									text = list[rd.Next(0, list.Count)];
									list.Remove(text);
									if (!chrome.CheckChromeClosed())
									{
										num4 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"tokenizer-input-container\"]>div>span').length").ToString());
										chrome.SendKeys(4, "[data-sigil=\" tokenizer-input focus-receiver\"]", text);
										DelayThaoTacNho();
										chrome.SendEnter(4, "[data-sigil=\" tokenizer-input focus-receiver\"]");
										DelayThaoTacNho();
										num5 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"tokenizer-input-container\"]>div>span').length").ToString());
										if (num4 == num5)
										{
											chrome.ClearText(4, "[data-sigil=\" tokenizer-input focus-receiver\"]");
										}
										if (num5 == num6)
										{
											break;
										}
										continue;
									}
									return -2;
								}
								chrome.Click(4, "[data-testid=\"addSelectedButton\"]");
								DelayThaoTacNho(3);
								if (chrome.CheckExistElement("#addMembersInfoArea>span", 5.0) == 1)
								{
									num += Convert.ToInt32(Regex.Match(chrome.ExecuteScript("return document.querySelector('#addMembersInfoArea>span').innerText").ToString(), "(.*?) ").Groups[1].Value);
								}
							}
							num7++;
							break;
						}
						return -1;
					}
				}
				end_IL_0105:;
			}
			catch
			{
			}
			return num;
		}

		public int HDPhanHoiTinNhan(int indexRow, string statusProxy, Chrome chrome, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, List<string> lstTinNhan, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
			int num3 = 0;
			string text = "";
			List<string> list = CloneList(lstTinNhan);
			try
			{
				while (true)
				{
					IL_04b8:
					if (CommonChrome.GoToMessagesUnread(chrome) != -2)
					{
						int num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num4 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
						{
							int num5 = 0;
							while (true)
							{
								if (num5 < 5 && chrome.CheckExistElement("#see_older_threads", 3.0) == 1)
								{
									num3 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('#threadlist_rows a').length").ToString()) - 1;
									if (num3 >= num2)
									{
										break;
									}
									chrome.Click(1, "see_older_threads");
									DelayThaoTacNho();
									num5++;
									continue;
								}
								num3 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('#threadlist_rows a').length").ToString());
								if (num3 != 0)
								{
									break;
								}
								return num;
							}
							int num6 = 0;
							while (num6 < num3 && num < num2)
							{
								num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								if (num4 != 1)
								{
									if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
									{
										chrome.Click(4, "#threadlist_rows a", num6);
										DelayThaoTacNho();
										if (chrome.CheckExistElement("[data-sigil=\"m-textarea-input photo-textarea\"]", 10.0) == 1)
										{
											if (list.Count == 0)
											{
												list = CloneList(lstTinNhan);
											}
											text = list[rd.Next(0, list.Count)];
											list.Remove(text);
											text = MCommon.Common.SpinText(text, rd);
											string newValue = chrome.ExecuteScript("return document.title.split('-')[0]").ToString();
											text = text.Replace("[u]", newValue);
											chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[data-sigil=\"m-textarea-input photo-textarea\"]", text + " ", 0.1);
											DelayThaoTacNho();
											num4 = chrome.CheckExistElements(5.0, "[name=\"Send\"]", "[name=\"send\"]");
											if (num4 == 1)
											{
												chrome.Click(4, "[name=\"Send\"]");
											}
											else
											{
												chrome.Click(4, "[name=\"send\"]");
											}
											if (chrome.CheckExistElement("[data-sigil=\"context-layer-root content-pane\"]>div>span>div", 5.0) != 1)
											{
												num++;
											}
											SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
											chrome.DelayTime(rd.Next(nudDelayFrom, nudDelayTo + 1));
											if (CommonChrome.GoToMessagesUnread(chrome) == -2)
											{
												return -2;
											}
										}
										num6++;
										continue;
									}
									return -1;
								}
								goto IL_04b8;
							}
							break;
						}
						return -1;
					}
					return -2;
				}
			}
			catch
			{
			}
			return num;
		}

		public int HDXemWatch(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, int nudTimeWatchFrom, int nudTimeWatchTo, bool ckbInteract, int nudCountLikeFrom, int nudCountLikeTo, bool ckbShareWall, int nudCountShareFrom, int nudCountShareTo, bool ckbComment, List<string> txtComment, int nudCountCommentFrom, int nudCountCommentTo, string tenHanhDong)
		{
			int num = 0;
			int num2 = rd.Next(nudCountLikeFrom, nudCountLikeTo + 1);
			int num3 = rd.Next(nudCountCommentFrom, nudCountCommentTo + 1);
			int num4 = rd.Next(nudCountShareFrom, nudCountShareTo + 1);
			int num5 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			string text = "";
			try
			{
				while (true)
				{
					device.GotoWatchQuick();
					device.DelayRandom(2.0, 3.0);
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						continue;
					default:
						goto end_IL_0097;
					case 0:
						break;
					}
					while (num < num5)
					{
						device.ClosePopup();
						if (device.ScrollAndCheckScreenNotChange(300, 1, "[100,391][219,423]", "[181,195][286,226]", "[99,416][169,456]"))
						{
							break;
						}
						num++;
						device.DelayRandom(nudTimeWatchFrom, nudTimeWatchTo);
						if (ckbInteract && rd.Next(2) == 0 && num6 < num2)
						{
							text = device.GetHtml();
							if (device.CheckExistText("like", text))
							{
								List<string> listBoundsByText = device.GetListBoundsByText("like", text);
								string bounds = listBoundsByText[listBoundsByText.Count - 1];
								device.TapLongByBounds(bounds);
								device.DelayRandom(1.5, 2.0);
								device.ClickReactions(6);
								num6++;
							}
						}
						if (ckbComment && rd.Next(2) == 0 && num7 < num3)
						{
							text = device.GetHtml();
							if (device.CheckExistText("comment", text))
							{
								string text2 = txtComment[device.GetRandomInt(0, txtComment.Count - 1)];
								text2 = MCommon.Common.SpinText(text2, rd);
								List<string> listBoundsByText2 = device.GetListBoundsByText("comment", text);
								string bounds2 = listBoundsByText2[listBoundsByText2.Count - 1];
								device.TapByBounds(bounds2);
								device.DelayRandom(1.0, 2.0);
								text = device.GetHtml();
								if (text == "")
								{
									device.GotoBack();
									continue;
								}
								int num9 = device.CheckExistTexts(text, 3.0, "\"comment…\"", "write a comment…\"");
								if (num9 == 1)
								{
									device.TapByText("\"comment…\"", text);
								}
								if (!device.TapByTextWithPopupAppear(10, "write a comment…\"", Device.GetListTextClosePopup().ToArray()))
								{
									break;
								}
								device.InputTextWithUnicode(text2);
								device.TapByText("\"send\"", "", 3);
								device.DelayRandom(2.0, 2.5);
								device.GotoBack(2);
								device.DelayRandom(1.0, 1.5);
								num7++;
							}
						}
						if (ckbShareWall && rd.Next(2) == 0 && num8 < num4)
						{
							text = device.GetHtml();
							if (device.CheckExistText("share", text))
							{
								List<string> listBoundsByText3 = device.GetListBoundsByText("share", text);
								string bounds3 = listBoundsByText3[listBoundsByText3.Count - 1];
								device.TapByBounds(bounds3);
								device.TapByText("\"share now\"", "", 3);
								device.DelayRandom(1.5, 2.0);
								num8++;
							}
						}
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num5})...");
					}
					break;
				}
				end_IL_0097:;
			}
			catch
			{
			}
			return num;
		}

		private int HDDocThongBao(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, string tenHanhDong)
		{
			int num = 0;
			string text = "";
			int num2 = device.GetRandomInt(nudSoLuongFrom, nudSoLuongTo);
			try
			{
				string text2 = "manage the notification";
				while (num < num2)
				{
					List<string> listBoundsByText = device.GetListBoundsByText(text2);
					if (listBoundsByText.Count == 0)
					{
						while (true)
						{
							device.GotoNotificationQuick();
							device.DelayRandom(3.0, 5.0);
							switch (CheckStatusDevice(device, indexRow, statusProxy))
							{
							case 1:
								continue;
							case 0:
								if (device.CheckExistText("khi bật thông báo, bạn sẽ luôn giữ được kết nối với hoạt động trên facebook"))
								{
									device.TapByImage("DataClick\\image\\luckhac");
								}
								listBoundsByText = device.GetListBoundsByText(text2);
								if (listBoundsByText.Count != 0)
								{
									if (listBoundsByText.Count <= 4)
									{
										num2 = listBoundsByText.Count;
									}
									break;
								}
								goto end_IL_001e;
							default:
								goto end_IL_001e;
							}
							break;
						}
					}
					while (true)
					{
						if (listBoundsByText.Count == 0)
						{
							if (device.ScrollAndCheckScreenNotChange(150))
							{
								break;
							}
							listBoundsByText = device.GetListBoundsByText(text2);
							if (listBoundsByText.Count == 0)
							{
								break;
							}
						}
						text = listBoundsByText[device.GetRandomInt(0, listBoundsByText.Count - 1)];
						listBoundsByText.Remove(text);
						Point locationFromBounds = device.GetLocationFromBounds(text);
						if (!device.CheckBoundsContainLocation("[0,60][320,480]", locationFromBounds))
						{
							continue;
						}
						device.Tap(locationFromBounds.X - device.GetRandomInt(100, 150), locationFromBounds.Y);
						device.DelayRandom(1.0, 2.0);
						int tickCount = Environment.TickCount;
						int randomInt = device.GetRandomInt(nudDelayFrom, nudDelayTo);
						while (Environment.TickCount - tickCount < randomInt * 1000 && !device.ScrollAndCheckScreenNotChange())
						{
							device.DelayRandom(1.0, 2.0);
						}
						num++;
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
						device.GotoBack();
						device.DelayRandom(1.0, 2.0);
						goto IL_0320;
					}
					break;
					IL_0320:;
				}
				end_IL_001e:;
			}
			catch
			{
			}
			return num;
		}

		public int HDDocThongBao(int indexRow, string statusProxy, Chrome chrome, int nudSoLuongFrom, int nudSoLuongTo, int typeDocThongBao, int nudDelayFrom, int nudDelayTo, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			try
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
				while (true)
				{
					if (CommonChrome.GoToNotifications(chrome) != -2)
					{
						num2 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num2 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num2))
						{
							num3 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('.touchable-notification').length+''").ToString());
							if (num3 > 0)
							{
								if (typeDocThongBao == 0)
								{
									while (true)
									{
										num2 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
										if (num2 == 1)
										{
											break;
										}
										if (new List<int> { -3, -2, -1, 2 }.Contains(num2))
										{
											return -1;
										}
										chrome.ScrollSmooth("document.querySelectorAll('.touchable-notification a')[" + num2 + "]");
										DelayThaoTacNho();
										if (chrome.Click(4, ".touchable-notification a", num2) == 1)
										{
											chrome.DelayThaoTacNho();
											CommonChrome.ScrollRandom(chrome);
										}
										num2++;
										num++;
										SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num4})...");
										if (num < num4)
										{
											chrome.DelayTime(rd.Next(nudDelayFrom, nudDelayTo + 1));
											chrome.Click(4, "[data-sigil=\"MBackNavBarClick\"]");
											DelayThaoTacNho(2);
											if (num <= 5 && chrome.CheckExistElement("#notifications_jewel > a", 10.0) == 1)
											{
												chrome.Click(4, "#notifications_jewel > a");
												DelayThaoTacNho(2);
											}
											if (num != num3)
											{
												goto IL_03b4;
											}
											num2 += num;
											if (chrome.CheckExistElement("#MNotificationFlyoutContent > div > ol > li > a", 10.0) == 1)
											{
												chrome.Click(4, "#MNotificationFlyoutContent > div > ol > li > a");
												chrome.DelayTime(2.0);
												if (chrome.CheckExistElement(".touchable-notification", 5.0) == 1)
												{
													int num5 = Convert.ToInt32(chrome.ExecuteScript("return (document.querySelectorAll('.touchable-notification').length+'')").ToString());
													if (num5 != num3)
													{
														num3 = num5;
														goto IL_03b4;
													}
												}
											}
										}
										goto end_IL_003f;
										IL_03b4:
										if (num < num4)
										{
											continue;
										}
										goto end_IL_003f;
									}
									continue;
								}
								List<int> list = new List<int>();
								for (int i = 0; i < num4; i++)
								{
									list.Add(i);
								}
								list = MCommon.Common.ShuffleList(list);
								while (num2 < num4)
								{
									if (CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3) == 0)
									{
										int num6 = list[0];
										if (num6 >= num3)
										{
											if (chrome.CheckExistElement("#MNotificationFlyoutContent > div > ol > li > a", 10.0) != 1)
											{
												break;
											}
											chrome.Click(4, "#MNotificationFlyoutContent > div > ol > li > a");
											chrome.DelayTime(2.0);
											if (chrome.CheckExistElement(".touchable-notification", 5.0) != 1)
											{
												break;
											}
											int num7 = Convert.ToInt32(chrome.ExecuteScript("return (document.querySelectorAll('.touchable-notification').length+'')").ToString());
											if (num7 == num3)
											{
												break;
											}
											chrome.Click(4, ".touchable-notification a", num6 + 5);
										}
										else
										{
											chrome.Click(4, ".touchable-notification a", num6);
										}
										num2++;
										num++;
										SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num4})...");
										chrome.DelayTime(rd.Next(nudDelayFrom, nudDelayTo + 1));
										list.RemoveAt(0);
										chrome.GotoBackPage();
										DelayThaoTacNho();
										if (chrome.CheckExistElement("#notifications_jewel > a", 10.0) == 1)
										{
											chrome.Click(4, "#notifications_jewel > a");
											DelayThaoTacNho();
										}
										if (num >= num4)
										{
											break;
										}
										continue;
									}
									return -1;
								}
								break;
							}
							return num;
						}
						return -1;
					}
					return -2;
				}
				end_IL_003f:;
			}
			catch
			{
				return -1;
			}
			return num;
		}

		private int CheckFacebookLogout(Chrome chrome, string uid, string pass, string fa2, bool isSendRequest = false)
		{
			int result = 0;
			CommonChrome.CheckStatusAccount(chrome, isSendRequest);
			switch (chrome.Status)
			{
			case StatusChromeAccount.ChromeClosed:
				result = -2;
				break;
			case StatusChromeAccount.LoginWithUserPass:
			case StatusChromeAccount.LoginWithSelectAccount:
			{
				string text = CommonChrome.LoginFacebookUsingUidPassNew(chrome, uid, pass, fa2, "https://m.facebook.com/", 2);
				result = ((text == "1") ? 1 : 2);
				break;
			}
			case StatusChromeAccount.Checkpoint:
				result = -1;
				break;
			case StatusChromeAccount.NoInternet:
				result = -3;
				break;
			}
			return result;
		}

		public int HDXemStory(int indexRow, string statusProxy, Device device, int nudTimeFrom, int nudTimeTo, bool ckbInteract, string typeReaction, bool ckbComment, List<string> lstComment, string tenHanhDong)
		{
			string text = "";
			int randomInt = device.GetRandomInt(nudTimeFrom, nudTimeTo);
			try
			{
				while (true)
				{
					device.GotoNewFeedQuick();
					device.DelayRandom(1.0, 2.0);
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						break;
					default:
						goto end_IL_0018;
					case 0:
					{
						string boundsByText = device.GetBoundsByText("'s story");
						if (boundsByText != "")
						{
							device.TapByBounds(boundsByText);
							int tickCount = Environment.TickCount;
							while (Environment.TickCount - tickCount < randomInt * 1000)
							{
								device.DelayRandom(4.0, 8.0);
								string boundsByText2 = device.GetBoundsByText("reply to");
								if (!(boundsByText2 == ""))
								{
									if (ckbComment && device.GetRandomInt(1, 9) % 3 == 0)
									{
										text = lstComment[device.GetRandomInt(0, lstComment.Count - 1)];
										text = MCommon.Common.SpinText(text, rd);
										device.TapByBounds(boundsByText2);
										device.DelayTime(1.0);
										device.InputTextWithUnicode(text);
										device.TapByText("\"send\"");
										device.DelayRandom(1.0, 1.5);
									}
									if (ckbInteract && device.GetRandomInt(1, 9) % 3 == 0)
									{
										string bounds = "[165,445][195,470]";
										string bounds2 = "[35,445][65,470]";
										device.SwipeByBounds(bounds, bounds2);
										device.DelayRandom(1.0, 1.5);
										int typeReaction2 = Convert.ToInt32(typeReaction[device.GetRandomInt(0, typeReaction.Length - 1)].ToString());
										device.ClickReactions(typeReaction2);
										device.DelayRandom(1.0, 1.5);
										device.TapByBounds("[260,198][300,268]");
										device.DelayRandom(1.0, 1.5);
									}
									device.TapByBounds("[260,198][300,268]");
									continue;
								}
								break;
							}
						}
						goto end_IL_0018;
					}
					}
				}
				end_IL_0018:;
			}
			catch
			{
			}
			return randomInt;
		}

		public int HDTuongTacVideo(int indexRow, string statusProxy, Device device, string txtLinkVideo, int nudTimeFrom, int nudTimeTo, bool ckbInteract, string typeReaction, bool ckbComment, List<string> lstComment, bool ckbBinhLuanNhieuLan, int nudBinhLuanNhieuLanDelayFrom, int nudBinhLuanNhieuLanDelayTo, string tenHanhDong)
		{
			List<string> list = CloneList(lstComment);
			string text = "";
			int randomInt = device.GetRandomInt(nudTimeFrom, nudTimeTo);
			try
			{
				while (true)
				{
					device.OpenLink(txtLinkVideo);
					device.DelayRandom(1.0, 2.0);
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						break;
					default:
						goto end_IL_0026;
					case 0:
					{
						if (ckbInteract)
						{
							List<string> listBoundsByText = device.GetListBoundsByText("double tap and hold to");
							if (listBoundsByText.Count > 0)
							{
								string text2 = listBoundsByText[listBoundsByText.Count - 1];
								if (text2 != "")
								{
									SetStatusAccount(indexRow, "Đang thả cảm xúc video...");
									if (device.TapLongByBounds(text2, "[0,100][320,480]"))
									{
										device.DelayRandom(1.0, 1.5);
										int typeReaction2 = Convert.ToInt32(typeReaction[rd.Next(0, typeReaction.Length)].ToString() ?? "");
										device.ClickReactions(typeReaction2);
										device.DelayRandom(1.0, 2.0);
									}
								}
							}
						}
						int num = 0;
						int tickCount = Environment.TickCount;
						SetStatusAccount(indexRow, "Đang xem video...");
						while (Environment.TickCount - tickCount < randomInt * 1000 && device.CheckIsLive())
						{
							if (ckbComment && (num == 0 || ckbBinhLuanNhieuLan))
							{
								string html = device.GetHtml();
								switch (device.CheckExistTexts(html, 0.0, "write a comment…", "comment button"))
								{
								case 1:
								{
									Bitmap bitmap = device.Crop(device.ScreenShoot(), "[44,72][153,96]");
									SetStatusAccount(indexRow, "Đang comment...");
									if (list.Count == 0)
									{
										list = MCommon.Common.CloneList(lstComment);
									}
									text = list[device.GetRandomInt(0, list.Count - 1)];
									list.Remove(text);
									text = MCommon.Common.SpinText(text, rd);
									text = GetIconFacebook.ProcessString(text, rd);
									if (!device.TapByText("write a comment…", html))
									{
										break;
									}
									device.DelayRandom(1.0, 2.0);
									device.InputTextWithUnicode(text);
									device.DelayRandom(1.0, 2.0);
									if (device.TapByText("send"))
									{
										device.DelayRandom(3.0, 5.0);
									}
									for (int i = 0; i < 5; i++)
									{
										if (device.GetBoundsByImage(bitmap, device.ScreenShoot()) != "")
										{
											break;
										}
										if (device.ScrollAndCheckScreenNotChange(200, -1))
										{
											break;
										}
										device.DelayTime(1.0);
									}
									num++;
									SetStatusAccount(indexRow, "Đang xem video...");
									device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
									break;
								}
								case 2:
								{
									List<string> listBoundsByText2 = device.GetListBoundsByText("comment button");
									if (listBoundsByText2.Count <= 0)
									{
										break;
									}
									string text3 = listBoundsByText2[listBoundsByText2.Count - 1];
									if (!(text3 != ""))
									{
										break;
									}
									SetStatusAccount(indexRow, "Đang comment...");
									if (list.Count == 0)
									{
										list = MCommon.Common.CloneList(lstComment);
									}
									text = list[device.GetRandomInt(0, list.Count - 1)];
									list.Remove(text);
									text = MCommon.Common.SpinText(text, rd);
									if (device.TapByBounds(text3, "[0,100][320,480]"))
									{
										device.DelayRandom(1.0, 2.0);
										device.InputTextWithUnicode(text);
										device.DelayRandom(1.0, 2.0);
										if (device.TapByText("send"))
										{
											device.DelayRandom(3.0, 5.0);
										}
										device.GotoBack(2, 0.3);
										num++;
										SetStatusAccount(indexRow, "Đang xem video...");
										device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
									}
									break;
								}
								}
							}
							else
							{
								int num2 = (Environment.TickCount - tickCount) / 1000;
								SetStatusAccount(indexRow, "Đang xem video, còn " + (randomInt - num2) + "s...");
								device.DelayTime(1.0);
							}
						}
						goto end_IL_0026;
					}
					}
				}
				end_IL_0026:;
			}
			catch
			{
			}
			SetStatusAccount(indexRow, "Xem video xong...");
			return randomInt;
		}

		public int HDTuongTacLivestream(int indexRow, string statusProxy, Device device, string txtLinkVideo, int nudTimeFrom, int nudTimeTo, bool ckbInteract, string typeReaction, bool ckbComment, List<string> lstComment, bool ckbBinhLuanNhieuLan, int nudBinhLuanNhieuLanDelayFrom, int nudBinhLuanNhieuLanDelayTo, string tenHanhDong)
		{
			List<string> list = CloneList(lstComment);
			string text = "";
			int randomInt = device.GetRandomInt(nudTimeFrom, nudTimeTo);
			try
			{
				while (device.OpenLink(txtLinkVideo))
				{
					bool flag = false;
					int num = 0;
					while (true)
					{
						if (num >= 10)
						{
							goto IL_02e7;
						}
						int num2 = CheckStatusDevice(device, indexRow, statusProxy);
						if (num2 == 1)
						{
							break;
						}
						if (num2 == 0 || num2 == -3)
						{
							bool flag2 = false;
							if (device.TapByImageWait("DataClick\\image\\livestream"))
							{
								flag2 = true;
							}
							else
							{
								string html = device.GetHtml();
								if (device.CheckExistText("\"ok\"", html))
								{
									device.TapByText("\"ok\"", html);
									html = device.GetHtml();
								}
								if (device.CheckExistText("\"video\"", html))
								{
									device.TapByText("\"video\"", html);
									flag2 = true;
								}
								else if (device.CheckExistText("viewers\"", html))
								{
									device.TapByText("viewers\"", html);
									flag2 = true;
								}
								else if (device.CheckExistText("\"toggle video sound", html))
								{
									string boundsByText = device.GetBoundsByText("\"toggle video sound", html);
									if (boundsByText != "")
									{
										Point locationFromBounds = device.GetLocationFromBounds(boundsByText);
										device.Tap(locationFromBounds.X - 120, locationFromBounds.Y);
										flag2 = true;
									}
								}
								else
								{
									device.ClosePopup(html);
								}
							}
							if (!flag2 || !device.CheckExistImage("DataClick\\image\\chiase"))
							{
								if (device.CheckExistImage("DataClick\\image\\luckhaccamon"))
								{
									device.TapByImageWait("DataClick\\image\\luckhaccamon");
								}
								if (device.CheckExistImage("DataClick\\image\\theodoi"))
								{
									device.GotoBack();
								}
								if (!device.CheckExistImage("DataClick\\image\\chiase"))
								{
									device.DelayTime(1.0);
									num++;
									continue;
								}
								flag = true;
							}
							else
							{
								flag = true;
							}
							goto IL_02e7;
						}
						goto end_IL_0026;
						IL_02e7:
						if (flag)
						{
							int tickCount = Environment.TickCount;
							device.DelayTime(5.0);
							while (ckbInteract)
							{
								string text2 = "[165,445][195,470]";
								string text3 = "[35,445][65,470]";
								device.SwipeByBounds(text2, text3, 500);
								device.DelayRandom(1.0, 1.5);
								if (!device.ClosePopup())
								{
									int typeReaction2 = Convert.ToInt32(typeReaction[device.GetRandomInt(0, typeReaction.Length - 1)].ToString());
									device.ClickReactions(typeReaction2);
									device.DelayRandom(1.0, 1.5);
									device.SwipeByBounds(text3, text2);
									device.DelayRandom(1.0, 1.5);
									break;
								}
							}
							int num3 = 0;
							SetStatusAccount(indexRow, "Đang xem live...");
							while (Environment.TickCount - tickCount < randomInt * 1000 && device.CheckIsLive())
							{
								if (ckbComment && (num3 == 0 || ckbBinhLuanNhieuLan))
								{
									string html2 = device.GetHtml();
									if (device.CheckExistText("write a comment…", html2))
									{
										SetStatusAccount(indexRow, "Đang comment...");
										if (list.Count == 0)
										{
											list = MCommon.Common.CloneList(lstComment);
										}
										text = list[device.GetRandomInt(0, list.Count - 1)];
										list.Remove(text);
										text = MCommon.Common.SpinText(text, rd);
										text = GetIconFacebook.ProcessString(text, rd);
										List<string> listBoundsByText = device.GetListBoundsByText("write a comment…", html2);
										if (device.TapByBounds(listBoundsByText[listBoundsByText.Count - 1]))
										{
											device.DelayRandom(1.0, 2.0);
											device.InputTextWithUnicode(text);
											device.DelayRandom(1.0, 2.0);
											if (device.TapByText("send"))
											{
												device.DelayRandom(3.0, 5.0);
											}
											num3++;
											SetStatusAccount(indexRow, "Đang xem live...");
											device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
										}
									}
									else
									{
										device.ClosePopup(html2);
									}
								}
								else
								{
									int num4 = (Environment.TickCount - tickCount) / 1000;
									SetStatusAccount(indexRow, "Đang xem live, còn " + (randomInt - num4) + "s...");
									device.DelayTime(1.0);
								}
							}
						}
						goto end_IL_0026;
					}
				}
				end_IL_0026:;
			}
			catch
			{
			}
			SetStatusAccount(indexRow, "Xem Live xong...");
			return randomInt;
		}

		public int HDXacNhanKetBan(int indexRow, string statusProxy, Device device, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, string tenHanhDong)
		{
			int num = 0;
			try
			{
				int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
				if (num2 != 0)
				{
					while (device.GotoAcceptFriend())
					{
						switch (CheckStatusDevice(device, indexRow, statusProxy))
						{
						case 0:
						{
							List<string> listBoundsByText = device.GetListBoundsByText("\"confirm");
							if (listBoundsByText.Count != 0)
							{
								while (true)
								{
									switch (CheckStatusDevice(device, indexRow, statusProxy))
									{
									case 0:
									{
										string text = listBoundsByText[device.GetRandomInt(0, listBoundsByText.Count - 1)];
										if (text != "" && device.TapByBounds(text))
										{
											num++;
											SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
											device.DelayRandom(delayFrom, delayTo);
											string html = device.GetHtml();
											if (device.CheckExistText("đã đạt ngưỡng 5.000", html))
											{
												string input = string.Join("|", device.GetListText(html));
												string text2 = Regex.Match(input, "\\|(.*?)đã đạt ngưỡng 5.000").Groups[1].Value.Trim();
												device.TapByText("\"ok\"", html);
												List<string> listBoundsByText2 = device.GetListBoundsByText(text2, "", 3);
												if (listBoundsByText2.Count > 1)
												{
													device.TapByBounds(listBoundsByText2[1], "[0,60][320,480]");
												}
												num--;
											}
										}
										if (num < num2)
										{
											listBoundsByText = device.GetListBoundsByText("\"confirm");
											if (listBoundsByText.Count != 0)
											{
												continue;
											}
											if (!device.ScrollAndCheckScreenNotChange(200))
											{
												listBoundsByText = device.GetListBoundsByText("\"confirm");
												if (listBoundsByText.Count != 0)
												{
													continue;
												}
											}
										}
										goto end_IL_0006;
									}
									case 1:
										break;
									default:
										goto end_IL_0006;
									}
									break;
								}
								break;
							}
							goto end_IL_0006;
						}
						case 1:
							break;
						default:
							goto end_IL_0006;
						}
					}
				}
				end_IL_0006:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDXacNhanKetBan(int indexRow, string statusProxy, Chrome chrome, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, Random rd, string tenHanhDong = "", bool ckbChiKetBanTenCoDau = false, bool ckbOnlyAddFriendWithMutualFriends = false)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			try
			{
				int num5 = rd.Next(soLuongFrom, soLuongTo + 1);
				while (true)
				{
					IL_04ef:
					if (chrome.GotoURL("https://m.facebook.com/friends/center/requests/all") != -2)
					{
						chrome.DelayRandom(3, 5);
						int num6 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num6 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num6))
						{
							if (num5 <= 0)
							{
								break;
							}
							int num7 = 0;
							switch (chrome.CheckExistElements(10.0, "#friends_center_main>div>header>h3>span", "[data-sigil=\"m-friend-center-req-badge\"]"))
							{
							case 2:
								num7 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelector('[data-sigil=\"m-friend-center-req-badge\"]').innerText").ToString().Replace(",", "")
									.Replace(".", ""));
								break;
							case 1:
								num7 = Convert.ToInt32(chrome.ExecuteScript("var dem='0';var x= document.querySelector('#friends_center_main>div>header>h3>span');if(x!=null) dem=x.innerText; return dem;").ToString().Replace(",", "")
									.Replace(".", ""));
								break;
							}
							if (num7 <= 0)
							{
								break;
							}
							num4 = ((num5 < 100) ? 5 : 10);
							int num8 = -1;
							while (num < num7)
							{
								num6 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								if (num6 != 1)
								{
									if (!new List<int> { -3, -2, -1, 2 }.Contains(num6))
									{
										num8++;
										if (Convert.ToBoolean(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil*=\"m-optimistic-response-root\"]')[" + num8 + "]==null?'false':'true'")))
										{
											chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('button[data-sigil=\"touchable confirm-request\"]')[" + num8 + "]");
											chrome.DelayTime(1.0);
											bool flag = true;
											if (ckbChiKetBanTenCoDau)
											{
												string text = chrome.ExecuteScript("return document.querySelectorAll('[data-sigil*=\"m-optimistic-response-root\"] h3,[data-sigil*=\"m-optimistic-response-root\"] h1')[" + num8 + "].innerText").ToString();
												string text2 = CommonCSharp.convertToUnSign(text);
												if (text == "")
												{
													break;
												}
												if (text == text2)
												{
													flag = false;
												}
											}
											if (flag && ckbOnlyAddFriendWithMutualFriends)
											{
												string pValue = chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"m-add-friend-source-replaceable\"]')[" + num8 + "].innerText").ToString();
												flag = MCommon.Common.IsContainNumber(pValue);
											}
											if (!flag)
											{
												continue;
											}
											chrome.Click(4, "button[data-sigil=\"touchable confirm-request\"]", num8);
											DelayThaoTacNho();
											if (CommonChrome.SkipNotifyWhenAddFriend(chrome))
											{
												num3++;
												if (num3 >= num4)
												{
													break;
												}
											}
											else
											{
												num3 = 0;
											}
											num++;
											if (tenHanhDong == "")
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang xác nhận kết bạn") + $" ({num}/{num5})...");
											}
											else
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num5})...");
											}
											if (num >= num5)
											{
												break;
											}
											if (chrome.CheckChromeClosed())
											{
												return -2;
											}
											delayFrom = ((delayFrom > 2) ? (delayFrom - 2) : 0);
											delayTo = ((delayTo > 2) ? (delayTo - 2) : 0);
											chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
										}
										else
										{
											num2++;
											if (num2 == 5)
											{
												break;
											}
										}
										continue;
									}
									return -1;
								}
								goto IL_04ef;
							}
							break;
						}
						return -1;
					}
					return -2;
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDKetBanTheoTuKhoa(int indexRow, string statusProxy, Device device, List<string> lstTuKhoa, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, string tenHanhDong)
		{
			int num = 0;
			try
			{
				int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
				if (num2 != 0)
				{
					lstTuKhoa = MCommon.Common.RemoveEmptyItems(lstTuKhoa);
					string text = lstTuKhoa[rd.Next(0, lstTuKhoa.Count)];
					text = MCommon.Common.SpinText(text, rd);
					while (device.GotoSearch(text, "people"))
					{
						switch (CheckStatusDevice(device, indexRow, statusProxy))
						{
						case 0:
						{
							List<string> listBoundsByImage = device.GetListBoundsByImage("DataClick\\image\\addfriend", null, 5);
							while (true)
							{
								string text2;
								switch (CheckStatusDevice(device, indexRow, statusProxy))
								{
								case 0:
								{
									if (listBoundsByImage.Count != 0)
									{
										goto IL_0172;
									}
									for (int i = 0; i < 10; i++)
									{
										if (device.ScrollAndCheckScreenNotChange(device.GetRandomInt(400, 500)))
										{
											break;
										}
										listBoundsByImage = device.GetListBoundsByImage("DataClick\\image\\addfriend", null, 5);
										if (listBoundsByImage.Count > 0)
										{
											break;
										}
									}
									if (listBoundsByImage.Count != 0)
									{
										goto IL_0172;
									}
									goto end_IL_0006;
								}
								case 1:
									break;
								default:
									goto end_IL_0006;
									IL_0172:
									text2 = listBoundsByImage[device.GetRandomInt(0, listBoundsByImage.Count - 1)];
									listBoundsByImage.Remove(text2);
									if (text2 != "" && device.TapByBounds(text2))
									{
										num++;
										SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
										device.DelayRandom(delayFrom, delayTo);
									}
									if (num < num2)
									{
										continue;
									}
									goto end_IL_0006;
								}
								break;
							}
							break;
						}
						case 1:
							break;
						default:
							goto end_IL_0006;
						}
					}
				}
				end_IL_0006:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDKetBanGoiY(int indexRow, string statusProxy, Device device, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, string tenHanhDong)
		{
			int num = 0;
			try
			{
				int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
				if (num2 != 0)
				{
					while (true)
					{
						device.GotoFriendSuggest();
						device.DelayRandom(1.0, 2.0);
						switch (CheckStatusDevice(device, indexRow, statusProxy))
						{
						case 0:
						{
							List<string> listBoundsByText = device.GetListBoundsByText("as a friend\"");
							if (listBoundsByText.Count != 0)
							{
								while (true)
								{
									int num3 = CheckStatusDevice(device, indexRow, statusProxy);
									if (num3 == 1)
									{
										break;
									}
									if (num3 == 0)
									{
										string text = listBoundsByText[device.GetRandomInt(0, listBoundsByText.Count - 1)];
										if (text != "" && device.TapByBounds(text))
										{
											num++;
											SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
											device.DelayRandom(delayFrom, delayTo);
										}
										if (num < num2)
										{
											listBoundsByText = device.GetListBoundsByText("as a friend");
											if (listBoundsByText.Count != 0)
											{
												continue;
											}
											if (!device.ScrollAndCheckScreenNotChange(device.GetRandomInt(200, 300)))
											{
												listBoundsByText = device.GetListBoundsByText("as a friend");
												if (listBoundsByText.Count != 0)
												{
													continue;
												}
											}
										}
									}
									goto end_IL_0006;
								}
								break;
							}
							goto end_IL_0006;
						}
						case 1:
							break;
						default:
							goto end_IL_0006;
						}
					}
				}
				end_IL_0006:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public List<string> GetListIdGroup(string useragent, string token, string cookie, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
				string json = requestXNet.RequestGet("https://graph.facebook.com/v3.0/me/groups?access_token=" + token + "&limit=5000&fields=id,name").ToString();
				JObject jObject = JObject.Parse(json);
				foreach (JToken item in (IEnumerable<JToken>)(jObject["data"]!))
				{
					list.Add(item["id"]!.ToString());
				}
			}
			catch
			{
			}
			return list;
		}

		public List<string> GetIdFriend(string token, string cookie, string useragent, string proxy, int typeProxy)
		{
			List<string> list = new List<string>();
			try
			{
				string value = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
				requestXNet.request.AddHeader("Authorization", "OAuth " + token);
				string json = requestXNet.RequestGet("https://graph.facebook.com/?ids=" + value + "&pretty=0&fields=friends.limit(5000){id}");
				JObject jObject = JObject.Parse(json);
				JToken jToken = jObject[value]!["friends"];
				if (jToken["data"].Count() > 0)
				{
					for (int i = 0; i < jToken["data"].Count(); i++)
					{
						string item = jToken["data"]![i]!["id"]!.ToString();
						list.Add(item);
					}
				}
			}
			catch
			{
			}
			return list;
		}

		public List<string> CloneList(List<string> lstFrom)
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

		private void DelayThaoTacNho(int timeAdd = 0)
		{
			MCommon.Common.DelayTime(rd.Next(timeAdd + 1, timeAdd + 4));
		}

		private void ShowTrangThai(string content)
		{
			try
			{
				plTrangThai.Invoke((MethodInvoker)delegate
				{
					if (!plTrangThai.Visible)
					{
						plTrangThai.Visible = true;
					}
				});
				lblTrangThai.Invoke((MethodInvoker)delegate
				{
					lblTrangThai.Text = content;
				});
			}
			catch
			{
			}
		}

		private void HideTrangThai()
		{
			try
			{
				plTrangThai.Invoke((MethodInvoker)delegate
				{
					if (plTrangThai.Visible)
					{
						plTrangThai.Visible = false;
					}
				});
			}
			catch
			{
			}
		}

		private void cControl(string dt)
		{
			Invoke((MethodInvoker)delegate
			{
				try
				{
					if (dt == "start")
					{
						btnInteract.Enabled = false;
						grQuanLyThuMuc.Enabled = false;
						btnPause.Enabled = true;
					}
					else if (dt == "stop")
					{
						btnPause.Text = Language.GetValue("Dừng");
						btnInteract.Enabled = true;
						grQuanLyThuMuc.Enabled = true;
						btnPause.Enabled = false;
					}
				}
				catch (Exception)
				{
				}
			});
		}

		private void DtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				try
				{
					dtgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value);
					CountCheckedAccount();
				}
				catch
				{
				}
			}
		}

		private void DtgvAcc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 32)
			{
				ChoseRowInDatagrid("ToggleCheck");
			}
		}

		private void TuLayThongTin(int type)
		{
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			if (type == 2)
			{
				maxThread = Convert.ToInt32(setting_general.GetValue("nudInteractThread"));
			}
			setting_general.GetValue("token");
			isStop = false;
			bool isChangeIPSuccess = false;
			int curChangeIp = 0;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = type;
				int num2 = num;
				if (num2 != 0)
				{
					if (num2 == 1)
					{
						int num3 = 0;
						while (num3 < dtgvAcc.Rows.Count && !isStop)
						{
							if (!Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
							{
								num3++;
								continue;
							}
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row2 = num3++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row2, Language.GetValue("Đang kiểm tra..."));
									string statusDataGridView3 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row2, "cId");
									string statusDataGridView4 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row2, "cCookies");
									string text3 = GetCellAccount(row2, "cUseragent");
									string text4 = "";
									int typeProxy2 = 0;
									if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
									{
										text4 = GetCellAccount(row2, "cProxy");
										typeProxy2 = (text4.EndsWith("*1") ? 1 : 0);
										if (text4.EndsWith("*0") || text4.EndsWith("*1"))
										{
											text4 = text4.Substring(0, text4.Length - 2);
										}
									}
									if (text3 == "" && text4.Split(':').Length == 4)
									{
										text3 = Base.useragentDefault;
									}
									if (statusDataGridView4 == "")
									{
										SetStatusAccount(row2, Language.GetValue("Cookie trống!"));
									}
									else
									{
										string tokenEAAG = CommonRequest.GetTokenEAAG(statusDataGridView4, text3, text4, typeProxy2);
										if (tokenEAAG == "-1")
										{
											SetStatusAccount(row2, "Cookie die!");
										}
										else
										{
											CommonSQL.UpdateFieldToAccount(statusDataGridView3, "token", tokenEAAG);
											SetCellAccount(row2, "cToken", tokenEAAG);
											SetStatusAccount(row2, Language.GetValue("Lấy token thành công!"));
										}
									}
								}).Start();
								continue;
							}
							if (Convert.ToInt32((setting_general.GetValue("ip_iTypeChangeIp") == "") ? "0" : setting_general.GetValue("ip_iTypeChangeIp")) == 0 || Convert.ToInt32((setting_general.GetValue("ip_iTypeChangeIp") == "") ? "0" : setting_general.GetValue("ip_iTypeChangeIp")) == 7)
							{
								MCommon.Common.DelayTime(1.0);
								continue;
							}
							while (iThread > 0)
							{
								MCommon.Common.DelayTime(1.0);
							}
							if (isStop)
							{
								break;
							}
							Interlocked.Increment(ref curChangeIp);
							if (curChangeIp < Convert.ToInt32((setting_general.GetValue("ip_nudChangeIpCount") == "") ? "1" : setting_general.GetValue("ip_nudChangeIpCount")))
							{
								continue;
							}
							for (int i = 0; i < 3; i++)
							{
								isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValueInt("typeDcom"), setting_general.GetValue("ip_txtProfileNameDcom"), setting_general.GetValue("txtUrlHilink"), setting_general.GetValueInt("ip_cbbHostpot"), setting_general.GetValue("ip_txtNordVPN"));
								if (isChangeIPSuccess)
								{
									break;
								}
							}
							if (isChangeIPSuccess)
							{
								curChangeIp = 0;
								continue;
							}
							goto IL_030d;
						}
					}
				}
				else
				{
					int num4 = 0;
					while (num4 < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							num4++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num4++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cId");
								string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cCookies");
								string text = GetCellAccount(row, "cUseragent");
								string text2 = "";
								int typeProxy = 0;
								if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
								{
									text2 = GetCellAccount(row, "cProxy");
									typeProxy = (text2.EndsWith("*1") ? 1 : 0);
									if (text2.EndsWith("*0") || text2.EndsWith("*1"))
									{
										text2 = text2.Substring(0, text2.Length - 2);
									}
								}
								if (text == "" && text2.Split(':').Length == 4)
								{
									text = Base.useragentDefault;
								}
								if (statusDataGridView2 == "")
								{
									SetStatusAccount(row, Language.GetValue("Cookie trống!"));
								}
								else
								{
									string tokenEAAAAZ = CommonRequest.GetTokenEAAAAZ(statusDataGridView2, text, text2, typeProxy);
									if (tokenEAAAAZ == "-1")
									{
										SetStatusAccount(row, "Cookie die!");
									}
									else
									{
										CommonSQL.UpdateFieldToAccount(statusDataGridView, "token", tokenEAAAAZ);
										SetCellAccount(row, "cToken", tokenEAAAAZ);
										SetStatusAccount(row, Language.GetValue("Lấy token thành công!"));
									}
								}
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9 || setting_general.GetValueInt("ip_iTypeChangeIp") == 10 || setting_general.GetValueInt("ip_iTypeChangeIp") == 11 || setting_general.GetValueInt("ip_iTypeChangeIp") == 12)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (isStop)
						{
							break;
						}
						Interlocked.Increment(ref curChangeIp);
						if (curChangeIp < Convert.ToInt32(setting_general.GetValueInt("ip_nudChangeIpCount", 1)))
						{
							continue;
						}
						for (int j = 0; j < 3; j++)
						{
							isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValueInt("typeDcom"), setting_general.GetValue("ip_txtProfileNameDcom"), setting_general.GetValue("txtUrlHilink"), setting_general.GetValueInt("ip_cbbHostpot"), setting_general.GetValue("ip_txtNordVPN"));
							if (isChangeIPSuccess)
							{
								break;
							}
						}
						if (isChangeIPSuccess)
						{
							curChangeIp = 0;
							continue;
						}
						goto IL_0618;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 60000)
				{
					MCommon.Common.DelayTime(1.0);
				}
				goto IL_0628;
				IL_0628:
				cControl("stop");
				return;
				IL_030d:
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
				goto IL_0628;
				IL_0618:
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
				goto IL_0628;
			}).Start();
		}

		private void BtnPause_Click(object sender, EventArgs e)
		{
			try
			{
				isStop = true;
				btnPause.Enabled = false;
				btnPause.Text = Language.GetValue("Đang dư\u0300ng...");
			}
			catch
			{
			}
		}

		private void TảiLạiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BtnLoadAcc_Click(null, null);
		}

		private void BtnDeleteFile_Click(object sender, EventArgs e)
		{
			int selectedIndex = cbbThuMuc.SelectedIndex;
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có thực sự muốn xóa thư mục [{0}] không?"), cbbThuMuc.Text)) == DialogResult.Yes)
			{
				if (CommonSQL.DeleteFileToDatabase(cbbThuMuc.SelectedValue.ToString()))
				{
					MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Xoá thành công thư mục [{0}] !"), cbbThuMuc.Text));
					LoadCbbThuMuc();
					cbbThuMuc.SelectedIndex = selectedIndex - 1;
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Không thể xóa thư mục [{0}] !"), cbbThuMuc.Text), 2);
				}
			}
		}

		private void CbbThuMuc_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isExcute_CbbThuMuc_SelectedIndexChanged || cbbThuMuc.SelectedValue == null || !StringHelper.CheckStringIsNumber(cbbThuMuc.SelectedValue.ToString()) || (cbbThuMuc.SelectedValue.ToString() != "999999" && indexCbbThuMucOld == cbbThuMuc.SelectedIndex))
			{
				return;
			}
			string text = cbbThuMuc.SelectedValue.ToString();
			string text2 = text;
			if (!(text2 == "-1"))
			{
				if (!(text2 == "999999"))
				{
					LoadCbbTinhTrang(GetIdFile());
				}
				else
				{
					MCommon.Common.ShowForm(new fChonThuMuc());
					if (!fChonThuMuc.isAdd || fChonThuMuc.lstChooseIdFiles == null || fChonThuMuc.lstChooseIdFiles.Count == 0)
					{
						isExcute_CbbThuMuc_SelectedIndexChanged = false;
						cbbThuMuc.SelectedIndex = ((indexCbbThuMucOld != -1) ? indexCbbThuMucOld : 0);
						isExcute_CbbThuMuc_SelectedIndexChanged = true;
					}
					else
					{
						LoadCbbTinhTrang(fChonThuMuc.lstChooseIdFiles);
					}
				}
			}
			else
			{
				LoadCbbTinhTrang();
			}
			indexCbbThuMucOld = cbbThuMuc.SelectedIndex;
			if (cbbThuMuc.SelectedValue != null)
			{
				string text3 = cbbThuMuc.SelectedValue.ToString();
				if (text3 == "-1" || text3 == "999999")
				{
					btnDeleteFile.BackColor = Color.Gray;
					btnDeleteFile.Enabled = false;
					btnEditFile.BackColor = Color.Gray;
					btnEditFile.Enabled = false;
				}
				else
				{
					btnDeleteFile.BackColor = Color.White;
					btnDeleteFile.Enabled = true;
					btnEditFile.BackColor = Color.White;
					btnEditFile.Enabled = true;
				}
			}
		}

		private void MailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail|passmail");
		}

		private void UidPassTokenCookieMailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie|mail|passmail");
		}

		private void CountTotalAccount()
		{
			try
			{
				lblCountTotal.Text = dtgvAcc.Rows.Count.ToString();
			}
			catch
			{
			}
		}

		private void CountCheckedAccount(int count = -1)
		{
			if (count == -1)
			{
				count = 0;
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						count++;
					}
				}
			}
			lblCountSelect.Text = count.ToString();
		}

		private void TạoProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng sư\u0309 du\u0323ng chư\u0301c năng Ta\u0323o profile khi Cha\u0323y tương ta\u0301c đê\u0309 gia\u0309m tô\u0301i đa ty\u0309 lê\u0323 checkpoint!"), 3);
		}

		private void KiemTraTaiKhoan(int type)
		{
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			string tokenTrungGian = setting_general.GetValue("token");
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				switch (type)
				{
				case 0:
				{
					int num4 = 0;
					while (num4 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row3 = num4++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row3, Language.GetValue("Đang kiểm tra..."));
									CheckMyWall(row3, tokenTrungGian);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num4++;
						}
					}
					break;
				}
				case 1:
				{
					int num6 = 0;
					while (num6 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num6].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row = num6++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
									CheckMyToken(row);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num6++;
						}
					}
					break;
				}
				case 2:
				{
					int num2 = 0;
					while (num2 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row5 = num2++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row5, Language.GetValue("Đang kiểm tra..."));
									CheckMyCookie(row5);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num2++;
						}
					}
					break;
				}
				case 3:
				{
					int num5 = 0;
					while (num5 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num5].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row2 = num5++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row2, Language.GetValue("Đang kiểm tra..."));
									CheckDangCheckpoint(row2);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num5++;
						}
					}
					break;
				}
				case 4:
				{
					int num3 = 0;
					while (num3 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row4 = num3++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row4, Language.GetValue("Đang kiểm tra..."));
									CheckAccountMail(row4);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num3++;
						}
					}
					break;
				}
				case 5:
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row6 = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row6, Language.GetValue("Đang kiểm tra..."));
									CheckInfoUid(row6);
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num++;
						}
					}
					break;
				}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 60000)
				{
					MCommon.Common.DelayTime(1.0);
				}
				cControl("stop");
			}).Start();
		}

		private void CheckInfoUid(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				if (!CheckIsUidFacebook(cellAccount2))
				{
					SetStatusAccount(row, Language.GetValue("Uid không hợp lệ!"));
					return;
				}
				string text = "";
				string text2 = CommonRequest.CheckInfoUsingUid(cellAccount2);
				if (text2.StartsWith("0|"))
				{
					if (CommonRequest.CheckLiveWall(cellAccount2).StartsWith("0|"))
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản Die!"));
						SetInfoAccount(cellAccount, row, "Die");
					}
					else
					{
						SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
					}
				}
				else if (text2.StartsWith("1|"))
				{
					string[] array = text2.Split('|');
					string text3 = array[2];
					string text4 = array[3].ToLower();
					string text5 = array[4];
					string text6 = array[5];
					string text7 = array[6];
					CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|friends|groups", text3 + "|" + text4 + "|" + text6 + "|" + text7);
					SetCellAccount(row, "cName", text3);
					SetCellAccount(row, "cGender", text4);
					SetCellAccount(row, "cFriend", text6);
					SetCellAccount(row, "cGroup", text7);
					if (text5 != "")
					{
						SetCellAccount(row, "cBirthday", text5);
						CommonSQL.UpdateFieldToAccount(cellAccount, "birthday", text5);
					}
					SetInfoAccount(cellAccount, row, "Live");
					text = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
					SetStatusAccount(row, text);
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckAccountMail(int row)
		{
			try
			{
				string text = "";
				string text2 = "";
				text = dtgvAcc.Rows[row].Cells["cEmail"].Value.ToString();
				text2 = dtgvAcc.Rows[row].Cells["cPassMail"].Value.ToString();
				if (text == "" || text2 == "")
				{
					SetStatusAccount(row, Language.GetValue("Không tìm thấy mail!"));
				}
				else if (text.EndsWith("@hotmail.com") || text.EndsWith("@outlook.com"))
				{
					string text3 = MCommon.Common.CheckAccountHotmail(text, text2);
					if (text3.Equals("1"))
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: live!"));
					}
					else
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: die!"));
					}
				}
				else if (text.EndsWith("@yandex.com"))
				{
					string text4 = MCommon.Common.CheckAccountEmail(text, text2, "imap.yandex.com");
					if (text4.Equals("1"))
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: live!"));
					}
					else
					{
						SetStatusAccount(row, Language.GetValue("Tài khoản mail: die!"));
					}
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Mail chưa hỗ trợ!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Lỗi!"));
			}
		}

		private void CheckMyWall(int row, string tokenTg)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				if (!CheckIsUidFacebook(cellAccount2))
				{
					SetStatusAccount(row, Language.GetValue("Uid không hợp lệ!"));
					return;
				}
				string text = "";
				string text2 = "";
				string text3 = CommonRequest.CheckLiveWall(cellAccount2);
				if (text3.StartsWith("0|"))
				{
					text = "Die";
					text2 = "Wall die";
				}
				else if (text3.StartsWith("1|"))
				{
					text = "Live";
					text2 = "Wall live";
				}
				else
				{
					text2 = Language.GetValue("Không check được!");
				}
				SetStatusAccount(row, text2);
				if (text != "")
				{
					SetInfoAccount(cellAccount, row, text);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckMyToken(int row)
		{
			try
			{
				string text = "";
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cCookies");
				string cellAccount3 = GetCellAccount(row, "cToken");
				if (cellAccount3.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Token trô\u0301ng!"));
					return;
				}
				string text2 = GetCellAccount(row, "cUseragent");
				string text3 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text3 = GetCellAccount(row, "cProxy");
					typeProxy = (text3.EndsWith("*1") ? 1 : 0);
					if (text3.EndsWith("*0") || text3.EndsWith("*1"))
					{
						text3 = text3.Substring(0, text3.Length - 2);
					}
				}
				if (text2 == "" && text3.Split(':').Length == 4)
				{
					text2 = Base.useragentDefault;
				}
				string text4 = "";
				if (!CommonRequest.CheckLiveToken(cellAccount2, cellAccount3, text2, text3, typeProxy))
				{
					text4 = "Token die";
				}
				else
				{
					text = "Live";
					text4 = "Token live";
				}
				SetStatusAccount(row, text4);
				if (text != "")
				{
					SetInfoAccount(cellAccount, row, text);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckMyCookie(int row)
		{
			try
			{
				string text = "";
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cCookies");
				if (cellAccount2.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Cookie trô\u0301ng!"));
					return;
				}
				string text2 = GetCellAccount(row, "cUseragent");
				string text3 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text3 = GetCellAccount(row, "cProxy");
					typeProxy = (text3.EndsWith("*1") ? 1 : 0);
					if (text3.EndsWith("*0") || text3.EndsWith("*1"))
					{
						text3 = text3.Substring(0, text3.Length - 2);
					}
				}
				if (text2 == "" && text3.Split(':').Length == 4)
				{
					text2 = Base.useragentDefault;
				}
				string text4 = "";
				if (!CommonRequest.CheckLiveCookie(cellAccount2, text2, text3, typeProxy).StartsWith("1|"))
				{
					text4 = "Cookie die";
				}
				else
				{
					text = "Live";
					text4 = "Cookie live";
				}
				SetStatusAccount(row, text4);
				if (text != "")
				{
					SetInfoAccount(cellAccount, row, text);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private void CheckDangCheckpoint(int row)
		{
			string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
			string email = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
			string pass = dtgvAcc.Rows[row].Cells["cPassword"].Value.ToString();
			string cellAccount = GetCellAccount(row, "cUseragent");
			string text = "";
			int typeProxy = 0;
			if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
			{
				text = GetCellAccount(row, "cProxy");
				typeProxy = (text.EndsWith("*1") ? 1 : 0);
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
			}
			if (cellAccount == "" && text.Split(':').Length == 4)
			{
				cellAccount = Base.useragentDefault;
			}
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = CommonRequest.CheckFacebookAccount(email, pass, "", text, typeProxy);
			switch (text5.Split('|')[0])
			{
			case "3":
				text2 = "Changed pass";
				break;
			case "2":
				text2 = ((!(text5.Split('|')[1].Trim() != "")) ? Language.GetValue("Checkpoint") : ("Checkpoint: " + text5.Split('|')[1]));
				break;
			case "1":
				text4 = text5.Split('|')[1];
				text2 = "Live";
				break;
			case "5":
				text3 = Language.GetValue("Không check đươ\u0323c (Co\u0301 2fa)!");
				break;
			case "0":
			case "4":
				text3 = Language.GetValue("Không check đươ\u0323c!");
				break;
			}
			if (text3 == "")
			{
				text3 = Language.GetValue("Đa\u0303 check xong!");
			}
			if (text4 != "")
			{
				SetCellAccount(row, "cCookies", text4);
				CommonSQL.UpdateFieldToAccount(id, "cookie1", text4);
			}
			if (text2 != "")
			{
				SetInfoAccount(id, row, text2);
				CommonSQL.UpdateFieldToAccount(id, "info", text2);
			}
			SetStatusAccount(row, text3);
		}

		private void KiểmTraWallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(0);
		}

		private void KiểmTraTokenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Tính năng này có thể khiến tài khoản bị khóa, bạn vẫn muốn sử dụng?")) == DialogResult.Yes)
			{
				KiemTraTaiKhoan(1);
			}
		}

		private void KiểmTraCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(2);
		}

		private void KiểmTraTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(3);
		}

		private void MailToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail");
		}

		private void BtnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbbSearch.SelectedIndex == -1)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn kiểu tìm kiếm!"), 3);
					return;
				}
				string columnName = cbbSearch.SelectedValue.ToString();
				string text = txbSearch.Text.Trim();
				if (text == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập nội dung tìm kiếm!"), 3);
					return;
				}
				List<int> list = new List<int>();
				text = MCommon.Common.ConvertToUnSign(text.ToLower());
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					string text2 = dtgvAcc.Rows[i].Cells[columnName].Value.ToString();
					text2 = MCommon.Common.ConvertToUnSign(text2.ToLower());
					text = MCommon.Common.ConvertToUnSign(text.ToLower());
					if (text2.Contains(text))
					{
						list.Add(i);
					}
				}
				int index = 0;
				int num = -1;
				try
				{
					num = dtgvAcc.CurrentRow.Index;
				}
				catch
				{
					num = -1;
				}
				if (list.Count <= 0)
				{
					return;
				}
				if (num >= list[list.Count - 1])
				{
					index = 0;
				}
				else
				{
					for (int j = 0; j < list.Count; j++)
					{
						if (num < list[j])
						{
							index = j;
							break;
						}
					}
				}
				int index2 = list[index];
				dtgvAcc.CurrentCell = dtgvAcc.Rows[index2].Cells[columnName];
				dtgvAcc.ClearSelection();
				dtgvAcc.Rows[index2].Selected = true;
			}
			catch (Exception)
			{
			}
		}

		private void UidPassTokenCookieMailPassMail2faToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie|mail|passmail|fa2");
		}

		private void UpdateSttOnDatatable()
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				SetCellAccount(i, "cSTT", i + 1);
			}
		}

		private void BtnShare_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.CreateFolder("maxshare");
				if (File.Exists(Application.StartupPath + "\\maxshare\\MaxShare.exe"))
				{
					CommonIniFile commonIniFile = new CommonIniFile(Application.StartupPath + "\\maxshare\\update.ini");
					string text = commonIniFile.Read("Version", "Infor");
					double num = Convert.ToDouble(text.Replace(".", "").Insert(1, "."));
					if (num < 3.66)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cập nhật phiên bản mới để sử dụng!"));
						Process.Start(Application.StartupPath + "\\maxshare\\AutoUpdate.exe");
						return;
					}
					List<string> list = new List<string>();
					for (int i = 0; i < dtgvAcc.RowCount; i++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
						{
							DataGridViewRow dataGridViewRow = dtgvAcc.Rows[i];
							try
							{
								list.Add("True||" + dataGridViewRow.Cells["cUid"].Value.ToString() + "|" + dataGridViewRow.Cells["cPassword"].Value.ToString() + "|" + dataGridViewRow.Cells["cFa2"].Value.ToString() + "|" + dataGridViewRow.Cells["cToken"].Value.ToString() + "|" + dataGridViewRow.Cells["cCookies"].Value.ToString() + "|" + dataGridViewRow.Cells["cProxy"].Value.ToString() + "|" + dataGridViewRow.Cells["cUseragent"].Value.ToString());
							}
							catch
							{
							}
						}
					}
					File.WriteAllLines("maxshare\\configsshare\\data.txt", list);
					Process process = new Process();
					process.StartInfo.FileName = Application.StartupPath + "\\maxshare\\MaxShare.exe";
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					setting_general = new JSON_Settings("configGeneral");
					string text2 = setting_general.GetValue("txbPathProfile");
					if (!text2.Contains('\\'))
					{
						text2 = Application.StartupPath + "\\" + ((setting_general.GetValue("txbPathProfile") == "") ? "profiles" : setting_general.GetValue("txbPathProfile"));
					}
					process.StartInfo.Arguments = Base.checkLisence + " \"" + text2 + "\" " + Base.codeKeyRandom;
					process.Start();
				}
				else if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Chư\u0301c năng na\u0300y hiê\u0323n chưa co\u0301 să\u0303n, ba\u0323n co\u0301 muô\u0301n ta\u0309i xuô\u0301ng?")) == DialogResult.Yes)
				{
					Base.softname = "maxshare";
					MCommon.Common.ShowForm(new frm_progress());
					BtnShare_Click(null, null);
				}
			}
			catch (Exception)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 sư\u0309 du\u0323ng chư\u0301c năng na\u0300y!"), 2);
			}
		}

		private void BtnPost_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.CreateFolder("maxpost");
				if (File.Exists(Application.StartupPath + "\\maxpost\\MaxPost.exe"))
				{
					CommonIniFile commonIniFile = new CommonIniFile(Application.StartupPath + "\\maxpost\\update.ini");
					string text = commonIniFile.Read("Version", "maxpost");
					double num = Convert.ToDouble(text.Replace(".", "").Insert(1, "."));
					if (num < 3.66)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cập nhật phiên bản mới để sử dụng!"));
						Process.Start(Application.StartupPath + "\\maxpost\\AutoUpdate.exe");
						return;
					}
					List<string> list = new List<string>();
					for (int i = 0; i < dtgvAcc.RowCount; i++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
						{
							DataGridViewRow dataGridViewRow = dtgvAcc.Rows[i];
							try
							{
								list.Add("True||" + dataGridViewRow.Cells["cUid"].Value.ToString() + "|" + dataGridViewRow.Cells["cPassword"].Value.ToString() + "|" + dataGridViewRow.Cells["cFa2"].Value.ToString() + "|" + dataGridViewRow.Cells["cToken"].Value.ToString() + "|" + dataGridViewRow.Cells["cCookies"].Value.ToString() + "|" + dataGridViewRow.Cells["cProxy"].Value.ToString() + "|" + dataGridViewRow.Cells["cUseragent"].Value.ToString());
							}
							catch
							{
							}
						}
					}
					File.WriteAllLines("maxpost\\configspost\\data.txt", list);
					Process process = new Process();
					process.StartInfo.FileName = Application.StartupPath + "\\maxpost\\MaxPost.exe";
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					setting_general = new JSON_Settings("configGeneral");
					string text2 = setting_general.GetValue("txbPathProfile");
					if (!text2.Contains('\\'))
					{
						text2 = Application.StartupPath + "\\" + ((setting_general.GetValue("txbPathProfile") == "") ? "profiles" : setting_general.GetValue("txbPathProfile"));
					}
					process.StartInfo.Arguments = Base.checkLisence + " \"" + text2 + "\" " + Base.codeKeyRandom;
					process.Start();
				}
				else if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Chư\u0301c năng na\u0300y hiê\u0323n chưa co\u0301 să\u0303n, ba\u0323n co\u0301 muô\u0301n ta\u0309i xuô\u0301ng?")) == DialogResult.Yes)
				{
					Base.softname = "maxpost";
					MCommon.Common.ShowForm(new frm_progress());
					BtnPost_Click(null, null);
				}
			}
			catch (Exception)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 sư\u0309 du\u0323ng chư\u0301c năng na\u0300y!"), 2);
			}
		}

		private void BtnViewLivestream_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.CreateFolder("maxviewlivestream");
				if (File.Exists(Application.StartupPath + "\\maxviewlivestream\\MaxViewLivestream.exe"))
				{
					CommonIniFile commonIniFile = new CommonIniFile(Application.StartupPath + "\\maxviewlivestream\\update.ini");
					string text = commonIniFile.Read("Version", "maxviewlivestream");
					double num = Convert.ToDouble(text.Replace(".", "").Insert(1, "."));
					if (num < 3.66)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cập nhật phiên bản mới để sử dụng!"));
						Process.Start(Application.StartupPath + "\\maxviewlivestream\\AutoUpdate.exe");
						return;
					}
					List<string> list = new List<string>();
					for (int i = 0; i < dtgvAcc.RowCount; i++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
						{
							DataGridViewRow dataGridViewRow = dtgvAcc.Rows[i];
							try
							{
								list.Add("True||" + dataGridViewRow.Cells["cUid"].Value.ToString() + "|" + dataGridViewRow.Cells["cPassword"].Value.ToString() + "|" + dataGridViewRow.Cells["cFa2"].Value.ToString() + "|" + dataGridViewRow.Cells["cToken"].Value.ToString() + "|" + dataGridViewRow.Cells["cCookies"].Value.ToString() + "|" + dataGridViewRow.Cells["cProxy"].Value.ToString() + "|" + dataGridViewRow.Cells["cUseragent"].Value.ToString());
							}
							catch
							{
							}
						}
					}
					File.WriteAllLines("maxviewlivestream\\configs\\data.txt", list);
					Process process = new Process();
					process.StartInfo.FileName = Application.StartupPath + "\\maxviewlivestream\\MaxViewLivestream.exe";
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					setting_general = new JSON_Settings("configGeneral");
					string text2 = setting_general.GetValue("txbPathProfile");
					if (!text2.Contains('\\'))
					{
						text2 = Application.StartupPath + "\\" + ((setting_general.GetValue("txbPathProfile") == "") ? "profiles" : setting_general.GetValue("txbPathProfile"));
					}
					process.StartInfo.Arguments = Base.checkLisence + " \"" + text2 + "\" " + Base.codeKeyRandom;
					process.Start();
				}
				else if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Chư\u0301c năng na\u0300y hiê\u0323n chưa co\u0301 să\u0303n, ba\u0323n co\u0301 muô\u0301n ta\u0309i xuô\u0301ng?")) == DialogResult.Yes)
				{
					Base.softname = "maxviewlivestream";
					MCommon.Common.ShowForm(new frm_progress());
					BtnViewLivestream_Click(null, null);
				}
			}
			catch (Exception)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 sư\u0309 du\u0323ng chư\u0301c năng na\u0300y!"));
			}
		}

		private void fAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("2fa");
		}

		private void checkAvatarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fNhapTokenTrungGian());
			if (!fNhapTokenTrungGian.isOK)
			{
				return;
			}
			LoadSetting();
			string token = setting_general.GetValue("token");
			if (!CommonRequest.CheckLiveToken("", token, "", ""))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại token trung gian!"), 3);
				return;
			}
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					Application.DoEvents();
					if (isStop)
					{
						break;
					}
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								CheckMyAvatar(row, token);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 30000)
				{
					Application.DoEvents();
					Thread.Sleep(300);
				}
				cControl("stop");
			}).Start();
		}

		private void CheckMyAvatar(int row, string token)
		{
			try
			{
				string uid = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				if (CommonRequest.CheckAvatarFromUid(uid, token))
				{
					SetStatusAccount(row, Language.GetValue("Đa\u0303 co\u0301 avatar!"));
					SetCellAccount(row, "cAvatar", "Yes");
					CommonSQL.UpdateFieldToAccount(id, "avatar", "Yes");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Không co\u0301 avatar!"));
					SetCellAccount(row, "cAvatar", "No");
					CommonSQL.UpdateFieldToAccount(id, "avatar", "No");
				}
			}
			catch
			{
				SetStatusAccount(row, "Lỗi!");
			}
		}

		private void locTrungToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num = 0;
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					continue;
				}
				try
				{
					string cellAccount = GetCellAccount(i, "cUid");
					if (list2.Contains(cellAccount))
					{
						list.Add(dtgvAcc.Rows[i].Cells["cId"].Value.ToString());
						dtgvAcc.Rows.RemoveAt(i);
						i--;
						num++;
					}
					else
					{
						list2.Add(cellAccount);
					}
				}
				catch
				{
				}
			}
			CommonSQL.DeleteAccountToDatabase(list);
			UpdateSttOnDatatable();
			CountTotalAccount();
			CountCheckedAccount();
			MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đã loại bỏ {0} tài khoản bị trùng!"), num));
		}

		private void đăngNhâpBăngUidpassToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void đăngNhâpBăngCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void xóaProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có chắc muốn xóa Profile của {0} tài khoản?"), CountChooseRowInDatagridview())) != DialogResult.Yes)
			{
				return;
			}
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang xo\u0301a profile..."));
								DeleteProfile(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void DeleteProfile(int row)
		{
			try
			{
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(id, "profile", "No");
					return;
				}
				string path = "profile\\" + text;
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
					SetStatusAccount(row, Language.GetValue("Xóa profile thành công!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(id, "profile", "No");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Xóa profile thất bại!"));
			}
		}

		private void checkProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			string profilePath = ConfigHelper.GetPathProfile();
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.RowCount)
				{
					if (Convert.ToBoolean(GetCellAccount(num, "cChose")))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, "Check profile...");
								CheckProfile(row, profilePath);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void CheckProfile(int row, string profilePath)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				profilePath = profilePath + "\\" + cellAccount2;
				if (Directory.Exists(profilePath))
				{
					SetStatusAccount(row, Language.GetValue("Đã có profile!"));
					SetCellAccount(row, "cProfile", "Yes");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "No");
				}
			}
			catch
			{
			}
		}

		private void donDepProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.ShowForm(new fClearProfile());
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(ex.ToString(), 3);
			}
		}

		public void CloseProcess(string nameProcess)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(nameProcess);
				foreach (Process process in processesByName)
				{
					process.Kill();
				}
			}
			catch
			{
			}
		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			CloseProcess("Chrome");
		}

		private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		}

		private void uidPass2FaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|2fa");
		}

		private void mnuCauHinhChung_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCauHinhChung());
		}

		private void đinhDangKhacToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.RowCount; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						string text = GetCellAccount(i, "cProxy");
						if (text.EndsWith("*0") || text.EndsWith("*1"))
						{
							text = text.Substring(0, text.Length - 2);
						}
						list.Add(GetCellAccount(i, "cUid") + "|" + GetCellAccount(i, "cPassword") + "|" + GetCellAccount(i, "cToken") + "|" + GetCellAccount(i, "cCookies") + "|" + GetCellAccount(i, "cEmail") + "|" + GetCellAccount(i, "cPassMail") + "|" + GetCellAccount(i, "cFa2") + "|" + GetCellAccount(i, "cUseragent") + "|" + text + "|" + GetCellAccount(i, "cName") + "|" + GetCellAccount(i, "cGender") + "|" + GetCellAccount(i, "cFollow") + "|" + GetCellAccount(i, "cFriend") + "|" + GetCellAccount(i, "cGroup") + "|" + GetCellAccount(i, "cBirthday") + "|" + GetCellAccount(i, "cDateCreateAcc") + "|" + GetCellAccount(i, "cDevice") + "|LDPlayer-" + GetCellAccount(i, "cDevice"));
					}
				}
				if (list.Count <= 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn danh sách tài khoản muốn copy thông tin!"), 3);
				}
				else
				{
					MCommon.Common.ShowForm(new fCopy(list));
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex, "Error Copy");
			}
		}

		private void maBaoMât6SôToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("ma2fa");
		}

		private void trạngTháiToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CapNhatThongTin(int type)
		{
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			string tokenTrungGian = setting_general.GetValue("token");
			string cookieTrungGian = setting_general.GetValue("cookie");
			if (type == 0 && !CommonRequest.CheckLiveToken("", tokenTrungGian, "", ""))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại token trung gian!"), 3);
				return;
			}
			if (type == 4 && CommonRequest.CheckLiveCookie(cookieTrungGian, "", "", 0).StartsWith("0|"))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại cookie trung gian!"), 3);
				return;
			}
			isStop = false;
			bool isTokenDie = false;
			bool isCookieDie = false;
			bool isChangeIPSuccess = false;
			int curChangeIp = 0;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				switch (type)
				{
				case 0:
				{
					int num3 = 0;
					while (num3 < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row2 = num3++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row2, Language.GetValue("Đang kiểm tra..."));
									if (!GetInfoUsingToken(row2, tokenTrungGian, isTokenTrungGian: true))
									{
										isStop = true;
										isTokenDie = true;
									}
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num3++;
						}
					}
					goto default;
				}
				case 1:
				{
					int num4 = 0;
					while (num4 < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							num4++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num4++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								GetInfoUsingToken(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9 || setting_general.GetValueInt("ip_iTypeChangeIp") == 10 || setting_general.GetValueInt("ip_iTypeChangeIp") == 11 || setting_general.GetValueInt("ip_iTypeChangeIp") == 12)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (isStop)
						{
							break;
						}
						Interlocked.Increment(ref curChangeIp);
						if (curChangeIp < Convert.ToInt32((setting_general.GetValue("ip_nudChangeIpCount") == "") ? "1" : setting_general.GetValue("ip_nudChangeIpCount")))
						{
							continue;
						}
						for (int j = 0; j < 3; j++)
						{
							isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValueInt("typeDcom"), setting_general.GetValue("ip_txtProfileNameDcom"), setting_general.GetValue("txtUrlHilink"), setting_general.GetValueInt("ip_cbbHostpot"), setting_general.GetValue("ip_txtNordVPN"));
							if (isChangeIPSuccess)
							{
								break;
							}
						}
						if (isChangeIPSuccess)
						{
							curChangeIp = 0;
							continue;
						}
						goto IL_0407;
					}
					goto default;
				}
				case 2:
				{
					int num2 = 0;
					while (num2 < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							num2++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row3 = num2++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row3, Language.GetValue("Đang kiểm tra..."));
								GetInfoUsingCookie(row3);
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9 || setting_general.GetValueInt("ip_iTypeChangeIp") == 10 || setting_general.GetValueInt("ip_iTypeChangeIp") == 11 || setting_general.GetValueInt("ip_iTypeChangeIp") == 12)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (isStop)
						{
							break;
						}
						Interlocked.Increment(ref curChangeIp);
						if (curChangeIp < Convert.ToInt32((setting_general.GetValue("ip_nudChangeIpCount") == "") ? "1" : setting_general.GetValue("ip_nudChangeIpCount")))
						{
							continue;
						}
						for (int i = 0; i < 3; i++)
						{
							isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValueInt("typeDcom"), setting_general.GetValue("ip_txtProfileNameDcom"), setting_general.GetValue("txtUrlHilink"), setting_general.GetValueInt("ip_cbbHostpot"), setting_general.GetValue("ip_txtNordVPN"));
							if (isChangeIPSuccess)
							{
								break;
							}
						}
						if (isChangeIPSuccess)
						{
							curChangeIp = 0;
							continue;
						}
						goto IL_071c;
					}
					goto default;
				}
				case 4:
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row4 = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row4, Language.GetValue("Đang kiểm tra..."));
									if (!GetInfoUsingCookieTrungGian(row4, cookieTrungGian))
									{
										isStop = true;
										isCookieDie = true;
									}
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Application.DoEvents();
								Thread.Sleep(200);
							}
						}
						else
						{
							num++;
						}
					}
					goto default;
				}
				default:
					{
						int tickCount = Environment.TickCount;
						while (iThread > 0 && Environment.TickCount - tickCount <= 60000)
						{
							MCommon.Common.DelayTime(1.0);
						}
						break;
					}
					IL_0407:
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
					break;
					IL_071c:
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
					break;
				}
				cControl("stop");
				if (isTokenDie)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Token trung gian die!"));
				}
				if (isCookieDie)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Cookie trung gian die!"));
				}
			}).Start();
		}

		private bool GetInfoUsingToken(int row, string token, bool isTokenTrungGian)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				string text = GetCellAccount(row, "cUseragent");
				string text2 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text2 = GetCellAccount(row, "cProxy");
					typeProxy = (text2.EndsWith("*1") ? 1 : 0);
					if (text2.EndsWith("*0") || text2.EndsWith("*1"))
					{
						text2 = text2.Substring(0, text2.Length - 2);
					}
				}
				if (text == "" && text2.Split(':').Length == 4)
				{
					text = Base.useragentDefault;
				}
				if (isTokenTrungGian)
				{
					text = "";
					text2 = "";
					typeProxy = 0;
				}
				string text3 = "";
				string text4 = "";
				if (cellAccount2 == "")
				{
					text4 = Language.GetValue("Không co\u0301 uid!");
				}
				else
				{
					string infoAccountFromUidUsingToken = CommonRequest.GetInfoAccountFromUidUsingToken(token, cellAccount2, text, text2, typeProxy);
					if (infoAccountFromUidUsingToken == "-1")
					{
						SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
						return false;
					}
					string[] array = infoAccountFromUidUsingToken.Split('|');
					if (Convert.ToBoolean(array[0]))
					{
						text3 = "Live";
						CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
						SetCellAccount(row, "cName", array[1]);
						SetCellAccount(row, "cGender", array[2]);
						SetCellAccount(row, "cBirthday", array[3]);
						if (array[5] != "")
						{
							SetCellAccount(row, "cEmail", array[5]);
						}
						SetCellAccount(row, "cFriend", array[6]);
						SetCellAccount(row, "cGroup", array[7]);
						text4 = "Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!";
					}
					else
					{
						text3 = "Die";
						text4 = Language.GetValue("Tài khoản die!");
					}
				}
				SetStatusAccount(row, text4);
				if (text3 != "")
				{
					SetInfoAccount(cellAccount, row, text3);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
			return true;
		}

		private void GetInfoUsingCookie(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cCookies");
				GetCellAccount(row, "cToken");
				string text = GetCellAccount(row, "cUseragent");
				string text2 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text2 = GetCellAccount(row, "cProxy");
					typeProxy = (text2.EndsWith("*1") ? 1 : 0);
					if (text2.EndsWith("*0") || text2.EndsWith("*1"))
					{
						text2 = text2.Substring(0, text2.Length - 2);
					}
				}
				if (text == "" && text2.Split(':').Length == 4)
				{
					text = Base.useragentDefault;
				}
				string text3 = "";
				string text4 = "";
				if (cellAccount2 == "")
				{
					text3 = Language.GetValue("Cookie trô\u0301ng");
				}
				else
				{
					string infoAccountFromUidUsingCookie = CommonRequest.GetInfoAccountFromUidUsingCookie(cellAccount2, text, text2, typeProxy);
					if (infoAccountFromUidUsingCookie == "-1")
					{
						text3 = "Cookie die";
					}
					else
					{
						string[] array = infoAccountFromUidUsingCookie.Split('|');
						if (Convert.ToBoolean(array[0]))
						{
							text4 = "Live";
							CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
							SetCellAccount(row, "cName", array[1]);
							SetCellAccount(row, "cGender", array[2]);
							SetCellAccount(row, "cBirthday", array[3]);
							if (array[5] != "")
							{
								SetCellAccount(row, "cEmail", array[5]);
							}
							SetCellAccount(row, "cFriend", array[6]);
							SetCellAccount(row, "cGroup", array[7]);
							text3 = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
						}
						else
						{
							text4 = "Die";
							text3 = Language.GetValue("Tài khoản die!");
						}
					}
				}
				SetStatusAccount(row, text3);
				if (text4 != "")
				{
					SetInfoAccount(cellAccount, row, text4);
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
		}

		private bool GetInfoUsingCookieTrungGian(int row, string cookie)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				string text = "";
				string infoAccountFromUidUsingCookieTrungGian = CommonRequest.GetInfoAccountFromUidUsingCookieTrungGian(cellAccount2, cookie);
				if (infoAccountFromUidUsingCookieTrungGian == "-1")
				{
					SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
					return false;
				}
				string[] array = infoAccountFromUidUsingCookieTrungGian.Split('|');
				if (Convert.ToBoolean(array[0]))
				{
					CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender", array[1] + "|" + array[2]);
					SetCellAccount(row, "cName", array[1]);
					SetCellAccount(row, "cGender", array[2]);
					if (array[6] != "")
					{
						SetCellAccount(row, "cFriend", array[6]);
						CommonSQL.UpdateFieldToAccount(cellAccount, "friends", array[6]);
					}
					if (array[7] != "")
					{
						SetCellAccount(row, "cGroup", array[7]);
						CommonSQL.UpdateFieldToAccount(cellAccount, "groups", array[7]);
					}
					SetInfoAccount(cellAccount, row, "Live");
					text = Language.GetValue("Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!");
				}
				else
				{
					SetInfoAccount(cellAccount, row, "Die");
					text = Language.GetValue("Tài khoản Die!");
				}
				SetStatusAccount(row, text);
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Không check đươ\u0323c!"));
			}
			return true;
		}

		private void UpdateInfoWhenInteracting(Chrome chrome, int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string infoAccountFromUidUsingCookie = CommonChrome.GetInfoAccountFromUidUsingCookie(chrome);
				if (!infoAccountFromUidUsingCookie.Contains("|"))
				{
					if (infoAccountFromUidUsingCookie == "-1")
					{
						SetInfoAccount(cellAccount, row, "Die");
					}
					return;
				}
				string[] array = infoAccountFromUidUsingCookie.Split('|');
				CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups|dateCreateAcc|follow" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + "|" + array[9] + "|" + array[10] + ((array[5] != "") ? ("|" + array[5]) : ""), isAllowEmptyValue: false);
				SetCellAccount(row, "cName", array[1], isAllowEmptyValue: false);
				SetCellAccount(row, "cGender", array[2], isAllowEmptyValue: false);
				SetCellAccount(row, "cBirthday", array[3], isAllowEmptyValue: false);
				SetCellAccount(row, "cEmail", array[5], isAllowEmptyValue: false);
				SetCellAccount(row, "cFriend", array[6], isAllowEmptyValue: false);
				SetCellAccount(row, "cGroup", array[7], isAllowEmptyValue: false);
				SetCellAccount(row, "cDateCreateAcc", array[9], isAllowEmptyValue: false);
				SetCellAccount(row, "cFollow", array[10], isAllowEmptyValue: false);
				SetInfoAccount(cellAccount, row, "Live");
			}
			catch
			{
			}
		}

		public int HDXoaThongBaoVPCS(int indexRow, string statusProxy, Chrome chrome, int typeDelete, bool isDeleteMessage, string tenHanhDong = "")
		{
			int num = 0;
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				if (typeDelete == 1 && Base.rd.Next(1, 11) > 7)
				{
					return 0;
				}
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + " " + tenHanhDong + "...");
				bool flag = false;
				for (int i = 0; i < 3; i++)
				{
					num = 0;
					CommonChrome.GoToNotifications(chrome);
					string cssSelector = chrome.GetCssSelector("a", "href", "/notifications.php?more");
					if (cssSelector != "" && chrome.Click(4, cssSelector) == 1)
					{
						chrome.DelayRandom(3, 5);
					}
					List<string> list = new List<string>();
					list = chrome.ExecuteScript("var y=[];var x=document.querySelectorAll('a'); for(i=0;i<x.length;i++){if(x[i].getAttribute('href')!=null && x[i].getAttribute('href').includes('/support/view_details/')) y.push(x[i].getAttribute('href'))};return y.join('|')").ToString().Split('|')
						.ToList();
					list = MCommon.Common.RemoveEmptyItems(list);
					if (list.Count == 0)
					{
						break;
					}
					for (int j = 0; j < list.Count; j++)
					{
						chrome.GotoURL("https://m.facebook.com" + list[j]);
						chrome.DelayRandom(2, 4);
						cssSelector = chrome.GetCssSelector("a", "href", "/si/actor_experience/action_experience");
						if (cssSelector != "")
						{
							chrome.Click(4, cssSelector);
							chrome.DelayRandom(2, 4);
							cssSelector = chrome.GetCssSelector("document.querySelector('span div[role=\"button\"]')");
							if (!(cssSelector != "") || chrome.Click(4, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).Substring(0, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).LastIndexOf('>'))) != 1)
							{
								continue;
							}
							chrome.DelayRandom(2, 4);
							cssSelector = chrome.GetCssSelector("document.querySelector('span div[role=\"button\"]')");
							if (cssSelector != "" && chrome.Click(4, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).Substring(0, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).LastIndexOf('>'))) == 1)
							{
								chrome.DelayRandom(2, 4);
							}
							if (chrome.CheckExistElement("[data-nt-switch-case='{\"v\":\"default\"}']", 4.0) != 1 || chrome.Click(4, "[data-nt-switch-case='{\"v\":\"default\"}']") != 1)
							{
								continue;
							}
							chrome.DelayRandom(2, 4);
							for (int k = 0; k < 5; k++)
							{
								cssSelector = chrome.GetCssSelector("document.querySelector('span div[role=\"button\"]')");
								if (!(cssSelector != "") || chrome.Click(4, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).Substring(0, cssSelector.Substring(0, cssSelector.LastIndexOf('>')).LastIndexOf('>'))) != 1)
								{
									break;
								}
								chrome.DelayRandom(2, 4);
							}
							continue;
						}
						if (isDeleteMessage)
						{
							cssSelector = chrome.GetCssSelector("a", "href", "/support/reporter/remove/");
							chrome.Click(4, cssSelector);
							chrome.DelayRandom(2, 4);
							if (chrome.CheckExistElement("[data-testid=\"supportInbox/confirmDialog/confirm\"]", 3.0) == 1 && chrome.Click(4, "[data-testid=\"supportInbox/confirmDialog/confirm\"]") == 1)
							{
								chrome.DelayRandom(2, 4);
							}
						}
						num++;
						if (num == list.Count)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		private void GetInfoUsingToken(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cToken");
				string text = GetCellAccount(row, "cUseragent");
				string text2 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text2 = GetCellAccount(row, "cProxy");
					typeProxy = (text2.EndsWith("*1") ? 1 : 0);
					if (text2.EndsWith("*0") || text2.EndsWith("*1"))
					{
						text2 = text2.Substring(0, text2.Length - 2);
					}
				}
				if (text == "" && text2.Split(':').Length == 4)
				{
					text = Base.useragentDefault;
				}
				string text3 = "";
				string text4 = "";
				if (cellAccount2 == "")
				{
					text4 = Language.GetValue("Token trô\u0301ng");
				}
				else
				{
					string infoAccountFromUidUsingToken = CommonRequest.GetInfoAccountFromUidUsingToken(cellAccount2, "", text, text2, typeProxy);
					if (infoAccountFromUidUsingToken == "-1")
					{
						text4 = "Token die";
					}
					else
					{
						string[] array = infoAccountFromUidUsingToken.Split('|');
						if (Convert.ToBoolean(array[0]))
						{
							text3 = "Live";
							CommonSQL.UpdateMultiFieldToAccount(cellAccount, "name|gender|birthday|friends|groups" + ((array[5] != "") ? "|email" : ""), array[1] + "|" + array[2] + "|" + array[3] + "|" + array[6] + "|" + array[7] + ((array[5] != "") ? ("|" + array[5]) : ""));
							SetCellAccount(row, "cName", array[1]);
							SetCellAccount(row, "cGender", array[2]);
							SetCellAccount(row, "cBirthday", array[3]);
							if (array[5] != "")
							{
								SetCellAccount(row, "cEmail", array[5]);
							}
							SetCellAccount(row, "cFriend", array[6]);
							SetCellAccount(row, "cGroup", array[7]);
						}
						else
						{
							text3 = "Die";
						}
						text4 = "Câ\u0323p nhâ\u0323t thông tin tha\u0300nh công!";
					}
				}
				SetStatusAccount(row, text4);
				if (text3 != "")
				{
					SetInfoAccount(cellAccount, row, text3);
				}
			}
			catch
			{
				SetStatusAccount(row, "Không check đươ\u0323c!");
			}
		}

		private void sưDungTokenTrungGianToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fNhapTokenTrungGian());
			if (fNhapTokenTrungGian.isOK)
			{
				CapNhatThongTin(0);
			}
		}

		private void sưDungTokenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CapNhatThongTin(1);
		}

		private void sưDungCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Tính năng này có thể khiến tài khoản bị khóa, bạn vẫn muốn sử dụng?")) == DialogResult.Yes)
			{
				CapNhatThongTin(2);
			}
		}

		private void BackupCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Tính năng này hiện tại đang chạy bằng Cookie nên rất dễ Die tài khoản!") + "\r\n" + Language.GetValue("Khuyến cáo nên sư\u0309 du\u0323ng chư\u0301c năng Backup khi Cha\u0323y tương ta\u0301c đê\u0309 gia\u0309m tô\u0301i đa ty\u0309 lê\u0323 checkpoint!") + "\r\n" + Language.GetValue("Bạn có chắc vẫn muốn sử dụng tính năng này?")) != DialogResult.Yes)
			{
				return;
			}
			LoadSetting();
			isStop = false;
			bool isChangeIPSuccess = false;
			int curChangeIp = 0;
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (true)
				{
					if (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							num++;
							continue;
						}
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								BackupAccountOneThread(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
							continue;
						}
						if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9 || setting_general.GetValueInt("ip_iTypeChangeIp") == 10 || setting_general.GetValueInt("ip_iTypeChangeIp") == 11 || setting_general.GetValueInt("ip_iTypeChangeIp") == 12)
						{
							MCommon.Common.DelayTime(1.0);
							continue;
						}
						while (iThread > 0)
						{
							MCommon.Common.DelayTime(1.0);
						}
						if (!isStop)
						{
							Interlocked.Increment(ref curChangeIp);
							if (curChangeIp >= Convert.ToInt32(setting_general.GetValueInt("ip_nudChangeIpCount", 1)))
							{
								for (int i = 0; i < 3; i++)
								{
									isChangeIPSuccess = MCommon.Common.ChangeIP(setting_general.GetValueInt("ip_iTypeChangeIp"), setting_general.GetValueInt("typeDcom"), setting_general.GetValue("ip_txtProfileNameDcom"), setting_general.GetValue("txtUrlHilink"), setting_general.GetValueInt("ip_cbbHostpot"), setting_general.GetValue("ip_txtNordVPN"));
									if (isChangeIPSuccess)
									{
										break;
									}
								}
								if (!isChangeIPSuccess)
								{
									MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 3);
									break;
								}
								curChangeIp = 0;
							}
							continue;
						}
					}
					_ = Environment.TickCount;
					while (iThread > 0)
					{
						MCommon.Common.DelayTime(1.0);
					}
					break;
				}
				cControl("stop");
			}).Start();
		}

		private List<string> GhepFileList(List<string> lstId, int soLuongAccMoiLan = 50, string separator = ",")
		{
			int num = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)lstId.Count * 1.0 / (double)soLuongAccMoiLan)));
			List<string> list = new List<string>();
			for (int i = 0; i < num; i++)
			{
				list.Add(string.Join(separator, lstId.GetRange(soLuongAccMoiLan * i, (soLuongAccMoiLan * i + soLuongAccMoiLan <= lstId.Count) ? soLuongAccMoiLan : (lstId.Count % soLuongAccMoiLan))));
			}
			return list;
		}

		private void BackupAccountOneThread(int row)
		{
			int indexRow = row;
			string text = "";
			string text2 = "";
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cookie = GetCellAccount(row, "cCookies");
				string token = GetCellAccount(row, "cToken");
				string cellAccount2 = GetCellAccount(row, "cUid");
				if (cellAccount2 == "")
				{
					cellAccount2 = Regex.Match(cookie, "c_user=(.*?);").Groups[1].Value;
				}
				string useragent = GetCellAccount(row, "cUseragent");
				string proxy = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					proxy = GetCellAccount(row, "cProxy");
					if (proxy.EndsWith("*1"))
					{
						typeProxy = 1;
					}
					else
					{
						typeProxy = 0;
					}
					if (proxy.EndsWith("*0") || proxy.EndsWith("*1"))
					{
						proxy = proxy.Substring(0, proxy.Length - 2);
					}
				}
				if (useragent == "" && proxy.Split(':').Length == 4)
				{
					useragent = Base.useragentDefault;
				}
				if (token == "" && CommonRequest.CheckLiveCookie(cookie, useragent, proxy, typeProxy).StartsWith("1|"))
				{
					token = CommonRequest.GetTokenEAAAAZ(cookie, useragent, proxy, typeProxy);
				}
				if (token != "" && CommonRequest.CheckLiveToken(cookie, token, useragent, proxy, typeProxy))
				{
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đang backup nga\u0300y sinh..."));
					string myBirthday = CommonRequest.GetMyBirthday(cookie, token, useragent, proxy, typeProxy);
					if (myBirthday == "-1")
					{
						DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", "Token die!");
						return;
					}
					cellAccount2 = myBirthday.Split('|')[0];
					text = myBirthday.Split('|')[1];
					text2 = myBirthday.Split('|')[2];
					lock (_lock)
					{
						Directory.CreateDirectory("backup\\" + cellAccount2);
						File.WriteAllText("backup\\" + cellAccount2 + "\\ngaysinh.txt", myBirthday);
					}
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đang backup a\u0309nh") + "...");
					List<string> listImageBackup = new List<string>();
					int iThread = 0;
					object _lock_countSuccess = new object();
					int countSuccess = 0;
					List<string> myListUidNameFriend = CommonRequest.GetMyListUidNameFriend(cookie, token, useragent, proxy, typeProxy);
					int totalFriend = myListUidNameFriend.Count;
					List<string> lstQuery = GhepFileList(myListUidNameFriend);
					_ = lstQuery.Count;
					new Thread((ThreadStart)delegate
					{
						while (iThread > 0)
						{
							DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đang backup ảnh") + ": " + countSuccess + "/" + totalFriend + "...");
							Thread.Sleep(100);
						}
					}).Start();
					if (lstQuery.Count > 0)
					{
						int num = ((lstQuery.Count > 10) ? 10 : lstQuery.Count);
						int num2 = 0;
						while (num2 < lstQuery.Count)
						{
							if (iThread < num)
							{
								Interlocked.Increment(ref iThread);
								int stt = num2++;
								new Thread((ThreadStart)delegate
								{
									string text4 = lstQuery[stt];
									List<string> list = CommonRequest.BackupImageOne(text4, cookie, token, useragent, proxy, typeProxy);
									if (list.Count > 0)
									{
										lock (listImageBackup)
										{
											listImageBackup.AddRange(list);
										}
									}
									lock (_lock_countSuccess)
									{
										countSuccess += text4.Split(',').Length;
									}
									Interlocked.Decrement(ref iThread);
								}).Start();
							}
							else
							{
								Thread.Sleep(100);
							}
						}
						while (iThread > 0)
						{
							Thread.Sleep(100);
						}
						if (listImageBackup.Count > 0)
						{
							lock (_lock2)
							{
								Directory.CreateDirectory("backup\\" + cellAccount2);
								File.WriteAllLines("backup\\" + cellAccount2 + "\\" + cellAccount2 + ".txt", listImageBackup);
							}
						}
						else
						{
							DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup đươ\u0323c!"));
						}
					}
					else
					{
						DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup đươ\u0323c!"));
					}
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Backup bình luận..."));
					List<string> myListComments = CommonRequest.GetMyListComments(cookie, useragent, proxy, typeProxy);
					lock (_lock3)
					{
						Directory.CreateDirectory("backup\\" + cellAccount2);
						File.WriteAllLines("backup\\" + cellAccount2 + "\\lscomment.txt", myListComments);
					}
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Backup nhă\u0301n tin gâ\u0300n đây..."));
					List<string> myListUidMessage = CommonRequest.GetMyListUidMessage(cookie, useragent, proxy, typeProxy);
					lock (_lock4)
					{
						Directory.CreateDirectory("backup\\" + cellAccount2);
						File.WriteAllLines("backup\\" + cellAccount2 + "\\banbeinbox.txt", myListUidMessage);
					}
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Đa\u0303 backup xong") + ": " + countSuccess + "!");
					string text3 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
					CommonSQL.UpdateMultiFieldToAccount(cellAccount, "uid|token|name|birthday|backup|info", cellAccount2 + "|" + token + "|" + text2 + "|" + text + "|" + text3 + "|Live", isAllowEmptyValue: false);
					SetCellAccount(indexRow, "cUid", cellAccount2);
					SetCellAccount(indexRow, "cToken", token);
					SetCellAccount(indexRow, "cName", text2, isAllowEmptyValue: false);
					SetCellAccount(indexRow, "cBirthday", text);
					SetCellAccount(indexRow, "cInfo", "Live");
					SetCellAccount(indexRow, "cBackup", text3);
				}
				else
				{
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Không backup được: Token/Cookie die!"));
				}
			}
			catch
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", Language.GetValue("Lỗi backup!"));
			}
		}

		private void LoadSetting()
		{
			setting_general = new JSON_Settings("configGeneral");
			setting_InteractGeneral = new JSON_Settings("configDangBai");
			setting_LDPlayer = new JSON_Settings("configLDPlayer");
		}

		private void dtgvAcc_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			List<string> list = new List<string> { "cStt", "cFriend", "cGroup", "cFollow" };
			if (list.Contains(e.Column.Name))
			{
				e.SortResult = int.Parse((e.CellValue1.ToString() == "") ? "-1" : e.CellValue1.ToString()).CompareTo(int.Parse((e.CellValue2.ToString() == "") ? "-1" : e.CellValue2.ToString()));
				e.Handled = true;
			}
			else
			{
				e.SortResult = ((e.CellValue1.ToString() == "") ? "" : e.CellValue1.ToString()).CompareTo((e.CellValue2.ToString() == "") ? "" : e.CellValue2.ToString());
				e.Handled = true;
			}
		}

		private void câuHinhHiênThiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fullString = new JSON_Settings("configDatagridview").GetFullString();
			MCommon.Common.ShowForm(new fCauHinhHienThi());
			if (fullString != new JSON_Settings("configDatagridview").GetFullString())
			{
				LoadConfigManHinh();
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (CountChooseRowInDatagridview() == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n như\u0303ng ta\u0300i khoa\u0309n muô\u0301n nhâ\u0323p Proxy!"), 3);
			}
			else
			{
				MCommon.Common.ShowForm(new fImportProxy());
			}
		}

		private void checkProxyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					Application.DoEvents();
					if (isStop)
					{
						break;
					}
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								CheckProxy(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 30000)
				{
					Application.DoEvents();
					Thread.Sleep(300);
				}
				cControl("stop");
			}).Start();
		}

		private void CheckProxy(int row)
		{
			try
			{
				string text = dtgvAcc.Rows[row].Cells["cProxy"].Value.ToString();
				int typeProxy = 0;
				if (text.EndsWith("*1"))
				{
					typeProxy = 1;
				}
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
				int num = 0;
				int num2 = 0;
				string text2 = "";
				bool flag = false;
				for (int i = 0; i < 10; i++)
				{
					text2 = MCommon.Common.CheckProxy(text, typeProxy);
					if (text2 != "")
					{
						num++;
						if (num == 3)
						{
							flag = true;
							break;
						}
					}
					else
					{
						num2++;
						if (num2 == 3)
						{
							break;
						}
					}
				}
				if (!flag)
				{
					SetStatusAccount(row, "Proxy Die!");
				}
				else
				{
					SetStatusAccount(row, "Proxy Live!");
				}
			}
			catch
			{
				SetStatusAccount(row, "Lỗi!");
			}
		}

		private void useragentToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("useragent");
		}

		private void proxyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("proxy");
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Alt)
			{
				try
				{
					Process.Start(Path.GetDirectoryName(Application.ExecutablePath));
				}
				catch
				{
				}
			}
		}

		private void cbbTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!isExcute_CbbTinhTrang_SelectedIndexChanged || cbbTinhTrang.SelectedValue == null || !StringHelper.CheckStringIsNumber(cbbTinhTrang.SelectedValue.ToString()) || (cbbTinhTrang.SelectedValue.ToString() != "-1" && indexCbbTinhTrangOld == cbbTinhTrang.SelectedIndex))
			{
				return;
			}
			string text = cbbThuMuc.SelectedValue.ToString();
			string text2 = text;
			if (!(text2 == "-1"))
			{
				if (!(text2 == "999999"))
				{
					LoadAccountFromFile(GetIdFile(), cbbTinhTrang.Text);
				}
				else
				{
					LoadAccountFromFile(fChonThuMuc.lstChooseIdFiles, cbbTinhTrang.Text);
				}
			}
			else
			{
				LoadAccountFromFile(null, cbbTinhTrang.Text);
			}
			indexCbbTinhTrangOld = cbbTinhTrang.SelectedIndex;
		}

		private void taoShortcutChromeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCauHinhTaoShortcut());
			if (!fCauHinhTaoShortcut.isOK)
			{
				return;
			}
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					Application.DoEvents();
					if (isStop)
					{
						break;
					}
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang ta\u0323o Shortcut..."));
								try
								{
									dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
									string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
									string text2 = dtgvAcc.Rows[row].Cells["cName"].Value.ToString();
									string nameShortcut = ((text2 == "") ? text : (text2 + "_" + text));
									string text3 = setting_general.GetValue("txbPathProfile") + "\\" + text;
									if (setting_general.GetValueBool("ckbUsePortable") && Directory.Exists(setting_general.GetValue("txbPathProfile") + "\\" + text + "\\Data\\profile"))
									{
										text3 = setting_general.GetValue("txbPathProfile") + "\\" + text + "\\Data\\profile";
									}
									if (Directory.Exists(text3))
									{
										if (CreateShortcutChrome(text3, nameShortcut))
										{
											SetStatusAccount(row, Language.GetValue("Ta\u0323o Shortcut thành công!"));
										}
										else
										{
											SetStatusAccount(row, Language.GetValue("Lô\u0303i ta\u0323o Shortcut!"));
										}
									}
									else
									{
										SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
									}
								}
								catch
								{
									SetStatusAccount(row, Language.GetValue("Lỗi!"));
								}
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 30000)
				{
					Application.DoEvents();
					Thread.Sleep(300);
				}
				cControl("stop");
			}).Start();
		}

		private bool CreateShortcutChrome(string profilePath, string nameShortcut)
		{
			try
			{
				nameShortcut = MCommon.Common.ConvertToUnSign(nameShortcut);
				if (profilePath.StartsWith("profiles\\"))
				{
					profilePath = Application.StartupPath + "\\" + profilePath;
				}
				string path = Application.StartupPath + "\\images\\chrome.ico";
				if (!File.Exists(path))
				{
					using FileStream outputStream = new FileStream(path, FileMode.Create);
					Resources.chrome.Save(outputStream);
				}
				if (MCommon.Common.CreateShortcutChrome(nameShortcut, setting_InteractGeneral.GetValue("txtPathShortcut"), profilePath, path, setting_InteractGeneral.GetValue("txtPathChromeOrigin")))
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void giưLaiProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteAccount(isDeleteProfile: false);
		}

		private void kiểmTraMailpassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(4);
		}

		private void đăngNhậpTrìnhDuyệtMớiToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void loginHotmailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoginMail();
		}

		private void LoginMail()
		{
			LoadSetting();
			List<int> lstPossition = new List<int>();
			for (int i = 0; i < CountChooseRowInDatagridview(); i++)
			{
				lstPossition.Add(0);
			}
			lstThread = new List<Thread>();
			new Thread((ThreadStart)delegate
			{
				try
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							int row = num++;
							Thread thread = new Thread((ThreadStart)delegate
							{
								int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
								LoginMailOneThread(row, indexOfPossitionApp);
							})
							{
								Name = row.ToString()
							};
							lstThread.Add(thread);
							thread.Start();
						}
						else
						{
							num++;
						}
					}
				}
				catch (Exception ex)
				{
					MCommon.Common.ExportError(null, ex, "LoginHotmail()");
				}
			}).Start();
		}

		private void LoginMailOneThread(int indexRow, int indexPos)
		{
			Chrome chrome = null;
			string cellAccount = GetCellAccount(indexRow, "cEmail");
			string cellAccount2 = GetCellAccount(indexRow, "cPassMail");
			try
			{
				SetStatusAccount(indexRow, Language.GetValue("Đang mơ\u0309 tri\u0300nh duyê\u0323t..."));
				Point pointFromIndexPosition = MCommon.Common.GetPointFromIndexPosition(indexPos, 5, 2);
				Point sizeChrome = MCommon.Common.GetSizeChrome(5, 2);
				bool flag = false;
				try
				{
					chrome = new Chrome
					{
						DisableImage = false,
						Size = sizeChrome,
						Position = pointFromIndexPosition,
						TimeWaitForSearchingElement = 3,
						TimeWaitForLoadingPage = 60
					};
					if (setting_general.GetValueInt("typeBrowser") != 0)
					{
						chrome.LinkToOtherBrowser = setting_general.GetValue("txtLinkToOtherBrowser");
					}
					if (!chrome.Open())
					{
						SetStatusAccount(indexRow, Language.GetValue("Lỗi mở trình duyệt!"));
						return;
					}
					SetStatusAccount(indexRow, Language.GetValue("Đang đăng nhâ\u0323p..."));
					if (cellAccount.Contains("hotmail") || cellAccount.Contains("outlook"))
					{
						chrome.GotoURL("https://login.live.com/login.srf");
						chrome.DelayTime(1.0);
						if (chrome.CheckExistElement("[name=\"loginfmt\"]", 10.0) == 1)
						{
							chrome.SendKeys(2, "loginfmt", cellAccount);
							chrome.DelayTime(0.1);
							chrome.Click(1, "idSIButton9");
							if (chrome.CheckExistElement("[name=\"passwd\"]", 10.0) == 1)
							{
								chrome.DelayTime(2.0);
								chrome.SendKeys(2, "passwd", cellAccount2);
								chrome.DelayTime(2.0);
								chrome.Click(1, "idSIButton9", 0, 0, "", 0, 10);
								for (int i = 0; i < 10; chrome.DelayTime(1.0), i++)
								{
									switch (chrome.CheckExistElements(0.0, "[name=\"DontShowAgain\"]", "#O365_MainLink_NavMenu"))
									{
									default:
										switch (chrome.CheckExistElements(0.0, "#idA_IL_ForgotPassword0", "[name=\"passwd\"]"))
										{
										case 2:
											SetStatusAccount(indexRow, Language.GetValue("Không có pass mail!"));
											return;
										case 1:
											SetStatusAccount(indexRow, Language.GetValue("Mail sai pass!"));
											return;
										}
										if (chrome.GetURL().Contains("https://account.live.com/Abuse"))
										{
											SetStatusAccount(indexRow, Language.GetValue("Mail đã bị khóa!"));
											return;
										}
										continue;
									case 1:
										chrome.Click(2, "DontShowAgain");
										chrome.DelayTime(0.1);
										chrome.Click(1, "idSIButton9");
										break;
									case 2:
										break;
									}
									break;
								}
								if (!chrome.GetURL().StartsWith("https://outlook.live.com"))
								{
									chrome.GotoURL("https://outlook.live.com/mail/0/");
								}
								flag = true;
							}
						}
					}
					else if (cellAccount.Contains("yandex"))
					{
						chrome.GotoURL("https://passport.yandex.com/auth?from=mail&origin=hostroot_homer_auth_com&retpath=https%3A%2F%2Fmail.yandex.com%2F&backpath=https%3A%2F%2Fmail.yandex.com%3Fnoretpath%3D1");
						chrome.DelayTime(1.0);
						if (chrome.CheckExistElement("#passp-field-login", 10.0) == 1)
						{
							chrome.SendKeys(1, "passp-field-login", cellAccount);
							chrome.DelayTime(0.1);
							chrome.Click(4, ".Button2_type_submit");
							if (chrome.CheckExistElement("#passp-field-passwd", 10.0) == 1)
							{
								chrome.SendKeys(1, "passp-field-passwd", cellAccount2);
								chrome.DelayTime(0.1);
								chrome.Click(4, ".Button2_type_submit");
								while (true)
								{
									switch (chrome.CheckExistElements(10.0, ".mail-ComposeButton", ".Textinput-Hint_state_error", "[data-t=\"phone_skip\"]"))
									{
									case 3:
										goto IL_0566;
									case 1:
										flag = true;
										break;
									}
									break;
									IL_0566:
									chrome.DelayTime(1.0);
									chrome.Click(4, "[data-t=\"phone_skip\"]");
									chrome.DelayTime(2.0);
								}
							}
						}
					}
					else
					{
						chrome.GotoURL("https://outlook.office.com/mail/inbox");
						chrome.DelayTime(1.0);
						if (chrome.CheckExistElement("[name=\"loginfmt\"]", 10.0) == 1)
						{
							chrome.SendKeys(2, "loginfmt", cellAccount);
							chrome.DelayTime(0.1);
							chrome.Click(1, "idSIButton9");
							if (chrome.CheckExistElement("[name=\"passwd\"]", 10.0) == 1)
							{
								chrome.SendKeys(2, "passwd", cellAccount2);
								chrome.DelayTime(2.0);
								chrome.Click(1, "idSIButton9", 0, 0, "", 0, 10);
								int num = chrome.CheckExistElements(10.0, "[name=\"DontShowAgain\"]", "#O365_MainLink_NavMenu");
								int num2 = num;
								int num3 = num2;
								if (num3 == 1)
								{
									chrome.Click(2, "DontShowAgain");
									chrome.DelayTime(0.1);
									chrome.Click(1, "idSIButton9");
								}
								chrome.GotoURLIfNotExist("https://outlook.office.com/mail/inbox");
								flag = true;
							}
						}
					}
					if (flag)
					{
						SetStatusAccount(indexRow, Language.GetValue("Đăng nhâ\u0323p thành công!"));
					}
				}
				catch (Exception ex)
				{
					SetStatusAccount(indexRow, Language.GetValue("Lô\u0303i đăng nhâ\u0323p!"));
					MCommon.Common.ExportError(chrome, ex, "Login Error!");
				}
			}
			catch (Exception ex2)
			{
				SetStatusAccount(indexRow, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				MCommon.Common.ExportError(chrome, ex2);
			}
		}

		private void metroButton2_Click(object sender, EventArgs e)
		{
			RandomThuTuTaiKhoan();
		}

		private void RandomThuTuTaiKhoan(int soLuot = 1)
		{
			try
			{
				for (int i = 0; i < soLuot; i++)
				{
					if (dtgvAcc.RowCount <= 1)
					{
						continue;
					}
					List<DataGridViewRow> list = new List<DataGridViewRow>();
					foreach (DataGridViewRow item in (IEnumerable)dtgvAcc.Rows)
					{
						list.Add(item);
					}
					int num = list.Count;
					while (num > 1)
					{
						num--;
						int index = Base.rd.Next(num + 1);
						DataGridViewRow value = list[index];
						list[index] = list[num];
						list[num] = value;
					}
					dtgvAcc.Rows.Clear();
					foreach (DataGridViewRow item2 in list)
					{
						dtgvAcc.Rows.Add(item2);
					}
				}
			}
			catch
			{
			}
		}

		public int CountChooseRowInDatagridview()
		{
			int result = 0;
			try
			{
				result = Convert.ToInt32(lblCountSelect.Text);
			}
			catch
			{
			}
			return result;
		}

		private void xóaDữLiệuBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có chắc muốn xóa dữ liệu backup của {0} tài khoản?"), CountChooseRowInDatagridview())) != DialogResult.Yes)
			{
				return;
			}
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang xo\u0301a dữ liệu backup..."));
								DeleteBackup(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void DeleteBackup(int row)
		{
			try
			{
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup!"));
					return;
				}
				string path = "backup\\" + text;
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
					SetStatusAccount(row, Language.GetValue("Xóa dữ liệu backup thành công!"));
					SetCellAccount(row, "cBackup", "");
					CommonSQL.UpdateFieldToAccount(id, "backup", "");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Xóa dữ liệu backup thất bại!"));
			}
		}

		private void checkBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			string pathBackup = ConfigHelper.GetPathBackup();
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, "Check backup...");
								CheckBackup(row, pathBackup);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void CheckBackup(int row, string backupPath)
		{
			try
			{
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				backupPath = backupPath + "\\" + text + "\\" + text + ".txt";
				if (File.Exists(backupPath))
				{
					SetStatusAccount(row, Language.GetValue("Đã backup!"));
					SetCellAccount(row, "cBackup", MCommon.Common.GetDateCreatFile(backupPath));
					CommonSQL.UpdateFieldToAccount(id, "backup", MCommon.Common.GetDateCreatFile(backupPath));
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup!"));
					SetCellAccount(row, "cBackup", "");
					CommonSQL.UpdateFieldToAccount(id, "backup", "");
				}
			}
			catch
			{
			}
		}

		private void checkInfoUIDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(5);
		}

		private void tảiXuốngAvatarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fNhapTokenTrungGian_DownAvatar());
			if (!fNhapTokenTrungGian_DownAvatar.isOK)
			{
				return;
			}
			LoadSetting();
			string token = setting_general.GetValue("token");
			if (!CommonRequest.CheckLiveToken("", token, "", ""))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại token trung gian!"), 2);
				return;
			}
			string pathFolder = setting_general.GetValue("pathFolderAvatar");
			if (!Directory.Exists(pathFolder))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại Nơi lưu Avatar!"), 2);
				return;
			}
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			isStop = false;
			new Thread((ThreadStart)delegate
			{
				cControl("start");
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					Application.DoEvents();
					if (isStop)
					{
						break;
					}
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								DownloadAvatar(row, token, pathFolder);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
				int tickCount = Environment.TickCount;
				while (iThread > 0 && Environment.TickCount - tickCount <= 30000)
				{
					Application.DoEvents();
					Thread.Sleep(300);
				}
				cControl("stop");
			}).Start();
		}

		private void DownloadAvatar(int row, string token, string pathFolder)
		{
			try
			{
				string uid = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				if (CommonRequest.DownLoadImageByUid(uid, token, pathFolder))
				{
					SetStatusAccount(row, Language.GetValue("Tải xuống thành công!"));
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Tải xuống thất bại!"));
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex, "DownloadAvatar");
				SetStatusAccount(row, Language.GetValue("Tải xuống thất bại!"));
			}
		}

		private void taiKhoanĐaXoaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fBin());
		}

		private void xóaCacheToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có chắc muốn xóa Cache Profile của {0} tài khoản?"), CountChooseRowInDatagridview())) != DialogResult.Yes)
			{
				return;
			}
			LoadSetting();
			int iThread = 0;
			int maxThread = setting_general.GetValueInt("nudHideThread", 10);
			new Thread((ThreadStart)delegate
			{
				int num = 0;
				while (num < dtgvAcc.Rows.Count)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
					{
						if (iThread < maxThread)
						{
							Interlocked.Increment(ref iThread);
							int row = num++;
							new Thread((ThreadStart)delegate
							{
								SetStatusAccount(row, Language.GetValue("Đang xo\u0301a Cache Profile..."));
								DeleteCacheProfile(row);
								Interlocked.Decrement(ref iThread);
							}).Start();
						}
						else
						{
							Application.DoEvents();
							Thread.Sleep(200);
						}
					}
					else
					{
						num++;
					}
				}
			}).Start();
		}

		private void DeleteCacheProfile(int row)
		{
			try
			{
				dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
					return;
				}
				string text2 = setting_general.GetValue("txbPathProfile") + "\\" + text;
				if (Directory.Exists(text2))
				{
					Directory.Delete(text2 + "\\Default\\Cache", recursive: true);
					SetStatusAccount(row, Language.GetValue("Xóa Cache Profile thành công!"));
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
				}
			}
			catch
			{
				SetStatusAccount(row, Language.GetValue("Xóa Cache Profile thất bại!"));
			}
		}

		private void lọcTrùngDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fTienIchLocTrung());
		}

		private void xửLýChuỗiOnlineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("chrome.exe", "http://app.minsoftware.vn/textfree.html");
			}
			catch
			{
				Process.Start("http://app.minsoftware.vn/textfree.html");
			}
		}

		private void checkCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void checkHotmailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fTienIchCheckImapHotmail());
		}

		private void dtgvAcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				dtgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dtgvAcc.CurrentRow.Cells["cChose"].Value);
				CountCheckedAccount();
			}
			catch
			{
			}
		}

		private void quảnLýThưMụcToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void metroButton2_Click_1(object sender, EventArgs e)
		{
			List<string> idFile = GetIdFile();
			if (idFile != null && idFile.Count == 1)
			{
				fEditFile fEditFile2 = new fEditFile(idFile[0], cbbThuMuc.Text);
				fEditFile2.ShowInTaskbar = false;
				fEditFile2.ShowDialog();
				int selectedIndex = cbbThuMuc.SelectedIndex;
				if (fEditFile2.isSuccess)
				{
					LoadCbbThuMuc();
					indexCbbThuMucOld = -1;
					cbbThuMuc.SelectedIndex = selectedIndex;
				}
			}
		}

		private void checkProxyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fTienIchCheckProxy());
		}

		private void sửDụngCookieTrungGianToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fNhapCookieTrungGian());
			if (fNhapCookieTrungGian.isOK)
			{
				CapNhatThongTin(4);
			}
		}

		private void lToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fLocTheoDanhSachUid());
			if (fLocTheoDanhSachUid.lstUID.Count > 0)
			{
				List<string> lstUid = MCommon.Common.CloneList(fLocTheoDanhSachUid.lstUID);
				DataTable accFromUid = CommonSQL.GetAccFromUid(lstUid);
				dtgvAcc.Rows.Clear();
				LoadDtgvAccFromDatatable(accFromUid);
			}
		}

		private void càiĐặtToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fShareBai_CauHinh());
		}

		public void SetStatusAccount(int indexRow, string value, Device device = null)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", value);
			if (device != null)
			{
				if (value.StartsWith("("))
				{
					value = value.Substring(value.IndexOf(")") + 1);
				}
				device.LoadHanhDongLD(value);
			}
		}

		public void SetInfoAccount(string id, int indexRow, string value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cInfo", value);
			SetRowColor(indexRow);
			CommonSQL.UpdateFieldToAccount(id, "info", value);
		}

		public void SetCellAccount(int indexRow, string column, object value, bool isAllowEmptyValue = true)
		{
			if (isAllowEmptyValue || !(value.ToString().Trim() == ""))
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, column, value);
			}
		}

		public void SetCellAccount(int indexRow, int column, object value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, column, value);
		}

		public string GetStatusAccount(int indexRow)
		{
			string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, "cStatus");
			if (statusDataGridView.StartsWith("("))
			{
				return statusDataGridView.Substring(statusDataGridView.IndexOf(')') + 1).Trim();
			}
			return statusDataGridView;
		}

		public string GetInfoAccount(int indexRow)
		{
			return DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, "cInfo");
		}

		public string GetCellAccount(int indexRow, string column)
		{
			return DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, column);
		}

		public string GetCellAccount(int indexRow, int column)
		{
			return DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, column);
		}

		private void SetRowColor(int indexRow = -1)
		{
			LoadSetting();
			if (setting_general.GetValueInt("typePhanBietMau") == 0)
			{
				if (indexRow == -1)
				{
					for (int i = 0; i < dtgvAcc.RowCount; i++)
					{
						string infoAccount = GetInfoAccount(i);
						if (infoAccount == "Live")
						{
							dtgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
						}
						else if (infoAccount.Contains("Die") || infoAccount.Contains(Language.GetValue("Checkpoint")) || infoAccount.Contains("Changed pass"))
						{
							dtgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
						}
					}
				}
				else
				{
					string infoAccount2 = GetInfoAccount(indexRow);
					if (infoAccount2 == "Live")
					{
						dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
					}
					else if (infoAccount2.Contains("Die") || infoAccount2.Contains(Language.GetValue("Checkpoint")) || infoAccount2.Contains("Changed pass"))
					{
						dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
					}
				}
			}
			else if (indexRow == -1)
			{
				for (int j = 0; j < dtgvAcc.RowCount; j++)
				{
					string infoAccount3 = GetInfoAccount(j);
					if (infoAccount3 == "Live")
					{
						dtgvAcc.Rows[j].DefaultCellStyle.ForeColor = Color.Green;
					}
					else if (infoAccount3.Contains("Die") || infoAccount3.Contains(Language.GetValue("Checkpoint")) || infoAccount3.Contains("Changed pass"))
					{
						dtgvAcc.Rows[j].DefaultCellStyle.ForeColor = Color.Red;
					}
				}
			}
			else
			{
				string infoAccount4 = GetInfoAccount(indexRow);
				if (infoAccount4 == "Live")
				{
					dtgvAcc.Rows[indexRow].DefaultCellStyle.ForeColor = Color.Green;
				}
				else if (infoAccount4.Contains("Die") || infoAccount4.Contains(Language.GetValue("Checkpoint")) || infoAccount4.Contains("Changed pass"))
				{
					dtgvAcc.Rows[indexRow].DefaultCellStyle.ForeColor = Color.Red;
				}
			}
		}

		private void SetRowColor(int indexRow, int typeColor)
		{
			switch (typeColor)
			{
			case 2:
				dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
				break;
			case 1:
				dtgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
				break;
			}
		}

		private void LoadConfigManHinh()
		{
			setting_ShowDtgv = new JSON_Settings("configDatagridview");
			dtgvAcc.Columns["cToken"].Visible = setting_ShowDtgv.GetValueBool("cToken");
			dtgvAcc.Columns["cCookies"].Visible = setting_ShowDtgv.GetValueBool("ckbCookie");
			dtgvAcc.Columns["cEmail"].Visible = setting_ShowDtgv.GetValueBool("ckbEmail");
			dtgvAcc.Columns["cName"].Visible = setting_ShowDtgv.GetValueBool("ckbTen");
			dtgvAcc.Columns["cFriend"].Visible = setting_ShowDtgv.GetValueBool("ckbBanBe");
			dtgvAcc.Columns["cGroup"].Visible = setting_ShowDtgv.GetValueBool("ckbNhom");
			dtgvAcc.Columns["cBirthday"].Visible = setting_ShowDtgv.GetValueBool("ckbNgaySinh");
			dtgvAcc.Columns["cGender"].Visible = setting_ShowDtgv.GetValueBool("ckbGioiTinh");
			dtgvAcc.Columns["cPassword"].Visible = setting_ShowDtgv.GetValueBool("ckbMatKhau");
			dtgvAcc.Columns["cPassMail"].Visible = setting_ShowDtgv.GetValueBool("ckbMatKhauMail");
			dtgvAcc.Columns["cBackup"].Visible = setting_ShowDtgv.GetValueBool("ckbBackup");
			dtgvAcc.Columns["cFa2"].Visible = setting_ShowDtgv.GetValueBool("ckbMa2FA");
			dtgvAcc.Columns["cUseragent"].Visible = setting_ShowDtgv.GetValueBool("ckbUseragent");
			dtgvAcc.Columns["cProxy"].Visible = setting_ShowDtgv.GetValueBool("ckbProxy");
			dtgvAcc.Columns["cDateCreateAcc"].Visible = setting_ShowDtgv.GetValueBool("ckbNgayTao");
			dtgvAcc.Columns["cAvatar"].Visible = setting_ShowDtgv.GetValueBool("ckbAvatar");
			dtgvAcc.Columns["cProfile"].Visible = setting_ShowDtgv.GetValueBool("ckbProfile");
			dtgvAcc.Columns["cInfo"].Visible = setting_ShowDtgv.GetValueBool("ckbTinhTrang");
			dtgvAcc.Columns["cThuMuc"].Visible = setting_ShowDtgv.GetValueBool("ckbThuMuc");
			dtgvAcc.Columns["cGhiChu"].Visible = setting_ShowDtgv.GetValueBool("ckbGhiChu");
			dtgvAcc.Columns["cFollow"].Visible = setting_ShowDtgv.GetValueBool("ckbFollow");
			dtgvAcc.Columns["cInteractEnd"].Visible = setting_ShowDtgv.GetValueBool("ckbInteractEnd");
			dtgvAcc.Columns["cDevice"].Visible = setting_ShowDtgv.GetValueBool("ckbDevice");
		}

		private void cậpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCapNhatDuLieu());
			if (fCapNhatDuLieu.isAdd)
			{
				BtnLoadAcc_Click(null, null);
			}
		}

		private void loginYandexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoginMail();
		}

		private void dtgvAcc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (isCountCheckAccountWhenChayTuongTac && e.ColumnIndex == 0)
			{
				CountCheckedAccount();
			}
		}

		private void copyProfileToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			CopyFolder("profile");
		}

		private void CopyFolder(string sourceFolder)
		{
			MCommon.Common.ShowForm(new fSelectFolder());
			string pathFolder = fSelectFolder.pathFolder;
			if (pathFolder == "")
			{
				return;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				try
				{
					if (Convert.ToBoolean(GetCellAccount(i, "cChose")))
					{
						string cellAccount = GetCellAccount(i, "cUid");
						list.Add(sourceFolder + "\\" + cellAccount + "|" + pathFolder + "\\" + cellAccount);
					}
				}
				catch
				{
				}
			}
			if (list.Count > 0)
			{
				MCommon.Common.ShowForm(new fShowProgressBar(list));
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đa\u0303 copy dư\u0303 liê\u0323u xong!"));
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				string text = CommonCSharp.Md5Encode(new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
					.AddSystemDriveSerialNumber()
					.ToString());
				string text2 = new RequestXNet("", "", "", 0).RequestGet("http://app.minsoftware.vn/minapi/minapi/api.php/CheckSerial?serial=" + text);
				if (text2 == "null" || text2 == "0")
				{
					Environment.Exit(0);
				}
			}
			catch
			{
			}
		}

		private void fSpamBaiViet_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fShareBai));
			dtgvAcc = new System.Windows.Forms.DataGridView();
			cChose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cCookies = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cFollow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cFriend = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cMailRecovery = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cPassMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cFa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cUseragent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cProxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cDateCreateAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cAvatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cThuMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cInteractEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ctmsAcc = new MetroFramework.Controls.MetroContextMenu(components);
			chọnLiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			liveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tinhTrangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			trạngTháiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			bỏChọnTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			passToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			fAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			maBaoMât6SôToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPass2FaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mailPassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPassTokenCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPassTokenCookieMailPassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPassTokenCookieMailPassMail2faToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			useragentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			proxyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			đinhDangKhacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xóaTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraWallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkInfoUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkAvatarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkBackupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraMailpassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			câpNhâtThôngTinCaNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			sưDungTokenTrungGianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			sửDụngCookieTrungGianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			chuyểnThưMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			chứcNăngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			locTrungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tảiXuốngAvatarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			loginHotmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			loginYandexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tảiLạiDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			càiĐặtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			grQuanLyThuMuc = new System.Windows.Forms.GroupBox();
			btnLoadAcc = new MetroFramework.Controls.MetroButton();
			btnEditFile = new MetroFramework.Controls.MetroButton();
			btnDeleteFile = new MetroFramework.Controls.MetroButton();
			AddFileAccount = new MetroFramework.Controls.MetroButton();
			cbbTinhTrang = new MetroFramework.Controls.MetroComboBox();
			cbbThuMuc = new MetroFramework.Controls.MetroComboBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			grTimKiem = new System.Windows.Forms.GroupBox();
			BtnSearch = new MetroFramework.Controls.MetroButton();
			cbbSearch = new System.Windows.Forms.ComboBox();
			txbSearch = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			btnPause = new System.Windows.Forms.Button();
			btnInteract = new System.Windows.Forms.Button();
			timer1 = new System.Windows.Forms.Timer(components);
			lblTrangThai = new System.Windows.Forms.Label();
			plTrangThai = new System.Windows.Forms.Panel();
			panel1 = new System.Windows.Forms.Panel();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountSelect = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountTotal = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)dtgvAcc).BeginInit();
			ctmsAcc.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			bunifuCards1.SuspendLayout();
			menuStrip1.SuspendLayout();
			grQuanLyThuMuc.SuspendLayout();
			grTimKiem.SuspendLayout();
			plTrangThai.SuspendLayout();
			panel1.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			dtgvAcc.AllowUserToAddRows = false;
			dtgvAcc.AllowUserToDeleteRows = false;
			dtgvAcc.AllowUserToResizeRows = false;
			dtgvAcc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			dtgvAcc.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dtgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvAcc.Columns.AddRange(cChose, cStt, cId, cUid, cToken, cCookies, cEmail, cPhone, cName, cFollow, cFriend, cGroup, cBirthday, cGender, cPassword, cMailRecovery, cPassMail, cBackup, cFa2, cUseragent, cProxy, cDateCreateAcc, cAvatar, cProfile, cThuMuc, cInteractEnd, cDevice, cInfo, cGhiChu, cStatus);
			dtgvAcc.ContextMenuStrip = ctmsAcc;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dtgvAcc.DefaultCellStyle = dataGridViewCellStyle2;
			dtgvAcc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dtgvAcc.Location = new System.Drawing.Point(9, 124);
			dtgvAcc.Name = "dtgvAcc";
			dtgvAcc.RowHeadersVisible = false;
			dtgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvAcc.Size = new System.Drawing.Size(1225, 455);
			dtgvAcc.TabIndex = 0;
			dtgvAcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(DtgvAcc_CellClick);
			dtgvAcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellDoubleClick);
			dtgvAcc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellValueChanged);
			dtgvAcc.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(dtgvAcc_SortCompare);
			dtgvAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(DtgvAcc_KeyDown);
			cChose.HeaderText = "Chọn";
			cChose.Name = "cChose";
			cChose.Width = 40;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			cStt.DefaultCellStyle = dataGridViewCellStyle3;
			cStt.HeaderText = "STT";
			cStt.Name = "cStt";
			cStt.Width = 35;
			cId.HeaderText = "Id";
			cId.Name = "cId";
			cId.Visible = false;
			cId.Width = 90;
			cUid.HeaderText = "UID";
			cUid.Name = "cUid";
			cUid.Width = 80;
			cToken.HeaderText = "Token";
			cToken.Name = "cToken";
			cToken.Width = 70;
			cCookies.HeaderText = "Cookie";
			cCookies.Name = "cCookies";
			cCookies.Width = 70;
			cEmail.HeaderText = "Email";
			cEmail.Name = "cEmail";
			cEmail.Width = 60;
			cPhone.HeaderText = "Phone";
			cPhone.Name = "cPhone";
			cPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cPhone.Visible = false;
			cPhone.Width = 90;
			cName.HeaderText = "Tên";
			cName.Name = "cName";
			cName.Width = 70;
			cFollow.HeaderText = "Theo do\u0303i";
			cFollow.Name = "cFollow";
			cFollow.Width = 80;
			cFriend.HeaderText = "Ba\u0323n be\u0300";
			cFriend.Name = "cFriend";
			cFriend.Width = 70;
			cGroup.HeaderText = "Nho\u0301m";
			cGroup.Name = "cGroup";
			cGroup.Width = 60;
			cBirthday.HeaderText = "Nga\u0300y sinh";
			cBirthday.Name = "cBirthday";
			cBirthday.Width = 90;
			cGender.HeaderText = "Giới Tính";
			cGender.Name = "cGender";
			cGender.Width = 80;
			cPassword.HeaderText = "Mật khẩu";
			cPassword.Name = "cPassword";
			cPassword.Visible = false;
			cPassword.Width = 70;
			cMailRecovery.HeaderText = "Email khôi phục";
			cMailRecovery.Name = "cMailRecovery";
			cMailRecovery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cMailRecovery.Visible = false;
			cMailRecovery.Width = 120;
			cPassMail.HeaderText = "Mật khẩu mail";
			cPassMail.Name = "cPassMail";
			cPassMail.Visible = false;
			cPassMail.Width = 120;
			cBackup.HeaderText = "Backup";
			cBackup.Name = "cBackup";
			cBackup.Width = 70;
			cFa2.HeaderText = "Mã 2FA";
			cFa2.Name = "cFa2";
			cFa2.Width = 65;
			cUseragent.HeaderText = "Useragent";
			cUseragent.Name = "cUseragent";
			cUseragent.Width = 70;
			cProxy.HeaderText = "Proxy";
			cProxy.Name = "cProxy";
			cProxy.Width = 55;
			cDateCreateAcc.HeaderText = "Nga\u0300y ta\u0323o";
			cDateCreateAcc.Name = "cDateCreateAcc";
			cDateCreateAcc.Width = 85;
			cAvatar.HeaderText = "Avatar";
			cAvatar.Name = "cAvatar";
			cAvatar.Width = 50;
			cProfile.HeaderText = "Profile";
			cProfile.Name = "cProfile";
			cProfile.Width = 50;
			cThuMuc.HeaderText = "Thư mục";
			cThuMuc.Name = "cThuMuc";
			cInteractEnd.HeaderText = "Lâ\u0300n tương ta\u0301c cuô\u0301i";
			cInteractEnd.Name = "cInteractEnd";
			cDevice.HeaderText = "LD Index";
			cDevice.Name = "cDevice";
			cDevice.Width = 80;
			cInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			cInfo.HeaderText = "Tình Trạng";
			cInfo.Name = "cInfo";
			cInfo.Width = 90;
			cGhiChu.HeaderText = "Ghi Chú";
			cGhiChu.Name = "cGhiChu";
			cStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cStatus.HeaderText = "Trạng Thái";
			cStatus.MinimumWidth = 200;
			cStatus.Name = "cStatus";
			ctmsAcc.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { chọnLiveToolStripMenuItem, bỏChọnTấtCảToolStripMenuItem, copyToolStripMenuItem, xóaTàiKhoảnToolStripMenuItem, checkCookieToolStripMenuItem, câpNhâtThôngTinCaNhânToolStripMenuItem, chuyểnThưMụcToolStripMenuItem, chứcNăngToolStripMenuItem1, tảiLạiDanhSáchToolStripMenuItem });
			ctmsAcc.Name = "ctmsAcc";
			ctmsAcc.Size = new System.Drawing.Size(175, 202);
			ctmsAcc.Opening += new System.ComponentModel.CancelEventHandler(CtmsAcc_Opening);
			chọnLiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { tấtCảToolStripMenuItem, liveToolStripMenuItem, tinhTrangToolStripMenuItem, trạngTháiToolStripMenuItem });
			chọnLiveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("chọnLiveToolStripMenuItem.Image");
			chọnLiveToolStripMenuItem.Name = "chọnLiveToolStripMenuItem";
			chọnLiveToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			chọnLiveToolStripMenuItem.Text = "Chọn";
			tấtCảToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tấtCảToolStripMenuItem.Image");
			tấtCảToolStripMenuItem.Name = "tấtCảToolStripMenuItem";
			tấtCảToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			tấtCảToolStripMenuItem.Text = "Tất cả";
			tấtCảToolStripMenuItem.Click += new System.EventHandler(TấtCảToolStripMenuItem_Click);
			liveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("liveToolStripMenuItem.Image");
			liveToolStripMenuItem.Name = "liveToolStripMenuItem";
			liveToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			liveToolStripMenuItem.Text = "Bôi đen";
			liveToolStripMenuItem.Click += new System.EventHandler(LiveToolStripMenuItem_Click);
			tinhTrangToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tinhTrangToolStripMenuItem.Image");
			tinhTrangToolStripMenuItem.Name = "tinhTrangToolStripMenuItem";
			tinhTrangToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			tinhTrangToolStripMenuItem.Text = "Ti\u0300nh tra\u0323ng";
			trạngTháiToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("trạngTháiToolStripMenuItem.Image");
			trạngTháiToolStripMenuItem.Name = "trạngTháiToolStripMenuItem";
			trạngTháiToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			trạngTháiToolStripMenuItem.Text = "Trạng thái";
			trạngTháiToolStripMenuItem.Click += new System.EventHandler(trạngTháiToolStripMenuItem_Click);
			bỏChọnTấtCảToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("bỏChọnTấtCảToolStripMenuItem.Image");
			bỏChọnTấtCảToolStripMenuItem.Name = "bỏChọnTấtCảToolStripMenuItem";
			bỏChọnTấtCảToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			bỏChọnTấtCảToolStripMenuItem.Text = "Bỏ chọn tất cả";
			bỏChọnTấtCảToolStripMenuItem.Click += new System.EventHandler(BỏChọnTấtCảToolStripMenuItem_Click);
			copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[16]
			{
				uidToolStripMenuItem, passToolStripMenuItem, tokenToolStripMenuItem, cookieToolStripMenuItem, mailToolStripMenuItem, fAToolStripMenuItem, maBaoMât6SôToolStripMenuItem, uidPassToolStripMenuItem, uidPass2FaToolStripMenuItem, mailPassMailToolStripMenuItem,
				uidPassTokenCookieToolStripMenuItem, uidPassTokenCookieMailPassMailToolStripMenuItem, uidPassTokenCookieMailPassMail2faToolStripMenuItem, useragentToolStripMenuItem1, proxyToolStripMenuItem1, đinhDangKhacToolStripMenuItem
			});
			copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			copyToolStripMenuItem.Text = "Copy";
			uidToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidToolStripMenuItem.Image");
			uidToolStripMenuItem.Name = "uidToolStripMenuItem";
			uidToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			uidToolStripMenuItem.Text = "Uid";
			uidToolStripMenuItem.Click += new System.EventHandler(UidToolStripMenuItem_Click);
			passToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("passToolStripMenuItem.Image");
			passToolStripMenuItem.Name = "passToolStripMenuItem";
			passToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			passToolStripMenuItem.Text = "Pass";
			passToolStripMenuItem.Click += new System.EventHandler(PassToolStripMenuItem_Click);
			tokenToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tokenToolStripMenuItem.Image");
			tokenToolStripMenuItem.Name = "tokenToolStripMenuItem";
			tokenToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			tokenToolStripMenuItem.Text = "Token";
			tokenToolStripMenuItem.Click += new System.EventHandler(TokenToolStripMenuItem_Click);
			cookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cookieToolStripMenuItem.Image");
			cookieToolStripMenuItem.Name = "cookieToolStripMenuItem";
			cookieToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			cookieToolStripMenuItem.Text = "Cookie";
			cookieToolStripMenuItem.Click += new System.EventHandler(CookieToolStripMenuItem_Click);
			mailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mailToolStripMenuItem.Image");
			mailToolStripMenuItem.Name = "mailToolStripMenuItem";
			mailToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			mailToolStripMenuItem.Text = "Email";
			mailToolStripMenuItem.Click += new System.EventHandler(MailToolStripMenuItem_Click_1);
			fAToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("fAToolStripMenuItem.Image");
			fAToolStripMenuItem.Name = "fAToolStripMenuItem";
			fAToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			fAToolStripMenuItem.Text = "2FA";
			fAToolStripMenuItem.Click += new System.EventHandler(fAToolStripMenuItem_Click);
			maBaoMât6SôToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("maBaoMât6SôToolStripMenuItem.Image");
			maBaoMât6SôToolStripMenuItem.Name = "maBaoMât6SôToolStripMenuItem";
			maBaoMât6SôToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			maBaoMât6SôToolStripMenuItem.Text = "Ma\u0303 ba\u0309o mâ\u0323t 6 sô\u0301 từ 2FA";
			maBaoMât6SôToolStripMenuItem.Click += new System.EventHandler(maBaoMât6SôToolStripMenuItem_Click);
			uidPassToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassToolStripMenuItem.Image");
			uidPassToolStripMenuItem.Name = "uidPassToolStripMenuItem";
			uidPassToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			uidPassToolStripMenuItem.Text = "Uid|Pass";
			uidPassToolStripMenuItem.Click += new System.EventHandler(UidPassToolStripMenuItem_Click);
			uidPass2FaToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPass2FaToolStripMenuItem.Image");
			uidPass2FaToolStripMenuItem.Name = "uidPass2FaToolStripMenuItem";
			uidPass2FaToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			uidPass2FaToolStripMenuItem.Text = "Uid|Pass|2Fa";
			uidPass2FaToolStripMenuItem.Click += new System.EventHandler(uidPass2FaToolStripMenuItem_Click);
			mailPassMailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mailPassMailToolStripMenuItem.Image");
			mailPassMailToolStripMenuItem.Name = "mailPassMailToolStripMenuItem";
			mailPassMailToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			mailPassMailToolStripMenuItem.Text = "Mail|Pass mail";
			mailPassMailToolStripMenuItem.Click += new System.EventHandler(MailPassMailToolStripMenuItem_Click);
			uidPassTokenCookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassTokenCookieToolStripMenuItem.Image");
			uidPassTokenCookieToolStripMenuItem.Name = "uidPassTokenCookieToolStripMenuItem";
			uidPassTokenCookieToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			uidPassTokenCookieToolStripMenuItem.Text = "Uid|Pass|Token|Cookie";
			uidPassTokenCookieToolStripMenuItem.Click += new System.EventHandler(UidPassTokenCookieToolStripMenuItem_Click);
			uidPassTokenCookieMailPassMailToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassTokenCookieMailPassMailToolStripMenuItem.Image");
			uidPassTokenCookieMailPassMailToolStripMenuItem.Name = "uidPassTokenCookieMailPassMailToolStripMenuItem";
			uidPassTokenCookieMailPassMailToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			uidPassTokenCookieMailPassMailToolStripMenuItem.Text = "Uid|Pass|Token|Cookie|Mail|Pass mail";
			uidPassTokenCookieMailPassMailToolStripMenuItem.Click += new System.EventHandler(UidPassTokenCookieMailPassMailToolStripMenuItem_Click);
			uidPassTokenCookieMailPassMail2faToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uidPassTokenCookieMailPassMail2faToolStripMenuItem.Image");
			uidPassTokenCookieMailPassMail2faToolStripMenuItem.Name = "uidPassTokenCookieMailPassMail2faToolStripMenuItem";
			uidPassTokenCookieMailPassMail2faToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			uidPassTokenCookieMailPassMail2faToolStripMenuItem.Text = "Uid|Pass|Token|Cookie|Mail|Pass mail|2fa";
			uidPassTokenCookieMailPassMail2faToolStripMenuItem.Click += new System.EventHandler(UidPassTokenCookieMailPassMail2faToolStripMenuItem_Click);
			useragentToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("useragentToolStripMenuItem1.Image");
			useragentToolStripMenuItem1.Name = "useragentToolStripMenuItem1";
			useragentToolStripMenuItem1.Size = new System.Drawing.Size(290, 22);
			useragentToolStripMenuItem1.Text = "Useragent";
			useragentToolStripMenuItem1.Click += new System.EventHandler(useragentToolStripMenuItem1_Click);
			proxyToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("proxyToolStripMenuItem1.Image");
			proxyToolStripMenuItem1.Name = "proxyToolStripMenuItem1";
			proxyToolStripMenuItem1.Size = new System.Drawing.Size(290, 22);
			proxyToolStripMenuItem1.Text = "Proxy";
			proxyToolStripMenuItem1.Click += new System.EventHandler(proxyToolStripMenuItem1_Click);
			đinhDangKhacToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("đinhDangKhacToolStripMenuItem.Image");
			đinhDangKhacToolStripMenuItem.Name = "đinhDangKhacToolStripMenuItem";
			đinhDangKhacToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
			đinhDangKhacToolStripMenuItem.Text = "Other...";
			đinhDangKhacToolStripMenuItem.Click += new System.EventHandler(đinhDangKhacToolStripMenuItem_Click);
			xóaTàiKhoảnToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("xóaTàiKhoảnToolStripMenuItem.Image");
			xóaTàiKhoảnToolStripMenuItem.Name = "xóaTàiKhoảnToolStripMenuItem";
			xóaTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			xóaTàiKhoảnToolStripMenuItem.Text = "Xóa ta\u0300i khoa\u0309n";
			xóaTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(giưLaiProfileToolStripMenuItem_Click);
			checkCookieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { kiểmTraWallToolStripMenuItem, checkInfoUIDToolStripMenuItem, kiểmTraTokenToolStripMenuItem, kiểmTraCookieToolStripMenuItem, checkAvatarToolStripMenuItem, checkBackupToolStripMenuItem1, kiểmTraMailpassMailToolStripMenuItem, checkProxyToolStripMenuItem });
			checkCookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkCookieToolStripMenuItem.Image");
			checkCookieToolStripMenuItem.Name = "checkCookieToolStripMenuItem";
			checkCookieToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			checkCookieToolStripMenuItem.Text = "Kiểm tra tài khoản";
			checkCookieToolStripMenuItem.Click += new System.EventHandler(checkCookieToolStripMenuItem_Click);
			kiểmTraWallToolStripMenuItem.Name = "kiểmTraWallToolStripMenuItem";
			kiểmTraWallToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			kiểmTraWallToolStripMenuItem.Text = "Check Wall";
			kiểmTraWallToolStripMenuItem.ToolTipText = "Không cần dùng token";
			kiểmTraWallToolStripMenuItem.Click += new System.EventHandler(KiểmTraWallToolStripMenuItem_Click);
			checkInfoUIDToolStripMenuItem.Name = "checkInfoUIDToolStripMenuItem";
			checkInfoUIDToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			checkInfoUIDToolStripMenuItem.Text = "Check Info UID";
			checkInfoUIDToolStripMenuItem.ToolTipText = "Không cần dùng token\r\nCâ\u0323p nhâ\u0323t thông tin: Ho\u0323 tên, Giớ\u0301i ti\u0301nh, [Email], [Ba\u0323n be\u0300], [Nho\u0301m], [Nga\u0300y sinh]";
			checkInfoUIDToolStripMenuItem.Click += new System.EventHandler(checkInfoUIDToolStripMenuItem_Click);
			kiểmTraTokenToolStripMenuItem.Name = "kiểmTraTokenToolStripMenuItem";
			kiểmTraTokenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			kiểmTraTokenToolStripMenuItem.Text = "Check Token";
			kiểmTraTokenToolStripMenuItem.Click += new System.EventHandler(KiểmTraTokenToolStripMenuItem_Click);
			kiểmTraCookieToolStripMenuItem.Name = "kiểmTraCookieToolStripMenuItem";
			kiểmTraCookieToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			kiểmTraCookieToolStripMenuItem.Text = "Check Cookie";
			kiểmTraCookieToolStripMenuItem.Click += new System.EventHandler(KiểmTraCookieToolStripMenuItem_Click);
			checkAvatarToolStripMenuItem.Name = "checkAvatarToolStripMenuItem";
			checkAvatarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			checkAvatarToolStripMenuItem.Text = "Check Avatar";
			checkAvatarToolStripMenuItem.Click += new System.EventHandler(checkAvatarToolStripMenuItem_Click);
			checkBackupToolStripMenuItem1.Name = "checkBackupToolStripMenuItem1";
			checkBackupToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
			checkBackupToolStripMenuItem1.Text = "Check Backup";
			checkBackupToolStripMenuItem1.Click += new System.EventHandler(checkBackupToolStripMenuItem_Click);
			kiểmTraMailpassMailToolStripMenuItem.Name = "kiểmTraMailpassMailToolStripMenuItem";
			kiểmTraMailpassMailToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			kiểmTraMailpassMailToolStripMenuItem.Text = "Mail|pass Mail";
			kiểmTraMailpassMailToolStripMenuItem.Click += new System.EventHandler(kiểmTraMailpassMailToolStripMenuItem_Click);
			checkProxyToolStripMenuItem.Name = "checkProxyToolStripMenuItem";
			checkProxyToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			checkProxyToolStripMenuItem.Text = "Check Proxy";
			checkProxyToolStripMenuItem.Click += new System.EventHandler(checkProxyToolStripMenuItem_Click);
			câpNhâtThôngTinCaNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { sưDungTokenTrungGianToolStripMenuItem, sửDụngCookieTrungGianToolStripMenuItem });
			câpNhâtThôngTinCaNhânToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("câpNhâtThôngTinCaNhânToolStripMenuItem.Image");
			câpNhâtThôngTinCaNhânToolStripMenuItem.Name = "câpNhâtThôngTinCaNhânToolStripMenuItem";
			câpNhâtThôngTinCaNhânToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			câpNhâtThôngTinCaNhânToolStripMenuItem.Text = "Câ\u0323p nhâ\u0323t thông tin";
			sưDungTokenTrungGianToolStripMenuItem.Name = "sưDungTokenTrungGianToolStripMenuItem";
			sưDungTokenTrungGianToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			sưDungTokenTrungGianToolStripMenuItem.Text = "Sư\u0309 du\u0323ng Token trung gian";
			sưDungTokenTrungGianToolStripMenuItem.ToolTipText = "Câ\u0323p nhâ\u0323t thông tin: Ho\u0323 tên, Giớ\u0301i ti\u0301nh, [Email], [Ba\u0323n be\u0300], [Nho\u0301m], [Nga\u0300y sinh]";
			sưDungTokenTrungGianToolStripMenuItem.Click += new System.EventHandler(sưDungTokenTrungGianToolStripMenuItem_Click);
			sửDụngCookieTrungGianToolStripMenuItem.Name = "sửDụngCookieTrungGianToolStripMenuItem";
			sửDụngCookieTrungGianToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			sửDụngCookieTrungGianToolStripMenuItem.Text = "Sử dụng Cookie trung gian";
			sửDụngCookieTrungGianToolStripMenuItem.Click += new System.EventHandler(sửDụngCookieTrungGianToolStripMenuItem_Click);
			chuyểnThưMụcToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("chuyểnThưMụcToolStripMenuItem.Image");
			chuyểnThưMụcToolStripMenuItem.Name = "chuyểnThưMụcToolStripMenuItem";
			chuyểnThưMụcToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			chuyểnThưMụcToolStripMenuItem.Text = "Chuyển thư mục";
			chứcNăngToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { locTrungToolStripMenuItem, tảiXuốngAvatarToolStripMenuItem, loginHotmailToolStripMenuItem, loginYandexToolStripMenuItem, lToolStripMenuItem });
			chứcNăngToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("chứcNăngToolStripMenuItem1.Image");
			chứcNăngToolStripMenuItem1.Name = "chứcNăngToolStripMenuItem1";
			chứcNăngToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
			chứcNăngToolStripMenuItem1.Text = "Chức năng";
			locTrungToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("locTrungToolStripMenuItem.Image");
			locTrungToolStripMenuItem.Name = "locTrungToolStripMenuItem";
			locTrungToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			locTrungToolStripMenuItem.Text = "Lo\u0323c tru\u0300ng ta\u0300i khoa\u0309n";
			locTrungToolStripMenuItem.Click += new System.EventHandler(locTrungToolStripMenuItem_Click);
			tảiXuốngAvatarToolStripMenuItem.Image = maxcare.Properties.Resources.client_management_25px;
			tảiXuốngAvatarToolStripMenuItem.Name = "tảiXuốngAvatarToolStripMenuItem";
			tảiXuốngAvatarToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			tảiXuốngAvatarToolStripMenuItem.Text = "Tải xuống avatar";
			tảiXuốngAvatarToolStripMenuItem.Click += new System.EventHandler(tảiXuốngAvatarToolStripMenuItem_Click);
			loginHotmailToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_microsoft_outlook_48px;
			loginHotmailToolStripMenuItem.Name = "loginHotmailToolStripMenuItem";
			loginHotmailToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			loginHotmailToolStripMenuItem.Text = "Login Hotmail";
			loginHotmailToolStripMenuItem.Click += new System.EventHandler(loginHotmailToolStripMenuItem_Click);
			loginYandexToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_yandex_international_32px;
			loginYandexToolStripMenuItem.Name = "loginYandexToolStripMenuItem";
			loginYandexToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			loginYandexToolStripMenuItem.Text = "Login Yandex";
			loginYandexToolStripMenuItem.Click += new System.EventHandler(loginYandexToolStripMenuItem_Click);
			lToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_mail_filter_24px1;
			lToolStripMenuItem.Name = "lToolStripMenuItem";
			lToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			lToolStripMenuItem.Text = "Lọc danh sách theo UID";
			lToolStripMenuItem.Click += new System.EventHandler(lToolStripMenuItem_Click);
			tảiLạiDanhSáchToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tảiLạiDanhSáchToolStripMenuItem.Image");
			tảiLạiDanhSáchToolStripMenuItem.Name = "tảiLạiDanhSáchToolStripMenuItem";
			tảiLạiDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			tảiLạiDanhSáchToolStripMenuItem.Text = "Tải lại danh sách";
			tảiLạiDanhSáchToolStripMenuItem.Click += new System.EventHandler(TảiLạiDanhSáchToolStripMenuItem_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = pnlHeader;
			bunifuDragControl1.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1242, 29);
			pnlHeader.TabIndex = 0;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(6, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			pictureBox1.DoubleClick += new System.EventHandler(pictureBox1_DoubleClick);
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.Dock = System.Windows.Forms.DockStyle.Right;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
			button2.Location = new System.Drawing.Point(1146, 0);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(32, 29);
			button2.TabIndex = 0;
			button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2_Click);
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.Dock = System.Windows.Forms.DockStyle.Right;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(1178, 0);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(32, 29);
			button1.TabIndex = 1;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1_Click);
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(1210, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 29);
			btnMinimize.TabIndex = 2;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			bunifuCustomLabel1.AutoSize = true;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(43, 6);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(301, 16);
			bunifuCustomLabel1.TabIndex = 3;
			bunifuCustomLabel1.Text = "MAX SYSTEM CARE PRO - Ti\u0301nh năng Share ba\u0300i";
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.RoyalBlue;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(1243, 38);
			bunifuCards1.TabIndex = 0;
			menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { hệThốngToolStripMenuItem, càiĐặtToolStripMenuItem, thoátToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(1, 37);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			menuStrip1.Size = new System.Drawing.Size(1241, 25);
			menuStrip1.Stretch = false;
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			hệThốngToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_job;
			hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
			hệThốngToolStripMenuItem.Size = new System.Drawing.Size(124, 21);
			hệThốngToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh chung";
			hệThốngToolStripMenuItem.Click += new System.EventHandler(mnuCauHinhChung_Click);
			càiĐặtToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_opposite_opinion;
			càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
			càiĐặtToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
			càiĐặtToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh";
			càiĐặtToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			càiĐặtToolStripMenuItem.Click += new System.EventHandler(càiĐặtToolStripMenuItem_Click_1);
			thoátToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_show_property_48px;
			thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			thoátToolStripMenuItem.Size = new System.Drawing.Size(132, 21);
			thoátToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
			thoátToolStripMenuItem.Click += new System.EventHandler(câuHinhHiênThiToolStripMenuItem_Click);
			grQuanLyThuMuc.Controls.Add(btnLoadAcc);
			grQuanLyThuMuc.Controls.Add(btnEditFile);
			grQuanLyThuMuc.Controls.Add(btnDeleteFile);
			grQuanLyThuMuc.Controls.Add(AddFileAccount);
			grQuanLyThuMuc.Controls.Add(cbbTinhTrang);
			grQuanLyThuMuc.Controls.Add(cbbThuMuc);
			grQuanLyThuMuc.Controls.Add(label2);
			grQuanLyThuMuc.Controls.Add(label1);
			grQuanLyThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grQuanLyThuMuc.Location = new System.Drawing.Point(703, 65);
			grQuanLyThuMuc.Name = "grQuanLyThuMuc";
			grQuanLyThuMuc.Size = new System.Drawing.Size(531, 53);
			grQuanLyThuMuc.TabIndex = 5;
			grQuanLyThuMuc.TabStop = false;
			grQuanLyThuMuc.Text = "Quản lý thư mục";
			btnLoadAcc.BackgroundImage = maxcare.Properties.Resources.available_updates_25px;
			btnLoadAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			btnLoadAcc.Cursor = System.Windows.Forms.Cursors.Hand;
			btnLoadAcc.Location = new System.Drawing.Point(498, 19);
			btnLoadAcc.Name = "btnLoadAcc";
			btnLoadAcc.Size = new System.Drawing.Size(25, 25);
			btnLoadAcc.TabIndex = 6;
			toolTip1.SetToolTip(btnLoadAcc, "Load lại danh sách");
			btnLoadAcc.UseSelectable = true;
			btnLoadAcc.Click += new System.EventHandler(BtnLoadAcc_Click);
			btnEditFile.BackColor = System.Drawing.Color.Gray;
			btnEditFile.BackgroundImage = maxcare.Properties.Resources.icons8_edit_24px1;
			btnEditFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnEditFile.Cursor = System.Windows.Forms.Cursors.Hand;
			btnEditFile.Enabled = false;
			btnEditFile.Location = new System.Drawing.Point(435, 19);
			btnEditFile.Name = "btnEditFile";
			btnEditFile.Size = new System.Drawing.Size(25, 25);
			btnEditFile.TabIndex = 5;
			toolTip1.SetToolTip(btnEditFile, "Sửa tên thư mục");
			btnEditFile.UseSelectable = true;
			btnEditFile.Click += new System.EventHandler(metroButton2_Click_1);
			btnDeleteFile.BackColor = System.Drawing.Color.Gray;
			btnDeleteFile.BackgroundImage = maxcare.Properties.Resources.icons8_subtract_25px;
			btnDeleteFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnDeleteFile.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDeleteFile.Enabled = false;
			btnDeleteFile.Location = new System.Drawing.Point(466, 19);
			btnDeleteFile.Name = "btnDeleteFile";
			btnDeleteFile.Size = new System.Drawing.Size(25, 25);
			btnDeleteFile.TabIndex = 5;
			toolTip1.SetToolTip(btnDeleteFile, "Xóa thư mục");
			btnDeleteFile.UseSelectable = true;
			btnDeleteFile.Click += new System.EventHandler(BtnDeleteFile_Click);
			AddFileAccount.BackgroundImage = maxcare.Properties.Resources.icons8_plus_math_25px1;
			AddFileAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			AddFileAccount.Cursor = System.Windows.Forms.Cursors.Hand;
			AddFileAccount.Location = new System.Drawing.Point(404, 19);
			AddFileAccount.Name = "AddFileAccount";
			AddFileAccount.Size = new System.Drawing.Size(25, 25);
			AddFileAccount.TabIndex = 4;
			toolTip1.SetToolTip(AddFileAccount, "Thêm thư mục");
			AddFileAccount.UseSelectable = true;
			AddFileAccount.Click += new System.EventHandler(AddFileAccount_Click_1);
			cbbTinhTrang.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTinhTrang.DropDownWidth = 300;
			cbbTinhTrang.FontSize = MetroFramework.MetroComboBoxSize.Small;
			cbbTinhTrang.FormattingEnabled = true;
			cbbTinhTrang.ItemHeight = 19;
			cbbTinhTrang.Items.AddRange(new object[1] { "[Tất cả tình trạng]" });
			cbbTinhTrang.Location = new System.Drawing.Point(277, 19);
			cbbTinhTrang.Name = "cbbTinhTrang";
			cbbTinhTrang.Size = new System.Drawing.Size(121, 25);
			cbbTinhTrang.TabIndex = 3;
			cbbTinhTrang.UseSelectable = true;
			cbbTinhTrang.SelectedIndexChanged += new System.EventHandler(cbbTinhTrang_SelectedIndexChanged);
			cbbThuMuc.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbThuMuc.DropDownWidth = 350;
			cbbThuMuc.FontSize = MetroFramework.MetroComboBoxSize.Small;
			cbbThuMuc.FormattingEnabled = true;
			cbbThuMuc.ItemHeight = 19;
			cbbThuMuc.Location = new System.Drawing.Point(72, 19);
			cbbThuMuc.Name = "cbbThuMuc";
			cbbThuMuc.Size = new System.Drawing.Size(167, 25);
			cbbThuMuc.TabIndex = 1;
			cbbThuMuc.UseSelectable = true;
			cbbThuMuc.SelectedIndexChanged += new System.EventHandler(CbbThuMuc_SelectedIndexChanged);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(241, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(32, 16);
			label2.TabIndex = 2;
			label2.Text = "Lọc:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(8, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(64, 16);
			label1.TabIndex = 0;
			label1.Text = "Thư mục:";
			grTimKiem.Controls.Add(BtnSearch);
			grTimKiem.Controls.Add(cbbSearch);
			grTimKiem.Controls.Add(txbSearch);
			grTimKiem.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grTimKiem.Location = new System.Drawing.Point(412, 64);
			grTimKiem.Name = "grTimKiem";
			grTimKiem.Size = new System.Drawing.Size(284, 53);
			grTimKiem.TabIndex = 4;
			grTimKiem.TabStop = false;
			grTimKiem.Text = "Tìm kiếm";
			BtnSearch.BackgroundImage = maxcare.Properties.Resources.icons8_search_24px_1;
			BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			BtnSearch.Location = new System.Drawing.Point(253, 18);
			BtnSearch.Name = "BtnSearch";
			BtnSearch.Size = new System.Drawing.Size(24, 24);
			BtnSearch.TabIndex = 2;
			BtnSearch.UseSelectable = true;
			BtnSearch.Click += new System.EventHandler(BtnSearch_Click);
			cbbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbSearch.DropDownWidth = 100;
			cbbSearch.FormattingEnabled = true;
			cbbSearch.Location = new System.Drawing.Point(12, 18);
			cbbSearch.Name = "cbbSearch";
			cbbSearch.Size = new System.Drawing.Size(86, 24);
			cbbSearch.TabIndex = 0;
			txbSearch.BorderColor = System.Drawing.Color.SeaGreen;
			txbSearch.Location = new System.Drawing.Point(104, 19);
			txbSearch.Name = "txbSearch";
			txbSearch.Size = new System.Drawing.Size(143, 23);
			txbSearch.TabIndex = 1;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = bunifuCustomLabel1;
			bunifuDragControl2.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 30000;
			toolTip1.InitialDelay = 0;
			toolTip1.ReshowDelay = 40;
			btnPause.BackColor = System.Drawing.Color.White;
			btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
			btnPause.Enabled = false;
			btnPause.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnPause.Image = (System.Drawing.Image)resources.GetObject("btnPause.Image");
			btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnPause.Location = new System.Drawing.Point(145, 79);
			btnPause.Name = "btnPause";
			btnPause.Size = new System.Drawing.Size(128, 32);
			btnPause.TabIndex = 3;
			btnPause.Text = "Dừng";
			toolTip1.SetToolTip(btnPause, "Dư\u0300ng tương ta\u0301c");
			btnPause.UseVisualStyleBackColor = true;
			btnPause.Click += new System.EventHandler(BtnPause_Click);
			btnInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			btnInteract.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnInteract.Image = (System.Drawing.Image)resources.GetObject("btnInteract.Image");
			btnInteract.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnInteract.Location = new System.Drawing.Point(9, 79);
			btnInteract.Name = "btnInteract";
			btnInteract.Size = new System.Drawing.Size(128, 32);
			btnInteract.TabIndex = 2;
			btnInteract.Text = "Bă\u0301t đâ\u0300u";
			toolTip1.SetToolTip(btnInteract, "Bă\u0301t đâ\u0300u cha\u0323y tương ta\u0301c");
			btnInteract.UseVisualStyleBackColor = false;
			btnInteract.Click += new System.EventHandler(BtnInteract_Click);
			timer1.Enabled = true;
			timer1.Interval = 1800000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
			lblTrangThai.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTrangThai.Location = new System.Drawing.Point(0, 0);
			lblTrangThai.Name = "lblTrangThai";
			lblTrangThai.Size = new System.Drawing.Size(373, 26);
			lblTrangThai.TabIndex = 0;
			lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			plTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			plTrangThai.BackColor = System.Drawing.Color.Gainsboro;
			plTrangThai.Controls.Add(lblTrangThai);
			plTrangThai.Location = new System.Drawing.Point(868, 36);
			plTrangThai.Name = "plTrangThai";
			plTrangThai.Size = new System.Drawing.Size(373, 26);
			plTrangThai.TabIndex = 10;
			plTrangThai.Visible = false;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(statusStrip1);
			panel1.Controls.Add(grTimKiem);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1244, 610);
			panel1.TabIndex = 11;
			statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripStatusLabel5, lblCountSelect, toolStripStatusLabel7, lblCountTotal });
			statusStrip1.Location = new System.Drawing.Point(0, 586);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1242, 22);
			statusStrip1.SizingGrip = false;
			statusStrip1.TabIndex = 9;
			statusStrip1.Text = "statusStrip1";
			statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(statusStrip1_ItemClicked);
			toolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			toolStripStatusLabel5.Size = new System.Drawing.Size(66, 17);
			toolStripStatusLabel5.Text = "Đã chọn:";
			lblCountSelect.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblCountSelect.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
			lblCountSelect.Name = "lblCountSelect";
			lblCountSelect.Size = new System.Drawing.Size(16, 17);
			lblCountSelect.Text = "0";
			toolStripStatusLabel7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel7.Name = "toolStripStatusLabel7";
			toolStripStatusLabel7.Size = new System.Drawing.Size(53, 17);
			toolStripStatusLabel7.Text = "Tất cả:";
			lblCountTotal.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblCountTotal.ForeColor = System.Drawing.Color.Maroon;
			lblCountTotal.Name = "lblCountTotal";
			lblCountTotal.Size = new System.Drawing.Size(16, 17);
			lblCountTotal.Text = "0";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(1244, 610);
			base.Controls.Add(plTrangThai);
			base.Controls.Add(btnPause);
			base.Controls.Add(btnInteract);
			base.Controls.Add(grQuanLyThuMuc);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(menuStrip1);
			base.Controls.Add(dtgvAcc);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = menuStrip1;
			base.Name = "fShareBai";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Max System Care Pro";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(fSpamBaiViet_FormClosed);
			base.Load += new System.EventHandler(FMain_Load);
			((System.ComponentModel.ISupportInitialize)dtgvAcc).EndInit();
			ctmsAcc.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			bunifuCards1.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			grQuanLyThuMuc.ResumeLayout(false);
			grQuanLyThuMuc.PerformLayout();
			grTimKiem.ResumeLayout(false);
			grTimKiem.PerformLayout();
			plTrangThai.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
