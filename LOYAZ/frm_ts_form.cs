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

namespace LOYAZ
{
    public partial class panel_ts_anasayfa : DevExpress.XtraEditors.XtraForm
    {
        public panel_ts_anasayfa()
        {
            InitializeComponent();
        }

        private void button_anasayfa_Click(object sender, EventArgs e)
        {
            frm_anasayfa_form frm = (frm_anasayfa_form)Application.OpenForms["anasayfa"];
            frm.panel_ana.Controls.Clear();
            
            frm_anasayfa_panel panel = new frm_anasayfa_panel();
            panel.TopLevel = false;
            
            frm.panel_ana.Controls.Add(panel);
            
            panel.Show();
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            
        }

        private void button_servisaç_Click(object sender, EventArgs e)
        {
            frm_ts_yeniservis_frm frm = new frm_ts_yeniservis_frm();
            frm.Show();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void button_servisiskapat_Click(object sender, EventArgs e)
        {
            frm_ts_servisgüncelle_frm frm = new frm_ts_servisgüncelle_frm();
            frm.Show();
        }

        private void panel_ts_anasayfa_Load(object sender, EventArgs e)
        {
            gridkontrolgöster();
        }

        public void gridkontrolgöster()
        {
            // TODO: Bu kod satırı 'lozyaDataSet1Local.ts_servis' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ts_servisTableAdapter.Fill(this.lozyaDataSet1Local.ts_servis);
        }

        private void tab_control_HeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.HeaderButtonEventArgs e)
        {
            
        }

        private void tab_control_CloseButtonClick(object sender, EventArgs e)
        {
            //tab_control.SelectedTabPage.PageVisible = false;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_ts_anasayfa frm = new frm_ts_anasayfa();
            frm.MdiParent = this;
            frm.TopLevel = true;
            frm.Show();
        }
    }
}