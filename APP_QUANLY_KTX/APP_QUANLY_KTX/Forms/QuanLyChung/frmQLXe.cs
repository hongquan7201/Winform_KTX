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
        private readonly frmLoading _frmLoading;
        private Xe account;
        private List<Truong> _listTruong = new List<Truong>();
        private string messager = "Vui Lòng Thử Lại";
        private async void GetAccount(Xe xe)
        {
            cbGioiTinh.Text = xe.GioiTinh;
            cbTruong.Text = xe.Truong;
            txtMaSV.Text = xe.MaSv;
            txtHoTen.Text = xe.NameUser;
            txtDiaChi.Text = xe.Address;
            cbKhu.Text = xe.NameKhu;
            txtCCCD.Text = xe.Cccd;
            txtSDT.Text = xe.Sdt;
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
            if (xe.CreateAt != null)
            {
                dtNgayDangKy.Text = xe.CreateAt.ToString();
            }
            try
            {
                if (!string.IsNullOrEmpty(xe.BirthDay))
                {
                    dtNgaySinh.Text = xe.BirthDay;
                }
            }catch(Exception ex)
            {

            }
         
        }
        public frmQLiXe(IXeHelper xeHelper, ISinhVienHelper sinhVienHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper, frmLoading frmLoading)
        {
            InitializeComponent();
            _xeHelper = xeHelper;
            _sinhVienHelper = sinhVienHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
            _frmLoading = frmLoading;
        }
        private async Task LoadXe(List<Xe> listXe)
        {
            var list = await _xeHelper.GetListXe(Constant.Token);
            if (list.status == 200)
            {
                listXe.Clear();
                int i = 1;
                foreach (var item in list.data)
                {
                    if (item.IdUser != null)
                    {
                        var user = await _sinhVienHelper.GetSinhVienById(item.IdUser, Constant.Token);
                        if (user.status == 200)
                        {
                            item.NameUser = user.data.FirstOrDefault().Name;
                            item.Address = user.data.FirstOrDefault().Address;
                            item.Cccd = user.data.FirstOrDefault().Cccd;
                            item.Sdt = user.data.FirstOrDefault().Sdt;
                            item.MaSv = user.data.FirstOrDefault().MaSv;
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
                                var resultPhong = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
                                if (resultPhong.status == 200)
                                {
                                    item.IdKhu = resultPhong.data.FirstOrDefault().IdKhu;
                                    if (item.IdKhu != null)
                                    {
                                        var resultKhu = await _khuHelper.GetKhu(item.IdKhu, Constant.Token);
                                        if (resultKhu.status == 200)
                                        {
                                            item.NameKhu = resultKhu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                            if (user.data.FirstOrDefault().IdTruong != null)
                            {
                                var resultTruong = await _truongHelper.GetTruong(user.data.FirstOrDefault().IdTruong, Constant.Token);
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
            var resultTruong = await _truongHelper.GetListTruong(Constant.Token);
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
                resultSinhVien = await _sinhVienHelper.GetSinhVienByCCCD(nameSearch, Constant.Token);
            }
            else
            {
                resultSinhVien = await _sinhVienHelper.GetSinhVienByName(nameSearch, Constant.Token);
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
                        var resultPhong = await _phongHelper.GetPhong(item.IdPhong, Constant.Token);
                        if (resultPhong.status == 200)
                        {
                            if (resultPhong.data.FirstOrDefault().IdKhu != null)
                            {
                                var resultKhu = await _khuHelper.GetKhu(resultPhong.data.FirstOrDefault().IdKhu, Constant.Token);
                                if (resultKhu.status == 200)
                                {
                                    xe.NameKhu = resultKhu.data.FirstOrDefault().Name;
                                }
                            }
                        }
                    }
                    if (item.IdTruong != null)
                    {
                        var resultTruong = await _truongHelper.GetTruong(item.IdTruong, Constant.Token);
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
            messager = resultSinhVien.message;
        }

        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await SearchSinhVien(GlobalModel.ListXe, txtTim.EditValue.ToString());
            gcDanhSach.DataSource = GlobalModel.ListXe;
            gcDanhSach.RefreshDataSource();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }

        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadXe(GlobalModel.ListXe);
            gcDanhSach.DataSource = GlobalModel.ListXe;
            gcDanhSach.RefreshDataSource();
            _frmLoading.Hide();
        }

        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await delete();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task delete()
        {
            var resultDelete = await _xeHelper.DeleteXe(account.Id, Constant.Token);
            if (resultDelete.status == 200)
            {
                await LoadXe(GlobalModel.ListXe);
                gcDanhSach.DataSource = GlobalModel.ListXe;
                gcDanhSach.RefreshDataSource();
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
        }

        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await edit();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task edit()
        {
            try
            {
                Xe xe = new Xe();
                xe.Id = account.Id;
                xe.IdUser = account.IdUser;
                xe.Name = txtTenXe.Text;
                xe.Color = txtMauXe.Text;
                xe.Code = txtBSoXe.Text;
                xe.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
                var resultEdit = await _xeHelper.EditXe(xe, Constant.Token);
                if (resultEdit.status == 200)
                {
                    await LoadXe(GlobalModel.ListXe);
                    gcDanhSach.DataSource = GlobalModel.ListXe;
                    gcDanhSach.RefreshDataSource();
                }
                messager = resultEdit.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await AddXe();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task AddXe()
        {
            Xe newXe = new Xe();
            if (GlobalModel.IsAddXe == true)
            {
                newXe.IdUser = GlobalModel.SinhVien.Id;
            }
            else
            {
                newXe.IdUser = account.IdUser;
            }
            newXe.Name = txtTenXe.Text;
            newXe.Code = txtBSoXe.Text;
            newXe.Color = txtMauXe.Text;
            var result = await _xeHelper.AddXe(newXe, Constant.Token);
            messager = result.message;
        }
    }
}