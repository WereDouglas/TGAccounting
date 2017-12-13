using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TGAccounting.SQLite;

namespace TGAccounting
{

    public static class DBConnect
    {
        static Connection dbobject = new Connection();
        static SQLiteConnection SQLconnect = new SQLiteConnection();
        static SQLiteDataReader Reader;
        public static SQLiteDataReader ReadingLite(string query)
        {
            try
            {
                SQLconnect.ConnectionString = dbobject.datalocation();
                SQLconnect.Open();
            }
            catch
            {

            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = SQLconnect.CreateCommand();
            cmd.CommandText = query;
            Reader = cmd.ExecuteReader();
            return Reader;
        }

        public static string save(string query)
        {
            Int32 rowsaffected = 0;
           
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = query;

                rowsaffected = cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQLconnect.Close();
            
            return rowsaffected.ToString();
        }
        public static string Insert(Object objGen)
        {
            Int32 rowsaffected = 0;
            //try
            //{


            // Get type and properties (vector)
            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert
            string SQL = "INSERT INTO " + table + " VALUES (";

            // It goes from second until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                object propValue = properties[i].GetValue(objGen, null);
                string[] typeValue = propValue.GetType().ToString().Split('.');
                if (typeValue[1].Equals("String"))
                {
                    SQL += "'" + propValue.ToString() + "',";
                }
                else if (typeValue[1].Equals("DateTime"))
                {
                    SQL += "'" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
                }

                else
                {
                    SQL += propValue.ToString() + ",";
                }
            }

            // get last attribute here
            object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
            string[] lastType = lastValue.GetType().ToString().Split('.');
            if (lastType[1].Equals("String"))
            {
                SQL += "'" + lastValue.ToString() + "'";
            }
            else if (lastType[1].Equals("DateTime"))
            {
                SQL += "'" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
            }

            else
            {
                SQL += lastValue.ToString();
            }

            // Ends string builder
            SQL += ");";

         
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = SQL;

                rowsaffected = cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQLconnect.Close();
            
            return rowsaffected.ToString();
        }

        public static string CreateDBSQL(Object objGen)
        {
            //try
            //{
            // OpenConn();

            // Get type and properties (vector)
            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert           
            string SQL = "CREATE TABLE IF NOT  EXISTS " + table + "  (";

            // It goes from second until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                //object propValue = properties[i].GetValue(objGen, null);
                string[] typeValue = properties[i].ToString().Split(' ');
                SQL += "" + typeValue[1].ToString() + " varchar(255),";

            }

            // get last attribute here           
            string[] lastType = properties[properties.Length - 1].ToString().Split(' ');

            SQL += "" + lastType[1].ToString() + " varchar(255)";


            // Ends string builder
            SQL += ");";


            return SQL;
            //}
            //catch (Exception c)
            //{
            //    Console.WriteLine("Errr on insert!" + c.Message);
            //    return "";
            //}
        }


        public static string EmptyDBSQL(Object objGen)
        {
            //try
            //{
            // OpenConn();

            // Get type and properties (vector)
            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert           
            string SQL = "DELETE FROM " + table + "";




            return SQL;
            //}
            //catch (Exception c)
            //{
            //    Console.WriteLine("Errr on insert!" + c.Message);
            //    return "";
            //}
        }


        public static string GenerateQuery(Object objGen)
        {
            //try
            //{

            Type typeObj = objGen.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            // Get table
            string[] type = typeObj.ToString().Split('.');
            string table = type[2].ToLower();

            // Start mounting string to insert
            string SQL = "INSERT INTO " + table + " VALUES (";

            // It goes from second until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                object propValue = properties[i].GetValue(objGen, null);
                string[] typeValue = propValue.GetType().ToString().Split('.');
                if (typeValue[1].Equals("String"))
                {
                    SQL += "'" + propValue.ToString() + "',";
                }
                else if (typeValue[1].Equals("DateTime"))
                {
                    SQL += "'" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
                }

                else
                {
                    SQL += propValue.ToString() + ",";
                }
            }

            // get last attribute here
            object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
            string[] lastType = lastValue.GetType().ToString().Split('.');
            if (lastType[1].Equals("String"))
            {
                SQL += "'" + lastValue.ToString() + "'";
            }
            else if (lastType[1].Equals("DateTime"))
            {
                SQL += "'" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
            }

            else
            {
                SQL += lastValue.ToString();
            }

            // Ends string builder
            SQL += ");";

            return SQL;

        }
        public static void Update(Object objGen, string idValue)
        {
            Int32 rowsaffected = 0;
            //try
            //{


            // Get table
            string[] type = objGen.GetType().ToString().Split('.');
            string table = type[2].ToLower();

            // Start building
            string SQL = "UPDATE " + table + " SET ";

            // Get types and properties
            Type type2 = objGen.GetType();
            PropertyInfo[] properties = type2.GetProperties();

            // Goes until second to last
            for (int i = 0; i < properties.Length - 1; i++)
            {
                object propValue = properties[i].GetValue(objGen, null);
                string[] nameAttribute = properties[i].ToString().Split(' ');
                string[] typeAttribute = propValue.GetType().ToString().Split('.');

                if (typeAttribute[1].Equals("String"))
                {
                    SQL += nameAttribute[1] + " = '" + propValue.ToString() + "',";
                }
                else if (typeAttribute[1].Equals("DateTime"))
                {
                    SQL += nameAttribute[1] + "= '" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
                }
                else
                {
                    SQL += nameAttribute[1] + " = " + propValue.ToString() + ",";
                }
            }

            // Process last attribute
            object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
            string[] lastType = lastValue.GetType().ToString().Split('.');
            string[] ultimoCampo = properties[properties.Length - 1].ToString().Split(' ');
            if (lastType[1].Equals("String"))
            {
                SQL += ultimoCampo[1] + " = '" + lastValue.ToString() + "'";
            }
            else if (lastType[1].Equals("DateTime"))
            {
                SQL += ultimoCampo[1] + "= '" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
            }
            else
            {
                SQL += ultimoCampo[1] + " = " + lastValue.ToString();
            }

            // Ends string builder
            SQL += " WHERE id = '" + idValue + "';";


            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Errr on update!");
            //}

           
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = SQL;

                rowsaffected = cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQLconnect.Close();
            

        }
        public static void Execute(string query)
        {
            
                try
                {
                    SQLconnect.ConnectionString = dbobject.datalocation();
                    SQLconnect.Open();
                }
                catch
                {

                }

                SQLiteCommand cmd = new SQLiteCommand();
                cmd = SQLconnect.CreateCommand();
                cmd.CommandText = query;

                cmd.Dispose();
                SQLconnect.Close();
            

        }
     
      

    }

}