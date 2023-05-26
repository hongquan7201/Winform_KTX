using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler.Reporting.Native;
using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Files;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmQLiHoaDon : DevExpress.XtraEditors.XtraForm
    {
        private readonly IHoaDonHelper _hoaDonHelper;
        private readonly frmLoading _frmLoading;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly INhanVienHelper _nhanVienHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IBankingHelper _bankingHelper;
        private readonly IChiTietCongToHelper _chiTietCongToHelper;
        private Hoadon _hoaDon = new Hoadon();
        private string messager = "Vui Lòng Thử Lại! ";
        private static List<Sinhvien> _listSinhVien = new List<Sinhvien>();
        public frmQLiHoaDon(IHoaDonHelper hoaDonHelper, frmLoading frmLoading, IPhongHelper phongHelper, IKhuHelper khuHelper, INhanVienHelper nhanVienHelper, ISinhVienHelper sinhVienHelper, IChiTietCongToHelper chiTietCongToHelper, IBankingHelper bankingHelper)
        {
            InitializeComponent();
            _hoaDonHelper = hoaDonHelper;
            _frmLoading = frmLoading;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _nhanVienHelper = nhanVienHelper;
            _sinhVienHelper = sinhVienHelper;
            _chiTietCongToHelper = chiTietCongToHelper;
            _bankingHelper = bankingHelper;
        }

        private void frmQLiHoaDon_Load(object sender, EventArgs e)
        {
            txtEmailNV.Text = GlobalModel.Nhanvien.Email;
            txtTenNhanVien.Text = GlobalModel.Nhanvien.Name;
            gcDanhSach.DataSource = GlobalModel.ListHoaDon;
            gcDanhSach.RefreshDataSource();
        }
        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Edit();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task Edit()
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmailNV.Text == GlobalModel.Nhanvien.Email)
            {
                var checkSinhVien = await _sinhVienHelper.GetSinhVienByEmail(txtEmail.Text, Constant.Token);
                if (checkSinhVien.status == 200)
                {
                    Hoadon hoadon = new Hoadon();
                    hoadon.Id = _hoaDon.Id;
                    hoadon.Status = _hoaDon.Status;
                    hoadon.CreateAt = DateTime.Parse(dtNgayThu.Text);
                    hoadon.Total = decimal.Parse(txtTongTien.Text);
                    hoadon.IdNhanVien = GlobalModel.Nhanvien.Id;
                    hoadon.IdSinhVien = checkSinhVien.data.FirstOrDefault().Id;
                    var result = await _hoaDonHelper.EditHoaDon(hoadon, Constant.Token);
                    await LoadListHoaDon(GlobalModel.ListHoaDon);
                    gcDanhSach.DataSource = GlobalModel.ListHoaDon;
                    gcDanhSach.RefreshDataSource();
                    messager = result.message;
                }
                else
                {
                    messager = checkSinhVien.message;
                }
            }
            else
            {
                messager = "Vui Lòng Nhập Đúng Thông Tin!";
            }
        }
        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Delete();
            await LoadListHoaDon(GlobalModel.ListHoaDon);
            gcDanhSach.DataSource = GlobalModel.ListHoaDon;
            gcDanhSach.RefreshDataSource();
            _frmLoading.Hide();
        }
        private async Task Delete()
        {
            var result = await _hoaDonHelper.DeleteHoaDon(_hoaDon.Id, Constant.Token);
            messager = result.message;
        }
        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListHoaDon(GlobalModel.ListHoaDon);
            _frmLoading.Hide();
        }

        private void btnXuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportExcel(gcDanhSach, "HoaDon");
        }

        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guid guid;
            if (Guid.TryParse(txtTim.EditValue.ToString(), out guid))
            {
                _frmLoading.Show();
                await Search(guid, GlobalModel.ListHoaDon);
                gcDanhSach.DataSource = GlobalModel.ListHoaDon;
                gcDanhSach.RefreshDataSource();
                _frmLoading.Hide();
                MessageBox.Show(messager);
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Mã Giao Dịch");
            }
        }
        private async Task Search(Guid id, List<Hoadon> listHoaDon)
        {
            var result = await _hoaDonHelper.GetHoaDon(id, Constant.Token);
            if (result.status == 200)
            {
                int i = 1;
                listHoaDon.Clear();
                foreach (var item in result.data)
                {
                    Hoadon hoadon = new Hoadon();
                    hoadon.Id = item.Id;
                    hoadon.Total = item.Total;
                    hoadon.Status = item.Status;
                    hoadon.MaGiaoDich = ConvertHelper.ConvertToGuid(item.Id);
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
                        hoadon.IdPhong = item.IdPhong;
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
        private void cbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task ThanhToan()
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmailNV.Text == GlobalModel.Nhanvien.Email)
            {
                var checkSinhVien = await _sinhVienHelper.GetSinhVienByEmail(txtEmail.Text, Constant.Token);
                if (checkSinhVien.status == 200)
                {
                    Hoadon hoadon = new Hoadon();
                    hoadon.Id = _hoaDon.Id;
                    hoadon.Status = true;
                    hoadon.IdNhanVien = GlobalModel.Nhanvien.Id;
                    hoadon.IdSinhVien = checkSinhVien.data.FirstOrDefault().Id;
                    hoadon.IdChiTietCongTo = _hoaDon.IdChiTietCongTo;
                    hoadon.Total = _hoaDon.Total;
                    hoadon.IdPhong = _hoaDon.IdPhong;
                    hoadon.CreateAt = _hoaDon.CreateAt;
                    var result = await _hoaDonHelper.EditHoaDon(hoadon, Constant.Token);
                    if (result.status == 200)
                    {
                        Banking banking = new Banking();
                        banking.IdHoaDon = hoadon.Id;
                        banking.Comment = "HD-" + checkSinhVien.data.FirstOrDefault().Cccd;
                        banking.IdUser = GlobalModel.Nhanvien.Id;
                        banking.Type = "Thanh Toán Qua: " + GlobalModel.Nhanvien.Email;
                        banking.Amount = _hoaDon.Total;
                        var resultBanking = await _bankingHelper.AddBanking(banking, Constant.Token);
                        messager = "Thanh Toán Thành Công!";
                    }

                    var report = new Report_Hoadon();
                    // Set the value of the "MaGiaoDich" field
                    report.Parameters["NameSinhVien1"].Value = "Họ, tên sinh viên: " + checkSinhVien.data.FirstOrDefault().Name + ".";
                    report.Parameters["MaBienLai"].Value = "Mã biên lai: " + _hoaDon.MaGiaoDich;
                    report.Parameters["NamePhong"].Value = "Phòng: ." + _hoaDon.NamePhong + ".";
                    report.Parameters["NameKhu"].Value = "Khu: " + _hoaDon.NameKhu + ".";
                    report.Parameters["CCCD"].Value = "CCCD: " + checkSinhVien.data.FirstOrDefault().Cccd + ".";
                    report.Parameters["TienDien"].Value = "Tiền điện: " + _hoaDon.TienDien.ToString() + ".(đồng)" + "( " + VietnamNumber.Number.ToVietnameseWords(Convert.ToInt64(_hoaDon.TienDien)) + " đồng )";
                    report.Parameters["TienNuoc"].Value = "Tiền nước: " + _hoaDon.TienNuoc.ToString() + ".(đồng)" + "( " + VietnamNumber.Number.ToVietnameseWords(Convert.ToInt64(_hoaDon.TienNuoc)) + " đồng )";
                    report.Parameters["Total"].Value = "Tổng tiền: " + _hoaDon.Total.ToString() + ".(đồng)" + "( " + VietnamNumber.Number.ToVietnameseWords(Convert.ToInt64(_hoaDon.Total)) + " đồng )";
                    report.Parameters["NgayDong"].Value = "Ngày đóng:  ngày " + _hoaDon.CreateAt.Value.Day + " tháng " + _hoaDon.CreateAt.Value.Month + " năm " + _hoaDon.CreateAt.Value.Year + ".";
                    report.Parameters["CreatAt"].Value = "Đà Nẵng,  ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + ".";
                    report.Parameters["MaSo"].Value = "Số: " + checkSinhVien.data.FirstOrDefault().Cccd + "/QĐ-TTQLKTX";
                    // Export the report to PDF
                    SaveFileDialog save = new SaveFileDialog();
                    save.FileName = checkSinhVien.data.FirstOrDefault().Cccd + "_HoaDon.pdf"; // Đặt tên file mặc định là "TaiSan.pdf"
                    save.Filter = "PDF Files|*.pdf"; // Chỉ cho phép lưu file có đuôi .pdf
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        report.ExportToPdf(save.FileName);
                    }
                    await LoadListHoaDon(GlobalModel.ListHoaDon);
                    gcDanhSach.DataSource = GlobalModel.ListHoaDon;
                    gcDanhSach.RefreshDataSource();

                }
                else
                {
                    messager = checkSinhVien.message;
                }

            }
            else
            {
                messager = "Vui Lòng Nhập Đúng Thông Tin!";
            }
        }
        private async void gcDanhSach_DoubleClick(object sender, EventArgs e)
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
                    _hoaDon = GlobalModel.ListHoaDon[s];
                    if (_hoaDon.IdPhong != null)
                    {
                        txtHoTen.Properties.Items.Clear();
                        var result = await _phongHelper.GetAllSinhVienInPhong(_hoaDon.IdPhong, Constant.Token);
                        if (result.status == 200)
                        {

                            foreach (var item in result.data)
                            {
                                _listSinhVien.Add(item);
                                txtHoTen.Properties.Items.Add(item.Name);
                            }
                        }
                    }
                    GetAccount(_hoaDon);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
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
                    hoadon.Id = item.Id;
                    hoadon.Total = item.Total;
                    hoadon.Status = item.Status;
                    hoadon.MaGiaoDich = ConvertHelper.ConvertToGuid(item.Id);
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
                        hoadon.IdPhong = item.IdPhong;
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
        private void GetAccount(Hoadon hoadon)
        {
            txtMaGD.Text = hoadon.MaGiaoDich;
            txtTienDien.Text = hoadon.TienDien;
            txtTienNuoc.Text = hoadon.TienNuoc;
            txtEmail.Text = hoadon.EmailSinhVien;
            txtEmailNV.Text = hoadon.EmailNhanVien;
            txtHoTen.Text = hoadon.NameSinhVien;
            txtCCCD.Text = hoadon.MaSinhVien;
            txtTenNhanVien.Text = hoadon.NameNhanVien;
            txtTongTien.Text = hoadon.Total.ToString() + "( " + VietnamNumber.Number.ToVietnameseWords(Convert.ToInt64(_hoaDon.Total)) + " đồng )";
            cbKhu.Text = hoadon.NameKhu;
            cbPhong.Text = hoadon.NamePhong;
            cbTrangThai.Text = hoadon.TrangThai;
            dtNgayThu.Text = hoadon.CreateAt.ToString();
        }

        private async void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await ThanhToan();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }

        private async void txtHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in _listSinhVien)
            {
                if (txtHoTen.Text == item.Name)
                {
                    txtCCCD.Text = item.Cccd;
                    txtEmail.Text = item.Email;
                    break;
                }
            }
        }
    }
}