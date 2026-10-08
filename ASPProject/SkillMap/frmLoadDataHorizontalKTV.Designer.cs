namespace ASPProject.SkillMap
{
    partial class frmLoadDataHorizontalKTV
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
            this.gridControlHorizontalKTV = new DevExpress.XtraGrid.GridControl();
            this.gridViewHorizontalKTV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontalKTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontalKTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlHorizontalKTV
            // 
            this.gridControlHorizontalKTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlHorizontalKTV.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlHorizontalKTV.Location = new System.Drawing.Point(0, 0);
            this.gridControlHorizontalKTV.MainView = this.gridViewHorizontalKTV;
            this.gridControlHorizontalKTV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlHorizontalKTV.Name = "gridControlHorizontalKTV";
            this.gridControlHorizontalKTV.Size = new System.Drawing.Size(1735, 850);
            this.gridControlHorizontalKTV.TabIndex = 0;
            this.gridControlHorizontalKTV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHorizontalKTV});
            // 
            // gridViewHorizontalKTV
            // 
            this.gridViewHorizontalKTV.DetailHeight = 431;
            this.gridViewHorizontalKTV.GridControl = this.gridControlHorizontalKTV;
            this.gridViewHorizontalKTV.Name = "gridViewHorizontalKTV";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExportExcel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 776);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1735, 74);
            this.panelControl1.TabIndex = 1;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Appearance.Options.UseBackColor = true;
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btnExportExcel.Location = new System.Drawing.Point(1304, 16);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(418, 42);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "Export Excel";
            // 
            // frmLoadDataHorizontalKTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 850);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControlHorizontalKTV);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmLoadDataHorizontalKTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadDataHorizontalKTV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontalKTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontalKTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlHorizontalKTV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHorizontalKTV;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
    }
}