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
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.ViewInfo;

namespace LOYAZ
{
    public partial class frm_ms_yenimüşteri_frm : DevExpress.XtraEditors.XtraForm
    {
        public frm_ms_yenimüşteri_frm()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();
        public string neredenGelen = "";

        private void frm_ms_yenimüşteri_frm_Load(object sender, EventArgs e)
        {
            combolariYükle();
            cmbModel();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            //splashScreenManager2.ShowWaitForm();
            //if (btn_kaydet.Text=="GÜNCELLE")
            //{

            //    var frm = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
            //    if (frm != null)
            //        frm.gridcontrolgöster();

            //    MySqlCommand komut = new MySqlCommand("update musteri set adsoyad = @adsoyad, telefon = @telefon, eposta=@eposta, adres = @adres where id = @id", blg.bağlantı());
            //    komut.Parameters.Clear();
            //    komut.Parameters.AddWithValue("@id", frm.lbl_id.Text);
            //    komut.Parameters.AddWithValue("@adsoyad", txt_adsoyad.Text);
            //    komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
            //    komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
            //    komut.Parameters.AddWithValue("@adres", txt_adres.Text);
            //    komut.ExecuteNonQuery();

            //    var frm3 = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
            //    if (frm3 != null)
            //        frm3.gridcontrolgöster();

            //    MessageBox.Show("" + txt_adsoyad.Text + " isimli müşteri " + Environment.NewLine + "başarıyla güncellenmiştir.", "GÜNCELLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
            //if (btn_kaydet.Text=="Kaydet"&& neredenGelen=="yeni")
            //{
            //    if (labelControl1.Text != txt_telefon.Text)
            //    {

            //        MySqlCommand komut = new MySqlCommand("insert into musteri(adsoyad,telefon,eposta,adres) values(@adsoyad,@telefon,@eposta,@adres)", blg.bağlantı());
            //        komut.Parameters.Clear();
            //        komut.Parameters.AddWithValue("@adsoyad", txt_adsoyad.Text);
            //        komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
            //        komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
            //        komut.Parameters.AddWithValue("@adres", txt_adres.Text);
                    
            //        komut.ExecuteNonQuery();
                    

            //        var frm = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
            //        if (frm != null)
            //            frm.gridcontrolgöster();

            //        var frm_yeni3 = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
            //        if (frm_yeni3 != null)
            //            frm_yeni3.gridcontrolgöster();

            //        MessageBox.Show("" + txt_adsoyad.Text + " isimli müşteri " + Environment.NewLine + "başarıyla kaydedilmiştir.", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("" + txt_telefon.Text.Trim(new char[] { '(', ')' }) + " Bu numaraya sahip bir kayıt bulunmaktadır." + Environment.NewLine + "" + Environment.NewLine + " kayda devam edilemiyor!", "KAYIT BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //if (btn_kaydet.Text == "Kaydet" && neredenGelen == "servisden")
            //{
            //    if (labelControl1.Text != txt_telefon.Text)
            //    {
            //        string musteriIdAktar = "";
            //        MySqlCommand komut = new MySqlCommand("insert into musteri(adsoyad,telefon,eposta,adres) values(@adsoyad,@telefon,@eposta,@adres)", blg.bağlantı());
            //        komut.Parameters.Clear();
            //        komut.Parameters.AddWithValue("@adsoyad", txt_adsoyad.Text);
            //        komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
            //        komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
            //        komut.Parameters.AddWithValue("@adres", txt_adres.Text);
            //        komut.ExecuteNonQuery();

            //        //kaydedilenin müşterinin id sini öğren
            //        MySqlCommand servisno = new MySqlCommand("select *from musteri where adsoyad=@adsoyad and telefon=@telefon", blg.bağlantı());
            //        servisno.Parameters.Clear();
            //        servisno.Parameters.AddWithValue("@adsoyad", txt_adsoyad.Text.Trim());
            //        servisno.Parameters.AddWithValue("@telefon", txt_telefon.Text.Trim());
            //        servisno.ExecuteNonQuery();
            //        MySqlDataReader oku = servisno.ExecuteReader();
            //        while (oku.Read())
            //        {
            //            musteriIdAktar = oku["id"].ToString();
            //        }

            //        frm_ts_yeniservis_frm yeni = (frm_ts_yeniservis_frm)Application.OpenForms["frm_ts_yeniservis_frm"];
            //        yeni.txt_müşteriadsoyad.Properties.NullValuePrompt = txt_adsoyad.Text;
            //        yeni.adsoyadBilgi = "yeni oluşturuldu";
            //        yeni.yeniMusteriId = musteriIdAktar;

            //        var frm_yeni = (frm_ts_yeniservis_frm)Application.OpenForms["frm_ts_yeniservis_frm"];
            //        if (frm_yeni != null)
            //        frm_yeni.gridcontrolgöster();


            //        var frm_yeni3 = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
            //        if (frm_yeni3 != null)
            //            frm_yeni3.gridcontrolgöster();


            //        MessageBox.Show("" + txt_adsoyad.Text + " isimli müşteri " + Environment.NewLine + "başarıyla kaydedilmiştir.", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("" + txt_telefon.Text.Trim(new char[] { '(', ')' }) + " Bu numaraya sahip bir kayıt bulunmaktadır." + Environment.NewLine + "" + Environment.NewLine + " kayda devam edilemiyor!", "KAYIT BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //splashScreenManager2.CloseWaitForm();
        }

