using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI
{
    public partial class ClassDashboard : Form
    {
        private ClassTableAdapter classTableAdapter;
        private int schoolId;
        private string schoolName;

        public ClassDashboard()
        {
            InitializeComponent();
            this.classTableAdapter = new QLDIEMDANHDataSetTableAdapters.ClassTableAdapter();
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

        private void Mouse_Hover(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel panel = (Guna.UI2.WinForms.Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;

            // get class from panel
            int classId = int.Parse(panel.Controls[8].Text);
            QLDIEMDANHDataSet.ClassRow classRow = classTableAdapter.GetData().Where(classItem => classItem.id == classId).ToList()[0];

            label21.Text = classRow.ten_mon_hoc;
            label25.Text = classRow.ma_mon;
            label26.Text = $"{classRow.startDate} - {classRow.endDate}";
            label47.Text = classRow.nhom;
            label49.Text = classRow.to;
            label51.Text = classRow.ca_hoc;
            label53.Text = classRow.phong_hoc;


        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Panel panel = (Guna.UI2.WinForms.Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
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
                BorderColor = button.BorderColor,
                BorderRadius = button.BorderRadius,
                BorderThickness = button.BorderThickness
            };

            return newButton;
        }

        private void ShowClassViewFromButton(object sender, EventArgs e)
        {
            // Get Class Id from panel
            Guna2Panel panel = (Guna2Panel)((Guna2Button)sender).Parent;
            int classId = int.Parse(panel.Controls[8].Text);

            ClassView classView = new ClassView
            {
                SchoolId = schoolId,
                SchoolName = schoolName,
                ClassId = classId,
                ClassName = panel.Controls[0].Text
            };

            classView.Show();
            this.Hide();
        }

        private void ShowClassViewFromPanel(object sender, EventArgs e)
        {
            // Get Class Id from panel
            Guna2Panel panel = (Guna2Panel)sender;
            int classId = int.Parse(panel.Controls[8].Text);

            ClassView classView = new ClassView
            {
                SchoolId = schoolId,
                SchoolName = schoolName,
                ClassId = classId,
                ClassName = panel.Controls[0].Text
            };

            classView.Show();
            this.Hide();
        }
        private void GoHomepage(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void Back(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Dispose();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label29.Text = schoolName;

            var classes = classTableAdapter.GetData().Where(classItem => classItem.school_id == schoolId).ToList();
         
            if (classes.Count == 0)
            {
                guna2Panel2.Visible = true;
            }

            for (int i = 0; i < classes.Count; i++)
            {
                QLDIEMDANHDataSet.ClassRow classRow = classes[i];

                // clone the panel
                Guna.UI2.WinForms.Guna2Panel tempPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = guna2Panel1.Size,
                    BackColor = guna2Panel1.BackColor
                };

                Label label = CloneLabel(label4);
                label.Text = $"{classRow.ten_mon_hoc}";
                tempPanel.Controls.Add(label);

                label = CloneLabel(label2);
                tempPanel.Controls.Add(label);

                label = CloneLabel(label5);
                label.Text = $"{classRow.startDate}";
                tempPanel.Controls.Add(label);

                label = CloneLabel(label6);
                tempPanel.Controls.Add(label);

                label = CloneLabel(label3);
                tempPanel.Controls.Add(label);

                label = CloneLabel(label30);
                tempPanel.Controls.Add(label);

                label = CloneLabel(label31);
                label.Text = $"{classRow.day}";
                tempPanel.Controls.Add(label);

                label = CloneLabel(label32);
                tempPanel.Controls.Add(label);

                label = CloneLabel(label33);
                label.Text = $"{classRow.ca_hoc}";

                label = CloneLabel(label7);
                label.Text = $"{classRow.id}";
                label.Visible = false;
                tempPanel.Controls.Add(label);

                Guna2Button button = CloneButton(guna2Button1);
                button.Click += new EventHandler(ShowClassViewFromButton);
                tempPanel.Controls.Add(button);

                button = CloneButton(guna2Button2);
                button.Click += new EventHandler(ShowEditClassForm);
                tempPanel.Controls.Add(button);

                button = CloneButton(guna2Button3);
                tempPanel.Controls.Add(button);

                // add container event handler
                tempPanel.MouseHover += new EventHandler(Mouse_Hover);
                tempPanel.MouseLeave += new EventHandler(Mouse_Leave);
                tempPanel.Click += new EventHandler(ShowClassViewFromPanel);

                container.Controls.Add(tempPanel);
            }
        }

        private void CreateClass(object sender, EventArgs e)
        {
            CreateClassForm form = new CreateClassForm
            {
                SchoolId = schoolId
            };
            form.Show();
            this.Dispose();
        }

        private void ShowEditClassForm(object sender, EventArgs e)
        {
            Guna2Panel panel = (Guna2Panel)((Guna2Button)sender).Parent;
            int classId = int.Parse(panel.Controls[8].Text);

            EditClassForm classForm = new EditClassForm
            {
                SchoolId = schoolId,
                ClassId = classId
            };

            classForm.Show();
            this.Dispose();
        }

        private void ConfirmDeleteClass(object sender, EventArgs e)
        {
            Guna2Panel panel = (Guna2Panel)((Guna2Button)sender).Parent;
            int classId = int.Parse(panel.Controls[8].Text);

            ConfirmDeletetion modal = new ConfirmDeletetion
            {
                ClassId = classId
            };

            modal.Show();
            this.Dispose();
        }
    }
}
