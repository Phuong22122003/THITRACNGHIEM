using DevExpress.XtraCharts.Native;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace THITRACNGHIEM
{
    internal class Data
    {
        public static String servernameTraCuu = "PHUONG\\MSSQLSERVER03";

        //dùng lưu trử thông tin người dùng
        public static String servername = "";//tên server kết nối tới
        public static String username = "";//mã
        public static String mlogin = "";//tên đăng nhập
        public static String password = "";//mật khẩu

        //pass và loginname của sinh viên
        public static String svlogin = "SV";
        public static String svpassword = "123456789";

        //site tra cứu
        public static String database = "TN_CSDLPT";
        public static String remotelogin = "sa";
        public static String remotepassword = "123456789";

        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String mHoten = "";

        public static int mCoSo = 0;

        public static BindingSource bds_dspm = new BindingSource();  // giữ bdsPM khi đăng nhập

        //Kết nối với site chủ để lấy thông tin về server khác
        public static SqlConnection PublisherConnection;
        //Connection String của site chủ
        public static String PublisherConnectionString="Data Source=PHUONG;Initial Catalog=TN_CSDLPT;Integrated Security=True";
        //Kết nối về site của người dùng
        public static SqlConnection ServerConnection;
        //ConnectionString của site người dùng
        public static String ServerConnectionString;
        //Kết nối về site tra cứu
        public static SqlConnection InformationRetrievalSite;
        //ConnectionString của site tra cứu
        public static String InformationRetrievalSiteConnectionString;


        //--------------------------------Connect------------------------------------------//

        public static int ConnectToRetrievalSite()
        {
            if (Data.InformationRetrievalSite == null) Data.InformationRetrievalSite = new SqlConnection();
            else if (Data.InformationRetrievalSite.State == ConnectionState.Open) Data.InformationRetrievalSite.Close();
            Data.InformationRetrievalSite.ConnectionString = "Data Source=" + Program.servernameTraCuu + ";Initial Catalog=" +Program.database + ";User ID=" +
                                                                                                                                    Program.remotelogin + ";password=" + Program.remotepassword;
            try
            {
                Data.InformationRetrievalSite.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới trang tra cứu\n" + ex.Message);
                return 0;
            }
        }
        public static void ConnectToPublisher()
        {
            if(Data.PublisherConnection == null) Data.PublisherConnection = new SqlConnection(Data.PublisherConnectionString);
            try
            {
                Data.PublisherConnection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu\n"+ex.Message);
                throw ex;
            }
        }
        public static int ConnectToServerWhenLogin()
        {
            if (Data.ServerConnection != null && Data.ServerConnection.State == ConnectionState.Open)
                Data.ServerConnection.Close();
            else if (Data.ServerConnection == null) Data.ServerConnection = new SqlConnection();
            try
            {
                Data.ServerConnectionString = "Data Source=" + Data.servername+ ";Initial Catalog=" +
                Data.database+ ";User ID=" +
                Data.mlogin + ";password=" + Data.password;
                Data.ServerConnection.ConnectionString = Data.ServerConnectionString;
                Data.ServerConnection.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("             Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n           " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }
        //--------------------------------Execute------------------------------------------//
        // Thực thi lệnh bằng connection đến publisher
        public static DataTable ExecuteStatementByPublisherConnection(string statement)
        {
            if(Data.PublisherConnection == null)
            {
                try
                {
                Data.ConnectToPublisher();
                }
                catch
                {
                    return null;
                }
            }
            if(Data.PublisherConnection.State ==ConnectionState.Closed) Data.PublisherConnection.Open ();
            DataTable table = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(statement,Data.PublisherConnection);
            try
            {
                sqlDataAdapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! không thể thực thi lệnh\n" + ex.Message);
                return null;
            }
            finally { Data.PublisherConnection.Close(); }
        }
        //thực thi lệnh bằng connection đến server hiện tại
        public static DataTable ExecuteStatementByServerConnection(String statement)
        {
            if(Data.ServerConnection == null)
            {
                try
                {
                    Data.ConnectToServerWhenLogin();
                }
                catch
                {
                    return null;
                }
            }
            if (Data.ServerConnection.State == ConnectionState.Closed) Data.ServerConnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(statement, Data.ServerConnection);
            try
            {
                sqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi! không thể thực thi lệnh\n" + ex.Message);
                return null;
            }
            finally
            {
                Data.ServerConnection.Close();
            }
        }
        public static DataTable ExecuteStatementByRetrievalSiteConnection(String statement)
        {
            if (Data.InformationRetrievalSite == null)
            {
                try
                {
                    Data.ConnectToRetrievalSite();
                }
                catch
                {
                    return null;
                }
            }
            if (Data.InformationRetrievalSite.State == ConnectionState.Closed) Data.InformationRetrievalSite.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(statement, Data.InformationRetrievalSite);
            try
            {
                sqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi! không thể thực thi lệnh\n" + ex.Message);
                return null;
            }
            finally
            {
                Data.InformationRetrievalSite.Close();
            }
        }

        //-----------------------excute chung----------------------------------//
        public static DataTable ExecSqlDataTable(String cmd,SqlConnection connection)
        {
            DataTable dt = new DataTable();
            if (connection.State == ConnectionState.Closed) connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, connection);
            try
            {
                da.Fill(dt); 
                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { connection.Close(); }
        }
        public static int ExecuteScalar(String strlenh, SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
            SqlCommand Sqlcmd =  new SqlCommand(strlenh, connection);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            try
            {
                return (int)Sqlcmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
            finally
            {
                connection.Close();
            }
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh,SqlConnection connection)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh,connection);
            sqlcmd.CommandType = CommandType.Text;
            if (connection.State == ConnectionState.Closed) connection.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); 
                return myreader;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                //connection.Close();
            }
        }
        public static int ExecSqlNonQuery(String strlenh,SqlConnection connection)
        {
            if(connection.State==ConnectionState.Closed) connection.Open();
            SqlCommand Sqlcmd = new SqlCommand(strlenh, connection);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (connection.State == ConnectionState.Closed) connection.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
            finally
            {
                connection.Close();
            }
        }
    }
  
}
