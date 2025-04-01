namespace ASPProject.ProdQRCodeMaster
{
    partial class frmProdQRCodeSummary
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lkeWO = new DevExpress.XtraEditors.LookUpEdit();
            this.lbLSX = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.gridProdQRCodeSum = new DevExpress.XtraGrid.GridControl();
            this.gridProdQRCodeSumView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.WODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SumOfOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SumOfNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SumOfRework = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SumOfScrap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkeStageID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdQRCodeSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdQRCodeSumView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStageID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(315, 31);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Đến ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 31);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Từ ngày";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(400, 26);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
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
            this.dtToDate.TabIndex = 17;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(110, 26);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
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
            this.dtFromDate.TabIndex = 16;
            // 
            // btFilter
            // 
            this.btFilter.ImageOptions.Image = global::ASPProject.Properties.Resources.preview_file;
            this.btFilter.Location = new System.Drawing.Point(636, 23);
            this.btFilter.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(120, 30);
            this.btFilter.TabIndex = 15;
            this.btFilter.Text = "Lọc";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lkeStageID);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lkeWO);
            this.panelControl1.Controls.Add(this.lbLSX);
            this.panelControl1.Controls.Add(this.checkEdit2);
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.dtToDate);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btFilter);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dtFromDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1446, 106);
            this.panelControl1.TabIndex = 20;
            // 
            // lkeWO
            // 
            this.lkeWO.EditValue = "";
            this.lkeWO.Location = new System.Drawing.Point(110, 61);
            this.lkeWO.Name = "lkeWO";
            this.lkeWO.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeWO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeWO.Properties.NullText = "";
            this.lkeWO.Size = new System.Drawing.Size(166, 23);
            this.lkeWO.TabIndex = 120;
            // 
            // lbLSX
            // 
            this.lbLSX.Location = new System.Drawing.Point(5, 67);
            this.lbLSX.Margin = new System.Windows.Forms.Padding(4);
            this.lbLSX.Name = "lbLSX";
            this.lbLSX.Size = new System.Drawing.Size(79, 16);
            this.lbLSX.TabIndex = 121;
            this.lbLSX.Text = "Lệnh sản xuất";
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(792, 64);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Theo ngày";
            this.checkEdit2.Size = new System.Drawing.Size(150, 20);
            this.checkEdit2.TabIndex = 119;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(636, 66);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Theo lệnh sản xuất";
            this.checkEdit1.Size = new System.Drawing.Size(150, 20);
            this.checkEdit1.TabIndex = 118;
            // 
            // gridProdQRCodeSum
            // 
            this.gridProdQRCodeSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProdQRCodeSum.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gridProdQRCodeSum.Location = new System.Drawing.Point(0, 106);
            this.gridProdQRCodeSum.MainView = this.gridProdQRCodeSumView;
            this.gridProdQRCodeSum.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gridProdQRCodeSum.Name = "gridProdQRCodeSum";
            this.gridProdQRCodeSum.Size = new System.Drawing.Size(1446, 625);
            this.gridProdQRCodeSum.TabIndex = 21;
            this.gridProdQRCodeSum.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProdQRCodeSumView});
            // 
            // gridProdQRCodeSumView
            // 
            this.gridProdQRCodeSumView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.WODocNo,
            this.ProductID,
            this.SumOfOK,
            this.SumOfNG,
            this.SumOfRework,
            this.SumOfScrap});
            this.gridProdQRCodeSumView.DetailHeight = 852;
            this.gridProdQRCodeSumView.GridControl = this.gridProdQRCodeSum;
            this.gridProdQRCodeSumView.Name = "gridProdQRCodeSumView";
            this.gridProdQRCodeSumView.OptionsBehavior.ReadOnly = true;
            this.gridProdQRCodeSumView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridProdQRCodeSumView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridProdQRCodeSumView.OptionsView.RowAutoHeight = true;
            this.gridProdQRCodeSumView.OptionsView.ShowAutoFilterRow = true;
            this.gridProdQRCodeSumView.OptionsView.ShowFooter = true;
            this.gridProdQRCodeSumView.OptionsView.ShowGroupPanel = false;
            // 
            // WODocNo
            // 
            this.WODocNo.Caption = "Lệnh sản xuất";
            this.WODocNo.FieldName = "WODocNo";
            this.WODocNo.MinWidth = 25;
            this.WODocNo.Name = "WODocNo";
            this.WODocNo.Visible = true;
            this.WODocNo.VisibleIndex = 0;
            this.WODocNo.Width = 94;
            // 
            // ProductID
            // 
            this.ProductID.Caption = "Mã sản phẩm";
            this.ProductID.FieldName = "ProductID";
            this.ProductID.MinWidth = 25;
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = true;
            this.ProductID.VisibleIndex = 1;
            this.ProductID.Width = 94;
            // 
            // SumOfOK
            // 
            this.SumOfOK.Caption = "Số lượng OK";
            this.SumOfOK.FieldName = "SumOfOK";
            this.SumOfOK.MinWidth = 25;
            this.SumOfOK.Name = "SumOfOK";
            this.SumOfOK.Visible = true;
            this.SumOfOK.VisibleIndex = 2;
            this.SumOfOK.Width = 94;
            // 
            // SumOfNG
            // 
            this.SumOfNG.Caption = "Số lượng NG";
            this.SumOfNG.FieldName = "SumOfNG";
            this.SumOfNG.MinWidth = 25;
            this.SumOfNG.Name = "SumOfNG";
            this.SumOfNG.Visible = true;
            this.SumOfNG.VisibleIndex = 3;
            this.SumOfNG.Width = 94;
            // 
            // SumOfRework
            // 
            this.SumOfRework.Caption = "Số lượng Rework";
            this.SumOfRework.FieldName = "SumOfRework";
            this.SumOfRework.MinWidth = 25;
            this.SumOfRework.Name = "SumOfRework";
            this.SumOfRework.Visible = true;
            this.SumOfRework.VisibleIndex = 4;
            this.SumOfRework.Width = 94;
            // 
            // SumOfScrap
            // 
            this.SumOfScrap.Caption = "Số lượng Scrap";
            this.SumOfScrap.FieldName = "SumOfScrap";
            this.SumOfScrap.MinWidth = 25;
            this.SumOfScrap.Name = "SumOfScrap";
            this.SumOfScrap.Visible = true;
            this.SumOfScrap.VisibleIndex = 5;
            this.SumOfScrap.Width = 94;
            // 
            // lkeStageID
            // 
            this.lkeStageID.EditValue = "";
            this.lkeStageID.Location = new System.Drawing.Point(400, 64);
            this.lkeStageID.Name = "lkeStageID";
            this.lkeStageID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeStageID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeStageID.Properties.NullText = "";
            this.lkeStageID.Size = new System.Drawing.Size(166, 23);
            this.lkeStageID.TabIndex = 122;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(315, 70);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 16);
            this.labelControl3.TabIndex = 123;
            this.labelControl3.Text = "Công đoạn";
            // 
            // frmProdQRCodeSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 731);
            this.Controls.Add(this.gridProdQRCodeSum);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProdQRCodeSummary";
            this.Text = "Tổng hợp dữ liệu QR Code";
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeWO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdQRCodeSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdQRCodeSumView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeStageID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridProdQRCodeSum;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProdQRCodeSumView;
        private DevExpress.XtraGrid.Columns.GridColumn WODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn SumOfOK;
        private DevExpress.XtraGrid.Columns.GridColumn SumOfNG;
        private DevExpress.XtraGrid.Columns.GridColumn SumOfRework;
        private DevExpress.XtraGrid.Columns.GridColumn SumOfScrap;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.LookUpEdit lkeWO;
        private DevExpress.XtraEditors.LabelControl lbLSX;
        private DevExpress.XtraEditors.LookUpEdit lkeStageID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}