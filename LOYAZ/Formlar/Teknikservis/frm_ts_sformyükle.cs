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
using DevExpress.XtraRichEdit.Forms;
using ZXing;
using System.IO;
using MySql.Data.MySqlClient;

namespace LOYAZ
{
    public partial class frm_ts_sformyükle : DevExpress.XtraEditors.XtraForm
    {
        public frm_ts_sformyükle()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void frm_ts_sformyükle_Load(object sender, EventArgs e)
        {

        }

        private void btn_gözat_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofg = new OpenFileDialog() { Filter = "JPG|*.jpg" })
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    pictureEdit1.Image = Image.FromFile(ofg.FileName);
                    BarcodeReader reader = new BarcodeReader();
                    var result = reader.Decode((Bitmap)pictureEdit1.Image);
                    if (result != null)
                    {
                        lbl_barcode_oku.Text = result.ToString();
                    }
                    txt_görselyolu.Text = ofg.FileName;
                }
        }

        private void btn_yükle_Click(object sender, EventArgs e)
        {
            string yol = "" + Application.StartupPath + @"\servis raporları" + "\\" + lbl_barcode_oku.Text + ".jpg";
            string yolkapa = "" + Application.StartupPath + @"\servis raporları" + "\\kapananlar\\" + lbl_barcode_oku.Text + ".jpg";

            //sağ tık id bağımlı yükleme
            if (lbl_direkt.Text == "bağımlı")
            {
                if (lbl_barcode_oku.Text.Remove(0, 3) == lbl_gelen_servisid.Text)
                {
                    try
                    {                    
                        MySqlCommand komut = new MySqlCommand("Select *from ts_servisform where servisid=@id", blg.bağlantı());
                        komut.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));
                        MySqlDataReader read = komut.ExecuteReader();
                        if (read.Read())
                        {
                            DialogResult durum = MessageBox.Show("Yüklemek istediğiniz form halihazırda mevcut bulunuyor. Devam ederseniz güncellenecek devam etmek ister misiniz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (DialogResult.Yes == durum)
                            {
                                MySqlCommand komut_güncelle = new MySqlCommand("update ts_servisform set yol=@yol,yüklemetarihiac=@yüklemetarihiac where servisid=@id", blg.bağlantı());
                                komut_güncelle.Parameters.AddWithValue("@yol", yol);
                                komut_güncelle.Parameters.AddWithValue("@yüklemetarihiac", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut_güncelle.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));
                                komut_güncelle.ExecuteNonQuery();
                                File.Copy(txt_görselyolu.Text, yol, true);

                                MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set açform=@açform where id=@id", blg.bağlantı());
                                komut_FormKontrol.Parameters.AddWithValue("@açform", "true");
                                komut_FormKontrol.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));
                                komut_FormKontrol.ExecuteNonQuery();

                                MessageBox.Show("Servis formu başarıyla güncellendi.");
                                this.Close();
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            MySqlCommand komut_ekle = new MySqlCommand("insert into ts_servisform(yol,servisid,yüklemetarihiac) values(@yol,@servisid,@yüklemetarihiac)", blg.bağlantı());
                            komut_ekle.Parameters.Clear();
                            komut_ekle.Parameters.AddWithValue("@servisid", lbl_barcode_oku.Text.Remove(0, 3));
                            komut_ekle.Parameters.AddWithValue("@yol", yol);
                            komut_ekle.Parameters.AddWithValue("@yüklemetarihiac", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                            komut_ekle.ExecuteNonQuery();
                            File.Copy(txt_görselyolu.Text, yol);

                            MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set açform=@açform where id=@id", blg.bağlantı());
                            komut_FormKontrol.Parameters.AddWithValue("@açform", "true");
                            komut_FormKontrol.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));

                            MessageBox.Show("Servis formu başarıyla yüklendi.");                            
                            this.Close();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("" + lbl_barcode_oku.Text + " nolu servisin mevcut bir formu zaten var.");
                    }
                }
                else
                {
                    DialogResult durum = MessageBox.Show("Yüklemek istediğiniz servis no ile belgedeki servis no eşleşmiyor. Yinede devam etmek ister misiniz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult.Yes == durum)
                    {
                        try
                        {
                            File.Copy(txt_görselyolu.Text, yol);
                        }
                        catch (Exception)
                        {
                            DialogResult durum2 = MessageBox.Show("Yüklemek istediğiniz form halihazırda mevcut bulunuyor. Devam ederseniz güncellenecek devam etmek ister misiniz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (DialogResult.Yes == durum2)
                            {
                                MySqlCommand komut = new MySqlCommand("insert into ts_servisform(yol,servisid,yüklemetarihiac) values(@yol,@servisid,@yüklemetarihiac)", blg.bağlantı());
                                komut.Parameters.Clear();
                                komut.Parameters.AddWithValue("@servisid", lbl_barcode_oku.Text.Remove(0, 3));
                                komut.Parameters.AddWithValue("@yüklemetarihiac", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut.Parameters.AddWithValue("@yol", yol);
                                komut.ExecuteNonQuery();
                                File.Copy(txt_görselyolu.Text, yol, true);

                                MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set açform=@açform where id=@id", blg.bağlantı());
                                komut_FormKontrol.Parameters.AddWithValue("@açform", "true");
                                komut_FormKontrol.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));

                                MessageBox.Show("Servis formu başarıyla yüklendi.");
                                this.Close();
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {

                    }
                }
            }

            //sağ tık id bağımlı yükleme kapanış formu
            if (lbl_direkt.Text == "bağımlı_kapanış")
            {
                if (lbl_barcode_oku.Text.Remove(0, 3) == lbl_gelen_servisid.Text)
                {
                    try
                    {
                        try
                        {
                            MySqlCommand komut = new MySqlCommand("Select *from ts_servisform where servisid=@id", blg.bağlantı());
                            komut.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));
                            MySqlDataReader read = komut.ExecuteReader();
                            if (read.Read())
                            {
                                MySqlCommand komut_güncelle = new MySqlCommand("update ts_servisform set yolkapa=@yolkapa,servisidkapa=@servisidkapa,yüklemetarihikapama=@yüklemetarihikapama where servisid=@id", blg.bağlantı());
                                komut_güncelle.Parameters.AddWithValue("@yolkapa", yolkapa);
                                komut_güncelle.Parameters.AddWithValue("@yüklemetarihikapama", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut_güncelle.Parameters.AddWithValue("@servisidkapa", lbl_barcode_oku.Text.Remove(0, 3));
                                komut_güncelle.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));
                                komut_güncelle.ExecuteNonQuery();
                                File.Copy(txt_görselyolu.Text, yolkapa, true);

                                MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set kapaform=@kapaform where id=@id", blg.bağlantı());
                                komut_FormKontrol.Parameters.AddWithValue("@kapaform", "true");
                                komut_FormKontrol.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));
                                komut_FormKontrol.ExecuteNonQuery();

                                MessageBox.Show("Servis kapanış formu başarıyla yüklendi.");
                                this.Close();
                            }
                            else
                            {
                                MySqlCommand komut_ekle = new MySqlCommand("insert into ts_servisform(yolkapa,servisidkapa,yüklemetarihikapama) values(@yolkapa,@servisidkapa,@yüklemetarihikapama)", blg.bağlantı());
                                komut_ekle.Parameters.Clear();
                                komut_ekle.Parameters.AddWithValue("@servisidkapa", lbl_barcode_oku.Text.Remove(0, 3));
                                komut_ekle.Parameters.AddWithValue("@yüklemetarihikapama", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut_ekle.Parameters.AddWithValue("@yolkapa", yolkapa);
                                komut_ekle.ExecuteNonQuery();
                                File.Copy(txt_görselyolu.Text, yolkapa);

                                MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set kapaform=@kapaform where id=@id", blg.bağlantı());
                                komut_FormKontrol.Parameters.AddWithValue("@kapaform", "true");
                                komut_FormKontrol.Parameters.AddWithValue("@id", lbl_barcode_oku.Text.Remove(0, 3));
                                komut_FormKontrol.ExecuteNonQuery();

                                MessageBox.Show("Servis kapanış formu başarıyla yüklendi.");
                                this.Close();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Servis kapanış formu yükleme işlemi başarısız. (B01)");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("" + lbl_barcode_oku.Text + " nolu servisin mevcut bir formu zaten var.");
                    }
                }
                else
                {
                    MessageBox.Show("Formun servis nosu okunamadı yada yüklemek istediğiniz servis no ile formun servis nosu birbirinden farklı.");
                }
            }   
        }
    }
}