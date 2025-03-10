﻿namespace InfoRegSystem.Forms
{
    partial class UserMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDasboard = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.bookinfobtn = new System.Windows.Forms.Button();
            this.returnbtn = new System.Windows.Forms.Button();
            this.userpnlDash = new System.Windows.Forms.Panel();
            this.userDashboard1 = new InfoRegSystem.Forms.UserDashboard();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.userpnlDash.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnDasboard);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.logoutbtn);
            this.panel1.Controls.Add(this.bookinfobtn);
            this.panel1.Controls.Add(this.returnbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 729);
            this.panel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(0, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 43);
            this.button2.TabIndex = 11;
            this.button2.Text = "Transactions";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnTransaction_Click);
            // 
            // btnDasboard
            // 
            this.btnDasboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.btnDasboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDasboard.FlatAppearance.BorderSize = 0;
            this.btnDasboard.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.btnDasboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.btnDasboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.btnDasboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDasboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDasboard.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDasboard.Location = new System.Drawing.Point(0, 174);
            this.btnDasboard.Name = "btnDasboard";
            this.btnDasboard.Padding = new System.Windows.Forms.Padding(35, 0, 35, 0);
            this.btnDasboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDasboard.Size = new System.Drawing.Size(187, 43);
            this.btnDasboard.TabIndex = 9;
            this.btnDasboard.Text = "Dashboard";
            this.btnDasboard.UseVisualStyleBackColor = false;
            this.btnDasboard.Click += new System.EventHandler(this.btnDasboard_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(26, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(132, 128);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // logoutbtn
            // 
            this.logoutbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.logoutbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoutbtn.FlatAppearance.BorderSize = 0;
            this.logoutbtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.logoutbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.logoutbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.ForeColor = System.Drawing.Color.White;
            this.logoutbtn.Location = new System.Drawing.Point(0, 694);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(187, 35);
            this.logoutbtn.TabIndex = 6;
            this.logoutbtn.Text = "Log out";
            this.logoutbtn.UseVisualStyleBackColor = false;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // bookinfobtn
            // 
            this.bookinfobtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.bookinfobtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookinfobtn.FlatAppearance.BorderSize = 0;
            this.bookinfobtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.bookinfobtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.bookinfobtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.bookinfobtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookinfobtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookinfobtn.ForeColor = System.Drawing.SystemColors.Control;
            this.bookinfobtn.Location = new System.Drawing.Point(0, 216);
            this.bookinfobtn.Name = "bookinfobtn";
            this.bookinfobtn.Padding = new System.Windows.Forms.Padding(35, 0, 35, 0);
            this.bookinfobtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bookinfobtn.Size = new System.Drawing.Size(187, 43);
            this.bookinfobtn.TabIndex = 2;
            this.bookinfobtn.Text = "Book Info";
            this.bookinfobtn.UseVisualStyleBackColor = false;
            this.bookinfobtn.Click += new System.EventHandler(this.bookinfobtn_Click);
            // 
            // returnbtn
            // 
            this.returnbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.returnbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.returnbtn.FlatAppearance.BorderSize = 0;
            this.returnbtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.returnbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.returnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.returnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.returnbtn.Location = new System.Drawing.Point(0, 258);
            this.returnbtn.Name = "returnbtn";
            this.returnbtn.Padding = new System.Windows.Forms.Padding(35, 0, 35, 0);
            this.returnbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.returnbtn.Size = new System.Drawing.Size(187, 43);
            this.returnbtn.TabIndex = 5;
            this.returnbtn.Text = "Borrowing";
            this.returnbtn.UseVisualStyleBackColor = false;
            this.returnbtn.Click += new System.EventHandler(this.Returnbtn_Click);
            // 
            // userpnlDash
            // 
            this.userpnlDash.BackColor = System.Drawing.Color.White;
            this.userpnlDash.Controls.Add(this.userDashboard1);
            this.userpnlDash.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userpnlDash.Location = new System.Drawing.Point(188, 1);
            this.userpnlDash.Name = "userpnlDash";
            this.userpnlDash.Size = new System.Drawing.Size(1157, 729);
            this.userpnlDash.TabIndex = 4;
            // 
            // userDashboard1
            // 
            this.userDashboard1.BackColor = System.Drawing.Color.White;
            this.userDashboard1.Location = new System.Drawing.Point(-3, -1);
            this.userDashboard1.Name = "userDashboard1";
            this.userDashboard1.Size = new System.Drawing.Size(1157, 729);
            this.userDashboard1.TabIndex = 0;
            // 
            // UserMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userpnlDash);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserMainForm";
            this.Load += new System.EventHandler(this.UserMainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.userpnlDash.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button bookinfobtn;
        private System.Windows.Forms.Button returnbtn;
        private System.Windows.Forms.Panel userpnlDash;
        private System.Windows.Forms.Button btnDasboard;
        private UserDashboard userDashboard1;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Button button2;
    }
}