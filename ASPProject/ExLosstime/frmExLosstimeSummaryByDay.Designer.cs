namespace ASPProject.ExLosstime
{
    partial class frmExLosstimeSummaryByDay
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
            this.gridExLosstimeSummary = new DevExpress.XtraGrid.GridControl();
            this.gridExLosstimeSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLosstimeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLosstimeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLosstimeNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridExLosstimeSum = new DevExpress.XtraGrid.GridControl();
            this.gridExLosstimeSumView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LosstimeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LosstimeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LosstimeNum = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSummaryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSumView)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.gridExLosstimeSummary);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridExLosstimeSum);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(958, 560);
            this.splitContainerControl1.SplitterPosition = 272;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gridExLosstimeSummary
            // 
            this.gridExLosstimeSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExLosstimeSummary.Location = new System.Drawing.Point(0, 0);
            this.gridExLosstimeSummary.MainView = this.gridExLosstimeSummaryView;
            this.gridExLosstimeSummary.Name = "gridExLosstimeSummary";
            this.gridExLosstimeSummary.Size = new System.Drawing.Size(958, 272);
            this.gridExLosstimeSummary.TabIndex = 4;
            this.gridExLosstimeSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridExLosstimeSummaryView});
            // 
            // gridExLosstimeSummaryView
            // 
            this.gridExLosstimeSummaryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineID,
            this.colLosstimeID,
            this.colLosstimeName,
            this.colLosstimeNum});
            this.gridExLosstimeSummaryView.GridControl = this.gridExLosstimeSummary;
            this.gridExLosstimeSummaryView.Name = "gridExLosstimeSummaryView";
            this.gridExLosstimeSummaryView.OptionsBehavior.Editable = false;
            this.gridExLosstimeSummaryView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridExLosstimeSummaryView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridExLosstimeSummaryView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridExLosstimeSummaryView.OptionsView.ShowAutoFilterRow = true;
            this.gridExLosstimeSummaryView.OptionsView.ShowGroupPanel = false;
            // 
            // colLineID
            // 
            this.colLineID.Caption = "Mã Line";
            this.colLineID.FieldName = "LineID";
            this.colLineID.MinWidth = 25;
            this.colLineID.Name = "colLineID";
            this.colLineID.Visible = true;
            this.colLineID.VisibleIndex = 0;
            this.colLineID.Width = 94;
            // 
            // colLosstimeID
            // 
            this.colLosstimeID.Caption = "Mã Losstime";
            this.colLosstimeID.FieldName = "LosstimeID";
            this.colLosstimeID.MinWidth = 25;
            this.colLosstimeID.Name = "colLosstimeID";
            this.colLosstimeID.Visible = true;
            this.colLosstimeID.VisibleIndex = 1;
            this.colLosstimeID.Width = 94;
            // 
            // colLosstimeName
            // 
            this.colLosstimeName.Caption = "Tên Losstime";
            this.colLosstimeName.FieldName = "LosstimeName";
            this.colLosstimeName.MinWidth = 25;
            this.colLosstimeName.Name = "colLosstimeName";
            this.colLosstimeName.Visible = true;
            this.colLosstimeName.VisibleIndex = 2;
            this.colLosstimeName.Width = 94;
            // 
            // colLosstimeNum
            // 
            this.colLosstimeNum.Caption = "Số giờ";
            this.colLosstimeNum.DisplayFormat.FormatString = "#0.00";
            this.colLosstimeNum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLosstimeNum.FieldName = "LosstimeNum";
            this.colLosstimeNum.MinWidth = 25;
            this.colLosstimeNum.Name = "colLosstimeNum";
            this.colLosstimeNum.Visible = true;
            this.colLosstimeNum.VisibleIndex = 3;
            this.colLosstimeNum.Width = 94;
            // 
            // gridExLosstimeSum
            // 
            this.gridExLosstimeSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExLosstimeSum.Location = new System.Drawing.Point(0, 0);
            this.gridExLosstimeSum.MainView = this.gridExLosstimeSumView;
            this.gridExLosstimeSum.Name = "gridExLosstimeSum";
            this.gridExLosstimeSum.Size = new System.Drawing.Size(958, 281);
            this.gridExLosstimeSum.TabIndex = 4;
            this.gridExLosstimeSum.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridExLosstimeSumView});
            // 
            // gridExLosstimeSumView
            // 
            this.gridExLosstimeSumView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.LosstimeID,
            this.LosstimeName,
            this.LosstimeNum});
            this.gridExLosstimeSumView.GridControl = this.gridExLosstimeSum;
            this.gridExLosstimeSumView.Name = "gridExLosstimeSumView";
            this.gridExLosstimeSumView.OptionsBehavior.Editable = false;
            this.gridExLosstimeSumView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridExLosstimeSumView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridExLosstimeSumView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridExLosstimeSumView.OptionsView.ShowGroupPanel = false;
            // 
            // LosstimeID
            // 
            this.LosstimeID.Caption = "Mã Losstime";
            this.LosstimeID.FieldName = "LosstimeID";
            this.LosstimeID.MinWidth = 25;
            this.LosstimeID.Name = "LosstimeID";
            this.LosstimeID.Visible = true;
            this.LosstimeID.VisibleIndex = 0;
            this.LosstimeID.Width = 94;
            // 
            // LosstimeName
            // 
            this.LosstimeName.Caption = "Tên Losstime";
            this.LosstimeName.FieldName = "LosstimeName";
            this.LosstimeName.MinWidth = 25;
            this.LosstimeName.Name = "LosstimeName";
            this.LosstimeName.Visible = true;
            this.LosstimeName.VisibleIndex = 1;
            this.LosstimeName.Width = 94;
            // 
            // LosstimeNum
            // 
            this.LosstimeNum.Caption = "Số giờ";
            this.LosstimeNum.DisplayFormat.FormatString = "#0.00";
            this.LosstimeNum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.LosstimeNum.FieldName = "LosstimeNum";
            this.LosstimeNum.MinWidth = 25;
            this.LosstimeNum.Name = "LosstimeNum";
            this.LosstimeNum.Visible = true;
            this.LosstimeNum.VisibleIndex = 2;
            this.LosstimeNum.Width = 94;
            // 
            // frmExLosstimeSummaryByDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 560);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmExLosstimeSummaryByDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmExLosstimeSummaryByDay";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSummaryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExLosstimeSumView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridExLosstimeSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridExLosstimeSummaryView;
        private DevExpress.XtraGrid.GridControl gridExLosstimeSum;
        private DevExpress.XtraGrid.Views.Grid.GridView gridExLosstimeSumView;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colLosstimeID;
        private DevExpress.XtraGrid.Columns.GridColumn colLosstimeName;
        private DevExpress.XtraGrid.Columns.GridColumn colLosstimeNum;
        private DevExpress.XtraGrid.Columns.GridColumn LosstimeID;
        private DevExpress.XtraGrid.Columns.GridColumn LosstimeName;
        private DevExpress.XtraGrid.Columns.GridColumn LosstimeNum;
    }
}