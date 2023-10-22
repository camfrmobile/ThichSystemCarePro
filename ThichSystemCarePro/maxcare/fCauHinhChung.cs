using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;
using MetroFramework.Controls;
using Newtonsoft.Json.Linq;

namespace maxcare
{
	public class fCauHinhChung : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Label label3;

		private NumericUpDown nudInteractThread;

		private Label label4;

		private Label label5;

		private NumericUpDown nudHideThread;

		private Label label6;

		private Panel panel1;

		private GroupBox groupBox2;

		private GroupBox groupBox3;

		private ComboBox cbbHostpot;

		private Button button5;

		private Panel plNordVPN;

		private Label label14;

		private TextBox txtNordVPN;

		private Button btnSSH;

		private Label label26;

		private Label label27;

		private RadioButton rbSSH;

		private RadioButton rbExpressVPN;

		private NumericUpDown nudChangeIpCount;

		private RadioButton rbNordVPN;

		private RadioButton rbHotspot;

		private RadioButton rbDcom;

		private RadioButton rbHma;

		private BunifuDragControl bunifuDragControl1;

		private ToolTip toolTip1;

		private Button btnCancel;

		private Button btnSave;

		private BunifuCards bunifuCards2;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button button2;

		private Panel plTinsoft;

		private ComboBox cbbLocationTinsoft;

		private Label label7;

		private Label label1;

		private TextBox txtApiUser;

		private Label label8;

		private NumericUpDown nudLuongPerIPTinsoft;

		private RadioButton rbTinsoft;

		private Button button3;

		private Panel panel2;

		private Label label12;

		private TextBox textBox1;

		private RadioButton radioButton5;

		private RadioButton radioButton4;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private GroupBox grChrome;

		private Panel plXproxy;

		private Label label17;

		private Label label13;

		private TextBox txtServiceURLXProxy;

		private RadioButton rbXproxy;

		private RichTextBox txtListProxy;

		private Label label18;

		private NumericUpDown nudLuongPerIPXProxy;

		private Panel plCheckDoiIP;

		private RadioButton rbProxy;

		private NumericUpDown nudDelayOpenDeviceTo;

		private Label label21;

		private Panel plTMProxy;

		private RichTextBox txtApiKeyTMProxy;

		private Label label24;

		private Label label25;

		private NumericUpDown nudLuongPerIPTMProxy;

		private RadioButton rbTMProxy;

		private LinkLabel linkLabel1;

		private GroupBox groupBox1;

		private RadioButton rbPhanBietMauChu;

		private RadioButton rbPhanBietMauNen;

		private Label label23;

		private LinkLabel linkLabel3;

		private Panel plApiProxy;

		private Label lblCountApiProxy;

		private Label label28;

		private TextBox txtApiProxy;

		private Button button7;

		private Panel plApiUser;

		private RadioButton rbApiProxy;

		private RadioButton rbApiUser;

		private CheckBox ckbWaitDoneAllXproxy;

		private NumericUpDown nudDelayOpenDeviceFrom;

		private Label label29;

		private CheckBox ckbWaitDoneAllTinsoft;

		private CheckBox ckbWaitDoneAllTMProxy;

		private NumericUpDown nudDelayCloseDeviceFrom;

		private NumericUpDown nudDelayCloseDeviceTo;

		private Label label32;

		private Label label31;

		private Label label2;

		private Button button8;

		private Panel panel4;

		private CheckBox ckbKhongCheckIP;

		private RadioButton rbNone;

		private TextBox txtLDPathSwap;

		private Label label36;

		private Panel plDelayMoChrome;

		private RadioButton rbMoCachNhau;

		private RadioButton rbMoLanLuot;

		private Label label9;

		private CheckBox ckbKhongAddVaoFormView;

		private Panel plLDPlayerThuong;

		private Label label11;

		private TextBox txtLDPathThuong;

		private Panel plLDPlayerSwap;

		private RadioButton rbLDThuong;

		private RadioButton rbLDSwap;

		private Label label10;

		private Panel panel3;

		private LinkLabel linkLabel2;

		private Panel plDongBoMaxCare;

		private Label label15;

		private TextBox txtPathMaxCare;

		private CheckBox ckbDongBoMaxCare;

		private Panel plDcom;

		private Button button4;

		private TextBox txtUrlHilink;

		private TextBox txtProfileNameDcom;

		private RadioButton rbDcomHilink;

		private Label label19;

		private RadioButton rbDcomThuong;

		private Panel plShopLike;

		private RichTextBox txtApiShopLike;

		private Label label47;

		private Label label48;

		private NumericUpDown nudLuongPerIPShopLike;

		private RadioButton rbShopLike;

		private Panel plProxyv6;

		private RichTextBox txtListProxyv6;

		private Label label43;

		private Label label44;

		private NumericUpDown nudLuongPerIPProxyv6;

		private Label label45;

		private TextBox txtApiProxyv6;

		private RadioButton rbProxyv6;

		private CheckBox ckbLuuTrangThai;

		private MetroButton btnDown;

		private Label label20;

		private Label label16;

		private NumericUpDown nudDelayResetXProxy;

		public fCauHinhChung()
		{
			InitializeComponent();
			settings = new JSON_Settings("configGeneral");
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(groupBox2);
			Language.GetValue(label3);
			Language.GetValue(label6);
			Language.GetValue(label4);
			Language.GetValue(label5);
			Language.GetValue(grChrome);
			Language.GetValue(label29);
			Language.GetValue(label21);
			Language.GetValue(label2);
			Language.GetValue(label32);
			Language.GetValue(label31);
			Language.GetValue(groupBox1);
			Language.GetValue(label23);
			Language.GetValue(rbPhanBietMauNen);
			Language.GetValue(rbPhanBietMauChu);
			Language.GetValue(groupBox3);
			Language.GetValue(ckbKhongCheckIP);
			Language.GetValue(label26);
			Language.GetValue(label27);
			Language.GetValue(button5);
			Language.GetValue(rbNone);
			Language.GetValue(rbProxy);
			Language.GetValue(rbHma);
			Language.GetValue(rbDcom);
			Language.GetValue(button4);
			Language.GetValue(rbTinsoft);
			Language.GetValue(linkLabel3);
			Language.GetValue(rbApiUser);
			Language.GetValue(ckbWaitDoneAllTinsoft);
			Language.GetValue(rbApiProxy);
			Language.GetValue(label7);
			Language.GetValue(label8);
			Language.GetValue(label17);
			Language.GetValue(ckbWaitDoneAllXproxy);
			Language.GetValue(label18);
			Language.GetValue(linkLabel1);
			Language.GetValue(label24);
			Language.GetValue(ckbWaitDoneAllTMProxy);
			Language.GetValue(label25);
			Language.GetValue(btnSave);
			Language.GetValue(btnCancel);
			Language.GetValue(ckbDongBoMaxCare);
			Language.GetValue(label15);
			Language.GetValue(label10);
			Language.GetValue(rbLDThuong);
			Language.GetValue(label11);
			Language.GetValue(rbLDSwap);
			Language.GetValue(label36);
			Language.GetValue(label9);
			Language.GetValue(rbMoLanLuot);
			Language.GetValue(rbMoCachNhau);
			Language.GetValue(label2);
			Language.GetValue(ckbKhongAddVaoFormView);
			Language.GetValue(rbDcomThuong);
			Language.GetValue(label19);
		}

		private void LoadCbbLocation()
		{
			Dictionary<string, string> dataSource = TinsoftGetListLocation();
			cbbLocationTinsoft.DataSource = new BindingSource(dataSource, null);
			cbbLocationTinsoft.ValueMember = "Key";
			cbbLocationTinsoft.DisplayMember = "Value";
		}

