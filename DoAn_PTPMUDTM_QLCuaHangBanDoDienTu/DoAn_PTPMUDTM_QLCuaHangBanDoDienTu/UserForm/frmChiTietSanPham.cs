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
    public partial class frmChiTietSanPham : Form
    {
        SanPham sp;
        List<ChiTietSanPham> lst = new List<ChiTietSanPham>();
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        ChiTietSanPham ct;
        public frmChiTietSanPham()
        {
            InitializeComponent();
            lblTenSanPham.TextAlign = ContentAlignment.TopLeft;// Căn lề văn bản cho Label
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void setData(SanPham sp)
        {
            this.sp = sp;
            lblTenSanPham.Text = sp.TenSanPham;
            loadCBBChiTiet();
            cboLuaChon.SelectedIndex = 1;
            loadChiTietSP();
        }
        private void loadCBBChiTiet()
        {
            lst = db.ChiTietSanPhams.Where(ct => ct.MaSanPham == sp.MaSanPham).ToList();
            cboLuaChon.DataSource = lst;
            cboLuaChon.DisplayMember = "MauSac";
            cboLuaChon.ValueMember = "ID";
        }
        private void loadChiTietSP()
        {
            int ID = -1;
            if (cboLuaChon.Items.Count > 0 && cboLuaChon.SelectedIndex == 0)
            {
                // Lấy mục đầu tiên trong ComboBox
                ID = lst.First().ID;
            }
            else
            {
                ID = (int)cboLuaChon.SelectedValue;
            }
            ct = db.ChiTietSanPhams.Where(c => c.ID == ID).FirstOrDefault();
            lblGia.Text = ct.Gia + " VNĐ";
            lblTonKho.Text = ct.Soluong.ToString();
            lblMoTa.Text = "Mô tả sản phẩm: " + ct.MoTa;
        }
        private void ThemGioHang()
        {
            try
            {
                GioHang gh = db.GioHangs.Where(g => g.MaCTSanPham == ct.ID).FirstOrDefault();
                if (gh==null)
                {
                    gh = new GioHang();
                    gh.TenDN = "nguyentandat";
                    gh.MaCTSanPham = ct.ID;
                    gh.SoLuong = (int)nbrSoLuong.Value;
                    db.GioHangs.InsertOnSubmit(gh);
                    db.SubmitChanges();
                }else
                {
                    gh.SoLuong += (int)nbrSoLuong.Value;
                    db.SubmitChanges();
                }    
                MessageBox.Show("Thêm giỏ hàng thành công");
                this.Close();
            }catch
            {
                MessageBox.Show("Lỗi khi thêm giỏ hàng");
            }
        }
        private void cboLuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChiTietSP();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            ThemGioHang();
        }
    }
}
