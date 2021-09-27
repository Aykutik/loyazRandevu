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

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            if (btn_kaydet.Text=="GÜNCELLE")
            {

                var frm = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
                if (frm != null)
                    frm.gridcontrolgöster();

                MySqlCommand komut = new MySqlCommand("update musteriler set musteriadsoyad = @musteriadsoyad, iletisim = @iletisim, eposta=@eposta, adres = @adres where id = @id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", frm.lbl_id.Text);
                komut.Parameters.AddWithValue("@musteriadsoyad", txt_adsoyad.Text);
                komut.Parameters.AddWithValue("@iletisim", txt_iletişim.Text);
                komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
                komut.Parameters.AddWithValue("@adres", txt_adres.Text);
                komut.ExecuteNonQuery();

                var frm3 = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
                if (frm3 != null)
                    frm3.gridcontrolgöster();

                MessageBox.Show("" + txt_adsoyad.Text + " isimli müşteri " + Environment.NewLine + "başarıyla güncellenmiştir.", "GÜNCELLEME BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            if (btn_kaydet.Text=="Kaydet"&& neredenGelen=="yeni")
            {
                if (labelControl1.Text != txt_iletişim.Text)
                {

                    MySqlCommand komut = new MySqlCommand("insert into musteriler(musteriadsoyad,iletisim,eposta,adres) values(@musteriadsoyad,@iletisim,@eposta,@adres)", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@musteriadsoyad", txt_adsoyad.Text);
                    komut.Parameters.AddWithValue("@iletisim", txt_iletişim.Text);
                    komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
                    komut.Parameters.AddWithValue("@adres", txt_adres.Text);
                    
                    komut.ExecuteNonQuery();
                    

                    var frm = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
                    if (frm != null)
                        frm.gridcontrolgöster();

                    var frm_yeni3 = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
                    if (frm_yeni3 != null)
                        frm_yeni3.gridcontrolgöster();

                    MessageBox.Show("" + txt_adsoyad.Text + " isimli müşteri " + Environment.NewLine + "başarıyla kaydedilmiştir.", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("" + txt_iletişim.Text.Trim(new char[] { '(', ')' }) + " Bu numaraya sahip bir kayıt bulunmaktadır." + Environment.NewLine + "" + Environment.NewLine + " kayda devam edilemiyor!", "KAYIT BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (btn_kaydet.Text == "Kaydet" && neredenGelen == "servisden")
            {
                if (labelControl1.Text != txt_iletişim.Text)
                {
                    string musteriIdAktar = "";
                    MySqlCommand komut = new MySqlCommand("insert into musteriler(musteriadsoyad,iletisim,eposta,adres) values(@musteriadsoyad,@iletisim,@eposta,@adres)", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@musteriadsoyad", txt_adsoyad.Text);
                    komut.Parameters.AddWithValue("@iletisim", txt_iletişim.Text);
                    komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
                    komut.Parameters.AddWithValue("@adres", txt_adres.Text);
                    komut.ExecuteNonQuery();

                    //kaydedilenin müşterinin id sini öğren
                    MySqlCommand servisno = new MySqlCommand("select *from musteriler where musteriadsoyad=@musteriadsoyad and iletisim=@iletisim", blg.bağlantı());
                    servisno.Parameters.Clear();
                    servisno.Parameters.AddWithValue("@musteriadsoyad", txt_adsoyad.Text.Trim());
                    servisno.Parameters.AddWithValue("@iletisim", txt_iletişim.Text.Trim());
                    servisno.ExecuteNonQuery();
                    MySqlDataReader oku = servisno.ExecuteReader();
                    while (oku.Read())
                    {
                        musteriIdAktar = oku["id"].ToString();
                    }

                    frm_ts_yeniservis_frm yeni = (frm_ts_yeniservis_frm)Application.OpenForms["frm_ts_yeniservis_frm"];
                    yeni.txt_müşteriadsoyad.Properties.NullValuePrompt = txt_adsoyad.Text;
                    yeni.adsoyadBilgi = "yeni oluşturuldu";
                    yeni.yeniMusteriId = musteriIdAktar;

                    var frm_yeni = (frm_ts_yeniservis_frm)Application.OpenForms["frm_ts_yeniservis_frm"];
                    if (frm_yeni != null)
                    frm_yeni.gridcontrolgöster();


                    var frm_yeni3 = (frm_ms_anasayfa_panel)Application.OpenForms["frm_ms_anasayfa_panel"];
                    if (frm_yeni3 != null)
                        frm_yeni3.gridcontrolgöster();


                    MessageBox.Show("" + txt_adsoyad.Text + " isimli müşteri " + Environment.NewLine + "başarıyla kaydedilmiştir.", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("" + txt_iletişim.Text.Trim(new char[] { '(', ')' }) + " Bu numaraya sahip bir kayıt bulunmaktadır." + Environment.NewLine + "" + Environment.NewLine + " kayda devam edilemiyor!", "KAYIT BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            splashScreenManager2.CloseWaitForm();
        }

        private void txt_iletişim_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txt_iletişim_Leave(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("select *from musteriler where iletisim=@tel",blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@tel", txt_iletişim.Text.ToString().Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                labelControl1.Text = oku["iletisim"].ToString();
            }

            if (labelControl1.Text == txt_iletişim.Text)
            {
                MessageBox.Show("Bu kayıttan var!");
            }
        }
    }
}