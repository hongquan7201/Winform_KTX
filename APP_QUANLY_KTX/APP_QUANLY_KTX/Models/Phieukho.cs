using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Phieukho
{
    public Guid Id { get; set; }

    public bool? Status { get; set; }

    public bool? Type { get; set; }

    public Guid? IdKho { get; set; }
}
