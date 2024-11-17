using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu
{

    class ExcelExport
    {
        DataDataContext db = new DataDataContext();
        public const string TMP_ROW = "TMP_ROW";

        public void ExportDonHang(List<DonHang> donHangs, string filePath)
        {
            // Định nghĩa Dictionary chứa các giá trị thay thế
            Dictionary<string, string> replacer = new Dictionary<string, string>();

            // Cửa hàng và thông tin địa chỉ
            replacer.Add("%CuaHang", "Cửa hàng đồ điện tử");
            replacer.Add("%DiaChiCuaHang", "123 Đường ABC, Quận 1, TP.HCM");

            // Tổng doanh thu
            double tongDoanhThu = (double)donHangs.Sum(dh => dh.TongGiaTri);
            replacer.Add("%TongDoanhThu", String.Format("{0:0,0.00 VNĐ}", tongDoanhThu));

            // Ngày xuất đơn
            string ngayXuat = DateTime.Now.ToString("dd/MM/yyyy");
            replacer.Add("%NgayXuat", ngayXuat);

            // Mở template Excel
            byte[] arrByte = File.ReadAllBytes("TongDoanhThu.xltx").ToArray();
            MemoryStream stream = new MemoryStream(arrByte);

            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

            // Thay thế các giá trị cố định
            foreach (var entry in replacer)
            {
                Replace(workSheet, entry.Key, entry.Value);
            }

            // Chuẩn bị dữ liệu đơn hàng và ánh xạ vào lớp DonHangDTO
            List<DonHangDTO> danhSachDonHang = donHangs.Select((dh, index) => new DonHangDTO
            {
                STT = index + 1,
                HoTen = dh.HoTen,
                NgayDat = dh.NgayDat.ToString("dd/MM/yyyy"), // Kiểm tra null
                Email = dh.Email,
                SoDienThoai = dh.SoDienThoai,
                ChiTietDiaChi = dh.ChiTietDiaChi,
                TongGiaTri = String.Format("{0:0,0.00 VNĐ}", dh.TongGiaTri),
                TrangThaiDonHang = dh.TrangThaiDonHang
            }).ToList();

            // Áp dụng dữ liệu vào Excel
            markProcessor.AddVariable("DonHang", danhSachDonHang);
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

            // Xóa dòng tạm TMP_ROW
            IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }

            // Lưu file Excel
            workBook.SaveAs(filePath);
            workBook.Close();
            engine.Dispose();
        }


        public void ExportChiTietDonHang(DonHang donHang, string filePath)
        {
            try
            {
                // Định nghĩa Dictionary chứa các giá trị thay thế
                Dictionary<string, string> replacer = new Dictionary<string, string>();

                // Tổng tiền cho đơn hàng
                double tongTien = (double)donHang.ChiTietDonHangs.Sum(ct => ct.ThanhTien);
                replacer.Add("%TongTien", String.Format("{0:0,0.00 VNĐ}", tongTien));

                // Cửa hàng và thông tin địa chỉ
                replacer.Add("%CuaHang", "Cửa hàng XYZ");
                replacer.Add("%DiaChiCuaHang", "123 Đường ABC, Quận 1, TP.HCM");

                // Ngày xuất đơn
                string ngayXuat = DateTime.Now.ToString("dd/MM/yyyy");
                replacer.Add("%NgayXuat", ngayXuat);

                // Tên khách hàng
                replacer.Add("%TenKhachHang", donHang.HoTen);

                // Mở template Excel
                byte[] arrByte = File.ReadAllBytes("ChiTietDonHang.xltx").ToArray();
                MemoryStream stream = new MemoryStream(arrByte);

                ExcelEngine engine = new ExcelEngine();
                IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
                IWorksheet workSheet = workBook.Worksheets[0];
                ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

                // Thay thế các giá trị cố định
                foreach (var entry in replacer)
                {
                    Replace(workSheet, entry.Key, entry.Value);
                }

                // Lấy dữ liệu từ bảng ChiTietDonHang kết hợp với ChiTietSanPham
                var chiTietDonHang = (from ctdh in db.ChiTietDonHangs
                                      join cts in db.ChiTietSanPhams on ctdh.MaCTSanPham equals cts.ID
                                      where ctdh.MaDonHang == donHang.MaDonHang
                                      select new
                                      {
                                          TenSanPham = cts.SanPham.TenSanPham,
                                          SoLuong = ctdh.SoLuong,
                                          ThanhTien = ctdh.ThanhTien,
                                      }).ToList(); // Thêm .ToList() để tránh lỗi LINQ to Entities

                // Chuẩn bị dữ liệu chi tiết đơn hàng và ánh xạ vào lớp ChiTietDonHangDTO
                List<ChiTietDonHangDTO> danhSachChiTiet = chiTietDonHang.Select((ct, index) => new ChiTietDonHangDTO
                {
                    STT = index + 1, // Đánh số thứ tự
                    TenSanPham = ct.TenSanPham, // Tên sản phẩm
                    SoLuong = (int)ct.SoLuong, // Số lượng
                    ThanhTien = String.Format("{0:0,0.00 VNĐ}", ct.ThanhTien) // Định dạng thành tiền
                }).ToList();

                // Áp dụng dữ liệu vào Excel
                markProcessor.AddVariable("ChiTietDonHang", danhSachChiTiet);
                markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

                // Xóa dòng tạm TMP_ROW
                IRange range = workSheet.FindFirst(TMP_ROW, ExcelFindType.Text);
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }

                // Lưu file Excel
                workBook.SaveAs(filePath);
                workBook.Close();
                engine.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi xuất file Excel: " + ex.Message);
            }
        }



        // Hàm thay thế giá trị trong Excel template
        private static void Replace(IWorksheet workSheet, string findValue, string replaceValue)
        {
            IRange[] cells = workSheet.Range.Cells;
            for (int i = 0; i < cells.Count(); i++)
            {
                if (cells[i].DisplayText.Contains(findValue))
                {
                    cells[i].Text = cells[i].Text.Replace(findValue, replaceValue);
                    break;
                }
            }
        }
    }

}
