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
using LOYAZ.Raporlar.ts;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using System.Reflection;
using DevExpress.ClipboardSource.SpreadsheetML;
//using DevExpress.DataAccess.ObjectBinding;
using DevExpress.CodeParser;
//using ZXing;
using LOYAZ.Formlar.Teknikservis;

namespace LOYAZ
{
    public partial class panel_ts_anasayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public panel_ts_anasayfa()
        {
            InitializeComponent();
        }

        #region kullaniciYetkileri 
        public string silinenServisleriGeriAl = "";



        #endregion

        sqlbağlantısı blg = new sqlbağlantısı();

        private void panel_ts_anasayfa_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();

            kullanıcıYetkileriSql();
            gridkontrolgöster();
            servissayısınıyazdır();            
 
            splashScreenManager1.CloseWaitForm();
        }
 
        private void kullanıcıYetkileriSql()
        {
            string kul_id = "";

            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["frm_anasayfa_form"];
            kul_id = frm.lbl_kul_id.Text;

            MySqlCommand komut = new MySqlCommand("select *from kul_kullanicilar where id=@id", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", kul_id);
            komut.ExecuteNonQuery();
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                MySqlCommand komut2 = new MySqlCommand("select *from kul_kullanicig_yetkiler where ad=@id", blg.bağlantı());
                komut2.Parameters.Clear();
                komut2.Parameters.AddWithValue("@id", oku["yetki"].ToString());
                komut2.ExecuteNonQuery();
                MySqlDataReader oku2 = komut2.ExecuteReader();
                while (oku2.Read())
                {
                    if (oku2["ts_servisac"].ToString() == "false" && oku2["ts_servissil"].ToString() == "false" && oku2["ts_servisduzenle"].ToString() == "false")
                    {
                        ribbonPageGroup_servisaç.Visible = false;
                    }
                    else
                    {
                        btn_yeniservis.Enabled = Convert.ToBoolean(oku2["ts_servisac"].ToString());
                        btn_servisidüzenle.Enabled = Convert.ToBoolean(oku2["ts_servisduzenle"].ToString());
                        btn_servisisil.Enabled = Convert.ToBoolean(oku2["ts_servissil"].ToString());
                    }

                    if (oku2["ts_servisgüncelle"].ToString() == "false" && oku2["ts_servisikapat"].ToString() == "false")
                    {
                        ribbonPageGroup_serviskapat_güncelle.Visible = false;
                    }
                    else
                    {
                        btn_serviskapat.Enabled = Convert.ToBoolean(oku2["ts_servisikapat"].ToString());
                        btn_servisgüncelle.Enabled = Convert.ToBoolean(oku2["ts_servisgüncelle"].ToString());
                    }

                    ribbonPageGroup_silinensergör.Visible = Convert.ToBoolean(oku2["ts_servisgüncelle"].ToString());                    

                    ribbonPageGroup_raporoluştur.Visible = Convert.ToBoolean(oku2["ts_raporoluştur"].ToString());

                    ribbonPageGroup_servisformuyükle.Visible = Convert.ToBoolean(oku2["ts_servisformuyükle"].ToString());

                    silinenServisleriGeriAl = oku2["ts_silinenservisigerial"].ToString();

                    ribbonPageGroup_silinengerial.Visible = false;

                }
                oku2.Close();
            }
            oku.Close();
        }



        public void gridkontrolgöster()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from servis_hareketler", blg.bağlantı());
            DataSet ds = new DataSet();
            adp.Fill(ds);
            gridControl_tumu.DataSource = ds.Tables[0];
            gridControl_devam.DataSource = ds.Tables[0];
            gridControl_tamamlanan.DataSource = ds.Tables[0];
            //gridControl_silinenler.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        private void tab_control_HeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.HeaderButtonEventArgs e)
        {
            İ.SelectedTabPage.PageVisible = false;
        }

        private void tab_control_CloseButtonClick(object sender, EventArgs e)
        {
            İ.SelectedTabPage.PageVisible = false;
        }

        private void btn_anasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        public void servissayısınıyazdır()
        {
            //string bitmemişadet;
            //string bitmişadet;

            //MySqlCommand bitmemiş = new MySqlCommand("select count(durum) from ts_servis where durum=@durum and (sil=@sil or sil=@sil2)", blg.bağlantı());
            //bitmemiş.Parameters.AddWithValue("@durum", 0);
            //bitmemiş.Parameters.AddWithValue("@sil", 0);
            //bitmemiş.Parameters.AddWithValue("@sil2", 0);

            //bitmemişadet = bitmemiş.ExecuteScalar().ToString();

            ////lbl_bitmemiş.Text = "" + bitmemişadet + "";

            //MySqlCommand bitmiş = new MySqlCommand("select count(durum) from ts_servis where durum=@durum and (sil=@sil or sil=@sil2)", blg.bağlantı());
            //bitmiş.Parameters.AddWithValue("@durum", 1);
            //bitmiş.Parameters.AddWithValue("@sil", 0);
            //bitmiş.Parameters.AddWithValue("@sil2", null);
            //bitmişadet = bitmiş.ExecuteScalar().ToString();

            ////lbl_bitmiş.Text = "" + bitmişadet + "";

            //int toplam = Convert.ToInt32(bitmişadet) + Convert.ToInt32(bitmemişadet);
            ////lbl_toplam_servis.Text = Convert.ToString(toplam);
        }

        private void lbl_bitmemiş_MouseClick(object sender, MouseEventArgs e)
        {
            if (xtraTabPage_devam.PageVisible == true)
            {
                İ.SelectedTabPage = xtraTabPage_devam;
            }
            else
            {
                xtraTabPage_devam.PageVisible = true;
                İ.SelectedTabPage = xtraTabPage_devam;
            }
        }

        private void lbl_bitmiş_Click(object sender, EventArgs e)
        {
            if (xtraTabPage_biten.PageVisible == true)
            {
                İ.SelectedTabPage = xtraTabPage_biten;
            }
            else
            {
                xtraTabPage_biten.PageVisible = true;
                İ.SelectedTabPage = xtraTabPage_biten;
            }
        }

        private void lbl_toplam_servis_MouseClick(object sender, MouseEventArgs e)
        {
            if (xtraTabPage_servis_hepsi.PageVisible == true)
            {
                İ.SelectedTabPage = xtraTabPage_servis_hepsi;
            }
            else
            {
                xtraTabPage_servis_hepsi.PageVisible = true;
                İ.SelectedTabPage = xtraTabPage_servis_hepsi;
            }
        }


        public string servisId = "";

        private void servisiTamamla()
        {
            if (servisId != "")
            {
                DialogResult durum = XtraMessageBox.Show("S" + servisId + " nolu teknik servisi silmek istediğinizden emin misiniz?", "S" + servisId + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.Yes == durum)
                {
                    MySqlCommand komut = new MySqlCommand("update servis_hareketler set randevu=@randevu where id=@id", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", Convert.ToInt32(servisId));
                    komut.Parameters.AddWithValue("@randevu", "4");
                    komut.ExecuteNonQuery();
                    gridkontrolgöster();
                    //servissayısınıyazdır();


                    for (int i = 1; i < 11; i++)
                    {
                        string sutun = "";

                        if (i==1)
                        {
                            sutun = "bir";
                        }
                        if (i == 2)
                        {
                            sutun = "iki";
                        }
                        if (i == 3)
                        {
                            sutun = "uc";
                        }
                        if (i == 4)
                        {
                            sutun = "dort";
                        }
                        if (i == 5)
                        {
                            sutun = "bes";
                        }
                        if (i == 6)
                        {
                            sutun = "alti";
                        }
                        if (i == 7)
                        {
                            sutun = "yedi";
                        }
                        if (i == 8)
                        {
                            sutun = "sekiz";
                        }
                        if (i == 9)
                        {
                            sutun = "dokuz";
                        }
                        if (i == 10)
                        {
                            sutun = "onn";
                        }

                        try
                        {
                            MySqlCommand komutTarih = new MySqlCommand("update tarih set " + sutun + "=@randevu where tarih=@tarih and " + sutun + "=@musteriId", blg.bağlantı());
                            komutTarih.Parameters.Clear();
                            komutTarih.Parameters.AddWithValue("@musteriId", musteriId);
                            komutTarih.Parameters.AddWithValue("@randevu", "");
                            komutTarih.Parameters.AddWithValue("@tarih", randevuTarih);
                            komutTarih.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                XtraMessageBox.Show("Servis seçimi yapılmadan silme işlemi yapılamaz!");
            }
        }

        private void servisaç()
        {
            frm_ts_yeniservis_frm frm = new frm_ts_yeniservis_frm();
            frm.ShowDialog();
        }

        private void düzenle()
        {
            if (servisId != "")
            {
                frm_ts_yeniservis_frm frm = new frm_ts_yeniservis_frm();
                frm.duzenlenecekId = servisId;
                frm.duzenlenecekMusteriId = musteriId;
                frm.musteriId = musteriId;
                frm.Show();
                //splashScreenManager1.CloseWaitForm();
            }
            else
            {
                XtraMessageBox.Show("Servis seçimi yapılmadan düzenleme işlemi yapılamaz!");
            }
        }

        private void sil()
        {
            if (servisId != "d")
            {
                DialogResult durum = XtraMessageBox.Show("" + lbl_ayrıntı_takip_no.Text + " nolu teknik servisi silmek istediğinizden emin misiniz?", "" + lbl_ayrıntı_takip_no.Text + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.Yes == durum)
                {
                    MySqlCommand komut = new MySqlCommand("update ts_servis set sil=@sil where id=@id", blg.bağlantı());
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", servisId);
                    komut.Parameters.AddWithValue("@sil", 1);
                    komut.ExecuteNonQuery();
                    gridkontrolgöster();
                    servissayısınıyazdır();
                }
                else
                {

                }
            }
            else
            {
                XtraMessageBox.Show("Servis seçimi yapılmadan silme işlemi yapılamaz!");
            }
        }

        private void servisikapat()
        {
            if (servisId != "")
            {
                frm_ts_servisgüncelle_frm frm = new frm_ts_servisgüncelle_frm();
                frm.lbl_kapatılacak_id.Text = servisId;
                frm.lbl_gün_id.Text = servisId;
                frm.ShowDialog();
                //splashScreenManager1.CloseWaitForm();
            }
            else
            {
                XtraMessageBox.Show("Servis seçimi yapılmadan servis kapatma işlemi yapılamaz!");
            }
        }

        private void servisigüncelle()
        {
            if (servisId != "")
            {
                frm_ts_servisgüncelle_frm frm = new frm_ts_servisgüncelle_frm();
                frm.lbl_gün_id.Text = servisId;
                frm.ShowDialog();
                //splashScreenManager1.CloseWaitForm();
            }
            else
            {
                XtraMessageBox.Show("Servis seçimi yapılmadan servis güncelleme işlemi yapılamaz!");
            }
        }

        public void btn_yeniservis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            servisaç();
        }


        private void btn_servisidüzenle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            düzenle();
        }

        private void btn_servisisil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sil();
        }

        private void btn_serviskapat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            servisikapat();
        }

        private void btn_servisgüncelle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            servisigüncelle();
        }

        private void ayrıntılarıyazdır()
        {

            //if (blg.bağlantı().State == ConnectionState.Open)
            //{
            //    blg.bağlantı().Close();
            //}

            //string model;
            //string marka;
            //string ürün;
            //panelControl_ayrıntı.Visible = true;
            ////lbl_ürünbilgileri.Visible = true;
            ////lbl_servishikayesi.Visible = true;
            //MySqlCommand komut = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
            //komut.Parameters.Clear();
            //komut.Parameters.AddWithValue("@id", servisId.ToString().Trim());
            //komut.ExecuteNonQuery();
            //MySqlDataReader oku = komut.ExecuteReader();
            //while (oku.Read())
            //{
            //    lbl_ayrıntı_müşteriadsoyad.Text = oku["musteriadsoyad"].ToString();
            //    ürün = oku["urun"].ToString();
            //    model = oku["model"].ToString();
            //    marka = oku["marka"].ToString();
            //    lbl_ayrıntı_arıza.Text = oku["ariza"].ToString();
            //    lbl_ayrıntı_açıklama.Text = oku["aciklama"].ToString();
            //    lbl_ayrıntı_takip_no.Text = "TS" + oku["id"].ToString() + "";
            //    lbl_ayrıntı_ürün.Text = "" + ürün + "-" + marka + "-" + model + "";

            //    string bosluk1 = "";
            //    string bosluk2 = "";
            //    string bosluk3 = "";
            //    string aks1 = oku["aks1"].ToString();
            //    string aks2 = oku["aks2"].ToString();
            //    string aks3 = oku["aks3"].ToString();
            //    string aks4 = oku["aks4"].ToString();
            //    if (aks1 != "" && aks2 != "")
            //    {
            //        bosluk1 = ",";
            //    }
            //    if (aks2 != "" && aks3 != "")
            //    {
            //        bosluk2 = ",";
            //    }
            //    if (aks3 != "" && aks4 != "")
            //    {
            //        bosluk3 = ",";
            //    }
            //    lbl_ayrıntı_aksesuar.Text = "" + aks1 + " " + bosluk1 + " " + aks2 + " " + bosluk2 + " " + aks3 + " " + bosluk3 + " " + aks4 + "";
            //}
            //oku.Close();
            //servishareketleriyazdır();
        }

        public string musteriId = "";
        public string randevuTarih = "";

  

        private void gridControl_tamamlanan_Click(object sender, EventArgs e)
        {
            try
            {
                servisId = gridView_tamamlanan.GetRowCellValue(gridView_tamamlanan.FocusedRowHandle, "id").ToString();
                musteriId = gridView_tamamlanan.GetRowCellValue(gridView_tamamlanan.FocusedRowHandle, "musteriid").ToString();
            }
            catch (Exception)
            {

            }
        }

        private void gridControl_devam_Click(object sender, EventArgs e)
        {
            try
            {
                servisId = gridView_Devam.GetRowCellValue(gridView_Devam.FocusedRowHandle, "id").ToString();
                musteriId = gridView_Devam.GetRowCellValue(gridView_Devam.FocusedRowHandle, "musteriid").ToString();
                randevuTarih = gridView_Devam.GetRowCellValue(gridView_Devam.FocusedRowHandle, "tarih").ToString();
            }
            catch (Exception)
            {

                
            }
        }



        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                servisId = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "id").ToString();
            }
            catch (Exception)
            {

                
            }
        }

        private void gridControl_tümü_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            //ayrıntılarıyazdır();
        }

        private void btn_silinenler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabPagesilinen.PageVisible = true;

            İ.SelectedTabPage = xtraTabPagesilinen;            
        }

        private void tab_control_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (silinenServisleriGeriAl == "true" && İ.SelectedTabPage == xtraTabPagesilinen)
            {
                ribbonPageGroup_silinengerial.Visible = true;
            }
            else
            {
                ribbonPageGroup_silinengerial.Visible = false;
            }

            if (İ.SelectedTabPage == xtraTabPage_devam)
            {
                rpg_çıktı_devam.Visible = true;
            }
            else
            {
                rpg_çıktı_devam.Visible = false;
            }

            if (İ.SelectedTabPage == xtraTabPage_biten)
            {
                rpg_çıktı_biten.Visible = true;
            }
            else
            {
                rpg_çıktı_biten.Visible = false;
            }

            if (İ.SelectedTabPage == xtraTabPage_servis_hepsi)
            {
                rpg_çıktı_tümü.Visible = true;
            }
            else
            {
                rpg_çıktı_tümü.Visible = false;
            }

            if (İ.SelectedTabPage == xtraTabPagesilinen)
            {
                
            }
            else
            {
                xtraTabPagesilinen.PageVisible = false;
            }
        }

        private void btn_sil_gerial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult durum = XtraMessageBox.Show("" + lbl_ayrıntı_takip_no.Text + " nolu teknik servisi silinmesini iptal etmek istediğinizden emin misiniz?", "" + lbl_ayrıntı_takip_no.Text + "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == durum)
            {
                MySqlCommand komut = new MySqlCommand("update ts_servis set sil=@sil where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", servisId);
                komut.Parameters.AddWithValue("@sil", 0);
                komut.ExecuteNonQuery();
                gridkontrolgöster();
                servissayısınıyazdır();
            }
            else
            {

            }
        }

        public void servishareketleriyazdır()
        {
            if (blg.bağlantı().State == ConnectionState.Open)
            {
                blg.bağlantı().Close();
            }

            //listBoxControl_anasayfa.Visible = true;
            //listBoxControl_anasayfa.Items.Clear();
            MySqlCommand listele = new MySqlCommand("select *from ts_servis_güncelleme where servisid=@id;", blg.bağlantı());
            listele.Parameters.Clear();
            listele.Parameters.AddWithValue("@id", servisId);
            MySqlDataReader read = listele.ExecuteReader();
            while (read.Read())
            {
                //listBoxControl_anasayfa.Items.Add("  " + read[2] + "  " + read[3] + "   " + read[1]);
            }
            read.Close();
        }

        #region DosyayaAktar

        private void exceleaktar_tümü()
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl_tumu.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (View != null)
            {
                saveFileDialog1.Filter = "Excel Old (XLS)|*.xls|Excel New (XLSX)|*.xlsx";
                saveFileDialog1.FileName = string.Empty;
                DialogResult rex = saveFileDialog1.ShowDialog();
                if (rex == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var fileName = saveFileDialog1.FileName;
                        if (saveFileDialog1.FilterIndex == 1)
                        {
                            View.ExportToXls(fileName);
                        }
                        else if (saveFileDialog1.FilterIndex == 2)
                        {
                            View.ExportToXlsx(fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exceleaktar_devam()
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl_devam.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (View != null)
            {
                saveFileDialog1.Filter = "Excel Old (XLS)|*.xls|Excel New (XLSX)|*.xlsx";
                saveFileDialog1.FileName = string.Empty;
                DialogResult rex = saveFileDialog1.ShowDialog();
                if (rex == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var fileName = saveFileDialog1.FileName;
                        if (saveFileDialog1.FilterIndex == 1)
                        {
                            View.ExportToXls(fileName);
                        }
                        else if (saveFileDialog1.FilterIndex == 2)
                        {
                            View.ExportToXlsx(fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exceleaktar_biten()
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl_tamamlanan.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (View != null)
            {
                saveFileDialog1.Filter = "Excel Old (XLS)|*.xls|Excel New (XLSX)|*.xlsx";
                saveFileDialog1.FileName = string.Empty;
                DialogResult rex = saveFileDialog1.ShowDialog();
                if (rex == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var fileName = saveFileDialog1.FileName;
                        if (saveFileDialog1.FilterIndex == 1)
                        {
                            View.ExportToXls(fileName);
                        }
                        else if (saveFileDialog1.FilterIndex == 2)
                        {
                            View.ExportToXlsx(fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pdf_devam()
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl_devam.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (View != null)
            {
                saveFileDialog1.Filter = "PDF|*.pdf";
                saveFileDialog1.FileName = string.Empty;
                DialogResult rex = saveFileDialog1.ShowDialog();
                if (rex == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var fileName = saveFileDialog1.FileName;
                        if (saveFileDialog1.FilterIndex == 1)
                        {
                            View.ExportToPdf(fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pdf_biten()
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl_tamamlanan.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (View != null)
            {
                saveFileDialog1.Filter = "PDF|*.pdf";
                saveFileDialog1.FileName = string.Empty;
                DialogResult rex = saveFileDialog1.ShowDialog();
                if (rex == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var fileName = saveFileDialog1.FileName;
                        if (saveFileDialog1.FilterIndex == 1)
                        {
                            View.ExportToPdf(fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }               

        private void öniz_tümü()
        {
            rpr_ts_tümü rapor = new rpr_ts_tümü();
            MySqlDataAdapter komut2 = new MySqlDataAdapter("select *from ts_servis", blg.bağlantı());

            DataTable ds = new DataTable();
            komut2.Fill(ds);

            rapor.bindingSource1.DataSource = ds;
            rapor.lbl_başlık.Text = "GENEL SERVİS RAPORU";

            MySqlCommand komut = new MySqlCommand("select *from firma", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            MySqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {
                rapor.lbl_firma.Text = oku3["firmadad"].ToString();
                rapor.pic_firmaLogo.ImageUrl = oku3["logoyol"].ToString();
            }

            ReportPrintTool pt = new ReportPrintTool(rapor);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreviewDialog();
        }
        private void öniz_devam()
        {
            rpr_ts_tümü rapor = new rpr_ts_tümü();
            MySqlDataAdapter komut2 = new MySqlDataAdapter("select *from ts_servis", blg.bağlantı());

            DataTable ds = new DataTable();
            komut2.Fill(ds);

            rapor.bindingSource1.DataSource = ds;
            rapor.bindingSource1.Filter = "durum='0'";
            rapor.lbl_başlık.Text = "DEVAM EDEN SERVİS RAPORU";

            MySqlCommand komut = new MySqlCommand("select *from firma", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            MySqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {
                rapor.lbl_firma.Text = oku3["firmadad"].ToString();
                rapor.pic_firmaLogo.ImageUrl = oku3["logoyol"].ToString();
            }

            ReportPrintTool pt = new ReportPrintTool(rapor);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreviewDialog();
        }
        
        private void öniz_biten()
        {
            rpr_ts_tümü rapor = new rpr_ts_tümü();
            MySqlDataAdapter komut2 = new MySqlDataAdapter("select *from ts_servis", blg.bağlantı());

            DataTable ds = new DataTable();
            komut2.Fill(ds);

            rapor.bindingSource1.DataSource = ds;
            rapor.bindingSource1.Filter = "durum='1'";
            rapor.lbl_başlık.Text = "KAPANAN SERVİS RAPORU";


            MySqlCommand komut = new MySqlCommand("select *from firma", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            MySqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {
                rapor.lbl_firma.Text = oku3["firmadad"].ToString();
                rapor.pic_firmaLogo.ImageUrl = oku3["logoyol"].ToString();
            }

            ReportPrintTool pt = new ReportPrintTool(rapor);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreviewDialog();
        }


        private void btn_exceleaktar_tümü_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            exceleaktar_tümü();
        }

        private void btn_exceleaktar_devam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            exceleaktar_devam();
        }

        private void btn_exceleaktar_biten_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            exceleaktar_biten();
        }

        private void btn_pdf_devam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pdf_devam();
        }

        private void btn_pdf_biten_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pdf_biten();
        }

        private void btn_önizleme_tümü_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            öniz_tümü();
        }

        private void btn_önizleme_devam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            öniz_devam();
        }

        private void btn_önizleme_biten_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            öniz_biten();
        }

        #endregion

        private void btn_yazdır_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MySqlDataAdapter yazdır = new MySqlDataAdapter("SELECT *FROM ts_servis WHERE id=@id", blg.bağlantı());

            DataTable dt = new DataTable();
            yazdır.SelectCommand.Parameters.AddWithValue("@id", servisId);
            yazdır.Fill(dt);
            rpr_serviskapama_a4 kr = new rpr_serviskapama_a4();
            kr.DataSource = dt;

            using (ReportPrintTool printTool = new ReportPrintTool(kr))
            {
                printTool.ShowPreviewDialog();
                kr.DesignerOptions.ShowPrintingWarnings = false;
                kr.ShowPrintMarginsWarning = false;
            }
            yazdır.Dispose();
        }

        private void btn_servis_gunluk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rpr_ts_tümü rapor = new rpr_ts_tümü();
            MySqlDataAdapter komut2 = new MySqlDataAdapter("select *from ts_servis", blg.bağlantı());
            DataTable ds = new DataTable();
            komut2.Fill(ds);
            rapor.bindingSource1.DataSource = ds;
            rapor.bindingSource1.Filter = "tarih = '" + blg.tarih() + "'";

            MySqlCommand komut = new MySqlCommand("select *from firma", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            MySqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {
                rapor.lbl_firma.Text = oku3["firmadad"].ToString();
                rapor.pic_firmaLogo.ImageUrl = oku3["logoyol"].ToString();
            }
            oku3.Close();

            ReportPrintTool pt = new ReportPrintTool(rapor);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreviewDialog();
        }

        private void btn_raporol_devam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ts_raporol frm = new frm_ts_raporol();
            frm.ShowDialog();
        }

        #region SAĞTIK

        private void sagtik_servisTamamlandi_Click(object sender, EventArgs e)
        {
            servisiTamamla();
        }

        private void sağtık_yeniservisaç_Click(object sender, EventArgs e)
        {
            servisaç();
        }

        private void sağtık_düzenle_Click(object sender, EventArgs e)
        {
            düzenle();
        }

        private void sağtık_sil_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void sağtık_güncelle_Click(object sender, EventArgs e)
        {
            servisigüncelle();
        }

        private void sağtık_yazdır_Click(object sender, EventArgs e)
        {
            öniz_devam();
        }

        private void sağtık_exceleaktar_Click(object sender, EventArgs e)
        {
            exceleaktar_devam();
        }

        private void sağtık_pdf_Click(object sender, EventArgs e)
        {
            pdf_devam();
        }

        private void sağtık_müşteriekstre_Click(object sender, EventArgs e)
        {
            rpr_ts_tümü rapor = new rpr_ts_tümü();
            MySqlDataAdapter komut2 = new MySqlDataAdapter("select *from ts_servis", blg.bağlantı());

            DataTable ds = new DataTable();
            komut2.Fill(ds);

            rapor.bindingSource1.DataSource = ds;
            rapor.bindingSource1.Filter = "musteriadsoyad = '" + lbl_ayrıntı_müşteriadsoyad.Text + "'";

            MySqlCommand komut = new MySqlCommand("select *from firma", blg.bağlantı());
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", 1);
            komut.ExecuteNonQuery();
            MySqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {
                rapor.lbl_firma.Text = oku3["firmadad"].ToString();
                rapor.pic_firmaLogo.ImageUrl = oku3["logoyol"].ToString();
            }

            ReportPrintTool pt = new ReportPrintTool(rapor);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreviewDialog();
        }

        private void sağtık_servisformunuaç_Click(object sender, EventArgs e)
        {
            string raporstil = "";

            MySqlCommand komut_stil = new MySqlCommand("select *from ayarlar where id=@id", blg.bağlantı());
            komut_stil.Parameters.Clear();
            komut_stil.Parameters.AddWithValue("@id", 1);
            komut_stil.ExecuteNonQuery();
            MySqlDataReader oku_stil = komut_stil.ExecuteReader();
            while (oku_stil.Read())
            {
                raporstil = oku_stil["raporstili"].ToString();
            }

            if (raporstil == "1")
            {


                string müşteriİd = "";
                rpr_ts_servisformu_a4 rapor = new rpr_ts_servisformu_a4();

                MySqlCommand komut2 = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
                komut2.Parameters.Clear();
                komut2.Parameters.AddWithValue("@id", servisId);
                komut2.ExecuteNonQuery();
                MySqlDataReader oku3 = komut2.ExecuteReader();
                while (oku3.Read())
                {
                    rapor.lbl_servisİd.Text = "TSA" + servisId + "";

                    müşteriİd = oku3["musteriid"].ToString();

                    rapor.lbl_ürün.Text = oku3["urun"].ToString();
                    rapor.lbl_marka.Text = oku3["marka"].ToString();
                    rapor.lbl_model.Text = oku3["model"].ToString();
                    rapor.lbl_arıza.Text = oku3["ariza"].ToString();
                    rapor.lbl_servisTarih.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());
                    rapor.lbl_aks1.Text = oku3["aks1"].ToString();
                    rapor.lbl_aks2.Text = oku3["aks2"].ToString();
                    rapor.lbl_aks3.Text = oku3["aks3"].ToString();
                    rapor.lbl_aks4.Text = oku3["aks4"].ToString();
                }

                MySqlCommand komut = new MySqlCommand("select *from musteriler where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", müşteriİd);
                komut.ExecuteNonQuery();
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    rapor.lbl_müşteriAdSoyad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_müşteriEposta.Text = oku["eposta"].ToString();
                    rapor.lbl_müşteriİletişim.Text = oku["iletisim"].ToString();
                    rapor.lbl_müşteriAdres.Text = oku["adres"].ToString();
                    rapor.lbl_teslimedenMüşteri.Text = oku["musteriadsoyad"].ToString();
                }

                rapor.lbl_tarih.Text = blg.tarih().ToString(blg.tarih_format());
                rapor.lbl_barcodeServis.Text = "TSA" + servisId + "";
                rapor.lbl_barcodeServis_alt.Text = "TSA" + servisId + "";

                MySqlCommand komutF = new MySqlCommand("select *from firma where id=@id", blg.bağlantı());
                komutF.Parameters.Clear();
                komutF.Parameters.AddWithValue("@id", 1);
                komutF.ExecuteNonQuery();
                MySqlDataReader okuF = komutF.ExecuteReader();
                while (okuF.Read())
                {
                    rapor.lbl_teslimAlan.Text = okuF["firmadad"].ToString();
                }
                okuF.Close();

                ReportPrintTool pt = new ReportPrintTool(rapor);
                pt.AutoShowParametersPanel = false;
                pt.ShowPreviewDialog();
            }
            if (raporstil == "2")
            {
                string müşteriİd = "";
                rpr_a4a5 rapor = new rpr_a4a5();

                MySqlCommand komut2 = new MySqlCommand("select *from ts_servis where id=@id", blg.bağlantı());
                komut2.Parameters.Clear();
                komut2.Parameters.AddWithValue("@id", servisId);
                komut2.ExecuteNonQuery();
                MySqlDataReader oku3 = komut2.ExecuteReader();
                while (oku3.Read())
                {
                    rapor.lbl_üst_servisno.Text = "TSA" + servisId + "";
                    rapor.lbl_alt_servisno.Text = "TSA" + servisId + "";

                    müşteriİd = oku3["musteriid"].ToString();

                    rapor.lbl_üst_ürün.Text = oku3["urun"].ToString();
                    rapor.lbl_üst_marka.Text = oku3["marka"].ToString();
                    rapor.lbl_üst_model.Text = oku3["model"].ToString();
                    rapor.lbl_üst_ariza.Text = oku3["ariza"].ToString();

                    rapor.lbl_üst_servistarihi.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());
                    rapor.lbl_üst_aks1.Text = oku3["aks1"].ToString();
                    rapor.aks2lbl_üst_.Text = oku3["aks2"].ToString();
                    rapor.lbl_üst_aks3.Text = oku3["aks3"].ToString();
                    rapor.lbl_üst_aks4.Text = oku3["aks4"].ToString();


                    rapor.lbl_alt_ürün.Text = oku3["urun"].ToString();
                    rapor.lbl_alt_marka.Text = oku3["marka"].ToString();
                    rapor.lbl_alt_model.Text = oku3["model"].ToString();
                    rapor.lbl_alt_ariza.Text = oku3["ariza"].ToString();

                    rapor.lbl_alt_servistarihi.Text = Convert.ToDateTime(oku3["tarih"]).ToString(blg.tarih_format());
                    rapor.lbl_alt_aks1.Text = oku3["aks1"].ToString();
                    rapor.lbl_alt_aks2.Text = oku3["aks2"].ToString();
                    rapor.lbl_alt_aks3.Text = oku3["aks3"].ToString();
                    rapor.lbl_alt_aks4.Text = oku3["aks4"].ToString();
                }
                oku3.Close();

                MySqlCommand komut = new MySqlCommand("select *from musteriler where id=@id", blg.bağlantı());
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", müşteriİd);
                komut.ExecuteNonQuery();
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    rapor.lbl_üst_müşteriad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_üst_teslimeden.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_üst_eposta.Text = oku["eposta"].ToString();
                    rapor.lbl_üst_müştel.Text = oku["iletisim"].ToString();
                    rapor.lbl_üst_adres.Text = oku["adres"].ToString();

                    rapor.lbl_alt_musteriadsoyad.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_alt_teslimeden.Text = oku["musteriadsoyad"].ToString();
                    rapor.lbl_alt_eposta.Text = oku["eposta"].ToString();
                    rapor.lbl_alt_tel.Text = oku["iletisim"].ToString();
                    rapor.lbl_alt_müştadres.Text = oku["adres"].ToString();
                }
                oku.Close();

                rapor.lbl_üst_barkod.Text = "TSA" + servisId + "";
                rapor.lbl_alt_barkod.Text = "TSA" + servisId + "";
                rapor.lbl_alt_barkod2.Text = "TSA" + servisId + "";

                rapor.lbl_alt_tyeslimtarihi.Text = blg.tarih().ToString(blg.tarih_format());
                rapor.lbl_üst_tyeslimtarihi.Text = blg.tarih().ToString(blg.tarih_format());

                MySqlCommand komutF = new MySqlCommand("select *from firma where id=@id", blg.bağlantı());
                komutF.Parameters.Clear();
                komutF.Parameters.AddWithValue("@id", 1);
                komutF.ExecuteNonQuery();
                MySqlDataReader okuF = komutF.ExecuteReader();
                while (okuF.Read())
                {
                    rapor.lbl_alt_teslimalan.Text = okuF["firmadad"].ToString();
                    rapor.lbl_üst_teslimalan.Text = okuF["firmadad"].ToString();
                }
                okuF.Close();

                ReportPrintTool pt = new ReportPrintTool(rapor);
                pt.AutoShowParametersPanel = false;
                pt.ShowPreviewDialog();
            }
        }

        private void sağtık_servisformu_yükle_Click(object sender, EventArgs e)
        {
            frm_ts_sformyükle frm = new frm_ts_sformyükle();
            frm.Show();
            frm.lbl_gelen_servisid.Text = servisId;
            frm.lbl_direkt.Text = "bağımlı";
        }

        private void sağtık_servisformugörüntüle_Click(object sender, EventArgs e)
        {
            string pic_logoyol = "";
            string tarih = "";


            MySqlCommand komut_firmad = new MySqlCommand("SELECT *FROM ts_servisform WHERE servisid=@id", blg.bağlantı());
            komut_firmad.Parameters.Clear();
            komut_firmad.Parameters.AddWithValue("@id", servisId);
            komut_firmad.ExecuteNonQuery();
            MySqlDataReader oku_firmaad = komut_firmad.ExecuteReader();
            while (oku_firmaad.Read())
            {
                pic_logoyol = oku_firmaad["yol"].ToString();
                tarih = oku_firmaad["yüklemetarihiac"].ToString();
            }

            oku_firmaad.Close();

            rpr_kapananformGör kr = new rpr_kapananformGör();

            try
            {
                kr.xrPictureBox1.Image = Image.FromFile(pic_logoyol);
                kr.lbl_servisid.Text = servisId;
                kr.lbl_yüklemeTarihi.Text = tarih;
            }
            catch (Exception)
            {
                return;
            }

            using (ReportPrintTool printTool = new ReportPrintTool(kr))
            {
                printTool.ShowPreviewDialog();
                kr.DesignerOptions.ShowPrintingWarnings = false;
                kr.ShowPrintMarginsWarning = false;
            }
        }

        #endregion

        private void btn_servisformu_yükle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ts_sformyükle frm = new frm_ts_sformyükle();
            frm.Show();
            frm.lbl_direkt.Text = "bağımsız";
        }

        private void lbl_kul_servisformuyükle_TextChanged(object sender, EventArgs e)
        {

        }

        private void servisKapanışFormuEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ts_sformyükle frm = new frm_ts_sformyükle();
            frm.Show();
            frm.lbl_direkt.Text = "bağımlı_kapanış";
            frm.lbl_gelen_servisid.Text = servisId;
        }

        private void btn_kapanışServisFormuYükle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ts_sformyükle frm = new frm_ts_sformyükle();
            frm.Show();
            frm.lbl_direkt.Text = "bağımsız_kapanış";
        }

        private void servisKapanışFormuGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pic_logoyol = "";
            string tarih = "";

            MySqlCommand komut_firmad = new MySqlCommand("SELECT *FROM ts_servisform WHERE servisidkapa=@id", blg.bağlantı());
            komut_firmad.Parameters.Clear();
            komut_firmad.Parameters.AddWithValue("@id", servisId);
            komut_firmad.ExecuteNonQuery();
            MySqlDataReader oku_firmaad = komut_firmad.ExecuteReader();
            while (oku_firmaad.Read())
            {
                pic_logoyol = oku_firmaad["yolkapa"].ToString();
                tarih = oku_firmaad["yüklemetarihikapama"].ToString();
            }

            oku_firmaad.Close();

            rpr_kapananformGör kr = new rpr_kapananformGör();
            try
            {
                kr.xrPictureBox1.Image = Image.FromFile(pic_logoyol);
                kr.lbl_servisid.Text = servisId;
                kr.lbl_kontrol.Text = "kapama";
                kr.lbl_yüklemeTarihi.Text = tarih;
            }
            catch (Exception)
            {
                return;
            }

            using (ReportPrintTool printTool = new ReportPrintTool(kr))
            {
                printTool.ShowPreviewDialog();
                kr.DesignerOptions.ShowPrintingWarnings = false;
                kr.ShowPrintMarginsWarning = false;
            }
        }

        private void gridControl_tumu_Click(object sender, EventArgs e)
        {
            try
            {
                servisId = gridView_tumu.GetRowCellValue(gridView_tamamlanan.FocusedRowHandle, "id").ToString();
                musteriId = gridView_tumu.GetRowCellValue(gridView_tamamlanan.FocusedRowHandle, "musteriid").ToString();
            }
            catch (Exception)
            {

            }
        }

        private void gridView_Devam_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                servisId = gridView_Devam.GetRowCellValue(gridView_Devam.FocusedRowHandle, "id").ToString();
            }
            catch (Exception)
            {

                
            }
            
            ayrıntılarıyazdır();
        }

        private void gridView_biten_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                servisId = gridView_tamamlanan.GetRowCellValue(gridView_tamamlanan.FocusedRowHandle, "id").ToString();
            }
            catch (Exception)
            {

                
            }
            
            ayrıntılarıyazdır();
        }

        private void gridView_tümü_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                servisId = gridView_tumu.GetRowCellValue(gridView_tumu.FocusedRowHandle, "id").ToString();
            }
            catch (Exception)
            {

                
            }
            
            ayrıntılarıyazdır();
        }

        private void btn_topluFormYükle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ts_sformyükle_toplu frm = new frm_ts_sformyükle_toplu();
            frm.ShowDialog();
        }

        private void tab_control_Click(object sender, EventArgs e)
        {

        }

        private void btnRandevuEkrani_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ts_randevuEkrani frm = new frm_ts_randevuEkrani();
            frm.Show();
        }
    }
}
