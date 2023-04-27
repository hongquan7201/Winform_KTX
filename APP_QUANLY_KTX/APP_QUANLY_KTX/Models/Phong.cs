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
    public string? NameKhu { get; set; }
    public int? MaxPeople { get;set; }
    public int? STT { get; set; }
}
