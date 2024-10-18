using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormUI
{
    public partial class ClassDashboard : Form
    {
        public ClassDashboard()
        {
            InitializeComponent();

            // Duplicate guna2panel1 to 4 of the same size and add them to the flowlayoutpanel

            for (int i = 0; i < 10; i++)
            {
                // clone the panel
                Guna.UI2.WinForms.Guna2Panel panel = new Guna.UI2.WinForms.Guna2Panel();
                panel.Size = guna2Panel1.Size;
                panel.BackColor = guna2Panel1.BackColor;

                // Clone labels and buttons
                Label label = CloneLabel(label4);
                panel.Controls.Add(label);

                label = CloneLabel(label2);
                panel.Controls.Add(label);

                label = CloneLabel(label5);
                panel.Controls.Add(label);

                label = CloneLabel(label3);
                panel.Controls.Add(label);

                Guna.UI2.WinForms.Guna2Button button = CloneButton(guna2Button1);
                button.Click += new EventHandler(ShowClassView);
                panel.Controls.Add(button);

                button = CloneButton(guna2Button2);
                panel.Controls.Add(button);

                button = CloneButton(guna2Button3);
                panel.Controls.Add(button);

                // add container event handler
                panel.MouseHover += new EventHandler(Hover);
                panel.MouseLeave += new EventHandler(Leave);

                container.Controls.Add(panel);
            }
        }

        private void Hover(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel panel = (Guna.UI2.WinForms.Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;
        }

        private void Leave(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel panel = (Guna.UI2.WinForms.Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
        }

        private Label CloneLabel(Label label)
        {
            Label newLabel = new Label();
            newLabel.Text = label.Text;
            newLabel.Font = label.Font;
            newLabel.ForeColor = label.ForeColor;
            newLabel.Location = label.Location;
            newLabel.Size = label.Size;
            newLabel.TextAlign = label.TextAlign;
            return newLabel;
        }

        private Guna.UI2.WinForms.Guna2Button CloneButton(Guna.UI2.WinForms.Guna2Button button)
        {
            Guna.UI2.WinForms.Guna2Button newButton = new Guna.UI2.WinForms.Guna2Button();
            newButton.Text = button.Text;
            newButton.Font = button.Font;
            newButton.ForeColor = button.ForeColor;
            newButton.Location = button.Location;
            newButton.Size = button.Size;
            newButton.TextAlign = button.TextAlign;
            newButton.FillColor = button.FillColor;
            newButton.HoverState.FillColor = button.HoverState.FillColor;
            newButton.HoverState.ForeColor = button.HoverState.ForeColor;
            newButton.BorderRadius = button.BorderRadius;
            newButton.BorderThickness = button.BorderThickness;
            newButton.BorderColor = button.BorderColor;
            return newButton;
        }

        private void ShowClassView(object sender, EventArgs e)
        {
            ClassView classView = new ClassView();
            classView.Show();
            this.Hide();
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
     
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click_1(object sender, EventArgs e)
        {

        }

        private void GoHomepage(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
