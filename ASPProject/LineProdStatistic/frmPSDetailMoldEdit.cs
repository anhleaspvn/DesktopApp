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
    public partial class frmPSDetailMoldEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public string MoldID, StampBy, userName;
        public double NumOfStamp, ProdQuantity;
        private DataTable dtMoldList = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailMold detailMoldDto = new PSDetailMold();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        #endregion

        #region Constructor
        public frmPSDetailMoldEdit()
        {
            InitializeComponent();

            this.Load += FrmPSDetailMoldEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmPSDetailMoldEdit_Load(object sender, EventArgs e)
        {
            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
            }

            this.ActiveControl = txtNumOfStamp;

            switch (editType)
            {
                case 1:
                    lkeMoldID.Properties.DataSource = prodStatDao.GetMoldList(string.Empty);
                    lkeMoldID.Properties.ValueMember = "MoldID";
                    lkeMoldID.Properties.DisplayMember = "MoldID";
                    lkeMoldID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeMoldID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    lkeStampBy.Properties.DataSource = prodStatDao.GetEmployeeListByUsername(string.Empty, userName);
                    lkeStampBy.Properties.ValueMember = "EmpID";
                    lkeStampBy.Properties.DisplayMember = "EmpName";
                    lkeStampBy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeStampBy.Properties.PopupFilterMode = PopupFilterMode.Contains;


                    break;
                case 0:
                    lkeMoldID.ReadOnly = true;
                    lkeMoldID.Properties.DataSource = prodStatDao.GetMoldList(MoldID);
                    lkeMoldID.Properties.ValueMember = "MoldID";
                    lkeMoldID.Properties.DisplayMember = "MoldID";
                    lkeMoldID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeMoldID.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeMoldID.EditValue = MoldID;

                    lkeStampBy.Properties.DataSource = prodStatDao.GetEmployeeListByUsername(string.Empty, userName);
                    lkeStampBy.Properties.ValueMember = "EmpID";
                    lkeStampBy.Properties.DisplayMember = "EmpID";
                    lkeStampBy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeStampBy.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeStampBy.EditValue = StampBy;

                    txtNumOfStamp.Text = NumOfStamp > 0 ? Convert.ToString(NumOfStamp) : string.Empty;
                    txtProdQuantity.Text = ProdQuantity > 0 ? Convert.ToString(ProdQuantity) : string.Empty;
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
            this.Text = "Form Insert && Update NumOfStamp";
        }

        public bool FormCheckValid()
        {
            if (editType == 1)
            {
                if (string.IsNullOrEmpty(lkeMoldID.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng nhập mã khuôn.");
                    return false;
                }
            }

            if (string.IsNullOrEmpty(lkeStampBy.EditValue.ToString()))
            {
                XtraMessageBox.Show("Vui lòng nhập người thao tác.");
                return false;
            }

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
                        detailMoldDto.HeaderID = HeaderID;
                        detailMoldDto.MoldID = Convert.ToString(lkeMoldID.EditValue);
                        detailMoldDto.MoldName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(Ten_Khuon, '') FROM L81DMKHUONASP WHERE Ma_Khuon = '" + Convert.ToString(lkeMoldID.EditValue) + "'");
                        detailMoldDto.NumOfStamp = Convert.ToDouble(!string.IsNullOrEmpty(txtNumOfStamp.Text) ? txtNumOfStamp.Text : "0");
                        detailMoldDto.ProdQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtProdQuantity.Text) ? txtProdQuantity.Text : "0");
                        detailMoldDto.StampBy = Convert.ToString(lkeStampBy.EditValue);
                        detailMoldDto.CreatedBy = userName;
                        detailMoldDto.CreatedDate = DateTime.Now;

                        prodStatDao.InsertPSDetailMold(detailMoldDto);

                        this.Close();

                        XtraMessageBox.Show("Đã thêm thành công khuôn.");
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
                            detailMoldDto.HeaderID = HeaderID;
                            detailMoldDto.MoldID = Convert.ToString(lkeMoldID.EditValue);
                            detailMoldDto.MoldName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(Ten_Khuon, '') FROM L81DMKHUONASP WHERE Ma_Khuon = '" + Convert.ToString(lkeMoldID.EditValue) + "'");
                            detailMoldDto.NumOfStamp = Convert.ToDouble(!string.IsNullOrEmpty(txtNumOfStamp.Text) ? txtNumOfStamp.Text : "0");
                            detailMoldDto.ProdQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtProdQuantity.Text) ? txtProdQuantity.Text : "0");
                            detailMoldDto.StampBy = Convert.ToString(lkeStampBy.EditValue);
                            detailMoldDto.LastModifiedBy = userName;
                            detailMoldDto.LastModifiedDate = DateTime.Now;

                            prodStatDao.UpdatePSDetailMold(detailMoldDto);
                        }
                        else
                        {
                            foreach (DataRow row in dtSaveMulti.Rows)
                            {
                                detailMoldDto.HeaderID = (long)Convert.ToDouble(row["HeaderID"]); ;
                                detailMoldDto.MoldID = Convert.ToString(row["MoldID"]);
                                detailMoldDto.MoldName = Convert.ToString(row["MoldName"]);
                                detailMoldDto.NumOfStamp = Convert.ToDouble(!string.IsNullOrEmpty(txtNumOfStamp.Text) ? txtNumOfStamp.Text : "0");
                                detailMoldDto.ProdQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtProdQuantity.Text) ? txtProdQuantity.Text : "0");
                                detailMoldDto.StampBy = Convert.ToString(lkeStampBy.EditValue);
                                detailMoldDto.LastModifiedBy = userName;
                                detailMoldDto.LastModifiedDate = DateTime.Now;

                                prodStatDao.UpdatePSDetailMold(detailMoldDto);
                            }
                        }

                        this.Close();
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
