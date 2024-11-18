using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_QLDoDienTu_Web.Models;
using Newtonsoft.Json;

namespace DoAn_QLDoDienTu_Web.Controllers
{
    public class HomeController : Controller
    {
        QL_CuaHangDoDienTuEntities db = new QL_CuaHangDoDienTuEntities();
        // GET: Home
        public ActionResult Index()
        {
            var khs = db.SanPham.Take(12).ToList();
            List<LoaiSanPham> lsp = db.LoaiSanPham.ToList();
            ViewBag.LoaiSanPham = lsp;
            return View(khs);
        }

        public ActionResult TongSanPham(string search = "", int page = 1, string sort_by = "price_asc")
        {
            var sp = db.SanPham;
            List<SanPham> sanpham = db.SanPham.Where(e => e.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            List<LoaiSanPham> cths = db.LoaiSanPham.ToList();
            ViewBag.ChuongTrinhHocs = cths;

            // Sắp xếp 
            if (sort_by == "price_asc")
            {
                sanpham = sanpham.OrderBy(c => c.TenSanPham).ToList();
            }
            else if (sort_by == "price_desc")
            {
                sanpham = sanpham.OrderByDescending(c => c.TenSanPham).ToList();
            }
            ViewBag.SortBy = sort_by;

            // Phân trang
            int NumberOfRecordsPerPage = 8;
            int NumberOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sanpham.Count) / Convert.ToDouble(NumberOfRecordsPerPage)));
            int NumberOfRecordsToSkip = (page - 1) * NumberOfRecordsPerPage;
            ViewBag.Page = page;
            ViewBag.NumberOfPages = NumberOfPages;
            sanpham = sanpham.Skip(NumberOfRecordsToSkip).Take(NumberOfRecordsPerPage).ToList();

            return View(sanpham);
        }
        public ActionResult ChiTietSanPham(int id)
        {
            // Lấy danh sách chi tiết sản phẩm dựa trên MaSanPham
            var chiTietSanPham = db.ChiTietSanPham.Where(x => x.MaSanPham == id).ToList();

            if (chiTietSanPham == null || chiTietSanPham.Count == 0)
            {
                return HttpNotFound("Không tìm thấy sản phẩm.");
            }

            // Chọn chi tiết sản phẩm mặc định (dòng đầu tiên)
            var chiTietMacDinh = chiTietSanPham.FirstOrDefault();

            // Chuyển danh sách chi tiết sản phẩm sang JSON
            var chiTietSanPhamJson = JsonConvert.SerializeObject(chiTietSanPham);

            // Truyền dữ liệu qua ViewBag
            ViewBag.ChiTietSanPhamJson = chiTietSanPhamJson;

            // Trả về View cùng với chi tiết sản phẩm mặc định
            return View(chiTietMacDinh);
        }


        public ActionResult SanPhamTheoLoai(int id, int page = 1, string sort_by = "price_asc")
        {
            List<SanPham> sanpham = db.SanPham.Where(t => t.LoaiSanPham.MaLoai == id).ToList();
            List<LoaiSanPham> lsp = db.LoaiSanPham.ToList();
            ViewBag.LoaiSanPham = lsp;

            ViewBag.MaSP = id;

            // Phân trang
            int NumberOfRecordsPerPage = 8;
            int NumberOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sanpham.Count) / Convert.ToDouble(NumberOfRecordsPerPage)));
            int NumberOfRecordsToSkip = (page - 1) * NumberOfRecordsPerPage;
            ViewBag.Page = page;
            ViewBag.NumberOfPages = NumberOfPages;
            sanpham = sanpham.Skip(NumberOfRecordsToSkip).Take(NumberOfRecordsPerPage).ToList();

            // Sắp xếp 
            if (sort_by == "price_asc")
            {
                sanpham = sanpham.OrderBy(c => c.TenSanPham).ToList();
            }
            else if (sort_by == "price_desc")
            {
                sanpham = sanpham.OrderByDescending(c => c.TenSanPham).ToList();
            }
            ViewBag.SortBy = sort_by;

            return View(sanpham);
        }
    }
}