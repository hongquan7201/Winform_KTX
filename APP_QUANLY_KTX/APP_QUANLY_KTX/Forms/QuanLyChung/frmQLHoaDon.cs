using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
        private Hoadon _hoaDon = new Hoadon();
        private string messager = "Vui Lòng Thử Lại! ";
        public frmQLiHoaDon(IHoaDonHelper hoaDonHelper, frmLoading frmLoading, IPhongHelper phongHelper, IKhuHelper khuHelper, INhanVienHelper nhanVienHelper, ISinhVienHelper sinhVienHelper)
        {
            InitializeComponent();
            _hoaDonHelper = hoaDonHelper;
            _frmLoading = frmLoading;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _nhanVienHelper = nhanVienHelper;
            _sinhVienHelper = sinhVienHelper;
        }

        private void frmQLiHoaDon_Load(object sender, EventArgs e)
        {
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
            _frmLoading.Show();
            await Search();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task Search()
        {
            if (!string.IsNullOrEmpty(txtTim.EditValue.ToString()))
            {
                bool result = false;
                var checkSinhVien = await _sinhVienHelper.GetSinhVienByEmail(txtTim.EditValue.ToString(), Constant.Token);
                if (checkSinhVien.status == 200)
                {
                    foreach (var item in GlobalModel.ListHoaDon)
                    {
                        if (checkSinhVien.data.FirstOrDefault().Id == item.IdSinhVien)
                        {
                            GetAccount(item);
                            result = true;
                            break;
                        }
                    }
                    if (result == true)
                    {
                        messager = "Tìm Thành Công!";
                    }
                    else
                    {
                        messager = "Sinh Viên Không có Hóa Đơn Nào!";
                    }
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
        private void cbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    var result = await _hoaDonHelper.EditHoaDon(hoadon, Constant.Token);
                    if (result.status == 200)
                    {
                        Banking banking = new Banking();
                        banking.IdHoaDon = hoadon.Id;
                        banking.cmt = "HD-" + checkSinhVien.data.FirstOrDefault().Cccd;
                        banking.IdUser = GlobalModel.Nhanvien.Id;
                        banking.creatAt = DateTime.Now;
                        banking.type = "Banking " + GlobalModel.Nhanvien.Email;
                        var resultBanking = await _bankingHelper.AddBanking(banking, Constant.Token);
                        messager = "Thanh Toán Thành Công!";
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
                    _hoaDon = GlobalModel.ListHoaDon[s];
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
                            hoadon.MaSinhVien = sinhvien.data.FirstOrDefault().MaSv;
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
            txtEmail.Text = hoadon.EmailSinhVien;
            txtEmailNV.Text = hoadon.EmailNhanVien;
            txtHoTen.Text = hoadon.NameSinhVien;
            txtCCCD.Text = hoadon.MaSinhVien;
            txtTenNhanVien.Text = hoadon.NameNhanVien;
            txtTongTien.Text = hoadon.Total.ToString();
            cbKhu.Text = hoadon.NameKhu;
            cbPhong.Text = hoadon.NamePhong;
            dtNgayThu.Text = hoadon.CreateAt.ToString();
            cbTrangThai.Text = hoadon.TrangThai;
        }
    }
}