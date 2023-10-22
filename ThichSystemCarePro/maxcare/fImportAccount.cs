using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fImportAccount : Form
	{
		public static bool isAddAccount = false;

		public static int idFileAdded = -1;

		public static bool isAddFile = false;

		private List<ComboBox> lstCbbDinhDang;

		private int indexOld = 0;

		private List<string> lstAccount = new List<string>();

		private List<Thread> lstThread = null;

		private object objLock = new object();

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnAdd;

		private Button btnCancel;

		private Label lblSuccess;

		private Label lblError;

		private Label lblWallDie;

		private Label lblTotal;

		private Label lblWallLive;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label lblStatus;

		private Label label8;

		private ComboBox cbbDinhDangNhap;

		private ComboBox cbbDinhDang1;

		private Label label9;

		private ComboBox cbbDinhDang2;

		private Label label10;

		private ComboBox cbbDinhDang3;

		private Label label11;

		private ComboBox cbbDinhDang4;

		private Label label12;

		private ComboBox cbbDinhDang5;

		private Label label13;

		private ComboBox cbbDinhDang6;

		private Label label14;

		private ComboBox cbbDinhDang7;

		private Label label15;

		private CheckBox ckbCheckThongTin;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private Panel plDinhDangNhap;

		private PictureBox pictureBox1;

		private Label label16;

		private ComboBox cbbThuMuc;

		private Button button1;

		private RichTextBox txbAccount;

		private Label label18;

		private Label label17;

		private ComboBox cbbDinhDang8;

		private ComboBox cbbDinhDang9;

		private Button btnMinimize;

		private Label lblKhongCheckDuoc;

		private Label label2;

		public fImportAccount(string idFile)
		{
			InitializeComponent();
			ChangeLanguage();
			Load_cbbThuMuc();
			if (idFile != "" && idFile != "-1" && idFile != "999999")
			{
				cbbThuMuc.SelectedValue = idFile;
			}
			cbbDinhDangNhap.SelectedIndex = 0;
			lstCbbDinhDang = new List<ComboBox> { cbbDinhDang1, cbbDinhDang2, cbbDinhDang3, cbbDinhDang4, cbbDinhDang5, cbbDinhDang6, cbbDinhDang7, cbbDinhDang8, cbbDinhDang9 };
			isAddFile = false;
			isAddAccount = false;
			idFileAdded = -1;
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

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label3);
			Language.GetValue(label4);
			Language.GetValue(label5);
			Language.GetValue(label6);
			Language.GetValue(label2);
			Language.GetValue(label7);
			Language.GetValue(label16);
			Language.GetValue(button1);
			Language.GetValue(label8);
			Language.GetValue(label15);
			Language.GetValue(ckbCheckThongTin);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> lst = txbAccount.Lines.ToList();
				lst = MCommon.Common.RemoveEmptyItems(lst);
				if (lst.Count == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng nhâ\u0323p thông tin ta\u0300i khoa\u0309n!"), 3);
					txbAccount.Focus();
					return;
				}
				if (cbbThuMuc.SelectedValue == null)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng cho\u0323n thư mu\u0323c!"), 3);
					return;
				}
				string idFile = cbbThuMuc.SelectedValue.ToString();
				bool isCheckThongTin = ckbCheckThongTin.Checked;
				int selectedIndex = cbbDinhDangNhap.SelectedIndex;
				if (selectedIndex != 6)
				{
					goto IL_014e;
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
					goto IL_014e;
				}
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng cho\u0323n đi\u0323nh da\u0323ng ta\u0300i khoa\u0309n!"), 3);
				goto end_IL_0001;
				IL_014e:
				int maxThread = 100;
				if (lst.Count < 100)
				{
					maxThread = lst.Count;
				}
				lblSuccess.Text = "0";
				lblError.Text = "0";
				lblWallDie.Text = "0";
				lblKhongCheckDuoc.Text = "0";
				lblWallLive.Text = "0";
				lstAccount = new List<string>();
				int num = 0;
				string[] temp;
				switch (selectedIndex)
				{
				case 0:
				{
					num = 3;
					for (int num3 = 0; num3 < lst.Count; num3++)
					{
						temp = lst[num3].Split('|');
						if (temp.Count() >= num)
						{
							lstAccount.Add(temp[0] + "|" + temp[1] + "|||||" + temp[2] + "||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 1:
				{
					for (int l = 0; l < lst.Count; l++)
					{
						lstAccount.Add("|||" + lst[l] + "|||||||");
					}
					break;
				}
				case 2:
				{
					num = 2;
					for (int n = 0; n < lst.Count; n++)
					{
						temp = lst[n].Split('|');
						if (temp.Count() >= num)
						{
							lstAccount.Add(temp[0] + "|" + temp[1] + "|||||||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 3:
				{
					num = 4;
					for (int num4 = 0; num4 < lst.Count; num4++)
					{
						temp = lst[num4].Split('|');
						if (temp.Count() >= num)
						{
							lstAccount.Add(temp[0] + "|" + temp[1] + "|" + temp[2] + "|" + temp[3] + "|||||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 4:
				{
					num = 6;
					for (int num2 = 0; num2 < lst.Count; num2++)
					{
						temp = lst[num2].Split('|');
						if (temp.Count() >= num)
						{
							lstAccount.Add(temp[0] + "|" + temp[1] + "|" + temp[2] + "|" + temp[3] + "|" + temp[4] + "|" + temp[5] + "|||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 5:
				{
					num = 7;
					for (int m = 0; m < lst.Count; m++)
					{
						temp = lst[m].Split('|');
						if (temp.Count() >= num)
						{
							lstAccount.Add(temp[0] + "|" + temp[1] + "|" + temp[2] + "|" + temp[3] + "|" + temp[4] + "|" + temp[5] + "|" + temp[6] + "||||");
						}
						else
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				case 6:
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
					string text10 = "";
					string text11 = "";
					for (int j = 0; j < lst.Count; j++)
					{
						temp = lst[j].Split('|');
						text = "";
						text2 = "";
						text3 = "";
						text4 = "";
						text5 = "";
						text6 = "";
						text7 = "";
						text8 = "";
						text9 = "";
						text10 = "";
						text11 = "";
						try
						{
							for (int k = 0; k < lstCbbDinhDang.Count; k++)
							{
								switch (lstCbbDinhDang[k].SelectedIndex)
								{
								case 0:
									text = temp[k];
									break;
								case 1:
									text2 = temp[k];
									break;
								case 2:
									text3 = temp[k];
									break;
								case 3:
									text4 = temp[k];
									break;
								case 4:
									text5 = temp[k];
									break;
								case 5:
									text6 = temp[k];
									break;
								case 6:
									text7 = temp[k];
									break;
								case 7:
									text8 = temp[k];
									break;
								case 8:
									text9 = ((!(temp[k].Trim() == "")) ? (temp[k] + "*0") : "");
									break;
								case 9:
									text10 = temp[k];
									break;
								case 10:
									text11 = temp[k];
									break;
								}
							}
							lstAccount.Add(text + "|" + text2 + "|" + text3 + "|" + text4 + "|" + text5 + "|" + text6 + "|" + text7 + "|" + text8 + "|" + text9 + "|" + text10 + "|" + text11);
						}
						catch
						{
							IncrementLabel(lblError);
						}
					}
					break;
				}
				}
				List<string> lstQuery = new List<string>();
				lstThread = new List<Thread>();
				new Thread((ThreadStart)delegate
				{
					try
					{
						btnAdd.Invoke((MethodInvoker)delegate
						{
							btnAdd.Enabled = false;
						});
						UpdateStatus(Language.GetValue("Chuẩn bị thêm tài khoản..."), lblStatus);
						if (isCheckThongTin)
						{
							int num5 = 0;
							while (num5 < lstAccount.Count)
							{
								if (lstThread.Count < maxThread)
								{
									int stt = num5++;
									UpdateStatus(string.Format(Language.GetValue("Đang check thông tin {0}/{1}..."), num5, lstAccount.Count), lblStatus);
									Thread thread = new Thread((ThreadStart)delegate
									{
										try
										{
											string text24 = lstAccount[stt];
											if (!(text24.Trim() == ""))
											{
												string[] array2 = text24.Split('|');
												string text25 = "";
												string text26 = "";
												string text27 = "";
												string text28 = "";
												string text29 = "";
												string text30 = "";
												string text31 = "";
												string text32 = "";
												string text33 = "";
												string text34 = "";
												string text35 = "";
												text25 = array2[0];
												text26 = array2[1];
												text27 = array2[2];
												text28 = array2[3];
												text29 = array2[4];
												text30 = array2[5];
												text31 = array2[6];
												text32 = array2[7];
												text33 = array2[8];
												text34 = array2[9];
												text35 = array2[10];
												string name2 = "";
												string friends2 = "";
												string groups2 = "";
												string gender2 = "";
												string text36 = "unknow";
												if (text25 == "")
												{
													text25 = Regex.Match(text28, "c_user=(.*?);").Groups[1].Value;
												}
												if (text25 == "")
												{
													text36 = "Die";
												}
												else
												{
													string text37 = CommonRequest.CheckInfoUsingUid(text25);
													if (text37.StartsWith("0|"))
													{
														if (CommonRequest.CheckLiveWall(text25).StartsWith("0|"))
														{
															text36 = "Die";
														}
													}
													else if (text37.StartsWith("1|"))
													{
														temp = text37.Split('|');
														name2 = temp[2];
														gender2 = temp[3].ToLower();
														text34 = temp[4];
														friends2 = temp[5];
														groups2 = temp[6];
														text36 = "Live";
													}
												}
												string text38 = text36;
												string text39 = text38;
												if (!(text39 == "Live"))
												{
													if (!(text39 == "Die"))
													{
														IncrementLabel(lblKhongCheckDuoc);
													}
													else
													{
														IncrementLabel(lblWallDie);
													}
												}
												else
												{
													IncrementLabel(lblWallLive);
												}
												lstQuery.Add(CommonSQL.ConvertToSqlInsertAccount(text25, text26, text27, text28, text29, name2, friends2, groups2, text34, gender2, text36, text31, idFile, text30, text32, text33, text35));
											}
										}
										catch
										{
										}
									});
									lstThread.Add(thread);
									thread.Start();
								}
								else
								{
									for (int num6 = 0; num6 < lstThread.Count; num6++)
									{
										if (!lstThread[num6].IsAlive)
										{
											lstThread.RemoveAt(num6--);
										}
									}
								}
							}
							for (int num7 = 0; num7 < lstThread.Count; num7++)
							{
								lstThread[num7].Join();
							}
						}
						else
						{
							for (int num8 = 0; num8 < lstAccount.Count; num8++)
							{
								try
								{
									string text12 = lstAccount[num8];
									if (text12.Trim() == "")
									{
										return;
									}
									string[] array = text12.Split('|');
									string text13 = "";
									string text14 = "";
									string text15 = "";
									string text16 = "";
									string text17 = "";
									string text18 = "";
									string text19 = "";
									string text20 = "";
									string text21 = "";
									string text22 = "";
									string text23 = "";
									text13 = array[0];
									text14 = array[1];
									text15 = array[2];
									text16 = array[3];
									text17 = array[4];
									text18 = array[5];
									text19 = array[6];
									text20 = array[7];
									text21 = array[8];
									text22 = array[9];
									text23 = array[10];
									string name = "";
									string friends = "";
									string groups = "";
									string gender = "";
									string info = "unknow";
									if (text13 == "")
									{
										text13 = Regex.Match(text16, "c_user=(.*?);").Groups[1].Value;
									}
									lstQuery.Add(CommonSQL.ConvertToSqlInsertAccount(text13, text14, text15, text16, text17, name, friends, groups, text22, gender, info, text19, idFile, text18, text20, text21, text23));
								}
								catch
								{
								}
							}
						}
						UpdateStatus(Language.GetValue("Đang thêm tài khoản..."), lblStatus);
						if (lstQuery.Count >= 0)
						{
							lstQuery = CommonSQL.ConvertToSqlInsertAccount(lstQuery);
							for (int num9 = 0; num9 < lstQuery.Count; num9++)
							{
								IncrementLabel(lblSuccess, Connector.Instance.ExecuteNonQuery(lstQuery[num9]));
							}
						}
						UpdateStatus((Convert.ToInt32(lblTotal.Text) - Convert.ToInt32(lblSuccess.Text)).ToString() ?? "", lblError);
						btnAdd.Invoke((MethodInvoker)delegate
						{
							btnAdd.Enabled = true;
						});
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Thêm tài khoản thành công!"));
						UpdateStatus(Language.GetValue("Thêm tài khoản thành công!"), lblStatus);
						isAddAccount = true;
						idFileAdded = Convert.ToInt32(idFile);
					}
					catch (Exception ex2)
					{
						MCommon.Common.ExportError(null, ex2, "AddAccount");
					}
				}).Start();
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đa\u0303 co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				MCommon.Common.ExportError(null, ex, "AddAccount");
			}
		}

		private void UpdateStatus(string content, Label lbl)
		{
			lbl.Invoke((MethodInvoker)delegate
			{
				Application.DoEvents();
				lbl.Text = content;
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

		private void IncrementLabel(Label lbl, int count = -1)
		{
			if (count == -1)
			{
				lbl.Invoke((MethodInvoker)delegate
				{
					Application.DoEvents();
					lbl.Text = (Convert.ToInt32(lbl.Text) + ((count == -1) ? 1 : count)).ToString();
				});
			}
			else
			{
				lbl.Invoke((MethodInvoker)delegate
				{
					Application.DoEvents();
					lbl.Text = (Convert.ToInt32(lbl.Text) + count).ToString();
				});
			}
		}

		private void cbbDinhDangNhap_SelectedIndexChanged(object sender, EventArgs e)
		{
			plDinhDangNhap.Visible = cbbDinhDangNhap.SelectedIndex == cbbDinhDangNhap.Items.Count - 1;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			fAddFile f = new fAddFile();
			MCommon.Common.ShowForm(f);
			if (fAddFile.isAdd)
			{
				Load_cbbThuMuc();
				cbbThuMuc.SelectedIndex = cbbThuMuc.Items.Count - 1;
				isAddFile = true;
			}
		}

		private bool CheckExistDinhDang()
		{
			bool result = false;
			List<int> list = new List<int>();
			int num = 0;
			for (int i = 0; i < lstCbbDinhDang.Count; i++)
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

		private void cbbDinhDang1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CheckExistDinhDang())
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Tu\u0300y cho\u0323n na\u0300y đa\u0303 tô\u0300n ta\u0323i, vui lo\u0300ng cho\u0323n tu\u0300y cho\u0323n kha\u0301c!"), 3);
				(sender as ComboBox).SelectedIndex = -1;
			}
		}

		private void cbbThuMuc_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fImportAccount));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			btnMinimize = new System.Windows.Forms.Button();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnAdd = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			lblSuccess = new System.Windows.Forms.Label();
			lblError = new System.Windows.Forms.Label();
			lblWallDie = new System.Windows.Forms.Label();
			lblTotal = new System.Windows.Forms.Label();
			lblWallLive = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			cbbDinhDangNhap = new System.Windows.Forms.ComboBox();
			cbbDinhDang1 = new System.Windows.Forms.ComboBox();
			label9 = new System.Windows.Forms.Label();
			cbbDinhDang2 = new System.Windows.Forms.ComboBox();
			label10 = new System.Windows.Forms.Label();
			cbbDinhDang3 = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			cbbDinhDang4 = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			cbbDinhDang5 = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			cbbDinhDang6 = new System.Windows.Forms.ComboBox();
			label14 = new System.Windows.Forms.Label();
			cbbDinhDang7 = new System.Windows.Forms.ComboBox();
			label15 = new System.Windows.Forms.Label();
			ckbCheckThongTin = new System.Windows.Forms.CheckBox();
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			plDinhDangNhap = new System.Windows.Forms.Panel();
			label18 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			cbbDinhDang8 = new System.Windows.Forms.ComboBox();
			cbbDinhDang9 = new System.Windows.Forms.ComboBox();
			label16 = new System.Windows.Forms.Label();
			cbbThuMuc = new System.Windows.Forms.ComboBox();
			button1 = new System.Windows.Forms.Button();
			txbAccount = new System.Windows.Forms.RichTextBox();
			lblKhongCheckDuoc = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			plDinhDangNhap.SuspendLayout();
			SuspendLayout();
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
			bunifuCards1.Size = new System.Drawing.Size(953, 37);
			bunifuCards1.TabIndex = 11;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(953, 31);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
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
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(921, 1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(30, 30);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnCancel_Click);
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(953, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Nhập Tài Khoản";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(364, 491);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(107, 31);
			btnAdd.TabIndex = 13;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(478, 491);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(107, 31);
			btnCancel.TabIndex = 14;
			btnCancel.Text = "Đo\u0301ng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			lblSuccess.AutoSize = true;
			lblSuccess.BackColor = System.Drawing.SystemColors.Control;
			lblSuccess.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblSuccess.ForeColor = System.Drawing.Color.FromArgb(53, 120, 229);
			lblSuccess.Location = new System.Drawing.Point(106, 51);
			lblSuccess.Name = "lblSuccess";
			lblSuccess.Size = new System.Drawing.Size(19, 19);
			lblSuccess.TabIndex = 23;
			lblSuccess.Text = "0";
			lblError.AutoSize = true;
			lblError.BackColor = System.Drawing.SystemColors.Control;
			lblError.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblError.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
			lblError.Location = new System.Drawing.Point(218, 51);
			lblError.Name = "lblError";
			lblError.Size = new System.Drawing.Size(19, 19);
			lblError.TabIndex = 24;
			lblError.Text = "0";
			lblWallDie.AutoSize = true;
			lblWallDie.BackColor = System.Drawing.SystemColors.Control;
			lblWallDie.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblWallDie.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lblWallDie.Location = new System.Drawing.Point(498, 51);
			lblWallDie.Name = "lblWallDie";
			lblWallDie.Size = new System.Drawing.Size(19, 19);
			lblWallDie.TabIndex = 25;
			lblWallDie.Text = "0";
			lblTotal.AutoSize = true;
			lblTotal.BackColor = System.Drawing.SystemColors.Control;
			lblTotal.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblTotal.ForeColor = System.Drawing.Color.Teal;
			lblTotal.Location = new System.Drawing.Point(842, 51);
			lblTotal.Name = "lblTotal";
			lblTotal.Size = new System.Drawing.Size(19, 19);
			lblTotal.TabIndex = 26;
			lblTotal.Text = "0";
			lblWallLive.AutoSize = true;
			lblWallLive.BackColor = System.Drawing.SystemColors.Control;
			lblWallLive.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblWallLive.ForeColor = System.Drawing.Color.Green;
			lblWallLive.Location = new System.Drawing.Point(361, 51);
			lblWallLive.Name = "lblWallLive";
			lblWallLive.Size = new System.Drawing.Size(19, 19);
			lblWallLive.TabIndex = 29;
			lblWallLive.Text = "0";
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label3.Location = new System.Drawing.Point(22, 53);
			label3.Name = "label3";
			label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label3.Size = new System.Drawing.Size(87, 16);
			label3.TabIndex = 34;
			label3.Text = "Tha\u0300nh công:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label4.Location = new System.Drawing.Point(170, 53);
			label4.Name = "label4";
			label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label4.Size = new System.Drawing.Size(52, 16);
			label4.TabIndex = 35;
			label4.Text = "Lỗi:";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label5.Location = new System.Drawing.Point(295, 53);
			label5.Name = "label5";
			label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label5.Size = new System.Drawing.Size(70, 16);
			label5.TabIndex = 36;
			label5.Text = "Wall Live:";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label6.Location = new System.Drawing.Point(438, 53);
			label6.Name = "label6";
			label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label6.Size = new System.Drawing.Size(64, 16);
			label6.TabIndex = 37;
			label6.Text = "Wall Die:";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(783, 53);
			label7.Name = "label7";
			label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label7.Size = new System.Drawing.Size(63, 16);
			label7.TabIndex = 38;
			label7.Text = "Tô\u0309ng sô\u0301:";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.Location = new System.Drawing.Point(15, 75);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new System.Drawing.Size(924, 28);
			lblStatus.TabIndex = 27;
			lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(14, 397);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(97, 14);
			label8.TabIndex = 39;
			label8.Text = "Định dạng nhập:";
			cbbDinhDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDangNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDangNhap.FormattingEnabled = true;
			cbbDinhDangNhap.Items.AddRange(new object[7] { "Uid|Pass|2FA", "Cookie", "Uid|Pass", "Uid|Pass|Token|Cookie", "Uid|Pass|Token|Cookie|Email|Pass Email", "Uid|Pass|Token|Cookie|Email|Pass Email|2FA", "Other..." });
			cbbDinhDangNhap.Location = new System.Drawing.Point(117, 394);
			cbbDinhDangNhap.Name = "cbbDinhDangNhap";
			cbbDinhDangNhap.Size = new System.Drawing.Size(269, 22);
			cbbDinhDangNhap.TabIndex = 40;
			cbbDinhDangNhap.SelectedIndexChanged += new System.EventHandler(cbbDinhDangNhap_SelectedIndexChanged);
			cbbDinhDang1.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang1.FormattingEnabled = true;
			cbbDinhDang1.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang1.Location = new System.Drawing.Point(3, 3);
			cbbDinhDang1.Name = "cbbDinhDang1";
			cbbDinhDang1.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang1.TabIndex = 40;
			cbbDinhDang1.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 12f);
			label9.Location = new System.Drawing.Point(81, 3);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(15, 19);
			label9.TabIndex = 41;
			label9.Text = "|";
			cbbDinhDang2.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang2.FormattingEnabled = true;
			cbbDinhDang2.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang2.Location = new System.Drawing.Point(96, 3);
			cbbDinhDang2.Name = "cbbDinhDang2";
			cbbDinhDang2.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang2.TabIndex = 40;
			cbbDinhDang2.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 12f);
			label10.Location = new System.Drawing.Point(174, 3);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(15, 19);
			label10.TabIndex = 41;
			label10.Text = "|";
			cbbDinhDang3.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang3.FormattingEnabled = true;
			cbbDinhDang3.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang3.Location = new System.Drawing.Point(189, 3);
			cbbDinhDang3.Name = "cbbDinhDang3";
			cbbDinhDang3.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang3.TabIndex = 40;
			cbbDinhDang3.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Tahoma", 12f);
			label11.Location = new System.Drawing.Point(267, 3);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(15, 19);
			label11.TabIndex = 41;
			label11.Text = "|";
			cbbDinhDang4.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang4.FormattingEnabled = true;
			cbbDinhDang4.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang4.Location = new System.Drawing.Point(282, 3);
			cbbDinhDang4.Name = "cbbDinhDang4";
			cbbDinhDang4.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang4.TabIndex = 40;
			cbbDinhDang4.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Tahoma", 12f);
			label12.Location = new System.Drawing.Point(360, 3);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(15, 19);
			label12.TabIndex = 41;
			label12.Text = "|";
			cbbDinhDang5.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang5.FormattingEnabled = true;
			cbbDinhDang5.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang5.Location = new System.Drawing.Point(375, 3);
			cbbDinhDang5.Name = "cbbDinhDang5";
			cbbDinhDang5.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang5.TabIndex = 40;
			cbbDinhDang5.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Tahoma", 12f);
			label13.Location = new System.Drawing.Point(453, 3);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(15, 19);
			label13.TabIndex = 41;
			label13.Text = "|";
			cbbDinhDang6.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang6.FormattingEnabled = true;
			cbbDinhDang6.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang6.Location = new System.Drawing.Point(468, 3);
			cbbDinhDang6.Name = "cbbDinhDang6";
			cbbDinhDang6.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang6.TabIndex = 40;
			cbbDinhDang6.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Tahoma", 12f);
			label14.Location = new System.Drawing.Point(546, 3);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(15, 19);
			label14.TabIndex = 41;
			label14.Text = "|";
			cbbDinhDang7.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang7.FormattingEnabled = true;
			cbbDinhDang7.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang7.Location = new System.Drawing.Point(561, 3);
			cbbDinhDang7.Name = "cbbDinhDang7";
			cbbDinhDang7.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang7.TabIndex = 40;
			cbbDinhDang7.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(14, 457);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(63, 14);
			label15.TabIndex = 39;
			label15.Text = "Tùy chọn:";
			ckbCheckThongTin.AutoSize = true;
			ckbCheckThongTin.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbCheckThongTin.Location = new System.Drawing.Point(117, 456);
			ckbCheckThongTin.Name = "ckbCheckThongTin";
			ckbCheckThongTin.Size = new System.Drawing.Size(355, 18);
			ckbCheckThongTin.TabIndex = 43;
			ckbCheckThongTin.Text = "Check thông tin (Check Wall, Tên, Giới tính, Bạn bè, Nhóm)";
			ckbCheckThongTin.UseVisualStyleBackColor = true;
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = bunifuCustomLabel1;
			bunifuDragControl1.Vertical = true;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			plDinhDangNhap.Controls.Add(cbbDinhDang1);
			plDinhDangNhap.Controls.Add(cbbDinhDang2);
			plDinhDangNhap.Controls.Add(cbbDinhDang3);
			plDinhDangNhap.Controls.Add(cbbDinhDang4);
			plDinhDangNhap.Controls.Add(label18);
			plDinhDangNhap.Controls.Add(label14);
			plDinhDangNhap.Controls.Add(cbbDinhDang5);
			plDinhDangNhap.Controls.Add(label17);
			plDinhDangNhap.Controls.Add(cbbDinhDang8);
			plDinhDangNhap.Controls.Add(label13);
			plDinhDangNhap.Controls.Add(cbbDinhDang6);
			plDinhDangNhap.Controls.Add(cbbDinhDang9);
			plDinhDangNhap.Controls.Add(label12);
			plDinhDangNhap.Controls.Add(cbbDinhDang7);
			plDinhDangNhap.Controls.Add(label11);
			plDinhDangNhap.Controls.Add(label9);
			plDinhDangNhap.Controls.Add(label10);
			plDinhDangNhap.Location = new System.Drawing.Point(114, 420);
			plDinhDangNhap.Name = "plDinhDangNhap";
			plDinhDangNhap.Size = new System.Drawing.Size(834, 28);
			plDinhDangNhap.TabIndex = 46;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Tahoma", 12f);
			label18.Location = new System.Drawing.Point(732, 3);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(15, 19);
			label18.TabIndex = 41;
			label18.Text = "|";
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Tahoma", 12f);
			label17.Location = new System.Drawing.Point(639, 3);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(15, 19);
			label17.TabIndex = 41;
			label17.Text = "|";
			cbbDinhDang8.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang8.FormattingEnabled = true;
			cbbDinhDang8.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang8.Location = new System.Drawing.Point(654, 3);
			cbbDinhDang8.Name = "cbbDinhDang8";
			cbbDinhDang8.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang8.TabIndex = 40;
			cbbDinhDang8.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			cbbDinhDang9.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbDinhDang9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbDinhDang9.FormattingEnabled = true;
			cbbDinhDang9.Items.AddRange(new object[11]
			{
				"Uid", "Pass", "Token", "Cookie", "Email", "Pass Email", "2FA", "Useragent", "Proxy", "Birthday",
				"LD Index"
			});
			cbbDinhDang9.Location = new System.Drawing.Point(747, 3);
			cbbDinhDang9.Name = "cbbDinhDang9";
			cbbDinhDang9.Size = new System.Drawing.Size(78, 22);
			cbbDinhDang9.TabIndex = 40;
			cbbDinhDang9.SelectedIndexChanged += new System.EventHandler(cbbDinhDang1_SelectedIndexChanged);
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(14, 368);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(90, 14);
			label16.TabIndex = 39;
			label16.Text = "Cho\u0323n thư mu\u0323c:";
			cbbThuMuc.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbThuMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbThuMuc.DropDownWidth = 269;
			cbbThuMuc.FormattingEnabled = true;
			cbbThuMuc.Location = new System.Drawing.Point(117, 365);
			cbbThuMuc.Name = "cbbThuMuc";
			cbbThuMuc.Size = new System.Drawing.Size(201, 22);
			cbbThuMuc.TabIndex = 40;
			cbbThuMuc.SelectedIndexChanged += new System.EventHandler(cbbThuMuc_SelectedIndexChanged);
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.Location = new System.Drawing.Point(324, 364);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(62, 25);
			button1.TabIndex = 45;
			button1.Text = "Thêm";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			txbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txbAccount.Location = new System.Drawing.Point(15, 120);
			txbAccount.Name = "txbAccount";
			txbAccount.Size = new System.Drawing.Size(924, 238);
			txbAccount.TabIndex = 48;
			txbAccount.Text = "";
			txbAccount.WordWrap = false;
			txbAccount.TextChanged += new System.EventHandler(TxbAccount_TextChanged);
			lblKhongCheckDuoc.AutoSize = true;
			lblKhongCheckDuoc.BackColor = System.Drawing.SystemColors.Control;
			lblKhongCheckDuoc.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblKhongCheckDuoc.ForeColor = System.Drawing.Color.Maroon;
			lblKhongCheckDuoc.Location = new System.Drawing.Point(705, 51);
			lblKhongCheckDuoc.Name = "lblKhongCheckDuoc";
			lblKhongCheckDuoc.Size = new System.Drawing.Size(19, 19);
			lblKhongCheckDuoc.TabIndex = 25;
			lblKhongCheckDuoc.Text = "0";
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
			label2.Location = new System.Drawing.Point(578, 53);
			label2.Name = "label2";
			label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			label2.Size = new System.Drawing.Size(131, 16);
			label2.TabIndex = 37;
			label2.Text = "Không Check được:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(953, 535);
			base.Controls.Add(txbAccount);
			base.Controls.Add(plDinhDangNhap);
			base.Controls.Add(button1);
			base.Controls.Add(ckbCheckThongTin);
			base.Controls.Add(cbbThuMuc);
			base.Controls.Add(cbbDinhDangNhap);
			base.Controls.Add(label15);
			base.Controls.Add(label16);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label2);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(lblWallLive);
			base.Controls.Add(lblStatus);
			base.Controls.Add(lblKhongCheckDuoc);
			base.Controls.Add(lblTotal);
			base.Controls.Add(lblWallDie);
			base.Controls.Add(lblError);
			base.Controls.Add(lblSuccess);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fImportAccount";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Nhập tài khoản";
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			plDinhDangNhap.ResumeLayout(false);
			plDinhDangNhap.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
