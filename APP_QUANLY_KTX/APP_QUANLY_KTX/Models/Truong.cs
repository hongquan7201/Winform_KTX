using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Truong
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public int? STT { get; set; }
    public virtual ICollection<Sinhvien> Sinhviens { get; } = new List<Sinhvien>();
}
