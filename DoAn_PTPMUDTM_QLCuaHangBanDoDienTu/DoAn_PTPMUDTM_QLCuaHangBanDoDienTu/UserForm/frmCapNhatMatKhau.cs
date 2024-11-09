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
    public partial class frmCapNhatMatKhau : Form
    {
        TaiKhoan tk;
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();

        public frmCapNhatMatKhau()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        public void setData(string tenDn)
        {
            this.tk = db.TaiKhoans.Where(t => t.TenDN == tenDn).FirstOrDefault();
        }
        public void UpdateMatKhau()
        {
            string str;
            str = kiemTraNhap();
            if(str.Length>0)
            {
                MessageBox.Show(str, "Thông báo");
                return;
            }    
            if(txtMatKhauCu.Text.Equals(tk.MatKhau))
            {
                if(txtMatKhauCu.Text.Equals(txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Mật khẩu mới khác mật khẩu hiện tại");
                    return;
                }
                if (txtMatKhauCu.Text.Equals(txtMatKhauNhapLai.Text))
                {
                    MessageBox.Show("Mật khẩu mới không trùng khớp");
                    return;
                }
                try
                {
                    tk.MatKhau = txtMatKhauMoi.Text;
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật mật khẩu thành công");
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại");
                }
            }    
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCapNhatMK_Click(object sender, EventArgs e)
        {
            UpdateMatKhau();
        }
        private string kiemTraNhap()
        {
            string str="";
            if (txtMatKhauMoi.Text.Length <= 0)
                str += "Vui lòng nhập mật khẩu mới\n";

            if (txtMatKhauCu.Text.Length <= 0)
                str += "Vui lòng nhập mật khẩu hiện tại\n";

            if (txtMatKhauNhapLai.Text.Length <= 0)
                str += "Vui lòng nhập lại mật khẩu mới\n";
            return str;
        }
    }
}
