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
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
                    saveFileDialog.FileName = Path.GetFileName(guna2TextBox8.Text);
                    saveFileDialog.InitialDirectory = @"C:\Uploads";
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.ShowDialog();

                    if (saveFileDialog.FileName == "")
                    {
                        MessageBox.Show("Hãy chọn file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // copy file to ExcelFiles folder
                    string fileName = guna2TextBox8.Text;
                    string destName = saveFileDialog.FileName;
                    File.Copy(fileName, destName, true);

                    classTableAdapter.UpdateClassById(guna2TextBox4.Text, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox6.Text, DateTime.Now, DateTime.Now, guna2ComboBox1.Text, guna2TextBox3.Text, guna2TextBox5.Text, destName, classId);

                    MessageBox.Show("Cập nhật lớp thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClassDashboard classDashboard = new ClassDashboard();
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
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox6.Text) || string.IsNullOrEmpty(guna2TextBox8.Text) || string.IsNullOrEmpty(guna2ComboBox1.Text) || string.IsNullOrEmpty(guna2TextBox5.Text) || string.IsNullOrEmpty(guna2TextBox3.Text))
            {
                MessageBox.Show("Hãy điền hết các trường dữ liệu", "Fields Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Back(object sender, EventArgs e)
        {
            string schoolName = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0].ten_mon_hoc;

            ClassDashboard classDashboard = new ClassDashboard();

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
