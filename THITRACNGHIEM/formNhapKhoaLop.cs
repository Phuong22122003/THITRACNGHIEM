using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
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

namespace THITRACNGHIEM
{
    public partial class formNhapKhoaLop : Form
    {
        private int vitri = 0;
        private int vitriLop = 0;
        private String makhoa = "";
        private String malop = "";
        //private String tenlop = "";
        //private List<String> malopArr = new List<String>();
        //private List<String> tenlopArr = new List<String>();
        private UndoManager undoManagerKhoa;
        private UndoManager undoManagerLop;
        private bool isUndoOrReundo = false;
        private bool clickPhucHoi = false;
        private TrangThaiGhi trangThaiGhiKhoa;
        private TrangThaiGhi trangThaiGhiLop;
        private object[] oldRowItemArrayKhoa;
        private object[] oldRowItemArrayLop;
        public formNhapKhoaLop()
        {
            InitializeComponent();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvKHOA.Columns)
            {
                column.OptionsColumn.AllowEdit = false;
            }
            //foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvLOP.Columns)
            //{
            //    column.OptionsColumn.AllowEdit = false;
            //}
            this.ContextMenuStrip = contextMenuStrip1;

            
        }
       
        private void formNhapKhoaLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSKhoaLop.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.GV_DKTableAdapter.Fill(this.DSKhoaLop.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'DSKhoaLop.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.GV_DKTableAdapter.Fill(this.DSKhoaLop.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'DSKhoaLop.SINHVIEN' table. You can move, or remove it, as needed.



            DSKhoaLop.EnforceConstraints = false;

            this.KHOATableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.KHOATableAdapter.Fill(this.DSKhoaLop.KHOA);
            this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.lOPTableAdapter.Fill(this.DSKhoaLop.LOP);
            this.SINHVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.SINHVIENTableAdapter.Fill(this.DSKhoaLop.SINHVIEN);
            this.SINHVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GV_DKTableAdapter.Fill(this.DSKhoaLop.GIAOVIEN_DANGKY);


            this.cmbCoSo.DataSource = Data.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            this.cmbCoSo.SelectedIndex = Data.mCoSo;

            if (Data.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
                btnGhi.Enabled = btnHieuChinh.Enabled = btnPhucHoi.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            else
            {
                cmbCoSo.Enabled = false;
                btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            }

            if (bdsLOP.Count == 0) xóaToolStripMenuItem.Enabled = false;
            undoManagerKhoa = new UndoManager(this.bdsKHOA);
            undoManagerLop = new UndoManager(this.bdsLOP);
        }

   

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            contextMenuStrip1.Enabled = false;
            txtMAKHOA.Enabled = true;
            vitri = bdsKHOA.Position;
            pcKHOA.Enabled = true;
            bdsKHOA.AddNew();
            if (Data.mCoSo == 0) txtMACS.Text = "CS1";
            else txtMACS.Text = "CS2";
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcKHOA.Enabled = false;
            trangThaiGhiKhoa = TrangThaiGhi.them;
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMAKHOA.Enabled = false;
            makhoa = txtMAKHOA.Text;
            vitri = bdsKHOA.Position;
            pcKHOA.Enabled = true;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcKHOA.Enabled = false;
            contextMenuStrip1.Enabled = false;
            trangThaiGhiKhoa = TrangThaiGhi.hieuchinh;
            DataRowView oldRow = (DataRowView)bdsKHOA.Current;
            oldRowItemArrayKhoa = oldRow.Row.ItemArray;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAKHOA.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học bị bỏ trống!", "", MessageBoxButtons.OK);
                txtMAKHOA.Focus();
                return;
            }
            if (txtTENKHOA.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học bị bỏ trống!", "", MessageBoxButtons.OK);
                txtTENKHOA.Focus();
                return;
            }

