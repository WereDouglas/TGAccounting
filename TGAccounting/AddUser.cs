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
    public partial class AddUser : Form
    {
        User _user;
        string UserID = "";
        public AddUser(string userID)
        {
            InitializeComponent();
            button3.Visible = false;
            if (!String.IsNullOrEmpty(userID))
            {
                UserID = userID;
                Profile(UserID);
                button3.Visible = true;
            }
        }
        string originalPassword = "";
        private void Profile(string ID)
        {

            nameTxt.Text = User.List().First(k => k.Id.Contains(ID)).Name;           
            contactTxt.Text = User.List().First(k => k.Id.Contains(ID)).Contact;
            
           // emailTxt.Text = Global.users.First(k => k.Id.Contains(ID)).Email;
           
            pass2Txt.Text = User.List().First(k => k.Id.Contains(ID)).Password;
            passTxt.Text = User.List().First(k => k.Id.Contains(ID)).Password;
            originalPassword = User.List().First(k => k.Id.Contains(ID)).Password;
            // initialTxt.Text = Global.users.First(k => k.Id.Contains(ID)).InitialPassword;
            

            Image img = Helper.Base64ToImage(User.List().First(k => k.Id.Contains(ID)).Image);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
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
        
       

        private void pass2Txt_Leave(object sender, EventArgs e)
        {
            if (pass2Txt.Text != passTxt.Text) {

                pass2Txt.BackColor = Color.Red;
                MessageBox.Show("Passwords do not match ");
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }
            

            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
            if (!String.IsNullOrEmpty(UserID))
            {
                User _user = new User(UserID, nameTxt.Text, contactTxt.Text, Helper.MD5Hash(pass2Txt.Text), fullimage,Convert.ToInt32(levelCbx.Text));
                DBConnect.Update(_user, UserID);              
                MessageBox.Show("Information Updated");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pass2Txt.Text != passTxt.Text)
            {
                MessageBox.Show("Passwords do not match");
                passTxt.BackColor = Color.Red;
                return;

            }
            if (UserID != Helper.UserID)
            {
                MessageBox.Show("You cannot reset the users password it seems its not your profile !");
                return;
            }

            string SQL = "UPDATE users SET passwords = '" + Helper.MD5Hash(pass2Txt.Text) + "' WHERE id = '" + UserID + "'";
            DBConnect.Execute(SQL);

            MessageBox.Show("information updated password will take effect on the next log in !");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Helper.UserLevel < 3)
            {
                MessageBox.Show("Access Denied !");
                return;
            }
            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }
            if (levelCbx.Text == "")
            {
                levelCbx.BackColor = Color.Red;
                return;
            }
            if (contactTxt.Text == "")
            {
                contactTxt.BackColor = Color.Red;
                return;
            }

            if (pass2Txt.Text != passTxt.Text)
            {
                MessageBox.Show("Passwords do not match");
                passTxt.BackColor = Color.Red;
                return;

            }
            if (String.IsNullOrEmpty(passTxt.Text))
            {
                passTxt.BackColor = Color.Red;
                return;
            }

            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
            string id = Guid.NewGuid().ToString();
            User _user = new User(id, nameTxt.Text, contactTxt.Text, Helper.MD5Hash(pass2Txt.Text), fullimage,Convert.ToInt32(levelCbx.Text));
            if (DBConnect.Insert(_user) != "")
            {
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
