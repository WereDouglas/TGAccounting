using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
   public class Report
    {
        private string date;
        private int week;
        private string ending;
        private string category;/**sales COGS, labor/payroll***/
        private string sub;
        private string main;
        private string item;         
        private double amount;
        private double p1;
        private double ytd;
        private double p2;
        private int order;
        private int subOrder;

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int Week
        {
            get
            {
                return week;
            }

            set
            {
                week = value;
            }
        }

        public string Ending
        {
            get
            {
                return ending;
            }

            set
            {
                ending = value;
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

        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public double P1
        {
            get
            {
                return p1;
            }

            set
            {
                p1 = value;
            }
        }

        public double Ytd
        {
            get
            {
                return ytd;
            }

            set
            {
                ytd = value;
            }
        }

        public double P2
        {
            get
            {
                return p2;
            }

            set
            {
                p2 = value;
            }
        }

        public string Sub
        {
            get
            {
                return sub;
            }

            set
            {
                sub = value;
            }
        }

        public string Main
        {
            get
            {
                return main;
            }

            set
            {
                main = value;
            }
        }

        public int Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public int SubOrder
        {
            get
            {
                return subOrder;
            }

            set
            {
                subOrder = value;
            }
        }

        public Report() { }

        public Report(string date, int week, string ending, string category, string item, double amount, double p1, double ytd, double p2,string sub,string main,int order,int subOrder)
        {
            this.Date = date;
            this.Week = week;
            this.Ending = ending;
            this.Category = category;
            this.Item = item;
            this.Amount = amount;
            this.P1 = p1;
            this.Ytd = ytd;
            this.P2 = p2;
            this.Sub = sub;
            this.Main = main;
            this.Order = order;
            this.SubOrder = subOrder;
        }
    }
}
