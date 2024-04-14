using DevExpress.ChartRangeControlClient.Core;
using DevExpress.Utils.Extensions;
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
    public partial class frmSinhVien : Form
    {
        //Lưu vị trí hiện tại
        private int vitri;
        private int count;
        private int IndexOfStack;
        private MyStack UndoStack;
        private MyStack RedoStack = new MyStack();
        private Action action;
        private DataRow currentDataRow;
        Object[] previousData;
        private SqlConnection mySqlConnection = new SqlConnection();
        private SqlCommand sqlcmd;
        private SqlParameter parameter;
        public frmSinhVien()
        {
            InitializeComponent();
        }

        //Load cơ sở dữ liệu
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
           
           this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.DS_SV.LOP);
           
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS_SV.SINHVIEN);
           
            this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.BANGDIEMTableAdapter.Fill(this.DS_SV.BANGDIEM);
            //Load cơ sở
            this.cmbCoSo.DataSource = Program.bds_dspm.DataSource;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            this.cmbCoSo.SelectedIndex = Program.mCoSo;
            this.checkRole();
            //Thêm sự kiện để xử lý
            this.cmbCoSo.SelectedIndexChanged += cmbSelected_IndexChanged;
            this.gcSinhVien.MouseClick += showCMS;
            // xử lý khi stack thay đổi
            this.UndoStack =  new MyStack();
            this.UndoStack.StackChange += UndoStackChange;
            this.UndoStack.TriggerEvent();
            this.RedoStack = new MyStack();
            this.RedoStack.StackChange += RedoStackChange;
            this.RedoStack.TriggerEvent();
            //Kết nối về site tra cứu
           if(this.connectSiteTraCuu())
            {
            sqlcmd = new SqlCommand("select dbo.checkExistsMasv(@masv) ", mySqlConnection);
            parameter= sqlcmd.Parameters.AddWithValue("@masv","");
            }
        }

        //Hàm tự thêm
        //Kiểm tra quyền
        private void checkRole()
        {
            Console.WriteLine(Program.mGroup);
            if (Program.mGroup.Equals("TRUONG"))
            {
                this.cmbCoSo.Enabled = true;
                btnThem.Enabled=btnHieuChinh.Enabled=btnXoa.Enabled= btnGhi.Enabled =btnPhucHoi.Enabled=false;  
            }
            else if (Program.mGroup.Equals("COSO"))
            {
                this.cmbCoSo.Enabled =btnPhucHoi.Enabled=btnGhi.Enabled= false;
                btnThem.Enabled=btnHieuChinh.Enabled=btnXoa.Enabled=btnThoat.Enabled=true;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào form này");
                this.Close();
            }
        }
        private void cmbSelected_IndexChanged(object sender,EventArgs e) 
        {
            Program.servername = cmbCoSo.SelectedValue.ToString();
            if (cmbCoSo.SelectedIndex != Program.mCoSo)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi(true) == 0)
            {
                MessageBox.Show("Lỗi kết nối về cơ sở", "", MessageBoxButtons.OK);
            }
            else
            {
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.DS_SV.LOP);
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS_SV.SINHVIEN);         
            this.BANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.BANGDIEMTableAdapter.Fill(this.DS_SV.BANGDIEM);
            }
        }
        //hiện ra contextmenustrip
        private void showCMS(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Tạo một điểm (Point) tại vị trí chuột được nhấp
                Point locationOnForm = this.PointToClient(Cursor.Position);
                // Hiển thị ContextMenuStrip tại vị trí chuột được nhấp
                contextMenuStrip1.Show(this, locationOnForm);
            }
        }

        private void UndoStackChange()
        {
            btnPhucHoi.Enabled = (UndoStack.getSize() > 0);

            btnReload.Enabled = btnThoat.Enabled = (UndoStack.getSize() == IndexOfStack);

            btnGhi.Enabled = (UndoStack.getSize() != IndexOfStack);
        }

        private void RedoStackChange()
        {
            if (RedoStack.getSize() == 0) btnRedo.Enabled = false;
        }
        private void HidePanelEdit(bool allow)
        {
            if (allow)
               panelEditSV.Dock = DockStyle.None;
            else
                panelEditSV.Dock = DockStyle.Left;
             gcLop.Enabled = allow;
             panelEditSV.Visible=!allow;
             gcSinhVien.Enabled = allow;
        }

        private bool connectSiteTraCuu()
        {
            if(mySqlConnection.State == ConnectionState.Open)mySqlConnection.Close();
            mySqlConnection.ConnectionString =  "Data Source=" + Program.servernameTraCuu + ";Initial Catalog=" +
                Program.database + ";User ID=" +
                Program.remotelogin + ";password=" + Program.remotepassword;
            try
            {
                mySqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu mã sinh viên\n" + ex.Message);
                return false;
            }
        }
        //Hàm xử lý sự kiện cho từng nút lệnh
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //lưu vị trí hiện tại
            vitri = bdsSinhVien.Position;
            //Chuyển sang giao diện edit
            HidePanelEdit(false);

            //thêm dòng mới
            bdsSinhVien.AddNew();
            txtMalop.Text = ((DataRowView)bdsLop.Current)[0].ToString();
            txtMasv.Enabled = true;
            //Không cho phép hành động hiệu chính, xóa, reload, thoát,thêm dòng mới khi chưa thêm xong
            btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = 
                btnThem.Enabled = btnThoat.Enabled = btnPhucHoi.Enabled = false;
        }
        private void btnXong_Click(object sender, EventArgs e)
        {
            currentDataRow = ((DataRowView)bdsSinhVien.Current).Row;
            if (txtMasv.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã sinh viên không được phép trống");
                return;
            }
            if (currentDataRow.RowState == DataRowState.Detached)//check
            {
                if(DS_SV.SINHVIEN.FindByMASV(txtMasv.Text.Trim()) != null)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại");
                    return;
                }

                sqlcmd.Parameters["@masv"].Value = txtMasv.Text.Trim();
                Console.WriteLine("abc");
                try
                {
                    if ((int)sqlcmd.ExecuteScalar() == 1) { 
                        MessageBox.Show("Mã sinh viên đã tồn tại");
                        return;
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tra cứu mã sinh viên\n" + ex.Message);
                    return;
                }
            }
            if (txtHo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Họ không được phép trống");
                return;
            }   
            if (txtTen.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên không được phép trống");
                return;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Password không được phép trống");
                return;
            }
            
            

             
            try {
                //currentDataRow.EndEdit();
                ((DataRowView)bdsSinhVien.Current).EndEdit();
                HidePanelEdit(true);
                btnHieuChinh.Enabled = btnXoa.Enabled = btnThem.Enabled = true;
                if (currentDataRow.RowState == DataRowState.Unchanged) return;
                if (currentDataRow.RowState == DataRowState.Detached || currentDataRow.RowState == DataRowState.Added)
                {
                    UndoStack.Push(ActionState.ADDED, currentDataRow, currentDataRow.ItemArray);
                    //DS_SV.SINHVIEN.Rows.Add(currentRowView.Row);
                }
                else
                    UndoStack.Push(ActionState.MODIFIED, currentDataRow,previousData);

                RedoStack.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bdsSinhVien.ResetCurrentItem();
                bdsSinhVien.EndEdit();
                this.SINHVIENTableAdapter.Update(DS_SV.SINHVIEN);
                MessageBox.Show("Ghi thành công");
                if(bdsSinhVien.Count == 0) btnXoa.Enabled = btnHieuChinh.Enabled = false;
                else btnXoa.Enabled = btnHieuChinh.Enabled = true;
                btnThem.Enabled= true;
                IndexOfStack = this.UndoStack.getSize();
                UndoStack.TriggerEvent();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lưu sinh viên\n" + ex.Message,"", MessageBoxButtons.OK);
            }
            finally
            {
                HidePanelEdit(true);
            }
        }

            private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Sinh viên đã thi không thể xóa vì đã thi","",MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn thực sự muốn xóa sinh viên này", "Xác nhận", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            currentDataRow = ((DataRowView)bdsSinhVien.Current).Row;
            UndoStack.Push(ActionState.DELETED, currentDataRow, currentDataRow.ItemArray);
            RedoStack.Clear();
            bdsSinhVien.RemoveCurrent();
            if (bdsSinhVien.Count == 0)
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UndoStack.getSize() == 0) return;
            action = UndoStack.Pop();
            switch(action.action)
            {
                case ActionState.ADDED:
                    RedoStack.Push(ActionState.DELETED, action.data, action.objects);
                    if (action.data.RowState == DataRowState.Added)
                        action.data.RejectChanges();
                    else action.data.Delete();
                    break;
                case ActionState.MODIFIED:
                    RedoStack.Push(ActionState.MODIFIED, action.data, action.data.ItemArray);
                    action.data.ItemArray = action.objects.ToArray();
                    break;
                case ActionState.DELETED:
                    RedoStack.Push(ActionState.ADDED, action.data, action.objects);
                    //xóa trên dòng củ
                    if (action.data.RowState == DataRowState.Deleted)
                    {
                        action.data.RejectChanges();
                        action.data.ItemArray = action.objects.ToArray();
                    }
                    else
                    {
                        //xóa trên dòng mới
                        action.data.ItemArray = action.objects.ToArray();
                        DS_SV.SINHVIEN.Rows.Add(action.data);
                    }
                    break;
            }
            if (bdsSinhVien.Count == 0) btnHieuChinh.Enabled = btnXoa.Enabled = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.mlogin = Program.mloginDN;
            Program.password = Program.passwordDN;
            Program.conn.Close();//Tạm thời
            this.mySqlConnection.Close();
            this.Close();
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsSinhVien.Position;
            previousData = ((DataRowView)bdsSinhVien.Current).Row.ItemArray;
            HidePanelEdit(false);

            btnThem.Enabled = btnXoa.Enabled  = btnHieuChinh.Enabled =
                btnPhucHoi.Enabled = btnReload.Enabled=btnThoat.Enabled= false;
            txtMalop.Enabled = txtMasv.Enabled = false;
        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LOPTableAdapter.Fill(DS_SV.LOP);
            SINHVIENTableAdapter.Fill(this.DS_SV.SINHVIEN);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            bdsSinhVien.CancelEdit();
            HidePanelEdit(true);
            UndoStack.TriggerEvent();
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = true;
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (RedoStack.getSize() == 0) return;
            action = RedoStack.Pop();
            try
            {
                switch (action.action)
                {
                    case ActionState.ADDED:
                        UndoStack.Push(ActionState.DELETED, action.data, action.objects);
                        if (action.data.RowState == DataRowState.Added)
                        {
                            action.data.RejectChanges();
                        }
                        else
                            action.data.Delete();
                        break;
                    case ActionState.MODIFIED:
                        UndoStack.Push(ActionState.MODIFIED, action.data, action.data.ItemArray);
                        action.data.ItemArray = action.objects.ToArray();
                        break;
                    case ActionState.DELETED:
                        UndoStack.Push(ActionState.ADDED, action.data, action.data.ItemArray);
                        //xóa trên dòng củ
                        if (action.data.RowState == DataRowState.Deleted)
                        {
                            action.data.RejectChanges();
                            action.data.ItemArray = action.objects.ToArray();
                        }
                        else
                        {
                            //xóa trên dòng mới
                            action.data.ItemArray = action.objects.ToArray();
                            DS_SV.SINHVIEN.Rows.Add(action.data);
                        }
                        break;
                }
                //trường hợp phục hồi dẫn tới không còn dòng nào nữa
                if (bdsSinhVien.Count == 0)
                    btnHieuChinh.Enabled = btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi\n" + ex.Message);
            }
        }
    }
}
