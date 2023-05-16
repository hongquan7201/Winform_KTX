using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Files;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace ProjectQLKTX
{
    public partial class frmDSNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRoleHelper _roleHelper;
        private readonly INhanVienHelper _nhanVienHelper;
        private readonly frmLoading _frmLoading;
        private string messager = "";
        public frmDSNhanVien(INhanVienHelper nhanVienHelper, frmLoading frmLoading, IRoleHelper roleHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
            _frmLoading = frmLoading;
            _roleHelper = roleHelper;
        }
        private Nhanvien account = new Nhanvien();
        private async Task LoadAccount(List<Nhanvien> listNhanVien)
        {
            var result = await _nhanVienHelper.GetListNhanVien(Constant.Token);
            try
            {
                if (result != null && result.status == 200)
                {
                    int i = 1;
                    listNhanVien.Clear();
                    foreach (var item in result.data)
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
                        if (item.IdRole != null)
                        {
                            var role = await _roleHelper.GetRole(item.IdRole);
                            if (role.status == 200)
                            {
                                item.NameRole = role.data.FirstOrDefault().Name;
                            }
                        }
                        listNhanVien.Add(item);
                        i++;
                    }
                    gcDanhSach.DataSource = listNhanVien;
                    gcDanhSach.RefreshDataSource();
                    lbDem.Text = listNhanVien.Count.ToString();
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
            lbDem.Text = GlobalModel.ListNhanVien.Count.ToString();
            foreach (var item in GlobalModel.ListRole)
            {
                cbChucVu.Text = item.Name;
            }
        }
        private async void GetAccount(Nhanvien nhanvien)
        {
            txtHoTen.Text = nhanvien.Name;
            txtEmail.Text = nhanvien.Email;
            txtDiaChi.Text = nhanvien.Address;
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
            cbChucVu.Text = nhanvien.NameRole;
            try
            {
                dtNgayDangKy.Text = nhanvien.CreateAt.Value.Day + "/" + nhanvien.CreateAt.Value.Month + "/" + nhanvien.CreateAt.Value.Year;
                dtNgaySinh.Text = nhanvien.Birthday;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui Lòng Định Dạng Lại dd/mm/yyyy");
            }
        }

        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await AddNhanVien();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task AddNhanVien()
        {
            try
            {
                Nhanvien nhanvien = new Nhanvien();
                nhanvien.Name = txtHoTen.Text;
                nhanvien.Password = txtEmail.Text;
                nhanvien.Email = txtEmail.Text;
                nhanvien.Address = txtDiaChi.Text;
                nhanvien.Cccd = txtCCCD.Text;
                nhanvien.Sdt = txtSDT.Text;
                foreach (var item in GlobalModel.ListRole)
                {
                    if (item.Name == cbChucVu.Text)
                    {
                        nhanvien.IdRole = item.Id;
                        break;
                    }
                }
                if (cbGioiTinh.Text == "Nam")
                {
                    nhanvien.Gender = true;
                }
                else
                {
                    nhanvien.Gender = false;
                }
                var result = await _nhanVienHelper.AddNhanVien(nhanvien, Constant.Token);
                if (result.status == 200)
                {
                    await LoadAccount(GlobalModel.ListNhanVien);
                }
                nhanvien.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
                nhanvien.Birthday = dtNgaySinh.Text;
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                messager = ex.Message;
            }
        }
        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Edit();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task Edit()
        {
            try
            {
                Nhanvien nhanvien = new Nhanvien();
                nhanvien.Id = account.Id;
                nhanvien.Name = txtHoTen.Text;
                nhanvien.Email = txtEmail.Text;
                nhanvien.Address = txtDiaChi.Text;
                nhanvien.Cccd = txtCCCD.Text;
                foreach (var item in GlobalModel.ListRole)
                {
                    if (item.Name == cbChucVu.Text)
                    {
                        nhanvien.IdRole = item.Id;
                        break;
                    }
                }
                nhanvien.Sdt = txtSDT.Text;
                if (cbGioiTinh.Text == "Nam")
                {
                    nhanvien.Gender = true;
                }
                else
                {
                    nhanvien.Gender = false;
                }
                var result = await _nhanVienHelper.EditNhanVien(account, Constant.Token);
                if (result.status == 200)
                {
                    await LoadAccount(GlobalModel.ListNhanVien);
                }
                nhanvien.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
                nhanvien.Birthday = dtNgaySinh.Text;
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Delete();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task Delete()
        {
            try
            {
                var result = await _nhanVienHelper.DeleteNhanVien(account.Id, Constant.Token);
                if (result.status == 200)
                {
                    await LoadAccount(GlobalModel.ListNhanVien);
                }
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                messager = ex.Message;
            }
        }
        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadAccount(GlobalModel.ListNhanVien);
            _frmLoading.Hide();
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

        private void btnInfilePDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportPDF(gcDanhSach, "DanhSachNhanVien");
        }

        private void btnXuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportExcel(gcDanhSach, "DanhSachNhanVien");
        }

        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTim.EditValue.ToString()))
            {
                _frmLoading.Show();
                await Search(GlobalModel.ListNhanVien, txtTim.EditValue.ToString());
                _frmLoading.Hide();
                MessageBox.Show(messager);
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Tên Nhân Viên Cần Tìm!");
            }
        }
        private async Task Search(List<Nhanvien> listNhanVien, string nameFind)
        {
            try
            {
                var result = await _nhanVienHelper.GetNhanVienByName(nameFind, Constant.Token);
                if (result.data.Count > 0)
                {
                    listNhanVien.Clear();
                    int i = 1;
                    foreach (var item in result.data)
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
                        listNhanVien.Add(item);
                        i++;
                    }
                }
                gcDanhSach.DataSource = listNhanVien;
                gcDanhSach.RefreshDataSource();
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                messager = ex.Message;
            }
        }
        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGioiTinh.Text == "Nam")
            {
                imgNVNam.Visible = true;
                imgNVNu.Visible = false;
                imgNo.Visible = false;
            }
            else
            {
                imgNVNam.Visible = false;
                imgNVNu.Visible = true;
                imgNo.Visible = false;
            }
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}