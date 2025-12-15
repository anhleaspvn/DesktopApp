namespace ASPProject.LineProdStatistic
{
    partial class frmPlanning
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.rdBt2 = new System.Windows.Forms.RadioButton();
            this.rdBt1 = new System.Windows.Forms.RadioButton();
            this.lkeYear = new DevExpress.XtraEditors.LookUpEdit();
            this.lkeMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridPlanning = new DevExpress.XtraGrid.GridControl();
            this.gridPlanningView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WODocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WODocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WOQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RemainQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblSumWO = new DevExpress.XtraEditors.LabelControl();
            this.lblSumWOFull = new DevExpress.XtraEditors.LabelControl();
            this.lblSumWOLack = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanningView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.rdBt2);
            this.panelControl1.Controls.Add(this.rdBt1);
            this.panelControl1.Controls.Add(this.lkeYear);
            this.panelControl1.Controls.Add(this.lkeMonth);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1166, 75);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(932, 10);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(149, 48);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Tìm kiếm";
            // 
            // rdBt2
            // 
            this.rdBt2.AutoSize = true;
            this.rdBt2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBt2.Location = new System.Drawing.Point(763, 19);
            this.rdBt2.Name = "rdBt2";
            this.rdBt2.Size = new System.Drawing.Size(97, 28);
            this.rdBt2.TabIndex = 5;
            this.rdBt2.TabStop = true;
            this.rdBt2.Text = "Sample";
            this.rdBt2.UseVisualStyleBackColor = true;
            // 
            // rdBt1
            // 
            this.rdBt1.AutoSize = true;
            this.rdBt1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBt1.Location = new System.Drawing.Point(618, 19);
            this.rdBt1.Name = "rdBt1";
            this.rdBt1.Size = new System.Drawing.Size(118, 28);
            this.rdBt1.TabIndex = 4;
            this.rdBt1.TabStop = true;
            this.rdBt1.Text = "Hàng loạt";
            this.rdBt1.UseVisualStyleBackColor = true;
            // 
            // lkeYear
            // 
            this.lkeYear.EditValue = "";
            this.lkeYear.Location = new System.Drawing.Point(400, 24);
            this.lkeYear.Margin = new System.Windows.Forms.Padding(6);
            this.lkeYear.Name = "lkeYear";
            this.lkeYear.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeYear.Properties.NullText = "";
            this.lkeYear.Size = new System.Drawing.Size(158, 23);
            this.lkeYear.TabIndex = 3;
            // 
            // lkeMonth
            // 
            this.lkeMonth.EditValue = "";
            this.lkeMonth.Location = new System.Drawing.Point(119, 24);
            this.lkeMonth.Margin = new System.Windows.Forms.Padding(5);
            this.lkeMonth.Name = "lkeMonth";
            this.lkeMonth.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeMonth.Properties.NullText = "";
            this.lkeMonth.Size = new System.Drawing.Size(158, 23);
            this.lkeMonth.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(323, 23);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 24);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Năm :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(28, 23);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tháng :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblSumWOLack);
            this.panelControl2.Controls.Add(this.lblSumWOFull);
            this.panelControl2.Controls.Add(this.lblSumWO);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 708);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1166, 50);
            this.panelControl2.TabIndex = 1;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridPlanning);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 75);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1166, 633);
            this.panelControl3.TabIndex = 2;
            // 
            // gridPlanning
            // 
            this.gridPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlanning.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridPlanning.Location = new System.Drawing.Point(2, 2);
            this.gridPlanning.MainView = this.gridPlanningView;
            this.gridPlanning.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridPlanning.Name = "gridPlanning";
            this.gridPlanning.Size = new System.Drawing.Size(1162, 629);
            this.gridPlanning.TabIndex = 6;
            this.gridPlanning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPlanningView});
            // 
            // gridPlanningView
            // 
            this.gridPlanningView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SODocNo,
            this.WODocNo,
            this.WODocDate,
            this.ProductID,
            this.MaterialID,
            this.WOQuantity,
            this.RemainQuantity});
            this.gridPlanningView.GridControl = this.gridPlanning;
            this.gridPlanningView.Name = "gridPlanningView";
            this.gridPlanningView.OptionsBehavior.Editable = false;
            this.gridPlanningView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridPlanningView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridPlanningView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridPlanningView.OptionsView.ShowAutoFilterRow = true;
            this.gridPlanningView.OptionsView.ShowGroupPanel = false;
            // 
            // SODocNo
            // 
            this.SODocNo.Caption = "Số SO";
            this.SODocNo.FieldName = "PODocNo";
            this.SODocNo.MinWidth = 25;
            this.SODocNo.Name = "SODocNo";
            this.SODocNo.Visible = true;
            this.SODocNo.VisibleIndex = 0;
            this.SODocNo.Width = 120;
            // 
            // WODocNo
            // 
            this.WODocNo.Caption = "Lệnh sản xuất";
            this.WODocNo.FieldName = "WODocNo";
            this.WODocNo.MinWidth = 25;
            this.WODocNo.Name = "WODocNo";
            this.WODocNo.Visible = true;
            this.WODocNo.VisibleIndex = 1;
            this.WODocNo.Width = 120;
            // 
            // WODocDate
            // 
            this.WODocDate.Caption = "Ngày ban hành";
            this.WODocDate.FieldName = "WODocDate";
            this.WODocDate.MinWidth = 25;
            this.WODocDate.Name = "WODocDate";
            this.WODocDate.Visible = true;
            this.WODocDate.VisibleIndex = 2;
            this.WODocDate.Width = 120;
            // 
            // ProductID
            // 
            this.ProductID.Caption = "Mã sản phẩm";
            this.ProductID.FieldName = "ProductID";
            this.ProductID.MinWidth = 25;
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = true;
            this.ProductID.VisibleIndex = 3;
            this.ProductID.Width = 120;
            // 
            // MaterialID
            // 
            this.MaterialID.Caption = "Mã nguyên vật liệu";
            this.MaterialID.FieldName = "MaterialID";
            this.MaterialID.MinWidth = 25;
            this.MaterialID.Name = "MaterialID";
            this.MaterialID.Visible = true;
            this.MaterialID.VisibleIndex = 4;
            this.MaterialID.Width = 130;
            // 
            // WOQuantity
            // 
            this.WOQuantity.Caption = "Số lượng yêu cầu";
            this.WOQuantity.FieldName = "WOQuantity";
            this.WOQuantity.MinWidth = 25;
            this.WOQuantity.Name = "WOQuantity";
            this.WOQuantity.Visible = true;
            this.WOQuantity.VisibleIndex = 5;
            this.WOQuantity.Width = 130;
            // 
            // RemainQuantity
            // 
            this.RemainQuantity.Caption = "Số lượng tồn kho";
            this.RemainQuantity.FieldName = "RemainQuantity";
            this.RemainQuantity.MinWidth = 25;
            this.RemainQuantity.Name = "RemainQuantity";
            this.RemainQuantity.Visible = true;
            this.RemainQuantity.VisibleIndex = 6;
            this.RemainQuantity.Width = 130;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(28, 12);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(123, 24);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Tổng số LSX :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(350, 12);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(205, 24);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Tổng số LSX đủ Stock :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(764, 12);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(265, 24);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Tổng số LSX không đủ Stock :";
            // 
            // lblSumWO
            // 
            this.lblSumWO.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumWO.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblSumWO.Appearance.Options.UseFont = true;
            this.lblSumWO.Appearance.Options.UseForeColor = true;
            this.lblSumWO.Location = new System.Drawing.Point(166, 12);
            this.lblSumWO.Name = "lblSumWO";
            this.lblSumWO.Size = new System.Drawing.Size(118, 24);
            this.lblSumWO.TabIndex = 4;
            this.lblSumWO.Text = "labelControl6";
            // 
            // lblSumWOFull
            // 
            this.lblSumWOFull.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumWOFull.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblSumWOFull.Appearance.Options.UseFont = true;
            this.lblSumWOFull.Appearance.Options.UseForeColor = true;
            this.lblSumWOFull.Location = new System.Drawing.Point(570, 12);
            this.lblSumWOFull.Name = "lblSumWOFull";
            this.lblSumWOFull.Size = new System.Drawing.Size(118, 24);
            this.lblSumWOFull.TabIndex = 5;
            this.lblSumWOFull.Text = "labelControl6";
            // 
            // lblSumWOLack
            // 
            this.lblSumWOLack.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumWOLack.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblSumWOLack.Appearance.Options.UseFont = true;
            this.lblSumWOLack.Appearance.Options.UseForeColor = true;
            this.lblSumWOLack.Location = new System.Drawing.Point(1042, 12);
            this.lblSumWOLack.Name = "lblSumWOLack";
            this.lblSumWOLack.Size = new System.Drawing.Size(118, 24);
            this.lblSumWOLack.TabIndex = 6;
            this.lblSumWOLack.Text = "labelControl6";
            // 
            // frmPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 758);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlanning";
            this.Text = "FrmPlanning";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanningView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lkeYear;
        private DevExpress.XtraEditors.LookUpEdit lkeMonth;
        private System.Windows.Forms.RadioButton rdBt2;
        private System.Windows.Forms.RadioButton rdBt1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridPlanning;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPlanningView;
        private DevExpress.XtraGrid.Columns.GridColumn SODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn WODocNo;
        private DevExpress.XtraGrid.Columns.GridColumn WODocDate;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn WOQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn RemainQuantity;
        private DevExpress.XtraEditors.LabelControl lblSumWOFull;
        private DevExpress.XtraEditors.LabelControl lblSumWO;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblSumWOLack;
    }
}