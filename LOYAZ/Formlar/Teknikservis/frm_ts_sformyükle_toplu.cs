
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
using ZXing;
using System.IO;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using WIA;


namespace LOYAZ.Formlar.Teknikservis
{
    public partial class frm_ts_sformyükle_toplu : DevExpress.XtraEditors.XtraForm
    {
        public frm_ts_sformyükle_toplu()
        {
            InitializeComponent();
        }

        public string servisRaporlarıKlasörü = "" + Application.StartupPath + @"\servis raporları\";
        public string servisRaporlarıKlasörü_Kapanan = "" + Application.StartupPath + @"\servis raporları\kapananlar\";
        public string servisRaporlarıKlasörü_Tarama = "" + Application.StartupPath + @"\servis raporları\tarama\";

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        sqlbağlantısı blg = new sqlbağlantısı();

        private void Yenile()
        {
            var frm = (panel_ts_anasayfa)Application.OpenForms["panel_ts_anasayfa"];
            if (frm != null)
                frm.gridkontrolgöster();
        }

        private void btn_gözat_Click(object sender, EventArgs e)
        {
            yükle();

            BarcodeReader reader = new BarcodeReader();
            PictureEdit[] pictureEdit = new PictureEdit[50];
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "JPG|*.jpg";
            ofg.Multiselect = true;
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                int i = -1;
                foreach (string oge in ofg.FileNames)
                {
                    gridView_topluForm.AddNewRow();
                    SendKeys.Send("{down}");
                    i++;    
                    gridView_topluForm.SetRowCellValue(i, "yol", oge);
                    pictureEdit[i] = new PictureEdit();
                    pictureEdit[i].Name = "PictureEdit" + i.ToString();
                    pictureEdit[i].Image = Image.FromFile(gridView_topluForm.GetRowCellValue(i, "yol").ToString());
                    var result = reader.Decode((Bitmap)pictureEdit[i].Image);
                    try
                    {
                        if (Convert.ToString(result).Substring(0, 3) == "TSA")
                        {
                            gridView_topluForm.SetRowCellValue(i, "ad", result.ToString());
                            gridView_topluForm.SetRowCellValue(i, "sayı", i + 1);

                        }
                        if (Convert.ToString(result).Substring(0, 3) == "TSK")
                        {
                            gridView_topluForm.SetRowCellValue(i, "ad_kapa", result.ToString());
                            gridView_topluForm.SetRowCellValue(i, "sayı", i+1);
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
        }

        private void yükle()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sayı", Type.GetType("System.String"));
            dt.Columns.Add("yol", Type.GetType("System.String"));
            dt.Columns.Add("ad", Type.GetType("System.String"));
            dt.Columns.Add("ad_kapa", Type.GetType("System.String"));
            dt.Columns.Add("sonuç", Type.GetType("System.String"));
            gridControl1.DataSource = dt;
            gridView_topluForm.AddNewRow();
        }

        private void frm_ts_sformyükle_toplu_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo klasör = new DirectoryInfo(servisRaporlarıKlasörü_Tarama);

            foreach (FileInfo dosya in klasör.GetFiles())
            {
                dosya.Delete();
            }

            yükle();
            try
            {
                var deviceManager = new DeviceManager();

                for(int i=1; i<=deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }

                    ////listBox1.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());

                    //comboBoxEdit_tarama.Properties.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                    //comboBoxEdit_tarama.Properties.NullValuePrompt = "" + deviceManager.DeviceInfos[i].Properties["Name"].get_Value() + "";
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_tara_Click(object sender, EventArgs e)
        {
            if (gridView_topluForm.RowCount > 1 && gridView_topluForm.GetRowCellValue(0, "sonuç").ToString() == "")
            {
                DialogResult durum = XtraMessageBox.Show("Tarama işlemine başlarsanız liste yenilecek ve kaydedilmeyen formlar kaybolacak!" + Environment.NewLine + "Devam etmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    taramaİşlemi();
                }
                else
                {

                }
            }
            taramaİşlemi();
        }

        private void taramaİşlemi()
        {
            yükle();
            try
            {
                BarcodeReader reader = new BarcodeReader();
                PictureEdit[] pictureEdit = new PictureEdit[50];

                var deviceManager = new DeviceManager();

                DeviceInfo AvailableScanner = null;

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }
                    AvailableScanner = deviceManager.DeviceInfos[i];
                    break;
                }

                for (int i = 1; i <= Convert.ToInt32(textEdit1.Text); i++)
                {                   

                    gridView_topluForm.AddNewRow();
                    SendKeys.Send("{down}");
                    SendKeys.Send("{down}");

                    gridView_topluForm.SetRowCellValue(i-1, "sonuç", "Tarama başlatılıyor....");

                    var device = AvailableScanner.Connect();
                    var ScannerItem = device.Items[1];
                    
                    var imgFile = (ImageFile)ScannerItem.Transfer(FormatID.wiaFormatJPEG);

                    gridView_topluForm.SetRowCellValue(i - 1, "sonuç", "Taranıyor....");

                    string etiket = "" + blg.tarih().ToString(blg.tarih_format()) + "_" + blg.saat().ToString("HH_mm_ss") + "_" + i + "";

                    var yol = "" + servisRaporlarıKlasörü_Tarama + "" + etiket + ".jpg";

                    gridView_topluForm.SetRowCellValue(i-1, "sonuç", "Görüntü dosyaya aktarılıyor....");

                    imgFile.SaveFile(yol);

                    gridView_topluForm.SetRowCellValue(i-1, "sonuç", "Analiz ediliyor...");

                    gridView_topluForm.SetRowCellValue(i - 1, "yol", yol);

                    pictureEdit[i] = new PictureEdit();
                    pictureEdit[i].Name = "PictureEdit" + i.ToString();
                    pictureEdit[i].Image = Image.FromFile(gridView_topluForm.GetRowCellValue(i - 1, "yol").ToString());
                    var result = reader.Decode((Bitmap)pictureEdit[i].Image);
                    try
                    {
                        if (Convert.ToString(result).Substring(0, 3) == "TSA")
                        {
                            gridView_topluForm.SetRowCellValue(i - 1, "ad", result.ToString());
                            gridView_topluForm.SetRowCellValue(i - 1, "sayı", i);
                        }
                        if (Convert.ToString(result).Substring(0, 3) == "TSK")
                        {
                            gridView_topluForm.SetRowCellValue(i - 1, "ad_kapa", result.ToString());
                            gridView_topluForm.SetRowCellValue(i - 1, "sayı", i);
                        }

                        gridView_topluForm.SetRowCellValue(i-1, "sonuç", "Form Kaydedilmeye hazır");
                    }
                    catch (Exception)
                    {
                        gridView_topluForm.SetRowCellValue(i - 1, "sonuç", "Form algılanamadı");
                    }
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < gridView_topluForm.RowCount; i++)
            {            
                try
                {
                    string yol = "" + servisRaporlarıKlasörü + "\\" + gridView_topluForm.GetRowCellValue(i, "ad").ToString() + ".jpg";
                    string yolkapa = "" + servisRaporlarıKlasörü_Kapanan+"" + gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString() + ".jpg";

                    if (gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString() == "") // AÇMA
                    {
                        //TSA
                        MySqlCommand komut = new MySqlCommand("Select *from ts_servisform where servisid=@id", blg.bağlantı());
                        komut.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad").ToString().Trim('T', 'S', 'A', 'K')));
                        MySqlDataReader read = komut.ExecuteReader();
                        if (read.Read())
                        {
                            try
                            {
                                MySqlCommand komut_güncelle = new MySqlCommand("update ts_servisform set yol=@yol,servisid=@servisid,yüklemetarihiac=@yüklemetarihiac where servisidkapa=@id", blg.bağlantı());
                                komut_güncelle.Parameters.AddWithValue("@yol", yol);
                                komut_güncelle.Parameters.AddWithValue("@yüklemetarihiac", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut_güncelle.Parameters.AddWithValue("@servisid", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad").ToString().Trim('T', 'S', 'A', 'K'))); //CONVERT İLE DEĞİŞTİRMDİM 30.12.2020
                                komut_güncelle.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad").ToString().Trim('T', 'S', 'A', 'K'))); //CONVERT İLE DEĞİŞTİRMDİM 30.12.2020
                                komut_güncelle.ExecuteNonQuery();

                                File.Copy(gridView_topluForm.GetRowCellValue(i, "yol").ToString(), yol, true);

                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Açılış Formu Yüklendi");

                                MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set açform=@açform where id=@id", blg.bağlantı());
                                komut_FormKontrol.Parameters.AddWithValue("@açform", "true");
                                komut_FormKontrol.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad").ToString().Trim('T', 'S', 'A', 'K')));
                                komut_FormKontrol.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {
                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Başarısız (A1)");
                            }
                        }
                        else
                        {
                            try
                            {
                                MySqlCommand komut_ekle = new MySqlCommand("insert into ts_servisform(yol,servisid,yüklemetarihiac) values(@yol,@servisid,@yüklemetarihiac)", blg.bağlantı());
                                komut_ekle.Parameters.Clear();
                                komut_ekle.Parameters.AddWithValue("@servisid", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad").ToString().Trim('T', 'S', 'A', 'K')));
                                komut_ekle.Parameters.AddWithValue("@yol", yol);
                                komut_ekle.Parameters.AddWithValue("@yüklemetarihiac", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut_ekle.ExecuteNonQuery();
                                try
                                {
                                    File.Copy(gridView_topluForm.GetRowCellValue(i, "yol").ToString(), yol, true);
                                }
                                catch (Exception)
                                {
                                    gridView_topluForm.SetRowCellValue(i, "sonuç", "Taranan görüntüyü koplama başarısız (A1.2)");
                                }
                                
                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Açılış Formu Yüklendi");

                                MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set açform=@açform where id=@id", blg.bağlantı());
                                komut_FormKontrol.Parameters.AddWithValue("@açform", "true");
                                komut_FormKontrol.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad").ToString().Trim('T', 'S', 'A', 'K')));
                                komut_FormKontrol.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {
                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Başarısız (A2)");
                            }
                        }
                    }
                    if (gridView_topluForm.GetRowCellValue(i, "ad").ToString() == "") // KAPAMA
                    {
                        //TSK
                        MySqlCommand komut = new MySqlCommand("Select *from ts_servisform where servisid=@id", blg.bağlantı());
                        komut.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString().Trim('T', 'S', 'A', 'K')));
                        MySqlDataReader read = komut.ExecuteReader();
                        if (read.Read())
                        {
                            try
                            {
                                MySqlCommand komut_güncelle = new MySqlCommand("update ts_servisform set yolkapa=@yolkapa,servisidkapa=@servisidkapa,yüklemetarihikapama=@yüklemetarihikapama where servisid=@id", blg.bağlantı());
                                komut_güncelle.Parameters.AddWithValue("@yolkapa", yolkapa);
                                komut_güncelle.Parameters.AddWithValue("@yüklemetarihikapama", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut_güncelle.Parameters.AddWithValue("@servisidkapa", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString().Trim('T', 'S', 'A', 'K')));
                                komut_güncelle.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString().Trim('T', 'S', 'A', 'K'))); //CONVERT İLE DEĞİŞTİRMDİM 30.12.2020
                                komut_güncelle.ExecuteNonQuery();
                                try
                                {
                                    File.Copy(gridView_topluForm.GetRowCellValue(i, "yol").ToString(), yolkapa, true);

                                    MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set kapaform=@kapaform where id=@id", blg.bağlantı());
                                    komut_FormKontrol.Parameters.AddWithValue("@kapaform", "true");
                                    komut_FormKontrol.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString().Trim('T', 'S', 'A', 'K')));
                                    komut_FormKontrol.ExecuteNonQuery();
                                }
                                catch (Exception)
                                {
                                    gridView_topluForm.SetRowCellValue(i, "sonuç", "Dosya kopyalanırken bir hata meydana geldi");
                                }
                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Kapanış Formu Yüklendi");
                            }
                            catch (Exception)
                            {
                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Güncelleme İşlemi Başarısız (A3)");
                            }
                        }
                        else
                        {
                            try
                            {
                                MySqlCommand komut_ekle = new MySqlCommand("insert into ts_servisform(yolkapa,servisidkapa,yüklemetarihikapama) values(@yolkapa,@servisidkapa,@yüklemetarihikapama)", blg.bağlantı());
                                komut_ekle.Parameters.Clear();
                                komut_ekle.Parameters.AddWithValue("@servisidkapa", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString().Trim('T', 'S', 'A', 'K')));
                                komut_ekle.Parameters.AddWithValue("@yolkapa", yolkapa);
                                komut_ekle.Parameters.AddWithValue("@yüklemetarihikapama", Convert.ToDateTime(blg.tarih().ToString("dd/MM/yyyy HH:mm")));
                                komut_ekle.ExecuteNonQuery();
                                File.Copy(gridView_topluForm.GetRowCellValue(i, "yol").ToString(), yolkapa, true);
                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Kapanış Formu Yüklendi");

                                MySqlCommand komut_FormKontrol = new MySqlCommand("update ts_servis set kapaform=@kapaform where id=@id", blg.bağlantı());
                                komut_FormKontrol.Parameters.AddWithValue("@kapaform", "true");
                                komut_FormKontrol.Parameters.AddWithValue("@id", Convert.ToInt32(gridView_topluForm.GetRowCellValue(i, "ad_kapa").ToString().Trim('T', 'S', 'A', 'K')));
                                komut_FormKontrol.ExecuteNonQuery();

                                if (File.Exists(gridView_topluForm.GetRowCellValue(i, "yol").ToString()))
                                {
                                    File.Delete(gridView_topluForm.GetRowCellValue(i, "yol").ToString());
                                }
                                else
                                {

                                }
                            }
                            catch (Exception)
                            {
                                gridView_topluForm.SetRowCellValue(i, "sonuç", "Ekleme İşlemi Başarısız (A4)");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                  
                }               
            }
            Yenile();
        }

        private void frm_ts_sformyükle_toplu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}