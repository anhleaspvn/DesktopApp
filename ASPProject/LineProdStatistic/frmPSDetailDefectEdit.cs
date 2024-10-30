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
    public partial class frmPSDetailDefectEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID;
        public string defectID, userName, stageID;
        public double fqcQuantity, scrapFQCQuantity, prevFQCQuantity, reworkFQCQuantity, remainDFQuantity;
        private DataTable dtDefectList = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        PSDetailDefect detailDefectDto = new PSDetailDefect();
        ProdStatisticDAO prodStatDao = new ProdStatisticDAO();
        #endregion

        #region Constructor
        public frmPSDetailDefectEdit()
        {
            InitializeComponent();

            this.Load += FrmPSDetailDefectEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmPSDetailDefectEdit_Load(object sender, EventArgs e)
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

                    txtStageID.Text = stageID;
                    txtFQCQuantity.Text = fqcQuantity > 0 ? Convert.ToString(fqcQuantity) : string.Empty;
                    txtScrapFQCQuantity.Text = scrapFQCQuantity > 0 ? Convert.ToString(scrapFQCQuantity) : string.Empty;
                    txtPrevFQCQuantity.Text = prevFQCQuantity > 0 ? Convert.ToString(prevFQCQuantity) : string.Empty;
                    txtFQCReworkQuantity.Text = reworkFQCQuantity > 0 ? Convert.ToString(reworkFQCQuantity) : string.Empty;
                   
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
                        detailDefectDto.StageID = Convert.ToString(txtStageID.Text);
                        detailDefectDto.DefectID = Convert.ToString(lkeDefectiD.EditValue);
                        detailDefectDto.DefectName = (string)_sqlHelper.ExecQueryDataFistOrDefault<string>("SELECT ISNULL(DefectName, '') FROM ASPDefectiveMode WHERE DefectID = '" + Convert.ToString(lkeDefectiD.EditValue) + "'");
                        detailDefectDto.FQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCQuantity.Text) ? txtFQCQuantity.Text : "0");
                        detailDefectDto.FQCScrapQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtScrapFQCQuantity.Text) ? txtScrapFQCQuantity.Text : "0");
                        detailDefectDto.PrevFQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtPrevFQCQuantity.Text) ? txtPrevFQCQuantity.Text : "0");
                        detailDefectDto.FQCReworkQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCReworkQuantity.Text) ? txtFQCReworkQuantity.Text : "0");
                        detailDefectDto.CreatedBy = userName;
                        detailDefectDto.CreatedDate = DateTime.Now;

                        prodStatDao.InsertPSDetailDefect(detailDefectDto);

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
                            detailDefectDto.StageID = Convert.ToString(txtStageID.Text);
                            detailDefectDto.DefectID = Convert.ToString(lkeDefectiD.EditValue);
                            detailDefectDto.FQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCQuantity.Text) ? txtFQCQuantity.Text : "0");
                            detailDefectDto.FQCScrapQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtScrapFQCQuantity.Text) ? txtScrapFQCQuantity.Text : "0");
                            detailDefectDto.PrevFQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtPrevFQCQuantity.Text) ? txtPrevFQCQuantity.Text : "0");
                            detailDefectDto.FQCReworkQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCReworkQuantity.Text) ? txtFQCReworkQuantity.Text : "0");
                            detailDefectDto.LastModifiedBy = userName;
                            detailDefectDto.LastModifiedDate = DateTime.Now;

                            prodStatDao.UpdatePSDetailDefect(detailDefectDto);
                        }
                        else
                        {
                            foreach (DataRow drSave in dtSaveMulti.Rows)
                            {
                                detailDefectDto.HeaderID = (long)Convert.ToDouble(drSave["HeaderID"]);
                                detailDefectDto.StageID = Convert.ToString(drSave["StageID"]);
                                detailDefectDto.DefectID = Convert.ToString(drSave["DefectID"]);
                                detailDefectDto.FQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCQuantity.Text) ? txtFQCQuantity.Text : "0");
                                detailDefectDto.FQCScrapQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtScrapFQCQuantity.Text) ? txtScrapFQCQuantity.Text : "0");
                                detailDefectDto.PrevFQCDFQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtPrevFQCQuantity.Text) ? txtPrevFQCQuantity.Text : "0");
                                detailDefectDto.FQCReworkQuantity = Convert.ToDouble(!string.IsNullOrEmpty(txtFQCReworkQuantity.Text) ? txtFQCReworkQuantity.Text : "0");
                                detailDefectDto.LastModifiedBy = userName;
                                detailDefectDto.LastModifiedDate = DateTime.Now;

                                prodStatDao.UpdatePSDetailDefect(detailDefectDto);
                            }
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

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
