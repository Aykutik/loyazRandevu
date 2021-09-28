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
using MySql.Data;
using System.Data.SqlClient;

namespace LOYAZ
{
    public partial class frm_ms_anasayfa_panel : DevExpress.XtraEditors.XtraForm
    {
        public frm_ms_anasayfa_panel()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void panel_müşteriler_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            kul_yet_getir();
            ayarlar();
            gridcontrolgöster();
            splashScreenManager1.CloseWaitForm();
            dt_ödemetarihi.EditValue = blg.tarih();
            dönemGetir();
            tanım_ödemeYöntemiData();
        }

        public string dönem = "";
        public string Stringyıl = "";
        public int yıl = 0;

        private void dönemGetir()
        {
            dönem = "" + blg.tarih().ToString("yyyy") + "/" + blg.tarih().ToString("MM") + "";
            Stringyıl = blg.tarih().ToString("yyyy");
            yıl = Convert.ToInt32(Stringyıl);
        }

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

        private void ayarlar()
        {
            if (lbl_kul_müş_düzenle.Text == "False" && lbl_kul_müşterisil.Text == "False" && lbl_kul_yeni_müş.Text == "False")
            {
                ribbonPageGroup_kişimenüsü.Visible = false;
                sağ_btn_müş_düzenle.Enabled = false;
                sağ_btn_müş_sil.Enabled = false;
            }
            else
            {
                btn_düzenle.Enabled = Convert.ToBoolean(lbl_kul_müş_düzenle.Text);
                btn_müş_sil.Enabled = Convert.ToBoolean(lbl_kul_müşterisil.Text);
                btn_yenimüşteri.Enabled = Convert.ToBoolean(lbl_kul_yeni_müş.Text);
                //sağtık
                sağ_btn_müş_düzenle.Enabled = true;
                sağ_btn_müş_sil.Enabled = true;
                //...
            }

            btn_müş_raporol.Enabled = Convert.ToBoolean(lbl_kul_raporoluştur.Text);
            panelControl1.Visible = blg.visabledurumu();
        }

