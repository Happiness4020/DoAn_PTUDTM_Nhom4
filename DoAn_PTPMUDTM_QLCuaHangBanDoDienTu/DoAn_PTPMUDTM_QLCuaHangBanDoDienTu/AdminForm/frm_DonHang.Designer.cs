
namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    partial class frm_DonHang
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
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.MaDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTietDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhThucThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btn_XuatDonHang = new System.Windows.Forms.Button();
            this.btn_XuatChiTietDH = new System.Windows.Forms.Button();
            this.btn_XuatExcel = new System.Windows.Forms.Button();
            this.btn_XuatCTDHExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDonHang,
            this.TenDN,
            this.NgayDat,
            this.Email,
            this.HoTen,
            this.SoDienThoai,
            this.ChiTietDiaChi,
            this.TongGiaTri,
            this.HinhThucThanhToan,
            this.TrangThaiDonHang});
            this.dgvDonHang.Location = new System.Drawing.Point(16, 314);
            this.dgvDonHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.RowHeadersWidth = 51;
            this.dgvDonHang.Size = new System.Drawing.Size(1387, 510);
            this.dgvDonHang.TabIndex = 0;
            this.dgvDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellClick);
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
            // TenDN
            // 
            this.TenDN.DataPropertyName = "TenDN";
            this.TenDN.HeaderText = "Tên đăng nhập";
            this.TenDN.MinimumWidth = 6;
            this.TenDN.Name = "TenDN";
            this.TenDN.ReadOnly = true;
            this.TenDN.Width = 125;
            // 
            // NgayDat
            // 
            this.NgayDat.DataPropertyName = "NgayDat";
            this.NgayDat.HeaderText = "Ngày đặt";
            this.NgayDat.MinimumWidth = 6;
            this.NgayDat.Name = "NgayDat";
            this.NgayDat.ReadOnly = true;
            this.NgayDat.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 125;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 125;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.DataPropertyName = "SoDienThoai";
            this.SoDienThoai.HeaderText = "Số điện thoại";
            this.SoDienThoai.MinimumWidth = 6;
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.ReadOnly = true;
            this.SoDienThoai.Width = 125;
            // 
            // ChiTietDiaChi
            // 
            this.ChiTietDiaChi.DataPropertyName = "ChiTietDiaChi";
            this.ChiTietDiaChi.HeaderText = "Địa chỉ";
            this.ChiTietDiaChi.MinimumWidth = 6;
            this.ChiTietDiaChi.Name = "ChiTietDiaChi";
            this.ChiTietDiaChi.ReadOnly = true;
            this.ChiTietDiaChi.Width = 125;
            // 
            // TongGiaTri
            // 
            this.TongGiaTri.DataPropertyName = "TongGiaTri";
            this.TongGiaTri.HeaderText = "Tổng tiền";
            this.TongGiaTri.MinimumWidth = 6;
            this.TongGiaTri.Name = "TongGiaTri";
            this.TongGiaTri.ReadOnly = true;
            this.TongGiaTri.Width = 125;
            // 
            // HinhThucThanhToan
            // 
            this.HinhThucThanhToan.DataPropertyName = "HinhThucThanhToan";
            this.HinhThucThanhToan.HeaderText = "Hình thức thanh toán";
            this.HinhThucThanhToan.MinimumWidth = 6;
            this.HinhThucThanhToan.Name = "HinhThucThanhToan";
            this.HinhThucThanhToan.ReadOnly = true;
            this.HinhThucThanhToan.Width = 125;
            // 
            // TrangThaiDonHang
            // 
            this.TrangThaiDonHang.DataPropertyName = "TrangThaiDonHang";
            this.TrangThaiDonHang.HeaderText = "Trạng thái";
            this.TrangThaiDonHang.MinimumWidth = 6;
            this.TrangThaiDonHang.Name = "TrangThaiDonHang";
            this.TrangThaiDonHang.ReadOnly = true;
            this.TrangThaiDonHang.Width = 125;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(925, 260);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(215, 42);
            this.btnXacNhan.TabIndex = 63;
            this.btnXacNhan.Text = "Xác nhận đơn hàng";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.BackColor = System.Drawing.Color.SeaGreen;
            this.btnChiTiet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnChiTiet.Location = new System.Drawing.Point(702, 260);
            this.btnChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(215, 42);
            this.btnChiTiet.TabIndex = 64;
            this.btnChiTiet.Text = "Chi tiết đơn hàng";
            this.btnChiTiet.UseVisualStyleBackColor = false;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.SeaGreen;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(523, 265);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(109, 43);
            this.btnHuy.TabIndex = 71;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.SeaGreen;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(405, 265);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 43);
            this.btnTimKiem.TabIndex = 70;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 273);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 25);
            this.label12.TabIndex = 69;
            this.label12.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(119, 271);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(278, 30);
            this.txtTimKiem.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 39);
            this.label7.TabIndex = 72;
            this.label7.Text = "Đơn hàng";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(1147, 260);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 43);
            this.btnLuu.TabIndex = 73;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btn_XuatDonHang
            // 
            this.btn_XuatDonHang.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_XuatDonHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XuatDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatDonHang.ForeColor = System.Drawing.Color.White;
            this.btn_XuatDonHang.Location = new System.Drawing.Point(702, 209);
            this.btn_XuatDonHang.Margin = new System.Windows.Forms.Padding(4);
            this.btn_XuatDonHang.Name = "btn_XuatDonHang";
            this.btn_XuatDonHang.Size = new System.Drawing.Size(215, 43);
            this.btn_XuatDonHang.TabIndex = 74;
            this.btn_XuatDonHang.Text = "Xuất doanh thu";
            this.btn_XuatDonHang.UseVisualStyleBackColor = false;
            this.btn_XuatDonHang.Click += new System.EventHandler(this.btn_XuatDonHang_Click);
            // 
            // btn_XuatChiTietDH
            // 
            this.btn_XuatChiTietDH.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_XuatChiTietDH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XuatChiTietDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatChiTietDH.ForeColor = System.Drawing.Color.White;
            this.btn_XuatChiTietDH.Location = new System.Drawing.Point(702, 158);
            this.btn_XuatChiTietDH.Margin = new System.Windows.Forms.Padding(4);
            this.btn_XuatChiTietDH.Name = "btn_XuatChiTietDH";
            this.btn_XuatChiTietDH.Size = new System.Drawing.Size(215, 43);
            this.btn_XuatChiTietDH.TabIndex = 75;
            this.btn_XuatChiTietDH.Text = "Xuất chi tiết đơn hàng";
            this.btn_XuatChiTietDH.UseVisualStyleBackColor = false;
            this.btn_XuatChiTietDH.Click += new System.EventHandler(this.btn_XuatChiTietDH_Click);
            // 
            // btn_XuatExcel
            // 
            this.btn_XuatExcel.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_XuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatExcel.ForeColor = System.Drawing.Color.White;
            this.btn_XuatExcel.Location = new System.Drawing.Point(925, 209);
            this.btn_XuatExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_XuatExcel.Name = "btn_XuatExcel";
            this.btn_XuatExcel.Size = new System.Drawing.Size(274, 43);
            this.btn_XuatExcel.TabIndex = 76;
            this.btn_XuatExcel.Text = "Xuất doanh thu excel";
            this.btn_XuatExcel.UseVisualStyleBackColor = false;
            this.btn_XuatExcel.Click += new System.EventHandler(this.btn_XuatExcel_Click);
            // 
            // btn_XuatCTDHExcel
            // 
            this.btn_XuatCTDHExcel.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_XuatCTDHExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_XuatCTDHExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatCTDHExcel.ForeColor = System.Drawing.Color.White;
            this.btn_XuatCTDHExcel.Location = new System.Drawing.Point(925, 158);
            this.btn_XuatCTDHExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_XuatCTDHExcel.Name = "btn_XuatCTDHExcel";
            this.btn_XuatCTDHExcel.Size = new System.Drawing.Size(274, 43);
            this.btn_XuatCTDHExcel.TabIndex = 77;
            this.btn_XuatCTDHExcel.Text = "Xuất chi tiết đơn hàng excel";
            this.btn_XuatCTDHExcel.UseVisualStyleBackColor = false;
            this.btn_XuatCTDHExcel.Click += new System.EventHandler(this.btn_XuatCTDHExcel_Click);
            // 
            // frm_DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1419, 838);
            this.Controls.Add(this.btn_XuatCTDHExcel);
            this.Controls.Add(this.btn_XuatExcel);
            this.Controls.Add(this.btn_XuatChiTietDH);
            this.Controls.Add(this.btn_XuatDonHang);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnChiTiet);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dgvDonHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_DonHang";
            this.Text = "frm_DonHang";
            this.Load += new System.EventHandler(this.frm_DonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiTietDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhThucThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiDonHang;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btn_XuatDonHang;
        private System.Windows.Forms.Button btn_XuatChiTietDH;
        private System.Windows.Forms.Button btn_XuatExcel;
        private System.Windows.Forms.Button btn_XuatCTDHExcel;
    }
}