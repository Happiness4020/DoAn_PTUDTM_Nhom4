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
        public frmDonHang()
        {
            InitializeComponent();
        }
        public void setData(string TenDN)
        {
            List<DonHang> lst = db.DonHangs.Where(t => t.TenDN == TenDN).OrderByDescending(t=>t.NgayDat).ToList();
            pnlDonHang.Controls.Clear();
            foreach(DonHang d in lst)
            {
                CardDonHang card = new CardDonHang();
                card.setDatTa(d);
                pnlDonHang.Controls.Add(card);
            }    

        }
    }
}
