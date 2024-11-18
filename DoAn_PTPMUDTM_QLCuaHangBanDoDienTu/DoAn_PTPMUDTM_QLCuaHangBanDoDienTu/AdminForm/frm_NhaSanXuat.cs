using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    public partial class frm_NhaSanXuat : Form
    {
        DataDataContext db = new DataDataContext();
        public frm_NhaSanXuat()
        {
            InitializeComponent();
            LoadCombobox();
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
        private void frm_NhaSanXuat_Load(object sender, EventArgs e)
        {
            dgvNSX.AutoGenerateColumns = false;
            dgvNSX.AllowUserToAddRows = false;
            Load_DataNSX();
            cbxTrangThai.SelectedIndex = 0;
            txtSDT.MaxLength = 10;
        }

        private void Load_DataNSX()
        {
            var nsxs = from nsx in db.NhaSanXuats where nsx.TrangThaiNSX == 0  select nsx;
            dgvNSX.DataSource = nsxs;   
        }
        private void Load_DataNSX_BiXoa()
        {
            var nsxs = from nsx in db.NhaSanXuats where nsx.TrangThaiNSX == 1 select nsx;
            dgvNSX.DataSource = nsxs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var tennsx = db.NhaSanXuats.Where(t => t.TenNhaSanXuat == txtTenNSX.Text).FirstOrDefault();
                if (string.IsNullOrEmpty(txtTenNSX.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà sản xuất!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(tennsx != null)
                {
                    MessageBox.Show("Nhà sản xuất đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
                else
                {
                    NhaSanXuat nsx = new NhaSanXuat();

                    nsx.TenNhaSanXuat = txtTenNSX.Text;
                    nsx.SoDienThoai = txtSDT.Text;
                    nsx.DiaChi = txtDiaChi.Text;
                    nsx.Email = txtEmail.Text;
                    nsx.TrangThaiNSX = cbxTrangThai.SelectedIndex;

                    // Thêm đối tượng nhưng đối tượng chỉ được thêm tạm thời vào DataDataContext và chưa được cập nhật vào database
                    db.NhaSanXuats.InsertOnSubmit(nsx);

                    Load_DataNSX(); ;
                    MessageBox.Show("Thêm thành công! Nhấn lưu để lưu nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà sản xuất này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    NhaSanXuat nsx = db.NhaSanXuats.Where(t => t.MaNhaSanXuat == mansx).FirstOrDefault();
                    SanPham sp = db.SanPhams.Where(a => a.MaNhaSanXuat == nsx.MaNhaSanXuat).FirstOrDefault();
                    if(sp!=null)
                    {
                        MessageBox.Show("Xóa nhà sản xuất không thành công do cửa hàng đang kinh doanh sản phẩm thuộc nhà sản xuất "+nsx.TenNhaSanXuat+" !!!\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (nsx != null)
                    {
                        nsx.TrangThaiNSX = 1;
                        db.SubmitChanges();
                        Load_DataNSX();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhà sản xuất: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int mansx = -1;
        private void dgvNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvNSX.CurrentRow;
                mansx = (int)currentRow.Cells[0].Value;
                txtTenNSX.Text = currentRow.Cells[1].Value.ToString();
                txtSDT.Text = currentRow.Cells[2].Value.ToString();
                txtDiaChi.Text = currentRow.Cells[3].Value.ToString();
                txtEmail.Text = currentRow.Cells[4].Value.ToString();
                cbxTrangThai.SelectedValue = currentRow.Cells[5].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            mansx = -1;
            txtTenNSX.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cbxTrangThai.SelectedIndex = 0;
            txtTenNSX.Focus();
            cbxTrangThai.Enabled = false;
            ckcSanPhamBiXoa.Checked = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (mansx == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã nhà sản xuất cần cập nhật!!!");
                }
                else
                {
                    NhaSanXuat nsx = db.NhaSanXuats.Where(t => t.MaNhaSanXuat == mansx).FirstOrDefault();

                    if (nsx != null)
                    {
                        nsx.TenNhaSanXuat = txtTenNSX.Text;
                        nsx.SoDienThoai = txtSDT.Text;
                        nsx.DiaChi = txtDiaChi.Text;
                        nsx.Email = txtEmail.Text;
                        nsx.TrangThaiNSX = cbxTrangThai.SelectedIndex;
                        ckcSanPhamBiXoa.Checked = false;
                        cbxTrangThai.Enabled = false;
                        Reset();
                        MessageBox.Show("Cập nhật thành công! Nhấn lưu để lưu nhà sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Nhà sản xuất không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhà sản xuất: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                db.SubmitChanges();
                cbxTrangThai.Enabled = false;
                Load_DataNSX();
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private bool isEmail(string email)
        {
            string dinhdang = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, dinhdang);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if(!isEmail(email))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tennsx = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(tennsx))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var kq = db.NhaSanXuats.Where(dh => dh.TenNhaSanXuat.Contains(tennsx)).ToList();

                if (kq.Count > 0)
                {
                    dgvNSX.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà sản xuất cần tìm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNSX.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhà sản xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_DataNSX();
        }

        private void ckcSanPhamBiXoa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcSanPhamBiXoa.Checked)
            {
                Load_DataNSX_BiXoa();
                cbxTrangThai.SelectedIndex = 1;
                cbxTrangThai.Enabled = true;
            }
            else
            {
                Load_DataNSX();
                cbxTrangThai.SelectedIndex = 0;
                cbxTrangThai.Enabled = false;
            }
        }
    }
}
