using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu
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
            frm_SanPham frmSp = new frm_SanPham();
            frmSp.TopLevel = false;
            pnlControls.Controls.Add(frmSp);
            frmSp.Show();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            frm_DangNhap frmDN = new frm_DangNhap();
            frmDN.Show();
            this.Hide();
        }
    }
}
