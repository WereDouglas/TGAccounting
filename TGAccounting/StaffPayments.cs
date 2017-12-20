using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class StaffPayments : Form
    {
        public StaffPayments()
        {
            InitializeComponent();
            autocomplete();
            autocompleteDepartment();
        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Staff r in Staff.List().GroupBy(x => x.Name, (key, group) => group.First()))
            {
                AutoItem.Add(r.Name);
                staffTxt.Items.Add(r.Name);
            }
            staffTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            staffTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            staffTxt.AutoCompleteCustomSource = AutoItem;


        }
        private void autocompleteDepartment()
        {
            departmentTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Staff r in Staff.List().GroupBy(x => x.Department, (key, group) => group.First()))
            {
                AutoItem.Add(r.Department);
                departmentTxt.Items.Add(r.Department);
            }
            departmentTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            departmentTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            departmentTxt.AutoCompleteCustomSource = AutoItem;


        }
        private void autocompleteCategory()
        {
            categoryTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Salary r in Salary.List().GroupBy(x => x.Category, (key, group) => group.First()))
            {
                AutoItem.Add(r.Category);
                categoryTxt.Items.Add(r.Category);
            }
            categoryTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryTxt.AutoCompleteCustomSource = AutoItem;


        }

        private void staffTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmentTxt.Text =Staff.List().First(k => k.Name.Contains(staffTxt.Text)).Department;
            try
            {
                Image img = Helper.Base64ToImage(Staff.List().First(k => k.Name.Contains(staffTxt.Text)).Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                pictureBox1.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(pictureBox1.DisplayRectangle);
                pictureBox1.Region = new Region(gp);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(staffTxt.Text))
            {
                staffTxt.BackColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(annualTxt.Text))
            {
                annualTxt.BackColor = Color.Red;
                return;
            }

            string ID = Guid.NewGuid().ToString();
            Salary i = new Salary(ID,staffTxt.Text, departmentTxt.Text, categoryTxt.Text, Convert.ToDouble(annualTxt.Text), Convert.ToDouble(weeklyTxt.Text), Convert.ToDouble(biweeklyTxt.Text), Convert.ToDouble(monthlyTxt.Text), Convert.ToDouble(ourTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            staffTxt.Text = "";
            annualTxt.Text = "";
            weeklyTxt.Text = "";
            biweeklyTxt.Text = "";
            monthlyTxt.Text = "";
            ourTxt.Text = "";
            autocompleteDepartment();
            autocomplete();
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
