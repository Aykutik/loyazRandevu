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
        public frm_ts_randevuEkrani()
        {
            InitializeComponent();
        }
        public string bağlantıadresi = "";
        

        public DateTime bugün = DateTime.Now;

        private void frm_ts_randevuEkrani_Load(object sender, EventArgs e)
        {
            mysqlGetir();
            randevulariGetir();
        }

        private void mysqlGetir()
        {          

            string dosyaadı = "Sytem.Memory.sq.dll";

            string yol = "" + Application.StartupPath + @"\\" + dosyaadı + "";

            FileStream fs = new FileStream(yol, FileMode.Open, FileAccess.Read);
            StreamReader oku = new StreamReader(fs);
            string satır = oku.ReadLine();
            while (satır != null)
            {
                bağlantıadresi = satır;
                satır = oku.ReadLine();
            }
            oku.Close();
            fs.Close();
        }

        private void randevulariTemizle()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            string saat = bugün.ToString().Substring(11, 2);
            string tarihGun = bugün.ToString().Substring(0, 2);
            string tarihAy = bugün.ToString().Substring(3, 2);
            string tarihYil = bugün.ToString().Substring(6, 4);
            int geciciSaat = 0;
            
            MySqlCommand komut_firmad = new MySqlCommand("SELECT *FROM servis_hareketler WHERE tarih=@tarih and randevu=@randevu", bağlantı);
            komut_firmad.Parameters.Clear();
            komut_firmad.Parameters.AddWithValue("@tarih", ""+tarihYil+"-"+tarihAy+"-"+tarihGun+"");
            komut_firmad.Parameters.AddWithValue("@randevu", "1");
            bağlantı.Open();
            komut_firmad.ExecuteNonQuery();
            MySqlDataReader oku_firmaad = komut_firmad.ExecuteReader();
            while (oku_firmaad.Read())
            {
                int id = Convert.ToInt32(oku_firmaad["id"]);
                geciciSaat = Convert.ToInt32(oku_firmaad["saat"].ToString().Substring(0,2));

                if (geciciSaat < Convert.ToInt32(saat))
                {
                    MySqlCommand komut = new MySqlCommand("update servis_hareketler set randevu=@randevu where id=@id", bağlantı);
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    komut.Parameters.AddWithValue("@randevu", "10");
                    komut.ExecuteNonQuery();
                }
                randevulariGetir();
            }
            oku_firmaad.Close();
            bağlantı.Close();

        }
        

        public void randevulariGetir()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            string tarih = bugün.ToString().Substring(0, 10);

            MySqlDataAdapter adp = new MySqlDataAdapter("select *from servis_hareketler", bağlantı);
            DataTable ds = new DataTable();
            bağlantı.Open();
            adp.Fill(ds);
            bindingSource1.DataSource = ds;
            bindingSource1.Filter = "tarih ='" + tarih + "' and randevu=1";
            gridControlRandevuEkrani.DataSource = bindingSource1;
            bağlantı.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            randevulariTemizle();
        }

        private void timerSanye_Tick(object sender, EventArgs e)
        {
            randevulariTemizle();
            randevulariGetir();
        }
    }
}
