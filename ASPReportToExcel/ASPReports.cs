using ASPControl;
using ASPData;
using ASPData.ASPDAO;
using Dapper;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ASPReportToExcel
{
    public partial class ASPReports : XtraForm
    {
        private readonly configDatabase _config;
        private readonly SQLHelper _sqlhelper;
        private readonly ASPExcelDataProcess.ASPExcelDataProcess _writeExcel;
        private DateTime _beginDate;
        private DateTime _endDate;
        private string _dataID;
        private string _factoryID;
        private string _fieldID;
        private string _lineID;
        private string _reportProc;
        private string _fileName;
        private string _sheetName;
        private string _rangeName;
        private string _saveFolder;
        public string Username;
        private DataSet ds = new DataSet();
        BindingSource bdsSheetsOut = new BindingSource();
        private DataTable dtRepIn;
        private DataTable dtRepOut;
        private Loadingggg _loading;
        private DataRow _drObjectID = null;
        private ASPDAO aspDao = new ASPDAO();

        public ASPReports()
        {
            InitializeComponent();
            this.Load += ASPReportExcel_Load;

            _config = new configDatabase();
            _sqlhelper = new SQLHelper();
            _writeExcel = new ASPExcelDataProcess.ASPExcelDataProcess();
            _loading = new Loadingggg();

            btnProcessExcelFile.Click += BtnProcessExcelFile_Click;
            btnProcessOut.Click += BtnProcessOut_Click;
            btnExcelFile.Click += BtnExcelFile_Click;
            btnSave.Click += BtnSave_Click;
            btExportReport.Click += BtExport_Click;
            btExportExcel.Click += BtExportExcel_Click;
            txtRangeName.TextChanged += TxtRangeName_TextChanged;
            dtpBeginDate.EditValueChanged += DtpBeginDate_EditValueChanged;
            dtpEndDate.EditValueChanged += DtpEndDate_EditValueChanged;
            cboReportName.EditValueChanged += CboReportName_EditValueChanged;
            cboDataID.EditValueChanged += CboDataID_EditValueChanged;
            cboFactoryID.EditValueChanged += CboFactoryID_EditValueChanged;
            cboFields.EditValueChanged += CboFields_EditValueChanged;
            cboLines.EditValueChanged += CboLines_EditValueChanged;
            cboOutlist.EditValueChanged += CboOutlist_EditValueChanged;
            cboSheetOut.EditValueChanged += CboSheetOut_EditValueChanged;
            cboSheetName.EditValueChanged += CboSheetName_EditValueChanged;
            gridStatSummaryView.RowCellStyle += GridStatSummaryView_RowCellStyle;
        }

        public enum MidType
        {
            Average,
            Median
        }

        private double GetMedian(List<double> values)
        {
            var sorted = values.OrderBy(x => x).ToList();
            int count = sorted.Count;
            if (count % 2 == 1)
                return sorted[count / 2];
            else
                return (sorted[(count / 2) - 1] + sorted[count / 2]) / 2.0;
        }

        private void GridStatSummaryView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow row = view.GetDataRow(e.RowHandle);

            if (row == null) return;

            DateTime date = DateTime.Now;

            if (row.Table.Columns.Contains("StatisticDate"))
                if (!string.IsNullOrEmpty(row["StatisticDate"].ToString()))
                    date = Convert.ToDateTime(row["StatisticDate"]);

            // ✅ Ưu tiên Chủ Nhật
            //if (date.DayOfWeek == DayOfWeek.Sunday)
            //{
            //    e.Appearance.BackColor = Color.Blue;
            //    e.Appearance.ForeColor = Color.White;

            //    if (e.Column.FieldName != "StatisticDate" && e.Column.FieldName != "DayOfWeeks")
            //    {
            //        row[e.Column.FieldName] = DBNull.Value; // ⬅️ ẩn giá trị thay vì xoá dữ liệu
            //    }
            //    return; // ⬅️ thoát luôn, không cho logic khác ghi đè
            //}

            // ✅ Các ngày khác mới chạy scale màu
            if (e.Column.FieldName == "YieldProductivity" || e.Column.FieldName == "DailyProductivity")
            {
                var values = Enumerable.Range(0, view.DataRowCount)
                    .Select(r => view.GetRowCellValue(r, "YieldProductivity"))
                    .Where(v => v != null && v != DBNull.Value && double.TryParse(v.ToString(), out _))
                    .Select(v => Convert.ToDouble(v))
                    .ToList();

                if (values.Count == 0) return;

                double min = values.Min();
                double max = values.Max();
                double mid = GetMedian(values);

                double val = 0;
                if (e.CellValue != null && e.CellValue != DBNull.Value)
                    double.TryParse(e.CellValue.ToString(), out val);

                if (val <= 0) return;

                if (val <= mid)
                {
                    double ratio = (val - min) / (mid - min + 0.00001);
                    if (ratio > 0)
                        e.Appearance.BackColor = InterpolateColor(Color.Red, Color.Yellow, ratio);
                }
                else
                {
                    double ratio = (val - mid) / (max - mid + 0.00001);
                    if (ratio > 0)
                        e.Appearance.BackColor = InterpolateColor(Color.Yellow, Color.Green, ratio);
                }
            }
        }


        private Color InterpolateColor(Color c1, Color c2, double ratio)
        {
            // đảm bảo ratio trong [0..1]
            ratio = Math.Max(0, Math.Min(1, ratio));

            int r = (int)Math.Round(c1.R + (c2.R - c1.R) * ratio);
            int g = (int)Math.Round(c1.G + (c2.G - c1.G) * ratio);
            int b = (int)Math.Round(c1.B + (c2.B - c1.B) * ratio);

            // clamp về 0–255
            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return Color.FromArgb(r, g, b);
        }


        private void ASPReportExcel_Load(object sender, EventArgs e)
        {
            dtpBeginDate.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.DateTime = DateTime.Now;

            FillData();
        }

        #region FillData
        private void FillData()
        {
            //fill cac mau bao cao tu phan mem
            //string strSQL = "SELECT Report_ID, Report_Name FROM REPORTEX ORDER BY Stt ASC";

            DataTable dtReportName = aspDao.GetReportByUser(Username);

            BindingSource bdsReportName = new BindingSource();
            bdsReportName.DataSource = dtReportName;

            cboReportName.Properties.DataSource = bdsReportName;
            cboReportName.Properties.ValueMember = dtReportName.Columns["Report_ID"].ColumnName;
            cboReportName.Properties.DisplayMember = dtReportName.Columns["Report_Name"].ColumnName;

            //fill ma dvcs
            string strSQL = "SELECT Ma_DvCs FROM L00DMDVCSASP WHERE Ma_DvCs <> 'A03'";
            DataTable dtDvCs = _sqlhelper.ExecQueryDataAsDataTable(strSQL);

            BindingSource bdsDvCs = new BindingSource();
            bdsDvCs.DataSource = dtDvCs;

            cboDataID.Properties.DataSource = bdsDvCs;
            cboDataID.Properties.ValueMember = dtDvCs.Columns["Ma_DvCs"].ColumnName;
            cboDataID.Properties.DisplayMember = dtDvCs.Columns["Ma_DvCs"].ColumnName;

            //fill ma nha may
            strSQL = "SELECT Ma_NhaMay, Ten_NhaMay FROM L81NHAMAYASP";
            DataTable dtNhaMay = _sqlhelper.ExecQueryDataAsDataTable(strSQL);

            BindingSource bdsNhaMay = new BindingSource();
            bdsNhaMay.DataSource = dtNhaMay;

            cboFactoryID.Properties.DataSource = bdsNhaMay;
            cboFactoryID.Properties.ValueMember = dtNhaMay.Columns["Ma_NhaMay"].ColumnName;
            cboFactoryID.Properties.DisplayMember = dtNhaMay.Columns["Ten_NhaMay"].ColumnName;

            //fill ma nganh nghe
            strSQL = "SELECT Ma_NNghe, Ten_NNghe FROM L81DMNNGHEASP UNION SELECT '*' AS Ma_NNghe, N'Tất cả' AS Ten_NNghe";
            DataTable dtNNghe = _sqlhelper.ExecQueryDataAsDataTable(strSQL);

            BindingSource bdsNNghe = new BindingSource();
            bdsNNghe.DataSource = dtNNghe;

            cboFields.Properties.DataSource = bdsNNghe;
            cboFields.Properties.ValueMember = dtNNghe.Columns["Ma_NNghe"].ColumnName;
            cboFields.Properties.DisplayMember = dtNNghe.Columns["Ten_NNghe"].ColumnName;

            //fill ma line
            strSQL = "SELECT Ma_Day_Chuyen, Ten_Day_Chuyen FROM L81DMDAYCHUYENASP UNION SELECT '*' AS Ma_Day_Chuyen, N'Tất cả' AS Ten_Day_Chuyen UNION SELECT '*_asm3' AS Ma_Day_Chuyen, N'Tất cả ASM3' AS Ten_Day_Chuyen";
            DataTable dtLines = _sqlhelper.ExecQueryDataAsDataTable(strSQL);

            BindingSource bdsLines = new BindingSource();
            bdsLines.DataSource = dtLines;

            cboLines.Properties.DataSource = bdsLines;
            cboLines.Properties.ValueMember = dtLines.Columns["Ma_Day_Chuyen"].ColumnName;
            cboLines.Properties.DisplayMember = dtLines.Columns["Ten_Day_Chuyen"].ColumnName;

            _reportProc = (string)_sqlhelper.ExecQuerySacalar("SELECT Report_Proc FROM ReportEx WHERE Report_ID = '" + cboReportName.EditValue.ToString() + "'");
            _beginDate = (DateTime)dtpBeginDate.EditValue;
            _endDate = (DateTime)dtpEndDate.EditValue;
            _dataID = cboDataID.EditValue.ToString();
            _factoryID = cboFactoryID.EditValue.ToString();
            _fieldID = cboFields.EditValue.ToString();
            _lineID = cboLines.EditValue.ToString();
            _fileName = txtExcelFile.Text;
            _rangeName = txtRangeName.Text;
            _saveFolder = txtSaveFile.Text;
        }

        private bool FormCheckValid()
        {
            if (dtRepIn == null || dtRepIn.Rows.Count == 0)
            {
                if (string.IsNullOrEmpty(_fileName) || string.IsNullOrEmpty(_sheetName) || string.IsNullOrEmpty(_rangeName))
                {
                    XtraMessageBox.Show("Cần nhập đủ thông tin đầu ra.", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(_saveFolder))
            {
                XtraMessageBox.Show("Cần chọn thư mục lưu.", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void LogReportProcessingError(string processStep, Exception exception)
        {
            try
            {
                string logFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "ASPProject",
                    "Logs");
                Directory.CreateDirectory(logFolder);

                string logPath = Path.Combine(logFolder, "report-excel.log");
                string logContent = string.Format(
                    "{0:yyyy-MM-dd HH:mm:ss} | Report={1} | Step={2} | Process={3}-bit | ManagedMemory={4:N0} bytes{5}{6}{5}{5}",
                    DateTime.Now,
                    Convert.ToString(cboReportName.EditValue),
                    processStep,
                    Environment.Is64BitProcess ? 64 : 32,
                    GC.GetTotalMemory(false),
                    Environment.NewLine,
                    exception);

                File.AppendAllText(logPath, logContent, Encoding.UTF8);
            }
            catch
            {
                // Logging must not hide the original processing error.
            }
        }

        #endregion

        #region Event
        private void BtnProcessExcelFile_Click(object sender, EventArgs e)
        {
            if (!FormCheckValid())
                return;

            string processStep = "Khởi tạo xử lý";
            Exception processError = null;
            bool hasData = false;
            bool processSucceeded = false;

            try
            {
                _loading.CreateWaitDialog();
                _loading.SetWaitDialogCaption("Đang xử lý...");

                cboSheetOut.Enabled = true;
                txtRangeOut.Enabled = true;

                processStep = "Chuẩn bị tham số báo cáo";

                var dicParams = new Dictionary<string, object>
                {
                    { "@Ngay_Ct1", _beginDate },
                    { "@Ngay_Ct2", _endDate },
                    { "@Ma_DvCs", _dataID },
                    { "@Ma_NNghe", _fieldID == "*" ? string.Empty : _fieldID },
                    { "@Ma_NhaMay", _factoryID}
                };

                var dicLine = new Dictionary<string, object>
                {
                    { "@ProcName", _reportProc },
                    { "@Param", "Ma_Day_Chuyen" }
                };

                DataTable dtCheckLineParams = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPCheckParamsinProc", dicLine);

                if (dtCheckLineParams.Rows.Count > 0)
                    dicParams.Add("@Ma_Day_Chuyen", _lineID == "*" ? string.Empty : _lineID);

                var dicUsername = new Dictionary<string, object>
                {
                     { "@ProcName", _reportProc },
                    { "@Param", "Username" }
                };

                dtCheckLineParams = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPCheckParamsinProc", dicUsername);

                if (dtCheckLineParams.Rows.Count > 0)
                    dicParams.Add("@Username", Username);

                var parameters = new DynamicParameters(dicParams);

                processStep = "Lấy dữ liệu báo cáo từ cơ sở dữ liệu";
                if (ds != null)
                {
                    ds.Dispose();
                    ds = new DataSet();
                }
                ds = _sqlhelper.ExecProcedureDataAsDataSet(_reportProc, parameters);

                processStep = "Đọc cấu hình đầu ra";
                dtRepOut = _sqlhelper.ExecQueryDataAsDataTable("SELECT Report_Out_SheetName, Report_Out_RangeName FROM ReportEx_Output WHERE Report_ID = '" + cboReportName.EditValue.ToString() + "' ORDER BY Stt, Report_ID");

                if (dtRepOut.Rows.Count == 0)
                {
                    //thêm vào combobox danh sách đầu ra
                    DataTable dtOutList = new DataTable();
                    dtOutList.Columns.Add("STT", typeof(Int16));
                    dtOutList.Columns.Add("OutPutName", typeof(string));

                    int i = 2;
                    while (ds.Tables.Count >= 2 && i <= ds.Tables.Count)
                    {
                        DataRow drOutList = dtOutList.NewRow();

                        drOutList["STT"] = i - 1;
                        drOutList["OutPutName"] = "Output " + (i - 1).ToString();

                        dtOutList.Rows.Add(drOutList);

                        i = i + 1;
                    }

                    if (dtOutList.Rows.Count > 0)
                    {
                        cboSheetOut.Properties.DataSource = bdsSheetsOut;
                        cboOutlist.Properties.DataSource = dtOutList.DefaultView;
                        cboOutlist.Properties.DisplayMember = "OutPutName";
                    }
                }
                else
                {
                    cboSheetOut.Enabled = false;
                    txtRangeOut.Enabled = false;
                }

                //write excel file
                if (ds.Tables.Count > 0)
                {
                    hasData = true;
                    processStep = "Ghi dữ liệu vào file Excel";

                    if (dtRepIn != null && dtRepIn.Rows.Count > 0)
                    {
                        if (ds.Tables.Count < dtRepIn.Rows.Count)
                            throw new InvalidOperationException("Số bảng dữ liệu trả về ít hơn số vùng đầu vào đã cấu hình.");

                        List<DataTable> inputTables = new List<DataTable>();
                        List<string> inputSheetNames = new List<string>();
                        List<string> inputRangeNames = new List<string>();

                        for (int k = 0; k <= dtRepIn.Rows.Count - 1; k++)
                        {
                            inputTables.Add(ds.Tables[k]);
                            inputSheetNames.Add(Convert.ToString(dtRepIn.Rows[k]["Report_In_SheetName"]));
                            inputRangeNames.Add(Convert.ToString(dtRepIn.Rows[k]["Report_In_RangeName"]));
                        }

                        _writeExcel.WriteDataTablesIntoExcelFile(
                            inputTables,
                            _fileName,
                            inputSheetNames,
                            inputRangeNames,
                            _saveFolder);
                    }
                    else
                        _writeExcel.WriteDataIntoExcelFile(ds.Tables[0], _fileName, _sheetName, _rangeName, _saveFolder);

                    processSucceeded = true;
                }
            }
            catch (Exception ex)
            {
                processError = ex;
                LogReportProcessingError(processStep, ex);
            }
            finally
            {
                _loading.simpleCloseWait();
            }

            if (processError != null)
            {
                if (processError is OutOfMemoryException)
                {
                    XtraMessageBox.Show(
                        "Không đủ bộ nhớ tại bước '" + processStep + "'. Vui lòng thu hẹp khoảng ngày hoặc giảm số lượng dữ liệu cần xuất.",
                        "Không thể xử lý",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show(
                        "Không thể xử lý đầu vào tại bước '" + processStep + "': " + processError.Message,
                        "Không thể xử lý",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            if (!hasData)
            {
                XtraMessageBox.Show("Không có dữ liệu.");
                return;
            }

            if (processSucceeded && XtraMessageBox.Show("Xử lý thành công, bạn có muốn mở file đã xử lý lên không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process.Start(string.IsNullOrEmpty(_saveFolder) ? _fileName : _saveFolder);
            }
        }

        private void BtnProcessOut_Click(object sender, EventArgs e)
        {
            DataTable dtRepOut = _sqlhelper.ExecQueryDataAsDataTable("SELECT Report_Out_SheetName, Report_Out_RangeName FROM ReportEx_Output WHERE Report_ID = '" + Convert.ToString(cboReportName.EditValue) + "' ORDER BY Stt ASC");

            _loading.CreateWaitDialog();
            _loading.SetWaitDialogCaption("Đang xử lý...");

            try
            {
                if (dtRepOut.Rows.Count == 0)
                {
                    if (string.IsNullOrEmpty(txtRangeOut.Text))
                    {
                        XtraMessageBox.Show("Vui lòng nhập vùng dữ liệu đầu ra.");
                        return;
                    }

                    int indxOut = cboOutlist.ItemIndex;

                    _writeExcel.WriteDataIntoExcelFile(ds.Tables[indxOut + 1], txtSaveFile.Text, Convert.ToString(cboSheetOut.EditValue), txtRangeOut.Text, _saveFolder);

                    _loading.simpleCloseWait();

                    if (XtraMessageBox.Show("Xử lý thành công, bạn có muốn mở file đã xử lý lên không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(string.IsNullOrEmpty(_saveFolder) ? _fileName : _saveFolder);
                    }

                }
                else
                {
                    int i = 0; //sheet 1
                    int indxOut = 1;

                    do
                    {
                        string iSheetName = (string)dtRepOut.Rows[i]["Report_Out_SheetName"];
                        string[] iarrRangeName = dtRepOut.Rows[i]["Report_Out_RangeName"].ToString().Split(',');

                        for (int k = 1; k <= iarrRangeName.Length; k++)
                        {
                            if (ds.Tables.Count > indxOut)
                                _writeExcel.WriteDataIntoExcelFile(ds.Tables[indxOut], txtSaveFile.Text, iSheetName, iarrRangeName[k - 1], _saveFolder);

                            indxOut++;
                        }

                        i++;
                    }
                    while (i <= dtRepOut.Rows.Count - 1);

                    _loading.simpleCloseWait();

                    if (XtraMessageBox.Show("Xử lý thành công, bạn có muốn mở file đã xử lý lên không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(string.IsNullOrEmpty(_saveFolder) ? _fileName : _saveFolder);
                    }
                }
            }
            catch (Exception ex)
            {
                _loading.simpleCloseWait();
                XtraMessageBox.Show("Không có dữ liệu: " + ex.Message);
            }
        }
        private void BtnExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcelFile = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Excel Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "Excel Files|*.xlsx;*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openExcelFile.ShowDialog() == DialogResult.OK)
            {
                txtExcelFile.Text = openExcelFile.FileName;

                if (!string.IsNullOrEmpty(txtExcelFile.Text))
                {
                    BindingSource bdsSheets = new BindingSource();
                    List<string> sourceSheets = _writeExcel.ExcelGetAllNameOfSheets(txtExcelFile.Text);
                    bdsSheets.DataSource = sourceSheets;
                    cboSheetName.Properties.DataSource = sourceSheets;
                    //cboSheetName.Properties.DisplayMember = "Sheet Name";
                    //cboSheetName.Properties.ValueMember = "Sheet Name";

                    //BindingSource bdsSheetsOut = new BindingSource();
                    bdsSheetsOut.DataSource = _writeExcel.ExcelGetAllNameOfSheets(txtExcelFile.Text);

                    _sheetName = Convert.ToString(cboSheetName.EditValue);
                    _fileName = txtExcelFile.Text;
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = _fileName;
            sf.Filter = "Excel Files|*.xlsx;*.xls";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                txtSaveFile.Text = sf.FileName;
                _saveFolder = txtSaveFile.Text;
            }
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
         
            gridStatSummary.RefreshDataSource();
            gridStatSummaryView.ClearSelection();

            _loading.CreateWaitDialog();
            _loading.SetWaitDialogCaption("Đang xử lý...");

            var dicParams = new Dictionary<string, object>
                {
                    { "@Ngay_Ct1", _beginDate },
                    { "@Ngay_Ct2", _endDate },
                    { "@Ma_DvCs", _dataID },
                    { "@Ma_NNghe", _fieldID == "*" ? string.Empty : _fieldID },
                    { "@Ma_NhaMay", _factoryID}
                };

            var dicLine = new Dictionary<string, object>
                {
                    { "@ProcName", _reportProc },
                    { "@Param", "Ma_Day_Chuyen" }
                };

            DataTable dtCheckLineParams = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPCheckParamsinProc", dicLine);

            if (dtCheckLineParams.Rows.Count > 0)
                dicParams.Add("@Ma_Day_Chuyen", _lineID == "*" ? string.Empty : _lineID);

            var dicUsername = new Dictionary<string, object>
                {
                     { "@ProcName", _reportProc },
                    { "@Param", "Username" }
                };

            dtCheckLineParams = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPCheckParamsinProc", dicUsername);

            if (dtCheckLineParams.Rows.Count > 0)
                dicParams.Add("@Username", Username);

            var parameters = new DynamicParameters(dicParams);

            ds = _sqlhelper.ExecProcedureDataAsDataSet(_reportProc, parameters);

            if (ds.Tables.Count > 0)
            {
                DataTable dtResult = ds.Tables[0];

                gridStatSummary.DataSource = dtResult;
                gridStatSummaryView.BestFitColumns(true);
            }

            XtraMessageBox.Show("Đã xuất thành công");

            _loading.simpleCloseWait();
        }

        private void BtExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridStatSummaryView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void DtpEndDate_EditValueChanged(object sender, EventArgs e)
        {
            _endDate = (DateTime)dtpEndDate.EditValue;
        }

        private void DtpBeginDate_EditValueChanged(object sender, EventArgs e)
        {
            _beginDate = (DateTime)dtpBeginDate.EditValue;
        }

        private void TxtRangeName_TextChanged(object sender, EventArgs e)
        {
            _rangeName = txtRangeName.Text;
        }

        private void CboSheetOut_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void CboSheetName_EditValueChanged(object sender, EventArgs e)
        {
            _sheetName = (string)cboSheetName.EditValue;
        }

        private void CboOutlist_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void CboFields_EditValueChanged(object sender, EventArgs e)
        {
            _fieldID = (string)cboFields.EditValue;
        }

        private void CboLines_EditValueChanged(object sender, EventArgs e)
        {
            _lineID = (string)cboLines.EditValue;
        }

        private void CboFactoryID_EditValueChanged(object sender, EventArgs e)
        {
            _factoryID = (string)cboFactoryID.EditValue;
        }

        private void CboDataID_EditValueChanged(object sender, EventArgs e)
        {
            _dataID = (string)cboDataID.EditValue;
        }

        private void CboReportName_EditValueChanged(object sender, EventArgs e)
        {
            _reportProc = (string)_sqlhelper.ExecQuerySacalar("SELECT Report_Proc FROM ReportEx WHERE Report_Id = '" + Convert.ToString(cboReportName.EditValue) + "'");
            dtRepIn = _sqlhelper.ExecQueryDataAsDataTable("SELECT Report_In_SheetName, Report_In_RangeName FROM ReportEx_Input WHERE Report_ID = '" + cboReportName.EditValue.ToString() + "' ORDER BY Stt, Report_ID");

            if (dtRepIn.Rows.Count > 0)
            {
                cboSheetName.Enabled = false;
                txtRangeName.Enabled = false;
            }
            else
            {
                cboSheetName.Enabled = true;
                txtRangeName.Enabled = true;
            }
        }
        #endregion
    }
}
