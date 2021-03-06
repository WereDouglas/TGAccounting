﻿using System;
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
        private int week;
        private string starting;
        private string ending;
        private string name;
        private string category;       
        private double amount;
        private double begining;
        private double finishing;
        private double cog;
        private string month;
        private string dop;


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

        public double Begining
        {
            get
            {
                return begining;
            }

            set
            {
                begining = value;
            }
        }

        public double Finishing
        {
            get
            {
                return finishing;
            }

            set
            {
                finishing = value;
            }
        }

        public double Cog
        {
            get
            {
                return cog;
            }

            set
            {
                cog = value;
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

        public string Dop
        {
            get
            {
                return dop;
            }

            set
            {
                dop = value;
            }
        }

        public Inventory() { }

        public Inventory(string id, string date, int week, string starting, string ending, string name, string category,double amount,double begining,double finishing,double cog,string month,string dop)
        {
            this.id = id;
            this.date = date;
            this.week = week;
            this.starting = starting;
            this.ending = ending;
            this.name = name;
            this.category = category;            
            this.amount = amount;
            this.begining = begining;
            this.finishing = finishing;
            this.cog = cog;
            this.month = month;
            this.dop = dop;


        }

        public static List<Inventory> List(string query)
        {           
             s = new List<Inventory>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                double begining = Cogs.List("SELECT * from cogs WHERE category= '" + Reader["category"].ToString() + "' AND week = '" + Convert.ToInt32(Reader["week"]) + "' AND date ='"+Helper.CurrentYear+"'").Sum(t => t.BeginningInventory);
                double ending = Cogs.List("SELECT * from cogs WHERE category= '" + Reader["category"].ToString() + "' AND week = '" + Convert.ToInt32(Reader["week"]) + "' AND date ='" + Helper.CurrentYear + "'").Sum(t => t.EndingInventory);
                double cg = Cogs.List("SELECT * from cogs WHERE category= '" + Reader["category"].ToString() + "' AND week = '" + Convert.ToInt32(Reader["week"]) + "' AND date ='" + Helper.CurrentYear + "'").Sum(t => t.Cost);

                Inventory p = new Inventory(Reader["id"].ToString(),Reader["date"].ToString(), Convert.ToInt32(Reader["week"]), Reader["starting"].ToString(),Convert.ToDateTime( Reader["ending"]).ToString("dd-MMM-yy"), Reader["name"].ToString(), Reader["category"].ToString(),Convert.ToDouble(Reader["amount"]),begining,ending,cg,Reader["month"].ToString(), Reader["dop"].ToString());
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
        public static List<String> ListCategory(string query)
        {
           List<string> s = new List<String>();
            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                   s.Add(Reader["category"].ToString());
            }
            Reader.Close();
            return s;

        }
        public static List<string> ListName(string query)
        {
            List<string> s = new List<String>();
            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                s.Add(Reader["name"].ToString());
            }
            Reader.Close();
            return s;
        }
    }
}
