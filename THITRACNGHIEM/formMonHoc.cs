using DevExpress.ChartRangeControlClient.Core;
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
        private TrangThaiGhi trangThaiGhi;

        //Lưu giá trị cũ trước khi edit để thực hiện việc hồi phục
        private object[] oldRowItemArray;

        private UndoManager undoManager;
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

        private void formMonHoc_Load(object sender, EventArgs e)
        {
            DSMonHoc.EnforceConstraints = false;

            this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.MONHOCTableAdapter.Fill(this.DSMonHoc.MONHOC);

            this.BODETableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.BODETableAdapter.Fill(this.DSMonHoc.BODE);

            this.BANGDIEMTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.BANGDIEMTableAdapter.Fill(this.DSMonHoc.BANGDIEM);
         
            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.DSMonHoc.GIAOVIEN_DANGKY);

   

            
            if (Data.mGroup == "TRUONG")
            {
            
                btnGhi.Enabled = btnHieuChinh.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            else
            {
           
                btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            }
            pcMonHoc.Enabled = false;

            undoManager = new UndoManager(this.bdsMH);
        }

        private void bANGDIEMBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMAMH.Enabled = true;
            vitri = bdsMH.Position;
            pcMonHoc.Enabled = true;
            bdsMH.AddNew();
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcMonHoc.Enabled = false;
            trangThaiGhi = TrangThaiGhi.them;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (pcMonHoc.Enabled == true)
            {
                try
                {
                    bdsMH.CancelEdit();
                    this.MONHOCTableAdapter.Fill(this.DSMonHoc.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể reload lại dữ liệu \n {ex}", "", MessageBoxButtons.OK);
                }
                bdsMH.Position = vitri;
            } else
            {
                if (undoManager.Undo() == 0)
                {
                    MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    MONHOCTableAdapter.Update(DSMonHoc.MONHOC);
                }
            }
            gcMonHoc.Enabled = true;
            pcMonHoc.Enabled = false;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
            else btnPhucHoi.Enabled = true;
            if (undoManager.GetReUndoStack().Count <= 0) btnTaiPhucHoi.Enabled = false;
            else btnTaiPhucHoi.Enabled = true;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMAMH.Enabled = false;
            DataRowView oldRow = (DataRowView)bdsMH.Current;
            oldRowItemArray = oldRow.Row.ItemArray;
            vitri = bdsMH.Position;
            pcMonHoc.Enabled = true;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcMonHoc.Enabled = false;
            trangThaiGhi = TrangThaiGhi.hieuchinh;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.MONHOCTableAdapter.Fill(this.DSMonHoc.MONHOC);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể reload lại dữ liệu \n {ex}", "", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                    DataRowView deletedRow = (DataRowView)bdsMH.Current;
                    object[] deletedRowArrayItem  = deletedRow.Row.ItemArray;
                    undoManager.DeleteRecord(deletedRowArrayItem);
                    if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
                    else btnPhucHoi.Enabled = true;
                    undoManager.ClearReUndoStack();
                    btnTaiPhucHoi.Enabled =false;
                    bdsMH.RemoveCurrent();
                    this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
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

            for (int i = 0; i < gvMonHoc.RowCount; i++)
            {
                if (i != gvMonHoc.FocusedRowHandle)
                {
                    string current = (String)gvMonHoc.GetRowCellValue(i, "TENMH");
                    if (current.Trim().Equals(txtTENMH.Text.Trim(), StringComparison.OrdinalIgnoreCase)) {
                        MessageBox.Show("Tên môn học bị trùng!", "", MessageBoxButtons.OK);
                        txtTENMH.Focus();
                        return;
                    }
                }
            }

            if (trangThaiGhi == TrangThaiGhi.them)
            {
                if(Data.ExecSqlNonQueryByServerConnection($"EXECUTE SP_CheckMaMonHocTonTai @mamh = '{txtMAMH.Text}'") != 0)
                {
                    return;
                }
            }

            try
            {
                bdsMH.EndEdit();
                bdsMH.ResetCurrentItem();
                DataRowView addedRow = (DataRowView)bdsMH.Current;
                object[] addedRowArrayItem = addedRow.Row.ItemArray;
                this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.MONHOCTableAdapter.Update(this.DSMonHoc.MONHOC);
                if (trangThaiGhi == TrangThaiGhi.them)
                {
                    undoManager.AddNewRecord(addedRowArrayItem);
                }
                else
                {
                    undoManager.EditRecord(oldRowItemArray, addedRowArrayItem);
                }
                if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
                else btnPhucHoi.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            undoManager.ClearReUndoStack();
            btnTaiPhucHoi.Enabled = false;
            gcMonHoc.Enabled = true;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = pcMonHoc.Enabled = false;
        }

     
        private void undoBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undoManager.GetUndoStack().Count <= 0)
            {
                MessageBox.Show("Không còn gì để undo", "", MessageBoxButtons.OK);
                return; 
            }
            if(undoManager.Undo() == 0)
            {
                MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                MONHOCTableAdapter.Update(DSMonHoc.MONHOC);

            }
            
        }

        private void ReUnDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undoManager.ReUndo() == 0)
            {
                MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                MONHOCTableAdapter.Update(DSMonHoc.MONHOC);
            }
            if (undoManager.GetReUndoStack().Count <= 0) btnTaiPhucHoi.Enabled = false;
            else btnTaiPhucHoi.Enabled = true;
            if (undoManager.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
            else btnPhucHoi.Enabled = true;
        }
    }
}
