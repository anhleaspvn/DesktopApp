namespace ASPProject.LineProdStatistic
{
    partial class frmIPQCInspec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIPQCInspec));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.gridIPQC = new DevExpress.XtraGrid.GridControl();
            this.gridIPQCView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInspDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeOfProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeOfSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIQCCheckName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcessNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSamplingSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPPM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQCID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIQCPeriodTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.isApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ApprovedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ApprovedDate = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridIPQC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIPQCView)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gridIPQC);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1191, 626);
            this.splitContainerControl1.SplitterPosition = 70;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(936, 20);
            this.btExport.Margin = new System.Windows.Forms.Padding(8);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(157, 30);
            this.btExport.TabIndex = 21;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(411, 32);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(97, 32);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(520, 27);
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
            this.dtToDate.TabIndex = 18;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(196, 27);
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
            this.dtFromDate.TabIndex = 17;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(787, 20);
            this.btFilter.Margin = new System.Windows.Forms.Padding(8);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(120, 30);
            this.btFilter.TabIndex = 16;
            this.btFilter.Text = "Lọc";
            // 
            // gridIPQC
            // 
            this.gridIPQC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIPQC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridIPQC.Location = new System.Drawing.Point(0, 0);
            this.gridIPQC.MainView = this.gridIPQCView;
            this.gridIPQC.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridIPQC.Name = "gridIPQC";
            this.gridIPQC.Size = new System.Drawing.Size(1191, 551);
            this.gridIPQC.TabIndex = 7;
            this.gridIPQC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridIPQCView});
            // 
            // gridIPQCView
            // 
            this.gridIPQCView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInspDate,
            this.colExtCode,
            this.colCustomerID,
            this.colTypeOfProduct,
            this.colTypeOfSX,
            this.colWODocNo,
            this.colProductID,
            this.colLineID,
            this.colIQCCheckName,
            this.colProcessNumber,
            this.colSamplingSize,
            this.colDefectQuantity,
            this.colDefectName,
            this.colPPM,
            this.colQCID,
            this.colInsType,
            this.colIQCPeriodTime,
            this.colIsLocked,
            this.isApproved,
            this.ApprovedBy,
            this.ApprovedDate});
            this.gridIPQCView.GridControl = this.gridIPQC;
            this.gridIPQCView.Name = "gridIPQCView";
            this.gridIPQCView.OptionsBehavior.Editable = false;
            this.gridIPQCView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridIPQCView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridIPQCView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridIPQCView.OptionsView.ShowAutoFilterRow = true;
            this.gridIPQCView.OptionsView.ShowGroupPanel = false;
            // 
            // colInspDate
            // 
            this.colInspDate.Caption = "Insp. Date";
            this.colInspDate.FieldName = "DocDate";
            this.colInspDate.MinWidth = 25;
            this.colInspDate.Name = "colInspDate";
            this.colInspDate.Visible = true;
            this.colInspDate.VisibleIndex = 0;
            this.colInspDate.Width = 94;
            // 
            // colExtCode
            // 
            this.colExtCode.Caption = "Ext. Code";
            this.colExtCode.FieldName = "ExtCode";
            this.colExtCode.MinWidth = 25;
            this.colExtCode.Name = "colExtCode";
            this.colExtCode.Visible = true;
            this.colExtCode.VisibleIndex = 1;
            this.colExtCode.Width = 94;
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Customer";
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.MinWidth = 25;
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 2;
            this.colCustomerID.Width = 94;
            // 
            // colTypeOfProduct
            // 
            this.colTypeOfProduct.Caption = "Type Of Product";
            this.colTypeOfProduct.FieldName = "TypeOfProduct";
            this.colTypeOfProduct.MinWidth = 25;
            this.colTypeOfProduct.Name = "colTypeOfProduct";
            this.colTypeOfProduct.Visible = true;
            this.colTypeOfProduct.VisibleIndex = 3;
            this.colTypeOfProduct.Width = 94;
            // 
            // colTypeOfSX
            // 
            this.colTypeOfSX.Caption = "Pro. Period";
            this.colTypeOfSX.FieldName = "TypeOfSX";
            this.colTypeOfSX.MinWidth = 25;
            this.colTypeOfSX.Name = "colTypeOfSX";
            this.colTypeOfSX.Visible = true;
            this.colTypeOfSX.VisibleIndex = 4;
            this.colTypeOfSX.Width = 94;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Work Order";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 5;
            this.colWODocNo.Width = 94;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Product";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 25;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 6;
            this.colProductID.Width = 94;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 25;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 7;
            this.colLineID.Width = 94;
            // 
            // colIQCCheckName
            // 
            this.colIQCCheckName.Caption = "Process Name";
            this.colIQCCheckName.FieldName = "IQCCheckName";
            this.colIQCCheckName.MinWidth = 25;
            this.colIQCCheckName.Name = "colIQCCheckName";
            this.colIQCCheckName.Visible = true;
            this.colIQCCheckName.VisibleIndex = 8;
            this.colIQCCheckName.Width = 94;
            // 
            // colProcessNumber
            // 
            this.colProcessNumber.Caption = "Process Number";
            this.colProcessNumber.FieldName = "IQCCheckID";
            this.colProcessNumber.MinWidth = 25;
            this.colProcessNumber.Name = "colProcessNumber";
            this.colProcessNumber.Visible = true;
            this.colProcessNumber.VisibleIndex = 9;
            this.colProcessNumber.Width = 94;
            // 
            // colSamplingSize
            // 
            this.colSamplingSize.Caption = "Sampling Size";
            this.colSamplingSize.FieldName = "IQCTemplateQuantity";
            this.colSamplingSize.MinWidth = 25;
            this.colSamplingSize.Name = "colSamplingSize";
            this.colSamplingSize.Visible = true;
            this.colSamplingSize.VisibleIndex = 10;
            this.colSamplingSize.Width = 94;
            // 
            // colDefectQuantity
            // 
            this.colDefectQuantity.Caption = "NG Q\'ty";
            this.colDefectQuantity.FieldName = "DefectQuantity";
            this.colDefectQuantity.MinWidth = 25;
            this.colDefectQuantity.Name = "colDefectQuantity";
            this.colDefectQuantity.Visible = true;
            this.colDefectQuantity.VisibleIndex = 11;
            this.colDefectQuantity.Width = 94;
            // 
            // colDefectName
            // 
            this.colDefectName.Caption = "Defect Name";
            this.colDefectName.FieldName = "DefectName";
            this.colDefectName.MinWidth = 25;
            this.colDefectName.Name = "colDefectName";
            this.colDefectName.Visible = true;
            this.colDefectName.VisibleIndex = 12;
            this.colDefectName.Width = 94;
            // 
            // colPPM
            // 
            this.colPPM.Caption = "PPM";
            this.colPPM.FieldName = "PPM";
            this.colPPM.MinWidth = 25;
            this.colPPM.Name = "colPPM";
            this.colPPM.Visible = true;
            this.colPPM.VisibleIndex = 13;
            this.colPPM.Width = 94;
            // 
            // colQCID
            // 
            this.colQCID.Caption = "ID";
            this.colQCID.FieldName = "QCID";
            this.colQCID.MinWidth = 25;
            this.colQCID.Name = "colQCID";
            this.colQCID.Visible = true;
            this.colQCID.VisibleIndex = 14;
            this.colQCID.Width = 94;
            // 
            // colInsType
            // 
            this.colInsType.Caption = "Inspection Type";
            this.colInsType.FieldName = "CheckState";
            this.colInsType.MinWidth = 25;
            this.colInsType.Name = "colInsType";
            this.colInsType.Visible = true;
            this.colInsType.VisibleIndex = 15;
            this.colInsType.Width = 94;
            // 
            // colIQCPeriodTime
            // 
            this.colIQCPeriodTime.Caption = "Inspection Time";
            this.colIQCPeriodTime.FieldName = "IQCPeriodTime";
            this.colIQCPeriodTime.MinWidth = 25;
            this.colIQCPeriodTime.Name = "colIQCPeriodTime";
            this.colIQCPeriodTime.Visible = true;
            this.colIQCPeriodTime.VisibleIndex = 16;
            this.colIQCPeriodTime.Width = 94;
            // 
            // colIsLocked
            // 
            this.colIsLocked.Caption = "Khoá";
            this.colIsLocked.FieldName = "isLocked";
            this.colIsLocked.MinWidth = 25;
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.Visible = true;
            this.colIsLocked.VisibleIndex = 17;
            this.colIsLocked.Width = 94;
            // 
            // isApproved
            // 
            this.isApproved.Caption = "Approved";
            this.isApproved.FieldName = "isApproved";
            this.isApproved.MinWidth = 25;
            this.isApproved.Name = "isApproved";
            this.isApproved.Visible = true;
            this.isApproved.VisibleIndex = 18;
            this.isApproved.Width = 94;
            // 
            // ApprovedBy
            // 
            this.ApprovedBy.Caption = "Approved By";
            this.ApprovedBy.FieldName = "ApprovedBy";
            this.ApprovedBy.MinWidth = 25;
            this.ApprovedBy.Name = "ApprovedBy";
            this.ApprovedBy.Visible = true;
            this.ApprovedBy.VisibleIndex = 19;
            this.ApprovedBy.Width = 94;
            // 
            // ApprovedDate
            // 
            this.ApprovedDate.Caption = "Approved Date";
            this.ApprovedDate.FieldName = "ApprovedDate";
            this.ApprovedDate.MinWidth = 25;
            this.ApprovedDate.Name = "ApprovedDate";
            this.ApprovedDate.Visible = true;
            this.ApprovedDate.VisibleIndex = 20;
            this.ApprovedDate.Width = 94;
            // 
            // frmIPQCInspec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 626);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIPQCInspec";
            this.Text = "frmIPQCInspec";
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
            ((System.ComponentModel.ISupportInitialize)(this.gridIPQC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIPQCView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridIPQC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridIPQCView;
        private DevExpress.XtraGrid.Columns.GridColumn colInspDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeOfProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeOfSX;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCCheckName;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSamplingSize;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectName;
        private DevExpress.XtraGrid.Columns.GridColumn colPPM;
        private DevExpress.XtraGrid.Columns.GridColumn colQCID;
        private DevExpress.XtraGrid.Columns.GridColumn colInsType;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCPeriodTime;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLocked;
        private DevExpress.XtraGrid.Columns.GridColumn isApproved;
        private DevExpress.XtraGrid.Columns.GridColumn ApprovedBy;
        private DevExpress.XtraGrid.Columns.GridColumn ApprovedDate;
    }
}