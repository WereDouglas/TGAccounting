using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Items
    {
        private string id;
        private string name;
        private string category;
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

        public Items() { }
        public Items(string id, string name, string category, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Description = description;
        }
        public static List<Items> List()
        {
            string SQL = "SELECT * FROM items";
            List<Items> i = new List<Items>();
            SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
            while (Reader.Read())
            {
                Items p = new Items(Reader["id"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(),Reader["description"].ToString());
                i.Add(p);
            }
            Reader.Close();

            return i;

        }
    }
}
