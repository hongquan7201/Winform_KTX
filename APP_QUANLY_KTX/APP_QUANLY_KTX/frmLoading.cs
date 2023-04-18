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
    public partial class frmLoading : DevExpress.XtraEditors.XtraForm
    {
        public frmLoading()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

        }
        public frmLoading( Form parent)
        {
            InitializeComponent();
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2,
                parent.Location.Y + parent.Height / 2 - this.Height / 2);
            }
            else
                this.StartPosition = FormStartPosition.CenterParent;
        }
        public void Close()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            if (pc1.Image!= null)
            {
                pc1.Image.Dispose();
            }
        }
    }
}