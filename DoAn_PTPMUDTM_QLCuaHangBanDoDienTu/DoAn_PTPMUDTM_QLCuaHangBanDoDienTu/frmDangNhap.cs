using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm;
using DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu
{
    public partial class frmDangNhap : Form
    {
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        public frmDangNhap()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đóng ứng dụng?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
            else { }
           
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                var tendn = db.TaiKhoans.Where(t => t.TenDN == txtTenDangNhap.Text).FirstOrDefault();
                var matkhau = db.TaiKhoans.Where(t => t.MatKhau == txtMatKhau.Text).FirstOrDefault();

                if (string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    MessageBox.Show("Chưa nhập tên đăng nhập hoặc mật khẩu!!!");
                    return;
                }
                else if (tendn == null || matkhau == null)
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại hoặc mật khẩu không chính xác!!!");
                    return;
                }

                var isAdmin = db.TaiKhoans.Where(t => t.VaiTro == "Admin" && t.TenDN == txtTenDangNhap.Text).FirstOrDefault();
                var isUser = db.TaiKhoans.Where(t => t.VaiTro == "User" && t.TenDN == txtTenDangNhap.Text).FirstOrDefault();

                if (isAdmin != null)
                {
                    frm_AdminDashboard frm_db = new frm_AdminDashboard();
                    frm_db.Show();
                    this.Visible = false;
                }
                else if (isUser != null)
                {
                    frmUserMain frm = new frmUserMain();
                    frm.setData(txtTenDangNhap.Text);
                    frm.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi đăng nhập ứng dụng: " + ex);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy frmDK = new frmDangKy();
            frmDK.Show();
            this.Visible = false;
        }
    }
}
