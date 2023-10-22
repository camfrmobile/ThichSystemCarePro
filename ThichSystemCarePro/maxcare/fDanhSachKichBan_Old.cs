using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.KichBan;
using maxcare.Properties;
using MCommon;

namespace maxcare
{
	public class fDanhSachKichBan_Old : Form
	{
		private string kichBan = "";

		private IContainer components = null;

		private ToolTip toolTip1;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private GroupBox groupBox1;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button button1;

		private GroupBox groupBox2;

		public DataGridView dtgvKichBan;

		public DataGridView dtgvHanhDong;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem thêmMớiToolStripMenuItem;

		private ToolStripMenuItem sửaToolStripMenuItem;

		private ToolStripMenuItem xóaToolStripMenuItem;

		private ToolStripMenuItem nhânBảnToolStripMenuItem;

		private Button button3;

		private Button button2;

		private ContextMenuStrip contextMenuStrip2;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem toolStripMenuItem2;

		private DataGridViewTextBoxColumn cStt;

		private DataGridViewTextBoxColumn cId_KichBan;

		private DataGridViewTextBoxColumn cTenKichBan;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn cId_HanhDong;

		private DataGridViewTextBoxColumn cTenHanhDong;

		private DataGridViewTextBoxColumn cTheLoai;

		private Panel panel1;

		public fDanhSachKichBan_Old(string kickBan)
		{
			InitializeComponent();
			ChangeLanguage();
			kichBan = kickBan;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(groupBox1);
			foreach (DataGridViewColumn column in dtgvKichBan.Columns)
			{
				Language.GetValue(column);
			}
			Language.GetValue(groupBox2);
			foreach (DataGridViewColumn column2 in dtgvHanhDong.Columns)
			{
				Language.GetValue(column2);
			}
			Language.GetValue(thêmMớiToolStripMenuItem);
			Language.GetValue(sửaToolStripMenuItem);
			Language.GetValue(xóaToolStripMenuItem);
			Language.GetValue(nhânBảnToolStripMenuItem);
			Language.GetValue(toolStripMenuItem1);
			Language.GetValue(toolStripMenuItem3);
			Language.GetValue(toolStripMenuItem4);
			Language.GetValue(toolStripMenuItem2);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			LoadKichBan(kichBan);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SuaKichBan();
		}

		private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			XoaKichBan();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			XoaHanhDong();
		}

		public void DoiChoDgv(ref DataGridView dgv, int oldRow, int newRow)
		{
			string text = "";
			for (int i = 1; i < dgv.Columns.Count; i++)
			{
				text = DatagridviewHelper.GetStatusDataGridView(dgv, oldRow, i);
				DatagridviewHelper.SetStatusDataGridView(dgv, oldRow, i, DatagridviewHelper.GetStatusDataGridView(dgv, newRow, i));
				DatagridviewHelper.SetStatusDataGridView(dgv, newRow, i, text);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int index = dtgvHanhDong.SelectedRows[0].Index;
			if (index == 0)
			{
				return;
			}
			string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvHanhDong, index - 1, "cId_HanhDong");
			string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvHanhDong, index, "cId_HanhDong");
			if (statusDataGridView + statusDataGridView2 != "")
			{
				if (InteractSQL.UpdateThuTuHanhDong(statusDataGridView, statusDataGridView2))
				{
					DoiChoDgv(ref dtgvHanhDong, index, index - 1);
					dtgvHanhDong.Rows[index - 1].Selected = true;
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int index = dtgvHanhDong.SelectedRows[0].Index;
			if (index == dtgvHanhDong.RowCount - 1)
			{
				return;
			}
			string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dtgvHanhDong, index + 1, "cId_HanhDong");
			string statusDataGridView2 = DatagridviewHelper.GetStatusDataGridView(dtgvHanhDong, index, "cId_HanhDong");
			if (statusDataGridView + statusDataGridView2 != "")
			{
				if (InteractSQL.UpdateThuTuHanhDong(statusDataGridView, statusDataGridView2))
				{
					DoiChoDgv(ref dtgvHanhDong, index, index + 1);
					dtgvHanhDong.Rows[index + 1].Selected = true;
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i xa\u0309y ra, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
		}

		private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ThemKichBan();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ThemHanhDong();
		}

		private void nhânBảnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NhanBanKichBan();
		}

