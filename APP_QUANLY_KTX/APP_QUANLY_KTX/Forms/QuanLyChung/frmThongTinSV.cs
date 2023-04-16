using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;

namespace ProjectQLKTX
{
    public partial class frmThongTinSV : DevExpress.XtraEditors.XtraForm
    {
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IThanNhanHelper _thanNhanHelper;
        private readonly IQuanHeHelper _quanHeHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        List<Sinhvien> _listSinhVien;
        List<Quanhe> _listQuanhe;
        List<Phong> _listPhong;
        List<Khu> _listKhu;
        List<Truong> _listTruong;
        private Thannhan _thanNhan { get; set; }
        public frmThongTinSV(ISinhVienHelper sinhVienHelper, IThanNhanHelper thanNhanHelper, IQuanHeHelper quanHeHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper)
        {
            InitializeComponent();
            _sinhVienHelper = sinhVienHelper;
            _thanNhanHelper = thanNhanHelper;
            _quanHeHelper = quanHeHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
            _listSinhVien = new List<Sinhvien>();
            _listKhu = new List<Khu>();
            _listPhong = new List<Phong>();
            _listQuanhe = new List<Quanhe>();
            _listTruong = new List<Truong>();
        }

        private Sinhvien _sinhVien { get; set; }
        private async Task LoadSinhVien(List<Sinhvien> listAccount)
        {
            var listSinhVien = await _sinhVienHelper.GetListSinhVien();
            try
            {
                if (listSinhVien != null && listSinhVien.status == 200)
                {
                    int i = 1;
                    listAccount.Clear();
                    var lstData = listSinhVien.data;
                    foreach (var item in lstData)
                    {
                        if (item.idThanNhan != null)
                        {
                            var nhanNhan = await _thanNhanHelper.GetThanNhan(item.idThanNhan);
                            if (nhanNhan.status == 200)
                            {
                                item.TenThanNhan = nhanNhan.data.FirstOrDefault().Name;
                                item.SDTThanNhan = nhanNhan.data.FirstOrDefault().Sdt;
                                item.AddressThanNha = nhanNhan.data.FirstOrDefault().Address;
                                if (nhanNhan.data.FirstOrDefault().Gender == true)
                                {

                                    item.GioiTinhThanNhan = "Nam";
                                }
                                else
                                {
                                    item.GioiTinhThanNhan = "Nữ";
                                }
                                if (nhanNhan.data.FirstOrDefault().IdQuanHe != null)
                                {
                                    var quanHe = await _quanHeHelper.GetQuanHe(nhanNhan.data.FirstOrDefault().IdQuanHe);
                                    if (quanHe.status == 200)
                                    {
                                        item.QuanHe = quanHe.data.FirstOrDefault().Name;
                                    }
                                }

                            }

                        }
                        if (item.IdTruong != null)
                        {
                            var truong = await _truongHelper.GetTruong(item.IdTruong);
                            if (truong.status == 200)
                            {
                                item.Truong = truong.data.FirstOrDefault().Name;
                            }

                        }
                        if (item.IdPhong != null)
                        {
                            var phong = await _phongHelper.GetPhong(item.IdPhong);
                            if (phong.status == 200)
                            {
                                item.Phong = phong.data.FirstOrDefault().Name;
                                if (phong.data.FirstOrDefault().IdKhu != null)
                                {
                                    var khu = await _khuHelper.GetKhu(phong.data.FirstOrDefault().IdKhu);
                                    if (khu.status == 200)
                                    {
                                        item.Khu = khu.data.FirstOrDefault().Name;
                                    }

                                }
                            }
                        }

                        item.STT = i;
                        if (item.Gender == true)
                        {

                            item.GioiTinh = "Nam";
                        }
                        else
                        {
                            item.GioiTinh = "Nữ";
                        }
                        listAccount.Add(item);
                        i++;
                    }
                    gcDanhSach.DataSource = listAccount;
                    gcDanhSach.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show(listSinhVien.message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + listSinhVien);
                Log.Error(ex, ex.Message);
            }
            var listKhu = await _khuHelper.GetListKhu();
            if (listKhu.status == 200)
            {
                foreach (var item in listKhu.data)
                {
                    cbKhu.Properties.Items.Add(item.Name);
                    _listKhu.Add(item);
                }

            }
            var listPhong = await _phongHelper.GetListPhong();
            if (listPhong.status == 200)
            {
                foreach (var item in listPhong.data)
                {
                    cbPhong.Properties.Items.Add(item.Name);
                    _listPhong.Add(item);
                }
            }
            var listTruong = await _truongHelper.GetListTruong();
            if (listTruong.status == 200)
            {
                foreach (var item in listTruong.data)
                {
                    cbTruong.Properties.Items.Add(item.Name);
                    _listTruong.Add(item);
                }
            }
            var listQuanHe = await _quanHeHelper.GetListQuanHe();
            if (listQuanHe.status == 200)
            {
                foreach (var item in listQuanHe.data)
                {
                    cbQuanHe.Properties.Items.Add(item.Name);
                    _listQuanhe.Add(item);
                }
            }
        }
        private async void frmThongTinSV_Load(object sender, EventArgs e)
        {
            await LoadSinhVien(_listSinhVien);
            imgSVNu.Visible = false;
            imgSVNam.Visible = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
                    _sinhVien = _listSinhVien[s];
                    GetAccount(_sinhVien);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
        private async void GetAccount(Sinhvien sinhVien)
        {
            cbTruong.Text = sinhVien.Truong;
            txtMaSV.Text = sinhVien.MaSv;
            txtHoTen.Text = sinhVien.Name;
            txtEmail.Text = sinhVien.Email;
            txtDiaChi.Text = sinhVien.Address;
            txtDiaChiTN.Text = sinhVien.AddressThanNha;
            cbQuanHe.Text = sinhVien.QuanHe;
            txtSDTTN.Text = sinhVien.SDTThanNhan;
            txtTenTN.Text = sinhVien.TenThanNhan;
            cbKhu.Text = sinhVien.Khu;
            cbPhong.Text = sinhVien.Phong;
            cbGioiTinhTN.Text = sinhVien.GioiTinhThanNhan;
            try
            {
                if (sinhVien.CreateAt != null)
                {
                    dtNgayDangKy.Text = sinhVien.CreateAt.ToString();
                }
                if (!string.IsNullOrEmpty(sinhVien.BirthDay))
                {
                    dtNgaySinh.Text = sinhVien.BirthDay.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui Lòng Định Dạng Lại dd/mm/yyyy");
            }
            txtCCCD.Text = sinhVien.Cccd;
            txtSDT.Text = sinhVien.Sdt;
            cbGioiTinh.Text = sinhVien.GioiTinh;
            if (sinhVien.Gender == true)
            {
                imgSVNam.Visible = true;
                imgSVNu.Visible = false;
            }
            else
            {
                imgSVNam.Visible = false;
                imgSVNu.Visible = true;
            }
        }

        private async void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _sinhVien.Name = txtHoTen.Text;
            _sinhVien.Email = txtEmail.Text;
            _sinhVien.Address = txtDiaChi.Text;
            _sinhVien.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
            _sinhVien.BirthDay = dtNgaySinh.Text;
            _sinhVien.Cccd = txtCCCD.Text;
            _sinhVien.Sdt = txtSDT.Text;
            _sinhVien.MaSv = txtMaSV.Text;
            // _sinhVien.
            if (cbGioiTinh.Text == "Nam")
            {
                _sinhVien.Gender = true;
            }
            else
            {
                _sinhVien.Gender = false;
            }
            //  var result = await _sinhVienHelper.EditSinhVien()
            //try
            //{
            //    await LoadSinhVien(_listSinhVien);
            //    MessageBox.Show(result.message);
            //}
            //catch (Exception ex)
            //{
            //    Log.Error("frmDSNhanVien " + result);
            //    Log.Error(ex, ex.Message);
            //}
        }

        private async void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var deleteById = await _sinhVienHelper.DeleteSinhVien(_sinhVien.Id);
            try
            {
                if (deleteById.status == 200)
                {
                    MessageBox.Show(deleteById.message);
                }
            }catch (Exception ex)
            {
                Log.Error(ex,ex.Message,ex.StackTrace);
            }
           
        }
    }
}