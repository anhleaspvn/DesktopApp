namespace ASPProject.AttendanceEmployee
{
    partial class frmAttendanceSummary
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
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridAttendanceSummary = new DevExpress.XtraGrid.GridControl();
            this.gridAttendanceSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TimekeepID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TimekeepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TimekeepQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridOverallSum = new DevExpress.XtraGrid.GridControl();
            this.gridOverallSumView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpHC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpSoon = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpTC = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).BeginInit();
            this.splitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).BeginInit();
            this.splitContainerControl2.Panel2.SuspendLayout();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceSummaryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverallSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverallSumView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpHC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSoon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpTC.Properties)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtEmpV);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtEmpP);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtEmpHC);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtEmpSoon);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtEmpTC);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1103, 668);
            this.splitContainerControl1.SplitterPosition = 533;
            this.splitContainerControl1.TabIndex = 0;
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
            this.splitContainerControl2.Panel1.Controls.Add(this.gridAttendanceSummary);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            // 
            // splitContainerControl2.Panel2
            // 
            this.splitContainerControl2.Panel2.Controls.Add(this.gridOverallSum);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1103, 533);
            this.splitContainerControl2.SplitterPosition = 337;
            this.splitContainerControl2.TabIndex = 5;
            // 
            // gridAttendanceSummary
            // 
            this.gridAttendanceSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttendanceSummary.Location = new System.Drawing.Point(0, 0);
            this.gridAttendanceSummary.MainView = this.gridAttendanceSummaryView;
            this.gridAttendanceSummary.Name = "gridAttendanceSummary";
            this.gridAttendanceSummary.Size = new System.Drawing.Size(1103, 337);
            this.gridAttendanceSummary.TabIndex = 3;
            this.gridAttendanceSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAttendanceSummaryView});
            // 
            // gridAttendanceSummaryView
            // 
            this.gridAttendanceSummaryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineID,
            this.TimekeepID,
            this.TimekeepName,
            this.TimekeepQuantity});
            this.gridAttendanceSummaryView.GridControl = this.gridAttendanceSummary;
            this.gridAttendanceSummaryView.Name = "gridAttendanceSummaryView";
            this.gridAttendanceSummaryView.OptionsBehavior.Editable = false;
            this.gridAttendanceSummaryView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridAttendanceSummaryView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridAttendanceSummaryView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridAttendanceSummaryView.OptionsView.ShowAutoFilterRow = true;
            this.gridAttendanceSummaryView.OptionsView.ShowGroupPanel = false;
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
            // TimekeepID
            // 
            this.TimekeepID.Caption = "Mã ký hiệu công";
            this.TimekeepID.FieldName = "TimekeepID";
            this.TimekeepID.MinWidth = 25;
            this.TimekeepID.Name = "TimekeepID";
            this.TimekeepID.Visible = true;
            this.TimekeepID.VisibleIndex = 1;
            this.TimekeepID.Width = 94;
            // 
            // TimekeepName
            // 
            this.TimekeepName.Caption = "Tên ký hiệu công";
            this.TimekeepName.FieldName = "TimekeepName";
            this.TimekeepName.MinWidth = 25;
            this.TimekeepName.Name = "TimekeepName";
            this.TimekeepName.Visible = true;
            this.TimekeepName.VisibleIndex = 2;
            this.TimekeepName.Width = 94;
            // 
            // TimekeepQuantity
            // 
            this.TimekeepQuantity.Caption = "Số lượng";
            this.TimekeepQuantity.DisplayFormat.FormatString = "#0.00";
            this.TimekeepQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TimekeepQuantity.FieldName = "TimekeepQuantity";
            this.TimekeepQuantity.MinWidth = 25;
            this.TimekeepQuantity.Name = "TimekeepQuantity";
            this.TimekeepQuantity.Visible = true;
            this.TimekeepQuantity.VisibleIndex = 3;
            this.TimekeepQuantity.Width = 94;
            // 
            // gridOverallSum
            // 
            this.gridOverallSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOverallSum.Location = new System.Drawing.Point(0, 0);
            this.gridOverallSum.MainView = this.gridOverallSumView;
            this.gridOverallSum.Name = "gridOverallSum";
            this.gridOverallSum.Size = new System.Drawing.Size(1103, 189);
            this.gridOverallSum.TabIndex = 4;
            this.gridOverallSum.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridOverallSumView});
            // 
            // gridOverallSumView
            // 
            this.gridOverallSumView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridOverallSumView.GridControl = this.gridOverallSum;
            this.gridOverallSumView.Name = "gridOverallSumView";
            this.gridOverallSumView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridOverallSumView.OptionsBehavior.Editable = false;
            this.gridOverallSumView.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridOverallSumView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridOverallSumView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridOverallSumView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridOverallSumView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridOverallSumView.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.gridOverallSumView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridOverallSumView.OptionsView.ShowFooter = true;
            this.gridOverallSumView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã ký hiệu công";
            this.gridColumn2.FieldName = "TimekeepID";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên ký hiệu công";
            this.gridColumn3.FieldName = "TimekeepName";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Số lượng";
            this.gridColumn4.DisplayFormat.FormatString = "#0.00";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "TimekeepQuantity";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TimekeepQuantity", "{0:0.##}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 94;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(507, 13);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(133, 21);
            this.labelControl2.TabIndex = 132;
            this.labelControl2.Text = "Số người vắng (V)";
            // 
            // txtEmpV
            // 
            this.txtEmpV.Location = new System.Drawing.Point(736, 11);
            this.txtEmpV.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpV.Name = "txtEmpV";
            this.txtEmpV.Properties.DisplayFormat.FormatString = "#0";
            this.txtEmpV.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpV.Properties.EditFormat.FormatString = "#0";
            this.txtEmpV.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpV.Size = new System.Drawing.Size(190, 23);
            this.txtEmpV.TabIndex = 131;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(507, 44);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(169, 21);
            this.labelControl3.TabIndex = 134;
            this.labelControl3.Text = "Số người nghỉ phép (P)";
            // 
            // txtEmpP
            // 
            this.txtEmpP.Location = new System.Drawing.Point(736, 42);
            this.txtEmpP.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpP.Name = "txtEmpP";
            this.txtEmpP.Properties.DisplayFormat.FormatString = "#0";
            this.txtEmpP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpP.Properties.EditFormat.FormatString = "#0";
            this.txtEmpP.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpP.Size = new System.Drawing.Size(190, 23);
            this.txtEmpP.TabIndex = 133;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(122, 21);
            this.labelControl1.TabIndex = 126;
            this.labelControl1.Text = "Số người làm HC";
            // 
            // txtEmpHC
            // 
            this.txtEmpHC.Location = new System.Drawing.Point(242, 11);
            this.txtEmpHC.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpHC.Name = "txtEmpHC";
            this.txtEmpHC.Properties.DisplayFormat.FormatString = "#0";
            this.txtEmpHC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpHC.Properties.EditFormat.FormatString = "#0";
            this.txtEmpHC.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpHC.Properties.UseMaskAsDisplayFormat = true;
            this.txtEmpHC.Size = new System.Drawing.Size(190, 23);
            this.txtEmpHC.TabIndex = 125;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(13, 44);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(122, 21);
            this.labelControl4.TabIndex = 128;
            this.labelControl4.Text = "Số người về sớm";
            // 
            // txtEmpSoon
            // 
            this.txtEmpSoon.Location = new System.Drawing.Point(242, 42);
            this.txtEmpSoon.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpSoon.Name = "txtEmpSoon";
            this.txtEmpSoon.Properties.DisplayFormat.FormatString = "#0";
            this.txtEmpSoon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSoon.Properties.EditFormat.FormatString = "#0";
            this.txtEmpSoon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSoon.Size = new System.Drawing.Size(190, 23);
            this.txtEmpSoon.TabIndex = 127;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(13, 77);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(124, 21);
            this.labelControl6.TabIndex = 130;
            this.labelControl6.Text = "Số người tăng ca";
            // 
            // txtEmpTC
            // 
            this.txtEmpTC.Location = new System.Drawing.Point(242, 75);
            this.txtEmpTC.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpTC.Name = "txtEmpTC";
            this.txtEmpTC.Properties.DisplayFormat.FormatString = "#0";
            this.txtEmpTC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpTC.Properties.EditFormat.FormatString = "#0";
            this.txtEmpTC.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpTC.Size = new System.Drawing.Size(190, 23);
            this.txtEmpTC.TabIndex = 129;
            // 
            // frmAttendanceSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 668);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmAttendanceSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAttendanceSummary";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            this.splitContainerControl1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).EndInit();
            this.splitContainerControl2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).EndInit();
            this.splitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceSummaryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverallSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOverallSumView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpHC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSoon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpTC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl gridAttendanceSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAttendanceSummaryView;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
        private DevExpress.XtraGrid.Columns.GridColumn TimekeepID;
        private DevExpress.XtraGrid.Columns.GridColumn TimekeepName;
        private DevExpress.XtraGrid.Columns.GridColumn TimekeepQuantity;
        private DevExpress.XtraGrid.GridControl gridOverallSum;
        private DevExpress.XtraGrid.Views.Grid.GridView gridOverallSumView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEmpV;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtEmpP;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEmpHC;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtEmpSoon;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtEmpTC;
    }
}