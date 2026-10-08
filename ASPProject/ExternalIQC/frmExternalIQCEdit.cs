using ASPData.ASPDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors;
using ASPData.ProdStatisticDTO;
using ASPData;
using ASPData.ASPDTO;

namespace ASPProject.ExternalIQC
{
    public partial class frmExternalIQCEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public long HeaderID;
        public string factoryID, lineID, WODocNo = string.Empty, qcID, productID, customerID, prodStatus, checkState, stageOfChecking, userName, passWord;
        public double prodReqQuantity;
        public DateTime docDate;
        private List<string> lstProdStatus = new List<string>();
        private List<string> lstCheckState = new List<string>();
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtWODocNoList = new DataTable();
        private DataTable dtFactoryList = new DataTable();
        private DataTable dtLineList = new DataTable();
  
        //private DataTable dtProductList = new DataTable();
        private string LineID = string.Empty;
        private string ProductID = string.Empty;
        private string CustomerID = string.Empty;
        private double ProdReqQuantity = 0;

        IQCCheckingDTO iqcCheckingDto = new IQCCheckingDTO();
        IQCCheckingDAO iqcCheckingDao = new IQCCheckingDAO();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        ASPDAO aspDao = new ASPDAO();
        #endregion

        #region Constructor
        public frmExternalIQCEdit()
        {
            InitializeComponent();

            this.Load += FrmExternalIQCEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
            this.lkeWO.EditValueChanged += LkeWO_EditValueChanged;
            this.lkeLine.EditValueChanged += LkeLine_EditValueChanged;
        }
        #endregion

        #region Load
        private void FrmExternalIQCEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            if (editType == 0)
            {
                LineID = lineID;
                ProductID = productID;
                CustomerID = customerID;
                ProdReqQuantity = prodReqQuantity;
                lkeWO.ReadOnly = true;
                lkeWO.EditValue = WODocNo;
                lkeStatus.EditValue = prodStatus;
                lkeFactoryID.EditValue = factoryID;
                txtIDQC.Text = qcID;
                lkeCheckState.EditValue = checkState;
              
                dtpDocDate.EditValue = docDate;
            }
            else
            {
                //load EmpID
                HeaderID = ASPGenLongCode();
                dtpDocDate.EditValue = DateTime.Now.Date;
            }

            //WO List
            dtWODocNoList = iqcCheckingDao.GetWODocNoListByLine(LineID, WODocNo, editType);

            lkeWO.Properties.DataSource = dtWODocNoList;
            lkeWO.Properties.DisplayMember = "So_Ct";
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            //Prod status
            lstProdStatus.Add("Pilot");
            lstProdStatus.Add("Sample");
            lstProdStatus.Add("MP");

            lkeStatus.Properties.DataSource = lstProdStatus;
            lkeStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeStatus.Properties.PopupFilterMode = PopupFilterMode.Contains;

            //Factory list
            dtFactoryList = aspDao.GetFactoryList();
            lkeFactoryID.Properties.DataSource = dtFactoryList;
            lkeFactoryID.Properties.DisplayMember = "Ten_NhaMay";
            lkeFactoryID.Properties.ValueMember = "Ma_NhaMay";
            lkeFactoryID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeFactoryID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            //Check state list
            lstCheckState.Add("FAI");
            lstCheckState.Add("Tuần kiểm");
            lkeCheckState.Properties.DataSource = lstCheckState;
            lkeCheckState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeCheckState.Properties.PopupFilterMode = PopupFilterMode.Contains;

            //line list
            dtLineList = aspDao.GetLineList();
            lkeLine.Properties.DataSource = dtLineList;
            lkeLine.Properties.DisplayMember = "Ten_Day_Chuyen";
            lkeLine.Properties.ValueMember = "Ma_Day_Chuyen";
            lkeLine.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeLine.Properties.PopupFilterMode = PopupFilterMode.Contains;

