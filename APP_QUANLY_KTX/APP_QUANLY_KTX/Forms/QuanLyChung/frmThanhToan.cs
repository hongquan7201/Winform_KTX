﻿using DevExpress.XtraEditors;
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
    public partial class frmThanhToan : DevExpress.XtraEditors.XtraForm
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }     
        private void btnLaphoadon_CheckedChanged(object sender, EventArgs e)
        {
            frmQLHoaDon frmQLHoaDon = new frmQLHoaDon();
            frmQLHoaDon.ShowDialog();
        }

        
    }
}