using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmQuenMK : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly INhanVienHelper _nhanVienHelper;
        private string message = "Vui Lòng Thử Lại!";
        public frmQuenMK(frmLoading frmLoading, INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _nhanVienHelper = nhanVienHelper;
        }

        private async void btnLayLaiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtCCCD.Text == GlobalModel.Nhanvien.Cccd && txtEmail.Text == GlobalModel.Nhanvien.Cccd)
            {
                _frmLoading.Show();
                await Reset(txtEmail.Text);
                _frmLoading.Hide();
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Thông Tin!");
            }
        }

        private void lbQLaiDN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private async Task Reset(string email)
        {
            try
            {
                var result = await _nhanVienHelper.ResetPassword(email);
                if (result.status == 200)
                {
                    message = "Reset Thành Công! Vui Lòng Check Email Để Nhận Password! Để Đăng Nhập!";
                }
                else
                {
                    message = result.message;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

        }

        private void btnLayLaiMK_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}