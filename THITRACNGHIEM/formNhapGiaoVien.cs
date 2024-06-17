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
        private List<String> maGVArr = new List<String>();
        private UndoManager undoManager;
        private TrangThaiGhi trangThaiGhi;
        private object[] oldRowItemArray;
        private bool isXoaUndo = false;
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
            if(isXoaUndo)
            {
                isXoaUndo = true;
                return;
            }
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

            try
            {
                SqlCommand command = new SqlCommand("EXECUTE SP_CHECKMAGIAOVIENTONTAI @MAGV = " + row["MAGV"].ToString().Trim(), Data.ServerConnection);
                command.ExecuteNonQuery();
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
            string maGV = row["MAGV"].ToString().Trim();
            if (maGVArr != null)
            {
                for (int i = 0; i < maGVArr.Count; i++)
                {
                    if (maGVArr[i].ToLower().Trim() == maGV.ToLower().Trim())
                    {
                        e.ErrorText = "Mã giáo viên bị trùng lặp.";
                        gvGiaoVien.FocusedRowHandle = e.RowHandle;
                        gvGiaoVien.FocusedColumn = gvGiaoVien.Columns["MAGV"];
                        e.Valid = false;
                        
                        return;
                    }
                }
                
            }
            maGVArr.Add(maGV.ToLower().Trim());
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvGiaoVien.Columns)
            {
                column.OptionsColumn.AllowEdit = false;
            }

            if (trangThaiGhi == TrangThaiGhi.them)
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
                ("Bạn có thật sự muốn xóa lớp này ??", "Xác nhận",
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
                    bdsGiaoVien.RemoveCurrent();
                    if (maGVArr.Contains(maGV.ToLower()))
                    {
                        maGVArr.Remove(maGV.ToLower());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp, vui lòng thử lại\n" + ex.Message, "", MessageBoxButtons.OK);
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
            tableLayoutPanel.Controls.Add(txtHo, 1, 1);

            // Tạo Label và TextBox cho Tên
            Label lblTen = new Label();
            lblTen.Text = "Tên:";
            lblTen.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblTen, 0, 2);

            TextBox txtTen = new TextBox();
            txtTen.Text = ten;
            tableLayoutPanel.Controls.Add(txtTen, 1, 2);

            // Tạo Label và TextBox cho Địa chỉ
            Label lblDiaChi = new Label();
            lblDiaChi.Text = "Địa chỉ:";
            lblDiaChi.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanel.Controls.Add(lblDiaChi, 0, 3);

            TextBox txtDiaChi = new TextBox();
            txtDiaChi.Text = diachi;
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
                    selectedRow["HOCVI"] = "";
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
                confirmForm.Close();
            };


            confirmForm.ShowDialog();
        }

        private void ghiLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bdsGiaoVien.EndEdit();
                bdsGiaoVien.ResetCurrentItem();
                undoManager.ClearUndoStack();
                undoManager.ClearReUndoStack();
                this.GIAOVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.GIAOVIENTableAdapter.Update(this.dSNhapLop.GIAOVIEN);
                maGVArr.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ghi lớp, vui lòng thử lại!{ex}", "", MessageBoxButtons.OK);
                return;
            }
        }

        private void phụcHồiGiáoViênToolStripmenuItem_Click(object sender, EventArgs e)
        {
            RowData temp = undoManager.GetUndoStack().Peek();
            if (temp.ActionType == ActionType.Delete) isXoaUndo = true;
            else isXoaUndo = false;
            undoManager.Undo();
            if (undoManager.GetUndoStack().Count <= 0) phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
            else phụcHồiGiáoViênToolStripmenuItem.Enabled = true;
            if (undoManager.GetReUndoStack().Count <= 0) táiPhụcHồiToolStripMenuItem.Enabled = false;
            else táiPhụcHồiToolStripMenuItem.Enabled = true;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void táiPhụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoManager.ReUndo();
            if (undoManager.GetReUndoStack().Count <= 0) táiPhụcHồiToolStripMenuItem.Enabled = false;
            else táiPhụcHồiToolStripMenuItem.Enabled = true;
            if (undoManager.GetUndoStack().Count <= 0) phụcHồiGiáoViênToolStripmenuItem.Enabled = false;
            else phụcHồiGiáoViênToolStripmenuItem.Enabled = true;
        }
    }
}