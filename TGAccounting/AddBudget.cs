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

            CategoryCbx.Items.Add("Sale");
            CategoryCbx.Items.Add("Cost of Goods");
            CategoryCbx.Items.Add("Complimentaries");
            CategoryCbx.Items.Add("Expenses");

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        Dictionary<string, string> Items = new Dictionary<string, string>();
        Dictionary<string, string> Category = new Dictionary<string, string>();
        private void autocomplete()
        {
            itemTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            if (CategoryCbx.Text.Contains("Sale"))
            {
                foreach (var r in Sale.ListName("SELECT DISTINCT item from sale"))
                {
                    AutoItem.Add(r);
                   
                        itemTxt.Items.Add(r);
                    
                }
            }
            if (CategoryCbx.Text.Contains("Cost"))
            {
                foreach (var r in Cogs.ListName("SELECT DISTINCT category from cogs"))
                {
                    AutoItem.Add(r);
                   
                        itemTxt.Items.Add(r);
                   
                }
            }
            if (CategoryCbx.Text.Contains("Complimentaries"))
            {
                foreach (var r in Comp.ListName("SELECT DISTINCT item from comp"))
                {
                    AutoItem.Add(r);
                  
                        itemTxt.Items.Add(r);
                  
                }
            }
            if (CategoryCbx.Text.Contains("Expenses"))
            {
                foreach (var r in Expense.ListName("SELECT DISTINCT name from expense"))
                {
                    AutoItem.Add(r);
                   
                        itemTxt.Items.Add(r);
                   
                }

            }

        }

        string existingID;

        private void button1_Click(object sender, EventArgs e)
        {


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
            if (string.IsNullOrEmpty(pctTxt.Text))
            {
                pctTxt.BackColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(itemTxt.Text))
            {
                itemTxt.BackColor = Color.Red;
                return;
            }
            string ID = Guid.NewGuid().ToString();
            Budget i = new Budget(ID, itemTxt.Text, CategoryCbx.Text, CategoryCbx.Text,Convert.ToDouble(pctTxt.Text), 0, yearTxt.Text);
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            pctTxt.Text = "";
        }

        private void categoryTxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CategoryCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            autocomplete();
        }
    }
}
