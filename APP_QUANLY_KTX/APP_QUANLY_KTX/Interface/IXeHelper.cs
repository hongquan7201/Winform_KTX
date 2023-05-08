using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLKTX.Interface
{
    public interface IXeHelper
    {
        Task<APIRespone<List<Xe>>> GetListXe(string token);
        Task<APIRespone<List<Xe>>> GetXe(Guid? id, string token);
        Task<APIRespone<string>> AddXe(Xe xe, string token);
        Task<APIRespone<string>> EditXe(Xe xe, string token);
        Task<APIRespone<string>> DeleteXe(Guid id, string token);
    }
}
