using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu
{
    public partial class frm_ChiTietSanPham : Form
    {
        DataDataContext db = new DataDataContext();
        public string masp;
        public frm_ChiTietSanPham(string masanpham)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            cbxMauSac.SelectedIndex = 0;
            dgvChiTietSP.AutoGenerateColumns = false;
            dgvChiTietSP.AllowUserToAddRows = false;
            masp = masanpham;
            Load_DataGridView();
        }

        public void Load_DataGridView()
        {
            try
            {
                var kq = db.ChiTietSanPhams
                               .Where(ctsp => ctsp.MaSanPham == masp)
                               .ToList();

                // Kiểm tra xem có chi tiết sản phẩm nào tìm thấy không
                if (kq.Count > 0)
                {
                    dgvChiTietSP.DataSource = kq; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtGia.Text) || cbxMauSac.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Kiểm tra xem màu sắc đã tồn tại chưa
                    var mauDaTonTai = db.ChiTietSanPhams
                        .FirstOrDefault(t => t.MaSanPham == txtMaSanPham.Text && t.Mausac.ToLower() == cbxMauSac.SelectedItem.ToString().ToLower());

                    if (mauDaTonTai != null)
                    {
                        MessageBox.Show("Sản phẩm đã có màu " + cbxMauSac.SelectedItem.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ChiTietSanPham ctsp = new ChiTietSanPham();

                    ctsp.ID = TaoID();
                    ctsp.MaSanPham = txtMaSanPham.Text;
                    ctsp.Gia = float.Parse(txtGia.Text);
                    ctsp.Soluong = int.Parse(numSoLuong.Value.ToString());
                    ctsp.Mausac = cbxMauSac.SelectedItem.ToString();

                    // Thêm đối tượng nhưng đối tượng chỉ được thêm tạm thời vào DataDataContext và chưa được cập nhật vào database
                    db.ChiTietSanPhams.InsertOnSubmit(ctsp);

                    Load_DataGridView();
                    MessageBox.Show("Thêm thành công! Nhấn lưu để lưu chi tiết sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string TaoID()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyx";
            const string numbers = "0123456789";
            StringBuilder kq = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(letters.Length);
                kq.Append(letters[index]);
            }

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(numbers.Length);
                kq.Append(numbers[index]);
            }

            return kq.ToString();
        }

        private void dgvChiTietSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvChiTietSP.CurrentRow;
                txtMaSanPham.Text = currentRow.Cells[0].Value.ToString();
                txtGia.Text = currentRow.Cells[1].Value.ToString();
                numSoLuong.Value = decimal.Parse(currentRow.Cells[2].Value.ToString());
                cbxMauSac.SelectedItem = currentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 

                if (result == DialogResult.Yes)
                {
                    string masanpham = txtMaSanPham.Text;
                    ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(t => t.MaSanPham == masanpham).FirstOrDefault();

                    if (ctsp != null)
                    {
                        db.ChiTietSanPhams.DeleteOnSubmit(ctsp);

                        db.SubmitChanges();
                        Load_DataGridView();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Chi tiết sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            txtGia.Clear();
            numSoLuong.Value = 0;
            cbxMauSac.SelectedIndex = 0;
            txtGia.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSanPham.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã chi tiết sản phẩm cần cập nhật!!!");
                }
                else
                {
                    string masanpham = txtMaSanPham.Text;
                    ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(t => t.MaSanPham == masanpham).FirstOrDefault();

                    if (ctsp != null)
                    {
                        ctsp.Gia = float.Parse(txtGia.Text);
                        ctsp.Soluong = int.Parse(numSoLuong.Value.ToString());
                        ctsp.Mausac = cbxMauSac.SelectedItem.ToString();

                        Load_DataGridView();
                        MessageBox.Show("Cập nhật thành công! Nhấn lưu để lưu chi tiết sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Chi tiết sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
