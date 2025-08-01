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
using ASPData.MachineDTO;
using ASPData.MachineDAO;
using System.Runtime.CompilerServices;
using ASPData;

namespace ASPProject.Machine
{
    public partial class frmMachine : DevExpress.XtraEditors.XtraForm
    {
        #region declare
        public string userName;
        public int iNgonNgu, curIndex, maintenanceMachine;
        string machineID, machineName, machineGroup;

        MachineDTO machineDto = new MachineDTO();
        MachineDAO machineDao = new MachineDAO();
        BindingSource bdsMachine = new BindingSource();

        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        #region constructor
        public frmMachine()
        {
            InitializeComponent();

            this.Load += FrmMachine_Load;
            this.btImportExcel.Click += BtImportExcel_Click;
            this.btExport.Click += BtExport_Click;
            this.btDelete.Click += BtDelete_Click;
        }
        #endregion

        #region load
        private void FrmMachine_Load(object sender, EventArgs e)
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
            bdsMachine.DataSource = machineDao.GetAllMachine();
            gridMachine.DataSource = bdsMachine;
        }
        #endregion

        #region event
        private void BtImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.Title = "Open Excel File";
            openExcel.Filter = "XLSX files|*.xlsx";
            openExcel.InitialDirectory = @"C:\";

            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //
                    ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();
                    DataTable dtExcel = new DataTable();
                    dtExcel = excel.ReadDataFromExcelFile(openExcel.FileName, "Sheet1", "A1:D10000");
                  
                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        DataRow dr = dtExcel.Rows[i];

                        if (i == 0)
                        {
                            string MachineID = dtExcel.Rows.Count > 0 ? Convert.ToString(dr["MachineID"]) : string.Empty;
                            _sqlHelper.ExecQueryNonData("DELETE FROM ASPMachine WHERE MachineID = '" + MachineID + "'");
                        }
                        else if (i > 0)
                        {
                            int j = i - 1;
                            DataRow drTemp = dtExcel.Rows[j];
                            if (dr["MachineID"] != drTemp["MachineID"])
                            {
                                string MachineID = dtExcel.Rows.Count > 0 ? Convert.ToString(dr["MachineID"]) : string.Empty;
                                _sqlHelper.ExecQueryNonData("DELETE FROM ASPMachine WHERE MachineID = '" + MachineID + "'");
                            }
                        }

                        machineDto.MachineID = Convert.ToString(dr["MachineID"]);
                        machineDto.MachineName = Convert.ToString(dr["MachineName"]);
                        machineDto.MaintenanceMonth = Convert.ToInt32(dr["MaintenanceMonth"]);
                        machineDto.MachineGroup = Convert.ToString(dr["MachineGroup"]);
                        machineDto.CreatedBy = userName;
                        machineDto.CreatedDate = DateTime.Now;
                        machineDto.LastModifiedBy = userName;
                        machineDto.LastModifiedDate = DateTime.Now;

                        machineDao.ImportExcelMachine(machineDto);
                    }

                    XtraMessageBox.Show("Import dữ liệu thành công.");

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BtExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            saveFileDialog1.Title = "Save an File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridMachineView.ExportToXlsx(saveFileDialog1.FileName);
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xoá máy này không ?", "Thông  báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow drRow = ((DataRowView)bdsMachine.Current).Row;
                if (drRow == null)
                    return;

                string machineID = (string)drRow["MachineID"];

                var dicParams = new Dictionary<string, object>()
                {
                    { "@MachineID", machineID }
                };

                _sqlHelper.ExecQueryNonData("DELETE FROM ASPMachine WHERE MachineID = @MachineID", dicParams);

                LoadData();
            }
        }
        #endregion
    }
}
