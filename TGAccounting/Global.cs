using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGAccounting.Model;

namespace TGAccounting
{
    public static class  Global
    {
        public static List<Events> events;
        public static List<string> categories = new List<string>();
        public static List<string> inventoryItems = new List<string>();
        public static void LoadData()
        {
           // events.Clear();
            events = new List<Events>(Events.List());
            foreach (Inventory r in Inventory.List("SELECT * from inventory").GroupBy(x => x.Category, (key, group) => group.First()))
            {               
                categories.Add(r.Category);
            }
            foreach (Inventory r in Inventory.List("SELECT * from inventory").GroupBy(x => x.Name, (key, group) => group.First()))
            {
                inventoryItems.Add(r.Name);
            }

        }
    }
}
