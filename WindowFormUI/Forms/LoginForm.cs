using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowFormUI.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI
{
    public partial class LoginForm : Form
    {
        private readonly UsersTableAdapter usersTableAdapter ;
        public LoginForm()
        {
            InitializeComponent();
            usersTableAdapter = new UsersTableAdapter();
        }

        private void Login(object sender, EventArgs e)
        {

            bool validationResult = ValidateRegister(sender, new CancelEventArgs());

            if (validationResult)
            {
                // if the login is successful
                int id = usersTableAdapter.GetData().Where(x => x.username.Equals(guna2TextBox1.Text) && x.password.Equals(Encrypt(guna2TextBox2.Text))).FirstOrDefault().id;

                Home.userId = id;
                Home home = new Home();
                home.Show();

                this.Hide();
            }
        }

        private string Encrypt(string value)
        {
            //Using MD5 to encrypt a string
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                //Hash data
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private bool ValidateRegister(object sender, CancelEventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please fill in the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            int count = usersTableAdapter.GetUserByNameAndPassword(guna2TextBox1.Text, Encrypt(guna2TextBox2.Text)).Count();

            if (count == 0)
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            return true;
        }

        private void Mouse_Hover(object sender, EventArgs e)
        {
            // Change color of label6 to darker color
            label6.ForeColor = Color.FromArgb(10, 54, 80);
            label6.BackColor = Color.LightGray;
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            // Return color of label6 to normal
            label6.ForeColor = Color.FromArgb(30, 74, 233);
            label6.BackColor = Color.White;
        }

        private void ShowRegisterForm(object sender, EventArgs e)
        {
            // show the register form
            RegisterForm registerView = new RegisterForm();
            registerView.Show();

            this.Hide();
        }
    }
}
