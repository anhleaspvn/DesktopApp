namespace WinFormApp.Views
{
    partial class GapAlertForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDesc;
        private System.Windows.Forms.DataGridView dgvGaps;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnClose;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderDesc = new System.Windows.Forms.Label();
            this.dgvGaps = new System.Windows.Forms.DataGridView();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblStats = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGaps)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(239, 68, 68); // Soft warning red header
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Controls.Add(this.lblHeaderDesc);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1064, 75);
            this.panelHeader.TabIndex = 0;

            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(434, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "⚠️ CRITICAL COST & LEAD TIME GAPS";

            // 
            // lblHeaderDesc
            // 
            this.lblHeaderDesc.AutoSize = true;
            this.lblHeaderDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderDesc.ForeColor = System.Drawing.Color.White;
            this.lblHeaderDesc.Location = new System.Drawing.Point(16, 45);
            this.lblHeaderDesc.Name = "lblHeaderDesc";
            this.lblHeaderDesc.Size = new System.Drawing.Size(890, 21);
            this.lblHeaderDesc.TabIndex = 1;
            this.lblHeaderDesc.Text = "Review discrepancies between Cost BOM and PO data. GAPs in Lead Time (> 12 weeks), pricing gaps, and vendor sources are highlighted.";

            // 
            // dgvGaps
            // 
            this.dgvGaps.AllowUserToAddRows = false;
            this.dgvGaps.AllowUserToDeleteRows = false;
            this.dgvGaps.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvGaps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGaps.Location = new System.Drawing.Point(0, 75);
            this.dgvGaps.Name = "dgvGaps";
            this.dgvGaps.ReadOnly = true;
            this.dgvGaps.RowHeadersVisible = false;
            this.dgvGaps.RowHeadersWidth = 51;
            this.dgvGaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGaps.Size = new System.Drawing.Size(1064, 426);
            this.dgvGaps.TabIndex = 1;

            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panelFooter.Controls.Add(this.lblStats);
            this.panelFooter.Controls.Add(this.btnClose);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 501);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1064, 60);
            this.panelFooter.TabIndex = 2;

            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStats.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblStats.Location = new System.Drawing.Point(15, 18);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(222, 23);
            this.lblStats.TabIndex = 0;
            this.lblStats.Text = "Total GAPs Detected: 0 items";

            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(929, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close Dashboard";
            this.btnClose.UseVisualStyleBackColor = false;

            // 
            // GapAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(1064, 561);
            this.Controls.Add(this.dgvGaps);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GapAlertForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GAP Analysis: Lead Time & Cost BOM vs PO Pricing Alerts";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGaps)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
