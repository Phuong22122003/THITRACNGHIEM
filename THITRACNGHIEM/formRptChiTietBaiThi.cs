using DevExpress.XtraReports.UI;
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
    public partial class formRptChiTietBaiThi : Form
    {
        public formRptChiTietBaiThi()
        {
            InitializeComponent();

        }





        private void formRptChiTietBaiThi_Load(object sender, EventArgs e)
        {
           
            this.dSChiTietBaiThi.EnforceConstraints = false;

            

            if (Data.mGroup != "SINHVIEN")
            {
                this.LOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.LOPTableAdapter.Fill(this.dSChiTietBaiThi.LOP);

                this.SINHVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.SINHVIENTableAdapter.Fill(this.dSChiTietBaiThi.SINHVIEN);

                this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.MONHOCTableAdapter.Fill(this.dSChiTietBaiThi.MONHOC, "undefined");


            } else
            {
                this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.MONHOCTableAdapter.Fill(this.dSChiTietBaiThi.MONHOC, Data.mlogin);

                lblHoTen.Visible = false;
                lblLop.Visible = false;
                
                this.cmbLop.Visible = false;
                this.cmbMaSV.Visible = false;
               
            }
            //this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.MONHOCTableAdapter.Fill(this.dSChiTietBaiThi.MONHOC);


            this.cmbCoSo.DataSource = Data.bds_dspm;
            this.cmbCoSo.DisplayMember = "TENCS";
            this.cmbCoSo.ValueMember = "TENSERVER";
            this.cmbCoSo.SelectedIndex = Data.mCoSo;
          
            if (Data.mGroup == "TRUONG")
            {
                cmbCoSo.Enabled = true;
            } else
            {
                cmbCoSo.Enabled = false;
            }

            cmbLanThi.SelectedIndex = 0;
            
             
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cmbMaSV.SelectedValue == null && Data.mGroup != "SINHVIEN")
            {
                MessageBox.Show("Lớp không có sinh viên!", "",MessageBoxButtons.OK);
                return;
            }
            xrpt_ChiTietBaiThi rpt;
            if (Data.mGroup == "SINHVIEN")
            {
                rpt = new xrpt_ChiTietBaiThi(Data.mlogin, cmbMaMH.SelectedValue.ToString(), int.Parse(cmbLanThi.Text));
            }
            else
            {
                rpt = new xrpt_ChiTietBaiThi(cmbMaSV.SelectedValue.ToString(), cmbMaMH.SelectedValue.ToString(), int.Parse(cmbLanThi.Text));
            }
            string command;
            if (Data.mGroup == "SINHVIEN")
            {
                command = "EXEC SP_FindNgayThiTenLop '" + Data.mlogin + "', '" + cmbMaMH.SelectedValue.ToString() + "', " + cmbLanThi.Text;
            }
            else
            {
                command = "EXEC SP_FindNgayThiTenLop '" + cmbMaSV.SelectedValue.ToString() + "', '" + cmbMaMH.SelectedValue.ToString() + "', " + cmbLanThi.Text;
            }

            SqlDataReader reader = Data.ExecSqlDataReader(command,Data.ServerConnection);
            DateTime ngayThi = DateTime.Today.Date;
            String tenLop = "";
            Boolean isExist = false;
            try
            {
                while (reader.Read())
                {
                    isExist = true;
                    ngayThi = Convert.ToDateTime(reader["NGAYTHI"]).Date;
                    tenLop = reader["TENLOP"].ToString();
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            if (!isExist)
            {
                MessageBox.Show("Không có thông tin!", "", MessageBoxButtons.OK);
                return;
            }
            rpt.lblLop.Text = tenLop;
            rpt.lblNgayThi.Text = ngayThi.ToString();
            if (Data.mGroup == "SINHVIEN")
            {
                rpt.lblHoTen.Text = Data.mHoten;
            } else
            {
                rpt.lblHoTen.Text = cmbMaSV.Text;
            }
            rpt.lblMon.Text = cmbMaMH.Text;
            rpt.lblLanThi.Text = cmbLanThi.Text;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
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
            if (Data.ConnectToServerWhenLogin(false)==0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới");
            }
            else
            {
                this.LOPTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.LOPTableAdapter.Fill(this.dSChiTietBaiThi.LOP);
                this.SINHVIENTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.SINHVIENTableAdapter.Fill(this.dSChiTietBaiThi.SINHVIEN);
                this.MONHOCTableAdapter.Connection.ConnectionString = Data.ServerConnectionString;
                this.MONHOCTableAdapter.Fill(this.dSChiTietBaiThi.MONHOC, "undefined");
            }
        }

        private void malopComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void malopLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
