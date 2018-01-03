using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Graphs
    {
        
        private string period;
        private string category;
        private string totals;
        private string item;       
       
        private static List<Graphs> s ;

        public string Period
        {
            get
            {
                return period;
            }

            set
            {
                period = value;
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

        public string Totals
        {
            get
            {
                return totals;
            }

            set
            {
                totals = value;
            }
        }

        public string Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public Graphs() { }

        public Graphs(string period, string category, string totals, string item)
        {
            this.Period = period;
            this.Category = category;
            this.Totals = totals;
            this.Item = item;
        }
    }
}
