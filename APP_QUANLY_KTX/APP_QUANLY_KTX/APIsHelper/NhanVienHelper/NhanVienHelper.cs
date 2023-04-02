using Newtonsoft.Json;
using ProjectQLKTX.APIsHelper.BienLaiHelper;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace ProjectQLKTX.APIsHelper.NhanVienHelper
{
    public class NhanVienHelper : INhanVienHelper
    {
        public Task AddNhanVien(Nhanvien nhanVien)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteNhanVien(Guid id)
        {
          
        }

        public async Task<APIReponse> EditNhanVien(Guid id,Nhanvien nhanVien)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(nhanVien, jsonSerializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/nhanvien/{id}", content);
            var body = await response.Content.ReadAsStringAsync();
            APIReponse data = JsonConvert.DeserializeObject<APIReponse>(body);
            return data;
        }

        public async Task<NhanVienRespone<List<Nhanvien>>> GetListNhanVien()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/nhanvien";
            var response = await httpClient.GetAsync(query);
            var body = await response.Content.ReadAsStringAsync();
            NhanVienRespone<List<Nhanvien>> data = JsonConvert.DeserializeObject<NhanVienRespone<List<Nhanvien>>>(body);
            return data;
        }

        public async Task<NhanVienRespone<Nhanvien>> GetNhanVien(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constant.Domain);
            string query = "/api/nhanvien/{0}";
            var response = await httpClient.GetAsync(string.Format(query,id));
            var body = await response.Content.ReadAsStringAsync();
            NhanVienRespone<Nhanvien> data = JsonConvert.DeserializeObject<NhanVienRespone<Nhanvien>>(body);
            return data;
        }
    }
}
