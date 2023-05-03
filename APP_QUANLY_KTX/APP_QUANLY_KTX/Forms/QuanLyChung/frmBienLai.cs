using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.Files;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmBienLai : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly IBienLaiHelper _bienLaiHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly INhanVienHelper _nhanVienHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IBankingHelper _bankingHelper;
        private Bienlai _bienLai = new Bienlai();
        private string messager = "Vui Lòng Thử Lại!";
        public frmBienLai(frmLoading frmLoading, IBienLaiHelper bienLaiHelper, ISinhVienHelper sinhVienHelper, INhanVienHelper nhanVienHelper, IKhuHelper khuHelper, IPhongHelper phongHelper, IBankingHelper bankingHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _bienLaiHelper = bienLaiHelper;
            _sinhVienHelper = sinhVienHelper;
            _nhanVienHelper = nhanVienHelper;
            _khuHelper = khuHelper;
            _phongHelper = phongHelper;
            _bankingHelper = bankingHelper;
        }
        private void GetAccount(Bienlai bienlai)
        {
            txtCCCD.Text = bienlai.CCCD;
            txtEmail.Text = bienlai.EmailSV;
            txtHoTen.Text = bienlai.NameSinhVien;
            txtMaSV.Text = bienlai.MaSinhVien;
            txtSDT.Text = bienlai.SdtSV;
            txtTenNV.Text = bienlai.NameNhanVien;
            txtTienPhong.Text = bienlai.TienPhong.ToString();
            txtTienXe.Text = bienlai.TienXe.ToString();
            txtTongTien.Text = bienlai.Total.ToString();
            dtNgayBatDau.Text = bienlai.NgayBatDau.ToString();
            dtNgayDong.Text = bienlai.NgayDong.ToString();
            dtNgayHetHan.Text = bienlai.NgayHetHan.ToString();
            dtNgaySinh.Text = bienlai.NgaySinhSV;
            cbGioiTinh.Text = bienlai.GioiTinhSV;
            cbKhu.Text = bienlai.Khu;
            cbPhong.Text = bienlai.Phong;
            cbTrangThai.Text = bienlai.TrangThai;
        }
        private void btnXuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportExcel(gcDanhSach, "BienLai");
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmBienLai_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = GlobalModel.ListBienLai;
            gcDanhSach.RefreshDataSource();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListBienLai(GlobalModel.ListBienLai);
            gcDanhSach.DataSource = GlobalModel.ListBienLai;
            gcDanhSach.RefreshDataSource();
            _frmLoading.Hide();
        }
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gcDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (
                          (sender is GridControl control) &&
                          (control.MainView is GridView gridView) &&
                          (e is DXMouseEventArgs args))
                {
                    var hittest = gridView.CalcHitInfo(args.Location);
                    var s = hittest.RowHandle;
                    _bienLai = GlobalModel.ListBienLai[s];
                    GetAccount(_bienLai);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        private async void btnThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            _frmLoading.Show();
            await ThanhToan();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task ThanhToan()
        {
            Bienlai bienlai = new Bienlai();
            bienlai.Id = _bienLai.Id;
            bienlai.Status = true;
            var result = await _bienLaiHelper.EditBienLai(bienlai);
            if (result.status == 200)
            {
                Banking banking = new Banking();
                banking.amount = _bienLai.Total.ToString();
                banking.IdUser = _bienLai.IdSinhVien;
                banking.cmt = "BL-" + _bienLai.CCCD;
                banking.type = "Thanh Toán Qua Nhân Viên " + _bienLai.EmailNV;
                banking.creatAt = DateTime.Now;
                banking.IdBienLai = _bienLai.Id;
                var resultBanking = await _bankingHelper.AddBanking(banking);
                if (resultBanking.status == 200)
                {
                    await LoadListBienLai(GlobalModel.ListBienLai);
                    gcDanhSach.DataSource = GlobalModel.ListBienLai;
                    gcDanhSach.RefreshDataSource();
                    messager = "Thanh Toán Thành Công!";
                }
            }
            else
            {
                messager = result.message;
            }

        }
        private async Task LoadListBienLai(List<Bienlai> listBienLai)
        {
            var bienLais = await _bienLaiHelper.GetListBienLai();
            if (bienLais.status == 200)
            {
                int i = 1;
                listBienLai.Clear();
                foreach (var item in bienLais.data)
                {
                    Bienlai bienlai = new Bienlai();
                    bienlai.Id = item.Id;
                    bienlai.NgayBatDau = item.NgayBatDau;
                    bienlai.NgayDong = item.NgayDong;
                    bienlai.NgayHetHan = item.NgayHetHan;
                    bienlai.TienPhong = item.TienPhong;
                    bienlai.TienXe = item.TienXe;
                    bienlai.Total = item.TienPhong + item.TienXe;
                    bienlai.Status = item.Status;
                    if (bienlai.Status == true)
                    {
                        bienlai.TrangThai = "Đã Thanh Toán";
                    }
                    else
                    {
                        bienlai.TrangThai = "Chưa Thanh Toán";
                    }
                    bienlai.STT = i;
                    bienlai.IdNhanVien = item.IdNhanVien;
                    bienlai.IdSinhVien = item.IdSinhVien;
                    if (bienlai.IdSinhVien != null)
                    {
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(bienlai.IdSinhVien);
                        if (sinhvien.status == 200)
                        {
                            bienlai.NameSinhVien = sinhvien.data.FirstOrDefault().Name;
                            bienlai.CCCD = sinhvien.data.FirstOrDefault().Cccd;
                            bienlai.EmailSV = sinhvien.data.FirstOrDefault().Email;
                            bienlai.NgaySinhSV = sinhvien.data.FirstOrDefault().BirthDay;
                            bienlai.MaSinhVien = sinhvien.data.FirstOrDefault().MaSv;
                            if (sinhvien.data.FirstOrDefault().Gender == true)
                            {
                                bienlai.GioiTinhSV = "Nam";
                            }
                            else
                            {
                                bienlai.GioiTinhSV = "Nữ";
                            }
                            if (sinhvien.data.FirstOrDefault().IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong);
                                if (phong.status == 200)
                                {
                                    bienlai.Phong = phong.data.FirstOrDefault().Name;
                                    if (phong.data.FirstOrDefault().IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu);
                                        if (khu.status == 200)
                                        {
                                            bienlai.Khu = khu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (item.IdNhanVien != null)
                    {
                        var nhanvien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien);
                        if (nhanvien.status == 200)
                        {
                            bienlai.NameNhanVien = nhanvien.data.FirstOrDefault().Name;
                            bienlai.EmailNV = nhanvien.data.FirstOrDefault().Email;
                        }
                    }
                    listBienLai.Add(bienlai);
                    i++;
                }
            }
        }

        private void cbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPhong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                if (cbKhu.Text == item.NameKhu && item.QuantityPeople < 8)
                {
                    cbPhong.Properties.Items.Add(item.Name);
                }
            }
        }
    }
}