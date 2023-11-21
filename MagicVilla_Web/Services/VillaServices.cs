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

        public Task<T> CreateAsync<T>(VillaCreatedDto entity)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.POST,
                Url = villaUrl + "/api/VillaAPI",
                Data = entity
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.GET,
                Url = villaUrl + "/api/VillaAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.GET,
                Url = villaUrl + "/api/VillaAPI" + id
            });
        }

        public Task<T> RemoveAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.DELETE,
                Url = villaUrl + "/api/VillaAPI" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdatedDto entity)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.APITYPE.PUT,
                Url = villaUrl + "/api/VillaAPI" + entity.Id,
                Data = entity
            });
        }
    }
}
