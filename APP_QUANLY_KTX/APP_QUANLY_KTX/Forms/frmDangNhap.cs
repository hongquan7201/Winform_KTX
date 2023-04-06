using ProjectQLKTX.Interface;
using ProjectQLKTX.Logins;
using ProjectQLKTX.Models;

namespace ProjectQLKTX
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILoginHelper _loginHelper;
        private readonly Home _home;
        public frmDangNhap(ILoginHelper loginHelper, Home home)
        {
            InitializeComponent();
            _loginHelper = loginHelper;
            _home = home;
        }

        public frmDangNhap()
        {
        }

        private void cb_Hienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi.Checked)
            {
                txtMatkhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatkhau.PasswordChar = '*';
                txtMatkhau.PasswordChar = (char)0;
            }
           
        }
        private async void btn_Dangnhap_CheckedChanged(object sender, EventArgs e)
        {
            Account account = new Account();
            account.email = txtEmail.Text;
            account.password = txtMatkhau.Text;
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtMatkhau.Text))
            {
                var login = await _loginHelper.Login(account);
                if (login.status == 200)
                {

                    _home.Show();
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
        private void btnThoat_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn Thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                this.Close();
            Environment.Exit(Environment.ExitCode);
        }     
        private void lbQuenMK_Click(object sender, EventArgs e)
        {
            frmQuenMK QuenMatKhau = new frmQuenMK(); 
            QuenMatKhau.ShowDialog();
        }
    }
}