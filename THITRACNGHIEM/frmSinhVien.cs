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
    public partial class frmSinhVien : Form
    {
        //Lưu vị trí hiện tại
        private int vitri;
        private String connString="";
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_SV);

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
            // Kiểm tra liệu có thêm mới thành công hay không
            this.bdsSinhVien.ListChanged += BdsSinhVien_ListChanged;
            this.cmbCoSo.SelectedIndexChanged += cmbSelected_IndexChanged;
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
                this.cmbCoSo.Enabled = false;
                btnThem.Enabled=btnHieuChinh.Enabled=btnGhi.Enabled=btnXoa.Enabled=btnPhucHoi.Enabled =true;
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
        // Cho phép chỉnh sửa trên các cột của sinh viên
        private void EnableEditColumn(bool allowEdit)
        {
            colMASV.OptionsColumn.AllowEdit = colHO.OptionsColumn.AllowEdit = colTEN.OptionsColumn.AllowEdit = colNGAYSINH.OptionsColumn.AllowEdit  = colDIACHI.OptionsColumn.AllowEdit = colPASSWORD.OptionsColumn.AllowEdit = allowEdit;
        }
        

        private void allowBtnThem(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            //bỏ sự kiện kiểm tra thêm dòng mới đi chờ đến khi thêm dòng mới
            this.bdsSinhVien.PositionChanged -= allowBtnThem;
        }
        private void BdsSinhVien_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {

                Console.WriteLine("bdsChange");
                Console.WriteLine(bdsSinhVien.Position);
                if (validationRow(bdsSinhVien.Position))
                {
                    EnableEditColumn(true);
                }
            }
        }
        //Kiểm tra các cột nhập liệu hợp lý chưa
        private bool validationRow(int position)
        {
            int currentPosition = bdsSinhVien.Position;
            if (position > currentPosition) return false;
            if (((DataRowView)bdsSinhVien[position])["MASV"].ToString().Equals("") || ((DataRowView)bdsSinhVien[position])["MASV"].ToString() == null) return false;
            if (((DataRowView)bdsSinhVien[position])["HO"].ToString().Equals("") || ((DataRowView)bdsSinhVien[position])["HO"].ToString() == null) return false;
            if (((DataRowView)bdsSinhVien[position])["TEN"].ToString().Equals("") || ((DataRowView)bdsSinhVien[position])["TEN"].ToString() == null) return false;
            if (((DataRowView)bdsSinhVien[position])["PASSWORD"].ToString().Equals("") || ((DataRowView)bdsSinhVien[position])["PASSWORD"].ToString() == null) return false;
            return true;
        }
        //Hàm xử lý sự kiện cho từng nút lệnh
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsSinhVien.Position;
            EnableEditColumn(true);
            //thêm dòng mới
            bdsSinhVien.AddNew();
            //thêm hàm cho phép btnThem khi nhập một dòng mới xong
            this.bdsSinhVien.PositionChanged += allowBtnThem;
            btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
            this.SINHVIENTableAdapter.Update(DS_SV.SINHVIEN);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lưu sinh viên\n" + ex.Message,"", MessageBoxButtons.OK);
            }
            EnableEditColumn(false);
        }

            private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Console.WriteLine(bdsBangDiem.Count);
            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Sinh viên đã thi không thể xóa");
                return;
            }
            this.bdsSinhVien.RemoveCurrent();
            this.SINHVIENTableAdapter.Update(DS_SV.SINHVIEN);
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.CancelEdit();
            this.bdsSinhVien.Position = vitri;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
