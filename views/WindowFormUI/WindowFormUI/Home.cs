using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowFormUI.Forms;

namespace WindowFormUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            // Duplicate guna2panel1 to 4 of the same size and add them to the flowlayoutpanel
            for (int i = 0; i < 10; i++)
            {
                // clone the panel
                Guna.UI2.WinForms.Guna2Panel panel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = guna2Panel1.Size,
                    BackColor = guna2Panel1.BackColor
                };

                // Clone labels and buttons
                Label label = CloneLabel(label4);
                panel.Controls.Add(label);

                label = CloneLabel(label2);
                panel.Controls.Add(label);

                label = CloneLabel(label5);
                panel.Controls.Add(label);

                label = CloneLabel(label3);
                panel.Controls.Add(label);

                Guna2Button button = CloneButton(guna2Button1);
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
            Guna2Panel panel = (Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;
        }

        private void Leave(object sender, EventArgs e)
        {
            Guna2Panel panel = (Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
        }

        private void ShowClassDashboardView(object sender, EventArgs e)
        {
            ClassDashboard classDashboard = new ClassDashboard();
            classDashboard.Show();
            this.Hide();
        }


        private Label CloneLabel(Label label)
        {
            Label newLabel = new Label
            {
                Text = label.Text + RandomNumberGenerator.Create(),
                Font = label.Font,
                ForeColor = label.ForeColor,
                Location = label.Location,
                Size = label.Size
            };
            return newLabel;
        }

        private Guna2Button CloneButton(Guna2Button button)
        {
            Guna2Button newButton = new Guna2Button
            {
                Text = button.Text,
                Font = button.Font,
                ForeColor = button.ForeColor,
                Location = button.Location,
                Size = button.Size,
                FillColor = button.FillColor,
                HoverState = { FillColor = button.HoverState.FillColor, ForeColor = button.HoverState.ForeColor },
                BorderRadius = button.BorderRadius,
                BorderThickness = button.BorderThickness
            };
            
            return newButton;
        }

        private void ViewSchoolDetails(object sender, EventArgs e)
        {
            ClassDashboard classDashboard = new ClassDashboard();
            classDashboard.Show();
            this.Hide();
        }

        private void ConfirmDelete(object sender, EventArgs e)
        {
            ConfirmDeletetion confirmDeletetion = new ConfirmDeletetion();
            confirmDeletetion.Show();
        }

        private void ShowUpdateSchoolForm(object sender, EventArgs e)
        {
            EditSchoolForm editSchoolForm = new EditSchoolForm();
            editSchoolForm.Show();
        }
    }
}
