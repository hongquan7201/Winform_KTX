using DevExpress.XtraEditors;
using ProjectQLKTX.CallApis;
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
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace ProjectQLKTX
{
    public partial class frmDSNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private readonly INhanVienHelper _nhanVienHelper;
        public frmDSNhanVien(INhanVienHelper nhanVienHelper)
        {
            InitializeComponent();
            _nhanVienHelper = nhanVienHelper;
        }
        List<Nhanvien> listNhanVien = new List<Nhanvien>();
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
        }

        private void txtHoten_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void frmDSNhanVien_Load(object sender, EventArgs e)
        {
            var result = await _nhanVienHelper.GetListNhanVien();
            try
            {
                if (result != null && result.status == 200)
                {
                    listNhanVien = result.data;
                    txtHoten.Text = listNhanVien[0].name;
                    txtCCCD.Text = listNhanVien[0].cccd;
                    txtQuequan.Text = listNhanVien[0].address;
                    txtSĐT.Text = listNhanVien[0].sdt;
                }
                else
                {
                    MessageBox.Show(result.message);
                }
            }
            catch (Exception ex)
            {
                Log.Error("frmDSNhanVien " + result);
                Log.Error(ex, ex.Message);
            }
        }
    }
}