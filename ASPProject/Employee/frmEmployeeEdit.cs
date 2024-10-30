using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using ASPData.EmployeeDTO;
using ASPData.EmployeeDAO;

using ASPData;
//using ASPProject.class_TungLam;

namespace ASPProject
{
    public partial class frmEmployeeEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        private List<string> directList = new List<string>();
        private readonly SQLHelper _sqlHelper = new SQLHelper();

        EmployeeDTO empDto = new EmployeeDTO();
        EmployeeDAO empDao = new EmployeeDAO();

        DataTable dt = new DataTable();
        public string empID, hrEmpID, userName, passWord, empPosition, empName, empDirect, empLine, description;
        public int editType, UpdateLine;
        string cackitudacbiet = @"!@#$%^&*()_+|~<>,.?/\=";
        public int iNgonNgu;
        public bool quitJob, quitMaternity, isOfficialEmp;
        public DataTable dtUpdateLine;
        #endregion

        #region Constructor
        public frmEmployeeEdit()
        {
            InitializeComponent();

            directList.Add("D1");
            directList.Add("D2");
            directList.Add("I");

            lkeDirect.Properties.DataSource = directList;
            lkeDirect.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeDirect.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeLineID.Properties.DataSource = LineIDData();
            lkeLineID.Properties.DisplayMember = "LineName";
            lkeLineID.Properties.ValueMember = "LineID";
            lkeLineID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeLineID.Properties.PopupFilterMode = PopupFilterMode.Contains;


            this.Load += FrmEmployeeEdit_Load;

            btSave.Click += BtSave_Click;
            btCancel.Click += BtCancel_Click;
        }
        private DataTable LineIDData()
        {
            DataTable dt = new DataTable();

            dt = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetAllLineID");

            return dt;
        }
        #endregion

        #region Load
        private void FrmEmployeeEdit_Load(object sender, EventArgs e)
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
                if (UpdateLine == 0)
                {
                    txtEmpID.Text = empID;
                    txtEmpIDHR.Text = hrEmpID;
                    txtEmpName.Text = empName;
                    txtPosition.Text = empPosition;
                    lkeDirect.EditValue = empDirect;
                    lkeLineID.EditValue = empLine;
                    chkQuitJob.Checked = quitJob;
                    chkQuitMaternity.Checked = quitMaternity;
                    chkIsOfficialEmp.Checked = isOfficialEmp;
                }
                else
                {
                    txtEmpID.Enabled = false;
                    txtEmpName.Enabled = false;
                    txtPosition.Enabled = false;
                    lkeDirect.Enabled = false;
                }
            }
            else
            {
                txtEmpID.Text = ASPGenEmpCode();
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
            this.Text = "Form Insert && Update Employee";
        }
        private string ASPGenEmpCode()
        {
            string empCode = string.Empty;

            var dicParams = new Dictionary<string, object> {
                { "@Prefix", "PEC" },
                { "@NumLen", 4 },
                { "@ColumnID", "EmpID" },
                { "@TableName", "ASPEmployee" }
            };

            empCode = (string)_sqlHelper.ExecProcedureSacalar("sp_ASPGenerateCode", dicParams);

            return empCode;
        }

        private bool FormCheckValid()
        {
            if (editType == 0 && UpdateLine == 1)
                return true;

            if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập chức vụ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(lkeDirect.EditValue)))
            {
                XtraMessageBox.Show("Vui lòng nhập Direct/Indirect", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (string.IsNullOrEmpty(Convert.ToString(lkeLineID.EditValue)))
            //{
            //    XtraMessageBox.Show("Vui lòng nhập mã line", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            return true;
        }
        #endregion

        #region Event
        private void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormCheckValid())
                    return;

                if (editType == 1)
                {
                    empDto.EmpID = txtEmpID.Text;
                    empDto.HREmpID = txtEmpIDHR.Text;
                    empDto.EmpName = txtEmpName.Text;
                    empDto.Position = txtPosition.Text;
                    empDto.LineID = Convert.ToString(lkeLineID.EditValue);
                    empDto.Direct = Convert.ToString(lkeDirect.EditValue);
                    empDto.QuitJob = chkQuitJob.Checked;
                    empDto.QuitMaternity = chkQuitMaternity.Checked;
                    empDto.IsOfficialEmp = chkIsOfficialEmp.Checked;
                    empDto.Description = mmDescription.Text;
                    empDto.CreatedBy = userName;
                    empDto.CreatedDate = DateTime.Now;

                    empDao.InsertEmployee(empDto);

                    XtraMessageBox.Show("Đã thêm nhân viên thành công.");
                    this.Close();
                }
                else
                {
                    if (UpdateLine == 0)
                    {
                        empDto.EmpID = txtEmpID.Text;
                        empDto.HREmpID = txtEmpIDHR.Text;
                        empDto.EmpName = txtEmpName.Text;
                        empDto.Position = txtPosition.Text;
                        empDto.LineID = Convert.ToString(lkeLineID.EditValue);
                        empDto.Direct = Convert.ToString(lkeDirect.EditValue);
                        empDto.QuitJob = chkQuitJob.Checked;
                        empDto.QuitMaternity = chkQuitMaternity.Checked;
                        empDto.IsOfficialEmp = chkIsOfficialEmp.Checked;
                        empDto.Description = mmDescription.Text;
                        empDto.LastModifiedBy = userName;
                        empDto.LastModifiedDate = DateTime.Now;

                        empDao.UpdateEmployee(empDto);

                        XtraMessageBox.Show("Đã cập nhật nhân viên thành công.");
                        this.Close();
                    }
                    else
                    {
                        foreach (DataRow row in dtUpdateLine.Rows)
                        {
                            empDto.EmpID = Convert.ToString(row["EmpID"]);
                            empDto.EmpName = Convert.ToString(row["EmpName"]);
                            empDto.LineID = Convert.ToString(lkeLineID.EditValue);
                            empDto.LastModifiedBy = userName;
                            empDto.LastModifiedDate = DateTime.Now;

                            empDao.UpdateEmployeeLineID(empDto);
                        }

                        XtraMessageBox.Show("Đã cập nhật nhân viên thành công.");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}