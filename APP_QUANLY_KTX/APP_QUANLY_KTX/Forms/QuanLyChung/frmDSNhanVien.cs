using DevExpress.DataAccess.Native.Json;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
        private Nhanvien account { get; set; }
        private async Task LoadAccount()
        {
            var result = await _nhanVienHelper.GetListNhanVien();
            try
            {
                if (result != null && result.status == 200)
                {

                    int i = 1;
                    GlobalModel.ListNhanVien.Clear();
                    GlobalModel.ListNhanVien = result.data;
                    foreach (var item in GlobalModel.ListNhanVien)
                    {
                        item.STT = i;
                        if (item.Gender == true)
                        {

                            item.GioiTinh = "Nam";
                        }
                        else
                        {
                            item.GioiTinh = "Nữ";
                        }
                        i++;
                    }
                    gcDanhSach.DataSource = GlobalModel.ListNhanVien;
                    gcDanhSach.RefreshDataSource();
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
        private async void frmDSNhanVien_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = GlobalModel.ListNhanVien;
            gcDanhSach.RefreshDataSource();
        }
        private async void GetAccount(Nhanvien nhanvien)
        {
            txtHoTen.Text = nhanvien.Name;
            txtEmail.Text = nhanvien.Email;
            txtDiaChi.Text = nhanvien.Address;
            try
            {
                dtNgayDangKy.Text = nhanvien.CreateAt.ToString();
                dtNgaySinh.Text = nhanvien.Birthday.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui Lòng Định Dạng Lại dd/mm/yyyy");
            }
            txtCCCD.Text = nhanvien.Cccd;
            txtSDT.Text = nhanvien.Sdt;
            cbGioiTinh.Text = nhanvien.GioiTinh;
            if (nhanvien.Gender == true)
            {
                imgNVNam.Visible = true;
                imgNVNu.Visible = false;
            }
            else
            {
                imgNVNam.Visible = false;
                imgNVNu.Visible = true;
            }
        }

        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nhanvien nhanvien = new Nhanvien();
            nhanvien.Id = Guid.NewGuid();
            nhanvien.Name = txtHoTen.Text;
            nhanvien.Password = txtEmail.Text;
            nhanvien.Email = txtEmail.Text;
            nhanvien.Address = txtDiaChi.Text;
            nhanvien.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
            nhanvien.Birthday = dtNgaySinh.Text;
            nhanvien.Cccd = txtCCCD.Text;
            nhanvien.Sdt = txtSDT.Text;
            if (cbGioiTinh.Text == "Nam")
            {
                nhanvien.Gender = true;
            }
            else
            {
                nhanvien.Gender = false;
            }
            var result = await _nhanVienHelper.AddNhanVien(nhanvien);
            LoadAccount();
            MessageBox.Show(result.message);
        }

        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            account.Name = txtHoTen.Text;
            account.Email = txtEmail.Text;
            account.Address = txtDiaChi.Text;
            account.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
            account.Birthday = dtNgaySinh.Text;
            account.Cccd = txtCCCD.Text;
            account.Sdt = txtSDT.Text;
            if (cbGioiTinh.Text == "Nam")
            {
                account.Gender = true;
            }
            else
            {
                account.Gender = false;
            }
            var result = await _nhanVienHelper.EditNhanVien(account);
            try
            {
                await LoadAccount();
                MessageBox.Show(result.message);
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + result);
                Log.Error(ex, ex.Message);
            }
        }

        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = await _nhanVienHelper.DeleteNhanVien(account.Id);
            try
            {
                gcDanhSach.DataSource = GlobalModel.ListNhanVien;
                gcDanhSach.RefreshDataSource();
                MessageBox.Show(result.message);
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + result);
                Log.Error(ex, ex.Message);
            }
        }

        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await LoadAccount();
        }

        private void gcDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (
                          (sender is GridControl control) &&
                          (control.MainView is GridView gridView) &&
                          (e is DXMouseEventArgs args))
                {
                    var hittest = gridView.CalcHitInfo(args.Location);
                    var s = hittest.RowHandle;
                    account = GlobalModel.ListNhanVien[s];
                    GetAccount(account);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}