using DevExpress.Mvvm.Native;
using DevExpress.XtraBars;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly INhanVienHelper _nhanVienHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IThanNhanHelper _thanNhanHelper;
        private readonly IQuanHeHelper _quanHeHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        private readonly IHopDongHelper _hopDongHelper;
        private readonly IXeHelper _xeHelper;
        private readonly ITaiSanHelper _taiSanHelper;
        private readonly IVatDungHelper _vatDungHelper;
        private readonly IChietTietPhieuKhoHelper _chietTietPhieuKhoHelper;
        private readonly IBankingHelper _bankingHelper;
        private readonly frmDangNhap _frmDangNhap;
        private readonly frmLoading _frmLoading;
        private readonly frmQLiXe _frmQLiXe;
        public Home(INhanVienHelper nhanVienHelper, ISinhVienHelper sinhVienHelper, IThanNhanHelper thanNhanHelper, IQuanHeHelper quanHeHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper, IHopDongHelper hopDongHelper, IXeHelper xeHelper, ITaiSanHelper taiSanHelper, IVatDungHelper vatDungHelper, IChietTietPhieuKhoHelper chietTietPhieuKhoHelper, frmDangNhap frmDangNhap, frmLoading frmLoading, frmQLiXe frmQLiXe, IBankingHelper bankingHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
            _sinhVienHelper = sinhVienHelper;
            _thanNhanHelper = thanNhanHelper;
            _quanHeHelper = quanHeHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
            _hopDongHelper = hopDongHelper;
            _xeHelper = xeHelper;
            _taiSanHelper = taiSanHelper;
            _vatDungHelper = vatDungHelper;
            _chietTietPhieuKhoHelper = chietTietPhieuKhoHelper;
            _frmDangNhap = frmDangNhap;
            _frmLoading = frmLoading;
            _frmQLiXe = frmQLiXe;
            _bankingHelper = bankingHelper;
        }
        private void btnDoiMK_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMK frmDoiMK = new frmDoiMK();
            frmDoiMK.ShowDialog();
        }
        private void btnDangKyPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDKPhong frmDangKyPhong = new frmDKPhong(_sinhVienHelper, _phongHelper, _khuHelper, _truongHelper, _hopDongHelper, _xeHelper);
            frmDangKyPhong.ShowDialog();
        }
        private void btnChuyenPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChuyenPhong frmChuyenPhong = new frmChuyenPhong();
            frmChuyenPhong.ShowDialog();
        }
        private void btnTraPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTraPhong frmTraPhong = new frmTraPhong();
            frmTraPhong.ShowDialog();
        }
        private async void btnThongTinSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadSinhVien(GlobalModel.ListSinhVien);
            _frmLoading.Hide();
            frmThongTinSV frmThongTinCaNhanSV = new frmThongTinSV(_sinhVienHelper, _thanNhanHelper, _quanHeHelper, _phongHelper, _khuHelper, _truongHelper);
            frmThongTinCaNhanSV.ShowDialog();
        }
        private async void btnDSNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListNhanVien(GlobalModel.ListNhanVien);
            _frmLoading.Hide();
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien(_nhanVienHelper);
            frmDSNhanVien.ShowDialog();
        }
        private async void btnTTNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmThongTinNV frmThongTinCaNhanNV = new frmThongTinNV();
            frmThongTinCaNhanNV.ShowDialog();
        }
        private async void btnQLiHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListHopDong(GlobalModel.ListHopDong);
            _frmLoading.Hide();
            frmQLiHopDong frmQLiHopDong = new frmQLiHopDong(_hopDongHelper, _nhanVienHelper, _sinhVienHelper, _phongHelper, _frmLoading);
            frmQLiHopDong.ShowDialog();
        }
        private void btnQLiDienNuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLiDienNuoc frmQLDienNuoc = new frmQLiDienNuoc();
            frmQLDienNuoc.ShowDialog();
        }
        private async void btnQLiXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListXe(GlobalModel._listXe);
            _frmLoading.Hide();
            _frmQLiXe.ShowDialog();
        }
        private void btnQLiPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLiPhong frmQLiPhong = new frmQLiPhong();
            frmQLiPhong.ShowDialog();
        }
        private void btnThanhToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBienLai frmBienLai = new frmBienLai();
            frmBienLai.ShowDialog();
        }
        private void btnQLiHoaDon_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmQLiHoaDon frmQLHoaDon = new frmQLiHoaDon();
            frmQLHoaDon.ShowDialog();
        }

        private async void btnQLiKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListKho(GlobalModel.ListChiTietPhieuKho);
            _frmLoading.Hide();
            frmQLiKho frmQLiKho = new frmQLiKho(_chietTietPhieuKhoHelper, _vatDungHelper, _nhanVienHelper);
            frmQLiKho.ShowDialog();
        }

        private async void btnQLiTaiSan_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListTaiSan(GlobalModel.ListTaiSan);
            _frmLoading.Hide();
            frmQLiTaiSan frmQLiTaiSan = new frmQLiTaiSan(_taiSanHelper, _phongHelper, _vatDungHelper);
            frmQLiTaiSan.ShowDialog();
        }

        private void btnBCDThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBaoCaoDoanhThu frmBaoCaoDoanhThu = new frmBaoCaoDoanhThu();
            frmBaoCaoDoanhThu.ShowDialog();
        }

        private void btnThongKeSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongKeSinhVien frmThongKeSinhVien = new frmThongKeSinhVien();
            frmThongKeSinhVien.ShowDialog();
        }

        private void btnDSTruong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDSTruong frmDSTruong = new frmDSTruong(_truongHelper);
            frmDSTruong.ShowDialog();
        }

        private void btnDangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            GlobalModel.IsLogin = false;
            DANHMUC.Visible = false;
            QUANLY.Visible = false;
            _frmDangNhap.ShowDialog();
            Thread thread = new Thread(check);
            thread.IsBackground = true;
            thread.Start();
        }
        private void check()
        {
            while (true)
            {
                if (GlobalModel.Nhanvien != null && GlobalModel.IsLogin == true)
                {
                    DANHMUC.Visible = true;
                    QUANLY.Visible = true;
                    if (GlobalModel.Nhanvien.IsAdmin == true)
                    {
                        btnDSNV.Enabled = true;
                        btnDSTruong.Enabled = true;
                    }
                    else
                    {
                        btnDSNV.Enabled = false;
                        btnDSTruong.Enabled = false;
                    }
                    btnDangxuat.Caption = "Đăng Xuất";
                    break;
                }
            }
        }
        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            btnDangxuat.Caption = "Đăng Nhập";
            DANHMUC.Visible = false;
            QUANLY.Visible = false;
        }
        private async Task LoadListXe(List<Xe> listXe)
        {
            var list = await _xeHelper.GetListXe();
            if (list.status == 200)
            {
                listXe.Clear();
                int i = 1;
                foreach (var item in list.data)
                {
                    if (item.IdUser != null)
                    {
                        var user = await _sinhVienHelper.GetSinhVienById(item.IdUser);
                        if (user.status == 200)
                        {
                            item.NameUser = user.data.FirstOrDefault().Name;
                            item.Address = user.data.FirstOrDefault().Address;
                            item.Cccd = user.data.FirstOrDefault().Cccd;
                            item.Sdt = user.data.FirstOrDefault().Sdt;
                            item.Gender = user.data.FirstOrDefault().Gender;
                            if (item.Gender == true)
                            {
                                item.GioiTinh = "Nam";
                            }
                            else
                            {
                                item.GioiTinh = "Nữ";
                            }
                            item.BirthDay = user.data.FirstOrDefault().BirthDay;
                            item.IdPhong = user.data.FirstOrDefault().IdPhong;
                            if (item.IdPhong != null)
                            {
                                var resultPhong = await _phongHelper.GetPhong(item.IdPhong);
                                if (resultPhong.status == 200)
                                {
                                    item.IdKhu = resultPhong.data.FirstOrDefault().IdKhu;
                                    if (item.IdKhu != null)
                                    {
                                        var resultKhu = await _khuHelper.GetKhu(item.IdKhu);
                                        if (resultKhu.status == 200)
                                        {
                                            item.NameKhu = resultKhu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                            if (user.data.FirstOrDefault().IdTruong != null)
                            {
                                var resultTruong = await _truongHelper.GetTruong(user.data.FirstOrDefault().IdTruong);
                                if (resultTruong.status == 200)
                                {
                                    item.Truong = resultTruong.data.FirstOrDefault().Name;
                                }
                            }
                        }
                        item.STT = i;
                        listXe.Add(item);
                        i++;
                    }
                }
            }
        }
        private async Task LoadListKho(List<Chitietphieukho> chitietphieukhos)
        {
            var resultChiTietPhieuKho = await _chietTietPhieuKhoHelper.GetListChietTietPhieuKho();
            if (resultChiTietPhieuKho.status == 200)
            {
                int i = 1;
                chitietphieukhos.Clear();
                foreach (var item in resultChiTietPhieuKho.data)
                {
                    if (item.IdVatDung != null)
                    {
                        var resultVatDung = await _vatDungHelper.GetVatDung(item.IdVatDung);
                        if (resultVatDung.status == 200)
                        {
                            item.NameVatDung = resultVatDung.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.IdNhanVien != null)
                    {
                        var resultNhanVien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien);
                        if (resultNhanVien.status == 200)
                        {
                            item.NameNhanVien = resultNhanVien.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.Status == true)
                    {
                        item.TinhTrang = "Còn";
                    }
                    else
                    {
                        item.TinhTrang = "Hư";
                    }
                    item.STT = i;
                    chitietphieukhos.Add(item);
                    i++;
                }
            }

        }
        private async Task LoadListTaiSan(List<Taisan> listTaiSan)
        {
            var taiSans = await _taiSanHelper.GetListTaiSan();
            if (taiSans.status == 200)
            {
                int i = 1;
                listTaiSan.Clear();
                foreach (var item in taiSans.data)
                {
                    if (item.IdVatDung != null)
                    {
                        var vatDungs = await _vatDungHelper.GetVatDung(item.IdVatDung);
                        if (vatDungs.status == 200)
                        {
                            item.NameVatDung = vatDungs.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.IdPhong != null)
                    {
                        var phongs = await _phongHelper.GetPhong(item.IdPhong);
                        if (phongs.status == 200)
                        {
                            item.NamePhong = phongs.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.Status == true)
                    {
                        item.TinhTrang = "Đang Sử Dụng";
                    }
                    else if (item.Status == false && item.Quantity > 0)
                    {
                        item.TinhTrang = "Hư";
                    }
                    else
                    {
                        item.TinhTrang = "Chưa Có";
                    }
                    item.STT = i;
                    listTaiSan.Add(item);
                    i++;
                }

                var listPhong = await _phongHelper.GetListPhong();
                if (listPhong.status == 200)
                {
                    GlobalModel.ListPhong.Clear();
                    foreach (var item in listPhong.data)
                    {
                        GlobalModel.ListPhong.Add(item);
                    }
                }
                var listVatDung = await _vatDungHelper.GetListVatDung();
                if (listVatDung.status == 200)
                {
                    GlobalModel.ListVatDung.Clear();
                    foreach (var item in listVatDung.data)
                    {
                        GlobalModel.ListVatDung.Add(item);
                    }
                }
            }
        }
        private async Task LoadListNhanVien(List<Nhanvien> listNhanVien)
        {
            var result = await _nhanVienHelper.GetListNhanVien();
            try
            {
                if (result != null && result.status == 200)
                {

                    int i = 1;
                    listNhanVien.Clear();
                    var list = result.data;
                    foreach (var item in list)
                    {
                        item.STT = i;
                        if (item.Gender == true)
                        {

                            item.GioiTinh = "Nam";
                        }
                        else
                        {
                            item.GioiTinh = "Nữ";
                        }
                        listNhanVien.Add(item);
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show(result.message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + result);
                Log.Error(ex, ex.Message);
            }
        }
        private async Task LoadSinhVien(List<Sinhvien> listAccount)
        {
            var listSinhVien = await _sinhVienHelper.GetListSinhVien();
            try
            {
                if (listSinhVien != null && listSinhVien.status == 200)
                {
                    int i = 1;
                    listAccount.Clear();
                    var lstData = listSinhVien.data;
                    foreach (var item in lstData)
                    {
                        if (item.idThanNhan != null)
                        {
                            var nhanNhan = await _thanNhanHelper.GetThanNhan(item.idThanNhan);
                            if (nhanNhan.status == 200)
                            {
                                item.TenThanNhan = nhanNhan.data.FirstOrDefault().Name;
                                item.SDTThanNhan = nhanNhan.data.FirstOrDefault().Sdt;
                                item.AddressThanNha = nhanNhan.data.FirstOrDefault().Address;
                                if (nhanNhan.data.FirstOrDefault().Gender == true)
                                {

                                    item.GioiTinhThanNhan = "Nam";
                                }
                                else
                                {
                                    item.GioiTinhThanNhan = "Nữ";
                                }
                                if (nhanNhan.data.FirstOrDefault().IdQuanHe != null)
                                {
                                    var quanHe = await _quanHeHelper.GetQuanHe(nhanNhan.data.FirstOrDefault().IdQuanHe);
                                    if (quanHe.status == 200)
                                    {
                                        item.QuanHe = quanHe.data.FirstOrDefault().Name;
                                    }
                                }

                            }

                        }
                        if (item.IdTruong != null)
                        {
                            var truong = await _truongHelper.GetTruong(item.IdTruong);
                            if (truong.status == 200)
                            {
                                item.Truong = truong.data.FirstOrDefault().Name;
                            }

                        }
                        if (item.IdPhong != null)
                        {
                            var phong = await _phongHelper.GetPhong(item.IdPhong);
                            if (phong.status == 200)
                            {
                                item.Phong = phong.data.FirstOrDefault().Name;
                                if (phong.data.FirstOrDefault().IdKhu != null)
                                {
                                    var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu);
                                    if (khu.status == 200)
                                    {
                                        item.Khu = khu.data.FirstOrDefault().Name;
                                    }

                                }
                            }
                        }

                        item.STT = i;
                        if (item.Gender == true)
                        {

                            item.GioiTinh = "Nam";
                        }
                        else
                        {
                            item.GioiTinh = "Nữ";
                        }
                        listAccount.Add(item);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + listSinhVien);
                Log.Error(ex, ex.Message);
            }
        }
        private async Task LoadListDienNuoc(List<Sinhvien> listAccount)
        {
            var listSinhVien = await _sinhVienHelper.GetListSinhVien();
            try
            {

            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async Task LoadListHopDong(List<Hopdong> listHopDong)
        {
            var resultListHopDong = await _hopDongHelper.GetListHopDong();
            if (resultListHopDong.status == 200)
            {
                int i = 1;
                listHopDong.Clear();
                foreach (var item in resultListHopDong.data)
                {
                    if (item.IdNhanVien != null)
                    {
                        var resultNhanVien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien);
                        if (resultNhanVien.status == 200)
                        {
                            item.NameNhanVien = resultNhanVien.data.FirstOrDefault().Name;
                            item.EmailNhanVien = resultNhanVien.data.FirstOrDefault().Email;
                        }
                    }
                    if (item.IdSinhVien != null)
                    {
                        var resultSinhVien = await _sinhVienHelper.GetSinhVienById(item.IdSinhVien);
                        if (resultSinhVien.status == 200)
                        {
                            item.MaSinhVien = resultSinhVien.data.FirstOrDefault().MaSv;
                            item.NameSinhVien = resultSinhVien.data.FirstOrDefault().Name;
                            item.EmailSinhVien = resultSinhVien.data.FirstOrDefault().Email;
                        }
                    }
                    if (item.IdPhong != null)
                    {
                        var resultPhong = await _phongHelper.GetPhong(item.IdPhong);
                        if (resultPhong.status == 200)
                        {
                            item.Phong = resultPhong.data.FirstOrDefault().Name;
                        }
                    }
                    item.STT = i;
                    listHopDong.Add(item);
                    i++;
                }
            }
            var listPhong = await _phongHelper.GetListPhong();
            if (listPhong.status == 200)
            {
                GlobalModel.ListPhong.Clear();
                foreach (var item in listPhong.data)
                {
                    GlobalModel.ListPhong.Add(item);
                }
            }
        }

        private async void btnLichSuGiaoDich_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListBanking(GlobalModel.ListBanking);
            _frmLoading.Hide();
            frmLichSuGiaoDich frmLichSuGiaoDich = new frmLichSuGiaoDich(_bankingHelper,_sinhVienHelper,_khuHelper,_phongHelper,_frmLoading);
            frmLichSuGiaoDich.ShowDialog();
        }
        private async Task LoadListBanking(List<Banking> listBanking)
        {
            var lstBanking = await _bankingHelper.GetListBanking();
            if (lstBanking.status == 200)
            {
                listBanking.Clear();
                int i = 1;
                foreach (var item in lstBanking.data)
                {
                    Banking banking = new Banking();
                    banking.type = item.type;
                    banking.idSinhVien = item.idSinhVien;
                    banking.amount = item.amount;
                    banking.code = item.code;
                    banking.Id = item.Id;
                    banking.cmt = item.cmt;
                    banking.creatAt = item.creatAt;
                    banking.STT = i;
                    if (banking.idSinhVien != null)
                    {
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(banking.idSinhVien);
                        if(sinhvien.status == 200)
                        {
                            banking.Name = sinhvien.data.FirstOrDefault().Name;
                            banking.Email = sinhvien.data.FirstOrDefault().Email;
                            banking.Sdt = sinhvien.data.FirstOrDefault().Sdt;
                            if (sinhvien.data.FirstOrDefault().IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong);
                                if(phong.status == 200)
                                {
                                    banking.NamePhong = phong.data.FirstOrDefault().Name;
                                    if (phong.data.FirstOrDefault().IdKhu!= null)
                                    {
                                        var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu);
                                        if(khu.status == 200)
                                        {
                                            banking.NameKhu = khu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                        }
                         
                    }
                    listBanking.Add(banking);
                    i++;
                }
            }

        }
    }
}