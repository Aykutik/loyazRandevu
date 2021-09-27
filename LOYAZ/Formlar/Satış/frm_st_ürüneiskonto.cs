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
    public partial class frm_st_ürüneiskonto : DevExpress.XtraEditors.XtraForm
    {
        public frm_st_ürüneiskonto()
        {
            InitializeComponent();            
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        public int id = 0;
        public int adet = 0;
        public string ürünkodu = "";
        public string varyant = "";
        public double öncekiFiyat = 0;
        public double yeniFİyat = 0;
        public double iskontoOran = 0;
        public double iskontoTutar = 0;
        public double öncekitutar = 0;
        public double yenitutar = 0;
        public double iskonto = 0;
        public double iskontooranı2 = 0;
        public double iskontotutarı2 = 0;

        private void frm_st_ürüneiskonto_Load(object sender, EventArgs e)
        {
            
        }

        private void bilgilerial()
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
                    iskontooranı2 = Convert.ToDouble(oku_3["iskontooranı"]);
                }
                catch (Exception)
                {
                        
                }
                try
                {
                    iskontotutarı2 = Convert.ToDouble(oku_3["iskontotutarı"]);
                }
                catch (Exception)
                {

                }
            }
            oku_3.Close();

            if (iskontooranı2!=0) // kayıtlarda iskonto oranı var ise...
            {
                txt_iskonto.Text = iskontooranı2.ToString();
                rd_iskontoTürü.EditValue = "yüzde";

                yeniFİyat = (öncekiFiyat * (100 - iskontooranı2)) / 100;
                lbl_yenifiyat.Text = yeniFİyat.ToString();
            }
            if (iskontotutarı2 != 0) // kayıtlarda iskonto tutarı var ise...
            {
                txt_iskonto.Text = iskontotutarı2.ToString();
                rd_iskontoTürü.EditValue = "tutar";

                yeniFİyat = öncekiFiyat - iskontotutarı2;
                lbl_yenifiyat.Text = yeniFİyat.ToString();
            }
            if(iskontooranı2 == 0 & iskontotutarı2 == 0)
            {
                txt_iskonto.Text = "0";
                yeniFİyat = öncekiFiyat;
                rd_iskontoTürü.EditValue = "";
            }

            

        }

        private void txt_iskonto_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd_iskontoTürü.EditValue.ToString() == "yüzde")
                {
                    if (txt_iskonto.Text != "") // daha önce iskonto var ise
                    {
                        iskontoOran = Convert.ToDouble(txt_iskonto.Text);
                    }
                    else
                    {
                        iskontoOran = 0;
                    }

                    yeniFİyat = (öncekiFiyat * (100 - iskontoOran)) / 100;

                    yenitutar = yeniFİyat * adet;

                    iskonto = (öncekiFiyat - yeniFİyat) * adet;
                }
                if (rd_iskontoTürü.EditValue.ToString() == "tutar")
                {
                    if (txt_iskonto.Text != "")// daha önce iskonto yapıldı ise
                    {
                        iskontoTutar = Convert.ToDouble(txt_iskonto.Text);
                    }
                    else
                    {
                        iskontoTutar = 0;
                    }

                    yeniFİyat = öncekiFiyat - iskontoTutar;

                    yenitutar = yeniFİyat * adet;

                    iskonto = (öncekiFiyat - yeniFİyat) * adet;
                }
            }
            catch (Exception)
            {

            }

            lbl_yenifiyat.Text = yeniFİyat.ToString();
        }

        private void btn_iskontoYap_Click(object sender, EventArgs e)
        {
            if (rd_iskontoTürü.EditValue.ToString() == "yüzde")
            {
                MySqlCommand komut_refyeni = new MySqlCommand("update stş_sepet set etutar=@etutar,tutar=@tutar,iskonto=@iskonto,iskontooranı=@iskontooranı,iskontotutarı=@iskontotutarı where ürünkodu=@id and varyant=@varyant", blg.bağlantı());
                komut_refyeni.Parameters.Clear();
                komut_refyeni.Parameters.AddWithValue("@id", ürünkodu);
                komut_refyeni.Parameters.AddWithValue("@varyant", varyant);
                komut_refyeni.Parameters.AddWithValue("@iskonto", iskonto);
                komut_refyeni.Parameters.AddWithValue("@tutar", yenitutar);
                komut_refyeni.Parameters.AddWithValue("@etutar", yenitutar + iskonto);
                komut_refyeni.Parameters.AddWithValue("@iskontooranı", iskontoOran);
                komut_refyeni.Parameters.AddWithValue("@iskontotutarı", null);
                komut_refyeni.ExecuteNonQuery();
                komut_refyeni.Dispose();

                var frm2 = (frm_st_anasayfa_panel)Application.OpenForms["frm_st_anasayfa_panel"];
                if (frm2 != null)
                    frm2.tamamla();
                this.Close();
            }
            if (rd_iskontoTürü.EditValue.ToString() == "tutar")
            {
                MySqlCommand komut_refyeni = new MySqlCommand("update stş_sepet set etutar=@etutar,tutar=@tutar,iskonto=@iskonto,iskontooranı=@iskontooranı,iskontotutarı=@iskontotutarı where ürünkodu=@id and varyant=@varyant", blg.bağlantı());
                komut_refyeni.Parameters.Clear();
                komut_refyeni.Parameters.AddWithValue("@id", ürünkodu);
                komut_refyeni.Parameters.AddWithValue("@varyant", varyant);
                komut_refyeni.Parameters.AddWithValue("@iskonto", iskonto);
                komut_refyeni.Parameters.AddWithValue("@tutar", yenitutar);
                komut_refyeni.Parameters.AddWithValue("@etutar", yenitutar + iskonto);
                komut_refyeni.Parameters.AddWithValue("@iskontooranı", null);
                komut_refyeni.Parameters.AddWithValue("@iskontotutarı", iskontoTutar);
                komut_refyeni.ExecuteNonQuery();
                komut_refyeni.Dispose();

                var frm2 = (frm_st_anasayfa_panel)Application.OpenForms["frm_st_anasayfa_panel"];
                if (frm2 != null)
                    frm2.tamamla();
                this.Close();
            }
        }

        private void frm_st_ürüneiskonto_Shown(object sender, EventArgs e)
        {
            bilgilerial();
        }

        private void rd_iskontoTürü_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rd_iskontoTürü.EditValue.ToString() == "yüzde")
            {
                lbl_iskontoTürü.Text = "Yüzde:";

                if (txt_iskonto.Text != "")
                {
                    txt_iskonto.Text = iskontooranı2.ToString();
                }
                else
                {
                    try
                    {
                        txt_iskonto.Text = (100-((yeniFİyat / öncekiFiyat)*100)).ToString(); 
                    }
                    catch (Exception)
                    {
                        iskontoOran = 0;
                    }
                }

                yeniFİyat = (öncekiFiyat * (100 - iskontooranı2)) / 100;

                yenitutar = yeniFİyat * adet;

                iskonto = (öncekiFiyat - yeniFİyat) * adet;

            }
            if (rd_iskontoTürü.EditValue.ToString() == "tutar")
            {
                lbl_iskontoTürü.Text = "Tutar:";

                if (txt_iskonto.Text != "")
                {
                    txt_iskonto.Text = iskontotutarı2.ToString();
                }
                else
                {
                    txt_iskonto.Text = "0";
                }



            }
        }
    }
}