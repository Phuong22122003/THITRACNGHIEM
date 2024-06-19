//using DevExpress.CodeParser;
using DevExpress.Data.Extensions;
using DevExpress.XtraEditors.Repository;
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
    public partial class formNhapGiaoVien : Form
    {

        private int vitri = 0;
        private String maGV;
      
        private UndoManager undoManager;
        private TrangThaiGhi trangThaiGhi;
        private object[] oldRowItemArray;

        private bool isUndoOrReundo = false;
        public formNhapGiaoVien()
        {
            InitializeComponent();
        }


        private void formNhapGiaoVIen_Load(object sender, EventArgs e)
        {
          

            this.dSNhapLop.EnforceConstraints = false;

            this.KHOATableAdapter.Connection.ConnectionString = Data.ServerConnectionString; 
            this.KHOATableAdapter.Fill(this.dSNhapLop.KHOA);

            this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIENTableAdapter.Fill(this.dSNhapLop.GIAOVIEN);

            this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSNhapLop.GIAOVIEN_DANGKY);

            this.BODETableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.BODETableAdapter.Fill(this.dSNhapLop.BODE);

            this.cmbCoSo.DataSource = Data.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            this.cmbCoSo.SelectedIndex = Data.mCoSo;


            colHOCVI.ColumnEdit = new RepositoryItemComboBox
            {
                Items = { "CỬ NHÂN", "TIẾN SĨ", "THẠC SĨ" }
            };

            if (Data.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
            }
            else
            {
                cmbCoSo.Enabled = false;
            }

            undoManager = new UndoManager(this.bdsGiaoVien);
        }

        private void thêmLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bdsGiaoVien.AddNew();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvGiaoVien.Columns)
            {
                if (column.FieldName == "MAKH") continue;
                column.OptionsColumn.AllowEdit = true;
            }
            if (bdsGiaoVien.Count == 0) xóaLớpToolStripMenuItem.Enabled = false;
            else xóaLớpToolStripMenuItem.Enabled = true;
            trangThaiGhi = TrangThaiGhi.them;
        }

        private void gcGiaoVien_MouseClick(object sender, MouseEventArgs e)
        {
            //Nếu click chuột phải vào grid view giáo viên
            //thì hiện menu context trip của giáo viên
            if (e.Button == MouseButtons.Right)
            {
                // Lấy control mà người dùng đã click chuột (gcGiaoVien)
                Control control = (Control)sender;

                // Lấy tọa độ của chuột tương đối với control
                Point relativeMousePosition = control.PointToClient(Cursor.Position);

                // Hiển thị ContextMenuStrip tại vị trí của chuột
                contextMenuStrip1.Show(control, relativeMousePosition);
            }
        }

        private void gvGiaoVien_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //if(isXoaUndo)
            //{
            //    isXoaUndo = false;
            //    return;
            //}
            //if (isXoaReUndo)
            //{
            //    isXoaReUndo = false;
            //    return;
            //}
            DataRowView row = (DataRowView)e.Row;
            if (row != null && row["MAGV"].ToString().Trim() == "")
            {
                e.ErrorText= "Mã giáo viên không được bỏ trống!";
                gvGiaoVien.FocusedRowHandle = e.RowHandle;
                gvGiaoVien.FocusedColumn = gvGiaoVien.Columns["MAGV"];
                e.Valid = false;
                
                return;
            }

            if (row != null && row["HO"].ToString().Trim() == "")
            {
                e.ErrorText = "Họ giáo viên không được bỏ trống!";
                gvGiaoVien.FocusedRowHandle = e.RowHandle;
                gvGiaoVien.FocusedColumn = gvGiaoVien.Columns["HO"];
                e.Valid = false;
                
                return;
            }

            if (row != null && row["TEN"].ToString().Trim() == "")
            {
                e.ErrorText = "Tên giáo viên không được bỏ trống!";
                gvGiaoVien.FocusedRowHandle = e.RowHandle;
                gvGiaoVien.FocusedColumn = gvGiaoVien.Columns["TEN"];
                e.Valid = false;
                
                return;
            }

            if (!isUndoOrReundo)
            {
                try
                {
                    Data.ExecSqlNonQueryByServerConnection("EXECUTE SP_CHECKMAGIAOVIENTONTAI @MAGV = " + row["MAGV"].ToString().Trim(), false);
                    SqlCommand Sqlcmd = new SqlCommand("EXECUTE SP_CHECKMAGIAOVIENTONTAI @MAGV = " + row["MAGV"].ToString().Trim(), Data.ServerConnection);
                    Sqlcmd.CommandType = CommandType.Text;
                    Sqlcmd.CommandTimeout = 600;// 10 phut 
                    if (Data.ServerConnection.State == ConnectionState.Closed) Data.ServerConnection.Open();
                    Sqlcmd.ExecuteNonQuery();
                   
                }
                catch (SqlException ex)
                {
                    // Lấy thông điệp lỗi từ SqlException
                    e.ErrorText = ex.Message;
                    gvGiaoVien.FocusedRowHandle = e.RowHandle;
                    gvGiaoVien.FocusedColumn = gvGiaoVien.Columns["MAGV"];
                    e.Valid = false;
    
                    return;
                }
                finally
                {
                    Data.ServerConnection.Close();
                }

            }
            string maGV = row["MAGV"].ToString().Trim();
            //if (maGVArr != null)
            //{
            //    isXoaUndo = false;
            //    isXoaReUndo = false;
            //    for (int i = 0; i < maGVArr.Count; i++)
            //    {
            //        if (maGVArr[i].ToLower().Trim() == maGV.ToLower().Trim())
            //        {
            //            e.ErrorText = "Mã giáo viên bị trùng lặp.";
            //            gvGiaoVien.FocusedRowHandle = e.RowHandle;
            //            gvGiaoVien.FocusedColumn = gvGiaoVien.Columns["MAGV"];
            //            e.Valid = false;
                        
            //            return;
            //        }
            //    }
                
            //}
           
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvGiaoVien.Columns)
            {
                column.OptionsColumn.AllowEdit = false;
            }

            if (trangThaiGhi == TrangThaiGhi.them && !isUndoOrReundo)
            {
                DataRowView addedRow = (DataRowView)bdsGiaoVien.Current;
                object[] addedRowArrayItem = addedRow.Row.ItemArray;
                undoManager.AddNewRecord(addedRowArrayItem);
            }

            if (undoManager.GetUndoStack().Count > 0)
            {
                phụcHồiGiáoViênToolStripmenuItem.Enabled = true;
            }
            else
            {
                phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
            }
            try
            {
                bdsGiaoVien.EndEdit();
                bdsGiaoVien.ResetCurrentItem();
                if (!isUndoOrReundo)
                {
                    undoManager.ClearReUndoStack();
                }
                this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.GIAOVIENTableAdapter.Update(this.dSNhapLop.GIAOVIEN);
    
            }
            catch (Exception ex)
            {
                e.Valid = false;
                e.ErrorText = ex.Message;
                return;
            }
            isUndoOrReundo = false;
        }

        private void xóaLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bdsGiaoVien.Count == 0)
            {
                MessageBox.Show("Không có giáo viên để xóa", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsGVDK.Count > 0)
            {
                MessageBox.Show("Không thể xóa giảng viên đã đăng ký thi", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Không thể xóa giảng viên đã có câu hỏi", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show
                ("Bạn có thật sự muốn xóa giảng viên này ??", "Xác nhận",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maGV = ((DataRowView)bdsGiaoVien[bdsGiaoVien.Position])["MAGV"].ToString();
                    DataRowView deletedRow = (DataRowView)bdsGiaoVien.Current;
                    object[] deletedRowArrayItem = deletedRow.Row.ItemArray;
                    undoManager.DeleteRecord(deletedRowArrayItem);
                    if (undoManager.GetUndoStack().Count <= 0) phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
                    else phụcHồiGiáoViênToolStripmenuItem.Enabled = true;
            
                    //if (maGVArr.Contains(maGV.ToLower()))
                    //{
                    //    maGVArr.Remove(maGV.ToLower());
                    //}
                    try
                    {
                        bdsGiaoVien.RemoveCurrent();
                        undoManager.ClearReUndoStack();
                      
                        this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                        this.GIAOVIENTableAdapter.Update(this.dSNhapLop.GIAOVIEN);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi ghi giảng viên, vui lòng thử lại!{ex}", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giảng viên, vui lòng thử lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.GIAOVIENTableAdapter.Fill(dSNhapLop.GIAOVIEN);
                    bdsGiaoVien.Position = bdsGiaoVien.Find("MAGV", maGV);
                    return;
                }
                if (bdsGiaoVien.Count == 0) xóaLớpToolStripMenuItem.Enabled = false;
            }

        }

        private void gvGiaoVien_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            
            DialogResult result = MessageBox.Show(e.ErrorText, "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            if (result == DialogResult.No)
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvGiaoVien.Columns)
                {
                    column.OptionsColumn.AllowEdit = false;
                }
            }
        }

        private void hiệuChỉnhGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangThaiGhi = TrangThaiGhi.hieuchinh;
            string magv = gvGiaoVien.GetFocusedDataRow()["MAGV"].ToString();
            string ho = gvGiaoVien.GetFocusedDataRow()["HO"].ToString();
            string ten = gvGiaoVien.GetFocusedDataRow()["TEN"].ToString();
            string diachi = gvGiaoVien.GetFocusedDataRow()["DIACHI"].ToString();
            string hocvi = gvGiaoVien.GetFocusedDataRow()["HOCVI"].ToString().ToUpper().Trim();
            Form confirmForm = new Form();
            confirmForm.Text = "Hiệu chỉnh";
            confirmForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            confirmForm.MaximizeBox = false;
            confirmForm.MinimizeBox = false;
            confirmForm.StartPosition = FormStartPosition.CenterScreen;
            // Tạo TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            confirmForm.Controls.Add(tableLayoutPanel);

            // Tạo Label và TextBox cho Mã GV
            Label lblMaGV = new Label();
            lblMaGV.Text = "Mã GV:";
            lblMaGV.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblMaGV, 0, 0);

            TextBox txtMaGV = new TextBox();
            txtMaGV.Text = magv;
            tableLayoutPanel.Controls.Add(txtMaGV, 1, 0);
            txtMaGV.Enabled = false;

            // Tạo Label và TextBox cho Họ
            Label lblHo = new Label();
            lblHo.Text = "Họ:";
            lblHo.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblHo, 0, 1);

            TextBox txtHo = new TextBox();
            txtHo.Text = ho;
            txtHo.MaxLength = 50;
            tableLayoutPanel.Controls.Add(txtHo, 1, 1);

            // Tạo Label và TextBox cho Tên
            Label lblTen = new Label();
            lblTen.Text = "Tên:";
            lblTen.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblTen, 0, 2);

            TextBox txtTen = new TextBox();
            txtTen.Text = ten;
            txtTen.MaxLength = 10;
            tableLayoutPanel.Controls.Add(txtTen, 1, 2);

            // Tạo Label và TextBox cho Địa chỉ
            Label lblDiaChi = new Label();
            lblDiaChi.Text = "Địa chỉ:";
            lblDiaChi.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblDiaChi, 0, 3);

            TextBox txtDiaChi = new TextBox();
            txtDiaChi.Text = diachi;
            txtDiaChi.MaxLength = 50;
            tableLayoutPanel.Controls.Add(txtDiaChi, 1, 3);

            // Tạo Label và ComboBox cho Học vị
            Label lblHocVi = new Label();
            lblHocVi.Text = "Học vị:";
            lblHocVi.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblHocVi, 0, 4);

            ComboBox cboHocVi = new ComboBox();
            cboHocVi.DropDownStyle = ComboBoxStyle.DropDownList;
            
            cboHocVi.Items.AddRange(new string[] { "KHÔNG", "CỬ NHÂN", "THẠC SĨ", "TIẾN SĨ" });
            if (hocvi != "")
            {
                cboHocVi.SelectedItem = hocvi;
            }
            else cboHocVi.SelectedItem = "KHÔNG";
            tableLayoutPanel.Controls.Add(cboHocVi, 1, 4);

            // Tạo nút "OK"
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.Controls.Add(btnOK, 0, 5); // Thêm nút vào TableLayoutPanel

            // Tạo nút "Cancel"
            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel; // Đặt kết quả trả về của form khi nút "Cancel" được nhấn
            tableLayoutPanel.Controls.Add(btnCancel, 1, 5); // Thêm nút vào TableLayoutPanel

            // Thiết lập căn giữa các nút trong TableLayoutPanel
            tableLayoutPanel.SetColumnSpan(btnOK, 2); // Giãn btnOK trên 2 cột
            tableLayoutPanel.SetColumnSpan(btnCancel, 2); // Giãn btnCancel trên 2 cột

            // Thêm TableLayoutPanel vào confirmForm
            confirmForm.Controls.Add(tableLayoutPanel);

            btnOK.Click += (sender1, e1) =>
            {
                string newHo = txtHo.Text;
                string newTen = txtTen.Text;
                string newDiachi = txtDiaChi.Text;
                string newHocvi = cboHocVi.SelectedItem.ToString();


                DataRow selectedRow = ((DataRowView)gvGiaoVien.GetFocusedRow()).Row;
                DataRowView oldRow = (DataRowView)gvGiaoVien.GetFocusedRow();
                oldRowItemArray = oldRow.Row.ItemArray;
                selectedRow["TEN"] = newTen;
                selectedRow["HO"] = newHo;
                selectedRow["DIACHI"] = newDiachi;
                if (newHocvi == "KHÔNG")
                {
                    selectedRow["HOCVI"] = null;
                } else selectedRow["HOCVI"] = newHocvi;
                DataRowView newRow = (DataRowView)gvGiaoVien.GetFocusedRow();
                object[] newRowItemArray = newRow.Row.ItemArray;
                undoManager.EditRecord(oldRowItemArray, newRowItemArray);
                if (undoManager.GetUndoStack().Count > 0)
                {
                    phụcHồiGiáoViênToolStripmenuItem.Enabled = true;
                }
                else
                {
                    phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
                }
                gvGiaoVien.RefreshData();
                try
                {
                    if(!isUndoOrReundo)
                    {
                        undoManager.ClearReUndoStack();
                    }
               
                  
                    this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                    this.GIAOVIENTableAdapter.Update(this.dSNhapLop.GIAOVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi ghi giảng viên, vui lòng thử lại!{ex}", "", MessageBoxButtons.OK);
                    return;
                }
                confirmForm.Close();
            };


            confirmForm.ShowDialog();
        }

       
        private void phụcHồiGiáoViênToolStripmenuItem_Click(object sender, EventArgs e)
        {
            //if (undoManager.GetUndoStack().Count <= 0)
            //{
            //    phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
            //    return;
            //}
            //else phụcHồiGiáoViênToolStripmenuItem.Enabled = true;

            //RowData temp = undoManager.GetUndoStack().Peek();

            //if (undoManager.Undo() == 0)
            //{
            //    if (temp.ActionType == ActionType.Delete)
            //    {
            //        this.maGVArr.Add(temp.RowItemArray[0].ToString());
            //        isXoaUndo = true;
            //    }
            //    else
            //    {
            //        isXoaUndo = false;
            //    }
            //    if (temp.ActionType == ActionType.Add)
            //    {
            //        if (this.maGVArr.Contains(temp.RowItemArray[0].ToString()))
            //        {
            //            this.maGVArr.Remove(temp.RowItemArray[0].ToString());
            //        }
            //    }
            //    if (temp.ActionType == ActionType.Edit)
            //    {
            //        if (this.maGVArr.Contains(temp.EditedRowItemArray[0].ToString()))
            //        {
            //            this.maGVArr.Remove(temp.EditedRowItemArray[0].ToString());
            //            this.maGVArr.Add(temp.RowItemArray[0].ToString());
            //        }
            //    }

            //}
            if (undoManager.GetUndoStack().Count != 0)
            {
                RowData temp = undoManager.GetUndoStack().Peek();
                if (temp.ActionType == ActionType.Delete)
                {
                    isUndoOrReundo = true;
                }
            }

            undoManager.Undo();
        
            this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIENTableAdapter.Update(this.dSNhapLop.GIAOVIEN);

            if (undoManager.GetUndoStack().Count <= 0)
            {
                phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
            }
            else phụcHồiGiáoViênToolStripmenuItem.Enabled = true;

            if (undoManager.GetReUndoStack().Count <= 0)
            {
                táiPhụcHồiToolStripMenuItem.Enabled = false;
            }
            else táiPhụcHồiToolStripMenuItem.Enabled = true;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void táiPhụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (undoManager.GetReUndoStack().Count <= 0)
            //{
            //    táiPhụcHồiToolStripMenuItem.Enabled = false;
            //    return;
            //}
            //else táiPhụcHồiToolStripMenuItem.Enabled = true;

            //RowData temp = undoManager.GetReUndoStack().Peek();


            //if (undoManager.ReUndo() == 0)
            //{


            //    } else
            //    {
            //        isXoaReUndo = false;
            //    }
            //    if (temp.ActionType == ActionType.Add)
            //    {
            //        if (this.maGVArr.Contains(temp.RowItemArray[0].ToString()))
            //        {
            //            this.maGVArr.Remove(temp.RowItemArray[0].ToString());
            //        }
            //    }
            //    if (temp.ActionType == ActionType.Edit)
            //    {
            //        if (this.maGVArr.Contains(temp.EditedRowItemArray[0].ToString()))
            //        {
            //            this.maGVArr.Remove(temp.EditedRowItemArray[0].ToString());
            //            this.maGVArr.Add(temp.RowItemArray[0].ToString());
            //        }
            //    }
            //}
            if (undoManager.GetReUndoStack().Count != 0)
            {
                RowData temp = undoManager.GetReUndoStack().Peek();
                if (temp.ActionType == ActionType.Delete)
                {
                 
                    isUndoOrReundo = true;
                }
            }
            
            undoManager.ReUndo();
            this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
            this.GIAOVIENTableAdapter.Update(this.dSNhapLop.GIAOVIEN);
        
            if (undoManager.GetReUndoStack().Count <= 0)
            {
                táiPhụcHồiToolStripMenuItem.Enabled = false;

            }
            else táiPhụcHồiToolStripMenuItem.Enabled = true;
            if (undoManager.GetUndoStack().Count <= 0)
            {
                phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
            }
            else phụcHồiGiáoViênToolStripmenuItem.Enabled = true;

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
                this.KHOATableAdapter.Fill(this.dSNhapLop.KHOA);

                this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.GIAOVIENTableAdapter.Fill(this.dSNhapLop.GIAOVIEN);

                this.GIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.GIAOVIEN_DANGKYTableAdapter.Fill(this.dSNhapLop.GIAOVIEN_DANGKY);

                this.BODETableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.BODETableAdapter.Fill(this.dSNhapLop.BODE);
            }
        }
    }
}