using DevExpress.XtraEditors;
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
    public partial class frmDSPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmDSPhong()
        {
            InitializeComponent();
        }
        private void btnSVcungphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSinhVienCungPhong frmSinhVienCungPhong = new frmSinhVienCungPhong();
            frmSinhVienCungPhong.ShowDialog();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}