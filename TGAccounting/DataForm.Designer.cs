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
            this.tabCogs = new System.Windows.Forms.TabPage();
            this.salesTab = new System.Windows.Forms.TabPage();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.itemGrid = new System.Windows.Forms.DataGridView();
            this.tabPL = new System.Windows.Forms.TabPage();
            this.tabExpense = new System.Windows.Forms.TabPage();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.tabEq = new System.Windows.Forms.TabPage();
            this.tabRm = new System.Windows.Forms.TabPage();
            this.tabSupply = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabTax = new System.Windows.Forms.TabPage();
            this.laborTab = new System.Windows.Forms.TabPage();
            this.saleTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.saleGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.salesTab.SuspendLayout();
            this.itemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCogs
            // 
            this.tabCogs.Location = new System.Drawing.Point(4, 25);
            this.tabCogs.Name = "tabCogs";
            this.tabCogs.Size = new System.Drawing.Size(1067, 636);
            this.tabCogs.TabIndex = 14;
            this.tabCogs.Text = "Cost of Goods";
            this.tabCogs.UseVisualStyleBackColor = true;
            // 
            // salesTab
            // 
            this.salesTab.Controls.Add(this.splitContainer1);
            this.salesTab.Location = new System.Drawing.Point(4, 25);
            this.salesTab.Name = "salesTab";
            this.salesTab.Size = new System.Drawing.Size(1067, 636);
            this.salesTab.TabIndex = 10;
            this.salesTab.Text = "Sales list";
            this.salesTab.UseVisualStyleBackColor = true;
            // 
            // itemTab
            // 
            this.itemTab.Controls.Add(this.itemGrid);
            this.itemTab.ForeColor = System.Drawing.Color.Red;
            this.itemTab.Location = new System.Drawing.Point(4, 25);
            this.itemTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.itemTab.Name = "itemTab";
            this.itemTab.Size = new System.Drawing.Size(1067, 636);
            this.itemTab.TabIndex = 9;
            this.itemTab.Text = "Items";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // itemGrid
            // 
            this.itemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemGrid.Location = new System.Drawing.Point(0, 0);
            this.itemGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.Size = new System.Drawing.Size(1067, 636);
            this.itemGrid.TabIndex = 4;
            // 
            // tabPL
            // 
            this.tabPL.Location = new System.Drawing.Point(4, 25);
            this.tabPL.Name = "tabPL";
            this.tabPL.Size = new System.Drawing.Size(1067, 636);
            this.tabPL.TabIndex = 13;
            this.tabPL.Text = "Profit && Loss";
            this.tabPL.UseVisualStyleBackColor = true;
            // 
            // tabExpense
            // 
            this.tabExpense.Location = new System.Drawing.Point(4, 25);
            this.tabExpense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabExpense.Name = "tabExpense";
            this.tabExpense.Size = new System.Drawing.Size(1067, 636);
            this.tabExpense.TabIndex = 7;
            this.tabExpense.Text = "Expenses";
            this.tabExpense.UseVisualStyleBackColor = true;
            // 
            // tabInventory
            // 
            this.tabInventory.Location = new System.Drawing.Point(4, 25);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Size = new System.Drawing.Size(1067, 636);
            this.tabInventory.TabIndex = 11;
            this.tabInventory.Text = "Inventory purchases";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // tabEq
            // 
            this.tabEq.Location = new System.Drawing.Point(4, 25);
            this.tabEq.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabEq.Name = "tabEq";
            this.tabEq.Size = new System.Drawing.Size(1067, 636);
            this.tabEq.TabIndex = 6;
            this.tabEq.Text = "Equipment";
            this.tabEq.UseVisualStyleBackColor = true;
            // 
            // tabRm
            // 
            this.tabRm.Location = new System.Drawing.Point(4, 25);
            this.tabRm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabRm.Name = "tabRm";
            this.tabRm.Size = new System.Drawing.Size(1067, 636);
            this.tabRm.TabIndex = 5;
            this.tabRm.Text = "Repair && Maintenance";
            this.tabRm.UseVisualStyleBackColor = true;
            // 
            // tabSupply
            // 
            this.tabSupply.Location = new System.Drawing.Point(4, 25);
            this.tabSupply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSupply.Name = "tabSupply";
            this.tabSupply.Size = new System.Drawing.Size(1067, 636);
            this.tabSupply.TabIndex = 4;
            this.tabSupply.Text = "Supplies";
            this.tabSupply.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1067, 636);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Salaries  && Insurance";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabTax
            // 
            this.tabTax.Location = new System.Drawing.Point(4, 25);
            this.tabTax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabTax.Name = "tabTax";
            this.tabTax.Size = new System.Drawing.Size(1067, 636);
            this.tabTax.TabIndex = 2;
            this.tabTax.Text = "PayrollTaxes";
            this.tabTax.UseVisualStyleBackColor = true;
            // 
            // laborTab
            // 
            this.laborTab.Location = new System.Drawing.Point(4, 25);
            this.laborTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.laborTab.Name = "laborTab";
            this.laborTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.laborTab.Size = new System.Drawing.Size(1067, 636);
            this.laborTab.TabIndex = 1;
            this.laborTab.Text = "Labor";
            this.laborTab.UseVisualStyleBackColor = true;
            // 
            // saleTab
            // 
            this.saleTab.Location = new System.Drawing.Point(4, 25);
            this.saleTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleTab.Name = "saleTab";
            this.saleTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleTab.Size = new System.Drawing.Size(1067, 636);
            this.saleTab.TabIndex = 0;
            this.saleTab.Text = "Sales";
            this.saleTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.saleTab);
            this.tabControl1.Controls.Add(this.laborTab);
            this.tabControl1.Controls.Add(this.tabTax);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabSupply);
            this.tabControl1.Controls.Add(this.tabRm);
            this.tabControl1.Controls.Add(this.tabEq);
            this.tabControl1.Controls.Add(this.tabInventory);
            this.tabControl1.Controls.Add(this.tabExpense);
            this.tabControl1.Controls.Add(this.tabPL);
            this.tabControl1.Controls.Add(this.itemTab);
            this.tabControl1.Controls.Add(this.salesTab);
            this.tabControl1.Controls.Add(this.tabCogs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1075, 665);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // saleGrid
            // 
            this.saleGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.saleGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saleGrid.Location = new System.Drawing.Point(0, 0);
            this.saleGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleGrid.Name = "saleGrid";
            this.saleGrid.Size = new System.Drawing.Size(1067, 586);
            this.saleGrid.TabIndex = 6;
            this.saleGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleGrid_CellClick);
            this.saleGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleGrid_CellEndEdit);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saleGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 636);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 7;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 665);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataForm";
            this.Text = "Input Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.salesTab.ResumeLayout(false);
            this.itemTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saleGrid)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCogs;
        private System.Windows.Forms.TabPage salesTab;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.TabPage tabPL;
        private System.Windows.Forms.TabPage tabExpense;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabEq;
        private System.Windows.Forms.TabPage tabRm;
        private System.Windows.Forms.TabPage tabSupply;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabTax;
        private System.Windows.Forms.TabPage laborTab;
        private System.Windows.Forms.TabPage saleTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView saleGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}