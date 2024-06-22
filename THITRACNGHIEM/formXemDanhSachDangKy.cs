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

namespace THITRACNGHIEM
{
    public partial class formXemDanhSachDangKy : Form
    {
        public formXemDanhSachDangKy()
        {
            InitializeComponent();
            lblErrorTuNgay.Visible = lblErrorDenNgay.Visible = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            lblErrorTuNgay.Visible = lblErrorDenNgay.Visible = false;
            String tungay = dateEditTuNgay.Text;
            String denngay = dateEditDenNgay.Text;
            if (tungay.Length == 0)
            {
                lblErrorTuNgay.Text = "Vui lòng nhập ngày bắt đầu";
                lblErrorTuNgay.Visible = true;
            }
            if (denngay.Length == 0)
            {
                 lblErrorDenNgay.Text = "Vui lòng nhập ngày đến";
                lblErrorDenNgay.Visible = true;
            }
            if( denngay.Length != 0&&tungay.Length!=0)
            if(dateEditDenNgay.DateTime < dateEditTuNgay.DateTime)
            {
                lblErrorTuNgay.Text = "Ngày bắt đầu không thể lớn hơn ngày kết thúc";
                lblErrorTuNgay.Visible = true;
            }
            if(lblErrorTuNgay.Visible == true|| lblErrorDenNgay.Visible == true)
            {
                return;
            }
            try
            {
            Xrpt_DangKyThi danhSachDangKyThi = new Xrpt_DangKyThi(tungay,denngay);
            ReportPrintTool print = new ReportPrintTool(danhSachDangKyThi);
            print.ShowPreviewDialog();
            }
            catch (Exception ex) {
                MessageBox.Show("Lỗi tải danh sách đăng ký" + ex.Message);

            }
        }
    }
}
