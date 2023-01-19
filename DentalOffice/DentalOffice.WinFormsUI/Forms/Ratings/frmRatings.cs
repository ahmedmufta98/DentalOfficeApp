using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.WinFormsUI.APIServices;

namespace DentalOffice.WinFormsUI.Forms.Ratings
{
    public partial class frmRatings : Form
    {
        private readonly BaseAPIService<int, RatingDto, RatingSearchRequestDto> _apiService = new("ratings");
        private readonly BaseAPIService<int, DentistDto, DentistSearchRequestDto> _dentistApiService = new("dentists");
        private readonly BaseAPIService<int, UserDto, UserSearchRequestDto> _userApiService = new("users");
        private ComboBoxHelper comboBoxHelper = new();
        public frmRatings()
        {
            InitializeComponent();
        }

        private async void frmRatings_Load(object sender, EventArgs e)
        {
            await LoadDentists();

            dgvRatings.AutoGenerateColumns = false;
            dgvRatings.DataSource = await _apiService.GetAll<List<RatingDto>>();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            RatingSearchRequestDto searchRequest = new()
            {
                DentistId = comboBoxHelper.GetIdFromComboBox(cmbDentists.ValueMember),
                UserId = comboBoxHelper.GetIdFromComboBox(cmbClients.ValueMember)
            };

            dgvRatings.AutoGenerateColumns = false;
            dgvRatings.DataSource = await _apiService.GetFilteredData<List<RatingDto>>(searchRequest);
        }

        private async Task LoadClients()
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

            cmbClients.DataSource = await _userApiService.GetFilteredData<List<UserDto>>(searchRequest);
            cmbClients.DisplayMember = "FullName";
            cmbClients.ValueMember = "Id";
        }

        private async Task LoadDentists()
        {
            cmbDentists.DataSource = await _dentistApiService.GetAll<List<DentistDto>>();
            cmbDentists.DisplayMember = "FullName";
            cmbDentists.ValueMember = "Id";

            await LoadClients();
        }
    }
}
