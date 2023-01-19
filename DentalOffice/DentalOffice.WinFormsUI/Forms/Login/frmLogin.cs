using DentalOffice.Dtos;
using DentalOffice.WinFormsUI.APIServices;
using DentalOffice.WinFormsUI.Forms.Dashboard;
using DentalOffice.WinFormsUI.Forms.Register;
using System.Xml.Linq;

namespace DentalOffice.WinFormsUI.Forms.Login
{
    public partial class frmLogin : Form
    {
        private readonly AuthAPIService _authApiService = new("auth");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                AuthData authData = AuthData.Instance;
                authData.Username = txtUsername.Text;
                authData.Password = txtPassword.Text;

                UserLoginDto loginRequest = new()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };

                UserDto loggedUser = await _authApiService.Login(loginRequest);

                if (loggedUser is not null)
                {
                    if (loggedUser.Role == Enums.Role.Admin)
                    {
                        frmDashboard frmDashboard = new();
                        frmDashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Only administrators can be logged in desktop app!");
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister frmRegister = new();
            frmRegister.Show();
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
    }
}
