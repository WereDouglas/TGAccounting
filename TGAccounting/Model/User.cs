using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
  public class User
    {
        private string id;
        private string name;        
        private string contact;
        private string password;
        private string image;
        private int level;

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

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
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

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public User() { }

        public User(string id, string name, string contact, string password, string image,int level)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Password = password;
            this.Image = image;
            this.Level = level;
        }

        public static List<User> List()
        {
            string SQL = "SELECT * FROM user";
            List<User> cats = new List<User>();
               int level = 0;
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                try {

                    level = Convert.ToInt32(Reader["level"].ToString());
                } catch { }
                    User p = new User(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["password"].ToString(), Reader["image"].ToString(),level);
                    cats.Add(p);
                }
                Reader.Close();
            
            return cats;
        }
    }
}
