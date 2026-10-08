using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using ASPData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Printing.Core.PdfExport.Metafile;
using DevExpress.XtraEditors;
using Newtonsoft.Json;


namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmProdQRCodeTraceability : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtProdScanQRCode = new DataTable();
        private DataTable dtWODocNoList = new DataTable();
        private DataTable dtProductList = new DataTable();
        private BindingSource bdsBOM = new BindingSource();
        private BindingSource bdsQRCodeMaster = new BindingSource();
        private BindingSource bdsQRCodeDetail = new BindingSource();
        private DataRow drHeaderCur = null;
        private DataRow drDetailCur = null;
        private BindingSource bdsProdScanQRCode = new BindingSource();
        private BindingSource bdsWOSummary = new BindingSource();
        private BindingSource bdsWOKHSX = new BindingSource();
        private BindingSource bdsEmpStage = new BindingSource();
        private BindingSource bdsWHMaterial = new BindingSource();
        private BindingSource bdsWHProduct = new BindingSource();
        private BindingSource bdsIQC = new BindingSource();
        private BindingSource bdsOQC = new BindingSource();
        private BindingSource bdsIPQC = new BindingSource();
        private BindingSource bdsOQCScan = new BindingSource();
        private BindingSource bdsSerial = new BindingSource();

        QRCodeMasterList qrDto = new QRCodeMasterList();
        ProdStatisticDTO prodDto = new ProdStatisticDTO();
        ProdStatisticDAO qrDao = new ProdStatisticDAO();
        QRCodeLog qrLogDto = new QRCodeLog();
        ASPExcelDataProcess.ASPExcelDataProcess aspExcel = new ASPExcelDataProcess.ASPExcelDataProcess();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
        public string rowWO = string.Empty;
        public ASPControl.Loadingggg ld = new ASPControl.Loadingggg();
        #endregion

        public frmProdQRCodeTraceability()
        {
            InitializeComponent();

            // Tạo collection chứa số từ 1 đến 100
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                numbers.Add(i);
            }

            txtSerial.Properties.CharacterCasing = CharacterCasing.Upper;

            // Gán collection vào LookUpEdit
            lkeCartNo.Properties.DataSource = numbers;
            lkeCartNo.Properties.DisplayMember = null; // Vì là kiểu int, không cần DisplayMember
            lkeCartNo.Properties.ValueMember = null;   // Vì là kiểu int, không cần ValueMember

            //gan collection vao lke product
            lkeProduct.Properties.DataSource = qrDao.GetProductList(string.Empty);
            lkeProduct.Properties.DisplayMember = "Ma_Vt";
            lkeProduct.Properties.ValueMember = "Ma_Vt";
            lkeProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeProduct.Properties.PopupFilterMode = PopupFilterMode.Contains;

            //gan collection vao lkeWO
            lkeWO.Properties.DataSource = qrDao.GetWODocNoList("AS0064", string.Empty, 1);
            lkeWO.Properties.DisplayMember = "So_Ct";
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            // (Tùy chọn) Thiết lập giá trị ban đầu
            lkeCartNo.EditValue = 1;

            //
            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;

            this.Load += FrmProdQRCodeTraceability_Load;

            this.lkeProduct.EditValueChanged += LkeProduct_EditValueChanged;
            //this.lkeWO.EditValueChanged += LkeWO_EditValueChanged;
            this.lkeWO.KeyDown += LkeWO_KeyDown;
            this.btExportExcel.Click += BtExportExcel_Click;
            this.txtQRCodeData.TextChanged += TxtQRCodeData_TextChanged;

            this.lkeCartNo.TextChanged += LkeCartNo_TextChanged;
            dtFromDate.EditValueChanging += DtFromDate_EditValueChanging;
            dtToDate.EditValueChanging += DtToDate_EditValueChanging;

            this.gridQRCodeView.RowStyle += GridQRCodeView_RowStyle;

            this.btXoa.Click += BtXoa_Click;
            this.btExcelReport.Click += BtExcelReport_Click;
            this.btSysExcel.Click += BtSysExcel_Click;
            this.btExcel.Click += BtExcel_Click;

            this.gridWOSummaryView.RowClick += GridWOSummaryView_RowClick;
           
            //this.txtSerial.EditValueChanged += TxtSerial_EditValueChanged;
            this.txtSerial.KeyDown += TxtSerial_KeyDown;
            this.gridSerialView.RowCellStyle += GridSerialView_RowCellStyle;
        }

       

        private void GridSerialView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            // Chỉ xử lý các dòng dữ liệu, bỏ header
            if (e.RowHandle < 0) return;

            string serialCode = view.GetRowCellValue(e.RowHandle, "SerialCode")?.ToString();
            bool highlight = false;

            if (!string.IsNullOrEmpty(serialCode))
            {
                // 1. Check độ dài < 12
                if (serialCode.Length < 12)
                {
                    highlight = true;
                }

                // 2. Check trùng lặp
                int count = Enumerable.Range(0, view.DataRowCount)
                                      .Select(i => view.GetRowCellValue(i, "SerialCode")?.ToString())
                                      .Count(s => s == serialCode);

                if (count > 1)
                    highlight = true;
            }

            // Nếu cần tô đỏ dòng, áp dụng cho tất cả cột
            if (highlight)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White; // chữ trắng dễ đọc
            }
        }


        private void LkeWO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (string.IsNullOrEmpty(lkeWO.EditValue.ToString()))
                return;
            if (lkeWO.EditValue.ToString().Length < 10)
                return;

            FillDetailDataTrace(false);
        }

        private void TxtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string txtSerial = this.txtSerial.Text.Trim();

                if (!string.IsNullOrEmpty(txtSerial) && txtSerial.Length == 18)
                {
                    txtSerial = txtSerial.Replace("ASM1", "KZ");
                    string factoryId = txtSerial.Substring(0, 2);
                    string monthyear = txtSerial.Substring(2, 4);
                    string numDoc = txtSerial.Substring(6, 4);
                    string DocNo = factoryId + "LSX" + monthyear + "/" + numDoc;

                    lkeWO.EditValue = DocNo;

                    FillDetailDataTrace(true);
                }

                if (!string.IsNullOrEmpty(txtSerial) && txtSerial.Length > 18)
                {
                    DataTable dtWO = qrDao.FindGeneracWO(txtSerial);
                    if (dtWO.Rows.Count > 0)
                    {
                        string WO = dtWO.Rows[0]["WODocNo"].ToString();

                        lkeWO.EditValue = WO;

                        string productID = (string)_sqlHelper.ExecQuerySacalar("SELECT Ma_Sp FROM L14CTLSXASP WHERE So_Ct = '" + lkeWO.EditValue.ToString() + "'");
                        string cusPartNumber = (string)_sqlHelper.ExecQuerySacalar("SELECT Ma_Sp_Kh FROM L81DMVTASP WHERE Ma_Vt = '" + productID + "'");

                        lblProduct.Text = productID;
                        lblCusPart.Text = cusPartNumber;

                        bdsSerial.DataSource = dtWO;
                        gridSerial.DataSource = bdsSerial;
                    }
                }

                // Xóa hoặc focus sang ô khác nếu muốn
                this.txtSerial.Text = string.Empty;
                e.Handled = true;
            }
        }

        private void FillDetailDataTrace(bool isSerial)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            //tab WOSummary
            prodDto.WODocNo = lkeWO.EditValue.ToString();
            DataSet dsTraceability = new DataSet();
            dsTraceability = qrDao.TraceabilityWO(prodDto.WODocNo);

            FillDataDetailSerial(isSerial);
            FillDataDetailBOM();
            FillDataDetailProduction(dsTraceability);
            FillDataDetailQC(dsTraceability);

            ld.simpleCloseWait();
        }

      

        private void GridWOSummaryView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Loading detail of data. Please wait...");

            DataRow drCurrent = gridWOSummaryView.GetDataRow(e.RowHandle);
            rowWO = Convert.ToString(drCurrent["WODocNo"]);

            //tab KHSX
            //prodDto.WODocNo = rowWO;
            if (rowWO == string.Empty)
                return;

            DataSet dsTraceability = qrDao.TraceabilityWO(rowWO);
            if (dsTraceability.Tables.Count > 1)
            {
                bdsWOKHSX.DataSource = dsTraceability.Tables[1];
                gridKHSX.DataSource = bdsWOKHSX;
            }

            if (dsTraceability.Tables.Count > 2)
            {
                bdsEmpStage.DataSource = dsTraceability.Tables[2];
                gridEmpStage.DataSource = bdsEmpStage;
            }

            if (dsTraceability.Tables.Count > 3)
            {
                bdsWHMaterial.DataSource = dsTraceability.Tables[3];
                gridWHInfo.DataSource = bdsWHMaterial;
            }

            if (dsTraceability.Tables.Count > 7)
            {
                bdsWHProduct.DataSource = dsTraceability.Tables[7];
                gridWHProduct.DataSource = bdsWHProduct;
            }

            if (dsTraceability.Tables.Count > 8)
            {
                gridLogScan.DataSource = dsTraceability.Tables[8];
            }

            ld.simpleCloseWait();

            tabTraceability.SelectedTabPage = tabProduction;
        }

        private void DtToDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            FillData();
        }

        private void DtFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            FillData();
        }

        private void LkeCartNo_TextChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void GridQRCodeView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            bool isDup = Convert.ToBoolean(gridQRCodeView.GetRowCellValue(e.RowHandle, "IsDuplicate"));

            if (isDup == true)
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void BtExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridBOMView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void TxtQRCodeData_TextChanged(object sender, EventArgs e)
        {
            if (txtQRCodeData.Text == string.Empty)
            {
                this.ActiveControl = txtQRCodeData;
                return;
            }

            if (txtQRCodeData.Text.Length != 9)
                return;

            if (string.IsNullOrEmpty(txtScanInfo.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập nội dung scan !!");
                this.ActiveControl = txtScanInfo;
                return;
            }

            if (string.IsNullOrEmpty(txtModel.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập model !!");
                this.ActiveControl = txtScanInfo;
                return;
            }

            qrLogDto.LogID = ASPGenLogQRCode();
            qrLogDto.StageID = Convert.ToString(lkeProduct.EditValue);
            qrLogDto.LogTime = DateTime.Now;
            qrLogDto.QRCodeData = txtQRCodeData.Text.Trim();
            qrLogDto.CartNo = Convert.ToInt32(lkeCartNo.EditValue);
            qrLogDto.GroupData = txtQRCodeData.Text.Substring(0, 3);
            qrLogDto.ScanInfo = txtScanInfo.Text.Trim();
            qrLogDto.CreatedDate = DateTime.Now;
            qrLogDto.CreatedBy = userName;
            qrLogDto.LastModifiedBy = userName;
            qrLogDto.LastModifiedDate = DateTime.Now;


            if (ValidateQRCode() == false)
            {
                if (XtraMessageBox.Show("QR Code đã tồn tại, bạn có muốn lưu tiếp không ?", "Kiểm tra", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    txtQRCodeData.Text = string.Empty;
                    this.ActiveControl = txtQRCodeData;
                    return;
                }

            }

            if (txtQRCodeData.Text.Contains(txtModel.Text) == false)
            {
                XtraMessageBox.Show("Không đúng model, vui lòng kiểm tra lại!");
                return;
            }

            qrDao.InsertEngASM2ScanQRCode(qrLogDto);

            txtQRCodeData.Text = string.Empty;

            FillData();
        }

        private bool ValidateQRCode()
        {
            bool chk = true;

            var dicParams = new Dictionary<string, object>()
            {
                { "@QRCodeData", txtQRCodeData.Text }
            };

            DataTable dt = new DataTable();
            dt = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPCheckEngASM2ScanQRCode", dicParams);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                chk = !Convert.ToBoolean(dr["IsExist"]);
            }

            return chk;
        }

        private void FillData()
        {
            qrLogDto.Username = userName;

            qrLogDto.FromDate = Convert.ToDateTime(dtFromDate.EditValue).Date;
            qrLogDto.ToDate = Convert.ToDateTime(dtToDate.EditValue).Date;
            qrLogDto.CartNo = Convert.ToInt32(lkeCartNo.EditValue);
            dtProdScanQRCode = qrDao.GetEngASM2QRCode(qrLogDto);

            bdsProdScanQRCode.DataSource = dtProdScanQRCode;

            gridQRCode.DataSource = dtProdScanQRCode;
        }

        //tab BOM
        private void FillDataDetailBOM()
        {
            string productID = (string)_sqlHelper.ExecQuerySacalar("SELECT Ma_Sp FROM L14CTLSXASP WHERE So_Ct = '" + lkeWO.EditValue.ToString() + "'");
            string cusPartNumber = (string)_sqlHelper.ExecQuerySacalar("SELECT Ma_Sp_Kh FROM L81DMVTASP WHERE Ma_Vt = '" + productID + "'");
            lblProduct.Text = productID;
            lblCusPart.Text = cusPartNumber;

            DataTable dtBOM = qrDao.GetCheckFullBOMByProduct(productID);
            bdsBOM.DataSource = dtBOM;
            gridBOMInfo.DataSource = bdsBOM;
        }

        //tab Serial code
        private void FillDataDetailSerial(bool isSerial)
        {
            string strWO = !string.IsNullOrEmpty(lkeWO.EditValue.ToString()) ? lkeWO.EditValue.ToString() : string.Empty;
            DataTable dtSerial = qrDao.GetGeneracSerialCode(strWO);
            if (isSerial == false)
                bdsSerial.DataSource = dtSerial;
            else
            {
                DataView dvSerial = new DataView(dtSerial);
                dvSerial.RowFilter = "SerialCode='" + txtSerial.Text.Trim() + "'";
                dtSerial = dvSerial.ToTable();

                bdsSerial.DataSource = dtSerial;
            }
            gridSerial.DataSource = bdsSerial;
        }

        //tab Production
        private void FillDataDetailProduction(DataSet dsTraceability)
        {
            if (dsTraceability.Tables.Count > 0)
            {
                bdsWOSummary.DataSource = dsTraceability.Tables[0];
                gridWOSummary.DataSource = bdsWOSummary;
            }
        }

        //tab QC
        private void FillDataDetailQC(DataSet dsTraceability)
        {
            if (dsTraceability.Tables.Count > 4)
            {
                bdsIQC.DataSource = dsTraceability.Tables[4];
                gridIQC.DataSource = bdsIQC;
            }

            if (dsTraceability.Tables.Count > 5)
            {
                bdsOQC.DataSource = dsTraceability.Tables[5];
                gridOQC.DataSource = bdsOQC;
            }

            if (dsTraceability.Tables.Count > 6)
            {
                bdsIPQC.DataSource = dsTraceability.Tables[6];
                gridIPQC.DataSource = bdsIPQC;
            }

            if (dsTraceability.Tables.Count > 9)
            {
                bdsOQC.DataSource = dsTraceability.Tables[9];
                gridOQCScan.DataSource = bdsOQC;
            }
        }

        private void LkeProduct_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtBOM = new DataTable();

            if (string.IsNullOrEmpty(lkeProduct.EditValue.ToString()))
                return;

            dtBOM = qrDao.GetCheckFullBOMByProduct(lkeProduct.EditValue.ToString());
            bdsBOM.DataSource = dtBOM;
            gridBOM.DataSource = bdsBOM;
        }

       
        private void FrmProdQRCodeTraceability_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private string ASPGenLogQRCode()
        {
            string qrCode = string.Empty;

            var dicParams = new Dictionary<string, object> {
                { "@Prefix", "LOG" },
                { "@NumLen", 20 },
                { "@ColumnID", "LogID" },
                { "@TableName", "ASPEngASM2ScanQRCode" }
            };

            qrCode = (string)_sqlHelper.ExecProcedureSacalar("sp_ASPGenerateCode", dicParams);

            return qrCode;
        }

        #region Event
        private void BtXoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= gridQRCodeView.GetSelectedRows().Length - 1; i++)
                {
                    DataRow dr = gridQRCodeView.GetDataRow(i);

                    if (dr != null)
                    {
                        var dicParams = new Dictionary<string, object>()
                        {
                            { "@LogID",  (string)dr["LogID"]}
                        };

                        _sqlHelper.ExecQueryNonData("DELETE FROM ASPEngASM2ScanQRCode WHERE LogTime = (SELECT MAX(LogTime) FROM ASPEngASM2ScanQRCode)", dicParams);
                    }
                }

                FillData();
                XtraMessageBox.Show("Đã xoá thành công");
            }
            catch (Exception ex) 
            {
                XtraMessageBox.Show("Không thành công, báo lỗi: " + ex.Message.ToString());
            }
        }

        private void BtExcelReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridQRCodeView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void frmProdQRCodeTraceability_Load_1(object sender, EventArgs e)
        {

        }

        private void BtSysExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                qrLogDto.Username = userName;

                qrLogDto.FromDate = Convert.ToDateTime("1900-01-01").Date;
                qrLogDto.ToDate = Convert.ToDateTime(dtToDate.EditValue).Date;
                qrLogDto.CartNo = Convert.ToInt32(lkeCartNo.EditValue);
                dtProdScanQRCode = qrDao.GetEngASM2QRCode(qrLogDto);

                bdsProdScanQRCode.DataSource = dtProdScanQRCode;

                gridQRCode.DataSource = dtProdScanQRCode;

                gridQRCodeView.ExportToXlsx(saveFileDialog1.FileName);

                qrLogDto.Username = userName;

                qrLogDto.FromDate = Convert.ToDateTime(dtFromDate.EditValue).Date;
                qrLogDto.ToDate = Convert.ToDateTime(dtToDate.EditValue).Date;
                qrLogDto.CartNo = Convert.ToInt32(lkeCartNo.EditValue);
                dtProdScanQRCode = qrDao.GetEngASM2QRCode(qrLogDto);

                bdsProdScanQRCode.DataSource = dtProdScanQRCode;

                gridQRCode.DataSource = dtProdScanQRCode;
            }
        }

        private void BtExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                if (xtraTabControl3.SelectedTabPage.Name == "tabOQCScanner")
                    gridOQCScanView.ExportToXlsx(saveFileDialog1.FileName);
                else
                    gridSerial.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        #endregion
    }
}
