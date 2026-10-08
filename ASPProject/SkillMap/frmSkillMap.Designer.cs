namespace ASPProject.AppTemplateSkillMap
{
    partial class frmSkillMap
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSkillMap));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Edit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemBtnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Delete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemBtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnChooseFile = new DevExpress.XtraEditors.SimpleButton();
            this.BtnImportFile = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.btnLoadDataKTV = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad_Data_Horizontal = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadDataUser = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlData
            // 
            this.gridControlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControlData.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridControlData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlData.Location = new System.Drawing.Point(0, 0);
            this.gridControlData.MainView = this.gridView1;
            this.gridControlData.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemBtnEdit,
            this.repItemBtnDelete});
            this.gridControlData.Size = new System.Drawing.Size(1556, 550);
            this.gridControlData.TabIndex = 0;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Edit,
            this.Delete});
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControlData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // Edit
            // 
            this.Edit.Caption = "Edit";
            this.Edit.ColumnEdit = this.repItemBtnEdit;
            this.Edit.MinWidth = 23;
            this.Edit.Name = "Edit";
            this.Edit.OptionsColumn.AllowEdit = false;
            this.Edit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "", "{0}")});
            this.Edit.Visible = true;
            this.Edit.VisibleIndex = 0;
            this.Edit.Width = 87;
            // 
            // repItemBtnEdit
            // 
            this.repItemBtnEdit.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.repItemBtnEdit.Appearance.Options.UseImage = true;
            this.repItemBtnEdit.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repItemBtnEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Edit", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repItemBtnEdit.ContextImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.repItemBtnEdit.Name = "repItemBtnEdit";
            // 
            // Delete
            // 
            this.Delete.Caption = "Delete";
            this.Delete.ColumnEdit = this.repItemBtnDelete;
            this.Delete.MinWidth = 23;
            this.Delete.Name = "Delete";
            this.Delete.OptionsColumn.AllowEdit = false;
            this.Delete.Visible = true;
            this.Delete.VisibleIndex = 1;
            this.Delete.Width = 87;
            // 
            // repItemBtnDelete
            // 
            this.repItemBtnDelete.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repItemBtnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Delete", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repItemBtnDelete.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("repItemBtnDelete.ContextImageOptions.Image")));
            this.repItemBtnDelete.Name = "repItemBtnDelete";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tablePanel1.AutoSize = true;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45F)});
            this.tablePanel1.Controls.Add(this.btnExportExcel);
            this.tablePanel1.Controls.Add(this.BtnChooseFile);
            this.tablePanel1.Controls.Add(this.BtnImportFile);
            this.tablePanel1.Controls.Add(this.label1);
            this.tablePanel1.Controls.Add(this.txtPath);
            this.tablePanel1.Location = new System.Drawing.Point(14, 22);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F)});
            this.tablePanel1.Size = new System.Drawing.Size(1514, 110);
            this.tablePanel1.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Appearance.Options.UseBackColor = true;
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnExportExcel, 5);
            this.btnExportExcel.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btnExportExcel.Location = new System.Drawing.Point(1092, 4);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.tablePanel1.SetRow(this.btnExportExcel, 0);
            this.btnExportExcel.Size = new System.Drawing.Size(418, 42);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // BtnChooseFile
            // 
            this.BtnChooseFile.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.BtnChooseFile.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.BtnChooseFile.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnChooseFile.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChooseFile.Appearance.Options.UseBackColor = true;
            this.BtnChooseFile.Appearance.Options.UseBorderColor = true;
            this.BtnChooseFile.Appearance.Options.UseFont = true;
            this.BtnChooseFile.AppearanceHovered.BackColor2 = System.Drawing.Color.Green;
            this.tablePanel1.SetColumn(this.BtnChooseFile, 3);
            this.BtnChooseFile.Location = new System.Drawing.Point(619, 4);
            this.BtnChooseFile.Margin = new System.Windows.Forms.Padding(4);
            this.BtnChooseFile.Name = "BtnChooseFile";
            this.tablePanel1.SetRow(this.BtnChooseFile, 0);
            this.BtnChooseFile.Size = new System.Drawing.Size(418, 42);
            this.BtnChooseFile.TabIndex = 2;
            this.BtnChooseFile.Text = "Choose File All";
            this.BtnChooseFile.Click += new System.EventHandler(this.BtnChooseFile_Click);
            // 
            // BtnImportFile
            // 
            this.BtnImportFile.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.BtnImportFile.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.BtnImportFile.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImportFile.Appearance.Options.UseBackColor = true;
            this.BtnImportFile.Appearance.Options.UseFont = true;
            this.BtnImportFile.AppearancePressed.BackColor = System.Drawing.Color.Maroon;
            this.BtnImportFile.AppearancePressed.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.BtnImportFile, 1);
            this.BtnImportFile.Location = new System.Drawing.Point(99, 60);
            this.BtnImportFile.Margin = new System.Windows.Forms.Padding(4);
            this.BtnImportFile.Name = "BtnImportFile";
            this.tablePanel1.SetRow(this.BtnImportFile, 1);
            this.BtnImportFile.Size = new System.Drawing.Size(465, 40);
            this.BtnImportFile.TabIndex = 3;
            this.BtnImportFile.Text = "Import File";
            this.BtnImportFile.Click += new System.EventHandler(this.BtnImportFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tablePanel1.SetColumn(this.label1, 0);
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.tablePanel1.SetRow(this.label1, 0);
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path :";
            // 
            // txtPath
            // 
            this.tablePanel1.SetColumn(this.txtPath, 1);
            this.txtPath.Location = new System.Drawing.Point(99, 13);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.tablePanel1.SetRow(this.txtPath, 0);
            this.txtPath.Size = new System.Drawing.Size(465, 23);
            this.txtPath.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.btnAdd, 0);
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(4, 13);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.tablePanel2.SetRow(this.btnAdd, 0);
            this.btnAdd.Size = new System.Drawing.Size(179, 46);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add New";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.btnExit, 2);
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.Location = new System.Drawing.Point(220, 13);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.tablePanel2.SetRow(this.btnExit, 0);
            this.btnExit.Size = new System.Drawing.Size(179, 46);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.Controls.Add(this.tablePanel1);
            this.groupControl2.Controls.Add(this.tablePanel2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 667);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1556, 217);
            this.groupControl2.TabIndex = 7;
            // 
            // tablePanel2
            // 
            this.tablePanel2.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tablePanel2.AutoSize = true;
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 7F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 7F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 75F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 7F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 75F)});
            this.tablePanel2.Controls.Add(this.btnLoadDataKTV);
            this.tablePanel2.Controls.Add(this.btnLoad_Data_Horizontal);
            this.tablePanel2.Controls.Add(this.btnExit);
            this.tablePanel2.Controls.Add(this.btnAdd);
            this.tablePanel2.Location = new System.Drawing.Point(14, 140);
            this.tablePanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(1083, 73);
            this.tablePanel2.TabIndex = 0;
            // 
            // btnLoadDataKTV
            // 
            this.btnLoadDataKTV.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDataKTV.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.btnLoadDataKTV, 6);
            this.btnLoadDataKTV.Location = new System.Drawing.Point(776, 13);
            this.btnLoadDataKTV.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadDataKTV.Name = "btnLoadDataKTV";
            this.tablePanel2.SetRow(this.btnLoadDataKTV, 0);
            this.btnLoadDataKTV.Size = new System.Drawing.Size(303, 46);
            this.btnLoadDataKTV.TabIndex = 8;
            this.btnLoadDataKTV.Text = "Load Data Horizontal KTV";
            this.btnLoadDataKTV.Click += new System.EventHandler(this.btnLoadDataKTV_Click);
            // 
            // btnLoad_Data_Horizontal
            // 
            this.btnLoad_Data_Horizontal.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad_Data_Horizontal.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.btnLoad_Data_Horizontal, 4);
            this.btnLoad_Data_Horizontal.Location = new System.Drawing.Point(436, 13);
            this.btnLoad_Data_Horizontal.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad_Data_Horizontal.Name = "btnLoad_Data_Horizontal";
            this.tablePanel2.SetRow(this.btnLoad_Data_Horizontal, 0);
            this.btnLoad_Data_Horizontal.Size = new System.Drawing.Size(303, 46);
            this.btnLoad_Data_Horizontal.TabIndex = 6;
            this.btnLoad_Data_Horizontal.Text = "Load Data Horizontal Line";
            this.btnLoad_Data_Horizontal.Click += new System.EventHandler(this.btnLoad_Data_Horizontal_Click);
            // 
            // btnLoadDataUser
            // 
            this.btnLoadDataUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDataUser.Appearance.Options.UseFont = true;
            this.btnLoadDataUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadDataUser.Location = new System.Drawing.Point(0, 550);
            this.btnLoadDataUser.Name = "btnLoadDataUser";
            this.btnLoadDataUser.Size = new System.Drawing.Size(1556, 51);
            this.btnLoadDataUser.TabIndex = 8;
            this.btnLoadDataUser.Text = "Xem Thông Tin Line Sản Xuất";
            this.btnLoadDataUser.Click += new System.EventHandler(this.btnLoadDataUser_Click);
            // 
            // frmSkillMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.Controls.Add(this.btnLoadDataUser);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.gridControlData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSkillMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSkillMap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //this.Load += new System.EventHandler(this.frmSkillMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton BtnChooseFile;
        private DevExpress.XtraEditors.SimpleButton BtnImportFile;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repItemBtnEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repItemBtnDelete;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.SimpleButton btnLoad_Data_Horizontal;
        private DevExpress.XtraEditors.SimpleButton btnLoadDataKTV;
        private DevExpress.XtraEditors.SimpleButton btnLoadDataUser;
    }
}

