using DevExpress.Accessibility;
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
    public class BankingHelper : IBankingHelper
    {
        public async Task<APIRespone<string>> AddBanking(Banking banking, string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(new
            {
                IdUser = banking.IdUser,
                amount = banking.amount,
                cmt = banking.cmt,
                type = banking.type,
                creatAt = banking.creatAt,
                IdBienLai = banking.IdBienLai

            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/banking/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<Banking>> GetBankingByCode(string code, string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            string query = "/api/banking/id?id={0}";
            var response = await httpClient.GetAsync(string.Format(query, code));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<Banking> data = JsonConvert.DeserializeObject<APIRespone<Banking>>(body);
            return data;
        }

        public async Task<APIRespone<List<Banking>>> GetListBanking(string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            string query = "/api/banking";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Banking>> data = JsonConvert.DeserializeObject<APIRespone<List<Banking>>>(body);
            return data;
        }
    }
}