        private void txt_iletişim_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txt_iletişim_Leave(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("select *from musteri where telefon=@tel", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@tel", txt_telefon.Text.ToString().Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {                
                labelControl1.Text = oku["iletisim"].ToString();
            }

            if (labelControl1.Text == txt_telefon.Text)
            {
                MessageBox.Show("Bu kayıttan var!");
            }
        }


        #region COMBOLARI YÜKLE

        private void combolariYükle()
        {

            //Arac bilgileri getir
            MySqlCommand komut = new MySqlCommand("select distinct arac from tanim_arac", blg.bağlantı());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            comboBoxEdit_aracArac.Properties.Items.Clear();
            comboBoxEdit_AracYil.Properties.Items.Clear();
            lbl_aracSeri.Text = "Seçim bekleniyor.";
            lbl_AracModel.Text = "Seçim bekleniyor.";

            while (oku.Read())
            {
                comboBoxEdit_aracArac.Properties.Items.Add(oku["arac"]);
            }

            comboBoxEdit_aracArac.Text = "Otomobil";

            //lastik bilgileri
            //marka bilgilerini yükle
            MySqlCommand komutMarka = new MySqlCommand("select distinct marka from tanim_lastik", blg.bağlantı());
            komutMarka.ExecuteNonQuery();
            MySqlDataReader okuMarka = komutMarka.ExecuteReader();
            comboBoxEdit_lastikMarka.Properties.Items.Clear();

            while (okuMarka.Read())
            {
                comboBoxEdit_lastikMarka.Properties.Items.Add(okuMarka["marka"]);
            }
            okuMarka.Close();
            //jantçap bilgilerini yükle
            MySqlCommand komutJant = new MySqlCommand("select distinct jantcap from tanim_lastik", blg.bağlantı());
            komutJant.ExecuteNonQuery();
            MySqlDataReader okuJant = komutJant.ExecuteReader();
            comboBoxEdit_lastikJantcap.Properties.Items.Clear();
            while (okuJant.Read())
            {
                comboBoxEdit_lastikJantcap.Properties.Items.Add(okuJant["jantcap"]);
            }
            okuJant.Close();
            //Taban Genişlik bilgilerini yükle
            MySqlCommand komuttaban = new MySqlCommand("select distinct tabangenislik from tanim_lastik", blg.bağlantı());
            komuttaban.ExecuteNonQuery();
            MySqlDataReader okuTaban = komuttaban.ExecuteReader();
            comboBoxEdit_lastikTabanGenislik.Properties.Items.Clear();
            while (okuTaban.Read())
            {
                comboBoxEdit_lastikTabanGenislik.Properties.Items.Add(okuTaban["tabangenislik"]);
            }
            okuTaban.Close();
            //Taban Genişlik bilgilerini yükle
            MySqlCommand komutkesitorani = new MySqlCommand("select distinct kesitorani from tanim_lastik", blg.bağlantı());
            komutkesitorani.ExecuteNonQuery();
            MySqlDataReader okukesitorani = komutkesitorani.ExecuteReader();
            comboBoxEdit_lastikKesitOrani.Properties.Items.Clear();
            while (okukesitorani.Read())
            {
                comboBoxEdit_lastikKesitOrani.Properties.Items.Add(okukesitorani["kesitorani"]);
            }
            okukesitorani.Close();
            //Taban Genişlik bilgilerini yükle
            MySqlCommand komutHizkodu = new MySqlCommand("select distinct hizkodu from tanim_lastik", blg.bağlantı());
            komutHizkodu.ExecuteNonQuery();
            MySqlDataReader okuHizkodu = komutHizkodu.ExecuteReader();
            comboBoxEdit_lastikHizKodu.Properties.Items.Clear();
            while (okuHizkodu.Read())
            {
                comboBoxEdit_lastikHizKodu.Properties.Items.Add(okuHizkodu["hizkodu"]);
            }
            okuHizkodu.Close();
            //Taban Genişlik bilgilerini yükle
            MySqlCommand komutyuzendeks = new MySqlCommand("select distinct yuzendeks from tanim_lastik", blg.bağlantı());
            komutyuzendeks.ExecuteNonQuery();
            MySqlDataReader okuyuzendeks = komutyuzendeks.ExecuteReader();
            comboBoxEdit_lastikYuzEndeks.Properties.Items.Clear();
            while (okuyuzendeks.Read())
            {
                comboBoxEdit_lastikYuzEndeks.Properties.Items.Add(okuyuzendeks["yuzendeks"]);
            }
            okuyuzendeks.Close();
            //Taban Genişlik bilgilerini yükle
            MySqlCommand komutMevsim = new MySqlCommand("select distinct mevsim from tanim_lastik", blg.bağlantı());
            komutMevsim.ExecuteNonQuery();
            MySqlDataReader okuMevsim = komutMevsim.ExecuteReader();
            comboBoxEdit_lastikMevsim.Properties.Items.Clear();
            while (okuMevsim.Read())
            {
                comboBoxEdit_lastikMevsim.Properties.Items.Add(okuMevsim["mevsim"]);
            }
            okuMevsim.Close();
        }

