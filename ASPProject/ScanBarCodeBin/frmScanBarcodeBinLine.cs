using ASPData;
using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.ScanBarCodeBin
{
    public partial class frmScanBarcodeBinLine : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtSB = new DataTable();
        DataTable dtSB2 = new DataTable();

        DataTable dtSB_F = new DataTable();
        DataTable dtSB2_F = new DataTable();

        BindingSource bdsSB = new BindingSource();
        BindingSource bdsSB2 = new BindingSource();

        BindingSource bdsSB_F = new BindingSource();
        BindingSource bdsSB2_F = new BindingSource();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;

        ProdStatisticDAO prodStatisticDAO = new ProdStatisticDAO();
        ProdStatisticDTO prodStatisticDTO = new ProdStatisticDTO();
        PSScanBarcodeBin psScanBin = new PSScanBarcodeBin();
        ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private GridControl lastFocusedGridControl = null;
        public frmScanBarcodeBinLine()
        {
            InitializeComponent();

            this.Load += FrmScanBarcodeBinLine_Load;
            this.btInput.Click += BtInput_Click;
            this.btCopy1.Click += BtCopy1_Click;
            this.btExcel1.Click += BtExcel1_Click;
            this.btTrans1.Click += BtTrans1_Click;
            this.btFilter.Click += BtFilter_Click;
            this.btDelete.Click += BtDelete_Click;
            gridScanBarcodeBinLine.GotFocus += (s, e) => lastFocusedGridControl = gridScanBarcodeBinLine;
            gridScanBarcodeBinLineV2.GotFocus += (s, e) => lastFocusedGridControl = gridScanBarcodeBinLineV2;

            this.gridScanBarcodeBinLineView.RowStyle += GridScanBarcodeBinLineView_RowStyle;
            this.gridScanBarcodeBinLineV2View.RowStyle += GridScanBarcodeBinLineV2View_RowStyle;

            this.dtFromDate.EditValue = DateTime.Now;
            this.dtToDate.EditValue = DateTime.Now;
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            foreach (int row in gridScanBarcodeBinLineView.GetSelectedRows())
            {
                DataRow drow = gridScanBarcodeBinLineView.GetDataRow(row);

                var dicParams = new Dictionary<string, object>()
                {
                    { "@AutoID", (long)Convert.ToDouble(drow["AutoID"]) }
                };

                _sqlHelper.ExecProcedureNonData("sp_ASPDeleteScanBarcodeBinLine", dicParams);
            }

            foreach (int row in gridScanBarcodeBinLineV2View.GetSelectedRows())
            {
                DataRow drow = gridScanBarcodeBinLineV2View.GetDataRow(row);

                var dicParams = new Dictionary<string, object>()
                {
                    { "@AutoID", (long)Convert.ToDouble(drow["AutoID"]) }
                };

                _sqlHelper.ExecProcedureNonData("sp_ASPDeleteScanBarcodeBinLine", dicParams);
            }

            XtraMessageBox.Show("Đã xoá thành công");
        }

        private void BtFilter_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void BtExcel1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int row = 0; row <= gridScanBarcodeBinLineView.GetSelectedRows().Length - 1; row++)
            {
                DataRow drow = gridScanBarcodeBinLineView.GetDataRow(row);

                if (drow == null)
                    continue;

                var dicParams = new Dictionary<string, object>()
                {
                    { "@AutoID", (long)Convert.ToDouble(drow["AutoID"]) },
                    { "@Type", 1 }
                };

                DataTable dtTemp = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPPSPrintBinLabel", dicParams);

                if (dtTemp.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 0)
                        dt = dtTemp.Clone();

                    dt.ImportRow(dtTemp.Rows[0]);
                }

                psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                psScanBin.ItemNo = Convert.ToString(drow["ItemNo"]);
                psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                psScanBin.NW = Convert.ToDouble(drow["NW"]);
                psScanBin.GW = Convert.ToDouble(drow["GW"]);
                psScanBin.CartNo = Convert.ToString(drow["CartNo"]);
                psScanBin.LotNo = Convert.ToString(drow["LotNo"]);
                psScanBin.WO = Convert.ToString(drow["WO"]);
                psScanBin.Cable = Convert.ToString(drow["Cable"]);
                psScanBin.BinSize = Convert.ToString(drow["BinSize"]);
                psScanBin.ULStamp = Convert.ToString(drow["ULStamp"]);
                psScanBin.UL2Stamp = Convert.ToString(drow["UL2Stamp"]);
                psScanBin.SBDate = Convert.ToString(drow["SBDate"]);
                psScanBin.CreatedBy = userName;
                psScanBin.CreatedDate = DateTime.Now;
                psScanBin.LastModifiedBy = userName;
                psScanBin.LastModifiedDate = DateTime.Now;
                psScanBin.AutoID = (long)Convert.ToDouble(drow["AutoID"]);
                psScanBin.IntType = 1;

                prodStatisticDAO.TransScanBarcodeBinLine(psScanBin);

                //transfer sang du lieu QC duyet
                int[] selectrowsHandle = gridScanBarcodeBinLineView.GetSelectedRows();

                if (selectrowsHandle.Length > 0)
                {
                    int intFirstRow = selectrowsHandle[0];

                    if (intFirstRow >= 0)
                    {
                        DataRow firstRow = gridScanBarcodeBinLineView.GetDataRow(intFirstRow);

                        string partNo = Convert.ToString(drow["PartNo"]);
                        string itemNo = Convert.ToString(drow["ItemNo"]);

                        dicParams = new Dictionary<string, object>()
                        {
                            { "@PartNo", drow["PartNo"] },
                            { "@ItemNo", drow["ItemNo"] }
                        };

                        DataTable dtOriginalBin = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPScanBarcodeBin WHERE PartNo = @PartNo AND ItemNo = @ItemNo", dicParams);

                        DataRow drOriginal = null;

                        if (dtOriginalBin.Rows.Count > 0)
                            drOriginal = dtOriginalBin.Rows[0];

                        if (firstRow != null && drOriginal != null)
                        {
                            //xu ly insert
                            psScanBin.WO = Convert.ToString(drow["WO"]).Replace("W.O: ", string.Empty);
                            dicParams = new Dictionary<string, object>()
                            {
                                { "@WODocNo", psScanBin.WO }
                            };
                            DataTable dtLine = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM L14CTLSXASP WHERE So_Ct = @WODocNo", dicParams);
                            psScanBin.PrintDate = DateTime.Now;
                            psScanBin.Line = dtLine.Rows.Count > 0 ? (string)dtLine.Rows[0]["Ma_Day_Chuyen"] : string.Empty;
                            psScanBin.ProductIDVN = (string)drow["ItemNo"];
                            psScanBin.Customer = string.Empty;
                            psScanBin.QRCodeVerify = string.Empty;
                            psScanBin.QRCodeData = string.Empty;
                            psScanBin.CustomerVerify = string.Empty;
                            psScanBin.ULStamp = (string)drow["ULStamp"];
                            psScanBin.QCVerify = false;
                            psScanBin.QCVerify_Log = string.Empty;
                            psScanBin.PrintUser = userName;
                            psScanBin.FirstBinQuantity = 0;
                            psScanBin.LastBinQuantity = 0;
                            psScanBin.SumQuantity = Convert.ToDouble(drow["Quantity"]);
                            psScanBin.LinkQQuantityPerBin = 0;
                            psScanBin.BinSize = string.Empty;//Convert.ToString(firstRow["BinSize"]);
                            psScanBin.N5 = Convert.ToDouble(drOriginal["N-5"]);
                            psScanBin.N25 = Convert.ToDouble(drOriginal["N-25"]);
                            psScanBin.N100 = Convert.ToDouble(drOriginal["N-100"]);
                            psScanBin.N250 = Convert.ToDouble(drOriginal["N-250"]);
                            psScanBin.N500 = Convert.ToDouble(drOriginal["N-500"]);
                            psScanBin.N1_25 = Convert.ToDouble(drOriginal["1-N-25"]);
                            psScanBin.N1_100 = Convert.ToDouble(drOriginal["1-N-100"]);
                            psScanBin.N1_250 = Convert.ToDouble(drOriginal["1-N-250"]);
                            psScanBin.N1_500 = Convert.ToDouble(drOriginal["1-N-500"]);
                            psScanBin.N5_Line = 0;
                            psScanBin.N25_Line = 0;
                            psScanBin.N100_Line = 0;
                            psScanBin.N250_Line = 0;
                            psScanBin.N500_Line = 0;
                            psScanBin.N1_25_Line = 0;
                            psScanBin.N1_100_Line = 0;
                            psScanBin.N1_250_Line = 0;
                            psScanBin.N1_500_Line = 0;
                            psScanBin.CreatedBy = userName;
                            psScanBin.CreatedDate = DateTime.Now;
                            psScanBin.LastModifiedBy = userName;
                            psScanBin.LastModifiedDate = DateTime.Now;

                            prodStatisticDAO.TransScanBinQCApproval(psScanBin);
                        }
                    }
                }

            }

            ExportExcel(dt, "DailyLineLabelReport", 0);

            DataTable dt2 = new DataTable();
            foreach (int row in gridScanBarcodeBinLineV2View.GetSelectedRows())
            {
                DataRow drow = gridScanBarcodeBinLineV2View.GetDataRow(row);

                if (drow == null)
                    continue;

                var dicParams = new Dictionary<string, object>()
                {
                    { "@AutoID", (long)Convert.ToDouble(drow["AutoID"]) },
                    { "@Type", 2 }
                };

                DataTable dtTemp = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPPSPrintBinLabel", dicParams);

                if (dtTemp.Rows.Count > 0)
                {
                    if (dt2.Rows.Count == 0)
                        dt2 = dtTemp.Clone();

                    dt2.ImportRow(dtTemp.Rows[0]);
                }

                psScanBin.CusID = Convert.ToString(drow["CusID"]);
                psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                psScanBin.BinQuantity = Convert.ToString(drow["BinQuantity"]);
                psScanBin.BinQuantitySum = Convert.ToString(drow["BinQuantitySum"]);
                psScanBin.ShipDate = Convert.ToString(drow["ShipDate"]);
                psScanBin.Rev = Convert.ToString(drow["Rev"]);
                psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                psScanBin.WO = Convert.ToString(drow["WO"]);
                psScanBin.PkgGwt = Convert.ToString(drow["PkgGwt"]);
                psScanBin.Desc = Convert.ToString(drow["Desc"]);
                psScanBin.MadeInVN = Convert.ToString(drow["MadeInVN"]);
                psScanBin.CreatedBy = userName;
                psScanBin.CreatedDate = DateTime.Now;
                psScanBin.LastModifiedBy = userName;
                psScanBin.LastModifiedDate = DateTime.Now;
                psScanBin.AutoID = (long)Convert.ToDouble(drow["AutoID"]);
                psScanBin.IntType = 1;

                prodStatisticDAO.TransScanBarcodeBinLineV2(psScanBin);

                //transfer sang du lieu QC duyet
                int[] selectrowsHandle = gridScanBarcodeBinLineV2View.GetSelectedRows();

                if (selectrowsHandle.Length > 0)
                {
                    int intFirstRow = selectrowsHandle[0];

                    if (intFirstRow >= 0)
                    {
                        DataRow firstRow = gridScanBarcodeBinLineV2View.GetDataRow(intFirstRow);

                        //string partNo = Convert.ToString(firstRow["PartNo"]);
                        //string itemNo = Convert.ToString(firstRow["ItemNo"]);

                        dicParams = new Dictionary<string, object>()
                        {
                            { "@CusID", drow["CusID"] }
                        };

                        DataTable dtOriginalBin = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPScanBarcodeBinV2 WHERE CusID = @CusID", dicParams);

                        DataRow drOriginal = null;

                        if (dtOriginalBin.Rows.Count > 0)
                            drOriginal = dtOriginalBin.Rows[0];

                        if (firstRow != null && drOriginal != null)
                        {
                            //xu ly insert
                            psScanBin.WO = Convert.ToString(drow["WO"]).Replace("WO: ", string.Empty);
                            dicParams = new Dictionary<string, object>()
                            {
                                { "@WODocNo", psScanBin.WO.Trim() }
                            };
                            DataTable dtLine = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM L14CTLSXASP WHERE So_Ct = @WODocNo", dicParams);
                            psScanBin.PrintDate = DateTime.Now;
                            psScanBin.Line = dtLine.Rows.Count > 0 ? (string)dtLine.Rows[0]["Ma_Day_Chuyen"] : string.Empty;
                            psScanBin.ProductIDVN = (string)drow["PartNo"];
                            psScanBin.Customer = string.Empty;
                            psScanBin.QRCodeVerify = string.Empty;
                            psScanBin.QRCodeData = string.Empty;
                            psScanBin.CustomerVerify = string.Empty;
                            psScanBin.ULStamp = string.Empty;
                            psScanBin.QCVerify = false;
                            psScanBin.QCVerify_Log = string.Empty;
                            psScanBin.PrintUser = userName;
                            psScanBin.FirstBinQuantity = 0;
                            psScanBin.LastBinQuantity = 0;
                            psScanBin.SumQuantity = Convert.ToDouble(drOriginal["Quantity"].ToString().Replace("pcs", string.Empty));
                            psScanBin.LinkQQuantityPerBin = 0;
                            psScanBin.BinSize = string.Empty;//Convert.ToString(firstRow["BinSize"]);
                            psScanBin.N5 = Convert.ToDouble(drOriginal["N-5"]);
                            psScanBin.N25 = Convert.ToDouble(drOriginal["N-25"]);
                            psScanBin.N100 = Convert.ToDouble(drOriginal["N-100"]);
                            psScanBin.N250 = Convert.ToDouble(drOriginal["N-250"]);
                            psScanBin.N500 = Convert.ToDouble(drOriginal["N-500"]);
                            psScanBin.N1_25 = Convert.ToDouble(drOriginal["1-N-25"]);
                            psScanBin.N1_100 = Convert.ToDouble(drOriginal["1-N-100"]);
                            psScanBin.N1_250 = Convert.ToDouble(drOriginal["1-N-250"]);
                            psScanBin.N1_500 = Convert.ToDouble(drOriginal["1-N-500"]);
                            psScanBin.N5_Line = 0;
                            psScanBin.N25_Line = 0;
                            psScanBin.N100_Line = 0;
                            psScanBin.N250_Line = 0;
                            psScanBin.N500_Line = 0;
                            psScanBin.N1_25_Line = 0;
                            psScanBin.N1_100_Line = 0;
                            psScanBin.N1_250_Line = 0;
                            psScanBin.N1_500_Line = 0;
                            psScanBin.CreatedBy = userName;
                            psScanBin.CreatedDate = DateTime.Now;
                            psScanBin.LastModifiedBy = userName;
                            psScanBin.LastModifiedDate = DateTime.Now;

                            prodStatisticDAO.TransScanBinQCApproval(psScanBin);
                        }
                    }
                }
            }

            ExportExcel(dt2, "DailyLineLabelReport2", 1);

            FillData();
            XtraMessageBox.Show("Đã xuất Excel thành công!");
        }

        private void BtTrans1_Click(object sender, EventArgs e)
        {

            foreach (int row in gridScanBarcodeBinLine_FView.GetSelectedRows())
            {
                DataRow drow = gridScanBarcodeBinLine_FView.GetDataRow(row);

                if (drow == null)
                    continue;

                psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                psScanBin.ItemNo = Convert.ToString(drow["ItemNo"]);
                psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                psScanBin.NW = Convert.ToDouble(drow["NW"]);
                psScanBin.GW = Convert.ToDouble(drow["GW"]);
                psScanBin.CartNo = Convert.ToString(drow["CartNo"]);
                psScanBin.LotNo = Convert.ToString(drow["LotNo"]);
                psScanBin.WO = Convert.ToString(drow["WO"]);
                psScanBin.Cable = Convert.ToString(drow["Cable"]);
                psScanBin.BinSize = Convert.ToString(drow["BinSize"]);
                psScanBin.ULStamp = Convert.ToString(drow["ULStamp"]);
                psScanBin.UL2Stamp = Convert.ToString(drow["UL2Stamp"]);
                psScanBin.SBDate = Convert.ToString(drow["SBDate"]);
                psScanBin.CreatedBy = userName;
                psScanBin.CreatedDate = DateTime.Now;
                psScanBin.LastModifiedBy = userName;
                psScanBin.LastModifiedDate = DateTime.Now;
                psScanBin.AutoID = (long)Convert.ToDouble(drow["AutoID"]);
                psScanBin.IntType = 2;

                prodStatisticDAO.TransScanBarcodeBinLine(psScanBin);
            }

            foreach (int row in gridScanBarcodeBinLineV2_FView.GetSelectedRows())
            {
                DataRow drow = gridScanBarcodeBinLineV2_FView.GetDataRow(row);

                if (drow == null)
                    continue;

                psScanBin.CusID = Convert.ToString(drow["CusID"]);
                psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                psScanBin.BinQuantity = Convert.ToString(drow["BinQuantity"]);
                psScanBin.BinQuantitySum = Convert.ToString(drow["BinQuantitySum"]);
                psScanBin.ShipDate = Convert.ToString(drow["ShipDate"]);
                psScanBin.Rev = Convert.ToString(drow["Rev"]);
                psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                psScanBin.WO = Convert.ToString(drow["WO"]);
                psScanBin.PkgGwt = Convert.ToString(drow["PkgGwt"]);
                psScanBin.Desc = Convert.ToString(drow["Desc"]);
                psScanBin.MadeInVN = Convert.ToString(drow["MadeInVN"]);
                psScanBin.CreatedBy = userName;
                psScanBin.CreatedDate = DateTime.Now;
                psScanBin.LastModifiedBy = userName;
                psScanBin.LastModifiedDate = DateTime.Now;
                psScanBin.AutoID = (long)Convert.ToDouble(drow["AutoID"]);
                psScanBin.IntType = 2;

                prodStatisticDAO.TransScanBarcodeBinLineV2(psScanBin);
            }

            FillData();
            XtraMessageBox.Show("Đã chuyển thành công!");
        }

        private void GridScanBarcodeBinLineV2View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isOriginal = Convert.ToBoolean(gridScanBarcodeBinLineV2View.GetRowCellValue(e.RowHandle, "IsOriginal"));

            if (isOriginal)
            {
                e.Appearance.ForeColor = Color.Orange;
            }
        }

        private void GridScanBarcodeBinLineView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isOriginal = Convert.ToBoolean(gridScanBarcodeBinLineView.GetRowCellValue(e.RowHandle, "IsOriginal"));

            if (isOriginal)
            {
                e.Appearance.ForeColor = Color.Orange;
            }
        }

        private void BtCopy1_Click(object sender, EventArgs e)
        {
            var quantity = XtraInputBox.Show("Nhập số dòng cần copy", "Số lượng dòng", 1);

            if (Convert.ToInt32(quantity) == 0)
                return;

            int count = 1;

            while (count <= quantity)
            {
                foreach (int row in gridScanBarcodeBinLineView.GetSelectedRows())
                {
                    DataRow drow = gridScanBarcodeBinLineView.GetDataRow(row);

                    if (drow == null)
                        continue;

                    string iCartNo = (Convert.ToInt32(drow["CartNo"]) + count).ToString().PadLeft(3, '0');

                    psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                    psScanBin.ItemNo = Convert.ToString(drow["ItemNo"]);
                    psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                    psScanBin.NW = Convert.ToDouble(drow["NW"]);
                    psScanBin.GW = Convert.ToDouble(drow["GW"]);
                    psScanBin.CartNo = iCartNo;

                    double dbTemp = 0;

                    double.TryParse(Convert.ToString(drow["LotNo"]).Substring(Convert.ToString(drow["LotNo"]).Length - 6, 6), out dbTemp);

                    psScanBin.LotNo = dbTemp == 0 ? Convert.ToString(drow["LotNo"]).Substring(0, Convert.ToString(drow["LotNo"]).Length - 3) + iCartNo : Convert.ToString(drow["LotNo"]);
                    psScanBin.WO = Convert.ToString(drow["WO"]);
                    psScanBin.Cable = Convert.ToString(drow["Cable"]);
                    psScanBin.BinSize = Convert.ToString(drow["BinSize"]);
                    psScanBin.ULStamp = Convert.ToString(drow["ULStamp"]);
                    psScanBin.UL2Stamp = Convert.ToString(drow["UL2Stamp"]);
                    psScanBin.SBDate = Convert.ToString(drow["SBDate"]);
                    psScanBin.CreatedBy = userName;
                    psScanBin.CreatedDate = DateTime.Now;
                    psScanBin.LastModifiedBy = userName;
                    psScanBin.LastModifiedDate = DateTime.Now;

                    prodStatisticDAO.CopyScanBarcodeBinLine(psScanBin);
                }
                foreach (int row in gridScanBarcodeBinLineV2View.GetSelectedRows())
                {
                    DataRow drow = gridScanBarcodeBinLineV2View.GetDataRow(row);

                    if (drow == null)
                        continue;

                    psScanBin.CusID = Convert.ToString(drow["CusID"]);
                    psScanBin.Quantity = Convert.ToString(drow["Quantity"]);
                    psScanBin.BinQuantity = Convert.ToString(drow["BinQuantity"]).Substring(0, Convert.ToString(drow["BinQuantity"]).Length - 1) + (count + 1).ToString();
                    psScanBin.BinQuantitySum = Convert.ToString(drow["BinQuantitySum"]);
                    psScanBin.ShipDate = Convert.ToString(drow["ShipDate"]);
                    psScanBin.Rev = Convert.ToString(drow["Rev"]);
                    psScanBin.PartNo = Convert.ToString(drow["PartNo"]);
                    psScanBin.WO = Convert.ToString(drow["WO"]);
                    psScanBin.PkgGwt = Convert.ToString(drow["PkgGwt"]);
                    psScanBin.Desc = Convert.ToString(drow["Desc"]);
                    psScanBin.MadeInVN = Convert.ToString(drow["MadeInVN"]);
                    psScanBin.CreatedBy = userName;
                    psScanBin.CreatedDate = DateTime.Now;
                    psScanBin.LastModifiedBy = userName;
                    psScanBin.LastModifiedDate = DateTime.Now;

                    prodStatisticDAO.CopyScanBarcodeBinLineV2(psScanBin);
                }
                count++;
            }

            FillData();

            XtraMessageBox.Show("Đã copy thành công!");

        }

        private void BtInput_Click(object sender, EventArgs e)
        {
            GridControl focusedGrid = lastFocusedGridControl; // Sử dụng giá trị đã lưu

            if (focusedGrid == gridScanBarcodeBinLine)
            {
                DataRowView row1 = (DataRowView)gridScanBarcodeBinLineView.GetFocusedRow();

                if (row1 == null)
                {
                    return;
                }
                else
                {
                    frmScanBarcodeBinEdit1 frmEdit1 = new frmScanBarcodeBinEdit1();
                    frmEdit1.type = 1;
                    frmEdit1.Quantity = Convert.ToString(row1["Quantity"]);
                    frmEdit1.NW = Convert.ToString(row1["NW"]);
                    frmEdit1.GW = Convert.ToString(row1["GW"]);
                    frmEdit1.LotNo = Convert.ToString(row1["LotNo"]);
                    frmEdit1.WO = Convert.ToString(row1["WO"]);
                    frmEdit1.SBDate = Convert.ToString(row1["SBDate"]);
                    frmEdit1.BinSize = Convert.ToString(row1["BinSize"]);
                    frmEdit1.AutoID = (long)Convert.ToDouble(row1["AutoID"]);

                    // Thêm event handler cho FormClosed
                    frmEdit1.FormClosed += (s, args) =>
                    {
                        if (frmEdit1.isAccept) // Chỉ fill data nếu người dùng chấp nhận thay đổi
                        {
                            FillData();
                        }
                    };

                    frmEdit1.Show();
                }
            }

            if (focusedGrid == gridScanBarcodeBinLineV2)
            {
                DataRowView row2 = (DataRowView)gridScanBarcodeBinLineV2View.GetFocusedRow();

                if (row2 == null)
                {
                    return;
                }
                else
                {
                    frmScanBarcodeBinEdit2 frmEdit2 = new frmScanBarcodeBinEdit2();
                    frmEdit2.type = 1;
                    frmEdit2.Quantity = Convert.ToString(row2["Quantity"]);
                    frmEdit2.BinQuantity = Convert.ToString(row2["BinQuantity"]);
                    frmEdit2.BinQuantitySum = Convert.ToString(row2["BinQuantitySum"]);
                    frmEdit2.ShipDate = Convert.ToString(row2["ShipDate"]);
                    frmEdit2.WO = Convert.ToString(row2["WO"]);
                    frmEdit2.PkgGwt = Convert.ToString(row2["PkgGwt"]);
                    frmEdit2.AutoID = (long)Convert.ToDouble(row2["AutoID"]);

                    // Thêm event handler cho FormClosed
                    frmEdit2.FormClosed += (s, args) =>
                    {
                        if (frmEdit2.isAccept) // Chỉ fill data nếu người dùng chấp nhận thay đổi
                        {
                            FillData();
                        }
                    };

                    frmEdit2.Show();
                }
            }
        }

        private void FrmScanBarcodeBinLine_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void ExportExcel(DataTable dtExcel, string PSReportID, int numTime)
        {

            DataTable dtTemplate = new DataTable();
            dtTemplate = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPPSReport WHERE PSReportID = '" + PSReportID + "'");

            for (int i = 0; i < dtTemplate.Rows.Count; i++)
            {
                string sqlProc = Convert.ToString(dtTemplate.Rows[i]["PSReportProc"]);
                string excelSheet = Convert.ToString(dtTemplate.Rows[i]["PSReportSheet"]);
                string excelRange = Convert.ToString(dtTemplate.Rows[i]["PSReportRange"]);
                string[] arrRange = excelRange.Split(',');
                string fileTemplate = Application.StartupPath + "\\" + Convert.ToString(dtTemplate.Rows[i]["PSTemplatePath"]);
                string localPath = Convert.ToString(dtTemplate.Rows[i]["FileTemplate"]);
                string resultFilename = Convert.ToString(dtTemplate.Rows[i]["PSResultName"]);
                string resultTemplate = @"\\" + Convert.ToString(dtTemplate.Rows[i]["PSResultPath"]) + "\\" + resultFilename + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx";
                string networkPath = Convert.ToString(dtTemplate.Rows[i]["PSNetworkPath"]);

                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsImpersonationContext context = identity.Impersonate();

                string myNetworkPath = networkPath + PSReportID + ".xlsx";
                string myLocalPath = localPath + Convert.ToString(dtTemplate.Rows[i]["FileNameOutput"]) + ".xlsx";

                using (context)
                {
                    if (arrRange.Length > 0)
                    {
                        for (int j = 0; j <= arrRange.Length - 1; j++)
                        {
                            if (!File.Exists(myLocalPath))
                            {
                                if (numTime == 0)
                                {
                                    excel.WriteDataIntoExcelFile(dtExcel, fileTemplate, excelSheet, arrRange[j], myLocalPath);
                                }
                                else
                                {
                                    excel.WriteDataIntoExcelFile(dtExcel, myLocalPath, excelSheet, arrRange[j], myLocalPath);
                                }
                            }

                            else
                            {
                                if (numTime == 0)
                                {
                                    File.Delete(myLocalPath);
                                    excel.WriteDataIntoExcelFile(dtExcel, fileTemplate, excelSheet, arrRange[j], myLocalPath);
                                }
                                else
                                {
                                    excel.WriteDataIntoExcelFile(dtExcel, myLocalPath, excelSheet, arrRange[j], myLocalPath);
                                }
                            }
                        }
                    }
                }

            }
        }

        private void FillData()
        {
            DataSet ds = new DataSet();

            prodStatisticDTO.FromDate = Convert.ToDateTime(dtFromDate.EditValue).Date;
            prodStatisticDTO.ToDate = Convert.ToDateTime(dtToDate.EditValue).Date;

            ds = prodStatisticDAO.GetScanBarcodeBinLine(prodStatisticDTO);

            if (ds.Tables.Count > 0)
            {
                dtSB = ds.Tables[0];
                bdsSB.DataSource = dtSB;
                gridScanBarcodeBinLine.DataSource = bdsSB;
            }

            if (ds.Tables.Count > 1)
            {
                dtSB2 = ds.Tables[1];
                bdsSB2.DataSource = dtSB2;
                gridScanBarcodeBinLineV2.DataSource = bdsSB2;
            }

            ds = prodStatisticDAO.GetScanBarcodeBinLineFinish(prodStatisticDTO);

            if (ds.Tables.Count > 0)
            {
                dtSB_F = ds.Tables[0];
                bdsSB_F.DataSource = dtSB_F;
                gridScanBarcodeBinLine_F.DataSource = bdsSB_F;
            }

            if (ds.Tables.Count > 1)
            {
                dtSB2_F = ds.Tables[1];
                bdsSB2_F.DataSource = dtSB2_F;
                gridScanBarcodeBinLineV2_F.DataSource = bdsSB2_F;
            }
        }
    }
}
