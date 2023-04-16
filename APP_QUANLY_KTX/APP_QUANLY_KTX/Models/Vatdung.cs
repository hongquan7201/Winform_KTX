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

    public virtual ICollection<Chitietphieukho> Chitietphieukhos { get; } = new List<Chitietphieukho>();

    public virtual Kho? IdKhoNavigation { get; set; }

    public virtual Loaivatdung? IdLoaiVatDungNavigation { get; set; }

    public virtual ICollection<Taisan> Taisans { get; } = new List<Taisan>();
}
