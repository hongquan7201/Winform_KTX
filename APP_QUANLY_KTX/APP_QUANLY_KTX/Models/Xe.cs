using System;
using System.Collections.Generic;

namespace ProjectQLKTX.Models;

public partial class Xe
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Color { get; set; }

    public string? Code { get; set; }

    public DateTime? CreateAt { get; set; }

    public Guid? IdKhu { get; set; }
    public Guid? IdPhong { get; set; }
    public Guid? IdUser { get; set; }
    public string? NameKhu { get; set; }
    public string? NameUser { get; set;}
    public string? Address { get; set;}
    public string? Cccd { get;set; }
    public string? MaSv { get; set; }
    public string? Truong { get;set; }
    public string? Sdt { get; set;}
    public string? GioiTinh { get;set; }
    public bool? Gender { get; set; }
    public string? BirthDay { get;set; }
}
