using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using WindowsFormsApp1;

namespace THITRACNGHIEM
{
    public partial class xrpt_ChiTietBaiThi : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_ChiTietBaiThi()
        {
            InitializeComponent();
        }

        public xrpt_ChiTietBaiThi(String masv, String mamh, int lanthi)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Data.ServerConnectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = masv;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = mamh;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lanthi;
            this.sqlDataSource1.Fill();
        }
    }
}
