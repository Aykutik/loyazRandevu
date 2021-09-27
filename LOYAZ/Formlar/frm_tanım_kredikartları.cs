using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;

namespace LOYAZ.Formlar
{
    public partial class frm_tanım_kredikartları : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_tanım_kredikartları()
        {
            InitializeComponent();
            Data();
            lk_bankalarData();
            //bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
        }

        public int id = 0;
        public int row = 0;

        sqlbağlantısı blg = new sqlbağlantısı();

        private void Data()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select *from tanım_kredikartları", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            gridControl_kredikartları.DataSource = ds;
        }

        private void lk_bankalarData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select *from tanım_bankalar", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            lk_kredikartları_bankalar.Properties.DataSource = ds;
            lk_kredikartları_bankalar.Properties.ValueMember = "ad";
            lk_kredikartları_bankalar.Properties.DisplayMember = "ad";
        }

        private void btn_yeni_ItemClick(object sender, ItemClickEventArgs e)
        {
            grp_ekleVEdüzenle.Text = "Yeni";
            grp_ekleVEdüzenle.Visible = true;
            txt_ad.Text = "";
            txt_sonüç.Text = "";
            lk_kredikartları_bankalar.Properties.NullText = "";
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            id= Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, "id"));
            row = gridView.FocusedRowHandle;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            txt_ad.Text = gridView.GetRowCellValue(row, "ad").ToString();
            txt_sonüç.Text = gridView.GetRowCellValue(row, "sonüc").ToString();
            lk_kredikartları_bankalar.Properties.NullText= gridView.GetRowCellValue(row, "banka").ToString();
            id = Convert.ToInt32(gridView.GetRowCellValue(row, "id"));
            grp_ekleVEdüzenle.Text = "Düzenle";
            grp_ekleVEdüzenle.Visible = true;
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (grp_ekleVEdüzenle.Text == "Düzenle")
            {
                try
                {
                    MySqlCommand komut_refyeni = new MySqlCommand("update tanım_kredikartları set ad=@ad,sonüc=@sonüc,banka=@banka where id=@id", blg.bağlantı());
                    komut_refyeni.Parameters.Clear();
                    komut_refyeni.Parameters.AddWithValue("@sonüc", txt_sonüç.Text);
                    komut_refyeni.Parameters.AddWithValue("@banka", lk_kredikartları_bankalar.Text);
                    komut_refyeni.Parameters.AddWithValue("@ad", txt_ad.Text);
                    komut_refyeni.Parameters.AddWithValue("@id", id);
                    komut_refyeni.ExecuteNonQuery();
                    lk_bankalarData();
                    Data();
                    grp_ekleVEdüzenle.Visible = false;
                    stk_dataGüncelle();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Kredi kartı ne yazık ki güncellenemedi");                   
                }
            }
            else
            {
                try
                {
                    MySqlCommand komut = new MySqlCommand("insert into tanım_kredikartları (ad,sonüc,banka) " +
                    "values(@ad,@sonüc,@banka)", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@sonüc", txt_sonüç.Text);
                    komut.Parameters.AddWithValue("@banka", lk_kredikartları_bankalar.Text);
                    komut.Parameters.AddWithValue("@ad", txt_ad.Text);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    Data();
                    lk_bankalarData();
                    grp_ekleVEdüzenle.Visible = false;
                    stk_dataGüncelle();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Kredi kartı ne yazık ki kaydedilemedi");
                }
            }
        }

        private void stk_dataGüncelle()
        {
            var frm2 = (frm_stk_anasayfa_panel)Application.OpenForms["frm_stk_anasayfa_panel"];
            if (frm2 != null)
                frm2.sl_fatura_kredikartıData();

        }
    }
}