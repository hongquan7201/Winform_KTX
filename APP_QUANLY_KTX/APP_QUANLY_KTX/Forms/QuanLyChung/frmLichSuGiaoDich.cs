using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper.API;
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
            txtLoaiGiaoDich.Text = banking.Type;
            txtMaGiaoDich.Text = banking.Code;
            txtNoiDung.Text = banking.Comment;
            txtSDT.Text = banking.Sdt;
            txtSoTien.Text = banking.Amount.ToString();
            cbKhu.Text = banking.NameKhu;
            cbPhong.Text = banking.NamePhong;
            dtNgayThanhToan.Text = banking.CreateAt.ToString();
        }
        private async void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmLoading.Show();
            await SearchCode();
            _frmLoading.Hide();
            MessageBox.Show(messager);
        }
        private async Task SearchCode()
        {
            if (!string.IsNullOrEmpty(txtTim.EditValue.ToString()))
            {
                var result = await _bankingHelper.GetBankingByCode(txtTim.EditValue.ToString(), Constant.Token);
                if (result.status == 200)
                {
                    Banking banking = new Banking();
                    banking.Type = result.data.Type;
                    banking.IdUser = result.data.IdUser;
                    banking.Amount = result.data.Amount;
                    banking.Code = result.data.Code;
                    banking.Id = result.data.Id;
                    banking.Comment = result.data.Comment;
                    banking.CreateAt = result.data.CreateAt;
                    if (banking.IdUser != null)
                    {
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(banking.IdUser, Constant.Token);
                        if (sinhvien.status == 200)
                        {
                            banking.Name = sinhvien.data.FirstOrDefault().Name;
                            banking.Email = sinhvien.data.FirstOrDefault().Email;
                            banking.Sdt = sinhvien.data.FirstOrDefault().Sdt;
                            if (sinhvien.data.FirstOrDefault().IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong, Constant.Token);
                                if (phong.status == 200)
                                {
                                    banking.NamePhong = phong.data.FirstOrDefault().Name;
                                    if (phong.data.FirstOrDefault().IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu, Constant.Token);
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
                    GetAccAccount(banking);
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
            var lstBanking = await _bankingHelper.GetListBanking(Constant.Token);
            if (lstBanking.status == 200)
            {
                listBanking.Clear();
                int i = 1;
                foreach (var item in lstBanking.data)
                {
                    Banking banking = new Banking();
                    banking.Type = item.Type;
                    banking.IdUser = item.IdUser;
                    banking.Amount = item.Amount;
                    banking.Code = item.Code;
                    banking.Id = item.Id;
                    banking.Comment = item.Comment;
                    banking.CreateAt = item.CreateAt;
                    banking.STT = i;
                    if (banking.IdUser != null)
                    {
                        var sinhvien = await _sinhVienHelper.GetSinhVienById(banking.IdUser, Constant.Token);
                        if (sinhvien.status == 200)
                        {
                            banking.Name = sinhvien.data.FirstOrDefault().Name;
                            banking.Email = sinhvien.data.FirstOrDefault().Email;
                            banking.Sdt = sinhvien.data.FirstOrDefault().Sdt;
                            if (sinhvien.data.FirstOrDefault().IdPhong != null)
                            {
                                var phong = await _phongHelper.GetPhong(sinhvien.data.FirstOrDefault().IdPhong, Constant.Token);
                                if (phong.status == 200)
                                {
                                    banking.NamePhong = phong.data.FirstOrDefault().Name;
                                    if (phong.data.FirstOrDefault().IdKhu != null)
                                    {
                                        var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu, Constant.Token);
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