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
    public partial class CardDiaChi : UserControl
    {
        DiaChi dc;
        dbQLCuaHangDienTuDataContext db = new dbQLCuaHangDienTuDataContext();
        public CardDiaChi()
        {
            InitializeComponent();
            //txtDiaChi.Dispose();
        }
        public void setData(DiaChi dc)
        {
            this.dc = db.DiaChis.Where(d => d.MaDiaChi == dc.MaDiaChi).FirstOrDefault();
            txtDiaChi.Text = dc.DiaChi1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteDiaChi();
        }
        private void DeleteDiaChi()
        {
            try
            {
                db.DiaChis.DeleteOnSubmit(dc);
                db.SubmitChanges();
                MessageBox.Show("Xóa dịa chỉ thành công");
                this.Dispose();
            }
            catch
            {
                MessageBox.Show("Xóa địa chỉ thất bại");
            }

        }
        private void UpdateDiaChi()
        {
            try
            {
                if (txtDiaChi.Text.Length <= 0)
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo");
                    return;
                }
                dc.DiaChi1 = txtDiaChi.Text;
                db.SubmitChanges();
                MessageBox.Show("Cập nhật địa chỉ thành công");

            }
            catch
            {
                MessageBox.Show("Cập nhật địa chỉ thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UpdateDiaChi();
        }
    }
}
