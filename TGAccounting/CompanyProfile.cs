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
    public partial class CompanyProfile : Form
    {
        Company _company;
        string CompanyID = "";
        public CompanyProfile(string companyID)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(companyID))
            {
                CompanyID = companyID;
                Profile(CompanyID);
               
            }
        }
        private void Profile(string ID)
        {

            nameTxt.Text = Company.List().First(k => k.Id.Contains(ID)).Name;
            addressTxt.Text = Company.List().First(k => k.Id.Contains(ID)).Address;
            currentTxt.Text = Company.List().First(k => k.Id.Contains(ID)).Current;
            // emailTxt.Text = Global.companys.First(k => k.Id.Contains(ID)).Email;



            Image img = Helper.Base64ToImage(Company.List().First(k => k.Id.Contains(ID)).Logo);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
            //Bitmap bps = new Bitmap(bmp, 50, 50);
            imgCapture.Image = bmp;
            imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
            if (nameTxt.Text == "")
            {
                nameTxt.BackColor = Color.Red;
                return;
            }          

            MemoryStream stream =  Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
            string id = Guid.NewGuid().ToString();
            Company _company = new Company(id, nameTxt.Text,addressTxt.Text, fullimage,currentTxt.Text);
            if (DBConnect.Insert(_company) != "")
            {
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
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
            if (!String.IsNullOrEmpty(CompanyID))
            {

                Company _company = new Company(CompanyID, nameTxt.Text, addressTxt.Text, fullimage,currentTxt.Text);
                DBConnect.Update(_company, CompanyID);

                MessageBox.Show("Information Updated");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void currentTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow two decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
