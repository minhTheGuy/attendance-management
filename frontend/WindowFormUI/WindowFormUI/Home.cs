using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, EventArgs e)
        {

        }
        private void guna2Panel1_MouseHover(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;
        }

        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel1.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClassDashboard cd = new ClassDashboard();
            cd.ShowDialog();
            this.Close();
        }

        private void guna2Panel2_MouseHover(object sender, EventArgs e)
        {
            guna2Panel2.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;
        }

        private void guna2Panel2_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel2.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
        }

        private void guna2Panel3_MouseHover(object sender, EventArgs e)
        {
            guna2Panel3.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;
        }

        private void guna2Panel3_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel3.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
        }

        private void guna2Panel4_MouseHover(object sender, EventArgs e)
        {
            guna2Panel4.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;
        }

        private void guna2Panel4_MouseLeave(object sender, EventArgs e)
        {
            guna2Panel4.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
        }
    }
}
