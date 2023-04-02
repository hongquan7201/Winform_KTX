using Microsoft.EntityFrameworkCore;
using ProjectQLKTX.Models;

namespace ProjectQLKTX.Models;

public class QuanlyktxContext : DbContext
{
    public QuanlyktxContext()
    {
    }

    public QuanlyktxContext(DbContextOptions<QuanlyktxContext> options)
        : base(options)
    {
    }

    public  DbSet<Congto> HoaDons { get; set; }

    public  DbSet<Chitietcongto> ChitietHoaDons { get; set; }

    public  DbSet<Chitietphieukho> Chitietphieukhos { get; set; }

  // public  DbSet<Congto> HoaDons { get; set; }

    public  DbSet<Hoadon> Hoadons { get; set; }

    public  DbSet<Hopdong> Hopdongs { get; set; }

    public  DbSet<Kho> Khos { get; set; }

    public  DbSet<Khu> Khus { get; set; }

    public  DbSet<Loaihoadon> Loaihoadons { get; set; }

    public  DbSet<Loaikhu> Loaikhus { get; set; }

    public  DbSet<Loaivatdung> Loaivatdungs { get; set; }

    public  DbSet<Loaixe> Loaixes { get; set; }

    public  DbSet<Nhanvien> Nhanviens { get; set; }

    public  DbSet<Phieugiahan> Phieugiahans { get; set; }

    public  DbSet<Phieukho> Phieukhos { get; set; }

    public  DbSet<Phong> Phongs { get; set; }

    public  DbSet<Quanhe> Quanhes { get; set; }

    public  DbSet<Role> Roles { get; set; }

    public  DbSet<Sinhvien> Sinhviens { get; set; }

    public  DbSet<Taisan> Taisans { get; set; }

    public  DbSet<Thannhan> Thannhans { get; set; }

    public  DbSet<Truong> Truongs { get; set; }

    public  DbSet<Vatdung> Vatdungs { get; set; }

    public  DbSet<Xe> Xes { get; set; }
}
