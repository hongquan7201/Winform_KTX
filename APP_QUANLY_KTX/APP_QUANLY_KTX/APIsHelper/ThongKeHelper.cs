using Newtonsoft.Json;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProjectQLKTX.APIsHelper
{
    public class ThongKeHelper : IThongKeHelper
    {
        public async Task<APIRespone<ResponeThongKe>> GetThongKe(string url, int yearFind, string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", token);
            string query = url + "?nam=" + yearFind;
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<ResponeThongKe> data = JsonConvert.DeserializeObject<APIRespone<ResponeThongKe>>(body);
            return data;
        }
    }
}
