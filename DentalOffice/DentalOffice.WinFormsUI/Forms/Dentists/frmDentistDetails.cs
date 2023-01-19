using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.WinFormsUI.APIServices;

namespace DentalOffice.WinFormsUI.Forms.Dentists
{
    public partial class frmDentistDetails : Form
    {
        private readonly int? _id;
        private readonly BaseAPIService<int, DentistDto, DentistSearchRequestDto> _apiService = new("dentists");
        private readonly BaseAPIService<int, DentistOfficeDto, object> _dentistOfficesApiService = new("dentistoffices");

        private byte[] DentistImage { get; set; }

        public frmDentistDetails(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {
                List<DentistOfficeDto> dentistOffices = await _dentistOfficesApiService.GetAll<List<DentistOfficeDto>>(null);

                if (dentistOffices.Any())
                {
                    DentistDto _request = new()
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Address = txtAddress.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Description = txtDescription.Text,
                        Active = chBoxActive.Checked,
                        BirthDate = dtPickerBirth.Value.ToUniversalTime(),
                        DentistOfficeId = dentistOffices.First().Id,
                        Image = DentistImage
                    };

                    if (_id is null)
                    {
                        DentistDto createdDentist = await _apiService.Insert<DentistDto>(_request);

                        if (createdDentist is not null)
                        {
                            MessageBox.Show("Dentist successfully added!");
                            this.Hide();
                        }
                    }
                    else
                    {
                        _request.Id = _id.Value;

                        DentistDto updatedDentist = await _apiService.Update<DentistDto>(_request.Id, _request);

                        if (updatedDentist is not null)
                        {
                            MessageBox.Show("Dentist successfully updated!");
                            this.Hide();
                        }
                    }
                }
            }
        }

        private async void frmDentistDetails_Load(object sender, EventArgs e)
        {
            if (_id is not null)
            {
                DentistDto dentist = await _apiService.GetById<DentistDto>(_id.Value);

                if (dentist is not null)
                {
                    txtFirstName.Text = dentist.FirstName;
                    txtLastName.Text = dentist.LastName;
                    txtAddress.Text = dentist.Address;
                    txtDescription.Text = dentist.Description;
                    txtEmail.Text = dentist.Email;
                    txtPhone.Text = dentist.Phone;
                    dtPickerBirth.Value = dentist.BirthDate;
                    chBoxActive.Checked = dentist.Active;

                    if (dentist.Image.Count() > 0)
                    {
                        ByteConverter byteConverter = new();
                        picBoxDentist.Image = byteConverter.ByteToImage(dentist.Image);
                        picBoxDentist.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                var fileName = openFileDialog.FileName;
                DentistImage = File.ReadAllBytes(fileName);
                txtImagePath.Text = fileName;

                Image image = Image.FromFile(fileName);
                picBoxDentist.Image = image;
                picBoxDentist.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhone, null);
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAddress, null);
            }
        }

        private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider.SetError(txtDescription, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDescription, null);
            }
        }

        private void dtPickerBirth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dtPickerBirth.Value == dtPickerBirth.MinDate)
            {
                errorProvider.SetError(dtPickerBirth, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtPickerBirth, null);
            }
        }

        private void txtImagePath_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImagePath.Text))
            {
                errorProvider.SetError(txtImagePath, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtImagePath, null);
            }
        }
    }
}
