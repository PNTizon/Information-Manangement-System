namespace InfoRegSystem.Forms
{
    partial class UserTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.userpanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.borrowedbtn = new Guna.UI2.WinForms.Guna2Button();
            this.returnbtn = new Guna.UI2.WinForms.Guna2Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.transactiongrid = new System.Windows.Forms.DataGridView();
            this.userpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).BeginInit();
            this.SuspendLayout();
            // 
            // userpanel
            // 
            this.userpanel.Controls.Add(this.label7);
            this.userpanel.Controls.Add(this.borrowedbtn);
            this.userpanel.Controls.Add(this.returnbtn);
            this.userpanel.Controls.Add(this.panel5);
            this.userpanel.Controls.Add(this.transactiongrid);
            this.userpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userpanel.Location = new System.Drawing.Point(0, 0);
            this.userpanel.Name = "userpanel";
            this.userpanel.Size = new System.Drawing.Size(1157, 729);
            this.userpanel.TabIndex = 0;
            this.userpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userpanel_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(467, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 40);
            this.label7.TabIndex = 78;
            this.label7.Text = "Transactions";
            // 
            // borrowedbtn
            // 
            this.borrowedbtn.BorderRadius = 10;
            this.borrowedbtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.borrowedbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.borrowedbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.borrowedbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.borrowedbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.borrowedbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(78)))));
            this.borrowedbtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.borrowedbtn.ForeColor = System.Drawing.Color.White;
            this.borrowedbtn.Location = new System.Drawing.Point(830, 672);
            this.borrowedbtn.Name = "borrowedbtn";
            this.borrowedbtn.Size = new System.Drawing.Size(115, 30);
            this.borrowedbtn.TabIndex = 77;
            this.borrowedbtn.Text = "Borrow";
            this.borrowedbtn.Click += new System.EventHandler(this.borrowedbtn_Click);
            // 
            // returnbtn
            // 
            this.returnbtn.BorderRadius = 10;
            this.returnbtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.returnbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.returnbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.returnbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.returnbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.returnbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(78)))));
            this.returnbtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.returnbtn.ForeColor = System.Drawing.Color.White;
            this.returnbtn.Location = new System.Drawing.Point(985, 672);
            this.returnbtn.Name = "returnbtn";
            this.returnbtn.Size = new System.Drawing.Size(115, 30);
            this.returnbtn.TabIndex = 76;
            this.returnbtn.Text = "Returned ";
            this.returnbtn.Click += new System.EventHandler(this.returnbtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Location = new System.Drawing.Point(2, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2000, 2);
            this.panel5.TabIndex = 75;
            // 
            // transactiongrid
            // 
            this.transactiongrid.AllowUserToAddRows = false;
            this.transactiongrid.AllowUserToDeleteRows = false;
            this.transactiongrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.transactiongrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.transactiongrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(245)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transactiongrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.transactiongrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactiongrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.transactiongrid.EnableHeadersVisualStyles = false;
            this.transactiongrid.GridColor = System.Drawing.Color.Black;
            this.transactiongrid.Location = new System.Drawing.Point(36, 81);
            this.transactiongrid.Name = "transactiongrid";
            this.transactiongrid.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.transactiongrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.transactiongrid.Size = new System.Drawing.Size(1086, 571);
            this.transactiongrid.TabIndex = 74;
            this.transactiongrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.transactiongrid_CellClick);
            // 
            // UserTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.userpanel);
            this.Name = "UserTransaction";
            this.Size = new System.Drawing.Size(1157, 729);
            this.Load += new System.EventHandler(this.UserTransac_Load);
            this.userpanel.ResumeLayout(false);
            this.userpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button borrowbtn;
        private System.Windows.Forms.Panel userpanel;
        private Guna.UI2.WinForms.Guna2Button borrowedbtn;
        private Guna.UI2.WinForms.Guna2Button returnbtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView transactiongrid;
        private System.Windows.Forms.Label label7;
    }
}
