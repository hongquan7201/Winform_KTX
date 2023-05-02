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
    public class SinhVienHelper : ISinhVienHelper
    {
        public async Task<Register> AddSinhVien(Sinhvien sinhVien)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            // var json = JsonConvert.SerializeObject(sinhVien, jsonSerializerSettings);
            var json = JsonConvert.SerializeObject(new
            {
                Email = sinhVien.Email,
                MaSv = sinhVien.MaSv,
                Password = sinhVien.Password,
                Name = sinhVien.Name,
                Address = sinhVien.Address,
                Cccd = sinhVien.Cccd,
                Sdt = sinhVien.Sdt,
                Gender = sinhVien.Gender,
                IdPhong = sinhVien.IdPhong,
                IdTruong = sinhVien.IdTruong,
                BirthDay = sinhVien.BirthDay,
                CreateAt = sinhVien.CreateAt
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/sinhvien/register", content);
            var body = await response.Content.ReadAsStringAsync();
            Register data = JsonConvert.DeserializeObject<Register>(body);
            return data;
        }

        public async Task<APIRespone<string>> DeleteSinhVien(Guid? id)
        {

            HttpClient httpClient = new HttpClient();
            string url = Constant.Domain + "/api/user/delete"; // Thay đổi đường dẫn API của bạn
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(id), System.Text.Encoding.UTF8, "application/json"); // Chuyển đối tượng id thành chuỗi JSON và đặt nội dung của request là chuỗi JSON này
            var response = await httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<string>> EditSinhVien(Sinhvien sinhVien)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(sinhVien, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/user/edit", content);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<string> data = JsonConvert.DeserializeObject<APIRespone<string>>(body);
            return data;
        }

        public async Task<APIRespone<List<Sinhvien>>> GetSinhVienByCCCD(string cccd)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/user/search/cccd?cccd={0}";
            var response = await httpClient.GetAsync(string.Format(query, cccd));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Sinhvien>> data = JsonConvert.DeserializeObject<APIRespone<List<Sinhvien>>>(body);
            return data;
        }

        public async Task<APIRespone<List<Sinhvien>>> GetSinhVienByName(string name)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/user/search/name?name={0}";
            var response = await httpClient.GetAsync(string.Format(query, name));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Sinhvien>> data = JsonConvert.DeserializeObject<APIRespone<List<Sinhvien>>>(body);
            return data;
        }

        public async Task<APIRespone<List<Sinhvien>>> GetListSinhVien()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/user";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Sinhvien>> data = JsonConvert.DeserializeObject<APIRespone<List<Sinhvien>>>(body);
            return data;
        }

        public async Task<APIRespone<List<Sinhvien>>> GetSinhVienById(Guid? id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/user/id?id={0}";
            var response = await httpClient.GetAsync(string.Format(query, id));
            var body = await response.Content.ReadAsStringAsync();
            APIRespone<List<Sinhvien>> data = JsonConvert.DeserializeObject < APIRespone<List<Sinhvien>>>(body);
            return data;
        }
    }
}
