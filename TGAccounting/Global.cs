using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGAccounting.Model;

namespace TGAccounting
{
    public static class Global
    {
        public static List<Events> events;
        public static List<string> categories = new List<string>();
        public static List<string> inventoryItems = new List<string>();
        public static List<string> expenseCategory = new List<string>();
        public static List<string> compNames = new List<string>();
        public static List<string> tables = new List<string>();
        public static bool LoadData()
        {
            // events.Clear();
            events = new List<Events>(Events.List());
            foreach (var r in Inventory.ListCategory("SELECT DISTINCT category from inventory "))
            {
                categories.Add(r);
            }
            foreach (var r in Inventory.ListName("SELECT  DISTINCT name from inventory "))
            {
                inventoryItems.Add(r);
            }
            foreach (var r in Expense.ListCategory("SELECT DISTINCT category from expense"))
            {
                expenseCategory.Add(r);
            }
            foreach (var r in Comp.ListName("SELECT DISTINCT item from comp"))
            {
                compNames.Add(r);
            }
       
            return true;
        }
        public static List<String> Tables()
        {
            List<string> s = new List<String>();
            SQLiteDataReader Reader = DBConnect.ReadingLite("SELECT name FROM sqlite_master WHERE type = 'table'");
            while (Reader.Read())
            {
                s.Add(Reader["name"].ToString());
            }
            Reader.Close();
            return s;

        }
    }
}
