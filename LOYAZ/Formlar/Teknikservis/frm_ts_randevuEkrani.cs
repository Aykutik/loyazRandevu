using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LOYAZ.Formlar.Teknikservis
{
    public partial class frm_ts_randevuEkrani : Form
    {
        public frm_ts_randevuEkrani()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        public DateTime bugün = DateTime.Now;

        private void frm_ts_randevuEkrani_Load(object sender, EventArgs e)
        {
            randevulariGetir();
        }

        private void randevulariTemizle()
        {
            string saat = bugün.ToString().Substring(11, 2);
            string tarih = bugün.ToString().Substring(0, 10);
            int geciciSaat = 0;

            MySqlCommand komut_firmad = new MySqlCommand("SELECT *FROM servis_hareketler WHERE tarih=@tarih and randevu=@randevu", blg.bağlantı());
            komut_firmad.Parameters.Clear();
            komut_firmad.Parameters.AddWithValue("@tarih", "2021-09-27");
            komut_firmad.Parameters.AddWithValue("@randevu", "1");
            komut_firmad.ExecuteNonQuery();
            MySqlDataReader oku_firmaad = komut_firmad.ExecuteReader();
            while (oku_firmaad.Read())
            {
                int id = Convert.ToInt32(oku_firmaad["id"]);
                geciciSaat = Convert.ToInt32(oku_firmaad["saat"].ToString().Substring(0,2));

                if (geciciSaat < Convert.ToInt32(saat))
                {
                    MySqlCommand komut = new MySqlCommand("update servis_hareketler set randevu=@randevu where id=@id", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    komut.Parameters.AddWithValue("@randevu", "10");
                    komut.ExecuteNonQuery();
                }
                randevulariGetir();
            }

        }
        

        public void randevulariGetir()
        {
            string tarih = bugün.ToString().Substring(0, 10);

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
    }
}
