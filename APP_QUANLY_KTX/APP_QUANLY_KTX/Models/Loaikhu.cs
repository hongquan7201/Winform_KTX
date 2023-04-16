using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Loaikhu
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Khu> Khus { get; } = new List<Khu>();
}
