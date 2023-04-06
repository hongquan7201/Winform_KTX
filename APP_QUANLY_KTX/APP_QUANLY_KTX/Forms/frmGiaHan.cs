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
    public partial class frmGiaHan : DevExpress.XtraEditors.XtraForm
    {
        public frmGiaHan()
        {
            InitializeComponent();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           this.Hide();
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmGiaHan_Load(object sender, EventArgs e)
        {

        }
    }
}