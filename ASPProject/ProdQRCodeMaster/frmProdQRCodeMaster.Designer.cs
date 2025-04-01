namespace ASPProject.ProdQRCodeMaster
{
    partial class frmProdQRCodeMaster
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.barIn = new DevExpress.XtraBars.BarButtonItem();
            this.barXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.barQRCode = new DevExpress.XtraEditors.BarCodeControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridQRCodeMaster = new DevExpress.XtraGrid.GridControl();
            this.gridQRCodeMasterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.WODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RequestQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridQRCodeDetail = new DevExpress.XtraGrid.GridControl();
            this.gridQRCodeDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QRCodeData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsPrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NumOfPrints = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeMasterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeDetailView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1085, 667);
            this.splitContainerControl2.SplitterPosition = 187;
            this.splitContainerControl2.TabIndex = 1;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Thêm";
            this.barButtonItem3.Id = 0;
            this.barButtonItem3.ImageOptions.Image = global::ASPProject.Properties.Resources.add;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thêm";
            this.barButtonItem2.Id = 0;
            this.barButtonItem2.ImageOptions.Image = global::ASPProject.Properties.Resources.add;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 54);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 667);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barThem,
            this.barXoa,
            this.barSua,
            this.barNapLai,
            this.barIn,
            this.barXuat,
            this.barThoat,
            this.barNhap});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barNapLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barXuat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barNhap, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barThem
            // 
            this.barThem.Caption = "Thêm";
            this.barThem.Id = 2;
            this.barThem.ImageOptions.Image = global::ASPProject.Properties.Resources.add;
            this.barThem.Name = "barThem";
            // 
            // barXoa
            // 
            this.barXoa.Caption = "Xóa";
            this.barXoa.Id = 3;
            this.barXoa.ImageOptions.Image = global::ASPProject.Properties.Resources.close1;
            this.barXoa.Name = "barXoa";
            // 
            // barSua
            // 
            this.barSua.Caption = "Sửa";
            this.barSua.Id = 4;
            this.barSua.ImageOptions.Image = global::ASPProject.Properties.Resources.edit2;
            this.barSua.Name = "barSua";
            // 
            // barNapLai
            // 
            this.barNapLai.Caption = "Refresh";
            this.barNapLai.Id = 5;
            this.barNapLai.ImageOptions.Image = global::ASPProject.Properties.Resources.refresh;
            this.barNapLai.Name = "barNapLai";
            // 
            // barIn
            // 
            this.barIn.Caption = "In";
            this.barIn.Id = 6;
            this.barIn.ImageOptions.Image = global::ASPProject.Properties.Resources.printer1;
            this.barIn.Name = "barIn";
            // 
            // barXuat
            // 
            this.barXuat.Caption = "Xuất Dữ Liệu";
            this.barXuat.Id = 7;
            this.barXuat.ImageOptions.Image = global::ASPProject.Properties.Resources.export;
            this.barXuat.Name = "barXuat";
            // 
            // barNhap
            // 
            this.barNhap.Caption = "Nhập Dữ Liệu";
            this.barNhap.Id = 9;
            this.barNhap.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.barNhap.Name = "barNhap";
            // 
            // barThoat
            // 
            this.barThoat.Caption = "Đóng";
            this.barThoat.Id = 8;
            this.barThoat.ImageOptions.Image = global::ASPProject.Properties.Resources.close2;
            this.barThoat.Name = "barThoat";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1387, 54);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 721);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1387, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1387, 54);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 667);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.barQRCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(983, 54);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(404, 667);
            this.panelControl1.TabIndex = 38;
            // 
            // barQRCode
            // 
            this.barQRCode.AutoModule = true;
            this.barQRCode.Location = new System.Drawing.Point(28, 26);
            this.barQRCode.Margin = new System.Windows.Forms.Padding(4);
            this.barQRCode.Name = "barQRCode";
            this.barQRCode.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barQRCode.Size = new System.Drawing.Size(153, 126);
            qrCodeGenerator1.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.Version1;
            this.barQRCode.Symbology = qrCodeGenerator1;
            this.barQRCode.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 54);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(983, 667);
            this.panelControl2.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainerControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 663);
            this.panel1.TabIndex = 34;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gridQRCodeMaster);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridQRCodeDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(979, 663);
            this.splitContainerControl1.SplitterPosition = 276;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // gridQRCodeMaster
            // 
            this.gridQRCodeMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQRCodeMaster.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeMaster.Location = new System.Drawing.Point(0, 0);
            this.gridQRCodeMaster.MainView = this.gridQRCodeMasterView;
            this.gridQRCodeMaster.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeMaster.Name = "gridQRCodeMaster";
            this.gridQRCodeMaster.Size = new System.Drawing.Size(979, 276);
            this.gridQRCodeMaster.TabIndex = 8;
            this.gridQRCodeMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridQRCodeMasterView});
            // 
            // gridQRCodeMasterView
            // 
            this.gridQRCodeMasterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.WODocNo,
            this.ProductID,
            this.RequestQuantity});
            this.gridQRCodeMasterView.GridControl = this.gridQRCodeMaster;
            this.gridQRCodeMasterView.Name = "gridQRCodeMasterView";
            this.gridQRCodeMasterView.OptionsBehavior.Editable = false;
            this.gridQRCodeMasterView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridQRCodeMasterView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridQRCodeMasterView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridQRCodeMasterView.OptionsView.ShowAutoFilterRow = true;
            this.gridQRCodeMasterView.OptionsView.ShowGroupPanel = false;
            // 
            // WODocNo
            // 
            this.WODocNo.Caption = "Lệnh sản xuất";
            this.WODocNo.FieldName = "WODocNo";
            this.WODocNo.MinWidth = 23;
            this.WODocNo.Name = "WODocNo";
            this.WODocNo.Visible = true;
            this.WODocNo.VisibleIndex = 0;
            this.WODocNo.Width = 140;
            // 
            // ProductID
            // 
            this.ProductID.Caption = "Mã sản phẩm";
            this.ProductID.FieldName = "ProductID";
            this.ProductID.MinWidth = 23;
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = true;
            this.ProductID.VisibleIndex = 1;
            this.ProductID.Width = 140;
            // 
            // RequestQuantity
            // 
            this.RequestQuantity.Caption = "Số lượng yêu cầu";
            this.RequestQuantity.FieldName = "RequestQuantity";
            this.RequestQuantity.MinWidth = 23;
            this.RequestQuantity.Name = "RequestQuantity";
            this.RequestQuantity.Visible = true;
            this.RequestQuantity.VisibleIndex = 2;
            this.RequestQuantity.Width = 175;
            // 
            // gridQRCodeDetail
            // 
            this.gridQRCodeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQRCodeDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeDetail.Location = new System.Drawing.Point(0, 0);
            this.gridQRCodeDetail.MainView = this.gridQRCodeDetailView;
            this.gridQRCodeDetail.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridQRCodeDetail.Name = "gridQRCodeDetail";
            this.gridQRCodeDetail.Size = new System.Drawing.Size(979, 380);
            this.gridQRCodeDetail.TabIndex = 6;
            this.gridQRCodeDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridQRCodeDetailView});
            // 
            // gridQRCodeDetailView
            // 
            this.gridQRCodeDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OrderNo,
            this.QRCodeData,
            this.IsPrinted,
            this.NumOfPrints});
            this.gridQRCodeDetailView.GridControl = this.gridQRCodeDetail;
            this.gridQRCodeDetailView.Name = "gridQRCodeDetailView";
            this.gridQRCodeDetailView.OptionsBehavior.Editable = false;
            this.gridQRCodeDetailView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridQRCodeDetailView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridQRCodeDetailView.OptionsSelection.MultiSelect = true;
            this.gridQRCodeDetailView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridQRCodeDetailView.OptionsView.ColumnAutoWidth = false;
            this.gridQRCodeDetailView.OptionsView.ShowAutoFilterRow = true;
            this.gridQRCodeDetailView.OptionsView.ShowGroupPanel = false;
            // 
            // OrderNo
            // 
            this.OrderNo.Caption = "Thứ tự";
            this.OrderNo.FieldName = "OrderNo";
            this.OrderNo.MinWidth = 24;
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Visible = true;
            this.OrderNo.VisibleIndex = 1;
            this.OrderNo.Width = 70;
            // 
            // QRCodeData
            // 
            this.QRCodeData.Caption = "Dữ liệu QR Code";
            this.QRCodeData.FieldName = "QRCodeData";
            this.QRCodeData.MinWidth = 23;
            this.QRCodeData.Name = "QRCodeData";
            this.QRCodeData.Visible = true;
            this.QRCodeData.VisibleIndex = 2;
            this.QRCodeData.Width = 300;
            // 
            // IsPrinted
            // 
            this.IsPrinted.Caption = "Đã In";
            this.IsPrinted.FieldName = "IsPrinted";
            this.IsPrinted.MinWidth = 23;
            this.IsPrinted.Name = "IsPrinted";
            this.IsPrinted.Visible = true;
            this.IsPrinted.VisibleIndex = 3;
            this.IsPrinted.Width = 100;
            // 
            // NumOfPrints
            // 
            this.NumOfPrints.Caption = "Số lần In";
            this.NumOfPrints.FieldName = "NumOfPrints";
            this.NumOfPrints.MinWidth = 23;
            this.NumOfPrints.Name = "NumOfPrints";
            this.NumOfPrints.Visible = true;
            this.NumOfPrints.VisibleIndex = 4;
            this.NumOfPrints.Width = 120;
            // 
            // frmProdQRCodeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 721);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmProdQRCodeMaster";
            this.Text = "Timekeeping";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeMasterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQRCodeDetailView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barXoa;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barNapLai;
        private DevExpress.XtraBars.BarButtonItem barIn;
        private DevExpress.XtraBars.BarButtonItem barXuat;
        private DevExpress.XtraBars.BarButtonItem barNhap;
        private DevExpress.XtraBars.BarButtonItem barThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.BarCodeControl barQRCode;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridQRCodeMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridQRCodeMasterView;
        private DevExpress.XtraGrid.Columns.GridColumn WODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn RequestQuantity;
        private DevExpress.XtraGrid.GridControl gridQRCodeDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridQRCodeDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn OrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn QRCodeData;
        private DevExpress.XtraGrid.Columns.GridColumn IsPrinted;
        private DevExpress.XtraGrid.Columns.GridColumn NumOfPrints;
    }
}