using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static DevExpress.Utils.Svg.CommonSvgImages;

namespace THITRACNGHIEM
{
    public partial class formMonHoc : Form
    {
        private formMain ParentForm;
        private int vitri;
        private String mamh="";
        public formMonHoc()
        {
            InitializeComponent();
        }

        public formMonHoc(formMain parent)
        {
            this.ParentForm = parent;
            InitializeComponent();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvMonHoc.Columns)
            {
                column.OptionsColumn.ReadOnly = true;
            }
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSMonHoc);

        }

        private void formMonHoc_Load(object sender, EventArgs e)
        {
            DSMonHoc.EnforceConstraints = false;

            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.DSMonHoc.MONHOC);

            this.BODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.BODETableAdapter.Fill(this.DSMonHoc.BODE);

            this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.BANGDIEMTableAdapter.Fill(this.DSMonHoc.BANGDIEM);
         
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DSMonHoc.GIAOVIEN_DANGKY);

            this.cmbCoSo.DataSource = Program.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            this.cmbCoSo.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
                btnGhi.Enabled = btnHieuChinh.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            else
            {
                cmbCoSo.Enabled = false;
                btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            }
            pcMonHoc.Enabled = false;
        }

        private void bANGDIEMBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMH.Position;
            pcMonHoc.Enabled = true;
            bdsMH.AddNew();
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcMonHoc.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMH.CancelEdit();
            if (btnThem.Enabled == false)
            {
                try
                {
                    this.MONHOCTableAdapter.Fill(this.DSMonHoc.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể reload lại dữ liệu \n {ex}", "", MessageBoxButtons.OK);
                }
                bdsMH.Position = vitri;
            }
            gcMonHoc.Enabled = true;
            pcMonHoc.Enabled = false;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mamh = txtMAMH.Text;
            vitri = bdsMH.Position;
            pcMonHoc.Enabled = true;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcMonHoc.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.MONHOCTableAdapter.Fill(this.DSMonHoc.MONHOC);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Không thể reload lại dữ liệu \n {ex}", "", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String mamh = "";
            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn này vì đã tồn tại điểm", "", 
                    MessageBoxButtons.OK);
                return;
            }
            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn này vì đã có câu hỏi", "", 
                    MessageBoxButtons.OK);
                return;
            }
            if (bdsGV_DK.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn này vì giảng viên đã lên lịch thi", "", 
                    MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show
                ("Bạn có thật sự muốn xóa môn học này ??","Xác nhận", 
                MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                try
                {
                    mamh = ((DataRowView)bdsMH[bdsMH.Position])["MAMH"].ToString();
                    bdsMH.RemoveCurrent();
                    this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.MONHOCTableAdapter.Update(this.DSMonHoc.MONHOC);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Lỗi xóa nhân viên, vui lòng thử lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.MONHOCTableAdapter.Fill(DSMonHoc.MONHOC);
                    bdsMH.Position = bdsMH.Find("MAMH", mamh);
                    return;
                }

                if (bdsMH.Count == 0) btnXoa.Enabled = false;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học bị bỏ trống!", "", MessageBoxButtons.OK);
                txtMAMH.Focus();
                return;
            }
            if (txtTENMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học bị bỏ trống!", "", MessageBoxButtons.OK);
                txtTENMH.Focus();
                return;
            }

            if (txtMAMH.Text.Trim() != mamh.Trim())
            {
                try
                {
                    SqlCommand command = new SqlCommand("EXECUTE SP_CheckMaMonHocTonTai @mamh = " + txtMAMH.Text, Program.conn);
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Lấy thông điệp lỗi từ SqlException
                    int errorState = ex.Number;
                    MessageBox.Show($"Mã môn học đã tồn tại! \n{errorState}", "", MessageBoxButtons.OK);
                    return;
                }
            }

            try
            {
                bdsMH.EndEdit();
                bdsMH.ResetCurrentItem();
                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.MONHOCTableAdapter.Update(this.DSMonHoc.MONHOC);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            gcMonHoc.Enabled = true;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }
    }
}
