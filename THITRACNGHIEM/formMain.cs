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
            this.Close();
        }

        private Form CheckExist(Type type)
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
            Program.mGroup = group;
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

    }
}