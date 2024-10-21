using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using WindowFormUI.Forms;
using WindowFormUI.QLDIEMDANHDataSetTableAdapters;

namespace WindowFormUI
{
    public partial class Home : Form
    {
        private readonly SchoolTableAdapter schoolTableAdapter;
        private readonly ClassTableAdapter classTableAdapter;
        private readonly UsersTableAdapter usersTableAdapter;
        private static int userId;
        public Home()
        {
            InitializeComponent();
            schoolTableAdapter = new SchoolTableAdapter();
            classTableAdapter = new ClassTableAdapter();
            usersTableAdapter = new UsersTableAdapter();
        }

        public static int UserId
        {
            get => userId;
            set => userId = value;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Mouse_Hover(object sender, EventArgs e)
        {
            Guna2Panel panel = (Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.WhiteSmoke;
            guna2Panel5.Visible = true;

            // get class data from the database which is related to the school
            int schoolId = int.Parse(panel.Controls[5].Text);
            var classRows = classTableAdapter.GetData().Where(classRow => classRow.school_id == schoolId).ToList();

            label22.Text = $"{classRows.Count}";

            for (int i = 0; i < classRows.Count; i++)
            {
                QLDIEMDANHDataSet.ClassRow classRow = classRows[i];

                // clone the panel
                Panel classInfo = new Panel
                {
                    Size = panel1.Size,
                    BackColor = panel1.BackColor,
                };

                Label label = CloneLabel(label31);
                label.Text = $@"{classRow.ten_mon_hoc}";
                classInfo.Controls.Add(label);

                label = CloneLabel(label30);
                classInfo.Controls.Add(label);

                label = CloneLabel(label27);
                label.Text = $@"{classRow.nhom}";
                classInfo.Controls.Add(label);

                label = CloneLabel(label24);
                classInfo.Controls.Add(label);

                label = CloneLabel(label23);
                label.Text = $@"{classRow.to}";
                classInfo.Controls.Add(label);

                side_container.Controls.Add(classInfo);
            }
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            Guna2Panel panel = (Guna2Panel)sender;
            panel.FillColor = System.Drawing.Color.White;
            guna2Panel5.Visible = false;
        }

        private void ShowClassDashboardView(object sender, EventArgs e)
        {
            ClassTableAdapter classTableAdapter = new ClassTableAdapter();

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
                BorderColor = button.BorderColor,
                BorderRadius = button.BorderRadius,
                BorderThickness = button.BorderThickness
            };
            
            return newButton;
        }

        private void ViewSchoolDetails(object sender, EventArgs e)
        {
            // Get the school id from the panel which contains this button
            Guna2Button button = (Guna2Button)sender;
            Guna2Panel panel = (Guna2Panel)button.Parent;
            Label label = (Label)panel.Controls[5];
            int schoolId = int.Parse(label.Text);
            string schoolName = panel.Controls[0].Text;

            ClassDashboard classDashboard = new ClassDashboard();
            classDashboard.SchoolId = schoolId;
            classDashboard.SchoolName = schoolName;
            classDashboard.Show();
            this.Hide();
        }

        private void ConfirmDelete(object sender, EventArgs e)
        {
            // Get the school id from the panel which contains this button
            Guna2Button button = (Guna2Button)sender;
            Guna2Panel panel = (Guna2Panel)button.Parent;
            Label label = (Label)panel.Controls[5];
            string schoolId = label.Text;

            ConfirmDeletetion confirmDeletetion = new ConfirmDeletetion();
            confirmDeletetion.SchoolId = int.Parse(schoolId);
            confirmDeletetion.Show();
            this.Dispose();
        }

        private void ShowUpdateSchoolForm(object sender, EventArgs e)
        {

            foreach (Control control in Controls)
            {
                if (control is Guna2Button)
                {
                    control.Enabled = false;
                }
            }

            Guna2Button button = (Guna2Button)sender;
            Guna2Panel panel = (Guna2Panel)button.Parent;
            Label label = (Label)panel.Controls[5];

            EditSchoolForm editSchoolForm = new EditSchoolForm();
            editSchoolForm.SchoolId = int.Parse(label.Text);
            editSchoolForm.Show();
            this.Dispose();
        }

        private void showClassDashboard(object sender, EventArgs e, int index)
        {
            // Get the school id from the panel which contains this button
            Guna2Panel panel = (Guna2Panel)sender;
            Label label = (Label)panel.Controls[5];
            int schoolId = int.Parse(label.Text);
            string schoolName = panel.Controls[0].Text;

            ClassDashboard classDashboard = new ClassDashboard();
            classDashboard.SchoolId = schoolId;
            classDashboard.SchoolName = schoolName;
            classDashboard.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            int user_id = userId;
            string username = usersTableAdapter.GetData().Where(user => user.id == user_id).FirstOrDefault().username;
            label29.Text = $"{username}";


            // Get school data from the database
            var schoolRows = schoolTableAdapter.GetData().Where(school => school.user_id == user_id).ToList();

            if (schoolRows.Count == 0)
            {
                guna2Panel2.Visible = true;
            }
            // Duplicate guna2panel1 to 4 of the same size and add them to the flowlayoutpanel
            for (int i = 0; i < schoolRows.Count; i++)
            {
                QLDIEMDANHDataSet.SchoolRow schoolRow = schoolRows[i];

                // clone the panel
                Guna.UI2.WinForms.Guna2Panel panel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = guna2Panel1.Size,
                    BackColor = guna2Panel1.BackColor
                };

                // Clone labels and buttons
                Label label = CloneLabel(label4);
                label.Text = $@"{schoolRow.Ten_truong}";
                panel.Controls.Add(label);

                label = CloneLabel(label2);
                panel.Controls.Add(label);

                label = CloneLabel(label5);
                label.Text = $@"{schoolRow.Dia_chi}";
                panel.Controls.Add(label);

                label = CloneLabel(label3);
                panel.Controls.Add(label);

                label = CloneLabel(label6);
                label.Text = $@"{schoolRow.Ten_co_so}";
                panel.Controls.Add(label);

                label = CloneLabel(label7);
                label.Text = $"{schoolRow.id}";
                label.Visible = false;
                panel.Controls.Add(label);
                
                //label = CloneLabel(label3);
                //label.Text = $"{schoolRow.Thong_tin_them}";
                //label.Text = $"{label3.Text}{schoolRow.Thong_tin_them}".Substring(0, 13) + "...";
                //panel.Controls.Add(label);


                Guna2Button button = CloneButton(guna2Button1);
                button.Click += new EventHandler(ViewSchoolDetails);
                panel.Controls.Add(button);

                button = CloneButton(guna2Button2);
                button.Click += new EventHandler(ShowUpdateSchoolForm);
                panel.Controls.Add(button);

                button = CloneButton(guna2Button3);
                button.Click += new EventHandler(ConfirmDelete);
                panel.Controls.Add(button);

                // add container event handler
                panel.MouseHover += new EventHandler(Mouse_Hover);
                panel.MouseLeave += new EventHandler(Mouse_Leave);
                panel.Click += (sender_evt, e_evt) => showClassDashboard(sender_evt, e_evt, i);

                container.Controls.Add(panel);
            }
        }

        private void ShowCreateForm(object sender, EventArgs e)
        {
            // disable all the buttons
            foreach (Control control in Controls)
            {
                if (control is Guna2Button)
                {
                    control.Enabled = false;
                }
            }

            CreateSchoolForm createSchoolForm = new CreateSchoolForm();
            createSchoolForm.Show();
            this.Dispose();
        }

        private void Label9_Hover(object sender, EventArgs e)
        {
            label9.ForeColor = Color.DarkGray;
        }

        private void Label9_Leave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Gray;
        }
    }
}
