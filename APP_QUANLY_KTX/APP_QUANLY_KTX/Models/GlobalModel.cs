namespace ProjectQLKTX.Models
{
    public  class GlobalModel
    {
        public static bool IsLogin = false;
        public static Sinhvien SinhVien = new Sinhvien();
        public static Nhanvien Nhanvien  = new Nhanvien();
        public static bool IsAddXe = false;
        public static List<Xe> _listXe = new List<Xe>();
        public static List<Chitietphieukho> ListChiTietPhieuKho = new List<Chitietphieukho>();
        public static List<Taisan> ListTaiSan = new List<Taisan>();
        public static List<Vatdung> ListVatDung = new List<Vatdung>();
        public static List<Phong> ListPhong = new List<Phong>();
        public static List<Nhanvien> ListNhanVien = new List<Nhanvien>();
        public static List<Sinhvien> ListSinhVien = new List<Sinhvien>();
        public static List<Hopdong> ListHopDong = new List<Hopdong>();
        public static List<Banking> ListBanking = new List<Banking>();
        public static List<Chitietcongto> ListChitietcongto = new List<Chitietcongto>();
        public static List<Truong> ListTruong = new List<Truong>();
    }
}
