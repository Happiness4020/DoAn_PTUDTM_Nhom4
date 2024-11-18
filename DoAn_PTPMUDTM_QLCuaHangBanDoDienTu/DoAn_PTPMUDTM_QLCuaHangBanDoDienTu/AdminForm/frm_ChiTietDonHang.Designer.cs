
namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    partial class frm_ChiTietDonHang
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
            this.dgvCTDH = new System.Windows.Forms.DataGridView();
            this.MaDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiCTDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCTDH
            // 
            this.dgvCTDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDonHang,
            this.MaCTSanPham,
            this.SoLuong,
            this.ThanhTien,
            this.TrangThaiCTDH});
            this.dgvCTDH.Location = new System.Drawing.Point(16, 15);
            this.dgvCTDH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCTDH.Name = "dgvCTDH";
            this.dgvCTDH.RowHeadersWidth = 51;
            this.dgvCTDH.Size = new System.Drawing.Size(731, 542);
            this.dgvCTDH.TabIndex = 0;
            // 
            // MaDonHang
            // 
            this.MaDonHang.DataPropertyName = "MaDonHang";
            this.MaDonHang.HeaderText = "Mã đơn hàng";
            this.MaDonHang.MinimumWidth = 6;
            this.MaDonHang.Name = "MaDonHang";
            this.MaDonHang.ReadOnly = true;
            this.MaDonHang.Width = 125;
            // 
            // MaCTSanPham
            // 
            this.MaCTSanPham.DataPropertyName = "MaCTSanPham";
            this.MaCTSanPham.HeaderText = "Mã chi tiết sản phẩm";
            this.MaCTSanPham.MinimumWidth = 6;
            this.MaCTSanPham.Name = "MaCTSanPham";
            this.MaCTSanPham.ReadOnly = true;
            this.MaCTSanPham.Width = 125;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 125;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            this.ThanhTien.Width = 125;
            // 
            // TrangThaiCTDH
            // 
            this.TrangThaiCTDH.DataPropertyName = "TrangThaiCTDH";
            this.TrangThaiCTDH.HeaderText = "Trạng thái";
            this.TrangThaiCTDH.MinimumWidth = 6;
            this.TrangThaiCTDH.Name = "TrangThaiCTDH";
            this.TrangThaiCTDH.ReadOnly = true;
            this.TrangThaiCTDH.Width = 125;
            // 
            // frm_ChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(763, 569);
            this.Controls.Add(this.dgvCTDH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frm_ChiTietDonHang";
            this.Text = "Chi tiết đơn hàng";
            this.Load += new System.EventHandler(this.frm_ChiTietDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCTDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiCTDH;
    }
}