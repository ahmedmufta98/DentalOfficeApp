using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.WinFormsUI.APIServices;

namespace DentalOffice.WinFormsUI.Forms.Users
{
    public partial class frmUsers : Form
    {
        private BaseAPIService<int, UserDto, UserSearchRequestDto> _apiService = new("users");

        public frmUsers()
        {
            InitializeComponent();
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            UserSearchRequestDto searchRequest = new()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Username = string.Empty,
                Email = string.Empty,
                Phone = string.Empty,
                Gender = null,
                Role = Enums.Role.Client
            };

            dgvClients.AutoGenerateColumns = false;
            dgvClients.DataSource = await _apiService.GetFilteredData<List<UserDto>>(searchRequest);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            UserSearchRequestDto searchRequest = new()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Username = string.Empty,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Gender = null,
                Role = Enums.Role.Client
            };

            dgvClients.AutoGenerateColumns = false;
            dgvClients.DataSource = await _apiService.GetFilteredData<List<UserDto>>(searchRequest);
        }

        private void dgvClients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvClients.SelectedRows[0].Cells[0].Value;
            frmUserDetails frm = new(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
