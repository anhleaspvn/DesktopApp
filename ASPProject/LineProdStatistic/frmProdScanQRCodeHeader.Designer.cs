namespace ASPProject.LineProdStatistic
{
    partial class frmProdScanQRCodeHeader
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lkeEmpID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lkeWODocNo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkeLine = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.gridScanQRCodeHeader = new DevExpress.XtraGrid.GridControl();
            this.gridScanQRCodeHeaderView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQRCodeContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdReqQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuaInstruction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToolJigID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkingTimeDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutputRateDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardORVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualQtyOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualQtyNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckInTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckOutTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWODocNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanQRCodeHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanQRCodeHeaderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainer1.Panel1.Controls.Add(this.lkeEmpID);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.lkeWODocNo);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.lkeLine);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.dtToDate);
            this.splitContainer1.Panel1.Controls.Add(this.dtFromDate);
            this.splitContainer1.Panel1.Controls.Add(this.btFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridScanQRCodeHeader);
            this.splitContainer1.Size = new System.Drawing.Size(1228, 659);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.TabIndex = 30;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(600, 20);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 16);
            this.labelControl5.TabIndex = 25;
            this.labelControl5.Text = "Mã nhân viên";
            // 
            // lkeEmpID
            // 
            this.lkeEmpID.EditValue = "";
            this.lkeEmpID.Location = new System.Drawing.Point(704, 13);
            this.lkeEmpID.Margin = new System.Windows.Forms.Padding(6);
            this.lkeEmpID.Name = "lkeEmpID";
            this.lkeEmpID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeEmpID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeEmpID.Properties.NullText = "";
            this.lkeEmpID.Size = new System.Drawing.Size(153, 22);
            this.lkeEmpID.TabIndex = 24;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(346, 58);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 16);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "LSX";
            // 
            // lkeWODocNo
            // 
            this.lkeWODocNo.EditValue = "";
            this.lkeWODocNo.Location = new System.Drawing.Point(404, 49);
            this.lkeWODocNo.Margin = new System.Windows.Forms.Padding(6);
            this.lkeWODocNo.Name = "lkeWODocNo";
            this.lkeWODocNo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeWODocNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeWODocNo.Properties.NullText = "";
            this.lkeWODocNo.Size = new System.Drawing.Size(153, 22);
            this.lkeWODocNo.TabIndex = 22;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(346, 22);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 16);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "Line";
            // 
            // lkeLine
            // 
            this.lkeLine.EditValue = "";
            this.lkeLine.Location = new System.Drawing.Point(404, 15);
            this.lkeLine.Margin = new System.Windows.Forms.Padding(5);
            this.lkeLine.Name = "lkeLine";
            this.lkeLine.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeLine.Properties.NullText = "";
            this.lkeLine.Size = new System.Drawing.Size(153, 22);
            this.lkeLine.TabIndex = 20;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 56);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 22);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(99, 49);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(191, 22);
            this.dtToDate.TabIndex = 17;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(99, 15);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(191, 22);
            this.dtFromDate.TabIndex = 16;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(1023, 40);
            this.btFilter.Margin = new System.Windows.Forms.Padding(5);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(185, 45);
            this.btFilter.TabIndex = 15;
            this.btFilter.Text = "Lọc";
            // 
            // gridScanQRCodeHeader
            // 
            this.gridScanQRCodeHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScanQRCodeHeader.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(12);
            this.gridScanQRCodeHeader.Location = new System.Drawing.Point(0, 0);
            this.gridScanQRCodeHeader.MainView = this.gridScanQRCodeHeaderView;
            this.gridScanQRCodeHeader.Margin = new System.Windows.Forms.Padding(12);
            this.gridScanQRCodeHeader.Name = "gridScanQRCodeHeader";
            this.gridScanQRCodeHeader.Size = new System.Drawing.Size(1228, 557);
            this.gridScanQRCodeHeader.TabIndex = 29;
            this.gridScanQRCodeHeader.UseEmbeddedNavigator = true;
            this.gridScanQRCodeHeader.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridScanQRCodeHeaderView,
            this.gridView2});
            // 
            // gridScanQRCodeHeaderView
            // 
            this.gridScanQRCodeHeaderView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocDate,
            this.colQRCodeContent,
            this.colWODocNo,
            this.colLineID,
            this.colProductID,
            this.colProdReqQuantity,
            this.colSOPID,
            this.colQuaInstruction,
            this.colToolJigID,
            this.colStageID,
            this.colStageName,
            this.colMaterialID,
            this.colMaterialName,
            this.colEmpID,
            this.colCycleTime,
            this.colWorkingTimeDG,
            this.colOutputRateDG,
            this.colStandardORVN,
            this.colActualQty,
            this.colActualQtyOK,
            this.colActualQtyNG,
            this.colCheckInTime,
            this.colCheckOutTime,
            this.colActualTime});
            this.gridScanQRCodeHeaderView.DetailHeight = 1315;
            this.gridScanQRCodeHeaderView.GridControl = this.gridScanQRCodeHeader;
            this.gridScanQRCodeHeaderView.Name = "gridScanQRCodeHeaderView";
            this.gridScanQRCodeHeaderView.OptionsBehavior.Editable = false;
            this.gridScanQRCodeHeaderView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridScanQRCodeHeaderView.OptionsSelection.MultiSelect = true;
            this.gridScanQRCodeHeaderView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridScanQRCodeHeaderView.OptionsView.ShowAutoFilterRow = true;
            this.gridScanQRCodeHeaderView.OptionsView.ShowGroupPanel = false;
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "Ngày chứng từ";
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.MinWidth = 39;
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 1;
            this.colDocDate.Width = 146;
            // 
            // colQRCodeContent
            // 
            this.colQRCodeContent.Caption = "Nội dung QR";
            this.colQRCodeContent.FieldName = "QRCodeContent";
            this.colQRCodeContent.MinWidth = 61;
            this.colQRCodeContent.Name = "colQRCodeContent";
            this.colQRCodeContent.Visible = true;
            this.colQRCodeContent.VisibleIndex = 24;
            this.colQRCodeContent.Width = 227;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 61;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 2;
            this.colWODocNo.Width = 227;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 61;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 3;
            this.colLineID.Width = 227;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 61;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 4;
            this.colProductID.Width = 227;
            // 
            // colProdReqQuantity
            // 
            this.colProdReqQuantity.Caption = "Số lượng yêu cầu";
            this.colProdReqQuantity.FieldName = "ProdReqQuantity";
            this.colProdReqQuantity.MinWidth = 61;
            this.colProdReqQuantity.Name = "colProdReqQuantity";
            this.colProdReqQuantity.Visible = true;
            this.colProdReqQuantity.VisibleIndex = 5;
            this.colProdReqQuantity.Width = 227;
            // 
            // colSOPID
            // 
            this.colSOPID.Caption = "Mã SOP";
            this.colSOPID.FieldName = "SOPID";
            this.colSOPID.MinWidth = 61;
            this.colSOPID.Name = "colSOPID";
            this.colSOPID.Visible = true;
            this.colSOPID.VisibleIndex = 6;
            this.colSOPID.Width = 227;
            // 
            // colQuaInstruction
            // 
            this.colQuaInstruction.Caption = "Quality Instruction";
            this.colQuaInstruction.FieldName = "QuaInstruction";
            this.colQuaInstruction.MinWidth = 61;
            this.colQuaInstruction.Name = "colQuaInstruction";
            this.colQuaInstruction.Visible = true;
            this.colQuaInstruction.VisibleIndex = 7;
            this.colQuaInstruction.Width = 227;
            // 
            // colToolJigID
            // 
            this.colToolJigID.Caption = "Mã Tool Jig";
            this.colToolJigID.FieldName = "ToolJigID";
            this.colToolJigID.MinWidth = 61;
            this.colToolJigID.Name = "colToolJigID";
            this.colToolJigID.Visible = true;
            this.colToolJigID.VisibleIndex = 8;
            this.colToolJigID.Width = 227;
            // 
            // colStageID
            // 
            this.colStageID.Caption = "Mã công đoạn";
            this.colStageID.FieldName = "StageID";
            this.colStageID.MinWidth = 61;
            this.colStageID.Name = "colStageID";
            this.colStageID.Visible = true;
            this.colStageID.VisibleIndex = 9;
            this.colStageID.Width = 227;
            // 
            // colStageName
            // 
            this.colStageName.Caption = "Tên công đoạn";
            this.colStageName.FieldName = "StageName";
            this.colStageName.MinWidth = 61;
            this.colStageName.Name = "colStageName";
            this.colStageName.Visible = true;
            this.colStageName.VisibleIndex = 10;
            this.colStageName.Width = 227;
            // 
            // colMaterialID
            // 
            this.colMaterialID.Caption = "Mã NVL";
            this.colMaterialID.FieldName = "MaterialID";
            this.colMaterialID.MinWidth = 61;
            this.colMaterialID.Name = "colMaterialID";
            this.colMaterialID.Visible = true;
            this.colMaterialID.VisibleIndex = 11;
            this.colMaterialID.Width = 227;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "Tên NVL";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.MinWidth = 61;
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 12;
            this.colMaterialName.Width = 227;
            // 
            // colEmpID
            // 
            this.colEmpID.Caption = "Tên nhân viên";
            this.colEmpID.FieldName = "EmpID";
            this.colEmpID.MinWidth = 61;
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.Visible = true;
            this.colEmpID.VisibleIndex = 13;
            this.colEmpID.Width = 227;
            // 
            // colCycleTime
            // 
            this.colCycleTime.Caption = "Cycle Time";
            this.colCycleTime.FieldName = "CycleTime";
            this.colCycleTime.MinWidth = 61;
            this.colCycleTime.Name = "colCycleTime";
            this.colCycleTime.Visible = true;
            this.colCycleTime.VisibleIndex = 14;
            this.colCycleTime.Width = 227;
            // 
            // colWorkingTimeDG
            // 
            this.colWorkingTimeDG.Caption = "Working Time DG";
            this.colWorkingTimeDG.FieldName = "WorkingTimeDG";
            this.colWorkingTimeDG.MinWidth = 61;
            this.colWorkingTimeDG.Name = "colWorkingTimeDG";
            this.colWorkingTimeDG.Visible = true;
            this.colWorkingTimeDG.VisibleIndex = 15;
            this.colWorkingTimeDG.Width = 227;
            // 
            // colOutputRateDG
            // 
            this.colOutputRateDG.Caption = "Output Rate DG";
            this.colOutputRateDG.FieldName = "OutputRateDG";
            this.colOutputRateDG.MinWidth = 61;
            this.colOutputRateDG.Name = "colOutputRateDG";
            this.colOutputRateDG.Visible = true;
            this.colOutputRateDG.VisibleIndex = 16;
            this.colOutputRateDG.Width = 227;
            // 
            // colStandardORVN
            // 
            this.colStandardORVN.Caption = "Standard OR VN";
            this.colStandardORVN.FieldName = "StandardORVN";
            this.colStandardORVN.MinWidth = 61;
            this.colStandardORVN.Name = "colStandardORVN";
            this.colStandardORVN.Visible = true;
            this.colStandardORVN.VisibleIndex = 17;
            this.colStandardORVN.Width = 227;
            // 
            // colActualQty
            // 
            this.colActualQty.Caption = "Số lượng thực tế";
            this.colActualQty.FieldName = "ActualQty";
            this.colActualQty.MinWidth = 61;
            this.colActualQty.Name = "colActualQty";
            this.colActualQty.Visible = true;
            this.colActualQty.VisibleIndex = 18;
            this.colActualQty.Width = 227;
            // 
            // colActualQtyOK
            // 
            this.colActualQtyOK.Caption = "Số lượng đạt";
            this.colActualQtyOK.FieldName = "ActualQtyOK";
            this.colActualQtyOK.MinWidth = 61;
            this.colActualQtyOK.Name = "colActualQtyOK";
            this.colActualQtyOK.Visible = true;
            this.colActualQtyOK.VisibleIndex = 19;
            this.colActualQtyOK.Width = 227;
            // 
            // colActualQtyNG
            // 
            this.colActualQtyNG.Caption = "Số lượng NG";
            this.colActualQtyNG.FieldName = "ActualQtyNG";
            this.colActualQtyNG.MinWidth = 61;
            this.colActualQtyNG.Name = "colActualQtyNG";
            this.colActualQtyNG.Visible = true;
            this.colActualQtyNG.VisibleIndex = 20;
            this.colActualQtyNG.Width = 227;
            // 
            // colCheckInTime
            // 
            this.colCheckInTime.Caption = "Thời gian check-in";
            this.colCheckInTime.FieldName = "CheckInTime";
            this.colCheckInTime.MinWidth = 61;
            this.colCheckInTime.Name = "colCheckInTime";
            this.colCheckInTime.Visible = true;
            this.colCheckInTime.VisibleIndex = 21;
            this.colCheckInTime.Width = 227;
            // 
            // colCheckOutTime
            // 
            this.colCheckOutTime.Caption = "Thời gian check-out";
            this.colCheckOutTime.FieldName = "CheckOutTime";
            this.colCheckOutTime.MinWidth = 61;
            this.colCheckOutTime.Name = "colCheckOutTime";
            this.colCheckOutTime.Visible = true;
            this.colCheckOutTime.VisibleIndex = 22;
            this.colCheckOutTime.Width = 227;
            // 
            // colActualTime
            // 
            this.colActualTime.Caption = "Thời gian thực tế";
            this.colActualTime.FieldName = "ActualTime";
            this.colActualTime.MinWidth = 61;
            this.colActualTime.Name = "colActualTime";
            this.colActualTime.Visible = true;
            this.colActualTime.VisibleIndex = 23;
            this.colActualTime.Width = 227;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 1065;
            this.gridView2.GridControl = this.gridScanQRCodeHeader;
            this.gridView2.Name = "gridView2";
            // 
            // frmProdScanQRCodeHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 659);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProdScanQRCodeHeader";
            this.Text = "frmProdScanQRCodeHeader";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWODocNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanQRCodeHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanQRCodeHeaderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridScanQRCodeHeader;
        private DevExpress.XtraGrid.Views.Grid.GridView gridScanQRCodeHeaderView;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colQRCodeContent;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colProdReqQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colSOPID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuaInstruction;
        private DevExpress.XtraGrid.Columns.GridColumn colToolJigID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleTime;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkingTimeDG;
        private DevExpress.XtraGrid.Columns.GridColumn colOutputRateDG;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardORVN;
        private DevExpress.XtraGrid.Columns.GridColumn colActualQty;
        private DevExpress.XtraGrid.Columns.GridColumn colActualQtyOK;
        private DevExpress.XtraGrid.Columns.GridColumn colActualQtyNG;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckInTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOutTime;
        private DevExpress.XtraGrid.Columns.GridColumn colActualTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.LookUpEdit lkeLine;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkeWODocNo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lkeEmpID;
    }
}