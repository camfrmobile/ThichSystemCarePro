using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using maxcare.Properties;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fHDBuffTinNhanProfile : Form
	{
		private JSON_Settings setting;

		private string id_KichBan;

		private string id_TuongTac;

		private string Id_HanhDong;

		private int type;

		public static bool isSave;

		private IContainer components = null;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private Panel panel1;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private TextBox txtTenHanhDong;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Panel plComment;

		private Label label8;

		private Label lblStatus;

		private CheckBox ckbNhanTinVanBan;

		private Label label49;

		private NumericUpDown nudSoLuongUidFrom;

		private Label label68;

		private NumericUpDown nudSoLuongUidTo;

		private Label label66;

		private Label label2;

		private Label lblStatusUid;

		private RichTextBox txtUid;

		private Panel plAnh;

		private CheckBox ckbSendAnh;

		private RichTextBox txtNoiDung;

		private CheckBox ckbTuDongXoaUid;

		private ToolTip toolTip1;

		private Label label3;

		private Label label4;

		private Label label9;

		private NumericUpDown nudSoLuongAnhFrom;

		private NumericUpDown nudSoLuongAnhTo;

		private MetroButton btnDown;

		private MetroButton btnUp;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label11;

		private Panel plTuongTacTruocKhiNhanTin;

		private CheckBox ckbTuongTacKhiNhanTinComment;

		private CheckBox ckbTuongTacKhiNhanTinLike;

		private CheckBox ckbTuongTacKhiNhanTin;

		private Panel plTuongTacTruocKhiNhanTinComment;

		private RadioButton ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong;

		private RadioButton ckbTuongTacKhiNhanTinCommentNoiDung1Dong;

		private Label label12;

		private RichTextBox txtTuongTacKhiNhanTinComment;

		private Label label13;

		private Label label14;

		private RadioButton rbTuongTacSauKhiNhanTin;

		private RadioButton rbTuongTacTruocKhiNhanTin;

		private Label label15;

		private Label label16;

		private Label label10;

		private TextBox txtAnh;

		public fHDBuffTinNhanProfile(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDBuffTinNhanProfile").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"CauHinh\", \"MoTa\") VALUES ('HDBuffTinNhanProfile', '{  \"nudSoLuongUidFrom\": \"1\",  \"nudSoLuongUidTo\": \"3\", \"nudSoLuongAnhFrom\": \"1\", \"nudSoLuongAnhTo\": \"1\",  \"nudDelayFrom\": \"3\",  \"nudDelayTo\": \"5\",  \"txtUid\": \"\",  \"ckbNhanTinVanBan\": \"True\",  \"txtNoiDung\": \"hello\",  \"ckbSendAnh\": \"False\",  \"txtAnh\": \"\",  \"ckbTuDongXoaUid\": \"False\"}', 'Buff Tin nhắn Profile');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDBuffTinNhanProfile");
				jsonStringOrPathFile = tuongTac.Rows[0]["CauHinh"].ToString();
				id_TuongTac = tuongTac.Rows[0]["Id_TuongTac"].ToString();
				txtTenHanhDong.Text = Language.GetValue(tuongTac.Rows[0]["MoTa"].ToString());
				break;
			}
			case 1:
			{
				DataTable hanhDongById = InteractSQL.GetHanhDongById(id_HanhDong);
				jsonStringOrPathFile = hanhDongById.Rows[0]["CauHinh"].ToString();
				btnAdd.Text = Language.GetValue("Câ\u0323p nhâ\u0323t");
				txtTenHanhDong.Text = hanhDongById.Rows[0]["TenHanhDong"].ToString();
				break;
			}
			}
			setting = new JSON_Settings(jsonStringOrPathFile, isJsonString: true);
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(label49);
			Language.GetValue(label66);
			Language.GetValue(label5);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(lblStatusUid);
			Language.GetValue(label2);
			Language.GetValue(ckbTuDongXoaUid);
			Language.GetValue(ckbNhanTinVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(ckbSendAnh);
			Language.GetValue(label10);
			Language.GetValue(label3);
			Language.GetValue(label9);
			Language.GetValue(label4);
			Language.GetValue(ckbTuongTacKhiNhanTin);
			Language.GetValue(label15);
			Language.GetValue(rbTuongTacTruocKhiNhanTin);
			Language.GetValue(rbTuongTacSauKhiNhanTin);
			Language.GetValue(label16);
			Language.GetValue(label14);
			Language.GetValue(label13);
			Language.GetValue(label12);
			Language.GetValue(ckbTuongTacKhiNhanTinCommentNoiDung1Dong);
			Language.GetValue(ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudSoLuongUidFrom.Value = setting.GetValueInt("nudSoLuongUidFrom", 1);
				nudSoLuongUidTo.Value = setting.GetValueInt("nudSoLuongUidTo", 3);
				nudSoLuongAnhFrom.Value = setting.GetValueInt("nudSoLuongAnhFrom", 1);
				nudSoLuongAnhTo.Value = setting.GetValueInt("nudSoLuongAnhTo", 1);
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				txtUid.Text = setting.GetValue("txtUid");
				ckbNhanTinVanBan.Checked = setting.GetValueBool("ckbNhanTinVanBan");
				txtNoiDung.Text = setting.GetValue("txtNoiDung");
				ckbSendAnh.Checked = setting.GetValueBool("ckbSendAnh");
				txtAnh.Text = setting.GetValue("txtAnh");
				ckbTuongTacKhiNhanTin.Checked = setting.GetValueBool("ckbTuongTacKhiNhanTin");
				if (setting.GetValueInt("typeTuongTacKhiNhanTin") == 0)
				{
					rbTuongTacTruocKhiNhanTin.Checked = true;
				}
				else
				{
					rbTuongTacSauKhiNhanTin.Checked = true;
				}
				ckbTuongTacKhiNhanTinLike.Checked = setting.GetValueBool("ckbTuongTacKhiNhanTinLike");
				ckbTuongTacKhiNhanTinComment.Checked = setting.GetValueBool("ckbTuongTacKhiNhanTinComment");
				txtTuongTacKhiNhanTinComment.Text = setting.GetValue("txtTuongTacKhiNhanTinComment");
				if (setting.GetValueInt("typeNganCachComment") == 1)
				{
					ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Checked = true;
				}
				else
				{
					ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Checked = true;
				}
				ckbTuDongXoaUid.Checked = setting.GetValueBool("ckbTuDongXoaUid");
				if (setting.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
			}
			catch
			{
			}
			CheckedChangeFull();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string text = txtTenHanhDong.Text.Trim();
			if (text == "")
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!"), 3);
				return;
			}
			List<string> lst = txtUid.Lines.ToList();
			lst = MCommon.Common.RemoveEmptyItems(lst);
			if (lst.Count == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p danh sa\u0301ch Uid!"), 3);
				return;
			}
			if (ckbNhanTinVanBan.Checked)
			{
				lst = txtNoiDung.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p nô\u0323i dung tin nhắn!"), 3);
					return;
				}
			}
			if (ckbSendAnh.Checked && txtAnh.Text.Trim().Length == 0)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng chọn folder ảnh!"), 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudSoLuongUidFrom", nudSoLuongUidFrom.Value);
			jSON_Settings.Update("nudSoLuongUidTo", nudSoLuongUidTo.Value);
			jSON_Settings.Update("nudSoLuongAnhFrom", nudSoLuongAnhFrom.Value);
			jSON_Settings.Update("nudSoLuongAnhTo", nudSoLuongAnhTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("txtUid", txtUid.Text.Trim());
			jSON_Settings.Update("ckbNhanTinVanBan", ckbNhanTinVanBan.Checked);
			jSON_Settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			jSON_Settings.Update("ckbSendAnh", ckbSendAnh.Checked);
			jSON_Settings.Update("txtAnh", txtAnh.Text.Trim());
			jSON_Settings.Update("ckbTuDongXoaUid", ckbTuDongXoaUid.Checked);
			jSON_Settings.Update("ckbTuongTacKhiNhanTin", ckbTuongTacKhiNhanTin.Checked);
			if (rbTuongTacTruocKhiNhanTin.Checked)
			{
				jSON_Settings.Update("typeTuongTacKhiNhanTin", 0);
			}
			else
			{
				jSON_Settings.Update("typeTuongTacKhiNhanTin", 1);
			}
			jSON_Settings.Update("ckbTuongTacKhiNhanTinLike", ckbTuongTacKhiNhanTinLike.Checked);
			jSON_Settings.Update("ckbTuongTacKhiNhanTinComment", ckbTuongTacKhiNhanTinComment.Checked);
			jSON_Settings.Update("txtTuongTacKhiNhanTinComment", txtTuongTacKhiNhanTinComment.Text.Trim());
			int num = 0;
			if (ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Checked)
			{
				num = 1;
			}
			jSON_Settings.Update("typeNganCachComment", num);
			int num2 = 0;
			if (rbNganCachKyTu.Checked)
			{
				num2 = 1;
			}
			jSON_Settings.Update("typeNganCach", num2);
			string fullString = jSON_Settings.GetFullString();
			if (type == 0)
			{
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?")) == DialogResult.Yes)
				{
					if (InteractSQL.InsertHanhDong(id_KichBan, text, id_TuongTac, fullString))
					{
						isSave = true;
						Close();
					}
					else
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
					}
				}
			}
			else if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?")) == DialogResult.Yes)
			{
				if (InteractSQL.UpdateHanhDong(Id_HanhDong, text, fullString))
				{
					isSave = true;
					Close();
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			if (panel1.BorderStyle == BorderStyle.FixedSingle)
			{
				int num = 1;
				int num2 = 0;
				using Pen pen = new Pen(Color.DarkViolet, 1f);
				e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
			}
		}

		private void txtComment_Click(object sender, EventArgs e)
		{
		}

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void UpdateSoLuongBinhLuan()
		{
			try
			{
				List<string> list = new List<string>();
				list = ((!rbNganCachMoiDong.Checked) ? txtNoiDung.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : txtNoiDung.Lines.ToList());
				list = MCommon.Common.RemoveEmptyItems(list);
				lblStatus.Text = string.Format(Language.GetValue("Nội dung tin nhắn ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void CheckedChangeFull()
		{
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbTuongTacTruocKhiNhanTin_CheckedChanged(null, null);
			ckbTuongTacTruocKhiNhanTinComment_CheckedChanged(null, null);
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbNhanTinVanBan.Checked;
		}

		private void txtUid_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUid.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatusUid.Text = string.Format(Language.GetValue("Danh sa\u0301ch Uid ca\u0301 nhân cần nhắn tin ({0}):"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void ckbSendAnh_CheckedChanged(object sender, EventArgs e)
		{
			plAnh.Enabled = ckbSendAnh.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			txtAnh.Text = MCommon.Common.SelectFolder();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			plComment.Height = 235;
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			plComment.Height = 185;
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				btnUp.Visible = true;
				btnDown.Visible = true;
			}
		}

		private void ckbTuongTacTruocKhiNhanTin_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacTruocKhiNhanTin.Enabled = ckbTuongTacKhiNhanTin.Checked;
		}

		private void ckbTuongTacTruocKhiNhanTinComment_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacTruocKhiNhanTinComment.Enabled = ckbTuongTacKhiNhanTinComment.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDBuffTinNhanProfile));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plTuongTacTruocKhiNhanTin = new System.Windows.Forms.Panel();
			rbTuongTacSauKhiNhanTin = new System.Windows.Forms.RadioButton();
			ckbTuongTacKhiNhanTinComment = new System.Windows.Forms.CheckBox();
			rbTuongTacTruocKhiNhanTin = new System.Windows.Forms.RadioButton();
			label15 = new System.Windows.Forms.Label();
			ckbTuongTacKhiNhanTinLike = new System.Windows.Forms.CheckBox();
			label16 = new System.Windows.Forms.Label();
			plTuongTacTruocKhiNhanTinComment = new System.Windows.Forms.Panel();
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong = new System.Windows.Forms.RadioButton();
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong = new System.Windows.Forms.RadioButton();
			label12 = new System.Windows.Forms.Label();
			txtTuongTacKhiNhanTinComment = new System.Windows.Forms.RichTextBox();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			plComment = new System.Windows.Forms.Panel();
			btnDown = new MetroFramework.Controls.MetroButton();
			btnUp = new MetroFramework.Controls.MetroButton();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			label11 = new System.Windows.Forms.Label();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			plAnh = new System.Windows.Forms.Panel();
			label10 = new System.Windows.Forms.Label();
			txtAnh = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			nudSoLuongAnhFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongAnhTo = new System.Windows.Forms.NumericUpDown();
			ckbSendAnh = new System.Windows.Forms.CheckBox();
			txtUid = new System.Windows.Forms.RichTextBox();
			label2 = new System.Windows.Forms.Label();
			lblStatusUid = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			nudSoLuongUidFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			nudSoLuongUidTo = new System.Windows.Forms.NumericUpDown();
			label66 = new System.Windows.Forms.Label();
			ckbTuongTacKhiNhanTin = new System.Windows.Forms.CheckBox();
			ckbNhanTinVanBan = new System.Windows.Forms.CheckBox();
			ckbTuDongXoaUid = new System.Windows.Forms.CheckBox();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plTuongTacTruocKhiNhanTin.SuspendLayout();
			plTuongTacTruocKhiNhanTinComment.SuspendLayout();
			plComment.SuspendLayout();
			plAnh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			bunifuCards1.SuspendLayout();
			SuspendLayout();
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(1009, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Buff Tin nhắn Profile";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1009, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(978, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 77;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(plTuongTacTruocKhiNhanTin);
			panel1.Controls.Add(plComment);
			panel1.Controls.Add(plAnh);
			panel1.Controls.Add(ckbSendAnh);
			panel1.Controls.Add(txtUid);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(lblStatusUid);
			panel1.Controls.Add(label49);
			panel1.Controls.Add(nudSoLuongUidFrom);
			panel1.Controls.Add(label68);
			panel1.Controls.Add(nudSoLuongUidTo);
			panel1.Controls.Add(label66);
			panel1.Controls.Add(ckbTuongTacKhiNhanTin);
			panel1.Controls.Add(ckbNhanTinVanBan);
			panel1.Controls.Add(ckbTuDongXoaUid);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1012, 416);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plTuongTacTruocKhiNhanTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacTruocKhiNhanTin.Controls.Add(rbTuongTacSauKhiNhanTin);
			plTuongTacTruocKhiNhanTin.Controls.Add(ckbTuongTacKhiNhanTinComment);
			plTuongTacTruocKhiNhanTin.Controls.Add(rbTuongTacTruocKhiNhanTin);
			plTuongTacTruocKhiNhanTin.Controls.Add(label15);
			plTuongTacTruocKhiNhanTin.Controls.Add(ckbTuongTacKhiNhanTinLike);
			plTuongTacTruocKhiNhanTin.Controls.Add(label16);
			plTuongTacTruocKhiNhanTin.Controls.Add(plTuongTacTruocKhiNhanTinComment);
			plTuongTacTruocKhiNhanTin.Enabled = false;
			plTuongTacTruocKhiNhanTin.Location = new System.Drawing.Point(688, 75);
			plTuongTacTruocKhiNhanTin.Name = "plTuongTacTruocKhiNhanTin";
			plTuongTacTruocKhiNhanTin.Size = new System.Drawing.Size(297, 272);
			plTuongTacTruocKhiNhanTin.TabIndex = 163;
			rbTuongTacSauKhiNhanTin.AutoSize = true;
			rbTuongTacSauKhiNhanTin.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTuongTacSauKhiNhanTin.Location = new System.Drawing.Point(77, 28);
			rbTuongTacSauKhiNhanTin.Name = "rbTuongTacSauKhiNhanTin";
			rbTuongTacSauKhiNhanTin.Size = new System.Drawing.Size(178, 20);
			rbTuongTacSauKhiNhanTin.TabIndex = 105;
			rbTuongTacSauKhiNhanTin.Text = "Tương tác sau khi nhắn tin";
			rbTuongTacSauKhiNhanTin.UseVisualStyleBackColor = true;
			ckbTuongTacKhiNhanTinComment.AutoSize = true;
			ckbTuongTacKhiNhanTinComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacKhiNhanTinComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacKhiNhanTinComment.Location = new System.Drawing.Point(161, 52);
			ckbTuongTacKhiNhanTinComment.Name = "ckbTuongTacKhiNhanTinComment";
			ckbTuongTacKhiNhanTinComment.Size = new System.Drawing.Size(82, 20);
			ckbTuongTacKhiNhanTinComment.TabIndex = 96;
			ckbTuongTacKhiNhanTinComment.Text = "Comment";
			ckbTuongTacKhiNhanTinComment.UseVisualStyleBackColor = true;
			ckbTuongTacKhiNhanTinComment.CheckedChanged += new System.EventHandler(ckbTuongTacTruocKhiNhanTinComment_CheckedChanged);
			rbTuongTacTruocKhiNhanTin.AutoSize = true;
			rbTuongTacTruocKhiNhanTin.Checked = true;
			rbTuongTacTruocKhiNhanTin.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTuongTacTruocKhiNhanTin.Location = new System.Drawing.Point(77, 6);
			rbTuongTacTruocKhiNhanTin.Name = "rbTuongTacTruocKhiNhanTin";
			rbTuongTacTruocKhiNhanTin.Size = new System.Drawing.Size(188, 20);
			rbTuongTacTruocKhiNhanTin.TabIndex = 106;
			rbTuongTacTruocKhiNhanTin.TabStop = true;
			rbTuongTacTruocKhiNhanTin.Text = "Tương tác trước khi nhắn tin";
			rbTuongTacTruocKhiNhanTin.UseVisualStyleBackColor = true;
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label15.Location = new System.Drawing.Point(6, 8);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(65, 16);
			label15.TabIndex = 103;
			label15.Text = "Tùy chọn:";
			ckbTuongTacKhiNhanTinLike.AutoSize = true;
			ckbTuongTacKhiNhanTinLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacKhiNhanTinLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacKhiNhanTinLike.Location = new System.Drawing.Point(106, 52);
			ckbTuongTacKhiNhanTinLike.Name = "ckbTuongTacKhiNhanTinLike";
			ckbTuongTacKhiNhanTinLike.Size = new System.Drawing.Size(49, 20);
			ckbTuongTacKhiNhanTinLike.TabIndex = 95;
			ckbTuongTacKhiNhanTinLike.Text = "Like";
			ckbTuongTacKhiNhanTinLike.UseVisualStyleBackColor = true;
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label16.Location = new System.Drawing.Point(6, 53);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(94, 16);
			label16.TabIndex = 104;
			label16.Text = "Loa\u0323i tương ta\u0301c:";
			plTuongTacTruocKhiNhanTinComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacTruocKhiNhanTinComment.Controls.Add(ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong);
			plTuongTacTruocKhiNhanTinComment.Controls.Add(ckbTuongTacKhiNhanTinCommentNoiDung1Dong);
			plTuongTacTruocKhiNhanTinComment.Controls.Add(label12);
			plTuongTacTruocKhiNhanTinComment.Controls.Add(txtTuongTacKhiNhanTinComment);
			plTuongTacTruocKhiNhanTinComment.Controls.Add(label13);
			plTuongTacTruocKhiNhanTinComment.Controls.Add(label14);
			plTuongTacTruocKhiNhanTinComment.Location = new System.Drawing.Point(9, 75);
			plTuongTacTruocKhiNhanTinComment.Name = "plTuongTacTruocKhiNhanTinComment";
			plTuongTacTruocKhiNhanTinComment.Size = new System.Drawing.Size(281, 191);
			plTuongTacTruocKhiNhanTinComment.TabIndex = 101;
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.AutoSize = true;
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Location = new System.Drawing.Point(70, 164);
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Name = "ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong";
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Size = new System.Drawing.Size(203, 20);
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.TabIndex = 3;
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.Text = "Các nội dung ngăn cách bởi \"|\"";
			ckbTuongTacKhiNhanTinCommentNoiDungNhieuDong.UseVisualStyleBackColor = true;
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.AutoSize = true;
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Checked = true;
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Location = new System.Drawing.Point(70, 143);
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Name = "ckbTuongTacKhiNhanTinCommentNoiDung1Dong";
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Size = new System.Drawing.Size(171, 20);
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.TabIndex = 3;
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.TabStop = true;
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.Text = "Mỗi dòng là một nội dung";
			ckbTuongTacKhiNhanTinCommentNoiDung1Dong.UseVisualStyleBackColor = true;
			label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(5, 143);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(65, 16);
			label12.TabIndex = 2;
			label12.Text = "Tùy chọn:";
			txtTuongTacKhiNhanTinComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtTuongTacKhiNhanTinComment.Location = new System.Drawing.Point(7, 23);
			txtTuongTacKhiNhanTinComment.Name = "txtTuongTacKhiNhanTinComment";
			txtTuongTacKhiNhanTinComment.Size = new System.Drawing.Size(263, 97);
			txtTuongTacKhiNhanTinComment.TabIndex = 1;
			txtTuongTacKhiNhanTinComment.Text = "";
			txtTuongTacKhiNhanTinComment.WordWrap = false;
			label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(4, 123);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(268, 16);
			label13.TabIndex = 0;
			label13.Text = "(Spin nội dung {a|b|c} - [u]: Họ tên của UID)";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(3, 3);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(119, 16);
			label14.TabIndex = 0;
			label14.Text = "Nội dung bình luận:";
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(btnDown);
			plComment.Controls.Add(btnUp);
			plComment.Controls.Add(rbNganCachKyTu);
			plComment.Controls.Add(rbNganCachMoiDong);
			plComment.Controls.Add(label11);
			plComment.Controls.Add(txtNoiDung);
			plComment.Controls.Add(label8);
			plComment.Controls.Add(lblStatus);
			plComment.Location = new System.Drawing.Point(369, 75);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(281, 185);
			plComment.TabIndex = 10;
			btnDown.BackgroundImage = maxcare.Properties.Resources.icons8_expand_arrow_24px;
			btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDown.Location = new System.Drawing.Point(224, -1);
			btnDown.Name = "btnDown";
			btnDown.Size = new System.Drawing.Size(25, 25);
			btnDown.TabIndex = 11;
			btnDown.UseSelectable = true;
			btnDown.Visible = false;
			btnDown.Click += new System.EventHandler(btnDown_Click);
			btnUp.BackgroundImage = maxcare.Properties.Resources.icons8_collapse_arrow_24px;
			btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			btnUp.Location = new System.Drawing.Point(255, -1);
			btnUp.Name = "btnUp";
			btnUp.Size = new System.Drawing.Size(25, 25);
			btnUp.TabIndex = 12;
			btnUp.UseSelectable = true;
			btnUp.Visible = false;
			btnUp.Click += new System.EventHandler(btnUp_Click);
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(68, 209);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(203, 20);
			rbNganCachKyTu.TabIndex = 10;
			rbNganCachKyTu.Text = "Các nội dung ngăn cách bởi \"|\"";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(68, 188);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(171, 20);
			rbNganCachMoiDong.TabIndex = 9;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Mỗi dòng là một nội dung";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(3, 188);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(65, 16);
			label11.TabIndex = 8;
			label11.Text = "Tùy chọn:";
			txtNoiDung.Location = new System.Drawing.Point(7, 24);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(263, 137);
			txtNoiDung.TabIndex = 1;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtComment_TextChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 163);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(266, 16);
			label8.TabIndex = 0;
			label8.Text = "(Spin nội dung {a|b|c} - [u]: Họ tên của Uid)";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 3);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(134, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Nội dung tin nhắn (0):";
			plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plAnh.Controls.Add(label10);
			plAnh.Controls.Add(txtAnh);
			plAnh.Controls.Add(label3);
			plAnh.Controls.Add(label4);
			plAnh.Controls.Add(label9);
			plAnh.Controls.Add(nudSoLuongAnhFrom);
			plAnh.Controls.Add(nudSoLuongAnhTo);
			plAnh.Enabled = false;
			plAnh.Location = new System.Drawing.Point(369, 289);
			plAnh.Name = "plAnh";
			plAnh.Size = new System.Drawing.Size(281, 58);
			plAnh.TabIndex = 162;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(3, 6);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(138, 16);
			label10.TabIndex = 159;
			label10.Text = "Đường dẫn folder ảnh:";
			txtAnh.Location = new System.Drawing.Point(143, 3);
			txtAnh.Name = "txtAnh";
			txtAnh.Size = new System.Drawing.Size(133, 23);
			txtAnh.TabIndex = 158;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 31);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(104, 16);
			label3.TabIndex = 34;
			label3.Text = "Số ảnh/tin nhắn:";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(240, 31);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 16);
			label4.TabIndex = 36;
			label4.Text = "ảnh";
			label9.Location = new System.Drawing.Point(164, 31);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(29, 16);
			label9.TabIndex = 38;
			label9.Text = "đê\u0301n";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudSoLuongAnhFrom.Location = new System.Drawing.Point(118, 29);
			nudSoLuongAnhFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongAnhFrom.Name = "nudSoLuongAnhFrom";
			nudSoLuongAnhFrom.Size = new System.Drawing.Size(43, 23);
			nudSoLuongAnhFrom.TabIndex = 5;
			nudSoLuongAnhTo.Location = new System.Drawing.Point(195, 29);
			nudSoLuongAnhTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongAnhTo.Name = "nudSoLuongAnhTo";
			nudSoLuongAnhTo.Size = new System.Drawing.Size(43, 23);
			nudSoLuongAnhTo.TabIndex = 6;
			ckbSendAnh.AutoSize = true;
			ckbSendAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbSendAnh.Location = new System.Drawing.Point(351, 266);
			ckbSendAnh.Name = "ckbSendAnh";
			ckbSendAnh.Size = new System.Drawing.Size(71, 20);
			ckbSendAnh.TabIndex = 161;
			ckbSendAnh.Text = "Gửi ảnh";
			ckbSendAnh.UseVisualStyleBackColor = true;
			ckbSendAnh.CheckedChanged += new System.EventHandler(ckbSendAnh_CheckedChanged);
			txtUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUid.Location = new System.Drawing.Point(31, 154);
			txtUid.Name = "txtUid";
			txtUid.Size = new System.Drawing.Size(299, 152);
			txtUid.TabIndex = 117;
			txtUid.Text = "";
			txtUid.WordWrap = false;
			txtUid.TextChanged += new System.EventHandler(txtUid_TextChanged);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(230, 308);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(103, 16);
			label2.TabIndex = 115;
			label2.Text = "(Mỗi Uid 1 dòng)";
			lblStatusUid.AutoSize = true;
			lblStatusUid.Location = new System.Drawing.Point(28, 135);
			lblStatusUid.Name = "lblStatusUid";
			lblStatusUid.Size = new System.Drawing.Size(238, 16);
			lblStatusUid.TabIndex = 116;
			lblStatusUid.Text = "Danh sa\u0301ch Uid ca\u0301 nhân cần nhắn tin (0):";
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(27, 81);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(102, 16);
			label49.TabIndex = 92;
			label49.Text = "Sô\u0301 lươ\u0323ng Uid(?):";
			toolTip1.SetToolTip(label49, "Mỗi tài khoản chỉ nhắn tin được tối đa 50 người tại 1 thời điểm!");
			nudSoLuongUidFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidFrom.Location = new System.Drawing.Point(135, 79);
			nudSoLuongUidFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidFrom.Name = "nudSoLuongUidFrom";
			nudSoLuongUidFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidFrom.TabIndex = 1;
			nudSoLuongUidFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(290, 81);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(26, 16);
			label68.TabIndex = 99;
			label68.Text = "Uid";
			nudSoLuongUidTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudSoLuongUidTo.Location = new System.Drawing.Point(232, 79);
			nudSoLuongUidTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongUidTo.Name = "nudSoLuongUidTo";
			nudSoLuongUidTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongUidTo.TabIndex = 2;
			nudSoLuongUidTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(197, 81);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 105;
			label66.Text = "đê\u0301n";
			label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbTuongTacKhiNhanTin.AutoSize = true;
			ckbTuongTacKhiNhanTin.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacKhiNhanTin.Location = new System.Drawing.Point(670, 51);
			ckbTuongTacKhiNhanTin.Name = "ckbTuongTacKhiNhanTin";
			ckbTuongTacKhiNhanTin.Size = new System.Drawing.Size(155, 20);
			ckbTuongTacKhiNhanTin.TabIndex = 9;
			ckbTuongTacKhiNhanTin.Text = "Tương tác khi nhắn tin";
			ckbTuongTacKhiNhanTin.UseVisualStyleBackColor = true;
			ckbTuongTacKhiNhanTin.CheckedChanged += new System.EventHandler(ckbTuongTacTruocKhiNhanTin_CheckedChanged);
			ckbNhanTinVanBan.AutoSize = true;
			ckbNhanTinVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbNhanTinVanBan.Location = new System.Drawing.Point(351, 51);
			ckbNhanTinVanBan.Name = "ckbNhanTinVanBan";
			ckbNhanTinVanBan.Size = new System.Drawing.Size(123, 20);
			ckbNhanTinVanBan.TabIndex = 9;
			ckbNhanTinVanBan.Text = "Nhắn tin văn bản";
			ckbNhanTinVanBan.UseVisualStyleBackColor = true;
			ckbNhanTinVanBan.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbTuDongXoaUid.AutoSize = true;
			ckbTuDongXoaUid.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuDongXoaUid.Location = new System.Drawing.Point(31, 324);
			ckbTuDongXoaUid.Name = "ckbTuDongXoaUid";
			ckbTuDongXoaUid.Size = new System.Drawing.Size(296, 20);
			ckbTuDongXoaUid.TabIndex = 8;
			ckbTuDongXoaUid.Text = "Tự động xóa Uid đã nhắn tin (Không trùng UID)";
			ckbTuDongXoaUid.UseVisualStyleBackColor = true;
			nudDelayTo.Location = new System.Drawing.Point(232, 108);
			nudDelayTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 6;
			nudDelayFrom.Location = new System.Drawing.Point(135, 108);
			nudDelayFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 5;
			txtTenHanhDong.Location = new System.Drawing.Point(135, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(195, 23);
			txtTenHanhDong.TabIndex = 0;
			label7.Location = new System.Drawing.Point(197, 110);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(29, 16);
			label7.TabIndex = 38;
			label7.Text = "đê\u0301n";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(290, 110);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(31, 16);
			label6.TabIndex = 36;
			label6.Text = "giây";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(27, 110);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(90, 16);
			label5.TabIndex = 34;
			label5.Text = "Thơ\u0300i gian chơ\u0300:";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(27, 52);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(99, 16);
			label1.TabIndex = 31;
			label1.Text = "Tên ha\u0300nh đô\u0323ng:";
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(513, 367);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 12;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(406, 367);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 11;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.DarkViolet;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(1009, 37);
			bunifuCards1.TabIndex = 28;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 20000;
			toolTip1.InitialDelay = 0;
			toolTip1.ReshowDelay = 0;
			toolTip1.ToolTipTitle = "Chú ý";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1012, 416);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDBuffTinNhanProfile";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plTuongTacTruocKhiNhanTin.ResumeLayout(false);
			plTuongTacTruocKhiNhanTin.PerformLayout();
			plTuongTacTruocKhiNhanTinComment.ResumeLayout(false);
			plTuongTacTruocKhiNhanTinComment.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			plAnh.ResumeLayout(false);
			plAnh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongUidTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
