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
    public partial class CardChiTietDonHang : UserControl
    {
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        public CardChiTietDonHang()
        {
            InitializeComponent();
        }
        public void setData(ChiTietDonHang ct)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(t => t.ID == ct.MaCTSanPham).FirstOrDefault();
            SanPham sp = db.SanPhams.Where(t => t.MaSanPham == ctsp.MaSanPham).FirstOrDefault();
            lblTenSanPham.Text = sp.TenSanPham;

            lblDonGia.Text = ctsp.Gia.ToString();
            lblThanhTien.Text = ct.ThanhTien.ToString();
            lblSoLuong.Text = ct.SoLuong.ToString();
            lblTuyChon.Text = "Tùy chọn: " + ctsp.MauSac;
        }
    }
}
