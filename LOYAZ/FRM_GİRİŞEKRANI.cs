using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LOYAZ
{
    public partial class FRM_GİRİŞEKRANI : Form
    {
        public FRM_GİRİŞEKRANI()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void FRM_GİRİŞEKRANI_Load(object sender, EventArgs e)
        {
            txt_kul_girişi.Text = "admin";
            txt_parola.Text = "admin";
        }

        private void btn_giriş_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("select *from kul_kullanicilar where ad=@ad and parola=@parola", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@ad", txt_kul_girişi.Text.Trim());
            komut.Parameters.AddWithValue("@parola", txt_parola.Text.Trim());
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {         
                frm_anasayfa_form frm = new frm_anasayfa_form();
                frm.lbl_kul_id.Text = oku["id"].ToString();
                frm.drop_kullanıcı.Text = oku["ad"].ToString();
                frm.lbl_kul_yetki.Text = oku["yetki"].ToString();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı veya parola hatalı. Kontrol edip tekrar deneyiniz.");
            }
        }
    }
}
