﻿using System;
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
    public partial class AddComp : Form
    {
        public AddComp()
        {
            InitializeComponent();
            autocomplete();
            autocompleteCategory();
            fillUp(Convert.ToDateTime(DateTime.Now.Date));
        }
        private void fillUp(DateTime d)
        {

            int week = Helper.GetIso8601WeekOfYear(d);
            weekLbl.Text = week.ToString();
            startLbl.Text = Helper.GetFirstDayOfWeek(d, CultureInfo.CurrentCulture).Date.ToString("dd-MM-yyyy");

            string mylast = startLbl.Text;
            string myStart = Convert.ToDateTime(startLbl.Text).AddDays(-7).Date.ToString("dd-MM-yyyy");

            startLbl.Text = Convert.ToDateTime(startLbl.Text).AddDays(-7).Date.ToString("dd-MM-yyyy");


            endLbl.Text = Helper.GetFirstDayOfWeek(d, CultureInfo.CurrentCulture).Date.ToString("dd-MM-yyyy");
            // startLbl.Text = Convert.ToDateTime(mylast).AddDays(-7).Date.ToString("dd-MM-yyyy");



        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Comp r in Comp.List("SELECT * from comp").GroupBy(x => x.Item, (key, group) => group.First()))
            {
                AutoItem.Add(r.Item);
            }
            itemTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemTxt.AutoCompleteCustomSource = AutoItem;

        }
        private void autocompleteCategory()
        {
            categoryTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Comp r in Comp.List("SELECT * from comp").GroupBy(x => x.Category, (key, group) => group.First()))
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
            if (!string.IsNullOrEmpty(existingID))
            {

                if (MessageBox.Show("YES or No?", "Are you sure you want to update the current existing information  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Comp j = new Comp(existingID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, Convert.ToDouble(amountTxt.Text), categoryTxt.Text);

                    DBConnect.Update(j, existingID);
                }
                return;
            }

            string ID = Guid.NewGuid().ToString();
            Comp i = new Comp(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, Convert.ToDouble(amountTxt.Text), categoryTxt.Text);
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            itemTxt.Text = "";
            amountTxt.Text = "";
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

        private void amountTxt_KeyPress(object sender, KeyPressEventArgs e)
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
        string existingID = "";
        private void itemTxt_Leave(object sender, EventArgs e)
        {
            try { categoryTxt.Text = Comp.List("SELECT * from comp WHERE item='" + itemTxt.Text + "'").First().Category; }
            catch (Exception y)
            {
                Helper.Exceptions(y.Message, "on adding Complimentary auto fill the category list selected item");
            }
            try
            {                
                amountTxt.Text = Comp.List("SELECT * from comp WHERE item='" + itemTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Amount.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {

                existingID = Comp.List("SELECT * from comp WHERE item='" + itemTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
        }
    }
}