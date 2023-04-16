using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Phong
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public int? QuantityPeople { get; set; }

    public Guid? IdKhu { get; set; }

    public virtual ICollection<Congto> Congtos { get; } = new List<Congto>();

    public virtual ICollection<Hoadon> Hoadons { get; } = new List<Hoadon>();

    public virtual ICollection<Hopdong> Hopdongs { get; } = new List<Hopdong>();

    public virtual Khu? IdKhuNavigation { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; } = new List<Sinhvien>();

    public virtual ICollection<Taisan> Taisans { get; } = new List<Taisan>();
}
