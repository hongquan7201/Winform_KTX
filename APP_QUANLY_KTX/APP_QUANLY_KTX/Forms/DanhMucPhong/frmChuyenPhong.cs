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
           _frmLoading?.Show();
            await Edit();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task Edit()
        {
            try
            {
                foreach (var phong in GlobalModel.ListPhong)
                {
                    if (cbChuyenToiPhong.Text == phong.Name)
                    {
                        _sinhvien.IdPhong = phong.Id;
                        break;
                    }
                }
                var result = await _sinhVienHelper.EditSinhVien(_sinhvien.Id,_sinhvien);
                messager = result.message;
            }
            catch(Exception ex)
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
                    cbChuyenToiKhu.Properties.Items.Add(item.NameKhu);
                    cbChuyenToiPhong.Properties.Items.Add(item.Name);
                }
            }
        }
        private async Task Search(string nameSearch)
        {
            try
            {
                var resultSinhVien = await _sinhVienHelper.GetSinhVienByCCCD(nameSearch);
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
                        var truong = await _truongHelper.GetTruong(resultSinhVien.data.FirstOrDefault().IdTruong);
                        _sinhvien.Truong = truong.data.FirstOrDefault().Name;
                    }
                    _sinhvien.Sdt = resultSinhVien.data.FirstOrDefault().Sdt;
                    if (resultSinhVien.data.FirstOrDefault().IdPhong != null)
                    {
                        var phong = await _phongHelper.GetPhong(resultSinhVien.data.FirstOrDefault().IdPhong);
                        if (phong.status == 200)
                        {
                            _sinhvien.Phong = phong.data.FirstOrDefault().Name;
                            if (phong.data.FirstOrDefault().IdKhu != null)
                            {
                                var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu);
                                if (khu.status == 200)
                                {
                                    _sinhvien.Khu = khu.data.FirstOrDefault().Name;
                                }
                            }
                        }
                    }
                    _sinhvien.CreateAt = resultSinhVien.data.FirstOrDefault().CreateAt;

                    GetAccount(GlobalModel.SinhVien);
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
            dtNgaySinh.Text = sinhvien.BirthDay;
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
            cbPhongHienTai.Text = sinhvien.Phong;
            cbKhuHienTai.Text = sinhvien.Khu;
        }
    }
}