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

namespace ASPProject.LineProdStatistic
{
    public partial class frmPSDetailLosstimeEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public string losstimeID, userName;
        public double losstimeNum;
        private DataTable dtLosstimeList = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailLosstime detailLTDto = new PSDetailLosstime();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        #endregion

        #region Constructor
        public frmPSDetailLosstimeEdit()
        {
            InitializeComponent();

            this.Load += FrmPSDetailLosstimeEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmPSDetailLosstimeEdit_Load(object sender, EventArgs e)
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
                    lkeLosstimeID.Properties.DataSource = prodStatDao.GetLosstimeList(string.Empty);
                    lkeLosstimeID.Properties.ValueMember = "LosstimeID";
                    lkeLosstimeID.Properties.DisplayMember = "LosstimeID";
                    lkeLosstimeID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeLosstimeID.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    txtLosstimeNum.Text = "0";
                    break;
                case 0:
                    lkeLosstimeID.ReadOnly = true;
                    lkeLosstimeID.Properties.DataSource = prodStatDao.GetLosstimeList(losstimeID);
                    lkeLosstimeID.Properties.ValueMember = "LosstimeID";
                    lkeLosstimeID.Properties.DisplayMember = "LosstimeID";
                    lkeLosstimeID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeLosstimeID.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeLosstimeID.EditValue = losstimeID;

                    txtLosstimeNum.Text = Convert.ToString(losstimeNum);
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
                if (string.IsNullOrEmpty(lkeLosstimeID.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng nhập mã losstime.");
                    return false;
                }
            }
            
            if (string.IsNullOrEmpty(txtLosstimeNum.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập số giờ losstime.");
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
            if (!FormCheckValid())
                return;

            switch (editType)
            {
                case 1:
                    try
                    {
                        detailLTDto.HeaderID = HeaderID;
                        detailLTDto.LosstimeID = Convert.ToString(lkeLosstimeID.EditValue);
                        detailLTDto.LosstimeName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(LosstimeName, '') FROM ASPLosstime WHERE LosstimeID = '" + Convert.ToString(lkeLosstimeID.EditValue) + "'");
                        detailLTDto.LosstimeNum = Convert.ToDouble(txtLosstimeNum.Text);
                        detailLTDto.CreatedBy = userName;
                        detailLTDto.CreatedDate = DateTime.Now;

                        prodStatDao.InsertPSDetailLosstime(detailLTDto);

                        this.Close();

                        XtraMessageBox.Show("Đã thêm thành công Losstime.");
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
                            detailLTDto.HeaderID = HeaderID;
                            detailLTDto.LosstimeID = Convert.ToString(lkeLosstimeID.EditValue);
                            detailLTDto.LosstimeName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(LosstimeName, '') FROM ASPLosstime WHERE LosstimeID = '" + Convert.ToString(lkeLosstimeID.EditValue) + "'");
                            detailLTDto.LosstimeNum = Convert.ToDouble(txtLosstimeNum.Text);
                            detailLTDto.LastModifiedBy = userName;
                            detailLTDto.LastModifiedDate = DateTime.Now;

                            prodStatDao.UpdatePSDetailLosstime(detailLTDto);
                        }
                        else
                        {
                            foreach (DataRow drSave in dtSaveMulti.Rows)
                            {
                                detailLTDto.HeaderID = (long)Convert.ToDouble(drSave["HeaderID"]);
                                detailLTDto.LosstimeID = Convert.ToString(drSave["LosstimeID"]);
                                detailLTDto.LosstimeName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(LosstimeName, '') FROM ASPLosstime WHERE LosstimeID = '" + Convert.ToString(drSave["LosstimeID"]) + "'");
                                detailLTDto.LosstimeNum = Convert.ToDouble(txtLosstimeNum.Text);
                                detailLTDto.LastModifiedBy = userName;
                                detailLTDto.LastModifiedDate = DateTime.Now;

                                prodStatDao.UpdatePSDetailLosstime(detailLTDto);
                            }
                        }

                        this.Close();

                        XtraMessageBox.Show("Đã cập nhật thành công Losstime.");
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

