using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmChuyenPhong : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly ITruongHelper _truongHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private Sinhvien _sinhvien = new Sinhvien();
        private string messager = "Vui Lòng Thử Lại!";
        public frmChuyenPhong(frmLoading frmLoading, ISinhVienHelper sinhVienHelper, ITruongHelper truongHelper, IPhongHelper phongHelper, IKhuHelper khuHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _sinhVienHelper = sinhVienHelper;
            _truongHelper = truongHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
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

        private async void btnChuyenPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Edit();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task Edit()
        {
            try
            {
                var result = await _phongHelper.DeleteSinhVien(_sinhvien.Id, Constant.Token);
                if (result.status == 200)
                {
                    SVP sVP = new SVP();
                    sVP.idSV = GlobalModel.SinhVien.Id;
                    foreach (var item in GlobalModel.ListPhong)
                    {
                        if (cbChuyenToiPhong.Text == item.Name && cbPhongHienTai.Text == item.NameKhu)
                        {
                            sVP.idPhong = item.Id;
                            break;
                        }
                    }
                    var resultAdd = await _phongHelper.AddSinhVien(sVP, Constant.Token);
                    messager = resultAdd.message;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private void frmChuyenPhong_Load(object sender, EventArgs e)
        {
            cbChuyenToiKhu.Properties.Items.Clear();
            cbChuyenToiPhong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                if (item.QuantityPeople < 8)
                {
                    cbPhongHienTai.Properties.Items.Add(item.NameKhu);
                    cbChuyenToiPhong.Properties.Items.Add(item.Name);
                }
            }
        }
        private async Task Search(string nameSearch)
        {
            try
            {
                var resultSinhVien = await _sinhVienHelper.GetSinhVienByCCCD(nameSearch, Constant.Token);
                if (resultSinhVien.status == 200)
                {
                    _sinhvien.Id = resultSinhVien.data.FirstOrDefault().Id;
                    _sinhvien.Cccd = resultSinhVien.data.FirstOrDefault().Cccd;
                    _sinhvien.Address = resultSinhVien.data.FirstOrDefault().Address;
                    _sinhvien.Email = resultSinhVien.data.FirstOrDefault().Email;
                    _sinhvien.Name = resultSinhVien.data.FirstOrDefault().Name;
                    _sinhvien.BirthDay = resultSinhVien.data.FirstOrDefault().BirthDay;
                    if (resultSinhVien.data.FirstOrDefault().IdTruong != null)
                    {
                        var truong = await _truongHelper.GetTruong(resultSinhVien.data.FirstOrDefault().IdTruong, Constant.Token);
                        _sinhvien.Truong = truong.data.FirstOrDefault().Name;
                    }
                    _sinhvien.Sdt = resultSinhVien.data.FirstOrDefault().Sdt;
                    if (resultSinhVien.data.FirstOrDefault().IdPhong != null)
                    {
                        var phong = await _phongHelper.GetPhong(resultSinhVien.data.FirstOrDefault().IdPhong, Constant.Token);
                        if (phong.status == 200)
                        {
                            _sinhvien.Phong = phong.data.FirstOrDefault().Name;
                            if (phong.data.FirstOrDefault().IdKhu != null)
                            {
                                var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu, Constant.Token);
                                if (khu.status == 200)
                                {
                                    _sinhvien.Khu = khu.data.FirstOrDefault().Name;
                                }
                            }
                        }
                    }
                    _sinhvien.MaSv = resultSinhVien.data.FirstOrDefault().MaSv;
                    _sinhvien.Gender = resultSinhVien.data.FirstOrDefault().Gender;
                    GetAccount(_sinhvien);
                }
                messager = resultSinhVien.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private void GetAccount(Sinhvien sinhvien)
        {
            txtCCCD.Text = sinhvien.Cccd;
            txtDiaChi.Text = sinhvien.Address;
            txtHoTen.Text = sinhvien.Name;
            if (sinhvien.Gender == true)
            {
                cbGioiTinh.Text = "Nam";
                imgSVNu.Visible = false;
                imgSVNam.Visible = true;
            }
            else
            {
                cbGioiTinh.Text = "Nữ";
                imgSVNu.Visible = true;
                imgSVNam.Visible = false;
            }
            txtMaSV.Text = sinhvien.MaSv;
            cbTruong.Text = sinhvien.Truong;
            txtSDT.Text = sinhvien.Sdt;
            cbChuyenToiKhu.Text = sinhvien.Phong;
            cbKhuHienTai.Text = sinhvien.Khu;
            txtEmail.Text = sinhvien.Email;
            txtTenNV.Text = GlobalModel.Nhanvien.Name;
            dtNgaySinh.Text = sinhvien.BirthDay;
        }
        private void cbKhuHienTai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPhongHienTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbChuyenToiPhong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                if (cbPhongHienTai.Text == item.NameKhu && item.QuantityPeople < 8)
                {
                    cbChuyenToiPhong.Properties.Items.Add(item.Name);
                }
            }
        }

        private void cbChuyenToiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}