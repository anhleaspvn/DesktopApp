namespace ASPProject.ExLosstime
{
    partial class frmExLosstime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExLosstime));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkCbListEmpID = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblEmpName = new DevExpress.XtraEditors.LabelControl();
            this.lkeEmployee = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblLineID = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNganh = new DevExpress.XtraEditors.LabelControl();
            this.dtpStatisticDate = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btSummary = new DevExpress.XtraEditors.SimpleButton();
            this.btDeleteAll = new DevExpress.XtraEditors.SimpleButton();
            this.btEditMulti = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gridExLosstime = new DevExpress.XtraGrid.GridControl();
            this.gridExLosstimeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LosstimeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LosstimeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LosstimeNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LosstimeNumTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCbListEmpID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatisticDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatisticDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkCbListEmpID);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lblEmpName);
            this.panelControl1.Controls.Add(this.lkeEmployee);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lblLineID);
            this.panelControl1.Controls.Add(this.lblMaNganh);
            this.panelControl1.Controls.Add(this.dtpStatisticDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1082, 117);
            this.panelControl1.TabIndex = 0;
            // 
            // chkCbListEmpID
            // 
            this.chkCbListEmpID.Location = new System.Drawing.Point(151, 47);
            this.chkCbListEmpID.Margin = new System.Windows.Forms.Padding(4);
            this.chkCbListEmpID.MaximumSize = new System.Drawing.Size(500, 50);
            this.chkCbListEmpID.MinimumSize = new System.Drawing.Size(300, 50);
            this.chkCbListEmpID.Name = "chkCbListEmpID";
            this.chkCbListEmpID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkCbListEmpID.Size = new System.Drawing.Size(500, 23);
            this.chkCbListEmpID.TabIndex = 113;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 52);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 16);
            this.labelControl2.TabIndex = 112;
            this.labelControl2.Text = "Chọn nhân viên";
            // 
            // lblEmpName
            // 
            this.lblEmpName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblEmpName.Appearance.Options.UseFont = true;
            this.lblEmpName.Appearance.Options.UseForeColor = true;
            this.lblEmpName.Location = new System.Drawing.Point(391, 48);
            this.lblEmpName.Margin = new System.Windows.Forms.Padding(4);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(108, 24);
            this.lblEmpName.TabIndex = 110;
            this.lblEmpName.Text = "Emp Name";
            this.lblEmpName.Visible = false;
            // 
            // lkeEmployee
            // 
            this.lkeEmployee.EditValue = "";
            this.lkeEmployee.Location = new System.Drawing.Point(151, 48);
            this.lkeEmployee.Name = "lkeEmployee";
            this.lkeEmployee.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeEmployee.Properties.NullText = "";
            this.lkeEmployee.Size = new System.Drawing.Size(200, 23);
            this.lkeEmployee.TabIndex = 109;
            this.lkeEmployee.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 55);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 16);
            this.labelControl1.TabIndex = 87;
            this.labelControl1.Text = "Mã nhân viên";
            this.labelControl1.Visible = false;
            // 
            // lblLineID
            // 
            this.lblLineID.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineID.Appearance.ForeColor = System.Drawing.Color.Orange;
            this.lblLineID.Appearance.Options.UseFont = true;
            this.lblLineID.Appearance.Options.UseForeColor = true;
            this.lblLineID.Location = new System.Drawing.Point(391, 17);
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
            this.lblMaNganh.Size = new System.Drawing.Size(81, 16);
            this.lblMaNganh.TabIndex = 84;
            this.lblMaNganh.Text = "Ngày thống kê";
            // 
            // dtpStatisticDate
            // 
            this.dtpStatisticDate.EditValue = null;
            this.dtpStatisticDate.Location = new System.Drawing.Point(151, 18);
            this.dtpStatisticDate.MaximumSize = new System.Drawing.Size(400, 50);
            this.dtpStatisticDate.MinimumSize = new System.Drawing.Size(200, 20);
            this.dtpStatisticDate.Name = "dtpStatisticDate";
            this.dtpStatisticDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStatisticDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStatisticDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpStatisticDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpStatisticDate.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dtpStatisticDate.Properties.UseMaskAsDisplayFormat = true;
            this.dtpStatisticDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStatisticDate.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btSummary);
            this.panelControl2.Controls.Add(this.btDeleteAll);
            this.panelControl2.Controls.Add(this.btEditMulti);
            this.panelControl2.Controls.Add(this.btDelete);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Controls.Add(this.btCancel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 580);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1082, 77);
            this.panelControl2.TabIndex = 1;
            // 
            // btSummary
            // 
            this.btSummary.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btSummary.ImageOptions.Image = global::ASPProject.Properties.Resources.paper;
            this.btSummary.Location = new System.Drawing.Point(700, 14);
            this.btSummary.Margin = new System.Windows.Forms.Padding(4);
            this.btSummary.Name = "btSummary";
            this.btSummary.Size = new System.Drawing.Size(175, 49);
            this.btSummary.TabIndex = 129;
            this.btSummary.Text = "Tổng kết";
            // 
            // btDeleteAll
            // 
            this.btDeleteAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDeleteAll.ImageOptions.Image = global::ASPProject.Properties.Resources.close;
            this.btDeleteAll.Location = new System.Drawing.Point(896, 14);
            this.btDeleteAll.Margin = new System.Windows.Forms.Padding(4);
            this.btDeleteAll.Name = "btDeleteAll";
            this.btDeleteAll.Size = new System.Drawing.Size(160, 49);
            this.btDeleteAll.TabIndex = 74;
            this.btDeleteAll.Text = "Xoá tất cả";
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
            this.btDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btDelete.Location = new System.Drawing.Point(529, 14);
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
            // gridExLosstime
            // 
            this.gridExLosstime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExLosstime.Location = new System.Drawing.Point(0, 117);
            this.gridExLosstime.MainView = this.gridExLosstimeView;
            this.gridExLosstime.Name = "gridExLosstime";
            this.gridExLosstime.Size = new System.Drawing.Size(1082, 463);
            this.gridExLosstime.TabIndex = 2;
            this.gridExLosstime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridExLosstimeView});
            // 
            // gridExLosstimeView
            // 
            this.gridExLosstimeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LosstimeID,
            this.LosstimeName,
            this.LineID,
            this.EmpID,
            this.LosstimeNum,
            this.LosstimeNumTC,
            this.Description,
            this.StartTime,
            this.EndTime});
            this.gridExLosstimeView.GridControl = this.gridExLosstime;
            this.gridExLosstimeView.Name = "gridExLosstimeView";
            this.gridExLosstimeView.OptionsBehavior.Editable = false;
            this.gridExLosstimeView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridExLosstimeView.OptionsSelection.MultiSelect = true;
            this.gridExLosstimeView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridExLosstimeView.OptionsView.ShowAutoFilterRow = true;
            this.gridExLosstimeView.OptionsView.ShowGroupPanel = false;
            // 
            // LosstimeID
            // 
            this.LosstimeID.Caption = "Mã Losstime";
            this.LosstimeID.FieldName = "LosstimeID";
            this.LosstimeID.MinWidth = 25;
            this.LosstimeID.Name = "LosstimeID";
            this.LosstimeID.Visible = true;
            this.LosstimeID.VisibleIndex = 1;
            this.LosstimeID.Width = 94;
            // 
            // LosstimeName
            // 
            this.LosstimeName.Caption = "Tên Losstime";
            this.LosstimeName.FieldName = "LosstimeName";
            this.LosstimeName.MinWidth = 25;
            this.LosstimeName.Name = "LosstimeName";
            this.LosstimeName.Visible = true;
            this.LosstimeName.VisibleIndex = 2;
            this.LosstimeName.Width = 94;
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
            // EmpID
            // 
            this.EmpID.Caption = "Mã nhân viên";
            this.EmpID.FieldName = "EmpID";
            this.EmpID.MinWidth = 25;
            this.EmpID.Name = "EmpID";
            this.EmpID.Visible = true;
            this.EmpID.VisibleIndex = 4;
            this.EmpID.Width = 94;
            // 
            // LosstimeNum
            // 
            this.LosstimeNum.Caption = "Giờ  Losstime HC";
            this.LosstimeNum.DisplayFormat.FormatString = "#0.00";
            this.LosstimeNum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LosstimeNum.FieldName = "LosstimeNum";
            this.LosstimeNum.MinWidth = 25;
            this.LosstimeNum.Name = "LosstimeNum";
            this.LosstimeNum.Visible = true;
            this.LosstimeNum.VisibleIndex = 5;
            this.LosstimeNum.Width = 94;
            // 
            // LosstimeNumTC
            // 
            this.LosstimeNumTC.Caption = "Giờ Losstime TC";
            this.LosstimeNumTC.DisplayFormat.FormatString = "#0.00";
            this.LosstimeNumTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LosstimeNumTC.FieldName = "LosstimeNumTC";
            this.LosstimeNumTC.MinWidth = 25;
            this.LosstimeNumTC.Name = "LosstimeNumTC";
            this.LosstimeNumTC.Visible = true;
            this.LosstimeNumTC.VisibleIndex = 6;
            this.LosstimeNumTC.Width = 94;
            // 
            // Description
            // 
            this.Description.Caption = "Ghi chú";
            this.Description.FieldName = "Description";
            this.Description.MinWidth = 25;
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 9;
            this.Description.Width = 94;
            // 
            // StartTime
            // 
            this.StartTime.Caption = "Thời gian bắt đầu";
            this.StartTime.DisplayFormat.FormatString = "#0.00";
            this.StartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.StartTime.FieldName = "StartTime";
            this.StartTime.MinWidth = 25;
            this.StartTime.Name = "StartTime";
            this.StartTime.Visible = true;
            this.StartTime.VisibleIndex = 7;
            this.StartTime.Width = 94;
            // 
            // EndTime
            // 
            this.EndTime.Caption = "Thời gian kết thúc";
            this.EndTime.DisplayFormat.FormatString = "#0.00";
            this.EndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EndTime.FieldName = "EndTime";
            this.EndTime.MinWidth = 25;
            this.EndTime.Name = "EndTime";
            this.EndTime.Visible = true;
            this.EndTime.VisibleIndex = 8;
            this.EndTime.Width = 94;
            // 
            // frmExLosstime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 657);
            this.Controls.Add(this.gridExLosstime);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmExLosstime";
            this.Text = "ExLosstime";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCbListEmpID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatisticDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStatisticDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridExLosstime;
        private DevExpress.XtraGrid.Views.Grid.GridView gridExLosstimeView;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.DateEdit dtpStatisticDate;
        private DevExpress.XtraEditors.LabelControl lblLineID;
        private DevExpress.XtraEditors.LabelControl lblMaNganh;
        private DevExpress.XtraGrid.Columns.GridColumn LosstimeID;
        private DevExpress.XtraGrid.Columns.GridColumn LosstimeName;
        private DevExpress.XtraGrid.Columns.GridColumn LineID;
        private DevExpress.XtraGrid.Columns.GridColumn LosstimeNum;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SimpleButton btDelete;
        private DevExpress.XtraEditors.SimpleButton btEditMulti;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblEmpName;
        private DevExpress.XtraEditors.LookUpEdit lkeEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn EmpID;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btDeleteAll;
        private DevExpress.XtraEditors.SimpleButton btSummary;
        private DevExpress.XtraGrid.Columns.GridColumn LosstimeNumTC;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkCbListEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn StartTime;
        private DevExpress.XtraGrid.Columns.GridColumn EndTime;
    }
}