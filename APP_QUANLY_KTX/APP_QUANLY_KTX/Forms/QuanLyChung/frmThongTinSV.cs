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
    public partial class frmThongTinSV : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IThanNhanHelper _thanNhanHelper;
        private readonly IQuanHeHelper _quanHeHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        private string messager = "Vui Lòng Thử Lại!";
        public frmThongTinSV(ISinhVienHelper sinhVienHelper, IThanNhanHelper thanNhanHelper, IQuanHeHelper quanHeHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper, frmLoading frmLoading)
        {
            InitializeComponent();
            _sinhVienHelper = sinhVienHelper;
            _thanNhanHelper = thanNhanHelper;
            _quanHeHelper = quanHeHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
            _frmLoading = frmLoading;
        }

        private Sinhvien _sinhVien { get; set; }
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
                    gcDanhSach.DataSource = listAccount;
                    gcDanhSach.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show(listSinhVien.message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + listSinhVien);
                Log.Error(ex, ex.Message);
            }
        }
        private async void frmThongTinSV_Load(object sender, EventArgs e)
        {
            imgSVNu.Visible = false;
            imgSVNam.Visible = false;
            imgNo.Visible = true;
            gcDanhSach.DataSource = GlobalModel.ListSinhVien;
            gcDanhSach.RefreshDataSource();
            cbPhong.Properties.Items.Clear();
            cbKhu.Properties.Items.Clear();
            lbDem.Text = GlobalModel.ListSinhVien.Count.ToString();
            foreach (var phong in GlobalModel.ListPhong)
            {
                cbPhong.Properties.Items.Add(phong.Name);
                cbKhu.Properties.Items.Add(phong.NameKhu);
            }
            cbQuanHe.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListQuanhe)
            {
                cbQuanHe.Properties.Items.Add(item.Name);
            }
            cbTruong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListTruong)
            {
                cbTruong.Properties.Items.Add(item.Name);
            }
        }

        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await AddSinhVien();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task AddSinhVien()
        {
            Sinhvien newSinhVien = new Sinhvien();
            newSinhVien.Name = txtHoTen.Text;
            newSinhVien.MaSv = txtMaSV.Text;
            newSinhVien.Address = txtDiaChi.Text;
            newSinhVien.BirthDay = dtNgaySinh.Value;
            newSinhVien.Cccd = txtCCCD.Text;
            newSinhVien.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
            newSinhVien.Email = txtEmail.Text;
            newSinhVien.Password = txtEmail.Text;
            newSinhVien.Sdt = txtSDT.Text;
            if (cbGioiTinh.Text == "Nam")
            {
                newSinhVien.Gender = true;
            }
            else
            {
                newSinhVien.Gender = false;
            }
            foreach (var item in GlobalModel.ListTruong)
            {
                if (cbTruong.Text == item.Name)
                {
                    newSinhVien.IdTruong = item.Id;
                }
            }
            foreach (var item in GlobalModel.ListPhong)
            {
                if (cbPhong.Text == item.Name)
                {
                    newSinhVien.IdPhong = item.Id;
                }
            }
            var sinhvien = await _sinhVienHelper.AddSinhVien(newSinhVien, Constant.Token);
            if (sinhvien.status == 200)
            {
                newSinhVien.Code = sinhvien.code;
                newSinhVien.Id = sinhvien.id;
                Thannhan thannhan = new Thannhan();
                thannhan.Address = txtDiaChiTN.Text;
                thannhan.IdUser = newSinhVien.Id;
                thannhan.Name = txtTenTN.Text;
                foreach (var item in GlobalModel.ListQuanhe)
                {
                    if (cbQuanHe.Text == item.Name)
                    {
                        thannhan.IdQuanHe = item.Id;
                    }
                }
                thannhan.Sdt = txtSDTTN.Text;
                if (cbGioiTinhTN.Text == "Nam")
                {
                    thannhan.Gender = true;
                }
                else
                {
                    thannhan.Gender = false;
                }
                var resultThanNhan = await _thanNhanHelper.AddThanNhan(thannhan, Constant.Token);
                if (resultThanNhan.status == 200)
                {

                }
            }
            await LoadSinhVien(GlobalModel.ListSinhVien);
            gcDanhSach.DataSource = GlobalModel.ListSinhVien;
            gcDanhSach.RefreshDataSource();
            lbDem.Text = GlobalModel.ListSinhVien.Count.ToString();
            messager = sinhvien.message;
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
                    _sinhVien = GlobalModel.ListSinhVien[s];
                    GetAccount(_sinhVien);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async void GetAccount(Sinhvien sinhVien)
        {
            cbTruong.Text = sinhVien.Truong;
            txtMaSV.Text = sinhVien.MaSv;
            txtHoTen.Text = sinhVien.Name;
            txtEmail.Text = sinhVien.Email;
            txtDiaChi.Text = sinhVien.Address;
            txtDiaChiTN.Text = sinhVien.AddressThanNha;
            cbQuanHe.Text = sinhVien.QuanHe;
            txtSDTTN.Text = sinhVien.SDTThanNhan;
            txtTenTN.Text = sinhVien.TenThanNhan;
            cbKhu.Text = sinhVien.Khu;
            cbPhong.Text = sinhVien.Phong;
            cbGioiTinhTN.Text = sinhVien.GioiTinhThanNhan;
            txtCCCD.Text = sinhVien.Cccd;
            txtSDT.Text = sinhVien.Sdt;
            cbGioiTinh.Text = sinhVien.GioiTinh;
            if (sinhVien.Gender == true)
            {
                imgSVNam.Visible = true;
                imgSVNu.Visible = false;
            }
            else
            {
                imgSVNam.Visible = false;
                imgSVNu.Visible = true;
            }
            try
            {
                if (sinhVien.CreateAt != null)
                {
                    dtNgayDangKy.Value = sinhVien.CreateAt;
                }
                    dtNgaySinh.Value = sinhVien.BirthDay;
            }
            catch (Exception ex)
            {

            }

        }
        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await EditSinhVien();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task EditSinhVien()
        {
            _sinhVien.Name = txtHoTen.Text;
            _sinhVien.Email = txtEmail.Text;
            _sinhVien.Address = txtDiaChi.Text;
            _sinhVien.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
            _sinhVien.BirthDay = dtNgaySinh.Value;
            _sinhVien.Cccd = txtCCCD.Text;
            _sinhVien.Sdt = txtSDT.Text;
            _sinhVien.MaSv = txtMaSV.Text;
            if (txtTenTN != null)
            {
                Thannhan thannhan = new Thannhan();
                thannhan.IdUser = _sinhVien.Id;
                if (_sinhVien.idThanNhan != null)
                {
                    thannhan.Id = _sinhVien.idThanNhan;
                    thannhan.Address = txtDiaChiTN.Text;
                    if (cbQuanHe.Text != null)
                    {
                        foreach (var item in GlobalModel.ListQuanhe)
                        {
                            if (cbQuanHe.Text == item.Name)
                            {
                                thannhan.IdQuanHe = item.Id;
                            }

                        }
                    }
                    thannhan.Sdt = txtSDT.Text;
                    thannhan.Name = txtTenTN.Text;
                    if (cbGioiTinhTN.Text == "Nam")
                    {
                        thannhan.Gender = true;
                    }
                    else
                    {
                        thannhan.Gender = false;
                    }
                    var s = await _thanNhanHelper.EditThanNhan(thannhan, Constant.Token);
                }
                else
                {
                    thannhan.Address = txtDiaChiTN.Text;
                    if (cbQuanHe.Text != null)
                    {
                        foreach (var item in GlobalModel.ListQuanhe)
                        {
                            if (cbQuanHe.Text == item.Name)
                            {
                                thannhan.IdQuanHe = item.Id;
                            }

                        }
                    }
                    thannhan.Sdt = txtSDT.Text;
                    thannhan.Name = txtTenTN.Text;
                    if (cbGioiTinhTN.Text == "Nam")
                    {
                        thannhan.Gender = true;
                    }
                    else
                    {
                        thannhan.Gender = false;
                    }
                    var s = await _thanNhanHelper.AddThanNhan(thannhan, Constant.Token);
                }

            }
            if (cbGioiTinh.Text == "Nam")
            {
                _sinhVien.Gender = true;
            }
            else
            {
                _sinhVien.Gender = false;
            }
            if (cbPhong.Text != _sinhVien.Phong || cbKhu.Text != _sinhVien.Khu)
            {
                foreach (var phong in GlobalModel.ListPhong)
                {
                    if (phong.Name == cbPhong.Text)
                    {
                        _sinhVien.IdPhong = phong.Id;
                    }
                }
            }
            var result = await _sinhVienHelper.EditSinhVien(_sinhVien, Constant.Token);
            if (result.status == 200)
            {
                await LoadSinhVien(GlobalModel.ListSinhVien);
                gcDanhSach.DataSource = GlobalModel.ListSinhVien;
                gcDanhSach.RefreshDataSource();
                lbDem.Text = GlobalModel.ListSinhVien.Count.ToString();
            }
            try
            {
                await LoadSinhVien(GlobalModel.ListSinhVien);
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + result);
                Log.Error(ex, ex.Message);
            }
        }
        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await DeleteSinhVien();
            _frmLoading.Hide();
            MessageBox.Show(messager);

        }
        private async Task DeleteSinhVien()
        {

            try
            {
                var deleteById = await _sinhVienHelper.DeleteSinhVien(_sinhVien.Id, Constant.Token);
                if (deleteById.status == 200)
                {
                    await LoadSinhVien(GlobalModel.ListSinhVien);
                    gcDanhSach.DataSource = GlobalModel.ListSinhVien;
                    gcDanhSach.RefreshDataSource();
                    lbDem.Text = GlobalModel.ListSinhVien.Count.ToString();
                }
                messager = deleteById.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message, ex.StackTrace);
            }
        }
        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadSinhVien(GlobalModel.ListSinhVien);
            _frmLoading.Hide();
        }
        private void btnXuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportExcel(gcDanhSach, "DanhSachSinhVien");
        }
        private void btnInfilePDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportPDF(gcDanhSach, "DanhSachSinhVien");
        }
        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTim.EditValue.ToString()))
            {
                _frmLoading.Show();
                await SearchSinhVien(GlobalModel.ListSinhVien, txtTim.EditValue.ToString());
                gcDanhSach.DataSource = GlobalModel.ListSinhVien;
                gcDanhSach.RefreshDataSource();
                lbDem.Text = GlobalModel.ListSinhVien.Count.ToString();
                _frmLoading.Hide();
                MessageBox.Show(messager);
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin cần Tìm!");
            }
        }
        private async Task SearchSinhVien(List<Sinhvien> listSinhVien, string nameSearch)
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
                List<Sinhvien> lstSinhVien = new List<Sinhvien>();
                foreach (var item in listSinhVien)
                {
                    lstSinhVien.Add(item);
                }
                listSinhVien.Clear();
                int i = 1;
                foreach (var item in resultSinhVien.data)
                {
                    Sinhvien sinhvien = new Sinhvien();
                    sinhvien.Address = item.Address;
                    sinhvien.Cccd = item.Cccd;
                    sinhvien.Name = item.Name;
                    sinhvien.Sdt = item.Sdt;
                    sinhvien.BirthDay = item.BirthDay;
                    sinhvien.Id = item.Id;
                    sinhvien.MaSv = item.MaSv;
                    sinhvien.Gender = item.Gender;
                    sinhvien.Email = item.Email;
                    if (sinhvien.Gender == true)
                    {
                        sinhvien.GioiTinh = "Nam";
                    }
                    else
                    {
                        sinhvien.GioiTinh = "Nữ";
                    }
                    sinhvien.IdPhong = item.IdPhong;
                    if (item.IdPhong != null)
                    {
                        var resultPhong = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
                        if (resultPhong.status == 200)
                        {
                            if (resultPhong.data.FirstOrDefault().IdKhu != null)
                            {
                                sinhvien.Phong = resultPhong.data.FirstOrDefault().Name;
                                var resultKhu = await _khuHelper.GetKhu(resultPhong.data.FirstOrDefault().IdKhu, Constant.Token);
                                if (resultKhu.status == 200)
                                {
                                    sinhvien.Khu = resultKhu.data.FirstOrDefault().Name;
                                }
                            }
                        }
                    }
                    if (item.IdTruong != null)
                    {
                        var resultTruong = await _truongHelper.GetTruong(item.IdTruong, Constant.Token);
                        if (resultTruong.status == 200)
                        {
                            sinhvien.Truong = resultTruong.data.FirstOrDefault().Name;
                        }
                    }
                    sinhvien.idThanNhan = item.idThanNhan;
                    if (sinhvien.idThanNhan != null)
                    {

                        var thannhan = await _thanNhanHelper.GetThanNhan(sinhvien.idThanNhan, Constant.Token);
                        if (thannhan.status == 200)
                        {
                            sinhvien.TenThanNhan = thannhan.data.FirstOrDefault().Name;
                            sinhvien.SDTThanNhan = thannhan.data.FirstOrDefault().Sdt;
                            sinhvien.AddressThanNha = thannhan.data.FirstOrDefault().Address;
                            if (thannhan.data.FirstOrDefault().Gender == true)
                            {

                                sinhvien.GioiTinhThanNhan = "Nam";
                            }
                            else
                            {
                                sinhvien.GioiTinhThanNhan = "Nữ";
                            }
                            if (thannhan.data.FirstOrDefault().IdQuanHe != null)
                            {
                                var quanHe = await _quanHeHelper.GetQuanHe(thannhan.data.FirstOrDefault().IdQuanHe, Constant.Token);
                                if (quanHe.status == 200)
                                {
                                    sinhvien.QuanHe = quanHe.data.FirstOrDefault().Name;
                                }
                            }
                        }
                    }
                    sinhvien.STT = i;
                    listSinhVien.Add(sinhvien);
                    i++;
                }
            }
            messager = resultSinhVien.message;
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

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGioiTinh.Text == "Nam")
            {
                imgSVNam.Visible = true;
                imgSVNu.Visible = false;
                imgNo.Visible = false;
            }
            else
            {
                imgSVNam.Visible = false;
                imgSVNu.Visible = true;
                imgNo.Visible = false;
            }
        }
    }
}