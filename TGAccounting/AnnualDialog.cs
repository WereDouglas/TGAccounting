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
    public partial class AnnualDialog : Form
    {
        public AnnualDialog()
        {
            InitializeComponent();
            int current = DateTime.Now.Year;
            for (int y = -2; y < 4; y++)
            {

                yearCbx.Items.Add((current + y));

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(annualTxt.Text))
            {
                MessageBox.Show("", "Please input the annual projection value !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string test = "";
            try
            {
                test = Annual.List("SELECT * from budget WHERE year='" + yearCbx.Text + "' AND weekly = '" + weeklyTxt.Text + "'").First().Annuals.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            if (!string.IsNullOrEmpty(test))
            {
                MessageBox.Show("Value inserted !");
                return;
            }

            string ID = Guid.NewGuid().ToString();
            Annual i = new Annual(ID, yearCbx.Text, Convert.ToDouble(annualTxt.Text), Convert.ToDouble(weeklyTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved");
            annualTxt.Text = "";
            weeklyTxt.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void annualTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                weeklyTxt.Text = (Convert.ToDouble(annualTxt.Text) / Convert.ToDouble(annualLbl.Text)).ToString();
            }
            catch { }
        }

        private void yearCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                annualLbl.Text = Helper.GetWeeksInYear(Convert.ToInt32(yearCbx.Text)).ToString();
            }
            catch { }
        }
    }
}
