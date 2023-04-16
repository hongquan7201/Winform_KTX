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
    public class LoaiHoaDonHelper : ILoaiHoaDonHelper
    {
        public async Task<APIRespone<string>> AddLoaiHoaDon(Loaihoadon loaiHoaDon)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(loaiHoaDon, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/loaihoadon/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteLoaiHoaDon(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            string url = Constant.Domain + "/api/loaihoadon/delete"; // Thay đổi đường dẫn API của bạn
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(id.ToString(), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> EditLoaiHoaDon(Guid id, Loaihoadon loaiHoaDon)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(loaiHoaDon, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/loaihoadon/edit/{id}", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<List<Loaihoadon>>> GetListLoaiHoaDon()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/loaihoadon";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Loaihoadon>> data = JsonConvert.DeserializeObject<APIRespone<List<Loaihoadon>>>(body);
            return data;
        }

        public async Task<APIRespone<Loaihoadon>> GetLoaiHoaDon(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/loaihoadon/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<Loaihoadon> data = JsonConvert.DeserializeObject<APIRespone<Loaihoadon>>(body);
            return data;
        }
    }
}
