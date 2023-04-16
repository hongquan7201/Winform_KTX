using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Khu
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? IdLoaiKhu { get; set; }

    public virtual Loaikhu? IdLoaiKhuNavigation { get; set; }

    public virtual ICollection<Phong> Phongs { get; } = new List<Phong>();

    public virtual ICollection<Xe> Xes { get; } = new List<Xe>();
}
