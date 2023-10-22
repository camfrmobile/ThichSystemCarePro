using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;
using MetroFramework;
using MetroFramework.Controls;

namespace maxcare
{
	public class fCauHinhTaoShortcut : Form
	{
		public static bool isOK;

		private string pathChromeOrigin = "";

		private JSON_Settings settings;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private BunifuDragControl bunifuDragControl1;

		private PictureBox pictureBox1;

		private Label label1;

		private MetroTextBox txtPathShortcut;

		private MetroButton metroButton1;

		private Label label2;

		private MetroTextBox txtPathChromeOrigin;

		private MetroButton metroButton2;

		public fCauHinhTaoShortcut()
		{
			InitializeComponent();
			settings = new JSON_Settings("configInteractGeneral");
			ChangeLanguage();
			isOK = false;
			string path = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
			string path2 = "C:\\Program Files (x64)\\Google\\Chrome\\Application\\chrome.exe";
			string path3 = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
			if (!File.Exists(path))
			{
				if (!File.Exists(path2))
				{
					if (File.Exists(path3))
					{
						pathChromeOrigin = path3;
					}
				}
				else
				{
					pathChromeOrigin = path2;
				}
			}
			else
			{
				pathChromeOrigin = path;
			}
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(metroButton1);
			Language.GetValue(label2);
			Language.GetValue(metroButton2);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			if (txtPathShortcut.Text.Trim() == "")
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p đươ\u0300ng dâ\u0303n đê\u0301n Thư mu\u0323c lưu Shortcut!"), 3);
				return;
			}
			if (txtPathChromeOrigin.Text.Trim() == "")
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p đươ\u0300ng dâ\u0303n đê\u0301n chrome.exe!"), 3);
				return;
			}
			if (!txtPathChromeOrigin.Text.Trim().EndsWith("chrome.exe"))
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đươ\u0300ng dâ\u0303n đê\u0301n chrome.exe không hơ\u0323p lê\u0323!"), 3);
				return;
			}
			settings.Update("txtPathShortcut", txtPathShortcut.Text.Trim());
			settings.Update("txtPathChromeOrigin", txtPathChromeOrigin.Text.Trim());
			settings.Save();
			isOK = true;
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void bunifuCustomLabel2_Click(object sender, EventArgs e)
		{
		}

		private void fClearProfile_Load(object sender, EventArgs e)
		{
			txtPathShortcut.Text = settings.GetValue("txtPathShortcut");
			if (txtPathShortcut.Text.Trim() == "" || !Directory.Exists(txtPathShortcut.Text.Trim()))
			{
				txtPathShortcut.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			}
			if (File.Exists(settings.GetValue("txtPathChromeOrigin")))
			{
				txtPathChromeOrigin.Text = settings.GetValue("txtPathChromeOrigin");
			}
			else
			{
				txtPathChromeOrigin.Text = pathChromeOrigin;
			}
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			txtPathShortcut.Text = MCommon.Common.SelectFolder();
		}

		private void metroButton2_Click(object sender, EventArgs e)
		{
			txtPathChromeOrigin.Text = MCommon.Common.SelectFile(Language.GetValue("Cho\u0323n File"), "");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCauHinhTaoShortcut));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			label1 = new System.Windows.Forms.Label();
			txtPathShortcut = new MetroFramework.Controls.MetroTextBox();
			metroButton1 = new MetroFramework.Controls.MetroButton();
			label2 = new System.Windows.Forms.Label();
			txtPathChromeOrigin = new MetroFramework.Controls.MetroTextBox();
			metroButton2 = new MetroFramework.Controls.MetroButton();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
			bunifuCards1.Size = new System.Drawing.Size(594, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(594, 32);
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
			btnMinimize.Location = new System.Drawing.Point(562, 0);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(594, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Câ\u0301u hi\u0300nh ta\u0323o Shortcut Chrome";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(303, 139);
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
			btnAdd.Location = new System.Drawing.Point(199, 139);
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
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(33, 60);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(105, 16);
			label1.TabIndex = 5;
			label1.Text = "Nơi lưu Shortcut:";
			txtPathShortcut.CustomButton.Image = null;
			txtPathShortcut.CustomButton.Location = new System.Drawing.Point(330, 1);
			txtPathShortcut.CustomButton.Name = "";
			txtPathShortcut.CustomButton.Size = new System.Drawing.Size(21, 21);
			txtPathShortcut.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			txtPathShortcut.CustomButton.TabIndex = 1;
			txtPathShortcut.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			txtPathShortcut.CustomButton.UseSelectable = true;
			txtPathShortcut.CustomButton.Visible = false;
			txtPathShortcut.Lines = new string[0];
			txtPathShortcut.Location = new System.Drawing.Point(157, 58);
			txtPathShortcut.MaxLength = 32767;
			txtPathShortcut.Name = "txtPathShortcut";
			txtPathShortcut.PasswordChar = '\0';
			txtPathShortcut.ScrollBars = System.Windows.Forms.ScrollBars.None;
			txtPathShortcut.SelectedText = "";
			txtPathShortcut.SelectionLength = 0;
			txtPathShortcut.SelectionStart = 0;
			txtPathShortcut.ShortcutsEnabled = true;
			txtPathShortcut.Size = new System.Drawing.Size(352, 23);
			txtPathShortcut.TabIndex = 6;
			txtPathShortcut.UseSelectable = true;
			txtPathShortcut.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
			txtPathShortcut.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton1.Location = new System.Drawing.Point(515, 58);
			metroButton1.Name = "metroButton1";
			metroButton1.Size = new System.Drawing.Size(47, 24);
			metroButton1.TabIndex = 7;
			metroButton1.Text = "Cho\u0323n";
			metroButton1.UseSelectable = true;
			metroButton1.Click += new System.EventHandler(metroButton1_Click);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(33, 91);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(125, 16);
			label2.TabIndex = 5;
			label2.Text = "Đươ\u0300ng dâ\u0303n Chrome:";
			txtPathChromeOrigin.CustomButton.Image = null;
			txtPathChromeOrigin.CustomButton.Location = new System.Drawing.Point(330, 1);
			txtPathChromeOrigin.CustomButton.Name = "";
			txtPathChromeOrigin.CustomButton.Size = new System.Drawing.Size(21, 21);
			txtPathChromeOrigin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			txtPathChromeOrigin.CustomButton.TabIndex = 1;
			txtPathChromeOrigin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			txtPathChromeOrigin.CustomButton.UseSelectable = true;
			txtPathChromeOrigin.CustomButton.Visible = false;
			txtPathChromeOrigin.Lines = new string[1] { "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe" };
			txtPathChromeOrigin.Location = new System.Drawing.Point(157, 89);
			txtPathChromeOrigin.MaxLength = 32767;
			txtPathChromeOrigin.Name = "txtPathChromeOrigin";
			txtPathChromeOrigin.PasswordChar = '\0';
			txtPathChromeOrigin.ScrollBars = System.Windows.Forms.ScrollBars.None;
			txtPathChromeOrigin.SelectedText = "";
			txtPathChromeOrigin.SelectionLength = 0;
			txtPathChromeOrigin.SelectionStart = 0;
			txtPathChromeOrigin.ShortcutsEnabled = true;
			txtPathChromeOrigin.Size = new System.Drawing.Size(352, 23);
			txtPathChromeOrigin.TabIndex = 6;
			txtPathChromeOrigin.Text = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
			txtPathChromeOrigin.UseSelectable = true;
			txtPathChromeOrigin.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
			txtPathChromeOrigin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton2.Location = new System.Drawing.Point(515, 89);
			metroButton2.Name = "metroButton2";
			metroButton2.Size = new System.Drawing.Size(47, 24);
			metroButton2.TabIndex = 7;
			metroButton2.Text = "Cho\u0323n";
			metroButton2.UseSelectable = true;
			metroButton2.Click += new System.EventHandler(metroButton2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(594, 187);
			base.Controls.Add(metroButton2);
			base.Controls.Add(metroButton1);
			base.Controls.Add(txtPathChromeOrigin);
			base.Controls.Add(label2);
			base.Controls.Add(txtPathShortcut);
			base.Controls.Add(label1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCauHinhTaoShortcut";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fClearProfile_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
