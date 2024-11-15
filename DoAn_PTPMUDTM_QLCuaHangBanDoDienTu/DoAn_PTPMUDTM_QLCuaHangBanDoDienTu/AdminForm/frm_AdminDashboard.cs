using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    public partial class frm_AdminDashboard : Form
    {
        public frm_AdminDashboard()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void frm_AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            DongTatCaForm();
            frm_SanPham frmSp = new frm_SanPham();
            frmSp.TopLevel = false;
            pnlControls.Controls.Add(frmSp);
            frmSp.Show();
        }

        private void btnNSX_Click(object sender, EventArgs e)
        {
            DongTatCaForm();
            frm_NhaSanXuat frmNSX = new frm_NhaSanXuat();
            frmNSX.TopLevel = false;
            pnlControls.Controls.Add(frmNSX);
            frmNSX.Show();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            frm_DangNhap frmDN = new frm_DangNhap();
            frmDN.Show();
            this.Hide();
        }

        private void DongTatCaForm()
        {
            foreach (Control ctrl in pnlControls.Controls)
            {
                if (ctrl is Form frm)
                {
                    frm.Close();
                }
            }
            pnlControls.Controls.Clear();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            DongTatCaForm();
            frm_TaiKhoan frmTK = new frm_TaiKhoan();
            frmTK.TopLevel = false;
            pnlControls.Controls.Add(frmTK);
            frmTK.Show();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            DongTatCaForm();
            frm_DonHang frmDH = new frm_DonHang();
            frmDH.TopLevel = false;
            pnlControls.Controls.Add(frmDH);
            frmDH.Show();
        }
    }
}
