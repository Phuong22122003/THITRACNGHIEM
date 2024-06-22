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
    public partial class formXemLichChoGV : Form
    {
        public formXemLichChoGV()
        {
            InitializeComponent();
            panelThongTinThi.Visible = false;
            panelThongTinThi.Dock = DockStyle.None;
            try
            {
                this.sP_LAYLICHTHI_GVTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.sP_LAYLICHTHI_GVTableAdapter.Fill(this.dS_THI.SP_LAYLICHTHI_GV, Data.username);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnXemChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelThongTinThi.Visible = true;
            panelThongTinThi.Dock = DockStyle.Right;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            panelThongTinThi.Visible = false;
            panelThongTinThi.Dock = DockStyle.None;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.sP_LAYLICHTHI_GVTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.sP_LAYLICHTHI_GVTableAdapter.Fill(this.dS_THI.SP_LAYLICHTHI_GV, Data.username);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnThoatForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThi_Click(object sender, EventArgs e)
        {
            Form frm = Data.formChinh.CheckExist(typeof(Thi));
            if (frm != null)
            {
                MessageBox.Show("Dang thi");
                btnThi.Enabled = false;
            }
            else
            {
                Thi thi = null;
                try
                {
                    int ID_CTDK = (int)((DataRowView)bdsLichThi.Current)["ID_CTDK"];

                    thi = new Thi(ID_CTDK, (int)speThoiLuong.Value);
                    thi.setLanThi((int)speLanThi.Value);
                    thi.setTenMon(txtTenMh.Text);
                    thi.MdiParent = Data.formChinh;
                    thi.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load đề\n" + ex);
                    if (thi != null)
                    {
                        thi.Close();
                    }
                }
            }
        }
    }
}
