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
 
        }

        private void dangXuatBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            clearInfo();
            Program.conn.Close();
            this.Close();
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
        public void showInfo(String loginName="",String group="")
        {
            if (group == "COSO" || group == "TRUONG")
                this.userName.Caption = "UserName: " + loginName;
            else this.userName.Caption = "Họ và tên: " + loginName;
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
            if (frm != null) frm.Activate();
            else
            {
                try
                {
                     formLichThi f = new formLichThi(this);

                    f.MdiParent = this;
                    f.Show();

                }
                catch(Exception ex)
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
    }
}