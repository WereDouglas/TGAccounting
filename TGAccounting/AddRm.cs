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
    public partial class AddRm : Form
    {
        public AddRm()
        {
            InitializeComponent();
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
            foreach (Rem r in Rem.List("SELECT * from rm").GroupBy(x => x.Name, (key, group) => group.First()))
            {
                AutoItem.Add(r.Name);
            }
            itemTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemTxt.AutoCompleteCustomSource = AutoItem;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
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
            Rem i = new Rem(ID, dateTxt.Text, weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, Convert.ToDouble(amountTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            itemTxt.Text = "";
            amountTxt.Text = "";
            autocomplete();
        }

        private void itemTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void amountTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void endLbl_Click(object sender, EventArgs e)
        {

        }

        private void startLbl_Click(object sender, EventArgs e)
        {

        }

        private void weekLbl_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddRm_Load(object sender, EventArgs e)
        {

        }
    }
}
