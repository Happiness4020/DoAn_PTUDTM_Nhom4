
namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    partial class CardChiTietDonHang
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTuyChon = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblSoLuong);
            this.panel2.Controls.Add(this.lblTuyChon);
            this.panel2.Controls.Add(this.lblThanhTien);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lblDonGia);
            this.panel2.Controls.Add(this.lblTenSanPham);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1145, 112);
            this.panel2.TabIndex = 8;
            // 
            // lblTuyChon
            // 
            this.lblTuyChon.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyChon.Location = new System.Drawing.Point(204, 54);
            this.lblTuyChon.Name = "lblTuyChon";
            this.lblTuyChon.Size = new System.Drawing.Size(262, 19);
            this.lblTuyChon.TabIndex = 14;
            this.lblTuyChon.Text = "Tùy chọn: ";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.Location = new System.Drawing.Point(975, 49);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(92, 22);
            this.lblThanhTien.TabIndex = 11;
            this.lblThanhTien.Text = "Thành tiền";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(35, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(73, 76);
            this.panel1.TabIndex = 9;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Location = new System.Drawing.Point(587, 49);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(73, 22);
            this.lblDonGia.TabIndex = 8;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSanPham.Location = new System.Drawing.Point(204, 26);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(273, 28);
            this.lblTenSanPham.TabIndex = 7;
            this.lblTenSanPham.Text = "Tên sản phẩm";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Location = new System.Drawing.Point(789, 49);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(82, 22);
            this.lblSoLuong.TabIndex = 15;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // CardChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "CardChiTietDonHang";
            this.Size = new System.Drawing.Size(1155, 121);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTuyChon;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.Label lblSoLuong;
    }
}
