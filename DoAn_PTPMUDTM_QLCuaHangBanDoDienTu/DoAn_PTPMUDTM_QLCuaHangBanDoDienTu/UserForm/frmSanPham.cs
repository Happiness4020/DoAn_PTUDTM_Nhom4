using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    public partial class frmSanPham : Form
    {
        int pageNumber = 1; // Số trang hiện tại (ví dụ là trang 1)
        int pageSize = 12; //Số sản phẩm trong trang
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        int pageNumberMax = 1;
        public frmSanPham()
        {
            InitializeComponent();
            pageNumberMax = (int)Math.Ceiling((double)db.SanPhams.Count() / pageSize);
            LaySanPham();
            this.Dock = DockStyle.Fill;
            LayLoaiSanPham();
        }      

        public void LaySanPham()
        {
            // Tính số lượng sản phẩm cần bỏ qua
            int skip = (pageNumber - 1) * pageSize;
            List<SanPham> lst = db.SanPhams
                .Where(sp=>sp.TrangThaiSP==0)
                .OrderBy(sp => sp.MaSanPham) // Sắp xếp theo một tiêu chí (ví dụ: MaSanPham)
                .Skip(skip) // Bỏ qua các sản phẩm trước đó
                .Take(pageSize) // Lấy số lượng sản phẩm tương ứng với pageSize
                .ToList();

            // Xóa các control cũ (nếu có) trong panel
            fillToPanle(lst);
        }
        public void LayLoaiSanPham()
        {
            List<LoaiSanPham> lst = db.LoaiSanPhams.Where(t => t.TrangThaiLoaiSP == 0).ToList();
            LoaiSanPham emptyItem = new LoaiSanPham
            {
                MaLoai = 0,  // Hoặc null, tùy thuộc vào kiểu dữ liệu của MaLoai
                TenLoai = "Chọn loại sản phẩm"  // Giá trị hiển thị cho mục rỗng
            };
            // Thêm đối tượng LoaiSanPham rỗng vào danh sách
            lst.Insert(0, emptyItem);
            cboLoaiSP.DataSource = lst;
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai"; 
        }
        public void LocSanPham()
        {
            if (cboLoaiSP.SelectedIndex != 0)
            {
                int MaLoai = (int)cboLoaiSP.SelectedValue;
                pageNumber = 1;
                int skip = (pageNumber - 1) * pageSize;
                List<SanPham> lst = db.SanPhams.Where(s => s.MaLoai == MaLoai && s.TrangThaiSP == 0)
                    .Skip(skip) // Bỏ qua các sản phẩm trước đó
                    .Take(pageSize) // Lấy số lượng sản phẩm tương ứng với pageSize
                    .ToList();
                pageNumberMax = (int)Math.Ceiling((double)lst.Count() / pageSize);
                fillToPanle(lst);
            }
            else
            {
                pageNumberMax = (int)Math.Ceiling((double)db.SanPhams.Count() / pageSize);
                LaySanPham();
            }    
        }
        public void TimSanPham(string TenSP)
        {
            if (TenSP.Length>0)
            {
                int MaLoai = (int)cboLoaiSP.SelectedValue;
                pageNumber = 1;
                int skip = (pageNumber - 1) * pageSize;
                List<SanPham> lst = db.SanPhams.Where(s => s.TenSanPham.ToLower().Contains(TenSP.ToLower()) && s.TrangThaiSP == 0)
                    .Skip(skip) // Bỏ qua các sản phẩm trước đó
                    .Take(pageSize) // Lấy số lượng sản phẩm tương ứng với pageSize
                    .ToList();
                pageNumberMax = (int)Math.Ceiling((double)lst.Count() / pageSize);
                fillToPanle(lst);
            }
            else
            {
                pageNumberMax = (int)Math.Ceiling((double)db.SanPhams.Count() / pageSize);
                LaySanPham();
            }
        }
        public void fillToPanle(List<SanPham> lst)
        {
            pnlSanPhan.Controls.Clear();

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill; // Để panel tự động điều chỉnh kích thước
            flowPanel.WrapContents = true; // Cho phép dòng tiếp theo khi hết không gian
            flowPanel.FlowDirection = FlowDirection.LeftToRight; // Sắp xếp từ trái sang phải

            foreach (SanPham s in lst)
            {
                CardSanPham card = new CardSanPham();
                card.setData(s);
                pnlSanPhan.Controls.Add(card);
            }


            // Thêm FlowLayoutPanel vào pnlSanPhan
            pnlSanPhan.Controls.Add(flowPanel);
        }

   
        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocSanPham();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (pageNumber < pageNumberMax)
            {
                this.pageNumber++;
                LocSanPham();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                this.pageNumber--;
                LocSanPham();
            }

        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            LocSanPham();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            pageNumber = pageNumberMax;
            LocSanPham();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {

        }

        private void cboLoaiSP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LocSanPham();
        }
    }
}
