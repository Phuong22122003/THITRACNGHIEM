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

namespace THITRACNGHIEM
{
    public partial class formLichThi : Form
    {
        private formMain parent;
        private DateTime now;
        public formLichThi()
        {
            InitializeComponent();
        }
        public formLichThi(formMain parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        private void formLichThi_Load(object sender, EventArgs e)
        {
            panelThongTinThi.Visible = false;
            panelThongTinThi.Dock = DockStyle.None;
            try
            {
                this.SP_LAYLICHTHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.SP_LAYLICHTHITableAdapter.Fill(this.dS_THI.SP_LAYLICHTHI, Program.username);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi tải lich thi" + ex.Message);
            }
        }

        private void allowBtnThi(object sender, EventArgs e)
        {
            now = DateTime.Now;
            tspThoiGianConLai.TimeSpan = deNgayThi.DateTime - now;
            if (tspThoiGianConLai.TimeSpan <= TimeSpan.Zero)
            {
                btnThi.Enabled = true;
                tspThoiGianConLai.TimeSpan = TimeSpan.Zero;
                timer.Stop();
            }
        }

        private void btnXemChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThi.Enabled = false;
            panelThongTinThi.Visible = true;
            panelThongTinThi.Dock = DockStyle.Right;
            timer.Start();
            btnXemChiTiet.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            panelThongTinThi.Visible = false;
            panelThongTinThi.Dock = DockStyle.None;
            timer.Stop();
            btnXemChiTiet.Enabled = true;
        }

        private void btnThi_Click(object sender, EventArgs e)
        {
            Form frm = parent.CheckExist(typeof(Thi));
            if (frm != null)
            {
                MessageBox.Show("Dang thi");
                btnThi.Enabled = false;
            }
            else
            {
                try
                {
                    int ID_CTDK = (int)((DataRowView)bdsLichThi.Current)["ID_CTDK"];
                    Thi thi = new Thi(ID_CTDK,txtMaMH.Text, (int)speLanThi.Value,(int)speThoiLuong.Value);
                    thi.Show();
                    btnThi.Enabled = false;
                }
                catch (Exception ex){
                    MessageBox.Show("Lỗi load đề\n" + ex);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
