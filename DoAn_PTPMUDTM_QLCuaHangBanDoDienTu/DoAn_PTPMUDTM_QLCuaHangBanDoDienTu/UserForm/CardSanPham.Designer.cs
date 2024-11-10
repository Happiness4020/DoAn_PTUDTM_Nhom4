namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    partial class CardSanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.pnlImgSanPham = new System.Windows.Forms.Panel();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSanPham.Location = new System.Drawing.Point(16, 232);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(212, 21);
            this.lblTenSanPham.TabIndex = 0;
            this.lblTenSanPham.Text = "Tên sản phẩm";
            // 
            // pnlImgSanPham
            // 
            this.pnlImgSanPham.BackColor = System.Drawing.Color.White;
            this.pnlImgSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlImgSanPham.Location = new System.Drawing.Point(20, 13);
            this.pnlImgSanPham.Name = "pnlImgSanPham";
            this.pnlImgSanPham.Size = new System.Drawing.Size(208, 208);
            this.pnlImgSanPham.TabIndex = 1;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnXemChiTiet.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(61, 266);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(122, 33);
            this.btnXemChiTiet.TabIndex = 2;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // CardSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnXemChiTiet);
            this.Controls.Add(this.pnlImgSanPham);
            this.Controls.Add(this.lblTenSanPham);
            this.Margin = new System.Windows.Forms.Padding(100, 20, 0, 20);
            this.Name = "CardSanPham";
            this.Size = new System.Drawing.Size(250, 310);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.Panel pnlImgSanPham;
        private System.Windows.Forms.Button btnXemChiTiet;
    }
}
