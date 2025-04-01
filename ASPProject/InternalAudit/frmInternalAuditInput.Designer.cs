namespace ASPProject.InternalAudit
{
    partial class frmInternalAuditInput
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btSendMail = new DevExpress.XtraEditors.SimpleButton();
            this.chkDeptSigned = new DevExpress.XtraEditors.CheckEdit();
            this.chkHeadSigned = new DevExpress.XtraEditors.CheckEdit();
            this.chkGLSigned = new DevExpress.XtraEditors.CheckEdit();
            this.gridAuditInput = new DevExpress.XtraGrid.GridControl();
            this.gridAuditInputView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClauseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClauseReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Question = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Evidences = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Conclusion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AuditorName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptSigned.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHeadSigned.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGLSigned.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInputView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btSendMail);
            this.panelControl1.Controls.Add(this.chkDeptSigned);
            this.panelControl1.Controls.Add(this.chkHeadSigned);
            this.panelControl1.Controls.Add(this.chkGLSigned);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 459);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1052, 55);
            this.panelControl1.TabIndex = 1;
            // 
            // btSendMail
            // 
            this.btSendMail.ImageOptions.Image = global::ASPProject.Properties.Resources.refresh1;
            this.btSendMail.Location = new System.Drawing.Point(910, 12);
            this.btSendMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSendMail.Name = "btSendMail";
            this.btSendMail.Size = new System.Drawing.Size(112, 32);
            this.btSendMail.TabIndex = 133;
            this.btSendMail.Text = "Gửi mail";
            // 
            // chkDeptSigned
            // 
            this.chkDeptSigned.Location = new System.Drawing.Point(441, 16);
            this.chkDeptSigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDeptSigned.Name = "chkDeptSigned";
            this.chkDeptSigned.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeptSigned.Properties.Appearance.Options.UseFont = true;
            this.chkDeptSigned.Properties.Caption = "Trưởng bộ phận";
            this.chkDeptSigned.Size = new System.Drawing.Size(153, 23);
            this.chkDeptSigned.TabIndex = 2;
            // 
            // chkHeadSigned
            // 
            this.chkHeadSigned.Location = new System.Drawing.Point(234, 16);
            this.chkHeadSigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkHeadSigned.Name = "chkHeadSigned";
            this.chkHeadSigned.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHeadSigned.Properties.Appearance.Options.UseFont = true;
            this.chkHeadSigned.Properties.Caption = "Trưởng đoàn";
            this.chkHeadSigned.Size = new System.Drawing.Size(127, 23);
            this.chkHeadSigned.TabIndex = 1;
            // 
            // chkGLSigned
            // 
            this.chkGLSigned.Location = new System.Drawing.Point(20, 16);
            this.chkGLSigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkGLSigned.Name = "chkGLSigned";
            this.chkGLSigned.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGLSigned.Properties.Appearance.Options.UseFont = true;
            this.chkGLSigned.Properties.Caption = "Trưởng nhóm";
            this.chkGLSigned.Size = new System.Drawing.Size(128, 23);
            this.chkGLSigned.TabIndex = 0;
            // 
            // gridAuditInput
            // 
            this.gridAuditInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuditInput.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gridAuditInput.Location = new System.Drawing.Point(0, 0);
            this.gridAuditInput.MainView = this.gridAuditInputView;
            this.gridAuditInput.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gridAuditInput.Name = "gridAuditInput";
            this.gridAuditInput.Size = new System.Drawing.Size(1052, 459);
            this.gridAuditInput.TabIndex = 5;
            this.gridAuditInput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAuditInputView});
            // 
            // gridAuditInputView
            // 
            this.gridAuditInputView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OrderNo,
            this.ClauseNo,
            this.ClauseReq,
            this.Question,
            this.Evidences,
            this.Conclusion,
            this.AuditorName});
            this.gridAuditInputView.DetailHeight = 692;
            this.gridAuditInputView.GridControl = this.gridAuditInput;
            this.gridAuditInputView.Name = "gridAuditInputView";
            this.gridAuditInputView.OptionsBehavior.ReadOnly = true;
            this.gridAuditInputView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridAuditInputView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridAuditInputView.OptionsView.RowAutoHeight = true;
            this.gridAuditInputView.OptionsView.ShowAutoFilterRow = true;
            this.gridAuditInputView.OptionsView.ShowFooter = true;
            this.gridAuditInputView.OptionsView.ShowGroupPanel = false;
            // 
            // OrderNo
            // 
            this.OrderNo.Caption = "Stt";
            this.OrderNo.FieldName = "OrderNo";
            this.OrderNo.MinWidth = 21;
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Visible = true;
            this.OrderNo.VisibleIndex = 0;
            this.OrderNo.Width = 81;
            // 
            // ClauseNo
            // 
            this.ClauseNo.Caption = "Clause No";
            this.ClauseNo.FieldName = "ClauseNo";
            this.ClauseNo.MinWidth = 21;
            this.ClauseNo.Name = "ClauseNo";
            this.ClauseNo.Visible = true;
            this.ClauseNo.VisibleIndex = 1;
            this.ClauseNo.Width = 81;
            // 
            // ClauseReq
            // 
            this.ClauseReq.Caption = "Clause Description";
            this.ClauseReq.FieldName = "ClauseReq";
            this.ClauseReq.MinWidth = 21;
            this.ClauseReq.Name = "ClauseReq";
            this.ClauseReq.Visible = true;
            this.ClauseReq.VisibleIndex = 2;
            this.ClauseReq.Width = 300;
            // 
            // Question
            // 
            this.Question.Caption = "Question";
            this.Question.FieldName = "Question";
            this.Question.MinWidth = 21;
            this.Question.Name = "Question";
            this.Question.Visible = true;
            this.Question.VisibleIndex = 3;
            this.Question.Width = 257;
            // 
            // Evidences
            // 
            this.Evidences.Caption = "Evidences";
            this.Evidences.FieldName = "Evidences";
            this.Evidences.MinWidth = 21;
            this.Evidences.Name = "Evidences";
            this.Evidences.Visible = true;
            this.Evidences.VisibleIndex = 4;
            this.Evidences.Width = 129;
            // 
            // Conclusion
            // 
            this.Conclusion.Caption = "Conclusion";
            this.Conclusion.FieldName = "Conclusion";
            this.Conclusion.MinWidth = 21;
            this.Conclusion.Name = "Conclusion";
            this.Conclusion.Visible = true;
            this.Conclusion.VisibleIndex = 5;
            this.Conclusion.Width = 81;
            // 
            // AuditorName
            // 
            this.AuditorName.Caption = "AuditorName";
            this.AuditorName.FieldName = "AuditorName";
            this.AuditorName.MinWidth = 21;
            this.AuditorName.Name = "AuditorName";
            this.AuditorName.Visible = true;
            this.AuditorName.VisibleIndex = 6;
            this.AuditorName.Width = 103;
            // 
            // frmInternalAuditInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 514);
            this.Controls.Add(this.gridAuditInput);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmInternalAuditInput";
            this.Text = "frmInternalAuditInput";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDeptSigned.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHeadSigned.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGLSigned.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditInputView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkDeptSigned;
        private DevExpress.XtraEditors.CheckEdit chkHeadSigned;
        private DevExpress.XtraEditors.CheckEdit chkGLSigned;
        private DevExpress.XtraGrid.GridControl gridAuditInput;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAuditInputView;
        private DevExpress.XtraGrid.Columns.GridColumn OrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn ClauseNo;
        private DevExpress.XtraGrid.Columns.GridColumn ClauseReq;
        private DevExpress.XtraGrid.Columns.GridColumn Question;
        private DevExpress.XtraGrid.Columns.GridColumn Evidences;
        private DevExpress.XtraGrid.Columns.GridColumn Conclusion;
        private DevExpress.XtraGrid.Columns.GridColumn AuditorName;
        private DevExpress.XtraEditors.SimpleButton btSendMail;
    }
}