using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.AdminForm
{
    public partial class frm_DonHang : Form
    {
        DataDataContext db = new DataDataContext();
        public frm_DonHang()
        {
            InitializeComponent();
        }

        private void frm_DonHang_Load(object sender, EventArgs e)
        {
            dgvDonHang.AutoGenerateColumns = false;
            dgvDonHang.AllowUserToAddRows = false;
            Load_DataDH();
        }

        private void Load_DataDH()
        {
            var donhangs = from dh in db.DonHangs select dh;
            dgvDonHang.DataSource = donhangs;
        }


        string tendn = "";
        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvDonHang.CurrentRow;
                madh = (int)currentRow.Cells[0].Value;
                tendn = currentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (madh == -1)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần xác nhận!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DonHang dh = db.DonHangs.Where(t => t.MaDonHang == madh).FirstOrDefault();

                    if (dh != null)
                    {
                        if (dh.TrangThaiDonHang == "Đã xác nhận" || dh.TrangThaiDonHang == "Đã hủy")
                        {
                            MessageBox.Show("Đơn hàng đã xác nhận hoặc đã hủy, không thể thay đổi trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            dh.TrangThaiDonHang = "Đã xác nhận";

                            Load_DataDH();
                            MessageBox.Show("Cập nhật thành công! Nhấn lưu để hoàn tất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn hàng không tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                db.SubmitChanges();

                Load_DataDH();
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int madh = -1;
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (madh == -1)
            {
                MessageBox.Show("Hãy chọn đơn hàng cần xem!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frm_ChiTietDonHang frmCTDH = new frm_ChiTietDonHang(madh);
                frmCTDH.Show();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDN = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(tenDN))
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var kq = db.DonHangs.Where(dh => dh.TenDN.Contains(tenDN)).ToList();

                if (kq.Count > 0)
                {
                    dgvDonHang.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng nào với tên đăng nhập này!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDonHang.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_DataDH();
        }
    }
}
