namespace TGAccounting
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.supGrid = new System.Windows.Forms.TabControl();
            this.saleTab = new System.Windows.Forms.TabPage();
            this.saleGrid = new System.Windows.Forms.DataGridView();
            this.laborTab = new System.Windows.Forms.TabPage();
            this.laborGrid = new System.Windows.Forms.DataGridView();
            this.tabTax = new System.Windows.Forms.TabPage();
            this.taxGrid = new System.Windows.Forms.DataGridView();
            this.tabSupply = new System.Windows.Forms.TabPage();
            this.supData = new System.Windows.Forms.DataGridView();
            this.tabRm = new System.Windows.Forms.TabPage();
            this.repGrid = new System.Windows.Forms.DataGridView();
            this.tabEq = new System.Windows.Forms.TabPage();
            this.equipGrid = new System.Windows.Forms.DataGridView();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.InventoryGrid = new System.Windows.Forms.DataGridView();
            this.tabExpense = new System.Windows.Forms.TabPage();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.tabCogs = new System.Windows.Forms.TabPage();
            this.costGrid = new System.Windows.Forms.DataGridView();
            this.tabStaff = new System.Windows.Forms.TabPage();
            this.staffGrid = new System.Windows.Forms.DataGridView();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.userGrid = new System.Windows.Forms.DataGridView();
            this.tabComp = new System.Windows.Forms.TabPage();
            this.comGrid = new System.Windows.Forms.DataGridView();
            this.tabException = new System.Windows.Forms.TabPage();
            this.ExceptionGrid = new System.Windows.Forms.DataGridView();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.logGrid = new System.Windows.Forms.DataGridView();
            this.tabBudget = new System.Windows.Forms.TabPage();
            this.budgetGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.monthCbx = new System.Windows.Forms.ComboBox();
            this.button20 = new System.Windows.Forms.Button();
            this.globalYrTxt = new System.Windows.Forms.TextBox();
            this.supGrid.SuspendLayout();
            this.saleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleGrid)).BeginInit();
            this.laborTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laborGrid)).BeginInit();
            this.tabTax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxGrid)).BeginInit();
            this.tabSupply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supData)).BeginInit();
            this.tabRm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repGrid)).BeginInit();
            this.tabEq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipGrid)).BeginInit();
            this.tabInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryGrid)).BeginInit();
            this.tabExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.tabCogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costGrid)).BeginInit();
            this.tabStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffGrid)).BeginInit();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
            this.tabComp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comGrid)).BeginInit();
            this.tabException.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExceptionGrid)).BeginInit();
            this.tabLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            this.tabBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.budgetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // supGrid
            // 
            this.supGrid.Controls.Add(this.saleTab);
            this.supGrid.Controls.Add(this.laborTab);
            this.supGrid.Controls.Add(this.tabTax);
            this.supGrid.Controls.Add(this.tabSupply);
            this.supGrid.Controls.Add(this.tabRm);
            this.supGrid.Controls.Add(this.tabEq);
            this.supGrid.Controls.Add(this.tabInventory);
            this.supGrid.Controls.Add(this.tabExpense);
            this.supGrid.Controls.Add(this.tabCogs);
            this.supGrid.Controls.Add(this.tabStaff);
            this.supGrid.Controls.Add(this.tabUser);
            this.supGrid.Controls.Add(this.tabComp);
            this.supGrid.Controls.Add(this.tabException);
            this.supGrid.Controls.Add(this.tabLog);
            this.supGrid.Controls.Add(this.tabBudget);
            this.supGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supGrid.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supGrid.Location = new System.Drawing.Point(0, 0);
            this.supGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.supGrid.Name = "supGrid";
            this.supGrid.SelectedIndex = 0;
            this.supGrid.Size = new System.Drawing.Size(1244, 627);
            this.supGrid.TabIndex = 1;
            this.supGrid.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.supGrid.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // saleTab
            // 
            this.saleTab.Controls.Add(this.saleGrid);
            this.saleTab.Location = new System.Drawing.Point(4, 25);
            this.saleTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleTab.Name = "saleTab";
            this.saleTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleTab.Size = new System.Drawing.Size(1236, 598);
            this.saleTab.TabIndex = 0;
            this.saleTab.Text = "Sales";
            this.saleTab.UseVisualStyleBackColor = true;
            // 
            // saleGrid
            // 
            this.saleGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.saleGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saleGrid.Location = new System.Drawing.Point(3, 4);
            this.saleGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleGrid.Name = "saleGrid";
            this.saleGrid.Size = new System.Drawing.Size(1230, 590);
            this.saleGrid.TabIndex = 5;
            this.saleGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.saleGrid_CellBeginEdit);
            this.saleGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleGrid_CellClick);
            this.saleGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleGrid_CellEndEdit);
            // 
            // laborTab
            // 
            this.laborTab.Controls.Add(this.laborGrid);
            this.laborTab.Location = new System.Drawing.Point(4, 25);
            this.laborTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.laborTab.Name = "laborTab";
            this.laborTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.laborTab.Size = new System.Drawing.Size(1236, 598);
            this.laborTab.TabIndex = 1;
            this.laborTab.Text = "Labor";
            this.laborTab.UseVisualStyleBackColor = true;
            // 
            // laborGrid
            // 
            this.laborGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.laborGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.laborGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.laborGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laborGrid.Location = new System.Drawing.Point(3, 4);
            this.laborGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.laborGrid.Name = "laborGrid";
            this.laborGrid.Size = new System.Drawing.Size(1230, 590);
            this.laborGrid.TabIndex = 5;
            this.laborGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.laborGrid_CellClick);
            this.laborGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.laborGrid_CellEndEdit);
            // 
            // tabTax
            // 
            this.tabTax.Controls.Add(this.taxGrid);
            this.tabTax.Location = new System.Drawing.Point(4, 25);
            this.tabTax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabTax.Name = "tabTax";
            this.tabTax.Size = new System.Drawing.Size(1236, 598);
            this.tabTax.TabIndex = 2;
            this.tabTax.Text = "PayrollTaxes";
            this.tabTax.UseVisualStyleBackColor = true;
            // 
            // taxGrid
            // 
            this.taxGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taxGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taxGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taxGrid.Location = new System.Drawing.Point(0, 0);
            this.taxGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.taxGrid.Name = "taxGrid";
            this.taxGrid.Size = new System.Drawing.Size(1236, 598);
            this.taxGrid.TabIndex = 5;
            this.taxGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taxGrid_CellClick);
            this.taxGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.taxGrid_CellEndEdit);
            // 
            // tabSupply
            // 
            this.tabSupply.Controls.Add(this.supData);
            this.tabSupply.Location = new System.Drawing.Point(4, 25);
            this.tabSupply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSupply.Name = "tabSupply";
            this.tabSupply.Size = new System.Drawing.Size(1236, 598);
            this.tabSupply.TabIndex = 4;
            this.tabSupply.Text = "Supplies";
            this.tabSupply.UseVisualStyleBackColor = true;
            // 
            // supData
            // 
            this.supData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.supData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supData.Location = new System.Drawing.Point(0, 0);
            this.supData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.supData.Name = "supData";
            this.supData.Size = new System.Drawing.Size(1236, 598);
            this.supData.TabIndex = 5;
            this.supData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supData_CellClick);
            this.supData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.supData_CellEndEdit);
            // 
            // tabRm
            // 
            this.tabRm.Controls.Add(this.repGrid);
            this.tabRm.Location = new System.Drawing.Point(4, 25);
            this.tabRm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabRm.Name = "tabRm";
            this.tabRm.Size = new System.Drawing.Size(1236, 598);
            this.tabRm.TabIndex = 5;
            this.tabRm.Text = "Repair && Maintenance";
            this.tabRm.UseVisualStyleBackColor = true;
            // 
            // repGrid
            // 
            this.repGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.repGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.repGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.repGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repGrid.Location = new System.Drawing.Point(0, 0);
            this.repGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.repGrid.Name = "repGrid";
            this.repGrid.Size = new System.Drawing.Size(1236, 598);
            this.repGrid.TabIndex = 5;
            this.repGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.repGrid_CellClick);
            this.repGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.repGrid_CellEndEdit);
            // 
            // tabEq
            // 
            this.tabEq.Controls.Add(this.equipGrid);
            this.tabEq.Location = new System.Drawing.Point(4, 25);
            this.tabEq.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabEq.Name = "tabEq";
            this.tabEq.Size = new System.Drawing.Size(1236, 598);
            this.tabEq.TabIndex = 6;
            this.tabEq.Text = "Equipment";
            this.tabEq.UseVisualStyleBackColor = true;
            // 
            // equipGrid
            // 
            this.equipGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.equipGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.equipGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.equipGrid.Location = new System.Drawing.Point(0, 0);
            this.equipGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.equipGrid.Name = "equipGrid";
            this.equipGrid.Size = new System.Drawing.Size(1236, 598);
            this.equipGrid.TabIndex = 5;
            this.equipGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipGrid_CellClick);
            this.equipGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipGrid_CellEndEdit);
            // 
            // tabInventory
            // 
            this.tabInventory.Controls.Add(this.InventoryGrid);
            this.tabInventory.Location = new System.Drawing.Point(4, 25);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Size = new System.Drawing.Size(1236, 598);
            this.tabInventory.TabIndex = 11;
            this.tabInventory.Text = "Inventory purchases";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // InventoryGrid
            // 
            this.InventoryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InventoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventoryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventoryGrid.Location = new System.Drawing.Point(0, 0);
            this.InventoryGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InventoryGrid.Name = "InventoryGrid";
            this.InventoryGrid.Size = new System.Drawing.Size(1236, 598);
            this.InventoryGrid.TabIndex = 5;
            this.InventoryGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventoryGrid_CellClick);
            this.InventoryGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventoryGrid_CellEndEdit);
            // 
            // tabExpense
            // 
            this.tabExpense.Controls.Add(this.expenseGrid);
            this.tabExpense.Location = new System.Drawing.Point(4, 25);
            this.tabExpense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabExpense.Name = "tabExpense";
            this.tabExpense.Size = new System.Drawing.Size(1236, 598);
            this.tabExpense.TabIndex = 7;
            this.tabExpense.Text = "Expenses";
            this.tabExpense.UseVisualStyleBackColor = true;
            // 
            // expenseGrid
            // 
            this.expenseGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.expenseGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expenseGrid.Location = new System.Drawing.Point(0, 0);
            this.expenseGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.Size = new System.Drawing.Size(1236, 598);
            this.expenseGrid.TabIndex = 5;
            this.expenseGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellClick);
            this.expenseGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellEndEdit);
            // 
            // tabCogs
            // 
            this.tabCogs.Controls.Add(this.costGrid);
            this.tabCogs.Location = new System.Drawing.Point(4, 25);
            this.tabCogs.Name = "tabCogs";
            this.tabCogs.Size = new System.Drawing.Size(1236, 598);
            this.tabCogs.TabIndex = 14;
            this.tabCogs.Text = "Cost of Goods";
            this.tabCogs.UseVisualStyleBackColor = true;
            // 
            // costGrid
            // 
            this.costGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.costGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.costGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.costGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.costGrid.Location = new System.Drawing.Point(0, 0);
            this.costGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.costGrid.Name = "costGrid";
            this.costGrid.Size = new System.Drawing.Size(1236, 598);
            this.costGrid.TabIndex = 5;
            this.costGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.costGrid_CellBeginEdit);
            this.costGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.costGrid_CellClick);
            this.costGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.costGrid_CellEndEdit);
            // 
            // tabStaff
            // 
            this.tabStaff.Controls.Add(this.staffGrid);
            this.tabStaff.Location = new System.Drawing.Point(4, 25);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Size = new System.Drawing.Size(1236, 598);
            this.tabStaff.TabIndex = 15;
            this.tabStaff.Text = "Staff";
            this.tabStaff.UseVisualStyleBackColor = true;
            // 
            // staffGrid
            // 
            this.staffGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.staffGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.staffGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staffGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staffGrid.Location = new System.Drawing.Point(0, 0);
            this.staffGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.staffGrid.Name = "staffGrid";
            this.staffGrid.Size = new System.Drawing.Size(1236, 598);
            this.staffGrid.TabIndex = 6;
            this.staffGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.staffGrid_CellClick);
            this.staffGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.staffGrid_CellEndEdit);
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.userGrid);
            this.tabUser.Location = new System.Drawing.Point(4, 25);
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(1236, 598);
            this.tabUser.TabIndex = 16;
            this.tabUser.Text = "Users";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // userGrid
            // 
            this.userGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userGrid.Location = new System.Drawing.Point(0, 0);
            this.userGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userGrid.Name = "userGrid";
            this.userGrid.Size = new System.Drawing.Size(1236, 598);
            this.userGrid.TabIndex = 7;
            this.userGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userGrid_CellClick);
            this.userGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.userGrid_CellEndEdit);
            // 
            // tabComp
            // 
            this.tabComp.Controls.Add(this.comGrid);
            this.tabComp.Location = new System.Drawing.Point(4, 25);
            this.tabComp.Name = "tabComp";
            this.tabComp.Size = new System.Drawing.Size(1236, 598);
            this.tabComp.TabIndex = 19;
            this.tabComp.Text = "Complimentaries";
            this.tabComp.UseVisualStyleBackColor = true;
            // 
            // comGrid
            // 
            this.comGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.comGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.comGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comGrid.Location = new System.Drawing.Point(0, 0);
            this.comGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comGrid.Name = "comGrid";
            this.comGrid.Size = new System.Drawing.Size(1236, 598);
            this.comGrid.TabIndex = 8;
            this.comGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.comGrid_CellBeginEdit);
            this.comGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.comGrid_CellClick);
            this.comGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.comGrid_CellEndEdit);
            // 
            // tabException
            // 
            this.tabException.Controls.Add(this.ExceptionGrid);
            this.tabException.Location = new System.Drawing.Point(4, 25);
            this.tabException.Name = "tabException";
            this.tabException.Size = new System.Drawing.Size(1236, 598);
            this.tabException.TabIndex = 17;
            this.tabException.Text = "Exceptions";
            this.tabException.UseVisualStyleBackColor = true;
            // 
            // ExceptionGrid
            // 
            this.ExceptionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExceptionGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExceptionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExceptionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExceptionGrid.Location = new System.Drawing.Point(0, 0);
            this.ExceptionGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExceptionGrid.Name = "ExceptionGrid";
            this.ExceptionGrid.Size = new System.Drawing.Size(1236, 598);
            this.ExceptionGrid.TabIndex = 7;
            this.ExceptionGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExceptionGrid_CellClick);
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.logGrid);
            this.tabLog.Location = new System.Drawing.Point(4, 25);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(1236, 598);
            this.tabLog.TabIndex = 18;
            this.tabLog.Text = "Logs";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // logGrid
            // 
            this.logGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.logGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logGrid.Location = new System.Drawing.Point(0, 0);
            this.logGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logGrid.Name = "logGrid";
            this.logGrid.Size = new System.Drawing.Size(1236, 598);
            this.logGrid.TabIndex = 7;
            this.logGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logGrid_CellClick);
            // 
            // tabBudget
            // 
            this.tabBudget.Controls.Add(this.budgetGrid);
            this.tabBudget.Location = new System.Drawing.Point(4, 25);
            this.tabBudget.Name = "tabBudget";
            this.tabBudget.Size = new System.Drawing.Size(1236, 598);
            this.tabBudget.TabIndex = 20;
            this.tabBudget.Text = "Budget";
            this.tabBudget.UseVisualStyleBackColor = true;
            // 
            // budgetGrid
            // 
            this.budgetGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.budgetGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.budgetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.budgetGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.budgetGrid.Location = new System.Drawing.Point(0, 0);
            this.budgetGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.budgetGrid.Name = "budgetGrid";
            this.budgetGrid.Size = new System.Drawing.Size(1236, 598);
            this.budgetGrid.TabIndex = 8;
            this.budgetGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.budgetGrid_CellClick);
            this.budgetGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.budgetGrid_CellEndEdit);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.monthCbx);
            this.splitContainer2.Panel1.Controls.Add(this.button20);
            this.splitContainer2.Panel1.Controls.Add(this.globalYrTxt);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.supGrid);
            this.splitContainer2.Size = new System.Drawing.Size(1244, 665);
            this.splitContainer2.SplitterDistance = 34;
            this.splitContainer2.TabIndex = 0;
            // 
            // monthCbx
            // 
            this.monthCbx.FormattingEnabled = true;
            this.monthCbx.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthCbx.Location = new System.Drawing.Point(468, 4);
            this.monthCbx.Name = "monthCbx";
            this.monthCbx.Size = new System.Drawing.Size(173, 24);
            this.monthCbx.TabIndex = 2;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(278, 5);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(185, 23);
            this.button20.TabIndex = 1;
            this.button20.Text = "Set current year of operation";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // globalYrTxt
            // 
            this.globalYrTxt.Location = new System.Drawing.Point(13, 8);
            this.globalYrTxt.Name = "globalYrTxt";
            this.globalYrTxt.Size = new System.Drawing.Size(248, 20);
            this.globalYrTxt.TabIndex = 0;
            this.globalYrTxt.Leave += new System.EventHandler(this.globalYrTxt_Leave);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 665);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataForm";
            this.Text = "Input Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.supGrid.ResumeLayout(false);
            this.saleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saleGrid)).EndInit();
            this.laborTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.laborGrid)).EndInit();
            this.tabTax.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxGrid)).EndInit();
            this.tabSupply.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.supData)).EndInit();
            this.tabRm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repGrid)).EndInit();
            this.tabEq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.equipGrid)).EndInit();
            this.tabInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryGrid)).EndInit();
            this.tabExpense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            this.tabCogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.costGrid)).EndInit();
            this.tabStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffGrid)).EndInit();
            this.tabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
            this.tabComp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comGrid)).EndInit();
            this.tabException.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExceptionGrid)).EndInit();
            this.tabLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            this.tabBudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.budgetGrid)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl supGrid;
        private System.Windows.Forms.TabPage saleTab;
        private System.Windows.Forms.TabPage laborTab;
        private System.Windows.Forms.TabPage tabTax;
        private System.Windows.Forms.TabPage tabSupply;
        private System.Windows.Forms.TabPage tabRm;
        private System.Windows.Forms.TabPage tabEq;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabExpense;
        private System.Windows.Forms.TabPage tabCogs;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView saleGrid;
        private System.Windows.Forms.DataGridView laborGrid;
        private System.Windows.Forms.DataGridView taxGrid;
        private System.Windows.Forms.DataGridView supData;
        private System.Windows.Forms.DataGridView repGrid;
        private System.Windows.Forms.DataGridView equipGrid;
        private System.Windows.Forms.DataGridView InventoryGrid;
        private System.Windows.Forms.DataGridView expenseGrid;
        private System.Windows.Forms.DataGridView costGrid;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.DataGridView staffGrid;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabException;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.DataGridView userGrid;
        private System.Windows.Forms.DataGridView ExceptionGrid;
        private System.Windows.Forms.DataGridView logGrid;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.TextBox globalYrTxt;
        private System.Windows.Forms.TabPage tabComp;
        private System.Windows.Forms.DataGridView comGrid;
        private System.Windows.Forms.TabPage tabBudget;
        private System.Windows.Forms.DataGridView budgetGrid;
        private System.Windows.Forms.ComboBox monthCbx;
    }
}