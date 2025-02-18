namespace InfoRegSystem.Forms
{
    partial class UserTransactions
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
            this.transactiongrid = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).BeginInit();
            this.SuspendLayout();
            // 
            // transactiongrid
            // 
            this.transactiongrid.AllowUserToAddRows = false;
            this.transactiongrid.AllowUserToDeleteRows = false;
            this.transactiongrid.BackgroundColor = System.Drawing.Color.White;
            this.transactiongrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactiongrid.GridColor = System.Drawing.Color.White;
            this.transactiongrid.Location = new System.Drawing.Point(52, 91);
            this.transactiongrid.Name = "transactiongrid";
            this.transactiongrid.ReadOnly = true;
            this.transactiongrid.Size = new System.Drawing.Size(1060, 609);
            this.transactiongrid.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(496, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 40);
            this.label7.TabIndex = 88;
            this.label7.Text = "Transactions";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Location = new System.Drawing.Point(-2, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2000, 2);
            this.panel5.TabIndex = 87;
            // 
            // UserTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 729);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.transactiongrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserTransactions";
            this.Text = "UserTransactions";
            this.Load += new System.EventHandler(this.UserTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactiongrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView transactiongrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
    }
}