namespace ASPProject.ScanBarCodeBin
{
    partial class frmScanBarcodeBinLine
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
            this.gridScanBarcodeBinLine = new DevExpress.XtraGrid.GridControl();
            this.gridScanBarcodeBinLineView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridScanBarcodeBinLineV2 = new DevExpress.XtraGrid.GridControl();
            this.gridScanBarcodeBinLineV2View = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCopy2 = new DevExpress.XtraEditors.SimpleButton();
            this.btCopy1 = new DevExpress.XtraEditors.SimpleButton();
            this.btInput2 = new DevExpress.XtraEditors.SimpleButton();
            this.btInput = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLineView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLineV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLineV2View)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.gridScanBarcodeBinLine);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridScanBarcodeBinLineV2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1211, 629);
            this.splitContainerControl1.SplitterPosition = 263;
            this.splitContainerControl1.TabIndex = 9;
            // 
            // gridScanBarcodeBinLine
            // 
            this.gridScanBarcodeBinLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScanBarcodeBinLine.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBinLine.Location = new System.Drawing.Point(0, 0);
            this.gridScanBarcodeBinLine.MainView = this.gridScanBarcodeBinLineView;
            this.gridScanBarcodeBinLine.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBinLine.Name = "gridScanBarcodeBinLine";
            this.gridScanBarcodeBinLine.Size = new System.Drawing.Size(1211, 263);
            this.gridScanBarcodeBinLine.TabIndex = 5;
            this.gridScanBarcodeBinLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridScanBarcodeBinLineView});
            // 
            // gridScanBarcodeBinLineView
            // 
            this.gridScanBarcodeBinLineView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.colSBDate});
            this.gridScanBarcodeBinLineView.GridControl = this.gridScanBarcodeBinLine;
            this.gridScanBarcodeBinLineView.Name = "gridScanBarcodeBinLineView";
            this.gridScanBarcodeBinLineView.OptionsBehavior.Editable = false;
            this.gridScanBarcodeBinLineView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridScanBarcodeBinLineView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridScanBarcodeBinLineView.OptionsSelection.MultiSelect = true;
            this.gridScanBarcodeBinLineView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridScanBarcodeBinLineView.OptionsView.RowAutoHeight = true;
            this.gridScanBarcodeBinLineView.OptionsView.ShowAutoFilterRow = true;
            this.gridScanBarcodeBinLineView.OptionsView.ShowGroupPanel = false;
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
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 23;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 3;
            // 
            // colNW
            // 
            this.colNW.Caption = "NW";
            this.colNW.FieldName = "NW";
            this.colNW.MinWidth = 23;
            this.colNW.Name = "colNW";
            this.colNW.Visible = true;
            this.colNW.VisibleIndex = 4;
            // 
            // colGW
            // 
            this.colGW.Caption = "GW";
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
            // gridScanBarcodeBinLineV2
            // 
            this.gridScanBarcodeBinLineV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScanBarcodeBinLineV2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBinLineV2.Location = new System.Drawing.Point(0, 0);
            this.gridScanBarcodeBinLineV2.MainView = this.gridScanBarcodeBinLineV2View;
            this.gridScanBarcodeBinLineV2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridScanBarcodeBinLineV2.Name = "gridScanBarcodeBinLineV2";
            this.gridScanBarcodeBinLineV2.Size = new System.Drawing.Size(1211, 359);
            this.gridScanBarcodeBinLineV2.TabIndex = 5;
            this.gridScanBarcodeBinLineV2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridScanBarcodeBinLineV2View});
            // 
            // gridScanBarcodeBinLineV2View
            // 
            this.gridScanBarcodeBinLineV2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.MadeInVN});
            this.gridScanBarcodeBinLineV2View.GridControl = this.gridScanBarcodeBinLineV2;
            this.gridScanBarcodeBinLineV2View.Name = "gridScanBarcodeBinLineV2View";
            this.gridScanBarcodeBinLineV2View.OptionsBehavior.Editable = false;
            this.gridScanBarcodeBinLineV2View.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridScanBarcodeBinLineV2View.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridScanBarcodeBinLineV2View.OptionsSelection.MultiSelect = true;
            this.gridScanBarcodeBinLineV2View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridScanBarcodeBinLineV2View.OptionsView.RowAutoHeight = true;
            this.gridScanBarcodeBinLineV2View.OptionsView.ShowAutoFilterRow = true;
            this.gridScanBarcodeBinLineV2View.OptionsView.ShowGroupPanel = false;
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
            this.MadeInVN.MinWidth = 25;
            this.MadeInVN.Name = "MadeInVN";
            this.MadeInVN.Visible = true;
            this.MadeInVN.VisibleIndex = 11;
            this.MadeInVN.Width = 94;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCopy2);
            this.panel1.Controls.Add(this.btCopy1);
            this.panel1.Controls.Add(this.btInput2);
            this.panel1.Controls.Add(this.btInput);
            this.panel1.Controls.Add(this.btDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 629);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 62);
            this.panel1.TabIndex = 8;
            // 
            // btCopy2
            // 
            this.btCopy2.ImageOptions.Image = global::ASPProject.Properties.Resources.export_to_file;
            this.btCopy2.Location = new System.Drawing.Point(616, 14);
            this.btCopy2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btCopy2.Name = "btCopy2";
            this.btCopy2.Size = new System.Drawing.Size(161, 34);
            this.btCopy2.TabIndex = 15;
            this.btCopy2.Text = "Sao chép 2";
            // 
            // btCopy1
            // 
            this.btCopy1.ImageOptions.Image = global::ASPProject.Properties.Resources.export_to_file;
            this.btCopy1.Location = new System.Drawing.Point(434, 15);
            this.btCopy1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btCopy1.Name = "btCopy1";
            this.btCopy1.Size = new System.Drawing.Size(161, 34);
            this.btCopy1.TabIndex = 14;
            this.btCopy1.Text = "Sao chép 1";
            // 
            // btInput2
            // 
            this.btInput2.ImageOptions.Image = global::ASPProject.Properties.Resources.edit2;
            this.btInput2.Location = new System.Drawing.Point(202, 14);
            this.btInput2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btInput2.Name = "btInput2";
            this.btInput2.Size = new System.Drawing.Size(161, 34);
            this.btInput2.TabIndex = 13;
            this.btInput2.Text = "Nhập liệu 2";
            // 
            // btInput
            // 
            this.btInput.ImageOptions.Image = global::ASPProject.Properties.Resources.edit2;
            this.btInput.Location = new System.Drawing.Point(20, 15);
            this.btInput.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btInput.Name = "btInput";
            this.btInput.Size = new System.Drawing.Size(161, 34);
            this.btInput.TabIndex = 12;
            this.btInput.Text = "Nhập liệu 1";
            // 
            // btDelete
            // 
            this.btDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btDelete.Location = new System.Drawing.Point(964, 15);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(161, 34);
            this.btDelete.TabIndex = 10;
            this.btDelete.Text = "Xoá";
            // 
            // frmScanBarcodeBinLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 691);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScanBarcodeBinLine";
            this.Text = "frmScanBarcodeBinLine";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLineView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLineV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridScanBarcodeBinLineV2View)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridScanBarcodeBinLine;
        private DevExpress.XtraGrid.Views.Grid.GridView gridScanBarcodeBinLineView;
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
        private DevExpress.XtraGrid.GridControl gridScanBarcodeBinLineV2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridScanBarcodeBinLineV2View;
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
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btDelete;
        private DevExpress.XtraGrid.Columns.GridColumn MadeInVN;
        private DevExpress.XtraEditors.SimpleButton btInput2;
        private DevExpress.XtraEditors.SimpleButton btInput;
        private DevExpress.XtraEditors.SimpleButton btCopy2;
        private DevExpress.XtraEditors.SimpleButton btCopy1;
    }
}