namespace ASPProject.LineProdStatistic
{
    partial class frmLineProductivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLineProductivity));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btDefectTable = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.gridLinePro = new DevExpress.XtraGrid.GridControl();
            this.gridLineProView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatisticDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdWorkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostBomTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYieldProductivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYieldPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBold = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLinePro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineProView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.btDefectTable);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtFromDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.btExport);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtToDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridLinePro);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1205, 593);
            this.splitContainerControl1.SplitterPosition = 58;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // btDefectTable
            // 
            this.btDefectTable.ImageOptions.Image = global::ASPProject.Properties.Resources.close4;
            this.btDefectTable.Location = new System.Drawing.Point(1004, 8);
            this.btDefectTable.Name = "btDefectTable";
            this.btDefectTable.Size = new System.Drawing.Size(131, 29);
            this.btDefectTable.TabIndex = 22;
            this.btDefectTable.Text = "Bảng Defect";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(128, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(180, 23);
            this.dtFromDate.TabIndex = 20;
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(835, 8);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(143, 29);
            this.btExport.TabIndex = 19;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(339, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(434, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(193, 23);
            this.dtToDate.TabIndex = 17;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(692, 8);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(118, 29);
            this.btFilter.TabIndex = 16;
            this.btFilter.Text = "Lọc";
            // 
            // gridLinePro
            // 
            this.gridLinePro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLinePro.Location = new System.Drawing.Point(0, 0);
            this.gridLinePro.MainView = this.gridLineProView;
            this.gridLinePro.Name = "gridLinePro";
            this.gridLinePro.Size = new System.Drawing.Size(1205, 528);
            this.gridLinePro.TabIndex = 3;
            this.gridLinePro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridLineProView});
            // 
            // gridLineProView
            // 
            this.gridLineProView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatisticDate,
            this.colProductType,
            this.colLineID,
            this.colProdWorkTime,
            this.colCostBomTime,
            this.colProductivity,
            this.colYieldProductivity,
            this.colDefectQuantity,
            this.colYieldPercent,
            this.colBold});
            this.gridLineProView.GridControl = this.gridLinePro;
            this.gridLineProView.Name = "gridLineProView";
            this.gridLineProView.OptionsBehavior.Editable = false;
            this.gridLineProView.OptionsBehavior.ReadOnly = true;
            this.gridLineProView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridLineProView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridLineProView.OptionsView.ShowAutoFilterRow = true;
            this.gridLineProView.OptionsView.ShowFooter = true;
            this.gridLineProView.OptionsView.ShowGroupPanel = false;
            // 
            // colStatisticDate
            // 
            this.colStatisticDate.Caption = "Ngày";
            this.colStatisticDate.FieldName = "StatisticDate";
            this.colStatisticDate.MinWidth = 25;
            this.colStatisticDate.Name = "colStatisticDate";
            this.colStatisticDate.Visible = true;
            this.colStatisticDate.VisibleIndex = 0;
            this.colStatisticDate.Width = 94;
            // 
            // colProductType
            // 
            this.colProductType.Caption = "Loại sản phẩm ";
            this.colProductType.FieldName = "ProductType";
            this.colProductType.MinWidth = 25;
            this.colProductType.Name = "colProductType";
            this.colProductType.Visible = true;
            this.colProductType.VisibleIndex = 1;
            this.colProductType.Width = 94;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 25;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 2;
            this.colLineID.Width = 94;
            // 
            // colProdWorkTime
            // 
            this.colProdWorkTime.Caption = "Thời gian sản xuất";
            this.colProdWorkTime.FieldName = "ProdWorkTime";
            this.colProdWorkTime.MinWidth = 25;
            this.colProdWorkTime.Name = "colProdWorkTime";
            this.colProdWorkTime.Visible = true;
            this.colProdWorkTime.VisibleIndex = 3;
            this.colProdWorkTime.Width = 94;
            // 
            // colCostBomTime
            // 
            this.colCostBomTime.Caption = "Thời gian Cost Bom";
            this.colCostBomTime.FieldName = "CostBomTime";
            this.colCostBomTime.MinWidth = 25;
            this.colCostBomTime.Name = "colCostBomTime";
            this.colCostBomTime.Visible = true;
            this.colCostBomTime.VisibleIndex = 4;
            this.colCostBomTime.Width = 94;
            // 
            // colProductivity
            // 
            this.colProductivity.Caption = "Năng suất";
            this.colProductivity.FieldName = "Productivity";
            this.colProductivity.MinWidth = 25;
            this.colProductivity.Name = "colProductivity";
            this.colProductivity.Visible = true;
            this.colProductivity.VisibleIndex = 5;
            this.colProductivity.Width = 94;
            // 
            // colYieldProductivity
            // 
            this.colYieldProductivity.Caption = "Năng suất tích luỹ";
            this.colYieldProductivity.FieldName = "YieldProductivity";
            this.colYieldProductivity.MinWidth = 25;
            this.colYieldProductivity.Name = "colYieldProductivity";
            this.colYieldProductivity.Visible = true;
            this.colYieldProductivity.VisibleIndex = 6;
            this.colYieldProductivity.Width = 94;
            // 
            // colDefectQuantity
            // 
            this.colDefectQuantity.Caption = "SL Defect";
            this.colDefectQuantity.FieldName = "DefectQuantity";
            this.colDefectQuantity.MinWidth = 25;
            this.colDefectQuantity.Name = "colDefectQuantity";
            this.colDefectQuantity.Visible = true;
            this.colDefectQuantity.VisibleIndex = 7;
            this.colDefectQuantity.Width = 94;
            // 
            // colYieldPercent
            // 
            this.colYieldPercent.Caption = "Yield";
            this.colYieldPercent.FieldName = "YieldPercent";
            this.colYieldPercent.MinWidth = 25;
            this.colYieldPercent.Name = "colYieldPercent";
            this.colYieldPercent.Visible = true;
            this.colYieldPercent.VisibleIndex = 8;
            this.colYieldPercent.Width = 94;
            // 
            // colBold
            // 
            this.colBold.Caption = "Bold";
            this.colBold.FieldName = "Bold";
            this.colBold.MinWidth = 25;
            this.colBold.Name = "colBold";
            this.colBold.Width = 94;
            // 
            // frmLineProductivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 593);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLineProductivity";
            this.Text = "frmLineProductivity";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLinePro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLineProView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraGrid.GridControl gridLinePro;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLineProView;
        private DevExpress.XtraGrid.Columns.GridColumn colStatisticDate;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colProdWorkTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCostBomTime;
        private DevExpress.XtraGrid.Columns.GridColumn colProductivity;
        private DevExpress.XtraGrid.Columns.GridColumn colYieldProductivity;
        private DevExpress.XtraGrid.Columns.GridColumn colBold;
        private DevExpress.XtraEditors.SimpleButton btDefectTable;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colYieldPercent;
    }
}