using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MySql.Data.MySqlClient;
using System.Data;

namespace LOYAZ.Raporlar.ts
{
    public partial class rpr_serviskapama_a4 : DevExpress.XtraReports.UI.XtraReport
    {
        sqlbağlantısı blg = new sqlbağlantısı();

        public rpr_serviskapama_a4()
        {
            InitializeComponent();

            MySqlCommand komut = new MySqlCommand("select *from firma", blg.bağlantı());
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                lbl_firma_ünvan.Text = read["firmadad"].ToString();
            }

            güncellemeleriyazdır();

        }

        private void güncellemeleriyazdır()
        {

        }
    }
}
