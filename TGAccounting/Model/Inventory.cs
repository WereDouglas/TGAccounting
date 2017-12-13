using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Inventory
    {
        private string id;
        private string date;
        private string week;
        private string starting;
        private string ending;
        private string name;
        private string category;       
        private double amount;
      

        private static List<Inventory> s ;

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

       
        public Inventory() { }

        public Inventory(string id, string date, string week, string starting, string ending, string name, string category,double amount)
        {
            this.id = id;
            this.date = date;
            this.week = week;
            this.starting = starting;
            this.ending = ending;
            this.name = name;
            this.category = category;
           
            this.amount = amount;
           
        }

        public static List<Inventory> List(string query)
        {           
             s = new List<Inventory>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Inventory p = new Inventory(Reader["id"].ToString(),Reader["date"].ToString(), Reader["week"].ToString(), Reader["starting"].ToString(), Reader["ending"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(),Convert.ToDouble(Reader["amount"]));
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
