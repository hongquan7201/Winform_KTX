﻿namespace ProjectQLKTX
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.lbQuenMK = new System.Windows.Forms.Label();
            this.btnDangnhap = new DevExpress.XtraEditors.CheckButton();
            this.btnThoat = new DevExpress.XtraEditors.CheckButton();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureEdit5 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit6 = new DevExpress.XtraEditors.PictureEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbHienthi = new DevExpress.XtraEditors.CheckEdit();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_ngongu = new System.Windows.Forms.TextBox();
            this.lb_quenmk = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_Hienthi = new DevExpress.XtraEditors.CheckEdit();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit6.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbHienthi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Hienthi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbQuenMK
            // 
            this.lbQuenMK.AutoSize = true;
            this.lbQuenMK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbQuenMK.Location = new System.Drawing.Point(365, 273);
            this.lbQuenMK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbQuenMK.Name = "lbQuenMK";
            this.lbQuenMK.Size = new System.Drawing.Size(104, 19);
            this.lbQuenMK.TabIndex = 57;
            this.lbQuenMK.Text = "Quên mật khẩu:";
            this.lbQuenMK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbQuenMK.Click += new System.EventHandler(this.lbQuenMK_Click);
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDangnhap.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDangnhap.Appearance.Options.UseBackColor = true;
            this.btnDangnhap.Appearance.Options.UseFont = true;
            this.btnDangnhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangnhap.ImageOptions.Image")));
            this.btnDangnhap.Location = new System.Drawing.Point(187, 223);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(135, 34);
            this.btnDangnhap.TabIndex = 56;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.CheckedChanged += new System.EventHandler(this.btn_Dangnhap_CheckedChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThoat.Appearance.Options.UseBackColor = true;
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(323, 223);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(133, 34);
            this.btnThoat.TabIndex = 55;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.CheckedChanged += new System.EventHandler(this.btnThoat_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(81, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 52;
            this.label6.Text = "Mật khẩu:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureEdit5
            // 
            this.pictureEdit5.EditValue = ((object)(resources.GetObject("pictureEdit5.EditValue")));
            this.pictureEdit5.Location = new System.Drawing.Point(43, 153);
            this.pictureEdit5.Name = "pictureEdit5";
            this.pictureEdit5.Properties.Appearance.BackColor = System.Drawing.Color.Azure;
            this.pictureEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit5.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit5.Properties.ZoomPercent = 5D;
            this.pictureEdit5.Size = new System.Drawing.Size(37, 30);
            this.pictureEdit5.TabIndex = 51;
            // 
            // pictureEdit6
            // 
            this.pictureEdit6.EditValue = ((object)(resources.GetObject("pictureEdit6.EditValue")));
            this.pictureEdit6.Location = new System.Drawing.Point(46, 104);
            this.pictureEdit6.Name = "pictureEdit6";
            this.pictureEdit6.Properties.Appearance.BackColor = System.Drawing.Color.Azure;
            this.pictureEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit6.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit6.Properties.ZoomPercent = 5D;
            this.pictureEdit6.Size = new System.Drawing.Size(37, 30);
            this.pictureEdit6.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(86, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 21);
            this.label7.TabIndex = 50;
            this.label7.Text = "Email:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtTendangnhap);
            this.panel2.Location = new System.Drawing.Point(187, 102);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 41);
            this.panel2.TabIndex = 46;
            // 
            // txtTendangnhap
            // 
            this.txtTendangnhap.BackColor = System.Drawing.Color.White;
            this.txtTendangnhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTendangnhap.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTendangnhap.ForeColor = System.Drawing.Color.Black;
            this.txtTendangnhap.Location = new System.Drawing.Point(4, 9);
            this.txtTendangnhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtTendangnhap.Multiline = true;
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.Size = new System.Drawing.Size(253, 23);
            this.txtTendangnhap.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.cbHienthi);
            this.panel6.Controls.Add(this.txtMatkhau);
            this.panel6.Location = new System.Drawing.Point(187, 151);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(264, 41);
            this.panel6.TabIndex = 45;
            // 
            // cbHienthi
            // 
            this.cbHienthi.Location = new System.Drawing.Point(244, 12);
            this.cbHienthi.Name = "cbHienthi";
            this.cbHienthi.Properties.Caption = "";
            this.cbHienthi.Size = new System.Drawing.Size(19, 20);
            this.cbHienthi.TabIndex = 45;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.BackColor = System.Drawing.Color.White;
            this.txtMatkhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatkhau.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMatkhau.ForeColor = System.Drawing.Color.Black;
            this.txtMatkhau.Location = new System.Drawing.Point(4, 9);
            this.txtMatkhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatkhau.Multiline = true;
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '*';
            this.txtMatkhau.Size = new System.Drawing.Size(233, 23);
            this.txtMatkhau.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(230, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 26);
            this.label1.TabIndex = 58;
            this.label1.Text = "ĐĂNG NHẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(0, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Azure;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ZoomPercent = 70D;
            this.pictureEdit1.Size = new System.Drawing.Size(178, 78);
            this.pictureEdit1.TabIndex = 38;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Location = new System.Drawing.Point(24, 24);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Azure;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.ZoomPercent = 5D;
            this.pictureEdit2.Size = new System.Drawing.Size(37, 30);
            this.pictureEdit2.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(62, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tên đăng nhập:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtEmail);
            this.panel4.Location = new System.Drawing.Point(211, 28);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(264, 41);
            this.panel4.TabIndex = 23;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(4, 9);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(253, 23);
            this.txtEmail.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txt_ngongu);
            this.panel3.Controls.Add(this.lb_quenmk);
            this.panel3.Location = new System.Drawing.Point(211, 126);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 41);
            this.panel3.TabIndex = 23;
            // 
            // txt_ngongu
            // 
            this.txt_ngongu.BackColor = System.Drawing.Color.White;
            this.txt_ngongu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ngongu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_ngongu.ForeColor = System.Drawing.Color.Black;
            this.txt_ngongu.Location = new System.Drawing.Point(4, 9);
            this.txt_ngongu.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ngongu.Multiline = true;
            this.txt_ngongu.Name = "txt_ngongu";
            this.txt_ngongu.Size = new System.Drawing.Size(209, 23);
            this.txt_ngongu.TabIndex = 5;
            // 
            // lb_quenmk
            // 
            this.lb_quenmk.AutoSize = true;
            this.lb_quenmk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_quenmk.Location = new System.Drawing.Point(299, 130);
            this.lb_quenmk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_quenmk.Name = "lb_quenmk";
            this.lb_quenmk.Size = new System.Drawing.Size(116, 17);
            this.lb_quenmk.TabIndex = 28;
            this.lb_quenmk.Text = "Fofgot Password ?";
            this.lb_quenmk.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cb_Hienthi);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Location = new System.Drawing.Point(211, 77);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 41);
            this.panel1.TabIndex = 22;
            // 
            // cb_Hienthi
            // 
            this.cb_Hienthi.Location = new System.Drawing.Point(244, 12);
            this.cb_Hienthi.Name = "cb_Hienthi";
            this.cb_Hienthi.Properties.Caption = "";
            this.cb_Hienthi.Size = new System.Drawing.Size(19, 20);
            this.cb_Hienthi.TabIndex = 45;
            this.cb_Hienthi.CheckedChanged += new System.EventHandler(this.cb_Hienthi_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(4, 9);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(233, 23);
            this.txtPassword.TabIndex = 5;
            // 
            // frmDangNhap
            // 
            this.Appearance.BackColor = System.Drawing.Color.Azure;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 301);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbQuenMK);
            this.Controls.Add(this.btnDangnhap);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureEdit5);
            this.Controls.Add(this.pictureEdit6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangNhap";
            this.Text = "DangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit6.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbHienthi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Hienthi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lbQuenMK;
        private DevExpress.XtraEditors.CheckButton btnDangnhap;
        private DevExpress.XtraEditors.CheckButton btnThoat;
        private Label label6;
        private DevExpress.XtraEditors.PictureEdit pictureEdit5;
        private DevExpress.XtraEditors.PictureEdit pictureEdit6;
        private Label label7;
        private Panel panel2;
        private TextBox txtTendangnhap;
        private Panel panel6;
        private DevExpress.XtraEditors.CheckEdit cbHienthi;
        private TextBox txtMatkhau;
        private Label label1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private Label label2;
        private Panel panel4;
        private TextBox txtEmail;
        private Panel panel3;
        private TextBox txt_ngongu;
        private Label lb_quenmk;
        private Panel panel1;
        private TextBox txtPassword;
        private Label txt_Quenmk;
        private DevExpress.XtraEditors.CheckEdit cb_Hienthi;
    }
}