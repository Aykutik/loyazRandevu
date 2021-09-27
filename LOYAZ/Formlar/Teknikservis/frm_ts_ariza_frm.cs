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

namespace LOYAZ
{
    public partial class frm_ts_ariza_frm : DevExpress.XtraEditors.XtraForm
    {
        public frm_ts_ariza_frm()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void frm_ts_ariza_frm_Load(object sender, EventArgs e)
        {

            pasifet();
            gridcontrolgöster();
        }

        public void gridcontrolgöster()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from ts_urun", blg.bağlantı());
            DataSet ds = new DataSet();
            adp.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

            MySqlDataAdapter adp2 = new MySqlDataAdapter("select * from ts_ariza", blg.bağlantı());
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            gridControl_marka.DataSource = ds2.Tables[0];
        }

        private void pasifet()
        {
            tab_ariza.PageVisible = false;
            btn_ürün_düzenle.Enabled = false;
            btn_ürün_sil.Enabled = false;
            btn_ileri.Enabled = false;
            btn_arıza_düzenle.Enabled = false;
            btn_ariza_sil.Enabled = false;
            btn_kapat.Enabled = false;
        }

        private void btn_ürün_kaydet_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            if (lbl_düzenlemedurumu_ürün.Text == "aktif")
            {
                //düzenleden geliyorsa, var mı kontrol et,
                MySqlCommand komut = new MySqlCommand("Select *from ts_urun where ad=@ad", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", txt_ürün_ad.Text);
                MySqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {

                }
                else
                {
                    //düzenleden geliyorsa //eğer varsa
                    MySqlCommand komut2 = new MySqlCommand("update ts_urun set ad=@ad where id=@id", blg.bağlantı());
                    komut2.Parameters.AddWithValue("@id", lbl_ürünid.Text.Trim());
                    komut2.Parameters.AddWithValue("@ad", txt_ürün_ad.Text.Trim());
                    komut2.ExecuteNonQuery();
                    gridcontrolgöster();
                    txt_ürün_ad.Text = "";
                    btn_ürün_kaydet.Text = "Yeni ürünü kaydet";
                    lbl_düzenlemedurumu_ürün.Text = "pasif";
                }
            }
            else
            {   // düzenlemeden gelmiyorsa varmı kontrol et
                MySqlCommand komut = new MySqlCommand("Select *from ts_urun where ad=@ad", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", txt_ürün_ad.Text);
                MySqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {

                }
                else
                {   // yoksa....
                    MySqlCommand komut2 = new MySqlCommand("insert into ts_urun(ad) values(@ad)", blg.bağlantı());
                    komut2.Parameters.AddWithValue("@ad", txt_ürün_ad.Text);
                    komut2.ExecuteNonQuery();
                    txt_ürün_ad.Text = "";
                    gridcontrolgöster();
                }
            }
            splashScreenManager2.CloseWaitForm();

        }

        private void btn_ariza_kaydet_Click(object sender, EventArgs e)
        {
            splashScreenManager2.ShowWaitForm();
            if (lbl_düzenlemedurumu_ariza.Text == "aktif")
            {   //düzenleden geliyorsa
                //eğer varsa güncelle modu
                MySqlCommand komut = new MySqlCommand("Select *from ts_ariza where ad=@ad and urun=@urun", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", txt_arıza_ad.Text);
                komut.Parameters.AddWithValue("@urun", lbl_ariza_ürün.Text);
                MySqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {

                }
                else
                {
                    //yoksa yeni kaydet modu
                    MySqlCommand komut2 = new MySqlCommand("update ts_ariza set ad=@ad urun=@urun where id=@id", blg.bağlantı());
                    komut2.Parameters.AddWithValue("@id", lbl_arızaid.Text.Trim());
                    komut2.Parameters.AddWithValue("@ad", txt_arıza_ad.Text.Trim());
                    komut2.Parameters.AddWithValue("@urun", lbl_ariza_ürün.Text.Trim());
                    komut2.ExecuteNonQuery();
                    gridcontrolgöster();
                    txt_arıza_ad.Text = "";
                    btn_ariza_kaydet.Text = "Yeni arızayı kaydet";
                    lbl_düzenlemedurumu_ariza.Text = "pasif";
                }
            }
            else
            {   
                //düzenleden gelmiyorsa
                //eğer varsa...
                MySqlCommand komut = new MySqlCommand("Select *from ts_ariza where ad=@ad", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", txt_arıza_ad.Text);
                MySqlDataReader read = komut.ExecuteReader();
                if (read.Read())
                {

                }
                else // yoksa....
                {
                    MySqlCommand komut2 = new MySqlCommand("insert into ts_ariza(ad,urun) values(@ad,@urun)", blg.bağlantı());
                    komut2.Parameters.AddWithValue("@ad", txt_arıza_ad.Text);
                    komut2.Parameters.AddWithValue("@urun", lbl_ariza_ürün.Text);
                    komut2.ExecuteNonQuery();
                    txt_arıza_ad.Text = "";
                    btn_ariza_kaydet.Text = "Yeni arızayı kaydet";
                    lbl_düzenlemedurumu_ariza.Text = "pasif";
                    gridcontrolgöster();
                }
            }
            splashScreenManager2.CloseWaitForm();
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            lbl_ürün_ürün.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ad").ToString().Trim();
            lbl_ariza_ürün.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ad").ToString().Trim();
        }

        private void gridControl_marka_MouseClick(object sender, MouseEventArgs e)
        {
            lbl_ariza_ariza.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ad").ToString().Trim();
            lbl_arızaid.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString().Trim();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_ürün_düzenle.Enabled = true;
            btn_ürün_sil.Enabled = true;
            lbl_ürünid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString().Trim();
        }

        private void gridControl_marka_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_arıza_düzenle.Enabled = true;
            btn_ariza_sil.Enabled = true;
            lbl_arızaid.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString().Trim();
        }

        private void btn_ileri_Click(object sender, EventArgs e)
        {
            tab_ariza.PageVisible = true;
            tabPane1.SelectedPage = tab_ariza;
        }

        private void lbl_ürün_ürün_TextChanged(object sender, EventArgs e)
        {
            if (lbl_ürün_ürün.Text == "Ürün seç")
            {
                btn_ileri.Enabled = false;
            }
            else
            {
                btn_ileri.Enabled = true;
            }
        }

        private void lbl_ariza_ariza_TextChanged(object sender, EventArgs e)
        {
            if (lbl_ariza_ariza.Text == "Arıza seç")
            {
                btn_kapat.Enabled = false;
            }
            else
            {
                btn_kapat.Enabled = true;
            }
        }

        private void btn_ürün_düzenle_Click(object sender, EventArgs e)
        {
            txt_ürün_ad.Text = lbl_ürün_ürün.Text;
            btn_ürün_kaydet.Text = "Ürünü güncelle";
        }

        private void btn_arıza_düzenle_Click(object sender, EventArgs e)
        {
            txt_arıza_ad.Text = lbl_ariza_ariza.Text;
            btn_ariza_kaydet.Text = "Arızayı güncelle";
        }

        private void btn_ürün_sil_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show(""+lbl_ürün_ürün.Text+" Kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                MySqlCommand Komut = new MySqlCommand("DELETE from ts_urun where id=@id", blg.bağlantı());
                Komut.Parameters.AddWithValue("@id", lbl_ürünid.Text);
                Komut.ExecuteNonQuery();
                gridcontrolgöster();
                lbl_ürün_ürün.Text = "Ürün seç";
                txt_ürün_ad.Text = "";
                btn_ürün_kaydet.Text = "Yeni ürünü kaydet";
                btn_ürün_düzenle.Enabled = false;
                btn_ürün_sil.Enabled = false;
            }
            else
            {

            }
        }

        private void btn_ariza_sil_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("" + lbl_ariza_ariza.Text + " Kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                MySqlCommand Komut = new MySqlCommand("DELETE from ts_ariza where id=@id", blg.bağlantı());
                Komut.Parameters.AddWithValue("@id", lbl_arızaid.Text);
                Komut.ExecuteNonQuery();
                gridcontrolgöster();
                lbl_ariza_ariza.Text = "Arıza seç";
                txt_arıza_ad.Text = "";
                btn_ariza_kaydet.Text = "Yeni arızayı kaydet";
                btn_arıza_düzenle.Enabled = false;
                btn_ariza_sil.Enabled = false;
            }
            else
            {

            }
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            var frm = (frm_ts_yeniservis_frm)Application.OpenForms["frm_ts_yeniservis_frm"];
            if (frm != null)
                frm.gridcontrolgöster();
            this.Close();
        }
    }
}