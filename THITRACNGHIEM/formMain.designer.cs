namespace WindowsFormsApp1
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTaiKhoang = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barListItem1 = new DevExpress.XtraBars.BarListItem();
            this.userName = new DevExpress.XtraBars.BarStaticItem();
            this.group = new DevExpress.XtraBars.BarStaticItem();
            this.btnMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemLichThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuanLyCauHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuanLySinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemDanhSachDk = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuanLyGiangVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuanLyKhoaLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangKyThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnBangDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnChiTietPhieuThi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupMonHoc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupNhanSu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupDangKy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.btnXemLichThiGV = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(85, 84, 85, 84);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnDangNhap,
            this.btnDangXuat,
            this.btnTaoTaiKhoang,
            this.barStaticItem1,
            this.barListItem1,
            this.userName,
            this.group,
            this.btnMonHoc,
            this.btnXemLichThi,
            this.btnQuanLyCauHoi,
            this.btnQuanLySinhVien,
            this.btnXemDanhSachDk,
            this.btnQuanLyGiangVien,
            this.btnQuanLyKhoaLop,
            this.btnDangKyThi,
            this.btnBangDiem,
            this.btnChiTietPhieuThi,
            this.btnXemLichThiGV});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.ribbon.MaxItemId = 22;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 927;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4});
            this.ribbon.Size = new System.Drawing.Size(1114, 193);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Caption = "Đăng nhập";
            this.btnDangNhap.Id = 1;
            this.btnDangNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.ImageOptions.Image")));
            this.btnDangNhap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.ImageOptions.LargeImage")));
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.dangNhapBtn_ItemClick);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 2;
            this.btnDangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.Image")));
            this.btnDangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.LargeImage")));
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.dangXuatBtn_ItemClick);
            // 
            // btnTaoTaiKhoang
            // 
            this.btnTaoTaiKhoang.Caption = "Tạo tài khoản";
            this.btnTaoTaiKhoang.Id = 3;
            this.btnTaoTaiKhoang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoTaiKhoang.ImageOptions.Image")));
            this.btnTaoTaiKhoang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaoTaiKhoang.ImageOptions.LargeImage")));
            this.btnTaoTaiKhoang.Name = "btnTaoTaiKhoang";
            this.btnTaoTaiKhoang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnTaoTaiKhoang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTaiKhoang_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barListItem1
            // 
            this.barListItem1.Caption = "barListItem1";
            this.barListItem1.Id = 8;
            this.barListItem1.Name = "barListItem1";
            // 
            // userName
            // 
            this.userName.Caption = "User Name: ";
            this.userName.Id = 9;
            this.userName.Name = "userName";
            // 
            // group
            // 
            this.group.Caption = "Group: ";
            this.group.Id = 10;
            this.group.Name = "group";
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Caption = "Quản lí môn học";
            this.btnMonHoc.Id = 11;
            this.btnMonHoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMonHoc.ImageOptions.Image")));
            this.btnMonHoc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMonHoc.ImageOptions.LargeImage")));
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonHoc_ItemClick);
            // 
            // btnXemLichThi
            // 
            this.btnXemLichThi.Caption = "Xem lịch thi";
            this.btnXemLichThi.Id = 12;
            this.btnXemLichThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemLichThi.ImageOptions.Image")));
            this.btnXemLichThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXemLichThi.ImageOptions.LargeImage")));
            this.btnXemLichThi.Name = "btnXemLichThi";
            this.btnXemLichThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemLichThi_ItemClick);
            // 
            // btnQuanLyCauHoi
            // 
            this.btnQuanLyCauHoi.Caption = "Quản lý câu hỏi";
            this.btnQuanLyCauHoi.Id = 13;
            this.btnQuanLyCauHoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyCauHoi.ImageOptions.Image")));
            this.btnQuanLyCauHoi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuanLyCauHoi.ImageOptions.LargeImage")));
            this.btnQuanLyCauHoi.Name = "btnQuanLyCauHoi";
            this.btnQuanLyCauHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuanLyCauHoi_ItemClick);
            // 
            // btnQuanLySinhVien
            // 
            this.btnQuanLySinhVien.Caption = "Quản lý sinh viên";
            this.btnQuanLySinhVien.Id = 14;
            this.btnQuanLySinhVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLySinhVien.ImageOptions.Image")));
            this.btnQuanLySinhVien.Name = "btnQuanLySinhVien";
            this.btnQuanLySinhVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQuanLySinhVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuanLySinhVien_ItemClick);
            // 
            // btnXemDanhSachDk
            // 
            this.btnXemDanhSachDk.Caption = "Xem danh sách đăng ký";
            this.btnXemDanhSachDk.Id = 15;
            this.btnXemDanhSachDk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemDanhSachDk.ImageOptions.Image")));
            this.btnXemDanhSachDk.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXemDanhSachDk.ImageOptions.LargeImage")));
            this.btnXemDanhSachDk.Name = "btnXemDanhSachDk";
            this.btnXemDanhSachDk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemDanhSachDk_ItemClick);
            // 
            // btnQuanLyGiangVien
            // 
            this.btnQuanLyGiangVien.Caption = "Quản lý giáo viên";
            this.btnQuanLyGiangVien.Id = 16;
            this.btnQuanLyGiangVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyGiangVien.ImageOptions.Image")));
            this.btnQuanLyGiangVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuanLyGiangVien.ImageOptions.LargeImage")));
            this.btnQuanLyGiangVien.Name = "btnQuanLyGiangVien";
            this.btnQuanLyGiangVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnQuanLyGiangVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuanLyGiangVien_ItemClick);
            // 
            // btnQuanLyKhoaLop
            // 
            this.btnQuanLyKhoaLop.Caption = "Quản lý khoa lớp";
            this.btnQuanLyKhoaLop.Id = 17;
            this.btnQuanLyKhoaLop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyKhoaLop.ImageOptions.Image")));
            this.btnQuanLyKhoaLop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuanLyKhoaLop.ImageOptions.LargeImage")));
            this.btnQuanLyKhoaLop.Name = "btnQuanLyKhoaLop";
            this.btnQuanLyKhoaLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuanLyKhoaLop_ItemClick);
            // 
            // btnDangKyThi
            // 
            this.btnDangKyThi.Caption = "Đăng ký thi";
            this.btnDangKyThi.Id = 18;
            this.btnDangKyThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangKyThi.ImageOptions.Image")));
            this.btnDangKyThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangKyThi.ImageOptions.LargeImage")));
            this.btnDangKyThi.Name = "btnDangKyThi";
            this.btnDangKyThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangKyThi_ItemClick);
            // 
            // btnBangDiem
            // 
            this.btnBangDiem.Caption = "Bảng điểm theo môn";
            this.btnBangDiem.Id = 19;
            this.btnBangDiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBangDiem.ImageOptions.Image")));
            this.btnBangDiem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBangDiem.ImageOptions.LargeImage")));
            this.btnBangDiem.Name = "btnBangDiem";
            this.btnBangDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBangDiem_ItemClick);
            // 
            // btnChiTietPhieuThi
            // 
            this.btnChiTietPhieuThi.Caption = "Chi tiết phiếu thi";
            this.btnChiTietPhieuThi.Id = 20;
            this.btnChiTietPhieuThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTietPhieuThi.ImageOptions.Image")));
            this.btnChiTietPhieuThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChiTietPhieuThi.ImageOptions.LargeImage")));
            this.btnChiTietPhieuThi.Name = "btnChiTietPhieuThi";
            this.btnChiTietPhieuThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChiTietPhieuThi_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Đăng nhập";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDangNhap);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTaoTaiKhoang);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDangXuat);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupMonHoc,
            this.ribbonPageGroupNhanSu,
            this.ribbonPageGroupDangKy});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Nghiệp vụ";
            // 
            // ribbonPageGroupMonHoc
            // 
            this.ribbonPageGroupMonHoc.ItemLinks.Add(this.btnMonHoc);
            this.ribbonPageGroupMonHoc.ItemLinks.Add(this.btnQuanLyCauHoi);
            this.ribbonPageGroupMonHoc.Name = "ribbonPageGroupMonHoc";
            this.ribbonPageGroupMonHoc.Text = "Môn học";
            // 
            // ribbonPageGroupNhanSu
            // 
            this.ribbonPageGroupNhanSu.ItemLinks.Add(this.btnQuanLySinhVien);
            this.ribbonPageGroupNhanSu.ItemLinks.Add(this.btnQuanLyGiangVien);
            this.ribbonPageGroupNhanSu.ItemLinks.Add(this.btnQuanLyKhoaLop);
            this.ribbonPageGroupNhanSu.Name = "ribbonPageGroupNhanSu";
            this.ribbonPageGroupNhanSu.Text = "Nhân sự";
            // 
            // ribbonPageGroupDangKy
            // 
            this.ribbonPageGroupDangKy.ItemLinks.Add(this.btnDangKyThi);
            this.ribbonPageGroupDangKy.Name = "ribbonPageGroupDangKy";
            this.ribbonPageGroupDangKy.Text = "Đăng ký";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Báo cáo";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnXemDanhSachDk);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnBangDiem);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChiTietPhieuThi);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Báo cáo";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Thi";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnXemLichThi);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnXemLichThiGV);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Lịch thi";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.userName);
            this.ribbonStatusBar.ItemLinks.Add(this.group);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 732);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(6);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1114, 30);
            // 
            // btnXemLichThiGV
            // 
            this.btnXemLichThiGV.Caption = "Xem lich thi cho giảng viên";
            this.btnXemLichThiGV.Id = 21;
            this.btnXemLichThiGV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btnXemLichThiGV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.btnXemLichThiGV.Name = "btnXemLichThiGV";
            this.btnXemLichThiGV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemLichThiGV_ItemClick);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 762);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "formMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Thi trắc nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnDangNhap;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.BarButtonItem btnTaoTaiKhoang;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.BarStaticItem userName;
        private DevExpress.XtraBars.BarStaticItem group;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupMonHoc;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnMonHoc;
        private DevExpress.XtraBars.BarButtonItem btnXemLichThi;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyCauHoi;
        private DevExpress.XtraBars.BarButtonItem btnQuanLySinhVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupNhanSu;
        private DevExpress.XtraBars.BarButtonItem btnXemDanhSachDk;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyGiangVien;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyKhoaLop;
        private DevExpress.XtraBars.BarButtonItem btnDangKyThi;
        private DevExpress.XtraBars.BarButtonItem btnBangDiem;
        private DevExpress.XtraBars.BarButtonItem btnChiTietPhieuThi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupDangKy;
        private DevExpress.XtraBars.BarButtonItem btnXemLichThiGV;
    }
}