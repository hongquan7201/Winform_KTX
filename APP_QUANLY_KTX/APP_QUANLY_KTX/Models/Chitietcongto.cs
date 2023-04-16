using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Chitietcongto
{
    public Guid Id { get; set; }

    public int? ChiSoDauThang { get; set; }

    public int? ChiSoCuoiThang { get; set; }

    public Guid? IdCongTo { get; set; }

    public virtual Congto? IdCongToNavigation { get; set; }
}
