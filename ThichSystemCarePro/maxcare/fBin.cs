using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Common;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;
using MetroFramework;
using MetroFramework.Controls;
using Newtonsoft.Json.Linq;
using WindowsFormsControlLibrary1;

namespace maxcare
{
	public class fBin : Form
	{
		private Random rd = new Random();

		private bool isStop;

		private JSON_Settings setting_general;

		private JSON_Settings setting_ShowDtgv;

		private object lock_StartProxy = new object();

		private object lock_FinishProxy = new object();

		private int checkDelayChrome = 0;

		private object lock_checkDelayChrome = new object();

		private List<string> LstKey = new List<string>();

		private List<string> LstLink = new List<string>();

		private List<string> lstua = new List<string>();

		private object _lockbackup = new object();

		private List<int> listPossitionApp = new List<int>();

		private bool isLookStatus = false;

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

		private JSON_Settings setting_MoTrinhDuyet;

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

		private List<Thread> lstThread = null;

		private IContainer components = null;

		public DataGridView dtgvAcc;

		private BunifuDragControl bunifuDragControl1;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private Button button2;

		private Button button1;

		private Button btnMinimize;

		private BunifuCustomLabel bunifuCustomLabel1;

		private MenuStrip menuStrip1;

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

		private ToolStripMenuItem checkCookieToolStripMenuItem;

		private ToolStripMenuItem tấtCảToolStripMenuItem;

		private ToolStripMenuItem bỏChọnTấtCảToolStripMenuItem;

		private ToolStripMenuItem passToolStripMenuItem;

		private ToolStripMenuItem kiểmTraCookieToolStripMenuItem;

		private ToolStripMenuItem kiểmTraTokenToolStripMenuItem;

		private ToolStripMenuItem tảiLạiDanhSáchToolStripMenuItem;

		private ToolStripMenuItem kiểmTraTàiKhoảnToolStripMenuItem;

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

		private ToolStripMenuItem uidPass2FaToolStripMenuItem;

		private BunifuDragControl bunifuDragControl2;

		private ToolTip toolTip1;

		private ToolStripMenuItem đinhDangKhacToolStripMenuItem;

		private ToolStripMenuItem maBaoMât6SôToolStripMenuItem;

		private ToolStripMenuItem thoátToolStripMenuItem;

		private ToolStripMenuItem useragentToolStripMenuItem1;

		private ToolStripMenuItem proxyToolStripMenuItem1;

		private ComboBox cbbSearch;

		private MetroButton btnLoadAcc;

		private MetroComboBox cbbTinhTrang;

		private Label label2;

		private ToolStripMenuItem kiểmTraMailpassMailToolStripMenuItem;

		private MetroButton BtnSearch;

		private ToolStripMenuItem uidToolStripMenuItem;

		private ToolStripMenuItem checkAvatarToolStripMenuItem;

		private ToolStripMenuItem checkProxyToolStripMenuItem;

		private ToolStripMenuItem checkProfileToolStripMenuItem1;

		private ToolStripMenuItem checkInfoUIDToolStripMenuItem;

		private ToolStripMenuItem checkBackupToolStripMenuItem1;

		private ToolStripMenuItem khôiPhucTaiKhoanToolStripMenuItem;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel5;

		private ToolStripStatusLabel lblCountSelect;

		private ToolStripStatusLabel toolStripStatusLabel7;

		private ToolStripStatusLabel lblCountTotal;

		private Button button9;

		private Button button3;

		private Label label3;

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

		private DataGridViewTextBoxColumn cDateDelete;

		private DataGridViewTextBoxColumn cStatus;

		public fBin()
		{
			InitializeComponent();
			LoadSetting();
			LoadConfigManHinh();
			LoadcbbSearch();
			menuStrip1.Cursor = Cursors.Hand;
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(thoátToolStripMenuItem);
			Language.GetValue(grTimKiem);
			Language.GetValue(grQuanLyThuMuc);
			Language.GetValue(label1);
			Language.GetValue(label2);
			Language.GetValue(button9);
			Language.GetValue(button3);
			Language.GetValue(toolStripStatusLabel5);
			Language.GetValue(toolStripStatusLabel7);
			Language.GetValue(label3);
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
			Language.GetValue(khôiPhucTaiKhoanToolStripMenuItem);
			Language.GetValue(xóaTàiKhoảnToolStripMenuItem);
			Language.GetValue(maBaoMât6SôToolStripMenuItem);
			Language.GetValue(đinhDangKhacToolStripMenuItem);
			Language.GetValue(checkCookieToolStripMenuItem);
			Language.GetValue(tảiLạiDanhSáchToolStripMenuItem);
		}

		private void LoadcbbSearch()
		{
			Dictionary<string, string> dataSource = new Dictionary<string, string>
			{
				{ "cUid", "UID" },
				{ "cToken", "Token" },
				{ "cCookies", "Cookie" },
				{ "cEmail", "Email" },
				{ "cPassMail", "Pass email" },
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
				{
					"cPassword",
					Language.GetValue("Mật khẩu")
				},
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

		protected override void OnLoad(EventArgs args)
		{
			Application.Idle += OnLoaded;
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
			LoadCbbTinhTrang(fChonThuMuc.lstChooseIdFilesFromBin);
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
					result = ((text2 == "999999") ? CollectionHelper.CloneList(fChonThuMuc.lstChooseIdFilesFromBin) : new List<string> { cbbThuMuc.SelectedValue.ToString() });
				}
			}
			catch
			{
			}
			return result;
		}

		private void LoadAccountFromFile(List<string> lstIdFile = null, string info = "", bool isGetActive = false)
		{
			try
			{
				dtgvAcc.Rows.Clear();
				if (info == "[Tất cả tình trạng]" || info == Language.GetValue("[Tất cả tình trạng]"))
				{
					info = "";
				}
				DataTable accFromFile = CommonSQL.GetAccFromFile(lstIdFile, info, isGetActive);
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

		public void SetStatusAccount(int indexRow, string value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", value);
		}

		public void SetInfoAccount(string id, int indexRow, string value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cInfo", value);
			SetRowColor(indexRow);
			CommonSQL.UpdateFieldToAccount(id, "info", value);
		}

		public void SetCellAccount(int indexRow, string column, object value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, column, value);
		}

		public void SetCellAccount(int indexRow, int column, object value)
		{
			DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, column, value);
		}

		public string GetStatusAccount(int indexRow)
		{
			return DatagridviewHelper.GetStatusDataGridView(dtgvAcc, indexRow, "cStatus");
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

		private void LoadRowColor(int rowIndex = -1)
		{
			LoadSetting();
			if (setting_general.GetValueInt("typePhanBietMau") == 0)
			{
				if (rowIndex == -1)
				{
					for (int i = 0; i < dtgvAcc.RowCount; i++)
					{
						string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cInfo");
						if (statusDataGridView == "Live")
						{
							dtgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
						}
						else if (statusDataGridView.Contains("Die") || statusDataGridView.Contains(Language.GetValue("Checkpoint")) || statusDataGridView.Contains("Changed pass"))
						{
							dtgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
						}
					}
					return;
				}
				string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, rowIndex, "cInfo");
				string text = statusDataGridView2;
				if (!(text == "Live"))
				{
					if (text == "Die")
					{
						dtgvAcc.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
					}
				}
				else
				{
					dtgvAcc.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
				}
			}
			else if (rowIndex == -1)
			{
				for (int j = 0; j < dtgvAcc.RowCount; j++)
				{
					string statusDataGridView3 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cInfo");
					if (statusDataGridView3.Contains("Die") || statusDataGridView3.Contains(Language.GetValue("Checkpoint")))
					{
						dtgvAcc.Rows[j].DefaultCellStyle.ForeColor = Color.Red;
					}
				}
			}
			else
			{
				string statusDataGridView4 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, rowIndex, "cInfo");
				string text2 = statusDataGridView4;
				if (!(text2 == "Live") && text2 == "Die")
				{
					dtgvAcc.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
				}
			}
		}

