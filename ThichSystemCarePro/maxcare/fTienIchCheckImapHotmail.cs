using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fTienIchCheckImapHotmail : Form
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

		private GroupBox grDaTao;

		private RichTextBox txtDaTao;

		private GroupBox groupBox1;

		private MetroButton btnNhapTuFile;

		private TextBox txtNhapTuFile;

		private RadioButton rbTuNhap;

		private RadioButton rbNhapTuFile;

		private GroupBox grChuaTao;

		private RichTextBox txtChuaTao;

		private Label lblStatus;

		public fTienIchCheckImapHotmail()
		{
			InitializeComponent();
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
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
				List<string> list = new List<string>();
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
					list = File.ReadAllLines(text).ToList();
				}
				else if (rbTuNhap.Checked)
				{
					list = txtInput.Lines.ToList();
				}
				int iThread = 0;
				int num = 10;
				lblStatus.Invoke((MethodInvoker)delegate
				{
					lblStatus.Visible = true;
				});
				int num2 = 0;
				while (num2 < list.Count)
				{
					if (iThread < num)
					{
						Interlocked.Increment(ref iThread);
						string mail = list[num2++];
						new Thread((ThreadStart)delegate
						{
							if (CheckAccountMail(mail))
							{
								AddRowIntoTextbox(txtDaTao, mail);
							}
							else
							{
								AddRowIntoTextbox(txtChuaTao, mail);
							}
							Interlocked.Decrement(ref iThread);
						}).Start();
					}
					else
					{
						Application.DoEvents();
						MCommon.Common.DelayTime(1.0);
					}
				}
				while (iThread > 0)
				{
					MCommon.Common.DelayTime(1.0);
				}
				lblStatus.Invoke((MethodInvoker)delegate
				{
					lblStatus.Visible = false;
				});
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã check xong!"));
			}
			catch (Exception)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void AddRowIntoTextbox(RichTextBox txt, string content)
		{
			txt.Invoke((MethodInvoker)delegate
			{
				Application.DoEvents();
				RichTextBox richTextBox = txt;
				richTextBox.Text = richTextBox.Text + content + "\r\n";
			});
		}

		private bool CheckAccountMail(string mail)
		{
			try
			{
				string text = mail.Split('|')[0];
				string text2 = mail.Split('|')[1];
				if (text == "" || text2 == "")
				{
					return false;
				}
				return MCommon.Common.CheckAccountHotmail(text, text2) == "1";
			}
			catch
			{
				return false;
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
				List<string> lst = txtDaTao.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				grDaTao.Text = string.Format(Language.GetValue("Live ({0})"), lst.Count.ToString());
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

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txtChuaTao.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				grChuaTao.Text = string.Format(Language.GetValue("Die ({0})"), lst.Count.ToString());
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
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			panel1 = new System.Windows.Forms.Panel();
			lblStatus = new System.Windows.Forms.Label();
			grChuaTao = new System.Windows.Forms.GroupBox();
			txtChuaTao = new System.Windows.Forms.RichTextBox();
			grDaTao = new System.Windows.Forms.GroupBox();
			txtDaTao = new System.Windows.Forms.RichTextBox();
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
			grChuaTao.SuspendLayout();
			grDaTao.SuspendLayout();
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
			bunifuCards1.Size = new System.Drawing.Size(466, 47);
			bunifuCards1.TabIndex = 12;
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(lblStatus);
			panel1.Controls.Add(grChuaTao);
			panel1.Controls.Add(grDaTao);
			panel1.Controls.Add(groupBox1);
			panel1.Controls.Add(btnAdd);
			panel1.Controls.Add(bunifuCards2);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(795, 404);
			panel1.TabIndex = 37;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			lblStatus.AutoSize = true;
			lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
			lblStatus.Location = new System.Drawing.Point(480, 59);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(71, 16);
			lblStatus.TabIndex = 52;
			lblStatus.Text = "Checking...";
			lblStatus.Visible = false;
			grChuaTao.Controls.Add(txtChuaTao);
			grChuaTao.ForeColor = System.Drawing.Color.DarkRed;
			grChuaTao.Location = new System.Drawing.Point(566, 91);
			grChuaTao.Name = "grChuaTao";
			grChuaTao.Size = new System.Drawing.Size(221, 307);
			grChuaTao.TabIndex = 51;
			grChuaTao.TabStop = false;
			grChuaTao.Text = "Die (0)";
			txtChuaTao.Dock = System.Windows.Forms.DockStyle.Fill;
			txtChuaTao.Location = new System.Drawing.Point(3, 19);
			txtChuaTao.Name = "txtChuaTao";
			txtChuaTao.Size = new System.Drawing.Size(215, 285);
			txtChuaTao.TabIndex = 50;
			txtChuaTao.Text = "";
			txtChuaTao.WordWrap = false;
			txtChuaTao.TextChanged += new System.EventHandler(richTextBox1_TextChanged);
			grDaTao.Controls.Add(txtDaTao);
			grDaTao.ForeColor = System.Drawing.Color.DarkGreen;
			grDaTao.Location = new System.Drawing.Point(339, 91);
			grDaTao.Name = "grDaTao";
			grDaTao.Size = new System.Drawing.Size(221, 307);
			grDaTao.TabIndex = 51;
			grDaTao.TabStop = false;
			grDaTao.Text = "Live (0)";
			txtDaTao.Dock = System.Windows.Forms.DockStyle.Fill;
			txtDaTao.Location = new System.Drawing.Point(3, 19);
			txtDaTao.Name = "txtDaTao";
			txtDaTao.Size = new System.Drawing.Size(215, 285);
			txtDaTao.TabIndex = 50;
			txtDaTao.Text = "";
			txtDaTao.WordWrap = false;
			txtDaTao.TextChanged += new System.EventHandler(txtOutput_TextChanged);
			groupBox1.Controls.Add(btnNhapTuFile);
			groupBox1.Controls.Add(txtInput);
			groupBox1.Controls.Add(txtNhapTuFile);
			groupBox1.Controls.Add(rbTuNhap);
			groupBox1.Controls.Add(rbNhapTuFile);
			groupBox1.Location = new System.Drawing.Point(6, 40);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(316, 358);
			groupBox1.TabIndex = 51;
			groupBox1.TabStop = false;
			groupBox1.Text = "Input: Email|Pass mail";
			btnNhapTuFile.Cursor = System.Windows.Forms.Cursors.Hand;
			btnNhapTuFile.Location = new System.Drawing.Point(243, 22);
			btnNhapTuFile.Name = "btnNhapTuFile";
			btnNhapTuFile.Size = new System.Drawing.Size(64, 24);
			btnNhapTuFile.TabIndex = 2;
			btnNhapTuFile.Text = "Chọn";
			btnNhapTuFile.UseSelectable = true;
			btnNhapTuFile.Click += new System.EventHandler(btnNhapTuFile_Click);
			txtInput.Location = new System.Drawing.Point(30, 75);
			txtInput.Name = "txtInput";
			txtInput.Size = new System.Drawing.Size(277, 277);
			txtInput.TabIndex = 50;
			txtInput.Text = "";
			txtInput.WordWrap = false;
			txtInput.TextChanged += new System.EventHandler(TxtComment_TextChanged);
			txtNhapTuFile.Location = new System.Drawing.Point(110, 22);
			txtNhapTuFile.Name = "txtNhapTuFile";
			txtNhapTuFile.Size = new System.Drawing.Size(127, 23);
			txtNhapTuFile.TabIndex = 1;
			rbTuNhap.AutoSize = true;
			rbTuNhap.Checked = true;
			rbTuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTuNhap.Location = new System.Drawing.Point(9, 49);
			rbTuNhap.Name = "rbTuNhap";
			rbTuNhap.Size = new System.Drawing.Size(95, 20);
			rbTuNhap.TabIndex = 0;
			rbTuNhap.TabStop = true;
			rbTuNhap.Text = "Tự nhập (0)";
			rbTuNhap.UseVisualStyleBackColor = true;
			rbTuNhap.CheckedChanged += new System.EventHandler(rbTuNhap_CheckedChanged);
			rbNhapTuFile.AutoSize = true;
			rbNhapTuFile.Cursor = System.Windows.Forms.Cursors.Hand;
			rbNhapTuFile.Location = new System.Drawing.Point(9, 23);
			rbNhapTuFile.Name = "rbNhapTuFile";
			rbNhapTuFile.Size = new System.Drawing.Size(95, 20);
			rbNhapTuFile.TabIndex = 0;
			rbNhapTuFile.Text = "Nhập từ File";
			rbNhapTuFile.UseVisualStyleBackColor = true;
			rbNhapTuFile.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
			btnAdd.BackColor = System.Drawing.Color.Green;
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(339, 49);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(135, 36);
			btnAdd.TabIndex = 45;
			btnAdd.Text = "Check";
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
			bunifuCards2.Size = new System.Drawing.Size(793, 37);
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
			pnlHeader.Size = new System.Drawing.Size(793, 31);
			pnlHeader.TabIndex = 9;
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.FlatAppearance.BorderSize = 0;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button2.ForeColor = System.Drawing.Color.White;
			button2.Image = maxcare.Properties.Resources.btnMinimize_Image;
			button2.Location = new System.Drawing.Point(762, 1);
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
			lblTitle.Size = new System.Drawing.Size(793, 31);
			lblTitle.TabIndex = 12;
			lblTitle.Text = "Check Imap Hotmail, Yandex";
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
			base.ClientSize = new System.Drawing.Size(795, 404);
			base.Controls.Add(panel1);
			base.Controls.Add(bunifuCards1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fTienIchCheckImapHotmail";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình chung";
			base.Load += new System.EventHandler(fTienIchLocTrung_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			grChuaTao.ResumeLayout(false);
			grDaTao.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			bunifuCards2.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
