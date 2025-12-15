namespace ASPProject.LineProdStatistic
{
    partial class frmPLineMachineInsRequire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPLineMachineInsRequire));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.gridMachineIns = new DevExpress.XtraGrid.GridControl();
            this.gridMachineInsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequiredStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTechName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTechApprovalName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTechApprovalTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumReceivedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumWaitingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumTimeSetup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCompleteName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJigID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.btEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btAdd = new DevExpress.XtraEditors.SimpleButton();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineIns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineInsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtToDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtFromDate);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridMachineIns);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1253, 717);
            this.splitContainerControl1.SplitterPosition = 54;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(788, 8);
            this.btFilter.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(161, 38);
            this.btFilter.TabIndex = 19;
            this.btFilter.Text = "Lọc";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(398, 22);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(62, 22);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(495, 16);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(222, 23);
            this.dtToDate.TabIndex = 16;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(147, 16);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(222, 23);
            this.dtFromDate.TabIndex = 15;
            // 
            // gridMachineIns
            // 
            this.gridMachineIns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMachineIns.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.gridMachineIns.Location = new System.Drawing.Point(0, 0);
            this.gridMachineIns.MainView = this.gridMachineInsView;
            this.gridMachineIns.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.gridMachineIns.Name = "gridMachineIns";
            this.gridMachineIns.Size = new System.Drawing.Size(1253, 658);
            this.gridMachineIns.TabIndex = 4;
            this.gridMachineIns.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMachineInsView});
            // 
            // gridMachineInsView
            // 
            this.gridMachineInsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocDate,
            this.colLineID,
            this.colWODocNo,
            this.colProductID,
            this.colStageName,
            this.colMachineID,
            this.colMachineGroup,
            this.colRequiredStatus,
            this.colMaterialID,
            this.colMaterialQuantity,
            this.colCreatedDate,
            this.colIsPriority,
            this.colTechName,
            this.colTechApprovalName,
            this.colStartTime,
            this.colEndTime,
            this.colTechApprovalTime,
            this.colSumTime,
            this.colSumReceivedTime,
            this.colSumWaitingTime,
            this.colSumTimeSetup,
            this.colIsCompleteName,
            this.colJigID,
            this.colNotes});
            this.gridMachineInsView.DetailHeight = 1081;
            this.gridMachineInsView.GridControl = this.gridMachineIns;
            this.gridMachineInsView.Name = "gridMachineInsView";
            this.gridMachineInsView.OptionsBehavior.Editable = false;
            this.gridMachineInsView.OptionsBehavior.ReadOnly = true;
            this.gridMachineInsView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridMachineInsView.OptionsPrint.AutoWidth = false;
            this.gridMachineInsView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridMachineInsView.OptionsView.RowAutoHeight = true;
            this.gridMachineInsView.OptionsView.ShowAutoFilterRow = true;
            this.gridMachineInsView.OptionsView.ShowFooter = true;
            this.gridMachineInsView.OptionsView.ShowGroupPanel = false;
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "Ngày yêu cầu";
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.MinWidth = 25;
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 0;
            this.colDocDate.Width = 94;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Mã Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 25;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 1;
            this.colLineID.Width = 94;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 2;
            this.colWODocNo.Width = 94;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 25;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 3;
            this.colProductID.Width = 94;
            // 
            // colStageName
            // 
            this.colStageName.Caption = "Tên công đoạn";
            this.colStageName.FieldName = "StageName";
            this.colStageName.MinWidth = 25;
            this.colStageName.Name = "colStageName";
            this.colStageName.Visible = true;
            this.colStageName.VisibleIndex = 4;
            this.colStageName.Width = 94;
            // 
            // colMachineID
            // 
            this.colMachineID.Caption = "Mã máy";
            this.colMachineID.FieldName = "MachineID";
            this.colMachineID.MinWidth = 25;
            this.colMachineID.Name = "colMachineID";
            this.colMachineID.Visible = true;
            this.colMachineID.VisibleIndex = 5;
            this.colMachineID.Width = 94;
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
            // colRequiredStatus
            // 
            this.colRequiredStatus.Caption = "Trạng thái yêu cầu";
            this.colRequiredStatus.FieldName = "RequiredStatus";
            this.colRequiredStatus.MinWidth = 25;
            this.colRequiredStatus.Name = "colRequiredStatus";
            this.colRequiredStatus.Visible = true;
            this.colRequiredStatus.VisibleIndex = 8;
            this.colRequiredStatus.Width = 94;
            // 
            // colMaterialID
            // 
            this.colMaterialID.Caption = "Mã nguyên vật liệu";
            this.colMaterialID.FieldName = "MaterialID";
            this.colMaterialID.MinWidth = 25;
            this.colMaterialID.Name = "colMaterialID";
            this.colMaterialID.Visible = true;
            this.colMaterialID.VisibleIndex = 9;
            this.colMaterialID.Width = 94;
            // 
            // colMaterialQuantity
            // 
            this.colMaterialQuantity.Caption = "Số lượng NVL";
            this.colMaterialQuantity.FieldName = "MaterialQuantity";
            this.colMaterialQuantity.MinWidth = 25;
            this.colMaterialQuantity.Name = "colMaterialQuantity";
            this.colMaterialQuantity.Visible = true;
            this.colMaterialQuantity.VisibleIndex = 10;
            this.colMaterialQuantity.Width = 94;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày/giờ tạo";
            this.colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.MinWidth = 25;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 11;
            this.colCreatedDate.Width = 94;
            // 
            // colIsPriority
            // 
            this.colIsPriority.Caption = "Ưu tiên";
            this.colIsPriority.FieldName = "IsPriority";
            this.colIsPriority.MinWidth = 25;
            this.colIsPriority.Name = "colIsPriority";
            this.colIsPriority.Visible = true;
            this.colIsPriority.VisibleIndex = 12;
            this.colIsPriority.Width = 94;
            // 
            // colTechName
            // 
            this.colTechName.Caption = "Tên KTV";
            this.colTechName.FieldName = "TechName";
            this.colTechName.MinWidth = 25;
            this.colTechName.Name = "colTechName";
            this.colTechName.Visible = true;
            this.colTechName.VisibleIndex = 13;
            this.colTechName.Width = 94;
            // 
            // colTechApprovalName
            // 
            this.colTechApprovalName.Caption = "KTV nhận  máy";
            this.colTechApprovalName.FieldName = "TechApprovalName";
            this.colTechApprovalName.MinWidth = 25;
            this.colTechApprovalName.Name = "colTechApprovalName";
            this.colTechApprovalName.Visible = true;
            this.colTechApprovalName.VisibleIndex = 14;
            this.colTechApprovalName.Width = 94;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "Giờ bắt đầu set máy";
            this.colStartTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.MinWidth = 25;
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 15;
            this.colStartTime.Width = 94;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "Giờ kết thúc set máy";
            this.colEndTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.MinWidth = 25;
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 16;
            this.colEndTime.Width = 94;
            // 
            // colTechApprovalTime
            // 
            this.colTechApprovalTime.Caption = "Thời gian nhận máy";
            this.colTechApprovalTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colTechApprovalTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTechApprovalTime.FieldName = "TechApprovalTime";
            this.colTechApprovalTime.MinWidth = 25;
            this.colTechApprovalTime.Name = "colTechApprovalTime";
            this.colTechApprovalTime.Visible = true;
            this.colTechApprovalTime.VisibleIndex = 17;
            this.colTechApprovalTime.Width = 94;
            // 
            // colSumTime
            // 
            this.colSumTime.Caption = "Thời gian hoàn thành";
            this.colSumTime.DisplayFormat.FormatString = "#.#";
            this.colSumTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumTime.FieldName = "SumTime";
            this.colSumTime.MinWidth = 25;
            this.colSumTime.Name = "colSumTime";
            this.colSumTime.Visible = true;
            this.colSumTime.VisibleIndex = 18;
            this.colSumTime.Width = 94;
            // 
            // colSumReceivedTime
            // 
            this.colSumReceivedTime.Caption = "Thời gian chờ nhận máy";
            this.colSumReceivedTime.DisplayFormat.FormatString = "#.#";
            this.colSumReceivedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumReceivedTime.FieldName = "SumReceivedTime";
            this.colSumReceivedTime.MinWidth = 25;
            this.colSumReceivedTime.Name = "colSumReceivedTime";
            this.colSumReceivedTime.Visible = true;
            this.colSumReceivedTime.VisibleIndex = 19;
            this.colSumReceivedTime.Width = 94;
            // 
            // colSumWaitingTime
            // 
            this.colSumWaitingTime.Caption = "Thời gian chờ Setup";
            this.colSumWaitingTime.DisplayFormat.FormatString = "#.#";
            this.colSumWaitingTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumWaitingTime.FieldName = "SumWaitingTime";
            this.colSumWaitingTime.MinWidth = 25;
            this.colSumWaitingTime.Name = "colSumWaitingTime";
            this.colSumWaitingTime.Visible = true;
            this.colSumWaitingTime.VisibleIndex = 20;
            this.colSumWaitingTime.Width = 94;
            // 
            // colSumTimeSetup
            // 
            this.colSumTimeSetup.Caption = "Thời gian setup";
            this.colSumTimeSetup.DisplayFormat.FormatString = "#.#";
            this.colSumTimeSetup.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumTimeSetup.FieldName = "SumTimeSetup";
            this.colSumTimeSetup.MinWidth = 25;
            this.colSumTimeSetup.Name = "colSumTimeSetup";
            this.colSumTimeSetup.Visible = true;
            this.colSumTimeSetup.VisibleIndex = 21;
            this.colSumTimeSetup.Width = 94;
            // 
            // colIsCompleteName
            // 
            this.colIsCompleteName.Caption = "KTV Hoàn thành";
            this.colIsCompleteName.FieldName = "IsCompleteName";
            this.colIsCompleteName.MinWidth = 25;
            this.colIsCompleteName.Name = "colIsCompleteName";
            this.colIsCompleteName.Visible = true;
            this.colIsCompleteName.VisibleIndex = 22;
            this.colIsCompleteName.Width = 94;
            // 
            // colJigID
            // 
            this.colJigID.Caption = "Mã dao";
            this.colJigID.FieldName = "JigID";
            this.colJigID.MinWidth = 25;
            this.colJigID.Name = "colJigID";
            this.colJigID.Visible = true;
            this.colJigID.VisibleIndex = 6;
            this.colJigID.Width = 94;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btExport);
            this.panelControl1.Controls.Add(this.btEdit);
            this.panelControl1.Controls.Add(this.btDelete);
            this.panelControl1.Controls.Add(this.btAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 660);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1253, 57);
            this.panelControl1.TabIndex = 1;
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(1087, 14);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(143, 29);
            this.btExport.TabIndex = 16;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // btEdit
            // 
            this.btEdit.ImageOptions.Image = global::ASPProject.Properties.Resources.edit2;
            this.btEdit.Location = new System.Drawing.Point(164, 11);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(120, 35);
            this.btEdit.TabIndex = 5;
            this.btEdit.Text = "Sửa";
            // 
            // btDelete
            // 
            this.btDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btDelete.Location = new System.Drawing.Point(299, 11);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(120, 35);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "Xoá";
            // 
            // btAdd
            // 
            this.btAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.ImageOptions.Image")));
            this.btAdd.Location = new System.Drawing.Point(29, 11);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(120, 35);
            this.btAdd.TabIndex = 3;
            this.btAdd.Text = "Thêm";
            // 
            // colNotes
            // 
            this.colNotes.Caption = "Ghi chú";
            this.colNotes.FieldName = "Notes";
            this.colNotes.MinWidth = 25;
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 23;
            this.colNotes.Width = 94;
            // 
            // frmPLineMachineInsRequire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 717);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPLineMachineInsRequire";
            this.Text = "frmPLineMachineInsRequire";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineIns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineInsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraGrid.GridControl gridMachineIns;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMachineInsView;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageName;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialQuantity;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btDelete;
        private DevExpress.XtraEditors.SimpleButton btAdd;
        private DevExpress.XtraEditors.SimpleButton btEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colTechApprovalName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompleteName;
        private DevExpress.XtraGrid.Columns.GridColumn colTechName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSumTime;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraGrid.Columns.GridColumn colSumTimeSetup;
        private DevExpress.XtraGrid.Columns.GridColumn colSumWaitingTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTechApprovalTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSumReceivedTime;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colJigID;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
    }
}