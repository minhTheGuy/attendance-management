using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowFormUI.Forms;

namespace WindowFormUI
{
    public partial class ClassView : Form
    {
        public ClassView()
        {
            InitializeComponent();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GoHomepage(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ShowCreateSchoolForm(object sender, EventArgs e)
        {
            EditSchoolForm editSchoolForm = new EditSchoolForm();
            editSchoolForm.Show();
        }
    }
}
