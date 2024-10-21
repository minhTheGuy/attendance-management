using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI.Forms
{
    public partial class EditSchoolForm : Form
    {
        private readonly SchoolTableAdapter schoolTableAdapter;
        private int schoolId;
        public EditSchoolForm()
        {
            InitializeComponent();
            schoolTableAdapter = new SchoolTableAdapter();
            this.schoolId = 0;
        }

        public int SchoolId
        {
            get => schoolId;
            set => schoolId = value;
        }

        private void Back(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Dispose();
        }

        private void EditSchool(object sender, EventArgs e)
        {
            bool result = ValidateInput();
            if (result)
            {
                schoolTableAdapter.UpdateSchoolById(guna2TextBox1.Text, guna2TextBox4.Text, guna2TextBox6.Text, guna2TextBox8.Text, Home.UserId);
                MessageBox.Show("School updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox6.Text) || string.IsNullOrEmpty(guna2TextBox8.Text))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void EditSchoolForm_Load(object sender, EventArgs e)
        {
            QLDIEMDANHDataSet.SchoolDataTable schoolDataTable = schoolTableAdapter.GetSChoolById(schoolId);
            guna2TextBox1.Text = schoolDataTable[0].Ten_truong;
            guna2TextBox4.Text = schoolDataTable[0].Ten_co_so;
            guna2TextBox6.Text = schoolDataTable[0].Dia_chi;
            guna2TextBox8.Text = schoolDataTable[0].Thong_tin_them;

            schoolTableAdapter.Fill(schoolDataTable);
        }
    }
}
