using DevExpress.XtraReports.Parameters;
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
    public partial class Thi : Form
    {
        private CTBTs ctbt;
        private int IDBD;
        private int ID_CTDK;
        private String mamh;
        private int lan;

        public Thi()
        {
            InitializeComponent();
            LoadDeThi();
        }    
        public Thi(int ID_CTDK,String mamh,int lan)
        {
            this.ID_CTDK = ID_CTDK;
            this.mamh = mamh;
            this.lan = lan;
            InitializeComponent();
            try
            {
                LoadDeThi();

                RandomDapAn();

                KhoiTaoDiem();

                button1_Click(null, null);//Lưu CTBT

                labelSoCau.Text = (1 + bdsCauHoi.Position).ToString();

                bdsCauHoi.PositionChanged += PositionChanged;
                
                ShowLVLuaChon();
                
                PositionChanged(null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadDeThi()
        {
            try
            {
                this.SP_LAYCAUHOITHITableAdapter.Connection.ConnectionString = Program.connstr; 
                this.SP_LAYCAUHOITHITableAdapter.Fill(this.DS_THI.SP_LAYCAUHOITHI, ID_CTDK);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void KhoiTaoDiem()
        {
            String strLenh = "exec SP_KHOITAOBD @masv,@mamh,@lan";
            SqlCommand cmd = new SqlCommand(strLenh,Program.conn);
            cmd.Parameters.Add("@masv",SqlDbType.NVarChar);
            cmd.Parameters["@masv"].Value = Program.username;
            cmd.Parameters.Add("@mamh",SqlDbType.NVarChar);
            cmd.Parameters["@mamh"].Value = mamh;
            cmd.Parameters.Add("@lan",SqlDbType.Int);
            cmd.Parameters["@lan"].Value = lan;
            try
            {
                if(Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                IDBD =(Int32)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void GhiDiem(float diem) 
        {
            String strLenh = "UPDATE BANGDIEM SET DIEM = @DIEM WHERE IDBD = @IDBD";
            SqlCommand cmd = new SqlCommand(strLenh, Program.conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DIEM", SqlDbType.Float);
            cmd.Parameters["@DIEM"].Value = diem;   
            cmd.Parameters.Add("@IDBD", SqlDbType.Int);
            cmd.Parameters["@IDBD"].Value = IDBD;
            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                {
                    Program.conn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi điểm" + ex.Message);
            }
        }
        private void RandomDapAn()
        {
            int thuTu = 1;
            Random rnd = new Random();
            ctbt = new CTBTs(bdsCauHoi.Count);
            char[] answers = { 'A', 'B', 'C', 'D' };
            foreach(DataRow dt in DS_THI.SP_LAYCAUHOITHI.Rows)
            {
                // Khởi tạo mảng chứa các đáp án
                CTBT ct = new CTBT();
                // Sử dụng phương pháp Fisher-Yates để đảo ngẫu nhiên các phần tử trong mảng
                answers = answers.OrderBy(x => rnd.Next()).ToArray();
                ct.DapAn_Thutu.Add( answers[0]);
                ct.DapAn_Thutu.Add(answers[1]);
                ct.DapAn_Thutu.Add(answers[2]);
                ct.DapAn_Thutu.Add(answers[3]);
                ct.CauHoi = (int)dt["CAUHOI"];
                ct.ThuTu = thuTu;
                Console.WriteLine(dt["DAP_AN"]);
                ct.Dap_An = (char)dt["DAP_AN"].ToString()[0];
                thuTu++;
                ctbt.addLuaChon(ct);
            }
        }
        private void PositionChanged(object sender, EventArgs e)
        {
            txtA.Text = (String)((DataRowView)bdsCauHoi.Current).Row[ctbt.getCTBT(bdsCauHoi.Position).DapAn_Thutu[0].ToString()];
            txtB.Text = (String)((DataRowView)bdsCauHoi.Current).Row[ctbt.getCTBT(bdsCauHoi.Position).DapAn_Thutu[1].ToString()];
            txtC.Text = (String)((DataRowView)bdsCauHoi.Current).Row[ctbt.getCTBT(bdsCauHoi.Position).DapAn_Thutu[2].ToString()];
            txtD.Text = (String)((DataRowView)bdsCauHoi.Current).Row[ctbt.getCTBT(bdsCauHoi.Position).DapAn_Thutu[3].ToString()];

            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
            if(ctbt.getCTBT(bdsCauHoi.Position).LuaChonSV!='\0')
                switch (ctbt.getCTBT(bdsCauHoi.Position).LuaChonSV + 1 - 'A')
                {
                    case 1:
                        radioA.Checked = true;
                        break;
                    case 2:
                        radioB.Checked = true;
                        break;
                    case 3:
                        radioC.Checked = true;
                        break;
                    case 4:
                        radioD.Checked = true;
                        break;
                }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bdsCauHoi.MovePrevious();
            labelSoCau.Text = (1+bdsCauHoi.Position).ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bdsCauHoi.MoveNext();
            labelSoCau.Text = (1 + bdsCauHoi.Position).ToString();
        }



        private void RadioButtonClick(object sender, EventArgs e)
        {
            lvLuaChon.Items[bdsCauHoi.Position].SubItems[1].Text = "";
            lvLuaChon.Items[bdsCauHoi.Position].SubItems[2].Text = "";
            lvLuaChon.Items[bdsCauHoi.Position].SubItems[3].Text = "";
            lvLuaChon.Items[bdsCauHoi.Position].SubItems[4].Text = "";
            if (radioA.Checked) { 
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'A');
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[1].Text = "✔️";
            }
            else if (radioB.Checked) {
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[2].Text = "✔️";
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'B');
            }
            else if (radioC.Checked) {
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[3].Text = "✔️";
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'C');
            }
            else if (radioD.Checked) { 
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[4].Text = "✔️";
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'D'); 
            }
        }
        private void ShowLVLuaChon()
        {
            ListViewItem item;


            for(int  i = 0;i<bdsCauHoi.Count;i++)
            {
                item = new ListViewItem("Câu "+(i+1).ToString());
            // Thêm các cột A, B, C, D vào ListViewItem
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                lvLuaChon.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CAUHOI", typeof(int));
            dt.Columns.Add("IDBD", typeof(int));
            dt.Columns.Add("THUTU", typeof(int));
            dt.Columns.Add("LUACHONSV", typeof(char));
            dt.Columns.Add("A", typeof(int));
            dt.Columns.Add("B", typeof(int));
            dt.Columns.Add("C", typeof(int));
            dt.Columns.Add("D", typeof(int));
            int soCauDung = 0;
            float diem;
            foreach(CTBT ct in ctbt.getList())
            {
                if(ct.LuaChonSV != '\0')
                    dt.Rows.Add(ct.CauHoi, IDBD, ct.ThuTu,ct.LuaChonSV,ct.DapAn_Thutu.IndexOf('A'), ct.DapAn_Thutu.IndexOf('B'), ct.DapAn_Thutu.IndexOf('C'), ct.DapAn_Thutu.IndexOf('D'));
                else 
                    dt.Rows.Add(ct.CauHoi, IDBD, ct.ThuTu,null,ct.DapAn_Thutu.IndexOf('A'), ct.DapAn_Thutu.IndexOf('B'), ct.DapAn_Thutu.IndexOf('C'), ct.DapAn_Thutu.IndexOf('D'));
                    Console.WriteLine(ct.CauHoi);
                if (ct.LuaChonSV != '\0' && ct.DapAn_Thutu[ct.LuaChonSV - 'A'] == ct.Dap_An) soCauDung++;
            }
            diem = (float)soCauDung / ctbt.getList().Count;
            diem = (float)Math.Round(diem, 2);
            GhiDiem(diem);
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = "dbo.TYPE_CTBT";
            param.Value = dt;
            param.ParameterName = "@CTBAITHI";
            SqlCommand cmd = new SqlCommand("SP_LUU_CTBT", Program.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nộp thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nộp bài thất bại" + ex.Message);
            }
        }
    }
}
