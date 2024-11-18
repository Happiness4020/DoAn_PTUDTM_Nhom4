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
    public partial class frm_PhieuNhap : Form
    {
        DataDataContext db = new DataDataContext();
        public bool test = false;
        public frm_PhieuNhap()
        {
            InitializeComponent();
            load_Combobox();
            cbx_SanPham.SelectedIndexChanged += cbx_SanPham_SelectedIndexChanged;
        }
        void load_Combobox()
        {
            var tblSP = from sp in db.SanPhams
                        select sp;
            cbx_SanPham.DataSource = tblSP;
            cbx_SanPham.DisplayMember = "TenSanPham";
            cbx_SanPham.ValueMember = "MaSanPham";
        }

        void load_DSSP(string maSP)
        {
            // Lấy chi tiết sản phẩm từ bảng ChiTietSanPham
            var tblDSSP = (from sp in db.SanPhams
                           join ctp in db.ChiTietSanPhams on sp.MaSanPham equals ctp.MaSanPham
                           where sp.MaSanPham.ToString() == maSP
                           select new
                           {
                               ctp.ID,
                               sp.TenSanPham,
                               ctp.Gia,
                               ctp.Soluong,
                               ctp.MauSac,
                               ctp.MoTa
                           }).ToList();

            dgrv_DanhSachSP.DataSource = tblDSSP;
        }

        private void cbx_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_SanPham.SelectedValue != null)
            {
                string maSP = cbx_SanPham.SelectedValue.ToString();
                load_DSSP(maSP);
            }
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            if (cbx_SanPham.SelectedValue != null)
            {
                string maNCC = cbx_SanPham.SelectedValue.ToString();
                DateTime ngayBatDau = DateTime_Tu.Value.Date; // Lấy ngày bắt đầu
                DateTime ngayKetThuc = DateTime_Den.Value.Date; // Lấy ngày kết thúc
                LoadPhieuNhapTheoKhoangThoiGian(maNCC, ngayBatDau, ngayKetThuc);

            }
            else
            { MessageBox.Show("Vui lòng chọn nhà cung cấp."); }
        }

        private void LoadPhieuNhapTheoKhoangThoiGian(string mapn, DateTime ngayBatDau, DateTime ngayKetThuc)
        {

            var phieuNhaps = (from pn in db.PhieuNhaps
                              join ctpn in db.ChiTietPhieuNhaps on pn.MaPhieuNhap equals ctpn.MaPhieuNhap
                              join cts in db.ChiTietSanPhams on ctpn.MaCTSanPham equals cts.ID
                              where pn.MaPhieuNhap == mapn
                                    && pn.NgayNhap >= ngayBatDau
                                    && pn.NgayNhap <= ngayKetThuc
                              select new
                              {
                                  pn.MaPhieuNhap,
                                  pn.NgayNhap,
                                  pn.TongGiaTri,
                                  ctpn.SoLuong,
                                  ctpn.ThanhTien
                              }).ToList();

            // Hiển thị kết quả vào DataGridView
            dgrv_MaPN.DataSource = phieuNhaps;

            if (phieuNhaps.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập nào trong khoảng thời gian đã chọn.");
            }

        }



        private void btn_TaoMoi_Click(object sender, EventArgs e)
        {
            string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");
            bool maPhieuNhapTonTai = true;
            int soThuTu = 1;

            while (maPhieuNhapTonTai)
            {
                string maPhieuNhapMoi = "PN" + ngayHienTai + soThuTu.ToString("D3");
                var phieuNhap = db.PhieuNhaps.FirstOrDefault(pn => pn.MaPhieuNhap == maPhieuNhapMoi);

                if (phieuNhap == null)
                {
                    maPhieuNhapTonTai = false;
                    txt_MaPN.Text = maPhieuNhapMoi;
                    DateTime_NgayNhap.Value = DateTime.Now;
                    txt_ThanhTien.Text = "0";
                    btn_LuuPN.Enabled = true;
                    btn_HuyPN.Enabled = true;
                    dgrv_MaPN.Rows.Add(maPhieuNhapMoi, DateTime_NgayNhap.Value.ToString("dd/MM/yyyy"), "0");
                    test = true;
                }
                else
                {
                    soThuTu++;
                    MessageBox.Show("Mã phiếu nhập đã tồn tại. Tạo mã mới với số thứ tự tăng.");
                }
            }
        }

        private void btn_LuuPN_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu txt_MaPN không có giá trị
                if (string.IsNullOrEmpty(txt_MaPN.Text))
                {
                    MessageBox.Show("Mã phiếu nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra nếu cbxThanhToan không có giá trị được chọn
                if (cbxThanhToan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn hình thức thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra nếu txt_ThanhTien không có giá trị hợp lệ
                if (string.IsNullOrEmpty(txt_ThanhTien.Text) || !double.TryParse(txt_ThanhTien.Text, out double tongGiaTri))
                {
                    MessageBox.Show("Tổng giá trị không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var phieuNhap = new PhieuNhap
                {
                    MaPhieuNhap = txt_MaPN.Text,
                    HinhThucThanhToan = cbxThanhToan.SelectedItem.ToString(),
                    NgayNhap = DateTime_NgayNhap.Value,
                    TongGiaTri = double.Parse(txt_ThanhTien.Text),
                    GhiChu = null,
                };

                db.PhieuNhaps.InsertOnSubmit(phieuNhap);
                db.SubmitChanges();
                MessageBox.Show("Lưu phiếu nhập thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu phiếu nhập: " + ex.Message);
            }
        }

        private void btn_HuyPN_Click(object sender, EventArgs e)
        {
            // Xác nhận hành động hủy của người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu nhập này không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lấy mã phiếu nhập hiện tại từ TextBox
                string maPNHienTai = txt_MaPN.Text;

                // Kiểm tra nếu mã phiếu nhập hiện tại tồn tại trong dgrv_MaPN
                bool found = false;
                foreach (DataGridViewRow row in dgrv_MaPN.Rows)
                {
                    if (row.Cells["MAPHIEUNHAP_PN"].Value != null && row.Cells["MAPHIEUNHAP_PN"].Value.ToString() == maPNHienTai)
                    {
                        // Xóa phiếu nhập khỏi DataGridView
                        dgrv_MaPN.Rows.Remove(row);
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    // Xóa thông tin trong DataGridView của chi tiết phiếu nhập
                    dgrv_ChiTietPN.Rows.Clear();


                    txt_MaPN.Text = string.Empty;
                    DateTime_NgayNhap.Value = DateTime.Now;
                    txt_ThanhTien.Text = "0";
                    MessageBox.Show("Phiếu nhập đã được hủy thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Không tìm thấy phiếu nhập cần hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_LuuCTPN_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgrv_ChiTietPN.Rows)
                {
                    if (row.Cells["MaCTSanPham_CTPN"].Value != null)
                    {
                        var chiTiet = new ChiTietPhieuNhap
                        {
                            MaPhieuNhap = txt_MaPN.Text,
                            MaCTSanPham = Convert.ToInt32(row.Cells["MaCTSanPham_CTPN"].Value),
                            SoLuong = Convert.ToInt32(row.Cells["SOLUONG_CTPN"].Value),
                            DonGiaNhap = Convert.ToDouble(row.Cells["DonGiaNhap_CTPN"].Value),
                            ThanhTien = Convert.ToDouble(row.Cells["THANHTIEN_CTPN"].Value)
                        };

                        var chiTietSanPham = db.ChiTietSanPhams.First(ctsp => ctsp.ID == chiTiet.MaCTSanPham);
                        chiTietSanPham.Soluong += chiTiet.SoLuong;

                        db.ChiTietPhieuNhaps.InsertOnSubmit(chiTiet);
                    }
                }
                db.SubmitChanges();
                MessageBox.Show("Lưu chi tiết phiếu nhập thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu chi tiết phiếu nhập: " + ex.Message);
            }
        }

        private void btn_Chuyen_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgrv_DanhSachSP.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["SelectColumn"].Value); // Kiểm tra nếu checkbox được chọn

                if (isChecked)
                {
                    if (test == false)
                    {
                        MessageBox.Show("Bạn cần tạo phiếu nhập trước", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Kiểm tra và chuyển đổi mã sản phẩm
                    else if (int.TryParse(row.Cells["ID"].Value?.ToString(), out int maSanPham))
                    {
                        // Truy vấn sản phẩm và chi tiết sản phẩm từ cơ sở dữ liệu bằng LINQ
                        var chiTietSanPham = db.ChiTietSanPhams
                            .Where(ct => ct.MaSanPham == maSanPham)
                            .Select(ct => new
                            {
                                ct.Gia,
                                ct.Soluong
                            })
                            .FirstOrDefault();

                        if (chiTietSanPham != null)
                        {
                            int soLuong = chiTietSanPham.Soluong; // Lấy số lượng có sẵn từ chi tiết sản phẩm

                            // Kiểm tra nếu sản phẩm đã tồn tại trong DataGridView của chi tiết phiếu nhập
                            var existingRow = dgrv_ChiTietPN.Rows.Cast<DataGridViewRow>()
                                              .FirstOrDefault(r => int.TryParse(r.Cells["MaCTSanPham_CTPN"].Value?.ToString(), out int existingMaSanPham) &&
                                                                   existingMaSanPham == maSanPham);

                            if (existingRow != null)
                            {
                                // Nếu sản phẩm đã tồn tại, cập nhật số lượng và thành tiền
                                if (int.TryParse(existingRow.Cells["SOLUONG_CTPN"].Value?.ToString(), out int soLuongHienTai))
                                {
                                    decimal donGia = Convert.ToDecimal(existingRow.Cells["DonGiaNhap_CTPN"].Value);
                                    int soLuongMoi = soLuongHienTai + 1;
                                    existingRow.Cells["SOLUONG_CTPN"].Value = soLuongMoi;
                                    existingRow.Cells["THANHTIEN_CTPN"].Value = soLuongMoi * donGia;
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng hiện tại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                // Nếu sản phẩm chưa tồn tại, thêm mới vào DataGridView
                                dgrv_ChiTietPN.Rows.Add(
                                    txt_MaPN.Text,                     // Mã phiếu nhập
                                    maSanPham,                         // Mã sản phẩm
                                    row.Cells["DONGIA_SP"].Value,      // Đơn giá
                                    1,                                 // Số lượng mặc định là 1
                                    row.Cells["DONGIA_SP"].Value       // Thành tiền = đơn giá * số lượng (1)
                                );
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm muốn thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            TinhTongThanhTien(); // Cập nhật tổng thành tiền

        }

        private void TinhTongThanhTien()
        {
            decimal tongThanhTien = 0;

            // Duyệt qua từng dòng và tính tổng thành tiền
            foreach (DataGridViewRow row in dgrv_ChiTietPN.Rows)
            {
                if (row.Cells["THANHTIEN_CTPN"].Value != null)
                {
                    tongThanhTien += Convert.ToDecimal(row.Cells["THANHTIEN_CTPN"].Value);
                }
            }

            // Hiển thị tổng thành tiền trong TextBox
            txt_ThanhTien.Text = tongThanhTien.ToString(); // Định dạng số tiền
        }

        private void dgrv_ChiTietPN_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Kiểm tra nếu click chuột phải và click vào một dòng hợp lệ
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Chọn dòng hiện tại khi người dùng click chuột phải
                dgrv_ChiTietPN.Rows[e.RowIndex].Selected = true;

                // Tạo menu context khi click chuột phải
                ContextMenuStrip menu = new ContextMenuStrip();

                // Thêm tùy chọn xóa sản phẩm vào menu
                menu.Items.Add("Xóa sản phẩm", null, (s, ev) => XoaSanPham(e.RowIndex));

                // Hiển thị menu tại vị trí con trỏ chuột
                menu.Show(dgrv_ChiTietPN, dgrv_ChiTietPN.PointToClient(Cursor.Position));
            }
        }

        private void XoaSanPham(int rowIndex)
        {
            try
            {
                // Kiểm tra nếu chỉ số dòng hợp lệ trước khi xóa
                if (rowIndex >= 0 && rowIndex < dgrv_ChiTietPN.Rows.Count)
                {
                    // Xóa dòng khỏi DataGridView
                    dgrv_ChiTietPN.Rows.RemoveAt(rowIndex);

                    // Sau khi xóa, cập nhật lại tổng thành tiền
                    TinhTongThanhTien();
                }
                else
                {
                    MessageBox.Show("Không thể xóa sản phẩm này. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có vấn đề khi xóa
                MessageBox.Show("Có lỗi xảy ra khi xóa sản phẩm: " + ex.Message);
            }
        }
    }
}
