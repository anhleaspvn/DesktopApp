namespace ASPProject.AppTemplateSkillMap
{
    partial class frmAddStaff
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
            this.gridAddStaff = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnImportFile = new DevExpress.XtraEditors.SimpleButton();
            this.txtPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.btnChooseFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridAddStaff
            // 
            this.gridAddStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAddStaff.Location = new System.Drawing.Point(12, 12);
            this.gridAddStaff.MainView = this.gridView1;
            this.gridAddStaff.Name = "gridAddStaff";
            this.gridAddStaff.Size = new System.Drawing.Size(1464, 251);
            this.gridAddStaff.TabIndex = 0;
            this.gridAddStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridAddStaff;
            this.gridView1.Name = "gridView1";
            this.gridView1.ColumnChanged += new System.EventHandler(this.gridView1_ColumnChanged);
            // 
            // btnImportFile
            // 
            this.btnImportFile.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnImportFile.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFile.Appearance.Options.UseBackColor = true;
            this.btnImportFile.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnImportFile, 1);
            this.btnImportFile.Location = new System.Drawing.Point(59, 46);
            this.btnImportFile.Name = "btnImportFile";
            this.tablePanel1.SetRow(this.btnImportFile, 1);
            this.btnImportFile.Size = new System.Drawing.Size(343, 40);
            this.btnImportFile.TabIndex = 1;
            this.btnImportFile.Text = "Import File ";
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // txtPath
            // 
            this.tablePanel1.SetColumn(this.txtPath, 1);
            this.txtPath.Location = new System.Drawing.Point(59, 11);
            this.txtPath.Name = "txtPath";
            this.tablePanel1.SetRow(this.txtPath, 0);
            this.txtPath.Size = new System.Drawing.Size(343, 20);
            this.txtPath.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.Location = new System.Drawing.Point(3, 10);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(43, 18);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Path :";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.tablePanel1);
            this.groupControl1.Location = new System.Drawing.Point(364, 290);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(735, 211);
            this.groupControl1.TabIndex = 4;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 12.28F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 75.88F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 17F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 54.84F)});
            this.tablePanel1.Controls.Add(this.btnChooseFile);
            this.tablePanel1.Controls.Add(this.btnExit);
            this.tablePanel1.Controls.Add(this.btnImportFile);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.txtPath);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 43F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 47F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(735, 211);
            this.tablePanel1.TabIndex = 0;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnChooseFile.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFile.Appearance.Options.UseBackColor = true;
            this.btnChooseFile.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnChooseFile, 3);
            this.btnChooseFile.Location = new System.Drawing.Point(486, 4);
            this.btnChooseFile.Name = "btnChooseFile";
            this.tablePanel1.SetRow(this.btnChooseFile, 0);
            this.btnChooseFile.Size = new System.Drawing.Size(246, 34);
            this.btnChooseFile.TabIndex = 5;
            this.btnChooseFile.Text = "Choose File";
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnExit, 3);
            this.btnExit.Location = new System.Drawing.Point(486, 46);
            this.btnExit.Name = "btnExit";
            this.tablePanel1.SetRow(this.btnExit, 1);
            this.btnExit.Size = new System.Drawing.Size(246, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmAddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 513);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridAddStaff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddStaff";
            this.Load += new System.EventHandler(this.frmAddStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAddStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridAddStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnImportFile;
        private DevExpress.XtraEditors.TextEdit txtPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnChooseFile;
    }
}