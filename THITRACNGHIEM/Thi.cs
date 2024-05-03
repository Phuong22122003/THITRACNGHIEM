﻿using DevExpress.XtraReports.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace THITRACNGHIEM
{
    public partial class Thi : Form
    {
        //==============Properties================//

        private int IDBD;
        private int ID_CTDK;
        private int lan;
        private int totalTime;
        private int remainingTime;
        private String mamh;
        private CTBTs ctbt;
        private Timer timer;
        private Thread thread;

        public Thi()
        {
            InitializeComponent();
        }

        public Thi(int IDBD,String mamh, int remainingTime,int totalTime)//Phuc hoi
        {
            this.totalTime = totalTime;
            this.IDBD =IDBD; this.mamh = mamh;
            this.remainingTime = remainingTime * 60;

            InitializeComponent();

            showInfo();

            LoadDeThiDaThi();
            
            SetCTBT();
            
            labelSoCau.Text = (1 + bdsCauHoi.Position).ToString();
            bdsCauHoi.PositionChanged += PositionChanged;
            lvLuaChon.SelectedIndexChanged += listViewIndexChanged;

            ShowLVLuaChon();

            PositionChanged(null, null);
            timer = new Timer();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            UpdateChange();
            timer.Start();
        }
        public Thi(int ID_CTDK, String mamh, int lan, int remainingTime, int totalTime)
        {
            this.totalTime = totalTime;
            this.ID_CTDK = ID_CTDK;
            this.mamh = mamh;
            this.lan = lan;
            this.remainingTime = remainingTime * 60;

            InitializeComponent();

            showInfo();

            LoadDeThiMoi();

            RandomDapAn();

            KhoiTaoDiem();

            //NopBai();//Khởi tạo chi tiết bài thi

            labelSoCau.Text = (1 + bdsCauHoi.Position).ToString();
            bdsCauHoi.PositionChanged += PositionChanged;
            lvLuaChon.SelectedIndexChanged += listViewIndexChanged;

            ShowLVLuaChon();

            PositionChanged(null, null);

            timer = new Timer();
            timer.Interval = 980;
            timer.Tick += Timer_Tick;
            UpdateChange();
            timer.Start();
        }


        private void LoadDeThiMoi()
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
        private void LoadDeThiDaThi()
        {
            try
            {
                this.SP_LAYCAUHOITHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.DS_THI.EnforceConstraints = false;
                this.SP_PHUCHOICAUHOITHITableAdapter.Fill(this.DS_THI.SP_PHUCHOICAUHOITHI, this.IDBD, this.mamh);
               // if (this.bdsCauHoi.Count == 0) this.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        //====================Hàm tự viết=======================================//

        private void showInfo()
        {
            txtMaSV.Text = Program.username;
            txtHoTen.Text = Program.mHoten;
            txtThoiGian.Text = this.totalTime.ToString();
            txtConLai.Text = this.remainingTime.ToString();
        }
        private void SetCTBT()
        {
            int thuTu = 1;

            //Khởi tạo ctbt
            ctbt = new CTBTs(bdsCauHoi.Count);

            // Khởi tạo mảng chứa các đáp án
            Dictionary<int,char> answers = new Dictionary<int,char>();
            CTBT ct;
            foreach (DataRow dt in DS_THI.SP_PHUCHOICAUHOITHI.Rows)
            {
                answers.Add(int.Parse(dt["THUTU_A"].ToString()), 'A');
                answers.Add(int.Parse(dt["THUTU_B"].ToString()), 'B');
                answers.Add(int.Parse(dt["THUTU_C"].ToString()), 'C');
                answers.Add(int.Parse(dt["THUTU_D"].ToString()), 'D');
                ct = new CTBT();
                ct.DapAn_Thutu.Add(answers[1]);
                ct.DapAn_Thutu.Add(answers[2]);
                ct.DapAn_Thutu.Add(answers[3]);
                ct.DapAn_Thutu.Add(answers[4]);
                ct.CauHoi = (int)dt["CAUHOI"];
                ct.ThuTu = thuTu;
                Console.WriteLine(dt["DAP_AN"]);
                ct.Dap_An = (char)dt["DAP_AN"].ToString()[0];
                ct.LuaChonSV = (char)dt["LUACHONSV"].ToString()[0];
                thuTu++;
                ctbt.addLuaChon(ct);
               // Object[] row = { dt["CAUHOI"], dt["NOIDUNG"], dt["DAP_AN_A"], dt["DAP_AN_B"], dt["DAP_AN_C"], dt["DAP_AN_D"], dt["DAP_AN"] };
                bdsCauHoi.AddNew();
                DataRow row = ((DataRowView)bdsCauHoi.Current).Row;
                row["NOIDUNG"] = dt["NOIDUNG"];
                row["A"] = dt["DAP_AN_A"];
                row["B"] = dt["DAP_AN_B"];
                row["C"] = dt["DAP_AN_C"];
                row["D"] = dt["DAP_AN_D"];
                answers.Clear();
            }
        }
        //1 Tạo đáp án ngẫu nhiên
        private void RandomDapAn()
        {
            int thuTu = 1;

            Random rnd = new Random();

            //Khởi tạo ctbt
            ctbt = new CTBTs(bdsCauHoi.Count);

            // Khởi tạo mảng chứa các đáp án
            char[] answers = { 'A', 'B', 'C', 'D' };
            CTBT ct;
            foreach (DataRow dt in DS_THI.SP_LAYCAUHOITHI.Rows)
            {

                ct = new CTBT();

                // sắp xếp thứ tự theo ngẫu nhiên
                answers = answers.OrderBy(x => rnd.Next()).ToArray();

                ct.DapAn_Thutu.Add(answers[0]);
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
        //2.Khởi tạo dòng điểm trong BANGDIEM
        private void KhoiTaoDiem()
        {
            DataTable dt = new DataTable();
            layCTBTs(dt);
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = "dbo.TYPE_CTBT";
            param.Value = dt;
            param.ParameterName = "@CTBAITHI";
            SqlCommand cmd = new SqlCommand("SP_KHOITAOBD", Program.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@masv", Program.username);
            cmd.Parameters.AddWithValue("@mamh", this.mamh);
            cmd.Parameters.AddWithValue("@lan", this.lan);
            cmd.Parameters.AddWithValue("@thoiGianConLai", this.totalTime);
            try
            {
                IDBD=(int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khởi tạo điểm thất bại" + ex.Message);
                throw ex;
            }
            //String strLenh = "exec SP_KHOITAOBD " + Program.username + ", " + mamh + ", " + lan+","+totalTime;
           
            //IDBD = Program.ExecuteScalar(strLenh);//lấy IDBD sau khi ghi điểm
            //if(IDBD == -1)
            //{
            //    throw new Exception("Lỗi khởi tạo điểm thi!");
            //}
         
        }
        private float layCTBTs(DataTable returnDataTable)
        {
            //returnDataTable= new DataTable();
            returnDataTable.Columns.Add("CAUHOI", typeof(int));
            returnDataTable.Columns.Add("IDBD", typeof(int));
            returnDataTable.Columns.Add("THUTU", typeof(int));
            returnDataTable.Columns.Add("LUACHONSV", typeof(char));
            returnDataTable.Columns.Add("A", typeof(int));
            returnDataTable.Columns.Add("B", typeof(int));
            returnDataTable.Columns.Add("C", typeof(int));
            returnDataTable.Columns.Add("D", typeof(int));
            int soCauDung = 0;
            float diem;
            foreach (CTBT ct in ctbt.getList())
            {
                if (ct.LuaChonSV != '\0')
                    returnDataTable.Rows.Add(ct.CauHoi, IDBD, ct.ThuTu, ct.LuaChonSV, ct.DapAn_Thutu.IndexOf('A') + 1, ct.DapAn_Thutu.IndexOf('B') + 1, ct.DapAn_Thutu.IndexOf('C') + 1, ct.DapAn_Thutu.IndexOf('D') + 1);
                else
                    returnDataTable.Rows.Add(ct.CauHoi, IDBD, ct.ThuTu, null, ct.DapAn_Thutu.IndexOf('A') + 1, ct.DapAn_Thutu.IndexOf('B') + 1, ct.DapAn_Thutu.IndexOf('C') + 1, ct.DapAn_Thutu.IndexOf('D') + 1);
                if (ct.LuaChonSV != '\0' && ct.DapAn_Thutu[ct.LuaChonSV - 'A'] == ct.Dap_An) soCauDung++;
            }
            diem = (float)soCauDung / ctbt.getList().Count;
            diem = (float)Math.Round(diem, 2) * 10;
            return diem;
        }
        private float NopBai()
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("CAUHOI", typeof(int));
            //dt.Columns.Add("IDBD", typeof(int));
            //dt.Columns.Add("THUTU", typeof(int));
            //dt.Columns.Add("LUACHONSV", typeof(char));
            //dt.Columns.Add("A", typeof(int));
            //dt.Columns.Add("B", typeof(int));
            //dt.Columns.Add("C", typeof(int));
            //dt.Columns.Add("D", typeof(int));
            //int soCauDung = 0;
            //float diem;
            //foreach (CTBT ct in ctbt.getList())
            //{
            //    if (ct.LuaChonSV != '\0')
            //        dt.Rows.Add(ct.CauHoi, IDBD, ct.ThuTu, ct.LuaChonSV, ct.DapAn_Thutu.IndexOf('A')+1, ct.DapAn_Thutu.IndexOf('B')+1, ct.DapAn_Thutu.IndexOf('C')+1, ct.DapAn_Thutu.IndexOf('D') + 1);
            //    else
            //        dt.Rows.Add(ct.CauHoi, IDBD, ct.ThuTu, null, ct.DapAn_Thutu.IndexOf('A') + 1, ct.DapAn_Thutu.IndexOf('B') + 1, ct.DapAn_Thutu.IndexOf('C') + 1, ct.DapAn_Thutu.IndexOf('D') + 1);
            //    if (ct.LuaChonSV != '\0' && ct.DapAn_Thutu[ct.LuaChonSV - 'A'] == ct.Dap_An) soCauDung++;
            //}
            //diem = (float)soCauDung / ctbt.getList().Count;
            //diem = (float)Math.Round(diem, 2) *10;
            DataTable dt = new DataTable();
            float diem = layCTBTs(dt);
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
                return diem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nộp bài thất bại" + ex.Message);
                throw ex;
            }
        }


        private void GhiDiem(float diem)
        {

            String strLenh = "UPDATE BANGDIEM SET DIEM = "+diem + ", TGCONLAI =0 WHERE IDBD = "+IDBD;
            int check =  Program.ExecSqlNonQuery(strLenh);
            if (check != 0) MessageBox.Show("Lỗi ghi điểm thi");
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
            if (ctbt.getCTBT(bdsCauHoi.Position).LuaChonSV != '\0')
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

        private void ShowLVLuaChon()
        {
            ListViewItem item;

            DataRow dt;
            for (int i = 0; i < bdsCauHoi.Count; i++)
            {
                item = new ListViewItem("Câu " + (i + 1).ToString());
                // Thêm các cột A, B, C, D vào ListViewItem
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                lvLuaChon.Items.Add(item);
                if (DS_THI.SP_PHUCHOICAUHOITHI.Rows.Count == 0) continue;
                dt =DS_THI.SP_PHUCHOICAUHOITHI.Rows[i];
                if (dt["LUACHONSV"].ToString() =="A") item.SubItems[1].Text = "✔️";
                else if (dt["LUACHONSV"].ToString() =="B") item.SubItems[2].Text = "✔️";
                else if (dt["LUACHONSV"].ToString() == "C") item.SubItems[3].Text = "✔️";
                else if (dt["LUACHONSV"].ToString() =="D") item.SubItems[4].Text= "✔️";
            }
        }
        // ======================Xử lý sự kiện====================//
        //1 Nôp bài
        private void btnNopBai_Click(object sender, EventArgs e)
        {
            remainingTime = 0;
            thread.Join();
            timer.Stop();
            float diem = NopBai();
            GhiDiem(diem);
            MessageBox.Show("Nộp thành công\n" + "            Điểm: " + diem);
            this.Close();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bdsCauHoi.MovePrevious();
            labelSoCau.Text = (1 + bdsCauHoi.Position).ToString();
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
            if (radioA.Checked)
            {
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'A');
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[1].Text = "✔️";
            }
            else if (radioB.Checked)
            {
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[2].Text = "✔️";
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'B');
            }
            else if (radioC.Checked)
            {
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[3].Text = "✔️";
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'C');
            }
            else if (radioD.Checked)
            {
                lvLuaChon.Items[bdsCauHoi.Position].SubItems[4].Text = "✔️";
                ctbt.setLuaChonSV(bdsCauHoi.Position, 'D');
            }
        }
        private void UpdateTimerDisplay()
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;
            txtConLai.Text = string.Format("{0}:{1:00}", minutes, seconds);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            // Hiển thị thời gian còn lại
            UpdateTimerDisplay();

            if (remainingTime <= 0)
            {
                //timer.Stop();
                btnNopBai_Click(null, null);
            }
        }
        private void listViewIndexChanged(object sender, EventArgs e)
        {
            if (lvLuaChon.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = lvLuaChon.SelectedItems[0];
                bdsCauHoi.Position = selectedRow.Index;
                labelSoCau.Text = (1 + selectedRow.Index).ToString();
            }
        }

        //==============Update======================
        private void UpdateChange()
        {
            thread  = new Thread(() => { updateCTBT(); });
            thread.Start();
            thread.IsBackground = true;
        }
        private void updateCTBT()
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
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = "dbo.TYPE_CTBT";
            param.ParameterName = "@CTBAITHI";
            SqlCommand cmd = new SqlCommand("SP_LUU_CTBT", Program.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            while (this.remainingTime > 0)
            {   
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (this.remainingTime % 60 != 0) continue;
                String strLenh = "UPDATE BANGDIEM SET TGCONLAI = "+this.remainingTime+"WHERE IDBD = " + IDBD;
                int check = Program.ExecSqlNonQuery(strLenh);
                if (check != 0) MessageBox.Show("Lỗi ghi điểm thi");
                foreach (CTBT ct in ctbt.getList())
                {
                    if (ct.LuaChonSV != '\0')
                        dt.Rows.Add(ct.CauHoi, IDBD,null, ct.LuaChonSV,null,null,null,null);
                }
                param.Value = dt;

                try
                {
                    cmd.ExecuteNonQuery();
                    dt.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update thất bại" + ex.Message);
                }
            }
        
        }

    }
}
