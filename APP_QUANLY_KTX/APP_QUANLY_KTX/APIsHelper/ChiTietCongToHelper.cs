using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static DevExpress.XtraBars.Docking2010.Views.BaseRegistrator;

namespace ProjectQLKTX.APIsHelper
{
    public class ChiTietCongToHelper : IChiTietCongToHelper
    {
        public async Task<APIRespone<string>> AddChiTietCongTo(Chitietcongto chiTietCongTo, string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(new
            {
                ChiSoDienDauThang = chiTietCongTo.ChiSoDienDauThang,
                ChiSoDienCuoiThang = chiTietCongTo.ChiSoDienCuoiThang,
                ChiSoNuocDauThang = chiTietCongTo.ChiSoNuocDauThang,
                IdCongTo = chiTietCongTo.IdCongTo,
                ChiSoNuocCuoiThang = chiTietCongTo.ChiSoNuocCuoiThang,
                SoNuocTieuThu = chiTietCongTo.SoNuocTieuThu,
                SoDienTieuThu = chiTietCongTo.SoDienTieuThu,
                IdPhong = chiTietCongTo.IdPhong,
                CreateAt = chiTietCongTo.CreateAt
            }) ;
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/chitietcongto/add", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteChiTietCongTo(Guid id, string token)
        {
            string url = Constant.Domain + "api/chitietcongto/delete";// Thay đổi đường dẫn API của bạn
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var jsonId = JsonConvert.SerializeObject(id);
            var content = new StringContent(jsonId, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = content
            };
            var response = await httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> EditChiTietCongTo(Chitietcongto chiTietCongTo, string token)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(new
            {
                Id = chiTietCongTo.Id,
                ChiSoDienDauThang = chiTietCongTo.ChiSoDienDauThang,
                ChiSoDienCuoiThang = chiTietCongTo.ChiSoDienCuoiThang,
                ChiSoNuocDauThang = chiTietCongTo.ChiSoNuocDauThang,
                IdCongTo = chiTietCongTo.IdCongTo,
                ChiSoNuocCuoiThang = chiTietCongTo.ChiSoNuocCuoiThang,
                SoNuocTieuThu = chiTietCongTo.SoNuocTieuThu,
                SoDienTieuThu = chiTietCongTo.SoDienTieuThu,
                IdPhong = chiTietCongTo.IdPhong,
                CreateAt = chiTietCongTo.CreateAt
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/chitietcongto/edit", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<List<Chitietcongto>>> GetChiTietCongTo(Guid? id, string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            string query = "/api/chitietcongto/id?id={0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Chitietcongto>> data = JsonConvert.DeserializeObject<APIRespone<List<Chitietcongto>>>(body);
            return data;
        }

        public async Task<APIRespone<List<Chitietcongto>>> GetListChiTietCongTo(string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            string query = "/api/chitietcongto";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Chitietcongto>> data = JsonConvert.DeserializeObject<APIRespone<List<Chitietcongto>>>(body);
            return data;
        }
    }
}
