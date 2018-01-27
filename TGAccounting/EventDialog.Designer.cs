namespace TGAccounting
{
    partial class EventDialog
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
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.priorityCbx = new System.Windows.Forms.ComboBox();
            this.endMinTxt = new System.Windows.Forms.TextBox();
            this.startMinTxt = new System.Windows.Forms.TextBox();
            this.detailsTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endHrTxt = new System.Windows.Forms.ComboBox();
            this.startHrTxt = new System.Windows.Forms.ComboBox();
            this.openedDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(114, 287);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 205;
            this.label8.Text = "Priority:";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(222, 287);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 29);
            this.button5.TabIndex = 8;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 202;
            this.label6.Text = "Remarks/Reason";
            // 
            // priorityCbx
            // 
            this.priorityCbx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.priorityCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.priorityCbx.FormattingEnabled = true;
            this.priorityCbx.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.priorityCbx.Location = new System.Drawing.Point(114, 131);
            this.priorityCbx.Margin = new System.Windows.Forms.Padding(4);
            this.priorityCbx.Name = "priorityCbx";
            this.priorityCbx.Size = new System.Drawing.Size(181, 24);
            this.priorityCbx.TabIndex = 5;
            // 
            // endMinTxt
            // 
            this.endMinTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.endMinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.endMinTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endMinTxt.Location = new System.Drawing.Point(218, 105);
            this.endMinTxt.Name = "endMinTxt";
            this.endMinTxt.Size = new System.Drawing.Size(43, 20);
            this.endMinTxt.TabIndex = 4;
            // 
            // startMinTxt
            // 
            this.startMinTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.startMinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startMinTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startMinTxt.Location = new System.Drawing.Point(218, 75);
            this.startMinTxt.Name = "startMinTxt";
            this.startMinTxt.Size = new System.Drawing.Size(43, 20);
            this.startMinTxt.TabIndex = 2;
            // 
            // detailsTxt
            // 
            this.detailsTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.detailsTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsTxt.Location = new System.Drawing.Point(107, 191);
            this.detailsTxt.Multiline = true;
            this.detailsTxt.Name = "detailsTxt";
            this.detailsTxt.Size = new System.Drawing.Size(188, 58);
            this.detailsTxt.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 196;
            this.label4.Text = "Start time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 197;
            this.label5.Text = "End time:";
            // 
            // endHrTxt
            // 
            this.endHrTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.endHrTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endHrTxt.FormattingEnabled = true;
            this.endHrTxt.Items.AddRange(new object[] {
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.endHrTxt.Location = new System.Drawing.Point(114, 101);
            this.endHrTxt.Name = "endHrTxt";
            this.endHrTxt.Size = new System.Drawing.Size(82, 24);
            this.endHrTxt.TabIndex = 3;
            // 
            // startHrTxt
            // 
            this.startHrTxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.startHrTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startHrTxt.Items.AddRange(new object[] {
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.startHrTxt.Location = new System.Drawing.Point(114, 72);
            this.startHrTxt.Name = "startHrTxt";
            this.startHrTxt.Size = new System.Drawing.Size(82, 24);
            this.startHrTxt.TabIndex = 1;
            // 
            // openedDate
            // 
            this.openedDate.Location = new System.Drawing.Point(115, 31);
            this.openedDate.Name = "openedDate";
            this.openedDate.Size = new System.Drawing.Size(177, 20);
            this.openedDate.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 195;
            this.label7.Text = "Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(114, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 218;
            this.label11.Text = "Add Events";
            // 
            // EventDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 354);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.priorityCbx);
            this.Controls.Add(this.endMinTxt);
            this.Controls.Add(this.startMinTxt);
            this.Controls.Add(this.detailsTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endHrTxt);
            this.Controls.Add(this.startHrTxt);
            this.Controls.Add(this.openedDate);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EventDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EventDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox priorityCbx;
        private System.Windows.Forms.TextBox endMinTxt;
        private System.Windows.Forms.TextBox startMinTxt;
        private System.Windows.Forms.TextBox detailsTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox endHrTxt;
        private System.Windows.Forms.ComboBox startHrTxt;
        private System.Windows.Forms.DateTimePicker openedDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
    }
}