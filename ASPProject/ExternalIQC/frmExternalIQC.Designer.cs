namespace ASPProject.ExternalIQC
{
    partial class frmExternalIQC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalIQC));
            this.btExportReport = new DevExpress.XtraEditors.SimpleButton();
            this.btStatEmpMulti = new DevExpress.XtraEditors.SimpleButton();
            this.btStatDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btStatEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btStatAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.barShowAll = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barDateFilter = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.barIn = new DevExpress.XtraBars.BarButtonItem();
            this.barXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barLocNgay = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.dtpFromDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.dtpToDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.cboStatus = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridIQCHeader = new DevExpress.XtraGrid.GridControl();
            this.gridIQCHeaderView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFactoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQCID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdReqQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStateOfChecking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPageProdStatDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabCheckContent = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridCheckContent = new DevExpress.XtraGrid.GridControl();
            this.gridCheckContentView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIQCCheckID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIQCCheckName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIQCCheckCont = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIQCTemplateQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIQCEvalueResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIQCPeriodTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDefect = new DevExpress.XtraGrid.GridControl();
            this.gridDefectView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDefectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefectQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabActualChecking = new DevExpress.XtraTab.XtraTabPage();
            this.gridActualCheck = new DevExpress.XtraGrid.GridControl();
            this.gridActualCheckView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IQCCheckID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCCheckName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCDFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCCheckingContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCStandardMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCStandardMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCEvalueActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCEvalueCheckTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCEvalueResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCDeviceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IQCMeasuringToolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIQCHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIQCHeaderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProdStatDetail)).BeginInit();
            this.tabPageProdStatDetail.SuspendLayout();
            this.tabCheckContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckContentView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefectView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tabActualChecking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActualCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActualCheckView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btExportReport
            // 
            this.btExportReport.ImageOptions.Image = global::ASPProject.Properties.Resources.report1;
            this.btExportReport.Location = new System.Drawing.Point(722, 11);
            this.btExportReport.Name = "btExportReport";
            this.btExportReport.Size = new System.Drawing.Size(161, 35);
            this.btExportReport.TabIndex = 4;
            this.btExportReport.Text = "Xuất báo cáo";
            // 
            // btStatEmpMulti
            // 
            this.btStatEmpMulti.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btStatEmpMulti.ImageOptions.Image")));
            this.btStatEmpMulti.Location = new System.Drawing.Point(156, 11);
            this.btStatEmpMulti.Name = "btStatEmpMulti";
            this.btStatEmpMulti.Size = new System.Drawing.Size(161, 35);
            this.btStatEmpMulti.TabIndex = 3;
            this.btStatEmpMulti.Text = "Sửa nhiều dòng";
            // 
            // btStatDelete
            // 
            this.btStatDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btStatDelete.Location = new System.Drawing.Point(156, 11);
            this.btStatDelete.Name = "btStatDelete";
            this.btStatDelete.Size = new System.Drawing.Size(120, 35);
            this.btStatDelete.TabIndex = 2;
            this.btStatDelete.Text = "Xoá";
            // 
            // btStatEdit
            // 
            this.btStatEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btStatEdit.ImageOptions.Image")));
            this.btStatEdit.Location = new System.Drawing.Point(156, 11);
            this.btStatEdit.Name = "btStatEdit";
            this.btStatEdit.Size = new System.Drawing.Size(120, 35);
            this.btStatEdit.TabIndex = 1;
            this.btStatEdit.Text = "Sửa";
            this.btStatEdit.Visible = false;
            // 
            // btStatAdd
            // 
            this.btStatAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btStatAdd.ImageOptions.Image")));
            this.btStatAdd.Location = new System.Drawing.Point(16, 11);
            this.btStatAdd.Name = "btStatAdd";
            this.btStatAdd.Size = new System.Drawing.Size(120, 35);
            this.btStatAdd.TabIndex = 0;
            this.btStatAdd.Text = "Thêm";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btExportReport);
            this.panel2.Controls.Add(this.btStatEmpMulti);
            this.panel2.Controls.Add(this.btStatDelete);
            this.panel2.Controls.Add(this.btStatEdit);
            this.panel2.Controls.Add(this.btStatAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 554);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1700, 59);
            this.panel2.TabIndex = 29;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Thêm";
            this.barButtonItem3.Id = 0;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thêm";
            this.barButtonItem2.Id = 0;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "Hiện tất cả";
            this.barCheckItem2.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.barCheckItem2.Id = 14;
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // barShowAll
            // 
            this.barShowAll.Caption = "Hiển thị tất cả LSX";
            this.barShowAll.Edit = this.repositoryItemCheckEdit1;
            this.barShowAll.Id = 13;
            this.barShowAll.Name = "barShowAll";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Hiện tất cả";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 12;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barDateFilter
            // 
            this.barDateFilter.Caption = "Lọc ngày";
            this.barDateFilter.Id = 11;
            this.barDateFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.barDateFilter.ImageOptions.LargeImage = global::ASPProject.Properties.Resources.preview_file;
            this.barDateFilter.Name = "barDateFilter";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemDateEdit1;
            this.barEditItem1.Id = 10;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1700, 54);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 613);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
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
            this.barEditItem1,
            this.barDateFilter,
            this.barCheckItem1,
            this.barShowAll,
            this.barCheckItem2,
            this.barButtonItem1,
            this.barLocNgay,
            this.barStaticItem1,
            this.dtpFromDate,
            this.barStaticItem2,
            this.dtpToDate,
            this.barStaticItem3,
            this.cboStatus});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 30;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemDateEdit2,
            this.repositoryItemDateEdit3,
            this.repositoryItemComboBox2});
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barNapLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barXuat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barNhap, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLocNgay),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.dtpFromDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.dtpToDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.cboStatus)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
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
            // barNapLai
            // 
            this.barNapLai.Caption = "Refresh";
            this.barNapLai.Id = 5;
            this.barNapLai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNapLai.ImageOptions.Image")));
            this.barNapLai.Name = "barNapLai";
            // 
            // barIn
            // 
            this.barIn.Caption = "In";
            this.barIn.Id = 6;
            this.barIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barIn.ImageOptions.Image")));
            this.barIn.Name = "barIn";
            // 
            // barXuat
            // 
            this.barXuat.Caption = "Xuất Dữ Liệu";
            this.barXuat.Id = 7;
            this.barXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXuat.ImageOptions.Image")));
            this.barXuat.Name = "barXuat";
            // 
            // barNhap
            // 
            this.barNhap.Caption = "Nhập Dữ Liệu";
            this.barNhap.Id = 9;
            this.barNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNhap.ImageOptions.Image")));
            this.barNhap.Name = "barNhap";
            // 
            // barThoat
            // 
            this.barThoat.Caption = "Đóng";
            this.barThoat.Id = 8;
            this.barThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barThoat.ImageOptions.Image")));
            this.barThoat.Name = "barThoat";
            // 
            // barLocNgay
            // 
            this.barLocNgay.Caption = "Lọc";
            this.barLocNgay.Id = 23;
            this.barLocNgay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barLocNgay.ImageOptions.Image")));
            this.barLocNgay.Name = "barLocNgay";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Từ ngày";
            this.barStaticItem1.Id = 24;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Caption = "barEditItem2";
            this.dtpFromDate.Edit = this.repositoryItemDateEdit2;
            this.dtpFromDate.Id = 25;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 0);
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "Đến ngày";
            this.barStaticItem2.Id = 26;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Caption = "barEditItem2";
            this.dtpToDate.Edit = this.repositoryItemDateEdit3;
            this.dtpToDate.Id = 27;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 0);
            // 
            // repositoryItemDateEdit3
            // 
            this.repositoryItemDateEdit3.AutoHeight = false;
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "Tình trạng SX";
            this.barStaticItem3.Id = 28;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // cboStatus
            // 
            this.cboStatus.Caption = "barEditItem2";
            this.cboStatus.Edit = this.repositoryItemComboBox2;
            this.cboStatus.Id = 29;
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(120, 0);
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1700, 54);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 667);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1700, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 54);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 613);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 22;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridIQCHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPageProdStatDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1700, 554);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 2;
            // 
            // gridIQCHeader
            // 
            this.gridIQCHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIQCHeader.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridIQCHeader.Location = new System.Drawing.Point(0, 0);
            this.gridIQCHeader.MainView = this.gridIQCHeaderView;
            this.gridIQCHeader.Margin = new System.Windows.Forms.Padding(4);
            this.gridIQCHeader.Name = "gridIQCHeader";
            this.gridIQCHeader.Size = new System.Drawing.Size(1700, 205);
            this.gridIQCHeader.TabIndex = 29;
            this.gridIQCHeader.UseEmbeddedNavigator = true;
            this.gridIQCHeader.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridIQCHeaderView,
            this.gridView1});
            // 
            // gridIQCHeaderView
            // 
            this.gridIQCHeaderView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFactoryID,
            this.colDocDate,
            this.colLineID,
            this.colQCID,
            this.colProductID,
            this.colWODocNo,
            this.colProdReqQuantity,
            this.colCustomerID,
            this.colProdStatus,
            this.colCheckState,
            this.colStateOfChecking});
            this.gridIQCHeaderView.DetailHeight = 431;
            this.gridIQCHeaderView.GridControl = this.gridIQCHeader;
            this.gridIQCHeaderView.Name = "gridIQCHeaderView";
            this.gridIQCHeaderView.OptionsBehavior.Editable = false;
            this.gridIQCHeaderView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridIQCHeaderView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridIQCHeaderView.OptionsView.ShowAutoFilterRow = true;
            this.gridIQCHeaderView.OptionsView.ShowGroupPanel = false;
            // 
            // colFactoryID
            // 
            this.colFactoryID.Caption = "Mã nhà máy";
            this.colFactoryID.FieldName = "FactoryID";
            this.colFactoryID.MinWidth = 25;
            this.colFactoryID.Name = "colFactoryID";
            this.colFactoryID.Visible = true;
            this.colFactoryID.VisibleIndex = 10;
            this.colFactoryID.Width = 94;
            // 
            // colDocDate
            // 
            this.colDocDate.Caption = "Ngày chứng từ";
            this.colDocDate.FieldName = "DocDate";
            this.colDocDate.MinWidth = 25;
            this.colDocDate.Name = "colDocDate";
            this.colDocDate.Visible = true;
            this.colDocDate.VisibleIndex = 0;
            this.colDocDate.Width = 94;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Mã Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 25;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 1;
            this.colLineID.Width = 94;
            // 
            // colQCID
            // 
            this.colQCID.Caption = "Mã QC";
            this.colQCID.FieldName = "QCID";
            this.colQCID.MinWidth = 25;
            this.colQCID.Name = "colQCID";
            this.colQCID.Visible = true;
            this.colQCID.VisibleIndex = 2;
            this.colQCID.Width = 94;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 25;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 3;
            this.colProductID.Width = 94;
            // 
            // colWODocNo
            // 
            this.colWODocNo.Caption = "Số lệnh sản xuất";
            this.colWODocNo.FieldName = "WODocNo";
            this.colWODocNo.MinWidth = 25;
            this.colWODocNo.Name = "colWODocNo";
            this.colWODocNo.Visible = true;
            this.colWODocNo.VisibleIndex = 4;
            this.colWODocNo.Width = 94;
            // 
            // colProdReqQuantity
            // 
            this.colProdReqQuantity.Caption = "Số lượng yêu cầu";
            this.colProdReqQuantity.FieldName = "ProdReqQuantity";
            this.colProdReqQuantity.MinWidth = 25;
            this.colProdReqQuantity.Name = "colProdReqQuantity";
            this.colProdReqQuantity.Visible = true;
            this.colProdReqQuantity.VisibleIndex = 5;
            this.colProdReqQuantity.Width = 94;
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Mã khách hàng";
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.MinWidth = 25;
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 6;
            this.colCustomerID.Width = 94;
            // 
            // colProdStatus
            // 
            this.colProdStatus.Caption = "Tình trạng SX";
            this.colProdStatus.FieldName = "ProdStatus";
            this.colProdStatus.MinWidth = 25;
            this.colProdStatus.Name = "colProdStatus";
            this.colProdStatus.Visible = true;
            this.colProdStatus.VisibleIndex = 7;
            this.colProdStatus.Width = 94;
            // 
            // colCheckState
            // 
            this.colCheckState.Caption = "Trạng thái KT";
            this.colCheckState.FieldName = "CheckState";
            this.colCheckState.MinWidth = 25;
            this.colCheckState.Name = "colCheckState";
            this.colCheckState.Visible = true;
            this.colCheckState.VisibleIndex = 8;
            this.colCheckState.Width = 94;
            // 
            // colStateOfChecking
            // 
            this.colStateOfChecking.Caption = "Công đoạn KT";
            this.colStateOfChecking.FieldName = "StateOfChecking";
            this.colStateOfChecking.MinWidth = 25;
            this.colStateOfChecking.Name = "colStateOfChecking";
            this.colStateOfChecking.Visible = true;
            this.colStateOfChecking.VisibleIndex = 9;
            this.colStateOfChecking.Width = 94;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridIQCHeader;
            this.gridView1.Name = "gridView1";
            // 
            // tabPageProdStatDetail
            // 
            this.tabPageProdStatDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageProdStatDetail.Location = new System.Drawing.Point(0, 0);
            this.tabPageProdStatDetail.Name = "tabPageProdStatDetail";
            this.tabPageProdStatDetail.SelectedTabPage = this.tabCheckContent;
            this.tabPageProdStatDetail.Size = new System.Drawing.Size(1700, 345);
            this.tabPageProdStatDetail.TabIndex = 0;
            this.tabPageProdStatDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabCheckContent,
            this.tabActualChecking});
            // 
            // tabCheckContent
            // 
            this.tabCheckContent.Controls.Add(this.splitContainerControl1);
            this.tabCheckContent.Name = "tabCheckContent";
            this.tabCheckContent.Size = new System.Drawing.Size(1694, 313);
            this.tabCheckContent.Text = "Ngoại quan";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gridCheckContent);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridDefect);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1694, 313);
            this.splitContainerControl1.SplitterPosition = 1172;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gridCheckContent
            // 
            this.gridCheckContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCheckContent.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridCheckContent.Location = new System.Drawing.Point(0, 0);
            this.gridCheckContent.MainView = this.gridCheckContentView;
            this.gridCheckContent.Margin = new System.Windows.Forms.Padding(4);
            this.gridCheckContent.Name = "gridCheckContent";
            this.gridCheckContent.Size = new System.Drawing.Size(1172, 313);
            this.gridCheckContent.TabIndex = 30;
            this.gridCheckContent.UseEmbeddedNavigator = true;
            this.gridCheckContent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridCheckContentView,
            this.gridView3});
            // 
            // gridCheckContentView
            // 
            this.gridCheckContentView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIQCCheckID,
            this.colIQCCheckName,
            this.colIQCCheckCont,
            this.colIQCTemplateQuantity,
            this.colIQCEvalueResult,
            this.colIQCPeriodTime});
            this.gridCheckContentView.DetailHeight = 431;
            this.gridCheckContentView.GridControl = this.gridCheckContent;
            this.gridCheckContentView.Name = "gridCheckContentView";
            this.gridCheckContentView.OptionsBehavior.Editable = false;
            this.gridCheckContentView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridCheckContentView.OptionsSelection.MultiSelect = true;
            this.gridCheckContentView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridCheckContentView.OptionsView.ShowAutoFilterRow = true;
            this.gridCheckContentView.OptionsView.ShowGroupPanel = false;
            // 
            // colIQCCheckID
            // 
            this.colIQCCheckID.Caption = "Công đoạn";
            this.colIQCCheckID.FieldName = "IQCCheckID";
            this.colIQCCheckID.MinWidth = 25;
            this.colIQCCheckID.Name = "colIQCCheckID";
            this.colIQCCheckID.Visible = true;
            this.colIQCCheckID.VisibleIndex = 1;
            this.colIQCCheckID.Width = 94;
            // 
            // colIQCCheckName
            // 
            this.colIQCCheckName.Caption = "Tên công đoạn";
            this.colIQCCheckName.FieldName = "IQCCheckName";
            this.colIQCCheckName.MinWidth = 25;
            this.colIQCCheckName.Name = "colIQCCheckName";
            this.colIQCCheckName.Visible = true;
            this.colIQCCheckName.VisibleIndex = 2;
            this.colIQCCheckName.Width = 94;
            // 
            // colIQCCheckCont
            // 
            this.colIQCCheckCont.Caption = "Nội dung";
            this.colIQCCheckCont.FieldName = "IQCCheckCont";
            this.colIQCCheckCont.MinWidth = 25;
            this.colIQCCheckCont.Name = "colIQCCheckCont";
            this.colIQCCheckCont.Visible = true;
            this.colIQCCheckCont.VisibleIndex = 3;
            this.colIQCCheckCont.Width = 94;
            // 
            // colIQCTemplateQuantity
            // 
            this.colIQCTemplateQuantity.Caption = "Số lượng mẫu";
            this.colIQCTemplateQuantity.FieldName = "IQCTemplateQuantity";
            this.colIQCTemplateQuantity.MinWidth = 25;
            this.colIQCTemplateQuantity.Name = "colIQCTemplateQuantity";
            this.colIQCTemplateQuantity.Visible = true;
            this.colIQCTemplateQuantity.VisibleIndex = 4;
            this.colIQCTemplateQuantity.Width = 94;
            // 
            // colIQCEvalueResult
            // 
            this.colIQCEvalueResult.Caption = "Kết quả kiểm tra";
            this.colIQCEvalueResult.FieldName = "IQCEvalueResult";
            this.colIQCEvalueResult.MinWidth = 25;
            this.colIQCEvalueResult.Name = "colIQCEvalueResult";
            this.colIQCEvalueResult.Visible = true;
            this.colIQCEvalueResult.VisibleIndex = 5;
            this.colIQCEvalueResult.Width = 94;
            // 
            // colIQCPeriodTime
            // 
            this.colIQCPeriodTime.Caption = "Thời gian kiểm tra";
            this.colIQCPeriodTime.FieldName = "IQCPeriodTime";
            this.colIQCPeriodTime.MinWidth = 25;
            this.colIQCPeriodTime.Name = "colIQCPeriodTime";
            this.colIQCPeriodTime.Visible = true;
            this.colIQCPeriodTime.VisibleIndex = 6;
            this.colIQCPeriodTime.Width = 94;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridCheckContent;
            this.gridView3.Name = "gridView3";
            // 
            // gridDefect
            // 
            this.gridDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDefect.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridDefect.Location = new System.Drawing.Point(0, 0);
            this.gridDefect.MainView = this.gridDefectView;
            this.gridDefect.Margin = new System.Windows.Forms.Padding(4);
            this.gridDefect.Name = "gridDefect";
            this.gridDefect.Size = new System.Drawing.Size(515, 313);
            this.gridDefect.TabIndex = 29;
            this.gridDefect.UseEmbeddedNavigator = true;
            this.gridDefect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDefectView,
            this.gridView2});
            // 
            // gridDefectView
            // 
            this.gridDefectView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDefectID,
            this.colDefectName,
            this.colDefectQuantity});
            this.gridDefectView.DetailHeight = 431;
            this.gridDefectView.GridControl = this.gridDefect;
            this.gridDefectView.Name = "gridDefectView";
            this.gridDefectView.OptionsBehavior.Editable = false;
            this.gridDefectView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridDefectView.OptionsSelection.MultiSelect = true;
            this.gridDefectView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridDefectView.OptionsView.ShowAutoFilterRow = true;
            this.gridDefectView.OptionsView.ShowGroupPanel = false;
            // 
            // colDefectID
            // 
            this.colDefectID.Caption = "Mã defect";
            this.colDefectID.FieldName = "DefectID";
            this.colDefectID.MinWidth = 25;
            this.colDefectID.Name = "colDefectID";
            this.colDefectID.Visible = true;
            this.colDefectID.VisibleIndex = 1;
            this.colDefectID.Width = 94;
            // 
            // colDefectName
            // 
            this.colDefectName.Caption = "Tên Defect";
            this.colDefectName.FieldName = "DefectName";
            this.colDefectName.MinWidth = 25;
            this.colDefectName.Name = "colDefectName";
            this.colDefectName.Visible = true;
            this.colDefectName.VisibleIndex = 2;
            this.colDefectName.Width = 94;
            // 
            // colDefectQuantity
            // 
            this.colDefectQuantity.Caption = "Số lượng";
            this.colDefectQuantity.DisplayFormat.FormatString = "#0.00";
            this.colDefectQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDefectQuantity.FieldName = "DefectQuantity";
            this.colDefectQuantity.MinWidth = 25;
            this.colDefectQuantity.Name = "colDefectQuantity";
            this.colDefectQuantity.Visible = true;
            this.colDefectQuantity.VisibleIndex = 3;
            this.colDefectQuantity.Width = 94;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridDefect;
            this.gridView2.Name = "gridView2";
            // 
            // tabActualChecking
            // 
            this.tabActualChecking.Controls.Add(this.gridActualCheck);
            this.tabActualChecking.Name = "tabActualChecking";
            this.tabActualChecking.Size = new System.Drawing.Size(1694, 313);
            this.tabActualChecking.Text = "Dim Function";
            // 
            // gridActualCheck
            // 
            this.gridActualCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridActualCheck.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridActualCheck.Location = new System.Drawing.Point(0, 0);
            this.gridActualCheck.MainView = this.gridActualCheckView;
            this.gridActualCheck.Margin = new System.Windows.Forms.Padding(4);
            this.gridActualCheck.Name = "gridActualCheck";
            this.gridActualCheck.Size = new System.Drawing.Size(1694, 313);
            this.gridActualCheck.TabIndex = 29;
            this.gridActualCheck.UseEmbeddedNavigator = true;
            this.gridActualCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridActualCheckView,
            this.gridView4});
            // 
            // gridActualCheckView
            // 
            this.gridActualCheckView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IQCCheckID,
            this.IQCCheckName,
            this.IQCDFID,
            this.IQCCheckingContent,
            this.IQCStandardMin,
            this.IQCStandardMax,
            this.IQCEvalueActual,
            this.IQCEvalueCheckTime,
            this.IQCEvalueResult,
            this.IQCDeviceID,
            this.IQCMeasuringToolID});
            this.gridActualCheckView.DetailHeight = 431;
            this.gridActualCheckView.GridControl = this.gridActualCheck;
            this.gridActualCheckView.Name = "gridActualCheckView";
            this.gridActualCheckView.OptionsBehavior.Editable = false;
            this.gridActualCheckView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridActualCheckView.OptionsSelection.MultiSelect = true;
            this.gridActualCheckView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridActualCheckView.OptionsView.ShowAutoFilterRow = true;
            this.gridActualCheckView.OptionsView.ShowGroupPanel = false;
            // 
            // IQCCheckID
            // 
            this.IQCCheckID.Caption = "ID";
            this.IQCCheckID.FieldName = "IQCCheckID";
            this.IQCCheckID.MinWidth = 25;
            this.IQCCheckID.Name = "IQCCheckID";
            this.IQCCheckID.Visible = true;
            this.IQCCheckID.VisibleIndex = 1;
            this.IQCCheckID.Width = 94;
            // 
            // IQCCheckName
            // 
            this.IQCCheckName.Caption = "Mô tả công đoạn";
            this.IQCCheckName.FieldName = "IQCCheckName";
            this.IQCCheckName.MinWidth = 25;
            this.IQCCheckName.Name = "IQCCheckName";
            this.IQCCheckName.Visible = true;
            this.IQCCheckName.VisibleIndex = 2;
            this.IQCCheckName.Width = 94;
            // 
            // IQCDFID
            // 
            this.IQCDFID.Caption = "Mã công đoạn";
            this.IQCDFID.FieldName = "IQCDFID";
            this.IQCDFID.MinWidth = 25;
            this.IQCDFID.Name = "IQCDFID";
            this.IQCDFID.Visible = true;
            this.IQCDFID.VisibleIndex = 3;
            this.IQCDFID.Width = 94;
            // 
            // IQCCheckingContent
            // 
            this.IQCCheckingContent.Caption = "Hạng mục KT";
            this.IQCCheckingContent.FieldName = "IQCCheckingContent";
            this.IQCCheckingContent.MinWidth = 25;
            this.IQCCheckingContent.Name = "IQCCheckingContent";
            this.IQCCheckingContent.Visible = true;
            this.IQCCheckingContent.VisibleIndex = 4;
            this.IQCCheckingContent.Width = 94;
            // 
            // IQCStandardMin
            // 
            this.IQCStandardMin.Caption = "Tiêu chuẩn Min";
            this.IQCStandardMin.FieldName = "IQCStandardMin";
            this.IQCStandardMin.MinWidth = 25;
            this.IQCStandardMin.Name = "IQCStandardMin";
            this.IQCStandardMin.Visible = true;
            this.IQCStandardMin.VisibleIndex = 5;
            this.IQCStandardMin.Width = 94;
            // 
            // IQCStandardMax
            // 
            this.IQCStandardMax.Caption = "Tiêu chuẩn Max";
            this.IQCStandardMax.FieldName = "IQCStandardMax";
            this.IQCStandardMax.MinWidth = 25;
            this.IQCStandardMax.Name = "IQCStandardMax";
            this.IQCStandardMax.Visible = true;
            this.IQCStandardMax.VisibleIndex = 6;
            this.IQCStandardMax.Width = 94;
            // 
            // IQCEvalueActual
            // 
            this.IQCEvalueActual.Caption = "Thực tế kiểm tra";
            this.IQCEvalueActual.FieldName = "IQCEvalueActual";
            this.IQCEvalueActual.MinWidth = 25;
            this.IQCEvalueActual.Name = "IQCEvalueActual";
            this.IQCEvalueActual.Visible = true;
            this.IQCEvalueActual.VisibleIndex = 7;
            this.IQCEvalueActual.Width = 94;
            // 
            // IQCEvalueCheckTime
            // 
            this.IQCEvalueCheckTime.Caption = "Thời gian KT";
            this.IQCEvalueCheckTime.FieldName = "IQCEvalueCheckTime";
            this.IQCEvalueCheckTime.MinWidth = 25;
            this.IQCEvalueCheckTime.Name = "IQCEvalueCheckTime";
            this.IQCEvalueCheckTime.Visible = true;
            this.IQCEvalueCheckTime.VisibleIndex = 8;
            this.IQCEvalueCheckTime.Width = 94;
            // 
            // IQCEvalueResult
            // 
            this.IQCEvalueResult.Caption = "Phán định";
            this.IQCEvalueResult.FieldName = "IQCEvalueResult";
            this.IQCEvalueResult.MinWidth = 25;
            this.IQCEvalueResult.Name = "IQCEvalueResult";
            this.IQCEvalueResult.Visible = true;
            this.IQCEvalueResult.VisibleIndex = 11;
            this.IQCEvalueResult.Width = 94;
            // 
            // IQCDeviceID
            // 
            this.IQCDeviceID.Caption = "Mã thiết bị";
            this.IQCDeviceID.FieldName = "IQCDeviceID";
            this.IQCDeviceID.MinWidth = 25;
            this.IQCDeviceID.Name = "IQCDeviceID";
            this.IQCDeviceID.Visible = true;
            this.IQCDeviceID.VisibleIndex = 9;
            this.IQCDeviceID.Width = 94;
            // 
            // IQCMeasuringToolID
            // 
            this.IQCMeasuringToolID.Caption = "Mã công cụ đo";
            this.IQCMeasuringToolID.FieldName = "IQCMeasuringToolID";
            this.IQCMeasuringToolID.MinWidth = 25;
            this.IQCMeasuringToolID.Name = "IQCMeasuringToolID";
            this.IQCMeasuringToolID.Visible = true;
            this.IQCMeasuringToolID.VisibleIndex = 10;
            this.IQCMeasuringToolID.Width = 94;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gridActualCheck;
            this.gridView4.Name = "gridView4";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1700, 613);
            this.panel1.TabIndex = 32;
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1700, 54);
            this.barDockControl4.Manager = null;
            this.barDockControl4.Size = new System.Drawing.Size(0, 613);
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(275, 268);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(5);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(146, 23);
            this.textEdit1.TabIndex = 34;
            this.textEdit1.Visible = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // frmExternalIQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 667);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExternalIQC";
            this.Text = "frmExternalIQC";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIQCHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIQCHeaderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProdStatDetail)).EndInit();
            this.tabPageProdStatDetail.ResumeLayout(false);
            this.tabCheckContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckContentView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefectView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tabActualChecking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridActualCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridActualCheckView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btExportReport;
        private DevExpress.XtraEditors.SimpleButton btStatEmpMulti;
        private DevExpress.XtraEditors.SimpleButton btStatDelete;
        private DevExpress.XtraEditors.SimpleButton btStatEdit;
        private DevExpress.XtraEditors.SimpleButton btStatAdd;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.BarEditItem barShowAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barDateFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barXoa;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barNapLai;
        private DevExpress.XtraBars.BarButtonItem barIn;
        private DevExpress.XtraBars.BarButtonItem barXuat;
        private DevExpress.XtraBars.BarButtonItem barNhap;
        private DevExpress.XtraBars.BarButtonItem barThoat;
      
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraTab.XtraTabControl tabPageProdStatDetail;
        private DevExpress.XtraTab.XtraTabPage tabCheckContent;
        private DevExpress.XtraTab.XtraTabPage tabActualChecking;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraGrid.GridControl gridIQCHeader;
        private DevExpress.XtraGrid.Views.Grid.GridView gridIQCHeaderView;
        private DevExpress.XtraGrid.Columns.GridColumn colFactoryID;
        private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colQCID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colWODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProdReqQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colProdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckState;
        private DevExpress.XtraGrid.Columns.GridColumn colStateOfChecking;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridActualCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView gridActualCheckView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn IQCCheckID;
        private DevExpress.XtraGrid.Columns.GridColumn IQCCheckName;
        private DevExpress.XtraGrid.Columns.GridColumn IQCStandardMin;
        private DevExpress.XtraGrid.Columns.GridColumn IQCEvalueActual;
        private DevExpress.XtraGrid.Columns.GridColumn IQCDFID;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barLocNgay;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem dtpFromDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarEditItem dtpToDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarEditItem cboStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridCheckContent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridCheckContentView;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCCheckID;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCCheckName;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCTemplateQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCEvalueResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.GridControl gridDefect;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDefectView;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectID;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectName;
        private DevExpress.XtraGrid.Columns.GridColumn colDefectQuantity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCPeriodTime;
        private DevExpress.XtraGrid.Columns.GridColumn IQCEvalueResult;
        private DevExpress.XtraGrid.Columns.GridColumn colIQCCheckCont;
        private DevExpress.XtraGrid.Columns.GridColumn IQCCheckingContent;
        private DevExpress.XtraGrid.Columns.GridColumn IQCEvalueCheckTime;
        private DevExpress.XtraGrid.Columns.GridColumn IQCDeviceID;
        private DevExpress.XtraGrid.Columns.GridColumn IQCMeasuringToolID;
        private DevExpress.XtraGrid.Columns.GridColumn IQCStandardMax;
    }
}