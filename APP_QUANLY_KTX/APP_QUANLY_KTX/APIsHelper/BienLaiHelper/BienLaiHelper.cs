using Newtonsoft.Json;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ProjectQLKTX.APIsHelper.BienLaiHelper
{
    public class BienLaiHelper : IBienLaiHelper
    {
        public async Task<APIReponse> AddBienLai(Bienlai bienLai)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = System.Text.Json.JsonSerializer.Serialize(bienLai);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/bienlai", content);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            APIReponse data = JsonConvert.DeserializeObject<APIReponse>(body);
            return data;
        }

        public async Task<APIReponse> DeleteBienLai(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/bienlai/delete/{0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIReponse data = JsonConvert.DeserializeObject<APIReponse>(body);
            return data;
        }

        public async Task<APIReponse> EditBienLai(Guid id,Bienlai bienLai)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = System.Text.Json.JsonSerializer.Serialize(bienLai, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/bienlai/edit/{id}", content);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            APIReponse data = JsonConvert.DeserializeObject<APIReponse>(body);
            return data;
        }

        public async Task<BienLaiResponse<Bienlai>> GetBienLai(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/bienlai/{0}";
            var response = await httpClient.GetAsync(string.Format(query,id));
            var body = await response.Content.ReadAsStringAsync();
            BienLaiResponse<Bienlai> data = JsonConvert.DeserializeObject<BienLaiResponse<Bienlai>>(body);
            return data;
        }

        public async Task<BienLaiResponse<ListBienLaiResult>> GetListBienLai()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/bienlai";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            BienLaiResponse<ListBienLaiResult> data = JsonConvert.DeserializeObject<BienLaiResponse<ListBienLaiResult>>(body);
            return data;

        }
    }
}
