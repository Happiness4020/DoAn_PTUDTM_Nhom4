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
        public int masp;
        public frm_ChiTietSanPham(int masanpham)
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

                if (kq.Count > 0)
                {
                    dgvChiTietSP.DataSource = kq;
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
                    // Kiểm tra xem sản phẩm đã có màu cần thêm chưa?
                    var mauDaTonTai = db.ChiTietSanPhams
                        .FirstOrDefault(t => t.MauSac.ToLower() == cbxMauSac.SelectedItem.ToString().ToLower() && t.MauSac == txtMaSanPham.Text);

                    if (mauDaTonTai != null)
                    {
                        MessageBox.Show("Sản phẩm đã có màu " + cbxMauSac.SelectedItem.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ChiTietSanPham ctsp = new ChiTietSanPham();

                    ctsp.MaSanPham = int.Parse(txtMaSanPham.Text);
                    ctsp.Gia = float.Parse(txtGia.Text);
                    ctsp.Soluong = int.Parse(numSoLuong.Value.ToString());
                    ctsp.MoTa = rtxtMoTa.Text;
                    ctsp.MauSac = cbxMauSac.SelectedItem.ToString();

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
                db.SubmitChanges();

                Load_DataGridView();
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTietSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvChiTietSP.CurrentRow;
                maid = (int)currentRow.Cells[0].Value;
                txtMaSanPham.Text = currentRow.Cells[1].Value.ToString();
                txtGia.Text = currentRow.Cells[2].Value.ToString();
                numSoLuong.Value = decimal.Parse(currentRow.Cells[3].Value.ToString());
                rtxtMoTa.Text = currentRow.Cells[4].Value.ToString();
                cbxMauSac.SelectedItem = currentRow.Cells[5].Value.ToString();
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
                    ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(t => t.ID == maid).FirstOrDefault();

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
            rtxtMoTa.Clear();
            cbxMauSac.SelectedIndex = 0;
            txtGia.Focus();
            maid = -1;
        }

        int maid = -1;
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (maid == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã chi tiết sản phẩm cần cập nhật!!!");
                }
                else
                {
                    int masanpham = int.Parse(txtMaSanPham.Text);
                    ChiTietSanPham ctsp = db.ChiTietSanPhams.Where(t => t.ID == maid).FirstOrDefault();

                    if (ctsp != null)
                    {
                        ctsp.Gia = float.Parse(txtGia.Text);
                        ctsp.Soluong = int.Parse(numSoLuong.Value.ToString());
                        ctsp.MoTa = rtxtMoTa.Text;
                        ctsp.MauSac = cbxMauSac.SelectedItem.ToString();

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

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
