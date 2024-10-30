namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailMachineByStage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPSDetailMachineByStage));
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridStatSummary = new DevExpress.XtraGrid.GridControl();
            this.gridStatSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colThang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatisticDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdReqQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckInDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOutDt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummaryView)).BeginInit();
            this.SuspendLayout();
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(752, 6);
            this.btExport.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(103, 24);
            this.btExport.TabIndex = 15;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(302, 19);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 19);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(395, 15);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(142, 20);
            this.dtToDate.TabIndex = 12;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(117, 15);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(142, 20);
            this.dtFromDate.TabIndex = 11;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(624, 6);
            this.btFilter.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(103, 24);
            this.btFilter.TabIndex = 10;
            this.btFilter.Text = "Lọc";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1132, 498);
            this.splitContainerControl1.SplitterPosition = 47;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // gridStatSummary
            // 
            this.gridStatSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatSummary.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gridStatSummary.Location = new System.Drawing.Point(0, 0);
            this.gridStatSummary.MainView = this.gridStatSummaryView;
            this.gridStatSummary.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gridStatSummary.Name = "gridStatSummary";
            this.gridStatSummary.Size = new System.Drawing.Size(1132, 447);
            this.gridStatSummary.TabIndex = 4;
            this.gridStatSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridStatSummaryView});
            // 
            // gridStatSummaryView
            // 
            this.gridStatSummaryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colThang,
            this.colStatisticDate,
            this.colWODocNo,
            this.colProductID,
            this.colProdReqQuantity,
            this.colProductType,
            this.colStageID,
            this.colStageName,
            this.colMachineID,
            this.colMachineName,
            this.colMachineGroup,
            this.colCheckInDt,
            this.colCheckOutDt,
            this.colSumTime});
            this.gridStatSummaryView.DetailHeight = 692;
            this.gridStatSummaryView.GridControl = this.gridStatSummary;
            this.gridStatSummaryView.Name = "gridStatSummaryView";
            this.gridStatSummaryView.OptionsBehavior.ReadOnly = true;
            this.gridStatSummaryView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridStatSummaryView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridStatSummaryView.OptionsView.RowAutoHeight = true;
            this.gridStatSummaryView.OptionsView.ShowAutoFilterRow = true;
            this.gridStatSummaryView.OptionsView.ShowFooter = true;
            this.gridStatSummaryView.OptionsView.ShowGroupPanel = false;
            // 
            // colThang
            // 
            this.colThang.Caption = "Tháng";
            this.colThang.FieldName = "Thang";
            this.colThang.Name = "colThang";
            this.colThang.Visible = true;
            this.colThang.VisibleIndex = 0;
            this.colThang.Width = 64;
            // 
            // colStatisticDate
            // 
            this.colStatisticDate.Caption = "Ngày";
            this.colStatisticDate.FieldName = "StatisticDate";
            this.colStatisticDate.Name = "colStatisticDate";
            this.colStatisticDate.Visible = true;
            this.colStatisticDate.VisibleIndex = 1;
            this.colStatisticDate.Width = 64;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 2;
            this.colWODocNo.Width = 64;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 3;
            this.colProductID.Width = 64;
            // 
            // colProdReqQuantity
            // 
            this.colProdReqQuantity.Caption = "Số lượng yêu cầu";
            this.colProdReqQuantity.FieldName = "ProdReqQuantity";
            this.colProdReqQuantity.Name = "colProdReqQuantity";
            this.colProdReqQuantity.Visible = true;
            this.colProdReqQuantity.VisibleIndex = 4;
            this.colProdReqQuantity.Width = 64;
            // 
            // colProductType
            // 
            this.colProductType.Caption = "Loại sản phẩm";
            this.colProductType.FieldName = "ProductType";
            this.colProductType.Name = "colProductType";
            this.colProductType.Visible = true;
            this.colProductType.VisibleIndex = 5;
            this.colProductType.Width = 64;
            // 
            // colStageID
            // 
            this.colStageID.Caption = "Mã công đoạn";
            this.colStageID.FieldName = "StageID";
            this.colStageID.Name = "colStageID";
            this.colStageID.Visible = true;
            this.colStageID.VisibleIndex = 6;
            this.colStageID.Width = 64;
            // 
            // colStageName
            // 
            this.colStageName.Caption = "Tên công đoạn";
            this.colStageName.FieldName = "StageName";
            this.colStageName.Name = "colStageName";
            this.colStageName.Visible = true;
            this.colStageName.VisibleIndex = 7;
            this.colStageName.Width = 64;
            // 
            // colMachineID
            // 
            this.colMachineID.Caption = "Mã máy";
            this.colMachineID.FieldName = "MachineID";
            this.colMachineID.Name = "colMachineID";
            this.colMachineID.Visible = true;
            this.colMachineID.VisibleIndex = 8;
            this.colMachineID.Width = 64;
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "Tên máy";
            this.colMachineName.FieldName = "MachineName";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 9;
            this.colMachineName.Width = 64;
            // 
            // colMachineGroup
            // 
            this.colMachineGroup.Caption = "Nhóm máy";
            this.colMachineGroup.FieldName = "MachineGroup";
            this.colMachineGroup.Name = "colMachineGroup";
            this.colMachineGroup.Visible = true;
            this.colMachineGroup.VisibleIndex = 10;
            this.colMachineGroup.Width = 64;
            // 
            // colCheckInDt
            // 
            this.colCheckInDt.Caption = "Thời gian Check-in";
            this.colCheckInDt.FieldName = "CheckInDt";
            this.colCheckInDt.Name = "colCheckInDt";
            this.colCheckInDt.Visible = true;
            this.colCheckInDt.VisibleIndex = 11;
            this.colCheckInDt.Width = 64;
            // 
            // colCheckOutDt
            // 
            this.colCheckOutDt.Caption = "Thời gian Check-out";
            this.colCheckOutDt.FieldName = "CheckOutDt";
            this.colCheckOutDt.Name = "colCheckOutDt";
            this.colCheckOutDt.Visible = true;
            this.colCheckOutDt.VisibleIndex = 12;
            this.colCheckOutDt.Width = 64;
            // 
            // colSumTime
            // 
            this.colSumTime.Caption = "Tổng thời gian";
            this.colSumTime.FieldName = "SumTime";
            this.colSumTime.Name = "colSumTime";
            this.colSumTime.Visible = true;
            this.colSumTime.VisibleIndex = 13;
            this.colSumTime.Width = 64;
            // 
            // frmPSDetailMachineByStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 498);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPSDetailMachineByStage";
            this.Text = "frmPSDetailMachineByStage";
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummaryView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridStatSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridStatSummaryView;
        private DevExpress.XtraGrid.Columns.GridColumn colThang;
        private DevExpress.XtraGrid.Columns.GridColumn colStatisticDate;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colProdReqQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colStageID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageName;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckInDt;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOutDt;
        private DevExpress.XtraGrid.Columns.GridColumn colSumTime;
    }
}