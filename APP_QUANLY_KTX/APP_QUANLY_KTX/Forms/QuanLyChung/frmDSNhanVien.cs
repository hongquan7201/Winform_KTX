using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmDSNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private readonly INhanVienHelper _nhanVienHelper;
        public frmDSNhanVien(INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
        }
        List<Nhanvien> listNhanVien = new List<Nhanvien>();
        private async void frmDSNhanVien_Load(object sender, EventArgs e)
        {
            var result = await _nhanVienHelper.GetListNhanVien();
            try
            {
                if (result != null && result.status == 200)
                {
                    listNhanVien = result.data;
                    txtHoTen.Text = listNhanVien[0].name;
                    txtEmail.Text = listNhanVien[0].email;
                    txtCCCD.Text = listNhanVien[0].cccd;
                    txtDiaChi.Text = listNhanVien[0].address;
                    txtSDT.Text = listNhanVien[0].sdt;
                }
                else
                {
                    MessageBox.Show(result.message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + result);
                Log.Error(ex, ex.Message);
            }
        }
    }
}