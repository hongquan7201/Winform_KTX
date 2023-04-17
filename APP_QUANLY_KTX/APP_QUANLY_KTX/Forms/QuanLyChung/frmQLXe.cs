using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ProjectQLKTX.APIsHelper.API;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQLKTX
{
    public partial class frmQLiXe : DevExpress.XtraEditors.XtraForm
    {
        private readonly IXeHelper _xeHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        List<Xe> _listXe = new List<Xe>();
        private Xe account;
        private async void GetAccount(Xe xe)
        {
            cbTruong.Text = xe.Truong;
            txtMaSV.Text = xe.MaSv;
            txtHoTen.Text = xe.Name;
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
            var lstXe = await _xeHelper.GetListXe();
            if (lstXe.status == 200)
            {
                listXe.Clear();
                int i = 1;
                foreach (var item in lstXe.data)
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
                        listXe.Add(item);
                        i++;
                    }
                }
                gcDanhSach.DataSource = listXe;
                gcDanhSach.RefreshDataSource();
            }
        }

        private void frmQLiXe_Load(object sender, EventArgs e)
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
            LoadXe(_listXe);
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
                    account = _listXe[s];
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
            int intValue;
            if (int.TryParse(nameSearch, out intValue))
            {
                resultSinhVien = await _sinhVienHelper.GetSinhVienByCCCD(nameSearch);
                MessageBox.Show(resultSinhVien.message);
            }
            else
            {
                resultSinhVien = await _sinhVienHelper.GetSinhVienByName(nameSearch);
                MessageBox.Show(resultSinhVien.message);
            }
            if (resultSinhVien.status == 200)
            {
                foreach (var item in resultSinhVien.data)
                {
                    Xe xe = new Xe();
                    xe.Address = item.Address;
                    xe.Cccd = item.Cccd;
                    xe.Name = item.Name;
                    xe.Sdt = item.Sdt;
                    xe.BirthDay = item.BirthDay;


                }
            }
           
        }
    }
}