		private void LoadStatusGrid(string status, string colname, int rowIndex, int typeColor, DataGridView gv)
		{
			if (!isLookStatus)
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, rowIndex, colname, status);
			}
			if (colname == "cInfo")
			{
				LoadRowColor(rowIndex);
			}
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
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cChose")))
					{
						list.Add(DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cId"));
						break;
					}
				}
				if (list.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn danh sách tài khoản muốn copy thông tin!"), 3);
					return;
				}
				string text = "";
				switch (modeCopy)
				{
				case "uid|pass|token|cookie":
				{
					for (int num4 = 0; num4 < dtgvAcc.RowCount; num4++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num4, "cUid") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num4, "cPassword") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num4, "cToken") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num4, "cCookies") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "uid|pass":
				{
					for (int k = 0; k < dtgvAcc.RowCount; k++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[k].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, k, "cUid") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, k, "cPassword") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "mail|passmail":
				{
					for (int num6 = 0; num6 < dtgvAcc.RowCount; num6++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num6].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num6, "cEmail") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num6, "cPassMail") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "ma2fa":
				{
					for (int num10 = 0; num10 < dtgvAcc.RowCount; num10++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num10].Cells["cChose"].Value))
						{
							try
							{
								text = text + MCommon.Common.GetTotp(DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num10, "cFa2")) + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "2fa":
				{
					for (int n = 0; n < dtgvAcc.RowCount; n++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[n].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, n, "cFa2") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "uid":
				{
					for (int num9 = 0; num9 < dtgvAcc.RowCount; num9++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num9].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num9, "cUid") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "pass":
				{
					for (int num = 0; num < dtgvAcc.RowCount; num++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num, "cPassword") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "cookie":
				{
					for (int num12 = 0; num12 < dtgvAcc.RowCount; num12++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num12].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num12, "cCookies") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "useragent":
				{
					for (int num7 = 0; num7 < dtgvAcc.RowCount; num7++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num7].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num7, "cUseragent") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "proxy":
				{
					for (int num3 = 0; num3 < dtgvAcc.RowCount; num3++)
					{
						if (!Convert.ToBoolean(dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							continue;
						}
						try
						{
							string text2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num3, "cProxy");
							if (text2.EndsWith("*0") || text2.EndsWith("*1"))
							{
								text2 = text2.Substring(0, text2.Length - 2);
							}
							text = text + text2 + "\r\n";
						}
						catch
						{
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "token":
				{
					for (int l = 0; l < dtgvAcc.RowCount; l++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[l].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, l, "cToken") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "name":
				{
					for (int num11 = 0; num11 < dtgvAcc.RowCount; num11++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num11].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num11, "cName") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text.TrimEnd('\r', '\n'));
					break;
				}
				case "uid|pass|2fa":
				{
					for (int num8 = 0; num8 < dtgvAcc.RowCount; num8++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num8].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num8, "cUid") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num8, "cPassword") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num8, "cFa2") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "uid|pass|token|cookie|mail|passmail":
				{
					for (int num5 = 0; num5 < dtgvAcc.RowCount; num5++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num5].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num5, "cUid") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num5, "cPassword") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num5, "cToken") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num5, "cCookies") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num5, "cEmail") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num5, "cPassMail") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "birthday":
				{
					for (int num2 = 0; num2 < dtgvAcc.RowCount; num2++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, num2, "cBirthday") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text.TrimEnd('\r', '\n'));
					break;
				}
				case "mail":
				{
					for (int m = 0; m < dtgvAcc.RowCount; m++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[m].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, m, "cEmail") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				case "uid|pass|token|cookie|mail|passmail|fa2":
				{
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							try
							{
								text = text + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cUid") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cPassword") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cToken") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cCookies") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cEmail") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cPassMail") + "|" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cFa2") + "\r\n";
							}
							catch
							{
							}
						}
					}
					Clipboard.SetText(text);
					break;
				}
				}
			}
			catch
			{
			}
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

		private void FMain_Load(object sender, EventArgs e)
		{
		}

		private void CtmsAcc_Opening(object sender, CancelEventArgs e)
		{
			trạngTháiToolStripMenuItem.DropDownItems.Clear();
			List<string> list = new List<string>();
			string text = "";
			string text2 = "";
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				text = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cStatus");
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
			for (int j = 0; j < list.Count; j++)
			{
				trạngTháiToolStripMenuItem.DropDownItems.Add(list[j]);
				trạngTháiToolStripMenuItem.DropDownItems[j].Click += SelectGridByStatus;
			}
			tinhTrangToolStripMenuItem.DropDownItems.Clear();
			list = new List<string>();
			for (int k = 0; k < dtgvAcc.RowCount; k++)
			{
				if (dtgvAcc.Rows[k].Cells["cInfo"].Value != null && !DatagridviewHelper.GetStatusDataGridView(dtgvAcc, k, "cInfo").Equals("") && !list.Contains(DatagridviewHelper.GetStatusDataGridView(dtgvAcc, k, "cInfo")))
				{
					list.Add(DatagridviewHelper.GetStatusDataGridView(dtgvAcc, k, "cInfo"));
				}
			}
			for (int l = 0; l < list.Count; l++)
			{
				tinhTrangToolStripMenuItem.DropDownItems.Add(list[l]);
				tinhTrangToolStripMenuItem.DropDownItems[l].Click += SelectGridByStatus1;
			}
		}

		private void SelectGridByStatus1(object sender, EventArgs e)
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
				string value = toolStripMenuItem.Text;
				if (DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cInfo").Equals(value))
				{
					dtgvAcc.Rows[i].Cells["cChose"].Value = true;
				}
				else
				{
					dtgvAcc.Rows[i].Cells["cChose"].Value = false;
				}
			}
		}

		private void SelectGridByStatus(object sender, EventArgs e)
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
				string value = toolStripMenuItem.Text;
				if (DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cStatus").Contains(value))
				{
					dtgvAcc.Rows[i].Cells["cChose"].Value = true;
				}
				else
				{
					dtgvAcc.Rows[i].Cells["cChose"].Value = false;
				}
			}
		}

		private void DeleteAccount()
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
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản cần xóa!"), 3);
				return;
			}
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Bạn có thực sự muốn xóa {0} tài khoản đã chọn?"), CountChooseRowInDatagridview()) + "\r\n\r\n" + Language.GetValue("Chu\u0301 y\u0301: Ta\u0300i khoa\u0309n đa\u0303 xo\u0301a thi\u0300 không thê\u0309 khôi phu\u0323c la\u0323i đươ\u0323c nư\u0303a!")) == DialogResult.Yes)
			{
				if (CommonSQL.DeleteAccountToDatabase(list, isReallyDelete: true))
				{
					for (int j = 0; j < dtgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							dtgvAcc.Rows.RemoveAt(j--);
						}
					}
					if (CommonSQL.DeleteFileToDatabaseIfEmptyAccount())
					{
						RefreshDtgvAcc();
					}
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Xóa thất bại, vui lòng thử lại sau!"), 2);
				}
				UpdateSTTOnDtgvAcc();
			}
			UpdateTotalCountRecord();
			UpdateSelectCountRecord();
		}

		private void RefreshDtgvAcc()
		{
			LoadRowColor();
			UpdateSTTOnDtgvAcc();
			UpdateTotalCountRecord();
			UpdateSelectCountRecord();
		}

		private bool CheckIsUidFacebook(string uid)
		{
			return MCommon.Common.IsNumber(uid) && !uid.StartsWith("0");
		}

		private void cControl(string dt)
		{
			Invoke((MethodInvoker)delegate
			{
				try
				{
					if (dt == "start")
					{
						grTimKiem.Enabled = false;
						grQuanLyThuMuc.Enabled = false;
					}
					else if (dt == "stop")
					{
						grTimKiem.Enabled = true;
						grQuanLyThuMuc.Enabled = true;
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

		private void LoadStatusDatagridView(int row, string status)
		{
			if (!isLookStatus)
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, row, "cStatus", status);
			}
		}

		private void TảiLạiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BtnLoadAcc_Click(null, null);
		}

		private void CbbFileAccount_SelectedIndexChanged(object sender, EventArgs e)
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
					MCommon.Common.ShowForm(new fChonThuMuc(isFromBin: true));
					if (!fChonThuMuc.isAdd || fChonThuMuc.lstChooseIdFilesFromBin == null || fChonThuMuc.lstChooseIdFilesFromBin.Count == 0)
					{
						isExcute_CbbThuMuc_SelectedIndexChanged = false;
						cbbThuMuc.SelectedIndex = ((indexCbbThuMucOld != -1) ? indexCbbThuMucOld : 0);
						isExcute_CbbThuMuc_SelectedIndexChanged = true;
					}
					else
					{
						LoadCbbTinhTrang(fChonThuMuc.lstChooseIdFilesFromBin);
					}
				}
			}
			else
			{
				LoadCbbTinhTrang();
			}
			indexCbbThuMucOld = cbbThuMuc.SelectedIndex;
		}

		private void MailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("mail|passmail");
		}

		private void UidPassTokenCookieMailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie|mail|passmail");
		}

		private void UpdateSelectCountRecord()
		{
			int num = 0;
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					num++;
				}
			}
			try
			{
				lblCountSelect.Text = num.ToString();
			}
			catch
			{
			}
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
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kiểm tra lại token trung gian!"));
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
								LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row, 0, dtgvAcc);
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
					LoadStatusGrid(Language.GetValue("Đa\u0303 co\u0301 avatar!"), "cStatus", row, 2, dtgvAcc);
					LoadStatusGrid("Yes", "cAvatar", row, 0, dtgvAcc);
					CommonSQL.UpdateFieldToAccount(id, "avatar", "Yes");
				}
				else
				{
					LoadStatusGrid(Language.GetValue("Không co\u0301 avatar!"), "cStatus", row, 2, dtgvAcc);
					LoadStatusGrid("No", "cAvatar", row, 0, dtgvAcc);
					CommonSQL.UpdateFieldToAccount(id, "avatar", "No");
				}
			}
			catch
			{
				LoadStatusGrid(Language.GetValue("Lỗi!!!"), "cStatus", row, 2, dtgvAcc);
			}
		}

		private void UpdateTotalCountRecord()
		{
			try
			{
				lblCountTotal.Text = dtgvAcc.Rows.Count.ToString();
			}
			catch
			{
			}
		}

		private void OnLoaded(object sender, EventArgs e)
		{
			Application.Idle -= OnLoaded;
			LoadConfigManHinh();
			LoadCbbThuMuc();
			LoadCbbTinhTrang();
		}

		private void LoadCbbThuMuc()
		{
			isExcute_CbbThuMuc_SelectedIndexChanged = false;
			DataTable allFilesFromDatabaseForBin = CommonSQL.GetAllFilesFromDatabaseForBin(isShowAll: true);
			cbbThuMuc.DataSource = allFilesFromDatabaseForBin;
			cbbThuMuc.ValueMember = "id";
			cbbThuMuc.DisplayMember = "name";
			isExcute_CbbThuMuc_SelectedIndexChanged = true;
		}

		private void LoadCbbTinhTrang(List<string> lstIdFile = null)
		{
			try
			{
				DataTable allInfoFromAccount = CommonSQL.GetAllInfoFromAccount(lstIdFile, isGetActive: false);
				cbbTinhTrang.DataSource = allInfoFromAccount;
				cbbTinhTrang.ValueMember = "id";
				cbbTinhTrang.DisplayMember = "name";
			}
			catch
			{
			}
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
									LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row3, 0, dtgvAcc);
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
									LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row, 0, dtgvAcc);
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
									LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row5, 0, dtgvAcc);
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
									LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row2, 0, dtgvAcc);
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
									LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row4, 0, dtgvAcc);
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
									LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row6, 0, dtgvAcc);
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
					LoadStatusGrid(Language.GetValue("Không tìm thấy mail") + "!!!", "cStatus", row, 2, dtgvAcc);
				}
				else if (text.EndsWith("@hotmail.com") || text.EndsWith("@outlook.com"))
				{
					string text3 = MCommon.Common.CheckAccountHotmail(text, text2);
					if (text3.Equals("1"))
					{
						LoadStatusGrid(Language.GetValue("Tài khoản mail: live!"), "cStatus", row, 0, dtgvAcc);
					}
					else
					{
						LoadStatusGrid(Language.GetValue("Tài khoản mail: die!"), "cStatus", row, 1, dtgvAcc);
					}
				}
				else
				{
					LoadStatusGrid(Language.GetValue("Mail chưa hỗ trợ") + "!!!", "cStatus", row, 2, dtgvAcc);
				}
			}
			catch
			{
				LoadStatusGrid(Language.GetValue("Lỗi!!!"), "cStatus", row, 2, dtgvAcc);
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
					text2 = Language.GetValue("Không check đươ\u0323c!");
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
				string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cId");
				string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cCookies");
				string statusDataGridView3 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cToken");
				string text2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cUseragent");
				string text3 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text3 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cProxy");
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
				if (!CommonRequest.CheckLiveToken(statusDataGridView2, statusDataGridView3, text2, text3, typeProxy))
				{
					text4 = "Token die";
				}
				else
				{
					text = "Live";
					text4 = "Token live";
				}
				LoadStatusGrid(text4, "cStatus", row, 2, dtgvAcc);
				if (text != "")
				{
					SetInfoAccount(statusDataGridView, row, text);
				}
			}
			catch
			{
				LoadStatusGrid(Language.GetValue("Không check đươ\u0323c!"), "cStatus", row, 2, dtgvAcc);
			}
		}

		private void CheckMyCookie(int row)
		{
			try
			{
				string text = "";
				string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cId");
				string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cCookies");
				string text2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cUseragent");
				string text3 = "";
				int typeProxy = 0;
				if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
				{
					text3 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cProxy");
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
				if (!CommonRequest.CheckLiveCookie(statusDataGridView2, text2, text3, typeProxy).StartsWith("1|"))
				{
					text4 = "Cookie die";
				}
				else
				{
					text = "Live";
					text4 = "Cookie live";
				}
				LoadStatusGrid(text4, "cStatus", row, 2, dtgvAcc);
				if (text != "")
				{
					SetInfoAccount(statusDataGridView, row, text);
				}
			}
			catch
			{
				LoadStatusGrid(Language.GetValue("Không check đươ\u0323c!"), "cStatus", row, 2, dtgvAcc);
			}
		}

		private void CheckDangCheckpoint(int row)
		{
			string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
			string email = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
			string pass = dtgvAcc.Rows[row].Cells["cPassword"].Value.ToString();
			string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cUseragent");
			string text = "";
			int typeProxy = 0;
			if (setting_general.GetValueInt("ip_iTypeChangeIp") == 9)
			{
				text = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cProxy");
				typeProxy = (text.EndsWith("*1") ? 1 : 0);
				if (text.EndsWith("*0") || text.EndsWith("*1"))
				{
					text = text.Substring(0, text.Length - 2);
				}
			}
			if (statusDataGridView == "" && text.Split(':').Length == 4)
			{
				statusDataGridView = Base.useragentDefault;
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
				CommonSQL.UpdateFieldToAccount(id, "cookie1", text4);
				LoadStatusGrid(text4, "cCookies", row, 1, dtgvAcc);
			}
			if (text2 != "")
			{
				SetInfoAccount(id, row, text2);
			}
			LoadStatusGrid(text3, "cStatus", row, 1, dtgvAcc);
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
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn kiểu tìm kiếm!"));
					return;
				}
				string columnName = cbbSearch.SelectedValue.ToString();
				string text = txbSearch.Text.Trim();
				if (text == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập nội dung tìm kiếm!"));
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
				if (list.Count <= 0)
				{
					return;
				}
				int index2 = dtgvAcc.CurrentRow.Index;
				if (index2 >= list[list.Count - 1])
				{
					index = 0;
				}
				else
				{
					for (int j = 0; j < list.Count; j++)
					{
						if (index2 < list[j])
						{
							index = j;
							break;
						}
					}
				}
				int index3 = list[index];
				dtgvAcc.CurrentCell = dtgvAcc.Rows[index3].Cells[columnName];
				dtgvAcc.ClearSelection();
				dtgvAcc.Rows[index3].Selected = true;
			}
			catch
			{
			}
		}

		private void UidPassTokenCookieMailPassMail2faToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|token|cookie|mail|passmail|fa2");
		}

		private void UpdateSTTOnDtgvAcc()
		{
			for (int i = 0; i < dtgvAcc.RowCount; i++)
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, i, "cSTT", i + 1);
			}
		}

		private void fAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("2fa");
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
								LoadStatusGrid(Language.GetValue("Đang xo\u0301a profile..."), "cStatus", row, 0, dtgvAcc);
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
					LoadStatusGrid(Language.GetValue("Chưa tạo profile!"), "cStatus", row, 0, dtgvAcc);
					return;
				}
				string path = setting_general.GetValue("txbPathProfile") + "\\" + text;
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
					LoadStatusGrid(Language.GetValue("Xóa profile thành công!"), "cStatus", row, 0, dtgvAcc);
					LoadStatusGrid("No", "cProfile", row, 0, dtgvAcc);
					CommonSQL.UpdateFieldToAccount(id, "profile", "No");
				}
				else
				{
					LoadStatusGrid(Language.GetValue("Chưa tạo profile!"), "cStatus", row, 0, dtgvAcc);
				}
			}
			catch
			{
				LoadStatusGrid(Language.GetValue("Xóa profile thất bại!"), "cStatus", row, 0, dtgvAcc);
			}
		}

		private void checkProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
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
								LoadStatusGrid(Language.GetValue("Đang check profile..."), "cStatus", row, 0, dtgvAcc);
								CheckProfile(row);
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

		private void CheckProfile(int row)
		{
			try
			{
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				string text = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				string path = setting_general.GetValue("txbPathProfile") + "\\" + text;
				if (Directory.Exists(path))
				{
					LoadStatusGrid(Language.GetValue("Đã có profile!"), "cStatus", row, 0, dtgvAcc);
					LoadStatusGrid("Yes", "cProfile", row, 0, dtgvAcc);
					CommonSQL.UpdateFieldToAccount(id, "profile", "Yes");
				}
				else
				{
					LoadStatusGrid(Language.GetValue("Chưa tạo profile!"), "cStatus", row, 0, dtgvAcc);
					LoadStatusGrid("No", "cProfile", row, 0, dtgvAcc);
					CommonSQL.UpdateFieldToAccount(id, "profile", "No");
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

		private void uidPass2FaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("uid|pass|2fa");
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

		private void LoadSetting()
		{
			setting_general = new JSON_Settings("configGeneral");
		}

		private void mơFileHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			new Thread((ThreadStart)delegate
			{
				try
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
									try
									{
										string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cCookies");
										string text = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cUid");
										if (text == "")
										{
											text = Regex.Match(statusDataGridView, "c_user=(.*?);").Groups[1].Value;
										}
										if (File.Exists("backup\\" + text + "\\" + text + ".html"))
										{
											Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "\\backup\\" + text + "\\" + text + ".html");
										}
										else
										{
											DatagridviewHelper.SetStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Chưa tạo html!"));
										}
										Interlocked.Decrement(ref iThread);
									}
									catch (Exception ex2)
									{
										CommonCSharp.ExportError(null, ex2.ToString());
									}
								}).Start();
							}
							else
							{
								CommonCSharp.DelayTime(1.0);
							}
						}
						else
						{
							num++;
						}
					}
					while (iThread > 0)
					{
						CommonCSharp.DelayTime(1.0);
					}
				}
				catch (Exception ex)
				{
					CommonCSharp.ExportError(null, ex.ToString());
				}
			}).Start();
		}

		private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = "";
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					return;
				}
				text = folderBrowserDialog.SelectedPath;
			}
			int num = 0;
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				try
				{
					if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						continue;
					}
					string text2 = dtgvAcc.Rows[i].Cells["cUid"].Value.ToString();
					try
					{
						if (File.Exists("backup\\" + text2 + "\\" + text2 + ".html"))
						{
							File.Copy("backup\\" + text2 + "\\" + text2 + ".html", text + "\\" + text2 + ".html");
							num++;
						}
					}
					catch
					{
					}
				}
				catch
				{
				}
			}
			MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Copy thành công {0} tệp backup html!"), num));
		}

		private void thưMụcToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			string text = "";
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					return;
				}
				text = folderBrowserDialog.SelectedPath;
			}
			int num = 0;
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				try
				{
					if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						continue;
					}
					string text2 = dtgvAcc.Rows[i].Cells["cUid"].Value.ToString();
					try
					{
						if (!Directory.Exists(text + "\\" + text2))
						{
							Directory.CreateDirectory(text + "\\" + text2);
						}
						string[] files = Directory.GetFiles("backup\\" + text2);
						for (int j = 0; j < files.Length; j++)
						{
							File.Copy(files[j], text + "\\" + text2 + "\\" + Path.GetFileName(files[j]));
						}
						num++;
					}
					catch
					{
					}
				}
				catch
				{
				}
			}
			MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Copy thành công {0} thư mục backup!"), num));
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
			MCommon.Common.ShowForm(new fCauHinhHienThi());
			LoadConfigManHinh();
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
								LoadStatusGrid(Language.GetValue("Đang kiểm tra..."), "cStatus", row, 0, dtgvAcc);
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
					LoadStatusGrid("Proxy Die!", "cStatus", row, 2, dtgvAcc);
				}
				else
				{
					LoadStatusGrid("Proxy Live!", "cStatus", row, 2, dtgvAcc);
				}
			}
			catch
			{
				LoadStatusGrid(Language.GetValue("Lỗi!!!"), "cStatus", row, 2, dtgvAcc);
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

		private void mởThưMụcBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < dtgvAcc.Rows.Count; i++)
			{
				if (isStop)
				{
					break;
				}
				if (!Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
				{
					continue;
				}
				string text = "backup\\" + DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cUid");
				if (Directory.Exists(text))
				{
					try
					{
						Process.Start(text);
						LoadStatusDatagridView(i, Language.GetValue("Mở thành công!"));
					}
					catch
					{
						LoadStatusDatagridView(i, Language.GetValue("Mở thất bại!"));
					}
				}
				else
				{
					LoadStatusDatagridView(i, Language.GetValue("Chưa backup!"));
				}
			}
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
					LoadAccountFromFile(fChonThuMuc.lstChooseIdFilesFromBin, cbbTinhTrang.Text);
				}
			}
			else
			{
				LoadAccountFromFile(null, cbbTinhTrang.Text);
			}
			indexCbbTinhTrangOld = cbbTinhTrang.SelectedIndex;
		}

		private void giưLaiProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteAccount();
		}

		private void kiểmTraMailpassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KiemTraTaiKhoan(4);
		}

		private void tênToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("name");
		}

		private void ngàySinhToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("birthday");
		}

		public int CountChooseRowInDatagridview()
		{
			int num = 0;
			try
			{
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						num++;
					}
				}
			}
			catch
			{
			}
			return num;
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
								LoadStatusGrid(Language.GetValue("Đang xo\u0301a dữ liệu backup..."), "cStatus", row, 0, dtgvAcc);
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
					LoadStatusGrid(Language.GetValue("Chưa backup!"), "cStatus", row, 0, dtgvAcc);
					return;
				}
				string path = "backup\\" + text;
				if (Directory.Exists(path))
				{
					Directory.Delete(path, recursive: true);
					LoadStatusGrid(Language.GetValue("Xóa dữ liệu backup thành công!"), "cStatus", row, 0, dtgvAcc);
					LoadStatusGrid("", "cBackup", row, 0, dtgvAcc);
					CommonSQL.UpdateFieldToAccount(id, "backup", "");
				}
				else
				{
					LoadStatusGrid(Language.GetValue("Chưa backup!"), "cStatus", row, 0, dtgvAcc);
				}
			}
			catch
			{
				LoadStatusGrid(Language.GetValue("Xóa dữ liệu backup thất bại!"), "cStatus", row, 0, dtgvAcc);
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
								SetStatusAccount(row, Language.GetValue("Đang check backup..."));
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

		private void button9_Click(object sender, EventArgs e)
		{
			KhoiPhucTaiKhoan();
		}

		private void KhoiPhucTaiKhoan()
		{
			if (CountChooseRowInDatagridview() == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n ta\u0300i khoa\u0309n câ\u0300n khôi phu\u0323c!"), 3);
				return;
			}
			MCommon.Common.ShowForm(new fCauHinhKhoiPhucTaiKhoan());
			if (fCauHinhKhoiPhucTaiKhoan.isOK)
			{
				try
				{
					if (fCauHinhKhoiPhucTaiKhoan.typeThuMuc == 0)
					{
						List<string> list = new List<string>();
						List<string> list2 = new List<string>();
						for (int i = 0; i < dtgvAcc.RowCount; i++)
						{
							if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
							{
								string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, i, "cId");
								string idFileFromIdAccount = CommonSQL.GetIdFileFromIdAccount(statusDataGridView);
								list.Add(statusDataGridView);
								list2.Add(idFileFromIdAccount);
								dtgvAcc.Rows.RemoveAt(i--);
							}
						}
						UpdateSTTOnDtgvAcc();
						CommonSQL.UpdateFieldToFile(list2, "active", "1");
						if (CommonSQL.UpdateFieldToAccount(list, "active", "1"))
						{
							MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đa\u0303 khôi phu\u0323c tha\u0300nh công {0} ta\u0300i khoa\u0309n!"), list.Count));
						}
						else
						{
							MessageBoxHelper.ShowMessageBox(Language.GetValue("Lô\u0303i khôi phu\u0323c ta\u0300i khoa\u0309n, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
						}
					}
					else
					{
						string idFile = fCauHinhKhoiPhucTaiKhoan.idFile;
						List<string> list3 = new List<string>();
						for (int j = 0; j < dtgvAcc.RowCount; j++)
						{
							if (Convert.ToBoolean(dtgvAcc.Rows[j].Cells["cChose"].Value))
							{
								string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, j, "cId");
								list3.Add(statusDataGridView2);
								dtgvAcc.Rows.RemoveAt(j--);
							}
						}
						UpdateSTTOnDtgvAcc();
						if (CommonSQL.UpdateFieldToAccount(list3, "idFile", idFile) && CommonSQL.UpdateFieldToAccount(list3, "active", "1"))
						{
							MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đa\u0303 khôi phu\u0323c tha\u0300nh công {0} ta\u0300i khoa\u0309n!"), list3.Count));
						}
						else
						{
							MessageBoxHelper.ShowMessageBox(Language.GetValue("Lô\u0303i khôi phu\u0323c ta\u0300i khoa\u0309n, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
						}
					}
				}
				catch (Exception ex)
				{
					MCommon.Common.ExportError(null, ex, "Khoi Phuc Tai Khoan");
				}
			}
			UpdateTotalCountRecord();
			UpdateSelectCountRecord();
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			DeleteAccount();
		}

		private void khôiPhucTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			KhoiPhucTaiKhoan();
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

		private void label3_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fBin));
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
			cDateDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ctmsAcc = new MetroFramework.Controls.MetroContextMenu(components);
			chọnLiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			liveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tinhTrangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			trạngTháiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			bỏChọnTấtCảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			khôiPhucTaiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xóaTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			checkCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraWallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkInfoUIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkAvatarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkProfileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			checkBackupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			kiểmTraMailpassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			grQuanLyThuMuc = new System.Windows.Forms.GroupBox();
			btnLoadAcc = new MetroFramework.Controls.MetroButton();
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
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountSelect = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountTotal = new System.Windows.Forms.ToolStripStatusLabel();
			button9 = new System.Windows.Forms.Button();
			button3 = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dtgvAcc).BeginInit();
			ctmsAcc.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			bunifuCards1.SuspendLayout();
			menuStrip1.SuspendLayout();
			grQuanLyThuMuc.SuspendLayout();
			grTimKiem.SuspendLayout();
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
			dtgvAcc.Columns.AddRange(cChose, cStt, cId, cUid, cToken, cCookies, cEmail, cPhone, cName, cFollow, cFriend, cGroup, cBirthday, cGender, cPassword, cMailRecovery, cPassMail, cBackup, cFa2, cUseragent, cProxy, cDateCreateAcc, cAvatar, cProfile, cThuMuc, cInteractEnd, cDevice, cInfo, cGhiChu, cDateDelete, cStatus);
			dtgvAcc.ContextMenuStrip = ctmsAcc;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dtgvAcc.DefaultCellStyle = dataGridViewCellStyle2;
			dtgvAcc.Location = new System.Drawing.Point(2, 124);
			dtgvAcc.Name = "dtgvAcc";
			dtgvAcc.ReadOnly = true;
			dtgvAcc.RowHeadersVisible = false;
			dtgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvAcc.Size = new System.Drawing.Size(1199, 461);
			dtgvAcc.TabIndex = 0;
			dtgvAcc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(DtgvAcc_CellClick);
			dtgvAcc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvAcc_CellDoubleClick);
			dtgvAcc.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(dtgvAcc_SortCompare);
			dtgvAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(DtgvAcc_KeyDown);
			cChose.HeaderText = "Chọn";
			cChose.Name = "cChose";
			cChose.ReadOnly = true;
			cChose.Width = 40;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			cStt.DefaultCellStyle = dataGridViewCellStyle3;
			cStt.HeaderText = "STT";
			cStt.Name = "cStt";
			cStt.ReadOnly = true;
			cStt.Width = 35;
			cId.HeaderText = "Id";
			cId.Name = "cId";
			cId.ReadOnly = true;
			cId.Visible = false;
			cId.Width = 90;
			cUid.HeaderText = "UID";
			cUid.Name = "cUid";
			cUid.ReadOnly = true;
			cUid.Width = 80;
			cToken.HeaderText = "Token";
			cToken.Name = "cToken";
			cToken.ReadOnly = true;
			cToken.Width = 70;
			cCookies.HeaderText = "Cookie";
			cCookies.Name = "cCookies";
			cCookies.ReadOnly = true;
			cCookies.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cCookies.Width = 70;
			cEmail.HeaderText = "Email";
			cEmail.Name = "cEmail";
			cEmail.ReadOnly = true;
			cEmail.Width = 60;
			cPhone.HeaderText = "Phone";
			cPhone.Name = "cPhone";
			cPhone.ReadOnly = true;
			cPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cPhone.Visible = false;
			cPhone.Width = 90;
			cName.HeaderText = "Tên";
			cName.Name = "cName";
			cName.ReadOnly = true;
			cName.Width = 70;
			cFollow.HeaderText = "Theo do\u0303i";
			cFollow.Name = "cFollow";
			cFollow.ReadOnly = true;
			cFollow.Width = 80;
			cFriend.HeaderText = "Ba\u0323n be\u0300";
			cFriend.Name = "cFriend";
			cFriend.ReadOnly = true;
			cFriend.Width = 70;
			cGroup.HeaderText = "Nho\u0301m";
			cGroup.Name = "cGroup";
			cGroup.ReadOnly = true;
			cGroup.Width = 60;
			cBirthday.HeaderText = "Nga\u0300y sinh";
			cBirthday.Name = "cBirthday";
			cBirthday.ReadOnly = true;
			cBirthday.Width = 90;
			cGender.HeaderText = "Giới Tính";
			cGender.Name = "cGender";
			cGender.ReadOnly = true;
			cGender.Width = 80;
			cPassword.HeaderText = "Mật khẩu";
			cPassword.Name = "cPassword";
			cPassword.ReadOnly = true;
			cPassword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cPassword.Visible = false;
			cPassword.Width = 70;
			cMailRecovery.HeaderText = "Email khôi phục";
			cMailRecovery.Name = "cMailRecovery";
			cMailRecovery.ReadOnly = true;
			cMailRecovery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cMailRecovery.Visible = false;
			cMailRecovery.Width = 120;
			cPassMail.HeaderText = "Mật khẩu mail";
			cPassMail.Name = "cPassMail";
			cPassMail.ReadOnly = true;
			cPassMail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cPassMail.Visible = false;
			cPassMail.Width = 120;
			cBackup.HeaderText = "Backup";
			cBackup.Name = "cBackup";
			cBackup.ReadOnly = true;
			cBackup.Width = 70;
			cFa2.HeaderText = "Mã 2FA";
			cFa2.Name = "cFa2";
			cFa2.ReadOnly = true;
			cFa2.Width = 65;
			cUseragent.HeaderText = "Useragent";
			cUseragent.Name = "cUseragent";
			cUseragent.ReadOnly = true;
			cUseragent.Width = 70;
			cProxy.HeaderText = "Proxy";
			cProxy.Name = "cProxy";
			cProxy.ReadOnly = true;
			cProxy.Width = 55;
			cDateCreateAcc.HeaderText = "Nga\u0300y ta\u0323o";
			cDateCreateAcc.Name = "cDateCreateAcc";
			cDateCreateAcc.ReadOnly = true;
			cDateCreateAcc.Width = 85;
			cAvatar.HeaderText = "Avatar";
			cAvatar.Name = "cAvatar";
			cAvatar.ReadOnly = true;
			cAvatar.Width = 50;
			cProfile.HeaderText = "Profile";
			cProfile.Name = "cProfile";
			cProfile.ReadOnly = true;
			cProfile.Width = 50;
			cThuMuc.HeaderText = "Thư mục";
			cThuMuc.Name = "cThuMuc";
			cThuMuc.ReadOnly = true;
			cInteractEnd.HeaderText = "Lâ\u0300n tương ta\u0301c cuô\u0301i";
			cInteractEnd.Name = "cInteractEnd";
			cInteractEnd.ReadOnly = true;
			cDevice.HeaderText = "LD Index";
			cDevice.Name = "cDevice";
			cDevice.ReadOnly = true;
			cDevice.Width = 80;
			cInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			cInfo.HeaderText = "Tình Trạng";
			cInfo.Name = "cInfo";
			cInfo.ReadOnly = true;
			cInfo.Width = 90;
			cGhiChu.HeaderText = "Ghi Chú";
			cGhiChu.Name = "cGhiChu";
			cGhiChu.ReadOnly = true;
			cDateDelete.HeaderText = "Thơ\u0300i gian xo\u0301a";
			cDateDelete.Name = "cDateDelete";
			cDateDelete.ReadOnly = true;
			cDateDelete.Width = 111;
			cStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cStatus.HeaderText = "Trạng Thái";
			cStatus.Name = "cStatus";
			cStatus.ReadOnly = true;
			ctmsAcc.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { chọnLiveToolStripMenuItem, bỏChọnTấtCảToolStripMenuItem, khôiPhucTaiKhoanToolStripMenuItem, xóaTàiKhoảnToolStripMenuItem, copyToolStripMenuItem, checkCookieToolStripMenuItem, tảiLạiDanhSáchToolStripMenuItem });
			ctmsAcc.Name = "ctmsAcc";
			ctmsAcc.Size = new System.Drawing.Size(198, 180);
			ctmsAcc.Opening += new System.ComponentModel.CancelEventHandler(CtmsAcc_Opening);
			chọnLiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { tấtCảToolStripMenuItem, liveToolStripMenuItem, tinhTrangToolStripMenuItem, trạngTháiToolStripMenuItem });
			chọnLiveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("chọnLiveToolStripMenuItem.Image");
			chọnLiveToolStripMenuItem.Name = "chọnLiveToolStripMenuItem";
			chọnLiveToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
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
			bỏChọnTấtCảToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			bỏChọnTấtCảToolStripMenuItem.Text = "Bỏ chọn tất cả";
			bỏChọnTấtCảToolStripMenuItem.Click += new System.EventHandler(BỏChọnTấtCảToolStripMenuItem_Click);
			khôiPhucTaiKhoanToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_sync;
			khôiPhucTaiKhoanToolStripMenuItem.Name = "khôiPhucTaiKhoanToolStripMenuItem";
			khôiPhucTaiKhoanToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			khôiPhucTaiKhoanToolStripMenuItem.Text = "Khôi phu\u0323c ta\u0300i khoa\u0309n";
			khôiPhucTaiKhoanToolStripMenuItem.Click += new System.EventHandler(khôiPhucTaiKhoanToolStripMenuItem_Click);
			xóaTàiKhoảnToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_delete_bin;
			xóaTàiKhoảnToolStripMenuItem.Name = "xóaTàiKhoảnToolStripMenuItem";
			xóaTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			xóaTàiKhoảnToolStripMenuItem.Text = "Xóa ta\u0300i khoa\u0309n vi\u0303nh viê\u0303n";
			xóaTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(giưLaiProfileToolStripMenuItem_Click);
			copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[16]
			{
				uidToolStripMenuItem, passToolStripMenuItem, tokenToolStripMenuItem, cookieToolStripMenuItem, mailToolStripMenuItem, fAToolStripMenuItem, maBaoMât6SôToolStripMenuItem, uidPassToolStripMenuItem, uidPass2FaToolStripMenuItem, mailPassMailToolStripMenuItem,
				uidPassTokenCookieToolStripMenuItem, uidPassTokenCookieMailPassMailToolStripMenuItem, uidPassTokenCookieMailPassMail2faToolStripMenuItem, useragentToolStripMenuItem1, proxyToolStripMenuItem1, đinhDangKhacToolStripMenuItem
			});
			copyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image");
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
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
			maBaoMât6SôToolStripMenuItem.Text = "Ma\u0303 ba\u0309o mâ\u0323t 6 sô\u0301";
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
			đinhDangKhacToolStripMenuItem.Text = "Đi\u0323nh da\u0323ng kha\u0301c...";
			đinhDangKhacToolStripMenuItem.Click += new System.EventHandler(đinhDangKhacToolStripMenuItem_Click);
			checkCookieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10] { kiểmTraWallToolStripMenuItem, checkInfoUIDToolStripMenuItem, kiểmTraTokenToolStripMenuItem, kiểmTraCookieToolStripMenuItem, checkAvatarToolStripMenuItem, checkProfileToolStripMenuItem1, checkBackupToolStripMenuItem1, kiểmTraTàiKhoảnToolStripMenuItem, kiểmTraMailpassMailToolStripMenuItem, checkProxyToolStripMenuItem });
			checkCookieToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("checkCookieToolStripMenuItem.Image");
			checkCookieToolStripMenuItem.Name = "checkCookieToolStripMenuItem";
			checkCookieToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			checkCookieToolStripMenuItem.Text = "Kiểm tra tài khoản";
			kiểmTraWallToolStripMenuItem.Name = "kiểmTraWallToolStripMenuItem";
			kiểmTraWallToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			kiểmTraWallToolStripMenuItem.Text = "Check Wall";
			kiểmTraWallToolStripMenuItem.ToolTipText = "Không cần dùng token";
			kiểmTraWallToolStripMenuItem.Click += new System.EventHandler(KiểmTraWallToolStripMenuItem_Click);
			checkInfoUIDToolStripMenuItem.Name = "checkInfoUIDToolStripMenuItem";
			checkInfoUIDToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			checkInfoUIDToolStripMenuItem.Text = "Check Info UID";
			checkInfoUIDToolStripMenuItem.ToolTipText = "Không cần dùng token\r\nCâ\u0323p nhâ\u0323t thông tin: Ho\u0323 tên, Giớ\u0301i ti\u0301nh, [Email], [Ba\u0323n be\u0300], [Nho\u0301m], [Nga\u0300y sinh]";
			checkInfoUIDToolStripMenuItem.Click += new System.EventHandler(checkInfoUIDToolStripMenuItem_Click);
			kiểmTraTokenToolStripMenuItem.Name = "kiểmTraTokenToolStripMenuItem";
			kiểmTraTokenToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			kiểmTraTokenToolStripMenuItem.Text = "Check Token";
			kiểmTraTokenToolStripMenuItem.Click += new System.EventHandler(KiểmTraTokenToolStripMenuItem_Click);
			kiểmTraCookieToolStripMenuItem.Name = "kiểmTraCookieToolStripMenuItem";
			kiểmTraCookieToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			kiểmTraCookieToolStripMenuItem.Text = "Check Cookie";
			kiểmTraCookieToolStripMenuItem.Click += new System.EventHandler(KiểmTraCookieToolStripMenuItem_Click);
			checkAvatarToolStripMenuItem.Name = "checkAvatarToolStripMenuItem";
			checkAvatarToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			checkAvatarToolStripMenuItem.Text = "Check Avatar";
			checkAvatarToolStripMenuItem.Click += new System.EventHandler(checkAvatarToolStripMenuItem_Click);
			checkProfileToolStripMenuItem1.Name = "checkProfileToolStripMenuItem1";
			checkProfileToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
			checkProfileToolStripMenuItem1.Text = "Check Profile";
			checkProfileToolStripMenuItem1.Click += new System.EventHandler(checkProfileToolStripMenuItem_Click);
			checkBackupToolStripMenuItem1.Name = "checkBackupToolStripMenuItem1";
			checkBackupToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
			checkBackupToolStripMenuItem1.Text = "Check Backup";
			checkBackupToolStripMenuItem1.Click += new System.EventHandler(checkBackupToolStripMenuItem_Click);
			kiểmTraTàiKhoảnToolStripMenuItem.Name = "kiểmTraTàiKhoảnToolStripMenuItem";
			kiểmTraTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			kiểmTraTàiKhoảnToolStripMenuItem.Text = "Dạng checkpoint";
			kiểmTraTàiKhoảnToolStripMenuItem.ToolTipText = "Chi\u0309 sư\u0309 du\u0323ng khi ta\u0300i khoa\u0309n đa\u0303 bi\u0323 checkpoint!";
			kiểmTraTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(KiểmTraTàiKhoảnToolStripMenuItem_Click);
			kiểmTraMailpassMailToolStripMenuItem.Name = "kiểmTraMailpassMailToolStripMenuItem";
			kiểmTraMailpassMailToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			kiểmTraMailpassMailToolStripMenuItem.Text = "Mail|pass Mail";
			kiểmTraMailpassMailToolStripMenuItem.Click += new System.EventHandler(kiểmTraMailpassMailToolStripMenuItem_Click);
			checkProxyToolStripMenuItem.Name = "checkProxyToolStripMenuItem";
			checkProxyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			checkProxyToolStripMenuItem.Text = "Check Proxy";
			checkProxyToolStripMenuItem.Click += new System.EventHandler(checkProxyToolStripMenuItem_Click);
			tảiLạiDanhSáchToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("tảiLạiDanhSáchToolStripMenuItem.Image");
			tảiLạiDanhSáchToolStripMenuItem.Name = "tảiLạiDanhSáchToolStripMenuItem";
			tảiLạiDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
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
			pnlHeader.Size = new System.Drawing.Size(1203, 29);
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
			button2.Location = new System.Drawing.Point(1107, 0);
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
			button1.Location = new System.Drawing.Point(1139, 0);
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
			btnMinimize.Location = new System.Drawing.Point(1171, 0);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(186, 16);
			bunifuCustomLabel1.TabIndex = 3;
			bunifuCustomLabel1.Text = "Danh sa\u0301ch ta\u0300i khoa\u0309n đa\u0303 xo\u0301a";
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.DarkRed;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(1204, 38);
			bunifuCards1.TabIndex = 0;
			menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			menuStrip1.AutoSize = false;
			menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { thoátToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 37);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			menuStrip1.Size = new System.Drawing.Size(1201, 25);
			menuStrip1.Stretch = false;
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			thoátToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_show_property_48px;
			thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			thoátToolStripMenuItem.Size = new System.Drawing.Size(132, 21);
			thoátToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
			thoátToolStripMenuItem.Click += new System.EventHandler(câuHinhHiênThiToolStripMenuItem_Click);
			grQuanLyThuMuc.Controls.Add(btnLoadAcc);
			grQuanLyThuMuc.Controls.Add(cbbTinhTrang);
			grQuanLyThuMuc.Controls.Add(cbbThuMuc);
			grQuanLyThuMuc.Controls.Add(label2);
			grQuanLyThuMuc.Controls.Add(label1);
			grQuanLyThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grQuanLyThuMuc.Location = new System.Drawing.Point(292, 65);
			grQuanLyThuMuc.Name = "grQuanLyThuMuc";
			grQuanLyThuMuc.Size = new System.Drawing.Size(445, 53);
			grQuanLyThuMuc.TabIndex = 5;
			grQuanLyThuMuc.TabStop = false;
			grQuanLyThuMuc.Text = "Quản lý thư mục";
			btnLoadAcc.BackgroundImage = maxcare.Properties.Resources.available_updates_25px;
			btnLoadAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			btnLoadAcc.Cursor = System.Windows.Forms.Cursors.Hand;
			btnLoadAcc.Location = new System.Drawing.Point(416, 19);
			btnLoadAcc.Name = "btnLoadAcc";
			btnLoadAcc.Size = new System.Drawing.Size(25, 25);
			btnLoadAcc.TabIndex = 6;
			toolTip1.SetToolTip(btnLoadAcc, "Load lại danh sách");
			btnLoadAcc.UseSelectable = true;
			btnLoadAcc.Click += new System.EventHandler(BtnLoadAcc_Click);
			cbbTinhTrang.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTinhTrang.DropDownWidth = 300;
			cbbTinhTrang.FontSize = MetroFramework.MetroComboBoxSize.Small;
			cbbTinhTrang.FormattingEnabled = true;
			cbbTinhTrang.ItemHeight = 19;
			cbbTinhTrang.Items.AddRange(new object[1] { "[Tất cả tình trạng]" });
			cbbTinhTrang.Location = new System.Drawing.Point(289, 19);
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
			cbbThuMuc.Items.AddRange(new object[1] { "[Tất cả thư mục]" });
			cbbThuMuc.Location = new System.Drawing.Point(72, 19);
			cbbThuMuc.Name = "cbbThuMuc";
			cbbThuMuc.Size = new System.Drawing.Size(173, 25);
			cbbThuMuc.TabIndex = 1;
			cbbThuMuc.UseSelectable = true;
			cbbThuMuc.SelectedIndexChanged += new System.EventHandler(CbbFileAccount_SelectedIndexChanged);
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(249, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(42, 16);
			label2.TabIndex = 2;
			label2.Text = "Lọc:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(8, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(64, 16);
			label1.TabIndex = 0;
			label1.Text = "Thư mục:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			grTimKiem.Controls.Add(BtnSearch);
			grTimKiem.Controls.Add(cbbSearch);
			grTimKiem.Controls.Add(txbSearch);
			grTimKiem.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grTimKiem.Location = new System.Drawing.Point(2, 65);
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
			statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripStatusLabel5, lblCountSelect, toolStripStatusLabel7, lblCountTotal });
			statusStrip1.Location = new System.Drawing.Point(0, 588);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1204, 22);
			statusStrip1.TabIndex = 11;
			statusStrip1.Text = "statusStrip1";
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
			button9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button9.BackColor = System.Drawing.Color.White;
			button9.Cursor = System.Windows.Forms.Cursors.Hand;
			button9.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button9.Image = maxcare.Properties.Resources.icons8_sync;
			button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button9.Location = new System.Drawing.Point(836, 78);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(158, 34);
			button9.TabIndex = 12;
			button9.Text = "Khôi phu\u0323c ta\u0300i khoa\u0309n";
			button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(button9_Click);
			button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button3.BackColor = System.Drawing.Color.White;
			button3.Cursor = System.Windows.Forms.Cursors.Hand;
			button3.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Image = maxcare.Properties.Resources.icons8_delete_bin;
			button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button3.Location = new System.Drawing.Point(1000, 78);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(201, 34);
			button3.TabIndex = 12;
			button3.Text = "Xo\u0301a ta\u0300i khoa\u0309n vi\u0303nh viê\u0303n";
			button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click_1);
			label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			label3.BackColor = System.Drawing.SystemColors.Control;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Red;
			label3.Location = new System.Drawing.Point(688, 591);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(515, 16);
			label3.TabIndex = 13;
			label3.Text = "[Bôi đen nhiều dòng rồi nhấn phím Space] hoặc [Click đúp vào tài khoản] để tích chọn!";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label3.Click += new System.EventHandler(label3_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(1204, 610);
			base.Controls.Add(label3);
			base.Controls.Add(button3);
			base.Controls.Add(button9);
			base.Controls.Add(statusStrip1);
			base.Controls.Add(grTimKiem);
			base.Controls.Add(grQuanLyThuMuc);
			base.Controls.Add(dtgvAcc);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(menuStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = menuStrip1;
			base.Name = "fBin";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "MAX CARE";
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
			grTimKiem.ResumeLayout(false);
			grTimKiem.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
