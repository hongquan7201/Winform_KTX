namespace ProjectQLKTX
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the Code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnDangxuat = new DevExpress.XtraBars.BarButtonItem();
            btnDoiMK = new DevExpress.XtraBars.BarButtonItem();
            btnDKyPhong = new DevExpress.XtraBars.BarButtonItem();
            btnChuyenPhong = new DevExpress.XtraBars.BarButtonItem();
            btnThoat = new DevExpress.XtraBars.BarButtonItem();
            btnTTSV = new DevExpress.XtraBars.BarButtonItem();
            btnDSNV = new DevExpress.XtraBars.BarButtonItem();
            btnTTNV = new DevExpress.XtraBars.BarButtonItem();
            btnQLiHopDong = new DevExpress.XtraBars.BarButtonItem();
            btnQLiDienNuoc = new DevExpress.XtraBars.BarButtonItem();
            btnQLiXe = new DevExpress.XtraBars.BarButtonItem();
            btnBCDThu = new DevExpress.XtraBars.BarButtonItem();
            btnThongKeSV = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            btnBienLai = new DevExpress.XtraBars.BarButtonItem();
            btnQLiHoaDon = new DevExpress.XtraBars.BarButtonItem();
            btnThongTinNV = new DevExpress.XtraBars.BarButtonItem();
            btnQLiPhong = new DevExpress.XtraBars.BarButtonItem();
            btnTraPhong = new DevExpress.XtraBars.BarButtonItem();
            btnQLiKho = new DevExpress.XtraBars.BarButtonItem();
            btnQLiTaiSan = new DevExpress.XtraBars.BarButtonItem();
            btnDSTruong = new DevExpress.XtraBars.BarButtonItem();
            btnLichSuGiaoDich = new DevExpress.XtraBars.BarButtonItem();
            HETHONG = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            DANHMUC = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            QUANLY = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            BAOCAOTHONGKE = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, ribbon.SearchEditItem, btnDangxuat, btnDoiMK, btnDKyPhong, btnChuyenPhong, btnThoat, btnTTSV, btnDSNV, btnTTNV, btnQLiHopDong, btnQLiDienNuoc, btnQLiXe, btnBCDThu, btnThongKeSV, barButtonItem1, btnBienLai, btnQLiHoaDon, btnThongTinNV, btnQLiPhong, btnTraPhong, btnQLiKho, btnQLiTaiSan, btnDSTruong, btnLichSuGiaoDich });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 46;
            ribbon.Name = "ribbon";
            ribbon.OptionsCustomizationForm.FormIcon = (Icon)resources.GetObject("resource.FormIcon");
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { HETHONG, DANHMUC, QUANLY, BAOCAOTHONGKE });
            ribbon.Size = new Size(953, 177);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // btnDangxuat
            // 
            btnDangxuat.Caption = "Đăng Xuất";
            btnDangxuat.Id = 1;
            btnDangxuat.ImageOptions.Image = (Image)resources.GetObject("btnDangxuat.ImageOptions.Image");
            btnDangxuat.ImageOptions.LargeImage = (Image)resources.GetObject("btnDangxuat.ImageOptions.LargeImage");
            btnDangxuat.Name = "btnDangxuat";
            btnDangxuat.ItemClick += btnDangxuat_ItemClick;
            // 
            // btnDoiMK
            // 
            btnDoiMK.Caption = "Đổi Mật Khẩu";
            btnDoiMK.Id = 2;
            btnDoiMK.ImageOptions.Image = (Image)resources.GetObject("btnDoiMK.ImageOptions.Image");
            btnDoiMK.ImageOptions.LargeImage = (Image)resources.GetObject("btnDoiMK.ImageOptions.LargeImage");
            btnDoiMK.Name = "btnDoiMK";
            btnDoiMK.ItemClick += btnDoiMK_ItemClick;
            // 
            // btnDKyPhong
            // 
            btnDKyPhong.Caption = "Đăng Ký Phòng";
            btnDKyPhong.Id = 35;
            btnDKyPhong.ImageOptions.Image = (Image)resources.GetObject("btnDKyPhong.ImageOptions.Image");
            btnDKyPhong.ImageOptions.LargeImage = (Image)resources.GetObject("btnDKyPhong.ImageOptions.LargeImage");
            btnDKyPhong.Name = "btnDKyPhong";
            btnDKyPhong.ItemClick += btnDangKyPhong_ItemClick;
            // 
            // btnChuyenPhong
            // 
            btnChuyenPhong.Caption = "Chuyển Phòng";
            btnChuyenPhong.Id = 36;
            btnChuyenPhong.ImageOptions.Image = (Image)resources.GetObject("btnChuyenPhong.ImageOptions.Image");
            btnChuyenPhong.ImageOptions.LargeImage = (Image)resources.GetObject("btnChuyenPhong.ImageOptions.LargeImage");
            btnChuyenPhong.Name = "btnChuyenPhong";
            btnChuyenPhong.ItemClick += btnChuyenPhong_ItemClick;
            // 
            // btnThoat
            // 
            btnThoat.Id = 44;
            btnThoat.Name = "btnThoat";
            // 
            // btnTTSV
            // 
            btnTTSV.Caption = "ThôngTin Sinh Viên";
            btnTTSV.Id = 9;
            btnTTSV.ImageOptions.Image = (Image)resources.GetObject("btnTTSV.ImageOptions.Image");
            btnTTSV.ImageOptions.LargeImage = (Image)resources.GetObject("btnTTSV.ImageOptions.LargeImage");
            btnTTSV.Name = "btnTTSV";
            btnTTSV.ItemClick += btnThongTinSinhVien_ItemClick;
            // 
            // btnDSNV
            // 
            btnDSNV.Caption = "Danh Sách Nhân Viên";
            btnDSNV.Id = 13;
            btnDSNV.ImageOptions.Image = (Image)resources.GetObject("btnDSNV.ImageOptions.Image");
            btnDSNV.ImageOptions.LargeImage = (Image)resources.GetObject("btnDSNV.ImageOptions.LargeImage");
            btnDSNV.Name = "btnDSNV";
            btnDSNV.ItemClick += btnDSNhanVien_ItemClick;
            // 
            // btnTTNV
            // 
            btnTTNV.Caption = "Thông Tin Nhân Viên";
            btnTTNV.Id = 14;
            btnTTNV.ImageOptions.Image = (Image)resources.GetObject("btnTTNV.ImageOptions.Image");
            btnTTNV.ImageOptions.LargeImage = (Image)resources.GetObject("btnTTNV.ImageOptions.LargeImage");
            btnTTNV.Name = "btnTTNV";
            // 
            // btnQLiHopDong
            // 
            btnQLiHopDong.Caption = "Quản Lý Hợp Đồng";
            btnQLiHopDong.Id = 15;
            btnQLiHopDong.ImageOptions.Image = (Image)resources.GetObject("btnQLiHopDong.ImageOptions.Image");
            btnQLiHopDong.ImageOptions.LargeImage = (Image)resources.GetObject("btnQLiHopDong.ImageOptions.LargeImage");
            btnQLiHopDong.Name = "btnQLiHopDong";
            btnQLiHopDong.ItemClick += btnQLiHopDong_ItemClick;
            // 
            // btnQLiDienNuoc
            // 
            btnQLiDienNuoc.Caption = "Quản Lý Điện Nước";
            btnQLiDienNuoc.Id = 17;
            btnQLiDienNuoc.ImageOptions.Image = (Image)resources.GetObject("btnQLiDienNuoc.ImageOptions.Image");
            btnQLiDienNuoc.ImageOptions.LargeImage = (Image)resources.GetObject("btnQLiDienNuoc.ImageOptions.LargeImage");
            btnQLiDienNuoc.Name = "btnQLiDienNuoc";
            btnQLiDienNuoc.ItemClick += btnQLiDienNuoc_ItemClick;
            // 
            // btnQLiXe
            // 
            btnQLiXe.Caption = "Quản Lý Xe";
            btnQLiXe.Id = 20;
            btnQLiXe.ImageOptions.Image = (Image)resources.GetObject("btnQLiXe.ImageOptions.Image");
            btnQLiXe.ImageOptions.LargeImage = (Image)resources.GetObject("btnQLiXe.ImageOptions.LargeImage");
            btnQLiXe.Name = "btnQLiXe";
            btnQLiXe.ItemClick += btnQLiXe_ItemClick;
            // 
            // btnBCDThu
            // 
            btnBCDThu.Caption = "Báo Cáo Doanh Thu";
            btnBCDThu.Id = 23;
            btnBCDThu.ImageOptions.Image = (Image)resources.GetObject("btnBCDThu.ImageOptions.Image");
            btnBCDThu.ImageOptions.LargeImage = (Image)resources.GetObject("btnBCDThu.ImageOptions.LargeImage");
            btnBCDThu.Name = "btnBCDThu";
            btnBCDThu.ItemClick += btnBCDThu_ItemClick;
            // 
            // btnThongKeSV
            // 
            btnThongKeSV.Caption = "Thống Kê Sinh Viên";
            btnThongKeSV.Id = 24;
            btnThongKeSV.ImageOptions.Image = (Image)resources.GetObject("btnThongKeSV.ImageOptions.Image");
            btnThongKeSV.ImageOptions.LargeImage = (Image)resources.GetObject("btnThongKeSV.ImageOptions.LargeImage");
            btnThongKeSV.Name = "btnThongKeSV";
            btnThongKeSV.ItemClick += btnThongKeSV_ItemClick;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 30;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // btnBienLai
            // 
            btnBienLai.Caption = "Biên Lai";
            btnBienLai.Id = 31;
            btnBienLai.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnBienLai.ImageOptions.SvgImage");
            btnBienLai.Name = "btnBienLai";
            btnBienLai.ItemClick += btnThanhToan_ItemClick;
            // 
            // btnQLiHoaDon
            // 
            btnQLiHoaDon.Caption = "Quản Lý Hóa Đơn";
            btnQLiHoaDon.Id = 32;
            btnQLiHoaDon.ImageOptions.Image = (Image)resources.GetObject("btnQLiHoaDon.ImageOptions.Image");
            btnQLiHoaDon.ImageOptions.LargeImage = (Image)resources.GetObject("btnQLiHoaDon.ImageOptions.LargeImage");
            btnQLiHoaDon.Name = "btnQLiHoaDon";
            btnQLiHoaDon.ItemClick += btnQLiHoaDon_ItemClick_1;
            // 
            // btnThongTinNV
            // 
            btnThongTinNV.Caption = "Thông Tin Nhân Viên";
            btnThongTinNV.Id = 33;
            btnThongTinNV.ImageOptions.Image = (Image)resources.GetObject("btnThongTinNV.ImageOptions.Image");
            btnThongTinNV.ImageOptions.LargeImage = (Image)resources.GetObject("btnThongTinNV.ImageOptions.LargeImage");
            btnThongTinNV.Name = "btnThongTinNV";
            btnThongTinNV.ItemClick += btnTTNhanVien_ItemClick;
            // 
            // btnQLiPhong
            // 
            btnQLiPhong.Caption = "Quản Lý Phòng";
            btnQLiPhong.Id = 34;
            btnQLiPhong.ImageOptions.Image = (Image)resources.GetObject("btnQLiPhong.ImageOptions.Image");
            btnQLiPhong.ImageOptions.LargeImage = (Image)resources.GetObject("btnQLiPhong.ImageOptions.LargeImage");
            btnQLiPhong.Name = "btnQLiPhong";
            btnQLiPhong.ItemClick += btnQLiPhong_ItemClick;
            // 
            // btnTraPhong
            // 
            btnTraPhong.Caption = "Trả Phòng";
            btnTraPhong.Id = 38;
            btnTraPhong.ImageOptions.Image = (Image)resources.GetObject("btnTraPhong.ImageOptions.Image");
            btnTraPhong.ImageOptions.LargeImage = (Image)resources.GetObject("btnTraPhong.ImageOptions.LargeImage");
            btnTraPhong.Name = "btnTraPhong";
            btnTraPhong.ItemClick += btnTraPhong_ItemClick;
            // 
            // btnQLiKho
            // 
            btnQLiKho.Caption = "Quản Lý Kho";
            btnQLiKho.Id = 39;
            btnQLiKho.ImageOptions.Image = (Image)resources.GetObject("btnQLiKho.ImageOptions.Image");
            btnQLiKho.ImageOptions.LargeImage = (Image)resources.GetObject("btnQLiKho.ImageOptions.LargeImage");
            btnQLiKho.Name = "btnQLiKho";
            btnQLiKho.ItemClick += btnQLiKho_ItemClick;
            // 
            // btnQLiTaiSan
            // 
            btnQLiTaiSan.Caption = "Quản Lý Tài Sản";
            btnQLiTaiSan.Id = 40;
            btnQLiTaiSan.ImageOptions.Image = (Image)resources.GetObject("btnQLiTaiSan.ImageOptions.Image");
            btnQLiTaiSan.ImageOptions.LargeImage = (Image)resources.GetObject("btnQLiTaiSan.ImageOptions.LargeImage");
            btnQLiTaiSan.Name = "btnQLiTaiSan";
            btnQLiTaiSan.ItemClick += btnQLiTaiSan_ItemClick;
            // 
            // btnDSTruong
            // 
            btnDSTruong.Caption = "Danh Sách Trường";
            btnDSTruong.Id = 43;
            btnDSTruong.ImageOptions.Image = (Image)resources.GetObject("btnDSTruong.ImageOptions.Image");
            btnDSTruong.ImageOptions.LargeImage = (Image)resources.GetObject("btnDSTruong.ImageOptions.LargeImage");
            btnDSTruong.Name = "btnDSTruong";
            btnDSTruong.ItemClick += btnDSTruong_ItemClick;
            // 
            // btnLichSuGiaoDich
            // 
            btnLichSuGiaoDich.Caption = "Lịch Sử Giao Dịch";
            btnLichSuGiaoDich.Id = 45;
            btnLichSuGiaoDich.ImageOptions.Image = (Image)resources.GetObject("btnLichSuGiaoDich.ImageOptions.Image");
            btnLichSuGiaoDich.ImageOptions.LargeImage = (Image)resources.GetObject("btnLichSuGiaoDich.ImageOptions.LargeImage");
            btnLichSuGiaoDich.Name = "btnLichSuGiaoDich";
            btnLichSuGiaoDich.ItemClick += btnLichSuGiaoDich_ItemClick;
            // 
            // HETHONG
            // 
            HETHONG.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            HETHONG.ImageOptions.Image = (Image)resources.GetObject("HETHONG.ImageOptions.Image");
            HETHONG.Name = "HETHONG";
            HETHONG.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnDangxuat);
            ribbonPageGroup1.ItemLinks.Add(btnDoiMK);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Hệ Thống";
            // 
            // DANHMUC
            // 
            DANHMUC.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2 });
            DANHMUC.ImageOptions.Image = (Image)resources.GetObject("DANHMUC.ImageOptions.Image");
            DANHMUC.Name = "DANHMUC";
            DANHMUC.Text = "Danh Mục Phòng";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(btnQLiPhong);
            ribbonPageGroup2.ItemLinks.Add(btnDKyPhong);
            ribbonPageGroup2.ItemLinks.Add(btnChuyenPhong);
            ribbonPageGroup2.ItemLinks.Add(btnTraPhong);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "QLPhong";
            // 
            // QUANLY
            // 
            QUANLY.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup3, ribbonPageGroup6, ribbonPageGroup7 });
            QUANLY.ImageOptions.Image = (Image)resources.GetObject("QUANLY.ImageOptions.Image");
            QUANLY.Name = "QUANLY";
            QUANLY.Text = "Quản Lý";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(btnTTSV);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "QLSV";
            // 
            // ribbonPageGroup6
            // 
            ribbonPageGroup6.ItemLinks.Add(btnDSNV);
            ribbonPageGroup6.ItemLinks.Add(btnThongTinNV);
            ribbonPageGroup6.Name = "ribbonPageGroup6";
            ribbonPageGroup6.Text = "QLNV";
            // 
            // ribbonPageGroup7
            // 
            ribbonPageGroup7.ItemLinks.Add(btnBienLai);
            ribbonPageGroup7.ItemLinks.Add(btnLichSuGiaoDich);
            ribbonPageGroup7.ItemLinks.Add(btnQLiHopDong);
            ribbonPageGroup7.ItemLinks.Add(btnQLiHoaDon);
            ribbonPageGroup7.ItemLinks.Add(btnQLiDienNuoc);
            ribbonPageGroup7.ItemLinks.Add(btnQLiXe);
            ribbonPageGroup7.ItemLinks.Add(btnQLiKho);
            ribbonPageGroup7.ItemLinks.Add(btnQLiTaiSan);
            ribbonPageGroup7.ItemLinks.Add(btnDSTruong);
            ribbonPageGroup7.Name = "ribbonPageGroup7";
            ribbonPageGroup7.Text = "QL Chung";
            // 
            // BAOCAOTHONGKE
            // 
            BAOCAOTHONGKE.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup9 });
            BAOCAOTHONGKE.ImageOptions.Image = (Image)resources.GetObject("BAOCAOTHONGKE.ImageOptions.Image");
            BAOCAOTHONGKE.Name = "BAOCAOTHONGKE";
            BAOCAOTHONGKE.Text = "Báo Cáo Thống Kê";
            // 
            // ribbonPageGroup9
            // 
            ribbonPageGroup9.ItemLinks.Add(btnBCDThu);
            ribbonPageGroup9.ItemLinks.Add(btnThongKeSV);
            ribbonPageGroup9.Name = "ribbonPageGroup9";
            ribbonPageGroup9.Text = "Báo Cáo";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new Point(0, 633);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(953, 24);
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayoutStore = ImageLayout.Stretch;
            BackgroundImageStore = (Image)resources.GetObject("$this.BackgroundImageStore");
            ClientSize = new Size(953, 657);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            IconOptions.Icon = (Icon)resources.GetObject("Home.IconOptions.Icon");
            Name = "Home";
            Ribbon = ribbon;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar;
            Text = "frmHome";
            WindowState = FormWindowState.Maximized;
            Load += Home_Load;
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage HETHONG;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage QUANLY;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage BAOCAOTHONGKE;
        private DevExpress.XtraBars.BarButtonItem btnDangxuat;
        private DevExpress.XtraBars.BarButtonItem btnDoiMK;
        private DevExpress.XtraBars.BarButtonItem btnDKyPhong;
        private DevExpress.XtraBars.BarButtonItem btnChuyenPhong;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarButtonItem btnTraPhong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnTTSV;
        private DevExpress.XtraBars.BarButtonItem btnDSNV;
        private DevExpress.XtraBars.BarButtonItem btnTTNV;
        private DevExpress.XtraBars.BarButtonItem btnQLiHopDong;
        private DevExpress.XtraBars.BarButtonItem btnQLiDienNuoc;
        private DevExpress.XtraBars.BarButtonItem btnQLiPhong;
        private DevExpress.XtraBars.BarButtonItem btnQLiXe;
        private DevExpress.XtraBars.BarButtonItem btnBCDThu;
        private DevExpress.XtraBars.BarButtonItem btnThongKeSV;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnBienLai;
        private DevExpress.XtraBars.BarButtonItem btnQLiHoaDon;
        private DevExpress.XtraBars.BarButtonItem btnThongTinNV;
        private DevExpress.XtraBars.Ribbon.RibbonPage DANHMUC;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnQLiKho;
        private DevExpress.XtraBars.BarButtonItem btnQLiTaiSan;
        private DevExpress.XtraBars.BarButtonItem btnDSTruong;
        private DevExpress.XtraBars.BarButtonItem btnLichSuGiaoDich;
    }
}