using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.AttendanceEmployeeDTO;
using ASPData.EmployeeDAO;
using DevExpress.XtraBars.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ASPProject.AttendanceEmployee
{
    public partial class frmAttendanceEmployee : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        private DataTable dtAttendance = new DataTable();
        private DataTable dtLockAttendance = new DataTable();
        private DataRow drCurrent;
        private int attIndexCur;
        private string lockStatus;
        private BindingSource bdsAttendance = new BindingSource();
        private ASPData.SQLHelper _sqlHelpter = new ASPData.SQLHelper();
        AttendanceEmployeeDAO attendEmpDAO = new AttendanceEmployeeDAO();
        AttendanceEmployeeDTO attendEmpDTO = new AttendanceEmployeeDTO();
        ASPDTO aspDto = new ASPDTO();
        EmployeeDAO empDao = new EmployeeDAO();
        #endregion

        #region Constructor
        public frmAttendanceEmployee()
        {
            InitializeComponent();

            new GridviewCheckbox(gridAttendanceView, this, gridAttendanceView.GetSelectedRows().ToList());

            this.Load += FrmAttendanceEmployee_Load;
            this.btCancel.Click += BtCancel_Click;
            this.btSave.Click += BtSave_Click;
            this.btDelete.Click += BtDelete_Click;
            this.btEditMulti.Click += BtEditMulti_Click;
            this.btLockAttendance.Click += BtLockAttendance_Click;
            this.gridAttendanceView.RowClick += GridAttendanceView_RowClick;
            this.gridAttendanceView.DoubleClick += GridAttendanceView_DoubleClick;
            this.dtpAttendanceDate.EditValueChanged += DtpAttendanceDate_EditValueChanged;
            this.btSummary.Click += BtSummary_Click;
            this.gridAttendanceView.RowCellStyle += GridAttendanceView_RowCellStyle;
        }
        #endregion

        #region Load
        private void FrmAttendanceEmployee_Load(object sender, EventArgs e)
        {
            frm.LoadVI += new frmMain.Translate(LoadTV);
            frm.LoadEN += new frmMain.Translate(LoadEL);

            dtpAttendanceDate.EditValue = DateTime.Now;
            lblLineID.Text = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");

            lkeLunchTime.Properties.DataSource = empDao.GetTimeOff("LunchTime");
            lkeLunchTime.Properties.DisplayMember = "TimeFrame";
            lkeLunchTime.Properties.ValueMember = "TimeFrame";
            lkeLunchTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeLunchTime.Properties.PopupFilterMode = PopupFilterMode.Contains;

            lkeDinnerTime.Properties.DataSource = empDao.GetTimeOff("DinnerTime");
            lkeDinnerTime.Properties.DisplayMember = "TimeFrame";
            lkeDinnerTime.Properties.ValueMember = "TimeFrame";
            lkeDinnerTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeDinnerTime.Properties.PopupFilterMode = PopupFilterMode.Contains;

            LoadData();

            if (iNgonNgu == 1)
            {
                LoadEL();
            }
            else
            {
                LoadTV();
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
        }
        private void LoadData()
        {
            //header
            attendEmpDTO.AttendanceDate = Convert.ToDateTime(dtpAttendanceDate.EditValue);
            attendEmpDTO.LineID = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");
            dtAttendance = attendEmpDAO.GetAttendanceEmployee(attendEmpDTO, userName);

            bdsAttendance.DataSource = dtAttendance;
            gridAttendance.DataSource = bdsAttendance;

            if (dtAttendance.Rows.Count > 0)
            {
                txtMorVege.Text =   Convert.ToDouble(dtAttendance.Rows[0]["MorVege"]) > 0 ? Convert.ToString(dtAttendance.Rows[0]["MorVege"]) : string.Empty;
                txtEveVege.Text = Convert.ToDouble(dtAttendance.Rows[0]["EveVege"]) > 0 ? Convert.ToString(dtAttendance.Rows[0]["EveVege"]) : string.Empty;

                lkeLunchTime.EditValue = Convert.ToString(dtAttendance.Rows[0]["LunchTime"]);
                lkeDinnerTime.EditValue = Convert.ToString(dtAttendance.Rows[0]["DinnerTime"]);
            }
           
            if (drCurrent != null)
            {
                long AutoID = (long)Convert.ToDouble(drCurrent["AutoID"]);
            }

            aspDto.FuncID = "AttendanceControl";
            aspDto.UserName = userName;

            dtLockAttendance = attendEmpDAO.GetLockAttendanceAdminList(aspDto);

            if (dtLockAttendance.Rows.Count > 0)
                btLockAttendance.Visible = true;
            else
                btLockAttendance.Visible = false;

            lockStatus = (string)attendEmpDAO.GetLockAttendance(aspDto);

            if (lockStatus == "Close")
                btLockAttendance.Text = "Mở khoá điểm danh";
            else
                btLockAttendance.Text = "Khoá điểm danh";

            //gridAttendanceView.SelectRow(attIndexCur);
            gridAttendanceView.TopRowIndex = attIndexCur;
        }

        private bool CheckLockAttendance()
        {
            if (lockStatus == "Open")
                return false;
            return true;
        }
        #endregion

        #region Event
        private void GridAttendanceView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drCurrent = gridAttendanceView.GetDataRow(e.RowHandle);
            attIndexCur = e.RowHandle;
        }

        private void GridAttendanceView_DoubleClick(object sender, EventArgs e)
        {
            aspDto.FuncID = "AttendanceControl";
            lockStatus = (string)attendEmpDAO.GetLockAttendance(aspDto);

            if (CheckLockAttendance())
            {
                XtraMessageBox.Show("Điểm danh đã khoá, không được chỉnh sửa.");
                return;
            }

            frmAttendanceEmployeeEdit editForm = new frmAttendanceEmployeeEdit();
            editForm.saveMulti = 0;
            editForm.userName = userName;
            editForm.attendanceDate = Convert.ToDateTime(drCurrent["AttendanceDate"]);
            editForm.lineID = Convert.ToString(drCurrent["LineID"]);
            editForm.empID = Convert.ToString(drCurrent["EmpID"]);
            editForm.timeKeeping = Convert.ToString(drCurrent["Timekeeping"]);
            editForm.morVege = !string.IsNullOrEmpty(txtMorVege.Text) ? Convert.ToInt32(txtMorVege.Text) : 0;
            editForm.eveVege = !string.IsNullOrEmpty(txtEveVege.Text) ? Convert.ToInt32(txtEveVege.Text) : 0;
            editForm.dateBeginTime = TimeSpan.Parse(Convert.ToString(drCurrent["DateBeginTime"]));
            editForm.dateEndTime = TimeSpan.Parse(Convert.ToString(drCurrent["DateEndTime"]));

            editForm.ShowDialog();

            LoadData();
        }

        private void DtpAttendanceDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {

            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            deDongTab();
        }
        private void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "AttendanceControl";
                lockStatus = (string)attendEmpDAO.GetLockAttendance(aspDto);

                if (CheckLockAttendance())
                {
                    XtraMessageBox.Show("Điểm danh đã khoá, không được chỉnh sửa.");
                    return;
                }

                DataTable dtSave = bdsAttendance.DataSource as DataTable;

                for (int i = 0; i <= dtSave.Rows.Count - 1; i++)
                {
                    DataRow iDr = dtSave.Rows[i];

                    attendEmpDTO.AttendanceDate = Convert.ToDateTime(iDr["AttendanceDate"]);
                    attendEmpDTO.LineID = Convert.ToString(iDr["LineID"]);
                    attendEmpDTO.EmpID = Convert.ToString(iDr["EmpID"]);
                    attendEmpDTO.Timekeeping = Convert.ToString(iDr["Timekeeping"]).Replace("-X-", "X");
                    attendEmpDTO.MorVege = Convert.ToDouble(!string.IsNullOrEmpty(txtMorVege.Text) ? txtMorVege.Text : "0");
                    attendEmpDTO.EveVege = Convert.ToDouble(!string.IsNullOrEmpty(txtEveVege.Text) ? txtEveVege.Text : "0");
                    attendEmpDTO.LunchTime = !string.IsNullOrEmpty(lkeLunchTime.EditValue.ToString()) ? lkeLunchTime.EditValue.ToString(): null;
                    attendEmpDTO.Dinnertime = !string.IsNullOrEmpty(lkeDinnerTime.EditValue.ToString()) ? lkeDinnerTime.EditValue.ToString() : null;
                    attendEmpDTO.DateBeginTime = TimeSpan.Parse(Convert.ToDateTime(iDr["AttendanceDate"]).AddHours(8).ToString("HH:mm:ss"));
                    attendEmpDTO.DateEndTime = TimeSpan.Parse(Convert.ToDateTime(iDr["AttendanceDate"]).AddHours(20).ToString("HH:mm:ss"));
                    attendEmpDTO.CreatedBy = userName;
                    attendEmpDTO.CreatedDate = DateTime.Now;
                    attendEmpDTO.LastModifiedBy = userName;
                    attendEmpDTO.LastModifiedDate = DateTime.Now;

                    attendEmpDAO.UpdateAttendanceEmployee(attendEmpDTO);
                }

                XtraMessageBox.Show("Đã lưu thành công.");

                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "AttendanceControl";
                lockStatus = (string)attendEmpDAO.GetLockAttendance(aspDto);

                if (CheckLockAttendance())
                {
                    XtraMessageBox.Show("Điểm danh đã khoá, không được xoá.");
                    return;
                }

                if (drCurrent == null || string.IsNullOrEmpty(drCurrent["LineID"].ToString()))
                {
                    drCurrent = gridAttendanceView.GetDataRow(0);
                }

                attendEmpDTO.AttendanceDate = Convert.ToDateTime(drCurrent["AttendanceDate"]);
                attendEmpDTO.LineID = Convert.ToString(drCurrent["LineID"]);

                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xoá bảng điểm danh này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                    return;

                attendEmpDAO.DeleteAttendanceEmployee(attendEmpDTO);

                XtraMessageBox.Show("Đã xoá thành công");

                LoadData();
            }
            catch ( Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtEditMulti_Click(object sender, EventArgs e)
        {
            aspDto.FuncID = "AttendanceControl";
            lockStatus = (string)attendEmpDAO.GetLockAttendance(aspDto);

            if (CheckLockAttendance())
            {
                XtraMessageBox.Show("Điểm danh đã khoá, không được chỉnh sửa.");
                return;
            }

            frmAttendanceEmployeeEdit editForm = new frmAttendanceEmployeeEdit();
            editForm.saveMulti = 1;
            editForm.userName = userName;
            editForm.morVege = !string.IsNullOrEmpty(txtMorVege.Text) ? Convert.ToInt32(txtMorVege.Text) : 0;
            editForm.eveVege = !string.IsNullOrEmpty(txtEveVege.Text) ? Convert.ToInt32(txtEveVege.Text) : 0;
            editForm.attendanceDate = Convert.ToDateTime(dtpAttendanceDate.EditValue);
            editForm.dtSaveMulti = gridAttendanceView.GetDataRow(0).Table.Clone(); //gridEmpStatView.GetDataRow(gridEmpStatView.GetSelectedRows());
            foreach (var iRow in gridAttendanceView.GetSelectedRows())
            {
                editForm.dtSaveMulti.ImportRow(gridAttendanceView.GetDataRow(iRow));
            }
            editForm.ShowDialog();

            LoadData();
        }

        private void BtLockAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "AttendanceControl";

                switch (lockStatus)
                {
                    case "Open":
                        aspDto.FuncValue = "Close";
                        break;
                    case "Close":
                        aspDto.FuncValue = "Open";
                        break;
                    default:
                        break;
                }

                attendEmpDAO.LockAttendance(aspDto);

                lockStatus = (string)aspDto.FuncValue;

                if (lockStatus == "Close")
                    btLockAttendance.Text = "Mở khoá điểm danh";
                else
                    btLockAttendance.Text = "Khoá điểm danh";

                XtraMessageBox.Show("Đã cập nhật thành công.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtSummary_Click(object sender, EventArgs e)
        {
            frmAttendanceSummary frm = new frmAttendanceSummary();
            frm.attendanceDate = Convert.ToDateTime(dtpAttendanceDate.EditValue);
            frm.lineID = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");
            frm.username = userName;

            frm.ShowDialog();
        }

        private void GridAttendanceView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            object value = e.CellValue;

            if (Convert.ToString(value).Trim() == "P" || Convert.ToString(value).Trim() == "V")
                e.Appearance.BackColor = Color.Yellow;
        }
        #endregion
    }
}
