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
    public partial class AddSalary : Form
    {
        public AddSalary()
        {
            InitializeComponent();
            autocompleteDepartment();
            autocompleteStaff();

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void autocompleteDepartment()
        {
            departmentCbx.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Staff r in Staff.List().GroupBy(x => x.Department, (key, group) => group.First()))
            {
                AutoItem.Add(r.Department);
                departmentCbx.Items.Add(r.Department);
            }
            departmentCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            departmentCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            departmentCbx.AutoCompleteCustomSource = AutoItem;


        }
        private void autocompleteStaff()
        {
            staffTxt.Items.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        private void staffTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                departmentCbx.Text = Staff.List().Where(k => k.Name.Contains(staffTxt.Text.ToString())).First().Department.ToString();
            }
            catch {
                MessageBox.Show("Staff member not registered in the database !");
                return;
            }
           // departmentCbx.Text = Staff.List().First(k => k.Name.Contains(staffTxt.Text)).Department;
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

        private void annualTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                weeklyTxt.Text =Math.Round( (Convert.ToDouble(annualTxt.Text) / 52),2).ToString();
            }
            catch { }
            try
            {
                biweeklyTxt.Text = Math.Round((Convert.ToDouble(weeklyTxt.Text) * 2), 2).ToString();
            }
            catch
            {              

            }
            try
            {
                ourTxt.Text = Math.Round((Convert.ToDouble(biweeklyTxt.Text) / 2), 2).ToString();
            }
            catch
            {

            }
        }

        private void annualTxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(annualTxt.Text))
            {
                annualTxt.BackColor = Color.Red;
                return;
            }

            string ID = Guid.NewGuid().ToString();
            Salary i = new Salary(ID, staffTxt.Text, departmentCbx.Text, categoryCbx.Text, Convert.ToDouble(annualTxt.Text), Convert.ToDouble(weeklyTxt.Text), Convert.ToDouble(biweeklyTxt.Text), Convert.ToDouble(0), Convert.ToDouble(ourTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            annualTxt.Text = "";
            autocompleteDepartment();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void AddSalary_Load(object sender, EventArgs e)
        {

        }
    }
}
