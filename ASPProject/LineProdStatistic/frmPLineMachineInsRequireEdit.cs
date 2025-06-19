using ASPData;
using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.Cmp;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPLineMachineInsRequireEdit : DevExpress.XtraEditors.XtraForm
    {
        #region declaration
        public long autoID;
        public int editType; public double requireQuantity;
        public DateTime docDate;
        public string userName, lineID, woDocNo, productID, stageID, machineID, requireStatus, materialID;
        public bool isPriority = false;

        PLineMachineIns prodDto = new PLineMachineIns();
        ProdStatisticDAO prodDao = new ProdStatisticDAO();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion
        public frmPLineMachineInsRequireEdit()
        {
            InitializeComponent();

            this.Load += FrmPLineMachineInsRequireEdit_Load;
            this.lkeWO.EditValueChanged += LkeWO_EditValueChanged;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }

        #region Load
        private void FrmPLineMachineInsRequireEdit_Load(object sender, EventArgs e)
        {
            txtLineID.Text = Convert.ToString(_sqlHelper.ExecQuerySacalar("SELECT LineID FROM ASPEmployee WHERE EmpID = '" + userName + "'"));
            //lkeLineID.Text = Convert.ToString(_sqlHelper.ExecQuerySacalar("SELECT LineID FROM ASPEmployee WHERE EmpID = '" + userName + "'"));
            DataTable dtMachine = new DataTable();
            DataTable dtMat = new DataTable();
            if (editType == 0) //chinh sua
            {
                dtpDocDate.EditValue = docDate;
                lkeWO.EditValue = woDocNo;
                txtProductID.EditValue = productID;
                lkeStageID.EditValue = stageID;
                lkeMachineID.EditValue = machineID;
                lkeRequireStatus.EditValue = requireStatus;
                lkeMaterialID.EditValue= materialID;
                txtQuantityMat.EditValue = requireQuantity > 0 ? Convert.ToString(requireQuantity) : string.Empty;
                chkPriority.Checked = isPriority;
            }
            else //tao moi
            {
                dtpDocDate.EditValue = DateTime.Now;
                lkeMachineID.EditValue = string.Empty;
                lkeMaterialID.EditValue = string.Empty;
                chkPriority.Checked = false;
            }

            DataTable dtWODocNoList = prodDao.GetWODocNoList(userName, string.Empty, editType);

            lkeWO.Properties.DataSource = dtWODocNoList;
            lkeWO.Properties.DisplayMember = "So_Ct";
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            string WODocNo = string.IsNullOrEmpty(lkeWO.EditValue.ToString()) ? string.Empty : lkeWO.EditValue.ToString();
            txtProductID.EditValue = (string)_sqlHelper.ExecQuerySacalar("SELECT Ma_Sp FROM L14CTLSXASP WHERE So_Ct = '" + WODocNo + "'");

            //List<string> lstReqStatus = new List<string>();
            //lstReqStatus.Add("Setup mới");
            //lstReqStatus.Add("Sửa máy");
            //lstReqStatus.Add("Sửa Jig");

            DataTable dtReqStatus = _sqlHelper.ExecQueryDataAsDataTable("SELECT RequiredStatus FROM ASPTechRequiredStatus");

            lkeRequireStatus.Properties.DataSource = dtReqStatus;
            lkeRequireStatus.Properties.DisplayMember = "RequiredStatus";
            lkeRequireStatus.Properties.ValueMember = "RequiredStatus";
            lkeRequireStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeRequireStatus.Properties.PopupFilterMode = PopupFilterMode.Contains;

            var dicParams = new Dictionary<string, object>()
            {
                { "@ProductID",  productID}
            };

            DataTable dtStage = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetStageForMachineIns", dicParams);

            lkeStageID.Properties.DataSource = dtStage;
            lkeStageID.Properties.DisplayMember = "StageID";
            lkeStageID.Properties.ValueMember = "StageID";
            lkeStageID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeStageID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            dtMachine = _sqlHelper.ExecQueryDataAsDataTable("SELECT MachineID, MachineName FROM ASPMachine");

            lkeMachineID.Properties.DataSource = dtMachine;
            lkeMachineID.Properties.DisplayMember = "MachineID";
            lkeMachineID.Properties.ValueMember = "MachineID";
            lkeMachineID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeMachineID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            dicParams = new Dictionary<string, object>()
            {
                { "@ProductID", txtProductID.Text.Trim() }
            };

            dtMat = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetMaterialListOfProduct", dicParams);

            lkeMaterialID.Properties.DataSource = dtMat;
            lkeMaterialID.Properties.DisplayMember = "MaterialID";
            lkeMaterialID.Properties.ValueMember = "MaterialID";
            lkeMaterialID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeMaterialID.Properties.PopupFilterMode = PopupFilterMode.Contains;
        }

        #endregion
        #region event
        private void LkeWO_EditValueChanged(object sender, EventArgs e)
        {
            string WODocNo = string.IsNullOrEmpty(lkeWO.EditValue.ToString()) ? string.Empty : lkeWO.EditValue.ToString();
            productID = (string)_sqlHelper.ExecQuerySacalar("SELECT Ma_Sp FROM L14CTLSXASP WHERE So_Ct = '" + WODocNo + "'");

            txtProductID.Text = productID;

            var dicParams = new Dictionary<string, object>()
            {
                { "@ProductID",  productID}
            };

            DataTable dtStage = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetStageForMachineIns", dicParams);

            lkeStageID.Properties.DataSource = dtStage;
            lkeStageID.Properties.DisplayMember = "StageID";
            lkeStageID.Properties.ValueMember = "StageID";
            lkeStageID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeStageID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            dicParams = new Dictionary<string, object>()
            {
                { "@ProductID", txtProductID.Text.Trim() }
            };

            DataTable dtMat = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetMaterialListOfProduct", dicParams);

            lkeMaterialID.Properties.DataSource = dtMat;
            lkeMaterialID.Properties.DisplayMember = "MaterialID";
            lkeMaterialID.Properties.ValueMember = "MaterialID";
            lkeMaterialID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeMaterialID.Properties.PopupFilterMode = PopupFilterMode.Contains;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (editType == 1) //tao moi
            {
                prodDto.DocDate = Convert.ToDateTime(dtpDocDate.EditValue).Date;
                prodDto.LineID = txtLineID.Text;
                prodDto.WODocNo = Convert.ToString(lkeWO.EditValue);
                prodDto.ProductID = Convert.ToString(txtProductID.Text);
                prodDto.StageID = Convert.ToString(lkeStageID.EditValue);
                prodDto.MachineID = Convert.ToString(lkeMachineID.EditValue);
                prodDto.RequiredStatus = Convert.ToString(lkeRequireStatus.EditValue);
                prodDto.MaterialID = Convert.ToString(lkeMaterialID.EditValue);
                prodDto.MaterialQuantity = !string.IsNullOrEmpty(txtQuantityMat.Text) ? Convert.ToDouble(txtQuantityMat.Text) : 0;
                prodDto.IsPriority = chkPriority.Checked;
                prodDto.CreatedBy = userName;
                prodDto.CreatedDate = DateTime.Now;
                prodDto.LastModifiedBy = userName;
                prodDto.LastModifiedDate = DateTime.Now;

                prodDao.InsertPLineMachineIns(prodDto);

                XtraMessageBox.Show("Đã tạo yêu cầu thành công!");
            }
            else if (editType == 0) //chinh sua
            {
                prodDto.AutoID = (long)Convert.ToDouble(autoID);
                prodDto.DocDate = Convert.ToDateTime(dtpDocDate.EditValue);
                prodDto.LineID = txtLineID.Text;
                prodDto.WODocNo = Convert.ToString(lkeWO.EditValue);
                prodDto.ProductID = Convert.ToString(txtProductID.Text);
                prodDto.StageID = Convert.ToString(lkeStageID.EditValue);
                prodDto.MachineID = Convert.ToString(lkeMachineID.EditValue);
                prodDto.RequiredStatus = Convert.ToString(lkeRequireStatus.EditValue);
                prodDto.MaterialID = Convert.ToString(lkeMaterialID.EditValue);
                prodDto.MaterialQuantity = !string.IsNullOrEmpty(txtQuantityMat.Text) ? Convert.ToDouble(txtQuantityMat.Text) : 0;
                prodDto.IsPriority = chkPriority.Checked;
                prodDto.CreatedBy = userName;
                prodDto.CreatedDate = DateTime.Now;
                prodDto.LastModifiedBy = userName;
                prodDto.LastModifiedDate = DateTime.Now;

                prodDao.UpdatePLineMachineIns(prodDto);
            }

            this.Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
