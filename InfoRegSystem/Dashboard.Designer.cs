namespace InfoRegSystem
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMembership = new System.Windows.Forms.Button();
            this.pnlBooks = new System.Windows.Forms.Panel();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(408, 34);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Dashboard";
            // 
            // btnMembership
            // 
            this.btnMembership.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.btnMembership.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembership.ForeColor = System.Drawing.Color.Snow;
            this.btnMembership.Location = new System.Drawing.Point(1, 116);
            this.btnMembership.Name = "btnMembership";
            this.btnMembership.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMembership.Size = new System.Drawing.Size(160, 37);
            this.btnMembership.TabIndex = 2;
            this.btnMembership.Text = "     User Mnagement";
            this.btnMembership.UseVisualStyleBackColor = false;
            this.btnMembership.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // pnlBooks
            // 
            this.pnlBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(220)))));
            this.pnlBooks.Controls.Add(this.btnReturnBook);
            this.pnlBooks.Controls.Add(this.btnBorrow);
            this.pnlBooks.Location = new System.Drawing.Point(0, 226);
            this.pnlBooks.Name = "pnlBooks";
            this.pnlBooks.Size = new System.Drawing.Size(162, 74);
            this.pnlBooks.TabIndex = 4;
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.White;
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.Location = new System.Drawing.Point(1, 36);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Padding = new System.Windows.Forms.Padding(35, 0, 35, 0);
            this.btnReturnBook.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReturnBook.Size = new System.Drawing.Size(162, 37);
            this.btnReturnBook.TabIndex = 5;
            this.btnReturnBook.Text = "Borrow/Return";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.White;
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.Location = new System.Drawing.Point(1, 0);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Padding = new System.Windows.Forms.Padding(35, 0, 35, 0);
            this.btnBorrow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBorrow.Size = new System.Drawing.Size(160, 35);
            this.btnBorrow.TabIndex = 2;
            this.btnBorrow.Text = "Book Info";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(12, 195);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 123);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogout.Location = new System.Drawing.Point(0, 435);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(162, 37);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.AutoScroll = true;
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.pnlSideMenu.Controls.Add(this.pictureBox4);
            this.pnlSideMenu.Controls.Add(this.panel3);
            this.pnlSideMenu.Controls.Add(this.panel1);
            this.pnlSideMenu.Controls.Add(this.btnLogout);
            this.pnlSideMenu.Controls.Add(this.pictureBox2);
            this.pnlSideMenu.Controls.Add(this.pictureBox3);
            this.pnlSideMenu.Controls.Add(this.pnlBooks);
            this.pnlSideMenu.Controls.Add(this.btnBooks);
            this.pnlSideMenu.Controls.Add(this.btnMembership);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.pnlSideMenu.Size = new System.Drawing.Size(162, 486);
            this.pnlSideMenu.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(13, 441);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(162, 117);
            this.panel3.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(220)))));
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Location = new System.Drawing.Point(1, 154);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(160, 35);
            this.panel1.TabIndex = 8;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRegister.Location = new System.Drawing.Point(0, 0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(160, 35);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Membership";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(100)))), ((int)(((byte)(54)))));
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.ForeColor = System.Drawing.Color.Snow;
            this.btnBooks.Location = new System.Drawing.Point(1, 189);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBooks.Size = new System.Drawing.Size(160, 37);
            this.btnBooks.TabIndex = 3;
            this.btnBooks.Text = "      Book Management";
            this.btnBooks.UseVisualStyleBackColor = false;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(162, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 47);
            this.panel2.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(665, 486);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSideMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlSideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMembership;
        private System.Windows.Forms.Panel pnlBooks;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlSideMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}