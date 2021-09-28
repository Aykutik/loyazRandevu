using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LOYAZ.Formlar.Teknikservis
{
    public partial class frm_ts_randevuEkrani : Form
    {
        sqlbağlantısı blg = new sqlbağlantısı();

        public frm_ts_randevuEkrani()
        {
            InitializeComponent();
        }
        public string bağlantıadresi = "";
        public DateTime bugun = DateTime.Now;

        private void frm_ts_randevuEkrani_Load(object sender, EventArgs e)
        {
            gridcontrol();
            randevulariGetir();
        }

        private void saatiGetir()
        {
            bugun = DateTime.Now;
            şimdi();
        }

        public string şimdi()
        {
            string saat_format = "HH:mm:ss";
            DateTime şimdik = DateTime.Now;
            string saat = Convert.ToString(şimdik.ToString(saat_format));
            return saat;
        }

        public string şimdiSaat()
        {
            string saat_format = "HH";
            DateTime şimdik = DateTime.Now;
            string saat = Convert.ToString(şimdik.ToString(saat_format));
            return saat;
        }

        public string şimdiDakika()
        {
            string saat_format = "mm";
            DateTime şimdik = DateTime.Now;
            string saat = Convert.ToString(şimdik.ToString(saat_format));
            return saat;
        }

        public string şimdiSaniye()
        {
            string saat_format = "ss";
            DateTime şimdik = DateTime.Now;
            string saat = Convert.ToString(şimdik.ToString(saat_format));
            return saat;
        }

        public string gün()
        {
            string saat_format = "dd MMMMM dddd yyyy";
            DateTime şimdik = DateTime.Today;
            string saat = Convert.ToString(şimdik.ToString(saat_format));
            return saat;
        }

        private void randevulariTemizle()
        {
            saatiGetir();

            lbl_saniye.Text = şimdiDakika();
            lbl_dakika.Text = şimdiSaniye();
            lbl_saat.Text = şimdiSaat();
            lblTarih.Text = gün();

            string saatDakika = bugun.ToString().Substring(14, 2);
            string saatSaniye = bugun.ToString().Substring(17, 2);

            if ((saatDakika == "43" && saatSaniye == "02") ||
                (saatDakika == "50" && saatSaniye == "02") ||
                (saatDakika == "00" && saatSaniye == "02") ||
                (saatDakika == "15" && saatSaniye == "02") ||
                (saatDakika == "25" && saatSaniye == "02") ||
                (saatDakika == "32" && saatSaniye == "02")
                )
            {
                gridcontrol();
                randevulariGetir();
            }        
        }
        
        private void gridcontrol()
        {
            string saatSaat = bugun.ToString().Substring(11, 2);

            string tarihGun = bugun.ToString().Substring(0, 2);
            string tarihAy = bugun.ToString().Substring(3, 2);
            string tarihYil = bugun.ToString().Substring(6, 4);
            int geciciSaat = 0;

            MySqlCommand komut_firmad = new MySqlCommand("SELECT *FROM servis_hareketler WHERE tarih=@tarih and randevu=@randevu", blg.bağlantı());
            komut_firmad.Parameters.Clear();
            komut_firmad.Parameters.AddWithValue("@tarih", "" + tarihYil + "-" + tarihAy + "-" + tarihGun + "");
            komut_firmad.Parameters.AddWithValue("@randevu", "1");
            komut_firmad.ExecuteNonQuery();
            MySqlDataReader oku_firmaad = komut_firmad.ExecuteReader();
            while (oku_firmaad.Read())
            {
                int id = Convert.ToInt32(oku_firmaad["id"]);
                geciciSaat = Convert.ToInt32(oku_firmaad["saat"].ToString().Substring(0, 2));

                if (geciciSaat < Convert.ToInt32(saatSaat))
                {
                    MySqlCommand komut = new MySqlCommand("update servis_hareketler set randevu=@randevu where id=@id", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    komut.Parameters.AddWithValue("@randevu", "10");
                    komut.ExecuteNonQuery();
                }
            }
            oku_firmaad.Close();
        }

        public void randevulariGetir()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            string tarih = bugun.ToString().Substring(0, 10);

            MySqlDataAdapter adp = new MySqlDataAdapter("select *from servis_hareketler", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            bindingSource1.DataSource = ds;
            bindingSource1.Filter = "tarih ='" + tarih + "' and randevu=1";
            gridControlRandevuEkrani.DataSource = bindingSource1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            randevulariTemizle();
        }

        private void timerSanye_Tick(object sender, EventArgs e)
        {
            randevulariTemizle();
        }
    }
}
