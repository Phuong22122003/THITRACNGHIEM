﻿using DevExpress.XtraCharts.Native;
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

        public static formMain formChinh;
        /// <summary>
        /// Biến chứa tên server để tra cứu
        /// </summary>
        public static String servernameTraCuu = "PHUONG\\MSSQLSERVER03";

        //dùng lưu trử thông tin người dùng
        /// <summary>
        /// Tên server kết nối tới
        /// </summary>
        public static String servername = "";
        /// <summary>
        /// Mã người dùng
        /// </summary>
        public static String username = "";
        /// <summary>
        /// Tên đăng nhập của người dùng
        /// </summary>
        public static String mlogin = "";
        /// <summary>
        /// Mật khẩu của người dùng
        /// </summary>
        public static String password = "";

        /// <summary>
        /// Mật khẩu dùng cho kết nối tới cơ sở dữ liệu khi sinh viên khi đăng nhập
        /// </summary>
        public static String svlogin = "SV";
        /// <summary>
        /// Password dùng cho kết nối cơ sở dữ liệu khi sinh viên khi đăng nhập
        /// </summary>
        public static String svpassword = "123456789";

        //site tra cứu
        /// <summary>
        /// Tên database
        /// </summary>
        public static String database = "TN_CSDLPT";
        /// <summary>
        /// Login name dùng cho tra cứu
        /// </summary>
        public static String remotelogin = "sa";
        /// <summary>
        /// Login name dùng cho tra cứu
        /// </summary>
        public static String remotepassword = "123456789";


        public static String mloginDN = "";
        public static String passwordDN = "";

        /// <summary>
        ///Nhóm của người dùng
        /// </summary>
        public static String mGroup = "";
        /// <summary>
        /// Họ tên người dùng
        /// </summary>
        public static String mHoten = "";

        public static int mCoSo = 0;

        /// <summary>
        /// giữ bdsPM khi đăng nhập
        /// </summary>
        public static BindingSource bds_dspm = new BindingSource();  

        /// <summary>
        /// Kết nối với site chủ để lấy tên của các server khác
        /// </summary>
        public static SqlConnection PublisherConnection;
        /// <summary>
        /// Connection String của site chủ
        /// </summary>
        public static String PublisherConnectionString="Data Source=PHUONG;Initial Catalog=TN_CSDLPT;Integrated Security=True";
        /// <summary>
        /// Kết nối về site của người dùng
        /// </summary>
        public static SqlConnection ServerConnection;
        /// <summary>
        /// ConnectionString của site người dùng
        /// </summary>
        public static String ServerConnectionString;
        /// <summary>
        /// Kết nối về site tra cứu
        /// </summary>
        public static SqlConnection InformationRetrievalSite;
        /// <summary>
        /// ConnectionString của site tra cứu
        /// </summary>
        public static String InformationRetrievalSiteConnectionString;


        //--------------------------------Connect------------------------------------------//
        /// <summary>
        /// Dùng để kết nối tới trang tra cứu. 
        /// Connection sẽ được lưu trong biến InformationRetrievalSite;
        /// Có thông báo lỗi. Để tắt set enable_error = false;
        /// </summary>
        /// <returns>
        /// Trả về 1 nếu kết nối thành công ngược lại là 0
        /// </returns>
        public static int ConnectToRetrievalSite(bool enable_error = true)
        {
            if (Data.InformationRetrievalSite == null) Data.InformationRetrievalSite = new SqlConnection();
            else if (Data.InformationRetrievalSite.State == ConnectionState.Open) Data.InformationRetrievalSite.Close();
            Data.InformationRetrievalSite.ConnectionString = "Data Source=" + Data.servernameTraCuu + ";Initial Catalog=" +Data.database + ";User ID=" +
                                                                                                                                    Data.remotelogin + ";password=" + Data.remotepassword;
            try
            {
                Data.InformationRetrievalSite.Open();
                return 1;
            }
            catch (Exception ex)
            {
                if (enable_error == true)
                    MessageBox.Show("Lỗi kết nối tới trang tra cứu\n" + ex.Message);
                return 0;
            }
        }
        /// <summary>
        /// Kết nối tới site chủ. Nếu có lỗi thì sẽ ném lỗi đó ra.
        /// Dùng cho đăng nhập.
        /// Có thông báo lỗi để tắt set enable_error = false;
        /// </summary>
        public static void ConnectToPublisher(bool enable_error = true)
        {
            if(Data.PublisherConnection == null) Data.PublisherConnection = new SqlConnection(Data.PublisherConnectionString);
            try
            {
                Data.PublisherConnection.Open();
            }
            catch(Exception ex)
            {
                if(enable_error == true)
                    MessageBox.Show("Lỗi kết nối tới cơ sở dữ liệu\n"+ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Dùng để kết nối tới site hiện tại người dùng chọn. 
        /// Có thông báo lỗi. Để tắt set enable_error = false;
        /// </summary>
        /// <returns>trả về 1 nếu thành công và trả về 0 nếu thất bại</returns>
        public static int ConnectToServerWhenLogin(bool enable_error = true)
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
                if (enable_error == true)
                    MessageBox.Show("             Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n           " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }
        //--------------------------------Execute------------------------------------------//
        /// <summary>
        /// Thực thi lệnh bằng connection của publisher.
        /// Có thông báo lỗi. Để tắt set enable_error = false;
        /// </summary>
        /// <param name="statement">Câu lệnh sử dụng</param>
        /// <returns>Kết quả là một DataTable.</returns>
        public static DataTable ExecuteStatementByPublisherConnection(string statement, bool enable_error = true)
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
                if (enable_error == true)
                    MessageBox.Show("Lỗi! không thể thực thi lệnh\n" + ex.Message);
                return null;
            }
            finally { Data.PublisherConnection.Close(); }
        }
        /// <summary>
        /// thực thi lệnh bằng connection đến server hiện tại.
        /// Có thông báo lỗi. Để tắt set enable_error = false;
        /// </summary>
        /// <param name="statement">Câu lệnh để thực hiện</param>
        /// <returns>Kết quả là môt DataTable</returns>
        public static DataTable ExecuteStatementByServerConnection(String statement, bool enable_error = true)
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
                if (enable_error == true)
                    MessageBox.Show("Lỗi! không thể thực thi lệnh\n" + ex.Message);
                return null;
            }
            finally
            {
                Data.ServerConnection.Close();
            }
        }
        /// <summary>
        /// Kết nối tới site tra cứu.
        /// Có thông báo lỗi. Để tắt set enable_error = false;
        /// </summary>
        /// <param name="statement">Câu lệnh thực thi</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteStatementByRetrievalSiteConnection(String statement, bool enable_error = true)
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
                if(enable_error == true)
                    MessageBox.Show("Lỗi! không thể thực thi lệnh\n" + ex.Message);
                return null;
            }
            finally
            {
                Data.InformationRetrievalSite.Close();
            }
        }

        //-----------------------excute chung----------------------------------//

        /// <summary>
        /// Thực hiện câu lệnh bằng kết nối tùy chọn.
        /// Có thông báo lỗi. Để tắt set enable_error = false
        /// </summary>
        /// <param name="cmd">Câu lệnh</param>
        /// <param name="connection">Kết nối</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecSqlDataTable(String cmd,SqlConnection connection, bool enable_error = true)
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
                if (enable_error == true)
                    MessageBox.Show(ex.Message);
                return null;
            }
            finally { connection.Close(); }
        }
        /// <summary>
        /// Thực hiện câu lệnh với connection tùy chọn.
        /// Có thông báo lỗi. Để tắt set enable_error = false;
        /// </summary>
        /// <param name="strlenh"></param>
        /// <param name="connection"></param>
        /// <returns>Giá trị là một số nguyên của kết quả thực hiện</returns>
        public static int ExecuteScalar(String strlenh, SqlConnection connection, bool enable_error = true)
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
                if (enable_error == true)
                    MessageBox.Show(ex.Message);
                return -1; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Thực hiện câu lệnh với kết nối tùy chọn.
        /// Có thông báo lỗi. Để tắt set enable error = false
        /// </summary>
        /// <param name="strLenh"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static SqlDataReader ExecSqlDataReader(String strLenh,SqlConnection connection, bool enable_error = true)
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
                if(enable_error == true)
                 MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                //connection.Close();
            }
        }
        /// <summary>
        /// Thực hiện câu lệnh với kết quả tùy chọn.
        /// Có thông báo lỗi. Để tắt set enable_error = false
        /// </summary>
        /// <param name="strlenh"></param>
        /// <param name="connection"></param>
        /// <returns>Trả về 0 nếu thành công. Hoặc Trả về mã lỗi từ server</returns>
        public static int ExecSqlNonQuery(String strlenh,SqlConnection connection, bool enable_error = true)
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
                if(enable_error == true)
                MessageBox.Show(ex.Message);
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Thực hiện bằng server connection.
        /// Có thông báo lỗi. Để tắt set enable_error = false;
        /// </summary>
        /// <param name="strlenh"></param>
        /// <returns></returns>
        public static int ExecSqlNonQueryByServerConnection(String strlenh, bool enable_error = true)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, Data.ServerConnection);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (Data.ServerConnection.State == ConnectionState.Closed) Data.ServerConnection.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException ex)
            {
                if(enable_error == true)
                    MessageBox.Show(ex.Message);
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
            finally
            {
               Data.ServerConnection.Close();
            }
        }
    }
  
}
