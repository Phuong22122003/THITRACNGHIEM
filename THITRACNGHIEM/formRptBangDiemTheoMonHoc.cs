using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;


namespace THITRACNGHIEM
{
    public partial class formRptBangDiemTheoMonHoc : Form
    {
        public formRptBangDiemTheoMonHoc()
        {
            InitializeComponent();
        }


        private void formRptBangDiemTheoMonHoc_Load(object sender, EventArgs e)
        {

            this.dSBangDiemTheoMon.EnforceConstraints = false;

            this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.MONHOCTableAdapter.Fill(this.dSBangDiemTheoMon.MONHOC);

            this.LOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.LOPTableAdapter.Fill(this.dSBangDiemTheoMon.LOP);
            this.cmbCoSo.DataSource = Data.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            this.cmbCoSo.SelectedIndex = Data.mCoSo;

            if (Data.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
            }
            else
            {
                cmbCoSo.Enabled = false;
            }
            cmbLanThi.SelectedIndex = 0;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            xrtp_PhieuBangDiemTheoMon rpt = new xrtp_PhieuBangDiemTheoMon(cmbMH.SelectedValue.ToString(), cmbLop.SelectedValue.ToString(), int.Parse(cmbLanThi.Text));
            rpt.header.Text = "BẢNG ĐIỂM MÔN HỌC " + cmbMH.Text +
                " LẦN THỨ " + cmbLanThi.Text + " CỦA LỚP " + cmbLop.Text;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCoSo.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Data.servername = cmbCoSo.SelectedValue.ToString();
            if (cmbCoSo.SelectedIndex != Data.mCoSo)
            {
                Data.mlogin = Data.remotelogin;
                Data.password = Data.remotepassword;
            }
            else
            {
                Data.mlogin = Data.mloginDN;
                Data.password = Data.passwordDN;
            }
            if (Data.ConnectToServerWhenLogin(false) == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.MONHOCTableAdapter.Fill(this.dSBangDiemTheoMon.MONHOC);

                this.LOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.LOPTableAdapter.Fill(this.dSBangDiemTheoMon.LOP);
            }
        }
    }
}
