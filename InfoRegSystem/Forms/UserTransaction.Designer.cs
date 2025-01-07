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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTransaction));
            this.returnbtn = new Guna.UI2.WinForms.Guna2Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.transactiongrid = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).BeginInit();
            this.SuspendLayout();
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
            this.returnbtn.Location = new System.Drawing.Point(80, 662);
            this.returnbtn.Name = "returnbtn";
            this.returnbtn.Size = new System.Drawing.Size(122, 37);
            this.returnbtn.TabIndex = 71;
            this.returnbtn.Text = "Returned Book";
            this.returnbtn.Click += new System.EventHandler(this.returnbtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Location = new System.Drawing.Point(0, 38);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2000, 2);
            this.panel5.TabIndex = 70;
            // 
            // transactiongrid
            // 
            this.transactiongrid.AllowUserToAddRows = false;
            this.transactiongrid.AllowUserToDeleteRows = false;
            this.transactiongrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.transactiongrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.transactiongrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(245)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transactiongrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.transactiongrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactiongrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.transactiongrid.EnableHeadersVisualStyles = false;
            this.transactiongrid.GridColor = System.Drawing.Color.Black;
            this.transactiongrid.Location = new System.Drawing.Point(43, 84);
            this.transactiongrid.Name = "transactiongrid";
            this.transactiongrid.ReadOnly = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.transactiongrid.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.transactiongrid.Size = new System.Drawing.Size(1086, 538);
            this.transactiongrid.TabIndex = 69;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(12, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(34, 39);
            this.btnBack.TabIndex = 68;
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(483, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(202, 37);
            this.textBox2.TabIndex = 67;
            this.textBox2.Text = "Transactions";
            // 
            // UserTransac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.returnbtn);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.transactiongrid);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.textBox2);
            this.Name = "UserTransac";
            this.Size = new System.Drawing.Size(1157, 729);
            this.Load += new System.EventHandler(this.UserTransac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button returnbtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView transactiongrid;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox textBox2;
    }
}
