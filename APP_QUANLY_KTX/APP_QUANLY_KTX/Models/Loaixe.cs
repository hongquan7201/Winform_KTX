using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Loaixe
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Xe> Xes { get; } = new List<Xe>();
}
