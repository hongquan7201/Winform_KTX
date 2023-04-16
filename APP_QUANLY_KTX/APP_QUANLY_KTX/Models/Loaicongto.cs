﻿using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Loaicongto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Congto> Congtos { get; } = new List<Congto>();
}