using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI
{
    public partial class EditClassForm : Form
    {
        private readonly ClassTableAdapter classTableAdapter = new ClassTableAdapter();
        private int classId;
        private int schoolId;

        public EditClassForm()
        {
            InitializeComponent();
            classTableAdapter = new ClassTableAdapter();
            this.schoolId = 0;
            this.classId = 0;
        }
        public int SchoolId
        {
            get { return schoolId; }
            set { schoolId = value; }
        }
        
        public int ClassId
        {
            get { return classId; }
            set { classId = value; }
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

        private void EditClass(object sender, EventArgs e)
        {
            bool result = ValidateInput();
            if (result)
            {
                try
                {
                    // copy file to ExcelFiles folder
                    string fileName = guna2TextBox8.Text;
                    string destName = Path.Combine(@"C:\Uploads", Path.GetFileName(fileName));
                    // if C:\Uploads folder does not exist, create it
                    if (!Directory.Exists(@"C:\Uploads"))
                    {
                        Directory.CreateDirectory(@"C:\Uploads");
                    }
                    File.Copy(fileName, destName, true);

                    classTableAdapter.UpdateClassById(guna2TextBox4.Text, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox6.Text, DateTime.Now, DateTime.Now, "Monday", "1", "B205", guna2TextBox8.Text, classId);
                    MessageBox.Show("Class updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void EditClassForm_Load(object sender, EventArgs e)
        {
            var editClass = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0];

            guna2TextBox1.Text = editClass.ten_mon_hoc;
            guna2TextBox4.Text = editClass.ma_mon;
            guna2TextBox2.Text = editClass.nhom;
            guna2TextBox6.Text = editClass.to;
            guna2TextBox8.Text = editClass.excel_path;

        }
    }
}
