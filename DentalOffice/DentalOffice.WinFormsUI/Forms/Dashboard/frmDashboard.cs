using DentalOffice.WinFormsUI.Forms.Appointments;
using DentalOffice.WinFormsUI.Forms.DentistOffice;
using DentalOffice.WinFormsUI.Forms.Dentists;
using DentalOffice.WinFormsUI.Forms.Payments;
using DentalOffice.WinFormsUI.Forms.Ratings;
using DentalOffice.WinFormsUI.Forms.Report;
using DentalOffice.WinFormsUI.Forms.Treatments;
using DentalOffice.WinFormsUI.Forms.Users;

namespace DentalOffice.WinFormsUI.Forms.Dashboard
{
    public partial class frmDashboard : Form
    {
        private int childFormNumber = 0;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDentistOfficeDetails frmDentistOfficeDetails = new();
            frmDentistOfficeDetails.Show();
        }

        private void newTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTreatmentDetails frmTreatmentDetails = new(null);
            frmTreatmentDetails.Show();
        }

        private void newDentistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDentistDetails frmDentistDetails = new(null);
            frmDentistDetails.Show();
        }

        private void dentistsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDentists frmDentists = new();
            frmDentists.Show();
        }

        private void treatmentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTreatments frmTreatments = new();
            frmTreatments.Show();
        }

        private void newAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppointmentDetails frmAppointmentDetails = new(null);
            frmAppointmentDetails.Show();
        }

        private void appointmentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAppointments frmAppointments = new();
            frmAppointments.Show();
        }

        private void allPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayments frmPayments = new();
            frmPayments.Show();
        }

        private void allRatingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRatings frmRatings = new();
            frmRatings.Show();
        }

        private void allClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frmUsers = new();
            frmUsers.Show();
        }

        private void mVPDentistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptDentistMvp report = new();
            report.Show();
        }
    }
}
