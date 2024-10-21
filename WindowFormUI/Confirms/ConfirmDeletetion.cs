using System;
using System.Windows.Forms;

namespace WindowFormUI
{
    public partial class ConfirmDeletetion : Form
    {
        private int schoolId;
        private int classId;
        private QLDIEMDANHDataSetTableAdapters.SchoolTableAdapter schoolTableAdapter;
        private QLDIEMDANHDataSetTableAdapters.ClassTableAdapter classTableAdapter;

        public ConfirmDeletetion()
        {
            InitializeComponent();
            schoolTableAdapter = new QLDIEMDANHDataSetTableAdapters.SchoolTableAdapter();
            classTableAdapter = new QLDIEMDANHDataSetTableAdapters.ClassTableAdapter();
            this.schoolId = 0;
            this.classId = 0;
        }

        public int SchoolId
        {
            get => schoolId;
            set => schoolId = value;
        }

        public int ClassId
        {
            get => classId;
            set => classId = value;
        }

        private void Delete(object sender, EventArgs e)
        {
            if (!(schoolId == 0))
            {
                // Delete school
                try
                {
                    schoolTableAdapter.DeleteSchoolById(schoolId);
                    MessageBox.Show("School deleted successfully");

                } catch (Exception ex)
                {
                    MessageBox.Show(@"Hãy chắc chắn rằng bạn đã xoá hết lớp học !");
                }
                Home home = new Home();

                home.Show();
                this.Dispose();
            }
            else if (classId != 0)
            {
                // Delete class
                classTableAdapter.DeleteClassById(classId);
                MessageBox.Show("Class deleted successfully");

                Home home = new Home();

                home.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void Back(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
