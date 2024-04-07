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
        private MyStack myStack = new MyStack();
        private Action action;
        private int count;
        private DataRowView currentRowView;
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
            // TODO: This line of code loads data into the 'dS_SV.LOP' table. You can move, or remove it, as needed.
           this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.DS_SV.LOP);
            // TODO: This line of code loads data into the 'DS_SV.SINHVIEN' table. You can move, or remove it, as needed.
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS_SV.SINHVIEN);
            // TODO: This line of code loads data into the 'DS_SV.BANGDIEM' table. You can move, or remove it, as needed.
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
            this.myStack.StackChange += StackChange;
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

        private void StackChange()
        {
            Console.WriteLine("here");
            if(myStack.getSize() > 0)
            {
                btnGhi.Enabled = btnPhucHoi.Enabled = true;
                btnReload.Enabled = btnThoat.Enabled = false;
                
            }
            else 
            {
                btnGhi.Enabled = btnPhucHoi.Enabled = false;
                btnReload.Enabled = btnThoat.Enabled = true;
            }
        }

        private void hidePanelEdit(bool allow)
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
            hidePanelEdit(false);

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
            currentRowView = (DataRowView)bdsSinhVien.Current;
            if (txtMasv.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã sinh viên không được phép trống");
                return;
            }
            if (currentRowView.Row.RowState == DataRowState.Detached)
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
                //6 trường hợp:
                //0 Không thay đổi gì cả
                // 1. Thêm mới hoàn toàn-> lưu vào stack
                // 2. Hiệu chỉnh trên dòng vừa thêm-> không lưu vào stack
                // 3. Hiệu chỉnh trên dòng củ-> lưu vào stack
                // 4. Xóa trên dòng vừa thêm -> lưu vào stack
                // 5. Xóa trên dòng củ-> lưu vào stack
                currentRowView.EndEdit();
                hidePanelEdit(true);
                btnHieuChinh.Enabled = btnXoa.Enabled = btnThem.Enabled = true;

                if (currentRowView.Row.RowState == DataRowState.Unchanged) return;
                if (currentRowView.Row.RowState == DataRowState.Detached)
                {
                    myStack.Push(Action.ADDED, (DataRowView)bdsSinhVien.Current);
                    DS_SV.SINHVIEN.Rows.Add(currentRowView.Row);
                }
                else if (currentRowView.Row.RowState == DataRowState.Modified)
                    myStack.Push(Action.MODIFIED, bdsSinhVien.Position, (DataRowView)bdsSinhVien.Current);

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
                btnHieuChinh.Enabled = btnXoa.Enabled  = btnThem.Enabled= true;
                //trường hợp chưa nhấn xong thì nhấn ghi
                myStack.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lưu sinh viên\n" + ex.Message,"", MessageBoxButtons.OK);
            }
            finally
            {
                hidePanelEdit(true);
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
            currentRowView = (DataRowView)bdsSinhVien.Current;
            if(currentRowView.Row.RowState == DataRowState.Added)
            {
                myStack.Push(Action.DELETED_NEW_ROW,currentRowView,currentRowView.Row.ItemArray);

                currentRowView.Row.RejectChanges();
            }
            else if (currentRowView.Row.RowState == DataRowState.Modified)
            {
                myStack.Push(Action.DELETED_MODIFIED_ROW, currentRowView,currentRowView.Row.ItemArray);
                currentRowView.Row.Delete();
            }
            else
            {
                myStack.Push(Action.DELETED, currentRowView);
                currentRowView.Row.Delete();
            }

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (myStack.getSize() == 0) return;
            action = myStack.Pop();
            switch(action.action)
            {
                
                case 1:
                    //Bỏ đi dòng mới thêm
                    // Added => Detached
                    action.data.Row.RejectChanges();
                    break;
                case 2:
                    //Phục hồi trên dòng củ modifed=>unchage
                    action.data.Row.RejectChanges();
                    action.data.Row.AcceptChanges();
                    break;
                case 3:
                    action.data.Row.RejectChanges();
                    action.data.Row.AcceptChanges();
                    break;
                case 4:
                    //4 Phục hồi khi xóa dòng vừa thêm
                    //khôi phục lại dữ liệu cho dòng bị xóa
                    action.data.Row.ItemArray = action.objects.ToArray();
                    DS_SV.SINHVIEN.Rows.Add(action.data.Row);
                    break;
                case 5:
                    // Phục hồi từ delete=> modified
                    //phục hồi 
                    action.data.Row.RejectChanges();
                    //đưa dữ liệu trở lại
                    action.data.Row.ItemArray = action.objects.ToArray();
                    break;
            }
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
            hidePanelEdit(false);
            vitri = bdsSinhVien.Position;
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
            hidePanelEdit(true);
            myStack.TriggerEvent();
            btnThem.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = true;
        }
    }
}
