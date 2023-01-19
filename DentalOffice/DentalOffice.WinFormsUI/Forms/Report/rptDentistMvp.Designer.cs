namespace DentalOffice.WinFormsUI.Forms.Report
{
    partial class rptDentistMvp
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
            this.dgvMvpDentist = new System.Windows.Forms.DataGridView();
            this.DentistFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerateExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMvpDentist)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMvpDentist
            // 
            this.dgvMvpDentist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMvpDentist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DentistFullName,
            this.AverageRate});
            this.dgvMvpDentist.Location = new System.Drawing.Point(12, 132);
            this.dgvMvpDentist.Name = "dgvMvpDentist";
            this.dgvMvpDentist.RowTemplate.Height = 25;
            this.dgvMvpDentist.Size = new System.Drawing.Size(776, 306);
            this.dgvMvpDentist.TabIndex = 0;
            // 
            // DentistFullName
            // 
            this.DentistFullName.DataPropertyName = "DentistFullName";
            this.DentistFullName.HeaderText = "Dentist";
            this.DentistFullName.Name = "DentistFullName";
            // 
            // AverageRate
            // 
            this.AverageRate.DataPropertyName = "AverageRate";
            this.AverageRate.HeaderText = "Average rate";
            this.AverageRate.Name = "AverageRate";
            // 
            // btnGenerateExcel
            // 
            this.btnGenerateExcel.Location = new System.Drawing.Point(665, 70);
            this.btnGenerateExcel.Name = "btnGenerateExcel";
            this.btnGenerateExcel.Size = new System.Drawing.Size(123, 36);
            this.btnGenerateExcel.TabIndex = 1;
            this.btnGenerateExcel.Text = "Generate Excel";
            this.btnGenerateExcel.UseVisualStyleBackColor = true;
            this.btnGenerateExcel.Click += new System.EventHandler(this.btnGenerateExcel_Click);
            // 
            // rptDentistMvp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateExcel);
            this.Controls.Add(this.dgvMvpDentist);
            this.Name = "rptDentistMvp";
            this.Text = "Report dentist MVP";
            this.Load += new System.EventHandler(this.rptDentistMvp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMvpDentist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvMvpDentist;
        private DataGridViewTextBoxColumn DentistFullName;
        private DataGridViewTextBoxColumn AverageRate;
        private Button btnGenerateExcel;
    }
}