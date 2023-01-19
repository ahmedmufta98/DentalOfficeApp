using Flurl.Http;

namespace DentalOffice.WinFormsUI.APIServices
{
    public class BaseAPIService<Tkey, Tmodel, Tsearch> where Tmodel : class where Tsearch : class
    {
        private readonly string _route = "";
        public static string Username { get; set; } = string.Empty;
        public static string Password { get; set; } = string.Empty;

        public BaseAPIService(string route)
        {
            _route = route;

            if (Username == string.Empty || Password == string.Empty)
            {
                AuthData authData = AuthData.Instance;

                if (authData is not null)
                {
                    Username = authData.Username;
                    Password = authData.Password;
                }
            }
        }

        public async Task<T> GetAll<T>(Tsearch? search = null)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}";

                if (search is not null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }

        public async Task<T> GetFilteredData<T>(Tsearch search)
        {
            var url = $"{Properties.Settings.Default.APIurl}/{_route}/filtering";
            return await url.WithBasicAuth(Username, Password).PostJsonAsync(search).ReceiveJson<T>();
        }

        public async Task<T> GetById<T>(Tkey id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }

        public async Task<T> Insert<T>(Tmodel request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }

        public async Task<T> Update<T>(Tkey id, Tmodel request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }

        public async Task<T> Delete<T>(Tkey id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
    }
}
