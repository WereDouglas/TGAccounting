using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Department
    {
        private string id;
        private string name;
        private string description;

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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public Department() { }
        public Department(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public static List<Department> List()
        {
            string SQL = "SELECT * FROM department";
            List<Department> d = new List<Department>();

            SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
            while (Reader.Read())
            {
                Department p = new Department(Reader["id"].ToString(), Reader["name"].ToString(), Reader["description"].ToString());
                d.Add(p);
            }
            Reader.Close();

            return d;
        }
    }
}
