using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowFormUI
{
    public partial class Form1 : Form
    {
        private readonly FaceRec faceRec = new FaceRec();
        private int schoolId;
        private int classId;
        private string schoolName;
        private string className;
        private string attendanceDate;
        private HashSet<string> studentNames;
        private readonly ClassTableAdapter classTableAdapter = new ClassTableAdapter();
        public Form1()
        {
            InitializeComponent();
            this.schoolId = 0;
            this.classId = 0;
            this.schoolName = "";
            this.className = "";
            this.attendanceDate = DateTime.Now.ToString("yyyy-MM-dd");
            this.classTableAdapter = new ClassTableAdapter();
            this.studentNames = new HashSet<string>();
        }
        public int ClassId
        {
            get => classId;
            set => classId = value;
        }

        public string AttendanceDate
        {
            get => attendanceDate;
            set => attendanceDate = value;
        }

        public int SchoolId { get => schoolId; set => schoolId = value; }

        public string SchoolName { get => schoolName; set => schoolName = value; }

        public string ClassName { get => className; set => className = value; }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(txtName.Text.ToUpper());
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Saved";
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBoxCamara, pictureBoxCaptured);
            faceRec.isTrained = true;
            faceRec.getPersonName(lblName);
        }

        private void Stop(object sender, EventArgs e)
        {

            var classRow = classTableAdapter.GetClassById(this.classId).ToList()[0];
            studentNames = faceRec.getStudentNames();
            string path = classRow.excel_path;
            if (path != null)
            {
                // create sheet to dest excel file
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(path);
                Excel.Worksheet worksheet = workbook.Worksheets[1];
                Excel.Range usedRange = worksheet.UsedRange;
                // add new sheet the latest
                Excel.Worksheet newSheet = workbook.Worksheets.Add(After: worksheet);

                try
                {
                    newSheet.Name = attendanceDate;
                    newSheet.Cells[1, 1] = "MSSV";
                    newSheet.Cells[1, 2].EntireColumn.ColumnWidth = "20";
                    newSheet.Cells[1, 2] = "Time";

                    int rowCount = worksheet.UsedRange.Rows.Count;
                    int columnCount = worksheet.UsedRange.Columns.Count;

                    // get the range of the data
                    Excel.Range range = worksheet.Range["A1", worksheet.Cells[rowCount, columnCount]];

                    // get values
                    object[,] values = (object[,])range.Value;

                    // check if student is in the class
                    int idx = 2;
                    for (int i = 2; i <= rowCount; i++)
                    {
                        foreach (string studentName in studentNames)
                        {
                            if (studentName == values[i, 1].ToString())
                            {
                                newSheet.Cells[idx, 1] = values[i, 1];
                                newSheet.Cells[idx, 2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                idx++;
                            }
                        }
                    }

                    worksheet.Range["A1", "R100"].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Cells[1, columnCount + 1].EntireColumn.ColumnWidth = "12";
                    worksheet.Cells[1, columnCount + 1] = attendanceDate;

                    for (int i = 2; i <= rowCount; i++)
                    {
                        worksheet.Cells[i, worksheet.UsedRange.Columns.Count] = "X";
                        for (int j = 2; j <= newSheet.UsedRange.Rows.Count; j++)
                        {
                            if (double.Parse(values[i, 1].ToString()) == newSheet.Cells[j, 1].Value)
                            {
                                worksheet.Cells[i, worksheet.UsedRange.Columns.Count] = " ";
                                break;
                            }
                        }
                    }
                    workbook.Save();

                    // Realse memory of excel
                    workbook.Close(0);
                    application.Quit();

                    faceRec.stopCamera();
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("That name is already taken"))
                    {
                        MessageBox.Show("Ngày này đã được điểm danh, vui lòng xoá sheet điểm danh này để điểm danh lại!");
                    }
                    workbook.Close(0);
                    application.Quit();
                    faceRec.stopCamera();
                }
            }
            else
            {
                MessageBox.Show("Không tìm được tệp của lớp");
            }

            ClassView classView = new ClassView();
            classView.Show();
            this.Dispose();
        }
    }
}
