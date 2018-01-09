using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Comp
    {
        private string id;
        private string date;
        private int week;
        private string starting;
        private string ending;
        private string item;
        private double amount;        
        private string month;

        private static List<Comp> s ;

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

        public int Week
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
                return item;
            }

            set
            {
                item = value;
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
        
        public string Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }

        public Comp() { }

        public Comp(string id, string date, int week, string starting, string ending, string item, double amount,string month)
        {
            this.Id = id;
            this.Date = date;
            this.Week = week;
            this.Starting = starting;
            this.Ending = ending;
            this.Item = item;
            this.Amount = amount;
            this.Month = month;

        }

        public static List<Comp> List(string query)
        {           
             s = new List<Comp>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Comp p = new Comp(Reader["id"].ToString(), Reader["date"].ToString(), Convert.ToInt32(Reader["week"]), Reader["starting"].ToString(), Reader["ending"].ToString(), Reader["item"].ToString(), Convert.ToDouble(Reader["amount"]),Reader["month"].ToString());
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
        public static List<String> ListName(string query)
        {
            List<string> s = new List<String>();
            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                s.Add(Reader["item"].ToString());
            }
            Reader.Close();
            return s;

        }
    }
}
