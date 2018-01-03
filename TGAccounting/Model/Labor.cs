using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Labor
    {
        private string id;
        private string date;
        private string week;
        private string starting;
        private string ending;
        private string department;
        private double amount;
       private static List<Labor> s ;
        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Week
        {
            get
            {
                return week;
            }

            set
            {
                week = value;
            }
        }

        public string Starting
        {
            get
            {
                return starting;
            }

            set
            {
                starting = value;
            }
        }

        public string Ending
        {
            get
            {
                return ending;
            }

            set
            {
                ending = value;
            }
        }

        public string Item
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Labor() { }
        public Labor(string id,string date, string week, string starting, string ending, string department, double amount)
        {
            this.Id = id;
            this.Date = date;
            this.Week = week;
            this.Starting = starting;
            this.Ending = ending;
            this.Item = department;
            this.Amount = amount;
        }
        public static List<Labor> List(string query)
        {           
             s = new List<Labor>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Labor p = new Labor(Reader["id"].ToString(),Reader["date"].ToString(), Reader["week"].ToString(), Reader["starting"].ToString(), Convert.ToDateTime(Reader["ending"]).ToString("dd-MMM-yy"), Reader["item"].ToString(),Convert.ToDouble(Reader["amount"]));
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
