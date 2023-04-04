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
    public class KhuHelper : IKhuHelper
    {
        public async Task<APIRespone<string>> AddKhu(Khu khu)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(khu, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/khu/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteKhu(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/khu/delete/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> EditKhu(Guid id, Khu khu)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(khu, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/khu/edit/{id}", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<Khu>> GetKhu(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/khu/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<Khu> data = JsonConvert.DeserializeObject<APIRespone<Khu>>(body);
            return data;
        }

        public async Task<APIRespone<List<Khu>>> GetListKhu()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/khu";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Khu>> data = JsonConvert.DeserializeObject<APIRespone<List<Khu>>>(body);
            return data;
        }
    }
}
