namespace ASPProject.LineProdStatistic
{
    partial class frmPSRptDetailJig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPSRptDetailJig));
            this.btRestart = new DevExpress.XtraEditors.SimpleButton();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridMachine = new DevExpress.XtraGrid.GridControl();
            this.gridMachineView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.JigID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JigName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QuotaQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DifferenceNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsCheckedKTV = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineView)).BeginInit();
            this.SuspendLayout();
            // 
            // btRestart
            // 
            this.btRestart.ImageOptions.Image = global::ASPProject.Properties.Resources.refresh;
            this.btRestart.Location = new System.Drawing.Point(877, 48);
            this.btRestart.Margin = new System.Windows.Forms.Padding(8);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(157, 30);
            this.btRestart.TabIndex = 16;
            this.btRestart.Text = "Bắt đầu lại";
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(877, 11);
            this.btExport.Margin = new System.Windows.Forms.Padding(8);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(157, 30);
            this.btExport.TabIndex = 15;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(352, 23);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 23);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(461, 18);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(8);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(166, 23);
            this.dtToDate.TabIndex = 12;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(137, 18);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(8);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(166, 23);
            this.dtFromDate.TabIndex = 11;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(728, 11);
            this.btFilter.Margin = new System.Windows.Forms.Padding(8);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(120, 30);
            this.btFilter.TabIndex = 10;
            this.btFilter.Text = "Lọc";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(8);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.btRestart);
            this.splitContainerControl1.Panel1.Controls.Add(this.btExport);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtToDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtFromDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridMachine);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1084, 614);
            this.splitContainerControl1.SplitterPosition = 89;
            this.splitContainerControl1.TabIndex = 3;
            // 
            // gridMachine
            // 
            this.gridMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMachine.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gridMachine.Location = new System.Drawing.Point(0, 0);
            this.gridMachine.MainView = this.gridMachineView;
            this.gridMachine.Margin = new System.Windows.Forms.Padding(6);
            this.gridMachine.Name = "gridMachine";
            this.gridMachine.Size = new System.Drawing.Size(1084, 520);
            this.gridMachine.TabIndex = 7;
            this.gridMachine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMachineView});
            // 
            // gridMachineView
            // 
            this.gridMachineView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.JigID,
            this.JigName,
            this.Quantity,
            this.QuotaQuantity,
            this.DifferenceNum,
            this.IsChecked,
            this.IsCheckedKTV});
            this.gridMachineView.DetailHeight = 682;
            this.gridMachineView.GridControl = this.gridMachine;
            this.gridMachineView.Name = "gridMachineView";
            this.gridMachineView.OptionsBehavior.Editable = false;
            this.gridMachineView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridMachineView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridMachineView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridMachineView.OptionsView.ShowAutoFilterRow = true;
            this.gridMachineView.OptionsView.ShowGroupPanel = false;
            // 
            // JigID
            // 
            this.JigID.Caption = "Mã Jig";
            this.JigID.FieldName = "JigID";
            this.JigID.MinWidth = 25;
            this.JigID.Name = "JigID";
            this.JigID.Visible = true;
            this.JigID.VisibleIndex = 0;
            this.JigID.Width = 94;
            // 
            // JigName
            // 
            this.JigName.Caption = "Tên Jig";
            this.JigName.FieldName = "JigName";
            this.JigName.MinWidth = 25;
            this.JigName.Name = "JigName";
            this.JigName.Visible = true;
            this.JigName.VisibleIndex = 1;
            this.JigName.Width = 94;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "Số lượng";
            this.Quantity.FieldName = "Quantity";
            this.Quantity.MinWidth = 25;
            this.Quantity.Name = "Quantity";
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 2;
            this.Quantity.Width = 94;
            // 
            // QuotaQuantity
            // 
            this.QuotaQuantity.Caption = "Định mức";
            this.QuotaQuantity.FieldName = "QuotaQuantity";
            this.QuotaQuantity.MinWidth = 25;
            this.QuotaQuantity.Name = "QuotaQuantity";
            this.QuotaQuantity.Visible = true;
            this.QuotaQuantity.VisibleIndex = 3;
            this.QuotaQuantity.Width = 94;
            // 
            // DifferenceNum
            // 
            this.DifferenceNum.Caption = "Vượt định mức";
            this.DifferenceNum.FieldName = "DifferenceNum";
            this.DifferenceNum.MinWidth = 25;
            this.DifferenceNum.Name = "DifferenceNum";
            this.DifferenceNum.Visible = true;
            this.DifferenceNum.VisibleIndex = 4;
            this.DifferenceNum.Width = 94;
            // 
            // IsChecked
            // 
            this.IsChecked.Caption = "QC đã kiểm tra";
            this.IsChecked.FieldName = "IsChecked";
            this.IsChecked.MinWidth = 25;
            this.IsChecked.Name = "IsChecked";
            this.IsChecked.Visible = true;
            this.IsChecked.VisibleIndex = 5;
            this.IsChecked.Width = 94;
            // 
            // IsCheckedKTV
            // 
            this.IsCheckedKTV.Caption = "KTV đã kiểm tra";
            this.IsCheckedKTV.FieldName = "IsCheckedKTV";
            this.IsCheckedKTV.MinWidth = 25;
            this.IsCheckedKTV.Name = "IsCheckedKTV";
            this.IsCheckedKTV.Visible = true;
            this.IsCheckedKTV.VisibleIndex = 6;
            this.IsCheckedKTV.Width = 94;
            // 
            // frmPSRptDetailJig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 614);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPSRptDetailJig";
            this.Text = "frmPSRptDetailJig";
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btRestart;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridMachine;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMachineView;
        private DevExpress.XtraGrid.Columns.GridColumn JigID;
        private DevExpress.XtraGrid.Columns.GridColumn JigName;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn QuotaQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn DifferenceNum;
        private DevExpress.XtraGrid.Columns.GridColumn IsChecked;
        private DevExpress.XtraGrid.Columns.GridColumn IsCheckedKTV;
    }
}