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

        private void btnImport_CheckedChanged(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png,.jpg)|*.png;*.jpg";
            if (openFile.ShowDialog() == DialogResult.OK )
            {
              //  picHinhAnh.Image = Image.FormFile(openFile.FileName);

            }
        }
    }
}