using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    public partial class frmUserMain : Form
    {
        public frmUserMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;  // Tối đa hóa form
            frmSanPham frm = new frmSanPham();
            ClickButtonLoadForm(frm);
        }

        
        private void ClickButtonLoadForm(Form frm)
        {
            pnlMain.Controls.Clear();
            // Thiết lập Form con
            frm.TopLevel = false;  // Phải được thiết lập trước khi thêm vào panel
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(frm);
            pnlMain.Tag = frm;

            frm.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.setData("nguyentandat");
            ClickButtonLoadForm(frm);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            frmDonHang frm = new frmDonHang();
            frm.setData("nguyentandat");
            ClickButtonLoadForm(frm);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            ClickButtonLoadForm(frm);
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            frmGioHang frm = new frmGioHang();
            frm.setData("nguyentandat");
            ClickButtonLoadForm(frm);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.TimSanPham(txtTimKiem.Text);
            ClickButtonLoadForm(frm);
        }

        private void frmUserMain_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            frmGioHang frm = new frmGioHang();
            frm.setData("nguyentandat");
            ClickButtonLoadForm(frm);
        }

        private void btnDiaChi_Click(object sender, EventArgs e)
        {
            frmDiaChi frm = new frmDiaChi();
            frm.setData("nguyentandat");
            ClickButtonLoadForm(frm);
        }
    }
}
