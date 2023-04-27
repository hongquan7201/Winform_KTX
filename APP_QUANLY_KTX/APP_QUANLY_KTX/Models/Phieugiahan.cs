using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Phieugiahan
{
    public Guid Id { get; set; }

    public string? DayStart { get; set; }

    public string? DayEnd { get; set; }

    public bool? Status { get; set; }

    public Guid? IdUser { get; set; }

    public Guid? IdHopDong { get; set; }

}
