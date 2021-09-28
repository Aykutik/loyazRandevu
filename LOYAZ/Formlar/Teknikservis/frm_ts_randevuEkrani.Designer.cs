
namespace LOYAZ.Formlar.Teknikservis
{
    partial class frm_ts_randevuEkrani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timerSanye = new System.Windows.Forms.Timer(this.components);
            this.groupControlHeader = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_saniye = new DevExpress.XtraEditors.LabelControl();
            this.lbl_saat = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_dakika = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lblTarih = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl_randevuEkrani = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlRandevuEkrani = new DevExpress.XtraGrid.GridControl();
            this.gridViewRandevuEkrani = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlHeader)).BeginInit();
            this.groupControlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_randevuEkrani)).BeginInit();
            this.xtraTabControl_randevuEkrani.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRandevuEkrani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRandevuEkrani)).BeginInit();
            this.SuspendLayout();
            // 
            // timerSanye
            // 
            this.timerSanye.Enabled = true;
            this.timerSanye.Interval = 1000;
            this.timerSanye.Tick += new System.EventHandler(this.timerSanye_Tick);
            // 
            // groupControlHeader
            // 
            this.groupControlHeader.Controls.Add(this.groupControl4);
            this.groupControlHeader.Controls.Add(this.groupControl3);
            this.groupControlHeader.Controls.Add(this.groupControl2);
            this.groupControlHeader.Controls.Add(this.groupControl1);
            this.groupControlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlHeader.Location = new System.Drawing.Point(0, 0);
            this.groupControlHeader.Name = "groupControlHeader";
            this.groupControlHeader.ShowCaption = false;
            this.groupControlHeader.Size = new System.Drawing.Size(1177, 95);
            this.groupControlHeader.TabIndex = 1;
            this.groupControlHeader.Text = "groupControl1";
            // 
            // groupControl4
            // 
            this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl4.Controls.Add(this.lbl_saniye);
            this.groupControl4.Controls.Add(this.lbl_saat);
            this.groupControl4.Controls.Add(this.labelControl2);
            this.groupControl4.Controls.Add(this.lbl_dakika);
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl4.Location = new System.Drawing.Point(771, 2);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.ShowCaption = false;
            this.groupControl4.Size = new System.Drawing.Size(365, 91);
            this.groupControl4.TabIndex = 10;
            this.groupControl4.Text = "groupControl4";
            // 
            // lbl_saniye
            // 
            this.lbl_saniye.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_saniye.Appearance.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.lbl_saniye.Appearance.Options.UseFont = true;
            this.lbl_saniye.Location = new System.Drawing.Point(153, 3);
            this.lbl_saniye.Name = "lbl_saniye";
            this.lbl_saniye.Size = new System.Drawing.Size(86, 81);
            this.lbl_saniye.TabIndex = 6;
            this.lbl_saniye.Text = "00";
            // 
            // lbl_saat
            // 
            this.lbl_saat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_saat.Appearance.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.lbl_saat.Appearance.Options.UseFont = true;
            this.lbl_saat.Location = new System.Drawing.Point(30, 4);
            this.lbl_saat.Name = "lbl_saat";
            this.lbl_saat.Size = new System.Drawing.Size(86, 81);
            this.lbl_saat.TabIndex = 8;
            this.lbl_saat.Text = "24";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(245, -3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 81);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = ":";
            // 
            // lbl_dakika
            // 
            this.lbl_dakika.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_dakika.Appearance.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.lbl_dakika.Appearance.ForeColor = System.Drawing.Color.SandyBrown;
            this.lbl_dakika.Appearance.Options.UseFont = true;
            this.lbl_dakika.Appearance.Options.UseForeColor = true;
            this.lbl_dakika.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_dakika.Location = new System.Drawing.Point(275, 4);
            this.lbl_dakika.Name = "lbl_dakika";
            this.lbl_dakika.Size = new System.Drawing.Size(86, 81);
            this.lbl_dakika.TabIndex = 7;
            this.lbl_dakika.Text = "00";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(123, -2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 81);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = ":";
            // 
            // groupControl3
            // 
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.Controls.Add(this.lblTarih);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl3.Location = new System.Drawing.Point(18, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(759, 91);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "groupControl1";
            // 
            // lblTarih
            // 
            this.lblTarih.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold);
            this.lblTarih.Appearance.Options.UseFont = true;
            this.lblTarih.Location = new System.Drawing.Point(6, 4);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(82, 77);
            this.lblTarih.TabIndex = 8;
            this.lblTarih.Text = "24";
            // 
            // groupControl2
            // 
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(16, 91);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "groupControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(1136, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(39, 91);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupControlMain
            // 
            this.groupControlMain.Controls.Add(this.xtraTabControl_randevuEkrani);
            this.groupControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlMain.Location = new System.Drawing.Point(0, 95);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.ShowCaption = false;
            this.groupControlMain.Size = new System.Drawing.Size(1177, 564);
            this.groupControlMain.TabIndex = 1;
            this.groupControlMain.Text = "groupControl1";
            // 
            // xtraTabControl_randevuEkrani
            // 
            this.xtraTabControl_randevuEkrani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_randevuEkrani.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl_randevuEkrani.Name = "xtraTabControl_randevuEkrani";
            this.xtraTabControl_randevuEkrani.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl_randevuEkrani.Size = new System.Drawing.Size(1173, 560);
            this.xtraTabControl_randevuEkrani.TabIndex = 1;
            this.xtraTabControl_randevuEkrani.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControlRandevuEkrani);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1167, 532);
            this.xtraTabPage1.Text = "Randevu Ekranı";
            // 
            // gridControlRandevuEkrani
            // 
            this.gridControlRandevuEkrani.DataSource = this.bindingSource1;
            this.gridControlRandevuEkrani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRandevuEkrani.Location = new System.Drawing.Point(0, 0);
            this.gridControlRandevuEkrani.MainView = this.gridViewRandevuEkrani;
            this.gridControlRandevuEkrani.Name = "gridControlRandevuEkrani";
            this.gridControlRandevuEkrani.Size = new System.Drawing.Size(1167, 532);
            this.gridControlRandevuEkrani.TabIndex = 1;
            this.gridControlRandevuEkrani.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRandevuEkrani});
            // 
            // gridViewRandevuEkrani
            // 
            this.gridViewRandevuEkrani.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.gridViewRandevuEkrani.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewRandevuEkrani.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewRandevuEkrani.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewRandevuEkrani.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.gridViewRandevuEkrani.Appearance.Row.Options.UseFont = true;
            this.gridViewRandevuEkrani.ColumnPanelRowHeight = 50;
            this.gridViewRandevuEkrani.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridViewRandevuEkrani.GridControl = this.gridControlRandevuEkrani;
            this.gridViewRandevuEkrani.Name = "gridViewRandevuEkrani";
            this.gridViewRandevuEkrani.OptionsView.ShowGroupPanel = false;
            this.gridViewRandevuEkrani.OptionsView.ShowIndicator = false;
            this.gridViewRandevuEkrani.RowHeight = 110;
            this.gridViewRandevuEkrani.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "SAAT";
            this.gridColumn1.FieldName = "saat";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 266;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "tarih";
            this.gridColumn2.FieldName = "tarih";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "1";
            this.gridColumn3.FieldName = "musteriad";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 759;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "iptal";
            this.gridColumn4.FieldName = "iptal";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "randevu";
            this.gridColumn5.FieldName = "randevu";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gelmedi";
            this.gridColumn6.FieldName = "gelmedi";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "id";
            this.gridColumn7.FieldName = "id";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1167, 532);
            this.xtraTabPage2.Text = "1";
            // 
            // frm_ts_randevuEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 659);
            this.Controls.Add(this.groupControlMain);
            this.Controls.Add(this.groupControlHeader);
            this.Name = "frm_ts_randevuEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAAT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ts_randevuEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlHeader)).EndInit();
            this.groupControlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_randevuEkrani)).EndInit();
            this.xtraTabControl_randevuEkrani.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRandevuEkrani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRandevuEkrani)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Timer timerSanye;
        private DevExpress.XtraEditors.GroupControl groupControlHeader;
        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lblTarih;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lbl_dakika;
        private DevExpress.XtraEditors.LabelControl lbl_saniye;
        private DevExpress.XtraEditors.LabelControl lbl_saat;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_randevuEkrani;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gridControlRandevuEkrani;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRandevuEkrani;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    }
}