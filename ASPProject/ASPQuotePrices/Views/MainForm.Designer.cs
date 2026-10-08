namespace WinFormApp.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageComponents;
        private System.Windows.Forms.TabPage tabPagePIC;
        private System.Windows.Forms.TabPage tabPagePermissions;
        private System.Windows.Forms.TabPage tabPageHistory;
        
        // Components tab controls
        private System.Windows.Forms.DataGridView dgvComponents;
        private System.Windows.Forms.Panel panelCompFilters;
        private System.Windows.Forms.TextBox txtSearchPN;
        private System.Windows.Forms.ComboBox cmbFilterSection;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnCheckGaps;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Panel panelCompEditor;
        private System.Windows.Forms.Label lblEditorTitle;
        private System.Windows.Forms.TextBox txtEditRevision;
        private System.Windows.Forms.TextBox txtEditSection;
        private System.Windows.Forms.TextBox txtEditInternalPN;
        private System.Windows.Forms.TextBox txtEditGILRef;
        private System.Windows.Forms.TextBox txtEditManufacturer;
        private System.Windows.Forms.TextBox txtEditLeadTime;
        private System.Windows.Forms.TextBox txtEditCostBOM;
        private System.Windows.Forms.TextBox txtEditVendor;
        private System.Windows.Forms.TextBox txtEditPOPrice;
        private System.Windows.Forms.TextBox txtEditPOQty;
        private System.Windows.Forms.TextBox txtEditPIC;
        private System.Windows.Forms.Button btnSaveComponent;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.TextBox txtCurrentUser;

        // PIC tab controls
        private System.Windows.Forms.Panel panelPICHeader;
        private System.Windows.Forms.ComboBox cmbPICSection;
        private System.Windows.Forms.TextBox txtPICName;
        private System.Windows.Forms.Button btnSavePIC;
        private System.Windows.Forms.DataGridView dgvPICList;

        // Permissions tab controls
        private System.Windows.Forms.Panel panelPermHeader;
        private System.Windows.Forms.TextBox txtPermUser;
        private System.Windows.Forms.ComboBox cmbPermSection;
        private System.Windows.Forms.CheckBox chkPermRead;
        private System.Windows.Forms.CheckBox chkPermWrite;
        private System.Windows.Forms.Button btnSavePerm;
        private System.Windows.Forms.DataGridView dgvPermissions;

        // History tab controls
        private System.Windows.Forms.Panel panelHistoryHeader;
        private System.Windows.Forms.TextBox txtSearchHistory;
        private System.Windows.Forms.DataGridView dgvHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageComponents = new System.Windows.Forms.TabPage();
            this.tabPagePIC = new System.Windows.Forms.TabPage();
            this.tabPagePermissions = new System.Windows.Forms.TabPage();
            this.tabPageHistory = new System.Windows.Forms.TabPage();
            
            // Grid Components
            this.dgvComponents = new System.Windows.Forms.DataGridView();
            this.panelCompFilters = new System.Windows.Forms.Panel();
            this.txtSearchPN = new System.Windows.Forms.TextBox();
            this.cmbFilterSection = new System.Windows.Forms.ComboBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnCheckGaps = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.panelCompEditor = new System.Windows.Forms.Panel();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            
            // Textboxes & Labels
            this.txtEditRevision = new System.Windows.Forms.TextBox();
            this.txtEditSection = new System.Windows.Forms.TextBox();
            this.txtEditInternalPN = new System.Windows.Forms.TextBox();
            this.txtEditGILRef = new System.Windows.Forms.TextBox();
            this.txtEditManufacturer = new System.Windows.Forms.TextBox();
            this.txtEditLeadTime = new System.Windows.Forms.TextBox();
            this.txtEditCostBOM = new System.Windows.Forms.TextBox();
            this.txtEditVendor = new System.Windows.Forms.TextBox();
            this.txtEditPOPrice = new System.Windows.Forms.TextBox();
            this.txtEditPOQty = new System.Windows.Forms.TextBox();
            this.txtEditPIC = new System.Windows.Forms.TextBox();
            this.btnSaveComponent = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.txtCurrentUser = new System.Windows.Forms.TextBox();

            // PIC
            this.panelPICHeader = new System.Windows.Forms.Panel();
            this.cmbPICSection = new System.Windows.Forms.ComboBox();
            this.txtPICName = new System.Windows.Forms.TextBox();
            this.btnSavePIC = new System.Windows.Forms.Button();
            this.dgvPICList = new System.Windows.Forms.DataGridView();

            // Permissions
            this.panelPermHeader = new System.Windows.Forms.Panel();
            this.txtPermUser = new System.Windows.Forms.TextBox();
            this.cmbPermSection = new System.Windows.Forms.ComboBox();
            this.chkPermRead = new System.Windows.Forms.CheckBox();
            this.chkPermWrite = new System.Windows.Forms.CheckBox();
            this.btnSavePerm = new System.Windows.Forms.Button();
            this.dgvPermissions = new System.Windows.Forms.DataGridView();

            // History
            this.panelHistoryHeader = new System.Windows.Forms.Panel();
            this.txtSearchHistory = new System.Windows.Forms.TextBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();

            this.tabControlMain.SuspendLayout();
            this.tabPageComponents.SuspendLayout();
            this.tabPagePIC.SuspendLayout();
            this.tabPagePermissions.SuspendLayout();
            this.tabPageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).BeginInit();
            this.panelCompFilters.SuspendLayout();
            this.panelCompEditor.SuspendLayout();
            this.panelPICHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPICList)).BeginInit();
            this.panelPermHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).BeginInit();
            this.panelHistoryHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageComponents);
            this.tabControlMain.Controls.Add(this.tabPagePIC);
            this.tabControlMain.Controls.Add(this.tabPagePermissions);
            this.tabControlMain.Controls.Add(this.tabPageHistory);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1264, 761);
            this.tabControlMain.TabIndex = 0;

            // 
            // tabPageComponents
            // 
            this.tabPageComponents.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.tabPageComponents.Controls.Add(this.dgvComponents);
            this.tabPageComponents.Controls.Add(this.panelCompEditor);
            this.tabPageComponents.Controls.Add(this.panelCompFilters);
            this.tabPageComponents.Location = new System.Drawing.Point(4, 30);
            this.tabPageComponents.Name = "tabPageComponents";
            this.tabPageComponents.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageComponents.Size = new System.Drawing.Size(1256, 727);
            this.tabPageComponents.TabIndex = 0;
            this.tabPageComponents.Text = "Component Master List";

            // 
            // panelCompFilters
            // 
            this.panelCompFilters.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelCompFilters.Controls.Add(this.lblCurrentUser);
            this.panelCompFilters.Controls.Add(this.txtCurrentUser);
            this.panelCompFilters.Controls.Add(this.txtSearchPN);
            this.panelCompFilters.Controls.Add(this.cmbFilterSection);
            this.panelCompFilters.Controls.Add(this.btnClearFilters);
            this.panelCompFilters.Controls.Add(this.btnCheckGaps);
            this.panelCompFilters.Controls.Add(this.btnAddNew);
            this.panelCompFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCompFilters.Location = new System.Drawing.Point(10, 10);
            this.panelCompFilters.Name = "panelCompFilters";
            this.panelCompFilters.Size = new System.Drawing.Size(1236, 60);
            this.panelCompFilters.TabIndex = 0;

            // 
            // txtSearchPN
            // 
            this.txtSearchPN.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtSearchPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchPN.ForeColor = System.Drawing.Color.White;
            this.txtSearchPN.Location = new System.Drawing.Point(15, 15);
            this.txtSearchPN.Name = "txtSearchPN";
            this.txtSearchPN.Size = new System.Drawing.Size(200, 30);
            this.txtSearchPN.TabIndex = 0;
            this.txtSearchPN.Text = "Search Part Number...";
            this.txtSearchPN.ForeColor = System.Drawing.Color.Gray;

            // 
            // cmbFilterSection
            // 
            this.cmbFilterSection.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.cmbFilterSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilterSection.ForeColor = System.Drawing.Color.White;
            this.cmbFilterSection.FormattingEnabled = true;
            this.cmbFilterSection.Location = new System.Drawing.Point(230, 15);
            this.cmbFilterSection.Name = "cmbFilterSection";
            this.cmbFilterSection.Size = new System.Drawing.Size(150, 31);
            this.cmbFilterSection.TabIndex = 1;

            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClearFilters.FlatAppearance.BorderSize = 0;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(395, 14);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 32);
            this.btnClearFilters.TabIndex = 2;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = false;

            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(510, 14);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 32);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "+ Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;

            // 
            // btnCheckGaps
            // 
            this.btnCheckGaps.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnCheckGaps.FlatAppearance.BorderSize = 0;
            this.btnCheckGaps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckGaps.ForeColor = System.Drawing.Color.White;
            this.btnCheckGaps.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckGaps.Location = new System.Drawing.Point(625, 14);
            this.btnCheckGaps.Name = "btnCheckGaps";
            this.btnCheckGaps.Size = new System.Drawing.Size(220, 32);
            this.btnCheckGaps.TabIndex = 4;
            this.btnCheckGaps.Text = "⚠️ POPUP GAP ANALYSIS";
            this.btnCheckGaps.UseVisualStyleBackColor = false;

            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Location = new System.Drawing.Point(980, 19);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(110, 23);
            this.lblCurrentUser.TabIndex = 5;
            this.lblCurrentUser.Text = "Current User:";

            // 
            // txtCurrentUser
            // 
            this.txtCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentUser.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtCurrentUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentUser.ForeColor = System.Drawing.Color.White;
            this.txtCurrentUser.Location = new System.Drawing.Point(1090, 15);
            this.txtCurrentUser.Name = "txtCurrentUser";
            this.txtCurrentUser.Size = new System.Drawing.Size(130, 30);
            this.txtCurrentUser.TabIndex = 6;
            this.txtCurrentUser.Text = "james";

            // 
            // dgvComponents
            // 
            this.dgvComponents.AllowUserToAddRows = false;
            this.dgvComponents.AllowUserToDeleteRows = false;
            this.dgvComponents.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvComponents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComponents.Location = new System.Drawing.Point(10, 70);
            this.dgvComponents.Name = "dgvComponents";
            this.dgvComponents.ReadOnly = true;
            this.dgvComponents.RowHeadersVisible = false;
            this.dgvComponents.RowHeadersWidth = 51;
            this.dgvComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponents.Size = new System.Drawing.Size(916, 647);
            this.dgvComponents.TabIndex = 1;

            // 
            // panelCompEditor
            // 
            this.panelCompEditor.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelCompEditor.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCompEditor.Location = new System.Drawing.Point(926, 70);
            this.panelCompEditor.Name = "panelCompEditor";
            this.panelCompEditor.Padding = new System.Windows.Forms.Padding(15);
            this.panelCompEditor.Size = new System.Drawing.Size(320, 647);
            this.panelCompEditor.TabIndex = 2;

            // 
            // lblEditorTitle
            // 
            this.lblEditorTitle.AutoSize = true;
            this.lblEditorTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEditorTitle.ForeColor = System.Drawing.Color.White;
            this.lblEditorTitle.Location = new System.Drawing.Point(15, 15);
            this.lblEditorTitle.Name = "lblEditorTitle";
            this.lblEditorTitle.Size = new System.Drawing.Size(188, 28);
            this.lblEditorTitle.TabIndex = 0;
            this.lblEditorTitle.Text = "Edit Component";

            // 
            // tabPagePIC
            // 
            this.tabPagePIC.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.tabPagePIC.Controls.Add(this.dgvPICList);
            this.tabPagePIC.Controls.Add(this.panelPICHeader);
            this.tabPagePIC.Location = new System.Drawing.Point(4, 30);
            this.tabPagePIC.Name = "tabPagePIC";
            this.tabPagePIC.Padding = new System.Windows.Forms.Padding(10);
            this.tabPagePIC.Size = new System.Drawing.Size(1256, 727);
            this.tabPagePIC.TabIndex = 1;
            this.tabPagePIC.Text = "PIC & Section Assignments";

            // 
            // panelPICHeader
            // 
            this.panelPICHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelPICHeader.Controls.Add(this.cmbPICSection);
            this.panelPICHeader.Controls.Add(this.txtPICName);
            this.panelPICHeader.Controls.Add(this.btnSavePIC);
            this.panelPICHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPICHeader.Location = new System.Drawing.Point(10, 10);
            this.panelPICHeader.Name = "panelPICHeader";
            this.panelPICHeader.Size = new System.Drawing.Size(1236, 60);
            this.panelPICHeader.TabIndex = 0;

            // 
            // cmbPICSection
            // 
            this.cmbPICSection.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.cmbPICSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPICSection.ForeColor = System.Drawing.Color.White;
            this.cmbPICSection.FormattingEnabled = true;
            this.cmbPICSection.Location = new System.Drawing.Point(15, 15);
            this.cmbPICSection.Name = "cmbPICSection";
            this.cmbPICSection.Size = new System.Drawing.Size(180, 31);
            this.cmbPICSection.TabIndex = 0;

            // 
            // txtPICName
            // 
            this.txtPICName.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtPICName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPICName.ForeColor = System.Drawing.Color.White;
            this.txtPICName.Location = new System.Drawing.Point(210, 15);
            this.txtPICName.Name = "txtPICName";
            this.txtPICName.Size = new System.Drawing.Size(200, 30);
            this.txtPICName.TabIndex = 1;
            this.txtPICName.Text = "Enter PIC Name...";
            this.txtPICName.ForeColor = System.Drawing.Color.Gray;

            // 
            // btnSavePIC
            // 
            this.btnSavePIC.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnSavePIC.FlatAppearance.BorderSize = 0;
            this.btnSavePIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePIC.ForeColor = System.Drawing.Color.White;
            this.btnSavePIC.Location = new System.Drawing.Point(425, 14);
            this.btnSavePIC.Name = "btnSavePIC";
            this.btnSavePIC.Size = new System.Drawing.Size(120, 32);
            this.btnSavePIC.TabIndex = 2;
            this.btnSavePIC.Text = "Assign PIC";
            this.btnSavePIC.UseVisualStyleBackColor = false;

            // 
            // dgvPICList
            // 
            this.dgvPICList.AllowUserToAddRows = false;
            this.dgvPICList.AllowUserToDeleteRows = false;
            this.dgvPICList.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvPICList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPICList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPICList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPICList.Location = new System.Drawing.Point(10, 70);
            this.dgvPICList.Name = "dgvPICList";
            this.dgvPICList.ReadOnly = true;
            this.dgvPICList.RowHeadersVisible = false;
            this.dgvPICList.RowHeadersWidth = 51;
            this.dgvPICList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPICList.Size = new System.Drawing.Size(1236, 647);
            this.dgvPICList.TabIndex = 1;

            // 
            // tabPagePermissions
            // 
            this.tabPagePermissions.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.tabPagePermissions.Controls.Add(this.dgvPermissions);
            this.tabPagePermissions.Controls.Add(this.panelPermHeader);
            this.tabPagePermissions.Location = new System.Drawing.Point(4, 30);
            this.tabPagePermissions.Name = "tabPagePermissions";
            this.tabPagePermissions.Padding = new System.Windows.Forms.Padding(10);
            this.tabPagePermissions.Size = new System.Drawing.Size(1256, 727);
            this.tabPagePermissions.TabIndex = 2;
            this.tabPagePermissions.Text = "User Permissions";

            // 
            // panelPermHeader
            // 
            this.panelPermHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelPermHeader.Controls.Add(this.txtPermUser);
            this.panelPermHeader.Controls.Add(this.cmbPermSection);
            this.panelPermHeader.Controls.Add(this.chkPermRead);
            this.panelPermHeader.Controls.Add(this.chkPermWrite);
            this.panelPermHeader.Controls.Add(this.btnSavePerm);
            this.panelPermHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPermHeader.Location = new System.Drawing.Point(10, 10);
            this.panelPermHeader.Name = "panelPermHeader";
            this.panelPermHeader.Size = new System.Drawing.Size(1236, 60);
            this.panelPermHeader.TabIndex = 0;

            // 
            // txtPermUser
            // 
            this.txtPermUser.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtPermUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPermUser.ForeColor = System.Drawing.Color.White;
            this.txtPermUser.Location = new System.Drawing.Point(15, 15);
            this.txtPermUser.Name = "txtPermUser";
            this.txtPermUser.Size = new System.Drawing.Size(180, 30);
            this.txtPermUser.TabIndex = 0;
            this.txtPermUser.Text = "Enter Username...";
            this.txtPermUser.ForeColor = System.Drawing.Color.Gray;

            // 
            // cmbPermSection
            // 
            this.cmbPermSection.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.cmbPermSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPermSection.ForeColor = System.Drawing.Color.White;
            this.cmbPermSection.FormattingEnabled = true;
            this.cmbPermSection.Location = new System.Drawing.Point(210, 15);
            this.cmbPermSection.Name = "cmbPermSection";
            this.cmbPermSection.Size = new System.Drawing.Size(150, 31);
            this.cmbPermSection.TabIndex = 1;

            // 
            // chkPermRead
            // 
            this.chkPermRead.AutoSize = true;
            this.chkPermRead.Checked = true;
            this.chkPermRead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPermRead.ForeColor = System.Drawing.Color.White;
            this.chkPermRead.Location = new System.Drawing.Point(380, 19);
            this.chkPermRead.Name = "chkPermRead";
            this.chkPermRead.Size = new System.Drawing.Size(70, 27);
            this.chkPermRead.TabIndex = 2;
            this.chkPermRead.Text = "Read";
            this.chkPermRead.UseVisualStyleBackColor = true;

            // 
            // chkPermWrite
            // 
            this.chkPermWrite.AutoSize = true;
            this.chkPermWrite.ForeColor = System.Drawing.Color.White;
            this.chkPermWrite.Location = new System.Drawing.Point(460, 19);
            this.chkPermWrite.Name = "chkPermWrite";
            this.chkPermWrite.Size = new System.Drawing.Size(72, 27);
            this.chkPermWrite.TabIndex = 3;
            this.chkPermWrite.Text = "Write";
            this.chkPermWrite.UseVisualStyleBackColor = true;

            // 
            // btnSavePerm
            // 
            this.btnSavePerm.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnSavePerm.FlatAppearance.BorderSize = 0;
            this.btnSavePerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePerm.ForeColor = System.Drawing.Color.White;
            this.btnSavePerm.Location = new System.Drawing.Point(550, 14);
            this.btnSavePerm.Name = "btnSavePerm";
            this.btnSavePerm.Size = new System.Drawing.Size(140, 32);
            this.btnSavePerm.TabIndex = 4;
            this.btnSavePerm.Text = "Assign Permission";
            this.btnSavePerm.UseVisualStyleBackColor = false;

            // 
            // dgvPermissions
            // 
            this.dgvPermissions.AllowUserToAddRows = false;
            this.dgvPermissions.AllowUserToDeleteRows = false;
            this.dgvPermissions.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvPermissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPermissions.Location = new System.Drawing.Point(10, 70);
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.ReadOnly = true;
            this.dgvPermissions.RowHeadersVisible = false;
            this.dgvPermissions.RowHeadersWidth = 51;
            this.dgvPermissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissions.Size = new System.Drawing.Size(1236, 647);
            this.dgvPermissions.TabIndex = 1;

            // 
            // tabPageHistory
            // 
            this.tabPageHistory.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.tabPageHistory.Controls.Add(this.dgvHistory);
            this.tabPageHistory.Controls.Add(this.panelHistoryHeader);
            this.tabPageHistory.Location = new System.Drawing.Point(4, 30);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageHistory.Size = new System.Drawing.Size(1256, 727);
            this.tabPageHistory.TabIndex = 3;
            this.tabPageHistory.Text = "Change History Logs";

            // 
            // panelHistoryHeader
            // 
            this.panelHistoryHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelHistoryHeader.Controls.Add(this.txtSearchHistory);
            this.panelHistoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHistoryHeader.Location = new System.Drawing.Point(10, 10);
            this.panelHistoryHeader.Name = "panelHistoryHeader";
            this.panelHistoryHeader.Size = new System.Drawing.Size(1236, 60);
            this.panelHistoryHeader.TabIndex = 0;

            // 
            // txtSearchHistory
            // 
            this.txtSearchHistory.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtSearchHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchHistory.ForeColor = System.Drawing.Color.White;
            this.txtSearchHistory.Location = new System.Drawing.Point(15, 15);
            this.txtSearchHistory.Name = "txtSearchHistory";
            this.txtSearchHistory.Size = new System.Drawing.Size(300, 30);
            this.txtSearchHistory.TabIndex = 0;
            this.txtSearchHistory.Text = "Search Logs...";
            this.txtSearchHistory.ForeColor = System.Drawing.Color.Gray;

            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(10, 70);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(1236, 647);
            this.dgvHistory.TabIndex = 1;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Component Master List & GAP Analysis Dashboard (LinkQ Integration)";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageComponents.ResumeLayout(false);
            this.tabPagePIC.ResumeLayout(false);
            this.tabPagePermissions.ResumeLayout(false);
            this.tabPageHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).EndInit();
            this.panelCompFilters.ResumeLayout(false);
            this.panelCompFilters.PerformLayout();
            this.panelCompEditor.ResumeLayout(false);
            this.panelCompEditor.PerformLayout();
            this.panelPICHeader.ResumeLayout(false);
            this.panelPICHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPICList)).EndInit();
            this.panelPermHeader.ResumeLayout(false);
            this.panelPermHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.panelHistoryHeader.ResumeLayout(false);
            this.panelHistoryHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
