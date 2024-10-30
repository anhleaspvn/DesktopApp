namespace ASPProject.Timekeeping
{
    partial class frmTimekeeping
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
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.colTimekeepID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTimekeepingView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTimekeepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimekeepHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimekeepHoursMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimekeepHoursOver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTimekeeping = new DevExpress.XtraGrid.GridControl();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimekeepingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimekeeping)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit2
            // 
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(220, 278);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(117, 23);
            this.textEdit2.TabIndex = 32;
            this.textEdit2.Visible = false;
            // 
            // colTimekeepID
            // 
            this.colTimekeepID.Caption = "Mã ký hiệu công";
            this.colTimekeepID.FieldName = "TimekeepID";
            this.colTimekeepID.MinWidth = 25;
            this.colTimekeepID.Name = "colTimekeepID";
            this.colTimekeepID.Visible = true;
            this.colTimekeepID.VisibleIndex = 0;
            this.colTimekeepID.Width = 94;
            // 
            // gridTimekeepingView
            // 
            this.gridTimekeepingView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTimekeepID,
            this.colTimekeepName,
            this.colTimekeepHours,
            this.colTimekeepHoursMain,
            this.colTimekeepHoursOver});
            this.gridTimekeepingView.DetailHeight = 431;
            this.gridTimekeepingView.GridControl = this.gridTimekeeping;
            this.gridTimekeepingView.Name = "gridTimekeepingView";
            this.gridTimekeepingView.OptionsBehavior.Editable = false;
            this.gridTimekeepingView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridTimekeepingView.OptionsSelection.MultiSelect = true;
            this.gridTimekeepingView.OptionsView.ShowAutoFilterRow = true;
            this.gridTimekeepingView.OptionsView.ShowGroupPanel = false;
            // 
            // colTimekeepName
            // 
            this.colTimekeepName.Caption = "Tên ký hiệu công";
            this.colTimekeepName.FieldName = "TimekeepName";
            this.colTimekeepName.MinWidth = 25;
            this.colTimekeepName.Name = "colTimekeepName";
            this.colTimekeepName.Visible = true;
            this.colTimekeepName.VisibleIndex = 1;
            this.colTimekeepName.Width = 94;
            // 
            // colTimekeepHours
            // 
            this.colTimekeepHours.Caption = "Tổng giờ công";
            this.colTimekeepHours.DisplayFormat.FormatString = "#0.0";
            this.colTimekeepHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimekeepHours.FieldName = "TimekeepHours";
            this.colTimekeepHours.MinWidth = 25;
            this.colTimekeepHours.Name = "colTimekeepHours";
            this.colTimekeepHours.Visible = true;
            this.colTimekeepHours.VisibleIndex = 2;
            this.colTimekeepHours.Width = 94;
            // 
            // colTimekeepHoursMain
            // 
            this.colTimekeepHoursMain.Caption = "Giờ công HC";
            this.colTimekeepHoursMain.DisplayFormat.FormatString = "#0.0";
            this.colTimekeepHoursMain.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimekeepHoursMain.FieldName = "TimekeepHoursMain";
            this.colTimekeepHoursMain.MinWidth = 25;
            this.colTimekeepHoursMain.Name = "colTimekeepHoursMain";
            this.colTimekeepHoursMain.Visible = true;
            this.colTimekeepHoursMain.VisibleIndex = 3;
            this.colTimekeepHoursMain.Width = 94;
            // 
            // colTimekeepHoursOver
            // 
            this.colTimekeepHoursOver.Caption = "Giờ công TC";
            this.colTimekeepHoursOver.DisplayFormat.FormatString = "#0.0";
            this.colTimekeepHoursOver.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimekeepHoursOver.FieldName = "TimekeepHoursOver";
            this.colTimekeepHoursOver.MinWidth = 25;
            this.colTimekeepHoursOver.Name = "colTimekeepHoursOver";
            this.colTimekeepHoursOver.Visible = true;
            this.colTimekeepHoursOver.VisibleIndex = 4;
            this.colTimekeepHoursOver.Width = 94;
            // 
            // gridTimekeeping
            // 
            this.gridTimekeeping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTimekeeping.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridTimekeeping.Location = new System.Drawing.Point(0, 0);
            this.gridTimekeeping.MainView = this.gridTimekeepingView;
            this.gridTimekeeping.Margin = new System.Windows.Forms.Padding(4);
            this.gridTimekeeping.Name = "gridTimekeeping";
            this.gridTimekeeping.Size = new System.Drawing.Size(983, 396);
            this.gridTimekeeping.TabIndex = 25;
            this.gridTimekeeping.UseEmbeddedNavigator = true;
            this.gridTimekeeping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridTimekeepingView});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridTimekeeping);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 396);
            this.panel1.TabIndex = 33;
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
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 396);
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
            this.barDockControlTop.Size = new System.Drawing.Size(983, 54);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(983, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(983, 54);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 396);
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(220, 246);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(117, 23);
            this.textEdit1.TabIndex = 31;
            this.textEdit1.Visible = false;
            // 
            // frmTimekeeping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 450);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimekeeping";
            this.Text = "Timekeeping";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimekeepingView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimekeeping)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colTimekeepID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridTimekeepingView;
        private DevExpress.XtraGrid.Columns.GridColumn colTimekeepName;
        private DevExpress.XtraGrid.GridControl gridTimekeeping;
        private System.Windows.Forms.Panel panel1;
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
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTimekeepHours;
        private DevExpress.XtraGrid.Columns.GridColumn colTimekeepHoursMain;
        private DevExpress.XtraGrid.Columns.GridColumn colTimekeepHoursOver;
    }
}