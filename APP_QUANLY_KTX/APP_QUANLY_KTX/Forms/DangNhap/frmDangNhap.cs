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
        private void btnThoat_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn Thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                this.Close();
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

        private void btnDangNhap_CheckedChanged_1(object sender, EventArgs e)
        {
            //Account account = new Account();
            //account.email = txtEmail.Text;
            //account.password = txtMatkhau.Text;
            //if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtMatkhau.Text))
            //{
            //    var login = await _loginHelper.Login(account);
            //    if (login.status == 200)
            //    {

            _home.Show();
            this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show(login.message);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui Lòng Kiểm Tra Thông Tin Đăng Nhập!");
            //}
        }
    }
}