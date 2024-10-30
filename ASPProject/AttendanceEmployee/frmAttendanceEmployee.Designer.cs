namespace ASPProject.AttendanceEmployee
{
    partial class frmAttendanceEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendanceEmployee));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtEveVege = new DevExpress.XtraEditors.TextEdit();
            this.txtMorVege = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblLineID = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNganh = new DevExpress.XtraEditors.LabelControl();
            this.dtpAttendanceDate = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btLockAttendance = new DevExpress.XtraEditors.SimpleButton();
            this.btEditMulti = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gridAttendance = new DevExpress.XtraGrid.GridControl();
            this.gridAttendanceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Timekeeping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateBeginTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeLunchTime = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLuchTime = new DevExpress.XtraEditors.LabelControl();
            this.lkeDinnerTime = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEveVege.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMorVege.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAttendanceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAttendanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLunchTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDinnerTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lkeDinnerTime);
            this.panelControl1.Controls.Add(this.lkeLunchTime);
            this.panelControl1.Controls.Add(this.lblLuchTime);
            this.panelControl1.Controls.Add(this.txtEveVege);
            this.panelControl1.Controls.Add(this.txtMorVege);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lblLineID);
            this.panelControl1.Controls.Add(this.lblMaNganh);
            this.panelControl1.Controls.Add(this.dtpAttendanceDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1256, 119);
            this.panelControl1.TabIndex = 0;
            // 
            // txtEveVege
            // 
            this.txtEveVege.Location = new System.Drawing.Point(135, 78);
            this.txtEveVege.Margin = new System.Windows.Forms.Padding(8);
            this.txtEveVege.Name = "txtEveVege";
            this.txtEveVege.Properties.DisplayFormat.FormatString = "#0.00";
            this.txtEveVege.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEveVege.Properties.EditFormat.FormatString = "#0.00";
            this.txtEveVege.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEveVege.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtEveVege.Properties.MaskSettings.Set("mask", "#####");
            this.txtEveVege.Properties.UseMaskAsDisplayFormat = true;
            this.txtEveVege.Size = new System.Drawing.Size(200, 23);
            this.txtEveVege.TabIndex = 126;
            // 
            // txtMorVege
            // 
            this.txtMorVege.Location = new System.Drawing.Point(135, 48);
            this.txtMorVege.Margin = new System.Windows.Forms.Padding(8);
            this.txtMorVege.Name = "txtMorVege";
            this.txtMorVege.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMorVege.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMorVege.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtMorVege.Properties.MaskSettings.Set("mask", "#####");
            this.txtMorVege.Properties.UseMaskAsDisplayFormat = true;
            this.txtMorVege.Size = new System.Drawing.Size(200, 23);
            this.txtMorVege.TabIndex = 125;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 81);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 16);
            this.labelControl2.TabIndex = 87;
            this.labelControl2.Text = "SL chay chiều";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 51);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 16);
            this.labelControl1.TabIndex = 86;
            this.labelControl1.Text = "SL chay sáng";
            // 
            // lblLineID
            // 
            this.lblLineID.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineID.Appearance.ForeColor = System.Drawing.Color.Orange;
            this.lblLineID.Appearance.Options.UseFont = true;
            this.lblLineID.Appearance.Options.UseForeColor = true;
            this.lblLineID.Location = new System.Drawing.Point(391, 16);
            this.lblLineID.Margin = new System.Windows.Forms.Padding(4);
            this.lblLineID.Name = "lblLineID";
            this.lblLineID.Size = new System.Drawing.Size(73, 24);
            this.lblLineID.TabIndex = 85;
            this.lblLineID.Text = "Line ID";
            // 
            // lblMaNganh
            // 
            this.lblMaNganh.Location = new System.Drawing.Point(17, 21);
            this.lblMaNganh.Margin = new System.Windows.Forms.Padding(4);
            this.lblMaNganh.Name = "lblMaNganh";
            this.lblMaNganh.Size = new System.Drawing.Size(92, 16);
            this.lblMaNganh.TabIndex = 84;
            this.lblMaNganh.Text = "Ngày điểm danh";
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.EditValue = null;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(135, 18);
            this.dtpAttendanceDate.MaximumSize = new System.Drawing.Size(400, 50);
            this.dtpAttendanceDate.MinimumSize = new System.Drawing.Size(200, 20);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpAttendanceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpAttendanceDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpAttendanceDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpAttendanceDate.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dtpAttendanceDate.Properties.UseMaskAsDisplayFormat = true;
            this.dtpAttendanceDate.Size = new System.Drawing.Size(200, 23);
            this.dtpAttendanceDate.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btSummary);
            this.panelControl2.Controls.Add(this.btLockAttendance);
            this.panelControl2.Controls.Add(this.btEditMulti);
            this.panelControl2.Controls.Add(this.btDelete);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Controls.Add(this.btCancel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 580);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1256, 77);
            this.panelControl2.TabIndex = 1;
            // 
            // btSummary
            // 
            this.btSummary.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btSummary.ImageOptions.Image = global::ASPProject.Properties.Resources.paper;
            this.btSummary.Location = new System.Drawing.Point(879, 14);
            this.btSummary.Margin = new System.Windows.Forms.Padding(4);
            this.btSummary.Name = "btSummary";
            this.btSummary.Size = new System.Drawing.Size(175, 49);
            this.btSummary.TabIndex = 128;
            this.btSummary.Text = "Tổng kết";
            // 
            // btLockAttendance
            // 
            this.btLockAttendance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btLockAttendance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btLockAttendance.ImageOptions.Image")));
            this.btLockAttendance.Location = new System.Drawing.Point(530, 14);
            this.btLockAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.btLockAttendance.Name = "btLockAttendance";
            this.btLockAttendance.Size = new System.Drawing.Size(179, 49);
            this.btLockAttendance.TabIndex = 127;
            this.btLockAttendance.Text = "Khoá điểm danh";
            // 
            // btEditMulti
            // 
            this.btEditMulti.ImageOptions.Image = global::ASPProject.Properties.Resources.money;
            this.btEditMulti.Location = new System.Drawing.Point(365, 14);
            this.btEditMulti.Name = "btEditMulti";
            this.btEditMulti.Size = new System.Drawing.Size(136, 49);
            this.btEditMulti.TabIndex = 73;
            this.btEditMulti.Text = "Sửa nhiều dòng";
            // 
            // btDelete
            // 
            this.btDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btDelete.Location = new System.Drawing.Point(1081, 14);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(143, 49);
            this.btDelete.TabIndex = 72;
            this.btDelete.Text = "Xoá";
            // 
            // btSave
            // 
            this.btSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(20, 14);
            this.btSave.Margin = new System.Windows.Forms.Padding(4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(143, 49);
            this.btSave.TabIndex = 71;
            this.btSave.Text = "Lưu";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.ImageOptions.Image")));
            this.btCancel.Location = new System.Drawing.Point(192, 14);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(143, 49);
            this.btCancel.TabIndex = 70;
            this.btCancel.Text = "Đóng";
            // 
            // gridAttendance
            // 
            this.gridAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttendance.Location = new System.Drawing.Point(0, 119);
            this.gridAttendance.MainView = this.gridAttendanceView;
            this.gridAttendance.Name = "gridAttendance";
            this.gridAttendance.Size = new System.Drawing.Size(1256, 461);
            this.gridAttendance.TabIndex = 2;
            this.gridAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAttendanceView});
            // 
            // gridAttendanceView
            // 
            this.gridAttendanceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EmpID,
            this.EmpName,
            this.LineID,
            this.Timekeeping,
            this.DateBeginTime,
            this.DateEndTime,
            this.LastModifiedBy,
            this.LastModifiedDate});
            this.gridAttendanceView.GridControl = this.gridAttendance;
            this.gridAttendanceView.Name = "gridAttendanceView";
            this.gridAttendanceView.OptionsBehavior.Editable = false;
            this.gridAttendanceView.OptionsSelection.MultiSelect = true;
            this.gridAttendanceView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridAttendanceView.OptionsView.ShowAutoFilterRow = true;
            this.gridAttendanceView.OptionsView.ShowFooter = true;
            this.gridAttendanceView.OptionsView.ShowGroupPanel = false;
            // 
            // EmpID
            // 
            this.EmpID.Caption = "Mã nhân viên";
            this.EmpID.FieldName = "EmpID";
            this.EmpID.MinWidth = 25;
            this.EmpID.Name = "EmpID";
            this.EmpID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmpID", "Số lượng = {0}")});
            this.EmpID.Visible = true;
            this.EmpID.VisibleIndex = 1;
            this.EmpID.Width = 94;
            // 
            // EmpName
            // 
            this.EmpName.Caption = "Tên nhân viên";
            this.EmpName.FieldName = "EmpName";
            this.EmpName.MinWidth = 25;
            this.EmpName.Name = "EmpName";
            this.EmpName.Visible = true;
            this.EmpName.VisibleIndex = 2;
            this.EmpName.Width = 94;
            // 
            // LineID
            // 
            this.LineID.Caption = "Line";
            this.LineID.FieldName = "LineID";
            this.LineID.MinWidth = 25;
            this.LineID.Name = "LineID";
            this.LineID.Visible = true;
            this.LineID.VisibleIndex = 3;
            this.LineID.Width = 94;
            // 
            // Timekeeping
            // 
            this.Timekeeping.Caption = "Mã chấm công";
            this.Timekeeping.FieldName = "Timekeeping";
            this.Timekeeping.MinWidth = 25;
            this.Timekeeping.Name = "Timekeeping";
            this.Timekeeping.Visible = true;
            this.Timekeeping.VisibleIndex = 4;
            this.Timekeeping.Width = 94;
            // 
            // DateBeginTime
            // 
            this.DateBeginTime.Caption = "Thời gian bắt đầu ngày";
            this.DateBeginTime.DisplayFormat.FormatString = "hh:mm:ss";
            this.DateBeginTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateBeginTime.FieldName = "DateBeginTime";
            this.DateBeginTime.MinWidth = 25;
            this.DateBeginTime.Name = "DateBeginTime";
            this.DateBeginTime.Visible = true;
            this.DateBeginTime.VisibleIndex = 5;
            this.DateBeginTime.Width = 94;
            // 
            // DateEndTime
            // 
            this.DateEndTime.Caption = "Thời gian kết thúc ngày";
            this.DateEndTime.DisplayFormat.FormatString = "hh:mm:ss";
            this.DateEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEndTime.FieldName = "DateEndTime";
            this.DateEndTime.MinWidth = 25;
            this.DateEndTime.Name = "DateEndTime";
            this.DateEndTime.Visible = true;
            this.DateEndTime.VisibleIndex = 6;
            this.DateEndTime.Width = 94;
            // 
            // LastModifiedBy
            // 
            this.LastModifiedBy.Caption = "Người sửa";
            this.LastModifiedBy.FieldName = "LastModifiedBy";
            this.LastModifiedBy.MinWidth = 25;
            this.LastModifiedBy.Name = "LastModifiedBy";
            this.LastModifiedBy.Visible = true;
            this.LastModifiedBy.VisibleIndex = 7;
            this.LastModifiedBy.Width = 94;
            // 
            // LastModifiedDate
            // 
            this.LastModifiedDate.Caption = "Ngày sửa";
            this.LastModifiedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.LastModifiedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.LastModifiedDate.FieldName = "LastModifiedDate";
            this.LastModifiedDate.MinWidth = 25;
            this.LastModifiedDate.Name = "LastModifiedDate";
            this.LastModifiedDate.Visible = true;
            this.LastModifiedDate.VisibleIndex = 8;
            this.LastModifiedDate.Width = 94;
            // 
            // lkeLunchTime
            // 
            this.lkeLunchTime.EditValue = "";
            this.lkeLunchTime.Location = new System.Drawing.Point(488, 48);
            this.lkeLunchTime.Margin = new System.Windows.Forms.Padding(4);
            this.lkeLunchTime.Name = "lkeLunchTime";
            this.lkeLunchTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeLunchTime.Properties.NullText = "";
            this.lkeLunchTime.Size = new System.Drawing.Size(162, 23);
            this.lkeLunchTime.TabIndex = 127;
            // 
            // lblLuchTime
            // 
            this.lblLuchTime.Location = new System.Drawing.Point(393, 51);
            this.lblLuchTime.Margin = new System.Windows.Forms.Padding(5);
            this.lblLuchTime.Name = "lblLuchTime";
            this.lblLuchTime.Size = new System.Drawing.Size(64, 16);
            this.lblLuchTime.TabIndex = 128;
            this.lblLuchTime.Text = "Giờ ăn trưa";
            // 
            // lkeDinnerTime
            // 
            this.lkeDinnerTime.EditValue = "";
            this.lkeDinnerTime.Location = new System.Drawing.Point(488, 78);
            this.lkeDinnerTime.Margin = new System.Windows.Forms.Padding(4);
            this.lkeDinnerTime.Name = "lkeDinnerTime";
            this.lkeDinnerTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDinnerTime.Properties.NullText = "";
            this.lkeDinnerTime.Size = new System.Drawing.Size(162, 23);
            this.lkeDinnerTime.TabIndex = 129;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(393, 81);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 16);
            this.labelControl3.TabIndex = 130;
            this.labelControl3.Text = "Giờ ăn chiều";
            // 
            // frmAttendanceEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 657);
            this.Controls.Add(this.gridAttendance);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAttendanceEmployee";
            this.Text = "AttendanceEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEveVege.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMorVege.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAttendanceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAttendanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLunchTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDinnerTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridAttendance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAttendanceView;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.DateEdit dtpAttendanceDate;
        private DevExpress.XtraEditors.LabelControl lblLineID;
        private DevExpress.XtraEditors.LabelControl lblMaNganh;
        private DevExpress.XtraGrid.Columns.GridColumn EmpID;
        private DevExpress.XtraGrid.Columns.GridColumn EmpName;
        private DevExpress.XtraGrid.Columns.GridColumn LineID;
        private DevExpress.XtraGrid.Columns.GridColumn Timekeeping;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SimpleButton btDelete;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEveVege;
        private DevExpress.XtraEditors.TextEdit txtMorVege;
        private DevExpress.XtraEditors.SimpleButton btEditMulti;
        private DevExpress.XtraEditors.SimpleButton btLockAttendance;
        private DevExpress.XtraGrid.Columns.GridColumn LastModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn LastModifiedDate;
        private DevExpress.XtraEditors.SimpleButton btSummary;
        private DevExpress.XtraGrid.Columns.GridColumn DateBeginTime;
        private DevExpress.XtraGrid.Columns.GridColumn DateEndTime;
        private DevExpress.XtraEditors.LookUpEdit lkeDinnerTime;
        private DevExpress.XtraEditors.LookUpEdit lkeLunchTime;
        private DevExpress.XtraEditors.LabelControl lblLuchTime;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}