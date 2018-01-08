using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class AddBudget : Form
    {
        public AddBudget()
        {
            InitializeComponent();            
           

            string current = DateTime.Now.Year.ToString();
            Helper.CurrentYear = current;
            yearTxt.Text = current;
            autocomplete();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        Dictionary<string, string> Items = new Dictionary<string, string>();
        Dictionary<string, string> Category = new Dictionary<string, string>();
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
          
            foreach (Sale r in Sale.List("SELECT * from sale").GroupBy(x => x.Item, (key, group) => group.First()))
            {
                AutoItem.Add(r.Item);
                if (!Items.ContainsKey(r.Item))
                {
                    Items.Add(r.Item, "SALES");
                    Category.Add(r.Item, r.Category);
                    itemCbx.Items.Add(r.Item);
                }
            }
            foreach (Cogs r in Cogs.List("SELECT * from cogs").GroupBy(x => x.Category, (key, group) => group.First()))
            {
                AutoItem.Add(r.Category);
                if (!Items.ContainsKey(r.Category))
                {
                    Items.Add(r.Category, "COST OF GOODS SOLD");
                    Category.Add(r.Category, "COST OF GOODS SOLD");
                    itemCbx.Items.Add(r.Category);
                }
            }
            foreach (Expense r in Expense.List("SELECT * from expense").GroupBy(x => x.Name, (key, group) => group.First()))
            {
                AutoItem.Add(r.Name);
                if (!Items.ContainsKey(r.Name))
                {
                    Items.Add(r.Name, "Expense");
                    Category.Add(r.Name, r.Category);
                    itemCbx.Items.Add(r.Name);
                }
            }

            itemCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemCbx.AutoCompleteCustomSource = AutoItem;


        }
      
        string existingID;

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void itemCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                groupTxt.Text = Items[itemCbx.Text];
            }
            catch { }
            try
            {
                catTxt.Text = Category[itemCbx.Text];
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pctTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
              && !char.IsDigit(e.KeyChar)
              && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow two decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(valTxt.Text))
            {
                valTxt.BackColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(itemCbx.Text))
            {
                itemCbx.BackColor = Color.Red;
                return;
            }
            string ID = Guid.NewGuid().ToString();
            Budget i = new Budget(ID, itemCbx.Text, catTxt.Text, groupTxt.Text, pctTxt.Text, Convert.ToDouble(valTxt.Text), DateTime.Now.ToString("dd-MM-yyyy"));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            valTxt.Text = "";
        }
    }
}
