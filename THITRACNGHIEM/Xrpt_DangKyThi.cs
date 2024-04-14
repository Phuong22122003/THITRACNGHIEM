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
            //this.tableCell2.ExpressionBindings.Clear();
            //this.tableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            //new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", ("\'Danh sách đăng ký thi trắc nghiệm  \' +[TENCS]"+"từ ngay"+tungay + " đến ngày "+denngay).ToUpper())});
            //this.tableCell2.Name = "tableCell2";
            //this.tableCell2.StyleName = "GroupData1";
            //this.tableCell2.Weight = 0.3903704596435047D;
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = new DevExpress.DataAccess.Expression("\'"+tungay+"\'", typeof(string));
            this.sqlDataSource1.Queries[0].Parameters[1].Value = new DevExpress.DataAccess.Expression("\'"+denngay+"\'", typeof(string));
            this.sqlDataSource1.Queries[0].Parameters[2].Value = new DevExpress.DataAccess.Expression("\'"+Program.username+"\'", typeof(string));
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
