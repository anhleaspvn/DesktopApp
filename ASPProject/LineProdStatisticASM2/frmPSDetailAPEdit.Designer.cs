namespace ASPProject.LineProdStatisticASM2
{
    partial class frmPSDetailAPEdit
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
            this.lkeDefectiD = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbLosstimeID = new DevExpress.XtraEditors.LabelControl();
            this.txtNumOfTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDefectiD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOfTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lkeDefectiD
            // 
            this.lkeDefectiD.EditValue = "";
            this.lkeDefectiD.Location = new System.Drawing.Point(147, 17);
            this.lkeDefectiD.Margin = new System.Windows.Forms.Padding(8);
            this.lkeDefectiD.Name = "lkeDefectiD";
            this.lkeDefectiD.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeDefectiD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDefectiD.Properties.NullText = "";
            this.lkeDefectiD.Size = new System.Drawing.Size(246, 23);
            this.lkeDefectiD.TabIndex = 74;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(91, 23);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(10);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 75;
            this.labelControl12.Text = "(*)";
            // 
            // lbLosstimeID
            // 
            this.lbLosstimeID.Location = new System.Drawing.Point(25, 23);
            this.lbLosstimeID.Margin = new System.Windows.Forms.Padding(10);
            this.lbLosstimeID.Name = "lbLosstimeID";
            this.lbLosstimeID.Size = new System.Drawing.Size(57, 16);
            this.lbLosstimeID.TabIndex = 76;
            this.lbLosstimeID.Text = "Mã Defect";
            // 
            // txtNumOfTime
            // 
            this.txtNumOfTime.Location = new System.Drawing.Point(147, 50);
            this.txtNumOfTime.Margin = new System.Windows.Forms.Padding(15);
            this.txtNumOfTime.Name = "txtNumOfTime";
            this.txtNumOfTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumOfTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumOfTime.Properties.UseMaskAsDisplayFormat = true;
            this.txtNumOfTime.Size = new System.Drawing.Size(246, 23);
            this.txtNumOfTime.TabIndex = 116;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 57);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 16);
            this.labelControl2.TabIndex = 117;
            this.labelControl2.Text = "Số giờ";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(242, 108);
            this.btCancel.Margin = new System.Windows.Forms.Padding(8);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(151, 44);
            this.btCancel.TabIndex = 122;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(39, 108);
            this.btSave.Margin = new System.Windows.Forms.Padding(8);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(152, 44);
            this.btSave.TabIndex = 121;
            this.btSave.Text = "Lưu";
            // 
            // frmPSDetailAPEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 176);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txtNumOfTime);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lkeDefectiD);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLosstimeID);
            this.Name = "frmPSDetailAPEdit";
            this.Text = "frmPSDetailAPEdit";
            ((System.ComponentModel.ISupportInitialize)(this.lkeDefectiD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumOfTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkeDefectiD;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLosstimeID;
        private DevExpress.XtraEditors.TextEdit txtNumOfTime;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
    }
}