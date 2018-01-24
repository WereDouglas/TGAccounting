using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
    public class Supplies
    {
        private string id;
        private string date;
        private int week;
        private string starting;
        private string ending;
        private string supplier;
        private double amount;
        private string month;
        private static List<Supplies> s;
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

        public string Supplier
        {
            get
            {
                return supplier;
            }

            set
            {
                supplier = value;
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

        public Supplies() { }
        public Supplies(string id, string date, int week, string starting, string ending, string supplier, double amount,string month)
        {
            this.Id = id;
            this.Date = date;
            this.Week = week;
            this.Starting = starting;
            this.Ending = ending;
            this.Supplier = supplier;
            this.Amount = amount;
            this.Month = month;
        }
        public static List<Supplies> List(string query)
        {
            s = new List<Supplies>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Supplies p = new Supplies(Reader["id"].ToString(), Reader["date"].ToString(), Convert.ToInt32(Reader["week"]), Reader["starting"].ToString(), Convert.ToDateTime(Reader["ending"]).ToString("dd-MMM-yy"), Reader["supplier"].ToString(), Convert.ToDouble(Reader["amount"]),Reader["month"].ToString());
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
