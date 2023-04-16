using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Quanhe
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Thannhan> Thannhans { get; } = new List<Thannhan>();
}
