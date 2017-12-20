using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
 public  class Company
    {
        private string id;
        private string name;
        private string address;
        private string logo;

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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }
        public Company() { }
        public Company(string id, string name, string address, string logo)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Logo = logo;
        }
        public static List<Company> List()
        {
            string SQL = "SELECT * FROM company";
            List<Company> cats = new List<Company>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
            while (Reader.Read())
            {
                Company p = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["address"].ToString(), Reader["logo"].ToString());
                cats.Add(p);
            }
            Reader.Close();

            return cats;
        }
    }
}
