using System.Drawing;
using System.Windows.Forms;

namespace WindowFormUI
{
    partial class CreateClassForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tenTruong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox4 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2TextBox6 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2TextBox8 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tieuDe
            // 
            this.tieuDe.AutoSize = false;
            this.tieuDe.BackColor = System.Drawing.Color.Transparent;
            this.tieuDe.Font = new System.Drawing.Font("Inter", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(71)))), ((int)(((byte)(191)))));
            this.tieuDe.Location = new System.Drawing.Point(306, 11);
            this.tieuDe.Margin = new System.Windows.Forms.Padding(2);
            this.tieuDe.Name = "tieuDe";
            this.tieuDe.Size = new System.Drawing.Size(185, 41);
            this.tieuDe.TabIndex = 0;
            this.tieuDe.Text = "Tạo lớp học";
            // 
            // tenTruong
            // 
            this.tenTruong.AutoSize = false;
            this.tenTruong.BackColor = System.Drawing.Color.Transparent;
            this.tenTruong.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tenTruong.ForeColor = System.Drawing.Color.DimGray;
            this.tenTruong.Location = new System.Drawing.Point(58, 56);
            this.tenTruong.Margin = new System.Windows.Forms.Padding(2);
            this.tenTruong.Name = "tenTruong";
            this.tenTruong.Size = new System.Drawing.Size(136, 26);
            this.tenTruong.TabIndex = 1;
            this.tenTruong.Text = " Tên môn học";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(92)))), ((int)(((byte)(250)))));
            this.guna2Button1.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(462, 564);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(163, 50);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "Tạo mới";
            this.guna2Button1.Click += new System.EventHandler(this.CreateClass);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.SystemColors.Control;
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(92)))), ((int)(((byte)(250)))));
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.CustomBorderColor = System.Drawing.Color.White;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2Button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(92)))), ((int)(((byte)(250)))));
            this.guna2Button2.Location = new System.Drawing.Point(147, 566);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(163, 50);
            this.guna2Button2.TabIndex = 7;
            this.guna2Button2.Text = " Trở lại";
            this.guna2Button2.Click += new System.EventHandler(this.Back);
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderColor = System.Drawing.Color.Gray;
            this.guna2TextBox1.BorderRadius = 15;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2TextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(58, 88);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.guna2TextBox1.PlaceholderText = "Tên môn học";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(657, 57);
            this.guna2TextBox1.TabIndex = 1;
            // 
            // guna2TextBox4
            // 
            this.guna2TextBox4.BorderColor = System.Drawing.Color.Gray;
            this.guna2TextBox4.BorderRadius = 15;
            this.guna2TextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox4.DefaultText = "";
            this.guna2TextBox4.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox4.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox4.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox4.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2TextBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox4.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox4.Location = new System.Drawing.Point(58, 198);
            this.guna2TextBox4.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TextBox4.Name = "guna2TextBox4";
            this.guna2TextBox4.PasswordChar = '\0';
            this.guna2TextBox4.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.guna2TextBox4.PlaceholderText = "123456";
            this.guna2TextBox4.SelectedText = "";
            this.guna2TextBox4.Size = new System.Drawing.Size(322, 50);
            this.guna2TextBox4.TabIndex = 2;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(58, 166);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(213, 26);
            this.guna2HtmlLabel1.TabIndex = 10;
            this.guna2HtmlLabel1.Text = " Mã môn học (nếu có)";
            // 
            // guna2TextBox6
            // 
            this.guna2TextBox6.BorderColor = System.Drawing.Color.Gray;
            this.guna2TextBox6.BorderRadius = 15;
            this.guna2TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox6.DefaultText = "";
            this.guna2TextBox6.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox6.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox6.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox6.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2TextBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox6.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox6.Location = new System.Drawing.Point(58, 300);
            this.guna2TextBox6.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TextBox6.Name = "guna2TextBox6";
            this.guna2TextBox6.PasswordChar = '\0';
            this.guna2TextBox6.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.guna2TextBox6.PlaceholderText = "T1";
            this.guna2TextBox6.SelectedText = "";
            this.guna2TextBox6.Size = new System.Drawing.Size(657, 51);
            this.guna2TextBox6.TabIndex = 4;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(58, 268);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(119, 26);
            this.guna2HtmlLabel2.TabIndex = 13;
            this.guna2HtmlLabel2.Text = "Tổ (nếu có)";
            // 
            // guna2TextBox8
            // 
            this.guna2TextBox8.BorderColor = System.Drawing.Color.Gray;
            this.guna2TextBox8.BorderRadius = 15;
            this.guna2TextBox8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox8.DefaultText = "";
            this.guna2TextBox8.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox8.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox8.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox8.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2TextBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox8.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox8.Location = new System.Drawing.Point(58, 418);
            this.guna2TextBox8.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TextBox8.Name = "guna2TextBox8";
            this.guna2TextBox8.PasswordChar = '\0';
            this.guna2TextBox8.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.guna2TextBox8.PlaceholderText = "danhsachlop.csv";
            this.guna2TextBox8.SelectedText = "";
            this.guna2TextBox8.Size = new System.Drawing.Size(609, 58);
            this.guna2TextBox8.TabIndex = 5;
            this.guna2TextBox8.Click += new System.EventHandler(this.BrowseFile);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.DimGray;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(58, 386);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(406, 26);
            this.guna2HtmlLabel3.TabIndex = 16;
            this.guna2HtmlLabel3.Text = "Upload Danh sách lớp (.csv)  (MSSV, Họ, Tên)";
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.BorderColor = System.Drawing.Color.Gray;
            this.guna2TextBox2.BorderRadius = 15;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2TextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Location = new System.Drawing.Point(388, 198);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.guna2TextBox2.PlaceholderText = "N1";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(327, 50);
            this.guna2TextBox2.TabIndex = 3;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Inter", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.DimGray;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(388, 166);
            this.guna2HtmlLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(124, 26);
            this.guna2HtmlLabel5.TabIndex = 20;
            this.guna2HtmlLabel5.Text = "Nhóm / Lớp";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 58);
            this.button1.TabIndex = 22;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BrowseFile);
            // 
            // CreateClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2TextBox2);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2TextBox8);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2TextBox6);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2TextBox4);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.tenTruong);
            this.Controls.Add(this.tieuDe);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo lớp học";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel tieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel tenTruong;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Button button1;
    }
}
