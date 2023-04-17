using ProjectQLKTX.Interface;
using ProjectQLKTX.Logins;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILoginHelper _loginHelper;
        private readonly Home _home;
        private readonly IRoleHelper _roleHelper;
        public frmDangNhap(ILoginHelper loginHelper, Home home, IRoleHelper roleHelper)
        {
            InitializeComponent();
            _loginHelper = loginHelper;
            _home = home;
            _roleHelper = roleHelper;
          txtEmail.Text = (string)Properties.Settings.Default["Email"];
          txtPassword.Text = (string) Properties.Settings.Default["Password"] ;
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

        private async void btnDangNhap_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                //Account account = new Account();
                //account.email = txtEmail.Text;
                //account.password = txtPassword.Text;
                //if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                //{
                //    var login = await _loginHelper.Login(account);
                //    if (login.status == 200)
                //    {
                //        Properties.Settings.Default["Email"] = txtEmail.Text;
                //        Properties.Settings.Default["Password"] = txtPassword.Text;
                //        Properties.Settings.Default.Save();
                //        if (login.data.IdRole != null)
                //        {
                //            var checkRole = await _roleHelper.GetRole(login.data.IdRole);
                //            if (checkRole.status == 200)
                //            {
                //                if (checkRole.data.FirstOrDefault().Name == "Admin")
                //                {
                //                    GlobalModel.Nhanvien.IsAdmin = true;
                //                }
                //                else
                //                {
                //                    GlobalModel.Nhanvien.IsAdmin = false;
                //                    GlobalModel.Nhanvien.Name = login.data.Name;
                //                    GlobalModel.Nhanvien.Address = login.data.Address;
                //                    GlobalModel.Nhanvien.Birthday = login.data.Birthday;
                //                    GlobalModel.Nhanvien.Email = login.data.Email;
                //                    GlobalModel.Nhanvien.Cccd = login.data.Cccd;
                //                    GlobalModel.Nhanvien.Gender = login.data.Gender;
                //                    GlobalModel.Nhanvien.Sdt = login.data.Sdt;
                //                    GlobalModel.Nhanvien.CreateAt = login.data.CreateAt;
                //                }
                //            }
                _home.Show();
                this.Hide();
                //        }
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
            catch(Exception ex)
            {
                Log.Error(ex,ex.Message);
                MessageBox.Show(ex.Message);
            }
         
        }
    }
}