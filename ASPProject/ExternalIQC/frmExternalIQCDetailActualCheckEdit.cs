using ASPData.ASPDAO;
using ASPData.ASPDTO;
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
using DevExpress.XtraEditors;
using System.Globalization;
using System.Threading;

namespace ASPProject.ExternalIQC
{
    public partial class frmExternalIQCDetailActualCheckEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID, AutoID;
        public string iqcCheckID, iqcStandard, iqcStandardMin, iqcStandardMax, iqcDFID, iqcCheckingContent, iqcEvalueCheckTime,
                            iqcEvalueResult, userName, iqcDeviceID, iqcMeasuringToolID, iqcCutterID;
        public List<string> lstCheckingTime = new List<string>();
        public double iqcEvalueActual;
        private DataTable dtIQCActualCheck = new DataTable();
        public DataTable dtSaveMulti = new DataTable();
        public List<long> autoIDs = new List<long>();
        public DateTime createdDate;
        public string checkState = string.Empty;

        private IQCCheckingDAO iqcDao = new IQCCheckingDAO();
        private IQCCheckListDTO iqcDto = new IQCCheckListDTO();
        private IQCActualCheck iqcActualDto = new IQCActualCheck();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        public frmExternalIQCDetailActualCheckEdit()
        {
            InitializeComponent();

            this.Load += FrmExternalIQCDetailActualCheckEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }

        #region Load
        private void FrmExternalIQCDetailActualCheckEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            LoadDropdowns();

