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
using System.Net;
using System.Management;
using System.Net.NetworkInformation;
using System.IO;
using LOYAZ.Formlar;

namespace LOYAZ
{
    public partial class frm_giriş : DevExpress.XtraEditors.XtraForm
    {
        
        public frm_giriş()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void bh_hatırlakontrol()
        {
            MySqlCommand komut_hatırla = new MySqlCommand("select *from ayarlar where bh_host=@bh_host and bh_kontrol=@bh_kontrol", blg.bağlantı());
            komut_hatırla.Parameters.Clear();
            komut_hatırla.Parameters.AddWithValue("@bh_host", MACAdresiAl());
            komut_hatırla.Parameters.AddWithValue("@bh_kontrol", 1);
            komut_hatırla.ExecuteNonQuery();
            MySqlDataReader oku_hatırla = komut_hatırla.ExecuteReader();
            if (oku_hatırla.Read())
            {
                txt_kul_girişi.Text = oku_hatırla["bh_eposta"].ToString();
            }

            splashScreenManager1.CloseWaitForm();

            MySqlCommand hatıla_kontrol = new MySqlCommand("select *from ayarlar where bh_eposta=@bh_eposta and bh_host=@bh_host", blg.bağlantı());
            hatıla_kontrol.Parameters.Clear();
            hatıla_kontrol.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text);
            hatıla_kontrol.Parameters.AddWithValue("@bh_host", MACAdresiAl());
            hatıla_kontrol.ExecuteNonQuery();
            MySqlDataReader oku_kontrol = hatıla_kontrol.ExecuteReader();
            
            if (oku_kontrol.Read())
            {
                chck_benihatırla.Checked = true;
            }
        }

        private void frm_giriş_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();

            string dosya_yolu = "" + Application.StartupPath + @"\\Sytem.Memory.sq2.dll";
            string dosya_yolu2 = "" + Application.StartupPath + @"\\Sytem.Memory.sq.dll";
            File.Copy(dosya_yolu, dosya_yolu2, true);

            try
            {
                comboyükle();
                bh_hatırlakontrol();
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı ayarlarını yapınız.");
                splashScreenManager1.CloseWaitForm();
            }

            lbl_versiyon.Text = blg.versiyon();

