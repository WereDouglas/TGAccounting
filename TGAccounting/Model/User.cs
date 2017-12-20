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

        public User() { }

        public User(string id, string name, string contact, string password, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Password = password;
            this.Image = image;
        }

        public static List<User> List()
        {
            string SQL = "SELECT * FROM user";
            List<User> cats = new List<User>();
           
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    User p = new User(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["password"].ToString(), Reader["image"].ToString());
                    cats.Add(p);
                }
                Reader.Close();
            
            return cats;
        }
    }
}
