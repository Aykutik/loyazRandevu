using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Data;

namespace LOYAZ
{
    class sqlbağlantısı
    {
        public MySqlConnection bağlantı()
        {
            //string bağlantıadresi = "Server = loyaz.net; Database = u477970783_tanlas; Convert Zero Datetime=true; uid = u477970783_aykutik;persistsecurityinfo=True; Password = aykuT18092007;SSL Mode=none";
            string bağlantıadresi = "";

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

            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);

            if (bağlantı.State ==ConnectionState.Open)
            {
                bağlantı.Close();
            }

            bağlantı.Open();
            return bağlantı;            
        }

        public string macAlDsyadan()
        {
            string mac = "";


            string yol = "" + Application.StartupPath + @"\ja\\DevExpress.XtraVerticalGrid.v20.1.resourcesr_adn.dll"; 

            try
            {
                StreamReader oku = new StreamReader("" + yol + "");
                string satır = oku.ReadLine();
                while (satır != null)
                {
                    mac = satır;
                    satır = oku.ReadLine();
                }
            }
            catch (Exception)
            {


            }
            return mac;
        }

        public string MACAdresiAl()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty) sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
            return sMacAddress;
        }

        public DateTime tarih()
        {
            DateTime bugun = DateTime.Today;
            //string tarih_format = "dd-MM-yyyy";
            string tarih_format = "DD.MM.YYYY";
            bugun.ToString(tarih_format);
            return bugun;
        }

        public string tarih_format()
        {
            //string tarih_format = "dd-MM-yyyy";
            string tarih_format = "dd.MM.yyyy";
            return tarih_format;
        }

        public DateTime saat()
        {
            DateTime şimdi = DateTime.Now;    
            return şimdi;
        }

        public string saat_format()
        {
            string saat_format = "HH:mm";
            return saat_format;
        }

        public string kullanıcı()
        {
            string kullanıcı = "Admin";
            return kullanıcı;
        }

        public string kullanıcıid()
        {
            string kullanıcı = "1";
            return kullanıcı;
        }

        public string versiyon()
        {
            string versiyon = "Alfa 1.2";
            return versiyon;
        }

        // ayarlar
        public bool visabledurumu()
        {
            bool visible = false;
            //bool visible = true;
            return visible;
        }
    }
}
