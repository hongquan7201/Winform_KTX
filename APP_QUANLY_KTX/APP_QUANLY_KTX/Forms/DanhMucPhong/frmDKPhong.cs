using DevExpress.XtraEditors;
using ProjectQLKTX.APIsHelper;
using ProjectQLKTX.Interface;
using ProjectQLKTX.Models;
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
    public partial class frmDKPhong : DevExpress.XtraEditors.XtraForm
    {
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;
        private readonly IHopDongHelper _hopDongHelper;
        private readonly IXeHelper _xeHelper;
        List<Phong> _listPhong;
        List<Khu> _listKhu;
        List<Truong> _listTruong;
        public frmDKPhong(ISinhVienHelper sinhVienHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper, IHopDongHelper hopDongHelper, IXeHelper xeHelper)
        {
            InitializeComponent();
            _sinhVienHelper = sinhVienHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
            _listPhong = new List<Phong>();
            _listTruong = new List<Truong>();
            _listKhu = new List<Khu>();
            _hopDongHelper = hopDongHelper;
            _xeHelper = xeHelper;
        }
        private void btnDangKyXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLiXe frm = new frmQLiXe(_xeHelper, _sinhVienHelper, _phongHelper,_khuHelper,_truongHelper);
            frm.ShowDialog();
        }

        private async void btnLapPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GlobalModel.SinhVien.Id = Guid.NewGuid();
            GlobalModel.SinhVien.Name = txtHoTen.Text;
            GlobalModel.SinhVien.Cccd = txtCCCD.Text;
            GlobalModel.SinhVien.Sdt = txtSDT.Text;
            GlobalModel.SinhVien.Address = txtDiaChi.Text;
            GlobalModel.SinhVien.BirthDay = dtNgaySinh.Text;
            GlobalModel.SinhVien.Password = txtEmail.Text;
            GlobalModel.SinhVien.Email = txtEmail.Text;
            if (cbGioiTinh.Text == "Nam")
            {
                GlobalModel.SinhVien.Gender = true;
            }
            else
            {
                GlobalModel.SinhVien.Gender = false;
            }
            foreach (var phong in _listPhong)
            {
                if (cbPhong.Text == phong.Name)
                {
                    GlobalModel.SinhVien.IdPhong = phong.Id;
                }
            }
            var addSinhVien = await _sinhVienHelper.AddSinhVien(GlobalModel.SinhVien);
            if (addSinhVien.status == 200)
            {
                Hopdong hopdong = new Hopdong();
                hopdong.Id = Guid.NewGuid();
                hopdong.IdSinhVien = GlobalModel.SinhVien.Id;
                hopdong.IdPhong = GlobalModel.SinhVien.IdPhong;
                hopdong.NgayBatDau = DateTime.Parse(dtNgayVao.Text);
                hopdong.NgayKetThuc = DateTime.Parse(dtNgayHetHan.Text);
                hopdong.CreateAt = DateTime.Parse(dtNgayDangKy.Text);
                hopdong.IdNhanVien = GlobalModel.Nhanvien.Id;
                var newHopDong = await _hopDongHelper.AddHopDong(hopdong);
                MessageBox.Show(newHopDong.message);
            }
        }

        private async void frmDKPhong_Load(object sender, EventArgs e)
        {
            var listKhu = await _khuHelper.GetListKhu();
            if (listKhu.status == 200)
            {
                cbKhu.Properties.Items.Clear();
                foreach (var item in listKhu.data)
                {
                    cbKhu.Properties.Items.Add(item.Name);
                    _listKhu.Add(item);
                }

            }
            var listPhong = await _phongHelper.GetListPhong();
            if (listPhong.status == 200)
            {
                cbPhong.Properties.Items.Clear();
                foreach (var item in listPhong.data)
                {
                    if (item.QuantityPeople < 8)
                    {
                        cbPhong.Properties.Items.Add(item.Name);
                        _listPhong.Add(item);
                    }
                }
            }
            var listTruong = await _truongHelper.GetListTruong();
            if (listTruong.status == 200)
            {
                cbTruong.Properties.Items.Clear();
                foreach (var item in listTruong.data)
                {
                    cbTruong.Properties.Items.Add(item.Name);
                    _listTruong.Add(item);
                }
            }
        }

        //private void cbKhu_Click(object sender, EventArgs e)
        //{
        //    cbPhong.Properties.Items.Clear();
        //    foreach (var khu in _listKhu)
        //    {
        //        if (cbKhu.Text == khu.Name)
        //        {
        //            foreach (var phong in _listPhong)
        //            {
        //                if (khu.Id == phong.IdKhu && phong.QuantityPeople < 8)
        //                {
        //                    cbPhong.Properties.Items.Add(phong.Name);
        //                }
        //            }
        //        }
        //    }
        //}

        private void cbKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPhong.Properties.Items.Clear();
            foreach (var khu in _listKhu)
            {
                if (cbKhu.Text == khu.Name)
                {
                    foreach (var phong in _listPhong)
                    {
                        if (khu.Id == phong.IdKhu)
                        {
                            if(phong.QuantityPeople < 8)
                            {
                                cbPhong.Properties.Items.Add(phong.Name);
                            }
                           
                        }
                    }
                }
            }
        }
    }
}