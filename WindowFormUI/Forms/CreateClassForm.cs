using System;
using System.IO;
using System.Windows.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI
{
    public partial class CreateClassForm : Form
    {
        private readonly ClassTableAdapter classTableAdapter = new ClassTableAdapter();
        private int schoolId;

        public CreateClassForm()
        {
            InitializeComponent();
            classTableAdapter = new ClassTableAdapter();
            this.schoolId = 0;
        }
        public int SchoolId
        {
            get { return schoolId; }
            set { schoolId = value; }
        }
        private void BrowseFile(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox8.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Please select a file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateClass(object sender, EventArgs e)
        {
            bool result = ValidateInput();
            if (result)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
                    saveFileDialog.FileName = guna2TextBox8.Text;
                    saveFileDialog.InitialDirectory = @"C:\Uploads";
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.ShowDialog();

                    if (saveFileDialog.FileName == "")
                    {
                        MessageBox.Show("Please select a file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // copy file to ExcelFiles folder
                    string fileName = guna2TextBox8.Text;
                    string destName = saveFileDialog.FileName;
                    File.Copy(fileName, destName, true);

                    classTableAdapter.Insert(schoolId, guna2TextBox4.Text, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox6.Text, DateTime.Now, DateTime.Now, "Monday", "1", "B205", guna2TextBox8.Text);
                    MessageBox.Show("Class created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClassDashboard classDashboard = new ClassDashboard
                    {
                        SchoolId = schoolId
                    };
                    classDashboard.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox6.Text) || string.IsNullOrEmpty(guna2TextBox8.Text))
            {
                MessageBox.Show("Please fill all the fields", "Fields Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Back(object sender, EventArgs e)
        {
            ClassDashboard classDashboard = new ClassDashboard
            {
                SchoolId = schoolId
            };

            classDashboard.Show();
            this.Close();
        }
    }
}
