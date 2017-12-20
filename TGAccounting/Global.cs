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
        public static void LoadData()
        {
           // events.Clear();
            events = new List<Events>(Events.List());
        
        }
    }
}
