using ASPData;
using ASPData.ASPDAO;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using ASPData.InternalAuditDAO;
using ASPData.InternalAuditDTO;

namespace ASPProject.InternalAudit
{
    public partial class frmInternalAuditReport : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public int editType;
        public int iNgonNgu;
        public string factoryID, deptID, userName;
        DataTable dtFactory = new DataTable();
        DataTable dtDept = new DataTable();
        ASPDAO aspDao = new ASPDAO();
        ASPExcelDataProcess.ASPExcelDataProcess excelProc = new ASPExcelDataProcess.ASPExcelDataProcess();
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        InternalAuditDTO iaDto = new InternalAuditDTO();
        InternalAuditDAO iaDao = new InternalAuditDAO();

        //BOD
        public string ASM1ReportBOD = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\01 BOD\\Internal audit report - BOD.xlsx";
        public string ASM2ReportBOD = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\01 BOD\\Internal audit report - BOD.xlsx";

        //CS
        public string ASM1ReportCS = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\02 CS\\Internal audit report - CS.xlsx";
        public string ASM2ReportCS = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\02 CS\\Internal audit report - CS.xlsx";

        //PLAN
        public string ASM1ReportPLAN = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\03 PLAN\\Internal audit report - PL.xlsx";
        public string ASM2ReportPLAN = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\03 PLAN\\Internal audit report - PL.xlsx";

        //PU
        public string ASM1ReportPU = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\04 PU\\Internal audit report - PU.xlsx";
        public string ASM2ReportPU = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\04 PU\\Internal audit report - PU.xlsx";

        //EN
        public string ASM1ReportEN = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\05 EN\\Internal audit report - EN.xlsx";
        public string ASM2ReportEN = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\01 EN\\Internal audit report - EN.xlsx";

        //PD
        public string ASM1ReportPD = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\06 PD\\Internal audit report - PD.xlsx";
        public string ASM2ReportPD = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\02 PD\\Internal audit report - PD.xlsx";

        //QUALITY
        public string ASM1ReportQUALITY = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\07 QUALITY\\Internal audit report - QA.xlsx";
        public string ASM2ReportQUALITY = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\03 QUALITY\\Internal audit report - QA.xlsx";

        //WH
        public string ASM1ReportWH = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\08 WH\\Internal audit report - WH.xlsx";
        public string ASM2ReportWH = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM2\\04 WH\\Internal audit report - WH.xlsx";

        //HR
        //WH
        public string ASM1ReportHR = Application.StartupPath + "\\InternalAudit\\03 Internal audit report\\ASM1\\09 HR-GA\\Internal audit report - HR-GA.xlsx";

        //BOD CAR
        public string ASM1CarBOD = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\01 BOD\\CAR.xlsx";
        public string ASM2CarBOD = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\01 BOD\\CAR.xlsx";

        //CS CAR
        public string ASM1CarCS = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\02 CS\\CAR.xlsx";
        public string ASM2CarCS = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\02 CS\\CAR.xlsx";

        //PLAN CAR
        public string ASM1CarPLAN = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\03 PLAN\\CAR.xlsx";
        public string ASM2CarPLAN = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\03 PLAN\\CAR.xlsx";

        //PU CAR
        public string ASM1CarPU = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\04 PU\\CAR.xlsx";
        public string ASM2CarPU = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\04 PU\\CAR.xlsx";

        //EN CAR
        public string ASM1CarEN = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\05 EN\\CAR.xlsx";
        public string ASM2CarEN = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\01 EN\\CAR.xlsx";

        //PD CAR
        public string ASM1CarPD = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\06 PD\\CAR.xlsx";
        public string ASM2CarPD = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\02 PD\\CAR.xlsx";

        //QUA CAR
        public string ASM1CarQuality = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\07 QUALITY\\CAR.xlsx";
        public string ASM2CarQuality = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\03 QUALITY\\CAR.xlsx";

        //WH CAR
        public string ASM1CarWH = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\08 WH\\CAR.xlsx";
        public string ASM2CarWH = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM2\\04 WH\\CAR.xlsx";

        //HR CAR
        public string ASM1CarHR = Application.StartupPath + "\\InternalAudit\\05 CAR\\ASM1\\09 HR-GA\\CAR.xlsx";

        //Summary ASM1
        public string ASM1Sum = Application.StartupPath + "\\InternalAudit\\04 Summary\\ASM1\\Summary.xlsx";

        //Summary ASM2
        public string ASM2Sum = Application.StartupPath + "\\InternalAudit\\04 Summary\\ASM2\\Summary.xlsx";


        #endregion

        #region Load
        public frmInternalAuditReport()
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

