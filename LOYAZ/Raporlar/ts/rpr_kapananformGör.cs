using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using Renci.SshNet.Messages;
using System.Windows.Forms;

namespace LOYAZ.Raporlar.ts
{
    public partial class rpr_kapananformGör : DevExpress.XtraReports.UI.XtraReport
    {
        public rpr_kapananformGör()
        {
            InitializeComponent();
        }
        sqlbağlantısı blg = new sqlbağlantısı();

        private void btn_DosyayıAç_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void lbl_servisid_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            if (lbl_kontrol.Text=="kapama")
            {
                try
                {
                    string image_outputDir = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);// debug klasörü neredeyse pathi getir.
                    DirectoryInfo df = new DirectoryInfo(image_outputDir + @"\servis raporları\kapananlar\TSK" + lbl_servisid.Text + ".jpg"); // O klasörün içindeki ilgili resmi bul
                    System.Diagnostics.Process.Start(df.ToString()); // ilgili dosyayı ac
                }
                catch (Exception)
                {
                    MessageBox.Show("TSA" + lbl_servisid.Text + " nolu servisin kapanış formu bulunamadı. Slinmiş olabilir.");
                }
            }
            else
            {
                try
                {
                    string image_outputDir = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);// debug klasörü neredeyse pathi getir.
                    DirectoryInfo df = new DirectoryInfo(image_outputDir + @"\servis raporları\TSA" + lbl_servisid.Text + ".jpg"); // O klasörün içindeki ilgili resmi bul
                    System.Diagnostics.Process.Start(df.ToString()); // ilgili dosyayı ac
                }
                catch (Exception)
                {
                    MessageBox.Show("TSA"+lbl_servisid.Text+" nolu servisin açılış formu bulunamadı. Slinmiş olabilir.");
                }
            }
        }
    }
}
