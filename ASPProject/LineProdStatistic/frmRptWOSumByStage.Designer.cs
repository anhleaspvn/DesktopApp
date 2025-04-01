namespace ASPProject.LineProdStatistic
{
    partial class frmRptWOSumByStage
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
            this.gridAuditInput = new DevExpress.XtraGrid.GridControl();
            this.gridAuditInputView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityBOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInputView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAuditInput
            // 
            this.gridAuditInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuditInput.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.gridAuditInput.Location = new System.Drawing.Point(0, 0);
            this.gridAuditInput.MainView = this.gridAuditInputView;
            this.gridAuditInput.Margin = new System.Windows.Forms.Padding(8);
            this.gridAuditInput.Name = "gridAuditInput";
            this.gridAuditInput.Size = new System.Drawing.Size(1361, 721);
            this.gridAuditInput.TabIndex = 4;
            this.gridAuditInput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAuditInputView});
            // 
            // gridAuditInputView
            // 
            this.gridAuditInputView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWODocNo,
            this.colMaterialID,
            this.colMaterialName,
            this.colQuantity,
            this.colQuantityBOM,
            this.colUnit});
            this.gridAuditInputView.DetailHeight = 852;
            this.gridAuditInputView.GridControl = this.gridAuditInput;
            this.gridAuditInputView.Name = "gridAuditInputView";
            this.gridAuditInputView.OptionsBehavior.ReadOnly = true;
            this.gridAuditInputView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridAuditInputView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridAuditInputView.OptionsView.ColumnAutoWidth = false;
            this.gridAuditInputView.OptionsView.ShowAutoFilterRow = true;
            this.gridAuditInputView.OptionsView.ShowFooter = true;
            this.gridAuditInputView.OptionsView.ShowGroupPanel = false;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lếnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.OptionsColumn.FixedWidth = true;
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 0;
            this.colWODocNo.Width = 120;
            // 
            // colMaterialID
            // 
            this.colMaterialID.Caption = "Mã NVL";
            this.colMaterialID.FieldName = "MaterialID";
            this.colMaterialID.MinWidth = 25;
            this.colMaterialID.Name = "colMaterialID";
            this.colMaterialID.OptionsColumn.FixedWidth = true;
            this.colMaterialID.Visible = true;
            this.colMaterialID.VisibleIndex = 1;
            this.colMaterialID.Width = 120;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "Tên NVL";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.MinWidth = 25;
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.OptionsColumn.FixedWidth = true;
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 2;
            this.colMaterialName.Width = 300;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Số lượng khai báo";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 25;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.FixedWidth = true;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            this.colQuantity.Width = 94;
            // 
            // colQuantityBOM
            // 
            this.colQuantityBOM.Caption = "Số lượng";
            this.colQuantityBOM.FieldName = "QuantityBOM";
            this.colQuantityBOM.MinWidth = 25;
            this.colQuantityBOM.Name = "colQuantityBOM";
            this.colQuantityBOM.OptionsColumn.FixedWidth = true;
            this.colQuantityBOM.Visible = true;
            this.colQuantityBOM.VisibleIndex = 4;
            this.colQuantityBOM.Width = 94;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Đơn vị tính";
            this.colUnit.FieldName = "Unit";
            this.colUnit.MinWidth = 25;
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.FixedWidth = true;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 5;
            this.colUnit.Width = 94;
            // 
            // frmRptWOSumByStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 721);
            this.Controls.Add(this.gridAuditInput);
            this.Name = "frmRptWOSumByStage";
            this.Text = "frmRptWOSumByStage";
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInputView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridAuditInput;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAuditInputView;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityBOM;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
    }
}