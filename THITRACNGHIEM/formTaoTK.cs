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
    public partial class formTaoTK : Form
    {
        private DataTable dt;
        private DataRow currentDataRow;
        public formTaoTK()
        {
            InitializeComponent();
        }

        private void formTaoTK_Load(object sender, EventArgs e)
        {
            dt = Program.ExecSqlDataTable("EXEC SP_LAYDANHSACHGV");
            dt.PrimaryKey = new DataColumn[] { dt.Columns["MAGV"] };
            cmbHoVaTen.DataSource = dt;
            cmbHoVaTen.DisplayMember = "HOVATEN";
            cmbHoVaTen.ValueMember = "MAGV";
            cmbHoVaTen.SelectedIndex = 0;

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("TENNHOM");
            dt1.Columns.Add("NHOM");
            dt1.Rows.Add("TRƯỜNG", "TRUONG");
            dt1.Rows.Add("CƠ SỞ", "COSO");
            dt1.Rows.Add("GIẢNG VIÊN", "GIANGVIEN");
            cmbNhom.DataSource = dt1;
            cmbNhom.DisplayMember = "TENNHOM";
            cmbNhom.ValueMember = "NHOM";
            this.cmbHoVaTen.SelectedIndexChanged += new System.EventHandler(this.cmbHoVaTen_SelectedIndexChanged);
            cmbHoVaTen_SelectedIndexChanged(null, null);

   
        }

        private void cmbHoVaTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllMesages();
            txtMaGV.Text = cmbHoVaTen.SelectedValue.ToString();
            currentDataRow = ((DataRowView)cmbHoVaTen.SelectedItem).Row;
            getLoginNameAndGroup(txtMaGV.Text);
        }
        private void getLoginNameAndGroup(String username)
        {
            SqlDataReader dr = Program.ExecSqlDataReader("EXEC SP_LAYLGNAME_VA_NHOM " + username);
            String nhom;
            if (dr.Read())
            { 
                txtTK.Text = dr[0].ToString();
                nhom = dr[1].ToString();
                cmbNhom.SelectedValue = nhom.Trim();
                txtTK.Enabled = cmbNhom.Enabled =  txtMK.Enabled = false;
                btnTaoTK.Enabled = false;
                btnDoiMK.Enabled = true;
                if(!txtMaGV.Text.Trim().Equals(Program.username.Trim())) 
                    if (Program.mGroup.Equals("TRUONG") && nhom.Equals("TRUONG")) btnXoaTK.Enabled = true;
                    else if(Program.mGroup.Equals("COSO") &&( nhom.Equals("COSO")||nhom.Equals("GIANGVIEN"))) btnXoaTK.Enabled = true;
                    else btnXoaTK.Enabled = false;
                else btnDoiMK.Enabled = false;
            }
            else
            {
                txtTK.Text = "";
                txtMK.Text = "";
                txtTK.Enabled = txtMK.Enabled = cmbNhom.Enabled = true;
                cmbNhom.SelectedIndex = -1;
                btnTaoTK.Enabled = true;
                btnXoaTK.Enabled = false;
                btnDoiMK.Enabled = false;
            }
            dr.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearAllMesages()
        {
            lblMessage.Text = lblLoiTK.Text = lblLoiMK.Text = lblLoiNhom.Text = "";
        }
        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if(txtTK.Text==null && txtTK.Text.Equals(""))
            {
                lblLoiTK.Text = "Tên tài khoảng không được trống";
                return;
            }
            if (txtMK.Text == null && txtTK.Text.Equals(""))
            {
                lblLoiMK.Text = "Mật khẩu không được trống";
                return;
            }
            if (cmbNhom.SelectedIndex <0)
            {
                lblLoiNhom.Text = "Vui lòng chọn nhóm";
                return;
            }
            ClearAllMesages();
            int check = Program.ExecSqlNonQuery("EXEC SP_TAOLOGIN " + txtTK.Text + ", " + txtMK.Text + ", " + txtMaGV.Text + ", " + cmbNhom.SelectedValue.ToString());
            if (check != 0)
            {
                lblMessage.Text = "Tạo thất bại";
                return;
            }
            else lblMessage.Text = "Tạo thành công";
            txtTK.Enabled = txtMK.Enabled = cmbNhom.Enabled = false;
            btnTaoTK.Enabled = false;
            btnXoaTK.Enabled = true;
            btnDoiMK.Enabled = true;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if(btnDoiMK.Text == "Đổi mật khẩu")
            {
                txtMK.Enabled = true;
                btnDoiMK.Text = "Lưu";
                return;
            }

            if(txtMK.Text.Length == 0)
            {
                lblLoiMK.Text = "Mật khẩu không được trống";
                return;
            }
            ClearAllMesages() ; 
           int check =  Program.ExecSqlNonQuery("EXEC sp_password NULL,  '" + txtMK.Text  + "', '"+txtTK.Text+"'");
            
            if(check != 0)
            {
                lblMessage.Text = "Đổi mật khẩu thất bại";
            }
            else
            {
                lblMessage.Text = "Đổi mật khẩu thành công";
            }
            txtMK.Enabled = false;
            btnDoiMK.Text = "Đổi mật khẩu";
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            int check = Program.ExecSqlNonQuery("Exec SP_XOALOGIN " + txtTK.Text + "," + txtMaGV.Text + "," + cmbNhom.SelectedValue.ToString());
            if (check != 0)
            {
                lblMessage.Text = "Xóa thất bại";
                return;
            }
            else lblMessage.Text = "Xóa thành công";
            txtTK.Enabled = txtMK.Enabled = cmbNhom.Enabled = true;
            btnTaoTK.Enabled = true;
            btnXoaTK.Enabled = false;
            btnDoiMK .Enabled = false;
        }
    }
}
