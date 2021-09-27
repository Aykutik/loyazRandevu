using LOYAZ.Formlar;
using LOYAZ.Formlar.Ayarlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOYAZ
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_giriş());
            //Application.Run(new frm_stk_anasayfa_panel());
            //Application.Run(new LOYAZ.Formlar.Teknikservis.frm_ts_sformyükle_toplu());
        }
    }
}
