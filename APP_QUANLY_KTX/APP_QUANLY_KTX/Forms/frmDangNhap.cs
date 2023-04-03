using ProjectQLKTX.Interface;
using ProjectQLKTX.Logins;
using ProjectQLKTX.Models;

namespace ProjectQLKTX
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILoginHelper _loginHelper;
        public frmDangNhap(ILoginHelper loginHelper)
        {
            InitializeComponent();
            _loginHelper = loginHelper;
        }

        private void cb_Hienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Hienthi.Checked)
            {
                txtPassword.PasswordChar = (char)0;
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private async void btn_Dangnhap_CheckedChanged(object sender, EventArgs e)
        {
            Account account = new Account();
            account.email = txtEmail.Text;
            account.password = txtPassword.Text;
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                var login = await _loginHelper.Login(account);
                if (login.status == 200)
                {
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(login.message);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Kiểm Tra Thông Tin Đăng Nhập!");
            }
        }
    }
}