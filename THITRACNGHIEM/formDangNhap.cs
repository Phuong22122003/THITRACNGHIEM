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
using THITRACNGHIEM;

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
            DataTable danhSachCoso = Data.ExecuteStatementByPublisherConnection("SELECT * FROM V_DS_PHANMANH");
            if(danhSachCoso == null)
            {
                btnDangNhap.Enabled = false;
                return;
            }
            Data.bds_dspm.DataSource = danhSachCoso;
            this.cmbCoSo.DataSource = Data.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            Data.bds_dspm.DataSource = danhSachCoso;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Data.servername = cmbCoSo.SelectedValue.ToString();
            //Trường hợp là giảng viên
            if (radioGiaoVien.Checked == true)
            {
                Data.mlogin = inputTK.Text;
                Data.password = inputMK.Text;
                if (Data.ConnectToServerWhenLogin() != 1) return;
                //Kết nối thành công
                try
                {
                    SqlDataReader reader = Data.ExecSqlDataReader("exec SP_LayThongTinGV " + Data.mlogin,Data.ServerConnection);
                    //Kết nối thành công và lấy dữ liệu
                    if (reader.Read())
                    {
                        Data.username = reader[0].ToString();
                        Data.mHoten = reader[1].ToString();
                        Data.mGroup = reader[2].ToString();
                        Data.mloginDN = Data.mlogin;
                        Data.passwordDN = Data.password;
                        this.parentForm.showInfo(Data.mHoten, Data.mGroup);           
                    }
                    // Kết nối vào cơ sở dữ liệu nhưng chưa đăng ký tài khoảng
                    else
                    {
                        MessageBox.Show("Tài khoảng chưa được đăng ký!");
                        Data.mlogin = "";
                        Data.password = "";
                    }

                }catch(Exception ex)
                {
                        MessageBox.Show(ex.ToString());
                }
                
            }
            //trường hợp là sinh viên
            else
                {
                    Data.mlogin = Data.svlogin;
                    Data.password = Data.svpassword;
                    if (Data.ConnectToServerWhenLogin() != 1) return;
                    
                    SqlDataReader reader = Data.ExecSqlDataReader("exec SP_LayThongTinSV " + inputTK.Text + ", " + inputMK.Text,Data.ServerConnection);
                try
                {

                    if(reader.Read())
                    {
                        Data.mHoten = reader[0].ToString();
                        Data.mlogin = inputTK.Text;
                        Data.password = inputMK.Text;
                        Data.mGroup = "SINH VIÊN";
                        Data.username = Data.mlogin;
                        this.parentForm.showInfo(Data.mHoten, Data.mGroup);           
                    }
                    else
                    {
                        MessageBox.Show("Bạn xem lại user name và password.\n ");
                    }
                    
                }
                catch
                {

                }
             }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}