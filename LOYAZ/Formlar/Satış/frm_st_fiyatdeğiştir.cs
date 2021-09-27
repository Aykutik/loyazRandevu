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
    public partial class frm_st_fiyatdeğiştir : DevExpress.XtraEditors.XtraForm
    {
        public frm_st_fiyatdeğiştir()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        #region sabitler

        public string varyant2 = "";
        public string ürünkodu2 = "";
        public double yenitutar2 = 0.00;
        public int adet2 = 0;
        public int yenifiyat2 = 0;
        public double fiyat2 = 0;

        #endregion

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            yenifiyat2 = Convert.ToInt32(txt_fiyat2.Text);

            yenitutar2 = yenifiyat2 * adet2;

            try
            {
                MySqlCommand komut_refyeni = new MySqlCommand("update stş_sepet set etutar=@etutar,fiyat=@fiyat,tutar=@tutar,iskonto=@iskonto,iskontooranı=@iskontooranı,iskontotutarı=@iskontotutarı where ürünkodu=@ürünkodu and varyant=@varyant", blg.bağlantı());
                komut_refyeni.Parameters.Clear();
                komut_refyeni.Parameters.AddWithValue("@ürünkodu", ürünkodu2);
                komut_refyeni.Parameters.AddWithValue("@varyant", varyant2);
                komut_refyeni.Parameters.AddWithValue("@fiyat", yenifiyat2);
                komut_refyeni.Parameters.AddWithValue("@tutar", yenitutar2);
                komut_refyeni.Parameters.AddWithValue("@etutar", yenitutar2);
                komut_refyeni.Parameters.AddWithValue("@iskonto", 0);
                komut_refyeni.Parameters.AddWithValue("@iskontooranı", 0);
                komut_refyeni.Parameters.AddWithValue("@iskontotutarı", 0);
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

            this.Close();
        }
    }
}