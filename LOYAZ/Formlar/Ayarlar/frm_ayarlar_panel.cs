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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;

namespace LOYAZ
{
    public partial class frm_ayarlar_panel : DevExpress.XtraEditors.XtraForm
    {
        public frm_ayarlar_panel()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void btn_anasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void frm_ayarlar_panel_Load(object sender, EventArgs e)
        {

            splashScreenManager1.ShowWaitForm();

            gridControl_teknik();
            gridControl_müşteri();
            gridControl_kullanıcılar_duzenle();
            gridControl_kullanıcılar_yetki();
            firmabilgilerinigetir();
            kul_düzey();
            erişimleribelirle();

            panelControl1.Visible = blg.visabledurumu();
            grp_debug_kullanıcılar.Visible = blg.visabledurumu();

            splashScreenManager1.CloseWaitForm();
        }

        #region GritController
        private void gridControl_teknik()
        {
            MySqlCommand cmd = new MySqlCommand("select ad,ts_erisim,ts_servisac,ts_servisgüncelle,ts_servisduzenle,ts_servisikapat," +
                "ts_servissil,ts_silinenservislerigör,ts_silinenservisigerial,ts_raporoluştur,ts_servisformuyükle,ts_kulyetkiayar,ts_ayar from kul_kullanicig_yetkiler", blg.bağlantı());
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Load(dr);
            gridControl_ts.DataSource = dt;
        }

        private void gridControl_müşteri()
        {
            MySqlCommand cmd = new MySqlCommand("select ad,ms_erisim,ms_yenimusteri,ms_mus_duzenle,ms_mus_sil,ms_rapor_olustur,ms_kulyetkiayar,ms_ayar from kul_kullanicig_yetkiler", blg.bağlantı());
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Load(dr);
            gridControl_ms.DataSource = dt;
        }

        private void gridControl_kullanıcılar_duzenle()
        {
            MySqlCommand cmd = new MySqlCommand("select avatar,ad,eposta,parola,yetki,id from kul_kullanicilar", blg.bağlantı());
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Load(dr);
            gridControl_kullanıcılar.DataSource = dt;

            MySqlCommand komut = new MySqlCommand("select *from kul_kullanicig_yetkiler", blg.bağlantı());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                cmb_kul_grupları.Properties.Items.Add(read["ad"]);
            }

        }

        private void gridControl_kullanıcılar_yetki()
        {
            MySqlCommand cmd = new MySqlCommand("select ad,kul_erisim,kul_kulekle,kul_kulduzenle,kul_kulsil,kul_ayar from kul_kullanicig_yetkiler", blg.bağlantı());
            MySqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Load(dr);
            gridControl_kul_kul_yetki.DataSource = dt;
        }
         
        #endregion

