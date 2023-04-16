﻿using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Nhanvien> Nhanviens { get; } = new List<Nhanvien>();
}
