using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Xe
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Color { get; set; }

    public string? Code { get; set; }

    public DateTime? CreateAt { get; set; }

    public Guid? IdKhu { get; set; }

    public Guid? IdUser { get; set; }

    public Guid? IdLoaiXe { get; set; }

    public virtual Khu? IdKhuNavigation { get; set; }

    public virtual Loaixe? IdLoaiXeNavigation { get; set; }

    public virtual Sinhvien? IdUserNavigation { get; set; }
}
