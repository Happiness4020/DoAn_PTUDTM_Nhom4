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
            LayHinhAnh(sp.Anh);
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
                pnlImgHinhAnh.BackgroundImage = Image.FromFile(imagePath);
                pnlImgHinhAnh.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                MessageBox.Show("Hình ảnh không tồn tại.");
            }
        }
    }
}
