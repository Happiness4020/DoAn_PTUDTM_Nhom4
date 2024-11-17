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

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    public partial class frm_SanPham : Form
    {
        DataDataContext db = new DataDataContext();
        string selectedImagePath;
        public frm_SanPham()
        {
            InitializeComponent();
            Load_LoaiSanPham();
            Load_NhaSanXuat();
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.AllowUserToAddRows = false;
            Load_DataGridView();
            LoadCombobox();
        }

        public void Load_DataGridView()
        {
            var sps = from sp in db.SanPhams
                      where sp.TrangThaiSP == 0
                      select sp;
            dgvSanPham.DataSource = sps;
        }
        public void loadSanPhamBiXoa_DataGridView()
        {
            var sps = from sp in db.SanPhams
                      where sp.TrangThaiSP == 1
                      select sp;
            dgvSanPham.DataSource = sps;
        }

        public void Load_LoaiSanPham()
        {
            var loaisps = from loaisp in db.LoaiSanPhams where loaisp.TrangThaiLoaiSP==0 select loaisp;
            cbxLoaiSanPham.DataSource = loaisps;
            cbxLoaiSanPham.DisplayMember = "TenLoai";
            cbxLoaiSanPham.ValueMember = "MaLoai";
        }
        private void LoadCombobox()
        {
            var items = new Dictionary<string, int>
            {
                { "Tồn tại", 0 },
                { "Đã bị xóa", 1 }
            };
            cbxTrangThai.DataSource = new BindingSource(items, null);
            cbxTrangThai.DisplayMember = "Key";
            cbxTrangThai.ValueMember = "Value";
        }
        public void Load_NhaSanXuat()
        {
            var nsxs = from nsx in db.NhaSanXuats where nsx.TrangThaiNSX==0 select nsx;
            cbxNhaSanXuat.DataSource = nsxs;
            cbxNhaSanXuat.DisplayMember = "TenNhaSanXuat";
            cbxNhaSanXuat.ValueMember = "MaNhaSanXuat";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham tensp = db.SanPhams.Where(sp => sp.TenSanPham == txtTenSanPham.Text).FirstOrDefault();
                if (string.IsNullOrEmpty(txtTenSanPham.Text) || string.IsNullOrEmpty(txtAnh.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(tensp != null)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
                else
                {
                    SanPham sp = new SanPham();

                    sp.TenSanPham = txtTenSanPham.Text;
                    sp.MaLoai = (int)cbxLoaiSanPham.SelectedValue;
                    sp.MaNhaSanXuat = (int)cbxNhaSanXuat.SelectedValue;                   
                    sp.Anh = CapNhatHinhAnh(selectedImagePath,sp.TenSanPham);
                    txtAnh.Text = sp.Anh;
                    sp.TrangThaiSP = (int)cbxTrangThai.SelectedValue;

                    // Thêm đối tượng nhưng đối tượng chỉ được thêm tạm thời vào DataDataContext và chưa được cập nhật vào database
                    db.SanPhams.InsertOnSubmit(sp);

                    Load_DataGridView();
                    MessageBox.Show("Thêm thành công! Nhấn lưu để lưu sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Đồng bộ dữ liệu của project vào database
                db.SubmitChanges();
                Load_DataGridView();
                
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int masanpham = -1;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SanPham sp = db.SanPhams.Where(t => t.MaSanPham == masanpham).FirstOrDefault();
                    List<ChiTietSanPham> lstctsp = db.ChiTietSanPhams.Where(t => t.MaSanPham == sp.MaSanPham).ToList();
                    foreach (ChiTietSanPham ct in lstctsp)
                    {
                        var donHang = (from ctdh in db.ChiTietDonHangs
                                       join dh in db.DonHangs on ctdh.MaDonHang equals dh.MaDonHang
                                       where ctdh.MaCTSanPham == ct.ID && dh.TrangThaiDonHang == "Chờ xác nhận"
                                       select dh).FirstOrDefault();
                        if (donHang != null)
                        {
                            MessageBox.Show("Xóa không thành công do sản phẩm đang được đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    foreach (ChiTietSanPham ct in lstctsp)
                    {
                        var gioHangs = db.GioHangs.Where(t => t.MaCTSanPham == ct.ID).ToList();
                        foreach (var gioHang in gioHangs)
                        {
                            db.GioHangs.DeleteOnSubmit(gioHang);
                        }
                    }
                    db.SubmitChanges();
                    if (sp != null)
                    {
                        sp.TrangThaiSP = 1;
                        db.SubmitChanges();
                        Load_DataGridView();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }    
                    else
                    {
                        MessageBox.Show("Sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }    
                }    
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvSanPham.CurrentRow;
                masanpham = (int)currentRow.Cells[0].Value;
                txtTenSanPham.Text = currentRow.Cells[1].Value.ToString();
                cbxLoaiSanPham.SelectedValue = currentRow.Cells[2].Value;
                cbxNhaSanXuat.SelectedValue = currentRow.Cells[3].Value;
                txtAnh.Text = currentRow.Cells[4].Value.ToString();
                LayHinhAnh(currentRow.Cells[4].Value.ToString());
                cbxTrangThai.SelectedIndex= (int)currentRow.Cells[5].Value;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    txtAnh.Text = Path.GetFileName(filePath);
                    // Gán hình ảnh vào panel pnlHinhAnh
                    pnlHinhAnh.BackgroundImage = Image.FromFile(filePath);
                    pnlHinhAnh.BackgroundImageLayout = ImageLayout.Zoom;
                    // Có thể lưu đường dẫn tạm để sử dụng trong CapNhatHinhAnh
                    selectedImagePath = filePath;
                }
            }
        }

        private string CapNhatHinhAnh(string filePath, string tenSanPham)
        {
            string imageDirectory = Path.Combine(Application.StartupPath, "Images\\imgProduct");
            Directory.CreateDirectory(imageDirectory);

            string fileExtension = Path.GetExtension(filePath);
            string fileName = tenSanPham + fileExtension;

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
            string imageDirectory = Path.Combine(Application.StartupPath, "Images\\imgProduct");

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

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.InitialDirectory = "D:\\";
            //    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
            //    openFileDialog.FilterIndex = 1;
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string fileName = Path.GetFileName(openFileDialog.FileName);
            //        txtAnh.Text = fileName;
            //    }
            //}
            ChonHinhAnh();
        }

        private void Reset()
        {
            masanpham = -1;
            txtTenSanPham.Clear();
            cbxLoaiSanPham.SelectedIndex = 0;
            cbxNhaSanXuat.SelectedIndex = 0;
            txtAnh.Clear();
            pnlHinhAnh.BackgroundImage=null;
            cbxTrangThai.SelectedIndex = 0;
            txtTenSanPham.Focus();
            ckcSanPhamBiXoa.Checked = false;
            cbxTrangThai.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (masanpham == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã sản phẩm cần cập nhật!!!");
                }
                else
                {
                    SanPham sp = db.SanPhams.Where(t => t.MaSanPham == masanpham).FirstOrDefault();

                    if(sp != null)
                    {
                        sp.TenSanPham = txtTenSanPham.Text;
                        sp.MaLoai = (int)cbxLoaiSanPham.SelectedValue;
                        sp.MaNhaSanXuat = (int)cbxNhaSanXuat.SelectedValue;
                        if (selectedImagePath != null)
                        {
                            sp.Anh = CapNhatHinhAnh(selectedImagePath, sp.TenSanPham);
                        }
                        sp.TrangThaiSP = (int)cbxTrangThai.SelectedValue;                     
                        ckcSanPhamBiXoa.Checked = false;
                        cbxTrangThai.Enabled = false;
                        MessageBox.Show("Cập nhật thành công! Nhấn lưu để lưu sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tensanpham = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(tensanpham))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var kq = db.SanPhams.Where(dh => dh.TenSanPham.Contains(tensanpham)).ToList();

                if (kq.Count > 0)
                {
                    dgvSanPham.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần tìm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSanPham.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
            txtTimKiem.Clear();
        }

        private void chiTiếtSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(masanpham == -1)
            {
                MessageBox.Show("Hãy chọn sản phẩm cần xem!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
            else
            {
                frm_ChiTietSanPham frmCTSP = new frm_ChiTietSanPham(masanpham);
                frmCTSP.txtMaSanPham.Text = masanpham.ToString();
                frmCTSP.masp = masanpham;
                frmCTSP.lblTenSanPham.Text = txtTenSanPham.Text;
                frmCTSP.Show();
            }    
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LoaiSanPham frmLoaiSP = new frm_LoaiSanPham();
            frmLoaiSP.Show();
        }

        private void ckcSanPhamBiXoa_CheckedChanged(object sender, EventArgs e)
        {
            if(ckcSanPhamBiXoa.Checked)
            {
                loadSanPhamBiXoa_DataGridView();
                cbxTrangThai.SelectedIndex = 1;
                cbxTrangThai.Enabled = true;
            }
            else
            {
                Load_DataGridView();
                cbxTrangThai.SelectedIndex = 0;
                cbxTrangThai.Enabled = false;
            }
        }
    }
}
