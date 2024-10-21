using System;
using System.ComponentModel;
using System.Windows.Forms;
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

        private void Register(object sender, EventArgs e)
        {
            // validate the username and password
            bool validationResult = ValidateRegister(sender, new CancelEventArgs());

            if (validationResult)
            {
                // if the registration is successful
                // show the login form
                usersTableAdapter.Insert(guna2TextBox1.Text, guna2TextBox3.Text, guna2TextBox2.Text);

                LoginForm loginView = new LoginForm();
                loginView.Show();
                this.Hide();
            }
        }

        private bool ValidateRegister(object sender, CancelEventArgs e)
        {
            // if there's no input in the username or email or password, show the message box
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "")
            {
                MessageBox.Show("Please fill in the required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // if the email is not valid, show the message box
            string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(guna2TextBox2.Text, emailRegex))
            {
                MessageBox.Show("Invalid email format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // if the password is less than 8 characters, show the message box
            if (guna2TextBox3.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // if password and confirm password do not match, show the message box
            if (guna2TextBox3.Text != guna2TextBox4.Text)
            {
                MessageBox.Show("Password and confirm password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            if (iconPictureBox3.IconChar.ToString() == "Circle")
            {
                MessageBox.Show("Please accept the terms and conditions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return false;
            }

            // let the user know that the registration is successful
            MessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void ShowLoginForm(object sender, EventArgs e)
        {
            LoginForm loginView = new LoginForm();
            loginView.Show();
            this.Hide();
        }

        private void AcceptTerm(object sender, EventArgs e)
        {
            if (iconPictureBox3.IconChar.ToString() == "Circle")
            {
                iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            }
            else
            {
                iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Circle;
            }
        }
    }
}
