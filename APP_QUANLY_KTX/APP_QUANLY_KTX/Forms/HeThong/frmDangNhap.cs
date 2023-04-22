using ProjectQLKTX.Interface;
using ProjectQLKTX.Logins;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILoginHelper _loginHelper;
        private readonly IRoleHelper _roleHelper;
        private readonly frmLoading _frmLoading;
        private string message = "";
        bool IsCheck = false;
        public frmDangNhap(ILoginHelper loginHelper, IRoleHelper roleHelper, frmLoading frmLoading)
        {
            InitializeComponent();
            _loginHelper = loginHelper;
            _roleHelper = roleHelper;
            txtEmail.Text = (string)Properties.Settings.Default["Email"];
            txtPassword.Text = (string)Properties.Settings.Default["Password"];
            _frmLoading = frmLoading;
        }
        private void btnThoat_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn Thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }
        private void lbQuenMK_Click(object sender, EventArgs e)
        {
            frmQuenMK QuenMatKhau = new frmQuenMK();
            QuenMatKhau.Show();
            this.Hide();
        }

        private void cbHienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi.Checked)
            {
                txtPassword.PasswordChar = (char)0;
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private async void btnDangNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                _frmLoading.Show();
                await  Login();
                _frmLoading.Hide();
                MessageBox.Show(message);
                if(IsCheck ==true)
                {
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Kiểm Tra Thông Tin Đăng Nhập!");
            }
        }
        private async Task Login()
        {
            try
            {
                Account account = new Account();
                account.email = txtEmail.Text;
                account.password = txtPassword.Text;
                var login = await _loginHelper.Login(account);
                if (login.status == 200)
                {
                    Properties.Settings.Default["Email"] = txtEmail.Text;
                    Properties.Settings.Default["Password"] = txtPassword.Text;
                    Properties.Settings.Default.Save();
                    if (login.data.FirstOrDefault().IdRole != null)
                    {
                        var checkRole = await _roleHelper.GetRole(login.data.FirstOrDefault().IdRole);
                        if (checkRole.status == 200)
                        {
                            if (checkRole.data.FirstOrDefault().Name == "Admin")
                            {
                                GlobalModel.Nhanvien.IsAdmin = true;
                            }
                            else
                            {
                                GlobalModel.Nhanvien.IsAdmin = false;
                            }
                            GlobalModel.Nhanvien.Name = login.data.FirstOrDefault().Name;
                            GlobalModel.Nhanvien.Address = login.data.FirstOrDefault().Address;
                            GlobalModel.Nhanvien.Birthday = login.data.FirstOrDefault().Birthday;
                            GlobalModel.Nhanvien.Email = login.data.FirstOrDefault().Email;
                            GlobalModel.Nhanvien.Cccd = login.data.FirstOrDefault().Cccd;
                            GlobalModel.Nhanvien.Gender = login.data.FirstOrDefault().Gender;
                            GlobalModel.Nhanvien.Sdt = login.data.FirstOrDefault().Sdt;
                            GlobalModel.Nhanvien.CreateAt = login.data.FirstOrDefault().CreateAt;
                            GlobalModel.Nhanvien.Id = login.data.FirstOrDefault().Id;
                        }
                    }
                    IsCheck = true;
                    GlobalModel.IsLogin = true;
                }
                else
                {
                    IsCheck = false;
                }
                message = login.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void cbHienthi_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}