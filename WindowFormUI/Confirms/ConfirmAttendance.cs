using System;
using System.Windows.Forms;

namespace WindowFormUI
{
    public partial class ConfirmAttendance : Form
    {
        private int schoolId;
        private string schoolName;
        private int classId;
        private string className;
        public ConfirmAttendance()
        {
            InitializeComponent();
            this.schoolId = 0;
            this.schoolName = "";
            this.classId = 0;
            this.className = "";
        }
        public int ClassId
        {
            get { return classId; }
            set { classId = value; }
        }

        public string ClassName
        { get { return className; } set { className = value; } }

        public int SchoolId { get { return schoolId; } set { schoolId = value; } }

        public string SchoolName { get { return schoolName; } set { schoolName = value; } }


        private void back(object sender, EventArgs e)
        {
            ClassView classView = new ClassView
            {
                ClassId = this.ClassId,
                ClassName = this.ClassName,
                SchoolId = this.SchoolId,
                SchoolName = this.SchoolName,
            };
            classView.Show();
            this.Dispose();
        }

        private void Perform(object sender, EventArgs e)
        {
            // run MultiFaceRec to confirm attendance
            FrmPrincipal frmPrincipal = new FrmPrincipal
            {
                ClassId = this.classId,
                ClassName = this.className,
                SchoolId = this.schoolId,
                SchoolName = this.schoolName,
                AttendanceDate = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd")
            };
            frmPrincipal.Show();
            this.Dispose();
        }
    }
}
