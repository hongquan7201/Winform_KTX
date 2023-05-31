using Newtonsoft.Json;

namespace ProjectQLKTX.Models;

public partial class Sinhvien
{
    public Guid? Id { get; set; }
    public string? Email { get; set; }
    public string? GioiTinh { get; set; }
    public int? STT { get;set; }
    public string MaSv { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Cccd { get; set; }

    public string? Sdt { get; set; }

    public bool? Gender { get; set; }

    public Guid? IdPhong { get; set; }

    public Guid? IdTruong { get; set; }
    public Guid? idXe { get; set; }
    public Guid? idThanNhan { get; set; }

    public DateTime BirthDay { get; set; }

    public bool? Status { get; set; }

    public string? Code { get; set; }

    public DateTime CreateAt { get; set; }
    /// <summary>
    /// //////////////////
    /// </summary>
    public string? TenThanNhan { get;set; }
    public string? GioiTinhThanNhan { get; set; }
    public string? AddressThanNha { get; set; }
    public string? SDTThanNhan { get; set; }
    public string? QuanHe { get;set; }
/// <summary>
/// ////////
/// </summary>
    public string? Truong { get; set; }
    public string? Phong { get; set; }
    public string? Khu { get;set; }
}
