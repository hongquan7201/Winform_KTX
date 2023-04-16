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
    public class LoaiXeHelper :ILoaiXeHelper
    {
        public async Task<APIRespone<string>> AddLoaiXe(Loaixe loaiXe)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(loaiXe, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/loaixe/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteLoaiXe(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            string url = Constant.Domain + "/api/loaixe/delete"; // Thay đổi đường dẫn API của bạn
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(id.ToString(), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> EditLoaiXe(Guid id, Loaixe loaiXe)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(loaiXe, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/loaixe/edit/{id}", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<List<Loaixe>>> GetListLoaiXe()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/loaixe";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Loaixe>> data = JsonConvert.DeserializeObject<APIRespone<List<Loaixe>>>(body);
            return data;
        }

        public async Task<APIRespone<Loaixe>> GetLoaiXe(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/loaixe/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<Loaixe> data = JsonConvert.DeserializeObject<APIRespone<Loaixe>>(body);
            return data;
        }
    }
}
