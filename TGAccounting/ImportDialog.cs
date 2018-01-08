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
    public partial class ImportDialog : Form
    {
        public ImportDialog()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
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
                    if (MessageBox.Show("YES or No?", "Confirm the year  " + Convert.ToDateTime(dateTxt.Text).Year.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (categoryTxt.Text.Contains("COGS"))
                        {
                            if (string.IsNullOrEmpty(subcategory.Text))
                            {
                                subcategory.BackColor = Color.Pink;
                                MessageBox.Show("Please select the cost of goods category");
                                return;
                            }
                        }
                        if (categoryTxt.Text.Contains("Purchases"))
                        {
                            if (string.IsNullOrEmpty(subcategory.Text))
                            {
                                subcategory.BackColor = Color.Pink;
                                MessageBox.Show("Please select the Purchase category");
                                return;
                            }
                        }
                        if (categoryTxt.Text.Contains("Expenses"))
                        {
                            if (string.IsNullOrEmpty(subcategory.Text))
                            {
                                subcategory.BackColor = Color.Pink;
                                MessageBox.Show("Please select the category");
                                return;
                            }
                        }
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
        private void autocomplete()
        {
            subcategory.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (var r in Global.categories)
            {
                AutoItem.Add(r);
                subcategory.Items.Add(r);
            }
            subcategory.AutoCompleteMode = AutoCompleteMode.Suggest;
            subcategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
            subcategory.AutoCompleteCustomSource = AutoItem;


        }
        private void autocompleteExpense()
        {
            subcategory.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (var r in Global.expenseCategory)
            {
                AutoItem.Add(r);
                subcategory.Items.Add(r);
            }
            subcategory.AutoCompleteMode = AutoCompleteMode.Suggest;
            subcategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
            subcategory.AutoCompleteCustomSource = AutoItem;


        }
        string existingID;
        string begs = "0";
        string ends = "0";
        string cogs = "0";
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
                for (int u = 1; u < 53; u++)
                {
                    Console.WriteLine("NEW WEEK :" + h);
                    DateTime startWeek = Helper.FirstDateOfWeek(Convert.ToInt32(Helper.CurrentYear), h - 1, CultureInfo.CurrentCulture);
                    foreach (DataRow row in dtexcel.Rows)
                    {
                        //MessageBox.Show();
                        if (!string.IsNullOrEmpty(row[0].ToString()) && !string.IsNullOrEmpty(row[u].ToString()))
                        {
                            if (categoryTxt.Text.Contains("COGS"))
                            {
                                if (row[0].ToString().Contains("Beginning"))
                                {
                                    begs = row[u].ToString();
                                }
                                if (row[0].ToString().Contains("Ending"))
                                {
                                    ends = row[u].ToString();
                                }
                                if (row[0].ToString().Contains("Cost") || row[0].ToString().Contains("Total"))
                                {
                                    cogs = row[u].ToString();
                                }
                                Console.WriteLine("this is the line " + row[0].ToString() + " Value" + row[u].ToString());

                                try
                                {
                                    existingID = Cogs.List("SELECT * from cogs WHERE category='" + subcategory.Text + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                    string Query = "DELETE from cogs WHERE id ='" + existingID + "'";
                                    DBConnect.save(Query);
                                    Console.WriteLine("DELETE: " + row[0].ToString() + " " + row[u].ToString() + " Week:" + h + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));

                                }
                                catch
                                {
                                    existingID = "";
                                }
                                if (!string.IsNullOrEmpty(cogs) && cogs != "0")
                                {
                                    string ID = Guid.NewGuid().ToString();
                                    Cogs i = new Cogs(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), subcategory.Text, Convert.ToDouble(begs), Convert.ToDouble(ends), Convert.ToDouble(cogs), startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);

                                }
                            }
                            // Console.WriteLine(row[0].ToString() + " " + row[u].ToString() + " Week:" + h  + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));
                            if (!row[0].ToString().Contains("Total") && !row[0].ToString().Contains("Week") && !row[0].ToString().Contains("Week:"))
                            {
                                if (categoryTxt.Text.Contains("Purchases"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Inventory.List("SELECT * from inventory WHERE item='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from inventory WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    string ID = Guid.NewGuid().ToString();
                                    Inventory i = new Inventory(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), subcategory.Text, Convert.ToDouble(row[u].ToString()), 0, 0, 0, startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);
                                }
                                if (categoryTxt.Text.Contains("Sales"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Sale.List("SELECT * from sale WHERE item='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from sale WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    string ID = Guid.NewGuid().ToString();
                                    Sale i = new Sale(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);
                                }
                                if (categoryTxt.Text.Contains("Labor"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Labor.List("SELECT * from labor WHERE department='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from labor WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    string ID = Guid.NewGuid().ToString();
                                    Labor i = new Labor(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);
                                }
                                if (categoryTxt.Text.Contains("Payroll"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Taxes.List("SELECT * from taxes WHERE name='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from taxes WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    string ID = Guid.NewGuid().ToString();
                                    Taxes i = new Taxes(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);
                                }
                                if (categoryTxt.Text.Contains("Supplies"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Supplies.List("SELECT * from supplies WHERE supplier='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from supplies WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    string ID = Guid.NewGuid().ToString();
                                    Supplies i = new Supplies(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);
                                }
                                if (categoryTxt.Text.Contains("Repairs"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Repair.List("SELECT * from repair WHERE supplier='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from repair WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    string ID = Guid.NewGuid().ToString();
                                    Repair i = new Repair(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);
                                }
                                if (categoryTxt.Text.Contains("Equipment"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Equipment.List("SELECT * from equipment WHERE name='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from equipment WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    if (!string.IsNullOrEmpty(row[0].ToString()) && !string.IsNullOrEmpty(row[u].ToString()))
                                    {
                                        Console.WriteLine(row[0].ToString() + " " + row[u].ToString() + " Week:" + h + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));

                                        string ID = Guid.NewGuid().ToString();
                                        try
                                        {
                                            Equipment i = new Equipment(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
                                            DBConnect.Insert(i);
                                        }
                                        catch { }

                                    }
                                }
                                if (categoryTxt.Text.Contains("Expenses"))
                                {
                                    existingID = "";
                                    try
                                    {
                                        existingID = Expense.List("SELECT * from expense WHERE name='" + row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty) + "' AND week = '" + h + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
                                        string Query = "DELETE from expense WHERE id ='" + existingID + "'";
                                        DBConnect.save(Query);
                                    }
                                    catch
                                    {
                                        existingID = "";
                                    }
                                    if (!string.IsNullOrEmpty(row[0].ToString()) && !string.IsNullOrEmpty(row[u].ToString()))
                                    {
                                        Console.WriteLine(row[0].ToString() + " " + row[u].ToString() + " Week:" + h + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));

                                        string ID = Guid.NewGuid().ToString();
                                        try
                                        {
                                            Expense i = new Expense(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h, startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), subcategory.Text, Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
                                            DBConnect.Insert(i);
                                        }
                                        catch { }

                                    }
                                }
                            }
                        }
                    }
                    h++;
                }
                //}
                //catch { }
            }

        }

        private void categoryTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryTxt.Text.Contains("COGS"))
            {
                autocomplete();

            }
            if (categoryTxt.Text.Contains("Purchases"))
            {
                autocomplete();

            }
            if (categoryTxt.Text.Contains("Expenses"))
            {
                autocompleteExpense();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Confirm the year  " + Convert.ToDateTime(dateTxt.Text).Year.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (categoryTxt.Text.Contains("Expenses"))
                {
                    string Query = "DELETE from expense WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);

                }
                if (categoryTxt.Text.Contains("Equipment"))
                {
                    string Query = "DELETE from equipment WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);
                }
                if (categoryTxt.Text.Contains("Labor"))
                {
                    string Query = "DELETE from Labor WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);
                }
                if (categoryTxt.Text.Contains("Payroll"))
                {
                    string Query = "DELETE from Salary WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);
                }
                if (categoryTxt.Text.Contains("Sales"))
                {
                    string Query = "DELETE from Sale WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);
                }
                if (categoryTxt.Text.Contains("Supplies"))
                {
                    string Query = "DELETE from Supplies WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);
                }
                if (categoryTxt.Text.Contains("Repairs"))
                {
                    string Query = "DELETE from Repair WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);
                }
                if (categoryTxt.Text.Contains("COGS"))
                {
                    string Query = "DELETE from cogs WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'";
                    DBConnect.save(Query);
                }
                if (categoryTxt.Text.Contains("Purchases"))
                {
                    string Query = "DELETE from inventory WHERE date ='" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "' AND category = '" + subcategory.Text + "'";
                    DBConnect.save(Query);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
