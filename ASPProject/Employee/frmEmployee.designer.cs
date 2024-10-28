namespace ASPProject
{
    partial class frmEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barMultiEditLine = new DevExpress.XtraBars.BarButtonItem();
            this.barNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.barIn = new DevExpress.XtraBars.BarButtonItem();
            this.barXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridEmp = new DevExpress.XtraGrid.GridControl();
            this.gridEmpView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDirect_Indirect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuitJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuitMaternity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsOfficialEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHREmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRBeginWorkingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHROfficialDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRQuitJobDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRSex = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpView)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit2
            // 
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(220, 444);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(117, 23);
            this.textEdit2.TabIndex = 19;
            this.textEdit2.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(220, 412);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(117, 23);
            this.textEdit1.TabIndex = 18;
            this.textEdit1.Visible = false;
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
            this.barMultiEditLine});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 11;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barMultiEditLine),
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
            this.barThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barThem.ImageOptions.Image")));
            this.barThem.Name = "barThem";
            // 
            // barXoa
            // 
            this.barXoa.Caption = "Xóa";
            this.barXoa.Id = 3;
            this.barXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXoa.ImageOptions.Image")));
            this.barXoa.Name = "barXoa";
            // 
            // barSua
            // 
            this.barSua.Caption = "Sửa";
            this.barSua.Id = 4;
            this.barSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSua.ImageOptions.Image")));
            this.barSua.Name = "barSua";
            // 
            // barMultiEditLine
            // 
            this.barMultiEditLine.Caption = "Cập nhật LINE";
            this.barMultiEditLine.Id = 10;
            this.barMultiEditLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barMultiEditLine.ImageOptions.Image")));
            this.barMultiEditLine.Name = "barMultiEditLine";
            this.barMultiEditLine.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barNapLai
            // 
            this.barNapLai.Caption = "Refresh";
            this.barNapLai.Id = 5;
            this.barNapLai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNapLai.ImageOptions.Image")));
            this.barNapLai.Name = "barNapLai";
            this.barNapLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNapLai_ItemClick);
            // 
            // barIn
            // 
            this.barIn.Caption = "In";
            this.barIn.Id = 6;
            this.barIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barIn.ImageOptions.Image")));
            this.barIn.Name = "barIn";
            this.barIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barIn_ItemClick);
            // 
            // barXuat
            // 
            this.barXuat.Caption = "Xuất Dữ Liệu";
            this.barXuat.Id = 7;
            this.barXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXuat.ImageOptions.Image")));
            this.barXuat.Name = "barXuat";
            this.barXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barXuat_ItemClick);
            // 
            // barNhap
            // 
            this.barNhap.Caption = "Nhập Dữ Liệu";
            this.barNhap.Id = 9;
            this.barNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNhap.ImageOptions.Image")));
            this.barNhap.Name = "barNhap";
            this.barNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNhap_ItemClick);
            // 
            // barThoat
            // 
            this.barThoat.Caption = "Đóng";
            this.barThoat.Id = 8;
            this.barThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barThoat.ImageOptions.Image")));
            this.barThoat.Name = "barThoat";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1194, 54);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 380);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1194, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 54);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 326);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1194, 54);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 326);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thêm";
            this.barButtonItem2.Id = 0;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Thêm";
            this.barButtonItem3.Id = 0;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridEmp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 326);
            this.panel1.TabIndex = 24;
            // 
            // gridEmp
            // 
            this.gridEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridEmp.Location = new System.Drawing.Point(0, 0);
            this.gridEmp.MainView = this.gridEmpView;
            this.gridEmp.Margin = new System.Windows.Forms.Padding(4);
            this.gridEmp.Name = "gridEmp";
            this.gridEmp.Size = new System.Drawing.Size(1194, 326);
            this.gridEmp.TabIndex = 25;
            this.gridEmp.UseEmbeddedNavigator = true;
            this.gridEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridEmpView});
            // 
            // gridEmpView
            // 
            this.gridEmpView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpID,
            this.colEmpName,
            this.colPosition,
            this.colDirect_Indirect,
            this.colLineID,
            this.colQuitJob,
            this.colQuitMaternity,
            this.colIsOfficialEmp,
            this.colHREmpID,
            this.colHRBeginWorkingDate,
            this.colHROfficialDate,
            this.colHRQuitJobDate,
            this.colHRSex,
            this.colDescription});
            this.gridEmpView.DetailHeight = 431;
            this.gridEmpView.GridControl = this.gridEmp;
            this.gridEmpView.Name = "gridEmpView";
            this.gridEmpView.OptionsBehavior.Editable = false;
            this.gridEmpView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridEmpView.OptionsSelection.MultiSelect = true;
            this.gridEmpView.OptionsView.ShowAutoFilterRow = true;
            this.gridEmpView.OptionsView.ShowGroupPanel = false;
            // 
            // colEmpID
            // 
            this.colEmpID.Caption = "Mã nhân viên";
            this.colEmpID.FieldName = "EmpID";
            this.colEmpID.MinWidth = 23;
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.OptionsColumn.AllowEdit = false;
            this.colEmpID.Visible = true;
            this.colEmpID.VisibleIndex = 0;
            this.colEmpID.Width = 87;
            // 
            // colEmpName
            // 
            this.colEmpName.Caption = "Tên nhân viên";
            this.colEmpName.FieldName = "EmpName";
            this.colEmpName.MinWidth = 23;
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.OptionsColumn.AllowEdit = false;
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 1;
            this.colEmpName.Width = 87;
            // 
            // colPosition
            // 
            this.colPosition.Caption = "Chức vụ";
            this.colPosition.FieldName = "Position";
            this.colPosition.MinWidth = 23;
            this.colPosition.Name = "colPosition";
            this.colPosition.OptionsColumn.AllowEdit = false;
            this.colPosition.Visible = true;
            this.colPosition.VisibleIndex = 4;
            this.colPosition.Width = 87;
            // 
            // colDirect_Indirect
            // 
            this.colDirect_Indirect.Caption = "Direct/Indirect";
            this.colDirect_Indirect.FieldName = "Direct_Indirect";
            this.colDirect_Indirect.MinWidth = 23;
            this.colDirect_Indirect.Name = "colDirect_Indirect";
            this.colDirect_Indirect.OptionsColumn.AllowEdit = false;
            this.colDirect_Indirect.Visible = true;
            this.colDirect_Indirect.VisibleIndex = 2;
            this.colDirect_Indirect.Width = 87;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Mã Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 23;
            this.colLineID.Name = "colLineID";
            this.colLineID.OptionsColumn.AllowEdit = false;
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 3;
            this.colLineID.Width = 87;
            // 
            // colQuitJob
            // 
            this.colQuitJob.Caption = "Nghỉ việc";
            this.colQuitJob.FieldName = "QuitJob";
            this.colQuitJob.MinWidth = 25;
            this.colQuitJob.Name = "colQuitJob";
            this.colQuitJob.UnboundDataType = typeof(bool);
            this.colQuitJob.Visible = true;
            this.colQuitJob.VisibleIndex = 5;
            this.colQuitJob.Width = 94;
            // 
            // colQuitMaternity
            // 
            this.colQuitMaternity.Caption = "Nghỉ thai sản";
            this.colQuitMaternity.FieldName = "QuitMaternity";
            this.colQuitMaternity.MinWidth = 25;
            this.colQuitMaternity.Name = "colQuitMaternity";
            this.colQuitMaternity.UnboundDataType = typeof(bool);
            this.colQuitMaternity.Visible = true;
            this.colQuitMaternity.VisibleIndex = 6;
            this.colQuitMaternity.Width = 94;
            // 
            // colIsOfficialEmp
            // 
            this.colIsOfficialEmp.Caption = "Đã có mã chính thức";
            this.colIsOfficialEmp.FieldName = "IsOfficialEmp";
            this.colIsOfficialEmp.MinWidth = 25;
            this.colIsOfficialEmp.Name = "colIsOfficialEmp";
            this.colIsOfficialEmp.UnboundDataType = typeof(bool);
            this.colIsOfficialEmp.Visible = true;
            this.colIsOfficialEmp.VisibleIndex = 7;
            this.colIsOfficialEmp.Width = 94;
            // 
            // colHREmpID
            // 
            this.colHREmpID.Caption = "Mã nhân viên HR";
            this.colHREmpID.FieldName = "HREmpID";
            this.colHREmpID.MinWidth = 25;
            this.colHREmpID.Name = "colHREmpID";
            this.colHREmpID.Visible = true;
            this.colHREmpID.VisibleIndex = 8;
            this.colHREmpID.Width = 94;
            // 
            // colHRBeginWorkingDate
            // 
            this.colHRBeginWorkingDate.Caption = "Ngày vào làm";
            this.colHRBeginWorkingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colHRBeginWorkingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHRBeginWorkingDate.FieldName = "HRBeginWorkingDate";
            this.colHRBeginWorkingDate.MinWidth = 25;
            this.colHRBeginWorkingDate.Name = "colHRBeginWorkingDate";
            this.colHRBeginWorkingDate.UnboundDataType = typeof(System.DateTime);
            this.colHRBeginWorkingDate.Visible = true;
            this.colHRBeginWorkingDate.VisibleIndex = 9;
            this.colHRBeginWorkingDate.Width = 94;
            // 
            // colHROfficialDate
            // 
            this.colHROfficialDate.Caption = "Ngày chính thức";
            this.colHROfficialDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colHROfficialDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHROfficialDate.FieldName = "HROfficialDate";
            this.colHROfficialDate.MinWidth = 25;
            this.colHROfficialDate.Name = "colHROfficialDate";
            this.colHROfficialDate.UnboundDataType = typeof(System.DateTime);
            this.colHROfficialDate.Visible = true;
            this.colHROfficialDate.VisibleIndex = 10;
            this.colHROfficialDate.Width = 94;
            // 
            // colHRQuitJobDate
            // 
            this.colHRQuitJobDate.Caption = "Ngày nghỉ việc";
            this.colHRQuitJobDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colHRQuitJobDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHRQuitJobDate.FieldName = "HRQuitJobDate";
            this.colHRQuitJobDate.MinWidth = 25;
            this.colHRQuitJobDate.Name = "colHRQuitJobDate";
            this.colHRQuitJobDate.UnboundDataType = typeof(System.DateTime);
            this.colHRQuitJobDate.Visible = true;
            this.colHRQuitJobDate.VisibleIndex = 11;
            this.colHRQuitJobDate.Width = 94;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Ghi chú";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 25;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 13;
            this.colDescription.Width = 94;
            // 
            // colHRSex
            // 
            this.colHRSex.Caption = "Giới tính";
            this.colHRSex.FieldName = "HRSex";
            this.colHRSex.MinWidth = 25;
            this.colHRSex.Name = "colHRSex";
            this.colHRSex.Visible = true;
            this.colHRSex.VisibleIndex = 12;
            this.colHRSex.Width = 94;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 380);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private XUAT_NHAPTONDataSet12 xUAT_NHAPTONDataSet12;
        //private ASPProject.XUAT_NHAPTONDataSet12TableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barXoa;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barNapLai;
        private DevExpress.XtraBars.BarButtonItem barIn;
        private DevExpress.XtraBars.BarButtonItem barXuat;
        private DevExpress.XtraBars.BarButtonItem barThoat;
        private DevExpress.XtraBars.BarButtonItem barNhap;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridEmpView;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colDirect_Indirect;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraBars.BarButtonItem barMultiEditLine;
        private DevExpress.XtraGrid.Columns.GridColumn colQuitJob;
        private DevExpress.XtraGrid.Columns.GridColumn colHREmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colHRBeginWorkingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colHROfficialDate;
        private DevExpress.XtraGrid.Columns.GridColumn colHRQuitJobDate;
        private DevExpress.XtraGrid.Columns.GridColumn colQuitMaternity;
        private DevExpress.XtraGrid.Columns.GridColumn colIsOfficialEmp;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colHRSex;
        //private XUAT_NHAPTONDataSet33 xUAT_NHAPTONDataSet33;
        //private ASPProject.XUAT_NHAPTONDataSet33TableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter1;
        //private XUAT_NHAPTONDataSet36 xUAT_NHAPTONDataSet36;
        //private ASPProject.XUAT_NHAPTONDataSet36TableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter2;
    }
}