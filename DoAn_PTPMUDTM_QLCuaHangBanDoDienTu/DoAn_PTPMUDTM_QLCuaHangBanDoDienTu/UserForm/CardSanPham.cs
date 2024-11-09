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
    public partial class CardSanPham : UserControl
    {
        public CardSanPham()
        {
            InitializeComponent();
        }
        SanPham sp;
        public void setData(SanPham s)
        {
            this.sp = s;
            lblTenSanPham.AutoEllipsis = true;

            lblTenSanPham.Text = sp.TenSanPham;
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            frmChiTietSanPham frm = new frmChiTietSanPham();
            frm.setData(sp);
            frm.Show();
        }
    }
}
