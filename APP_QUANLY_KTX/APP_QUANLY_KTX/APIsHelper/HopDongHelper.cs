using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ProjectQLKTX.APIsHelper
{
    public class HopDongHelper : IHopDongHelper
    {
        public async Task<APIRespone<string>> AddHopDong(Hopdong hopDong)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(hopDong, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/hopdong/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteHopDong(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/hopdong/delete/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> EditHopDong(Guid id, Hopdong hopDong)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(hopDong, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/hopdong/edit/{id}", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<Hopdong>> GetHopDong(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/hopdong/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<Hopdong> data = JsonConvert.DeserializeObject<APIRespone<Hopdong>>(body);
            return data;
        }

        public async Task<APIRespone<List<Hopdong>>> GetListHopDong()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/hopdong";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Hopdong>> data = JsonConvert.DeserializeObject<APIRespone<List<Hopdong>>>(body);
            return data;
        }
    }
}
