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
    public partial class frm_SanPham : Form
    {
        DataDataContext db = new DataDataContext();
        public frm_SanPham()
        {
            InitializeComponent();
            Load_LoaiSanPham();
            Load_NhaSanXuat();
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.AllowUserToAddRows = false;
            Load_DataGridView();
        }

        public void Load_DataGridView()
        {
            var sps = from sp in db.SanPhams select sp;
            dgvSanPham.DataSource = sps;
        }

        public void Load_LoaiSanPham()
        {
            var loaisps = from loaisp in db.LoaiSanPhams select loaisp;
            cbxLoaiSanPham.DataSource = loaisps;
            cbxLoaiSanPham.DisplayMember = "TenLoai";
            cbxLoaiSanPham.ValueMember = "MaLoai";
        }

        public void Load_NhaSanXuat()
        {
            var nsxs = from nsx in db.NhaSanXuats select nsx;
            cbxNhaSanXuat.DataSource = nsxs;
            cbxNhaSanXuat.DisplayMember = "TenNhaSanXuat";
            cbxNhaSanXuat.ValueMember = "MaNhaSanXuat";
        }

        public string TaoMaSanPham()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(letters.Length);
                result.Append(letters[index]);
            }

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(numbers.Length);
                result.Append(numbers[index]);
            }

            return result.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenSanPham.Text) || string.IsNullOrEmpty(txtAnh.Text) || string.IsNullOrEmpty(rtxtMoTa.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SanPham sp = new SanPham();

                    sp.MaSanPham = TaoMaSanPham();
                    sp.TenSanPham = txtTenSanPham.Text;
                    sp.MaLoai = cbxLoaiSanPham.SelectedValue.ToString();
                    sp.MaNhaSanXuat = cbxNhaSanXuat.SelectedValue.ToString();
                    sp.MoTa = rtxtMoTa.Text;
                    sp.Anh = txtAnh.Text;

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string masanpham = txtMaSanPham.Text;
                    SanPham sp = db.SanPhams.Where(t => t.MaSanPham == masanpham).FirstOrDefault();

                    if (sp != null)
                    {
                        db.SanPhams.DeleteOnSubmit(sp);

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
                txtMaSanPham.Text = currentRow.Cells[0].Value.ToString();
                txtTenSanPham.Text = currentRow.Cells[1].Value.ToString();
                cbxLoaiSanPham.SelectedValue = currentRow.Cells[2].Value.ToString();
                cbxNhaSanXuat.SelectedValue = currentRow.Cells[3].Value.ToString();
                rtxtMoTa.Text = currentRow.Cells[4].Value.ToString();
                txtAnh.Text = currentRow.Cells[5].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    txtAnh.Text = filePath;
                }
            }
        }

        private void Reset()
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            cbxLoaiSanPham.SelectedIndex = 0;
            cbxNhaSanXuat.SelectedIndex = 0;
            rtxtMoTa.Clear();
            txtAnh.Clear();
            txtTenSanPham.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSanPham.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã sản phẩm cần cập nhật!!!");
                }
                else
                {
                    string masanpham = txtMaSanPham.Text;
                    SanPham sp = db.SanPhams.Where(t => t.MaSanPham == masanpham).FirstOrDefault();

                    if(sp != null)
                    {
                        sp.TenSanPham = txtTenSanPham.Text;
                        sp.MaLoai = cbxLoaiSanPham.SelectedValue.ToString();
                        sp.MaNhaSanXuat = cbxNhaSanXuat.SelectedValue.ToString();
                        sp.MoTa = rtxtMoTa.Text;
                        sp.Anh = txtAnh.Text;

                        Load_DataGridView();
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
            string tensanpham = txtTenSanPham.Text.Trim();

            try
            {
                var kq = db.SanPhams
                               .Where(sp => sp.TenSanPham.Contains(tensanpham))
                               .ToList();

                if (kq.Count > 0)
                {
                    dgvSanPham.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSanPham.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
            txtTimKiem.Clear();
        }

        private void chiTiếtSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaSanPham.Text))
            {
                MessageBox.Show("Hãy chọn sản phẩm cần xem!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
            else
            {
                frm_ChiTietSanPham frmCTSP = new frm_ChiTietSanPham(txtMaSanPham.Text);
                frmCTSP.txtMaSanPham.Text = txtMaSanPham.Text;
                frmCTSP.masp = txtMaSanPham.Text;
                frmCTSP.lblTenSanPham.Text = txtTenSanPham.Text;
                frmCTSP.Show();
            }    
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LoaiSanPham frmLoaiSP = new frm_LoaiSanPham();
            frmLoaiSP.Show();
        }
    }
}
