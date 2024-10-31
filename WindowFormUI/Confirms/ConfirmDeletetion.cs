using System;
using System.Windows.Forms;

namespace WindowFormUI
{
    public partial class ConfirmDeletetion : Form
    {
        private int schoolId;
        private int classId;
        private readonly QLDIEMDANHDataSetTableAdapters.SchoolTableAdapter schoolTableAdapter;
        private readonly QLDIEMDANHDataSetTableAdapters.ClassTableAdapter classTableAdapter;

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
            Home home = new Home();

            if (!(schoolId == 0))
            {
                // Delete school
                try
                {
                    schoolTableAdapter.DeleteSchoolById(schoolId);

                    MessageBox.Show("Trường học đã được xoá thành công!", "Xoá trường học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Hãy chắc chắn rằng bạn đã xoá hết lớp học !");
                }

                home.Show();
                this.Dispose();
            }
            else if (classId != 0)
            {
                // Delete class
                classTableAdapter.DeleteClassById(classId);

                MessageBox.Show("Lớp học đã được xoá thành công", "Xoá lớp học", MessageBoxButtons.OK, MessageBoxIcon.Information);

                home.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Something went wrong");

                home.Show();
                this.Dispose();
            }
        }

        private void Back(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();

            this.Dispose();
        }

        private void ConfirmDeletetion_Load(object sender, EventArgs e)
        {
            // Set title for form
            if (schoolId != 0)
            {
                label1.Text = "Xác nhận xoá trường học";
            }
            else if (classId != 0)
            {
                label1.Text = "Xác nhận xoá lớp học";
            }

            // Set message for form
            if (schoolId != 0)
            {
                guna2HtmlLabel2.Text = "Bạn có chắc chắn muốn xoá trường học này?";
            }
            else if (classId != 0)
            {
                guna2HtmlLabel2.Text = "Bạn có chắc chắn muốn xoá lớp học này?";
            }
        }

    }
}
