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

namespace LOYAZ.Formlar.Satış
{
    public partial class frm_st_adetdeğiştir : DevExpress.XtraEditors.XtraForm
    {
        public frm_st_adetdeğiştir()
        {
            InitializeComponent();
        }

        private void frm_st_adetdeğiştir_Load(object sender, EventArgs e)
        {

        }

        sqlbağlantısı blg = new sqlbağlantısı();


        #region sabitler

        public string varyant = "";
        public string ürünkodu = "";
        public double yenitutar = 0.00;
        public int adet = 0;
        public int yeniadet = 0;
        public int id = 0;
        public double fiyat = 0;
        public double iskonto = 0;
        public double yeniİskonto = 0;
        public double iskontooranı = 0;
        public double iskontotutarı = 0;

        #endregion

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            MySqlCommand komut_3 = new MySqlCommand("select *from stş_sepet where ürünkodu=@ürünkodu and varyant=@varyant", blg.bağlantı());
            komut_3.Parameters.AddWithValue("@ürünkodu", ürünkodu);
            komut_3.Parameters.AddWithValue("@varyant", varyant);
            komut_3.ExecuteNonQuery();
            MySqlDataReader oku_3 = komut_3.ExecuteReader();
            if (oku_3.Read())
            {
                try
                {
                    iskontooranı = Convert.ToDouble(oku_3["iskontooranı"]);
                }
                catch (Exception)
                {

                    iskontooranı=0;
                }
                try
                {
                    iskontotutarı = Convert.ToDouble(oku_3["iskontotutarı"]);
                }
                catch (Exception)
                {

                    iskontotutarı=0;
                }
            }
            oku_3.Close();

            yeniadet = Convert.ToInt32(txt_adet.Text);

            if (iskontooranı!=0)
            {
                
                double yeniFİyat = (fiyat * (100 - iskontooranı)) / 100;

                yenitutar = yeniFİyat * yeniadet;

                iskonto = (fiyat - yeniFİyat) * yeniadet;


                try
                {
                    MySqlCommand komut_refyeni = new MySqlCommand("update stş_sepet set etutar=@etutar,adet=@adet,tutar=@tutar,iskonto=@iskonto where ürünkodu=@ürünkodu and varyant=@varyant", blg.bağlantı());
                    komut_refyeni.Parameters.Clear();
                    komut_refyeni.Parameters.AddWithValue("@ürünkodu", ürünkodu);
                    komut_refyeni.Parameters.AddWithValue("@varyant", varyant);
                    komut_refyeni.Parameters.AddWithValue("@adet", yeniadet);
                    komut_refyeni.Parameters.AddWithValue("@tutar", yenitutar);
                    komut_refyeni.Parameters.AddWithValue("@etutar", yenitutar+iskonto);
                    komut_refyeni.Parameters.AddWithValue("@iskonto", iskonto);
                    komut_refyeni.ExecuteNonQuery();
                    komut_refyeni.Dispose();

                    tamamla();
                }
                catch (Exception)
                {

                }

            }
            if (iskontotutarı != 0)
            {
                double yeniFİyat = (fiyat - iskontotutarı);

                yenitutar = yeniFİyat * yeniadet;

                iskonto = (fiyat - yeniFİyat) * yeniadet;

                try
                {
                    MySqlCommand komut_refyeni = new MySqlCommand("update stş_sepet set etutar=@etutar,adet=@adet,tutar=@tutar,iskonto=@iskonto where ürünkodu=@ürünkodu and varyant=@varyant", blg.bağlantı());
                    komut_refyeni.Parameters.Clear();
                    komut_refyeni.Parameters.AddWithValue("@ürünkodu", ürünkodu);
                    komut_refyeni.Parameters.AddWithValue("@varyant", varyant);
                    komut_refyeni.Parameters.AddWithValue("@adet", yeniadet);
                    komut_refyeni.Parameters.AddWithValue("@tutar", yenitutar);
                    komut_refyeni.Parameters.AddWithValue("@etutar", yenitutar + iskonto);
                    komut_refyeni.Parameters.AddWithValue("@iskonto", iskonto);
                    komut_refyeni.ExecuteNonQuery();
                    komut_refyeni.Dispose();

                    tamamla();
                }
                catch (Exception)
                {

                }
            }


            if (iskontooranı == 0 && iskontotutarı == 0)
            {
                yenitutar = fiyat * yeniadet;
            }


            try
            {
                MySqlCommand komut_refyeni = new MySqlCommand("update stş_sepet set adet=@adet,tutar=@tutar where ürünkodu=@ürünkodu and varyant=@varyant", blg.bağlantı());
                komut_refyeni.Parameters.Clear();
                komut_refyeni.Parameters.AddWithValue("@ürünkodu", ürünkodu);
                komut_refyeni.Parameters.AddWithValue("@varyant", varyant);
                komut_refyeni.Parameters.AddWithValue("@adet", yeniadet);
                komut_refyeni.Parameters.AddWithValue("@tutar", yenitutar);
                komut_refyeni.ExecuteNonQuery();
                komut_refyeni.Dispose();

                tamamla();
            }
            catch (Exception)
            {

            }
        }

        private void tamamla()
        {
            var frm2 = (frm_st_anasayfa_panel)Application.OpenForms["frm_st_anasayfa_panel"];
            if (frm2 != null)
                frm2.tamamla();

            txt_adet.Text = "";
            lbl_ürün.Text = "";
            this.Close();
        }
    }
}