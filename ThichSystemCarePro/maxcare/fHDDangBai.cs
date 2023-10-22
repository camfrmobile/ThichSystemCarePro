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
	public class fHDDangBai : Form
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

		private TextBox txtTenHanhDong;

		private Label label1;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private Button button1;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private CheckBox ckbAnh;

		private CheckBox ckbVanBan;

		private Panel plVanBan;

		private Label lblStatus;

		private Panel plAnh;

		private TextBox txtPathAnh;

		private Label label2;

		private Label label3;

		private Panel plVideo;

		private TextBox txtPathVideo;

		private Label label5;

		private Label label6;

		private Label label7;

		private NumericUpDown nudSoLuongAnhFrom;

		private Label label4;

		private CheckBox ckbVideo;

		private RichTextBox txtNoiDung;

		private MetroButton btnDown;

		private MetroButton btnUp;

		private CheckBox ckbUseBackground;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label20;

		private Label label19;

		private Label label15;

		private GroupBox groupBox2;

		private Panel plDangBaiLenPage;

		private Label label21;

		private Label label22;

		private NumericUpDown nudCountPageTo;

		private Label label23;

		private NumericUpDown nudCountPageFrom;

		private Panel plDangBaiLenNhom;

		private NumericUpDown nudCountGroupTo;

		private NumericUpDown nudCountGroupFrom;

		private Label label24;

		private Label label25;

		private Label label26;

		private CheckBox ckbDangBaiLenPage;

		private CheckBox ckbDangBaiLenNhom;

		private CheckBox ckbDangBaiLenTuong;

		private NumericUpDown nudSoLuongVideoTo;

		private NumericUpDown nudSoLuongVideoFrom;

		private Label label11;

		private NumericUpDown nudSoLuongAnhTo;

		private Label label10;

		private Button button3;

		private Button button2;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private Label label8;

		private CheckBox ckbOnlyDangNhomKhongKiemDuyet;

		public fHDDangBai(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			string text = base.Name.Substring(1);
			if (InteractSQL.GetTuongTac("", text).Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\",\"MoTa\") VALUES ('" + text + "', 'Đăng bài');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", text);
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
			Language.GetValue(label15);
			Language.GetValue(label20);
			Language.GetValue(label19);
			Language.GetValue(groupBox2);
			Language.GetValue(ckbDangBaiLenTuong);
			Language.GetValue(ckbDangBaiLenNhom);
			Language.GetValue(label26);
			Language.GetValue(label24);
			Language.GetValue(label25);
			Language.GetValue(ckbOnlyDangNhomKhongKiemDuyet);
			Language.GetValue(ckbDangBaiLenPage);
			Language.GetValue(label21);
			Language.GetValue(label23);
			Language.GetValue(label22);
			Language.GetValue(ckbVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(ckbUseBackground);
			Language.GetValue(ckbAnh);
			Language.GetValue(label3);
			Language.GetValue(label2);
			Language.GetValue(label10);
			Language.GetValue(label4);
			Language.GetValue(ckbVideo);
			Language.GetValue(label7);
			Language.GetValue(label6);
			Language.GetValue(label11);
			Language.GetValue(label5);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(rbNganCachKyTu);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				ckbDangBaiLenTuong.Checked = setting.GetValueBool("ckbDangBaiLenTuong");
				ckbDangBaiLenNhom.Checked = setting.GetValueBool("ckbDangBaiLenNhom");
				ckbOnlyDangNhomKhongKiemDuyet.Checked = setting.GetValueBool("ckbOnlyDangNhomKhongKiemDuyet");
				nudCountGroupFrom.Value = setting.GetValueInt("nudCountGroupFrom", 1);
				nudCountGroupTo.Value = setting.GetValueInt("nudCountGroupTo", 1);
				ckbDangBaiLenPage.Checked = setting.GetValueBool("ckbDangBaiLenPage");
				nudCountPageFrom.Value = setting.GetValueInt("nudCountPageFrom", 1);
				nudCountPageTo.Value = setting.GetValueInt("nudCountPageTo", 1);
				ckbVanBan.Checked = setting.GetValueBool("ckbVanBan");
				ckbUseBackground.Checked = setting.GetValueBool("ckbUseBackground");
				txtNoiDung.Text = setting.GetValue("txtNoiDung");
				ckbAnh.Checked = setting.GetValueBool("ckbAnh");
				ckbVideo.Checked = setting.GetValueBool("ckbVideo");
				nudSoLuongAnhFrom.Value = setting.GetValueInt("nudSoLuongAnhFrom", 1);
				nudSoLuongAnhTo.Value = setting.GetValueInt("nudSoLuongAnhTo", 1);
				nudSoLuongVideoFrom.Value = setting.GetValueInt("nudSoLuongVideoFrom", 1);
				nudSoLuongVideoTo.Value = setting.GetValueInt("nudSoLuongVideoTo", 1);
				txtPathAnh.Text = setting.GetValue("txtPathAnh");
				txtPathVideo.Text = setting.GetValue("txtPathVideo");
				if (setting.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
			}
			catch (Exception)
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
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("ckbDangBaiLenTuong", ckbDangBaiLenTuong.Checked);
			jSON_Settings.Update("ckbDangBaiLenNhom", ckbDangBaiLenNhom.Checked);
			jSON_Settings.Update("ckbOnlyDangNhomKhongKiemDuyet", ckbOnlyDangNhomKhongKiemDuyet.Checked);
			jSON_Settings.Update("nudCountGroupFrom", nudCountGroupFrom.Value);
			jSON_Settings.Update("nudCountGroupTo", nudCountGroupTo.Value);
			jSON_Settings.Update("ckbDangBaiLenPage", ckbDangBaiLenPage.Checked);
			jSON_Settings.Update("nudCountPageFrom", nudCountPageFrom.Value);
			jSON_Settings.Update("nudCountPageTo", nudCountPageTo.Value);
			jSON_Settings.Update("ckbVanBan", ckbVanBan.Checked);
			jSON_Settings.Update("ckbUseBackground", ckbUseBackground.Checked);
			jSON_Settings.Update("ckbAnh", ckbAnh.Checked);
			jSON_Settings.Update("ckbVideo", ckbVideo.Checked);
			jSON_Settings.Update("nudSoLuongAnhFrom", nudSoLuongAnhFrom.Value);
			jSON_Settings.Update("nudSoLuongAnhTo", nudSoLuongAnhTo.Value);
			jSON_Settings.Update("nudSoLuongVideoFrom", nudSoLuongVideoFrom.Value);
			jSON_Settings.Update("nudSoLuongVideoTo", nudSoLuongVideoTo.Value);
			jSON_Settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			jSON_Settings.Update("txtPathAnh", txtPathAnh.Text.Trim());
			jSON_Settings.Update("txtPathVideo", txtPathVideo.Text.Trim());
			int num = 0;
			if (rbNganCachKyTu.Checked)
			{
				num = 1;
			}
			jSON_Settings.Update("typeNganCach", num);
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

		private void CheckedChangeFull()
		{
			ckbDangBaiLenNhom_CheckedChanged(null, null);
			ckbDangBaiLenPage_CheckedChanged(null, null);
			ckbVanBan_CheckedChanged(null, null);
			ckbAnh_CheckedChanged(null, null);
			ckbVideo_CheckedChanged(null, null);
		}

		private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
			if (!ckbVanBan.Checked)
			{
				ckbUseBackground.Checked = false;
			}
		}

		private void ckbAnh_CheckedChanged(object sender, EventArgs e)
		{
			plAnh.Enabled = ckbAnh.Checked;
			if (ckbAnh.Checked)
			{
				ckbUseBackground.Checked = false;
			}
		}

		private void ckbVideo_CheckedChanged(object sender, EventArgs e)
		{
			plVideo.Enabled = ckbVideo.Checked;
			if (ckbVideo.Checked)
			{
				ckbUseBackground.Checked = false;
			}
		}

		private void txtNoiDung_TextChanged(object sender, EventArgs e)
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
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch nô\u0323i dung ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			txtPathAnh.Text = MCommon.Common.SelectFolder();
		}

		private void metroButton2_Click(object sender, EventArgs e)
		{
			txtPathVideo.Text = MCommon.Common.SelectFolder();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				btnUp.Visible = true;
				btnDown.Visible = true;
			}
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			plVanBan.Height = 216;
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			plVanBan.Height = 169;
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void ckbUseBackground_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbDangBaiLenNhom_CheckedChanged(object sender, EventArgs e)
		{
			plDangBaiLenNhom.Enabled = ckbDangBaiLenNhom.Checked;
		}

		private void ckbDangBaiLenPage_CheckedChanged(object sender, EventArgs e)
		{
			plDangBaiLenPage.Enabled = ckbDangBaiLenPage.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
			txtNoiDung.Focus();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
			txtNoiDung.Focus();
		}

		private void rbNganCachMoiDong_CheckedChanged_1(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged_1(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fHDDangBai));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			groupBox2 = new System.Windows.Forms.GroupBox();
			plDangBaiLenPage = new System.Windows.Forms.Panel();
			label21 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			nudCountPageTo = new System.Windows.Forms.NumericUpDown();
			label23 = new System.Windows.Forms.Label();
			nudCountPageFrom = new System.Windows.Forms.NumericUpDown();
			plDangBaiLenNhom = new System.Windows.Forms.Panel();
			ckbOnlyDangNhomKhongKiemDuyet = new System.Windows.Forms.CheckBox();
			nudCountGroupTo = new System.Windows.Forms.NumericUpDown();
			nudCountGroupFrom = new System.Windows.Forms.NumericUpDown();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			ckbDangBaiLenPage = new System.Windows.Forms.CheckBox();
			ckbDangBaiLenNhom = new System.Windows.Forms.CheckBox();
			ckbDangBaiLenTuong = new System.Windows.Forms.CheckBox();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label20 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			plVanBan = new System.Windows.Forms.Panel();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			btnDown = new MetroFramework.Controls.MetroButton();
			btnUp = new MetroFramework.Controls.MetroButton();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			lblStatus = new System.Windows.Forms.Label();
			btnAdd = new System.Windows.Forms.Button();
			plVideo = new System.Windows.Forms.Panel();
			nudSoLuongVideoTo = new System.Windows.Forms.NumericUpDown();
			txtPathVideo = new System.Windows.Forms.TextBox();
			nudSoLuongVideoFrom = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			plAnh = new System.Windows.Forms.Panel();
			nudSoLuongAnhTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongAnhFrom = new System.Windows.Forms.NumericUpDown();
			txtPathAnh = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			ckbVideo = new System.Windows.Forms.CheckBox();
			ckbUseBackground = new System.Windows.Forms.CheckBox();
			ckbAnh = new System.Windows.Forms.CheckBox();
			ckbVanBan = new System.Windows.Forms.CheckBox();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox2.SuspendLayout();
			plDangBaiLenPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountPageTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountPageFrom).BeginInit();
			plDangBaiLenNhom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			plVanBan.SuspendLayout();
			plVideo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongVideoTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongVideoFrom).BeginInit();
			plAnh.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(680, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Đăng bài";
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
			pnlHeader.Size = new System.Drawing.Size(680, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(649, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 0;
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
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(label20);
			panel1.Controls.Add(label19);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(plVanBan);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(plVideo);
			panel1.Controls.Add(plAnh);
			panel1.Controls.Add(ckbVideo);
			panel1.Controls.Add(ckbUseBackground);
			panel1.Controls.Add(ckbAnh);
			panel1.Controls.Add(ckbVanBan);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(683, 504);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox2.Controls.Add(plDangBaiLenPage);
			groupBox2.Controls.Add(plDangBaiLenNhom);
			groupBox2.Controls.Add(ckbDangBaiLenPage);
			groupBox2.Controls.Add(ckbDangBaiLenNhom);
			groupBox2.Controls.Add(ckbDangBaiLenTuong);
			groupBox2.Location = new System.Drawing.Point(30, 107);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(617, 145);
			groupBox2.TabIndex = 62;
			groupBox2.TabStop = false;
			groupBox2.Text = "Tùy chọn đăng";
			plDangBaiLenPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangBaiLenPage.Controls.Add(label21);
			plDangBaiLenPage.Controls.Add(label22);
			plDangBaiLenPage.Controls.Add(nudCountPageTo);
			plDangBaiLenPage.Controls.Add(label23);
			plDangBaiLenPage.Controls.Add(nudCountPageFrom);
			plDangBaiLenPage.Location = new System.Drawing.Point(157, 112);
			plDangBaiLenPage.Name = "plDangBaiLenPage";
			plDangBaiLenPage.Size = new System.Drawing.Size(310, 27);
			plDangBaiLenPage.TabIndex = 1;
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(3, 3);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(96, 16);
			label21.TabIndex = 49;
			label21.Text = "Số lượng page:";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(261, 3);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(36, 16);
			label22.TabIndex = 50;
			label22.Text = "page";
			nudCountPageTo.Location = new System.Drawing.Point(205, 1);
			nudCountPageTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountPageTo.Name = "nudCountPageTo";
			nudCountPageTo.Size = new System.Drawing.Size(56, 23);
			nudCountPageTo.TabIndex = 48;
			label23.Location = new System.Drawing.Point(170, 3);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(29, 16);
			label23.TabIndex = 51;
			label23.Text = "đê\u0301n";
			label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudCountPageFrom.Location = new System.Drawing.Point(108, 1);
			nudCountPageFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountPageFrom.Name = "nudCountPageFrom";
			nudCountPageFrom.Size = new System.Drawing.Size(56, 23);
			nudCountPageFrom.TabIndex = 47;
			plDangBaiLenNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangBaiLenNhom.Controls.Add(ckbOnlyDangNhomKhongKiemDuyet);
			plDangBaiLenNhom.Controls.Add(nudCountGroupTo);
			plDangBaiLenNhom.Controls.Add(nudCountGroupFrom);
			plDangBaiLenNhom.Controls.Add(label24);
			plDangBaiLenNhom.Controls.Add(label25);
			plDangBaiLenNhom.Controls.Add(label26);
			plDangBaiLenNhom.Location = new System.Drawing.Point(157, 52);
			plDangBaiLenNhom.Name = "plDangBaiLenNhom";
			plDangBaiLenNhom.Size = new System.Drawing.Size(310, 54);
			plDangBaiLenNhom.TabIndex = 1;
			ckbOnlyDangNhomKhongKiemDuyet.AutoSize = true;
			ckbOnlyDangNhomKhongKiemDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbOnlyDangNhomKhongKiemDuyet.Location = new System.Drawing.Point(6, 30);
			ckbOnlyDangNhomKhongKiemDuyet.Name = "ckbOnlyDangNhomKhongKiemDuyet";
			ckbOnlyDangNhomKhongKiemDuyet.Size = new System.Drawing.Size(217, 20);
			ckbOnlyDangNhomKhongKiemDuyet.TabIndex = 2;
			ckbOnlyDangNhomKhongKiemDuyet.Text = "Chỉ đăng nhóm không kiểm duyệt";
			ckbOnlyDangNhomKhongKiemDuyet.UseVisualStyleBackColor = true;
			nudCountGroupTo.Location = new System.Drawing.Point(205, 5);
			nudCountGroupTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountGroupTo.Name = "nudCountGroupTo";
			nudCountGroupTo.Size = new System.Drawing.Size(56, 23);
			nudCountGroupTo.TabIndex = 53;
			nudCountGroupFrom.Location = new System.Drawing.Point(108, 5);
			nudCountGroupFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountGroupFrom.Name = "nudCountGroupFrom";
			nudCountGroupFrom.Size = new System.Drawing.Size(56, 23);
			nudCountGroupFrom.TabIndex = 52;
			label24.Location = new System.Drawing.Point(170, 7);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(29, 16);
			label24.TabIndex = 56;
			label24.Text = "đê\u0301n";
			label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(261, 7);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(40, 16);
			label25.TabIndex = 55;
			label25.Text = "nhóm";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(3, 7);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(100, 16);
			label26.TabIndex = 54;
			label26.Text = "Số lượng nhóm:";
			ckbDangBaiLenPage.AutoSize = true;
			ckbDangBaiLenPage.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDangBaiLenPage.Location = new System.Drawing.Point(11, 114);
			ckbDangBaiLenPage.Name = "ckbDangBaiLenPage";
			ckbDangBaiLenPage.Size = new System.Drawing.Size(131, 20);
			ckbDangBaiLenPage.TabIndex = 0;
			ckbDangBaiLenPage.Text = "Đăng bài lên page";
			ckbDangBaiLenPage.UseVisualStyleBackColor = true;
			ckbDangBaiLenPage.CheckedChanged += new System.EventHandler(ckbDangBaiLenPage_CheckedChanged);
			ckbDangBaiLenNhom.AutoSize = true;
			ckbDangBaiLenNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDangBaiLenNhom.Location = new System.Drawing.Point(11, 54);
			ckbDangBaiLenNhom.Name = "ckbDangBaiLenNhom";
			ckbDangBaiLenNhom.Size = new System.Drawing.Size(135, 20);
			ckbDangBaiLenNhom.TabIndex = 0;
			ckbDangBaiLenNhom.Text = "Đăng bài lên nhóm";
			ckbDangBaiLenNhom.UseVisualStyleBackColor = true;
			ckbDangBaiLenNhom.CheckedChanged += new System.EventHandler(ckbDangBaiLenNhom_CheckedChanged);
			ckbDangBaiLenTuong.AutoSize = true;
			ckbDangBaiLenTuong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbDangBaiLenTuong.Location = new System.Drawing.Point(11, 23);
			ckbDangBaiLenTuong.Name = "ckbDangBaiLenTuong";
			ckbDangBaiLenTuong.Size = new System.Drawing.Size(136, 20);
			ckbDangBaiLenTuong.TabIndex = 0;
			ckbDangBaiLenTuong.Text = "Đăng bài lên tường";
			ckbDangBaiLenTuong.UseVisualStyleBackColor = true;
			nudDelayTo.Location = new System.Drawing.Point(238, 79);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 58;
			nudDelayFrom.Location = new System.Drawing.Point(141, 79);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 57;
			label20.Location = new System.Drawing.Point(203, 81);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(29, 16);
			label20.TabIndex = 61;
			label20.Text = "đê\u0301n";
			label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(295, 81);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(31, 16);
			label19.TabIndex = 60;
			label19.Text = "giây";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(27, 81);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(117, 16);
			label15.TabIndex = 59;
			label15.Text = "Khoảng cách đăng:";
			plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVanBan.Controls.Add(button3);
			plVanBan.Controls.Add(button2);
			plVanBan.Controls.Add(rbNganCachKyTu);
			plVanBan.Controls.Add(rbNganCachMoiDong);
			plVanBan.Controls.Add(label9);
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(btnDown);
			plVanBan.Controls.Add(btnUp);
			plVanBan.Controls.Add(txtNoiDung);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Location = new System.Drawing.Point(47, 279);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(278, 169);
			plVanBan.TabIndex = 33;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(230, 189);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 44;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(230, 166);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 45;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(71, 189);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 42;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged_1);
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(71, 168);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 43;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged_1);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(6, 168);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 41;
			label9.Text = "Tùy chọn:";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(5, 147);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(144, 16);
			label8.TabIndex = 40;
			label8.Text = "(Spin nội dung {a|b|c})";
			btnDown.BackgroundImage = maxcare.Properties.Resources.icons8_expand_arrow_24px;
			btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDown.Location = new System.Drawing.Point(221, -1);
			btnDown.Name = "btnDown";
			btnDown.Size = new System.Drawing.Size(25, 25);
			btnDown.TabIndex = 38;
			btnDown.UseSelectable = true;
			btnDown.Click += new System.EventHandler(btnDown_Click);
			btnUp.BackgroundImage = maxcare.Properties.Resources.icons8_collapse_arrow_24px;
			btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			btnUp.Location = new System.Drawing.Point(252, -1);
			btnUp.Name = "btnUp";
			btnUp.Size = new System.Drawing.Size(25, 25);
			btnUp.TabIndex = 39;
			btnUp.UseSelectable = true;
			btnUp.Click += new System.EventHandler(btnUp_Click);
			txtNoiDung.Location = new System.Drawing.Point(7, 24);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(263, 119);
			txtNoiDung.TabIndex = 34;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged);
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(146, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(245, 462);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			plVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVideo.Controls.Add(nudSoLuongVideoTo);
			plVideo.Controls.Add(txtPathVideo);
			plVideo.Controls.Add(nudSoLuongVideoFrom);
			plVideo.Controls.Add(label5);
			plVideo.Controls.Add(label11);
			plVideo.Controls.Add(label6);
			plVideo.Controls.Add(label7);
			plVideo.Location = new System.Drawing.Point(369, 390);
			plVideo.Name = "plVideo";
			plVideo.Size = new System.Drawing.Size(278, 58);
			plVideo.TabIndex = 33;
			nudSoLuongVideoTo.Location = new System.Drawing.Point(196, 29);
			nudSoLuongVideoTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongVideoTo.Name = "nudSoLuongVideoTo";
			nudSoLuongVideoTo.Size = new System.Drawing.Size(45, 23);
			nudSoLuongVideoTo.TabIndex = 3;
			txtPathVideo.Location = new System.Drawing.Point(97, 2);
			txtPathVideo.Name = "txtPathVideo";
			txtPathVideo.Size = new System.Drawing.Size(177, 23);
			txtPathVideo.TabIndex = 1;
			nudSoLuongVideoFrom.Location = new System.Drawing.Point(118, 29);
			nudSoLuongVideoFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongVideoFrom.Name = "nudSoLuongVideoFrom";
			nudSoLuongVideoFrom.Size = new System.Drawing.Size(45, 23);
			nudSoLuongVideoFrom.TabIndex = 3;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(241, 31);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(38, 16);
			label5.TabIndex = 0;
			label5.Text = "video";
			label11.Location = new System.Drawing.Point(165, 31);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(29, 16);
			label11.TabIndex = 0;
			label11.Text = "đến";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 31);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(120, 16);
			label6.TabIndex = 0;
			label6.Text = "Sô\u0301 lươ\u0323ng video/bài:";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(3, 5);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(98, 16);
			label7.TabIndex = 0;
			label7.Text = "Thư mu\u0323c video:";
			plAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plAnh.Controls.Add(nudSoLuongAnhTo);
			plAnh.Controls.Add(nudSoLuongAnhFrom);
			plAnh.Controls.Add(txtPathAnh);
			plAnh.Controls.Add(label10);
			plAnh.Controls.Add(label4);
			plAnh.Controls.Add(label2);
			plAnh.Controls.Add(label3);
			plAnh.Location = new System.Drawing.Point(372, 304);
			plAnh.Name = "plAnh";
			plAnh.Size = new System.Drawing.Size(275, 58);
			plAnh.TabIndex = 33;
			nudSoLuongAnhTo.Location = new System.Drawing.Point(191, 29);
			nudSoLuongAnhTo.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongAnhTo.Name = "nudSoLuongAnhTo";
			nudSoLuongAnhTo.Size = new System.Drawing.Size(45, 23);
			nudSoLuongAnhTo.TabIndex = 3;
			nudSoLuongAnhFrom.Location = new System.Drawing.Point(113, 29);
			nudSoLuongAnhFrom.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			nudSoLuongAnhFrom.Name = "nudSoLuongAnhFrom";
			nudSoLuongAnhFrom.Size = new System.Drawing.Size(45, 23);
			nudSoLuongAnhFrom.TabIndex = 3;
			txtPathAnh.Location = new System.Drawing.Point(94, 2);
			txtPathAnh.Name = "txtPathAnh";
			txtPathAnh.Size = new System.Drawing.Size(177, 23);
			txtPathAnh.TabIndex = 1;
			label10.Location = new System.Drawing.Point(160, 31);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 0;
			label10.Text = "đến";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(236, 31);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 16);
			label4.TabIndex = 0;
			label4.Text = "a\u0309nh";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 31);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(111, 16);
			label2.TabIndex = 0;
			label2.Text = "Sô\u0301 lươ\u0323ng a\u0309nh/bài:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 5);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(89, 16);
			label3.TabIndex = 0;
			label3.Text = "Thư mu\u0323c ảnh:";
			ckbVideo.AutoSize = true;
			ckbVideo.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVideo.Location = new System.Drawing.Point(355, 368);
			ckbVideo.Name = "ckbVideo";
			ckbVideo.Size = new System.Drawing.Size(59, 20);
			ckbVideo.TabIndex = 32;
			ckbVideo.Text = "Video";
			ckbVideo.UseVisualStyleBackColor = true;
			ckbVideo.CheckedChanged += new System.EventHandler(ckbVideo_CheckedChanged);
			ckbUseBackground.AutoSize = true;
			ckbUseBackground.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbUseBackground.Location = new System.Drawing.Point(355, 255);
			ckbUseBackground.Name = "ckbUseBackground";
			ckbUseBackground.Size = new System.Drawing.Size(145, 20);
			ckbUseBackground.TabIndex = 32;
			ckbUseBackground.Text = "Sử dụng Background";
			ckbUseBackground.UseVisualStyleBackColor = true;
			ckbUseBackground.CheckedChanged += new System.EventHandler(ckbUseBackground_CheckedChanged);
			ckbAnh.AutoSize = true;
			ckbAnh.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbAnh.Location = new System.Drawing.Point(355, 279);
			ckbAnh.Name = "ckbAnh";
			ckbAnh.Size = new System.Drawing.Size(49, 20);
			ckbAnh.TabIndex = 32;
			ckbAnh.Text = "A\u0309nh";
			ckbAnh.UseVisualStyleBackColor = true;
			ckbAnh.CheckedChanged += new System.EventHandler(ckbAnh_CheckedChanged);
			ckbVanBan.AutoSize = true;
			ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVanBan.Location = new System.Drawing.Point(30, 255);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(74, 20);
			ckbVanBan.TabIndex = 32;
			ckbVanBan.Text = "Văn ba\u0309n";
			ckbVanBan.UseVisualStyleBackColor = true;
			ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
			txtTenHanhDong.Location = new System.Drawing.Point(141, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(193, 23);
			txtTenHanhDong.TabIndex = 0;
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
			btnCancel.Location = new System.Drawing.Point(344, 462);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
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
			bunifuCards1.Size = new System.Drawing.Size(680, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(683, 504);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDDangBai";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			plDangBaiLenPage.ResumeLayout(false);
			plDangBaiLenPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountPageTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountPageFrom).EndInit();
			plDangBaiLenNhom.ResumeLayout(false);
			plDangBaiLenNhom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			plVanBan.ResumeLayout(false);
			plVanBan.PerformLayout();
			plVideo.ResumeLayout(false);
			plVideo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongVideoTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongVideoFrom).EndInit();
			plAnh.ResumeLayout(false);
			plAnh.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongAnhFrom).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
