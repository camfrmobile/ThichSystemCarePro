using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fTienIchLocTrung : Form
	{
		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel panel1;

		private BunifuDragControl bunifuDragControl1;

		private ToolTip toolTip1;

		private BunifuCards bunifuCards2;

		private Panel pnlHeader;

		private Button button2;

		private PictureBox pictureBox1;

		private Button btnMinimize;

		private BunifuCustomLabel lblTitle;

		private Button btnAdd;

		private RichTextBox txtInput;

		private GroupBox groupBox2;

		private RichTextBox txtOutput;

		private GroupBox groupBox1;

		private MetroButton btnNhapTuFile;

		private TextBox txtNhapTuFile;

		private RadioButton rbTuNhap;

		private RadioButton rbNhapTuFile;

		public fTienIchLocTrung()
		{
			InitializeComponent();
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(lblTitle);
			Language.GetValue(rbNhapTuFile);
			Language.GetValue(btnNhapTuFile);
			Language.GetValue(rbTuNhap);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> source = new List<string>();
				string text = txtNhapTuFile.Text.Trim();
				if (rbNhapTuFile.Checked)
				{
					if (text.EndsWith(".txt"))
					{
						if (!File.Exists(text))
						{
							MessageBoxHelper.ShowMessageBox(Language.GetValue("File dữ liệu nhập không tồn tại!"), 2);
						}
					}
					else
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("File nhập vào chỉ hỗ trợ đối với File (.txt)!"), 2);
					}
				}
				if (rbNhapTuFile.Checked)
				{
					source = File.ReadAllLines(text).ToList();
				}
				else if (rbTuNhap.Checked)
				{
					source = txtInput.Lines.ToList();
				}
				List<string> list = source.Distinct().ToList();
				txtOutput.Lines = list.ToArray();
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã lọc xong!"));
			}
			catch (Exception)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void TxtComment_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtInput.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				rbTuNhap.Text = string.Format(Language.GetValue("Tự nhập ({0})"), lst.Count.ToString());
			}
			catch
			{
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			txtNhapTuFile.Enabled = rbNhapTuFile.Checked;
			btnNhapTuFile.Enabled = rbNhapTuFile.Checked;
		}

		private void rbTuNhap_CheckedChanged(object sender, EventArgs e)
		{
			txtInput.Enabled = rbTuNhap.Checked;
		}

		private void btnNhapTuFile_Click(object sender, EventArgs e)
		{
			txtNhapTuFile.Text = MCommon.Common.SelectFile();
		}

		private void txtOutput_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtOutput.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				groupBox2.Text = $"Output ({lst.Count.ToString()})";
			}
			catch
			{
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void fTienIchLocTrung_Load(object sender, EventArgs e)
		{
			radioButton1_CheckedChanged(null, null);
			rbTuNhap_CheckedChanged(null, null);
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
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			panel1 = new System.Windows.Forms.Panel();
			groupBox2 = new System.Windows.Forms.GroupBox();
			txtOutput = new System.Windows.Forms.RichTextBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			btnNhapTuFile = new MetroFramework.Controls.MetroButton();
			txtInput = new System.Windows.Forms.RichTextBox();
			txtNhapTuFile = new System.Windows.Forms.TextBox();
			rbTuNhap = new System.Windows.Forms.RadioButton();
			rbNhapTuFile = new System.Windows.Forms.RadioButton();
			btnAdd = new System.Windows.Forms.Button();
			bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			button2 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			panel1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
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
			bunifuCards1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(509, 47);
			bunifuCards1.TabIndex = 12;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(838, 270);
			panel1.TabIndex = 37;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox2.Controls.Add(txtOutput);
			groupBox2.Location = new System.Drawing.Point(469, 40);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(361, 223);
			groupBox2.TabIndex = 51;
			groupBox2.TabStop = false;
			groupBox2.Text = "Output (0)";
			txtOutput.Location = new System.Drawing.Point(6, 22);
			txtOutput.Name = "txtOutput";
			txtOutput.Size = new System.Drawing.Size(349, 194);
			txtOutput.TabIndex = 50;
			txtOutput.Text = "";
			txtOutput.WordWrap = false;
			txtOutput.TextChanged += new System.EventHandler(txtOutput_TextChanged);
			groupBox1.Controls.Add(btnNhapTuFile);
			groupBox1.Controls.Add(txtInput);
			groupBox1.Controls.Add(txtNhapTuFile);
			groupBox1.Controls.Add(rbTuNhap);
			groupBox1.Controls.Add(rbNhapTuFile);
			groupBox1.Location = new System.Drawing.Point(6, 40);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(361, 223);
			groupBox1.TabIndex = 51;
			groupBox1.TabStop = false;
			groupBox1.Text = "Input";
			btnNhapTuFile.Cursor = System.Windows.Forms.Cursors.Hand;
			btnNhapTuFile.Location = new System.Drawing.Point(287, 22);
			btnNhapTuFile.Name = "btnNhapTuFile";
			btnNhapTuFile.Size = new System.Drawing.Size(65, 24);
			btnNhapTuFile.TabIndex = 2;
			btnNhapTuFile.Text = "Chọn";
			btnNhapTuFile.UseSelectable = true;
			btnNhapTuFile.Click += new System.EventHandler(btnNhapTuFile_Click);
			txtInput.Location = new System.Drawing.Point(30, 75);
			txtInput.Name = "txtInput";
			txtInput.Size = new System.Drawing.Size(322, 141);
			txtInput.TabIndex = 50;
			txtInput.Text = "";
			txtInput.WordWrap = false;
			txtInput.TextChanged += new System.EventHandler(TxtComment_TextChanged);
			txtNhapTuFile.Location = new System.Drawing.Point(110, 22);
			txtNhapTuFile.Name = "txtNhapTuFile";
			txtNhapTuFile.Size = new System.Drawing.Size(171, 23);
			txtNhapTuFile.TabIndex = 1;
			rbTuNhap.AutoSize = true;
			rbTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTuNhap.Location = new System.Drawing.Point(9, 49);
			rbTuNhap.Name = "rbTuNhap";
			rbTuNhap.Size = new System.Drawing.Size(95, 20);
			rbTuNhap.TabIndex = 0;
			rbTuNhap.Text = "Tự nhập (0)";
			rbTuNhap.UseVisualStyleBackColor = true;
			rbTuNhap.CheckedChanged += new System.EventHandler(rbTuNhap_CheckedChanged);
			rbNhapTuFile.AutoSize = true;
			rbNhapTuFile.Checked = true;
			rbNhapTuFile.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNhapTuFile.Location = new System.Drawing.Point(9, 23);
			rbNhapTuFile.Name = "rbNhapTuFile";
			rbNhapTuFile.Size = new System.Drawing.Size(95, 20);
			rbNhapTuFile.TabIndex = 0;
			rbNhapTuFile.TabStop = true;
			rbNhapTuFile.Text = "Nhập từ File";
			rbNhapTuFile.UseVisualStyleBackColor = true;
			rbNhapTuFile.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			btnAdd.BackColor = System.Drawing.Color.Green;
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(379, 138);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(78, 29);
			btnAdd.TabIndex = 45;
			btnAdd.Text = "Start";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
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
			bunifuCards2.Size = new System.Drawing.Size(836, 37);
			bunifuCards2.TabIndex = 43;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(lblTitle);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(836, 31);
			pnlHeader.TabIndex = 9;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = maxcare.Properties.Resources.btnMinimize_Image;
			button2.Location = new System.Drawing.Point(805, 1);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(30, 30);
			button2.TabIndex = 77;
			button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = maxcare.Properties.Resources.icon_64;
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Location = new System.Drawing.Point(899, 1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(30, 30);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			lblTitle.BackColor = System.Drawing.Color.Transparent;
			lblTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
			lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblTitle.ForeColor = System.Drawing.Color.Black;
			lblTitle.Location = new System.Drawing.Point(0, 0);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(836, 31);
			lblTitle.TabIndex = 12;
			lblTitle.Text = "Lọc trùng dữ liệu";
			lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = lblTitle;
			bunifuDragControl1.Vertical = true;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(838, 270);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuCards1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fTienIchLocTrung";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình chung";
			base.Load += new System.EventHandler(fTienIchLocTrung_Load);
			panel1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			bunifuCards2.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
