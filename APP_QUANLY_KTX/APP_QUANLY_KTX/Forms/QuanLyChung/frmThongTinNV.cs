using DevExpress.XtraEditors;
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
    public partial class frmThongTinNV : DevExpress.XtraEditors.XtraForm
    {
        public frmThongTinNV()
        {
            InitializeComponent();
        }
        private async void GetAccount(Nhanvien nhanvien)
        {
            txtHoTen.Text = nhanvien.Name;
            txtEmail.Text = nhanvien.Email;
            txtDiaChi.Text = nhanvien.Address;
            txtCCCD.Text = nhanvien.Cccd;
            txtSDT.Text = nhanvien.Sdt;
            cbGioiTinh.Text = nhanvien.GioiTinh;
            if (nhanvien.Gender == true)
            {
                imgNVNam.Visible = true;
                imgNVNu.Visible = false;
                cbGioiTinh.Text = "Nam";
            }
            else
            {
                imgNVNam.Visible = false;
                imgNVNu.Visible = true;
                cbGioiTinh.Text = "Nữ";
            }
            try
            {
                dtNgayDangKy.Text = nhanvien.CreateAt.ToString();
                dtNgaySinh.Text = nhanvien.Birthday.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui Lòng Định Dạng Lại dd/mm/yyyy");
            }
          
        }
        private void frmThongTinNV_Load(object sender, EventArgs e)
        {
            GetAccount(GlobalModel.Nhanvien);
        }
    }
}