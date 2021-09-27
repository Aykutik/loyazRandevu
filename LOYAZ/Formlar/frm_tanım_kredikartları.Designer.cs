namespace LOYAZ.Formlar
{
    partial class frm_tanım_kredikartları
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl_kredikartları = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.btn_yeni = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.repositoryItemTextEdit_sonüç = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit_bankalar = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grp_ekleVEdüzenle = new DevExpress.XtraEditors.GroupControl();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lk_kredikartları_bankalar = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_sonüç = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_kredikartları)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_sonüç)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_bankalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_ekleVEdüzenle)).BeginInit();
            this.grp_ekleVEdüzenle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_kredikartları_bankalar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sonüç.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_kredikartları
            // 
            this.gridControl_kredikartları.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_kredikartları.Location = new System.Drawing.Point(0, 144);
            this.gridControl_kredikartları.MainView = this.gridView;
            this.gridControl_kredikartları.MenuManager = this.ribbonControl;
            this.gridControl_kredikartları.Name = "gridControl_kredikartları";
            this.gridControl_kredikartları.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit_sonüç,
            this.repositoryItemTextEdit_bankalar});
            this.gridControl_kredikartları.Size = new System.Drawing.Size(784, 471);
            this.gridControl_kredikartları.TabIndex = 2;
            this.gridControl_kredikartları.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2});
            this.gridView.GridControl = this.gridControl_kredikartları;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kredi Kartı Adı";
            this.gridColumn1.FieldName = "ad";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Son Üç Rakamı";
            this.gridColumn3.FieldName = "sonüc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Banka Adı";
            this.gridColumn2.FieldName = "banka";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.btn_yeni,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(784, 144);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // btn_yeni
            // 
            this.btn_yeni.Caption = "Ekle";
            this.btn_yeni.Id = 16;
            this.btn_yeni.ImageOptions.ImageUri.Uri = "New";
            this.btn_yeni.Name = "btn_yeni";
            this.btn_yeni.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_yeni_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Düzenle";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Kaldır";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Yenile";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_yeni);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tasks";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 583);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(784, 32);
            // 
            // repositoryItemTextEdit_sonüç
            // 
            this.repositoryItemTextEdit_sonüç.AutoHeight = false;
            this.repositoryItemTextEdit_sonüç.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.repositoryItemTextEdit_sonüç.Mask.EditMask = "**** **** **** *";
            this.repositoryItemTextEdit_sonüç.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit_sonüç.Name = "repositoryItemTextEdit_sonüç";
            // 
            // repositoryItemTextEdit_bankalar
            // 
            this.repositoryItemTextEdit_bankalar.AutoHeight = false;
            this.repositoryItemTextEdit_bankalar.Name = "repositoryItemTextEdit_bankalar";
            // 
            // grp_ekleVEdüzenle
            // 
            this.grp_ekleVEdüzenle.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grp_ekleVEdüzenle.Controls.Add(this.btn_kaydet);
            this.grp_ekleVEdüzenle.Controls.Add(this.lk_kredikartları_bankalar);
            this.grp_ekleVEdüzenle.Controls.Add(this.labelControl3);
            this.grp_ekleVEdüzenle.Controls.Add(this.labelControl2);
            this.grp_ekleVEdüzenle.Controls.Add(this.txt_sonüç);
            this.grp_ekleVEdüzenle.Controls.Add(this.labelControl1);
            this.grp_ekleVEdüzenle.Controls.Add(this.txt_ad);
            this.grp_ekleVEdüzenle.Location = new System.Drawing.Point(0, 489);
            this.grp_ekleVEdüzenle.Name = "grp_ekleVEdüzenle";
            this.grp_ekleVEdüzenle.Size = new System.Drawing.Size(784, 96);
            this.grp_ekleVEdüzenle.TabIndex = 4;
            this.grp_ekleVEdüzenle.Text = "groupControl1";
            this.grp_ekleVEdüzenle.Visible = false;
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Location = new System.Drawing.Point(664, 27);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(75, 39);
            this.btn_kaydet.TabIndex = 3;
            this.btn_kaydet.Text = "Kaydet";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // lk_kredikartları_bankalar
            // 
            this.lk_kredikartları_bankalar.Location = new System.Drawing.Point(379, 46);
            this.lk_kredikartları_bankalar.MenuManager = this.ribbonControl;
            this.lk_kredikartları_bankalar.Name = "lk_kredikartları_bankalar";
            this.lk_kredikartları_bankalar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_kredikartları_bankalar.Properties.NullText = "";
            this.lk_kredikartları_bankalar.Size = new System.Drawing.Size(216, 20);
            this.lk_kredikartları_bankalar.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(470, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Banka";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(246, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Son üç Rakamı";
            // 
            // txt_sonüç
            // 
            this.txt_sonüç.Location = new System.Drawing.Point(223, 46);
            this.txt_sonüç.Name = "txt_sonüç";
            this.txt_sonüç.Properties.Mask.EditMask = "**** **** **** *999";
            this.txt_sonüç.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txt_sonüç.Size = new System.Drawing.Size(113, 20);
            this.txt_sonüç.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(68, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Kredi Kartı Tanımı";
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(59, 46);
            this.txt_ad.MenuManager = this.ribbonControl;
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(100, 20);
            this.txt_ad.TabIndex = 0;
            // 
            // frm_tanım_kredikartları
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 615);
            this.Controls.Add(this.grp_ekleVEdüzenle);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl_kredikartları);
            this.Controls.Add(this.ribbonControl);
            this.Name = "frm_tanım_kredikartları";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_kredikartları)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_sonüç)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit_bankalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_ekleVEdüzenle)).EndInit();
            this.grp_ekleVEdüzenle.ResumeLayout(false);
            this.grp_ekleVEdüzenle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_kredikartları_bankalar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sonüç.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_kredikartları;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem btn_yeni;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit_sonüç;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit_bankalar;
        private DevExpress.XtraEditors.GroupControl grp_ekleVEdüzenle;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private DevExpress.XtraEditors.LookUpEdit lk_kredikartları_bankalar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_sonüç;
    }
}