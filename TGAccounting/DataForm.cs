﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class DataForm : Form
    {
        DataTable idt, sdt, ldt, tdt, saldt, supdt, rmdt, eqdt, invdt, expdt, costdt, caldt;
        DateTime pStart, pEnd;
        public User _user = new User();
        public static List<User> _userList = new List<User> { };
        public static DataTable table = new DataTable();
        DataTable t, s, ex, lg, cp, bg,pr;
        public DataForm()
        {
            InitializeComponent();
            globalYrTxt.Text = Helper.CurrentYear;
        }
        public void LoadUsers()
        {

            t = new DataTable();
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//2
            t.Columns.Add("id");//4
            t.Columns.Add("Name");//4                
            t.Columns.Add("Contact");//7            
            t.Columns.Add("View");
            t.Columns.Add("Delete");
            t.Columns.Add("image");//17
            t.Columns.Add("Password");//17
            t.Columns.Add("Level");//17

            Bitmap b = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (User u in User.List())
            {
                t.Rows.Add(new object[] { b, u.Id, u.Name, u.Contact, "View", "Delete", u.Image, u.Password,u.Level });
            }
            userGrid.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {
                        Image img = Helper.Base64ToImage(row["image"].ToString());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        row["Img"] = bps;
                    }
                    catch
                    {

                    }
                }
            });
            userGrid.AllowUserToAddRows = false;
            userGrid.Columns["View"].DefaultCellStyle.ForeColor = Color.Green;
            userGrid.Columns["View"].DefaultCellStyle.Font = new Font("Calibri", 15.5F, FontStyle.Underline, GraphicsUnit.Pixel);
            userGrid.Columns["Delete"].DefaultCellStyle.ForeColor = Color.Red;
            userGrid.Columns["Delete"].DefaultCellStyle.Font = new Font("Calibri", 15.5F, FontStyle.Underline, GraphicsUnit.Pixel);

            userGrid.RowTemplate.Height = 60;


            userGrid.Columns["id"].Visible = false;

            userGrid.Columns["image"].Visible = false;
            userGrid.Columns["Password"].Visible = false;
        }
        public void LoadStaff()
        {

            s = new DataTable();
            s.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//2
            s.Columns.Add("id");//4
            s.Columns.Add("Name");//4                
            s.Columns.Add("Contact");//7            
            s.Columns.Add("Department");
            s.Columns.Add("Delete");
            s.Columns.Add("View");
            s.Columns.Add("image");//17
            s.Columns.Add("email");

            Bitmap b = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Gray), 00, 00);
            }
            foreach (Staff u in Staff.List())
            {
                s.Rows.Add(new object[] { b, u.Id, u.Name, u.Contact, u.Department, "Delete", "View", u.Image, u.Email });
            }
            staffGrid.DataSource = s;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in s.Rows)
                {
                    try
                    {
                        Image img = Helper.Base64ToImage(row["image"].ToString());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        row["Img"] = bps;
                    }
                    catch
                    {

                    }
                }
            });
            staffGrid.AllowUserToAddRows = false;
            staffGrid.Columns["Delete"].DefaultCellStyle.ForeColor = Color.Red;
            staffGrid.Columns["Delete"].DefaultCellStyle.Font = new Font("Calibri", 15.5F, FontStyle.Underline, GraphicsUnit.Pixel);

            staffGrid.RowTemplate.Height = 60;
            staffGrid.Columns["id"].Visible = false;
            staffGrid.Columns["image"].Visible = false;




        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            string tab = current.Name.ToString();
            switch (tab)
            {
                case "laborTab":
                    LoadLabor(pStart, pEnd);
                    break;

                case "saleTab":
                    LoadSales();
                    break;
                case "tabTax":
                    LoadTax(pStart, pEnd);
                    break;              
                case "tabSupply":
                    LoadSupplies(pStart, pEnd);
                    break;
                case "tabEq":
                    LoadEquipment(pStart, pEnd);
                    break;
                case "tabRm":
                    LoadRepair(pStart, pEnd);
                    break;
                case "tabInventory":
                    LoadInventory(pStart, pEnd);
                    break;
                case "tabExpense":
                    LoadExpense(pStart, pEnd);
                    break;
                case "tabCogs":
                    LoadCogs();
                    break;
                case "tabCalendar":
                    break;
                case "tabUser":
                    LoadUsers();
                    break;
                case "tabStaff":
                    LoadStaff();
                    break;
                case "tabException":
                    LoadExecptions(pStart, pEnd);
                    break;
                case "tabLogs":
                    LoadLogs(pStart, pEnd);
                    break;
                case "tabComp":
                    LoadComps();
                    break;
                case "tabBudget":
                    LoadBudgets(pStart, pEnd);
                    break;
                case "tabProjection":
                    LoadProjection();
                    break;
            }
        }
       
        private void saleGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (!Helper.validateDouble(saleGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(saleGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }
            if (!string.IsNullOrEmpty(oldName) && oldName != saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString())
            {
                if (Helper.UserLevel < 2)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or No?", "Update all names from "+oldName+" to "+ saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString()) )
                    {
                        foreach (Sale s in Sale.List("SELECT * FROM sale WHERE item='"+ oldName + "'")) {
                            string SQL = "UPDATE sale SET item = '" + saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString() + "' WHERE id= '" + s.Id + "'";
                            DBConnect.save(SQL);
                        }
                        MessageBox.Show("Information updated ");
                        oldName = "";
                    }
                   
                }
            }

            try
            {
                Sale _c = new Sale(saleGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(saleGrid.Rows[e.RowIndex].Cells["week"].Value), saleGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString(), Convert.ToDouble(saleGrid.Rows[e.RowIndex].Cells["amount"].Value), saleGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, saleGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {

                Helper.Exceptions(c.Message, "Editing Sales grid");
                MessageBox.Show("You have an invalid entry !");
            }
            try
            {
                LoadSales();
            }
            catch { }
        }
        string oldName = "";
        private void saleGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString()))
            {
                oldName = saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString();
            }

        }

        private void laborGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Helper.validateDouble(laborGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(laborGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }

            try
            {
                Labor _c = new Labor(laborGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), laborGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(laborGrid.Rows[e.RowIndex].Cells["week"].Value), laborGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), laborGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), laborGrid.Rows[e.RowIndex].Cells["department"].Value.ToString(), Convert.ToDouble(laborGrid.Rows[e.RowIndex].Cells["amount"].Value), laborGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, laborGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {

                Helper.Exceptions(c.Message, "Editing labor grid");
                MessageBox.Show("You have an invalid entry !");
            }

        }

        private void taxGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Helper.validateDouble(taxGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(taxGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }

            try
            {
                Taxes _c = new Taxes(taxGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), taxGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(taxGrid.Rows[e.RowIndex].Cells["week"].Value), taxGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), taxGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), taxGrid.Rows[e.RowIndex].Cells["department"].Value.ToString(), Convert.ToDouble(taxGrid.Rows[e.RowIndex].Cells["amount"].Value), taxGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, taxGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {

                Helper.Exceptions(c.Message, "Editing tax grid");
                MessageBox.Show("You have an invalid entry !");
            }

        }

     
        private void supData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Helper.validateDouble(supData.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(supData.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }

            try
            {
                Supplies _c = new Supplies(supData.Rows[e.RowIndex].Cells["id"].Value.ToString(), supData.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(supData.Rows[e.RowIndex].Cells["week"].Value), supData.Rows[e.RowIndex].Cells["starting"].Value.ToString(), supData.Rows[e.RowIndex].Cells["ending"].Value.ToString(), supData.Rows[e.RowIndex].Cells["supplier"].Value.ToString(), Convert.ToDouble(supData.Rows[e.RowIndex].Cells["amount"].Value), supData.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, supData.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message, "Editing salary grid");
                MessageBox.Show("You have an invalid entry !");
            }

        }

        private void repGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            if (!Helper.validateDouble(repGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(repGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }

            try
            {
                Repair _c = new Repair(repGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), repGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(repGrid.Rows[e.RowIndex].Cells["week"].Value), repGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), repGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), repGrid.Rows[e.RowIndex].Cells["supplier"].Value.ToString(), Convert.ToDouble(repGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()), repGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, repGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message, "Editing repair and mantenance grid");
                MessageBox.Show("You have an invalid entry !");
            }
        }

        private void equipGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            if (!Helper.validateDouble(equipGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(equipGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }

            try
            {
                Equipment _c = new Equipment(equipGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), equipGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(equipGrid.Rows[e.RowIndex].Cells["week"].Value), equipGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), equipGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), equipGrid.Rows[e.RowIndex].Cells["supplier"].Value.ToString(), Convert.ToDouble(equipGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()), equipGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, equipGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message, "Editing equipment grid");
                MessageBox.Show("You have an invalid entry !");
            }
        }

        private void InventoryGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            if (!Helper.validateDouble(InventoryGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(InventoryGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }
            try
            {
                Inventory _c = new Inventory(InventoryGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(),InventoryGrid.Rows[e.RowIndex].Cells["year"].Value.ToString(), Convert.ToInt32(InventoryGrid.Rows[e.RowIndex].Cells["week"].Value), InventoryGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), InventoryGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), InventoryGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), InventoryGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), Convert.ToDouble(InventoryGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()), 0, 0, 0, InventoryGrid.Rows[e.RowIndex].Cells["month"].Value.ToString(), InventoryGrid.Rows[e.RowIndex].Cells["date"].Value.ToString());
                DBConnect.Update(_c, InventoryGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message, "Editing Inventory grid");
                MessageBox.Show("You have an invalid entry !");
            }

        }

        private void expenseGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            if (!Helper.validateDouble(expenseGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(expenseGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
            }

            if (!Helper.ifEmpty(expenseGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
            {
                MessageBox.Show("Invalid entry");
                return;
            }
            try
            {
                Expense _c = new Expense(expenseGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), expenseGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(expenseGrid.Rows[e.RowIndex].Cells["week"].Value), expenseGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), expenseGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), expenseGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), expenseGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), Convert.ToDouble(expenseGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()), expenseGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, expenseGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message, "Editing Expense grid");
                MessageBox.Show("You have an invalid entry !");
            }

        }

        private void profitGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void itemGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void costGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Helper.validateDouble(costGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }

            if (!Helper.validateDouble(costGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("Invalid value");
            }
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            if (!string.IsNullOrEmpty(oldName))
            {

                if (MessageBox.Show("YES or No?", "Update all names from " + oldName + " to " + costGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(costGrid.Rows[e.RowIndex].Cells["category"].Value.ToString()))
                    {
                        foreach (Cogs s in Cogs.List("SELECT * FROM cogs WHERE category='" + oldName + "'"))
                        {
                            string SQL = "UPDATE cogs SET category = '" + costGrid.Rows[e.RowIndex].Cells["category"].Value.ToString() + "' WHERE id= '" + s.Id + "'";
                            DBConnect.save(SQL);
                        }
                        MessageBox.Show("Information updated ");
                        oldName = "";
                    }
                    LoadCogs();
                }
            }

            try
            {
                Cogs _c = new Cogs(costGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), costGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), Convert.ToInt32(costGrid.Rows[e.RowIndex].Cells["week"].Value), costGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), costGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), costGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), 0, 0, Convert.ToDouble(costGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()), costGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
                DBConnect.Update(_c, costGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message, "Editing cost of goods grid");
                MessageBox.Show("You have an invalid entry !");
            }
        }

        private void costGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == costGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    string Query = "DELETE from cogs WHERE id ='" + costGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadCogs();
                }
            }
        }

        private void laborGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == laborGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from labor WHERE id ='" + laborGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadLabor(pStart, pEnd);
                }
            }
        }

        private void taxGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == taxGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from taxes WHERE id ='" + taxGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadTax(pStart, pEnd);
                }
            }
        }

        private void supData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == supData.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from supplies WHERE id ='" + supData.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadSupplies(pStart, pEnd);
                }
            }
        }

        private void repGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == repGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from repair WHERE id ='" + repGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadRepair(pStart, pEnd);
                }
            }
        }

        private void equipGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == equipGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from equipment WHERE id ='" + equipGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadEquipment(pStart, pEnd);
                }
            }
        }

        private void InventoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == InventoryGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from inventory WHERE id ='" + InventoryGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadInventory(pStart, pEnd);
                }
            }
        }

        private void expenseGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == expenseGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from expense WHERE id ='" + expenseGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadExpense(pStart, pEnd);
                }
            }
        }

        private void profitGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == userGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from user WHERE id ='" + userGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);
                    MessageBox.Show("Information deleted");
                    LoadUsers();

                }
            }
            if (e.ColumnIndex == userGrid.Columns["View"].Index && e.RowIndex >= 0)
            {
                using (AddUser form = new AddUser(userGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {


                    }
                }


            }

        }

        private void userGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Helper.UserLevel<2) {
                MessageBox.Show("Access Denied !");
                return;
            }
            if (String.IsNullOrEmpty(userGrid.Rows[e.RowIndex].Cells["Name"].Value.ToString()))
            {
                MessageBox.Show("Please input a name ");
                return;
            }
            string ID = userGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            User _c = new User(ID, userGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), userGrid.Rows[e.RowIndex].Cells["contact"].Value.ToString(), userGrid.Rows[e.RowIndex].Cells["password"].Value.ToString(), userGrid.Rows[e.RowIndex].Cells["image"].Value.ToString(),Convert.ToInt32(userGrid.Rows[e.RowIndex].Cells["level"].Value));
            DBConnect.Update(_c, ID);

        }

        private void staffGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(staffGrid.Rows[e.RowIndex].Cells["Name"].Value.ToString()))
            {
                MessageBox.Show("Please input a name ");
                return;
            }
            string ID = staffGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            Staff _c = new Staff(ID, staffGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), staffGrid.Rows[e.RowIndex].Cells["contact"].Value.ToString(), staffGrid.Rows[e.RowIndex].Cells["department"].Value.ToString(), staffGrid.Rows[e.RowIndex].Cells["image"].Value.ToString(), staffGrid.Rows[e.RowIndex].Cells["email"].Value.ToString());
            DBConnect.Update(_c, ID);
        }

        private void staffGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == staffGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from staff WHERE id ='" + staffGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);
                    MessageBox.Show("Information deleted");
                    LoadStaff();

                }
            }
            if (e.ColumnIndex == staffGrid.Columns["View"].Index && e.RowIndex >= 0)
            {

                using (AddStaff form = new AddStaff(staffGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {


                    }
                }
            }
        }

        private void ExceptionGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ExceptionGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (Helper.UserLevel < 3)
                    {
                        MessageBox.Show("Access Denied !");
                        return;
                    }
                    string Query = "DELETE from exceptions WHERE id ='" + ExceptionGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);
                    MessageBox.Show("Information deleted");

                }
            }
        }

        private void logGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == logGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from logs WHERE id ='" + logGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);
                    MessageBox.Show("Information deleted");

                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Helper.CurrentYear = globalYrTxt.Text;
        }

        private void globalYrTxt_Leave(object sender, EventArgs e)
        {
            Helper.CurrentYear = globalYrTxt.Text;
        }

        private void comGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == comGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (Helper.UserLevel < 3)
                    {
                        MessageBox.Show("Access Denied !");
                        return;
                    }
                    string Query = "DELETE from comp WHERE id ='" + comGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);
                    MessageBox.Show("Information deleted");

                }
            }
        }

        private void budgetGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == budgetGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (Helper.UserLevel < 3)
                    {
                        MessageBox.Show("Access Denied !");
                        return;
                    }
                    string Query = "DELETE from budget WHERE id ='" + budgetGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);
                    MessageBox.Show("Information deleted");

                }
            }
        }
        private void budgetGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(budgetGrid.Rows[e.RowIndex].Cells["Item"].Value.ToString()))
            {
                MessageBox.Show("Please input a name ");
                return;
            }
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            string ID = budgetGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            Budget _c = new Budget(ID, budgetGrid.Rows[e.RowIndex].Cells["Item"].Value.ToString(), budgetGrid.Rows[e.RowIndex].Cells["Category"].Value.ToString(), budgetGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(),Convert.ToDouble(budgetGrid.Rows[e.RowIndex].Cells["perc"].Value), Convert.ToDouble(budgetGrid.Rows[e.RowIndex].Cells["perc"].Value), budgetGrid.Rows[e.RowIndex].Cells["year"].Value.ToString());
            DBConnect.Update(_c, ID);
        }

        private void comGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(comGrid.Rows[e.RowIndex].Cells["Item"].Value.ToString()))
            {
                MessageBox.Show("Please input a name ");
                return;
            }
            if (!string.IsNullOrEmpty(oldName) && oldName != comGrid.Rows[e.RowIndex].Cells["item"].Value.ToString())
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }

                if (MessageBox.Show("YES or No?", "Update all names from " + oldName + " to " + comGrid.Rows[e.RowIndex].Cells["item"].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(comGrid.Rows[e.RowIndex].Cells["item"].Value.ToString()))
                    {
                        foreach (Comp s in Comp.List("SELECT * FROM comp WHERE item='" + oldName + "'"))
                        {
                            string SQL = "UPDATE comp SET item = '" + comGrid.Rows[e.RowIndex].Cells["item"].Value.ToString() + "' WHERE id= '" + s.Id + "'";
                            DBConnect.save(SQL);
                        }
                        MessageBox.Show("Information updated ");
                        oldName = "";
                    }
                    
                }               
                
            }
            string ID = comGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            Comp _c = new Comp(comGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), comGrid.Rows[e.RowIndex].Cells["year"].Value.ToString(), Convert.ToInt32(comGrid.Rows[e.RowIndex].Cells["week"].Value), comGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), comGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), comGrid.Rows[e.RowIndex].Cells["item"].Value.ToString(), Convert.ToDouble(comGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()), comGrid.Rows[e.RowIndex].Cells["month"].Value.ToString());
            DBConnect.Update(_c, ID);
            LoadComps();
        }

        private void costGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(costGrid.Rows[e.RowIndex].Cells["category"].Value.ToString()))
            {
                oldName = costGrid.Rows[e.RowIndex].Cells["category"].Value.ToString();
            }
        }

        private void dataProjection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataProjection.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from annual WHERE id ='" + dataProjection.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadProjection();
                }
            }
        }

        private void dataProjection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dataProjection.Rows[e.RowIndex].Cells["Year"].Value.ToString()))
            {
                MessageBox.Show("Please input a name ");
                return;
            }
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            string ID = dataProjection.Rows[e.RowIndex].Cells["id"].Value.ToString();
            Annual _c = new Annual(ID, dataProjection.Rows[e.RowIndex].Cells["year"].Value.ToString(),Convert.ToDouble(dataProjection.Rows[e.RowIndex].Cells["annuals"].Value), Convert.ToDouble(dataProjection.Rows[e.RowIndex].Cells["weekly"].Value));
            DBConnect.Update(_c, ID);
        }

        private void comGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(comGrid.Rows[e.RowIndex].Cells["item"].Value.ToString()))
            {
                oldName = comGrid.Rows[e.RowIndex].Cells["item"].Value.ToString();
            }
        }

        private void itemGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadSales()
        {
            saleGrid.DataSource = null;
            sdt = new DataTable();
            sdt.Columns.Add("id", typeof(string));
            sdt.Columns.Add("Item", typeof(string));
            sdt.Columns.Add("Amount", typeof(string));
            sdt.Columns.Add("Week");
            sdt.Columns.Add("Starting");
            sdt.Columns.Add("Ending");
            sdt.Columns.Add("Date");
            sdt.Columns.Add("Category");
            sdt.Columns.Add("Month");
            sdt.Columns.Add("Delete");
            string query = "SELECT * FROM sale WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Sale w in Sale.List(query))
            {
                sdt.Rows.Add(new object[] { w.Id, w.Item, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Category, w.Month, "Delete" });
            }
            saleGrid.DataSource = sdt;
            saleGrid.Columns["id"].Visible = false;
            saleGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void saleGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == saleGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (Helper.UserLevel < 3)
                {
                    MessageBox.Show("Access Denied !");
                    return;
                }
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from sale WHERE id ='" + saleGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadSales();
                }
            }
         /**   if (e.ColumnIndex == saleGrid.Columns["Item"].Index && e.RowIndex >= 0)
            {
                using (EditName form = new EditName(saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString(),"sale","item"))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadSales(pStart, pEnd);
                    }
                }
            }**/
        }
        /*Labor section**/
        private void LoadLabor(DateTime start, DateTime end)
        {
            laborGrid.DataSource = null;
            ldt = new DataTable();
            ldt.Columns.Add("id", typeof(string));
            ldt.Columns.Add("Name", typeof(string));
            ldt.Columns.Add("Amount", typeof(string));
            ldt.Columns.Add("Week");
            ldt.Columns.Add("Starting");
            ldt.Columns.Add("Ending");
            ldt.Columns.Add("Date");
            ldt.Columns.Add("Month");
            ldt.Columns.Add("Delete");
            string query = "SELECT * FROM labor WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Labor w in Labor.List(query))
            {
                ldt.Rows.Add(new object[] { w.Id, w.Item, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            laborGrid.DataSource = ldt;
            laborGrid.Columns["id"].Visible = false;
            laborGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void LoadTax(DateTime start, DateTime end)
        {
            taxGrid.DataSource = null;
            tdt = new DataTable();
            tdt.Columns.Add("id", typeof(string));
            tdt.Columns.Add("Name", typeof(string));
            tdt.Columns.Add("Amount", typeof(string));
            tdt.Columns.Add("Week");
            tdt.Columns.Add("Starting");
            tdt.Columns.Add("Ending");
            tdt.Columns.Add("Date");
            tdt.Columns.Add("Month");
            tdt.Columns.Add("Delete");
            string query = "SELECT * FROM taxes WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Taxes w in Taxes.List(query))
            {
                tdt.Rows.Add(new object[] { w.Id, w.Name, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            taxGrid.DataSource = tdt;
            taxGrid.Columns["id"].Visible = false;
            taxGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Orange;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void LoadSupplies(DateTime start, DateTime end)
        {
            supData.DataSource = null;
            supdt = new DataTable();
            supdt.Columns.Add("id", typeof(string));
            supdt.Columns.Add("Name", typeof(string));
            supdt.Columns.Add("Amount", typeof(string));
            supdt.Columns.Add("Week");
            supdt.Columns.Add("Starting");
            supdt.Columns.Add("Ending");
            supdt.Columns.Add("Date");
            supdt.Columns.Add("Month");
            supdt.Columns.Add("Delete");
            string query = "SELECT * FROM taxes WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Taxes w in Taxes.List(query))
            {
                supdt.Rows.Add(new object[] { w.Id, w.Name, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            supData.DataSource = supdt;
            supData.Columns["id"].Visible = false;
            supData.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void LoadRepair(DateTime start, DateTime end)
        {
            repGrid.DataSource = null;
            rmdt = new DataTable();
            rmdt.Columns.Add("id", typeof(string));
            rmdt.Columns.Add("Name", typeof(string));
            rmdt.Columns.Add("Amount", typeof(string));
            rmdt.Columns.Add("Week");
            rmdt.Columns.Add("Starting");
            rmdt.Columns.Add("Ending");
            rmdt.Columns.Add("Date");
            rmdt.Columns.Add("Month");
            rmdt.Columns.Add("Delete");
            string query = "SELECT * FROM repair WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Repair w in Repair.List(query))
            {
                rmdt.Rows.Add(new object[] { w.Id, w.Supplier, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            repGrid.DataSource = rmdt;
            repGrid.Columns["id"].Visible = false;
            repGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void LoadEquipment(DateTime start, DateTime end)
        {
            equipGrid.DataSource = null;
            eqdt = new DataTable();
            eqdt.Columns.Add("id", typeof(string));
            eqdt.Columns.Add("Name", typeof(string));
            eqdt.Columns.Add("Amount", typeof(string));
            eqdt.Columns.Add("Week");
            eqdt.Columns.Add("Starting");
            eqdt.Columns.Add("Ending");
            eqdt.Columns.Add("Date");
            eqdt.Columns.Add("Month");
            eqdt.Columns.Add("Delete");
            string query = "SELECT * FROM equipment WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Equipment w in Equipment.List(query))
            {
                eqdt.Rows.Add(new object[] { w.Id, w.Name, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            equipGrid.DataSource = eqdt;
            equipGrid.Columns["id"].Visible = false;
            equipGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void LoadInventory(DateTime start, DateTime end)
        {
            InventoryGrid.DataSource = null;
            invdt = new DataTable();
            invdt.Columns.Add("id", typeof(string));
            invdt.Columns.Add("Name", typeof(string));
            invdt.Columns.Add("Category", typeof(string));
            invdt.Columns.Add("Amount", typeof(string));
            invdt.Columns.Add("Week");
            invdt.Columns.Add("Starting");
            invdt.Columns.Add("Ending");
            invdt.Columns.Add("Year");
            invdt.Columns.Add("Date");
            invdt.Columns.Add("Month");
            invdt.Columns.Add("Delete");
            string query = "SELECT * FROM inventory WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Inventory w in Inventory.List(query))
            {
                invdt.Rows.Add(new object[] { w.Id, w.Name, w.Category, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Dop,w.Month, "Delete" });
            }
            InventoryGrid.DataSource = invdt;
            InventoryGrid.Columns["id"].Visible = false;
            InventoryGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void LoadExpense(DateTime start, DateTime end)
        {
            expenseGrid.DataSource = null;
            expdt = new DataTable();
            expdt.Columns.Add("id", typeof(string));
            expdt.Columns.Add("Name", typeof(string));
            expdt.Columns.Add("Amount", typeof(string));
            expdt.Columns.Add("Week");
            expdt.Columns.Add("Starting");
            expdt.Columns.Add("Ending");
            expdt.Columns.Add("Date");
            expdt.Columns.Add("Month");
            expdt.Columns.Add("Delete");
            string query = "SELECT * FROM expense WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Expense w in Expense.List(query))
            {
                expdt.Rows.Add(new object[] { w.Id, w.Name, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            expenseGrid.DataSource = expdt;
            expenseGrid.Columns["id"].Visible = false;
            expenseGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void LoadCogs()
        {
            costGrid.DataSource = null;
            costdt = new DataTable();
            costdt.Columns.Add("id", typeof(string));
            costdt.Columns.Add("Category", typeof(string));
            costdt.Columns.Add("Amount", typeof(string));
            costdt.Columns.Add("Week");
            costdt.Columns.Add("Starting");
            costdt.Columns.Add("Ending");
            costdt.Columns.Add("Date");
            costdt.Columns.Add("Month");
            costdt.Columns.Add("Delete");
            string query = "SELECT * FROM cogs WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Cogs w in Cogs.List(query))
            {
                costdt.Rows.Add(new object[] { w.Id, w.Category, w.Cost, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            costGrid.DataSource = costdt;
            costGrid.Columns["id"].Visible = false;
            costGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

        }
        private void LoadExecptions(DateTime start, DateTime end)
        {
            ex = new DataTable();
            ex.Columns.Add("id", typeof(string));
            ex.Columns.Add("Error", typeof(string));
            ex.Columns.Add("Action carried out", typeof(string));
            ex.Columns.Add("Created on");
            ex.Columns.Add("Delete");
            string query = "SELECT * FROM Exceptions";
            foreach (Exceptions w in Exceptions.List())
            {
                ex.Rows.Add(new object[] { w.Id, w.Message, w.Page, w.Created, "Delete" });
            }
            ExceptionGrid.DataSource = ex;
            ExceptionGrid.Columns["id"].Visible = false;
            ExceptionGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

        }
        private void LoadLogs(DateTime start, DateTime end)
        {
            logGrid.DataSource = null;
            lg = new DataTable();
            lg.Columns.Add("id", typeof(string));
            lg.Columns.Add("User", typeof(string));
            lg.Columns.Add("Action carried out", typeof(string));
            lg.Columns.Add("Created on");
            lg.Columns.Add("Delete");
            string query = "SELECT * FROM logs";
            foreach (Logs w in Logs.List())
            {
                lg.Rows.Add(new object[] { w.Id, w.Name, w.Actions, w.Created, "Delete" });
            }
            logGrid.DataSource = lg;
            logGrid.Columns["id"].Visible = false;
            logGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

        }
        private void LoadBudgets(DateTime start, DateTime end)
        {
            budgetGrid.DataSource = null;
            bg = new DataTable();
            bg.Columns.Add("id", typeof(string));
            bg.Columns.Add("Category", typeof(string));
            bg.Columns.Add("Item");
            bg.Columns.Add("Perc");
            bg.Columns.Add("Year", typeof(string));
            bg.Columns.Add("Delete");
            string query = "SELECT * FROM budget";
            foreach (Budget w in Budget.List(query))
            {
                bg.Rows.Add(new object[] { w.Id, w.Item, w.Category, w.Pct, w.Date, "Delete" });
            }
            budgetGrid.DataSource = bg;
            budgetGrid.Columns["id"].Visible = false;
            budgetGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

        }
        private void LoadProjection()
        {
            dataProjection.DataSource = null;
            pr = new DataTable();
            pr.Columns.Add("id", typeof(string));
            pr.Columns.Add("Year", typeof(string));
            pr.Columns.Add("Annuals");
            pr.Columns.Add("Weekly");

            pr.Columns.Add("Delete");
            string query = "SELECT * FROM annual";
            foreach (Annual w in Annual.List(query))
            {
                pr.Rows.Add(new object[] { w.Id, w.Year, w.Annuals, w.Weekly,"Delete" });
            }
            dataProjection.DataSource = pr;
            dataProjection.Columns["id"].Visible = false;
            dataProjection.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

        }
        private void LoadComps()
        {
            comGrid.DataSource= null;
            cp = new DataTable();
            cp.Columns.Add("id", typeof(string));
            cp.Columns.Add("Item", typeof(string));
            cp.Columns.Add("Amount", typeof(string));
            cp.Columns.Add("Week");
            cp.Columns.Add("Starting");
            cp.Columns.Add("Ending");
            cp.Columns.Add("Year");
            cp.Columns.Add("Month");
            cp.Columns.Add("Delete");
            string query = "SELECT * FROM comp WHERE date = '" + Helper.CurrentYear + "' AND month = '" + monthCbx.Text + "'";
            foreach (Comp w in Comp.List(query))
            {
                cp.Rows.Add(new object[] { w.Id, w.Item, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Month, "Delete" });
            }
            comGrid.DataSource = cp;
            comGrid.Columns["id"].Visible = false;
            comGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
    }
}
