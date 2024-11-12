using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_PTPMUDTM_QLCuaHangBanDoDienTu.UserForm;

namespace DoAn_PTPMUDTM_QLCuaHangBanDoDienTu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_Dashboard());
            Application.Run(new frm_DangNhap());
            //Application.Run(new frmUserMain());
        }
    }
}
