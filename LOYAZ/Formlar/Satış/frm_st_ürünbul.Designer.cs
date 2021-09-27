namespace LOYAZ.Formlar.Satış
{
    partial class frm_st_ürünbul
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
            this.gridControl_ürünbul = new DevExpress.XtraGrid.GridControl();
            this.gridView_ürünbul = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ürünbul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ürünbul)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ürünbul
            // 
            this.gridControl_ürünbul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ürünbul.Location = new System.Drawing.Point(0, 0);
            this.gridControl_ürünbul.MainView = this.gridView_ürünbul;
            this.gridControl_ürünbul.Name = "gridControl_ürünbul";
            this.gridControl_ürünbul.Size = new System.Drawing.Size(713, 347);
            this.gridControl_ürünbul.TabIndex = 0;
            this.gridControl_ürünbul.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ürünbul});
            this.gridControl_ürünbul.DoubleClick += new System.EventHandler(this.gridControl_ürünbul_DoubleClick);
            // 
            // gridView_ürünbul
            // 
            this.gridView_ürünbul.GridControl = this.gridControl_ürünbul;
            this.gridView_ürünbul.Name = "gridView_ürünbul";
            this.gridView_ürünbul.OptionsBehavior.Editable = false;
            this.gridView_ürünbul.OptionsBehavior.ReadOnly = true;
            // 
            // frm_st_ürünbul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 347);
            this.Controls.Add(this.gridControl_ürünbul);
            this.Name = "frm_st_ürünbul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÜRÜN BUL";
            this.Load += new System.EventHandler(this.frm_st_ürünbul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ürünbul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ürünbul)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ürünbul;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ürünbul;
    }
}