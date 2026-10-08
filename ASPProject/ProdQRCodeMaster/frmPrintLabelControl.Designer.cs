namespace ASPProject.ProdQRCodeMaster
{
    partial class frmPrintLabelControl
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
        /// Required method for Designer - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtWODocNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtProductID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtBoxID = new DevExpress.XtraEditors.TextEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.btExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystemQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrintedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscrepancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlDetail = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetSerialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetLabelType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetBoxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetNGDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWODocNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetail)).BeginInit();
            this.groupControlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dtFromDate);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dtToDate);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtWODocNo);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtProductID);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtBoxID);
            this.panelControl1.Controls.Add(this.btFilter);
            this.panelControl1.Controls.Add(this.btExportExcel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1400, 80);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 28);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(68, 25);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(128, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(210, 28);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(272, 25);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(128, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(414, 28);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "W.O";
            // 
            // txtWODocNo
            // 
            this.txtWODocNo.Location = new System.Drawing.Point(449, 25);
            this.txtWODocNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWODocNo.Name = "txtWODocNo";
            this.txtWODocNo.Size = new System.Drawing.Size(152, 23);
            this.txtWODocNo.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(618, 28);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Mã sản phẩm";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(700, 25);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(140, 23);
            this.txtProductID.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(858, 28);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "BOX";
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(892, 25);
            this.txtBoxID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(117, 23);
            this.txtBoxID.TabIndex = 9;
            // 
            // btFilter
            // 
            this.btFilter.Location = new System.Drawing.Point(1032, 22);
            this.btFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(99, 28);
            this.btFilter.TabIndex = 10;
            this.btFilter.Text = "Tìm kiếm";
            // 
            // btExportExcel
            // 
            this.btExportExcel.Location = new System.Drawing.Point(1143, 22);
            this.btExportExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btExportExcel.Name = "btExportExcel";
            this.btExportExcel.Size = new System.Drawing.Size(99, 28);
            this.btExportExcel.TabIndex = 11;
            this.btExportExcel.Text = "Xuất Excel";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 80);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1400, 782);
            this.splitContainerControl1.SplitterPosition = 320;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1400, 320);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocDate,
            this.colWODocNo,
            this.colProductID,
            this.colBoxID,
            this.colPassQty,
            this.colNGQty,
            this.colSystemQty,
            this.colPrintedQty,
            this.colDiscrepancy,
            this.colStatus});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "Ngày";
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.MinWidth = 23;
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.OptionsColumn.AllowEdit = false;
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 0;
            this.colDocDate.Width = 117;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 23;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.OptionsColumn.AllowEdit = false;
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 1;
            this.colWODocNo.Width = 175;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 23;
            this.colProductID.Name = "colProductID";
            this.colProductID.OptionsColumn.AllowEdit = false;
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 2;
            this.colProductID.Width = 175;
            // 
            // colBoxID
            // 
            this.colBoxID.Caption = "Hộp (BOX)";
            this.colBoxID.FieldName = "BoxID";
            this.colBoxID.MinWidth = 23;
            this.colBoxID.Name = "colBoxID";
            this.colBoxID.OptionsColumn.AllowEdit = false;
            this.colBoxID.Visible = true;
            this.colBoxID.VisibleIndex = 3;
            this.colBoxID.Width = 117;
            // 
            // colPassQty
            // 
            this.colPassQty.Caption = "Số lượng Pass";
            this.colPassQty.FieldName = "PassQty";
            this.colPassQty.MinWidth = 23;
            this.colPassQty.Name = "colPassQty";
            this.colPassQty.OptionsColumn.AllowEdit = false;
            this.colPassQty.Visible = true;
            this.colPassQty.VisibleIndex = 4;
            this.colPassQty.Width = 117;
            // 
            // colNGQty
            // 
            this.colNGQty.Caption = "Số lượng NG";
            this.colNGQty.FieldName = "NGQty";
            this.colNGQty.MinWidth = 23;
            this.colNGQty.Name = "colNGQty";
            this.colNGQty.OptionsColumn.AllowEdit = false;
            this.colNGQty.Visible = true;
            this.colNGQty.VisibleIndex = 5;
            this.colNGQty.Width = 117;
            // 
            // colSystemQty
            // 
            this.colSystemQty.Caption = "Số lượng hệ thống";
            this.colSystemQty.FieldName = "SystemQty";
            this.colSystemQty.MinWidth = 23;
            this.colSystemQty.Name = "colSystemQty";
            this.colSystemQty.OptionsColumn.AllowEdit = false;
            this.colSystemQty.Visible = true;
            this.colSystemQty.VisibleIndex = 6;
            this.colSystemQty.Width = 140;
            // 
            // colPrintedQty
            // 
            this.colPrintedQty.Caption = "Số lượng tem in";
            this.colPrintedQty.FieldName = "PrintedQty";
            this.colPrintedQty.MinWidth = 23;
            this.colPrintedQty.Name = "colPrintedQty";
            this.colPrintedQty.Visible = true;
            this.colPrintedQty.VisibleIndex = 7;
            this.colPrintedQty.Width = 140;
            // 
            // colDiscrepancy
            // 
            this.colDiscrepancy.Caption = "Chênh lệch";
            this.colDiscrepancy.FieldName = "Discrepancy";
            this.colDiscrepancy.MinWidth = 23;
            this.colDiscrepancy.Name = "colDiscrepancy";
            this.colDiscrepancy.OptionsColumn.AllowEdit = false;
            this.colDiscrepancy.Visible = true;
            this.colDiscrepancy.VisibleIndex = 8;
            this.colDiscrepancy.Width = 117;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.FieldName = "Status";
            this.colStatus.MinWidth = 23;
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 117;
            // 
            // groupControlDetail
            // 
            this.groupControlDetail.Controls.Add(this.gridControlDetail);
            this.groupControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDetail.Location = new System.Drawing.Point(0, 0);
            this.groupControlDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControlDetail.Name = "groupControlDetail";
            this.groupControlDetail.Size = new System.Drawing.Size(1400, 455);
            this.groupControlDetail.TabIndex = 0;
            this.groupControlDetail.Text = "Chi tiết tem in theo dòng được chọn";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlDetail.Location = new System.Drawing.Point(2, 27);
            this.gridControlDetail.MainView = this.gridViewDetail;
            this.gridControlDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(1396, 426);
            this.gridControlDetail.TabIndex = 0;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetSerialCode,
            this.colDetLabelType,
            this.colDetBoxID,
            this.colDetCreatedDate,
            this.colDetNGDescription});
            this.gridViewDetail.DetailHeight = 431;
            this.gridViewDetail.GridControl = this.gridControlDetail;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsBehavior.Editable = false;
            this.gridViewDetail.OptionsView.ShowAutoFilterRow = true;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colDetSerialCode
            // 
            this.colDetSerialCode.Caption = "Mã tem (Serial Code)";
            this.colDetSerialCode.FieldName = "SerialCode";
            this.colDetSerialCode.MinWidth = 23;
            this.colDetSerialCode.Name = "colDetSerialCode";
            this.colDetSerialCode.Visible = true;
            this.colDetSerialCode.VisibleIndex = 0;
            this.colDetSerialCode.Width = 292;
            // 
            // colDetLabelType
            // 
            this.colDetLabelType.Caption = "Loại tem";
            this.colDetLabelType.FieldName = "LabelType";
            this.colDetLabelType.MinWidth = 23;
            this.colDetLabelType.Name = "colDetLabelType";
            this.colDetLabelType.Visible = true;
            this.colDetLabelType.VisibleIndex = 1;
            this.colDetLabelType.Width = 117;
            // 
            // colDetBoxID
            // 
            this.colDetBoxID.Caption = "Hộp (BOX)";
            this.colDetBoxID.FieldName = "BoxID";
            this.colDetBoxID.MinWidth = 23;
            this.colDetBoxID.Name = "colDetBoxID";
            this.colDetBoxID.Visible = true;
            this.colDetBoxID.VisibleIndex = 2;
            this.colDetBoxID.Width = 175;
            // 
            // colDetCreatedDate
            // 
            this.colDetCreatedDate.Caption = "Thời gian ghi nhận";
            this.colDetCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colDetCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDetCreatedDate.FieldName = "CreatedDate";
            this.colDetCreatedDate.MinWidth = 23;
            this.colDetCreatedDate.Name = "colDetCreatedDate";
            this.colDetCreatedDate.Visible = true;
            this.colDetCreatedDate.VisibleIndex = 3;
            this.colDetCreatedDate.Width = 233;
            // 
            // colDetNGDescription
            // 
            this.colDetNGDescription.Caption = "Mô tả lỗi (NG Description)";
            this.colDetNGDescription.FieldName = "NGDescription";
            this.colDetNGDescription.MinWidth = 23;
            this.colDetNGDescription.Name = "colDetNGDescription";
            this.colDetNGDescription.Visible = true;
            this.colDetNGDescription.VisibleIndex = 4;
            this.colDetNGDescription.Width = 408;
            // 
            // frmPrintLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 862);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPrintLabelControl";
            this.Text = "Kiểm soát in tem";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWODocNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetail)).EndInit();
            this.groupControlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtWODocNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtProductID;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtBoxID;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.SimpleButton btExportExcel;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colBoxID;
        private DevExpress.XtraGrid.Columns.GridColumn colPassQty;
        private DevExpress.XtraGrid.Columns.GridColumn colNGQty;
        private DevExpress.XtraGrid.Columns.GridColumn colSystemQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPrintedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscrepancy;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.GroupControl groupControlDetail;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDetSerialCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDetLabelType;
        private DevExpress.XtraGrid.Columns.GridColumn colDetBoxID;
        private DevExpress.XtraGrid.Columns.GridColumn colDetCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDetNGDescription;
    }
}
