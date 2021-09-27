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
using LOYAZ.Raporlar.ts;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace LOYAZ
{
    public partial class frm_ts_servisgüncelle_frm : DevExpress.XtraEditors.XtraForm
    {
        public frm_ts_servisgüncelle_frm()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void frm_servisikapat_Load(object sender, EventArgs e)
        {
            panelControl2.Visible = blg.visabledurumu();

            MySqlCommand komut = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", lbl_gün_id.Text.ToString().Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txt_müşteriadsoyad.Text = oku["musteriadsoyad"].ToString();
                txt_ürün.Text = oku["urun"].ToString();
                txt_marka.Text = oku["marka"].ToString();
                txt_arıza.Properties.NullValuePrompt = oku["ariza"].ToString();
                txt_kabul_tar.Text = oku["tarih"].ToString();
            }
            txt_servis_no.Text = "TS"+lbl_gün_id.Text+"";

            MySqlCommand listele = new MySqlCommand("select *from ts_servis_güncelleme where servisid=@id;", blg.bağlantı());
            listele.Parameters.Clear();
            listele.Parameters.AddWithValue("@id", lbl_gün_id.Text);
            MySqlDataReader read = listele.ExecuteReader();
            while (read.Read())
            {
                listBoxControl1.Items.Add("  "+read[2]+"  "+read[3]+"   "+read[1]);
            }

            if (lbl_kapatılacak_id.Text != "kapatılacak_id")
            {
                btn_güncelle.Text = "Servisi Kapat";
                this.Text    = "Servis Kapat";
            }
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            if (lbl_kapatılacak_id.Text != "kapatılacak_id")
            {
                serviskapat();
                splashScreenManager2.CloseWaitForm();
                var frm = (panel_ts_anasayfa)Application.OpenForms["panel_ts_anasayfa"];
                if (frm != null)
                    frm.gridkontrolgöster();
                frm.servissayısınıyazdır();
                servisiraporla();
                this.Close();
            }
            else
            {
                servisgüncelle();
                var frm = (panel_ts_anasayfa)Application.OpenForms["panel_ts_anasayfa"];
                if (frm != null)
                    frm.servishareketleriyazdır();
                frm.gridkontrolgöster();
                this.Close();
            }            
        }

        private void servisiraporla()
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
                komut2.Parameters.AddWithValue("@id", lbl_kapatılacak_id.Text);
                komut2.ExecuteNonQuery();
                MySqlDataReader oku3 = komut2.ExecuteReader();
                while (oku3.Read())
                {
                    müşteriİd = oku3["musteriid"].ToString();

                    rapor.lbl_ürün.Text = oku3["urun"].ToString();
                    rapor.lbl_marka.Text = oku3["marka"].ToString();
                    rapor.lbl_model.Text = oku3["model"].ToString();
                    rapor.lbl_arıza.Text = oku3["ariza"].ToString();

                    rapor.lbl_servisTarih.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());
                    rapor.lbl_aks1.Text = oku3["aks1"].ToString();
                    rapor.lbl_aks2.Text = oku3["aks2"].ToString();
                    rapor.lbl_aks3.Text = oku3["aks3"].ToString();
                    rapor.lbl_aks4.Text = oku3["aks4"].ToString();
                }

                MySqlCommand komut = new MySqlCommand("select *from musteriler where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", müşteriİd);
                komut.ExecuteNonQuery();
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    rapor.lbl_müşteriAdSoyad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_müşteriEposta.Text = oku["eposta"].ToString();
                    rapor.lbl_müşteriİletişim.Text = oku["iletisim"].ToString();
                    rapor.lbl_müşteriAdres.Text = oku["adres"].ToString();
                    rapor.lbl_teslimAlan.Text = oku["musteriadsoyad"].ToString();
                }

                rapor.lbl_servisİd.Text = "TSk" + lbl_kapatılacak_id.Text + "";
                rapor.lbl_barcodeServis.Text = "TSK" + lbl_kapatılacak_id.Text + "";
                rapor.lbl_barcodeServis_alt.Text = "TSK" + lbl_kapatılacak_id.Text + "";
                rapor.lbl_başlık.Text = "SERVİS KAPAMA FORMU";
                rapor.lbl_tarih.Text = blg.tarih().ToString(blg.tarih_format()); 
                rapor.lbl_TeslimalanBaşlık.Text = "Teslim Eden";
                rapor.lbl_teslimedenBAŞLIK.Text = "Teslim Alan";

                MySqlCommand komutU = new MySqlCommand("select *from ayarlar where id=@id", blg.bağlantı());
                komutU.Parameters.Clear();
                komutU.Parameters.AddWithValue("@id", 1);
                komutU.ExecuteNonQuery();
                MySqlDataReader okuU3 = komutU.ExecuteReader();
                while (okuU3.Read())
                {
                    rapor.lbl_unutulanMalUyarısı.Text = "";
                }
                okuU3.Close();

                MySqlCommand komutF = new MySqlCommand("select *from firma where id=@id", blg.bağlantı());
                komutF.Parameters.Clear();
                komutF.Parameters.AddWithValue("@id", 1);
                komutF.ExecuteNonQuery();
                MySqlDataReader okuF = komutF.ExecuteReader();
                while (okuF.Read())
                {
                    rapor.lbl_teslimedenMüşteri.Text = okuF["firmadad"].ToString();
                }

                ReportPrintTool pt = new ReportPrintTool(rapor);
                pt.AutoShowParametersPanel = false;
                pt.ShowPreviewDialog();
            }
            if (raporstil == "2")
            {
                string müşteriİd = "";

                rpr_a4a5 rapor = new rpr_a4a5();
                MySqlCommand komut2 = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
                komut2.Parameters.Clear();
                komut2.Parameters.AddWithValue("@id", lbl_kapatılacak_id.Text);
                komut2.ExecuteNonQuery();
                MySqlDataReader oku3 = komut2.ExecuteReader();
                while (oku3.Read())
                {
                    rapor.lbl_üst_servisno.Text = "TSK" +lbl_kapatılacak_id.Text+ "";
                    rapor.lbl_alt_servisno.Text = "TSK" + lbl_kapatılacak_id.Text + "";

                    müşteriİd = oku3["musteriid"].ToString();

                    rapor.lbl_üst_ürün.Text = oku3["urun"].ToString();
                    rapor.lbl_üst_marka.Text = oku3["marka"].ToString();
                    rapor.lbl_üst_model.Text = oku3["model"].ToString();
                    rapor.lbl_üst_ariza.Text = oku3["ariza"].ToString();

                    rapor.lbl_üst_servistarihi.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());
                    rapor.lbl_üst_aks1.Text = oku3["aks1"].ToString();
                    rapor.aks2lbl_üst_.Text = oku3["aks2"].ToString();
                    rapor.lbl_üst_aks3.Text = oku3["aks3"].ToString();
                    rapor.lbl_üst_aks4.Text = oku3["aks4"].ToString();

                    rapor.lbl_alt_ürün.Text = oku3["urun"].ToString();
                    rapor.lbl_alt_marka.Text = oku3["marka"].ToString();
                    rapor.lbl_alt_model.Text = oku3["model"].ToString();
                    rapor.lbl_alt_ariza.Text = oku3["ariza"].ToString();

                    rapor.lbl_alt_servistarihi.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());
                    rapor.lbl_alt_aks1.Text = oku3["aks1"].ToString();
                    rapor.lbl_alt_aks2.Text = oku3["aks2"].ToString();
                    rapor.lbl_alt_aks3.Text = oku3["aks3"].ToString();
                    rapor.lbl_alt_aks4.Text = oku3["aks4"].ToString();
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
                    rapor.lbl_üst_teslimalan.Text = "MİKRON BİLİŞİM";                   // DÜZENLE
                    rapor.lbl_üst_eposta.Text = oku["eposta"].ToString();
                    rapor.lbl_üst_müştel.Text = oku["iletisim"].ToString();
                    rapor.lbl_üst_adres.Text = oku["adres"].ToString();

                    rapor.lbl_alt_musteriadsoyad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_alt_teslimeden.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_alt_eposta.Text = oku["eposta"].ToString();
                    rapor.lbl_alt_tel.Text = oku["iletisim"].ToString();
                    rapor.lbl_alt_müştadres.Text = oku["adres"].ToString();
                }

                rapor.lbl_üst_barkod.Text = "TSK" + lbl_kapatılacak_id.Text + "";
                rapor.lbl_alt_barkod.Text = "TSK" + lbl_kapatılacak_id.Text + "";

                rapor.lbl_üst_başlık.Text = "SERVİS KAPAMA FORMU";                 // DÜZENLE
                rapor.lbl_alt_başlık.Text = "SERVİS KAPAMA FORMU";

                rapor.lbl_teslimalanBAŞLIKüst.Text = "Teslim Eden";
                rapor.lbl_teslimedenBaşlıkÜst.Text = "Teslim Alan";

                rapor.lbl_teslimalanBAŞLIKalt.Text = "Teslim Eden";
                rapor.lbl_teslimedenBAŞLIKalt.Text = "Teslim Alan";

                rapor.lbl_alt_tyeslimtarihi.Text = blg.tarih().ToString(blg.tarih_format());
                rapor.lbl_üst_tyeslimtarihi.Text = blg.tarih().ToString(blg.tarih_format());

                MySqlCommand komutU = new MySqlCommand("select *from ayarlar where id=@id", blg.bağlantı());
                komutU.Parameters.Clear();
                komutU.Parameters.AddWithValue("@id", 1);
                komutU.ExecuteNonQuery();
                MySqlDataReader okuU3 = komutU.ExecuteReader();
                while (okuU3.Read())
                {
                    rapor.lbl_üst_unutulanUyarı.Text = "";
                    rapor.lbl_alt_unutulanuyarı.Text = "";
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

        private void serviskapat()
        {
            DialogResult durum = MessageBox.Show("TSA" + lbl_kapatılacak_id.Text + " nolu teknik servisi kapatmak istediğinizden emin misiniz?", "TSA" + lbl_kapatılacak_id.Text + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == durum)
            {
                MySqlCommand güncelle = new MySqlCommand("insert into " +
                "ts_servis_güncelleme(servisid,islem,tarih,saat,kullanici) " +
                "values(@servisid,@islem,@tarih,@saat,@kullanici)", blg.bağlantı());
                güncelle.Parameters.Clear();
                güncelle.Parameters.AddWithValue("@servisid", lbl_kapatılacak_id.Text);
                güncelle.Parameters.AddWithValue("@tarih", blg.tarih().ToString(blg.tarih_format()));
                güncelle.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                güncelle.Parameters.AddWithValue("@kullanici", blg.kullanıcı());
                güncelle.Parameters.AddWithValue("@islem", "TSA" + lbl_kapatılacak_id.Text + " takip nolu servis kapatıldı.");
                güncelle.ExecuteNonQuery();

                MySqlCommand komut = new MySqlCommand("update ts_servis set durum=@durum,k_tarih=@k_tarih,k_saat=@k_saat where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", lbl_kapatılacak_id.Text.ToString());
                komut.Parameters.AddWithValue("@durum", 1);
                komut.Parameters.AddWithValue("@K_tarih", blg.tarih().ToString(blg.tarih_format()));
                komut.Parameters.AddWithValue("@k_saat", blg.saat().ToString(blg.saat_format()));
                komut.Parameters.AddWithValue("@k_kullanici", blg.kullanıcı());
                komut.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void servisgüncelle()
        {
            if (txt_güncelleme.Text != "")
            {
                MySqlCommand komut = new MySqlCommand("insert into " +
                "ts_servis_güncelleme(servisid,islem,tarih,saat,kullanici) " +
                "values(@servisid,@islem,@tarih,@saat,@kullanici)", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@servisid", lbl_gün_id.Text);
                komut.Parameters.AddWithValue("@islem", txt_güncelleme.Text);
                komut.Parameters.AddWithValue("@tarih", blg.tarih().ToString(blg.tarih_format()));
                komut.Parameters.AddWithValue("@saat", blg.saat().ToString(blg.saat_format()));
                komut.Parameters.AddWithValue("@kullanici", blg.kullanıcı());
                komut.ExecuteNonQuery();
                splashScreenManager2.CloseWaitForm();
                MessageBox.Show("Güncelleme işlemi başarılı.");                
                this.Close();
            }
            else
            {
                MessageBox.Show("Yapılan işlemler boş olamaz!");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            servisiraporla();
        }
    }
}