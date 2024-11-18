using Syncfusion.XlsIO;
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
    public partial class frm_DonHang : Form
    {
        DataDataContext db = new DataDataContext();
        private int selectedOrderId;
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
                selectedOrderId = madh;
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

        private void btn_XuatDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ bảng DonHang
                var danhSachDonHang = from donhang in db.DonHangs
                                      select new
                                      {
                                          donhang.HoTen,
                                          donhang.NgayDat,
                                          donhang.Email,
                                          donhang.SoDienThoai,
                                          donhang.ChiTietDiaChi,
                                          donhang.TongGiaTri,
                                      };

                double tongTien = (double)danhSachDonHang.Sum(dh => dh.TongGiaTri);

                // Tạo DataTable để xuất ra Word
                DataTable tblDonHang = new DataTable();
                tblDonHang.Columns.Add("STT", typeof(int));
                tblDonHang.Columns.Add("Họ và Tên", typeof(string));
                tblDonHang.Columns.Add("Ngày đặt", typeof(string));
                tblDonHang.Columns.Add("Email", typeof(string));
                tblDonHang.Columns.Add("Số điện thoại", typeof(string));
                tblDonHang.Columns.Add("Địa chỉ", typeof(string));
                tblDonHang.Columns.Add("Thành tiền", typeof(double));

                // Thêm dữ liệu vào DataTable
                int stt = 1;
                foreach (var donhang in danhSachDonHang)
                {
                    tblDonHang.Rows.Add(
                        stt++,
                        donhang.HoTen,
                        donhang.NgayDat,
                        donhang.Email,
                        donhang.SoDienThoai,
                        donhang.ChiTietDiaChi,
                        donhang.TongGiaTri
                    );
                }


                // Đường dẫn template file Word
                string templatePath = Application.StartupPath + "/Template/TongDoanhThu.dotx";

                // Sử dụng class WordExport
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("ngayhientai", DateTime.Now.ToString("dd/MM/yyyy"));
                dic.Add("tongtien", tongTien.ToString("N0") + " VNĐ");

                WordExport wd = new WordExport(templatePath, true);

                // Ghi dữ liệu vào Word
                wd.WriteFields(dic);
                wd.WriteTable(tblDonHang, 1);

                // Hiển thị thông báo thành công
                MessageBox.Show("Xuất file đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btn_XuatChiTietDH_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOrderId == 0)
                {
                    MessageBox.Show("Hãy chọn đơn hàng cần xem chi tiết!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Lấy dữ liệu từ bảng ChiTietDonHang kết hợp với ChiTietSanPham
                var chiTietDonHang = from ctdh in db.ChiTietDonHangs
                                     join cts in db.ChiTietSanPhams on ctdh.MaCTSanPham equals cts.ID
                                     where ctdh.MaDonHang == selectedOrderId
                                     select new
                                     {
                                         TenSanPham = cts.SanPham.TenSanPham,
                                         SoLuong = ctdh.SoLuong,
                                         ThanhTien = ctdh.ThanhTien,
                                     };

                double tongTien = (double)chiTietDonHang.Sum(ct => ct.ThanhTien);

                // Tạo DataTable để xuất ra Word
                DataTable tblChiTietDonHang = new DataTable();
                tblChiTietDonHang.Columns.Add("STT", typeof(int));
                tblChiTietDonHang.Columns.Add("Tên sản phẩm", typeof(string));
                tblChiTietDonHang.Columns.Add("Số lượng", typeof(int));
                tblChiTietDonHang.Columns.Add("Thành tiền", typeof(double));

                // Thêm dữ liệu vào DataTable
                int stt = 1;
                foreach (var item in chiTietDonHang)
                {
                    tblChiTietDonHang.Rows.Add(
                        stt++,
                        item.TenSanPham,
                        item.SoLuong,
                        item.ThanhTien
                    );
                }
                // Đường dẫn template file Word
                string templatePath = Application.StartupPath + "/Template/ChiTietDonHang.dotx";

                // Sử dụng class WordExport
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("ngayhientai", DateTime.Now.ToString("dd/MM/yyyy"));
                dic.Add("tenkhachhang", db.DonHangs.FirstOrDefault(dh => dh.MaDonHang == selectedOrderId)?.HoTen);
                dic.Add("tongtien", tongTien.ToString("N0") + " VNĐ");

                WordExport wd = new WordExport(templatePath, true);

                // Ghi dữ liệu vào Word
                wd.WriteFields(dic);
                wd.WriteTable(tblChiTietDonHang, 1);

                // Hiển thị thông báo thành công
                MessageBox.Show("Xuất file chi tiết đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XuatExcel_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng ExcelExport
            ExcelExport excel = new ExcelExport();

            // Lấy danh sách các đơn hàng từ cơ sở dữ liệu
            List<DonHang> donHangs = db.DonHangs.ToList();

            // Kiểm tra nếu có dữ liệu đơn hàng
            if (donHangs != null && donHangs.Count > 0)
            {
                // Mở SaveFileDialog để chọn vị trí lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "TongDoanhThu_" + DateTime.Now.ToString("dd_MM_yyyy_HHmmss") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Gọi hàm ExportDonHang để xuất dữ liệu đơn hàng ra file Excel
                        excel.ExportDonHang(donHangs, filePath);

                        MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu đơn hàng để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_XuatCTDHExcel_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng ExcelExport
            ExcelExport excel = new ExcelExport();

            // Kiểm tra xem người dùng đã chọn đơn hàng trong DataGridView hay chưa
            if (dgvDonHang.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvDonHang.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvDonHang.Rows[selectedRowIndex];
                int donHangId = Convert.ToInt32(selectedRow.Cells["MaDonHang"].Value);

                // Lấy đơn hàng từ cơ sở dữ liệu
                DonHang donHang = db.DonHangs.FirstOrDefault(dh => dh.MaDonHang == donHangId);

                if (donHang != null)
                {
                    // Mở SaveFileDialog để người dùng chọn vị trí lưu file Excel
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";  // Chỉ cho phép chọn file Excel
                    saveFileDialog.FileName = "ChiTietDonHang_" + donHangId + "_" + DateTime.Now.ToString("dd_MM_yyyy_HHmmss") + ".xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        try
                        {
                            // Gọi phương thức ExportChiTietDonHang để xuất dữ liệu chi tiết đơn hàng ra file Excel
                            excel.ExportChiTietDonHang(donHang, filePath);

                            // Hiển thị thông báo thành công
                            MessageBox.Show("Xuất file chi tiết đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Xử lý lỗi nếu có
                            MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu chi tiết đơn hàng để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}

