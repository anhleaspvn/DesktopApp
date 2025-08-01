namespace ASPProject.ScanBarCodeBin
{
    partial class frmScanBarcodeBin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExport2 = new DevExpress.XtraEditors.SimpleButton();
            this.btExport1 = new DevExpress.XtraEditors.SimpleButton();
            this.btGetLinkQData = new DevExpress.XtraEditors.SimpleButton();
            this.btTransLine = new DevExpress.XtraEditors.SimpleButton();
            this.btImport2 = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btImportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridScanBarcodeBin = new DevExpress.XtraGrid.GridControl();
            this.gridScanBarcodeBinView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPartNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCartNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBinSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colULStamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUL2Stamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSBDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLinkQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginalMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridScanBarcodeBinV2 = new DevExpress.XtraGrid.GridControl();
            this.gridScanBarcodeBinV2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BinQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BinQuantitySum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShipDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rev = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PartNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PkgGwt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Desc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MadeInVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsLinkQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OriginalMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinV2View)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btExport2);
            this.panel1.Controls.Add(this.btExport1);
            this.panel1.Controls.Add(this.btGetLinkQData);
            this.panel1.Controls.Add(this.btTransLine);
            this.panel1.Controls.Add(this.btImport2);
            this.panel1.Controls.Add(this.btDelete);
            this.panel1.Controls.Add(this.btImportExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 600);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1498, 62);
            this.panel1.TabIndex = 0;
            // 
            // btExport2
            // 
            this.btExport2.ImageOptions.Image = global::ASPProject.Properties.Resources.money;
            this.btExport2.Location = new System.Drawing.Point(578, 14);
            this.btExport2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btExport2.Name = "btExport2";
            this.btExport2.Size = new System.Drawing.Size(161, 34);
            this.btExport2.TabIndex = 15;
            this.btExport2.Text = "Xuất dữ liệu 2";
            // 
            // btExport1
            // 
            this.btExport1.ImageOptions.Image = global::ASPProject.Properties.Resources.export;
            this.btExport1.Location = new System.Drawing.Point(397, 14);
            this.btExport1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btExport1.Name = "btExport1";
            this.btExport1.Size = new System.Drawing.Size(161, 34);
            this.btExport1.TabIndex = 14;
            this.btExport1.Text = "Xuất dữ liệu 1";
            // 
            // btGetLinkQData
            // 
            this.btGetLinkQData.ImageOptions.Image = global::ASPProject.Properties.Resources.money;
            this.btGetLinkQData.Location = new System.Drawing.Point(1086, 14);
            this.btGetLinkQData.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btGetLinkQData.Name = "btGetLinkQData";
            this.btGetLinkQData.Size = new System.Drawing.Size(185, 34);
            this.btGetLinkQData.TabIndex = 13;
            this.btGetLinkQData.Text = "Lấy dữ liệu từ LinkQ";
            // 
            // btTransLine
            // 
            this.btTransLine.ImageOptions.Image = global::ASPProject.Properties.Resources.export;
            this.btTransLine.Location = new System.Drawing.Point(910, 14);
            this.btTransLine.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btTransLine.Name = "btTransLine";
            this.btTransLine.Size = new System.Drawing.Size(161, 34);
            this.btTransLine.TabIndex = 12;
            this.btTransLine.Text = "Chuyển sang Line";
            // 
            // btImport2
            // 
            this.btImport2.ImageOptions.Image = global::ASPProject.Properties.Resources.plus;
            this.btImport2.Location = new System.Drawing.Point(198, 14);
            this.btImport2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btImport2.Name = "btImport2";
            this.btImport2.Size = new System.Drawing.Size(161, 34);
            this.btImport2.TabIndex = 11;
            this.btImport2.Text = "Import Dữ liệu 2";
            // 
            // btDelete
            // 
            this.btDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btDelete.Location = new System.Drawing.Point(1309, 14);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(161, 34);
            this.btDelete.TabIndex = 10;
            this.btDelete.Text = "Xoá";
            // 
            // btImportExcel
            // 
            this.btImportExcel.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btImportExcel.Location = new System.Drawing.Point(16, 15);
            this.btImportExcel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btImportExcel.Name = "btImportExcel";
            this.btImportExcel.Size = new System.Drawing.Size(161, 34);
            this.btImportExcel.TabIndex = 9;
            this.btImportExcel.Text = "Import Dữ liệu";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gridScanBarcodeBin);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridScanBarcodeBinV2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1498, 600);
            this.splitContainerControl1.SplitterPosition = 413;
            this.splitContainerControl1.TabIndex = 7;
            // 
            // gridScanBarcodeBin
            // 
            this.gridScanBarcodeBin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScanBarcodeBin.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBin.Location = new System.Drawing.Point(0, 0);
            this.gridScanBarcodeBin.MainView = this.gridScanBarcodeBinView;
            this.gridScanBarcodeBin.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBin.Name = "gridScanBarcodeBin";
            this.gridScanBarcodeBin.Size = new System.Drawing.Size(1498, 413);
            this.gridScanBarcodeBin.TabIndex = 5;
            this.gridScanBarcodeBin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridScanBarcodeBinView});
            // 
            // gridScanBarcodeBinView
            // 
            this.gridScanBarcodeBinView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPartNo,
            this.colItemNo,
            this.colQuantity,
            this.colNW,
            this.colGW,
            this.colCartNo,
            this.colLotNo,
            this.colWO,
            this.colCable,
            this.colBinSize,
            this.colULStamp,
            this.colUL2Stamp,
            this.colSBDate,
            this.colPOText,
            this.colPOCode,
            this.colIsLinkQ,
            this.colOriginalMaterial});
            this.gridScanBarcodeBinView.GridControl = this.gridScanBarcodeBin;
            this.gridScanBarcodeBinView.Name = "gridScanBarcodeBinView";
            this.gridScanBarcodeBinView.OptionsBehavior.Editable = false;
            this.gridScanBarcodeBinView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridScanBarcodeBinView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridScanBarcodeBinView.OptionsSelection.MultiSelect = true;
            this.gridScanBarcodeBinView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridScanBarcodeBinView.OptionsView.RowAutoHeight = true;
            this.gridScanBarcodeBinView.OptionsView.ShowAutoFilterRow = true;
            this.gridScanBarcodeBinView.OptionsView.ShowGroupPanel = false;
            // 
            // colPartNo
            // 
            this.colPartNo.Caption = "Part No";
            this.colPartNo.FieldName = "PartNo";
            this.colPartNo.MinWidth = 23;
            this.colPartNo.Name = "colPartNo";
            this.colPartNo.Visible = true;
            this.colPartNo.VisibleIndex = 1;
            // 
            // colItemNo
            // 
            this.colItemNo.Caption = "Item No";
            this.colItemNo.FieldName = "ItemNo";
            this.colItemNo.MinWidth = 23;
            this.colItemNo.Name = "colItemNo";
            this.colItemNo.Visible = true;
            this.colItemNo.VisibleIndex = 2;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.DisplayFormat.FormatString = "{0:#0}";
            this.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 23;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            // 
            // colNW
            // 
            this.colNW.Caption = "NW";
            this.colNW.DisplayFormat.FormatString = "{0:#0.00}";
            this.colNW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNW.FieldName = "NW";
            this.colNW.MinWidth = 23;
            this.colNW.Name = "colNW";
            this.colNW.Visible = true;
            this.colNW.VisibleIndex = 4;
            // 
            // colGW
            // 
            this.colGW.Caption = "GW";
            this.colGW.DisplayFormat.FormatString = "{0:#0.00}";
            this.colGW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGW.FieldName = "GW";
            this.colGW.MinWidth = 23;
            this.colGW.Name = "colGW";
            this.colGW.Visible = true;
            this.colGW.VisibleIndex = 5;
            // 
            // colCartNo
            // 
            this.colCartNo.Caption = "Cart No";
            this.colCartNo.FieldName = "CartNo";
            this.colCartNo.MinWidth = 23;
            this.colCartNo.Name = "colCartNo";
            this.colCartNo.Visible = true;
            this.colCartNo.VisibleIndex = 6;
            this.colCartNo.Width = 200;
            // 
            // colLotNo
            // 
            this.colLotNo.Caption = "Lot No";
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.MinWidth = 23;
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.Visible = true;
            this.colLotNo.VisibleIndex = 7;
            // 
            // colWO
            // 
            this.colWO.Caption = "WO";
            this.colWO.FieldName = "WO";
            this.colWO.MinWidth = 23;
            this.colWO.Name = "colWO";
            this.colWO.Visible = true;
            this.colWO.VisibleIndex = 8;
            // 
            // colCable
            // 
            this.colCable.Caption = "Cable";
            this.colCable.FieldName = "Cable";
            this.colCable.MinWidth = 23;
            this.colCable.Name = "colCable";
            this.colCable.Visible = true;
            this.colCable.VisibleIndex = 9;
            // 
            // colBinSize
            // 
            this.colBinSize.Caption = "Bin Size";
            this.colBinSize.FieldName = "BinSize";
            this.colBinSize.MinWidth = 23;
            this.colBinSize.Name = "colBinSize";
            this.colBinSize.Visible = true;
            this.colBinSize.VisibleIndex = 10;
            // 
            // colULStamp
            // 
            this.colULStamp.Caption = "UL Stamp";
            this.colULStamp.FieldName = "ULStamp";
            this.colULStamp.MinWidth = 23;
            this.colULStamp.Name = "colULStamp";
            this.colULStamp.Visible = true;
            this.colULStamp.VisibleIndex = 11;
            // 
            // colUL2Stamp
            // 
            this.colUL2Stamp.Caption = "UL Stamp 2";
            this.colUL2Stamp.FieldName = "UL2Stamp";
            this.colUL2Stamp.MinWidth = 23;
            this.colUL2Stamp.Name = "colUL2Stamp";
            this.colUL2Stamp.Visible = true;
            this.colUL2Stamp.VisibleIndex = 12;
            // 
            // colSBDate
            // 
            this.colSBDate.Caption = "SB Date";
            this.colSBDate.FieldName = "SBDate";
            this.colSBDate.MinWidth = 23;
            this.colSBDate.Name = "colSBDate";
            this.colSBDate.Visible = true;
            this.colSBDate.VisibleIndex = 13;
            // 
            // colPOText
            // 
            this.colPOText.Caption = "PO Text";
            this.colPOText.FieldName = "POText";
            this.colPOText.MinWidth = 25;
            this.colPOText.Name = "colPOText";
            this.colPOText.Visible = true;
            this.colPOText.VisibleIndex = 14;
            this.colPOText.Width = 94;
            // 
            // colPOCode
            // 
            this.colPOCode.Caption = "PO Code";
            this.colPOCode.FieldName = "POCode";
            this.colPOCode.MinWidth = 25;
            this.colPOCode.Name = "colPOCode";
            this.colPOCode.Visible = true;
            this.colPOCode.VisibleIndex = 15;
            this.colPOCode.Width = 94;
            // 
            // colIsLinkQ
            // 
            this.colIsLinkQ.Caption = "Từ LinkQ";
            this.colIsLinkQ.FieldName = "IsLinkQ";
            this.colIsLinkQ.MinWidth = 25;
            this.colIsLinkQ.Name = "colIsLinkQ";
            this.colIsLinkQ.Visible = true;
            this.colIsLinkQ.VisibleIndex = 17;
            this.colIsLinkQ.Width = 94;
            // 
            // colOriginalMaterial
            // 
            this.colOriginalMaterial.Caption = "Vật tư gốc";
            this.colOriginalMaterial.FieldName = "OriginalMaterial";
            this.colOriginalMaterial.MinWidth = 25;
            this.colOriginalMaterial.Name = "colOriginalMaterial";
            this.colOriginalMaterial.Visible = true;
            this.colOriginalMaterial.VisibleIndex = 16;
            this.colOriginalMaterial.Width = 94;
            // 
            // gridScanBarcodeBinV2
            // 
            this.gridScanBarcodeBinV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScanBarcodeBinV2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBinV2.Location = new System.Drawing.Point(0, 0);
            this.gridScanBarcodeBinV2.MainView = this.gridScanBarcodeBinV2View;
            this.gridScanBarcodeBinV2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBinV2.Name = "gridScanBarcodeBinV2";
            this.gridScanBarcodeBinV2.Size = new System.Drawing.Size(1498, 180);
            this.gridScanBarcodeBinV2.TabIndex = 5;
            this.gridScanBarcodeBinV2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridScanBarcodeBinV2View});
            // 
            // gridScanBarcodeBinV2View
            // 
            this.gridScanBarcodeBinV2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CusID,
            this.Quantity,
            this.BinQuantity,
            this.BinQuantitySum,
            this.ShipDate,
            this.Rev,
            this.PartNo,
            this.WO,
            this.PkgGwt,
            this.Desc,
            this.MadeInVN,
            this.IsLinkQ,
            this.OriginalMaterial});
            this.gridScanBarcodeBinV2View.GridControl = this.gridScanBarcodeBinV2;
            this.gridScanBarcodeBinV2View.Name = "gridScanBarcodeBinV2View";
            this.gridScanBarcodeBinV2View.OptionsBehavior.Editable = false;
            this.gridScanBarcodeBinV2View.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridScanBarcodeBinV2View.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridScanBarcodeBinV2View.OptionsSelection.MultiSelect = true;
            this.gridScanBarcodeBinV2View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridScanBarcodeBinV2View.OptionsView.RowAutoHeight = true;
            this.gridScanBarcodeBinV2View.OptionsView.ShowAutoFilterRow = true;
            this.gridScanBarcodeBinV2View.OptionsView.ShowGroupPanel = false;
            // 
            // CusID
            // 
            this.CusID.Caption = "Customer";
            this.CusID.FieldName = "CusID";
            this.CusID.MinWidth = 23;
            this.CusID.Name = "CusID";
            this.CusID.Visible = true;
            this.CusID.VisibleIndex = 1;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "Quantity";
            this.Quantity.FieldName = "Quantity";
            this.Quantity.MinWidth = 23;
            this.Quantity.Name = "Quantity";
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 2;
            // 
            // BinQuantity
            // 
            this.BinQuantity.Caption = "Bin Quantity";
            this.BinQuantity.FieldName = "BinQuantity";
            this.BinQuantity.MinWidth = 23;
            this.BinQuantity.Name = "BinQuantity";
            this.BinQuantity.Visible = true;
            this.BinQuantity.VisibleIndex = 3;
            // 
            // BinQuantitySum
            // 
            this.BinQuantitySum.Caption = "Bin Quantity Sum";
            this.BinQuantitySum.FieldName = "BinQuantitySum";
            this.BinQuantitySum.MinWidth = 23;
            this.BinQuantitySum.Name = "BinQuantitySum";
            this.BinQuantitySum.Visible = true;
            this.BinQuantitySum.VisibleIndex = 4;
            // 
            // ShipDate
            // 
            this.ShipDate.Caption = "Ship Date";
            this.ShipDate.FieldName = "ShipDate";
            this.ShipDate.MinWidth = 23;
            this.ShipDate.Name = "ShipDate";
            this.ShipDate.Visible = true;
            this.ShipDate.VisibleIndex = 5;
            // 
            // Rev
            // 
            this.Rev.Caption = "Rev";
            this.Rev.FieldName = "Rev";
            this.Rev.MinWidth = 23;
            this.Rev.Name = "Rev";
            this.Rev.Visible = true;
            this.Rev.VisibleIndex = 6;
            // 
            // PartNo
            // 
            this.PartNo.Caption = "Part No";
            this.PartNo.FieldName = "PartNo";
            this.PartNo.MinWidth = 23;
            this.PartNo.Name = "PartNo";
            this.PartNo.Visible = true;
            this.PartNo.VisibleIndex = 7;
            // 
            // WO
            // 
            this.WO.Caption = "WO";
            this.WO.FieldName = "WO";
            this.WO.MinWidth = 23;
            this.WO.Name = "WO";
            this.WO.Visible = true;
            this.WO.VisibleIndex = 8;
            // 
            // PkgGwt
            // 
            this.PkgGwt.Caption = "Pkg Gwt";
            this.PkgGwt.FieldName = "PkgGwt";
            this.PkgGwt.MinWidth = 23;
            this.PkgGwt.Name = "PkgGwt";
            this.PkgGwt.Visible = true;
            this.PkgGwt.VisibleIndex = 9;
            // 
            // Desc
            // 
            this.Desc.Caption = "Desc";
            this.Desc.FieldName = "Desc";
            this.Desc.MinWidth = 23;
            this.Desc.Name = "Desc";
            this.Desc.Visible = true;
            this.Desc.VisibleIndex = 10;
            // 
            // MadeInVN
            // 
            this.MadeInVN.Caption = "Made In VN";
            this.MadeInVN.FieldName = "MadeInVN";
            this.MadeInVN.MinWidth = 23;
            this.MadeInVN.Name = "MadeInVN";
            this.MadeInVN.Visible = true;
            this.MadeInVN.VisibleIndex = 11;
            // 
            // IsLinkQ
            // 
            this.IsLinkQ.Caption = "Từ LinkQ";
            this.IsLinkQ.FieldName = "IsLinkQ";
            this.IsLinkQ.MinWidth = 25;
            this.IsLinkQ.Name = "IsLinkQ";
            this.IsLinkQ.Visible = true;
            this.IsLinkQ.VisibleIndex = 13;
            this.IsLinkQ.Width = 94;
            // 
            // OriginalMaterial
            // 
            this.OriginalMaterial.Caption = "Vật tư gốc";
            this.OriginalMaterial.FieldName = "OriginalMaterial";
            this.OriginalMaterial.MinWidth = 25;
            this.OriginalMaterial.Name = "OriginalMaterial";
            this.OriginalMaterial.Visible = true;
            this.OriginalMaterial.VisibleIndex = 12;
            this.OriginalMaterial.Width = 94;
            // 
            // frmScanBarcodeBin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 662);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmScanBarcodeBin";
            this.Text = "frmScanBarcodeBin";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinV2View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridScanBarcodeBin;
        private DevExpress.XtraGrid.Views.Grid.GridView gridScanBarcodeBinView;
        private DevExpress.XtraGrid.Columns.GridColumn colPartNo;
        private DevExpress.XtraGrid.Columns.GridColumn colItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colNW;
        private DevExpress.XtraGrid.Columns.GridColumn colGW;
        private DevExpress.XtraGrid.Columns.GridColumn colCartNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn colWO;
        private DevExpress.XtraGrid.Columns.GridColumn colCable;
        private DevExpress.XtraGrid.Columns.GridColumn colBinSize;
        private DevExpress.XtraGrid.Columns.GridColumn colULStamp;
        private DevExpress.XtraGrid.Columns.GridColumn colUL2Stamp;
        private DevExpress.XtraGrid.Columns.GridColumn colSBDate;
        private DevExpress.XtraGrid.GridControl gridScanBarcodeBinV2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridScanBarcodeBinV2View;
        private DevExpress.XtraGrid.Columns.GridColumn CusID;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn BinQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn BinQuantitySum;
        private DevExpress.XtraGrid.Columns.GridColumn ShipDate;
        private DevExpress.XtraGrid.Columns.GridColumn Rev;
        private DevExpress.XtraGrid.Columns.GridColumn PartNo;
        private DevExpress.XtraGrid.Columns.GridColumn WO;
        private DevExpress.XtraGrid.Columns.GridColumn PkgGwt;
        private DevExpress.XtraGrid.Columns.GridColumn Desc;
        private DevExpress.XtraGrid.Columns.GridColumn MadeInVN;
        private DevExpress.XtraEditors.SimpleButton btDelete;
        private DevExpress.XtraEditors.SimpleButton btImportExcel;
        private DevExpress.XtraEditors.SimpleButton btImport2;
        private DevExpress.XtraEditors.SimpleButton btTransLine;
        private DevExpress.XtraEditors.SimpleButton btGetLinkQData;
        private DevExpress.XtraGrid.Columns.GridColumn colPOText;
        private DevExpress.XtraGrid.Columns.GridColumn colPOCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLinkQ;
        private DevExpress.XtraGrid.Columns.GridColumn IsLinkQ;
        private DevExpress.XtraEditors.SimpleButton btExport2;
        private DevExpress.XtraEditors.SimpleButton btExport1;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginalMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn OriginalMaterial;
    }
}