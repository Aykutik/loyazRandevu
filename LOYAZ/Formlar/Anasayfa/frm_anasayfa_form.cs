using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LOYAZ.Formlar.Ayarlar.KullanıcıHesapları;
using LOYAZ.Formlar.Anasayfa;
using LOYAZ.Formlar.Ayarlar;
using System.IO;

namespace LOYAZ
{
    public partial class frm_anasayfa_form : DevExpress.XtraEditors.XtraForm
    {
        public frm_anasayfa_form()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        public string kullaniciId = "";
        public string dropKullanici = "";

        private void button_teknikservis_Click(object sender, EventArgs e)
        {
            panel_ana.Controls.Clear();
            panel_ts_anasayfa frm = new panel_ts_anasayfa();
            frm.TopLevel = false;
            panel_ana.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
        }

        private void lisansKontrol()
        {
            try
            {
                if (blg.macAlDsyadan() == blg.MACAdresiAl())
                {
                    btn_lisanslama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    layoutControlItemPinc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;                    
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            lisansKontrol();
            //panel_anasayfa frm = (panel_anasayfa)Application.OpenForms["panel_anasayfa"];
            frm_anasayfa_panel frm = new frm_anasayfa_panel();
            //panel_ana.Controls.Clear();
            frm.TopLevel = false;
            panel_ana.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
        }

        private void btn_hesabım_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            pnl_kul_yeni panel = new pnl_kul_yeni();
            panel.TopLevel = false;
            frm.panel_ana.Controls.Add(panel);
            panel.Show();
            panel.Dock = DockStyle.Fill;
        }

        private void btn_çıkış_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_giriş frm = new frm_giriş();
            frm.Show();
            this.Hide();
        }

        private void btn_lisanslama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mac = "";
            string yol = "" + Application.StartupPath + @"\ja\\DevExpress.XtraVerticalGrid.v20.1.resourcesr_adn.dll"; ;

            try
            {
                StreamReader oku = new StreamReader("" + yol + "");
                string satır = oku.ReadLine();
                while (satır != null)
                {
                    mac = satır;
                    satır = oku.ReadLine();
                }

                if (mac == blg.MACAdresiAl())
                {

                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (mac == blg.MACAdresiAl())
                {
                    MessageBox.Show("");
                }
                else
                {
                    Devexpress frm = new Devexpress();
                    frm.Show();
                }
            }
            catch (Exception)
            {

            }

        }

        private void frm_anasayfa_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}