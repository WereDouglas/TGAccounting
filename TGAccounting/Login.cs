using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            newInstallation();
            autocomplete();
            InitializeCulture();
        }
        protected  void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("en-Gb");
            CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
          //  base.InitializeCulture();
        }
        private void newInstallation()
        {
            try
            {
                string c = Company.List().First().Name;

                Image img = Helper.Base64ToImage(Company.List().First().Logo);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                //Bitmap bps = new Bitmap(bmp, 50, 50);
                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Helper.CompanyID = Company.List().First().Id;
            }
            catch
            {

                using (CompanyProfile form = new CompanyProfile(Helper.CompanyID))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            string c = User.List().First().Name;
                        }
                        catch
                        {

                            using (AddUser forms = new AddUser(null))
                            {
                                DialogResult drs = forms.ShowDialog();
                                if (drs == DialogResult.OK)
                                {
                                    autocomplete();
                                }
                            }

                        }

                    }
                }
            }
            try
            {
                string c = User.List().First().Name;
            }
            catch
            {


                using (AddUser forms = new AddUser(null))
                {
                    DialogResult drs = forms.ShowDialog();
                    if (drs == DialogResult.OK)
                    {
                        autocomplete();
                    }
                }

            }

        }
        private void autocomplete()
        {
            contactCbx.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (User r in User.List().GroupBy(x => x.Contact, (key, group) => group.First()))
            {
                AutoItem.Add(r.Contact);
                contactCbx.Items.Add(r.Contact);
            }
            contactCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            contactCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            contactCbx.AutoCompleteCustomSource = AutoItem;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            List<User> _userList = new List<User>();
            try
            {
                _userList = User.List().Where(j => j.Contact.Contains(contactCbx.Text) && (j.Password.Contains(Helper.MD5Hash(passwordTxt.Text)))).ToList();

            }
            catch
            {

                MessageBox.Show("No Users defined");
                button2.Visible = true;
                return;

            }

            if (contactCbx.Text == "" || passwordTxt.Text == "")
            {
                MessageBox.Show("Insert login credentials");
                button2.Visible = true;
                return;
            }
            if (User.List().Count() > 0 && _userList.Count() > 0)
            {
                Helper.UserID = _userList.First().Id;
                Helper.UserImage = _userList.First().Image;
                Helper.UserName = _userList.First().Name;
                Helper.Log(Helper.UserName,"Log in ");
                Helper.CompanyID = Company.List().First().Id;

                HomeForm frm = new HomeForm();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid User Check contact and password !");
                button2.Visible = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();

        }
        private void createSqlliteDB()
        {
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Sale()));
                     
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
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Logs()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Exceptions()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Budget()));
            Connection.createSQLLiteDB(DBConnect.CreateDBSQL(new Comp()));

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void contactTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }
    }
}
