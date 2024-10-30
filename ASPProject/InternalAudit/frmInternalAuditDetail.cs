using ASPData.ASPDAO;
using ASPData.ASPDTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject.InternalAudit
{
    public partial class frmInternalAuditDetail : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration
        public string userName;
        public int editType;
        public int iNgonNgu;
        public string factoryID, deptID;
        DataTable dtFactory = new DataTable();

        ASPDTO aspDto = new ASPDTO();
        ASPDAO aspDao = new ASPDAO();
        ASPExcelDataProcess.ASPExcelDataProcess excel = new ASPExcelDataProcess.ASPExcelDataProcess();
        frmInternalAuditReport frmRpt = new frmInternalAuditReport();

        //ASM1 Summary
        private string ASM1Summary = Application.StartupPath + "\\InternalAudit\\04 Summary\\ASM1\\Summary.xlsx";
        //ASM2 Summary
        private string ASM2Summary = Application.StartupPath + "\\InternalAudit\\04 Summary\\ASM2\\Summary.xlsx";
        #endregion

        #region Load
        public frmInternalAuditDetail()
        {
            InitializeComponent();

            dtFactory = aspDao.GetFactoryList();

            lkeFactoryID.Properties.DataSource = dtFactory;
            lkeFactoryID.Properties.DisplayMember = "Ten_NhaMay";
            lkeFactoryID.Properties.ValueMember = "Ma_NhaMay";
            lkeFactoryID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkeFactoryID.Properties.PopupFilterMode = PopupFilterMode.Contains;

            this.Load += FrmInternalAuditDetail_Load;

            btView.Click += BtView_Click;
            btCancel.Click += BtCancel_Click;
            btSummary.Click += BtSummary_Click;
        }

        private void FrmInternalAuditDetail_Load(object sender, EventArgs e)
        {
            aspDto.FuncID = "InternalAuditControl";
            aspDto.UserName = userName;

            DataTable dtSum = aspDao.GetLockAdminList(aspDto);

            if (dtSum.Rows.Count > 0)
                btSummary.Visible = true;
            else
                btSummary.Visible = false;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtSummary_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn tổng hợp kết quả ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            if (string.IsNullOrEmpty(lkeFactoryID.EditValue.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn nhà máy để tổng hợp !");
                return;
            }
            switch (lkeFactoryID.EditValue.ToString().ToUpper().Trim())
            {
                case "KIZUNA":
                    for (int i = 20; i <= 54; i++)
                    {
                        //BOD
                        string CellBODContPre = "L" + i.ToString();
                        string CellBODContCheck = "Q" + i.ToString();

                        string BODCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportBOD, "BOD", CellBODContCheck);

                        if (BODCheck.Contains("OFI") || BODCheck.Contains("NC"))
                        {
                            string BODCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportBOD, "BOD", CellBODContPre);
                            excel.WriteDataIntoExcelFileStr(BODCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string BODDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportBOD, "BOD", "C8");
                            excel.WriteDataIntoExcelFileStr(BODDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string BODDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportBOD, "BOD", "C9");
                            excel.WriteDataIntoExcelFileStr(BODDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string BODPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportBOD, "BOD", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(BODPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string BODConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportBOD, "BOD", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(BODConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //CS
                        string CellCSContPre = "L" + i.ToString();
                        string CellCSContCheck = "Q" + i.ToString();

                        string CSCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportCS, "CS", CellCSContCheck);

                        if (CSCheck.Contains("OFI") || CSCheck.Contains("NC"))
                        {
                            string CSCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportCS, "CS", CellCSContPre);
                            excel.WriteDataIntoExcelFileStr(CSCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string CSDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportCS, "CS", "C8");
                            excel.WriteDataIntoExcelFileStr(CSDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string CSDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportCS, "CS", "C9");
                            excel.WriteDataIntoExcelFileStr(CSDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string CSPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportCS, "CS", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(CSPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string CSConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportCS, "CS", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(CSConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //PLAN

                        string CellPLContPre = "L" + i.ToString();
                        string CellPLContCheck = "Q" + i.ToString();

                        string PLCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPLAN, "PL", CellPLContCheck);

                        if (PLCheck.Contains("OFI") || PLCheck.Contains("NC"))
                        {
                            string PLCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPLAN, "PL", CellPLContPre);
                            excel.WriteDataIntoExcelFileStr(PLCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PLDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPLAN, "PL", "C8");
                            excel.WriteDataIntoExcelFileStr(PLDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PLDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPLAN, "PL", "C9");
                            excel.WriteDataIntoExcelFileStr(PLDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PLPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPLAN, "PL", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PLPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PLConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPLAN, "PL", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PLConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //PU

                        string CellPUContPre = "L" + i.ToString();
                        string CellPUContCheck = "Q" + i.ToString();

                        string PUCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPU, "PU", CellPUContCheck);

                        if (PUCheck.Contains("OFI") || PUCheck.Contains("NC"))
                        {
                            string PUCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPU, "PU", CellPUContPre);
                            excel.WriteDataIntoExcelFileStr(PUCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PUDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPU, "PU", "C8");
                            excel.WriteDataIntoExcelFileStr(PUDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PUDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPU, "PU", "C9");
                            excel.WriteDataIntoExcelFileStr(PUDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PUPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPU, "PU", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PUPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PUConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPU, "PU", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PUConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //EN
                        string CellENGContPre = "L" + i.ToString();
                        string CellENGContCheck = "Q" + i.ToString();

                        string ENGCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportEN, "ENG", CellENGContCheck);

                        if (ENGCheck.Contains("OFI") || ENGCheck.Contains("NC"))
                        {
                            string ENGCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportEN, "ENG", CellENGContPre);
                            excel.WriteDataIntoExcelFileStr(ENGCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportEN, "ENG", "C8");
                            excel.WriteDataIntoExcelFileStr(ENGDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportEN, "ENG", "C9");
                            excel.WriteDataIntoExcelFileStr(ENGDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportEN, "ENG", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(ENGPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportEN, "ENG", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(ENGConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //PD
                        string CellPDContPre = "L" + i.ToString();
                        string CellPDContCheck = "Q" + i.ToString();

                        string PDCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPD, "PD", CellPDContCheck);

                        if (PDCheck.Contains("OFI") || PDCheck.Contains("NC"))
                        {
                            string PDCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPD, "PD", CellPDContPre);
                            excel.WriteDataIntoExcelFileStr(PDCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPD, "PD", "C8");
                            excel.WriteDataIntoExcelFileStr(PDDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPD, "PD", "C9");
                            excel.WriteDataIntoExcelFileStr(PDDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPD, "PD", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PDPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportPD, "PD", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PDConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //QUALITY
                        string CellQUALITYContPre = "L" + i.ToString();
                        string CellQUALITYContCheck = "Q" + i.ToString();

                        string QUALITYCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportQUALITY, "QUALITY", CellQUALITYContCheck);

                        if (QUALITYCheck.Contains("OFI") || QUALITYCheck.Contains("NC"))
                        {
                            string QUALITYCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportQUALITY, "QUALITY", CellQUALITYContPre);
                            excel.WriteDataIntoExcelFileStr(QUALITYCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportQUALITY, "QUALITY", "C8");
                            excel.WriteDataIntoExcelFileStr(QUALITYDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportQUALITY, "QUALITY", "C9");
                            excel.WriteDataIntoExcelFileStr(QUALITYDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportQUALITY, "QUALITY", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(QUALITYPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportQUALITY, "QUALITY", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(QUALITYConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //WH

                        string CellWHContPre = "L" + i.ToString();
                        string CellWHContCheck = "Q" + i.ToString();

                        string WHCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportWH, "WH", CellWHContCheck);

                        if (WHCheck.Contains("OFI") || WHCheck.Contains("NC"))
                        {
                            string WHCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportWH, "WH", CellWHContPre);
                            excel.WriteDataIntoExcelFileStr(WHCont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportWH, "WH", "C8");
                            excel.WriteDataIntoExcelFileStr(WHDept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportWH, "WH", "C9");
                            excel.WriteDataIntoExcelFileStr(WHDate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportWH, "WH", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(WHPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportWH, "WH", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(WHConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //HR-GA

                        string CellHRGAContPre = "L" + i.ToString();
                        string CellHRGAContCheck = "Q" + i.ToString();

                        string HRGACheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportHR, "HR", CellHRGAContCheck);

                        if (HRGACheck.Contains("OFI") || HRGACheck.Contains("NC"))
                        {
                            string HRGACont = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportHR, "HR", CellHRGAContPre);
                            excel.WriteDataIntoExcelFileStr(HRGACont, frmRpt.ASM1Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string HRGADept = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportHR, "HR", "C8");
                            excel.WriteDataIntoExcelFileStr(HRGADept, frmRpt.ASM1Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string HRGADate = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportHR, "HR", "C9");
                            excel.WriteDataIntoExcelFileStr(HRGADate, frmRpt.ASM1Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string HRGAPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportHR, "HR", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(HRGAPerson, frmRpt.ASM1Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string HRGAConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM1ReportHR, "HR", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(HRGAConlud, frmRpt.ASM1Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }
                    }    
                    break;
                case "LONGHAU":
                    for (int i = 20; i <= 54; i++)
                    {
                        //EN
                        string CellENGContPre = "L" + i.ToString();
                        string CellENGContCheck = "Q" + i.ToString();

                        string ENGCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportEN, "ENG", CellENGContCheck);

                        if (ENGCheck.Contains("OFI") || ENGCheck.Contains("NC"))
                        {
                            string ENGCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportEN, "ENG", CellENGContPre);
                            excel.WriteDataIntoExcelFileStr(ENGCont, frmRpt.ASM2Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportEN, "ENG", "C8");
                            excel.WriteDataIntoExcelFileStr(ENGDept, frmRpt.ASM2Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportEN, "ENG", "C9");
                            excel.WriteDataIntoExcelFileStr(ENGDate, frmRpt.ASM2Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportEN, "ENG", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(ENGPerson, frmRpt.ASM2Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string ENGConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportEN, "ENG", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(ENGConlud, frmRpt.ASM2Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //PD
                        string CellPDContPre = "L" + i.ToString();
                        string CellPDContCheck = "Q" + i.ToString();

                        string PDCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportPD, "PD", CellPDContCheck);

                        if (PDCheck.Contains("OFI") || PDCheck.Contains("NC"))
                        {
                            string PDCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportPD, "PD", CellPDContPre);
                            excel.WriteDataIntoExcelFileStr(PDCont, frmRpt.ASM2Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportPD, "PD", "C8");
                            excel.WriteDataIntoExcelFileStr(PDDept, frmRpt.ASM2Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportPD, "PD", "C9");
                            excel.WriteDataIntoExcelFileStr(PDDate, frmRpt.ASM2Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportPD, "PD", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PDPerson, frmRpt.ASM2Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string PDConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportPD, "PD", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(PDConlud, frmRpt.ASM2Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //QUALITY
                        string CellQUALITYContPre = "L" + i.ToString();
                        string CellQUALITYContCheck = "Q" + i.ToString();

                        string QUALITYCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportQUALITY, "QUALITY", CellQUALITYContCheck);

                        if (QUALITYCheck.Contains("OFI") || QUALITYCheck.Contains("NC"))
                        {
                            string QUALITYCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportQUALITY, "QUALITY", CellQUALITYContPre);
                            excel.WriteDataIntoExcelFileStr(QUALITYCont, frmRpt.ASM2Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportQUALITY, "QUALITY", "C8");
                            excel.WriteDataIntoExcelFileStr(QUALITYDept, frmRpt.ASM2Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportQUALITY, "QUALITY", "C9");
                            excel.WriteDataIntoExcelFileStr(QUALITYDate, frmRpt.ASM2Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportQUALITY, "QUALITY", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(QUALITYPerson, frmRpt.ASM2Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string QUALITYConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportQUALITY, "QUALITY", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(QUALITYConlud, frmRpt.ASM2Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }

                        //WH
                        string CellWHContPre = "L" + i.ToString();
                        string CellWHContCheck = "Q" + i.ToString();

                        string WHCheck = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportWH, "WH", CellWHContCheck);

                        if (WHCheck.Contains("OFI") || WHCheck.Contains("NC"))
                        {
                            string WHCont = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportWH, "WH", CellWHContPre);
                            excel.WriteDataIntoExcelFileStr(WHCont, frmRpt.ASM2Sum, "Summary new", "I" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHDept = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportWH, "WH", "C8");
                            excel.WriteDataIntoExcelFileStr(WHDept, frmRpt.ASM2Sum, "Summary new", "C" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHDate = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportWH, "WH", "C9");
                            excel.WriteDataIntoExcelFileStr(WHDate, frmRpt.ASM2Sum, "Summary new", "E" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHPerson = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportWH, "WH", "S" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(WHPerson, frmRpt.ASM2Sum, "Summary new", "G" + (i - 13).ToString(), frmRpt.ASM1Sum);

                            string WHConlud = excel.ReadDataFromExcelFileStr(frmRpt.ASM2ReportWH, "WH", "Q" + i.ToString());
                            excel.WriteDataIntoExcelFileStr(WHConlud, frmRpt.ASM2Sum, "Summary new", "O" + (i - 13).ToString(), frmRpt.ASM1Sum);
                        }
                    }    
                    break;
            }

            XtraMessageBox.Show("Đã tổng hợp thành công !");
        }

        private void BtAudit_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Test");
        }

        private void BtView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lkeFactoryID.EditValue.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn nhà máy.");
                return;
            }

            if (editType == 0) //summary
            {
                switch (lkeFactoryID.EditValue.ToString().ToUpper())
                {
                    case "KIZUNA":
                        System.Diagnostics.Process.Start(ASM1Summary);
                        break;
                    case "LONGHAU":
                        System.Diagnostics.Process.Start(ASM2Summary);
                        break;
                }
            }
        }
        #endregion
    }
}
