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

    public virtual ICollection<Bienlai> Bienlais { get; } = new List<Bienlai>();

    public virtual Hopdong? IdHopDongNavigation { get; set; }

    public virtual Sinhvien? IdUserNavigation { get; set; }
}
