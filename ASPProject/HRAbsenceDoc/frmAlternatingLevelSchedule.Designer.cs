namespace ASPProject.ASPAlternatingLevelSchedule
{
    partial class frmAlternatingLevelSchedule
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
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlternatingLevelSchedule));
            this.tablePanel3 = new DevExpress.Utils.Layout.TablePanel();
            this.labelControlEnglish = new DevExpress.XtraEditors.LabelControl();
            this.labelControlViet = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.buttonEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDS_DangKy = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlShowData = new DevExpress.XtraGrid.GridControl();
            this.gridViewShowData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemButtonConfirm = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel3)).BeginInit();
            this.tablePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlShowData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewShowData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonConfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel3
            // 
            this.tablePanel3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tablePanel3.Appearance.Options.UseBackColor = true;
            this.tablePanel3.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel3.Controls.Add(this.labelControlEnglish);
            this.tablePanel3.Controls.Add(this.labelControlViet);
            this.tablePanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanel3.Location = new System.Drawing.Point(0, 0);
            this.tablePanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tablePanel3.Name = "tablePanel3";
            this.tablePanel3.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 36F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 24F)});
            this.tablePanel3.Size = new System.Drawing.Size(1636, 64);
            this.tablePanel3.TabIndex = 0;
            // 
            // labelControlEnglish
            // 
            this.labelControlEnglish.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.labelControlEnglish.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControlEnglish.Appearance.Options.UseFont = true;
            this.labelControlEnglish.Appearance.Options.UseForeColor = true;
            this.labelControlEnglish.Appearance.Options.UseTextOptions = true;
            this.labelControlEnglish.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlEnglish.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablePanel3.SetColumn(this.labelControlEnglish, 0);
            this.labelControlEnglish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControlEnglish.Location = new System.Drawing.Point(4, 40);
            this.labelControlEnglish.Margin = new System.Windows.Forms.Padding(4);
            this.labelControlEnglish.Name = "labelControlEnglish";
            this.tablePanel3.SetRow(this.labelControlEnglish, 1);
            this.labelControlEnglish.Size = new System.Drawing.Size(1628, 20);
            this.labelControlEnglish.TabIndex = 1;
            this.labelControlEnglish.Text = "ALTERNATE LEAVE SCHEDULE / WFH FOR SATURDAY OFFICE STAFF";
            // 
            // labelControlViet
            // 
            this.labelControlViet.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.labelControlViet.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControlViet.Appearance.Options.UseFont = true;
            this.labelControlViet.Appearance.Options.UseForeColor = true;
            this.labelControlViet.Appearance.Options.UseTextOptions = true;
            this.labelControlViet.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlViet.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablePanel3.SetColumn(this.labelControlViet, 0);
            this.labelControlViet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControlViet.Location = new System.Drawing.Point(4, 4);
            this.labelControlViet.Margin = new System.Windows.Forms.Padding(4);
            this.labelControlViet.Name = "labelControlViet";
            this.tablePanel3.SetRow(this.labelControlViet, 0);
            this.labelControlViet.Size = new System.Drawing.Size(1628, 28);
            this.labelControlViet.TabIndex = 0;
            this.labelControlViet.Text = "LỊCH NGHỈ LUÂN PHIÊN THỨ BẢY / WFH NHÂN VIÊN VĂN PHÒNG";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.tablePanel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 64);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1636, 48);
            this.groupControl1.TabIndex = 1;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 190F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 12F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 190F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 16F)});
            this.tablePanel1.Controls.Add(this.buttonEdit);
            this.tablePanel1.Controls.Add(this.btnDS_DangKy);
            this.tablePanel1.Controls.Add(this.btnExit);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 42F)});
            this.tablePanel1.Size = new System.Drawing.Size(1636, 48);
            this.tablePanel1.TabIndex = 0;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.buttonEdit, 1);
            this.buttonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEdit.Location = new System.Drawing.Point(1232, 7);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.tablePanel1.SetRow(this.buttonEdit, 0);
            this.buttonEdit.Size = new System.Drawing.Size(182, 34);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.Text = "Cập Nhật Lịch Nghỉ";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // btnDS_DangKy
            // 
            this.btnDS_DangKy.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDS_DangKy.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnDS_DangKy, 3);
            this.btnDS_DangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDS_DangKy.Location = new System.Drawing.Point(1434, 7);
            this.btnDS_DangKy.Margin = new System.Windows.Forms.Padding(4);
            this.btnDS_DangKy.Name = "btnDS_DangKy";
            this.tablePanel1.SetRow(this.btnDS_DangKy, 0);
            this.btnDS_DangKy.Size = new System.Drawing.Size(182, 34);
            this.btnDS_DangKy.TabIndex = 1;
            this.btnDS_DangKy.Text = "Danh Sách Đăng Ký";
            this.btnDS_DangKy.Click += new System.EventHandler(this.btnDS_DangKy_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.btnExit, 0);
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.Location = new System.Drawing.Point(4, 7);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.tablePanel1.SetRow(this.btnExit, 0);
            this.btnExit.Size = new System.Drawing.Size(1220, 34);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridControlShowData
            // 
            this.gridControlShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlShowData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlShowData.Location = new System.Drawing.Point(0, 112);
            this.gridControlShowData.MainView = this.gridViewShowData;
            this.gridControlShowData.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlShowData.Name = "gridControlShowData";
            this.gridControlShowData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonConfirm});
            this.gridControlShowData.Size = new System.Drawing.Size(1636, 786);
            this.gridControlShowData.TabIndex = 2;
            this.gridControlShowData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewShowData});
            // 
            // gridViewShowData
            // 
            this.gridViewShowData.DetailHeight = 431;
            this.gridViewShowData.GridControl = this.gridControlShowData;
            this.gridViewShowData.Name = "gridViewShowData";
            // 
            // repositoryItemButtonConfirm
            // 
            this.repositoryItemButtonConfirm.AutoHeight = false;
            this.repositoryItemButtonConfirm.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonConfirm.Name = "repositoryItemButtonConfirm";
            this.repositoryItemButtonConfirm.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // frmAlternatingLevelSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1636, 898);
            this.Controls.Add(this.gridControlShowData);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tablePanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAlternatingLevelSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm Alternating Level Schedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAlternatingLevelSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel3)).EndInit();
            this.tablePanel3.ResumeLayout(false);
            this.tablePanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlShowData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewShowData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonConfirm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControlShowData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewShowData;
        private DevExpress.XtraEditors.LabelControl labelControlViet;
        private DevExpress.Utils.Layout.TablePanel tablePanel3;
        private DevExpress.XtraEditors.LabelControl labelControlEnglish;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonConfirm;
        private DevExpress.XtraEditors.SimpleButton btnDS_DangKy;
        private DevExpress.XtraEditors.SimpleButton buttonEdit;
    }
}
