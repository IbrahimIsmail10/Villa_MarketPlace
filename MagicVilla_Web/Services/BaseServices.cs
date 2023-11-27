using Magic_Villa_Web.Models;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using Utility;

namespace MagicVilla_Web.Services
{
    public class BaseServices : IBaseServices
    {
        public APIResponse APIResponse { get; set; }
        public IHttpClientFactory HttpClient { get; set; }
        public BaseServices(IHttpClientFactory httpClient)
        {
           this.APIResponse = new APIResponse();
            this.HttpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest ApiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(ApiRequest.Url);
                if (ApiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(ApiRequest.Data)
                                       ,Encoding.UTF8, "application/json");
                }
                switch (ApiRequest.ApiType) {
                    case SD.APITYPE.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.APITYPE.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.APITYPE.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage _response = null;
                _response = await client.SendAsync(message);
                var apicontent =await _response.Content.ReadAsStringAsync();
                try 
                {
                    APIResponse respon = JsonConvert.DeserializeObject<APIResponse>(apicontent);
                    if (_response.StatusCode == System.Net.HttpStatusCode.BadRequest 
                        || _response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        respon.Status = System.Net.HttpStatusCode.BadRequest;
                        respon.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(respon);
                        var returnObj = JsonConvert.DeserializeObject<T>(res);
                        return returnObj;
                        
                    }

                }
                catch (Exception e)
                { 
                    var excep = JsonConvert.DeserializeObject<T>(apicontent);
                    return excep;
                }
                var APIResponse = JsonConvert.DeserializeObject<T>(apicontent);
                return APIResponse;
            }
            catch(Exception ex)
            {
                var dto = new APIResponse()
                {
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false

                };
                var content = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(content);
                return APIResponse;
            }
        }
    }
}
