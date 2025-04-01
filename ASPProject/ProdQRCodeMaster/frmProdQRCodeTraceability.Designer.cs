namespace ASPProject.ProdQRCodeMaster
{
    partial class frmProdQRCodeTraceability
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabWO = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lkeWO = new DevExpress.XtraEditors.LookUpEdit();
            this.lbLSX = new DevExpress.XtraEditors.LabelControl();
            this.lblCusPart = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblProduct = new DevExpress.XtraEditors.LabelControl();
            this.lblProductID = new DevExpress.XtraEditors.LabelControl();
            this.tabTraceability = new DevExpress.XtraTab.XtraTabControl();
            this.tabBOM = new DevExpress.XtraTab.XtraTabPage();
            this.gridBOMInfo = new DevExpress.XtraGrid.GridControl();
            this.gridBOMInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabWarehouse = new DevExpress.XtraTab.XtraTabPage();
            this.gridWHInfo = new DevExpress.XtraGrid.GridControl();
            this.gridWHInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WHAllocated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LineUsedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WORemainQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabProduction = new DevExpress.XtraTab.XtraTabPage();
            this.tabQC = new DevExpress.XtraTab.XtraTabPage();
            this.tabProduct = new DevExpress.XtraTab.XtraTabPage();
            this.gridBOM = new DevExpress.XtraGrid.GridControl();
            this.gridBOMView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaterialType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QuotaQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Applied = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LaborCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsageCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsSemiProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.lkeProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Material = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabWO.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.lkeWO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabTraceability)).BeginInit();
            this.tabTraceability.SuspendLayout();
            this.tabBOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOMInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOMInfoView)).BeginInit();
            this.tabWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWHInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWHInfoView)).BeginInit();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOMView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeProduct.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabWO;
            this.xtraTabControl1.Size = new System.Drawing.Size(1239, 721);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabWO,
            this.tabProduct});
            // 
            // tabWO
            // 
            this.tabWO.Controls.Add(this.splitContainerControl1);
            this.tabWO.Name = "tabWO";
            this.tabWO.Size = new System.Drawing.Size(1233, 689);
            this.tabWO.Text = "Lệnh sản xuất";
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
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.tabTraceability);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1233, 689);
            this.splitContainerControl1.SplitterPosition = 158;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitContainerControl2.Name = "splitContainerControl2";
            // 
            // splitContainerControl2.Panel1
            // 
            this.splitContainerControl2.Panel1.Controls.Add(this.lkeWO);
            this.splitContainerControl2.Panel1.Controls.Add(this.lbLSX);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            // 
            // splitContainerControl2.Panel2
            // 
            this.splitContainerControl2.Panel2.Controls.Add(this.lblCusPart);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblProduct);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblProductID);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1233, 158);
            this.splitContainerControl2.SplitterPosition = 367;
            this.splitContainerControl2.TabIndex = 0;
            // 
            // lkeWO
            // 
            this.lkeWO.EditValue = "";
            this.lkeWO.Location = new System.Drawing.Point(21, 75);
            this.lkeWO.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeWO.MaximumSize = new System.Drawing.Size(500, 250);
            this.lkeWO.MinimumSize = new System.Drawing.Size(199, 30);
            this.lkeWO.Name = "lkeWO";
            this.lkeWO.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeWO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeWO.Properties.NullText = "";
            this.lkeWO.Size = new System.Drawing.Size(323, 23);
            this.lkeWO.TabIndex = 77;
            // 
            // lbLSX
            // 
            this.lbLSX.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLSX.Appearance.Options.UseFont = true;
            this.lbLSX.Location = new System.Drawing.Point(21, 27);
            this.lbLSX.Margin = new System.Windows.Forms.Padding(4);
            this.lbLSX.Name = "lbLSX";
            this.lbLSX.Size = new System.Drawing.Size(195, 33);
            this.lbLSX.TabIndex = 78;
            this.lbLSX.Text = "LỆNH SẢN XUẤT";
            // 
            // lblCusPart
            // 
            this.lblCusPart.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusPart.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCusPart.Appearance.Options.UseFont = true;
            this.lblCusPart.Appearance.Options.UseForeColor = true;
            this.lblCusPart.Location = new System.Drawing.Point(223, 82);
            this.lblCusPart.Margin = new System.Windows.Forms.Padding(4);
            this.lblCusPart.Name = "lblCusPart";
            this.lblCusPart.Size = new System.Drawing.Size(194, 31);
            this.lblCusPart.TabIndex = 81;
            this.lblCusPart.Text = "Cus part number";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(79, 89);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.labelControl1.MaximumSize = new System.Drawing.Size(500, 250);
            this.labelControl1.MinimumSize = new System.Drawing.Size(96, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 20);
            this.labelControl1.TabIndex = 80;
            this.labelControl1.Text = "Cus part number";
            // 
            // lblProduct
            // 
            this.lblProduct.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblProduct.Appearance.Options.UseFont = true;
            this.lblProduct.Appearance.Options.UseForeColor = true;
            this.lblProduct.Location = new System.Drawing.Point(223, 37);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(4);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(194, 31);
            this.lblProduct.TabIndex = 79;
            this.lblProduct.Text = "FGs part number";
            // 
            // lblProductID
            // 
            this.lblProductID.Location = new System.Drawing.Point(79, 42);
            this.lblProductID.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblProductID.MaximumSize = new System.Drawing.Size(500, 250);
            this.lblProductID.MinimumSize = new System.Drawing.Size(96, 20);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(96, 20);
            this.lblProductID.TabIndex = 0;
            this.lblProductID.Text = "FGs part number";
            // 
            // tabTraceability
            // 
            this.tabTraceability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTraceability.Location = new System.Drawing.Point(0, 0);
            this.tabTraceability.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabTraceability.Name = "tabTraceability";
            this.tabTraceability.SelectedTabPage = this.tabBOM;
            this.tabTraceability.Size = new System.Drawing.Size(1233, 524);
            this.tabTraceability.TabIndex = 0;
            this.tabTraceability.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBOM,
            this.tabWarehouse,
            this.tabProduction,
            this.tabQC});
            // 
            // tabBOM
            // 
            this.tabBOM.Controls.Add(this.gridBOMInfo);
            this.tabBOM.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabBOM.Name = "tabBOM";
            this.tabBOM.Size = new System.Drawing.Size(1227, 492);
            this.tabBOM.Text = "BOM";
            // 
            // gridBOMInfo
            // 
            this.gridBOMInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBOMInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gridBOMInfo.Location = new System.Drawing.Point(0, 0);
            this.gridBOMInfo.MainView = this.gridBOMInfoView;
            this.gridBOMInfo.Margin = new System.Windows.Forms.Padding(6);
            this.gridBOMInfo.Name = "gridBOMInfo";
            this.gridBOMInfo.Size = new System.Drawing.Size(1227, 492);
            this.gridBOMInfo.TabIndex = 7;
            this.gridBOMInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridBOMInfoView});
            // 
            // gridBOMInfoView
            // 
            this.gridBOMInfoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaterialID,
            this.colMaterialName,
            this.colMaterialQuantity});
            this.gridBOMInfoView.DetailHeight = 682;
            this.gridBOMInfoView.GridControl = this.gridBOMInfo;
            this.gridBOMInfoView.Name = "gridBOMInfoView";
            this.gridBOMInfoView.OptionsBehavior.Editable = false;
            this.gridBOMInfoView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridBOMInfoView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridBOMInfoView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridBOMInfoView.OptionsView.ShowAutoFilterRow = true;
            this.gridBOMInfoView.OptionsView.ShowGroupPanel = false;
            // 
            // colMaterialID
            // 
            this.colMaterialID.Caption = "Material ID";
            this.colMaterialID.FieldName = "MaterialID";
            this.colMaterialID.Name = "colMaterialID";
            this.colMaterialID.Visible = true;
            this.colMaterialID.VisibleIndex = 0;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "Material Name";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 1;
            // 
            // colMaterialQuantity
            // 
            this.colMaterialQuantity.Caption = "Material Quantity";
            this.colMaterialQuantity.FieldName = "MaterialQuantity";
            this.colMaterialQuantity.Name = "colMaterialQuantity";
            this.colMaterialQuantity.Visible = true;
            this.colMaterialQuantity.VisibleIndex = 2;
            // 
            // tabWarehouse
            // 
            this.tabWarehouse.Controls.Add(this.gridWHInfo);
            this.tabWarehouse.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabWarehouse.Name = "tabWarehouse";
            this.tabWarehouse.Size = new System.Drawing.Size(1227, 492);
            this.tabWarehouse.Text = "Warehouse";
            // 
            // gridWHInfo
            // 
            this.gridWHInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWHInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gridWHInfo.Location = new System.Drawing.Point(0, 0);
            this.gridWHInfo.MainView = this.gridWHInfoView;
            this.gridWHInfo.Margin = new System.Windows.Forms.Padding(6);
            this.gridWHInfo.Name = "gridWHInfo";
            this.gridWHInfo.Size = new System.Drawing.Size(1227, 492);
            this.gridWHInfo.TabIndex = 8;
            this.gridWHInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridWHInfoView});
            // 
            // gridWHInfoView
            // 
            this.gridWHInfoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaterialID,
            this.WHAllocated,
            this.LineUsedQty,
            this.WORemainQty});
            this.gridWHInfoView.DetailHeight = 682;
            this.gridWHInfoView.GridControl = this.gridWHInfo;
            this.gridWHInfoView.Name = "gridWHInfoView";
            this.gridWHInfoView.OptionsBehavior.Editable = false;
            this.gridWHInfoView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridWHInfoView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridWHInfoView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridWHInfoView.OptionsView.ShowAutoFilterRow = true;
            this.gridWHInfoView.OptionsView.ShowGroupPanel = false;
            // 
            // MaterialID
            // 
            this.MaterialID.Caption = "Material ID";
            this.MaterialID.FieldName = "MaterialID";
            this.MaterialID.MinWidth = 23;
            this.MaterialID.Name = "MaterialID";
            this.MaterialID.Visible = true;
            this.MaterialID.VisibleIndex = 0;
            this.MaterialID.Width = 87;
            // 
            // WHAllocated
            // 
            this.WHAllocated.Caption = "Số lượng kho cấp phát";
            this.WHAllocated.FieldName = "WHAllocatedQty";
            this.WHAllocated.MinWidth = 23;
            this.WHAllocated.Name = "WHAllocated";
            this.WHAllocated.Visible = true;
            this.WHAllocated.VisibleIndex = 1;
            this.WHAllocated.Width = 87;
            // 
            // LineUsedQty
            // 
            this.LineUsedQty.Caption = "Số lượng Line sử dụng";
            this.LineUsedQty.FieldName = "LineUsedQty";
            this.LineUsedQty.MinWidth = 23;
            this.LineUsedQty.Name = "LineUsedQty";
            this.LineUsedQty.Visible = true;
            this.LineUsedQty.VisibleIndex = 2;
            this.LineUsedQty.Width = 87;
            // 
            // WORemainQty
            // 
            this.WORemainQty.Caption = "Số lượng còn lại";
            this.WORemainQty.FieldName = "WORemainQty";
            this.WORemainQty.MinWidth = 23;
            this.WORemainQty.Name = "WORemainQty";
            this.WORemainQty.Visible = true;
            this.WORemainQty.VisibleIndex = 3;
            this.WORemainQty.Width = 87;
            // 
            // tabProduction
            // 
            this.tabProduction.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabProduction.Name = "tabProduction";
            this.tabProduction.Size = new System.Drawing.Size(1227, 492);
            this.tabProduction.Text = "Production";
            // 
            // tabQC
            // 
            this.tabQC.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabQC.Name = "tabQC";
            this.tabQC.Size = new System.Drawing.Size(1227, 492);
            this.tabQC.Text = "QC";
            // 
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.gridBOM);
            this.tabProduct.Controls.Add(this.panel1);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Size = new System.Drawing.Size(1233, 689);
            this.tabProduct.Text = "Sản phẩm";
            // 
            // gridBOM
            // 
            this.gridBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBOM.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gridBOM.Location = new System.Drawing.Point(0, 120);
            this.gridBOM.MainView = this.gridBOMView;
            this.gridBOM.Margin = new System.Windows.Forms.Padding(6);
            this.gridBOM.Name = "gridBOM";
            this.gridBOM.Size = new System.Drawing.Size(1233, 569);
            this.gridBOM.TabIndex = 8;
            this.gridBOM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridBOMView});
            // 
            // gridBOMView
            // 
            this.gridBOMView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MLevel,
            this.colProduct,
            this.Material,
            this.MaterialName,
            this.MaterialType,
            this.QuotaQuantity,
            this.Unit,
            this.Applied,
            this.UnitCost,
            this.LaborCost,
            this.UsageCost,
            this.CT,
            this.IsSemiProd});
            this.gridBOMView.DetailHeight = 682;
            this.gridBOMView.GridControl = this.gridBOM;
            this.gridBOMView.Name = "gridBOMView";
            this.gridBOMView.OptionsBehavior.Editable = false;
            this.gridBOMView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridBOMView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridBOMView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridBOMView.OptionsView.ShowAutoFilterRow = true;
            this.gridBOMView.OptionsView.ShowGroupPanel = false;
            // 
            // MLevel
            // 
            this.MLevel.Caption = "Level";
            this.MLevel.FieldName = "MLevel";
            this.MLevel.MinWidth = 25;
            this.MLevel.Name = "MLevel";
            this.MLevel.Visible = true;
            this.MLevel.VisibleIndex = 0;
            this.MLevel.Width = 94;
            // 
            // colProduct
            // 
            this.colProduct.Caption = "Product";
            this.colProduct.FieldName = "Product";
            this.colProduct.MinWidth = 25;
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 1;
            this.colProduct.Width = 94;
            // 
            // MaterialName
            // 
            this.MaterialName.Caption = "Material Name";
            this.MaterialName.FieldName = "MaterialName";
            this.MaterialName.MinWidth = 25;
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.Visible = true;
            this.MaterialName.VisibleIndex = 3;
            this.MaterialName.Width = 94;
            // 
            // MaterialType
            // 
            this.MaterialType.Caption = "Material Type";
            this.MaterialType.FieldName = "MaterialType";
            this.MaterialType.MinWidth = 25;
            this.MaterialType.Name = "MaterialType";
            this.MaterialType.Visible = true;
            this.MaterialType.VisibleIndex = 4;
            this.MaterialType.Width = 94;
            // 
            // QuotaQuantity
            // 
            this.QuotaQuantity.Caption = "Quota Quantity";
            this.QuotaQuantity.FieldName = "QuotaQuantity";
            this.QuotaQuantity.MinWidth = 25;
            this.QuotaQuantity.Name = "QuotaQuantity";
            this.QuotaQuantity.Visible = true;
            this.QuotaQuantity.VisibleIndex = 5;
            this.QuotaQuantity.Width = 94;
            // 
            // Unit
            // 
            this.Unit.Caption = "Unit";
            this.Unit.FieldName = "Unit";
            this.Unit.MinWidth = 25;
            this.Unit.Name = "Unit";
            this.Unit.Visible = true;
            this.Unit.VisibleIndex = 6;
            this.Unit.Width = 94;
            // 
            // Applied
            // 
            this.Applied.Caption = "Applied";
            this.Applied.FieldName = "Applied";
            this.Applied.MinWidth = 25;
            this.Applied.Name = "Applied";
            this.Applied.Visible = true;
            this.Applied.VisibleIndex = 7;
            this.Applied.Width = 94;
            // 
            // UnitCost
            // 
            this.UnitCost.Caption = "Unit cost";
            this.UnitCost.FieldName = "UnitCost";
            this.UnitCost.MinWidth = 25;
            this.UnitCost.Name = "UnitCost";
            this.UnitCost.Visible = true;
            this.UnitCost.VisibleIndex = 8;
            this.UnitCost.Width = 94;
            // 
            // LaborCost
            // 
            this.LaborCost.Caption = "Labor cost";
            this.LaborCost.FieldName = "LaborCost";
            this.LaborCost.MinWidth = 25;
            this.LaborCost.Name = "LaborCost";
            this.LaborCost.Visible = true;
            this.LaborCost.VisibleIndex = 9;
            this.LaborCost.Width = 94;
            // 
            // UsageCost
            // 
            this.UsageCost.Caption = "Usage cost";
            this.UsageCost.FieldName = "UsageCost";
            this.UsageCost.MinWidth = 25;
            this.UsageCost.Name = "UsageCost";
            this.UsageCost.Visible = true;
            this.UsageCost.VisibleIndex = 10;
            this.UsageCost.Width = 94;
            // 
            // CT
            // 
            this.CT.Caption = "C/T";
            this.CT.FieldName = "CT";
            this.CT.MinWidth = 25;
            this.CT.Name = "CT";
            this.CT.Visible = true;
            this.CT.VisibleIndex = 11;
            this.CT.Width = 94;
            // 
            // IsSemiProd
            // 
            this.IsSemiProd.Caption = "Is Semi Prod";
            this.IsSemiProd.FieldName = "IsSemiProd";
            this.IsSemiProd.MinWidth = 25;
            this.IsSemiProd.Name = "IsSemiProd";
            this.IsSemiProd.Visible = true;
            this.IsSemiProd.VisibleIndex = 12;
            this.IsSemiProd.Width = 94;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btExportExcel);
            this.panel1.Controls.Add(this.lkeProduct);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1233, 120);
            this.panel1.TabIndex = 0;
            // 
            // btExportExcel
            // 
            this.btExportExcel.ImageOptions.Image = global::ASPProject.Properties.Resources.export;
            this.btExportExcel.Location = new System.Drawing.Point(350, 65);
            this.btExportExcel.Name = "btExportExcel";
            this.btExportExcel.Size = new System.Drawing.Size(164, 29);
            this.btExportExcel.TabIndex = 81;
            this.btExportExcel.Text = "Xuất Excel";
            // 
            // lkeProduct
            // 
            this.lkeProduct.EditValue = "";
            this.lkeProduct.Location = new System.Drawing.Point(20, 69);
            this.lkeProduct.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lkeProduct.MaximumSize = new System.Drawing.Size(500, 250);
            this.lkeProduct.MinimumSize = new System.Drawing.Size(199, 30);
            this.lkeProduct.Name = "lkeProduct";
            this.lkeProduct.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeProduct.Properties.NullText = "";
            this.lkeProduct.Size = new System.Drawing.Size(323, 23);
            this.lkeProduct.TabIndex = 79;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(20, 21);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(127, 33);
            this.labelControl2.TabIndex = 80;
            this.labelControl2.Text = "SẢN PHẨM";
            // 
            // Material
            // 
            this.Material.Caption = "Material";
            this.Material.FieldName = "Material";
            this.Material.MinWidth = 25;
            this.Material.Name = "Material";
            this.Material.Visible = true;
            this.Material.VisibleIndex = 2;
            this.Material.Width = 94;
            // 
            // frmProdQRCodeTraceability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 721);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmProdQRCodeTraceability";
            this.Text = "frmProdQRCodeTraceability";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabWO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).EndInit();
            this.splitContainerControl2.Panel1.ResumeLayout(false);
            this.splitContainerControl2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).EndInit();
            this.splitContainerControl2.Panel2.ResumeLayout(false);
            this.splitContainerControl2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeWO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabTraceability)).EndInit();
            this.tabTraceability.ResumeLayout(false);
            this.tabBOM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBOMInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOMInfoView)).EndInit();
            this.tabWarehouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridWHInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWHInfoView)).EndInit();
            this.tabProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOMView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeProduct.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabWO;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.LookUpEdit lkeWO;
        private DevExpress.XtraEditors.LabelControl lbLSX;
        private DevExpress.XtraEditors.LabelControl lblCusPart;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblProduct;
        private DevExpress.XtraEditors.LabelControl lblProductID;
        private DevExpress.XtraTab.XtraTabControl tabTraceability;
        private DevExpress.XtraTab.XtraTabPage tabBOM;
        private DevExpress.XtraGrid.GridControl gridBOMInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridBOMInfoView;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialQuantity;
        private DevExpress.XtraTab.XtraTabPage tabWarehouse;
        private DevExpress.XtraGrid.GridControl gridWHInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridWHInfoView;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn WHAllocated;
        private DevExpress.XtraGrid.Columns.GridColumn LineUsedQty;
        private DevExpress.XtraGrid.Columns.GridColumn WORemainQty;
        private DevExpress.XtraTab.XtraTabPage tabProduction;
        private DevExpress.XtraTab.XtraTabPage tabQC;
        private DevExpress.XtraTab.XtraTabPage tabProduct;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LookUpEdit lkeProduct;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btExportExcel;
        private DevExpress.XtraGrid.GridControl gridBOM;
        private DevExpress.XtraGrid.Views.Grid.GridView gridBOMView;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn MaterialType;
        private DevExpress.XtraGrid.Columns.GridColumn QuotaQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn IsSemiProd;
        private DevExpress.XtraGrid.Columns.GridColumn MLevel;
        private DevExpress.XtraGrid.Columns.GridColumn Unit;
        private DevExpress.XtraGrid.Columns.GridColumn Applied;
        private DevExpress.XtraGrid.Columns.GridColumn UnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn LaborCost;
        private DevExpress.XtraGrid.Columns.GridColumn UsageCost;
        private DevExpress.XtraGrid.Columns.GridColumn CT;
        private DevExpress.XtraGrid.Columns.GridColumn Material;
    }
}