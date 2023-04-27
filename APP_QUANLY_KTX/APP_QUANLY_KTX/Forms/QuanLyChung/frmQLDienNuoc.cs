using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.Files;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmQLiDienNuoc : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly IKhuHelper _khuHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IChiTietCongToHelper _chiTietCongToHelper;
        private Chitietcongto _ChiTietCongTo = new Chitietcongto();
        private string messager = "Vui Lòng Thử Lại!";
        public frmQLiDienNuoc(frmLoading frmLoading, IChiTietCongToHelper chiTietCongToHelper, IKhuHelper khuHelper, IPhongHelper phongHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _chiTietCongToHelper = chiTietCongToHelper;
            _khuHelper = khuHelper;
            _phongHelper = phongHelper;
        }
        private void GetAccount(Chitietcongto chitietCongTo)
        {
            cbPhong.Text = chitietCongTo.NamePhong;
            cbKhu.Text = chitietCongTo.NameKhu;
            if (chitietCongTo.ChiSoDienCuoiThang != null)
            {
                txtChiSoDienCuoi.Text = chitietCongTo.ChiSoDienCuoiThang.ToString();
                txtChiSoDienDau.Text = chitietCongTo.ChiSoDienDauThang.ToString();
                txtChiSoNuocCuoi.Text = chitietCongTo.ChiSoNuocCuoiThang.ToString();
                txtChiSoNuocDau.Text = chitietCongTo.ChiSoNuocDauThang.ToString();
                txtSoDienTThu.Text = chitietCongTo.SoDienTieuThu.ToString();
                txtSoNuocTThu.Text = chitietCongTo.SoNuocTieuThu.ToString();
                txtTienDien.Text = chitietCongTo.TienDien.ToString();
                txtTienNuoc.Text = chitietCongTo.TienNuoc.ToString();
                txtTongTien.Text = chitietCongTo.Total.ToString();
                dtThangThu.Text = chitietCongTo.CreateAt.ToString();
            }
            else
            {
                txtChiSoDienCuoi.Text = string.Empty;
                txtChiSoDienDau.Text = string.Empty;
                txtChiSoNuocCuoi.Text = string.Empty;
                txtChiSoNuocDau.Text = string.Empty;
                txtSoDienTThu.Text = string.Empty;
                txtSoNuocTThu.Text = string.Empty;
                txtTienDien.Text = string.Empty;
                txtTienNuoc.Text = string.Empty;
                txtTongTien.Text = string.Empty;
                dtThangThu.Text = string.Empty;
            }
          
        }
        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await AddChiTietCongTo();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task AddChiTietCongTo()
        {
            try
            {
                Chitietcongto chitietcongto = new Chitietcongto();
                chitietcongto.ChiSoDienDauThang = int.Parse(txtChiSoDienDau.Text);
                chitietcongto.ChiSoDienCuoiThang = int.Parse(txtChiSoDienCuoi.Text);
                chitietcongto.ChiSoNuocDauThang = int.Parse(txtChiSoNuocDau.Text);
                chitietcongto.ChiSoNuocCuoiThang = int.Parse(txtChiSoNuocCuoi.Text);
                chitietcongto.CreateAt = DateTime.Parse(dtThangThu.Text);
                foreach (var item in GlobalModel.ListPhong)
                {
                    if (item.Name == cbPhong.Text && item.NameKhu == cbKhu.Text)
                    {
                        chitietcongto.IdPhong = item.Id;
                        break;
                    }
                }
                var result = await _chiTietCongToHelper.AddChiTietCongTo(chitietcongto);
                if (result.status == 200)
                {
                    await LoadListDienNuoc(GlobalModel.ListChitietcongto);
                }
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async Task EditChiTietCongTo()
        {
            try
            {
                Chitietcongto chitietcongto = new Chitietcongto();
                chitietcongto.Id = _ChiTietCongTo.Id;
                chitietcongto.IdPhong = _ChiTietCongTo.IdPhong;
                chitietcongto.ChiSoDienDauThang = int.Parse(txtChiSoDienDau.Text);
                chitietcongto.ChiSoDienCuoiThang = int.Parse(txtChiSoDienCuoi.Text);
                chitietcongto.ChiSoNuocDauThang = int.Parse(txtChiSoNuocDau.Text);
                chitietcongto.ChiSoNuocCuoiThang = int.Parse(txtChiSoNuocCuoi.Text);
                chitietcongto.CreateAt = DateTime.Parse(dtThangThu.Text);
                var result = await _chiTietCongToHelper.AddChiTietCongTo(chitietcongto);
                if (result.status == 200)
                {
                    await LoadListDienNuoc(GlobalModel.ListChitietcongto);
                }
                messager = result.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private void frmQLiDienNuoc_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = GlobalModel.ListChitietcongto;
            gcDanhSach.RefreshDataSource();
            cbPhong.Properties.Items.Clear();
            cbKhu.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                cbPhong.Properties.Items.Add(item.Name);
                cbKhu.Properties.Items.Add(item.NameKhu);
            }
        }
        private async Task LoadListDienNuoc(List<Chitietcongto> listChiTietCongTo)
        {
            var chiTietCongTos = await _chiTietCongToHelper.GetListChiTietCongTo();
            try
            {
                if (chiTietCongTos.status == 200)
                {
                    int i = 1;
                    listChiTietCongTo.Clear();
                    foreach (var item in chiTietCongTos.data)
                    {
                        Chitietcongto chitietcongto = new Chitietcongto();
                        chitietcongto.ChiSoDienCuoiThang = item.ChiSoDienCuoiThang;
                        chitietcongto.ChiSoDienDauThang = item.ChiSoDienDauThang;
                        chitietcongto.ChiSoNuocCuoiThang = item.ChiSoNuocCuoiThang;
                        chitietcongto.ChiSoNuocDauThang = item.ChiSoNuocDauThang;
                        chitietcongto.SoDienTieuThu = (chitietcongto.ChiSoDienCuoiThang - chitietcongto.ChiSoDienDauThang);
                        chitietcongto.SoNuocTieuThu = (chitietcongto.ChiSoNuocCuoiThang - chitietcongto.ChiSoNuocDauThang);
                        chitietcongto.CreateAt = item.CreateAt;
                        chitietcongto.Id = item.Id;
                        chitietcongto.TienDien = item.TienDien;
                        chitietcongto.TienNuoc = item.TienNuoc;
                        chitietcongto.Total = item.Total;
                        chitietcongto.IdPhong = item.IdPhong;
                        if (chitietcongto.IdPhong != null)
                        {
                            if (chitietcongto.IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(chitietcongto.IdPhong);
                                if (phong.status == 200)
                                {
                                    chitietcongto.NamePhong = phong.data.FirstOrDefault().Name;
                                    chitietcongto.IdKhu = phong.data.FirstOrDefault().IdKhu;
                                    if (chitietcongto.IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(chitietcongto.IdKhu);
                                        if (khu.status == 200)
                                        {
                                            chitietcongto.NameKhu = khu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                        }
                        chitietcongto.STT = i;
                        listChiTietCongTo.Add(chitietcongto);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
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
                    _ChiTietCongTo = GlobalModel.ListChitietcongto[s];
                    GetAccount(_ChiTietCongTo);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await DeleteChiTietCongTo();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task DeleteChiTietCongTo()
        {
            try
            {
                var delete = await _chiTietCongToHelper.DeleteChiTietCongTo(_ChiTietCongTo.Id);
                if (delete.status == 200)
                {
                    await LoadListDienNuoc(GlobalModel.ListChitietcongto);
                }
                messager = delete.message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListDienNuoc(GlobalModel.ListChitietcongto);
            gcDanhSach.DataSource = GlobalModel.ListChitietcongto;
            gcDanhSach.RefreshDataSource();
            _frmLoading.Hide();
        }

        private void btnXuatfileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportExcel(gcDanhSach, "QLDienNuoc");
        }

        private void cbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
          cbPhong.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                if (cbKhu.Text == item.NameKhu)
                {
                    cbPhong.Properties.Items.Add(item.Name);
                }
            }
        }

        private void cbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in GlobalModel.ListChitietcongto)
            {
                if (cbPhong.Text == item.NamePhong && cbKhu.Text == item.NameKhu)
                {
                    GetAccount(item);
                    break;
                }
            }

        }

        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTim.EditValue.ToString()))
            {
                _frmLoading.Show();
                await SearchPhong(txtTim.EditValue.ToString());
                _frmLoading.Hide();
            }
            else
            {
                MessageBox.Show("Vui Lòng Kiểm Tra Lại Thông Tin!");
            }
        }
        private async Task SearchPhong(string phong)
        {
            var congTos = new List<Chitietcongto>();
            foreach (var congTo in GlobalModel.ListChitietcongto)
            {
                congTos.Add(congTo);
            }
            GlobalModel.ListChitietcongto.Clear();
            foreach (var item in congTos)
            {
                if (phong == item.NamePhong)
                {
                    GlobalModel.ListChitietcongto.Add(item);
                }
            }
            gcDanhSach.DataSource = GlobalModel.ListChitietcongto;
            gcDanhSach.RefreshDataSource();
        }
    }
}