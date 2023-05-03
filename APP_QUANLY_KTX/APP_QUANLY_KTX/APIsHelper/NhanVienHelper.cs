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
    public class NhanVienHelper : INhanVienHelper
    {
        public async Task<APIRespone<string>> AddNhanVien(Nhanvien nhanVien)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(new
            {
                Name = nhanVien.Name,
                Password = nhanVien.Password,
                Email = nhanVien.Email,
                Address = nhanVien.Address,
                CreateAt = nhanVien.CreateAt,
                Birthday = nhanVien.Birthday,
                Cccd = nhanVien.Cccd,
                Gender = nhanVien.Gender,
                Sdt = nhanVien.Sdt
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/nhanvien/register", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }
        public async Task<APIRespone<string>> DeleteNhanVien(Guid id)
        {
            string url = Constant.Domain + "api/nhanvien/delete";// Thay đổi đường dẫn API của bạn
            var httpClient = new HttpClient();
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

        public async Task<APIRespone<string>> EditNhanVien(Nhanvien nhanVien)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(new
            {
                Id = nhanVien.Id,
                Name = nhanVien.Name,
                Password = nhanVien.Password,
                Email = nhanVien.Email,
                Address = nhanVien.Address,
                CreateAt = nhanVien.CreateAt,
                Birthday = nhanVien.Birthday,
                Cccd = nhanVien.Cccd,
                Gender = nhanVien.Gender,
                Sdt = nhanVien.Sdt
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/nhanvien/edit", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<List<Nhanvien>>> GetListNhanVien()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/nhanvien";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Nhanvien>> data = JsonConvert.DeserializeObject<APIRespone<List<Nhanvien>>>(body);
            return data;
        }

        public async Task<APIRespone<List<Nhanvien>>> GetNhanVienByEmail(string? email)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/nhanvien/search/email?email={0}";
            var response = await httpClient.GetAsync(string.Format(query, email));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Nhanvien>> data = JsonConvert.DeserializeObject<APIRespone<List<Nhanvien>>>(body);
            return data;
        }

        public async Task<APIRespone<List<Nhanvien>>> GetNhanVienById(Guid? id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/nhanvien/id?id={0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Nhanvien>> data = JsonConvert.DeserializeObject<APIRespone<List<Nhanvien>>>(body);
            return data;
        }

        public async Task<APIRespone<List<Nhanvien>>> GetNhanVienByName(string? name)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/nhanvien/search/name?name={0}";
            var response = await httpClient.GetAsync(string.Format(query, name));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Nhanvien>> data = JsonConvert.DeserializeObject<APIRespone<List<Nhanvien>>>(body);
            return data;
        }

        public async Task<APIRespone<string>> ResetPassword(string email)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(email, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/nhanvien/reset", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }
    }
}
