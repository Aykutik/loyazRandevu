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
using MySql.Data.MySqlClient;
using DevExpress.XtraLayout.Converter;
using DevExpress.XtraPrinting.Export.Pdf;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace LOYAZ
{
    public partial class frm_anasayfa_panel : DevExpress.XtraEditors.XtraForm
    {
        sqlbağlantısı blg = new sqlbağlantısı();

        public frm_anasayfa_panel()
        {
            InitializeComponent();
        }

        private void frm_anasayfa_panel_Load(object sender, EventArgs e)
        {
            kul_yet_getir();            
        }

        private void kul_yet_getir()
        {
            string kul_id = "";
            string kul_düzeyi = "";

            string ms = "";
            string ts = "";
            string ayar = "";
            string st = "";
            string stş = "";

            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            kul_id = frm.lbl_kul_id.Text;

            MySqlCommand komut = new MySqlCommand("select *from kul_kullanicilar where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", kul_id);
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                kul_düzeyi = oku["yetki"].ToString();
            }

            MySqlCommand komut2 = new MySqlCommand("select *from kul_kullanicig_yetkiler where ad=@id", blg.bağlantı());
            komut2.Parameters.Clear();
            komut2.Parameters.AddWithValue("@id", kul_düzeyi);
            komut2.ExecuteNonQuery();
            MySqlDataReader oku2 = komut2.ExecuteReader();
            if (oku2.Read())
            {
                ms = oku2["ms_erisim"].ToString();
                ts = oku2["ts_erisim"].ToString();
                ayar = oku2["ayar_erisim"].ToString();
                //st = oku2["ts_erisim"].ToString();
                //sts = oku2["ts_erisim"].ToString();
            }

            if (ms != "true")
            {
                layoutControlItem_müşteriler.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem_müşteriler_boşluk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem_teknikservis.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (ts != "true")
            {
                layoutControlItem_teknikservis.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem_teknikservis_boşluk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (ayar != "true")
            {
                layoutControlItem_ayarlar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //layoutControlItem_ayarlar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //layoutControlItem_stok.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //layoutControlItem_satış.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

            private void button_teknikservis_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();
            
            panel_ts_anasayfa panel = new panel_ts_anasayfa();
            panel.TopLevel = false;
            frm.panel_ana.Controls.Add(panel);
            panel.Show();
            panel.Dock = DockStyle.Fill;            
        }

        private void button_yenimüşteri_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            frm_ms_anasayfa_panel panel = new frm_ms_anasayfa_panel();
            panel.TopLevel = false;
            frm.panel_ana.Controls.Add(panel);
            panel.Show();
            panel.Dock = DockStyle.Fill;
        }

        private void button_ayarlar_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            frm_ayarlar_panel panel = new frm_ayarlar_panel();
            panel.TopLevel = false;
            frm.panel_ana.Controls.Add(panel);
            panel.Show();
            panel.Dock = DockStyle.Fill;
        }

        private void button_stok_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            frm_stk_anasayfa_panel panel = new frm_stk_anasayfa_panel();
            panel.TopLevel = false;
            frm.panel_ana.Controls.Add(panel);
            panel.Show();
            panel.Dock = DockStyle.Fill;
        }

        private void button_satış_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            frm_st_anasayfa_panel panel = new frm_st_anasayfa_panel();
            panel.TopLevel = false;
            frm.panel_ana.Controls.Add(panel);
            panel.Show();
            panel.Dock = DockStyle.Fill;
        }

        private void button_cari_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            frm_st_anasayfa_panel panel = new frm_st_anasayfa_panel();
            panel.TopLevel = false;
            frm.panel_ana.Controls.Add(panel);
            panel.Show();
            panel.Dock = DockStyle.Fill;
        }
    }
}