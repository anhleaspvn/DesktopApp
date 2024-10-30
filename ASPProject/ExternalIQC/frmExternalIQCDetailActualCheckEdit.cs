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
                            iqcEvalueResult, userName, iqcDeviceID, iqcMeasuringToolID;
        public List<string> lstCheckingTime = new List<string>();
        public double iqcEvalueActual;
        private DataTable dtIQCActualCheck = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

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

            switch (editType)
            {
                case 1:
                    lkeIQCCheckID.Properties.DataSource = iqcDao.GetCheckStateList(string.Empty);
                    lkeIQCCheckID.Properties.ValueMember = "IQCCheckID";
                    lkeIQCCheckID.Properties.DisplayMember = "IQCCheckID";
                    lkeIQCCheckID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeIQCCheckID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    lkeIQCCheckingContent.Properties.DataSource = iqcDao.GetIQCCheckingContentList(string.Empty);
                    lkeIQCCheckingContent.Properties.ValueMember = "IQCCheckingContent";
                    lkeIQCCheckingContent.Properties.DisplayMember = "IQCCheckingContent";
                    lkeIQCCheckingContent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeIQCCheckingContent.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    break;
                case 0:
                    lkeIQCCheckID.ReadOnly = true;
                    lkeIQCCheckID.Properties.DataSource = iqcDao.GetCheckStateList(iqcCheckID);
                    lkeIQCCheckID.Properties.ValueMember = "IQCCheckID";
                    lkeIQCCheckID.Properties.DisplayMember = "IQCCheckID";
                    lkeIQCCheckID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeIQCCheckID.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeIQCCheckID.EditValue = iqcCheckID;

                    //lkeIQCCheckingContent.ReadOnly = true;
                    lkeIQCCheckingContent.Properties.DataSource = iqcDao.GetIQCCheckingContentList(string.Empty);
                    lkeIQCCheckingContent.Properties.ValueMember = "IQCCheckingContent";
                    lkeIQCCheckingContent.Properties.DisplayMember = "IQCCheckingContent";
                    lkeIQCCheckingContent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeIQCCheckingContent.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeIQCCheckingContent.EditValue = "";

                    txtIQCEvalueActual.Text = iqcEvalueActual > 0 ? Convert.ToString(iqcEvalueActual) : string.Empty;
                    txtStandardMin.Text = iqcStandardMin;
                    txtStandardMax.Text = iqcStandardMax;
                    txtIQCDFID.Text = iqcDFID;

                    break;
                default:
                    break;
            }
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
            this.Text = "Form Insert && Update Losstime";
        }

        public bool FormCheckValid()
        {
            if (editType == 1)
            {
                if (string.IsNullOrEmpty(lkeIQCCheckID.EditValue.ToString()))
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
                        iqcActualDto.IQCCheckID = Convert.ToString(lkeIQCCheckID.EditValue);
                        iqcActualDto.IQCCheckName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(IQCCheckName, '') FROM ASPIQCCheckList WHERE IQCCheckID = '" + Convert.ToString(lkeIQCCheckID.EditValue) + "'");
                        iqcActualDto.IQCDFID = !string.IsNullOrEmpty(txtIQCDFID.Text) ? txtIQCDFID.Text : string.Empty;
                        iqcActualDto.IQCEvalueActual = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCEvalueActual.Text) ? txtIQCEvalueActual.Text : "0");
                        iqcActualDto.IQCStandardMin = !string.IsNullOrEmpty(txtStandardMin.Text) ? txtStandardMin.Text : string.Empty;
                        iqcActualDto.IQCStandardMax = !string.IsNullOrEmpty(txtStandardMax.Text) ? txtStandardMax.Text : string.Empty;
                        iqcActualDto.IQCEvalueResult = !string.IsNullOrEmpty(txtIQCResult.Text) ? txtIQCResult.Text : string.Empty;
                        iqcActualDto.IQCEvalueCheckTime = !string.IsNullOrEmpty(txtIQCEvalueCheckTime.Text) ? txtIQCEvalueCheckTime.Text : string.Empty;
                        iqcActualDto.IQCCheckingContent = !string.IsNullOrEmpty(lkeIQCCheckingContent.Text) ? lkeIQCCheckingContent.Text : string.Empty;
                        iqcActualDto.IQCDeviceID = !string.IsNullOrEmpty(txtIQCDeviceID.Text) ? txtIQCDeviceID.Text : string.Empty;
                        iqcActualDto.IQCMeasuringToolID = !string.IsNullOrEmpty(txtIQCMeasuringToolID.Text) ? txtIQCMeasuringToolID.Text : string.Empty;
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
                            iqcActualDto.AutoID = AutoID;
                            iqcActualDto.IQCCheckName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(IQCCheckName, '') FROM ASPIQCCheckList WHERE IQCCheckID = '" + Convert.ToString(lkeIQCCheckID.EditValue) + "'");
                            iqcActualDto.IQCDFID = !string.IsNullOrEmpty(txtIQCDFID.Text) ? txtIQCDFID.Text : string.Empty;
                            iqcActualDto.IQCEvalueActual = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCEvalueActual.Text) ? txtIQCEvalueActual.Text : "0");
                            iqcActualDto.IQCStandardMin = !string.IsNullOrEmpty(txtStandardMin.Text) ? txtStandardMin.Text : string.Empty;
                            iqcActualDto.IQCStandardMax = !string.IsNullOrEmpty(txtStandardMax.Text) ? txtStandardMax.Text : string.Empty;
                            iqcActualDto.IQCEvalueResult = !string.IsNullOrEmpty(txtIQCResult.Text) ? txtIQCResult.Text : string.Empty;
                            iqcActualDto.IQCEvalueCheckTime = !string.IsNullOrEmpty(txtIQCEvalueCheckTime.Text) ? txtIQCEvalueCheckTime.Text : string.Empty;
                            iqcActualDto.IQCCheckingContent = !string.IsNullOrEmpty(lkeIQCCheckingContent.Text) ? lkeIQCCheckingContent.Text : string.Empty;
                            iqcActualDto.IQCDeviceID = !string.IsNullOrEmpty(txtIQCDeviceID.Text) ? txtIQCDeviceID.Text : string.Empty;
                            iqcActualDto.IQCMeasuringToolID = !string.IsNullOrEmpty(txtIQCMeasuringToolID.Text) ? txtIQCMeasuringToolID.Text : string.Empty;
                            iqcActualDto.LastModifiedBy = userName;
                            iqcActualDto.LastModifiedDate = DateTime.Now;

                            iqcDao.UpdateIQCActualCheck(iqcActualDto);
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
