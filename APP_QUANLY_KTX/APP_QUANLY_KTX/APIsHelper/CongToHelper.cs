using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;

namespace ProjectQLKTX.APIsHelper
{
    public class CongToHelper : ICongToHelper
    {
        public async Task<APIRespone<string>> AddCongTo(Congto CongTo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(CongTo, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/congto/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteCongTo(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            string url = Constant.Domain + "/api/congto/delete"; // Thay đổi đường dẫn API của bạn
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(id.ToString(), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> EditCongTo(Guid id,Congto CongTo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(CongTo, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/congto/edit/{id}", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<Bienlai>> GetCongTo(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/congto/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<Bienlai> data = JsonConvert.DeserializeObject<APIRespone<Bienlai>>(body);
            return data;
        }

        public async Task<APIRespone<List<Congto>>> GetListCongTo()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/congto";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Congto>> data = JsonConvert.DeserializeObject<APIRespone<List<Congto>>>(body);
            return data;
        }
    }
}
