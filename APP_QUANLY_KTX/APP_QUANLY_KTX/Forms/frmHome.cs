using DevExpress.XtraBars;
using ProjectQLKTX.Interface;

namespace ProjectQLKTX
{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly INhanVienHelper _nhanVienHelper;
        public Home(INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
        }
        private void btnDSSV_ItemClick(object sender, ItemClickEventArgs e)
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
        private void btnDSKyLuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDSKyLuat frmDSKyLuat = new frmDSKyLuat();
            frmDSKyLuat.ShowDialog();
        }
        private void btnDSNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien(_nhanVienHelper);
            frmDSNhanVien.ShowDialog();
        }
        private void btnQLHDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLHopDong frmDSHopDong = new frmQLHopDong();
            frmDSHopDong.ShowDialog();
        }
        private void btnQLHDon_ItemClick(object sender, ItemClickEventArgs e)
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
        private void btn_ThongTinSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinCaNhanSV frmThongTinCaNhanSV = new frmThongTinCaNhanSV();
            frmThongTinCaNhanSV.ShowDialog();
        }
        private void btnThongTinNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinCaNhanNV frmThongTinCaNhanNV = new frmThongTinCaNhanNV();
            frmThongTinCaNhanNV.ShowDialog();
        }
        private void btnQLDVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLDichVu frmQLDichVu = new frmQLDichVu();
            frmQLDichVu.ShowDialog();
        }
        private void btnDoiMK1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMK frmDoiMK = new frmDoiMK();
            frmDoiMK.ShowDialog();
        }
        private void btnTTSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinCaNhanSV frmThongTinCaNhanSV = new frmThongTinCaNhanSV();
            frmThongTinCaNhanSV.ShowDialog();
        }
        private void btnTTnhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinCaNhanNV frmThongTinCaNhanNV = new frmThongTinCaNhanNV();
            frmThongTinCaNhanNV.ShowDialog();
        }
        private void btnQLnhaxe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLNhaXe frmQLNhaXe = new frmQLNhaXe();
            frmQLNhaXe.ShowDialog();
        }
        private void btnDangxuat1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Home home = new Home(_nhanVienHelper);
            home.ShowDialog();

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}