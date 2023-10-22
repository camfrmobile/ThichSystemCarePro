using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fQuetNhom : Form
	{
		public static bool isOK;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private Panel panel1;

		private MetroButton btnCauHinh;

		private Label label3;

		private Button btnSave;

		private RadioButton radioButton2;

		private RadioButton radioButton3;

		private RadioButton radioButton1;

		private Label label1;

		public fQuetNhom()
		{
			InitializeComponent();
			ChangeLanguage();
			isOK = false;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label3);
			Language.GetValue(btnCauHinh);
			Language.GetValue(btnSave);
			Language.GetValue(btnCancel);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fCauHinhChung());
		}

		private void fMoTrinhDuyet_Load(object sender, EventArgs e)
		{
		}

		private void btnSave_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fQuetNhom));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			panel1 = new System.Windows.Forms.Panel();
			btnCauHinh = new MetroFramework.Controls.MetroButton();
			btnSave = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			radioButton1 = new System.Windows.Forms.RadioButton();
			label1 = new System.Windows.Forms.Label();
			radioButton2 = new System.Windows.Forms.RadioButton();
			radioButton3 = new System.Windows.Forms.RadioButton();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(402, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(402, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 17;
			pictureBox1.TabStop = false;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(369, -1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(402, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Cấu hình Que\u0301t nho\u0301m";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(208, 181);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 4;
			btnCancel.Text = "Hu\u0309y";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(radioButton2);
			panel1.Controls.Add(radioButton3);
			panel1.Controls.Add(radioButton1);
			panel1.Controls.Add(btnCauHinh);
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(btnCancel);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(label3);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(403, 223);
			panel1.TabIndex = 5;
			btnCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCauHinh.Location = new System.Drawing.Point(147, 61);
			btnCauHinh.Name = "btnCauHinh";
			btnCauHinh.Size = new System.Drawing.Size(75, 23);
			btnCauHinh.TabIndex = 5;
			btnCauHinh.Text = "Cấu hình";
			btnCauHinh.UseSelectable = true;
			btnCauHinh.Click += new System.EventHandler(metroButton1_Click);
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnSave.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSave.FlatAppearance.BorderSize = 0;
			btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSave.ForeColor = System.Drawing.Color.White;
			btnSave.Location = new System.Drawing.Point(73, 181);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(119, 29);
			btnSave.TabIndex = 20;
			btnSave.Text = "Tiê\u0301n ha\u0300nh que\u0301t";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(34, 64);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(99, 16);
			label3.TabIndex = 7;
			label3.Text = "Cấu hình đổi IP:";
			radioButton1.AutoSize = true;
			radioButton1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			radioButton1.Location = new System.Drawing.Point(147, 142);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(212, 20);
			radioButton1.TabIndex = 22;
			radioButton1.TabStop = true;
			radioButton1.Text = "Chi\u0309 xuâ\u0301t nho\u0301m không kiê\u0309m duyê\u0323t";
			radioButton1.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(34, 92);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(65, 16);
			label1.TabIndex = 7;
			label1.Text = "Tu\u0300y cho\u0323n:";
			radioButton2.AutoSize = true;
			radioButton2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			radioButton2.Location = new System.Drawing.Point(147, 116);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(174, 20);
			radioButton2.TabIndex = 22;
			radioButton2.TabStop = true;
			radioButton2.Text = "Chi\u0309 xuâ\u0301t nho\u0301m kiê\u0309m duyê\u0323t";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton3.AutoSize = true;
			radioButton3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			radioButton3.Location = new System.Drawing.Point(147, 90);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new System.Drawing.Size(124, 20);
			radioButton3.TabIndex = 22;
			radioButton3.TabStop = true;
			radioButton3.Text = "Xuâ\u0301t tâ\u0301t ca\u0309 nho\u0301m";
			radioButton3.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(403, 223);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fQuetNhom";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fMoTrinhDuyet_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
	}
}
