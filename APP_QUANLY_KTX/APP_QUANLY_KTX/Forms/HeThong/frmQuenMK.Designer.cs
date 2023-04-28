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
        /// the contents of this method with the code editor.
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
            pictureEdit6 = new DevExpress.XtraEditors.PictureEdit();
            label7 = new Label();
            panel2 = new Panel();
            txtEmail = new TextBox();
            panel6 = new Panel();
            txtCCCD = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit5.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit6.Properties).BeginInit();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // pictureEdit1
            // 
            pictureEdit1.EditValue = resources.GetObject("pictureEdit1.EditValue");
            pictureEdit1.Location = new Point(12, 8);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.Appearance.BackColor = SystemColors.GradientActiveCaption;
            pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.ZoomPercent = 70D;
            pictureEdit1.Size = new Size(170, 81);
            pictureEdit1.TabIndex = 74;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(209, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(232, 26);
            label1.TabIndex = 73;
            label1.Text = "QUÊN MẬT KHẨU?";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbQLaiDN
            // 
            lbQLaiDN.AutoSize = true;
            lbQLaiDN.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbQLaiDN.ForeColor = Color.Blue;
            lbQLaiDN.Location = new Point(250, 287);
            lbQLaiDN.Margin = new Padding(4, 0, 4, 0);
            lbQLaiDN.Name = "lbQLaiDN";
            lbQLaiDN.Size = new Size(147, 19);
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
            btnLayLaiMK.Location = new Point(235, 231);
            btnLayLaiMK.Name = "btnLayLaiMK";
            btnLayLaiMK.Size = new Size(183, 40);
            btnLayLaiMK.TabIndex = 71;
            btnLayLaiMK.Text = "Lấy lại mật khẩu";
            btnLayLaiMK.CheckedChanged += btnLayLaiMK_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(75, 126);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(107, 19);
            label6.TabIndex = 67;
            label6.Text = "Địa chỉ Email:";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureEdit5
            // 
            pictureEdit5.EditValue = resources.GetObject("pictureEdit5.EditValue");
            pictureEdit5.Location = new Point(29, 114);
            pictureEdit5.Name = "pictureEdit5";
            pictureEdit5.Properties.Appearance.BackColor = SystemColors.GradientActiveCaption;
            pictureEdit5.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit5.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit5.Properties.ZoomPercent = 5D;
            pictureEdit5.Size = new Size(39, 44);
            pictureEdit5.TabIndex = 66;
            // 
            // pictureEdit6
            // 
            pictureEdit6.EditValue = resources.GetObject("pictureEdit6.EditValue");
            pictureEdit6.Location = new Point(29, 164);
            pictureEdit6.Name = "pictureEdit6";
            pictureEdit6.Properties.Appearance.BackColor = SystemColors.GradientActiveCaption;
            pictureEdit6.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit6.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit6.Properties.ZoomPercent = 10D;
            pictureEdit6.Size = new Size(39, 43);
            pictureEdit6.TabIndex = 64;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(75, 175);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(106, 19);
            label7.TabIndex = 65;
            label7.Text = "CCCD/CMND:";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtEmail);
            panel2.Location = new Point(209, 117);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 41);
            panel2.TabIndex = 61;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(4, 9);
            txtEmail.Margin = new Padding(4);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(253, 23);
            txtEmail.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(txtCCCD);
            panel6.Location = new Point(209, 166);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(264, 41);
            panel6.TabIndex = 60;
            // 
            // txtCCCD
            // 
            txtCCCD.BackColor = Color.White;
            txtCCCD.BorderStyle = BorderStyle.None;
            txtCCCD.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCCCD.ForeColor = Color.Black;
            txtCCCD.Location = new Point(4, 9);
            txtCCCD.Margin = new Padding(4);
            txtCCCD.Multiline = true;
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(253, 23);
            txtCCCD.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(210, 72);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(246, 17);
            label2.TabIndex = 75;
            label2.Text = "(Nhập địa chỉ email để đặt lại mật khẩu)";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmQuenMK
            // 
            Appearance.BackColor = SystemColors.GradientActiveCaption;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 319);
            Controls.Add(label2);
            Controls.Add(pictureEdit1);
            Controls.Add(label1);
            Controls.Add(lbQLaiDN);
            Controls.Add(btnLayLaiMK);
            Controls.Add(label6);
            Controls.Add(pictureEdit5);
            Controls.Add(pictureEdit6);
            Controls.Add(label7);
            Controls.Add(panel2);
            Controls.Add(panel6);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IconOptions.Icon = (Icon)resources.GetObject("frmQuenMK.IconOptions.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmQuenMK";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên Mật Khẩu";
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit5.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit6.Properties).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
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
        private DevExpress.XtraEditors.PictureEdit pictureEdit6;
        private Label label7;
        private Panel panel2;
        private TextBox txtEmail;
        private Panel panel6;
        private TextBox txtCCCD;
        private Label label2;
    }
}