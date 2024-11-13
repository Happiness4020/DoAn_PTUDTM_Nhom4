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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var tensp = db.SanPhams.Where(sp => sp.TenSanPham == txtTenSanPham.Text);
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
                    sp.Anh = txtAnh.Text;
                    sp.TrangThaiSP = cbxTrangThai.SelectedIndex;

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
                masanpham = (int)currentRow.Cells[0].Value;
                txtTenSanPham.Text = currentRow.Cells[1].Value.ToString();
                cbxLoaiSanPham.SelectedValue = currentRow.Cells[2].Value;
                cbxNhaSanXuat.SelectedValue = currentRow.Cells[3].Value;
                txtAnh.Text = currentRow.Cells[4].Value.ToString();
                cbxTrangThai.SelectedValue = currentRow.Cells[5].Value.ToString();
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

        private void Reset()
        {
            masanpham = -1;
            txtTenSanPham.Clear();
            cbxLoaiSanPham.SelectedIndex = 0;
            cbxNhaSanXuat.SelectedIndex = 0;
            txtAnh.Clear();
            cbxTrangThai.SelectedIndex = 0;
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
                        sp.Anh = txtAnh.Text;
                        sp.TrangThaiSP = cbxTrangThai.SelectedIndex;

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
    }
}
