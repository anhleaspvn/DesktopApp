namespace ASPProject.NFCQReader
{
    partial class frmNFCQRReader
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
            this.gridNFC = new DevExpress.XtraGrid.GridControl();
            this.gridNFCView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSM232Content = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQRCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRGB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRGB2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHSV2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.mmSM232 = new DevExpress.XtraEditors.MemoEdit();
            this.lblNFC = new DevExpress.XtraEditors.LabelControl();
            this.ColorID = new DevExpress.XtraEditors.LabelControl();
            this.mmHSV2 = new DevExpress.XtraEditors.MemoEdit();
            this.mmRGB2 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btCamera = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.mmHSV = new DevExpress.XtraEditors.MemoEdit();
            this.mmRGB = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btSaveInfo = new DevExpress.XtraEditors.SimpleButton();
            this.mmQRCode = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btFilter = new DevExpress.XtraEditors.SimpleButton();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.colColorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HaveSpring = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridNFC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNFCView)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.mmSM232.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmHSV2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmRGB2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmHSV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmRGB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmQRCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel1)).BeginInit();
            this.splitContainerControl3.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel2)).BeginInit();
            this.splitContainerControl3.Panel2.SuspendLayout();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridNFC
            // 
            this.gridNFC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNFC.Location = new System.Drawing.Point(0, 0);
            this.gridNFC.MainView = this.gridNFCView;
            this.gridNFC.Name = "gridNFC";
            this.gridNFC.Size = new System.Drawing.Size(1492, 388);
            this.gridNFC.TabIndex = 0;
            this.gridNFC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridNFCView});
            // 
            // gridNFCView
            // 
            this.gridNFCView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colSM232Content,
            this.colQRCode,
            this.colResult,
            this.colRGB,
            this.colHSV,
            this.colRGB2,
            this.colHSV2,
            this.colColorID,
            this.HaveSpring});
            this.gridNFCView.GridControl = this.gridNFC;
            this.gridNFCView.Name = "gridNFCView";
            this.gridNFCView.OptionsBehavior.ReadOnly = true;
            this.gridNFCView.OptionsView.ShowAutoFilterRow = true;
            this.gridNFCView.OptionsView.ShowGroupPanel = false;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.MinWidth = 25;
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 94;
            // 
            // colSM232Content
            // 
            this.colSM232Content.Caption = "NFC";
            this.colSM232Content.FieldName = "SM232Content";
            this.colSM232Content.MinWidth = 25;
            this.colSM232Content.Name = "colSM232Content";
            this.colSM232Content.Visible = true;
            this.colSM232Content.VisibleIndex = 1;
            this.colSM232Content.Width = 94;
            // 
            // colQRCode
            // 
            this.colQRCode.Caption = "QR CODE";
            this.colQRCode.FieldName = "QRCodeContent";
            this.colQRCode.MinWidth = 25;
            this.colQRCode.Name = "colQRCode";
            this.colQRCode.Visible = true;
            this.colQRCode.VisibleIndex = 2;
            this.colQRCode.Width = 94;
            // 
            // colResult
            // 
            this.colResult.Caption = "Kết quả";
            this.colResult.FieldName = "ResultMatch";
            this.colResult.MinWidth = 25;
            this.colResult.Name = "colResult";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 3;
            this.colResult.Width = 94;
            // 
            // colRGB
            // 
            this.colRGB.Caption = "RGB";
            this.colRGB.FieldName = "RGB";
            this.colRGB.MinWidth = 25;
            this.colRGB.Name = "colRGB";
            this.colRGB.Width = 94;
            // 
            // colHSV
            // 
            this.colHSV.Caption = "HSV";
            this.colHSV.FieldName = "HSV";
            this.colHSV.MinWidth = 25;
            this.colHSV.Name = "colHSV";
            this.colHSV.Width = 94;
            // 
            // colRGB2
            // 
            this.colRGB2.Caption = "RGB 2";
            this.colRGB2.FieldName = "RGB2";
            this.colRGB2.MinWidth = 25;
            this.colRGB2.Name = "colRGB2";
            this.colRGB2.Width = 94;
            // 
            // colHSV2
            // 
            this.colHSV2.Caption = "HSV 2";
            this.colHSV2.FieldName = "HSV2";
            this.colHSV2.MinWidth = 25;
            this.colHSV2.Name = "colHSV2";
            this.colHSV2.Width = 94;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridNFC);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1492, 553);
            this.splitContainerControl1.SplitterPosition = 158;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            // 
            // splitContainerControl2.Panel1
            // 
            this.splitContainerControl2.Panel1.Controls.Add(this.mmSM232);
            this.splitContainerControl2.Panel1.Controls.Add(this.lblNFC);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            // 
            // splitContainerControl2.Panel2
            // 
            this.splitContainerControl2.Panel2.Controls.Add(this.ColorID);
            this.splitContainerControl2.Panel2.Controls.Add(this.mmHSV2);
            this.splitContainerControl2.Panel2.Controls.Add(this.mmRGB2);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl6);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl7);
            this.splitContainerControl2.Panel2.Controls.Add(this.btCamera);
            this.splitContainerControl2.Panel2.Controls.Add(this.btCancel);
            this.splitContainerControl2.Panel2.Controls.Add(this.mmHSV);
            this.splitContainerControl2.Panel2.Controls.Add(this.mmRGB);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl2.Panel2.Controls.Add(this.btSaveInfo);
            this.splitContainerControl2.Panel2.Controls.Add(this.mmQRCode);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1492, 158);
            this.splitContainerControl2.SplitterPosition = 320;
            this.splitContainerControl2.TabIndex = 0;
            // 
            // mmSM232
            // 
            this.mmSM232.Location = new System.Drawing.Point(12, 44);
            this.mmSM232.Name = "mmSM232";
            this.mmSM232.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmSM232.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.mmSM232.Properties.Appearance.Options.UseFont = true;
            this.mmSM232.Properties.Appearance.Options.UseForeColor = true;
            this.mmSM232.Properties.ReadOnly = true;
            this.mmSM232.Size = new System.Drawing.Size(303, 96);
            this.mmSM232.TabIndex = 1;
            // 
            // lblNFC
            // 
            this.lblNFC.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNFC.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblNFC.Appearance.Options.UseFont = true;
            this.lblNFC.Appearance.Options.UseForeColor = true;
            this.lblNFC.Location = new System.Drawing.Point(12, 12);
            this.lblNFC.Name = "lblNFC";
            this.lblNFC.Size = new System.Drawing.Size(40, 24);
            this.lblNFC.TabIndex = 0;
            this.lblNFC.Text = "NFC";
            // 
            // ColorID
            // 
            this.ColorID.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorID.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ColorID.Appearance.Options.UseFont = true;
            this.ColorID.Appearance.Options.UseForeColor = true;
            this.ColorID.Location = new System.Drawing.Point(585, 15);
            this.ColorID.Name = "ColorID";
            this.ColorID.Size = new System.Drawing.Size(100, 24);
            this.ColorID.TabIndex = 13;
            this.ColorID.Text = "COLOR ID";
            // 
            // mmHSV2
            // 
            this.mmHSV2.Location = new System.Drawing.Point(729, 98);
            this.mmHSV2.Name = "mmHSV2";
            this.mmHSV2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmHSV2.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.mmHSV2.Properties.Appearance.Options.UseFont = true;
            this.mmHSV2.Properties.Appearance.Options.UseForeColor = true;
            this.mmHSV2.Properties.ReadOnly = true;
            this.mmHSV2.Size = new System.Drawing.Size(220, 42);
            this.mmHSV2.TabIndex = 12;
            // 
            // mmRGB2
            // 
            this.mmRGB2.Location = new System.Drawing.Point(729, 50);
            this.mmRGB2.Name = "mmRGB2";
            this.mmRGB2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmRGB2.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.mmRGB2.Properties.Appearance.Options.UseFont = true;
            this.mmRGB2.Properties.Appearance.Options.UseForeColor = true;
            this.mmRGB2.Properties.ReadOnly = true;
            this.mmRGB2.Size = new System.Drawing.Size(220, 42);
            this.mmRGB2.TabIndex = 11;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(657, 68);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(63, 24);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "RGB 2";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(657, 116);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(61, 24);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "HSV 2";
            // 
            // btCamera
            // 
            this.btCamera.Location = new System.Drawing.Point(405, 14);
            this.btCamera.Name = "btCamera";
            this.btCamera.Size = new System.Drawing.Size(141, 25);
            this.btCamera.TabIndex = 5;
            this.btCamera.Text = "Open Camera";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.cancel;
            this.btCancel.Location = new System.Drawing.Point(978, 92);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(169, 48);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Xoá thông tin";
            // 
            // mmHSV
            // 
            this.mmHSV.Location = new System.Drawing.Point(405, 98);
            this.mmHSV.Name = "mmHSV";
            this.mmHSV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmHSV.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.mmHSV.Properties.Appearance.Options.UseFont = true;
            this.mmHSV.Properties.Appearance.Options.UseForeColor = true;
            this.mmHSV.Properties.ReadOnly = true;
            this.mmHSV.Size = new System.Drawing.Size(220, 42);
            this.mmHSV.TabIndex = 7;
            // 
            // mmRGB
            // 
            this.mmRGB.Location = new System.Drawing.Point(405, 50);
            this.mmRGB.Name = "mmRGB";
            this.mmRGB.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmRGB.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.mmRGB.Properties.Appearance.Options.UseFont = true;
            this.mmRGB.Properties.Appearance.Options.UseForeColor = true;
            this.mmRGB.Properties.ReadOnly = true;
            this.mmRGB.Size = new System.Drawing.Size(220, 42);
            this.mmRGB.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(333, 68);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(63, 24);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "RGB 1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(333, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 24);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "HSV 1";
            // 
            // btSaveInfo
            // 
            this.btSaveInfo.ImageOptions.Image = global::ASPProject.Properties.Resources.check;
            this.btSaveInfo.Location = new System.Drawing.Point(978, 30);
            this.btSaveInfo.Name = "btSaveInfo";
            this.btSaveInfo.Size = new System.Drawing.Size(169, 48);
            this.btSaveInfo.TabIndex = 3;
            this.btSaveInfo.Text = "Lưu thông tin";
            // 
            // mmQRCode
            // 
            this.mmQRCode.Location = new System.Drawing.Point(4, 44);
            this.mmQRCode.Name = "mmQRCode";
            this.mmQRCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmQRCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mmQRCode.Properties.Appearance.Options.UseFont = true;
            this.mmQRCode.Properties.Appearance.Options.UseForeColor = true;
            this.mmQRCode.Properties.ReadOnly = true;
            this.mmQRCode.Size = new System.Drawing.Size(303, 96);
            this.mmQRCode.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(4, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 24);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "QR CODE";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            // 
            // splitContainerControl3.Panel1
            // 
            this.splitContainerControl3.Panel1.Controls.Add(this.btFilter);
            this.splitContainerControl3.Panel1.Controls.Add(this.dtToDate);
            this.splitContainerControl3.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl3.Panel1.Controls.Add(this.dtFromDate);
            this.splitContainerControl3.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            // 
            // splitContainerControl3.Panel2
            // 
            this.splitContainerControl3.Panel2.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(1492, 615);
            this.splitContainerControl3.SplitterPosition = 55;
            this.splitContainerControl3.TabIndex = 1;
            // 
            // btFilter
            // 
            this.btFilter.Location = new System.Drawing.Point(553, 19);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(141, 25);
            this.btFilter.TabIndex = 4;
            this.btFilter.Text = "Lọc dữ liệu";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(336, 22);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtToDate.Size = new System.Drawing.Size(147, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(268, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Đến ngày";
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(80, 22);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFromDate.Size = new System.Drawing.Size(147, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Từ ngày";
            // 
            // colColorID
            // 
            this.colColorID.Caption = "Color";
            this.colColorID.FieldName = "ColorID";
            this.colColorID.MinWidth = 25;
            this.colColorID.Name = "colColorID";
            this.colColorID.Visible = true;
            this.colColorID.VisibleIndex = 4;
            this.colColorID.Width = 94;
            // 
            // HaveSpring
            // 
            this.HaveSpring.Caption = "Spring";
            this.HaveSpring.FieldName = "HaveSpring";
            this.HaveSpring.MinWidth = 25;
            this.HaveSpring.Name = "HaveSpring";
            this.HaveSpring.Visible = true;
            this.HaveSpring.VisibleIndex = 5;
            this.HaveSpring.Width = 94;
            // 
            // frmNFCQRReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 615);
            this.Controls.Add(this.splitContainerControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNFCQRReader";
            this.Text = "NFCQRReader";
            ((System.ComponentModel.ISupportInitialize)(this.gridNFC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNFCView)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.mmSM232.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmHSV2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmRGB2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmHSV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmRGB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmQRCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel1)).EndInit();
            this.splitContainerControl3.Panel1.ResumeLayout(false);
            this.splitContainerControl3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel2)).EndInit();
            this.splitContainerControl3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridNFC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridNFCView;
        private DevExpress.XtraGrid.Columns.GridColumn colSM232Content;
        private DevExpress.XtraGrid.Columns.GridColumn colQRCode;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.MemoEdit mmSM232;
        private DevExpress.XtraEditors.LabelControl lblNFC;
        private DevExpress.XtraEditors.MemoEdit mmQRCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btSaveInfo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraEditors.SimpleButton btFilter;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btCamera;
        private DevExpress.XtraEditors.MemoEdit mmHSV;
        private DevExpress.XtraEditors.MemoEdit mmRGB;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colRGB;
        private DevExpress.XtraGrid.Columns.GridColumn colHSV;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.MemoEdit mmHSV2;
        private DevExpress.XtraEditors.MemoEdit mmRGB2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.Columns.GridColumn colRGB2;
        private DevExpress.XtraGrid.Columns.GridColumn colHSV2;
        private DevExpress.XtraEditors.LabelControl ColorID;
        private DevExpress.XtraGrid.Columns.GridColumn colColorID;
        private DevExpress.XtraGrid.Columns.GridColumn HaveSpring;
    }
}