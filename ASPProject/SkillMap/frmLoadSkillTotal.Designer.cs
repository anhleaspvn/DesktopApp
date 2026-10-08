namespace ASPProject.SkillMap
{
    partial class frmLoadSkillTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadSkillTotal));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButFilterMonth = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditMonth = new DevExpress.XtraEditors.DateEdit();
            this.gridControlSkillTotal = new DevExpress.XtraGrid.GridControl();
            this.gridViewSkillTotal = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSkillTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSkillTotal)).BeginInit();
            this.SuspendLayout();
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
            this.tablePanel1.Controls.Add(this.simpleButFilterMonth);
            this.tablePanel1.Controls.Add(this.dateEditMonth);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 52.39998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1745, 66);
            this.tablePanel1.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(147, 46);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Lọc theo tháng :";
            // 
            // simpleButFilterMonth
            // 
            this.simpleButFilterMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButFilterMonth.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButFilterMonth.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.simpleButFilterMonth, 3);
            this.simpleButFilterMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButFilterMonth.ImageOptions.Image")));
            this.simpleButFilterMonth.Location = new System.Drawing.Point(449, 4);
            this.simpleButFilterMonth.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButFilterMonth.Name = "simpleButFilterMonth";
            this.tablePanel1.SetRow(this.simpleButFilterMonth, 0);
            this.simpleButFilterMonth.Size = new System.Drawing.Size(252, 44);
            this.simpleButFilterMonth.TabIndex = 12;
            this.simpleButFilterMonth.Text = "Lọc";
            this.simpleButFilterMonth.Click += new System.EventHandler(this.simpleButFilterMonth_Click);
            // 
            // dateEditMonth
            // 
            this.tablePanel1.SetColumn(this.dateEditMonth, 1);
            this.dateEditMonth.EditValue = null;
            this.dateEditMonth.Location = new System.Drawing.Point(156, 9);
            this.dateEditMonth.Name = "dateEditMonth";
            this.dateEditMonth.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditMonth.Properties.Appearance.Options.UseFont = true;
            this.dateEditMonth.Properties.AutoHeight = false;
            this.dateEditMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMonth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.dateEditMonth, 0);
            this.dateEditMonth.Size = new System.Drawing.Size(254, 34);
            this.dateEditMonth.TabIndex = 11;
            // 
            // gridControlSkillTotal
            // 
            this.gridControlSkillTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSkillTotal.Location = new System.Drawing.Point(0, 66);
            this.gridControlSkillTotal.MainView = this.gridViewSkillTotal;
            this.gridControlSkillTotal.Name = "gridControlSkillTotal";
            this.gridControlSkillTotal.Size = new System.Drawing.Size(1745, 821);
            this.gridControlSkillTotal.TabIndex = 10;
            this.gridControlSkillTotal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSkillTotal});
            // 
            // gridViewSkillTotal
            // 
            this.gridViewSkillTotal.GridControl = this.gridControlSkillTotal;
            this.gridViewSkillTotal.Name = "gridViewSkillTotal";
            // 
            // frmLoadSkillTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 887);
            this.Controls.Add(this.gridControlSkillTotal);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmLoadSkillTotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoadSkillTotal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadSkillTotal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSkillTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSkillTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButFilterMonth;
        private DevExpress.XtraEditors.DateEdit dateEditMonth;
        private DevExpress.XtraGrid.GridControl gridControlSkillTotal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSkillTotal;
    }
}