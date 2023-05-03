using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmQLiXe : DevExpress.XtraEditors.XtraForm
    {
        private readonly IXeHelper _xeHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        private Xe account;
        private List<Truong> _listTruong = new List<Truong>();
        private async void GetAccount(Xe xe)
        {
            cbTruong.Text = xe.Truong;
            txtMaSV.Text = xe.MaSv;
            txtHoTen.Text = xe.NameUser;
            txtDiaChi.Text = xe.Address;
            cbKhu.Text = xe.NameKhu;
            try
            {
                if (xe.CreateAt != null)
                {
                    dtNgayDangKy.Text = xe.CreateAt.ToString();
                }
                if (!string.IsNullOrEmpty(xe.BirthDay))
                {
                    dtNgaySinh.Text = xe.BirthDay.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui Lòng Định Dạng Lại dd/mm/yyyy");
            }
            txtCCCD.Text = xe.Cccd;
            txtSDT.Text = xe.Sdt;
            cbGioiTinh.Text = xe.GioiTinh;
            if (xe.Gender == true)
            {
                imgSVNam.Visible = true;
                imgSVNu.Visible = false;
                imgNo.Visible = false;
            }
            else
            {
                imgSVNam.Visible = false;
                imgSVNu.Visible = true;
                imgNo.Visible = false;
            }
            txtBSoXe.Text = xe.Code;
            txtMauXe.Text = xe.Color;
            txtTenXe.Text = xe.Name;
        }
        public frmQLiXe(IXeHelper xeHelper, ISinhVienHelper sinhVienHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper)
        {
            InitializeComponent();
            _xeHelper = xeHelper;
            _sinhVienHelper = sinhVienHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
        }
        private async Task LoadXe(List<Xe> listXe)
        {
            var list = await _xeHelper.GetListXe();
            if (list.status == 200)
            {
                listXe.Clear();
                int i = 1;
                foreach (var item in list.data)
                {
                    if (item.IdUser != null)
                    {
                        var user = await _sinhVienHelper.GetSinhVienById(item.IdUser);
                        if (user.status == 200)
                        {
                            item.NameUser = user.data.FirstOrDefault().Name;
                            item.Address = user.data.FirstOrDefault().Address;
                            item.Cccd = user.data.FirstOrDefault().Cccd;
                            item.Sdt = user.data.FirstOrDefault().Sdt;
                            item.Gender = user.data.FirstOrDefault().Gender;
                            if (item.Gender == true)
                            {
                                item.GioiTinh = "Nam";
                            }
                            else
                            {
                                item.GioiTinh = "Nữ";
                            }
                            item.BirthDay = user.data.FirstOrDefault().BirthDay;
                            item.IdPhong = user.data.FirstOrDefault().IdPhong;
                            if (item.IdPhong != null)
                            {
                                var resultPhong = await _phongHelper.GetPhong(item.IdPhong);
                                if (resultPhong.status == 200)
                                {
                                    item.IdKhu = resultPhong.data.FirstOrDefault().IdKhu;
                                    if (item.IdKhu != null)
                                    {
                                        var resultKhu = await _khuHelper.GetKhu(item.IdKhu);
                                        if (resultKhu.status == 200)
                                        {
                                            item.NameKhu = resultKhu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                            if (user.data.FirstOrDefault().IdTruong != null)
                            {
                                var resultTruong = await _truongHelper.GetTruong(user.data.FirstOrDefault().IdTruong);
                                if (resultTruong.status == 200)
                                {
                                    item.Truong = resultTruong.data.FirstOrDefault().Name;
                                }
                            }
                        }
                        item.STT = i;
                        listXe.Add(item);
                        i++;
                    }
                }
                gcDanhSach.DataSource = listXe;
                gcDanhSach.RefreshDataSource();
            }
        }

        private async void frmQLiXe_Load(object sender, EventArgs e)
        {
            if (GlobalModel.IsAddXe == true)
            {
                txtHoTen.Text = GlobalModel.SinhVien.Name;
                txtDiaChi.Text = GlobalModel.SinhVien.Address;
                txtCCCD.Text = GlobalModel.SinhVien.Cccd;
                txtMaSV.Text = GlobalModel.SinhVien.MaSv;
                dtNgaySinh.Text = GlobalModel.SinhVien.BirthDay;
                txtSDT.Text = GlobalModel.SinhVien.Sdt;
                cbTruong.Text = GlobalModel.SinhVien.Truong;
                if (GlobalModel.SinhVien.Gender == true)
                {
                    cbGioiTinh.Text = "Nam";
                    imgSVNam.Visible = true;
                    imgNo.Visible = false;
                    imgSVNu.Visible = false;
                }
                else
                {
                    cbGioiTinh.Text = "Nữ";
                    imgSVNam.Visible = false;
                    imgNo.Visible = false;
                    imgSVNu.Visible = true;
                }
            }
            var resultTruong = await _truongHelper.GetListTruong();
            if (resultTruong.status == 200)
            {
                cbTruong.Properties.Items.Clear();
                foreach (var item in resultTruong.data)
                {
                    cbTruong.Properties.Items.Add(item.Name);
                    _listTruong.Add(item);
                }
            }
            gcDanhSach.DataSource = GlobalModel.ListXe;
            gcDanhSach.RefreshDataSource();
            GlobalModel.IsAddXe = false;
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
                    account = GlobalModel.ListXe[s];
                    GetAccount(account);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async Task SearchSinhVien(List<Xe> listSinhVien, string nameSearch)
        {
            APIRespone<List<Sinhvien>> resultSinhVien = new APIRespone<List<Sinhvien>>();
            long intValue;
            if (long.TryParse(nameSearch, out intValue))
            {
                resultSinhVien = await _sinhVienHelper.GetSinhVienByCCCD(nameSearch);
            }
            else
            {
                resultSinhVien = await _sinhVienHelper.GetSinhVienByName(nameSearch);
            }
            if (resultSinhVien.status == 200)
            {
                List<Xe> lstXe = new List<Xe>();
                foreach (var item in listSinhVien)
                {
                    lstXe.Add(item);
                }
                listSinhVien.Clear();
                int i = 1;
                foreach (var item in resultSinhVien.data)
                {
                    Xe xe = new Xe();
                    xe.Address = item.Address;
                    xe.Cccd = item.Cccd;
                    xe.NameUser = item.Name;
                    xe.Sdt = item.Sdt;
                    xe.BirthDay = item.BirthDay;
                    xe.IdUser = item.Id;
                    if (xe.IdUser != null)
                    {
                        foreach (var indexXe in lstXe)
                        {
                            if (indexXe.IdUser == item.Id)
                            {
                                xe.Name = indexXe.Name;
                                xe.Color = indexXe.Color;
                                xe.Code = indexXe.Code;
                                xe.CreateAt = indexXe.CreateAt;
                                xe.Id = indexXe.Id;
                            }
                        }
                    }
                    if (item.IdPhong != null)
                    {
                        var resultPhong = await _phongHelper.GetPhong(item.IdPhong);
                        if (resultPhong.status == 200)
                        {
                            if (resultPhong.data.FirstOrDefault().IdKhu != null)
                            {
                                var resultKhu = await _khuHelper.GetKhu(resultPhong.data.FirstOrDefault().IdKhu);
                                if (resultKhu.status == 200)
                                {
                                    xe.NameKhu = resultKhu.data.FirstOrDefault().Name;
                                }
                            }
                        }
                    }
                    if (item.IdTruong != null)
                    {
                        var resultTruong = await _truongHelper.GetTruong(item.IdTruong);
                        if (resultTruong.status == 200)
                        {
                            xe.Truong = resultTruong.data.FirstOrDefault().Name;
                        }
                    }
                    xe.STT = i;
                    listSinhVien.Add(xe);
                    i++;
                }
            }
            else
            {
                MessageBox.Show(resultSinhVien.message);
            }

        }

        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await SearchSinhVien(GlobalModel.ListXe, txtTim.EditValue.ToString());
            gcDanhSach.DataSource = GlobalModel.ListXe;
            gcDanhSach.RefreshDataSource();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadXe(GlobalModel.ListXe);
        }

        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var resultDelete = await _xeHelper.DeleteXe(account.Id);
            if (resultDelete.status == 200)
            {
                await LoadXe(GlobalModel.ListXe);
                txtTenXe.Text = string.Empty;
                cbTruong.Text = _listTruong[0].Name;
                txtMaSV.Text = string.Empty;
                txtHoTen.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                cbKhu.Text = string.Empty;
                dtNgayDangKy.Text = DateTime.Now.ToString();
                dtNgaySinh.Text = DateTime.Now.ToString();
                txtCCCD.Text = string.Empty;
                txtSDT.Text = string.Empty;
                cbGioiTinh.Text = "Nam";
                imgSVNam.Visible = false;
                imgSVNu.Visible = false;
                imgNo.Visible = true;
                txtBSoXe.Text = string.Empty;
                txtMauXe.Text = string.Empty;
                txtTenXe.Text = string.Empty;
            }

            MessageBox.Show(resultDelete.message);
        }

        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xe xe = new Xe();
            xe.Id = account.Id;
            xe.IdUser = account.IdUser;
            xe.Name = txtTenXe.Text;
            xe.Color = txtMauXe.Text;
            xe.Code = txtBSoXe.Text;
            xe.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
            var resultEdit = await _xeHelper.EditXe(xe);
            if (resultEdit.status == 200)
            {
                await LoadXe(GlobalModel.ListXe);
            }
            MessageBox.Show(resultEdit.message);


        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}