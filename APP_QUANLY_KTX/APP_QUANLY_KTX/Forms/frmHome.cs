using DevExpress.XtraBars;

namespace ProjectQLKTX

{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Home()
        {
            InitializeComponent();
        }
        private void btn_DSSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDSSinhVien frmDSSinhVien = new frmDSSinhVien();
            frmDSSinhVien.ShowDialog();
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
            frmDSKyLuat frmDSKyLuat = new frmDSKyLuat();
            frmDSKyLuat.ShowDialog();
        }
        private void btnNhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien();
            frmDSNhanVien.ShowDialog();
        }
        private void btnQLHDong_ItemClick(object sender, ItemClickEventArgs e)
        {
           frmQLHopDong frmDSHopDong = new frmQLHopDong();
            frmDSHopDong.ShowDialog();
        }
        private void btnQLHD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLHoaDon frmQLHoaDon = new frmQLHoaDon();
            frmQLHoaDon.ShowDialog();
        }
        private void btnQLDNuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLDienNuoc frmQLDienNuoc = new frmQLDienNuoc();
            frmQLDienNuoc.ShowDialog();
        }
        private void btnQLTTBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDSTrangThietBi frmDSTrangThietBi = new frmDSTrangThietBi();
            frmDSTrangThietBi.ShowDialog();
        }
        private void btnQLNXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLNhaXe frmQLNhaXe = new frmQLNhaXe();
            frmQLNhaXe.ShowDialog();
        }
        private void btnQLPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
           frmQLPhong frmQLPhong = new frmQLPhong();
            frmQLPhong.ShowDialog();
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
        private void btn_TTSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinCaNhanSV frmThongTinCaNhanSV = new frmThongTinCaNhanSV();
            frmThongTinCaNhanSV.ShowDialog();
        }
        private void btnTTNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinCaNhanNV frmThongTinCaNhanNV = new frmThongTinCaNhanNV();
            frmThongTinCaNhanNV.ShowDialog();
        }
        private void btnQLDVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLDichVu frmQLDichVu = new frmQLDichVu();
            frmQLDichVu.ShowDialog();
        }

        private void btn_BCDThu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_TKSLHDong_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_TKTTPhong_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_TKSLuong_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnDoiMK1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMK frmDoiMK = new frmDoiMK();
            frmDoiMK.ShowDialog();
        }
    }
}