namespace ASPProject.LineProdStatistic
{
    partial class frmPSDetailLosstimeEdit
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
            this.txtLosstimeNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.lkeLosstimeID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lbLosstimeID = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtLosstimeNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLosstimeID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLosstimeNum
            // 
            this.txtLosstimeNum.Location = new System.Drawing.Point(173, 65);
            this.txtLosstimeNum.Margin = new System.Windows.Forms.Padding(8);
            this.txtLosstimeNum.Name = "txtLosstimeNum";
            this.txtLosstimeNum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLosstimeNum.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLosstimeNum.Size = new System.Drawing.Size(226, 23);
            this.txtLosstimeNum.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 71);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 16);
            this.labelControl1.TabIndex = 130;
            this.labelControl1.Text = "Số giờ";
            // 
            // btCancel
            // 
            this.btCancel.ImageOptions.Image = global::ASPProject.Properties.Resources.close__2_;
            this.btCancel.Location = new System.Drawing.Point(336, 138);
            this.btCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(180, 61);
            this.btCancel.TabIndex = 129;
            this.btCancel.Text = "Đóng";
            // 
            // btSave
            // 
            this.btSave.ImageOptions.Image = global::ASPProject.Properties.Resources.save1;
            this.btSave.Location = new System.Drawing.Point(113, 138);
            this.btSave.Margin = new System.Windows.Forms.Padding(5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(181, 61);
            this.btSave.TabIndex = 128;
            this.btSave.Text = "Lưu";
            // 
            // lkeLosstimeID
            // 
            this.lkeLosstimeID.EditValue = "";
            this.lkeLosstimeID.Location = new System.Drawing.Point(173, 32);
            this.lkeLosstimeID.Margin = new System.Windows.Forms.Padding(5);
            this.lkeLosstimeID.Name = "lkeLosstimeID";
            this.lkeLosstimeID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkeLosstimeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeLosstimeID.Properties.NullText = "";
            this.lkeLosstimeID.Size = new System.Drawing.Size(226, 23);
            this.lkeLosstimeID.TabIndex = 1;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.Location = new System.Drawing.Point(137, 35);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(18, 16);
            this.labelControl12.TabIndex = 125;
            this.labelControl12.Text = "(*)";
            // 
            // lbLosstimeID
            // 
            this.lbLosstimeID.Location = new System.Drawing.Point(32, 35);
            this.lbLosstimeID.Margin = new System.Windows.Forms.Padding(6);
            this.lbLosstimeID.Name = "lbLosstimeID";
            this.lbLosstimeID.Size = new System.Drawing.Size(71, 16);
            this.lbLosstimeID.TabIndex = 126;
            this.lbLosstimeID.Text = "Mã Losstime";
            // 
            // frmPSDetailLosstimeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 239);
            this.Controls.Add(this.txtLosstimeNum);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lkeLosstimeID);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.lbLosstimeID);
            this.Name = "frmPSDetailLosstimeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPSDetailLosstimeEdit";
            ((System.ComponentModel.ISupportInitialize)(this.txtLosstimeNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeLosstimeID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtLosstimeNum;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.LookUpEdit lkeLosstimeID;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lbLosstimeID;
    }
}