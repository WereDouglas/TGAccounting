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
    public partial class AddDepartment : Form
    {
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = Guid.NewGuid().ToString();
            Department i = new Department(ID, nameTxt.Text, descriptionRTxt.Text);
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
