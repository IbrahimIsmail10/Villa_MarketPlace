using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Utility;

namespace MagicVilla_Web.Services
{
    public class AuthService : BaseServices, IAuthServices
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string villaUrl;
        public AuthService(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            villaUrl = configuration.GetValue<string>("ServicesUrls:VillaAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.POST,
                Url = villaUrl + "/api/UserAPI/Login",
                Data = obj
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.POST,
                Url = villaUrl + "/api/UserAPI/Register",
                Data = obj
            });
        }
    }
}
