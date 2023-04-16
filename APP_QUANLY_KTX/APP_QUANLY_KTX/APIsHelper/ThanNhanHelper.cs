using Newtonsoft.Json;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http;

namespace ProjectQLKTX.APIsHelper
{
    public class ThanNhanHelper : IThanNhanHelper
    {
        public Task<APIRespone<string>> AddThanNhan(Thannhan thanNhan)
        {
            throw new NotImplementedException();
        }

        public async Task<APIRespone<string>> DeleteThanNhan(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            string url = Constant.Domain + "/api/thannhan/delete"; // Thay đổi đường dẫn API của bạn
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(id.ToString(), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public Task<APIRespone<string>> EditThanNhan(Thannhan thanNhan)
        {
            throw new NotImplementedException();
        }

        public Task<APIRespone<List<Thannhan>>> GetListThanNhan()
        {
            throw new NotImplementedException();
        }

        public Task<APIRespone<Bienlai>> GetThanNhan(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
