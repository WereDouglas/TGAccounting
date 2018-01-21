using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGAccounting
{
    public partial class EditName : Form
    {
        List<string> tables = new List<string>();
        public EditName(string column,string table,string field)
        {
            InitializeComponent();
            previousTxt.Text = column;
            itemCbx.Text = table;
            fieldTxt.Text = field;
            foreach (string t in Global.Tables() ) {
                itemCbx.Items.Add(t);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to update the current existing information  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(newTxt.Text) && !string.IsNullOrEmpty(previousTxt.Text))
                {
                    string SQL = "UPDATE "+ itemCbx.Text + " SET " + fieldTxt.Text + " = '" + newTxt.Text + "' WHERE "+fieldTxt.Text+" = '" + previousTxt.Text + "'";
                    DBConnect.Execute(SQL);
                    MessageBox.Show("Information updated ");
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
