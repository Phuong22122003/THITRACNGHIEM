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
            DataTable tmp = new DataTable();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Program.connstr_publisher;
           conn.Open();
            String statement = "SELECT * FROM V_DS_PHANMANH";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(statement, conn);
            try
            {
                sqlDataAdapter.Fill(tmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể đăng nhập lúc này!\n" + ex.Message);
                return;
            }
            finally 
            {
                conn.Close(); 
            }
            Program.bds_dspm.DataSource = tmp;
            this.cmbCoSo.DataSource = Program.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            Program.bds_dspm.DataSource = tmp;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Program.servername = cmbCoSo.SelectedValue.ToString();
            if (radioGiaoVien.Checked == true)
            {
                Program.mloginDN =Program.mlogin = inputTK.Text;
                Program.passwordDN =  Program.password = inputMK.Text;
                if (Program.KetNoi(true) == 1)
                {
                    SqlDataReader reader = Program.ExecSqlDataReader("exec SP_LayThongTinGV " + Program.mlogin);
                    if (reader.Read())
                    {
                        Program.username = reader[0].ToString();
                        Program.mHoten = reader[1].ToString();
                        Program.mGroup = reader[2].ToString();
                    }
                    else
                        MessageBox.Show("Tài khoảng chưa được đăng ký!");
                }
            }
            else
                {
                    Program.mlogin = Program.svlogin;
                    Program.password = Program.svpassword;
                    if (Program.KetNoi(true) == 1)
                    {
                        Program.username = Program.mlogin = inputTK.Text;
                        Program.password = inputMK.Text;
                        Program.mGroup = "SINH VIÊN";
                        SqlDataReader reader = Program.ExecSqlDataReader("exec SP_LayThongTinSV " + Program.mlogin + ", " +Program.password);
                            try
                            {
                                if(reader.Read()) 
                                        Program.mHoten = reader[0].ToString();
                                else
                                {
                                    MessageBox.Show("Bạn xem lại user name và password.\n ");
                                }

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }    
                    }
                }
                    this.parentForm.showInfo(Program.mHoten,Program.mGroup);           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}