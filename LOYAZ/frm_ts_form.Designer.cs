namespace LOYAZ
{
    partial class panel_ts_anasayfa
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
            this.sidePanel1 = new DevExpress.XtraEditors.SidePanel();
            this.button_servisiskapat = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.button_anasayfa = new DevExpress.XtraEditors.SimpleButton();
            this.button_servisaç = new DevExpress.XtraEditors.SimpleButton();
            this.tsservisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lozyaDataSet1Local = new LOYAZ.lozyaDataSet1Local();
            this.ts_servisTableAdapter = new LOYAZ.lozyaDataSet1LocalTableAdapters.ts_servisTableAdapter();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sidePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsservisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lozyaDataSet1Local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel1
            // 
            this.sidePanel1.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sidePanel1.Appearance.Options.UseBackColor = true;
            this.sidePanel1.Controls.Add(this.simpleButton1);
            this.sidePanel1.Controls.Add(this.button_servisiskapat);
            this.sidePanel1.Controls.Add(this.labelControl1);
            this.sidePanel1.Controls.Add(this.button_anasayfa);
            this.sidePanel1.Controls.Add(this.button_servisaç);
            this.sidePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidePanel1.Location = new System.Drawing.Point(0, 0);
            this.sidePanel1.Name = "sidePanel1";
            this.sidePanel1.Size = new System.Drawing.Size(1148, 55);
            this.sidePanel1.TabIndex = 1;
            this.sidePanel1.Text = "sidePanel1";
            // 
            // button_servisiskapat
            // 
            this.button_servisiskapat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_servisiskapat.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.button_servisiskapat.Appearance.Options.UseFont = true;
            this.button_servisiskapat.Appearance.Options.UseTextOptions = true;
            this.button_servisiskapat.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.button_servisiskapat.Location = new System.Drawing.Point(1081, 12);
            this.button_servisiskapat.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.button_servisiskapat.Name = "button_servisiskapat";
            this.button_servisiskapat.Size = new System.Drawing.Size(56, 33);
            this.button_servisiskapat.TabIndex = 5;
            this.button_servisiskapat.Text = "SERVİSİ GÜNCELLE";
            this.button_servisiskapat.Click += new System.EventHandler(this.button_servisiskapat_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.LineColor = System.Drawing.Color.White;
            this.labelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl1.Location = new System.Drawing.Point(64, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 28);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "SERVİS";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // button_anasayfa
            // 
            this.button_anasayfa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_anasayfa.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.button_anasayfa.Appearance.Options.UseFont = true;
            this.button_anasayfa.Location = new System.Drawing.Point(10, 10);
            this.button_anasayfa.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.button_anasayfa.Name = "button_anasayfa";
            this.button_anasayfa.Size = new System.Drawing.Size(41, 33);
            this.button_anasayfa.TabIndex = 3;
            this.button_anasayfa.Text = "LOZAY";
            this.button_anasayfa.Click += new System.EventHandler(this.button_anasayfa_Click);
            // 
            // button_servisaç
            // 
            this.button_servisaç.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_servisaç.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.button_servisaç.Appearance.Options.UseFont = true;
            this.button_servisaç.Location = new System.Drawing.Point(1017, 12);
            this.button_servisaç.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.button_servisaç.Name = "button_servisaç";
            this.button_servisaç.Size = new System.Drawing.Size(56, 33);
            this.button_servisaç.TabIndex = 2;
            this.button_servisaç.Text = "SERVİS AÇ";
            this.button_servisaç.Click += new System.EventHandler(this.button_servisaç_Click);
            // 
            // tsservisBindingSource
            // 
            this.tsservisBindingSource.DataMember = "ts_servis";
            this.tsservisBindingSource.DataSource = this.lozyaDataSet1Local;
            // 
            // lozyaDataSet1Local
            // 
            this.lozyaDataSet1Local.DataSetName = "lozyaDataSet1Local";
            this.lozyaDataSet1Local.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ts_servisTableAdapter
            // 
            this.ts_servisTableAdapter.ClearBeforeFill = true;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(258, 22);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panel_ts_anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 752);
            this.Controls.Add(this.sidePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "panel_ts_anasayfa";
            this.Text = "frm_teknikservis_anasayfa";
            this.Load += new System.EventHandler(this.panel_ts_anasayfa_Load);
            this.sidePanel1.ResumeLayout(false);
            this.sidePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsservisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lozyaDataSet1Local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SidePanel sidePanel1;
        private DevExpress.XtraEditors.SimpleButton button_servisaç;
        private DevExpress.XtraEditors.SimpleButton button_anasayfa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton button_servisiskapat;
        private lozyaDataSet1Local lozyaDataSet1Local;
        private System.Windows.Forms.BindingSource tsservisBindingSource;
        private lozyaDataSet1LocalTableAdapters.ts_servisTableAdapter ts_servisTableAdapter;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}