﻿namespace InfoRegSystem.Forms
{
    partial class AccountCreation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountCreation));
            this.label5 = new System.Windows.Forms.Label();
            this.showpass = new System.Windows.Forms.PictureBox();
            this.hidepass = new System.Windows.Forms.PictureBox();
            this.createbtn = new Guna.UI2.WinForms.Guna2Button();
            this.errorbox8 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.loginbtn = new Guna.UI2.WinForms.Guna2Button();
            this.errorbox1 = new System.Windows.Forms.TextBox();
            this.errorbox2 = new System.Windows.Forms.TextBox();
            this.errorbox3 = new System.Windows.Forms.TextBox();
            this.errorbox4 = new System.Windows.Forms.TextBox();
            this.errorbox5 = new System.Windows.Forms.TextBox();
            this.errorbox6 = new System.Windows.Forms.TextBox();
            this.errorbox7 = new System.Windows.Forms.TextBox();
            this.registration_firstname = new System.Windows.Forms.TextBox();
            this.registration_lastname = new System.Windows.Forms.TextBox();
            this.registration_ages = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.cmbCountryCode = new System.Windows.Forms.ComboBox();
            this.registration_number = new System.Windows.Forms.TextBox();
            this.registration_house = new System.Windows.Forms.TextBox();
            this.registration_emails = new System.Windows.Forms.TextBox();
            this.registration_username = new System.Windows.Forms.TextBox();
            this.registration_pass = new System.Windows.Forms.TextBox();
            this.countryNumbers = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.showpass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidepass)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(154, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 35);
            this.label5.TabIndex = 55;
            this.label5.Text = "Get Started ";
            // 
            // showpass
            // 
            this.showpass.Image = ((System.Drawing.Image)(resources.GetObject("showpass.Image")));
            this.showpass.Location = new System.Drawing.Point(409, 591);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(33, 22);
            this.showpass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showpass.TabIndex = 88;
            this.showpass.TabStop = false;
            this.showpass.Click += new System.EventHandler(this.showpass_Click);
            // 
            // hidepass
            // 
            this.hidepass.Image = ((System.Drawing.Image)(resources.GetObject("hidepass.Image")));
            this.hidepass.Location = new System.Drawing.Point(409, 591);
            this.hidepass.Name = "hidepass";
            this.hidepass.Size = new System.Drawing.Size(33, 22);
            this.hidepass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hidepass.TabIndex = 87;
            this.hidepass.TabStop = false;
            this.hidepass.Click += new System.EventHandler(this.hidepass_Click);
            // 
            // createbtn
            // 
            this.createbtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.createbtn.BorderRadius = 10;
            this.createbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.createbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.createbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.createbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.createbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.createbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.createbtn.ForeColor = System.Drawing.Color.White;
            this.createbtn.Location = new System.Drawing.Point(151, 657);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(163, 34);
            this.createbtn.TabIndex = 91;
            this.createbtn.Text = "Create Account";
            this.createbtn.Click += new System.EventHandler(this.createbtn_Click);
            // 
            // errorbox8
            // 
            this.errorbox8.BackColor = System.Drawing.Color.White;
            this.errorbox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox8.ForeColor = System.Drawing.Color.Red;
            this.errorbox8.Location = new System.Drawing.Point(89, 621);
            this.errorbox8.Multiline = true;
            this.errorbox8.Name = "errorbox8";
            this.errorbox8.Size = new System.Drawing.Size(301, 16);
            this.errorbox8.TabIndex = 90;
            this.errorbox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 92;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 93;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 94;
            this.label3.Text = "Phone No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(285, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 95;
            this.label4.Text = "Gender";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 96;
            this.label6.Text = "Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(79, 564);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 97;
            this.label8.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(79, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 98;
            this.label9.Text = "Username";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(70, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 16);
            this.label12.TabIndex = 99;
            this.label12.Text = "Age";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(278, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 100;
            this.label13.Text = "Last Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(132, 698);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 16);
            this.label14.TabIndex = 101;
            this.label14.Text = "Already have an accout?";
            // 
            // loginbtn
            // 
            this.loginbtn.BackColor = System.Drawing.Color.White;
            this.loginbtn.BorderRadius = 10;
            this.loginbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loginbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loginbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loginbtn.FillColor = System.Drawing.Color.Empty;
            this.loginbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loginbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.loginbtn.Location = new System.Drawing.Point(284, 692);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(60, 30);
            this.loginbtn.TabIndex = 102;
            this.loginbtn.Text = "Log in";
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // errorbox1
            // 
            this.errorbox1.BackColor = System.Drawing.Color.White;
            this.errorbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox1.ForeColor = System.Drawing.Color.Red;
            this.errorbox1.Location = new System.Drawing.Point(78, 122);
            this.errorbox1.Multiline = true;
            this.errorbox1.Name = "errorbox1";
            this.errorbox1.Size = new System.Drawing.Size(341, 16);
            this.errorbox1.TabIndex = 103;
            this.errorbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorbox2
            // 
            this.errorbox2.BackColor = System.Drawing.Color.White;
            this.errorbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox2.ForeColor = System.Drawing.Color.Red;
            this.errorbox2.Location = new System.Drawing.Point(47, 206);
            this.errorbox2.Multiline = true;
            this.errorbox2.Name = "errorbox2";
            this.errorbox2.Size = new System.Drawing.Size(129, 16);
            this.errorbox2.TabIndex = 104;
            this.errorbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorbox3
            // 
            this.errorbox3.BackColor = System.Drawing.Color.White;
            this.errorbox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox3.ForeColor = System.Drawing.Color.Red;
            this.errorbox3.Location = new System.Drawing.Point(247, 208);
            this.errorbox3.Multiline = true;
            this.errorbox3.Name = "errorbox3";
            this.errorbox3.Size = new System.Drawing.Size(207, 16);
            this.errorbox3.TabIndex = 105;
            this.errorbox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorbox4
            // 
            this.errorbox4.BackColor = System.Drawing.Color.White;
            this.errorbox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox4.ForeColor = System.Drawing.Color.Red;
            this.errorbox4.Location = new System.Drawing.Point(102, 294);
            this.errorbox4.Multiline = true;
            this.errorbox4.Name = "errorbox4";
            this.errorbox4.Size = new System.Drawing.Size(290, 16);
            this.errorbox4.TabIndex = 106;
            this.errorbox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorbox5
            // 
            this.errorbox5.BackColor = System.Drawing.Color.White;
            this.errorbox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox5.ForeColor = System.Drawing.Color.Red;
            this.errorbox5.Location = new System.Drawing.Point(160, 381);
            this.errorbox5.Multiline = true;
            this.errorbox5.Name = "errorbox5";
            this.errorbox5.Size = new System.Drawing.Size(154, 16);
            this.errorbox5.TabIndex = 107;
            this.errorbox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorbox6
            // 
            this.errorbox6.BackColor = System.Drawing.Color.White;
            this.errorbox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox6.ForeColor = System.Drawing.Color.Red;
            this.errorbox6.Location = new System.Drawing.Point(90, 459);
            this.errorbox6.Multiline = true;
            this.errorbox6.Name = "errorbox6";
            this.errorbox6.Size = new System.Drawing.Size(301, 16);
            this.errorbox6.TabIndex = 108;
            this.errorbox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorbox7
            // 
            this.errorbox7.BackColor = System.Drawing.Color.White;
            this.errorbox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorbox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorbox7.ForeColor = System.Drawing.Color.Red;
            this.errorbox7.Location = new System.Drawing.Point(91, 543);
            this.errorbox7.Multiline = true;
            this.errorbox7.Name = "errorbox7";
            this.errorbox7.Size = new System.Drawing.Size(301, 16);
            this.errorbox7.TabIndex = 109;
            this.errorbox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // registration_firstname
            // 
            this.registration_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_firstname.Location = new System.Drawing.Point(74, 90);
            this.registration_firstname.Name = "registration_firstname";
            this.registration_firstname.Size = new System.Drawing.Size(147, 26);
            this.registration_firstname.TabIndex = 112;
            // 
            // registration_lastname
            // 
            this.registration_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_lastname.Location = new System.Drawing.Point(274, 90);
            this.registration_lastname.Name = "registration_lastname";
            this.registration_lastname.Size = new System.Drawing.Size(147, 26);
            this.registration_lastname.TabIndex = 113;
            // 
            // registration_ages
            // 
            this.registration_ages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_ages.Location = new System.Drawing.Point(74, 174);
            this.registration_ages.Name = "registration_ages";
            this.registration_ages.Size = new System.Drawing.Size(70, 26);
            this.registration_ages.TabIndex = 114;
            this.registration_ages.TextChanged += new System.EventHandler(this.registration_ages_TextChanged);
            this.registration_ages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.registration_ages_KeyPress);
            // 
            // cmbGender
            // 
            this.cmbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(274, 174);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(145, 28);
            this.cmbGender.TabIndex = 115;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.cmbGender_SelectedIndexChanged);
            // 
            // cmbCountryCode
            // 
            this.cmbCountryCode.DropDownHeight = 100;
            this.cmbCountryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountryCode.FormattingEnabled = true;
            this.cmbCountryCode.IntegralHeight = false;
            this.cmbCountryCode.Location = new System.Drawing.Point(129, 261);
            this.cmbCountryCode.Name = "cmbCountryCode";
            this.cmbCountryCode.Size = new System.Drawing.Size(115, 28);
            this.cmbCountryCode.TabIndex = 116;
            this.cmbCountryCode.SelectedIndexChanged += new System.EventHandler(this.cmbCountryCode_SelectedIndexChanged);
            // 
            // registration_number
            // 
            this.registration_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_number.Location = new System.Drawing.Point(244, 262);
            this.registration_number.Name = "registration_number";
            this.registration_number.Size = new System.Drawing.Size(105, 26);
            this.registration_number.TabIndex = 117;
            this.registration_number.TextChanged += new System.EventHandler(this.registration_number_TextChanged);
            this.registration_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.registration_number_KeyPress);
            // 
            // registration_house
            // 
            this.registration_house.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_house.Location = new System.Drawing.Point(73, 350);
            this.registration_house.Name = "registration_house";
            this.registration_house.Size = new System.Drawing.Size(330, 26);
            this.registration_house.TabIndex = 118;
            // 
            // registration_emails
            // 
            this.registration_emails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_emails.Location = new System.Drawing.Point(74, 427);
            this.registration_emails.Name = "registration_emails";
            this.registration_emails.Size = new System.Drawing.Size(329, 26);
            this.registration_emails.TabIndex = 119;
            // 
            // registration_username
            // 
            this.registration_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_username.Location = new System.Drawing.Point(73, 512);
            this.registration_username.Name = "registration_username";
            this.registration_username.Size = new System.Drawing.Size(330, 26);
            this.registration_username.TabIndex = 120;
            // 
            // registration_pass
            // 
            this.registration_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registration_pass.Location = new System.Drawing.Point(73, 588);
            this.registration_pass.Name = "registration_pass";
            this.registration_pass.Size = new System.Drawing.Size(330, 26);
            this.registration_pass.TabIndex = 121;
            this.registration_pass.TextChanged += new System.EventHandler(this.registration_pass_TextChanged);
            // 
            // countryNumbers
            // 
            this.countryNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryNumbers.Location = new System.Drawing.Point(130, 262);
            this.countryNumbers.Name = "countryNumbers";
            this.countryNumbers.Size = new System.Drawing.Size(98, 26);
            this.countryNumbers.TabIndex = 122;
            this.countryNumbers.TextChanged += new System.EventHandler(this.countryNumbers_TextChanged);
            // 
            // AccountCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 746);
            this.Controls.Add(this.countryNumbers);
            this.Controls.Add(this.registration_pass);
            this.Controls.Add(this.registration_username);
            this.Controls.Add(this.registration_emails);
            this.Controls.Add(this.registration_house);
            this.Controls.Add(this.registration_number);
            this.Controls.Add(this.cmbCountryCode);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.registration_ages);
            this.Controls.Add(this.registration_lastname);
            this.Controls.Add(this.registration_firstname);
            this.Controls.Add(this.errorbox7);
            this.Controls.Add(this.errorbox6);
            this.Controls.Add(this.errorbox5);
            this.Controls.Add(this.errorbox4);
            this.Controls.Add(this.errorbox3);
            this.Controls.Add(this.errorbox2);
            this.Controls.Add(this.errorbox1);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createbtn);
            this.Controls.Add(this.errorbox8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.showpass);
            this.Controls.Add(this.hidepass);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AccountCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AccCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showpass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hidepass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox showpass;
        private System.Windows.Forms.PictureBox hidepass;
        private Guna.UI2.WinForms.Guna2Button createbtn;
        private System.Windows.Forms.TextBox errorbox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2Button loginbtn;
        private System.Windows.Forms.TextBox errorbox1;
        private System.Windows.Forms.TextBox errorbox2;
        private System.Windows.Forms.TextBox errorbox3;
        private System.Windows.Forms.TextBox errorbox4;
        private System.Windows.Forms.TextBox errorbox5;
        private System.Windows.Forms.TextBox errorbox6;
        private System.Windows.Forms.TextBox errorbox7;
        private System.Windows.Forms.TextBox registration_firstname;
        private System.Windows.Forms.TextBox registration_lastname;
        private System.Windows.Forms.TextBox registration_ages;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbCountryCode;
        private System.Windows.Forms.TextBox registration_number;
        private System.Windows.Forms.TextBox registration_house;
        private System.Windows.Forms.TextBox registration_emails;
        private System.Windows.Forms.TextBox registration_username;
        private System.Windows.Forms.TextBox registration_pass;
        private System.Windows.Forms.TextBox countryNumbers;
    }
}