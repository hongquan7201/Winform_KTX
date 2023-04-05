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
            //var s = await _nhanVienHelper.GetListNhanVien();
            //var x = await _nhanVienHelper.GetNhanVien(Guid.Parse("b991f15c-1e25-4b5c-9a2b-efd846c37c76"));
            //x.data.name = "LamLe03001";
            // x.data.cccd = "123456789";
            //var edit = await _nhanVienHelper.EditNhanVien(x.data.id, x.data);
            //var result = await _nhanVienHelper.GetNhanVien(x.data.id);
            //Account account = new Account();
            //account.email = txtEmail.Text;
            //account.password = txtMatkhau.Text;
            //if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtMatkhau.Text))
            //{
            //    var login = await _loginHelper.Login(account);
            //    if (login.status == 200)
            //    {
            Home home = new Home();
            home.Show();
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