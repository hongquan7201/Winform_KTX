using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmTraPhong : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        private Sinhvien _sinhvien = new Sinhvien();
        private string messager = "Vui Lòng Thử Lại!";
        public frmTraPhong(frmLoading frmLoading, ISinhVienHelper sinhVienHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _sinhVienHelper = sinhVienHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
        }

        private async void btnTraPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = await _phongHelper.DeleteSinhVien(_sinhvien.Id, Constant.Token);
            MessageBox.Show(result.message);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmTraPhong_Load(object sender, EventArgs e)
        {
            imgNo.Visible = true;
            imgSVNam.Visible = false;
            imgSVNu.Visible = false;
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
            dtNgayVao.Text = sinhvien.CreateAt.ToString();
            dtNgayRa.Text = DateTime.Now.ToString();
            cbPhong.Text = sinhvien.Phong;
            cbKhu.Text = sinhvien.Khu;
        }
    }
}