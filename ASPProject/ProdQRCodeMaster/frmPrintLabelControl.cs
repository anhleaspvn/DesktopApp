using ASPData;
using ASPData.ASPDAO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmPrintLabelControl : XtraForm
    {
        public frmMain frm;
        public int iNgonNgu;
        public string userName;

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtData = new DataTable();
        private DevExpress.XtraGrid.Columns.GridColumn colDetSTT;

        // Dynamic UI controls for OQC Detail tab
        private DevExpress.XtraTab.XtraTabControl tabControlDetail;
        private DevExpress.XtraTab.XtraTabPage tabPageLabel;
        private DevExpress.XtraTab.XtraTabPage tabPageOQC;
        private DevExpress.XtraGrid.GridControl gridControlOQC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOQC;
        private DevExpress.XtraGrid.Columns.GridColumn colOqcSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colOqcSerialCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOqcCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOqcCreatedBy;

        // Controls for print label detail Excel export
        private DevExpress.XtraEditors.SimpleButton btExportExcelDetail;
        private ToolStripMenuItem menuExportExcelDetail;

        private DevExpress.XtraGrid.Columns.GridColumn colPendingQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscrepancyNote;

        public frmPrintLabelControl()
        {
            InitializeComponent();

            this.Load += FrmPrintLabelControl_Load;
            this.btFilter.Click += BtFilter_Click;
            this.btExportExcel.Click += BtExportExcel_Click;
            this.gridView1.CellValueChanged += GridView1_CellValueChanged;
            this.gridView1.RowCellStyle += GridView1_RowCellStyle;
            
            // Register master-detail focused row changed event
            this.gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            
            // Register detail grid style event
            this.gridViewDetail.RowCellStyle += GridViewDetail_RowCellStyle;
        }

        private void FrmPrintLabelControl_Load(object sender, EventArgs e)
        {
            // Initialize Tab Control dynamically
            this.tabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabControlDetail.Dock = DockStyle.Fill;

            this.tabPageLabel = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageLabel.Text = iNgonNgu == 1 ? "Label Details" : "Chi tiết tem in";

            this.tabPageOQC = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageOQC.Text = iNgonNgu == 1 ? "OQC Scans" : "Chi tiết quét OQC";

            // Move gridControlDetail to tabPageLabel and add Excel export button
            groupControlDetail.Controls.Remove(this.gridControlDetail);
            this.tabPageLabel.Controls.Clear();

            PanelControl pnlDetailHeader = new PanelControl();
            pnlDetailHeader.Dock = DockStyle.Top;
            pnlDetailHeader.Height = 40;
            pnlDetailHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            this.btExportExcelDetail = new SimpleButton();
            this.btExportExcelDetail.Text = iNgonNgu == 1 ? "Export Excel" : "Xuất Excel";
            this.btExportExcelDetail.Location = new Point(5, 6);
            this.btExportExcelDetail.Size = new Size(110, 28);
            this.btExportExcelDetail.Click += BtExportExcelDetail_Click;

            pnlDetailHeader.Controls.Add(this.btExportExcelDetail);

            // Context Menu for gridControlDetail
            ContextMenuStrip contextMenuDetail = new ContextMenuStrip();
            this.menuExportExcelDetail = new ToolStripMenuItem(iNgonNgu == 1 ? "Export Excel" : "Xuất Excel");
            this.menuExportExcelDetail.Click += BtExportExcelDetail_Click;
            contextMenuDetail.Items.Add(this.menuExportExcelDetail);
            this.gridControlDetail.ContextMenuStrip = contextMenuDetail;

            this.tabPageLabel.Controls.Add(this.gridControlDetail);
            this.tabPageLabel.Controls.Add(pnlDetailHeader);
            pnlDetailHeader.SendToBack();
            this.gridControlDetail.BringToFront();
            this.gridControlDetail.Dock = DockStyle.Fill;

            // Initialize gridControlOQC
            this.gridControlOQC = new DevExpress.XtraGrid.GridControl();
            this.gridViewOQC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlOQC.MainView = this.gridViewOQC;
            this.gridControlOQC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewOQC });
            this.gridControlOQC.Dock = DockStyle.Fill;
            this.gridViewOQC.GridControl = this.gridControlOQC;
            this.gridViewOQC.Name = "gridViewOQC";
            this.gridViewOQC.OptionsBehavior.Editable = false;
            this.gridViewOQC.OptionsView.ShowAutoFilterRow = true;
            this.gridViewOQC.OptionsView.ShowGroupPanel = false;

            // Setup columns for gridViewOQC
            this.colOqcSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOqcSTT.Caption = iNgonNgu == 1 ? "No." : "STT";
            this.colOqcSTT.FieldName = "STT";
            this.colOqcSTT.Name = "colOqcSTT";
            this.colOqcSTT.Visible = true;
            this.colOqcSTT.VisibleIndex = 0;
            this.colOqcSTT.Width = 50;
            this.colOqcSTT.OptionsColumn.AllowEdit = false;

            this.colOqcSerialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOqcSerialCode.Caption = iNgonNgu == 1 ? "Serial Code" : "Mã tem (OQC Scan)";
            this.colOqcSerialCode.FieldName = "SerialCode";
            this.colOqcSerialCode.Name = "colOqcSerialCode";
            this.colOqcSerialCode.Visible = true;
            this.colOqcSerialCode.VisibleIndex = 1;
            this.colOqcSerialCode.Width = 250;
            this.colOqcSerialCode.OptionsColumn.AllowEdit = false;

            this.colOqcCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOqcCreatedDate.Caption = iNgonNgu == 1 ? "Scan Time" : "Thời gian quét";
            this.colOqcCreatedDate.FieldName = "CreatedDate";
            this.colOqcCreatedDate.Name = "colOqcCreatedDate";
            this.colOqcCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOqcCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colOqcCreatedDate.Visible = true;
            this.colOqcCreatedDate.VisibleIndex = 2;
            this.colOqcCreatedDate.Width = 200;
            this.colOqcCreatedDate.OptionsColumn.AllowEdit = false;

            this.colOqcCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOqcCreatedBy.Caption = iNgonNgu == 1 ? "Scanner" : "Người quét";
            this.colOqcCreatedBy.FieldName = "CreatedBy";
            this.colOqcCreatedBy.Name = "colOqcCreatedBy";
            this.colOqcCreatedBy.Visible = true;
            this.colOqcCreatedBy.VisibleIndex = 3;
            this.colOqcCreatedBy.Width = 150;
            this.colOqcCreatedBy.OptionsColumn.AllowEdit = false;

            this.gridViewOQC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colOqcSTT,
                this.colOqcSerialCode,
                this.colOqcCreatedDate,
                this.colOqcCreatedBy
            });

            this.tabPageOQC.Controls.Add(this.gridControlOQC);
            this.tabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tabPageLabel,
                this.tabPageOQC
            });
            groupControlDetail.Controls.Add(this.tabControlDetail);

            // Initialize colDetSTT dynamically
            this.colDetSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetSTT.Caption = "STT";
            this.colDetSTT.FieldName = "STT";
            this.colDetSTT.Name = "colDetSTT";
            this.colDetSTT.Visible = true;
            this.colDetSTT.VisibleIndex = 0;
            this.colDetSTT.Width = 50;
            this.colDetSTT.OptionsColumn.AllowEdit = false;
            this.gridViewDetail.Columns.Add(this.colDetSTT);

            // Run database migration check to add PendingQty and DiscrepancyNote columns if not exists
            try
            {
                _sqlHelper.ExecQueryNonData("IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ASPPrintLabelControl' AND COLUMN_NAME = 'PendingQty') BEGIN ALTER TABLE ASPPrintLabelControl ADD PendingQty INT NULL END");
            }
            catch { }
            try
            {
                _sqlHelper.ExecQueryNonData("IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ASPPrintLabelControl' AND COLUMN_NAME = 'DiscrepancyNote') BEGIN ALTER TABLE ASPPrintLabelControl ADD DiscrepancyNote NVARCHAR(500) NULL END");
            }
            catch { }

            // Initialize colPendingQty dynamically
            this.colPendingQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendingQty.Caption = iNgonNgu == 1 ? "Pending Qty" : "Số lượng chờ xác nhận";
            this.colPendingQty.FieldName = "PendingQty";
            this.colPendingQty.Name = "colPendingQty";
            this.colPendingQty.Visible = true;
            this.colPendingQty.VisibleIndex = 8;
            this.colPendingQty.Width = 140;
            this.colPendingQty.OptionsColumn.AllowEdit = true;
            this.gridView1.Columns.Add(this.colPendingQty);

            // Initialize colDiscrepancyNote dynamically
            this.colDiscrepancyNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscrepancyNote.Caption = iNgonNgu == 1 ? "Discrepancy Note" : "Ghi chú lý do chênh lệch";
            this.colDiscrepancyNote.FieldName = "DiscrepancyNote";
            this.colDiscrepancyNote.Name = "colDiscrepancyNote";
            this.colDiscrepancyNote.Visible = true;
            this.colDiscrepancyNote.VisibleIndex = 10;
            this.colDiscrepancyNote.Width = 200;
            this.colDiscrepancyNote.OptionsColumn.AllowEdit = true;
            this.gridView1.Columns.Add(this.colDiscrepancyNote);

            // Enable footer for gridView1
            this.gridView1.OptionsView.ShowFooter = true;
            
            // Add sum summaries for quantity columns
            this.colPassQty.Summary.Clear();
            this.colPassQty.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PassQty", "{0:N0}"));
            
            this.colNGQty.Summary.Clear();
            this.colNGQty.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NGQty", "{0:N0}"));
            
            this.colSystemQty.Summary.Clear();
            this.colSystemQty.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SystemQty", "{0:N0}"));
            
            this.colPrintedQty.Summary.Clear();
            this.colPrintedQty.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PrintedQty", "{0:N0}"));

            this.colPendingQty.Summary.Clear();
            this.colPendingQty.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PendingQty", "{0:N0}"));
            
            this.colDiscrepancy.Summary.Clear();
            this.colDiscrepancy.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Discrepancy", "{0:N0}"));

            this.gridView1.OptionsBehavior.Editable = true;
            this.colPrintedQty.OptionsColumn.AllowEdit = false;
            this.colPrintedQty.Caption = "Số lượng OQC";

            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;

            // Localize text controls if language is set to English (iNgonNgu == 1)
            if (iNgonNgu == 1)
            {
                this.Text = "Print Label Control";
                labelControl1.Text = "From Date";
                labelControl2.Text = "To Date";
                labelControl3.Text = "W.O";
                labelControl4.Text = "Product ID";
                labelControl5.Text = "BOX";
                btFilter.Text = "Filter";
                btExportExcel.Text = "Export Excel";

                colDocDate.Caption = "Date";
                colWODocNo.Caption = "Work Order";
                colProductID.Caption = "Product ID";
                colBoxID.Caption = "BOX ID";
                colPassQty.Caption = "Pass Qty";
                colNGQty.Caption = "NG Qty";
                colSystemQty.Caption = "System Qty";
                colPrintedQty.Caption = "OQC Qty";
                colPendingQty.Caption = "Pending Qty";
                colDiscrepancy.Caption = "Discrepancy";
                colDiscrepancyNote.Caption = "Discrepancy Note";
                colStatus.Caption = "Status";

                // Localize detail panel
                groupControlDetail.Text = "Printed label details for selected row";
                this.colDetSTT.Caption = "No.";
                colDetSerialCode.Caption = "Serial Code";
                colDetLabelType.Caption = "Label Type";
                colDetBoxID.Caption = "BOX ID";
                colDetCreatedDate.Caption = "Scan Time";
                colDetNGDescription.Caption = "NG Description";

                if (this.btExportExcelDetail != null)
                    this.btExportExcelDetail.Text = "Export Excel";
                if (this.menuExportExcelDetail != null)
                    this.menuExportExcelDetail.Text = "Export Excel";
            }

            LoadData();
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string sqlQuery = @"
                    WITH UniqueTraceabilityPass AS (
                        SELECT 
                            DocDate,
                            WODocNo,
                            ProductID,
                            BoxID,
                            SerialCode
                        FROM (
                            SELECT 
                                CAST(CreatedDate AS DATE) as DocDate,
                                WODocNo,
                                ProductID,
                                BoxID,
                                SerialCode,
                                ROW_NUMBER() OVER (PARTITION BY WODocNo, SerialCode ORDER BY CreatedDate ASC) as rn
                            FROM vw_TraceabilityRawData
                            WHERE TRIM(Result) = 'PASS'
                        ) t
                        WHERE t.rn = 1
                    ),
                    UniqueNG AS (
                        SELECT 
                            HeaderID,
                            SerialCode,
                            NGDescription
                        FROM (
                            SELECT 
                                HeaderID,
                                SerialCode,
                                NGDescription,
                                ROW_NUMBER() OVER (PARTITION BY HeaderID, SerialCode ORDER BY AutoID ASC) as rn
                            FROM ASPPSSerialCodeNG
                        ) t
                        WHERE t.rn = 1
                    ),
                    Combined AS (
                        SELECT 
                            DocDate,
                            WODocNo,
                            ProductID,
                            BoxID,
                            SerialCode,
                            1 as PassQty,
                            0 as NGQty
                        FROM UniqueTraceabilityPass

                        UNION ALL

                        SELECT 
                            CAST(COALESCE(tr.CreatedDate, h.DocDate) AS DATE) as DocDate,
                            h.WODocNo,
                            h.ProductID,
                            COALESCE(tr.BoxID, 'No Box') as BoxID,
                            ng.SerialCode,
                            0 as PassQty,
                            1 as NGQty
                        FROM UniqueNG ng
                        JOIN ASPPSHeader h ON ng.HeaderID = h.HeaderID
                        LEFT JOIN vw_TraceabilityRawData tr ON ng.SerialCode = tr.SerialCode AND TRIM(tr.Result) = 'PASS'
                    ),
                    Aggregated AS (
                        SELECT 
                            DocDate,
                            WODocNo,
                            ProductID,
                            BoxID,
                            SUM(PassQty) as PassQty,
                            SUM(NGQty) as NGQty,
                            SUM(PassQty + NGQty) as SystemQty
                        FROM Combined
                        GROUP BY DocDate, WODocNo, ProductID, BoxID
                    ),
                    OQCScanned AS (
                        SELECT 
                            c.DocDate,
                            c.WODocNo,
                            c.ProductID,
                            c.BoxID,
                            COUNT(DISTINCT q.QRCodeData) as PrintedQty
                        FROM Combined c
                        JOIN ASPQCScanQRCodeLog q ON c.SerialCode = RIGHT(q.QRCodeData, 12) 
                                                 AND c.WODocNo = q.WODocNo
                                                 AND q.CreatedDate >= DATEADD(day, -15, @FromDate)
                                                 AND q.CreatedDate <= DATEADD(day, 15, @ToDate)
                        GROUP BY c.DocDate, c.WODocNo, c.ProductID, c.BoxID
                    )
                    SELECT 
                        a.DocDate,
                        a.WODocNo,
                        a.ProductID,
                        a.BoxID,
                        a.PassQty,
                        a.NGQty,
                        a.SystemQty,
                        COALESCE(oqc.PrintedQty, 0) as PrintedQty,
                        COALESCE(plc.PendingQty, 0) as PendingQty,
                        (a.SystemQty - COALESCE(oqc.PrintedQty, 0) - COALESCE(plc.PendingQty, 0)) as Discrepancy,
                        plc.DiscrepancyNote,
                        CASE WHEN a.SystemQty = (COALESCE(oqc.PrintedQty, 0) + COALESCE(plc.PendingQty, 0)) THEN 
                            CASE WHEN @Lang = 0 THEN N'Khớp' ELSE 'Match' END
                        ELSE 
                            CASE WHEN @Lang = 0 THEN N'Lệch' ELSE 'Mismatch' END
                        END as [Status]
                    FROM Aggregated a
                    LEFT JOIN OQCScanned oqc ON a.DocDate = oqc.DocDate 
                                           AND a.WODocNo = oqc.WODocNo 
                                           AND a.ProductID = oqc.ProductID 
                                           AND a.BoxID = oqc.BoxID
                    LEFT JOIN ASPPrintLabelControl plc ON a.DocDate = plc.DocDate 
                                                     AND a.WODocNo = plc.WODocNo 
                                                     AND a.ProductID = plc.ProductID 
                                                     AND a.BoxID = plc.BoxID
                    WHERE a.DocDate >= @FromDate AND a.DocDate <= @ToDate
                      AND (@WODocNo = '' OR a.WODocNo LIKE @WODocNo)
                      AND (@ProductID = '' OR a.ProductID LIKE @ProductID)
                      AND (@BoxID = '' OR a.BoxID LIKE @BoxID)
                    ORDER BY a.DocDate DESC, a.WODocNo, CASE WHEN a.BoxID LIKE 'BOX %' THEN COALESCE(TRY_CAST(SUBSTRING(a.BoxID, 5, LEN(a.BoxID)) AS INT), 9999) ELSE 9999 END ASC";

                DateTime fromDate = Convert.ToDateTime(dtFromDate.EditValue).Date;
                DateTime toDate = Convert.ToDateTime(dtToDate.EditValue).Date;
                string woDocNo = txtWODocNo.Text.Trim();
                string productID = txtProductID.Text.Trim();
                string boxID = txtBoxID.Text.Trim();

                var parameters = new
                {
                    FromDate = fromDate,
                    ToDate = toDate,
                    WODocNo = string.IsNullOrEmpty(woDocNo) ? "" : "%" + woDocNo + "%",
                    ProductID = string.IsNullOrEmpty(productID) ? "" : "%" + productID + "%",
                    BoxID = string.IsNullOrEmpty(boxID) ? "" : "%" + boxID + "%",
                    Lang = iNgonNgu
                };

                dtData = _sqlHelper.ExecQueryDataAsDataTable(sqlQuery, parameters);

                if (dtData.Columns.Contains("PendingQty"))
                    dtData.Columns["PendingQty"].ReadOnly = false;
                if (dtData.Columns.Contains("DiscrepancyNote"))
                    dtData.Columns["DiscrepancyNote"].ReadOnly = false;
                if (dtData.Columns.Contains("Discrepancy"))
                    dtData.Columns["Discrepancy"].ReadOnly = false;
                if (dtData.Columns.Contains("Status"))
                    dtData.Columns["Status"].ReadOnly = false;

                gridControl1.DataSource = dtData;

                // Load detail data for the newly focused/first row
                LoadDetailData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadDetailData();
        }

        private void LoadDetailData()
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                gridControlDetail.DataSource = null;
                if (gridControlOQC != null)
                    gridControlOQC.DataSource = null;
                return;
            }
 
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row == null)
            {
                gridControlDetail.DataSource = null;
                if (gridControlOQC != null)
                    gridControlOQC.DataSource = null;
                return;
            }
 
            try
            {
                DateTime docDate = Convert.ToDateTime(row["DocDate"]);
                string woDocNo = Convert.ToString(row["WODocNo"]);
                string productID = Convert.ToString(row["ProductID"]);
                string boxID = Convert.ToString(row["BoxID"]);
 
                string sqlDetail = @"
                    WITH FilteredScans AS (
                        SELECT DISTINCT RIGHT(QRCodeData, 12) as SerialCode
                        FROM ASPQCScanQRCodeLog
                        WHERE WODocNo = @WODocNo
                    ),
                    UniqueTraceabilityPass AS (
                        SELECT 
                            SerialCode,
                            BoxID,
                            CreatedDate
                        FROM (
                            SELECT 
                                SerialCode,
                                BoxID,
                                CreatedDate,
                                WODocNo,
                                ProductID,
                                ROW_NUMBER() OVER (PARTITION BY WODocNo, SerialCode ORDER BY CreatedDate ASC) as rn
                            FROM vw_TraceabilityRawData
                            WHERE TRIM(Result) = 'PASS'
                        ) t
                        WHERE t.rn = 1 
                          AND WODocNo = @WODocNo 
                          AND ProductID = @ProductID 
                          AND BoxID = @BoxID
                          AND CAST(CreatedDate AS DATE) = @DocDate
                    ),
                    UniqueNG AS (
                        SELECT 
                            HeaderID,
                            SerialCode,
                            NGDescription
                        FROM (
                            SELECT 
                                HeaderID,
                                SerialCode,
                                NGDescription,
                                ROW_NUMBER() OVER (PARTITION BY HeaderID, SerialCode ORDER BY AutoID ASC) as rn
                            FROM ASPPSSerialCodeNG
                        ) t
                        WHERE t.rn = 1
                    ),
                    Combined AS (
                        SELECT 
                            SerialCode,
                            'PASS' as [LabelType],
                            BoxID,
                            CreatedDate,
                            '' as [NGDescription]
                        FROM UniqueTraceabilityPass
 
                        UNION ALL
 
                        SELECT 
                            ng.SerialCode,
                            'NG' as [LabelType],
                            COALESCE(tr.BoxID, 'No Box') as BoxID,
                            COALESCE(tr.CreatedDate, h.DocDate) as CreatedDate,
                            ng.NGDescription
                        FROM UniqueNG ng
                        JOIN ASPPSHeader h ON ng.HeaderID = h.HeaderID
                        LEFT JOIN vw_TraceabilityRawData tr ON ng.SerialCode = tr.SerialCode AND TRIM(tr.Result) = 'PASS'
                        WHERE h.WODocNo = @WODocNo
                          AND h.ProductID = @ProductID
                          AND COALESCE(tr.BoxID, 'No Box') = @BoxID
                          AND CAST(COALESCE(tr.CreatedDate, h.DocDate) AS DATE) = @DocDate
                    )
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY c.LabelType, c.SerialCode) as STT,
                        c.SerialCode,
                        c.LabelType,
                        c.BoxID,
                        c.CreatedDate,
                        c.NGDescription,
                        CASE WHEN s.SerialCode IS NOT NULL THEN 1 ELSE 0 END as IsOQCScanned
                    FROM Combined c
                    LEFT JOIN FilteredScans s ON c.SerialCode = s.SerialCode
                    ORDER BY LabelType, SerialCode";
 
                var parameters = new
                {
                    DocDate = docDate.Date,
                    WODocNo = woDocNo,
                    ProductID = productID,
                    BoxID = boxID
                };
 
                DataTable dtDetail = _sqlHelper.ExecQueryDataAsDataTable(sqlDetail, parameters);
                gridControlDetail.DataSource = dtDetail;

                // Load Tab 2: OQC Details
                string sqlOqcDetail = @"
                    WITH BoxSerials AS (
                        SELECT SerialCode FROM (
                            SELECT 
                                SerialCode,
                                WODocNo,
                                ProductID,
                                BoxID,
                                CreatedDate,
                                ROW_NUMBER() OVER (PARTITION BY WODocNo, SerialCode ORDER BY CreatedDate ASC) as rn
                            FROM vw_TraceabilityRawData
                            WHERE TRIM(Result) = 'PASS'
                        ) t
                        WHERE t.rn = 1 
                          AND WODocNo = @WODocNo 
                          AND ProductID = @ProductID 
                          AND BoxID = @BoxID
                          AND CAST(CreatedDate AS DATE) = @DocDate

                        UNION ALL

                        SELECT ng.SerialCode 
                        FROM (
                            SELECT 
                                HeaderID,
                                SerialCode,
                                ROW_NUMBER() OVER (PARTITION BY HeaderID, SerialCode ORDER BY AutoID ASC) as rn
                            FROM ASPPSSerialCodeNG
                        ) ng
                        JOIN ASPPSHeader h ON ng.HeaderID = h.HeaderID
                        LEFT JOIN vw_TraceabilityRawData tr ON ng.SerialCode = tr.SerialCode AND TRIM(tr.Result) = 'PASS'
                        WHERE ng.rn = 1
                          AND h.WODocNo = @WODocNo
                          AND h.ProductID = @ProductID
                          AND COALESCE(tr.BoxID, 'No Box') = @BoxID
                          AND CAST(COALESCE(tr.CreatedDate, h.DocDate) AS DATE) = @DocDate
                    )
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY q.CreatedDate ASC) as STT,
                        q.QRCodeData as SerialCode,
                        q.CreatedDate,
                        q.CreatedBy
                    FROM ASPQCScanQRCodeLog q
                    JOIN BoxSerials b ON RIGHT(q.QRCodeData, 12) = b.SerialCode
                    WHERE q.WODocNo = @WODocNo
                    ORDER BY q.CreatedDate ASC";

                DataTable dtOqcDetail = _sqlHelper.ExecQueryDataAsDataTable(sqlOqcDetail, parameters);
                if (gridControlOQC != null)
                    gridControlOQC.DataSource = dtOqcDetail;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridControlDetail.DataSource = null;
                if (gridControlOQC != null)
                    gridControlOQC.DataSource = null;
            }
        }

        private void GridViewDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || e.RowHandle < 0) return;

            object isScannedVal = view.GetRowCellValue(e.RowHandle, "IsOQCScanned");
            if (isScannedVal != null && Convert.ToInt32(isScannedVal) == 0)
            {
                e.Appearance.BackColor = Color.Moccasin;
                e.Appearance.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                string labelType = view.GetRowCellValue(e.RowHandle, "LabelType")?.ToString();
                if (labelType == "NG")
                {
                    e.Appearance.BackColor = Color.MistyRose;
                    e.Appearance.ForeColor = Color.Red;
                }
                else if (labelType == "PASS")
                {
                    e.Appearance.ForeColor = Color.ForestGreen;
                }
            }
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PendingQty" || e.Column.FieldName == "DiscrepancyNote")
            {
                var view = sender as GridView;
                if (view == null) return;

                DataRow row = view.GetDataRow(e.RowHandle);
                if (row == null) return;

                try
                {
                    DateTime docDate = Convert.ToDateTime(row["DocDate"]);
                    string woDocNo = Convert.ToString(row["WODocNo"]);
                    string productID = Convert.ToString(row["ProductID"]);
                    string boxID = Convert.ToString(row["BoxID"]);
                    
                    int pendingQty = 0;
                    if (row["PendingQty"] != null && row["PendingQty"] != DBNull.Value)
                    {
                        int.TryParse(row["PendingQty"].ToString(), out pendingQty);
                    }

                    string discrepancyNote = "";
                    if (row["DiscrepancyNote"] != null && row["DiscrepancyNote"] != DBNull.Value)
                    {
                        discrepancyNote = row["DiscrepancyNote"].ToString();
                    }

                    int printedQty = Convert.ToInt32(row["PrintedQty"]);
                    int systemQty = Convert.ToInt32(row["SystemQty"]);

                    string sqlSave = @"
                        IF EXISTS (SELECT 1 FROM ASPPrintLabelControl WHERE DocDate = @DocDate AND WODocNo = @WODocNo AND ProductID = @ProductID AND BoxID = @BoxID)
                        BEGIN
                            UPDATE ASPPrintLabelControl 
                            SET PendingQty = @PendingQty, DiscrepancyNote = @DiscrepancyNote, LastModifiedBy = @Username, LastModifiedDate = GETDATE()
                            WHERE DocDate = @DocDate AND WODocNo = @WODocNo AND ProductID = @ProductID AND BoxID = @BoxID
                        END
                        ELSE
                        BEGIN
                            INSERT INTO ASPPrintLabelControl (DocDate, WODocNo, ProductID, BoxID, PendingQty, DiscrepancyNote, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
                            VALUES (@DocDate, @WODocNo, @ProductID, @BoxID, @PendingQty, @DiscrepancyNote, @Username, GETDATE(), @Username, GETDATE())
                        END";

                    var parameters = new
                    {
                        DocDate = docDate.Date,
                        WODocNo = woDocNo,
                        ProductID = productID,
                        BoxID = boxID,
                        PendingQty = pendingQty,
                        DiscrepancyNote = discrepancyNote,
                        Username = userName
                    };

                    _sqlHelper.ExecQueryNonData(sqlSave, parameters);

                    // Update UI locally for smooth user experience
                    int discrepancy = systemQty - printedQty - pendingQty;
                    row["Discrepancy"] = discrepancy;
                    row["Status"] = (discrepancy == 0) ? 
                        (iNgonNgu == 0 ? "Khớp" : "Match") : 
                        (iNgonNgu == 0 ? "Lệch" : "Mismatch");

                    view.RefreshRow(e.RowHandle);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || e.RowHandle < 0) return;

            string status = view.GetRowCellValue(e.RowHandle, "Status")?.ToString();
            if (status == "Lệch" || status == "Mismatch")
            {
                e.Appearance.BackColor = Color.MistyRose;
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void BtExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = iNgonNgu == 0 ? "Lưu tệp Excel" : "Save Excel File";
                saveFileDialog.FileName = iNgonNgu == 0 ? "KiemSoatInTem" : "PrintLabelControl";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        gridControl1.ExportToXlsx(saveFileDialog.FileName);
                        XtraMessageBox.Show(iNgonNgu == 0 ? "Xuất dữ liệu Excel thành công!" : "Exported Excel successfully!", 
                                            iNgonNgu == 0 ? "Thông báo" : "Information", 
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtExportExcelDetail_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = iNgonNgu == 0 ? "Lưu tệp Excel" : "Save Excel File";
                saveFileDialog.FileName = iNgonNgu == 0 ? "ChiTietTemIn" : "PrintLabelDetailControl";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bool oldUsePrintStyles = gridViewDetail.OptionsPrint.UsePrintStyles;
                        gridViewDetail.OptionsPrint.UsePrintStyles = false;

                        var options = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                        options.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                        options.ShowGridLines = true;

                        gridControlDetail.ExportToXlsx(saveFileDialog.FileName, options);

                        gridViewDetail.OptionsPrint.UsePrintStyles = oldUsePrintStyles;

                        XtraMessageBox.Show(iNgonNgu == 0 ? "Xuất dữ liệu Excel thành công!" : "Exported Excel successfully!", 
                                            iNgonNgu == 0 ? "Thông báo" : "Information", 
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
