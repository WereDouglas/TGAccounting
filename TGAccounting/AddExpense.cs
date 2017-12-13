using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class AddExpense : Form
    {
        public AddExpense()
        {
            InitializeComponent();
            autocompleteCategory();
            autocomplete();
            fillUp(Convert.ToDateTime(DateTime.Now.Date));
        }
        private void fillUp(DateTime d)
        {
            int week = Helper.GetIso8601WeekOfYear(d);
            weekLbl.Text = week.ToString();
            string mylast = startLbl.Text = Helper.FirstDateOfWeek(d.Year, Convert.ToInt32(week), CultureInfo.CurrentCulture).Date.ToString("yyyy-MM-dd");
            string myStart = Convert.ToDateTime(startLbl.Text).AddDays(7).Date.ToString("yyyy-MM-dd");

            endLbl.Text = mylast;
            startLbl.Text = Convert.ToDateTime(mylast).AddDays(-7).Date.ToString("yyyy-MM-dd");

        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Expense r in Expense.List("SELECT * from expense").GroupBy(x => x.Name, (key, group) => group.First()))
            {
                AutoItem.Add(r.Name);
            }
            itemTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemTxt.AutoCompleteCustomSource = AutoItem;


        }
        private void autocompleteCategory()
        {
            categoryTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Expense r in Expense.List("SELECT * from expense").GroupBy(x => x.Category, (key, group) => group.First()))
            {
                AutoItem.Add(r.Category);
                categoryTxt.Items.Add(r.Category);
            }
            categoryTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryTxt.AutoCompleteCustomSource = AutoItem;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amountTxt.Text))
            {
                amountTxt.BackColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(itemTxt.Text))
            {
                itemTxt.BackColor = Color.Red;
                return;
            }

            string ID = Guid.NewGuid().ToString();
            Expense i = new Expense(ID, dateTxt.Text, weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, categoryTxt.Text, Convert.ToDouble(amountTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            itemTxt.Text = "";
            amountTxt.Text = "";
            autocompleteCategory();
            autocomplete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
        }
    }
}
