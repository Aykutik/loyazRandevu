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
    public partial class FrmMsYenimüşteriFrm : DevExpress.XtraEditors.XtraForm
    {
        public FrmMsYenimüşteriFrm()
        {
            InitializeComponent();
        }

        sqlbağlantısı _blg = new sqlbağlantısı();
        public int musteriid = 2;
        public string neredenGelen = "";
        string _telefonKontrol = "";

        private void frm_ms_yenimüşteri_frm_Load(object sender, EventArgs e)
        {
            CombolariYükle();
            CmbModel();
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
            //    
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

        private void txt_iletişim_Leave(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("select *from musteri where telefon=@tel", _blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@tel", txt_telefon.Text.ToString().Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                _telefonKontrol = oku["telefon"].ToString();
            }

            if (_telefonKontrol == txt_telefon.Text)
            {
                MessageBox.Show("Bu kayıttan var!");
            }
        }

        #region  COMBO
        private void searchLookUpEditAracMarka_EditValueChanged(object sender, EventArgs e)
        {

            comboBoxEdit_lastikMarka.Enabled = true;
            lbl_aracSeri.Enabled = true;
            lbl_AracModel.Enabled = true;
            comboBoxEdit_AracYil.Enabled = true;
            txt_aracPlaka.Enabled = true;


        }

        #region COMBOLARI YÜKLE

        private void CombolariYükle()
        {
            // Arac bilgileri
            var komut = new MySqlCommand("select distinct arac from tanim_arac", _blg.bağlantı());
            komut.ExecuteNonQuery();
            var oku = komut.ExecuteReader();
            comboBoxEdit_aracArac.Properties.Items.Clear();
            comboBoxEdit_AracYil.Properties.Items.Clear();
            lbl_aracSeri.Text = "Seçim bekleniyor.";
            lbl_AracModel.Text = "Seçim bekleniyor.";

            while (oku.Read())
            {
                comboBoxEdit_aracArac.Properties.Items.Add(oku["arac"]);
            }

            comboBoxEdit_aracArac.Text = "Otomobil";
            oku.Close();

            // Lastik bilgilerini sayfa açılınca yüklenecek,
            // lastik marka ya tıklanınca diğer bilgiler de yüklenecek
            var komutLastik = new MySqlCommand("select distinct marka from tanim_lastik", _blg.bağlantı());
            komutLastik.ExecuteNonQuery();
            var okuLastik = komutLastik.ExecuteReader();

            while (okuLastik.Read())
            {
                var marka = okuLastik["marka"].ToString();
                if (marka == "") continue;
                comboBoxEdit_lastikMarka.Properties.Items.Add(marka);
            }
            okuLastik.Close();

        }


        private void comboBoxEdit_lastikMarka_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEdit_lastikJantcap.Enabled = true;
            comboBoxEdit_lastikTabanGenislik.Enabled = true;
            comboBoxEdit_lastikKesitOrani.Enabled = true;
            comboBoxEdit_lastikHizKodu.Enabled = true;
            comboBoxEdit_lastikYuzEndeks.Enabled = true;
            comboBoxEdit_lastikMevsim.Enabled = true;
            comboBoxEdit_lastikKonumBolum.Enabled = true;
            comboBoxEdit_lastikKonumKisim.Enabled = true;

            //lastik markaya tıklanınca diğer bilgiler geliyor...
            var komutLastik = new MySqlCommand("select distinct jantcap,tabangenislik,kesitorani,hizkodu,yuzendeks,mevsim from tanim_lastik", _blg.bağlantı());
            komutLastik.ExecuteNonQuery();
            var okuLastik = komutLastik.ExecuteReader();
            while (okuLastik.Read())
            {
                var jantcap = okuLastik["jantcap"].ToString();
                var tabangenislik = okuLastik["tabangenislik"].ToString();
                var kesitorani = okuLastik["kesitorani"].ToString();
                var hizkodu = okuLastik["hizkodu"].ToString();
                var yuzendeks = okuLastik["yuzendeks"].ToString();
                var mevsim = okuLastik["mevsim"].ToString();


                if (jantcap != "")
                {
                    comboBoxEdit_lastikJantcap.Properties.Items.Add(jantcap);

                }
                if (tabangenislik != "")
                {
                    comboBoxEdit_lastikTabanGenislik.Properties.Items.Add(tabangenislik);

                }
                if (kesitorani != "")
                {
                    comboBoxEdit_lastikKesitOrani.Properties.Items.Add(kesitorani);

                }
                if (hizkodu != "")
                {
                    comboBoxEdit_lastikHizKodu.Properties.Items.Add(hizkodu);

                }
                if (yuzendeks != "")
                {
                    comboBoxEdit_lastikYuzEndeks.Properties.Items.Add(yuzendeks);

                }
                if (mevsim != "")
                {
                    comboBoxEdit_lastikMevsim.Properties.Items.Add(mevsim);

                }
            }
            okuLastik.Close();
        }

        #endregion

        #endregion

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

        private void CmbModel()
        {
            //Araca göre bilgi gir
            var adp = new MySqlDataAdapter("select distinct *from tanim_arac", _blg.bağlantı());
            var ds = new DataTable();
            adp.Fill(ds);
            bindingSource1.DataSource = ds;
            bindingSource1.Filter = "arac ='" + comboBoxEdit_aracArac.Text + "'";
            searchLookUpEditAracMarka.Properties.DataSource = bindingSource1;
            searchLookUpEditAracMarka.Properties.DisplayMember = "marka";
            searchLookUpEditAracMarka.Properties.ValueMember = "marka";
        }

        private void comboBoxEdit_aracArac_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbModel();
        }

        private void btn_kaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //müşteri sayfasından mı? Servisden mi? Yeni müşteri mi yoksa düzenleme mi?
            if (btn_kaydet.Caption == "KAYDET")
            {
                if (neredenGelen == "yeni")
                {
                    if (_telefonKontrol != txt_telefon.Text)
                    {
                        //Müşteri Bilgileri
                        MySqlCommand komut = new MySqlCommand("insert into musteri(adsoyad,telefon,eposta,adres) values(@adsoyad,@telefon,@eposta,@adres)", _blg.bağlantı());
                        komut.Parameters.Clear();
                        komut.Parameters.AddWithValue("@adsoyad", txt_adsoyad.Text);
                        komut.Parameters.AddWithValue("@telefon", txt_telefon.Text);
                        komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
                        komut.Parameters.AddWithValue("@adres", txt_adres.Text);
                        komut.ExecuteNonQuery();

                        var frm = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
                        frm?.gridcontrolgöster();
                        
                        //Lastik bilgileri
                        MySqlCommand komutLastik = new MySqlCommand("insert into musteri_arac_lastik(musteriid,arac,marka,seri,model,plaka," +
                                                              "lastikmarka,jantcap,tabangenislik,kesitoran,yuzendeks,mevsim) " +
                                                              "values(@musteriid,@arac,@marka,@seri,@model,@plaka,@lastikmarka," +
                                                              "@jantcap,@tabangenislik,@kesitoran,@yuzendeks,@mevsim)", _blg.bağlantı());
                        komutLastik.Parameters.Clear();
                        komutLastik.Parameters.AddWithValue("@musteriid", musteriid);
                        komutLastik.Parameters.AddWithValue("@arac", comboBoxEdit_aracArac.EditValue.ToString());
                        komutLastik.Parameters.AddWithValue("@marka", searchLookUpEditAracMarka.Text);
                        komutLastik.Parameters.AddWithValue("@seri", lbl_aracSeri.Text);
                        komutLastik.Parameters.AddWithValue("@model", lbl_AracModel.Text);
                        komutLastik.Parameters.AddWithValue("@plaka", txt_aracPlaka.Text);
                        komutLastik.Parameters.AddWithValue("@lastikmarka", comboBoxEdit_lastikMarka.Text);
                        komutLastik.Parameters.AddWithValue("@jantcap", comboBoxEdit_lastikJantcap.Text);
                        komutLastik.Parameters.AddWithValue("@tabangenislik", comboBoxEdit_lastikTabanGenislik.Text);
                        komutLastik.Parameters.AddWithValue("@kesitoran", comboBoxEdit_lastikKesitOrani.Text);
                        komutLastik.Parameters.AddWithValue("@yuzendeks", comboBoxEdit_lastikYuzEndeks.Text);
                        komutLastik.Parameters.AddWithValue("@mevsim", comboBoxEdit_lastikMevsim.Text);
                        komutLastik.ExecuteNonQuery();

                        MessageBox.Show("" + txt_adsoyad.Text + " isimli müşteri " + Environment.NewLine + "başarıyla kaydedilmiştir.", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("" + txt_telefon.Text.Trim(new char[] { '(', ')' }) + " Bu numaraya sahip bir kayıt bulunmaktadır." + Environment.NewLine + "" + Environment.NewLine + " kayda devam edilemiyor!", "KAYIT BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                if (neredenGelen == "Servisden")
                {
                    
                }
            }

            if (btn_kaydet.Caption == "Güncelle")
            {
                
            }
        }
    }
}