namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailEmpByStage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPSDetailEmpByStage));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.gridStatSummary = new DevExpress.XtraGrid.GridControl();
            this.gridStatSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatisticDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMixStage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckInDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOutDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumTimeHC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumTimeTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpProductivity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummaryView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(8);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.btExport);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtToDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtFromDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridStatSummary);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1140, 683);
            this.splitContainerControl1.SplitterPosition = 76;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(877, 11);
            this.btExport.Margin = new System.Windows.Forms.Padding(8);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(120, 30);
            this.btExport.TabIndex = 15;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(352, 23);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 23);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(461, 18);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(8);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(166, 23);
            this.dtToDate.TabIndex = 12;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(137, 18);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(8);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(166, 23);
            this.dtFromDate.TabIndex = 11;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(728, 11);
            this.btFilter.Margin = new System.Windows.Forms.Padding(8);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(120, 30);
            this.btFilter.TabIndex = 10;
            this.btFilter.Text = "Lọc";
            // 
            // gridStatSummary
            // 
            this.gridStatSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatSummary.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.gridStatSummary.Location = new System.Drawing.Point(0, 0);
            this.gridStatSummary.MainView = this.gridStatSummaryView;
            this.gridStatSummary.Margin = new System.Windows.Forms.Padding(8);
            this.gridStatSummary.Name = "gridStatSummary";
            this.gridStatSummary.Size = new System.Drawing.Size(1140, 600);
            this.gridStatSummary.TabIndex = 3;
            this.gridStatSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridStatSummaryView});
            // 
            // gridStatSummaryView
            // 
            this.gridStatSummaryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatisticDate,
            this.colEmpID,
            this.colEmpName,
            this.colLineEmpID,
            this.colWODocNo,
            this.colProductID,
            this.colMachineID,
            this.colMachineGroup,
            this.colMaterialID,
            this.colStageID,
            this.colStageName,
            this.colMixStage,
            this.colCheckInDt,
            this.colCheckOutDt,
            this.colQuantity,
            this.colSumTime,
            this.colSumTimeHC,
            this.colSumTimeTC,
            this.colEmpProductivity});
            this.gridStatSummaryView.DetailHeight = 852;
            this.gridStatSummaryView.GridControl = this.gridStatSummary;
            this.gridStatSummaryView.Name = "gridStatSummaryView";
            this.gridStatSummaryView.OptionsBehavior.ReadOnly = true;
            this.gridStatSummaryView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridStatSummaryView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridStatSummaryView.OptionsView.ColumnAutoWidth = false;
            this.gridStatSummaryView.OptionsView.ShowAutoFilterRow = true;
            this.gridStatSummaryView.OptionsView.ShowFooter = true;
            this.gridStatSummaryView.OptionsView.ShowGroupPanel = false;
            // 
            // colStatisticDate
            // 
            this.colStatisticDate.Caption = "Ngày thống kê";
            this.colStatisticDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colStatisticDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStatisticDate.FieldName = "StatisticDate";
            this.colStatisticDate.MinWidth = 25;
            this.colStatisticDate.Name = "colStatisticDate";
            this.colStatisticDate.Visible = true;
            this.colStatisticDate.VisibleIndex = 0;
            this.colStatisticDate.Width = 94;
            // 
            // colEmpID
            // 
            this.colEmpID.Caption = "Mã nhân viên";
            this.colEmpID.FieldName = "EmpID";
            this.colEmpID.MinWidth = 25;
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.Visible = true;
            this.colEmpID.VisibleIndex = 1;
            this.colEmpID.Width = 120;
            // 
            // colEmpName
            // 
            this.colEmpName.Caption = "Tên nhân viên";
            this.colEmpName.FieldName = "EmpName";
            this.colEmpName.MinWidth = 25;
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 2;
            this.colEmpName.Width = 250;
            // 
            // colLineEmpID
            // 
            this.colLineEmpID.Caption = "Mã Line NV";
            this.colLineEmpID.FieldName = "LineEmpID";
            this.colLineEmpID.MinWidth = 25;
            this.colLineEmpID.Name = "colLineEmpID";
            this.colLineEmpID.Visible = true;
            this.colLineEmpID.VisibleIndex = 3;
            this.colLineEmpID.Width = 94;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lếnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 4;
            this.colWODocNo.Width = 120;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 25;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 5;
            this.colProductID.Width = 120;
            // 
            // colMachineID
            // 
            this.colMachineID.Caption = "Mã máy";
            this.colMachineID.FieldName = "MachineID";
            this.colMachineID.MinWidth = 25;
            this.colMachineID.Name = "colMachineID";
            this.colMachineID.Visible = true;
            this.colMachineID.VisibleIndex = 6;
            this.colMachineID.Width = 120;
            // 
            // colMachineGroup
            // 
            this.colMachineGroup.Caption = "Nhóm máy";
            this.colMachineGroup.FieldName = "MachineGroup";
            this.colMachineGroup.MinWidth = 25;
            this.colMachineGroup.Name = "colMachineGroup";
            this.colMachineGroup.Visible = true;
            this.colMachineGroup.VisibleIndex = 7;
            this.colMachineGroup.Width = 94;
            // 
            // colMaterialID
            // 
            this.colMaterialID.Caption = "Mã NVL";
            this.colMaterialID.FieldName = "MaterialID";
            this.colMaterialID.MinWidth = 25;
            this.colMaterialID.Name = "colMaterialID";
            this.colMaterialID.Visible = true;
            this.colMaterialID.VisibleIndex = 8;
            this.colMaterialID.Width = 120;
            // 
            // colStageID
            // 
            this.colStageID.Caption = "Mã công đoạn";
            this.colStageID.FieldName = "StageID";
            this.colStageID.MinWidth = 25;
            this.colStageID.Name = "colStageID";
            this.colStageID.Visible = true;
            this.colStageID.VisibleIndex = 9;
            this.colStageID.Width = 120;
            // 
            // colStageName
            // 
            this.colStageName.Caption = "Tên công đoạn";
            this.colStageName.FieldName = "StageName";
            this.colStageName.MinWidth = 25;
            this.colStageName.Name = "colStageName";
            this.colStageName.Visible = true;
            this.colStageName.VisibleIndex = 10;
            this.colStageName.Width = 250;
            // 
            // colMixStage
            // 
            this.colMixStage.Caption = "Công đoạn tổng hợp";
            this.colMixStage.FieldName = "MixStage";
            this.colMixStage.MinWidth = 25;
            this.colMixStage.Name = "colMixStage";
            this.colMixStage.Visible = true;
            this.colMixStage.VisibleIndex = 11;
            this.colMixStage.Width = 94;
            // 
            // colCheckInDt
            // 
            this.colCheckInDt.Caption = "Giờ vào";
            this.colCheckInDt.DisplayFormat.FormatString = "HH:mm:ss";
            this.colCheckInDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckInDt.FieldName = "CheckInDt";
            this.colCheckInDt.MinWidth = 25;
            this.colCheckInDt.Name = "colCheckInDt";
            this.colCheckInDt.Visible = true;
            this.colCheckInDt.VisibleIndex = 12;
            this.colCheckInDt.Width = 120;
            // 
            // colCheckOutDt
            // 
            this.colCheckOutDt.Caption = "Giờ ra";
            this.colCheckOutDt.DisplayFormat.FormatString = "HH:mm:ss";
            this.colCheckOutDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCheckOutDt.FieldName = "CheckOutDt";
            this.colCheckOutDt.MinWidth = 25;
            this.colCheckOutDt.Name = "colCheckOutDt";
            this.colCheckOutDt.Visible = true;
            this.colCheckOutDt.VisibleIndex = 13;
            this.colCheckOutDt.Width = 120;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Số lượng";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 25;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:0.##}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 14;
            this.colQuantity.Width = 94;
            // 
            // colSumTime
            // 
            this.colSumTime.Caption = "Tổng giờ";
            this.colSumTime.FieldName = "SumTime";
            this.colSumTime.MinWidth = 25;
            this.colSumTime.Name = "colSumTime";
            this.colSumTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumTime", "{0:0.##}")});
            this.colSumTime.Visible = true;
            this.colSumTime.VisibleIndex = 15;
            this.colSumTime.Width = 120;
            // 
            // colSumTimeHC
            // 
            this.colSumTimeHC.Caption = "Tổng giờ HC";
            this.colSumTimeHC.FieldName = "SumTimeHC";
            this.colSumTimeHC.MinWidth = 25;
            this.colSumTimeHC.Name = "colSumTimeHC";
            this.colSumTimeHC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumTimeHC", "{0:0.##}")});
            this.colSumTimeHC.Visible = true;
            this.colSumTimeHC.VisibleIndex = 16;
            this.colSumTimeHC.Width = 94;
            // 
            // colSumTimeTC
            // 
            this.colSumTimeTC.Caption = "Tổng giờ TC";
            this.colSumTimeTC.FieldName = "SumTimeTC";
            this.colSumTimeTC.MinWidth = 25;
            this.colSumTimeTC.Name = "colSumTimeTC";
            this.colSumTimeTC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumTimeTC", "{0:0.##}")});
            this.colSumTimeTC.Visible = true;
            this.colSumTimeTC.VisibleIndex = 17;
            this.colSumTimeTC.Width = 94;
            // 
            // colEmpProductivity
            // 
            this.colEmpProductivity.Caption = "Năng suất NV";
            this.colEmpProductivity.FieldName = "EmpProductivity";
            this.colEmpProductivity.MinWidth = 25;
            this.colEmpProductivity.Name = "colEmpProductivity";
            this.colEmpProductivity.Visible = true;
            this.colEmpProductivity.VisibleIndex = 18;
            this.colEmpProductivity.Width = 94;
            // 
            // frmPSDetailEmpByStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 683);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPSDetailEmpByStage";
            this.Text = "frmProdStatisticSummaryReport";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummaryView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraGrid.GridControl gridStatSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridStatSummaryView;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageName;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckInDt;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOutDt;
        private DevExpress.XtraGrid.Columns.GridColumn colSumTime;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpProductivity;
        private DevExpress.XtraGrid.Columns.GridColumn colStatisticDate;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colMixStage;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colSumTimeHC;
        private DevExpress.XtraGrid.Columns.GridColumn colSumTimeTC;
        private DevExpress.XtraGrid.Columns.GridColumn colLineEmpID;
    }
}