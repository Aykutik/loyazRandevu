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
using System.IO;

namespace LOYAZ.Formlar.Ayarlar.KullanıcıHesapları
{
    public partial class pnl_kul_yeni : DevExpress.XtraEditors.XtraForm
    {
        public pnl_kul_yeni()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void btn_anasayfa_Click(object sender, EventArgs e)
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

        private void frm_kul_yeni_Load(object sender, EventArgs e)
        {

            lbl_uyarı.Text = "";
            lbl_uyarı_eposta_tel.Text = "";

            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            lbl_kul_id.Text  = frm.lbl_kul_id.Text;

            try
            {
                string pic_fotoyol = "" + Application.StartupPath + @"\reg\kul_foto" + "\\" + lbl_kul_id.Text + ".jpg";
                pictureEdit1.Image = Image.FromFile(pic_fotoyol);
            }
            catch (Exception)
            {

             
            }

            MySqlCommand komut2 = new MySqlCommand("select *from kul_kullanicilar where id=@id", blg.bağlantı());
            komut2.Parameters.Clear();
            komut2.Parameters.AddWithValue("@id", lbl_kul_id.Text);
            komut2.ExecuteNonQuery();
            MySqlDataReader oku2 = komut2.ExecuteReader();
            if (oku2.Read())
            {
                lbl_adsoyad.Text = oku2["ad"].ToString();
                txt_eposta.Text = oku2["eposta"].ToString();
                txt_telno.Text = oku2["telno"].ToString();
            }
            lbl_zaman.Text = "şimdi";
        }

        private void btn_kaydet_gözat_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofg = new OpenFileDialog() { Filter = "JPG|*.jpg" })
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    pictureEdit1.Image = Image.FromFile(ofg.FileName);
                    lbl_kul_avatar_yükle_yol.Text = ofg.FileName;
                    btn_kaydet_foto.Enabled = true;
                }
        }

        private void btn_kaydet_foto_Click(object sender, EventArgs e)
        {
            //...
            string pic_fotoyol = "" + Application.StartupPath + @"\reg\kul_foto" + "\\" + lbl_kul_id.Text + ".jpg";

            //foto kaydetme
            MySqlCommand komut_foto = new MySqlCommand("update kul_kullanicilar set avatar=@avatar where id=@id", blg.bağlantı());
            komut_foto.Parameters.Clear();
            komut_foto.Parameters.AddWithValue("@id", lbl_kul_id.Text);
            komut_foto.Parameters.AddWithValue("@avatar", pic_fotoyol);
            komut_foto.ExecuteNonQuery();

            File.Copy(lbl_kul_avatar_yükle_yol.Text, pic_fotoyol, true);
            //...
        }

        private void txt_eposta_EditValueChanged(object sender, EventArgs e)
        {
            if (lbl_zaman.Text == "şimdi")
            {
                btn_kaydet_eposta_tel.Enabled = true;
            }
        }

        private void txt_telno_EditValueChanged(object sender, EventArgs e)
        {
            if (lbl_zaman.Text == "şimdi")
            {
                btn_kaydet_eposta_tel.Enabled = true;
            }
        }

        private void txt_yeni_parola_tekrar_Leave(object sender, EventArgs e)
        {
            if (txt_yeni_parola.Text == txt_yeni_parola_tekrar.Text)
            {
                btn_kaydet.Enabled = true;
                lbl_uyarı.Text = "";
            }
            else
            {
                btn_kaydet.Enabled = false;
                lbl_uyarı.Visible = true;
                lbl_uyarı.ForeColor = Color.Red;
                lbl_uyarı.Text = "Parolalar eşleşmiyor!";
            }
        }

        private void txt_yeni_parola_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_yeni_parola_tekrar.Text!="")
            {
                if (txt_yeni_parola.Text == txt_yeni_parola_tekrar.Text)
                {
                    btn_kaydet.Enabled = true;
                    lbl_uyarı.Text = "";
                }
                else
                {
                    btn_kaydet.Enabled = false;
                    lbl_uyarı.Visible = true;
                    lbl_uyarı.ForeColor = Color.Red;
                    lbl_uyarı.Text = "Parolalar eşleşmiyor!";
                }
            }
        }

        int sayaç = 0;

        private void btn_kaydet_eposta_tel_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand komut_foto = new MySqlCommand("update kul_kullanicilar set telno=@telno, eposta=@eposta where id=@id", blg.bağlantı());
                komut_foto.Parameters.Clear();
                komut_foto.Parameters.AddWithValue("@id", lbl_kul_id.Text);
                komut_foto.Parameters.AddWithValue("@eposta", txt_eposta.Text);
                komut_foto.Parameters.AddWithValue("@telno", txt_telno.Text);
                komut_foto.ExecuteNonQuery();

                lbl_uyarı_eposta_tel.ForeColor = Color.Green;
                lbl_uyarı_eposta_tel.Text = "Değişiklikler başarıyla kaydedildi.";
                btn_kaydet_eposta_tel.Enabled = false;
                timer1.Start();
            }
            catch (Exception)
            {
                lbl_uyarı_eposta_tel.ForeColor = Color.Red;
                lbl_uyarı_eposta_tel.Text = "Bağlantıda bir hatayla karşılaşıldı lütfen tekrar deneyiniz.";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_uyarı_eposta_tel.Text = "";
            timer1.Stop();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_yeni_parola_tekrar.Text == txt_yeni_parola.Text)
                {
                    MySqlCommand komut_foto = new MySqlCommand("update kul_kullanicilar set parola=@parola where id=@id", blg.bağlantı());
                    komut_foto.Parameters.Clear();
                    komut_foto.Parameters.AddWithValue("@id", lbl_kul_id.Text);
                    komut_foto.Parameters.AddWithValue("@parola", txt_yeni_parola_tekrar.Text);
                    komut_foto.ExecuteNonQuery();

                    lbl_uyarı.ForeColor = Color.Green;
                    lbl_uyarı.Text = "Parola değişimi başarıyla gerçekleşti";
                }
                else
                {
                    lbl_uyarı.ForeColor = Color.Red;
                    lbl_uyarı.Text = "Parolalar eşleşmiyor!";
                }
            }
            catch (Exception)
            {
                lbl_uyarı.ForeColor = Color.Red;
                lbl_uyarı.Text = "Bağlantıda bir hatayla karşılaşıldı lütfen tekrar deneyiniz.";
            }
        }
    }
}

