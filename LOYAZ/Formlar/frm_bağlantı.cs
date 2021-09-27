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
using System.IO;
using MySql.Data.MySqlClient;

namespace LOYAZ.Formlar
{
    public partial class frm_bağlantı : DevExpress.XtraEditors.XtraForm
    {
        public frm_bağlantı()
        {
            InitializeComponent();
        }

        private void dosyayaz()
        {
            if (txt_parola.Text !="")
            {
                string dosya_yolu = "" + Application.StartupPath + @"\\Sytem.Memory.sq2.dll";
                File.Delete(dosya_yolu);
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("server=" + txt_server.Text.Trim() + ";user id=" + txt_kullanıcıadı.Text.Trim() + "; password=" + txt_parola.Text.Trim() + ";persistsecurityinfo=True;database=" + txt_database.Text.Trim() + "; Charset = utf8");
                sw.Flush();
                sw.Close();
                fs.Close();
                Application.Restart();
            }
            else
            {
                string dosya_yolu = "" + Application.StartupPath + @"\\Sytem.Memory.sq2.dll";
                File.Delete(dosya_yolu);
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("server=" + txt_server.Text.Trim() + ";user id=" + txt_kullanıcıadı.Text.Trim() + ";database=lozya; Charset = utf8");
                sw.Flush();
                sw.Close();
                fs.Close();
                Application.Restart();
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {

            dosyayaz();

            kapatabilir.Text = "evet";
            
            this.Close();

        }

        private void btn_bağlantıtest_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection bağlantı = new MySqlConnection("server=" + txt_server.Text.Trim() + ";user id=" + txt_kullanıcıadı.Text.Trim() + "; password=" + txt_parola.Text.Trim() + ";database=" + txt_database.Text.Trim() + "; Charset = utf8");
                bağlantı.Open();

                string bağlantıtest = "";

                MySqlCommand komut = new MySqlCommand("select *from tarih where id=@id", bağlantı);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", 48);
                komut.ExecuteNonQuery();
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    bağlantıtest = oku["tarih"].ToString();
                    MessageBox.Show("" + bağlantıtest + " Kaydetme işlemi yapabilirsiniz.", "BAĞLANTI SAĞLANDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı Başarısız! Bağlantı bilgilerini kontrol edip tekrar deneyiniz.","BAĞLANTI HATASI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frm_bağlantı_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (kapatabilir.Text == "evet")
            //{
            //    //this.Close();
            //    Application.Exit();
            //}
            //else
            //{
            //    DialogResult durum = MessageBox.Show("Bağlantı henüz kaydedilmemiş, bağlantıyı kaydetmeden çıkmak istiyor musunuz?", "Kapatma Onayı", MessageBoxButtons.YesNo);
            //    if (DialogResult.Yes == durum)
            //    {
            //        //this.Close();
            //        kapatabilir.Text = "evet";
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        private void frm_bağlantı_Load(object sender, EventArgs e)
        {

        }
    }
}