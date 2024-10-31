using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System;

namespace WindowFormUI
{
    partial class ConfirmAttendance
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Inter", 15F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(21, 76);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(235, 31);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Xác nhận điểm danh";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 20;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(45)))), ((int)(((byte)(32)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.125F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(143, 227);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(112, 32);
            this.guna2Button2.TabIndex = 4;
            this.guna2Button2.Text = "Điểm danh";
            this.guna2Button2.Click += new System.EventHandler(this.Perform);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.125F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(21, 227);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(112, 32);
            this.guna2Button1.TabIndex = 5;
            this.guna2Button1.Text = "Hủy";
            this.guna2Button1.Click += new System.EventHandler(this.back);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::WindowFormUI.Properties.Resources.flag;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(21, 8);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(61, 64);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 6;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(21, 110);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(235, 26);
            this.guna2HtmlLabel3.TabIndex = 7;
            this.guna2HtmlLabel3.Text = "Chọn ngày bạn muốn điểm danh";
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.White;
            this.guna2DateTimePicker1.FocusedColor = System.Drawing.Color.White;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(21, 150);
            this.guna2DateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(274, 50);
            this.guna2DateTimePicker1.TabIndex = 8;
            this.guna2DateTimePicker1.Value = new System.DateTime(2024, 10, 29, 0, 0, 0, 0);
            // 
            // ConfirmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(363, 267);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfirmAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận điểm danh";
            this.Load += new System.EventHandler(this.ConfirmAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
    }
}
