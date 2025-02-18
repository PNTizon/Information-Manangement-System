namespace InfoRegSystem.User_Controls
{
    partial class UserBorrowing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.userpanel = new System.Windows.Forms.Panel();
            this.transactiongrid = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnBorrow = new Guna.UI2.WinForms.Guna2Button();
            this.BtnReturn = new Guna.UI2.WinForms.Guna2Button();
            this.userpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).BeginInit();
            this.SuspendLayout();
            // 
            // userpanel
            // 
            this.userpanel.Controls.Add(this.BtnReturn);
            this.userpanel.Controls.Add(this.BtnBorrow);
            this.userpanel.Controls.Add(this.label7);
            this.userpanel.Controls.Add(this.panel5);
            this.userpanel.Controls.Add(this.transactiongrid);
            this.userpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userpanel.Location = new System.Drawing.Point(0, 0);
            this.userpanel.Name = "userpanel";
            this.userpanel.Size = new System.Drawing.Size(1157, 729);
            this.userpanel.TabIndex = 0;
            // 
            // transactiongrid
            // 
            this.transactiongrid.AllowUserToAddRows = false;
            this.transactiongrid.AllowUserToDeleteRows = false;
            this.transactiongrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.transactiongrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.transactiongrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(245)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transactiongrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.transactiongrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactiongrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.transactiongrid.EnableHeadersVisualStyles = false;
            this.transactiongrid.GridColor = System.Drawing.Color.Black;
            this.transactiongrid.Location = new System.Drawing.Point(27, 77);
            this.transactiongrid.Name = "transactiongrid";
            this.transactiongrid.ReadOnly = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.transactiongrid.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.transactiongrid.Size = new System.Drawing.Size(1102, 587);
            this.transactiongrid.TabIndex = 84;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Location = new System.Drawing.Point(-3, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2000, 2);
            this.panel5.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(495, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 40);
            this.label7.TabIndex = 86;
            this.label7.Text = "Borrowing";
            // 
            // BtnBorrow
            // 
            this.BtnBorrow.BorderRadius = 10;
            this.BtnBorrow.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.BtnBorrow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnBorrow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnBorrow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnBorrow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnBorrow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(78)))));
            this.BtnBorrow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.BtnBorrow.ForeColor = System.Drawing.Color.White;
            this.BtnBorrow.Location = new System.Drawing.Point(821, 675);
            this.BtnBorrow.Name = "BtnBorrow";
            this.BtnBorrow.Size = new System.Drawing.Size(115, 37);
            this.BtnBorrow.TabIndex = 87;
            this.BtnBorrow.Text = "Borrow";
            this.BtnBorrow.Click += new System.EventHandler(this.BtnBorrow_Click);
            // 
            // BtnReturn
            // 
            this.BtnReturn.BorderRadius = 10;
            this.BtnReturn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.BtnReturn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnReturn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnReturn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnReturn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnReturn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(78)))));
            this.BtnReturn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.BtnReturn.ForeColor = System.Drawing.Color.White;
            this.BtnReturn.Location = new System.Drawing.Point(962, 675);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(115, 37);
            this.BtnReturn.TabIndex = 88;
            this.BtnReturn.Text = "Return";
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // UserBorrowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.userpanel);
            this.Name = "UserBorrowing";
            this.Size = new System.Drawing.Size(1157, 729);
            this.Load += new System.EventHandler(this.UserBorrowing_Load);
            this.userpanel.ResumeLayout(false);
            this.userpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userpanel;
        private Guna.UI2.WinForms.Guna2Button BtnReturn;
        private Guna.UI2.WinForms.Guna2Button BtnBorrow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView transactiongrid;
    }
}
