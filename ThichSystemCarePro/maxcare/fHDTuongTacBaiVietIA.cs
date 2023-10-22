using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using maxcare.Properties;
using MCommon;

namespace maxcare
{
	public class fHDTuongTacBaiVietIA : Form
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

		private Button btnMinimize;

		private Label lblUid;

		private Label label15;

		private Label label5;

		private TextBox txtIdPage;

		private Label label7;

		private Label label4;

		private Label label6;

		private NumericUpDown nudThoiGianLuotTo;

		private NumericUpDown nudThoiGianLuotFrom;

		private Label label3;

		private NumericUpDown nudSoLuongBaiFrom;

		private NumericUpDown nudSoLuongBaiTo;

		private Panel plTuongTacQuangCao;

		private RichTextBox txtNoiDungTinNhan;

		private Label label2;

		private CheckBox ckbTuongTacQuangCao;

		public fHDTuongTacBaiVietIA(string id_KichBan, int type = 0, string id_HanhDong = "")
		{
			InitializeComponent();
			ChangeLanguage();
			isSave = false;
			this.id_KichBan = id_KichBan;
			Id_HanhDong = id_HanhDong;
			this.type = type;
			if (InteractSQL.GetTuongTac("", "HDTuongTacBaiVietIA").Rows.Count == 0)
			{
				maxcare.KichBan.Connector.Instance.ExecuteNonQuery("INSERT INTO \"main\".\"Tuong_Tac\" (\"TenTuongTac\", \"MoTa\") VALUES ('HDTuongTacBaiVietIA', 'Tương tác ba\u0300i viê\u0301t IA');");
			}
			string jsonStringOrPathFile = "";
			switch (type)
			{
			case 0:
			{
				DataTable tuongTac = InteractSQL.GetTuongTac("", "HDTuongTacBaiVietIA");
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
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
			Language.GetValue(lblUid);
			Language.GetValue(label3);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			try
			{
				txtIdPage.Text = setting.GetValue("txtIdPage");
				nudSoLuongBaiFrom.Value = setting.GetValueInt("nudSoLuongBaiFrom", 1);
				nudSoLuongBaiTo.Value = setting.GetValueInt("nudSoLuongBaiTo", 3);
				nudThoiGianLuotFrom.Value = setting.GetValueInt("nudThoiGianLuotFrom", 30);
				nudThoiGianLuotTo.Value = setting.GetValueInt("nudThoiGianLuotTo", 30);
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
			jSON_Settings.Update("txtIdPage", txtIdPage.Text.Trim());
			jSON_Settings.Update("nudSoLuongBaiFrom", nudSoLuongBaiFrom.Value);
			jSON_Settings.Update("nudSoLuongBaiTo", nudSoLuongBaiTo.Value);
			jSON_Settings.Update("nudThoiGianLuotFrom", nudThoiGianLuotFrom.Value);
			jSON_Settings.Update("nudThoiGianLuotTo", nudThoiGianLuotTo.Value);
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

		private void txtComment_Click(object sender, EventArgs e)
		{
		}

		private void UpdateSoLuongBinhLuan()
		{
		}

		private void CheckedChangeFull()
		{
			ckbInteract_CheckedChanged(null, null);
			ckbComment_CheckedChanged(null, null);
			ckbTuongTacQuangCao_CheckedChanged(null, null);
		}

		private void ckbComment_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
			}
		}

		private void ckbInteract_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckbTuongTacQuangCao_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacQuangCao.Enabled = ckbTuongTacQuangCao.Checked;
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
			plTuongTacQuangCao = new System.Windows.Forms.Panel();
			txtNoiDungTinNhan = new System.Windows.Forms.RichTextBox();
			label2 = new System.Windows.Forms.Label();
			ckbTuongTacQuangCao = new System.Windows.Forms.CheckBox();
			lblUid = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			txtIdPage = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			nudThoiGianLuotTo = new System.Windows.Forms.NumericUpDown();
			nudThoiGianLuotFrom = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			nudSoLuongBaiFrom = new System.Windows.Forms.NumericUpDown();
			nudSoLuongBaiTo = new System.Windows.Forms.NumericUpDown();
			txtTenHanhDong = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			plTuongTacQuangCao.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudThoiGianLuotTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudThoiGianLuotFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).BeginInit();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(352, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cấu hình Tương tác ba\u0300i viê\u0301t IA";
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
			pnlHeader.Size = new System.Drawing.Size(352, 31);
			pnlHeader.TabIndex = 9;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = maxcare.Properties.Resources.btnMinimize_Image;
			btnMinimize.Location = new System.Drawing.Point(319, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 78;
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
			panel1.Controls.Add(plTuongTacQuangCao);
			panel1.Controls.Add(ckbTuongTacQuangCao);
			panel1.Controls.Add(lblUid);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(txtIdPage);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label6);
			panel1.Controls.Add(nudThoiGianLuotTo);
			panel1.Controls.Add(nudThoiGianLuotFrom);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(nudSoLuongBaiFrom);
			panel1.Controls.Add(nudSoLuongBaiTo);
			panel1.Controls.Add(txtTenHanhDong);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards1);
			panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(355, 222);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			plTuongTacQuangCao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacQuangCao.Controls.Add(txtNoiDungTinNhan);
			plTuongTacQuangCao.Controls.Add(label2);
			plTuongTacQuangCao.Location = new System.Drawing.Point(24, 241);
			plTuongTacQuangCao.Name = "plTuongTacQuangCao";
			plTuongTacQuangCao.Size = new System.Drawing.Size(305, 103);
			plTuongTacQuangCao.TabIndex = 142;
			plTuongTacQuangCao.Visible = false;
			txtNoiDungTinNhan.Location = new System.Drawing.Point(7, 24);
			txtNoiDungTinNhan.Name = "txtNoiDungTinNhan";
			txtNoiDungTinNhan.Size = new System.Drawing.Size(292, 73);
			txtNoiDungTinNhan.TabIndex = 1;
			txtNoiDungTinNhan.Text = "";
			txtNoiDungTinNhan.WordWrap = false;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(4, 4);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(166, 16);
			label2.TabIndex = 0;
			label2.Text = "Nhâ\u0323p nô\u0323i dung tin nhă\u0301n (0):";
			ckbTuongTacQuangCao.AutoSize = true;
			ckbTuongTacQuangCao.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacQuangCao.Location = new System.Drawing.Point(24, 219);
			ckbTuongTacQuangCao.Name = "ckbTuongTacQuangCao";
			ckbTuongTacQuangCao.Size = new System.Drawing.Size(247, 20);
			ckbTuongTacQuangCao.TabIndex = 141;
			ckbTuongTacQuangCao.Text = "Tư\u0323 đô\u0323ng tương ta\u0301c qua\u0309ng ca\u0301o (să\u0301p co\u0301)";
			ckbTuongTacQuangCao.UseVisualStyleBackColor = true;
			ckbTuongTacQuangCao.Visible = false;
			ckbTuongTacQuangCao.CheckedChanged += new System.EventHandler(ckbTuongTacQuangCao_CheckedChanged);
			lblUid.AutoSize = true;
			lblUid.Location = new System.Drawing.Point(21, 81);
			lblUid.Name = "lblUid";
			lblUid.Size = new System.Drawing.Size(57, 16);
			lblUid.TabIndex = 140;
			lblUid.Text = "ID Page:";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(21, 138);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(114, 16);
			label15.TabIndex = 134;
			label15.Text = "Thơ\u0300i gian lươ\u0301t/ba\u0300i:";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(21, 109);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(109, 16);
			label5.TabIndex = 135;
			label5.Text = "Sô\u0301 lươ\u0323ng ba\u0300i viê\u0301t:";
			txtIdPage.Location = new System.Drawing.Point(141, 78);
			txtIdPage.Name = "txtIdPage";
			txtIdPage.Size = new System.Drawing.Size(188, 23);
			txtIdPage.TabIndex = 127;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(299, 138);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(31, 16);
			label7.TabIndex = 136;
			label7.Text = "giây";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(299, 109);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(25, 16);
			label4.TabIndex = 137;
			label4.Text = "ba\u0300i";
			label6.Location = new System.Drawing.Point(203, 138);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 16);
			label6.TabIndex = 138;
			label6.Text = "đê\u0301n";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudThoiGianLuotTo.Location = new System.Drawing.Point(238, 136);
			nudThoiGianLuotTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudThoiGianLuotTo.Name = "nudThoiGianLuotTo";
			nudThoiGianLuotTo.Size = new System.Drawing.Size(56, 23);
			nudThoiGianLuotTo.TabIndex = 132;
			nudThoiGianLuotFrom.Location = new System.Drawing.Point(141, 136);
			nudThoiGianLuotFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudThoiGianLuotFrom.Name = "nudThoiGianLuotFrom";
			nudThoiGianLuotFrom.Size = new System.Drawing.Size(56, 23);
			nudThoiGianLuotFrom.TabIndex = 130;
			label3.Location = new System.Drawing.Point(203, 109);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 16);
			label3.TabIndex = 139;
			label3.Text = "đê\u0301n";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudSoLuongBaiFrom.Location = new System.Drawing.Point(141, 107);
			nudSoLuongBaiFrom.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongBaiFrom.Name = "nudSoLuongBaiFrom";
			nudSoLuongBaiFrom.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiFrom.TabIndex = 131;
			nudSoLuongBaiTo.Location = new System.Drawing.Point(238, 107);
			nudSoLuongBaiTo.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudSoLuongBaiTo.Name = "nudSoLuongBaiTo";
			nudSoLuongBaiTo.Size = new System.Drawing.Size(56, 23);
			nudSoLuongBaiTo.TabIndex = 133;
			txtTenHanhDong.Location = new System.Drawing.Point(141, 49);
			txtTenHanhDong.Name = "txtTenHanhDong";
			txtTenHanhDong.Size = new System.Drawing.Size(188, 23);
			txtTenHanhDong.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(21, 52);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(99, 16);
			label1.TabIndex = 31;
			label1.Text = "Tên ha\u0300nh đô\u0323ng:";
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(180, 176);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 12;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(78, 176);
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
			bunifuCards1.Size = new System.Drawing.Size(352, 37);
			bunifuCards1.TabIndex = 28;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(355, 222);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fHDTuongTacBaiVietIA";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plTuongTacQuangCao.ResumeLayout(false);
			plTuongTacQuangCao.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudThoiGianLuotTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudThoiGianLuotFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSoLuongBaiTo).EndInit();
			bunifuCards1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
