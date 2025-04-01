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
using ASPData.ASPDTO;
using DevExpress.XtraEditors;
using static DevExpress.Data.Filtering.Helpers.SubExprHelper.ThreadHoppingFiltering;
using System.Windows.Media.Animation;

namespace ASPProject.ProdQRCodeMaster
{
    public partial class frmProdQRCodeMasterEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public string userName, WODocNo = string.Empty;
        private DataTable dtWODocNoList = new DataTable();

        private readonly SQLHelper _sqlHelper = new SQLHelper();

        QRCodeMasterList qrDto = new QRCodeMasterList();
        ProdStatisticDAO prDao = new ProdStatisticDAO();

        #endregion

        #region Load
        public frmProdQRCodeMasterEdit()
        {
            InitializeComponent();

            this.Load += FrmProdQRCodeMasterEdit_Load;

            this.btCancel.Click += BtCancel_Click;
            this.btSave.Click += BtSave_Click;

            this.lkeWO.EditValueChanged += LkeWO_EditValueChanged;
        }

        private void FrmProdQRCodeMasterEdit_Load(object sender, EventArgs e)
        {
            if (editType == 0)
            {
                lkeWO.ReadOnly = true;
                lkeWO.EditValue = WODocNo;
            }
            else
            {
              
            }

            dtWODocNoList = prDao.GetWODocNoList(userName, WODocNo, editType);

            lkeWO.Properties.DataSource = dtWODocNoList;
            lkeWO.Properties.DisplayMember = "So_Ct";
            lkeWO.Properties.ValueMember = "So_Ct";
            lkeWO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeWO.Properties.PopupFilterMode = PopupFilterMode.Contains;
        }
        #endregion

        #region Event
        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                qrDto.WODocNo = Convert.ToString(lkeWO.EditValue);
                qrDto.CreatedBy = userName;
                qrDto.CreatedDate = DateTime.Now;

                prDao.InsertQRCodeMaster(qrDto);

                XtraMessageBox.Show("Đã thêm thành công.");
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void LkeWO_EditValueChanged(object sender, EventArgs e)
        {
            dtWODocNoList = prDao.GetWODocNoList(userName, Convert.ToString(lkeWO.EditValue), editType);

            if (dtWODocNoList.Rows.Count > 0)
            {
                DataRow drWODocNo = dtWODocNoList.Rows[0];

                txtProductID.Text = drWODocNo["Ma_Sp"].ToString();
                txtRequestQuantity.Text = drWODocNo["So_Luong9"].ToString();
            }
        }
        #endregion
    }
}
