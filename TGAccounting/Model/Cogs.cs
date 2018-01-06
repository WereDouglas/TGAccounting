using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Cogs
    {
        private string id;
        private string date;
        private string week;
        private string starting;
        private string ending;
        private string category;
        private double beginningInventory;
        private double endingInventory;
        private double cost;
        private string month;

        private static List<Cogs> s ;

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

        public double BeginningInventory
        {
            get
            {
                return beginningInventory;
            }

            set
            {
                beginningInventory = value;
            }
        }

        public double EndingInventory
        {
            get
            {
                return endingInventory;
            }

            set
            {
                endingInventory = value;
            }
        }

        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
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

        public Cogs() { }

        public Cogs(string id, string date, string week, string starting, string ending, string category, double beginningInventory, double endingInventory,double cost,string month)
        {
            this.id = id;
            this.date = date;
            this.week = week;
            this.starting = starting;
            this.ending = ending;
            this.category = category;
            this.beginningInventory = beginningInventory;
            this.endingInventory = endingInventory;
            this.cost = cost;
            this.month = month;
        }

        public static List<Cogs> List(string query)
        {           
             s = new List<Cogs>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Cogs p = new Cogs(Reader["id"].ToString(), Reader["date"].ToString(), Reader["week"].ToString(), Reader["starting"].ToString(), Reader["ending"].ToString(), Reader["category"].ToString(),Convert.ToDouble(Reader["beginningInventory"]), Convert.ToDouble(Reader["endingInventory"].ToString()), Convert.ToDouble(Reader["cost"].ToString()), Reader["month"].ToString());
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
