namespace ASPProject.AlternatingLeaveSchedule
{
    partial class frmALSRegistered
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmALSRegistered));
            this.gridControl_Registered = new DevExpress.XtraGrid.GridControl();
            this.gridView_Registered = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablePanelHeader = new DevExpress.Utils.Layout.TablePanel();
            this.lblSubTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.panelFilter = new DevExpress.XtraEditors.PanelControl();
            this.tablePanelFilter = new DevExpress.Utils.Layout.TablePanel();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnrefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoc_Thang_Nam = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditFilter = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Registered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Registered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelHeader)).BeginInit();
            this.tablePanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFilter)).BeginInit();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelFilter)).BeginInit();
            this.tablePanelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Registered
            // 
            this.gridControl_Registered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Registered.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl_Registered.Location = new System.Drawing.Point(0, 124);
            this.gridControl_Registered.MainView = this.gridView_Registered;
            this.gridControl_Registered.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl_Registered.Name = "gridControl_Registered";
            this.gridControl_Registered.Size = new System.Drawing.Size(1600, 709);
            this.gridControl_Registered.TabIndex = 2;
            this.gridControl_Registered.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Registered});
            // 
            // gridView_Registered
            // 
            this.gridView_Registered.DetailHeight = 431;
            this.gridView_Registered.GridControl = this.gridControl_Registered;
            this.gridView_Registered.Name = "gridView_Registered";
            // 
            // tablePanelHeader
            // 
            this.tablePanelHeader.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tablePanelHeader.Appearance.Options.UseBackColor = true;
            this.tablePanelHeader.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanelHeader.Controls.Add(this.lblSubTitle);
            this.tablePanelHeader.Controls.Add(this.lblTitle);
            this.tablePanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tablePanelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.tablePanelHeader.Name = "tablePanelHeader";
            this.tablePanelHeader.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 38F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanelHeader.Size = new System.Drawing.Size(1600, 68);
            this.tablePanelHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblSubTitle.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubTitle.Appearance.Options.UseFont = true;
            this.lblSubTitle.Appearance.Options.UseForeColor = true;
            this.lblSubTitle.Appearance.Options.UseTextOptions = true;
            this.lblSubTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblSubTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablePanelHeader.SetColumn(this.lblSubTitle, 0);
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubTitle.Location = new System.Drawing.Point(4, 42);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lblSubTitle.Name = "lblSubTitle";
            this.tablePanelHeader.SetRow(this.lblSubTitle, 1);
            this.lblSubTitle.Size = new System.Drawing.Size(1592, 22);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "REGISTERED ALTERNATE LEAVE SCHEDULE / WFH LIST";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablePanelHeader.SetColumn(this.lblTitle, 0);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitle.Name = "lblTitle";
            this.tablePanelHeader.SetRow(this.lblTitle, 0);
            this.lblTitle.Size = new System.Drawing.Size(1592, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH SÁCH ĐĂNG KÝ LỊCH NGHỈ LUÂN PHIÊN THỨ BẢY / WFH";
            // 
            // panelFilter
            // 
            this.panelFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFilter.Controls.Add(this.tablePanelFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 68);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1600, 56);
            this.panelFilter.TabIndex = 1;
            // 
            // tablePanelFilter
            // 
            this.tablePanelFilter.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 16F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 0F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 12F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 135F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 125F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 135F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 105F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 16F)});
            this.tablePanelFilter.Controls.Add(this.btnExit);
            this.tablePanelFilter.Controls.Add(this.btnExcel);
            this.tablePanelFilter.Controls.Add(this.btnrefresh);
            this.tablePanelFilter.Controls.Add(this.btnLoc_Thang_Nam);
            this.tablePanelFilter.Controls.Add(this.dateEditFilter);
            this.tablePanelFilter.Controls.Add(this.labelControl1);
            this.tablePanelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelFilter.Location = new System.Drawing.Point(0, 0);
            this.tablePanelFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tablePanelFilter.Name = "tablePanelFilter";
            this.tablePanelFilter.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 46F)});
            this.tablePanelFilter.Size = new System.Drawing.Size(1600, 56);
            this.tablePanelFilter.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.tablePanelFilter.SetColumn(this.btnExit, 10);
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btnExit.Location = new System.Drawing.Point(1483, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.tablePanelFilter.SetRow(this.btnExit, 0);
            this.btnExit.Size = new System.Drawing.Size(97, 34);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Đóng";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(124)))), ((int)(((byte)(65)))));
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Appearance.Options.UseBackColor = true;
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Appearance.Options.UseForeColor = true;
            this.tablePanelFilter.SetColumn(this.btnExcel, 8);
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.Image")));
            this.btnExcel.Location = new System.Drawing.Point(1340, 11);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.tablePanelFilter.SetRow(this.btnExcel, 0);
            this.btnExcel.Size = new System.Drawing.Size(127, 34);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.Appearance.Options.UseFont = true;
            this.tablePanelFilter.SetColumn(this.btnrefresh, 6);
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.Location = new System.Drawing.Point(470, 11);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnrefresh.Name = "btnrefresh";
            this.tablePanelFilter.SetRow(this.btnrefresh, 0);
            this.btnrefresh.Size = new System.Drawing.Size(117, 34);
            this.btnrefresh.TabIndex = 3;
            this.btnrefresh.Text = "Làm Mới";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnLoc_Thang_Nam
            // 
            this.btnLoc_Thang_Nam.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc_Thang_Nam.Appearance.Options.UseFont = true;
            this.tablePanelFilter.SetColumn(this.btnLoc_Thang_Nam, 4);
            this.btnLoc_Thang_Nam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoc_Thang_Nam.Location = new System.Drawing.Point(327, 11);
            this.btnLoc_Thang_Nam.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoc_Thang_Nam.Name = "btnLoc_Thang_Nam";
            this.tablePanelFilter.SetRow(this.btnLoc_Thang_Nam, 0);
            this.btnLoc_Thang_Nam.Size = new System.Drawing.Size(127, 34);
            this.btnLoc_Thang_Nam.TabIndex = 2;
            this.btnLoc_Thang_Nam.Text = "Lọc Dữ Liệu";
            this.btnLoc_Thang_Nam.Click += new System.EventHandler(this.btnLoc_Thang_Nam_Click);
            // 
            // dateEditFilter
            // 
            this.tablePanelFilter.SetColumn(this.dateEditFilter, 2);
            this.dateEditFilter.EditValue = null;
            this.dateEditFilter.Location = new System.Drawing.Point(165, 11);
            this.dateEditFilter.Margin = new System.Windows.Forms.Padding(4);
            this.dateEditFilter.Name = "dateEditFilter";
            this.dateEditFilter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditFilter.Properties.Appearance.Options.UseFont = true;
            this.dateEditFilter.Properties.Appearance.Options.UseTextOptions = true;
            this.dateEditFilter.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateEditFilter.Properties.AutoHeight = false;
            this.dateEditFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFilter.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanelFilter.SetRow(this.dateEditFilter, 0);
            this.dateEditFilter.Size = new System.Drawing.Size(142, 34);
            this.dateEditFilter.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.tablePanelFilter.SetColumn(this.labelControl1, 1);
            this.labelControl1.Location = new System.Drawing.Point(20, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 0, 10, 0);
            this.labelControl1.Name = "labelControl1";
            this.tablePanelFilter.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(131, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn thời gian:";
            // 
            // frmALSRegistered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 833);
            this.Controls.Add(this.gridControl_Registered);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.tablePanelHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmALSRegistered";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Đăng Ký Lịch Nghỉ Luân Phiên / Registered Alternate Leave Schedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Registered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Registered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelHeader)).EndInit();
            this.tablePanelHeader.ResumeLayout(false);
            this.tablePanelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFilter)).EndInit();
            this.panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelFilter)).EndInit();
            this.tablePanelFilter.ResumeLayout(false);
            this.tablePanelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Registered;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Registered;
        private DevExpress.Utils.Layout.TablePanel tablePanelHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubTitle;
        private DevExpress.XtraEditors.PanelControl panelFilter;
        private DevExpress.Utils.Layout.TablePanel tablePanelFilter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEditFilter;
        private DevExpress.XtraEditors.SimpleButton btnLoc_Thang_Nam;
        private DevExpress.XtraEditors.SimpleButton btnrefresh;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnExit;
    }
}