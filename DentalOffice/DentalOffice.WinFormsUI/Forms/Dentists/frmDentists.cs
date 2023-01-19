using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.WinFormsUI.APIServices;

namespace DentalOffice.WinFormsUI.Forms.Dentists
{
    public partial class frmDentists : Form
    {
        private BaseAPIService<int, DentistDto, DentistSearchRequestDto> _apiService = new("dentists");

        public frmDentists()
        {
            InitializeComponent();
        }

        private async void frmDentists_Load(object sender, EventArgs e)
        {
            dgvDentists.AutoGenerateColumns = false;
            dgvDentists.DataSource = await _apiService.GetAll<List<DentistDto>>();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            DentistSearchRequestDto searchRequest = new()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            List<DentistDto> dentists = await _apiService.GetFilteredData<List<DentistDto>>(searchRequest);

            if (dentists.Any())
            {
                dgvDentists.AutoGenerateColumns = false;
                dgvDentists.DataSource = dentists;
            }
            else
            {
                MessageBox.Show("There are no results for this search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDentists_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvDentists.SelectedRows[0].Cells[0].Value;
            frmDentistDetails frm = new(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
