using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmQLiPhong : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmLoading _frmLoading;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private Phong _phong = new Phong();
        private string messager = "Vui Lòng Thử Lại!";
        public frmQLiPhong(frmLoading frmLoading, IPhongHelper phongHelper, IKhuHelper khuHelper)
        {
            InitializeComponent();
            _frmLoading = frmLoading;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
        }
        private void GetAccount(Phong phong)
        {
            txtHienTai.Text = phong.QuantityPeople.ToString();
            txtToiDa.Text = phong.MaxPeople.ToString();
            cbKhu.Text = phong.NameKhu;
            cbPhong.Text = phong.Name;
        }
        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Add();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }

        private void frmQLiPhong_Load(object sender, EventArgs e)
        {
            cbPhong.Properties.Items.Clear();
            gcDanhSach.DataSource = GlobalModel.ListPhong;
            gcDanhSach.RefreshDataSource();
            cbPhong.Properties.Items.Clear();
            cbKhu.Properties.Items.Clear();
            foreach (var item in GlobalModel.ListPhong)
            {
                cbPhong.Properties.Items.Add(item.Name);
                cbKhu.Properties.Items.Add(item.NameKhu);
            }
        }
        private async Task LoadListPhong(List<Phong> listPhong)
        {
            var phongs = await _phongHelper.GetListPhong();
            if (phongs.data.Count > 0)
            {
                int i = 1;
                listPhong.Clear();
                foreach (var item in phongs.data)
                {
                    Phong phong = new Phong();
                    phong.Id = item.Id;
                    phong.Name = item.Name;
                    phong.QuantityPeople = item.QuantityPeople;
                    phong.MaxPeople = 8;
                    phong.IdKhu = item.IdKhu;
                    phong.STT = i;
                    if (phong.IdKhu != null)
                    {
                        var khu = await _khuHelper.GetKhu(phong.IdKhu);
                        if (khu.status == 200)
                        {
                            phong.NameKhu = khu.data.FirstOrDefault().Name;
                        }
                    }
                    listPhong.Add(phong);
                    i++;
                }
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
                    _phong = GlobalModel.ListPhong[s];
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
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
            foreach (var item in GlobalModel.ListPhong)
            {
                if (cbPhong.Text == item.Name && cbKhu.Text == item.NameKhu)
                {
                    GetAccount(item);
                    break;
                }
            }
        }
        private async Task Add()
        {
            Phong phong = new Phong();
            phong.Name = cbPhong.Text;
            phong.Status = true;
            phong.QuantityPeople = int.Parse(txtHienTai.Text);
            foreach (var item in GlobalModel.ListPhong)
            {
                if (cbKhu.Text == item.NameKhu)
                {
                    phong.IdKhu = item.IdKhu;
                    break;
                }
            }
            var result = await _phongHelper.AddPhong(phong);
            if (result.status == 200)
            {
                await LoadListPhong(GlobalModel.ListPhong);
                gcDanhSach.DataSource = GlobalModel.ListPhong;
                gcDanhSach.RefreshDataSource();
            }
            messager = result.message;
        }
        private async Task Edit()
        {
            Phong phong = new Phong();
            phong.Id = _phong.Id;
            phong.Name = cbPhong.Text;
            phong.QuantityPeople = int.Parse(txtHienTai.Text);
            foreach (var item in GlobalModel.ListPhong)
            {
                if (cbKhu.Text == item.NameKhu)
                {
                    phong.IdKhu = item.IdKhu;
                    break;
                }
            }
            var result = await _phongHelper.EditPhong(phong);
            if (result.status == 200)
            {
                await LoadListPhong(GlobalModel.ListPhong);
                gcDanhSach.DataSource = GlobalModel.ListPhong;
                gcDanhSach.RefreshDataSource();
            }
            messager = result.message;
        }
        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Edit();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task Delete()
        {
            var result = await _phongHelper.DeletePhong(_phong.Id);
            if (result.status == 200)
            {
                await LoadListPhong(GlobalModel.ListPhong);
                gcDanhSach.DataSource = GlobalModel.ListPhong;
                gcDanhSach.RefreshDataSource();
            }
            messager = result.message;
        }
        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await Delete();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }

        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListPhong(GlobalModel.ListPhong);
            _frmLoading.Hide();
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}