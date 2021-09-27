
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
            this.gridControlRandevuEkrani = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewRandevuEkrani = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.timerSanye = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRandevuEkrani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRandevuEkrani)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlRandevuEkrani
            // 
            this.gridControlRandevuEkrani.DataSource = this.bindingSource1;
            this.gridControlRandevuEkrani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRandevuEkrani.Location = new System.Drawing.Point(0, 0);
            this.gridControlRandevuEkrani.MainView = this.gridViewRandevuEkrani;
            this.gridControlRandevuEkrani.Name = "gridControlRandevuEkrani";
            this.gridControlRandevuEkrani.Size = new System.Drawing.Size(1177, 659);
            this.gridControlRandevuEkrani.TabIndex = 0;
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
            this.gridViewRandevuEkrani.RowHeight = 110;
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
            this.gridColumn3.Caption = "MUSTERİ AD SOYAD";
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
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(907, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // timerSanye
            // 
            this.timerSanye.Enabled = true;
            this.timerSanye.Interval = 1000;
            this.timerSanye.Tick += new System.EventHandler(this.timerSanye_Tick);
            // 
            // frm_ts_randevuEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 659);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControlRandevuEkrani);
            this.Name = "frm_ts_randevuEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RANDEVU EKRANI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ts_randevuEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRandevuEkrani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRandevuEkrani)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlRandevuEkrani;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRandevuEkrani;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Timer timerSanye;
    }
}