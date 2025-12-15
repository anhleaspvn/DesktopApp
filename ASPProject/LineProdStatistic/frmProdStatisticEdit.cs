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
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors;

namespace ASPProject.LineProdStatistic
{
    public partial class frmProdStatisticEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public long HeaderID;
        public string factoryID, fieldID, shift, WODocNo = string.Empty, productID, prodStatus, userName, passWord;
        public string materialReason, manReason, machineReason, methodReason;
        public double prodStatisticQuantity, prodStatisticEmpQuantity;
        public DateTime statisticDate, prodBeginDate;
        public Boolean IschkQRStart;
        private List<string> lstProdStatus = new List<string>();
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private DataTable dtWODocNoList = new DataTable();
        private DataTable dtProdShift = new DataTable();
        private string LineID = string.Empty;
        private string GWODocNo = string.Empty;
        private string ProductID = string.Empty;
        private double ProdReqQuantity = 0;
        private string ProductType = string.Empty;

        ProdStatisticDTO prodStatDto = new ProdStatisticDTO();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        #endregion

        #region Constructor
        public frmProdStatisticEdit()
        {
            InitializeComponent();

            this.Load += FrmProdStatisticEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
            this.lkeWO.EditValueChanged += LkeWO_EditValueChanged;
        }

        #endregion

        #region Load
        private void FrmProdStatisticEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            this.ActiveControl = lkeWO;
            factoryID = (string)_sqlHelper.ExecQuerySacalar("SELECT FactoryID FROM ASPEmployee WHERE EmpID = '" + userName + "'");

            if (editType == 0)
            {
                lkeWO.ReadOnly = true;
              
                lkeFieldID.EditValue = fieldID;
                lkeStatus.EditValue = prodStatus;
                lkeWO.EditValue = WODocNo;
                dtpStatisDate.EditValue = statisticDate;
                dtpProdBeginDate.EditValue = prodBeginDate;
                lkeProdShift.EditValue = shift;
                txtStatisQuantity.Text = prodStatisticQuantity > 0 ? Convert.ToString(prodStatisticQuantity) : string.Empty;
                txtManStatis.Text = prodStatisticEmpQuantity > 0 ? Convert.ToString(prodStatisticEmpQuantity) : string.Empty;
                chkQRStart.Checked = IschkQRStart;
                rtMaterial.Text = materialReason;
                rtMan.Text = manReason;
                rtMachine.Text = machineReason;
                rtMethod.Text = methodReason;
            }
            else
            {
                chkQRStart.Checked = false;
                HeaderID = ASPGenLongCode();
                lkeFieldID.EditValue = prodStatDao.GetFieldIDList(factoryID).Rows.Count > 0 ? (string)prodStatDao.GetFieldIDList(factoryID).Rows[0][0] : "NNGHE_A";
                lkeProdShift.EditValue = "CA1";
                lkeStatus.EditValue = "Đang sản xuất";
                dtpStatisDate.EditValue = DateTime.Now.Date;
                dtpProdBeginDate.EditValue = Convert.ToDateTime("1900-01-01");
            }

            //fieldID
            lkeFieldID.Properties.DataSource = prodStatDao.GetFieldIDList(factoryID);
            lkeFieldID.Properties.DisplayMember = "Ma_NNghe";
            lkeFieldID.Properties.ValueMember = "Ma_NNghe";
            lkeFieldID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeFieldID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            dtWODocNoList = prodStatDao.GetWODocNoList(userName, WODocNo, editType);

            lkeWO.Properties.DataSource = dtWODocNoList;
            lkeWO.Properties.DisplayMember = "So_Ct";
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;

            //Shift
            dtProdShift = prodStatDao.GetProductShiftList();
            lkeProdShift.Properties.DataSource = dtProdShift;
            lkeProdShift.Properties.DisplayMember = "Ma_Ca";
            lkeProdShift.Properties.ValueMember = "Ma_Ca";
            lkeProdShift.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeProdShift.Properties.PopupFilterMode = PopupFilterMode.Contains;

            //Prod status
            lstProdStatus.Add("Đang sản xuất");
            lstProdStatus.Add("Hoàn thành");

