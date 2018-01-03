using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Sale
    {
        private string id;
        private string date;
        private string week;
        private string starting;
        private string ending;
        private string item;
        private double amount;
        private string category;
        private static List<Sale> s ;
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

        public Sale() { }
        public Sale(string id,string date, string week, string starting, string ending, string item, double amount,string category)
        {
            this.Id = id;
            this.Date = date;
            this.Week = week;
            this.Starting = starting;
            this.Ending = ending;
            this.Item = item;
            this.Amount = amount;
            this.Category = category;
        }
        public static List<Sale> List(string query)
        {           
             s = new List<Sale>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Sale p = new Sale(Reader["id"].ToString(), Reader["date"].ToString(), Reader["week"].ToString(), Reader["starting"].ToString(),Convert.ToDateTime( Reader["ending"]).ToString("dd-MMM-yy"), Reader["item"].ToString(),Convert.ToDouble(Reader["amount"]), Reader["category"].ToString());
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
