using System;
using System.Windows.Forms;

namespace WindowFormUI
{
    public partial class ConfirmAttendance : Form
    {
        public ConfirmAttendance()
        {
            InitializeComponent();
        }

        private void back(object sender, EventArgs e)
        {
            ClassView classView = new ClassView();
            classView.Show();

            this.Dispose();
        }

        private void Perform(object sender, EventArgs e)
        {
            Form1 form = new Form1
            {
                ClassId = ClassView.classId,
                AttendanceDate = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd"),
            };

            form.Show();
            this.Dispose();
        }

        private void ConfirmAttendance_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value = DateTime.Now;
        }
    }
}
