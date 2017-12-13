using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
  public class Category
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
        public Category() { }
        public Category(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public static List<Category> List()
        {
            string SQL = "SELECT * FROM category";
            List<Category> cats = new List<Category>();
           
                SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
                while (Reader.Read())
                {
                    Category p = new Category(Reader["id"].ToString(), Reader["name"].ToString(), Reader["description"].ToString());
                    cats.Add(p);
                }
                Reader.Close();
            
            return cats;
        }
    }
}
