using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.Files;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmQLiTaiSan : DevExpress.XtraEditors.XtraForm
    {
        private readonly ITaiSanHelper _taiSanHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IVatDungHelper _vatDungHelper;
        private bool IsCheck = false;
        private Taisan _taiSan { get; set; }
        public frmQLiTaiSan(ITaiSanHelper taiSanHelper, IPhongHelper phongHelper, IVatDungHelper vatDungHelper)
        {
            InitializeComponent();
            _taiSanHelper = taiSanHelper;
            _phongHelper = phongHelper;
            _vatDungHelper = vatDungHelper;
        }
        private async Task LoadListTaiSan(List<Taisan> listTaiSan)
        {
            var taiSans = await _taiSanHelper.GetListTaiSan();
            if (taiSans.status == 200)
            {
                int i = 1;
                listTaiSan.Clear();
                foreach (var item in taiSans.data)
                {
                    if (item.IdVatDung != null)
                    {
                        var vatDungs = await _vatDungHelper.GetVatDung(item.IdVatDung);
                        if (vatDungs.status == 200)
                        {
                            item.NameVatDung = vatDungs.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.IdPhong != null)
                    {
                        var phongs = await _phongHelper.GetPhong(item.IdPhong);
                        if (phongs.status == 200)
                        {
                            item.NamePhong = phongs.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.Status == true)
                    {
                        item.TinhTrang = "Đang Sử Dụng";
                    }
                    else if (item.Status == false && item.Quantity > 0)
                    {
                        item.TinhTrang = "Hư";
                    }
                    else
                    {
                        item.TinhTrang = "Chưa Có";
                    }
                    item.STT = i;
                    listTaiSan.Add(item);
                    i++;
                }

                var listPhong = await _phongHelper.GetListPhong();
                if (listPhong.status == 200)
                {
                    cbPhong.Properties.Items.Clear();
                    foreach (var item in listPhong.data)
                    {
                        cbPhong.Properties.Items.Add(item.Name);
                    }
                }
                var listVatDung = await _vatDungHelper.GetListVatDung();
                if (listVatDung.status == 200)
                {
                    GlobalModel.ListVatDung.Clear();
                    cbVatDung.Properties.Items.Clear();
                    foreach (var item in listVatDung.data)
                    {
                        cbVatDung.Properties.Items.Add(item.Name);
                         GlobalModel.ListVatDung.Add(item);
                    }
                }
                gcDanhSach.DataSource = listTaiSan;
                gcDanhSach.RefreshDataSource();
            }
        }
        private async void frmQLiTaiSan_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = GlobalModel.ListTaiSan;
            gcDanhSach.RefreshDataSource();
            foreach(var item in GlobalModel.ListPhong)
            {
                cbPhong.Properties.Items.Add(item);
            }
            foreach(var item in GlobalModel.ListVatDung)
            {
                cbVatDung.Properties.Items.Add(item);
            }
        }

        private void btnXuatfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export.ExportExcel(gcDanhSach, "TaiSan");
        }

        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await LoadListTaiSan( GlobalModel.ListTaiSan);
        }
        private async Task GetAccount(Taisan taiSan)
        {
            txtSoLuong.Text = taiSan.Quantity.ToString();
            if (taiSan.Status == true)
            {
                txtTinhTrang.Text = "Đang Sử Dụng";
            }
            else if (taiSan.Status == false && taiSan.Quantity > 0)
            {
                taiSan.TinhTrang = "Hư";
            }
            else
            {
                taiSan.TinhTrang = "Chưa Có";
            }
            cbPhong.Text = taiSan.NamePhong;
            cbVatDung.Text = taiSan.NameVatDung;
        }
        private void gcDanhSach_DoubleClick(object sender, EventArgs e)
        {
            IsCheck = true;
            try
            {
                if (
                          (sender is GridControl control) &&
                          (control.MainView is GridView gridView) &&
                          (e is DXMouseEventArgs args))
                {
                    var hittest = gridView.CalcHitInfo(args.Location);
                    var s = hittest.RowHandle;
                    _taiSan =  GlobalModel.ListTaiSan[s];
                    GetAccount(_taiSan);
                    IsCheck = false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        private async void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Taisan taisan = new Taisan();
            foreach (var item in  GlobalModel.ListVatDung)
            {
                if (cbVatDung.Text == item.Name)
                {
                    taisan.IdVatDung = item.Id;
                }
            }
            foreach (var item in  GlobalModel.ListTaiSan)
            {
                if (cbPhong.Text == item.NamePhong)
                {
                    taisan.IdPhong = item.IdPhong;
                    break;
                }
            }
            taisan.Quantity = int.Parse(txtSoLuong.Text);
            taisan.Status = true;
            var resultTaiSan = await _taiSanHelper.AddTaiSan(taisan);
            await LoadListTaiSan( GlobalModel.ListTaiSan);
            MessageBox.Show(resultTaiSan.message);
        }

        private void cbVatDung_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_taiSan != null && IsCheck == false)
            {
                foreach (var item in  GlobalModel.ListTaiSan)
                {
                    if (cbPhong.Text == item.NamePhong && cbVatDung.Text == item.NameVatDung)
                    {
                        txtSoLuong.Text = item.Quantity.ToString();
                        txtTinhTrang.Text = item.TinhTrang;
                        break;
                    }
                    else
                    {
                        txtSoLuong.Text = "0";
                        txtTinhTrang.Text = "Chưa Có";
                    }
                }
            }
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lstTaiSan = new List<Taisan>();
            foreach (var item in  GlobalModel.ListTaiSan)
            {
                lstTaiSan.Add(item);
            }
             GlobalModel.ListTaiSan.Clear();
            foreach (var item in lstTaiSan)
            {
                if (txtTim.EditValue.ToString() == item.NamePhong)
                {
                     GlobalModel.ListTaiSan.Add(item);
                }
            }
            gcDanhSach.DataSource =  GlobalModel.ListTaiSan;
            gcDanhSach.RefreshDataSource();
        }

        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Taisan taisan = new Taisan();
            taisan.Id = _taiSan.Id;
            foreach (var item in  GlobalModel.ListVatDung)
            {
                if (cbVatDung.Text == item.Name)
                {
                    taisan.IdVatDung = item.Id;
                }
            }
            foreach (var item in  GlobalModel.ListTaiSan)
            {
                if (cbPhong.Text == item.NamePhong)
                {
                    taisan.IdPhong = item.IdPhong;
                    break;
                }
            }
            taisan.Quantity = int.Parse(txtSoLuong.Text);
            if (txtTinhTrang.Text.Contains("Sử Dụng"))
            {
                taisan.Status = true;
            }
            else
            {
                taisan.Status = false;
            }

            var resultTaiSan = await _taiSanHelper.EditTaiSan(taisan);
            await LoadListTaiSan( GlobalModel.ListTaiSan);
            MessageBox.Show(resultTaiSan.message);
        }

        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var resultDelete = await _taiSanHelper.DeleteTaiSan(_taiSan.Id);
            await LoadListTaiSan( GlobalModel.ListTaiSan);
            MessageBox.Show(resultDelete.message);
        }
    }
}