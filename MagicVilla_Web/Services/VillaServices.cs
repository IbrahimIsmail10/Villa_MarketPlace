using Magic_Villa_Web.Models.DTO;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Utility;

namespace MagicVilla_Web.Services
{
    public class VillaServices : BaseServices, IVillaServices
    {
        private readonly IHttpClientFactory _ClientFactory;
        private string villaUrl;
        public VillaServices(IHttpClientFactory ClientFactory,IConfiguration configuration) : base(ClientFactory)
        {
            _ClientFactory = ClientFactory;
            villaUrl = configuration.GetValue<string>("ServicesUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaCreatedDto entity, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.POST,
                Url = villaUrl + "/api/VillaAPI",
                Data = entity,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.GET,
                Url = villaUrl + "/api/VillaAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.GET,
                Url = villaUrl + "/api/VillaAPI/" + id,
                Token = token
            });
        }

        public Task<T> RemoveAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.DELETE,
                Url = villaUrl + "/api/VillaAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdatedDto entity, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.PUT,
                Url = villaUrl + "/api/VillaAPI/" + entity.Id,
                Data = entity,
                Token = token
            });
        }
    }
}
