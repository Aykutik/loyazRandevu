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
using System.Deployment.Internal;

namespace LOYAZ.Formlar.Satış
{
    public partial class frm_st_ürünbul : DevExpress.XtraEditors.XtraForm
    {
        public frm_st_ürünbul()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        private void frm_st_ürünbul_Load(object sender, EventArgs e)
        {
            gridData();
        }

        private void gridData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select *from ür_varyant", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            BindingSource bs = new BindingSource();
            bs.DataSource = ds;
            gridControl_ürünbul.DataSource = bs;
        }

        public int id = 0;
        public string ürünkodu = "";
        public string varyant = "";

        private void gridControl_ürünbul_DoubleClick(object sender, EventArgs e)
        {
            id = gridView_ürünbul.FocusedRowHandle;

            var frm2 = (frm_st_anasayfa_panel)Application.OpenForms["frm_st_anasayfa_panel"];
            if (frm2 != null)
                frm2.txt_barkod.Text = gridView_ürünbul.GetRowCellValue(id, "barkod").ToString();
            frm2.sepeteEkle();
            this.Close();
        }
    }
}