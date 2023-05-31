using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Thannhan
{
    public Guid? Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Sdt { get; set; }

    public bool? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public Guid? IdUser { get; set; }

    public Guid? IdQuanHe { get; set; }
}
