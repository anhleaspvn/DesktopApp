using ASPData.ASPDAO;
using ASPData.ASPDTO;
using ASPData.EmployeeDAO;
using ASPData.LosstimeDTO;
using DevExpress.XtraBars.Customization;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ASPProject.ExLosstime
{
    public partial class frmExLosstime : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        private DataTable dtExLosstime = new DataTable();
        private DataTable dtLockExLosstime = new DataTable();
        private DataRow drCurrent;
        private int attIndexCur;
        private string lockStatus;
        private BindingSource bdsExLosstime = new BindingSource();
        private ASPData.SQLHelper _sqlHelpter = new ASPData.SQLHelper();
        private string[] lstEmpID = new string[] { "" };
        LosstimeDAO exLossDAO = new LosstimeDAO();
        LosstimeDTO exLossDTO = new LosstimeDTO();
        ASPDTO aspDto = new ASPDTO();
        EmployeeDAO empDao = new EmployeeDAO();
        #endregion

        #region Constructor
        public frmExLosstime()
        {
            InitializeComponent();

            new GridviewCheckbox(gridExLosstimeView, this, gridExLosstimeView.GetSelectedRows().ToList());

            this.Load += FrmExLosstime_Load;
            this.btCancel.Click += BtCancel_Click;
            this.btSave.Click += BtSave_Click;
            this.btDelete.Click += BtDelete_Click;
            this.btDeleteAll.Click += BtDeleteAll_Click;
            this.btEditMulti.Click += BtEditMulti_Click;
            this.btSummary.Click += BtSummary_Click;
            this.gridExLosstimeView.RowClick += GridExLosstimeView_RowClick;
            this.gridExLosstimeView.DoubleClick += GridExLosstimeView_DoubleClick;
            this.dtpStatisticDate.EditValueChanged += DtpStatisticDate_EditValueChanged;
            this.lkeEmployee.EditValueChanged += LkeEmployee_EditValueChanged;
            this.chkCbListEmpID.EditValueChanged += ChkCbListEmpID_EditValueChanged;
        }
        #endregion

        #region Load
        private void FrmExLosstime_Load(object sender, EventArgs e)
        {
            frm.LoadVI += new frmMain.Translate(LoadTV);
            frm.LoadEN += new frmMain.Translate(LoadEL);

            dtpStatisticDate.EditValue = DateTime.Now;
            lblLineID.Text = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");

            lkeEmployee.Properties.DataSource = empDao.GetAllEmployeeByLineForExLosstime(lblLineID.Text, Convert.ToDateTime(dtpStatisticDate.EditValue), userName);
            lkeEmployee.Properties.DisplayMember = "EmpID";
            lkeEmployee.Properties.ValueMember = "EmpID";
            lkeEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeEmployee.Properties.PopupFilterMode = PopupFilterMode.Contains;

            chkCbListEmpID.Properties.SeparatorChar = ',';
            chkCbListEmpID.Properties.AllowMultiSelect = true;
            chkCbListEmpID.Properties.ReadOnly = false;
            DataTable dtEmpID = empDao.GetAllEmployeeByLine(lblLineID.Text, Convert.ToDateTime(dtpStatisticDate.EditValue), userName);
            chkCbListEmpID.Properties.DataSource = dtEmpID;
            chkCbListEmpID.Properties.ValueMember = "EmpID";
            chkCbListEmpID.Properties.DisplayMember = "EmpName";

            //foreach (DataRow dr in dtEmpID.Rows)
            //{
            //    chkCbListEmpID.Properties.Items.Add(dr["EmpID"], dr["EmpName"].ToString(), System.Windows.Forms.CheckState.Unchecked, false);
            //}

            lblEmpName.Text = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(EmpName, '') FROM ASPEmployee WHERE EmpID = '" + Convert.ToString(lkeEmployee.EditValue) + "'");

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
            gridExLosstimeView.ClearSelection();
            new GridviewCheckbox(gridExLosstimeView, this, gridExLosstimeView.GetSelectedRows().ToList());

            //header
            exLossDTO.StatisticDate = Convert.ToDateTime(dtpStatisticDate.EditValue);
            exLossDTO.LineID = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");

            exLossDTO.EmpID = lstEmpID.Length == 1 ? lstEmpID[0] : string.Empty;

            dtExLosstime = exLossDAO.GetPSExLosstime(exLossDTO);

            bdsExLosstime.DataSource = dtExLosstime;
            gridExLosstime.DataSource = bdsExLosstime;

            if (drCurrent != null)
            {
                long AutoID = (long)Convert.ToDouble(drCurrent["AutoID"]);
            }

            gridExLosstimeView.TopRowIndex = attIndexCur;
        }

        private bool CheckLockExLosstime()
        {
            if (lockStatus == "Open")
                return false;
            return true;
        }
        #endregion

        #region Event
        private void GridExLosstimeView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            drCurrent = gridExLosstimeView.GetDataRow(e.RowHandle);
            attIndexCur = e.RowHandle;
        }

        private void GridExLosstimeView_DoubleClick(object sender, EventArgs e)
        {

            frmExLosstimeEdit editForm = new frmExLosstimeEdit();
            editForm.saveMulti = 0;
            editForm.userName = userName;
            editForm.statisticDate = Convert.ToDateTime(drCurrent["StatisticDate"]);
            editForm.lineID = Convert.ToString(drCurrent["LineID"]);
            editForm.empID = Convert.ToString(drCurrent["EmpID"]);
            editForm.losstimeID = Convert.ToString(drCurrent["LosstimeID"]);
            editForm.losstimeNum = Convert.ToDouble(drCurrent["LosstimeNum"]);
            editForm.losstimeNumTC = Convert.ToDouble(drCurrent["LosstimeNumTC"]);
            editForm.lstEmpID = lstEmpID;
            editForm.dtAll = gridExLosstimeView.GetDataRow(0).Table.Clone();

            DataTable dtEmp = new DataTable();

            dtEmp = empDao.GetAllEmployeeByLineForExLosstime(lblLineID.Text, Convert.ToDateTime(dtpStatisticDate.EditValue), userName);

            for (int iRow = 0; iRow <= dtEmp.Rows.Count - 1; iRow++)
            {
                DataRow drAll = editForm.dtAll.NewRow();
                drAll["StatisticDate"] = drCurrent["StatisticDate"];
                drAll["LineID"] = drCurrent["LineID"];
                drAll["EmpID"] = dtEmp.Rows[iRow]["EmpID"];
                drAll["LosstimeID"] = drCurrent["LosstimeID"];
                drAll["LosstimeName"] = drCurrent["LosstimeName"];
                drAll["LosstimeNum"] = drCurrent["LosstimeNum"];
                drAll["LosstimeNumTC"] = drCurrent["LosstimeNumTC"];
                drAll["Description"] = drCurrent["Description"];
                editForm.dtAll.Rows.Add(drAll);
            }
            //empDao.GetAllEmployeeByLine(lblLineID.Text, userName);
            editForm.ShowDialog();

            LoadData();
        }
        private void DtpStatisticDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData();

                lkeEmployee.Properties.DataSource = empDao.GetAllEmployeeByLineForExLosstime(lblLineID.Text, Convert.ToDateTime(dtpStatisticDate.EditValue), userName);
                lkeEmployee.Properties.DisplayMember = "EmpID";
                lkeEmployee.Properties.ValueMember = "EmpID";
                lkeEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                lkeEmployee.Properties.PopupFilterMode = PopupFilterMode.Contains;

                DataTable dtEmpID = empDao.GetAllEmployeeByLine(lblLineID.Text, Convert.ToDateTime(dtpStatisticDate.EditValue), userName);
                chkCbListEmpID.Properties.DataSource = dtEmpID;
                chkCbListEmpID.Properties.ValueMember = "EmpID";
                chkCbListEmpID.Properties.DisplayMember = "EmpName";
            }
            catch
            {

            }
        }

        private void LkeEmployee_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblEmpName.Text = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(EmpName, '') FROM ASPEmployee WHERE EmpID = '" + Convert.ToString(lkeEmployee.EditValue) + "'");
                LoadData();
            }
            catch
            {

            }
        }

        private void ChkCbListEmpID_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chkCbListEmpID.EditValue.ToString()))
            {
                lstEmpID = chkCbListEmpID.EditValue.ToString().Split(',');

                if (lstEmpID.Length == 1)
                    LoadData();
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
                DataTable dtSave = bdsExLosstime.DataSource as DataTable;

                for (int i = 0; i <= dtSave.Rows.Count - 1; i++)
                {
                    DataRow iDr = dtSave.Rows[i];

                    exLossDTO.StatisticDate = Convert.ToDateTime(iDr["StatisticDate"]);
                    exLossDTO.LineID = Convert.ToString(iDr["LineID"]);
                    exLossDTO.EmpID = Convert.ToString(iDr["EmpID"]);
                    exLossDTO.LosstimeID = Convert.ToString(iDr["LosstimeID"]);
                    exLossDTO.LosstimeNum = Convert.ToDouble(iDr["LosstimeNum"]);
                    exLossDTO.CreatedBy = userName;
                    exLossDTO.CreatedDate = DateTime.Now;
                    exLossDTO.LastModifiedBy = userName;
                    exLossDTO.LastModifiedDate = DateTime.Now;

                    exLossDAO.UpdateExLosstime(exLossDTO);
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
                if (drCurrent == null || string.IsNullOrEmpty(drCurrent["LineID"].ToString()))
                {
                    drCurrent = gridExLosstimeView.GetDataRow(0);
                }

                exLossDTO.StatisticDate = Convert.ToDateTime(drCurrent["StatisticDate"]);
                exLossDTO.LineID = Convert.ToString(drCurrent["LineID"]);
                exLossDTO.EmpID = Convert.ToString(drCurrent["EmpID"]);

                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xoá bảng Losstime này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                    return;

                exLossDAO.DeleteExLosstime(exLossDTO);

                XtraMessageBox.Show("Đã xoá thành công");

                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void BtDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (drCurrent == null || string.IsNullOrEmpty(drCurrent["LineID"].ToString()))
                {
                    drCurrent = gridExLosstimeView.GetDataRow(0);
                }

                exLossDTO.StatisticDate = Convert.ToDateTime(drCurrent["StatisticDate"]);
                exLossDTO.LineID = Convert.ToString(drCurrent["LineID"]);
                exLossDTO.EmpID = string.Empty;

                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xoá tất cả thống kê Losstime này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                    return;

                exLossDAO.DeleteExLosstime(exLossDTO);

                XtraMessageBox.Show("Đã xoá thành công");

                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtEditMulti_Click(object sender, EventArgs e)
        {

            frmExLosstimeEdit editForm = new frmExLosstimeEdit();
            editForm.saveMulti = 1;
            editForm.userName = userName;
            editForm.statisticDate = Convert.ToDateTime(dtpStatisticDate.EditValue).Date;
            editForm.dtSaveMulti = gridExLosstimeView.GetDataRow(0).Table.Clone(); //gridEmpStatView.GetDataRow(gridEmpStatView.GetSelectedRows());
            editForm.lstEmpID = lstEmpID;
            foreach (var iRow in gridExLosstimeView.GetSelectedRows())
            {
                editForm.dtSaveMulti.ImportRow(gridExLosstimeView.GetDataRow(iRow));
            }
            editForm.ShowDialog();

            LoadData();
        }

        private void BtSummary_Click(object sender, EventArgs e)
        {
            frmExLosstimeSummaryByDay frm = new frmExLosstimeSummaryByDay();
            frm.statisticDate = Convert.ToDateTime(dtpStatisticDate.EditValue).Date;
            frm.lineID = (string)_sqlHelpter.ExecQuerySacalar("SELECT TOP 1 ISNULL(LineID, '') FROM ASPEmployee WHERE EmpID = '" + userName + "'");
            frm.username = userName;

            frm.ShowDialog();
        }
        #endregion
    }
}
