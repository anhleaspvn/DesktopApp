﻿namespace ASPProject.HRAbsenceDoc
{
    partial class frmHRAbsenceDocByStaff
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
            this.lblTongPTH = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lblTongPTN = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblDateJob = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblPosition = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblDepName = new DevExpress.XtraEditors.LabelControl();
            this.lblEmpName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.dtpToDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lkeEmpID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridHRAbsence = new DevExpress.XtraGrid.GridControl();
            this.gridHRAbsenceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTimeOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumDateOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeOfAbsence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReasonOfAbsence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumRemainAbsense = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovedEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovedHOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovedHR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApprovedBOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsenceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTongPTH);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl15);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTongPTN);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl8);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblDateJob);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPosition);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblDepName);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblEmpName);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpToDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpFromDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.lkeEmpID);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridHRAbsence);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(995, 450);
            this.splitContainerControl1.SplitterPosition = 152;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // lblTongPTH
            // 
            this.lblTongPTH.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongPTH.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblTongPTH.Appearance.Options.UseFont = true;
            this.lblTongPTH.Appearance.Options.UseForeColor = true;
            this.lblTongPTH.Location = new System.Drawing.Point(848, 74);
            this.lblTongPTH.Margin = new System.Windows.Forms.Padding(4);
            this.lblTongPTH.Name = "lblTongPTH";
            this.lblTongPTH.Size = new System.Drawing.Size(70, 21);
            this.lblTongPTH.TabIndex = 135;
            this.lblTongPTH.Text = "TongPTH";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(744, 75);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(56, 16);
            this.labelControl15.TabIndex = 134;
            this.labelControl15.Text = "Tổng PTH";
            // 
            // lblTongPTN
            // 
            this.lblTongPTN.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongPTN.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblTongPTN.Appearance.Options.UseFont = true;
            this.lblTongPTN.Appearance.Options.UseForeColor = true;
            this.lblTongPTN.Location = new System.Drawing.Point(848, 39);
            this.lblTongPTN.Margin = new System.Windows.Forms.Padding(4);
            this.lblTongPTN.Name = "lblTongPTN";
            this.lblTongPTN.Size = new System.Drawing.Size(70, 21);
            this.lblTongPTN.TabIndex = 133;
            this.lblTongPTN.Text = "TongPTN";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(744, 44);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 16);
            this.labelControl7.TabIndex = 132;
            this.labelControl7.Text = "Tổng PTN";
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Location = new System.Drawing.Point(848, 7);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 21);
            this.lblStatus.TabIndex = 131;
            this.lblStatus.Text = "Status";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(744, 12);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(59, 16);
            this.labelControl8.TabIndex = 130;
            this.labelControl8.Text = "Trạng thái";
            // 
            // lblDateJob
            // 
            this.lblDateJob.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateJob.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDateJob.Appearance.Options.UseFont = true;
            this.lblDateJob.Appearance.Options.UseForeColor = true;
            this.lblDateJob.Location = new System.Drawing.Point(457, 73);
            this.lblDateJob.Margin = new System.Windows.Forms.Padding(4);
            this.lblDateJob.Name = "lblDateJob";
            this.lblDateJob.Size = new System.Drawing.Size(68, 21);
            this.lblDateJob.TabIndex = 129;
            this.lblDateJob.Text = "Date Job";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(353, 75);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(86, 16);
            this.labelControl5.TabIndex = 128;
            this.labelControl5.Text = "Ngày nhận việc";
            // 
            // lblPosition
            // 
            this.lblPosition.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblPosition.Appearance.Options.UseFont = true;
            this.lblPosition.Appearance.Options.UseForeColor = true;
            this.lblPosition.Location = new System.Drawing.Point(457, 39);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(60, 21);
            this.lblPosition.TabIndex = 127;
            this.lblPosition.Text = "Position";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(353, 46);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 16);
            this.labelControl6.TabIndex = 126;
            this.labelControl6.Text = "Chức vụ";
            // 
            // lblDepName
            // 
            this.lblDepName.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepName.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDepName.Appearance.Options.UseFont = true;
            this.lblDepName.Appearance.Options.UseForeColor = true;
            this.lblDepName.Location = new System.Drawing.Point(457, 8);
            this.lblDepName.Margin = new System.Windows.Forms.Padding(4);
            this.lblDepName.Name = "lblDepName";
            this.lblDepName.Size = new System.Drawing.Size(86, 21);
            this.lblDepName.TabIndex = 125;
            this.lblDepName.Text = "Dept Name";
            // 
            // lblEmpName
            // 
            this.lblEmpName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Appearance.ForeColor = System.Drawing.Color.Orange;
            this.lblEmpName.Appearance.Options.UseFont = true;
            this.lblEmpName.Appearance.Options.UseForeColor = true;
            this.lblEmpName.Location = new System.Drawing.Point(17, 104);
            this.lblEmpName.Margin = new System.Windows.Forms.Padding(4);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(108, 24);
            this.lblEmpName.TabIndex = 124;
            this.lblEmpName.Text = "Emp Name";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(353, 16);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 16);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Bộ phận";
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(865, 112);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(118, 29);
            this.btFilter.TabIndex = 122;
            this.btFilter.Text = "Lọc";
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = null;
            this.dtpToDate.Location = new System.Drawing.Point(118, 40);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpToDate.Size = new System.Drawing.Size(179, 22);
            this.dtpToDate.TabIndex = 121;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 120;
            this.labelControl2.Text = "Đến ngày";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.EditValue = null;
            this.dtpFromDate.Location = new System.Drawing.Point(118, 9);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFromDate.Size = new System.Drawing.Size(179, 22);
            this.dtpFromDate.TabIndex = 119;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 16);
            this.labelControl3.TabIndex = 118;
            this.labelControl3.Text = "Từ ngày";
            // 
            // lkeEmpID
            // 
            this.lkeEmpID.EditValue = "";
            this.lkeEmpID.Location = new System.Drawing.Point(118, 72);
            this.lkeEmpID.Margin = new System.Windows.Forms.Padding(5);
            this.lkeEmpID.Name = "lkeEmpID";
            this.lkeEmpID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeEmpID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeEmpID.Properties.NullText = "";
            this.lkeEmpID.Size = new System.Drawing.Size(179, 22);
            this.lkeEmpID.TabIndex = 116;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 79);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 16);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "Mã nhân viên";
            // 
            // gridHRAbsence
            // 
            this.gridHRAbsence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHRAbsence.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridHRAbsence.Location = new System.Drawing.Point(0, 0);
            this.gridHRAbsence.MainView = this.gridHRAbsenceView;
            this.gridHRAbsence.Margin = new System.Windows.Forms.Padding(4);
            this.gridHRAbsence.Name = "gridHRAbsence";
            this.gridHRAbsence.Size = new System.Drawing.Size(995, 286);
            this.gridHRAbsence.TabIndex = 32;
            this.gridHRAbsence.UseEmbeddedNavigator = true;
            this.gridHRAbsence.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridHRAbsenceView,
            this.gridView2});
            // 
            // gridHRAbsenceView
            // 
            this.gridHRAbsenceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTimeOff,
            this.colNumDateOff,
            this.colTypeOfAbsence,
            this.colReasonOfAbsence,
            this.colSumRemainAbsense,
            this.colApprovedEmp,
            this.colApprovedHOD,
            this.colApprovedHR,
            this.colApprovedBOD});
            this.gridHRAbsenceView.DetailHeight = 431;
            this.gridHRAbsenceView.GridControl = this.gridHRAbsence;
            this.gridHRAbsenceView.Name = "gridHRAbsenceView";
            this.gridHRAbsenceView.OptionsBehavior.Editable = false;
            this.gridHRAbsenceView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridHRAbsenceView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridHRAbsenceView.OptionsView.ShowAutoFilterRow = true;
            this.gridHRAbsenceView.OptionsView.ShowGroupPanel = false;
            // 
            // colTimeOff
            // 
            this.colTimeOff.Caption = "Thời gian nghỉ";
            this.colTimeOff.FieldName = "TimeOff";
            this.colTimeOff.MinWidth = 25;
            this.colTimeOff.Name = "colTimeOff";
            this.colTimeOff.Visible = true;
            this.colTimeOff.VisibleIndex = 0;
            this.colTimeOff.Width = 94;
            // 
            // colNumDateOff
            // 
            this.colNumDateOff.Caption = "Số ngày";
            this.colNumDateOff.DisplayFormat.FormatString = "#.#";
            this.colNumDateOff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNumDateOff.FieldName = "NumDateOff";
            this.colNumDateOff.MinWidth = 25;
            this.colNumDateOff.Name = "colNumDateOff";
            this.colNumDateOff.Visible = true;
            this.colNumDateOff.VisibleIndex = 1;
            this.colNumDateOff.Width = 94;
            // 
            // colTypeOfAbsence
            // 
            this.colTypeOfAbsence.Caption = "Loại phép";
            this.colTypeOfAbsence.FieldName = "TypeOfAbsence";
            this.colTypeOfAbsence.MinWidth = 25;
            this.colTypeOfAbsence.Name = "colTypeOfAbsence";
            this.colTypeOfAbsence.Visible = true;
            this.colTypeOfAbsence.VisibleIndex = 2;
            this.colTypeOfAbsence.Width = 94;
            // 
            // colReasonOfAbsence
            // 
            this.colReasonOfAbsence.Caption = "Lý do xin nghỉ";
            this.colReasonOfAbsence.FieldName = "ReasonOfAbsence";
            this.colReasonOfAbsence.MinWidth = 25;
            this.colReasonOfAbsence.Name = "colReasonOfAbsence";
            this.colReasonOfAbsence.Visible = true;
            this.colReasonOfAbsence.VisibleIndex = 3;
            this.colReasonOfAbsence.Width = 94;
            // 
            // colSumRemainAbsense
            // 
            this.colSumRemainAbsense.Caption = "Số phép còn lại";
            this.colSumRemainAbsense.FieldName = "SumRemainAbsense";
            this.colSumRemainAbsense.MinWidth = 25;
            this.colSumRemainAbsense.Name = "colSumRemainAbsense";
            this.colSumRemainAbsense.Visible = true;
            this.colSumRemainAbsense.VisibleIndex = 4;
            this.colSumRemainAbsense.Width = 94;
            // 
            // colApprovedEmp
            // 
            this.colApprovedEmp.Caption = "Nhân viên xác nhận";
            this.colApprovedEmp.FieldName = "ApprovedEmp";
            this.colApprovedEmp.MinWidth = 25;
            this.colApprovedEmp.Name = "colApprovedEmp";
            this.colApprovedEmp.Visible = true;
            this.colApprovedEmp.VisibleIndex = 5;
            this.colApprovedEmp.Width = 94;
            // 
            // colApprovedHOD
            // 
            this.colApprovedHOD.Caption = "TBP Duyệt";
            this.colApprovedHOD.FieldName = "ApprovedHOD";
            this.colApprovedHOD.MinWidth = 25;
            this.colApprovedHOD.Name = "colApprovedHOD";
            this.colApprovedHOD.Visible = true;
            this.colApprovedHOD.VisibleIndex = 6;
            this.colApprovedHOD.Width = 94;
            // 
            // colApprovedHR
            // 
            this.colApprovedHR.Caption = "P.HCNS (Thẩm định)";
            this.colApprovedHR.FieldName = "ApprovedHR";
            this.colApprovedHR.MinWidth = 25;
            this.colApprovedHR.Name = "colApprovedHR";
            this.colApprovedHR.Visible = true;
            this.colApprovedHR.VisibleIndex = 7;
            this.colApprovedHR.Width = 94;
            // 
            // colApprovedBOD
            // 
            this.colApprovedBOD.Caption = "Ban điều hành duyệt";
            this.colApprovedBOD.FieldName = "ApprovedBOD";
            this.colApprovedBOD.MinWidth = 25;
            this.colApprovedBOD.Name = "colApprovedBOD";
            this.colApprovedBOD.Visible = true;
            this.colApprovedBOD.VisibleIndex = 8;
            this.colApprovedBOD.Width = 94;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridHRAbsence;
            this.gridView2.Name = "gridView2";
            // 
            // frmHRAbsenceDocByStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 450);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHRAbsenceDocByStaff";
            this.Text = "frmHRAbsenceDocByStaff";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmpID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRAbsenceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LookUpEdit lkeEmpID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.DateEdit dtpToDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtpFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblPosition;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblDepName;
        private DevExpress.XtraEditors.LabelControl lblEmpName;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lblDateJob;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblTongPTH;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl lblTongPTN;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.GridControl gridHRAbsence;
        private DevExpress.XtraGrid.Views.Grid.GridView gridHRAbsenceView;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeOff;
        private DevExpress.XtraGrid.Columns.GridColumn colNumDateOff;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeOfAbsence;
        private DevExpress.XtraGrid.Columns.GridColumn colReasonOfAbsence;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedEmp;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedHOD;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedHR;
        private DevExpress.XtraGrid.Columns.GridColumn colApprovedBOD;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colSumRemainAbsense;
    }
}