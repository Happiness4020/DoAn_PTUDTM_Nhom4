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
    public partial class frm_ChiTietDonHang : Form
    {
        DataDataContext db = new DataDataContext();
        public int madh;
        public frm_ChiTietDonHang(int madonhang)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            madh = madonhang;
        }

        private void Load_DataCTDH()
        {
            try
            {
                var kq = db.ChiTietDonHangs
                               .Where(ctdh => ctdh.MaDonHang == madh)
                               .ToList();

                if (kq.Count > 0)
                {
                    dgvCTDH.DataSource = kq;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frm_ChiTietDonHang_Load(object sender, EventArgs e)
        {
            dgvCTDH.AutoGenerateColumns = false;
            dgvCTDH.AllowUserToAddRows = false;
            Load_DataCTDH();
        }
    }
}