		public Dictionary<string, string> TinsoftGetListLocation()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			List<string> listCountryTinsoft = SetupFolder.GetListCountryTinsoft();
			for (int i = 0; i < listCountryTinsoft.Count; i++)
			{
				string[] array = listCountryTinsoft[i].Split('|');
				dictionary.Add(array[0], array[1]);
			}
			return dictionary;
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FConfigGenneral_Load(object sender, EventArgs e)
		{
			LoadCbbLocation();
			nudInteractThread.Value = Convert.ToInt32((settings.GetValue("nudInteractThread") == "") ? "3" : settings.GetValue("nudInteractThread"));
			nudHideThread.Value = Convert.ToInt32((settings.GetValue("nudHideThread") == "") ? "5" : settings.GetValue("nudHideThread"));
			ckbKhongAddVaoFormView.Checked = settings.GetValueBool("ckbKhongAddVaoFormView");
			ckbDongBoMaxCare.Checked = settings.GetValueBool("ckbDongBoMaxCare");
			txtPathMaxCare.Text = settings.GetValue("txtPathMaxCare");
			if (settings.GetValueBool("isRunSwap"))
			{
				rbLDSwap.Checked = true;
			}
			else
			{
				rbLDThuong.Checked = true;
			}
			txtLDPathSwap.Text = settings.GetValue("txtLDPathSwap");
			txtLDPathThuong.Text = settings.GetValue("txtLDPathThuong");
			if (settings.GetValueInt("typeOpenDevice") == 0)
			{
				rbMoLanLuot.Checked = true;
			}
			else
			{
				rbMoCachNhau.Checked = true;
			}
			nudDelayOpenDeviceFrom.Value = settings.GetValueInt("nudDelayOpenDeviceFrom", 1);
			nudDelayOpenDeviceTo.Value = settings.GetValueInt("nudDelayOpenDeviceTo", 1);
			nudDelayCloseDeviceFrom.Value = settings.GetValueInt("nudDelayCloseDeviceFrom");
			nudDelayCloseDeviceTo.Value = settings.GetValueInt("nudDelayCloseDeviceTo");
			ckbKhongCheckIP.Checked = settings.GetValueBool("ckbKhongCheckIP");
			nudChangeIpCount.Value = Convert.ToInt32((settings.GetValue("ip_nudChangeIpCount") == "") ? "1" : settings.GetValue("ip_nudChangeIpCount"));
			switch (Convert.ToInt32((settings.GetValue("ip_iTypeChangeIp") == "") ? "0" : settings.GetValue("ip_iTypeChangeIp")))
			{
			case 0:
				rbNone.Checked = true;
				break;
			case 1:
				rbHma.Checked = true;
				break;
			case 2:
				rbDcom.Checked = true;
				break;
			case 3:
				rbSSH.Checked = true;
				break;
			case 4:
				rbExpressVPN.Checked = true;
				break;
			case 5:
				rbHotspot.Checked = true;
				break;
			case 6:
				rbNordVPN.Checked = true;
				break;
			case 7:
				rbTinsoft.Checked = true;
				break;
			case 8:
				rbXproxy.Checked = true;
				break;
			case 9:
				rbProxy.Checked = true;
				break;
			case 10:
				rbTMProxy.Checked = true;
				break;
			case 11:
				rbProxyv6.Checked = true;
				break;
			case 12:
				rbShopLike.Checked = true;
				break;
			}
			if (settings.GetValueInt("typeDcom") == 0)
			{
				rbDcomThuong.Checked = true;
			}
			else
			{
				rbDcomHilink.Checked = true;
			}
			txtProfileNameDcom.Text = settings.GetValue("ip_txtProfileNameDcom");
			txtUrlHilink.Text = settings.GetValue("txtUrlHilink", "http://192.168.1.1/html/home.html");
			txtNordVPN.Text = settings.GetValue("ip_txtNordVPN");
			cbbHostpot.SelectedIndex = Convert.ToInt32((settings.GetValue("ip_cbbHostpot") == "") ? "0" : settings.GetValue("ip_cbbHostpot"));
			if (settings.GetValueInt("typeApiTinsoft") == 0)
			{
				rbApiUser.Checked = true;
			}
			else
			{
				rbApiProxy.Checked = true;
			}
			txtApiUser.Text = settings.GetValue("txtApiUser");
			txtApiProxy.Text = settings.GetValue("txtApiProxy");
			cbbLocationTinsoft.SelectedValue = ((settings.GetValue("cbbLocationTinsoft") == "") ? "0" : settings.GetValue("cbbLocationTinsoft"));
			nudLuongPerIPTinsoft.Value = settings.GetValueInt("nudLuongPerIPTinsoft");
			ckbWaitDoneAllTinsoft.Checked = settings.GetValueBool("ckbWaitDoneAllTinsoft");
			txtServiceURLXProxy.Text = settings.GetValue("txtServiceURLXProxy");
			txtListProxy.Text = settings.GetValue("txtListProxy");
			nudLuongPerIPXProxy.Value = settings.GetValueInt("nudLuongPerIPXProxy");
			nudDelayResetXProxy.Value = settings.GetValueInt("nudDelayResetXProxy", 5);
			ckbWaitDoneAllXproxy.Checked = settings.GetValueBool("ckbWaitDoneAllXproxy");
			txtApiKeyTMProxy.Text = settings.GetValue("txtApiKeyTMProxy");
			nudLuongPerIPTMProxy.Value = settings.GetValueInt("nudLuongPerIPTMProxy", 1);
			ckbWaitDoneAllTMProxy.Checked = settings.GetValueBool("ckbWaitDoneAllTMProxy");
			txtApiProxyv6.Text = settings.GetValue("txtApiProxyv6");
			txtListProxyv6.Text = settings.GetValue("txtListProxyv6");
			nudLuongPerIPProxyv6.Value = settings.GetValueInt("nudLuongPerIPProxyv6", 1);
			txtApiShopLike.Text = settings.GetValue("txtApiShopLike");
			nudLuongPerIPShopLike.Value = settings.GetValueInt("nudLuongPerIPShopLike", 1);
			if (settings.GetValueInt("typePhanBietMau") == 0)
			{
				rbPhanBietMauNen.Checked = true;
			}
			else
			{
				rbPhanBietMauChu.Checked = true;
			}
			ckbLuuTrangThai.Checked = settings.GetValueBool("ckbLuuTrangThai");
			CheckedChangedFull();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (ckbKhongCheckIP.Checked && rbProxy.Checked)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Khi Sư\u0309 du\u0323ng Proxy thi\u0300 nên Check IP trươ\u0301c khi cha\u0323y!"), 3);
			}
			if (rbProxyv6.Checked)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Khi Sư\u0309 du\u0323ng Proxyv6.net thi\u0300 NHƠ\u0301 u\u0309y quyê\u0300n IP (AUTH IP) trươ\u0301c khi cha\u0323y nha!"), 3);
			}
			try
			{
				settings.Update("nudInteractThread", nudInteractThread.Value);
				settings.Update("nudHideThread", nudHideThread.Value);
				settings.Update("ckbKhongAddVaoFormView", ckbKhongAddVaoFormView.Checked);
				settings.Update("ckbDongBoMaxCare", ckbDongBoMaxCare.Checked);
				string text = txtPathMaxCare.Text.Trim();
				if (ckbDongBoMaxCare.Checked && !File.Exists(text + "\\database\\db_maxcare.sqlite"))
				{
					MessageBoxHelper.ShowMessageBox("Đươ\u0300ng dâ\u0303n MaxCare không hơ\u0323p lê\u0323!", 3);
					return;
				}
				settings.Update("txtPathMaxCare", text);
				bool flag = false;
				string text2 = "";
				if (rbLDSwap.Checked)
				{
					flag = true;
					text2 = txtLDPathSwap.Text.Trim();
				}
				else
				{
					text2 = txtLDPathThuong.Text.Trim();
				}
				if (text2.Contains(" "))
				{
					MessageBoxHelper.ShowMessageBox("Đường dẫn LDPlayer không đươ\u0323c chư\u0301a dâ\u0301u ca\u0301ch (space)!", 3);
					return;
				}
				if (!Directory.Exists(text2))
				{
					MessageBoxHelper.ShowMessageBox("Đường dẫn LDPlayer không tồn tại!", 3);
					return;
				}
				settings.Update("isRunSwap", flag);
				settings.Update("txtLDPathSwap", txtLDPathSwap.Text.Trim());
				settings.Update("txtLDPathThuong", txtLDPathThuong.Text.Trim());
				if (rbMoCachNhau.Checked)
				{
					settings.Update("typeOpenDevice", 1);
				}
				else
				{
					settings.Update("typeOpenDevice", 0);
				}
				settings.Update("nudDelayOpenDeviceFrom", nudDelayOpenDeviceFrom.Value);
				settings.Update("nudDelayOpenDeviceTo", nudDelayOpenDeviceTo.Value);
				settings.Update("nudDelayCloseDeviceFrom", nudDelayCloseDeviceFrom.Value);
				settings.Update("nudDelayCloseDeviceTo", nudDelayCloseDeviceTo.Value);
				settings.Update("ckbKhongCheckIP", ckbKhongCheckIP.Checked);
				settings.Update("ip_nudChangeIpCount", nudChangeIpCount.Value);
				int num = 0;
				if (rbNone.Checked)
				{
					num = 0;
				}
				else if (rbHma.Checked)
				{
					num = 1;
				}
				else if (rbDcom.Checked)
				{
					num = 2;
				}
				else if (rbSSH.Checked)
				{
					num = 3;
				}
				else if (rbExpressVPN.Checked)
				{
					num = 4;
				}
				else if (rbHotspot.Checked)
				{
					num = 5;
				}
				else if (rbNordVPN.Checked)
				{
					num = 6;
				}
				else if (rbTinsoft.Checked)
				{
					num = 7;
				}
				else if (rbXproxy.Checked)
				{
					num = 8;
				}
				else if (rbProxy.Checked)
				{
					num = 9;
				}
				else if (rbTMProxy.Checked)
				{
					num = 10;
				}
				else if (rbProxyv6.Checked)
				{
					num = 11;
				}
				else if (rbShopLike.Checked)
				{
					num = 12;
				}
				settings.Update("ip_iTypeChangeIp", num);
				if (rbDcomThuong.Checked)
				{
					settings.Update("typeDcom", 0);
				}
				else
				{
					settings.Update("typeDcom", 1);
				}
				settings.Update("txtUrlHilink", txtUrlHilink.Text);
				settings.Update("ip_txtProfileNameDcom", txtProfileNameDcom.Text);
				settings.Update("ip_txtNordVPN", txtNordVPN.Text);
				settings.Update("ip_cbbHostpot", cbbHostpot.SelectedIndex);
				if (rbApiUser.Checked)
				{
					settings.Update("typeApiTinsoft", 0);
				}
				else
				{
					settings.Update("typeApiTinsoft", 1);
				}
				settings.Update("txtApiUser", txtApiUser.Text);
				settings.Update("txtApiProxy", txtApiProxy.Text);
				settings.Update("cbbLocationTinsoft", cbbLocationTinsoft.SelectedValue);
				settings.Update("nudLuongPerIPTinsoft", nudLuongPerIPTinsoft.Value);
				settings.Update("ckbWaitDoneAllTinsoft", ckbWaitDoneAllTinsoft.Checked);
				settings.Update("txtServiceURLXProxy", txtServiceURLXProxy.Text);
				settings.Update("txtListProxy", txtListProxy.Text);
				settings.Update("nudLuongPerIPXProxy", nudLuongPerIPXProxy.Value);
				settings.Update("nudDelayResetXProxy", nudDelayResetXProxy.Value);
				settings.Update("ckbWaitDoneAllXproxy", ckbWaitDoneAllXproxy.Checked);
				settings.Update("txtApiKeyTMProxy", txtApiKeyTMProxy.Text);
				settings.Update("nudLuongPerIPTMProxy", nudLuongPerIPTMProxy.Value);
				settings.Update("ckbWaitDoneAllTMProxy", ckbWaitDoneAllTMProxy.Checked);
				settings.Update("txtApiProxyv6", txtApiProxyv6.Text);
				settings.Update("txtListProxyv6", txtListProxyv6.Text);
				settings.Update("nudLuongPerIPProxyv6", nudLuongPerIPProxyv6.Value);
				settings.Update("txtApiShopLike", txtApiShopLike.Text);
				settings.Update("nudLuongPerIPShopLike", nudLuongPerIPShopLike.Value);
				if (rbPhanBietMauNen.Checked)
				{
					settings.Update("typePhanBietMau", 0);
				}
				else
				{
					settings.Update("typePhanBietMau", 1);
				}
				settings.Update("ckbLuuTrangThai", ckbLuuTrangThai.Checked);
				UpdateStatus.isSaveSettings = ckbLuuTrangThai.Checked;
				settings.Save();
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
				{
					Close();
				}
				string path = text2 + "\\vms\\config\\leidians.config";
				if (File.Exists(path))
				{
					string json = File.ReadAllText(path);
					JObject jObject = JObject.Parse(json);
					jObject["languageId"] = (JToken)"en_US";
					File.WriteAllText(path, jObject.ToString());
				}
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Lỗi!"));
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (settings.GetValueInt("ip_iTypeChangeIp") == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng chọn loại đổi IP"), 3);
			}
			else if (MCommon.Common.ChangeIP(settings.GetValueInt("ip_iTypeChangeIp"), settings.GetValueInt("typeDcom"), settings.GetValue("ip_txtProfileNameDcom"), settings.GetValue("txtUrlHilink"), settings.GetValueInt("ip_cbbHostpot"), settings.GetValue("ip_txtNordVPN")))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đổi IP thành công!"));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đổi IP thất bại!"), 2);
			}
		}

		private void btnSSH_Click(object sender, EventArgs e)
		{
			Process.Start("changeip\\ssh.txt");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!CommonChrome.CheckInvalidChrome())
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cập nhật chromedriver!"), 3);
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Phiên bản chromedriver khả dụng!"));
			}
		}

		private void rbTinsoft_CheckedChanged(object sender, EventArgs e)
		{
			plTinsoft.Enabled = rbTinsoft.Checked;
		}

		private void rbNordVPN_CheckedChanged(object sender, EventArgs e)
		{
			panel2.Enabled = rbNordVPN.Checked;
		}

		private void CheckedChangedFull()
		{
			radioButton1_CheckedChanged(null, null);
			radioButton1_CheckedChanged_1(null, null);
			rbLDThuong_CheckedChanged(null, null);
			rbTinsoft_CheckedChanged(null, null);
			rbNordVPN_CheckedChanged(null, null);
			rbDcom_CheckedChanged(null, null);
			rbXproxy_CheckedChanged(null, null);
			rbHma_CheckedChanged(null, null);
			rbTMProxy_CheckedChanged(null, null);
			rbApiUser_CheckedChanged(null, null);
			rbApiProxy_CheckedChanged(null, null);
			ckbDongBoMaxCare_CheckedChanged(null, null);
			rbProxyv6_CheckedChanged(null, null);
			rbShopLike_CheckedChanged(null, null);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string api_user = txtApiUser.Text.Trim();
			List<string> listKey = TinsoftProxy.GetListKey(api_user);
			if (listKey.Count > 0)
			{
				MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đang có {0} proxy khả dụng!"), listKey.Count));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không có proxy khả dụng!"), 2);
			}
		}

		private void rbDcom_CheckedChanged(object sender, EventArgs e)
		{
			plDcom.Enabled = rbDcom.Checked;
			CheckDoiIPEnable();
		}

		private void rbXproxy_CheckedChanged(object sender, EventArgs e)
		{
			plXproxy.Enabled = rbXproxy.Checked;
		}

		private void CheckDoiIPEnable()
		{
			plCheckDoiIP.Enabled = rbDcom.Checked || rbHma.Checked;
		}

		private void rbHma_CheckedChanged(object sender, EventArgs e)
		{
			CheckDoiIPEnable();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				};
				Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				if (text.Split('\n').Length <= 3)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng kết nối Dcom trước!"), 2);
					return;
				}
				txtProfileNameDcom.Text = text.Split('\n').ToList()[1];
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Lấy tên cấu hình Dcom thành công!"));
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex, "change ip dcom");
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void rbTMProxy_CheckedChanged(object sender, EventArgs e)
		{
			plTMProxy.Enabled = rbTMProxy.Checked;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("https://youtu.be/eexEDCyPbR8");
			}
			catch
			{
			}
		}

		private void txtApiProxy_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtApiProxy.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblCountApiProxy.Text = "(" + lst.Count + ")";
			}
			catch
			{
			}
		}

		private void rbApiUser_CheckedChanged(object sender, EventArgs e)
		{
			plApiUser.Enabled = rbApiUser.Checked;
		}

		private void rbApiProxy_CheckedChanged(object sender, EventArgs e)
		{
			plApiProxy.Enabled = rbApiProxy.Checked;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			List<string> lst = txtApiProxy.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			foreach (string item in lst)
			{
				if (TinsoftProxy.CheckApiProxy(item))
				{
					list.Add(item);
				}
			}
			txtApiProxy.Lines = list.ToArray();
			if (list.Count > 0)
			{
				MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đang có {0} proxy khả dụng!"), list.Count));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không có proxy khả dụng!"), 2);
			}
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("https://www.youtube.com/watch?v=XZTveKk-utY");
			}
			catch
			{
			}
		}

		private void plXproxy_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				ckbWaitDoneAllXproxy.Visible = true;
			}
		}

		private void plTinsoft_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				ckbWaitDoneAllTinsoft.Visible = true;
			}
		}

		private void plTMProxy_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				ckbWaitDoneAllTMProxy.Visible = true;
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			List<string> lst = txtApiKeyTMProxy.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			foreach (string item in lst)
			{
				if (TMProxy.CheckApiProxy(item))
				{
					list.Add(item);
				}
			}
			txtApiKeyTMProxy.Lines = list.ToArray();
			if (list.Count > 0)
			{
				MessageBoxHelper.ShowMessageBox(string.Format(Language.GetValue("Đang có {0} proxy khả dụng!"), list.Count));
			}
			else
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Không có proxy khả dụng!"), 2);
			}
		}

		private void txtApiKeyTMProxy_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtApiKeyTMProxy.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label24.Text = string.Format(Language.GetValue("Nhập API KEY ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void txtListProxy_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtListProxy.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				label17.Text = string.Format(Language.GetValue("Nhập Proxy ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			plDelayMoChrome.Enabled = rbMoCachNhau.Checked;
		}

		private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
		{
			plLDPlayerSwap.Enabled = rbLDSwap.Checked;
		}

		private void rbLDThuong_CheckedChanged(object sender, EventArgs e)
		{
			plLDPlayerThuong.Enabled = rbLDThuong.Checked;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://download.minsoftware.vn/dnplayer4/dnplayer.rar");
		}

		private void ckbDongBoMaxCare_CheckedChanged(object sender, EventArgs e)
		{
			plDongBoMaxCare.Enabled = ckbDongBoMaxCare.Checked;
		}

		private void rbDcomThuong_CheckedChanged(object sender, EventArgs e)
		{
			button4.Enabled = rbDcomThuong.Checked;
			txtProfileNameDcom.Enabled = rbDcomThuong.Checked;
		}

		private void rbDcomHilink_CheckedChanged(object sender, EventArgs e)
		{
			txtUrlHilink.Enabled = rbDcomHilink.Checked;
		}

		private void txtApiShopLike_TextChanged(object sender, EventArgs e)
		{
			List<string> lst = txtApiShopLike.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			label47.Text = string.Format(Language.GetValue("Nhập API KEY ({0}):"), lst.Count.ToString());
		}

		private void txtListProxyv6_TextChanged(object sender, EventArgs e)
		{
			List<string> lst = txtListProxyv6.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			label43.Text = string.Format(Language.GetValue("Nhập Proxy ({0}):"), lst.Count.ToString());
		}

		private void rbShopLike_CheckedChanged(object sender, EventArgs e)
		{
			plShopLike.Enabled = rbShopLike.Checked;
		}

		private void rbProxyv6_CheckedChanged(object sender, EventArgs e)
		{
			plProxyv6.Enabled = rbProxyv6.Checked;
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (plXproxy.Height == 199)
			{
				plXproxy.Height = 170;
				(sender as Button).BackgroundImage = Resources.icons8_expand_arrow_24px;
			}
			else
			{
				plXproxy.Height = 199;
				(sender as Button).BackgroundImage = Resources.icons8_collapse_arrow_24px;
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCauHinhChung));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			label3 = new System.Windows.Forms.Label();
			nudInteractThread = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			nudHideThread = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			grChrome = new System.Windows.Forms.GroupBox();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			panel3 = new System.Windows.Forms.Panel();
			rbMoLanLuot = new System.Windows.Forms.RadioButton();
			rbMoCachNhau = new System.Windows.Forms.RadioButton();
			plDelayMoChrome = new System.Windows.Forms.Panel();
			nudDelayOpenDeviceFrom = new System.Windows.Forms.NumericUpDown();
			label21 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			nudDelayOpenDeviceTo = new System.Windows.Forms.NumericUpDown();
			plLDPlayerThuong = new System.Windows.Forms.Panel();
			label11 = new System.Windows.Forms.Label();
			txtLDPathThuong = new System.Windows.Forms.TextBox();
			plLDPlayerSwap = new System.Windows.Forms.Panel();
			label36 = new System.Windows.Forms.Label();
			txtLDPathSwap = new System.Windows.Forms.TextBox();
			rbLDThuong = new System.Windows.Forms.RadioButton();
			rbLDSwap = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			nudDelayCloseDeviceFrom = new System.Windows.Forms.NumericUpDown();
			nudDelayCloseDeviceTo = new System.Windows.Forms.NumericUpDown();
			label32 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			ckbKhongAddVaoFormView = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			cbbHostpot = new System.Windows.Forms.ComboBox();
			bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			panel2 = new System.Windows.Forms.Panel();
			label12 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			btnSave = new System.Windows.Forms.Button();
			plNordVPN = new System.Windows.Forms.Panel();
			label14 = new System.Windows.Forms.Label();
			txtNordVPN = new System.Windows.Forms.TextBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			panel4 = new System.Windows.Forms.Panel();
			rbPhanBietMauNen = new System.Windows.Forms.RadioButton();
			rbPhanBietMauChu = new System.Windows.Forms.RadioButton();
			label23 = new System.Windows.Forms.Label();
			ckbLuuTrangThai = new System.Windows.Forms.CheckBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			plDongBoMaxCare = new System.Windows.Forms.Panel();
			label15 = new System.Windows.Forms.Label();
			txtPathMaxCare = new System.Windows.Forms.TextBox();
			ckbDongBoMaxCare = new System.Windows.Forms.CheckBox();
			btnSSH = new System.Windows.Forms.Button();
			radioButton4 = new System.Windows.Forms.RadioButton();
			rbHotspot = new System.Windows.Forms.RadioButton();
			radioButton5 = new System.Windows.Forms.RadioButton();
			rbNordVPN = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			rbSSH = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			rbExpressVPN = new System.Windows.Forms.RadioButton();
			groupBox3 = new System.Windows.Forms.GroupBox();
			plXproxy = new System.Windows.Forms.Panel();
			ckbWaitDoneAllXproxy = new System.Windows.Forms.CheckBox();
			txtListProxy = new System.Windows.Forms.RichTextBox();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			nudLuongPerIPXProxy = new System.Windows.Forms.NumericUpDown();
			label13 = new System.Windows.Forms.Label();
			txtServiceURLXProxy = new System.Windows.Forms.TextBox();
			plShopLike = new System.Windows.Forms.Panel();
			txtApiShopLike = new System.Windows.Forms.RichTextBox();
			label47 = new System.Windows.Forms.Label();
			label48 = new System.Windows.Forms.Label();
			nudLuongPerIPShopLike = new System.Windows.Forms.NumericUpDown();
			rbShopLike = new System.Windows.Forms.RadioButton();
			plProxyv6 = new System.Windows.Forms.Panel();
			txtListProxyv6 = new System.Windows.Forms.RichTextBox();
			label43 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			nudLuongPerIPProxyv6 = new System.Windows.Forms.NumericUpDown();
			label45 = new System.Windows.Forms.Label();
			txtApiProxyv6 = new System.Windows.Forms.TextBox();
			rbProxyv6 = new System.Windows.Forms.RadioButton();
			plDcom = new System.Windows.Forms.Panel();
			button4 = new System.Windows.Forms.Button();
			txtUrlHilink = new System.Windows.Forms.TextBox();
			txtProfileNameDcom = new System.Windows.Forms.TextBox();
			rbDcomHilink = new System.Windows.Forms.RadioButton();
			label19 = new System.Windows.Forms.Label();
			rbDcomThuong = new System.Windows.Forms.RadioButton();
			linkLabel3 = new System.Windows.Forms.LinkLabel();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			plTMProxy = new System.Windows.Forms.Panel();
			ckbWaitDoneAllTMProxy = new System.Windows.Forms.CheckBox();
			txtApiKeyTMProxy = new System.Windows.Forms.RichTextBox();
			label24 = new System.Windows.Forms.Label();
			button8 = new System.Windows.Forms.Button();
			label25 = new System.Windows.Forms.Label();
			nudLuongPerIPTMProxy = new System.Windows.Forms.NumericUpDown();
			plCheckDoiIP = new System.Windows.Forms.Panel();
			button5 = new System.Windows.Forms.Button();
			label26 = new System.Windows.Forms.Label();
			nudChangeIpCount = new System.Windows.Forms.NumericUpDown();
			label27 = new System.Windows.Forms.Label();
			plTinsoft = new System.Windows.Forms.Panel();
			ckbWaitDoneAllTinsoft = new System.Windows.Forms.CheckBox();
			plApiProxy = new System.Windows.Forms.Panel();
			lblCountApiProxy = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			txtApiProxy = new System.Windows.Forms.TextBox();
			button7 = new System.Windows.Forms.Button();
			plApiUser = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			txtApiUser = new System.Windows.Forms.TextBox();
			button3 = new System.Windows.Forms.Button();
			cbbLocationTinsoft = new System.Windows.Forms.ComboBox();
			rbApiProxy = new System.Windows.Forms.RadioButton();
			rbApiUser = new System.Windows.Forms.RadioButton();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			nudLuongPerIPTinsoft = new System.Windows.Forms.NumericUpDown();
			rbTMProxy = new System.Windows.Forms.RadioButton();
			rbDcom = new System.Windows.Forms.RadioButton();
			rbTinsoft = new System.Windows.Forms.RadioButton();
			rbProxy = new System.Windows.Forms.RadioButton();
			rbNone = new System.Windows.Forms.RadioButton();
			rbXproxy = new System.Windows.Forms.RadioButton();
			rbHma = new System.Windows.Forms.RadioButton();
			ckbKhongCheckIP = new System.Windows.Forms.CheckBox();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			btnDown = new MetroFramework.Controls.MetroButton();
			nudDelayResetXProxy = new System.Windows.Forms.NumericUpDown();
			label16 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)nudInteractThread).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudHideThread).BeginInit();
			panel1.SuspendLayout();
			grChrome.SuspendLayout();
			panel3.SuspendLayout();
			plDelayMoChrome.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceTo).BeginInit();
			plLDPlayerThuong.SuspendLayout();
			plLDPlayerSwap.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceTo).BeginInit();
			bunifuCards2.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel2.SuspendLayout();
			plNordVPN.SuspendLayout();
			groupBox1.SuspendLayout();
			panel4.SuspendLayout();
			groupBox2.SuspendLayout();
			plDongBoMaxCare.SuspendLayout();
			groupBox3.SuspendLayout();
			plXproxy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).BeginInit();
			plShopLike.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPShopLike).BeginInit();
			plProxyv6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPProxyv6).BeginInit();
			plDcom.SuspendLayout();
			plTMProxy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTMProxy).BeginInit();
			plCheckDoiIP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudChangeIpCount).BeginInit();
			plTinsoft.SuspendLayout();
			plApiProxy.SuspendLayout();
			plApiUser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTinsoft).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayResetXProxy).BeginInit();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 5;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(575, 38);
			bunifuCards1.TabIndex = 12;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(32, 27);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(146, 16);
			label3.TabIndex = 23;
			label3.Text = "Số luồng chạy LDPlayer:";
			nudInteractThread.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudInteractThread.Location = new System.Drawing.Point(184, 25);
			nudInteractThread.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
			nudInteractThread.Name = "nudInteractThread";
			nudInteractThread.Size = new System.Drawing.Size(89, 23);
			nudInteractThread.TabIndex = 24;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(276, 27);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 16);
			label4.TabIndex = 25;
			label4.Text = "Luồng";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(276, 55);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(42, 16);
			label5.TabIndex = 28;
			label5.Text = "Luồng";
			nudHideThread.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudHideThread.Location = new System.Drawing.Point(184, 53);
			nudHideThread.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
			nudHideThread.Name = "nudHideThread";
			nudHideThread.Size = new System.Drawing.Size(89, 23);
			nudHideThread.TabIndex = 27;
			label6.AutoSize = true;
			label6.Cursor = System.Windows.Forms.Cursors.Help;
			label6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(32, 55);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(131, 16);
			label6.TabIndex = 26;
			label6.Text = "Số luồng chạy ẩn (?):";
			toolTip1.SetToolTip(label6, "La\u0300 sô\u0301 luô\u0300ng khi cha\u0323y ca\u0301c chư\u0301c năng không liên quan gi\u0300 đê\u0301n tri\u0300nh duyê\u0323t.\r\nVi\u0301 du\u0323 như: Check wall, Check Avatar,...\r\n(Khuyê\u0301n ca\u0301o nên đê\u0309 10 luô\u0300ng)");
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(grChrome);
			panel1.Controls.Add(cbbHostpot);
			panel1.Controls.Add(bunifuCards2);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(plNordVPN);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(btnSSH);
			panel1.Controls.Add(radioButton4);
			panel1.Controls.Add(rbHotspot);
			panel1.Controls.Add(radioButton5);
			panel1.Controls.Add(rbNordVPN);
			panel1.Controls.Add(radioButton2);
			panel1.Controls.Add(rbSSH);
			panel1.Controls.Add(radioButton3);
			panel1.Controls.Add(rbExpressVPN);
			panel1.Controls.Add(groupBox3);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1158, 692);
			panel1.TabIndex = 37;
			grChrome.Controls.Add(linkLabel2);
			grChrome.Controls.Add(panel3);
			grChrome.Controls.Add(plLDPlayerThuong);
			grChrome.Controls.Add(plLDPlayerSwap);
			grChrome.Controls.Add(rbLDThuong);
			grChrome.Controls.Add(rbLDSwap);
			grChrome.Controls.Add(label9);
			grChrome.Controls.Add(label10);
			grChrome.Controls.Add(nudDelayCloseDeviceFrom);
			grChrome.Controls.Add(nudDelayCloseDeviceTo);
			grChrome.Controls.Add(label32);
			grChrome.Controls.Add(label31);
			grChrome.Controls.Add(ckbKhongAddVaoFormView);
			grChrome.Controls.Add(label2);
			grChrome.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			grChrome.Location = new System.Drawing.Point(7, 174);
			grChrome.Name = "grChrome";
			grChrome.Size = new System.Drawing.Size(568, 225);
			grChrome.TabIndex = 38;
			grChrome.TabStop = false;
			grChrome.Text = "Cấu hình LDPlayer";
			linkLabel2.AutoSize = true;
			linkLabel2.Location = new System.Drawing.Point(32, 46);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(117, 16);
			linkLabel2.TabIndex = 165;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "Download LDPlayer";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			panel3.Controls.Add(rbMoLanLuot);
			panel3.Controls.Add(rbMoCachNhau);
			panel3.Controls.Add(plDelayMoChrome);
			panel3.Location = new System.Drawing.Point(181, 120);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(384, 52);
			panel3.TabIndex = 164;
			rbMoLanLuot.AutoSize = true;
			rbMoLanLuot.Checked = true;
			rbMoLanLuot.Cursor = System.Windows.Forms.Cursors.Hand;
			rbMoLanLuot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbMoLanLuot.Location = new System.Drawing.Point(3, 3);
			rbMoLanLuot.Name = "rbMoLanLuot";
			rbMoLanLuot.Size = new System.Drawing.Size(72, 20);
			rbMoLanLuot.TabIndex = 161;
			rbMoLanLuot.TabStop = true;
			rbMoLanLuot.Text = "Lần lượt";
			rbMoLanLuot.UseVisualStyleBackColor = true;
			rbMoCachNhau.AutoSize = true;
			rbMoCachNhau.Cursor = System.Windows.Forms.Cursors.Hand;
			rbMoCachNhau.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbMoCachNhau.Location = new System.Drawing.Point(3, 26);
			rbMoCachNhau.Name = "rbMoCachNhau";
			rbMoCachNhau.Size = new System.Drawing.Size(137, 20);
			rbMoCachNhau.TabIndex = 161;
			rbMoCachNhau.Text = "Delay mơ\u0309 LDPlayer:";
			rbMoCachNhau.UseVisualStyleBackColor = true;
			rbMoCachNhau.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			plDelayMoChrome.Controls.Add(nudDelayOpenDeviceFrom);
			plDelayMoChrome.Controls.Add(label21);
			plDelayMoChrome.Controls.Add(label29);
			plDelayMoChrome.Controls.Add(nudDelayOpenDeviceTo);
			plDelayMoChrome.Location = new System.Drawing.Point(153, 24);
			plDelayMoChrome.Name = "plDelayMoChrome";
			plDelayMoChrome.Size = new System.Drawing.Size(153, 26);
			plDelayMoChrome.TabIndex = 162;
			nudDelayOpenDeviceFrom.Location = new System.Drawing.Point(2, 1);
			nudDelayOpenDeviceFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayOpenDeviceFrom.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudDelayOpenDeviceFrom.Name = "nudDelayOpenDeviceFrom";
			nudDelayOpenDeviceFrom.Size = new System.Drawing.Size(41, 23);
			nudDelayOpenDeviceFrom.TabIndex = 151;
			nudDelayOpenDeviceFrom.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label21.Location = new System.Drawing.Point(117, 3);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(31, 16);
			label21.TabIndex = 33;
			label21.Text = "giây";
			label29.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label29.Location = new System.Drawing.Point(45, 3);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(29, 16);
			label29.TabIndex = 33;
			label29.Text = "đê\u0301n";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudDelayOpenDeviceTo.Location = new System.Drawing.Point(74, 1);
			nudDelayOpenDeviceTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayOpenDeviceTo.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudDelayOpenDeviceTo.Name = "nudDelayOpenDeviceTo";
			nudDelayOpenDeviceTo.Size = new System.Drawing.Size(41, 23);
			nudDelayOpenDeviceTo.TabIndex = 151;
			nudDelayOpenDeviceTo.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			plLDPlayerThuong.Controls.Add(label11);
			plLDPlayerThuong.Controls.Add(txtLDPathThuong);
			plLDPlayerThuong.Location = new System.Drawing.Point(197, 40);
			plLDPlayerThuong.Name = "plLDPlayerThuong";
			plLDPlayerThuong.Size = new System.Drawing.Size(368, 29);
			plLDPlayerThuong.TabIndex = 163;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(3, 6);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(129, 16);
			label11.TabIndex = 158;
			label11.Text = "Đường dẫn LDPlayer:";
			txtLDPathThuong.Location = new System.Drawing.Point(138, 3);
			txtLDPathThuong.Name = "txtLDPathThuong";
			txtLDPathThuong.Size = new System.Drawing.Size(227, 23);
			txtLDPathThuong.TabIndex = 159;
			plLDPlayerSwap.Controls.Add(label36);
			plLDPlayerSwap.Controls.Add(txtLDPathSwap);
			plLDPlayerSwap.Location = new System.Drawing.Point(197, 89);
			plLDPlayerSwap.Name = "plLDPlayerSwap";
			plLDPlayerSwap.Size = new System.Drawing.Size(368, 29);
			plLDPlayerSwap.TabIndex = 163;
			label36.AutoSize = true;
			label36.Location = new System.Drawing.Point(3, 6);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(129, 16);
			label36.TabIndex = 158;
			label36.Text = "Đường dẫn LDPlayer:";
			txtLDPathSwap.Location = new System.Drawing.Point(138, 3);
			txtLDPathSwap.Name = "txtLDPathSwap";
			txtLDPathSwap.Size = new System.Drawing.Size(227, 23);
			txtLDPathSwap.TabIndex = 159;
			rbLDThuong.AutoSize = true;
			rbLDThuong.Checked = true;
			rbLDThuong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLDThuong.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbLDThuong.Location = new System.Drawing.Point(183, 22);
			rbLDThuong.Name = "rbLDThuong";
			rbLDThuong.Size = new System.Drawing.Size(252, 20);
			rbLDThuong.TabIndex = 161;
			rbLDThuong.TabStop = true;
			rbLDThuong.Text = "Chế độ thường (1 tài khoản/1 LDPlayer)";
			rbLDThuong.UseVisualStyleBackColor = true;
			rbLDThuong.CheckedChanged += new System.EventHandler(rbLDThuong_CheckedChanged);
			rbLDSwap.AutoSize = true;
			rbLDSwap.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLDSwap.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbLDSwap.Location = new System.Drawing.Point(183, 71);
			rbLDSwap.Name = "rbLDSwap";
			rbLDSwap.Size = new System.Drawing.Size(321, 20);
			rbLDSwap.TabIndex = 161;
			rbLDSwap.Text = "Chế độ Swap (Không giới hạn tài khoản/1 LDPlayer)";
			rbLDSwap.UseVisualStyleBackColor = true;
			rbLDSwap.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged_1);
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(32, 123);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(140, 16);
			label9.TabIndex = 160;
			label9.Text = "Tu\u0300y cho\u0323n mơ\u0309 LDPlayer:";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(32, 24);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(137, 16);
			label10.TabIndex = 158;
			label10.Text = "Tùy chọn chế độ chạy:";
			nudDelayCloseDeviceFrom.Location = new System.Drawing.Point(184, 172);
			nudDelayCloseDeviceFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayCloseDeviceFrom.Name = "nudDelayCloseDeviceFrom";
			nudDelayCloseDeviceFrom.Size = new System.Drawing.Size(41, 23);
			nudDelayCloseDeviceFrom.TabIndex = 151;
			nudDelayCloseDeviceTo.Location = new System.Drawing.Point(256, 172);
			nudDelayCloseDeviceTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayCloseDeviceTo.Name = "nudDelayCloseDeviceTo";
			nudDelayCloseDeviceTo.Size = new System.Drawing.Size(41, 23);
			nudDelayCloseDeviceTo.TabIndex = 151;
			label32.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label32.Location = new System.Drawing.Point(227, 174);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(29, 16);
			label32.TabIndex = 33;
			label32.Text = "đê\u0301n";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label31.AutoSize = true;
			label31.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label31.Location = new System.Drawing.Point(299, 174);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(31, 16);
			label31.TabIndex = 33;
			label31.Text = "giây";
			ckbKhongAddVaoFormView.AutoSize = true;
			ckbKhongAddVaoFormView.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongAddVaoFormView.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbKhongAddVaoFormView.Location = new System.Drawing.Point(35, 199);
			ckbKhongAddVaoFormView.Name = "ckbKhongAddVaoFormView";
			ckbKhongAddVaoFormView.Size = new System.Drawing.Size(196, 20);
			ckbKhongAddVaoFormView.TabIndex = 112;
			ckbKhongAddVaoFormView.Text = "Không Add LD vào Form View";
			ckbKhongAddVaoFormView.UseVisualStyleBackColor = true;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(32, 174);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(129, 16);
			label2.TabIndex = 33;
			label2.Text = "Delay đóng LDPlayer:";
			cbbHostpot.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbHostpot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbHostpot.Enabled = false;
			cbbHostpot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			cbbHostpot.ForeColor = System.Drawing.Color.Black;
			cbbHostpot.FormattingEnabled = true;
			cbbHostpot.Items.AddRange(new object[2] { "Chi\u0309 trong quô\u0301c gia đang cho\u0323n", "Toa\u0300n bô\u0323 quô\u0301c gia" });
			cbbHostpot.Location = new System.Drawing.Point(1177, 563);
			cbbHostpot.Name = "cbbHostpot";
			cbbHostpot.Size = new System.Drawing.Size(229, 24);
			cbbHostpot.TabIndex = 144;
			bunifuCards2.BackColor = System.Drawing.Color.White;
			bunifuCards2.BorderRadius = 0;
			bunifuCards2.BottomSahddow = true;
			bunifuCards2.color = System.Drawing.Color.SaddleBrown;
			bunifuCards2.Controls.Add(pnlHeader);
			bunifuCards2.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards2.LeftSahddow = false;
			bunifuCards2.Location = new System.Drawing.Point(0, 0);
			bunifuCards2.Name = "bunifuCards2";
			bunifuCards2.RightSahddow = true;
			bunifuCards2.ShadowDepth = 20;
			bunifuCards2.Size = new System.Drawing.Size(1156, 37);
			bunifuCards2.TabIndex = 40;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1156, 31);
			pnlHeader.TabIndex = 9;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
			button2.Location = new System.Drawing.Point(1125, 1);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(30, 30);
			button2.TabIndex = 77;
			button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(BtnCancel_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(1156, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh chung";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(583, 650);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 20;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label12);
			panel2.Controls.Add(textBox1);
			panel2.Enabled = false;
			panel2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			panel2.Location = new System.Drawing.Point(1176, 475);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(232, 30);
			panel2.TabIndex = 142;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label12.Location = new System.Drawing.Point(3, 5);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(76, 16);
			label12.TabIndex = 82;
			label12.Text = "Đường dẫn:";
			textBox1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			textBox1.ForeColor = System.Drawing.Color.Black;
			textBox1.Location = new System.Drawing.Point(87, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(142, 23);
			textBox1.TabIndex = 83;
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(483, 650);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(92, 29);
			btnSave.TabIndex = 19;
			btnSave.Text = "Lưu";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(BtnSave_Click);
			plNordVPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plNordVPN.Controls.Add(label14);
			plNordVPN.Controls.Add(txtNordVPN);
			plNordVPN.Enabled = false;
			plNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plNordVPN.Location = new System.Drawing.Point(1176, 475);
			plNordVPN.Name = "plNordVPN";
			plNordVPN.Size = new System.Drawing.Size(232, 30);
			plNordVPN.TabIndex = 142;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label14.Location = new System.Drawing.Point(3, 5);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(76, 16);
			label14.TabIndex = 82;
			label14.Text = "Đường dẫn:";
			txtNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtNordVPN.ForeColor = System.Drawing.Color.Black;
			txtNordVPN.Location = new System.Drawing.Point(87, 2);
			txtNordVPN.Name = "txtNordVPN";
			txtNordVPN.Size = new System.Drawing.Size(142, 23);
			txtNordVPN.TabIndex = 83;
			groupBox1.Controls.Add(panel4);
			groupBox1.Controls.Add(label23);
			groupBox1.Controls.Add(ckbLuuTrangThai);
			groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox1.Location = new System.Drawing.Point(7, 405);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(568, 68);
			groupBox1.TabIndex = 38;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cấu hình khác";
			panel4.Controls.Add(rbPhanBietMauNen);
			panel4.Controls.Add(rbPhanBietMauChu);
			panel4.Location = new System.Drawing.Point(253, 17);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(309, 25);
			panel4.TabIndex = 156;
			rbPhanBietMauNen.AutoSize = true;
			rbPhanBietMauNen.Checked = true;
			rbPhanBietMauNen.Cursor = System.Windows.Forms.Cursors.Hand;
			rbPhanBietMauNen.Location = new System.Drawing.Point(3, 3);
			rbPhanBietMauNen.Name = "rbPhanBietMauNen";
			rbPhanBietMauNen.Size = new System.Drawing.Size(131, 20);
			rbPhanBietMauNen.TabIndex = 34;
			rbPhanBietMauNen.TabStop = true;
			rbPhanBietMauNen.Text = "Đổi màu nền dòng";
			rbPhanBietMauNen.UseVisualStyleBackColor = true;
			rbPhanBietMauChu.AutoSize = true;
			rbPhanBietMauChu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbPhanBietMauChu.Location = new System.Drawing.Point(190, 3);
			rbPhanBietMauChu.Name = "rbPhanBietMauChu";
			rbPhanBietMauChu.Size = new System.Drawing.Size(99, 20);
			rbPhanBietMauChu.TabIndex = 34;
			rbPhanBietMauChu.Text = "Đổi màu chữ";
			rbPhanBietMauChu.UseVisualStyleBackColor = true;
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label23.Location = new System.Drawing.Point(32, 20);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(224, 16);
			label23.TabIndex = 33;
			label23.Text = "Phân biệt màu [Tình trạng tài khoản]:";
			ckbLuuTrangThai.AutoSize = true;
			ckbLuuTrangThai.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbLuuTrangThai.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbLuuTrangThai.Location = new System.Drawing.Point(35, 43);
			ckbLuuTrangThai.Name = "ckbLuuTrangThai";
			ckbLuuTrangThai.Size = new System.Drawing.Size(185, 20);
			ckbLuuTrangThai.TabIndex = 112;
			ckbLuuTrangThai.Text = "Lưu dư\u0303 liê\u0323u cô\u0323t [Tra\u0323ng tha\u0301i]";
			ckbLuuTrangThai.UseVisualStyleBackColor = true;
			groupBox2.Controls.Add(plDongBoMaxCare);
			groupBox2.Controls.Add(ckbDongBoMaxCare);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(nudHideThread);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(nudInteractThread);
			groupBox2.Controls.Add(label3);
			groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox2.Location = new System.Drawing.Point(7, 39);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(567, 129);
			groupBox2.TabIndex = 38;
			groupBox2.TabStop = false;
			groupBox2.Text = "Cấu hình chung";
			plDongBoMaxCare.Controls.Add(label15);
			plDongBoMaxCare.Controls.Add(txtPathMaxCare);
			plDongBoMaxCare.Location = new System.Drawing.Point(48, 97);
			plDongBoMaxCare.Name = "plDongBoMaxCare";
			plDongBoMaxCare.Size = new System.Drawing.Size(517, 29);
			plDongBoMaxCare.TabIndex = 164;
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(3, 6);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(130, 16);
			label15.TabIndex = 158;
			label15.Text = "Đường dẫn MaxCare:";
			txtPathMaxCare.Location = new System.Drawing.Point(136, 3);
			txtPathMaxCare.Name = "txtPathMaxCare";
			txtPathMaxCare.Size = new System.Drawing.Size(378, 23);
			txtPathMaxCare.TabIndex = 159;
			ckbDongBoMaxCare.AutoSize = true;
			ckbDongBoMaxCare.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDongBoMaxCare.Location = new System.Drawing.Point(35, 79);
			ckbDongBoMaxCare.Name = "ckbDongBoMaxCare";
			ckbDongBoMaxCare.Size = new System.Drawing.Size(192, 20);
			ckbDongBoMaxCare.TabIndex = 29;
			ckbDongBoMaxCare.Text = "Đô\u0300ng bô\u0323 dư\u0303 liê\u0323u vơ\u0301i MaxCare";
			ckbDongBoMaxCare.UseVisualStyleBackColor = true;
			ckbDongBoMaxCare.CheckedChanged += new System.EventHandler(ckbDongBoMaxCare_CheckedChanged);
			btnSSH.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSSH.Enabled = false;
			btnSSH.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnSSH.ForeColor = System.Drawing.Color.Black;
			btnSSH.Location = new System.Drawing.Point(1263, 508);
			btnSSH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnSSH.Name = "btnSSH";
			btnSSH.Size = new System.Drawing.Size(106, 26);
			btnSSH.TabIndex = 130;
			btnSSH.Text = "Nhập IP SSH";
			btnSSH.UseVisualStyleBackColor = true;
			btnSSH.Click += new System.EventHandler(btnSSH_Click);
			radioButton4.AutoSize = true;
			radioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton4.Enabled = false;
			radioButton4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton4.Location = new System.Drawing.Point(1162, 426);
			radioButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new System.Drawing.Size(131, 20);
			radioButton4.TabIndex = 133;
			radioButton4.Text = "Đổi IP ExpressVPN";
			radioButton4.UseVisualStyleBackColor = true;
			rbHotspot.AutoSize = true;
			rbHotspot.Enabled = false;
			rbHotspot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbHotspot.Location = new System.Drawing.Point(1162, 539);
			rbHotspot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbHotspot.Name = "rbHotspot";
			rbHotspot.Size = new System.Drawing.Size(146, 20);
			rbHotspot.TabIndex = 135;
			rbHotspot.Text = "Đổi IP Hotspot Shield";
			rbHotspot.UseVisualStyleBackColor = true;
			radioButton5.AutoSize = true;
			radioButton5.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton5.Enabled = false;
			radioButton5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton5.Location = new System.Drawing.Point(1162, 511);
			radioButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new System.Drawing.Size(88, 20);
			radioButton5.TabIndex = 132;
			radioButton5.Text = "Đổi IP SSH";
			radioButton5.UseVisualStyleBackColor = true;
			rbNordVPN.AutoSize = true;
			rbNordVPN.Enabled = false;
			rbNordVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbNordVPN.Location = new System.Drawing.Point(1162, 451);
			rbNordVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbNordVPN.Name = "rbNordVPN";
			rbNordVPN.Size = new System.Drawing.Size(114, 20);
			rbNordVPN.TabIndex = 134;
			rbNordVPN.Text = "Đổi IP NordVPN";
			rbNordVPN.UseVisualStyleBackColor = true;
			rbNordVPN.CheckedChanged += new System.EventHandler(rbNordVPN_CheckedChanged);
			radioButton2.AutoSize = true;
			radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton2.Enabled = false;
			radioButton2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton2.Location = new System.Drawing.Point(1162, 539);
			radioButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(146, 20);
			radioButton2.TabIndex = 135;
			radioButton2.Text = "Đổi IP Hotspot Shield";
			radioButton2.UseVisualStyleBackColor = true;
			rbSSH.AutoSize = true;
			rbSSH.Enabled = false;
			rbSSH.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbSSH.Location = new System.Drawing.Point(1162, 511);
			rbSSH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbSSH.Name = "rbSSH";
			rbSSH.Size = new System.Drawing.Size(88, 20);
			rbSSH.TabIndex = 132;
			rbSSH.Text = "Đổi IP SSH";
			rbSSH.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
			radioButton3.Enabled = false;
			radioButton3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			radioButton3.Location = new System.Drawing.Point(1162, 451);
			radioButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(114, 20);
			radioButton3.TabIndex = 134;
			radioButton3.Text = "Đổi IP NordVPN";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton3.CheckedChanged += new System.EventHandler(rbNordVPN_CheckedChanged);
			rbExpressVPN.AutoSize = true;
			rbExpressVPN.Enabled = false;
			rbExpressVPN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbExpressVPN.Location = new System.Drawing.Point(1162, 426);
			rbExpressVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbExpressVPN.Name = "rbExpressVPN";
			rbExpressVPN.Size = new System.Drawing.Size(131, 20);
			rbExpressVPN.TabIndex = 133;
			rbExpressVPN.Text = "Đổi IP ExpressVPN";
			rbExpressVPN.UseVisualStyleBackColor = true;
			groupBox3.Controls.Add(plXproxy);
			groupBox3.Controls.Add(plShopLike);
			groupBox3.Controls.Add(rbShopLike);
			groupBox3.Controls.Add(plProxyv6);
			groupBox3.Controls.Add(rbProxyv6);
			groupBox3.Controls.Add(plDcom);
			groupBox3.Controls.Add(linkLabel3);
			groupBox3.Controls.Add(linkLabel1);
			groupBox3.Controls.Add(plTMProxy);
			groupBox3.Controls.Add(plCheckDoiIP);
			groupBox3.Controls.Add(plTinsoft);
			groupBox3.Controls.Add(rbTMProxy);
			groupBox3.Controls.Add(rbDcom);
			groupBox3.Controls.Add(rbTinsoft);
			groupBox3.Controls.Add(rbProxy);
			groupBox3.Controls.Add(rbNone);
			groupBox3.Controls.Add(rbXproxy);
			groupBox3.Controls.Add(rbHma);
			groupBox3.Controls.Add(ckbKhongCheckIP);
			groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox3.Location = new System.Drawing.Point(581, 39);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(568, 605);
			groupBox3.TabIndex = 39;
			groupBox3.TabStop = false;
			groupBox3.Text = "Cấu hình đổi IP";
			plXproxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plXproxy.Controls.Add(btnDown);
			plXproxy.Controls.Add(ckbWaitDoneAllXproxy);
			plXproxy.Controls.Add(txtListProxy);
			plXproxy.Controls.Add(label17);
			plXproxy.Controls.Add(label20);
			plXproxy.Controls.Add(label16);
			plXproxy.Controls.Add(label18);
			plXproxy.Controls.Add(nudDelayResetXProxy);
			plXproxy.Controls.Add(nudLuongPerIPXProxy);
			plXproxy.Controls.Add(label13);
			plXproxy.Controls.Add(txtServiceURLXProxy);
			plXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plXproxy.Location = new System.Drawing.Point(322, 83);
			plXproxy.Name = "plXproxy";
			plXproxy.Size = new System.Drawing.Size(240, 170);
			plXproxy.TabIndex = 142;
			plXproxy.Click += new System.EventHandler(plXproxy_Click);
			ckbWaitDoneAllXproxy.AutoSize = true;
			ckbWaitDoneAllXproxy.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWaitDoneAllXproxy.Location = new System.Drawing.Point(106, 28);
			ckbWaitDoneAllXproxy.Name = "ckbWaitDoneAllXproxy";
			ckbWaitDoneAllXproxy.Size = new System.Drawing.Size(129, 20);
			ckbWaitDoneAllXproxy.TabIndex = 145;
			ckbWaitDoneAllXproxy.Text = "Đợi chạy xong hết";
			ckbWaitDoneAllXproxy.UseVisualStyleBackColor = true;
			ckbWaitDoneAllXproxy.Visible = false;
			txtListProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtListProxy.Location = new System.Drawing.Point(6, 51);
			txtListProxy.Name = "txtListProxy";
			txtListProxy.Size = new System.Drawing.Size(229, 88);
			txtListProxy.TabIndex = 144;
			txtListProxy.Text = "";
			txtListProxy.WordWrap = false;
			txtListProxy.TextChanged += new System.EventHandler(txtListProxy_TextChanged);
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label17.Location = new System.Drawing.Point(1, 29);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(98, 16);
			label17.TabIndex = 79;
			label17.Text = "Nhập Proxy (0):";
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label18.Location = new System.Drawing.Point(5, 143);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(79, 16);
			label18.TabIndex = 139;
			label18.Text = "Số luồng/IP:";
			nudLuongPerIPXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPXProxy.Location = new System.Drawing.Point(90, 142);
			nudLuongPerIPXProxy.Name = "nudLuongPerIPXProxy";
			nudLuongPerIPXProxy.Size = new System.Drawing.Size(67, 23);
			nudLuongPerIPXProxy.TabIndex = 140;
			nudLuongPerIPXProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label13.Location = new System.Drawing.Point(3, 5);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(81, 16);
			label13.TabIndex = 79;
			label13.Text = "Service URL:";
			txtServiceURLXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtServiceURLXProxy.ForeColor = System.Drawing.Color.Black;
			txtServiceURLXProxy.Location = new System.Drawing.Point(90, 2);
			txtServiceURLXProxy.Name = "txtServiceURLXProxy";
			txtServiceURLXProxy.Size = new System.Drawing.Size(145, 23);
			txtServiceURLXProxy.TabIndex = 81;
			plShopLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plShopLike.Controls.Add(txtApiShopLike);
			plShopLike.Controls.Add(label47);
			plShopLike.Controls.Add(label48);
			plShopLike.Controls.Add(nudLuongPerIPShopLike);
			plShopLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plShopLike.Location = new System.Drawing.Point(32, 428);
			plShopLike.Name = "plShopLike";
			plShopLike.Size = new System.Drawing.Size(266, 169);
			plShopLike.TabIndex = 157;
			txtApiShopLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtApiShopLike.Location = new System.Drawing.Point(6, 21);
			txtApiShopLike.Name = "txtApiShopLike";
			txtApiShopLike.Size = new System.Drawing.Size(255, 117);
			txtApiShopLike.TabIndex = 144;
			txtApiShopLike.Text = "";
			txtApiShopLike.WordWrap = false;
			txtApiShopLike.TextChanged += new System.EventHandler(txtApiShopLike_TextChanged);
			label47.AutoSize = true;
			label47.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label47.Location = new System.Drawing.Point(3, 2);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(111, 16);
			label47.TabIndex = 79;
			label47.Text = "Nhập API KEY (0):";
			label48.AutoSize = true;
			label48.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label48.Location = new System.Drawing.Point(3, 144);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(79, 16);
			label48.TabIndex = 139;
			label48.Text = "Số luồng/IP:";
			nudLuongPerIPShopLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPShopLike.Location = new System.Drawing.Point(88, 141);
			nudLuongPerIPShopLike.Name = "nudLuongPerIPShopLike";
			nudLuongPerIPShopLike.Size = new System.Drawing.Size(67, 23);
			nudLuongPerIPShopLike.TabIndex = 140;
			nudLuongPerIPShopLike.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			rbShopLike.AutoSize = true;
			rbShopLike.Cursor = System.Windows.Forms.Cursors.Hand;
			rbShopLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbShopLike.Location = new System.Drawing.Point(33, 404);
			rbShopLike.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbShopLike.Name = "rbShopLike";
			rbShopLike.Size = new System.Drawing.Size(166, 20);
			rbShopLike.TabIndex = 156;
			rbShopLike.Text = "http://proxy.shoplike.vn/";
			rbShopLike.UseVisualStyleBackColor = true;
			rbShopLike.CheckedChanged += new System.EventHandler(rbShopLike_CheckedChanged);
			plProxyv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plProxyv6.Controls.Add(txtListProxyv6);
			plProxyv6.Controls.Add(label43);
			plProxyv6.Controls.Add(label44);
			plProxyv6.Controls.Add(nudLuongPerIPProxyv6);
			plProxyv6.Controls.Add(label45);
			plProxyv6.Controls.Add(txtApiProxyv6);
			plProxyv6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plProxyv6.Location = new System.Drawing.Point(322, 427);
			plProxyv6.Name = "plProxyv6";
			plProxyv6.Size = new System.Drawing.Size(240, 170);
			plProxyv6.TabIndex = 155;
			txtListProxyv6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtListProxyv6.Location = new System.Drawing.Point(6, 47);
			txtListProxyv6.Name = "txtListProxyv6";
			txtListProxyv6.Size = new System.Drawing.Size(229, 92);
			txtListProxyv6.TabIndex = 144;
			txtListProxyv6.Text = "";
			txtListProxyv6.WordWrap = false;
			txtListProxyv6.TextChanged += new System.EventHandler(txtListProxyv6_TextChanged);
			label43.AutoSize = true;
			label43.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label43.Location = new System.Drawing.Point(3, 28);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(98, 16);
			label43.TabIndex = 79;
			label43.Text = "Nhập Proxy (0):";
			label44.AutoSize = true;
			label44.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label44.Location = new System.Drawing.Point(5, 143);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(79, 16);
			label44.TabIndex = 139;
			label44.Text = "Số luồng/IP:";
			nudLuongPerIPProxyv6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPProxyv6.Location = new System.Drawing.Point(90, 142);
			nudLuongPerIPProxyv6.Name = "nudLuongPerIPProxyv6";
			nudLuongPerIPProxyv6.Size = new System.Drawing.Size(67, 23);
			nudLuongPerIPProxyv6.TabIndex = 140;
			nudLuongPerIPProxyv6.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label45.AutoSize = true;
			label45.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label45.Location = new System.Drawing.Point(3, 5);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(56, 16);
			label45.TabIndex = 79;
			label45.Text = "API Key:";
			txtApiProxyv6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtApiProxyv6.ForeColor = System.Drawing.Color.Black;
			txtApiProxyv6.Location = new System.Drawing.Point(75, 2);
			txtApiProxyv6.Name = "txtApiProxyv6";
			txtApiProxyv6.Size = new System.Drawing.Size(160, 23);
			txtApiProxyv6.TabIndex = 81;
			rbProxyv6.AutoSize = true;
			rbProxyv6.Cursor = System.Windows.Forms.Cursors.Hand;
			rbProxyv6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbProxyv6.Location = new System.Drawing.Point(322, 404);
			rbProxyv6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbProxyv6.Name = "rbProxyv6";
			rbProxyv6.Size = new System.Drawing.Size(92, 20);
			rbProxyv6.TabIndex = 154;
			rbProxyv6.Text = "Proxyv6.net";
			rbProxyv6.UseVisualStyleBackColor = true;
			rbProxyv6.CheckedChanged += new System.EventHandler(rbProxyv6_CheckedChanged);
			plDcom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDcom.Controls.Add(button4);
			plDcom.Controls.Add(txtUrlHilink);
			plDcom.Controls.Add(txtProfileNameDcom);
			plDcom.Controls.Add(rbDcomHilink);
			plDcom.Controls.Add(label19);
			plDcom.Controls.Add(rbDcomThuong);
			plDcom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plDcom.Location = new System.Drawing.Point(32, 152);
			plDcom.Name = "plDcom";
			plDcom.Size = new System.Drawing.Size(265, 57);
			plDcom.TabIndex = 148;
			button4.Cursor = System.Windows.Forms.Cursors.Hand;
			button4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button4.ForeColor = System.Drawing.Color.Black;
			button4.Location = new System.Drawing.Point(72, 1);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(93, 25);
			button4.TabIndex = 143;
			button4.Text = "Lâ\u0301y tên Dcom";
			toolTip1.SetToolTip(button4, "Lâ\u0301y tên dcom");
			button4.UseVisualStyleBackColor = true;
			button4.Click += new System.EventHandler(button4_Click);
			txtUrlHilink.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtUrlHilink.ForeColor = System.Drawing.Color.Black;
			txtUrlHilink.Location = new System.Drawing.Point(171, 30);
			txtUrlHilink.Name = "txtUrlHilink";
			txtUrlHilink.Size = new System.Drawing.Size(91, 23);
			txtUrlHilink.TabIndex = 81;
			txtProfileNameDcom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtProfileNameDcom.ForeColor = System.Drawing.Color.Black;
			txtProfileNameDcom.Location = new System.Drawing.Point(171, 2);
			txtProfileNameDcom.Name = "txtProfileNameDcom";
			txtProfileNameDcom.Size = new System.Drawing.Size(91, 23);
			txtProfileNameDcom.TabIndex = 81;
			rbDcomHilink.AutoSize = true;
			rbDcomHilink.Cursor = System.Windows.Forms.Cursors.Hand;
			rbDcomHilink.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbDcomHilink.Location = new System.Drawing.Point(5, 31);
			rbDcomHilink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbDcomHilink.Name = "rbDcomHilink";
			rbDcomHilink.Size = new System.Drawing.Size(56, 20);
			rbDcomHilink.TabIndex = 136;
			rbDcomHilink.Text = "Hilink";
			rbDcomHilink.UseVisualStyleBackColor = true;
			rbDcomHilink.CheckedChanged += new System.EventHandler(rbDcomHilink_CheckedChanged);
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label19.Location = new System.Drawing.Point(69, 33);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(102, 16);
			label19.TabIndex = 79;
			label19.Text = "Đươ\u0300ng dâ\u0303n URL:";
			rbDcomThuong.AutoSize = true;
			rbDcomThuong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbDcomThuong.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbDcomThuong.Location = new System.Drawing.Point(5, 3);
			rbDcomThuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbDcomThuong.Name = "rbDcomThuong";
			rbDcomThuong.Size = new System.Drawing.Size(70, 20);
			rbDcomThuong.TabIndex = 136;
			rbDcomThuong.Text = "Thươ\u0300ng";
			rbDcomThuong.UseVisualStyleBackColor = true;
			rbDcomThuong.CheckedChanged += new System.EventHandler(rbDcomThuong_CheckedChanged);
			linkLabel3.AutoSize = true;
			linkLabel3.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel3.Location = new System.Drawing.Point(215, 215);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(86, 16);
			linkLabel3.TabIndex = 147;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "Hươ\u0301ng dâ\u0303n(?)";
			linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
			linkLabel1.AutoSize = true;
			linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
			linkLabel1.Location = new System.Drawing.Point(481, 259);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(86, 16);
			linkLabel1.TabIndex = 147;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Hươ\u0301ng dâ\u0303n(?)";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			plTMProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTMProxy.Controls.Add(ckbWaitDoneAllTMProxy);
			plTMProxy.Controls.Add(txtApiKeyTMProxy);
			plTMProxy.Controls.Add(label24);
			plTMProxy.Controls.Add(button8);
			plTMProxy.Controls.Add(label25);
			plTMProxy.Controls.Add(nudLuongPerIPTMProxy);
			plTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTMProxy.Location = new System.Drawing.Point(322, 279);
			plTMProxy.Name = "plTMProxy";
			plTMProxy.Size = new System.Drawing.Size(240, 123);
			plTMProxy.TabIndex = 146;
			plTMProxy.Click += new System.EventHandler(plTMProxy_Click);
			ckbWaitDoneAllTMProxy.AutoSize = true;
			ckbWaitDoneAllTMProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWaitDoneAllTMProxy.Location = new System.Drawing.Point(115, 1);
			ckbWaitDoneAllTMProxy.Name = "ckbWaitDoneAllTMProxy";
			ckbWaitDoneAllTMProxy.Size = new System.Drawing.Size(129, 20);
			ckbWaitDoneAllTMProxy.TabIndex = 145;
			ckbWaitDoneAllTMProxy.Text = "Đợi chạy xong hết";
			ckbWaitDoneAllTMProxy.UseVisualStyleBackColor = true;
			ckbWaitDoneAllTMProxy.Visible = false;
			txtApiKeyTMProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtApiKeyTMProxy.Location = new System.Drawing.Point(6, 23);
			txtApiKeyTMProxy.Name = "txtApiKeyTMProxy";
			txtApiKeyTMProxy.Size = new System.Drawing.Size(175, 68);
			txtApiKeyTMProxy.TabIndex = 144;
			txtApiKeyTMProxy.Text = "";
			txtApiKeyTMProxy.WordWrap = false;
			txtApiKeyTMProxy.TextChanged += new System.EventHandler(txtApiKeyTMProxy_TextChanged);
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label24.Location = new System.Drawing.Point(3, 2);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(111, 16);
			label24.TabIndex = 79;
			label24.Text = "Nhập API KEY (0):";
			button8.Cursor = System.Windows.Forms.Cursors.Hand;
			button8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button8.ForeColor = System.Drawing.Color.Black;
			button8.Location = new System.Drawing.Point(183, 22);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(52, 27);
			button8.TabIndex = 143;
			button8.Text = "Check";
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label25.Location = new System.Drawing.Point(5, 95);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(79, 16);
			label25.TabIndex = 139;
			label25.Text = "Số luồng/IP:";
			nudLuongPerIPTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPTMProxy.Location = new System.Drawing.Point(90, 94);
			nudLuongPerIPTMProxy.Name = "nudLuongPerIPTMProxy";
			nudLuongPerIPTMProxy.Size = new System.Drawing.Size(67, 23);
			nudLuongPerIPTMProxy.TabIndex = 140;
			nudLuongPerIPTMProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			plCheckDoiIP.Controls.Add(button5);
			plCheckDoiIP.Controls.Add(label26);
			plCheckDoiIP.Controls.Add(nudChangeIpCount);
			plCheckDoiIP.Controls.Add(label27);
			plCheckDoiIP.Location = new System.Drawing.Point(25, 50);
			plCheckDoiIP.Name = "plCheckDoiIP";
			plCheckDoiIP.Size = new System.Drawing.Size(270, 27);
			plCheckDoiIP.TabIndex = 146;
			button5.Cursor = System.Windows.Forms.Cursors.Hand;
			button5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button5.ForeColor = System.Drawing.Color.Black;
			button5.Location = new System.Drawing.Point(193, 0);
			button5.Name = "button5";
			button5.Size = new System.Drawing.Size(77, 27);
			button5.TabIndex = 143;
			button5.Text = "Test";
			button5.UseVisualStyleBackColor = true;
			button5.Click += new System.EventHandler(button5_Click);
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label26.Location = new System.Drawing.Point(3, 5);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(101, 16);
			label26.TabIndex = 139;
			label26.Text = "Thay đổi IP sau:";
			nudChangeIpCount.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudChangeIpCount.Location = new System.Drawing.Point(106, 3);
			nudChangeIpCount.Name = "nudChangeIpCount";
			nudChangeIpCount.Size = new System.Drawing.Size(46, 23);
			nudChangeIpCount.TabIndex = 140;
			nudChangeIpCount.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label27.Location = new System.Drawing.Point(154, 5);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(30, 16);
			label27.TabIndex = 141;
			label27.Text = "lượt";
			plTinsoft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTinsoft.Controls.Add(ckbWaitDoneAllTinsoft);
			plTinsoft.Controls.Add(plApiProxy);
			plTinsoft.Controls.Add(plApiUser);
			plTinsoft.Controls.Add(cbbLocationTinsoft);
			plTinsoft.Controls.Add(rbApiProxy);
			plTinsoft.Controls.Add(rbApiUser);
			plTinsoft.Controls.Add(label7);
			plTinsoft.Controls.Add(label8);
			plTinsoft.Controls.Add(nudLuongPerIPTinsoft);
			plTinsoft.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTinsoft.Location = new System.Drawing.Point(32, 237);
			plTinsoft.Name = "plTinsoft";
			plTinsoft.Size = new System.Drawing.Size(266, 165);
			plTinsoft.TabIndex = 142;
			plTinsoft.Click += new System.EventHandler(plTinsoft_Click);
			ckbWaitDoneAllTinsoft.AutoSize = true;
			ckbWaitDoneAllTinsoft.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWaitDoneAllTinsoft.Location = new System.Drawing.Point(132, 3);
			ckbWaitDoneAllTinsoft.Name = "ckbWaitDoneAllTinsoft";
			ckbWaitDoneAllTinsoft.Size = new System.Drawing.Size(129, 20);
			ckbWaitDoneAllTinsoft.TabIndex = 145;
			ckbWaitDoneAllTinsoft.Text = "Đợi chạy xong hết";
			ckbWaitDoneAllTinsoft.UseVisualStyleBackColor = true;
			ckbWaitDoneAllTinsoft.Visible = false;
			plApiProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plApiProxy.Controls.Add(lblCountApiProxy);
			plApiProxy.Controls.Add(label28);
			plApiProxy.Controls.Add(txtApiProxy);
			plApiProxy.Controls.Add(button7);
			plApiProxy.Location = new System.Drawing.Point(6, 77);
			plApiProxy.Name = "plApiProxy";
			plApiProxy.Size = new System.Drawing.Size(257, 58);
			plApiProxy.TabIndex = 35;
			lblCountApiProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			lblCountApiProxy.Location = new System.Drawing.Point(1, 24);
			lblCountApiProxy.Name = "lblCountApiProxy";
			lblCountApiProxy.Size = new System.Drawing.Size(32, 16);
			lblCountApiProxy.TabIndex = 82;
			lblCountApiProxy.Text = "(0)";
			lblCountApiProxy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label28.Location = new System.Drawing.Point(1, 5);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(32, 16);
			label28.TabIndex = 82;
			label28.Text = "API:";
			txtApiProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtApiProxy.ForeColor = System.Drawing.Color.Black;
			txtApiProxy.Location = new System.Drawing.Point(35, 2);
			txtApiProxy.Multiline = true;
			txtApiProxy.Name = "txtApiProxy";
			txtApiProxy.Size = new System.Drawing.Size(165, 51);
			txtApiProxy.TabIndex = 83;
			txtApiProxy.WordWrap = false;
			txtApiProxy.TextChanged += new System.EventHandler(txtApiProxy_TextChanged);
			button7.Cursor = System.Windows.Forms.Cursors.Hand;
			button7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button7.ForeColor = System.Drawing.Color.Black;
			button7.Location = new System.Drawing.Point(203, 1);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(52, 27);
			button7.TabIndex = 143;
			button7.Text = "Check";
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			plApiUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plApiUser.Controls.Add(label1);
			plApiUser.Controls.Add(txtApiUser);
			plApiUser.Controls.Add(button3);
			plApiUser.Location = new System.Drawing.Point(6, 24);
			plApiUser.Name = "plApiUser";
			plApiUser.Size = new System.Drawing.Size(257, 29);
			plApiUser.TabIndex = 35;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label1.Location = new System.Drawing.Point(1, 5);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 16);
			label1.TabIndex = 82;
			label1.Text = "API:";
			txtApiUser.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtApiUser.ForeColor = System.Drawing.Color.Black;
			txtApiUser.Location = new System.Drawing.Point(35, 2);
			txtApiUser.Name = "txtApiUser";
			txtApiUser.Size = new System.Drawing.Size(165, 23);
			txtApiUser.TabIndex = 83;
			button3.Cursor = System.Windows.Forms.Cursors.Hand;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button3.ForeColor = System.Drawing.Color.Black;
			button3.Location = new System.Drawing.Point(203, 0);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(52, 27);
			button3.TabIndex = 143;
			button3.Text = "Check";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			cbbLocationTinsoft.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbLocationTinsoft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbLocationTinsoft.DropDownWidth = 120;
			cbbLocationTinsoft.FormattingEnabled = true;
			cbbLocationTinsoft.Location = new System.Drawing.Point(61, 137);
			cbbLocationTinsoft.Name = "cbbLocationTinsoft";
			cbbLocationTinsoft.Size = new System.Drawing.Size(67, 24);
			cbbLocationTinsoft.TabIndex = 84;
			rbApiProxy.AutoSize = true;
			rbApiProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbApiProxy.Location = new System.Drawing.Point(3, 56);
			rbApiProxy.Name = "rbApiProxy";
			rbApiProxy.Size = new System.Drawing.Size(136, 20);
			rbApiProxy.TabIndex = 34;
			rbApiProxy.Text = "Sử dụng Api Proxy:";
			rbApiProxy.UseVisualStyleBackColor = true;
			rbApiProxy.CheckedChanged += new System.EventHandler(rbApiProxy_CheckedChanged);
			rbApiUser.AutoSize = true;
			rbApiUser.Checked = true;
			rbApiUser.Cursor = System.Windows.Forms.Cursors.Hand;
			rbApiUser.Location = new System.Drawing.Point(3, 3);
			rbApiUser.Name = "rbApiUser";
			rbApiUser.Size = new System.Drawing.Size(131, 20);
			rbApiUser.TabIndex = 34;
			rbApiUser.TabStop = true;
			rbApiUser.Text = "Sử dụng Api User:";
			rbApiUser.UseVisualStyleBackColor = true;
			rbApiUser.CheckedChanged += new System.EventHandler(rbApiUser_CheckedChanged);
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(3, 140);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(60, 16);
			label7.TabIndex = 82;
			label7.Text = "Location:";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label8.Location = new System.Drawing.Point(134, 140);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(79, 16);
			label8.TabIndex = 139;
			label8.Text = "Số luồng/IP:";
			toolTip1.SetToolTip(label8, "Là số tài khoản cùng chạy trên 1 Proxy (hay 1 IP)");
			nudLuongPerIPTinsoft.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPTinsoft.Location = new System.Drawing.Point(216, 138);
			nudLuongPerIPTinsoft.Name = "nudLuongPerIPTinsoft";
			nudLuongPerIPTinsoft.Size = new System.Drawing.Size(46, 23);
			nudLuongPerIPTinsoft.TabIndex = 140;
			nudLuongPerIPTinsoft.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			rbTMProxy.AutoSize = true;
			rbTMProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbTMProxy.Location = new System.Drawing.Point(322, 256);
			rbTMProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbTMProxy.Name = "rbTMProxy";
			rbTMProxy.Size = new System.Drawing.Size(148, 20);
			rbTMProxy.TabIndex = 145;
			rbTMProxy.Text = "https://tmproxy.com/";
			rbTMProxy.UseVisualStyleBackColor = true;
			rbTMProxy.CheckedChanged += new System.EventHandler(rbTMProxy_CheckedChanged);
			rbDcom.AutoSize = true;
			rbDcom.Cursor = System.Windows.Forms.Cursors.Hand;
			rbDcom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbDcom.Location = new System.Drawing.Point(31, 129);
			rbDcom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbDcom.Name = "rbDcom";
			rbDcom.Size = new System.Drawing.Size(96, 20);
			rbDcom.TabIndex = 137;
			rbDcom.Text = "Đổi IP Dcom";
			rbDcom.UseVisualStyleBackColor = true;
			rbDcom.CheckedChanged += new System.EventHandler(rbDcom_CheckedChanged);
			rbTinsoft.AutoSize = true;
			rbTinsoft.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTinsoft.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbTinsoft.Location = new System.Drawing.Point(31, 213);
			rbTinsoft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbTinsoft.Name = "rbTinsoft";
			rbTinsoft.Size = new System.Drawing.Size(168, 20);
			rbTinsoft.TabIndex = 134;
			rbTinsoft.Text = "https://tinsoftproxy.com/";
			rbTinsoft.UseVisualStyleBackColor = true;
			rbTinsoft.CheckedChanged += new System.EventHandler(rbTinsoft_CheckedChanged);
			rbProxy.AutoSize = true;
			rbProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbProxy.Location = new System.Drawing.Point(31, 106);
			rbProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbProxy.Name = "rbProxy";
			rbProxy.Size = new System.Drawing.Size(267, 20);
			rbProxy.TabIndex = 136;
			rbProxy.Text = "Sử dụng Proxy (đã gán cho mỗi tài khoản)";
			rbProxy.UseVisualStyleBackColor = true;
			rbNone.AutoSize = true;
			rbNone.Checked = true;
			rbNone.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNone.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbNone.Location = new System.Drawing.Point(31, 83);
			rbNone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbNone.Name = "rbNone";
			rbNone.Size = new System.Drawing.Size(97, 20);
			rbNone.TabIndex = 136;
			rbNone.TabStop = true;
			rbNone.Text = "Không đổi IP";
			rbNone.UseVisualStyleBackColor = true;
			rbXproxy.AutoSize = true;
			rbXproxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbXproxy.Location = new System.Drawing.Point(322, 53);
			rbXproxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbXproxy.Name = "rbXproxy";
			rbXproxy.Size = new System.Drawing.Size(224, 20);
			rbXproxy.TabIndex = 138;
			rbXproxy.Text = "Xproxy, Mobi, OBC, Eager, S Proxy";
			rbXproxy.UseVisualStyleBackColor = true;
			rbXproxy.CheckedChanged += new System.EventHandler(rbXproxy_CheckedChanged);
			rbHma.AutoSize = true;
			rbHma.Cursor = System.Windows.Forms.Cursors.Hand;
			rbHma.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbHma.Location = new System.Drawing.Point(164, 83);
			rbHma.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			rbHma.Name = "rbHma";
			rbHma.Size = new System.Drawing.Size(90, 20);
			rbHma.TabIndex = 138;
			rbHma.Text = "Đổi IP HMA";
			rbHma.UseVisualStyleBackColor = true;
			rbHma.CheckedChanged += new System.EventHandler(rbHma_CheckedChanged);
			ckbKhongCheckIP.AutoSize = true;
			ckbKhongCheckIP.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongCheckIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbKhongCheckIP.Location = new System.Drawing.Point(31, 26);
			ckbKhongCheckIP.Name = "ckbKhongCheckIP";
			ckbKhongCheckIP.Size = new System.Drawing.Size(199, 20);
			ckbKhongCheckIP.TabIndex = 112;
			ckbKhongCheckIP.Text = "Không Check IP trước khi chạy";
			ckbKhongCheckIP.UseVisualStyleBackColor = true;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			btnDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDown.BackgroundImage = maxcare.Properties.Resources.icons8_expand_arrow_24px;
			btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDown.Location = new System.Drawing.Point(209, 141);
			btnDown.Name = "btnDown";
			btnDown.Size = new System.Drawing.Size(25, 25);
			btnDown.TabIndex = 146;
			btnDown.UseSelectable = true;
			btnDown.Click += new System.EventHandler(btnDown_Click);
			nudDelayResetXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudDelayResetXProxy.Location = new System.Drawing.Point(144, 170);
			nudDelayResetXProxy.Name = "nudDelayResetXProxy";
			nudDelayResetXProxy.Size = new System.Drawing.Size(50, 23);
			nudDelayResetXProxy.TabIndex = 140;
			nudDelayResetXProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label16.Location = new System.Drawing.Point(5, 172);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(139, 16);
			label16.TabIndex = 139;
			label16.Text = "Chờ reset proxy tối đa:";
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label20.Location = new System.Drawing.Point(199, 172);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(33, 16);
			label20.TabIndex = 139;
			label20.Text = "phút";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1158, 692);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCauHinhChung";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình chung";
			base.Load += new System.EventHandler(FConfigGenneral_Load);
			((System.ComponentModel.ISupportInitialize)nudInteractThread).EndInit();
			((System.ComponentModel.ISupportInitialize)nudHideThread).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			grChrome.ResumeLayout(false);
			grChrome.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			plDelayMoChrome.ResumeLayout(false);
			plDelayMoChrome.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayOpenDeviceTo).EndInit();
			plLDPlayerThuong.ResumeLayout(false);
			plLDPlayerThuong.PerformLayout();
			plLDPlayerSwap.ResumeLayout(false);
			plLDPlayerSwap.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayCloseDeviceTo).EndInit();
			bunifuCards2.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			plNordVPN.ResumeLayout(false);
			plNordVPN.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			plDongBoMaxCare.ResumeLayout(false);
			plDongBoMaxCare.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			plXproxy.ResumeLayout(false);
			plXproxy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).EndInit();
			plShopLike.ResumeLayout(false);
			plShopLike.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPShopLike).EndInit();
			plProxyv6.ResumeLayout(false);
			plProxyv6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPProxyv6).EndInit();
			plDcom.ResumeLayout(false);
			plDcom.PerformLayout();
			plTMProxy.ResumeLayout(false);
			plTMProxy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTMProxy).EndInit();
			plCheckDoiIP.ResumeLayout(false);
			plCheckDoiIP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudChangeIpCount).EndInit();
			plTinsoft.ResumeLayout(false);
			plTinsoft.PerformLayout();
			plApiProxy.ResumeLayout(false);
			plApiProxy.PerformLayout();
			plApiUser.ResumeLayout(false);
			plApiUser.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTinsoft).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayResetXProxy).EndInit();
			ResumeLayout(false);
		}
	}
}
