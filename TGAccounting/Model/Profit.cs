using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting.Model
{
    public class Profit
    {
        private string year;
        private string month;
        private int week;
        private string ending;
        private double sales;
        private double cogs;
        private double comps;
        private double grossProfit;//sales-(cogs +comps)
        private double payroll;
        private double prime;//cogs+comps+payroll
        private double variableExpenses;
        private double supplies;
        private double repairs;
        private double controllableExpense;//payroll + variableExp +suppliers + repair
        private double controllableProfit;//grossProfit -controllableExpense
        private double occupancy;
        private double equipment;
        private double profits;//controllableProfit-occupancy-equipment mantenance
        public Profit() { }
        public Profit(string year, string month, int week, string ending, double sales, double cogs, double comps, double grossProfit, double payroll, double prime, double variableExpenses, double supplies, double repairs, double controllableExpense, double controllableProfit, double occupancy, double equipment, double profits)
        {
            this.year = year;
            this.month = month;
            this.week = week;
            this.ending = ending;
            this.sales = sales;
            this.cogs = cogs;
            this.comps = comps;
            this.grossProfit = grossProfit;
            this.payroll = payroll;
            this.prime = prime;
            this.variableExpenses = variableExpenses;
            this.supplies = supplies;
            this.repairs = repairs;
            this.controllableExpense = controllableExpense;
            this.controllableProfit = controllableProfit;
            this.occupancy = occupancy;
            this.equipment = equipment;
            this.profits = profits;
        }

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public string Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
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

        public double Sales
        {
            get
            {
                return sales;
            }

            set
            {
                sales = value;
            }
        }

        public double Cogs
        {
            get
            {
                return cogs;
            }

            set
            {
                cogs = value;
            }
        }

        public double Comps
        {
            get
            {
                return comps;
            }

            set
            {
                comps = value;
            }
        }

        public double GrossProfit
        {
            get
            {
                return grossProfit;
            }

            set
            {
                grossProfit = value;
            }
        }

        public double Payroll
        {
            get
            {
                return payroll;
            }

            set
            {
                payroll = value;
            }
        }

        public double Prime
        {
            get
            {
                return prime;
            }

            set
            {
                prime = value;
            }
        }

        public double VariableExpenses
        {
            get
            {
                return variableExpenses;
            }

            set
            {
                variableExpenses = value;
            }
        }

        public double Supplies
        {
            get
            {
                return supplies;
            }

            set
            {
                supplies = value;
            }
        }

        public double Repairs
        {
            get
            {
                return repairs;
            }

            set
            {
                repairs = value;
            }
        }

        public double ControllableExpense
        {
            get
            {
                return controllableExpense;
            }

            set
            {
                controllableExpense = value;
            }
        }

        public double ControllableProfit
        {
            get
            {
                return controllableProfit;
            }

            set
            {
                controllableProfit = value;
            }
        }

        public double Occupancy
        {
            get
            {
                return occupancy;
            }

            set
            {
                occupancy = value;
            }
        }

        public double Equipment
        {
            get
            {
                return equipment;
            }

            set
            {
                equipment = value;
            }
        }

        public double Profits
        {
            get
            {
                return profits;
            }

            set
            {
                profits = value;
            }
        }
    }
}
