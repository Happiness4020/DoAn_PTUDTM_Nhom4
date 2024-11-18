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

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    public partial class frmChiTietSanPham : Form
    {
        SanPham sp;
        List<ChiTietSanPham> lst = new List<ChiTietSanPham>();
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        ChiTietSanPham ct;
        public frmChiTietSanPham()
        {
            InitializeComponent();
            lblTenSanPham.TextAlign = ContentAlignment.TopLeft;// Căn lề văn bản cho Label
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void CardSanPhamDeXuat_OnClick(object sender, EventArgs e)
        {
            this.Close();  // Đóng form khi click vào cardSanPhamDeXuat
        }
        public void setData(SanPham sp)
        {
            this.sp = sp;
            lblTenSanPham.Text = sp.TenSanPham;
            loadCBBChiTiet();
            cboLuaChon.SelectedIndex = 1;
            loadChiTietSP();
            loadSanPhamDeXuat();
        }
        private void loadCBBChiTiet()
        {
            lst = db.ChiTietSanPhams.Where(ct => ct.MaSanPham == sp.MaSanPham).ToList();
            cboLuaChon.DataSource = lst;
            cboLuaChon.DisplayMember = "MauSac";
            cboLuaChon.ValueMember = "ID";
        }
        private void loadChiTietSP()
        {
            int ID = -1;
            if (cboLuaChon.Items.Count > 0 && cboLuaChon.SelectedIndex == 0)
            {
                // Lấy mục đầu tiên trong ComboBox
                ID = lst.First().ID;
            }
            else
            {
                ID = (int)cboLuaChon.SelectedValue;
            }
            ct = db.ChiTietSanPhams.Where(c => c.ID == ID).FirstOrDefault();
            lblGia.Text = ct.Gia + " VNĐ";
            lblTonKho.Text = ct.Soluong.ToString();
            lblMoTa.Text = "Mô tả sản phẩm: " + ct.MoTa;
            LayHinhAnh(sp.Anh);
            nbrSoLuong.Maximum = ct.Soluong;
        }
        private void ThemGioHang()
        {
            try
            {
                GioHang gh = db.GioHangs.Where(g => g.MaCTSanPham == ct.ID).FirstOrDefault();   
                if (gh==null)
                {
                    gh = new GioHang();
                    gh.TenDN = Properties.Settings.Default.tenDN;
                    gh.MaCTSanPham = ct.ID;
                    gh.SoLuong = (int)nbrSoLuong.Value;
                    db.GioHangs.InsertOnSubmit(gh);
                    db.SubmitChanges();
                }else
                {
                    gh.SoLuong += (int)nbrSoLuong.Value;
                    db.SubmitChanges();
                }    
                MessageBox.Show("Thêm giỏ hàng thành công");
                this.Close();
            }catch
            {
                MessageBox.Show("Lỗi khi thêm giỏ hàng");
            }
        }
        private void cboLuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChiTietSP();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            if(ValidateInputs())
                ThemGioHang();
        }
        public bool ValidateInputs()
        {
            string errorMessage = "";
            if (nbrSoLuong.Value < 1)
            {
                errorMessage += "Giá trị số lượng phải là số lớn hơn 1.\n";
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void LayHinhAnh(string tenHinhAnh)
        {
            // Thư mục chứa hình ảnh trong bin\Debug
            string imageDirectory = Path.Combine(Application.StartupPath, "Images\\imgProduct");

            // Kiểm tra lại xem đường dẫn thư mục có chính xác không
            imageDirectory = Path.GetFullPath(imageDirectory);  // Lấy đường dẫn đầy đủ để kiểm tra

            // Kiểm tra xem tên tệp có phần mở rộng hay không
            string imagePath = Path.Combine(imageDirectory, tenHinhAnh); // tenDN đã bao gồm phần mở rộng như .png hoặc .jpg

            // Kiểm tra xem ảnh có tồn tại không và gán vào panel
            if (File.Exists(imagePath))
            {
                pnlImgSanPham.BackgroundImage = Image.FromFile(imagePath);
                pnlImgSanPham.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                MessageBox.Show("Hình ảnh không tồn tại.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                Dat1SanPham();
            }
        }
        private void Dat1SanPham()
        {
            GioHang gh1sp = new GioHang();
            gh1sp.SoLuong = (int)nbrSoLuong.Value;
            gh1sp.MaCTSanPham = ct.ID;
            gh1sp.TenDN = Properties.Settings.Default.tenDN;
            frmDatHang frm = new frmDatHang();
            frm.setData(gh1sp);
            frm.Show();
        }
        public List<ChiTietSanPham> LayChiTietSanPhamDeXuat(string tenDangNhap)
        {
            // Lấy danh sách các chi tiết sản phẩm mà người dùng đã mua
            var dsMaChiTietSanPhamDaMua = db.ChiTietDonHangs
                .Where(dh => dh.DonHang.TenDN == tenDangNhap)
                .Select(dh => dh.MaCTSanPham)
                .ToList();

            // Lấy danh sách tất cả các chi tiết sản phẩm chưa mua
            var dsChiTietSanPhamChuaMua = db.ChiTietSanPhams
                .Where(ctsp => !dsMaChiTietSanPhamDaMua.Contains(ctsp.ID))
                .ToList();

            // Tính điểm tương đồng cho từng chi tiết sản phẩm chưa mua và lưu vào danh sách
            var dsChiTietSanPhamDeXuatVoiDiem = dsChiTietSanPhamChuaMua
                .GroupBy(ctsp => ctsp.MaSanPham) 
                .Select(group => new
                {
                    ChiTietSanPham = group.FirstOrDefault(),
                    DiemTuongDong = TinhDiemTuongDong(group.FirstOrDefault(), dsMaChiTietSanPhamDaMua)
                })
                .OrderByDescending(ctsp => ctsp.DiemTuongDong)
                .Take(5) 
                .Select(ctsp => ctsp.ChiTietSanPham)
                .ToList();

            return dsChiTietSanPhamDeXuatVoiDiem;
        }

        private double TinhDiemTuongDong(ChiTietSanPham chiTietSanPham, List<int> dsMaChiTietSanPhamDaMua)
        {
            var dsChiTietSanPhamDaMua = db.ChiTietSanPhams
                .Where(p => dsMaChiTietSanPhamDaMua.Contains(p.ID))
                .ToList();

            double diemTuongDong = 0;

            var sanPham = db.SanPhams.FirstOrDefault(c => c.MaSanPham == chiTietSanPham.MaSanPham);

            if (sanPham != null)
            {
                foreach (var chiTietSanPhamDaMua in dsChiTietSanPhamDaMua)
                {
                    var sanPhamDaMua = db.SanPhams.FirstOrDefault(c => c.MaSanPham == chiTietSanPhamDaMua.MaSanPham);

                    if (sanPhamDaMua != null)
                    {
                        // Tính điểm tương đồng dựa trên các yếu tố của sản phẩm
                        if (sanPhamDaMua.MaLoai == sanPham.MaLoai)
                        {
                            diemTuongDong += 0.5;
                        }

                        if (sanPhamDaMua.MaNhaSanXuat == sanPham.MaNhaSanXuat)
                        {
                            diemTuongDong += 0.3;
                        }

                        if (Math.Abs(chiTietSanPhamDaMua.Gia - chiTietSanPham.Gia) < 1000000)
                        {
                            diemTuongDong += 0.2;
                        }
                    }
                }

                // Trả về điểm tương đồng trung bình
                return diemTuongDong / dsChiTietSanPhamDaMua.Count;
            }

            // Nếu không có sản phẩm tương ứng
            return 0;
        }

        public void loadSanPhamDeXuat()
        {
            string tenDN = Properties.Settings.Default.tenDN;
            List<ChiTietSanPham> ctspDeXuats = LayChiTietSanPhamDeXuat(tenDN);
            foreach(ChiTietSanPham ct in ctspDeXuats)
            {
                CardSanPhamDeXuat card = new CardSanPhamDeXuat();
                SanPham s = db.SanPhams.Where(sp => sp.MaSanPham == ct.MaSanPham).FirstOrDefault();
                card.setData(s);
                pnlSanPhamDeXuat.Controls.Add(card);
            }    
        }

        private void pnlSanPhamDeXuat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
