using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.WinFormsUI.APIServices;
using System.Windows.Forms;

namespace DentalOffice.WinFormsUI.Forms.Appointments
{
    public partial class frmAppointmentDetails : Form
    {
        private readonly int? _id;
        private readonly BaseAPIService<int, AppointmentDto, AppointmentSearchRequestDto> _apiService = new("appointments");
        private readonly BaseAPIService<int, DentistDto, DentistSearchRequestDto> _dentistApiService = new("dentists");
        private readonly BaseAPIService<int, TreatmentDto, TreatmentSearchRequestDto> _treatmentApiService = new("treatments");
        private readonly BaseAPIService<int, UserDto, UserSearchRequestDto> _userApiService = new("users");
        private readonly ComboBoxHelper comboBoxHelper = new();

        public frmAppointmentDetails(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            AppointmentDto _request = new()
            {
                Start = dtPicStart.Value.ToUniversalTime(),
                DentistId = comboBoxHelper.GetIdFromComboBox(cmbDentist.SelectedValue),
                TreatmentId = comboBoxHelper.GetIdFromComboBox(cmbTreatment.SelectedValue),
                UserId = comboBoxHelper.GetIdFromComboBox(cmbClients.SelectedValue)
            };

            var pickedTreatment = await _treatmentApiService.GetById<TreatmentDto>(_request.TreatmentId);
            if(pickedTreatment is not null)
            {
                _request.End = _request.Start.AddMinutes(double.Parse(pickedTreatment.TimeRequiredInMinutes.ToString())).ToUniversalTime();
            }

            if (_id is not null)
            {
                _request.Id = _id.Value;
                var updatedAppointment = await _apiService.Update<AppointmentDto>(_request.Id, _request);

                if (updatedAppointment is not null)
                {
                    MessageBox.Show("Appointment data successfully updated!");
                    this.Hide();
                }
            }
            else
            {
                var addedAppointment = await _apiService.Insert<AppointmentDto>(_request);

                if (addedAppointment is not null)
                {
                    MessageBox.Show("Appointment successfully added!");
                    this.Hide();
                }
            }
        }

        private async Task LoadTreatments()
        {
            cmbTreatment.DataSource = await _treatmentApiService.GetAll<List<TreatmentDto>>();
            cmbTreatment.DisplayMember = "Name";
            cmbTreatment.ValueMember = "Id";

            await LoadClients();
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
            cmbDentist.DataSource = await _dentistApiService.GetAll<List<DentistDto>>();
            cmbDentist.DisplayMember = "FullName";
            cmbDentist.ValueMember = "Id";

            await LoadTreatments();
        }

        private async void frmAppointmentDetails_Load(object sender, EventArgs e)
        {
            await LoadDentists();
        }

        private void dtPicStart_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtPicStart.Value == dtPicStart.MinDate)
            {
                errorProvider.SetError(dtPicStart, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtPicStart, null);
            }
        }
    }
}
