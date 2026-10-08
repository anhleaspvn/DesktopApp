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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontalKTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontalKTV)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlHorizontalKTV
            // 
            this.gridControlHorizontalKTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlHorizontalKTV.Location = new System.Drawing.Point(0, 0);
            this.gridControlHorizontalKTV.MainView = this.gridViewHorizontalKTV;
            this.gridControlHorizontalKTV.Name = "gridControlHorizontalKTV";
            this.gridControlHorizontalKTV.Size = new System.Drawing.Size(1487, 691);
            this.gridControlHorizontalKTV.TabIndex = 0;
            this.gridControlHorizontalKTV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHorizontalKTV});
            // 
            // gridViewHorizontalKTV
            // 
            this.gridViewHorizontalKTV.GridControl = this.gridControlHorizontalKTV;
            this.gridViewHorizontalKTV.Name = "gridViewHorizontalKTV";
            // 
            // frmLoadDataHorizontalKTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 691);
            this.Controls.Add(this.gridControlHorizontalKTV);
            this.Name = "frmLoadDataHorizontalKTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadDataHorizontalKTV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontalKTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontalKTV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlHorizontalKTV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHorizontalKTV;
    }
}