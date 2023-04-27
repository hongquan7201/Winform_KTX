using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Nhanvien
{
    public Guid Id { get; set; }
    public string? GioiTinh { get;set; }
    public string Email { get; set; } = null!;
    public int STT { get; set; }
    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Cccd { get; set; }

    public string? Sdt { get; set; }

    public bool? Gender { get; set; }
    public bool? IsAdmin { get; set; }  

    public string? Birthday { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool? Status { get; set; }

    public Guid? IdRole { get; set; }

}
