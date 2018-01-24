using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
    public class Annual
    {
        private string id;
        private string year;
        private double annuals;
        private double weekly;

        private static List<Annual> s;

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

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public double Annuals
        {
            get
            {
                return annuals;
            }

            set
            {
                annuals = value;
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

        public Annual() { }

        public Annual(string id, string year, double annuals, double weekly)
        {
            this.Id = id;
            this.Year = year;
            this.Annuals = annuals;
            this.Weekly = weekly;
        }

        public static List<Annual> List(string query)
        {
            s = new List<Annual>();
            SQLiteDataReader Reader = DBConnect.ReadingLite(query);
            while (Reader.Read())
            {
                Annual p = new Annual(Reader["id"].ToString(), Reader["year"].ToString(), Convert.ToDouble(Reader["annuals"]), Convert.ToDouble(Reader["weekly"]));
                s.Add(p);
            }
            Reader.Close();

            return s;

        }
    }
}