            if (editType == 0)
            {
                lkeLine.EditValue = LineID;
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

        public long ASPGenLongCode()
        {
            long longCode = 0;

            var dicParams = new Dictionary<string, object> {
                { "@ColumnID", "HeaderID" },
                { "@TableName", "ASPIQCHeader" }
            };

            longCode = (long)_sqlHelper.ExecProcedureSacalar("sp_ASPGenLongCode", dicParams);

            return longCode;
        }

        private bool FormCheckValid()
        {
            LineID = !string.IsNullOrEmpty(Convert.ToString(lkeLine.EditValue)) ? Convert.ToString(lkeLine.EditValue) : LineID;
            WODocNo = Convert.ToString(lkeWO.EditValue);

            if (string.IsNullOrEmpty(Convert.ToString(dtpDocDate.EditValue)) || Convert.ToDateTime(dtpDocDate.EditValue).Year < 2000)
            {
                XtraMessageBox.Show("Vui long nhap ngay nhap dung.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeFactoryID.EditValue)))
            {
                XtraMessageBox.Show("Vui long chon nha may.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(LineID))
            {
                XtraMessageBox.Show("Vui long chon Ma Line.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeWO.EditValue)))
            {
                XtraMessageBox.Show("Vui long chon lenh san xuat.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(txtIDQC.Text))
            {
                XtraMessageBox.Show("Vui long nhap ID of QC.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeStatus.EditValue)))
            {
                XtraMessageBox.Show("Vui long chon tinh trang san xuat.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeCheckState.EditValue)))
            {
                XtraMessageBox.Show("Vui long chon trang thai kiem tra.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
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
            try
            {
                if (!FormCheckValid())
                    return;

                if (editType == 1)
                {
                    iqcCheckingDto.HeaderID = ASPGenLongCode();
                    iqcCheckingDto.FactoryID = Convert.ToString(lkeFactoryID.EditValue);
                    iqcCheckingDto.DocDate = Convert.ToDateTime(dtpDocDate.EditValue);
                    iqcCheckingDto.LineID = LineID;
                    iqcCheckingDto.QCID = txtIDQC.Text;
                    iqcCheckingDto.ProductID = ProductID;
                    iqcCheckingDto.WODocNo = WODocNo;
                    iqcCheckingDto.ProdReqQuantity = ProdReqQuantity;
                    iqcCheckingDto.CustomerID = CustomerID;
                    iqcCheckingDto.ProdStatus = Convert.ToString(lkeStatus.EditValue);
                    iqcCheckingDto.CheckState = Convert.ToString(lkeCheckState.EditValue);
                   
                    iqcCheckingDto.CreatedBy = userName;
                    iqcCheckingDto.CreatedDate = DateTime.Now;

                    iqcCheckingDao.InsertIQCCheckingHeader(iqcCheckingDto);
                   
                }
                else
                {
                    iqcCheckingDto.HeaderID = HeaderID;
                    iqcCheckingDto.FactoryID = Convert.ToString(lkeFactoryID.EditValue);
                    iqcCheckingDto.DocDate = Convert.ToDateTime(dtpDocDate.EditValue);
                    iqcCheckingDto.LineID = LineID;
                    iqcCheckingDto.QCID = txtIDQC.Text;
                    iqcCheckingDto.ProductID = ProductID;
                    iqcCheckingDto.WODocNo = WODocNo;
                    iqcCheckingDto.ProdReqQuantity = ProdReqQuantity;
                    iqcCheckingDto.CustomerID = CustomerID;
                    iqcCheckingDto.ProdStatus = Convert.ToString(lkeStatus.EditValue);
                    iqcCheckingDto.CheckState = Convert.ToString(lkeCheckState.EditValue);
                  
                    iqcCheckingDto.LastModifiedBy = userName;
                    iqcCheckingDto.LastModifiedDate = DateTime.Now;

                    iqcCheckingDao.UpdateIQCCheckingHeader(iqcCheckingDto);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkeWO_EditValueChanged(object sender, EventArgs e)
        {
            string selectedWODocNo = Convert.ToString(lkeWO.EditValue);
            string selectedLineID = !string.IsNullOrEmpty(Convert.ToString(lkeLine.EditValue)) ? Convert.ToString(lkeLine.EditValue) : LineID;
            dtWODocNoList = iqcCheckingDao.GetWODocNoListByLine(selectedLineID, selectedWODocNo, editType);
            try
            {
                if (!string.IsNullOrEmpty(selectedWODocNo))
                {
                    var row = dtWODocNoList.AsEnumerable().FirstOrDefault(myRow => myRow.Field<string>("So_Ct") == selectedWODocNo);

                    this.WODocNo = selectedWODocNo;

                    if (row == null)
                        return;

                    string woLineID = Convert.ToString(row["Ma_Day_Chuyen"]);
                    LineID = !string.IsNullOrEmpty(woLineID) ? woLineID : selectedLineID;
                    ProductID = Convert.ToString(row["Ma_Sp"]);
                    ProdReqQuantity = row["So_Luong9"] != DBNull.Value ? Convert.ToDouble(row["So_Luong9"]) : 0;
                    CustomerID = Convert.ToString(row["Ma_Dt_Kh"]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LkeLine_EditValueChanged(object sender, EventArgs e)
        {
            LineID = Convert.ToString(lkeLine.EditValue);
            string selectedWODocNo = editType == 0 ? WODocNo : string.Empty;
            dtWODocNoList = iqcCheckingDao.GetWODocNoListByLine(LineID, selectedWODocNo, editType);

            lkeWO.Properties.DataSource = dtWODocNoList;
            lkeWO.Properties.DisplayMember = "So_Ct";
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            if (editType == 0 && !string.IsNullOrEmpty(WODocNo))
            {
                lkeWO.EditValue = WODocNo;
            }
        }
        #endregion
    }
}
