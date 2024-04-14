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
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            String tungay = dateEditTuNgay.Text;
            String denngay = dateEditDenNgay.Text;
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
