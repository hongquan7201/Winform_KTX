using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmDKPhong : DevExpress.XtraEditors.XtraForm
    {
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        private readonly IHopDongHelper _hopDongHelper;
        private readonly IXeHelper _xeHelper;
        private readonly IBienLaiHelper _bienLaiHelper;
        private readonly frmLoading _frmLoading;
        private string messager = "Vui Lòng Thử Lại!";
        public frmDKPhong(ISinhVienHelper sinhVienHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper, IHopDongHelper hopDongHelper, IXeHelper xeHelper, frmLoading frmLoading, IBienLaiHelper bienLaiHelper)
        {
            InitializeComponent();
            _sinhVienHelper = sinhVienHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
            _hopDongHelper = hopDongHelper;
            _xeHelper = xeHelper;
            _frmLoading = frmLoading;
            _bienLaiHelper = bienLaiHelper;
        }
        private void GetAccount(Sinhvien sinhvien)
        {
            txtCCCD.Text = sinhvien.Cccd;
            txtDiaChi.Text = sinhvien.Address;
            txtEmail.Text = sinhvien.Email;
            txtHoTen.Text = sinhvien.Name;
            if (sinhvien.Gender == true)
            {
                cbGioiTinh.Text = "Nam";
                imgSVNu.Visible = false;
                imgNo.Visible = false;
                imgSVNam.Visible = true;
            }
            else
            {
                cbGioiTinh.Text = "Nữ";
                imgSVNu.Visible = true;
                imgNo.Visible = false;
                imgSVNam.Visible = false;
            }
            txtMaSV.Text = sinhvien.MaSv;
            cbTruong.Text = sinhvien.Truong;
            txtSDT.Text = sinhvien.Sdt;
            dtNgaySinh.Value = sinhvien.BirthDay;
        }
        private void btnDangKyXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GlobalModel.IsAddXe = true;
            frmQLiXe frm = new frmQLiXe(_xeHelper, _sinhVienHelper, _phongHelper, _khuHelper, _truongHelper, _frmLoading);
            frm.ShowDialog();
        }

        private async void btnLapPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Add();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }

        private async void frmDKPhong_Load(object sender, EventArgs e)
        {
            cbKhu.Properties.Items.Clear();
            cbPhong.Properties.Items.Clear();
            cbTruong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                if (item.QuantityPeople < 8)
                {
                    cbPhong.Properties.Items.Add(item.Name);
                    cbKhu.Properties.Items.Add(item.NameKhu);
                }
            }
            foreach (var item in GlobalModel.ListTruong)
            {
                cbTruong.Properties.Items.Add(item.Name);
            }
            cbGioiTinh.Text = "Nam";
            txtEmailNV.Text = GlobalModel.Nhanvien.Email;
            txtTenNV.Text = GlobalModel.Nhanvien.Name;
            imgSVNu.Visible = false;
            imgNo.Visible = false;
            imgSVNam.Visible = true;
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

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cbKhu.Properties.Items.Clear();
            cbPhong.Properties.Items.Clear();
            cbTruong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                if (item.QuantityPeople < 8)
                {
                    cbPhong.Properties.Items.Add(item.Name);
                    cbKhu.Properties.Items.Add(item.NameKhu);
                }
            }
            foreach (var item in GlobalModel.ListTruong)
            {
                cbTruong.Properties.Items.Add(item.Name);
            }
            cbGioiTinh.Text = "Nam";
            imgSVNu.Visible = false;
            imgNo.Visible = false;
            imgSVNam.Visible = true;
            txtEmailNV.Text = GlobalModel.Nhanvien.Email;
            txtTenNV.Text = GlobalModel.Nhanvien.Name;
            txtCCCD.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtMaSV.Text = string.Empty;
            txtSDT.Text = string.Empty;
        }
        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGioiTinh.Text == "Nam")
            {
                imgSVNu.Visible = false;
                imgNo.Visible = false;

                imgSVNam.Visible = true;
            }
            else
            {
                imgSVNu.Visible = true;
                imgNo.Visible = false;
                imgSVNam.Visible = false;
            }
        }

        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            long intValue;
            if (long.TryParse(txtTim.EditValue.ToString(), out intValue))
            {
                _frmLoading.Show();
                await Search(txtTim.EditValue.ToString());
                _frmLoading.Hide();
                MessageBox.Show(messager);
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đúng CCCD!");
            }
        }
        private async Task Search(string nameSearch)
        {
            try
            {
                var resultSinhVien = await _sinhVienHelper.GetSinhVienByCCCD(nameSearch, Constant.Token);
                if (resultSinhVien.status == 200)
                {
                    GlobalModel.SinhVien.Id = resultSinhVien.data.FirstOrDefault().Id;
                    GlobalModel.SinhVien.Cccd = resultSinhVien.data.FirstOrDefault().Cccd;
                    GlobalModel.SinhVien.Address = resultSinhVien.data.FirstOrDefault().Address;
                    GlobalModel.SinhVien.Email = resultSinhVien.data.FirstOrDefault().Email;
                    GlobalModel.SinhVien.Name = resultSinhVien.data.FirstOrDefault().Name;
                    GlobalModel.SinhVien.BirthDay = resultSinhVien.data.FirstOrDefault().BirthDay;
                    GlobalModel.SinhVien.MaSv = resultSinhVien.data.FirstOrDefault().MaSv;
                    GlobalModel.SinhVien.Gender = resultSinhVien.data.FirstOrDefault().Gender;
                    if (resultSinhVien.data.FirstOrDefault().IdTruong != null)
                    {
                        var truong = await _truongHelper.GetTruong(resultSinhVien.data.FirstOrDefault().IdTruong, Constant.Token);
                        GlobalModel.SinhVien.Truong = truong.data.FirstOrDefault().Name;
                    }
                    GlobalModel.SinhVien.Sdt = resultSinhVien.data.FirstOrDefault().Sdt;
                    GetAccount(GlobalModel.SinhVien);
                }
                messager = resultSinhVien.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async Task Add()
        {
            try
            {
                SVP sVP = new SVP();
                sVP.idSV = GlobalModel.SinhVien.Id;
                foreach (var item in GlobalModel.ListPhong)
                {
                    if (cbPhong.Text == item.Name)
                    {
                        sVP.idPhong = item.Id;
                        GlobalModel.SinhVien.IdPhong = item.Id;
                        break;
                    }
                }
                var result = await _phongHelper.AddSinhVien(sVP, Constant.Token);
                messager = result.message;
                if (result.status == 200)
                {
                    Hopdong hopdong = new Hopdong();
                    hopdong.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
                    hopdong.IdNhanVien = GlobalModel.Nhanvien.Id;
                    hopdong.IdSinhVien = GlobalModel.SinhVien.Id;
                    hopdong.NgayBatDau = dtNgayVao.Value;
                    hopdong.NgayKetThuc = dtNgayHetHan.Value;
                    hopdong.IdPhong = GlobalModel.SinhVien.IdPhong;
                    var resultHopDong = await _hopDongHelper.AddHopDong(hopdong, Constant.Token);
                    Bienlai bienlai = new Bienlai();
                    bienlai.IdNhanVien = GlobalModel.Nhanvien.Id;
                    bienlai.IdSinhVien = GlobalModel.SinhVien.Id;
                    bienlai.NgayBatDau = dtNgayVao.Value;
                    bienlai.NgayHetHan = dtNgayHetHan.Value;
                    await _bienLaiHelper.AddBienLai(bienlai, Constant.Token);
                }
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

        }
    }
}