namespace LOYAZ
{
    partial class frm_giriş
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
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::LOYAZ.Formlar.WaitForm2), true, true);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_giriş = new DevExpress.XtraEditors.SimpleButton();
            this.txt_parola = new DevExpress.XtraEditors.TextEdit();
            this.txt_kul_girişi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.chck_benihatırla = new DevExpress.XtraEditors.CheckEdit();
            this.btn_kapat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_bağlantıayarları = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pinc = new DevExpress.XtraEditors.LabelControl();
            this.lbl_versiyon = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_parola.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kul_girişi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chck_benihatırla.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.Transparent;
            this.layoutControl1.Controls.Add(this.btn_giriş);
            this.layoutControl1.Controls.Add(this.txt_parola);
            this.layoutControl1.Controls.Add(this.txt_kul_girişi);
            this.layoutControl1.Location = new System.Drawing.Point(12, 80);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(500, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(220, 130);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_giriş
            // 
            this.btn_giriş.Location = new System.Drawing.Point(12, 82);
            this.btn_giriş.Name = "btn_giriş";
            this.btn_giriş.Size = new System.Drawing.Size(196, 22);
            this.btn_giriş.StyleController = this.layoutControl1;
            this.btn_giriş.TabIndex = 6;
            this.btn_giriş.Text = "GİRİŞ";
            this.btn_giriş.Click += new System.EventHandler(this.btn_giriş_Click);
            // 
            // txt_parola
            // 
            this.txt_parola.Location = new System.Drawing.Point(55, 47);
            this.txt_parola.Name = "txt_parola";
            this.txt_parola.Properties.PasswordChar = '*';
            this.txt_parola.Size = new System.Drawing.Size(153, 20);
            this.txt_parola.StyleController = this.layoutControl1;
            this.txt_parola.TabIndex = 5;
            this.txt_parola.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_parola_KeyUp);
            // 
            // txt_kul_girişi
            // 
            this.txt_kul_girişi.Location = new System.Drawing.Point(55, 12);
            this.txt_kul_girişi.Name = "txt_kul_girişi";
            this.txt_kul_girişi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_kul_girişi.Size = new System.Drawing.Size(153, 20);
            this.txt_kul_girişi.StyleController = this.layoutControl1;
            this.txt_kul_girişi.TabIndex = 4;
            this.txt_kul_girişi.SelectedValueChanged += new System.EventHandler(this.txt_kul_girişi_SelectedValueChanged);
            this.txt_kul_girişi.BeforePopup += new System.EventHandler(this.txt_kul_girişi_BeforePopup);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(220, 130);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_kul_girişi;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem1.Text = "E Posta";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(40, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(200, 14);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_parola;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem2.Text = "PAROLA";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(40, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_giriş;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 70);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(200, 26);
            this.layoutControlItem3.Text = "GİRİŞ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(200, 11);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 59);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(200, 11);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // chck_benihatırla
            // 
            this.chck_benihatırla.EditValue = null;
            this.chck_benihatırla.Location = new System.Drawing.Point(24, 216);
            this.chck_benihatırla.Name = "chck_benihatırla";
            this.chck_benihatırla.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chck_benihatırla.Properties.Caption = "Beni Hatırla";
            this.chck_benihatırla.Size = new System.Drawing.Size(100, 19);
            this.chck_benihatırla.TabIndex = 2;
            this.chck_benihatırla.CheckedChanged += new System.EventHandler(this.chck_benihatırla_CheckedChanged);
            // 
            // btn_kapat
            // 
            this.btn_kapat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.btn_kapat.Appearance.Options.UseFont = true;
            this.btn_kapat.Appearance.Options.UseTextOptions = true;
            this.btn_kapat.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_kapat.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btn_kapat.Location = new System.Drawing.Point(511, 9);
            this.btn_kapat.Margin = new System.Windows.Forms.Padding(0);
            this.btn_kapat.Name = "btn_kapat";
            this.btn_kapat.Size = new System.Drawing.Size(19, 17);
            this.btn_kapat.TabIndex = 3;
            this.btn_kapat.Text = "X";
            this.btn_kapat.Click += new System.EventHandler(this.btn_kapat_Click);
            // 
            // btn_bağlantıayarları
            // 
            this.btn_bağlantıayarları.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.btn_bağlantıayarları.Appearance.Options.UseFont = true;
            this.btn_bağlantıayarları.Location = new System.Drawing.Point(22, 276);
            this.btn_bağlantıayarları.LookAndFeel.SkinName = "Office 2019 White";
            this.btn_bağlantıayarları.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btn_bağlantıayarları.LookAndFeel.UseWindowsXPTheme = true;
            this.btn_bağlantıayarları.Name = "btn_bağlantıayarları";
            this.btn_bağlantıayarları.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_bağlantıayarları.Size = new System.Drawing.Size(70, 23);
            this.btn_bağlantıayarları.TabIndex = 4;
            this.btn_bağlantıayarları.Text = "Bağlantı ayarları";
            this.btn_bağlantıayarları.Click += new System.EventHandler(this.btn_bağlantıayarları_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pinc
            // 
            this.pinc.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.pinc.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pinc.Appearance.Options.UseFont = true;
            this.pinc.Appearance.Options.UseForeColor = true;
            this.pinc.Location = new System.Drawing.Point(22, 20);
            this.pinc.Name = "pinc";
            this.pinc.Size = new System.Drawing.Size(122, 21);
            this.pinc.TabIndex = 5;
            this.pinc.Text = "Demo Sürümü";
            // 
            // lbl_versiyon
            // 
            this.lbl_versiyon.Location = new System.Drawing.Point(24, 305);
            this.lbl_versiyon.Name = "lbl_versiyon";
            this.lbl_versiyon.Size = new System.Drawing.Size(63, 13);
            this.lbl_versiyon.TabIndex = 6;
            this.lbl_versiyon.Text = "labelControl2";
            // 
            // frm_giriş
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 328);
            this.Controls.Add(this.lbl_versiyon);
            this.Controls.Add(this.pinc);
            this.Controls.Add(this.btn_bağlantıayarları);
            this.Controls.Add(this.btn_kapat);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.chck_benihatırla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_giriş";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_giriş";
            this.Load += new System.EventHandler(this.frm_giriş_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_parola.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kul_girişi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chck_benihatırla.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btn_giriş;
        private DevExpress.XtraEditors.TextEdit txt_parola;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.CheckEdit chck_benihatırla;
        private DevExpress.XtraEditors.ComboBoxEdit txt_kul_girişi;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.SimpleButton btn_kapat;
        private DevExpress.XtraEditors.SimpleButton btn_bağlantıayarları;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl pinc;
        private DevExpress.XtraEditors.LabelControl lbl_versiyon;
    }
}