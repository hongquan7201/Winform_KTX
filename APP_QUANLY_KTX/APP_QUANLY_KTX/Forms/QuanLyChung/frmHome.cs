using DevExpress.XtraBars;
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

        public Home(INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
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
            frmThongTinSV frmThongTinCaNhanSV = new frmThongTinSV();
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
        private void btnQLHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLHopDong frmQLHopDong = new frmQLHopDong();
            frmQLHopDong.ShowDialog();
        }
        private void btnQLDienNuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLDienNuoc frmQLDienNuoc = new frmQLDienNuoc();
            frmQLDienNuoc.ShowDialog();
        }
        private void btnQLXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLXe frmQLXe = new frmQLXe();
            frmQLXe.ShowDialog();
        }
        private void btnQLPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQLPhong frmQLPhong = new frmQLPhong();
            frmQLPhong.ShowDialog();
        }
        private void btnThanhToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBienLai frmBienLai = new frmBienLai();
            frmBienLai.ShowDialog();
        }
        private void btnQLiHoaDon_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmQLHoaDon frmQLHoaDon = new frmQLHoaDon();
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
    }
}