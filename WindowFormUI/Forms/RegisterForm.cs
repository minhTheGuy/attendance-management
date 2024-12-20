﻿using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UsersTableAdapter usersTableAdapter;
        public RegisterForm()
        {
            InitializeComponent();
            usersTableAdapter = new UsersTableAdapter();
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

        private void Register(object sender, EventArgs e)
        {
            // validate the username and password
            bool validationResult = ValidateRegister(sender, new CancelEventArgs());

            if (validationResult)
            {
                usersTableAdapter.Insert(guna2TextBox1.Text, Encrypt(guna2TextBox3.Text), guna2TextBox2.Text);
                LoginForm loginView = new LoginForm();
                loginView.Show();
                this.Dispose();
            }
        }

        private bool ValidateRegister(object sender, CancelEventArgs e)
        {
            // if there's no input in the username or email or password, show the message box
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "")
            {
                MessageBox.Show("Hãy nhập hết các trường dữ liệu !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // if the email is not valid, show the message box
            string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(guna2TextBox2.Text, emailRegex))
            {
                MessageBox.Show("Sai định dạng Email !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // if the password is less than 8 characters, show the message box
            if (guna2TextBox3.Text.Length < 8)
            {
                MessageBox.Show("Mật khẩu có độ dài ít nhất 8 ký tự", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // if password and confirm password do not match, show the message box
            if (guna2TextBox3.Text != guna2TextBox4.Text)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            if (iconPictureBox3.IconChar.ToString() == "Circle")
            {
                MessageBox.Show("Please accept the terms and conditions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // if user doesn't accept the terms and conditions, show the message box
            if ((int)iconPictureBox1.IconChar == (int)IconChar.Circle)
            {
                MessageBox.Show("Please accept the terms and conditions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // let the user know that the registration is successful
            MessageBox.Show("Đăng ký thành công !", "Đăng ký tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void ShowLoginForm(object sender, EventArgs e)
        {
            LoginForm loginView = new LoginForm();
            loginView.Show();
            this.Dispose();
        }

        private void AcceptTerm(object sender, EventArgs e)
        {
            if (iconPictureBox3.IconChar.ToString() == "Circle")
            {
                iconPictureBox3.IconChar =IconChar.CircleCheck;
            }
            else
            {
                iconPictureBox3.IconChar = IconChar.Circle;
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
