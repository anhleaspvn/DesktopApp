namespace ASPProject.AttendanceEmployee
{
    partial class frmAttendanceTableByMonth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendanceTableByMonth));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.dtpFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridAttMonth = new DevExpress.XtraGrid.GridControl();
            this.gridAttMonthView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Position = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Direct_Indirect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col07 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col08 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col09 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpFromDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridAttMonth);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1160, 665);
            this.splitContainerControl1.SplitterPosition = 53;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(270, 11);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(118, 29);
            this.btFilter.TabIndex = 9;
            this.btFilter.Text = "Lọc";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.EditValue = null;
            this.dtpFromDate.Location = new System.Drawing.Point(99, 18);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtpFromDate.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 16);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Tháng";
            // 
            // gridAttMonth
            // 
            this.gridAttMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttMonth.Location = new System.Drawing.Point(0, 0);
            this.gridAttMonth.MainView = this.gridAttMonthView;
            this.gridAttMonth.Name = "gridAttMonth";
            this.gridAttMonth.Size = new System.Drawing.Size(1160, 607);
            this.gridAttMonth.TabIndex = 0;
            this.gridAttMonth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAttMonthView});
            // 
            // gridAttMonthView
            // 
            this.gridAttMonthView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EmpID,
            this.EmpName,
            this.Position,
            this.Direct_Indirect,
            this.LineID,
            this.col01,
            this.col02,
            this.col03,
            this.col04,
            this.col05,
            this.col06,
            this.col07,
            this.col08,
            this.col09,
            this.col10,
            this.col11,
            this.col12,
            this.col13,
            this.col14,
            this.col15,
            this.col16,
            this.col17,
            this.col18,
            this.col19,
            this.col20,
            this.col21,
            this.col22,
            this.col23,
            this.col24,
            this.col25,
            this.col26,
            this.col27,
            this.col28,
            this.col29,
            this.col30,
            this.col31});
            this.gridAttMonthView.GridControl = this.gridAttMonth;
            this.gridAttMonthView.Name = "gridAttMonthView";
            this.gridAttMonthView.OptionsBehavior.ReadOnly = true;
            this.gridAttMonthView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridAttMonthView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridAttMonthView.OptionsView.ShowAutoFilterRow = true;
            this.gridAttMonthView.OptionsView.ShowFooter = true;
            this.gridAttMonthView.OptionsView.ShowGroupPanel = false;
            // 
            // EmpID
            // 
            this.EmpID.Caption = "Mã nhân viên";
            this.EmpID.FieldName = "EmpID";
            this.EmpID.MinWidth = 25;
            this.EmpID.Name = "EmpID";
            this.EmpID.Visible = true;
            this.EmpID.VisibleIndex = 0;
            this.EmpID.Width = 94;
            // 
            // EmpName
            // 
            this.EmpName.Caption = "Tên nhân viên";
            this.EmpName.FieldName = "EmpName";
            this.EmpName.MinWidth = 25;
            this.EmpName.Name = "EmpName";
            this.EmpName.Visible = true;
            this.EmpName.VisibleIndex = 1;
            this.EmpName.Width = 94;
            // 
            // Position
            // 
            this.Position.Caption = "Chức vụ";
            this.Position.FieldName = "Position";
            this.Position.MinWidth = 25;
            this.Position.Name = "Position";
            this.Position.Visible = true;
            this.Position.VisibleIndex = 2;
            this.Position.Width = 94;
            // 
            // Direct_Indirect
            // 
            this.Direct_Indirect.Caption = "Direct/Indirect";
            this.Direct_Indirect.FieldName = "Direct_Indirect";
            this.Direct_Indirect.MinWidth = 25;
            this.Direct_Indirect.Name = "Direct_Indirect";
            this.Direct_Indirect.ShowUnboundExpressionMenu = true;
            this.Direct_Indirect.Visible = true;
            this.Direct_Indirect.VisibleIndex = 3;
            this.Direct_Indirect.Width = 94;
            // 
            // LineID
            // 
            this.LineID.Caption = "Mã Line";
            this.LineID.FieldName = "LineID";
            this.LineID.MinWidth = 25;
            this.LineID.Name = "LineID";
            this.LineID.Visible = true;
            this.LineID.VisibleIndex = 4;
            this.LineID.Width = 94;
            // 
            // col01
            // 
            this.col01.Caption = "01";
            this.col01.FieldName = "01";
            this.col01.MinWidth = 25;
            this.col01.Name = "col01";
            this.col01.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "01", "{0}")});
            this.col01.Visible = true;
            this.col01.VisibleIndex = 5;
            this.col01.Width = 94;
            // 
            // col02
            // 
            this.col02.Caption = "02";
            this.col02.FieldName = "02";
            this.col02.MinWidth = 25;
            this.col02.Name = "col02";
            this.col02.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "02", "{0}")});
            this.col02.Visible = true;
            this.col02.VisibleIndex = 6;
            this.col02.Width = 94;
            // 
            // col03
            // 
            this.col03.Caption = "03";
            this.col03.FieldName = "03";
            this.col03.MinWidth = 25;
            this.col03.Name = "col03";
            this.col03.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "03", "{0}")});
            this.col03.Visible = true;
            this.col03.VisibleIndex = 7;
            this.col03.Width = 94;
            // 
            // col04
            // 
            this.col04.Caption = "04";
            this.col04.FieldName = "04";
            this.col04.MinWidth = 25;
            this.col04.Name = "col04";
            this.col04.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "04", "{0}")});
            this.col04.Visible = true;
            this.col04.VisibleIndex = 8;
            this.col04.Width = 94;
            // 
            // col05
            // 
            this.col05.Caption = "05";
            this.col05.FieldName = "05";
            this.col05.MinWidth = 25;
            this.col05.Name = "col05";
            this.col05.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "05", "{0}")});
            this.col05.Visible = true;
            this.col05.VisibleIndex = 9;
            this.col05.Width = 94;
            // 
            // col06
            // 
            this.col06.Caption = "06";
            this.col06.FieldName = "06";
            this.col06.MinWidth = 25;
            this.col06.Name = "col06";
            this.col06.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "06", "{0}")});
            this.col06.Visible = true;
            this.col06.VisibleIndex = 10;
            this.col06.Width = 94;
            // 
            // col07
            // 
            this.col07.Caption = "07";
            this.col07.FieldName = "07";
            this.col07.MinWidth = 25;
            this.col07.Name = "col07";
            this.col07.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "07", "{0}")});
            this.col07.Visible = true;
            this.col07.VisibleIndex = 11;
            this.col07.Width = 94;
            // 
            // col08
            // 
            this.col08.Caption = "08";
            this.col08.FieldName = "08";
            this.col08.MinWidth = 25;
            this.col08.Name = "col08";
            this.col08.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "08", "{0}")});
            this.col08.Visible = true;
            this.col08.VisibleIndex = 12;
            this.col08.Width = 94;
            // 
            // col09
            // 
            this.col09.Caption = "09";
            this.col09.FieldName = "09";
            this.col09.MinWidth = 25;
            this.col09.Name = "col09";
            this.col09.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "09", "{0}")});
            this.col09.Visible = true;
            this.col09.VisibleIndex = 13;
            this.col09.Width = 94;
            // 
            // col10
            // 
            this.col10.Caption = "10";
            this.col10.FieldName = "10";
            this.col10.MinWidth = 25;
            this.col10.Name = "col10";
            this.col10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "10", "{0}")});
            this.col10.Visible = true;
            this.col10.VisibleIndex = 14;
            this.col10.Width = 94;
            // 
            // col11
            // 
            this.col11.Caption = "11";
            this.col11.FieldName = "11";
            this.col11.MinWidth = 25;
            this.col11.Name = "col11";
            this.col11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "11", "{0}")});
            this.col11.Visible = true;
            this.col11.VisibleIndex = 15;
            this.col11.Width = 94;
            // 
            // col12
            // 
            this.col12.Caption = "12";
            this.col12.FieldName = "12";
            this.col12.MinWidth = 25;
            this.col12.Name = "col12";
            this.col12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "12", "{0}")});
            this.col12.Visible = true;
            this.col12.VisibleIndex = 16;
            this.col12.Width = 94;
            // 
            // col13
            // 
            this.col13.Caption = "13";
            this.col13.FieldName = "13";
            this.col13.MinWidth = 25;
            this.col13.Name = "col13";
            this.col13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "13", "{0}")});
            this.col13.Visible = true;
            this.col13.VisibleIndex = 17;
            this.col13.Width = 94;
            // 
            // col14
            // 
            this.col14.Caption = "14";
            this.col14.FieldName = "14";
            this.col14.MinWidth = 25;
            this.col14.Name = "col14";
            this.col14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "14", "{0}")});
            this.col14.Visible = true;
            this.col14.VisibleIndex = 18;
            this.col14.Width = 94;
            // 
            // col15
            // 
            this.col15.Caption = "15";
            this.col15.FieldName = "15";
            this.col15.MinWidth = 25;
            this.col15.Name = "col15";
            this.col15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "15", "{0}")});
            this.col15.Visible = true;
            this.col15.VisibleIndex = 19;
            this.col15.Width = 94;
            // 
            // col16
            // 
            this.col16.Caption = "16";
            this.col16.FieldName = "16";
            this.col16.MinWidth = 25;
            this.col16.Name = "col16";
            this.col16.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "16", "{0}")});
            this.col16.Visible = true;
            this.col16.VisibleIndex = 20;
            this.col16.Width = 94;
            // 
            // col17
            // 
            this.col17.Caption = "17";
            this.col17.FieldName = "17";
            this.col17.MinWidth = 25;
            this.col17.Name = "col17";
            this.col17.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "17", "{0}")});
            this.col17.Visible = true;
            this.col17.VisibleIndex = 21;
            this.col17.Width = 94;
            // 
            // col18
            // 
            this.col18.Caption = "18";
            this.col18.FieldName = "18";
            this.col18.MinWidth = 25;
            this.col18.Name = "col18";
            this.col18.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "18", "{0}")});
            this.col18.Visible = true;
            this.col18.VisibleIndex = 22;
            this.col18.Width = 94;
            // 
            // col19
            // 
            this.col19.Caption = "19";
            this.col19.FieldName = "19";
            this.col19.MinWidth = 25;
            this.col19.Name = "col19";
            this.col19.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "19", "{0}")});
            this.col19.Visible = true;
            this.col19.VisibleIndex = 23;
            this.col19.Width = 94;
            // 
            // col20
            // 
            this.col20.Caption = "20";
            this.col20.FieldName = "20";
            this.col20.MinWidth = 25;
            this.col20.Name = "col20";
            this.col20.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "20", "{0}")});
            this.col20.Visible = true;
            this.col20.VisibleIndex = 24;
            this.col20.Width = 94;
            // 
            // col21
            // 
            this.col21.Caption = "21";
            this.col21.FieldName = "21";
            this.col21.MinWidth = 25;
            this.col21.Name = "col21";
            this.col21.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "21", "{0}")});
            this.col21.Visible = true;
            this.col21.VisibleIndex = 25;
            this.col21.Width = 94;
            // 
            // col22
            // 
            this.col22.Caption = "22";
            this.col22.FieldName = "22";
            this.col22.MinWidth = 25;
            this.col22.Name = "col22";
            this.col22.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "22", "{0}")});
            this.col22.Visible = true;
            this.col22.VisibleIndex = 26;
            this.col22.Width = 94;
            // 
            // col23
            // 
            this.col23.Caption = "23";
            this.col23.FieldName = "23";
            this.col23.MinWidth = 25;
            this.col23.Name = "col23";
            this.col23.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "23", "{0}")});
            this.col23.Visible = true;
            this.col23.VisibleIndex = 27;
            this.col23.Width = 94;
            // 
            // col24
            // 
            this.col24.Caption = "24";
            this.col24.FieldName = "24";
            this.col24.MinWidth = 25;
            this.col24.Name = "col24";
            this.col24.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "24", "{0}")});
            this.col24.Visible = true;
            this.col24.VisibleIndex = 28;
            this.col24.Width = 94;
            // 
            // col25
            // 
            this.col25.Caption = "25";
            this.col25.FieldName = "25";
            this.col25.MinWidth = 25;
            this.col25.Name = "col25";
            this.col25.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "25", "{0}")});
            this.col25.Visible = true;
            this.col25.VisibleIndex = 29;
            this.col25.Width = 94;
            // 
            // col26
            // 
            this.col26.Caption = "26";
            this.col26.FieldName = "26";
            this.col26.MinWidth = 25;
            this.col26.Name = "col26";
            this.col26.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "26", "{0}")});
            this.col26.Visible = true;
            this.col26.VisibleIndex = 30;
            this.col26.Width = 94;
            // 
            // col27
            // 
            this.col27.Caption = "27";
            this.col27.FieldName = "27";
            this.col27.MinWidth = 25;
            this.col27.Name = "col27";
            this.col27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "27", "{0}")});
            this.col27.Visible = true;
            this.col27.VisibleIndex = 31;
            this.col27.Width = 94;
            // 
            // col28
            // 
            this.col28.Caption = "28";
            this.col28.FieldName = "28";
            this.col28.MinWidth = 25;
            this.col28.Name = "col28";
            this.col28.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "28", "{0}")});
            this.col28.Visible = true;
            this.col28.VisibleIndex = 32;
            this.col28.Width = 94;
            // 
            // col29
            // 
            this.col29.Caption = "29";
            this.col29.FieldName = "29";
            this.col29.MinWidth = 25;
            this.col29.Name = "col29";
            this.col29.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "29", "{0}")});
            this.col29.Visible = true;
            this.col29.VisibleIndex = 33;
            this.col29.Width = 94;
            // 
            // col30
            // 
            this.col30.Caption = "30";
            this.col30.FieldName = "30";
            this.col30.MinWidth = 25;
            this.col30.Name = "col30";
            this.col30.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "30", "{0}")});
            this.col30.Visible = true;
            this.col30.VisibleIndex = 34;
            this.col30.Width = 94;
            // 
            // col31
            // 
            this.col31.Caption = "31";
            this.col31.FieldName = "31";
            this.col31.MinWidth = 25;
            this.col31.Name = "col31";
            this.col31.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "31", "{0}")});
            this.col31.Visible = true;
            this.col31.VisibleIndex = 35;
            this.col31.Width = 94;
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(403, 11);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(143, 29);
            this.btExport.TabIndex = 16;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // frmAttendanceTableByMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 665);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAttendanceTableByMonth";
            this.Text = "frmAttendanceTableByMonth";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttMonthView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridAttMonth;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAttMonthView;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.DateEdit dtpFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn EmpID;
        private DevExpress.XtraGrid.Columns.GridColumn EmpName;
        private DevExpress.XtraGrid.Columns.GridColumn Position;
        private DevExpress.XtraGrid.Columns.GridColumn Direct_Indirect;
        private DevExpress.XtraGrid.Columns.GridColumn LineID;
        private DevExpress.XtraGrid.Columns.GridColumn col01;
        private DevExpress.XtraGrid.Columns.GridColumn col02;
        private DevExpress.XtraGrid.Columns.GridColumn col03;
        private DevExpress.XtraGrid.Columns.GridColumn col04;
        private DevExpress.XtraGrid.Columns.GridColumn col05;
        private DevExpress.XtraGrid.Columns.GridColumn col06;
        private DevExpress.XtraGrid.Columns.GridColumn col07;
        private DevExpress.XtraGrid.Columns.GridColumn col08;
        private DevExpress.XtraGrid.Columns.GridColumn col09;
        private DevExpress.XtraGrid.Columns.GridColumn col10;
        private DevExpress.XtraGrid.Columns.GridColumn col11;
        private DevExpress.XtraGrid.Columns.GridColumn col12;
        private DevExpress.XtraGrid.Columns.GridColumn col13;
        private DevExpress.XtraGrid.Columns.GridColumn col14;
        private DevExpress.XtraGrid.Columns.GridColumn col15;
        private DevExpress.XtraGrid.Columns.GridColumn col16;
        private DevExpress.XtraGrid.Columns.GridColumn col17;
        private DevExpress.XtraGrid.Columns.GridColumn col18;
        private DevExpress.XtraGrid.Columns.GridColumn col19;
        private DevExpress.XtraGrid.Columns.GridColumn col20;
        private DevExpress.XtraGrid.Columns.GridColumn col21;
        private DevExpress.XtraGrid.Columns.GridColumn col22;
        private DevExpress.XtraGrid.Columns.GridColumn col23;
        private DevExpress.XtraGrid.Columns.GridColumn col24;
        private DevExpress.XtraGrid.Columns.GridColumn col25;
        private DevExpress.XtraGrid.Columns.GridColumn col26;
        private DevExpress.XtraGrid.Columns.GridColumn col27;
        private DevExpress.XtraGrid.Columns.GridColumn col28;
        private DevExpress.XtraGrid.Columns.GridColumn col29;
        private DevExpress.XtraGrid.Columns.GridColumn col30;
        private DevExpress.XtraGrid.Columns.GridColumn col31;
        private DevExpress.XtraEditors.SimpleButton btExport;
    }
}