using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowFormUI.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

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
            ConfirmAttendance modal = new ConfirmAttendance();
            modal.Show();
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

            // load .csv file
            string path = ClassRow.excel_path;
            if (path != null)
            {
                string[] lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] items = line.Split(',');
                    guna2DataGridView1.Rows.Add(items);
                }
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
