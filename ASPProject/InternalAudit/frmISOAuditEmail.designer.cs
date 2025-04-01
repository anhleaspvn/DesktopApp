namespace ASPProject
{
    partial class frmISOAuditEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmISOAuditEmail));
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.barXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridISOAuditEmail = new DevExpress.XtraGrid.GridControl();
            this.gridISOAuditEmailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DeptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FactoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GLSignedID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GLSignedEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HeadSignedID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HeadSignedEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptSignedID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeptSignedEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridISOAuditEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridISOAuditEmailView)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit2
            // 
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(189, 361);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 19;
            this.textEdit2.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(189, 335);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
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
            this.barXuat,
            this.barThoat});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barNapLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barXuat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            // barNapLai
            // 
            this.barNapLai.Caption = "Refresh";
            this.barNapLai.Id = 5;
            this.barNapLai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNapLai.ImageOptions.Image")));
            this.barNapLai.Name = "barNapLai";
            this.barNapLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNapLai_ItemClick);
            // 
            // barXuat
            // 
            this.barXuat.Caption = "Xuất Dữ Liệu";
            this.barXuat.Id = 7;
            this.barXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barXuat.ImageOptions.Image")));
            this.barXuat.Name = "barXuat";
            this.barXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barXuat_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1023, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 309);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1023, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 265);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1023, 44);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 265);
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
            this.panel1.Controls.Add(this.gridISOAuditEmail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 265);
            this.panel1.TabIndex = 24;
            // 
            // gridISOAuditEmail
            // 
            this.gridISOAuditEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridISOAuditEmail.Location = new System.Drawing.Point(0, 0);
            this.gridISOAuditEmail.MainView = this.gridISOAuditEmailView;
            this.gridISOAuditEmail.Name = "gridISOAuditEmail";
            this.gridISOAuditEmail.Size = new System.Drawing.Size(1023, 265);
            this.gridISOAuditEmail.TabIndex = 25;
            this.gridISOAuditEmail.UseEmbeddedNavigator = true;
            this.gridISOAuditEmail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridISOAuditEmailView});
            // 
            // gridISOAuditEmailView
            // 
            this.gridISOAuditEmailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DeptID,
            this.FactoryID,
            this.GLSignedID,
            this.GLSignedEmail,
            this.HeadSignedID,
            this.HeadSignedEmail,
            this.DeptSignedID,
            this.DeptSignedEmail});
            this.gridISOAuditEmailView.GridControl = this.gridISOAuditEmail;
            this.gridISOAuditEmailView.Name = "gridISOAuditEmailView";
            this.gridISOAuditEmailView.OptionsBehavior.Editable = false;
            this.gridISOAuditEmailView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridISOAuditEmailView.OptionsSelection.MultiSelect = true;
            this.gridISOAuditEmailView.OptionsView.ShowAutoFilterRow = true;
            this.gridISOAuditEmailView.OptionsView.ShowGroupPanel = false;
            // 
            // DeptID
            // 
            this.DeptID.Caption = "Mã bộ phận";
            this.DeptID.FieldName = "DeptID";
            this.DeptID.Name = "DeptID";
            this.DeptID.Visible = true;
            this.DeptID.VisibleIndex = 0;
            // 
            // FactoryID
            // 
            this.FactoryID.Caption = "Mã nhà máy";
            this.FactoryID.FieldName = "FactoryID";
            this.FactoryID.Name = "FactoryID";
            this.FactoryID.Visible = true;
            this.FactoryID.VisibleIndex = 1;
            // 
            // GLSignedID
            // 
            this.GLSignedID.Caption = "Trưởng nhóm";
            this.GLSignedID.FieldName = "GLSignedID";
            this.GLSignedID.Name = "GLSignedID";
            this.GLSignedID.Visible = true;
            this.GLSignedID.VisibleIndex = 2;
            // 
            // GLSignedEmail
            // 
            this.GLSignedEmail.Caption = "Email trưởng nhóm";
            this.GLSignedEmail.FieldName = "GLSignedEmail";
            this.GLSignedEmail.Name = "GLSignedEmail";
            this.GLSignedEmail.Visible = true;
            this.GLSignedEmail.VisibleIndex = 3;
            // 
            // HeadSignedID
            // 
            this.HeadSignedID.Caption = "Trưởng đoàn";
            this.HeadSignedID.FieldName = "HeadSignedID";
            this.HeadSignedID.Name = "HeadSignedID";
            this.HeadSignedID.Visible = true;
            this.HeadSignedID.VisibleIndex = 4;
            // 
            // HeadSignedEmail
            // 
            this.HeadSignedEmail.Caption = "Email trưởng đoàn";
            this.HeadSignedEmail.FieldName = "HeadSignedEmail";
            this.HeadSignedEmail.Name = "HeadSignedEmail";
            this.HeadSignedEmail.Visible = true;
            this.HeadSignedEmail.VisibleIndex = 5;
            // 
            // DeptSignedID
            // 
            this.DeptSignedID.Caption = "Trưởng bộ phận";
            this.DeptSignedID.FieldName = "DeptSignedID";
            this.DeptSignedID.Name = "DeptSignedID";
            this.DeptSignedID.Visible = true;
            this.DeptSignedID.VisibleIndex = 6;
            // 
            // DeptSignedEmail
            // 
            this.DeptSignedEmail.Caption = "Email trưởng BP";
            this.DeptSignedEmail.FieldName = "DeptSignedEmail";
            this.DeptSignedEmail.Name = "DeptSignedEmail";
            this.DeptSignedEmail.Visible = true;
            this.DeptSignedEmail.VisibleIndex = 7;
            // 
            // frmISOAuditEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 309);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmISOAuditEmail";
            this.Text = "frmISOAuditEmail";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridISOAuditEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridISOAuditEmailView)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem barXuat;
        private DevExpress.XtraBars.BarButtonItem barThoat;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridISOAuditEmail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridISOAuditEmailView;
        private DevExpress.XtraGrid.Columns.GridColumn DeptID;
        private DevExpress.XtraGrid.Columns.GridColumn FactoryID;
        private DevExpress.XtraGrid.Columns.GridColumn GLSignedEmail;
        private DevExpress.XtraGrid.Columns.GridColumn HeadSignedEmail;
        private DevExpress.XtraGrid.Columns.GridColumn DeptSignedEmail;
        private DevExpress.XtraGrid.Columns.GridColumn GLSignedID;
        private DevExpress.XtraGrid.Columns.GridColumn HeadSignedID;
        private DevExpress.XtraGrid.Columns.GridColumn DeptSignedID;
        //private XUAT_NHAPTONDataSet33 xUAT_NHAPTONDataSet33;
        //private ASPProject.XUAT_NHAPTONDataSet33TableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter1;
        //private XUAT_NHAPTONDataSet36 xUAT_NHAPTONDataSet36;
        //private ASPProject.XUAT_NHAPTONDataSet36TableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter2;
    }
}