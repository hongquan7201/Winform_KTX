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
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }
        private void btnThoat_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbHienthi1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi1.Checked)
            {
                txtPasswordCu.PasswordChar = (char)0;
            }
            else
            {
                txtPasswordCu.PasswordChar = '*';
            }
        }

        private void cbHienthi2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi2.Checked)
            {
                txtPasswordMoi.PasswordChar = (char)0;
            }
            else
            {
                txtPasswordMoi.PasswordChar = '*';
            }
        }

        private void cbHienthi3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienthi3.Checked)
            {
                txtNhapLaiPassword.PasswordChar = (char)0;
            }
            else
            {
                txtNhapLaiPassword.PasswordChar = '*';
            }
        }
    }
}