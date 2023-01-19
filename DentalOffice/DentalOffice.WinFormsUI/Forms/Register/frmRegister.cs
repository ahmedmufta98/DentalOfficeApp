using DentalOffice.Dtos;
using DentalOffice.Enums;
using DentalOffice.WinFormsUI.APIServices;
using DentalOffice.WinFormsUI.Forms.Login;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DentalOffice.WinFormsUI.Forms.Register
{
    public partial class frmRegister : Form
    {
        private readonly AuthAPIService _authAPIService = new("auth");
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>().Select(r => new { Value = r, Title = string.Format("-->{0}<--", r) }).ToList();

            cmbRole.DataSource = roles;
            cmbRole.ValueMember = "Value";
            cmbRole.DisplayMember = "Text";

            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g => new { Value = g, Title = string.Format("-->{0}<--", g) }).ToList();

            cmbGender.DataSource = genders;
            cmbGender.ValueMember = "Value";
            cmbGender.DisplayMember = "Text";
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                UserDto request = new()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Username = txtUsername.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    Password = txtPassword.Text,
                    PasswordConfirm = txtPasswordConfirm.Text,
                    Role = Enum.Parse<Role>(cmbRole.Text),
                    Gender = Enum.Parse<Gender>(cmbGender.Text)
                };

                var registredUser = await _authAPIService.Register(request);

                if (registredUser is not null)
                {
                    frmLogin frmLogin = new();
                    frmLogin.Show();
                    this.Hide();
                }
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

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
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

        private void cmbRole_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbRole.SelectedIndex < 0)
            {
                errorProvider.SetError(cmbRole, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbRole, null);
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

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtPasswordConfirm_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                errorProvider.SetError(txtPasswordConfirm, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPasswordConfirm, null);
            }

            if(!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                if(txtPassword.Text != txtPasswordConfirm.Text)
                {
                    errorProvider.SetError(txtPasswordConfirm, "Password and Password confirm are not equal!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtPasswordConfirm, null);
                }
            }
        }

        private void cmbGender_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbGender.SelectedIndex < 0)
            {
                errorProvider.SetError(cmbGender, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbGender, null);
            }
        }
    }
}