            if (blg.macAlDsyadan() == blg.MACAdresiAl())
            {
                pinc.Visible = false;
            }
        }

        private void comboyükle()
        {
            txt_kul_girişi.Properties.Items.Clear();
            MySqlCommand komut_combo = new MySqlCommand("select *from ayarlar where bh_host=@bh_host and bh_kontrol=@bh_kontrol", blg.bağlantı());
            komut_combo.Parameters.AddWithValue("@bh_host", MACAdresiAl());
            komut_combo.Parameters.AddWithValue("@bh_kontrol", 1);
            MySqlDataReader read = komut_combo.ExecuteReader();
            while (read.Read())
            {
                txt_kul_girişi.Text = read["bh_eposta"].ToString();
                txt_kul_girişi.Properties.Items.Add(read["bh_eposta"]);
            }
        }

        private void txt_kul_girişi_BeforePopup(object sender, EventArgs e)
        {
            txt_kul_girişi.Properties.Items.Clear();
            MySqlCommand komut_combo = new MySqlCommand("select *from ayarlar where bh_host=@bh_host and bh_kontrol=@bh_kontrol", blg.bağlantı());
            komut_combo.Parameters.AddWithValue("@bh_host", MACAdresiAl());
            komut_combo.Parameters.AddWithValue("@bh_kontrol", 1);
            MySqlDataReader read = komut_combo.ExecuteReader();
            while (read.Read())
            {
                txt_kul_girişi.Properties.Items.Add(read["bh_eposta"]);
            }
        }

        private void bh_kontol()
        {
            if (chck_benihatırla.Checked == true)
            {
                string kontrol = "";

                //daha önce kaydı var mı kontrol et 
                MySqlCommand komut_kontrol_et = new MySqlCommand("select *from ayarlar where bh_host=@bh_host and bh_eposta=@bh_eposta", blg.bağlantı());
                komut_kontrol_et.Parameters.Clear();
                komut_kontrol_et.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text);
                komut_kontrol_et.Parameters.AddWithValue("@bh_host", MACAdresiAl());
                komut_kontrol_et.ExecuteNonQuery();
                MySqlDataReader oku_kontrol = komut_kontrol_et.ExecuteReader();
                if (oku_kontrol.Read())// varsa..
                {
                    kontrol = oku_kontrol["bh_kontrol"].ToString();

                    if (kontrol == "1")
                    {

                    }
                    else
                    {
                        MySqlCommand komut_bh = new MySqlCommand("update ayarlar set bh_kontrol=@bh_kontrol where bh_eposta=@bh_eposta and bh_host=@bh_host", blg.bağlantı());
                        komut_bh.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text);
                        komut_bh.Parameters.AddWithValue("@bh_host", MACAdresiAl());
                        komut_bh.Parameters.AddWithValue("@bh_kontrol", "1");
                        komut_bh.Parameters.AddWithValue("@id", 1);
                        komut_bh.ExecuteNonQuery();
                    }
                }
                else// yoksa
                {
                    MySqlCommand komut_bh_host = new MySqlCommand("insert into " +
                    "ayarlar(bh_kontrol,bh_eposta,bh_host) " +
                    "values(@bh_kontrol,@bh_eposta,@bh_host)", blg.bağlantı());
                    komut_bh_host.Parameters.Clear();
                    komut_bh_host.Parameters.AddWithValue("@bh_kontrol", "1");
                    komut_bh_host.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text);
                    komut_bh_host.Parameters.AddWithValue("@bh_host", MACAdresiAl());
                    komut_bh_host.ExecuteNonQuery();
                }
            }
            else
            {
                MySqlCommand komut_bh = new MySqlCommand("update ayarlar set bh_kontrol=@bh_kontrol, bh_eposta=@bh_eposta where id=@id", blg.bağlantı());
                komut_bh.Parameters.AddWithValue("@bh_kontrol", "0");
                komut_bh.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text);
                komut_bh.Parameters.AddWithValue("@id", 1);
                komut_bh.ExecuteNonQuery();
            }
        }
        private void btn_giriş_Click(object sender, EventArgs e)
        {
            giriş();
        }

        private void giriş()
        {

            MySqlCommand komut = new MySqlCommand("select *from kul_kullanicilar where eposta=@eposta and parola=@parola", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@eposta", txt_kul_girişi.Text.Trim());
            komut.Parameters.AddWithValue("@parola", txt_parola.Text.Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                try
                {
                    frm_anasayfa_form frm2 = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
                    frm2.Close();
                }
                catch (Exception)
                {

                }

                try// verileri sonraki sayfaya aktar..
                {
                    frm_anasayfa_form frm = new frm_anasayfa_form();
                    frm.lbl_kul_id.Text = oku["id"].ToString();
                    frm.drop_kullanıcı.Text = oku["ad"].ToString();

                    string pic_logoyol = "" + Application.StartupPath + @"\reg\kul_foto" + "\\" + frm.lbl_kul_id.Text + ".jpg";

                    frm.pictureEdit_avatar2.Image = Image.FromFile(pic_logoyol);
                    frm.Show();
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                }
                catch (Exception)// verileri sonraki sayfaya aktar. fotoğrafsız
                {
                    frm_anasayfa_form frm = new frm_anasayfa_form();
                    frm.lbl_kul_id.Text = oku["id"].ToString();
                    frm.drop_kullanıcı.Text = oku["ad"].ToString();
                    frm.Show();
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                }
                bh_kontol();
            }
            else
            {
                MessageBox.Show("Kullanıcı veya parola hatalı. Kontrol edip tekrar deneyiniz.");
            }
        }

        private void txt_parola_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                giriş();
            }
        }


        private void chck_benihatırla_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_benihatırla.Checked == true)
            {
                
            }
            else
            {
                //bu hesap kayıtlarda var mı varsa silme onayını sor
                if (txt_kul_girişi.Text.Length > 5)
                {
                    MySqlCommand komut_hatırla = new MySqlCommand("select *from ayarlar where bh_eposta=@bh_eposta and bh_host=@bh_host", blg.bağlantı());
                    komut_hatırla.Parameters.Clear();
                    komut_hatırla.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text);
                    komut_hatırla.Parameters.AddWithValue("@bh_host", MACAdresiAl());
                    komut_hatırla.ExecuteNonQuery();
                    MySqlDataReader oku_hatırla = komut_hatırla.ExecuteReader();
                    if (oku_hatırla.Read())
                    {
                        DialogResult durum = MessageBox.Show("" + txt_kul_girişi.Text + " Eposta hesabı sonraki girişlerde hatırlatılmasının kaldırılmasını onaylıyor musunuz?", "" + txt_kul_girişi.Text + "", MessageBoxButtons.YesNoCancel);
                        if (DialogResult.Yes == durum)
                        {
                            MySqlCommand komut_bh = new MySqlCommand("update ayarlar set bh_kontrol=@bh_kontrol where bh_host=@bh_host and bh_eposta=@bh_eposta", blg.bağlantı());
                            komut_bh.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text.Trim());
                            komut_bh.Parameters.AddWithValue("@bh_host", MACAdresiAl());
                            komut_bh.Parameters.AddWithValue("@bh_kontrol", "0");
                            komut_bh.ExecuteNonQuery();

                            txt_kul_girişi.Properties.Items.Clear();

                            MySqlCommand komut_combo = new MySqlCommand("select *from ayarlar where bh_host=@bh_host and bh_kontrol=@bh_kontrol", blg.bağlantı());
                            komut_combo.Parameters.AddWithValue("@bh_host", MACAdresiAl());
                            komut_combo.Parameters.AddWithValue("@bh_kontrol", 1);
                            MySqlDataReader read = komut_combo.ExecuteReader();
                            while (read.Read())
                            {
                                txt_kul_girişi.Properties.Items.Add(read["bh_eposta"]);
                            }
                        }
                    }
                }
            }
        }

        private void txt_kul_girişi_SelectedValueChanged(object sender, EventArgs e)// kullanıcı hafıza kayıtlarında var mı kontrol et
        {
            MySqlCommand hatıla_kontrol = new MySqlCommand("select *from ayarlar where bh_eposta=@bh_eposta and bh_host=@bh_host", blg.bağlantı());
            hatıla_kontrol.Parameters.Clear();
            hatıla_kontrol.Parameters.AddWithValue("@bh_eposta", txt_kul_girişi.Text);
            hatıla_kontrol.Parameters.AddWithValue("@bh_host", MACAdresiAl());
            hatıla_kontrol.ExecuteNonQuery();
            MySqlDataReader oku_kontrol = hatıla_kontrol.ExecuteReader();
            if (oku_kontrol.Read())
            {
                chck_benihatırla.Checked = true;
            }
            else
            {
                chck_benihatırla.Checked = false;
            }
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btn_bağlantıayarları_Click(object sender, EventArgs e)
        {
            
            frm_bağlantı frm = new frm_bağlantı();
            frm.ShowDialog();
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

 
    }
}