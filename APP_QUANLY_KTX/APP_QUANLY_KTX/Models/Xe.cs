using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public  class Xe
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public Guid? IdKhu { get; set; }

    public Guid? IdUser { get; set; }

    public Guid? IdLoaiXe { get; set; }

    public  Khu? IdKhuNavigation { get; set; }

    public  Loaixe? IdLoaiXeNavigation { get; set; }

    public  Sinhvien? IdUserNavigation { get; set; }
}
