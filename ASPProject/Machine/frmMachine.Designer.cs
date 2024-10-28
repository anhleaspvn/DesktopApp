namespace ASPProject.Machine
{
    partial class frmMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachine));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btExport = new DevExpress.XtraEditors.SimpleButton();
            this.btImportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.gridMachine = new DevExpress.XtraGrid.GridControl();
            this.gridMachineView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaintenanceMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btDelete);
            this.panelControl1.Controls.Add(this.btExport);
            this.panelControl1.Controls.Add(this.btImportExcel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 275);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(638, 44);
            this.panelControl1.TabIndex = 0;
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btExport.ImageOptions.Image")));
            this.btExport.Location = new System.Drawing.Point(496, 6);
            this.btExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(130, 31);
            this.btExport.TabIndex = 16;
            this.btExport.Text = "Xuất dữ liệu";
            // 
            // btImportExcel
            // 
            this.btImportExcel.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btImportExcel.Location = new System.Drawing.Point(12, 6);
            this.btImportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btImportExcel.Name = "btImportExcel";
            this.btImportExcel.Size = new System.Drawing.Size(130, 31);
            this.btImportExcel.TabIndex = 8;
            this.btImportExcel.Text = "Import Dữ liệu";
            // 
            // gridMachine
            // 
            this.gridMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMachine.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.gridMachine.Location = new System.Drawing.Point(0, 0);
            this.gridMachine.MainView = this.gridMachineView;
            this.gridMachine.Margin = new System.Windows.Forms.Padding(5);
            this.gridMachine.Name = "gridMachine";
            this.gridMachine.Size = new System.Drawing.Size(638, 275);
            this.gridMachine.TabIndex = 6;
            this.gridMachine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMachineView});
            // 
            // gridMachineView
            // 
            this.gridMachineView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineID,
            this.colMachineName,
            this.colMaintenanceMonth,
            this.colMachineGroup});
            this.gridMachineView.DetailHeight = 554;
            this.gridMachineView.GridControl = this.gridMachine;
            this.gridMachineView.Name = "gridMachineView";
            this.gridMachineView.OptionsBehavior.Editable = false;
            this.gridMachineView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridMachineView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridMachineView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridMachineView.OptionsView.ShowAutoFilterRow = true;
            this.gridMachineView.OptionsView.ShowGroupPanel = false;
            // 
            // colMachineID
            // 
            this.colMachineID.Caption = "Mã máy";
            this.colMachineID.FieldName = "MachineID";
            this.colMachineID.MinWidth = 27;
            this.colMachineID.Name = "colMachineID";
            this.colMachineID.Visible = true;
            this.colMachineID.VisibleIndex = 0;
            this.colMachineID.Width = 100;
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "Tên máy";
            this.colMachineName.FieldName = "MachineName";
            this.colMachineName.MinWidth = 27;
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 1;
            this.colMachineName.Width = 100;
            // 
            // colMaintenanceMonth
            // 
            this.colMaintenanceMonth.Caption = "Số tháng bảo hành";
            this.colMaintenanceMonth.FieldName = "MaintenanceMonth";
            this.colMaintenanceMonth.MinWidth = 27;
            this.colMaintenanceMonth.Name = "colMaintenanceMonth";
            this.colMaintenanceMonth.Visible = true;
            this.colMaintenanceMonth.VisibleIndex = 2;
            this.colMaintenanceMonth.Width = 100;
            // 
            // colMachineGroup
            // 
            this.colMachineGroup.Caption = "Nhóm máy";
            this.colMachineGroup.FieldName = "MachineGroup";
            this.colMachineGroup.MinWidth = 27;
            this.colMachineGroup.Name = "colMachineGroup";
            this.colMachineGroup.Visible = true;
            this.colMachineGroup.VisibleIndex = 3;
            this.colMachineGroup.Width = 100;
            // 
            // btDelete
            // 
            this.btDelete.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btDelete.Location = new System.Drawing.Point(153, 7);
            this.btDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(130, 31);
            this.btDelete.TabIndex = 17;
            this.btDelete.Text = "Xoá";
            // 
            // frmMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 319);
            this.Controls.Add(this.gridMachine);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMachine";
            this.Text = "frmMachine";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMachineView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridMachine;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMachineView;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineID;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaintenanceMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineGroup;
        private DevExpress.XtraEditors.SimpleButton btImportExcel;
        private DevExpress.XtraEditors.SimpleButton btExport;
        private DevExpress.XtraEditors.SimpleButton btDelete;
    }
}