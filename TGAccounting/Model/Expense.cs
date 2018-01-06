using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
    public class Expense
    {
        private string id;
        private string date;
        private string week;
        private string starting;
        private string ending;
        private string name;
        private string category;
        private double amount;
        private string month;

        private static List<Expense> s;

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
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

        public Expense() { }

        public Expense(string id, string date, string week, string starting, string ending, string name, string category, double amount, string month)
        {
            this.id = id;
            this.date = date;
            this.week = week;
            this.starting = starting;
            this.ending = ending;
            this.name = name;
            this.category = category;
            this.month = month;
            this.amount = amount;

        }

        public static List<Expense> List(string query)
        {
            s = new List<Expense>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Expense p = new Expense(Reader["id"].ToString(), Reader["date"].ToString(), Reader["week"].ToString(), Reader["starting"].ToString(), Convert.ToDateTime(Reader["ending"]).ToString("dd-MMMM-yy"), Reader["name"].ToString(), Reader["category"].ToString(), Convert.ToDouble(Reader["amount"]), Reader["month"].ToString());
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
