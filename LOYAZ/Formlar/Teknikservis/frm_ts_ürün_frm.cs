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
    public partial class frm_ts_ürün_frm : DevExpress.XtraEditors.XtraForm
    {
        public frm_ts_ürün_frm()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void panel_değişken_Load(object sender, EventArgs e)
        {
            pasifet();
            gridcontrolgöster();
        }

        private void pasifet()
        {
            tab_marka.PageVisible = false;
            tab_model.PageVisible = false;
            btn_ürün_düzenle.Enabled = false;
            btn_ürün_sil.Enabled = false;
            btn_kaydet_son.Enabled = false;
        }

        public void gridcontrolgöster()
        {
            // TODO: Bu kod satırı 'dayhan_lozyaDataSet.ts_model' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ts_modelTableAdapter.Fill(this.dayhan_lozyaDataSet.ts_model);
            // TODO: Bu kod satırı 'dayhan_lozyaDataSet.ts_marka' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ts_markaTableAdapter.Fill(this.dayhan_lozyaDataSet.ts_marka);
            // TODO: Bu kod satırı 'dayhan_lozyaDataSet.ts_urun' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ts_urunTableAdapter.Fill(this.dayhan_lozyaDataSet.ts_urun);
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbl_ürünaktar_markaya.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ad").ToString();
            lbl_ürün_marka.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ad").ToString().Trim();
            lbl_marka_ürün.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ad").ToString().Trim();
            lbl_model_ürün.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ad").ToString().Trim();
            tab_marka.PageVisible = true;
            tabPane1.SelectedPage = tab_marka;
        }

        private void btn_ürün_kaydet_Click(object sender, EventArgs e)
        {
            if (lbl_düzenlemedurumu_ürün.Text=="aktif")
            {
                MySqlCommand komut2 = new MySqlCommand("update ts_urun set ad=@ad where id=@id", blg.bağlantı());
                komut2.Parameters.AddWithValue("@id", lbl_ürünid.Text.Trim());
                komut2.Parameters.AddWithValue("@ad", txt_ürün_ad.Text.Trim());
                komut2.ExecuteNonQuery();
                gridcontrolgöster();
                txt_ürün_ad.Text = "";
                btn_ürün_kaydet.Text = "Yeni ürünü kaydet";
                lbl_düzenlemedurumu_ürün.Text="pasif";
            }
            else
            {
                MySqlCommand komut = new MySqlCommand("insert into ts_urun(ad) values(@ad)", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", txt_ürün_ad.Text);
                komut.ExecuteNonQuery();
                txt_ürün_ad.Text = "";
                gridcontrolgöster();

            }
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_ürünid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            lbl_ürün_ürün.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ad").ToString();

        }

        private void btn_ürün_düzenle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("select *from ts_urun where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", lbl_ürünid.Text.ToString().Trim());

            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txt_ürün_ad.Text = oku["ad"].ToString();
            }

            lbl_düzenlemedurumu_ürün.Text = "aktif";
            btn_ürün_kaydet.Text = "Ürünü güncelle";
        }

        private void btn_ürün_sil_Click(object sender, EventArgs e)
        {
            //MySqlCommand komut = new MySqlCommand("select *from ts_urun where id=@id", blg.bağlantı());
            //komut.Parameters.Clear();
            //komut.Parameters.AddWithValue("@id", lbl_ürünid.Text);

            //komut.ExecuteNonQuery();
            //MySqlDataReader oku = komut.ExecuteReader();
            //while (oku.Read())
            //{
            //    lbl_ürün_ürün.Text = oku["ad"].ToString();
            //}


            DialogResult durum = MessageBox.Show("" + lbl_ürün_ürün.Text + " adlı ürünü silmek istediğinizden emin misiniz?", "" + lbl_ürün_ürün.Text + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == durum)
            {
                string sorgu = "DELETE from ts_urun where id=@id";
                MySqlCommand Komut = new MySqlCommand(sorgu, blg.bağlantı());
                Komut.Parameters.AddWithValue("@id", lbl_ürünid.Text.ToString().Trim());
                Komut.ExecuteNonQuery();
                gridcontrolgöster();
                lbl_ürün_ürün.Text = "Ürün";
            }
            else
            {

            }
        }

        //MARKA
        private void btn_marka_kaydet_Click(object sender, EventArgs e)
        {
            if (lbl_düzenlemedurumu_marka.Text == "aktif")
            {
                MySqlCommand komut2 = new MySqlCommand("update ts_marka set ad=@ad,urun=@ürün where id=@id", blg.bağlantı());
                komut2.Parameters.AddWithValue("@id", lbl_ürünid.Text.Trim());
                komut2.Parameters.AddWithValue("@ad", txt_ürün_ad.Text.Trim());
                komut2.Parameters.AddWithValue("@ürün", lbl_marka_ürün.Text.Trim());
                komut2.ExecuteNonQuery();
                gridcontrolgöster();
                txt_marka_ad.Text = "";
                btn_marka_kaydet.Text = "Yeni ürünü kaydet";
                lbl_düzenlemedurumu_marka.Text = "pasif";
            }
            else
            {
                MySqlCommand komut = new MySqlCommand("insert into ts_marka(ad,urun) values(@ad,@ürün)", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", txt_marka_ad.Text);
                komut.Parameters.AddWithValue("@ürün", lbl_marka_ürün.Text.Trim());
                komut.ExecuteNonQuery();
                txt_marka_ad.Text = "";
                gridcontrolgöster();
            }
        }

        private void btn_marka_düzenle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("select *from ts_marka where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", lbl_markaid.Text.ToString().Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txt_marka_ad.Text = oku["ad"].ToString();
            }

            lbl_düzenlemedurumu_marka.Text = "aktif";
            btn_marka_kaydet.Text = "Markayı güncelle";
        }

        private void gridControl_marka_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_markaid.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString();
            lbl_marka__marka.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ad").ToString();
        }

        private void gridControl_marka_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbl_model_marka.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ad").ToString().Trim();
            tab_model.PageVisible = true;
            tabPane1.SelectedPage = tab_model;
        }


        // MODEL
        private void btn_model_kaydet_Click(object sender, EventArgs e)
        {
            if (lbl_düzenlemedurumu_model.Text == "aktif")
            {
                MySqlCommand komut2 = new MySqlCommand("update ts_model set ad=@ad where id=@id and marka=@marka", blg.bağlantı());
                komut2.Parameters.AddWithValue("@id", lbl_modelid.Text.Trim());
                komut2.Parameters.AddWithValue("@marka", lbl_model_marka.Text.Trim());
                komut2.Parameters.AddWithValue("@ad", txt_model_ad.Text.Trim());
                komut2.ExecuteNonQuery();
                gridcontrolgöster();
                txt_model_ad.Text = "";
                btn_model_kaydet.Text = "Yeni modeli kaydet";
                lbl_düzenlemedurumu_model.Text = "pasif";
            }
            else
            {
                MySqlCommand komut = new MySqlCommand("insert into ts_model(ad,marka) values(@ad,@marka)", blg.bağlantı());
                komut.Parameters.AddWithValue("@ad", txt_model_ad.Text);
                komut.Parameters.AddWithValue("@marka", lbl_model_marka.Text.Trim());
                komut.ExecuteNonQuery();
                txt_model_ad.Text = "";
                gridcontrolgöster();
            }
        }

        private void txt_model_düzenle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("select *from ts_model where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", lbl_modelid.Text.ToString().Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txt_model_ad.Text = oku["ad"].ToString();
            }

            lbl_düzenlemedurumu_model.Text = "aktif";
            btn_model_kaydet.Text = "Modeli güncelle";
        }

        private void txt_model_sil_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("" + lbl_model_model.Text + " adlı ürünü silmek istediğinizden emin misiniz?", "" + lbl_model_model.Text + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == durum)
            {
                string sorgu = "DELETE from ts_model where id=@id";
                MySqlCommand Komut = new MySqlCommand(sorgu, blg.bağlantı());
                Komut.Parameters.AddWithValue("@id", lbl_modelid.Text.ToString().Trim());
                Komut.ExecuteNonQuery();
                gridcontrolgöster();
                lbl_model_model.Text = "Model";
            }
            else
            {

            }
        }

        private void btn_kaydet_son_Click(object sender, EventArgs e)
        {
            this.Close();

            var frm3 = (frm_ts_yeniservis_frm)Application.OpenForms["frm_ts_yeniservis_frm"];
            if (frm3 != null)
            frm3.txt_ürün.Properties.Items.Clear();
            frm3.gridcontrolgöster();
        }

        private void gridControl_model_MouseClick(object sender, MouseEventArgs e)
        {
            lbl_modelid.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
            lbl_model_model.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ad").ToString();
        }

        private void lbl_model_model_TextChanged(object sender, EventArgs e)
        {
            if (lbl_model_model.Text != "Model")
            {
                btn_kaydet_son.Enabled = true;
            }
            else
            {
                btn_kaydet_son.Enabled = false;
            }
        }
    }
}