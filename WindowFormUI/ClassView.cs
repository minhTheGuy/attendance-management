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
        private readonly ClassTableAdapter classTableAdapter;
        public static int classId = 0;
        public static string className = "";

        public ClassView()
        {
            InitializeComponent();
            this.classTableAdapter = new ClassTableAdapter();
            className = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0].ten_mon_hoc;
        }

        private void GoHomepage(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();

            this.Dispose();
        }
        private void ConfirmAttendance(object sender, EventArgs e)
        {
            ConfirmAttendance modal = new ConfirmAttendance();
            modal.Show();

            this.Dispose();
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            classNameLabel.Text = className;
            label29.Text = $"{className}";

            var ClassRow = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0];

            maMonLabel.Text = $"Mã môn: {ClassRow.ma_mon}";
            nhomLabel.Text = $"Nhóm: {ClassRow.nhom}";
            toLabel.Text = $"Tổ: {ClassRow.to}";
            caHocLabel.Text = $"Ca: {ClassRow.ca_hoc}";
            hocKiLabel.Text = $"Học kì: {ClassRow.startDate.Year}-{ClassRow.endDate.Year}";

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
                    if ((int)worksheet.Rows[i].Interior.Color == (int)Excel.XlRgbColor.rgbYellow)
                    {
                        dataGridView1.Rows[i - 2].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if
                     ((int)worksheet.Rows[i].Interior.Color == (int)Excel.XlRgbColor.rgbRed)
                    {
                        dataGridView1.Rows[i - 2].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    }
                    else if ((int)worksheet.Rows[i].Interior.Color == (int)Excel.XlRgbColor.rgbWhite)
                    {
                        dataGridView1.Rows[i - 2].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }

                int days = workbook.Worksheets.Count;
                soBuoiDiemDanhLabel.Text = $"Số buổi đã điểm danh: {days - 1} buổi";

                workbook.Close(0);
                application.Quit();
            }
        }
        private void Back(object sender, EventArgs e)
        {
            ClassDashboard classDashboard = new ClassDashboard();
            classDashboard.Show();
            this.Dispose();
        }

        private void ShowCreateClassForm(object sender, EventArgs e)
        {
            CreateClassForm classForm = new CreateClassForm();
            classForm.Show();

            this.Dispose();
        }

        private void CheckAbsent(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập số buổi vắng tối đa", "Nhập số buổi vắng tối đa", "0");

            if (input == "")
            {
                return;
            }

            int absentLimit;
            try { absentLimit = int.Parse(input); }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập số nguyên", "Lỗi Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            label3.Text = absentLimit.ToString();

            var ClassRow = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0];
            string path = ClassRow.excel_path;

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

            for (int i = 2; i <= rowCount; i++)
            {
                int count = 0;

                for (int j = 3; j <= columnCount; j++)
                {
                    if (values[i, j].ToString() == "X")
                    {
                        count++;
                    }
                }

                if (count == absentLimit)
                {
                    worksheet.Rows[i].Interior.Color = Excel.XlRgbColor.rgbYellow;
                }
                else if (count > absentLimit)
                {
                    worksheet.Rows[i].Interior.Color = Excel.XlRgbColor.rgbRed;
                }
                else
                {
                    worksheet.Rows[i].Interior.Color = Excel.XlRgbColor.rgbWhite;
                }
            }

            // release the memory
            System.Runtime.InteropServices.Marshal.ReleaseComObject(usedRange);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            workbook.Save();
            workbook.Close(0);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            application.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(application);

            MessageBox.Show("Đã kiểm tra xong", "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClassView_Load(sender, e);
        }

        private void ExportExcelFile(object sender, EventArgs e)
        {
            // ask user to save the new excel file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName == "")
            {
                MessageBox.Show("Vui lòng chọn nơi lưu file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get excel from path
            var ClassRow = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0];
            string path = ClassRow.excel_path;

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

            // create a new excel file
            Excel.Application newApplication = new Excel.Application();
            Excel.Workbook newWorkbook = newApplication.Workbooks.Add();
            Excel.Worksheet newWorksheet = newWorkbook.Worksheets[1];

            newWorksheet.Range["A1:R100"].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // write values to the new excel file
            for (int i = 1; i <= rowCount; i++)
            {
                newWorksheet.Columns[i].ColumnWidth = worksheet.Columns[i].ColumnWidth;
                for (int j = 1; j <= columnCount; j++)
                {
                    newWorksheet.Cells[i, j] = values[i, j];
                }
            }

            // add the last column to the new excel file or the status of the student
            newWorksheet.Cells[1, columnCount + 1] = "Trạng thái";
            for (int i = 2; i <= rowCount; i++)
            {
                int count = 0;
                for (int j = 3; j <= columnCount; j++)
                {
                    if (values[i, j].ToString() == "X")
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    newWorksheet.Cells[i, columnCount + 1] = "Đầy đủ";
                }
                else
                {
                    newWorksheet.Cells[i, columnCount + 1] = "Vắng " + count + " buổi";
                }
            }

            newWorksheet.Rows[rowCount + 1].RowHeight = 45;
            newWorksheet.Rows[rowCount + 1].WrapText = true;

            // add the last row to the new excel file or the total students that reached the absent limit
            newWorksheet.Cells[rowCount + 1, 1] = "Tổng số học sinh vượt quá số buổi quy định";
            newWorksheet.Cells[rowCount + 1, 2] = label3.Text.Equals("null") ? "0" : label3.Text;

            // save the new excel filew
            newWorkbook.SaveAs(saveFileDialog.FileName);
            newWorkbook.Close(0);
            newApplication.Quit();

            MessageBox.Show("Đã xuất file thành công", "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            workbook.Close(0);
            application.Quit();

            // release the memory
            System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(usedRange);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(newApplication);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(newWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(newWorksheet);


            System.Diagnostics.Process.Start("explorer.exe", saveFileDialog.FileName);
        }
    }
}
