using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using maxcare.Helper;
using MCommon;

namespace maxcare
{
	public class fConfigInteract : Form
	{
		private JSON_Settings settings;

		private IContainer components = null;

		private BunifuCards bunifuCards1;

		private Panel pnlHeader;

		private BunifuCustomLabel bunifuCustomLabel1;

		private Button btnMinimize;

		private Button btnCancel;

		private Button btnAdd;

		private GroupBox groupBox5;

		private Panel plTuongTacCMSN;

		private RadioButton rbTuongTacCMSNDangBai;

		private RadioButton rbTuongTacCMSNNhanTin;

		private Label label11;

		private NumericUpDown nudTuongTacCMSNSoLuongFrom;

		private Button button2;

		private Label label28;

		private Label label35;

		private NumericUpDown nudTuongTacCMSNDelayFrom;

		private Label label10;

		private Label label37;

		private NumericUpDown nudTuongTacCMSNDelayTo;

		private Label label45;

		private Panel plTuongTacNhanTin;

		private Button btnInbox;

		private Label label41;

		private NumericUpDown nudTuongTacNhanTinSoLuongFrom;

		private Label label42;

		private NumericUpDown nudTuongTacNhanTinDelayFrom;

		private Label label43;

		private NumericUpDown nudTuongTacNhanTinDelayTo;

		private Label label44;

		private Panel plTuongTacChoc;

		private Label label36;

		private NumericUpDown nudTuongTacChocSoLuongFrom;

		private Label label38;

		private NumericUpDown nudTuongTacChocSoLuongDelayFrom;

		private Label label39;

		private NumericUpDown nudTuongTacChocSoLuongDelayTo;

		private Label label40;

		private CheckBox ckbTuongTacNhanTin;

		private CheckBox ckbTuongTacChoc;

		private CheckBox ckbTuongTacCMSN;

		private GroupBox groupBox4;

		private Panel plTuongTacFanpage;

		private Label label56;

		private NumericUpDown nudTuongTacFanpageSoLuongPageFrom;

		private Label label58;

		private NumericUpDown nudTuongTacFanpageSoLuongBaiVietFrom;

		private CheckBox ckbTuongTacFanpageComment;

		private Button button7;

		private Button btnTuongTacFanpageComment;

		private CheckBox ckbTuongTacFanpageLike;

		private Label label59;

		private Label label60;

		private NumericUpDown nudTuongTacFanpageDelayFrom;

		private Label label61;

		private NumericUpDown nudTuongTacFanpageDelayTo;

		private Label label62;

		private Panel plTuongTacGroup;

		private Label label7;

		private NumericUpDown nudTuongTacGroupSoLuongNhomFrom;

		private Label label18;

		private NumericUpDown nudTuongTacGroupSoLuongBaiVietFrom;

		private CheckBox ckbTuongTacGroupComment;

		private Button btnTuongTacGroupComment;

		private CheckBox ckbTuongTacGroupLike;

		private Label label50;

		private Label label51;

		private NumericUpDown nudTuongTacGroupDelayFrom;

		private Label label52;

		private NumericUpDown nudTuongTacGroupDelayTo;

		private Label label53;

		private Panel plTuongTacFriend;

		private Label label49;

		private NumericUpDown nudTuongTacFriendSoLuongBanBeFrom;

		private Label label54;

		private Label label19;

		private NumericUpDown nudTuongTacFriendSoLuongBaiVietFrom;

		private CheckBox ckbTuongTacFriendComment;

		private Button btnTuongTacFriendComment;

		private CheckBox ckbTuongTacFriendLike;

		private Label label33;

		private Label label46;

		private NumericUpDown nudTuongTacFriendDelayFrom;

		private Label label47;

		private NumericUpDown nudTuongTacFriendDelayTo;

		private Label label48;

		private Panel plTuongTacNewsfeed;

		private Label label1;

		private NumericUpDown nudTuongTacNewsfeedSoLuongFrom;

		private CheckBox ckbTuongTacNewsfeedComment;

		private Button btnTuongTacNewsfeedComment;

		private CheckBox ckbTuongTacNewsfeedLike;

		private Label label8;

		private Label label24;

		private NumericUpDown nudTuongTacNewsfeedDelayFrom;

		private Label label29;

		private NumericUpDown nudTuongTacNewsfeedDelayTo;

		private Label label25;

		private CheckBox ckbTuongTacFanpage;

		private CheckBox ckbTuongTacGroup;

		private CheckBox ckbTuongTacNewsfeed;

		private CheckBox ckbTuongTacFriend;

		private GroupBox groupBox8;

		private CheckBox ckbKetBanGoiY;

		private CheckBox ckbXacNhanKetBan;

		private CheckBox ckbKetBanTepUid;

		private Button button8;

		private GroupBox groupBox7;

		private CheckBox ckbThamGiaNhom;

		private ToolTip toolTip1;

		private CheckBox ckbKetBanTuKhoa;

		private Panel plKetBanTepUid;

		private Label label17;

		private Label label20;

		private NumericUpDown nudKetBanTepUidSoLuongFrom;

		private Label label21;

		private NumericUpDown nudKetBanTepUidDelayFrom;

		private Label label22;

		private NumericUpDown nudKetBanTepUidDelayTo;

		private Label label23;

		private Panel plKetBanTuKhoa;

		private TextBox txtKetBanTuKhoaTuKhoa;

		private Label label16;

		private Label label3;

		private NumericUpDown nudKetBanTuKhoaSoLuongFrom;

		private Label label9;

		private NumericUpDown nudKetBanTuKhoaDelayFrom;

		private Label label14;

		private NumericUpDown nudKetBanTuKhoaDelayTo;

		private Label label15;

		private Panel plXacNhanKetBan;

		private Label label26;

		private NumericUpDown nudXacNhanKetBanSoLuongFrom;

		private Label label27;

		private NumericUpDown nudXacNhanKetBanDelayFrom;

		private Label label30;

		private NumericUpDown nudXacNhanKetBanDelayTo;

		private Label label31;

		private Panel plKetBanGoiY;

		private Label label2;

		private NumericUpDown nudKetBanGoiYSoLuongFrom;

		private Label label4;

		private NumericUpDown nudKetBanGoiYDelayFrom;

		private Label label5;

		private NumericUpDown nudKetBanGoiYDelayTo;

		private Label label6;

		private Panel plThamGiaNhom;

		private CheckBox ckbThamGiaNhomTraLoiCauHoi;

		private Label label12;

		private Label label13;

		private NumericUpDown nudThamGiaNhomSoLuongFrom;

		private Label label32;

		private NumericUpDown nudThamGiaNhomDelayFrom;

		private Label label34;

		private NumericUpDown nudThamGiaNhomDelayTo;

		private Button btnThamGiaNhomTraLoiCauHoi;

		private Button button1;

		private Label label63;

		private BunifuDragControl bunifuDragControl1;

		private BunifuDragControl bunifuDragControl2;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private CheckBox ckbKetBanTepUidTrungNhau;

		private CheckBox ckbThamGiaNhomTrungNhau;

		private Label label80;

		private NumericUpDown nudTuongTacCMSNSoLuongTo;

		private Label label79;

		private Label label84;

		private NumericUpDown nudTuongTacNhanTinSoLuongTo;

		private Label label83;

		private Label label82;

		private NumericUpDown nudTuongTacChocSoLuongTo;

		private Label label81;

		private Label label87;

		private Label label85;

		private NumericUpDown nudTuongTacFanpageSoLuongPageTo;

		private NumericUpDown nudTuongTacFanpageSoLuongBaiVietTo;

		private Label label86;

		private Label label57;

		private Label label89;

		private Label label90;

		private NumericUpDown nudTuongTacGroupSoLuongBaiVietTo;

		private Label label55;

		private NumericUpDown nudTuongTacGroupSoLuongNhomTo;

		private Label label88;

		private Label label68;

		private NumericUpDown nudTuongTacFriendSoLuongBaiVietTo;

		private NumericUpDown nudTuongTacFriendSoLuongBanBeTo;

		private Label label67;

		private Label label66;

		private Label label65;

		private NumericUpDown nudTuongTacNewsfeedSoLuongTo;

		private Label label64;

		private Label label74;

		private NumericUpDown nudKetBanTepUidSoLuongTo;

		private Label label73;

		private Label label70;

		private NumericUpDown nudKetBanTuKhoaSoLuongTo;

		private Label label69;

		private Label label76;

		private NumericUpDown nudXacNhanKetBanSoLuongTo;

		private Label label75;

		private Label label72;

		private NumericUpDown nudKetBanGoiYSoLuongTo;

		private Label label71;

		private Label label78;

		private NumericUpDown nudThamGiaNhomSoLuongTo;

		private Label label77;

		private Label label92;

		private Label label91;

