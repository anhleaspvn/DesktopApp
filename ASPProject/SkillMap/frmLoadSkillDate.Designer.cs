namespace ASPProject.SkillMap
{
    partial class frmLoadSkillDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadSkillDate));
            this.gridControlSkillDate = new DevExpress.XtraGrid.GridControl();
            this.gridViewSkillDate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButFilterYear = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditYear = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSkillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSkillDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditYear.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlSkillDate
            // 
            this.gridControlSkillDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlSkillDate.Location = new System.Drawing.Point(0, 72);
            this.gridControlSkillDate.MainView = this.gridViewSkillDate;
            this.gridControlSkillDate.Name = "gridControlSkillDate";
            this.gridControlSkillDate.Size = new System.Drawing.Size(1745, 815);
            this.gridControlSkillDate.TabIndex = 0;
            this.gridControlSkillDate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSkillDate});
            // 
            // gridViewSkillDate
            // 
            this.gridViewSkillDate.GridControl = this.gridControlSkillDate;
            this.gridViewSkillDate.Name = "gridViewSkillDate";
            // 
            // tablePanel1
            // 
            this.tablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 23.49F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 40F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 40F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 45F)});
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.simpleButFilterYear);
            this.tablePanel1.Controls.Add(this.dateEditYear);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 52.39998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1745, 66);
            this.tablePanel1.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(16, 3);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(134, 46);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Lọc theo năm :";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // simpleButFilterYear
            // 
            this.simpleButFilterYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButFilterYear.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButFilterYear.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.simpleButFilterYear, 3);
            this.simpleButFilterYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButFilterYear.ImageOptions.Image")));
            this.simpleButFilterYear.Location = new System.Drawing.Point(449, 4);
            this.simpleButFilterYear.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButFilterYear.Name = "simpleButFilterYear";
            this.tablePanel1.SetRow(this.simpleButFilterYear, 0);
            this.simpleButFilterYear.Size = new System.Drawing.Size(252, 44);
            this.simpleButFilterYear.TabIndex = 12;
            this.simpleButFilterYear.Text = "Lọc";
            this.simpleButFilterYear.Click += new System.EventHandler(this.simpleButFilterYear_Click);
            // 
            // dateEditYear
            // 
            this.tablePanel1.SetColumn(this.dateEditYear, 1);
            this.dateEditYear.EditValue = null;
            this.dateEditYear.Location = new System.Drawing.Point(156, 9);
            this.dateEditYear.Name = "dateEditYear";
            this.dateEditYear.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditYear.Properties.Appearance.Options.UseFont = true;
            this.dateEditYear.Properties.AutoHeight = false;
            this.dateEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditYear.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.dateEditYear, 0);
            this.dateEditYear.Size = new System.Drawing.Size(254, 34);
            this.dateEditYear.TabIndex = 11;
            //this.dateEditYear.EditValueChanged += new System.EventHandler(this.dateEditMonth_EditValueChanged);
            // 
            // frmLoadSkillDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 887);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.gridControlSkillDate);
            this.Name = "frmLoadSkillDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoadSkillDate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadSkillDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSkillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSkillDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditYear.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditYear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlSkillDate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSkillDate;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButFilterYear;
        private DevExpress.XtraEditors.DateEdit dateEditYear;
    }
}