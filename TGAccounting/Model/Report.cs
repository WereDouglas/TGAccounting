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
        private double weeklyBudget;
        private double weeklyDiff;
        private double ytd;
        private double p2;
        private int order;
        private int subOrder;
        private double budget;
        private double budgetPerc;
        private double difference;
        private double differencePerc;



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

        public double Budget
        {
            get
            {
                return budget;
            }

            set
            {
                budget = value;
            }
        }

        public double BudgetPerc
        {
            get
            {
                return budgetPerc;
            }

            set
            {
                budgetPerc = value;
            }
        }

        public double Difference
        {
            get
            {
                return difference;
            }

            set
            {
                difference = value;
            }
        }

        public double DifferencePerc
        {
            get
            {
                return differencePerc;
            }

            set
            {
                differencePerc = value;
            }
        }

        public double WeeklyBudget
        {
            get
            {
                return weeklyBudget;
            }

            set
            {
                weeklyBudget = value;
            }
        }

        public double WeeklyDiff
        {
            get
            {
                return weeklyDiff;
            }

            set
            {
                weeklyDiff = value;
            }
        }

        public Report() { }

        public Report(string date, int week, string ending, string category, string sub, string main, string item, double amount, double p1, double weeklyBudget, double weeklyDiff, double ytd, double p2, int order, int subOrder, double budget, double budgetPerc, double difference, double differencePerc)
        {
            this.date = date;
            this.week = week;
            this.ending = ending;
            this.category = category;
            this.sub = sub;
            this.main = main;
            this.item = item;
            this.amount = amount;
            this.p1 = p1;
            this.ytd = ytd;
            this.p2 = p2;
            this.order = order;
            this.subOrder = subOrder;
            this.budget = budget;
            this.budgetPerc = budgetPerc;
            this.difference = difference;
            this.differencePerc = differencePerc;
            this.weeklyBudget = weeklyBudget;
            this.weeklyDiff = weeklyDiff;
        }
    }
}
