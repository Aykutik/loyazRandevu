namespace LOYAZ.Formlar.Teknikservis
{
    partial class frm_ts_sformyükle_toplu
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleContains formatConditionRuleContains2 = new DevExpress.XtraEditors.FormatConditionRuleContains();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ts_sformyükle_toplu));
            this.gridColumn_Sonuç = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView_topluForm = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Kaynak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Kapanış = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Servis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_gözat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tara = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_topluForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn_Sonuç
            // 
            this.gridColumn_Sonuç.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Sonuç.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn_Sonuç.AppearanceCell.Options.UseFont = true;
            this.gridColumn_Sonuç.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn_Sonuç.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Sonuç.AppearanceHeader.Options.UseFont = true;
            this.gridColumn_Sonuç.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Sonuç.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_Sonuç.Caption = "Sonuç";
            this.gridColumn_Sonuç.FieldName = "sonuç";
            this.gridColumn_Sonuç.Name = "gridColumn_Sonuç";
            this.gridColumn_Sonuç.OptionsColumn.AllowEdit = false;
            this.gridColumn_Sonuç.OptionsColumn.ReadOnly = true;
            this.gridColumn_Sonuç.Visible = true;
            this.gridColumn_Sonuç.VisibleIndex = 4;
            this.gridColumn_Sonuç.Width = 213;
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.Location = new System.Drawing.Point(12, 109);
            this.gridControl1.MainView = this.gridView_topluForm;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(754, 472);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_topluForm});
            // 
            // gridView_topluForm
            // 
            this.gridView_topluForm.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.gridView_topluForm.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.gridView_topluForm.Appearance.Empty.Options.UseBackColor = true;
            this.gridView_topluForm.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_topluForm.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView_topluForm.ColumnPanelRowHeight = 40;
            this.gridView_topluForm.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn_Kaynak,
            this.gridColumn_Kapanış,
            this.gridColumn_Servis,
            this.gridColumn_Sonuç});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.gridColumn_Sonuç;
            gridFormatRule2.Name = "FormatBaşarılı";
            formatConditionRuleContains2.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleContains2.Appearance.Options.UseForeColor = true;
            formatConditionRuleContains2.PredefinedName = "Green Fill";
            formatConditionRuleContains2.Values = ((System.Collections.IList)(resources.GetObject("formatConditionRuleContains2.Values")));
            gridFormatRule2.Rule = formatConditionRuleContains2;
            gridFormatRule2.StopIfTrue = true;
            this.gridView_topluForm.FormatRules.Add(gridFormatRule2);
            this.gridView_topluForm.GridControl = this.gridControl1;
            this.gridView_topluForm.Name = "gridView_topluForm";
            this.gridView_topluForm.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "NO";
            this.gridColumn1.FieldName = "sayı";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 27;
            // 
            // gridColumn_Kaynak
            // 
            this.gridColumn_Kaynak.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Kaynak.AppearanceCell.Options.UseFont = true;
            this.gridColumn_Kaynak.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Kaynak.AppearanceHeader.Options.UseFont = true;
            this.gridColumn_Kaynak.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Kaynak.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_Kaynak.Caption = "Kaynak Dosya";
            this.gridColumn_Kaynak.FieldName = "yol";
            this.gridColumn_Kaynak.Name = "gridColumn_Kaynak";
            this.gridColumn_Kaynak.OptionsColumn.AllowEdit = false;
            this.gridColumn_Kaynak.OptionsColumn.ReadOnly = true;
            this.gridColumn_Kaynak.Visible = true;
            this.gridColumn_Kaynak.VisibleIndex = 1;
            this.gridColumn_Kaynak.Width = 393;
            // 
            // gridColumn_Kapanış
            // 
            this.gridColumn_Kapanış.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Kapanış.AppearanceCell.Options.UseFont = true;
            this.gridColumn_Kapanış.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_Kapanış.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Kapanış.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Kapanış.AppearanceHeader.Options.UseFont = true;
            this.gridColumn_Kapanış.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Kapanış.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Kapanış.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_Kapanış.Caption = "Kapanış Formu";
            this.gridColumn_Kapanış.FieldName = "ad_kapa";
            this.gridColumn_Kapanış.Name = "gridColumn_Kapanış";
            this.gridColumn_Kapanış.Visible = true;
            this.gridColumn_Kapanış.VisibleIndex = 3;
            this.gridColumn_Kapanış.Width = 52;
            // 
            // gridColumn_Servis
            // 
            this.gridColumn_Servis.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Servis.AppearanceCell.Options.UseFont = true;
            this.gridColumn_Servis.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_Servis.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Servis.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn_Servis.AppearanceHeader.Options.UseFont = true;
            this.gridColumn_Servis.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Servis.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Servis.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn_Servis.Caption = "Açılış Formu";
            this.gridColumn_Servis.FieldName = "ad";
            this.gridColumn_Servis.Name = "gridColumn_Servis";
            this.gridColumn_Servis.Visible = true;
            this.gridColumn_Servis.VisibleIndex = 2;
            this.gridColumn_Servis.Width = 51;
            // 
            // btn_gözat
            // 
            this.btn_gözat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_gözat.ImageOptions.Image")));
            this.btn_gözat.Location = new System.Drawing.Point(16, 32);
            this.btn_gözat.Name = "btn_gözat";
            this.btn_gözat.Size = new System.Drawing.Size(75, 24);
            this.btn_gözat.TabIndex = 1;
            this.btn_gözat.Text = "GÖZAT";
            this.btn_gözat.Click += new System.EventHandler(this.btn_gözat_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_kaydet.Appearance.Options.UseFont = true;
            this.btn_kaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_kaydet.ImageOptions.Image")));
            this.btn_kaydet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_kaydet.Location = new System.Drawing.Point(662, 20);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(101, 68);
            this.btn_kaydet.TabIndex = 3;
            this.btn_kaydet.Text = "KAYDET";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // btn_tara
            // 
            this.btn_tara.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_tara.ImageOptions.Image")));
            this.btn_tara.Location = new System.Drawing.Point(144, 32);
            this.btn_tara.Name = "btn_tara";
            this.btn_tara.Size = new System.Drawing.Size(75, 24);
            this.btn_tara.TabIndex = 5;
            this.btn_tara.Text = "Tara";
            this.btn_tara.Click += new System.EventHandler(this.btn_tara_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(89, 34);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(29, 20);
            this.textEdit1.TabIndex = 8;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btn_tara);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(175, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(244, 76);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Otomatik Tara";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Sayfa Sayısı:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btn_gözat);
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl2.Location = new System.Drawing.Point(12, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(111, 76);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Manuel Seç";
            // 
            // frm_ts_sformyükle_toplu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 596);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_ts_sformyükle_toplu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FORM YÜKLE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ts_sformyükle_toplu_FormClosing);
            this.Load += new System.EventHandler(this.frm_ts_sformyükle_toplu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_topluForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_topluForm;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Kaynak;
        private DevExpress.XtraEditors.SimpleButton btn_gözat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Servis;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Sonuç;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Kapanış;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btn_tara;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}