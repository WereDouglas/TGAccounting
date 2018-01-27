using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class AddInventory : Form
    {
        public AddInventory()
        {
            InitializeComponent();
            autocompleteCategory();
            autocomplete();
            if (!string.IsNullOrEmpty(Helper.CurrentStarting) && !string.IsNullOrEmpty(Helper.CurrentEnding))
            {
                session();
            }
            else
            {
                fillUp(Convert.ToDateTime(DateTime.Now.Date));
            }
        }
        string month;
        private void fillUp(DateTime d)
        {
            month = d.ToString("MMMM");
            int year = Convert.ToInt32(d.ToString("yyyy"));
            int week = Helper.GetIso8601WeekOfYear(d);
            weekLbl.Text = week.ToString();
            startLbl.Text = Helper.FirstDateOfWeek(year, week).Date.ToString("dd-MM-yyyy");
            endLbl.Text = Convert.ToDateTime(startLbl.Text).AddDays(+6).Date.ToString("dd-MM-yyyy");
        }
        private void session()
        {
            weekLbl.Text = Helper.CurrentWeek.ToString();
            startLbl.Text = Helper.CurrentStarting;
            endLbl.Text = Helper.CurrentEnding;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (var r in Global.inventoryItems)
            {
                AutoItem.Add(r);
            }
            itemTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemTxt.AutoCompleteCustomSource = AutoItem;


        }
        private void autocompleteCategory()
        {
            categoryTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (var r in Global.categories)
            {
                AutoItem.Add(r);
                categoryTxt.Items.Add(r);
            }
            categoryTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryTxt.AutoCompleteCustomSource = AutoItem;


        }
        string existingID;
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
            if (!string.IsNullOrEmpty(existingID))
            {

                if (MessageBox.Show("YES or No?", "Are you sure you want to update the current existing information  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Inventory j = new Inventory(existingID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), Convert.ToInt32(weekLbl.Text), startLbl.Text, endLbl.Text, itemTxt.Text, categoryTxt.Text, Convert.ToDouble(amountTxt.Text), 0, 0, 0, month, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"));

                    DBConnect.Update(j, existingID);
                }
                return;
            }
            else
            {

                string ID = Guid.NewGuid().ToString();
                Inventory i = new Inventory(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), Convert.ToInt32(weekLbl.Text), startLbl.Text, endLbl.Text, itemTxt.Text, categoryTxt.Text, Convert.ToDouble(amountTxt.Text), 0, 0, 0, month, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"));
                DBConnect.Insert(i);
                MessageBox.Show("Information Saved ");
                itemTxt.Text = "";
                amountTxt.Text = "";
                autocompleteCategory();
                autocomplete();
            }


        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
            itemTxt_Leave(null, null);
        }

        private void itemTxt_Leave(object sender, EventArgs e)
        {
            existingID = "";
            int prevWeek = Convert.ToInt32(weekLbl.Text) - 1;
            try { categoryTxt.Text = Inventory.List("SELECT * from inventory WHERE name='" + itemTxt.Text + "'").First().Category; }
            catch (Exception y)
            {
              //  Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }

            try
            {
                amountTxt.Text = Inventory.List("SELECT * from inventory WHERE name='" + itemTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "' dop = '" + Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy") + "'").First().Amount.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {
                month = Inventory.List("SELECT * from inventory WHERE name='" + itemTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Month;
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {
                existingID = Inventory.List("SELECT * from inventory WHERE name='" + itemTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "' AND dop = '" + Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy") + "'").First().Id.ToString();
            }
            catch { }

        }

        private void amountTxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    //try
                    //{
                    DataTable dtExcel = new DataTable();
                    if (string.IsNullOrEmpty(categoryTxt.Text))
                    {
                        MessageBox.Show("Please select the category ");
                        categoryTxt.BackColor = Color.Red;
                        return;
                    }

                    if (MessageBox.Show("YES or No?", "Confirm " + categoryTxt.Text + " year " + Convert.ToDateTime(dateTxt.Text).Year.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        LoadingWindow.ShowSplashScreen();
                        ReadExcel(filePath, fileExt); //read excel file  
                        LoadingWindow.CloseForm();
                    }
                    //  dataGridView1.Visible = true;
                    // dataGridView1.DataSource = dtExcel;
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message.ToString());
                    //}
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }

        }
        public void ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {

                //try
                //{
                OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                int h = 1;
                //for (int u = 1; u < dtexcel.Columns.Count; u++)
                for (int u = 1; u < 60; u++)
                {
                    Console.WriteLine("NEW WEEK :" + h);
                    DateTime startWeek = Helper.FirstDateOfWeek(Convert.ToInt32(Helper.CurrentYear), h - 1);
                    foreach (DataRow row in dtexcel.Rows)
                    {
                        try
                        {
                            //MessageBox.Show();
                            if (!string.IsNullOrEmpty(row[0].ToString()) && !string.IsNullOrEmpty(row[u].ToString()))
                            {
                                // Console.WriteLine(row[0].ToString() + " " + row[u].ToString() + " Week:" + h  + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));
                                if (!row[0].ToString().Contains("Inventory") && !row[0].ToString().Contains("Total") && !row[0].ToString().Contains("Week"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Inventory.List("SELECT * from inventory WHERE name='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from inventory WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                        Console.WriteLine("DELETE: " + row[0].ToString() + " " + row[u].ToString() + " Week:" + h + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));

                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }

                                    string ID = Guid.NewGuid().ToString();
                                    Inventory i = new Inventory(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), categoryTxt.Text, Convert.ToDouble(row[u].ToString()), 0, 0, 0, startWeek.AddDays(7).ToString("MMMM"), Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"));
                                    DBConnect.Insert(i);
                                    Console.WriteLine("INSERT: " + row[0].ToString() + " " + row[u].ToString().Replace("'", @"\'") + " Week:" + h + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));
                                    
                                }

                            }
                        }
                        catch { }
                    }
                    h++;
                }
                //}
                //catch { }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(categoryTxt.Text))
            {
                MessageBox.Show("Please select the category ");
                categoryTxt.BackColor = Color.Red;
                return;
            }
            if (MessageBox.Show("YES or No?", "Confirm the year  " + Convert.ToDateTime(dateTxt.Text).Year.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string Query = "DELETE from inventory WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "' AND category = '" + categoryTxt.Text + "'";
                DBConnect.save(Query);


            }
        }
    }
}
