namespace ASPProject.DefectiveMode
{
    partial class frmDefectiveMode
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
            this.colDefectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDefectView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDefectType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHNUSBNetwork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoldAssembly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainStep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDefect = new DevExpress.XtraGrid.GridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barThoat = new DevExpress.XtraBars.BarButtonItem();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.barXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.barIn = new DevExpress.XtraBars.BarButtonItem();
            this.barNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefectView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefect)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colDefectName
            // 
            this.colDefectName.Caption = "Tên Defect";
            this.colDefectName.FieldName = "DefectName";
            this.colDefectName.MinWidth = 23;
            this.colDefectName.Name = "colDefectName";
            this.colDefectName.OptionsColumn.AllowEdit = false;
            this.colDefectName.Visible = true;
            this.colDefectName.VisibleIndex = 1;
            this.colDefectName.Width = 87;
            // 
            // colDefectID
            // 
            this.colDefectID.Caption = "Mã Defect";
            this.colDefectID.FieldName = "DefectID";
            this.colDefectID.MinWidth = 23;
            this.colDefectID.Name = "colDefectID";
            this.colDefectID.OptionsColumn.AllowEdit = false;
            this.colDefectID.Visible = true;
            this.colDefectID.VisibleIndex = 0;
            this.colDefectID.Width = 87;
            // 
            // gridDefectView
            // 
            this.gridDefectView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDefectID,
            this.colDefectName,
            this.colDefectType,
            this.colDefectLevel,
            this.colHNUSBNetwork,
            this.colMoldAssembly,
            this.colMainStep});
            this.gridDefectView.DetailHeight = 431;
            this.gridDefectView.GridControl = this.gridDefect;
            this.gridDefectView.Name = "gridDefectView";
            this.gridDefectView.OptionsBehavior.Editable = false;
            this.gridDefectView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridDefectView.OptionsSelection.MultiSelect = true;
            this.gridDefectView.OptionsView.ShowAutoFilterRow = true;
            this.gridDefectView.OptionsView.ShowGroupPanel = false;
            // 
            // colDefectType
            // 
            this.colDefectType.Caption = "Loại defect";
            this.colDefectType.FieldName = "DefectType";
            this.colDefectType.MinWidth = 25;
            this.colDefectType.Name = "colDefectType";
            this.colDefectType.Visible = true;
            this.colDefectType.VisibleIndex = 2;
            this.colDefectType.Width = 94;
            // 
            // colDefectLevel
            // 
            this.colDefectLevel.Caption = "Mức độ";
            this.colDefectLevel.FieldName = "DefectLevel";
            this.colDefectLevel.MinWidth = 25;
            this.colDefectLevel.Name = "colDefectLevel";
            this.colDefectLevel.Visible = true;
            this.colDefectLevel.VisibleIndex = 3;
            this.colDefectLevel.Width = 94;
            // 
            // colHNUSBNetwork
            // 
            this.colHNUSBNetwork.Caption = "HN/USB/Network";
            this.colHNUSBNetwork.FieldName = "HN_USB_Network";
            this.colHNUSBNetwork.MinWidth = 25;
            this.colHNUSBNetwork.Name = "colHNUSBNetwork";
            this.colHNUSBNetwork.Visible = true;
            this.colHNUSBNetwork.VisibleIndex = 4;
            this.colHNUSBNetwork.Width = 94;
            // 
            // colMoldAssembly
            // 
            this.colMoldAssembly.Caption = "Mold/Assembly";
            this.colMoldAssembly.FieldName = "Mold_Assembly";
            this.colMoldAssembly.MinWidth = 25;
            this.colMoldAssembly.Name = "colMoldAssembly";
            this.colMoldAssembly.Visible = true;
            this.colMoldAssembly.VisibleIndex = 5;
            this.colMoldAssembly.Width = 94;
            // 
            // colMainStep
            // 
            this.colMainStep.Caption = "HN/USB/Network";
            this.colMainStep.FieldName = "MainStep";
            this.colMainStep.MinWidth = 25;
            this.colMainStep.Name = "colMainStep";
            this.colMainStep.Visible = true;
            this.colMainStep.VisibleIndex = 6;
            this.colMainStep.Width = 94;
            // 
            // gridDefect
            // 
            this.gridDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDefect.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridDefect.Location = new System.Drawing.Point(0, 0);
            this.gridDefect.MainView = this.gridDefectView;
            this.gridDefect.Margin = new System.Windows.Forms.Padding(4);
            this.gridDefect.Name = "gridDefect";
            this.gridDefect.Size = new System.Drawing.Size(1045, 297);
            this.gridDefect.TabIndex = 25;
            this.gridDefect.UseEmbeddedNavigator = true;
            this.gridDefect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDefectView});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridDefect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 297);
            this.panel1.TabIndex = 27;
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
            // barThoat
            // 
            this.barThoat.Caption = "Đóng";
            this.barThoat.Id = 8;
            this.barThoat.ImageOptions.Image = global::ASPProject.Properties.Resources.close2;
            this.barThoat.Name = "barThoat";
            // 
            // textEdit2
            // 
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(220, 382);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(117, 23);
            this.textEdit2.TabIndex = 26;
            this.textEdit2.Visible = false;
            // 
            // barXuat
            // 
            this.barXuat.Caption = "Xuất Dữ Liệu";
            this.barXuat.Id = 7;
            this.barXuat.ImageOptions.Image = global::ASPProject.Properties.Resources.export;
            this.barXuat.Name = "barXuat";
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 54);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 297);
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
            this.barNhap,
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
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
            // barNhap
            // 
            this.barNhap.Caption = "Nhập Dữ Liệu";
            this.barNhap.Id = 9;
            this.barNhap.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.barNhap.Name = "barNhap";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1045, 54);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 351);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1045, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1045, 54);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 297);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(220, 350);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(117, 23);
            this.textEdit1.TabIndex = 25;
            this.textEdit1.Visible = false;
            // 
            // frmDefectiveMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDefectiveMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDefectiveMode";
            ((System.ComponentModel.ISupportInitialize)(this.gridDefectView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefect)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn colDefectName;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDefectView;
        private DevExpress.XtraGrid.GridControl gridDefect;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barThoat;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraBars.BarButtonItem barXuat;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barXoa;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barNapLai;
        private DevExpress.XtraBars.BarButtonItem barIn;
        private DevExpress.XtraBars.BarButtonItem barNhap;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectType;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colMoldAssembly;
        private DevExpress.XtraGrid.Columns.GridColumn colMainStep;
        private DevExpress.XtraGrid.Columns.GridColumn colHNUSBNetwork;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
       
    }
}