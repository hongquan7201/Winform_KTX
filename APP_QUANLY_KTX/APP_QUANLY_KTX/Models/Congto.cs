using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Congto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int ChiSoDauThang { get; set; }

    public int ChiSoCuoiThang { get; set; }

    public Guid? IdLoaiCongTo { get; set; }

    public Guid? IdPhong { get; set; }

    public string? NgayUpdate { get; set; }

    public virtual Loaicongto? IdLoaiCongToNavigation { get; set; }

    public virtual Phong? IdPhongNavigation { get; set; }
}
