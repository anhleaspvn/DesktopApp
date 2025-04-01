using ASPData;
using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.ScanBarCodeBin
{
    public partial class frmScanBarcodeBin : DevExpress.XtraEditors.XtraForm
    {
        #region declaration
        public string userName, lineID;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex, curIndexDetail;

        private BindingSource bdsScanBCBin = new BindingSource();
        private BindingSource bdsCanBCBin2 = new BindingSource();

        private DataTable dtScanBCBin = new DataTable();
        private DataTable dtScanBCBin2 = new DataTable();

        ProdStatisticDAO prodStatisticDAO = new ProdStatisticDAO();
        ProdStatisticDTO prodStatisticDTO = new ProdStatisticDTO();
        PSScanBarcodeBin psScanBin  = new PSScanBarcodeBin();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        #endregion

        #region constructor
        public frmScanBarcodeBin()
        {
            InitializeComponent();

            this.Load += FrmScanBarcodeBin_Load;
            btDelete.Click += BtDelete_Click;
            btImportExcel.Click += BtImportExcel_Click;
            btImport2.Click += BtImport2_Click;
            btTransLine.Click += BtTransLine_Click;
            btGetLinkQData.Click += BtGetLinkQData_Click;
        }

        private void BtGetLinkQData_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region load
        private void FrmScanBarcodeBin_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            DataSet ds = new DataSet();

            prodStatisticDTO.FromDate = DateTime.Now;
            prodStatisticDTO.ToDate = DateTime.Now;

            ds = prodStatisticDAO.GetScanBarcodeBin(prodStatisticDTO);

            if (ds.Tables.Count > 0)
            {
                dtScanBCBin = ds.Tables[0];
                bdsScanBCBin.DataSource = dtScanBCBin;
                gridScanBarcodeBin.DataSource = bdsScanBCBin;
            }

            if (ds.Tables.Count > 1)
            {
                dtScanBCBin2 = ds.Tables[1];
                bdsCanBCBin2.DataSource = dtScanBCBin2;
                gridScanBarcodeBinV2.DataSource = bdsCanBCBin2;
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xoá dữ liệu barcode này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                prodStatisticDTO.FromDate = DateTime.Now;
                prodStatisticDTO.ToDate = DateTime.Now;

                prodStatisticDAO.DeleteScanBarcodeBin(prodStatisticDTO);

                FillData();
            }
        }

        private void BtImport2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.Title = "Open Excel File";
            openExcel.Filter = "XLSX files|*.xlsx";
            openExcel.InitialDirectory = @"C:\";

            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //
                    List<string> arrProd = new List<string>();
                    ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();
                    DataTable dtExcel = new DataTable();
                    dtExcel = excel.ReadDataFromExcelFile(openExcel.FileName, "Sheet2", "A1:T10000");

                    foreach (DataRow dr in dtExcel.Rows)
                    {
                        string idCheck = Convert.ToString(dr["CusID"]);

                        if (!arrProd.Contains(idCheck))
                        {
                            _sqlHelper.ExecQueryNonData("DELETE FROM ASPScanBarcodeBinV2 WHERE CusID = '" + idCheck + "'");
                            arrProd.Add(Convert.ToString(dr["CusID"]));
                        }

                        psScanBin.CusID = Convert.ToString(dr["CusID"]);
                        psScanBin.Quantity = Convert.ToString(dr["Quantity"]);
                        psScanBin.BinQuantity = Convert.ToString(dr["BinQuantity"]);
                        psScanBin.BinQuantitySum = Convert.ToString(dr["BinQuantitySum"]);
                        psScanBin.ShipDate = Convert.ToString(dr["ShipDate"]);
                        psScanBin.Rev = Convert.ToString(dr["Rev"]);
                        psScanBin.PartNo = Convert.ToString(dr["PartNo"]);
                        psScanBin.WO = Convert.ToString(dr["WO"]);
                        psScanBin.PkgGwt = Convert.ToString(dr["PkgGwt"]);
                        psScanBin.Desc = Convert.ToString(dr["Desc"]);
                        psScanBin.MadeInVN = Convert.ToString(dr["MadeInVN"]);
                        psScanBin.N5 = Convert.ToDouble(dr["N-5"]);
                        psScanBin.N25 = Convert.ToDouble(dr["N-25"]);
                        psScanBin.N100 = Convert.ToDouble(dr["N-100"]);
                        psScanBin.N250 = Convert.ToDouble(dr["N-250"]);
                        psScanBin.N500 = Convert.ToDouble(dr["N-500"]);
                        psScanBin.N1_25 = Convert.ToDouble(dr["1-N-25"]);
                        psScanBin.N1_100 = Convert.ToDouble(dr["1-N-100"]);
                        psScanBin.N1_250 = Convert.ToDouble(dr["1-N-250"]);
                        psScanBin.N1_500 = Convert.ToDouble(dr["1-N-500"]);
                        psScanBin.CreatedBy = userName;
                        psScanBin.CreatedDate = DateTime.Now;
                        psScanBin.LastModifiedBy = userName;
                        psScanBin.LastModifiedDate = DateTime.Now;

                        prodStatisticDAO.ImportScanBarcodeBinV2(psScanBin);
                    }

                    XtraMessageBox.Show("Import dữ liệu thành công.");

                    FillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BtTransLine_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn chuyển dữ liệu sang cho Line nhập không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            foreach (var iRow in gridScanBarcodeBinView.GetSelectedRows())
            {
                DataRow drSB = gridScanBarcodeBinView.GetDataRow(iRow);

                psScanBin.AutoID = (long)Convert.ToDouble(drSB["AutoID"]);
                psScanBin.PartNo = Convert.ToString(drSB["PartNo"]);
                psScanBin.ItemNo = Convert.ToString(drSB["ItemNo"]);
                psScanBin.CreatedBy = userName;
                psScanBin.CreatedDate = DateTime.Now;
                psScanBin.LastModifiedBy = userName;
                psScanBin.LastModifiedDate = DateTime.Now;

                prodStatisticDAO.TransLineScanBarcodeBin(psScanBin);
            }

            foreach (var iRow in gridScanBarcodeBinV2View.GetSelectedRows())
            {
                DataRow drSB = gridScanBarcodeBinV2View.GetDataRow(iRow);

                psScanBin.AutoID = (long)Convert.ToDouble(drSB["AutoID"]);
                psScanBin.PartNo = Convert.ToString(drSB["PartNo"]);
                psScanBin.CusID = Convert.ToString(drSB["CusID"]);
                psScanBin.CreatedBy = userName;
                psScanBin.CreatedDate = DateTime.Now;
                psScanBin.LastModifiedBy = userName;
                psScanBin.LastModifiedDate = DateTime.Now;

                prodStatisticDAO.TransLineScanBarcodeBinV2(psScanBin);
            }
        }

        private void BtImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.Title = "Open Excel File";
            openExcel.Filter = "XLSX files|*.xlsx";
            openExcel.InitialDirectory = @"C:\";

            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //
                    List<string> arrProd = new List<string>();
                    ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();
                    DataTable dtExcel = new DataTable();
                    dtExcel = excel.ReadDataFromExcelFile(openExcel.FileName, "Sheet1", "A1:V10000");

                    foreach (DataRow dr in dtExcel.Rows)
                    {
                        string PartNo = Convert.ToString(dr["PartNo"]);
                        string ItemNo = Convert.ToString(dr["ItemNo"]);
                        string idCheck = PartNo + ItemNo;

                        if (!arrProd.Contains(idCheck))
                        {
                            _sqlHelper.ExecQueryNonData("DELETE FROM ASPScanBarcodeBin WHERE PartNo = '" + PartNo + "' AND ItemNo = '" + ItemNo + "'");
                            arrProd.Add(Convert.ToString(dr["PartNo"]) + Convert.ToString(dr["ItemNo"]));
                        }

                        psScanBin.PartNo = Convert.ToString(dr["PartNo"]);
                        psScanBin.ItemNo = Convert.ToString(dr["ItemNo"]);
                        psScanBin.Quantity = Convert.ToString(dr["Quantity"]);
                        psScanBin.NW = Convert.ToDouble(dr["NW"]);
                        psScanBin.GW = Convert.ToDouble(dr["GW"]);
                        psScanBin.CartNo = Convert.ToString(dr["CartNo"]);
                        psScanBin.LotNo = Convert.ToString(dr["LotNo"]);
                        psScanBin.WO = Convert.ToString(dr["WO"]);
                        psScanBin.Cable = Convert.ToString(dr["Cable"]);
                        psScanBin.BinSize = Convert.ToString(dr["BinSize"]);
                        psScanBin.ULStamp = Convert.ToString(dr["ULStamp"]);
                        psScanBin.UL2Stamp = Convert.ToString(dr["UL2Stamp"]);
                        psScanBin.SBDate = Convert.ToString(dr["SBDate"]);
                        psScanBin.N5 = Convert.ToDouble(dr["N-5"]);
                        psScanBin.N25 = Convert.ToDouble(dr["N-25"]);
                        psScanBin.N100 = Convert.ToDouble(dr["N-100"]);
                        psScanBin.N250 = Convert.ToDouble(dr["N-250"]);
                        psScanBin.N500 = Convert.ToDouble(dr["N-500"]);
                        psScanBin.N1_25 = Convert.ToDouble(dr["1-N-25"]);
                        psScanBin.N1_100 = Convert.ToDouble(dr["1-N-100"]);
                        psScanBin.N1_250 = Convert.ToDouble(dr["1-N-250"]);
                        psScanBin.N1_500 = Convert.ToDouble(dr["1-N-500"]);
                        psScanBin.CreatedBy = userName;
                        psScanBin.CreatedDate = DateTime.Now;
                        psScanBin.LastModifiedBy = userName;
                        psScanBin.LastModifiedDate = DateTime.Now;

                        prodStatisticDAO.ImportScanBarcodeBin(psScanBin);
                    }

                    XtraMessageBox.Show("Import dữ liệu thành công.");

                    FillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        #endregion
    }
}
