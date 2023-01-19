using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.WinFormsUI.APIServices;

namespace DentalOffice.WinFormsUI.Forms.Treatments
{
    public partial class frmTreatments : Form
    {
        private BaseAPIService<int, TreatmentDto, TreatmentSearchRequestDto> _apiService = new("treatments");
        public frmTreatments()
        {
            InitializeComponent();
        }

        private async void frmTreatments_Load(object sender, EventArgs e)
        {
            dgvTreatments.AutoGenerateColumns = false;
            dgvTreatments.DataSource = await _apiService.GetAll<List<TreatmentDto>>();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            TreatmentSearchRequestDto searchRequest = new()
            {
                Name = txtName.Text
            };

            List<TreatmentDto> treatments = await _apiService.GetFilteredData<List<TreatmentDto>>(searchRequest);

            if (treatments.Any())
            {
                dgvTreatments.AutoGenerateColumns = false;
                dgvTreatments.DataSource = treatments;
            }
            else
            {
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvTreatments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvTreatments.SelectedRows[0].Cells[0].Value;
            frmTreatmentDetails frm = new(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
