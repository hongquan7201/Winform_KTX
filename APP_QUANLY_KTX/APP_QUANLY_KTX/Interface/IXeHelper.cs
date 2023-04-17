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
        Task<APIRespone<List<Xe>>> GetListXe();
        Task<APIRespone<Xe>> GetXe(Guid id);
        Task<APIRespone<string>> AddXe(Xe xe);
        Task<APIRespone<string>> EditXe(Xe xe);
        Task<APIRespone<string>> DeleteXe(Guid id);
    }
}
