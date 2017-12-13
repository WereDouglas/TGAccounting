using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGAccounting.SQLite
{
    public class Connection
    {
        static Connection dbobject = new Connection();
        static SQLiteConnection SQLconnect = new SQLiteConnection();
        public string datalocation()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //   string fullFilePath = Path.Combine(appPath, "casesLite.txt");
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return "Data Source=" + dir + "\\profitLoss.db;";
            /// 
            // Helper.GrantAccess(appPath + "\\pos.bbs;");
            // return "Data Source=" + appPath + "\\pos.bbs;";
        }
        public static string XMLFile()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return dir + "\\profitLoss.xml";

        }

        public static string Documents()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(dir + "\\ProfitLoss\\"))
            {
                DirectoryInfo dim = Directory.CreateDirectory(dir + "\\CASE\\");
                Console.WriteLine("The directory was created successfully at {0}.",
                Directory.GetCreationTime(dir + "\\ProfitLoss\\"));
            }
            GrantAccess(dir + "\\ProfitLoss\\");
            return dir + "\\ProfitLoss\\";

        }
        private static void GrantAccess(string file)
        {
            bool exists = System.IO.Directory.Exists(file);

            if (exists)
            {
                DirectoryInfo di = System.IO.Directory.CreateDirectory(file);
                Console.WriteLine("The Folder is created Sucessfully");
            }
            else
            {
                Console.WriteLine("The Folder already exists");
            }
            DirectoryInfo dInfo = new DirectoryInfo(file);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);

        }
        public static void createSQLLiteDB(String SQL)
        {


            // string fullFilePath = Path.Combine(appPath, "casesLite.txt");

            //try
            //{
            SQLconnect.ConnectionString = dbobject.datalocation();
            SQLconnect.Open();

            SQLiteCommand SQLcommand = new SQLiteCommand();
            SQLcommand = SQLconnect.CreateCommand();
            //CreateDBSQL(Object objGen)

            SQLcommand.CommandText = SQL;
            //  SQLcommand.CommandText = "CREATE TABLE IF NOT EXISTS business ( Username TEXT, Password TEXT);";
            ///////
            SQLcommand.ExecuteNonQuery();
            SQLcommand.Dispose();
            SQLconnect.Close();
            //}
            //catch (Exception p)
            //{
            //    MessageBox.Show(p.Message.ToString());

            //}


        }


    }
}