using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using maxcare.Properties;
using MCommon;
using MetroFramework.Controls;

namespace maxcare
{
	public class fThemHanhDong : Form
	{
		private string id_KichBan;

		private IContainer components = null;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private PictureBox pictureBox1;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button button1;

		private GroupBox groupBox2;

		private MetroButton metroButton3;

		private MetroButton metroButton2;

		private MetroButton btnDocThongBao;

		private GroupBox groupBox1;

		private GroupBox groupBox4;

		private MetroButton metroButton18;

		private MetroButton metroButton9;

		private MetroButton metroButton17;

		private MetroButton metroButton13;

		private MetroButton metroButton14;

		private MetroButton metroButton22;

		private MetroButton metroButton23;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		private PictureBox pictureBox5;

		private MetroButton metroButton21;

		private Panel panel1;

		private GroupBox groupBox3;

		private PictureBox pictureBox6;

		private ToolTip toolTip1;

		private MetroButton metroButton29;

		private MetroButton metroButton34;

		private MetroButton metroButton35;

		private MetroButton metroButton38;

		private MetroButton metroButton41;

		private MetroButton metroButton40;

		private MetroButton metroButton39;

		private MetroButton metroButton43;

		private MetroButton metroButton42;

		private MetroButton metroButton6;

		private MetroButton metroButton5;

		private GroupBox groupBox7;

		private PictureBox pictureBox8;

		private MetroButton metroButton8;

		private MetroButton metroButton10;

		private MetroButton metroButton12;

		private MetroButton metroButton11;

		private MetroButton metroButton15;

		private MetroButton metroButton16;

		private MetroButton metroButton19;

		private MetroButton metroButton1;

		private MetroButton metroButton20;

		private MetroButton metroButton24;

		private MetroButton metroButton25;

		private MetroButton metroButton4;

		private MetroButton metroButton7;

		private MetroButton metroButton26;

		private MetroButton metroButton28;

		private MetroButton metroButton27;

		private MetroButton metroButton30;

		private MetroButton metroButton31;

		private MetroButton metroButton32;

		public fThemHanhDong(string id_KichBan)
		{
			InitializeComponent();
			ChangeLanguage();
			this.id_KichBan = id_KichBan;
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(groupBox2);
			Language.GetValue(btnDocThongBao);
			Language.GetValue(metroButton2);
			Language.GetValue(metroButton3);
			Language.GetValue(groupBox1);
			Language.GetValue(metroButton29);
			Language.GetValue(metroButton34);
			Language.GetValue(metroButton6);
			Language.GetValue(metroButton5);
			Language.GetValue(groupBox4);
			Language.GetValue(metroButton14);
			Language.GetValue(metroButton13);
			Language.GetValue(metroButton18);
			Language.GetValue(metroButton9);
			Language.GetValue(metroButton17);
			Language.GetValue(metroButton38);
			Language.GetValue(metroButton23);
			Language.GetValue(metroButton21);
			Language.GetValue(metroButton22);
			Language.GetValue(groupBox3);
			Language.GetValue(metroButton25);
			Language.GetValue(metroButton35);
			Language.GetValue(groupBox7);
			Language.GetValue(metroButton4);
			Language.GetValue(metroButton43);
			Language.GetValue(metroButton42);
			Language.GetValue(metroButton24);
			Language.GetValue(metroButton8);
			Language.GetValue(metroButton10);
			Language.GetValue(metroButton6);
			Language.GetValue(metroButton19);
			Language.GetValue(metroButton15);
			Language.GetValue(metroButton12);
			Language.GetValue(metroButton11);
			Language.GetValue(metroButton16);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnDocThongBao_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDocThongBao(id_KichBan));
			if (fHDDocThongBao.isSave)
			{
				Close();
			}
		}

