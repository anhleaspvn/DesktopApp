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
using DevExpress.XtraEditors;
using System.Globalization;
using System.Threading;
using ASPData.ASPDTO;
using DevExpress.Utils.Automation;

namespace ASPProject.ExternalIQC
{
    public partial class frmExternalIQCDetailContentEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public long AutoID;
        public string iqcCheckID, userName, iqcEvalueResult;
        public double iqcTemplateQuantity;
        private DataTable dtIQCCheckContent = new DataTable();
        public DataTable dtSaveMulti = new DataTable();
        private List<string> lstCheckingTime = new List<string>();
        private IQCCheckingDAO iqcDao = new IQCCheckingDAO();
        private IQCCheckListDTO iqcDto = new IQCCheckListDTO();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        #region Load
        public frmExternalIQCDetailContentEdit()
        {
            InitializeComponent();

            this.Load += FrmExternalIQCDetailContentEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }

        private void FrmExternalIQCDetailContentEdit_Load(object sender, EventArgs e)
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

                  

                    break;
                case 0:
                    lkeIQCCheckID.ReadOnly = true;
                    lkeIQCCheckID.Properties.DataSource = iqcDao.GetCheckStateList(iqcCheckID);
                    lkeIQCCheckID.Properties.ValueMember = "IQCCheckID";
                    lkeIQCCheckID.Properties.DisplayMember = "IQCCheckID";
                    lkeIQCCheckID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeIQCCheckID.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeIQCCheckID.EditValue = iqcCheckID;

                    

                    txtIQCTemplateQuantity.Text = iqcTemplateQuantity > 0 ? Convert.ToString(iqcTemplateQuantity) : string.Empty;

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
                        iqcDto.HeaderID = HeaderID;
                        iqcDto.IQCCheckID = Convert.ToString(lkeIQCCheckID.EditValue);
                        iqcDto.IQCCheckName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(IQCCheckName, '') FROM ASPIQCCheckList WHERE IQCCheckID = '" + Convert.ToString(lkeIQCCheckID.EditValue) + "'");
                        iqcDto.IQCCheckCont = !string.IsNullOrEmpty(txtIQCCheckCont.Text) ? txtIQCCheckCont.Text : string.Empty;
                        iqcDto.IQCTemplateQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCTemplateQuantity.Text) ? txtIQCTemplateQuantity.Text : "0");
                        iqcDto.IQCEvalueResult = !string.IsNullOrEmpty(txtEvalueResult.Text) ? txtEvalueResult.Text : string.Empty;
                        iqcDto.IQCPeriodTime = !string.IsNullOrEmpty(txtIQCPeriodTime.Text) ? txtIQCPeriodTime.Text : string.Empty;
                        iqcDto.CreatedBy = userName;
                        iqcDto.CreatedDate = DateTime.Now;

                        iqcDao.InsertIQCCheckContent(iqcDto);
                        iqcDao.GetAllIQCCheckDefect(iqcDto);

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
                            iqcDto.AutoID = AutoID;
                            iqcDto.HeaderID = HeaderID;
                            iqcDto.IQCCheckID = Convert.ToString(lkeIQCCheckID.EditValue);
                            iqcDto.IQCCheckName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(IQCCheckName, '') FROM ASPIQCCheckList WHERE IQCCheckID = '" + Convert.ToString(lkeIQCCheckID.EditValue) + "'");
                            iqcDto.IQCCheckCont = !string.IsNullOrEmpty(txtIQCCheckCont.Text) ? txtIQCCheckCont.Text : string.Empty;
                            iqcDto.IQCTemplateQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtIQCTemplateQuantity.Text) ? txtIQCTemplateQuantity.Text : "0");
                            iqcDto.IQCEvalueResult = !string.IsNullOrEmpty(txtEvalueResult.Text) ? txtEvalueResult.Text : string.Empty;
                            iqcDto.IQCPeriodTime = !string.IsNullOrEmpty(txtIQCPeriodTime.Text) ? txtIQCPeriodTime.Text : string.Empty;
                            iqcDto.LastModifiedBy = userName;
                            iqcDto.LastModifiedDate = DateTime.Now;

                            iqcDao.UpdateIQCCheckContent(iqcDto.AutoID, iqcDto.HeaderID, iqcDto.IQCCheckID, iqcDto.IQCTemplateQuantity, iqcDto.IQCEvalueResult, iqcDto.IQCPeriodTime);
                        }
                        else
                        {
                            //foreach (DataRow drSave in dtSaveMulti.Rows)
                            //{
                            //    detailDefectDto.HeaderID = (long)Convert.ToDouble(drSave["HeaderID"]);
                            //    detailDefectDto.DefectID = Convert.ToString(drSave["DefectID"]);
                            //    detailDefectDto.FQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCQuantity.Text) ? txtFQCQuantity.Text : "0");
                            //    detailDefectDto.FQCScrapQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtScrapFQCQuantity.Text) ? txtScrapFQCQuantity.Text : "0");
                            //    detailDefectDto.PrevFQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtPrevFQCQuantity.Text) ? txtPrevFQCQuantity.Text : "0");
                            //    detailDefectDto.FQCReworkQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCReworkQuantity.Text) ? txtFQCReworkQuantity.Text : "0");
                            //    detailDefectDto.LastModifiedBy = userName;
                            //    detailDefectDto.LastModifiedDate = DateTime.Now;

                            //    prodStatDao.UpdatePSDetailDefect(detailDefectDto);
                            //}
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
            #endregion
        }
    }
}
