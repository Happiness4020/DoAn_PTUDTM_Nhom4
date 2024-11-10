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
    public partial class frmDatHang : Form
    {
        private frmGioHang frm;
        GioHang gh1sp = null;
        public void reloadForm(frmGioHang frm)
        {
            this.frm = frm;
        }
        TaiKhoan tk = new TaiKhoan();
        List<GioHang> lstgh = new List<GioHang>();
        float tongTien = 0;
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        public frmDatHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void loadComboBox()
        {
            List<DiaChi> lstdc = db.DiaChis.Where(t => t.TenDN == tk.TenDN).ToList();
            cboDiaChi.DataSource = lstdc;
            cboDiaChi.DisplayMember = "DiaChi1";
            cboDiaChi.ValueMember = "MaDiaChi";
        }
        public void setData(GioHang gh)
        {
            this.tk = db.TaiKhoans.Where(t => t.TenDN == gh.TenDN).FirstOrDefault();
            loadComboBox();
            txtHoTen.Text = tk.HoTen;
            txtSoDienThoai.Text = tk.SoDienThoai;
            this.gh1sp = gh;
            ChiTietSanPham ct = db.ChiTietSanPhams.Where(c => c.ID == gh1sp.MaCTSanPham).FirstOrDefault();
            lblTongTien.Text = gh1sp.SoLuong * ct.Gia + " VNĐ";
            tongTien = (float)(gh1sp.SoLuong * ct.Gia);
            txtDiaChiMoi.Enabled = false;
        }
        public void setData(string tenDN)
        {
            this.tk = db.TaiKhoans.Where(t => t.TenDN == tenDN).FirstOrDefault();
            loadComboBox();
            txtHoTen.Text = tk.HoTen;
            txtSoDienThoai.Text = tk.SoDienThoai;
            this.lstgh = db.GioHangs.Where(t => t.TenDN == tenDN).ToList();
            List<ViewGioHang> lst = db.ViewGioHangs.Where(g => g.TenDN == tk.TenDN).ToList();
            lblTongTien.Text = lst.Sum(g => g.Gia * g.SoLuong).ToString() + " VNĐ";
            tongTien = (float)lst.Sum(g => g.Gia * g.SoLuong);
            txtDiaChiMoi.Enabled = false;
        }
        private void InsertDonHang()
        {
            try
            {
                //Tạo mới đơn hàng
                DonHang dh = new DonHang();
                dh.TenDN = tk.TenDN;
                dh.HoTen = txtHoTen.Text;
                DateTime thoiGianDat = DateTime.Now;
                dh.NgayDat = thoiGianDat;
                dh.SoDienThoai = txtSoDienThoai.Text;
                dh.TrangThaiDonHang = "Chờ xác nhận";
                if (rdoDiaChiHT.Checked)
                    dh.MaDiaChi = (int)cboDiaChi.SelectedValue;
                else
                {
                    if (txtDiaChiMoi.Text.Length <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập địa chỉ mới");
                    }
                    DiaChi newdc = new DiaChi();
                    newdc.TenDN = tk.TenDN;
                    newdc.DiaChi1 = txtDiaChiMoi.Text;
                    db.DiaChis.InsertOnSubmit(newdc);
                    db.SubmitChanges();
                    newdc = db.DiaChis.Where(t => t.TenDN == tk.TenDN).OrderByDescending(t => t.MaDiaChi).FirstOrDefault();
                    dh.MaDiaChi = newdc.MaDiaChi;
                }
                if (rdoTienMat.Checked)
                    dh.HinhThucThanhToan = rdoTienMat.Text;
                else
                    dh.HinhThucThanhToan = rdoNganHang.Text;
                dh.Email = tk.Email;
                dh.TongGiaTri = tongTien;
                db.DonHangs.InsertOnSubmit(dh);
                db.SubmitChanges();
                dh = db.DonHangs.Where(t => t.TenDN == tk.TenDN && t.NgayDat == thoiGianDat).FirstOrDefault();
                if (gh1sp != null)
                {
                    ChiTietDonHang ctdh = new ChiTietDonHang();
                    ctdh.MaCTSanPham = gh1sp.MaCTSanPham;
                    ctdh.SoLuong = gh1sp.SoLuong;
                    ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(s => s.ID == gh1sp.MaCTSanPham).FirstOrDefault();
                    ctdh.ThanhTien = ctsp.Gia * gh1sp.SoLuong;
                    ctdh.MaDonHang = dh.MaDonHang;
                    db.ChiTietDonHangs.InsertOnSubmit(ctdh);
                    db.SubmitChanges();
                    MessageBox.Show("Tạo đơn hàng thành công");
                    this.Dispose();
                    return;
                }
                else
                {
                    //Gán thông tin giỏ hàng vào chi tiết đơn hàng của đơn hàng vừa tạo và xóa giỏ hàng
                    foreach (GioHang g in lstgh)
                    {
                        ChiTietDonHang ctdh = new ChiTietDonHang();
                        ctdh.MaCTSanPham = g.MaCTSanPham;
                        ctdh.SoLuong = g.SoLuong;
                        ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(s => s.ID == g.MaCTSanPham).FirstOrDefault();
                        ctdh.ThanhTien = ctsp.Gia * g.SoLuong;
                        ctdh.MaDonHang = dh.MaDonHang;
                        db.ChiTietDonHangs.InsertOnSubmit(ctdh);
                        db.GioHangs.DeleteOnSubmit(g);
                        db.SubmitChanges();
                    }
                }
                MessageBox.Show("Tạo đơn hàng thành công");
                frm.loadGioHang();
                this.Dispose();

            }
            catch
            {
                MessageBox.Show("Tạo đơn hàng thất bại");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertDonHang();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rdoDiaChiHT_CheckedChanged(object sender, EventArgs e)
        {
            cboDiaChi.Enabled = true;
            txtDiaChiMoi.Enabled = false;
        }

        private void rdoDiaChiMoi_CheckedChanged(object sender, EventArgs e)
        {
            txtDiaChiMoi.Enabled = true;
            cboDiaChi.Enabled = false;
        }

    }
}
