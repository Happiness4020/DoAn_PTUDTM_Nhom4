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
    }
}
