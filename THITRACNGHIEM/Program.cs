using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using THITRACNGHIEM;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Data.ConnectToRetrievalSite();
            //Data.ConnectToPublisher();
            Data.formChinh = new formMain();
            Application.Run(Data.formChinh);
        }
    }
}
