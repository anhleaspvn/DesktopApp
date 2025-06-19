namespace ASPProject.ScanBarCodeBin
{
    partial class frmBinLineQCApproval
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtQRQuantity = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtQRContent = new System.Windows.Forms.TextBox();
            this.gridBinLineQCApproval = new DevExpress.XtraGrid.GridControl();
            this.gridBinLineQCApprovalView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrintDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductIDVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQRCodeVerify = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQRCodeData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerVerify = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQCVerify = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrintUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinkQQuantityPerBin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBinSize = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBinLineQCApproval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBinLineQCApprovalView)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtQRQuantity);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtQRContent);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridBinLineQCApproval);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1361, 774);
            this.splitContainerControl1.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(487, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(156, 18);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "QR CODE SỐ LƯỢNG";
            // 
            // txtQRQuantity
            // 
            this.txtQRQuantity.BackColor = System.Drawing.Color.Cyan;
            this.txtQRQuantity.Location = new System.Drawing.Point(481, 52);
            this.txtQRQuantity.MaximumSize = new System.Drawing.Size(500, 50);
            this.txtQRQuantity.MinimumSize = new System.Drawing.Size(100, 30);
            this.txtQRQuantity.Name = "txtQRQuantity";
            this.txtQRQuantity.Size = new System.Drawing.Size(300, 23);
            this.txtQRQuantity.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(37, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(153, 18);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "QR CODE NỘI DUNG";
            // 
            // txtQRContent
            // 
            this.txtQRContent.BackColor = System.Drawing.Color.Cyan;
            this.txtQRContent.Location = new System.Drawing.Point(31, 52);
            this.txtQRContent.MaximumSize = new System.Drawing.Size(500, 50);
            this.txtQRContent.MinimumSize = new System.Drawing.Size(100, 30);
            this.txtQRContent.Name = "txtQRContent";
            this.txtQRContent.Size = new System.Drawing.Size(300, 23);
            this.txtQRContent.TabIndex = 12;
            // 
            // gridBinLineQCApproval
            // 
            this.gridBinLineQCApproval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBinLineQCApproval.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridBinLineQCApproval.Location = new System.Drawing.Point(0, 0);
            this.gridBinLineQCApproval.MainView = this.gridBinLineQCApprovalView;
            this.gridBinLineQCApproval.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridBinLineQCApproval.Name = "gridBinLineQCApproval";
            this.gridBinLineQCApproval.Size = new System.Drawing.Size(1361, 667);
            this.gridBinLineQCApproval.TabIndex = 13;
            this.gridBinLineQCApproval.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridBinLineQCApprovalView});
            // 
            // gridBinLineQCApprovalView
            // 
            this.gridBinLineQCApprovalView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWODocNo,
            this.colPrintDate,
            this.colLine,
            this.colProductIDVN,
            this.colCustomer,
            this.colQRCodeVerify,
            this.colQRCodeData,
            this.colCustomerVerify,
            this.colQCVerify,
            this.colPrintUser,
            this.colSumQuantity,
            this.colLinkQQuantityPerBin,
            this.colBinSize});
            this.gridBinLineQCApprovalView.GridControl = this.gridBinLineQCApproval;
            this.gridBinLineQCApprovalView.Name = "gridBinLineQCApprovalView";
            this.gridBinLineQCApprovalView.OptionsBehavior.Editable = false;
            this.gridBinLineQCApprovalView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridBinLineQCApprovalView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridBinLineQCApprovalView.OptionsPrint.AutoWidth = false;
            this.gridBinLineQCApprovalView.OptionsSelection.MultiSelect = true;
            this.gridBinLineQCApprovalView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridBinLineQCApprovalView.OptionsView.ColumnAutoWidth = false;
            this.gridBinLineQCApprovalView.OptionsView.RowAutoHeight = true;
            this.gridBinLineQCApprovalView.OptionsView.ShowAutoFilterRow = true;
            this.gridBinLineQCApprovalView.OptionsView.ShowGroupPanel = false;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 1;
            this.colWODocNo.Width = 94;
            // 
            // colPrintDate
            // 
            this.colPrintDate.Caption = "Ngày in";
            this.colPrintDate.FieldName = "PrintDate";
            this.colPrintDate.MinWidth = 25;
            this.colPrintDate.Name = "colPrintDate";
            this.colPrintDate.Visible = true;
            this.colPrintDate.VisibleIndex = 2;
            this.colPrintDate.Width = 94;
            // 
            // colLine
            // 
            this.colLine.Caption = "Line";
            this.colLine.FieldName = "Line";
            this.colLine.MinWidth = 25;
            this.colLine.Name = "colLine";
            this.colLine.Visible = true;
            this.colLine.VisibleIndex = 3;
            this.colLine.Width = 94;
            // 
            // colProductIDVN
            // 
            this.colProductIDVN.Caption = "Mã SP VN";
            this.colProductIDVN.FieldName = "ProductIDVN";
            this.colProductIDVN.MinWidth = 25;
            this.colProductIDVN.Name = "colProductIDVN";
            this.colProductIDVN.Visible = true;
            this.colProductIDVN.VisibleIndex = 4;
            this.colProductIDVN.Width = 94;
            // 
            // colCustomer
            // 
            this.colCustomer.Caption = "Khách hàng";
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.MinWidth = 25;
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Visible = true;
            this.colCustomer.VisibleIndex = 5;
            this.colCustomer.Width = 94;
            // 
            // colQRCodeVerify
            // 
            this.colQRCodeVerify.Caption = "Xác nhận mã vạch";
            this.colQRCodeVerify.FieldName = "QRCodeVerify";
            this.colQRCodeVerify.MinWidth = 25;
            this.colQRCodeVerify.Name = "colQRCodeVerify";
            this.colQRCodeVerify.Visible = true;
            this.colQRCodeVerify.VisibleIndex = 6;
            this.colQRCodeVerify.Width = 94;
            // 
            // colQRCodeData
            // 
            this.colQRCodeData.Caption = "Nội dung Scan";
            this.colQRCodeData.FieldName = "QRCodeData";
            this.colQRCodeData.MinWidth = 25;
            this.colQRCodeData.Name = "colQRCodeData";
            this.colQRCodeData.Visible = true;
            this.colQRCodeData.VisibleIndex = 7;
            this.colQRCodeData.Width = 94;
            // 
            // colCustomerVerify
            // 
            this.colCustomerVerify.Caption = "Mã khách hàng kiểm tra";
            this.colCustomerVerify.FieldName = "CustomerVerify";
            this.colCustomerVerify.MinWidth = 25;
            this.colCustomerVerify.Name = "colCustomerVerify";
            this.colCustomerVerify.Visible = true;
            this.colCustomerVerify.VisibleIndex = 8;
            this.colCustomerVerify.Width = 94;
            // 
            // colQCVerify
            // 
            this.colQCVerify.Caption = "Xác nhận QC";
            this.colQCVerify.FieldName = "QCVerify";
            this.colQCVerify.MinWidth = 25;
            this.colQCVerify.Name = "colQCVerify";
            this.colQCVerify.Visible = true;
            this.colQCVerify.VisibleIndex = 9;
            this.colQCVerify.Width = 94;
            // 
            // colPrintUser
            // 
            this.colPrintUser.Caption = "SX In Tem";
            this.colPrintUser.FieldName = "PrintUser";
            this.colPrintUser.MinWidth = 25;
            this.colPrintUser.Name = "colPrintUser";
            this.colPrintUser.Visible = true;
            this.colPrintUser.VisibleIndex = 10;
            this.colPrintUser.Width = 94;
            // 
            // colSumQuantity
            // 
            this.colSumQuantity.Caption = "Tổng số lượng";
            this.colSumQuantity.DisplayFormat.FormatString = "{0:#0}";
            this.colSumQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumQuantity.FieldName = "SumQuantity";
            this.colSumQuantity.MinWidth = 25;
            this.colSumQuantity.Name = "colSumQuantity";
            this.colSumQuantity.Visible = true;
            this.colSumQuantity.VisibleIndex = 11;
            this.colSumQuantity.Width = 94;
            // 
            // colLinkQQuantityPerBin
            // 
            this.colLinkQQuantityPerBin.Caption = "SL / thùng LinkQ";
            this.colLinkQQuantityPerBin.DisplayFormat.FormatString = "{0:#0}";
            this.colLinkQQuantityPerBin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLinkQQuantityPerBin.FieldName = "LinkQQuantityPerBin";
            this.colLinkQQuantityPerBin.MinWidth = 25;
            this.colLinkQQuantityPerBin.Name = "colLinkQQuantityPerBin";
            this.colLinkQQuantityPerBin.Visible = true;
            this.colLinkQQuantityPerBin.VisibleIndex = 12;
            this.colLinkQQuantityPerBin.Width = 94;
            // 
            // colBinSize
            // 
            this.colBinSize.Caption = "Kích thước thùng";
            this.colBinSize.FieldName = "BinSize";
            this.colBinSize.MinWidth = 25;
            this.colBinSize.Name = "colBinSize";
            this.colBinSize.Visible = true;
            this.colBinSize.VisibleIndex = 13;
            this.colBinSize.Width = 94;
            // 
            // frmBinLineQCApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 774);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBinLineQCApproval";
            this.Text = "frmBinLineQCApproval";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBinLineQCApproval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBinLineQCApprovalView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtQRQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtQRContent;
        private DevExpress.XtraGrid.GridControl gridBinLineQCApproval;
        private DevExpress.XtraGrid.Views.Grid.GridView gridBinLineQCApprovalView;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPrintDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colProductIDVN;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colQRCodeVerify;
        private DevExpress.XtraGrid.Columns.GridColumn colQRCodeData;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerVerify;
        private DevExpress.XtraGrid.Columns.GridColumn colQCVerify;
        private DevExpress.XtraGrid.Columns.GridColumn colPrintUser;
        private DevExpress.XtraGrid.Columns.GridColumn colSumQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colLinkQQuantityPerBin;
        private DevExpress.XtraGrid.Columns.GridColumn colBinSize;
    }
}