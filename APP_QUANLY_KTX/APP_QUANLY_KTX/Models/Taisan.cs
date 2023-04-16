using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Taisan
{
    public Guid Id { get; set; }

    public int? Quantity { get; set; }

    public bool? Status { get; set; }

    public Guid? IdVatDung { get; set; }

    public Guid IdPhong { get; set; }

    public virtual Phong IdPhongNavigation { get; set; } = null!;

    public virtual Vatdung? IdVatDungNavigation { get; set; }
}
