﻿using DevExpress.XtraBars;
using ProjectQLKTX.Interface;
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
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly INhanVienHelper _nhanVienHelper;
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IThanNhanHelper _thanNhanHelper;
        private readonly IQuanHeHelper _quanHeHelper;
        private readonly IPhongHelper _phongHelper;
        private readonly IKhuHelper _khuHelper;
        private readonly ITruongHelper _truongHelper;

        public Home(INhanVienHelper nhanVienHelper, ISinhVienHelper sinhVienHelper, IThanNhanHelper thanNhanHelper, IQuanHeHelper quanHeHelper, IPhongHelper phongHelper, IKhuHelper khuHelper, ITruongHelper truongHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
            _sinhVienHelper = sinhVienHelper;
            _thanNhanHelper = thanNhanHelper;
            _quanHeHelper = quanHeHelper;
            _phongHelper = phongHelper;
            _khuHelper = khuHelper;
            _truongHelper = truongHelper;
        }
        //void OpenForm(Type typeForm)
        //{
        //    foreach (Form frm in MdiChildren)
        //    {
        //        if (frm.GetType()== typeForm)
        //        {
        //            frm.Activate();
        //            return;
        //        }
        //    }
        //    Form f =(Form) Activator.CreateInstance(typeForm);
        //    f.MdiParent = this;
        //    f.Show();
        //}
        private void btnDoiMK_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMK frmDoiMK = new frmDoiMK();
            frmDoiMK.ShowDialog();
        }
        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn Thoát ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }
        private void btnDangKyPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            //OpenForm(typeof(frmDKPhong));
            frmDKPhong frmDangKyPhong = new frmDKPhong();
            frmDangKyPhong.ShowDialog();
        }
        private void btnChuyenPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChuyenPhong frmChuyenPhong = new frmChuyenPhong();
            frmChuyenPhong.ShowDialog();
        }
        private void btnTraPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTraPhong frmTraPhong = new frmTraPhong();
            frmTraPhong.ShowDialog();
        }
        private void btnThongTinSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinSV frmThongTinCaNhanSV = new frmThongTinSV(_sinhVienHelper,_thanNhanHelper,_quanHeHelper,_phongHelper,_khuHelper,_truongHelper);
            frmThongTinCaNhanSV.ShowDialog();
        }
        private void btnDSNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDSNhanVien frmDSNhanVien = new frmDSNhanVien(_nhanVienHelper);
            frmDSNhanVien.ShowDialog();
        }
        private void btnTTNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinNV frmThongTinCaNhanNV = new frmThongTinNV();
            frmThongTinCaNhanNV.ShowDialog();
        }
        private void btnQLiHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLiHopDong frmQLiHopDong = new frmQLiHopDong();
            frmQLiHopDong.ShowDialog();
        }
        private void btnQLiDienNuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLiDienNuoc frmQLDienNuoc = new frmQLiDienNuoc();
            frmQLDienNuoc.ShowDialog();
        }
        private void btnQLiXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLiXe frmQLXe = new frmQLiXe();
            frmQLXe.ShowDialog();
        }
        private void btnQLiPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
           frmQLiPhong frmQLiPhong = new frmQLiPhong();
            frmQLiPhong.ShowDialog();
        }
        private void btnThanhToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBienLai frmBienLai = new frmBienLai();
            frmBienLai.ShowDialog();
        }
        private void btnQLiHoaDon_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmQLiHoaDon frmQLHoaDon = new frmQLiHoaDon();
            frmQLHoaDon.ShowDialog();
        }

        private void btnQLiKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLiKho frmQLiKho = new frmQLiKho();
            frmQLiKho.ShowDialog();
        }

        private void btnQLiTaiSan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLiTaiSan frmQLiTaiSan = new frmQLiTaiSan();
            frmQLiTaiSan.ShowDialog();
        }

        private void btnBCDThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBaoCaoDoanhThu frmBaoCaoDoanhThu = new frmBaoCaoDoanhThu();
            frmBaoCaoDoanhThu.ShowDialog();
        }

        private void btnThongKeSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongKeSinhVien frmThongKeSinhVien = new frmThongKeSinhVien();
            frmThongKeSinhVien.ShowDialog();
        }
    }
}