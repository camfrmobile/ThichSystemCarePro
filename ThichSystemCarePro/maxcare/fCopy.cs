using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;

namespace maxcare
{
	public class fCopy : Form
	{
		private List<ComboBox> lstCbbDinhDang;

		private List<string> lst = new List<string>();

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private Label label1;

		private BunifuDragControl bunifuDragControl1;

		private ComboBox cbbDinhDang1;

		private ComboBox cbbDinhDang2;

		private ComboBox cbbDinhDang3;

		private ComboBox cbbDinhDang4;

		private Label label14;

		private ComboBox cbbDinhDang5;

		private Label label13;

		private ComboBox cbbDinhDang6;

		private Label label12;

		private ComboBox cbbDinhDang7;

		private Label label11;

		private Label label9;

		private Label label10;

		private ComboBox cbbDinhDang9;

		private ComboBox cbbDinhDang8;

		private Label label2;

		private Label label3;

		private Button button1;

		public fCopy(List<string> lstAcc)
		{
			InitializeComponent();
			lst = lstAcc;
			ChangeLanguage();
			lstCbbDinhDang = new List<ComboBox> { cbbDinhDang1, cbbDinhDang2, cbbDinhDang3, cbbDinhDang4, cbbDinhDang5, cbbDinhDang6, cbbDinhDang7, cbbDinhDang8, cbbDinhDang9 };
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(button1);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void SaveDinhDang()
		{
			try
			{
				string text = "";
				for (int i = 0; i < lstCbbDinhDang.Count; i++)
				{
					text = text + lstCbbDinhDang[i].SelectedIndex + "|";
				}
				text = text.TrimEnd('|');
				File.WriteAllText("settings\\format_copy.txt", text);
			}
			catch
			{
			}
		}

		private void LoadDinhDang()
		{
			try
			{
				if (File.Exists("settings\\format_copy.txt"))
				{
					string text = File.ReadAllText("settings\\format_copy.txt");
					for (int i = 0; i < lstCbbDinhDang.Count; i++)
					{
						lstCbbDinhDang[i].SelectedIndex = Convert.ToInt32(text.Split('|')[i]);
					}
				}
			}
			catch
			{
			}
		}

		private void ResetDinhDang()
		{
			try
			{
				for (int i = 0; i < lstCbbDinhDang.Count; i++)
				{
					lstCbbDinhDang[i].SelectedIndex = -1;
				}
			}
			catch
			{
			}
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				string text = "";
				int num = 0;
				int num2 = lstCbbDinhDang.Count - 1;
				while (num2 >= 0)
				{
					if (lstCbbDinhDang[num2].SelectedIndex == -1)
					{
						num2--;
						continue;
					}
					num = num2 + 1;
					break;
				}
				if (num == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("vui lo\u0300ng cho\u0323n đi\u0323nh da\u0323ng câ\u0300n copy!"), 3);
					return;
				}
				SaveDinhDang();
				int num3 = 0;
				for (int i = 0; i < lst.Count; i++)
				{
					text = "";
					string[] array = lst[i].Split('|');
					for (int j = 0; j < lstCbbDinhDang.Count; j++)
					{
						if (lstCbbDinhDang[j].SelectedIndex != -1)
						{
							text += array[lstCbbDinhDang[j].SelectedIndex];
						}
						text += "|";
					}
					text = text.TrimEnd('|');
					for (num3 = text.Split('|').Count(); num3 < num; num3++)
					{
						text += "|";
					}
					list.Add(text);
				}
				string text2 = string.Join("\r\n", list);
				Clipboard.SetText(text2);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Copy tha\u0300nh công!"));
				Close();
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Có lỗi xảy ra, vui lòng thử lại sau!"), 2);
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ResetDinhDang();
		}

