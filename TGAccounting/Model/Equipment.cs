using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Equipment
    {
        private string id;
        private string date;
        private string week;
        private string starting;
        private string ending;
        private string name;
        private double amount;
       private static List<Equipment> s ;
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

        public Equipment() { }
        public Equipment(string id,string date, string week, string starting, string ending, string name, double amount)
        {
            this.Id = id;
            this.Date = date;
            this.Week = week;
            this.Starting = starting;
            this.Ending = ending;
            this.Name = name;
            this.Amount = amount;
        }
        public static List<Equipment> List(string query)
        {           
             s = new List<Equipment>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Equipment p = new Equipment(Reader["id"].ToString(),Reader["date"].ToString(), Reader["week"].ToString(),Convert.ToDateTime(Reader["starting"]).ToString("dd-MMMM-yy"), Convert.ToDateTime(Reader["ending"]).ToString("dd-MMMM-yy"), Reader["name"].ToString(),Convert.ToDouble(Reader["amount"]));
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
