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
    public partial class CardSanPhamDeXuat : UserControl
    {
        public CardSanPhamDeXuat()
        {
            InitializeComponent();
        }

        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        SanPham sp;
        public void setData(SanPham s)
        {
            this.sp = s;
            lblTenSanPham.AutoEllipsis = true;

            lblTenSanPham.Text = sp.TenSanPham;
            LayHinhAnh(this.sp.Anh);
        }
        private void LayHinhAnh(string tenHinhAnh)
        {
            // Thư mục chứa hình ảnh trong bin\Debug
            string imageDirectory = Path.Combine(Application.StartupPath, "Images\\imgProduct");

            // Kiểm tra lại xem đường dẫn thư mục có chính xác không
            imageDirectory = Path.GetFullPath(imageDirectory);  // Lấy đường dẫn đầy đủ để kiểm tra

            // Kiểm tra xem tên tệp có phần mở rộng hay không
            string imagePath = Path.Combine(imageDirectory, tenHinhAnh); // tenDN đã bao gồm phần mở rộng như .png hoặc .jpg

            // Kiểm tra xem ảnh có tồn tại không và gán vào panel
            if (File.Exists(imagePath))
            {
                pnlImgSanPham.BackgroundImage = Image.FromFile(imagePath);
                pnlImgSanPham.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                MessageBox.Show("Hình ảnh không tồn tại.");
            }
        }


        private void panel1_Click(object sender, EventArgs e)
        {
            ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(ct => ct.MaSanPham == sp.MaSanPham).FirstOrDefault();
            if (ctsp == null)
            {
                MessageBox.Show("Sản phẩm chưa được kinh doanh");
                return;
            }
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmChiTietSanPham)
                {
                    form.Close();  // Đóng form đã mở
                    break;  // Dừng vòng lặp sau khi tìm thấy và đóng form
                }
            }
            frmChiTietSanPham frm = new frmChiTietSanPham();
            frm.setData(sp);
            frm.Show();
        }
    }
}
