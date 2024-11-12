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
    public partial class frmGioHang : Form
    {
        TaiKhoan tk;
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        public frmGioHang()
        {
            InitializeComponent();
        }
        public void setData(string TenDN)
        {
            tk = db.TaiKhoans.Where(t => t.TenDN == TenDN).FirstOrDefault();
            loadGioHang();
        }
        public void loadGioHang()
        {
            List<ViewGioHang> lst = db.ViewGioHangs.Where(g => g.TenDN == tk.TenDN).ToList();
            pnlGioHang.Controls.Clear();

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill; // Để panel tự động điều chỉnh kích thước
            flowPanel.WrapContents = true; // Cho phép dòng tiếp theo khi hết không gian
            flowPanel.FlowDirection = FlowDirection.LeftToRight; // Sắp xếp từ trái sang phải

            foreach (ViewGioHang vgh in lst)
            {
                CardGioHang card = new CardGioHang();

                card.setData(vgh);
                pnlGioHang.Controls.Add(card);
            }
            lblTongTien.Text = lst.Sum(g => g.Gia * g.SoLuong).ToString() + " VNĐ";
        }

        private void pnlGioHang_Click(object sender, EventArgs e)
        {
        }

        private void frmGioHang_Load(object sender, EventArgs e)
        {
            foreach (CardGioHang control in pnlGioHang.Controls)
            {
                control.ButtonSuaClicked += Control_ButtonClicked;
                control.ButtonXoaClicked += Control_ButtonClicked;
            }
           
        }
        private void Control_ButtonClicked(object sender, EventArgs e)
        {
            List<ViewGioHang> lst = db.ViewGioHangs.Where(g => g.TenDN == tk.TenDN).ToList();
            lblTongTien.Text = lst.Sum(g => g.Gia * g.SoLuong).ToString() + " VNĐ";
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = db.GioHangs.Where(t => t.TenDN == tk.TenDN).Count();
            if (count > 0)
            {
                frmDatHang frm = new frmDatHang();
                frm.setData(tk.TenDN);
                frm.Show();
                frm.reloadForm(this);
            }
            else
            {
                MessageBox.Show("Giỏ hàng của bạn đang trống vui lòng thêm sản phẩm để đặt hàng");
            }
        }
    }
    
}
