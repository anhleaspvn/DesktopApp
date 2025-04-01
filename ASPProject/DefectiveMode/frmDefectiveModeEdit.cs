using ASPData;
using ASPData.ASPDAO;
using ASPData.DefectiveModeDTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ASPProject.DefectiveMode
{
    public partial class frmDefectiveModeEdit : DevExpress.XtraEditors.XtraForm
    {
        public int editType;
        public int iNgonNgu;
        public string defectID, defectName, defectLevel, defectType, moldAssembly, mainStep, userName, passWord;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        private List<string> lstDefectLevel = new List<string>();
        private List<string> lstMoldAssembly = new List<string>();

        DefectiveModeDTO defectDto = new DefectiveModeDTO();
        DefectiveModeDAO defectDao = new DefectiveModeDAO();
        public frmDefectiveModeEdit()
        {
            InitializeComponent();

            lstDefectLevel.Add("Major");
            lstDefectLevel.Add("Minor");
            lstDefectLevel.Add("Critical");

            lstMoldAssembly.Add("Mold");
            lstMoldAssembly.Add("Assembly");
            lstMoldAssembly.Add("All");

            lkeDefectLevel.Properties.DataSource = lstDefectLevel;
            lkeMoldAssembly.Properties.DataSource = lstMoldAssembly;
            lkeDefectLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeDefectLevel.Properties.PopupFilterMode = PopupFilterMode.Contains;
            lkeMoldAssembly.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeMoldAssembly.Properties.PopupFilterMode = PopupFilterMode.Contains;

            this.Load += FrmDefectiveModeEdit_Load;
            btSave.Click += BtSave_Click;
            btCancel.Click += BtCancel_Click;
        }

        #region Load
        private void FrmDefectiveModeEdit_Load(object sender, EventArgs e)
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
                txtDefectID.Text = Convert.ToString(defectID);
                txtDefectName.Text = Convert.ToString(defectName);
                txtDefectType.Text = Convert.ToString(defectType);
                lkeDefectLevel.EditValue = Convert.ToString(defectLevel);
                lkeMoldAssembly.EditValue = Convert.ToString(moldAssembly);
                txtMainStep.Text = Convert.ToString(mainStep);
                txtDefectType.Text = Convert.ToString(defectType);
            }
            else
            {
                //load EmpID
                txtDefectID.Text = ASPGenEmpCode();
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
            this.Text = "Form Insert && Update Defect Mode";
        }

        private string ASPGenEmpCode()
        {
            string defCode = string.Empty;

            var dicParams = new Dictionary<string, object> {
                { "@Prefix", "DP" },
                { "@NumLen", 2},
                { "@ColumnID", "DefectID" },
                { "@TableName", "ASPDefectiveMode" }
            };

            defCode = (string)_sqlHelper.ExecProcedureSacalar("sp_ASPGenerateCode", dicParams);

            return defCode;
        }

        private bool FormCheckValid()
        {
            if (string.IsNullOrEmpty(txtDefectName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên Defect Mode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    defectDto.DefectID = Convert.ToString(txtDefectID.Text);
                    defectDto.DefectName = Convert.ToString(txtDefectName.Text);
                    defectDto.DefectType = Convert.ToString(txtDefectType.Text);
                    defectDto.DefectLevel = Convert.ToString(lkeDefectLevel.EditValue);
                    defectDto.Mold_Assembly = Convert.ToString(lkeMoldAssembly.EditValue);
                    defectDto.MainStep = Convert.ToString(txtMainStep.Text);
                    defectDto.CreatedBy = userName;
                    defectDto.CreatedDate = DateTime.Now;

                    defectDao.InsertDefectiveMode(defectDto);

                    XtraMessageBox.Show("Đã thêm defect mode thành công.");
                    this.Close();
                }
                else
                {
                    defectDto.DefectID = Convert.ToString(txtDefectID.Text);
                    defectDto.DefectName = Convert.ToString(txtDefectName.Text);
                    defectDto.DefectType = Convert.ToString(txtDefectType.Text);
                    defectDto.DefectLevel = Convert.ToString(lkeDefectLevel.EditValue);
                    defectDto.Mold_Assembly = Convert.ToString(lkeMoldAssembly.EditValue);
                    defectDto.MainStep = Convert.ToString(txtMainStep.Text);
                    defectDto.LastModifiedBy = userName;
                    defectDto.LastModifiedDate = DateTime.Now;

                    defectDao.UpdateDefectiveMode(defectDto);

                    XtraMessageBox.Show("Đã cập nhật defect mode thành công.");
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
