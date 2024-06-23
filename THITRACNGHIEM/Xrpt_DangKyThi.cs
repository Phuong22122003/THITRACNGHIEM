using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace THITRACNGHIEM
{
    public partial class Xrpt_DangKyThi : DevExpress.XtraReports.UI.XtraReport
    {
        private string tungay, denngay;
        public Xrpt_DangKyThi()
        {
            InitializeComponent();
        }
        public Xrpt_DangKyThi(String tungay,String denngay)
        {
            this.tungay = tungay;
            this.denngay = denngay;
            InitializeComponent();
            lblReportHeader.Text = "DANH SÁCH ĐĂNG KÝ THI TRẮC NGHIỆM TỪ NGÀY "+ tungay+" ĐẾN NGÀY "+denngay;
            this.sqlDataSource1.Connection.ConnectionString = Data.ServerConnectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = new DevExpress.DataAccess.Expression("\'"+tungay+"\'", typeof(string));
            this.sqlDataSource1.Queries[0].Parameters[1].Value = new DevExpress.DataAccess.Expression("\'"+denngay+"\'", typeof(string));
            this.sqlDataSource1.Queries[0].Parameters[2].Value = new DevExpress.DataAccess.Expression("\'"+Data.username+"\'", typeof(string));
            try
            {
                  this.sqlDataSource1.Fill();
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Lỗi tải danh sách đăng ký" + ex.Message);
                throw ex;
            }
        }

    }
}
