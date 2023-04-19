using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmQLiKho : DevExpress.XtraEditors.XtraForm
    {
        private readonly IChietTietPhieuKhoHelper _chietPhieuKhoHelper;
        private readonly IVatDungHelper _vatDungHelper;
        private readonly INhanVienHelper _nhanVienHelper;
        private bool IsCheck = false;
        List<Vatdung> _vatdungList = new List<Vatdung>();
        private Chitietphieukho _chitietphieukho { get; set; }
        public frmQLiKho(IChietTietPhieuKhoHelper chietPhieuKhoHelper, IVatDungHelper vatDungHelper, INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _chietPhieuKhoHelper = chietPhieuKhoHelper;
            _vatDungHelper = vatDungHelper;
            _nhanVienHelper = nhanVienHelper;
        }
        private async Task LoadKho(List<Chitietphieukho> chitietphieukhos)
        {
            var resultChiTietPhieuKho = await _chietPhieuKhoHelper.GetListChietTietPhieuKho();
            if (resultChiTietPhieuKho.status == 200)
            {
                int i = 1;
                chitietphieukhos.Clear();
                foreach (var item in resultChiTietPhieuKho.data)
                {
                    if (item.IdVatDung != null)
                    {
                        var resultVatDung = await _vatDungHelper.GetVatDung(item.IdVatDung);
                        if (resultVatDung.status == 200)
                        {
                            item.NameVatDung = resultVatDung.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.IdNhanVien != null)
                    {
                        var resultNhanVien = await _nhanVienHelper.GetNhanVienById(item.IdNhanVien);
                        if (resultNhanVien.status == 200)
                        {
                            item.NameNhanVien = resultNhanVien.data.FirstOrDefault().Name;
                        }
                    }
                    if (item.Status == true)
                    {
                        item.TinhTrang = "Còn";
                    }
                    else
                    {
                        item.TinhTrang = "Hư";
                    }
                    item.STT = i;
                    chitietphieukhos.Add(item);
                    i++;
                }
                gcDanhSach.DataSource = chitietphieukhos;
                gcDanhSach.RefreshDataSource();
            }
          
        }
        private async void frmQLiKho_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = GlobalModel.ListChiTietPhieuKho;
            gcDanhSach.RefreshDataSource();
            var resulListtVatDung = await _vatDungHelper.GetListVatDung();
            if (resulListtVatDung.status == 200)
            {
                cbTenVatDung.Properties.Items.Clear();
                foreach (var item in resulListtVatDung.data)
                {
                    cbTenVatDung.Properties.Items.Add(item.Name);
                    _vatdungList.Add(item);
                }
            }
        }
        private void GetAccount(Chitietphieukho chitietphieukho)
        {
            txtSoLuong.Text = chitietphieukho.Quantity.ToString();
            txtTenNV.Text = chitietphieukho.NameNhanVien;
            if (chitietphieukho.Status == true)
            {
                txtTinhTrang.Text = "Còn";
            }
            else if (chitietphieukho.Status == false && chitietphieukho.Quantity > 0)
            {
                txtTinhTrang.Text = "Hư";
            }
            else
            {
                txtTinhTrang.Text = "Hết";
            }
            cbTenVatDung.Text = chitietphieukho.NameVatDung;
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
                    _chitietphieukho = GlobalModel.ListChiTietPhieuKho[s];
                    GetAccount(_chitietphieukho);
                    IsCheck = false;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lstKho = new List<Chitietphieukho>();
            foreach (var item in GlobalModel.ListChiTietPhieuKho)
            {
                lstKho.Add(item);
            }
            int i = 1;
            GlobalModel.ListChiTietPhieuKho.Clear();
            foreach (var item in lstKho)
            {
                if (txtTim.EditValue.ToString() == item.NameVatDung)
                {
                    item.STT = i;
                    GlobalModel.ListChiTietPhieuKho.Add(item);
                    i++;
                }
            }
            gcDanhSach.DataSource = GlobalModel.ListChiTietPhieuKho;
            gcDanhSach.RefreshDataSource();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadKho(GlobalModel.ListChiTietPhieuKho);
        }

        private void cbTenVatDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsCheck == false)
            {
                foreach (var item in GlobalModel.ListChiTietPhieuKho)
                {
                    if (item.NameVatDung == cbTenVatDung.Text)
                    {
                        txtSoLuong.Text = item.Quantity.ToString();
                        txtTenNV.Text = item.NameNhanVien;
                        if (item.Status == true)
                        {
                            txtTinhTrang.Text = "Còn";
                        }
                        else if (item.Status == false && item.Quantity > 0)
                        {
                            txtTinhTrang.Text = "Hư";
                        }
                        else
                        {
                            txtTinhTrang.Text = "Hết";
                        }
                        break;
                    }
                    else
                    {
                        txtSoLuong.Text = "0";
                        txtTenNV.Text = "";
                        txtTinhTrang.Text = "chưa nhập";
                    }
                }
            }

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}