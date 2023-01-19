using DentalOffice.Dtos;
using DentalOffice.WinFormsUI.APIServices;

namespace DentalOffice.WinFormsUI.Forms.DentistOffice
{
    public partial class frmDentistOfficeDetails : Form
    {
        private readonly BaseAPIService<int, DentistOfficeDto, object> _apiService = new("dentistoffices");
        private List<DentistOfficeDto> _dentistOffices = new();
        private bool _isUpdate = false;

        public frmDentistOfficeDetails()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            DentistOfficeDto _request = new()
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Description = txtDescription.Text
            };

            if (_isUpdate)
            {
                _request.Id = _dentistOffices.First().Id;
                var dentistOffice = await _apiService.Update<DentistOfficeDto>(_request.Id, _request);

                if (dentistOffice is not null)
                {
                    MessageBox.Show("Dentist office data successfully updated!");
                    this.Hide();
                }
            }
            else
            {
                var dentistOffice = await _apiService.Insert<DentistOfficeDto>(_request);

                if (dentistOffice is not null)
                {
                    MessageBox.Show("Dentist office data successfully added!");
                    this.Hide();
                }
            }
        }

        private async void frmDentistOfficeDetails_Load(object sender, EventArgs e)
        {
            _dentistOffices = await _apiService.GetAll<List<DentistOfficeDto>>(null);

            if (_dentistOffices.Any())
                _isUpdate = true;

            if (_isUpdate)
            {
                txtName.Text = _dentistOffices[0].Name;
                txtAddress.Text = _dentistOffices[0].Address;
                txtEmail.Text = _dentistOffices[0].Email;
                txtPhone.Text = _dentistOffices[0].Phone;
                txtDescription.Text = _dentistOffices[0].Description;
            }
        }
    }
}
