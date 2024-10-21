using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormUI.Forms
{
    public partial class CreateSchoolForm : Form
    {
        private QLDIEMDANHDataSetTableAdapters.SchoolTableAdapter schoolTableAdapter;
        public CreateSchoolForm()
        {
            InitializeComponent();
            schoolTableAdapter = new QLDIEMDANHDataSetTableAdapters.SchoolTableAdapter();
        }

        private void CreateSchool(object sender, EventArgs e)
        {
            // validate input
            if (!ValidateInput())
            {
                return;
            }

            // create new school
            schoolTableAdapter.Insert($"{ guna2TextBox1.Text}", Home.UserId, $"{guna2TextBox6.Text}", $"{guna2TextBox8.Text}", $"{guna2TextBox4.Text}");
            MessageBox.Show("School created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private bool ValidateInput()
        {
            // if input is empty, return false
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox6.Text) || string.IsNullOrEmpty(guna2TextBox8.Text))
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Back(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
