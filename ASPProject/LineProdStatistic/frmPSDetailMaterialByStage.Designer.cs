namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailMaterialByStage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPSDetailMaterialByStage));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.gridStatSummary = new DevExpress.XtraGrid.GridControl();
            this.gridStatSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lkeReportID = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummaryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeReportID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.lkeReportID);
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
            this.splitContainerControl1.Panel2.Controls.Add(this.gridStatSummary);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(977, 555);
            this.splitContainerControl1.SplitterPosition = 71;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // btExport
            // 
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(666, 36);
            this.btExport.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(103, 24);
            this.btExport.TabIndex = 15;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(391, 41);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(176, 41);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(453, 37);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(142, 20);
            this.dtToDate.TabIndex = 12;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(230, 37);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(142, 20);
            this.dtFromDate.TabIndex = 11;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(667, 6);
            this.btFilter.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(103, 24);
            this.btFilter.TabIndex = 10;
            this.btFilter.Text = "Lọc";
            // 
            // gridStatSummary
            // 
            this.gridStatSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatSummary.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gridStatSummary.Location = new System.Drawing.Point(0, 0);
            this.gridStatSummary.MainView = this.gridStatSummaryView;
            this.gridStatSummary.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gridStatSummary.Name = "gridStatSummary";
            this.gridStatSummary.Size = new System.Drawing.Size(977, 478);
            this.gridStatSummary.TabIndex = 3;
            this.gridStatSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridStatSummaryView});
            // 
            // gridStatSummaryView
            // 
            this.gridStatSummaryView.DetailHeight = 692;
            this.gridStatSummaryView.GridControl = this.gridStatSummary;
            this.gridStatSummaryView.Name = "gridStatSummaryView";
            this.gridStatSummaryView.OptionsBehavior.ReadOnly = true;
            this.gridStatSummaryView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridStatSummaryView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridStatSummaryView.OptionsView.RowAutoHeight = true;
            this.gridStatSummaryView.OptionsView.ShowAutoFilterRow = true;
            this.gridStatSummaryView.OptionsView.ShowFooter = true;
            this.gridStatSummaryView.OptionsView.ShowGroupPanel = false;
            // 
            // lkeReportID
            // 
            this.lkeReportID.EditValue = "";
            this.lkeReportID.Location = new System.Drawing.Point(176, 13);
            this.lkeReportID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkeReportID.Name = "lkeReportID";
            this.lkeReportID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeReportID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeReportID.Properties.NullText = "";
            this.lkeReportID.Size = new System.Drawing.Size(419, 20);
            this.lkeReportID.TabIndex = 88;
            // 
            // frmPSDetailMaterialByStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 555);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPSDetailMaterialByStage";
            this.Text = "frmProdStatisticSummaryReport";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatSummaryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeReportID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraGrid.GridControl gridStatSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridStatSummaryView;
        private DevExpress.XtraEditors.LookUpEdit lkeReportID;
    }
}