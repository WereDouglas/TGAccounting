namespace TGAccounting
{
    partial class AnnualDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.yearCbx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.weeklyTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.annualTxt = new System.Windows.Forms.TextBox();
            this.annualLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(29, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Annual projection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(106, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Projected budgets";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.annualLbl);
            this.panel1.Controls.Add(this.annualTxt);
            this.panel1.Controls.Add(this.yearCbx);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.weeklyTxt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(7, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 129);
            this.panel1.TabIndex = 18;
            // 
            // yearCbx
            // 
            this.yearCbx.FormattingEnabled = true;
            this.yearCbx.Location = new System.Drawing.Point(149, 18);
            this.yearCbx.Name = "yearCbx";
            this.yearCbx.Size = new System.Drawing.Size(199, 26);
            this.yearCbx.TabIndex = 43;
            this.yearCbx.SelectedIndexChanged += new System.EventHandler(this.yearCbx_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(29, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "Year of operation";
            // 
            // weeklyTxt
            // 
            this.weeklyTxt.Location = new System.Drawing.Point(149, 80);
            this.weeklyTxt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.weeklyTxt.Name = "weeklyTxt";
            this.weeklyTxt.Size = new System.Drawing.Size(199, 21);
            this.weeklyTxt.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(29, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Weekly Projection";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::TGAccounting.Properties.Resources.Save_16__2_;
            this.button2.Location = new System.Drawing.Point(311, 174);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 34);
            this.button2.TabIndex = 21;
            this.button2.Text = "Save";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::TGAccounting.Properties.Resources.Close_16;
            this.button3.Location = new System.Drawing.Point(7, 174);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 34);
            this.button3.TabIndex = 20;
            this.button3.Text = "Close";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // annualTxt
            // 
            this.annualTxt.Location = new System.Drawing.Point(149, 51);
            this.annualTxt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.annualTxt.Name = "annualTxt";
            this.annualTxt.Size = new System.Drawing.Size(199, 21);
            this.annualTxt.TabIndex = 44;
            this.annualTxt.TextChanged += new System.EventHandler(this.annualTxt_TextChanged);
            // 
            // annualLbl
            // 
            this.annualLbl.AutoSize = true;
            this.annualLbl.BackColor = System.Drawing.Color.LightGray;
            this.annualLbl.Location = new System.Drawing.Point(356, 21);
            this.annualLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.annualLbl.Name = "annualLbl";
            this.annualLbl.Size = new System.Drawing.Size(15, 18);
            this.annualLbl.TabIndex = 45;
            this.annualLbl.Text = "#";
            // 
            // AnnualDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 230);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnnualDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AnnualDialog";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox yearCbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox weeklyTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox annualTxt;
        private System.Windows.Forms.Label annualLbl;
    }
}