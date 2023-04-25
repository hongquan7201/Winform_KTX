using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmLichSuGiaoDich : DevExpress.XtraEditors.XtraForm
    {
        private readonly IBankingHelper _bankingHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly frmLoading _frmLoading;
        public frmLichSuGiaoDich(IBankingHelper bankingHelper, ISinhVienHelper sinhVienHelper, IKhuHelper khuHelper, IPhongHelper phongHelper, frmLoading frmLoading)
        {
            InitializeComponent();
            _bankingHelper = bankingHelper;
            _sinhVienHelper = sinhVienHelper;
            _khuHelper = khuHelper;
            _phongHelper = phongHelper;
            _frmLoading = frmLoading;
        }
        private Banking _banking = new Banking();
        private string messager = "Vui Lòng Thử Lại!";
        private void GetAccAccount(Banking banking)
        {
            txtEmail.Text = banking.Email;
            txtHoTen.Text = banking.Name;
            txtLoaiGiaoDich.Text = banking.type;
            txtMaGiaoDich.Text = banking.code;
            txtNoiDung.Text = banking.cmt;
            txtSDT.Text = banking.Sdt;
            txtSoTien.Text = banking.amount;
            cbKhu.Text = banking.NameKhu;
            cbPhong.Text = banking.NamePhong;
            dtNgayThanhToan.Text = banking.creatAt.ToString();
        }
        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await SearchCode(_banking);
            GetAccAccount(_banking);
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task SearchCode(Banking banking)
        {
            if (!string.IsNullOrEmpty(txtTim.EditValue.ToString()))
            {
                var result = await _bankingHelper.GetBankingByCode(txtTim.EditValue.ToString());
                if (result.status == 200)
                {
                    banking.type = result.data.type;
                    banking.idSinhVien = result.data.idSinhVien;
                    banking.amount = result.data.amount;
                    banking.code = result.data.code;
                    banking.Id = result.data.Id;
                    banking.cmt = result.data.cmt;
                    banking.creatAt = result.data.creatAt;
                    if (banking.idSinhVien != null)
                    {
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(banking.idSinhVien);
                        if (sinhvien.status == 200)
                        {
                            banking.Name = sinhvien.data.FirstOrDefault().Name;
                            banking.Email = sinhvien.data.FirstOrDefault().Email;
                            banking.Sdt = sinhvien.data.FirstOrDefault().Sdt;
                            if (sinhvien.data.FirstOrDefault().IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong);
                                if (phong.status == 200)
                                {
                                    banking.NamePhong = phong.data.FirstOrDefault().Name;
                                    if (phong.data.FirstOrDefault().IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu);
                                        if (khu.status == 200)
                                        {
                                            banking.NameKhu = khu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    GlobalModel.ListBanking.Clear();
                    GlobalModel.ListBanking.Add(banking);
                    gcDanhSach.DataSource = GlobalModel.ListBanking;
                    gcDanhSach.RefreshDataSource();
                }
                messager = result.message;
            }
        }
        private void frmLichSuGiaoDich_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = GlobalModel.ListBanking;
            gcDanhSach.RefreshDataSource();

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
                    _banking = GlobalModel.ListBanking[s];
                    GetAccAccount(_banking);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        private async void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await LoadListBanking(GlobalModel.ListBanking);
            gcDanhSach.DataSource = GlobalModel.ListBanking;
            gcDanhSach.RefreshDataSource();
            _frmLoading.Hide();
        }
        private async Task LoadListBanking(List<Banking> listBanking)
        {
            var lstBanking = await _bankingHelper.GetListBanking();
            if (lstBanking.status == 200)
            {
                listBanking.Clear();
                int i = 1;
                foreach (var item in lstBanking.data)
                {
                    Banking banking = new Banking();
                    banking.type = item.type;
                    banking.idSinhVien = item.idSinhVien;
                    banking.amount = item.amount;
                    banking.code = item.code;
                    banking.Id = item.Id;
                    banking.cmt = item.cmt;
                    banking.creatAt = item.creatAt;
                    banking.STT = i;
                    if (banking.idSinhVien != null)
                    {
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(banking.idSinhVien);
                        if (sinhvien.status == 200)
                        {
                            banking.Name = sinhvien.data.FirstOrDefault().Name;
                            banking.Email = sinhvien.data.FirstOrDefault().Email;
                            banking.Sdt = sinhvien.data.FirstOrDefault().Sdt;
                            if (sinhvien.data.FirstOrDefault().IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong);
                                if (phong.status == 200)
                                {
                                    banking.NamePhong = phong.data.FirstOrDefault().Name;
                                    if (phong.data.FirstOrDefault().IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu);
                                        if (khu.status == 200)
                                        {
                                            banking.NameKhu = khu.data.FirstOrDefault().Name;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    listBanking.Add(banking);
                    i++;
                }
            }

        }
    }
}