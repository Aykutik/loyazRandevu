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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace LOYAZ.Formlar.Stok
{
    public partial class frm_stk_özellikEkle : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        sqlbağlantısı blg = new sqlbağlantısı();

        public string hangiData = "";
        public string hangiBağ = "";
        public string bağ = "";
        public string bağadı = "";
        public int id = 0;
        public int row = 0;

        public frm_stk_özellikEkle()
        {
            InitializeComponent();
            

            //bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
        }

        private void frm_stk_özellikEkle_Load(object sender, EventArgs e)
        {
            gridControl_özellikEkle.DataSource = datasource(hangiData);
            sl_bağ.Properties.DataSource = bağData(hangiBağ);
            sl_bağ.Properties.ValueMember = "ad";
            sl_bağ.Properties.DisplayMember = "ad";
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl_özellikEkle.ShowRibbonPrintPreview();
        }

        public DataTable datasource(string tablo)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select "+bağ+"ad,id from "+tablo+"", blg.bağlantı());
            DataTable ds = new DataTable();
            //ds.Columns.Add("["+bağadı+"]", Type.GetType("System.String"));
            ds.Columns.Add("ad", Type.GetType("System.String"));
            //ds.Columns.Add("id", Type.GetType("System.String"));
            adp.Fill(ds);
            return ds;
        }

        private DataTable bağData(string tablo)
        {
            try
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("select ad,id from " + tablo + "", blg.bağlantı());
                DataTable ds = new DataTable();
                //ds.Columns.Add("["+bağadı+"]", Type.GetType("System.String"));
                ds.Columns.Add("ad", Type.GetType("System.String"));
                //ds.Columns.Add("id", Type.GetType("System.String"));
                adp.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                DataTable ds = new DataTable();
                ds.Columns.Add("ad", Type.GetType("System.String"));
                return ds;
            }            
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            groupControl1.Text = "Yeni";
            groupControl1.Visible = true;
        }

        private void gridView_özellikEkle_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            id=Convert.ToInt32(gridView_özellikEkle.GetRowCellValue(gridView_özellikEkle.FocusedRowHandle, "id"));
            row = gridView_özellikEkle.FocusedRowHandle;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bağ != "")
            {
                sl_bağ.Properties.NullText = gridView_özellikEkle.GetRowCellValue(row, "" + bağ.Trim(',') + "").ToString();
                txt_ad.Text = gridView_özellikEkle.GetRowCellValue(row, "ad").ToString();
                id = Convert.ToInt32(gridView_özellikEkle.GetRowCellValue(row, "id"));
                groupControl1.Text = "Düzenle";
                groupControl1.Visible = true;
            }
            else
            {   
                txt_ad.Text = gridView_özellikEkle.GetRowCellValue(row, "ad").ToString();
                id = Convert.ToInt32(gridView_özellikEkle.GetRowCellValue(row, "id"));
                groupControl1.Text = "Düzenle";
                groupControl1.Visible = true;
            }
        }

        private void btn_sonuçButon_Click(object sender, EventArgs e)
        {
            if (bağ!="")
            {
                if (groupControl1.Text == "Düzenle")
                {
                    MySqlCommand komut_refyeni = new MySqlCommand("update " + hangiData + " set ad=@ad," + bağ.Trim(',') + "=@bağ where id=@id", blg.bağlantı());
                    komut_refyeni.Parameters.Clear();
                    komut_refyeni.Parameters.AddWithValue("@bağ", sl_bağ.Text);
                    komut_refyeni.Parameters.AddWithValue("@ad", txt_ad.Text);
                    komut_refyeni.Parameters.AddWithValue("@id", id);
                    komut_refyeni.ExecuteNonQuery();

                    groupControl1.Visible = false;
                    gridControl_özellikEkle.DataSource = datasource(hangiData);

                    stk_dataGüncelle();
                }
                else
                {
                    MySqlCommand komut = new MySqlCommand("insert into " + hangiData + " (" + bağ + "ad) " +
                              "values(@bağ,@ad)", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@bağ", sl_bağ.Text);
                    komut.Parameters.AddWithValue("@ad", txt_ad.Text);
                    komut.ExecuteNonQuery();
                    komut.Dispose();

                    groupControl1.Visible = false;
                    gridControl_özellikEkle.DataSource = datasource(hangiData);

                    stk_dataGüncelle();
                }
            }
            else
            {
                if (groupControl1.Text == "Düzenle")
                {
                    MySqlCommand komut_refyeni = new MySqlCommand("update " + hangiData + " set ad=@ad where id=@id", blg.bağlantı());
                    komut_refyeni.Parameters.Clear();
                    komut_refyeni.Parameters.AddWithValue("@ad", txt_ad.Text);
                    komut_refyeni.Parameters.AddWithValue("@id", id);
                    komut_refyeni.ExecuteNonQuery();

                    groupControl1.Visible = false;
                    gridControl_özellikEkle.DataSource = datasource(hangiData);

                    stk_dataGüncelle();
                }
                else
                {
                    MySqlCommand komut = new MySqlCommand("insert into " + hangiData + " (ad) " +
                              "values(@ad)", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@ad", txt_ad.Text);
                    komut.ExecuteNonQuery();
                    komut.Dispose();

                    groupControl1.Visible = false;
                    gridControl_özellikEkle.DataSource = datasource(hangiData);

                    stk_dataGüncelle();
                }
            }
        }

        private void stk_dataGüncelle()
        {
            var frm2 = (frm_stk_anasayfa_panel)Application.OpenForms["frm_stk_anasayfa_panel"];
            if (frm2 != null)
                frm2.yeniÜrün_ürüntipiData();
                frm2.yeniÜrün_ÜrünGrubuData();
                frm2.yeniÜrün_markaData();
                frm2.yeniürün_varyantData();
        }

        private void gridView_özellikEkle_DoubleClick(object sender, EventArgs e)
        {
            var frm = (frm_stk_anasayfa_panel)Application.OpenForms["frm_stk_anasayfa_panel"];
            if (frm != null)
                frm.ad = gridView_özellikEkle.GetRowCellValue(row, "ad").ToString();
            frm.lbl_yeniürün_varyant.Text = gridView_özellikEkle.GetRowCellValue(row, "ad").ToString();
            
            this.Hide();
            var frm2 = (frm_stk_anasayfa_panel)Application.OpenForms["frm_stk_anasayfa_panel"];
            if (frm2 != null)
                frm2.labelControl8.Text = "şimdi";
        }

        private void frm_stk_özellikEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            var frm = (frm_stk_anasayfa_panel)Application.OpenForms["frm_stk_anasayfa_panel"];
            if (frm != null)
                frm.labelControl8.Text = "şimdi";
        }
    }
}