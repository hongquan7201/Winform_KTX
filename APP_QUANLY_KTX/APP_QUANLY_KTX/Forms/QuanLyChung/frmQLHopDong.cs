using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;
using ProjectQLKTX.Files;

namespace ProjectQLKTX
{
    public partial class frmQLiHopDong : DevExpress.XtraEditors.XtraForm
    {
        private readonly IHopDongHelper _hopDongHelper;
        private readonly INhanVienHelper _nhanVienHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly frmLoading _frmLoading;
        private Hopdong _hopdong = new Hopdong();
        public frmQLiHopDong(IHopDongHelper hopDongHelper, INhanVienHelper nhanVienHelper, ISinhVienHelper sinhVienHelper, IPhongHelper phongHelper, frmLoading frmLoading)
        {
            InitializeComponent();
            _hopDongHelper = hopDongHelper;
            _nhanVienHelper = nhanVienHelper;
            _sinhVienHelper = sinhVienHelper;
            _phongHelper = phongHelper;
            _frmLoading = frmLoading;
        }

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCheck = false;
            foreach (var item in GlobalModel.ListHopDong)
            {
                if (item.Phong == cbPhong.Text)
                {
                    _hopdong = item;
                    isCheck = true;
                    break;
                }
            }
            if (isCheck == true)
            {
                GetAccount(_hopdong);
            }
            else
            {
                txtMaSV.Text = string.Empty;
                txtHoTen.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtEmailNV.Text = string.Empty;
                txtTenNV.Text = string.Empty;
                dtNgayBatDau.Text = DateTime.Now.ToString();
                dtNgayKetKhuc.Text = DateTime.Now.ToString();
            }


        }
        private void frmQLiHopDong_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = GlobalModel.ListHopDong;
            gcDanhSach.RefreshDataSource();
            cbPhong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                cbPhong.Properties.Items.Add(item.Name);
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
                    _hopdong = GlobalModel.ListHopDong[s];
                    GetAccount(_hopdong);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async void GetAccount(Hopdong hopDong)
        {
            txtMaSV.Text = hopDong.MaSinhVien;
            txtHoTen.Text = hopDong.NameSinhVien;
            txtEmail.Text = hopDong.EmailSinhVien;
            txtEmailNV.Text = hopDong.EmailNhanVien;
            txtTenNV.Text = hopDong.NameNhanVien;
            cbPhong.Text = hopDong.Phong;
            try
            {
                if (hopDong.NgayBatDau != null)
                {
                    dtNgayBatDau.Text = hopDong.NgayBatDau.ToString();
                }
                if (hopDong.NgayKetThuc != null)
                {
                    dtNgayKetKhuc.Text = hopDong.NgayKetThuc.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui Lòng Định Dạng Lại dd/mm/yyyy");
            }
        }

        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GlobalModel.Nhanvien.Name == txtTenNV.Text && GlobalModel.Nhanvien.Email == txtEmailNV.Text)
            {
                _frmLoading.Show();
                await AddHopDong();
                _frmLoading.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng thông tin cá nhân của mình");
            }
        }

        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await SearchSinhVien(GlobalModel.ListHopDong, txtTim.EditValue.ToString());
            _frmLoading.Hide();
        }
        private async Task SearchSinhVien(List<Hopdong> listSinhVien, string nameSearch)
        {
            APIRespone<List<Sinhvien>> resultSinhVien = new APIRespone<List<Sinhvien>>();
            long intValue;
            if (long.TryParse(nameSearch, out intValue))
            {
                resultSinhVien = await _sinhVienHelper.GetSinhVienByCCCD(nameSearch, Constant.Token);
            }
            else
            {
                resultSinhVien = await _sinhVienHelper.GetSinhVienByName(nameSearch, Constant.Token);
            }
            if (resultSinhVien.status == 200)
            {
                List<Hopdong> lstHopDong = new List<Hopdong>();
                foreach (var item in listSinhVien)
                {
                    lstHopDong.Add(item);
                }
                listSinhVien.Clear();
                int i = 1;
                foreach (var item in resultSinhVien.data)
                {
                    Hopdong hopDong = new Hopdong();
                    hopDong.NameSinhVien = item.Name;
                    hopDong.EmailSinhVien = item.Email;
                    hopDong.MaSinhVien = item.MaSv;
                    hopDong.IdSinhVien = item.Id;
                    foreach (var phong in GlobalModel.ListPhong)
                    {
                        if (item.IdPhong == phong.Id)
                        {
                            hopDong.Phong = phong.Name;
                            hopDong.IdPhong = phong.Id;
                            break;
                        }
                    }
                    foreach (var itemHopDong in lstHopDong)
                    {
                        if (item.Id == itemHopDong.IdSinhVien)
                        {
                            hopDong.Id = itemHopDong.Id;
                            hopDong.NgayBatDau = itemHopDong.NgayBatDau;
                            hopDong.NgayKetThuc = itemHopDong.NgayKetThuc;
                            hopDong.NameNhanVien = itemHopDong.NameNhanVien;
                            hopDong.EmailNhanVien = itemHopDong.EmailNhanVien;
                        }
                    }

                    listSinhVien.Add(hopDong);
                    i++;
                }
                gcDanhSach.DataSource = listSinhVien;
                gcDanhSach.RefreshDataSource();
            }
            else
            {
                MessageBox.Show(resultSinhVien.message);
            }

        }
        private async Task AddHopDong()
        {
            Hopdong hopdong = new Hopdong();
            hopdong.NgayBatDau = DateTime.Parse(dtNgayBatDau.Text);
            hopdong.NgayKetThuc = DateTime.Parse(dtNgayKetKhuc.Text);
            hopdong.IdNhanVien = GlobalModel.Nhanvien.Id;
            hopdong.IdSinhVien = _hopdong.IdSinhVien;
            var resultAddHopDong = await _hopDongHelper.AddHopDong(hopdong, Constant.Token);
            if (resultAddHopDong.status == 200)
            {
                await LoadListHopDong(GlobalModel.ListHopDong);
                gcDanhSach.DataSource = GlobalModel.ListHopDong;
                gcDanhSach.RefreshDataSource();
            }
            MessageBox.Show(resultAddHopDong.message);
        }

        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (_hopdong.Id == Guid.Empty)
            {
                MessageBox.Show("Sinh Viên này chưa có hợp đồng!");
            }
            else
            {
                if (GlobalModel.Nhanvien.Name == txtTenNV.Text && GlobalModel.Nhanvien.Email == txtEmailNV.Text)
                {
                    _frmLoading.Show();
                    await EditHopDong();
                    _frmLoading.Hide();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng thông tin cá nhân của mình");
                }
            }
        }
        private async Task EditHopDong()
        {
            Hopdong hopdong = new Hopdong();
            hopdong.Id = _hopdong.Id;
            hopdong.NgayBatDau = DateTime.Parse(dtNgayBatDau.Text);
            hopdong.NgayKetThuc = DateTime.Parse(dtNgayKetKhuc.Text);
            hopdong.IdNhanVien = GlobalModel.Nhanvien.Id;
            hopdong.IdSinhVien = _hopdong.IdSinhVien;
            var resultEditHopDong = await _hopDongHelper.EditHopDong(hopdong.Id, hopdong, Constant.Token);
            if (resultEditHopDong.status == 200)
            {
                await LoadListHopDong(GlobalModel.ListHopDong);
                gcDanhSach.DataSource = GlobalModel.ListHopDong;
                gcDanhSach.RefreshDataSource();
            }
            MessageBox.Show(resultEditHopDong.message);

        }
        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            var delete = await _hopDongHelper.DeleteHopDong(_hopdong.Id, Constant.Token);
            if (delete.status == 200)
            {
                await LoadListHopDong(GlobalModel.ListHopDong);
                gcDanhSach.DataSource = GlobalModel.ListHopDong;
                gcDanhSach.RefreshDataSource();
            }
            _frmLoading.Hide();
            MessageBox.Show(delete.message);
        }
        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListHopDong(GlobalModel.ListHopDong);
            _frmLoading.Hide();
            gcDanhSach.DataSource = GlobalModel.ListHopDong;
            gcDanhSach.RefreshDataSource();
        }

        private void btnXuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportExcel(gcDanhSach, "DanhSachHopDong");
        }

        private void btnInfilePDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = new Report_Hopdong();
            // Set the value of the "MaGiaoDich" field
            report.Parameters["NameSinhVien"].Value = "Họ, tên sinh viên: " + _hopdong.NameSinhVien + ".";
            report.Parameters["MaGiaoDich"].Value = "Mã Hợp Đồng: " + _hopdong.Id.ToString();
            report.Parameters["NamePhong"].Value = "Phòng: ." + _hopdong.Phong + ".";
            report.Parameters["MaSinhVien"].Value = "Mã Số Sinh Viên: " + _hopdong.MaSinhVien + ".";
            report.Parameters["EmailSinhVien"].Value = "Email Sinh Viên: " + _hopdong.EmailSinhVien + ".";
            report.Parameters["NgayBatDau"].Value = "Ngày Bắt Đầu:  ngày " + _hopdong.NgayBatDau.Value.Day + " tháng " + _hopdong.NgayBatDau.Value.Month + " năm " + _hopdong.NgayBatDau.Value.Year + ".";
            report.Parameters["NgayKetThuc"].Value = "Ngày Kết Thúc:  ngày " + _hopdong.NgayKetThuc.Value.Day + " tháng " + _hopdong.NgayKetThuc.Value.Month + " năm " + _hopdong.NgayKetThuc.Value.Year + ".";
            report.Parameters["CreatAt"].Value = "Đà Nẵng,  ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + ".";
            report.Parameters["MaSo"].Value = "Số: " + DateTime.Now.Month + "/HĐ-TTQLKTX";
            // Export the report to PDF
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = _hopdong.MaSinhVien + "_HopDong.pdf"; // Đặt tên file mặc định là "TaiSan.pdf"
            save.Filter = "PDF Files|*.pdf"; // Chỉ cho phép lưu file có đuôi .pdf
            if (save.ShowDialog() == DialogResult.OK)
            {
                report.ExportToPdf(save.FileName);
            }
        }
    }
}