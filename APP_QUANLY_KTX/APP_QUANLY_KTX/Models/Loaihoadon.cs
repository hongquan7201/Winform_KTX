using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Loaihoadon
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hoadon> Hoadons { get; } = new List<Hoadon>();
}
