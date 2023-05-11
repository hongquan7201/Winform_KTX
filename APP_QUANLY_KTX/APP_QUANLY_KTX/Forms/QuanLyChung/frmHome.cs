using DevExpress.XtraBars;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Files;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IThongKeHelper _thongKeHelper;
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
        private readonly IChiTietCongToHelper _chiTietCongToHelper;
        private readonly ICongToHelper _congToHelper;
        private readonly IBienLaiHelper _bienLaiHelper;
        private readonly IHoaDonHelper _hoaDonHelper;
        private readonly frmDangNhap _frmDangNhap;
        private readonly frmLoading _frmLoading;
        private readonly frmQLiXe _frmQLiXe;
        public Home(INhanVienHelper nhanVienHelper, ISinhVienHelper sinhVienHelper, IThanNhanHelper thanNhanHelper, IQuanHeHelper quanHeHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper, IHopDongHelper hopDongHelper, IXeHelper xeHelper, ITaiSanHelper taiSanHelper, IVatDungHelper vatDungHelper, IChietTietPhieuKhoHelper chietTietPhieuKhoHelper, frmDangNhap frmDangNhap, frmLoading frmLoading, frmQLiXe frmQLiXe, IBankingHelper bankingHelper, IChiTietCongToHelper chiTietCongToHelper, ICongToHelper congToHelper, IBienLaiHelper bienLaiHelper, IHoaDonHelper hoaDonHelper, IThongKeHelper thongKeHelper)
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
            _chiTietCongToHelper = chiTietCongToHelper;
            _congToHelper = congToHelper;
            _bienLaiHelper = bienLaiHelper;
            _hoaDonHelper = hoaDonHelper;
            _thongKeHelper = thongKeHelper;
        }
        private void btnDoiMK_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMK frmDoiMK = new frmDoiMK(_frmLoading, _nhanVienHelper);
            frmDoiMK.ShowDialog();
        }
        private void btnDangKyPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDKPhong frmDangKyPhong = new frmDKPhong(_sinhVienHelper, _phongHelper, _khuHelper, _truongHelper, _hopDongHelper, _xeHelper, _frmLoading);
            frmDangKyPhong.ShowDialog();
        }
        private async void btnChuyenPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListPhong(GlobalModel.ListPhong);
            _frmLoading.Hide();
            frmChuyenPhong frmChuyenPhong = new frmChuyenPhong(_frmLoading, _sinhVienHelper, _truongHelper, _phongHelper, _khuHelper);
            frmChuyenPhong.ShowDialog();
        }
        private void btnTraPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTraPhong frmTraPhong = new frmTraPhong(_frmLoading, _sinhVienHelper, _phongHelper, _khuHelper, _truongHelper);
            frmTraPhong.ShowDialog();
        }
        private async void btnThongTinSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadSinhVien(GlobalModel.ListSinhVien);
            await LoadListPhong(GlobalModel.ListPhong);
            await LoadListTruong(GlobalModel.ListTruong);
            await LoadListQuanHe(GlobalModel.ListQuanhe);
            _frmLoading.Hide();
            frmThongTinSV frmThongTinCaNhanSV = new frmThongTinSV(_sinhVienHelper, _thanNhanHelper, _quanHeHelper, _phongHelper, _khuHelper, _truongHelper, _frmLoading);
            frmThongTinCaNhanSV.ShowDialog();
        }
        private async void btnDSNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListNhanVien(GlobalModel.ListNhanVien);
            _frmLoading.Hide();
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien(_nhanVienHelper, _frmLoading);
            frmDSNhanVien.ShowDialog();
        }
        private async void btnTTNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmThongTinNV frmThongTinCaNhanNV = new frmThongTinNV(_frmLoading, _nhanVienHelper);
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
        private async void btnQLiDienNuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListDienNuoc(GlobalModel.ListChitietcongto);
            await LoadListPhong(GlobalModel.ListPhong);
            _frmLoading.Hide();
            frmQLiDienNuoc frmQLDienNuoc = new frmQLiDienNuoc(_frmLoading, _chiTietCongToHelper, _khuHelper, _phongHelper);
            frmQLDienNuoc.ShowDialog();
        }
        private async void btnQLiXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListXe(GlobalModel.ListXe);
            _frmLoading.Hide();
            _frmQLiXe.ShowDialog();
        }
        private async void btnQLiPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListPhong(GlobalModel.ListPhong);
            _frmLoading.Hide();
            frmQLiPhong frmQLiPhong = new frmQLiPhong(_frmLoading, _phongHelper, _khuHelper);
            frmQLiPhong.ShowDialog();
        }
        private async void btnThanhToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListBienLai(GlobalModel.ListBienLai);
            _frmLoading.Hide();
            frmBienLai frmBienLai = new frmBienLai(_frmLoading, _bienLaiHelper, _sinhVienHelper, _nhanVienHelper, _khuHelper, _phongHelper, _bankingHelper);
            frmBienLai.ShowDialog();
        }
        private async void btnQLiHoaDon_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListHoaDon(GlobalModel.ListHoaDon);
            await LoadListPhong(GlobalModel.ListPhong);
            _frmLoading.Hide();
            frmQLiHoaDon frmQLHoaDon = new frmQLiHoaDon(_hoaDonHelper, _frmLoading, _phongHelper, _khuHelper, _nhanVienHelper, _sinhVienHelper, _chiTietCongToHelper);
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

        private async void btnBCDThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBaoCaoDoanhThu frmBaoCaoDoanhThu = new frmBaoCaoDoanhThu(_thongKeHelper);
            frmBaoCaoDoanhThu.ShowDialog();
        }

        private async void btnThongKeSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongKeSinhVien frmThongKeSinhVien = new frmThongKeSinhVien(_thongKeHelper);
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
            btnDoiMK.Enabled = false;
            BAOCAOTHONGKE.Visible = false;
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
                    btnDoiMK.Enabled = true;
                    BAOCAOTHONGKE.Visible = true;
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
            btnDoiMK.Enabled = false;
            BAOCAOTHONGKE.Visible = false;
        }
        private async Task LoadListXe(List<Xe> listXe)
        {
            var list = await _xeHelper.GetListXe(Constant.Token);
            if (list.status == 200)
            {
                listXe.Clear();
                int i = 1;
                foreach (var item in list.data)
                {
                    if (item.IdUser != null)
                    {
                        var user = await _sinhVienHelper.GetSinhVienById(item.IdUser, Constant.Token);
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
                                var resultPhong = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
                                if (resultPhong.status == 200)
                                {
                                    item.IdKhu = resultPhong.data.FirstOrDefault().IdKhu;
                                    if (item.IdKhu != null)
                                    {
                                        var resultKhu = await _khuHelper.GetKhu(item.IdKhu, Constant.Token);
                                        if (resultKhu.status == 200)
                                        {
                                            item.NameKhu = resultKhu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                            if (user.data.FirstOrDefault().IdTruong != null)
                            {
                                var resultTruong = await _truongHelper.GetTruong(user.data.FirstOrDefault().IdTruong, Constant.Token);
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
            var resultChiTietPhieuKho = await _chietTietPhieuKhoHelper.GetListChietTietPhieuKho(Constant.Token);
            if (resultChiTietPhieuKho.status == 200)
            {
                int i = 1;
                chitietphieukhos.Clear();
                foreach (var item in resultChiTietPhieuKho.data)
                {
                    if (item.IdVatDung != null)
                    {
                        var resultVatDung = await _vatDungHelper.GetVatDung(item.IdVatDung, Constant.Token);
                        if (resultVatDung.status == 200)
                        {
                            item.NameVatDung = resultVatDung.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.IdNhanVien != null)
                    {
                        var resultNhanVien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien, Constant.Token);
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
            var taiSans = await _taiSanHelper.GetListTaiSan(Constant.Token);
            if (taiSans.status == 200)
            {
                int i = 1;
                listTaiSan.Clear();
                foreach (var item in taiSans.data)
                {
                    if (item.IdVatDung != null)
                    {
                        var vatDungs = await _vatDungHelper.GetVatDung(item.IdVatDung, Constant.Token);
                        if (vatDungs.status == 200)
                        {
                            item.NameVatDung = vatDungs.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.IdPhong != null)
                    {
                        var phongs = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
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

                var listPhong = await _phongHelper.GetListPhong(Constant.Token);
                if (listPhong.status == 200)
                {
                    GlobalModel.ListPhong.Clear();
                    foreach (var item in listPhong.data)
                    {
                        GlobalModel.ListPhong.Add(item);
                    }
                }
                var listVatDung = await _vatDungHelper.GetListVatDung(Constant.Token);
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
            var result = await _nhanVienHelper.GetListNhanVien(Constant.Token);
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
            var listSinhVien = await _sinhVienHelper.GetListSinhVien(Constant.Token);
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
                            var nhanNhan = await _thanNhanHelper.GetThanNhan(item.idThanNhan, Constant.Token);
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
                                    var quanHe = await _quanHeHelper.GetQuanHe(nhanNhan.data.FirstOrDefault().IdQuanHe, Constant.Token);
                                    if (quanHe.status == 200)
                                    {
                                        item.QuanHe = quanHe.data.FirstOrDefault().Name;
                                    }
                                }

                            }

                        }
                        if (item.IdTruong != null)
                        {
                            var truong = await _truongHelper.GetTruong(item.IdTruong, Constant.Token);
                            if (truong.status == 200)
                            {
                                item.Truong = truong.data.FirstOrDefault().Name;
                            }

                        }
                        if (item.IdPhong != null)
                        {
                            var phong = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
                            if (phong.status == 200)
                            {
                                item.Phong = phong.data.FirstOrDefault().Name;
                                if (phong.data.FirstOrDefault().IdKhu != null)
                                {
                                    var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu, Constant.Token);
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
        private async Task LoadListDienNuoc(List<Chitietcongto> listChiTietCongTo)
        {
            var chiTietCongTos = await _chiTietCongToHelper.GetListChiTietCongTo(Constant.Token);
            try
            {
                if (chiTietCongTos.status == 200)
                {
                    listChiTietCongTo.Clear();
                    int i = 1;
                    foreach (var item in chiTietCongTos.data)
                    {
                        Chitietcongto chitietcongto = new Chitietcongto();
                        chitietcongto.ChiSoDienCuoiThang = item.ChiSoDienCuoiThang;
                        chitietcongto.ChiSoDienDauThang = item.ChiSoDienDauThang;
                        chitietcongto.ChiSoNuocCuoiThang = item.ChiSoNuocCuoiThang;
                        chitietcongto.ChiSoNuocDauThang = item.ChiSoNuocDauThang;
                        chitietcongto.SoDienTieuThu = (chitietcongto.ChiSoDienCuoiThang - chitietcongto.ChiSoDienDauThang);
                        chitietcongto.SoNuocTieuThu = (chitietcongto.ChiSoNuocCuoiThang - chitietcongto.ChiSoNuocDauThang);
                        chitietcongto.CreateAt = item.CreateAt;
                        chitietcongto.Id = item.Id;
                        chitietcongto.TienDien = item.TienDien;
                        chitietcongto.TienNuoc = item.TienNuoc;
                        chitietcongto.Total = item.Total;
                        chitietcongto.IdPhong = item.IdPhong;
                        if (chitietcongto.IdPhong != null)
                        {
                            if (chitietcongto.IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(chitietcongto.IdPhong, Constant.Token);
                                if (phong.status == 200)
                                {
                                    chitietcongto.NamePhong = phong.data.FirstOrDefault().Name;
                                    chitietcongto.IdKhu = phong.data.FirstOrDefault().IdKhu;
                                    if (chitietcongto.IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(chitietcongto.IdKhu, Constant.Token);
                                        if (khu.status == 200)
                                        {
                                            chitietcongto.NameKhu = khu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                        }
                        chitietcongto.STT = i;
                        listChiTietCongTo.Add(chitietcongto);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async Task LoadListHopDong(List<Hopdong> listHopDong)
        {
            var resultListHopDong = await _hopDongHelper.GetListHopDong(Constant.Token);
            if (resultListHopDong.status == 200)
            {
                int i = 1;
                listHopDong.Clear();
                foreach (var item in resultListHopDong.data)
                {
                    if (item.IdNhanVien != null)
                    {
                        var resultNhanVien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien, Constant.Token);
                        if (resultNhanVien.status == 200)
                        {
                            item.NameNhanVien = resultNhanVien.data.FirstOrDefault().Name;
                            item.EmailNhanVien = resultNhanVien.data.FirstOrDefault().Email;
                        }
                    }
                    if (item.IdSinhVien != null)
                    {
                        var resultSinhVien = await _sinhVienHelper.GetSinhVienById(item.IdSinhVien, Constant.Token);
                        if (resultSinhVien.status == 200)
                        {
                            item.MaSinhVien = resultSinhVien.data.FirstOrDefault().MaSv;
                            item.NameSinhVien = resultSinhVien.data.FirstOrDefault().Name;
                            item.EmailSinhVien = resultSinhVien.data.FirstOrDefault().Email;
                        }
                    }
                    if (item.IdPhong != null)
                    {
                        var resultPhong = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
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
            var listPhong = await _phongHelper.GetListPhong(Constant.Token);
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
            frmLichSuGiaoDich frmLichSuGiaoDich = new frmLichSuGiaoDich(_bankingHelper, _sinhVienHelper, _khuHelper, _phongHelper, _frmLoading);
            frmLichSuGiaoDich.ShowDialog();
        }
        private async Task LoadListBanking(List<Banking> listBanking)
        {
            var lstBanking = await _bankingHelper.GetListBanking(Constant.Token);
            if (lstBanking.status == 200)
            {
                listBanking.Clear();
                int i = 1;
                foreach (var item in lstBanking.data)
                {
                    Banking banking = new Banking();
                    banking.Type = item.Type;
                    banking.IdUser = item.IdUser;
                    banking.Amount = item.Amount;
                    banking.Code = item.Code;
                    banking.Id = item.Id;
                    banking.Comment = item.Comment;
                    banking.CreateAt = item.CreateAt;
                    banking.STT = i;
                    if (banking.IdUser != null)
                    {
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(banking.IdUser, Constant.Token);
                        if (sinhvien.status == 200)
                        {
                            banking.Name = sinhvien.data.FirstOrDefault().Name;
                            banking.Email = sinhvien.data.FirstOrDefault().Email;
                            banking.Sdt = sinhvien.data.FirstOrDefault().Sdt;
                            if (sinhvien.data.FirstOrDefault().IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong, Constant.Token);
                                if (phong.status == 200)
                                {
                                    banking.NamePhong = phong.data.FirstOrDefault().Name;
                                    if (phong.data.FirstOrDefault().IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu, Constant.Token);
                                        if (khu.status == 200)
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
        private async Task LoadListPhong(List<Phong> listPhong)
        {
            var phongs = await _phongHelper.GetListPhong(Constant.Token);
            if (phongs.data.Count > 0)
            {
                int i = 1;
                listPhong.Clear();
                foreach (var item in phongs.data)
                {
                    Phong phong = new Phong();
                    phong.STT = i;
                    phong.Id = item.Id;
                    phong.Name = item.Name;
                    phong.QuantityPeople = item.QuantityPeople;
                    phong.MaxPeople = 8;
                    phong.IdKhu = item.IdKhu;
                    if (phong.IdKhu != null)
                    {
                        var khu = await _khuHelper.GetKhu(phong.IdKhu, Constant.Token);
                        if (khu.status == 200)
                        {
                            phong.NameKhu = khu.data.FirstOrDefault().Name;
                        }
                    }
                    listPhong.Add(phong);
                    i++;
                }
            }
        }
        private async Task LoadListTruong(List<Truong> listTruong)
        {
            var result = await _truongHelper.GetListTruong(Constant.Token);
            if (result.status == 200)
            {
                listTruong.Clear();
                foreach (var item in result.data)
                {
                    listTruong.Add(item);
                }
            }
        }
        private async Task LoadListBienLai(List<Bienlai> listBienLai)
        {
            try
            {
                var bienLais = await _bienLaiHelper.GetListBienLai(Constant.Token);
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
                        bienlai.MaGiaoDich = ConvertHelper.ConvertToGuid(item.Id);
                        if (bienlai.Status == true)
                        {
                            bienlai.TrangThai = "Đã Thanh Toán";
                        }
                        else if (bienlai.Status == false)
                        {
                            bienlai.TrangThai = "Chưa Thanh Toán";
                        }
                        bienlai.STT = i;
                        bienlai.IdNhanVien = item.IdNhanVien;
                        bienlai.IdSinhVien = item.IdSinhVien;
                        if (bienlai.IdSinhVien != null)
                        {
                            var sinhvien = await _sinhVienHelper.GetSinhVienById(bienlai.IdSinhVien, Constant.Token);
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
                                    var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong, Constant.Token);
                                    if (phong.status == 200)
                                    {
                                        bienlai.Phong = phong.data.FirstOrDefault().Name;
                                        if (phong.data.FirstOrDefault().IdKhu != null)
                                        {
                                            var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu, Constant.Token);
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
                            var nhanvien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien, Constant.Token);
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
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

        }
        private async Task LoadListQuanHe(List<Quanhe> listQuanHe)
        {
            var result = await _quanHeHelper.GetListQuanHe(Constant.Token);
            if (result.status == 200)
            {
                listQuanHe.Clear();
                foreach (var item in result.data)
                {
                    listQuanHe.Add(item);
                }
            }
        }
        private async Task LoadListHoaDon(List<Hoadon> listHoaDon)
        {
            var hoaDons = await _hoaDonHelper.GetListHoaDon(Constant.Token);
            if (hoaDons.status == 200)
            {
                int i = 1;
                listHoaDon.Clear();
                foreach (var item in hoaDons.data)
                {
                    Hoadon hoadon = new Hoadon();
                    hoadon.MaGiaoDich = ConvertHelper.ConvertToGuid(item.Id);
                    hoadon.Id = item.Id;
                    hoadon.Total = item.Total;
                    hoadon.Status = item.Status;
                    if (hoadon.Status == true)
                    {
                        hoadon.TrangThai = "Đã Thanh Toán";
                    }
                    else
                    {
                        hoadon.TrangThai = "Chưa Thanh Toán";
                    }
                    hoadon.CreateAt = item.CreateAt;
                    if (item.IdPhong != null)
                    {
                        hoadon.IdPhong = item.Id;
                        var phong = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
                        if (phong.status == 200)
                        {
                            hoadon.NamePhong = phong.data.FirstOrDefault().Name;
                            if (phong.data.FirstOrDefault().IdKhu != null)
                            {
                                var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu, Constant.Token);
                                if (khu.status == 200)
                                {
                                    hoadon.NameKhu = khu.data.FirstOrDefault().Name;
                                }
                            }
                        }
                    }
                    if (item.IdNhanVien != null)
                    {
                        hoadon.IdNhanVien = item.IdNhanVien;
                        var nhanvien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien, Constant.Token);
                        if (nhanvien.status == 200)
                        {
                            hoadon.NameNhanVien = nhanvien.data.FirstOrDefault().Name;
                            hoadon.EmailNhanVien = nhanvien.data.FirstOrDefault().Email;
                        }
                    }
                    if (item.IdSinhVien != null)
                    {
                        hoadon.IdSinhVien = item.IdSinhVien;
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(item.IdSinhVien, Constant.Token);
                        if (sinhvien.status == 200)
                        {
                            hoadon.NameSinhVien = sinhvien.data.FirstOrDefault().Name;
                            hoadon.EmailSinhVien = sinhvien.data.FirstOrDefault().Email;
                            hoadon.MaSinhVien = sinhvien.data.FirstOrDefault().Cccd;
                        }
                    }
                    if (item.IdChiTietCongTo != null)
                    {
                        var resultChiTietCongTo = await _chiTietCongToHelper.GetChiTietCongTo(item.IdChiTietCongTo, Constant.Token);
                        if (resultChiTietCongTo.status == 200)
                        {
                            hoadon.TienDien = resultChiTietCongTo.data.FirstOrDefault().TienDien.ToString();
                            hoadon.TienNuoc = resultChiTietCongTo.data.FirstOrDefault().TienNuoc.ToString();
                        }
                    }
                    hoadon.STT = i;
                    listHoaDon.Add(hoadon);
                    i++;
                }
            }
        }
    }
}