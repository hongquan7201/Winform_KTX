using ProjectQLKTX.Interface;

namespace ProjectQLKTX
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private readonly INhanVienHelper _nhanVienHelper;
        public frmDangNhap(INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
            //  _bienLaiHelper = bienLaiHelper;
        }

        private void cb_Hienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Hienthi.Checked)
            {
                txt_password.PasswordChar = (char)0;
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }

        private async void btn_Dangnhap_CheckedChanged(object sender, EventArgs e)
        {
            //var s = await _nhanVienHelper.GetListNhanVien();
            var x = await _nhanVienHelper.GetNhanVien(Guid.Parse("b991f15c-1e25-4b5c-9a2b-efd846c37c76"));
            x.data.name = "LamLe03001";
            x.data.cccd = "123456789";
            var edit = await _nhanVienHelper.EditNhanVien(x.data.id, x.data);
            var result = await _nhanVienHelper.GetNhanVien(x.data.id);
            //Home home = new Home();
            //home.Show();
            //this.Hide();
        }
    }
}