        #endregion

        private void searchLookUpEdit_aracArac_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //MySqlDataAdapter adp = new MySqlDataAdapter("select *from tanim_arac", blg.bağlantı());
                //DataTable ds = new DataTable();
                //adp.Fill(ds);
                //bindingSource1.DataSource = ds;
                //bindingSource1.Filter = "arac ='" + searchLookUpEdit_aracArac.Text + "'";
                //searchLookUpEditAracMarka.Properties.DataSource = bindingSource1;
            }
            catch (Exception)
            {

            }
        }

        private void searchLookUpEditAracMarka_Click(object sender, EventArgs e)
        {
            
        }

        private void searchLookUpEditGrid_AracMarka_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_aracSeri.Text = searchLookUpEditGrid_AracMarka.GetRowCellValue(searchLookUpEditGrid_AracMarka.FocusedRowHandle, "seri").ToString();
                lbl_AracModel.Text = searchLookUpEditGrid_AracMarka.GetRowCellValue(searchLookUpEditGrid_AracMarka.FocusedRowHandle, "model").ToString();
            }
            catch (Exception)
            {

            }
        }

        private void cmbModel()
        {
            //Araca göre bilgi gir
            MySqlDataAdapter adp = new MySqlDataAdapter("select distinct *from tanim_arac", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            bindingSource1.DataSource = ds;
            bindingSource1.Filter = "arac ='" + comboBoxEdit_aracArac.Text + "'";
            searchLookUpEditAracMarka.Properties.DataSource = bindingSource1;
            searchLookUpEditAracMarka.Properties.DisplayMember = "marka";
            searchLookUpEditAracMarka.Properties.ValueMember = "id";
        }

        private void comboBoxEdit_aracArac_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModel();
        }
    }
}