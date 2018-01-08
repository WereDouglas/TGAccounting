using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class AddStaff : Form
    {
        Staff _user;
        string StaffID = "";
        public AddStaff(string staffID)
        {

            InitializeComponent();
            autocomplete();
            if (!String.IsNullOrEmpty(staffID))
            {
                StaffID = staffID;
                Profile(StaffID);

            }
        }
        private void Profile(string ID)
        {

            nameTxt.Text = Staff.List().First(k => k.Id.Contains(ID)).Name;
            contactTxt.Text = Staff.List().First(k => k.Id.Contains(ID)).Contact;


            Image img = Base64ToImage(Staff.List().First(k => k.Id.Contains(ID)).Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Staff r in Staff.List().GroupBy(x => x.Department, (key, group) => group.First()))
            {
                AutoItem.Add(r.Name);
            }
            departmentCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            departmentCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            departmentCbx.AutoCompleteCustomSource = AutoItem;


        }
        public System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // open file dialog 
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                imgCapture.Image = new Bitmap(open.FileName);
                imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
                fileUrlTxtBx.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }


            MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = ImageToBase64(stream);
            if (!String.IsNullOrEmpty(StaffID))
            {

                Staff _user = new Staff(StaffID, nameTxt.Text, contactTxt.Text, departmentCbx.Text, fullimage,emailTxt.Text);
                DBConnect.Update(_user, StaffID);

                MessageBox.Show("Information Updated");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        static string base64String = null;
        public string ImageToBase64(MemoryStream images)
        {

            using (System.Drawing.Image image = System.Drawing.Image.FromStream(images))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public MemoryStream ImageToStream(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return ms;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        string existingID = "";
        private void contactTxt_Leave(object sender, EventArgs e)
        {
            try
            {
               nameTxt.Text = Staff.List().First(r=>r.Contact.Contains(contactTxt.Text)).Name;
            }
            catch (Exception y)
            {
                Helper.Exceptions(y.Message, "on adding name auto fill the category list selected item");
            }
            try
            {
                emailTxt.Text = Staff.List().First(r => r.Contact.Contains(contactTxt.Text)).Email;
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {
                departmentCbx.Text = Staff.List().First(r => r.Contact.Contains(contactTxt.Text)).Department;
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {

                existingID = Staff.List().First(r => r.Contact.Contains(contactTxt.Text)).Id;
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }

            MemoryStream stream = ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = ImageToBase64(stream);

            if (!string.IsNullOrEmpty(existingID))
            {

                if (MessageBox.Show("YES or No?", "Are you sure you want to update the current existing information  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Staff j = new Staff(existingID, nameTxt.Text, contactTxt.Text, departmentCbx.Text, fullimage, emailTxt.Text);
                    DBConnect.Update(j, existingID);
                    existingID = "";
                    return;
                }

            }
            existingID = "";



            string id = Guid.NewGuid().ToString();
            Staff _user = new Staff(id, nameTxt.Text, contactTxt.Text, departmentCbx.Text, fullimage, emailTxt.Text);
            if (DBConnect.Insert(_user) != "")
            {
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
