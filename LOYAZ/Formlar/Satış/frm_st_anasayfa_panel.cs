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
using LOYAZ.Formlar.Satış;

namespace LOYAZ
{
    public partial class frm_st_anasayfa_panel : DevExpress.XtraEditors.XtraForm
    {
        public frm_st_anasayfa_panel()
        {
            InitializeComponent();
            tamamla();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void button_anasayfa_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            frm_anasayfa_panel panel = new frm_anasayfa_panel();
            panel.TopLevel = false;

            frm.panel_ana.Controls.Add(panel);

            panel.Show();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
        }

        private void sepetGridData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select *from stş_sepet", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            BindingSource bs = new BindingSource();
            bs.DataSource = ds;
            gridControl_sepet.DataSource = bs;
        }

        #region button
        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "9";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "6";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "5";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "4";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "3";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "0";
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (txt_barkod.Text.Length > 0)
            {
                txt_barkod.Text = "" + txt_barkod.Text.Substring(txt_barkod.Text.Length - txt_barkod.Text.Length, txt_barkod.Text.Length - 1) + "";
            }
        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "";
        }

        private void btn_yıldız_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + "*";
        }

        private void btn_virgül_Click(object sender, EventArgs e)
        {
            txt_barkod.Text = "" + txt_barkod.Text + ",";
        }


        public double sepetTutarı = 0;
        public double iskontoToplamı = 0;
        public int adet = 0;

        private void btn_enter_Click(object sender, EventArgs e)
        {
            sepeteEkle();
        }
        #endregion


        private void faturaHesapla()
        {
            double istfiyat = 0;
            int adet = 0;
            double etutar = 0;

            MySqlCommand msq = new MySqlCommand("select Sum(etutar),Sum(tutar),Sum(iskonto),Sum(adet),Sum(fiyat) from stş_sepet", blg.bağlantı());
            msq.Parameters.Clear();
            msq.ExecuteNonQuery();
            MySqlDataReader oku_id = msq.ExecuteReader();
            while (oku_id.Read())
            {
                try
                {
                    sepetTutarı = Convert.ToDouble(oku_id["Sum(tutar)"]);
                    iskontoToplamı = Convert.ToDouble(oku_id["Sum(iskonto)"]);
                    adet = Convert.ToInt32(oku_id["Sum(adet)"]);
                    istfiyat = Convert.ToDouble(oku_id["Sum(fiyat)"]);
                    try
                    {
                        etutar = Convert.ToDouble(oku_id["Sum(etutar)"]);
                    }
                    catch (Exception)
                    {
                        etutar = sepetTutarı;
                    }
                }
                catch (Exception)
                {
                    sepetTutarı = 0.00;
                    iskontoToplamı = 0.00;
                    adet = 0;
                    istfiyat = 0;
                    etutar = 0;
                }
            }
            oku_id.Close();

            lbl_ist_miktar.Text = adet.ToString();
            lbl_ist_tutar.Text = (etutar).ToString();
            lbl_ist_iskonto.Text = iskontoToplamı.ToString();
            lbl_ist_net_tutar.Text = (Convert.ToDouble(lbl_ist_tutar.Text) - iskontoToplamı).ToString();
        }

        public void sepeteEkle()
        {
            string barkod = txt_barkod.Text;
            string ürünkodu = "";
            string varyant = "";
            double satışfiyatı = 0.00;
            int krtkstok = 0;

            //barcodu ürüne çevir
            MySqlCommand komut_id = new MySqlCommand("select *from ür_varyant where barkod=@id", blg.bağlantı());
            komut_id.Parameters.Clear();
            komut_id.Parameters.AddWithValue("@id", barkod);
            komut_id.ExecuteNonQuery();
            MySqlDataReader oku_id = komut_id.ExecuteReader();
            while (oku_id.Read())
            {
                ürünkodu = oku_id["ürünkodu"].ToString();
                varyant = oku_id["ad"].ToString();
                satışfiyatı = Convert.ToDouble(oku_id["satışfiyatı"]);
            }
            oku_id.Close();

            string ürün = "";

            //gelen ürün kodundan ürün adını getir

            MySqlCommand komut_2 = new MySqlCommand("select *from ür_ürün where ürünkodu=@id", blg.bağlantı());
            komut_2.Parameters.Clear();
            komut_2.Parameters.AddWithValue("@id", ürünkodu);
            komut_2.ExecuteNonQuery();
            MySqlDataReader oku_2 = komut_2.ExecuteReader();
            while (oku_2.Read())
            {
                ürün = oku_2["ad"].ToString();
            }
            oku_2.Close();

            // Önceden var mı sepette bu ürün?
            int öncekiAdet = 0;

            try
            {
                MySqlCommand komut_3 = new MySqlCommand("select *from stş_sepet where ürünkodu=@id and varyant=@varyant", blg.bağlantı());
                komut_3.Parameters.Clear();
                komut_3.Parameters.AddWithValue("@id", ürünkodu);
                komut_3.Parameters.AddWithValue("@varyant", varyant);
                komut_3.ExecuteNonQuery();
                MySqlDataReader oku_3 = komut_3.ExecuteReader();
                if (oku_3.Read())
                {
                    öncekiAdet = Convert.ToInt32(oku_3["adet"]);
                }
                oku_3.Close();
            }
            catch (Exception)
            {
                öncekiAdet = 0;
            }

            double tutar = 0.00;

            // Önceden sepette var ise..

            if (ürünkodu!="")
            {
                if (öncekiAdet > 0)
                {
                    // tutarı hesapla
                    int yeniAdet = öncekiAdet + 1;

                    tutar = satışfiyatı * yeniAdet;

                    // ürünü sepete ekle +
                    MySqlCommand komut_refyeni = new MySqlCommand("update stş_sepet set adet=@adet,tutar=@tutar,iskonto=@iskonto,etutar=@etutar" +
                        " where ürünkodu=@id and varyant=@varyant", blg.bağlantı());
                    komut_refyeni.Parameters.Clear();
                    komut_refyeni.Parameters.AddWithValue("@id", ürünkodu);
                    komut_refyeni.Parameters.AddWithValue("@varyant", varyant);
                    komut_refyeni.Parameters.AddWithValue("@adet", yeniAdet);
                    komut_refyeni.Parameters.AddWithValue("@tutar", tutar);
                    komut_refyeni.Parameters.AddWithValue("@iskonto", 0);
                    komut_refyeni.Parameters.AddWithValue("@etutar", tutar);
                    komut_refyeni.ExecuteNonQuery();
                    komut_refyeni.Dispose();
                }
                else
                {
                    // ürünü sepete ekle
                    MySqlCommand komut = new MySqlCommand("insert into stş_sepet" +
                             "(ürün,ürünkodu,adet,fiyat,tutar,açıklama,varyant,iskonto,etutar) " +
                    "values(@ürün,@ürünkodu,@adet,@fiyat,@tutar,@açıklama,@varyant,@iskonto,@etutar)", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@ürün", ürün);
                    komut.Parameters.AddWithValue("@ürünkodu", ürünkodu);
                    komut.Parameters.AddWithValue("@adet", 1);
                    komut.Parameters.AddWithValue("@fiyat", satışfiyatı);
                    komut.Parameters.AddWithValue("@tutar", satışfiyatı);
                    komut.Parameters.AddWithValue("@varyant", varyant);
                    komut.Parameters.AddWithValue("@açıklama", txt_açıklama.Text);
                    komut.Parameters.AddWithValue("@iskonto", 0);
                    komut.Parameters.AddWithValue("@etutar", satışfiyatı);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
            }

            tamamla();
        }

        public void tamamla()
        {
            sepetGridData();
            txt_barkod.Text = "";
            faturaHesapla();
        }

        private void btn_ödemea_Click(object sender, EventArgs e)
        {

            MySqlCommand komut2 = new MySqlCommand("delete from stş_sepet", blg.bağlantı());
            komut2.ExecuteNonQuery();

            tamamla();
        }

        private void gridView_sepet_Click(object sender, EventArgs e)
        {
            id = gridView_sepet.FocusedRowHandle;
        }

        int id = 0;

        private void gridView_sepet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //id = gridView_sepet.FocusedRowHandle;
        }

        private void adetDeğişir()
        {
            string varyant = "";
            string ürünkodu = "";
            double tutar = 0.00;
            double yenitutar = 0.00;
            int adet = 0;
            int yeniadet = 0;
                       

            MySqlCommand komut_3 = new MySqlCommand("select *from stş_sepet where id=@id", blg.bağlantı());
            komut_3.Parameters.AddWithValue("@id", id);
            komut_3.ExecuteNonQuery();
            MySqlDataReader oku_3 = komut_3.ExecuteReader();
            if (oku_3.Read())
            {
                varyant = oku_3["varyant"].ToString();
                ürünkodu = oku_3["ürünkodu"].ToString();
                tutar = Convert.ToDouble(oku_3["tutar"]);
            }
            oku_3.Close();
              
        }

        private void btn_miktardeğiştir_Click(object sender, EventArgs e)
        {
            double iskonto = Convert.ToDouble(gridView_sepet.GetRowCellValue(id, "iskonto").ToString());
            string ürünkodu = gridView_sepet.GetRowCellValue(id, "ürünkodu").ToString();
            string ürün = gridView_sepet.GetRowCellValue(id, "ürün").ToString();
            string varyant = gridView_sepet.GetRowCellValue(id, "varyant").ToString();
            int adet = Convert.ToInt32(gridView_sepet.GetRowCellValue(id, "adet").ToString());
            double fiyat = Convert.ToDouble(gridView_sepet.GetRowCellValue(id, "fiyat").ToString());

            frm_st_adetdeğiştir frm = new frm_st_adetdeğiştir();
            frm.Show();

            var frm2 = (frm_st_adetdeğiştir)Application.OpenForms["frm_st_adetdeğiştir"];
            if (frm2 != null)
                frm2.Text = "Adet Değiştir";
                frm2.lbl_ürün.Text = ""+ürün+"-"+varyant+"";
                frm2.txt_adet.Text = adet.ToString();
                frm2.varyant = varyant;
                frm2.ürünkodu = ürünkodu;
                frm2.fiyat = fiyat;
                frm2.iskonto = iskonto;
                frm2.adet = adet;
                frm2.id = id;
        }

        private void btn_ürünSil_Click(object sender, EventArgs e)
        {
            string ürünkodu = gridView_sepet.GetRowCellValue(id, "ürünkodu").ToString();
            string varyant = gridView_sepet.GetRowCellValue(id, "varyant").ToString();

            try
            {
                MySqlCommand komut2 = new MySqlCommand("delete from stş_sepet where ürünkodu=@ürünkodu and varyant=@varyant", blg.bağlantı());
                komut2.Parameters.AddWithValue("@ürünkodu", ürünkodu);
                komut2.Parameters.AddWithValue("@varyant", varyant);
                komut2.ExecuteNonQuery();

                tamamla();
            }
            catch (Exception)
            {

            }
        }

        private void btn_fiyatdeğiştir_Click(object sender, EventArgs e)
        {
            string ürünkodu2 = gridView_sepet.GetRowCellValue(id, "ürünkodu").ToString();
            string ürün2 = gridView_sepet.GetRowCellValue(id, "ürün").ToString();
            string varyant2 = gridView_sepet.GetRowCellValue(id, "varyant").ToString();
            double fiyat2 = Convert.ToDouble(gridView_sepet.GetRowCellValue(id, "fiyat").ToString());
            int adet2 = Convert.ToInt32(gridView_sepet.GetRowCellValue(id, "adet").ToString());

            frm_st_fiyatdeğiştir frm = new frm_st_fiyatdeğiştir();
            frm.Show();

            var frm2 = (frm_st_fiyatdeğiştir)Application.OpenForms["frm_st_fiyatdeğiştir"];
            if (frm2 != null)
            frm2.lbl_ürün2.Text = "" + ürün2 + "-" + varyant2 + "";
            frm2.txt_fiyat2.Text = fiyat2.ToString();
            frm2.varyant2 = varyant2.ToString();
            frm2.ürünkodu2 = ürünkodu2.ToString();
            frm2.adet2 = adet2;
        }

        private void btn_ürün_bul_Click(object sender, EventArgs e)
        {
            frm_st_ürünbul frm = new frm_st_ürünbul();
            frm.ShowDialog();
        }

        private void btn_ürüne_iskonto_Click(object sender, EventArgs e)
        {
            string ürünkodu2 = gridView_sepet.GetRowCellValue(id, "ürünkodu").ToString();
            string ürün2 = gridView_sepet.GetRowCellValue(id, "ürün").ToString();
            string varyant2 = gridView_sepet.GetRowCellValue(id, "varyant").ToString();
            double fiyat2 = Convert.ToDouble(gridView_sepet.GetRowCellValue(id, "fiyat").ToString());
            double tutar = Convert.ToDouble(gridView_sepet.GetRowCellValue(id, "tutar").ToString());
            int adet2 = Convert.ToInt32(gridView_sepet.GetRowCellValue(id, "adet").ToString());

            frm_st_ürüneiskonto frm = new frm_st_ürüneiskonto();
            frm.Show();

            var frm2 = (frm_st_ürüneiskonto)Application.OpenForms["frm_st_ürüneiskonto"];
            if (frm2 != null)
                frm2.lbl_ürün.Text = "" + ürün2 + "-" + varyant2 + "";
                frm2.lbl_öncekifiyat.Text = fiyat2.ToString();
                frm2.öncekiFiyat = fiyat2;
                frm2.öncekitutar = tutar;
                frm2.varyant = varyant2.ToString();
                frm2.ürünkodu = ürünkodu2.ToString();
                frm2.adet = adet2;
        }
    }
}