using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    public partial class frmChiTietDonHang : Form
    {
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        public frmChiTietDonHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void setData(DonHang dh)
        {
            List<ChiTietDonHang> lstct = db.ChiTietDonHangs.Where(t => t.MaDonHang == dh.MaDonHang).ToList();
            pnlChiTietDonHang.Controls.Clear();
            foreach(ChiTietDonHang ct in lstct)
            {
                CardChiTietDonHang card = new CardChiTietDonHang();
                card.setData(ct);
                pnlChiTietDonHang.Controls.Add(card);
            }    
        }
       
        private void panel3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
