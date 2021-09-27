using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using LOYAZ.Raporlar.ts;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LOYAZ
{
    public partial class frm_ts_yeniservis_frm : DevExpress.XtraEditors.XtraForm
    {
        public frm_ts_yeniservis_frm()
        {
            InitializeComponent();
        }
        
        sqlbağlantısı blg = new sqlbağlantısı();

        public void gridcontrolgöster()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from musteri", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            txt_müşteriadsoyad.Properties.ValueMember = "id";
            txt_müşteriadsoyad.Properties.DisplayMember = "adsoyad";
            txt_müşteriadsoyad.Properties.DataSource = ds;
        }

        public string duzenlenecekId = "";

        private void frm_yeniservis_Load(object sender, EventArgs e)
        {
            panelControl2.Visible = blg.visabledurumu();

            if (duzenlenecekId != "")
            {
                MySqlCommand komut = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", duzenlenecekId.ToString().Trim());
                komut.ExecuteNonQuery();
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    txt_müşteriadsoyad.Properties.NullValuePrompt = oku["musteriadsoyad"].ToString();
                    txt_ürün.Text = oku["urun"].ToString();
                    txt_açıklama.Text = oku["aciklama"].ToString();
                }

                btn_servisaç.Text = "Servisi Güncelle";
            }
            gridcontrolgöster();
        }

        private void btn_yenimüşteri_Click(object sender, EventArgs e)
        {            
            frm_ms_yenimüşteri_frm frm = new frm_ms_yenimüşteri_frm();
            frm.Show();

            frm_ms_yenimüşteri_frm yeni = (frm_ms_yenimüşteri_frm)Application.OpenForms["frm_ms_yenimüşteri_frm"];
            yeni.neredenGelen = "servisden";
            
        }

        int sayfa = 1;
       
        private void btn_yeniarıza_Click(object sender, EventArgs e)
        {            
            ürünükaydet();
            frm_ts_ariza_frm frm = new frm_ts_ariza_frm();
            frm.ShowDialog();
        }

        private void combobox_ürünleri_yükle()
        {
            MySqlCommand komut = new MySqlCommand("Select * from ts_urun", blg.bağlantı());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txt_ürün.Properties.Items.Add(read["ad"]);
            }
        }

        private void txt_müşteriadsoyad_EditValueChanged(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("Select *from musteriler where musteriadsoyad=@musteriadsoyad", blg.bağlantı());
            komut.Parameters.AddWithValue("@musteriadsoyad", txt_müşteriadsoyad.Text.Trim());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                musteriId = read["id"].ToString();
            }
            kontrol = "kontrol";
            adsoyadBilgi = "seçildi";
            
        }

        private void txt_ürün_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void ürünükaydet()
        {
            MySqlCommand komut = new MySqlCommand("Select *from ts_urun where ad=@ad", blg.bağlantı());
            komut.Parameters.AddWithValue("@ad", txt_ürün.Text);
            MySqlDataReader read = komut.ExecuteReader();
            if (read.Read())
            {

            }
            else
            {
                MySqlCommand komut_urun = new MySqlCommand("insert into ts_urun(ad) values(@ad)", blg.bağlantı());
                komut_urun.Parameters.AddWithValue("@ad", txt_ürün.Text);
                komut_urun.ExecuteNonQuery();

            }
        }
        public string adsoyadBilgi="";

        private void boslukkontrol()
        {
            if (duzenlenecekId != "" | adsoyadBilgi == "yeni oluşturuldu")
            {

                lbl_bos_ürün.Text = "";

                if (txt_ürün.Text == "")
                {
                    kontrol = "hata";
                    lbl_bos_ürün.Text = "Ürün -";

                }
            }
            else
            {
                lbl_bos_ad.Text = "";
                lbl_bos_arıza.Text = "";
                lbl_bos_marka.Text = "";
                lbl_bos_model.Text = "";
                lbl_bos_ürün.Text = "";

                if (txt_müşteriadsoyad.Text == "")
                {
                    kontrol = "hata";
                    lbl_bos_ad.Text = "Müşteri Ad Soyad -";

                }
                if (txt_ürün.Text == "")
                {
                    kontrol = "hata";
                    lbl_bos_ürün.Text = "Ürün -";

                }


                if (kontrol == "hata")
                {
                    XtraMessageBox.Show("" + lbl_bos_ad.Text + "" + lbl_bos_ürün.Text + "" + lbl_bos_marka.Text + "" + lbl_bos_model.Text + "" + lbl_bos_arıza.Text + " bölümü boş bırakılamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string kontrol = "";
        public string musteriId = "";
        public string yeniMusteriId = "";
        public string duzenlenecekMusteriId = "";

        private void servisikaydet()
        {
            MySqlConnection bağlantı = blg.bağlantı();

            if (duzenlenecekId != "dzn_id") // düzenleme modu
            {
                if (kontrol != "hata" && duzenlenecekMusteriId != musteriId) // müşteri ve arıza değişti
                {   //müşteri değişti arıza aynı
                    MySqlCommand komut = new MySqlCommand("update ts_servis set " +
                        "musteriadsoyad=@musteriadsoyad,musteriid=@musteriid,urun=@urun,marka=@marka,model=@model,aks1=@aks1," +
                        "aks2=@aks2,aks3=@aks3,aks4=@aks4,aciklama=@aciklama,g_tarih=@tarih,g_saat=@saat,g_kullanici=@kullanıcı,g_kullaniciid=@kullaniciid " +
                        "where id=@id", bağlantı);
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", duzenlenecekId.ToString().Trim());
                    komut.Parameters.AddWithValue("@musteriadsoyad", txt_müşteriadsoyad.Text);
                    komut.Parameters.AddWithValue("@musteriid", musteriId);
                    komut.Parameters.AddWithValue("@urun", txt_ürün.Text);
                    komut.Parameters.AddWithValue("@aciklama", txt_açıklama.Text);
                    komut.Parameters.AddWithValue("@tarih", blg.tarih().ToString(blg.tarih_format()));
                    komut.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                    komut.Parameters.AddWithValue("@kullanıcı", blg.kullanıcı());
                    komut.Parameters.AddWithValue("@kullaniciid", blg.kullanıcıid());
                    komut.ExecuteNonQuery();
                    başarılıkapat();
                }
                if (kontrol != "hata" && lbl_müş_düz_id.Text == musteriId) // buraaya girdi nedense?
                {   // müşteri ve arıza değişmedi
                    MySqlCommand komut = new MySqlCommand("update ts_servis set " +
                        "urun=@urun,marka=@marka,model=@model,aks1=@aks1," +
                        "aks2=@aks2,aks3=@aks3,aks4=@aks4,aciklama=@aciklama,g_tarih=@tarih,g_saat=@saat,g_kullanici=@kullanıcı,g_kullaniciid=@kullaniciid " +
                        "where id=@id", bağlantı);
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", duzenlenecekId.ToString().Trim());
                    komut.Parameters.AddWithValue("@urun", txt_ürün.Text);
                    komut.Parameters.AddWithValue("@aciklama", txt_açıklama.Text);
                    komut.Parameters.AddWithValue("@tarih", blg.tarih().ToString(blg.tarih_format()));
                    komut.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                    komut.Parameters.AddWithValue("@kullanıcı", blg.kullanıcı());
                    komut.Parameters.AddWithValue("@kullaniciid", blg.kullanıcıid());
                    komut.ExecuteNonQuery();
                    başarılıkapat();
                }
            }// düzenleme modu sonu

            if (duzenlenecekId == "dzn_id") // yeni kayıt
            {
                if (adsoyadBilgi == "seçildi")
                {
                        MySqlCommand komut = new MySqlCommand("insert into " +
                            "ts_servis(musteriadsoyad,musteriid,urun,aciklama,tarih,saat,kullanici,kullaniciid,durum,sil) " +
                            "values(@musteriadsoyad,@musteriid,@urun,@aciklama,@tarih,@saat,@kullanıcı,@kullaniciid,@durum,@sil)", bağlantı);
                        komut.Parameters.Clear();
                        komut.Parameters.AddWithValue("@musteriadsoyad", txt_müşteriadsoyad.Text);
                        komut.Parameters.AddWithValue("@musteriid", musteriId);
                        komut.Parameters.AddWithValue("@urun", txt_ürün.Text);
                        komut.Parameters.AddWithValue("@aciklama", txt_açıklama.Text);
                        komut.Parameters.AddWithValue("@tarih", blg.tarih());
                        komut.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                        komut.Parameters.AddWithValue("@kullanıcı", blg.kullanıcı());
                        komut.Parameters.AddWithValue("@kullaniciid", blg.kullanıcıid());
                        komut.Parameters.AddWithValue("@durum", 0);
                        komut.Parameters.AddWithValue("@sil", 0);

                        komut.ExecuteNonQuery();

                        //kaydedilenin servis nosunu öğren
                        MySqlCommand servisno = new MySqlCommand("select *from ts_servis where musteriadsoyad=@musteriadsoyad and urun=@urun and tarih=@tarih", bağlantı);
                        servisno.Parameters.Clear();
                        servisno.Parameters.AddWithValue("@musteriadsoyad", txt_müşteriadsoyad.Text);
                        servisno.Parameters.AddWithValue("@urun", txt_ürün.Text);
                        servisno.Parameters.AddWithValue("@tarih", blg.tarih());
                        servisno.ExecuteNonQuery();
                        MySqlDataReader oku = servisno.ExecuteReader();
                        while (oku.Read())
                        {
                            lbl_gecici_id.Text = oku["id"].ToString();
                        }
                        oku.Close();

                        //servis güncelleme kaydı
                        MySqlCommand güncelle = new MySqlCommand("insert into " +
                            "ts_servis_güncelleme(servisid,islem,tarih,saat,kullanici) " +
                            "values(@servisid,@islem,@tarih,@saat,@kullanici)", blg.bağlantı());
                        güncelle.Parameters.Clear();
                        güncelle.Parameters.AddWithValue("@servisid", lbl_gecici_id.Text);
                        güncelle.Parameters.AddWithValue("@tarih", blg.tarih().ToString(blg.tarih_format()));
                        güncelle.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                        güncelle.Parameters.AddWithValue("@kullanici", blg.kullanıcı());
                        güncelle.Parameters.AddWithValue("@islem", "" + txt_ürün.Text + " ürünü TSA" + lbl_gecici_id.Text + " servis takip no ile kabul edildi.");
                        güncelle.ExecuteNonQuery();
                    
                }
                if (adsoyadBilgi == "yeni oluşturuldu")
                {
                    if (kontrol != "hata" )
                    {
                        string geciciId = "";

                        MySqlCommand komut = new MySqlCommand("insert into " +
                            "ts_servis(musteriadsoyad,musteriid,urun,aciklama,tarih,saat,kullanici,kullaniciid,durum,sil) " +
                            "values(@musteriadsoyad,@musteriid,@urun,@aciklama,@tarih,@saat,@kullanıcı,@kullaniciid,@durum,@sil)", bağlantı);
                        komut.Parameters.Clear();
                        komut.Parameters.AddWithValue("@musteriadsoyad", txt_müşteriadsoyad.Properties.NullValuePrompt);
                        komut.Parameters.AddWithValue("@musteriid", yeniMusteriId);
                        komut.Parameters.AddWithValue("@urun", txt_ürün.Text);
                        komut.Parameters.AddWithValue("@aciklama", txt_açıklama.Text);
                        komut.Parameters.AddWithValue("@tarih", blg.tarih());
                        komut.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                        komut.Parameters.AddWithValue("@kullanıcı", blg.kullanıcı());
                        komut.Parameters.AddWithValue("@kullaniciid", blg.kullanıcıid());
                        komut.Parameters.AddWithValue("@durum", 0);
                        komut.Parameters.AddWithValue("@sil", 0);
                        komut.ExecuteNonQuery();

                        //kaydedilenin servis nosunu öğren
                        MySqlCommand servisno = new MySqlCommand("select *from ts_servis where musteriadsoyad=@musteriadsoyad and urun=@urun and tarih=@tarih", bağlantı);
                        servisno.Parameters.Clear();
                        servisno.Parameters.AddWithValue("@musteriadsoyad", txt_müşteriadsoyad.Properties.NullValuePrompt);
                        servisno.Parameters.AddWithValue("@urun", txt_ürün.Text);
                        servisno.Parameters.AddWithValue("@tarih", blg.tarih());
                        servisno.ExecuteNonQuery();
                        MySqlDataReader oku = servisno.ExecuteReader();
                        while (oku.Read())
                        {
                            geciciId = oku["id"].ToString();
                        }
                        oku.Close();
                        //servis güncelleme kaydı
                        MySqlCommand güncelle = new MySqlCommand("insert into " +
                            "ts_servis_güncelleme(servisid,islem,tarih,saat,kullanici) " +
                            "values(@servisid,@islem,@tarih,@saat,@kullanici)", blg.bağlantı());
                        güncelle.Parameters.Clear();
                        güncelle.Parameters.AddWithValue("@servisid", geciciId);
                        güncelle.Parameters.AddWithValue("@tarih", blg.tarih().ToString(blg.tarih_format()));
                        güncelle.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                        güncelle.Parameters.AddWithValue("@kullanici", blg.kullanıcı());
                        güncelle.Parameters.AddWithValue("@islem", "" + txt_ürün.Text + " ürünü TSA" + lbl_gecici_id.Text + " servis takip no ile kabul edildi.");
                        güncelle.ExecuteNonQuery();
                    }
                    
                }
                if (kontrol != "hata")
                {
                    //servis_formuyazdır();
                    başarılıkapat();
                }
            } // yeni kayıt sonu
            
        }

        private void başarılıkapat()
        {            
            var frm = (panel_ts_anasayfa)Application.OpenForms["panel_ts_anasayfa"];
            if (frm != null)
                frm.servissayısınıyazdır();
                frm.gridkontrolgöster();
                //servisiyazdır();
                

            this.Close();
        }

        private void servisiyazdır()
        {
            string tog_servis_barcod = "2";

            MySqlCommand barcodayar = new MySqlCommand("select *from ayarlar where id=@id", blg.bağlantı());
            barcodayar.Parameters.Clear();
            barcodayar.Parameters.AddWithValue("@id", 1);
            barcodayar.ExecuteNonQuery();
            MySqlDataReader oku = barcodayar.ExecuteReader();
            while (oku.Read())
            {
                tog_servis_barcod = oku["yen_ser_barcod"].ToString();
            }

            if (duzenlenecekId == "dzn_id" && tog_servis_barcod == "1")
            {
                for (int i = 0; i < Convert.ToInt32(lbl_sayfasayısı.Text); i++)
                {
                    printDocument1.Print();
                }
            }
            else
            {

            }
        }

        private void btn_servisaç_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            boslukkontrol();
            ürünükaydet();
            servisikaydet();
            splashScreenManager2.CloseWaitForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(lbl_sayfasayısı.Text); i++)
            {
                servisiyazdır();
            }            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font Bbaşlık = new Font("Verdana", 8, FontStyle.Bold);
            Font CİZGİ = new Font("Verdana", 5);
            Font Bbaşlık_marka = new Font("Verdana", 6, FontStyle.Bold);
            Font Bgövde = new Font("Verdana", 7);
            Font Başlık = new Font("Verdana", 4, FontStyle.Bold);
            Font gövde = new Font("Verdana", 4);
            SolidBrush sb = new SolidBrush(Color.Black);

            StringFormat sFormat = new StringFormat();
            sFormat.Alignment = StringAlignment.Near;

            brk_servisno.Text = lbl_gecici_id.Text;
            e.Graphics.DrawString("-----------------------------------------------", CİZGİ, sb, 8, 7);
            e.Graphics.DrawString("Takip No:", Bbaşlık, sb, 8, 11);
            e.Graphics.DrawString("TS" + lbl_gecici_id.Text + "", Bgövde, sb, 110, 12);
            e.Graphics.DrawString("-----------------------------------------------", CİZGİ, sb, 7, 21);

            e.Graphics.DrawString("Müşteri:", Başlık, sb, 9, 29);
            e.Graphics.DrawString(txt_müşteriadsoyad.Text, gövde, sb, 37, 29);

            e.Graphics.DrawString("Ürün:", Başlık, sb, 9, 37);
            e.Graphics.DrawString(txt_ürün.Text, gövde, sb, 37, 37);

            e.Graphics.DrawString("Tarih:", Başlık, sb, 9, 61);
            e.Graphics.DrawString(blg.tarih().ToString(blg.tarih_format()), gövde, sb, 37, 61);

            e.Graphics.DrawString("MİKRON BİLİŞİM", Bbaşlık_marka, sb, 9, 69);

            e.Graphics.DrawImage(brk_servisno.ExportToImage(), 100, 26);

        }

        private void btn_önizleme_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btn_servisformu_Click(object sender, EventArgs e)
        {
            servis_formuyazdır();
        }

        public void servis_formuyazdır()
        {
            string raporstil = "";

            MySqlCommand komut_stil = new MySqlCommand("select *from ayarlar where id=@id", blg.bağlantı());
            komut_stil.Parameters.Clear();
            komut_stil.Parameters.AddWithValue("@id", 1);
            komut_stil.ExecuteNonQuery();
            MySqlDataReader oku_stil = komut_stil.ExecuteReader();
            while (oku_stil.Read())
            {
                raporstil = oku_stil["raporstili"].ToString();
            }

            if (raporstil == "1")
            {
                string müşteriİd = "";
                rpr_ts_servisformu_a4 rapor = new rpr_ts_servisformu_a4();

                MySqlCommand komut2 = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
                komut2.Parameters.Clear();
                komut2.Parameters.AddWithValue("@id", lbl_gecici_id.Text);
                komut2.ExecuteNonQuery();
                MySqlDataReader oku3 = komut2.ExecuteReader();
                while (oku3.Read())
                {
                    rapor.lbl_servisİd.Text = "TSA" + lbl_gecici_id.Text + "";

                    müşteriİd = oku3["musteriid"].ToString();

                    rapor.lbl_ürün.Text = oku3["urun"].ToString();
                    rapor.lbl_servisTarih.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());
                }
                MySqlCommand komut = new MySqlCommand("select *from musteriler where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", müşteriİd);
                komut.ExecuteNonQuery();
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    rapor.lbl_müşteriAdSoyad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_teslimedenMüşteri.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_müşteriEposta.Text = oku["eposta"].ToString();
                    rapor.lbl_müşteriİletişim.Text = oku["iletisim"].ToString();
                    rapor.lbl_müşteriAdres.Text = oku["adres"].ToString();
                }

                rapor.lbl_barcodeServis.Text = "TSA"+ lbl_gecici_id.Text + "";
                rapor.lbl_barcodeServis_alt.Text = "TSA" + lbl_gecici_id.Text + "";

                rapor.lbl_tarih.Text = blg.tarih().ToString(blg.tarih_format());

                ReportPrintTool pt = new ReportPrintTool(rapor);
                pt.AutoShowParametersPanel = false;
                pt.ShowPreviewDialog();
            }
            if (raporstil=="2")
            {
                string müşteriİd = "";
                rpr_a4a5 rapor = new rpr_a4a5();

                MySqlCommand komut2 = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
                komut2.Parameters.Clear();
                komut2.Parameters.AddWithValue("@id", lbl_gecici_id.Text);
                komut2.ExecuteNonQuery();
                MySqlDataReader oku3 = komut2.ExecuteReader();
                while (oku3.Read())
                {
                    rapor.lbl_üst_servisno.Text = "TSA"+lbl_gecici_id.Text+"";
                    rapor.lbl_alt_servisno.Text = "TSA" + lbl_gecici_id.Text + "";

                    müşteriİd = oku3["musteriid"].ToString();

                    rapor.lbl_üst_ürün.Text = oku3["urun"].ToString();

                    rapor.lbl_üst_servistarihi .Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());

                    rapor.lbl_alt_ürün.Text = oku3["urun"].ToString();

                    rapor.lbl_alt_servistarihi.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());

                    rapor.lbl_üst_tyeslimtarihi.Text = blg.tarih().ToString(blg.tarih_format());
                    rapor.lbl_alt_tyeslimtarihi.Text = blg.tarih().ToString(blg.tarih_format());
                }

                MySqlCommand komut = new MySqlCommand("select *from musteriler where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", müşteriİd);
                komut.ExecuteNonQuery();
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    rapor.lbl_üst_müşteriad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_üst_teslimeden.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_üst_eposta.Text = oku["eposta"].ToString();
                    rapor.lbl_üst_müştel.Text = oku["iletisim"].ToString();
                    rapor.lbl_üst_adres.Text = oku["adres"].ToString();

                    rapor.lbl_alt_musteriadsoyad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_alt_teslimeden.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_alt_eposta.Text = oku["eposta"].ToString();
                    rapor.lbl_alt_tel.Text = oku["iletisim"].ToString();
                    rapor.lbl_alt_müştadres.Text = oku["adres"].ToString();
                }

                rapor.lbl_üst_barkod.Text = "TSA" + lbl_gecici_id.Text + "";
                rapor.lbl_alt_barkod.Text = "TSA" + lbl_gecici_id.Text + "";

                MySqlCommand komutU = new MySqlCommand("select *from ayarlar where id=@id", blg.bağlantı());
                komutU.Parameters.Clear();
                komutU.Parameters.AddWithValue("@id", 1);
                komutU.ExecuteNonQuery();
                MySqlDataReader okuU3 = komutU.ExecuteReader();
                while (okuU3.Read())
                {
                    rapor.lbl_üst_unutulanUyarı.Text = okuU3["unutuyarı"].ToString();
                    rapor.lbl_alt_unutulanuyarı.Text = okuU3["unutuyarı"].ToString();
                }
                okuU3.Close();

                MySqlCommand komutF = new MySqlCommand("select *from firma where id=@id", blg.bağlantı());
                komutF.Parameters.Clear();
                komutF.Parameters.AddWithValue("@id", 1);
                komutF.ExecuteNonQuery();
                MySqlDataReader okuF = komutF.ExecuteReader();
                while (okuF.Read())
                {
                    rapor.lbl_alt_teslimalan.Text = okuF["firmadad"].ToString();
                    rapor.lbl_üst_teslimalan.Text = okuF["firmadad"].ToString();
                }
                okuF.Close();

                ReportPrintTool pt = new ReportPrintTool(rapor);
                pt.AutoShowParametersPanel = false;
                pt.ShowPreviewDialog();
            }            
        }
    }
}
