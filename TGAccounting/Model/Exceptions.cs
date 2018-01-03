using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
  public class Exceptions
    {
        private string id;
        private string message;        
        private string page;
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

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public string Page
        {
            get
            {
                return page;
            }

            set
            {
                page = value;
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

        public Exceptions() { }

        public Exceptions(string id, string message, string page, string created)
        {
            this.Id = id;
            this.Message = message;
            this.Page = page;
            this.Created = created;
        }

        public static List<Exceptions> List()
        {
            string SQL = "SELECT * FROM exceptions";
            List<Exceptions> cats = new List<Exceptions>();
           
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Exceptions p = new Exceptions(Reader["id"].ToString(), Reader["message"].ToString(), Reader["page"].ToString(), Reader["created"].ToString());
                    cats.Add(p);
                }
                Reader.Close();
            
            return cats;
        }
    }
}
