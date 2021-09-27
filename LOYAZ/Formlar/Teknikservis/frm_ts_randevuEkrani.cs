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

        private void frm_ts_randevuEkrani_Load(object sender, EventArgs e)
        {
            randevulariGetir();
        }

        public void randevulariGetir()
        {
            DateTime bugün = DateTime.
;            MySqlDataAdapter adp = new MySqlDataAdapter("select *from servis_hareketler", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            bindingSource1.DataSource = ds;
            bindingSource1.Filter = "tarih ='" + bugün.ToString() + "'";
            gridControlRandevuEkrani.DataSource = bindingSource1;
        }
    }
}
