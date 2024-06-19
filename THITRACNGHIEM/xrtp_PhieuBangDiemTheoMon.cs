using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using WindowsFormsApp1;

namespace THITRACNGHIEM
{
    public partial class xrtp_PhieuBangDiemTheoMon : DevExpress.XtraReports.UI.XtraReport
    {
        public xrtp_PhieuBangDiemTheoMon()
        {
            InitializeComponent();
        }

        public xrtp_PhieuBangDiemTheoMon(string mamh, string malop, int lanthi)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Data.ServerConnectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = mamh;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = malop;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = lanthi;
            try
            {
            this.sqlDataSource1.Fill();
            }
            catch (Exception ex) 
            {
                throw ex;
            }


        }

    }
}
