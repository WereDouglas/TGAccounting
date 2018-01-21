using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Budget
    {
        private string id;     
        private string item;
        private string date;
        private string category;
        private string grouping;
        private double pct;       
        private double groupValue;       


        private static List<Budget> s ;

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

        public string Grouping
        {
            get
            {
                return grouping;
            }

            set
            {
                grouping = value;
            }
        }

        public double Pct
        {
            get
            {
                return pct;
            }

            set
            {
                pct = value;
            }
        }

        public double GroupValue
        {
            get
            {
                return groupValue;
            }

            set
            {
                groupValue = value;
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

        public Budget() { }

        public Budget(string id, string item, string category, string grouping, double pct, double groupValue, string date)
        {
            this.Id = id;
            this.Item = item;
            this.Category = category;
            this.Grouping = grouping;
            this.Pct = pct;
            this.GroupValue = groupValue;
            this.Date = date;
        }

        public static List<Budget> List(string query)
        {           
            s = new List<Budget>();
            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
               
               Budget p = new Budget(Reader["id"].ToString(), Reader["item"].ToString(), Reader["category"].ToString(),Reader["grouping"].ToString(), Convert.ToDouble(Reader["pct"]),Convert.ToDouble(Reader["groupValue"]), Reader["date"].ToString());
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
