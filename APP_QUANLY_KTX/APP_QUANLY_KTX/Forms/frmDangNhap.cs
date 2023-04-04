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
            if (cbHienthi.Checked)
            {
                txtMatkhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatkhau.PasswordChar = '*';
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
            Home home = new Home();
            home.Show();
            //this.Hide();
        }
        private void btnThoat_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn Thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                this.Close();
            Environment.Exit(Environment.ExitCode);
        }
        private void btnLoad_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void lbQuenMK_Click(object sender, EventArgs e)
        {
            frmQuenMK QuenMatKhau = new frmQuenMK();
            QuenMatKhau.ShowDialog();
        }
    }
}