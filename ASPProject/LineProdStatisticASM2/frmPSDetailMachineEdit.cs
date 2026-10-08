using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using ASPData;
using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Threading;

namespace ASPProject.LineProdStatisticASM2
{
    public partial class frmPSDetailMachineEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public string machineID, userName, moldID;
        public double machineTime, machineTimePlan, settingMoldTime, startingTime, settingMachineTime, offMachineTime, downTime, cycleTime, qtyPlan, qtyNG;
        private DataTable dtMachineList = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailMachine detailMCDto = new PSDetailMachine();
        ProdStatisticASM2DAO prodStatDao = new ProdStatisticASM2DAO();
        #endregion

        #region Constructor
        public frmPSDetailMachineEdit()
        {
            InitializeComponent();

            this.Load += FrmPSDetailMachineEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmPSDetailMachineEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            this.ActiveControl = txtMachineTimePlan;

            switch (editType)
            {
                case 1:
                    lkeMachineID.Properties.DataSource = prodStatDao.GetMachineList(string.Empty);
                    lkeMachineID.Properties.ValueMember = "MachineID";
                    lkeMachineID.Properties.DisplayMember = "MachineID";
                    lkeMachineID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeMachineID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    lkeMoldID.Properties.DataSource = prodStatDao.GetMoldList(string.Empty);
                    lkeMoldID.Properties.ValueMember = "MoldID";
                    lkeMoldID.Properties.DisplayMember = "MoldID";
                    lkeMoldID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeMoldID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    //txtMachineTime.Text = "0";
                    break;
                case 0:
                    lkeMachineID.ReadOnly = true;
                    lkeMachineID.Properties.DataSource = prodStatDao.GetMachineList(machineID);
                    lkeMachineID.Properties.ValueMember = "MachineID";
                    lkeMachineID.Properties.DisplayMember = "MachineID";
                    lkeMachineID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeMachineID.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeMachineID.EditValue = machineID;

                    lkeMoldID.Properties.DataSource = prodStatDao.GetMoldList(string.Empty);
                    lkeMoldID.Properties.ValueMember = "MoldID";
                    lkeMoldID.Properties.DisplayMember = "MoldID";
                    lkeMoldID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeMoldID.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeMoldID.EditValue = moldID;

                    txtMachineTimePlan.Text = machineTime > 0 ? Convert.ToString(machineTime) : string.Empty;
                    txtCycleTime.Text = cycleTime > 0 ? Convert.ToString(cycleTime) : string.Empty;
                    txtQtyFG.Text = qtyPlan > 0 ? Convert.ToString(qtyPlan) : string.Empty;
                    txtQtyNG.Text = qtyNG > 0 ? Convert.ToString(qtyNG): string.Empty;

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
            this.Text = "Form Insert && Update Machinetime";
        }

        public bool FormCheckValid()
        {
            if (editType == 1)
            {
                if (string.IsNullOrEmpty(lkeMachineID.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng nhập mã máy.");
                    return false;
                }
            }

            //if (string.IsNullOrEmpty(txtMachineTime.Text))
            //{
            //    XtraMessageBox.Show("Vui lòng nhập số giờ máy.");
            //    return false;
            //}

            return true;
        }
        #endregion

        #region Event
        private void BtSave_Click(object sender, EventArgs e)
        {
            if (!FormCheckValid())
                return;

            switch (editType)
            {
                case 1:
                    try
                    {
                        detailMCDto.HeaderID = HeaderID;
                        detailMCDto.MachineID = Convert.ToString(lkeMachineID.EditValue);
                        detailMCDto.MoldID = Convert.ToString(lkeMoldID.EditValue);
                        detailMCDto.MachineName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(Ten_May, '') FROM L81DMMAYASP WHERE Ma_May = '" + Convert.ToString(lkeMachineID.EditValue) + "'");
                        detailMCDto.MachineTimePlan = Convert.ToDouble(!string.IsNullOrEmpty(txtMachineTimePlan.Text) ? txtMachineTimePlan.Text : "0");
                        detailMCDto.SettingMoldTime = 0;//Convert.ToDouble(!string.IsNullOrEmpty(txtSettingMoldTime.Text) ? txtSettingMoldTime.Text : "0");
                        detailMCDto.StartingTime = 0;//Convert.ToDouble(!string.IsNullOrEmpty(txtStartTime.Text) ? txtStartTime.Text : "0");
                        detailMCDto.SettingMachineTime = 0; //Convert.ToDouble(!string.IsNullOrEmpty(txtSettingMachineTime.Text) ? txtSettingMachineTime.Text : "0");
                        detailMCDto.OffMachineTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtOffMachineTime.Text) ? txtOffMachineTime.Text : "0");
                        detailMCDto.DownTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtDownTime.Text) ? txtDownTime.Text : "0");
                        detailMCDto.CycleTime = Convert.ToDouble(!string.IsNullOrEmpty(txtCycleTime.Text) ? txtCycleTime.Text : "0");
                        detailMCDto.QtyFG = Convert.ToDouble(!string.IsNullOrEmpty(txtQtyFG.Text) ? txtQtyFG.Text : "0");
                        detailMCDto.QtyNG = Convert.ToDouble(!string.IsNullOrEmpty(txtQtyNG.Text) ? txtQtyNG.Text : "0");
                        detailMCDto.CreatedBy = userName;
                        detailMCDto.CreatedDate = DateTime.Now;

                        prodStatDao.InsertPSDetailMachine(detailMCDto);

                        this.Close();

                        XtraMessageBox.Show("Đã thêm thành công máy.");
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
                            detailMCDto.HeaderID = HeaderID;
                            detailMCDto.MachineID = Convert.ToString(lkeMachineID.EditValue);
                            detailMCDto.MoldID = Convert.ToString(lkeMoldID.EditValue);
                            detailMCDto.MachineName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(Ten_May, '') FROM L81DMMAYASP WHERE Ma_May = '" + Convert.ToString(lkeMachineID.EditValue) + "'");
                            detailMCDto.MachineTimePlan = Convert.ToDouble(!string.IsNullOrEmpty(txtMachineTimePlan.Text) ? txtMachineTimePlan.Text : "0");
                            detailMCDto.SettingMoldTime = 0; //Convert.ToDouble(!string.IsNullOrEmpty(txtSettingMoldTime.Text) ? txtSettingMoldTime.Text : "0");
                            detailMCDto.StartingTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtStartTime.Text) ? txtStartTime.Text : "0");
                            detailMCDto.SettingMachineTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtSettingMachineTime.Text) ? txtSettingMachineTime.Text : "0");
                            detailMCDto.OffMachineTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtOffMachineTime.Text) ? txtOffMachineTime.Text : "0");
                            detailMCDto.DownTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtDownTime.Text) ? txtDownTime.Text : "0");
                            detailMCDto.CycleTime = Convert.ToDouble(!string.IsNullOrEmpty(txtCycleTime.Text) ? txtCycleTime.Text : "0");
                            detailMCDto.QtyFG = Convert.ToDouble(!string.IsNullOrEmpty(txtQtyFG.Text) ? txtQtyFG.Text : "0");
                            detailMCDto.QtyNG = Convert.ToDouble(!string.IsNullOrEmpty(txtQtyNG.Text) ? txtQtyNG.Text : "0");
                            detailMCDto.LastModifiedBy = userName;
                            detailMCDto.LastModifiedDate = DateTime.Now;

                            prodStatDao.UpdatePSDetailMachine(detailMCDto);
                        }
                        else
                        {
                            foreach (DataRow row in dtSaveMulti.Rows)
                            {
                                detailMCDto.HeaderID = (long)Convert.ToDouble(row["HeaderID"]); ;
                                detailMCDto.MachineID = Convert.ToString(row["MachineID"]);
                                detailMCDto.MoldID = Convert.ToString(row["MoldID"]);
                                detailMCDto.MachineName = Convert.ToString(row["MachineName"]);
                                detailMCDto.MachineTimePlan = 0; //Convert.ToDouble(!string.IsNullOrEmpty(txtMachineTimePlan.Text) ? txtMachineTimePlan.Text : "0");
                                detailMCDto.SettingMoldTime = 0; //Convert.ToDouble(!string.IsNullOrEmpty(txtSettingMoldTime.Text) ? txtSettingMoldTime.Text : "0");
                                detailMCDto.StartingTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtStartTime.Text) ? txtStartTime.Text : "0");
                                detailMCDto.SettingMachineTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtSettingMachineTime.Text) ? txtSettingMachineTime.Text : "0");
                                detailMCDto.OffMachineTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtOffMachineTime.Text) ? txtOffMachineTime.Text : "0");
                                detailMCDto.DownTime = 0;  //Convert.ToDouble(!string.IsNullOrEmpty(txtDownTime.Text) ? txtDownTime.Text : "0");
                                detailMCDto.CycleTime = Convert.ToDouble(!string.IsNullOrEmpty(txtCycleTime.Text) ? txtCycleTime.Text : "0");
                                detailMCDto.QtyFG = Convert.ToDouble(!string.IsNullOrEmpty(txtQtyFG.Text) ? txtQtyFG.Text : "0");
                                detailMCDto.QtyNG = Convert.ToDouble(!string.IsNullOrEmpty(txtQtyNG.Text) ? txtQtyNG.Text : "0");
                                detailMCDto.LastModifiedBy = userName;
                                detailMCDto.LastModifiedDate = DateTime.Now;

                                prodStatDao.UpdatePSDetailMachine(detailMCDto);
                            }
                        }


                        this.Close();

                        //XtraMessageBox.Show("Đã cập nhật thành công máy.");
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
        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
