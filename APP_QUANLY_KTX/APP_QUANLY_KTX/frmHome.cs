using DevExpress.XtraBars;

namespace ProjectQLKTX

{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_TTCNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinCaNhan frmThongTinCaNhan = new frmThongTinCaNhan();
            frmThongTinCaNhan.ShowDialog();
        }

        private void btn_Dangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDangNhap frmDangNhap = new frmDangNhap();
            //frmDangNhap.Show();
            //this.Hide();
        }

        private void btn_DSSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDanhSachSinhVien frmDanhSachSinhVien = new frmDanhSachSinhVien();
            frmDanhSachSinhVien.ShowDialog();
        }

        private void btnDSSVCPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSinhVienCungPhong frmSinhVienCungPhong = new frmSinhVienCungPhong();
            frmSinhVienCungPhong.ShowDialog();
        }

        private void btnDSThanNhanSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThanNhanSV frmThanNhanSV = new frmThanNhanSV();
            frmThanNhanSV.ShowDialog();
        }

        private void btnDanhsachkyluat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDanhSachKyLuat frmDanhSachKyLuat = new frmDanhSachKyLuat();
            frmDanhSachKyLuat.ShowDialog();
        }
        private void btnNhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDanhSachNhanVien frmDanhSachNhanVien = new frmDanhSachNhanVien();
            frmDanhSachNhanVien.ShowDialog();
        }
        private void btnQLHDong_ItemClick(object sender, ItemClickEventArgs e)
        {
           DanhSachHopDong danhSachHopDong = new DanhSachHopDong();
            danhSachHopDong.ShowDialog();
        }
        private void btnQLHD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyHoaDon frmQuanLyHoaDon = new frmQuanLyHoaDon();
            frmQuanLyHoaDon.ShowDialog();
        }

        private void btnQLDNuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyDienNuoc frmQuanLyDienNuoc = new frmQuanLyDienNuoc();
            frmQuanLyDienNuoc.ShowDialog();
        }

        private void btnQLTTBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDanhSachTrangThietBi frmDanhSachTrangThietBi = new frmDanhSachTrangThietBi();
            frmDanhSachTrangThietBi.ShowDialog();
        }

        private void btnQLNXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyNhaXe frmQuanLyNhaXe = new frmQuanLyNhaXe();
            frmQuanLyNhaXe.ShowDialog();
        }

        private void btnQLPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
           frmQuanLyPhong frmQuanLyPhong = new frmQuanLyPhong();
            frmQuanLyPhong.ShowDialog();
        }

        private void btnDangkyphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangKyPhong frmDangKyPhong = new frmDangKyPhong();
            frmDangKyPhong.ShowDialog();
        }

        private void btnGiahan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmGiaHan frmGiaHan = new frmGiaHan();
            frmGiaHan.ShowDialog();
        }

        private void btnChuyenphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChuyenPhong frmChuyenPhong = new frmChuyenPhong();
            frmChuyenPhong.ShowDialog();
        }

        private void btnTraPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTraPhong frmTraPhong = new frmTraPhong();
            frmTraPhong.ShowDialog();
        }
    }
}