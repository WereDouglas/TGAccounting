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
using TGAccounting.SQLite;

namespace TGAccounting
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            createSqlliteDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeForm frm = new HomeForm();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void createSqlliteDB()
        {
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Sale()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Items()));           
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Category()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Department()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Labor()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Taxes()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Supplies()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Repair()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Equipment()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Inventory()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Expense()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Cogs()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Events()));

            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Company()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new User()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Staff()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Salary()));

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
