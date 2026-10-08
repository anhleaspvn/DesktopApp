namespace ASPProject.SkillMap
{
    partial class frmLoadDataHorizontal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadDataHorizontal));
            this.gridControlHorizontal = new DevExpress.XtraGrid.GridControl();
            this.gridViewHorizontal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExportExcelHorizontal = new DevExpress.XtraEditors.SimpleButton();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.btnExportTotalSkillMonth = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditDate = new DevExpress.XtraEditors.DateEdit();
            this.btnExportMonthYear = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportToDate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlHorizontal
            // 
            this.gridControlHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlHorizontal.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlHorizontal.Location = new System.Drawing.Point(0, 73);
            this.gridControlHorizontal.MainView = this.gridViewHorizontal;
            this.gridControlHorizontal.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlHorizontal.Name = "gridControlHorizontal";
            this.gridControlHorizontal.Size = new System.Drawing.Size(1745, 744);
            this.gridControlHorizontal.TabIndex = 0;
            this.gridControlHorizontal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHorizontal});
            this.gridControlHorizontal.Click += new System.EventHandler(this.gridControlHorizontal_Click);
            // 
            // gridViewHorizontal
            // 
            this.gridViewHorizontal.DetailHeight = 431;
            this.gridViewHorizontal.GridControl = this.gridControlHorizontal;
            this.gridViewHorizontal.Name = "gridViewHorizontal";
            this.gridViewHorizontal.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewHorizontal_RowCellStyle);
            // 
            // btnExportExcelHorizontal
            // 
            this.btnExportExcelHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcelHorizontal.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnExportExcelHorizontal.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcelHorizontal.Appearance.Options.UseBackColor = true;
            this.btnExportExcelHorizontal.Appearance.Options.UseFont = true;
            this.btnExportExcelHorizontal.ImageOptions.Image = global::ASPProject.Properties.Resources.excel;
            this.btnExportExcelHorizontal.Location = new System.Drawing.Point(548, 825);
            this.btnExportExcelHorizontal.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportExcelHorizontal.Name = "btnExportExcelHorizontal";
            this.btnExportExcelHorizontal.Size = new System.Drawing.Size(625, 54);
            this.btnExportExcelHorizontal.TabIndex = 6;
            this.btnExportExcelHorizontal.Text = "Export Excel";
            this.btnExportExcelHorizontal.Click += new System.EventHandler(this.btnExportExcelHorizontal_Click);
            // 
            // tablePanel1
            // 
            this.tablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 35F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 35F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 35F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 31.2F)});
            this.tablePanel1.Controls.Add(this.btnExportTotalSkillMonth);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.dateEditDate);
            this.tablePanel1.Controls.Add(this.btnExportMonthYear);
            this.tablePanel1.Controls.Add(this.btnImportToDate);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 47.59998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1745, 66);
            this.tablePanel1.TabIndex = 7;
            // 
            // btnExportTotalSkillMonth
            // 
            this.btnExportTotalSkillMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportTotalSkillMonth.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportTotalSkillMonth.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnExportTotalSkillMonth, 7);
            this.btnExportTotalSkillMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnExportTotalSkillMonth.Location = new System.Drawing.Point(1136, 4);
            this.btnExportTotalSkillMonth.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportTotalSkillMonth.Name = "btnExportTotalSkillMonth";
            this.tablePanel1.SetRow(this.btnExportTotalSkillMonth, 0);
            this.btnExportTotalSkillMonth.Size = new System.Drawing.Size(369, 40);
            this.btnExportTotalSkillMonth.TabIndex = 14;
            this.btnExportTotalSkillMonth.Text = "Export Total Skill Month Year";
            this.btnExportTotalSkillMonth.Click += new System.EventHandler(this.btnExportTotalSkillMonth_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(43, 3);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(143, 42);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Chọn thời gian :";
            // 
            // dateEditDate
            // 
            this.tablePanel1.SetColumn(this.dateEditDate, 1);
            this.dateEditDate.EditValue = null;
            this.dateEditDate.Location = new System.Drawing.Point(192, 5);
            this.dateEditDate.Name = "dateEditDate";
            this.dateEditDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditDate.Properties.Appearance.Options.UseFont = true;
            this.dateEditDate.Properties.AutoHeight = false;
            this.dateEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.dateEditDate, 0);
            this.dateEditDate.Size = new System.Drawing.Size(258, 37);
            this.dateEditDate.TabIndex = 11;
            // 
            // btnExportMonthYear
            // 
            this.btnExportMonthYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportMonthYear.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportMonthYear.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnExportMonthYear, 5);
            this.btnExportMonthYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportMonthYear.ImageOptions.Image")));
            this.btnExportMonthYear.Location = new System.Drawing.Point(834, 4);
            this.btnExportMonthYear.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportMonthYear.Name = "btnExportMonthYear";
            this.tablePanel1.SetRow(this.btnExportMonthYear, 0);
            this.btnExportMonthYear.Size = new System.Drawing.Size(256, 40);
            this.btnExportMonthYear.TabIndex = 10;
            this.btnExportMonthYear.Text = "Export Line Skill Year";
            this.btnExportMonthYear.Click += new System.EventHandler(this.btnExportMonthYear_Click);
            // 
            // btnImportToDate
            // 
            this.btnImportToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportToDate.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportToDate.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnImportToDate, 3);
            this.btnImportToDate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportToDate.ImageOptions.Image")));
            this.btnImportToDate.Location = new System.Drawing.Point(532, 4);
            this.btnImportToDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportToDate.Name = "btnImportToDate";
            this.tablePanel1.SetRow(this.btnImportToDate, 0);
            this.btnImportToDate.Size = new System.Drawing.Size(256, 40);
            this.btnImportToDate.TabIndex = 9;
            this.btnImportToDate.Text = "Import to Date";
            this.btnImportToDate.Click += new System.EventHandler(this.btnImportToDate_Click);
            // 
            // frmLoadDataHorizontal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 887);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.btnExportExcelHorizontal);
            this.Controls.Add(this.gridControlHorizontal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoadDataHorizontal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadDataHorizontal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlHorizontal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHorizontal;
        private DevExpress.XtraEditors.SimpleButton btnExportExcelHorizontal;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton btnExportMonthYear;
        private DevExpress.XtraEditors.SimpleButton btnImportToDate;
        private DevExpress.XtraEditors.DateEdit dateEditDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExportTotalSkillMonth;
    }
}