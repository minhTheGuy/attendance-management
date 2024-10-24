using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowFormUI
{
    public partial class ClassView : Form
    {
        private ClassTableAdapter classTableAdapter;
        private int schoolId;
        private string schoolName;
        private int classId;
        private string className;

        public ClassView()
        {
            InitializeComponent();
            this.classTableAdapter = new ClassTableAdapter();
            this.schoolId = 0;
            this.schoolName = "";
            this.classId = 0;
            this.className = "";
        }
        public int SchoolId
        {
            get { return schoolId; }
            set { schoolId = value; }
        }
        public string SchoolName
        {
            get { return schoolName; }
            set { schoolName = value; }
        }
        public int ClassId
        {
            get { return classId; }
            set { classId = value; }
        }
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private void GoHomepage(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void ConfirmAttendance(object sender, EventArgs e)
        {
            ConfirmAttendance modal = new ConfirmAttendance
            {
                SchoolId = this.SchoolId,
                ClassId = this.classId,
                SchoolName = this.schoolName,
                ClassName = this.ClassName,
            };
            modal.Show();
            this.Dispose();
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            classNameLabel.Text = className;

            var ClassRow = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0];

            maMonLabel.Text += $"{ClassRow.ma_mon}";
            nhomLabel.Text += $"{ClassRow.nhom}";
            toLabel.Text += $"{ClassRow.to}";
            caHocLabel.Text += $"{ClassRow.ca_hoc}";
            hocKiLabel.Text += $"{ClassRow.startDate}-{ClassRow.endDate}";
            soBuoiDiemDanhLabel.Text += "0/0";
            soHocSinhVangLabel.Text += "0";

            //string path = ClassRow.excel_path;
            //if (path != null)
            //{
            //    string[] lines = new string[] { };
            //    try { lines = System.IO.File.ReadAllLines(path); }
            //    catch (Exception err)
            //    {
            //        MessageBox.Show(Text = err.ToString());
            //        ClassDashboard classDashboard = new ClassDashboard
            //        {
            //            SchoolId = schoolId,
            //            SchoolName = schoolName
            //        };

            //        classDashboard.Show();
            //        this.Dispose();
            //        return;
            //    }
            //    // Create columns
            //    string[] headers = lines[0].Split(',');
            //    foreach (string header in headers)
            //    {
            //        guna2DataGridView1.Columns.Add(header, header);
            //    }

            //    foreach (string line in lines)
            //    {
            //        string[] items = line.Split(',');
            //        guna2DataGridView1.Rows.Add(items);
            //    }
            //}

            // load excel file
            string path = ClassRow.excel_path;
            if (path != null)
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(path);
                Excel.Worksheet worksheet = workbook.Worksheets[1];

                // get the used range
                Excel.Range usedRange = worksheet.UsedRange;

                // get the row count
                int rowCount = usedRange.Rows.Count;

                // get the column count
                int columnCount = usedRange.Columns.Count;

                // get the range of the data
                Excel.Range range = worksheet.Range["A1", worksheet.Cells[rowCount, columnCount]];

                // get values
                object[,] values = (object[,])range.Value;

                // create columns
                for (int i = 1; i <= columnCount; i++)
                {
                    dataGridView1.Columns.Add(values[1, i].ToString(), values[1, i].ToString());
                }

                // create rows
                for (int i = 2; i <= rowCount; i++)
                {
                    string[] row = new string[columnCount];
                    for (int j = 1; j <= columnCount; j++)
                    {
                        row[j - 1] = values[i, j].ToString();
                    }
                    dataGridView1.Rows.Add(row);
                }

                workbook.Close(false);
                application.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
            }
        }
        private void Back(object sender, EventArgs e)
        {
            ClassDashboard classDashboard = new ClassDashboard
            {
                SchoolId = schoolId,
                SchoolName = schoolName
            };
            classDashboard.Show();
            this.Dispose();
        }

        private void ShowCreateClassForm(object sender, EventArgs e)
        {
            CreateClassForm classForm = new CreateClassForm
            {
                SchoolId = schoolId
            };

            classForm.Show();
            this.Dispose();
        }
    }
}
