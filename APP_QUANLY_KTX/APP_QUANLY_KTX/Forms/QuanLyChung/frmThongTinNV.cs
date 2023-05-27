using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmThongTinNV : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly INhanVienHelper _nhanVienHelper;
        private string messager = "Vui Lòng Thử Lại!";
        public frmThongTinNV(frmLoading frmLoading, INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _nhanVienHelper = nhanVienHelper;
        }
        private async void GetAccount(Nhanvien nhanvien)
        {
            txtHoTen.Text = nhanvien.Name;
            txtEmail.Text = nhanvien.Email;
            txtDiaChi.Text = nhanvien.Address;
            txtCCCD.Text = nhanvien.Cccd;
            txtSDT.Text = nhanvien.Sdt;
            cbGioiTinh.Text = nhanvien.GioiTinh;
            if (nhanvien.Gender == true)
            {
                imgNVNam.Visible = true;
                imgNVNu.Visible = false;
                cbGioiTinh.Text = "Nam";
            }
            else
            {
                imgNVNam.Visible = false;
                imgNVNu.Visible = true;
                cbGioiTinh.Text = "Nữ";
            }
            try
            {
                dtNgayDangKy.Text = nhanvien.CreateAt.ToString();
                dtNgaySinh.Text = nhanvien.Birthday.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui Lòng Định Dạng Lại dd/mm/yyyy");
            }

        }
        private void frmThongTinNV_Load(object sender, EventArgs e)
        {
            GetAccount(GlobalModel.Nhanvien);
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
            try
            {
                GlobalModel.Nhanvien.Name = txtHoTen.Text;
                GlobalModel.Nhanvien.Email = txtEmail.Text;
                GlobalModel.Nhanvien.Birthday = dtNgaySinh.Value;
                GlobalModel.Nhanvien.Cccd = txtCCCD.Text;
                GlobalModel.Nhanvien.Address = txtDiaChi.Text;
                GlobalModel.Nhanvien.Sdt = txtSDT.Text;
                GlobalModel.Nhanvien.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
                var result = await _nhanVienHelper.EditNhanVien(GlobalModel.Nhanvien, Constant.Token);
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
    }
}