            btCancel.Click += BtCancel_Click;
            btView.Click += BtView_Click; ;
            btSummary.Click += BtSummary_Click;
            btAudit.Click += BtAudit_Click;
        }

        private void BtView_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
               
                DataTable dtTemplate = new DataTable();
                dtTemplate = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPISOReport WHERE ISOReportID = 'IAReport'");

                iaDto.FactoryID = Convert.ToString(lkeFactoryID.EditValue);
                iaDto.DeptID = Convert.ToString(lkeDeptID.EditValue);

                for (int i = 0; i < dtTemplate.Rows.Count; i++)
                {
                    string sqlProc = Convert.ToString(dtTemplate.Rows[i]["ISOReportProc"]);
                    string excelSheet = Convert.ToString(dtTemplate.Rows[i]["ISOReportSheet"]);
                    string excelRange = Convert.ToString(dtTemplate.Rows[i]["ISOReportRange"]);
                    string[] arrRange = excelRange.Split(',');
                    string fileTemplate = Application.StartupPath + "\\" + Convert.ToString(dtTemplate.Rows[i]["ISOTemplatePath"]);
                    string localPath = Path.GetDirectoryName(fileTemplate);
                    string resultFilename = Convert.ToString(dtTemplate.Rows[i]["ISOResultName"]);
                    string resultTemplate = @"\\" + Convert.ToString(dtTemplate.Rows[i]["ISOResultPath"]) + "\\" + resultFilename + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx";
                    string networkPath = Convert.ToString(dtTemplate.Rows[i]["ISONetworkPath"]);
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    WindowsImpersonationContext context = identity.Impersonate();

                    string myNetworkPath = networkPath + resultFilename + ".xlsx";
                    string myLocalPath = localPath + "\\" + resultFilename + ".xlsx";

                    using (context)
                    {
                        ds = iaDao.GetIAReport(iaDto, sqlProc);

                        if (arrRange.Length > 0)
                        {
                            for (int j = 0; j <= arrRange.Length - 1; j++)
                            {
                                if (!File.Exists(myLocalPath))
                                    excelProc.WriteDataIntoExcelFile(ds.Tables[j], fileTemplate, excelSheet, arrRange[j], myLocalPath);
                                else
                                    excelProc.WriteDataIntoExcelFile(ds.Tables[j], myLocalPath, excelSheet, arrRange[j], myLocalPath);

                                if (j == arrRange.Length - 1)
                                    File.Copy(myLocalPath, myNetworkPath, true);
                            }
                        }
                        if (arrRange.Length == 1)
                        {
                            if (!File.Exists(myLocalPath))
                                excelProc.WriteDataIntoExcelFile(ds.Tables[0], fileTemplate, excelSheet, arrRange[0], myLocalPath);
                            else
                                excelProc.WriteDataIntoExcelFile(ds.Tables[0], myLocalPath, excelSheet, arrRange[0], myLocalPath);
                            File.Copy(myLocalPath, myNetworkPath, true);
                        }
                    }
                }

                XtraMessageBox.Show("Đã xuất file thành công.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtSummary_Click(object sender, EventArgs e)
        {
            string BOD = (string)excelProc.ReadDataFromExcelFile(ASM1ReportBOD, "BOD", "C8").Rows[0][0];
            excelProc.WriteDataIntoExcelFileStr(BOD, ASM1Sum, "Summary new", "C7", ASM1Sum);
        }

        private void BtAudit_Click(object sender, EventArgs e)
        {
            frmInternalAuditInput frmInput = new frmInternalAuditInput();
            frmInput.deptID = Convert.ToString(lkeDeptID.EditValue);
            frmInput.factoryID = Convert.ToString(lkeFactoryID.EditValue);
            frmInput.userName = userName;
            frmInput.Show();
        }

        //private void BtView_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(lkeFactoryID.EditValue.ToString()))
        //    {
        //        XtraMessageBox.Show("Vui lòng chọn nhà máy.");
        //        return;
        //    }
                

        //    if (string.IsNullOrEmpty(lkeDeptID.EditValue.ToString()))
        //    {
        //        XtraMessageBox.Show("Vui lòng chọn phòng ban.");
        //        return;
        //    }

        //    if (editType == 0)
        //    {
        //        switch (lkeDeptID.EditValue.ToString())
        //        {
        //            case "BOD":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportBOD);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportBOD);
        //                break;
        //            case "CS":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportCS);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportCS);
        //                break;
        //            case "PLAN":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportPLAN);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportPLAN);
        //                break;
        //            case "PU":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportPU);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportPU);
        //                break;
        //            case "EN":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportEN);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportEN);
        //                break;
        //            case "PD":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportPD);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportPD);
        //                break;
        //            case "QUALITY":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportQUALITY);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportQUALITY);
        //                break;
        //            case "WH":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportWH);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2ReportWH);
        //                break;

        //            case "HR":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1ReportHR);
                       
        //                break;
        //        }
        //    }    
        //    if (editType == 1) //Car
        //    {
        //        switch (lkeDeptID.EditValue.ToString())
        //        {
        //            case "BOD":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarBOD);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarBOD);
        //                break;
        //            case "CS":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarCS);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarCS);
        //                break;
        //            case "PLAN":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarPLAN);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarPLAN);
        //                break;
        //            case "PU":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarPU);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarPU);
        //                break;
        //            case "EN":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarEN);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarEN);
        //                break;
        //            case "PD":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarPD);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarPD);
        //                break;
        //            case "QUALITY":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarQuality);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarQuality);
        //                break;
        //            case "WH":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarWH);
        //                else
        //                    System.Diagnostics.Process.Start(ASM2CarWH);
        //                break;
        //            case "HR":
        //                if (lkeFactoryID.EditValue.ToString().ToUpper() == "KIZUNA")
        //                    System.Diagnostics.Process.Start(ASM1CarHR);

        //                break;
        //        }
        //    }    
        //}

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
