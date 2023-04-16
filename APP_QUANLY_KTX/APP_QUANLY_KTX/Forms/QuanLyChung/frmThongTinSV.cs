using DevExpress.XtraEditors;
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
    public partial class frmThongTinSV : DevExpress.XtraEditors.XtraForm
    {
        private readonly ISinhVienHelper _sinhVienHelper;
        private readonly IThanNhanHelper _thanNhanHelper;
        public frmThongTinSV(ISinhVienHelper sinhVienHelper, IThanNhanHelper thanNhanHelper)
        {
            InitializeComponent();
            _sinhVienHelper = sinhVienHelper;
            _thanNhanHelper = thanNhanHelper;
        }
        List<Sinhvien>_listSinhVien= new List<Sinhvien>();
        List<Thannhan>_listThanNhan = new List<Thannhan>();
        private async void LoadSinhVien(List<Sinhvien> lis)
        {
            var listSinhVien = await _sinhVienHelper.GetListSinhVien();
            try
            {
                if (listSinhVien != null && listSinhVien.status == 200)
                {
                    int i = 1;
                    _listSinhVien.Clear();
                    _listSinhVien = listSinhVien.data;
                    foreach (var item in _listSinhVien)
                    {




                        item.STT = i;
                        if (item.Gender == true)
                        {

                            item.GioiTinh = "Nam";
                        }
                        else
                        {
                            item.GioiTinh = "Nữ";
                        }
                        i++;
                    }
                    gcDanhSach.DataSource = _listSinhVien;
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
        }
        private void frmThongTinSV_Load(object sender, EventArgs e)
        {

        }
    }
}