            switch (editType)
            {
                case 1:
                    cboCheckState.EditValue = string.Empty;
                    break;
                case 0:
                    lkeIQCCheckID.ReadOnly = true;

                    lkeIQCCheckID.EditValue = iqcCheckID;
                    lkeIQCDFID.EditValue = iqcDFID;
                    lkeIQCCheckingContent.EditValue = iqcCheckingContent;
                    lkeIQCEvalueCheckTime.EditValue = iqcEvalueCheckTime;
                    lkeIQCDeviceID.EditValue = iqcDeviceID;
                    lkeIQCMeasuringToolID.EditValue = iqcMeasuringToolID;

                    txtStandardMin.Text = iqcStandardMin;
                    txtStandardMax.Text = iqcStandardMax;
                    txtIQCResult.Text = iqcEvalueResult ?? string.Empty;
                    txtIQCCutterID.Text = iqcCutterID ?? string.Empty;
                    cboCheckState.EditValue = checkState ?? string.Empty;

                    var dtActuals = iqcDao.GetIQCActualCheckGroup(HeaderID, iqcCheckID, iqcDFID, createdDate, AutoID);

                    autoIDs.Clear();
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < dtActuals.Rows.Count)
                        {
                            autoIDs.Add(Convert.ToInt64(dtActuals.Rows[i]["AutoID"]));
                            var val = Convert.ToDouble(dtActuals.Rows[i]["IQCEvalueActual"]);
                            
                            if (i == 0) txtIQCEvalueActual.Text = val > 0 ? val.ToString() : string.Empty;
                            if (i == 1) txtIQCEvalueActual2.Text = val > 0 ? val.ToString() : string.Empty;
                            if (i == 2) txtIQCEvalueActual3.Text = val > 0 ? val.ToString() : string.Empty;
                            if (i == 3) txtIQCEvalueActual4.Text = val > 0 ? val.ToString() : string.Empty;
                            if (i == 4) txtIQCEvalueActual5.Text = val > 0 ? val.ToString() : string.Empty;
                        }
                        else
                        {
                            autoIDs.Add(0);
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        private void LoadDropdowns()
        {
            string checkFilter = editType == 0 ? (iqcCheckID ?? string.Empty) : string.Empty;
            BindLookUpEdit(
                lkeIQCCheckID,
                iqcDao.GetCheckStateListV2(checkFilter),
                preferredValueColumns: new[] { "IQCCheckID" },
                preferredDisplayColumns: new[] { "IQCCheckID", "IQCCheckName" });

            BindLookUpEdit(
                lkeIQCDFID,
                iqcDao.GetASPStageExList(),
                preferredValueColumns: new[] { "StageID", "IQCDFID", "Ma_Cong_Doan", "DFID" },
                preferredDisplayColumns: new[] { "StageName", "StageID", "IQCDFID", "Ma_Cong_Doan", "DFID" });

            BindLookUpEdit(
                lkeIQCCheckingContent,
                iqcDao.GetIQCCheckingContentList(string.Empty),
                preferredValueColumns: new[] { "IQCCheckingContent" },
                preferredDisplayColumns: new[] { "IQCCheckingContent" });

            BindLookUpEdit(
                lkeIQCEvalueCheckTime,
                iqcDao.GetQCInsPeriodTimeList(),
                preferredValueColumns: new[] { "PeriodTime", "IQCEvalueCheckTime", "QCInsPeriodTime", "InspectionTime", "PeriodID" },
                preferredDisplayColumns: new[] { "PeriodTime", "PeriodName", "IQCEvalueCheckTime", "QCInsPeriodTime", "InspectionTime", "PeriodID" });

            DataTable dtDevice = iqcDao.GetASPDeviceList() ?? new DataTable();
            BindLookUpEdit(
                lkeIQCDeviceID,
                dtDevice,
                preferredValueColumns: new[] { "DeviceID", "Ma_Thiet_Bi", "IQCDeviceID" },
                preferredDisplayColumns: new[] { "DeviceName", "DeviceID", "Ma_Thiet_Bi", "IQCDeviceID" });

            BindLookUpEdit(
                lkeIQCMeasuringToolID,
                dtDevice.Copy(),
                preferredValueColumns: new[] { "DeviceID", "Ma_Thiet_Bi", "IQCDeviceID" },
                preferredDisplayColumns: new[] { "DeviceName", "DeviceID", "Ma_Thiet_Bi", "IQCDeviceID" });
        }

        private void BindLookUpEdit(LookUpEdit lke, DataTable dt, string[] preferredValueColumns, string[] preferredDisplayColumns)
        {
            if (dt == null)
                dt = new DataTable();

            string valueMember = ResolveColumn(dt, preferredValueColumns);
            string displayMember = ResolveColumn(dt, preferredDisplayColumns) ?? valueMember;

            lke.Properties.DataSource = dt;
            lke.Properties.ValueMember = valueMember ?? string.Empty;
            lke.Properties.DisplayMember = displayMember ?? string.Empty;
            lke.Properties.NullText = "";
            lke.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lke.Properties.PopupFilterMode = PopupFilterMode.Contains;
            lke.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        private static string ResolveColumn(DataTable dt, string[] preferredColumns)
        {
            if (dt == null || dt.Columns.Count == 0)
                return null;

            if (preferredColumns != null)
            {
                foreach (string col in preferredColumns)
                {
                    if (!string.IsNullOrEmpty(col) && dt.Columns.Contains(col))
                        return col;
                }
            }

            return dt.Columns[0].ColumnName;
        }

        private static string GetLookupValue(LookUpEdit lke)
        {
            if (lke == null || lke.EditValue == null || lke.EditValue == DBNull.Value)
                return string.Empty;

            string value = Convert.ToString(lke.EditValue);
            return value ?? string.Empty;
        }

        public void LoadTV()
        {
            iNgonNgu = 0;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        public void LoadEL()
        {
            iNgonNgu = 1;
            CultureInfo objCultureInfo = Thread.CurrentThread.CurrentCulture;
            this.Text = "Form Insert && Update Actual Check";
        }

        public bool FormCheckValid()
        {
            if (editType == 1)
            {
                if (lkeIQCCheckID.EditValue == null || string.IsNullOrEmpty(Convert.ToString(lkeIQCCheckID.EditValue)))
                {
                    XtraMessageBox.Show("Vui lòng nhập mã nội dung.");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Event
        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (!FormCheckValid())
                return;

            switch (editType)
            {
                case 1:
                    try
                    {
                        iqcActualDto.HeaderID = HeaderID;
                        iqcActualDto.IQCCheckID = GetLookupValue(lkeIQCCheckID);
                        iqcActualDto.IQCCheckName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(IQCCheckName, '') FROM ASPIQCCheckList WHERE IQCCheckID = '" + GetLookupValue(lkeIQCCheckID).Replace("'", "''") + "'");
                        iqcActualDto.IQCDFID = GetLookupValue(lkeIQCDFID);
                        iqcActualDto.IQCEvalueActual = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCEvalueActual.Text) ? txtIQCEvalueActual.Text : "0");
                        iqcActualDto.IQCStandardMin = !string.IsNullOrEmpty(txtStandardMin.Text) ? txtStandardMin.Text : string.Empty;
                        iqcActualDto.IQCStandardMax = !string.IsNullOrEmpty(txtStandardMax.Text) ? txtStandardMax.Text : string.Empty;
                        iqcActualDto.IQCEvalueResult = !string.IsNullOrEmpty(txtIQCResult.Text) ? txtIQCResult.Text : string.Empty;
                        iqcActualDto.IQCEvalueCheckTime = GetLookupValue(lkeIQCEvalueCheckTime);
                        iqcActualDto.IQCCheckingContent = GetLookupValue(lkeIQCCheckingContent);
                        iqcActualDto.IQCDeviceID = GetLookupValue(lkeIQCDeviceID);
                        iqcActualDto.IQCMeasuringToolID = GetLookupValue(lkeIQCMeasuringToolID);
                        iqcActualDto.IQCCutterID = !string.IsNullOrEmpty(txtIQCCutterID.Text) ? txtIQCCutterID.Text : string.Empty;
                        iqcActualDto.CheckState = Convert.ToString(cboCheckState.EditValue);
                        iqcActualDto.CreatedBy = userName;
                        iqcActualDto.CreatedDate = DateTime.Now;

                        iqcDao.InsertIQCActualCheck(iqcActualDto);

                        if (!string.IsNullOrEmpty(txtIQCEvalueActual2.Text))
                        {
                            iqcActualDto.IQCEvalueActual = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCEvalueActual2.Text) ? txtIQCEvalueActual2.Text : "0");
                            iqcDao.InsertIQCActualCheck(iqcActualDto);
                        }

                        if (!string.IsNullOrEmpty(txtIQCEvalueActual3.Text))
                        {
                            iqcActualDto.IQCEvalueActual = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCEvalueActual3.Text) ? txtIQCEvalueActual3.Text : "0");
                            iqcDao.InsertIQCActualCheck(iqcActualDto);
                        }

                        if (!string.IsNullOrEmpty(txtIQCEvalueActual4.Text))
                        {
                            iqcActualDto.IQCEvalueActual = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCEvalueActual4.Text) ? txtIQCEvalueActual4.Text : "0");
                            iqcDao.InsertIQCActualCheck(iqcActualDto);
                        }

