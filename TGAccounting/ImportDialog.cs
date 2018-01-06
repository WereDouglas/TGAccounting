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
            this.DialogResult = DialogResult.OK;
            this.Dispose();
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

                    if (MessageBox.Show("YES or No?", "Confirm the year of operation  it being " + Convert.ToDateTime(dateTxt.Text).Year.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        string existingID;
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
                            // Console.WriteLine(row[0].ToString() + " " + row[u].ToString() + " Week:" + h  + " Week starting " + startWeek.ToString("dd-MM-yyyy") + " Week ending " + startWeek.AddDays(7).ToString("dd-MM-yyyy"));
                            if ( !row[0].ToString().Contains("Total") && !row[0].ToString().Contains("Week"))
                            {
                                if (categoryTxt.Text.Contains("Sales")) {
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
                                    Sale i = new Sale(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h.ToString(), startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), startWeek.AddDays(7).ToString("MMMM"));
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
                                    Labor i = new Labor(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h.ToString(), startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
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
                                    Taxes i = new Taxes(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h.ToString(), startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
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
                                    Supplies i = new Supplies(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h.ToString(), startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
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
                                    Repair i = new Repair(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h.ToString(), startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
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
                                    string ID = Guid.NewGuid().ToString();
                                    Equipment i = new Equipment(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), h.ToString(), startWeek.ToString("dd-MM-yyyy"), startWeek.AddDays(7).ToString("dd-MM-yyyy"), row[0].ToString().Replace("\"", string.Empty).Replace("'", string.Empty), Convert.ToDouble(row[u].ToString()), startWeek.AddDays(7).ToString("MMMM"));
                                    DBConnect.Insert(i);
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

    }
}