		private void fCopy_Load(object sender, EventArgs e)
		{
			LoadDinhDang();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCopy));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			cbbDinhDang1 = new System.Windows.Forms.ComboBox();
			cbbDinhDang2 = new System.Windows.Forms.ComboBox();
			cbbDinhDang3 = new System.Windows.Forms.ComboBox();
			cbbDinhDang4 = new System.Windows.Forms.ComboBox();
			label14 = new System.Windows.Forms.Label();
			cbbDinhDang5 = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			cbbDinhDang6 = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			cbbDinhDang7 = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			cbbDinhDang9 = new System.Windows.Forms.ComboBox();
			cbbDinhDang8 = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
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
			bunifuCards1.Size = new System.Drawing.Size(1037, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1037, 32);
			pnlHeader.TabIndex = 9;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(1005, 0);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(1037, 32);
			bunifuCustomLabel1.TabIndex = 1;
			bunifuCustomLabel1.Text = "Tu\u0300y cho\u0323n đi\u0323nh da\u0323ng sao che\u0301p";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(575, 120);
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
			btnAdd.Location = new System.Drawing.Point(467, 120);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Xa\u0301c nhâ\u0323n";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label1.Location = new System.Drawing.Point(20, 66);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(132, 16);
			label1.TabIndex = 20;
			label1.Text = "Cho\u0323n đi\u0323nh da\u0323ng copy:";
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			cbbDinhDang1.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang1.FormattingEnabled = true;
			cbbDinhDang1.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang1.Location = new System.Drawing.Point(158, 65);
			cbbDinhDang1.Name = "cbbDinhDang1";
			cbbDinhDang1.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang1.TabIndex = 42;
			cbbDinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang2.FormattingEnabled = true;
			cbbDinhDang2.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang2.Location = new System.Drawing.Point(255, 65);
			cbbDinhDang2.Name = "cbbDinhDang2";
			cbbDinhDang2.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang2.TabIndex = 43;
			cbbDinhDang3.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang3.FormattingEnabled = true;
			cbbDinhDang3.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang3.Location = new System.Drawing.Point(352, 65);
			cbbDinhDang3.Name = "cbbDinhDang3";
			cbbDinhDang3.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang3.TabIndex = 44;
			cbbDinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang4.FormattingEnabled = true;
			cbbDinhDang4.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang4.Location = new System.Drawing.Point(449, 65);
			cbbDinhDang4.Name = "cbbDinhDang4";
			cbbDinhDang4.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang4.TabIndex = 45;
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label14.Location = new System.Drawing.Point(721, 67);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(19, 19);
			label14.TabIndex = 49;
			label14.Text = "|";
			cbbDinhDang5.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang5.FormattingEnabled = true;
			cbbDinhDang5.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang5.Location = new System.Drawing.Point(546, 65);
			cbbDinhDang5.Name = "cbbDinhDang5";
			cbbDinhDang5.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang5.TabIndex = 46;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label13.Location = new System.Drawing.Point(624, 67);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(19, 19);
			label13.TabIndex = 50;
			label13.Text = "|";
			cbbDinhDang6.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang6.FormattingEnabled = true;
			cbbDinhDang6.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang6.Location = new System.Drawing.Point(643, 65);
			cbbDinhDang6.Name = "cbbDinhDang6";
			cbbDinhDang6.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang6.TabIndex = 47;
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(527, 67);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(19, 19);
			label12.TabIndex = 51;
			label12.Text = "|";
			cbbDinhDang7.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang7.FormattingEnabled = true;
			cbbDinhDang7.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang7.Location = new System.Drawing.Point(740, 65);
			cbbDinhDang7.Name = "cbbDinhDang7";
			cbbDinhDang7.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang7.TabIndex = 48;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(430, 67);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(19, 19);
			label11.TabIndex = 52;
			label11.Text = "|";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(236, 67);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(19, 19);
			label9.TabIndex = 53;
			label9.Text = "|";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(333, 67);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(19, 19);
			label10.TabIndex = 54;
			label10.Text = "|";
			cbbDinhDang9.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang9.FormattingEnabled = true;
			cbbDinhDang9.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang9.Location = new System.Drawing.Point(934, 65);
			cbbDinhDang9.Name = "cbbDinhDang9";
			cbbDinhDang9.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang9.TabIndex = 48;
			cbbDinhDang8.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbDinhDang8.FormattingEnabled = true;
			cbbDinhDang8.Items.AddRange(new object[18]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Tên",
				"Giới tính", "Theo dõi", "Bạn bè", "Nhóm", "Ngày sinh", "Ngày tạo", "LD Index", "LD Name"
			});
			cbbDinhDang8.Location = new System.Drawing.Point(837, 65);
			cbbDinhDang8.Name = "cbbDinhDang8";
			cbbDinhDang8.Size = new System.Drawing.Size(78, 24);
			cbbDinhDang8.TabIndex = 47;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(818, 67);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(19, 19);
			label2.TabIndex = 50;
			label2.Text = "|";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(915, 67);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(19, 19);
			label3.TabIndex = 49;
			label3.Text = "|";
			button1.BackColor = System.Drawing.Color.DarkOrange;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(330, 120);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(121, 29);
			button1.TabIndex = 4;
			button1.Text = "Reset định dạng";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1037, 165);
			base.Controls.Add(cbbDinhDang1);
			base.Controls.Add(cbbDinhDang2);
			base.Controls.Add(cbbDinhDang3);
			base.Controls.Add(cbbDinhDang4);
			base.Controls.Add(label3);
			base.Controls.Add(label14);
			base.Controls.Add(cbbDinhDang5);
			base.Controls.Add(label2);
			base.Controls.Add(cbbDinhDang8);
			base.Controls.Add(label13);
			base.Controls.Add(cbbDinhDang6);
			base.Controls.Add(cbbDinhDang9);
			base.Controls.Add(label12);
			base.Controls.Add(cbbDinhDang7);
			base.Controls.Add(label11);
			base.Controls.Add(label9);
			base.Controls.Add(label10);
			base.Controls.Add(label1);
			base.Controls.Add(button1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCopy";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fAddFile";
			base.Load += new System.EventHandler(fCopy_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
