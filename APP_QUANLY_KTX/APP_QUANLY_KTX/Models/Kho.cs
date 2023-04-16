using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Kho
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Phieukho> Phieukhos { get; } = new List<Phieukho>();

    public virtual ICollection<Vatdung> Vatdungs { get; } = new List<Vatdung>();
}
