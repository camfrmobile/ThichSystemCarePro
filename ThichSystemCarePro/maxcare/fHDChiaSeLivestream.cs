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
	public class fHDChiaSeLivestream : Form
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

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private CheckBox ckbVanBan;

		private Panel plVanBan;

		private Label label8;

		private Label lblStatus;

		private RadioButton rbNganCachKyTu;

		private RadioButton rbNganCachMoiDong;

		private Label label9;

		private MetroButton btnDown;

		private MetroButton btnUp;

		private Button btnMinimize;

		private GroupBox groupBox1;

		private NumericUpDown nudDelayTo;

		private NumericUpDown nudDelayFrom;

		private Label label15;

		private Label label14;

		private Label label13;

		private GroupBox groupBox2;

		private Panel plDangBaiLenNhom;

		private CheckBox ckbChiaSeLenNhom;

		private CheckBox ckbChiaSeLenTuong;

		private NumericUpDown nudCountGroupTo;

		private NumericUpDown nudCountGroupFrom;

		private Label label16;

		private Label label17;

		private Label label18;

		private Label label2;

		private TextBox txtLinkChiaSe;

		private RichTextBox txtNoiDung;

		private Panel plTuongTacLivestream;

		private CheckBox ckbTuongTacLivestream;

		private Panel plComment;

		private Panel plBinhLuanNhieuLan;

		private NumericUpDown nudBinhLuanNhieuLanDelayTo;

		private Label lblmc1;

		private NumericUpDown nudBinhLuanNhieuLanDelayFrom;

		private Label label5;

		private Label label6;

		private CheckBox ckbBinhLuanNhieuLan;

		private Label label3;

		private TextBox txtComment;

		private Label label4;

		private Panel plInteract;

		private Label label25;

		private Label label26;

		private Label label28;

		private Label label29;

		private Label label30;

		private CheckBox ckbGian;

		private CheckBox ckbBuon;

		private CheckBox ckbWow;

		private CheckBox ckbHaha;

		private CheckBox ckbTym;

		private CheckBox ckbLike;

		private Label label32;

		private CheckBox ckbComment;

		private CheckBox ckbInteract;

		private NumericUpDown nudSoLuongTo;

		private NumericUpDown nudSoLuongFrom;

		private Label label10;

		private Label label11;

		private Label label12;

		private Button button3;

		private Button button2;

		public fHDChiaSeLivestream(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDChiaSeLivestream").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('HDChiaSeLivestream', 'Chia sẻ livestream');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDChiaSeLivestream");
				jsonStringOrPathFile = tuongTac.Rows[0]["CauHinh"].ToString();
				id_TuongTac = tuongTac.Rows[0]["Id_TuongTac"].ToString();
				txtTenHanhDong.Text = Language.GetValue(tuongTac.Rows[0]["MoTa"].ToString());
				break;
			}
			case 1:
			{
				DataTable hanhDongById = InteractSQL.GetHanhDongById(id_HanhDong);
				jsonStringOrPathFile = hanhDongById.Rows[0]["CauHinh"].ToString();
				btnAdd.Text = "Câ\u0323p nhâ\u0323t";
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
			Language.GetValue(groupBox2);
			Language.GetValue(label26);
			Language.GetValue(label25);
			Language.GetValue(label2);
			Language.GetValue(ckbVanBan);
			Language.GetValue(lblStatus);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(rbNganCachMoiDong);
			Language.GetValue(rbNganCachKyTu);
			Language.GetValue(label13);
			Language.GetValue(label14);
			Language.GetValue(ckbChiaSeLenTuong);
			Language.GetValue(ckbChiaSeLenNhom);
			Language.GetValue(label18);
			Language.GetValue(label16);
			Language.GetValue(label17);
			Language.GetValue(groupBox1);
			Language.GetValue(ckbVanBan);
			Language.GetValue(label9);
			Language.GetValue(ckbTuongTacLivestream);
			Language.GetValue(label12);
			Language.GetValue(label10);
			Language.GetValue(label11);
			Language.GetValue(ckbInteract);
			Language.GetValue(label25);
			Language.GetValue(label26);
			Language.GetValue(label28);
			Language.GetValue(label29);
			Language.GetValue(label30);
			Language.GetValue(label32);
			Language.GetValue(ckbComment);
			Language.GetValue(label4);
			Language.GetValue(label3);
			Language.GetValue(ckbBinhLuanNhieuLan);
			Language.GetValue(label6);
			Language.GetValue(label5);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				nudDelayFrom.Value = setting.GetValueInt("nudDelayFrom", 3);
				nudDelayTo.Value = setting.GetValueInt("nudDelayTo", 5);
				ckbChiaSeLenTuong.Checked = setting.GetValueBool("ckbChiaSeLenTuong");
				ckbChiaSeLenNhom.Checked = setting.GetValueBool("ckbChiaSeLenNhom");
				nudCountGroupFrom.Value = setting.GetValueInt("nudCountGroupFrom", 1);
				nudCountGroupTo.Value = setting.GetValueInt("nudCountGroupTo", 3);
				ckbVanBan.Checked = setting.GetValueBool("ckbVanBan");
				txtNoiDung.Text = setting.GetValue("txtNoiDung");
				if (setting.GetValueInt("typeNganCach") == 1)
				{
					rbNganCachKyTu.Checked = true;
				}
				else
				{
					rbNganCachMoiDong.Checked = true;
				}
				txtLinkChiaSe.Text = setting.GetValue("txtLinkChiaSe");
				ckbTuongTacLivestream.Checked = setting.GetValueBool("ckbTuongTacLivestream");
				nudSoLuongFrom.Value = setting.GetValueInt("nudSoLuongFrom", 30);
				nudSoLuongTo.Value = setting.GetValueInt("nudSoLuongTo", 30);
				ckbInteract.Checked = setting.GetValueBool("ckbInteract");
				string value = setting.GetValue("typeReaction");
				List<CheckBox> list = new List<CheckBox> { ckbLike, ckbTym, ckbHaha, ckbWow, ckbBuon, ckbGian };
				for (int i = 0; i < list.Count; i++)
				{
					if (value.Contains(i.ToString()))
					{
						list[i].Checked = true;
					}
				}
				ckbComment.Checked = setting.GetValueBool("ckbComment");
				txtComment.Text = setting.GetValue("txtComment");
				ckbBinhLuanNhieuLan.Checked = setting.GetValueBool("ckbBinhLuanNhieuLan");
				nudBinhLuanNhieuLanDelayFrom.Value = setting.GetValueInt("nudBinhLuanNhieuLanDelayFrom", 10);
				nudBinhLuanNhieuLanDelayTo.Value = setting.GetValueInt("nudBinhLuanNhieuLanDelayTo", 10);
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
				MessageBoxHelper.ShowMessageBox("Vui lo\u0300ng nhâ\u0323p tên ha\u0300nh đô\u0323ng!", 3);
				return;
			}
			JSON_Settings jSON_Settings = new JSON_Settings();
			jSON_Settings.Update("ckbChiaSeLenTuong", ckbChiaSeLenTuong.Checked);
			jSON_Settings.Update("ckbChiaSeLenNhom", ckbChiaSeLenNhom.Checked);
			jSON_Settings.Update("nudCountGroupFrom", nudCountGroupFrom.Value);
			jSON_Settings.Update("nudCountGroupTo", nudCountGroupTo.Value);
			jSON_Settings.Update("nudDelayFrom", nudDelayFrom.Value);
			jSON_Settings.Update("nudDelayTo", nudDelayTo.Value);
			jSON_Settings.Update("txtLinkChiaSe", txtLinkChiaSe.Text.Trim());
			jSON_Settings.Update("ckbVanBan", ckbVanBan.Checked);
			jSON_Settings.Update("txtNoiDung", txtNoiDung.Text.Trim());
			int num = 0;
			if (rbNganCachKyTu.Checked)
			{
				num = 1;
			}
			jSON_Settings.Update("typeNganCach", num);
			jSON_Settings.Update("ckbTuongTacLivestream", ckbTuongTacLivestream.Checked);
			jSON_Settings.Update("nudSoLuongFrom", nudSoLuongFrom.Value);
			jSON_Settings.Update("nudSoLuongTo", nudSoLuongTo.Value);
			jSON_Settings.Update("ckbInteract", ckbInteract.Checked);
			string text2 = "";
			List<CheckBox> list = new List<CheckBox> { ckbLike, ckbTym, ckbHaha, ckbWow, ckbBuon, ckbGian };
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Checked)
				{
					text2 += i;
				}
			}
			jSON_Settings.Update("typeReaction", text2);
			jSON_Settings.Update("ckbComment", ckbComment.Checked);
			jSON_Settings.Update("txtComment", txtComment.Text.Trim());
			jSON_Settings.Update("ckbBinhLuanNhieuLan", ckbBinhLuanNhieuLan.Checked);
			jSON_Settings.Update("nudBinhLuanNhieuLanDelayFrom", nudBinhLuanNhieuLanDelayFrom.Value);
			jSON_Settings.Update("nudBinhLuanNhieuLanDelayTo", nudBinhLuanNhieuLanDelayTo.Value);
			string fullString = jSON_Settings.GetFullString();
			if (type == 0)
			{
				if (MessageBox.Show("Ba\u0323n co\u0301 muô\u0301n thêm ha\u0300nh đô\u0323ng mơ\u0301i?", "Thông ba\u0301o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (InteractSQL.InsertHanhDong(id_KichBan, text, id_TuongTac, fullString))
					{
						isSave = true;
						Close();
					}
					else
					{
						MessageBoxHelper.ShowMessageBox("Thêm thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
					}
				}
			}
			else if (MessageBox.Show("Ba\u0323n co\u0301 muô\u0301n câ\u0323p nhâ\u0323t ha\u0300nh đô\u0323ng?", "Thông ba\u0301o", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (InteractSQL.UpdateHanhDong(Id_HanhDong, text, fullString))
				{
					isSave = true;
					Close();
				}
				else
				{
					MessageBoxHelper.ShowMessageBox("Câ\u0323p nhâ\u0323t thâ\u0301t ba\u0323i, vui lo\u0300ng thư\u0309 la\u0323i sau!", 2);
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
			ckbVanBan_CheckedChanged(null, null);
			ckbDangBaiLenNhom_CheckedChanged(null, null);
			ckbTuongTacLivestream_CheckedChanged(null, null);
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbBinhLuanNhieuLan_CheckedChanged(null, null);
		}

		private void ckbVanBan_CheckedChanged(object sender, EventArgs e)
		{
			plVanBan.Enabled = ckbVanBan.Checked;
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
			groupBox1.Height = 290;
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			groupBox1.Height = 246;
		}

		private void rbNganCachMoiDong_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void rbNganCachKyTu_CheckedChanged(object sender, EventArgs e)
		{
			UpdateSoLuongBinhLuan();
		}

		private void ckbDangBaiLenNhom_CheckedChanged(object sender, EventArgs e)
		{
			plDangBaiLenNhom.Enabled = ckbChiaSeLenNhom.Checked;
		}

		private void ckbTuongTacLivestream_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacLivestream.Enabled = ckbTuongTacLivestream.Checked;
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
			plInteract.Enabled = ckbInteract.Checked;
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
			plComment.Enabled = ckbComment.Checked;
		}

		private void ckbBinhLuanNhieuLan_CheckedChanged(object sender, EventArgs e)
		{
			plBinhLuanNhieuLan.Enabled = ckbBinhLuanNhieuLan.Checked;
		}

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				list = ((!rbNganCachMoiDong.Checked) ? txtComment.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : txtComment.Lines.ToList());
				list = MCommon.Common.RemoveEmptyItems(list);
				label4.Text = string.Format(Language.GetValue("Nội dung bình luận ({0}):"), list.Count.ToString());
			}
			catch
			{
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhập mỗi dòng là 1 nội dung!"));
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHelpNhapComment());
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
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			btnMinimize = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			plTuongTacLivestream = new System.Windows.Forms.Panel();
			plComment = new System.Windows.Forms.Panel();
			plBinhLuanNhieuLan = new System.Windows.Forms.Panel();
			nudBinhLuanNhieuLanDelayTo = new System.Windows.Forms.NumericUpDown();
			lblmc1 = new System.Windows.Forms.Label();
			nudBinhLuanNhieuLanDelayFrom = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			ckbBinhLuanNhieuLan = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			txtComment = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			plInteract = new System.Windows.Forms.Panel();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			ckbGian = new System.Windows.Forms.CheckBox();
			ckbBuon = new System.Windows.Forms.CheckBox();
			ckbWow = new System.Windows.Forms.CheckBox();
			ckbHaha = new System.Windows.Forms.CheckBox();
			ckbTym = new System.Windows.Forms.CheckBox();
			ckbLike = new System.Windows.Forms.CheckBox();
			label32 = new System.Windows.Forms.Label();
			ckbComment = new System.Windows.Forms.CheckBox();
			ckbInteract = new System.Windows.Forms.CheckBox();
			nudSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			plDangBaiLenNhom = new System.Windows.Forms.Panel();
			nudCountGroupTo = new System.Windows.Forms.NumericUpDown();
			nudCountGroupFrom = new System.Windows.Forms.NumericUpDown();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			ckbChiaSeLenNhom = new System.Windows.Forms.CheckBox();
			ckbChiaSeLenTuong = new System.Windows.Forms.CheckBox();
			nudDelayTo = new System.Windows.Forms.NumericUpDown();
			ckbTuongTacLivestream = new System.Windows.Forms.CheckBox();
			nudDelayFrom = new System.Windows.Forms.NumericUpDown();
			label15 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			ckbVanBan = new System.Windows.Forms.CheckBox();
			plVanBan = new System.Windows.Forms.Panel();
			btnDown = new MetroFramework.Controls.MetroButton();
			btnUp = new MetroFramework.Controls.MetroButton();
			rbNganCachKyTu = new System.Windows.Forms.RadioButton();
			rbNganCachMoiDong = new System.Windows.Forms.RadioButton();
			label9 = new System.Windows.Forms.Label();
			txtNoiDung = new System.Windows.Forms.RichTextBox();
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtLinkChiaSe = new System.Windows.Forms.TextBox();
			btnAdd = new System.Windows.Forms.Button();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plTuongTacLivestream.SuspendLayout();
			plComment.SuspendLayout();
			plBinhLuanNhieuLan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayFrom).BeginInit();
			plInteract.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).BeginInit();
			groupBox2.SuspendLayout();
			plDangBaiLenNhom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).BeginInit();
			groupBox1.SuspendLayout();
			plVanBan.SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(875, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Chia sẻ livestream";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(875, 31);
			pnlHeader.TabIndex = 9;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = maxcare.Properties.Resources.btnMinimize_Image;
			btnMinimize.Location = new System.Drawing.Point(842, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 79;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(button1_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = maxcare.Properties.Resources.icon_64;
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(plTuongTacLivestream);
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(nudDelayTo);
			panel1.Controls.Add(ckbTuongTacLivestream);
			panel1.Controls.Add(nudDelayFrom);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(label14);
			panel1.Controls.Add(label13);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(878, 501);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plTuongTacLivestream.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacLivestream.Controls.Add(plComment);
			plTuongTacLivestream.Controls.Add(plInteract);
			plTuongTacLivestream.Controls.Add(ckbComment);
			plTuongTacLivestream.Controls.Add(ckbInteract);
			plTuongTacLivestream.Controls.Add(nudSoLuongTo);
			plTuongTacLivestream.Controls.Add(nudSoLuongFrom);
			plTuongTacLivestream.Controls.Add(label10);
			plTuongTacLivestream.Controls.Add(label11);
			plTuongTacLivestream.Controls.Add(label12);
			plTuongTacLivestream.Location = new System.Drawing.Point(530, 89);
			plTuongTacLivestream.Name = "plTuongTacLivestream";
			plTuongTacLivestream.Size = new System.Drawing.Size(315, 351);
			plTuongTacLivestream.TabIndex = 53;
			plComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plComment.Controls.Add(plBinhLuanNhieuLan);
			plComment.Controls.Add(ckbBinhLuanNhieuLan);
			plComment.Controls.Add(label3);
			plComment.Controls.Add(txtComment);
			plComment.Controls.Add(label4);
			plComment.Location = new System.Drawing.Point(25, 128);
			plComment.Name = "plComment";
			plComment.Size = new System.Drawing.Size(278, 213);
			plComment.TabIndex = 43;
			plBinhLuanNhieuLan.Controls.Add(nudBinhLuanNhieuLanDelayTo);
			plBinhLuanNhieuLan.Controls.Add(lblmc1);
			plBinhLuanNhieuLan.Controls.Add(nudBinhLuanNhieuLanDelayFrom);
			plBinhLuanNhieuLan.Controls.Add(label5);
			plBinhLuanNhieuLan.Controls.Add(label6);
			plBinhLuanNhieuLan.Location = new System.Drawing.Point(19, 182);
			plBinhLuanNhieuLan.Name = "plBinhLuanNhieuLan";
			plBinhLuanNhieuLan.Size = new System.Drawing.Size(254, 27);
			plBinhLuanNhieuLan.TabIndex = 134;
			nudBinhLuanNhieuLanDelayTo.Cursor = System.Windows.Forms.Cursors.Hand;
			nudBinhLuanNhieuLanDelayTo.Location = new System.Drawing.Point(174, 2);
			nudBinhLuanNhieuLanDelayTo.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
			nudBinhLuanNhieuLanDelayTo.Name = "nudBinhLuanNhieuLanDelayTo";
			nudBinhLuanNhieuLanDelayTo.Size = new System.Drawing.Size(50, 23);
			nudBinhLuanNhieuLanDelayTo.TabIndex = 22;
			lblmc1.AutoSize = true;
			lblmc1.Location = new System.Drawing.Point(4, 4);
			lblmc1.Name = "lblmc1";
			lblmc1.Size = new System.Drawing.Size(73, 16);
			lblmc1.TabIndex = 18;
			lblmc1.Text = "Delay time:";
			nudBinhLuanNhieuLanDelayFrom.Cursor = System.Windows.Forms.Cursors.Hand;
			nudBinhLuanNhieuLanDelayFrom.Location = new System.Drawing.Point(86, 2);
			nudBinhLuanNhieuLanDelayFrom.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
			nudBinhLuanNhieuLanDelayFrom.Name = "nudBinhLuanNhieuLanDelayFrom";
			nudBinhLuanNhieuLanDelayFrom.Size = new System.Drawing.Size(45, 23);
			nudBinhLuanNhieuLanDelayFrom.TabIndex = 21;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(226, 4);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(31, 16);
			label5.TabIndex = 20;
			label5.Text = "giây";
			label6.Location = new System.Drawing.Point(133, 4);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(39, 16);
			label6.TabIndex = 20;
			label6.Text = "đến";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbBinhLuanNhieuLan.AutoSize = true;
			ckbBinhLuanNhieuLan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBinhLuanNhieuLan.Location = new System.Drawing.Point(7, 163);
			ckbBinhLuanNhieuLan.Name = "ckbBinhLuanNhieuLan";
			ckbBinhLuanNhieuLan.Size = new System.Drawing.Size(135, 20);
			ckbBinhLuanNhieuLan.TabIndex = 133;
			ckbBinhLuanNhieuLan.Text = "Bình luận nhiều lần";
			ckbBinhLuanNhieuLan.UseVisualStyleBackColor = true;
			ckbBinhLuanNhieuLan.CheckedChanged += new System.EventHandler(ckbBinhLuanNhieuLan_CheckedChanged);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 141);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(266, 16);
			label3.TabIndex = 2;
			label3.Text = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})";
			txtComment.Location = new System.Drawing.Point(7, 27);
			txtComment.Multiline = true;
			txtComment.Name = "txtComment";
			txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtComment.Size = new System.Drawing.Size(261, 111);
			txtComment.TabIndex = 1;
			txtComment.WordWrap = false;
			txtComment.TextChanged += new System.EventHandler(txtComment_TextChanged);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 5);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(140, 16);
			label4.TabIndex = 0;
			label4.Text = "Nội dung bình luận (0):";
			plInteract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plInteract.Controls.Add(label25);
			plInteract.Controls.Add(label26);
			plInteract.Controls.Add(label28);
			plInteract.Controls.Add(label29);
			plInteract.Controls.Add(label30);
			plInteract.Controls.Add(ckbGian);
			plInteract.Controls.Add(ckbBuon);
			plInteract.Controls.Add(ckbWow);
			plInteract.Controls.Add(ckbHaha);
			plInteract.Controls.Add(ckbTym);
			plInteract.Controls.Add(ckbLike);
			plInteract.Controls.Add(label32);
			plInteract.Location = new System.Drawing.Point(25, 59);
			plInteract.Name = "plInteract";
			plInteract.Size = new System.Drawing.Size(278, 40);
			plInteract.TabIndex = 41;
			label25.Cursor = System.Windows.Forms.Cursors.Hand;
			label25.Location = new System.Drawing.Point(4, 1);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(30, 16);
			label25.TabIndex = 0;
			label25.Text = "Like";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label26.Cursor = System.Windows.Forms.Cursors.Hand;
			label26.Location = new System.Drawing.Point(46, 1);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(39, 16);
			label26.TabIndex = 2;
			label26.Text = "Tym";
			label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.Cursor = System.Windows.Forms.Cursors.Hand;
			label28.Location = new System.Drawing.Point(93, 1);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(37, 16);
			label28.TabIndex = 6;
			label28.Text = "Haha";
			label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label29.Cursor = System.Windows.Forms.Cursors.Hand;
			label29.Location = new System.Drawing.Point(140, 1);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(37, 16);
			label29.TabIndex = 8;
			label29.Text = "Wow";
			label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label30.Cursor = System.Windows.Forms.Cursors.Hand;
			label30.Location = new System.Drawing.Point(187, 1);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(36, 16);
			label30.TabIndex = 10;
			label30.Text = "Buồn";
			label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbGian.AutoSize = true;
			ckbGian.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbGian.Location = new System.Drawing.Point(246, 20);
			ckbGian.Name = "ckbGian";
			ckbGian.Size = new System.Drawing.Size(15, 14);
			ckbGian.TabIndex = 13;
			ckbGian.UseVisualStyleBackColor = true;
			ckbBuon.AutoSize = true;
			ckbBuon.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbBuon.Location = new System.Drawing.Point(199, 20);
			ckbBuon.Name = "ckbBuon";
			ckbBuon.Size = new System.Drawing.Size(15, 14);
			ckbBuon.TabIndex = 11;
			ckbBuon.UseVisualStyleBackColor = true;
			ckbWow.AutoSize = true;
			ckbWow.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWow.Location = new System.Drawing.Point(152, 20);
			ckbWow.Name = "ckbWow";
			ckbWow.Size = new System.Drawing.Size(15, 14);
			ckbWow.TabIndex = 9;
			ckbWow.UseVisualStyleBackColor = true;
			ckbHaha.AutoSize = true;
			ckbHaha.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbHaha.Location = new System.Drawing.Point(105, 20);
			ckbHaha.Name = "ckbHaha";
			ckbHaha.Size = new System.Drawing.Size(15, 14);
			ckbHaha.TabIndex = 7;
			ckbHaha.UseVisualStyleBackColor = true;
			ckbTym.AutoSize = true;
			ckbTym.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTym.Location = new System.Drawing.Point(58, 20);
			ckbTym.Name = "ckbTym";
			ckbTym.Size = new System.Drawing.Size(15, 14);
			ckbTym.TabIndex = 3;
			ckbTym.UseVisualStyleBackColor = true;
			ckbLike.AutoSize = true;
			ckbLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbLike.Location = new System.Drawing.Point(11, 20);
			ckbLike.Name = "ckbLike";
			ckbLike.Size = new System.Drawing.Size(15, 14);
			ckbLike.TabIndex = 1;
			ckbLike.UseVisualStyleBackColor = true;
			label32.Cursor = System.Windows.Forms.Cursors.Hand;
			label32.Location = new System.Drawing.Point(230, 1);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(44, 16);
			label32.TabIndex = 12;
			label32.Text = "Giận";
			label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbComment.AutoSize = true;
			ckbComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbComment.Location = new System.Drawing.Point(7, 103);
			ckbComment.Name = "ckbComment";
			ckbComment.Size = new System.Drawing.Size(131, 20);
			ckbComment.TabIndex = 42;
			ckbComment.Text = "Tư\u0323 đô\u0323ng bi\u0300nh luâ\u0323n";
			ckbComment.UseVisualStyleBackColor = true;
			ckbComment.CheckedChanged += new System.EventHandler(ckbComment_CheckedChanged);
			ckbInteract.AutoSize = true;
			ckbInteract.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbInteract.Location = new System.Drawing.Point(7, 35);
			ckbInteract.Name = "ckbInteract";
			ckbInteract.Size = new System.Drawing.Size(113, 20);
			ckbInteract.TabIndex = 40;
			ckbInteract.Text = "Ba\u0300y to\u0309 ca\u0309m xu\u0301c";
			ckbInteract.UseVisualStyleBackColor = true;
			ckbInteract.CheckedChanged += new System.EventHandler(ckbInteract_CheckedChanged);
			nudSoLuongTo.Location = new System.Drawing.Point(206, 6);
			nudSoLuongTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongTo.Name = "nudSoLuongTo";
			nudSoLuongTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongTo.TabIndex = 39;
			nudSoLuongFrom.Location = new System.Drawing.Point(109, 6);
			nudSoLuongFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongFrom.Name = "nudSoLuongFrom";
			nudSoLuongFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongFrom.TabIndex = 38;
			label10.Location = new System.Drawing.Point(171, 8);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(29, 16);
			label10.TabIndex = 46;
			label10.Text = "đê\u0301n";
			label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(267, 8);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(31, 16);
			label11.TabIndex = 45;
			label11.Text = "giây";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(4, 8);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(94, 16);
			label12.TabIndex = 44;
			label12.Text = "Thời gian xem:";
			groupBox2.Controls.Add(plDangBaiLenNhom);
			groupBox2.Controls.Add(ckbChiaSeLenNhom);
			groupBox2.Controls.Add(ckbChiaSeLenTuong);
			groupBox2.Location = new System.Drawing.Point(30, 107);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(475, 81);
			groupBox2.TabIndex = 52;
			groupBox2.TabStop = false;
			groupBox2.Text = "Tùy chọn chia sẻ";
			plDangBaiLenNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plDangBaiLenNhom.Controls.Add(nudCountGroupTo);
			plDangBaiLenNhom.Controls.Add(nudCountGroupFrom);
			plDangBaiLenNhom.Controls.Add(label16);
			plDangBaiLenNhom.Controls.Add(label17);
			plDangBaiLenNhom.Controls.Add(label18);
			plDangBaiLenNhom.Location = new System.Drawing.Point(157, 47);
			plDangBaiLenNhom.Name = "plDangBaiLenNhom";
			plDangBaiLenNhom.Size = new System.Drawing.Size(310, 27);
			plDangBaiLenNhom.TabIndex = 1;
			nudCountGroupTo.Location = new System.Drawing.Point(205, 1);
			nudCountGroupTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountGroupTo.Name = "nudCountGroupTo";
			nudCountGroupTo.Size = new System.Drawing.Size(56, 23);
			nudCountGroupTo.TabIndex = 53;
			nudCountGroupFrom.Location = new System.Drawing.Point(108, 1);
			nudCountGroupFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudCountGroupFrom.Name = "nudCountGroupFrom";
			nudCountGroupFrom.Size = new System.Drawing.Size(56, 23);
			nudCountGroupFrom.TabIndex = 52;
			label16.Location = new System.Drawing.Point(170, 3);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(29, 16);
			label16.TabIndex = 56;
			label16.Text = "đê\u0301n";
			label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(264, 3);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(40, 16);
			label17.TabIndex = 55;
			label17.Text = "nhóm";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(3, 3);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(100, 16);
			label18.TabIndex = 54;
			label18.Text = "Số lượng nhóm:";
			ckbChiaSeLenNhom.AutoSize = true;
			ckbChiaSeLenNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbChiaSeLenNhom.Location = new System.Drawing.Point(11, 49);
			ckbChiaSeLenNhom.Name = "ckbChiaSeLenNhom";
			ckbChiaSeLenNhom.Size = new System.Drawing.Size(126, 20);
			ckbChiaSeLenNhom.TabIndex = 0;
			ckbChiaSeLenNhom.Text = "Chia sẻ lên nhóm";
			ckbChiaSeLenNhom.UseVisualStyleBackColor = true;
			ckbChiaSeLenNhom.CheckedChanged += new System.EventHandler(ckbDangBaiLenNhom_CheckedChanged);
			ckbChiaSeLenTuong.AutoSize = true;
			ckbChiaSeLenTuong.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbChiaSeLenTuong.Location = new System.Drawing.Point(11, 23);
			ckbChiaSeLenTuong.Name = "ckbChiaSeLenTuong";
			ckbChiaSeLenTuong.Size = new System.Drawing.Size(127, 20);
			ckbChiaSeLenTuong.TabIndex = 0;
			ckbChiaSeLenTuong.Text = "Chia sẻ lên tường";
			ckbChiaSeLenTuong.UseVisualStyleBackColor = true;
			nudDelayTo.Location = new System.Drawing.Point(220, 78);
			nudDelayTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayTo.Name = "nudDelayTo";
			nudDelayTo.Size = new System.Drawing.Size(56, 23);
			nudDelayTo.TabIndex = 48;
			ckbTuongTacLivestream.AutoSize = true;
			ckbTuongTacLivestream.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacLivestream.Location = new System.Drawing.Point(530, 66);
			ckbTuongTacLivestream.Name = "ckbTuongTacLivestream";
			ckbTuongTacLivestream.Size = new System.Drawing.Size(238, 20);
			ckbTuongTacLivestream.TabIndex = 0;
			ckbTuongTacLivestream.Text = "Tương tác livestream trước khi share";
			ckbTuongTacLivestream.UseVisualStyleBackColor = true;
			ckbTuongTacLivestream.CheckedChanged += new System.EventHandler(ckbTuongTacLivestream_CheckedChanged);
			nudDelayFrom.Location = new System.Drawing.Point(123, 78);
			nudDelayFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudDelayFrom.Name = "nudDelayFrom";
			nudDelayFrom.Size = new System.Drawing.Size(56, 23);
			nudDelayFrom.TabIndex = 47;
			label15.Location = new System.Drawing.Point(185, 80);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(29, 16);
			label15.TabIndex = 51;
			label15.Text = "đê\u0301n";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(279, 80);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(31, 16);
			label14.TabIndex = 50;
			label14.Text = "giây";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(27, 80);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(90, 16);
			label13.TabIndex = 49;
			label13.Text = "Thời gian chờ:";
			groupBox1.Controls.Add(ckbVanBan);
			groupBox1.Controls.Add(plVanBan);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(txtLinkChiaSe);
			groupBox1.Location = new System.Drawing.Point(30, 194);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(475, 246);
			groupBox1.TabIndex = 34;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cấu hình nội dung chia sẻ";
			ckbVanBan.AutoSize = true;
			ckbVanBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbVanBan.Location = new System.Drawing.Point(11, 50);
			ckbVanBan.Name = "ckbVanBan";
			ckbVanBan.Size = new System.Drawing.Size(121, 20);
			ckbVanBan.TabIndex = 32;
			ckbVanBan.Text = "Nội dung chia sẻ";
			ckbVanBan.UseVisualStyleBackColor = true;
			ckbVanBan.CheckedChanged += new System.EventHandler(ckbVanBan_CheckedChanged);
			plVanBan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			plVanBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVanBan.Controls.Add(button3);
			plVanBan.Controls.Add(button2);
			plVanBan.Controls.Add(btnDown);
			plVanBan.Controls.Add(btnUp);
			plVanBan.Controls.Add(rbNganCachKyTu);
			plVanBan.Controls.Add(rbNganCachMoiDong);
			plVanBan.Controls.Add(label9);
			plVanBan.Controls.Add(txtNoiDung);
			plVanBan.Controls.Add(label8);
			plVanBan.Controls.Add(lblStatus);
			plVanBan.Location = new System.Drawing.Point(28, 74);
			plVanBan.Name = "plVanBan";
			plVanBan.Size = new System.Drawing.Size(439, 163);
			plVanBan.TabIndex = 33;
			btnDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDown.BackgroundImage = maxcare.Properties.Resources.icons8_expand_arrow_24px;
			btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDown.Location = new System.Drawing.Point(382, -1);
			btnDown.Name = "btnDown";
			btnDown.Size = new System.Drawing.Size(25, 25);
			btnDown.TabIndex = 38;
			btnDown.UseSelectable = true;
			btnDown.Visible = false;
			btnDown.Click += new System.EventHandler(btnDown_Click);
			btnUp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnUp.BackgroundImage = maxcare.Properties.Resources.icons8_collapse_arrow_24px;
			btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
			btnUp.Location = new System.Drawing.Point(413, -1);
			btnUp.Name = "btnUp";
			btnUp.Size = new System.Drawing.Size(25, 25);
			btnUp.TabIndex = 39;
			btnUp.UseSelectable = true;
			btnUp.Visible = false;
			btnUp.Click += new System.EventHandler(btnUp_Click);
			rbNganCachKyTu.AutoSize = true;
			rbNganCachKyTu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachKyTu.Location = new System.Drawing.Point(69, 183);
			rbNganCachKyTu.Name = "rbNganCachKyTu";
			rbNganCachKyTu.Size = new System.Drawing.Size(160, 20);
			rbNganCachKyTu.TabIndex = 37;
			rbNganCachKyTu.Text = "Nội dung có nhiều dòng";
			rbNganCachKyTu.UseVisualStyleBackColor = true;
			rbNganCachKyTu.CheckedChanged += new System.EventHandler(rbNganCachKyTu_CheckedChanged);
			rbNganCachMoiDong.AutoSize = true;
			rbNganCachMoiDong.Checked = true;
			rbNganCachMoiDong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNganCachMoiDong.Location = new System.Drawing.Point(69, 162);
			rbNganCachMoiDong.Name = "rbNganCachMoiDong";
			rbNganCachMoiDong.Size = new System.Drawing.Size(156, 20);
			rbNganCachMoiDong.TabIndex = 36;
			rbNganCachMoiDong.TabStop = true;
			rbNganCachMoiDong.Text = "Nội dung chỉ có 1 dòng";
			rbNganCachMoiDong.UseVisualStyleBackColor = true;
			rbNganCachMoiDong.CheckedChanged += new System.EventHandler(rbNganCachMoiDong_CheckedChanged);
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(4, 162);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 16);
			label9.TabIndex = 35;
			label9.Text = "Tùy chọn:";
			txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			txtNoiDung.Location = new System.Drawing.Point(7, 24);
			txtNoiDung.Name = "txtNoiDung";
			txtNoiDung.Size = new System.Drawing.Size(424, 114);
			txtNoiDung.TabIndex = 34;
			txtNoiDung.Text = "";
			txtNoiDung.WordWrap = false;
			txtNoiDung.TextChanged += new System.EventHandler(txtNoiDung_TextChanged);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 141);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(266, 16);
			label8.TabIndex = 0;
			label8.Text = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})";
			lblStatus.AutoSize = true;
			lblStatus.Location = new System.Drawing.Point(3, 5);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(146, 16);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Danh sa\u0301ch nô\u0323i dung (0):";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(8, 26);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(98, 16);
			label2.TabIndex = 31;
			label2.Text = "Link livestream:";
			txtLinkChiaSe.Location = new System.Drawing.Point(112, 23);
			txtLinkChiaSe.Name = "txtLinkChiaSe";
			txtLinkChiaSe.Size = new System.Drawing.Size(355, 23);
			txtLinkChiaSe.TabIndex = 0;
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(343, 454);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(btnAdd_Click);
			txtTenHanhDong.Location = new System.Drawing.Point(123, 49);
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
			btnCancel.Location = new System.Drawing.Point(442, 454);
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
			bunifuCards1.Size = new System.Drawing.Size(875, 37);
			bunifuCards1.TabIndex = 28;
			button3.Cursor = System.Windows.Forms.Cursors.Help;
			button3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button3.Location = new System.Drawing.Point(223, 185);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(21, 23);
			button3.TabIndex = 195;
			button3.Text = "?";
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Cursor = System.Windows.Forms.Cursors.Help;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(223, 162);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(21, 23);
			button2.TabIndex = 196;
			button2.Text = "?";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(878, 501);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDChiaSeLivestream";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plTuongTacLivestream.ResumeLayout(false);
			plTuongTacLivestream.PerformLayout();
			plComment.ResumeLayout(false);
			plComment.PerformLayout();
			plBinhLuanNhieuLan.ResumeLayout(false);
			plBinhLuanNhieuLan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudBinhLuanNhieuLanDelayFrom).EndInit();
			plInteract.ResumeLayout(false);
			plInteract.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongFrom).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			plDangBaiLenNhom.ResumeLayout(false);
			plDangBaiLenNhom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCountGroupTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCountGroupFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayFrom).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			plVanBan.ResumeLayout(false);
			plVanBan.PerformLayout();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