                        if (!string.IsNullOrEmpty(txtIQCEvalueActual5.Text))
                        {
                            iqcActualDto.IQCEvalueActual = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCEvalueActual5.Text) ? txtIQCEvalueActual5.Text : "0");
                            iqcDao.InsertIQCActualCheck(iqcActualDto);
                        }

                        this.Close();

                        XtraMessageBox.Show("Đã thêm thành công nội dung kiểm tra.");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }

                    break;
                case 0:
                    try
                    {
                        if (saveMulti == 0)
                        {
                            iqcActualDto.HeaderID = HeaderID;
                            iqcActualDto.IQCCheckID = GetLookupValue(lkeIQCCheckID);
                            iqcActualDto.IQCCheckName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(IQCCheckName, '') FROM ASPIQCCheckList WHERE IQCCheckID = '" + GetLookupValue(lkeIQCCheckID).Replace("'", "''") + "'");
                            iqcActualDto.IQCDFID = GetLookupValue(lkeIQCDFID);
                            iqcActualDto.IQCStandardMin = !string.IsNullOrEmpty(txtStandardMin.Text) ? txtStandardMin.Text : string.Empty;
                            iqcActualDto.IQCStandardMax = !string.IsNullOrEmpty(txtStandardMax.Text) ? txtStandardMax.Text : string.Empty;
                            iqcActualDto.IQCEvalueResult = !string.IsNullOrEmpty(txtIQCResult.Text) ? txtIQCResult.Text : string.Empty;
                            iqcActualDto.IQCEvalueCheckTime = GetLookupValue(lkeIQCEvalueCheckTime);
                            iqcActualDto.IQCCheckingContent = GetLookupValue(lkeIQCCheckingContent);
                            iqcActualDto.IQCDeviceID = GetLookupValue(lkeIQCDeviceID);
                            iqcActualDto.IQCMeasuringToolID = GetLookupValue(lkeIQCMeasuringToolID);
                            iqcActualDto.IQCCutterID = !string.IsNullOrEmpty(txtIQCCutterID.Text) ? txtIQCCutterID.Text : string.Empty;
                            iqcActualDto.CheckState = Convert.ToString(cboCheckState.EditValue);

                            TextEdit[] txtActuals = { txtIQCEvalueActual, txtIQCEvalueActual2, txtIQCEvalueActual3, txtIQCEvalueActual4, txtIQCEvalueActual5 };

                            for (int i = 0; i < 5; i++)
                            {
                                var textVal = txtActuals[i].Text;
                                long currentAutoID = (i < autoIDs.Count) ? autoIDs[i] : 0;

                                if (currentAutoID > 0)
                                {
                                    if (string.IsNullOrEmpty(textVal))
                                    {
                                        // Nếu người dùng xóa trống giá trị đo, ta xóa dòng tương ứng dưới DB
                                        var delDto = new IQCCheckListDTO { AutoID = currentAutoID };
                                        iqcDao.DeleteDetailIQCActualCheck(delDto);
                                    }
                                    else
                                    {
                                        // Update dòng đã tồn tại
                                        iqcActualDto.AutoID = currentAutoID;
                                        iqcActualDto.IQCEvalueActual = Convert.ToDouble(textVal);
                                        iqcActualDto.LastModifiedBy = userName;
                                        iqcActualDto.LastModifiedDate = DateTime.Now;

                                        iqcDao.UpdateIQCActualCheck(iqcActualDto);
                                    }
                                }
                                else if (!string.IsNullOrEmpty(textVal))
                                {
                                    // Insert dòng mới (Sử dụng cùng CreatedDate của nhóm để tránh bị tách dòng khi tải lại)
                                    iqcActualDto.IQCEvalueActual = Convert.ToDouble(textVal);
                                    iqcActualDto.CreatedBy = userName;
                                    iqcActualDto.CreatedDate = createdDate;

                                    iqcDao.InsertIQCActualCheck(iqcActualDto);
                                }
                            }
                        }
                        else
                        {

                        }

                        this.Close();

                        //XtraMessageBox.Show("Đã cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }

                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
