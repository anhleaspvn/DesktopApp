namespace ASPProject.LineProdStatistic
{
    partial class frmLineDefectTable
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
            this.gridLineDefect = new DevExpress.XtraGrid.GridControl();
            this.gridLineDefectView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdStatisticQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DefectQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYieldPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineDefectView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLineDefect
            // 
            this.gridLineDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLineDefect.Location = new System.Drawing.Point(0, 0);
            this.gridLineDefect.MainView = this.gridLineDefectView;
            this.gridLineDefect.Name = "gridLineDefect";
            this.gridLineDefect.Size = new System.Drawing.Size(1120, 661);
            this.gridLineDefect.TabIndex = 4;
            this.gridLineDefect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridLineDefectView});
            // 
            // gridLineDefectView
            // 
            this.gridLineDefectView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWODocNo,
            this.colProdStatisticQuantity,
            this.colDefectID,
            this.colDefectName,
            this.DefectQuantity,
            this.colYieldPercent});
            this.gridLineDefectView.GridControl = this.gridLineDefect;
            this.gridLineDefectView.Name = "gridLineDefectView";
            this.gridLineDefectView.OptionsBehavior.ReadOnly = true;
            this.gridLineDefectView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridLineDefectView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridLineDefectView.OptionsView.ShowAutoFilterRow = true;
            this.gridLineDefectView.OptionsView.ShowFooter = true;
            this.gridLineDefectView.OptionsView.ShowGroupPanel = false;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 0;
            this.colWODocNo.Width = 94;
            // 
            // colProdStatisticQuantity
            // 
            this.colProdStatisticQuantity.Caption = "Số lượng đạt";
            this.colProdStatisticQuantity.FieldName = "ProdStatisticQuantity";
            this.colProdStatisticQuantity.MinWidth = 25;
            this.colProdStatisticQuantity.Name = "colProdStatisticQuantity";
            this.colProdStatisticQuantity.Visible = true;
            this.colProdStatisticQuantity.VisibleIndex = 1;
            this.colProdStatisticQuantity.Width = 94;
            // 
            // colDefectID
            // 
            this.colDefectID.Caption = "Mã DF";
            this.colDefectID.FieldName = "DefectID";
            this.colDefectID.MinWidth = 25;
            this.colDefectID.Name = "colDefectID";
            this.colDefectID.Visible = true;
            this.colDefectID.VisibleIndex = 2;
            this.colDefectID.Width = 94;
            // 
            // colDefectName
            // 
            this.colDefectName.Caption = "Tên DF";
            this.colDefectName.FieldName = "DefectName";
            this.colDefectName.MinWidth = 25;
            this.colDefectName.Name = "colDefectName";
            this.colDefectName.Visible = true;
            this.colDefectName.VisibleIndex = 3;
            this.colDefectName.Width = 94;
            // 
            // DefectQuantity
            // 
            this.DefectQuantity.Caption = "Số lượng DF";
            this.DefectQuantity.FieldName = "DefectQuantity";
            this.DefectQuantity.MinWidth = 25;
            this.DefectQuantity.Name = "DefectQuantity";
            this.DefectQuantity.Visible = true;
            this.DefectQuantity.VisibleIndex = 4;
            this.DefectQuantity.Width = 94;
            // 
            // colYieldPercent
            // 
            this.colYieldPercent.Caption = "% Yield";
            this.colYieldPercent.FieldName = "YieldPercent";
            this.colYieldPercent.MinWidth = 25;
            this.colYieldPercent.Name = "colYieldPercent";
            this.colYieldPercent.Visible = true;
            this.colYieldPercent.VisibleIndex = 5;
            this.colYieldPercent.Width = 94;
            // 
            // frmLineDefectTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 661);
            this.Controls.Add(this.gridLineDefect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmLineDefectTable";
            this.Text = "frmLineDefectTable";
            ((System.ComponentModel.ISupportInitialize)(this.gridLineDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineDefectView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridLineDefect;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLineDefectView;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProdStatisticQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectID;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectName;
        private DevExpress.XtraGrid.Columns.GridColumn DefectQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colYieldPercent;
    }
}