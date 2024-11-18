
namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    partial class frm_PhieuNhap
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
            this.DateTime_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.DateTime_Den = new System.Windows.Forms.DateTimePicker();
            this.txt_ThanhTien = new System.Windows.Forms.TextBox();
            this.txt_MaPN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DateTime_Tu = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgrv_ChiTietPN = new System.Windows.Forms.DataGridView();
            this.btn_LuuCTPN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_SanPham = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Chuyen = new System.Windows.Forms.Button();
            this.dgrv_DanhSachSP = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxThanhToan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Loc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_HuyPN = new System.Windows.Forms.Button();
            this.btn_LuuPN = new System.Windows.Forms.Button();
            this.btn_TaoMoi = new System.Windows.Forms.Button();
            this.dgrv_MaPN = new System.Windows.Forms.DataGridView();
            this.MAPHIEUNHAP_PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYNHAP_PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhtien_PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhThucThanhToan_PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_CTPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTSanPham_CTPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaNhap_CTPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG_CTPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THANHTIEN_CTPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENSANPHAM_SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DONGIA_SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONGTON_SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MALOAISANPHAM_SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_ChiTietPN)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_DanhSachSP)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_MaPN)).BeginInit();
            this.SuspendLayout();
            // 
            // DateTime_NgayNhap
            // 
            this.DateTime_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTime_NgayNhap.Location = new System.Drawing.Point(522, 74);
            this.DateTime_NgayNhap.Name = "DateTime_NgayNhap";
            this.DateTime_NgayNhap.Size = new System.Drawing.Size(167, 30);
            this.DateTime_NgayNhap.TabIndex = 15;
            // 
            // DateTime_Den
            // 
            this.DateTime_Den.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTime_Den.Location = new System.Drawing.Point(331, 35);
            this.DateTime_Den.Name = "DateTime_Den";
            this.DateTime_Den.Size = new System.Drawing.Size(162, 30);
            this.DateTime_Den.TabIndex = 14;
            // 
            // txt_ThanhTien
            // 
            this.txt_ThanhTien.Enabled = false;
            this.txt_ThanhTien.Location = new System.Drawing.Point(151, 129);
            this.txt_ThanhTien.Name = "txt_ThanhTien";
            this.txt_ThanhTien.Size = new System.Drawing.Size(210, 30);
            this.txt_ThanhTien.TabIndex = 12;
            // 
            // txt_MaPN
            // 
            this.txt_MaPN.Enabled = false;
            this.txt_MaPN.Location = new System.Drawing.Point(151, 77);
            this.txt_MaPN.Name = "txt_MaPN";
            this.txt_MaPN.Size = new System.Drawing.Size(210, 30);
            this.txt_MaPN.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Thành tiền";
            // 
            // DateTime_Tu
            // 
            this.DateTime_Tu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTime_Tu.Location = new System.Drawing.Point(70, 36);
            this.DateTime_Tu.Name = "DateTime_Tu";
            this.DateTime_Tu.Size = new System.Drawing.Size(183, 30);
            this.DateTime_Tu.TabIndex = 13;
            this.DateTime_Tu.Value = new System.DateTime(2024, 9, 30, 0, 0, 0, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgrv_ChiTietPN);
            this.groupBox3.Controls.Add(this.btn_LuuCTPN);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(620, 490);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(778, 233);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết phiếu nhập";
            // 
            // dgrv_ChiTietPN
            // 
            this.dgrv_ChiTietPN.AllowUserToAddRows = false;
            this.dgrv_ChiTietPN.AllowUserToDeleteRows = false;
            this.dgrv_ChiTietPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrv_ChiTietPN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_CTPN,
            this.MaCTSanPham_CTPN,
            this.DonGiaNhap_CTPN,
            this.SOLUONG_CTPN,
            this.THANHTIEN_CTPN});
            this.dgrv_ChiTietPN.Location = new System.Drawing.Point(23, 60);
            this.dgrv_ChiTietPN.Name = "dgrv_ChiTietPN";
            this.dgrv_ChiTietPN.ReadOnly = true;
            this.dgrv_ChiTietPN.RowHeadersWidth = 51;
            this.dgrv_ChiTietPN.RowTemplate.Height = 24;
            this.dgrv_ChiTietPN.Size = new System.Drawing.Size(738, 150);
            this.dgrv_ChiTietPN.TabIndex = 2;
            this.dgrv_ChiTietPN.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrv_ChiTietPN_CellMouseClick);
            // 
            // btn_LuuCTPN
            // 
            this.btn_LuuCTPN.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_LuuCTPN.ForeColor = System.Drawing.Color.White;
            this.btn_LuuCTPN.Location = new System.Drawing.Point(555, 20);
            this.btn_LuuCTPN.Name = "btn_LuuCTPN";
            this.btn_LuuCTPN.Size = new System.Drawing.Size(180, 34);
            this.btn_LuuCTPN.TabIndex = 1;
            this.btn_LuuCTPN.Text = "Lưu chi tiết phiếu nhập";
            this.btn_LuuCTPN.UseVisualStyleBackColor = false;
            this.btn_LuuCTPN.Click += new System.EventHandler(this.btn_LuuCTPN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(396, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày nhập";
            // 
            // cbx_SanPham
            // 
            this.cbx_SanPham.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_SanPham.FormattingEnabled = true;
            this.cbx_SanPham.Location = new System.Drawing.Point(184, 35);
            this.cbx_SanPham.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_SanPham.Name = "cbx_SanPham";
            this.cbx_SanPham.Size = new System.Drawing.Size(236, 30);
            this.cbx_SanPham.TabIndex = 6;
            this.cbx_SanPham.SelectedIndexChanged += new System.EventHandler(this.cbx_SanPham_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sản phẩm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Chuyen);
            this.groupBox1.Controls.Add(this.dgrv_DanhSachSP);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(599, 653);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sản phẩm";
            // 
            // btn_Chuyen
            // 
            this.btn_Chuyen.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Chuyen.ForeColor = System.Drawing.Color.White;
            this.btn_Chuyen.Location = new System.Drawing.Point(291, 596);
            this.btn_Chuyen.Name = "btn_Chuyen";
            this.btn_Chuyen.Size = new System.Drawing.Size(283, 50);
            this.btn_Chuyen.TabIndex = 1;
            this.btn_Chuyen.Text = "Thêm vào chi tiết phiếu nhập";
            this.btn_Chuyen.UseVisualStyleBackColor = false;
            this.btn_Chuyen.Click += new System.EventHandler(this.btn_Chuyen_Click);
            // 
            // dgrv_DanhSachSP
            // 
            this.dgrv_DanhSachSP.AllowUserToOrderColumns = true;
            this.dgrv_DanhSachSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrv_DanhSachSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn,
            this.ID,
            this.TENSANPHAM_SP,
            this.DONGIA_SP,
            this.SOLUONGTON_SP,
            this.MALOAISANPHAM_SP,
            this.MoTa});
            this.dgrv_DanhSachSP.Location = new System.Drawing.Point(7, 27);
            this.dgrv_DanhSachSP.Name = "dgrv_DanhSachSP";
            this.dgrv_DanhSachSP.RowHeadersWidth = 51;
            this.dgrv_DanhSachSP.RowTemplate.Height = 24;
            this.dgrv_DanhSachSP.Size = new System.Drawing.Size(592, 551);
            this.dgrv_DanhSachSP.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxThanhToan);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.DateTime_NgayNhap);
            this.groupBox2.Controls.Add(this.DateTime_Den);
            this.groupBox2.Controls.Add(this.DateTime_Tu);
            this.groupBox2.Controls.Add(this.txt_ThanhTien);
            this.groupBox2.Controls.Add(this.txt_MaPN);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_Loc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_HuyPN);
            this.groupBox2.Controls.Add(this.btn_LuuPN);
            this.groupBox2.Controls.Add(this.btn_TaoMoi);
            this.groupBox2.Controls.Add(this.dgrv_MaPN);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(623, 57);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(775, 403);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phiếu nhập";
            // 
            // cbxThanhToan
            // 
            this.cbxThanhToan.FormattingEnabled = true;
            this.cbxThanhToan.Items.AddRange(new object[] {
            "Chọn phương thức thanh toán",
            "Tiền mặt",
            "Chuyển khoản"});
            this.cbxThanhToan.Location = new System.Drawing.Point(578, 132);
            this.cbxThanhToan.Name = "cbxThanhToan";
            this.cbxThanhToan.Size = new System.Drawing.Size(180, 30);
            this.cbxThanhToan.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 22);
            this.label7.TabIndex = 16;
            this.label7.Text = "Hình thức thanh toán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã phiếu nhập";
            // 
            // btn_Loc
            // 
            this.btn_Loc.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_Loc.ForeColor = System.Drawing.Color.White;
            this.btn_Loc.Location = new System.Drawing.Point(522, 32);
            this.btn_Loc.Name = "btn_Loc";
            this.btn_Loc.Size = new System.Drawing.Size(75, 30);
            this.btn_Loc.TabIndex = 6;
            this.btn_Loc.Text = "Lọc";
            this.btn_Loc.UseVisualStyleBackColor = false;
            this.btn_Loc.Click += new System.EventHandler(this.btn_Loc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ";
            // 
            // btn_HuyPN
            // 
            this.btn_HuyPN.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_HuyPN.ForeColor = System.Drawing.Color.White;
            this.btn_HuyPN.Location = new System.Drawing.Point(535, 362);
            this.btn_HuyPN.Name = "btn_HuyPN";
            this.btn_HuyPN.Size = new System.Drawing.Size(154, 41);
            this.btn_HuyPN.TabIndex = 3;
            this.btn_HuyPN.Text = "Hủy phiếu nhập";
            this.btn_HuyPN.UseVisualStyleBackColor = false;
            this.btn_HuyPN.Click += new System.EventHandler(this.btn_HuyPN_Click);
            // 
            // btn_LuuPN
            // 
            this.btn_LuuPN.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_LuuPN.ForeColor = System.Drawing.Color.White;
            this.btn_LuuPN.Location = new System.Drawing.Point(361, 362);
            this.btn_LuuPN.Name = "btn_LuuPN";
            this.btn_LuuPN.Size = new System.Drawing.Size(157, 41);
            this.btn_LuuPN.TabIndex = 2;
            this.btn_LuuPN.Text = "Lưu phiếu nhập";
            this.btn_LuuPN.UseVisualStyleBackColor = false;
            this.btn_LuuPN.Click += new System.EventHandler(this.btn_LuuPN_Click);
            // 
            // btn_TaoMoi
            // 
            this.btn_TaoMoi.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_TaoMoi.ForeColor = System.Drawing.Color.White;
            this.btn_TaoMoi.Location = new System.Drawing.Point(240, 362);
            this.btn_TaoMoi.Name = "btn_TaoMoi";
            this.btn_TaoMoi.Size = new System.Drawing.Size(101, 41);
            this.btn_TaoMoi.TabIndex = 1;
            this.btn_TaoMoi.Text = "Tạo mới";
            this.btn_TaoMoi.UseVisualStyleBackColor = false;
            this.btn_TaoMoi.Click += new System.EventHandler(this.btn_TaoMoi_Click);
            // 
            // dgrv_MaPN
            // 
            this.dgrv_MaPN.AllowUserToAddRows = false;
            this.dgrv_MaPN.AllowUserToDeleteRows = false;
            this.dgrv_MaPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrv_MaPN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAPHIEUNHAP_PN,
            this.NGAYNHAP_PN,
            this.thanhtien_PN,
            this.HinhThucThanhToan_PN});
            this.dgrv_MaPN.Location = new System.Drawing.Point(20, 182);
            this.dgrv_MaPN.Name = "dgrv_MaPN";
            this.dgrv_MaPN.ReadOnly = true;
            this.dgrv_MaPN.RowHeadersWidth = 51;
            this.dgrv_MaPN.RowTemplate.Height = 24;
            this.dgrv_MaPN.Size = new System.Drawing.Size(738, 167);
            this.dgrv_MaPN.TabIndex = 0;
            // 
            // MAPHIEUNHAP_PN
            // 
            this.MAPHIEUNHAP_PN.DataPropertyName = "MAPHIEUNHAP";
            this.MAPHIEUNHAP_PN.HeaderText = "Mã phiếu nhập";
            this.MAPHIEUNHAP_PN.MinimumWidth = 6;
            this.MAPHIEUNHAP_PN.Name = "MAPHIEUNHAP_PN";
            this.MAPHIEUNHAP_PN.ReadOnly = true;
            this.MAPHIEUNHAP_PN.Width = 150;
            // 
            // NGAYNHAP_PN
            // 
            this.NGAYNHAP_PN.DataPropertyName = "NGAYNHAP";
            this.NGAYNHAP_PN.HeaderText = "Ngày nhập";
            this.NGAYNHAP_PN.MinimumWidth = 6;
            this.NGAYNHAP_PN.Name = "NGAYNHAP_PN";
            this.NGAYNHAP_PN.ReadOnly = true;
            this.NGAYNHAP_PN.Width = 150;
            // 
            // thanhtien_PN
            // 
            this.thanhtien_PN.DataPropertyName = "THANHTIEN";
            this.thanhtien_PN.HeaderText = "Thành tiền";
            this.thanhtien_PN.MinimumWidth = 6;
            this.thanhtien_PN.Name = "thanhtien_PN";
            this.thanhtien_PN.ReadOnly = true;
            this.thanhtien_PN.Width = 150;
            // 
            // HinhThucThanhToan_PN
            // 
            this.HinhThucThanhToan_PN.DataPropertyName = "HinhThucThanhToan";
            this.HinhThucThanhToan_PN.HeaderText = "Hình thức thanh toán";
            this.HinhThucThanhToan_PN.MinimumWidth = 6;
            this.HinhThucThanhToan_PN.Name = "HinhThucThanhToan_PN";
            this.HinhThucThanhToan_PN.ReadOnly = true;
            this.HinhThucThanhToan_PN.Width = 125;
            // 
            // ID_CTPN
            // 
            this.ID_CTPN.DataPropertyName = "ID";
            this.ID_CTPN.HeaderText = "Mã phiếu nhập";
            this.ID_CTPN.MinimumWidth = 6;
            this.ID_CTPN.Name = "ID_CTPN";
            this.ID_CTPN.ReadOnly = true;
            this.ID_CTPN.Width = 125;
            // 
            // MaCTSanPham_CTPN
            // 
            this.MaCTSanPham_CTPN.DataPropertyName = "MaCTSanPham";
            this.MaCTSanPham_CTPN.HeaderText = "Mã chi tiết sản phẩm";
            this.MaCTSanPham_CTPN.MinimumWidth = 6;
            this.MaCTSanPham_CTPN.Name = "MaCTSanPham_CTPN";
            this.MaCTSanPham_CTPN.ReadOnly = true;
            this.MaCTSanPham_CTPN.Width = 125;
            // 
            // DonGiaNhap_CTPN
            // 
            this.DonGiaNhap_CTPN.DataPropertyName = "DonGiaNhap";
            this.DonGiaNhap_CTPN.HeaderText = "Đơn giá nhập";
            this.DonGiaNhap_CTPN.MinimumWidth = 6;
            this.DonGiaNhap_CTPN.Name = "DonGiaNhap_CTPN";
            this.DonGiaNhap_CTPN.ReadOnly = true;
            this.DonGiaNhap_CTPN.Width = 125;
            // 
            // SOLUONG_CTPN
            // 
            this.SOLUONG_CTPN.DataPropertyName = "SoLuong";
            this.SOLUONG_CTPN.HeaderText = "Số lượng";
            this.SOLUONG_CTPN.MinimumWidth = 6;
            this.SOLUONG_CTPN.Name = "SOLUONG_CTPN";
            this.SOLUONG_CTPN.ReadOnly = true;
            this.SOLUONG_CTPN.Width = 125;
            // 
            // THANHTIEN_CTPN
            // 
            this.THANHTIEN_CTPN.DataPropertyName = "ThanhTien";
            this.THANHTIEN_CTPN.HeaderText = "Thành tiền";
            this.THANHTIEN_CTPN.MinimumWidth = 6;
            this.THANHTIEN_CTPN.Name = "THANHTIEN_CTPN";
            this.THANHTIEN_CTPN.ReadOnly = true;
            this.THANHTIEN_CTPN.Width = 125;
            // 
            // SelectColumn
            // 
            this.SelectColumn.DataPropertyName = "SelectColumn";
            this.SelectColumn.HeaderText = "Thêm";
            this.SelectColumn.MinimumWidth = 6;
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectColumn.Width = 60;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Mã sản phẩm";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 125;
            // 
            // TENSANPHAM_SP
            // 
            this.TENSANPHAM_SP.DataPropertyName = "TenSanPham";
            this.TENSANPHAM_SP.HeaderText = "Tên sản phẩm";
            this.TENSANPHAM_SP.MinimumWidth = 6;
            this.TENSANPHAM_SP.Name = "TENSANPHAM_SP";
            this.TENSANPHAM_SP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TENSANPHAM_SP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TENSANPHAM_SP.Width = 125;
            // 
            // DONGIA_SP
            // 
            this.DONGIA_SP.DataPropertyName = "Gia";
            this.DONGIA_SP.HeaderText = "Đơn giá";
            this.DONGIA_SP.MinimumWidth = 6;
            this.DONGIA_SP.Name = "DONGIA_SP";
            this.DONGIA_SP.Width = 125;
            // 
            // SOLUONGTON_SP
            // 
            this.SOLUONGTON_SP.DataPropertyName = "Soluong";
            this.SOLUONGTON_SP.HeaderText = "Số lượng";
            this.SOLUONGTON_SP.MinimumWidth = 6;
            this.SOLUONGTON_SP.Name = "SOLUONGTON_SP";
            this.SOLUONGTON_SP.Width = 125;
            // 
            // MALOAISANPHAM_SP
            // 
            this.MALOAISANPHAM_SP.DataPropertyName = "MauSac";
            this.MALOAISANPHAM_SP.HeaderText = "Màu sắc";
            this.MALOAISANPHAM_SP.MinimumWidth = 6;
            this.MALOAISANPHAM_SP.Name = "MALOAISANPHAM_SP";
            this.MALOAISANPHAM_SP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MALOAISANPHAM_SP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MALOAISANPHAM_SP.Width = 125;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.MinimumWidth = 6;
            this.MoTa.Name = "MoTa";
            this.MoTa.Width = 125;
            // 
            // frm_PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1425, 743);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cbx_SanPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_PhieuNhap";
            this.Text = "frm_PhieuNhap";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_ChiTietPN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_DanhSachSP)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrv_MaPN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateTime_NgayNhap;
        private System.Windows.Forms.DateTimePicker DateTime_Den;
        private System.Windows.Forms.TextBox txt_ThanhTien;
        private System.Windows.Forms.TextBox txt_MaPN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DateTime_Tu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgrv_ChiTietPN;
        private System.Windows.Forms.Button btn_LuuCTPN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_SanPham;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Chuyen;
        private System.Windows.Forms.DataGridView dgrv_DanhSachSP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Loc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_HuyPN;
        private System.Windows.Forms.Button btn_LuuPN;
        private System.Windows.Forms.Button btn_TaoMoi;
        private System.Windows.Forms.DataGridView dgrv_MaPN;
        private System.Windows.Forms.ComboBox cbxThanhToan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAPHIEUNHAP_PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYNHAP_PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtien_PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhThucThanhToan_PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CTPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTSanPham_CTPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaNhap_CTPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG_CTPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn THANHTIEN_CTPN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSANPHAM_SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DONGIA_SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONGTON_SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MALOAISANPHAM_SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
    }
}