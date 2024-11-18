
namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    partial class CardSanPhamDeXuat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.pnlImgSanPham = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTenSanPham);
            this.panel1.Controls.Add(this.pnlImgSanPham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 115);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.Font = new System.Drawing.Font("Times New Roman", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSanPham.Location = new System.Drawing.Point(3, 85);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(105, 22);
            this.lblTenSanPham.TabIndex = 5;
            this.lblTenSanPham.Text = "Tên sản phẩm";
            this.lblTenSanPham.Click += new System.EventHandler(this.panel1_Click);
            // 
            // pnlImgSanPham
            // 
            this.pnlImgSanPham.BackColor = System.Drawing.Color.White;
            this.pnlImgSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlImgSanPham.Location = new System.Drawing.Point(19, 7);
            this.pnlImgSanPham.Name = "pnlImgSanPham";
            this.pnlImgSanPham.Size = new System.Drawing.Size(74, 74);
            this.pnlImgSanPham.TabIndex = 4;
            this.pnlImgSanPham.Click += new System.EventHandler(this.panel1_Click);
            // 
            // CardSanPhamDeXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 40, 3);
            this.Name = "CardSanPhamDeXuat";
            this.Size = new System.Drawing.Size(111, 115);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.Panel pnlImgSanPham;
    }
}
