namespace LOYAZ
{
    partial class frm_ts_sformyükle
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
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txt_görselyolu = new DevExpress.XtraEditors.TextEdit();
            this.btn_gözat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_yükle = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_barcode_oku = new System.Windows.Forms.Label();
            this.lbl_gelen_servisid = new System.Windows.Forms.Label();
            this.lbl_direkt = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_görselyolu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(578, 786);
            this.pictureEdit1.TabIndex = 0;
            // 
            // txt_görselyolu
            // 
            this.txt_görselyolu.Location = new System.Drawing.Point(83, 806);
            this.txt_görselyolu.Name = "txt_görselyolu";
            this.txt_görselyolu.Size = new System.Drawing.Size(424, 20);
            this.txt_görselyolu.TabIndex = 1;
            // 
            // btn_gözat
            // 
            this.btn_gözat.Location = new System.Drawing.Point(12, 804);
            this.btn_gözat.Name = "btn_gözat";
            this.btn_gözat.Size = new System.Drawing.Size(65, 23);
            this.btn_gözat.TabIndex = 2;
            this.btn_gözat.Text = "Gözat";
            this.btn_gözat.Click += new System.EventHandler(this.btn_gözat_Click);
            // 
            // btn_yükle
            // 
            this.btn_yükle.Location = new System.Drawing.Point(515, 804);
            this.btn_yükle.Name = "btn_yükle";
            this.btn_yükle.Size = new System.Drawing.Size(75, 23);
            this.btn_yükle.TabIndex = 3;
            this.btn_yükle.Text = "Yükle";
            this.btn_yükle.Click += new System.EventHandler(this.btn_yükle_Click);
            // 
            // lbl_barcode_oku
            // 
            this.lbl_barcode_oku.AutoSize = true;
            this.lbl_barcode_oku.Location = new System.Drawing.Point(13, 833);
            this.lbl_barcode_oku.Name = "lbl_barcode_oku";
            this.lbl_barcode_oku.Size = new System.Drawing.Size(85, 13);
            this.lbl_barcode_oku.TabIndex = 4;
            this.lbl_barcode_oku.Text = "lbl_barcode_oku";
            // 
            // lbl_gelen_servisid
            // 
            this.lbl_gelen_servisid.AutoSize = true;
            this.lbl_gelen_servisid.Location = new System.Drawing.Point(104, 833);
            this.lbl_gelen_servisid.Name = "lbl_gelen_servisid";
            this.lbl_gelen_servisid.Size = new System.Drawing.Size(91, 13);
            this.lbl_gelen_servisid.TabIndex = 4;
            this.lbl_gelen_servisid.Text = "lbl_gelen_servisid";
            // 
            // lbl_direkt
            // 
            this.lbl_direkt.Location = new System.Drawing.Point(202, 833);
            this.lbl_direkt.Name = "lbl_direkt";
            this.lbl_direkt.Size = new System.Drawing.Size(27, 13);
            this.lbl_direkt.TabIndex = 5;
            this.lbl_direkt.Text = "direkt";
            // 
            // frm_ts_sformyükle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 834);
            this.Controls.Add(this.lbl_direkt);
            this.Controls.Add(this.lbl_gelen_servisid);
            this.Controls.Add(this.lbl_barcode_oku);
            this.Controls.Add(this.btn_yükle);
            this.Controls.Add(this.btn_gözat);
            this.Controls.Add(this.txt_görselyolu);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_ts_sformyükle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servis Formu Yükle";
            this.Load += new System.EventHandler(this.frm_ts_sformyükle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_görselyolu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit txt_görselyolu;
        private DevExpress.XtraEditors.SimpleButton btn_gözat;
        private DevExpress.XtraEditors.SimpleButton btn_yükle;
        private System.Windows.Forms.Label lbl_barcode_oku;
        public System.Windows.Forms.Label lbl_gelen_servisid;
        public DevExpress.XtraEditors.LabelControl lbl_direkt;
    }
}