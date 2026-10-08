namespace ASPProject.SOPStage
{
    partial class frmWOSOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWOSOP));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.FuncTab = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridWOSOP = new DevExpress.XtraGrid.GridControl();
            this.gridWOSOPView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSOPStage = new DevExpress.XtraGrid.GridControl();
            this.gridSOPStageView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CycleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsageBom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ManPower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btImportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.Summary = new DevExpress.XtraTab.XtraTabPage();
            this.gridSOP = new DevExpress.XtraGrid.GridControl();
            this.gridSOPView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsageBom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManPower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.SkillID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSkillID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.FuncTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWOSOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWOSOPView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOPStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOPStageView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.Summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOPView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.FuncTab;
            this.xtraTabControl1.Size = new System.Drawing.Size(1273, 692);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.FuncTab,
            this.Summary});
            // 
            // FuncTab
            // 
            this.FuncTab.Controls.Add(this.splitContainerControl1);
            this.FuncTab.Controls.Add(this.panelControl1);
            this.FuncTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FuncTab.Name = "FuncTab";
            this.FuncTab.Size = new System.Drawing.Size(1267, 660);
            this.FuncTab.Text = "Chức năng";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gridWOSOP);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridSOPStage);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1267, 603);
            this.splitContainerControl1.SplitterPosition = 263;
            this.splitContainerControl1.TabIndex = 5;
            // 
            // gridWOSOP
            // 
            this.gridWOSOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWOSOP.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridWOSOP.Location = new System.Drawing.Point(0, 0);
            this.gridWOSOP.MainView = this.gridWOSOPView;
            this.gridWOSOP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridWOSOP.Name = "gridWOSOP";
            this.gridWOSOP.Size = new System.Drawing.Size(1267, 263);
            this.gridWOSOP.TabIndex = 5;
            this.gridWOSOP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridWOSOPView});
            // 
            // gridWOSOPView
            // 
            this.gridWOSOPView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductID});
            this.gridWOSOPView.GridControl = this.gridWOSOP;
            this.gridWOSOPView.Name = "gridWOSOPView";
            this.gridWOSOPView.OptionsBehavior.Editable = false;
            this.gridWOSOPView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridWOSOPView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridWOSOPView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridWOSOPView.OptionsView.ColumnAutoWidth = false;
            this.gridWOSOPView.OptionsView.ShowAutoFilterRow = true;
            this.gridWOSOPView.OptionsView.ShowGroupPanel = false;
            // 
            // ProductID
            // 
            this.ProductID.Caption = "Mã sản phẩm";
            this.ProductID.FieldName = "ProductID";
            this.ProductID.MinWidth = 24;
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = true;
            this.ProductID.VisibleIndex = 0;
            this.ProductID.Width = 150;
            // 
            // gridSOPStage
            // 
            this.gridSOPStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSOPStage.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridSOPStage.Location = new System.Drawing.Point(0, 0);
            this.gridSOPStage.MainView = this.gridSOPStageView;
            this.gridSOPStage.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridSOPStage.Name = "gridSOPStage";
            this.gridSOPStage.Size = new System.Drawing.Size(1267, 333);
            this.gridSOPStage.TabIndex = 5;
            this.gridSOPStage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSOPStageView});
            // 
            // gridSOPStageView
            // 
            this.gridSOPStageView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.StageID,
            this.StageName,
            this.MaterialID,
            this.MachineID,
            this.CycleTime,
            this.UsageBom,
            this.ManPower,
            this.SkillID});
            this.gridSOPStageView.GridControl = this.gridSOPStage;
            this.gridSOPStageView.Name = "gridSOPStageView";
            this.gridSOPStageView.OptionsBehavior.Editable = false;
            this.gridSOPStageView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridSOPStageView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridSOPStageView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridSOPStageView.OptionsView.ColumnAutoWidth = false;
            this.gridSOPStageView.OptionsView.ShowAutoFilterRow = true;
            this.gridSOPStageView.OptionsView.ShowGroupPanel = false;
            // 
            // StageID
            // 
            this.StageID.Caption = "Mã công đoạn";
            this.StageID.FieldName = "StageID";
            this.StageID.MinWidth = 24;
            this.StageID.Name = "StageID";
            this.StageID.Visible = true;
            this.StageID.VisibleIndex = 0;
            this.StageID.Width = 94;
            // 
            // StageName
            // 
            this.StageName.Caption = "Tên công đoạn";
            this.StageName.FieldName = "StageName";
            this.StageName.MinWidth = 24;
            this.StageName.Name = "StageName";
            this.StageName.Visible = true;
            this.StageName.VisibleIndex = 1;
            this.StageName.Width = 350;
            // 
            // MaterialID
            // 
            this.MaterialID.Caption = "Mã NVL";
            this.MaterialID.FieldName = "MaterialID";
            this.MaterialID.MinWidth = 24;
            this.MaterialID.Name = "MaterialID";
            this.MaterialID.Visible = true;
            this.MaterialID.VisibleIndex = 2;
            this.MaterialID.Width = 94;
            // 
            // MachineID
            // 
            this.MachineID.Caption = "Mã máy";
            this.MachineID.FieldName = "MachineID";
            this.MachineID.MinWidth = 24;
            this.MachineID.Name = "MachineID";
            this.MachineID.Visible = true;
            this.MachineID.VisibleIndex = 3;
            this.MachineID.Width = 94;
            // 
            // CycleTime
            // 
            this.CycleTime.Caption = "Cycle Time";
            this.CycleTime.FieldName = "CycleTime";
            this.CycleTime.MinWidth = 24;
            this.CycleTime.Name = "CycleTime";
            this.CycleTime.Visible = true;
            this.CycleTime.VisibleIndex = 4;
            this.CycleTime.Width = 94;
            // 
            // UsageBom
            // 
            this.UsageBom.Caption = "Usage BOM";
            this.UsageBom.FieldName = "UsageBom";
            this.UsageBom.MinWidth = 24;
            this.UsageBom.Name = "UsageBom";
            this.UsageBom.Visible = true;
            this.UsageBom.VisibleIndex = 5;
            this.UsageBom.Width = 94;
            // 
            // ManPower
            // 
            this.ManPower.Caption = "Số người";
            this.ManPower.FieldName = "ManPower";
            this.ManPower.MinWidth = 24;
            this.ManPower.Name = "ManPower";
            this.ManPower.Visible = true;
            this.ManPower.VisibleIndex = 6;
            this.ManPower.Width = 94;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btDelete);
            this.panelControl1.Controls.Add(this.btImportExcel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 603);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1267, 57);
            this.panelControl1.TabIndex = 4;
            // 
            // btDelete
            // 
            this.btDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btDelete.Location = new System.Drawing.Point(211, 11);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(161, 34);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "Xoá";
            // 
            // btImportExcel
            // 
            this.btImportExcel.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btImportExcel.Location = new System.Drawing.Point(18, 11);
            this.btImportExcel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btImportExcel.Name = "btImportExcel";
            this.btImportExcel.Size = new System.Drawing.Size(161, 34);
            this.btImportExcel.TabIndex = 7;
            this.btImportExcel.Text = "Import Dữ liệu";
            // 
            // Summary
            // 
            this.Summary.Controls.Add(this.gridSOP);
            this.Summary.Controls.Add(this.panelControl2);
            this.Summary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(1267, 660);
            this.Summary.Text = "Tổng hợp";
            // 
            // gridSOP
            // 
            this.gridSOP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSOP.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gridSOP.Location = new System.Drawing.Point(0, 0);
            this.gridSOP.MainView = this.gridSOPView;
            this.gridSOP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gridSOP.Name = "gridSOP";
            this.gridSOP.Size = new System.Drawing.Size(1267, 606);
            this.gridSOP.TabIndex = 7;
            this.gridSOP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSOPView});
            // 
            // gridSOPView
            // 
            this.gridSOPView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductID,
            this.colStageID,
            this.colStageName,
            this.colMaterial,
            this.colCycleTime,
            this.colUsageBom,
            this.colManPower,
            this.colSkillID});
            this.gridSOPView.DetailHeight = 682;
            this.gridSOPView.GridControl = this.gridSOP;
            this.gridSOPView.Name = "gridSOPView";
            this.gridSOPView.OptionsBehavior.Editable = false;
            this.gridSOPView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridSOPView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridSOPView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridSOPView.OptionsView.ShowAutoFilterRow = true;
            this.gridSOPView.OptionsView.ShowGroupPanel = false;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã sản phẩm";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.MinWidth = 23;
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 0;
            this.colProductID.Width = 87;
            // 
            // colStageID
            // 
            this.colStageID.Caption = "Mã công đoạn";
            this.colStageID.FieldName = "StageID";
            this.colStageID.MinWidth = 23;
            this.colStageID.Name = "colStageID";
            this.colStageID.Visible = true;
            this.colStageID.VisibleIndex = 1;
            this.colStageID.Width = 87;
            // 
            // colStageName
            // 
            this.colStageName.Caption = "Tên công đoạn";
            this.colStageName.FieldName = "StageName";
            this.colStageName.MinWidth = 23;
            this.colStageName.Name = "colStageName";
            this.colStageName.Visible = true;
            this.colStageName.VisibleIndex = 2;
            this.colStageName.Width = 87;
            // 
            // colMaterial
            // 
            this.colMaterial.Caption = "Mã nguyên liệu";
            this.colMaterial.FieldName = "MaterialID";
            this.colMaterial.MinWidth = 23;
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.Visible = true;
            this.colMaterial.VisibleIndex = 3;
            this.colMaterial.Width = 87;
            // 
            // colCycleTime
            // 
            this.colCycleTime.Caption = "Cycle Time";
            this.colCycleTime.FieldName = "CycleTime";
            this.colCycleTime.MinWidth = 23;
            this.colCycleTime.Name = "colCycleTime";
            this.colCycleTime.Visible = true;
            this.colCycleTime.VisibleIndex = 4;
            this.colCycleTime.Width = 87;
            // 
            // colUsageBom
            // 
            this.colUsageBom.Caption = "Usage Bom";
            this.colUsageBom.FieldName = "UsageBom";
            this.colUsageBom.MinWidth = 23;
            this.colUsageBom.Name = "colUsageBom";
            this.colUsageBom.Visible = true;
            this.colUsageBom.VisibleIndex = 5;
            this.colUsageBom.Width = 87;
            // 
            // colManPower
            // 
            this.colManPower.Caption = "Man Power";
            this.colManPower.FieldName = "ManPower";
            this.colManPower.MinWidth = 23;
            this.colManPower.Name = "colManPower";
            this.colManPower.Visible = true;
            this.colManPower.VisibleIndex = 6;
            this.colManPower.Width = 87;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btExport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 606);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1267, 54);
            this.panelControl2.TabIndex = 1;
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(1101, 7);
            this.btExport.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(152, 38);
            this.btExport.TabIndex = 16;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // SkillID
            // 
            this.SkillID.Caption = "Mã kỹ năng";
            this.SkillID.FieldName = "SkillID";
            this.SkillID.MinWidth = 25;
            this.SkillID.Name = "SkillID";
            this.SkillID.Visible = true;
            this.SkillID.VisibleIndex = 7;
            this.SkillID.Width = 87;
            // 
            // colSkillID
            // 
            this.colSkillID.Caption = "Mã kỹ năng";
            this.colSkillID.FieldName = "SkillID";
            this.colSkillID.MinWidth = 25;
            this.colSkillID.Name = "colSkillID";
            this.colSkillID.Visible = true;
            this.colSkillID.VisibleIndex = 7;
            this.colSkillID.Width = 87;
            // 
            // frmWOSOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 692);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmWOSOP";
            this.Text = "Khai báo SOP lệnh sản xuất";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.FuncTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridWOSOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWOSOPView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOPStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOPStageView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.Summary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSOPView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage FuncTab;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridWOSOP;
        private DevExpress.XtraGrid.Views.Grid.GridView gridWOSOPView;
        private DevExpress.XtraGrid.Columns.GridColumn ProductID;
        private DevExpress.XtraGrid.GridControl gridSOPStage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSOPStageView;
        private DevExpress.XtraGrid.Columns.GridColumn StageID;
        private DevExpress.XtraGrid.Columns.GridColumn StageName;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn MachineID;
        private DevExpress.XtraGrid.Columns.GridColumn CycleTime;
        private DevExpress.XtraGrid.Columns.GridColumn UsageBom;
        private DevExpress.XtraGrid.Columns.GridColumn ManPower;
        private DevExpress.XtraTab.XtraTabPage Summary;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraGrid.GridControl gridSOP;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSOPView;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageID;
        private DevExpress.XtraGrid.Columns.GridColumn colStageName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUsageBom;
        private DevExpress.XtraGrid.Columns.GridColumn colManPower;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btDelete;
        private DevExpress.XtraEditors.SimpleButton btImportExcel;
        private DevExpress.XtraGrid.Columns.GridColumn SkillID;
        private DevExpress.XtraGrid.Columns.GridColumn colSkillID;
    }
}