using ASPData;
using ASPData.ASPDAO;
using ASPData.LosstimeDTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.Losstime
{
    public partial class frmLosstimeEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public string losstimeID, losstimeName, losstimeType, userName, passWord;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private List<string> lstLosstimeType = new List<string>();

        LosstimeDTO losstimeDto = new LosstimeDTO();
        LosstimeDAO losstimeDao = new LosstimeDAO();
        #endregion

        #region Constructor
        public frmLosstimeEdit()
        {
            InitializeComponent();

            this.Load += FrmLosstimeEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }
        #endregion

        #region Load
        private void FrmLosstimeEdit_Load(object sender, EventArgs e)
        {
            //Prod status
            lstLosstimeType.Add("Internal");
            lstLosstimeType.Add("External");

            lkeLosstimeType.Properties.DataSource = lstLosstimeType;
            lkeLosstimeType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeLosstimeType.Properties.PopupFilterMode = PopupFilterMode.Contains;

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
                txtLosstimeID.Text = Convert.ToString(losstimeID);
                txtLosstimeName.Text = Convert.ToString(losstimeName);
                lkeLosstimeType.EditValue = Convert.ToString(losstimeType);
            }
            else
            {
                //load EmpID
                txtLosstimeID.Text = ASPGenEmpCode();
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

        private string ASPGenEmpCode()
        {
            string losstimeCode = string.Empty;

            var dicParams = new Dictionary<string, object> {
                { "@Prefix", "LT" },
                { "@NumLen", 2 },
                { "@ColumnID", "LosstimeID" },
                { "@TableName", "ASPLosstime" }
            };

            losstimeCode = (string)_sqlHelper.ExecProcedureSacalar("sp_ASPGenerateCode", dicParams);

            return losstimeCode;
        }

        private bool FormCheckValid()
        {
            if (string.IsNullOrEmpty(txtLosstimeName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên Losstime", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeLosstimeType.EditValue)))
            {
                XtraMessageBox.Show("Vui lòng nhập loại Losstime", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            try
            {
                if (!FormCheckValid())
                    return;

                if (editType == 1)
                {
                    losstimeDto.LosstimeID = Convert.ToString(txtLosstimeID.Text);
                    losstimeDto.LosstimeName = Convert.ToString(txtLosstimeName.Text);
                    losstimeDto.LosstimeType = Convert.ToString(lkeLosstimeType.EditValue);
                    losstimeDto.CreatedBy = userName;
                    losstimeDto.CreatedDate = DateTime.Now;

                    losstimeDao.InsertLosstime(losstimeDto);

                    XtraMessageBox.Show("Đã thêm losstime thành công.");
                    this.Close();
                }
                else
                {
                    losstimeDto.LosstimeID = Convert.ToString(txtLosstimeID.Text);
                    losstimeDto.LosstimeName = Convert.ToString(txtLosstimeName.Text);
                    losstimeDto.LosstimeType = Convert.ToString(lkeLosstimeType.EditValue);
                    losstimeDto.LastModifiedBy = userName;
                    losstimeDto.LastModifiedDate = DateTime.Now;

                    losstimeDao.UpdateLosstime(losstimeDto);

                    XtraMessageBox.Show("Đã cập nhật losstime thành công.");
                    this.Close();
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
