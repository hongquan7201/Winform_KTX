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

namespace APP_QUANLY_KTX
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void cb_Hienthi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Hienthi.Checked)
            {
                txt_password.PasswordChar = (char)0;
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }
    }
}