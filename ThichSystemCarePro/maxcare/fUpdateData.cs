using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;
using MetroFramework;
using MetroFramework.Controls;

namespace maxcare
{
	public class fUpdateData : Form
	{
		private fMain main;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private MetroComboBox cbbTypeUpdate;

		private Label label1;

		private TextBox txbData;

		private Label label2;

		private Button btnCancel;

		private Button btnAdd;

		private PictureBox pictureBox1;

		private Label label3;

		private ComboBox cbbTypeProxy;

		public fUpdateData(fMain main, string mode)
		{
			InitializeComponent();
			ChangeLanguage();
			this.main = main;
			cbbTypeUpdate.Text = mode;
			cbbTypeProxy.SelectedIndex = 0;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(label1);
			Language.GetValue(label2);
			Language.GetValue(label3);
			Language.GetValue(btnAdd);
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

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = false;
				if (txbData.Text.Equals("") || txbData.Text.Equals("|"))
				{
					if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Ba\u0323n co\u0301 chă\u0301c muô\u0301n xo\u0301a dư\u0303 liê\u0323u của {0} tài khoản?"), main.CountChooseRowInDatagridview())) == DialogResult.Yes)
					{
						flag = true;
					}
				}
				else if (MessageBoxHelper.ShowMessageBoxWithQuestion(string.Format(Language.GetValue("Ba\u0323n co\u0301 chă\u0301c muô\u0301n câ\u0323p nhâ\u0323t dư\u0303 liê\u0323u của {0} tài khoản?"), main.CountChooseRowInDatagridview())) == DialogResult.Yes)
				{
					flag = true;
				}
				if (!flag)
				{
					return;
				}
				List<string> list = new List<string>();
				string text = txbData.Text;
				for (int i = 0; i < main.dtgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(main.dtgvAcc.Rows[i].Cells["cChose"].Value))
					{
						list.Add(main.GetCellAccount(i, "cId"));
					}
				}
				switch (cbbTypeUpdate.Text)
				{
				case "Notes":
				{
					if (!CommonSQL.UpdateFieldToAccount(list, "ghiChu", text))
					{
						break;
					}
					for (int l = 0; l < main.dtgvAcc.Rows.Count; l++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[l].Cells["cChose"].Value))
						{
							main.SetCellAccount(l, "cGhiChu", text);
						}
					}
					break;
				}
				case "Mail|pass":
				{
					if (text.Split('|').Length != 2)
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lo\u0300ng nhâ\u0323p la\u0323i đi\u0323nh da\u0323ng Mail|Pass Mail!"), 3);
						return;
					}
					if (!CommonSQL.UpdateMultiFieldToAccount(list, "email|passmail", text))
					{
						break;
					}
					for (int num4 = 0; num4 < main.dtgvAcc.Rows.Count; num4++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							main.SetCellAccount(num4, "cEmail", text.Split('|')[0]);
							main.SetCellAccount(num4, "cPassMail", text.Split('|')[1]);
						}
					}
					break;
				}
				case "Token":
				{
					if (!CommonSQL.UpdateFieldToAccount(list, "token", text))
					{
						break;
					}
					for (int n = 0; n < main.dtgvAcc.Rows.Count; n++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[n].Cells["cChose"].Value))
						{
							main.SetCellAccount(n, "cToken", text);
						}
					}
					break;
				}
				case "Password":
				{
					if (!CommonSQL.UpdateFieldToAccount(list, "pass", text))
					{
						break;
					}
					for (int num3 = 0; num3 < main.dtgvAcc.Rows.Count; num3++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							main.SetCellAccount(num3, "cPassword", text);
						}
					}
					break;
				}
				case "2FA":
				{
					if (!CommonSQL.UpdateFieldToAccount(list, "fa2", text))
					{
						break;
					}
					for (int num = 0; num < main.dtgvAcc.Rows.Count; num++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[num].Cells["cChose"].Value))
						{
							main.SetCellAccount(num, "cFa2", text);
						}
					}
					break;
				}
				case "Proxy":
				{
					int selectedIndex = cbbTypeProxy.SelectedIndex;
					string text2 = ((text == "") ? "" : (text + "*" + selectedIndex));
					if (!CommonSQL.UpdateFieldToAccount(list, "proxy", text2))
					{
						break;
					}
					for (int k = 0; k < main.dtgvAcc.Rows.Count; k++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[k].Cells["cChose"].Value))
						{
							main.SetCellAccount(k, "cProxy", text2);
						}
					}
					break;
				}
				case "Useragent":
				{
					if (!CommonSQL.UpdateFieldToAccount(list, "useragent", text))
					{
						break;
					}
					for (int num2 = 0; num2 < main.dtgvAcc.Rows.Count; num2++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							main.SetCellAccount(num2, "cUseragent", text);
						}
					}
					break;
				}
				case "Birthday":
				{
					if (!CommonSQL.UpdateFieldToAccount(list, "birthday", text))
					{
						break;
					}
					for (int m = 0; m < main.dtgvAcc.Rows.Count; m++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[m].Cells["cChose"].Value))
						{
							main.SetCellAccount(m, "cBirthday", text);
						}
					}
					break;
				}
				case "Cookie":
				{
					if (!CommonSQL.UpdateFieldToAccount(list, "cookie1", text))
					{
						break;
					}
					for (int j = 0; j < main.dtgvAcc.Rows.Count; j++)
					{
						if (Convert.ToBoolean(main.dtgvAcc.Rows[j].Cells["cChose"].Value))
						{
							main.SetCellAccount(j, "cCookies", text);
						}
					}
					break;
				}
				}
				Close();
			}
			catch
			{
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thử lại sau!"), 2);
			}
		}

		private void cbbTypeUpdate_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool visible = cbbTypeUpdate.Text == "Proxy";
			label3.Visible = visible;
			cbbTypeProxy.Visible = visible;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fUpdateData));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			btnMinimize = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			cbbTypeUpdate = new MetroFramework.Controls.MetroComboBox();
			label1 = new System.Windows.Forms.Label();
			txbData = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			cbbTypeProxy = new System.Windows.Forms.ComboBox();
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 5;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.SaddleBrown;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(0, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(416, 38);
			bunifuCards1.TabIndex = 12;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(416, 32);
			pnlHeader.TabIndex = 9;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(382, -1);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 32);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 79;
			pictureBox1.TabStop = false;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(416, 32);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Cập nhật dữ liệu";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			cbbTypeUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTypeUpdate.FontSize = MetroFramework.MetroComboBoxSize.Small;
			cbbTypeUpdate.FormattingEnabled = true;
			cbbTypeUpdate.ItemHeight = 19;
			cbbTypeUpdate.Items.AddRange(new object[9] { "Token", "Cookie", "Password", "Mail|pass", "2FA", "Birthday", "Useragent", "Proxy", "Notes" });
			cbbTypeUpdate.Location = new System.Drawing.Point(146, 43);
			cbbTypeUpdate.Name = "cbbTypeUpdate";
			cbbTypeUpdate.Size = new System.Drawing.Size(238, 25);
			cbbTypeUpdate.TabIndex = 13;
			cbbTypeUpdate.UseSelectable = true;
			cbbTypeUpdate.SelectedIndexChanged += new System.EventHandler(cbbTypeUpdate_SelectedIndexChanged);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(34, 51);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(106, 16);
			label1.TabIndex = 14;
			label1.Text = "Dữ liệu cập nhật:";
			txbData.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txbData.Location = new System.Drawing.Point(146, 79);
			txbData.Name = "txbData";
			txbData.Size = new System.Drawing.Size(238, 23);
			txbData.TabIndex = 15;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(34, 82);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(85, 16);
			label2.TabIndex = 16;
			label2.Text = "Nhập dữ liệu:";
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(209, 145);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 18;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(111, 145);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 17;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(34, 111);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(71, 16);
			label3.TabIndex = 16;
			label3.Text = "Loại proxy:";
			cbbTypeProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTypeProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbTypeProxy.Enabled = false;
			cbbTypeProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbTypeProxy.FormattingEnabled = true;
			cbbTypeProxy.Items.AddRange(new object[2] { "HTTP", "Sock5" });
			cbbTypeProxy.Location = new System.Drawing.Point(146, 108);
			cbbTypeProxy.Name = "cbbTypeProxy";
			cbbTypeProxy.Size = new System.Drawing.Size(130, 24);
			cbbTypeProxy.TabIndex = 124;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(416, 188);
			base.Controls.Add(cbbTypeProxy);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(txbData);
			base.Controls.Add(label1);
			base.Controls.Add(cbbTypeUpdate);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fUpdateData";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "fUpdateData";
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
