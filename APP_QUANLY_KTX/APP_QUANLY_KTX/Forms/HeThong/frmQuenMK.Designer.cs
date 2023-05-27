namespace ProjectQLKTX
{
    partial class frmQuenMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the Code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuenMK));
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            label1 = new Label();
            lbQLaiDN = new Label();
            btnLayLaiMK = new DevExpress.XtraEditors.CheckButton();
            label6 = new Label();
            pictureEdit5 = new DevExpress.XtraEditors.PictureEdit();
            panel2 = new Panel();
            txtEmail = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit5.Properties).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureEdit1
            // 
            pictureEdit1.EditValue = resources.GetObject("pictureEdit1.EditValue");
            pictureEdit1.Location = new Point(14, 10);
            pictureEdit1.Margin = new Padding(4, 4, 4, 4);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.Appearance.BackColor = SystemColors.GradientActiveCaption;
            pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.ZoomPercent = 70D;
            pictureEdit1.Size = new Size(198, 100);
            pictureEdit1.TabIndex = 74;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(244, 43);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(291, 35);
            label1.TabIndex = 73;
            label1.Text = "QUÊN MẬT KHẨU?";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbQLaiDN
            // 
            lbQLaiDN.AutoSize = true;
            lbQLaiDN.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbQLaiDN.ForeColor = Color.Blue;
            lbQLaiDN.Location = new Point(223, 315);
            lbQLaiDN.Margin = new Padding(5, 0, 5, 0);
            lbQLaiDN.Name = "lbQLaiDN";
            lbQLaiDN.Size = new Size(183, 24);
            lbQLaiDN.TabIndex = 72;
            lbQLaiDN.Text = "Quay lại đăng nhập";
            lbQLaiDN.TextAlign = ContentAlignment.TopCenter;
            lbQLaiDN.Click += lbQLaiDN_Click;
            // 
            // btnLayLaiMK
            // 
            btnLayLaiMK.Appearance.BackColor = SystemColors.Highlight;
            btnLayLaiMK.Appearance.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLayLaiMK.Appearance.Options.UseBackColor = true;
            btnLayLaiMK.Appearance.Options.UseFont = true;
            btnLayLaiMK.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnLayLaiMK.ImageOptions.SvgImage");
            btnLayLaiMK.Location = new Point(205, 246);
            btnLayLaiMK.Margin = new Padding(4, 4, 4, 4);
            btnLayLaiMK.Name = "btnLayLaiMK";
            btnLayLaiMK.Size = new Size(214, 49);
            btnLayLaiMK.TabIndex = 71;
            btnLayLaiMK.Text = "Lấy lại mật khẩu";
            btnLayLaiMK.CheckedChanged += btnLayLaiMK_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(88, 155);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(133, 24);
            label6.TabIndex = 67;
            label6.Text = "Địa chỉ Email:";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureEdit5
            // 
            pictureEdit5.EditValue = resources.GetObject("pictureEdit5.EditValue");
            pictureEdit5.Location = new Point(34, 140);
            pictureEdit5.Margin = new Padding(4, 4, 4, 4);
            pictureEdit5.Name = "pictureEdit5";
            pictureEdit5.Properties.Appearance.BackColor = SystemColors.GradientActiveCaption;
            pictureEdit5.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit5.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit5.Properties.ZoomPercent = 5D;
            pictureEdit5.Size = new Size(46, 54);
            pictureEdit5.TabIndex = 66;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtEmail);
            panel2.Location = new Point(244, 144);
            panel2.Margin = new Padding(5, 5, 5, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(308, 50);
            panel2.TabIndex = 61;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(5, 11);
            txtEmail.Margin = new Padding(5, 5, 5, 5);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(295, 28);
            txtEmail.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(245, 89);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(311, 21);
            label2.TabIndex = 75;
            label2.Text = "(Nhập địa chỉ email để đặt lại mật khẩu)";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmQuenMK
            // 
            Appearance.BackColor = SystemColors.GradientActiveCaption;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 369);
            Controls.Add(label2);
            Controls.Add(pictureEdit1);
            Controls.Add(label1);
            Controls.Add(lbQLaiDN);
            Controls.Add(btnLayLaiMK);
            Controls.Add(label6);
            Controls.Add(pictureEdit5);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.Icon = (Icon)resources.GetObject("frmQuenMK.IconOptions.Icon");
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmQuenMK";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên Mật Khẩu";
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit5.Properties).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private Label label1;
        private Label lbQLaiDN;
        private DevExpress.XtraEditors.CheckButton btnLayLaiMK;
        private Label label6;
        private DevExpress.XtraEditors.PictureEdit pictureEdit5;
        private Panel panel2;
        private TextBox txtEmail;
        private Label label2;
    }
}