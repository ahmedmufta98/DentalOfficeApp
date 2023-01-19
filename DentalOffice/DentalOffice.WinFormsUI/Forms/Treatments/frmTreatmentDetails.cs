using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.WinFormsUI.APIServices;

namespace DentalOffice.WinFormsUI.Forms.Treatments
{
    public partial class frmTreatmentDetails : Form
    {
        private readonly int? _id;
        private readonly BaseAPIService<int, TreatmentDto, TreatmentSearchRequestDto> _apiService = new("treatments");
        private byte[]? TreatmentImage { get; set; }

        public frmTreatmentDetails(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                TreatmentDto _request = new()
                {
                    Name = txtName.Text,
                    Price = int.Parse(txtPrice.Text),
                    TimeRequiredInMinutes = int.Parse(txtDuration.Text),
                    Image = TreatmentImage
                };

                if (_id is not null)
                {
                    _request.Id = _id.Value;
                    var updatedTreatment = await _apiService.Update<TreatmentDto>(_request.Id, _request);

                    if (updatedTreatment is not null)
                    {
                        MessageBox.Show("Treatment data successfully updated!");
                        this.Hide();
                    }
                }
                else
                {
                    var addedTreatment = await _apiService.Insert<TreatmentDto>(_request);

                    if (addedTreatment is not null)
                    {
                        MessageBox.Show("Treatment successfully added!");
                        this.Hide();
                    }
                }
            }
        }

        private async void frmTreatmentDetails_Load(object sender, EventArgs e)
        {
            if (_id is not null)
            {
                TreatmentDto treatment = await _apiService.GetById<TreatmentDto>(_id.Value);

                if (treatment is not null)
                {
                    txtName.Text = treatment.Name;
                    txtPrice.Text = treatment.Price.ToString();
                    txtDuration.Text = treatment.TimeRequiredInMinutes.ToString();
                    if (treatment.Image.Count() > 0)
                    {
                        ByteConverter byteConverter = new();
                        picBoxTreatment.Image = byteConverter.ByteToImage(treatment.Image);
                        picBoxTreatment.SizeMode = PictureBoxSizeMode.StretchImage;
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
                TreatmentImage = File.ReadAllBytes(fileName);
                txtImagePath.Text = fileName;

                Image image = Image.FromFile(fileName);
                picBoxTreatment.Image = image;
                picBoxTreatment.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private void txtPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                errorProvider.SetError(txtPrice, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrice, null);
            }
        }

        private void txtDuration_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                errorProvider.SetError(txtDuration, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDuration, null);
            }
        }
    }
}
