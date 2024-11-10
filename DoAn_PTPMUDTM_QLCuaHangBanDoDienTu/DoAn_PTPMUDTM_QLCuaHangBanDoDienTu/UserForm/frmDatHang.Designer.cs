
namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    partial class frmDatHang
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoTienMat = new System.Windows.Forms.RadioButton();
            this.rdoNganHang = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.rdoDiaChiHT = new System.Windows.Forms.RadioButton();
            this.rdoDiaChiMoi = new System.Windows.Forms.RadioButton();
            this.txtDiaChiMoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDiaChi = new System.Windows.Forms.ComboBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 690);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoTienMat);
            this.panel2.Controls.Add(this.rdoNganHang);
            this.panel2.Location = new System.Drawing.Point(76, 443);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 68);
            this.panel2.TabIndex = 52;
            // 
            // rdoTienMat
            // 
            this.rdoTienMat.AutoSize = true;
            this.rdoTienMat.Checked = true;
            this.rdoTienMat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTienMat.Location = new System.Drawing.Point(3, 4);
            this.rdoTienMat.Name = "rdoTienMat";
            this.rdoTienMat.Size = new System.Drawing.Size(99, 26);
            this.rdoTienMat.TabIndex = 53;
            this.rdoTienMat.TabStop = true;
            this.rdoTienMat.Text = "Tiền mặt";
            this.rdoTienMat.UseVisualStyleBackColor = true;
            // 
            // rdoNganHang
            // 
            this.rdoNganHang.AutoSize = true;
            this.rdoNganHang.Enabled = false;
            this.rdoNganHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNganHang.Location = new System.Drawing.Point(3, 31);
            this.rdoNganHang.Name = "rdoNganHang";
            this.rdoNganHang.Size = new System.Drawing.Size(176, 26);
            this.rdoNganHang.TabIndex = 54;
            this.rdoNganHang.Text = "Liên kết ngân hàng";
            this.rdoNganHang.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.Properties.Resources.thoat;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(538, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(59, 37);
            this.panel3.TabIndex = 45;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(164, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 37);
            this.label1.TabIndex = 44;
            this.label1.Text = "TẠO ĐƠN HÀNG";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(246, 617);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 35);
            this.button1.TabIndex = 51;
            this.button1.Text = "Đặt hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongTien.Location = new System.Drawing.Point(424, 551);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 23);
            this.lblTongTien.TabIndex = 56;
            this.lblTongTien.Text = "000000000";
            // 
            // rdoDiaChiHT
            // 
            this.rdoDiaChiHT.AutoSize = true;
            this.rdoDiaChiHT.Checked = true;
            this.rdoDiaChiHT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDiaChiHT.Location = new System.Drawing.Point(80, 227);
            this.rdoDiaChiHT.Name = "rdoDiaChiHT";
            this.rdoDiaChiHT.Size = new System.Drawing.Size(151, 26);
            this.rdoDiaChiHT.TabIndex = 55;
            this.rdoDiaChiHT.TabStop = true;
            this.rdoDiaChiHT.Text = "Địa chỉ hiện có";
            this.rdoDiaChiHT.UseVisualStyleBackColor = true;
            this.rdoDiaChiHT.CheckedChanged += new System.EventHandler(this.rdoDiaChiHT_CheckedChanged);
            // 
            // rdoDiaChiMoi
            // 
            this.rdoDiaChiMoi.AutoSize = true;
            this.rdoDiaChiMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDiaChiMoi.Location = new System.Drawing.Point(80, 327);
            this.rdoDiaChiMoi.Name = "rdoDiaChiMoi";
            this.rdoDiaChiMoi.Size = new System.Drawing.Size(125, 26);
            this.rdoDiaChiMoi.TabIndex = 52;
            this.rdoDiaChiMoi.Text = "Địa chỉ mới";
            this.rdoDiaChiMoi.UseVisualStyleBackColor = true;
            this.rdoDiaChiMoi.CheckedChanged += new System.EventHandler(this.rdoDiaChiMoi_CheckedChanged);
            // 
            // txtDiaChiMoi
            // 
            this.txtDiaChiMoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChiMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiMoi.Location = new System.Drawing.Point(80, 359);
            this.txtDiaChiMoi.Name = "txtDiaChiMoi";
            this.txtDiaChiMoi.Size = new System.Drawing.Size(469, 30);
            this.txtDiaChiMoi.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 551);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 22);
            this.label5.TabIndex = 49;
            this.label5.Text = "Tổng thanh toán:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 22);
            this.label4.TabIndex = 48;
            this.label4.Text = "Phương thức thanh toán:";
            // 
            // cboDiaChi
            // 
            this.cboDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDiaChi.FormattingEnabled = true;
            this.cboDiaChi.Location = new System.Drawing.Point(80, 259);
            this.cboDiaChi.Name = "cboDiaChi";
            this.cboDiaChi.Size = new System.Drawing.Size(469, 30);
            this.cboDiaChi.TabIndex = 47;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoDienThoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(363, 162);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(186, 30);
            this.txtSoDienThoai.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 46;
            this.label3.Text = "Số điện thoại:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(80, 162);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(235, 30);
            this.txtHoTen.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 43;
            this.label2.Text = "Họ tên:";
            // 
            // frmDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(624, 693);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.rdoDiaChiHT);
            this.Controls.Add(this.rdoDiaChiMoi);
            this.Controls.Add(this.txtDiaChiMoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboDiaChi);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDatHang";
            this.Text = "frmDatHang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.RadioButton rdoDiaChiHT;
        private System.Windows.Forms.RadioButton rdoNganHang;
        private System.Windows.Forms.RadioButton rdoTienMat;
        private System.Windows.Forms.RadioButton rdoDiaChiMoi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDiaChiMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDiaChi;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}