            if (txtMAKHOA.Text.Trim() != makhoa.Trim())
            {
                try
                {
                    SqlCommand Sqlcmd = new SqlCommand("EXECUTE SP_CheckMaKhoaTonTai @makhoa = " + txtMAKHOA.Text, Data.ServerConnection);
                    Sqlcmd.CommandType = CommandType.Text;
                    Sqlcmd.CommandTimeout = 600;// 10 phut 
                    if (Data.ServerConnection.State == ConnectionState.Closed) Data.ServerConnection.Open();
                    Sqlcmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Lấy thông điệp lỗi từ SqlException
                    String errorMessage = ex.Message;
                    MessageBox.Show(errorMessage, "", MessageBoxButtons.OK);
                    return;
                }
                finally
                {
                    Data.ServerConnection.Close();
                }
            }

            try
            {
                bdsKHOA.EndEdit();
                bdsKHOA.ResetCurrentItem();
                DataRowView addedRow = (DataRowView)bdsKHOA.Current;
                object[] addedRowArrayItem = addedRow.Row.ItemArray;
                this.KHOATableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.KHOATableAdapter.Update(this.DSKhoaLop.KHOA);
                this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.lOPTableAdapter.Fill(this.DSKhoaLop.LOP);
                if (trangThaiGhiKhoa == TrangThaiGhi.them)
                {
                    undoManagerKhoa.AddNewRecord(addedRowArrayItem);
                }
                else
                {
                    undoManagerKhoa.EditRecord(oldRowItemArrayKhoa, addedRowArrayItem);
                }
                if (undoManagerKhoa.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
                else btnPhucHoi.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên. \n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            undoManagerKhoa.ClearReUndoStack();
            contextMenuStrip1.Enabled = true;
            gcKHOA.Enabled = true;
            pcKHOA.Enabled = false;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsLOP.Count > 0)
            {
                MessageBox.Show("Không thể xóa khoa có lớp", "",
                    MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show
                ("Bạn có thật sự muốn xóa khoa này ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    makhoa = ((DataRowView)bdsKHOA[bdsKHOA.Position])["MAKH"].ToString();
                    DataRowView deletedRow = (DataRowView)bdsKHOA.Current;
                    object[] deletedRowArrayItem = deletedRow.Row.ItemArray;
                    undoManagerKhoa.DeleteRecord(deletedRowArrayItem);
                    undoManagerKhoa.ClearReUndoStack();
                    if (undoManagerKhoa.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
                    else btnPhucHoi.Enabled = true;
                    bdsKHOA.RemoveCurrent();
                    this.KHOATableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    this.KHOATableAdapter.Update(this.DSKhoaLop.KHOA);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên, vui lòng thử lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.KHOATableAdapter.Fill(DSKhoaLop.KHOA);
                    bdsKHOA.Position = bdsKHOA.Find("MAKH", makhoa);
                    return;
                }
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pcKHOA.Enabled == true)
            {
                try
                {
                    bdsKHOA.CancelEdit();
                    this.KHOATableAdapter.Fill(this.DSKhoaLop.KHOA);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể reload lại dữ liệu \n {ex}", "", MessageBoxButtons.OK);
                }
                bdsKHOA.Position = vitri;
            }
            else
            {
                if (undoManagerKhoa.Undo() == 0)
                {
                    KHOATableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    KHOATableAdapter.Update(DSKhoaLop.KHOA);
                }
            }
            gcKHOA.Enabled = true;
            pcKHOA.Enabled = false;
            btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            if (undoManagerKhoa.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
            else btnPhucHoi.Enabled = true;
            if (undoManagerKhoa.GetReUndoStack().Count <= 0) btnTaiPhucHoi.Enabled = false;
            else btnTaiPhucHoi.Enabled = true;
            contextMenuStrip1.Enabled = true;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.KHOATableAdapter.Fill(this.DSKhoaLop.KHOA);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể reload lại dữ liệu \n {ex}", "", MessageBoxButtons.OK);
            }
        }

        private void tENCSComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //private void ghiToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
        //    //if (txtMaLop.Text.Trim() != malop.Trim())
        //    //{
        //    //    try
        //    //    {
        //    //        SqlCommand command = new SqlCommand("EXECUTE SP_CheckValiDateLop @malop = " + txtMaLop.Text, Program.conn);
        //    //        command.ExecuteNonQuery();
        //    //    }
        //    //    catch (SqlException ex)
        //    //    {
        //    //        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
        //    //        return;
        //    //    }
        //    //}
        //    //if ( txtTenLop.Text.Trim() != tenlop.Trim())
        //    //{
        //    //    try
        //    //    {
        //    //        SqlCommand command = new SqlCommand("EXECUTE SP_CheckValiDateLop @tenlop = " + "'" + txtTenLop.Text + "'", Program.conn);
        //    //        command.ExecuteNonQuery();
        //    //    }
        //    //    catch (SqlException ex)
        //    //    {
        //    //        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
        //    //        return;
        //    //    }
        //    //}

        //    //if (malopArr != null)
        //    //{
        //    //    for (int i = 0; i < malopArr.Count; i++)
        //    //    {
        //    //        if (malopArr[i].ToLower() == txtMaLop.Text.ToLower())
        //    //        {
        //    //            MessageBox.Show("Trùng mã lớp", "", MessageBoxButtons.OK);
        //    //            return;
        //    //        }
        //    //    }
        //    //}
        //    //if (tenlopArr != null)
        //    //{
        //    //    for (int i = 0; i < tenlopArr.Count; i++)
        //    //    {
        //    //        if (tenlopArr[i].ToLower() == txtTenLop.Text.ToLower())
        //    //        {
        //    //            MessageBox.Show("Trùng tên lớp", "", MessageBoxButtons.OK);
        //    //            return;
        //    //        }
        //    //    }
        //    //}

        //    try
        //    {
        //        bdsLOP.EndEdit();
        //        bdsLOP.ResetCurrentItem();
        //        undoManagerLop.ClearUndoStack();
        //        undoManagerLop.ClearReUndoStack();
        //        this.lOPTableAdapter.Connection.ConnectionString =   Data.ServerConnectionString;
        //        this.lOPTableAdapter.Update(this.DSKhoaLop.LOP);
              
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi ghi lớp, vui lòng thử lại!{ex}", "", MessageBoxButtons.OK); 
        //        return;   
        //    }
        //}

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            if (bdsLOP.Count == 0)
            {
                MessageBox.Show("Không có lớp để xóa", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsSV.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp có sinh viên", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsGV_DK.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp đã đăng ký thi", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show
                ("Bạn có thật sự muốn xóa lớp này ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    malop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
                    DataRowView deletedRow = (DataRowView)bdsLOP.Current;
                    object[] deletedRowArrayItem = deletedRow.Row.ItemArray;
                    undoManagerLop.DeleteRecord(deletedRowArrayItem);
                    if (undoManagerLop.GetUndoStack().Count <= 0) phụcHồiToolStripMenuItem.Enabled = false;
                    else phụcHồiToolStripMenuItem.Enabled = true;
                    try
                    {
                        bdsLOP.RemoveCurrent();
                        undoManagerLop.ClearReUndoStack();

                        this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                        this.lOPTableAdapter.Update(this.DSKhoaLop.LOP);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi ghi lớp, vui lòng thử lại!{ex}", "", MessageBoxButtons.OK);
                        return;
                    }
                
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp, vui lòng thử lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.lOPTableAdapter.Fill(DSKhoaLop.LOP);
                    //bdsLOP.Position = bdsLOP.Find("MALOP", malop);
                    return;
                }
                if (bdsLOP.Count == 0) xóaToolStripMenuItem.Enabled = false;
            }
            
        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            bdsLOP.AddNew();
            vitriLop = bdsLOP.Position;
            trangThaiGhiLop = TrangThaiGhi.them;
            ((DataRowView)bdsLOP[bdsLOP.Position])["MAKH"] = txtMAKHOA.Text;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvLOP.Columns)
            {
                if (column.FieldName == "MAKH") continue;
                column.OptionsColumn.AllowEdit = true;
            }
            if (bdsLOP.Count == 0) xóaToolStripMenuItem.Enabled = false;
            else xóaToolStripMenuItem.Enabled = true;
        }

            private void gvLOP_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
            {
            
            DataRowView row = (DataRowView)e.Row;
                if (row != null && row["MALOP"].ToString().Trim() == "")
                {
                    e.ErrorText = "Mã lớp bị bỏ trống.";
                    gvLOP.FocusedRowHandle = e.RowHandle;
                    gvLOP.FocusedColumn = gvLOP.Columns["MALOP"];
                    e.Valid = false;
            
                return;
                }
                if (row != null && row["TENLOP"].ToString().Trim() == "")
                {
                    e.ErrorText = "Tên lớp bị bỏ trống.";
                    gvLOP.FocusedRowHandle = e.RowHandle;
                    gvLOP.FocusedColumn = gvLOP.Columns["TENLOP"];
                    e.Valid = false;

                return;
                }


                if (!isUndoOrReundo)
            {
                try
                {
                    if (Data.ServerConnection.State == ConnectionState.Closed)
                    {
                        Data.ServerConnection.Open();
                    }
                    SqlCommand command = new SqlCommand("EXECUTE SP_CheckValiDateLop @malop = " + row["MALOP"].ToString().Trim() + ", @tenlop = " + row["TENLOP"].ToString().Trim(), Data.ServerConnection);
                    command.ExecuteNonQuery();
                    Data.ServerConnection.Close();
                }
                catch (SqlException ex)
                {
                    // Lấy thông điệp lỗi từ SqlException
                    String errorMessage = ex.Message;
                    gvLOP.FocusedRowHandle = e.RowHandle;
                    e.ErrorText = errorMessage;
                    // Trạng thái 1 quy định lỗi trùng mã lớp, trạng thái 2 quy định trùng tên lớp
                    if (ex.State == 1)
                    {
                        gvLOP.FocusedColumn = gvLOP.Columns["MALOP"];
                    }
                    else
                    {
                        gvLOP.FocusedColumn = gvLOP.Columns["TENLOP"];
                    }
                    e.Valid = false;

                    return;
                }
            }

          
                
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvLOP.Columns)
            {
                column.OptionsColumn.AllowEdit = false;
            }

            if(trangThaiGhiLop == TrangThaiGhi.them && !isUndoOrReundo)
            {
                DataRowView addedRow = (DataRowView)bdsLOP.Current;
                object[] addedRowArrayItem = addedRow.Row.ItemArray;
                undoManagerLop.AddNewRecord(addedRowArrayItem);
            }

            if (undoManagerLop.GetUndoStack().Count > 0)
            {
                phụcHồiToolStripMenuItem.Enabled = true;
            } else
            {
                phụcHồiToolStripMenuItem.Enabled = false;
            }
            try
            {
                bdsLOP.EndEdit();
                bdsLOP.ResetCurrentItem();
                if (!isUndoOrReundo)
                {
                    undoManagerLop.ClearReUndoStack();
                }

                this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.lOPTableAdapter.Update(this.DSKhoaLop.LOP);

            }
            catch (Exception ex)
            {
                e.Valid = false;
                e.ErrorText = ex.Message;
                return;
            }
            isUndoOrReundo = false;
        }


