using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THITRACNGHIEM;

namespace WindowsFormsApp1
{
    public partial class formMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public formMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            disableAll();
        }

        public void disableAll()
        {
            btnTaoTaiKhoang.Visibility = BarItemVisibility.Never;
            btnTaoTaiKhoang.Enabled = false;

            ribbonPage2.Visible = false;
            ribbonPage3.Visible = false;
            ribbonPage4.Visible = false;
        }
        public void GiaoDienSinhVien()
        {
            ribbonPage3.Visible = true;

            btnChiTietPhieuThi.Visibility = BarItemVisibility.Always;
            btnBangDiem.Visibility = BarItemVisibility.Never;
            btnXemDanhSachDk.Visibility = BarItemVisibility.Never;

            ribbonPage4.Visible = true;
            btnXemLichThi.Visibility = BarItemVisibility.Always;
            btnXemLichThi.Enabled = true;
            btnXemLichThiGV.Visibility = BarItemVisibility.Never;
            btnXemLichThiGV.Enabled = false;
        }
        public void GiaoDienGiangVien()
        {
            ribbonPage2.Visible = true;

            ribbonPageGroupNhanSu.Visible = false;
            ribbonPageGroupNhanSu.Enabled = false;

            ribbonPageGroupDangKy.Visible = false;
            ribbonPageGroupDangKy.Enabled = false;

            btnMonHoc.Visibility = BarItemVisibility.Never;
            btnMonHoc.Enabled = false;

            ribbonPage3.Visible = true;

            btnXemDanhSachDk.Visibility = BarItemVisibility.Never;
            btnXemDanhSachDk.Enabled = false;
            ribbonPage4.Visible = true;
            btnXemLichThi.Visibility = BarItemVisibility.Never;
            btnXemLichThi.Enabled = false;
            btnXemLichThiGV.Visibility = BarItemVisibility.Always;
            btnXemLichThiGV.Enabled = true;

        }

        public void GiaoDienTruong()
        {
            btnTaoTaiKhoang.Visibility = BarItemVisibility.Always;
            btnTaoTaiKhoang.Enabled = true;
            ribbonPage2.Visible = true;

            ribbonPageGroupDangKy.Visible=false;
            ribbonPageGroupDangKy.Enabled=false;

            ribbonPageGroupMonHoc.Visible = true;
            ribbonPageGroupMonHoc.Enabled = true;

            btnQuanLyCauHoi.Visibility = BarItemVisibility.Always;
            btnQuanLyCauHoi.Enabled = true;

            ribbonPageGroupNhanSu.Visible = true;
            ribbonPageGroupNhanSu.Enabled = true;

            btnQuanLySinhVien.Visibility = BarItemVisibility.Always;
            btnQuanLySinhVien.Enabled = true;

            btnQuanLyKhoaLop.Visibility = BarItemVisibility.Always;
            btnQuanLyKhoaLop.Enabled = true;

            btnQuanLyGiangVien.Visibility = BarItemVisibility.Always;
            btnQuanLyGiangVien.Enabled = true;

            btnDangKyThi.Visibility = BarItemVisibility.Never;
            btnDangKyThi.Enabled = false;

            ribbonPage3.Visible = true;
        }
        public void GiaoDienCoSo()
        {
            btnTaoTaiKhoang.Visibility = BarItemVisibility.Always;
            btnTaoTaiKhoang.Enabled = true;

            ribbonPage2.Visible = true;

            ribbonPageGroupDangKy.Visible = false;
            ribbonPageGroupDangKy.Enabled = false;

            ribbonPageGroupMonHoc.Visible = true;
            ribbonPageGroupMonHoc.Enabled = true;

            btnQuanLyCauHoi.Visibility = BarItemVisibility.Always;
            btnQuanLyCauHoi.Enabled = true;

            ribbonPageGroupNhanSu.Visible = true;
            ribbonPageGroupNhanSu.Enabled = true;

            btnQuanLySinhVien.Visibility = BarItemVisibility.Always;
            btnQuanLySinhVien.Enabled = true;

            btnQuanLyKhoaLop.Visibility = BarItemVisibility.Always;
            btnQuanLyKhoaLop.Enabled = true;

            btnQuanLyGiangVien.Visibility = BarItemVisibility.Always;
            btnQuanLyGiangVien.Enabled = true;

            ribbonPageGroupDangKy.Visible = true;
            ribbonPageGroupDangKy.Enabled = true;

            btnDangKyThi.Visibility = BarItemVisibility.Always;
            btnDangKyThi.Enabled = true;

            ribbonPage3.Visible = true;
        }
        private void dangXuatBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(formDangNhap)) { 
                ((formDangNhap) f).clear();
                    ((formDangNhap)f).enableBtnDangNhap();
                }
               else f.Close();
            }
            Data.clear();
            clearInfo();
            disableAll();
        }

        public Form CheckExist(Type type)
        {
            foreach(Form f in this.MdiChildren ) {
            if(f.GetType() == type) 
                return f;        
            }
            return null;
        }
        private void dangNhapBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formDangNhap));
            if(frm != null) frm.Activate();
            else
            {
                formDangNhap f = new formDangNhap(this);
               
                f.MdiParent = this;
                f.Show();
            }
        }
        public void showInfo(String hoVaTen="",String group="")
        {

            if (group.Trim().ToUpper().Equals("TRUONG"))
            {
                group = "TRƯỜNG";
                GiaoDienTruong();
            }

            if (group.Trim().ToUpper().Equals("COSO"))
            {
                group = "CƠ SỞ";
                GiaoDienCoSo();
            }
            if (group.Trim().ToUpper().Equals("GIANGVIEN"))
            {
                group = "GIẢNG VIÊN";
                GiaoDienGiangVien();
            }    
            if (group.Trim().ToUpper().Equals("SINHVIEN"))
            {
                group = "SINHVIEN";
                GiaoDienSinhVien();
            }    
            this.userName.Caption = "Họ và tên: " + hoVaTen;
            this.group.Caption = "Nhóm: " + group;
        }
        public void clearInfo()
        {
            this.userName.Caption = "";
            this.group.Caption= "";
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            btnDangNhap.PerformClick();
        }

        private void btnMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                formMonHoc f = new formMonHoc(this);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnXemLichThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formLichThi));
            if (frm != null) {
                frm.Activate();
                formLichThi current = (formLichThi) frm;
                current.btnReloadClick(null, null);
                
            }
            else
            {
                try
                {
                    formLichThi f = new formLichThi(this);

                    f.MdiParent = this;
                    f.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải lịch thi" + ex.Message);
                }
            }
        }

        private void btnQuanLyCauHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formBoDe));
            if (frm != null) frm.Activate();
            else
            {
                try
                {
                    formBoDe f = new formBoDe();

                    f.MdiParent = this;
                    f.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải bộ đề" + ex.Message);
                }
            }
        }

        private void btnQuanLySinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(frmSinhVien));
            if (frm != null) frm.Activate();
            else
            {
                try
                {
                    frmSinhVien f = new frmSinhVien();

                    f.MdiParent = this;
                    f.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách sinh viên" + ex.Message);
                }
            }
        }

        private void btnXemDanhSachDk_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formXemDanhSachDangKy));
            if (frm != null) frm.Activate();
            else
            {
                formXemDanhSachDangKy f = new formXemDanhSachDangKy();

                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTaoTaiKhoang_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Có lỗi thì không mở form nữa
            Form frm = this.CheckExist(typeof(formTaoTK));
            if (frm != null) frm.Activate();
            else
            {
                try
                {
                    formTaoTK f = new formTaoTK();

                    f.MdiParent = this;
                    f.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message);
                }
            }
        }

        private void btnQuanLyGiangVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formNhapGiaoVien));
            if (frm != null) frm.Activate();
            else
            {
                formNhapGiaoVien f = new formNhapGiaoVien(this);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQuanLyKhoaLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formNhapKhoaLop));
            if (frm != null) frm.Activate();
            else
            {
                formNhapKhoaLop f = new formNhapKhoaLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangKyThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formChuanBiThi));
            if (frm != null) frm.Activate();
            else
            {
                formChuanBiThi f = new formChuanBiThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBangDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formRptBangDiemTheoMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                formRptBangDiemTheoMonHoc f = new formRptBangDiemTheoMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnChiTietPhieuThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formRptChiTietBaiThi));
            if (frm != null) frm.Activate();
            else
            {
                formRptChiTietBaiThi f = new formRptChiTietBaiThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnXemLichThiGV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExist(typeof(formXemLichChoGV));
            if (frm != null)
            {
                frm.Activate();
                formXemLichChoGV current = (formXemLichChoGV)frm;
               // current.btnReloadClick(null, null);

            }
            else
            {
                try
                {
                    formXemLichChoGV f = new formXemLichChoGV();

                    f.MdiParent = this;
                    f.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải lịch thi" + ex.Message);
                }
            }
        }
    }
}