using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fImportUseragent : Form
	{
		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private Label label8;

		private Label lblStatus;

		private RichTextBox txtUseragent;

		private Label label1;

		private NumericUpDown nudTaiKhoanPerUa;

		private CheckBox ckbKhongNhapTaiKhoanDaCo;

		private Label label2;

		private RadioButton rbNgauNhien;

		private RadioButton rbLanLuot;

		public fImportUseragent()
		{
			InitializeComponent();
			ChangeLanguage();
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(lblStatus);
			Language.GetValue(label1);
			Language.GetValue(label8);
			Language.GetValue(label2);
			Language.GetValue(rbLanLuot);
			Language.GetValue(rbNgauNhien);
			Language.GetValue(ckbKhongNhapTaiKhoanDaCo);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUseragent.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				List<string> list = new List<string>();
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p thêm Useragent!"), 3);
					return;
				}
				int num = Convert.ToInt32(nudTaiKhoanPerUa.Value);
				for (int i = 0; i < lst.Count; i++)
				{
					for (int j = 0; j < num; j++)
					{
						list.Add(lst[i]);
					}
				}
				if (rbNgauNhien.Checked)
				{
					list = MCommon.Common.ShuffleList(list);
				}
				Queue<string> queue = new Queue<string>(list);
				for (int k = 0; k < fMain.remote.dtgvAcc.Rows.Count; k++)
				{
					if (Convert.ToBoolean(fMain.remote.GetCellAccount(k, "cChose")) && (!(fMain.remote.GetCellAccount(k, "cUseragent") != "") || !ckbKhongNhapTaiKhoanDaCo.Checked))
					{
						if (queue.Count == 0)
						{
							break;
						}
						string text = queue.Dequeue().Replace("'", "''");
						if (CommonSQL.UpdateFieldToAccount(fMain.remote.GetCellAccount(k, "cId"), "useragent", text))
						{
							fMain.remote.SetCellAccount(k, "cUseragent", text);
						}
					}
				}
				if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Nhâ\u0323p thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
				{
					Close();
				}
			}
			catch (Exception)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txbNameFile_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				BtnAdd_Click(null, null);
			}
		}

		private void txtComment_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtUseragent.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblStatus.Text = string.Format(Language.GetValue("Danh sa\u0301ch Useragent ({0}):"), lst.Count);
			}
			catch
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fImportUseragent));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			label8 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			txtUseragent = new System.Windows.Forms.RichTextBox();
			label1 = new System.Windows.Forms.Label();
			nudTaiKhoanPerUa = new System.Windows.Forms.NumericUpDown();
			ckbKhongNhapTaiKhoanDaCo = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			rbNgauNhien = new System.Windows.Forms.RadioButton();
			rbLanLuot = new System.Windows.Forms.RadioButton();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTaiKhoanPerUa).BeginInit();
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
			bunifuCards1.Size = new System.Drawing.Size(477, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(477, 32);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(4, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 77;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(445, 0);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(477, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Nhâ\u0323p Useragent";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(245, 342);
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
			btnAdd.Location = new System.Drawing.Point(136, 342);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Xa\u0301c nhâ\u0323n";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(301, 252);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(142, 16);
			label8.TabIndex = 5;
			label8.Text = "(Mỗi useragent 1 dòng)";
			lblStatus.AutoSize = true;
			lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.Location = new System.Drawing.Point(30, 47);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(155, 16);
			lblStatus.TabIndex = 6;
			lblStatus.Text = "Danh sa\u0301ch Useragent (0):";
			txtUseragent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtUseragent.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUseragent.Location = new System.Drawing.Point(34, 66);
			txtUseragent.Name = "txtUseragent";
			txtUseragent.Size = new System.Drawing.Size(409, 181);
			txtUseragent.TabIndex = 118;
			txtUseragent.Text = "";
			txtUseragent.WordWrap = false;
			txtUseragent.TextChanged += new System.EventHandler(txtComment_TextChanged);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(31, 252);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(147, 16);
			label1.TabIndex = 119;
			label1.Text = "Sô\u0301 ta\u0300i khoa\u0309n/Useragent:";
			nudTaiKhoanPerUa.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudTaiKhoanPerUa.Location = new System.Drawing.Point(184, 250);
			nudTaiKhoanPerUa.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
			nudTaiKhoanPerUa.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudTaiKhoanPerUa.Name = "nudTaiKhoanPerUa";
			nudTaiKhoanPerUa.Size = new System.Drawing.Size(69, 23);
			nudTaiKhoanPerUa.TabIndex = 120;
			nudTaiKhoanPerUa.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			ckbKhongNhapTaiKhoanDaCo.AutoSize = true;
			ckbKhongNhapTaiKhoanDaCo.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKhongNhapTaiKhoanDaCo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ckbKhongNhapTaiKhoanDaCo.Location = new System.Drawing.Point(33, 303);
			ckbKhongNhapTaiKhoanDaCo.Name = "ckbKhongNhapTaiKhoanDaCo";
			ckbKhongNhapTaiKhoanDaCo.Size = new System.Drawing.Size(311, 20);
			ckbKhongNhapTaiKhoanDaCo.TabIndex = 121;
			ckbKhongNhapTaiKhoanDaCo.Text = "Không nhâ\u0323p va\u0300o như\u0303ng ta\u0300i khoa\u0309n đa\u0303 co\u0301 Useragent";
			ckbKhongNhapTaiKhoanDaCo.UseVisualStyleBackColor = true;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(30, 279);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(159, 16);
			label2.TabIndex = 119;
			label2.Text = "Tu\u0300y cho\u0323n nhâ\u0323p Useragent:";
			rbNgauNhien.AutoSize = true;
			rbNgauNhien.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNgauNhien.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbNgauNhien.Location = new System.Drawing.Point(274, 277);
			rbNgauNhien.Name = "rbNgauNhien";
			rbNgauNhien.Size = new System.Drawing.Size(90, 20);
			rbNgauNhien.TabIndex = 122;
			rbNgauNhien.Text = "Ngâ\u0303u nhiên";
			rbNgauNhien.UseVisualStyleBackColor = true;
			rbLanLuot.AutoSize = true;
			rbLanLuot.Checked = true;
			rbLanLuot.Cursor = System.Windows.Forms.Cursors.Hand;
			rbLanLuot.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbLanLuot.Location = new System.Drawing.Point(184, 277);
			rbLanLuot.Name = "rbLanLuot";
			rbLanLuot.Size = new System.Drawing.Size(72, 20);
			rbLanLuot.TabIndex = 122;
			rbLanLuot.TabStop = true;
			rbLanLuot.Text = "Lâ\u0300n lươ\u0323t";
			rbLanLuot.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(477, 388);
			base.Controls.Add(rbLanLuot);
			base.Controls.Add(rbNgauNhien);
			base.Controls.Add(ckbKhongNhapTaiKhoanDaCo);
			base.Controls.Add(nudTaiKhoanPerUa);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(txtUseragent);
			base.Controls.Add(label8);
			base.Controls.Add(lblStatus);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fImportUseragent";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTaiKhoanPerUa).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
