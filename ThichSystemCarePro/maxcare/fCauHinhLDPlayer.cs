using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fCauHinhLDPlayer : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel panel1;

		private BunifuDragControl bunifuDragControl1;

		private ToolTip toolTip1;

		private Button btnCancel;

		private Button btnSave;

		private RadioButton rbBackupNhe;

		private Label label10;

		private BunifuCards bunifuCards2;

		private Panel pnlHeader;

		private Button button2;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private RadioButton rbBackupFull;

		private RadioButton rbBackupThuong;

		private Label label5;

		private NumericUpDown nudSizeH;

		private NumericUpDown nudDPI;

		private NumericUpDown nudSizeW;

		private ComboBox cbbRAM;

		private ComboBox cbbCPU;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private CheckBox ckbEnableGPS;

		public fCauHinhLDPlayer()
		{
			InitializeComponent();
			settings = new JSON_Settings("configLDPlayer");
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(btnSave);
			Language.GetValue(btnCancel);
			Language.GetValue(label10);
			Language.GetValue(rbBackupNhe);
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FConfigGenneral_Load(object sender, EventArgs e)
		{
			cbbCPU.Text = settings.GetValue("cbbCPU", "1 cores (Khuyê\u0301n nghi\u0323)");
			cbbRAM.Text = settings.GetValue("cbbRAM", "1024M (Khuyê\u0301n nghi\u0323)");
			nudSizeW.Value = settings.GetValueInt("nudSizeW", 320);
			nudSizeH.Value = settings.GetValueInt("nudSizeH", 480);
			nudDPI.Value = settings.GetValueInt("nudDPI", 120);
			ckbEnableGPS.Checked = settings.GetValueBool("ckbEnableGPS");
			switch (settings.GetValueInt("typeBackupDataFb"))
			{
			case 0:
				rbBackupNhe.Checked = true;
				break;
			case 1:
				rbBackupThuong.Checked = true;
				break;
			case 2:
				rbBackupFull.Checked = true;
				break;
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				settings.Update("cbbCPU", cbbCPU.Text);
				settings.Update("cbbRAM", cbbRAM.Text);
				settings.Update("nudSizeW", nudSizeW.Value);
				settings.Update("nudSizeH", nudSizeH.Value);
				settings.Update("nudDPI", nudDPI.Value);
				settings.Update("ckbEnableGPS", ckbEnableGPS.Checked);
				int num = 0;
				if (rbBackupNhe.Checked)
				{
					num = 0;
				}
				else if (rbBackupThuong.Checked)
				{
					num = 1;
				}
				else if (rbBackupFull.Checked)
				{
					num = 2;
				}
				settings.Update("typeBackupDataFb", num);
				settings.Save();
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
				{
					Close();
				}
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Lỗi!"));
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCauHinhLDPlayer));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			panel1 = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			nudSizeH = new System.Windows.Forms.NumericUpDown();
			nudDPI = new System.Windows.Forms.NumericUpDown();
			nudSizeW = new System.Windows.Forms.NumericUpDown();
			cbbRAM = new System.Windows.Forms.ComboBox();
			cbbCPU = new System.Windows.Forms.ComboBox();
			bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			rbBackupFull = new System.Windows.Forms.RadioButton();
			rbBackupThuong = new System.Windows.Forms.RadioButton();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			rbBackupNhe = new System.Windows.Forms.RadioButton();
			label1 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			ckbEnableGPS = new System.Windows.Forms.CheckBox();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSizeH).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDPI).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSizeW).BeginInit();
			bunifuCards2.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
			bunifuCards1.Size = new System.Drawing.Size(0, 38);
			bunifuCards1.TabIndex = 12;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(ckbEnableGPS);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(nudSizeH);
			panel1.Controls.Add(nudDPI);
			panel1.Controls.Add(nudSizeW);
			panel1.Controls.Add(cbbRAM);
			panel1.Controls.Add(cbbCPU);
			panel1.Controls.Add(bunifuCards2);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(rbBackupFull);
			panel1.Controls.Add(rbBackupThuong);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(rbBackupNhe);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label10);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(302, 325);
			panel1.TabIndex = 37;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(137, 108);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(26, 25);
			label5.TabIndex = 164;
			label5.Text = "X";
			nudSizeH.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudSizeH.Location = new System.Drawing.Point(167, 109);
			nudSizeH.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
			nudSizeH.Name = "nudSizeH";
			nudSizeH.Size = new System.Drawing.Size(59, 23);
			nudSizeH.TabIndex = 163;
			nudDPI.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudDPI.Location = new System.Drawing.Point(74, 138);
			nudDPI.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
			nudDPI.Name = "nudDPI";
			nudDPI.Size = new System.Drawing.Size(59, 23);
			nudDPI.TabIndex = 163;
			nudSizeW.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudSizeW.Location = new System.Drawing.Point(74, 109);
			nudSizeW.Maximum = new decimal(new int[4] { 1215752191, 23, 0, 0 });
			nudSizeW.Name = "nudSizeW";
			nudSizeW.Size = new System.Drawing.Size(59, 23);
			nudSizeW.TabIndex = 163;
			cbbRAM.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbRAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbRAM.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbRAM.FormattingEnabled = true;
			cbbRAM.Items.AddRange(new object[9] { "256M", "512M", "768M", "1024M (Khuyê\u0301n nghi\u0323)", "1536M", "2048M", "3072M", "4096M", "8192M" });
			cbbRAM.Location = new System.Drawing.Point(74, 80);
			cbbRAM.Name = "cbbRAM";
			cbbRAM.Size = new System.Drawing.Size(152, 24);
			cbbRAM.TabIndex = 162;
			cbbCPU.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbCPU.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbCPU.FormattingEnabled = true;
			cbbCPU.Items.AddRange(new object[5] { "1 cores (Khuyê\u0301n nghi\u0323)", "2 cores", "3 cores", "4 cores", "6 cores" });
			cbbCPU.Location = new System.Drawing.Point(74, 50);
			cbbCPU.Name = "cbbCPU";
			cbbCPU.Size = new System.Drawing.Size(152, 24);
			cbbCPU.TabIndex = 162;
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
			bunifuCards2.Size = new System.Drawing.Size(300, 37);
			bunifuCards2.TabIndex = 40;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(300, 31);
			pnlHeader.TabIndex = 9;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = (System.Drawing.Image)resources.GetObject("button2.Image");
			button2.Location = new System.Drawing.Point(269, 1);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(300, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh LDPlayer";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(155, 283);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 20;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(55, 283);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(92, 29);
			btnSave.TabIndex = 19;
			btnSave.Text = "Lưu";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(BtnSave_Click);
			rbBackupFull.AutoSize = true;
			rbBackupFull.Cursor = System.Windows.Forms.Cursors.Hand;
			rbBackupFull.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbBackupFull.Location = new System.Drawing.Point(73, 229);
			rbBackupFull.Name = "rbBackupFull";
			rbBackupFull.Size = new System.Drawing.Size(108, 20);
			rbBackupFull.TabIndex = 161;
			rbBackupFull.Text = "Backup đâ\u0300y đu\u0309";
			rbBackupFull.UseVisualStyleBackColor = true;
			rbBackupThuong.AutoSize = true;
			rbBackupThuong.Cursor = System.Windows.Forms.Cursors.Hand;
			rbBackupThuong.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbBackupThuong.Location = new System.Drawing.Point(73, 206);
			rbBackupThuong.Name = "rbBackupThuong";
			rbBackupThuong.Size = new System.Drawing.Size(110, 20);
			rbBackupThuong.TabIndex = 161;
			rbBackupThuong.Text = "Backup thươ\u0300ng";
			rbBackupThuong.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(32, 140);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(32, 16);
			label4.TabIndex = 158;
			label4.Text = "DPI:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(32, 111);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(39, 16);
			label3.TabIndex = 158;
			label3.Text = "SIZE:";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(32, 83);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(39, 16);
			label2.TabIndex = 158;
			label2.Text = "RAM:";
			rbBackupNhe.AutoSize = true;
			rbBackupNhe.Checked = true;
			rbBackupNhe.Cursor = System.Windows.Forms.Cursors.Hand;
			rbBackupNhe.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbBackupNhe.Location = new System.Drawing.Point(73, 183);
			rbBackupNhe.Name = "rbBackupNhe";
			rbBackupNhe.Size = new System.Drawing.Size(201, 20);
			rbBackupNhe.TabIndex = 161;
			rbBackupNhe.TabStop = true;
			rbBackupNhe.Text = "Backup siêu nhe\u0323 (Khuyê\u0301n nghi\u0323)";
			rbBackupNhe.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(32, 53);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(36, 16);
			label1.TabIndex = 158;
			label1.Text = "CPU:";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(32, 164);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(140, 16);
			label10.TabIndex = 158;
			label10.Text = "Backup data Facebook:";
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			ckbEnableGPS.AutoSize = true;
			ckbEnableGPS.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbEnableGPS.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbEnableGPS.Location = new System.Drawing.Point(35, 252);
			ckbEnableGPS.Name = "ckbEnableGPS";
			ckbEnableGPS.Size = new System.Drawing.Size(92, 20);
			ckbEnableGPS.TabIndex = 165;
			ckbEnableGPS.Text = "Enable GPS";
			ckbEnableGPS.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(302, 325);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCauHinhLDPlayer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình chung";
			base.Load += new System.EventHandler(FConfigGenneral_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSizeH).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDPI).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSizeW).EndInit();
			bunifuCards2.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