		private void metroButton2_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDXemStory(id_KichBan));
			if (fHDXemStory.isSave)
			{
				Close();
			}
		}

		private void metroButton3_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDXemWatch(id_KichBan));
			if (fHDXemWatch.isSave)
			{
				Close();
			}
		}

		private void metroButton12_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDNhanTinBanBe(id_KichBan));
			if (fHDNhanTinBanBe.isSave)
			{
				Close();
			}
		}

		private void metroButton11_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDChocBanBe(id_KichBan));
			if (fHDChocBanBe.isSave)
			{
				Close();
			}
		}

		private void metroButton10_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDChucMungSinhNhat(id_KichBan));
			if (fHDChucMungSinhNhat.isSave)
			{
				Close();
			}
		}

		private void metroButton4_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDPhanHoiTinNhan(id_KichBan));
			if (fHDPhanHoiTinNhan.isSave)
			{
				Close();
			}
		}

		private void metroButton8_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBaiVietNewsfeed(id_KichBan));
			if (fHDBaiVietNewsfeed.isSave)
			{
				Close();
			}
		}

		private void metroButton7_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBaiVietBanBe(id_KichBan));
			if (fHDBaiVietBanBe.isSave)
			{
				Close();
			}
		}

		private void metroButton6_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBaiVietNhom(id_KichBan));
			if (fHDBaiVietNhom.isSave)
			{
				Close();
			}
		}

		private void metroButton5_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBaiVietFanpage(id_KichBan));
			if (fHDBaiVietFanpage.isSave)
			{
				Close();
			}
		}

		private void metroButton14_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanTheoTuKhoa(id_KichBan));
			if (fHDKetBanTheoTuKhoa.isSave)
			{
				Close();
			}
		}

		private void metroButton13_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanGoiY(id_KichBan));
			if (fHDKetBanGoiY.isSave)
			{
				Close();
			}
		}

		private void groupBox5_Enter(object sender, EventArgs e)
		{
		}

		private void metroButton18_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDXacNhanKetBan(id_KichBan));
			if (fHDXacNhanKetBan.isSave)
			{
				Close();
			}
		}

		private void metroButton9_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanTepUid(id_KichBan));
			if (fHDKetBanTepUid.isSave)
			{
				Close();
			}
		}

		private void metroButton16_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanThanhVienNhom(id_KichBan));
			if (fHDKetBanThanhVienNhom.isSave)
			{
				Close();
			}
		}

		private void metroButton15_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDHuyLoiMoiKetBan(id_KichBan));
			if (fHDHuyLoiMoiKetBan.isSave)
			{
				Close();
			}
		}

		private void metroButton17_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDHuyKetBan(id_KichBan));
			if (fHDHuyKetBan.isSave)
			{
				Close();
			}
		}

		private void metroButton23_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDThamGiaNhomUid(id_KichBan));
			if (fHDThamGiaNhomUid.isSave)
			{
				Close();
			}
		}

		private void metroButton23_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDThamGiaNhomTuKhoa(id_KichBan));
			if (fHDThamGiaNhomTuKhoa.isSave)
			{
				Close();
			}
		}

		private void metroButton22_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDRoiNhom(id_KichBan));
			if (fHDRoiNhom.isSave)
			{
				Close();
			}
		}

		private void metroButton20_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDMoiBanBeVaoNhom(id_KichBan));
			if (fHDMoiBanBeVaoNhom.isSave)
			{
				Close();
			}
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

		private void metroButton1_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacNewsfeed(id_KichBan));
			if (fHDTuongTacNewsfeed.isSave)
			{
				Close();
			}
		}

		private void metroButton26_Click(object sender, EventArgs e)
		{
			try
			{
				MCommon.Common.ShowForm(new fHDBuffLikeComment(id_KichBan));
				if (fHDBuffLikeComment.isSave)
				{
					Close();
				}
			}
			catch (Exception ex)
			{
				MCommon.Common.ExportError(ex, "metroButton26_Click");
				MessageBoxHelper.ShowMessageBox(Language.GetValue("Đã có lỗi xảy ra, vui lòng liên hệ Admin!"), 2);
			}
		}

		private void metroButton31_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBuffFollowLikePage(id_KichBan));
			if (fHDBuffFollowLikePage.isSave)
			{
				Close();
			}
		}

		private void metroButton25_Click(object sender, EventArgs e)
		{
		}

		private void metroButton27_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBuffTinNhanProfile(id_KichBan));
			if (fHDBuffTinNhanProfile.isSave)
			{
				Close();
			}
		}

		private void metroButton1_Click_2(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDSeedingByVideo(id_KichBan));
			if (fHDSeedingByVideo.isSave)
			{
				Close();
			}
		}

		private void metroButton32_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTruyCapWebsite(id_KichBan));
			if (fHDTruyCapWebsite.isSave)
			{
				Close();
			}
		}

		private void metroButton32_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTimKiemGoogle(id_KichBan));
			if (fHDTimKiemGoogle.isSave)
			{
				Close();
			}
		}

		private void metroButton34_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacBanBe(id_KichBan));
			if (fHDTuongTacBanBe.isSave)
			{
				Close();
			}
		}

		private void metroButton30_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanTepUidNew(id_KichBan));
			if (fHDKetBanTepUidNew.isSave)
			{
				Close();
			}
		}

		private void metroButton35_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDNghiGiaiLao(id_KichBan));
			if (fHDNghiGiaiLao.isSave)
			{
				Close();
			}
		}

		private void metroButton38_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDThamGiaNhomGoiY(id_KichBan));
			if (fHDThamGiaNhomGoiY.isSave)
			{
				Close();
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if ((e as MouseEventArgs).Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control)
			{
				base.Height = 508;
			}
		}

		private void metroButton40_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanNewfeed(id_KichBan));
			if (fHDKetBanNewfeed.isSave)
			{
				Close();
			}
		}

		private void metroButton41_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanVoiBanCuaBanBe(id_KichBan));
			if (fHDKetBanVoiBanCuaBanBe.isSave)
			{
				Close();
			}
		}

		private void metroButton39_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDKetBanVoiBanBeCuaUid(id_KichBan));
			if (fHDKetBanVoiBanBeCuaUid.isSave)
			{
				Close();
			}
		}

		private void metroButton43_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacNhom(id_KichBan));
			if (fHDTuongTacNhom.isSave)
			{
				Close();
			}
		}

		private void metroButton42_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacPage(id_KichBan));
			if (fHDTuongTacPage.isSave)
			{
				Close();
			}
		}

		private void metroButton4_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDUpAvatar(id_KichBan));
			if (fHDUpAvatar.isSave)
			{
				Close();
			}
		}

		private void metroButton7_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDUpCover(id_KichBan));
			if (fHDUpCover.isSave)
			{
				Close();
			}
		}

		private void metroButton5_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDongBoDanhBa(id_KichBan));
			if (fHDDongBoDanhBa.isSave)
			{
				Close();
			}
		}

		private void metroButton6_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDChiaSeLivestream(id_KichBan));
			if (fHDChiaSeLivestream.isSave)
			{
				Close();
			}
		}

		private void metroButton8_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDangBaiTuong(id_KichBan));
			if (fHDDangBaiTuong.isSave)
			{
				Close();
			}
		}

		private void metroButton10_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDShareBai(id_KichBan));
			if (fHDShareBai.isSave)
			{
				Close();
			}
		}

		private void metroButton11_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacVideo(id_KichBan));
			if (fHDTuongTacVideo.isSave)
			{
				Close();
			}
		}

		private void metroButton12_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacLivestream(id_KichBan));
			if (fHDTuongTacLivestream.isSave)
			{
				Close();
			}
		}

		private void metroButton15_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDanhGiaPage(id_KichBan));
			if (fHDDanhGiaPage.isSave)
			{
				Close();
			}
		}

		private void metroButton16_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacBaiVietChiDinh(id_KichBan));
			if (fHDTuongTacBaiVietChiDinh.isSave)
			{
				Close();
			}
		}

		private void metroButton19_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDSpamBaiViet(id_KichBan));
			if (fHDSpamBaiViet.isSave)
			{
				Close();
			}
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBuffLikePage(id_KichBan));
			if (fHDBuffLikePage.isSave)
			{
				Close();
			}
		}

		private void metroButton20_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDBuffFollowUID(id_KichBan));
			if (fHDBuffFollowUID.isSave)
			{
				Close();
			}
		}

		private void metroButton24_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDangStory(id_KichBan));
			if (fHDDangStory.isSave)
			{
				Close();
			}
		}

		private void metroButton25_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDangBaiNhom(id_KichBan));
			if (fHDDangBaiNhom.isSave)
			{
				Close();
			}
		}

		private void metroButton4_Click_2(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDXemWatchTheoTuKhoa(id_KichBan));
			if (fHDXemWatchTheoTuKhoa.isSave)
			{
				Close();
			}
		}

		private void metroButton7_Click_2(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDShareBaiNangCao(id_KichBan));
			if (fHDShareBaiNangCao.isSave)
			{
				Close();
			}
		}

		private void metroButton26_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDTuongTacBaiVietIA(id_KichBan));
			if (fHDTuongTacBaiVietIA.isSave)
			{
				Close();
			}
		}

		private void metroButton28_Click(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDMoiBanBeVaoNhom(id_KichBan));
			if (fHDMoiBanBeVaoNhom.isSave)
			{
				Close();
			}
		}

		private void metroButton27_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDMoiBanBeLikePage(id_KichBan));
			if (fHDMoiBanBeLikePage.isSave)
			{
				Close();
			}
		}

		private void metroButton30_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDoiMatKhau(id_KichBan));
			if (fHDDoiMatKhau.isSave)
			{
				Close();
			}
		}

		private void metroButton31_Click_1(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDDangXuatThietBiCu(id_KichBan));
			if (fHDDangXuatThietBiCu.isSave)
			{
				Close();
			}
		}

		private void metroButton30_Click_2(object sender, EventArgs e)
		{
			MCommon.Common.ShowForm(new fHDOnOff2FA(id_KichBan));
			if (fHDOnOff2FA.isSave)
			{
				Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fThemHanhDong));
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			pnlHeader = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			groupBox2 = new System.Windows.Forms.GroupBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			metroButton43 = new MetroFramework.Controls.MetroButton();
			metroButton4 = new MetroFramework.Controls.MetroButton();
			metroButton3 = new MetroFramework.Controls.MetroButton();
			metroButton42 = new MetroFramework.Controls.MetroButton();
			metroButton29 = new MetroFramework.Controls.MetroButton();
			metroButton34 = new MetroFramework.Controls.MetroButton();
			metroButton2 = new MetroFramework.Controls.MetroButton();
			btnDocThongBao = new MetroFramework.Controls.MetroButton();
			metroButton24 = new MetroFramework.Controls.MetroButton();
			metroButton8 = new MetroFramework.Controls.MetroButton();
			groupBox1 = new System.Windows.Forms.GroupBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			metroButton14 = new MetroFramework.Controls.MetroButton();
			metroButton22 = new MetroFramework.Controls.MetroButton();
			metroButton18 = new MetroFramework.Controls.MetroButton();
			metroButton21 = new MetroFramework.Controls.MetroButton();
			metroButton9 = new MetroFramework.Controls.MetroButton();
			metroButton23 = new MetroFramework.Controls.MetroButton();
			metroButton38 = new MetroFramework.Controls.MetroButton();
			metroButton13 = new MetroFramework.Controls.MetroButton();
			metroButton41 = new MetroFramework.Controls.MetroButton();
			metroButton17 = new MetroFramework.Controls.MetroButton();
			metroButton40 = new MetroFramework.Controls.MetroButton();
			metroButton39 = new MetroFramework.Controls.MetroButton();
			metroButton12 = new MetroFramework.Controls.MetroButton();
			metroButton16 = new MetroFramework.Controls.MetroButton();
			metroButton11 = new MetroFramework.Controls.MetroButton();
			groupBox4 = new System.Windows.Forms.GroupBox();
			pictureBox5 = new System.Windows.Forms.PictureBox();
			metroButton7 = new MetroFramework.Controls.MetroButton();
			metroButton10 = new MetroFramework.Controls.MetroButton();
			metroButton6 = new MetroFramework.Controls.MetroButton();
			metroButton25 = new MetroFramework.Controls.MetroButton();
			panel1 = new System.Windows.Forms.Panel();
			groupBox7 = new System.Windows.Forms.GroupBox();
			pictureBox8 = new System.Windows.Forms.PictureBox();
			metroButton31 = new MetroFramework.Controls.MetroButton();
			metroButton30 = new MetroFramework.Controls.MetroButton();
			metroButton26 = new MetroFramework.Controls.MetroButton();
			metroButton35 = new MetroFramework.Controls.MetroButton();
			metroButton5 = new MetroFramework.Controls.MetroButton();
			groupBox3 = new System.Windows.Forms.GroupBox();
			pictureBox6 = new System.Windows.Forms.PictureBox();
			metroButton20 = new MetroFramework.Controls.MetroButton();
			metroButton28 = new MetroFramework.Controls.MetroButton();
			metroButton27 = new MetroFramework.Controls.MetroButton();
			metroButton1 = new MetroFramework.Controls.MetroButton();
			metroButton15 = new MetroFramework.Controls.MetroButton();
			metroButton19 = new MetroFramework.Controls.MetroButton();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			metroButton32 = new MetroFramework.Controls.MetroButton();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			bunifuCards1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			panel1.SuspendLayout();
			groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
			SuspendLayout();
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
			bunifuCustomLabel1.Size = new System.Drawing.Size(1037, 31);
			bunifuCustomLabel1.TabIndex = 12;
			bunifuCustomLabel1.Text = "Danh sách hành động";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = pnlHeader;
			bunifuDragControl2.Vertical = true;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(button1);
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 3);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1037, 31);
			pnlHeader.TabIndex = 9;
			button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(1005, 1);
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
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
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
			bunifuCards1.Size = new System.Drawing.Size(1037, 37);
			bunifuCards1.TabIndex = 12;
			groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox2.Controls.Add(pictureBox2);
			groupBox2.Controls.Add(metroButton43);
			groupBox2.Controls.Add(metroButton4);
			groupBox2.Controls.Add(metroButton3);
			groupBox2.Controls.Add(metroButton42);
			groupBox2.Controls.Add(metroButton29);
			groupBox2.Controls.Add(metroButton34);
			groupBox2.Controls.Add(metroButton2);
			groupBox2.Controls.Add(btnDocThongBao);
			groupBox2.Location = new System.Drawing.Point(9, 43);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(200, 404);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "Tương tác";
			pictureBox2.Image = maxcare.Properties.Resources._49808659_232534617678897_2552302324445872128_n;
			pictureBox2.Location = new System.Drawing.Point(14, 34);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(171, 83);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			metroButton43.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton43.Location = new System.Drawing.Point(14, 310);
			metroButton43.Name = "metroButton43";
			metroButton43.Size = new System.Drawing.Size(171, 23);
			metroButton43.TabIndex = 0;
			metroButton43.Text = "Tương tác Nhóm";
			metroButton43.UseSelectable = true;
			metroButton43.Click += new System.EventHandler(metroButton43_Click);
			metroButton4.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton4.Location = new System.Drawing.Point(14, 223);
			metroButton4.Name = "metroButton4";
			metroButton4.Size = new System.Drawing.Size(171, 23);
			metroButton4.TabIndex = 2;
			metroButton4.Text = "Xem Watch theo tư\u0300 kho\u0301a";
			metroButton4.UseSelectable = true;
			metroButton4.Click += new System.EventHandler(metroButton4_Click_2);
			metroButton3.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton3.Location = new System.Drawing.Point(14, 194);
			metroButton3.Name = "metroButton3";
			metroButton3.Size = new System.Drawing.Size(171, 23);
			metroButton3.TabIndex = 2;
			metroButton3.Text = "Xem Watch";
			metroButton3.UseSelectable = true;
			metroButton3.Click += new System.EventHandler(metroButton3_Click);
			metroButton42.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton42.Location = new System.Drawing.Point(14, 339);
			metroButton42.Name = "metroButton42";
			metroButton42.Size = new System.Drawing.Size(171, 23);
			metroButton42.TabIndex = 1;
			metroButton42.Text = "Tương ta\u0301c Page";
			metroButton42.UseSelectable = true;
			metroButton42.Click += new System.EventHandler(metroButton42_Click);
			metroButton29.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton29.Location = new System.Drawing.Point(14, 252);
			metroButton29.Name = "metroButton29";
			metroButton29.Size = new System.Drawing.Size(171, 23);
			metroButton29.TabIndex = 0;
			metroButton29.Text = "Tương tác Newsfeed";
			metroButton29.UseSelectable = true;
			metroButton29.Click += new System.EventHandler(metroButton1_Click_1);
			metroButton34.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton34.Location = new System.Drawing.Point(14, 281);
			metroButton34.Name = "metroButton34";
			metroButton34.Size = new System.Drawing.Size(171, 23);
			metroButton34.TabIndex = 1;
			metroButton34.Text = "Tương ta\u0301c Bạn bè";
			metroButton34.UseSelectable = true;
			metroButton34.Click += new System.EventHandler(metroButton34_Click);
			metroButton2.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton2.Location = new System.Drawing.Point(14, 165);
			metroButton2.Name = "metroButton2";
			metroButton2.Size = new System.Drawing.Size(171, 23);
			metroButton2.TabIndex = 1;
			metroButton2.Text = "Xem Story";
			metroButton2.UseSelectable = true;
			metroButton2.Click += new System.EventHandler(metroButton2_Click);
			btnDocThongBao.BackColor = System.Drawing.SystemColors.Control;
			btnDocThongBao.Cursor = System.Windows.Forms.Cursors.Hand;
			btnDocThongBao.ForeColor = System.Drawing.Color.Black;
			btnDocThongBao.Location = new System.Drawing.Point(14, 136);
			btnDocThongBao.Name = "btnDocThongBao";
			btnDocThongBao.Size = new System.Drawing.Size(171, 23);
			btnDocThongBao.TabIndex = 0;
			btnDocThongBao.Text = "Đọc thông báo";
			btnDocThongBao.UseSelectable = true;
			btnDocThongBao.Click += new System.EventHandler(btnDocThongBao_Click);
			metroButton24.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton24.Location = new System.Drawing.Point(14, 136);
			metroButton24.Name = "metroButton24";
			metroButton24.Size = new System.Drawing.Size(171, 23);
			metroButton24.TabIndex = 1;
			metroButton24.Text = "Đăng Story";
			metroButton24.UseSelectable = true;
			metroButton24.Click += new System.EventHandler(metroButton24_Click);
			metroButton8.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton8.Location = new System.Drawing.Point(14, 165);
			metroButton8.Name = "metroButton8";
			metroButton8.Size = new System.Drawing.Size(171, 23);
			metroButton8.TabIndex = 2;
			metroButton8.Text = "Đăng ba\u0300i lên tươ\u0300ng";
			metroButton8.UseSelectable = true;
			metroButton8.Click += new System.EventHandler(metroButton8_Click_1);
			groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox1.Controls.Add(pictureBox3);
			groupBox1.Controls.Add(metroButton14);
			groupBox1.Controls.Add(metroButton22);
			groupBox1.Controls.Add(metroButton18);
			groupBox1.Controls.Add(metroButton21);
			groupBox1.Controls.Add(metroButton9);
			groupBox1.Controls.Add(metroButton23);
			groupBox1.Controls.Add(metroButton38);
			groupBox1.Controls.Add(metroButton13);
			groupBox1.Controls.Add(metroButton41);
			groupBox1.Controls.Add(metroButton17);
			groupBox1.Controls.Add(metroButton40);
			groupBox1.Controls.Add(metroButton39);
			groupBox1.Location = new System.Drawing.Point(215, 43);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(200, 404);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Kê\u0301t ba\u0323n - Tham gia nho\u0301m";
			pictureBox3.Image = maxcare.Properties.Resources._116692455_670988066823486_3905997291042984785_n;
			pictureBox3.Location = new System.Drawing.Point(14, 34);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(171, 83);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox3.TabIndex = 1;
			pictureBox3.TabStop = false;
			metroButton14.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton14.Location = new System.Drawing.Point(14, 136);
			metroButton14.Name = "metroButton14";
			metroButton14.Size = new System.Drawing.Size(171, 23);
			metroButton14.TabIndex = 0;
			metroButton14.Text = "Kết bạn theo từ khóa";
			metroButton14.UseSelectable = true;
			metroButton14.Click += new System.EventHandler(metroButton14_Click);
			metroButton22.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton22.Location = new System.Drawing.Point(14, 339);
			metroButton22.Name = "metroButton22";
			metroButton22.Size = new System.Drawing.Size(171, 23);
			metroButton22.TabIndex = 2;
			metroButton22.Text = "Rời nhóm";
			metroButton22.UseSelectable = true;
			metroButton22.Click += new System.EventHandler(metroButton22_Click);
			metroButton18.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton18.Location = new System.Drawing.Point(14, 194);
			metroButton18.Name = "metroButton18";
			metroButton18.Size = new System.Drawing.Size(171, 23);
			metroButton18.TabIndex = 2;
			metroButton18.Text = "Xác nhận kết bạn";
			metroButton18.UseSelectable = true;
			metroButton18.Click += new System.EventHandler(metroButton18_Click);
			metroButton21.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton21.Location = new System.Drawing.Point(14, 310);
			metroButton21.Name = "metroButton21";
			metroButton21.Size = new System.Drawing.Size(171, 23);
			metroButton21.TabIndex = 1;
			metroButton21.Text = "Tham gia nhóm theo tệp UID";
			metroButton21.UseSelectable = true;
			metroButton21.Click += new System.EventHandler(metroButton23_Click);
			metroButton9.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton9.Location = new System.Drawing.Point(14, 223);
			metroButton9.Name = "metroButton9";
			metroButton9.Size = new System.Drawing.Size(171, 23);
			metroButton9.TabIndex = 4;
			metroButton9.Text = "Kết bạn theo tệp UID";
			metroButton9.UseSelectable = true;
			metroButton9.Click += new System.EventHandler(metroButton9_Click);
			metroButton23.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton23.Location = new System.Drawing.Point(14, 281);
			metroButton23.Name = "metroButton23";
			metroButton23.Size = new System.Drawing.Size(171, 23);
			metroButton23.TabIndex = 0;
			metroButton23.Text = "Tham gia nhóm theo từ khóa";
			metroButton23.UseSelectable = true;
			metroButton23.Click += new System.EventHandler(metroButton23_Click_1);
			metroButton38.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton38.Enabled = false;
			metroButton38.Location = new System.Drawing.Point(14, 339);
			metroButton38.Name = "metroButton38";
			metroButton38.Size = new System.Drawing.Size(171, 23);
			metroButton38.TabIndex = 3;
			metroButton38.Text = "Tham gia nhóm theo gợi ý (ẩn)";
			metroButton38.UseSelectable = true;
			metroButton38.Visible = false;
			metroButton38.Click += new System.EventHandler(metroButton38_Click);
			metroButton13.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton13.Location = new System.Drawing.Point(14, 165);
			metroButton13.Name = "metroButton13";
			metroButton13.Size = new System.Drawing.Size(171, 23);
			metroButton13.TabIndex = 1;
			metroButton13.Text = "Kết bạn theo gợi ý";
			metroButton13.UseSelectable = true;
			metroButton13.Click += new System.EventHandler(metroButton13_Click);
			metroButton41.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton41.Enabled = false;
			metroButton41.Location = new System.Drawing.Point(14, 223);
			metroButton41.Name = "metroButton41";
			metroButton41.Size = new System.Drawing.Size(171, 23);
			metroButton41.TabIndex = 6;
			metroButton41.Text = "Kết bạn với bạn của bạn bè (ẩn)";
			metroButton41.UseSelectable = true;
			metroButton41.Visible = false;
			metroButton41.Click += new System.EventHandler(metroButton41_Click);
			metroButton17.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton17.Location = new System.Drawing.Point(14, 252);
			metroButton17.Name = "metroButton17";
			metroButton17.Size = new System.Drawing.Size(171, 23);
			metroButton17.TabIndex = 6;
			metroButton17.Text = "Hủy kết bạn";
			metroButton17.UseSelectable = true;
			metroButton17.Click += new System.EventHandler(metroButton17_Click);
			metroButton40.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton40.Enabled = false;
			metroButton40.Location = new System.Drawing.Point(14, 194);
			metroButton40.Name = "metroButton40";
			metroButton40.Size = new System.Drawing.Size(171, 23);
			metroButton40.TabIndex = 6;
			metroButton40.Text = "Kết bạn Newfeed (ẩn)";
			metroButton40.UseSelectable = true;
			metroButton40.Visible = false;
			metroButton40.Click += new System.EventHandler(metroButton40_Click);
			metroButton39.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton39.Enabled = false;
			metroButton39.Location = new System.Drawing.Point(14, 252);
			metroButton39.Name = "metroButton39";
			metroButton39.Size = new System.Drawing.Size(171, 23);
			metroButton39.TabIndex = 6;
			metroButton39.Text = "Kết bạn với bạn bè của Uid (ẩn)";
			metroButton39.UseSelectable = true;
			metroButton39.Visible = false;
			metroButton39.Click += new System.EventHandler(metroButton39_Click);
			metroButton12.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton12.Location = new System.Drawing.Point(14, 252);
			metroButton12.Name = "metroButton12";
			metroButton12.Size = new System.Drawing.Size(171, 23);
			metroButton12.TabIndex = 6;
			metroButton12.Text = "Tương ta\u0301c Livestream";
			metroButton12.UseSelectable = true;
			metroButton12.Click += new System.EventHandler(metroButton12_Click_1);
			metroButton16.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton16.Location = new System.Drawing.Point(14, 310);
			metroButton16.Name = "metroButton16";
			metroButton16.Size = new System.Drawing.Size(171, 23);
			metroButton16.TabIndex = 1;
			metroButton16.Text = "Tương ta\u0301c Ba\u0300i viê\u0301t chi\u0309 đi\u0323nh";
			metroButton16.UseSelectable = true;
			metroButton16.Click += new System.EventHandler(metroButton16_Click_1);
			metroButton11.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton11.Location = new System.Drawing.Point(14, 281);
			metroButton11.Name = "metroButton11";
			metroButton11.Size = new System.Drawing.Size(171, 23);
			metroButton11.TabIndex = 6;
			metroButton11.Text = "Tương ta\u0301c Video chi\u0309 đi\u0323nh";
			metroButton11.UseSelectable = true;
			metroButton11.Click += new System.EventHandler(metroButton11_Click_1);
			groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox4.Controls.Add(pictureBox5);
			groupBox4.Controls.Add(metroButton7);
			groupBox4.Controls.Add(metroButton10);
			groupBox4.Controls.Add(metroButton24);
			groupBox4.Controls.Add(metroButton6);
			groupBox4.Controls.Add(metroButton25);
			groupBox4.Controls.Add(metroButton8);
			groupBox4.Location = new System.Drawing.Point(421, 43);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(200, 404);
			groupBox4.TabIndex = 3;
			groupBox4.TabStop = false;
			groupBox4.Text = "Đăng ba\u0300i - Share ba\u0300i";
			pictureBox5.Image = maxcare.Properties.Resources.cac_group_ban_hang_tren_facebook_hieu_qua1;
			pictureBox5.Location = new System.Drawing.Point(14, 34);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new System.Drawing.Size(171, 83);
			pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox5.TabIndex = 1;
			pictureBox5.TabStop = false;
			metroButton7.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton7.Location = new System.Drawing.Point(14, 281);
			metroButton7.Name = "metroButton7";
			metroButton7.Size = new System.Drawing.Size(171, 23);
			metroButton7.TabIndex = 6;
			metroButton7.Text = "Chia sẻ Nâng cao";
			metroButton7.UseSelectable = true;
			metroButton7.Click += new System.EventHandler(metroButton7_Click_2);
			metroButton10.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton10.Location = new System.Drawing.Point(14, 223);
			metroButton10.Name = "metroButton10";
			metroButton10.Size = new System.Drawing.Size(171, 23);
			metroButton10.TabIndex = 6;
			metroButton10.Text = "Chia sẻ Bài viết/Video";
			metroButton10.UseSelectable = true;
			metroButton10.Click += new System.EventHandler(metroButton10_Click_1);
			metroButton6.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton6.Location = new System.Drawing.Point(14, 252);
			metroButton6.Name = "metroButton6";
			metroButton6.Size = new System.Drawing.Size(171, 23);
			metroButton6.TabIndex = 5;
			metroButton6.Text = "Chia sẻ Livestream";
			metroButton6.UseSelectable = true;
			metroButton6.Click += new System.EventHandler(metroButton6_Click_1);
			metroButton25.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton25.Location = new System.Drawing.Point(14, 194);
			metroButton25.Name = "metroButton25";
			metroButton25.Size = new System.Drawing.Size(171, 23);
			metroButton25.TabIndex = 2;
			metroButton25.Text = "Đăng ba\u0300i lên nho\u0301m";
			metroButton25.UseSelectable = true;
			metroButton25.Click += new System.EventHandler(metroButton25_Click_1);
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel1.Controls.Add(groupBox7);
			panel1.Controls.Add(groupBox3);
			panel1.Controls.Add(bunifuCards1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1040, 456);
			panel1.TabIndex = 25;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			groupBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox7.Controls.Add(pictureBox8);
			groupBox7.Controls.Add(metroButton31);
			groupBox7.Controls.Add(metroButton32);
			groupBox7.Controls.Add(metroButton30);
			groupBox7.Controls.Add(metroButton26);
			groupBox7.Controls.Add(metroButton35);
			groupBox7.Controls.Add(metroButton5);
			groupBox7.Location = new System.Drawing.Point(832, 43);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new System.Drawing.Size(200, 403);
			groupBox7.TabIndex = 4;
			groupBox7.TabStop = false;
			groupBox7.Text = "Chư\u0301c năng kha\u0301c";
			groupBox7.Enter += new System.EventHandler(groupBox5_Enter);
			pictureBox8.Image = maxcare.Properties.Resources._2_B_Facebook;
			pictureBox8.Location = new System.Drawing.Point(14, 34);
			pictureBox8.Name = "pictureBox8";
			pictureBox8.Size = new System.Drawing.Size(171, 83);
			pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox8.TabIndex = 1;
			pictureBox8.TabStop = false;
			metroButton31.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton31.Location = new System.Drawing.Point(14, 222);
			metroButton31.Name = "metroButton31";
			metroButton31.Size = new System.Drawing.Size(171, 23);
			metroButton31.TabIndex = 1;
			metroButton31.Text = "Đăng xuâ\u0301t thiê\u0301t bi\u0323 cu\u0303";
			metroButton31.UseSelectable = true;
			metroButton31.Click += new System.EventHandler(metroButton31_Click_1);
			metroButton30.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton30.Location = new System.Drawing.Point(14, 164);
			metroButton30.Name = "metroButton30";
			metroButton30.Size = new System.Drawing.Size(171, 23);
			metroButton30.TabIndex = 1;
			metroButton30.Text = "Bật - Tắt 2FA";
			metroButton30.UseSelectable = true;
			metroButton30.Click += new System.EventHandler(metroButton30_Click_2);
			metroButton26.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton26.Location = new System.Drawing.Point(14, 251);
			metroButton26.Name = "metroButton26";
			metroButton26.Size = new System.Drawing.Size(171, 23);
			metroButton26.TabIndex = 0;
			metroButton26.Text = "Tương tác ba\u0300i viê\u0301t IA";
			metroButton26.UseSelectable = true;
			metroButton26.Click += new System.EventHandler(metroButton26_Click_1);
			metroButton35.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton35.Location = new System.Drawing.Point(14, 280);
			metroButton35.Name = "metroButton35";
			metroButton35.Size = new System.Drawing.Size(171, 23);
			metroButton35.TabIndex = 0;
			metroButton35.Text = "Nghỉ giải lao";
			metroButton35.UseSelectable = true;
			metroButton35.Click += new System.EventHandler(metroButton35_Click);
			metroButton5.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton5.Location = new System.Drawing.Point(14, 135);
			metroButton5.Name = "metroButton5";
			metroButton5.Size = new System.Drawing.Size(171, 23);
			metroButton5.TabIndex = 4;
			metroButton5.Text = "Đồng bộ danh bạ";
			metroButton5.UseSelectable = true;
			metroButton5.Click += new System.EventHandler(metroButton5_Click_1);
			groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			groupBox3.Controls.Add(pictureBox6);
			groupBox3.Controls.Add(metroButton16);
			groupBox3.Controls.Add(metroButton20);
			groupBox3.Controls.Add(metroButton28);
			groupBox3.Controls.Add(metroButton12);
			groupBox3.Controls.Add(metroButton27);
			groupBox3.Controls.Add(metroButton1);
			groupBox3.Controls.Add(metroButton15);
			groupBox3.Controls.Add(metroButton19);
			groupBox3.Controls.Add(metroButton11);
			groupBox3.Location = new System.Drawing.Point(626, 42);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(200, 404);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "Spam - Seeding";
			groupBox3.Enter += new System.EventHandler(groupBox5_Enter);
			pictureBox6.Image = maxcare.Properties.Resources.seeding_facebook_define_1200x545_c;
			pictureBox6.Location = new System.Drawing.Point(14, 34);
			pictureBox6.Name = "pictureBox6";
			pictureBox6.Size = new System.Drawing.Size(171, 83);
			pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox6.TabIndex = 1;
			pictureBox6.TabStop = false;
			metroButton20.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton20.Location = new System.Drawing.Point(14, 223);
			metroButton20.Name = "metroButton20";
			metroButton20.Size = new System.Drawing.Size(171, 23);
			metroButton20.TabIndex = 6;
			metroButton20.Text = "Buff Follow UID";
			metroButton20.UseSelectable = true;
			metroButton20.Click += new System.EventHandler(metroButton20_Click_1);
			metroButton28.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton28.Location = new System.Drawing.Point(14, 368);
			metroButton28.Name = "metroButton28";
			metroButton28.Size = new System.Drawing.Size(171, 23);
			metroButton28.TabIndex = 1;
			metroButton28.Text = "Mơ\u0300i ba\u0323n be\u0300 va\u0300o nho\u0301m";
			metroButton28.UseSelectable = true;
			metroButton28.Click += new System.EventHandler(metroButton28_Click);
			metroButton27.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton27.Location = new System.Drawing.Point(14, 339);
			metroButton27.Name = "metroButton27";
			metroButton27.Size = new System.Drawing.Size(171, 23);
			metroButton27.TabIndex = 1;
			metroButton27.Text = "Mơ\u0300i ba\u0323n be\u0300 like page";
			metroButton27.UseSelectable = true;
			metroButton27.Click += new System.EventHandler(metroButton27_Click_1);
			metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton1.Location = new System.Drawing.Point(14, 194);
			metroButton1.Name = "metroButton1";
			metroButton1.Size = new System.Drawing.Size(171, 23);
			metroButton1.TabIndex = 6;
			metroButton1.Text = "Buff Like Page";
			metroButton1.UseSelectable = true;
			metroButton1.Click += new System.EventHandler(metroButton1_Click);
			metroButton15.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton15.Location = new System.Drawing.Point(14, 165);
			metroButton15.Name = "metroButton15";
			metroButton15.Size = new System.Drawing.Size(171, 23);
			metroButton15.TabIndex = 6;
			metroButton15.Text = "Đánh giá Page";
			metroButton15.UseSelectable = true;
			metroButton15.Click += new System.EventHandler(metroButton15_Click_1);
			metroButton19.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton19.Location = new System.Drawing.Point(14, 136);
			metroButton19.Name = "metroButton19";
			metroButton19.Size = new System.Drawing.Size(171, 23);
			metroButton19.TabIndex = 1;
			metroButton19.Text = "Spam ba\u0300i viê\u0301t";
			metroButton19.UseSelectable = true;
			metroButton19.Click += new System.EventHandler(metroButton19_Click);
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 0;
			toolTip1.InitialDelay = 500;
			toolTip1.ReshowDelay = 0;
			metroButton32.Cursor = System.Windows.Forms.Cursors.Hand;
			metroButton32.Location = new System.Drawing.Point(14, 193);
			metroButton32.Name = "metroButton32";
			metroButton32.Size = new System.Drawing.Size(171, 23);
			metroButton32.TabIndex = 1;
			metroButton32.Text = "Đô\u0309i mâ\u0323t khâ\u0309u";
			metroButton32.UseSelectable = true;
			metroButton32.Click += new System.EventHandler(metroButton30_Click_1);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1040, 456);
			base.Controls.Add(groupBox4);
			base.Controls.Add(groupBox1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(panel1);
			Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "fThemHanhDong";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			bunifuCards1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			panel1.ResumeLayout(false);
			groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
			ResumeLayout(false);
		}
	}
}
