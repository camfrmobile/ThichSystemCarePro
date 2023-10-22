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
	public class fCapNhatDuLieu : Form
	{
		public static bool isAdd;

		private List<ComboBox> lstCbbDinhDang;

		private List<string> lstAccount = new List<string>();

		private List<string> lstAccountNotError = new List<string>();

		private List<string> lstAccountError = new List<string>();

		private IContainer components = null;

		private Button btnAdd;

		private Button btnCancel;

		private Label label8;

		private ComboBox cbbDinhDangNhap;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private RichTextBox txbAccount;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Panel pnlHeader;

		private BunifuCards bunifuCards1;

		private ContextMenuStrip ctmsDevice;

		private ToolStripMenuItem chọnToolStripMenuItem1;

		private ToolStripMenuItem tấtCảToolStripMenuItem1;

		private ToolStripMenuItem bôiĐenToolStripMenuItem1;

		private ToolStripMenuItem tàiKhoản0ToolStripMenuItem;

		private ToolStripMenuItem tàiKhoản1ToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem tạoThiếtBịToolStripMenuItem;

		private ToolStripMenuItem xóaThiếtBịToolStripMenuItem;

		private ToolStripMenuItem loadDanhSachThiêtBiToolStripMenuItem1;

		private Label label3;

		private Label lblSuccess;

		private Label lblError;

		private Label lblTotal;

		private Label label4;

		private Label label7;

		private Label lblStatus;

		private PictureBox pictureBox1;

		private Button btnMinimize;

		private PictureBox pictureBox2;

		private Panel plDinhDangNhap;

		private Label label1;

		private ComboBox cbbDinhDang1;

		private ComboBox cbbDinhDang2;

		private ComboBox cbbDinhDang3;

		private ComboBox cbbDinhDang4;

		private Label label14;

		private ComboBox cbbDinhDang5;

		private Label label17;

		private ComboBox cbbDinhDang8;

		private Label label13;

		private ComboBox cbbDinhDang6;

		private Label label12;

		private ComboBox cbbDinhDang7;

		private Label label11;

		private Label label9;

		private Label label10;

		private ComboBox cbbTypeProxy;

		private Label label2;

		public fCapNhatDuLieu()
		{
			InitializeComponent();
			cbbDinhDangNhap.SelectedIndex = 0;
			lstCbbDinhDang = new List<ComboBox> { cbbDinhDang1, cbbDinhDang2, cbbDinhDang3, cbbDinhDang4, cbbDinhDang5, cbbDinhDang6, cbbDinhDang7, cbbDinhDang8 };
			isAdd = false;
			ChangeLanguage();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(lblStatus);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label7);
			Language.GetValue(label8);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			lstAccountNotError = new List<string>();
			lstAccountError = new List<string>();
			try
			{
				List<string> lst = txbAccount.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhâ\u0323p thông tin ta\u0300i khoa\u0309n!"));
					txbAccount.Focus();
					return;
				}
				int selectedIndex = cbbDinhDangNhap.SelectedIndex;
				if (selectedIndex != 5)
				{
					goto IL_0100;
				}
				bool flag = false;
				for (int i = 0; i < lstCbbDinhDang.Count; i++)
				{
					if (lstCbbDinhDang[i].SelectedIndex > -1)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					goto IL_0100;
				}
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n đi\u0323nh da\u0323ng ta\u0300i khoa\u0309n!"));
				goto end_IL_001c;
				IL_0100:
				lblSuccess.Text = "0";
				lblError.Text = "0";
				lstAccount = new List<string>();
				int num = 0;
				switch (selectedIndex)
				{
				case 0:
				{
					num = 2;
					for (int n = 0; n < lst.Count; n++)
					{
						string[] array = lst[n].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add(array[0] + "|" + array[1] + "|||||||");
							lstAccountNotError.Add(lst[n]);
						}
						else
						{
							IncrementLabel(lblError);
							lstAccountError.Add(lst[n]);
						}
					}
					break;
				}
				case 1:
				{
					num = 3;
					for (int num3 = 0; num3 < lst.Count; num3++)
					{
						string[] array = lst[num3].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add(array[0] + "|" + array[1] + "|||||" + array[2] + "||");
							lstAccountNotError.Add(lst[num3]);
						}
						else
						{
							IncrementLabel(lblError);
							lstAccountError.Add(lst[num3]);
						}
					}
					break;
				}
				case 2:
				{
					num = 4;
					for (int l = 0; l < lst.Count; l++)
					{
						string[] array = lst[l].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add(array[0] + "|" + array[1] + "|" + array[2] + "|" + array[3] + "|||||");
							lstAccountNotError.Add(lst[l]);
						}
						else
						{
							IncrementLabel(lblError);
							lstAccountError.Add(lst[l]);
						}
					}
					break;
				}
				case 3:
				{
					num = 6;
					for (int num2 = 0; num2 < lst.Count; num2++)
					{
						string[] array = lst[num2].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add(array[0] + "|" + array[1] + "|" + array[2] + "|" + array[3] + "|" + array[4] + "|" + array[5] + "|||");
							lstAccountNotError.Add(lst[num2]);
						}
						else
						{
							IncrementLabel(lblError);
							lstAccountError.Add(lst[num2]);
						}
					}
					break;
				}
				case 4:
				{
					num = 7;
					for (int m = 0; m < lst.Count; m++)
					{
						string[] array = lst[m].Split('|');
						if (array.Count() >= num)
						{
							lstAccount.Add(array[0] + "|" + array[1] + "|" + array[2] + "|" + array[3] + "|" + array[4] + "|" + array[5] + "|" + array[6] + "||");
							lstAccountNotError.Add(lst[m]);
						}
						else
						{
							IncrementLabel(lblError);
							lstAccountError.Add(lst[m]);
						}
					}
					break;
				}
				case 5:
				{
					string text = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					for (int j = 0; j < lst.Count; j++)
					{
						string[] array = lst[j].Split('|');
						text = "";
						text2 = "";
						text3 = "";
						text4 = "";
						text5 = "";
						text6 = "";
						text7 = "";
						text8 = "";
						text9 = "";
						try
						{
							text = array[0];
							for (int k = 1; k < lstCbbDinhDang.Count; k++)
							{
								switch (lstCbbDinhDang[k - 1].SelectedIndex)
								{
								case 0:
									text = array[k];
									break;
								case 1:
									text2 = array[k];
									break;
								case 2:
									text3 = array[k];
									break;
								case 3:
									text4 = array[k];
									break;
								case 4:
									text5 = array[k];
									break;
								case 5:
									text6 = array[k];
									break;
								case 6:
									text7 = array[k];
									break;
								case 7:
									text8 = array[k];
									break;
								case 8:
									text9 = ((array[k] == "") ? "" : (array[k] + "*" + cbbTypeProxy.SelectedIndex));
									break;
								}
							}
							lstAccount.Add(text + "|" + text2 + "|" + text3 + "|" + text4 + "|" + text5 + "|" + text6 + "|" + text7 + "|" + text8 + "|" + text9);
							lstAccountNotError.Add(lst[j]);
						}
						catch
						{
							IncrementLabel(lblError);
							lstAccountError.Add(lst[j]);
						}
					}
					break;
				}
				}
				btnAdd.Invoke((MethodInvoker)delegate
				{
					btnAdd.Enabled = false;
				});
				UpdateStatus(Language.GetValue("Đang cập nhật dữ liệu..."));
				for (int num4 = 0; num4 < lstAccount.Count; num4++)
				{
					if (CommonSQL.UpdateAccountByUid(lstAccount[num4]))
					{
						IncrementLabel(lblSuccess);
					}
					else
					{
						IncrementLabel(lblError);
					}
				}
				btnAdd.Invoke((MethodInvoker)delegate
				{
					btnAdd.Enabled = true;
				});
				lstAccountNotError.AddRange(lstAccountError);
				txbAccount.Lines = lstAccountNotError.ToArray();
				UpdateStatus(Language.GetValue("Cập nhật dữ liệu xong!"));
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Cập nhật dữ liệu xong!"));
				isAdd = true;
				end_IL_001c:;
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đa\u0303 co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!"));
				MCommon.Common.ExportError(ex, "UpdateAccount");
			}
		}

		private void UpdateStatus(string content)
		{
			Application.DoEvents();
			lblStatus.Invoke((MethodInvoker)delegate
			{
				lblStatus.Text = content;
			});
		}

		private void TxbAccount_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txbAccount.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				lblTotal.Text = lst.Count.ToString();
			}
			catch
			{
			}
		}

		private void IncrementLabel(Label lbl)
		{
			Application.DoEvents();
			lock (lbl)
			{
				lbl.Invoke((MethodInvoker)delegate
				{
					int num = Convert.ToInt32(lbl.Text);
					lbl.Text = (num + 1).ToString();
				});
			}
		}

		private void cbbDinhDangNhap_SelectedIndexChanged(object sender, EventArgs e)
		{
			plDinhDangNhap.Visible = cbbDinhDangNhap.SelectedIndex == cbbDinhDangNhap.Items.Count - 1;
		}

		private bool CheckExistDinhDang()
		{
			bool result = false;
			List<int> list = new List<int>();
			int num = 0;
			for (int i = 0; i <= 6; i++)
			{
				num = lstCbbDinhDang[i].SelectedIndex;
				if (num != -1)
				{
					if (list.Contains(num))
					{
						result = true;
						break;
					}
					list.Add(num);
				}
			}
			return result;
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbbDinhDang1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool visible = false;
			for (int i = 0; i < lstCbbDinhDang.Count; i++)
			{
				if (lstCbbDinhDang[i].Text == "Proxy")
				{
					visible = true;
					break;
				}
			}
			label2.Visible = visible;
			cbbTypeProxy.Visible = visible;
		}

		private void fCapNhatDuLieu_Load(object sender, EventArgs e)
		{
			cbbTypeProxy.SelectedIndex = 0;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fCapNhatDuLieu));
			btnAdd = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			cbbDinhDangNhap = new System.Windows.Forms.ComboBox();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			txbAccount = new System.Windows.Forms.RichTextBox();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			ctmsDevice = new System.Windows.Forms.ContextMenuStrip(components);
			chọnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			tấtCảToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			bôiĐenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			tàiKhoản0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tàiKhoản1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			tạoThiếtBịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xóaThiếtBịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			loadDanhSachThiêtBiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			label3 = new System.Windows.Forms.Label();
			lblSuccess = new System.Windows.Forms.Label();
			lblError = new System.Windows.Forms.Label();
			lblTotal = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			plDinhDangNhap = new System.Windows.Forms.Panel();
			cbbTypeProxy = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			cbbDinhDang1 = new System.Windows.Forms.ComboBox();
			cbbDinhDang2 = new System.Windows.Forms.ComboBox();
			cbbDinhDang3 = new System.Windows.Forms.ComboBox();
			cbbDinhDang4 = new System.Windows.Forms.ComboBox();
			label14 = new System.Windows.Forms.Label();
			cbbDinhDang5 = new System.Windows.Forms.ComboBox();
			label17 = new System.Windows.Forms.Label();
			cbbDinhDang8 = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			cbbDinhDang6 = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			cbbDinhDang7 = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			bunifuCards1.SuspendLayout();
			ctmsDevice.SuspendLayout();
			plDinhDangNhap.SuspendLayout();
			SuspendLayout();
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(335, 460);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(97, 31);
			btnAdd.TabIndex = 13;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(452, 460);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(97, 31);
			btnCancel.TabIndex = 14;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			label8.Location = new System.Drawing.Point(9, 367);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(97, 14);
			label8.TabIndex = 39;
			label8.Text = "Chọn định dạng:";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			cbbDinhDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDangNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDangNhap.FormattingEnabled = true;
			cbbDinhDangNhap.Items.AddRange(new object[6] { "Uid|Pass", "Uid|Pass|2FA", "Uid|Pass|Token|Cookie", "Uid|Pass|Token|Cookie|Email|Pass Email", "Uid|Pass|Token|Cookie|Email|Pass Email|2FA", "Other..." });
			cbbDinhDangNhap.Location = new System.Drawing.Point(112, 364);
			cbbDinhDangNhap.Name = "cbbDinhDangNhap";
			cbbDinhDangNhap.Size = new System.Drawing.Size(269, 22);
			cbbDinhDangNhap.TabIndex = 40;
			cbbDinhDangNhap.SelectedIndexChanged += new System.EventHandler(cbbDinhDangNhap_SelectedIndexChanged);
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(885, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cập nhật dữ liệu";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox2);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(885, 31);
			pnlHeader.TabIndex = 9;
			pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(2, 3);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(34, 27);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 79;
			pictureBox2.TabStop = false;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(-156, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 78;
			pictureBox1.TabStop = false;
			btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(853, 1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(30, 30);
			btnMinimize.TabIndex = 77;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(btnMinimize_Click);
			txbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txbAccount.Location = new System.Drawing.Point(12, 77);
			txbAccount.Name = "txbAccount";
			txbAccount.Size = new System.Drawing.Size(863, 277);
			txbAccount.TabIndex = 48;
			txbAccount.Text = "";
			txbAccount.WordWrap = false;
			txbAccount.TextChanged += new System.EventHandler(TxbAccount_TextChanged);
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.DarkViolet;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(885, 37);
			bunifuCards1.TabIndex = 49;
			ctmsDevice.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ctmsDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { chọnToolStripMenuItem1, toolStripMenuItem2, tạoThiếtBịToolStripMenuItem, xóaThiếtBịToolStripMenuItem, loadDanhSachThiêtBiToolStripMenuItem1 });
			ctmsDevice.Name = "ctmsAcc";
			ctmsDevice.Size = new System.Drawing.Size(179, 114);
			chọnToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { tấtCảToolStripMenuItem1, bôiĐenToolStripMenuItem1, tàiKhoản0ToolStripMenuItem, tàiKhoản1ToolStripMenuItem });
			chọnToolStripMenuItem1.Name = "chọnToolStripMenuItem1";
			chọnToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
			chọnToolStripMenuItem1.Text = "Chọn";
			tấtCảToolStripMenuItem1.Name = "tấtCảToolStripMenuItem1";
			tấtCảToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
			tấtCảToolStripMenuItem1.Text = "Tất cả";
			bôiĐenToolStripMenuItem1.Name = "bôiĐenToolStripMenuItem1";
			bôiĐenToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
			bôiĐenToolStripMenuItem1.Text = "Bôi đen";
			tàiKhoản0ToolStripMenuItem.Name = "tàiKhoản0ToolStripMenuItem";
			tàiKhoản0ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			tàiKhoản0ToolStripMenuItem.Text = "Tài khoản=0";
			tàiKhoản1ToolStripMenuItem.Name = "tàiKhoản1ToolStripMenuItem";
			tàiKhoản1ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			tàiKhoản1ToolStripMenuItem.Text = "Tài khoản=1";
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(178, 22);
			toolStripMenuItem2.Text = "Bỏ chọn tất cả";
			tạoThiếtBịToolStripMenuItem.Name = "tạoThiếtBịToolStripMenuItem";
			tạoThiếtBịToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			tạoThiếtBịToolStripMenuItem.Text = "Tạo thiết bị";
			xóaThiếtBịToolStripMenuItem.Name = "xóaThiếtBịToolStripMenuItem";
			xóaThiếtBịToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			xóaThiếtBịToolStripMenuItem.Text = "Xóa thiết bị";
			loadDanhSachThiêtBiToolStripMenuItem1.Name = "loadDanhSachThiêtBiToolStripMenuItem1";
			loadDanhSachThiêtBiToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
			loadDanhSachThiêtBiToolStripMenuItem1.Text = "Làm mới danh sa\u0301ch";
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label3.Location = new System.Drawing.Point(443, 50);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(87, 16);
			label3.TabIndex = 55;
			label3.Text = "Tha\u0300nh công:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblSuccess.AutoSize = true;
			lblSuccess.BackColor = System.Drawing.SystemColors.Control;
			lblSuccess.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblSuccess.ForeColor = System.Drawing.Color.FromArgb(53, 120, 229);
			lblSuccess.Location = new System.Drawing.Point(526, 47);
			lblSuccess.Name = "lblSuccess";
			lblSuccess.Size = new System.Drawing.Size(19, 19);
			lblSuccess.TabIndex = 50;
			lblSuccess.Text = "0";
			lblError.AutoSize = true;
			lblError.BackColor = System.Drawing.SystemColors.Control;
			lblError.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblError.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			lblError.Location = new System.Drawing.Point(649, 47);
			lblError.Name = "lblError";
			lblError.Size = new System.Drawing.Size(19, 19);
			lblError.TabIndex = 51;
			lblError.Text = "0";
			lblTotal.AutoSize = true;
			lblTotal.BackColor = System.Drawing.SystemColors.Control;
			lblTotal.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblTotal.ForeColor = System.Drawing.Color.Teal;
			lblTotal.Location = new System.Drawing.Point(809, 48);
			lblTotal.Name = "lblTotal";
			lblTotal.Size = new System.Drawing.Size(19, 19);
			lblTotal.TabIndex = 53;
			lblTotal.Text = "0";
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label4.Location = new System.Drawing.Point(600, 50);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(52, 16);
			label4.TabIndex = 56;
			label4.Text = "Lỗi:";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(749, 50);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(63, 16);
			label7.TabIndex = 59;
			label7.Text = "Tô\u0309ng sô\u0301:";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
			lblStatus.Location = new System.Drawing.Point(12, 44);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(227, 28);
			lblStatus.TabIndex = 60;
			lblStatus.Text = "Nhập thông tin tài khoản:";
			lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plDinhDangNhap.Controls.Add(cbbTypeProxy);
			plDinhDangNhap.Controls.Add(label2);
			plDinhDangNhap.Controls.Add(label1);
			plDinhDangNhap.Controls.Add(cbbDinhDang1);
			plDinhDangNhap.Controls.Add(cbbDinhDang2);
			plDinhDangNhap.Controls.Add(cbbDinhDang3);
			plDinhDangNhap.Controls.Add(cbbDinhDang4);
			plDinhDangNhap.Controls.Add(label14);
			plDinhDangNhap.Controls.Add(cbbDinhDang5);
			plDinhDangNhap.Controls.Add(label17);
			plDinhDangNhap.Controls.Add(cbbDinhDang8);
			plDinhDangNhap.Controls.Add(label13);
			plDinhDangNhap.Controls.Add(cbbDinhDang6);
			plDinhDangNhap.Controls.Add(label12);
			plDinhDangNhap.Controls.Add(cbbDinhDang7);
			plDinhDangNhap.Controls.Add(label11);
			plDinhDangNhap.Controls.Add(label9);
			plDinhDangNhap.Controls.Add(label10);
			plDinhDangNhap.Location = new System.Drawing.Point(102, 392);
			plDinhDangNhap.Name = "plDinhDangNhap";
			plDinhDangNhap.Size = new System.Drawing.Size(777, 62);
			plDinhDangNhap.TabIndex = 61;
			cbbTypeProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTypeProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbTypeProxy.Enabled = false;
			cbbTypeProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbTypeProxy.FormattingEnabled = true;
			cbbTypeProxy.Items.AddRange(new object[2] { "HTTP", "Sock5" });
			cbbTypeProxy.Location = new System.Drawing.Point(85, 33);
			cbbTypeProxy.Name = "cbbTypeProxy";
			cbbTypeProxy.Size = new System.Drawing.Size(130, 24);
			cbbTypeProxy.TabIndex = 126;
			cbbTypeProxy.Visible = false;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(7, 36);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(71, 16);
			label2.TabIndex = 125;
			label2.Text = "Loại proxy:";
			label2.Visible = false;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 12f);
			label1.Location = new System.Drawing.Point(5, 3);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(39, 19);
			label1.TabIndex = 42;
			label1.Text = "Uid|";
			cbbDinhDang1.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang1.FormattingEnabled = true;
			cbbDinhDang1.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang1.Location = new System.Drawing.Point(44, 3);
			cbbDinhDang1.Name = "cbbDinhDang1";
			cbbDinhDang1.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang1.TabIndex = 40;
			cbbDinhDang1.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			cbbDinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang2.FormattingEnabled = true;
			cbbDinhDang2.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang2.Location = new System.Drawing.Point(137, 3);
			cbbDinhDang2.Name = "cbbDinhDang2";
			cbbDinhDang2.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang2.TabIndex = 40;
			cbbDinhDang2.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			cbbDinhDang3.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang3.FormattingEnabled = true;
			cbbDinhDang3.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang3.Location = new System.Drawing.Point(230, 3);
			cbbDinhDang3.Name = "cbbDinhDang3";
			cbbDinhDang3.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang3.TabIndex = 40;
			cbbDinhDang3.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			cbbDinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang4.FormattingEnabled = true;
			cbbDinhDang4.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang4.Location = new System.Drawing.Point(323, 3);
			cbbDinhDang4.Name = "cbbDinhDang4";
			cbbDinhDang4.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang4.TabIndex = 40;
			cbbDinhDang4.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Tahoma", 12f);
			label14.Location = new System.Drawing.Point(587, 3);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(15, 19);
			label14.TabIndex = 41;
			label14.Text = "|";
			cbbDinhDang5.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang5.FormattingEnabled = true;
			cbbDinhDang5.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang5.Location = new System.Drawing.Point(416, 3);
			cbbDinhDang5.Name = "cbbDinhDang5";
			cbbDinhDang5.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang5.TabIndex = 40;
			cbbDinhDang5.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Tahoma", 12f);
			label17.Location = new System.Drawing.Point(680, 3);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(15, 19);
			label17.TabIndex = 41;
			label17.Text = "|";
			cbbDinhDang8.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang8.FormattingEnabled = true;
			cbbDinhDang8.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang8.Location = new System.Drawing.Point(695, 3);
			cbbDinhDang8.Name = "cbbDinhDang8";
			cbbDinhDang8.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang8.TabIndex = 40;
			cbbDinhDang8.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Tahoma", 12f);
			label13.Location = new System.Drawing.Point(494, 3);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(15, 19);
			label13.TabIndex = 41;
			label13.Text = "|";
			cbbDinhDang6.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang6.FormattingEnabled = true;
			cbbDinhDang6.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang6.Location = new System.Drawing.Point(509, 3);
			cbbDinhDang6.Name = "cbbDinhDang6";
			cbbDinhDang6.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang6.TabIndex = 40;
			cbbDinhDang6.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Tahoma", 12f);
			label12.Location = new System.Drawing.Point(401, 3);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(15, 19);
			label12.TabIndex = 41;
			label12.Text = "|";
			cbbDinhDang7.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang7.FormattingEnabled = true;
			cbbDinhDang7.Items.AddRange(new object[9] { "Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy" });
			cbbDinhDang7.Location = new System.Drawing.Point(602, 3);
			cbbDinhDang7.Name = "cbbDinhDang7";
			cbbDinhDang7.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang7.TabIndex = 40;
			cbbDinhDang7.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Tahoma", 12f);
			label11.Location = new System.Drawing.Point(308, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(15, 19);
			label11.TabIndex = 41;
			label11.Text = "|";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 12f);
			label9.Location = new System.Drawing.Point(122, 3);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(15, 19);
			label9.TabIndex = 41;
			label9.Text = "|";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 12f);
			label10.Location = new System.Drawing.Point(215, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(15, 19);
			label10.TabIndex = 41;
			label10.Text = "|";
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(885, 502);
			base.Controls.Add(plDinhDangNhap);
			base.Controls.Add(lblStatus);
			base.Controls.Add(label3);
			base.Controls.Add(lblSuccess);
			base.Controls.Add(lblError);
			base.Controls.Add(lblTotal);
			base.Controls.Add(label4);
			base.Controls.Add(label7);
			base.Controls.Add(btnAdd);
			base.Controls.Add(btnCancel);
			base.Controls.Add(txbAccount);
			base.Controls.Add(bunifuCards1);
			base.Controls.Add(cbbDinhDangNhap);
			base.Controls.Add(label8);
			Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fCapNhatDuLieu";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Nhập tài khoản";
			base.Load += new System.EventHandler(fCapNhatDuLieu_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			bunifuCards1.ResumeLayout(false);
			ctmsDevice.ResumeLayout(false);
			plDinhDangNhap.ResumeLayout(false);
			plDinhDangNhap.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