		public fConfigInteract()
		{
			InitializeComponent();
			settings = new JSON_Settings("configInteract");
			ChangeLanguage();
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ChangeLanguage()
		{
			Language.GetValue(bunifuCustomLabel1);
			Language.GetValue(groupBox4);
			Language.GetValue(ckbTuongTacNewsfeed);
			Language.GetValue(label1);
			Language.GetValue(label64);
			Language.GetValue(label65);
			Language.GetValue(label24);
			Language.GetValue(label25);
			Language.GetValue(label29);
			Language.GetValue(label8);
			Language.GetValue(btnTuongTacNewsfeedComment);
			Language.GetValue(ckbTuongTacFriend);
			Language.GetValue(label49);
			Language.GetValue(label66);
			Language.GetValue(label68);
			Language.GetValue(label19);
			Language.GetValue(label67);
			Language.GetValue(label54);
			Language.GetValue(label46);
			Language.GetValue(label48);
			Language.GetValue(label47);
			Language.GetValue(label33);
			Language.GetValue(btnTuongTacFriendComment);
			Language.GetValue(ckbTuongTacFanpage);
			Language.GetValue(label91);
			Language.GetValue(button7);
			Language.GetValue(label56);
			Language.GetValue(label86);
			Language.GetValue(label87);
			Language.GetValue(label58);
			Language.GetValue(label57);
			Language.GetValue(label85);
			Language.GetValue(label60);
			Language.GetValue(label62);
			Language.GetValue(label61);
			Language.GetValue(label59);
			Language.GetValue(btnTuongTacFanpageComment);
			Language.GetValue(ckbTuongTacGroup);
			Language.GetValue(label7);
			Language.GetValue(label88);
			Language.GetValue(label89);
			Language.GetValue(label18);
			Language.GetValue(label55);
			Language.GetValue(label90);
			Language.GetValue(label51);
			Language.GetValue(label53);
			Language.GetValue(label52);
			Language.GetValue(label50);
			Language.GetValue(btnTuongTacGroupComment);
			Language.GetValue(groupBox5);
			Language.GetValue(ckbTuongTacNhanTin);
			Language.GetValue(label92);
			Language.GetValue(btnInbox);
			Language.GetValue(label41);
			Language.GetValue(label83);
			Language.GetValue(label84);
			Language.GetValue(label42);
			Language.GetValue(label44);
			Language.GetValue(label43);
			Language.GetValue(ckbTuongTacChoc);
			Language.GetValue(label36);
			Language.GetValue(label81);
			Language.GetValue(label82);
			Language.GetValue(label38);
			Language.GetValue(label40);
			Language.GetValue(label39);
			Language.GetValue(ckbTuongTacCMSN);
			Language.GetValue(label11);
			Language.GetValue(label79);
			Language.GetValue(label80);
			Language.GetValue(label35);
			Language.GetValue(label45);
			Language.GetValue(label37);
			Language.GetValue(label28);
			Language.GetValue(rbTuongTacCMSNNhanTin);
			Language.GetValue(rbTuongTacCMSNDangBai);
			Language.GetValue(label10);
			Language.GetValue(button2);
			Language.GetValue(groupBox8);
			Language.GetValue(ckbKetBanTuKhoa);
			Language.GetValue(label16);
			Language.GetValue(pictureBox2);
			Language.GetValue(label3);
			Language.GetValue(label69);
			Language.GetValue(label70);
			Language.GetValue(label9);
			Language.GetValue(label15);
			Language.GetValue(label14);
			Language.GetValue(ckbKetBanGoiY);
			Language.GetValue(label2);
			Language.GetValue(label71);
			Language.GetValue(label72);
			Language.GetValue(label4);
			Language.GetValue(label6);
			Language.GetValue(label5);
			Language.GetValue(ckbKetBanTepUid);
			Language.GetValue(label17);
			Language.GetValue(button8);
			Language.GetValue(label20);
			Language.GetValue(label73);
			Language.GetValue(label74);
			Language.GetValue(label21);
			Language.GetValue(label23);
			Language.GetValue(label22);
			Language.GetValue(ckbKetBanTepUidTrungNhau);
			Language.GetValue(ckbXacNhanKetBan);
			Language.GetValue(label26);
			Language.GetValue(label75);
			Language.GetValue(label76);
			Language.GetValue(label31);
			Language.GetValue(label30);
			Language.GetValue(groupBox7);
			Language.GetValue(label12);
			Language.GetValue(button1);
			Language.GetValue(label13);
			Language.GetValue(label77);
			Language.GetValue(label78);
			Language.GetValue(label32);
			Language.GetValue(label63);
			Language.GetValue(label34);
			Language.GetValue(ckbThamGiaNhom);
			Language.GetValue(ckbThamGiaNhomTrungNhau);
			Language.GetValue(ckbThamGiaNhomTraLoiCauHoi);
			Language.GetValue(btnThamGiaNhomTraLoiCauHoi);
			Language.GetValue(btnAdd);
			Language.GetValue(btnCancel);
		}

		private void FConfigInteract_Load(object sender, EventArgs e)
		{
			LoadSetting();
			CheckedChangedFull();
		}

		private void LoadSetting()
		{
			ckbTuongTacNewsfeed.Checked = settings.GetValueBool("ckbTuongTacNewsfeed");
			nudTuongTacNewsfeedSoLuongFrom.Value = settings.GetValueInt("nudTuongTacNewsfeedSoLuongFrom", 1);
			nudTuongTacNewsfeedSoLuongTo.Value = settings.GetValueInt("nudTuongTacNewsfeedSoLuongTo", 3);
			nudTuongTacNewsfeedDelayFrom.Value = settings.GetValueInt("nudTuongTacNewsfeedDelayFrom", 2);
			nudTuongTacNewsfeedDelayTo.Value = settings.GetValueInt("nudTuongTacNewsfeedDelayTo", 5);
			ckbTuongTacNewsfeedLike.Checked = settings.GetValueBool("ckbTuongTacNewsfeedLike", valueDefault: true);
			ckbTuongTacNewsfeedComment.Checked = settings.GetValueBool("ckbTuongTacNewsfeedComment");
			ckbTuongTacFriend.Checked = settings.GetValueBool("ckbTuongTacFriend");
			nudTuongTacFriendSoLuongBanBeFrom.Value = settings.GetValueInt("nudTuongTacFriendSoLuongBanBe", 1);
			nudTuongTacFriendSoLuongBaiVietFrom.Value = settings.GetValueInt("nudTuongTacFriendSoLuongBaiVietFrom", 1);
			nudTuongTacFriendSoLuongBaiVietTo.Value = settings.GetValueInt("nudTuongTacFriendSoLuongBaiVietTo", 3);
			nudTuongTacFriendDelayFrom.Value = settings.GetValueInt("nudTuongTacFriendDelayFrom", 2);
			nudTuongTacFriendDelayTo.Value = settings.GetValueInt("nudTuongTacFriendDelayTo", 5);
			ckbTuongTacFriendLike.Checked = settings.GetValueBool("ckbTuongTacFriendLike", valueDefault: true);
			ckbTuongTacFriendComment.Checked = settings.GetValueBool("ckbTuongTacFriendComment", valueDefault: true);
			ckbTuongTacGroup.Checked = settings.GetValueBool("ckbTuongTacGroup");
			nudTuongTacGroupSoLuongNhomFrom.Value = settings.GetValueInt("nudTuongTacGroupSoLuongNhomFrom", 1);
			nudTuongTacGroupSoLuongNhomTo.Value = settings.GetValueInt("nudTuongTacGroupSoLuongNhomTo", 3);
			nudTuongTacGroupSoLuongBaiVietFrom.Value = settings.GetValueInt("nudTuongTacGroupSoLuongBaiVietFrom", 1);
			nudTuongTacGroupSoLuongBaiVietTo.Value = settings.GetValueInt("nudTuongTacGroupSoLuongBaiVietTo", 1);
			nudTuongTacGroupDelayFrom.Value = settings.GetValueInt("nudTuongTacGroupDelayFrom", 2);
			nudTuongTacGroupDelayTo.Value = settings.GetValueInt("nudTuongTacGroupDelayTo", 5);
			ckbTuongTacGroupLike.Checked = settings.GetValueBool("ckbTuongTacGroupLike", valueDefault: true);
			ckbTuongTacGroupComment.Checked = settings.GetValueBool("ckbTuongTacGroupComment");
			ckbTuongTacFanpage.Checked = settings.GetValueBool("ckbTuongTacFanpage");
			nudTuongTacFanpageSoLuongPageFrom.Value = settings.GetValueInt("nudTuongTacFanpageSoLuongPageFrom", 1);
			nudTuongTacFanpageSoLuongPageTo.Value = settings.GetValueInt("nudTuongTacFanpageSoLuongPageTo", 1);
			nudTuongTacFanpageSoLuongBaiVietFrom.Value = settings.GetValueInt("nudTuongTacFanpageSoLuongBaiVietFrom", 2);
			nudTuongTacFanpageSoLuongBaiVietTo.Value = settings.GetValueInt("nudTuongTacFanpageSoLuongBaiVietTo", 2);
			nudTuongTacFanpageDelayFrom.Value = settings.GetValueInt("nudTuongTacFanpageDelayFrom", 2);
			nudTuongTacFanpageDelayTo.Value = settings.GetValueInt("nudTuongTacFanpageDelayTo", 5);
			ckbTuongTacFanpageLike.Checked = settings.GetValueBool("ckbTuongTacFanpageLike", valueDefault: true);
			ckbTuongTacFanpageComment.Checked = settings.GetValueBool("ckbTuongTacFanpageComment");
			ckbKetBanTuKhoa.Checked = settings.GetValueBool("ckbKetBanTuKhoa");
			txtKetBanTuKhoaTuKhoa.Text = settings.GetValue("txtKetBanTuKhoaTuKhoa");
			nudKetBanTuKhoaSoLuongFrom.Value = settings.GetValueInt("nudKetBanTuKhoaSoLuongFrom", 1);
			nudKetBanTuKhoaSoLuongTo.Value = settings.GetValueInt("nudKetBanTuKhoaSoLuongTo", 3);
			nudKetBanTuKhoaDelayFrom.Value = settings.GetValueInt("nudKetBanTuKhoaDelayFrom", 2);
			nudKetBanTuKhoaDelayTo.Value = settings.GetValueInt("nudKetBanTuKhoaDelayTo", 5);
			ckbKetBanGoiY.Checked = settings.GetValueBool("ckbKetBanGoiY");
			nudKetBanGoiYSoLuongFrom.Value = settings.GetValueInt("nudKetBanGoiYSoLuongFrom", 1);
			nudKetBanGoiYSoLuongTo.Value = settings.GetValueInt("nudKetBanGoiYSoLuongTo", 3);
			nudKetBanGoiYDelayFrom.Value = settings.GetValueInt("nudKetBanGoiYDelayFrom", 2);
			nudKetBanGoiYDelayTo.Value = settings.GetValueInt("nudKetBanGoiYDelayTo", 5);
			ckbKetBanTepUid.Checked = settings.GetValueBool("ckbKetBanTepUid");
			nudKetBanTepUidSoLuongFrom.Value = settings.GetValueInt("nudKetBanTepUidSoLuongFrom", 1);
			nudKetBanTepUidSoLuongTo.Value = settings.GetValueInt("nudKetBanTepUidSoLuongTo", 3);
			nudKetBanTepUidDelayFrom.Value = settings.GetValueInt("nudKetBanTepUidDelayFrom", 2);
			nudKetBanTepUidDelayTo.Value = settings.GetValueInt("nudKetBanTepUidDelayTo", 5);
			ckbKetBanTepUidTrungNhau.Checked = settings.GetValueBool("ckbKetBanTepUidTrungNhau");
			ckbXacNhanKetBan.Checked = settings.GetValueBool("ckbXacNhanKetBan");
			nudXacNhanKetBanSoLuongFrom.Value = settings.GetValueInt("nudXacNhanKetBanSoLuongFrom", 1);
			nudXacNhanKetBanSoLuongTo.Value = settings.GetValueInt("nudXacNhanKetBanSoLuongTo", 3);
			nudXacNhanKetBanDelayFrom.Value = settings.GetValueInt("nudXacNhanKetBanDelayFrom", 2);
			nudXacNhanKetBanDelayTo.Value = settings.GetValueInt("nudXacNhanKetBanDelayTo", 5);
			ckbTuongTacNhanTin.Checked = settings.GetValueBool("ckbTuongTacNhanTin");
			nudTuongTacNhanTinSoLuongFrom.Value = settings.GetValueInt("nudTuongTacNhanTinSoLuongFrom", 1);
			nudTuongTacNhanTinSoLuongTo.Value = settings.GetValueInt("nudTuongTacNhanTinSoLuongTo", 3);
			nudTuongTacNhanTinDelayFrom.Value = settings.GetValueInt("nudTuongTacNhanTinDelayFrom", 2);
			nudTuongTacNhanTinDelayTo.Value = settings.GetValueInt("nudTuongTacNhanTinDelayTo", 5);
			ckbTuongTacChoc.Checked = settings.GetValueBool("ckbTuongTacChoc");
			nudTuongTacChocSoLuongFrom.Value = settings.GetValueInt("nudTuongTacChocSoLuongFrom", 1);
			nudTuongTacChocSoLuongTo.Value = settings.GetValueInt("nudTuongTacChocSoLuongTo", 3);
			nudTuongTacChocSoLuongDelayFrom.Value = settings.GetValueInt("nudTuongTacChocSoLuongDelayFrom", 2);
			nudTuongTacChocSoLuongDelayTo.Value = settings.GetValueInt("nudTuongTacChocSoLuongDelayTo", 5);
			ckbTuongTacCMSN.Checked = settings.GetValueBool("ckbTuongTacCMSN");
			nudTuongTacCMSNSoLuongFrom.Value = settings.GetValueInt("nudTuongTacCMSNSoLuongFrom", 1);
			nudTuongTacCMSNSoLuongTo.Value = settings.GetValueInt("nudTuongTacCMSNSoLuongTo", 3);
			nudTuongTacCMSNDelayFrom.Value = settings.GetValueInt("nudTuongTacCMSNDelayFrom", 2);
			nudTuongTacCMSNDelayTo.Value = settings.GetValueInt("nudTuongTacCMSNDelayTo", 5);
			if (settings.GetValueInt("TuongTacCMSNTypeAction") == 0)
			{
				rbTuongTacCMSNNhanTin.Checked = true;
			}
			else
			{
				rbTuongTacCMSNDangBai.Checked = true;
			}
			ckbThamGiaNhom.Checked = settings.GetValueBool("ckbThamGiaNhom");
			nudThamGiaNhomSoLuongFrom.Value = settings.GetValueInt("nudThamGiaNhomSoLuongFrom", 1);
			nudThamGiaNhomSoLuongTo.Value = settings.GetValueInt("nudThamGiaNhomSoLuongTo", 3);
			nudThamGiaNhomDelayFrom.Value = settings.GetValueInt("nudThamGiaNhomDelayFrom", 2);
			nudThamGiaNhomDelayTo.Value = settings.GetValueInt("nudThamGiaNhomDelayTo", 5);
			ckbThamGiaNhomTraLoiCauHoi.Checked = settings.GetValueBool("ckbThamGiaNhomTraLoiCauHoi");
			ckbThamGiaNhomTrungNhau.Checked = settings.GetValueBool("ckbThamGiaNhomTrungNhau");
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			settings.Update("ckbTuongTacNewsfeed", ckbTuongTacNewsfeed.Checked);
			settings.Update("nudTuongTacNewsfeedSoLuongFrom", Convert.ToInt32(nudTuongTacNewsfeedSoLuongFrom.Value));
			settings.Update("nudTuongTacNewsfeedSoLuongTo", Convert.ToInt32(nudTuongTacNewsfeedSoLuongTo.Value));
			settings.Update("nudTuongTacNewsfeedDelayFrom", Convert.ToInt32(nudTuongTacNewsfeedDelayFrom.Value));
			settings.Update("nudTuongTacNewsfeedDelayTo", Convert.ToInt32(nudTuongTacNewsfeedDelayTo.Value));
			settings.Update("ckbTuongTacNewsfeedLike", ckbTuongTacNewsfeedLike.Checked);
			settings.Update("ckbTuongTacNewsfeedComment", ckbTuongTacNewsfeedComment.Checked);
			settings.Update("ckbTuongTacFriend", ckbTuongTacFriend.Checked);
			settings.Update("nudTuongTacFriendSoLuongBanBeFrom", Convert.ToInt32(nudTuongTacFriendSoLuongBanBeFrom.Value));
			settings.Update("nudTuongTacFriendSoLuongBanBeTo", Convert.ToInt32(nudTuongTacFriendSoLuongBanBeTo.Value));
			settings.Update("nudTuongTacFriendSoLuongBaiVietFrom", Convert.ToInt32(nudTuongTacFriendSoLuongBaiVietFrom.Value));
			settings.Update("nudTuongTacFriendSoLuongBaiVietTo", Convert.ToInt32(nudTuongTacFriendSoLuongBaiVietTo.Value));
			settings.Update("nudTuongTacFriendDelayFrom", Convert.ToInt32(nudTuongTacFriendDelayFrom.Value));
			settings.Update("nudTuongTacFriendDelayTo", Convert.ToInt32(nudTuongTacFriendDelayTo.Value));
			settings.Update("ckbTuongTacFriendLike", ckbTuongTacFriendLike.Checked);
			settings.Update("ckbTuongTacFriendComment", ckbTuongTacFriendComment.Checked);
			settings.Update("ckbTuongTacGroup", ckbTuongTacGroup.Checked);
			settings.Update("nudTuongTacGroupSoLuongNhomFrom", Convert.ToInt32(nudTuongTacGroupSoLuongNhomFrom.Value));
			settings.Update("nudTuongTacGroupSoLuongNhomTo", Convert.ToInt32(nudTuongTacGroupSoLuongNhomTo.Value));
			settings.Update("nudTuongTacGroupSoLuongBaiVietFrom", Convert.ToInt32(nudTuongTacGroupSoLuongBaiVietFrom.Value));
			settings.Update("nudTuongTacGroupSoLuongBaiVietTo", Convert.ToInt32(nudTuongTacGroupSoLuongBaiVietTo.Value));
			settings.Update("nudTuongTacGroupDelayFrom", Convert.ToInt32(nudTuongTacGroupDelayFrom.Value));
			settings.Update("nudTuongTacGroupDelayTo", Convert.ToInt32(nudTuongTacGroupDelayTo.Value));
			settings.Update("ckbTuongTacGroupLike", ckbTuongTacGroupLike.Checked);
			settings.Update("ckbTuongTacGroupComment", ckbTuongTacGroupComment.Checked);
			settings.Update("ckbTuongTacFanpage", ckbTuongTacFanpage.Checked);
			settings.Update("nudTuongTacFanpageSoLuongPageFrom", Convert.ToInt32(nudTuongTacFanpageSoLuongPageFrom.Value));
			settings.Update("nudTuongTacFanpageSoLuongPageTo", Convert.ToInt32(nudTuongTacFanpageSoLuongPageTo.Value));
			settings.Update("nudTuongTacFanpageSoLuongBaiVietFrom", Convert.ToInt32(nudTuongTacFanpageSoLuongBaiVietFrom.Value));
			settings.Update("nudTuongTacFanpageSoLuongBaiVietTo", Convert.ToInt32(nudTuongTacFanpageSoLuongBaiVietTo.Value));
			settings.Update("nudTuongTacFanpageDelayFrom", Convert.ToInt32(nudTuongTacFanpageDelayFrom.Value));
			settings.Update("nudTuongTacFanpageDelayTo", Convert.ToInt32(nudTuongTacFanpageDelayTo.Value));
			settings.Update("ckbTuongTacFanpageLike", ckbTuongTacFanpageLike.Checked);
			settings.Update("ckbTuongTacFanpageComment", ckbTuongTacFanpageComment.Checked);
			settings.Update("ckbKetBanTuKhoa", ckbKetBanTuKhoa.Checked);
			settings.Update("txtKetBanTuKhoaTuKhoa", txtKetBanTuKhoaTuKhoa.Text);
			settings.Update("nudKetBanTuKhoaSoLuongFrom", Convert.ToInt32(nudKetBanTuKhoaSoLuongFrom.Value));
			settings.Update("nudKetBanTuKhoaSoLuongTo", Convert.ToInt32(nudKetBanTuKhoaSoLuongTo.Value));
			settings.Update("nudKetBanTuKhoaDelayFrom", Convert.ToInt32(nudKetBanTuKhoaDelayFrom.Value));
			settings.Update("nudKetBanTuKhoaDelayTo", Convert.ToInt32(nudKetBanTuKhoaDelayTo.Value));
			settings.Update("ckbKetBanGoiY", ckbKetBanGoiY.Checked);
			settings.Update("nudKetBanGoiYSoLuongFrom", Convert.ToInt32(nudKetBanGoiYSoLuongFrom.Value));
			settings.Update("nudKetBanGoiYSoLuongTo", Convert.ToInt32(nudKetBanGoiYSoLuongTo.Value));
			settings.Update("nudKetBanGoiYDelayFrom", Convert.ToInt32(nudKetBanGoiYDelayFrom.Value));
			settings.Update("nudKetBanGoiYDelayTo", Convert.ToInt32(nudKetBanGoiYDelayTo.Value));
			settings.Update("ckbKetBanTepUid", ckbKetBanTepUid.Checked);
			settings.Update("nudKetBanTepUidSoLuongFrom", Convert.ToInt32(nudKetBanTepUidSoLuongFrom.Value));
			settings.Update("nudKetBanTepUidSoLuongTo", Convert.ToInt32(nudKetBanTepUidSoLuongTo.Value));
			settings.Update("nudKetBanTepUidDelayFrom", Convert.ToInt32(nudKetBanTepUidDelayFrom.Value));
			settings.Update("nudKetBanTepUidDelayTo", Convert.ToInt32(nudKetBanTepUidDelayTo.Value));
			settings.Update("ckbKetBanTepUidTrungNhau", ckbKetBanTepUidTrungNhau.Checked);
			settings.Update("ckbXacNhanKetBan", ckbXacNhanKetBan.Checked);
			settings.Update("nudXacNhanKetBanSoLuongFrom", Convert.ToInt32(nudXacNhanKetBanSoLuongFrom.Value));
			settings.Update("nudXacNhanKetBanSoLuongTo", Convert.ToInt32(nudXacNhanKetBanSoLuongTo.Value));
			settings.Update("nudXacNhanKetBanDelayFrom", Convert.ToInt32(nudXacNhanKetBanDelayFrom.Value));
			settings.Update("nudXacNhanKetBanDelayTo", Convert.ToInt32(nudXacNhanKetBanDelayTo.Value));
			settings.Update("ckbTuongTacNhanTin", ckbTuongTacNhanTin.Checked);
			settings.Update("nudTuongTacNhanTinSoLuongFrom", Convert.ToInt32(nudTuongTacNhanTinSoLuongFrom.Value));
			settings.Update("nudTuongTacNhanTinSoLuongTo", Convert.ToInt32(nudTuongTacNhanTinSoLuongTo.Value));
			settings.Update("nudTuongTacNhanTinDelayFrom", Convert.ToInt32(nudTuongTacNhanTinDelayFrom.Value));
			settings.Update("nudTuongTacNhanTinDelayTo", Convert.ToInt32(nudTuongTacNhanTinDelayTo.Value));
			settings.Update("ckbTuongTacChoc", ckbTuongTacChoc.Checked);
			settings.Update("nudTuongTacChocSoLuongFrom", Convert.ToInt32(nudTuongTacChocSoLuongFrom.Value));
			settings.Update("nudTuongTacChocSoLuongTo", Convert.ToInt32(nudTuongTacChocSoLuongTo.Value));
			settings.Update("nudTuongTacChocSoLuongDelayFrom", Convert.ToInt32(nudTuongTacChocSoLuongDelayFrom.Value));
			settings.Update("nudTuongTacChocSoLuongDelayTo", Convert.ToInt32(nudTuongTacChocSoLuongDelayTo.Value));
			settings.Update("ckbTuongTacCMSN", ckbTuongTacCMSN.Checked);
			settings.Update("nudTuongTacCMSNSoLuongFrom", Convert.ToInt32(nudTuongTacCMSNSoLuongFrom.Value));
			settings.Update("nudTuongTacCMSNSoLuongTo", Convert.ToInt32(nudTuongTacCMSNSoLuongTo.Value));
			settings.Update("nudTuongTacCMSNDelayFrom", Convert.ToInt32(nudTuongTacCMSNDelayFrom.Value));
			settings.Update("nudTuongTacCMSNDelayTo", Convert.ToInt32(nudTuongTacCMSNDelayTo.Value));
			if (rbTuongTacCMSNNhanTin.Checked)
			{
				settings.Update("TuongTacCMSNTypeAction", 0);
			}
			else
			{
				settings.Update("TuongTacCMSNTypeAction", 1);
			}
			settings.Update("ckbThamGiaNhom", ckbThamGiaNhom.Checked);
			settings.Update("nudThamGiaNhomSoLuongFrom", Convert.ToInt32(nudThamGiaNhomSoLuongFrom.Value));
			settings.Update("nudThamGiaNhomSoLuongTo", Convert.ToInt32(nudThamGiaNhomSoLuongTo.Value));
			settings.Update("nudThamGiaNhomDelayFrom", Convert.ToInt32(nudThamGiaNhomDelayFrom.Value));
			settings.Update("nudThamGiaNhomDelayTo", Convert.ToInt32(nudThamGiaNhomDelayTo.Value));
			settings.Update("ckbThamGiaNhomTraLoiCauHoi", ckbThamGiaNhomTraLoiCauHoi.Checked);
			settings.Update("ckbThamGiaNhomTrungNhau", ckbThamGiaNhomTrungNhau.Checked);
			settings.Save();
			if (MessageBoxHelper.ShowMessageBoxWithQuestion(Language.GetValue("Lưu thành công, ba\u0323n co\u0301 muô\u0301n đo\u0301ng cư\u0309a sô\u0309?")) == DialogResult.Yes)
			{
				Close();
			}
		}

		private void BtnOpenComment_Click(object sender, EventArgs e)
		{
			Process.Start("comments.txt");
		}

		private void BtnUploadUid_Click(object sender, EventArgs e)
		{
			Process.Start("uidadddfriend.txt");
		}

		private void BtnUploadGroup_Click(object sender, EventArgs e)
		{
			Process.Start("groups.txt");
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Process.Start("inboxs.txt");
		}

		private void CheckedChangedFull()
		{
			ckbTuongTacNewsfeed_CheckedChanged(null, null);
			ckbTuongTacFriend_CheckedChanged(null, null);
			ckbTuongTacGroup_CheckedChanged(null, null);
			ckbTuongTacFanpage_CheckedChanged(null, null);
			ckbKetBanTuKhoa_CheckedChanged(null, null);
			ckbKetBanTepUid_CheckedChanged(null, null);
			ckbKetBanGoiY_CheckedChanged(null, null);
			ckbTuongTacNhanTin_CheckedChanged(null, null);
			ckbTuongTacChoc_CheckedChanged(null, null);
			ckbTuongTacCMSN_CheckedChanged(null, null);
			ckbThamGiaNhom_CheckedChanged(null, null);
			ckbXacNhanKetBan_CheckedChanged(null, null);
			ckbTuongTacNewsfeedComment_CheckedChanged(null, null);
			ckbTuongTacFriendComment_CheckedChanged(null, null);
			ckbTuongTacGroupComment_CheckedChanged(null, null);
			ckbTuongTacFanpageComment_CheckedChanged(null, null);
			ckbThamGiaNhomTraLoiCauHoi_CheckedChanged(null, null);
		}

		private void ckbTuongTacNewsfeed_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacNewsfeed.Enabled = ckbTuongTacNewsfeed.Checked;
		}

