namespace TGAccounting
{
    partial class ChartForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.SaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SuppliesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CogsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CompBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProfit = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button21 = new System.Windows.Forms.Button();
            this.maxWeeksTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer7 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.saleTab = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.categoryCbx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reportViewerInventory = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabExpense = new System.Windows.Forms.TabPage();
            this.reportViewerExpense = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GraphsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LaborBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TaxesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExpenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EquipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProfitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SaleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuppliesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CogsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabProfit.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.saleTab.SuspendLayout();
            this.tabInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaborBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SaleBindingSource
            // 
            this.SaleBindingSource.DataSource = typeof(TGAccounting.Model.Sale);
            // 
            // SuppliesBindingSource
            // 
            this.SuppliesBindingSource.DataSource = typeof(TGAccounting.Model.Supplies);
            // 
            // CogsBindingSource
            // 
            this.CogsBindingSource.DataSource = typeof(TGAccounting.Model.Cogs);
            // 
            // CompBindingSource
            // 
            this.CompBindingSource.DataSource = typeof(TGAccounting.Model.Comp);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1241, 709);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProfit);
            this.tabControl1.Controls.Add(this.saleTab);
            this.tabControl1.Controls.Add(this.tabInventory);
            this.tabControl1.Controls.Add(this.tabExpense);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1241, 680);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabProfit
            // 
            this.tabProfit.Controls.Add(this.tableLayoutPanel1);
            this.tabProfit.Location = new System.Drawing.Point(4, 25);
            this.tabProfit.Name = "tabProfit";
            this.tabProfit.Size = new System.Drawing.Size(1233, 651);
            this.tabProfit.TabIndex = 12;
            this.tabProfit.Text = "Charts";
            this.tabProfit.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportViewer7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.846154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.15385F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1233, 651);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button21);
            this.panel1.Controls.Add(this.maxWeeksTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 28);
            this.panel1.TabIndex = 0;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(257, 3);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 4;
            this.button21.Text = "Generate";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // maxWeeksTxt
            // 
            this.maxWeeksTxt.Location = new System.Drawing.Point(126, 5);
            this.maxWeeksTxt.Name = "maxWeeksTxt";
            this.maxWeeksTxt.Size = new System.Drawing.Size(125, 20);
            this.maxWeeksTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Max number of weeks ";
            // 
            // reportViewer7
            // 
            this.reportViewer7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer7.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetAnnual";
            reportDataSource1.Value = this.ProfitBindingSource;
            this.reportViewer7.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer7.LocalReport.ReportEmbeddedResource = "TGAccounting.ReportAnnual.rdlc";
            this.reportViewer7.Location = new System.Drawing.Point(3, 41);
            this.reportViewer7.Name = "reportViewer7";
            this.reportViewer7.Size = new System.Drawing.Size(1227, 607);
            this.reportViewer7.TabIndex = 1;
            // 
            // saleTab
            // 
            this.saleTab.Controls.Add(this.reportViewer1);
            this.saleTab.Location = new System.Drawing.Point(4, 25);
            this.saleTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleTab.Name = "saleTab";
            this.saleTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleTab.Size = new System.Drawing.Size(1233, 651);
            this.saleTab.TabIndex = 0;
            this.saleTab.Text = "Sales";
            this.saleTab.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetSaleGraph";
            reportDataSource2.Value = this.SaleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TGAccounting.ReportChartSales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1227, 643);
            this.reportViewer1.TabIndex = 1;
            // 
            // tabInventory
            // 
            this.tabInventory.Controls.Add(this.splitContainer1);
            this.tabInventory.Location = new System.Drawing.Point(4, 25);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Size = new System.Drawing.Size(1233, 651);
            this.tabInventory.TabIndex = 11;
            this.tabInventory.Text = "Inventory purchases";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.categoryCbx);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewerInventory);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 651);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 0;
            // 
            // categoryCbx
            // 
            this.categoryCbx.FormattingEnabled = true;
            this.categoryCbx.Location = new System.Drawing.Point(68, 7);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.Size = new System.Drawing.Size(218, 24);
            this.categoryCbx.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Category:";
            // 
            // reportViewerInventory
            // 
            this.reportViewerInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewerInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetInventory";
            reportDataSource3.Value = null;
            this.reportViewerInventory.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerInventory.LocalReport.ReportEmbeddedResource = "TGAccounting.ReportInventory.rdlc";
            this.reportViewerInventory.Location = new System.Drawing.Point(0, 0);
            this.reportViewerInventory.Name = "reportViewerInventory";
            this.reportViewerInventory.Size = new System.Drawing.Size(1233, 602);
            this.reportViewerInventory.TabIndex = 0;
            // 
            // tabExpense
            // 
            this.tabExpense.Controls.Add(this.reportViewerExpense);
            this.tabExpense.Location = new System.Drawing.Point(4, 25);
            this.tabExpense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabExpense.Name = "tabExpense";
            this.tabExpense.Size = new System.Drawing.Size(1233, 651);
            this.tabExpense.TabIndex = 7;
            this.tabExpense.Text = "Expenses";
            this.tabExpense.UseVisualStyleBackColor = true;
            // 
            // reportViewerExpense
            // 
            this.reportViewerExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewerExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSetExpense";
            reportDataSource4.Value = null;
            this.reportViewerExpense.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewerExpense.LocalReport.ReportEmbeddedResource = "TGAccounting.ReportExpense.rdlc";
            this.reportViewerExpense.Location = new System.Drawing.Point(0, 0);
            this.reportViewerExpense.Name = "reportViewerExpense";
            this.reportViewerExpense.Size = new System.Drawing.Size(1233, 651);
            this.reportViewerExpense.TabIndex = 0;
            // 
            // GraphsBindingSource
            // 
            this.GraphsBindingSource.DataSource = typeof(TGAccounting.Model.Graphs);
            // 
            // LaborBindingSource
            // 
            this.LaborBindingSource.DataSource = typeof(TGAccounting.Model.Labor);
            // 
            // TaxesBindingSource
            // 
            this.TaxesBindingSource.DataSource = typeof(TGAccounting.Model.Taxes);
            // 
            // InventoryBindingSource
            // 
            this.InventoryBindingSource.DataSource = typeof(TGAccounting.Model.Inventory);
            // 
            // ExpenseBindingSource
            // 
            this.ExpenseBindingSource.DataSource = typeof(TGAccounting.Model.Expense);
            // 
            // ReportBindingSource
            // 
            this.ReportBindingSource.DataSource = typeof(TGAccounting.Model.Report);
            // 
            // SalaryBindingSource
            // 
            this.SalaryBindingSource.DataSource = typeof(TGAccounting.Model.Salary);
            // 
            // EquipmentBindingSource
            // 
            this.EquipmentBindingSource.DataSource = typeof(TGAccounting.Model.Equipment);
            // 
            // ProfitBindingSource
            // 
            this.ProfitBindingSource.DataSource = typeof(TGAccounting.Model.Profit);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 709);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChartForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SaleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuppliesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CogsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompBindingSource)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabProfit.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.saleTab.ResumeLayout(false);
            this.tabInventory.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabExpense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GraphsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaborBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.BindingSource GraphsBindingSource;
        private System.Windows.Forms.BindingSource SaleBindingSource;
        private System.Windows.Forms.BindingSource SuppliesBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage saleTab;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox categoryCbx;
        private System.Windows.Forms.Label label6;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerInventory;
        private System.Windows.Forms.TabPage tabExpense;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerExpense;
        private System.Windows.Forms.BindingSource LaborBindingSource;
        private System.Windows.Forms.BindingSource TaxesBindingSource;
        private System.Windows.Forms.BindingSource InventoryBindingSource;
        private System.Windows.Forms.BindingSource ExpenseBindingSource;
        private System.Windows.Forms.BindingSource ReportBindingSource;
        private System.Windows.Forms.BindingSource CogsBindingSource;
        private System.Windows.Forms.BindingSource SalaryBindingSource;
        private System.Windows.Forms.BindingSource EquipmentBindingSource;
        private System.Windows.Forms.BindingSource CompBindingSource;
        private System.Windows.Forms.TabPage tabProfit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.TextBox maxWeeksTxt;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer7;
        private System.Windows.Forms.BindingSource ProfitBindingSource;
    }
}