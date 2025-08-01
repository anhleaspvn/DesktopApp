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

        QRCodeMasterList qrDto = new QRCodeMasterList();
        ProdStatisticDAO qrDao = new ProdStatisticDAO();
        QRCodeLog qrLogDto = new QRCodeLog();
        ASPExcelDataProcess.ASPExcelDataProcess aspExcel = new ASPExcelDataProcess.ASPExcelDataProcess();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu, curIndex;
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

            // Gán collection vào LookUpEdit
            lkeCartNo.Properties.DataSource = numbers;
            lkeCartNo.Properties.DisplayMember = null; // Vì là kiểu int, không cần DisplayMember
            lkeCartNo.Properties.ValueMember = null;   // Vì là kiểu int, không cần ValueMember

            //gan collection vao lke product
            lkeProduct.Properties.DataSource = qrDao.GetProductList(string.Empty);
            lkeProduct.Properties.DisplayMember = "Ma_Vt";
            lkeProduct.Properties.ValueMember = "Ma_Vt";

            // (Tùy chọn) Thiết lập giá trị ban đầu
            lkeCartNo.EditValue = 1;

            //
            dtFromDate.EditValue = DateTime.Now;
            dtToDate.EditValue = DateTime.Now;

            this.Load += FrmProdQRCodeTraceability_Load;

            this.lkeProduct.EditValueChanged += LkeProduct_EditValueChanged;
            this.btExportExcel.Click += BtExportExcel_Click;
            this.txtQRCodeData.TextChanged += TxtQRCodeData_TextChanged;

            this.lkeCartNo.TextChanged += LkeCartNo_TextChanged;
            dtFromDate.EditValueChanging += DtFromDate_EditValueChanging;
            dtToDate.EditValueChanging += DtToDate_EditValueChanging;

            this.gridQRCodeView.RowStyle += GridQRCodeView_RowStyle;

            this.btXoa.Click += BtXoa_Click;
            this.btExcelReport.Click += BtExcelReport_Click;
            this.btSysExcel.Click += BtSysExcel_Click;
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

        //private void FrmProdQRCodeTraceability_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    var dicParams = new Dictionary<string, object>()
        //        {
        //            { "@FromDate", qrLogDto.FromDate },
        //            { "@ToDate", qrLogDto.ToDate },
        //            { "@CartNo", qrLogDto.CartNo }
        //        };

        //    //
        //    _sqlHelper.ExecProcedureNonData("sp_ASPDeleteEngASM2QRCode_Log", dicParams);
        //}

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

            //if (dtProdScanQRCode.Rows.Count == 0)
            //{
            //    //load tam
            //    var dicParams = new Dictionary<string, object>()
            //    {
            //        { "@FromDate", qrLogDto.FromDate.Date },
            //        { "@ToDate", qrLogDto.ToDate.Date },
            //        { "@CartNo", qrLogDto.CartNo }
            //    };

            //    //
            //    dtProdScanQRCode = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetEngASM2QRCode_Log", dicParams);
            //}
            bdsProdScanQRCode.DataSource = dtProdScanQRCode;

            gridQRCode.DataSource = dtProdScanQRCode;
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

        #endregion
    }
}
