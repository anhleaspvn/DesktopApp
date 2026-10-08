namespace ASPProject.HRAbsenceDoc
{
    partial class frmHRGoLate
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dtpNgayTB = new DevExpress.XtraEditors.DateEdit();
            this.btSendMail = new DevExpress.XtraEditors.SimpleButton();
            this.gridHRGoLate = new DevExpress.XtraGrid.GridControl();
            this.gridHRGoLateView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMa_CbNv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen_CbNv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay_ChamCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGio_Vao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGio_Ra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhut_DiTre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhut_VeSom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhi_Chu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayTB.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRGoLate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRGoLateView)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.dtpNgayTB);
            this.splitContainerControl1.Panel1.Controls.Add(this.btSendMail);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridHRGoLate);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1112, 722);
            this.splitContainerControl1.SplitterPosition = 52;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // dtpNgayTB
            // 
            this.dtpNgayTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayTB.EditValue = null;
            this.dtpNgayTB.Location = new System.Drawing.Point(362, 15);
            this.dtpNgayTB.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpNgayTB.Name = "dtpNgayTB";
            this.dtpNgayTB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgayTB.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpNgayTB.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayTB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayTB.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayTB.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayTB.Size = new System.Drawing.Size(166, 23);
            this.dtpNgayTB.TabIndex = 78;
            // 
            // btSendMail
            // 
            this.btSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSendMail.ImageOptions.Image = global::ASPProject.Properties.Resources.report1;
            this.btSendMail.Location = new System.Drawing.Point(548, 11);
            this.btSendMail.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btSendMail.Name = "btSendMail";
            this.btSendMail.Size = new System.Drawing.Size(143, 30);
            this.btSendMail.TabIndex = 77;
            this.btSendMail.Text = "Gửi mail";
            // 
            // gridHRGoLate
            // 
            this.gridHRGoLate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHRGoLate.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridHRGoLate.Location = new System.Drawing.Point(0, 0);
            this.gridHRGoLate.MainView = this.gridHRGoLateView;
            this.gridHRGoLate.Margin = new System.Windows.Forms.Padding(4);
            this.gridHRGoLate.Name = "gridHRGoLate";
            this.gridHRGoLate.Size = new System.Drawing.Size(1112, 663);
            this.gridHRGoLate.TabIndex = 26;
            this.gridHRGoLate.UseEmbeddedNavigator = true;
            this.gridHRGoLate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridHRGoLateView});
            // 
            // gridHRGoLateView
            // 
            this.gridHRGoLateView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStt,
            this.colMa_CbNv,
            this.colTen_CbNv,
            this.colNgay_ChamCong,
            this.colGio_Vao,
            this.colGio_Ra,
            this.colPhut_DiTre,
            this.colPhut_VeSom,
            this.colGhi_Chu});
            this.gridHRGoLateView.DetailHeight = 431;
            this.gridHRGoLateView.GridControl = this.gridHRGoLate;
            this.gridHRGoLateView.Name = "gridHRGoLateView";
            this.gridHRGoLateView.OptionsBehavior.Editable = false;
            this.gridHRGoLateView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridHRGoLateView.OptionsSelection.MultiSelect = true;
            this.gridHRGoLateView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridHRGoLateView.OptionsView.ShowAutoFilterRow = true;
            this.gridHRGoLateView.OptionsView.ShowGroupPanel = false;
            // 
            // colStt
            // 
            this.colStt.Caption = "STT";
            this.colStt.FieldName = "Stt";
            this.colStt.MinWidth = 25;
            this.colStt.Name = "colStt";
            this.colStt.Visible = true;
            this.colStt.VisibleIndex = 1;
            this.colStt.Width = 94;
            // 
            // colMa_CbNv
            // 
            this.colMa_CbNv.Caption = "Mã nhân viên";
            this.colMa_CbNv.FieldName = "Ma_CbNv";
            this.colMa_CbNv.MinWidth = 25;
            this.colMa_CbNv.Name = "colMa_CbNv";
            this.colMa_CbNv.Visible = true;
            this.colMa_CbNv.VisibleIndex = 2;
            this.colMa_CbNv.Width = 94;
            // 
            // colTen_CbNv
            // 
            this.colTen_CbNv.Caption = "Tên nhân viên";
            this.colTen_CbNv.FieldName = "Ten_CbNv";
            this.colTen_CbNv.MinWidth = 25;
            this.colTen_CbNv.Name = "colTen_CbNv";
            this.colTen_CbNv.Visible = true;
            this.colTen_CbNv.VisibleIndex = 3;
            this.colTen_CbNv.Width = 94;
            // 
            // colNgay_ChamCong
            // 
            this.colNgay_ChamCong.Caption = "Ngày chấm công";
            this.colNgay_ChamCong.FieldName = "Ngay_ChamCong";
            this.colNgay_ChamCong.MinWidth = 25;
            this.colNgay_ChamCong.Name = "colNgay_ChamCong";
            this.colNgay_ChamCong.Visible = true;
            this.colNgay_ChamCong.VisibleIndex = 4;
            this.colNgay_ChamCong.Width = 94;
            // 
            // colGio_Vao
            // 
            this.colGio_Vao.Caption = "Giờ vào";
            this.colGio_Vao.FieldName = "Gio_Vao";
            this.colGio_Vao.MinWidth = 25;
            this.colGio_Vao.Name = "colGio_Vao";
            this.colGio_Vao.Visible = true;
            this.colGio_Vao.VisibleIndex = 5;
            this.colGio_Vao.Width = 94;
            // 
            // colGio_Ra
            // 
            this.colGio_Ra.Caption = "Giờ ra";
            this.colGio_Ra.FieldName = "Gio_Ra";
            this.colGio_Ra.MinWidth = 25;
            this.colGio_Ra.Name = "colGio_Ra";
            this.colGio_Ra.Visible = true;
            this.colGio_Ra.VisibleIndex = 6;
            this.colGio_Ra.Width = 94;
            // 
            // colPhut_DiTre
            // 
            this.colPhut_DiTre.Caption = "Phút đi trễ";
            this.colPhut_DiTre.FieldName = "Phut_DiTre";
            this.colPhut_DiTre.MinWidth = 25;
            this.colPhut_DiTre.Name = "colPhut_DiTre";
            this.colPhut_DiTre.Visible = true;
            this.colPhut_DiTre.VisibleIndex = 7;
            this.colPhut_DiTre.Width = 94;
            // 
            // colPhut_VeSom
            // 
            this.colPhut_VeSom.Caption = "Phút về sớm";
            this.colPhut_VeSom.FieldName = "Phut_VeSom";
            this.colPhut_VeSom.MinWidth = 25;
            this.colPhut_VeSom.Name = "colPhut_VeSom";
            this.colPhut_VeSom.Visible = true;
            this.colPhut_VeSom.VisibleIndex = 8;
            this.colPhut_VeSom.Width = 94;
            // 
            // colGhi_Chu
            // 
            this.colGhi_Chu.Caption = "Ghi chú";
            this.colGhi_Chu.FieldName = "Ghi_Chu";
            this.colGhi_Chu.MinWidth = 25;
            this.colGhi_Chu.Name = "colGhi_Chu";
            this.colGhi_Chu.Visible = true;
            this.colGhi_Chu.VisibleIndex = 9;
            this.colGhi_Chu.Width = 94;
            // 
            // frmHRGoLate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 722);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmHRGoLate";
            this.Text = "frmHRGoLate";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayTB.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRGoLate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHRGoLateView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.DateEdit dtpNgayTB;
        private DevExpress.XtraEditors.SimpleButton btSendMail;
        private DevExpress.XtraGrid.GridControl gridHRGoLate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridHRGoLateView;
        private DevExpress.XtraGrid.Columns.GridColumn colStt;
        private DevExpress.XtraGrid.Columns.GridColumn colMa_CbNv;
        private DevExpress.XtraGrid.Columns.GridColumn colTen_CbNv;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay_ChamCong;
        private DevExpress.XtraGrid.Columns.GridColumn colGio_Vao;
        private DevExpress.XtraGrid.Columns.GridColumn colGio_Ra;
        private DevExpress.XtraGrid.Columns.GridColumn colPhut_DiTre;
        private DevExpress.XtraGrid.Columns.GridColumn colPhut_VeSom;
        private DevExpress.XtraGrid.Columns.GridColumn colGhi_Chu;
    }
}