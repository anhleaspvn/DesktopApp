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
using System.Runtime.CompilerServices;

//using ASPProject.class_TungLam;

namespace ASPProject
{
    public partial class frmEmployee : DevExpress.XtraEditors.XtraForm
    {
        #region declare
        public string userName;
        public int iNgonNgu, curIndex;
        string empID, hrEmpID, empName, empPosition, empDirect, empLine, description;
        bool quitJob, quitMaternity, isOfficialEmp;

        EmployeeDTO empDto = new EmployeeDTO();
        EmployeeDAO empDao = new EmployeeDAO();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        #endregion

        #region constructor
        public frmEmployee()
        {
            InitializeComponent();

            this.Load += FrmEmployee_Load;
            this.barThoat.ItemClick += BarThoat_ItemClick;
            this.gridEmpView.RowClick += GridEmpView_RowClick;
            this.gridEmpView.DoubleClick += GridEmpView_DoubleClick;
            this.barXuat.ItemClick += barXuat_ItemClick;
            this.barNhap.ItemClick += barNhap_ItemClick;
            this.barIn.ItemClick += barIn_ItemClick;
            this.barNapLai.ItemClick += barNapLai_ItemClick;
            this.barSua.ItemClick += BarSua_ItemClick;
            this.barXoa.ItemClick += BarXoa_ItemClick;
            this.barThem.ItemClick += BarThem_ItemClick;
            this.barMultiEditLine.ItemClick += BarMultiEditLine_ItemClick;
        }
        #endregion

        #region Load
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            frm.LoadVI += new frmMain.Translate(LoadTV);
            frm.LoadEN += new frmMain.Translate(LoadEL);

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
            gridEmp.DataSource = empDao.GetAllEmployee();
            //gridEmpView.SelectRow(curIndex);
        }
        #endregion

        #region Event
        private void BarSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEmployeeEdit editForm = new frmEmployeeEdit();

            editForm.editType = 0;
            editForm.UpdateLine = 0;
            editForm.empID = empID;
            editForm.hrEmpID = hrEmpID;
            editForm.empName = empName;
            editForm.empPosition = empPosition;
            editForm.empDirect = empDirect;
            editForm.empLine = empLine;
            editForm.quitJob = quitJob;
            editForm.quitMaternity = quitMaternity;
            editForm.isOfficialEmp = isOfficialEmp;
            editForm.description = description;
            editForm.userName = userName;

            if (string.IsNullOrEmpty(empID))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select information to edit.");
                }

            }
            else
            {
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void BarMultiEditLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEmployeeEdit editForm = new frmEmployeeEdit();

            editForm.editType = 0;
            editForm.UpdateLine = 1;
            editForm.dtUpdateLine = gridEmpView.GetDataRow(0).Table.Clone();

            foreach (var i in gridEmpView.GetSelectedRows())
            {
                editForm.dtUpdateLine.ImportRow(gridEmpView.GetDataRow(i));
            }

            editForm.userName = userName;

            if (string.IsNullOrEmpty(empID))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select information to edit.");
                }

            }
            else
            {
                editForm.ShowDialog();
                LoadData();
            }
        }

        private void BarXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(empID))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần xoá.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select infomation to delete.");
                }

            }
            else if (iNgonNgu == 0)
            {
                DialogResult a = XtraMessageBox.Show("Bạn có chắc xóa thông tin nhân viên " + empName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {

                    empDto.EmpID = empID;
                    empDao.DeleteEmployee(empDto);
                    LoadData();

                    empID = string.Empty;
                    empName = string.Empty;
                    empPosition = string.Empty;
                    empDirect = string.Empty;
                    empLine = string.Empty;
                    description = string.Empty;
                    quitJob = false;
                }
            }
            else
            {
                DialogResult a = XtraMessageBox.Show(" Are you sure to delete Employee  " + empName + " ???", "Warming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {

                    empDto.EmpID = empID;
                    empDao.DeleteEmployee(empDto);
                    LoadData();

                    empID = string.Empty;
                    empName = string.Empty;
                    empPosition = string.Empty;
                    empDirect = string.Empty;
                    empLine = string.Empty;
                    description= string.Empty;
                    quitJob = false;
                }
            }
        }
        private void BarThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEmployeeEdit th = new frmEmployeeEdit();
            th.userName = userName;
            th.editType = 1;
            th.iNgonNgu = iNgonNgu;
            th.ShowDialog();
            LoadData();
        }
        
        private void BarThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deDongTab();
        }

        private void GridEmpView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dtr = gridEmpView.GetDataRow(e.RowHandle);
            empID = dtr[0].ToString();
            textEdit1.Text = empID.Trim().ToString();
            empName = dtr[1].ToString();
            textEdit2.Text = empName;
            empPosition = dtr[2].ToString();
            empDirect = dtr[3].ToString();
            empLine = dtr[4].ToString();
            quitJob = Convert.ToBoolean(dtr[5]);
            quitMaternity = Convert.ToBoolean(dtr[6]);
            isOfficialEmp = Convert.ToBoolean(dtr[7]);
            hrEmpID = dtr[8].ToString();
            description = dtr[9].ToString();
            curIndex = e.RowHandle;
        }

        private void GridEmpView_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(empID))
            {
                if (iNgonNgu == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn thông tin cần sửa.");
                }
                if (iNgonNgu == 1)
                {
                    XtraMessageBox.Show("Please select information to edit.");
                }

            }
            else
            {
                frmEmployeeEdit editForm = new frmEmployeeEdit();

                editForm.editType = 0;
                editForm.UpdateLine = 0;
                editForm.empID = empID;
                editForm.hrEmpID = hrEmpID;
                editForm.empName = empName;
                editForm.empPosition = empPosition;
                editForm.empDirect = empDirect;
                editForm.empLine = empLine;
                editForm.quitJob = quitJob;
                editForm.quitMaternity = quitMaternity;
                editForm.isOfficialEmp = isOfficialEmp;
                editForm.description = description;
                editForm.userName = userName;

                editForm.ShowDialog();
                LoadData();
            }
        }

        private void barXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridEmp.ExportToXlsx(saveFileDialog1.FileName);

            }
        }

        private void barNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridEmp.ShowPrintPreview();
        }

        private void barNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        #endregion
    }
}