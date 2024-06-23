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
            if (Data.mlogin.Length > 0)
            {
                btnDangNhap.Enabled = false;
                return;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblErrorLoginName.Visible = false;
            lblErrorPassword.Visible = false ;
            if (inputTK.Text.Trim().Length == 0) lblErrorLoginName.Visible = true;
            if (inputMK.Text.Trim().Length == 0) lblErrorPassword.Visible = true;

            if(lblErrorLoginName.Visible || lblErrorPassword.Visible)
            {
                return;
            }
            Data.mServerName = Data.servername = cmbCoSo.SelectedValue.ToString();
            Data.mCoSo = cmbCoSo.SelectedIndex;
            //Trường hợp là giảng viên
            if (radioGiaoVien.Checked == true)
            {
                Data.mlogin = inputTK.Text;
                Data.password = inputMK.Text;
                if (Data.ConnectToServerWhenLogin() != 1) return;
                //Kết nối thành công
                try
                {
                    Dictionary<String,String> teacherInfo = Data.getTeacherInfo(Data.mlogin);
                    //Kết nối thành công và lấy dữ liệu

                    Data.username = teacherInfo["USERNAME"];
                    Data.mHoten = teacherInfo["HOVATEN"];
                    Data.mGroup = teacherInfo["NHOM"];
                    Data.mloginDN = Data.mlogin;
                    Data.passwordDN = Data.password;
                    this.parentForm.showInfo(Data.mHoten, Data.mGroup);
                    btnDangNhap.Enabled = false;

                }catch(Exception ex)
                {
                    Data.mlogin = "";
                    Data.password = "";
                    MessageBox.Show(ex.Message);
                }
            }
            //trường hợp là sinh viên
            else
                {
                    Data.mlogin = Data.svlogin;
                    Data.password = Data.svpassword;
                    if (Data.ConnectToServerWhenLogin(false) != 1)
                    {
                        MessageBox.Show("Không thể kết nối đến hệ thống lúc này");
                        return;
                    }

                    try
                    {
                        Dictionary<String,String> studentInfo= Data.getStudentInfo(inputTK.Text, inputMK.Text);
                        Data.mHoten = studentInfo["HOTEN"];
                        Data.tenLop = studentInfo["TENLOP"];
                        Data.mlogin = inputTK.Text;
                        Data.password = inputMK.Text;
                        Data.mGroup = "SINHVIEN";
                        Data.username = Data.mlogin;
                        this.parentForm.showInfo(Data.mHoten, Data.mGroup);
                        btnDangNhap.Enabled = false;
      
                    }
                    catch(Exception ex)
                    {
                            MessageBox.Show("       Đăng nhập thất bại\n" + ex.Message);
                    }
             }
        }
        public void clear()
        {
            this.inputTK.Clear();
            this.inputMK.Clear();
        }
        public void enableBtnDangNhap(bool enable = true)
        { 
            btnDangNhap.Enabled = enable;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}