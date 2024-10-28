namespace ASPProject.LineProdStatistic
{
    partial class frmPSRptDetailMold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPSRptDetailMold));
            this.gridRptMoldView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMoldID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldMoldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumOfStamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCavity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumOfDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDifferenceNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridRptMold = new DevExpress.XtraGrid.GridControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btRestart = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridRptMoldView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRptMold)).BeginInit();
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
            this.SuspendLayout();
            // 
            // gridRptMoldView
            // 
            this.gridRptMoldView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridRptMoldView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMoldID,
            this.coldMoldName,
            this.colProdQuantity,
            this.colNumOfStamp,
            this.colCavity,
            this.colNumOfDefault,
            this.colDifferenceNum,
            this.colIsChecked});
            this.gridRptMoldView.DetailHeight = 852;
            this.gridRptMoldView.GridControl = this.gridRptMold;
            this.gridRptMoldView.Name = "gridRptMoldView";
            this.gridRptMoldView.OptionsBehavior.ReadOnly = true;
            this.gridRptMoldView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridRptMoldView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridRptMoldView.OptionsView.ColumnAutoWidth = false;
            this.gridRptMoldView.OptionsView.ShowAutoFilterRow = true;
            this.gridRptMoldView.OptionsView.ShowFooter = true;
            this.gridRptMoldView.OptionsView.ShowGroupPanel = false;
            // 
            // colMoldID
            // 
            this.colMoldID.Caption = "Mã mold";
            this.colMoldID.FieldName = "MoldID";
            this.colMoldID.MinWidth = 25;
            this.colMoldID.Name = "colMoldID";
            this.colMoldID.OptionsColumn.AllowEdit = false;
            this.colMoldID.OptionsColumn.FixedWidth = true;
            this.colMoldID.Visible = true;
            this.colMoldID.VisibleIndex = 0;
            this.colMoldID.Width = 120;
            // 
            // coldMoldName
            // 
            this.coldMoldName.Caption = "Tên mold";
            this.coldMoldName.FieldName = "MoldName";
            this.coldMoldName.MinWidth = 25;
            this.coldMoldName.Name = "coldMoldName";
            this.coldMoldName.OptionsColumn.AllowEdit = false;
            this.coldMoldName.OptionsColumn.FixedWidth = true;
            this.coldMoldName.Visible = true;
            this.coldMoldName.VisibleIndex = 1;
            this.coldMoldName.Width = 280;
            // 
            // colProdQuantity
            // 
            this.colProdQuantity.Caption = "Số lượng TP";
            this.colProdQuantity.FieldName = "ProdQuantity";
            this.colProdQuantity.MinWidth = 25;
            this.colProdQuantity.Name = "colProdQuantity";
            this.colProdQuantity.OptionsColumn.AllowEdit = false;
            this.colProdQuantity.OptionsColumn.FixedWidth = true;
            this.colProdQuantity.Visible = true;
            this.colProdQuantity.VisibleIndex = 2;
            this.colProdQuantity.Width = 120;
            // 
            // colNumOfStamp
            // 
            this.colNumOfStamp.Caption = "Số lần dập";
            this.colNumOfStamp.FieldName = "NumOfStamp";
            this.colNumOfStamp.MinWidth = 25;
            this.colNumOfStamp.Name = "colNumOfStamp";
            this.colNumOfStamp.OptionsColumn.AllowEdit = false;
            this.colNumOfStamp.OptionsColumn.FixedWidth = true;
            this.colNumOfStamp.Visible = true;
            this.colNumOfStamp.VisibleIndex = 3;
            this.colNumOfStamp.Width = 120;
            // 
            // colCavity
            // 
            this.colCavity.Caption = "Cavity";
            this.colCavity.FieldName = "Cavity";
            this.colCavity.MinWidth = 25;
            this.colCavity.Name = "colCavity";
            this.colCavity.OptionsColumn.AllowEdit = false;
            this.colCavity.OptionsColumn.FixedWidth = true;
            this.colCavity.Visible = true;
            this.colCavity.VisibleIndex = 4;
            this.colCavity.Width = 120;
            // 
            // colNumOfDefault
            // 
            this.colNumOfDefault.Caption = "Số lần định mức";
            this.colNumOfDefault.FieldName = "NumOfDefault";
            this.colNumOfDefault.MinWidth = 25;
            this.colNumOfDefault.Name = "colNumOfDefault";
            this.colNumOfDefault.OptionsColumn.AllowEdit = false;
            this.colNumOfDefault.OptionsColumn.FixedWidth = true;
            this.colNumOfDefault.Visible = true;
            this.colNumOfDefault.VisibleIndex = 5;
            this.colNumOfDefault.Width = 120;
            // 
            // colDifferenceNum
            // 
            this.colDifferenceNum.Caption = "Vượt định mức";
            this.colDifferenceNum.FieldName = "DifferenceNum";
            this.colDifferenceNum.MinWidth = 25;
            this.colDifferenceNum.Name = "colDifferenceNum";
            this.colDifferenceNum.OptionsColumn.AllowEdit = false;
            this.colDifferenceNum.OptionsColumn.FixedWidth = true;
            this.colDifferenceNum.Visible = true;
            this.colDifferenceNum.VisibleIndex = 6;
            this.colDifferenceNum.Width = 120;
            // 
            // colIsChecked
            // 
            this.colIsChecked.Caption = "Đã kiểm tra";
            this.colIsChecked.FieldName = "IsChecked";
            this.colIsChecked.MinWidth = 25;
            this.colIsChecked.Name = "colIsChecked";
            this.colIsChecked.OptionsColumn.AllowEdit = false;
            this.colIsChecked.Visible = true;
            this.colIsChecked.VisibleIndex = 7;
            this.colIsChecked.Width = 94;
            // 
            // gridRptMold
            // 
            this.gridRptMold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRptMold.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8);
            this.gridRptMold.Location = new System.Drawing.Point(0, 0);
            this.gridRptMold.MainView = this.gridRptMoldView;
            this.gridRptMold.Margin = new System.Windows.Forms.Padding(8);
            this.gridRptMold.Name = "gridRptMold";
            this.gridRptMold.Size = new System.Drawing.Size(1161, 550);
            this.gridRptMold.TabIndex = 3;
            this.gridRptMold.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridRptMoldView});
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
            this.dtToDate.Size = new System.Drawing.Size(166, 22);
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
            this.dtFromDate.Size = new System.Drawing.Size(166, 22);
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gridRptMold);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1161, 651);
            this.splitContainerControl1.SplitterPosition = 89;
            this.splitContainerControl1.TabIndex = 2;
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
            // frmPSRptDetailMold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 651);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPSRptDetailMold";
            this.Text = "frmPSRptDetailMold";
            ((System.ComponentModel.ISupportInitialize)(this.gridRptMoldView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRptMold)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridRptMoldView;
        private DevExpress.XtraGrid.GridControl gridRptMold;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMoldID;
        private DevExpress.XtraGrid.Columns.GridColumn coldMoldName;
        private DevExpress.XtraGrid.Columns.GridColumn colProdQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colNumOfStamp;
        private DevExpress.XtraGrid.Columns.GridColumn colCavity;
        private DevExpress.XtraGrid.Columns.GridColumn colNumOfDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colDifferenceNum;
        private DevExpress.XtraGrid.Columns.GridColumn colIsChecked;
        private DevExpress.XtraEditors.SimpleButton btRestart;
    }
}