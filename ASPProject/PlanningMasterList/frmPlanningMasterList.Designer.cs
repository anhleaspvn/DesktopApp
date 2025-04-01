namespace ASPProject.PlaningMasterList
{
    partial class frmPlanningMasterList
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btImportDay = new DevExpress.XtraEditors.SimpleButton();
            this.btImportMonth = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridPlanByMonth = new DevExpress.XtraGrid.GridControl();
            this.gridPlanByMonthView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Month = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFGsPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPsPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPlanByDay = new DevExpress.XtraGrid.GridControl();
            this.gridPlanByDayView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col9 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByMonthView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByDayView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btImportDay);
            this.panelControl1.Controls.Add(this.btImportMonth);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1162, 83);
            this.panelControl1.TabIndex = 0;
            // 
            // btImportDay
            // 
            this.btImportDay.ImageOptions.Image = global::ASPProject.Properties.Resources.plus;
            this.btImportDay.Location = new System.Drawing.Point(939, 6);
            this.btImportDay.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btImportDay.Name = "btImportDay";
            this.btImportDay.Size = new System.Drawing.Size(161, 34);
            this.btImportDay.TabIndex = 9;
            this.btImportDay.Text = "Import theo ngày";
            // 
            // btImportMonth
            // 
            this.btImportMonth.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btImportMonth.Location = new System.Drawing.Point(54, 6);
            this.btImportMonth.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btImportMonth.Name = "btImportMonth";
            this.btImportMonth.Size = new System.Drawing.Size(161, 34);
            this.btImportMonth.TabIndex = 8;
            this.btImportMonth.Text = "Import theo tháng";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 83);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gridPlanByMonth);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridPlanByDay);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1162, 616);
            this.splitContainerControl1.SplitterPosition = 414;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // gridPlanByMonth
            // 
            this.gridPlanByMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlanByMonth.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridPlanByMonth.Location = new System.Drawing.Point(0, 0);
            this.gridPlanByMonth.MainView = this.gridPlanByMonthView;
            this.gridPlanByMonth.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridPlanByMonth.Name = "gridPlanByMonth";
            this.gridPlanByMonth.Size = new System.Drawing.Size(414, 616);
            this.gridPlanByMonth.TabIndex = 6;
            this.gridPlanByMonth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPlanByMonthView});
            // 
            // gridPlanByMonthView
            // 
            this.gridPlanByMonthView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Year,
            this.Month,
            this.colLineID,
            this.colFGsPlan,
            this.colMPsPlan});
            this.gridPlanByMonthView.GridControl = this.gridPlanByMonth;
            this.gridPlanByMonthView.Name = "gridPlanByMonthView";
            this.gridPlanByMonthView.OptionsBehavior.Editable = false;
            this.gridPlanByMonthView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridPlanByMonthView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridPlanByMonthView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridPlanByMonthView.OptionsView.RowAutoHeight = true;
            this.gridPlanByMonthView.OptionsView.ShowAutoFilterRow = true;
            this.gridPlanByMonthView.OptionsView.ShowGroupPanel = false;
            // 
            // Year
            // 
            this.Year.Caption = "Năm";
            this.Year.FieldName = "Year";
            this.Year.MinWidth = 23;
            this.Year.Name = "Year";
            this.Year.Visible = true;
            this.Year.VisibleIndex = 0;
            this.Year.Width = 87;
            // 
            // Month
            // 
            this.Month.Caption = "Tháng";
            this.Month.FieldName = "Month";
            this.Month.MinWidth = 23;
            this.Month.Name = "Month";
            this.Month.Visible = true;
            this.Month.VisibleIndex = 1;
            this.Month.Width = 87;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Mã Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 23;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 2;
            this.colLineID.Width = 87;
            // 
            // colFGsPlan
            // 
            this.colFGsPlan.Caption = "FGs";
            this.colFGsPlan.DisplayFormat.FormatString = "#0.00";
            this.colFGsPlan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFGsPlan.FieldName = "FGsPlan";
            this.colFGsPlan.MinWidth = 23;
            this.colFGsPlan.Name = "colFGsPlan";
            this.colFGsPlan.Visible = true;
            this.colFGsPlan.VisibleIndex = 3;
            this.colFGsPlan.Width = 87;
            // 
            // colMPsPlan
            // 
            this.colMPsPlan.Caption = "MPs";
            this.colMPsPlan.DisplayFormat.FormatString = "#0.00";
            this.colMPsPlan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMPsPlan.FieldName = "MPsPlan";
            this.colMPsPlan.MinWidth = 23;
            this.colMPsPlan.Name = "colMPsPlan";
            this.colMPsPlan.Visible = true;
            this.colMPsPlan.VisibleIndex = 4;
            this.colMPsPlan.Width = 87;
            // 
            // gridPlanByDay
            // 
            this.gridPlanByDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlanByDay.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridPlanByDay.Location = new System.Drawing.Point(0, 0);
            this.gridPlanByDay.MainView = this.gridPlanByDayView;
            this.gridPlanByDay.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridPlanByDay.Name = "gridPlanByDay";
            this.gridPlanByDay.Size = new System.Drawing.Size(741, 616);
            this.gridPlanByDay.TabIndex = 7;
            this.gridPlanByDay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPlanByDayView});
            // 
            // gridPlanByDayView
            // 
            this.gridPlanByDayView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colYear,
            this.colMonth,
            this.colWODocNo,
            this.colProductID,
            this.LineID,
            this.colORDG,
            this.colORVN,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8,
            this.col9,
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
            this.gridPlanByDayView.GridControl = this.gridPlanByDay;
            this.gridPlanByDayView.Name = "gridPlanByDayView";
            this.gridPlanByDayView.OptionsBehavior.Editable = false;
            this.gridPlanByDayView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridPlanByDayView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridPlanByDayView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridPlanByDayView.OptionsView.ColumnAutoWidth = false;
            this.gridPlanByDayView.OptionsView.RowAutoHeight = true;
            this.gridPlanByDayView.OptionsView.ShowAutoFilterRow = true;
            this.gridPlanByDayView.OptionsView.ShowGroupPanel = false;
            // 
            // colYear
            // 
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.MinWidth = 23;
            this.colYear.Name = "colYear";
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 0;
            this.colYear.Width = 87;
            // 
            // colMonth
            // 
            this.colMonth.Caption = "Tháng";
            this.colMonth.FieldName = "Month";
            this.colMonth.MinWidth = 23;
            this.colMonth.Name = "colMonth";
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 1;
            this.colMonth.Width = 87;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 23;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 2;
            this.colWODocNo.Width = 87;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 23;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 3;
            this.colProductID.Width = 87;
            // 
            // LineID
            // 
            this.LineID.Caption = "Mã Line";
            this.LineID.FieldName = "LineID";
            this.LineID.MinWidth = 23;
            this.LineID.Name = "LineID";
            this.LineID.Visible = true;
            this.LineID.VisibleIndex = 4;
            this.LineID.Width = 87;
            // 
            // colORDG
            // 
            this.colORDG.Caption = "OR DG";
            this.colORDG.DisplayFormat.FormatString = "#0.00";
            this.colORDG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colORDG.FieldName = "ORDG";
            this.colORDG.MinWidth = 23;
            this.colORDG.Name = "colORDG";
            this.colORDG.Visible = true;
            this.colORDG.VisibleIndex = 5;
            this.colORDG.Width = 87;
            // 
            // colORVN
            // 
            this.colORVN.Caption = "OR VN";
            this.colORVN.DisplayFormat.FormatString = "#0.00";
            this.colORVN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colORVN.FieldName = "ORVN";
            this.colORVN.MinWidth = 23;
            this.colORVN.Name = "colORVN";
            this.colORVN.Visible = true;
            this.colORVN.VisibleIndex = 6;
            this.colORVN.Width = 87;
            // 
            // col1
            // 
            this.col1.Caption = "1";
            this.col1.DisplayFormat.FormatString = "#0.00";
            this.col1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col1.FieldName = "1";
            this.col1.MinWidth = 23;
            this.col1.Name = "col1";
            this.col1.Visible = true;
            this.col1.VisibleIndex = 7;
            this.col1.Width = 87;
            // 
            // col2
            // 
            this.col2.Caption = "2";
            this.col2.DisplayFormat.FormatString = "#0.00";
            this.col2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col2.FieldName = "2";
            this.col2.MinWidth = 23;
            this.col2.Name = "col2";
            this.col2.Visible = true;
            this.col2.VisibleIndex = 8;
            this.col2.Width = 87;
            // 
            // col3
            // 
            this.col3.Caption = "3";
            this.col3.DisplayFormat.FormatString = "#0.00";
            this.col3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col3.FieldName = "3";
            this.col3.MinWidth = 23;
            this.col3.Name = "col3";
            this.col3.Visible = true;
            this.col3.VisibleIndex = 9;
            this.col3.Width = 87;
            // 
            // col4
            // 
            this.col4.Caption = "4";
            this.col4.DisplayFormat.FormatString = "#0.00";
            this.col4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col4.FieldName = "4";
            this.col4.MinWidth = 23;
            this.col4.Name = "col4";
            this.col4.Visible = true;
            this.col4.VisibleIndex = 10;
            this.col4.Width = 87;
            // 
            // col5
            // 
            this.col5.Caption = "5";
            this.col5.DisplayFormat.FormatString = "#0.00";
            this.col5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col5.FieldName = "5";
            this.col5.MinWidth = 23;
            this.col5.Name = "col5";
            this.col5.Visible = true;
            this.col5.VisibleIndex = 11;
            this.col5.Width = 87;
            // 
            // col6
            // 
            this.col6.Caption = "6";
            this.col6.DisplayFormat.FormatString = "#0.00";
            this.col6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col6.FieldName = "6";
            this.col6.MinWidth = 23;
            this.col6.Name = "col6";
            this.col6.Visible = true;
            this.col6.VisibleIndex = 12;
            this.col6.Width = 87;
            // 
            // col7
            // 
            this.col7.Caption = "7";
            this.col7.DisplayFormat.FormatString = "#0.00";
            this.col7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col7.FieldName = "7";
            this.col7.MinWidth = 23;
            this.col7.Name = "col7";
            this.col7.Visible = true;
            this.col7.VisibleIndex = 13;
            this.col7.Width = 87;
            // 
            // col8
            // 
            this.col8.Caption = "8";
            this.col8.DisplayFormat.FormatString = "#0.00";
            this.col8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col8.FieldName = "8";
            this.col8.MinWidth = 23;
            this.col8.Name = "col8";
            this.col8.Visible = true;
            this.col8.VisibleIndex = 14;
            this.col8.Width = 87;
            // 
            // col9
            // 
            this.col9.Caption = "9";
            this.col9.DisplayFormat.FormatString = "#0.00";
            this.col9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col9.FieldName = "9";
            this.col9.MinWidth = 23;
            this.col9.Name = "col9";
            this.col9.Visible = true;
            this.col9.VisibleIndex = 15;
            this.col9.Width = 87;
            // 
            // col10
            // 
            this.col10.Caption = "10";
            this.col10.DisplayFormat.FormatString = "#0.00";
            this.col10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col10.FieldName = "10";
            this.col10.MinWidth = 23;
            this.col10.Name = "col10";
            this.col10.Visible = true;
            this.col10.VisibleIndex = 16;
            this.col10.Width = 87;
            // 
            // col11
            // 
            this.col11.Caption = "11";
            this.col11.DisplayFormat.FormatString = "#0.00";
            this.col11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col11.FieldName = "11";
            this.col11.MinWidth = 23;
            this.col11.Name = "col11";
            this.col11.Visible = true;
            this.col11.VisibleIndex = 17;
            this.col11.Width = 87;
            // 
            // col12
            // 
            this.col12.Caption = "12";
            this.col12.DisplayFormat.FormatString = "#0.00";
            this.col12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col12.FieldName = "12";
            this.col12.MinWidth = 23;
            this.col12.Name = "col12";
            this.col12.Visible = true;
            this.col12.VisibleIndex = 18;
            this.col12.Width = 87;
            // 
            // col13
            // 
            this.col13.Caption = "13";
            this.col13.DisplayFormat.FormatString = "#0.00";
            this.col13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col13.FieldName = "13";
            this.col13.MinWidth = 23;
            this.col13.Name = "col13";
            this.col13.Visible = true;
            this.col13.VisibleIndex = 19;
            this.col13.Width = 87;
            // 
            // col14
            // 
            this.col14.Caption = "14";
            this.col14.DisplayFormat.FormatString = "#0.00";
            this.col14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col14.FieldName = "14";
            this.col14.MinWidth = 23;
            this.col14.Name = "col14";
            this.col14.Visible = true;
            this.col14.VisibleIndex = 20;
            this.col14.Width = 87;
            // 
            // col15
            // 
            this.col15.Caption = "15";
            this.col15.DisplayFormat.FormatString = "#0.00";
            this.col15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col15.FieldName = "15";
            this.col15.MinWidth = 23;
            this.col15.Name = "col15";
            this.col15.Visible = true;
            this.col15.VisibleIndex = 21;
            this.col15.Width = 87;
            // 
            // col16
            // 
            this.col16.Caption = "16";
            this.col16.DisplayFormat.FormatString = "#0.00";
            this.col16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col16.FieldName = "16";
            this.col16.MinWidth = 23;
            this.col16.Name = "col16";
            this.col16.Visible = true;
            this.col16.VisibleIndex = 22;
            this.col16.Width = 87;
            // 
            // col17
            // 
            this.col17.Caption = "17";
            this.col17.DisplayFormat.FormatString = "#0.00";
            this.col17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col17.FieldName = "17";
            this.col17.MinWidth = 23;
            this.col17.Name = "col17";
            this.col17.Visible = true;
            this.col17.VisibleIndex = 23;
            this.col17.Width = 87;
            // 
            // col18
            // 
            this.col18.Caption = "18";
            this.col18.DisplayFormat.FormatString = "#0.00";
            this.col18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col18.FieldName = "18";
            this.col18.MinWidth = 23;
            this.col18.Name = "col18";
            this.col18.Visible = true;
            this.col18.VisibleIndex = 24;
            this.col18.Width = 87;
            // 
            // col19
            // 
            this.col19.Caption = "19";
            this.col19.DisplayFormat.FormatString = "#0.00";
            this.col19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col19.FieldName = "19";
            this.col19.MinWidth = 23;
            this.col19.Name = "col19";
            this.col19.Visible = true;
            this.col19.VisibleIndex = 25;
            this.col19.Width = 87;
            // 
            // col20
            // 
            this.col20.Caption = "20";
            this.col20.DisplayFormat.FormatString = "#0.00";
            this.col20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col20.FieldName = "20";
            this.col20.MinWidth = 23;
            this.col20.Name = "col20";
            this.col20.Visible = true;
            this.col20.VisibleIndex = 26;
            this.col20.Width = 87;
            // 
            // col21
            // 
            this.col21.Caption = "21";
            this.col21.DisplayFormat.FormatString = "#0.00";
            this.col21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col21.FieldName = "21";
            this.col21.MinWidth = 23;
            this.col21.Name = "col21";
            this.col21.Visible = true;
            this.col21.VisibleIndex = 27;
            this.col21.Width = 87;
            // 
            // col22
            // 
            this.col22.Caption = "22";
            this.col22.DisplayFormat.FormatString = "#0.00";
            this.col22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col22.FieldName = "22";
            this.col22.MinWidth = 23;
            this.col22.Name = "col22";
            this.col22.Visible = true;
            this.col22.VisibleIndex = 28;
            this.col22.Width = 87;
            // 
            // col23
            // 
            this.col23.Caption = "23";
            this.col23.DisplayFormat.FormatString = "#0.00";
            this.col23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col23.FieldName = "23";
            this.col23.MinWidth = 23;
            this.col23.Name = "col23";
            this.col23.Visible = true;
            this.col23.VisibleIndex = 29;
            this.col23.Width = 87;
            // 
            // col24
            // 
            this.col24.Caption = "24";
            this.col24.DisplayFormat.FormatString = "#0.00";
            this.col24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col24.FieldName = "24";
            this.col24.MinWidth = 23;
            this.col24.Name = "col24";
            this.col24.Visible = true;
            this.col24.VisibleIndex = 30;
            this.col24.Width = 87;
            // 
            // col25
            // 
            this.col25.Caption = "25";
            this.col25.DisplayFormat.FormatString = "#0.00";
            this.col25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col25.FieldName = "25";
            this.col25.MinWidth = 23;
            this.col25.Name = "col25";
            this.col25.Visible = true;
            this.col25.VisibleIndex = 31;
            this.col25.Width = 87;
            // 
            // col26
            // 
            this.col26.Caption = "26";
            this.col26.DisplayFormat.FormatString = "#0.00";
            this.col26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col26.FieldName = "26";
            this.col26.MinWidth = 23;
            this.col26.Name = "col26";
            this.col26.Visible = true;
            this.col26.VisibleIndex = 32;
            this.col26.Width = 87;
            // 
            // col27
            // 
            this.col27.Caption = "27";
            this.col27.DisplayFormat.FormatString = "#0.00";
            this.col27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col27.FieldName = "27";
            this.col27.MinWidth = 23;
            this.col27.Name = "col27";
            this.col27.Visible = true;
            this.col27.VisibleIndex = 33;
            this.col27.Width = 87;
            // 
            // col28
            // 
            this.col28.Caption = "28";
            this.col28.DisplayFormat.FormatString = "#0.00";
            this.col28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col28.FieldName = "28";
            this.col28.MinWidth = 23;
            this.col28.Name = "col28";
            this.col28.Visible = true;
            this.col28.VisibleIndex = 34;
            this.col28.Width = 87;
            // 
            // col29
            // 
            this.col29.Caption = "29";
            this.col29.DisplayFormat.FormatString = "#0.00";
            this.col29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col29.FieldName = "29";
            this.col29.MinWidth = 23;
            this.col29.Name = "col29";
            this.col29.Visible = true;
            this.col29.VisibleIndex = 35;
            this.col29.Width = 87;
            // 
            // col30
            // 
            this.col30.Caption = "30";
            this.col30.DisplayFormat.FormatString = "#0.00";
            this.col30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col30.FieldName = "30";
            this.col30.MinWidth = 23;
            this.col30.Name = "col30";
            this.col30.Visible = true;
            this.col30.VisibleIndex = 36;
            this.col30.Width = 87;
            // 
            // col31
            // 
            this.col31.Caption = "31";
            this.col31.DisplayFormat.FormatString = "#0.00";
            this.col31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col31.FieldName = "31";
            this.col31.MinWidth = 23;
            this.col31.Name = "col31";
            this.col31.Visible = true;
            this.col31.VisibleIndex = 37;
            this.col31.Width = 87;
            // 
            // frmPlanningMasterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 699);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPlanningMasterList";
            this.Text = "frmPlanningMasterList";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByMonthView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanByDayView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridPlanByMonth;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPlanByMonthView;
        private DevExpress.XtraGrid.GridControl gridPlanByDay;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPlanByDayView;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colFGsPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colMPsPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn LineID;
        private DevExpress.XtraGrid.Columns.GridColumn colORDG;
        private DevExpress.XtraGrid.Columns.GridColumn colORVN;
        private DevExpress.XtraGrid.Columns.GridColumn col1;
        private DevExpress.XtraGrid.Columns.GridColumn col2;
        private DevExpress.XtraGrid.Columns.GridColumn col3;
        private DevExpress.XtraGrid.Columns.GridColumn col4;
        private DevExpress.XtraGrid.Columns.GridColumn col5;
        private DevExpress.XtraGrid.Columns.GridColumn col6;
        private DevExpress.XtraGrid.Columns.GridColumn col7;
        private DevExpress.XtraGrid.Columns.GridColumn col8;
        private DevExpress.XtraGrid.Columns.GridColumn col9;
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
        private DevExpress.XtraEditors.SimpleButton btImportDay;
        private DevExpress.XtraEditors.SimpleButton btImportMonth;
        private DevExpress.XtraGrid.Columns.GridColumn Year;
        private DevExpress.XtraGrid.Columns.GridColumn Month;
    }
}