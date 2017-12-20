using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
  public class Staff
    {
        private string id;
        private string name;        
        private string contact;
        private string department;
        private string image;

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

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
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

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public Staff() { }

        public Staff(string id, string name, string contact, string department, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Department = department;
            this.Image = image;
        }

        public static List<Staff> List()
        {
            string SQL = "SELECT * FROM staff";
            List<Staff> cats = new List<Staff>();
           
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Staff p = new Staff(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["department"].ToString(), Reader["image"].ToString());
                    cats.Add(p);
                }
                Reader.Close();
            
            return cats;
        }
    }
}
