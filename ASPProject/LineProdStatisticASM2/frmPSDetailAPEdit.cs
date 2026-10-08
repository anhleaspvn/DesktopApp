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

namespace ASPProject.LineProdStatisticASM2
{
    public partial class frmPSDetailAPEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public string defectID, userName;
        public double numOfTime;
        private DataTable dtDefectList = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailDefect detailDefectDto = new PSDetailDefect();
        ProdStatisticASM2DAO prodStatDao = new ProdStatisticASM2DAO();
        #endregion

        #region Constructor
        public frmPSDetailAPEdit()
        {
            InitializeComponent();

            this.Load += FrmPSDetailAPEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmPSDetailAPEdit_Load(object sender, EventArgs e)
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
                    lkeDefectiD.Properties.DataSource = prodStatDao.GetDefectModeList(string.Empty);
                    lkeDefectiD.Properties.ValueMember = "DefectID";
                    lkeDefectiD.Properties.DisplayMember = "DefectID";
                    lkeDefectiD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeDefectiD.Properties.PopupFilterMode = PopupFilterMode.Contains;

                    break;
                case 0:
                    lkeDefectiD.ReadOnly = true;
                    lkeDefectiD.Properties.DataSource = prodStatDao.GetDefectModeList(defectID);
                    lkeDefectiD.Properties.ValueMember = "DefectID";
                    lkeDefectiD.Properties.DisplayMember = "DefectID";
                    lkeDefectiD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    lkeDefectiD.Properties.PopupFilterMode = PopupFilterMode.Contains;
                    lkeDefectiD.EditValue = defectID;

                    txtNumOfTime.Text = numOfTime > 0 ? Convert.ToString(numOfTime) : string.Empty;

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
                if (string.IsNullOrEmpty(lkeDefectiD.EditValue.ToString()))
                {
                    XtraMessageBox.Show("Vui lòng nhập mã Defect.");
                    return false;
                }
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
                        detailDefectDto.HeaderID = HeaderID;
                        detailDefectDto.DefectID = Convert.ToString(lkeDefectiD.EditValue);
                        detailDefectDto.DefectName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(DefectName, '') FROM ASPDefectiveMode WHERE DefectID = '" + Convert.ToString(lkeDefectiD.EditValue) + "'");
                        detailDefectDto.NumOfTime = Convert.ToDouble(!string.IsNullOrEmpty(txtNumOfTime.Text) ? txtNumOfTime.Text : "0");
                        detailDefectDto.CreatedBy = userName;
                        detailDefectDto.CreatedDate = DateTime.Now;

                        prodStatDao.InsertPSDetailAP(detailDefectDto);

                        this.Close();

                        XtraMessageBox.Show("Đã thêm thành công Defect Mode.");
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
                            detailDefectDto.HeaderID = HeaderID;
                            detailDefectDto.DefectID = Convert.ToString(lkeDefectiD.EditValue);
                            detailDefectDto.NumOfTime = Convert.ToDouble(!string.IsNullOrEmpty(txtNumOfTime.Text) ? txtNumOfTime.Text : "0");
                            detailDefectDto.LastModifiedBy = userName;
                            detailDefectDto.LastModifiedDate = DateTime.Now;

                            prodStatDao.UpdatePSDetailAP(detailDefectDto);
                        }
                        else
                        {
                            foreach (DataRow drSave in dtSaveMulti.Rows)
                            {
                                detailDefectDto.HeaderID = (long)Convert.ToDouble(drSave["HeaderID"]);
                                detailDefectDto.DefectID = Convert.ToString(drSave["DefectID"]);
                                detailDefectDto.NumOfTime = Convert.ToDouble(!string.IsNullOrEmpty(txtNumOfTime.Text) ? txtNumOfTime.Text : "0");
                                detailDefectDto.LastModifiedBy = userName;
                                detailDefectDto.LastModifiedDate = DateTime.Now;

                                prodStatDao.UpdatePSDetailAP(detailDefectDto);
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
