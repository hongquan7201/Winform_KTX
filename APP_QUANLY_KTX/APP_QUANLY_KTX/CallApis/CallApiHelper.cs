using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;
using System.Net.Http.Headers;
using System.Text;

namespace ProjectQLKTX.CallApis
{
    public class CallApiHelper
    {
        public async Task<APIRespone<List<K>>> GetList<K>(string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            var response = await httpClient.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<K>> data = JsonConvert.DeserializeObject<APIRespone<List<K>>>(body);
            return data;
        }
        public async Task<K> GetById<K>(string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            var response = await httpClient.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<K>> data = JsonConvert.DeserializeObject<APIRespone<List<K>>>(body);
            return data.data.FirstOrDefault();
        }
        public async Task<APIRespone<string>>Update<K>( K model,string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(model, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }
        public async Task<APIRespone<string>> Delete(string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            var response = await httpClient.DeleteAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }
        public async Task<APIRespone<string>> Add<K>(K model,string url)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(model, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }
    }
}
