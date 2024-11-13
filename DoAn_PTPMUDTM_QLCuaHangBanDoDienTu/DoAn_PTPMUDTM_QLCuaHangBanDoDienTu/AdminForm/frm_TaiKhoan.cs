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
    public partial class frm_TaiKhoan : Form
    {
        DataDataContext db = new DataDataContext();
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.AllowUserToAddRows = false;
            Load_DataTK();
        }

        private void Load_DataTK()
        {
            var taikhoans = from tk in db.TaiKhoans select tk;
            dgvTaiKhoan.DataSource = taikhoans;
        }
    }
}