        private void gvKHOA_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsLOP.Count == 0) xóaToolStripMenuItem.Enabled = false;
            else xóaToolStripMenuItem.Enabled = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void hiệuChỉnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangThaiGhiLop = TrangThaiGhi.hieuchinh;
            //btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            string maLop;
            string tenLop;
            try
            {
                maLop = gvLOP.GetFocusedDataRow()["MALOP"].ToString();
                tenLop = gvLOP.GetFocusedDataRow()["TENLOP"].ToString();
            }
            catch ( Exception ex)
            {
                MessageBox.Show("Không thể hiệu chỉnh!", "", MessageBoxButtons.OK);
                return;
            }

            // Tạo hộp thoại xác nhận tùy chỉnh với thông tin lớp và mã lớp
            Form confirmForm = new Form();
            confirmForm.Text = "Hiệu chỉnh";
            confirmForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            confirmForm.MaximizeBox = false;
            confirmForm.MinimizeBox = false;
            confirmForm.StartPosition = FormStartPosition.CenterScreen;

            // Tạo label cho mã lớp và tên lớp
            Label lblMaLop = new Label();
            lblMaLop.Text = "Mã lớp:";
            lblMaLop.Location = new Point(20, 20);
            lblMaLop.Size = new Size(60, 20);
            lblMaLop.TextAlign = ContentAlignment.MiddleRight;
            confirmForm.Controls.Add(lblMaLop);

            Label lblTenLop = new Label();
            lblTenLop.Text = "Tên lớp:";
            lblTenLop.Location = new Point(20, 50);
            lblTenLop.Size = new Size(60, 20);
            lblTenLop.TextAlign = ContentAlignment.MiddleRight;
            confirmForm.Controls.Add(lblTenLop);

            // Tạo TextBox cho mã lớp và tên lớp
            TextBox txtMaLopHieuChinh = new TextBox();
            txtMaLopHieuChinh.Text = maLop;
            txtMaLopHieuChinh.Location = new Point(90, 20);
            txtMaLopHieuChinh.Size = new Size(200, 20);
            confirmForm.Controls.Add(txtMaLopHieuChinh);
            txtMaLopHieuChinh.Enabled = false;

            TextBox txtTenLopHieuChinh = new TextBox();
            txtTenLopHieuChinh.Text = tenLop;
            txtTenLopHieuChinh.Location = new Point(90, 50);
            txtTenLopHieuChinh.Size = new Size(200, 20);
            confirmForm.Controls.Add(txtTenLopHieuChinh);

            // Thêm nút "OK" và "Cancel" vào hộp thoại
            Button btnOK = new Button();
            btnOK.Text = "OK";
            //btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(90, 90);
            confirmForm.Controls.Add(btnOK);

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(190, 90);
            confirmForm.Controls.Add(btnCancel);

            // Hiển thị hộp thoại và xử lý kết quả khi người dùng click vào nút "OK" hoặc "Cancel"
            btnOK.Click += (sender1, e1) =>
            {
                // Lấy giá trị mới từ các TextBox
                //string newMaLop = txtMaLopHieuChinh.Text;
                string newTenLop = txtTenLopHieuChinh.Text;
                if (newTenLop.ToLower().Trim() != tenLop.ToLower().Trim())
                {
                    //try
                    //{
                    //    SqlCommand command = new SqlCommand(, Program.conn);
                    //    command.ExecuteNonQuery();
                    //}
                    //catch (SqlException ex)
                    //{
                    //    // Lấy thông điệp lỗi từ SqlException
                    //    String errorMessage = ex.Message;
                    //    MessageBox.Show(errorMessage, "", MessageBoxButtons.OK);
                    //    return;
                    //}
                    if(Data.ExecSqlNonQueryByServerConnection("EXECUTE SP_CheckValiDateLop @malop = " + "null" + ", @tenlop = " + "'" + newTenLop + "'") != 0)
                    {
                        return;
                    }
                }
             
                DataRow selectedRow = ((DataRowView)gvLOP.GetFocusedRow()).Row;
                DataRowView oldRow = (DataRowView)gvLOP.GetFocusedRow();
                oldRowItemArrayLop = oldRow.Row.ItemArray;
                selectedRow["TENLOP"] = newTenLop;
                DataRowView newRow = (DataRowView)gvLOP.GetFocusedRow();
                object[] newRowItemArrayLop = newRow.Row.ItemArray;
                undoManagerLop.EditRecord(oldRowItemArrayLop, newRowItemArrayLop);

                if (undoManagerLop.GetUndoStack().Count > 0)
                {
                    phụcHồiToolStripMenuItem.Enabled = true;
                } else
                {
                    phụcHồiToolStripMenuItem.Enabled = false;
                }
               
                gvLOP.RefreshData();
                try
                {
                    if (!isUndoOrReundo)
                    {
                        undoManagerLop.ClearReUndoStack();
                    }

                    this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    this.lOPTableAdapter.Update(this.DSKhoaLop.LOP);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi ghi lớp, vui lòng thử lại!{ex}", "", MessageBoxButtons.OK);
                    return;
                }
                confirmForm.Close();
            };
            confirmForm.ShowDialog();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void gcLOP_Click(object sender, EventArgs e)
        {

        }

        private void gvLOP_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            
            DialogResult result = MessageBox.Show(e.ErrorText, "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            if (result == DialogResult.No)
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvLOP.Columns)
                {
                    column.OptionsColumn.AllowEdit = false;
                }
                btnHieuChinh.Enabled = btnReload.Enabled = btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = true;
            }
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
                this.KHOATableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.KHOATableAdapter.Fill(this.DSKhoaLop.KHOA);
                this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.lOPTableAdapter.Fill(this.DSKhoaLop.LOP);
                this.SINHVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.SINHVIENTableAdapter.Fill(this.DSKhoaLop.SINHVIEN);
            }
        }

        private void phụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoManagerLop.GetUndoStack().Count != 0)
            {
                RowData temp = undoManagerLop.GetUndoStack().Peek();
                if (temp.ActionType == ActionType.Delete)
                {
                    isUndoOrReundo = true;
                }
            }
            undoManagerLop.Undo();
            //bdsLOP.EndEdit();
            //bdsLOP.ResetCurrentItem();
            this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.lOPTableAdapter.Update(this.DSKhoaLop.LOP);
            if (undoManagerLop.GetUndoStack().Count <= 0) phụcHồiToolStripMenuItem.Enabled = false;
            else phụcHồiToolStripMenuItem.Enabled = true;
            if (undoManagerLop.GetReUndoStack().Count <= 0) táiPhụcHồiToolStripMenuItem.Enabled = false;
            else táiPhụcHồiToolStripMenuItem.Enabled = true;
            clickPhucHoi = true;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undoManagerKhoa.ReUndo() == 0)
            {
                KHOATableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                KHOATableAdapter.Update(DSKhoaLop.KHOA);
            }
            if (undoManagerKhoa.GetReUndoStack().Count <= 0) btnTaiPhucHoi.Enabled = false;
            else btnTaiPhucHoi.Enabled = true;
            if (undoManagerKhoa.GetUndoStack().Count <= 0) btnPhucHoi.Enabled = false;
            else btnPhucHoi.Enabled = true;
        }

        private void táiPhụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoManagerLop.GetReUndoStack().Count != 0)
            {
                RowData temp = undoManagerLop.GetReUndoStack().Peek();
                if (temp.ActionType == ActionType.Delete)
                {
                    isUndoOrReundo = true;
                }
            }
            undoManagerLop.ReUndo();
            this.lOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.lOPTableAdapter.Update(this.DSKhoaLop.LOP);
            if (undoManagerLop.GetReUndoStack().Count <= 0) táiPhụcHồiToolStripMenuItem.Enabled = false;
            else táiPhụcHồiToolStripMenuItem.Enabled = true;
            if (undoManagerLop.GetUndoStack().Count <= 0) phụcHồiToolStripMenuItem.Enabled = false;
            else phụcHồiToolStripMenuItem.Enabled = true;
        }
    }
}
