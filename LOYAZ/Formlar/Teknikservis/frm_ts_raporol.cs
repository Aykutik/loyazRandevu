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
using DevExpress.XtraReports.Parameters;
using MySql.Data.MySqlClient;
using LOYAZ.Raporlar.ts;
using DevExpress.XtraReports.UI;
using System.Drawing.Text;
using DevExpress.DataProcessing;

namespace LOYAZ
{
    public partial class frm_ts_raporol : DevExpress.XtraEditors.XtraForm
    {
        public frm_ts_raporol()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();


        private void frm_ts_raporol_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from musteriler", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            txt_müşteri_adsoyad.Properties.ValueMember = "ID";
            txt_müşteri_adsoyad.Properties.DisplayMember = "musteriadsoyad";
            txt_müşteri_adsoyad.Properties.DataSource = ds;

            ürünlistesinidoldur();
            dt_bas.Text= blg.tarih().ToString(blg.tarih_format());
            dt_son.Text = blg.tarih().ToString(blg.tarih_format());

            lbl_gecici_durum.Text = rd_durum.Text;
            rd_durum.EditValue = "1";
        }

        private void txt_müşteri_adsoyad_EditValueChanged(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("Select *from musteriler where musteriadsoyad=@musteriadsoyad", blg.bağlantı());
            komut.Parameters.AddWithValue("@musteriadsoyad", txt_müşteri_adsoyad.Text.Trim());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                lbl_müş_id.Text = read["id"].ToString();
            }
        }

        private void txt_ürün_SelectedIndexChanged(object sender, EventArgs e)
        {
            markalistesinidoldur();
        }

        private void txt_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            modellistesinidoldur();
        }

        public void ürünlistesinidoldur()
        {
            MySqlCommand komut = new MySqlCommand("Select * from ts_urun", blg.bağlantı());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txt_ürün.Properties.Items.Add(read["ad"]);
            }
        }


        public void markalistesinidoldur()
        {
            MySqlCommand komut = new MySqlCommand("Select *from ts_marka where urun=@urun", blg.bağlantı());
            komut.Parameters.AddWithValue("@urun", txt_ürün.Text.Trim());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txt_marka.Properties.Items.Add(read["ad"]);
            }
        }

        public void modellistesinidoldur()
        {
            MySqlCommand komut = new MySqlCommand("Select *from ts_model where marka=@marka", blg.bağlantı());
            komut.Parameters.AddWithValue("@marka", txt_marka.Text.Trim());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txt_model.Properties.Items.Add(read["ad"]);
            }
        }

        private void btn_rpr_hazırla_Click(object sender, EventArgs e)
        {
            string müşteri = "";
            string ürün = "";
            string marka = "";
            string model = "";
            string durum = "";

            if (txt_müşteri_adsoyad.Text != "")
            {
                müşteri = " and musteriadsoyad = '" + txt_müşteri_adsoyad.Text + "'"; 
            }
            else
            {
                müşteri = "";
            }

            if (txt_ürün.Text != "")
            {
                ürün = " and urun = '" + txt_ürün.Text + "'";
            }
            else
            {
                ürün = "";
            }

            if (txt_marka.Text != "")
            {
                marka = " and marka = '" + txt_marka.Text + "'";
            }
            else
            {
                marka = "";
            }

            if (txt_model.Text != "")
            {
                model = " and model = '" + txt_model.Text + "'";
            }
            else
            {
                model = "";
            }

            if (rd_durum.EditValue.ToString() == "1")
            {
                durum = "";
            }

            if (rd_durum.EditValue.ToString() == "2")
            {
                durum = " and durum = '0'";
            }

            if (rd_durum.EditValue.ToString() == "3")
            {
                durum = " and durum = '1'";
            }

            rpr_ts_tümü rapor = new rpr_ts_tümü();
            MySqlDataAdapter komut2 = new MySqlDataAdapter("select *from ts_servis", blg.bağlantı());

            DataTable ds = new DataTable();
            komut2.Fill(ds);

            rapor.bindingSource1.DataSource = ds;
            rapor.bindingSource1.Filter = "tarih >=  '" + dt_bas.EditValue + "'and tarih <='" + dt_son.EditValue + "'"+müşteri+""+ürün+""+marka+""+model+""+durum+"";

           
            MySqlCommand komut = new MySqlCommand("select *from firma", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            MySqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {
                rapor.lbl_firma.Text = oku3["firmadad"].ToString();
                rapor.pic_firmaLogo.ImageUrl = oku3["logoyol"].ToString();
            }            

            ReportPrintTool pt = new ReportPrintTool(rapor);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreviewDialog();
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}