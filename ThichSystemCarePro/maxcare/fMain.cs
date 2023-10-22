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
using maxcare.Enum;
using maxcare.Helper;
using maxcare.KichBan;
using maxcare.Properties;
using MCommon;
using MetroFramework;
using MetroFramework.Controls;
using Newtonsoft.Json.Linq;
using WindowsFormsControlLibrary1;

namespace maxcare
{
	public class fMain : Form
	{
		private Random rd;

		private bool isStop;

		public const int softIndex = 42;

		public const string nameSoft = "maxsystemcarepro";

		public string deviceId;

		public static fMain remote;

		public bool isResetAdb;

		private JSON_Settings setting_general;

		private JSON_Settings setting_Interact;

		private JSON_Settings setting_InteractGeneral;

		private JSON_Settings setting_LDPlayer;

		private JSON_Settings setting_ShowDtgv;

		private JSON_Settings setting_MoTrinhDuyet;

		private int icheck1;

		private List<Thread> lstThread;

		private List<string> lstIdGroup;

		private List<string> lstIdFr;

		private List<TinsoftProxy> listTinsoft;

		private List<XproxyProxy> listxProxy;

		private List<TMProxy> listTMProxy;

		private List<ProxyWeb> listProxyWeb;

		private List<ShopLike> listShopLike;

		private List<string> listApiTinsoft;

		private List<string> listProxyXproxy;

		private List<string> listProxyTMProxy;

		private List<string> listProxyProxyv6;

		private List<string> listProxyShopLike;

		private Dictionary<string, List<string>> dicUidNhom;

		private Dictionary<string, List<string>> dicUidCaNhan;

		private Dictionary<string, List<string>> dicUidTinNhanProfile;

		private Dictionary<string, List<string>> dicHDDangBaiTuong_NoiDung;

		private Dictionary<string, List<string>> dicHDDangBaiNhom_NoiDung;

		private Dictionary<string, List<string>> dicUidTuongTacPage;

		private Dictionary<string, List<string>> dicSdt;

		private Dictionary<string, List<string>> dicNoiDungReview;

		private Dictionary<string, List<string>> dicHDTuongTacBaiVietChiDinhComment;

		private Dictionary<string, List<string>> dicHDSpamBaiVietID;

		private Dictionary<string, List<string>> dicHDShareBaiNangCao_lstIdGroupShared;

		private int checkDelayLD;

		private object lock_checkDelayLD;

		private bool isOpeningDevice;

		private object lock_checkDelayCreateDevice;

		private int checkDelayLD_MoLDPLayer;

		private object lock_checkDelayLD_MoLDPLayer;

		private bool isOpeningDevice_MoLDPLayer;

		private object lock_checkDelayCreateDevice_MoLDPLayer;

		private bool isReloginIfLogout;

		private List<Device> lstDevice;

		private object lock_StartProxy;

		private object lock_FinishProxy;

		private int checkDelayChrome;

		private object lock_checkDelayChrome;

		private object lock_restoreDevice;

		private object lock_useImage;

		private object lock_fileig;

		private object _lockbackup;

		private object lock_BuffTinNhanProfile;

		private object lock_db2;

		private object lock_db3;

		private object lockStatus;

		private bool kiukiu;

		private int indexCbbThuMucOld;

		private bool isExcute_CbbThuMuc_SelectedIndexChanged;

		private object objLock;

		private object _lock;

		private object _lock2;

		private object _lock3;

		private object _lock4;

		private int indexCbbTinhTrangOld;

		private bool isExcute_CbbTinhTrang_SelectedIndexChanged;

		private int tung1;

		private bool isCountCheckAccountWhenChayTuongTac;

		private object lock_CreateDevice;

		private IContainer components;

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

		private ToolStripMenuItem càiĐặtToolStripMenuItem;

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

		private ToolStripMenuItem cậpNhậtDữLiệuToolStripMenuItem;

		private ToolStripMenuItem mậtKhẩuToolStripMenuItem1;

		private ToolStripMenuItem tokenToolStripMenuItem2;

		private ToolStripMenuItem cookieToolStripMenuItem3;

		private Button btnPause;

		private ToolStripMenuItem chứcNăngToolStripMenuItem1;

		private ToolStripMenuItem mailPassMailToolStripMenuItem;

		private ToolStripMenuItem uidPassTokenCookieMailPassMailToolStripMenuItem;

		private ToolStripMenuItem trạngTháiToolStripMenuItem;

		private ToolStripMenuItem kiểmTraWallToolStripMenuItem;

		private GroupBox grTimKiem;

		private BunifuCustomTextbox txbSearch;

		private ToolStripMenuItem mailToolStripMenuItem;

		private ToolStripMenuItem mailKhôiPhụcToolStripMenuItem;

		private ToolStripMenuItem uidPassTokenCookieMailPassMail2faToolStripMenuItem;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel lblStatus;

		private ToolStripStatusLabel toolStripStatusLabel3;

		private ToolStripStatusLabel lblKey;

		private ToolStripStatusLabel toolStripStatusLabel7;

		private ToolStripStatusLabel lblCountTotal;

		private ToolStripStatusLabel toolStripStatusLabel8;

		private ToolStripStatusLabel txbUid;

		private ToolStripStatusLabel lblUser;

		private ToolStripStatusLabel toolStripStatusLabel9;

		private ToolStripStatusLabel toolStripStatusLabel10;

		private ToolStripStatusLabel toolStripStatusLabel5;

		private ToolStripStatusLabel lblCountSelect;

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

		private ToolStripMenuItem mã2FAToolStripMenuItem;

		private ToolStripMenuItem thoátToolStripMenuItem;

		private ToolStripMenuItem useragentToolStripMenuItem;

		private ToolStripMenuItem proxyToolStripMenuItem;

		private ToolStripMenuItem useragentToolStripMenuItem1;

		private ToolStripMenuItem proxyToolStripMenuItem1;

		private ComboBox cbbSearch;

		private ToolStripMenuItem ghiChuToolStripMenuItem;

		private ToolStripMenuItem ngàySinhToolStripMenuItem;

		private MetroButton btnAddFile;

		private MetroButton btnDeleteFile;

		private MetroButton btnLoadAcc;

		private MetroComboBox cbbTinhTrang;

		private Label label2;

		private Button button9;

		private ToolStripMenuItem kiểmTraMailpassMailToolStripMenuItem;

		private ToolStripMenuItem loginHotmailToolStripMenuItem;

		private MetroButton BtnSearch;

		private Panel plTrangThai;

		private Label lblTrangThai;

		private ToolStripMenuItem uidToolStripMenuItem;

		private ToolStripMenuItem checkAvatarToolStripMenuItem;

		private ToolStripMenuItem checkProxyToolStripMenuItem;

		private ToolStripMenuItem tảiXuốngAvatarToolStripMenuItem;

		private ToolStripMenuItem checkInfoUIDToolStripMenuItem;

		private ToolStripMenuItem checkBackupToolStripMenuItem1;

		private ToolStripMenuItem taiKhoanĐaXoaToolStripMenuItem;

		private ToolStripMenuItem tiệnÍchToolStripMenuItem;

		private ToolStripMenuItem lọcTrùngDữLiệuToolStripMenuItem;

		private ToolStripMenuItem xửLýChuỗiOnlineToolStripMenuItem;

		private ToolStripMenuItem checkHotmailToolStripMenuItem;

		private MetroButton btnEditFile;

		private ToolStripMenuItem checkProxyToolStripMenuItem1;

		private ToolStripMenuItem sửDụngCookieTrungGianToolStripMenuItem;

		private ToolStripMenuItem lToolStripMenuItem;

		private ToolStripMenuItem cậpToolStripMenuItem;

		private ToolStripMenuItem loginYandexToolStripMenuItem;

		private ToolStripMenuItem checkLiveUidToolStripMenuItem;

		private Panel panel1;

		private ToolStripMenuItem liênHệToolStripMenuItem;

		public ToolStripStatusLabel lblDateExpried;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem toolStripMenuItem8;

		private ToolStripMenuItem toolStripMenuItem9;

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

		private ToolStripMenuItem lDPlayerThườngToolStripMenuItem;

		private ToolStripMenuItem tạoLDPlayerToolStripMenuItem;

		private ToolStripMenuItem xóaLDPlayerToolStripMenuItem;

		private ToolStripMenuItem dọnDẹpLDPlayerToolStripMenuItem;

		private System.Windows.Forms.Timer timer1;

		public BunifuCustomLabel bunifuCustomLabel1;

		private MetroButton btnRandomIndexRow;

		private Panel plChucNang;

		private Button button7;

		private Button btnViewLivestream;

		private Button btnShare;

		private Button btnPost;

		private Button button6;

		private Button button5;

		private ToolStripMenuItem toolStripMenuItem5;

		public fMain(string log)
		{
			rd = new Random();
			deviceId = "";
			isResetAdb = false;
			icheck1 = 0;
			lstThread = null;
			lstIdGroup = new List<string>();
			lstIdFr = new List<string>();
			listTinsoft = null;
			listxProxy = null;
			listTMProxy = null;
			listProxyWeb = null;
			listShopLike = null;
			listApiTinsoft = null;
			listProxyXproxy = null;
			listProxyTMProxy = null;
			listProxyProxyv6 = null;
			listProxyShopLike = null;
			dicUidNhom = null;
			dicUidCaNhan = null;
			dicUidTinNhanProfile = null;
			dicHDDangBaiTuong_NoiDung = null;
			dicHDDangBaiNhom_NoiDung = null;
			dicUidTuongTacPage = null;
			dicSdt = null;
			dicNoiDungReview = null;
			dicHDTuongTacBaiVietChiDinhComment = null;
			dicHDSpamBaiVietID = null;
			dicHDShareBaiNangCao_lstIdGroupShared = null;
			checkDelayLD = 0;
			lock_checkDelayLD = new object();
			isOpeningDevice = false;
			lock_checkDelayCreateDevice = new object();
			checkDelayLD_MoLDPLayer = 0;
			lock_checkDelayLD_MoLDPLayer = new object();
			isOpeningDevice_MoLDPLayer = false;
			lock_checkDelayCreateDevice_MoLDPLayer = new object();
			isReloginIfLogout = false;
			lstDevice = null;
			lock_StartProxy = new object();
			lock_FinishProxy = new object();
			checkDelayChrome = 0;
			lock_checkDelayChrome = new object();
			lock_restoreDevice = new object();
			lock_useImage = new object();
			lock_fileig = new object();
			_lockbackup = new object();
			lock_BuffTinNhanProfile = new object();
			lock_db2 = new object();
			lock_db3 = new object();
			lockStatus = new object();
			kiukiu = false;
			indexCbbThuMucOld = -1;
			isExcute_CbbThuMuc_SelectedIndexChanged = true;
			objLock = new object();
			_lock = new object();
			_lock2 = new object();
			_lock3 = new object();
			_lock4 = new object();
			indexCbbTinhTrangOld = -1;
			isExcute_CbbTinhTrang_SelectedIndexChanged = true;
			tung1 = 1;
			isCountCheckAccountWhenChayTuongTac = false;
			lock_CreateDevice = new object();
			components = null;
			InitializeComponent();
			ChangeLanguage();
			lblDateExpried.Text = "Vĩnh Viễn";
			lblKey.Text = "T657437TTR****";
			lblUser.Text = "Uyennguyen";
			remote = this;
		}

		private void ChangeLanguage()
		{
			bunifuCustomLabel1.Text = bunifuCustomLabel1.Text.Split('-')[0] + " - " + Language.GetValue(bunifuCustomLabel1.Text.Split('-')[1].Trim()) + " - " + bunifuCustomLabel1.Text.Split('-')[2];
			Language.GetValue(hệThốngToolStripMenuItem);
			Language.GetValue(càiĐặtToolStripMenuItem);
			Language.GetValue(thoátToolStripMenuItem);
			Language.GetValue(taiKhoanĐaXoaToolStripMenuItem);
			Language.GetValue(tiệnÍchToolStripMenuItem);
			Language.GetValue(checkLiveUidToolStripMenuItem);
			Language.GetValue(checkProxyToolStripMenuItem1);
			Language.GetValue(checkHotmailToolStripMenuItem);
			Language.GetValue(lọcTrùngDữLiệuToolStripMenuItem);
			Language.GetValue(xửLýChuỗiOnlineToolStripMenuItem);
			Language.GetValue(liênHệToolStripMenuItem);
			Language.GetValue(btnInteract);
			Language.GetValue(btnPause);
			Language.GetValue(grTimKiem);
			Language.GetValue(grQuanLyThuMuc);
			Language.GetValue(label1);
			Language.GetValue(label2);
			Language.GetValue(button9);
			Language.GetValue(toolStripStatusLabel1);
			Language.GetValue(lblStatus);
			Language.GetValue(toolStripStatusLabel3);
			Language.GetValue(toolStripStatusLabel9);
			Language.GetValue(toolStripStatusLabel10);
			Language.GetValue(toolStripStatusLabel5);
			Language.GetValue(toolStripStatusLabel7);
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
			Language.GetValue(cậpNhậtDữLiệuToolStripMenuItem);
			Language.GetValue(cậpToolStripMenuItem);
			Language.GetValue(ghiChuToolStripMenuItem);
			Language.GetValue(ngàySinhToolStripMenuItem);
			Language.GetValue(chuyểnThưMụcToolStripMenuItem);
			Language.GetValue(chứcNăngToolStripMenuItem1);
			Language.GetValue(locTrungToolStripMenuItem);
			Language.GetValue(tảiXuốngAvatarToolStripMenuItem);
			Language.GetValue(lToolStripMenuItem);
			Language.GetValue(tảiLạiDanhSáchToolStripMenuItem);
			Language.GetValue(toolStripMenuItem1);
			Language.GetValue(toolStripMenuItem2);
			Language.GetValue(toolStripMenuItem3);
			Language.GetValue(lDPlayerThườngToolStripMenuItem);
			Language.GetValue(toolStripMenuItem4);
			Language.GetValue(tạoLDPlayerToolStripMenuItem);
			Language.GetValue(xóaLDPlayerToolStripMenuItem);
			Language.GetValue(dọnDẹpLDPlayerToolStripMenuItem);
			Language.GetValue(toolStripMenuItem8);
			Language.GetValue(toolStripMenuItem9);
			Language.GetValue(btnPost);
			Language.GetValue(btnShare);
			Language.GetValue(btnViewLivestream);
			Language.GetValue(button7);
		}

		protected override void OnLoad(EventArgs args)
		{
			Application.Idle += OnLoaded;
		}

		private void OnLoaded(object sender, EventArgs e)
		{
			Application.Idle -= OnLoaded;
			LoadCheckTool();
			Base.useragentDefault = CommonChrome.GetUserAgentDefault();
			SetupFolder.StartApplication();
			LoadcbbSearch();
			LoadSetting();
			LoadConfigManHinh();
			LoadCbbThuMuc();
			LoadCbbTinhTrang();
			Base.width = base.Width;
			Base.heigh = base.Height;
			menuStrip1.Cursor = Cursors.Hand;
			new Thread((ThreadStart)delegate
			{
				while (true)
				{
					try
					{
						string text = ADBHelper.RunCMD("adb devices");
						if (!text.Contains("List of devices attached"))
						{
							MCommon.Common.KillProcess("adb");
							isResetAdb = true;
						}
					}
					catch
					{
					}
					MCommon.Common.DelayTime(30.0);
				}
			}).Start();
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
			try
			{
				try
				{
					File.Delete("settings\\language.txt");
				}
				catch
				{
				}
				UpdateStatus.SetValueFromDatabase();
				Environment.Exit(0);
			}
			catch
			{
				Close();
			}
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

		private Dictionary<string, List<string>> GetDictionaryIntoHanhDong(string idKichBan, string tenTuongTac, string field = "txtUid")
		{
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			try
			{
				List<string> idHanhDongByIdKichBanAndTenTuongTac = InteractSQL.GetIdHanhDongByIdKichBanAndTenTuongTac(idKichBan, tenTuongTac);
				if (idHanhDongByIdKichBanAndTenTuongTac.Count > 0)
				{
					for (int i = 0; i < idHanhDongByIdKichBanAndTenTuongTac.Count; i++)
					{
						string text = idHanhDongByIdKichBanAndTenTuongTac[i];
						JSON_Settings jSON_Settings = new JSON_Settings(InteractSQL.GetCauHinhFromHanhDong(text), isJsonString: true);
						List<string> list = new List<string>();
						list = ((!(field == "txtUid")) ? jSON_Settings.GetValueList(field, jSON_Settings.GetValueInt("typeNganCach")) : jSON_Settings.GetValueList(field));
						dictionary.Add(text, list);
					}
				}
			}
			catch
			{
			}
			return dictionary;
		}

		private void SaveDictionaryIntoHanhDong(Dictionary<string, List<string>> dic, string field = "txtUid")
		{
			if (dic.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, List<string>> item in dic)
			{
				string key = item.Key;
				List<string> value = item.Value;
				JSON_Settings jSON_Settings = new JSON_Settings(InteractSQL.GetCauHinhFromHanhDong(key), isJsonString: true);
				jSON_Settings.Update(field, value);
				InteractSQL.UpdateHanhDong(key, "", jSON_Settings.GetFullString());
			}
		}

		private bool ComparePortXproxy(string proxy1, string proxy2)
		{
			try
			{
				string text = proxy1.Split(':')[1];
				string text2 = proxy2.Split(':')[1];
				if (text.Substring(1) == text2.Substring(1))
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
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
				string text3 = "127.0.0.1:" + (device.IndexDevice * 2 + 5555);
				for (int k = 0; k < 10; ADBHelper.ConnectDevice(text3), ReconnectPortLD(), k++)
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
				ADBHelper.ConnectDevice(text3);
				ReconnectPortLD();
				string text4 = "";
				for (int l = 0; l < 10; l++)
				{
					text4 = device.CheckIP();
					if (text4 != "" && !text4.Contains("error"))
					{
						break;
					}
					Thread.Sleep(1000);
				}
				result = text2 != text4 && !text4.Contains("error") && text4 != "";
			}
			return result;
		}

		public void ReconnectPortLD()
		{
			for (int i = 0; i < lstDevice.Count; i++)
			{
				string deviceByIndex = ADBHelper.GetDeviceByIndex(lstDevice[i].IndexDevice);
				if (!string.IsNullOrEmpty(deviceByIndex))
				{
					lstDevice[i].DeviceId = deviceByIndex;
				}
			}
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
							if (isResetAdb && lstDevice.Count > 0)
							{
								bool flag = false;
								while (!flag)
								{
									flag = true;
									for (int num13 = 0; num13 < lstDevice.Count; num13++)
									{
										string deviceByIndex = ADBHelper.GetDeviceByIndex(lstDevice[num13].IndexDevice);
										if (string.IsNullOrEmpty(deviceByIndex))
										{
											flag = false;
										}
										else
										{
											lstDevice[num13].DeviceId = deviceByIndex;
										}
									}
								}
								isResetAdb = false;
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
				List<int> lstPossition = new List<int>();
				for (int n = 0; n < maxThread; n++)
				{
					lstPossition.Add(0);
				}
				isOpeningDevice = false;
				checkDelayLD = 0;
				cControl("start");
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
						List<string> list = new List<string>();
						string idKichBan = "";
						string text = "";
						int num2 = setting_InteractGeneral.GetValueInt("nudSoLuotChay", 1);
						if (num2 == 0)
						{
							num2 = 1;
						}
						int num3 = 0;
						while (num3 < num2)
						{
							list = new List<string>();
							if (setting_InteractGeneral.GetValueBool("ckbRepeatAll"))
							{
								text = ((num2 > 1) ? string.Format(Language.GetValue("Lượt {0}/{1}. "), num3 + 1, num2) : "");
								if (setting_InteractGeneral.GetValueBool("RepeatAllVIP"))
								{
									list = setting_InteractGeneral.GetValueList("lstIdKichBan");
									if (setting_InteractGeneral.GetValueBool("ckbRandomKichBan"))
									{
										list = MCommon.Common.ShuffleList(list);
										list = MCommon.Common.ShuffleList(list);
										list = MCommon.Common.ShuffleList(list);
									}
								}
								else
								{
									list.Add(setting_InteractGeneral.GetValue("cbbKichBan"));
								}
							}
							else
							{
								list.Add(setting_InteractGeneral.GetValue("cbbKichBan"));
							}
							if (!InteractSQL.CheckListKichBanContainTenTuongTac(list, "HDOnOff2FA") || File.Exists("MessagingToolkit.QRCode.dll"))
							{
								int num4 = 0;
								while (true)
								{
									if (num4 < list.Count && !isStop)
									{
										idKichBan = list[num4];
										if (text != "")
										{
											ShowTrangThai(text + string.Format(Language.GetValue("Kịch bản") + ": {0}...", InteractSQL.GetTenKichBanById(idKichBan)));
										}
										if (setting_InteractGeneral.GetValueBool("ckbRandomThuTuTaiKhoan"))
										{
											dtgvAcc.Invoke((MethodInvoker)delegate
											{
												RandomThuTuTaiKhoan();
											});
										}
										dicUidNhom = GetDictionaryIntoHanhDong(idKichBan, "HDThamGiaNhomUid");
										dicUidCaNhan = GetDictionaryIntoHanhDong(idKichBan, "HDKetBanTepUid");
										dicHDSpamBaiVietID = GetDictionaryIntoHanhDong(idKichBan, "HDSpamBaiViet");
										dicHDDangBaiTuong_NoiDung = GetDictionaryIntoHanhDong(idKichBan, "HDDangBaiTuong", "txtNoiDung");
										dicHDDangBaiNhom_NoiDung = GetDictionaryIntoHanhDong(idKichBan, "HDDangBaiNhom", "txtNoiDung");
										dicUidTuongTacPage = GetDictionaryIntoHanhDong(idKichBan, "HDTuongTacPage");
										dicSdt = GetDictionaryIntoHanhDong(idKichBan, "HDDongBoDanhBa", "txtSdt");
										dicNoiDungReview = GetDictionaryIntoHanhDong(idKichBan, "HDDanhGiaPage", "txtComment");
										dicHDTuongTacBaiVietChiDinhComment = GetDictionaryIntoHanhDong(idKichBan, "HDTuongTacBaiVietChiDinh", "txtComment");
										dicHDShareBaiNangCao_lstIdGroupShared = new Dictionary<string, List<string>>();
										int num5 = 0;
										while (num5 < dtgvAcc.Rows.Count && !isStop)
										{
											if (!Convert.ToBoolean(dtgvAcc.Rows[num5].Cells["cChose"].Value))
											{
												num5++;
												goto IL_0a08;
											}
											if (isStop)
											{
												break;
											}
											if (lstThread.Count < maxThread)
											{
												if (isStop)
												{
													break;
												}
												int row = num5++;
												Thread thread = new Thread((ThreadStart)delegate
												{
													try
													{
														int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
														ExcuteOneThread(row, indexOfPossitionApp + 1, idKichBan, isRunSwap, pathLD);
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
												goto IL_0a08;
											}
											if (isStop)
											{
												break;
											}
											if ((setting_general.GetValueInt("ip_iTypeChangeIp") == 7 && setting_general.GetValueBool("ckbWaitDoneAllTinsoft")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 8 && setting_general.GetValueBool("ckbWaitDoneAllXproxy")) || (setting_general.GetValueInt("ip_iTypeChangeIp") == 10 && setting_general.GetValueBool("ckbWaitDoneAllTMProxy")))
											{
												for (int num6 = 0; num6 < lstThread.Count; num6++)
												{
													lstThread[num6].Join();
													lock (lstThread)
													{
														lstThread.RemoveAt(num6--);
													}
												}
												goto IL_0a08;
											}
											if (setting_general.GetValueInt("ip_iTypeChangeIp") == 0 || setting_general.GetValueInt("ip_iTypeChangeIp") == 7 || setting_general.GetValueInt("ip_iTypeChangeIp") == 8 || setting_general.GetValueInt("ip_iTypeChangeIp") == 9 || setting_general.GetValueInt("ip_iTypeChangeIp") == 10 || setting_general.GetValueInt("ip_iTypeChangeIp") == 11 || setting_general.GetValueInt("ip_iTypeChangeIp") == 12)
											{
												for (int num7 = 0; num7 < lstThread.Count; num7++)
												{
													if (!lstThread[num7].IsAlive)
													{
														lock (lstThread)
														{
															lstThread.RemoveAt(num7--);
														}
													}
												}
												goto IL_0a08;
											}
											for (int num8 = 0; num8 < lstThread.Count; num8++)
											{
												lstThread[num8].Join();
												lock (lstThread)
												{
													lstThread.RemoveAt(num8--);
												}
											}
											if (isStop)
											{
												break;
											}
											Interlocked.Increment(ref curChangeIp);
											if (curChangeIp < setting_general.GetValueInt("ip_nudChangeIpCount", 1))
											{
												goto IL_0a08;
											}
											for (int num9 = 0; num9 < 3; num9++)
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
												goto IL_0a08;
											}
											MessageBoxHelper.ShowMessageBox(Language.GetValue("Không thê\u0309 đô\u0309i ip!"), 2);
											goto end_IL_0001;
											IL_0a08:
											if (isStop)
											{
												break;
											}
										}
										for (int num10 = 0; num10 < lstThread.Count; num10++)
										{
											lstThread[num10].Join();
										}
										SaveDictionaryIntoHanhDong(dicUidNhom);
										SaveDictionaryIntoHanhDong(dicUidCaNhan);
										SaveDictionaryIntoHanhDong(dicHDSpamBaiVietID);
										SaveDictionaryIntoHanhDong(dicHDDangBaiTuong_NoiDung, "txtNoiDung");
										SaveDictionaryIntoHanhDong(dicHDDangBaiNhom_NoiDung, "txtNoiDung");
										SaveDictionaryIntoHanhDong(dicUidTuongTacPage);
										SaveDictionaryIntoHanhDong(dicSdt, "txtSdt");
										SaveDictionaryIntoHanhDong(dicNoiDungReview, "txtComment");
										SaveDictionaryIntoHanhDong(dicHDTuongTacBaiVietChiDinhComment, "txtComment");
										if (!isStop)
										{
											if (num4 + 1 < list.Count)
											{
												int num11 = Base.rd.Next(setting_InteractGeneral.GetValueInt("nudDelayKichBanFrom"), setting_InteractGeneral.GetValueInt("nudDelayKichBanTo") + 1);
												int tickCount = Environment.TickCount;
												while ((Environment.TickCount - tickCount) / 1000 - num11 < 0)
												{
													ShowTrangThai(text + string.Format(Language.GetValue("Chạy kịch bản tiếp theo sau {time} giây...").Replace("{time}", (num11 - (Environment.TickCount - tickCount) / 1000).ToString())));
													MCommon.Common.DelayTime(0.5);
													if (isStop)
													{
														break;
													}
												}
											}
											num4++;
											continue;
										}
									}
									if (!setting_InteractGeneral.GetValueBool("ckbRepeatAll") || isStop)
									{
										break;
									}
									if (num3 + 1 < num2)
									{
										int num12 = Base.rd.Next(setting_InteractGeneral.GetValueInt("nudDelayTurnFrom"), setting_InteractGeneral.GetValueInt("nudDelayTurnTo") + 1) * 60;
										int tickCount2 = Environment.TickCount;
										while ((Environment.TickCount - tickCount2) / 1000 - num12 < 0)
										{
											ShowTrangThai(text + string.Format(Language.GetValue("Chạy lượt tiếp theo sau {time} giây...").Replace("{time}", (num12 - (Environment.TickCount - tickCount2) / 1000).ToString())));
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
									goto IL_0e0e;
								}
							}
							else
							{
								MCommon.Common.ShowMessageBox("Vui lòng tắt phần mềm và extract here file 2fa.zip, sau đó mở lại phần mềm để chạy!", 3);
							}
							break;
							IL_0e0e:;
						}
						end_IL_0001:;
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2);
					}
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

		private List<string> GetListBountsAvailability(List<string> lstBounds)
		{
			List<string> list = new List<string>();
			lstBounds = lstBounds.Distinct().ToList();
			for (int i = 0; i < lstBounds.Count; i++)
			{
				if (lstBounds[i] != "[0,0][0,0]")
				{
					list.Add(lstBounds[i]);
				}
			}
			return list;
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
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y UID!"), device);
					}
					else if (cellAccount3.Trim() == "")
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"), device);
					}
				}
				else
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đăng nhập bằng Uid|Pass..."), device);
					result = device.LoginFacebook(cellAccount, cellAccount3, cellAccount4);
				}
			}
			else if (cellAccount2.Trim() == "" || cellAccount3.Trim() == "")
			{
				if (cellAccount2.Trim() == "")
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Email!"), device);
				}
				else if (cellAccount3.Trim() == "")
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"), device);
				}
			}
			else
			{
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đăng nhập bằng Email|Pass..."), device);
				result = device.LoginFacebook(cellAccount2, cellAccount3, cellAccount4);
			}
			return result;
		}

		private int CheckStatusDevice(Device device, int indexRow, string statusProxy, bool isAllowClickImageX = true)
		{
			device.LoadStatusLD("Check status...");
			string html = "";
			int num = device.CheckStatusDevice(ref html, isAllowClickImageX);
			device.LoadStatusLD($"Check status: {num}...");
			if ((num.ToString() ?? "").StartsWith("-1"))
			{
				if (device.CheckExistText("\"ok\"", html))
				{
					device.DelayTime(1.0);
					device.TapByText("\"ok\"", html);
				}
				num = -1;
			}
			int num2 = num;
			int num3 = num2;
			if (num3 != -1)
			{
				return num;
			}
			if (isReloginIfLogout && device.GetActivity() != "Application")
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

		private void ExcuteOneThread(int indexRow, int indexPos, string idKichBan, bool isRunSwap, string pathLD)
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
			string text6 = GetCellAccount(indexRow, "cCookies");
			string text7 = GetCellAccount(indexRow, "cToken");
			if (text5 == "")
			{
				text5 = Regex.Match(text6 + ";", "c_user=(.*?);").Groups[1].Value;
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
										foreach (ShopLike item in listShopLike)
										{
											if (shopLike == null || item.daSuDung < shopLike.daSuDung)
											{
												shopLike = item;
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
										shopLike.dangSuDung++;
										shopLike.daSuDung++;
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
										shopLike.dangSuDung--;
										shopLike.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0141;
						case 11:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy Proxyv6..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									proxyWeb = null;
									while (!isStop)
									{
										foreach (ProxyWeb item2 in listProxyWeb)
										{
											if (proxyWeb == null || item2.daSuDung < proxyWeb.daSuDung)
											{
												proxyWeb = item2;
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
										proxyWeb.dangSuDung++;
										proxyWeb.daSuDung++;
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
										goto IL_078b;
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
										goto IL_078b;
									}
								}
								goto end_IL_04b1;
								IL_078b:
								if (!flag9)
								{
									proxyWeb.dangSuDung--;
									proxyWeb.daSuDung--;
									continue;
								}
								text = text.Split(':')[0] + ":" + text.Split(':')[1];
								break;
								end_IL_04b1:;
							}
							goto end_IL_0141;
						case 10:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy TMProxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tMProxy = null;
									while (!isStop)
									{
										foreach (TMProxy item3 in listTMProxy)
										{
											if (tMProxy == null || item3.daSuDung < tMProxy.daSuDung)
											{
												tMProxy = item3;
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
										tMProxy.dangSuDung++;
										tMProxy.daSuDung++;
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
										tMProxy.dangSuDung--;
										tMProxy.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0141;
						case 8:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy Proxy..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									xproxyProxy = null;
									while (!isStop)
									{
										foreach (XproxyProxy item4 in listxProxy)
										{
											if (xproxyProxy == null || (item4.isProxyLive && item4.daSuDung < xproxyProxy.daSuDung))
											{
												xproxyProxy = item4;
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
									xproxyProxy.dangSuDung++;
									xproxyProxy.daSuDung++;
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
										goto IL_0ceb;
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
										goto IL_0ceb;
									}
								}
								goto end_IL_0a88;
								IL_0ceb:
								if (!flag7)
								{
									xproxyProxy.dangSuDung--;
									xproxyProxy.daSuDung--;
									continue;
								}
								break;
								end_IL_0a88:;
							}
							goto end_IL_0141;
						case 7:
							SetStatusAccount(indexRow, Language.GetValue("Đang lấy proxy Tinsoft..."));
							lock (lock_StartProxy)
							{
								while (!isStop)
								{
									tinsoftProxy = null;
									while (!isStop)
									{
										foreach (TinsoftProxy item5 in listTinsoft)
										{
											if (tinsoftProxy == null || item5.daSuDung < tinsoftProxy.daSuDung)
											{
												tinsoftProxy = item5;
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
										tinsoftProxy.dangSuDung++;
										tinsoftProxy.daSuDung++;
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
										tinsoftProxy.dangSuDung--;
										tinsoftProxy.daSuDung--;
										continue;
									}
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								num3 = 1;
							}
							goto end_IL_0141;
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
									goto IL_125d;
								}
								break;
							}
							goto IL_125d;
						}
						goto IL_126f;
						IL_125d:
						text2 = "(IP: " + text3 + ") ";
						goto IL_126f;
						IL_126f:
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
								SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị..."));
								for (int i = 0; i < 2; i++)
								{
									ADBHelper.AddDevice(pathLD);
									if (Directory.Exists(pathLD + "\\vms\\leidian" + indexPos))
									{
										break;
									}
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Cấu hình thiết bị..."));
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
							string text8 = GetCellAccount(indexRow, "cDevice");
							if (text8 == "" || !Directory.Exists(pathLD + "\\vms\\leidian" + text8))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị, chờ đến lượt..."));
								lock (lock_checkDelayCreateDevice)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị..."));
									List<string> listIndexLDPlayer = ADBHelper.GetListIndexLDPlayer(pathLD);
									ADBHelper.AddDevice(pathLD);
									for (int j = 0; j < 30; j++)
									{
										text8 = ADBHelper.GetListIndexLDPlayer(pathLD).Except(listIndexLDPlayer).First();
										if (text8 != "")
										{
											break;
										}
									}
									if (text8 == "")
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị thất bại!"));
										num3 = 1;
										goto IL_45eb;
									}
								}
								device = new Device(pathLD, text8);
								SetCellAccount(indexRow, "cDevice", text8);
								CommonSQL.UpdateFieldToAccount(cellAccount, "device", text8);
								SetStatusAccount(indexRow, text2 + Language.GetValue("Cấu hình thiết bị..."));
								lock (lock_restoreDevice)
								{
									device.Restore();
								}
								device.ChangeHardwareLDPlayer2();
							}
							else
							{
								device = new Device(pathLD, text8);
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
										goto IL_45eb;
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
										goto IL_45eb;
									}
								}
							}
							else
							{
								checkDelayLD++;
							}
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiết bị..."));
						device.LoadStatusLD("Open device...");
						device.Open();
						if (device.process == null)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở thiết bị!"));
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
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở thiết bị!"));
							isOpeningDevice = false;
							num3 = 1;
							break;
						}
						isOpeningDevice = false;
						SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiết bị thành công!"), device);
						device.LoadStatusLD("Open device success...");
						lstDevice.Add(device);
						if (!setting_general.GetValueBool("ckbKhongAddVaoFormView"))
						{
							fViewLD.remote.ShowPicTurnOffDevice(device.IndexDevice, device.DeviceId);
						}
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
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i Install App!"), device);
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
									SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i Install App Proxy!"));
									break;
								}
								device.ClearDataApp("com.cell47.College_Proxy");
								SetStatusAccount(indexRow, text2 + Language.GetValue("Connect proxy..."));
								device.LoadStatusLD("Connect proxy...");
								if (!ConnectProxy(device, text))
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i Connect proxy!"));
									break;
								}
								device.InputKey(Device.KeyEvent.KEYCODE_HOME);
							}
						}
						if (isRunSwap)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Restore dữ liệu Fb..."), device);
							device.RestoreAccountFacebook(text5);
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Mở app Facebook..."), device);
						string text9 = device.OpenFacebookAndCheckStatusLogin();
						if (text9.Split('|')[0] == "0")
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở app Facebook!"));
							num3 = 1;
							break;
						}
						if (text9.Split('|')[0] == "2")
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi đăng nhập swap!"));
							num3 = 1;
							break;
						}
						num2 = ((!(text9.Split('|')[1] == "0") && !(text9.Split('|')[1] == "11")) ? Convert.ToInt32(text9.Split('|')[1]) : LoginFacebook(device, indexRow, text2));
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
							for (int m = 0; m < 10; m++)
							{
								text9 = device.OpenFacebookAndCheckStatusLogin();
								if (!(text9.Split('|')[1] == "1"))
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
						if (num2 != 1)
						{
							num3 = 1;
							device.CheckDevice("", "", "log\\loginfail" + num2);
							break;
						}
						flag4 = true;
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhập thành công..."), device);
						if (flag = !CheckIsUidFacebook(text5))
						{
							text4 = text5;
							text5 = Regex.Match(device.GetTokenCookie().Split('|')[1] + ";", "c_user=(.*?);").Groups[1].Value;
							if (text5.Trim() != "")
							{
								CommonSQL.UpdateFieldToAccount(cellAccount, "uid", text5);
								SetCellAccount(indexRow, "cUid", text5);
							}
						}
						if (setting_InteractGeneral.GetValueBool("ckbGetCookie"))
						{
							string tokenCookie = device.GetTokenCookie();
							text7 = tokenCookie.Split('|')[0];
							text6 = tokenCookie.Split('|')[1];
							CommonSQL.UpdateFieldToAccount(cellAccount, "token", text7);
							SetCellAccount(indexRow, "cToken", text7);
							CommonSQL.UpdateFieldToAccount(cellAccount, "cookie1", text6);
							SetCellAccount(indexRow, "cCookies", text6);
						}
						DataTable dataTable = InteractSQL.GetAllHanhDongByKichBan(idKichBan);
						if (setting_InteractGeneral.GetValueBool("ckbRandomHanhDong"))
						{
							dataTable = MCommon.Common.ShuffleDataTable(dataTable);
							dataTable = MCommon.Common.ShuffleDataTable(dataTable);
							dataTable = MCommon.Common.ShuffleDataTable(dataTable);
						}
						string text10 = "";
						string text11 = "";
						DataTable dataTable2 = new DataTable();
						string cauHinhFromKichBan = InteractSQL.GetCauHinhFromKichBan(idKichBan);
						JSON_Settings jSON_Settings = new JSON_Settings(cauHinhFromKichBan, isJsonString: true);
						int valueInt = jSON_Settings.GetValueInt("typeSoLuongHanhDong");
						int valueInt2 = jSON_Settings.GetValueInt("nudHanhDongFrom");
						int valueInt3 = jSON_Settings.GetValueInt("nudHanhDongTo");
						int num8 = dataTable.Rows.Count;
						if (valueInt == 1 && valueInt2 <= valueInt3)
						{
							num8 = Base.rd.Next(valueInt2, valueInt3 + 1);
							if (num8 > dataTable.Rows.Count)
							{
								num8 = dataTable.Rows.Count;
							}
						}
						int num9 = 0;
						while (true)
						{
							if (num9 < num8)
							{
								if (isStop)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
									num3 = 1;
									break;
								}
								num2 = CheckStatusDevice(device, indexRow, text2);
								switch (num2)
								{
								case -3:
									device.OpenAppFacebook();
									goto default;
								default:
									try
									{
										text11 = dataTable.Rows[num9]["TenHanhDong"].ToString();
										text10 = dataTable.Rows[num9]["Id_HanhDong"].ToString();
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đang") + " " + text11 + "...", device);
										dataTable2 = InteractSQL.GetHanhDongById(text10);
										JSON_Settings jSON_Settings2 = new JSON_Settings(dataTable2.Rows[0]["CauHinh"].ToString(), isJsonString: true);
										string html = device.GetHtml();
										device.ClosePopup(ref html);
										if (device.CheckExistText("\"save your login info\"", html))
										{
											device.TapByText("\"ok\"", html);
										}
										switch (dataTable2.Rows[0]["TenTuongTac"].ToString())
										{
										case "HDDangBaiTuong":
											try
											{
												num2 = HDDangBaiTuong(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom", 1), jSON_Settings2.GetValueInt("nudSoLuongTo", 1), jSON_Settings2.GetValueInt("nudKhoangCachFrom"), jSON_Settings2.GetValueInt("nudKhoangCachTo"), jSON_Settings2.GetValueBool("ckbVanBan"), jSON_Settings2.GetValueBool("ckbUseBackground"), jSON_Settings2.GetValueBool("ckbAnh"), jSON_Settings2.GetValue("txtPathAnh"), jSON_Settings2.GetValueBool("ckbXoaNguyenLieuDaDung"), text11, text10);
											}
											catch (Exception ex37)
											{
												MCommon.Common.ExportError(ex37, "HDDangBaiTuong");
											}
											break;
										case "HDXemWatchTheoTuKhoa":
											try
											{
												num2 = HDXemWatchTheoTuKhoa(indexRow, text2, device, jSON_Settings2.GetValueList("txtTuKhoa"), jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudTimeWatchFrom"), jSON_Settings2.GetValueInt("nudTimeWatchTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValueInt("nudCountLikeFrom"), jSON_Settings2.GetValueInt("nudCountLikeTo"), jSON_Settings2.GetValueBool("ckbShareWall"), jSON_Settings2.GetValueInt("nudCountShareFrom"), jSON_Settings2.GetValueInt("nudCountShareTo"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment"), jSON_Settings2.GetValueInt("nudCountCommentFrom"), jSON_Settings2.GetValueInt("nudCountCommentTo"), text11);
											}
											catch (Exception ex36)
											{
												MCommon.Common.ExportError(ex36, "HDXemWatchTheoTuKhoa");
											}
											break;
										case "HDShareBai":
											try
											{
												num2 = HDShareBai(indexRow, text2, device, jSON_Settings2.GetValueBool("ckbShareBaiLenTuong"), jSON_Settings2.GetValueBool("ckbShareBaiLenNhom"), jSON_Settings2.GetValueInt("nudCountGroupFrom"), jSON_Settings2.GetValueInt("nudCountGroupTo"), jSON_Settings2.GetValueBool("ckbOnlyShareNhomKhongKiemDuyet"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValue("txtLinkChiaSe"), jSON_Settings2.GetValueBool("ckbVanBan"), jSON_Settings2.GetValueList("txtNoiDung", jSON_Settings2.GetValueInt("typeNganCach")), text11);
											}
											catch (Exception ex35)
											{
												MCommon.Common.ExportError(ex35, "HDShareBai");
											}
											break;
										case "HDDangBaiNhom":
											try
											{
												num2 = HDDangBaiNhom(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom", 1), jSON_Settings2.GetValueInt("nudSoLuongTo", 1), jSON_Settings2.GetValueInt("nudKhoangCachFrom"), jSON_Settings2.GetValueInt("nudKhoangCachTo"), jSON_Settings2.GetValueBool("ckbChiDangNhomKKD"), jSON_Settings2.GetValueBool("ckbVanBan"), jSON_Settings2.GetValueBool("ckbUseBackground"), jSON_Settings2.GetValueBool("ckbAnh"), jSON_Settings2.GetValue("txtPathAnh"), jSON_Settings2.GetValueBool("ckbXoaNguyenLieuDaDung"), text11, text10, text, typeProxy);
											}
											catch (Exception ex34)
											{
												MCommon.Common.ExportError(ex34, "HDDangBaiNhom");
											}
											break;
										case "HDKetBanGoiY":
											try
											{
												num2 = HDKetBanGoiY(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text11);
											}
											catch (Exception ex33)
											{
												MCommon.Common.ExportError(ex33, "HDKetBanGoiY");
											}
											break;
										case "HDTuongTacBaiVietIA":
											try
											{
												num2 = HDTuongTacBaiVietIA(indexRow, text2, device, jSON_Settings2, text11);
											}
											catch (Exception ex32)
											{
												MCommon.Common.ExportError(ex32, "HDTuongTacBaiVietIA");
											}
											break;
										case "HDXemWatch":
											try
											{
												num2 = HDXemWatch(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudTimeWatchFrom"), jSON_Settings2.GetValueInt("nudTimeWatchTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValueInt("nudCountLikeFrom"), jSON_Settings2.GetValueInt("nudCountLikeTo"), jSON_Settings2.GetValueBool("ckbShareWall"), jSON_Settings2.GetValueInt("nudCountShareFrom"), jSON_Settings2.GetValueInt("nudCountShareTo"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment"), jSON_Settings2.GetValueInt("nudCountCommentFrom"), jSON_Settings2.GetValueInt("nudCountCommentTo"), jSON_Settings2.GetValueInt("nudPercentLike", 50), jSON_Settings2.GetValueInt("nudPercentShare", 50), jSON_Settings2.GetValueInt("nudPercentComment", 50), text11);
											}
											catch (Exception ex31)
											{
												MCommon.Common.ExportError(ex31, "HDXemWatch");
											}
											break;
										case "HDXemStory":
											try
											{
												num2 = HDXemStory(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValue("typeReaction"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment"), text11);
											}
											catch (Exception ex30)
											{
												MCommon.Common.ExportError(ex30, "HDXemStory");
											}
											break;
										case "HDBuffFollowUID":
											try
											{
												num2 = HDBuffFollowUID(indexRow, text2, device, jSON_Settings2.GetValue("txtUid"), text11);
											}
											catch (Exception ex29)
											{
												MCommon.Common.ExportError(ex29, "HDBuffFollowUID");
											}
											break;
										case "HDTuongTacBanBe":
											try
											{
												num2 = HDTuongTacBanBe(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongBanBeFrom"), jSON_Settings2.GetValueInt("nudSoLuongBanBeTo"), jSON_Settings2.GetValueInt("nudTimeFrom"), jSON_Settings2.GetValueInt("nudTimeTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValueInt("nudCountLikeFrom", 1), jSON_Settings2.GetValueInt("nudCountLikeTo", 3), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueInt("nudCountCommentFrom", 1), jSON_Settings2.GetValueInt("nudCountCommentTo", 3), jSON_Settings2.GetValueList("txtComment", jSON_Settings2.GetValueInt("typeNganCach")), jSON_Settings2.GetValueBool("ckbShareWall"), jSON_Settings2.GetValueInt("nudCountShareFrom", 1), jSON_Settings2.GetValueInt("nudCountShareTo", 3), text11);
											}
											catch (Exception ex28)
											{
												MCommon.Common.ExportError(ex28, "HDTuongTacBanBe");
											}
											break;
										case "HDKetBanTepUid":
											try
											{
												num2 = HDKetBanTepUid(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValueBool("ckbTuongTac"), jSON_Settings2.GetValueInt("nudTimeFrom"), jSON_Settings2.GetValueInt("nudTimeTo"), jSON_Settings2.GetValueBool("ckbTuongTacLike"), jSON_Settings2.GetValueInt("nudCountLikeFrom"), jSON_Settings2.GetValueInt("nudCountLikeTo"), jSON_Settings2.GetValueBool("ckbTuongTacComment"), jSON_Settings2.GetValueList("txtComment"), jSON_Settings2.GetValueInt("nudCountCommentFrom"), jSON_Settings2.GetValueInt("nudCountCommentTo"), jSON_Settings2.GetValueBool("ckbTuDongXoaUid"), text10, text11);
											}
											catch (Exception ex27)
											{
												MCommon.Common.ExportError(ex27, "HDKetBanTepUid");
											}
											break;
										case "HDNghiGiaiLao":
											try
											{
												num2 = HDNghiGiaiLao(indexRow, text2, jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text11);
											}
											catch (Exception ex26)
											{
												MCommon.Common.ExportError(ex26, "HDNghiGiaiLao");
											}
											break;
										case "HDChiaSeLivestream":
											try
											{
												num2 = HDChiaSeLivestream(indexRow, text2, device, jSON_Settings2.GetValueBool("ckbChiaSeLenTuong"), jSON_Settings2.GetValueBool("ckbChiaSeLenNhom"), jSON_Settings2.GetValueInt("nudCountGroupFrom"), jSON_Settings2.GetValueInt("nudCountGroupTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValue("txtLinkChiaSe"), jSON_Settings2.GetValueBool("ckbVanBan"), jSON_Settings2.GetValueList("txtNoiDung", jSON_Settings2.GetValueInt("typeNganCach")), jSON_Settings2.GetValueBool("ckbTuongTacLivestream"), jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValue("typeReaction"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment"), jSON_Settings2.GetValueBool("ckbBinhLuanNhieuLan"), jSON_Settings2.GetValueInt("nudBinhLuanNhieuLanDelayFrom"), jSON_Settings2.GetValueInt("nudBinhLuanNhieuLanDelayTo"), text11);
											}
											catch (Exception ex25)
											{
												MCommon.Common.ExportError(ex25, "HDChiaSeLivestream");
											}
											break;
										case "HDKetBanTheoTuKhoa":
											try
											{
												num2 = HDKetBanTheoTuKhoa(indexRow, text2, device, jSON_Settings2.GetValueList("txtTuKhoa"), jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text11);
											}
											catch (Exception ex24)
											{
												MCommon.Common.ExportError(ex24, "HDKetBanTheoTuKhoa");
											}
											break;
										case "HDDocThongBao":
											try
											{
												num2 = HDDocThongBao(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text11);
											}
											catch (Exception ex23)
											{
												MCommon.Common.ExportError(ex23, "HDDocThongBao");
											}
											break;
										case "HDRoiNhom":
											try
											{
												num2 = HDRoiNhom(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValueInt("typeRoiNhom"), jSON_Settings2.GetValueBool("ckbDieuKienThanhVien"), jSON_Settings2.GetValueInt("nudThanhVienToiDa"), jSON_Settings2.GetValueBool("ckbDieuKienTuKhoa"), jSON_Settings2.GetValueList("txtTuKhoa"), jSON_Settings2.GetValueList("txtIDNhomGiuLai"), text, typeProxy, text11);
											}
											catch (Exception ex22)
											{
												MCommon.Common.ExportError(ex22, "HDRoiNhom");
											}
											break;
										case "HDBuffLikePage":
											try
											{
												num2 = HDBuffLikePage(indexRow, text2, device, jSON_Settings2.GetValue("txtUid"), text11);
											}
											catch (Exception ex21)
											{
												MCommon.Common.ExportError(ex21, "HDBuffLikePage");
											}
											break;
										case "HDOnOff2FA":
											try
											{
												num2 = HDOnOff2FA(indexRow, text2, device, jSON_Settings2);
											}
											catch (Exception ex20)
											{
												MCommon.Common.ExportError(ex20, "HDOnOff2FA");
											}
											break;
										case "HDThamGiaNhomTuKhoa":
											try
											{
												num2 = HDThamGiaNhomTuKhoa(indexRow, text2, device, jSON_Settings2.GetValueList("txtTuKhoa"), jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValueBool("ckbTuDongTraLoiCauHoi"), jSON_Settings2.GetValueList("txtCauTraLoi"), text11);
											}
											catch (Exception ex19)
											{
												MCommon.Common.ExportError(ex19, "HDThamGiaNhomTuKhoa");
											}
											break;
										case "HDMoiBanBeLikePage":
											try
											{
												num2 = HDMoiBanBeLikePage(indexRow, text2, device, jSON_Settings2, text11);
											}
											catch (Exception ex18)
											{
												MCommon.Common.ExportError(ex18, "HDMoiBanBeLikePage");
											}
											break;
										case "HDMoiBanBeVaoNhom":
											try
											{
												num2 = HDMoiBanBeVaoNhom(indexRow, text2, device, jSON_Settings2, text11, text, typeProxy);
											}
											catch (Exception ex17)
											{
												MCommon.Common.ExportError(ex17, "HDMoiBanBeVaoNhom");
											}
											break;
										case "HDHuyKetBan":
											try
											{
												num2 = HDHuyKetBan(indexRow, text2, device, text7, text6, jSON_Settings2.GetValueInt("typeHuyKetBan"), jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueList("txtUid"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValueList("txtUidKhongHuyKetBan"), text, typeProxy, text11);
											}
											catch (Exception ex16)
											{
												MCommon.Common.ExportError(ex16, "HDHuyKetBan");
											}
											break;
										case "HDTuongTacNewsfeed":
											try
											{
												num2 = HDTuongTacNewsfeed(indexRow, text2, device, jSON_Settings2.GetValueInt("nudTimeFrom"), jSON_Settings2.GetValueInt("nudTimeTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValueInt("nudCountLikeFrom", 1), jSON_Settings2.GetValueInt("nudCountLikeTo", 3), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueInt("nudCountCommentFrom", 1), jSON_Settings2.GetValueInt("nudCountCommentTo", 3), jSON_Settings2.GetValueList("txtComment", jSON_Settings2.GetValueInt("typeNganCach")), jSON_Settings2.GetValueBool("ckbShareWall"), jSON_Settings2.GetValueInt("nudCountShareFrom", 1), jSON_Settings2.GetValueInt("nudCountShareTo", 3), text11);
											}
											catch (Exception ex15)
											{
												MCommon.Common.ExportError(ex15, "HDTuongTacNewsfeed");
											}
											break;
										case "HDThamGiaNhomUid":
											try
											{
												num2 = HDThamGiaNhomUid(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValueBool("ckbTuDongTraLoiCauHoi"), jSON_Settings2.GetValueList("txtCauTraLoi"), jSON_Settings2.GetValueBool("ckbTuDongXoaUid"), text10, text11);
											}
											catch (Exception ex14)
											{
												MCommon.Common.ExportError(ex14, "HDThamGiaNhomUid");
											}
											break;
										case "HDTuongTacVideo":
											try
											{
												num2 = HDTuongTacVideo(indexRow, text2, device, jSON_Settings2.GetValue("txtLinkVideo"), jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValue("typeReaction"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment"), jSON_Settings2.GetValueBool("ckbBinhLuanNhieuLan"), jSON_Settings2.GetValueInt("nudBinhLuanNhieuLanDelayFrom"), jSON_Settings2.GetValueInt("nudBinhLuanNhieuLanDelayTo"), text11);
											}
											catch (Exception ex13)
											{
												MCommon.Common.ExportError(ex13, "HDXemStory");
											}
											break;
										case "HDDangXuatThietBiCu":
											try
											{
												num2 = HDDangXuatThietBiCu(indexRow, text2, device, text11);
											}
											catch (Exception ex12)
											{
												MCommon.Common.ExportError(ex12, "HDDangXuatThietBiCu");
											}
											break;
										case "HDDongBoDanhBa":
											try
											{
												num2 = HDDongBoDanhBa(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueBool("ckbTuDongXoa"), jSON_Settings2.GetValueBool("ckbAutoAddFriend"), jSON_Settings2.GetValueInt("nudSoLuongKetBanFrom"), jSON_Settings2.GetValueInt("nudSoLuongKetBanTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text10, text11);
											}
											catch (Exception ex11)
											{
												MCommon.Common.ExportError(ex11, "HDDongBoDanhBa");
											}
											break;
										case "HDDoiMatKhau":
											try
											{
												num2 = HDDoiMatKhau(indexRow, text2, device, jSON_Settings2, text11);
											}
											catch (Exception ex10)
											{
												MCommon.Common.ExportError(ex10, "HDDoiMatKhau");
											}
											break;
										case "HDTuongTacBaiVietChiDinh":
											try
											{
												num2 = HDTuongTacBaiVietChiDinh(indexRow, text2, device, jSON_Settings2.GetValue("txtIdPost"), jSON_Settings2.GetValueInt("nudTimeFrom"), jSON_Settings2.GetValueInt("nudTimeTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValue("typeReaction"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment", jSON_Settings2.GetValueInt("typeNganCach")), jSON_Settings2.GetValueBool("ckbTuDongXoaNoiDung"), jSON_Settings2.GetValueBool("ckbSendAnh"), jSON_Settings2.GetValue("txtAnh"), text11, text10);
											}
											catch (Exception ex9)
											{
												MCommon.Common.ExportError(ex9, "HDTuongTacBaiVietChiDinh");
											}
											break;
										case "HDTuongTacNhom":
											try
											{
												num2 = HDTuongTacNhom(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongNhomFrom"), jSON_Settings2.GetValueInt("nudSoLuongNhomTo"), jSON_Settings2.GetValueInt("nudTimeFrom"), jSON_Settings2.GetValueInt("nudTimeTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValueInt("nudCountLikeFrom", 1), jSON_Settings2.GetValueInt("nudCountLikeTo", 3), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueInt("nudCountCommentFrom", 1), jSON_Settings2.GetValueInt("nudCountCommentTo", 3), jSON_Settings2.GetValueList("txtComment", jSON_Settings2.GetValueInt("typeNganCach")), jSON_Settings2.GetValueBool("ckbShareWall"), jSON_Settings2.GetValueInt("nudCountShareFrom", 1), jSON_Settings2.GetValueInt("nudCountShareTo", 3), text11);
											}
											catch (Exception ex8)
											{
												MCommon.Common.ExportError(ex8, "HDTuongTacNhom");
											}
											break;
										case "HDShareBaiNangCao":
											try
											{
												num2 = HDShareBaiNangCao(indexRow, text2, device, jSON_Settings2, text, typeProxy, text10, text11);
											}
											catch (Exception ex7)
											{
												MCommon.Common.ExportError(ex7, "HDShareBaiNangCao");
											}
											break;
										case "HDDanhGiaPage":
											try
											{
												num2 = HDDanhGiaPage(indexRow, text2, device, jSON_Settings2.GetValue("txtUid"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValueBool("ckbTuDongXoaNoiDung"), text10, text11);
											}
											catch (Exception ex6)
											{
												MCommon.Common.ExportError(ex6, "HDTuongTacPage");
											}
											break;
										case "HDTuongTacLivestream":
											try
											{
												num2 = HDTuongTacLivestream(indexRow, text2, device, jSON_Settings2.GetValue("txtLinkVideo"), jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValue("typeReaction"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment"), jSON_Settings2.GetValueBool("ckbBinhLuanNhieuLan"), jSON_Settings2.GetValueInt("nudBinhLuanNhieuLanDelayFrom"), jSON_Settings2.GetValueInt("nudBinhLuanNhieuLanDelayTo"), text11);
											}
											catch (Exception ex5)
											{
												MCommon.Common.ExportError(ex5, "HDXemStory");
											}
											break;
										case "HDDangStory":
											try
											{
												num2 = HDDangStory(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("typeDang"), jSON_Settings2.GetValueList("txtNoiDung"), jSON_Settings2.GetValueBool("ckbUseBackground"), jSON_Settings2.GetValueInt("typeBaiHat"), jSON_Settings2.GetValueList("txtDanhSachBaiHat"), text11);
											}
											catch (Exception ex4)
											{
												MCommon.Common.ExportError(ex4, "HDDangStory");
											}
											break;
										case "HDSpamBaiViet":
											try
											{
												num2 = HDSpamBaiViet(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongUidFrom"), jSON_Settings2.GetValueInt("nudSoLuongUidTo"), jSON_Settings2.GetValueInt("nudSoLuongBaiVietFrom"), jSON_Settings2.GetValueInt("nudSoLuongBaiVietTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), jSON_Settings2.GetValueInt("typeID"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValue("typeReaction"), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueList("txtComment", jSON_Settings2.GetValueInt("typeNganCach")), jSON_Settings2.GetValueBool("ckbTuDongXoaUid"), jSON_Settings2.GetValueBool("ckbSendAnh"), jSON_Settings2.GetValue("txtAnh"), text11, text10);
											}
											catch (Exception ex3)
											{
												MCommon.Common.ExportError(ex3, "HDSpamBaiViet");
											}
											break;
										case "HDXacNhanKetBan":
											try
											{
												num2 = HDXacNhanKetBan(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongFrom"), jSON_Settings2.GetValueInt("nudSoLuongTo"), jSON_Settings2.GetValueInt("nudDelayFrom"), jSON_Settings2.GetValueInt("nudDelayTo"), text11);
											}
											catch (Exception ex2)
											{
												MCommon.Common.ExportError(ex2, "HDXacNhanKetBan");
											}
											break;
										case "HDTuongTacPage":
											try
											{
												num2 = HDTuongTacPage(indexRow, text2, device, jSON_Settings2.GetValueInt("nudSoLuongPageFrom"), jSON_Settings2.GetValueInt("nudSoLuongPageTo"), jSON_Settings2.GetValueBool("ckbTuDongXoaUid"), jSON_Settings2.GetValueInt("nudTimeFrom"), jSON_Settings2.GetValueInt("nudTimeTo"), jSON_Settings2.GetValueBool("ckbInteract"), jSON_Settings2.GetValueInt("nudCountLikeFrom", 1), jSON_Settings2.GetValueInt("nudCountLikeTo", 3), jSON_Settings2.GetValueBool("ckbComment"), jSON_Settings2.GetValueInt("nudCountCommentFrom", 1), jSON_Settings2.GetValueInt("nudCountCommentTo", 3), jSON_Settings2.GetValueList("txtComment", jSON_Settings2.GetValueInt("typeNganCach")), jSON_Settings2.GetValueBool("ckbShareWall"), jSON_Settings2.GetValueInt("nudCountShareFrom", 1), jSON_Settings2.GetValueInt("nudCountShareTo", 3), text10, text11);
											}
											catch (Exception ex)
											{
												MCommon.Common.ExportError(ex, "HDTuongTacPage");
											}
											break;
										}
									}
									catch (Exception ex38)
									{
										MCommon.Common.ExportError(ex38, "Tuong tac theo kich ban");
									}
									switch (num2)
									{
									default:
										goto IL_43d8;
									case -5:
										flag3 = true;
										break;
									case -4:
										flag2 = true;
										break;
									case -2:
										SetStatusAccount(indexRow, text2 + "Thiết bị đã bị đóng!");
										num3 = 1;
										goto end_IL_0141;
									}
									break;
								case 7:
									SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi kết nối Internet!"));
									num3 = 1;
									goto end_IL_0141;
								case -4:
									SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi app Fb!"));
									num3 = 1;
									goto end_IL_0141;
								case -2:
									SetStatusAccount(indexRow, text2 + Language.GetValue("Thiết bị đã bị đóng!"));
									num3 = 1;
									goto end_IL_0141;
								case -1:
									goto end_IL_0141;
								case 2:
									SetStatusAccount(indexRow, text2 + Language.GetValue("Checkpoint!"));
									SetInfoAccount(cellAccount, indexRow, "Checkpoint!");
									goto end_IL_0141;
								}
							}
							if (setting_InteractGeneral.GetValueBool("ckbUpdateInfo"))
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Update info..."));
								UpdateInfoWhenInteracting(device, indexRow, text, typeProxy);
							}
							if (!setting_InteractGeneral.GetValueBool("ckbLogOut"))
							{
							}
							break;
							IL_43d8:
							num9++;
						}
						break;
					}
				}
				end_IL_0141:;
			}
			catch (Exception ex39)
			{
				device.ExportError(ex39, "Lô\u0303i không xa\u0301c đi\u0323nh!");
				SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
				num3 = 1;
				MCommon.Common.ExportError(null, ex39, Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
			}
			goto IL_45eb;
			IL_45eb:
			string text12 = "";
			if (num3 == 1)
			{
				text12 = GetStatusAccount(indexRow);
			}
			else if (CheckIsUidFacebook(text5) && CommonRequest.CheckLiveWall(text5).StartsWith("0|"))
			{
				SetInfoAccount(cellAccount, indexRow, "Die");
				text12 = Language.GetValue("Tài khoản Die!");
			}
			if (flag4)
			{
				device.BackupConfigDevice(text5);
				if (isRunSwap && device.CheckIsLive())
				{
					SetStatusAccount(indexRow, text2 + Language.GetValue("Backup dữ liệu Fb..."), device);
					device.BackupAccountFacebook(text5, cellAccount3, cellAccount2);
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
					SetCellAccount(indexRow, "cProfile", "Yes");
					device.ClearDataAppFacebook();
				}
			}
			try
			{
				int num10 = rd.Next(setting_general.GetValueInt("nudDelayCloseDeviceFrom"), setting_general.GetValueInt("nudDelayCloseDeviceTo") + 1);
				if (num10 > 0)
				{
					int tickCount2 = Environment.TickCount;
					while ((Environment.TickCount - tickCount2) / 1000 - num10 < 0)
					{
						if (!isStop)
						{
							SetStatusAccount(indexRow, text2 + Language.GetValue("Đóng LD sau {time}s...").Replace("{time}", (num10 - (Environment.TickCount - tickCount2) / 1000).ToString()));
							MCommon.Common.DelayTime(0.5);
							continue;
						}
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
						break;
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
			lstDevice.Remove(device);
			string text13 = text12;
			string text14 = text13;
			if (!(text14 == ""))
			{
				SetStatusAccount(indexRow, text2 + text12 + (flag3 ? "- Lô\u0303i mơ\u0309 link" : "") + (flag2 ? "- Facebook blocked" : ""));
			}
			else
			{
				SetStatusAccount(indexRow, text2 + Language.GetValue("Đã tương tác xong!") + (flag3 ? "- Lô\u0303i mơ\u0309 link" : "") + (flag2 ? "- Facebook blocked" : "") + " [" + MCommon.Common.ConvertSecondsToTime((Environment.TickCount - num) / 1000) + "(s)]");
				SetCellAccount(indexRow, "cInteractEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				CommonSQL.UpdateFieldToAccount(cellAccount, "interactEnd", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
				if (GetInfoAccount(indexRow) != "Changed pass")
				{
					SetInfoAccount(cellAccount, indexRow, "Live");
				}
			}
			if (flag && Directory.Exists("profile\\" + text4) && !string.IsNullOrEmpty(text4))
			{
				string text15 = "profile\\" + text4;
				string pathTo = "profile\\" + text5;
				if (!MCommon.Common.MoveFolder(text15, pathTo) && MCommon.Common.CopyFolder(text15, pathTo))
				{
					MCommon.Common.DeleteFolder(text15);
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

		private int HDShareBaiNangCao(int indexRow, string statusProxy, Device device, JSON_Settings cauHinh, string proxy, int typeProxy, string idHanhDong, string tenHanhDong)
		{
			int num = 0;
			int num2 = 0;
			try
			{
				bool valueBool = cauHinh.GetValueBool("ckbShareBaiLenTuong");
				bool valueBool2 = cauHinh.GetValueBool("ckbShareBaiLenNhom");
				bool valueBool3 = cauHinh.GetValueBool("ckbShareNhomNangCao");
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				if (valueBool3)
				{
					flag = cauHinh.GetValueBool("ckbChiShareNhomKKD");
					flag2 = cauHinh.GetValueBool("ckbUuTienShareNhomNhieuThanhVien");
					flag3 = cauHinh.GetValueBool("ckbKhongShareTrungNhom");
				}
				int valueInt = cauHinh.GetValueInt("typeNhomToShare");
				List<string> lstNhomTuNhap = cauHinh.GetValueList("lstNhomTuNhap");
				lstNhomTuNhap = MCommon.Common.RemoveEmptyItems(lstNhomTuNhap);
				int valueInt2 = cauHinh.GetValueInt("nudCountGroupFrom");
				int valueInt3 = cauHinh.GetValueInt("nudCountGroupTo");
				int randomInt = device.GetRandomInt(valueInt2, valueInt3);
				int valueInt4 = cauHinh.GetValueInt("nudDelayFrom");
				int valueInt5 = cauHinh.GetValueInt("nudDelayTo");
				int valueInt6 = cauHinh.GetValueInt("typeShareLink");
				List<string> valueList = cauHinh.GetValueList("txtLinkChiaSe");
				valueList = MCommon.Common.RemoveEmptyItems(valueList);
				if (!dicHDShareBaiNangCao_lstIdGroupShared.ContainsKey(idHanhDong))
				{
					dicHDShareBaiNangCao_lstIdGroupShared.Add(idHanhDong, new List<string>());
				}
				string text = "";
				text = ((valueInt6 != 0) ? valueList[indexRow % valueList.Count] : valueList.OrderBy((string t) => Guid.NewGuid()).First());
				int valueInt7 = cauHinh.GetValueInt("typeLinkShare");
				bool valueBool4 = cauHinh.GetValueBool("ckbVanBan");
				List<string> valueList2 = cauHinh.GetValueList("txtNoiDung");
				bool valueBool5 = cauHinh.GetValueBool("ckbTuongTacTruocKhiShare");
				int valueInt8 = cauHinh.GetValueInt("nudSoLuongFrom");
				int valueInt9 = cauHinh.GetValueInt("nudSoLuongTo");
				bool valueBool6 = cauHinh.GetValueBool("ckbInteract");
				string value = cauHinh.GetValue("typeReaction");
				bool valueBool7 = cauHinh.GetValueBool("ckbComment");
				List<string> valueList3 = cauHinh.GetValueList("txtComment");
				bool valueBool8 = cauHinh.GetValueBool("ckbBinhLuanNhieuLan");
				int valueInt10 = cauHinh.GetValueInt("nudBinhLuanNhieuLanDelayFrom");
				int valueInt11 = cauHinh.GetValueInt("nudBinhLuanNhieuLanDelayTo");
				string html = "";
				List<string> list = new List<string>();
				if (!valueBool5)
				{
					goto IL_11c6;
				}
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Tương ta\u0301c..."), device);
				List<string> list2 = CloneList(valueList3);
				string text2 = "";
				int randomInt2 = device.GetRandomInt(valueInt8, valueInt9);
				if (valueInt7 == 0)
				{
					try
					{
						while (true)
						{
							num2 = GoToLivestream(device, indexRow, statusProxy, text);
							if (num2 == 0 || num2 == 3)
							{
								break;
							}
							if (num2 == 2)
							{
								continue;
							}
							int tickCount = Environment.TickCount;
							device.DelayTime(2.0);
							while (valueBool6)
							{
								string text3 = "[165,445][195,470]";
								string text4 = "[35,445][65,470]";
								device.SwipeByBounds(text3, text4, 500);
								device.DelayRandom(1.0, 1.5);
								if (!device.ClosePopup(ref html))
								{
									int typeReaction = Convert.ToInt32(value[device.GetRandomInt(0, value.Length - 1)].ToString());
									device.ClickReactions(typeReaction);
									device.DelayRandom(1.0, 1.5);
									device.SwipeByBounds(text4, text3);
									device.DelayRandom(1.0, 1.5);
									break;
								}
							}
							int num3 = 0;
							SetStatusAccount(indexRow, statusProxy + "Đang xem live...");
							while (Environment.TickCount - tickCount < randomInt2 * 1000 && device.CheckIsLive())
							{
								if (valueBool7 && (num3 == 0 || valueBool8))
								{
									html = device.GetHtml();
									if (device.CheckExistText("write a comment…", html))
									{
										SetStatusAccount(indexRow, statusProxy + "Đang comment...");
										if (list2.Count == 0)
										{
											list2 = MCommon.Common.CloneList(valueList3);
										}
										text2 = list2[device.GetRandomInt(0, list2.Count - 1)];
										list2.Remove(text2);
										text2 = MCommon.Common.SpinText(text2, rd);
										text2 = GetIconFacebook.ProcessString(text2, rd);
										List<string> listBoundsByText = device.GetListBoundsByText("write a comment…", html);
										if (device.TapByBounds(listBoundsByText[listBoundsByText.Count - 1]))
										{
											device.DelayRandom(1.0, 2.0);
											device.InputTextWithUnicode(text2);
											device.DelayRandom(1.0, 2.0);
											if (device.TapByText("send"))
											{
												device.DelayRandom(3.0, 5.0);
											}
											num3++;
											SetStatusAccount(indexRow, statusProxy + "Đang xem live...");
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
									int num4 = (Environment.TickCount - tickCount) / 1000;
									SetStatusAccount(indexRow, statusProxy + "Đang xem live, còn " + (randomInt2 - num4) + "s...", device);
									device.DelayTime(1.0);
								}
							}
							goto IL_0735;
						}
					}
					catch
					{
						goto IL_0735;
					}
				}
				else
				{
					try
					{
						device.LoadStatusLD("Open video");
						while (true)
						{
							num2 = GoToVideo(device, indexRow, statusProxy, text);
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
									for (int i = 0; i < 3; i++)
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
										string text5 = listBoundsByImage.FirstOrDefault();
										if (!string.IsNullOrEmpty(text5))
										{
											SetStatusAccount(indexRow, statusProxy + "Đang thả cảm xúc video...");
											if (device.TapLongByBounds(text5, "[0,100][320,480]"))
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
								int num5 = 0;
								int tickCount2 = Environment.TickCount;
								SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
								while (Environment.TickCount - tickCount2 < randomInt2 * 1000 && device.CheckIsLive())
								{
									if (valueBool7 && (num5 == 0 || valueBool8))
									{
										string boundsByImage = device.GetBoundsByImage("DataClick\\image\\comment");
										if (string.IsNullOrEmpty(boundsByImage))
										{
											continue;
										}
										device.LoadStatusLD("Comment");
										SetStatusAccount(indexRow, statusProxy + "Đang comment...");
										if (list2.Count == 0)
										{
											list2 = MCommon.Common.CloneList(valueList3);
										}
										text2 = list2[device.GetRandomInt(0, list2.Count - 1)];
										list2.Remove(text2);
										text2 = MCommon.Common.SpinText(text2, rd);
										text2 = GetIconFacebook.ProcessString(text2, rd);
										if (device.TapByBounds(boundsByImage, "[0,100][320,480]"))
										{
											device.DelayRandom(1.0, 2.0);
											device.InputTextWithUnicode(text2);
											device.DelayRandom(1.0, 2.0);
											if (device.TapByText("send"))
											{
												device.DelayRandom(3.0, 5.0);
											}
											device.GotoBack(2, 0.3);
											num5++;
											SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
											device.DelayRandom(valueInt10, valueInt11);
										}
									}
									else
									{
										int num6 = (Environment.TickCount - tickCount2) / 1000;
										SetStatusAccount(indexRow, statusProxy + "Đang xem video, còn " + (randomInt2 - num6) + "s...", device);
										device.DelayTime(1.0);
									}
								}
							}
							else
							{
								device.LoadStatusLD("Interact");
								if (valueBool6)
								{
									for (int j = 0; j < 4; j++)
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
										string text6 = list3.FirstOrDefault();
										if (!string.IsNullOrEmpty(text6))
										{
											SetStatusAccount(indexRow, statusProxy + "Đang thả cảm xúc video...");
											if (device.TapLongByBounds(text6, "[0,100][320,480]"))
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
								int num7 = 0;
								int tickCount3 = Environment.TickCount;
								SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
								while (Environment.TickCount - tickCount3 < randomInt2 * 1000 && device.CheckIsLive())
								{
									if (valueBool7 && (num7 == 0 || valueBool8))
									{
										html = device.GetHtml();
										num2 = device.CheckExistTexts(html, 0.0, "write a comment…", "comment button");
										string text7 = "";
										switch (num2)
										{
										case 1:
											text7 = device.GetBoundsByText("write a comment…", html);
											break;
										case 2:
											text7 = device.GetListBoundsByText("comment button").LastOrDefault();
											break;
										default:
											text7 = device.GetBoundsByImage("DataClick\\image\\comment");
											if (!string.IsNullOrEmpty(text7))
											{
												num2 = 2;
											}
											break;
										}
										if (string.IsNullOrEmpty(text7))
										{
											continue;
										}
										device.LoadStatusLD("Comment");
										SetStatusAccount(indexRow, statusProxy + "Đang comment...");
										if (list2.Count == 0)
										{
											list2 = MCommon.Common.CloneList(valueList3);
										}
										text2 = list2[device.GetRandomInt(0, list2.Count - 1)];
										list2.Remove(text2);
										text2 = MCommon.Common.SpinText(text2, rd);
										text2 = GetIconFacebook.ProcessString(text2, rd);
										switch (num2)
										{
										case 1:
										{
											Bitmap bitmap = device.Crop(device.ScreenShoot(), "[44,72][153,96]");
											if (!device.TapByBounds(text7))
											{
												break;
											}
											device.DelayRandom(1.0, 2.0);
											device.InputTextWithUnicode(text2);
											device.DelayRandom(1.0, 2.0);
											if (device.TapByText("send"))
											{
												device.DelayRandom(3.0, 5.0);
											}
											for (int k = 0; k < 5; k++)
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
											num7++;
											SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
											device.DelayRandom(valueInt10, valueInt11);
											break;
										}
										case 2:
											if (device.TapByBounds(text7, "[0,100][320,480]"))
											{
												device.DelayRandom(1.0, 2.0);
												device.InputTextWithUnicode(text2);
												device.DelayRandom(1.0, 2.0);
												if (device.TapByText("send"))
												{
													device.DelayRandom(3.0, 5.0);
												}
												device.GotoBack(2, 0.3);
												num7++;
												SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
												device.DelayRandom(valueInt10, valueInt11);
											}
											break;
										}
									}
									else
									{
										int num8 = (Environment.TickCount - tickCount3) / 1000;
										SetStatusAccount(indexRow, statusProxy + "Đang xem video, còn " + (randomInt2 - num8) + "s...", device);
										device.DelayTime(1.0);
									}
								}
							}
							goto IL_11aa;
						}
					}
					catch
					{
						goto IL_11aa;
					}
				}
				goto end_IL_000c;
				IL_228a:
				List<string> list4;
				if (valueBool2)
				{
					if ((valueBool3 || valueInt == 1) && list4.Count == 0)
					{
						SetStatusAccount(indexRow, "No Group!", device);
					}
					else
					{
						int num9 = 0;
						while (num9 < randomInt + 5 && num < randomInt)
						{
							SetStatusAccount(indexRow, statusProxy + "Share groups...", device);
							while ((!valueBool3 && valueInt != 1) || list4.Count != 0)
							{
								device.LoadStatusLD("Open post");
								num2 = GoToVideo(device, indexRow, statusProxy, text);
								if (num2 == 0 || num2 == 3)
								{
									break;
								}
								if (num2 == 2)
								{
									continue;
								}
								device.LoadStatusLD("Loading2");
								bool flag4 = false;
								int num10 = 0;
								while (true)
								{
									if (num10 < 10)
									{
										if (!device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
										{
											if (!(device.GetActivity() != "com.facebook.katana/com.facebook.deeplinking.activity.StoryDeepLinkLoadingActivity"))
											{
												if (!device.CheckExistText("\"can't post"))
												{
													switch (CheckStatusDevice(device, indexRow, statusProxy, isAllowClickImageX: false))
													{
													case 0:
														goto IL_2411;
													case 1:
														break;
													default:
														goto end_IL_000c;
													}
													break;
												}
											}
											else
											{
												flag4 = true;
											}
										}
										else
										{
											flag4 = true;
										}
									}
									if (flag4)
									{
										device.LoadStatusLD("Find share");
										bool flag5 = false;
										int num11 = 0;
										while (true)
										{
											if (num11 >= 5)
											{
												goto IL_25c4;
											}
											if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
											{
												if (!device.TapByImage("DataClick\\image\\share"))
												{
													if (!device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
													{
														device.DelayTime(1.0);
														goto IL_259a;
													}
												}
												else
												{
													flag5 = true;
												}
												goto IL_25c4;
											}
											num2 = CheckStatusDevice(device, indexRow, statusProxy, isAllowClickImageX: false);
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
														goto IL_259a;
													}
												}
												else
												{
													flag5 = true;
												}
												goto IL_25c4;
											}
											goto end_IL_000c;
											IL_259a:
											num11++;
											continue;
											IL_25c4:
											if (flag5)
											{
												goto IL_25d2;
											}
											goto IL_2dc6;
										}
										break;
									}
									goto IL_2dd0;
									IL_2dd0:
									num9++;
									goto IL_2dda;
									IL_2dc6:
									if (num > 0)
									{
										goto IL_2dd0;
									}
									goto end_IL_000c;
									IL_25d2:
									device.LoadStatusLD("Find share group");
									for (int l = 0; l < 2; l++)
									{
										if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
										{
											bool flag6 = false;
											int num12 = 0;
											while (num12 < 5)
											{
												if (device.TapByImageWait("DataClick\\image\\sharegroup", 3))
												{
													flag6 = true;
													break;
												}
												if (!(device.GetActivity() == "Application"))
												{
													device.DelayTime(1.0);
													num12++;
													continue;
												}
												goto end_IL_000c;
											}
											if (flag6)
											{
												break;
											}
											if (l == 0)
											{
												string bounds = "[220,415][260,455]";
												string bounds2 = "[35,415][65,455]";
												device.SwipeByBounds(bounds, bounds2);
											}
											else if (num <= 0)
											{
												break;
											}
											continue;
										}
										bool flag7 = false;
										for (int m = 0; m < 5; device.DelayTime(1.0), m++)
										{
											html = "";
											if (device.TapByImageWait("DataClick\\image\\sharegroup", 3) || device.TapByText("share to a group", html))
											{
												flag7 = true;
												break;
											}
											if (!(device.GetActivity() == "Application"))
											{
												switch (CheckStatusDevice(device, indexRow, statusProxy))
												{
												case 0:
													continue;
												case 1:
													break;
												default:
													goto end_IL_000c;
												}
												goto IL_2b44;
											}
											goto end_IL_000c;
										}
										if (flag7)
										{
											break;
										}
										if (l == 0)
										{
											string bounds3 = "[220,415][260,455]";
											string bounds4 = "[35,415][65,455]";
											device.SwipeByBounds(bounds3, bounds4);
										}
										else if (num <= 0)
										{
											break;
										}
									}
									if (!device.WaitForLoaded(10))
									{
										goto IL_2dd0;
									}
									string text8 = "";
									if (!valueBool3 && valueInt != 1)
									{
										goto IL_2996;
									}
									while (list4.Count != 0)
									{
										string item = list4[0].Split('|')[0];
										text8 = list4[0].Split('|')[1];
										list4.RemoveAt(0);
										if (flag3)
										{
											lock (dicHDShareBaiNangCao_lstIdGroupShared)
											{
												if (dicHDShareBaiNangCao_lstIdGroupShared[idHanhDong].Contains(item))
												{
													continue;
												}
												dicHDShareBaiNangCao_lstIdGroupShared[idHanhDong].Add(item);
												goto IL_2957;
											}
										}
										goto IL_2957;
										IL_2957:
										device.TapByText("\"search\"");
										device.InputTextWithUnicode(text8);
										device.DelayTime(2.0);
										goto IL_2996;
									}
									goto end_IL_000c;
									IL_2996:
									int num13 = 0;
									while (true)
									{
										if (num13 < 5)
										{
											List<string> list5 = new List<string>();
											for (int n = 0; n < 2; n++)
											{
												html = device.GetHtml();
												list5 = device.GetListText(html, 2);
												list5.Remove("back");
												if (list5.Count != 0 || (!valueBool3 && valueInt != 1) || n >= 1)
												{
													break;
												}
												device.InputKeyBackspace(5);
												device.DelayTime(2.0);
											}
											if (list5.Count != 0)
											{
												if (!valueBool3 && valueInt != 1)
												{
													text8 = (from t in list5.Except(list)
														orderby Guid.NewGuid()
														select t).FirstOrDefault();
													if (string.IsNullOrEmpty(text8))
													{
														device.ScrollAndCheckScreenNotChange(device.GetRandomInt(400, 500));
														num13++;
														continue;
													}
												}
												else
												{
													text8 = list5[0];
												}
											}
											else if (valueBool3 || valueInt == 1)
											{
												break;
											}
										}
										if (!string.IsNullOrEmpty(text8))
										{
											goto IL_2b69;
										}
										goto end_IL_000c;
									}
									break;
									IL_2411:
									device.DelayTime(2.0);
									num10++;
									continue;
									IL_2b69:
									device.DelayTime(2.0);
									if (!device.TapByText("content-desc=\"" + text8, html))
									{
										goto IL_2dd0;
									}
									list.Add(text8);
									device.DelayTime(1.0);
									string text9 = "";
									for (int num14 = 0; num14 < 10; num14++)
									{
										html = device.GetHtml();
										text9 = device.GetBoundsByText("\"post", html);
										if (text9 == "")
										{
											text9 = device.GetBoundsByImage("DataClick\\image\\dang");
										}
										if (text9 != "")
										{
											break;
										}
										device.DelayTime(1.0);
									}
									if (!(text9 != ""))
									{
										goto IL_2dd0;
									}
									if (valueBool4 && valueList2.Count > 0 && (device.TapByImage("DataClick\\image\\banvietgidi") || device.TapByText("\"write something…\"", html)))
									{
										string text10 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
										text10 = MCommon.Common.SpinText(text10, rd);
										text10 = GetIconFacebook.ProcessString(text10, rd);
										device.InputTextWithUnicode(text10);
										device.DelayTime(1.0);
									}
									if (!device.TapByBounds(text9))
									{
										goto IL_2dd0;
									}
									num++;
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" share post ({num}/{randomInt})...");
									device.LoadStatusLD("Posted");
									device.DelayRandom(valueInt4, valueInt5);
									if (!device.CheckExistImage("DataClick\\image\\cantpost"))
									{
										goto IL_2dd0;
									}
									goto end_IL_000c;
								}
								IL_2b44:;
							}
							break;
							IL_2dda:;
						}
					}
				}
				goto end_IL_000c;
				IL_11aa:
				SetStatusAccount(indexRow, statusProxy + "Xem video xong...");
				goto IL_11c6;
				IL_11c6:
				list4 = new List<string>();
				if (valueBool2 && (valueBool3 || valueInt == 1))
				{
					for (int num15 = 0; num15 < 2; num15++)
					{
						if (num15 != 1)
						{
							goto IL_1359;
						}
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Mở app Facebook..."), device);
						string text11 = device.OpenFacebookAndCheckStatusLogin();
						if (!(text11.Split('|')[0] == "0") && !(text11.Split('|')[0] == "2"))
						{
							num2 = ((!(text11.Split('|')[1] == "0") && !(text11.Split('|')[1] == "11")) ? Convert.ToInt32(text11.Split('|')[1]) : LoginFacebook(device, indexRow, statusProxy));
							if (num2 == 1)
							{
								goto IL_1359;
							}
						}
						goto end_IL_000c;
						IL_1359:
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Scan group..."), device);
						string text12 = device.GetTokenCookie().Split('|')[1];
						if (!(text12.Trim() == ""))
						{
							List<string> listGroup = CommonRequest.GetListGroup(text12, proxy, typeProxy, flag);
							list4 = ((!flag) ? listGroup.Select((string x) => x).ToList() : listGroup.Where((string x) => x.Split('|')[3].ToLower() == "false").ToList());
							if (flag2)
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
					}
				}
				if (valueInt7 == 0)
				{
					while (true)
					{
						IL_1ed9:
						device.LoadStatusLD("Open livestream...");
						num2 = GoToLivestream(device, indexRow, statusProxy, text);
						if (num2 == 0 || num2 == 3)
						{
							break;
						}
						switch (num2)
						{
						case 2:
							continue;
						case 4:
							goto end_IL_000c;
						}
						if (valueBool)
						{
							SetStatusAccount(indexRow, statusProxy + Language.GetValue("Share Wall..."));
							bool flag8 = false;
							int num16 = 0;
							do
							{
								flag8 = false;
								num16++;
								switch (num16)
								{
								case 2:
								{
									for (int num18 = 0; num18 < 10; num18++)
									{
										if (device.TapByImageWait("DataClick\\image\\chiase"))
										{
											if (device.TapByImageWait("DataClick\\image\\vietbai"))
											{
												flag8 = true;
												break;
											}
											device.GotoBack();
										}
										device.DelayTime(2.0);
									}
									continue;
								}
								case 3:
								{
									if (valueBool4 && valueList2.Count > 0 && (device.TapByImage("DataClick\\image\\banvietgidi") || device.TapByText("\"write something…\"")))
									{
										string text13 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
										text13 = MCommon.Common.SpinText(text13, rd);
										text13 = GetIconFacebook.ProcessString(text13, rd);
										device.InputTextWithUnicode(text13);
										device.DelayTime(1.0);
									}
									if (device.TapByImageWait("DataClick\\image\\dang"))
									{
										flag8 = true;
										continue;
									}
									string text14 = device.GetListBoundsByText("\"post\"").LastOrDefault();
									if (!string.IsNullOrEmpty(text14))
									{
										flag8 = true;
										device.TapByBounds(text14);
									}
									continue;
								}
								case 1:
								{
									for (int num17 = 0; num17 < 30; num17++)
									{
										if (device.CheckExistImage("DataClick\\image\\theodoi"))
										{
											device.GotoBack();
										}
										else
										{
											if (device.CheckExistImage("DataClick\\image\\chiase"))
											{
												flag8 = true;
												break;
											}
											if (!device.ClosePopup())
											{
												device.SwipeByBounds("[35,445][65,470]", "[165,445][195,470]", 500);
											}
										}
										device.DelayTime(1.0);
									}
									continue;
								}
								}
								flag8 = true;
								break;
							}
							while (flag8);
						}
						if (valueBool2)
						{
							if ((!valueBool3 && valueInt != 1) || list4.Count != 0)
							{
								SetStatusAccount(indexRow, statusProxy + Language.GetValue("Share Groups..."));
								bool flag9 = false;
								int num19 = 0;
								do
								{
									flag9 = false;
									num19++;
									if (num19 != 1)
									{
										if (num19 == 2)
										{
											for (int num20 = 0; num20 < 10; num20++)
											{
												if (device.TapByImageWait("DataClick\\image\\chiase"))
												{
													if (device.TapByImageWait("DataClick\\image\\chiaselennhom"))
													{
														flag9 = true;
														break;
													}
													device.GotoBack();
												}
												device.DelayTime(2.0);
											}
											continue;
										}
										if (num19 == 3)
										{
											if (valueBool4 && valueList2.Count > 0)
											{
												for (int num21 = 0; num21 < 10; num21++)
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
															num19 = 0;
															break;
														case 1:
														{
															device.TapByText("write a message…", html);
															string text15 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
															text15 = MCommon.Common.SpinText(text15, rd);
															text15 = GetIconFacebook.ProcessString(text15, rd);
															device.InputTextWithUnicode(text15);
															device.DelayTime(1.0);
															break;
														}
														}
													}
													else
													{
														string text16 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
														text16 = MCommon.Common.SpinText(text16, rd);
														text16 = GetIconFacebook.ProcessString(text16, rd);
														device.InputTextWithUnicode(text16);
														device.DelayTime(1.0);
													}
													break;
												}
											}
											int num22 = 0;
											while (num < randomInt)
											{
												num22++;
												if (num22 % 4 == 0)
												{
													switch (CheckStatusDevice(device, indexRow, statusProxy))
													{
													case 0:
														break;
													case 1:
														goto IL_1ed9;
													default:
														goto end_IL_000c;
													}
												}
												if (!valueBool3 && valueInt != 1)
												{
													goto IL_1cce;
												}
												while (list4.Count != 0)
												{
													string item2 = list4[0].Split('|')[0];
													string text17 = list4[0].Split('|')[1];
													list4.RemoveAt(0);
													if (flag3)
													{
														lock (dicHDShareBaiNangCao_lstIdGroupShared)
														{
															if (dicHDShareBaiNangCao_lstIdGroupShared[idHanhDong].Contains(item2))
															{
																continue;
															}
															dicHDShareBaiNangCao_lstIdGroupShared[idHanhDong].Add(item2);
															goto IL_1c8f;
														}
													}
													goto IL_1c8f;
													IL_1c8f:
													device.ClearText("search");
													device.InputTextWithUnicode(text17);
													device.DelayTime(2.0);
													goto IL_1cce;
												}
												goto end_IL_000c;
												IL_1cce:
												if (!device.TapByImage("DataClick\\image\\chiasexanh"))
												{
													if (!valueBool3 && valueInt != 1 && device.ScrollAndCheckScreenNotChange(rd.Next(1000, 1100), 1, "[115,429][210,460]", "[154,292][246,312]", "[27,253][296,454]"))
													{
														break;
													}
													continue;
												}
												num++;
												SetStatusAccount(indexRow, statusProxy + Language.GetValue($"Chia sẻ lên nhóm {num}/{randomInt}..."));
												if (num >= randomInt)
												{
													break;
												}
												device.DelayRandom(valueInt4, valueInt5);
												if (device.CheckExistImage("DataClick\\image\\posted") || device.CheckExistText("posted"))
												{
													continue;
												}
												goto end_IL_000c;
											}
											continue;
										}
										flag9 = true;
										break;
									}
									for (int num23 = 0; num23 < 30; num23++)
									{
										if (device.CheckExistImage("DataClick\\image\\theodoi"))
										{
											device.GotoBack();
										}
										else
										{
											if (device.CheckExistImage("DataClick\\image\\chiase"))
											{
												flag9 = true;
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
								while (flag9);
							}
							else
							{
								SetStatusAccount(indexRow, "No Group!", device);
							}
						}
						goto end_IL_000c;
					}
				}
				else
				{
					if (!valueBool)
					{
						goto IL_228a;
					}
					SetStatusAccount(indexRow, statusProxy + "Share tươ\u0300ng...", device);
					while (true)
					{
						device.LoadStatusLD("Open post");
						num2 = GoToVideo(device, indexRow, statusProxy, text);
						if (num2 == 0 || num2 == 3)
						{
							break;
						}
						if (num2 == 2)
						{
							continue;
						}
						bool flag10 = false;
						for (int num24 = 0; num24 < 5; num24++)
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
							flag10 = true;
							break;
						}
						if (!flag10)
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
									string text18 = valueList2.OrderBy((string t) => Guid.NewGuid()).First();
									text18 = MCommon.Common.SpinText(text18, rd);
									text18 = GetIconFacebook.ProcessString(text18, rd);
									device.InputTextWithUnicode(text18);
									device.DelayTime(1.0);
								}
								device.TapByText("\"post", html);
							}
						}
						goto IL_228a;
					}
				}
				goto end_IL_000c;
				IL_0735:
				SetStatusAccount(indexRow, statusProxy + "Xem Live xong...");
				goto IL_11c6;
				end_IL_000c:;
			}
			catch
			{
			}
			return num;
		}

		private int HDTuongTacBaiVietIA(int indexRow, string statusProxy, Device device, JSON_Settings setting, string tenHanhDong)
		{
			int result = 0;
			string html = "";
			try
			{
				string value = setting.GetValue("txtIdPage");
				int valueInt = setting.GetValueInt("nudSoLuongBaiFrom");
				int valueInt2 = setting.GetValueInt("nudSoLuongBaiTo");
				int valueInt3 = setting.GetValueInt("nudThoiGianLuotFrom");
				int valueInt4 = setting.GetValueInt("nudThoiGianLuotTo");
				device.GotoPageQuick(value);
				if (device.CheckExistTexts(ref html, 10.0, "home", "page cover photo") > 0)
				{
					if (device.CheckExistText("posts, tab", ref html, 10.0))
					{
						device.TapByText("posts, tab", html);
					}
					device.DelayTime(2.0);
					int num = 0;
					int num2 = 100;
					int num3 = 0;
					int num4 = rd.Next(valueInt, valueInt2 + 1);
					for (num = 0; num < num2; num++)
					{
						SetStatusAccount(indexRow, statusProxy + "Tìm bài viết...", device);
						if (device.ScrollAndCheckScreenNotChange(rd.Next(400, 500)))
						{
							break;
						}
						html = device.GetHtml();
						if (device.CheckExistText("shared link image", html))
						{
							device.TapByText("shared link image", html);
							device.DelayTime(2.0);
							SetStatusAccount(indexRow, statusProxy + "Lướt bài viết...", device);
							int tickCount = Environment.TickCount;
							int num5 = rd.Next(valueInt3, valueInt4 + 1);
							while (Environment.TickCount - tickCount < num5 * 1000 && !device.ScrollAndCheckScreenNotChange(device.GetRandomInt(100, 1000)))
							{
							}
							device.GotoBack();
							device.DelayTime(2.0);
							device.ScrollAndCheckScreenNotChange(rd.Next(200, 300));
							num = 0;
							num3++;
							if (num3 > num4)
							{
								break;
							}
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDMoiBanBeLikePage(int indexRow, string statusProxy, Device device, JSON_Settings setting, string tenHanhDong)
		{
			int result = 0;
			string html = "";
			try
			{
				List<string> valueList = setting.GetValueList("txtUid");
				int valueInt = setting.GetValueInt("nudSoLuongFrom");
				int valueInt2 = setting.GetValueInt("nudSoLuongTo");
				string id = valueList[indexRow % valueList.Count];
				int num = 0;
				int randomInt = device.GetRandomInt(valueInt, valueInt2);
				device.GotoPageQuick(id);
				if (device.CheckExistTexts(ref html, 10.0, "home", "page cover photo") > 0 && device.TapByImage("DataClick\\image\\sharepage", null, 5))
				{
					if (device.TapByText("invite friends to like this page", "", 5))
					{
						goto IL_0196;
					}
					device.GotoBack();
					if (device.TapByImageWait("DataClick\\image\\3cham", 5) && device.TapByImageWait("DataClick\\image\\sharepage2", 5) && device.TapByText("invite friends to like this page", "", 5))
					{
						goto IL_0196;
					}
				}
				goto end_IL_000c;
				IL_0196:
				num++;
				if (device.CheckExistText("invite friends", "", 10.0))
				{
					for (int i = 0; i < randomInt; i++)
					{
						if (!device.TapByImageWait("DataClick\\image\\checkbox"))
						{
							if (device.ScrollAndCheckScreenNotChange())
							{
								break;
							}
							i--;
						}
						SetStatusAccount(indexRow, $"Đang cho\u0323n {i + 1}/{randomInt}...", device);
						device.DelayRandom(0.5, 1.0);
					}
					if (device.TapByText("invite selected friends", "", 5) && device.CheckExistTexts("", 10.0, "home", "page cover photo") > 0)
					{
					}
				}
				end_IL_000c:;
			}
			catch
			{
			}
			return result;
		}

		private int HDMoiBanBeVaoNhom(int indexRow, string statusProxy, Device device, JSON_Settings setting, string tenHanhDong, string proxy, int typeProxy)
		{
			string value = setting.GetValue("txtIdGroup");
			int valueInt = setting.GetValueInt("typeInvite");
			int valueInt2 = setting.GetValueInt("nudSoLuongFrom");
			int valueInt3 = setting.GetValueInt("nudSoLuongTo");
			int valueInt4 = setting.GetValueInt("nudDelayFrom");
			int valueInt5 = setting.GetValueInt("nudDelayTo");
			int result = 1;
			bool flag = false;
			int num = 0;
			int randomInt = device.GetRandomInt(valueInt2, valueInt3);
			try
			{
				device.GotoGroupQuick(value);
				if (device.CheckExistTexts("", 10.0, "cover photo of group", "community") != 0)
				{
					flag = false;
					for (int i = 0; i < 5; i++)
					{
						if (flag = device.TapByText("invite members", "", 2))
						{
							break;
						}
						if (device.ScrollAndCheckScreenNotChange(800, -1))
						{
							break;
						}
					}
					if (flag)
					{
						if (valueInt == 1)
						{
							List<string> listBoundsByText = device.GetListBoundsByText("\"invite\"");
							string text = "";
							for (int j = 0; j < randomInt + 10; j++)
							{
								if (listBoundsByText.Count == 0)
								{
									if (device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									listBoundsByText = device.GetListBoundsByText("\"invite\"");
									if (listBoundsByText.Count == 0)
									{
										break;
									}
								}
								text = listBoundsByText.LastOrDefault();
								listBoundsByText.Remove(text);
								device.TapByBounds(text);
								num++;
								SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{randomInt})...");
								if (num < randomInt)
								{
									device.DelayRandom(valueInt4, valueInt5);
									continue;
								}
								break;
							}
						}
						else
						{
							int num2 = 0;
							string text2 = "";
							string text3 = "";
							string token = device.GetTokenCookie().Split('|')[0];
							List<string> nameFriend = CommonRequest.GetNameFriend(token, proxy, typeProxy);
							if (flag = device.TapByText("search for friends"))
							{
								for (int k = 0; k < randomInt + 10; k++)
								{
									if (nameFriend.Count == 0)
									{
										break;
									}
									text3 = nameFriend[rd.Next(0, nameFriend.Count)];
									nameFriend.Remove(text3);
									device.InputTextWithUnicode(text3);
									device.DelayRandom(2.0, 2.5);
									for (int l = 0; l < 10; device.DelayTime(1.0), l++)
									{
										text2 = device.GetHtml();
										switch (device.CheckExistTexts(text2, 0.0, "\"invite\"", "we couldn't find a match"))
										{
										default:
											continue;
										case 1:
											device.TapByText("\"invite\"", text2);
											num++;
											SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{randomInt})...");
											device.DelayRandom(valueInt4, valueInt5);
											break;
										case 2:
											break;
										}
										break;
									}
									if (num < randomInt)
									{
										device.ClearText("search for friends");
										continue;
									}
									break;
								}
							}
						}
					}
				}
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		private int HDDoiMatKhau(int indexRow, string statusProxy, Device device, JSON_Settings setting, string tenHanhDong)
		{
			int result = 0;
			string text = "";
			int num = 0;
			bool flag = false;
			string text2 = "";
			string cellAccount = GetCellAccount(indexRow, "cId");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			if (cellAccount2 == "")
			{
				SetStatusAccount(indexRow, statusProxy + "Mâ\u0323t khâ\u0309u trô\u0301ng!", device);
				device.DelayTime(3.0);
			}
			else
			{
				try
				{
					int valueInt = setting.GetValueInt("typeMatKhau");
					string text3 = setting.GetValue("txtMatKhau");
					if (text3.Contains("*"))
					{
						string[] array = text3.Split('*');
						text3 = array[0];
						for (int i = 1; i < array.Length; i++)
						{
							text3 += MCommon.Common.CreateRandomString(1, rd);
							text3 += array[i];
						}
					}
					int valueInt2 = setting.GetValueInt("nudTimeOut", 30);
					device.GotoNewFeedQuick();
					num++;
					if (flag = device.TapByImage("DataClick\\image\\menu", null, 10))
					{
						flag = false;
						num++;
						for (int j = 0; j < 10; j++)
						{
							text = device.GetHtml();
							if (!device.CheckExistText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", text))
							{
								if (!device.CheckExistText("settings &amp; privacy, header. section is expanded. double-tap to collapse the section.", text))
								{
									if (device.ScrollAndCheckScreenNotChange(500))
									{
										break;
									}
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							device.TapByText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", text);
							flag = true;
							break;
						}
						if (flag)
						{
							flag = false;
							num++;
							for (int k = 0; k < 10; k++)
							{
								if (!device.TapByImage("DataClick\\image\\caidat"))
								{
									if (k % 2 == 1 && device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							if (flag)
							{
								flag = false;
								for (int l = 0; l < 10; l++)
								{
									text = device.GetHtml();
									if (!device.TapByText("password and security", text) && !device.TapByText("security and login", text))
									{
										if (device.ScrollAndCheckScreenNotChange())
										{
											break;
										}
										device.DelayTime(1.0);
										continue;
									}
									flag = true;
									break;
								}
								if (flag)
								{
									int num2 = 0;
									while (true)
									{
										IL_05d5:
										text2 = ((valueInt == 0) ? MCommon.Common.CreateRandomStringNumber(10, rd) : text3);
										num++;
										if (!(flag = device.TapByText("change password", "", 10)))
										{
											break;
										}
										num++;
										if (!(flag = device.CheckExistText("update password", "", 10.0)))
										{
											break;
										}
										device.TapByBounds("[40,80][160,105]");
										device.DelayTime(1.0);
										device.InputTextWithUnicode(cellAccount2);
										device.TapByBounds("[40,125][160,150]");
										device.DelayTime(1.0);
										device.InputTextWithUnicode(text2);
										device.TapByBounds("[40,170][160,195]");
										device.DelayTime(1.0);
										device.InputTextWithUnicode(text2);
										num++;
										if (!(flag = device.TapByText("update password", "", 10)))
										{
											break;
										}
										flag = false;
										int num3 = 0;
										while (num3 < valueInt2)
										{
											if (!device.CheckExistImage("DataClick\\image\\wrongpass"))
											{
												if (!device.CheckExistImage("DataClick\\image\\loimatkhaumoi"))
												{
													if (!device.CheckExistText("log out of other devices?"))
													{
														device.DelayTime(1.0);
														num3++;
														continue;
													}
													if (device.TapByImage("DataClick\\image\\duytridangnhap"))
													{
														device.TapByImage("DataClick\\image\\nutTiepTuc");
													}
													device.GotoNewFeedQuick();
													flag = true;
													break;
												}
												if (valueInt == 0)
												{
													num2++;
													if (num2 < 10)
													{
														device.TapByBounds("[13,32][31,47]");
														goto IL_05d5;
													}
													break;
												}
												SetStatusAccount(indexRow, statusProxy + "Mâ\u0323t khâ\u0309u không tin câ\u0323y!", device);
												device.DelayTime(3.0);
												break;
											}
											SetInfoAccount(cellAccount, indexRow, "Changed pass");
											break;
										}
										break;
									}
								}
							}
						}
					}
				}
				catch
				{
				}
			}
			if (flag && text2 != "")
			{
				CommonSQL.UpdateFieldToAccount(cellAccount, "pass", text2);
				SetCellAccount(indexRow, "cPassword", text2);
				SetStatusAccount(indexRow, statusProxy + "Đô\u0309i mâ\u0323t khâ\u0309u tha\u0300nh công!", device);
			}
			else
			{
				SetStatusAccount(indexRow, statusProxy + "Đô\u0309i mâ\u0323t khâ\u0309u thâ\u0301t ba\u0323i!", device);
				device.DelayTime(3.0);
			}
			return result;
		}

		private void UpdateInfoWhenInteracting(Device device, int row, string proxy, int typeProxy)
		{
			string tokenCookie = device.GetTokenCookie();
			string text = tokenCookie.Split('|')[0];
			string text2 = tokenCookie.Split('|')[1];
			if (string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text))
			{
				return;
			}
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string infoAccountFromUidUsingCookie = GetInfoAccountFromUidUsingCookie(text2, text, proxy, typeProxy);
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
			catch (Exception ex)
			{
				CommonCSharp.ExportError(null, ex.ToString());
			}
		}

		public static string GetInfoAccountFromUidUsingCookie(string cookie, string token, string proxy, int typeProxy)
		{
			string text = "";
			bool flag = false;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			try
			{
				string value = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				RequestXNet requestXNet = new RequestXNet(cookie, "", proxy, typeProxy);
				string input = requestXNet.RequestGet("https://mbasic.facebook.com/friends/center/friends/?mff_nav=1");
				text7 = Regex.Match(input, "bm bn\">(.*?)<").Groups[1].Value.Replace(",", "").Replace(".", "");
				if (text7 == "")
				{
					text7 = Regex.Match(input, "bm\">(.*?)<").Groups[1].Value.Replace(",", "").Replace(".", "");
				}
				text7 = Regex.Match(text7, "\\d+").Value;
				input = requestXNet.RequestGet("https://mbasic.facebook.com/groups/?seemore&refid=27");
				text8 = Regex.Matches(input, "class=\"bl\"").Count.ToString();
				try
				{
					input = requestXNet.RequestGet("https://mobile.facebook.com/composer/ocelot/async_loader/?publisher=feed");
					string value2 = Regex.Match(input, MCommon.Common.Base64Decode("bmFtZT1cXCJmYl9kdHNnXFwiIHZhbHVlPVxcIiguKj8pXFwi")).Groups[1].Value;
					string value3 = Regex.Match(input, "LSD\\\\\",\\[\\],{\\\\\"token\\\\\":\\\\\"(.*?)\\\\\"").Groups[1].Value;
					token = Regex.Match(input, "EAAA(.*?)\"").Value.TrimEnd('"', '\\');
					string data = "av=" + value + "&__user=" + value + "&__a=1&__dyn=&__csr=&__req=y&__hs=18794.EXP2%3Acomet_pkg.2.1.0.0&dpr=1&__ccg=EXCELLENT&__rev=1003974565&__s=zbue97%3A5iciql%3Abxnvge&__hsi=6974199735511561326-0&__comet_req=1&fb_dtsg=" + value2 + "&jazoest=22414&lsd=" + value3 + "&__spin_r=1003974565&__spin_b=trunk&__spin_t=1623807413&fb_api_caller_class=RelayModern&fb_api_req_friendly_name=PrivacyAccessHubYourInformationSectionQuery&variables=%7B%7D&server_timestamps=true&doc_id=3200030856767767";
					input = requestXNet.RequestPost("https://web.facebook.com/api/graphql/", data);
					JObject jObject = JObject.Parse(input);
					text9 = jObject["data"]!["section"]!["tiles"]![1]!["links"]![0]!["non_link_content"]!["metadata"]!.ToString();
				}
				catch
				{
				}
				string infoAccountFromUidUsingToken = GetInfoAccountFromUidUsingToken(cookie, token, proxy, typeProxy);
				string[] array = infoAccountFromUidUsingToken.Split('|');
				text2 = array[1];
				text3 = array[2];
				text4 = array[3];
				text6 = array[5];
				if (text10 == "")
				{
					text10 = "0";
				}
				if (text7 == "")
				{
					text7 = "0";
				}
				if (text8 == "")
				{
					text8 = "0";
				}
			}
			catch (Exception ex)
			{
				CommonCSharp.ExportError(null, ex.ToString());
			}
			return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}|{token}|{text9}|{text10}";
		}

		public static string GetInfoAccountFromUidUsingToken(string cookie, string token, string proxy, int typeProxy)
		{
			string text = "";
			bool flag = false;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			try
			{
				RequestXNet requestXNet = new RequestXNet(cookie, "", proxy, typeProxy);
				string json = requestXNet.RequestGet("https://graph.facebook.com/v2.11/me?fields=name,email,gender,birthday&access_token=" + token);
				JObject jObject = JObject.Parse(json);
				flag = true;
				text2 = jObject["name"]!.ToString();
				try
				{
					text3 = jObject["gender"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text4 = jObject["birthday"]!.ToString();
				}
				catch
				{
				}
				try
				{
					text6 = jObject["email"]!.ToString();
				}
				catch
				{
				}
			}
			catch
			{
			}
			return $"{flag}|{text2}|{text3}|{text4}|{text5}|{text6}|{text7}|{text8}";
		}

		private int HDChiaSeLivestream(int indexRow, string statusProxy, Device device, bool ckbChiaSeLenTuong, bool ckbChiaSeLenNhom, int nudCountGroupFrom, int nudCountGroupTo, int nudDelayFrom, int nudDelayTo, string txtLinkChiaSe, bool ckbVanBan, List<string> txtNoiDung, bool ckbTuongTacLivestream, int nudTimeFrom, int nudTimeTo, bool ckbInteract, string typeReaction, bool ckbComment, List<string> lstComment, bool ckbBinhLuanNhieuLan, int nudBinhLuanNhieuLanDelayFrom, int nudBinhLuanNhieuLanDelayTo, string tenHanhDong)
		{
			int num = 0;
			int num2 = 0;
			string html = "";
			int randomInt = device.GetRandomInt(nudCountGroupFrom, nudCountGroupTo);
			try
			{
				if (!device.CheckIsLive())
				{
					return -2;
				}
				device.LoadStatusLD("Open livestream");
				bool flag = false;
				while (true)
				{
					IL_0e2c:
					num2 = GoToLivestream(device, indexRow, statusProxy, txtLinkChiaSe);
					if (num2 == 0 || num2 == 3)
					{
						break;
					}
					if (num2 == 2)
					{
						continue;
					}
					if (ckbTuongTacLivestream && !flag)
					{
						flag = true;
						SetStatusAccount(indexRow, statusProxy + "Tương tác live...");
						List<string> list = CloneList(lstComment);
						string text = "";
						int randomInt2 = device.GetRandomInt(nudTimeFrom, nudTimeTo);
						int tickCount = Environment.TickCount;
						device.DelayTime(5.0);
						while (ckbInteract)
						{
							string text2 = "[165,445][195,470]";
							string text3 = "[35,445][65,470]";
							device.SwipeByBounds(text2, text3, 500);
							device.DelayRandom(1.0, 1.5);
							if (device.ClosePopup(ref html))
							{
								continue;
							}
							int typeReaction2 = Convert.ToInt32(typeReaction[device.GetRandomInt(0, typeReaction.Length - 1)].ToString());
							device.ClickReactions(typeReaction2);
							device.DelayRandom(1.0, 1.5);
							if (device.CheckExistImage("DataClick\\image\\youcantusereaction"))
							{
								device.TapByImageWait("DataClick\\image\\ok");
								device.DelayTime(1.0);
								if (device.CheckExistImage("DataClick\\image\\notnowthank"))
								{
									device.TapByImageWait("DataClick\\image\\notnowthank");
									device.DelayTime(1.0);
									GoToLivestream(device, indexRow, statusProxy, txtLinkChiaSe);
								}
							}
							device.SwipeByBounds(text3, text2, 500);
							device.DelayRandom(1.0, 1.5);
							break;
						}
						num2 = CheckStatusDevice(device, indexRow, statusProxy);
						if (num2 == 1)
						{
							continue;
						}
						if (num2 != 0)
						{
							break;
						}
						Bitmap bitmap = null;
						int num3 = 0;
						SetStatusAccount(indexRow, statusProxy + "Đang xem live...");
						while (Environment.TickCount - tickCount < randomInt2 * 1000 && device.CheckIsLive())
						{
							bitmap = device.ScreenShoot();
							if (device.CheckExistImage("DataClick\\image\\tryagain", bitmap))
							{
								device.DelayTime(2.0);
								device.TapByImage("DataClick\\image\\tryagain", bitmap);
							}
							switch (CheckStatusDevice(device, indexRow, statusProxy))
							{
							case 0:
								if (ckbComment && (num3 == 0 || ckbBinhLuanNhieuLan))
								{
									html = device.GetHtml();
									if (device.CheckExistText("write a comment…", html))
									{
										SetStatusAccount(indexRow, statusProxy + "Đang comment...");
										if (list.Count == 0)
										{
											list = MCommon.Common.CloneList(lstComment);
										}
										text = list[device.GetRandomInt(0, list.Count - 1)];
										list.Remove(text);
										text = MCommon.Common.SpinText(text, rd);
										List<string> listBoundsByText = device.GetListBoundsByText("write a comment…", html);
										if (device.TapByBounds(listBoundsByText[listBoundsByText.Count - 1]))
										{
											device.DelayRandom(1.0, 2.0);
											device.InputTextWithUnicode(text);
											device.DelayRandom(1.0, 2.0);
											if (device.TapByText("send"))
											{
												device.DelayRandom(3.0, 5.0);
												num3++;
												SetStatusAccount(indexRow, statusProxy + "Đang xem live...");
												device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
											}
										}
									}
									else
									{
										device.ClosePopup(ref html);
									}
								}
								else
								{
									int num4 = (Environment.TickCount - tickCount) / 1000;
									SetStatusAccount(indexRow, statusProxy + "Đang xem live, còn " + (randomInt2 - num4) + "s...");
									device.DelayTime(1.0);
								}
								continue;
							case 1:
								break;
							default:
								goto end_IL_0024;
							}
							goto IL_0e2c;
						}
						bitmap = device.ScreenShoot();
						if (device.CheckExistImage("DataClick\\image\\tryagain", bitmap))
						{
							device.DelayTime(2.0);
							device.TapByImage("DataClick\\image\\tryagain", bitmap);
						}
					}
					if (ckbChiaSeLenTuong)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Chia sẻ lên tường..."));
						bool flag2 = false;
						int num5 = 0;
						flag2 = false;
						num5 = 1;
						int num6 = 1;
						int num7 = 1;
						while (true)
						{
							IL_0911:
							for (int i = 0; i < 30; i++)
							{
								if (device.CheckExistImage("DataClick\\image\\theodoi"))
								{
									device.GotoBack();
								}
								if (!device.CheckExistImage("DataClick\\image\\chiase"))
								{
									device.SwipeByBounds("[35,445][65,470]", "[165,445][195,470]", 500);
									device.DelayTime(1.0);
									continue;
								}
								flag2 = true;
								break;
							}
							while (true)
							{
								if (flag2)
								{
									flag2 = false;
									num5++;
									switch (num5)
									{
									case 2:
										break;
									case 3:
										goto IL_07ee;
									case 4:
										goto IL_08a8;
									case 1:
										goto IL_0911;
									default:
										goto IL_0938;
									}
									for (int j = 0; j < 10; device.DelayTime(2.0), j++)
									{
										if (!device.TapByImage("DataClick\\image\\chiase"))
										{
											continue;
										}
										device.DelayTime(1.0);
										if (device.CheckExistImage("DataClick\\image\\chiase"))
										{
											switch (CheckStatusDevice(device, indexRow, statusProxy))
											{
											default:
												goto end_IL_0024;
											case 0:
												continue;
											case 1:
												break;
											}
											goto IL_0e2c;
										}
										if (!device.TapByImageWait("DataClick\\image\\vietbai"))
										{
											device.GotoBack();
											continue;
										}
										flag2 = true;
										break;
									}
									continue;
								}
								device.ExportError(null, "HDChiaSeLivestreamLenTuong: step " + num5);
								break;
								IL_08a8:
								if (device.TapByImageWait("DataClick\\image\\dang"))
								{
									flag2 = true;
									continue;
								}
								List<string> listBoundsByText2 = device.GetListBoundsByText("\"post\"");
								device.TapByBounds(listBoundsByText2[listBoundsByText2.Count - 1]);
								continue;
								IL_07ee:
								if (ckbVanBan && txtNoiDung.Count > 0)
								{
									for (int k = 0; k < 10; k++)
									{
										if (device.TapByImage("DataClick\\image\\banvietgidi") || device.TapByText("\"write something…\""))
										{
											device.InputTextWithUnicode(txtNoiDung[device.GetRandomInt(0, txtNoiDung.Count - 1)]);
											break;
										}
									}
								}
								flag2 = true;
							}
							break;
						}
					}
					goto IL_0938;
					IL_0938:
					if (!ckbChiaSeLenNhom)
					{
						break;
					}
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Chia sẻ lên nhóm..."));
					bool flag3 = false;
					int num8 = 0;
					flag3 = false;
					num8 = 1;
					int num9 = 1;
					int num10 = 1;
					while (true)
					{
						IL_0e13:
						for (int l = 0; l < 30; l++)
						{
							if (device.CheckExistImage("DataClick\\image\\theodoi"))
							{
								device.GotoBack();
							}
							if (!device.CheckExistImage("DataClick\\image\\chiase"))
							{
								device.SwipeByBounds("[35,445][65,470]", "[165,445][195,470]", 500);
								device.DelayTime(1.0);
								continue;
							}
							flag3 = true;
							break;
						}
						while (true)
						{
							if (flag3)
							{
								flag3 = false;
								num8++;
								switch (num8)
								{
								case 2:
									goto IL_0a57;
								case 3:
									goto IL_0b47;
								case 4:
									goto IL_0cb1;
								case 1:
									goto IL_0e13;
								}
							}
							else
							{
								device.ExportError(null, "HDChiaSeLivestreamLenNhom: step " + num8);
							}
							break;
							IL_0a57:
							for (int m = 0; m < 10; device.DelayTime(2.0), m++)
							{
								if (!device.TapByImage("DataClick\\image\\chiase"))
								{
									continue;
								}
								device.DelayTime(1.0);
								if (device.CheckExistImage("DataClick\\image\\chiase"))
								{
									switch (CheckStatusDevice(device, indexRow, statusProxy))
									{
									default:
										goto end_IL_0024;
									case 0:
										continue;
									case 1:
										break;
									}
									goto IL_0e2c;
								}
								if (!device.TapByImageWait("DataClick\\image\\chiaselennhom"))
								{
									device.GotoBack();
									continue;
								}
								flag3 = true;
								break;
							}
							continue;
							IL_0b47:
							if (ckbVanBan && txtNoiDung.Count > 0)
							{
								for (int n = 0; n < 10; n++)
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
											num8 = 0;
											break;
										case 1:
											device.TapByText("write a message…", html);
											device.InputTextWithUnicode(txtNoiDung[device.GetRandomInt(0, txtNoiDung.Count - 1)]);
											break;
										}
									}
									else
									{
										device.InputTextWithUnicode(txtNoiDung[device.GetRandomInt(0, txtNoiDung.Count - 1)]);
									}
									break;
								}
							}
							flag3 = true;
							continue;
							IL_0cb1:
							int num11 = 0;
							while (num < randomInt)
							{
								num11++;
								if (num11 % 4 == 0)
								{
									switch (CheckStatusDevice(device, indexRow, statusProxy))
									{
									case 0:
										break;
									case 1:
										goto IL_0e2c;
									default:
										goto end_IL_0024;
									}
								}
								if (!device.TapByImage("DataClick\\image\\chiasexanh"))
								{
									if (device.ScrollAndCheckScreenNotChange(rd.Next(1000, 1100), 1, "[115,429][210,460]", "[154,292][246,312]", "[10,289][305,466]"))
									{
										break;
									}
									continue;
								}
								num++;
								SetStatusAccount(indexRow, statusProxy + Language.GetValue($"Chia sẻ lên nhóm {num}/{randomInt}..."));
								if (num >= randomInt)
								{
									break;
								}
								device.DelayRandom(nudDelayFrom, nudDelayTo);
								if (device.CheckExistImage("DataClick\\image\\posted") || device.CheckExistText("posted"))
								{
									continue;
								}
								goto end_IL_0024;
							}
						}
						break;
					}
					break;
				}
				end_IL_0024:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		private int HDShareBai(int indexRow, string statusProxy, Device device, bool ckbChiaSeLenTuong, bool ckbChiaSeLenNhom, int nudCountGroupFrom, int nudCountGroupTo, bool ckbOnlyShareNhomKhongKiemDuyet, int nudDelayFrom, int nudDelayTo, string txtLinkChiaSe, bool ckbVanBan, List<string> txtNoiDung, string tenHanhDong)
		{
			int num = 0;
			string html = "";
			List<string> list = new List<string>();
			int randomInt = device.GetRandomInt(nudCountGroupFrom, nudCountGroupTo);
			try
			{
				if (!ckbChiaSeLenTuong)
				{
					goto IL_0335;
				}
				device.LoadStatusLD("Open post");
				while (true)
				{
					int num2 = GoToVideo(device, indexRow, statusProxy, txtLinkChiaSe);
					if (num2 == 0 || num2 == 3)
					{
						break;
					}
					if (num2 == 2)
					{
						continue;
					}
					bool flag = false;
					for (int i = 0; i < 5; i++)
					{
						string html2 = "";
						if (!device.TapByImage("DataClick\\image\\share") && !device.TapByText("\"share button", html2))
						{
							device.ClosePopup(ref html2);
							if (device.ScrollAndCheckScreenNotChange(device.GetRandomInt(1000, 2000)))
							{
								break;
							}
							device.DelayTime(1.0);
							continue;
						}
						flag = true;
						break;
					}
					if (!flag)
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
							if (ckbVanBan && txtNoiDung.Count > 0 && device.CheckExistText("write something…", html))
							{
								device.TapByText("write something…", html);
								device.InputTextWithUnicode(txtNoiDung[device.GetRandomInt(0, txtNoiDung.Count - 1)]);
								device.DelayRandom(1.5, 2.5);
							}
							device.TapByText("\"post", html);
						}
					}
					goto IL_0335;
				}
				goto end_IL_0024;
				IL_0335:
				if (ckbChiaSeLenNhom)
				{
					int num3 = 0;
					while (num3 < randomInt + 5 && num < randomInt)
					{
						SetStatusAccount(indexRow, statusProxy + "Share groups...", device);
						while (true)
						{
							IL_0829:
							device.LoadStatusLD("Open post");
							int num4 = GoToVideo(device, indexRow, statusProxy, txtLinkChiaSe);
							if (num4 == 0 || num4 == 3)
							{
								break;
							}
							if (num4 == 2)
							{
								continue;
							}
							device.LoadStatusLD("Loading");
							bool flag2 = false;
							int num5 = 0;
							while (true)
							{
								if (num5 < 10)
								{
									if (!device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
									{
										if (!(device.GetActivity() != "com.facebook.katana/com.facebook.deeplinking.activity.StoryDeepLinkLoadingActivity"))
										{
											if (!device.CheckExistText("\"can't post"))
											{
												switch (CheckStatusDevice(device, indexRow, statusProxy))
												{
												case 0:
													goto IL_043d;
												case 1:
													break;
												default:
													goto end_IL_0024;
												}
												break;
											}
										}
										else
										{
											flag2 = true;
										}
									}
									else
									{
										flag2 = true;
									}
								}
								if (flag2)
								{
									device.LoadStatusLD("Find share");
									bool flag3 = false;
									int num6 = 0;
									while (true)
									{
										if (num6 >= 5)
										{
											goto IL_05f3;
										}
										if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
										{
											if (!device.TapByImage("DataClick\\image\\share"))
											{
												if (!device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
												{
													device.DelayTime(1.0);
													goto IL_05c9;
												}
											}
											else
											{
												flag3 = true;
											}
											goto IL_05f3;
										}
										num4 = CheckStatusDevice(device, indexRow, statusProxy);
										if (num4 == 1)
										{
											break;
										}
										if (num4 == 0)
										{
											string html3 = "";
											if (!device.TapByImage("DataClick\\image\\share") && !device.TapByText("\"share button", html3))
											{
												device.ClosePopup(html3);
												if (!device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
												{
													device.DelayTime(1.0);
													goto IL_05c9;
												}
											}
											else
											{
												flag3 = true;
											}
											goto IL_05f3;
										}
										goto end_IL_0024;
										IL_05c9:
										num6++;
										continue;
										IL_05f3:
										if (flag3)
										{
											goto IL_0601;
										}
										goto IL_0c22;
									}
									break;
								}
								goto IL_0c2c;
								IL_0c2c:
								num3++;
								goto IL_0c36;
								IL_043d:
								device.DelayTime(2.0);
								num5++;
								continue;
								IL_0c22:
								if (num > 0)
								{
									goto IL_0c2c;
								}
								goto end_IL_0024;
								IL_0601:
								device.LoadStatusLD("Find share group");
								for (int j = 0; j < 2; j++)
								{
									if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
									{
										bool flag4 = false;
										int num7 = 0;
										while (num7 < 5)
										{
											if (device.TapByImageWait("DataClick\\image\\sharegroup", 3))
											{
												flag4 = true;
												break;
											}
											if (!(device.GetActivity() == "Application"))
											{
												device.DelayTime(1.0);
												num7++;
												continue;
											}
											goto end_IL_0024;
										}
										if (flag4)
										{
											break;
										}
										if (j == 0)
										{
											string bounds = "[220,415][260,455]";
											string bounds2 = "[35,415][65,455]";
											device.SwipeByBounds(bounds, bounds2);
										}
										else if (num <= 0)
										{
											break;
										}
										continue;
									}
									bool flag5 = false;
									for (int k = 0; k < 5; device.DelayTime(1.0), k++)
									{
										html = "";
										if (device.TapByImageWait("DataClick\\image\\sharegroup", 3) || device.TapByText("share to a group", html))
										{
											flag5 = true;
											break;
										}
										if (!(device.GetActivity() == "Application"))
										{
											switch (CheckStatusDevice(device, indexRow, statusProxy))
											{
											case 0:
												continue;
											case 1:
												break;
											default:
												goto end_IL_0024;
											}
											goto IL_0829;
										}
										goto end_IL_0024;
									}
									if (flag5)
									{
										break;
									}
									if (j == 0)
									{
										string bounds3 = "[220,415][260,455]";
										string bounds4 = "[35,415][65,455]";
										device.SwipeByBounds(bounds3, bounds4);
									}
									else if (num <= 0)
									{
										break;
									}
								}
								bool flag6 = false;
								for (int l = 0; l < 10; l++)
								{
									if (!(device.GetActivity() == "com.facebook.katana/com.facebook.composer.groups.selector.GroupSelectorActivity"))
									{
										device.DelayTime(1.0);
										continue;
									}
									device.DelayTime(1.0);
									for (int m = 0; m < 10; m++)
									{
										if (!device.CheckExistXpath("//*[@class='android.widget.progressbar']"))
										{
											break;
										}
										device.DelayTime(1.0);
									}
									flag6 = true;
									break;
								}
								if (!flag6)
								{
									goto IL_0c2c;
								}
								string text = "";
								for (int n = 0; n < 5; n++)
								{
									html = device.GetHtml();
									List<string> listText = device.GetListText(html, 2);
									listText.Remove("back");
									if (listText.Count != 0)
									{
										text = (from x in listText.Except(list)
											orderby Guid.NewGuid()
											select x).FirstOrDefault();
										if (!string.IsNullOrEmpty(text))
										{
											break;
										}
										device.ScrollAndCheckScreenNotChange(device.GetRandomInt(400, 500));
									}
								}
								if (!string.IsNullOrEmpty(text))
								{
									if (!device.TapByText("content-desc=\"" + text, html))
									{
										goto IL_0c2c;
									}
									list.Add(text);
									device.DelayTime(1.0);
									string text2 = "";
									for (int num8 = 0; num8 < 10; num8++)
									{
										html = device.GetHtml();
										text2 = device.GetBoundsByText("\"post", html);
										if (text2 == "")
										{
											text2 = device.GetBoundsByImage("DataClick\\image\\dang");
										}
										if (text2 != "")
										{
											break;
										}
										device.DelayTime(1.0);
									}
									if (!(text2 != ""))
									{
										goto IL_0c2c;
									}
									if (ckbVanBan && txtNoiDung.Count > 0 && (device.TapByImage("DataClick\\image\\banvietgidi") || device.TapByText("\"write something…\"", html)))
									{
										string text3 = txtNoiDung.OrderBy((string t) => Guid.NewGuid()).First();
										text3 = MCommon.Common.SpinText(text3, rd);
										text3 = GetIconFacebook.ProcessString(text3, rd);
										device.InputTextWithUnicode(text3);
										device.DelayTime(1.0);
									}
									if (!device.TapByBounds(text2))
									{
										goto IL_0c2c;
									}
									num++;
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" share post ({num}/{randomInt})...");
									device.LoadStatusLD("Posted");
									device.DelayRandom(nudDelayFrom, nudDelayTo);
									if (!device.CheckExistImage("DataClick\\image\\cantpost"))
									{
										goto IL_0c2c;
									}
								}
								goto end_IL_0024;
							}
						}
						break;
						IL_0c36:;
					}
				}
				end_IL_0024:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDRoiNhom(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, int typeRoiNhom, bool ckbDieuKienThanhVien, int nudThanhVienToiDa, bool ckbDieuKienTuKhoa, List<string> lstTuKhoa, List<string> lstIDNhomGiuLai, string proxy, int typeProxy, string tenHanhDong)
		{
			int num = 0;
			int num2 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
			try
			{
				string cookie = device.GetTokenCookie().Split('|')[1];
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang quét nhóm..."));
				List<string> list = GetListIdGroupForLeave(cookie, "", proxy, typeProxy, typeRoiNhom, ckbDieuKienThanhVien, nudThanhVienToiDa, ckbDieuKienTuKhoa, lstTuKhoa);
				if (lstIDNhomGiuLai.Count > 0)
				{
					list = list.Except(lstIDNhomGiuLai).ToList();
				}
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
				string text = "";
				while (num < num2)
				{
					while (list.Count != 0)
					{
						text = list[rd.Next(0, list.Count)];
						list.Remove(text);
						bool flag = false;
						int num3 = 0;
						num3 = 1;
						int num4 = 1;
						int num5 = 1;
						while (true)
						{
							IL_024f:
							device.GotoGroupQuick(text);
							device.DelayRandom(1.0, 2.0);
							switch (CheckStatusDevice(device, indexRow, statusProxy))
							{
							case 0:
								flag = device.TapByText("member tools", "", 5) || device.TapByBounds("[279,19][320,58]");
								while (flag)
								{
									num3++;
									switch (num3)
									{
									case 2:
										flag = device.TapByText("\"leave group\"", "", 5);
										continue;
									case 3:
										flag = device.TapByText("\"leave group\"", "", 5);
										continue;
									case 4:
										flag = device.WaitForTextAppear(10.0, "\"close\"");
										device.TapByText("\"close\"");
										continue;
									case 1:
										break;
									default:
										num++;
										SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
										if (num < num2)
										{
											goto IL_02f1;
										}
										goto end_IL_0023;
									}
									goto IL_024f;
								}
								device.ExportError(null, "HDRoiNhom: step " + num3);
								goto IL_0333;
							case 1:
								break;
							default:
								goto end_IL_0023;
								IL_02f1:
								device.DelayRandom(nudDelayFrom, nudDelayTo);
								goto IL_0304;
							}
						}
						IL_0304:;
					}
					break;
					IL_0333:;
				}
				end_IL_0023:;
			}
			catch
			{
			}
			return num;
		}

		private List<string> GetGroupKhongKiemDuyet(List<string> lstGroup, string cookie, string useragent, string proxy, int typeProxy)
		{
			List<string> lstOutput = new List<string>();
			try
			{
				int iThread = 0;
				int num = ((lstGroup.Count < 100) ? lstGroup.Count : 100);
				int num2 = 0;
				while (num2 < lstGroup.Count)
				{
					if (iThread < num)
					{
						Interlocked.Increment(ref iThread);
						int row = num2++;
						new Thread((ThreadStart)delegate
						{
							try
							{
								string text = lstGroup[row].Split('|')[0];
								RequestXNet requestXNet = new RequestXNet(cookie, useragent, proxy, typeProxy);
								string text2 = requestXNet.RequestGet("https://m.facebook.com/groups/" + text + "/madminpanel");
								if (!text2.Contains("madminpanel/pending/"))
								{
									lock (lstOutput)
									{
										lstOutput.Add(text);
									}
								}
							}
							catch
							{
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
				while (iThread > 0)
				{
					Application.DoEvents();
					Thread.Sleep(1000);
				}
			}
			catch
			{
			}
			return lstOutput;
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

		private int HDDangXuatThietBiCu(int indexRow, string statusProxy, Device device, string tenHanhDong)
		{
			bool flag = false;
			string html = "";
			int num = 0;
			try
			{
				device.GotoNewFeedQuick();
				num++;
				if ((flag = device.TapByImage("DataClick\\image\\menu", null, 10)) && (flag = device.WaitForLoaded(10)))
				{
					flag = false;
					num++;
					for (int i = 0; i < 10; i++)
					{
						html = device.GetHtml();
						if (!device.CheckExistText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", html))
						{
							if (!device.CheckExistText("settings &amp; privacy, header. section is expanded. double-tap to collapse the section.", html))
							{
								if (device.ScrollAndCheckScreenNotChange(500))
								{
									break;
								}
								device.DelayTime(1.0);
								continue;
							}
							flag = true;
							break;
						}
						device.TapByText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", html);
						device.DelayTime(2.0);
						flag = true;
						break;
					}
					if (flag)
					{
						flag = false;
						num++;
						for (int j = 0; j < 10; j++)
						{
							if (!device.TapByImageWait("DataClick\\image\\caidat"))
							{
								if (j % 2 == 1 && device.ScrollAndCheckScreenNotChange())
								{
									break;
								}
								device.DelayTime(1.0);
								continue;
							}
							flag = true;
							break;
						}
						if (flag)
						{
							flag = false;
							for (int k = 0; k < 10; k++)
							{
								html = device.GetHtml();
								if (!device.TapByText("password and security", html) && !device.TapByText("security and login", html))
								{
									if (device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							if (flag)
							{
								num++;
								flag = false;
								for (int l = 0; l < 10; l++)
								{
									html = device.GetHtml();
									if (!device.CheckExistText("where you're logged in", html))
									{
										device.DelayTime(1.0);
										continue;
									}
									if (device.CheckExistText("see all", html))
									{
										device.TapByText("see all", html);
										flag = true;
									}
									break;
								}
								if (flag)
								{
									num++;
									flag = false;
									for (int m = 0; m < 10; m++)
									{
										html = device.GetHtml();
										if (device.CheckExistText("where you're logged in", html))
										{
											if (device.CheckExistText("log out of all sessions", html))
											{
												flag = true;
												break;
											}
											for (int n = 0; n < 50; n++)
											{
												if (device.ScrollAndCheckScreenNotChange(200))
												{
													break;
												}
											}
										}
										else if (device.CheckExistText("log out of all sessions", html))
										{
											flag = true;
											break;
										}
										device.DelayTime(1.0);
									}
									if (flag)
									{
										num++;
										if ((flag = device.TapByText("log out of all sessions", html, 10)) && device.TapByText("\"log out\"", "", 10))
										{
											device.DelayTime(2.0);
											device.WaitForLoaded(10);
										}
									}
								}
							}
						}
					}
				}
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

		private List<string> GetListIdGroupForLeave(string cookie, string useragent, string proxy, int typeProxy, int typeRoiNhom, bool ckbDieuKienThanhVien, int nudThanhVienToiDa, bool ckbDieuKienTuKhoa, List<string> lstTuKhoa)
		{
			List<string> list = new List<string>();
			try
			{
				if (typeRoiNhom == 2)
				{
					lstTuKhoa = lstTuKhoa.ConvertAll((string d) => d.ToLower());
				}
				RequestXNet requestXNet = new RequestXNet(cookie, "", proxy, typeProxy);
				string input = requestXNet.RequestGet("https://mobile.facebook.com/help/");
				string value = Regex.Match(input, MCommon.Common.Base64Decode("ImR0c2dfYWciOnsidG9rZW4iOiIoLio/KSI=")).Groups[1].Value;
				string value2 = Regex.Match(cookie + ";", "c_user=(.*?);").Groups[1].Value;
				string url = "https://www.facebook.com/ajax/typeahead/first_degree.php?fb_dtsg_ag=" + value + "&filter%5B0%5D=group&viewer=" + value2 + "&__user=" + value2 + "&__a=1&__dyn=&__comet_req=0&jazoest=26581";
				input = requestXNet.RequestGet(url).Replace("for (;;);", "");
				JObject jObject = JObject.Parse(input);
				foreach (JToken item2 in (IEnumerable<JToken>)(jObject["payload"]!["entries"]!))
				{
					try
					{
						if (typeRoiNhom == 0 || typeRoiNhom == 1)
						{
							list.Add(item2["uid"]!.ToString());
						}
						else if (typeRoiNhom == 2)
						{
							string item = item2["uid"]!.ToString();
							string s = item2["text"]!.ToString();
							string value3 = item2["size"]!.ToString();
							if ((ckbDieuKienThanhVien && Convert.ToInt32(value3) < nudThanhVienToiDa) || (ckbDieuKienTuKhoa && CheckStringIsExistInList(s, lstTuKhoa)))
							{
								list.Add(item);
							}
						}
					}
					catch
					{
					}
				}
				if (typeRoiNhom == 1)
				{
					list = GetGroupKhongKiemDuyet(list, cookie, useragent, proxy, typeProxy);
				}
			}
			catch
			{
			}
			return list;
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

		public int HDThamGiaNhomTuKhoa(int indexRow, string statusProxy, Device device, List<string> lstTuKhoa, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, bool ckbTuDongTraLoiCauHoi, List<string> lstCauTraLoi, string tenHanhDong)
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
					while (device.GotoSearch(text, "groups"))
					{
						List<string> list = new List<string>();
						for (int i = 0; i < num2 + 10; i++)
						{
							string text2;
							switch (CheckStatusDevice(device, indexRow, statusProxy))
							{
							case 0:
							{
								list = device.GetListBoundsByImage("DataClick\\image\\join", null, 3);
								if (list.Count != 0 && (list.Count != 1 || device.CheckBoundsContainBounds("[0,95][320,480]", list[0])))
								{
									goto IL_01dd;
								}
								for (int j = 0; j < 10; j++)
								{
									if (device.ScrollAndCheckScreenNotChange(device.GetRandomInt(400, 500)))
									{
										break;
									}
									list = device.GetListBoundsByImage("DataClick\\image\\join", null, 3);
									if (list.Count > 0)
									{
										break;
									}
								}
								if (list.Count != 0 && (list.Count != 1 || device.CheckBoundsContainBounds("[0,95][320,480]", list[0])))
								{
									goto IL_01dd;
								}
								goto end_IL_0006;
							}
							case 1:
								break;
							default:
								goto end_IL_0006;
								IL_01dd:
								text2 = list[device.GetRandomInt(0, list.Count - 1)];
								list.Remove(text2);
								if (text2 != "" && device.CheckBoundsContainBounds("[0,95][320,480]", text2) && device.TapByBounds(text2))
								{
									if (device.CheckExistText("your membership is pending approval.", "", 3.0))
									{
										if (ckbTuDongTraLoiCauHoi)
										{
											AnswerQuestionWhenJoinGroup(device, lstCauTraLoi);
										}
										else
										{
											if (!device.TapByText("\"back\""))
											{
												device.GotoBack();
											}
											if (device.CheckExistText("exit without answering", "", 5.0))
											{
												device.TapByText("\"exit\"");
												device.DelayRandom(1.0, 1.5);
											}
										}
									}
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
							goto IL_038a;
						}
						break;
						IL_038a:;
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

		private int CheckGoToProfileUidSuccess(Device device, int indexRow, string statusProxy)
		{
			int result = 0;
			string text = "";
			int num = 0;
			int num2 = 5;
			for (int i = 0; i < 60; device.DelayTime(1.0), i++)
			{
				text = device.GetHtml();
				if (device.GetListText(text).Count == 1)
				{
					device.TapByText(device.GetListText(text)[0], text);
					continue;
				}
				if (!device.CheckExistText("profile picture", text))
				{
					if (device.CheckExistImage("DataClick\\image\\reloadpage") && !device.CheckExistText("session expired", text))
					{
						num++;
						if (num >= num2)
						{
							break;
						}
						device.TapByImageWait("DataClick\\image\\reloadpage");
						continue;
					}
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 0:
						continue;
					default:
						result = 3;
						break;
					case 1:
						result = 2;
						break;
					}
					break;
				}
				result = 1;
				break;
			}
			return result;
		}

		private int CheckGoToIDSuccess(Device device, int indexRow, string statusProxy)
		{
			int result = 0;
			string text = "";
			int num = 0;
			int num2 = 5;
			for (int i = 0; i < 60; device.DelayTime(1.0), i++)
			{
				text = device.GetHtml();
				if (device.GetListText(text).Count == 1)
				{
					device.TapByText(device.GetListText(text)[0], text);
					continue;
				}
				if (device.CheckExistTexts(text, 0.0, "profile picture", "page cover photo", "cover photo of group", "community") <= 0)
				{
					if (device.CheckExistImage("DataClick\\image\\reloadpage"))
					{
						num++;
						if (num >= num2)
						{
							break;
						}
						device.TapByImageWait("DataClick\\image\\reloadpage");
						continue;
					}
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 0:
						continue;
					default:
						result = 3;
						break;
					case 1:
						result = 2;
						break;
					}
					break;
				}
				result = 1;
				break;
			}
			return result;
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
									device.ClosePopup(ref text);
								}
							}
						}
						num = CheckStatusDevice(device, indexRow, statusProxy);
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
			if (device.OpenLink(linkVideo, 3))
			{
				for (int i = 0; i < 10; i++)
				{
					if (!device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
					{
						if (!device.CheckExistImage("DataClick\\image\\share"))
						{
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
							num = CheckStatusDevice(device, indexRow, statusProxy, isAllowClickImageX: false);
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
					result = 1;
					break;
				}
			}
			return result;
		}

		public int HDDangBaiTuong(int indexRow, string statusProxy, Device device, int soLuongFrom, int soLuongTo, int khoangCachFrom, int khoangCachTo, bool isVanBan, bool isUseBackground, bool isAnh, string pathFolderAnh, bool isXoaNguyenLieuDaDung, string tenHanhDong, string idHanhDong)
		{
			int num = 0;
			try
			{
				if (dicHDDangBaiTuong_NoiDung[idHanhDong].Count != 0)
				{
					List<string> list = new List<string>();
					if (!isXoaNguyenLieuDaDung)
					{
						list = MCommon.Common.CloneList(dicHDDangBaiTuong_NoiDung[idHanhDong]);
					}
					int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
					string text = "";
					for (int i = 0; i < num2 + 5; i++)
					{
						if (num >= num2)
						{
							break;
						}
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num + 1}/{num2})...");
						try
						{
							bool flag = false;
							int num3 = 0;
							num3 = 1;
							int num4 = 1;
							int num5 = 1;
							while (true)
							{
								IL_0806:
								device.GotoNewFeedQuick();
								for (int j = 0; j < 50; j++)
								{
									if (device.ScrollAndCheckScreenNotChange(200, -1))
									{
										break;
									}
								}
								for (int k = 0; k < 10; k++)
								{
									if (!device.TapByImage("DataClick\\image\\bandangnghigi") && !device.CheckExistText("\"post\""))
									{
										if (device.ScrollAndCheckScreenNotChange(device.GetRandomInt(220, 300)))
										{
											break;
										}
										device.DelayTime(1.0);
										continue;
									}
									flag = true;
									break;
								}
								while (true)
								{
									if (flag)
									{
										num3++;
										string item;
										List<string> listBoundsByText;
										switch (num3)
										{
										default:
											goto end_IL_00e1;
										case 2:
										{
											for (int m = 0; m < 5; m++)
											{
												text = device.GetHtml();
												if (device.GetListText(text).Count == 1)
												{
													device.TapByText(device.GetListText(text)[0], text);
													device.DelayTime(2.0);
													text = device.GetHtml();
												}
												if (device.CheckExistText("what's on your mind?", text) || device.CheckExistText("\"post\"", text) || device.CheckExistText("post audience", text))
												{
													flag = true;
													break;
												}
											}
											continue;
										}
										case 3:
											text = device.GetHtml();
											if ((device.CheckExistText("choose privacy public", text) || !device.TapByText("choose privacy", text)) && !device.CheckExistText("post audience", text))
											{
												continue;
											}
											if (device.TapByText("\"public\"", "", 5))
											{
												text = device.GetHtml();
												string text2 = device.CheckExistTextsV2(text, 0.0, "\"done\"", "\"save\"");
												if (text2 != "")
												{
													device.TapByText(text2, text);
												}
												else
												{
													device.TapByText("\"back\"");
												}
											}
											else
											{
												device.TapByText("\"back\"");
											}
											continue;
										case 4:
											if (!isVanBan)
											{
												continue;
											}
											device.ClearText("what's on your mind?");
											if (device.TapByText("what's on your mind?", "", 10))
											{
												item = "";
												if (!isXoaNguyenLieuDaDung)
												{
													if (list.Count == 0)
													{
														list = MCommon.Common.CloneList(dicHDDangBaiTuong_NoiDung[idHanhDong]);
													}
													item = list.OrderBy((string t) => Guid.NewGuid()).FirstOrDefault();
													list.Remove(item);
													goto IL_059a;
												}
												lock (dicHDDangBaiTuong_NoiDung)
												{
													if (dicHDDangBaiTuong_NoiDung[idHanhDong].Count != 0)
													{
														int index = rd.Next(0, dicHDDangBaiTuong_NoiDung[idHanhDong].Count);
														item = dicHDDangBaiTuong_NoiDung[idHanhDong][index];
														dicHDDangBaiTuong_NoiDung[idHanhDong].RemoveAt(index);
														goto IL_059a;
													}
												}
												return num;
											}
											flag = false;
											continue;
										case 5:
										{
											if (!device.TapByText("\"post\"", "", 10))
											{
												continue;
											}
											device.DelayRandom(3.0, 5.0);
											for (int l = 0; l < 60; l++)
											{
												if (device.CheckExistImage("DataClick\\image\\posting"))
												{
													device.DelayTime(1.0);
													continue;
												}
												num++;
												if (num < num2)
												{
													device.LoadStatusLD("Delay");
													device.DelayRandom(khoangCachFrom, khoangCachTo);
												}
												break;
											}
											continue;
										}
										case 1:
											break;
											IL_059a:
											item = MCommon.Common.SpinText(item, rd);
											item = GetIconFacebook.ProcessString(item, rd);
											if (!(item.Trim() != ""))
											{
												continue;
											}
											device.DelayRandom(1.0, 1.5);
											device.InputTextWithUnicode(item);
											device.DelayRandom(1.0, 1.5);
											if (!isUseBackground || !device.TapByText("show all background options"))
											{
												continue;
											}
											device.DelayRandom(2.0, 3.0);
											device.ScrollAndCheckScreenNotChange(rd.Next(200, 400), 1, "[115,429][210,460]", "[154,292][246,312]", "[110,333][159,374]");
											text = device.GetHtml();
											listBoundsByText = device.GetListBoundsByText(", background", text);
											if (listBoundsByText.Count > 2)
											{
												device.TapByBounds(listBoundsByText.OrderBy((string t) => Guid.NewGuid()).First());
												device.DelayRandom(1.0, 1.5);
											}
											device.TapByText("minimize background options", text);
											continue;
										}
										goto IL_0806;
									}
									device.ExportError(null, "HDDangStatus: stt" + num3);
									break;
								}
								break;
							}
							end_IL_00e1:;
						}
						catch
						{
						}
					}
				}
			}
			catch
			{
			}
			return num;
		}

		public int HDDangBaiNhom(int indexRow, string statusProxy, Device device, int soLuongFrom, int soLuongTo, int khoangCachFrom, int khoangCachTo, bool isDangNhomKKD, bool isVanBan, bool isUseBackground, bool isAnh, string pathFolderAnh, bool isXoaNguyenLieuDaDung, string tenHanhDong, string idHanhDong, string proxy, int typeProxy)
		{
			int num = 0;
			try
			{
				if (dicHDDangBaiNhom_NoiDung[idHanhDong].Count != 0)
				{
					List<string> list = new List<string>();
					if (!isXoaNguyenLieuDaDung)
					{
						list = MCommon.Common.CloneList(dicHDDangBaiNhom_NoiDung[idHanhDong]);
					}
					List<string> list2 = new List<string>();
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + " que\u0301t danh sa\u0301ch nho\u0301m...");
					device.LoadStatusLD("Get list group");
					string cookie = device.GetTokenCookie().Split('|')[1];
					list2 = GetListIdGroupForLeave(cookie, "", proxy, typeProxy, isDangNhomKKD ? 1 : 0, ckbDieuKienThanhVien: false, 0, ckbDieuKienTuKhoa: false, null);
					if (list2.Count != 0)
					{
						int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
						string text = "";
						string text2 = "";
						for (int i = 0; i < num2 + 5 && num < num2 && list2.Count != 0; i++)
						{
							text2 = list2[0];
							list2.Remove(text2);
							SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num + 1}/{num2})...");
							try
							{
								bool flag = false;
								int num3 = 0;
								num3 = 1;
								int num4 = 1;
								int num5 = 1;
								while (true)
								{
									IL_095f:
									device.GotoGroupQuick(text2);
									device.DelayTime(2.0);
									device.Scroll(500, -1);
									device.DelayTime(1.0);
									text = device.GetHtml();
									if (device.GetListText(text).Count == 1)
									{
										device.TapByText(device.GetListText(text)[0], text);
										device.DelayTime(2.0);
									}
									switch (CheckStatusDevice(device, indexRow, statusProxy))
									{
									case 0:
									{
										for (int j = 0; j < 10; j++)
										{
											if (device.TapByImage("DataClick\\image\\createpostgroup"))
											{
												break;
											}
											text = device.GetHtml();
											if (device.GetListText(text).Count == 1)
											{
												device.TapByText(device.GetListText(text)[0], text);
												device.DelayTime(2.0);
												text = device.GetHtml();
											}
											if (!device.TapByText("discussion\"", text))
											{
												if (device.CheckExistTexts(text, 0.0, "create a public post", "submit a public post", "create a post") > 0)
												{
													string text3 = device.CheckExistTextsV2(text, 0.0, "create a public post", "submit a public post", "create a post");
													device.TapByText(text3, text);
													flag = true;
													break;
												}
												if (device.CheckExistText("what's on your mind?", text))
												{
													flag = true;
													break;
												}
												device.DelayTime(1.0);
											}
										}
										flag = true;
										while (flag)
										{
											num3++;
											string item;
											List<string> listBoundsByText;
											switch (num3)
											{
											case 2:
											{
												for (int k = 0; k < 5; k++)
												{
													text = device.GetHtml();
													if (device.GetListText(text).Count == 1)
													{
														device.TapByText(device.GetListText(text)[0], text);
														device.DelayTime(2.0);
														text = device.GetHtml();
													}
													if (device.CheckExistText("group rules", text))
													{
														device.GotoBack();
														continue;
													}
													if (!device.CheckExistText("\"post\"", text))
													{
														device.DelayTime(1.0);
														continue;
													}
													flag = true;
													break;
												}
												continue;
											}
											case 3:
											{
												if (!isVanBan)
												{
													continue;
												}
												string text4 = device.CheckExistTextsV2("", 10.0, "what's on your mind?", "create a public post", "submit a public post", "create a post");
												if (text4 != "")
												{
													device.TapByText(text4);
													item = "";
													if (!isXoaNguyenLieuDaDung)
													{
														if (list.Count == 0)
														{
															list = MCommon.Common.CloneList(dicHDDangBaiNhom_NoiDung[idHanhDong]);
														}
														item = list.OrderBy((string t) => Guid.NewGuid()).FirstOrDefault();
														list.Remove(item);
														goto IL_06a8;
													}
													lock (dicHDDangBaiNhom_NoiDung)
													{
														if (dicHDDangBaiNhom_NoiDung[idHanhDong].Count == 0)
														{
															goto end_IL_013d;
														}
														int index = rd.Next(0, dicHDDangBaiNhom_NoiDung[idHanhDong].Count);
														item = dicHDDangBaiNhom_NoiDung[idHanhDong][index];
														dicHDDangBaiNhom_NoiDung[idHanhDong].RemoveAt(index);
														goto IL_06a8;
													}
												}
												flag = false;
												continue;
											}
											case 4:
											{
												if (!device.TapByText("\"post\"", "", 10))
												{
													continue;
												}
												device.DelayRandom(3.0, 5.0);
												int num6 = 0;
												while (num6 < 60)
												{
													if (device.CheckExistImage("DataClick\\image\\posting"))
													{
														device.DelayTime(1.0);
														num6++;
														continue;
													}
													num++;
													if (num < num2)
													{
														device.LoadStatusLD("Delay");
														device.DelayRandom(khoangCachFrom, khoangCachTo);
														break;
													}
													goto end_IL_01c1;
												}
												continue;
											}
											case 1:
												break;
											default:
												goto IL_09de;
												IL_06a8:
												item = MCommon.Common.SpinText(item, rd);
												item = GetIconFacebook.ProcessString(item, rd);
												if (!(item.Trim() != ""))
												{
													continue;
												}
												device.DelayRandom(1.0, 1.5);
												device.InputTextWithUnicode(item);
												device.DelayRandom(1.0, 1.5);
												if (!isUseBackground || !device.TapByText("show all background options"))
												{
													continue;
												}
												device.DelayRandom(2.0, 3.0);
												device.ScrollAndCheckScreenNotChange(rd.Next(200, 400), 1, "[115,429][210,460]", "[154,292][246,312]", "[110,333][159,374]");
												text = device.GetHtml();
												listBoundsByText = device.GetListBoundsByText(", background", text);
												if (listBoundsByText.Count > 2)
												{
													device.TapByBounds(listBoundsByText.OrderBy((string t) => Guid.NewGuid()).First());
													device.DelayRandom(1.0, 1.5);
												}
												device.TapByText("minimize background options", text);
												continue;
											}
											goto IL_095f;
										}
										goto IL_09de;
									}
									case 1:
										break;
									default:
										goto end_IL_01c1;
									}
								}
								end_IL_01c1:;
							}
							catch
							{
								continue;
							}
							break;
							continue;
							end_IL_013d:
							break;
							IL_09de:;
						}
					}
				}
			}
			catch
			{
			}
			return num;
		}

		public int HDHuyKetBan(int indexRow, string statusProxy, Device device, string token, string cookie, int typeHuyKetBan, int nudSoLuongFrom, int nudSoLuongTo, List<string> lstUidNhap, int nudDelayFrom, int nudDelayTo, List<string> lstUidKhongHuyKetBan, string proxy, int typeProxy, string tenHanhDong)
		{
			int num = 0;
			try
			{
				int num2 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
				if (num2 > 0)
				{
					if (!(cookie == "") && !(token == "") && CommonRequest.CheckLiveToken(cookie, token, "", proxy, typeProxy))
					{
						goto IL_0121;
					}
					token = device.GetTokenCookie().Split('|')[0];
					cookie = device.GetTokenCookie().Split('|')[1];
					if (!(token == "") && CommonRequest.CheckLiveToken(cookie, token, "", proxy, typeProxy))
					{
						goto IL_0121;
					}
				}
				goto end_IL_0006;
				IL_0121:
				List<string> list = GetIdFriend(token, cookie, "", proxy, typeProxy);
				if (typeHuyKetBan == 1)
				{
					list = MCommon.Common.GetIntersectItemBetweenTwoList(list, lstUidNhap);
				}
				if (lstUidKhongHuyKetBan.Count > 0)
				{
					list = MCommon.Common.GetExceptItemBetweenTwoList(list, lstUidKhongHuyKetBan);
				}
				if (list.Count == 0)
				{
					return num;
				}
				if (typeHuyKetBan == 1)
				{
					num2 = list.Count;
				}
				string text = "";
				while (list.Count > 0)
				{
					text = list[rd.Next(0, list.Count)];
					list.Remove(text);
					while (true)
					{
						device.GotoProfileQuick(text);
						device.DelayTime(2.0);
						int num3 = CheckGoToProfileUidSuccess(device, indexRow, statusProxy);
						if (num3 == 0)
						{
							break;
						}
						if (num3 == 2)
						{
							continue;
						}
						if (num3 != 3)
						{
							while (true)
							{
								if (!device.TapByImage("DataClick\\image\\daketban", null, 3))
								{
									if (!device.TapByText("\"more\""))
									{
										break;
									}
									continue;
								}
								device.DelayRandom(1.0, 1.5);
								if (!device.TapByText("unfriend", "", 3))
								{
									break;
								}
								device.DelayRandom(1.0, 1.5);
								if (!device.TapByText("confirm", "", 3))
								{
									break;
								}
								num++;
								SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
								if (num < num2)
								{
									device.DelayRandom(nudDelayFrom, nudDelayTo);
									break;
								}
								goto end_IL_0006;
							}
							break;
						}
						goto end_IL_0006;
					}
				}
				end_IL_0006:;
			}
			catch
			{
			}
			return num;
		}

		public int HDThamGiaNhomGoiY(int indexRow, string statusProxy, Device device, int countGroupFrom, int countGroupTo, int delayFrom, int delayTo, bool isTraLoiCauHoi, List<string> lstCauTraLoi, string tenHanhDong)
		{
			return 0;
		}

		public int HDHuyKetBan(int indexRow, string statusProxy, Chrome chrome, string token, string cookie, int typeHuyKetBan, int nudSoLuongFrom, int nudSoLuongTo, List<string> lstUidNhap, int nudDelayFrom, int nudDelayTo, List<string> lstUidKhongHuyKetBan, string proxy, int typeProxy, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
			string useragent = chrome.GetUseragent().Split('$')[0];
			cookie = chrome.GetCookieFromChrome();
			if (token == "" || !CommonRequest.CheckLiveToken(cookie, token, useragent, proxy, typeProxy))
			{
				token = CommonChrome.GetTokenEAAAAZ(chrome);
			}
			List<string> list = GetIdFriend(token, cookie, useragent, proxy, typeProxy);
			if (typeHuyKetBan == 1)
			{
				list = MCommon.Common.GetIntersectItemBetweenTwoList(list, lstUidNhap);
			}
			if (lstUidKhongHuyKetBan.Count > 0)
			{
				list = MCommon.Common.GetExceptItemBetweenTwoList(list, lstUidKhongHuyKetBan);
			}
			if (typeHuyKetBan == 1)
			{
				num2 = list.Count;
			}
			if (num2 > 0)
			{
				string text = "";
				try
				{
					if (list.Count == 0)
					{
						return num;
					}
					while (list.Count != 0)
					{
						text = list[rd.Next(0, list.Count)];
						list.Remove(text);
						int num3;
						do
						{
							chrome.GotoURL("https://m.facebook.com/removefriend.php?friend_id=" + text + "&unref=bd_profile_button");
							DelayThaoTacNho();
							num3 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						}
						while (num3 == 1);
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num3))
						{
							if (chrome.CheckExistElement("[name=\"confirm\"]", 10.0) == 1)
							{
								DelayThaoTacNho();
								chrome.Click(2, "confirm");
								num++;
								SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
								if (num >= num2)
								{
									break;
								}
								chrome.DelayTime(rd.Next(nudDelayFrom, nudDelayTo + 1));
							}
							continue;
						}
						return -1;
					}
				}
				catch
				{
				}
			}
			return num;
		}

		public int HDHuyLoiMoiKetBan(int indexRow, string statusProxy, Chrome chrome, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = rd.Next(nudDelayFrom, nudDelayTo + 1);
			int num3 = 0;
			int num4 = 0;
			try
			{
				int num5;
				do
				{
					chrome.GotoURL("https://m.facebook.com/friends/center/requests/outgoing/");
					DelayThaoTacNho();
					num5 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
				}
				while (num5 == 1);
				if (new List<int> { -3, -2, -1, 2 }.Contains(num5))
				{
					return -1;
				}
				if (chrome.CheckExistElement("[data-sigil=\"context-layer-root content-pane\"]", 10.0) == 1)
				{
					if (Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"undoable-action\"]').length").ToString()) == 0)
					{
						return num;
					}
					while (num < num2)
					{
						if (!chrome.CheckChromeClosed())
						{
							if (chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"undoable-action\"]')[" + num4 + "].getAttribute('data-sigil')").ToString() != null)
							{
								DelayThaoTacNho();
								chrome.ScrollSmooth("document.querySelectorAll('[data-sigil=\"touchable check m-cancel-request\"]')[" + num4 + "]");
								DelayThaoTacNho();
								chrome.Click(4, "[data-sigil=\"touchable check m-cancel-request\"]", num4);
								num++;
								num4++;
								SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
								chrome.DelayTime(rd.Next(nudDelayFrom, nudDelayTo + 1));
								continue;
							}
							break;
						}
						return -2;
					}
				}
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

		public int HDXemWatch(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, int nudTimeWatchFrom, int nudTimeWatchTo, bool ckbInteract, int nudCountLikeFrom, int nudCountLikeTo, bool ckbShareWall, int nudCountShareFrom, int nudCountShareTo, bool ckbComment, List<string> txtComment, int nudCountCommentFrom, int nudCountCommentTo, int nudPercentLike, int nudPercentShare, int nudPercentComment, string tenHanhDong)
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
				int num9 = 0;
				while (true)
				{
					IL_014f:
					if (num9 < 10)
					{
						while (true)
						{
							device.GotoWatchQuick();
							if (device.CheckExistText("more options", "", 5.0))
							{
								break;
							}
							if (!device.CheckExistImage("DataClick\\image\\tryagain"))
							{
								if (!device.ClosePopup())
								{
									switch (CheckStatusDevice(device, indexRow, statusProxy))
									{
									case 1:
										continue;
									case 0:
										break;
									default:
										goto end_IL_0097;
									}
								}
							}
							else
							{
								device.TapByImageWait("DataClick\\image\\tryagain");
							}
							num9++;
							goto IL_014f;
						}
					}
					while (num < num5)
					{
						device.ClosePopup();
						if (device.ScrollAndCheckScreenNotChange(500, 1, "[97,401][179,413]", "[180,88][254,100]", "[99,416][169,456]"))
						{
							break;
						}
						num++;
						device.DelayRandom(nudTimeWatchFrom, nudTimeWatchTo);
						if (ckbInteract && num6 < num2 && MCommon.Common.CheckWithPercent(nudPercentLike))
						{
							text = device.GetHtml();
							string text2 = device.GetListBoundsByText("\"like\"", text).LastOrDefault();
							if (!string.IsNullOrEmpty(text2))
							{
								device.TapLongByBounds(text2);
								device.ClickReactions(6);
								num6++;
							}
						}
						if (ckbComment && num7 < num3 && MCommon.Common.CheckWithPercent(nudPercentComment))
						{
							text = device.GetHtml();
							string text3 = device.GetListBoundsByText("\"comment\"", text).LastOrDefault();
							if (!string.IsNullOrEmpty(text3))
							{
								string text4 = txtComment[device.GetRandomInt(0, txtComment.Count - 1)];
								text4 = MCommon.Common.SpinText(text4, rd);
								text4 = GetIconFacebook.ProcessString(text4, rd);
								device.TapByBounds(text3);
								device.DelayRandom(2.0, 3.0);
								device.ClosePopup();
								device.GetHtml();
								int num10 = device.CheckExistTexts(text, 3.0, "\"comment…\"", "write a comment…\"");
								if (num10 == 1)
								{
									device.TapByText("\"comment…\"", text);
								}
								if (!device.TapByTextWithPopupAppear(10, "write a comment…\"", Device.GetListTextClosePopup().ToArray()))
								{
									break;
								}
								device.InputTextWithUnicode(text4);
								device.TapByText("\"send\"", "", 3);
								device.DelayRandom(2.0, 2.5);
								device.GotoBack(2);
								device.DelayRandom(1.0, 1.5);
								num7++;
							}
						}
						if (ckbShareWall && num8 < num4 && MCommon.Common.CheckWithPercent(nudPercentShare))
						{
							text = device.GetHtml();
							if (device.CheckExistText("share", text))
							{
								List<string> listBoundsByText = device.GetListBoundsByText("share", text);
								string bounds = listBoundsByText[listBoundsByText.Count - 1];
								device.TapByBounds(bounds);
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

		public int HDXemWatchTheoTuKhoa(int indexRow, string statusProxy, Device device, List<string> txtTuKhoa, int nudSoLuongFrom, int nudSoLuongTo, int nudTimeWatchFrom, int nudTimeWatchTo, bool ckbInteract, int nudCountLikeFrom, int nudCountLikeTo, bool ckbShareWall, int nudCountShareFrom, int nudCountShareTo, bool ckbComment, List<string> txtComment, int nudCountCommentFrom, int nudCountCommentTo, string tenHanhDong)
		{
			int num = 0;
			int num2 = rd.Next(nudCountLikeFrom, nudCountLikeTo + 1);
			int num3 = rd.Next(nudCountCommentFrom, nudCountCommentTo + 1);
			int num4 = rd.Next(nudCountShareFrom, nudCountShareTo + 1);
			int num5 = rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			try
			{
				string text = "";
				int num9 = 0;
				while (true)
				{
					IL_014c:
					if (num9 < 10)
					{
						while (true)
						{
							device.GotoWatchQuick();
							if (device.CheckExistText("more options", "", 5.0))
							{
								break;
							}
							if (!device.CheckExistImage("DataClick\\image\\tryagain"))
							{
								if (!device.ClosePopup())
								{
									switch (CheckStatusDevice(device, indexRow, statusProxy))
									{
									case 1:
										continue;
									case 0:
										break;
									default:
										goto end_IL_0090;
									}
								}
							}
							else
							{
								device.TapByImageWait("DataClick\\image\\tryagain");
							}
							num9++;
							goto IL_014c;
						}
					}
					string value = txtTuKhoa.OrderBy((string t) => Guid.NewGuid()).FirstOrDefault();
					if (string.IsNullOrEmpty(value))
					{
						break;
					}
					bool flag = false;
					int num10 = 0;
					do
					{
						num10++;
						flag = false;
						switch (num10)
						{
						case 2:
							flag = device.TapByText("\"search   watch\"", "", 10);
							continue;
						case 3:
							device.InputTextWithUnicode(value);
							device.DelayTime(1.0);
							device.InputKey(Device.KeyEvent.KEYCODE_ENTER);
							flag = true;
							continue;
						case 4:
						{
							for (int i = 0; i < 10; i++)
							{
								if (!device.TapByText("\"video\""))
								{
									if (device.ScrollAndCheckScreenNotChange(500))
									{
										break;
									}
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							continue;
						}
						case 1:
							flag = device.TapByText("\"search", "", 10);
							continue;
						default:
							flag = true;
							break;
						}
						break;
					}
					while (flag);
					if (!flag)
					{
						break;
					}
					bool flag2 = device.CheckExistTexts("", 10.0, "write a comment…", "more videos") == 1;
					while (num < num5)
					{
						text = device.GetHtml();
						device.ClosePopup(text);
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num5})...");
						if (!flag2)
						{
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
									int num11 = device.CheckExistTexts(text, 3.0, "\"comment…\"", "write a comment…\"");
									if (num11 == 1)
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
							if (device.ScrollAndCheckScreenNotChange(500, 1, "[97,401][179,413]", "[180,88][254,100]", "[99,416][169,456]"))
							{
								break;
							}
							continue;
						}
						num++;
						device.DelayRandom(nudTimeWatchFrom, nudTimeWatchTo);
						text = device.GetHtml();
						if (ckbInteract && rd.Next(2) == 0 && num6 < num2 && device.TapByText("like", text))
						{
							num6++;
						}
						if (ckbComment && rd.Next(2) == 0 && num7 < num3 && device.TapByText("write a comment…", text))
						{
							device.DelayTime(1.0);
							string text3 = txtComment[device.GetRandomInt(0, txtComment.Count - 1)];
							text3 = MCommon.Common.SpinText(text3, rd);
							device.InputTextWithUnicode(text3);
							device.DelayTime(1.0);
							device.TapByText("\"send\"", "", 3);
							device.DelayRandom(1.0, 1.5);
							num7++;
						}
						if (ckbShareWall && rd.Next(2) == 0 && num8 < num4)
						{
							bool flag3 = false;
							int num12 = 0;
							do
							{
								num12++;
								flag3 = false;
								switch (num12)
								{
								case 2:
									flag3 = device.TapByText("\"write post\"", "", 5);
									continue;
								case 3:
									flag3 = device.TapByXpath("//*[@class='android.widget.button']", "", 5);
									continue;
								case 1:
									flag3 = device.TapByText("\"share\"", text);
									continue;
								default:
									flag3 = true;
									break;
								}
								break;
							}
							while (flag3);
							if (flag3)
							{
								device.DelayRandom(2.0, 2.5);
								num8++;
							}
						}
						device.GotoBack();
						if (!device.ScrollAndCheckScreenNotChange(300, 1, "[100,391][219,423]", "[181,195][286,226]", "[99,416][169,456]"))
						{
							device.DelayTime(1.0);
							if (!device.TapByText("\"video\""))
							{
								break;
							}
							continue;
						}
						break;
					}
					break;
				}
				end_IL_0090:;
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
				List<string> list = new List<string>();
				while (num < num2)
				{
					int num3 = 0;
					while (true)
					{
						if (num3 < 10)
						{
							string html = device.GetHtml();
							list = device.GetListBoundsByText(text2);
							if (list.Count <= 0)
							{
								if (device.CheckExistText("no notifications", html))
								{
									break;
								}
								while (true)
								{
									device.GotoNotificationQuick();
									device.DelayTime(3.0);
									if (!device.ClosePopup())
									{
										switch (CheckStatusDevice(device, indexRow, statusProxy))
										{
										case 1:
											continue;
										case 0:
											break;
										default:
											goto end_IL_001e;
										}
									}
									num3++;
									break;
								}
								continue;
							}
							if (list.Count <= 4)
							{
								num2 = list.Count;
							}
						}
						while (true)
						{
							if (list.Count == 0)
							{
								if (device.ScrollAndCheckScreenNotChange(150))
								{
									break;
								}
								list = device.GetListBoundsByText(text2);
								if (list.Count == 0)
								{
									break;
								}
							}
							text = list[device.GetRandomInt(0, list.Count - 1)];
							list.Remove(text);
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
							SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...", device);
							device.GotoBack();
							device.DelayRandom(1.0, 2.0);
							goto IL_0327;
						}
						break;
					}
					break;
					IL_0327:;
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
				device.LoadStatusLD("Open video");
				while (true)
				{
					int num = GoToVideo(device, indexRow, statusProxy, txtLinkVideo);
					if (num == 0 || num == 3)
					{
						break;
					}
					if (num == 2)
					{
						continue;
					}
					if (device.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity"))
					{
						device.LoadStatusLD("Interact");
						if (ckbInteract)
						{
							for (int i = 0; i < 3; i++)
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
								string text2 = listBoundsByImage.FirstOrDefault();
								if (!string.IsNullOrEmpty(text2))
								{
									SetStatusAccount(indexRow, statusProxy + "Đang thả cảm xúc video...");
									if (device.TapLongByBounds(text2, "[0,100][320,480]"))
									{
										device.DelayRandom(1.0, 1.5);
										int typeReaction2 = Convert.ToInt32(typeReaction[rd.Next(0, typeReaction.Length)].ToString() ?? "");
										device.ClickReactions(typeReaction2);
										device.DelayRandom(1.0, 2.0);
									}
								}
								break;
							}
						}
						device.LoadStatusLD("Watch Video");
						int num2 = 0;
						int tickCount = Environment.TickCount;
						SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
						while (Environment.TickCount - tickCount < randomInt * 1000 && device.CheckIsLive())
						{
							if (ckbComment && (num2 == 0 || ckbBinhLuanNhieuLan))
							{
								string boundsByImage = device.GetBoundsByImage("DataClick\\image\\comment");
								if (string.IsNullOrEmpty(boundsByImage))
								{
									continue;
								}
								device.LoadStatusLD("Comment");
								SetStatusAccount(indexRow, statusProxy + "Đang comment...");
								if (list.Count == 0)
								{
									list = MCommon.Common.CloneList(lstComment);
								}
								text = list[device.GetRandomInt(0, list.Count - 1)];
								list.Remove(text);
								text = MCommon.Common.SpinText(text, rd);
								text = GetIconFacebook.ProcessString(text, rd);
								if (device.TapByBounds(boundsByImage, "[0,100][320,480]"))
								{
									device.DelayRandom(1.0, 2.0);
									device.InputTextWithUnicode(text);
									device.DelayRandom(1.0, 2.0);
									if (device.TapByText("send"))
									{
										device.DelayRandom(3.0, 5.0);
									}
									device.GotoBack(2, 0.3);
									num2++;
									SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
									device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
								}
							}
							else
							{
								int num3 = (Environment.TickCount - tickCount) / 1000;
								SetStatusAccount(indexRow, statusProxy + "Đang xem video, còn " + (randomInt - num3) + "s...", device);
								device.DelayTime(1.0);
							}
						}
						break;
					}
					device.LoadStatusLD("Interact");
					if (ckbInteract)
					{
						for (int j = 0; j < 3; j++)
						{
							List<string> list2 = device.GetListBoundsByText("double tap and hold to");
							if (list2.Count == 0)
							{
								list2 = device.GetListBoundsByImage("DataClick\\image\\like");
							}
							if (list2.Count <= 0)
							{
								if (device.ScrollAndCheckScreenNotChange(1000, 1, "[97,401][179,413]", "[180,88][254,100]"))
								{
									break;
								}
								continue;
							}
							string text3 = list2.FirstOrDefault();
							if (!string.IsNullOrEmpty(text3))
							{
								SetStatusAccount(indexRow, statusProxy + "Đang thả cảm xúc video...");
								if (device.TapLongByBounds(text3, "[0,100][320,480]"))
								{
									device.DelayRandom(1.0, 1.5);
									int typeReaction3 = Convert.ToInt32(typeReaction[rd.Next(0, typeReaction.Length)].ToString() ?? "");
									device.ClickReactions(typeReaction3);
									device.DelayRandom(1.0, 2.0);
								}
							}
							break;
						}
					}
					device.LoadStatusLD("Watch Video");
					int num4 = 0;
					int tickCount2 = Environment.TickCount;
					SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
					while (Environment.TickCount - tickCount2 < randomInt * 1000 && device.CheckIsLive())
					{
						if (ckbComment && (num4 == 0 || ckbBinhLuanNhieuLan))
						{
							string html = device.GetHtml();
							num = device.CheckExistTexts(html, 0.0, "write a comment…", "comment button");
							string text4 = "";
							switch (num)
							{
							case 1:
								text4 = device.GetBoundsByText("write a comment…", html);
								break;
							case 2:
								text4 = device.GetListBoundsByText("comment button").LastOrDefault();
								break;
							default:
								text4 = device.GetBoundsByImage("DataClick\\image\\comment");
								if (!string.IsNullOrEmpty(text4))
								{
									num = 2;
								}
								break;
							}
							if (string.IsNullOrEmpty(text4))
							{
								continue;
							}
							device.LoadStatusLD("Comment");
							SetStatusAccount(indexRow, statusProxy + "Đang comment...");
							if (list.Count == 0)
							{
								list = MCommon.Common.CloneList(lstComment);
							}
							text = list[device.GetRandomInt(0, list.Count - 1)];
							list.Remove(text);
							text = MCommon.Common.SpinText(text, rd);
							text = GetIconFacebook.ProcessString(text, rd);
							switch (num)
							{
							case 1:
							{
								Bitmap bitmap = device.Crop(device.ScreenShoot(), "[44,72][153,96]");
								if (!device.TapByBounds(text4))
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
								for (int k = 0; k < 5; k++)
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
								num4++;
								SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
								device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
								break;
							}
							case 2:
								if (device.TapByBounds(text4, "[0,100][320,480]"))
								{
									device.DelayRandom(1.0, 2.0);
									device.InputTextWithUnicode(text);
									device.DelayRandom(1.0, 2.0);
									if (device.TapByText("send"))
									{
										device.DelayRandom(3.0, 5.0);
									}
									device.GotoBack(2, 0.3);
									num4++;
									SetStatusAccount(indexRow, statusProxy + "Đang xem video...");
									device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
								}
								break;
							}
						}
						else
						{
							int num5 = (Environment.TickCount - tickCount2) / 1000;
							SetStatusAccount(indexRow, statusProxy + "Đang xem video, còn " + (randomInt - num5) + "s...", device);
							device.DelayTime(1.0);
						}
					}
					break;
				}
			}
			catch
			{
			}
			SetStatusAccount(indexRow, statusProxy + "Xem video xong...");
			return randomInt;
		}

		public int HDTuongTacLivestream(int indexRow, string statusProxy, Device device, string txtLinkVideo, int nudTimeFrom, int nudTimeTo, bool ckbInteract, string typeReaction, bool ckbComment, List<string> lstComment, bool ckbBinhLuanNhieuLan, int nudBinhLuanNhieuLanDelayFrom, int nudBinhLuanNhieuLanDelayTo, string tenHanhDong)
		{
			List<string> list = CloneList(lstComment);
			string text = "";
			int randomInt = device.GetRandomInt(nudTimeFrom, nudTimeTo);
			try
			{
				while (true)
				{
					int num = GoToLivestream(device, indexRow, statusProxy, txtLinkVideo);
					if (num == 0 || num == 3)
					{
						break;
					}
					if (num == 2)
					{
						continue;
					}
					int tickCount = Environment.TickCount;
					device.DelayTime(2.0);
					while (ckbInteract)
					{
						string text2 = "[165,445][195,470]";
						string text3 = "[35,445][65,470]";
						device.SwipeByBounds(text2, text3, 500);
						device.DelayRandom(1.0, 1.5);
						string html = "";
						if (device.ClosePopup(ref html))
						{
							continue;
						}
						int typeReaction2 = Convert.ToInt32(typeReaction[device.GetRandomInt(0, typeReaction.Length - 1)].ToString());
						device.ClickReactions(typeReaction2);
						device.DelayRandom(1.0, 1.5);
						if (device.CheckExistImage("DataClick\\image\\youcantusereaction"))
						{
							device.TapByImageWait("DataClick\\image\\ok");
							device.DelayTime(1.0);
							if (device.CheckExistImage("DataClick\\image\\notnowthank"))
							{
								device.TapByImageWait("DataClick\\image\\notnowthank");
								device.DelayTime(1.0);
								GoToLivestream(device, indexRow, statusProxy, txtLinkVideo);
							}
						}
						device.SwipeByBounds(text3, text2, 500);
						device.DelayRandom(1.0, 1.5);
						break;
					}
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						break;
					default:
						goto end_IL_0026;
					case 0:
					{
						int num2 = 0;
						SetStatusAccount(indexRow, statusProxy + "Đang xem live...");
						while (Environment.TickCount - tickCount < randomInt * 1000 && device.CheckIsLive())
						{
							if (ckbComment && (num2 == 0 || ckbBinhLuanNhieuLan))
							{
								string html2 = device.GetHtml();
								if (device.CheckExistText("write a comment…", html2))
								{
									SetStatusAccount(indexRow, statusProxy + "Đang comment...");
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
										num2++;
										SetStatusAccount(indexRow, statusProxy + "Đang xem live...");
										device.DelayRandom(nudBinhLuanNhieuLanDelayFrom, nudBinhLuanNhieuLanDelayTo);
									}
								}
								else
								{
									device.ClosePopup(ref html2);
								}
							}
							else
							{
								int num3 = (Environment.TickCount - tickCount) / 1000;
								SetStatusAccount(indexRow, statusProxy + "Đang xem live, còn " + (randomInt - num3) + "s...");
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
			SetStatusAccount(indexRow, statusProxy + "Xem Live xong...");
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
								for (int i = 0; i < num2 + 10; i++)
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
											device.ClosePopup(ref html);
											if (device.CheckExistText("confirm request", html))
											{
												device.TapByText("confirm request", html);
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
									goto IL_0262;
								}
							}
							goto end_IL_0006;
						}
						case 1:
							break;
						default:
							goto end_IL_0006;
						}
						IL_0262:;
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
							for (int i = 0; i < num2 + 10; i++)
							{
								string text2;
								switch (CheckStatusDevice(device, indexRow, statusProxy))
								{
								case 0:
								{
									if (listBoundsByImage.Count != 0)
									{
										goto IL_01a3;
									}
									for (int j = 0; j < 10; j++)
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
										goto IL_01a3;
									}
									goto end_IL_0006;
								}
								case 1:
									break;
								default:
									goto end_IL_0006;
									IL_01a3:
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
								goto IL_026d;
							}
							goto end_IL_0006;
						}
						case 1:
							break;
						default:
							goto end_IL_0006;
						}
						IL_026d:;
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
						IL_0203:
						device.GotoFriendSuggest();
						device.DelayRandom(1.0, 2.0);
						switch (CheckStatusDevice(device, indexRow, statusProxy))
						{
						case 0:
						{
							List<string> listBoundsByText = device.GetListBoundsByText("as a friend\"");
							if (listBoundsByText.Count != 0)
							{
								for (int i = 0; i < num2 + 10; i++)
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
										goto end_IL_0006;
									}
									case 1:
										break;
									default:
										goto end_IL_0006;
									}
									goto IL_0203;
								}
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

		public int HDBackupData(string id, int indexRow, string statusProxy, Chrome chrome, string token, bool isNgaySinh, bool isAnh, bool isBackupNangCao, int soLuongAnh, bool isNhanTin, bool isBinhLuan, int numberMonth, bool isCreateHtml, string proxy, int typeProxy, string tenHanhDong = "")
		{
			GetCellAccount(indexRow, "cUid");
			GetCellAccount(indexRow, "cPassword");
			GetCellAccount(indexRow, "cFa2");
			int result = 0;
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				string template_backup = Base.template_backup;
				string useragent = chrome.GetUseragent().Split('$')[0];
				string cookie = chrome.GetCookieFromChrome();
				if (token == "" || !CommonRequest.CheckLiveToken(cookie, token, useragent, proxy, typeProxy))
				{
					token = CommonChrome.GetTokenEAAAAZ(chrome);
				}
				string text = chrome.ExecuteScript("return (document.cookie+';').match(new RegExp('c_user=(.*?);'))[1]").ToString();
				MCommon.Common.CreateFolder("backup\\" + text);
				bool flag = false;
				if (token != "")
				{
					string text2 = "";
					string text3 = "";
					if (isNgaySinh)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang backup ngày sinh..."));
						string birthday = CommonChrome.GetBirthday(chrome, token);
						if (birthday == "")
						{
							DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", "Token die!");
							flag = true;
						}
						else
						{
							text2 = birthday.Split('|')[1];
							text3 = birthday.Split('|')[2];
							lock (_lockbackup)
							{
								File.WriteAllText("backup\\" + text + "\\ngaysinh.txt", birthday);
							}
						}
					}
					if (!flag && isAnh)
					{
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
								DatagridviewHelper.SetStatusDataGridView(dtgvAcc, indexRow, "cStatus", string.Format(Language.GetValue("Đang backup ảnh: {0}/{1}..."), countSuccess, totalFriend));
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
										string text5 = lstQuery[stt];
										List<string> list = CommonRequest.BackupImageOne(text5, cookie, token, useragent, proxy, typeProxy, soLuongAnh, isBackupNangCao);
										if (list.Count > 0)
										{
											lock (listImageBackup)
											{
												listImageBackup.AddRange(list);
											}
										}
										lock (_lock_countSuccess)
										{
											countSuccess += text5.Split(',').Length;
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
									Directory.CreateDirectory("backup\\" + text);
									File.WriteAllLines("backup\\" + text + "\\" + text + ".txt", listImageBackup);
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
					}
					if (!flag && isNhanTin)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang backup nhắn tin..."));
						List<string> myListUidMessage = CommonChrome.GetMyListUidMessage(chrome);
						lock (_lock4)
						{
							File.WriteAllLines("backup\\" + text + "\\banbeinbox.txt", myListUidMessage);
						}
					}
					if (!flag && isBinhLuan)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang backup bình luận..."));
						List<string> myListComments = CommonChrome.GetMyListComments(chrome, numberMonth);
						lock (_lock3)
						{
							File.WriteAllLines("backup\\" + text + "\\lscomment.txt", myListComments);
						}
					}
					if (!flag && isCreateHtml)
					{
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang tạo File html..."));
						CreateHTML(text, template_backup);
					}
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đã backup xong!"));
					if (!flag)
					{
						string text4 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
						CommonSQL.UpdateMultiFieldToAccount(id, "uid|token|name|birthday|backup|info", text + "|" + token + "|" + text3 + "|" + text2 + "|" + text4 + "|Live", isAllowEmptyValue: false);
						SetCellAccount(indexRow, "cUid", text);
						SetCellAccount(indexRow, "cToken", token);
						SetCellAccount(indexRow, "cName", text3, isAllowEmptyValue: false);
						SetCellAccount(indexRow, "cBirthday", text2);
						SetCellAccount(indexRow, "cInfo", "Live");
						SetCellAccount(indexRow, "cBackup", text4);
					}
				}
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		private void ShowTrangThai(string content)
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

		private void HideTrangThai()
		{
			plTrangThai.Invoke((MethodInvoker)delegate
			{
				if (plTrangThai.Visible)
				{
					plTrangThai.Visible = false;
				}
			});
		}

		public int HDTuongTacNewsfeed(int indexRow, string statusProxy, Device device, int timeFrom, int timeTo, bool isLike, int countLikeFrom, int countLikeTo, bool isComment, int countCommentFrom, int countCommentTo, List<string> lstComment, bool isShareWall, int countShareFrom, int countShareTo, string tenHanhDong)
		{
			int result = 0;
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
						goto end_IL_0006;
					case 0:
						InteractTimelime(indexRow, statusProxy, device, timeFrom, timeTo, isLike, countLikeFrom, countLikeTo, isComment, countCommentFrom, countCommentTo, lstComment, isShareWall, countShareFrom, countShareTo);
						goto end_IL_0006;
					}
				}
				end_IL_0006:;
			}
			catch (Exception ex)
			{
				device.ExportError(ex, "HDTuongTacNewsfeed");
				result = -1;
			}
			return result;
		}

		public int InteractTimelime(int indexRow, string statusProxy, Device device, int timeFrom, int timeTo, bool isLike, int countLikeFrom, int countLikeTo, bool isComment, int countCommentFrom, int countCommentTo, List<string> lstComment, bool isShareWall, int countShareFrom, int countShareTo)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			if (isLike)
			{
				num4 = device.GetRandomInt(countLikeFrom, countLikeTo);
			}
			lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
			List<string> list = MCommon.Common.CloneList(lstComment);
			string text = "";
			if (isComment)
			{
				num5 = device.GetRandomInt(countCommentFrom, countCommentTo);
			}
			if (isShareWall)
			{
				num6 = device.GetRandomInt(countShareFrom, countShareTo);
			}
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			int randomInt = device.GetRandomInt(timeFrom, timeTo);
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < randomInt * 1000)
			{
				int num7 = CheckStatusDevice(device, indexRow, statusProxy);
				if (num7 == 1)
				{
					device.GotoNewFeedQuick();
				}
				else if (num7 != 0)
				{
					break;
				}
				string html = device.GetHtml();
				list2 = device.GetListBoundsByText("like button. double tap and hold to react", html);
				if (list2.Count > 0 && isLike && num < num4 && device.GetRandomInt(1, 100) % 2 == 0)
				{
					string text2 = list2[list2.Count - 1];
					if (text2 != "" && device.TapLongByBounds(text2, "[0,100][320,480]"))
					{
						device.DelayRandom(1.0, 1.5);
						device.ClickReactions(6);
						num++;
						device.DelayRandom(1.0, 2.0);
						html = device.GetHtml();
					}
				}
				list3 = device.GetListBoundsByText("comment button", html);
				if (list3.Count > 0 && isComment && num2 < num5 && device.GetRandomInt(1, 100) % 2 == 0)
				{
					string text3 = list3[list3.Count - 1];
					if (text3 != "")
					{
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
							num2++;
							device.DelayRandom(1.0, 2.0);
							html = device.GetHtml();
						}
					}
				}
				list4 = device.GetListBoundsByText("share button", html);
				if (list4.Count > 0 && isShareWall && num3 < num6 && device.GetRandomInt(1, 100) % 2 == 0)
				{
					string text4 = list4[list4.Count - 1];
					if (text4 != "" && device.TapByBounds(text4, "[0,100][320,480]"))
					{
						device.DelayRandom(1.5, 2.0);
						device.TapByText("share now");
						device.DelayRandom(2.0, 3.0);
						num3++;
					}
				}
				if (device.ScrollAndCheckScreenNotChange(500, 1, "[97,401][179,413]", "[180,88][254,100]"))
				{
					break;
				}
				device.DelayRandom(1.5, 3.0);
			}
			return 0;
		}

		public int HDTuongTacBaiVietChiDinh(int indexRow, string statusProxy, Device device, string linkBaiViet, int timeFrom, int timeTo, bool isLike, string typeReaction, bool isComment, List<string> lstComment, bool ckbTuDongXoaNoiDung, bool isSendAnh, string pathFolderImage, string tenHanhDong, string idHanhDong)
		{
			int result = 1;
			string text = "";
			int num = 0;
			bool flag = false;
			try
			{
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Va\u0300o link..."));
				device.LoadStatusLD("Open link");
				while (device.OpenLink(linkBaiViet))
				{
					device.DelayTime(2.0);
					device.Scroll(500, -1);
					device.DelayTime(1.0);
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						break;
					default:
						goto end_IL_0018;
					case 0:
					{
						num++;
						flag = false;
						for (int i = 0; i < 10; i++)
						{
							text = device.GetHtml();
							if (!device.CheckExistText("post menu"))
							{
								device.DelayTime(1.0);
								continue;
							}
							flag = true;
							break;
						}
						if (flag)
						{
							SetStatusAccount(indexRow, statusProxy + Language.GetValue("Xem ba\u0300i viê\u0301t..."));
							device.LoadStatusLD("View post");
							device.DelayRandom(timeFrom, timeTo);
							num++;
							flag = false;
							for (int j = 0; j < 10; j++)
							{
								if (!device.CheckExistText("double tap and hold to"))
								{
									device.ScrollAndCheckScreenNotChange();
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							if (flag)
							{
								if (isLike)
								{
									num++;
									List<string> listBoundsByText = device.GetListBoundsByText("double tap and hold to");
									if (listBoundsByText.Count > 0)
									{
										string text2 = listBoundsByText[0];
										if (text2 != "")
										{
											SetStatusAccount(indexRow, statusProxy + Language.GetValue("Tương ta\u0301c ba\u0300i viê\u0301t..."));
											device.LoadStatusLD("Interact Post");
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
								if (isComment)
								{
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Comment ba\u0300i viê\u0301t..."));
									device.LoadStatusLD("Comment Post");
									num++;
									flag = false;
									for (int k = 0; k < 10; k++)
									{
										text = device.GetHtml();
										if (!device.TapByText("write a", text))
										{
											device.TapByText("comment", text);
											device.DelayTime(1.0);
											continue;
										}
										flag = true;
										break;
									}
									if (flag)
									{
										device.DelayTime(1.0);
										string text3 = "";
										if (dicHDTuongTacBaiVietChiDinhComment[idHanhDong].Count != 0)
										{
											if (!ckbTuDongXoaNoiDung)
											{
												text3 = dicHDTuongTacBaiVietChiDinhComment[idHanhDong][rd.Next(0, dicHDTuongTacBaiVietChiDinhComment[idHanhDong].Count)];
											}
											else
											{
												lock (dicHDTuongTacBaiVietChiDinhComment)
												{
													int index = rd.Next(0, dicHDTuongTacBaiVietChiDinhComment[idHanhDong].Count);
													text3 = dicHDTuongTacBaiVietChiDinhComment[idHanhDong][index];
													dicHDTuongTacBaiVietChiDinhComment[idHanhDong].RemoveAt(index);
												}
											}
											text3 = MCommon.Common.SpinText(text3, rd);
											text3 = GetIconFacebook.ProcessString(text3, rd);
											device.InputTextWithUnicode(text3);
											device.DelayTime(2.0);
											num++;
											if (flag = device.TapByText("send", "", 10))
											{
												device.DelayRandom(2.0, 5.0);
											}
										}
									}
								}
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
				result = 0;
			}
			return result;
		}

		public int HDBuffFollowCaNhan(int indexRow, string statusProxy, Chrome chrome, int delayFrom, int delayTo, List<string> lstId, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				int count = lstId.Count;
				for (int i = 0; i < count; i++)
				{
					int num2;
					do
					{
						chrome.GotoURL("https://m.facebook.com/" + lstId[i]);
						DelayThaoTacNho(2);
						num2 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
					}
					while (num2 == 1);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num2))
					{
						string cssSelector = chrome.GetCssSelector("a", "href", "subscriptions/add");
						if (cssSelector != "")
						{
							if (chrome.Click(4, cssSelector) != 1)
							{
								chrome.GotoURL("https://m.facebook.com/" + chrome.GetAttributeValue(cssSelector, "href"));
							}
						}
						else if (chrome.CheckExistElement("#pages_follow_action_id") == 1)
						{
							chrome.ScrollSmooth("document.querySelector('#pages_follow_action_id')");
							DelayThaoTacNho();
							chrome.Click(1, "pages_follow_action_id");
						}
						num++;
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{count})...");
						chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
						continue;
					}
					return -1;
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDBuffFollowLikePage(int indexRow, string statusProxy, Chrome chrome, int delayFrom, int delayTo, List<string> lstId, bool isLike, bool isFollow, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			try
			{
				if (chrome.CheckChromeClosed())
				{
					return -2;
				}
				int count = lstId.Count;
				string text = "";
				string text2 = "";
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					flag = false;
					int num2;
					do
					{
						chrome.GotoURL("https://m.facebook.com/" + lstId[i]);
						DelayThaoTacNho();
						num2 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
					}
					while (num2 == 1);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num2))
					{
						if (isLike)
						{
							text = chrome.GetURL();
							if (chrome.CheckExistElement("#msite-pages-header-contents", 10.0) == 1)
							{
								chrome.ScrollSmooth("document.querySelector('[style=\"flex-grow:0;flex-shrink:1;margin:0 0 5px 0\"]')");
								DelayThaoTacNho();
								chrome.ExecuteScript("document.querySelector('[style=\"flex-grow:0;flex-shrink:1;margin:0 0 5px 0\"]').click()");
								DelayThaoTacNho(2);
								text2 = chrome.GetURL();
								if (text == text2)
								{
									flag = true;
									DelayThaoTacNho();
								}
							}
						}
						else if (isFollow)
						{
							text = chrome.GetURL();
							if (chrome.CheckExistElement("[data-sigil=\"header-launchpad-more-button\"]>div", 5.0) == 1)
							{
								chrome.ScrollSmooth("document.querySelector('[data-sigil=\"header-launchpad-more-button\"]>div')");
								DelayThaoTacNho();
								chrome.Click(4, "[data-sigil=\"header-launchpad-more-button\"]>div");
								DelayThaoTacNho();
								num2 = chrome.CheckExistElements(5.0, "#page > div > div > div > div > div > div > div > div:nth-child(1) > div > div > div > div._2ti7", "#page > div > div > div > div > div > div > div > div:nth-child(2) > div > div > div > div._2ti7");
								if (num2 == 1)
								{
									chrome.Click(4, "#page > div > div > div > div > div > div > div > div:nth-child(1) > div > div > div > div._2ti7");
									DelayThaoTacNho(2);
									text2 = chrome.GetURL();
									if (text == text2)
									{
										flag = true;
									}
								}
								else
								{
									chrome.Click(4, "#page > div > div > div > div > div > div > div > div:nth-child(2) > div > div > div > div._2ti7");
									DelayThaoTacNho(2);
									text2 = chrome.GetURL();
									if (text == text2)
									{
										flag = true;
									}
								}
							}
						}
						if (flag)
						{
							num++;
						}
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{count})...");
						chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
						continue;
					}
					return -1;
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDBaiVietNewsfeed(int indexRow, string statusProxy, Chrome chrome, int countPostFrom, int countPostTo, int delayFrom, int delayTo, bool isLike, bool isComment, List<string> lstComment, Random rd, string tenHanhDong = "", bool isShareWall = false)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			try
			{
				int num2 = -1;
				lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
				List<string> list = CloneList(lstComment);
				string text = "";
				int num3 = 0;
				int num4 = rd.Next(countPostFrom, countPostTo + 1);
				while (true)
				{
					IL_0729:
					if (CommonChrome.GoToHome(chrome) != -2)
					{
						int num5 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num5 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num5))
						{
							int num6 = 0;
							if (!Convert.ToBoolean(chrome.ExecuteScript("return (document.querySelectorAll('[data-store*=\"linkdata\"]').length>0)+''").ToString()))
							{
								break;
							}
							while (num < num4)
							{
								num5 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								if (num5 != 1)
								{
									if (!new List<int> { -3, -2, -1, 2 }.Contains(num5))
									{
										num2++;
										if (chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}]") != 1)
										{
											break;
										}
										num6 = 0;
										if (Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
										{
											num6++;
										}
										chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num2 + "]");
										DelayThaoTacNho();
										if (isLike && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")))
										{
											chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num2 + "].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')");
											num6++;
											if (Convert.ToBoolean(chrome.ExecuteScript($"var output='false';var x=document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a');  if(x!=null) output=(JSON.parse(x.getAttribute('data-store')).reaction==0)+''; return output;").ToString()))
											{
												DelayThaoTacNho();
												chrome.Click(4, "[data-store*=\"linkdata\"]", num2, 4, "[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a");
												DelayThaoTacNho();
											}
										}
										if (isComment && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")))
										{
											if (list.Count == 0)
											{
												list = CloneList(lstComment);
											}
											text = list[rd.Next(0, list.Count)];
											list.Remove(text);
											text = MCommon.Common.SpinText(text, rd);
											chrome.Click(4, "[data-store*=\"linkdata\"]", num2, 4, "[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]");
											DelayThaoTacNho();
											if (chrome.CheckExistElement("[data-sigil=\"textarea mufi-composer m-textarea-input\"]", 5.0) == 1)
											{
												DelayThaoTacNho();
												chrome.ScrollSmooth("document.querySelector('[data-sigil =\"textarea mufi-composer m-textarea-input\"]')");
												DelayThaoTacNho();
												string nameFromPost = CommonChrome.GetNameFromPost(chrome);
												text = text.Replace("[u]", nameFromPost);
												chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[data-sigil =\"textarea mufi-composer m-textarea-input\"]", text + " ", 0.15);
												DelayThaoTacNho();
												chrome.Click(4, "[name=\"submit\"]");
												DelayThaoTacNho(2);
												if (CommonChrome.CheckFacebookBlocked(chrome))
												{
													return -4;
												}
											}
											chrome.GotoBackPage();
											DelayThaoTacNho();
										}
										if (isShareWall && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num2}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
										{
											chrome.Click(4, "[data-store*=\"linkdata\"]", num2, 4, "[data-sigil=\"share-popup\"]");
											switch (chrome.CheckExistElements(5.0, "#share-one-click-button", "#share-post-one-click-button"))
											{
											case 1:
												DelayThaoTacNho();
												chrome.Click(1, "share-one-click-button");
												DelayThaoTacNho();
												break;
											case 2:
												DelayThaoTacNho();
												chrome.Click(1, "share-post-one-click-button");
												DelayThaoTacNho();
												break;
											}
										}
										if (num6 > 0)
										{
											num3 = 0;
											num++;
											if (tenHanhDong == "")
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang tương tác") + $" newsfeed ({num}/{num4})...");
											}
											else
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num4})...");
											}
										}
										else
										{
											num3++;
											if (num3 == 5)
											{
												break;
											}
										}
										chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
										continue;
									}
									return -1;
								}
								goto IL_0729;
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

		private void NewFeed(Chrome chrome, int countPostFrom, int countPostTo, bool isInteract, int typeInteract, bool isComment, List<string> lstComment, bool isShareWall, int delayFrom, int delayTo, Random rd)
		{
			List<string> list = new List<string>();
			list = CloneList(lstComment);
			int num = 0;
			if (chrome.GetURL() != "https://www.facebook.com/")
			{
				chrome.GotoURL("https://www.facebook.com/");
			}
			chrome.DelayTime(3.0);
			int num2 = rd.Next(countPostFrom, countPostTo + 1);
			for (int i = 0; i < num2; i++)
			{
				if (chrome.CheckExistElementv2("document.querySelectorAll('[role=\"feed\"]>div')[" + i + "]", 3.0) != 1)
				{
					break;
				}
				if (chrome.CheckExistElementOnScreen("document.querySelectorAll('[role=\"feed\"]>div')[" + i + "]") != 0)
				{
					chrome.ScrollSmooth("document.querySelectorAll('[role=\"feed\"]>div')[" + i + "]");
					DelayThaoTacNho();
				}
				if (isInteract)
				{
					string text = "";
					string text2 = "[role=\"feed\"]>div:nth-child(" + (i + 2) + ") div[data-visualcompletion=\"ignore-dynamic\"]>div>div>div>div:nth-child(1)>span";
					string text3 = "[role=\"feed\"]>div:nth-child(" + (i + 2) + ") div[data-visualcompletion=\"ignore-dynamic\"]>div>div>div>div:nth-child(2)>span";
					int num3 = chrome.CheckExistElements(0.0, text2, text3);
					switch (num3)
					{
					case 2:
						text = text3;
						break;
					case 1:
						text = text2;
						break;
					}
					if (num3 != 0)
					{
						DelayThaoTacNho();
						if (chrome.CheckExistElementOnScreen("document.querySelector('" + text + "')") != 0)
						{
							chrome.ScrollSmooth("document.querySelector('" + text + "')");
							DelayThaoTacNho();
						}
						chrome.HoverElement(4, text, 0.0);
						string text4 = "body>div>div>div>div[role=\"dialog\"]>span:nth-child(" + typeInteract + ")";
						if (chrome.CheckExistElement(text4, 3.0) == 1)
						{
							chrome.DelayTime(0.1);
							chrome.Click(4, text4);
							DelayThaoTacNho();
						}
					}
				}
				if (isComment)
				{
					string text5 = "";
					string text6 = "[role=\"feed\"]>div:nth-child(" + (i + 2) + ") div[data-visualcompletion=\"ignore-dynamic\"]>div>div>div>div:nth-child(1)>span:nth-child(2)>div";
					string text7 = "[role=\"feed\"]>div:nth-child(" + (i + 2) + ") div[data-visualcompletion=\"ignore-dynamic\"]>div>div>div>div:nth-child(2)>span:nth-child(2)>div";
					int num4 = chrome.CheckExistElements(0.0, text6, text7);
					switch (num4)
					{
					case 2:
						text5 = text7;
						break;
					case 1:
						text5 = text6;
						break;
					}
					if (num4 != 0)
					{
						if (list.Count == 0)
						{
							list = CloneList(lstComment);
						}
						string text8 = lstComment[rd.Next(0, lstComment.Count)];
						list.Remove(text8);
						string text9 = "[role=\"feed\"]>div:nth-child(" + (i + 2) + ") [data-contents=\"true\"]";
						if (chrome.CheckExistElement(text9) != 1)
						{
							DelayThaoTacNho();
							if (chrome.CheckExistElementOnScreen("document.querySelector('" + text5 + "')") != 0)
							{
								chrome.ScrollSmooth("document.querySelector('" + text5 + "')");
								DelayThaoTacNho();
							}
							chrome.Click(4, text5);
						}
						if (chrome.CheckExistElement(text9, 5.0) == 1)
						{
							DelayThaoTacNho();
							if (chrome.CheckExistElementOnScreen("document.querySelector('" + text9 + "')") != 0)
							{
								chrome.ScrollSmooth("document.querySelector('" + text9 + "')");
								DelayThaoTacNho();
							}
							switch (setting_general.GetValueInt("tocDoGoVanBan"))
							{
							case 2:
								chrome.SendKeys(4, text9, chrome.CountElement(text9) - 1, text8);
								break;
							case 0:
							case 1:
								chrome.SendKeys(4, text9, chrome.CountElement(text9) - 1, text8, 0.1, isClick: true, rd.Next(1, 3));
								break;
							}
							DelayThaoTacNho(1);
							chrome.SendEnter(4, text9);
							DelayThaoTacNho(2);
						}
					}
				}
				if (isShareWall)
				{
					string text10 = "";
					string text11 = "[role=\"feed\"]>div:nth-child(" + (i + 2) + ") div[data-visualcompletion=\"ignore-dynamic\"]>div>div>div>div:nth-child(1)>div[aria-label]";
					string text12 = "[role=\"feed\"]>div:nth-child(" + (i + 2) + ") div[data-visualcompletion=\"ignore-dynamic\"]>div>div>div>div:nth-child(2)>div[aria-label]";
					int num5 = chrome.CheckExistElements(0.0, text12, text11);
					switch (num5)
					{
					case 2:
						text10 = text11;
						break;
					case 1:
						text10 = text12;
						break;
					}
					if (num5 != 0)
					{
						int num6 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-pagelet=\"root\"]').length+''").ToString());
						if (chrome.CheckExistElementOnScreen("document.querySelector('" + text10 + "')") != 0)
						{
							chrome.ScrollSmooth("document.querySelector('" + text10 + "')");
							DelayThaoTacNho();
						}
						if (chrome.Click(4, text10) == 1)
						{
							for (int j = 0; j < 5; j++)
							{
								int num7 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-pagelet=\"root\"]').length+''").ToString());
								if (num7 <= num6)
								{
									chrome.DelayTime(1.0);
									continue;
								}
								DelayThaoTacNho();
								if (chrome.Click(4, "[data-testid=\"Keycommand_wrapper_ModalLayer\"] [data-visualcompletion=\"ignore-dynamic\"] >div") == 1)
								{
									i++;
								}
								break;
							}
						}
					}
				}
				num++;
				chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
			}
		}

		public int HDBaiVietBanBe(int indexRow, string statusProxy, Chrome chrome, string token, string cookie, int soLuongBanFrom, int soLuongBanTo, int soLuongBaiFrom, int soLuongBaiTo, int delayFrom, int delayTo, bool isLike, bool isComment, List<string> lstComment, string proxy, int typeProxy, Random rd, string tenHanhDong = "", bool isShareWall = false, int typeNganCach = 0)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = 0;
			try
			{
				int num3 = rd.Next(soLuongBanFrom, soLuongBanTo + 1);
				int num4 = 0;
				string text = "";
				lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
				List<string> list = new List<string>();
				list = CloneList(lstComment);
				while (true)
				{
					if (CommonChrome.GoToFriend(chrome) != -2)
					{
						int num5 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num5 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num5))
						{
							if (num3 == 0)
							{
								break;
							}
							int num6 = chrome.CountElement("[data-sigil=\"undoable-action\"]");
							if (num6 > 5)
							{
								CommonChrome.ScrollRandom(chrome);
							}
							num6 = chrome.CountElement("[data-sigil=\"undoable-action\"]");
							if (num6 <= 0)
							{
								break;
							}
							int index = Base.rd.Next(0, num6);
							chrome.ScrollSmooth("document.querySelectorAll('[data-sigil=\"undoable-action\"]>div:nth-child(1)>a')[" + index + "]");
							DelayThaoTacNho();
							chrome.Click(4, "[data-sigil=\"undoable-action\"]>div:nth-child(1)>a", index);
							DelayThaoTacNho(2);
							num++;
							num2 = 0;
							int num7 = rd.Next(soLuongBaiFrom, soLuongBaiTo + 1);
							int num8 = 0;
							int num9 = -1;
							while (true)
							{
								if (num2 < num7)
								{
									num5 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
									if (num5 == 1)
									{
										break;
									}
									if (new List<int> { -3, -2, -1, 2 }.Contains(num5))
									{
										return -1;
									}
									num9++;
									if (chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}]") == 1)
									{
										if (Base.rd.Next(1, 100) % 2 != 0)
										{
											continue;
										}
										num8 = 0;
										if (Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
										{
											num8++;
										}
										chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num9 + "]");
										DelayThaoTacNho(2);
										if (isLike && Base.rd.Next(1, 100) % 3 == 0 && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")))
										{
											chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num9 + "].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')");
											num8++;
											if (Convert.ToBoolean(chrome.ExecuteScript($"var output='false';var x=document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a');  if(x!=null) output=(JSON.parse(x.getAttribute('data-store')).reaction==0)+''; return output;").ToString()))
											{
												DelayThaoTacNho();
												chrome.Click(4, "[data-store*=\"linkdata\"]", num9, 4, "[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a");
												DelayThaoTacNho();
											}
										}
										if (isComment && Base.rd.Next(1, 100) % 3 == 0 && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")))
										{
											num8++;
											if (list.Count == 0)
											{
												list = CloneList(lstComment);
											}
											text = list[rd.Next(0, list.Count)];
											list.Remove(text);
											text = MCommon.Common.SpinText(text, rd);
											chrome.Click(4, "[data-store*=\"linkdata\"]", num9, 4, "[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]");
											DelayThaoTacNho();
											if (chrome.CheckExistElement("[data-sigil=\"textarea mufi-composer m-textarea-input\"]", 5.0) == 1)
											{
												DelayThaoTacNho();
												chrome.ScrollSmooth("document.querySelector('[data-sigil =\"textarea mufi-composer m-textarea-input\"]')");
												DelayThaoTacNho();
												string nameFromPost = CommonChrome.GetNameFromPost(chrome);
												text = text.Replace("[u]", nameFromPost);
												chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[data-sigil =\"textarea mufi-composer m-textarea-input\"]", text + " ", 0.15);
												DelayThaoTacNho();
												chrome.Click(4, "[name=\"submit\"]");
												DelayThaoTacNho(2);
												if (CommonChrome.CheckFacebookBlocked(chrome))
												{
													return -4;
												}
											}
											chrome.GotoBackPage();
											DelayThaoTacNho();
										}
										if (isShareWall && Base.rd.Next(1, 100) % 3 == 0 && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num9}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
										{
											num8++;
											chrome.Click(4, "[data-store*=\"linkdata\"]", num9, 4, "[data-sigil=\"share-popup\"]");
											switch (chrome.CheckExistElements(5.0, "#share-one-click-button", "#share-post-one-click-button"))
											{
											case 1:
												DelayThaoTacNho();
												chrome.Click(1, "share-one-click-button");
												DelayThaoTacNho();
												break;
											case 2:
												DelayThaoTacNho();
												chrome.Click(1, "share-post-one-click-button");
												DelayThaoTacNho();
												break;
											}
										}
										if (num8 > 0)
										{
											num4 = 0;
											num2++;
											if (tenHanhDong == "")
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang tương tác bạn bè") + $"({num}/{num3}:{num2}/{num7})...");
											}
											else
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num3}:{num2}/{num7})...");
											}
											if (chrome.CheckChromeClosed())
											{
												return -2;
											}
										}
										else
										{
											num4++;
											if (num4 == 3)
											{
												goto IL_0949;
											}
										}
										chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
										continue;
									}
								}
								goto IL_0949;
								IL_0949:
								if (num < num3)
								{
									break;
								}
								goto end_IL_0046;
							}
							continue;
						}
						return -1;
					}
					return -2;
				}
				end_IL_0046:;
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex, "HDBaiVietBanBe");
			}
			return num;
		}

		public int HDTuongTacBanBe(int indexRow, string statusProxy, Device device, int soLuongBanFrom, int soLuongBanTo, int timeFrom, int timeTo, bool isLike, int countLikeFrom, int countLikeTo, bool isComment, int countCommentFrom, int countCommentTo, List<string> lstComment, bool isShareWall, int countShareFrom, int countShareTo, string tenHanhDong)
		{
			int num = 0;
			try
			{
				int num2 = rd.Next(soLuongBanFrom, soLuongBanTo + 1);
				if (num2 != 0)
				{
					while (num < num2)
					{
						num++;
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
						while (true)
						{
							device.GotoListFriend();
							device.DelayRandom(1.0, 2.0);
							switch (CheckStatusDevice(device, indexRow, statusProxy))
							{
							case 1:
								break;
							case 0:
							{
								List<string> listBoundsByText = device.GetListBoundsByText("more options", "", 10);
								if (listBoundsByText.Count != 0)
								{
									int num3 = 0;
									if (listBoundsByText.Count >= 6)
									{
										while (!device.ScrollAndCheckScreenNotChange(device.GetRandomInt(200, 300)))
										{
											num3++;
											if (num3 >= 5)
											{
												break;
											}
										}
										int randomInt = device.GetRandomInt(0, ((num3 < 1) ? 1 : num3) - 1);
										for (int i = 0; i < randomInt; i++)
										{
											if (device.ScrollAndCheckScreenNotChange(device.GetRandomInt(200, 300), -1))
											{
												break;
											}
										}
										listBoundsByText = device.GetListBoundsByText("more options", "", 10);
									}
									string bounds = listBoundsByText[device.GetRandomInt(0, listBoundsByText.Count - 1)];
									Point locationFromBounds = device.GetLocationFromBounds(bounds);
									device.Tap(locationFromBounds.X - device.GetRandomInt(40, 160), locationFromBounds.Y);
									InteractTimelime(indexRow, statusProxy, device, timeFrom, timeTo, isLike, countLikeFrom, countLikeTo, isComment, countCommentFrom, countCommentTo, lstComment, isShareWall, countShareFrom, countShareTo);
									goto IL_029d;
								}
								goto end_IL_0006;
							}
							default:
								goto end_IL_0006;
							}
						}
						IL_029d:;
					}
				}
				end_IL_0006:;
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "HDTuongTacBanBe");
			}
			return num;
		}

		public int HDTuongTacNhom(int indexRow, string statusProxy, Device device, int soLuongNhomFrom, int soLuongNhomTo, int timeFrom, int timeTo, bool isLike, int countLikeFrom, int countLikeTo, bool isComment, int countCommentFrom, int countCommentTo, List<string> lstComment, bool isShareWall, int countShareFrom, int countShareTo, string tenHanhDong)
		{
			int num = 0;
			try
			{
				int num2 = rd.Next(soLuongNhomFrom, soLuongNhomTo + 1);
				if (num2 != 0)
				{
					while (num < num2)
					{
						num++;
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
						while (true)
						{
							device.GotoListGroup();
							device.DelayRandom(1.0, 2.0);
							switch (CheckStatusDevice(device, indexRow, statusProxy))
							{
							case 1:
								break;
							case 0:
							{
								List<string> list = new List<string>();
								for (int i = 0; i < 3; i++)
								{
									list = device.GetListBoundsByText("\\sbutton");
									if (list.Count > 0 || device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									device.DelayTime(1.0);
								}
								if (list.Count != 0)
								{
									int num3 = 0;
									if (list.Count > 5)
									{
										while (!device.ScrollAndCheckScreenNotChange(device.GetRandomInt(200, 300)))
										{
											num3++;
											if (num3 >= 5)
											{
												break;
											}
										}
										int randomInt = device.GetRandomInt(0, ((num3 < 1) ? 1 : num3) - 1);
										for (int j = 0; j < randomInt; j++)
										{
											if (device.ScrollAndCheckScreenNotChange(device.GetRandomInt(200, 300), -1))
											{
												break;
											}
										}
										list = device.GetListBoundsByText("\\sbutton");
									}
									string bounds = list[device.GetRandomInt(0, list.Count - 1)];
									device.TapByBounds(bounds);
									InteractTimelime(indexRow, statusProxy, device, timeFrom, timeTo, isLike, countLikeFrom, countLikeTo, isComment, countCommentFrom, countCommentTo, lstComment, isShareWall, countShareFrom, countShareTo);
									goto IL_02d2;
								}
								goto end_IL_0006;
							}
							default:
								goto end_IL_0006;
							}
						}
						IL_02d2:;
					}
				}
				end_IL_0006:;
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "HDTTuongTacNhom");
			}
			return num;
		}

		public int HDTuongTacPage(int indexRow, string statusProxy, Device device, int soLuongNhomFrom, int soLuongNhomTo, bool ckbTuDongXoaUid, int timeFrom, int timeTo, bool isLike, int countLikeFrom, int countLikeTo, bool isComment, int countCommentFrom, int countCommentTo, List<string> lstComment, bool isShareWall, int countShareFrom, int countShareTo, string idHanhDong, string tenHanhDong)
		{
			int num = 0;
			try
			{
				int num2 = rd.Next(soLuongNhomFrom, soLuongNhomTo + 1);
				if (num2 != 0)
				{
					List<string> list = new List<string>();
					if (!ckbTuDongXoaUid)
					{
						list = MCommon.Common.CloneList(dicUidTuongTacPage[idHanhDong]);
					}
					string text = "";
					while (num < num2)
					{
						num++;
						SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
						if (!ckbTuDongXoaUid)
						{
							if (list.Count != 0)
							{
								text = list[rd.Next(0, list.Count)];
								list.Remove(text);
								goto IL_01a1;
							}
							break;
						}
						lock (dicUidTuongTacPage)
						{
							if (dicUidTuongTacPage[idHanhDong].Count == 0)
							{
								break;
							}
							text = dicUidTuongTacPage[idHanhDong][rd.Next(0, dicUidTuongTacPage[idHanhDong].Count)];
							dicUidTuongTacPage[idHanhDong].Remove(text);
							goto IL_01a1;
						}
						IL_01a1:
						while (true)
						{
							device.GotoPageQuick(text);
							device.DelayRandom(2.0, 3.0);
							switch (CheckStatusDevice(device, indexRow, statusProxy))
							{
							case 1:
								break;
							case 0:
								goto IL_01f8;
							default:
								goto end_IL_0006;
							}
							continue;
							IL_01f8:
							InteractTimelime(indexRow, statusProxy, device, timeFrom, timeTo, isLike, countLikeFrom, countLikeTo, isComment, countCommentFrom, countCommentTo, lstComment, isShareWall, countShareFrom, countShareTo);
							break;
						}
					}
				}
				end_IL_0006:;
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "HDTTuongTacPage");
			}
			return num;
		}

		public int HDDanhGiaPage(int indexRow, string statusProxy, Device device, string idPage, bool islike, bool ckbTuDongXoaNoiDung, string idHanhDong, string tenHanhDong)
		{
			int result = 1;
			string text = "";
			bool flag = false;
			try
			{
				while (true)
				{
					device.GotoPageQuick(idPage);
					device.DelayTime(3.0);
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						break;
					default:
						goto end_IL_0012;
					case 0:
						if (flag = device.CheckExistTexts("", 10.0, "home", "page cover photo") > 0)
						{
							if (islike)
							{
								SetStatusAccount(indexRow, statusProxy + "Like page...");
								if (device.TapByImage("DataClick\\image\\nutLikePage"))
								{
									device.DelayRandom(2.0, 3.0);
									device.TapByImage("DataClick\\image\\nutLikePage\\like");
								}
							}
							SetStatusAccount(indexRow, statusProxy + "Review page...");
							flag = false;
							for (int i = 0; i < 10; i++)
							{
								text = device.GetHtml();
								if (!device.TapByText("reviews", text))
								{
									device.SwipeByBounds("[232,323][276,336]", "[53,323][92,338]", 500);
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							if (flag && (flag = device.CheckExistText("do you recommend", "", 10.0)))
							{
								flag = false;
								for (int j = 0; j < 10; j++)
								{
									if (!device.TapByImage("DataClick\\image\\nutLikePage\\review"))
									{
										if (device.ScrollAndCheckScreenNotChange())
										{
											break;
										}
										device.DelayTime(1.0);
										continue;
									}
									flag = true;
									break;
								}
								if (flag && (flag = device.CheckExistText("what do you recommend", "", 10.0)))
								{
									device.TapByBounds("[104,179][221,233]");
									device.DelayTime(2.0);
									string text2 = "";
									if (dicNoiDungReview[idHanhDong].Count != 0)
									{
										if (!ckbTuDongXoaNoiDung)
										{
											text2 = dicNoiDungReview[idHanhDong][rd.Next(0, dicNoiDungReview[idHanhDong].Count)];
										}
										else
										{
											lock (dicNoiDungReview)
											{
												int index = rd.Next(0, dicNoiDungReview[idHanhDong].Count);
												text2 = dicNoiDungReview[idHanhDong][index];
												dicNoiDungReview[idHanhDong].RemoveAt(index);
											}
										}
										text2 = MCommon.Common.SpinText(text2, rd);
										flag = false;
										for (int k = 0; k < 10; k++)
										{
											device.InputTextWithUnicode(text2);
											device.DelayTime(1.0);
											if (!device.TapByImage("DataClick\\image\\nutLikePage\\share"))
											{
												device.DelayTime(1.0);
												continue;
											}
											flag = true;
											break;
										}
										if (flag)
										{
											flag = false;
											for (int l = 0; l < 10; l++)
											{
												if (!device.TapByImage("DataClick\\image\\skip") && !device.CheckExistText("thanks for recommending"))
												{
													device.DelayTime(1.0);
													continue;
												}
												flag = true;
												break;
											}
											if (flag)
											{
												flag = device.CheckExistText("thanks for recommending", "", 10.0);
											}
										}
									}
								}
							}
						}
						goto end_IL_0012;
					}
				}
				end_IL_0012:;
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		public int HDBuffLikePage(int indexRow, string statusProxy, Device device, string idPage, string tenHanhDong)
		{
			int result = 1;
			try
			{
				while (true)
				{
					device.GotoPageQuick(idPage);
					device.DelayTime(3.0);
					switch (CheckStatusDevice(device, indexRow, statusProxy))
					{
					case 1:
						break;
					default:
						goto end_IL_0006;
					case 0:
						if (device.CheckExistTexts("", 10.0, "home", "page cover photo") != 0)
						{
							SetStatusAccount(indexRow, statusProxy + "Like page...");
							if (device.TapByImage("DataClick\\image\\nutLikePage"))
							{
								device.DelayRandom(2.0, 3.0);
								device.TapByImage("DataClick\\image\\nutLikePage\\like");
							}
						}
						goto end_IL_0006;
					}
				}
				end_IL_0006:;
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		public int HDBuffFollowUID(int indexRow, string statusProxy, Device device, string uid, string tenHanhDong)
		{
			int result = 1;
			try
			{
				while (true)
				{
					device.GotoProfileQuick(uid);
					device.DelayTime(2.0);
					switch (CheckGoToProfileUidSuccess(device, indexRow, statusProxy))
					{
					case 2:
						continue;
					case 0:
					case 3:
						goto end_IL_0006;
					}
					SetStatusAccount(indexRow, statusProxy + "Follow UID...");
					if (!device.TapByImage("DataClick\\image\\followeuid", null, 5))
					{
						string html = device.GetHtml();
						if (!device.CheckExistText("\"following\"", html) && !device.TapByText("\"follow\"", html) && device.TapByText("more", html))
						{
							for (int i = 0; i < 10; i++)
							{
								if (device.TapByImage("DataClick\\image\\followeuid"))
								{
									break;
								}
								if (device.TapByText("\"follow\""))
								{
									break;
								}
								device.DelayTime(1.0);
							}
						}
					}
					goto end_IL_0006;
				}
				end_IL_0006:;
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		public int HDDangStory(int indexRow, string statusProxy, Device device, int soLuongFrom, int soLuongTo, int typeDang, List<string> lstContentText, bool ckbUseBackground, int typeBaiHat, List<string> lstNhac, string tenHanhDong)
		{
			int result = 1;
			bool flag = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			string text = "";
			new List<string>();
			try
			{
				int randomInt = device.GetRandomInt(soLuongFrom, soLuongTo);
				int num4 = 0;
				while (num4 < randomInt)
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num4 + 1}/{randomInt})...");
					while (true)
					{
						device.GotoProfileQuick();
						device.DelayTime(2.0);
						num2 = CheckGoToProfileUidSuccess(device, indexRow, statusProxy);
						if (num2 != 0)
						{
							if (num2 == 2)
							{
								continue;
							}
							if (num2 == 3)
							{
								break;
							}
							if (device.TapByText("add to story", "", 10))
							{
								if (typeDang == 0)
								{
									num++;
									if (flag = device.TapByImage("DataClick\\image\\taostory\\text", null, 10))
									{
										num++;
										if (flag = device.TapByText("start typing", "", 10))
										{
											device.InputTextWithUnicode(lstContentText.OrderBy((string t) => Guid.NewGuid()).First());
											device.DelayTime(2.0);
											if (ckbUseBackground)
											{
												flag = false;
												switch (device.CheckExistTexts("", 10.0, "background image", "select background"))
												{
												case 2:
													flag = device.TapByText("select background", "", 10);
													break;
												case 1:
													flag = true;
													break;
												}
												if (flag)
												{
													num3 = rd.Next(2, 5);
													for (int i = 0; i < num3; i++)
													{
														device.SwipeByBounds("[254,253][279,279]", "[60,254][94,277]");
														device.DelayTime(1.0);
													}
													device.DelayTime(1.0);
													string text2 = (from t in device.GetListBoundsByText("background image")
														orderby Guid.NewGuid()
														select t).FirstOrDefault();
													if (!string.IsNullOrEmpty(text2))
													{
														device.TapByBounds(text2);
													}
												}
											}
											device.TapByBounds("[272,27][300,38]");
											device.DelayTime(2.0);
											goto IL_0593;
										}
									}
								}
								else
								{
									num++;
									if (flag = device.TapByImage("DataClick\\image\\taostory\\nhac", null, 10))
									{
										num++;
										if (flag = device.CheckExistText("search music", "", 10.0))
										{
											if (typeBaiHat == 0)
											{
												num3 = rd.Next(2, 5);
												for (int j = 0; j < num3; j++)
												{
													device.Scroll();
													device.DelayTime(1.0);
												}
											}
											else
											{
												flag = device.TapByText("search music", "", 10);
												num++;
												if (!flag)
												{
													goto IL_06fb;
												}
												device.InputTextWithUnicode(lstNhac.OrderBy((string t) => Guid.NewGuid()).FirstOrDefault());
												device.DelayTime(3.0);
											}
											flag = false;
											num++;
											string text3 = (from t in device.GetListBoundsByText("song preview")
												orderby Guid.NewGuid()
												select t).FirstOrDefault();
											if (!string.IsNullOrEmpty(text3))
											{
												Point locationFromBounds = device.GetLocationFromBounds(text3);
												device.Tap(locationFromBounds.X - 100, locationFromBounds.Y);
												flag = true;
											}
											if (flag)
											{
												flag = device.TapByText("done", "", 10);
												num++;
												if (flag)
												{
													flag = device.TapByText("close background", "", 10);
													num++;
													if (flag)
													{
														goto IL_0593;
													}
												}
											}
										}
									}
								}
							}
						}
						goto IL_06fb;
						IL_0593:
						device.ClosePopup();
						flag = device.TapByText("privacy", "", 10);
						num++;
						if (flag)
						{
							flag = device.TapByText("public", "", 10);
							num++;
							if (flag)
							{
								flag = device.TapByText("\"change\"", "", 5);
								device.DelayTime(2.0);
								device.GotoBack();
								flag = device.TapByText("share", "", 10);
								num++;
								device.DelayTime(2.0);
								for (int k = 0; k < 3; k++)
								{
									text = "";
									switch (device.CheckExistTexts(ref text, 10.0, "not now", "add to story"))
									{
									case 1:
										device.TapByText("not now", text);
										continue;
									default:
										continue;
									case 2:
										break;
									}
									break;
								}
							}
						}
						goto IL_06fb;
						IL_06fb:
						num4++;
						goto IL_0705;
					}
					break;
					IL_0705:;
				}
			}
			catch
			{
			}
			return result;
		}

		public int HDBaiVietNhom(int indexRow, string statusProxy, Chrome chrome, string token, string cookie, int soLuongNhomFrom, int soLuongNhomTo, int soLuongBaiVietFrom, int soLuongBaiVietTo, int delayFrom, int delayTo, bool isLike, bool isComment, List<string> lstComment, string proxy, int typeProxy, Random rd, string tenHanhDong = "", bool isShareWall = false, bool isSendAnh = false, string pathFolderImage = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = 0;
			int num3 = rd.Next(soLuongNhomFrom, soLuongNhomTo + 1);
			int num4 = 0;
			string text = "";
			lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
			List<string> list = new List<string>();
			list = CloneList(lstComment);
			List<string> list2 = new List<string>();
			List<string> lstFrom = new List<string>();
			List<string> list3 = new List<string>();
			if (isSendAnh)
			{
				lstFrom = Directory.GetFiles(pathFolderImage).ToList();
				list3 = CloneList(lstFrom);
			}
			string text2 = "";
			while (true)
			{
				IL_0b1d:
				if (CommonChrome.GoToGroup(chrome) != -2)
				{
					int num5 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
					if (num5 == 1)
					{
						continue;
					}
					if (new List<int> { -3, -2, -1, 2 }.Contains(num5))
					{
						break;
					}
					CommonChrome.ScrollRandom(chrome);
					if (num3 != 0)
					{
						list2 = chrome.ExecuteScript("var x=[];document.querySelectorAll('a').forEach(e=>{if(e.getAttribute('href')!=null && e.getAttribute('href').endsWith('ref=group_browse')) x.push(e.getAttribute('href'))}); return x.join('|')").ToString().Split('|')
							.ToList();
						if (list2.Count > 0)
						{
							int index = Base.rd.Next(0, list2.Count);
							chrome.ScrollSmooth("document.querySelector('[href=\"" + list2[index] + "\"]')");
							DelayThaoTacNho();
							chrome.Click(4, "[href=\"" + list2[index] + "\"]");
							DelayThaoTacNho(2);
							num++;
							num2 = 0;
							int num6 = rd.Next(soLuongBaiVietFrom, soLuongBaiVietTo + 1);
							int num7 = 0;
							int num8 = 0;
							while (num2 < num6)
							{
								num5 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								if (num5 != 1)
								{
									if (!new List<int> { -3, -2, -1, 2 }.Contains(num5))
									{
										num8++;
										if (chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}]") != 1)
										{
											break;
										}
										if (Base.rd.Next(1, 100) % 2 != 0)
										{
											continue;
										}
										num7 = 0;
										if (Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
										{
											num7++;
										}
										if (!chrome.CheckChromeClosed())
										{
											chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "]");
											DelayThaoTacNho();
											if (isLike && Base.rd.Next(1, 100) % 3 == 0 && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")))
											{
												chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')");
												num7++;
												if (Convert.ToBoolean(chrome.ExecuteScript($"var output='false';var x=document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a');  if(x!=null) output=(JSON.parse(x.getAttribute('data-store')).reaction==0)+''; return output;").ToString()))
												{
													DelayThaoTacNho();
													chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a");
													DelayThaoTacNho();
												}
											}
											if ((isComment || isSendAnh) && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")))
											{
												num7++;
												if (list.Count == 0)
												{
													list = CloneList(lstComment);
												}
												text = list[rd.Next(0, list.Count)];
												list.Remove(text);
												text = MCommon.Common.SpinText(text, rd);
												chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]");
												DelayThaoTacNho();
												if (chrome.CheckExistElement("[data-sigil=\"textarea mufi-composer m-textarea-input\"]", 5.0) == 1)
												{
													DelayThaoTacNho();
													chrome.ScrollSmooth("document.querySelector('[data-sigil =\"textarea mufi-composer m-textarea-input\"]')");
													if (isSendAnh)
													{
														DelayThaoTacNho();
														if (list3.Count == 0)
														{
															list3 = CloneList(lstFrom);
														}
														text2 = list3[rd.Next(0, list3.Count)];
														list3.Remove(text2);
														chrome.SendKeys(4, "[data-sigil=\"m-raw-file-input\"]", text2);
														int tickCount = Environment.TickCount;
														do
														{
															chrome.DelayTime(1.0);
														}
														while (Environment.TickCount - tickCount < 30000 && chrome.CheckExistElement("[data-sigil=\"touchable\"]>img") != 1);
														DelayThaoTacNho();
													}
													if (isComment)
													{
														DelayThaoTacNho();
														if (list.Count == 0)
														{
															list = CloneList(lstComment);
														}
														text = list[rd.Next(0, list.Count)];
														list.Remove(text);
														text = MCommon.Common.SpinText(text, rd);
														string nameFromPost = CommonChrome.GetNameFromPost(chrome);
														text = text.Replace("[u]", nameFromPost);
														chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[data-sigil =\"textarea mufi-composer m-textarea-input\"]", text + " ", 0.1);
														DelayThaoTacNho();
													}
													for (int i = 0; i < 10; i++)
													{
														if (chrome.Click(2, "submit") == 1)
														{
															break;
														}
														MCommon.Common.DelayTime(1.0);
													}
													DelayThaoTacNho(2);
													if (CommonChrome.CheckFacebookBlocked(chrome))
													{
														return -4;
													}
												}
												chrome.GotoBackPage();
												DelayThaoTacNho();
											}
											if (isShareWall && Base.rd.Next(1, 100) % 3 == 0 && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
											{
												num7++;
												chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-sigil=\"share-popup\"]");
												switch (chrome.CheckExistElements(5.0, "#share-one-click-button", "#share-post-one-click-button"))
												{
												case 1:
													DelayThaoTacNho();
													chrome.Click(1, "share-one-click-button");
													DelayThaoTacNho();
													break;
												case 2:
													DelayThaoTacNho();
													chrome.Click(1, "share-post-one-click-button");
													DelayThaoTacNho();
													break;
												}
											}
											if (num7 > 0)
											{
												num4 = 0;
												num2++;
												if (tenHanhDong == "")
												{
													SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang tương tác nhóm") + $" ({num}/{num3}:{num2}/{num6})...");
												}
												else
												{
													SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num3}:{num2}/{num6})...");
												}
												if (chrome.CheckChromeClosed())
												{
													return -2;
												}
											}
											else
											{
												num4++;
												if (num4 == 3)
												{
													break;
												}
											}
											chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
											continue;
										}
										return -2;
									}
									return -1;
								}
								goto IL_0b1d;
							}
							if (num < num3)
							{
								continue;
							}
						}
					}
					return num;
				}
				return -2;
			}
			return -1;
		}

		public int HDBaiVietFanpage(int indexRow, string statusProxy, Chrome chrome, int soLuongPageFrom, int soLuongPageTo, List<string> lstPage, int soLuongBaiFrom, int soLuongBaiTo, int delayFrom, int delayTo, bool isLike, bool isComment, List<string> lstComment, bool isLikePage, bool isViewVideo, int viewFrom, int viewTo, Random rd, string tenHanhDong = "", bool isShareWall = false)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = 0;
			string text = "";
			List<string> list = new List<string>();
			lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
			list = CloneList(lstComment);
			try
			{
				lstPage = MCommon.Common.RemoveEmptyItems(lstPage);
				int count = lstPage.Count;
				int num3 = rd.Next(soLuongPageFrom, soLuongPageTo + 1);
				for (int i = 0; i < count; i++)
				{
					if (num == num3)
					{
						break;
					}
					string text2 = lstPage[rd.Next(0, lstPage.Count)];
					lstPage.Remove(text2);
					while (true)
					{
						IL_0931:
						chrome.GotoURL("https://m.facebook.com/" + text2 + "/posts");
						chrome.DelayTime(2.0);
						int num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num4 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
						{
							num++;
							chrome.Scroll(0, 1000);
							num2 = 0;
							int num5 = 0;
							int num6 = rd.Next(soLuongBaiFrom, soLuongBaiTo + 1);
							int num7 = 0;
							int num8 = -1;
							while (num2 < num6)
							{
								num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								if (num4 != 1)
								{
									if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
									{
										num8++;
										if (chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}]") != 1)
										{
											break;
										}
										num7 = 0;
										if (Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}]!=null&&(document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null|| document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null || document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"share-popup\"]')!=null))+''")))
										{
											num7++;
										}
										if (!chrome.CheckChromeClosed())
										{
											chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "]");
											DelayThaoTacNho(2);
											if (isViewVideo && chrome.CheckExistElementv2("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "].querySelector('[data-sigil=\"m-video-play-button playInlineVideo\"]')") == 1)
											{
												chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "].document.querySelector('[data-sigil=\"m-video-play-button playInlineVideo\"]')");
												DelayThaoTacNho();
												chrome.ClickWithAction(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-sigil=\"m-video-play-button playInlineVideo\"]");
												chrome.DelayTime(rd.Next(viewFrom, viewTo + 1));
											}
											if (isLike && chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')") == 1)
											{
												chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')");
												num7++;
												if (Convert.ToBoolean(chrome.ExecuteScript($"var output='false';var x=document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a');  if(x!=null) output=(JSON.parse(x.getAttribute('data-store')).reaction==0)+''; return output;").ToString()))
												{
													DelayThaoTacNho();
													chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a");
													DelayThaoTacNho();
												}
											}
											if (isComment && chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')") == 1)
											{
												num7++;
												if (list.Count == 0)
												{
													list = CloneList(lstComment);
												}
												text = list[rd.Next(0, list.Count)];
												list.Remove(text);
												text = MCommon.Common.SpinText(text, rd);
												if (chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]") == 1)
												{
													DelayThaoTacNho();
													if (chrome.CheckExistElement("[data-sigil=\"textarea mufi-composer m-textarea-input\"]", 5.0) == 1)
													{
														DelayThaoTacNho();
														chrome.ScrollSmooth("document.querySelector('[data-sigil =\"textarea mufi-composer m-textarea-input\"]')");
														DelayThaoTacNho();
														string nameFromPost = CommonChrome.GetNameFromPost(chrome);
														text = text.Replace("[u]", nameFromPost);
														chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[data-sigil =\"textarea mufi-composer m-textarea-input\"]", text + " ", 0.15);
														DelayThaoTacNho();
														chrome.Click(4, "[name=\"submit\"]");
														DelayThaoTacNho(2);
														if (CommonChrome.CheckFacebookBlocked(chrome))
														{
															return -4;
														}
													}
													chrome.GotoBackPage();
													DelayThaoTacNho();
													chrome.Scroll(0, 1000);
												}
											}
											if (isShareWall && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
											{
												num7++;
												chrome.ScrollSmooth($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"share-popup\"]')");
												DelayThaoTacNho();
												chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-sigil=\"share-popup\"]");
												switch (chrome.CheckExistElements(5.0, "#share-one-click-button", "#share-post-one-click-button"))
												{
												case 1:
													DelayThaoTacNho();
													chrome.Click(1, "share-one-click-button");
													DelayThaoTacNho();
													break;
												case 2:
													DelayThaoTacNho();
													chrome.Click(1, "share-post-one-click-button");
													DelayThaoTacNho();
													break;
												}
											}
											if (num7 > 0)
											{
												num5 = 0;
												num2++;
												if (tenHanhDong == "")
												{
													SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang tương tác") + $" page ({num}/{num3}:{num2}/{num6})...");
												}
												else
												{
													SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num3}:{num2}/{num6})...");
												}
												if (chrome.CheckChromeClosed())
												{
													return -2;
												}
											}
											else
											{
												num5++;
												if (num5 == 3)
												{
													break;
												}
											}
											chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
											continue;
										}
										return -2;
									}
									return -1;
								}
								goto IL_0931;
							}
							break;
						}
						return -1;
					}
					if (!isLikePage)
					{
						continue;
					}
					string uRL = chrome.GetURL();
					if (chrome.CheckExistElement("#msite-pages-header-contents", 10.0) == 1)
					{
						chrome.ScrollSmooth("document.querySelector('[style=\"flex-grow:0;flex-shrink:1;margin:0 0 5px 0\"]')");
						DelayThaoTacNho();
						chrome.ExecuteScript("document.querySelector('[style=\"flex-grow:0;flex-shrink:1;margin:0 0 5px 0\"]').click()");
						DelayThaoTacNho(2);
						string uRL2 = chrome.GetURL();
						if (uRL == uRL2)
						{
							DelayThaoTacNho();
						}
					}
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDSpamBaiViet(int indexRow, string statusProxy, Device device, int soLuongUidFrom, int soLuongUidTo, int soLuongBaiFrom, int soLuongBaiTo, int delayFrom, int delayTo, int typeID, bool isReaction, string typeReaction, bool isComment, List<string> lstComment, bool isTuDongXoaUid, bool isSendAnh, string pathFolderImage, string tenHanhDong, string id_HanhDong)
		{
			string text = "";
			string text2 = "";
			int num = 0;
			new List<string>();
			string html = "";
			List<string> list = new List<string>();
			if (!isTuDongXoaUid)
			{
				list = CloneList(dicHDSpamBaiVietID[id_HanhDong]);
			}
			List<string> list2 = new List<string>();
			lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
			list2 = CloneList(lstComment);
			List<string> lstFrom = new List<string>();
			List<string> list3 = new List<string>();
			if (isSendAnh)
			{
				lstFrom = Directory.GetFiles(pathFolderImage).ToList();
				list3 = CloneList(lstFrom);
			}
			try
			{
				int num2 = rd.Next(soLuongUidFrom, soLuongUidTo + 1);
				int num3 = 0;
				while (num3 < num2)
				{
					string text3 = "";
					if (isTuDongXoaUid)
					{
						lock (dicHDSpamBaiVietID)
						{
							if (dicHDSpamBaiVietID[id_HanhDong].Count == 0)
							{
								break;
							}
							int index = rd.Next(0, dicHDSpamBaiVietID[id_HanhDong].Count);
							text3 = dicHDSpamBaiVietID[id_HanhDong][index];
							dicHDSpamBaiVietID[id_HanhDong].RemoveAt(index);
							goto IL_0238;
						}
					}
					if (list.Count != 0)
					{
						text3 = list[rd.Next(0, list.Count)];
						list.Remove(text3);
						goto IL_0238;
					}
					break;
					IL_0238:
					while (true)
					{
						switch (typeID)
						{
						case 2:
							device.GotoPageQuick(text3);
							break;
						case 1:
							device.GotoGroupQuick(text3);
							break;
						case 0:
							device.GotoProfileQuick(text3);
							break;
						}
						device.DelayTime(2.0);
						num = CheckGoToIDSuccess(device, indexRow, statusProxy);
						if (num != 0)
						{
							if (num == 2)
							{
								continue;
							}
							if (num == 3)
							{
								break;
							}
							SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num3 + 1}/{num2})...");
							int randomInt = device.GetRandomInt(soLuongBaiFrom, soLuongBaiTo);
							bool flag = false;
							for (int i = 0; i < randomInt; i++)
							{
								flag = false;
								for (int j = 0; j < 15; j++)
								{
									html = device.GetHtml();
									if (device.CheckExistTexts(html, 0.0, "double tap and hold to", "like button") <= 0)
									{
										if (device.ScrollAndCheckScreenNotChange())
										{
											break;
										}
										device.DelayTime(1.0);
										continue;
									}
									flag = true;
									break;
								}
								if (!flag)
								{
									break;
								}
								if (isReaction)
								{
									string text4 = device.GetListBoundsByText("double tap and hold to", html).LastOrDefault();
									if (string.IsNullOrEmpty(text4))
									{
										text4 = device.GetListBoundsByText("like button", html).LastOrDefault();
									}
									if (!string.IsNullOrEmpty(text4))
									{
										SetStatusAccount(indexRow, statusProxy + Language.GetValue("Tha\u0309 ca\u0309m xu\u0301c ba\u0300i viê\u0301t..."));
										device.LoadStatusLD("Interact Post");
										if (device.TapLongByBounds(text4, "[0,100][320,480]"))
										{
											device.DelayTime(2.0);
											int typeReaction2 = Convert.ToInt32(typeReaction[rd.Next(0, typeReaction.Length)].ToString() ?? "");
											device.ClickReactions(typeReaction2);
											device.DelayRandom(2.0, 3.0);
										}
										html = device.GetHtml();
									}
								}
								if (isComment || isSendAnh)
								{
									string text5 = device.GetListBoundsByText("comment", html).LastOrDefault();
									if (!string.IsNullOrEmpty(text5))
									{
										SetStatusAccount(indexRow, statusProxy + Language.GetValue("Comment ba\u0300i viê\u0301t..."));
										device.LoadStatusLD("Comment Post");
										device.TapByBounds(text5);
										if (isComment)
										{
											string text6 = device.GetListBoundsByText("write a", "", 10).LastOrDefault();
											if (!string.IsNullOrEmpty(text6))
											{
												if (list2.Count == 0)
												{
													list2 = CloneList(lstComment);
												}
												text = list2.OrderBy((string t) => Guid.NewGuid()).First();
												list2.Remove(text);
												text = MCommon.Common.SpinText(text, rd);
												text = GetIconFacebook.ProcessString(text, rd);
												device.TapByBounds(text6);
												device.TapByBounds(text6);
												device.DelayTime(1.0);
												device.InputTextWithUnicode(text + " ");
												device.DelayTime(2.0);
											}
										}
										if (isSendAnh)
										{
											lock (lock_useImage)
											{
												if (list3.Count == 0)
												{
													list3 = CloneList(lstFrom);
												}
												if (list3.Count > 0)
												{
													text2 = list3.OrderBy((string t) => Guid.NewGuid()).First();
													device.PushImageToDevice(text2);
													device.DelayRandom(1.5, 2.0);
													if (device.TapByText("show photos and videos", "", 10))
													{
														for (int k = 0; k < 5; device.DelayTime(1.0), k++)
														{
															html = device.GetHtml();
															switch (device.CheckExistTexts(html, 0.0, "\"allow\"", "\"enable gallery access", "\"want to upload your photos", "photo"))
															{
															case 1:
																device.TapByText("\"allow\"", html);
																continue;
															case 2:
																device.TapByText("\"enable gallery access", html);
																continue;
															case 3:
																device.TapByText("\"want to upload your photos", html);
																device.DelayTime(2.0);
																device.GotoBack();
																continue;
															default:
																continue;
															case 4:
																break;
															}
															break;
														}
														device.DelayRandom(2.0, 3.0);
														device.TapByText("photo", html);
														device.DelayTime(1.0);
														device.GotoBack();
														device.DelayTime(1.0);
													}
												}
											}
										}
										if (device.TapByText("send", "", 5))
										{
											device.DelayTime(3.0);
											for (int l = 0; l < 30; l++)
											{
												device.DelayTime(1.0);
												if (!device.CheckExistImage("DataClick\\image\\posting"))
												{
													break;
												}
											}
										}
										device.GotoBack(2);
									}
								}
								if (device.ScrollAndCheckScreenNotChange(200) || device.ScrollAndCheckScreenNotChange(200))
								{
									break;
								}
								device.LoadStatusLD("Delay");
								device.DelayRandom(delayFrom, delayTo);
							}
						}
						num3++;
						goto IL_09c2;
					}
					break;
					IL_09c2:;
				}
			}
			catch
			{
			}
			return 0;
		}

		public int HDBuffTinNhanProfile(int indexRow, string statusProxy, Chrome chrome, int soLuongUidFrom, int soLuongUidTo, int soLuongAnhFrom, int soLuongAnhTo, int delayFrom, int delayTo, bool isNhanTinVanBan, List<string> lstContent, Random rd, string tenHanhDong = "", bool isSendAnh = false, string pathFolderImage = "", bool isTuDongXoaUid = false, string id_HanhDong = "", bool ckbTuongTacKhiNhanTin = false, int typeTuongTacKhiNhanTin = 0, bool ckbTuongTacKhiNhanTinLike = false, bool ckbTuongTacKhiNhanTinComment = false, List<string> lstTuongTacKhiNhanTinComment = null, int typeNganCachComment = 0)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			string text = "";
			string text2 = "";
			List<string> list = new List<string>();
			lstContent = MCommon.Common.RemoveEmptyItems(lstContent);
			list = CloneList(lstContent);
			List<string> lstFrom = new List<string>();
			List<string> list2 = new List<string>();
			if (isSendAnh)
			{
				lstFrom = Directory.GetFiles(pathFolderImage).ToList();
				list2 = CloneList(lstFrom);
			}
			List<string> list3 = new List<string>();
			if (!isTuDongXoaUid)
			{
				list3 = CloneList(dicUidTinNhanProfile[id_HanhDong]);
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			try
			{
				int num5 = rd.Next(soLuongUidFrom, soLuongUidTo + 1);
				int num6 = 0;
				while (num6 < num5)
				{
					string text3 = "";
					if (isTuDongXoaUid)
					{
						lock (dicUidTinNhanProfile)
						{
							if (dicUidTinNhanProfile[id_HanhDong].Count == 0)
							{
								break;
							}
							text3 = dicUidTinNhanProfile[id_HanhDong][rd.Next(0, dicUidTinNhanProfile[id_HanhDong].Count)];
							dicUidTinNhanProfile[id_HanhDong].Remove(text3);
							goto IL_01fd;
						}
					}
					if (list3.Count != 0)
					{
						text3 = list3[rd.Next(0, list3.Count)];
						list3.Remove(text3);
						goto IL_01fd;
					}
					break;
					IL_01fd:
					if (ckbTuongTacKhiNhanTin && typeTuongTacKhiNhanTin == 0)
					{
						do
						{
							chrome.GotoURL("https://m.facebook.com/" + text3);
							chrome.DelayTime(2.0);
							num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						}
						while (num4 == 1);
						if (new List<int> { -3, -2, -1, 2 }.Contains(num4))
						{
							return -1;
						}
						string text4 = chrome.ExecuteScript("return document.documentElement.innerHTML.match(new RegExp('<title>(.*?)</title>'))[1]").ToString();
						text4 = text4.Split('-')[0].Trim();
						int num7 = 0;
						int num8 = 0;
						if (chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{0}]") == 1)
						{
							num7 = 0;
							if (Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
							{
								num7++;
							}
							if (chrome.CheckChromeClosed())
							{
								return -2;
							}
							chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "]");
							DelayThaoTacNho(3);
							if (ckbTuongTacKhiNhanTinLike && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")))
							{
								chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')");
								num7++;
								if (Convert.ToBoolean(chrome.ExecuteScript($"var output='false';var x=document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a');  if(x!=null) output=(JSON.parse(x.getAttribute('data-store')).reaction==0)+''; return output;").ToString()))
								{
									DelayThaoTacNho();
									chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a");
									DelayThaoTacNho();
								}
							}
							if (ckbTuongTacKhiNhanTinComment && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")))
							{
								num7++;
								chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]");
								DelayThaoTacNho();
								if (chrome.CheckExistElement("[data-sigil=\"textarea mufi-composer m-textarea-input\"]", 5.0) == 1)
								{
									DelayThaoTacNho();
									chrome.ScrollSmooth("document.querySelector('[data-sigil =\"textarea mufi-composer m-textarea-input\"]')");
									DelayThaoTacNho();
									List<string> list4 = new List<string>();
									if (list4.Count == 0)
									{
										list4 = CloneList(lstTuongTacKhiNhanTinComment);
									}
									string item = list4[rd.Next(0, list4.Count)];
									list4.Remove(item);
									item = MCommon.Common.SpinText(item, rd);
									item = item.Replace("[u]", text4);
									chrome.SendKeys(4, "[data-sigil =\"textarea mufi-composer m-textarea-input\"]", item + " ", 0.1);
									DelayThaoTacNho(3);
									for (int i = 0; i < 10; i++)
									{
										if (chrome.Click(2, "submit") == 1)
										{
											break;
										}
										MCommon.Common.DelayTime(1.0);
									}
									DelayThaoTacNho(2);
								}
								chrome.GotoBackPage();
								DelayThaoTacNho();
							}
						}
					}
					do
					{
						chrome.GotoURL("https://m.facebook.com/messages/read/?fbid=" + text3);
						DelayThaoTacNho();
						num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
					}
					while (num4 == 1);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
					{
						if (chrome.CheckExistElement("[name=\"body\"]", 10.0) == 1)
						{
							if (isSendAnh)
							{
								int num9 = rd.Next(soLuongAnhFrom, soLuongAnhTo + 1);
								num2 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"touchable\"]>img').length"));
								if (chrome.CheckExistElement("[data-sigil=\"m-raw-file-input\"]") == 1)
								{
									for (int j = 0; j < num9; j++)
									{
										if (list2.Count == 0)
										{
											list2 = CloneList(lstFrom);
										}
										text2 = list2[rd.Next(0, list2.Count)];
										list2.Remove(text2);
										chrome.SendKeys(4, "[data-sigil=\"m-raw-file-input\"]", text2);
										chrome.DelayTime(1.0);
									}
								}
								for (int k = 0; k < 60; k++)
								{
									num3 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"touchable\"]>img').length"));
									if (num3 >= num9 + num2)
									{
										break;
									}
									chrome.DelayTime(1.0);
								}
								DelayThaoTacNho();
							}
							if (isNhanTinVanBan)
							{
								if (list.Count == 0)
								{
									list = CloneList(lstContent);
								}
								text = list[rd.Next(0, list.Count)];
								list.Remove(text);
								text = MCommon.Common.SpinText(text, rd);
								string newValue = chrome.ExecuteScript("return document.querySelector('[data-sigil=\" token\"]').innerText.replace('×','').trim()").ToString();
								text = text.Replace("[u]", newValue);
								chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[name=\"body\"]", text, 0.1);
								DelayThaoTacNho();
							}
							num4 = chrome.CheckExistElements(5.0, "[name=\"Send\"]", "[name=\"send\"]");
							if (num4 == 1)
							{
								chrome.Click(4, "[name=\"Send\"]");
							}
							else
							{
								chrome.Click(4, "[name=\"send\"]");
							}
							DelayThaoTacNho();
							num++;
							SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num5})...");
							if (chrome.CheckChromeClosed())
							{
								return -2;
							}
							chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
							if (ckbTuongTacKhiNhanTin && typeTuongTacKhiNhanTin == 1)
							{
								do
								{
									chrome.GotoURL("https://m.facebook.com/" + text3);
									chrome.DelayTime(2.0);
									num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								}
								while (num4 == 1);
								if (new List<int> { -3, -2, -1, 2 }.Contains(num4))
								{
									return -1;
								}
								string text5 = chrome.ExecuteScript("return document.documentElement.innerHTML.match(new RegExp('<title>(.*?)</title>'))[1]").ToString();
								text5 = text5.Split('-')[0].Trim();
								int num10 = 0;
								int num11 = 0;
								if (chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{0}]") == 1)
								{
									num10 = 0;
									if (Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num11}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num11}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")) || Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num11}].querySelector('[data-sigil=\"share-popup\"]')!=null)+''")))
									{
										num10++;
									}
									if (chrome.CheckChromeClosed())
									{
										return -2;
									}
									chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num11 + "]");
									DelayThaoTacNho(3);
									if (ckbTuongTacKhiNhanTinLike && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num11}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")))
									{
										chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num11 + "].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')");
										num10++;
										if (Convert.ToBoolean(chrome.ExecuteScript($"var output='false';var x=document.querySelectorAll('[data-store*=\"linkdata\"]')[{num11}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a');  if(x!=null) output=(JSON.parse(x.getAttribute('data-store')).reaction==0)+''; return output;").ToString()))
										{
											DelayThaoTacNho();
											chrome.Click(4, "[data-store*=\"linkdata\"]", num11, 4, "[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a");
											DelayThaoTacNho();
										}
									}
									if (ckbTuongTacKhiNhanTinComment && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num11}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")))
									{
										num10++;
										chrome.Click(4, "[data-store*=\"linkdata\"]", num11, 4, "[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]");
										DelayThaoTacNho();
										if (chrome.CheckExistElement("[data-sigil=\"textarea mufi-composer m-textarea-input\"]", 5.0) == 1)
										{
											DelayThaoTacNho();
											chrome.ScrollSmooth("document.querySelector('[data-sigil =\"textarea mufi-composer m-textarea-input\"]')");
											DelayThaoTacNho();
											List<string> list5 = new List<string>();
											if (list5.Count == 0)
											{
												list5 = CloneList(lstTuongTacKhiNhanTinComment);
											}
											string item2 = list5[rd.Next(0, list5.Count)];
											list5.Remove(item2);
											item2 = MCommon.Common.SpinText(item2, rd);
											item2 = item2.Replace("[u]", text5);
											chrome.SendKeys(4, "[data-sigil =\"textarea mufi-composer m-textarea-input\"]", item2 + " ", 0.1);
											DelayThaoTacNho(3);
											for (int l = 0; l < 10; l++)
											{
												if (chrome.Click(2, "submit") == 1)
												{
													break;
												}
												MCommon.Common.DelayTime(1.0);
											}
											DelayThaoTacNho(2);
										}
										chrome.GotoBackPage();
										DelayThaoTacNho();
									}
								}
							}
						}
						num6++;
						continue;
					}
					return -1;
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDNhanTinBanBeRandom(int indexRow, string statusProxy, Chrome chrome, int soLuongBanFrom, int soLuongBanTo, List<string> lstContent, int delayFrom, int delayTo, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			try
			{
				List<string> list = new List<string>();
				list = CloneList(lstContent);
				string text = "";
				int num2 = rd.Next(soLuongBanFrom, soLuongBanTo + 1);
				if (num2 != 0)
				{
					while (true)
					{
						if (CommonChrome.GoToFriend(chrome) != -2)
						{
							int num3 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
							if (num3 == 1)
							{
								continue;
							}
							if (!new List<int> { -3, -2, -1, 2 }.Contains(num3))
							{
								CommonChrome.ScrollRandom(chrome);
								while (true)
								{
									num3 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
									if (num3 == 1)
									{
										break;
									}
									if (new List<int> { -3, -2, -1, 2 }.Contains(num3))
									{
										return -1;
									}
									int num4 = chrome.CountElement("[data-sigil=\"undoable-action\"]");
									if (num4 > 0)
									{
										int index = Base.rd.Next(0, num4);
										chrome.ScrollSmooth("document.querySelectorAll('[data-sigil=\"undoable-action\"]>div:nth-child(1)>a')[" + index + "]");
										DelayThaoTacNho();
										chrome.Click(4, "[data-sigil=\"undoable-action\"]>div:nth-child(1)>a", index);
										DelayThaoTacNho(2);
										if (chrome.CheckExistElement("[data-sigil=\"hq-profile-logging-action-bar-button\"]>a", 3.0) == 1)
										{
											CommonChrome.ScrollRandom(chrome);
											chrome.ScrollSmooth("document.querySelector('[data-sigil=\"hq-profile-logging-action-bar-button\"]>a')");
											DelayThaoTacNho();
											chrome.Click(4, "[data-sigil=\"hq-profile-logging-action-bar-button\"]>a");
											DelayThaoTacNho(2);
											if (chrome.CheckExistElement("[name=\"body\"]", 5.0) != 1)
											{
												goto IL_050a;
											}
											if (list.Count == 0)
											{
												list = CloneList(lstContent);
											}
											text = list[rd.Next(0, list.Count)];
											list.Remove(text);
											text = MCommon.Common.SpinText(text, rd);
											string newValue = chrome.ExecuteScript("return document.querySelector('[data-sigil=\" token\"]').innerText.replace('×','').trim()").ToString();
											text = text.Replace("[u]", newValue);
											DelayThaoTacNho();
											switch (setting_general.GetValueInt("tocDoGoVanBan"))
											{
											case 0:
												chrome.SendKeys(Base.rd, 4, "[name=\"body\"]", text, 0.1);
												break;
											case 1:
												chrome.SendKeys(4, "[name=\"body\"]", text, 0.1);
												break;
											case 2:
												chrome.SendKeys(4, "[name=\"body\"]", text);
												break;
											}
											DelayThaoTacNho();
											num3 = chrome.CheckExistElements(5.0, "[name=\"Send\"]", "[name=\"send\"]");
											if (num3 == 1)
											{
												chrome.Click(4, "[name=\"Send\"]");
											}
											else
											{
												chrome.Click(4, "[name=\"send\"]");
											}
											DelayThaoTacNho();
											num++;
											SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
											if (chrome.CheckChromeClosed())
											{
												return -2;
											}
											chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
											if (num < num2)
											{
												goto IL_050a;
											}
										}
									}
									goto end_IL_003f;
									IL_050a:
									chrome.GotoBackPage();
									chrome.DelayThaoTacNho();
									chrome.GotoBackPage();
									chrome.DelayThaoTacNho();
									if (chrome.CheckExistElement("[data-sigil=\"undoable-action\"]") != 1)
									{
										chrome.GotoBackPage();
										chrome.DelayThaoTacNho();
										if (chrome.CheckExistElement("[data-sigil=\"undoable-action\"]") != 1)
										{
											break;
										}
									}
								}
								continue;
							}
							return -1;
						}
						return -2;
					}
				}
				end_IL_003f:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDNhanTinBanBe(int indexRow, string statusProxy, Chrome chrome, string token, string cookie, int soLuongBanFrom, int soLuongBanTo, List<string> lstContent, int delayFrom, int delayTo, string proxy, int typeProxy, Random rd, string tenHanhDong = "", int typeDoiTuong = 0, List<string> lstUidChiDinh = null)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int result = 0;
			try
			{
				List<string> list = new List<string>();
				if (typeDoiTuong == 0)
				{
					HDNhanTinBanBeRandom(indexRow, statusProxy, chrome, soLuongBanFrom, soLuongBanTo, lstContent, delayFrom, delayTo, rd, tenHanhDong);
				}
				else
				{
					list = CloneList(lstUidChiDinh);
					List<string> list2 = new List<string>();
					list2 = CloneList(lstContent);
					string text = "";
					string text2 = "";
					int count = list.Count;
					int num = 0;
					int num2 = rd.Next(soLuongBanFrom, soLuongBanTo + 1);
					for (int i = 0; i < count; i++)
					{
						if (num == num2)
						{
							break;
						}
						num++;
						if (list2.Count == 0)
						{
							list2 = CloneList(lstContent);
						}
						text = list2[rd.Next(0, list2.Count)];
						text2 = list[rd.Next(0, list.Count)];
						list.Remove(text2);
						list2.Remove(text);
						text = MCommon.Common.SpinText(text, rd);
						int num3;
						do
						{
							chrome.GotoURL("https://m.facebook.com/messages/read/?fbid=" + text2);
							DelayThaoTacNho(2);
							num3 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						}
						while (num3 == 1);
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num3))
						{
							if (chrome.CheckExistElement("[name=\"body\"]", 5.0) == 1)
							{
								DelayThaoTacNho();
								chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[name=\"body\"]", text, 0.1);
								DelayThaoTacNho();
								num3 = chrome.CheckExistElements(5.0, "[name=\"Send\"]", "[name=\"send\"]");
								if (num3 == 1)
								{
									chrome.Click(4, "[name=\"Send\"]");
								}
								else
								{
									chrome.Click(4, "[name=\"send\"]");
								}
								DelayThaoTacNho();
								if (tenHanhDong == "")
								{
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang nhắn tin bạn bè") + $" ({num}/{num2})...");
								}
								else
								{
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
								}
								chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
							}
							continue;
						}
						return -1;
					}
				}
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		public int HDChocBanBe(int indexRow, string statusProxy, Chrome chrome, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, Random rd, string tenHanhDong = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = 0;
			try
			{
				while (true)
				{
					IL_028c:
					if (CommonChrome.GoToPoke(chrome) != -2)
					{
						int num3 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num3 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num3))
						{
							int num4 = rd.Next(soLuongFrom, soLuongTo + 1);
							while (num < num4)
							{
								num3 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								if (num3 != 1)
								{
									if (!new List<int> { -3, -2, -1, 2 }.Contains(num3))
									{
										if (chrome.CheckExistElement("[data-sigil=\"touchable ajaxify\"]", 5.0) == 1)
										{
											num2 = 0;
											chrome.ScrollSmooth("document.querySelector('[data-sigil=\"touchable ajaxify\"]')");
											DelayThaoTacNho();
											chrome.Click(4, "[data-sigil=\"touchable ajaxify\"]");
											num++;
											DelayThaoTacNho(2);
											if (tenHanhDong == "")
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang chọc bạn bè") + $" ({num}/{num4})...");
											}
											else
											{
												SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num4})...");
											}
											chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
										}
										else
										{
											chrome.Refresh();
											num2++;
											if (num2 == 2)
											{
												break;
											}
										}
										continue;
									}
									return -1;
								}
								goto IL_028c;
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

		private int HDOnOff2FA(int indexRow, string statusProxy, Device device, JSON_Settings cauHinh)
		{
			string cellAccount = GetCellAccount(indexRow, "cId");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			int valueInt = cauHinh.GetValueInt("typeOnOff2FA");
			bool valueBool = cauHinh.GetValueBool("ckbOff2FA");
			if (valueInt == 1)
			{
				SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang bật 2FA..."), device);
				int result = 0;
				string text = "";
				int num = 0;
				bool flag = false;
				try
				{
					while (true)
					{
						IL_081b:
						device.GotoNewFeedQuick();
						num++;
						if (!(flag = device.TapByImage("DataClick\\image\\menu", null, 10)))
						{
							break;
						}
						flag = false;
						num++;
						for (int i = 0; i < 10; i++)
						{
							text = device.GetHtml();
							if (!device.CheckExistText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", text))
							{
								if (!device.CheckExistText("settings &amp; privacy, header. section is expanded. double-tap to collapse the section.", text))
								{
									if (device.ScrollAndCheckScreenNotChange(500))
									{
										break;
									}
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							device.TapByText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", text);
							flag = true;
							break;
						}
						if (!flag)
						{
							break;
						}
						flag = false;
						num++;
						for (int j = 0; j < 10; j++)
						{
							if (!device.TapByImage("DataClick\\image\\caidat"))
							{
								if (j % 2 == 1 && device.ScrollAndCheckScreenNotChange())
								{
									break;
								}
								device.DelayTime(1.0);
								continue;
							}
							flag = true;
							break;
						}
						if (!flag)
						{
							break;
						}
						flag = false;
						for (int k = 0; k < 10; k++)
						{
							text = device.GetHtml();
							if (!device.TapByText("password and security", text) && !device.TapByText("security and login", text))
							{
								if (device.ScrollAndCheckScreenNotChange())
								{
									break;
								}
								device.DelayTime(1.0);
								continue;
							}
							flag = true;
							break;
						}
						if (!flag)
						{
							break;
						}
						while (true)
						{
							flag = false;
							for (int l = 0; l < 10; l++)
							{
								text = device.GetHtml();
								if (!device.TapByText("use two-factor authentication", text))
								{
									if (device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									device.DelayTime(1.0);
									continue;
								}
								flag = true;
								break;
							}
							if (!flag)
							{
								break;
							}
							flag = false;
							int num2 = 0;
							while (true)
							{
								if (num2 < 10)
								{
									text = device.GetHtml();
									if (!device.TapByText("continue", text))
									{
										if (!device.CheckExistText("two-factor authentication is on", text))
										{
											goto IL_051d;
										}
										bool flag2 = false;
										if (valueBool)
										{
											if (device.TapByImageWait("DataClick\\image\\turnoff") && device.TapByImageWait("DataClick\\image\\turnoffxanh"))
											{
												for (int m = 0; m < 10; m++)
												{
													text = device.GetHtml();
													if (!device.CheckExistText("incorrect password", text))
													{
														if (device.CheckExistText("\"password\"", text))
														{
															if (cellAccount2.Trim() == "")
															{
																break;
															}
															device.TapByText("\"password\"", text);
															device.InputTextWithUnicode(cellAccount2);
															device.TapByText("\"continue\"");
														}
														else if (device.CheckExistText("two-factor authentication", text))
														{
															flag2 = true;
															break;
														}
														device.DelayTime(1.0);
														continue;
													}
													SetInfoAccount(cellAccount, indexRow, "Changed pass");
													break;
												}
											}
											if (flag2)
											{
												break;
											}
											goto IL_051d;
										}
									}
									else
									{
										flag = true;
									}
								}
								if (flag)
								{
									goto IL_0571;
								}
								goto end_IL_009b;
								IL_051d:
								device.DelayTime(1.0);
								num2++;
							}
							continue;
							IL_0571:
							if (!(flag = device.CheckExistText("set up via third party authenticator", "", 10.0)))
							{
								break;
							}
							Bitmap bitmap = null;
							string text2 = "";
							for (int n = 0; n < 5; n++)
							{
								bitmap = device.ScreenShoot();
								text2 = MCommon.Common.ByPassQRCode(bitmap);
								text2 = Regex.Match(text2, "secret=(.*?)&").Groups[1].Value;
								if (!string.IsNullOrEmpty(text2))
								{
									break;
								}
								device.DelayTime(1.0);
							}
							if (string.IsNullOrEmpty(text2))
							{
								break;
							}
							int num3 = 0;
							while (flag = device.TapByText("\"continue\"", "", 10))
							{
								flag = false;
								if (device.TapByImage("DataClick\\image\\enterthe6digitcode", null, 10))
								{
									string totp = MCommon.Common.GetTotp(text2);
									device.InputTextWithUnicode(totp);
									device.TapByText("\"continue\"");
									int num4 = 0;
									while (num4 < 10)
									{
										if (!device.CheckExistImage("DataClick\\image\\thiscodeisntright"))
										{
											text = device.GetHtml();
											if (!device.CheckExistText("incorrect password", text))
											{
												if (device.CheckExistText("\"password\"", text))
												{
													if (cellAccount2.Trim() == "")
													{
														break;
													}
													device.TapByText("\"password\"", text);
													device.InputTextWithUnicode(cellAccount2);
													device.TapByText("\"continue\"");
												}
												else if (device.CheckExistText("two-factor authentication is on", text))
												{
													flag = true;
													break;
												}
												device.DelayTime(1.0);
												num4++;
												continue;
											}
											SetInfoAccount(cellAccount, indexRow, "Changed pass");
											break;
										}
										goto IL_0796;
									}
								}
								goto IL_0810;
								IL_0810:
								if (flag)
								{
									SetCellAccount(indexRow, "cFa2", text2);
									CommonSQL.UpdateFieldToAccount(cellAccount, "fa2", text2);
									break;
								}
								goto IL_081b;
								IL_0796:
								num3++;
								if (num3 < 3)
								{
									device.TapByText("\"back\"");
									continue;
								}
								goto IL_0810;
							}
							break;
						}
						break;
					}
					end_IL_009b:;
				}
				catch (Exception)
				{
				}
				return result;
			}
			SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang tắt 2FA..."), device);
			int result2 = 0;
			string text3 = "";
			int num5 = 0;
			bool flag3 = false;
			try
			{
				device.GotoNewFeedQuick();
				num5++;
				if (flag3 = device.TapByImage("DataClick\\image\\menu", null, 10))
				{
					flag3 = false;
					num5++;
					for (int num6 = 0; num6 < 10; num6++)
					{
						text3 = device.GetHtml();
						if (!device.CheckExistText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", text3))
						{
							if (!device.CheckExistText("settings &amp; privacy, header. section is expanded. double-tap to collapse the section.", text3))
							{
								if (device.ScrollAndCheckScreenNotChange(500))
								{
									break;
								}
								device.DelayTime(1.0);
								continue;
							}
							flag3 = true;
							break;
						}
						device.TapByText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", text3);
						flag3 = true;
						break;
					}
					if (flag3)
					{
						flag3 = false;
						num5++;
						for (int num7 = 0; num7 < 10; num7++)
						{
							if (!device.TapByImage("DataClick\\image\\caidat"))
							{
								if (num7 % 2 == 1 && device.ScrollAndCheckScreenNotChange())
								{
									break;
								}
								device.DelayTime(1.0);
								continue;
							}
							flag3 = true;
							break;
						}
						if (flag3)
						{
							flag3 = false;
							for (int num8 = 0; num8 < 10; num8++)
							{
								text3 = device.GetHtml();
								if (!device.TapByText("password and security", text3) && !device.TapByText("security and login", text3))
								{
									if (device.ScrollAndCheckScreenNotChange())
									{
										break;
									}
									device.DelayTime(1.0);
									continue;
								}
								flag3 = true;
								break;
							}
							if (flag3)
							{
								flag3 = false;
								for (int num9 = 0; num9 < 10; num9++)
								{
									text3 = device.GetHtml();
									if (!device.TapByText("use two-factor authentication", text3))
									{
										if (device.ScrollAndCheckScreenNotChange())
										{
											break;
										}
										device.DelayTime(1.0);
										continue;
									}
									flag3 = true;
									break;
								}
								if (flag3)
								{
									flag3 = false;
									int num10 = 0;
									while (true)
									{
										if (num10 < 10)
										{
											text3 = device.GetHtml();
											if (!device.CheckExistText("two-factor authentication is on", text3))
											{
												if (!device.CheckExistText("authentication app", text3))
												{
													device.DelayTime(1.0);
													num10++;
													continue;
												}
												flag3 = true;
												break;
											}
											flag3 = true;
										}
										if (!flag3)
										{
											break;
										}
										flag3 = false;
										if (!device.TapByImageWait("DataClick\\image\\turnoff") || !device.TapByImageWait("DataClick\\image\\turnoffxanh"))
										{
											break;
										}
										for (int num11 = 0; num11 < 10; num11++)
										{
											text3 = device.GetHtml();
											if (!device.CheckExistText("incorrect password", text3))
											{
												if (device.CheckExistText("\"password\"", text3))
												{
													if (cellAccount2.Trim() == "")
													{
														break;
													}
													device.TapByText("\"password\"", text3);
													device.InputTextWithUnicode(cellAccount2);
													device.TapByText("\"continue\"");
												}
												else if (device.CheckExistText("two-factor authentication", text3))
												{
													flag3 = true;
													break;
												}
												device.DelayTime(1.0);
												continue;
											}
											SetInfoAccount(cellAccount, indexRow, "Changed pass");
											break;
										}
										break;
									}
								}
							}
						}
					}
				}
			}
			catch
			{
			}
			if (flag3)
			{
				SetCellAccount(indexRow, "cFa2", "");
				CommonSQL.UpdateFieldToAccount(cellAccount, "fa2", "");
			}
			return result2;
		}

		private int HDDongBoDanhBa(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, bool ckbTuDongXoa, bool isAutoAddFriend, int soLuongKetBanFrom, int soLuongKetBanTo, int delayKetBanFrom, int delayKetBanTo, string idHanhDong, string tenHanhDong)
		{
			int result = 0;
			try
			{
				int num = device.GetRandomInt(nudSoLuongFrom, nudSoLuongTo);
				List<string> list = new List<string>();
				if (!ckbTuDongXoa)
				{
					list = dicSdt[idHanhDong].GetRange(0, num);
				}
				else
				{
					lock (dicSdt)
					{
						if (dicSdt[idHanhDong].Count > 0)
						{
							if (num > dicSdt[idHanhDong].Count)
							{
								num = dicSdt[idHanhDong].Count;
							}
							list = dicSdt[idHanhDong].GetRange(0, num);
							dicSdt[idHanhDong].RemoveRange(0, num);
						}
					}
				}
				if (list.Count > 0)
				{
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Import danh bạ..."));
					device.ImportContact(list);
					device.DelayTime(10.0);
					SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + " " + tenHanhDong + "...");
					device.SyncContactByFb();
					if (isAutoAddFriend)
					{
						List<string> listBoundsByText = device.GetListBoundsByText("add friend", "", 3);
						if (listBoundsByText.Count > 0)
						{
							int num2 = 0;
							int num3 = rd.Next(soLuongKetBanFrom, soLuongKetBanTo + 1);
							if (num3 != 0)
							{
								int num4 = 0;
								for (int i = 0; i < num3 + 10; i++)
								{
									if (device.CheckIsLive())
									{
										num4++;
										if (num4 % 3 == 0 && CheckStatusDevice(device, indexRow, statusProxy) != 0)
										{
											break;
										}
										string text = listBoundsByText[device.GetRandomInt(0, listBoundsByText.Count - 1)];
										if (text != "" && device.CheckBoundsContainBounds("[0,130][320,480]", text) && device.TapByBounds(text))
										{
											num2++;
											SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong}: Add Friend ({num2}/{num3})...");
											device.DelayRandom(delayKetBanFrom, delayKetBanTo);
										}
										if (num2 >= num3)
										{
											break;
										}
										listBoundsByText = device.GetListBoundsByText("add friend");
										if (listBoundsByText.Count == 0 || (listBoundsByText.Count == 1 && !device.CheckBoundsContainBounds("[0,130][320,480]", listBoundsByText[0])))
										{
											if (device.ScrollAndCheckScreenNotChange(device.GetRandomInt(200, 300)))
											{
												break;
											}
											listBoundsByText = device.GetListBoundsByText("add friend");
											if (listBoundsByText.Count == 0 || (listBoundsByText.Count == 1 && !device.CheckBoundsContainBounds("[0,130][320,480]", listBoundsByText[0])))
											{
												break;
											}
										}
										continue;
									}
									return -2;
								}
							}
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		private int HDKetBanTepUid(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, bool ckbTuongTac, int nudTimeFrom, int nudTimeTo, bool ckbTuongTacLike, int nudCountLikeFrom, int nudCountLikeTo, bool ckbTuongTacComment, List<string> lstComment, int nudCountCommentFrom, int nudCountCommentTo, bool ckbTuDongXoaUid, string idHanhDong, string tenHanhDong)
		{
			int num = 0;
			int randomInt = device.GetRandomInt(nudSoLuongFrom, nudSoLuongTo);
			string text = "";
			string html = "";
			List<string> list = new List<string>();
			if (!ckbTuDongXoaUid)
			{
				list = MCommon.Common.CloneList(dicUidCaNhan[idHanhDong]);
			}
			try
			{
				int num2 = 0;
				while (num2 < randomInt)
				{
					if (!ckbTuDongXoaUid)
					{
						if (list.Count != 0)
						{
							text = list[rd.Next(0, list.Count)];
							list.Remove(text);
							goto IL_0162;
						}
						break;
					}
					lock (dicUidCaNhan)
					{
						if (dicUidCaNhan[idHanhDong].Count == 0)
						{
							break;
						}
						text = dicUidCaNhan[idHanhDong][rd.Next(0, dicUidCaNhan[idHanhDong].Count)];
						dicUidCaNhan[idHanhDong].Remove(text);
						goto IL_0162;
					}
					IL_0162:
					while (true)
					{
						device.GotoProfileQuick(text);
						device.DelayTime(2.0);
						int num3 = CheckGoToProfileUidSuccess(device, indexRow, statusProxy);
						if (num3 != 0)
						{
							if (num3 == 2)
							{
								continue;
							}
							if (num3 == 3)
							{
								break;
							}
							if (device.CheckExistText("add friend", html) || device.CheckExistImage("DataClick/image/addfriend", null, 3))
							{
								if (!ckbTuongTac)
								{
									goto IL_02a7;
								}
								InteractTimelime(indexRow, statusProxy, device, nudTimeFrom, nudTimeTo, ckbTuongTacLike, nudCountLikeFrom, nudCountLikeTo, ckbTuongTacComment, nudCountCommentFrom, nudCountCommentTo, lstComment, isShareWall: false, 0, 0);
								while (true)
								{
									device.GotoProfileQuick(text);
									device.DelayTime(2.0);
									num3 = CheckGoToProfileUidSuccess(device, indexRow, statusProxy);
									if (num3 != 0)
									{
										if (num3 == 2)
										{
											continue;
										}
										goto IL_028f;
									}
									break;
								}
							}
							else
							{
								num2--;
							}
						}
						goto IL_0348;
						IL_02a7:
						if (device.TapByText("add friend", html) || device.TapByImage("DataClick/image/addfriend", null, 3))
						{
							num++;
							SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{randomInt})...");
							device.DelayRandom(nudDelayFrom, nudDelayTo);
						}
						else
						{
							num2--;
						}
						goto IL_0348;
						IL_0348:
						num2++;
						goto IL_0352;
						IL_028f:
						if (num3 != 3)
						{
							html = device.GetHtml();
							goto IL_02a7;
						}
						break;
					}
					break;
					IL_0352:;
				}
			}
			catch
			{
			}
			return num;
		}

		public int HDKetBanTepUid(int indexRow, string statusProxy, Chrome chrome, ref List<string> lstUid, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, bool isTrungNhau, Random rd, string tenHanhDong = "", bool isTuongTac = false, int soLuongBaiVietFrom = 0, int soLuongBaiVietTo = 0, int tuongTacDelayFrom = 0, int tuongTacDelayTo = 0, bool isLike = false, bool isComment = false, List<string> lstComment = null, bool isTuDongXoaUid = false, string id_HanhDong = "", string uid = "", string pass = "", string fa2 = "")
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			string text = "";
			string text2 = "";
			if (lstComment != null)
			{
				lstComment = MCommon.Common.RemoveEmptyItems(lstComment);
			}
			List<string> list = new List<string>();
			if (id_HanhDong != "")
			{
				if (!isTuDongXoaUid)
				{
					list = CloneList(dicUidCaNhan[id_HanhDong]);
				}
			}
			else if (isTrungNhau)
			{
				list = CloneList(lstUid);
			}
			try
			{
				int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
				for (int num3 = 0; num3 < num2; num3++)
				{
					if (isTrungNhau || (id_HanhDong != "" && !isTuDongXoaUid))
					{
						if (list.Count != 0)
						{
							text = list[rd.Next(0, list.Count)];
							list.Remove(text);
							goto IL_0579;
						}
						break;
					}
					lock (dicUidCaNhan)
					{
						if (dicUidCaNhan[id_HanhDong].Count == 0)
						{
							break;
						}
						text = dicUidCaNhan[id_HanhDong][rd.Next(0, dicUidCaNhan[id_HanhDong].Count)];
						dicUidCaNhan[id_HanhDong].Remove(text);
						goto IL_0579;
					}
					IL_0579:
					while (true)
					{
						IL_0579_2:
						chrome.GotoURL("https://m.facebook.com/" + text);
						DelayThaoTacNho(2);
						int num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						if (num4 == 1)
						{
							continue;
						}
						if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
						{
							text2 = chrome.ExecuteScript("var link='';var x=document.querySelectorAll('div');for(i=0;i<x.length;i++){if(x[i].getAttribute('data-sigil')!=null && x[i].getAttribute('data-sigil').includes('hq-profile-logging-action-bar-button')) {if(x[i].querySelector('a').getAttribute('href')!=null&& x[i].querySelector('a').getAttribute('href').includes('add_friend')) {link=x[i].querySelector('a').getAttribute('href');break;}}}; return link;").ToString();
							if (text2 != "")
							{
								if (isTuongTac)
								{
									int num5 = 0;
									int num6 = rd.Next(soLuongBaiVietFrom, soLuongBaiVietTo + 1);
									int num7 = 0;
									int num8 = -1;
									List<string> list2 = new List<string>();
									string text3 = "";
									int num9 = 0;
									while (num5 < num6)
									{
										num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
										if (num4 != 1)
										{
											if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
											{
												num8++;
												if (chrome.CheckExistElementv2($"document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}]") != 1)
												{
													break;
												}
												num7 = 0;
												if (!chrome.CheckChromeClosed())
												{
													chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "]");
													DelayThaoTacNho();
													if (isLike && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')!=null)+''")))
													{
														chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]')[" + num8 + "].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a')");
														num7++;
														if (Convert.ToBoolean(chrome.ExecuteScript($"var output='false';var x=document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a');  if(x!=null) output=(JSON.parse(x.getAttribute('data-store')).reaction==0)+''; return output;").ToString()))
														{
															DelayThaoTacNho();
															chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-store*=\"linkdata\"]>footer>div>div:nth-child(2)>div:nth-child(1)>a");
															DelayThaoTacNho();
														}
													}
													if (isComment && Convert.ToBoolean(chrome.ExecuteScript($"return (document.querySelectorAll('[data-store*=\"linkdata\"]')[{num8}].querySelector('[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]')!=null)+''")))
													{
														num7++;
														if (list2.Count == 0)
														{
															list2 = CloneList(lstComment);
														}
														text3 = list2[rd.Next(0, list2.Count)];
														list2.Remove(text3);
														chrome.Click(4, "[data-store*=\"linkdata\"]", num8, 4, "[data-sigil=\"feed-ufi-focus feed-ufi-trigger ufiCommentLink mufi-composer-focus\"]");
														DelayThaoTacNho();
														if (chrome.CheckExistElement("[data-sigil=\"textarea mufi-composer m-textarea-input\"]", 5.0) == 1)
														{
															DelayThaoTacNho();
															chrome.ScrollSmooth("document.querySelector('[data-sigil =\"textarea mufi-composer m-textarea-input\"]')");
															DelayThaoTacNho();
															chrome.SendKeysWithSpeed(setting_general.GetValueInt("tocDoGoVanBan"), 4, "[data-sigil =\"textarea mufi-composer m-textarea-input\"]", text3 + " ", 0.15);
															DelayThaoTacNho();
															chrome.Click(4, "[name=\"submit\"]");
															DelayThaoTacNho(2);
														}
														chrome.GotoBackPage();
														DelayThaoTacNho();
													}
													if (num7 > 0)
													{
														num9 = 0;
														num5++;
														if (tenHanhDong == "")
														{
															SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang kết bạn theo tệp uid") + $" ({num}/{num2}:{num5}/{num6})...");
														}
														else
														{
															SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2}:{num5}/{num6})...");
														}
														if (chrome.CheckChromeClosed())
														{
															return -2;
														}
													}
													else
													{
														num9++;
														if (num9 == 3)
														{
															break;
														}
													}
													chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
													continue;
												}
												return -2;
											}
											return -1;
										}
										goto IL_0579_2;
									}
								}
								DelayThaoTacNho();
								chrome.GotoURL("https://m.facebook.com/" + text2);
								num++;
								if (tenHanhDong == "")
								{
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang kết bạn theo tệp uid") + $" ({num}/{num2})...");
								}
								else
								{
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
								}
								if (!chrome.CheckChromeClosed())
								{
									chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
									break;
								}
								return -2;
							}
							num4 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
							if (num4 == 1)
							{
								continue;
							}
							if (!new List<int> { -3, -2, -1, 2 }.Contains(num4))
							{
								num3--;
								break;
							}
							return -1;
						}
						return -1;
					}
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDKetBanNewfeed(int indexRow, string statusProxy, Chrome chrome, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, Random rd, string tenHanhDong)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			try
			{
				int num2 = 0;
				int num3 = 5;
				int num4 = 0;
				int num5 = rd.Next(soLuongFrom, soLuongTo + 1);
				List<string> list = new List<string>();
				CommonChrome.GoToHome(chrome);
				DelayThaoTacNho(2);
				if (chrome.CheckExistElement("[data-sigil=\"mufi-inline\"]>div:nth-child(1) a", 10.0) == 1)
				{
					while (num < num5)
					{
						while (true)
						{
							int item = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
							if (!new List<int> { -3, -2, -1, 2 }.Contains(item))
							{
								if (chrome.ScrollSmooth("document.querySelectorAll('[data-store*=\"linkdata\"]>div>header>div:nth-child(2)>div>div>div>div>a')[" + num4 * 2 + "]") != 1)
								{
									break;
								}
								chrome.DelayTime(1.0);
								string text = chrome.ExecuteScript("return document.querySelectorAll('[data-store*=\"linkdata\"]>div>header>div:nth-child(2)>div>div>div>div>a')[" + num4 * 2 + "].href").ToString();
								if (text == "https://m.facebook.com/home.php#")
								{
									text = chrome.ExecuteScript("return document.querySelectorAll('[data-store*=\"linkdata\"]>div>header>div:nth-child(2)>div>div>div>div>a')[" + (num4 * 2 + 1) + "].href").ToString();
								}
								string value = Regex.Match(text, "fbid=(.*?)&").Groups[1].Value;
								if (value == "")
								{
									value = Regex.Match(text, "permalink/(.*?)/").Groups[1].Value;
								}
								if (!list.Contains(value))
								{
									list.Add(value);
									chrome.Click(4, "[data-sigil=\"m-feed-voice-subtitle\"] a", num4);
									DelayThaoTacNho();
									if (chrome.CheckExistElement("[data-sigil=\"m-mentions-expand\"]>div>div:nth-child(2) span", 10.0) == 1)
									{
										chrome.Click(4, "[data-sigil=\"m-mentions-expand\"] a");
										chrome.DelayThaoTacNho();
										if (chrome.CheckExistElement("[data-sigil=\"m-add-friend-flyout\"] button", 10.0) == 1)
										{
											int num6 = Convert.ToInt32(chrome.ExecuteScript("return document.querySelectorAll('[data-sigil=\"touchable m-add-friend\"] button').length").ToString());
											int num7 = 0;
											while (num7 < num6)
											{
												if (num != num5)
												{
													item = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
													if (new List<int> { -3, -2, -1, 2 }.Contains(item))
													{
														return -1;
													}
													chrome.ScrollSmooth("document.querySelectorAll('[data-sigil=\"touchable m-add-friend\"] button')[" + num7 + "]");
													chrome.DelayTime(1.0);
													chrome.Click(4, "[data-sigil=\"touchable m-add-friend\"] button", num7);
													chrome.DelayTime(1.0);
													num2 = (CommonChrome.SkipNotifyWhenAddFriend(chrome) ? (num2 + 1) : 0);
													if (num2 < num3)
													{
														num++;
														SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num5})...");
														chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
														num7++;
														continue;
													}
												}
												goto end_IL_003f;
											}
										}
										chrome.GotoBackPage(2);
										DelayThaoTacNho();
										num4++;
										goto IL_04d4;
									}
									num4++;
									chrome.GotoBackPage();
								}
								else
								{
									num4++;
								}
								continue;
							}
							return -1;
						}
						break;
						IL_04d4:;
					}
				}
				end_IL_003f:;
			}
			catch
			{
			}
			return num;
		}

		public int HDKetBanVoiBanBeCuaUid(int indexRow, string statusProxy, Chrome chrome, List<string> lstUid, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, Random rd, string tenHanhDong)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
			string text = "";
			try
			{
				int num3 = 0;
				int num4 = 5;
				while (lstUid.Count != 0)
				{
					int num5 = 0;
					text = lstUid[rd.Next(0, lstUid.Count)];
					lstUid.Remove(text);
					int num6;
					do
					{
						chrome.GotoURL("https://m.facebook.com/" + text);
						DelayThaoTacNho(1);
						num6 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
					}
					while (num6 == 1);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(num6))
					{
						if (chrome.CheckExistElement("#timelineProfileTiles>div>div>a", 3.0) != 1)
						{
							continue;
						}
						chrome.ScrollSmoothIfNotExistOnScreen("#timelineProfileTiles>div>div>a");
						chrome.DelayTime(1.0);
						chrome.Click(4, "#timelineProfileTiles>div>div>a");
						chrome.DelayThaoTacNho();
						if (chrome.CheckExistElement("[data-sigil=\"touchable m-add-friend\"] button", 3.0) != 1)
						{
							continue;
						}
						while (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('[data-sigil=\"touchable m-add-friend\"] button')[" + num5 + "]") == 1)
						{
							if (num != num2)
							{
								num6 = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
								if (new List<int> { -3, -2, -1, 2 }.Contains(num6))
								{
									return -1;
								}
								chrome.DelayTime(1.0);
								chrome.Click(4, "[data-sigil=\"touchable m-add-friend\"] button", num5);
								num3 = (CommonChrome.SkipNotifyWhenAddFriend(chrome) ? (num3 + 1) : 0);
								if (num3 < num4)
								{
									num++;
									num5++;
									SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
									chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
									continue;
								}
							}
							goto end_IL_005f;
						}
						continue;
					}
					return -1;
				}
				end_IL_005f:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		public int HDKetBanVoiBanCuaBanBe(int indexRow, string statusProxy, Chrome chrome, int soLuongFrom, int soLuongTo, int delayFrom, int delayTo, Random rd, string tenHanhDong)
		{
			string cellAccount = GetCellAccount(indexRow, "cUid");
			string cellAccount2 = GetCellAccount(indexRow, "cPassword");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			int num = 0;
			int num2 = rd.Next(soLuongFrom, soLuongTo + 1);
			string text = "";
			try
			{
				int num3 = 0;
				int num4 = 5;
				List<string> myListUidFriend = CommonChrome.GetMyListUidFriend(chrome);
				while (myListUidFriend.Count != 0)
				{
					int item = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
					if (!new List<int> { -3, -2, -1, 2 }.Contains(item))
					{
						int num5 = 0;
						text = myListUidFriend[rd.Next(0, myListUidFriend.Count)];
						myListUidFriend.Remove(text);
						do
						{
							chrome.GotoURL("https://m.facebook.com/" + text);
							DelayThaoTacNho(1);
							item = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
						}
						while (item == 1);
						if (!new List<int> { -3, -2, -1, 2 }.Contains(item))
						{
							if (chrome.CheckExistElement("#timelineProfileTiles>div>div>a", 3.0) != 1)
							{
								continue;
							}
							chrome.ScrollSmoothIfNotExistOnScreen("#timelineProfileTiles>div>div>a");
							chrome.DelayTime(1.0);
							chrome.Click(4, "#timelineProfileTiles>div>div>a");
							chrome.DelayThaoTacNho();
							if (chrome.CheckExistElement("[data-sigil=\"touchable m-add-friend\"] button", 3.0) != 1)
							{
								continue;
							}
							while (chrome.ScrollSmoothIfNotExistOnScreen("document.querySelectorAll('[data-sigil=\"touchable m-add-friend\"] button')[" + num5 + "]") == 1)
							{
								if (num != num2)
								{
									item = CheckFacebookLogout(chrome, cellAccount, cellAccount2, cellAccount3);
									if (new List<int> { -3, -2, -1, 2 }.Contains(item))
									{
										return -1;
									}
									chrome.DelayTime(1.0);
									chrome.Click(4, "[data-sigil=\"touchable m-add-friend\"] button", num5);
									chrome.DelayTime(1.0);
									num3 = (CommonChrome.SkipNotifyWhenAddFriend(chrome) ? (num3 + 1) : 0);
									if (num3 < num4)
									{
										num++;
										num5++;
										SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{num2})...");
										chrome.DelayTime(rd.Next(delayFrom, delayTo + 1));
										continue;
									}
								}
								goto end_IL_005f;
							}
							continue;
						}
						return -1;
					}
					return -1;
				}
				end_IL_005f:;
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		private int HDThamGiaNhomUid(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, int nudDelayFrom, int nudDelayTo, bool ckbTuDongTraLoiCauHoi, List<string> lstCauTraLoi, bool ckbTuDongXoaUid, string idHanhDong, string tenHanhDong)
		{
			int num = 0;
			int randomInt = device.GetRandomInt(nudSoLuongFrom, nudSoLuongTo);
			string text = "";
			List<string> list = new List<string>();
			if (!ckbTuDongXoaUid)
			{
				list = MCommon.Common.CloneList(dicUidNhom[idHanhDong]);
			}
			try
			{
				int num2 = 0;
				int num3 = 5;
				int num4 = 0;
				int num5 = 3;
				int num6 = 0;
				while (num6 < randomInt + 10)
				{
					string activity = device.GetActivity();
					if (activity.Contains("Launcher") || activity == "Application")
					{
						break;
					}
					if (!ckbTuDongXoaUid)
					{
						if (list.Count != 0)
						{
							text = list[rd.Next(0, list.Count)];
							list.Remove(text);
							goto IL_0278;
						}
						break;
					}
					lock (dicUidNhom)
					{
						if (dicUidNhom[idHanhDong].Count == 0)
						{
							break;
						}
						text = dicUidNhom[idHanhDong][rd.Next(0, dicUidNhom[idHanhDong].Count)];
						dicUidNhom[idHanhDong].Remove(text);
						goto IL_0278;
					}
					IL_0278:
					while (true)
					{
						device.GotoGroupQuick(text);
						device.DelayTime(2.0);
						device.LoadStatusLD("Loading...");
						bool flag = false;
						int tickCount = Environment.TickCount;
						while (Environment.TickCount - tickCount < 30000)
						{
							if (device.CheckExistImage("DataClick\\image\\loadinggroup"))
							{
								device.DelayTime(1.0);
								continue;
							}
							flag = true;
							break;
						}
						device.LoadStatusLD("");
						if (!flag)
						{
							device.CloseAppFacebook();
							num4++;
							if (num4 >= num5)
							{
								break;
							}
							continue;
						}
						num4 = 0;
						device.Scroll(500, -1);
						device.DelayTime(1.0);
						switch (CheckStatusDevice(device, indexRow, statusProxy))
						{
						case 1:
							break;
						case 0:
						{
							string html = device.GetHtml();
							if (device.GetListText(html).Count == 1)
							{
								device.TapByText(device.GetListText(html)[0], html);
								device.DelayTime(2.0);
								html = device.GetHtml();
							}
							if (device.CheckExistTexts(html, 0.0, "\"joined", "\"cancel join", "\"cancel request\"", "\"invite members\"") > 0)
							{
								goto IL_058e;
							}
							string boundsByText = device.GetBoundsByText("\"join", html, 1);
							if (boundsByText != "")
							{
								device.TapByBounds(boundsByText);
								device.DelayTime(2.0);
								html = device.GetHtml();
								if (device.GetListText(html).Count == 1)
								{
									device.TapByText(device.GetListText(html)[0], html);
									device.DelayTime(2.0);
									html = device.GetHtml();
								}
								if (device.CheckExistText("this group may share content that violates our community standards.", html))
								{
									device.TapByImage("DataClick\\image\\joingroup");
									device.DelayTime(2.0);
									html = device.GetHtml();
								}
								if (device.GetListText(html).Count > 1 && ckbTuDongTraLoiCauHoi && device.CheckExistTexts(html, 3.0, "answer these questions") == 1)
								{
									AnswerQuestionWhenJoinGroup(device, lstCauTraLoi);
								}
								num++;
								SetStatusAccount(indexRow, statusProxy + Language.GetValue("Đang") + $" {tenHanhDong} ({num}/{randomInt})...");
								if (num < randomInt)
								{
									device.DelayRandom(nudDelayFrom, nudDelayTo);
									goto IL_058e;
								}
							}
							else
							{
								num6--;
								num2++;
								if (num2 < num3)
								{
									goto IL_058e;
								}
							}
							goto end_IL_004a;
						}
						default:
							goto end_IL_004a;
							IL_058e:
							num6++;
							goto IL_0598;
						}
					}
					break;
					IL_0598:;
				}
				end_IL_004a:;
			}
			catch
			{
			}
			return num;
		}

		private void AnswerQuestionWhenJoinGroup(Device device, List<string> lstCauTraLoi)
		{
			for (int i = 0; i < 10; i++)
			{
				List<string> listBoundsByText = device.GetListBoundsByText("write your answer...");
				if (listBoundsByText.Count > 0)
				{
					for (int j = 0; j < listBoundsByText.Count; j++)
					{
						device.TapByBounds(listBoundsByText[j]);
						device.DelayRandom(1.0, 1.5);
						device.InputTextWithUnicode(lstCauTraLoi[device.GetRandomInt(0, lstCauTraLoi.Count - 1)]);
						device.DelayRandom(1.0, 1.5);
					}
				}
				for (int k = 0; k < 10; k++)
				{
					if (!device.TapByImage("DataClick\\image\\thamgianhom\\checkbox"))
					{
						break;
					}
					device.DelayRandom(1.0, 1.5);
				}
				if (device.TapByImage("DataClick\\image\\thamgianhom\\radiobutton"))
				{
					device.DelayRandom(1.0, 1.5);
				}
				if (!device.ScrollAndCheckScreenNotChange(device.GetRandomInt(400, 500)))
				{
					continue;
				}
				if (!device.TapByText("\"submit\""))
				{
					break;
				}
				device.DelayRandom(2.0, 2.5);
				string html = device.GetHtml();
				if (device.CheckExistText("There was an error submitting", html))
				{
					device.GotoBack(2);
					device.DelayRandom(1.5, 2.0);
					html = device.GetHtml();
					if (device.CheckExistText("exit without answering", html))
					{
						device.TapByText("\"exit", html);
						device.DelayRandom(1.0, 1.5);
					}
				}
				if (!device.CheckExistText("\"submit\"", html))
				{
					break;
				}
			}
		}

		private void LoadCheckTool()
		{
			lblStatus.Text = Language.GetValue("Đã kích hoạt");
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
						btnPause.Text = Language.GetValue("Dừng Tương Tác");
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

		private void OpenFormUpdate(string type)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(GetCellAccount(i, "cChose")))
					{
						list.Add(GetCellAccount(i, "cId"));
					}
				}
				if (list.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n ta\u0300i khoa\u0309n câ\u0300n câ\u0323p nhâ\u0323t!"), 3);
				}
				else
				{
					MCommon.Common.ShowForm(new fUpdateData(this, type));
				}
			}
			catch
			{
			}
		}

		private void mậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Password");
		}

		private void NhậpDữLiệuToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Token");
		}

		private void NhậpDữLiệuToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Cookie");
		}

		private void mailKhôiPhụcToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Mail|pass");
		}

		private void mã2FAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("2FA");
		}

		private void tokenEAAAAZToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TuLayThongTin(0);
		}

		private void TokenBussinessToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TuLayThongTin(1);
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
			if (!(text == "-1"))
			{
				if (!(text == "999999"))
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
				string text2 = cbbThuMuc.SelectedValue.ToString();
				if (text2 == "-1" || text2 == "999999")
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

		private void ToolStripStatusLabel9_Click(object sender, EventArgs e)
		{
			Hide();
			Settings.Default.UserName = "";
			Settings.Default.PassWord = "";
			Settings.Default.Save();
			fActive fActive2 = new fActive(0, deviceId);
			fActive2.ShowInTaskbar = true;
			fActive2.ShowDialog();
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
		}

		private void BtnPost_Click(object sender, EventArgs e)
		{
		}

		private void BtnViewLivestream_Click(object sender, EventArgs e)
		{
		}

		private void fAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("2fa");
		}

		private void checkAvatarToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
								SetStatusAccount(row, Language.GetValue("Đang kiểm tra..."));
								CheckMyAvatar(row);
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

		private void CheckMyAvatar(int row)
		{
			try
			{
				string uid = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				string id = dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				if (CommonRequest.CheckAvatarFromUid(uid))
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
				string text2 = FileHelper.GetPathToCurrentFolder() + "\\profile\\" + text;
				string path = text2 + "\\data.tar.gz";
				string path2 = text2 + ".zip";
				if (text.Trim() == "")
				{
					SetStatusAccount(row, Language.GetValue("Chưa tạo profile!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(id, "profile", "No");
				}
				else if (File.Exists(path))
				{
					try
					{
						File.Delete(path);
						SetStatusAccount(row, Language.GetValue("Xóa profile thành công!"));
						SetCellAccount(row, "cProfile", "No");
						CommonSQL.UpdateFieldToAccount(id, "profile", "No");
					}
					catch
					{
						SetStatusAccount(row, Language.GetValue("Xóa profile thâ\u0301t ba\u0323i!"));
					}
				}
				else if (File.Exists(path2))
				{
					try
					{
						File.Delete(path2);
						SetStatusAccount(row, Language.GetValue("Xóa profile thành công!"));
						SetCellAccount(row, "cProfile", "No");
						CommonSQL.UpdateFieldToAccount(id, "profile", "No");
					}
					catch
					{
						SetStatusAccount(row, Language.GetValue("Xóa profile thâ\u0301t ba\u0323i!"));
					}
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
			setting_Interact = new JSON_Settings("configInteract");
			setting_InteractGeneral = new JSON_Settings("configInteractGeneral");
			setting_LDPlayer = new JSON_Settings("configLDPlayer");
		}

		private void taoFileHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadSetting();
			string template = Base.template_backup;
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
										CreateAndCopyHtmlFromBackupTxt(row, template);
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

		private void CreateAndCopyHtmlFromBackupTxt(int row, string template, bool isOpen = false, string pathDestination = "")
		{
			try
			{
				string text = "";
				string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvAcc, row, "cCookie");
				string text2 = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				if (text2 == "")
				{
					text2 = Regex.Match(statusDataGridView, "c_user=(.*?);").Groups[1].Value;
				}
				text = ((!File.Exists("backup\\" + text2 + "\\ngaysinh.txt")) ? "||" : File.ReadAllText("backup\\" + text2 + "\\ngaysinh.txt"));
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Đang tạo file Html..."));
				if (text2 != "")
				{
					string text3 = text.Split('|')[2].Replace("\"", "\\\"").Replace("'", "\\'");
					string text4 = text.Split('|')[1];
					if (text3 == "")
					{
						text3 = "NoName";
					}
					if (text4 == "")
					{
						text4 = "00/00/0000";
					}
					template = template.Replace("{{uid}}", text2).Replace("{{birthday}}", text4).Replace("{{name}}", text3);
					string text5 = "backup\\" + text2;
					if (!Directory.Exists(text5))
					{
						return;
					}
					if (File.Exists(text5 + "\\lscomment.txt"))
					{
						string text6 = "";
						List<string> list = File.ReadAllLines(text5 + "\\lscomment.txt").ToList();
						int count = list.Count;
						for (int i = 0; i < count; i++)
						{
							text6 = text6 + "\"" + list[i].Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
						}
						if (text6 != "")
						{
							text6 = text6.Remove(text6.Length - 1, 1);
							template = template.Replace("{comments}", text6);
						}
						else
						{
							template = template.Replace("{comments}", "");
						}
					}
					else
					{
						template = template.Replace("{comments}", "");
					}
					if (File.Exists(text5 + "\\banbeinbox.txt"))
					{
						string text7 = "";
						List<string> list2 = File.ReadAllLines(text5 + "\\banbeinbox.txt").ToList();
						int count2 = list2.Count;
						for (int j = 0; j < count2; j++)
						{
							text7 = text7 + "\"" + list2[j].Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
						}
						if (text7 != "")
						{
							text7 = text7.Remove(text7.Length - 1, 1);
							template = template.Replace("{messages}", text7);
						}
						else
						{
							template = template.Replace("{messages}", "");
						}
					}
					else
					{
						template = template.Replace("{messages}", "");
					}
					if (File.Exists(text5 + "\\" + text2 + ".txt"))
					{
						string text8 = "";
						string text9 = "";
						string text10 = File.ReadAllText(text5 + "\\" + text2 + ".txt");
						string[] array = text10.Split(new string[1] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
						for (int k = 0; k < array.Length; k++)
						{
							string[] array2 = array[k].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
							if (array2.Length != 0)
							{
								text9 = "";
								for (int l = 0; l < array2.Length; l++)
								{
									string[] array3 = array2[l].Split('*');
									text9 = text9 + "\"" + array3[2].Split('|')[0] + "\",";
								}
								text9 = text9.Remove(text9.Length - 1, 1);
								text8 = text8 + "{\"uid\":\"" + array2[0].Split('*')[0] + "\",\"name\":\"" + array2[0].Split('*')[1] + "\",\"photos\":[" + text9 + "],\"show\":true},";
							}
						}
						text8 = text8.Remove(text8.Length - 1, 1);
						template = template.Replace("{photos}", text8);
					}
					else
					{
						template = template.Replace("{photos}", "");
					}
					File.WriteAllText(text5 + "\\" + text2 + ".html", template);
					DatagridviewHelper.SetStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Ta\u0323o tha\u0300nh công!"));
					return;
				}
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Không co\u0301 uid!"));
			}
			catch
			{
				DatagridviewHelper.SetStatusDataGridView(dtgvAcc, row, "cStatus", Language.GetValue("Lô\u0303i ta\u0323o file!"));
			}
		}

		private bool CreateHTML(string uid, string template, string pathFolder = "backup\\")
		{
			bool result = false;
			try
			{
				string text = "";
				text = ((!File.Exists(pathFolder + "\\" + uid + "\\ngaysinh.txt")) ? "||" : File.ReadAllText(pathFolder + "\\" + uid + "\\ngaysinh.txt"));
				if (uid != "")
				{
					string text2 = text.Split('|')[2].Replace("\"", "\\\"").Replace("'", "\\'");
					string text3 = text.Split('|')[1];
					if (text2 == "")
					{
						text2 = "NoName";
					}
					if (text3 == "")
					{
						text3 = "00/00/0000";
					}
					template = template.Replace("{{uid}}", uid).Replace("{{birthday}}", text3).Replace("{{name}}", text2);
					string text4 = pathFolder + "\\" + uid;
					if (Directory.Exists(text4))
					{
						if (File.Exists(text4 + "\\lscomment.txt"))
						{
							string text5 = "";
							List<string> list = File.ReadAllLines(text4 + "\\lscomment.txt").ToList();
							int count = list.Count;
							for (int i = 0; i < count; i++)
							{
								text5 = text5 + "\"" + list[i].Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
							}
							if (text5 != "")
							{
								text5 = text5.Remove(text5.Length - 1, 1);
								template = template.Replace("{comments}", text5);
							}
							else
							{
								template = template.Replace("{comments}", "");
							}
						}
						else
						{
							template = template.Replace("{comments}", "");
						}
						if (File.Exists(text4 + "\\banbeinbox.txt"))
						{
							string text6 = "";
							List<string> list2 = File.ReadAllLines(text4 + "\\banbeinbox.txt").ToList();
							int count2 = list2.Count;
							for (int j = 0; j < count2; j++)
							{
								text6 = text6 + "\"" + list2[j].Replace("\"", "\\\"").Replace("'", "\\'") + "\",";
							}
							if (text6 != "")
							{
								text6 = text6.Remove(text6.Length - 1, 1);
								template = template.Replace("{messages}", text6);
							}
							else
							{
								template = template.Replace("{messages}", "");
							}
						}
						else
						{
							template = template.Replace("{messages}", "");
						}
						if (File.Exists(text4 + "\\" + uid + ".txt"))
						{
							string text7 = "";
							string text8 = "";
							string text9 = File.ReadAllText(text4 + "\\" + uid + ".txt");
							string[] array = text9.Split(new string[1] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
							for (int k = 0; k < array.Length; k++)
							{
								string[] array2 = array[k].Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
								if (array2.Length != 0)
								{
									text8 = "";
									for (int l = 0; l < array2.Length; l++)
									{
										string[] array3 = array2[l].Split('*');
										text8 = text8 + "\"" + array3[2].Split('|')[0] + "\",";
									}
									text8 = text8.Remove(text8.Length - 1, 1);
									text7 = text7 + "{\"uid\":\"" + array2[0].Split('*')[0] + "\",\"name\":\"" + array2[0].Split('*')[1] + "\",\"photos\":[" + text8 + "],\"show\":true},";
								}
							}
							text7 = text7.Remove(text7.Length - 1, 1);
							template = template.Replace("{photos}", text7);
						}
						else
						{
							template = template.Replace("{photos}", "");
						}
						File.WriteAllText(text4 + "\\" + uid + ".html", template);
						result = true;
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
			MCommon.Common.ShowForm(new fSelectFolder());
			string pathFolder = fSelectFolder.pathFolder;
			if (pathFolder == "")
			{
				return;
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
					string text = dtgvAcc.Rows[i].Cells["cUid"].Value.ToString();
					try
					{
						if (File.Exists(FileHelper.GetPathToCurrentFolder() + "\\backup\\" + text + "\\" + text + ".html"))
						{
							File.Copy("backup\\" + text + "\\" + text + ".html", pathFolder + "\\" + text + ".html");
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
			CopyFolder(ConfigHelper.GetPathBackup());
		}

		private void dtgvAcc_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
		{
			List<string> list = new List<string> { "cStt", "cFriend", "cGroup", "cFollow" };
			if (list.Contains(e.Column.Name))
			{
				e.SortResult = int.Parse((e.CellValue1.ToString() == "") ? "-1" : e.CellValue1.ToString()).CompareTo(int.Parse((e.CellValue2.ToString() == "") ? "-1" : e.CellValue2.ToString()));
				e.Handled = true;
			}
			else if (e.Column.Name == "cStatus")
			{
				string text = e.CellValue1.ToString();
				string text2 = e.CellValue2.ToString();
				string text3 = "";
				string text4 = "";
				text3 = ((!text.StartsWith("(")) ? text : text.Substring(text.IndexOf(")") + 1).Trim());
				text4 = ((!text2.StartsWith("(")) ? text2 : text2.Substring(text2.IndexOf(")") + 1).Trim());
				e.SortResult = text3.CompareTo(text4);
				e.Handled = true;
			}
			else if (e.Column.Name == "cBirthday")
			{
				string text5 = e.CellValue1.ToString();
				string text6 = e.CellValue2.ToString();
				int num = int.Parse((text5 == "") ? "-1" : ((text5.Split('/').Length >= 3) ? text5.Split('/')[2] : "-1"));
				int value = int.Parse((text6 == "") ? "-1" : ((text6.Split('/').Length >= 3) ? text6.Split('/')[2] : "-1"));
				e.SortResult = num.CompareTo(value);
				e.Handled = true;
			}
			else if (e.Column.Name == "cDateCreateAcc")
			{
				try
				{
					string text7 = e.CellValue1.ToString();
					string text8 = e.CellValue2.ToString();
					int num2 = int.Parse((text7 == "") ? "-1" : ((text7.Split(',').Length >= 2) ? text7.Split(',')[1] : "-1"));
					int value2 = int.Parse((text8 == "") ? "-1" : ((text8.Split(',').Length >= 2) ? text8.Split(',')[1] : "-1"));
					e.SortResult = num2.CompareTo(value2);
					e.Handled = true;
				}
				catch (Exception)
				{
					e.SortResult = -1.CompareTo(-1);
					e.Handled = true;
				}
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

		private void button6_Click(object sender, EventArgs e)
		{
		}

		private void useragentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Useragent");
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
				if (text.Trim() == "")
				{
					SetStatusAccount(row, "Proxy trô\u0301ng!");
					return;
				}
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

		private void proxyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Proxy");
		}

		private void useragentToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("useragent");
		}

		private void proxyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CopyRowDatagrid("proxy");
		}

		private void ghiChuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Notes");
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

		private void ngàySinhToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFormUpdate("Birthday");
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
			string useragentIPad = SetupFolder.GetUseragentIPad(rd);
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
						TimeWaitForLoadingPage = 60,
						UserAgent = useragentIPad
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
										goto IL_057e;
									case 1:
										flag = true;
										break;
									}
									break;
									IL_057e:
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
								DownloadAvatar(row, pathFolder);
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

		private void DownloadAvatar(int row, string pathFolder)
		{
			try
			{
				string uid = dtgvAcc.Rows[row].Cells["cUid"].Value.ToString();
				dtgvAcc.Rows[row].Cells["cId"].Value.ToString();
				if (CommonRequest.DownLoadImageByUid(uid, pathFolder))
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
			MCommon.Common.ShowForm(new fCauHinhTuongTac());
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

		private void checkLiveUidToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fTienIchCheckLiveUid());
		}

		private void MoTrinhDuyet()
		{
			try
			{
				LoadSetting();
				setting_MoTrinhDuyet = new JSON_Settings("configOpenBrowser");
				string profilePath = "";
				if (!setting_MoTrinhDuyet.GetValueBool("isUseProfile"))
				{
					goto IL_008f;
				}
				profilePath = ConfigHelper.GetPathProfile();
				if (Directory.Exists(profilePath))
				{
					goto IL_008f;
				}
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn profile không hợp lệ!"), 3);
				goto end_IL_0001;
				IL_008f:
				if (!(Base.useragentDefault == ""))
				{
					goto IL_00d4;
				}
				Base.useragentDefault = CommonChrome.GetUserAgentDefault();
				if (!(Base.useragentDefault == ""))
				{
					goto IL_00d4;
				}
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Phiên bản Chromedriver hiện tại không khả dụng, vui lòng cập nhật!"), 3);
				goto end_IL_0001;
				IL_00d4:
				LoadSetting();
				int maxThread = CountChooseRowInDatagridview();
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
				isStop = false;
				List<int> lstPossition = new List<int>();
				for (int n = 0; n < CountChooseRowInDatagridview(); n++)
				{
					lstPossition.Add(0);
				}
				checkDelayChrome = 0;
				lstThread = new List<Thread>();
				new Thread((ThreadStart)delegate
				{
					try
					{
						int num = 0;
						while (num < dtgvAcc.Rows.Count && !isStop)
						{
							if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
							{
								if (isStop || lstThread.Count >= maxThread)
								{
									break;
								}
								if (isStop)
								{
									break;
								}
								int row = num++;
								Thread thread = new Thread((ThreadStart)delegate
								{
									try
									{
										int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
										MoTrinhDuyetOneThread(row, indexOfPossitionApp, profilePath);
									}
									catch (Exception ex3)
									{
										MCommon.Common.ExportError(null, ex3);
									}
								})
								{
									Name = row.ToString()
								};
								lstThread.Add(thread);
								MCommon.Common.DelayTime(1.0);
								thread.Start();
							}
							else
							{
								num++;
							}
							if (isStop)
							{
								break;
							}
						}
						for (int num2 = 0; num2 < lstThread.Count; num2++)
						{
							lstThread[num2].Join();
						}
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2);
					}
				}).Start();
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
			}
		}

		private void MoTrinhDuyetOneThread(int indexRow, int indexPos, string profilePath)
		{
			string text = "";
			Chrome chrome = null;
			int num = 0;
			bool flag = false;
			string text2 = "";
			int typeProxy = 0;
			string text3 = "";
			TinsoftProxy tinsoftProxy = null;
			XproxyProxy xproxyProxy = null;
			TMProxy tMProxy = null;
			ProxyWeb proxyWeb = null;
			ShopLike shopLike = null;
			bool flag2 = false;
			string text4 = "";
			string text5 = GetCellAccount(indexRow, "cUid");
			string cellAccount = GetCellAccount(indexRow, "cId");
			string cellAccount2 = GetCellAccount(indexRow, "cEmail");
			string cellAccount3 = GetCellAccount(indexRow, "cFa2");
			string cellAccount4 = GetCellAccount(indexRow, "cPassword");
			string cellAccount5 = GetCellAccount(indexRow, "cCookies");
			GetCellAccount(indexRow, "cToken");
			string text6 = GetCellAccount(indexRow, "cUseragent");
			if (text5 == "")
			{
				text5 = Regex.Match(cellAccount5, "c_user=(.*?);").Groups[1].Value;
			}
			if (isStop)
			{
				SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
			}
			else
			{
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
									foreach (ShopLike item in listShopLike)
									{
										if (shopLike == null || item.daSuDung < shopLike.daSuDung)
										{
											shopLike = item;
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
									shopLike.dangSuDung++;
									shopLike.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag6 = true;
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
									flag6 = false;
								}
							}
							if (!flag6)
							{
								shopLike.dangSuDung--;
								shopLike.daSuDung--;
								continue;
							}
							goto default;
						}
					case 11:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy Proxyv6..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								proxyWeb = null;
								while (!isStop)
								{
									foreach (ProxyWeb item2 in listProxyWeb)
									{
										if (proxyWeb == null || item2.daSuDung < proxyWeb.daSuDung)
										{
											proxyWeb = item2;
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
									proxyWeb.dangSuDung++;
									proxyWeb.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag8 = true;
							if (setting_general.GetValueInt("nudDelayCheckIP") > 0)
							{
								SetStatusAccount(indexRow, text2 + "Delay check IP...");
								MCommon.Common.DelayTime(setting_general.GetValueInt("nudDelayCheckIP"));
							}
							if (setting_general.GetValueBool("ckbKhongCheckIP"))
							{
								goto IL_06d4;
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
										break;
									}
								}
								if (text3 == "")
								{
									flag8 = false;
								}
								goto IL_06d4;
							}
							goto end_IL_0403;
							IL_06d4:
							if (!flag8)
							{
								proxyWeb.dangSuDung--;
								proxyWeb.daSuDung--;
								continue;
							}
							text = text.Split(':')[0] + ":" + text.Split(':')[1];
							goto default;
							end_IL_0403:;
						}
						break;
					case 10:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy TMProxy..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								tMProxy = null;
								while (!isStop)
								{
									foreach (TMProxy item3 in listTMProxy)
									{
										if (tMProxy == null || item3.daSuDung < tMProxy.daSuDung)
										{
											tMProxy = item3;
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
									tMProxy.dangSuDung++;
									tMProxy.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag4 = true;
							if (!setting_general.GetValueBool("ckbKhongCheckIP"))
							{
								text2 = "(IP: " + text.Split(':')[0] + ") ";
								SetStatusAccount(indexRow, text2 + "Check IP...");
								text3 = MCommon.Common.CheckProxy(text, 0);
								if (text3 == "")
								{
									flag4 = false;
								}
							}
							if (!flag4)
							{
								tMProxy.dangSuDung--;
								tMProxy.daSuDung--;
								continue;
							}
							goto default;
						}
					case 8:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy Xproxy..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								xproxyProxy = null;
								while (!isStop)
								{
									foreach (XproxyProxy item4 in listxProxy)
									{
										if (xproxyProxy == null || (item4.isProxyLive && item4.daSuDung < xproxyProxy.daSuDung))
										{
											xproxyProxy = item4;
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
								xproxyProxy.dangSuDung++;
								xproxyProxy.daSuDung++;
								break;
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag3 = true;
							if (setting_general.GetValueBool("ckbKhongCheckIP"))
							{
								goto IL_0c26;
							}
							text2 = "(IP: " + text.Split(':')[0] + ") ";
							SetStatusAccount(indexRow, text2 + "Check IP...");
							int num2 = 0;
							while (true)
							{
								if (num2 < 30)
								{
									MCommon.Common.DelayTime(1.0);
									text3 = MCommon.Common.CheckProxy(text, typeProxy);
									if (!(text3 != ""))
									{
										if (!isStop)
										{
											num2++;
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										break;
									}
								}
								if (text3 == "")
								{
									flag3 = false;
								}
								goto IL_0c26;
							}
							goto end_IL_09cd;
							IL_0c26:
							if (!flag3)
							{
								xproxyProxy.dangSuDung--;
								xproxyProxy.daSuDung--;
								continue;
							}
							goto default;
							end_IL_09cd:;
						}
						break;
					case 7:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy proxy Tinsoft..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								tinsoftProxy = null;
								while (!isStop)
								{
									foreach (TinsoftProxy item5 in listTinsoft)
									{
										if (tinsoftProxy == null || item5.daSuDung < tinsoftProxy.daSuDung)
										{
											tinsoftProxy = item5;
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
									tinsoftProxy.dangSuDung++;
									tinsoftProxy.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag5 = true;
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
								tinsoftProxy.dangSuDung--;
								tinsoftProxy.daSuDung--;
								continue;
							}
							goto default;
						}
					case 9:
						text = GetCellAccount(indexRow, "cProxy");
						typeProxy = (text.EndsWith("*1") ? 1 : 0);
						if (text.EndsWith("*0") || text.EndsWith("*1"))
						{
							text = text.Substring(0, text.Length - 2);
						}
						goto default;
					default:
						{
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
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
									bool flag7 = false;
									int num3 = 0;
									while (num3 < 30)
									{
										MCommon.Common.DelayTime(1.0);
										text3 = MCommon.Common.CheckProxy(text, typeProxy);
										if (!(text3 != ""))
										{
											if (!isStop)
											{
												num3++;
												continue;
											}
											goto IL_10fd;
										}
										flag7 = true;
										break;
									}
									if (!flag7)
									{
										if (text != "")
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không thể kết nối proxy!"));
										}
										else
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không có kết nối Internet!"));
										}
										break;
									}
								}
								text2 = "(IP: " + text3 + ") ";
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							try
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Chờ đến lượt..."));
								lock (lock_checkDelayChrome)
								{
									if (checkDelayChrome > 0)
									{
										int num4 = rd.Next(setting_general.GetValueInt("nudDelayOpenChromeFrom", 1), setting_general.GetValueInt("nudDelayOpenChromeTo", 1) + 1);
										if (num4 > 0)
										{
											int tickCount = Environment.TickCount;
											while ((Environment.TickCount - tickCount) / 1000 - num4 < 0)
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Mở tri\u0300nh duyê\u0323t sau") + " {time}s...".Replace("{time}", (num4 - (Environment.TickCount - tickCount) / 1000).ToString()));
												MCommon.Common.DelayTime(0.5);
												if (isStop)
												{
													SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
													goto end_IL_0ec9;
												}
											}
										}
									}
									else
									{
										checkDelayChrome++;
									}
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đang mơ\u0309 tri\u0300nh duyê\u0323t..."));
								if (text6 == "" && text.Split(':').Length == 4)
								{
									text6 = Base.useragentDefault;
								}
								string text7 = profilePath + "\\" + text5;
								if (!setting_MoTrinhDuyet.GetValueBool("isUseProfile"))
								{
									text7 = "";
								}
								Point pointFromIndexPosition = MCommon.Common.GetPointFromIndexPosition(indexPos, 5, 2);
								Point sizeChrome = MCommon.Common.GetSizeChrome(5, 2);
								chrome = new Chrome
								{
									DisableImage = !Convert.ToBoolean((setting_general.GetValue("ckbShowImageInteract") == "") ? "false" : setting_general.GetValue("ckbShowImageInteract")),
									UserAgent = text6,
									ProfilePath = text7,
									Size = sizeChrome,
									Position = pointFromIndexPosition,
									TimeWaitForSearchingElement = 3,
									TimeWaitForLoadingPage = 120,
									Proxy = text,
									TypeProxy = typeProxy,
									IsUsePortable = setting_general.GetValueBool("ckbUsePortable"),
									PathToPortableZip = setting_general.GetValue("txtPathToPortableZip")
								};
								if (isStop)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
									break;
								}
								if (setting_general.GetValueInt("typeBrowser") != 0)
								{
									chrome.LinkToOtherBrowser = setting_general.GetValue("txtLinkToOtherBrowser");
								}
								if (!chrome.Open())
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở trình duyệt!"));
									break;
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đang đăng nhâ\u0323p..."));
								string text8 = "";
								text8 = ((setting_MoTrinhDuyet.GetValueInt("typeBrowserLogin") != 0) ? "https://www.facebook.com/" : "https://m.facebook.com/");
								if (text7.Trim() != "")
								{
									num = CommonChrome.CheckLiveCookie(chrome, text8);
									switch (num)
									{
									case -3:
										chrome.Status = StatusChromeAccount.NoInternet;
										goto end_IL_11cb;
									case -2:
										chrome.Status = StatusChromeAccount.ChromeClosed;
										goto end_IL_11cb;
									case 1:
										flag = true;
										break;
									case 2:
										chrome.Status = StatusChromeAccount.Checkpoint;
										SetInfoAccount(cellAccount, indexRow, Language.GetValue("Checkpoint"));
										goto end_IL_11cb;
									}
								}
								if (!flag)
								{
									string text9 = "";
									switch (setting_MoTrinhDuyet.GetValueInt("typeLogin"))
									{
									case 0:
										if (text5.Trim() == "" || cellAccount4.Trim() == "")
										{
											if (text5.Trim() == "")
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Không ti\u0300m thâ\u0301y UID!"));
											}
											else if (cellAccount4.Trim() == "")
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"));
											}
											goto end_IL_0ec9;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhâ\u0323p bă\u0300ng uid|pass..."));
										text9 = CommonChrome.LoginFacebookUsingUidPassNew(chrome, text5, cellAccount4, cellAccount3, text8, 2, setting_MoTrinhDuyet.GetValueBool("ckbKhongLuuTrinhDuyet"));
										try
										{
											num = Convert.ToInt32(text9);
										}
										catch
										{
											num = -1;
										}
										goto default;
									case 1:
										if (cellAccount2.Trim() == "" || cellAccount4.Trim() == "")
										{
											if (cellAccount2.Trim() == "")
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Không ti\u0300m thâ\u0301y Email!"));
											}
											else if (cellAccount4.Trim() == "")
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Không ti\u0300m thâ\u0301y Pass!"));
											}
											goto end_IL_0ec9;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhâ\u0323p bă\u0300ng email|pass..."));
										text9 = CommonChrome.LoginFacebookUsingUidPassNew(chrome, cellAccount2, cellAccount4, cellAccount3, text8, 2, setting_MoTrinhDuyet.GetValueBool("ckbKhongLuuTrinhDuyet"));
										try
										{
											num = Convert.ToInt32(text9);
										}
										catch
										{
											num = -1;
										}
										goto default;
									case 2:
										if (cellAccount5.Trim() == "")
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không ti\u0300m thâ\u0301y Cookie!"));
											goto end_IL_0ec9;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhâ\u0323p bă\u0300ng cookie..."));
										num = CommonChrome.LoginFacebookUsingCookie(chrome, cellAccount5, text8);
										goto default;
									default:
										if (setting_MoTrinhDuyet.GetValueInt("typeLogin") != 2)
										{
											switch (num)
											{
											case -2:
												chrome.Status = StatusChromeAccount.ChromeClosed;
												break;
											case -1:
												SetStatusAccount(indexRow, text2 + text9);
												break;
											case 0:
												SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhập thất bại!"));
												CommonChrome.CheckStatusAccount(chrome, isSendRequest: true);
												if (chrome.Status == StatusChromeAccount.Logined)
												{
													flag = true;
												}
												break;
											case 1:
												flag = true;
												break;
											case 2:
												chrome.Status = StatusChromeAccount.Checkpoint;
												SetInfoAccount(cellAccount, indexRow, Language.GetValue("Checkpoint"));
												break;
											case 3:
												SetStatusAccount(indexRow, text2 + Language.GetValue("Không có 2fa!"));
												break;
											case 4:
												SetStatusAccount(indexRow, text2 + Language.GetValue("Tài khoản không đúng!"));
												break;
											case 5:
												SetStatusAccount(indexRow, text2 + Language.GetValue("Mật khẩu không đúng!"));
												SetInfoAccount(cellAccount, indexRow, "Changed pass");
												break;
											case 6:
												SetStatusAccount(indexRow, text2 + Language.GetValue("Mã 2fa không đúng!"));
												break;
											case 7:
												chrome.Status = StatusChromeAccount.NoInternet;
												break;
											}
											if (flag)
											{
												break;
											}
											SetRowColor(indexRow, 1);
											ScreenCaptureError(chrome, text5, 1);
											goto end_IL_0ec9;
										}
										switch (num)
										{
										case -3:
											chrome.Status = StatusChromeAccount.NoInternet;
											goto end_IL_11cb;
										case -2:
											chrome.Status = StatusChromeAccount.ChromeClosed;
											goto end_IL_11cb;
										case 1:
											flag = true;
											goto default;
										default:
											if (flag)
											{
												break;
											}
											SetRowColor(indexRow, 1);
											SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhâ\u0323p thâ\u0301t ba\u0323i!"));
											ScreenCaptureError(chrome, text5, 1);
											goto end_IL_11cb;
										case 2:
											chrome.Status = StatusChromeAccount.Checkpoint;
											SetInfoAccount(cellAccount, indexRow, Language.GetValue("Checkpoint"));
											goto end_IL_11cb;
										}
										break;
									}
								}
								if (setting_MoTrinhDuyet.GetValueInt("typeBrowserLogin") == 1 && !chrome.GetURL().StartsWith(text8))
								{
									chrome.GotoURL(text8);
								}
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhâ\u0323p tha\u0300nh công!"));
								SetRowColor(indexRow, 2);
								if (setting_MoTrinhDuyet.GetValueBool("ckbAutoOpenLink"))
								{
									chrome.GotoURL(setting_MoTrinhDuyet.GetValue("txtLink"));
								}
								if (flag2 = !CheckIsUidFacebook(text5))
								{
									text4 = text5;
									text5 = Regex.Match(chrome.GetCookieFromChrome() + ";", "c_user=(.*?);").Groups[1].Value;
									if (text5.Trim() != "")
									{
										CommonSQL.UpdateFieldToAccount(cellAccount, "uid", text5);
										SetCellAccount(indexRow, "cUid", text5);
									}
								}
								if (setting_MoTrinhDuyet.GetValueBool("isGetCookie"))
								{
									cellAccount5 = chrome.GetCookieFromChrome();
									if (text5.Trim() != "")
									{
										CommonSQL.UpdateFieldToAccount(cellAccount, "uid", text5);
									}
									CommonSQL.UpdateFieldToAccount(cellAccount, "cookie1", cellAccount5);
									SetCellAccount(indexRow, "cCookies", cellAccount5);
								}
								end_IL_11cb:;
							}
							catch (Exception ex)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
								MCommon.Common.ExportError(chrome, ex);
							}
							break;
						}
						IL_10fd:
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
						break;
						end_IL_0ec9:
						break;
					}
					break;
				}
			}
			if (chrome != null)
			{
				StatusChromeAccount status = chrome.Status;
				StatusChromeAccount statusChromeAccount = status;
				if (statusChromeAccount == StatusChromeAccount.ChromeClosed || statusChromeAccount == StatusChromeAccount.Checkpoint || statusChromeAccount == StatusChromeAccount.NoInternet)
				{
					SetRowColor(indexRow, 1);
					SetStatusAccount(indexRow, text2 + GetContentStatusChrome.GetContent(chrome.Status));
				}
			}
			if (!flag && setting_MoTrinhDuyet.GetValueBool("isAutoCloseChromeLoginFail"))
			{
				try
				{
					chrome.Close();
				}
				catch
				{
				}
			}
			if (flag2 && Directory.Exists(setting_general.GetValue("txbPathProfile") + "\\" + text4) && !string.IsNullOrEmpty(text4))
			{
				string text10 = setting_general.GetValue("txbPathProfile") + "\\" + text4;
				string pathTo = setting_general.GetValue("txbPathProfile") + "\\" + text5;
				if (!MCommon.Common.MoveFolder(text10, pathTo) && MCommon.Common.CopyFolder(text10, pathTo))
				{
					MCommon.Common.DeleteFolder(text10);
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

		private void mởLuônToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CountChooseRowInDatagridview() == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản cần mở trình duyệt!"), 3);
			}
			else
			{
				MoTrinhDuyet();
			}
		}

		private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
		{
		}

		private void dọnDẹpBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.ShowForm(new fClearBackup());
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(ex.ToString(), 3);
			}
		}

		private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fContact());
		}

		private void metroButton2_Click_2(object sender, EventArgs e)
		{
			List<string> list = new List<string> { "Đã tương tác xong! - Block da", "Đã tương tác xong!" };
			Random random = new Random();
			for (int i = 0; i < 100; i++)
			{
				SetStatusAccount(i, "[" + random.Next(10000, 99999) + "] " + list[random.Next(2)]);
			}
		}

		private void checkFileBackupLDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
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
								SetStatusAccount(row, "Check profile LD...");
								CheckBackupLD(row);
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

		private void CheckBackupLD(int row)
		{
			try
			{
				string cellAccount = GetCellAccount(row, "cId");
				string cellAccount2 = GetCellAccount(row, "cUid");
				string text = FileHelper.GetPathToCurrentFolder() + "\\profile\\" + cellAccount2;
				string path = text + "\\data.tar.gz";
				string path2 = text + ".zip";
				if (File.Exists(path) || File.Exists(path2))
				{
					SetStatusAccount(row, Language.GetValue("Đã backup LD!"));
					SetCellAccount(row, "cProfile", "Yes");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
				}
				else
				{
					SetStatusAccount(row, Language.GetValue("Chưa backup LD!"));
					SetCellAccount(row, "cProfile", "No");
					CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "No");
				}
			}
			catch
			{
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fMoLDPlayer());
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			MoLDPlayer();
		}

		private void MoLDPlayer()
		{
			try
			{
				LoadSetting();
				setting_MoTrinhDuyet = new JSON_Settings("configOpenBrowser");
				if (CountChooseRowInDatagridview() == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chạy!"), 3);
					return;
				}
				bool isRunSwap = setting_general.GetValueBool("isRunSwap");
				string pathLD = ConfigHelper.GetPathLDPlayer();
				if (!Directory.Exists(pathLD))
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer không hợp lệ!"), 3);
					return;
				}
				int maxThread = CountChooseRowInDatagridview();
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
				isStop = false;
				List<int> lstPossition = new List<int>();
				for (int n = 0; n < CountChooseRowInDatagridview(); n++)
				{
					lstPossition.Add(0);
				}
				checkDelayLD_MoLDPLayer = 0;
				lstThread = new List<Thread>();
				new Thread((ThreadStart)delegate
				{
					try
					{
						int num = 0;
						while (num < dtgvAcc.Rows.Count && !isStop)
						{
							if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
							{
								if (isStop || lstThread.Count >= maxThread)
								{
									break;
								}
								if (isStop)
								{
									break;
								}
								int row = num++;
								Thread thread = new Thread((ThreadStart)delegate
								{
									try
									{
										int indexOfPossitionApp = MCommon.Common.GetIndexOfPossitionApp(ref lstPossition);
										MoLDPlayerOneThread(row, indexOfPossitionApp + 1, isRunSwap, pathLD);
									}
									catch (Exception ex3)
									{
										MCommon.Common.ExportError(null, ex3);
									}
								})
								{
									Name = row.ToString()
								};
								lstThread.Add(thread);
								MCommon.Common.DelayTime(1.0);
								thread.Start();
							}
							else
							{
								num++;
							}
							if (isStop)
							{
								break;
							}
						}
						for (int num2 = 0; num2 < lstThread.Count; num2++)
						{
							lstThread[num2].Join();
						}
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2);
					}
				}).Start();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
			}
		}

		private void MoLDPlayerOneThread(int indexRow, int indexPos, bool isRunSwap, string pathLD)
		{
			string text = "";
			Device device = null;
			int num = 0;
			bool flag = false;
			string text2 = "";
			int typeProxy = 0;
			string text3 = "";
			TinsoftProxy tinsoftProxy = null;
			XproxyProxy xproxyProxy = null;
			TMProxy tMProxy = null;
			ProxyWeb proxyWeb = null;
			ShopLike shopLike = null;
			bool flag2 = false;
			string text4 = "";
			string text5 = GetCellAccount(indexRow, "cUid");
			string cellAccount = GetCellAccount(indexRow, "cId");
			GetCellAccount(indexRow, "cEmail");
			string cellAccount2 = GetCellAccount(indexRow, "cFa2");
			string cellAccount3 = GetCellAccount(indexRow, "cPassword");
			string cellAccount4 = GetCellAccount(indexRow, "cCookies");
			string cellAccount5 = GetCellAccount(indexRow, "cToken");
			GetCellAccount(indexRow, "cUseragent");
			if (text5 == "")
			{
				text5 = Regex.Match(cellAccount4, "c_user=(.*?);").Groups[1].Value;
			}
			if (isStop)
			{
				SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
			}
			else
			{
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
									foreach (ShopLike item in listShopLike)
									{
										if (shopLike == null || item.daSuDung < shopLike.daSuDung)
										{
											shopLike = item;
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
									shopLike.dangSuDung++;
									shopLike.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag6 = true;
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
									flag6 = false;
								}
							}
							if (!flag6)
							{
								shopLike.dangSuDung--;
								shopLike.daSuDung--;
								continue;
							}
							goto default;
						}
					case 11:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy Proxyv6..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								proxyWeb = null;
								while (!isStop)
								{
									foreach (ProxyWeb item2 in listProxyWeb)
									{
										if (proxyWeb == null || item2.daSuDung < proxyWeb.daSuDung)
										{
											proxyWeb = item2;
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
									proxyWeb.dangSuDung++;
									proxyWeb.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag8 = true;
							if (setting_general.GetValueInt("nudDelayCheckIP") > 0)
							{
								SetStatusAccount(indexRow, text2 + "Delay check IP...");
								MCommon.Common.DelayTime(setting_general.GetValueInt("nudDelayCheckIP"));
							}
							if (setting_general.GetValueBool("ckbKhongCheckIP"))
							{
								goto IL_06d3;
							}
							text2 = "(IP: " + text.Split(':')[0] + ") ";
							SetStatusAccount(indexRow, text2 + "Check IP...");
							string proxy = text.Split(':')[0] + ":" + text.Split(':')[1];
							int num6 = 0;
							while (true)
							{
								if (num6 < 30)
								{
									MCommon.Common.DelayTime(1.0);
									text3 = MCommon.Common.CheckProxy(proxy, typeProxy);
									if (!(text3 != ""))
									{
										if (!isStop)
										{
											num6++;
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										break;
									}
								}
								if (text3 == "")
								{
									flag8 = false;
								}
								goto IL_06d3;
							}
							goto end_IL_0402;
							IL_06d3:
							if (!flag8)
							{
								proxyWeb.dangSuDung--;
								proxyWeb.daSuDung--;
								continue;
							}
							text = text.Split(':')[0] + ":" + text.Split(':')[1];
							goto default;
							end_IL_0402:;
						}
						break;
					case 10:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy TMProxy..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								tMProxy = null;
								while (!isStop)
								{
									foreach (TMProxy item3 in listTMProxy)
									{
										if (tMProxy == null || item3.daSuDung < tMProxy.daSuDung)
										{
											tMProxy = item3;
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
									tMProxy.dangSuDung++;
									tMProxy.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag4 = true;
							if (!setting_general.GetValueBool("ckbKhongCheckIP"))
							{
								text2 = "(IP: " + text.Split(':')[0] + ") ";
								SetStatusAccount(indexRow, text2 + "Check IP...");
								text3 = MCommon.Common.CheckProxy(text, 0);
								if (text3 == "")
								{
									flag4 = false;
								}
							}
							if (!flag4)
							{
								tMProxy.dangSuDung--;
								tMProxy.daSuDung--;
								continue;
							}
							goto default;
						}
					case 8:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy Xproxy..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								xproxyProxy = null;
								while (!isStop)
								{
									foreach (XproxyProxy item4 in listxProxy)
									{
										if (xproxyProxy == null || (item4.isProxyLive && item4.daSuDung < xproxyProxy.daSuDung))
										{
											xproxyProxy = item4;
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
								xproxyProxy.dangSuDung++;
								xproxyProxy.daSuDung++;
								break;
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag3 = true;
							if (setting_general.GetValueBool("ckbKhongCheckIP"))
							{
								goto IL_0c25;
							}
							text2 = "(IP: " + text.Split(':')[0] + ") ";
							SetStatusAccount(indexRow, text2 + "Check IP...");
							int num2 = 0;
							while (true)
							{
								if (num2 < 30)
								{
									MCommon.Common.DelayTime(1.0);
									text3 = MCommon.Common.CheckProxy(text, typeProxy);
									if (!(text3 != ""))
									{
										if (!isStop)
										{
											num2++;
											continue;
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
										break;
									}
								}
								if (text3 == "")
								{
									flag3 = false;
								}
								goto IL_0c25;
							}
							goto end_IL_09cc;
							IL_0c25:
							if (!flag3)
							{
								xproxyProxy.dangSuDung--;
								xproxyProxy.daSuDung--;
								continue;
							}
							goto default;
							end_IL_09cc:;
						}
						break;
					case 7:
						SetStatusAccount(indexRow, Language.GetValue("Đang lấy proxy Tinsoft..."));
						lock (lock_StartProxy)
						{
							while (!isStop)
							{
								tinsoftProxy = null;
								while (!isStop)
								{
									foreach (TinsoftProxy item5 in listTinsoft)
									{
										if (tinsoftProxy == null || item5.daSuDung < tinsoftProxy.daSuDung)
										{
											tinsoftProxy = item5;
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
									tinsoftProxy.dangSuDung++;
									tinsoftProxy.daSuDung++;
									break;
								}
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							bool flag5 = true;
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
								tinsoftProxy.dangSuDung--;
								tinsoftProxy.daSuDung--;
								continue;
							}
							goto default;
						}
					case 9:
						text = GetCellAccount(indexRow, "cProxy");
						typeProxy = (text.EndsWith("*1") ? 1 : 0);
						if (text.EndsWith("*0") || text.EndsWith("*1"))
						{
							text = text.Substring(0, text.Length - 2);
						}
						goto default;
					default:
						{
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
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
									bool flag7 = false;
									int num3 = 0;
									while (num3 < 30)
									{
										MCommon.Common.DelayTime(1.0);
										text3 = MCommon.Common.CheckProxy(text, typeProxy);
										if (!(text3 != ""))
										{
											if (!isStop)
											{
												num3++;
												continue;
											}
											goto IL_10fc;
										}
										flag7 = true;
										break;
									}
									if (!flag7)
									{
										if (text != "")
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không thể kết nối proxy!"));
										}
										else
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không có kết nối Internet!"));
										}
										break;
									}
								}
								text2 = "(IP: " + text3 + ") ";
							}
							if (isStop)
							{
								SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
								break;
							}
							try
							{
								if (isRunSwap)
								{
									device = new Device(pathLD, indexPos.ToString() ?? "");
									if (!Directory.Exists(pathLD + "\\vms\\leidian" + indexPos))
									{
										SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị..."));
										ADBHelper.AddDevice(pathLD);
										for (int i = 0; i < 2; i++)
										{
											ADBHelper.AddDevice(pathLD);
											if (Directory.Exists(pathLD + "\\vms\\leidian" + indexPos))
											{
												break;
											}
										}
										SetStatusAccount(indexRow, text2 + Language.GetValue("Cấu hình thiết bị..."));
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
										SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị, chờ đến lượt..."));
										lock (lock_checkDelayCreateDevice)
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị..."));
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
												SetStatusAccount(indexRow, text2 + Language.GetValue("Tạo thiết bị thất bại!"));
												break;
											}
										}
										device = new Device(pathLD, text6);
										SetCellAccount(indexRow, "cDevice", text6);
										CommonSQL.UpdateFieldToAccount(cellAccount, "device", text6);
										SetStatusAccount(indexRow, text2 + Language.GetValue("Cấu hình thiết bị..."));
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
								lock (lock_checkDelayLD_MoLDPLayer)
								{
									if (setting_general.GetValueInt("typeOpenDevice") == 0)
									{
										while (true)
										{
											if (isOpeningDevice_MoLDPLayer)
											{
												MCommon.Common.DelayTime(0.5);
												if (isStop)
												{
													SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
													goto end_IL_0ec8;
												}
												continue;
											}
											isOpeningDevice_MoLDPLayer = true;
											break;
										}
									}
									else if (checkDelayLD_MoLDPLayer > 0)
									{
										int num4 = rd.Next(setting_general.GetValueInt("nudDelayOpenDeviceFrom", 1), setting_general.GetValueInt("nudDelayOpenDeviceFrom", 1) + 1);
										if (num4 > 0)
										{
											int tickCount = Environment.TickCount;
											while ((Environment.TickCount - tickCount) / 1000 - num4 < 0)
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiê\u0301t bi\u0323 sau {time}s...".Replace("{time}", (num4 - (Environment.TickCount - tickCount) / 1000).ToString())));
												MCommon.Common.DelayTime(0.5);
												if (isStop)
												{
													SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
													goto end_IL_0ec8;
												}
											}
										}
									}
									else
									{
										checkDelayLD_MoLDPLayer++;
									}
								}
								int num5 = 0;
								while (true)
								{
									SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiết bị..."));
									device.Open();
									if (device.process != null)
									{
										if (!device.CheckOpenedDevice())
										{
											if (num5 == 0)
											{
												num5++;
												device.Close();
												continue;
											}
											SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở thiết bị!"));
											isOpeningDevice_MoLDPLayer = false;
											break;
										}
										isOpeningDevice_MoLDPLayer = false;
										SetStatusAccount(indexRow, text2 + Language.GetValue("Mở thiết bị thành công!"));
										for (int k = 0; k < 5; k++)
										{
											device.lstPackages = device.GetListPackages();
											if (device.lstPackages.Contains("com.facebook.katana") && device.lstPackages.Contains("com.android.adbkeyboard"))
											{
												break;
											}
											if (!device.lstPackages.Contains("com.facebook.katana"))
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Install App Facebook..."));
												device.LoadStatusLD("Install App Facebook...");
												device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\facebook.apk");
											}
											if (!device.lstPackages.Contains("com.android.adbkeyboard"))
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Install App Keyboard..."));
												device.LoadStatusLD("Install App Keyboard...");
												device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\ADBKeyboard.apk");
											}
										}
										if (!device.lstPackages.Contains("com.facebook.katana") || !device.lstPackages.Contains("com.android.adbkeyboard"))
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i Install App!"));
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
													SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i Install App Proxy!"));
													break;
												}
												device.ClearDataApp("com.cell47.College_Proxy");
												SetStatusAccount(indexRow, text2 + Language.GetValue("Connect proxy..."));
												device.LoadStatusLD("Connect proxy...");
												if (!ConnectProxy(device, text))
												{
													SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i Connect proxy!"));
													break;
												}
												device.InputKey(Device.KeyEvent.KEYCODE_HOME);
											}
										}
										if (isRunSwap)
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Restore dữ liệu Fb..."));
											device.RestoreAccountFacebook(text5);
										}
										device.LoadStatusLD("Open Facebook...");
										SetStatusAccount(indexRow, text2 + Language.GetValue("Mở app Facebook..."));
										string text7 = device.OpenFacebookAndCheckStatusLogin();
										if (text7.Split('|')[0] == "0")
										{
											SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở app Facebook!"));
											break;
										}
										num = ((!(text7.Split('|')[1] == "0") && !(text7.Split('|')[1] == "11")) ? Convert.ToInt32(text7.Split('|')[1]) : LoginFacebook(device, indexRow, text2));
										switch (num)
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
											for (int m = 0; m < 10; m++)
											{
												text7 = device.OpenFacebookAndCheckStatusLogin();
												if (!(text7.Split('|')[1] == "1"))
												{
													device.DelayTime(1.0);
													continue;
												}
												num = 1;
												break;
											}
											if (num != 1)
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Facebook bắt add sđt!"));
											}
											break;
										}
										case 10:
											SetStatusAccount(indexRow, text2 + Language.GetValue("Không thê\u0309 login!"));
											break;
										}
										if (num != 1 && num != 8)
										{
											break;
										}
										flag = true;
										device.BackupConfigDevice(text5);
										if (num == 1)
										{
											if (isRunSwap && setting_MoTrinhDuyet.GetValueBool("isBackupAccount"))
											{
												SetStatusAccount(indexRow, text2 + Language.GetValue("Backup dữ liệu Fb..."), device);
												device.BackupAccountFacebook(text5, cellAccount3, cellAccount2);
												CommonSQL.UpdateFieldToAccount(cellAccount, "profile", "Yes");
												SetCellAccount(indexRow, "cProfile", "Yes");
											}
											SetStatusAccount(indexRow, text2 + Language.GetValue("Đăng nhập thành công!"));
										}
										if (flag2 = !CheckIsUidFacebook(text5))
										{
											text4 = text5;
											text5 = Regex.Match(device.GetTokenCookie().Split('|')[1] + ";", "c_user=(.*?);").Groups[1].Value;
											if (text5.Trim() != "")
											{
												CommonSQL.UpdateFieldToAccount(cellAccount, "uid", text5);
												SetCellAccount(indexRow, "cUid", text5);
											}
										}
										if (setting_MoTrinhDuyet.GetValueBool("isGetCookie"))
										{
											string tokenCookie = device.GetTokenCookie();
											cellAccount5 = tokenCookie.Split('|')[0];
											cellAccount4 = tokenCookie.Split('|')[1];
											CommonSQL.UpdateFieldToAccount(cellAccount, "token", cellAccount5);
											SetCellAccount(indexRow, "cToken", cellAccount5);
											CommonSQL.UpdateFieldToAccount(cellAccount, "cookie1", cellAccount4);
											SetCellAccount(indexRow, "cCookies", cellAccount4);
										}
										break;
									}
									SetStatusAccount(indexRow, text2 + Language.GetValue("Lỗi mở thiết bị!"));
									isOpeningDevice = false;
									break;
								}
							}
							catch (Exception ex)
							{
								device.ExportError(ex, "Lô\u0303i không xa\u0301c đi\u0323nh!");
								SetStatusAccount(indexRow, text2 + Language.GetValue("Lô\u0303i không xa\u0301c đi\u0323nh!"));
								MCommon.Common.ExportError(null, ex);
							}
							break;
						}
						IL_10fc:
						SetStatusAccount(indexRow, text2 + Language.GetValue("Đã dừng!"));
						break;
						end_IL_0ec8:
						break;
					}
					break;
				}
			}
			if (!flag && setting_MoTrinhDuyet.GetValueBool("isAutoCloseChromeLoginFail"))
			{
				try
				{
					device.Close();
				}
				catch
				{
				}
			}
			if (flag2 && Directory.Exists("profile\\" + text4) && !string.IsNullOrEmpty(text4))
			{
				string text8 = "profile\\" + text4;
				string pathTo = "profile\\" + text5;
				if (!MCommon.Common.MoveFolder(text8, pathTo) && MCommon.Common.CopyFolder(text8, pathTo))
				{
					MCommon.Common.DeleteFolder(text8);
				}
			}
		}

		private void lấyTokenCookieTừDữLiệuBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int iThread = 0;
			int maxThread = 10;
			string pathLDPlayer = ConfigHelper.GetPathLDPlayer(1);
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
								SetStatusAccount(row, "Đang check...");
								GetTokenCookie(row, pathLDPlayer);
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

		private void GetTokenCookie(int indexRow, string pathLDPlayer)
		{
			try
			{
				string cellAccount = GetCellAccount(indexRow, "cId");
				GetCellAccount(indexRow, "cUid");
				string cellAccount2 = GetCellAccount(indexRow, "cDevice");
				string text = pathLDPlayer + "\\vms\\leidian" + cellAccount2;
				if (cellAccount2 == "" || !Directory.Exists(text))
				{
					SetStatusAccount(indexRow, "Tài khoản này chưa tạo LD!");
					return;
				}
				SetStatusAccount(indexRow, "Đang lấy token/cookie...");
				string tokenCookieFromLDPlayer = GetTokenCookieFromLDPlayer(text);
				if (tokenCookieFromLDPlayer != "|")
				{
					string text2 = tokenCookieFromLDPlayer.Split('|')[0];
					string text3 = tokenCookieFromLDPlayer.Split('|')[1];
					if (text2 != "")
					{
						SetCellAccount(indexRow, "cToken", text2);
						CommonSQL.UpdateFieldToAccount(cellAccount, "token", text2);
					}
					if (text3 != "")
					{
						SetCellAccount(indexRow, "cCookies", text3);
						CommonSQL.UpdateFieldToAccount(cellAccount, "cookie1", text3);
					}
					SetStatusAccount(indexRow, "Đã cập nhật token/cookie!");
					SetRowColor(indexRow, 2);
				}
				else
				{
					SetStatusAccount(indexRow, "Không lấy được token/cookie!");
				}
			}
			catch
			{
				SetStatusAccount(indexRow, "Không lấy được token/cookie!");
			}
		}

		public string GetTokenCookieFromLDPlayer(string pathToLDPlayer)
		{
			string path = Path.Combine(pathToLDPlayer, "data.vmdk");
			string text = "";
			string text2 = "";
			string result = "";
			if (File.Exists(path))
			{
				using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using BufferedStream stream2 = new BufferedStream(stream);
					using StreamReader streamReader = new StreamReader(stream2);
					string text3;
					while ((text3 = streamReader.ReadLine()) != null)
					{
						if (!text3.Contains("access_token\":\""))
						{
							if (text3.Contains("accessToken\":\""))
							{
								string text4 = Regex.Split(text3, "accessToken\":\"")[1].Split('"')[0];
								Console.WriteLine(text4);
								text = text4;
								if (text2 != "" && text != "")
								{
									break;
								}
							}
							else
							{
								if (!text3.Contains("[{\"name\":\"c_user\""))
								{
									continue;
								}
								string json = "[{\"name\":\"c_user\"" + text3.Split(new string[1] { "[{\"name\":\"c_user\"" }, StringSplitOptions.None)[1].Split(']')[0].Replace("\\\"", "\"") + "]";
								JArray jArray = JArray.Parse(json);
								List<string> list = new List<string>();
								foreach (JToken item in jArray)
								{
									list.Add(item["name"]!.ToString() + "=" + item["value"]!.ToString());
								}
								string text5 = string.Join("; ", list);
								text2 = text5;
								if (text2 != "" && text != "")
								{
									break;
								}
							}
							continue;
						}
						string text6 = Regex.Split(text3, "access_token\":\"")[1].Split('"')[0];
						text = text6;
						string json2 = Regex.Split(text3, "session_cookie_string\":\"")[1].Split(']')[0].Replace("\\\"", "\"") + "]";
						JArray jArray2 = JArray.Parse(json2);
						List<string> list2 = new List<string>();
						foreach (JToken item2 in jArray2)
						{
							list2.Add(item2["name"]!.ToString() + "=" + item2["value"]!.ToString());
						}
						string text7 = string.Join("; ", list2);
						text2 = text7;
						break;
					}
				}
				result = text + "|" + text2;
			}
			return result;
		}

		private void xóaLDPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (CountChooseRowInDatagridview() == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chạy!"), 3);
					return;
				}
				LoadSetting();
				string pathLD = ConfigHelper.GetPathLDPlayer(1);
				if (pathLD == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer trống!"), 3);
					return;
				}
				if (!Directory.Exists(pathLD))
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer không hợp lệ!"), 3);
					return;
				}
				cControl("start");
				int iThread = 0;
				int maxThread = setting_general.GetValueInt("nudHideThread", 10);
				isStop = false;
				new Thread((ThreadStart)delegate
				{
					int num = 0;
					while (num < dtgvAcc.Rows.Count && !isStop)
					{
						if (Convert.ToBoolean(dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							if (iThread < maxThread)
							{
								Interlocked.Increment(ref iThread);
								int row = num++;
								new Thread((ThreadStart)delegate
								{
									SetStatusAccount(row, Language.GetValue("Đang check..."));
									DeleteDeviceOneThread(row, pathLD);
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
					cControl("stop");
				}).Start();
			}
			catch
			{
			}
		}

		private void tạoLDPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (CountChooseRowInDatagridview() == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn tài khoản muốn chạy!"), 3);
					return;
				}
				LoadSetting();
				string pathLD = ConfigHelper.GetPathLDPlayer(1);
				if (pathLD == "")
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer trống!"), 3);
					return;
				}
				if (!Directory.Exists(pathLD))
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Đường dẫn LDPlayer không hợp lệ!"), 3);
					return;
				}
				cControl("start");
				setting_general.GetValueInt("nudHideThread", 10);
				isStop = false;
				new Thread((ThreadStart)delegate
				{
					new List<string>();
					for (int i = 0; i < dtgvAcc.Rows.Count; i++)
					{
						if (isStop)
						{
							break;
						}
						if (Convert.ToBoolean(dtgvAcc.Rows[i].Cells["cChose"].Value))
						{
							CreateDeviceOneThread(i, pathLD);
						}
					}
					cControl("stop");
				}).Start();
			}
			catch
			{
			}
		}

		private void CreateDeviceOneThread(int indexRow, string pathLD)
		{
			string cellAccount = GetCellAccount(indexRow, "cId");
			string cellAccount2 = GetCellAccount(indexRow, "cUid");
			string text = GetCellAccount(indexRow, "cDevice");
			if (text == "" || !Directory.Exists(pathLD + "\\vms\\leidian" + text))
			{
				SetStatusAccount(indexRow, Language.GetValue("Tạo thiết bị..."));
				List<string> listIndexLDPlayer = ADBHelper.GetListIndexLDPlayer(pathLD);
				ADBHelper.AddDevice(pathLD);
				for (int i = 0; i < 30; i++)
				{
					text = ADBHelper.GetListIndexLDPlayer(pathLD).Except(listIndexLDPlayer).First();
					if (text != "")
					{
						break;
					}
				}
				if (text == "")
				{
					SetStatusAccount(indexRow, Language.GetValue("Tạo thiết bị thất bại!"));
					return;
				}
				Device device = new Device(pathLD, text);
				SetCellAccount(indexRow, "cDevice", text);
				CommonSQL.UpdateFieldToAccount(cellAccount, "device", text);
				SetStatusAccount(indexRow, Language.GetValue("Cấu hình thiết bị..."));
				lock (lock_restoreDevice)
				{
					device.Restore();
				}
				device.ChangeHardwareLDPlayer2();
				device.ChangeFileConfig();
				if (File.Exists(FileHelper.GetPathToCurrentFolder() + "\\device\\" + cellAccount2 + "\\config"))
				{
					device.RestoreConfigDevice(cellAccount2);
					device.ChangeFileConfig();
				}
				else
				{
					device.BackupConfigDevice(cellAccount2);
				}
				SetStatusAccount(indexRow, Language.GetValue("Tạo thiết bị thành công!"));
			}
			else
			{
				SetStatusAccount(indexRow, Language.GetValue("Đã tạo LD từ trước!"));
			}
		}

		private void DeleteDeviceOneThread(int indexRow, string pathLD)
		{
			string cellAccount = GetCellAccount(indexRow, "cId");
			string cellAccount2 = GetCellAccount(indexRow, "cDevice");
			if (cellAccount2 != "" && Directory.Exists(pathLD + "\\vms\\leidian" + cellAccount2))
			{
				try
				{
					SetStatusAccount(indexRow, Language.GetValue("Đang xo\u0301a LDPlayer..."));
					Directory.Delete(pathLD + "\\vms\\leidian" + cellAccount2, recursive: true);
					SetCellAccount(indexRow, "cDevice", "");
					CommonSQL.UpdateMultiFieldToAccount(cellAccount, "device", "");
					SetStatusAccount(indexRow, Language.GetValue("Xóa LDPlayer thành công!"));
				}
				catch
				{
					SetStatusAccount(indexRow, Language.GetValue("Xóa LDPlayer thất bại!"));
				}
			}
			else
			{
				SetStatusAccount(indexRow, Language.GetValue("Chưa tạo LDPlayer!"));
			}
		}

		private void dọnDẹpLDPlayerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.ShowForm(new fClearLDPlayer());
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(ex.ToString(), 3);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		private void btnViewLivestream_Click_1(object sender, EventArgs e)
		{
			Hide();
			new fSpamBaiViet().ShowDialog();
			Show();
		}

		private void btnPost_Click_1(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fDangBai().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fUpAvatar().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fUpCover().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void btnShare_Click_1(object sender, EventArgs e)
		{
			try
			{
				Hide();
				new fShareBai().ShowDialog();
				Show();
			}
			catch
			{
			}
		}

		private void btnRandomIndexRow_Click(object sender, EventArgs e)
		{
			RandomThuTuTaiKhoan();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCauHinhLDPlayer());
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fMain));
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
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
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
			cậpNhậtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mậtKhẩuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			tokenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			cookieToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			mailKhôiPhụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mã2FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			useragentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			proxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ghiChuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ngàySinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			chuyểnThưMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			chứcNăngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			locTrungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tảiXuốngAvatarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			loginHotmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			loginYandexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			lDPlayerThườngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tạoLDPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xóaLDPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			dọnDẹpLDPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
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
			toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			taiKhoanĐaXoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tiệnÍchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkLiveUidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkProxyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			checkHotmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			lọcTrùngDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xửLýChuỗiOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			liênHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			grQuanLyThuMuc = new System.Windows.Forms.GroupBox();
			btnLoadAcc = new MetroFramework.Controls.MetroButton();
			btnEditFile = new MetroFramework.Controls.MetroButton();
			btnDeleteFile = new MetroFramework.Controls.MetroButton();
			btnAddFile = new MetroFramework.Controls.MetroButton();
			cbbTinhTrang = new MetroFramework.Controls.MetroComboBox();
			cbbThuMuc = new MetroFramework.Controls.MetroComboBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			button9 = new System.Windows.Forms.Button();
			grTimKiem = new System.Windows.Forms.GroupBox();
			BtnSearch = new MetroFramework.Controls.MetroButton();
			cbbSearch = new System.Windows.Forms.ComboBox();
			txbSearch = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			lblKey = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
			txbUid = new System.Windows.Forms.ToolStripStatusLabel();
			lblUser = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
			lblDateExpried = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountSelect = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountTotal = new System.Windows.Forms.ToolStripStatusLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			btnPause = new System.Windows.Forms.Button();
			btnInteract = new System.Windows.Forms.Button();
			btnShare = new System.Windows.Forms.Button();
			btnPost = new System.Windows.Forms.Button();
			plTrangThai = new System.Windows.Forms.Panel();
			lblTrangThai = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			btnRandomIndexRow = new MetroFramework.Controls.MetroButton();
			plChucNang = new System.Windows.Forms.Panel();
			button6 = new System.Windows.Forms.Button();
			button5 = new System.Windows.Forms.Button();
			btnViewLivestream = new System.Windows.Forms.Button();
			button7 = new System.Windows.Forms.Button();
			timer1 = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)dtgvAcc).BeginInit();
			ctmsAcc.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			bunifuCards1.SuspendLayout();
			menuStrip1.SuspendLayout();
			grQuanLyThuMuc.SuspendLayout();
			grTimKiem.SuspendLayout();
			statusStrip1.SuspendLayout();
			plTrangThai.SuspendLayout();
			panel1.SuspendLayout();
			plChucNang.SuspendLayout();
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
			dtgvAcc.Location = new System.Drawing.Point(9, 153);
			dtgvAcc.Name = "dtgvAcc";
			dtgvAcc.RowHeadersVisible = false;
			dtgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvAcc.Size = new System.Drawing.Size(1225, 429);
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
			ctmsAcc.Items.AddRange(new System.Windows.Forms.ToolStripItem[13]
			{
				chọnLiveToolStripMenuItem, bỏChọnTấtCảToolStripMenuItem, copyToolStripMenuItem, toolStripMenuItem1, xóaTàiKhoảnToolStripMenuItem, checkCookieToolStripMenuItem, câpNhâtThôngTinCaNhânToolStripMenuItem, cậpNhậtDữLiệuToolStripMenuItem, chuyểnThưMụcToolStripMenuItem, chứcNăngToolStripMenuItem1,
				lDPlayerThườngToolStripMenuItem, toolStripMenuItem4, tảiLạiDanhSáchToolStripMenuItem
			});
			ctmsAcc.Name = "ctmsAcc";
			ctmsAcc.Size = new System.Drawing.Size(175, 290);
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
			toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem2, toolStripMenuItem3 });
			toolStripMenuItem1.Image = maxcare.Properties.Resources._6333;
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
			toolStripMenuItem1.Text = "Mở LDPlayer";
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
			toolStripMenuItem2.Text = "Tiến hành mở";
			toolStripMenuItem2.Click += new System.EventHandler(toolStripMenuItem2_Click);
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
			toolStripMenuItem3.Text = "Cài đặt cấu hình mở";
			toolStripMenuItem3.Click += new System.EventHandler(toolStripMenuItem3_Click);
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
			cậpNhậtDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10] { cậpToolStripMenuItem, mậtKhẩuToolStripMenuItem1, tokenToolStripMenuItem2, cookieToolStripMenuItem3, mailKhôiPhụcToolStripMenuItem, mã2FAToolStripMenuItem, useragentToolStripMenuItem, proxyToolStripMenuItem, ghiChuToolStripMenuItem, ngàySinhToolStripMenuItem });
			cậpNhậtDữLiệuToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cậpNhậtDữLiệuToolStripMenuItem.Image");
			cậpNhậtDữLiệuToolStripMenuItem.Name = "cậpNhậtDữLiệuToolStripMenuItem";
			cậpNhậtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			cậpNhậtDữLiệuToolStripMenuItem.Text = "Cập nhật dữ liệu";
			cậpToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_multiline_text_32px;
			cậpToolStripMenuItem.Name = "cậpToolStripMenuItem";
			cậpToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			cậpToolStripMenuItem.Text = "Cập nhật hàng loạt theo UID";
			cậpToolStripMenuItem.Click += new System.EventHandler(cậpToolStripMenuItem_Click);
			mậtKhẩuToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("mậtKhẩuToolStripMenuItem1.Image");
			mậtKhẩuToolStripMenuItem1.Name = "mậtKhẩuToolStripMenuItem1";
			mậtKhẩuToolStripMenuItem1.Size = new System.Drawing.Size(224, 22);
			mậtKhẩuToolStripMenuItem1.Text = "Password";
			mậtKhẩuToolStripMenuItem1.Click += new System.EventHandler(mậtKhẩuToolStripMenuItem1_Click);
			tokenToolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("tokenToolStripMenuItem2.Image");
			tokenToolStripMenuItem2.Name = "tokenToolStripMenuItem2";
			tokenToolStripMenuItem2.Size = new System.Drawing.Size(224, 22);
			tokenToolStripMenuItem2.Text = "Token";
			tokenToolStripMenuItem2.Click += new System.EventHandler(NhậpDữLiệuToolStripMenuItem2_Click);
			cookieToolStripMenuItem3.Image = (System.Drawing.Image)resources.GetObject("cookieToolStripMenuItem3.Image");
			cookieToolStripMenuItem3.Name = "cookieToolStripMenuItem3";
			cookieToolStripMenuItem3.Size = new System.Drawing.Size(224, 22);
			cookieToolStripMenuItem3.Text = "Cookie";
			cookieToolStripMenuItem3.Click += new System.EventHandler(NhậpDữLiệuToolStripMenuItem1_Click);
			mailKhôiPhụcToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mailKhôiPhụcToolStripMenuItem.Image");
			mailKhôiPhụcToolStripMenuItem.Name = "mailKhôiPhụcToolStripMenuItem";
			mailKhôiPhụcToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			mailKhôiPhụcToolStripMenuItem.Text = "Email|Pass Email";
			mailKhôiPhụcToolStripMenuItem.Click += new System.EventHandler(mailKhôiPhụcToolStripMenuItem_Click);
			mã2FAToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("mã2FAToolStripMenuItem.Image");
			mã2FAToolStripMenuItem.Name = "mã2FAToolStripMenuItem";
			mã2FAToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			mã2FAToolStripMenuItem.Text = "Mã 2FA";
			mã2FAToolStripMenuItem.Click += new System.EventHandler(mã2FAToolStripMenuItem_Click);
			useragentToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("useragentToolStripMenuItem.Image");
			useragentToolStripMenuItem.Name = "useragentToolStripMenuItem";
			useragentToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			useragentToolStripMenuItem.Text = "Useragent";
			useragentToolStripMenuItem.Click += new System.EventHandler(useragentToolStripMenuItem_Click);
			proxyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("proxyToolStripMenuItem.Image");
			proxyToolStripMenuItem.Name = "proxyToolStripMenuItem";
			proxyToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			proxyToolStripMenuItem.Text = "Proxy";
			proxyToolStripMenuItem.Click += new System.EventHandler(proxyToolStripMenuItem_Click);
			ghiChuToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_note_48px;
			ghiChuToolStripMenuItem.Name = "ghiChuToolStripMenuItem";
			ghiChuToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			ghiChuToolStripMenuItem.Text = "Ghi chu\u0301";
			ghiChuToolStripMenuItem.Click += new System.EventHandler(ghiChuToolStripMenuItem_Click);
			ngàySinhToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_calendar_5_48px;
			ngàySinhToolStripMenuItem.Name = "ngàySinhToolStripMenuItem";
			ngàySinhToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			ngàySinhToolStripMenuItem.Text = "Ngày sinh";
			ngàySinhToolStripMenuItem.Click += new System.EventHandler(ngàySinhToolStripMenuItem_Click);
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
			lDPlayerThườngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { tạoLDPlayerToolStripMenuItem, xóaLDPlayerToolStripMenuItem, dọnDẹpLDPlayerToolStripMenuItem });
			lDPlayerThườngToolStripMenuItem.Image = maxcare.Properties.Resources.ldplayer_logo;
			lDPlayerThườngToolStripMenuItem.Name = "lDPlayerThườngToolStripMenuItem";
			lDPlayerThườngToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			lDPlayerThườngToolStripMenuItem.Text = "LDPlayer (thường)";
			tạoLDPlayerToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_add_24px_1;
			tạoLDPlayerToolStripMenuItem.Name = "tạoLDPlayerToolStripMenuItem";
			tạoLDPlayerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			tạoLDPlayerToolStripMenuItem.Text = "Tạo LDPlayer";
			tạoLDPlayerToolStripMenuItem.Click += new System.EventHandler(tạoLDPlayerToolStripMenuItem_Click);
			xóaLDPlayerToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_delete_bin;
			xóaLDPlayerToolStripMenuItem.Name = "xóaLDPlayerToolStripMenuItem";
			xóaLDPlayerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			xóaLDPlayerToolStripMenuItem.Text = "Xóa LDPlayer";
			xóaLDPlayerToolStripMenuItem.Click += new System.EventHandler(xóaLDPlayerToolStripMenuItem_Click);
			dọnDẹpLDPlayerToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_broom;
			dọnDẹpLDPlayerToolStripMenuItem.Name = "dọnDẹpLDPlayerToolStripMenuItem";
			dọnDẹpLDPlayerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			dọnDẹpLDPlayerToolStripMenuItem.Text = "Dọn dẹp LDPlayer";
			dọnDẹpLDPlayerToolStripMenuItem.Click += new System.EventHandler(dọnDẹpLDPlayerToolStripMenuItem_Click);
			toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { toolStripMenuItem8, toolStripMenuItem9 });
			toolStripMenuItem4.Image = maxcare.Properties.Resources.ldplayer_logo;
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new System.Drawing.Size(174, 22);
			toolStripMenuItem4.Text = "LDPlayer (Swap)";
			toolStripMenuItem8.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem8.Image");
			toolStripMenuItem8.Name = "toolStripMenuItem8";
			toolStripMenuItem8.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem8.Text = "Check profile";
			toolStripMenuItem8.Click += new System.EventHandler(checkFileBackupLDToolStripMenuItem_Click);
			toolStripMenuItem9.Image = (System.Drawing.Image)resources.GetObject("toolStripMenuItem9.Image");
			toolStripMenuItem9.Name = "toolStripMenuItem9";
			toolStripMenuItem9.Size = new System.Drawing.Size(144, 22);
			toolStripMenuItem9.Text = "Xóa profile";
			toolStripMenuItem9.Click += new System.EventHandler(xóaProfileToolStripMenuItem_Click);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(800, 16);
			bunifuCustomLabel1.TabIndex = 3;
			bunifuCustomLabel1.Text = "THICH SYSTEM CARE PRO - Phần Mềm Quản Lý Va\u0300 Chăm So\u0301c Tài Khoản Facebook Trên Giả lập LDPlayer - FB CARE";
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
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { hệThốngToolStripMenuItem, càiĐặtToolStripMenuItem, toolStripMenuItem5, thoátToolStripMenuItem, taiKhoanĐaXoaToolStripMenuItem, tiệnÍchToolStripMenuItem, liênHệToolStripMenuItem });
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
			càiĐặtToolStripMenuItem.Size = new System.Drawing.Size(144, 21);
			càiĐặtToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh tương ta\u0301c";
			càiĐặtToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			càiĐặtToolStripMenuItem.Click += new System.EventHandler(càiĐặtToolStripMenuItem_Click_1);
			toolStripMenuItem5.Image = maxcare.Properties.Resources.ldplayer_logo;
			toolStripMenuItem5.Name = "toolStripMenuItem5";
			toolStripMenuItem5.Size = new System.Drawing.Size(139, 21);
			toolStripMenuItem5.Text = "Câ\u0301u hi\u0300nh LDPlayer";
			toolStripMenuItem5.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			toolStripMenuItem5.Click += new System.EventHandler(toolStripMenuItem5_Click);
			thoátToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_show_property_48px;
			thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			thoátToolStripMenuItem.Size = new System.Drawing.Size(132, 21);
			thoátToolStripMenuItem.Text = "Câ\u0301u hi\u0300nh hiê\u0309n thi\u0323";
			thoátToolStripMenuItem.Click += new System.EventHandler(câuHinhHiênThiToolStripMenuItem_Click);
			taiKhoanĐaXoaToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_delete_bin_21;
			taiKhoanĐaXoaToolStripMenuItem.Name = "taiKhoanĐaXoaToolStripMenuItem";
			taiKhoanĐaXoaToolStripMenuItem.Size = new System.Drawing.Size(134, 21);
			taiKhoanĐaXoaToolStripMenuItem.Text = "Ta\u0300i khoa\u0309n đa\u0303 xo\u0301a";
			taiKhoanĐaXoaToolStripMenuItem.Click += new System.EventHandler(taiKhoanĐaXoaToolStripMenuItem_Click);
			tiệnÍchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { checkLiveUidToolStripMenuItem, checkProxyToolStripMenuItem1, checkHotmailToolStripMenuItem, lọcTrùngDữLiệuToolStripMenuItem, xửLýChuỗiOnlineToolStripMenuItem });
			tiệnÍchToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_circled_menu;
			tiệnÍchToolStripMenuItem.Name = "tiệnÍchToolStripMenuItem";
			tiệnÍchToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
			tiệnÍchToolStripMenuItem.Text = "Tiện ích";
			checkLiveUidToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_checkmark_26px;
			checkLiveUidToolStripMenuItem.Name = "checkLiveUidToolStripMenuItem";
			checkLiveUidToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			checkLiveUidToolStripMenuItem.Text = "Check Live Uid";
			checkLiveUidToolStripMenuItem.Click += new System.EventHandler(checkLiveUidToolStripMenuItem_Click);
			checkProxyToolStripMenuItem1.Image = maxcare.Properties.Resources.icons8_cloud_firewall_64px1;
			checkProxyToolStripMenuItem1.Name = "checkProxyToolStripMenuItem1";
			checkProxyToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
			checkProxyToolStripMenuItem1.Text = "Check Proxy";
			checkProxyToolStripMenuItem1.Click += new System.EventHandler(checkProxyToolStripMenuItem1_Click);
			checkHotmailToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_mail;
			checkHotmailToolStripMenuItem.Name = "checkHotmailToolStripMenuItem";
			checkHotmailToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			checkHotmailToolStripMenuItem.Text = "Check Imap Hotmail";
			checkHotmailToolStripMenuItem.Click += new System.EventHandler(checkHotmailToolStripMenuItem_Click);
			lọcTrùngDữLiệuToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_mail_filter_24px;
			lọcTrùngDữLiệuToolStripMenuItem.Name = "lọcTrùngDữLiệuToolStripMenuItem";
			lọcTrùngDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			lọcTrùngDữLiệuToolStripMenuItem.Text = "Lọc trùng dữ liệu";
			lọcTrùngDữLiệuToolStripMenuItem.Click += new System.EventHandler(lọcTrùngDữLiệuToolStripMenuItem_Click);
			xửLýChuỗiOnlineToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_rss;
			xửLýChuỗiOnlineToolStripMenuItem.Name = "xửLýChuỗiOnlineToolStripMenuItem";
			xửLýChuỗiOnlineToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			xửLýChuỗiOnlineToolStripMenuItem.Text = "Xử lý chuỗi cơ bản";
			xửLýChuỗiOnlineToolStripMenuItem.Click += new System.EventHandler(xửLýChuỗiOnlineToolStripMenuItem_Click);
			liênHệToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_safety_float;
			liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
			liênHệToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
			liênHệToolStripMenuItem.Text = "Liên hệ";
			liênHệToolStripMenuItem.Click += new System.EventHandler(liênHệToolStripMenuItem_Click);
			grQuanLyThuMuc.Controls.Add(btnLoadAcc);
			grQuanLyThuMuc.Controls.Add(btnEditFile);
			grQuanLyThuMuc.Controls.Add(btnDeleteFile);
			grQuanLyThuMuc.Controls.Add(btnAddFile);
			grQuanLyThuMuc.Controls.Add(cbbTinhTrang);
			grQuanLyThuMuc.Controls.Add(cbbThuMuc);
			grQuanLyThuMuc.Controls.Add(label2);
			grQuanLyThuMuc.Controls.Add(label1);
			grQuanLyThuMuc.Controls.Add(button9);
			grQuanLyThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grQuanLyThuMuc.Location = new System.Drawing.Point(572, 65);
			grQuanLyThuMuc.Name = "grQuanLyThuMuc";
			grQuanLyThuMuc.Size = new System.Drawing.Size(662, 53);
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
			btnAddFile.BackgroundImage = maxcare.Properties.Resources.icons8_plus_math_25px1;
			btnAddFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnAddFile.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAddFile.Location = new System.Drawing.Point(404, 19);
			btnAddFile.Name = "btnAddFile";
			btnAddFile.Size = new System.Drawing.Size(25, 25);
			btnAddFile.TabIndex = 4;
			toolTip1.SetToolTip(btnAddFile, "Thêm thư mục");
			btnAddFile.UseSelectable = true;
			btnAddFile.Click += new System.EventHandler(AddFileAccount_Click_1);
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
			button9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button9.BackColor = System.Drawing.Color.White;
			button9.Cursor = System.Windows.Forms.Cursors.Hand;
			button9.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button9.Image = maxcare.Properties.Resources.upload_to_ftp_25px;
			button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button9.Location = new System.Drawing.Point(530, 18);
			button9.Name = "button9";
			button9.Size = new System.Drawing.Size(130, 27);
			button9.TabIndex = 7;
			button9.Text = "Nhập tài khoản";
			button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			button9.UseVisualStyleBackColor = true;
			button9.Click += new System.EventHandler(Button3_Click);
			grTimKiem.Controls.Add(BtnSearch);
			grTimKiem.Controls.Add(cbbSearch);
			grTimKiem.Controls.Add(txbSearch);
			grTimKiem.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grTimKiem.Location = new System.Drawing.Point(282, 65);
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
			statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			statusStrip1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				toolStripStatusLabel1, lblStatus, toolStripStatusLabel3, lblKey, toolStripStatusLabel8, txbUid, lblUser, toolStripStatusLabel9, toolStripStatusLabel10, lblDateExpried,
				toolStripStatusLabel5, lblCountSelect, toolStripStatusLabel7, lblCountTotal
			});
			statusStrip1.Location = new System.Drawing.Point(0, 586);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1242, 22);
			statusStrip1.SizingGrip = false;
			statusStrip1.TabIndex = 9;
			statusStrip1.Text = "statusStrip1";
			statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(statusStrip1_ItemClicked);
			toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(79, 17);
			toolStripStatusLabel1.Text = "Trạng thái:";
			lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.Color.Green;
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(97, 17);
			lblStatus.Text = "Đang kiê\u0309m tra...";
			toolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new System.Drawing.Size(82, 17);
			toolStripStatusLabel3.Text = "Mã thiết bị:";
			lblKey.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblKey.ForeColor = System.Drawing.Color.Teal;
			lblKey.Name = "lblKey";
			lblKey.Size = new System.Drawing.Size(49, 17);
			lblKey.Text = "******";
			toolStripStatusLabel8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel8.Name = "toolStripStatusLabel8";
			toolStripStatusLabel8.Size = new System.Drawing.Size(42, 17);
			toolStripStatusLabel8.Text = "User:";
			txbUid.Name = "txbUid";
			txbUid.Size = new System.Drawing.Size(0, 17);
			lblUser.Name = "lblUser";
			lblUser.Size = new System.Drawing.Size(56, 17);
			lblUser.Text = "******";
			toolStripStatusLabel9.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel9.IsLink = true;
			toolStripStatusLabel9.Name = "toolStripStatusLabel9";
			toolStripStatusLabel9.Size = new System.Drawing.Size(66, 17);
			toolStripStatusLabel9.Text = "Đăng xuâ\u0301t";
			toolStripStatusLabel9.Click += new System.EventHandler(ToolStripStatusLabel9_Click);
			toolStripStatusLabel10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel10.Name = "toolStripStatusLabel10";
			toolStripStatusLabel10.Size = new System.Drawing.Size(99, 17);
			toolStripStatusLabel10.Text = "Ngày hết hạn:";
			lblDateExpried.Name = "lblDateExpried";
			lblDateExpried.Size = new System.Drawing.Size(74, 17);
			lblDateExpried.Text = "20/10/2020";
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
			btnPause.Text = "Dừng Tương Tác      ";
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
			btnInteract.Text = "Chạy Tương Tác      ";
			toolTip1.SetToolTip(btnInteract, "Bă\u0301t đâ\u0300u cha\u0323y tương ta\u0301c");
			btnInteract.UseVisualStyleBackColor = false;
			btnInteract.Click += new System.EventHandler(BtnInteract_Click);
			btnShare.Cursor = System.Windows.Forms.Cursors.Hand;
			btnShare.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnShare.Image = (System.Drawing.Image)resources.GetObject("btnShare.Image");
			btnShare.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnShare.Location = new System.Drawing.Point(139, 1);
			btnShare.Name = "btnShare";
			btnShare.Size = new System.Drawing.Size(128, 29);
			btnShare.TabIndex = 1;
			btnShare.Text = "Auto chia sẻ";
			btnShare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			toolTip1.SetToolTip(btnShare, "Chư\u0301c năng tư\u0323 đô\u0323ng chia se\u0309");
			btnShare.UseVisualStyleBackColor = false;
			btnShare.Click += new System.EventHandler(btnShare_Click_1);
			btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
			btnPost.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnPost.Image = (System.Drawing.Image)resources.GetObject("btnPost.Image");
			btnPost.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnPost.Location = new System.Drawing.Point(3, 1);
			btnPost.Name = "btnPost";
			btnPost.Size = new System.Drawing.Size(128, 29);
			btnPost.TabIndex = 0;
			btnPost.Text = "Auto đăng bài";
			btnPost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			toolTip1.SetToolTip(btnPost, "Chư\u0301c năng tư\u0323 đô\u0323ng đăng ba\u0300i");
			btnPost.UseVisualStyleBackColor = false;
			btnPost.Click += new System.EventHandler(btnPost_Click_1);
			plTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			plTrangThai.BackColor = System.Drawing.Color.Gainsboro;
			plTrangThai.Controls.Add(lblTrangThai);
			plTrangThai.Location = new System.Drawing.Point(868, 36);
			plTrangThai.Name = "plTrangThai";
			plTrangThai.Size = new System.Drawing.Size(373, 26);
			plTrangThai.TabIndex = 10;
			plTrangThai.Visible = false;
			lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
			lblTrangThai.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTrangThai.Location = new System.Drawing.Point(0, 0);
			lblTrangThai.Name = "lblTrangThai";
			lblTrangThai.Size = new System.Drawing.Size(373, 26);
			lblTrangThai.TabIndex = 0;
			lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(btnRandomIndexRow);
			panel1.Controls.Add(plChucNang);
			panel1.Controls.Add(button7);
			panel1.Controls.Add(statusStrip1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1244, 610);
			panel1.TabIndex = 11;
			btnRandomIndexRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			btnRandomIndexRow.Cursor = System.Windows.Forms.Cursors.Hand;
			btnRandomIndexRow.Location = new System.Drawing.Point(1145, 119);
			btnRandomIndexRow.Name = "btnRandomIndexRow";
			btnRandomIndexRow.Size = new System.Drawing.Size(88, 29);
			btnRandomIndexRow.TabIndex = 12;
			btnRandomIndexRow.Text = "Random";
			btnRandomIndexRow.UseSelectable = true;
			btnRandomIndexRow.Click += new System.EventHandler(btnRandomIndexRow_Click);
			plChucNang.Controls.Add(button6);
			plChucNang.Controls.Add(button5);
			plChucNang.Controls.Add(btnViewLivestream);
			plChucNang.Controls.Add(btnShare);
			plChucNang.Controls.Add(btnPost);
			plChucNang.Location = new System.Drawing.Point(5, 118);
			plChucNang.Name = "plChucNang";
			plChucNang.Size = new System.Drawing.Size(682, 31);
			plChucNang.TabIndex = 10;
			button6.Cursor = System.Windows.Forms.Cursors.Hand;
			button6.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button6.Image = maxcare.Properties.Resources.icons8_instagram_check_mark_24px;
			button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			button6.Location = new System.Drawing.Point(547, 1);
			button6.Name = "button6";
			button6.Size = new System.Drawing.Size(128, 29);
			button6.TabIndex = 5;
			button6.Text = "        Up Cover";
			button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button6.UseVisualStyleBackColor = false;
			button6.Click += new System.EventHandler(button6_Click_1);
			button5.Cursor = System.Windows.Forms.Cursors.Hand;
			button5.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button5.Image = maxcare.Properties.Resources.icons8_male_user_24px;
			button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			button5.Location = new System.Drawing.Point(411, 1);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(128, 29);
			button5.TabIndex = 4;
			button5.Text = "      Up Avatar";
			button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button5.UseVisualStyleBackColor = false;
			button5.Click += new System.EventHandler(button5_Click);
			btnViewLivestream.Cursor = System.Windows.Forms.Cursors.Hand;
			btnViewLivestream.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnViewLivestream.Image = maxcare.Properties.Resources.icons8_forward_button_24px;
			btnViewLivestream.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			btnViewLivestream.Location = new System.Drawing.Point(275, 1);
			btnViewLivestream.Name = "btnViewLivestream";
			btnViewLivestream.Size = new System.Drawing.Size(128, 29);
			btnViewLivestream.TabIndex = 4;
			btnViewLivestream.Text = "Spam ba\u0300i viê\u0301t";
			btnViewLivestream.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnViewLivestream.UseVisualStyleBackColor = false;
			btnViewLivestream.Click += new System.EventHandler(btnViewLivestream_Click_1);
			button7.Cursor = System.Windows.Forms.Cursors.Hand;
			button7.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button7.Image = (System.Drawing.Image)resources.GetObject("button7.Image");
			button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button7.Location = new System.Drawing.Point(1031, 119);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(105, 29);
			button7.TabIndex = 7;
			button7.Text = "Nhập Proxy";
			button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			button7.UseVisualStyleBackColor = false;
			button7.Click += new System.EventHandler(button7_Click);
			timer1.Enabled = true;
			timer1.Interval = 1800000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(1244, 610);
			base.Controls.Add(plTrangThai);
			base.Controls.Add(grTimKiem);
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
			base.Name = "fMain";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Max System Care Pro";
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
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			plTrangThai.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plChucNang.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
