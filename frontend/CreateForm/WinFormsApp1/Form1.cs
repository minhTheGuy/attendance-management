namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ProgressIndicator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            using (modalForm modal = new modalForm())
            {
                form = modal;
                form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            using (modalTaoLop modal = new modalTaoLop())
            {
                form = modal;
                form.ShowDialog();
            }
        }

    }
}
