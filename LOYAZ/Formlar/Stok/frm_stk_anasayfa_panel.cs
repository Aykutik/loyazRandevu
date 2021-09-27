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
using DevExpress.XtraBars.ViewInfo;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGauges.Core.Model;
using LOYAZ.Formlar.Stok;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Senders;
using DevExpress.CodeParser;
using LOYAZ.Formlar;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;

namespace LOYAZ
{
    public partial class frm_stk_anasayfa_panel : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        public frm_stk_anasayfa_panel()
        {
            InitializeComponent();
        }

        sqlbağlantısı blg = new sqlbağlantısı();

        #region Değişkenler
        public int row = 0;
        public string fatRefAdı = "";
        public int fatRefNo = 0;
        public string ad = "";
        #endregion

        public string kullanıcı()
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            string kullanıcı = frm.drop_kullanıcı.Text;
            return kullanıcı;
        }

        private void btn_anasyfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            frm.panel_ana.Controls.Clear();

            frm_anasayfa_panel panel = new frm_anasayfa_panel();
            panel.TopLevel = false;

            frm.panel_ana.Controls.Add(panel);

            panel.Show();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
        }


        private void frm_stk_anasayfa_panel_Load(object sender, EventArgs e)
        {
            gridControlStok();

            tanım_ödemeYöntemiData();

            yeniÜrün_GridcontrolData();
            yeniÜrün_ürüntipiData();
            yeniÜrün_markaData();
            yeniÜrün_ÜrünGrubuData();
            yeniürün_varyantData();
            yeniürün_vergiGrubu();

            gridControlÜrünYÜkle_İrsaliye();
            sl_irsaliye_ürünkoduData();

            datasourceFatura();
            sl_fatura_ürünkoduData();
            faturaTedarikçiler();
            sl_fatura_FatRefNoData();
            sl_fatura_varyantData();
            fatura_tedarikçiCariGridcontData();
            sl_fatura_kredikartıData();
            sl_fatura_bankalarData();

            dt_faturaİşlemTarihi.DateTime = DateTime.Now;
            dt_faturaFaturaTarihi.DateTime = DateTime.Now;
        }

        

        #region #ÜRÜN YÜKLE

        public void yeniÜrün_GridcontrolData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ad", Type.GetType("System.String"));
            dt.Columns.Add("ürünkodu", Type.GetType("System.String"));
            dt.Columns.Add("marka", Type.GetType("System.String"));
            dt.Columns.Add("vergigrp", Type.GetType("System.String"));
            dt.Columns.Add("satışfiyat", Type.GetType("System.String"));
            dt.Columns.Add("varyant", Type.GetType("System.String"));
            dt.Columns.Add("krtkstok", Type.GetType("System.String"));
            dt.Columns.Add("ürüntipi", Type.GetType("System.String"));
            dt.Columns.Add("barkod", Type.GetType("System.String"));
            dt.Columns.Add("ürüngrubu", Type.GetType("System.String"));
            dt.Columns.Add("id", Type.GetType("System.String"));
            gridControl_yeniürün.DataSource = dt;
            gridView_ürünyükle.AddNewRow();
        }

        #region yeniürün_ürüntipi

        public void yeniÜrün_ürüntipiData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select ad,id from ür_ürüntipi", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            sl_Yeniürün_ürüntipi.ValueMember = "ad";
            sl_Yeniürün_ürüntipi.DisplayMember = "ad";
            sl_Yeniürün_ürüntipi.DataSource = ds;
        }

        private void sl_Yeniürün_ürüntipi_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
            frm_stk_özellikEkle frm = new frm_stk_özellikEkle();
            frm.hangiData = "ür_ürüntipi";
            frm.hangiBağ = "";
            frm.bağ = "";
            frm.bağadı = "";
            frm.lbl_ad.Text = "AD:";
            frm.lbl_bağ.Text = "";
            frm.sl_bağ.Visible = false;
            frm.ShowDialog();
        }

        //ÜRÜN TİPİİİİ
        private void sl_Yeniürün_ürüntipi_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            row = gridView_ürünyükle.FocusedRowHandle;

            //if (row <= gridView_ürünyükle.RowCount-1)
            //{
            //    SendKeys.Send("{down}");
            //    SendKeys.Send("{up}");
            //    gridView_ürünyükle.AddNewRow();
            //    SendKeys.Send("{down}");
            //    SendKeys.Send("{up}");
            //}
        }

        #endregion

        #region yeniürün_marka
        public void yeniÜrün_markaData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select ad from ür_marka", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            sl_yeniürün_marka.ValueMember = "ad";
            sl_yeniürün_marka.DisplayMember = "ad";
            sl_yeniürün_marka.DataSource = ds;
        }

        private void sl_yeniürün_marka_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
            frm_stk_özellikEkle frm = new frm_stk_özellikEkle();
            frm.hangiData = "ür_marka";
            frm.hangiBağ = "";
            frm.bağ = "";
            frm.bağadı = "";
            frm.lbl_ad.Text = "AD:";
            frm.lbl_bağ.Text = "Bağ:";
            frm.sl_bağ.Enabled = false;
            frm.ShowDialog();
        }

        private void sl_yeniürün_marka_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            row = gridView_ürünyükle.FocusedRowHandle;

            if (row < 0)
            {
                SendKeys.Send("{down}");
                SendKeys.Send("{up}");
            }
        }

        #endregion

        #region yeniürün_ürüngrubu

        public void yeniÜrün_ÜrünGrubuData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select ad from ür_ürüngrubu", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            sl_Yeniürün_ürüngrubu.ValueMember = "ad";
            sl_Yeniürün_ürüngrubu.DisplayMember = "ad";
            sl_Yeniürün_ürüngrubu.DataSource = ds;
        }

        private void sl_Yeniürün_ürüngrubu_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
            frm_stk_özellikEkle frm = new frm_stk_özellikEkle();
            frm.hangiData = "ür_ürüngrubu";
            frm.hangiBağ = "";
            frm.bağ = "";
            frm.bağadı = "";
            frm.lbl_ad.Text = "AD:";
            frm.lbl_bağ.Text = "Bağ:";
            frm.sl_bağ.Enabled = false;
            frm.ShowDialog();
        }

        private void sl_Yeniürün_ürüngrubu_Leave(object sender, EventArgs e)
        {
            row = gridView_ürünyükle.FocusedRowHandle;
            ÜrünKoduAdıOluştur();
        }

        private void gridView_YeniÜrün_ürüngrubu_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{down}");
            SendKeys.Send("{up}");

            if (row < 0)
            {
                SendKeys.Send("{down}");
                SendKeys.Send("{up}");
            }
        }

        private void lbl_yeniürün_ürüngrubu_TextChanged(object sender, EventArgs e)
        {
            string ürünkodu = lbl_yeniürün_ürüngrubu.Text;

            //MySqlCommand komut_var = new MySqlCommand("select ad from ür_varyant where ürünkodu=@id", blg.bağlantı());
            //komut_var.Parameters.AddWithValue("@id", ürünkodu);
            //komut_var.ExecuteNonQuery();
            //MySqlDataReader oku_var = komut_var.ExecuteReader();
            //ComboBox_Fatura_Varyant2.Items.Clear();
            //while (oku_var.Read())
            //{
            //    ComboBox_Fatura_Varyant2.Items.Add(oku_var["ad"].ToString());
            //}
            //oku_var.Close();
        }

        #endregion

        #region Ürünkodu ve adı oluştur

        LabelControl[] labels = new LabelControl[3];
        public string hatakontrol = "";

        private void ÜrünKoduAdıOluştur()
        {
            string hatakodu = "";
            try
            {
                for (int i = 0; i < gridView_ürünyükle.RowCount; i++)
                {
                    string ürüntipi = gridView_ürünyükle.GetRowCellDisplayText(i, "ürüntipi").ToString();
                    string marka = gridView_ürünyükle.GetRowCellDisplayText(i, "marka").ToString();
                    string ürüngrubu = gridView_ürünyükle.GetRowCellDisplayText(i, "ürüngrubu").ToString();
                    string varyant = gridView_ürünyükle.GetRowCellDisplayText(i, "varyant").ToString();

                    string[] ürüngrubuKelimeleri = ürüngrubu.Split(' ');
                    int s = 1;

                    if (hatakodu != ürüngrubu)
                    {
                        foreach (var j in ürüngrubuKelimeleri)
                        {
                            var kelime = j.Trim();
                            labels[s] = new LabelControl();
                            labels[s].Text = kelime;
                            s++;
                        }

                        try
                        {
                            if (labels[2].Text == "")
                            {
                                string sonuç = "" + blg.tarih().ToString("yy") + "" + ürüntipi.Substring(0, 1) + "" + marka.Substring(0, 1) + "" + labels[1].Text.Substring(0, 1) + "" + labels[2].Text.Substring(0, 1) + "";
                                string sonuçad = "" + sonuç + " " + marka + " " + ürüngrubu + "";
                                gridView_ürünyükle.SetRowCellValue(i, "ürünkodu", sonuç);
                                gridView_ürünyükle.SetRowCellValue(i, "ad", sonuçad);
                                labels[2].Text = "";
                            }
                            else
                            {
                                string sonuç = "" + blg.tarih().ToString("yy") + "" + ürüntipi.Substring(0, 1) + "" + marka.Substring(0, 1) + "" + labels[1].Text.Substring(0, 1) + "" + labels[2].Text.Substring(0, 1) + "";
                                string sonuçad = "" + sonuç + " " + marka + " " + ürüngrubu + "";
                                gridView_ürünyükle.SetRowCellValue(i, "ürünkodu", sonuç);
                                gridView_ürünyükle.SetRowCellValue(i, "ad", sonuçad);
                                labels[2].Text = "";
                            }
                        }
                        catch (Exception)
                        {
                            string sonuç = "" + blg.tarih().ToString("yy") + "" + ürüntipi.Substring(0, 1) + "" + marka.Substring(0, 1) + "" + labels[1].Text.Substring(0, 1) + "X";
                            string sonuçad = "" + sonuç + " " + marka + " " + ürüngrubu + "";
                            gridView_ürünyükle.SetRowCellValue(i, "ürünkodu", sonuç);
                            gridView_ürünyükle.SetRowCellValue(i, "ad", sonuçad);
                        }
                    }
                    else
                    {

                    }


                }
            }
            catch (Exception)
            {

            }
        }

        private void repositoryItemButtonEdit_irsaliyeAltaKopyala_Click(object sender, EventArgs e)
        {
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ürüntipi", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ürüntipi"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "marka", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "marka"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ürüngrubu", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ürüngrubu"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ürünkodu", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ürünkodu"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ad", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ad"));
            MessageBox.Show("sdasd");
        }

        private void repositoryItemButtonEdit_irsaliyeAltaKopyala_Enter(object sender, EventArgs e)
        {
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ürüntipi", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ürüntipi"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "marka", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "marka"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ürüngrubu", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ürüngrubu"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ürünkodu", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ürünkodu"));
            gridView_ürünyükle.SetRowCellValue(gridView_ürünyükle.FocusedRowHandle + 1, "ad", gridView_ürünyükle.GetRowCellValue(gridView_ürünyükle.FocusedRowHandle, "ad"));
            MessageBox.Show("sdasd");
        }

        private void repositoryItemButtonEdit_yeniürün_altakopyala_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            row = gridView_ürünyükle.FocusedRowHandle;

            gridView_ürünyükle.SetRowCellValue(row + 1, "ad", gridView_ürünyükle.GetRowCellValue(row, "ad"));
            gridView_ürünyükle.SetRowCellValue(row + 1, "ürünkodu", gridView_ürünyükle.GetRowCellValue(row, "ürünkodu"));
            gridView_ürünyükle.SetRowCellValue(row + 1, "marka", gridView_ürünyükle.GetRowCellValue(row, "marka"));
            gridView_ürünyükle.SetRowCellValue(row + 1, "ürüntipi", gridView_ürünyükle.GetRowCellValue(row, "ürüntipi"));

            SendKeys.Send("{down}");
            SendKeys.Send("{up}");

            for (int i = 0; i < gridView_ürünyükle.RowCount; i++)
            {
                if (gridView_ürünyükle.GetRowCellValue(i, "ürüntipi").ToString() == "")
                {
                    gridView_ürünyükle.DeleteRow(i);
                }
            }
        }

        private void gridView_ürünyükle_RowStyle(object sender, RowStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    //string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Kategori"]); // Kolon adı ile

            //    if (hatakontrol != "")
            //    {
            //        e.Appearance.BackColor = Color.Blue;
            //        // sadece BackColor 'e renk verirseniz satır tek renk olur
            //        // BackColor2 'yede farklı renk verirseniz BackColor'dan  BackColor2'ye radyan geçişli
            //        // olur.
            //    }
            //    else
            //    {
            //        e.Appearance.BackColor = Color.White;
            //    }
            //}
        }

        #endregion

        public void yeniürün_varyantData()
        {
            MySqlCommand adp = new MySqlCommand("select ad,ürüngrubu from ür_var_varyant", blg.bağlantı());
            MySqlDataAdapter yükle = new MySqlDataAdapter(adp);
            DataTable ds = new DataTable();
            yükle.Fill(ds);

            sl_Yeniürün_varyant.DataSource = ds;
            sl_Yeniürün_varyant.ValueMember = "ad";
            sl_Yeniürün_varyant.DisplayMember = "ad";
        }

        private void sl_Yeniürün_varyant_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
            frm_stk_özellikEkle frm = new frm_stk_özellikEkle();
            frm.hangiData = "ür_var_varyant";
            frm.hangiBağ = "ür_ürüngrubu";
            frm.bağ = "ürüngrubu,"; // , unutma
            frm.bağadı = "Ürün Grubu";
            frm.lbl_ad.Text = "AD:";
            frm.lbl_bağ.Text = "Ürün Grubu:";
            frm.ShowDialog();
        }

        private void sl_Yeniürün_varyant_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            row = gridView_ürünyükle.FocusedRowHandle;

            if (gridView_ürünyükle.RowCount - 1 == row)
            {
                gridView_ürünyükle.AddNewRow();
                SendKeys.Send("{down}");
                SendKeys.Send("{up}");
            }

            (sender as SearchLookUpEdit).Properties.View.FindFilterText = gridView_ürünyükle.GetRowCellValue(row, "ürüngrubu").ToString().Trim();
        }

        private void sl_Yeniürün_varyant_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            row = gridView_ürünyükle.FocusedRowHandle;
        }

        private void sl_Yeniürün_varyant_Leave(object sender, EventArgs e)
        {

            if (gridView_ürünyükle.RowCount - 1 == row)
            {
                gridView_ürünyükle.AddNewRow();
                SendKeys.Send("{down}");
                SendKeys.Send("{up}");
            }

            string kontrolürün = "";
            string ürünkodu = gridView_ürünyükle.GetRowCellValue(row, "ürünkodu").ToString();
            string varyant = gridView_ürünyükle.GetRowCellDisplayText(row, "varyant").ToString();
            MySqlCommand komut_var = new MySqlCommand("select ad from ür_varyant where ürünkodu=@ürünkodu and ad=@varyant", blg.bağlantı());
            komut_var.Parameters.AddWithValue("@ürünkodu", ürünkodu);
            komut_var.Parameters.AddWithValue("@varyant", varyant);
            komut_var.ExecuteNonQuery();
            MySqlDataReader oku_var = komut_var.ExecuteReader();
            while (oku_var.Read())
            {
                kontrolürün = oku_var["ad"].ToString();
            }
            oku_var.Close();

            if (kontrolürün != "")
            {
                gridView_ürünyükle.SetRowCellValue(row, "varyant", "");
                XtraMessageBox.Show("" + ürünkodu + " kodlu ürünün " + varyant + " kaydı bulunmaktadır!");
            }

            if (gridView_ürünyükle.RowCount != 2)
            {
                for (int i = 0; i < row; i++)
                {
                    if (gridView_ürünyükle.GetRowCellValue(i, "ürünkodu").ToString() == ürünkodu && gridView_ürünyükle.GetRowCellDisplayText(i, "varyant").ToString() == varyant)
                    {
                        gridView_ürünyükle.SetRowCellValue(row, "varyant", "");
                        XtraMessageBox.Show("" + ürünkodu + " kodlu ürünün " + varyant + " kaydı listede bulunmaktadır!");
                    }
                }
            }
        }

        private void sl_Yeniürün_varyant_Click(object sender, EventArgs e)
        {
            row = gridView_ürünyükle.FocusedRowHandle;
            (sender as SearchLookUpEdit).Properties.View.FindFilterText = gridView_ürünyükle.GetRowCellValue(row, "ürüngrubu").ToString().Trim();
        }

        public string önceki = "";

        private void sl_Yeniürün_varyant_EditValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{down}");
            SendKeys.Send("{up}");

            string kontrolürün = "";
            string ürünkodu = gridView_ürünyükle.GetRowCellValue(row, "ürünkodu").ToString();
            string varyant = gridView_ürünyükle.GetRowCellDisplayText(row, "varyant").ToString();
            MySqlCommand komut_var = new MySqlCommand("select ad from ür_varyant where ürünkodu=@ürünkodu and ad=@varyant", blg.bağlantı());
            komut_var.Parameters.AddWithValue("@ürünkodu", ürünkodu);
            komut_var.Parameters.AddWithValue("@varyant", varyant);
            komut_var.ExecuteNonQuery();
            MySqlDataReader oku_var = komut_var.ExecuteReader();
            while (oku_var.Read())
            {
                kontrolürün = oku_var["ad"].ToString();
                önceki = ürünkodu;
            }
            oku_var.Close();

            if (kontrolürün != "" && ürünkodu != önceki)
            {
                XtraMessageBox.Show("" + ürünkodu + " kodlu ürünün " + varyant + " kaydı bulunmaktadır!");
            }
        }

        private void yeniürün_vergiGrubu()
        {
            MySqlCommand komut_var = new MySqlCommand("select ad from ür_vergi", blg.bağlantı());
            komut_var.ExecuteNonQuery();
            MySqlDataReader oku_var = komut_var.ExecuteReader();
            repositoryItemComboBox_Vergig.Items.Clear();
            while (oku_var.Read())
            {
                repositoryItemComboBox_Vergig.Items.Add(oku_var["ad"].ToString());
            }
            oku_var.Close();
        }

        private void btn_ürünKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<string> hatalar = new List<string>();

            for (int i = 0; i < gridView_ürünyükle.RowCount; i++)
            {
                if (gridView_ürünyükle.GetRowCellValue(i, "ürünkodu").ToString().Trim() != "")
                {
                    int satır = i + 1;
                    string sil = gridView_ürünyükle.GetRowCellValue(i, "varyant").ToString().Trim();

                    MySqlCommand komut_var = new MySqlCommand("select *from ür_varyant where barkod=@barkod", blg.bağlantı());
                    komut_var.Parameters.AddWithValue("@barkod", gridView_ürünyükle.GetRowCellValue(i, "barkod").ToString().Trim());
                    komut_var.ExecuteNonQuery();
                    MySqlDataReader oku_var = komut_var.ExecuteReader();
                    while (oku_var.Read())
                    {
                        string ürün = oku_var["ürünkodu"].ToString().Trim();
                        hatalar.Add("" + satır + ". satırdaki ürünün barkodu başva bir üründe tanımlanmış!(Ürün Kodu: "+ürün+")");
                    }
                    oku_var.Close();

                    if (gridView_ürünyükle.GetRowCellValue(i, "satışfiyat").ToString().Trim() == "")
                    {
                        hatalar.Add("" + satır + ". satırdaki ürünün satış fiyatı girilmemiş!");
                    }
                    if (gridView_ürünyükle.GetRowCellValue(i, "varyant").ToString().Trim() == "")
                    {
                        hatalar.Add("" + satır + ". satırdaki ürünün varyantı girilmemiş!");
                    }
                    if (gridView_ürünyükle.GetRowCellValue(i, "barkod").ToString().Trim() == "")
                    {
                        hatalar.Add("" + satır + ". satırdaki ürünün barkodu girilmemiş!");
                    }
                }
            }
            if (hatalar.Count > 0)
            {
                string mesaj = "";
                if (hatalar.Count == 10)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[7] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[8] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[9] + "";
                }
                if (hatalar.Count == 9)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[7] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[8] + "";
                }
                if (hatalar.Count == 8)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[7] + "";
                }
                if (hatalar.Count == 7)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[6] + "";
                }
                if (hatalar.Count == 6)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[5] + "";
                }
                if (hatalar.Count == 5)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[4] + "";
                }
                if (hatalar.Count == 4)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[3] + "";
                }
                if (hatalar.Count == 3)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[2] + "";
                }
                if (hatalar.Count == 2)
                {
                    mesaj = "" + hatalar[0] + "" +
"" + Environment.NewLine + "" +
    "" + hatalar[1] + "";
                }
                if (hatalar.Count == 1)
                {
                    mesaj = "" + hatalar[0] + "";
                }
                XtraMessageBox.Show("Bazı eksiklikler tespit edildi:" + Environment.NewLine + "" + Environment.NewLine + "" + mesaj + "");
            }
            else
            {
                for (int i = 0; i < gridView_ürünyükle.RowCount - 1; i++)
                {
                    if (gridView_ürünyükle.GetRowCellValue(i, "ürünkodu").ToString().Trim() != "")
                    {
                        MySqlCommand komut = new MySqlCommand("insert into ür_ürün" +
                        "(ad,ürünkodu,varyant,marka,ürüngrubu,vergigrp,ürüntipi) " +
                        "values(@ad,@ürünkodu,@varyant,@marka,@ürüngrubu,@vergigrp,@ürüntipi)", blg.bağlantı());
                        komut.Parameters.Clear();
                        komut.Parameters.AddWithValue("@ad", gridView_ürünyükle.GetRowCellValue(i, "ad").ToString().Trim());
                        komut.Parameters.AddWithValue("@ürünkodu", gridView_ürünyükle.GetRowCellValue(i, "ürünkodu").ToString().Trim());
                        komut.Parameters.AddWithValue("@varyant", gridView_ürünyükle.GetRowCellValue(i, "varyant").ToString().Trim());
                        komut.Parameters.AddWithValue("@marka", gridView_ürünyükle.GetRowCellValue(i, "marka").ToString().Trim());
                        komut.Parameters.AddWithValue("@ürüngrubu", gridView_ürünyükle.GetRowCellValue(i, "ürüngrubu").ToString().Trim());
                        komut.Parameters.AddWithValue("@vergigrp", gridView_ürünyükle.GetRowCellDisplayText(i, "vergigrp").ToString().Trim());
                        komut.Parameters.AddWithValue("@ürüntipi", gridView_ürünyükle.GetRowCellValue(i, "ürüntipi").ToString().Trim());
                        komut.ExecuteNonQuery();
                        komut.Dispose();

                        try
                        {
                            if (gridView_ürünyükle.GetRowCellValue(i, "krtkstok").ToString().Trim() != "")
                            {
                                MySqlCommand komut2 = new MySqlCommand("insert into ür_varyant" +
                                "(ürünkodu,ad,barkod,satışfiyatı,krtkstok) values(@ürünkodu,@ad,@barkod,@satışfiyatı,@krtkstok)", blg.bağlantı());
                                komut2.Parameters.Clear();
                                komut2.Parameters.AddWithValue("@ad", gridView_ürünyükle.GetRowCellValue(i, "varyant").ToString().Trim());
                                komut2.Parameters.AddWithValue("@ürünkodu", gridView_ürünyükle.GetRowCellValue(i, "ürünkodu").ToString().Trim());
                                komut2.Parameters.AddWithValue("@barkod", gridView_ürünyükle.GetRowCellValue(i, "barkod").ToString().Trim());
                                komut2.Parameters.AddWithValue("@satışfiyatı", Convert.ToDouble(gridView_ürünyükle.GetRowCellValue(i, "satışfiyat")));
                                komut2.Parameters.AddWithValue("@krtkstok", Convert.ToDouble(gridView_ürünyükle.GetRowCellValue(i, "krtkstok")));
                                komut2.ExecuteNonQuery();
                                komut2.Dispose();
                            }
                            else
                            {
                                MySqlCommand komut2 = new MySqlCommand("insert into ür_varyant" +
                                "(ürünkodu,ad,barkod,satışfiyatı) values(@ürünkodu,@ad,@barkod,@satışfiyatı)", blg.bağlantı());
                                komut2.Parameters.Clear();
                                komut2.Parameters.AddWithValue("@ad", gridView_ürünyükle.GetRowCellValue(i, "varyant").ToString().Trim());
                                komut2.Parameters.AddWithValue("@ürünkodu", gridView_ürünyükle.GetRowCellValue(i, "ürünkodu").ToString().Trim());
                                komut2.Parameters.AddWithValue("@barkod", gridView_ürünyükle.GetRowCellValue(i, "barkod").ToString().Trim());
                                komut2.Parameters.AddWithValue("@satışfiyatı", Convert.ToDouble(gridView_ürünyükle.GetRowCellValue(i, "satışfiyat")));
                                komut2.ExecuteNonQuery();
                                komut2.Dispose();
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
        }

        #endregion

        #region #FATURA

        // #Tedarikçiler

        private void faturaTedarikçiler()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select ad,id from tedarikçiler", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            sl_fatura_Tedarikçiler.Properties.ValueMember = "id";
            sl_fatura_Tedarikçiler.Properties.DisplayMember = "ad";
            sl_fatura_Tedarikçiler.Properties.DataSource = ds;
        }

        private void fatura_tedarikçiCariGridcontData()
        {
            try
            {
                double fatura = 0.00;
                double ödeme = 0.00;
                double sonuç = 0.00;
                MySqlCommand msq = new MySqlCommand("select Sum(fatura),Sum(ödeme) from tedarikçiler_cari where tedarikçikodu=@id", blg.bağlantı());
                msq.Parameters.Clear();
                msq.Parameters.AddWithValue("@id", sl_fatura_Tedarikçiler.EditValue);
                msq.ExecuteNonQuery();
                MySqlDataReader oku_id = msq.ExecuteReader();
                while (oku_id.Read())
                {
                    fatura = Convert.ToDouble(oku_id["Sum(fatura)"]);
                    ödeme = Convert.ToDouble(oku_id["Sum(ödeme)"]);
                }
                oku_id.Close();

                sonuç = ödeme - fatura;
                txt_fatura_TedarikçilerBorç.NullText = "" + Convert.ToString(fatura) + "₺";
                txt_fatura_TedarikçilerÖdeme.NullText = "" + Convert.ToString(ödeme) + "₺";
                txt_fatura_TedarikçilerBakiye.NullText = "" + Convert.ToString(sonuç) + "₺";

                string tel = "";
                string adres = "";
                string eposta = "";
                string vergino = "";
                MySqlCommand ted = new MySqlCommand("select *from tedarikçiler", blg.bağlantı());
                ted.ExecuteNonQuery();
                MySqlDataReader oku_ted = ted.ExecuteReader();
                while (oku_ted.Read())
                {
                    tel = oku_ted["tel"].ToString();
                    adres = oku_ted["adres"].ToString();
                    eposta = oku_ted["eposta"].ToString();
                    vergino = oku_ted["vno"].ToString();
                }
                oku_ted.Close();

                txt_fatura_TedarikçilerAdres.NullText = adres;
                txt_fatura_TedarikçilerEposta.NullText = eposta;
                txt_fatura_TedarikçilerVergino.NullText = vergino;
                txt_fatura_TedarikçilerTel.NullText = tel;

            }
            catch (Exception)
            {

            }
        }

        private void searchLookUpEditFaturaTedarikçiler_EditValueChanged(object sender, EventArgs e)
        {
            fatura_tedarikçiCariGridcontData();
        }

        private void SearchLookUpEdit_Fatura_İrsaliyeNo_BeforePopup(object sender, EventArgs e)
        {
            row = gridViewFatura.FocusedRowHandle;
        }


        private void SearchLookUpEdit_Fatura_İrsaliyeNo_Leave(object sender, EventArgs e)
        {
            string id = "";

            for (int i = 0; i < gridViewFatura.RowCount + 3; i++)
            {
                try
                {
                    id = gridViewFatura.GetRowCellValue(i, "irrefno").ToString().Trim();
                }
                catch (Exception)
                {

                }

                MySqlCommand komut_id = new MySqlCommand("select *from stk_irsaliye where irrefno=@id", blg.bağlantı());
                komut_id.Parameters.Clear();
                komut_id.Parameters.AddWithValue("@id", id);
                komut_id.ExecuteNonQuery();
                MySqlDataReader oku_id = komut_id.ExecuteReader();
                while (oku_id.Read())
                {
                    //SearchLookUpEdit_Fatura_Tedarikçi.NullText = oku_id["tedarikçi"].ToString(); // burada kaldım
                    gridViewFatura.SetRowCellValue(i, "tedarikçi", oku_id["tedarikçi"].ToString());
                    gridViewFatura.SetRowCellValue(i, "ad", oku_id["ad"].ToString().Trim());
                    gridViewFatura.SetRowCellValue(i, "ürünkodu", oku_id["ürünkodu"].ToString());
                    SendKeys.Send("{down}");
                }
                oku_id.Close();
            }
        }

        private void datasourceFatura()
        {
            gridControlFatura.DataSource = tabloOluşturFatura(1);
        }

        private void sl_fatura_FatRefNoData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select distinct fatRefNo,ürünkodu,ad,tedarikçi,fatTarih from stk_hareketler", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            searchLookUpEdit_faturaFatRefNo.Properties.ValueMember = "fatRefNo";
            searchLookUpEdit_faturaFatRefNo.Properties.DisplayMember = "fatRefNo";
            searchLookUpEdit_faturaFatRefNo.Properties.DataSource = ds;
        }

        private DataTable tabloOluşturFatura(int RowCount)
        {
            if (checkEdit_kdvDahil.Checked == true)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ürünkodu", Type.GetType("System.String"));
                dt.Columns.Add("ad", Type.GetType("System.String"));
                dt.Columns.Add("tedarikçi", Type.GetType("System.String"));
                dt.Columns.Add("varyant", Type.GetType("System.String"));
                dt.Columns.Add("serino", Type.GetType("System.String"));
                //dt.Columns.Add("alışfiyatıVH", Type.GetType("System.Decimal"));
                dt.Columns.Add("alışfiyatıVD", Type.GetType("System.Decimal"));
                dt.Columns.Add("adet", Type.GetType("System.Decimal"));
                dt.Columns.Add("vergigrp", Type.GetType("System.String"));
                dt.Columns.Add("id", Type.GetType("System.String"));
                for (int i = 0; i < RowCount; i++)
                {
                    dt.Rows.Add();
                }
                return dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ürünkodu", Type.GetType("System.String"));
                dt.Columns.Add("ad", Type.GetType("System.String"));
                dt.Columns.Add("varyant", Type.GetType("System.String"));
                dt.Columns.Add("serino", Type.GetType("System.String"));
                dt.Columns.Add("alışfiyatıVH", Type.GetType("System.Decimal"));
                //dt.Columns.Add("alışfiyatıVD", Type.GetType("System.Decimal"));
                dt.Columns.Add("adet", Type.GetType("System.Decimal"));
                dt.Columns.Add("vergigrp", Type.GetType("System.String"));
                dt.Columns.Add("id", Type.GetType("System.String"));
                for (int i = 0; i < RowCount; i++)
                {
                    dt.Rows.Add();
                }
                return dt;
            }
        }
        
        // #faturakaydet
        private void btn_kaydet_fatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sl_fatura_Tedarikçiler.Text != "")
            {
                if (rd_fatura_ödemetürü.EditValue.ToString() != "")
                {
                    if (rd_fatura_ödemetürü.EditValue.ToString() == "1")
                    {
                        if (cmb_fatura_peşin.Text != "")
                        {
                            if (cmb_fatura_peşin.Text == "Nakit")
                            {
                                if (sl_fatura_kasaHesabı.Text != "")
                                {
                                    faturaKaydet();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Kasa hesabı seçilmemiş!");
                                }
                            }
                            if (cmb_fatura_peşin.Text == "Havale")
                            {
                                if (sl_fatura_bankahesabı.Text != "")
                                {
                                    faturaKaydet();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Banka hesabı seçilmemiş!");
                                }
                            }
                            if (cmb_fatura_peşin.Text == "Kredi Kartı")
                            {
                                if (sl_fatura_krediKartları.Text != "")
                                {
                                    faturaKaydet();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Kredi kartı şeçimi yapılmamış!");
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Peşin ödeme yöntemi seçilmemiş. Lütfen peşin ödeme yöntemi seçin.");
                        }
                    }
                    if (rd_fatura_ödemetürü.EditValue.ToString() == "2")
                    {
                        if (cmb_fatura_vadeli.Text != "")
                        {
                            if (cmb_fatura_vadeli.Text == "Vadeli")
                            {
                                faturaKaydet();
                            }
                            if (cmb_fatura_peşin.Text == "Çek")
                            {
                                faturaKaydet();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Vadeli ödeme yöntemi seçilmemiş. Lütfen vadeli ödeme yöntemi seçin.");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Ödeme yöntemi seçilmemiş. Lütfenödeme yöntemi seçin.");
                }
            }
            else
            {
                XtraMessageBox.Show("Tedarikçi seçimi yapılmamış. Lütfen bir tedarikçi seçin.");
            }            
        }

        private void faturaKaydet()
        {
            MySqlCommand komut_id = new MySqlCommand("select *from stk_serino where id=@id", blg.bağlantı());
            komut_id.Parameters.Clear();
            komut_id.Parameters.AddWithValue("@id", Convert.ToInt32(chk_faturaİadeFat.EditValue));
            komut_id.ExecuteNonQuery();
            MySqlDataReader oku_id = komut_id.ExecuteReader();
            while (oku_id.Read())
            {
                fatRefAdı = oku_id["ad"].ToString();
                fatRefNo = Convert.ToInt32(oku_id["no"]) + 1;
            }
            oku_id.Close();

            int adet = 1;

            if (Convert.ToInt32(chk_faturaİadeFat.EditValue) == 1)
            {
                adet = 1;
            }
            else
            {
                adet = - 1;
            }

            int tedarikçiKodu = Convert.ToInt32(sl_fatura_Tedarikçiler.EditValue);

            MySqlCommand komut = new MySqlCommand("insert into stk_hareketler" +
            "(ürünkodu,varyant,vergigrp,serino,alışfiyatıVH,alışfiyatıVD,adet,tutar,tutarVD,fatTarih,fatİşlmTar,tedarikçi,fatTarihSytem,fatRefNo,iade) " +
            "values(@ürünkodu,@varyant,@vergigrp,@serino,@alışfiyatıVH,@alışfiyatıVD,@adet,@tutar,@tutarVD,@fatTarih,@fatİşlmTar,@tedarikçi,@fatTarihSytem,@fatRefNo,@iade)", blg.bağlantı());
            for (int i = 0; i < gridViewFatura.RowCount - 1; i++)
            {
                if (gridViewFatura.GetRowCellDisplayText(i, "ürünkodu").ToString().Trim() != "")
                {
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@ürünkodu", gridViewFatura.GetRowCellDisplayText(i, "ürünkodu").ToString().Trim());
                    komut.Parameters.AddWithValue("@varyant", gridViewFatura.GetRowCellDisplayText(i, "varyant").ToString().Trim());
                    komut.Parameters.AddWithValue("@vergigrp", gridViewFatura.GetRowCellValue(i, "vergigrp").ToString().Trim());
                    komut.Parameters.AddWithValue("@serino", gridViewFatura.GetRowCellValue(i, "serino").ToString().Trim());
                    komut.Parameters.AddWithValue("@alışfiyatıVH", gridViewFatura.GetRowCellValue(i, "alışfiyatıVH").ToString().Trim());
                    komut.Parameters.AddWithValue("@alışfiyatıVD", gridViewFatura.GetRowCellValue(i, "alışfiyatıVD"));
                    komut.Parameters.AddWithValue("@adet", Convert.ToInt32(gridViewFatura.GetRowCellValue(i, "adet"))*adet);
                    komut.Parameters.AddWithValue("@tutar", gridViewFatura.GetRowCellValue(i, "tutar"));
                    komut.Parameters.AddWithValue("@tutarVD", gridViewFatura.GetRowCellValue(i, "tutarVD"));
                    komut.Parameters.AddWithValue("@fatTarih", dt_faturaFaturaTarihi.EditValue);
                    komut.Parameters.AddWithValue("@fatİşlmTar", dt_faturaİşlemTarihi.EditValue);
                    komut.Parameters.AddWithValue("@tedarikçi", tedarikçiKodu);
                    komut.Parameters.AddWithValue("@fatTarihSytem", blg.tarih());
                    komut.Parameters.AddWithValue("@fatRefNo", "" + fatRefAdı + "" + fatRefNo + "");
                    komut.Parameters.AddWithValue("@iade", chk_faturaİadeFat.EditValue);
                    //komut.Parameters.AddWithValue("@kullanıcı", ""+kullanıcı()+"");
                    komut.ExecuteNonQuery();
                }
            }
            komut.Dispose();

            double faturaTutarı = Convert.ToDouble(gridViewFatura.Columns["tutarVD"].SummaryItem.SummaryValue);

            if (rd_fatura_ödemetürü.EditValue.ToString() == "1")
            {
                if (cmb_fatura_peşin.Text == "Nakit")
                {
                    MySqlCommand komut_ödeme = new MySqlCommand("insert into tedarikçiler_cari" +
                    "(fatRefNo,fatura,ödeme,ödemetürü,ödemeyöntemi,tedarikçikodu,tarih,faturatarihi) " +
                    "values(@fatRefNo,@fatura,@ödeme,@ödemetürü,@ödemeyöntemi,@tedarikçikodu,@tarih,@faturatarihi)", blg.bağlantı());
                    komut_ödeme.Parameters.Clear();
                    komut_ödeme.Parameters.AddWithValue("@fatRefNo", "" + fatRefAdı + "" + fatRefNo + "");
                    komut_ödeme.Parameters.AddWithValue("@fatura", faturaTutarı);
                    komut_ödeme.Parameters.AddWithValue("@ödeme", faturaTutarı);
                    komut_ödeme.Parameters.AddWithValue("@ödemetürü", sl_fatura_kasaHesabı.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemeyöntemi", sl_fatura_krediKartları.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemetarihi", blg.tarih());
                    komut_ödeme.Parameters.AddWithValue("@tedarikçikodu", tedarikçiKodu);
                    komut_ödeme.Parameters.AddWithValue("@tarih", blg.tarih());
                    komut_ödeme.Parameters.AddWithValue("@faturatarihi", dt_faturaFaturaTarihi.EditValue);
                    komut_ödeme.ExecuteNonQuery();
                    komut_ödeme.Dispose();
                }
                if (cmb_fatura_peşin.Text == "Havale")
                {
                    MySqlCommand komut_ödeme = new MySqlCommand("insert into tedarikçiler_cari" +
                    "(fatRefNo,fatura,ödeme,ödemetürü,ödemeyöntemi,tedarikçikodu,tarih,faturatarihi) " +
                    "values(@fatRefNo,@fatura,@ödeme,@ödemetürü,@ödemeyöntemi,@tedarikçikodu,@tarih,@faturatarihi)", blg.bağlantı());
                    komut_ödeme.Parameters.Clear();
                    komut_ödeme.Parameters.AddWithValue("@fatRefNo", "" + fatRefAdı + "" + fatRefNo + "");
                    komut_ödeme.Parameters.AddWithValue("@fatura", faturaTutarı);
                    komut_ödeme.Parameters.AddWithValue("@ödeme", faturaTutarı);
                    komut_ödeme.Parameters.AddWithValue("@ödemetürü", sl_fatura_bankahesabı.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemeyöntemi", cmb_fatura_peşin.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemetarihi", blg.tarih());
                    komut_ödeme.Parameters.AddWithValue("@tedarikçikodu", tedarikçiKodu);
                    komut_ödeme.Parameters.AddWithValue("@tarih", blg.tarih());
                    komut_ödeme.Parameters.AddWithValue("@faturatarihi", dt_faturaFaturaTarihi.EditValue);
                    komut_ödeme.ExecuteNonQuery();
                    komut_ödeme.Dispose();
                }
                if (cmb_fatura_peşin.Text == "Kredi Kartı")
                {
                    MySqlCommand komut_ödeme = new MySqlCommand("insert into tedarikçiler_cari" +
                    "(fatRefNo,fatura,ödeme,ödemetürü,ödemeyöntemi,tedarikçikodu,tarih,faturatarihi) " +
                    "values(@fatRefNo,@fatura,@ödeme,@ödemetürü,@ödemeyöntemi,@tedarikçikodu,@tarih,@faturatarihi)", blg.bağlantı());
                    komut_ödeme.Parameters.Clear();
                    komut_ödeme.Parameters.AddWithValue("@fatRefNo", "" + fatRefAdı + "" + fatRefNo + "");
                    komut_ödeme.Parameters.AddWithValue("@fatura", faturaTutarı);
                    komut_ödeme.Parameters.AddWithValue("@ödeme", faturaTutarı);
                    komut_ödeme.Parameters.AddWithValue("@ödemetürü", sl_fatura_krediKartları.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemeyöntemi", cmb_fatura_peşin.Text);
                    komut_ödeme.Parameters.AddWithValue("@ödemetarihi", blg.tarih());
                    komut_ödeme.Parameters.AddWithValue("@tedarikçikodu", tedarikçiKodu);
                    komut_ödeme.Parameters.AddWithValue("@tarih", blg.tarih());
                    komut_ödeme.Parameters.AddWithValue("@faturatarihi", dt_faturaFaturaTarihi.EditValue);
                    komut_ödeme.ExecuteNonQuery();
                    komut_ödeme.Dispose();
                }
            }
            if (rd_fatura_ödemetürü.EditValue.ToString() == "2")
            {
                MySqlCommand komut_ödeme = new MySqlCommand("insert into tedarikçiler_cari" +
                "(fatRefNo,fatura,ödemeyöntemi,tedarikçikodu,tarih,faturatarihi) " +
                "values(@fatRefNo,@fatura,@ödemeyöntemi,@tedarikçikodu,@tarih,@faturatarihi)", blg.bağlantı());
                komut_ödeme.Parameters.Clear();
                komut_ödeme.Parameters.AddWithValue("@fatRefNo", "" + fatRefAdı + "" + fatRefNo + "");
                komut_ödeme.Parameters.AddWithValue("@fatura", faturaTutarı);
                komut_ödeme.Parameters.AddWithValue("@ödemeyöntemi", cmb_fatura_vadeli.Text);
                komut_ödeme.Parameters.AddWithValue("@tedarikçikodu", tedarikçiKodu);
                komut_ödeme.Parameters.AddWithValue("@tarih", blg.tarih());
                komut_ödeme.Parameters.AddWithValue("@faturatarihi", dt_faturaFaturaTarihi.EditValue);
                komut_ödeme.ExecuteNonQuery();
                komut_ödeme.Dispose();
            }
            MySqlCommand komut_refyeni = new MySqlCommand("update stk_serino set no=@no where id=@id", blg.bağlantı());
            komut_refyeni.Parameters.Clear();
            komut_refyeni.Parameters.AddWithValue("@no", fatRefNo);
            komut_refyeni.Parameters.AddWithValue("@id", Convert.ToInt32(chk_faturaİadeFat.EditValue));
            komut_refyeni.ExecuteNonQuery();
            komut_refyeni.Dispose();
        }

        #region #serino&adet

        private void txt_fatura_serino_Leave(object sender, EventArgs e)
        {
            row = gridViewFatura.FocusedRowHandle;
            if ((sender as TextEdit).Text != "")
            {
                gridViewFatura.SetRowCellValue(row, "adet", "1");
            }
        }

        private void SpinEdit_Fatura_Adet_EditValueChanged(object sender, EventArgs e)
        {
            row = gridViewFatura.FocusedRowHandle;
            if ((sender as SpinEdit).Text != "1")
            {
                if (gridViewFatura.GetRowCellValue(row, "serino").ToString() != "")
                {
                    gridViewFatura.SetRowCellValue(row, "adet", "1");
                }
            }
        }
        #endregion

        #region #ödemeyöntemi

        private void sl_fatura_bankalarData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select ad,id from muh_bankalar", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            sl_fatura_bankahesabı.Properties.ValueMember = "ad";
            sl_fatura_bankahesabı.Properties.DisplayMember = "ad";
            sl_fatura_bankahesabı.Properties.DataSource = ds;
        }

        private void tanım_ödemeYöntemiData()
        {
            string ödemeyöntemi = "";

            try
            {
                if (rd_fatura_ödemetürü.EditValue.ToString() == "1")
                {
                    ödemeyöntemi = "peşin";
                }
                if (rd_fatura_ödemetürü.EditValue.ToString() == "2")
                {
                    ödemeyöntemi = "vadeli";
                }

                MySqlCommand komut_var = new MySqlCommand("select *from tanım_fatura_ödemeyöntemi where ödemeyöntemi=@id", blg.bağlantı());
                komut_var.Parameters.AddWithValue("@id", ödemeyöntemi);
                komut_var.ExecuteNonQuery();
                MySqlDataReader oku_var = komut_var.ExecuteReader();
                cmb_fatura_peşin.Properties.Items.Clear();
                cmb_fatura_vadeli.Properties.Items.Clear();
                while (oku_var.Read())
                {
                    cmb_fatura_peşin.Properties.Items.Add(oku_var["ad"].ToString());
                    cmb_fatura_vadeli.Properties.Items.Add(oku_var["ad"].ToString());
                }
                oku_var.Close();
            }
            catch (Exception)
            {

            }
        }

        private void rd_fatura_ödemetürü_SelectedIndexChanged(object sender, EventArgs e)
        {
            grp_fatura_kredikarı.Visible = false;
            grp_fatura_havale.Visible = false;
            grp_fatura_nakitödeme.Visible = false;
            cmb_fatura_peşin.Text = "";
            cmb_fatura_vadeli.Text = "";
            sl_fatura_bankahesabı.Text = "";
            sl_fatura_kasaHesabı.Text = "";
            sl_fatura_krediKartları.Text = "";

            if (rd_fatura_ödemetürü.EditValue.ToString() == "1")
            {
                cmb_fatura_peşin.Visible = true;
                cmb_fatura_vadeli.Visible = false;
            }
            if (rd_fatura_ödemetürü.EditValue.ToString() == "2")
            {
                cmb_fatura_peşin.Visible = false;
                cmb_fatura_vadeli.Visible = true;
            }
            tanım_ödemeYöntemiData();
        }

        private void cmb_fatura_peşin_EditValueChanged(object sender, EventArgs e)
        {
            sl_fatura_bankahesabı.Text = "";
            sl_fatura_kasaHesabı.Text = "";
            sl_fatura_krediKartları.Text = "";

            if (cmb_fatura_peşin.Text == "Kredi Kartı")
            {
                grp_fatura_nakitödeme.Visible = false;
                grp_fatura_havale.Visible = false;
                grp_fatura_kredikarı.Visible = true;
                sp_fatura_taksitsayısı.EditValue = 1;
            }
            if (cmb_fatura_peşin.Text == "Nakit")
            {
                grp_fatura_kredikarı.Visible = false;
                grp_fatura_havale.Visible = false;
                grp_fatura_nakitödeme.Visible = true;
            }
            if (cmb_fatura_peşin.Text == "Havale")
            {
                grp_fatura_kredikarı.Visible = false;                
                grp_fatura_nakitödeme.Visible = false;
                grp_fatura_havale.Visible = true;
            }
        }

        private void sp_fatura_taksitsayısı_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(sp_fatura_taksitsayısı.EditValue) == 1)
            {
                lbl_fatura_tekçekim.Visible = true;
            }
            else
            {
                lbl_fatura_tekçekim.Visible = false;
            }
        }

        #endregion

        #region tanım kredikartları
        public void sl_fatura_kredikartıData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select ad,banka,id from tanım_kredikartları", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            sl_fatura_krediKartları.Properties.ValueMember = "id";
            sl_fatura_krediKartları.Properties.DisplayMember = "ad";
            sl_fatura_krediKartları.Properties.DataSource = ds;
        }
        private void sl_fatura_krediKartları_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
        {
            frm_tanım_kredikartları frm = new frm_tanım_kredikartları();
            frm.ShowDialog();
        }

        #endregion

        #region tutar
        decimal getTotalValue(GridView view, int listSourceRowIndex)
        {
            decimal unitPrice = 0;
            decimal quantity = 0;

            try
            {
                unitPrice = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "alışfiyatıVH"));
                quantity = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "adet"));

            }
            catch (Exception)
            {

            }
            return unitPrice * quantity;
        }

        decimal getTotalValue2(GridView view2, int listSourceRowIndex)
        {
            decimal sayı = 0;
            decimal vergi = 0;
            decimal sonuç = 0;
            int vergioranı = 0;

            try
            {
                vergioranı = Convert.ToInt32(view2.GetListSourceRowCellValue(listSourceRowIndex, "vergigrp"));
                sayı = Convert.ToDecimal(view2.GetListSourceRowCellValue(listSourceRowIndex, "alışfiyatıVD"));

                if (Convert.ToString(vergioranı).Length < 2)
                {
                    vergi = Convert.ToDecimal("1,0" + vergioranı + "");
                }
                else
                {
                    vergi = Convert.ToDecimal("1," + vergioranı + "");
                }

                sonuç = sayı / (vergi);
            }
            catch (Exception)
            {

            }
            return sonuç;
        }

        decimal getTotalValue3(GridView view2, int listSourceRowIndex)
        {
            decimal sayı = 0;
            decimal vergi = 0;
            decimal sonuç = 0;
            int vergioranı = 0;
            try
            {
                vergioranı = Convert.ToInt32(view2.GetListSourceRowCellValue(listSourceRowIndex, "vergigrp"));
                sayı = Convert.ToDecimal(view2.GetListSourceRowCellValue(listSourceRowIndex, "alışfiyatıVH"));

                if (Convert.ToString(vergioranı).Length < 2)
                {
                    vergi = Convert.ToDecimal("0,0" + vergioranı + "");
                }
                else
                {
                    vergi = Convert.ToDecimal("0," + vergioranı + "");
                }

                sonuç = sayı + (sayı * vergi);
            }
            catch (Exception)
            {

            }
            return sonuç;
        }

        decimal getTotalValue4(GridView view3, int listSourceRowIndex)
        {
            decimal sayı = 0;
            decimal adet = 0;
            decimal sonuç = 0;
            try
            {
                sayı = Convert.ToDecimal(view3.GetListSourceRowCellValue(listSourceRowIndex, "alışfiyatıVD"));
                adet = Convert.ToDecimal(view3.GetListSourceRowCellValue(listSourceRowIndex, "adet"));
                sonuç = sayı * adet;
            }
            catch (Exception)
            {

            }
            return sonuç;
        }

        private void gridViewFatura_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

            if (checkEdit_kdvDahil.Checked == true)
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "tutar" && e.IsGetData) e.Value =
                  getTotalValue(view, e.ListSourceRowIndex);

                GridView view2 = sender as GridView;
                if (e.Column.FieldName == "alışfiyatıVH" && e.IsGetData) e.Value =
                  getTotalValue2(view, e.ListSourceRowIndex);

                GridView view3 = sender as GridView;
                if (e.Column.FieldName == "tutarVD" && e.IsGetData) e.Value =
                  getTotalValue4(view, e.ListSourceRowIndex);
            }
            else
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "tutar" && e.IsGetData) e.Value =
                  getTotalValue(view, e.ListSourceRowIndex);

                GridView view2 = sender as GridView;
                if (e.Column.FieldName == "alışfiyatıVD" && e.IsGetData) e.Value =
                  getTotalValue3(view, e.ListSourceRowIndex);

                GridView view3 = sender as GridView;
                if (e.Column.FieldName == "tutarVD" && e.IsGetData) e.Value =
                  getTotalValue4(view, e.ListSourceRowIndex);
            }
        }

        private void checkEdit_kdvDahil_CheckedChanged(object sender, EventArgs e)
        {
            datasourceFatura();

            if (checkEdit_kdvDahil.Checked == true)
            {
                gridViewFatura.Columns["alışfiyatıVH"].OptionsColumn.ReadOnly = true;
                gridViewFatura.Columns["alışfiyatıVH"].OptionsColumn.AllowEdit = false;

                gridViewFatura.Columns["alışfiyatıVD"].OptionsColumn.ReadOnly = false;
                gridViewFatura.Columns["alışfiyatıVD"].OptionsColumn.AllowEdit = true;
            }
            if (checkEdit_kdvDahil.Checked == false)
            {
                gridViewFatura.Columns["alışfiyatıVH"].OptionsColumn.ReadOnly = false;
                gridViewFatura.Columns["alışfiyatıVH"].OptionsColumn.AllowEdit = true;

                gridViewFatura.Columns["alışfiyatıVD"].OptionsColumn.ReadOnly = true;
                gridViewFatura.Columns["alışfiyatıVD"].OptionsColumn.AllowEdit = false;
            }
        }

        #endregion

        // #ürünkodu
        public void sl_fatura_ürünkoduData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select distinct ürünkodu,ad from ür_ürün", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            SearchLookUpEdit_Fatura_ÜrünKodu.ValueMember = "ad";
            SearchLookUpEdit_Fatura_ÜrünKodu.DisplayMember = "ürünkodu";
            SearchLookUpEdit_Fatura_ÜrünKodu.DataSource = ds;
        }

        private void SearchLookUpEdit_Fatura_ÜrünKodu_Leave(object sender, EventArgs e)
        {

            if (row < 0)
            {
                SendKeys.Send("{down}");
            }

            for (int i = 0; i < gridViewFatura.RowCount; i++)
            {
                try
                {
                    gridViewFatura.SetRowCellValue(i - 1, "ad", Convert.ToString(gridViewFatura.GetRowCellValue(i - 1, "ürünkodu")));

                    MySqlCommand komut_id = new MySqlCommand("select *from ür_ürün where ürünkodu=@id", blg.bağlantı());
                    komut_id.Parameters.AddWithValue("@id", Convert.ToString(gridViewFatura.GetRowCellDisplayText(i - 1, "ürünkodu")));
                    komut_id.ExecuteNonQuery();
                    MySqlDataReader oku_id = komut_id.ExecuteReader();
                    while (oku_id.Read())
                    {
                        gridViewFatura.SetRowCellValue(i - 1, "vergigrp", oku_id["vergigrp"].ToString());
                    }
                    oku_id.Close();

                    if (Convert.ToString(gridViewFatura.GetRowCellValue(i - 1, "adet")) == "")
                    {
                        gridViewFatura.SetRowCellValue(i - 1, "adet", 1);
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void SearchLookUpEdit_Fatura_ÜrünKodu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            SendKeys.Send("{down}");
        }

        private void SearchLookUpEdit_Fatura_ÜrünKodu_BeforePopup(object sender, EventArgs e)
        {
            row = gridViewFatura.FocusedRowHandle;
        }

        private void gridControlFatura_Click(object sender, EventArgs e)
        {
            row = gridViewFatura.FocusedRowHandle;
        }

        private void gridControlFatura_MouseClick(object sender, MouseEventArgs e)
        {
            row = gridViewFatura.FocusedRowHandle;
        }

        //#varyant
        public void sl_fatura_varyantData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select ad,ürünkodu from ür_varyant", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            sl_fatura_varyantSeç.DataSource = ds;

            sl_fatura_varyantSeç.DisplayMember = "ad";
            sl_fatura_varyantSeç.ValueMember = "ad";
        }

        private void sl_fatura_varyantSeç_Click(object sender, EventArgs e)
        {
            row = gridViewFatura.FocusedRowHandle;

            if (row < 0)
            {
                gridViewFatura.AddNewRow();
                SendKeys.Send("{down}");
                SendKeys.Send("{up}");
            }

            (sender as SearchLookUpEdit).Properties.View.FindFilterText = gridViewFatura.GetRowCellDisplayText(row, "ürünkodu").ToString().Trim();
        }

        private void searchLookUpEdit_faturaFatRefNo_Properties_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.Controls.EditorButton btn = (sender as DevExpress.XtraEditors.Controls.EditorButton);

            //DevExpress.XtraEditors.Controls.EditorButton newButton = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis);
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "al", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "1", null, superToolTip1, DevExpress.Utils.ToolTipAnchor.Cursor)});
            //repositoryItemComboBox_Varyant.Properties.Buttons.Add(newButton);
            //if ((sender as SearchLookUpEdit).Properties.Buttons.)

            try
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("select *from stk_hareketler", blg.bağlantı());
                DataTable ds = new DataTable();
                adp.Fill(ds);
                bindingSource1.DataSource = ds;
                bindingSource1.Filter = "fatRefNo ='" + searchLookUpEdit_faturaFatRefNo.EditValue + "'";
                gridControlFatura.DataSource = bindingSource1;

                MySqlCommand komut_var = new MySqlCommand("select *from stk_hareketler where fatRefNo=@id", blg.bağlantı());
                komut_var.Parameters.AddWithValue("@id", searchLookUpEdit_faturaFatRefNo.EditValue);
                komut_var.ExecuteNonQuery();
                MySqlDataReader oku_var = komut_var.ExecuteReader();
                while (oku_var.Read())
                {
                    sl_fatura_Tedarikçiler.Properties.NullValuePrompt = oku_var["tedarikçi"].ToString();
                }
                oku_var.Close();

            }
            catch (Exception)
            {
                //throw;
            }
        }
        #endregion

        #region #STOK

        public void gridControlStok()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select *from ür_ürün", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            gridControl_stok.DataSource = ds;

            for (int i = 0; i < gridView_stok.RowCount; i++)
            {
                try
                {
                    string varyant = gridView_stok.GetRowCellValue(i, "varyant").ToString().Trim();
                    string ürünkodu = gridView_stok.GetRowCellValue(i, "ürünkodu").ToString().Trim();

                    MySqlCommand komut_var = new MySqlCommand("select Sum(adet) from stk_hareketler where ürünkodu=@ürünkodu and varyant=@varyant", blg.bağlantı());
                    komut_var.Parameters.AddWithValue("@ürünkodu", ürünkodu);
                    komut_var.Parameters.AddWithValue("@varyant", varyant);
                    komut_var.ExecuteNonQuery();
                    MySqlDataReader oku_var = komut_var.ExecuteReader();
                    while (oku_var.Read())
                    {
                        try
                        {
                            gridView_stok.SetRowCellValue(i, "stok", Convert.ToInt32(oku_var["Sum(adet)"]));
                        }
                        catch (Exception)
                        {

                        }
                    }
                    oku_var.Close();
                }
                catch (Exception)
                {

                }
            }

            gridView_stok.Columns["ürünkodu"].GroupIndex = 1;

        }

        #endregion

        #region İRSALİYE

        public void gridControlÜrünYÜkle_İrsaliye()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select *from stk_irsaliye_şablon", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            gridControl_irsaliye.DataSource = ds;
        }

        public void sl_irsaliye_ürünkoduData()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select distinct ürünkodu,ad from ür_ürün", blg.bağlantı());
            DataTable ds = new DataTable();
            adp.Fill(ds);
            bindingSource1.DataSource = ds;
            repositoryItemSearchLookUpEdit_ürünkodu.ValueMember = "ad";
            repositoryItemSearchLookUpEdit_ürünkodu.DisplayMember = "ürünkodu";
            repositoryItemSearchLookUpEdit_ürünkodu.DataSource = ds;
        }

        private void btn_irsaliyeKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            MySqlCommand komut = new MySqlCommand("insert into stk_irsaliye" +
            "(tedarikçi,ad,ürünkodu,marka,varyant,serino,adet,tarih,kullanıcı) " +
            "values(@tedarikçi,@ad,@ürünkodu,@marka,@varyant,@serino,@adet,@tarih,@kullanıcı)", blg.bağlantı());

            for (int i = 0; i < gridView_İrsaliye.RowCount - 1; i++)
            {
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@tedarikçi", gridView_İrsaliye.GetRowCellValue(i, "tedarikçi").ToString().Trim());
                komut.Parameters.AddWithValue("@ad", gridView_İrsaliye.GetRowCellValue(i, "ad").ToString().Trim());
                komut.Parameters.AddWithValue("@ürünkodu", gridView_İrsaliye.GetRowCellValue(i, "ürünkodu").ToString().Trim());
                komut.Parameters.AddWithValue("@marka", gridView_İrsaliye.GetRowCellValue(i, "marka").ToString().Trim());
                komut.Parameters.AddWithValue("@varyant", gridView_İrsaliye.GetRowCellValue(i, "varyant").ToString().Trim());
                komut.Parameters.AddWithValue("@serino", gridView_İrsaliye.GetRowCellValue(i, "serino").ToString().Trim());
                komut.Parameters.AddWithValue("@adet", Convert.ToInt32(gridView_İrsaliye.GetRowCellValue(i, "adet")));
                komut.Parameters.AddWithValue("@tarih", blg.tarih());
                komut.Parameters.AddWithValue("@kullanıcı", kullanıcı());
                komut.ExecuteNonQuery();
            }
            komut.Dispose();
        }

        private void repositoryItemSearchLookUpEdit_ürünkodu_BeforePopup(object sender, EventArgs e)
        {
            row = gridView_İrsaliye.FocusedRowHandle;
        }

        private void repositoryItemSearchLookUpEdit_ürünkodu_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            SendKeys.Send("{down}");

            if (row < 0)
            {
                SendKeys.Send("{down}");
            }

        }

        private void repositoryItemSearchLookUpEdit_ürünkodu_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView_İrsaliye.RowCount + 3; i++)
            {
                try
                {
                    gridView_İrsaliye.SetRowCellValue(i, "ad", Convert.ToString(gridView_İrsaliye.GetRowCellValue(i, "ürünkodu")));
                    gridView_İrsaliye.SetRowCellValue(i, "tedarikçi", Convert.ToString(gridView_İrsaliye.GetRowCellValue(0, "tedarikçi")));
                }
                catch (Exception)
                {


                }
            }
        }




        #endregion

    }
}