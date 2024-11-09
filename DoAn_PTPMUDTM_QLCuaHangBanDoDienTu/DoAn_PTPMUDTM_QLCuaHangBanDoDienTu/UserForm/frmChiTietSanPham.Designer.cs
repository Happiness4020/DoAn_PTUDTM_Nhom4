
namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    partial class frmChiTietSanPham
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGia = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nbrSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemGioHang = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLuaChon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoLuong)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(41, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 347);
            this.panel1.TabIndex = 0;
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.ForeColor = System.Drawing.Color.Red;
            this.lblGia.Location = new System.Drawing.Point(583, 274);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(90, 35);
            this.lblGia.TabIndex = 1;
            this.lblGia.Text = "00000";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.button1.Location = new System.Drawing.Point(450, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Mua ngay";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // nbrSoLuong
            // 
            this.nbrSoLuong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrSoLuong.Location = new System.Drawing.Point(589, 366);
            this.nbrSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbrSoLuong.Name = "nbrSoLuong";
            this.nbrSoLuong.Size = new System.Drawing.Size(68, 27);
            this.nbrSoLuong.TabIndex = 3;
            this.nbrSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSanPham.Location = new System.Drawing.Point(445, 135);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(686, 67);
            this.lblTenSanPham.TabIndex = 4;
            this.lblTenSanPham.Text = "Tên Sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Giá:";
            // 
            // btnThemGioHang
            // 
            this.btnThemGioHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.btnThemGioHang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemGioHang.ForeColor = System.Drawing.Color.White;
            this.btnThemGioHang.Location = new System.Drawing.Point(665, 430);
            this.btnThemGioHang.Margin = new System.Windows.Forms.Padding(0);
            this.btnThemGioHang.Name = "btnThemGioHang";
            this.btnThemGioHang.Size = new System.Drawing.Size(147, 37);
            this.btnThemGioHang.TabIndex = 6;
            this.btnThemGioHang.Text = "Thêm giỏ hàng";
            this.btnThemGioHang.UseVisualStyleBackColor = false;
            this.btnThemGioHang.Click += new System.EventHandler(this.btnThemGioHang_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(445, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số lượng:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(38, 487);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(853, 122);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả sản phẩm: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(445, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lựa chọn:";
            // 
            // cboLuaChon
            // 
            this.cboLuaChon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLuaChon.FormattingEnabled = true;
            this.cboLuaChon.Location = new System.Drawing.Point(589, 229);
            this.cboLuaChon.Name = "cboLuaChon";
            this.cboLuaChon.Size = new System.Drawing.Size(149, 33);
            this.cboLuaChon.TabIndex = 10;
            this.cboLuaChon.SelectedIndexChanged += new System.EventHandler(this.cboLuaChon_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(445, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tồn kho:";
            // 
            // lblTonKho
            // 
            this.lblTonKho.AutoSize = true;
            this.lblTonKho.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTonKho.ForeColor = System.Drawing.Color.Black;
            this.lblTonKho.Location = new System.Drawing.Point(584, 322);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(67, 25);
            this.lblTonKho.TabIndex = 12;
            this.lblTonKho.Text = "00000";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1179, 63);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.Properties.Resources.thoat;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(1107, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(59, 37);
            this.panel3.TabIndex = 14;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(445, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 32);
            this.label5.TabIndex = 14;
            this.label5.Text = "CHI TIẾT SẢN PHẨM";
            // 
            // frmChiTietSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1177, 638);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTonKho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboLuaChon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThemGioHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTenSanPham);
            this.Controls.Add(this.nbrSoLuong);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChiTietSanPham";
            this.Text = "frmChiTietSanPham";
            ((System.ComponentModel.ISupportInitialize)(this.nbrSoLuong)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nbrSoLuong;
        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemGioHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLuaChon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
    }
}