using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace ProjectQLKTX.Logins
{
    public class LoginHelper : ILoginHelper
    {
        public async Task<APIRespone<Role>> Login(Account account)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(account, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/nhanvien/login", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<Role> data = JsonConvert.DeserializeObject<APIRespone<Role>>(body);
            return data;
        }
    }
}
