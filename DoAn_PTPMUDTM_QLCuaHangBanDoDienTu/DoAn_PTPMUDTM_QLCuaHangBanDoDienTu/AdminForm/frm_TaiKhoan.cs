using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    public partial class frm_TaiKhoan : Form
    {
        DataDataContext db = new DataDataContext();
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.AllowUserToAddRows = false;
            Load_DataTK();
            txtSDT.MaxLength = 10;
            cbxVaiTro.SelectedIndex = 0;
            cbxGioiTinh.SelectedIndex = 0;
            cbxTrangThai.SelectedIndex = 0;
        }

        private void Load_DataTK()
        {
            var taikhoans = from tk in db.TaiKhoans select tk;
            dgvTaiKhoan.DataSource = taikhoans;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    txtAnh.Text = fileName;
                }
            }
        }

        private bool isEmail(string email)
        {
            string dinhdang = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, dinhdang);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (!isEmail(email))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Any(tk => tk.TenDN == txtTenDN.Text || tk.Email == txtEmail.Text);
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtAnh.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (taikhoan)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    TaiKhoan tk = new TaiKhoan();

                    tk.VaiTro = cbxVaiTro.SelectedItem.ToString();
                    tk.Email = txtEmail.Text;
                    tk.HoTen = txtHoTen.Text;
                    tk.NgaySinh = dtpNgaySinh.Value;
                    tk.GioiTinh = cbxGioiTinh.SelectedItem.ToString();
                    tk.SoDienThoai = txtSDT.Text;
                    tk.TenDN = txtTenDN.Text;
                    tk.MatKhau = txtMatKhau.Text;
                    tk.AnhBiaUser = txtAnh.Text;
                    tk.TrangThaiTK = cbxTrangThai.SelectedIndex;

                    // Thêm đối tượng nhưng đối tượng chỉ được thêm tạm thời vào DataDataContext và chưa được cập nhật vào database
                    db.TaiKhoans.InsertOnSubmit(tk);

                    Load_DataTK();
                    MessageBox.Show("Thêm thành công! Nhấn lưu để lưu tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            cbxVaiTro.SelectedIndex = 0;
            txtEmail.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cbxGioiTinh.SelectedIndex = 0;
            txtSDT.Clear();
            txtTenDN.Clear();
            txtMatKhau.Clear();
            txtAnh.Clear();
            cbxTrangThai.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Đồng bộ dữ liệu của project vào database
                db.SubmitChanges();

                Load_DataTK();
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    TaiKhoan tk = db.TaiKhoans.Where(t => t.TenDN == txtTenDN.Text).FirstOrDefault();

                    if (tk != null)
                    {
                        db.TaiKhoans.DeleteOnSubmit(tk);

                        db.SubmitChanges();
                        Load_DataTK();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenDN.Text))
                {
                    MessageBox.Show("Vui lòng chọn tên đăng nhập để cập nhật!!!");
                }
                else
                {
                    TaiKhoan tk = db.TaiKhoans.Where(t => t.TenDN == txtTenDN.Text).FirstOrDefault();

                    if (tk != null)
                    {
                        tk.VaiTro = cbxVaiTro.SelectedItem.ToString();
                        tk.Email = txtEmail.Text;
                        tk.HoTen = txtHoTen.Text;
                        tk.NgaySinh = dtpNgaySinh.Value;
                        tk.GioiTinh = cbxGioiTinh.SelectedItem.ToString();
                        tk.SoDienThoai = txtSDT.Text;
                        tk.MatKhau = txtMatKhau.Text;
                        tk.AnhBiaUser = txtAnh.Text;
                        tk.TrangThaiTK = cbxTrangThai.SelectedIndex;

                        Load_DataTK();
                        MessageBox.Show("Cập nhật thành công! Nhấn lưu để lưu tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvTaiKhoan.CurrentRow;
                cbxVaiTro.SelectedItem = currentRow.Cells[0].Value.ToString();
                txtEmail.Text = currentRow.Cells[1].Value.ToString();
                txtHoTen.Text = currentRow.Cells[2].Value.ToString();
                dtpNgaySinh.Value = (DateTime)currentRow.Cells[3].Value;
                cbxGioiTinh.SelectedItem = currentRow.Cells[4].Value.ToString();
                txtSDT.Text = currentRow.Cells[5].Value.ToString();
                txtTenDN.Text = currentRow.Cells[6].Value.ToString();
                txtMatKhau.Text = currentRow.Cells[7].Value.ToString();
                txtAnh.Text = currentRow.Cells[8].Value.ToString();
                cbxTrangThai.SelectedIndex = (int)currentRow.Cells[9].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tendn = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(tendn))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var kq = db.TaiKhoans.Where(dh => dh.TenDN.Contains(tendn)).ToList();

                if (kq.Count > 0)
                {
                    dgvTaiKhoan.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần tìm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTaiKhoan.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_DataTK();
        }
    }
}
