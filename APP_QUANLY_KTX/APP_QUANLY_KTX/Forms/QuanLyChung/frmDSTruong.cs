using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmDSTruong : DevExpress.XtraEditors.XtraForm
    {
        private readonly ITruongHelper _truongHelper;
        public frmDSTruong(ITruongHelper truongHelper)
        {
            InitializeComponent();
            _truongHelper = truongHelper;
        }
        List<Truong> _listTruong = new List<Truong>();
        private Truong _truong = new Truong();
        private async void frmDSTruong_Load(object sender, EventArgs e)
        {
            var getList = await _truongHelper.GetListTruong(Constant.Token);
            if (getList.status == 200)
            {
                foreach (var item in getList.data)
                {
                    _listTruong.Add(item);
                }
                gcDanhSach.DataSource = _listTruong;
                gcDanhSach.RefreshDataSource();
            }
            else
            {
                MessageBox.Show(getList.message);
            }
        }
        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isUsing = false;
            foreach(var item in _listTruong)
            {
                if (txtTruong.Text == item.Name)
                {
                    isUsing = true;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(txtTruong.Text)&&isUsing== false)
            {
                Truong truong = new Truong();
                truong.Name = txtTruong.Text;
                var add = await _truongHelper.AddTruong(truong, Constant.Token);
                if (add.status == 200)
                {
                    var getList = await _truongHelper.GetListTruong(Constant.Token);
                    if (getList.status == 200)
                    {
                        _listTruong.Clear();
                        foreach (var item in getList.data)
                        {
                            _listTruong.Add(item);
                        }
                        gcDanhSach.DataSource = _listTruong;
                        gcDanhSach.RefreshDataSource();
                    }
                }
                MessageBox.Show(add.message);
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập!");
            }
        }

        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTruong.Text))
            {
                Truong truong = new Truong();
                truong.Name = txtTruong.Text;
                truong.Id = _truong.Id;
                var edit = await _truongHelper.EditTruong(truong, Constant.Token);
                if (edit.status == 200)
                {
                    var getList = await _truongHelper.GetListTruong(Constant.Token);
                    if (getList.status == 200)
                    {
                        _listTruong.Clear();
                        foreach (var item in getList.data)
                        {
                            _listTruong.Add(item);
                        }
                        gcDanhSach.DataSource = _listTruong;
                        gcDanhSach.RefreshDataSource();
                    }
                }
                MessageBox.Show(edit.message);
            }
        }
        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                var delete = await _truongHelper.DeleteTruong(_truong.Id, Constant.Token);
                if (delete.status == 200)
                {
                    var getList = await _truongHelper.GetListTruong(Constant.Token);
                    if (getList.status == 200)
                    {
                        _listTruong.Clear();
                        foreach (var item in getList.data)
                        {
                            _listTruong.Add(item);
                        }
                        gcDanhSach.DataSource = _listTruong;
                        gcDanhSach.RefreshDataSource();
                    }
                }
                MessageBox.Show(delete.message);
        }

        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var getList = await _truongHelper.GetListTruong(Constant.Token);
            if (getList.status == 200)
            {
                _listTruong.Clear();
                foreach (var item in getList.data)
                {
                    _listTruong.Add(item);
                }
                gcDanhSach.DataSource = _listTruong;
                gcDanhSach.RefreshDataSource();
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
                    _truong = _listTruong[s];
                    txtTruong.Text = _truong.Name;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
    }
}