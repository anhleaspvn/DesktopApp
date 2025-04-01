using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.InternalAuditDTO;
using ASPData.InternalAuditDAO;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native.Lines;
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
using static DevExpress.Data.Filtering.Helpers.SubExprHelper.ThreadHoppingFiltering;

namespace ASPProject.InternalAudit
{
    public partial class frmISOAuditEmailEdit : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtFactory = new DataTable();
        DataTable dtDept = new DataTable();
        DataTable dtEmp = new DataTable();

        ASPDAO aspDao = new ASPDAO();
        ASPDTO aspDto = new ASPDTO();

        InternalAuditDTO isoDto = new InternalAuditDTO();
        InternalAuditDAO isoDao = new InternalAuditDAO();

        public int editType, iNgonNgu;
        public string userName, deptID, factoryID, glSignedID, headSignedID, deptSignedID;
        public frmISOAuditEmailEdit()
        {
            InitializeComponent();

            dtFactory = aspDao.GetFactoryList();
            dtDept = aspDao.GetDepartmentList();

            lkeFactoryID.Properties.DataSource = dtFactory;
            lkeFactoryID.Properties.DisplayMember = "Ten_NhaMay";
            lkeFactoryID.Properties.ValueMember = "Ma_NhaMay";
            lkeFactoryID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeFactoryID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeDeptID.Properties.DataSource = dtDept;
            lkeDeptID.Properties.DisplayMember = "DeptName";
            lkeDeptID.Properties.ValueMember = "DeptID";
            lkeDeptID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeDeptID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            isoDto.FactoryID = Convert.ToString(lkeFactoryID.EditValue);
            dtEmp = isoDao.GetISOStaff(isoDto);

            lkeDepartID.Properties.DataSource = dtEmp;
            lkeDepartID.Properties.DisplayMember = "EmpName";
            lkeDepartID.Properties.ValueMember = "EmpID";
            lkeDepartID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeDepartID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeHeadID.Properties.DataSource = dtEmp;
            lkeHeadID.Properties.DisplayMember = "EmpName";
            lkeHeadID.Properties.ValueMember = "EmpID";
            lkeHeadID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeHeadID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeGLID.Properties.DataSource = dtEmp;
            lkeGLID.Properties.DisplayMember = "EmpName";
            lkeGLID.Properties.ValueMember = "EmpID";
            lkeGLID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeGLID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            this.Load += FrmISOAuditEmailEdit_Load;
            this.btSave.Click += BtSave_Click;
            this.btCancel.Click += BtCancel_Click;
        }

        private void FrmISOAuditEmailEdit_Load(object sender, EventArgs e)
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
                lkeDeptID.ReadOnly = false;
                lkeFactoryID.ReadOnly = false;
            }
            else
            {
                lkeDeptID.EditValue = deptID;
                lkeFactoryID.EditValue = factoryID;

                lkeDeptID.ReadOnly = true;
                lkeFactoryID.ReadOnly = true;

                lkeGLID.EditValue = glSignedID;
                lkeHeadID.EditValue = headSignedID;
                lkeDepartID.EditValue = deptSignedID;
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
            this.Text = "Form Insert && Update ISO Email";
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            isoDto.DeptID = Convert.ToString(lkeDeptID.EditValue);
            isoDto.FactoryID = Convert.ToString(lkeFactoryID.EditValue);    
            isoDto.GLSignedID = string.IsNullOrEmpty(lkeGLID.EditValue.ToString()) ? string.Empty : lkeGLID.EditValue.ToString();
            isoDto.HeadSignedID = string.IsNullOrEmpty(lkeHeadID.EditValue.ToString()) ? string.Empty : lkeHeadID.EditValue.ToString();
            isoDto.DeptSignedID = string.IsNullOrEmpty(lkeDepartID.EditValue.ToString()) ? string.Empty : lkeDepartID.EditValue.ToString();

            if (editType == 0)
            {
                isoDao.InsertISOAuditEmail(isoDto);

                XtraMessageBox.Show("Đã thêm thành công.");
            }
            else
            {
                isoDao.UpdateISOAuditEmail(isoDto);

                XtraMessageBox.Show("Đã sửa thành công.");
            }

            this.Close();
        }
    }
}
