using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fCauHinhKhoiPhucTaiKhoan : Form
	{
		public static bool isOK = false;

		public static int typeThuMuc = 0;

		public static string idFile = "";

		private int indexOld = 0;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private RadioButton rbThuMucCu;

		private RadioButton rbThuMucKhac;

		private Button button1;

		private ComboBox cbbThuMuc;

		private Panel plThuMucKhac;

		public fCauHinhKhoiPhucTaiKhoan()
		{
			InitializeComponent();
			Load_cbbThuMuc();
			ChangeLanguage();
			isOK = false;
			typeThuMuc = 0;
			idFile = "";
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(rbThuMucCu);
			Language.GetValue(rbThuMucKhac);
			Language.GetValue(button1);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			if (rbThuMucKhac.Checked)
			{
				if (cbbThuMuc.SelectedIndex == -1)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thêm thư mục để lưu tài khoản!"), 3);
					return;
				}
				typeThuMuc = 1;
				idFile = cbbThuMuc.SelectedValue.ToString();
			}
			isOK = true;
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void fClearProfile_Load(object sender, EventArgs e)
		{
			rbThuMucKhac_CheckedChanged(null, null);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			fAddFile f = new fAddFile();
			MCommon.Common.ShowForm(f);
			if (fAddFile.isAdd)
			{
				Load_cbbThuMuc();
				cbbThuMuc.SelectedIndex = cbbThuMuc.Items.Count - 1;
			}
		}

		private void Load_cbbThuMuc()
		{
			indexOld = cbbThuMuc.SelectedIndex;
			DataTable allFilesFromDatabase = CommonSQL.GetAllFilesFromDatabase();
			if (allFilesFromDatabase.Rows.Count > 0)
			{
				cbbThuMuc.DataSource = allFilesFromDatabase;
				cbbThuMuc.ValueMember = "id";
				cbbThuMuc.DisplayMember = "name";
				if (indexOld == -1)
				{
					indexOld = 0;
				}
				cbbThuMuc.SelectedIndex = indexOld;
			}
		}

		private void rbThuMucKhac_CheckedChanged(object sender, EventArgs e)
		{
			plThuMucKhac.Enabled = rbThuMucKhac.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCauHinhKhoiPhucTaiKhoan));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			rbThuMucCu = new System.Windows.Forms.RadioButton();
			rbThuMucKhac = new System.Windows.Forms.RadioButton();
			button1 = new System.Windows.Forms.Button();
			cbbThuMuc = new System.Windows.Forms.ComboBox();
			plThuMucKhac = new System.Windows.Forms.Panel();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			plThuMucKhac.SuspendLayout();
			SuspendLayout();
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(365, 34);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(365, 28);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 17;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(333, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 28);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(365, 28);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh Khôi phu\u0323c ta\u0300i khoa\u0309n";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(188, 162);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(84, 162);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			rbThuMucCu.AutoSize = true;
			rbThuMucCu.Checked = true;
			rbThuMucCu.Cursor = System.Windows.Forms.Cursors.Hand;
			rbThuMucCu.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbThuMucCu.Location = new System.Drawing.Point(36, 56);
			rbThuMucCu.Name = "rbThuMucCu";
			rbThuMucCu.Size = new System.Drawing.Size(166, 20);
			rbThuMucCu.TabIndex = 5;
			rbThuMucCu.TabStop = true;
			rbThuMucCu.Text = "Khôi phu\u0323c vê\u0300 thư mu\u0323c cu\u0303";
			rbThuMucCu.UseVisualStyleBackColor = true;
			rbThuMucKhac.AutoSize = true;
			rbThuMucKhac.Cursor = System.Windows.Forms.Cursors.Hand;
			rbThuMucKhac.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbThuMucKhac.Location = new System.Drawing.Point(36, 82);
			rbThuMucKhac.Name = "rbThuMucKhac";
			rbThuMucKhac.Size = new System.Drawing.Size(180, 20);
			rbThuMucKhac.TabIndex = 5;
			rbThuMucKhac.Text = "Chuyê\u0309n sang thư mu\u0323c kha\u0301c";
			rbThuMucKhac.UseVisualStyleBackColor = true;
			rbThuMucKhac.CheckedChanged += new System.EventHandler(rbThuMucKhac_CheckedChanged);
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.Location = new System.Drawing.Point(210, 2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(62, 27);
			button1.TabIndex = 48;
			button1.Text = "Thêm";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			cbbThuMuc.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbThuMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbThuMuc.DropDownWidth = 269;
			cbbThuMuc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbThuMuc.FormattingEnabled = true;
			cbbThuMuc.Location = new System.Drawing.Point(3, 3);
			cbbThuMuc.Name = "cbbThuMuc";
			cbbThuMuc.Size = new System.Drawing.Size(201, 24);
			cbbThuMuc.TabIndex = 47;
			plThuMucKhac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plThuMucKhac.Controls.Add(cbbThuMuc);
			plThuMucKhac.Controls.Add(button1);
			plThuMucKhac.Location = new System.Drawing.Point(55, 108);
			plThuMucKhac.Name = "plThuMucKhac";
			plThuMucKhac.Size = new System.Drawing.Size(278, 33);
			plThuMucKhac.TabIndex = 49;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(365, 205);
			base.Controls.Add(plThuMucKhac);
			base.Controls.Add(rbThuMucKhac);
			base.Controls.Add(rbThuMucCu);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCauHinhKhoiPhucTaiKhoan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fClearProfile_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			plThuMucKhac.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
