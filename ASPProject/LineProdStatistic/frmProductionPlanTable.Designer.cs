namespace ASPProject.LineProdStatistic
{
    partial class frmProductionPlanTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionPlanTable));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.gridAttMonth = new DevExpress.XtraGrid.GridControl();
            this.gridAttMonthView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProdBeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductID_CN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProdReqQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CostBomTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProdWorktime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SubJobTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProdStatisticQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProdRemainQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Productivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProdBeginTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProdEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProdStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateOfMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateOfReqMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateOfFinMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OTD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SumDefects = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SumReworkOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SumNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YieldRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ScrapRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ParentWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ParChildWorkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ParChildORVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ParChildProductivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ManReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MachineReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MethodReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Thanh_Tien_ThucDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Thanh_Tien_ChenhLech_ThucDung_BOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ty_Le_HaoHut_Vuot_DinhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridAttMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttMonthView)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gridAttMonth);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1579, 686);
            this.splitContainerControl1.SplitterPosition = 48;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(472, 10);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(143, 29);
            this.btExport.TabIndex = 15;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Từ ngày";
            this.labelControl1.Visible = false;
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(139, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(147, 23);
            this.dtToDate.TabIndex = 12;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(140, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(147, 23);
            this.dtFromDate.TabIndex = 11;
            this.dtFromDate.Visible = false;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(329, 10);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(118, 29);
            this.btFilter.TabIndex = 10;
            this.btFilter.Text = "Lọc";
            // 
            // gridAttMonth
            // 
            this.gridAttMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttMonth.Location = new System.Drawing.Point(0, 0);
            this.gridAttMonth.MainView = this.gridAttMonthView;
            this.gridAttMonth.Name = "gridAttMonth";
            this.gridAttMonth.Size = new System.Drawing.Size(1579, 633);
            this.gridAttMonth.TabIndex = 2;
            this.gridAttMonth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAttMonthView});
            // 
            // gridAttMonthView
            // 
            this.gridAttMonthView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProdBeginDate,
            this.WODocNo,
            this.ProductID,
            this.ProductID_CN,
            this.CustomerID,
            this.ProductType,
            this.LineID,
            this.ProdReqQuantity,
            this.CostBomTime,
            this.ProdWorktime,
            this.SubJobTime,
            this.ProdStatisticQuantity,
            this.ProdRemainQuantity,
            this.ORDG,
            this.ORVN,
            this.Productivity,
            this.ProdBeginTime,
            this.ProdEndTime,
            this.ProdStatus,
            this.DateOfMaterial,
            this.DateOfReqMaterial,
            this.DateOfFinMaterial,
            this.OTD,
            this.SumDefects,
            this.SumReworkOK,
            this.SumNG,
            this.YieldRate,
            this.ScrapRate,
            this.ParentWODocNo,
            this.ParChildWorkTime,
            this.ParChildORVN,
            this.ParChildProductivity,
            this.MaterialReason,
            this.ManReason,
            this.MachineReason,
            this.MethodReason,
            this.Thanh_Tien_ThucDung,
            this.Thanh_Tien_ChenhLech_ThucDung_BOM,
            this.Ty_Le_HaoHut_Vuot_DinhMuc});
            this.gridAttMonthView.GridControl = this.gridAttMonth;
            this.gridAttMonthView.Name = "gridAttMonthView";
            this.gridAttMonthView.OptionsBehavior.ReadOnly = true;
            this.gridAttMonthView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridAttMonthView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridAttMonthView.OptionsView.ColumnAutoWidth = false;
            this.gridAttMonthView.OptionsView.ShowAutoFilterRow = true;
            this.gridAttMonthView.OptionsView.ShowFooter = true;
            this.gridAttMonthView.OptionsView.ShowGroupPanel = false;
            // 
            // ProdBeginDate
            // 
            this.ProdBeginDate.Caption = "Tháng sản xuất";
            this.ProdBeginDate.FieldName = "ProdBeginDate";
            this.ProdBeginDate.MinWidth = 25;
            this.ProdBeginDate.Name = "ProdBeginDate";
            this.ProdBeginDate.Visible = true;
            this.ProdBeginDate.VisibleIndex = 0;
            this.ProdBeginDate.Width = 94;
            // 
            // WODocNo
            // 
            this.WODocNo.Caption = "Lệnh sản xuất";
            this.WODocNo.FieldName = "WODocNo";
            this.WODocNo.MinWidth = 25;
            this.WODocNo.Name = "WODocNo";
            this.WODocNo.Visible = true;
            this.WODocNo.VisibleIndex = 1;
            this.WODocNo.Width = 94;
            // 
            // ProductID
            // 
            this.ProductID.Caption = "Mã sản phẩm VN";
            this.ProductID.FieldName = "ProductID";
            this.ProductID.MinWidth = 25;
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = true;
            this.ProductID.VisibleIndex = 2;
            this.ProductID.Width = 94;
            // 
            // ProductID_CN
            // 
            this.ProductID_CN.Caption = "Mã sản phẩm CN";
            this.ProductID_CN.FieldName = "ProductID_CN";
            this.ProductID_CN.MinWidth = 25;
            this.ProductID_CN.Name = "ProductID_CN";
            this.ProductID_CN.Visible = true;
            this.ProductID_CN.VisibleIndex = 3;
            this.ProductID_CN.Width = 94;
            // 
            // CustomerID
            // 
            this.CustomerID.Caption = "Mã khách hàng";
            this.CustomerID.FieldName = "CustomerID";
            this.CustomerID.MinWidth = 25;
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Visible = true;
            this.CustomerID.VisibleIndex = 4;
            this.CustomerID.Width = 94;
            // 
            // ProductType
            // 
            this.ProductType.Caption = "Loại sản phẩm";
            this.ProductType.FieldName = "ProductType";
            this.ProductType.MinWidth = 25;
            this.ProductType.Name = "ProductType";
            this.ProductType.Visible = true;
            this.ProductType.VisibleIndex = 5;
            this.ProductType.Width = 94;
            // 
            // LineID
            // 
            this.LineID.Caption = "Chuyền";
            this.LineID.FieldName = "LineID";
            this.LineID.MinWidth = 25;
            this.LineID.Name = "LineID";
            this.LineID.Visible = true;
            this.LineID.VisibleIndex = 6;
            this.LineID.Width = 94;
            // 
            // ProdReqQuantity
            // 
            this.ProdReqQuantity.Caption = "Số lượng yêu cầu";
            this.ProdReqQuantity.DisplayFormat.FormatString = "#.#";
            this.ProdReqQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ProdReqQuantity.FieldName = "ProdReqQuantity";
            this.ProdReqQuantity.MinWidth = 25;
            this.ProdReqQuantity.Name = "ProdReqQuantity";
            this.ProdReqQuantity.Visible = true;
            this.ProdReqQuantity.VisibleIndex = 7;
            this.ProdReqQuantity.Width = 94;
            // 
            // CostBomTime
            // 
            this.CostBomTime.Caption = "Giờ công Cost Bom";
            this.CostBomTime.DisplayFormat.FormatString = "#.#";
            this.CostBomTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CostBomTime.FieldName = "CostBomTime";
            this.CostBomTime.MinWidth = 25;
            this.CostBomTime.Name = "CostBomTime";
            this.CostBomTime.Visible = true;
            this.CostBomTime.VisibleIndex = 8;
            this.CostBomTime.Width = 94;
            // 
            // ProdWorktime
            // 
            this.ProdWorktime.Caption = "Giờ công TT";
            this.ProdWorktime.DisplayFormat.FormatString = "#.#";
            this.ProdWorktime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ProdWorktime.FieldName = "ProdWorktime";
            this.ProdWorktime.MinWidth = 25;
            this.ProdWorktime.Name = "ProdWorktime";
            this.ProdWorktime.Visible = true;
            this.ProdWorktime.VisibleIndex = 9;
            this.ProdWorktime.Width = 94;
            // 
            // SubJobTime
            // 
            this.SubJobTime.Caption = "Giờ Sub Job";
            this.SubJobTime.DisplayFormat.FormatString = "#.#";
            this.SubJobTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SubJobTime.FieldName = "SubJobTime";
            this.SubJobTime.MinWidth = 25;
            this.SubJobTime.Name = "SubJobTime";
            this.SubJobTime.Visible = true;
            this.SubJobTime.VisibleIndex = 10;
            this.SubJobTime.Width = 94;
            // 
            // ProdStatisticQuantity
            // 
            this.ProdStatisticQuantity.Caption = "Số lượng đạt";
            this.ProdStatisticQuantity.DisplayFormat.FormatString = "#.#";
            this.ProdStatisticQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ProdStatisticQuantity.FieldName = "ProdStatisticQuantity";
            this.ProdStatisticQuantity.MinWidth = 25;
            this.ProdStatisticQuantity.Name = "ProdStatisticQuantity";
            this.ProdStatisticQuantity.Visible = true;
            this.ProdStatisticQuantity.VisibleIndex = 11;
            this.ProdStatisticQuantity.Width = 94;
            // 
            // ProdRemainQuantity
            // 
            this.ProdRemainQuantity.Caption = "Số lượng còn lại";
            this.ProdRemainQuantity.DisplayFormat.FormatString = "#.#";
            this.ProdRemainQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ProdRemainQuantity.FieldName = "ProdRemainQuantity";
            this.ProdRemainQuantity.MinWidth = 25;
            this.ProdRemainQuantity.Name = "ProdRemainQuantity";
            this.ProdRemainQuantity.Visible = true;
            this.ProdRemainQuantity.VisibleIndex = 12;
            this.ProdRemainQuantity.Width = 94;
            // 
            // ORDG
            // 
            this.ORDG.Caption = "Output rate Cost Bom";
            this.ORDG.DisplayFormat.FormatString = "0.##";
            this.ORDG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ORDG.FieldName = "ORDG";
            this.ORDG.MinWidth = 25;
            this.ORDG.Name = "ORDG";
            this.ORDG.Visible = true;
            this.ORDG.VisibleIndex = 13;
            this.ORDG.Width = 94;
            // 
            // ORVN
            // 
            this.ORVN.Caption = "Output rate VN";
            this.ORVN.DisplayFormat.FormatString = "0.##";
            this.ORVN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ORVN.FieldName = "ORVN";
            this.ORVN.MinWidth = 25;
            this.ORVN.Name = "ORVN";
            this.ORVN.Visible = true;
            this.ORVN.VisibleIndex = 14;
            this.ORVN.Width = 94;
            // 
            // Productivity
            // 
            this.Productivity.Caption = "Năng suất";
            this.Productivity.DisplayFormat.FormatString = "#.##";
            this.Productivity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Productivity.FieldName = "Productivity";
            this.Productivity.MinWidth = 25;
            this.Productivity.Name = "Productivity";
            this.Productivity.Visible = true;
            this.Productivity.VisibleIndex = 15;
            this.Productivity.Width = 94;
            // 
            // ProdBeginTime
            // 
            this.ProdBeginTime.Caption = "Ngày bắt đầu";
            this.ProdBeginTime.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ProdBeginTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ProdBeginTime.FieldName = "ProdBeginTime";
            this.ProdBeginTime.MinWidth = 25;
            this.ProdBeginTime.Name = "ProdBeginTime";
            this.ProdBeginTime.Visible = true;
            this.ProdBeginTime.VisibleIndex = 16;
            this.ProdBeginTime.Width = 94;
            // 
            // ProdEndTime
            // 
            this.ProdEndTime.Caption = "Ngày kết thúc";
            this.ProdEndTime.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.ProdEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ProdEndTime.FieldName = "ProdEndTime";
            this.ProdEndTime.MinWidth = 25;
            this.ProdEndTime.Name = "ProdEndTime";
            this.ProdEndTime.Visible = true;
            this.ProdEndTime.VisibleIndex = 17;
            this.ProdEndTime.Width = 94;
            // 
            // ProdStatus
            // 
            this.ProdStatus.Caption = "Tình trạng SX";
            this.ProdStatus.FieldName = "ProdStatus";
            this.ProdStatus.MinWidth = 25;
            this.ProdStatus.Name = "ProdStatus";
            this.ProdStatus.Visible = true;
            this.ProdStatus.VisibleIndex = 18;
            this.ProdStatus.Width = 94;
            // 
            // DateOfMaterial
            // 
            this.DateOfMaterial.Caption = "Ngày nhận vật tư";
            this.DateOfMaterial.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.DateOfMaterial.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateOfMaterial.FieldName = "DateOfMaterial";
            this.DateOfMaterial.MinWidth = 25;
            this.DateOfMaterial.Name = "DateOfMaterial";
            this.DateOfMaterial.Visible = true;
            this.DateOfMaterial.VisibleIndex = 19;
            this.DateOfMaterial.Width = 94;
            // 
            // DateOfReqMaterial
            // 
            this.DateOfReqMaterial.Caption = "Ngày YC nhận VT";
            this.DateOfReqMaterial.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.DateOfReqMaterial.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateOfReqMaterial.FieldName = "DateOfReqMaterial";
            this.DateOfReqMaterial.MinWidth = 25;
            this.DateOfReqMaterial.Name = "DateOfReqMaterial";
            this.DateOfReqMaterial.Visible = true;
            this.DateOfReqMaterial.VisibleIndex = 20;
            this.DateOfReqMaterial.Width = 94;
            // 
            // DateOfFinMaterial
            // 
            this.DateOfFinMaterial.Caption = "Ngày YC hoàn thành";
            this.DateOfFinMaterial.FieldName = "DateOfFinMaterial";
            this.DateOfFinMaterial.MinWidth = 25;
            this.DateOfFinMaterial.Name = "DateOfFinMaterial";
            this.DateOfFinMaterial.Visible = true;
            this.DateOfFinMaterial.VisibleIndex = 21;
            this.DateOfFinMaterial.Width = 94;
            // 
            // OTD
            // 
            this.OTD.Caption = "OTD";
            this.OTD.FieldName = "OTD";
            this.OTD.MinWidth = 25;
            this.OTD.Name = "OTD";
            this.OTD.Visible = true;
            this.OTD.VisibleIndex = 22;
            this.OTD.Width = 94;
            // 
            // SumDefects
            // 
            this.SumDefects.Caption = "Tổng SL lỗi";
            this.SumDefects.DisplayFormat.FormatString = "#.#";
            this.SumDefects.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SumDefects.FieldName = "SumDefects";
            this.SumDefects.MinWidth = 25;
            this.SumDefects.Name = "SumDefects";
            this.SumDefects.Visible = true;
            this.SumDefects.VisibleIndex = 23;
            this.SumDefects.Width = 94;
            // 
            // SumReworkOK
            // 
            this.SumReworkOK.Caption = "Số lượng RW OK";
            this.SumReworkOK.DisplayFormat.FormatString = "#.#";
            this.SumReworkOK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SumReworkOK.FieldName = "SumReworkOK";
            this.SumReworkOK.MinWidth = 25;
            this.SumReworkOK.Name = "SumReworkOK";
            this.SumReworkOK.Visible = true;
            this.SumReworkOK.VisibleIndex = 24;
            this.SumReworkOK.Width = 94;
            // 
            // SumNG
            // 
            this.SumNG.Caption = "Số lượng Scrap";
            this.SumNG.DisplayFormat.FormatString = "#.#";
            this.SumNG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SumNG.FieldName = "SumNG";
            this.SumNG.MinWidth = 25;
            this.SumNG.Name = "SumNG";
            this.SumNG.Visible = true;
            this.SumNG.VisibleIndex = 25;
            this.SumNG.Width = 94;
            // 
            // YieldRate
            // 
            this.YieldRate.Caption = "Tỷ lệ Yield (%)";
            this.YieldRate.DisplayFormat.FormatString = "#.#";
            this.YieldRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.YieldRate.FieldName = "YieldRate";
            this.YieldRate.MinWidth = 25;
            this.YieldRate.Name = "YieldRate";
            this.YieldRate.Visible = true;
            this.YieldRate.VisibleIndex = 26;
            this.YieldRate.Width = 94;
            // 
            // ScrapRate
            // 
            this.ScrapRate.Caption = "Tỷ lệ Scrap (%)";
            this.ScrapRate.DisplayFormat.FormatString = "#.#";
            this.ScrapRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ScrapRate.FieldName = "ScrapRate";
            this.ScrapRate.MinWidth = 25;
            this.ScrapRate.Name = "ScrapRate";
            this.ScrapRate.Visible = true;
            this.ScrapRate.VisibleIndex = 27;
            this.ScrapRate.Width = 94;
            // 
            // ParentWODocNo
            // 
            this.ParentWODocNo.Caption = "Lệnh sản xuất mẹ";
            this.ParentWODocNo.FieldName = "ParentWODocNo";
            this.ParentWODocNo.MinWidth = 25;
            this.ParentWODocNo.Name = "ParentWODocNo";
            this.ParentWODocNo.Visible = true;
            this.ParentWODocNo.VisibleIndex = 28;
            this.ParentWODocNo.Width = 94;
            // 
            // ParChildWorkTime
            // 
            this.ParChildWorkTime.Caption = "Tổng giờ công mẹ con";
            this.ParChildWorkTime.DisplayFormat.FormatString = "n2";
            this.ParChildWorkTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ParChildWorkTime.FieldName = "ParChildWorkTime";
            this.ParChildWorkTime.MinWidth = 25;
            this.ParChildWorkTime.Name = "ParChildWorkTime";
            this.ParChildWorkTime.Visible = true;
            this.ParChildWorkTime.VisibleIndex = 29;
            this.ParChildWorkTime.Width = 94;
            // 
            // ParChildORVN
            // 
            this.ParChildORVN.Caption = "ORVN mẹ con";
            this.ParChildORVN.DisplayFormat.FormatString = "n2";
            this.ParChildORVN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ParChildORVN.FieldName = "ParChildORVN";
            this.ParChildORVN.MinWidth = 25;
            this.ParChildORVN.Name = "ParChildORVN";
            this.ParChildORVN.Visible = true;
            this.ParChildORVN.VisibleIndex = 30;
            this.ParChildORVN.Width = 94;
            // 
            // ParChildProductivity
            // 
            this.ParChildProductivity.Caption = "Năng suất mẹ con";
            this.ParChildProductivity.DisplayFormat.FormatString = "n2";
            this.ParChildProductivity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ParChildProductivity.FieldName = "ParChildProductivity";
            this.ParChildProductivity.MinWidth = 25;
            this.ParChildProductivity.Name = "ParChildProductivity";
            this.ParChildProductivity.Visible = true;
            this.ParChildProductivity.VisibleIndex = 31;
            this.ParChildProductivity.Width = 94;
            // 
            // MaterialReason
            // 
            this.MaterialReason.Caption = "Material";
            this.MaterialReason.FieldName = "MaterialReason";
            this.MaterialReason.MinWidth = 25;
            this.MaterialReason.Name = "MaterialReason";
            this.MaterialReason.Visible = true;
            this.MaterialReason.VisibleIndex = 32;
            this.MaterialReason.Width = 94;
            // 
            // ManReason
            // 
            this.ManReason.Caption = "Man";
            this.ManReason.FieldName = "ManReason";
            this.ManReason.MinWidth = 25;
            this.ManReason.Name = "ManReason";
            this.ManReason.Visible = true;
            this.ManReason.VisibleIndex = 33;
            this.ManReason.Width = 94;
            // 
            // MachineReason
            // 
            this.MachineReason.Caption = "Machine";
            this.MachineReason.FieldName = "MachineReason";
            this.MachineReason.MinWidth = 25;
            this.MachineReason.Name = "MachineReason";
            this.MachineReason.Visible = true;
            this.MachineReason.VisibleIndex = 34;
            this.MachineReason.Width = 94;
            // 
            // MethodReason
            // 
            this.MethodReason.Caption = "Method";
            this.MethodReason.FieldName = "MethodReason";
            this.MethodReason.MinWidth = 25;
            this.MethodReason.Name = "MethodReason";
            this.MethodReason.Visible = true;
            this.MethodReason.VisibleIndex = 35;
            this.MethodReason.Width = 94;
            // 
            // Thanh_Tien_ThucDung
            // 
            this.Thanh_Tien_ThucDung.Caption = "Thành tiền thực dùng";
            this.Thanh_Tien_ThucDung.DisplayFormat.FormatString = "#.##";
            this.Thanh_Tien_ThucDung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Thanh_Tien_ThucDung.FieldName = "Thanh_Tien_ThucDung";
            this.Thanh_Tien_ThucDung.MinWidth = 25;
            this.Thanh_Tien_ThucDung.Name = "Thanh_Tien_ThucDung";
            this.Thanh_Tien_ThucDung.Visible = true;
            this.Thanh_Tien_ThucDung.VisibleIndex = 36;
            this.Thanh_Tien_ThucDung.Width = 94;
            // 
            // Thanh_Tien_ChenhLech_ThucDung_BOM
            // 
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.Caption = "Thành tiền CL Thực dùng - BOM";
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.DisplayFormat.FormatString = "#.##";
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.FieldName = "Thanh_Tien_ChenhLech_ThucDung_BOM";
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.MinWidth = 25;
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.Name = "Thanh_Tien_ChenhLech_ThucDung_BOM";
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.Visible = true;
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.VisibleIndex = 37;
            this.Thanh_Tien_ChenhLech_ThucDung_BOM.Width = 94;
            // 
            // Ty_Le_HaoHut_Vuot_DinhMuc
            // 
            this.Ty_Le_HaoHut_Vuot_DinhMuc.Caption = "Tỷ lệ hao hụt vượt định mức";
            this.Ty_Le_HaoHut_Vuot_DinhMuc.DisplayFormat.FormatString = "#.##";
            this.Ty_Le_HaoHut_Vuot_DinhMuc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Ty_Le_HaoHut_Vuot_DinhMuc.FieldName = "Ty_Le_HaoHut_Vuot_DinhMuc";
            this.Ty_Le_HaoHut_Vuot_DinhMuc.MinWidth = 25;
            this.Ty_Le_HaoHut_Vuot_DinhMuc.Name = "Ty_Le_HaoHut_Vuot_DinhMuc";
            this.Ty_Le_HaoHut_Vuot_DinhMuc.Visible = true;
            this.Ty_Le_HaoHut_Vuot_DinhMuc.VisibleIndex = 38;
            this.Ty_Le_HaoHut_Vuot_DinhMuc.Width = 94;
            // 
            // frmProductionPlanTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 686);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductionPlanTable";
            this.Text = "frmProductionPlanTable";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridAttMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttMonthView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridAttMonth;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAttMonthView;
        private DevExpress.XtraGrid.Columns.GridColumn ProdBeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn WODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID_CN;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn ProductType;
        private DevExpress.XtraGrid.Columns.GridColumn LineID;
        private DevExpress.XtraGrid.Columns.GridColumn ProdReqQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn CostBomTime;
        private DevExpress.XtraGrid.Columns.GridColumn ProdWorktime;
        private DevExpress.XtraGrid.Columns.GridColumn ProdStatisticQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn ProdRemainQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn ORDG;
        private DevExpress.XtraGrid.Columns.GridColumn ORVN;
        private DevExpress.XtraGrid.Columns.GridColumn Productivity;
        private DevExpress.XtraGrid.Columns.GridColumn ProdBeginTime;
        private DevExpress.XtraGrid.Columns.GridColumn ProdEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn ProdStatus;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn SubJobTime;
        private DevExpress.XtraGrid.Columns.GridColumn DateOfMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn DateOfReqMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn DateOfFinMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn OTD;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraGrid.Columns.GridColumn SumDefects;
        private DevExpress.XtraGrid.Columns.GridColumn SumReworkOK;
        private DevExpress.XtraGrid.Columns.GridColumn SumNG;
        private DevExpress.XtraGrid.Columns.GridColumn YieldRate;
        private DevExpress.XtraGrid.Columns.GridColumn ScrapRate;
        private DevExpress.XtraGrid.Columns.GridColumn ParentWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn ParChildWorkTime;
        private DevExpress.XtraGrid.Columns.GridColumn ParChildORVN;
        private DevExpress.XtraGrid.Columns.GridColumn ParChildProductivity;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialReason;
        private DevExpress.XtraGrid.Columns.GridColumn ManReason;
        private DevExpress.XtraGrid.Columns.GridColumn MachineReason;
        private DevExpress.XtraGrid.Columns.GridColumn MethodReason;
        private DevExpress.XtraGrid.Columns.GridColumn Thanh_Tien_ThucDung;
        private DevExpress.XtraGrid.Columns.GridColumn Thanh_Tien_ChenhLech_ThucDung_BOM;
        private DevExpress.XtraGrid.Columns.GridColumn Ty_Le_HaoHut_Vuot_DinhMuc;
    }
}