        private void kul_yet_getir()
        {
            string kul_id = "";
            string kul_düzeyi = "";

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
                lbl_kul_yeni_müş.Text = oku2["ms_yenimusteri"].ToString();
                lbl_kul_müş_düzenle.Text = oku2["ms_mus_duzenle"].ToString();
                lbl_kul_müşterisil.Text = oku2["ms_mus_sil"].ToString();
                lbl_kul_raporoluştur.Text = oku2["ms_rapor_olustur"].ToString();
            }
        }

        public void gridcontrolgöster()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from musteri", blg.bağlantı());
            DataSet ds = new DataSet();
            adp.Fill(ds);
            gridControl_müşterilistesi.DataSource = ds.Tables[0];
        }
        public void gridcontrolgöster_cari()
        {
            //MySqlDataAdapter adp = new MySqlDataAdapter("select *from car_hareketler", blg.bağlantı());
            //DataTable ds = new DataTable();
            //adp.Fill(ds);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = ds;
            //bs.Filter = "müşteri='"+lbl_id.Text+"'";
            //gridControl_müş_cari.DataSource = bs;
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                lbl_id.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            }
            catch (Exception)
            {
                lbl_id.Text = "";
            }
        }

        private void müşteriyisil()
        {
            splashScreenManager1.ShowWaitForm();
            MySqlCommand komut = new MySqlCommand("select *from musteriler where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", lbl_id.Text.ToString().Trim());

            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lbl_isim.Text = oku["musteriadsoyad"].ToString();
            }

            DialogResult durum = MessageBox.Show("" + lbl_isim.Text + " adlı müşteriyi silmek istediğinizden emin misiniz?", "" + lbl_isim.Text + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == durum)
            {
                string sorgu = "DELETE from musteriler where id=@id";
                MySqlCommand Komut = new MySqlCommand(sorgu, blg.bağlantı());
                Komut.Parameters.AddWithValue("@id", lbl_id.Text.ToString().Trim());
                Komut.ExecuteNonQuery();
                gridcontrolgöster();
            }
            else
            {

            }
            splashScreenManager1.CloseWaitForm();
        }

        private void müşteriyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            müşteriyisil();
        }

        private void müşteridüzenle()
        {
            //frm_ms_yenimüşteri_frm frm = new frm_ms_yenimüşteri_frm();
            //frm.Show();
            //splashScreenManager1.ShowWaitForm();
            //var frm2 = (frm_ms_yenimüşteri_frm)Application.OpenForms["frm_ms_yenimüşteri_frm"];
            //if (frm2 != null)
            //    frm2.Text = "DÜZENLE";
            //    frm2.btn_kaydet.Text = "GÜNCELLE";

            //MySqlCommand komut = new MySqlCommand("select *from musteriler where id=@id", blg.bağlantı());
            //komut.Parameters.Clear();
            //komut.Parameters.AddWithValue("@id", lbl_id.Text.ToString().Trim());
            //komut.ExecuteNonQuery();
            //MySqlDataReader oku = komut.ExecuteReader();
            //while (oku.Read())
            //{
            //    frm.txt_adsoyad.Text = oku["musteriadsoyad"].ToString();
            //    frm.txt_eposta.Text = oku["eposta"].ToString();
            //    frm.txt_iletişim.Text = oku["iletisim"].ToString();
            //    frm.txt_adres.Text = oku["adres"].ToString();
            //}
            //splashScreenManager1.CloseWaitForm();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            müşteridüzenle();
        }

        private void müşteriyiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            müşteridüzenle();
        }

        private void gridControl1_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                lbl_id.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            }
            catch (Exception)
            {
                lbl_id.Text = "";
            }
        }

        private void btn_yenimüşteri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ms_yenimüşteri_frm frm = new frm_ms_yenimüşteri_frm();
            frm.Show();
        }

        private void btn_müş_sil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            müşteriyisil();
        }

        private void btn_düzenle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            müşteridüzenle();
        }

        private void tanım_ödemeYöntemiData() // Ödeme yöntemi sadece nakit * * *
        {
            try
            {
                //MySqlCommand komut_var = new MySqlCommand("select *from tanım_fatura_ödemeyöntemi where ödemeyöntemi=@id", blg.bağlantı());
                //komut_var.Parameters.AddWithValue("@id", "Peşin");
                //komut_var.ExecuteNonQuery();
                //MySqlDataReader oku_var = komut_var.ExecuteReader();
                //cmb_fatura_peşin.Properties.Items.Clear();
                //while (oku_var.Read())
                //{
                //    cmb_fatura_peşin.Properties.Items.Add(oku_var["ad"].ToString());
                //}
                //oku_var.Close();
            }
            catch (Exception)
            {

            }
        }

        private void cmb_fatura_peşin_SelectedIndexChanged(object sender, EventArgs e)
        {
            sl_fatura_bankahesabı.Text = "";
            sl_fatura_kasaHesabı.Text = "";
            sl_fatura_krediKartları.Text = "";

            if (cmb_fatura_peşin.Text == "Kredi Kartı")
            {
                grp_fatura_nakitödeme.Visible = false;
                grp_fatura_havale.Visible = false;
                grp_fatura_kredikarı.Visible = true;
                sp_fatura_taksitsayısı.EditValue = 1;
            }
            if (cmb_fatura_peşin.Text == "Nakit")
            {
                grp_fatura_kredikarı.Visible = false;
                grp_fatura_havale.Visible = false;
                grp_fatura_nakitödeme.Visible = true;
            }
            if (cmb_fatura_peşin.Text == "Havale")
            {
                grp_fatura_kredikarı.Visible = false;
                grp_fatura_nakitödeme.Visible = false;
                grp_fatura_havale.Visible = true;
            }
        }

        private void btn_ödemea_Click(object sender, EventArgs e)
        {
            List<string> hatalar = new List<string>();

            //hatalar.Add("");

            if (hatalar.Count > 0)
            {
                string mesaj = "";
                if (hatalar.Count == 10)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[7] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[8] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[9] + "";
                }
                if (hatalar.Count == 9)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[7] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[8] + "";
                }
                if (hatalar.Count == 8)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[7] + "";
                }
                if (hatalar.Count == 7)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "";
                }
                if (hatalar.Count == 6)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "";
                }
                if (hatalar.Count == 5)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "";
                }
                if (hatalar.Count == 4)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "";
                }
                if (hatalar.Count == 3)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "";
                }
                if (hatalar.Count == 2)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "";
                }
                if (hatalar.Count == 1)
                {
                    mesaj = "" + hatalar[0] + "";
                }
                XtraMessageBox.Show("Bazı eksiklikler tespit edildi:" + Environment.NewLine + "" + Environment.NewLine + "" + mesaj + "");
            }
            else
            {
                if (cmb_fatura_peşin.Text == "Nakit")
                {
                    MySqlCommand komut_ödeme = new MySqlCommand("insert into car_hareketler" +
                    "(müşteri,faturano,ödeme,ödemetürü,ödemeyöntemi,ödemetarihi,tarih,dönem,yıl,açıklama) " +
                    "values(@müşteri,@faturano,@ödeme,@ödemetürü,@ödemeyöntemi,@ödemetarihi,@tarih,@dönem,@yıl,@açıklama)", blg.bağlantı());
                    komut_ödeme.Parameters.Clear();
                    komut_ödeme.Parameters.AddWithValue("@açıklama", txt_açıklama.Text);
                    komut_ödeme.Parameters.AddWithValue("@müşteri", Convert.ToInt32(lbl_id.Text));
                    komut_ödeme.Parameters.AddWithValue("@faturano", searchLookUpEdit_faturaFatRefNo.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödeme", Convert.ToDouble(txt_ödeme.Text));
                    komut_ödeme.Parameters.AddWithValue("@ödemetürü", sl_fatura_kasaHesabı.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemeyöntemi", cmb_fatura_peşin.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemetarihi", Convert.ToDateTime(dt_ödemetarihi.EditValue));
                    komut_ödeme.Parameters.AddWithValue("@tarih", Convert.ToDateTime(blg.tarih().ToString()));
                    komut_ödeme.Parameters.AddWithValue("@dönem", dönem);
                    komut_ödeme.Parameters.AddWithValue("@yıl", yıl);
                    komut_ödeme.ExecuteNonQuery();
                    komut_ödeme.Dispose();
                }
                if (cmb_fatura_peşin.Text == "Havale")
                {
                    MySqlCommand komut_ödeme = new MySqlCommand("insert into car_hareketler" +
                    "(müşteri,faturano,ödeme,ödemetürü,ödemeyöntemi,ödemetarihi,tarih,dönem,yıl,açıklama) " +
                    "values(@müşteri,@faturano,@ödeme,@ödemetürü,@ödemeyöntemi,@ödemetarihi,@tarih,@dönem,@yıl,@açıklama)", blg.bağlantı());
                    komut_ödeme.Parameters.Clear();
                    komut_ödeme.Parameters.AddWithValue("@açıklama", txt_açıklama.Text);
                    komut_ödeme.Parameters.AddWithValue("@müşteri", Convert.ToInt32(lbl_id.Text));
                    komut_ödeme.Parameters.AddWithValue("@faturano", searchLookUpEdit_faturaFatRefNo.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödeme", Convert.ToDouble(txt_ödeme.Text));
                    komut_ödeme.Parameters.AddWithValue("@ödemetürü", sl_fatura_bankahesabı.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemeyöntemi", cmb_fatura_peşin.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemetarihi", Convert.ToDateTime(dt_ödemetarihi.EditValue));
                    komut_ödeme.Parameters.AddWithValue("@tarih", Convert.ToDateTime(blg.tarih().ToString()));
                    komut_ödeme.Parameters.AddWithValue("@dönem", dönem);
                    komut_ödeme.Parameters.AddWithValue("@yıl", yıl);
                    komut_ödeme.ExecuteNonQuery();
                    komut_ödeme.Dispose();
                }
                if (cmb_fatura_peşin.Text == "Kredi Kartı")
                {
                    MySqlCommand komut_ödeme = new MySqlCommand("insert into car_hareketler" +
                    "(müşteri,faturano,ödeme,ödemetürü,ödemeyöntemi,ödemetarihi,tarih,dönem,yıl,açıklama) " +
                    "values(@müşteri,@faturano,@ödeme,@ödemetürü,@ödemeyöntemi,@ödemetarihi,@tarih,@dönem,@yıl,@açıklama)", blg.bağlantı());
                    komut_ödeme.Parameters.Clear();
                    komut_ödeme.Parameters.AddWithValue("@açıklama", txt_açıklama.Text);
                    komut_ödeme.Parameters.AddWithValue("@müşteri", Convert.ToInt32(lbl_id.Text));
                    komut_ödeme.Parameters.AddWithValue("@faturano", searchLookUpEdit_faturaFatRefNo.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödeme", Convert.ToDouble(txt_ödeme.Text));
                    komut_ödeme.Parameters.AddWithValue("@ödemetürü", sl_fatura_krediKartları.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemeyöntemi", cmb_fatura_peşin.Text);
                    komut_ödeme.Parameters.AddWithValue("@taksit", sp_fatura_taksitsayısı.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemetarihi", Convert.ToDateTime(dt_ödemetarihi.EditValue));
                    komut_ödeme.Parameters.AddWithValue("@tarih", Convert.ToDateTime(blg.tarih().ToString()));
                    komut_ödeme.Parameters.AddWithValue("@dönem", dönem);
                    komut_ödeme.Parameters.AddWithValue("@yıl", yıl);
                    komut_ödeme.ExecuteNonQuery();
                    komut_ödeme.Dispose();
                }
                tamamla();
            }            
        }

        private void tamamla()
        {
            gridcontrolgöster_cari();
            searchLookUpEdit_faturaFatRefNo.Text = "";
            txt_ödeme.Text = "";
            cmb_fatura_peşin.Text = "";
            dt_ödemetarihi.EditValue = blg.tarih();
            sl_fatura_krediKartları.Text = "";
            sl_fatura_bankahesabı.Text = "";
            sl_fatura_kasaHesabı.Text = "";
            txt_açıklama.Text="";
        }

        private void cariHesapla()
        {
            //double bakiye = 0.00;
            //double ödeme = 0.00;
            //double harcama = 0.00;
            //double kredi = 0.00;
            //double kalanKredi = 0.00;

            //MySqlCommand msq = new MySqlCommand("select Sum(ödeme),Sum(harcama) from car_hareketler where müşteri=@id", blg.bağlantı());
            //msq.Parameters.Clear();
            //msq.Parameters.AddWithValue("@id", lbl_id.Text);
            //msq.ExecuteNonQuery();
            //MySqlDataReader oku_id = msq.ExecuteReader();
            //while (oku_id.Read())
            //{
            //    try
            //    {
            //        harcama = Convert.ToDouble(oku_id["Sum(harcama)"]);
            //    }
            //    catch (Exception)
            //    {
            //        harcama = 0.00;
            //    }
            //    try
            //    {
            //        ödeme = Convert.ToDouble(oku_id["Sum(ödeme)"]);
            //    }
            //    catch (Exception)
            //    {
            //        ödeme = 0.00;
            //    }
            //}
            //oku_id.Close();

            //bakiye = harcama - ödeme;

            //lbl_bakiye.Text = bakiye.ToString();
            //lbl_ödeme.Text = ödeme.ToString();
            //lbl_harcama.Text = harcama.ToString();

            //MySqlCommand msq2 = new MySqlCommand("select kredi from musteriler where id=@id", blg.bağlantı());
            //msq2.Parameters.Clear();
            //msq2.Parameters.AddWithValue("@id", lbl_id.Text);
            //msq2.ExecuteNonQuery();
            //MySqlDataReader oku_id2 = msq2.ExecuteReader();
            //while (oku_id2.Read())
            //{
            //    try
            //    {
            //        kredi = Convert.ToDouble(oku_id2["kredi"]);
            //    }
            //    catch (Exception)
            //    {
            //        kredi = 0.00;
            //    }
            //}
            //oku_id2.Close();

            //kalanKredi = kredi - bakiye;

            //lbl_kredi.Text = ""+kredi.ToString()+"/"+kalanKredi.ToString()+"";

        }

        private void lbl_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gridcontrolgöster_cari();
                cariHesapla();
            }
            catch (Exception)
            {

            }
        }
    }
}