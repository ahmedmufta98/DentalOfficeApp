namespace DentalOffice.WinFormsUI.Forms.Appointments
{
    partial class frmAppointments
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
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DentistFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreatmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDentists = new System.Windows.Forms.ComboBox();
            this.cmbTreatments = new System.Windows.Forms.ComboBox();
            this.dtPicStart = new System.Windows.Forms.DateTimePicker();
            this.dtPicEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Start,
            this.End,
            this.DentistFullName,
            this.TreatmentName,
            this.ClientFullName});
            this.dgvAppointments.Location = new System.Drawing.Point(12, 150);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.RowTemplate.Height = 25;
            this.dgvAppointments.Size = new System.Drawing.Size(768, 288);
            this.dgvAppointments.TabIndex = 0;
            this.dgvAppointments.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAppointments_CellMouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Start
            // 
            this.Start.DataPropertyName = "Start";
            this.Start.HeaderText = "Start";
            this.Start.Name = "Start";
            // 
            // End
            // 
            this.End.DataPropertyName = "End";
            this.End.HeaderText = "End";
            this.End.Name = "End";
            // 
            // DentistFullName
            // 
            this.DentistFullName.DataPropertyName = "DentistFullName";
            this.DentistFullName.HeaderText = "Dentist";
            this.DentistFullName.Name = "DentistFullName";
            // 
            // TreatmentName
            // 
            this.TreatmentName.DataPropertyName = "TreatmentName";
            this.TreatmentName.HeaderText = "Treatment";
            this.TreatmentName.Name = "TreatmentName";
            // 
            // ClientFullName
            // 
            this.ClientFullName.DataPropertyName = "ClientFullName";
            this.ClientFullName.HeaderText = "Client";
            this.ClientFullName.Name = "ClientFullName";
            // 
            // cmbDentists
            // 
            this.cmbDentists.FormattingEnabled = true;
            this.cmbDentists.Location = new System.Drawing.Point(450, 27);
            this.cmbDentists.Name = "cmbDentists";
            this.cmbDentists.Size = new System.Drawing.Size(192, 23);
            this.cmbDentists.TabIndex = 1;
            // 
            // cmbTreatments
            // 
            this.cmbTreatments.FormattingEnabled = true;
            this.cmbTreatments.Location = new System.Drawing.Point(659, 27);
            this.cmbTreatments.Name = "cmbTreatments";
            this.cmbTreatments.Size = new System.Drawing.Size(121, 23);
            this.cmbTreatments.TabIndex = 2;
            // 
            // dtPicStart
            // 
            this.dtPicStart.Location = new System.Drawing.Point(12, 27);
            this.dtPicStart.Name = "dtPicStart";
            this.dtPicStart.Size = new System.Drawing.Size(200, 23);
            this.dtPicStart.TabIndex = 3;
            // 
            // dtPicEnd
            // 
            this.dtPicEnd.Location = new System.Drawing.Point(230, 27);
            this.dtPicEnd.Name = "dtPicEnd";
            this.dtPicEnd.Size = new System.Drawing.Size(200, 23);
            this.dtPicEnd.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "End date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dentist";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(659, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Treatment";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(705, 121);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbClients
            // 
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(12, 72);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(200, 23);
            this.cmbClients.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Client";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "*Double click for opening appointment details";
            // 
            // frmAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbClients);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPicEnd);
            this.Controls.Add(this.dtPicStart);
            this.Controls.Add(this.cmbTreatments);
            this.Controls.Add(this.cmbDentists);
            this.Controls.Add(this.dgvAppointments);
            this.Name = "frmAppointments";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.frmAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvAppointments;
        private ComboBox cmbDentists;
        private ComboBox cmbTreatments;
        private DateTimePicker dtPicStart;
        private DateTimePicker dtPicEnd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSearch;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Start;
        private DataGridViewTextBoxColumn End;
        private DataGridViewTextBoxColumn DentistFullName;
        private DataGridViewTextBoxColumn TreatmentName;
        private DataGridViewTextBoxColumn ClientFullName;
        private ComboBox cmbClients;
        private Label label5;
        private Label label6;
    }
}