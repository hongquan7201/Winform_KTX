using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Loaivatdung
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Vatdung> Vatdungs { get; } = new List<Vatdung>();
}
