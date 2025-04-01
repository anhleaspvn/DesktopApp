using ASPData.ASPDAO;
using ASPData.ProdStatisticDTO;
using ASPData;
using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Threading;

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSDetailMachineEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public string machineID, userName;
        public double machineTime;
        private DataTable dtMachineList = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailMachine detailMCDto = new PSDetailMachine();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
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

            this.ActiveControl = txtMachineTime;

            switch (editType)
            {
                case 1:
                    lkeMachineID.Properties.DataSource = prodStatDao.GetMachineList(string.Empty);
                    lkeMachineID.Properties.ValueMember = "MachineID";
                    lkeMachineID.Properties.DisplayMember = "MachineID";
                    lkeMachineID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeMachineID.Properties.PopupFilterMode = PopupFilterMode.Contains;

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

                    txtMachineTime.Text = machineTime > 0 ? Convert.ToString(machineTime) : string.Empty;
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
                        detailMCDto.MachineName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(Ten_May, '') FROM L81DMMAYASP WHERE Ma_May = '" + Convert.ToString(lkeMachineID.EditValue) + "'");
                        detailMCDto.MachineTime = Convert.ToDouble(!string.IsNullOrEmpty(txtMachineTime.Text) ? txtMachineTime.Text : "0");
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
                            detailMCDto.MachineName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(Ten_May, '') FROM L81DMMAYASP WHERE Ma_May = '" + Convert.ToString(lkeMachineID.EditValue) + "'");
                            detailMCDto.MachineTime = Convert.ToDouble(!string.IsNullOrEmpty(txtMachineTime.Text) ? txtMachineTime.Text : "0");
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
                                detailMCDto.MachineName = Convert.ToString(row["MachineName"]);
                                detailMCDto.MachineTime = Convert.ToDouble(!string.IsNullOrEmpty(txtMachineTime.Text) ? txtMachineTime.Text : "0");
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