            lkeStatus.Properties.DataSource = lstProdStatus;
            lkeStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeStatus.Properties.PopupFilterMode = PopupFilterMode.Contains;

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
                { "@TableName", "ASPPSHeader" }
            };

            longCode = (long)_sqlHelper.ExecProcedureSacalar("sp_ASPGenLongCode", dicParams);

            return longCode;
        }

        private bool FormCheckValid()
        {
            if (string.IsNullOrEmpty(Convert.ToString(lkeFieldID.EditValue)))
            {
                XtraMessageBox.Show("Vui lòng nhập ngành nghề.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeWO.EditValue)))
            {
                XtraMessageBox.Show("Vui lòng nhập lệnh sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (Convert.ToDateTime(dtpStatisDate.EditValue).Year < 2000)
            {
                XtraMessageBox.Show("Vui lòng nhập ngày thống kê đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (Convert.ToDateTime(dtpProdBeginDate.EditValue).Year < 2000)
            {
                XtraMessageBox.Show("Vui lòng nhập ngày bắt đầu sản xuất đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeStatus.EditValue)))
            {
                XtraMessageBox.Show("Vui lòng nhập tình trạng sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(txtManStatis.Text)))
            {
                XtraMessageBox.Show("Vui lòng nhập số người thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(LineID)))
            {
                XtraMessageBox.Show("Lệnh sản xuất chưa bổ sung Line. Vui lòng bổ sung thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            DataTable dtCheckWO = new DataTable();
            statisticDate = Convert.ToDateTime(dtpStatisDate.EditValue);
            WODocNo = Convert.ToString(lkeWO.EditValue);

            dtCheckWO = prodStatDao.DuplicateCheckWOProdStatistic(WODocNo, statisticDate);

            if (dtCheckWO.Rows.Count > 0 && editType == 1)
            {
                XtraMessageBox.Show("Lệnh sản xuất đã có thống kê trong ngày. Vui lòng kiểm tra để không nhập trùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        #endregion

        #region Event
        private void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormCheckValid())
                    return;

                if (editType == 1) //them moi
                {

                    prodStatDto.HeaderID = ASPGenLongCode();
                    prodStatDto.FieldID = Convert.ToString(lkeFieldID.EditValue);
                    prodStatDto.LineID = LineID;
                    prodStatDto.DocDate = DateTime.Now;
                    prodStatDto.StatisticDate = Convert.ToDateTime(dtpStatisDate.EditValue);

                    if (string.IsNullOrEmpty(dtpProdBeginDate.EditValue.ToString()))
                        dtpProdBeginDate.EditValue = "1900/01/01";

                    prodStatDto.ProdBeginDate = Convert.ToDateTime(dtpProdBeginDate.EditValue);
                    prodStatDto.ProdShift = Convert.ToString(lkeProdShift.EditValue);
                    prodStatDto.WODocNo = Convert.ToString(lkeWO.EditValue);
                    prodStatDto.GWODocNo = GWODocNo;
                    prodStatDto.ProductID = ProductID;
                    prodStatDto.ProductType = ProductType;
                    prodStatDto.ProdReqQuantity = ProdReqQuantity;
                    prodStatDto.ProdStatus = Convert.ToString((lkeStatus.EditValue));
                    prodStatDto.ProdStatisticQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtStatisQuantity.Text) ? txtStatisQuantity.Text : "0");
                    prodStatDto.ProdStatisticEmpQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtManStatis.Text) ? txtManStatis.Text : "0");

                    prodStatDto.CreatedBy = userName;
                    prodStatDto.CreatedDate = DateTime.Now;
                    prodStatDto.QRStart = Convert.ToBoolean(chkQRStart.EditValue);

                    prodStatDao.InsertProdStatisticHeader(prodStatDto);

                    prodStatDao.InsertEmpListByLine(prodStatDto.HeaderID, prodStatDto.LineID);
                    //prodStatDao.InsertMachineListByLine(prodStatDto.HeaderID);
                    prodStatDao.InsertPSDetailMachineList(prodStatDto.HeaderID);
                    prodStatDao.InsertPSDetailDefectModeList(prodStatDto.HeaderID);
                    prodStatDao.InsertPSDetailLosstimeList(prodStatDto.HeaderID);
                    prodStatDao.InsertPSDetailMoldList(prodStatDto.HeaderID);
                }
                else
                {
                    prodStatDto.HeaderID = HeaderID;
                    prodStatDto.FieldID = Convert.ToString(lkeFieldID.EditValue);
                    prodStatDto.DocDate = DateTime.Now;
                    prodStatDto.StatisticDate = Convert.ToDateTime(dtpStatisDate.EditValue);

                    if (string.IsNullOrEmpty(dtpProdBeginDate.EditValue.ToString()))
                        dtpProdBeginDate.EditValue = "1900/01/01";

                    prodStatDto.ProdBeginDate = Convert.ToDateTime(dtpProdBeginDate.EditValue);
                    prodStatDto.ProdShift = Convert.ToString(lkeProdShift.EditValue);
                    prodStatDto.ProdStatus = Convert.ToString((lkeStatus.EditValue));
                    prodStatDto.ProdStatisticQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtStatisQuantity.Text) ? txtStatisQuantity.Text : "0");
                    prodStatDto.ProdStatisticEmpQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtManStatis.Text) ? txtManStatis.Text : "0");

                    prodStatDto.LastModifiedBy = userName;
                    prodStatDto.LastModifiedDate = DateTime.Now;
                    prodStatDto.MaterialReason = !string.IsNullOrEmpty(rtMaterial.Text) ? rtMaterial.Text: string.Empty;
                    prodStatDto.ManReason = !string.IsNullOrEmpty(rtMan.Text) ? rtMan.Text : string.Empty;
                    prodStatDto.MachineReason = !string.IsNullOrEmpty(rtMachine.Text) ? rtMachine.Text : string.Empty;
                    prodStatDto.MethodReason = !string.IsNullOrEmpty(rtMethod.Text) ? rtMethod.Text : string.Empty;

                    if (Convert.ToString(lkeFieldID.EditValue) != fieldID)
                    {
                        if (XtraMessageBox.Show("Bạn có chắc chắn muốn thay đổi ngành nghề LSX này không? Khi thay đổi phải nhập thống kê máy và defect mode lại.", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            prodStatDao.UpdateProdStatisticHeader(prodStatDto);
                            prodStatDao.InsertPSDetailMachineList(prodStatDto.HeaderID);
                            prodStatDao.InsertPSDetailDefectModeList(prodStatDto.HeaderID);
                        }
                    }
                    else
                    {
                        prodStatDao.UpdateProdStatisticHeader(prodStatDto);
                    }

                    //update scan QR Code
                    if (!string.IsNullOrEmpty(chkQRStart.EditValue.ToString()))
                    {
                        prodStatDto.QRStart = (bool)chkQRStart.EditValue;
                        prodStatDao.UpdateQRStart(prodStatDto);
                    }
                        
                }
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LkeWO_Validated(object sender, EventArgs e)
        {
            string WODocNo = Convert.ToString(lkeWO.EditValue);
            try
            {
                if (!string.IsNullOrEmpty(WODocNo))
                {
                    var row = dtWODocNoList.AsEnumerable().Where(myRow => myRow.Field<string>("So_Ct") == WODocNo);

                    LineID = row.Select(x => x.Field<string>("Ma_Day_Chuyen")).FirstOrDefault();
                    GWODocNo = row.Select(s => s.Field<string>("So_Ct_LSX_Cha")).FirstOrDefault();
                    ProductID = row.Select(s => s.Field<string>("Ma_Sp")).FirstOrDefault();
                    ProdReqQuantity = Convert.ToDouble(row.Select(s => s.Field<decimal>("So_Luong9")).FirstOrDefault());
                    ProductType = row.Select(s => s.Field<string>("Loai_Vt")).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LkeWO_EditValueChanged(object sender, EventArgs e)
        {
            string WODocNo = Convert.ToString(lkeWO.EditValue);
            dtWODocNoList = prodStatDao.GetWODocNoList(userName, WODocNo, editType);
            try
            {
                if (!string.IsNullOrEmpty(WODocNo))
                {
                    var row = dtWODocNoList.AsEnumerable().Where(myRow => myRow.Field<string>("So_Ct") == WODocNo);

                    LineID = row.Select(x => x.Field<string>("Ma_Day_Chuyen")).FirstOrDefault();
                    GWODocNo = row.Select(s => s.Field<string>("So_Ct_LSX_Cha")).FirstOrDefault();
                    ProductID = row.Select(s => s.Field<string>("Ma_Sp")).FirstOrDefault();
                    ProdReqQuantity = Convert.ToDouble(row.Select(s => s.Field<decimal>("So_Luong9")).FirstOrDefault());
                    ProductType = row.Select(s => s.Field<string>("Loai_Vt")).FirstOrDefault();

                    if (Convert.ToDateTime(dtpProdBeginDate.EditValue).Year <= 2000)
                    {
                        dtpProdBeginDate.EditValue = prodStatDao.GetPSProdBeginDate(LineID, WODocNo);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
