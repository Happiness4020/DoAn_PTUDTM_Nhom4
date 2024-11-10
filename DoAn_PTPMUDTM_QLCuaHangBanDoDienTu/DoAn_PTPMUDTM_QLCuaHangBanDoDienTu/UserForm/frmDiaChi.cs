using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm
{
    public partial class frmDiaChi : Form
    {
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        string TenDN;
        int soLuongDiaChi=3;
        public frmDiaChi()
        {
            InitializeComponent();
        }
       public void setData(string TenDN)
        {
            pnlDiaChi.Controls.Clear();
            this.TenDN = TenDN;
            List<DiaChi> lst = db.DiaChis.Where(t => t.TenDN == TenDN).ToList();
            foreach(DiaChi d in lst)
            {
                CardDiaChi card = new CardDiaChi();
                card.setData(d);
                pnlDiaChi.Controls.Add(card);
            }    
        }
        private void ThemGioHang()
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int sl = db.DiaChis.Where(t => t.TenDN == TenDN).Count();
            if (sl + 1> soLuongDiaChi)
            {
                MessageBox.Show("Đã đạt số lượng địa chỉ tối đa (" + soLuongDiaChi + " địa chỉ)\nVui lòng xóa hoặc cập nhật lại địa chỉ hiện có", "Lỗi khi thêm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DiaChi add = new DiaChi();
                add.TenDN = TenDN;
                add.DiaChi1 = txtDiaChi.Text;
                db.DiaChis.InsertOnSubmit(add);
                db.SubmitChanges();
                MessageBox.Show("Thêm địa chỉ thành công");
                setData(TenDN);
            }
            catch
            {
                MessageBox.Show("Lỗi khi thêm địa chỉ");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ThemGioHang();
        }


    }
}
