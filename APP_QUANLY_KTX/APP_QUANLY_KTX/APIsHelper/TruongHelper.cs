using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace ProjectQLKTX.APIsHelper
{
    public class TruongHelper : ITruongHelper
    {
        public async Task<APIRespone<string>> AddTruong(Truong truong)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(truong, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/truong/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteTruong(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            string url = Constant.Domain + "/api/truong/delete"; // Thay đổi đường dẫn API của bạn
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(id.ToString(), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public Task<APIRespone<string>> EditTruong(Truong truong)
        {
            throw new NotImplementedException();
        }

        public Task<APIRespone<List<Truong>>> GetListTruong()
        {
            throw new NotImplementedException();
        }

        public Task<APIRespone<Truong>> GetTruong(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
