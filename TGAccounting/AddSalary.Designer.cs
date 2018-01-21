namespace TGAccounting
{
    partial class AddSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSalary));
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ourTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.biweeklyTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryCbx = new System.Windows.Forms.ComboBox();
            this.departmentCbx = new System.Windows.Forms.ComboBox();
            this.annualTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.weeklyTxt = new System.Windows.Forms.TextBox();
            this.staffTxt = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(165, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "Add Staff payment information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.ourTxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.biweeklyTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.categoryCbx);
            this.panel1.Controls.Add(this.departmentCbx);
            this.panel1.Controls.Add(this.annualTxt);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.weeklyTxt);
            this.panel1.Controls.Add(this.staffTxt);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(28, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 266);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(379, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 85);
            this.pictureBox1.TabIndex = 179;
            this.pictureBox1.TabStop = false;
            // 
            // ourTxt
            // 
            this.ourTxt.Location = new System.Drawing.Point(143, 225);
            this.ourTxt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ourTxt.Name = "ourTxt";
            this.ourTxt.Size = new System.Drawing.Size(213, 21);
            this.ourTxt.TabIndex = 6;
            this.ourTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.annualTxt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(10, 229);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 51;
            this.label4.Text = "Our Cost";
            // 
            // biweeklyTxt
            // 
            this.biweeklyTxt.Location = new System.Drawing.Point(141, 188);
            this.biweeklyTxt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.biweeklyTxt.Name = "biweeklyTxt";
            this.biweeklyTxt.Size = new System.Drawing.Size(213, 21);
            this.biweeklyTxt.TabIndex = 5;
            this.biweeklyTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.annualTxt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(10, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Bi-weekly";
            // 
            // categoryCbx
            // 
            this.categoryCbx.FormattingEnabled = true;
            this.categoryCbx.Location = new System.Drawing.Point(143, 90);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.Size = new System.Drawing.Size(211, 26);
            this.categoryCbx.TabIndex = 2;
            // 
            // departmentCbx
            // 
            this.departmentCbx.FormattingEnabled = true;
            this.departmentCbx.Location = new System.Drawing.Point(143, 53);
            this.departmentCbx.Name = "departmentCbx";
            this.departmentCbx.Size = new System.Drawing.Size(211, 26);
            this.departmentCbx.TabIndex = 1;
            // 
            // annualTxt
            // 
            this.annualTxt.Location = new System.Drawing.Point(141, 130);
            this.annualTxt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.annualTxt.Name = "annualTxt";
            this.annualTxt.Size = new System.Drawing.Size(213, 21);
            this.annualTxt.TabIndex = 3;
            this.annualTxt.TextChanged += new System.EventHandler(this.annualTxt_TextChanged);
            this.annualTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.annualTxt_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.Location = new System.Drawing.Point(10, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 18);
            this.label9.TabIndex = 43;
            this.label9.Text = "Annual Pay";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.Location = new System.Drawing.Point(10, 162);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "Weekly";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.Location = new System.Drawing.Point(10, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 18);
            this.label7.TabIndex = 40;
            this.label7.Text = "Category/Payment for:";
            // 
            // weeklyTxt
            // 
            this.weeklyTxt.Location = new System.Drawing.Point(141, 158);
            this.weeklyTxt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.weeklyTxt.Name = "weeklyTxt";
            this.weeklyTxt.Size = new System.Drawing.Size(213, 21);
            this.weeklyTxt.TabIndex = 4;
            this.weeklyTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.annualTxt_KeyPress);
            // 
            // staffTxt
            // 
            this.staffTxt.FormattingEnabled = true;
            this.staffTxt.Location = new System.Drawing.Point(143, 23);
            this.staffTxt.Name = "staffTxt";
            this.staffTxt.Size = new System.Drawing.Size(211, 26);
            this.staffTxt.TabIndex = 0;
            this.staffTxt.Leave += new System.EventHandler(this.staffTxt_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightGray;
            this.label11.Location = new System.Drawing.Point(10, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 18);
            this.label11.TabIndex = 37;
            this.label11.Text = "Staff member";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Location = new System.Drawing.Point(10, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 18);
            this.label10.TabIndex = 36;
            this.label10.Text = "Department";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::TGAccounting.Properties.Resources.Close_16;
            this.button3.Location = new System.Drawing.Point(171, 316);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 34);
            this.button3.TabIndex = 25;
            this.button3.Text = "Close";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::TGAccounting.Properties.Resources.Save_16__2_;
            this.button4.Location = new System.Drawing.Point(323, 316);
            this.button4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 34);
            this.button4.TabIndex = 24;
            this.button4.Text = "Save";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // AddSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 364);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddSalary";
            this.Load += new System.EventHandler(this.AddSalary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox annualTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox weeklyTxt;
        private System.Windows.Forms.ComboBox staffTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox departmentCbx;
        private System.Windows.Forms.ComboBox categoryCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox biweeklyTxt;
        private System.Windows.Forms.TextBox ourTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}