        #region Yetki
        private void kul_düzey()
        {
            string kul_id = "";

            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            kul_id = frm.lbl_kul_id.Text;

            MySqlCommand komut = new MySqlCommand("select *from kul_kullanicilar where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", kul_id);
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lbl_kul_düzeyi.Text = oku["yetki"].ToString();
            }
        }
                
        private void erişimleribelirle()
        {
            MySqlCommand komut2 = new MySqlCommand("select *from kul_kullanicig_yetkiler where ad=@id", blg.bağlantı());
            komut2.Parameters.Clear();
            komut2.Parameters.AddWithValue("@id", lbl_kul_düzeyi.Text);
            komut2.ExecuteNonQuery();
            MySqlDataReader oku2 = komut2.ExecuteReader();
            if (oku2.Read())
            {
                lbl_kul_ts_ayar.Text = oku2["ts_ayar"].ToString();
                lbl_kul_ts_kulyetki.Text = oku2["ts_kulyetkiayar"].ToString();


                lbl_kul_ms_ayar.Text = oku2["ms_ayar"].ToString();
                lbl_kul_ms_kulyetki.Text = oku2["ms_kulyetkiayar"].ToString();


                lbl_kul_kul_ayar.Text = oku2["kul_ayar"].ToString();
                lbl_kul_kulekle.Text = oku2["kul_kulekle"].ToString();
                lbl_kul_kulduzenle.Text = oku2["kul_kulduzenle"].ToString();
                lbl_kul_kulsil.Text = oku2["kul_kulsil"].ToString();
            }

            // ERİŞİMLERİ BELİRT
            navigationPage_kul.PageVisible = Convert.ToBoolean(lbl_kul_kul_ayar.Text);
            grpcntrl_kul_yeni.Enabled = Convert.ToBoolean(lbl_kul_kulekle.Text);

            navigationPage_ts.PageVisible = Convert.ToBoolean(lbl_kul_ts_ayar.Text);
            TabPage_ts_kul_yet.PageVisible = Convert.ToBoolean(lbl_kul_ts_kulyetki.Text);

            navigationPage_ms.PageVisible = Convert.ToBoolean(lbl_kul_ms_ayar.Text);
            TabPage_ms_kul_yet.PageVisible = Convert.ToBoolean(lbl_kul_ms_kulyetki.Text);
            
            //...

        }

        #endregion

        #region TeknikServis

        private void ts_ayarlar()
        {
            MySqlCommand komut = new MySqlCommand("select *from ayarlar where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                radioGroup1.EditValue = Convert.ToInt32(oku["raporstili"].ToString());
                tog_yeniservisdensonra.EditValue = oku["yen_ser_rapor"].ToString();
                tog_ayar_ser_barcod.EditValue = oku["yen_ser_barcod"].ToString();
                txt_unutuyarı.Text = oku["unutuyarı"].ToString();
            }
            oku.Close();
        }

        #endregion


        
        private void firmabilgilerinigetir()
        {
            string pic_logoyol = "";

            MySqlCommand komut_firmad = new MySqlCommand("select *from firma where id=@id", blg.bağlantı());
            komut_firmad.Parameters.Clear();
            komut_firmad.Parameters.AddWithValue("@id", 1);
            komut_firmad.ExecuteNonQuery();
            MySqlDataReader oku_firmaad = komut_firmad.ExecuteReader();
            while (oku_firmaad.Read())
            {
                txt_firmaadı.Text = oku_firmaad["firmadad"].ToString();
                txt_adres.Text = oku_firmaad["adres"].ToString();
                txt_sabit_tel.Text = oku_firmaad["sabittel"].ToString();
                txt_tel.Text = oku_firmaad["tel"].ToString();
                txt_web.Text = oku_firmaad["web"].ToString();
                txt_eposta.Text = oku_firmaad["eposta"].ToString();
                txt_marka.Text = oku_firmaad["marka"].ToString();
                pic_logoyol = oku_firmaad["logoyol"].ToString();
            }

            try
            {
                pictureEdit3.Image = Image.FromFile(pic_logoyol);
            }
            catch (Exception)
            {
                return;
            }
        }

        
        private void raporstilikaydet()
        {
            MySqlCommand komut = new MySqlCommand("update ayarlar set raporstili=@raporstili where id=@id", blg.bağlantı());
            komut.Parameters.AddWithValue("@raporstili", Convert.ToUInt32(radioGroup1.EditValue));
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
        }

        private void ayar_ser_rapor()
        {
            string yen_ser_rapor = "2";

            if (tog_yeniservisdensonra.EditValue.ToString() == "0")
            {
                yen_ser_rapor = "0";
            }
            if (tog_yeniservisdensonra.EditValue.ToString() == "1")
            {
                yen_ser_rapor = "1";
            }

            splashScreenManager2.ShowWaitForm();
            MySqlCommand komut = new MySqlCommand("update ayarlar set raporstili=@raporstili, yen_ser_rapor=@yen_ser_rapor where id=@id", blg.bağlantı());
            komut.Parameters.AddWithValue("@raporstili", Convert.ToUInt32(radioGroup1.EditValue));
            komut.Parameters.AddWithValue("@yen_ser_rapor", yen_ser_rapor);
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            splashScreenManager2.CloseWaitForm();
        }

        private void ayar_ser_barkod()
        {
            string yen_ser_barcod = "2";

            if (tog_ayar_ser_barcod.EditValue.ToString() == "0")
            {
                yen_ser_barcod = "0";
            }
            if (tog_ayar_ser_barcod.EditValue.ToString() == "1")
            {
                yen_ser_barcod = "1";
            }
            splashScreenManager2.ShowWaitForm();
            MySqlCommand komut = new MySqlCommand("update ayarlar set yen_ser_barcod=@yen_ser_barcod where id=@id", blg.bağlantı());
            komut.Parameters.AddWithValue("@yen_ser_barcod", yen_ser_barcod);
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            splashScreenManager2.CloseWaitForm();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            raporstilikaydet(); 
        }

        private void tog_yeniservisdensonra_Toggled(object sender, EventArgs e)
        {            
            ayar_ser_rapor();    
        }

        private void tog_ayar_ser_barcod_Toggled(object sender, EventArgs e)
        {            
            ayar_ser_barkod();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            MySqlCommand komut = new MySqlCommand("update firma set firmadad=@firmadad, adres=@adres, marka=@marka, sabittel=@sabittel, tel=@tel, eposta=@eposta, web=@web where id=@id", blg.bağlantı());
            komut.Parameters.AddWithValue("@id", 1);
            komut.Parameters.AddWithValue("@firmadad", txt_firmaadı.Text);
            komut.Parameters.AddWithValue("@adres", txt_adres.Text);
            komut.Parameters.AddWithValue("@marka", txt_marka.Text);
            komut.Parameters.AddWithValue("@sabittel", txt_sabit_tel.Text);
            komut.Parameters.AddWithValue("@tel", txt_tel.Text);
            komut.Parameters.AddWithValue("@eposta", txt_eposta.Text);
            komut.Parameters.AddWithValue("@web", txt_web.Text);
            komut.ExecuteNonQuery();
            splashScreenManager2.CloseWaitForm();
        }

        private void btn_logoyükle_Click(object sender, EventArgs e)
        {
            string görselyolu = "";
            string yol = "" + Application.StartupPath + @"\reg" + "\\logo.jpg";

            using (OpenFileDialog ofg = new OpenFileDialog() { Filter = "JPG|*.jpg" })

                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    pictureEdit3.Image = Image.FromFile(ofg.FileName);
                    görselyolu = ofg.FileName;
                }
            splashScreenManager_görselyükle.ShowWaitForm();
            try
            {
                if (File.Exists(yol))
                {
                    System.IO.File.Delete(yol);
                    File.Delete(yol);
                }
            }
            catch (Exception)
            {
                
            }

            try
            {
                File.Copy(görselyolu, yol, true);
            }
            catch (Exception)
            {
                
            }

            MySqlCommand komut_güncelle = new MySqlCommand("update firma set logoyol=@yol where id=@id", blg.bağlantı());
            komut_güncelle.Parameters.AddWithValue("@yol", yol);
            komut_güncelle.Parameters.AddWithValue("@id", 1);
            komut_güncelle.ExecuteNonQuery();
            splashScreenManager_görselyükle.CloseWaitForm();
        }



        #region Müşteriler
        private void gridView_ms_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void btn_müş_yet_kaydet_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            for (int i = 0; i < gridView_ms.RowCount; i++)
            {
                MySqlCommand komut = new MySqlCommand("update kul_kullanicig_yetkiler set " +
                    "ms_erisim=@ms_erisim, ms_yenimusteri=@ms_yenimusteri, ms_mus_duzenle=@ms_mus_duzenle, ms_mus_sil=@ms_mus_sil, ms_rapor_olustur=@ms_rapor_olustur, ms_kulyetkiayar=@ms_kulyetkiayar, ms_ayar=@ms_ayar " +
                    "where ad=@ad", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", gridView_ms.GetRowCellValue(i, "ad").ToString().Trim());
                komut.Parameters.AddWithValue("@ms_erisim", gridView_ms.GetRowCellValue(i, "ms_erisim").ToString().Trim());
                komut.Parameters.AddWithValue("@ms_yenimusteri", gridView_ms.GetRowCellValue(i, "ms_yenimusteri").ToString().Trim());
                komut.Parameters.AddWithValue("@ms_mus_duzenle", gridView_ms.GetRowCellValue(i, "ms_mus_duzenle").ToString().Trim());
                komut.Parameters.AddWithValue("@ms_mus_sil", gridView_ms.GetRowCellValue(i, "ms_mus_sil").ToString().Trim());
                komut.Parameters.AddWithValue("@ms_rapor_olustur", gridView_ms.GetRowCellValue(i, "ms_rapor_olustur").ToString().Trim());
                komut.Parameters.AddWithValue("@ms_kulyetkiayar", gridView_ms.GetRowCellValue(i, "ms_kulyetkiayar").ToString().Trim());
                komut.Parameters.AddWithValue("@ms_ayar", gridView_ms.GetRowCellValue(i, "ms_ayar").ToString().Trim());
                komut.ExecuteNonQuery();
            }
            splashScreenManager2.CloseWaitForm();
        }
        #endregion


        private void navigationPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (navigationPane1.SelectedPage == navigationPage_ts)
            {
                splashScreenManager1.ShowWaitForm();
                ts_ayarlar();
                splashScreenManager1.CloseWaitForm();
            }
        }
        #region Kullanıcılar

        private void btn_kullanıcı_yet_kaydet_Click(object sender, EventArgs e)
        {           
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                MySqlCommand komut = new MySqlCommand("update kul_kullanicig_yetkiler set " +
                    "ts_erisim=@ts_erisim, ts_servisac=@ts_servisac, ts_servisgüncelle=@ts_servisgüncelle, ts_servissil=@ts_servissil," +
                    " ts_servisduzenle=@ts_servisduzenle, ts_servisikapat=@ts_servisikapat, ts_silinenservislerigör=@ts_silinenservislerigör, ts_silinenservisigerial=@ts_silinenservisigerial, " +
                    "ts_raporoluştur=@ts_raporoluştur, ts_servisformuyükle=@ts_servisformuyükle,ts_kulyetkiayar=@ts_kulyetkiayar, ts_ayar=@ts_ayar " +
                    "where ad=@ad", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", gridView1.GetRowCellValue(i, "ad").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_erisim", gridView1.GetRowCellValue(i, "ts_erisim").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_servisac", gridView1.GetRowCellValue(i, "ts_servisac").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_servisgüncelle", gridView1.GetRowCellValue(i, "ts_servisgüncelle").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_servisduzenle", gridView1.GetRowCellValue(i, "ts_servisduzenle").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_servisikapat", gridView1.GetRowCellValue(i, "ts_servisikapat").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_servissil", gridView1.GetRowCellValue(i, "ts_servissil").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_silinenservislerigör", gridView1.GetRowCellValue(i, "ts_silinenservislerigör").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_silinenservisigerial", gridView1.GetRowCellValue(i, "ts_silinenservisigerial").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_raporoluştur", gridView1.GetRowCellValue(i, "ts_raporoluştur").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_servisformuyükle", gridView1.GetRowCellValue(i, "ts_servisformuyükle").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_kulyetkiayar", gridView1.GetRowCellValue(i, "ts_kulyetkiayar").ToString().Trim());
                komut.Parameters.AddWithValue("@ts_ayar", gridView1.GetRowCellValue(i, "ts_ayar").ToString().Trim());
                komut.ExecuteNonQuery();
            }           
        }

        private void btn_kullanıcılar_kayder_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            for (int i = 0; i < gridView_kul.RowCount; i++)
            {
                MySqlCommand komut = new MySqlCommand("update kul_kullanicilar set " +
                "ad=@ad, eposta=@eposta,  yetki=@yetki, parola=@parola " +
                "where id=@id", blg.bağlantı());
                komut.Parameters.AddWithValue("@id", gridView_kul.GetRowCellValue(i, "id").ToString().Trim());
                komut.Parameters.AddWithValue("@ad", gridView_kul.GetRowCellValue(i, "ad").ToString().Trim());
                komut.Parameters.AddWithValue("@eposta", gridView_kul.GetRowCellValue(i, "eposta").ToString().Trim());
                komut.Parameters.AddWithValue("@parola", gridView_kul.GetRowCellValue(i, "parola").ToString().Trim());
                komut.Parameters.AddWithValue("@yetki", gridView_kul.GetRowCellValue(i, "yetki").ToString().Trim());

                komut.ExecuteNonQuery();
            }
            splashScreenManager2.CloseWaitForm();
        }

        private void btn_kaydet_kul_kulyetki_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            for (int i = 0; i < gridView_kul_yet.RowCount; i++)
            {
                MySqlCommand komut = new MySqlCommand("update kul_kullanicig_yetkiler set " +
                "ad=@ad, kul_erisim=@kul_erisim, kul_kulekle=@kul_kulekle, kul_kulduzenle=@kul_kulduzenle, kul_kulsil=@kul_kulsil, kul_ayar=@kul_ayar " +
                "where ad=@ad", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", gridView_kul_yet.GetRowCellValue(i, "ad").ToString().Trim());
                komut.Parameters.AddWithValue("@kul_erisim", gridView_kul_yet.GetRowCellValue(i, "kul_erisim").ToString().Trim());
                komut.Parameters.AddWithValue("@kul_kulekle", gridView_kul_yet.GetRowCellValue(i, "kul_kulekle").ToString().Trim());
                komut.Parameters.AddWithValue("@kul_kulduzenle", gridView_kul_yet.GetRowCellValue(i, "kul_kulduzenle").ToString().Trim());
                komut.Parameters.AddWithValue("@kul_kulsil", gridView_kul_yet.GetRowCellValue(i, "kul_kulsil").ToString().Trim());
                komut.Parameters.AddWithValue("@kul_ayar", gridView_kul_yet.GetRowCellValue(i, "kul_ayar").ToString().Trim());
                komut.ExecuteNonQuery();
            }
            splashScreenManager2.CloseWaitForm();
        }

        private void btn_kul_kaydet_Click(object sender, EventArgs e)
        {
            if (lbl_kul_id.Text == "id") //yeni
            {
                MySqlCommand komut = new MySqlCommand("insert into kul_kullanicilar(ad,parola,eposta) values(@ad,@parola,@eposta)", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@ad", txt_kul_adsoyad.Text);
                komut.Parameters.AddWithValue("@parola", txt_kul_parola.Text);
                komut.Parameters.AddWithValue("@eposta", txt_kul_eposta.Text);
                komut.ExecuteNonQuery();

                string kul_id = "";


                //yeni id öğren
                MySqlCommand komut_id = new MySqlCommand("select *from kul_kullanicilar where eposta=@eposta and parola=@parola", blg.bağlantı());
                komut_id.Parameters.Clear();
                komut_id.Parameters.AddWithValue("@eposta", txt_kul_eposta.Text.Trim());
                komut_id.Parameters.AddWithValue("@parola", txt_kul_parola.Text.Trim());
                komut_id.ExecuteNonQuery();
                MySqlDataReader oku_id = komut_id.ExecuteReader();
                while (oku_id.Read())
                {
                    lbl_kul_id.Text = oku_id["id"].ToString();
                }

                //...
                string pic_fotoyol = "" + Application.StartupPath + @"\reg\kul_foto" + "\\" + lbl_kul_id.Text + ".jpg";

                //foto kaydetme
                MySqlCommand komut_foto = new MySqlCommand("update kul_kullanicilar set avatar=@avatar where id=@id", blg.bağlantı());
                komut_foto.Parameters.Clear();
                komut_foto.Parameters.AddWithValue("@id", lbl_kul_id.Text);
                komut_foto.Parameters.AddWithValue("@avatar", pic_fotoyol);
                komut_foto.ExecuteNonQuery();

                File.Copy(lbl_kul_avatar_yükle_yol.Text, pic_fotoyol, true);
                lbl_kul_id.Text = "id";
                //...
            }
            else //düzenleme
            {
                string pic_fotoyol = "" + Application.StartupPath + @"\reg\kul_foto" + "\\" + lbl_kul_id.Text + ".jpg";

                //foto kaydetme
                MySqlCommand komut_foto = new MySqlCommand("update kul_kullanicilar set avatar=@avatar, ad=@ad, parola=@parola, eposta=@eposta where id=@id", blg.bağlantı());
                komut_foto.Parameters.Clear();
                komut_foto.Parameters.AddWithValue("@id", lbl_kul_id.Text);
                komut_foto.Parameters.AddWithValue("@avatar", pic_fotoyol);
                komut_foto.Parameters.AddWithValue("@ad", txt_kul_adsoyad.Text);
                komut_foto.Parameters.AddWithValue("@parola", txt_kul_parola.Text);
                komut_foto.Parameters.AddWithValue("@eposta", txt_kul_eposta.Text);
                komut_foto.ExecuteNonQuery();

                File.Copy(lbl_kul_avatar_yükle_yol.Text, pic_fotoyol, true);
                lbl_kul_id.Text = "id";
            }
        }

        private void btn_kul_gözat_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofg = new OpenFileDialog() { Filter = "JPG|*.jpg" })
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    pic_kul_avatar.Image = Image.FromFile(ofg.FileName);
                    lbl_kul_avatar_yükle_yol.Text = ofg.FileName;
                }
        }
        #endregion

        private void gridView_kul_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
 
        }

        private void gridView_kul_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            for (int i = 0; i < gridView_kul.RowCount; i++)
            {
                MySqlCommand komut = new MySqlCommand("update kul_kullanicilar set " +
                "ad=@ad, eposta=@eposta,  yetki=@yetki, parola=@parola " +
                "where id=@id", blg.bağlantı());
                komut.Parameters.AddWithValue("@id", gridView_kul.GetRowCellValue(i, "id").ToString().Trim());
                komut.Parameters.AddWithValue("@ad", gridView_kul.GetRowCellValue(i, "ad").ToString().Trim());
                komut.Parameters.AddWithValue("@eposta", gridView_kul.GetRowCellValue(i, "eposta").ToString().Trim());
                komut.Parameters.AddWithValue("@parola", gridView_kul.GetRowCellValue(i, "parola").ToString().Trim());
                komut.Parameters.AddWithValue("@yetki", gridView_kul.GetRowCellValue(i, "yetki").ToString().Trim());

                komut.ExecuteNonQuery();
            }
            splashScreenManager2.CloseWaitForm();
        }

        private void btn_diğer_kaydet_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("update ayarlar set " +
            "unutuyarı=@unutuyarı where id=@id", blg.bağlantı());
            komut.Parameters.AddWithValue("@id", 1);
            komut.Parameters.AddWithValue("@unutuyarı", txt_unutuyarı.Text);
            komut.ExecuteNonQuery();
        }
    }
}