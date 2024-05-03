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
                bdsLichThi.PositionChanged += PositionChange;
            try
            {
                this.SP_LAYLICHTHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.SP_LAYLICHTHITableAdapter.Fill(this.dS_THI.SP_LAYLICHTHI, Program.username);
                if(bdsLichThi.Count<0)
                    btnXemChiTiet.Enabled = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi tải lich thi" + ex.Message);
            }
        }
        private void allowBtnThi(object sender, EventArgs e)
        {
            now = DateTime.Now;
            tspBatDauSau.TimeSpan = deNgayThi.DateTime - now;
            if (tspBatDauSau.TimeSpan <= TimeSpan.Zero)
            {
                btnThi.Enabled = true;
                tspBatDauSau.TimeSpan = TimeSpan.Zero;
                timer.Stop();
            }
        }
        private void PositionChange(object sender, EventArgs e)
        {
            if (bdsLichThi.Count == 0) return;
            if ((int)((DataRowView)bdsLichThi.Current).Row["THOIGIANCONLAI"] == 0) {
                speThoiGianConLai.Value = speThoiLuong.Value; 
                btnThi.Text = "Thi";
            }
            else btnThi.Text = "Tiếp tục";

        }
        private void btnXemChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThi.Enabled = false;
            panelThongTinThi.Visible = true;
            panelThongTinThi.Dock = DockStyle.Right;
            PositionChange(null, null);
            timer.Start();
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
                   Thi thi=null;
                try
                {
                    int ID_CTDK = (int)((DataRowView)bdsLichThi.Current)["ID_CTDK"];
                    if (btnThi.Text.Equals("Thi"))
                        thi = new Thi(ID_CTDK,txtMaMH.Text, (int)speLanThi.Value,(int)speThoiLuong.Value,(int)speThoiLuong.Value);
                    else
                    { 
                        thi = new Thi((int)((DataRowView)bdsLichThi.Current)["IDBD"],txtMaMH.Text,(int)speThoiGianConLai.Value, (int)speThoiLuong.Value);
                    }
                    thi.MdiParent = this.parent;
                    thi.Show();
                    //btnThi.Enabled = false;
                    this.Close();
                }
                catch (Exception ex){
                    MessageBox.Show("Lỗi load đề\n" + ex);
                    if (thi != null)
                    {
                        thi.Close();
                    }
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        public void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //panelThongTinThi.Visible = false;
            //panelThongTinThi.Dock = DockStyle.None;
            try
            {
              //  this.SP_LAYLICHTHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.SP_LAYLICHTHITableAdapter.Fill(this.dS_THI.SP_LAYLICHTHI, Program.username);
                btnThi.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi tải lich thi" + ex.Message);
            }
        }
    }
}
