using DevExpress.XtraEditors;
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

namespace WindowsFormsApp1
{
    public partial class formDangNhap : Form
    {
        
        public formDangNhap(formMain parent)
        {
            this.parentForm = parent;   
            InitializeComponent();
        }

        private void formDangNhap_Load(object sender, EventArgs e)
        {
            loadCoSO();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String loginName;
            String password;
            Program.servername = cmbCoSo.SelectedValue.ToString();
            loginName= Program.mloginDN = Program.mlogin = inputTK.Text;
            password= Program.passwordDN = Program.password = inputMK.Text;
            Program.mCoSo = cmbCoSo.SelectedIndex;
            if (Program.KetNoi() == 1)
            {
                SqlDataReader reader =  Program.ExecSqlDataReader("exec SP_LayThongTinDangNhap " + Program.mlogin);
                if (reader.Read())this.parentForm.showInfo((String)reader[0], (String)reader[1]);
                
                else MessageBox.Show("Tài khoảng không hợp lệ");
            }
            else
            {
                Program.mlogin = Program.svlogin;
                Program.password = Program.svpassword;
                if (Program.KetNoi(true) == 1)
                {
                SqlDataReader reader = Program.ExecSqlDataReader("exec  Sp_LayThongTinSinhVien '" + loginName + "' , '"+ password+"'" );
                Console.WriteLine(loginName+ ' '+ password);
                    if (reader.Read()) this.parentForm.showInfo((String)reader[0], "SINHVIEN");
                    else MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n ", "", MessageBoxButtons.OK);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadCoSO()
        {
            DataTable tmp = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Program.connstr_publisher;
            if (conn.State == ConnectionState.Closed)conn.Open();
            String statement = "SELECT * FROM V_DS_PHANMANH";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(statement,conn);
            sqlDataAdapter.Fill(tmp);
            this.cmbCoSo.DataSource = tmp;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            Program.bds_dspm.DataSource = tmp;
            conn.Close();
        }


    }
}