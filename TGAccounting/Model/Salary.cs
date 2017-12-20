using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
  public class Salary
    {
        private string id;
        private string staff;        
        private string department;
        private string category;
        private double annual;
        private double weekly;
        private double biweekly;
        private double monthly;
        private double our;

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

        public string Staff
        {
            get
            {
                return staff;
            }

            set
            {
                staff = value;
            }
        }

        public string Department
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

        public double Annual
        {
            get
            {
                return annual;
            }

            set
            {
                annual = value;
            }
        }

        public double Weekly
        {
            get
            {
                return weekly;
            }

            set
            {
                weekly = value;
            }
        }

        public double Biweekly
        {
            get
            {
                return biweekly;
            }

            set
            {
                biweekly = value;
            }
        }

        public double Monthly
        {
            get
            {
                return monthly;
            }

            set
            {
                monthly = value;
            }
        }

        public double Our
        {
            get
            {
                return our;
            }

            set
            {
                our = value;
            }
        }

        public Salary() { }

        public Salary(string id, string staff, string department, string category, double annual, double weekly, double biweekly, double monthly,double our)
        {
            this.Id = id;
            this.Staff = staff;
            this.Department = department;
            this.Category = category;
            this.Annual = annual;
            this.Weekly = weekly;
            this.Biweekly = biweekly;
            this.Monthly = monthly;
            this.Our = our;
        }

        public static List<Salary> List()
        {
            string SQL = "SELECT * FROM salary";
            List<Salary> cats = new List<Salary>();
           
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Salary p = new Salary(Reader["id"].ToString(), Reader["staff"].ToString(), Reader["department"].ToString(), Reader["category"].ToString(), Convert.ToDouble( Reader["annual"]), Convert.ToDouble(Reader["weekly"]), Convert.ToDouble(Reader["biweekly"]), Convert.ToDouble(Reader["monthly"]),Convert.ToDouble(Reader["our"]));
                    cats.Add(p);
                }
                Reader.Close();
            
            return cats;
        }
    }
}