		private void dtgvKichBan_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				LoadHanhDong();
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			SuaHanhDong();
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			NhanBanHanhDong();
		}

		private void dtgvHanhDong_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
			case Keys.Delete:
				XoaHanhDong();
				break;
			case Keys.Insert:
			case Keys.F1:
				ThemHanhDong();
				break;
			case Keys.F2:
				SuaHanhDong();
				break;
			case Keys.F5:
				LoadHanhDong();
				break;
			case Keys.D:
				if (e.Modifiers == Keys.Control)
				{
					NhanBanHanhDong();
				}
				break;
			}
		}

		private void NhanBanHanhDong()
		{
			try
			{
				if (dtgvHanhDong.RowCount == 0)
				{
					MessageBoxHelper.ShowMessageBox("Vui lòng thêm hành động trước!", 3);
					return;
				}
				DataGridViewRow dataGridViewRow = dtgvHanhDong.SelectedRows[0];
				string id_HanhDong = dataGridViewRow.Cells["cId_HanhDong"].Value.ToString();
				string text = dataGridViewRow.Cells["cTenHanhDong"].Value.ToString();
				string text2 = text + " - Copy";
				int num = 2;
				while (InteractSQL.CheckExistTenHanhDong(text2))
				{
					text2 = text + $" - Copy ({num++})";
				}
				if (InteractSQL.DuplicateHanhDong(id_HanhDong, text2))
				{
					DataTable hanhDongMoi = InteractSQL.GetHanhDongMoi();
					dtgvHanhDong.Rows.Add(dtgvHanhDong.RowCount + 1, hanhDongMoi.Rows[0]["Id_HanhDong"], hanhDongMoi.Rows[0]["TenHanhDong"], hanhDongMoi.Rows[0]["MoTa"]);
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
			catch
			{
			}
		}

		private void LoadHanhDong()
		{
			try
			{
				dtgvHanhDong.Rows.Clear();
				if (dtgvKichBan.RowCount != 0)
				{
					DataGridViewRow dataGridViewRow = dtgvKichBan.SelectedRows[0];
					string idKichBan = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
					DataTable allHanhDongByKichBan = InteractSQL.GetAllHanhDongByKichBan(idKichBan);
					for (int i = 0; i < allHanhDongByKichBan.Rows.Count; i++)
					{
						dtgvHanhDong.Rows.Add(dtgvHanhDong.RowCount + 1, allHanhDongByKichBan.Rows[i]["Id_HanhDong"], allHanhDongByKichBan.Rows[i]["TenHanhDong"], allHanhDongByKichBan.Rows[i]["MoTa"]);
					}
				}
			}
			catch
			{
			}
		}

		private void XoaHanhDong()
		{
			try
			{
				if (dtgvHanhDong.RowCount == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thêm hành động trước!"), 3);
				}
				else
				{
					if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Bạn có chắc muốn xóa hoạt động này?")) != DialogResult.Yes)
					{
						return;
					}
					DataGridViewRow dataGridViewRow = dtgvHanhDong.SelectedRows[0];
					if (InteractSQL.DeleteHanhDongByIdHanhDong(dataGridViewRow.Cells["cId_HanhDong"].Value.ToString()))
					{
						int index = dataGridViewRow.Index;
						for (int i = index; i < dtgvHanhDong.Rows.Count - 1; i++)
						{
							DoiChoDgv(ref dtgvHanhDong, i, i + 1);
						}
						dtgvHanhDong.Rows.RemoveAt(dtgvHanhDong.Rows.Count - 1);
					}
					else
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
					}
					return;
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}

		private void ThemHanhDong()
		{
			try
			{
				if (dtgvKichBan.RowCount == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thêm kịch bản trước!"), 3);
					return;
				}
				DataGridViewRow dataGridViewRow = dtgvKichBan.SelectedRows[0];
				string text = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
				int count = InteractSQL.GetAllHanhDongByKichBan(text).Rows.Count;
				MCommon.Common.ShowForm(new fThemHanhDong(text));
				DataTable allHanhDongByKichBan = InteractSQL.GetAllHanhDongByKichBan(text);
				int count2 = allHanhDongByKichBan.Rows.Count;
				if (count2 > count)
				{
					dtgvHanhDong.Rows.Add(dtgvHanhDong.RowCount + 1, allHanhDongByKichBan.Rows[count2 - 1]["Id_HanhDong"], allHanhDongByKichBan.Rows[count2 - 1]["TenHanhDong"], allHanhDongByKichBan.Rows[count2 - 1]["MoTa"]);
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}

		private void SuaHanhDong()
		{
			try
			{
				if (dtgvHanhDong.RowCount == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thêm hành động trước!"), 3);
					return;
				}
				DataGridViewRow dataGridViewRow = dtgvHanhDong.SelectedRows[0];
				string text = dataGridViewRow.Cells["cId_HanhDong"].Value.ToString();
				DataTable hanhDongById = InteractSQL.GetHanhDongById(text);
				string name = "maxcare.f" + hanhDongById.Rows[0]["TenTuongTac"];
				Form formByName = MCommon.Common.GetFormByName(name, text);
				if (formByName != null)
				{
					MCommon.Common.ShowForm(formByName);
				}
				hanhDongById = InteractSQL.GetHanhDongById(text);
				DatagridviewHelper.SetStatusDataGridView(dtgvHanhDong, dataGridViewRow.Index, "cTenHanhDong", hanhDongById.Rows[0]["TenHanhDong"].ToString());
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}

		private void dtgvKichBan_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
			case Keys.Delete:
				XoaKichBan();
				break;
			case Keys.Insert:
			case Keys.F1:
				ThemKichBan();
				break;
			case Keys.F2:
				SuaKichBan();
				break;
			case Keys.F5:
				LoadKichBan();
				break;
			case Keys.D:
				if (e.Modifiers == Keys.Control)
				{
					NhanBanKichBan();
				}
				break;
			}
		}

		private void LoadKichBan(string kichBan = "")
		{
			try
			{
				dtgvKichBan.Rows.Clear();
				DataTable allKichBan = InteractSQL.GetAllKichBan();
				if (allKichBan.Rows.Count > 0)
				{
					for (int i = 0; i < allKichBan.Rows.Count; i++)
					{
						DataRow dataRow = allKichBan.Rows[i];
						dtgvKichBan.Rows.Add(i + 1, dataRow["Id_KichBan"], dataRow["TenKichBan"]);
					}
				}
				if (kichBan != "")
				{
					for (int j = 0; j < dtgvKichBan.RowCount; j++)
					{
						if (DatagridviewHelper.GetStatusDataGridView(dtgvKichBan, j, "cId_KichBan") == kichBan)
						{
							dtgvKichBan.Rows[j].Selected = true;
							break;
						}
					}
				}
				LoadHanhDong();
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
			}
		}

		private void XoaKichBan()
		{
			try
			{
				if (dtgvKichBan.RowCount == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thêm kịch bản trước!"), 3);
				}
				else
				{
					if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Bạn có chắc muốn xóa kịch bản này?")) != DialogResult.Yes)
					{
						return;
					}
					DataGridViewRow dataGridViewRow = dtgvKichBan.SelectedRows[0];
					if (InteractSQL.DeleteKichBan(dataGridViewRow.Cells["cId_KichBan"].Value.ToString()))
					{
						int index = dataGridViewRow.Index;
						for (int i = index; i < dtgvKichBan.Rows.Count - 1; i++)
						{
							DoiChoDgv(ref dtgvKichBan, i, i + 1);
						}
						dtgvKichBan.Rows.RemoveAt(dtgvKichBan.Rows.Count - 1);
						LoadHanhDong();
					}
					else
					{
						MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
					}
					return;
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}

		private void SuaKichBan()
		{
			try
			{
				if (dtgvKichBan.RowCount == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thêm kịch bản trước!"), 3);
					return;
				}
				DataGridViewRow dataGridViewRow = dtgvKichBan.SelectedRows[0];
				string id = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
				MCommon.Common.ShowForm(new fThemKichBan(1, id));
				string status = InteractSQL.GetKichBanById(id).Rows[0]["TenKichBan"].ToString();
				DatagridviewHelper.SetStatusDataGridView(dtgvKichBan, dataGridViewRow.Index, "cTenKichBan", status);
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}

		private void ThemKichBan()
		{
			try
			{
				string text = "";
				try
				{
					text = InteractSQL.GetKichBanMoi().Rows[0]["Id_KichBan"].ToString();
				}
				catch
				{
				}
				MCommon.Common.ShowForm(new fThemKichBan(0));
				DataTable kichBanMoi = InteractSQL.GetKichBanMoi();
				string text2 = "";
				try
				{
					text2 = kichBanMoi.Rows[0]["Id_KichBan"].ToString();
				}
				catch
				{
				}
				if (text != text2)
				{
					dtgvKichBan.Rows.Add(dtgvKichBan.RowCount + 1, kichBanMoi.Rows[0]["Id_KichBan"], kichBanMoi.Rows[0]["TenKichBan"]);
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(null, ex);
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
			}
		}

		private void NhanBanKichBan()
		{
			try
			{
				if (dtgvKichBan.RowCount == 0)
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Vui lòng thêm kịch bản trước!"), 3);
					return;
				}
				DataGridViewRow dataGridViewRow = dtgvKichBan.SelectedRows[0];
				string id_KichBanCu = dataGridViewRow.Cells["cId_KichBan"].Value.ToString();
				string text = dataGridViewRow.Cells["cTenKichBan"].Value.ToString();
				string text2 = text + " - Copy";
				int num = 2;
				while (InteractSQL.CheckExistTenKichBan(text2))
				{
					text2 = text + $" - Copy ({num++})";
				}
				if (InteractSQL.DuplicateKichBan(id_KichBanCu, text2))
				{
					DataTable kichBanMoi = InteractSQL.GetKichBanMoi();
					dtgvKichBan.Rows.Add(dtgvKichBan.RowCount + 1, kichBanMoi.Rows[0]["Id_KichBan"], kichBanMoi.Rows[0]["TenKichBan"]);
				}
				else
				{
					MessageBoxHelper.ShowMessageBox(Language.GetValue("Co\u0301 lô\u0303i, vui lo\u0300ng thư\u0309 la\u0323i sau!"), 2);
				}
			}
			catch
			{
			}
		}

		private void dtgvKichBan_KeyUp(object sender, KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			Keys keys = keyCode;
			if (keys == Keys.Up || keys == Keys.Down)
			{
				LoadHanhDong();
			}
		}

		private void fDanhSachKichBan_Paint(object sender, PaintEventArgs e)
		{
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			if (panel1.BorderStyle == BorderStyle.FixedSingle)
			{
				int num = 1;
				int num2 = 0;
				using Pen pen = new Pen(Color.DarkViolet, 1f);
				e.Graphics.DrawRectangle(pen, new Rectangle(num2, num2, panel1.ClientSize.Width - num, panel1.ClientSize.Height - num));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fChonKichBan));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			dtgvKichBan = new System.Windows.Forms.DataGridView();
			cStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cId_KichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cTenKichBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			nhânBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			groupBox2 = new System.Windows.Forms.GroupBox();
			button3 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			dtgvHanhDong = new System.Windows.Forms.DataGridView();
			dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cId_HanhDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cTenHanhDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
			contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			panel1 = new System.Windows.Forms.Panel();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dtgvKichBan).BeginInit();
			contextMenuStrip1.SuspendLayout();
			bunifuCards1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dtgvHanhDong).BeginInit();
			contextMenuStrip2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			toolTip1.ToolTipTitle = "Chú thích";
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(771, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Qua\u0309n ly\u0301 ki\u0323ch ba\u0309n";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(771, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(742, 2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(30, 30);
			button1.TabIndex = 77;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 76;
			pictureBox1.TabStop = false;
			groupBox1.BackColor = System.Drawing.Color.White;
			groupBox1.Controls.Add(dtgvKichBan);
			groupBox1.Location = new System.Drawing.Point(12, 41);
			groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox1.Size = new System.Drawing.Size(308, 559);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Danh sách kịch bản";
			dtgvKichBan.AllowUserToAddRows = false;
			dtgvKichBan.AllowUserToDeleteRows = false;
			dtgvKichBan.AllowUserToResizeRows = false;
			dtgvKichBan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvKichBan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dtgvKichBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvKichBan.Columns.AddRange(cStt, cId_KichBan, cTenKichBan);
			dtgvKichBan.ContextMenuStrip = contextMenuStrip1;
			dtgvKichBan.Dock = System.Windows.Forms.DockStyle.Fill;
			dtgvKichBan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dtgvKichBan.Location = new System.Drawing.Point(3, 20);
			dtgvKichBan.MultiSelect = false;
			dtgvKichBan.Name = "dtgvKichBan";
			dtgvKichBan.RowHeadersVisible = false;
			dtgvKichBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvKichBan.Size = new System.Drawing.Size(302, 535);
			dtgvKichBan.TabIndex = 76;
			dtgvKichBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dtgvKichBan_CellClick);
			dtgvKichBan.KeyDown += new System.Windows.Forms.KeyEventHandler(dtgvKichBan_KeyDown);
			dtgvKichBan.KeyUp += new System.Windows.Forms.KeyEventHandler(dtgvKichBan_KeyUp);
			cStt.HeaderText = "STT";
			cStt.Name = "cStt";
			cStt.Width = 35;
			cId_KichBan.HeaderText = "Column1";
			cId_KichBan.Name = "cId_KichBan";
			cId_KichBan.Visible = false;
			cTenKichBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cTenKichBan.HeaderText = "Tên kịch bản";
			cTenKichBan.Name = "cTenKichBan";
			cTenKichBan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { thêmMớiToolStripMenuItem, sửaToolStripMenuItem, xóaToolStripMenuItem, nhânBảnToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(162, 92);
			thêmMớiToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_add_24px_1;
			thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
			thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			thêmMớiToolStripMenuItem.Text = "Thêm ki\u0323ch ba\u0309n";
			thêmMớiToolStripMenuItem.Click += new System.EventHandler(thêmMớiToolStripMenuItem_Click);
			sửaToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_edit_24px_1;
			sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
			sửaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			sửaToolStripMenuItem.Text = "Sửa tên ki\u0323ch ba\u0309n";
			sửaToolStripMenuItem.Click += new System.EventHandler(sửaToolStripMenuItem_Click);
			xóaToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_delete_file_24px_1;
			xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
			xóaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			xóaToolStripMenuItem.Text = "Xóa ki\u0323ch ba\u0309n";
			xóaToolStripMenuItem.Click += new System.EventHandler(xóaToolStripMenuItem_Click);
			nhânBảnToolStripMenuItem.Image = maxcare.Properties.Resources.icons8_copy_24px_1;
			nhânBảnToolStripMenuItem.Name = "nhânBảnToolStripMenuItem";
			nhânBảnToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			nhânBảnToolStripMenuItem.Text = "Nhân bản";
			nhânBảnToolStripMenuItem.Click += new System.EventHandler(nhânBảnToolStripMenuItem_Click);
			bunifuCards1.BackColor = System.Drawing.Color.White;
			bunifuCards1.BorderRadius = 0;
			bunifuCards1.BottomSahddow = true;
			bunifuCards1.color = System.Drawing.Color.DarkViolet;
			bunifuCards1.Controls.Add(pnlHeader);
			bunifuCards1.LeftSahddow = false;
			bunifuCards1.Location = new System.Drawing.Point(1, 0);
			bunifuCards1.Name = "bunifuCards1";
			bunifuCards1.RightSahddow = true;
			bunifuCards1.ShadowDepth = 20;
			bunifuCards1.Size = new System.Drawing.Size(774, 37);
			bunifuCards1.TabIndex = 12;
			groupBox2.BackColor = System.Drawing.Color.White;
			groupBox2.Controls.Add(button3);
			groupBox2.Controls.Add(button2);
			groupBox2.Controls.Add(dtgvHanhDong);
			groupBox2.Location = new System.Drawing.Point(338, 41);
			groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			groupBox2.Size = new System.Drawing.Size(427, 559);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Danh sách hành động";
			button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button3.Cursor = System.Windows.Forms.Cursors.Hand;
			button3.Image = maxcare.Properties.Resources.icons8_down_arrow_32px;
			button3.Location = new System.Drawing.Point(382, 64);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(41, 38);
			button3.TabIndex = 78;
			button3.UseVisualStyleBackColor = true;
			button3.Click += new System.EventHandler(button3_Click);
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.Image = maxcare.Properties.Resources.icons8_up_32px;
			button2.Location = new System.Drawing.Point(382, 19);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(41, 38);
			button2.TabIndex = 78;
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			dtgvHanhDong.AllowUserToAddRows = false;
			dtgvHanhDong.AllowUserToDeleteRows = false;
			dtgvHanhDong.AllowUserToResizeRows = false;
			dtgvHanhDong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			dtgvHanhDong.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dtgvHanhDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dtgvHanhDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dtgvHanhDong.Columns.AddRange(dataGridViewTextBoxColumn1, cId_HanhDong, cTenHanhDong, cTheLoai);
			dtgvHanhDong.ContextMenuStrip = contextMenuStrip2;
			dtgvHanhDong.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dtgvHanhDong.Location = new System.Drawing.Point(6, 20);
			dtgvHanhDong.MultiSelect = false;
			dtgvHanhDong.Name = "dtgvHanhDong";
			dtgvHanhDong.RowHeadersVisible = false;
			dtgvHanhDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dtgvHanhDong.Size = new System.Drawing.Size(373, 535);
			dtgvHanhDong.TabIndex = 77;
			dtgvHanhDong.KeyDown += new System.Windows.Forms.KeyEventHandler(dtgvHanhDong_KeyDown);
			dataGridViewTextBoxColumn1.HeaderText = "STT";
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			dataGridViewTextBoxColumn1.Width = 35;
			cId_HanhDong.HeaderText = "Column1";
			cId_HanhDong.Name = "cId_HanhDong";
			cId_HanhDong.Visible = false;
			cTenHanhDong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			cTenHanhDong.HeaderText = "Tên hành động";
			cTenHanhDong.Name = "cTenHanhDong";
			cTenHanhDong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cTheLoai.HeaderText = "Loại tương tác";
			cTheLoai.Name = "cTheLoai";
			cTheLoai.Width = 175;
			contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { toolStripMenuItem1, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem2 });
			contextMenuStrip2.Name = "contextMenuStrip1";
			contextMenuStrip2.Size = new System.Drawing.Size(166, 92);
			toolStripMenuItem1.Image = maxcare.Properties.Resources.icons8_add_24px;
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			toolStripMenuItem1.Text = "Thêm ha\u0300nh đô\u0323ng";
			toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
			toolStripMenuItem3.Image = maxcare.Properties.Resources.icons8_edit_24px;
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(165, 22);
			toolStripMenuItem3.Text = "Sửa ha\u0300nh đô\u0323ng";
			toolStripMenuItem3.Click += new System.EventHandler(toolStripMenuItem3_Click);
			toolStripMenuItem4.Image = maxcare.Properties.Resources.icons8_delete_file_24px;
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new System.Drawing.Size(165, 22);
			toolStripMenuItem4.Text = "Xóa ha\u0300nh đô\u0323ng";
			toolStripMenuItem4.Click += new System.EventHandler(toolStripMenuItem4_Click);
			toolStripMenuItem2.Image = maxcare.Properties.Resources.icons8_copy_24px;
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
			toolStripMenuItem2.Text = "Nhân bản";
			toolStripMenuItem2.Click += new System.EventHandler(toolStripMenuItem2_Click);
			panel1.BackColor = System.Drawing.Color.White;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(bunifuCards1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(777, 607);
			panel1.TabIndex = 13;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(777, 607);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fDanhSachKichBan";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			base.Paint += new System.Windows.Forms.PaintEventHandler(fDanhSachKichBan_Paint);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dtgvKichBan).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			bunifuCards1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dtgvHanhDong).EndInit();
			contextMenuStrip2.ResumeLayout(false);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
