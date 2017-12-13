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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
            autocomplete();
        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Category r in Category.List())
            {
                AutoItem.Add(r.Name);
                categoryTxt.Items.Add(r.Name);
            }
            categoryTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryTxt.AutoCompleteCustomSource = AutoItem;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ID = Guid.NewGuid().ToString();
            Items i = new Items(ID,nameTxt.Text, categoryTxt.Text,descriptionRTxt.Text);
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
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
