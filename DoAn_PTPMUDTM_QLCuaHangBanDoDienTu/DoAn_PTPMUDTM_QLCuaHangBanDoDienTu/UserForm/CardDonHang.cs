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
    public partial class CardDonHang : UserControl
    {
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        DonHang dh;
        public CardDonHang()
        {
            InitializeComponent();
        }
        public void setDatTa(DonHang x)
        {
            this.dh = db.DonHangs.Where(d => d.MaDonHang == x.MaDonHang).FirstOrDefault();
            lblMaDonHang.Text = dh.MaDonHang.ToString();
            lblNgayDat.Text = dh.NgayDat?.ToString("dd/MM/yyyy") ?? "Ngày không xác định";
            lblHoTen.Text = dh.HoTen;
            lblSoDienThoai.Text = dh.SoDienThoai;
            lblTrangThai.Text = dh.TrangThaiDonHang;
            lblTongTien.Text = dh.TongGiaTri.ToString();
            lblDiaChi.Text = db.DiaChis.Where(t => t.MaDiaChi == dh.MaDiaChi).FirstOrDefault().DiaChi1;
        }
        private void Delete()
        {
            if (!dh.TrangThaiDonHang.Equals("Chờ xác nhận"))
            {
                MessageBox.Show("Hủy đơn hàng không thành công\nĐơn hàng chỉ có thể hủy ở trạng thái \"Chờ xác nhận\"");
            }
            else
            {
                try
                {
                    dh.TrangThaiDonHang = "Đã hủy";
                    db.SubmitChanges();
                    MessageBox.Show("Hủy đơn hàng thành công");
                    setDatTa(dh);

                }
                catch
                {
                    MessageBox.Show("Hủy đơn hàng thất bại");
                }
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            frmChiTietDonHang frm = new frmChiTietDonHang();
            frm.setData(dh);
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
