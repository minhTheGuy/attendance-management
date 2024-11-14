using System;
using System.IO;
using System.Windows.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI
{
    public partial class CreateClassForm : Form
    {
        private readonly ClassTableAdapter classTableAdapter = new ClassTableAdapter();

        public CreateClassForm()
        {
            InitializeComponent();
            classTableAdapter = new ClassTableAdapter();
        }

        private void BrowseFile(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
            openFileDialog1.Title = "Chọn file Excel";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox8.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Hãy chọn file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateClass(object sender, EventArgs e)
        {
            bool result = ValidateInput();
            if (result)
            {
                try
                {
                    if (!Directory.Exists(@"C:\Uploads"))
                    {
                        Directory.CreateDirectory(@"C:\Uploads");
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv",
                        FileName = Path.GetFileName(guna2TextBox8.Text),
                        InitialDirectory = @"C:\Uploads",
                        RestoreDirectory = true,
                        Title = "Lưu file Excel"
                    };

                    saveFileDialog.ShowDialog();

                    if (saveFileDialog.FileName == "")
                    {
                        MessageBox.Show("Hãy chọn file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string fileName = guna2TextBox8.Text;
                    string destName = saveFileDialog.FileName;
                    File.Copy(fileName, destName, true);
                    classTableAdapter.Insert(ClassDashboard.schoolId, guna2TextBox4.Text, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox6.Text, DateTime.Now, DateTime.Now, guna2ComboBox1.Text, guna2TextBox3.Text, guna2TextBox5.Text, destName);

<<<<<<< HEAD
                    classTableAdapter.Insert(ClassDashboard.schoolId, guna2TextBox4.Text, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox6.Text, DateTime.Now, DateTime.Now, guna2ComboBox1.Text.Replace("Thứ", ""), guna2TextBox3.Text, guna2TextBox5.Text, destName);
=======
>>>>>>> 0bf7baf976964b5f772a79563617628aea07f0d6
                    MessageBox.Show("Lớp học được tạo thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClassDashboard classDashboard = new ClassDashboard();
                    classDashboard.Show();
                    
                    this.Dispose();
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
                MessageBox.Show("Xin hãy điền hết các ô dữ liệu", "Fields Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Back(object sender, EventArgs e)
        {
            ClassDashboard classDashboard = new ClassDashboard();
            classDashboard.Show();

            this.Dispose();
        }
    }
}
