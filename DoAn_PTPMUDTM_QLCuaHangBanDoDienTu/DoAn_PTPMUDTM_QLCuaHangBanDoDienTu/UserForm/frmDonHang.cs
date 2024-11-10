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
    public partial class frmDonHang : Form
    {
        TaiKhoan tk = new TaiKhoan();
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        List<DonHang> lst;
        public frmDonHang()
        {
            InitializeComponent();
        }
        public void setData(string TenDN)
        {
         
            lst = db.DonHangs.Where(t => t.TenDN == TenDN).OrderByDescending(t=>t.NgayDat).ToList();
            fillPanle(lst);

        }
        private void fillPanle(List<DonHang> l)
        {
            pnlDonHang.Controls.Clear();
            foreach (DonHang d in l)
            {
                CardDonHang card = new CardDonHang();
                card.setDatTa(d);
                pnlDonHang.Controls.Add(card);
            }
        }
        private void locDonHangTheoMa()
        {
            if (!string.IsNullOrWhiteSpace(txtMaDonHang.Text))
            {
                List<DonHang> loc = lst.Where(t => t.MaDonHang.ToString().Equals(txtMaDonHang.Text)).ToList();
                fillPanle(loc);
            }
            else
            {
                fillPanle(lst);
            }
        }
        private void locDonHangTheNgay()
        {
            txtMaDonHang.Text = "";
            List<DonHang> loc = lst.Where(t => t.NgayDat.Value.Date==dateNgayDat.Value.Date).ToList();
            fillPanle(loc);
        }
        private void dateNgayDat_ValueChanged(object sender, EventArgs e)
        {
            locDonHangTheNgay();
        }



        private void panel4_Click(object sender, EventArgs e)
        {
            txtMaDonHang.Text = "";
            fillPanle(lst);
        }

        private void txtMaDonHang_TextChanged(object sender, EventArgs e)
        {
            locDonHangTheoMa();
        }
    }
}
