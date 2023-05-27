using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly INhanVienHelper _nhanVienHelper;
        private string messager = "Vui Lòng Thử Lại!";
        public frmDoiMK(frmLoading frmLoading, INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _nhanVienHelper = nhanVienHelper;
        }
        private void btnThoat_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbHienthi1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi1.Checked)
            {
                txtPasswordCu.PasswordChar = (char)0;
            }
            else
            {
                txtPasswordCu.PasswordChar = '*';
            }
        }

        private void cbHienthi2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi2.Checked)
            {
                txtPasswordMoi.PasswordChar = (char)0;
            }
            else
            {
                txtPasswordMoi.PasswordChar = '*';
            }
        }

        private void cbHienthi3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi3.Checked)
            {
                txtNhapLaiPassword.PasswordChar = (char)0;
            }
            else
            {
                txtNhapLaiPassword.PasswordChar = '*';
            }
        }

        private async void btnDongY_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string pass = (string)Properties.Settings.Default["Password"];
                if (txtPasswordCu.Text == pass && txtPasswordMoi.Text == txtNhapLaiPassword.Text)
                {
                    if(txtPasswordMoi.Text.Length > 8)
                    {
                        _frmLoading.Show();
                        await Edit(pass);
                        _frmLoading.Hide();
                        MessageBox.Show(messager);
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Nhập Mật Khẩu Trên 8 Ký Tự Trở Lên!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Nhập Đúng Thông Tin!");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

        }
        private async Task Edit(string pass)
        {
            try
            {
                ChangePasswordNhanVien nhanvien = new ChangePasswordNhanVien();
                nhanvien.idNhanVien = GlobalModel.Nhanvien.Id;
                nhanvien.oldPassword = pass;
                nhanvien.newPassword = txtPasswordMoi.Text;
                var result = await _nhanVienHelper.ChangePassword(nhanvien, Constant.Token);
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        private void pictureEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}