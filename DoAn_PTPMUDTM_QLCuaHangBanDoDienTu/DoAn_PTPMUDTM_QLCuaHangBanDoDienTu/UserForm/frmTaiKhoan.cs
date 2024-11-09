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
    public partial class frmTaiKhoan : Form
    {
        TaiKhoan tk;
        string selectedImagePath;
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }


        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            ChonHinhAnh();
        }

        private void ChonHinhAnh()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Đường dẫn hình ảnh đã chọn
                    string filePath = openFileDialog.FileName;

                    // Gán hình ảnh vào panel pnlHinhAnh
                    pnlHinhAnh.BackgroundImage = Image.FromFile(filePath);
                    pnlHinhAnh.BackgroundImageLayout = ImageLayout.Zoom;

                    // Có thể lưu đường dẫn tạm để sử dụng trong CapNhatHinhAnh
                    selectedImagePath = filePath;
                }
            }
        }

        private string CapNhatHinhAnh(string filePath, string tenDN)
        {
            string imageDirectory = Path.Combine(Application.StartupPath, "Images\\imgUser");
            Directory.CreateDirectory(imageDirectory); 

            string fileExtension = Path.GetExtension(filePath);
            string fileName = tenDN + fileExtension;

            string newImagePath = Path.Combine(imageDirectory, fileName);

            if (File.Exists(newImagePath))
            {
                // Giải phóng tài nguyên của hình ảnh trong pnlHinhAnh
                if (pnlHinhAnh.BackgroundImage != null)
                {
                    // Đảm bảo giải phóng tài nguyên của hình ảnh
                    pnlHinhAnh.BackgroundImage.Dispose();
                    pnlHinhAnh.BackgroundImage = null;  // Gán lại BackgroundImage là null
                }

                // Yêu cầu Garbage Collector giải phóng bộ nhớ
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // Thêm một chút delay để đảm bảo không có tiến trình nào khác đang sử dụng file
                System.Threading.Thread.Sleep(100);

                // Xóa tệp hình ảnh
                File.Delete(newImagePath);
               
            }
            File.Copy(filePath, newImagePath);
            return fileName;
        }

        private void LayHinhAnh(string tenHinhAnh)
        {
            // Thư mục chứa hình ảnh trong bin\Debug
            string imageDirectory = Path.Combine(Application.StartupPath, "Images\\imgUser");

            // Kiểm tra lại xem đường dẫn thư mục có chính xác không
            imageDirectory = Path.GetFullPath(imageDirectory);  // Lấy đường dẫn đầy đủ để kiểm tra

            // Kiểm tra xem tên tệp có phần mở rộng hay không
            string imagePath = Path.Combine(imageDirectory, tenHinhAnh); // tenDN đã bao gồm phần mở rộng như .png hoặc .jpg

            // Kiểm tra xem ảnh có tồn tại không và gán vào panel
            if (File.Exists(imagePath))
            {
                pnlHinhAnh.BackgroundImage = Image.FromFile(imagePath);
                pnlHinhAnh.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                MessageBox.Show("Hình ảnh không tồn tại.");
            }
        }


        public void setData(string tenDn)
        {
            this.tk = db.TaiKhoans.Where(t => t.TenDN == tenDn).FirstOrDefault();
            txtHoTen.Text = tk.HoTen;
            txtSoDienThoai.Text = tk.SoDienThoai;
            txtEmail.Text = tk.Email;
            if(tk.GioiTinh.Equals("Nam"))
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
            dateNgaySinh.Value = tk.NgaySinh;
            LayHinhAnh(tk.AnhBiaUser);
           
        }
        private void UpdateTaiKhoan()
        {
            try
            {
                tk.HoTen = txtHoTen.Text;
                tk.Email = txtEmail.Text;
                tk.SoDienThoai = txtSoDienThoai.Text;
                if (rdoNam.Checked)
                    tk.GioiTinh = "Nam";
                else
                    tk.GioiTinh = "Nữ";
                tk.NgaySinh = dateNgaySinh.Value;
                
                if (selectedImagePath != null)
                {
                    tk.AnhBiaUser = CapNhatHinhAnh(selectedImagePath, tk.TenDN);
                }
                db.SubmitChanges();
                MessageBox.Show("Cập nhật thông tin thành công");
                setData(tk.TenDN);
            }
            catch
            {
                MessageBox.Show("Cập nhật thông tin thất bại");
            }
        }

        private void btnCapNhatTT_Click(object sender, EventArgs e)
        {
            UpdateTaiKhoan();
        }

        private void btnCapNhatMK_Click(object sender, EventArgs e)
        {
            frmCapNhatMatKhau frm = new frmCapNhatMatKhau();
            frm.setData(tk.TenDN);
            frm.Show();
        }
    }
}
