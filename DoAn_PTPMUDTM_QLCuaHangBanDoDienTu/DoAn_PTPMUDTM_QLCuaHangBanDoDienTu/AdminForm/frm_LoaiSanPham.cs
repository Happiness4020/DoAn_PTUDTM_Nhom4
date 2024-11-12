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
    public partial class frm_LoaiSanPham : Form
    {
        DataDataContext db = new DataDataContext();
        public frm_LoaiSanPham()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dgvLoaiSanPham.AutoGenerateColumns = false;
            dgvLoaiSanPham.AllowUserToAddRows = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            var loaisps = from loaisp in db.LoaiSanPhams select loaisp;
            dgvLoaiSanPham.DataSource = loaisps;
        }

        private void frm_LoaiSanPham_Load(object sender, EventArgs e)
        {

        }

        private string TaoMaLoai()
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenLoai.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên loại sản phẩm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LoaiSanPham loaisp = new LoaiSanPham();
                    loaisp.TenLoai = txtTenLoai.Text;
                    loaisp.TrangThaiLoaiSP = cbxTrangThai.SelectedIndex;

                    // Thêm đối tượng nhưng đối tượng chỉ được thêm tạm thời vào DataDataContext và chưa được cập nhật vào database
                    db.LoaiSanPhams.InsertOnSubmit(loaisp);

                    Load_DataGridView();
                    MessageBox.Show("Thêm thành công! Nhấn lưu để lưu loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        int maloai = -1;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    LoaiSanPham loaisp = db.LoaiSanPhams.Where(t => t.MaLoai == maloai).FirstOrDefault();

                    if (loaisp != null)
                    {
                        db.LoaiSanPhams.DeleteOnSubmit(loaisp);

                        db.SubmitChanges();
                        Load_DataGridView();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Loại sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            maloai = -1;
            txtTenLoai.Clear();
            cbxTrangThai.SelectedIndex = 0;
            txtTenLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (maloai == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã loại sản phẩm cần cập nhật!!!");
                }
                else
                {
                    LoaiSanPham loaisp = db.LoaiSanPhams.Where(t => t.MaLoai == maloai).FirstOrDefault();

                    if (loaisp != null)
                    {
                        loaisp.TenLoai = txtTenLoai.Text;
                        loaisp.TrangThaiLoaiSP = cbxTrangThai.SelectedIndex;

                        Load_DataGridView();
                        MessageBox.Show("Cập nhật thành công! Nhấn lưu để lưu loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Loại sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật loại sản phẩm: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dgvLoaiSanPham.CurrentRow;
            maloai = (int)currentRow.Cells[0].Value;
            txtTenLoai.Text = currentRow.Cells[1].Value.ToString();
            cbxTrangThai.SelectedIndex =(int)currentRow.Cells[2].Value;
        }
    }
}
