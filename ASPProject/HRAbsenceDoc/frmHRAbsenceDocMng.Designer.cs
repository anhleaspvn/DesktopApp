namespace ASPProject.HRAbsenceDoc
{
    partial class frmHRAbsenceDocMng
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkeTypeEmp = new DevExpress.XtraEditors.LookUpEdit();
            this.btEditLeave = new DevExpress.XtraEditors.SimpleButton();
            this.btCancelLeave = new DevExpress.XtraEditors.SimpleButton();
            this.btReadGGS = new DevExpress.XtraEditors.SimpleButton();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.dtpToDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridHRAbsence = new DevExpress.XtraGrid.GridControl();
            this.gridHRAbsenceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumDateOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeOfAbsence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReasonOfAbsence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumRemainAbsense = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDLDStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHDStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCancel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).BeginInit();
            this.splitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).BeginInit();
            this.splitContainerControl2.Panel2.SuspendLayout();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeTypeEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsenceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            // 
            // splitContainerControl2.Panel1
            // 
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl2.Panel1.Controls.Add(this.lkeTypeEmp);
            this.splitContainerControl2.Panel1.Controls.Add(this.btEditLeave);
            this.splitContainerControl2.Panel1.Controls.Add(this.btCancelLeave);
            this.splitContainerControl2.Panel1.Controls.Add(this.btReadGGS);
            this.splitContainerControl2.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl2.Panel1.Controls.Add(this.dtpToDate);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl2.Panel1.Controls.Add(this.dtpFromDate);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            // 
            // splitContainerControl2.Panel2
            // 
            this.splitContainerControl2.Panel2.Controls.Add(this.gridHRAbsence);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1416, 687);
            this.splitContainerControl2.SplitterPosition = 76;
            this.splitContainerControl2.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(257, 50);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(82, 16);
            this.labelControl3.TabIndex = 73;
            this.labelControl3.Text = "Loại nhân viên";
            this.labelControl3.Visible = false;
            // 
            // lkeTypeEmp
            // 
            this.lkeTypeEmp.EditValue = "";
            this.lkeTypeEmp.Location = new System.Drawing.Point(359, 43);
            this.lkeTypeEmp.Margin = new System.Windows.Forms.Padding(4);
            this.lkeTypeEmp.Name = "lkeTypeEmp";
            this.lkeTypeEmp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeTypeEmp.Properties.NullText = "";
            this.lkeTypeEmp.Size = new System.Drawing.Size(125, 23);
            this.lkeTypeEmp.TabIndex = 72;
            this.lkeTypeEmp.Visible = false;
            // 
            // btEditLeave
            // 
            this.btEditLeave.ImageOptions.Image = global::ASPProject.Properties.Resources.edit2;
            this.btEditLeave.Location = new System.Drawing.Point(856, 11);
            this.btEditLeave.Name = "btEditLeave";
            this.btEditLeave.Size = new System.Drawing.Size(127, 29);
            this.btEditLeave.TabIndex = 7;
            this.btEditLeave.Text = "Sửa phép";
            this.btEditLeave.Visible = false;
            // 
            // btCancelLeave
            // 
            this.btCancelLeave.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btCancelLeave.Location = new System.Drawing.Point(1000, 11);
            this.btCancelLeave.Name = "btCancelLeave";
            this.btCancelLeave.Size = new System.Drawing.Size(150, 29);
            this.btCancelLeave.TabIndex = 6;
            this.btCancelLeave.Text = "Huỷ phép";
            // 
            // btReadGGS
            // 
            this.btReadGGS.ImageOptions.Image = global::ASPProject.Properties.Resources.refresh1;
            this.btReadGGS.Location = new System.Drawing.Point(675, 11);
            this.btReadGGS.Name = "btReadGGS";
            this.btReadGGS.Size = new System.Drawing.Size(164, 29);
            this.btReadGGS.TabIndex = 5;
            this.btReadGGS.Text = "Lấy dữ liệu phép";
            this.btReadGGS.Visible = false;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(539, 11);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(118, 29);
            this.btFilter.TabIndex = 4;
            this.btFilter.Text = "Lọc";
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = null;
            this.dtpToDate.Location = new System.Drawing.Point(359, 10);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpToDate.Size = new System.Drawing.Size(125, 23);
            this.dtpToDate.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(285, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.EditValue = null;
            this.dtpFromDate.Location = new System.Drawing.Point(101, 10);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFromDate.Size = new System.Drawing.Size(125, 23);
            this.dtpFromDate.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            // 
            // gridHRAbsence
            // 
            this.gridHRAbsence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHRAbsence.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridHRAbsence.Location = new System.Drawing.Point(0, 0);
            this.gridHRAbsence.MainView = this.gridHRAbsenceView;
            this.gridHRAbsence.Margin = new System.Windows.Forms.Padding(4);
            this.gridHRAbsence.Name = "gridHRAbsence";
            this.gridHRAbsence.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridHRAbsence.Size = new System.Drawing.Size(1416, 604);
            this.gridHRAbsence.TabIndex = 32;
            this.gridHRAbsence.UseEmbeddedNavigator = true;
            this.gridHRAbsence.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridHRAbsenceView,
            this.gridView2});
            // 
            // gridHRAbsenceView
            // 
            this.gridHRAbsenceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTimestamp,
            this.colEmpID,
            this.colEmpName,
            this.colPosition,
            this.colEmpPosition,
            this.colDeptID,
            this.colDeptName,
            this.colTimeOff,
            this.colNumDateOff,
            this.colTypeOfAbsence,
            this.colReasonOfAbsence,
            this.colSumRemainAbsense,
            this.colDLDStatus,
            this.colAHDStatus,
            this.colHRStatus,
            this.colIsCancel});
            this.gridHRAbsenceView.DetailHeight = 431;
            this.gridHRAbsenceView.GridControl = this.gridHRAbsence;
            this.gridHRAbsenceView.Name = "gridHRAbsenceView";
            this.gridHRAbsenceView.OptionsBehavior.Editable = false;
            this.gridHRAbsenceView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridHRAbsenceView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridHRAbsenceView.OptionsView.ShowAutoFilterRow = true;
            this.gridHRAbsenceView.OptionsView.ShowGroupPanel = false;
            // 
            // colTimestamp
            // 
            this.colTimestamp.Caption = "Thời gian tạo";
            this.colTimestamp.FieldName = "Timestamp";
            this.colTimestamp.MinWidth = 25;
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.Visible = true;
            this.colTimestamp.VisibleIndex = 0;
            this.colTimestamp.Width = 94;
            // 
            // colEmpID
            // 
            this.colEmpID.Caption = "Mã nhân viên";
            this.colEmpID.FieldName = "EmpID";
            this.colEmpID.MinWidth = 25;
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.Visible = true;
            this.colEmpID.VisibleIndex = 1;
            this.colEmpID.Width = 94;
            // 
            // colEmpName
            // 
            this.colEmpName.Caption = "Tên nhân viên";
            this.colEmpName.FieldName = "EmpName";
            this.colEmpName.MinWidth = 25;
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 2;
            this.colEmpName.Width = 94;
            // 
            // colPosition
            // 
            this.colPosition.Caption = "Chức vụ";
            this.colPosition.FieldName = "Position";
            this.colPosition.MinWidth = 25;
            this.colPosition.Name = "colPosition";
            this.colPosition.Visible = true;
            this.colPosition.VisibleIndex = 3;
            this.colPosition.Width = 94;
            // 
            // colEmpPosition
            // 
            this.colEmpPosition.Caption = "Line";
            this.colEmpPosition.FieldName = "EmpPosition";
            this.colEmpPosition.MinWidth = 25;
            this.colEmpPosition.Name = "colEmpPosition";
            this.colEmpPosition.Visible = true;
            this.colEmpPosition.VisibleIndex = 4;
            this.colEmpPosition.Width = 94;
            // 
            // colDeptID
            // 
            this.colDeptID.Caption = "Mã bộ phận";
            this.colDeptID.FieldName = "DeptID";
            this.colDeptID.MinWidth = 25;
            this.colDeptID.Name = "colDeptID";
            this.colDeptID.Visible = true;
            this.colDeptID.VisibleIndex = 5;
            this.colDeptID.Width = 94;
            // 
            // colDeptName
            // 
            this.colDeptName.Caption = "Tên bộ phận";
            this.colDeptName.FieldName = "DeptName";
            this.colDeptName.MinWidth = 25;
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.Visible = true;
            this.colDeptName.VisibleIndex = 6;
            this.colDeptName.Width = 94;
            // 
            // colTimeOff
            // 
            this.colTimeOff.Caption = "Thời gian nghỉ";
            this.colTimeOff.FieldName = "TimeOff";
            this.colTimeOff.MinWidth = 25;
            this.colTimeOff.Name = "colTimeOff";
            this.colTimeOff.Visible = true;
            this.colTimeOff.VisibleIndex = 7;
            this.colTimeOff.Width = 94;
            // 
            // colNumDateOff
            // 
            this.colNumDateOff.Caption = "Số ngày nghỉ";
            this.colNumDateOff.DisplayFormat.FormatString = "0.##";
            this.colNumDateOff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNumDateOff.FieldName = "NumDateOff";
            this.colNumDateOff.MinWidth = 25;
            this.colNumDateOff.Name = "colNumDateOff";
            this.colNumDateOff.Visible = true;
            this.colNumDateOff.VisibleIndex = 8;
            this.colNumDateOff.Width = 94;
            // 
            // colTypeOfAbsence
            // 
            this.colTypeOfAbsence.Caption = "Loại phép";
            this.colTypeOfAbsence.FieldName = "TypeOfAbsence";
            this.colTypeOfAbsence.MinWidth = 25;
            this.colTypeOfAbsence.Name = "colTypeOfAbsence";
            this.colTypeOfAbsence.Visible = true;
            this.colTypeOfAbsence.VisibleIndex = 9;
            this.colTypeOfAbsence.Width = 94;
            // 
            // colReasonOfAbsence
            // 
            this.colReasonOfAbsence.Caption = "Lý do nghỉ";
            this.colReasonOfAbsence.FieldName = "ReasonOfAbsence";
            this.colReasonOfAbsence.MinWidth = 25;
            this.colReasonOfAbsence.Name = "colReasonOfAbsence";
            this.colReasonOfAbsence.Visible = true;
            this.colReasonOfAbsence.VisibleIndex = 10;
            this.colReasonOfAbsence.Width = 94;
            // 
            // colSumRemainAbsense
            // 
            this.colSumRemainAbsense.Caption = "Tổng số phép còn lại";
            this.colSumRemainAbsense.DisplayFormat.FormatString = "#.#";
            this.colSumRemainAbsense.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumRemainAbsense.FieldName = "SumRemainAbsense";
            this.colSumRemainAbsense.MinWidth = 25;
            this.colSumRemainAbsense.Name = "colSumRemainAbsense";
            this.colSumRemainAbsense.Visible = true;
            this.colSumRemainAbsense.VisibleIndex = 11;
            this.colSumRemainAbsense.Width = 94;
            // 
            // colDLDStatus
            // 
            this.colDLDStatus.Caption = "Quản lý trực tiếp";
            this.colDLDStatus.FieldName = "DLDStatus";
            this.colDLDStatus.MinWidth = 25;
            this.colDLDStatus.Name = "colDLDStatus";
            this.colDLDStatus.Width = 94;
            // 
            // colAHDStatus
            // 
            this.colAHDStatus.Caption = "HOD / BOD";
            this.colAHDStatus.FieldName = "AHDStatus";
            this.colAHDStatus.MinWidth = 25;
            this.colAHDStatus.Name = "colAHDStatus";
            this.colAHDStatus.Visible = true;
            this.colAHDStatus.VisibleIndex = 12;
            this.colAHDStatus.Width = 94;
            // 
            // colHRStatus
            // 
            this.colHRStatus.Caption = "HR";
            this.colHRStatus.FieldName = "HRStatus";
            this.colHRStatus.MinWidth = 25;
            this.colHRStatus.Name = "colHRStatus";
            this.colHRStatus.Visible = true;
            this.colHRStatus.VisibleIndex = 13;
            this.colHRStatus.Width = 94;
            // 
            // colIsCancel
            // 
            this.colIsCancel.Caption = "Phép đã huỷ";
            this.colIsCancel.FieldName = "IsCancel";
            this.colIsCancel.MinWidth = 25;
            this.colIsCancel.Name = "colIsCancel";
            this.colIsCancel.Visible = true;
            this.colIsCancel.VisibleIndex = 14;
            this.colIsCancel.Width = 94;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Huỷ phép", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridHRAbsence;
            this.gridView2.Name = "gridView2";
            // 
            // frmHRAbsenceDocMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 687);
            this.Controls.Add(this.splitContainerControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHRAbsenceDocMng";
            this.Text = "HRAbsenceDocMng";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).EndInit();
            this.splitContainerControl2.Panel1.ResumeLayout(false);
            this.splitContainerControl2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).EndInit();
            this.splitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeTypeEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsenceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lkeTypeEmp;
        private DevExpress.XtraEditors.SimpleButton btEditLeave;
        private DevExpress.XtraEditors.SimpleButton btCancelLeave;
        private DevExpress.XtraEditors.SimpleButton btReadGGS;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.DateEdit dtpToDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtpFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridHRAbsence;
        private DevExpress.XtraGrid.Views.Grid.GridView gridHRAbsenceView;
        private DevExpress.XtraGrid.Columns.GridColumn colTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colDeptID;
        private DevExpress.XtraGrid.Columns.GridColumn colDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeOff;
        private DevExpress.XtraGrid.Columns.GridColumn colNumDateOff;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeOfAbsence;
        private DevExpress.XtraGrid.Columns.GridColumn colReasonOfAbsence;
        private DevExpress.XtraGrid.Columns.GridColumn colSumRemainAbsense;
        private DevExpress.XtraGrid.Columns.GridColumn colDLDStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colAHDStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colHRStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCancel;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}