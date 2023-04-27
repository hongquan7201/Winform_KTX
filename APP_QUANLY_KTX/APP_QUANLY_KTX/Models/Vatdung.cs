using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Vatdung
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Quantity { get; set; }

    public bool? Status { get; set; }

    public Guid? IdLoaiVatDung { get; set; }

    public Guid? IdKho { get; set; }
}
