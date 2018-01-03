using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
  public class Logs
    {
        private string id;             
        private string name;
        private string actions;
        private string created;

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

        public string Actions
        {
            get
            {
                return actions;
            }

            set
            {
                actions = value;
            }
        }

        public string Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        public Logs() { }

        public Logs(string id, string name, string actions, string created)
        {
            this.id = id;
            this.name = name;
            this.actions = actions;
            this.created = created;
        }

        public static List<Logs> List()
        {
            string SQL = "SELECT * FROM logs";
            List<Logs> cats = new List<Logs>();
           
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Logs p = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString());
                    cats.Add(p);
                }
                Reader.Close();
            
            return cats;
        }
    }
}
