using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
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
using ASPData.ASPDTO;
using System.Globalization;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace ASPProject.SOPStage
{
    public partial class frmSOPStageEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public long headerID;
        public string stageID, stageName, userName, passWord;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
       
        WOSOPDTO woDto = new WOSOPDTO();
        WOSOPDAO woDao = new WOSOPDAO();
        #endregion

        #region Load
        public frmSOPStageEdit()
        {
            InitializeComponent();

            this.Load += FrmSOPStageEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }

        private void FrmSOPStageEdit_Load(object sender, EventArgs e)
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
                txtStageID.Text = Convert.ToString(stageID);
                txtStageName.Text = Convert.ToString(stageName);
            }
            else
            {
                //load StageID
                txtStageID.Text = ASPGenStageCode();
            }
        }

        private string ASPGenStageCode()
        {
            string losstimeCode = string.Empty;

            var dicParams = new Dictionary<string, object> {
                { "@Prefix", "STAGE" },
                { "@NumLen", 4},
                { "@ColumnID", "StageID" },
                { "@TableName", "ASPWOSOPDetail" }
            };

            losstimeCode = (string)_sqlHelper.ExecProcedureSacalar("sp_ASPGenerateCode", dicParams);

            return losstimeCode;
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

        #endregion

        #region Event
        private void BtSave_Click(object sender, EventArgs e)
        {
            if (editType == 1) //them moi
            {
                woDto.HeaderID = headerID;
                woDto.StageID = !string.IsNullOrEmpty(txtStageID.Text) ? txtStageID.Text : string.Empty;
                woDto.StageName = !string.IsNullOrEmpty(txtStageName.Text) ? txtStageName.Text : string.Empty;
                woDto.CreatedBy = userName;
                woDto.CreatedDate = DateTime.Now;
                woDto.LastModifiedBy = string.Empty;
                woDto.LastModifiedDate = Convert.ToDateTime("1900-01-01");

                woDao.InsertWOSOPStage(woDto);
            }
            else //chinh sua
            {
                woDto.HeaderID = headerID;
                woDto.StageID = !string.IsNullOrEmpty(txtStageID.Text) ? txtStageID.Text : string.Empty;
                woDto.StageName = !string.IsNullOrEmpty(txtStageName.Text) ? txtStageName.Text : string.Empty;
                woDto.CreatedBy = string.Empty;
                woDto.CreatedDate = Convert.ToDateTime("1900-01-01");
                woDto.LastModifiedBy = userName;
                woDto.LastModifiedDate = DateTime.Now;

                woDao.UpdateWOSOPStage(woDto);
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
