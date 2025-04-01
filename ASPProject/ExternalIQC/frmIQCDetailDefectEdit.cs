using ASPData.ASPDAO;
using ASPData.ASPDTO;
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

namespace ASPProject.ExternalIQC
{
    public partial class frmIQCDetailDefectEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType, saveMulti;
        public int iNgonNgu;
        public long HeaderID, AutoID;
        public string iqcCheckID, defectID, userName;
        public double defectQuantity;
        private DataTable dtIQCDefect = new DataTable();
        public DataTable dtSaveMulti = new DataTable();

        private IQCCheckingDAO iqcDao = new IQCCheckingDAO();
        private IQCCheckListDTO iqcDto = new IQCCheckListDTO();
        private ProdStatisticDAO prodStatDao = new ProdStatisticDAO();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion
        #region Load
        public frmIQCDetailDefectEdit()
        {
            InitializeComponent();

            this.Load += FrmIQCDetailDefectEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }

        private void FrmIQCDetailDefectEdit_Load(object sender, EventArgs e)
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

                    txtDefectQuantity.Text = defectQuantity > 0 ? Convert.ToString(defectQuantity) : string.Empty;

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
            this.Text = "Form IQC defect";
        }
        #endregion

        #region Event
        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (editType == 0)
            {
                iqcDto.AutoID = AutoID;
                iqcDto.DefectQuantity = Convert.ToDouble(txtDefectQuantity.Text);
                iqcDto.LastModifiedBy = userName;
                iqcDto.LastModifiedDate = DateTime.Now;

                iqcDao.UpdateIQCCheckDefect(iqcDto);
            }

            this.Close();
        }
        #endregion
    }
}
