namespace ASPProject.SkillMap
{
    partial class frmLoadDataHorizontal
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
            this.gridControlHorizontal = new DevExpress.XtraGrid.GridControl();
            this.gridViewHorizontal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExportExcelHorizontal = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontal)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlHorizontal
            // 
            this.gridControlHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlHorizontal.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlHorizontal.Location = new System.Drawing.Point(0, 0);
            this.gridControlHorizontal.MainView = this.gridViewHorizontal;
            this.gridControlHorizontal.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlHorizontal.Name = "gridControlHorizontal";
            this.gridControlHorizontal.Size = new System.Drawing.Size(1745, 817);
            this.gridControlHorizontal.TabIndex = 0;
            this.gridControlHorizontal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHorizontal});
            // 
            // gridViewHorizontal
            // 
            this.gridViewHorizontal.DetailHeight = 431;
            this.gridViewHorizontal.GridControl = this.gridControlHorizontal;
            this.gridViewHorizontal.Name = "gridViewHorizontal";
            this.gridViewHorizontal.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewHorizontal_RowCellStyle);
            // 
            // btnExportExcelHorizontal
            // 
            this.btnExportExcelHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcelHorizontal.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnExportExcelHorizontal.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcelHorizontal.Appearance.Options.UseBackColor = true;
            this.btnExportExcelHorizontal.Appearance.Options.UseFont = true;
            this.btnExportExcelHorizontal.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btnExportExcelHorizontal.Location = new System.Drawing.Point(548, 825);
            this.btnExportExcelHorizontal.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportExcelHorizontal.Name = "btnExportExcelHorizontal";
            this.btnExportExcelHorizontal.Size = new System.Drawing.Size(625, 54);
            this.btnExportExcelHorizontal.TabIndex = 6;
            this.btnExportExcelHorizontal.Text = "Export Excel";
            this.btnExportExcelHorizontal.Click += new System.EventHandler(this.btnExportExcelHorizontal_Click);
            // 
            // frmLoadDataHorizontal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 887);
            this.Controls.Add(this.btnExportExcelHorizontal);
            this.Controls.Add(this.gridControlHorizontal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoadDataHorizontal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadDataHorizontal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlHorizontal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHorizontal;
        private DevExpress.XtraEditors.SimpleButton btnExportExcelHorizontal;
    }
}