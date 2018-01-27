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
    public partial class EventDialog : Form
    {
        public EventDialog(string start, string end, string date)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(start))
            {
                startHrTxt.Text = Convert.ToDateTime( start).ToString("HH");
                endHrTxt.Text = Convert.ToDateTime(end).ToString("HH");
                openedDate.Text = date;

                startMinTxt.Text = Convert.ToDateTime(start).ToString("MM"); ;
                endMinTxt.Text = Convert.ToDateTime(end).ToString("MM"); ;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (startHrTxt.Text == "" || endHrTxt.Text == "")
            {
                MessageBox.Show("Please input the start time and end time for the meeting /schedule ");
                return;
            }
            string ID = Guid.NewGuid().ToString();
            var start = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.startHrTxt.Text + ":" + startMinTxt.Text + ":00";
            var end = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.endHrTxt.Text + ":" + endMinTxt.Text + ":00";

            string priority = "Medium";
            if (!String.IsNullOrEmpty(priorityCbx.Text))
            {
                priority = priorityCbx.Text;
            }
           
            Events _event = new Events(ID, Helper.CleanString(this.detailsTxt.Text), start, end, "", "", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "", "due","", Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), "", priority, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "f", "", "", "", "","0", "");
            DBConnect.Insert(_event);
           
            MessageBox.Show("Information saved" + start + " to" + end);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