		private void ckbTuongTacFriend_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacFriend.Enabled = ckbTuongTacFriend.Checked;
		}

		private void ckbTuongTacGroup_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacGroup.Enabled = ckbTuongTacGroup.Checked;
		}

		private void ckbTuongTacFanpage_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacFanpage.Enabled = ckbTuongTacFanpage.Checked;
		}

		private void ckbKetBanTuKhoa_CheckedChanged(object sender, EventArgs e)
		{
			plKetBanTuKhoa.Enabled = ckbKetBanTuKhoa.Checked;
		}

		private void ckbKetBanTepUid_CheckedChanged(object sender, EventArgs e)
		{
			plKetBanTepUid.Enabled = ckbKetBanTepUid.Checked;
		}

		private void ckbKetBanGoiY_CheckedChanged(object sender, EventArgs e)
		{
			plKetBanGoiY.Enabled = ckbKetBanGoiY.Checked;
		}

		private void ckbTuongTacNhanTin_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacNhanTin.Enabled = ckbTuongTacNhanTin.Checked;
		}

		private void ckbTuongTacChoc_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacChoc.Enabled = ckbTuongTacChoc.Checked;
		}

		private void ckbTuongTacCMSN_CheckedChanged(object sender, EventArgs e)
		{
			plTuongTacCMSN.Enabled = ckbTuongTacCMSN.Checked;
		}

		private void ckbThamGiaNhom_CheckedChanged(object sender, EventArgs e)
		{
			plThamGiaNhom.Enabled = ckbThamGiaNhom.Checked;
		}

		private void ckbXacNhanKetBan_CheckedChanged(object sender, EventArgs e)
		{
			plXacNhanKetBan.Enabled = ckbXacNhanKetBan.Checked;
		}

		private void btnOpenComment_Click_1(object sender, EventArgs e)
		{
			OpenFile("newsfeedcomments", Language.GetValue("Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("Danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng, spin nô\u0323i dung {a|b|c})"));
		}

		private void OpenFile(string nameFile, string title, string status, string footer)
		{
			try
			{
				string text = "reactions\\" + nameFile + ".txt";
				if (!File.Exists(text))
				{
					MCommon.Common.CreateFile(text);
				}
				MCommon.Common.ShowForm(new fNhapDuLieu1(text, title, status, footer));
			}
			catch
			{
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OpenFile("friendcomments", Language.GetValue("Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("Danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng, spin nô\u0323i dung {a|b|c})"));
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OpenFile("groupcomments", Language.GetValue("Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("Danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng, spin nô\u0323i dung {a|b|c})"));
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OpenFile("pages", Language.GetValue("Nhâ\u0323p danh sa\u0301ch ID page"), Language.GetValue("Danh sa\u0301ch ID page"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng)"));
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OpenFile("pagecomments", Language.GetValue("Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("Danh sa\u0301ch bi\u0300nh luâ\u0323n"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng, spin nô\u0323i dung {a|b|c})"));
		}

		private void btnInbox_Click(object sender, EventArgs e)
		{
			OpenFile("message", Language.GetValue("Nhâ\u0323p danh sa\u0301ch tin nhă\u0301n"), Language.GetValue("Danh sa\u0301ch tin nhă\u0301n"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng, spin nô\u0323i dung {a|b|c})"));
		}

		private void button2_Click(object sender, EventArgs e)
		{
			OpenFile("birthdaycontent", Language.GetValue("Nhâ\u0323p danh sa\u0301ch lơ\u0300i chu\u0301c"), Language.GetValue("Danh sa\u0301ch lơ\u0300i chu\u0301c"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng, spin nô\u0323i dung {a|b|c})"));
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OpenFile("idFriend", Language.GetValue("Nhâ\u0323p danh sa\u0301ch UID câ\u0300n kê\u0301t ba\u0323n"), Language.GetValue("Danh sa\u0301ch UID"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng)"));
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			OpenFile("idGroup", Language.GetValue("Nhâ\u0323p danh sa\u0301ch ID nho\u0301m câ\u0300n tham gia"), Language.GetValue("Danh sa\u0301ch ID nho\u0301m"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng)"));
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OpenFile("answer", Language.GetValue("Nhâ\u0323p danh sa\u0301ch câu tra\u0309 lơ\u0300i"), Language.GetValue("Danh sa\u0301ch câu tra\u0309 lơ\u0300i"), Language.GetValue("(Mô\u0303i nô\u0323i dung 1 do\u0300ng, spin nô\u0323i dung {a|b|c})"));
		}

		private void ckbTuongTacNewsfeedComment_CheckedChanged(object sender, EventArgs e)
		{
			btnTuongTacNewsfeedComment.Enabled = ckbTuongTacNewsfeedComment.Checked;
		}

		private void ckbTuongTacFriendComment_CheckedChanged(object sender, EventArgs e)
		{
			btnTuongTacFriendComment.Enabled = ckbTuongTacFriendComment.Checked;
		}

		private void ckbTuongTacGroupComment_CheckedChanged(object sender, EventArgs e)
		{
			btnTuongTacGroupComment.Enabled = ckbTuongTacGroupComment.Checked;
		}

		private void ckbTuongTacFanpageComment_CheckedChanged(object sender, EventArgs e)
		{
			btnTuongTacFanpageComment.Enabled = ckbTuongTacFanpageComment.Checked;
		}

		private void ckbThamGiaNhomTraLoiCauHoi_CheckedChanged(object sender, EventArgs e)
		{
			btnThamGiaNhomTraLoiCauHoi.Enabled = ckbThamGiaNhomTraLoiCauHoi.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maxcare.fConfigInteract));
			bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
			pnlHeader = new System.Windows.Forms.Panel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
			btnMinimize = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnAdd = new System.Windows.Forms.Button();
			groupBox5 = new System.Windows.Forms.GroupBox();
			plTuongTacCMSN = new System.Windows.Forms.Panel();
			rbTuongTacCMSNDangBai = new System.Windows.Forms.RadioButton();
			rbTuongTacCMSNNhanTin = new System.Windows.Forms.RadioButton();
			label11 = new System.Windows.Forms.Label();
			nudTuongTacCMSNSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			button2 = new System.Windows.Forms.Button();
			label28 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			nudTuongTacCMSNDelayFrom = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			label80 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			nudTuongTacCMSNSoLuongTo = new System.Windows.Forms.NumericUpDown();
			label79 = new System.Windows.Forms.Label();
			nudTuongTacCMSNDelayTo = new System.Windows.Forms.NumericUpDown();
			label45 = new System.Windows.Forms.Label();
			plTuongTacNhanTin = new System.Windows.Forms.Panel();
			btnInbox = new System.Windows.Forms.Button();
			label92 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			nudTuongTacNhanTinSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label42 = new System.Windows.Forms.Label();
			nudTuongTacNhanTinDelayFrom = new System.Windows.Forms.NumericUpDown();
			label84 = new System.Windows.Forms.Label();
			label43 = new System.Windows.Forms.Label();
			nudTuongTacNhanTinDelayTo = new System.Windows.Forms.NumericUpDown();
			nudTuongTacNhanTinSoLuongTo = new System.Windows.Forms.NumericUpDown();
			label83 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			plTuongTacChoc = new System.Windows.Forms.Panel();
			label36 = new System.Windows.Forms.Label();
			nudTuongTacChocSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label38 = new System.Windows.Forms.Label();
			nudTuongTacChocSoLuongDelayFrom = new System.Windows.Forms.NumericUpDown();
			label82 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			nudTuongTacChocSoLuongTo = new System.Windows.Forms.NumericUpDown();
			label81 = new System.Windows.Forms.Label();
			nudTuongTacChocSoLuongDelayTo = new System.Windows.Forms.NumericUpDown();
			label40 = new System.Windows.Forms.Label();
			ckbTuongTacNhanTin = new System.Windows.Forms.CheckBox();
			ckbTuongTacChoc = new System.Windows.Forms.CheckBox();
			ckbTuongTacCMSN = new System.Windows.Forms.CheckBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			plTuongTacFanpage = new System.Windows.Forms.Panel();
			label91 = new System.Windows.Forms.Label();
			label56 = new System.Windows.Forms.Label();
			nudTuongTacFanpageSoLuongPageFrom = new System.Windows.Forms.NumericUpDown();
			label58 = new System.Windows.Forms.Label();
			label87 = new System.Windows.Forms.Label();
			label85 = new System.Windows.Forms.Label();
			button7 = new System.Windows.Forms.Button();
			nudTuongTacFanpageSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
			ckbTuongTacFanpageComment = new System.Windows.Forms.CheckBox();
			btnTuongTacFanpageComment = new System.Windows.Forms.Button();
			ckbTuongTacFanpageLike = new System.Windows.Forms.CheckBox();
			label59 = new System.Windows.Forms.Label();
			label60 = new System.Windows.Forms.Label();
			nudTuongTacFanpageDelayFrom = new System.Windows.Forms.NumericUpDown();
			label61 = new System.Windows.Forms.Label();
			nudTuongTacFanpageDelayTo = new System.Windows.Forms.NumericUpDown();
			nudTuongTacFanpageSoLuongPageTo = new System.Windows.Forms.NumericUpDown();
			nudTuongTacFanpageSoLuongBaiVietTo = new System.Windows.Forms.NumericUpDown();
			label86 = new System.Windows.Forms.Label();
			label62 = new System.Windows.Forms.Label();
			label57 = new System.Windows.Forms.Label();
			plTuongTacGroup = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			nudTuongTacGroupSoLuongNhomFrom = new System.Windows.Forms.NumericUpDown();
			label89 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			nudTuongTacGroupSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
			ckbTuongTacGroupComment = new System.Windows.Forms.CheckBox();
			btnTuongTacGroupComment = new System.Windows.Forms.Button();
			ckbTuongTacGroupLike = new System.Windows.Forms.CheckBox();
			label90 = new System.Windows.Forms.Label();
			label50 = new System.Windows.Forms.Label();
			label51 = new System.Windows.Forms.Label();
			nudTuongTacGroupSoLuongBaiVietTo = new System.Windows.Forms.NumericUpDown();
			nudTuongTacGroupDelayFrom = new System.Windows.Forms.NumericUpDown();
			label55 = new System.Windows.Forms.Label();
			label52 = new System.Windows.Forms.Label();
			nudTuongTacGroupDelayTo = new System.Windows.Forms.NumericUpDown();
			label53 = new System.Windows.Forms.Label();
			nudTuongTacGroupSoLuongNhomTo = new System.Windows.Forms.NumericUpDown();
			label88 = new System.Windows.Forms.Label();
			plTuongTacFriend = new System.Windows.Forms.Panel();
			label49 = new System.Windows.Forms.Label();
			nudTuongTacFriendSoLuongBanBeFrom = new System.Windows.Forms.NumericUpDown();
			label68 = new System.Windows.Forms.Label();
			label54 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			nudTuongTacFriendSoLuongBaiVietFrom = new System.Windows.Forms.NumericUpDown();
			ckbTuongTacFriendComment = new System.Windows.Forms.CheckBox();
			btnTuongTacFriendComment = new System.Windows.Forms.Button();
			ckbTuongTacFriendLike = new System.Windows.Forms.CheckBox();
			label33 = new System.Windows.Forms.Label();
			label46 = new System.Windows.Forms.Label();
			nudTuongTacFriendDelayFrom = new System.Windows.Forms.NumericUpDown();
			label47 = new System.Windows.Forms.Label();
			nudTuongTacFriendSoLuongBaiVietTo = new System.Windows.Forms.NumericUpDown();
			nudTuongTacFriendSoLuongBanBeTo = new System.Windows.Forms.NumericUpDown();
			nudTuongTacFriendDelayTo = new System.Windows.Forms.NumericUpDown();
			label67 = new System.Windows.Forms.Label();
			label66 = new System.Windows.Forms.Label();
			label48 = new System.Windows.Forms.Label();
			plTuongTacNewsfeed = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			nudTuongTacNewsfeedSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			ckbTuongTacNewsfeedComment = new System.Windows.Forms.CheckBox();
			btnTuongTacNewsfeedComment = new System.Windows.Forms.Button();
			ckbTuongTacNewsfeedLike = new System.Windows.Forms.CheckBox();
			label8 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			nudTuongTacNewsfeedDelayFrom = new System.Windows.Forms.NumericUpDown();
			label65 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			nudTuongTacNewsfeedSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudTuongTacNewsfeedDelayTo = new System.Windows.Forms.NumericUpDown();
			label64 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			ckbTuongTacFanpage = new System.Windows.Forms.CheckBox();
			ckbTuongTacGroup = new System.Windows.Forms.CheckBox();
			ckbTuongTacNewsfeed = new System.Windows.Forms.CheckBox();
			ckbTuongTacFriend = new System.Windows.Forms.CheckBox();
			groupBox8 = new System.Windows.Forms.GroupBox();
			ckbKetBanTuKhoa = new System.Windows.Forms.CheckBox();
			plKetBanTepUid = new System.Windows.Forms.Panel();
			ckbKetBanTepUidTrungNhau = new System.Windows.Forms.CheckBox();
			label17 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			nudKetBanTepUidSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label21 = new System.Windows.Forms.Label();
			nudKetBanTepUidDelayFrom = new System.Windows.Forms.NumericUpDown();
			label22 = new System.Windows.Forms.Label();
			label74 = new System.Windows.Forms.Label();
			nudKetBanTepUidDelayTo = new System.Windows.Forms.NumericUpDown();
			nudKetBanTepUidSoLuongTo = new System.Windows.Forms.NumericUpDown();
			label73 = new System.Windows.Forms.Label();
			button8 = new System.Windows.Forms.Button();
			label23 = new System.Windows.Forms.Label();
			plKetBanTuKhoa = new System.Windows.Forms.Panel();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			txtKetBanTuKhoaTuKhoa = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			nudKetBanTuKhoaSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			nudKetBanTuKhoaDelayFrom = new System.Windows.Forms.NumericUpDown();
			label70 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			nudKetBanTuKhoaSoLuongTo = new System.Windows.Forms.NumericUpDown();
			label69 = new System.Windows.Forms.Label();
			nudKetBanTuKhoaDelayTo = new System.Windows.Forms.NumericUpDown();
			label15 = new System.Windows.Forms.Label();
			ckbKetBanGoiY = new System.Windows.Forms.CheckBox();
			plXacNhanKetBan = new System.Windows.Forms.Panel();
			label26 = new System.Windows.Forms.Label();
			nudXacNhanKetBanSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label27 = new System.Windows.Forms.Label();
			nudXacNhanKetBanDelayFrom = new System.Windows.Forms.NumericUpDown();
			label30 = new System.Windows.Forms.Label();
			nudXacNhanKetBanDelayTo = new System.Windows.Forms.NumericUpDown();
			label31 = new System.Windows.Forms.Label();
			label76 = new System.Windows.Forms.Label();
			nudXacNhanKetBanSoLuongTo = new System.Windows.Forms.NumericUpDown();
			label75 = new System.Windows.Forms.Label();
			plKetBanGoiY = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			nudKetBanGoiYSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			nudKetBanGoiYDelayFrom = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			nudKetBanGoiYDelayTo = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			label72 = new System.Windows.Forms.Label();
			nudKetBanGoiYSoLuongTo = new System.Windows.Forms.NumericUpDown();
			label71 = new System.Windows.Forms.Label();
			ckbKetBanTepUid = new System.Windows.Forms.CheckBox();
			ckbXacNhanKetBan = new System.Windows.Forms.CheckBox();
			groupBox7 = new System.Windows.Forms.GroupBox();
			ckbThamGiaNhom = new System.Windows.Forms.CheckBox();
			plThamGiaNhom = new System.Windows.Forms.Panel();
			ckbThamGiaNhomTrungNhau = new System.Windows.Forms.CheckBox();
			ckbThamGiaNhomTraLoiCauHoi = new System.Windows.Forms.CheckBox();
			label12 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			nudThamGiaNhomSoLuongFrom = new System.Windows.Forms.NumericUpDown();
			label32 = new System.Windows.Forms.Label();
			nudThamGiaNhomDelayFrom = new System.Windows.Forms.NumericUpDown();
			label78 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			nudThamGiaNhomSoLuongTo = new System.Windows.Forms.NumericUpDown();
			nudThamGiaNhomDelayTo = new System.Windows.Forms.NumericUpDown();
			btnThamGiaNhomTraLoiCauHoi = new System.Windows.Forms.Button();
			label77 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			label63 = new System.Windows.Forms.Label();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(components);
			bunifuCards1.SuspendLayout();
			pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox5.SuspendLayout();
			plTuongTacCMSN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNDelayTo).BeginInit();
			plTuongTacNhanTin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinSoLuongTo).BeginInit();
			plTuongTacChoc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongDelayTo).BeginInit();
			groupBox4.SuspendLayout();
			plTuongTacFanpage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongPageFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongBaiVietFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongPageTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongBaiVietTo).BeginInit();
			plTuongTacGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongNhomFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongBaiVietFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongBaiVietTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongNhomTo).BeginInit();
			plTuongTacFriend.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBanBeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBaiVietFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBaiVietTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBanBeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendDelayTo).BeginInit();
			plTuongTacNewsfeed.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedDelayTo).BeginInit();
			groupBox8.SuspendLayout();
			plKetBanTepUid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidSoLuongTo).BeginInit();
			plKetBanTuKhoa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaDelayTo).BeginInit();
			plXacNhanKetBan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanSoLuongTo).BeginInit();
			plKetBanGoiY.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYSoLuongTo).BeginInit();
			groupBox7.SuspendLayout();
			plThamGiaNhom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomSoLuongFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomDelayFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomSoLuongTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomDelayTo).BeginInit();
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
			bunifuCards1.Size = new System.Drawing.Size(1012, 38);
			bunifuCards1.TabIndex = 0;
			pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			pnlHeader.BackColor = System.Drawing.Color.White;
			pnlHeader.Controls.Add(pictureBox1);
			pnlHeader.Controls.Add(bunifuCustomLabel1);
			pnlHeader.Controls.Add(btnMinimize);
			pnlHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
			pnlHeader.Location = new System.Drawing.Point(0, 5);
			pnlHeader.Name = "pnlHeader";
			pnlHeader.Size = new System.Drawing.Size(1012, 30);
			pnlHeader.TabIndex = 9;
			pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(5, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(34, 27);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 77;
			pictureBox1.TabStop = false;
			bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
			bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
			bunifuCustomLabel1.Location = new System.Drawing.Point(0, 0);
			bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			bunifuCustomLabel1.Size = new System.Drawing.Size(980, 30);
			bunifuCustomLabel1.TabIndex = 0;
			bunifuCustomLabel1.Text = "Cấu hình Tương tác nhanh";
			bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
			btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			btnMinimize.FlatAppearance.BorderSize = 0;
			btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimize.ForeColor = System.Drawing.Color.White;
			btnMinimize.Image = (System.Drawing.Image)resources.GetObject("btnMinimize.Image");
			btnMinimize.Location = new System.Drawing.Point(980, 0);
			btnMinimize.Name = "btnMinimize";
			btnMinimize.Size = new System.Drawing.Size(32, 30);
			btnMinimize.TabIndex = 9;
			btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnMinimize.UseVisualStyleBackColor = true;
			btnMinimize.Click += new System.EventHandler(BtnMinimize_Click);
			btnCancel.BackColor = System.Drawing.Color.Maroon;
			btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCancel.ForeColor = System.Drawing.Color.White;
			btnCancel.Location = new System.Drawing.Point(513, 675);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(92, 29);
			btnCancel.TabIndex = 6;
			btnCancel.Text = "Đóng";
			btnCancel.UseVisualStyleBackColor = false;
			btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			btnAdd.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
			btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			btnAdd.FlatAppearance.BorderSize = 0;
			btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAdd.ForeColor = System.Drawing.Color.White;
			btnAdd.Location = new System.Drawing.Point(409, 675);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new System.Drawing.Size(92, 29);
			btnAdd.TabIndex = 5;
			btnAdd.Text = "Lưu";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += new System.EventHandler(BtnAdd_Click);
			groupBox5.Controls.Add(plTuongTacCMSN);
			groupBox5.Controls.Add(plTuongTacNhanTin);
			groupBox5.Controls.Add(plTuongTacChoc);
			groupBox5.Controls.Add(ckbTuongTacNhanTin);
			groupBox5.Controls.Add(ckbTuongTacChoc);
			groupBox5.Controls.Add(ckbTuongTacCMSN);
			groupBox5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox5.Location = new System.Drawing.Point(662, 37);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(344, 381);
			groupBox5.TabIndex = 2;
			groupBox5.TabStop = false;
			groupBox5.Text = "Tương ta\u0301c ba\u0323n be\u0300";
			plTuongTacCMSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacCMSN.Controls.Add(rbTuongTacCMSNDangBai);
			plTuongTacCMSN.Controls.Add(rbTuongTacCMSNNhanTin);
			plTuongTacCMSN.Controls.Add(label11);
			plTuongTacCMSN.Controls.Add(nudTuongTacCMSNSoLuongFrom);
			plTuongTacCMSN.Controls.Add(button2);
			plTuongTacCMSN.Controls.Add(label28);
			plTuongTacCMSN.Controls.Add(label35);
			plTuongTacCMSN.Controls.Add(nudTuongTacCMSNDelayFrom);
			plTuongTacCMSN.Controls.Add(label10);
			plTuongTacCMSN.Controls.Add(label80);
			plTuongTacCMSN.Controls.Add(label37);
			plTuongTacCMSN.Controls.Add(nudTuongTacCMSNSoLuongTo);
			plTuongTacCMSN.Controls.Add(label79);
			plTuongTacCMSN.Controls.Add(nudTuongTacCMSNDelayTo);
			plTuongTacCMSN.Controls.Add(label45);
			plTuongTacCMSN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTacCMSN.Location = new System.Drawing.Point(42, 256);
			plTuongTacCMSN.Name = "plTuongTacCMSN";
			plTuongTacCMSN.Size = new System.Drawing.Size(288, 118);
			plTuongTacCMSN.TabIndex = 5;
			rbTuongTacCMSNDangBai.AutoSize = true;
			rbTuongTacCMSNDangBai.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTuongTacCMSNDangBai.Location = new System.Drawing.Point(199, 59);
			rbTuongTacCMSNDangBai.Name = "rbTuongTacCMSNDangBai";
			rbTuongTacCMSNDangBai.Size = new System.Drawing.Size(77, 20);
			rbTuongTacCMSNDangBai.TabIndex = 4;
			rbTuongTacCMSNDangBai.Text = "Đăng ba\u0300i";
			rbTuongTacCMSNDangBai.UseVisualStyleBackColor = true;
			rbTuongTacCMSNNhanTin.AutoSize = true;
			rbTuongTacCMSNNhanTin.Checked = true;
			rbTuongTacCMSNNhanTin.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTuongTacCMSNNhanTin.Location = new System.Drawing.Point(122, 61);
			rbTuongTacCMSNNhanTin.Name = "rbTuongTacCMSNNhanTin";
			rbTuongTacCMSNNhanTin.Size = new System.Drawing.Size(73, 20);
			rbTuongTacCMSNNhanTin.TabIndex = 3;
			rbTuongTacCMSNNhanTin.TabStop = true;
			rbTuongTacCMSNNhanTin.Text = "Nhă\u0301n tin";
			rbTuongTacCMSNNhanTin.UseVisualStyleBackColor = true;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label11.Location = new System.Drawing.Point(7, 7);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(102, 16);
			label11.TabIndex = 89;
			label11.Text = "Sô\u0301 lươ\u0323ng ba\u0323n be\u0300";
			nudTuongTacCMSNSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacCMSNSoLuongFrom.Location = new System.Drawing.Point(122, 4);
			nudTuongTacCMSNSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacCMSNSoLuongFrom.Name = "nudTuongTacCMSNSoLuongFrom";
			nudTuongTacCMSNSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacCMSNSoLuongFrom.TabIndex = 0;
			nudTuongTacCMSNSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			button2.Cursor = System.Windows.Forms.Cursors.Hand;
			button2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button2.Location = new System.Drawing.Point(122, 84);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(58, 27);
			button2.TabIndex = 5;
			button2.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(button2, "Nhâ\u0323p danh sa\u0301ch nô\u0323i dung chu\u0301c mư\u0300ng sinh nhâ\u0323t");
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label28.Location = new System.Drawing.Point(7, 61);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(67, 16);
			label28.TabIndex = 89;
			label28.Text = "Hi\u0300nh thư\u0301c:";
			label35.AutoSize = true;
			label35.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label35.Location = new System.Drawing.Point(7, 36);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(100, 16);
			label35.TabIndex = 89;
			label35.Text = "Thơ\u0300i gian delay:";
			nudTuongTacCMSNDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacCMSNDelayFrom.Location = new System.Drawing.Point(122, 33);
			nudTuongTacCMSNDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacCMSNDelayFrom.Name = "nudTuongTacCMSNDelayFrom";
			nudTuongTacCMSNDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacCMSNDelayFrom.TabIndex = 1;
			nudTuongTacCMSNDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label10.Location = new System.Drawing.Point(7, 89);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(63, 16);
			label10.TabIndex = 89;
			label10.Text = "Nô\u0323i dung:";
			label80.AutoSize = true;
			label80.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label80.Location = new System.Drawing.Point(246, 8);
			label80.Name = "label80";
			label80.Size = new System.Drawing.Size(29, 16);
			label80.TabIndex = 91;
			label80.Text = "ba\u0323n";
			label37.AutoSize = true;
			label37.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label37.Location = new System.Drawing.Point(246, 38);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(31, 16);
			label37.TabIndex = 91;
			label37.Text = "giây";
			nudTuongTacCMSNSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacCMSNSoLuongTo.Location = new System.Drawing.Point(199, 4);
			nudTuongTacCMSNSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacCMSNSoLuongTo.Name = "nudTuongTacCMSNSoLuongTo";
			nudTuongTacCMSNSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacCMSNSoLuongTo.TabIndex = 2;
			nudTuongTacCMSNSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label79.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label79.Location = new System.Drawing.Point(167, 8);
			label79.Name = "label79";
			label79.Size = new System.Drawing.Size(29, 16);
			label79.TabIndex = 91;
			label79.Text = "đê\u0301n";
			label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudTuongTacCMSNDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacCMSNDelayTo.Location = new System.Drawing.Point(199, 33);
			nudTuongTacCMSNDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacCMSNDelayTo.Name = "nudTuongTacCMSNDelayTo";
			nudTuongTacCMSNDelayTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacCMSNDelayTo.TabIndex = 2;
			nudTuongTacCMSNDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label45.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label45.Location = new System.Drawing.Point(167, 38);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(29, 16);
			label45.TabIndex = 91;
			label45.Text = "đê\u0301n";
			label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plTuongTacNhanTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacNhanTin.Controls.Add(btnInbox);
			plTuongTacNhanTin.Controls.Add(label92);
			plTuongTacNhanTin.Controls.Add(label41);
			plTuongTacNhanTin.Controls.Add(nudTuongTacNhanTinSoLuongFrom);
			plTuongTacNhanTin.Controls.Add(label42);
			plTuongTacNhanTin.Controls.Add(nudTuongTacNhanTinDelayFrom);
			plTuongTacNhanTin.Controls.Add(label84);
			plTuongTacNhanTin.Controls.Add(label43);
			plTuongTacNhanTin.Controls.Add(nudTuongTacNhanTinDelayTo);
			plTuongTacNhanTin.Controls.Add(nudTuongTacNhanTinSoLuongTo);
			plTuongTacNhanTin.Controls.Add(label83);
			plTuongTacNhanTin.Controls.Add(label44);
			plTuongTacNhanTin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTacNhanTin.Location = new System.Drawing.Point(42, 45);
			plTuongTacNhanTin.Name = "plTuongTacNhanTin";
			plTuongTacNhanTin.Size = new System.Drawing.Size(288, 90);
			plTuongTacNhanTin.TabIndex = 1;
			btnInbox.Cursor = System.Windows.Forms.Cursors.Hand;
			btnInbox.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnInbox.Location = new System.Drawing.Point(122, 2);
			btnInbox.Name = "btnInbox";
			btnInbox.Size = new System.Drawing.Size(78, 27);
			btnInbox.TabIndex = 1;
			btnInbox.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(btnInbox, "Nhâ\u0323p danh sa\u0301ch tin nhă\u0301n");
			btnInbox.UseVisualStyleBackColor = true;
			btnInbox.Click += new System.EventHandler(btnInbox_Click);
			label92.AutoSize = true;
			label92.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label92.Location = new System.Drawing.Point(3, 6);
			label92.Name = "label92";
			label92.Size = new System.Drawing.Size(122, 16);
			label92.TabIndex = 0;
			label92.Text = "Danh sách tin nhắn:";
			label41.AutoSize = true;
			label41.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label41.Location = new System.Drawing.Point(3, 36);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(107, 16);
			label41.TabIndex = 89;
			label41.Text = "Sô\u0301 lươ\u0323ng ba\u0323n be\u0300:";
			nudTuongTacNhanTinSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNhanTinSoLuongFrom.Location = new System.Drawing.Point(123, 33);
			nudTuongTacNhanTinSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNhanTinSoLuongFrom.Name = "nudTuongTacNhanTinSoLuongFrom";
			nudTuongTacNhanTinSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacNhanTinSoLuongFrom.TabIndex = 0;
			nudTuongTacNhanTinSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label42.AutoSize = true;
			label42.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label42.Location = new System.Drawing.Point(3, 63);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(100, 16);
			label42.TabIndex = 89;
			label42.Text = "Thơ\u0300i gian delay:";
			nudTuongTacNhanTinDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNhanTinDelayFrom.Location = new System.Drawing.Point(123, 60);
			nudTuongTacNhanTinDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNhanTinDelayFrom.Name = "nudTuongTacNhanTinDelayFrom";
			nudTuongTacNhanTinDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacNhanTinDelayFrom.TabIndex = 2;
			nudTuongTacNhanTinDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label84.AutoSize = true;
			label84.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label84.Location = new System.Drawing.Point(247, 37);
			label84.Name = "label84";
			label84.Size = new System.Drawing.Size(29, 16);
			label84.TabIndex = 91;
			label84.Text = "ba\u0323n";
			label43.AutoSize = true;
			label43.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label43.Location = new System.Drawing.Point(247, 65);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(31, 16);
			label43.TabIndex = 91;
			label43.Text = "giây";
			nudTuongTacNhanTinDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNhanTinDelayTo.Location = new System.Drawing.Point(200, 61);
			nudTuongTacNhanTinDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNhanTinDelayTo.Name = "nudTuongTacNhanTinDelayTo";
			nudTuongTacNhanTinDelayTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacNhanTinDelayTo.TabIndex = 3;
			nudTuongTacNhanTinDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudTuongTacNhanTinSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNhanTinSoLuongTo.Location = new System.Drawing.Point(200, 33);
			nudTuongTacNhanTinSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNhanTinSoLuongTo.Name = "nudTuongTacNhanTinSoLuongTo";
			nudTuongTacNhanTinSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacNhanTinSoLuongTo.TabIndex = 2;
			nudTuongTacNhanTinSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label83.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label83.Location = new System.Drawing.Point(168, 37);
			label83.Name = "label83";
			label83.Size = new System.Drawing.Size(29, 16);
			label83.TabIndex = 91;
			label83.Text = "đê\u0301n";
			label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label44.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label44.Location = new System.Drawing.Point(168, 65);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(29, 16);
			label44.TabIndex = 91;
			label44.Text = "đê\u0301n";
			label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plTuongTacChoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacChoc.Controls.Add(label36);
			plTuongTacChoc.Controls.Add(nudTuongTacChocSoLuongFrom);
			plTuongTacChoc.Controls.Add(label38);
			plTuongTacChoc.Controls.Add(nudTuongTacChocSoLuongDelayFrom);
			plTuongTacChoc.Controls.Add(label82);
			plTuongTacChoc.Controls.Add(label39);
			plTuongTacChoc.Controls.Add(nudTuongTacChocSoLuongTo);
			plTuongTacChoc.Controls.Add(label81);
			plTuongTacChoc.Controls.Add(nudTuongTacChocSoLuongDelayTo);
			plTuongTacChoc.Controls.Add(label40);
			plTuongTacChoc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTacChoc.Location = new System.Drawing.Point(42, 163);
			plTuongTacChoc.Name = "plTuongTacChoc";
			plTuongTacChoc.Size = new System.Drawing.Size(288, 65);
			plTuongTacChoc.TabIndex = 3;
			label36.AutoSize = true;
			label36.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label36.Location = new System.Drawing.Point(3, 8);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(107, 16);
			label36.TabIndex = 89;
			label36.Text = "Sô\u0301 lươ\u0323ng ba\u0323n be\u0300:";
			nudTuongTacChocSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacChocSoLuongFrom.Location = new System.Drawing.Point(122, 5);
			nudTuongTacChocSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacChocSoLuongFrom.Name = "nudTuongTacChocSoLuongFrom";
			nudTuongTacChocSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacChocSoLuongFrom.TabIndex = 0;
			nudTuongTacChocSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label38.AutoSize = true;
			label38.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label38.Location = new System.Drawing.Point(3, 37);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(100, 16);
			label38.TabIndex = 89;
			label38.Text = "Thơ\u0300i gian delay:";
			nudTuongTacChocSoLuongDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacChocSoLuongDelayFrom.Location = new System.Drawing.Point(122, 34);
			nudTuongTacChocSoLuongDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacChocSoLuongDelayFrom.Name = "nudTuongTacChocSoLuongDelayFrom";
			nudTuongTacChocSoLuongDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacChocSoLuongDelayFrom.TabIndex = 1;
			nudTuongTacChocSoLuongDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label82.AutoSize = true;
			label82.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label82.Location = new System.Drawing.Point(246, 10);
			label82.Name = "label82";
			label82.Size = new System.Drawing.Size(29, 16);
			label82.TabIndex = 91;
			label82.Text = "ba\u0323n";
			label39.AutoSize = true;
			label39.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label39.Location = new System.Drawing.Point(246, 39);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(31, 16);
			label39.TabIndex = 91;
			label39.Text = "giây";
			nudTuongTacChocSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacChocSoLuongTo.Location = new System.Drawing.Point(199, 5);
			nudTuongTacChocSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacChocSoLuongTo.Name = "nudTuongTacChocSoLuongTo";
			nudTuongTacChocSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacChocSoLuongTo.TabIndex = 2;
			nudTuongTacChocSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label81.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label81.Location = new System.Drawing.Point(167, 10);
			label81.Name = "label81";
			label81.Size = new System.Drawing.Size(29, 16);
			label81.TabIndex = 91;
			label81.Text = "đê\u0301n";
			label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudTuongTacChocSoLuongDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacChocSoLuongDelayTo.Location = new System.Drawing.Point(199, 34);
			nudTuongTacChocSoLuongDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacChocSoLuongDelayTo.Name = "nudTuongTacChocSoLuongDelayTo";
			nudTuongTacChocSoLuongDelayTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacChocSoLuongDelayTo.TabIndex = 2;
			nudTuongTacChocSoLuongDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label40.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label40.Location = new System.Drawing.Point(167, 39);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(29, 16);
			label40.TabIndex = 91;
			label40.Text = "đê\u0301n";
			label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbTuongTacNhanTin.AutoSize = true;
			ckbTuongTacNhanTin.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacNhanTin.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacNhanTin.Location = new System.Drawing.Point(23, 22);
			ckbTuongTacNhanTin.Name = "ckbTuongTacNhanTin";
			ckbTuongTacNhanTin.Size = new System.Drawing.Size(74, 20);
			ckbTuongTacNhanTin.TabIndex = 0;
			ckbTuongTacNhanTin.Text = "Nhă\u0301n tin";
			ckbTuongTacNhanTin.UseVisualStyleBackColor = true;
			ckbTuongTacNhanTin.CheckedChanged += new System.EventHandler(ckbTuongTacNhanTin_CheckedChanged);
			ckbTuongTacChoc.AutoSize = true;
			ckbTuongTacChoc.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacChoc.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacChoc.Location = new System.Drawing.Point(23, 140);
			ckbTuongTacChoc.Name = "ckbTuongTacChoc";
			ckbTuongTacChoc.Size = new System.Drawing.Size(98, 20);
			ckbTuongTacChoc.TabIndex = 2;
			ckbTuongTacChoc.Text = "Cho\u0323c ba\u0323n be\u0300";
			ckbTuongTacChoc.UseVisualStyleBackColor = true;
			ckbTuongTacChoc.CheckedChanged += new System.EventHandler(ckbTuongTacChoc_CheckedChanged);
			ckbTuongTacCMSN.AutoSize = true;
			ckbTuongTacCMSN.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacCMSN.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacCMSN.Location = new System.Drawing.Point(23, 233);
			ckbTuongTacCMSN.Name = "ckbTuongTacCMSN";
			ckbTuongTacCMSN.Size = new System.Drawing.Size(148, 20);
			ckbTuongTacCMSN.TabIndex = 4;
			ckbTuongTacCMSN.Text = "Chu\u0301c mư\u0300ng sinh nhâ\u0323t";
			ckbTuongTacCMSN.UseVisualStyleBackColor = true;
			ckbTuongTacCMSN.CheckedChanged += new System.EventHandler(ckbTuongTacCMSN_CheckedChanged);
			groupBox4.Controls.Add(plTuongTacFanpage);
			groupBox4.Controls.Add(plTuongTacGroup);
			groupBox4.Controls.Add(plTuongTacFriend);
			groupBox4.Controls.Add(plTuongTacNewsfeed);
			groupBox4.Controls.Add(ckbTuongTacFanpage);
			groupBox4.Controls.Add(ckbTuongTacGroup);
			groupBox4.Controls.Add(ckbTuongTacNewsfeed);
			groupBox4.Controls.Add(ckbTuongTacFriend);
			groupBox4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox4.Location = new System.Drawing.Point(7, 37);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(649, 381);
			groupBox4.TabIndex = 1;
			groupBox4.TabStop = false;
			groupBox4.Text = "Tương ta\u0301c ba\u0300i viê\u0301t";
			plTuongTacFanpage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacFanpage.Controls.Add(label91);
			plTuongTacFanpage.Controls.Add(label56);
			plTuongTacFanpage.Controls.Add(nudTuongTacFanpageSoLuongPageFrom);
			plTuongTacFanpage.Controls.Add(label58);
			plTuongTacFanpage.Controls.Add(button7);
			plTuongTacFanpage.Controls.Add(nudTuongTacFanpageSoLuongBaiVietFrom);
			plTuongTacFanpage.Controls.Add(ckbTuongTacFanpageComment);
			plTuongTacFanpage.Controls.Add(btnTuongTacFanpageComment);
			plTuongTacFanpage.Controls.Add(ckbTuongTacFanpageLike);
			plTuongTacFanpage.Controls.Add(label59);
			plTuongTacFanpage.Controls.Add(label60);
			plTuongTacFanpage.Controls.Add(nudTuongTacFanpageDelayFrom);
			plTuongTacFanpage.Controls.Add(nudTuongTacFanpageDelayTo);
			plTuongTacFanpage.Controls.Add(nudTuongTacFanpageSoLuongPageTo);
			plTuongTacFanpage.Controls.Add(nudTuongTacFanpageSoLuongBaiVietTo);
			plTuongTacFanpage.Controls.Add(label86);
			plTuongTacFanpage.Controls.Add(label62);
			plTuongTacFanpage.Controls.Add(label57);
			plTuongTacFanpage.Controls.Add(label87);
			plTuongTacFanpage.Controls.Add(label85);
			plTuongTacFanpage.Controls.Add(label61);
			plTuongTacFanpage.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTacFanpage.Location = new System.Drawing.Point(41, 198);
			plTuongTacFanpage.Name = "plTuongTacFanpage";
			plTuongTacFanpage.Size = new System.Drawing.Size(278, 176);
			plTuongTacFanpage.TabIndex = 97;
			label91.AutoSize = true;
			label91.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label91.Location = new System.Drawing.Point(7, 8);
			label91.Name = "label91";
			label91.Size = new System.Drawing.Size(90, 16);
			label91.TabIndex = 0;
			label91.Text = "Nhập ID Page:";
			label56.AutoSize = true;
			label56.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label56.Location = new System.Drawing.Point(7, 38);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(96, 16);
			label56.TabIndex = 0;
			label56.Text = "Sô\u0301 lươ\u0323ng page:";
			nudTuongTacFanpageSoLuongPageFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFanpageSoLuongPageFrom.Location = new System.Drawing.Point(117, 35);
			nudTuongTacFanpageSoLuongPageFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFanpageSoLuongPageFrom.Name = "nudTuongTacFanpageSoLuongPageFrom";
			nudTuongTacFanpageSoLuongPageFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacFanpageSoLuongPageFrom.TabIndex = 1;
			nudTuongTacFanpageSoLuongPageFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label58.AutoSize = true;
			label58.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label58.Location = new System.Drawing.Point(7, 67);
			label58.Name = "label58";
			label58.Size = new System.Drawing.Size(106, 16);
			label58.TabIndex = 89;
			label58.Text = "Sô\u0301 ba\u0300i viê\u0301t/page:";
			label87.AutoSize = true;
			label87.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label87.Location = new System.Drawing.Point(239, 38);
			label87.Name = "label87";
			label87.Size = new System.Drawing.Size(36, 16);
			label87.TabIndex = 89;
			label87.Text = "page";
			label85.AutoSize = true;
			label85.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label85.Location = new System.Drawing.Point(239, 67);
			label85.Name = "label85";
			label85.Size = new System.Drawing.Size(25, 16);
			label85.TabIndex = 89;
			label85.Text = "ba\u0300i";
			button7.Cursor = System.Windows.Forms.Cursors.Hand;
			button7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button7.Location = new System.Drawing.Point(116, 3);
			button7.Name = "button7";
			button7.Size = new System.Drawing.Size(75, 27);
			button7.TabIndex = 2;
			button7.Text = "Nhập";
			toolTip1.SetToolTip(button7, "Nhâ\u0323p danh sa\u0301ch ID Page");
			button7.UseVisualStyleBackColor = true;
			button7.Click += new System.EventHandler(button7_Click);
			nudTuongTacFanpageSoLuongBaiVietFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFanpageSoLuongBaiVietFrom.Location = new System.Drawing.Point(117, 64);
			nudTuongTacFanpageSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFanpageSoLuongBaiVietFrom.Name = "nudTuongTacFanpageSoLuongBaiVietFrom";
			nudTuongTacFanpageSoLuongBaiVietFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacFanpageSoLuongBaiVietFrom.TabIndex = 3;
			nudTuongTacFanpageSoLuongBaiVietFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			ckbTuongTacFanpageComment.AutoSize = true;
			ckbTuongTacFanpageComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacFanpageComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacFanpageComment.Location = new System.Drawing.Point(117, 144);
			ckbTuongTacFanpageComment.Name = "ckbTuongTacFanpageComment";
			ckbTuongTacFanpageComment.Size = new System.Drawing.Size(82, 20);
			ckbTuongTacFanpageComment.TabIndex = 7;
			ckbTuongTacFanpageComment.Text = "Comment";
			ckbTuongTacFanpageComment.UseVisualStyleBackColor = true;
			ckbTuongTacFanpageComment.CheckedChanged += new System.EventHandler(ckbTuongTacFanpageComment_CheckedChanged);
			btnTuongTacFanpageComment.Cursor = System.Windows.Forms.Cursors.Hand;
			btnTuongTacFanpageComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnTuongTacFanpageComment.Location = new System.Drawing.Point(208, 140);
			btnTuongTacFanpageComment.Name = "btnTuongTacFanpageComment";
			btnTuongTacFanpageComment.Size = new System.Drawing.Size(58, 27);
			btnTuongTacFanpageComment.TabIndex = 8;
			btnTuongTacFanpageComment.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(btnTuongTacFanpageComment, "Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n");
			btnTuongTacFanpageComment.UseVisualStyleBackColor = true;
			btnTuongTacFanpageComment.Click += new System.EventHandler(button6_Click);
			ckbTuongTacFanpageLike.AutoSize = true;
			ckbTuongTacFanpageLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacFanpageLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacFanpageLike.Location = new System.Drawing.Point(117, 121);
			ckbTuongTacFanpageLike.Name = "ckbTuongTacFanpageLike";
			ckbTuongTacFanpageLike.Size = new System.Drawing.Size(49, 20);
			ckbTuongTacFanpageLike.TabIndex = 6;
			ckbTuongTacFanpageLike.Text = "Like";
			ckbTuongTacFanpageLike.UseVisualStyleBackColor = true;
			label59.AutoSize = true;
			label59.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label59.Location = new System.Drawing.Point(7, 122);
			label59.Name = "label59";
			label59.Size = new System.Drawing.Size(94, 16);
			label59.TabIndex = 89;
			label59.Text = "Loa\u0323i tương ta\u0301c:";
			label60.AutoSize = true;
			label60.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label60.Location = new System.Drawing.Point(7, 96);
			label60.Name = "label60";
			label60.Size = new System.Drawing.Size(100, 16);
			label60.TabIndex = 89;
			label60.Text = "Thơ\u0300i gian delay:";
			nudTuongTacFanpageDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFanpageDelayFrom.Location = new System.Drawing.Point(117, 93);
			nudTuongTacFanpageDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFanpageDelayFrom.Name = "nudTuongTacFanpageDelayFrom";
			nudTuongTacFanpageDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacFanpageDelayFrom.TabIndex = 4;
			nudTuongTacFanpageDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label61.AutoSize = true;
			label61.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label61.Location = new System.Drawing.Point(239, 98);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(31, 16);
			label61.TabIndex = 91;
			label61.Text = "giây";
			nudTuongTacFanpageDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFanpageDelayTo.Location = new System.Drawing.Point(194, 94);
			nudTuongTacFanpageDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFanpageDelayTo.Name = "nudTuongTacFanpageDelayTo";
			nudTuongTacFanpageDelayTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacFanpageDelayTo.TabIndex = 5;
			nudTuongTacFanpageDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudTuongTacFanpageSoLuongPageTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFanpageSoLuongPageTo.Location = new System.Drawing.Point(194, 36);
			nudTuongTacFanpageSoLuongPageTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFanpageSoLuongPageTo.Name = "nudTuongTacFanpageSoLuongPageTo";
			nudTuongTacFanpageSoLuongPageTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacFanpageSoLuongPageTo.TabIndex = 4;
			nudTuongTacFanpageSoLuongPageTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudTuongTacFanpageSoLuongBaiVietTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFanpageSoLuongBaiVietTo.Location = new System.Drawing.Point(194, 65);
			nudTuongTacFanpageSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFanpageSoLuongBaiVietTo.Name = "nudTuongTacFanpageSoLuongBaiVietTo";
			nudTuongTacFanpageSoLuongBaiVietTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacFanpageSoLuongBaiVietTo.TabIndex = 4;
			nudTuongTacFanpageSoLuongBaiVietTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label86.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label86.Location = new System.Drawing.Point(162, 38);
			label86.Name = "label86";
			label86.Size = new System.Drawing.Size(29, 16);
			label86.TabIndex = 91;
			label86.Text = "đê\u0301n";
			label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label62.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label62.Location = new System.Drawing.Point(162, 98);
			label62.Name = "label62";
			label62.Size = new System.Drawing.Size(29, 16);
			label62.TabIndex = 91;
			label62.Text = "đê\u0301n";
			label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label57.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label57.Location = new System.Drawing.Point(162, 67);
			label57.Name = "label57";
			label57.Size = new System.Drawing.Size(29, 16);
			label57.TabIndex = 91;
			label57.Text = "đê\u0301n";
			label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plTuongTacGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacGroup.Controls.Add(label7);
			plTuongTacGroup.Controls.Add(nudTuongTacGroupSoLuongNhomFrom);
			plTuongTacGroup.Controls.Add(label18);
			plTuongTacGroup.Controls.Add(nudTuongTacGroupSoLuongBaiVietFrom);
			plTuongTacGroup.Controls.Add(ckbTuongTacGroupComment);
			plTuongTacGroup.Controls.Add(btnTuongTacGroupComment);
			plTuongTacGroup.Controls.Add(ckbTuongTacGroupLike);
			plTuongTacGroup.Controls.Add(label50);
			plTuongTacGroup.Controls.Add(label51);
			plTuongTacGroup.Controls.Add(nudTuongTacGroupSoLuongBaiVietTo);
			plTuongTacGroup.Controls.Add(nudTuongTacGroupDelayFrom);
			plTuongTacGroup.Controls.Add(label55);
			plTuongTacGroup.Controls.Add(nudTuongTacGroupDelayTo);
			plTuongTacGroup.Controls.Add(label53);
			plTuongTacGroup.Controls.Add(nudTuongTacGroupSoLuongNhomTo);
			plTuongTacGroup.Controls.Add(label88);
			plTuongTacGroup.Controls.Add(label89);
			plTuongTacGroup.Controls.Add(label90);
			plTuongTacGroup.Controls.Add(label52);
			plTuongTacGroup.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTacGroup.Location = new System.Drawing.Point(358, 225);
			plTuongTacGroup.Name = "plTuongTacGroup";
			plTuongTacGroup.Size = new System.Drawing.Size(278, 149);
			plTuongTacGroup.TabIndex = 6;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label7.Location = new System.Drawing.Point(7, 8);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(100, 16);
			label7.TabIndex = 89;
			label7.Text = "Sô\u0301 lươ\u0323ng nho\u0301m:";
			nudTuongTacGroupSoLuongNhomFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacGroupSoLuongNhomFrom.Location = new System.Drawing.Point(117, 5);
			nudTuongTacGroupSoLuongNhomFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacGroupSoLuongNhomFrom.Name = "nudTuongTacGroupSoLuongNhomFrom";
			nudTuongTacGroupSoLuongNhomFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacGroupSoLuongNhomFrom.TabIndex = 0;
			nudTuongTacGroupSoLuongNhomFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label89.AutoSize = true;
			label89.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label89.Location = new System.Drawing.Point(239, 8);
			label89.Name = "label89";
			label89.Size = new System.Drawing.Size(40, 16);
			label89.TabIndex = 89;
			label89.Text = "nho\u0301m";
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label18.Location = new System.Drawing.Point(7, 37);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(110, 16);
			label18.TabIndex = 89;
			label18.Text = "Sô\u0301 ba\u0300i viê\u0301t/nho\u0301m:";
			nudTuongTacGroupSoLuongBaiVietFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacGroupSoLuongBaiVietFrom.Location = new System.Drawing.Point(117, 34);
			nudTuongTacGroupSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacGroupSoLuongBaiVietFrom.Name = "nudTuongTacGroupSoLuongBaiVietFrom";
			nudTuongTacGroupSoLuongBaiVietFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacGroupSoLuongBaiVietFrom.TabIndex = 1;
			nudTuongTacGroupSoLuongBaiVietFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			ckbTuongTacGroupComment.AutoSize = true;
			ckbTuongTacGroupComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacGroupComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacGroupComment.Location = new System.Drawing.Point(117, 117);
			ckbTuongTacGroupComment.Name = "ckbTuongTacGroupComment";
			ckbTuongTacGroupComment.Size = new System.Drawing.Size(82, 20);
			ckbTuongTacGroupComment.TabIndex = 5;
			ckbTuongTacGroupComment.Text = "Comment";
			ckbTuongTacGroupComment.UseVisualStyleBackColor = true;
			ckbTuongTacGroupComment.CheckedChanged += new System.EventHandler(ckbTuongTacGroupComment_CheckedChanged);
			btnTuongTacGroupComment.Cursor = System.Windows.Forms.Cursors.Hand;
			btnTuongTacGroupComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnTuongTacGroupComment.Location = new System.Drawing.Point(208, 113);
			btnTuongTacGroupComment.Name = "btnTuongTacGroupComment";
			btnTuongTacGroupComment.Size = new System.Drawing.Size(58, 27);
			btnTuongTacGroupComment.TabIndex = 6;
			btnTuongTacGroupComment.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(btnTuongTacGroupComment, "Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n");
			btnTuongTacGroupComment.UseVisualStyleBackColor = true;
			btnTuongTacGroupComment.Click += new System.EventHandler(button4_Click);
			ckbTuongTacGroupLike.AutoSize = true;
			ckbTuongTacGroupLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacGroupLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacGroupLike.Location = new System.Drawing.Point(117, 92);
			ckbTuongTacGroupLike.Name = "ckbTuongTacGroupLike";
			ckbTuongTacGroupLike.Size = new System.Drawing.Size(49, 20);
			ckbTuongTacGroupLike.TabIndex = 4;
			ckbTuongTacGroupLike.Text = "Like";
			ckbTuongTacGroupLike.UseVisualStyleBackColor = true;
			label90.AutoSize = true;
			label90.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label90.Location = new System.Drawing.Point(240, 38);
			label90.Name = "label90";
			label90.Size = new System.Drawing.Size(25, 16);
			label90.TabIndex = 91;
			label90.Text = "ba\u0300i";
			label50.AutoSize = true;
			label50.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label50.Location = new System.Drawing.Point(7, 93);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(94, 16);
			label50.TabIndex = 89;
			label50.Text = "Loa\u0323i tương ta\u0301c:";
			label51.AutoSize = true;
			label51.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label51.Location = new System.Drawing.Point(7, 66);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(100, 16);
			label51.TabIndex = 89;
			label51.Text = "Thơ\u0300i gian delay:";
			nudTuongTacGroupSoLuongBaiVietTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacGroupSoLuongBaiVietTo.Location = new System.Drawing.Point(194, 35);
			nudTuongTacGroupSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacGroupSoLuongBaiVietTo.Name = "nudTuongTacGroupSoLuongBaiVietTo";
			nudTuongTacGroupSoLuongBaiVietTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacGroupSoLuongBaiVietTo.TabIndex = 2;
			nudTuongTacGroupSoLuongBaiVietTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudTuongTacGroupDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacGroupDelayFrom.Location = new System.Drawing.Point(117, 63);
			nudTuongTacGroupDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacGroupDelayFrom.Name = "nudTuongTacGroupDelayFrom";
			nudTuongTacGroupDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacGroupDelayFrom.TabIndex = 2;
			nudTuongTacGroupDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label55.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label55.Location = new System.Drawing.Point(162, 38);
			label55.Name = "label55";
			label55.Size = new System.Drawing.Size(29, 16);
			label55.TabIndex = 91;
			label55.Text = "đê\u0301n";
			label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label52.AutoSize = true;
			label52.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label52.Location = new System.Drawing.Point(240, 68);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(31, 16);
			label52.TabIndex = 91;
			label52.Text = "giây";
			nudTuongTacGroupDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacGroupDelayTo.Location = new System.Drawing.Point(194, 64);
			nudTuongTacGroupDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacGroupDelayTo.Name = "nudTuongTacGroupDelayTo";
			nudTuongTacGroupDelayTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacGroupDelayTo.TabIndex = 3;
			nudTuongTacGroupDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label53.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label53.Location = new System.Drawing.Point(162, 68);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(29, 16);
			label53.TabIndex = 91;
			label53.Text = "đê\u0301n";
			label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudTuongTacGroupSoLuongNhomTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacGroupSoLuongNhomTo.Location = new System.Drawing.Point(194, 5);
			nudTuongTacGroupSoLuongNhomTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacGroupSoLuongNhomTo.Name = "nudTuongTacGroupSoLuongNhomTo";
			nudTuongTacGroupSoLuongNhomTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacGroupSoLuongNhomTo.TabIndex = 4;
			nudTuongTacGroupSoLuongNhomTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label88.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label88.Location = new System.Drawing.Point(162, 8);
			label88.Name = "label88";
			label88.Size = new System.Drawing.Size(29, 16);
			label88.TabIndex = 91;
			label88.Text = "đê\u0301n";
			label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plTuongTacFriend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacFriend.Controls.Add(label49);
			plTuongTacFriend.Controls.Add(nudTuongTacFriendSoLuongBanBeFrom);
			plTuongTacFriend.Controls.Add(label19);
			plTuongTacFriend.Controls.Add(nudTuongTacFriendSoLuongBaiVietFrom);
			plTuongTacFriend.Controls.Add(ckbTuongTacFriendComment);
			plTuongTacFriend.Controls.Add(btnTuongTacFriendComment);
			plTuongTacFriend.Controls.Add(ckbTuongTacFriendLike);
			plTuongTacFriend.Controls.Add(label33);
			plTuongTacFriend.Controls.Add(label46);
			plTuongTacFriend.Controls.Add(nudTuongTacFriendDelayFrom);
			plTuongTacFriend.Controls.Add(nudTuongTacFriendSoLuongBaiVietTo);
			plTuongTacFriend.Controls.Add(nudTuongTacFriendSoLuongBanBeTo);
			plTuongTacFriend.Controls.Add(nudTuongTacFriendDelayTo);
			plTuongTacFriend.Controls.Add(label67);
			plTuongTacFriend.Controls.Add(label66);
			plTuongTacFriend.Controls.Add(label48);
			plTuongTacFriend.Controls.Add(label68);
			plTuongTacFriend.Controls.Add(label54);
			plTuongTacFriend.Controls.Add(label47);
			plTuongTacFriend.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTacFriend.Location = new System.Drawing.Point(356, 46);
			plTuongTacFriend.Name = "plTuongTacFriend";
			plTuongTacFriend.Size = new System.Drawing.Size(278, 151);
			plTuongTacFriend.TabIndex = 4;
			label49.AutoSize = true;
			label49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label49.Location = new System.Drawing.Point(7, 8);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(107, 16);
			label49.TabIndex = 0;
			label49.Text = "Sô\u0301 lươ\u0323ng ba\u0323n be\u0300:";
			nudTuongTacFriendSoLuongBanBeFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFriendSoLuongBanBeFrom.Location = new System.Drawing.Point(117, 5);
			nudTuongTacFriendSoLuongBanBeFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFriendSoLuongBanBeFrom.Name = "nudTuongTacFriendSoLuongBanBeFrom";
			nudTuongTacFriendSoLuongBanBeFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacFriendSoLuongBanBeFrom.TabIndex = 1;
			nudTuongTacFriendSoLuongBanBeFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label68.AutoSize = true;
			label68.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label68.Location = new System.Drawing.Point(240, 8);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(29, 16);
			label68.TabIndex = 89;
			label68.Text = "ba\u0323n";
			label54.AutoSize = true;
			label54.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label54.Location = new System.Drawing.Point(240, 37);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(25, 16);
			label54.TabIndex = 89;
			label54.Text = "ba\u0300i";
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label19.Location = new System.Drawing.Point(7, 37);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(99, 16);
			label19.TabIndex = 89;
			label19.Text = "Sô\u0301 ba\u0300i viê\u0301t/ba\u0323n:";
			nudTuongTacFriendSoLuongBaiVietFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFriendSoLuongBaiVietFrom.Location = new System.Drawing.Point(117, 34);
			nudTuongTacFriendSoLuongBaiVietFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFriendSoLuongBaiVietFrom.Name = "nudTuongTacFriendSoLuongBaiVietFrom";
			nudTuongTacFriendSoLuongBaiVietFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacFriendSoLuongBaiVietFrom.TabIndex = 2;
			nudTuongTacFriendSoLuongBaiVietFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			ckbTuongTacFriendComment.AutoSize = true;
			ckbTuongTacFriendComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacFriendComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacFriendComment.Location = new System.Drawing.Point(117, 118);
			ckbTuongTacFriendComment.Name = "ckbTuongTacFriendComment";
			ckbTuongTacFriendComment.Size = new System.Drawing.Size(82, 20);
			ckbTuongTacFriendComment.TabIndex = 6;
			ckbTuongTacFriendComment.Text = "Comment";
			ckbTuongTacFriendComment.UseVisualStyleBackColor = true;
			ckbTuongTacFriendComment.CheckedChanged += new System.EventHandler(ckbTuongTacFriendComment_CheckedChanged);
			btnTuongTacFriendComment.Cursor = System.Windows.Forms.Cursors.Hand;
			btnTuongTacFriendComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnTuongTacFriendComment.Location = new System.Drawing.Point(208, 114);
			btnTuongTacFriendComment.Name = "btnTuongTacFriendComment";
			btnTuongTacFriendComment.Size = new System.Drawing.Size(58, 27);
			btnTuongTacFriendComment.TabIndex = 7;
			btnTuongTacFriendComment.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(btnTuongTacFriendComment, "Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n");
			btnTuongTacFriendComment.UseVisualStyleBackColor = true;
			btnTuongTacFriendComment.Click += new System.EventHandler(button3_Click);
			ckbTuongTacFriendLike.AutoSize = true;
			ckbTuongTacFriendLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacFriendLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacFriendLike.Location = new System.Drawing.Point(117, 93);
			ckbTuongTacFriendLike.Name = "ckbTuongTacFriendLike";
			ckbTuongTacFriendLike.Size = new System.Drawing.Size(49, 20);
			ckbTuongTacFriendLike.TabIndex = 5;
			ckbTuongTacFriendLike.Text = "Like";
			ckbTuongTacFriendLike.UseVisualStyleBackColor = true;
			label33.AutoSize = true;
			label33.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label33.Location = new System.Drawing.Point(7, 94);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(94, 16);
			label33.TabIndex = 89;
			label33.Text = "Loa\u0323i tương ta\u0301c:";
			label46.AutoSize = true;
			label46.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label46.Location = new System.Drawing.Point(7, 66);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(100, 16);
			label46.TabIndex = 89;
			label46.Text = "Thơ\u0300i gian delay:";
			nudTuongTacFriendDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFriendDelayFrom.Location = new System.Drawing.Point(117, 63);
			nudTuongTacFriendDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFriendDelayFrom.Name = "nudTuongTacFriendDelayFrom";
			nudTuongTacFriendDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacFriendDelayFrom.TabIndex = 3;
			nudTuongTacFriendDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label47.AutoSize = true;
			label47.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label47.Location = new System.Drawing.Point(240, 68);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(31, 16);
			label47.TabIndex = 91;
			label47.Text = "giây";
			nudTuongTacFriendSoLuongBaiVietTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFriendSoLuongBaiVietTo.Location = new System.Drawing.Point(194, 35);
			nudTuongTacFriendSoLuongBaiVietTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFriendSoLuongBaiVietTo.Name = "nudTuongTacFriendSoLuongBaiVietTo";
			nudTuongTacFriendSoLuongBaiVietTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacFriendSoLuongBaiVietTo.TabIndex = 4;
			nudTuongTacFriendSoLuongBaiVietTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudTuongTacFriendSoLuongBanBeTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFriendSoLuongBanBeTo.Location = new System.Drawing.Point(194, 6);
			nudTuongTacFriendSoLuongBanBeTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFriendSoLuongBanBeTo.Name = "nudTuongTacFriendSoLuongBanBeTo";
			nudTuongTacFriendSoLuongBanBeTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacFriendSoLuongBanBeTo.TabIndex = 4;
			nudTuongTacFriendSoLuongBanBeTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudTuongTacFriendDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacFriendDelayTo.Location = new System.Drawing.Point(194, 64);
			nudTuongTacFriendDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacFriendDelayTo.Name = "nudTuongTacFriendDelayTo";
			nudTuongTacFriendDelayTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacFriendDelayTo.TabIndex = 4;
			nudTuongTacFriendDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label67.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label67.Location = new System.Drawing.Point(162, 37);
			label67.Name = "label67";
			label67.Size = new System.Drawing.Size(29, 16);
			label67.TabIndex = 91;
			label67.Text = "đê\u0301n";
			label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label66.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label66.Location = new System.Drawing.Point(162, 8);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(29, 16);
			label66.TabIndex = 91;
			label66.Text = "đê\u0301n";
			label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label48.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label48.Location = new System.Drawing.Point(162, 68);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(29, 16);
			label48.TabIndex = 91;
			label48.Text = "đê\u0301n";
			label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plTuongTacNewsfeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTuongTacNewsfeed.Controls.Add(label1);
			plTuongTacNewsfeed.Controls.Add(nudTuongTacNewsfeedSoLuongFrom);
			plTuongTacNewsfeed.Controls.Add(ckbTuongTacNewsfeedComment);
			plTuongTacNewsfeed.Controls.Add(btnTuongTacNewsfeedComment);
			plTuongTacNewsfeed.Controls.Add(ckbTuongTacNewsfeedLike);
			plTuongTacNewsfeed.Controls.Add(label8);
			plTuongTacNewsfeed.Controls.Add(label24);
			plTuongTacNewsfeed.Controls.Add(nudTuongTacNewsfeedDelayFrom);
			plTuongTacNewsfeed.Controls.Add(nudTuongTacNewsfeedSoLuongTo);
			plTuongTacNewsfeed.Controls.Add(nudTuongTacNewsfeedDelayTo);
			plTuongTacNewsfeed.Controls.Add(label64);
			plTuongTacNewsfeed.Controls.Add(label25);
			plTuongTacNewsfeed.Controls.Add(label65);
			plTuongTacNewsfeed.Controls.Add(label29);
			plTuongTacNewsfeed.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTuongTacNewsfeed.Location = new System.Drawing.Point(41, 46);
			plTuongTacNewsfeed.Name = "plTuongTacNewsfeed";
			plTuongTacNewsfeed.Size = new System.Drawing.Size(278, 123);
			plTuongTacNewsfeed.TabIndex = 2;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label1.Location = new System.Drawing.Point(7, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(109, 16);
			label1.TabIndex = 89;
			label1.Text = "Sô\u0301 lươ\u0323ng ba\u0300i viê\u0301t:";
			nudTuongTacNewsfeedSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNewsfeedSoLuongFrom.Location = new System.Drawing.Point(117, 6);
			nudTuongTacNewsfeedSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNewsfeedSoLuongFrom.Name = "nudTuongTacNewsfeedSoLuongFrom";
			nudTuongTacNewsfeedSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacNewsfeedSoLuongFrom.TabIndex = 0;
			nudTuongTacNewsfeedSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			ckbTuongTacNewsfeedComment.AutoSize = true;
			ckbTuongTacNewsfeedComment.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacNewsfeedComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacNewsfeedComment.Location = new System.Drawing.Point(117, 90);
			ckbTuongTacNewsfeedComment.Name = "ckbTuongTacNewsfeedComment";
			ckbTuongTacNewsfeedComment.Size = new System.Drawing.Size(82, 20);
			ckbTuongTacNewsfeedComment.TabIndex = 4;
			ckbTuongTacNewsfeedComment.Text = "Comment";
			ckbTuongTacNewsfeedComment.UseVisualStyleBackColor = true;
			ckbTuongTacNewsfeedComment.CheckedChanged += new System.EventHandler(ckbTuongTacNewsfeedComment_CheckedChanged);
			btnTuongTacNewsfeedComment.Cursor = System.Windows.Forms.Cursors.Hand;
			btnTuongTacNewsfeedComment.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnTuongTacNewsfeedComment.Location = new System.Drawing.Point(208, 86);
			btnTuongTacNewsfeedComment.Name = "btnTuongTacNewsfeedComment";
			btnTuongTacNewsfeedComment.Size = new System.Drawing.Size(58, 27);
			btnTuongTacNewsfeedComment.TabIndex = 5;
			btnTuongTacNewsfeedComment.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(btnTuongTacNewsfeedComment, "Nhâ\u0323p danh sa\u0301ch bi\u0300nh luâ\u0323n");
			btnTuongTacNewsfeedComment.UseVisualStyleBackColor = true;
			btnTuongTacNewsfeedComment.Click += new System.EventHandler(btnOpenComment_Click_1);
			ckbTuongTacNewsfeedLike.AutoSize = true;
			ckbTuongTacNewsfeedLike.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacNewsfeedLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacNewsfeedLike.Location = new System.Drawing.Point(117, 65);
			ckbTuongTacNewsfeedLike.Name = "ckbTuongTacNewsfeedLike";
			ckbTuongTacNewsfeedLike.Size = new System.Drawing.Size(49, 20);
			ckbTuongTacNewsfeedLike.TabIndex = 3;
			ckbTuongTacNewsfeedLike.Text = "Like";
			ckbTuongTacNewsfeedLike.UseVisualStyleBackColor = true;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label8.Location = new System.Drawing.Point(7, 66);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(94, 16);
			label8.TabIndex = 89;
			label8.Text = "Loa\u0323i tương ta\u0301c:";
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label24.Location = new System.Drawing.Point(7, 39);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(100, 16);
			label24.TabIndex = 89;
			label24.Text = "Thơ\u0300i gian delay:";
			nudTuongTacNewsfeedDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNewsfeedDelayFrom.Location = new System.Drawing.Point(117, 36);
			nudTuongTacNewsfeedDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNewsfeedDelayFrom.Name = "nudTuongTacNewsfeedDelayFrom";
			nudTuongTacNewsfeedDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudTuongTacNewsfeedDelayFrom.TabIndex = 1;
			nudTuongTacNewsfeedDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label65.AutoSize = true;
			label65.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label65.Location = new System.Drawing.Point(240, 11);
			label65.Name = "label65";
			label65.Size = new System.Drawing.Size(25, 16);
			label65.TabIndex = 91;
			label65.Text = "ba\u0300i";
			label29.AutoSize = true;
			label29.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label29.Location = new System.Drawing.Point(240, 40);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(31, 16);
			label29.TabIndex = 91;
			label29.Text = "giây";
			nudTuongTacNewsfeedSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNewsfeedSoLuongTo.Location = new System.Drawing.Point(194, 7);
			nudTuongTacNewsfeedSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNewsfeedSoLuongTo.Name = "nudTuongTacNewsfeedSoLuongTo";
			nudTuongTacNewsfeedSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacNewsfeedSoLuongTo.TabIndex = 2;
			nudTuongTacNewsfeedSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudTuongTacNewsfeedDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudTuongTacNewsfeedDelayTo.Location = new System.Drawing.Point(194, 37);
			nudTuongTacNewsfeedDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudTuongTacNewsfeedDelayTo.Name = "nudTuongTacNewsfeedDelayTo";
			nudTuongTacNewsfeedDelayTo.Size = new System.Drawing.Size(47, 23);
			nudTuongTacNewsfeedDelayTo.TabIndex = 2;
			nudTuongTacNewsfeedDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label64.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label64.Location = new System.Drawing.Point(162, 11);
			label64.Name = "label64";
			label64.Size = new System.Drawing.Size(29, 16);
			label64.TabIndex = 91;
			label64.Text = "đê\u0301n";
			label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label25.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label25.Location = new System.Drawing.Point(162, 41);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(29, 16);
			label25.TabIndex = 91;
			label25.Text = "đê\u0301n";
			label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbTuongTacFanpage.AutoSize = true;
			ckbTuongTacFanpage.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacFanpage.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacFanpage.Location = new System.Drawing.Point(21, 175);
			ckbTuongTacFanpage.Name = "ckbTuongTacFanpage";
			ckbTuongTacFanpage.Size = new System.Drawing.Size(76, 20);
			ckbTuongTacFanpage.TabIndex = 7;
			ckbTuongTacFanpage.Text = "Fanpage";
			ckbTuongTacFanpage.UseVisualStyleBackColor = true;
			ckbTuongTacFanpage.CheckedChanged += new System.EventHandler(ckbTuongTacFanpage_CheckedChanged);
			ckbTuongTacGroup.AutoSize = true;
			ckbTuongTacGroup.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacGroup.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacGroup.Location = new System.Drawing.Point(338, 204);
			ckbTuongTacGroup.Name = "ckbTuongTacGroup";
			ckbTuongTacGroup.Size = new System.Drawing.Size(61, 20);
			ckbTuongTacGroup.TabIndex = 5;
			ckbTuongTacGroup.Text = "Group";
			ckbTuongTacGroup.UseVisualStyleBackColor = true;
			ckbTuongTacGroup.CheckedChanged += new System.EventHandler(ckbTuongTacGroup_CheckedChanged);
			ckbTuongTacNewsfeed.AutoSize = true;
			ckbTuongTacNewsfeed.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacNewsfeed.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacNewsfeed.Location = new System.Drawing.Point(23, 22);
			ckbTuongTacNewsfeed.Name = "ckbTuongTacNewsfeed";
			ckbTuongTacNewsfeed.Size = new System.Drawing.Size(83, 20);
			ckbTuongTacNewsfeed.TabIndex = 0;
			ckbTuongTacNewsfeed.Text = "Newsfeed";
			ckbTuongTacNewsfeed.UseVisualStyleBackColor = true;
			ckbTuongTacNewsfeed.CheckedChanged += new System.EventHandler(ckbTuongTacNewsfeed_CheckedChanged);
			ckbTuongTacFriend.AutoSize = true;
			ckbTuongTacFriend.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbTuongTacFriend.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbTuongTacFriend.Location = new System.Drawing.Point(338, 22);
			ckbTuongTacFriend.Name = "ckbTuongTacFriend";
			ckbTuongTacFriend.Size = new System.Drawing.Size(63, 20);
			ckbTuongTacFriend.TabIndex = 3;
			ckbTuongTacFriend.Text = "Friend";
			ckbTuongTacFriend.UseVisualStyleBackColor = true;
			ckbTuongTacFriend.CheckedChanged += new System.EventHandler(ckbTuongTacFriend_CheckedChanged);
			groupBox8.Controls.Add(ckbKetBanTuKhoa);
			groupBox8.Controls.Add(plKetBanTepUid);
			groupBox8.Controls.Add(plKetBanTuKhoa);
			groupBox8.Controls.Add(ckbKetBanGoiY);
			groupBox8.Controls.Add(plXacNhanKetBan);
			groupBox8.Controls.Add(plKetBanGoiY);
			groupBox8.Controls.Add(ckbKetBanTepUid);
			groupBox8.Controls.Add(ckbXacNhanKetBan);
			groupBox8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox8.Location = new System.Drawing.Point(7, 424);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new System.Drawing.Size(649, 243);
			groupBox8.TabIndex = 3;
			groupBox8.TabStop = false;
			groupBox8.Text = "Kê\u0301t ba\u0323n";
			ckbKetBanTuKhoa.AutoSize = true;
			ckbKetBanTuKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKetBanTuKhoa.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbKetBanTuKhoa.Location = new System.Drawing.Point(23, 20);
			ckbKetBanTuKhoa.Name = "ckbKetBanTuKhoa";
			ckbKetBanTuKhoa.Size = new System.Drawing.Size(146, 20);
			ckbKetBanTuKhoa.TabIndex = 0;
			ckbKetBanTuKhoa.Text = "Kết bạn theo tư\u0300 kho\u0301a";
			ckbKetBanTuKhoa.UseVisualStyleBackColor = true;
			ckbKetBanTuKhoa.CheckedChanged += new System.EventHandler(ckbKetBanTuKhoa_CheckedChanged);
			plKetBanTepUid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plKetBanTepUid.Controls.Add(ckbKetBanTepUidTrungNhau);
			plKetBanTepUid.Controls.Add(label17);
			plKetBanTepUid.Controls.Add(label20);
			plKetBanTepUid.Controls.Add(nudKetBanTepUidSoLuongFrom);
			plKetBanTepUid.Controls.Add(label21);
			plKetBanTepUid.Controls.Add(nudKetBanTepUidDelayFrom);
			plKetBanTepUid.Controls.Add(nudKetBanTepUidDelayTo);
			plKetBanTepUid.Controls.Add(nudKetBanTepUidSoLuongTo);
			plKetBanTepUid.Controls.Add(label73);
			plKetBanTepUid.Controls.Add(button8);
			plKetBanTepUid.Controls.Add(label23);
			plKetBanTepUid.Controls.Add(label22);
			plKetBanTepUid.Controls.Add(label74);
			plKetBanTepUid.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plKetBanTepUid.Location = new System.Drawing.Point(358, 43);
			plKetBanTepUid.Name = "plKetBanTepUid";
			plKetBanTepUid.Size = new System.Drawing.Size(278, 105);
			plKetBanTepUid.TabIndex = 5;
			ckbKetBanTepUidTrungNhau.AutoSize = true;
			ckbKetBanTepUidTrungNhau.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKetBanTepUidTrungNhau.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbKetBanTepUidTrungNhau.Location = new System.Drawing.Point(10, 82);
			ckbKetBanTepUidTrungNhau.Name = "ckbKetBanTepUidTrungNhau";
			ckbKetBanTepUidTrungNhau.Size = new System.Drawing.Size(193, 20);
			ckbKetBanTepUidTrungNhau.TabIndex = 112;
			ckbKetBanTepUidTrungNhau.Text = "Cho phép kết bạn trùng nhau";
			ckbKetBanTepUidTrungNhau.UseVisualStyleBackColor = true;
			ckbKetBanTepUidTrungNhau.CheckedChanged += new System.EventHandler(ckbThamGiaNhomTraLoiCauHoi_CheckedChanged);
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label17.Location = new System.Drawing.Point(7, 7);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(88, 16);
			label17.TabIndex = 89;
			label17.Text = "Nhâ\u0323p tê\u0323p UID:";
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label20.Location = new System.Drawing.Point(7, 34);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(64, 16);
			label20.TabIndex = 89;
			label20.Text = "Sô\u0301 lươ\u0323ng:";
			nudKetBanTepUidSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTepUidSoLuongFrom.Location = new System.Drawing.Point(117, 31);
			nudKetBanTepUidSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTepUidSoLuongFrom.Name = "nudKetBanTepUidSoLuongFrom";
			nudKetBanTepUidSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudKetBanTepUidSoLuongFrom.TabIndex = 1;
			nudKetBanTepUidSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label21.Location = new System.Drawing.Point(7, 61);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(100, 16);
			label21.TabIndex = 89;
			label21.Text = "Thơ\u0300i gian delay:";
			nudKetBanTepUidDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTepUidDelayFrom.Location = new System.Drawing.Point(117, 57);
			nudKetBanTepUidDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTepUidDelayFrom.Name = "nudKetBanTepUidDelayFrom";
			nudKetBanTepUidDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudKetBanTepUidDelayFrom.TabIndex = 2;
			nudKetBanTepUidDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label22.Location = new System.Drawing.Point(239, 61);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(31, 16);
			label22.TabIndex = 91;
			label22.Text = "giây";
			label74.AutoSize = true;
			label74.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label74.Location = new System.Drawing.Point(239, 36);
			label74.Name = "label74";
			label74.Size = new System.Drawing.Size(29, 16);
			label74.TabIndex = 91;
			label74.Text = "ba\u0323n";
			nudKetBanTepUidDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTepUidDelayTo.Location = new System.Drawing.Point(194, 58);
			nudKetBanTepUidDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTepUidDelayTo.Name = "nudKetBanTepUidDelayTo";
			nudKetBanTepUidDelayTo.Size = new System.Drawing.Size(47, 23);
			nudKetBanTepUidDelayTo.TabIndex = 3;
			nudKetBanTepUidDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudKetBanTepUidSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTepUidSoLuongTo.Location = new System.Drawing.Point(194, 32);
			nudKetBanTepUidSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTepUidSoLuongTo.Name = "nudKetBanTepUidSoLuongTo";
			nudKetBanTepUidSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudKetBanTepUidSoLuongTo.TabIndex = 3;
			nudKetBanTepUidSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label73.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label73.Location = new System.Drawing.Point(162, 36);
			label73.Name = "label73";
			label73.Size = new System.Drawing.Size(29, 16);
			label73.TabIndex = 91;
			label73.Text = "đê\u0301n";
			label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button8.Cursor = System.Windows.Forms.Cursors.Hand;
			button8.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button8.Location = new System.Drawing.Point(116, 2);
			button8.Name = "button8";
			button8.Size = new System.Drawing.Size(80, 27);
			button8.TabIndex = 0;
			button8.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(button8, "Nhâ\u0323p danh sa\u0301ch UID câ\u0300n kê\u0301t ba\u0323n");
			button8.UseVisualStyleBackColor = true;
			button8.Click += new System.EventHandler(button8_Click);
			label23.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label23.Location = new System.Drawing.Point(162, 61);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(29, 16);
			label23.TabIndex = 91;
			label23.Text = "đê\u0301n";
			label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plKetBanTuKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plKetBanTuKhoa.Controls.Add(pictureBox2);
			plKetBanTuKhoa.Controls.Add(txtKetBanTuKhoaTuKhoa);
			plKetBanTuKhoa.Controls.Add(label16);
			plKetBanTuKhoa.Controls.Add(label3);
			plKetBanTuKhoa.Controls.Add(nudKetBanTuKhoaSoLuongFrom);
			plKetBanTuKhoa.Controls.Add(label9);
			plKetBanTuKhoa.Controls.Add(nudKetBanTuKhoaDelayFrom);
			plKetBanTuKhoa.Controls.Add(nudKetBanTuKhoaSoLuongTo);
			plKetBanTuKhoa.Controls.Add(label69);
			plKetBanTuKhoa.Controls.Add(nudKetBanTuKhoaDelayTo);
			plKetBanTuKhoa.Controls.Add(label15);
			plKetBanTuKhoa.Controls.Add(label70);
			plKetBanTuKhoa.Controls.Add(label14);
			plKetBanTuKhoa.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plKetBanTuKhoa.Location = new System.Drawing.Point(41, 43);
			plKetBanTuKhoa.Name = "plKetBanTuKhoa";
			plKetBanTuKhoa.Size = new System.Drawing.Size(278, 91);
			plKetBanTuKhoa.TabIndex = 1;
			pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(249, 3);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(25, 25);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 92;
			pictureBox2.TabStop = false;
			toolTip1.SetToolTip(pictureBox2, "Có thể nhập nhiều từ khóa, ngăn cách nhau bởi dấu |");
			txtKetBanTuKhoaTuKhoa.Location = new System.Drawing.Point(117, 4);
			txtKetBanTuKhoaTuKhoa.Name = "txtKetBanTuKhoaTuKhoa";
			txtKetBanTuKhoaTuKhoa.Size = new System.Drawing.Size(129, 23);
			txtKetBanTuKhoaTuKhoa.TabIndex = 0;
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label16.Location = new System.Drawing.Point(7, 7);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(60, 16);
			label16.TabIndex = 89;
			label16.Text = "Tư\u0300 kho\u0301a:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label3.Location = new System.Drawing.Point(7, 35);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(64, 16);
			label3.TabIndex = 89;
			label3.Text = "Sô\u0301 lươ\u0323ng:";
			nudKetBanTuKhoaSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTuKhoaSoLuongFrom.Location = new System.Drawing.Point(117, 32);
			nudKetBanTuKhoaSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTuKhoaSoLuongFrom.Name = "nudKetBanTuKhoaSoLuongFrom";
			nudKetBanTuKhoaSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudKetBanTuKhoaSoLuongFrom.TabIndex = 1;
			nudKetBanTuKhoaSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label9.Location = new System.Drawing.Point(7, 64);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(100, 16);
			label9.TabIndex = 89;
			label9.Text = "Thơ\u0300i gian delay:";
			nudKetBanTuKhoaDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTuKhoaDelayFrom.Location = new System.Drawing.Point(117, 62);
			nudKetBanTuKhoaDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTuKhoaDelayFrom.Name = "nudKetBanTuKhoaDelayFrom";
			nudKetBanTuKhoaDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudKetBanTuKhoaDelayFrom.TabIndex = 2;
			nudKetBanTuKhoaDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label70.AutoSize = true;
			label70.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label70.Location = new System.Drawing.Point(239, 36);
			label70.Name = "label70";
			label70.Size = new System.Drawing.Size(29, 16);
			label70.TabIndex = 91;
			label70.Text = "ba\u0323n";
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label14.Location = new System.Drawing.Point(239, 66);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(31, 16);
			label14.TabIndex = 91;
			label14.Text = "giây";
			nudKetBanTuKhoaSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTuKhoaSoLuongTo.Location = new System.Drawing.Point(194, 32);
			nudKetBanTuKhoaSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTuKhoaSoLuongTo.Name = "nudKetBanTuKhoaSoLuongTo";
			nudKetBanTuKhoaSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudKetBanTuKhoaSoLuongTo.TabIndex = 3;
			nudKetBanTuKhoaSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label69.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label69.Location = new System.Drawing.Point(162, 36);
			label69.Name = "label69";
			label69.Size = new System.Drawing.Size(29, 16);
			label69.TabIndex = 91;
			label69.Text = "đê\u0301n";
			label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			nudKetBanTuKhoaDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanTuKhoaDelayTo.Location = new System.Drawing.Point(194, 62);
			nudKetBanTuKhoaDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanTuKhoaDelayTo.Name = "nudKetBanTuKhoaDelayTo";
			nudKetBanTuKhoaDelayTo.Size = new System.Drawing.Size(47, 23);
			nudKetBanTuKhoaDelayTo.TabIndex = 3;
			nudKetBanTuKhoaDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label15.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label15.Location = new System.Drawing.Point(162, 66);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(29, 16);
			label15.TabIndex = 91;
			label15.Text = "đê\u0301n";
			label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbKetBanGoiY.AutoSize = true;
			ckbKetBanGoiY.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKetBanGoiY.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbKetBanGoiY.Location = new System.Drawing.Point(23, 140);
			ckbKetBanGoiY.Name = "ckbKetBanGoiY";
			ckbKetBanGoiY.Size = new System.Drawing.Size(130, 20);
			ckbKetBanGoiY.TabIndex = 2;
			ckbKetBanGoiY.Text = "Kết bạn theo gợi ý";
			ckbKetBanGoiY.UseVisualStyleBackColor = true;
			ckbKetBanGoiY.CheckedChanged += new System.EventHandler(ckbKetBanGoiY_CheckedChanged);
			plXacNhanKetBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plXacNhanKetBan.Controls.Add(label26);
			plXacNhanKetBan.Controls.Add(nudXacNhanKetBanSoLuongFrom);
			plXacNhanKetBan.Controls.Add(label27);
			plXacNhanKetBan.Controls.Add(nudXacNhanKetBanDelayFrom);
			plXacNhanKetBan.Controls.Add(nudXacNhanKetBanDelayTo);
			plXacNhanKetBan.Controls.Add(label31);
			plXacNhanKetBan.Controls.Add(nudXacNhanKetBanSoLuongTo);
			plXacNhanKetBan.Controls.Add(label75);
			plXacNhanKetBan.Controls.Add(label30);
			plXacNhanKetBan.Controls.Add(label76);
			plXacNhanKetBan.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plXacNhanKetBan.Location = new System.Drawing.Point(358, 176);
			plXacNhanKetBan.Name = "plXacNhanKetBan";
			plXacNhanKetBan.Size = new System.Drawing.Size(278, 61);
			plXacNhanKetBan.TabIndex = 97;
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label26.Location = new System.Drawing.Point(7, 7);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(64, 16);
			label26.TabIndex = 89;
			label26.Text = "Sô\u0301 lươ\u0323ng:";
			nudXacNhanKetBanSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudXacNhanKetBanSoLuongFrom.Location = new System.Drawing.Point(117, 4);
			nudXacNhanKetBanSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudXacNhanKetBanSoLuongFrom.Name = "nudXacNhanKetBanSoLuongFrom";
			nudXacNhanKetBanSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudXacNhanKetBanSoLuongFrom.TabIndex = 0;
			nudXacNhanKetBanSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label27.Location = new System.Drawing.Point(7, 34);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(100, 16);
			label27.TabIndex = 89;
			label27.Text = "Thơ\u0300i gian delay:";
			nudXacNhanKetBanDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudXacNhanKetBanDelayFrom.Location = new System.Drawing.Point(117, 31);
			nudXacNhanKetBanDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudXacNhanKetBanDelayFrom.Name = "nudXacNhanKetBanDelayFrom";
			nudXacNhanKetBanDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudXacNhanKetBanDelayFrom.TabIndex = 1;
			nudXacNhanKetBanDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label30.Location = new System.Drawing.Point(239, 36);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(31, 16);
			label30.TabIndex = 91;
			label30.Text = "giây";
			nudXacNhanKetBanDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudXacNhanKetBanDelayTo.Location = new System.Drawing.Point(194, 32);
			nudXacNhanKetBanDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudXacNhanKetBanDelayTo.Name = "nudXacNhanKetBanDelayTo";
			nudXacNhanKetBanDelayTo.Size = new System.Drawing.Size(47, 23);
			nudXacNhanKetBanDelayTo.TabIndex = 2;
			nudXacNhanKetBanDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label31.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label31.Location = new System.Drawing.Point(162, 36);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(29, 16);
			label31.TabIndex = 91;
			label31.Text = "đê\u0301n";
			label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label76.AutoSize = true;
			label76.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label76.Location = new System.Drawing.Point(239, 9);
			label76.Name = "label76";
			label76.Size = new System.Drawing.Size(29, 16);
			label76.TabIndex = 91;
			label76.Text = "ba\u0323n";
			nudXacNhanKetBanSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudXacNhanKetBanSoLuongTo.Location = new System.Drawing.Point(194, 5);
			nudXacNhanKetBanSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudXacNhanKetBanSoLuongTo.Name = "nudXacNhanKetBanSoLuongTo";
			nudXacNhanKetBanSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudXacNhanKetBanSoLuongTo.TabIndex = 3;
			nudXacNhanKetBanSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label75.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label75.Location = new System.Drawing.Point(162, 9);
			label75.Name = "label75";
			label75.Size = new System.Drawing.Size(29, 16);
			label75.TabIndex = 91;
			label75.Text = "đê\u0301n";
			label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			plKetBanGoiY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plKetBanGoiY.Controls.Add(label2);
			plKetBanGoiY.Controls.Add(nudKetBanGoiYSoLuongFrom);
			plKetBanGoiY.Controls.Add(label4);
			plKetBanGoiY.Controls.Add(nudKetBanGoiYDelayFrom);
			plKetBanGoiY.Controls.Add(nudKetBanGoiYDelayTo);
			plKetBanGoiY.Controls.Add(label6);
			plKetBanGoiY.Controls.Add(nudKetBanGoiYSoLuongTo);
			plKetBanGoiY.Controls.Add(label71);
			plKetBanGoiY.Controls.Add(label5);
			plKetBanGoiY.Controls.Add(label72);
			plKetBanGoiY.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plKetBanGoiY.Location = new System.Drawing.Point(41, 162);
			plKetBanGoiY.Name = "plKetBanGoiY";
			plKetBanGoiY.Size = new System.Drawing.Size(278, 64);
			plKetBanGoiY.TabIndex = 3;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label2.Location = new System.Drawing.Point(7, 7);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(64, 16);
			label2.TabIndex = 89;
			label2.Text = "Sô\u0301 lươ\u0323ng:";
			nudKetBanGoiYSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanGoiYSoLuongFrom.Location = new System.Drawing.Point(117, 4);
			nudKetBanGoiYSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanGoiYSoLuongFrom.Name = "nudKetBanGoiYSoLuongFrom";
			nudKetBanGoiYSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudKetBanGoiYSoLuongFrom.TabIndex = 0;
			nudKetBanGoiYSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label4.Location = new System.Drawing.Point(7, 36);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(100, 16);
			label4.TabIndex = 89;
			label4.Text = "Thơ\u0300i gian delay:";
			nudKetBanGoiYDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanGoiYDelayFrom.Location = new System.Drawing.Point(117, 33);
			nudKetBanGoiYDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanGoiYDelayFrom.Name = "nudKetBanGoiYDelayFrom";
			nudKetBanGoiYDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudKetBanGoiYDelayFrom.TabIndex = 1;
			nudKetBanGoiYDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label5.Location = new System.Drawing.Point(239, 38);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(31, 16);
			label5.TabIndex = 91;
			label5.Text = "giây";
			nudKetBanGoiYDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanGoiYDelayTo.Location = new System.Drawing.Point(194, 34);
			nudKetBanGoiYDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanGoiYDelayTo.Name = "nudKetBanGoiYDelayTo";
			nudKetBanGoiYDelayTo.Size = new System.Drawing.Size(47, 23);
			nudKetBanGoiYDelayTo.TabIndex = 2;
			nudKetBanGoiYDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label6.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label6.Location = new System.Drawing.Point(162, 38);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(29, 16);
			label6.TabIndex = 91;
			label6.Text = "đê\u0301n";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label72.AutoSize = true;
			label72.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label72.Location = new System.Drawing.Point(239, 9);
			label72.Name = "label72";
			label72.Size = new System.Drawing.Size(29, 16);
			label72.TabIndex = 91;
			label72.Text = "ba\u0323n";
			nudKetBanGoiYSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudKetBanGoiYSoLuongTo.Location = new System.Drawing.Point(194, 5);
			nudKetBanGoiYSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudKetBanGoiYSoLuongTo.Name = "nudKetBanGoiYSoLuongTo";
			nudKetBanGoiYSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudKetBanGoiYSoLuongTo.TabIndex = 3;
			nudKetBanGoiYSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			label71.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label71.Location = new System.Drawing.Point(162, 9);
			label71.Name = "label71";
			label71.Size = new System.Drawing.Size(29, 16);
			label71.TabIndex = 91;
			label71.Text = "đê\u0301n";
			label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			ckbKetBanTepUid.AutoSize = true;
			ckbKetBanTepUid.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbKetBanTepUid.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbKetBanTepUid.Location = new System.Drawing.Point(338, 20);
			ckbKetBanTepUid.Name = "ckbKetBanTepUid";
			ckbKetBanTepUid.Size = new System.Drawing.Size(145, 20);
			ckbKetBanTepUid.TabIndex = 4;
			ckbKetBanTepUid.Text = "Kết bạn theo tệp UID";
			ckbKetBanTepUid.UseVisualStyleBackColor = true;
			ckbKetBanTepUid.CheckedChanged += new System.EventHandler(ckbKetBanTepUid_CheckedChanged);
			ckbXacNhanKetBan.AutoSize = true;
			ckbXacNhanKetBan.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbXacNhanKetBan.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbXacNhanKetBan.Location = new System.Drawing.Point(338, 154);
			ckbXacNhanKetBan.Name = "ckbXacNhanKetBan";
			ckbXacNhanKetBan.Size = new System.Drawing.Size(126, 20);
			ckbXacNhanKetBan.TabIndex = 6;
			ckbXacNhanKetBan.Text = "Xác nhận kết bạn";
			ckbXacNhanKetBan.UseVisualStyleBackColor = true;
			ckbXacNhanKetBan.CheckedChanged += new System.EventHandler(ckbXacNhanKetBan_CheckedChanged);
			groupBox7.Controls.Add(ckbThamGiaNhom);
			groupBox7.Controls.Add(plThamGiaNhom);
			groupBox7.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			groupBox7.Location = new System.Drawing.Point(662, 424);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new System.Drawing.Size(344, 243);
			groupBox7.TabIndex = 4;
			groupBox7.TabStop = false;
			groupBox7.Text = "Tham gia nho\u0301m";
			ckbThamGiaNhom.AutoSize = true;
			ckbThamGiaNhom.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbThamGiaNhom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbThamGiaNhom.Location = new System.Drawing.Point(23, 22);
			ckbThamGiaNhom.Name = "ckbThamGiaNhom";
			ckbThamGiaNhom.Size = new System.Drawing.Size(184, 20);
			ckbThamGiaNhom.TabIndex = 0;
			ckbThamGiaNhom.Text = "Tham gia nhóm theo tê\u0323p ID";
			ckbThamGiaNhom.UseVisualStyleBackColor = true;
			ckbThamGiaNhom.CheckedChanged += new System.EventHandler(ckbThamGiaNhom_CheckedChanged);
			plThamGiaNhom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plThamGiaNhom.Controls.Add(ckbThamGiaNhomTrungNhau);
			plThamGiaNhom.Controls.Add(ckbThamGiaNhomTraLoiCauHoi);
			plThamGiaNhom.Controls.Add(label12);
			plThamGiaNhom.Controls.Add(label13);
			plThamGiaNhom.Controls.Add(nudThamGiaNhomSoLuongFrom);
			plThamGiaNhom.Controls.Add(label32);
			plThamGiaNhom.Controls.Add(nudThamGiaNhomDelayFrom);
			plThamGiaNhom.Controls.Add(nudThamGiaNhomSoLuongTo);
			plThamGiaNhom.Controls.Add(nudThamGiaNhomDelayTo);
			plThamGiaNhom.Controls.Add(btnThamGiaNhomTraLoiCauHoi);
			plThamGiaNhom.Controls.Add(label77);
			plThamGiaNhom.Controls.Add(button1);
			plThamGiaNhom.Controls.Add(label63);
			plThamGiaNhom.Controls.Add(label78);
			plThamGiaNhom.Controls.Add(label34);
			plThamGiaNhom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plThamGiaNhom.Location = new System.Drawing.Point(39, 43);
			plThamGiaNhom.Name = "plThamGiaNhom";
			plThamGiaNhom.Size = new System.Drawing.Size(291, 148);
			plThamGiaNhom.TabIndex = 1;
			ckbThamGiaNhomTrungNhau.AutoSize = true;
			ckbThamGiaNhomTrungNhau.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbThamGiaNhomTrungNhau.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbThamGiaNhomTrungNhau.Location = new System.Drawing.Point(10, 92);
			ckbThamGiaNhomTrungNhau.Name = "ckbThamGiaNhomTrungNhau";
			ckbThamGiaNhomTrungNhau.Size = new System.Drawing.Size(237, 20);
			ckbThamGiaNhomTrungNhau.TabIndex = 112;
			ckbThamGiaNhomTrungNhau.Text = "Cho phép tham gia nhóm trùng nhau";
			ckbThamGiaNhomTrungNhau.UseVisualStyleBackColor = true;
			ckbThamGiaNhomTrungNhau.CheckedChanged += new System.EventHandler(ckbThamGiaNhomTraLoiCauHoi_CheckedChanged);
			ckbThamGiaNhomTraLoiCauHoi.AutoSize = true;
			ckbThamGiaNhomTraLoiCauHoi.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbThamGiaNhomTraLoiCauHoi.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			ckbThamGiaNhomTraLoiCauHoi.Location = new System.Drawing.Point(10, 118);
			ckbThamGiaNhomTraLoiCauHoi.Name = "ckbThamGiaNhomTraLoiCauHoi";
			ckbThamGiaNhomTraLoiCauHoi.Size = new System.Drawing.Size(157, 20);
			ckbThamGiaNhomTraLoiCauHoi.TabIndex = 112;
			ckbThamGiaNhomTraLoiCauHoi.Text = "Tư\u0323 đô\u0323ng tra\u0309 lơ\u0300i câu ho\u0309i";
			ckbThamGiaNhomTraLoiCauHoi.UseVisualStyleBackColor = true;
			ckbThamGiaNhomTraLoiCauHoi.CheckedChanged += new System.EventHandler(ckbThamGiaNhomTraLoiCauHoi_CheckedChanged);
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label12.Location = new System.Drawing.Point(10, 7);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(80, 16);
			label12.TabIndex = 89;
			label12.Text = "Nhâ\u0323p tê\u0323p ID:";
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label13.Location = new System.Drawing.Point(10, 35);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(64, 16);
			label13.TabIndex = 89;
			label13.Text = "Sô\u0301 lươ\u0323ng:";
			nudThamGiaNhomSoLuongFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudThamGiaNhomSoLuongFrom.Location = new System.Drawing.Point(127, 33);
			nudThamGiaNhomSoLuongFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudThamGiaNhomSoLuongFrom.Name = "nudThamGiaNhomSoLuongFrom";
			nudThamGiaNhomSoLuongFrom.Size = new System.Drawing.Size(42, 23);
			nudThamGiaNhomSoLuongFrom.TabIndex = 1;
			nudThamGiaNhomSoLuongFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label32.AutoSize = true;
			label32.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label32.Location = new System.Drawing.Point(10, 64);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(100, 16);
			label32.TabIndex = 89;
			label32.Text = "Thơ\u0300i gian delay:";
			nudThamGiaNhomDelayFrom.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudThamGiaNhomDelayFrom.Location = new System.Drawing.Point(127, 62);
			nudThamGiaNhomDelayFrom.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudThamGiaNhomDelayFrom.Name = "nudThamGiaNhomDelayFrom";
			nudThamGiaNhomDelayFrom.Size = new System.Drawing.Size(42, 23);
			nudThamGiaNhomDelayFrom.TabIndex = 2;
			nudThamGiaNhomDelayFrom.Value = new decimal(new int[4] { 5, 0, 0, 0 });
			label78.AutoSize = true;
			label78.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label78.Location = new System.Drawing.Point(250, 37);
			label78.Name = "label78";
			label78.Size = new System.Drawing.Size(40, 16);
			label78.TabIndex = 91;
			label78.Text = "nho\u0301m";
			label34.AutoSize = true;
			label34.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label34.Location = new System.Drawing.Point(250, 65);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(31, 16);
			label34.TabIndex = 91;
			label34.Text = "giây";
			nudThamGiaNhomSoLuongTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudThamGiaNhomSoLuongTo.Location = new System.Drawing.Point(204, 32);
			nudThamGiaNhomSoLuongTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudThamGiaNhomSoLuongTo.Name = "nudThamGiaNhomSoLuongTo";
			nudThamGiaNhomSoLuongTo.Size = new System.Drawing.Size(47, 23);
			nudThamGiaNhomSoLuongTo.TabIndex = 3;
			nudThamGiaNhomSoLuongTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			nudThamGiaNhomDelayTo.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudThamGiaNhomDelayTo.Location = new System.Drawing.Point(204, 62);
			nudThamGiaNhomDelayTo.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudThamGiaNhomDelayTo.Name = "nudThamGiaNhomDelayTo";
			nudThamGiaNhomDelayTo.Size = new System.Drawing.Size(47, 23);
			nudThamGiaNhomDelayTo.TabIndex = 3;
			nudThamGiaNhomDelayTo.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			btnThamGiaNhomTraLoiCauHoi.Cursor = System.Windows.Forms.Cursors.Hand;
			btnThamGiaNhomTraLoiCauHoi.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnThamGiaNhomTraLoiCauHoi.Location = new System.Drawing.Point(170, 114);
			btnThamGiaNhomTraLoiCauHoi.Name = "btnThamGiaNhomTraLoiCauHoi";
			btnThamGiaNhomTraLoiCauHoi.Size = new System.Drawing.Size(103, 27);
			btnThamGiaNhomTraLoiCauHoi.TabIndex = 4;
			btnThamGiaNhomTraLoiCauHoi.Text = "Nhâ\u0323p nô\u0323i dung";
			toolTip1.SetToolTip(btnThamGiaNhomTraLoiCauHoi, "Nhâ\u0323p danh sa\u0301ch nô\u0323i dung câu tra\u0309 lơ\u0300i");
			btnThamGiaNhomTraLoiCauHoi.UseVisualStyleBackColor = true;
			btnThamGiaNhomTraLoiCauHoi.Click += new System.EventHandler(button5_Click);
			label77.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label77.Location = new System.Drawing.Point(172, 37);
			label77.Name = "label77";
			label77.Size = new System.Drawing.Size(29, 16);
			label77.TabIndex = 91;
			label77.Text = "đê\u0301n";
			label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button1.Cursor = System.Windows.Forms.Cursors.Hand;
			button1.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			button1.Location = new System.Drawing.Point(126, 2);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(80, 27);
			button1.TabIndex = 0;
			button1.Text = "Nhâ\u0323p";
			toolTip1.SetToolTip(button1, "Nhâ\u0323p danh sa\u0301ch ID nho\u0301m câ\u0300n tham gia");
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click_1);
			label63.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label63.Location = new System.Drawing.Point(172, 65);
			label63.Name = "label63";
			label63.Size = new System.Drawing.Size(29, 16);
			label63.TabIndex = 91;
			label63.Text = "đê\u0301n";
			label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			toolTip1.AutomaticDelay = 0;
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			toolTip1.ToolTipTitle = "Chú thích";
			bunifuDragControl1.Fixed = true;
			bunifuDragControl1.Horizontal = true;
			bunifuDragControl1.TargetControl = pnlHeader;
			bunifuDragControl1.Vertical = true;
			bunifuDragControl2.Fixed = true;
			bunifuDragControl2.Horizontal = true;
			bunifuDragControl2.TargetControl = bunifuCustomLabel1;
			bunifuDragControl2.Vertical = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1012, 716);
			base.Controls.Add(groupBox5);
			base.Controls.Add(groupBox4);
			base.Controls.Add(groupBox8);
			base.Controls.Add(groupBox7);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnAdd);
			base.Controls.Add(bunifuCards1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "fConfigInteract";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Cấu hình tương tác";
			base.Load += new System.EventHandler(FConfigInteract_Load);
			bunifuCards1.ResumeLayout(false);
			pnlHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			plTuongTacCMSN.ResumeLayout(false);
			plTuongTacCMSN.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacCMSNDelayTo).EndInit();
			plTuongTacNhanTin.ResumeLayout(false);
			plTuongTacNhanTin.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNhanTinSoLuongTo).EndInit();
			plTuongTacChoc.ResumeLayout(false);
			plTuongTacChoc.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacChocSoLuongDelayTo).EndInit();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			plTuongTacFanpage.ResumeLayout(false);
			plTuongTacFanpage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongPageFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongBaiVietFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongPageTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFanpageSoLuongBaiVietTo).EndInit();
			plTuongTacGroup.ResumeLayout(false);
			plTuongTacGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongNhomFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongBaiVietFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongBaiVietTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacGroupSoLuongNhomTo).EndInit();
			plTuongTacFriend.ResumeLayout(false);
			plTuongTacFriend.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBanBeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBaiVietFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBaiVietTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendSoLuongBanBeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacFriendDelayTo).EndInit();
			plTuongTacNewsfeed.ResumeLayout(false);
			plTuongTacNewsfeed.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTuongTacNewsfeedDelayTo).EndInit();
			groupBox8.ResumeLayout(false);
			groupBox8.PerformLayout();
			plKetBanTepUid.ResumeLayout(false);
			plKetBanTepUid.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTepUidSoLuongTo).EndInit();
			plKetBanTuKhoa.ResumeLayout(false);
			plKetBanTuKhoa.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanTuKhoaDelayTo).EndInit();
			plXacNhanKetBan.ResumeLayout(false);
			plXacNhanKetBan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudXacNhanKetBanSoLuongTo).EndInit();
			plKetBanGoiY.ResumeLayout(false);
			plKetBanGoiY.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKetBanGoiYSoLuongTo).EndInit();
			groupBox7.ResumeLayout(false);
			groupBox7.PerformLayout();
			plThamGiaNhom.ResumeLayout(false);
			plThamGiaNhom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomSoLuongFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomDelayFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomSoLuongTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudThamGiaNhomDelayTo).EndInit();
			ResumeLayout(false);
		}
	}
}
