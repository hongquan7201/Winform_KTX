﻿namespace ProjectQLKTX
{
    partial class frmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.pc1 = new System.Windows.Forms.PictureBox();
            this.pc2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc2)).BeginInit();
            this.SuspendLayout();
            // 
            // pc1
            // 
            this.pc1.Image = ((System.Drawing.Image)(resources.GetObject("pc1.Image")));
            this.pc1.Location = new System.Drawing.Point(4, 10);
            this.pc1.Name = "pc1";
            this.pc1.Size = new System.Drawing.Size(358, 199);
            this.pc1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pc1.TabIndex = 4;
            this.pc1.TabStop = false;
            // 
            // pc2
            // 
            this.pc2.Image = ((System.Drawing.Image)(resources.GetObject("pc2.Image")));
            this.pc2.Location = new System.Drawing.Point(1, 215);
            this.pc2.Name = "pc2";
            this.pc2.Size = new System.Drawing.Size(361, 275);
            this.pc2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pc2.TabIndex = 3;
            this.pc2.TabStop = false;
            // 
            // frmLoading
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 486);
            this.Controls.Add(this.pc1);
            this.Controls.Add(this.pc2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmLoading.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            ((System.ComponentModel.ISupportInitialize)(this.pc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pc1;
        private PictureBox pc2;
    }
}