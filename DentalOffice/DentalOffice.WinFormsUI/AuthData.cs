namespace DentalOffice.WinFormsUI
{
    public class AuthData
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private static AuthData instance = null;

        private AuthData()
        {

        }

        public static AuthData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthData();
                }

                return instance;
            }
        }
    }
}
