using ASPData.ASPDAO;
using ASPGoogleSheet;
using ASPMachineMonitor;
using ASPProject.AppTemplateSkillMap;
using ASPProject.AppTemplateSkillMapV2;
using ASPProject.AttendanceEmployee;
using ASPProject.DefectiveMode;
using ASPProject.ExLosstime;
using ASPProject.ExternalIQC;
using ASPProject.HRAbsenceDoc;
using ASPProject.InternalAudit;
using ASPProject.LineProdStatistic;
using ASPProject.Losstime;
using ASPProject.Machine;
using ASPProject.PlaningMasterList;
using ASPProject.ProdQRCodeMaster;
using ASPProject.Properties;
using ASPProject.ScanBarCodeBin;
using ASPProject.SOPStage;
using ASPProject.Timekeeping;
using ASPProject.ASPAlternatingLevelSchedule;
using ASPProject.AlternatingLeaveSchedule;
using QRCoder;
using System.Drawing.Imaging;
using DevComponents.DotNetBar;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Html;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ASPProject
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ASPControl.Loadingggg ld = new ASPControl.Loadingggg();
        private readonly ASPDAO aspDao = new ASPDAO();
        private ASPData.ASPData data = new ASPData.ASPData();

        public frmMain()
        {
            InitializeComponent();

            btExportReportExcel.ItemClick += BtExportReportExcel_ItemClick;
            btMachineChart.ItemClick += BtMachineChart_ItemClick;
            btDefectMode.ItemClick += BtDefectMode_ItemClick;
            btLosstime.ItemClick += BtLosstime_ItemClick;
            btProdStatistic.ItemClick += BtProdStatistic_ItemClick;
            btProdStatisticASM2.ItemClick += BtProdStatisticASM2_ItemClick;
            btTimekeeping.ItemClick += BtTimekeeping_ItemClick;
            btAttendance.ItemClick += BtAttendance_ItemClick;
            btProdExLosstime.ItemClick += BtProdExLosstime_ItemClick;
            btOutputChart.ItemClick += BtOutputChart_ItemClick;
            btProdReport.ItemClick += BtProdReport_ItemClick;
            btExDimQC.ItemClick += BtExDimQC_ItemClick;
            btHRAbsence.ItemClick += BtHRAbsence_ItemClick;
            btNFCReader.ItemClick += BtNFCReader_ItemClick;
            btAttendanceTable.ItemClick += BtAttendanceTable_ItemClick;
            btProdPlan.ItemClick += BtProdPlan_ItemClick;
            btHRAbsenceByStaff.ItemClick += BtHRAbsenceByStaff_ItemClick;
            btWOSOP.ItemClick += BtWOSOP_ItemClick;
            btQCOutputChart.ItemClick += BtQCChart_ItemClick;
            btInternalAudit.ItemClick += BtInternalAudit_ItemClick;
            btSumReport.ItemClick += BtSumReport_ItemClick;
            btRptMatStage.ItemClick += BtRptMatStage_ItemClick;
            btProdORChart.ItemClick += BtProdORChart_ItemClick;
            btAbsenceDoc.ItemClick += BtAbsenceDoc_ItemClick;
            btRptMold.ItemClick += BtRptMold_ItemClick;
            btAbsenceFollow.ItemClick += BtAbsenceFollow_ItemClick;
            ribbon.Paint += Ribbon_Paint;
            btRptMachineStage.ItemClick += BtRptMachineStage_ItemClick;
            btMachine.ItemClick += BtMachine_ItemClick;
            btEmpCapacity.ItemClick += BtEmpCapacity_ItemClick;
            btIsoEmail.ItemClick += BtIsoEmail_ItemClick;
            btScanBarcodeBin.ItemClick += BtScanBarcodeBin_ItemClick;
            btQRCodeMaster.ItemClick += BtQRCodeMaster_ItemClick;
            btProdScanQRCodeLog.ItemClick += BtProdScanQRCodeLog_ItemClick;
            btTraceability.ItemClick += BtTracebility_ItemClick;
            btScanQRCodeJig.ItemClick += BtScanQRCodeJig_ItemClick;
            btDetailTableJig.ItemClick += BtDetailTableJig_ItemClick;
            btSBLine.ItemClick += BtSBLine_ItemClick;
            btSumDataQRCode.ItemClick += BtSumDataQRCode_ItemClick;
            btBinQCApproval.ItemClick += BtBinQCApproval_ItemClick;
            btMachineIns.ItemClick += BtMachineIns_ItemClick;
            btPlanning.ItemClick += BtPlanning_ItemClick;
            btSkillmap.ItemClick += BtSkillmap_ItemClick;
            btScanQR037.ItemClick += BtScanQR037_ItemClick;
            btIPQCInspect.ItemClick += BtIPQCInspect_ItemClick;
            btLineProductivity.ItemClick += BtLineProductivity_ItemClick;
            btAlternative.ItemClick += BtAlternative_ItemClick;
            btXuatQR.ItemClick += BtXuatQR_ItemClick;
        }

        private void BtLineProductivity_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng kế hoạch sản xuất";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Production planning table";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Line productivity";
                frmLineProductivity frm = new frmLineProductivity();

                frm.deDongTab = new frmLineProductivity._deDongTab(vDOngTab);
                frm.frm = this;
                frm.iNgonNgu = iNgonNgu;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        public static void GenerateQr(string content, string savePath)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(
                    content,
                    QRCodeGenerator.ECCLevel.Q
                );

                using (QRCode qrCode = new QRCode(qrCodeData))
                using (Bitmap qrImage = qrCode.GetGraphic(10))
                {
                    qrImage.Save(savePath, ImageFormat.Png);
                }
            }
        }

        private void BtXuatQR_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dic = new Dictionary<string, object>();

            string sql = "SELECT * FROM TempQRCodeEmp WHERE QRType = 2";

            ASPData.SQLHelper hp = new ASPData.SQLHelper();
            DataTable dt = hp.ExecQueryDataAsDataTable(sql, dic);

            string dir = Path.Combine(Application.StartupPath, "QROthers");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            foreach (DataRow dr in dt.Rows)
            {
                string empID = !string.IsNullOrEmpty(dr["EmpID"].ToString()) ? dr["EmpID"].ToString() : string.Empty;
                string empName = !string.IsNullOrEmpty(dr["EmpName"].ToString()) ? dr["EmpName"].ToString() : string.Empty;
                string deptName = !string.IsNullOrEmpty(dr["DeptName"].ToString()) ? dr["DeptName"].ToString() : string.Empty;
                string factory = !string.IsNullOrEmpty(dr["Factory"].ToString()) ? dr["Factory"].ToString() : string.Empty;

                string qrContent = empID + "-" + empName + "-" + deptName + "-" + factory;
                string filePath = Path.Combine(dir, empName + ".png");

                GenerateQr(qrContent, filePath);
            }
        }

        private void BtAlternative_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Đăng ký lịch nghỉ luân phiên";
            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Leaves Alternative";
            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Chart";

            frmAlternatingLevelSchedule machineChart = new frmAlternatingLevelSchedule(sManv);
            machineChart.TopLevel = false;

            t.AttachedControl.Controls.Add(machineChart);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            machineChart.Show();
            ld.simpleCloseWait();
        }

        private void BtIPQCInspect_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "IPQC Inspection";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "IPQC Inspection";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "IPQC Inspection";

            frmIPQCInspec prodQr = new frmIPQCInspec();

            prodQr.TopLevel = false;
            prodQr.Dock = DockStyle.Fill;
            prodQr.userName = sManv;
            prodQr.frm = this;
            t.AttachedControl.Controls.Add(prodQr);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            prodQr.Show();

            ld.simpleCloseWait();
        }

        private void BtScanQR037_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Scan QR Code P";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Scan QR Code P";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Scan QR Code P";

            frmProdScanQRCodeLog prodQr = new frmProdScanQRCodeLog();

            prodQr.TopLevel = false;
            prodQr.Dock = DockStyle.Fill;
            prodQr.userName = sManv;
            prodQr.frm = this;
            t.AttachedControl.Controls.Add(prodQr);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            prodQr.Show();

            ld.simpleCloseWait();
        }

        //read data from GGS to write to DB
        private void BtReadGGS_ItemClick(object sender, ItemClickEventArgs e)
        {
            SyncDashboardIndex();
        }

        public void SyncDashboardIndex()
        {
            try
            {
                SyncWHIndex();
                SyncHRIndex();
                SyncQCIndex();

                MessageBox.Show("Đã cập nhật thành công!");
            }
            catch (Exception ex)
            {
                // lỗi hệ thống rất lớn (credential, config, app chết)
                MessageBox.Show(ex.ToString());
            }
        }

        private void SyncWHIndex()
        {
            try
            {
                string credentialFile = "credentials.json";
                string spreadSheetID = "1bn5kLlwrPGYR0iK2pC9ORlyCUNBNEPEx2fc97lUVoB8";

                var ggs = new GoogleSheetsHelper(credentialFile, spreadSheetID);
                var ggsParams = new GoogleSheetParameters
                {
                    SheetName = "Sheet1",
                    FirstRowIsHeaders = true,
                    RangeRowStart = 1,
                    RangeColumnStart = 1,
                    RangeColumnEnd = 3,
                    RangeRowEnd = 10000
                };

                DataTable dt = GGSExtension.ToDataTable(ggs.GetDataFromSheet(ggsParams));

                using (SqlConnection conn = new SqlConnection(
                    data.ASPDecrypt(ASPData.configDatabase.CONNECTION_STRINGS)))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            new SqlCommand(
                                "TRUNCATE TABLE dbo.ASPWHCSChartIndex", conn, tran
                            ).ExecuteNonQuery();

                            using (SqlBulkCopy bulk = new SqlBulkCopy(
                                conn, SqlBulkCopyOptions.TableLock, tran))
                            {
                                bulk.DestinationTableName = "dbo.ASPWHCSChartIndex";
                                bulk.BatchSize = 5000;
                                bulk.BulkCopyTimeout = 0;

                                bulk.ColumnMappings.Add("StatisticDate", "StatisticDate");
                                bulk.ColumnMappings.Add("InventoryTurn", "InventoryTurn");
                                bulk.ColumnMappings.Add("OTD", "OTD");

                                bulk.WriteToServer(dt);
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SyncHRIndex()
        {
            try
            {
                string credentialFile = "credentials.json";
                string spreadSheetID = "1tjZC0xyQpwyc5pgDz1Cz_ksUrbx4_s_K1NrpK7R3kwI";

                var ggs = new GoogleSheetsHelper(credentialFile, spreadSheetID);
                var ggsParams = new GoogleSheetParameters
                {
                    SheetName = "Sheet1",
                    FirstRowIsHeaders = true,
                    RangeRowStart = 1,
                    RangeColumnStart = 1,
                    RangeColumnEnd = 6,
                    RangeRowEnd = 10000
                };

                DataTable dt = GGSExtension.ToDataTable(ggs.GetDataFromSheet(ggsParams));

                dt.Columns.Add("TempDate", typeof(DateTime));

                foreach (DataRow dr in dt.Rows)
                {
                    if (!DateTime.TryParseExact(
                        Convert.ToString(dr["StatisticDate"]),
                        new[] { "dd/MM/yyyy", "d/MM/yyyy", "d/M/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" },
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime parsedDate))
                    {
                        parsedDate = new DateTime(1900, 1, 1);
                    }

                    dr["TempDate"] = parsedDate;
                }

                using (SqlConnection conn = new SqlConnection(
                    data.ASPDecrypt(ASPData.configDatabase.CONNECTION_STRINGS)))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            new SqlCommand(
                                "TRUNCATE TABLE dbo.ASPHRChartIndex", conn, tran
                            ).ExecuteNonQuery();

                            using (SqlBulkCopy bulk = new SqlBulkCopy(
                                conn, SqlBulkCopyOptions.TableLock, tran))
                            {
                                bulk.DestinationTableName = "dbo.ASPHRChartIndex";
                                bulk.BatchSize = 5000;
                                bulk.BulkCopyTimeout = 0;

                                bulk.ColumnMappings.Add("TempDate", "StatisticDate");
                                bulk.ColumnMappings.Add("DeptID", "DeptID");
                                bulk.ColumnMappings.Add("FactoryID", "FactoryID");
                                bulk.ColumnMappings.Add("IndexOf7S", "IndexOf7S");
                                bulk.ColumnMappings.Add("IndexOfSAI", "IndexOfSAI");
                                bulk.ColumnMappings.Add("IndexOfEII", "IndexOfEII");

                                bulk.WriteToServer(dt);
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SyncQCIndex()
        {
            try
            {
                string credentialFile = "credentials.json";
                string spreadSheetID = "1rribSI6kLrffp0NAsvLUcWpaou5VV0dcFGJGn-YCosA";

                var ggs = new GoogleSheetsHelper(credentialFile, spreadSheetID);
                var ggsParams = new GoogleSheetParameters
                {
                    SheetName = "Sheet1",
                    FirstRowIsHeaders = true,
                    RangeRowStart = 2,
                    RangeColumnStart = 1,
                    RangeColumnEnd = 7,
                    RangeRowEnd = 10000
                };

                DataTable dt = GGSExtension.ToDataTable(ggs.GetDataFromSheet(ggsParams));
                dt.Columns.Add("TempDate", typeof(DateTime));

                foreach (DataRow dr in dt.Rows)
                {
                    if (!DateTime.TryParseExact(
                        Convert.ToString(dr["StatisticDate"]),
                        new[] { "dd/MM/yyyy", "d/MM/yyyy", "d/M/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" },
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime parsedDate))
                    {
                        parsedDate = new DateTime(1900, 1, 1);
                    }

                    dr["TempDate"] = parsedDate;
                }

                using (SqlConnection conn = new SqlConnection(
                    data.ASPDecrypt(ASPData.configDatabase.CONNECTION_STRINGS)))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            new SqlCommand(
                                "TRUNCATE TABLE dbo.ASPDashboardQAASM1", conn, tran
                            ).ExecuteNonQuery();

                            using (SqlBulkCopy bulk = new SqlBulkCopy(
                                conn, SqlBulkCopyOptions.TableLock, tran))
                            {
                                bulk.DestinationTableName = "dbo.ASPDashboardQAASM1";
                                bulk.BatchSize = 5000;
                                bulk.BulkCopyTimeout = 0;

                                bulk.ColumnMappings.Add("TempDate", "StatisticDate");
                                bulk.ColumnMappings.Add("CusComplaintPPM", "CusComplaintPPM");
                                bulk.ColumnMappings.Add("SampleComplaint", "SampleComplaint");
                                bulk.ColumnMappings.Add("CarCloseRate", "CarCloseRate");
                                bulk.ColumnMappings.Add("IQCLossRate", "IQCLossRate");
                                bulk.ColumnMappings.Add("MonthlyPPMOQCLoss", "MonthlyPPMOQCLoss");
                                bulk.ColumnMappings.Add("MonthlyOQCLoss", "MonthlyOQCLoss");

                                bulk.WriteToServer(dt);
                            }

                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private DataTable CheckModulePermission(string username, string moduleName)
        {
            var dic = new Dictionary<string, object>
            {
                { "@username", username },
                { "@moduleName", moduleName }
            };
            string sql = "SELECT TOP 1 Member_ID AS Counter FROM L00PERMISSIONASP WHERE Member_ID = @username AND [Object_ID] = @moduleName" +
                "   UNION SELECT TOP 1 Member_ID AS Counter FROM L00MEMBERASP WHERE Member_ID = @username AND Is_Admin = 1";
            ASPData.SQLHelper hp = new ASPData.SQLHelper();
            DataTable dt = hp.ExecQueryDataAsDataTable(sql, dic);
            return dt;
        }

        private void BtSkillmap_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenSkillMapTab();
        }

        /// <summary>
        /// Mở / focus tab Skill Map (V2). Idempotent theo t.Name = "Skill Map".
        /// Non-admin: mở thẳng Horizontal; Admin: mở form quản trị frmSkillMapV2.
        /// </summary>
        public void OpenSkillMapTab()
        {
            string username = !string.IsNullOrWhiteSpace(this.sManv)
                ? this.sManv
                : ASPProject.SkillMap.SessionMangerSkillMap.Username ?? "";

            var dao = new SkillMapV2DAO();
            bool isAdmin = dao.IsSkillMapAdmin(username);

            string tabName = isAdmin ? "Skill Map" : "Skill Map Horizontal";
            string tabTitle = "Skill Map";

            for (int i = 0; i < tabControl12.Tabs.Count; i++)
            {
                if (tabControl12.Tabs[i].Name == tabName)
                {
                    tabControl12.SelectedTabIndex = i;
                    return;
                }
            }

            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            TabItem t = tabControl12.CreateTab(tabTitle);
            t.Name = tabName;

            if (isAdmin)
            {
                var frmSkill = new frmSkillMapV2();
                frmSkill.TopLevel = false;
                frmSkill.Dock = DockStyle.Fill;
                frmSkill.FormBorderStyle = FormBorderStyle.None;

                t.AttachedControl.Controls.Add(frmSkill);
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;

                frmSkill.Show();
            }
            else
            {
                // Non-admin (WHA, LineSX, KTV): Mở thẳng Ma trận ngang Horizontal sạch sẽ
                var frmH = new frmHorizontalV2(username, isAdmin: false, initialSkillType: null);
                frmH.TopLevel = false;
                frmH.Dock = DockStyle.Fill;
                frmH.FormBorderStyle = FormBorderStyle.None;

                t.AttachedControl.Controls.Add(frmH);
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;

                frmH.Show();
            }

            ld.simpleCloseWait();
        }

        /// <summary>
        /// Mở / focus tab Horizontal (admin): Mode = SkillType từ config (LineSX/KTV/VPSX/…), không popup.
        /// </summary>
        /// <param name="initialSkillType">vd "LineSX", "KTV", "VPSX"; null = type đầu trong config</param>
        public void OpenSkillMapHorizontalTab(string username, string initialSkillType = null)
        {
            const string tabName = "Skill Map Horizontal";
            for (int i = 0; i < tabControl12.Tabs.Count; i++)
            {
                if (tabControl12.Tabs[i].Name != tabName) continue;

                tabControl12.SelectedTabIndex = i;
                foreach (Control c in tabControl12.Tabs[i].AttachedControl.Controls)
                {
                    if (c is frmHorizontalV2 h)
                    {
                        if (!string.IsNullOrWhiteSpace(initialSkillType))
                            h.SetMode(initialSkillType);
                        return;
                    }
                }
                return;
            }

            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            TabItem t = tabControl12.CreateTab("Skill Map Horizontal");
            t.Name = tabName;

            // Admin horizontal tab: isAdmin=true, Mode load từ ASPSkillMapTypeConfig
            var frmH = new frmHorizontalV2(username, isAdmin: true, initialSkillType: initialSkillType);
            frmH.TopLevel = false;
            frmH.Dock = DockStyle.Fill;
            frmH.FormBorderStyle = FormBorderStyle.None;

            t.AttachedControl.Controls.Add(frmH);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;

            frmH.Show();
            ld.simpleCloseWait();
        }

        private void BtPlanning_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Planning";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Planning";
            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Planning";

            frmPlanning frminsMachine = new frmPlanning();
            //frminsMachine.userName = sManv;
            frminsMachine.TopLevel = false;
            frminsMachine.Dock = DockStyle.Fill;

            t.AttachedControl.Controls.Add(frminsMachine);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;

            frminsMachine.Show();
            ld.simpleCloseWait();
        }

        private void BtMachineIns_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Yêu cầu setup máy";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Machine installation require";
            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Machine installation require";

            frmPLineMachineInsRequire frminsMachine = new frmPLineMachineInsRequire();
            frminsMachine.userName = sManv;
            frminsMachine.TopLevel = false;
            frminsMachine.Dock = DockStyle.Fill;

            t.AttachedControl.Controls.Add(frminsMachine);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;

            frminsMachine.Show();
            ld.simpleCloseWait();
        }
        private void BtBinQCApproval_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Xác nhận QC";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "QC Approval";
            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "QC Approval";

            frmBinLineQCApproval qcApproval = new frmBinLineQCApproval();

            qcApproval.TopLevel = false;
            qcApproval.Dock = DockStyle.Fill;

            t.AttachedControl.Controls.Add(qcApproval);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;

            qcApproval.Show();
            ld.simpleCloseWait();
        }

        private void BtEmpCapacity_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng năng lực nhân viên";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Employee capacity table";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Employee capacity table";

            frmPSRptEmployeeCapacity empCapacity = new frmPSRptEmployeeCapacity();

            empCapacity.TopLevel = false;
            empCapacity.Dock = DockStyle.Fill;
            empCapacity.userName = sManv;
            t.AttachedControl.Controls.Add(empCapacity);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            empCapacity.Show();
            ld.simpleCloseWait();
        }

        private void BtIsoEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Danh sách ISO Email";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "ISO email list";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "ISO email list";

            frmISOAuditEmail isoEmail = new frmISOAuditEmail();

            isoEmail.deDongTab = new frmISOAuditEmail._deDongTab(vDOngTab);
            isoEmail.frm = this;
            isoEmail.iNgonNgu = iNgonNgu;
            isoEmail.TopLevel = false;
            isoEmail.Dock = DockStyle.Fill;
            isoEmail.userName = this.sManv;

            t.AttachedControl.Controls.Add(isoEmail);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            isoEmail.Show();
            ld.simpleCloseWait();
        }

        private void BtScanBarcodeBin_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Import Scan barcode bin";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Import Scan barcode bin";
            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Import Scan barcode bin";

            frmScanBarcodeBin frmScanBCB = new frmScanBarcodeBin();

            frmScanBCB.TopLevel = false;
            frmScanBCB.Dock = DockStyle.Fill;
            frmScanBCB.userName = sManv;
            t.AttachedControl.Controls.Add(frmScanBCB);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            frmScanBCB.Show();
            ld.simpleCloseWait();
        }

        private void BtQRCodeMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "QR Code Master";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "QR Code Master";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "QR Code Master";

            frmProdQRCodeMaster prodQr = new frmProdQRCodeMaster();

            prodQr.TopLevel = false;
            prodQr.Dock = DockStyle.Fill;
            prodQr.userName = sManv;
            prodQr.frm = this;
            t.AttachedControl.Controls.Add(prodQr);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            prodQr.Show();

            ld.simpleCloseWait();
        }
        private void BtProdScanQRCodeLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Scan QR Code";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Scan QR Code";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Scan QR Code";

            frmQCScanQRCodeLog prodQr = new frmQCScanQRCodeLog();

            prodQr.TopLevel = false;
            prodQr.Dock = DockStyle.Fill;
            prodQr.userName = sManv;
            prodQr.frm = this;
            t.AttachedControl.Controls.Add(prodQr);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            prodQr.Show();

            ld.simpleCloseWait();
        }

        private void BtScanQRCodeJig_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Scan QR Code Jig Test";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Scan QR Code Jig Test";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Scan QR Code Jig Test";

            frmProdQRCodeJigTestLog prodQr = new frmProdQRCodeJigTestLog();

            prodQr.TopLevel = false;
            prodQr.Dock = DockStyle.Fill;
            prodQr.userName = sManv;
            prodQr.frm = this;
            t.AttachedControl.Controls.Add(prodQr);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            prodQr.Show();

            ld.simpleCloseWait();
        }

        private void BtTracebility_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Traceability";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Traceability";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Traceability";

            frmProdQRCodeTraceability prodQr = new frmProdQRCodeTraceability();

            prodQr.TopLevel = false;
            prodQr.Dock = DockStyle.Fill;
            prodQr.userName = sManv;
            prodQr.frm = this;
            t.AttachedControl.Controls.Add(prodQr);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            prodQr.Show();

            ld.simpleCloseWait();
        }

        private void InitializePrintLabelControl()
        {
            DevExpress.XtraBars.BarButtonItem btPrintLabelControl = new DevExpress.XtraBars.BarButtonItem();

            btPrintLabelControl.Caption = (iNgonNgu == 0) ? "Kiểm soát in tem" : "Print Label Control";
            btPrintLabelControl.Id = 999;
            btPrintLabelControl.Name = "btPrintLabelControl";

            // Icon lớn (thường dùng trên Ribbon)
            btPrintLabelControl.ImageOptions.LargeImage = Properties.Resources.barcode;

            // Hoặc icon nhỏ
            btPrintLabelControl.ImageOptions.Image = Properties.Resources.barcode;

            btPrintLabelControl.ItemClick += BtPrintLabelControl_ItemClick;

            if (this.ribbon != null)
            {
                this.ribbon.Items.Add(btPrintLabelControl);
            }

            if (this.ribEMES_MRP_ASM1 != null)
            {
                int index = -1;
                

                if (index >= 0)
                {
                    this.ribEMES_MRP_ASM1.ItemLinks.Insert(index + 1, btPrintLabelControl);
                }
                else
                {
                    this.ribEMES_MRP_ASM1.ItemLinks.Add(btPrintLabelControl);
                }
            }
        }

        private void BtPrintLabelControl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption(iNgonNgu == 0 ? "Đang tải dữ liệu - Vui Lòng Chờ" : "Loading data - Please wait...");

            string sTieuDe = iNgonNgu == 0 ? "Kiểm soát in tem" : "Print Label Control";

            foreach (TabItem item in tabControl12.Tabs)
            {
                if (item.Name == "PrintLabelControl")
                {
                    tabControl12.SelectedTab = item;
                    ld.simpleCloseWait();
                    return;
                }
            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "PrintLabelControl";

            frmPrintLabelControl printCtrl = new frmPrintLabelControl();

            printCtrl.TopLevel = false;
            printCtrl.Dock = DockStyle.Fill;
            printCtrl.userName = sManv;
            printCtrl.iNgonNgu = iNgonNgu;
            printCtrl.frm = this;
            t.AttachedControl.Controls.Add(printCtrl);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            printCtrl.Show();

            ld.simpleCloseWait();
        }

        private void Ribbon_Paint(object sender, PaintEventArgs e)
        {
            Image image = Resources.asplogo128x128;
            Rectangle RibbonBounds = ribbon.Bounds;
            Rectangle rect = new Rectangle(RibbonBounds.Right - 35, RibbonBounds.Y + 49, image.Width, image.Height);
            rect.Offset(RibbonBounds.X - image.Width, 10);
            e.Graphics.DrawImage(image, rect);
        }

        #region ASPEvent
        private void BtMachineChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Theo dõi hiệu suất máy";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Monitoring machine effectiveness";

            }

            TabItem t = tabControl12.CreateTab(sTieuDe);
            t.Name = "Chart";

            MachineChart machineChart = new MachineChart();

            machineChart.TopLevel = false;
            machineChart.Dock = DockStyle.Fill;
            t.AttachedControl.Controls.Add(machineChart);
            tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            machineChart.Show();
            ld.simpleCloseWait();
        }
        private void BtExportReportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Trích xuất báo cáo";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Export Report";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "BaoCao";
                ASPReportToExcel.ASPReports aspRpt = new ASPReportToExcel.ASPReports();
                aspRpt.Username = sManv;

                aspRpt.Show();
                aspRpt.TopLevel = false;
                aspRpt.Dock = DockStyle.Fill;
                t.AttachedControl.Controls.Add(aspRpt);
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }
        private void BtProdReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Báo cáo sản xuất";
            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Production Report";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "BaoCao";
                ASPReportToExcel.ASPReports aspRpt = new ASPReportToExcel.ASPReports();
                aspRpt.Username = sManv;

                aspRpt.Show();
                aspRpt.TopLevel = false;
                aspRpt.Dock = DockStyle.Fill;
                t.AttachedControl.Controls.Add(aspRpt);
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }

        private void BtExDimQC_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Kiểm tra chất lượng";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "IQC Checking";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "IQC Checking";
                frmExternalIQC frmExIQC = new frmExternalIQC();
                frmExIQC.deDongTab = new frmExternalIQC._deDongTab(vDOngTab);
                frmExIQC.userName = sManv;
                frmExIQC.frm = this;
                frmExIQC.iNgonNgu = iNgonNgu;
                frmExIQC.TopLevel = false;
                frmExIQC.Dock = DockStyle.Fill;
                t.AttachedControl.Controls.Add(frmExIQC);
                frmExIQC.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }

        private void BtHRAbsence_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Quản lý phép";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "HR Absence Management";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "HR Absence Management";
                frmHRAbsenceDocMng frmHR = new frmHRAbsenceDocMng();
                frmHR.deDongTab = new frmHRAbsenceDocMng._deDongTab(vDOngTab);
                frmHR.userName = sManv;
                frmHR.frm = this;
                frmHR.iNgonNgu = iNgonNgu;
                frmHR.TopLevel = false;
                frmHR.Dock = DockStyle.Fill;
                t.AttachedControl.Controls.Add(frmHR);
                frmHR.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }

        private void BtNFCReader_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "NFC QR Reader";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "NFC QR Reader";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "\"NFC QR Reader\";";
                //frmNFCQRReader frmNfc = new frmNFCQRReader();
                //frmNfc.deDongTab = new frmNFCQRReader._deDongTab(vDOngTab);
                //frmNfc.userName = sManv;
                //frmNfc.frm = this;
                //frmNfc.iNgonNgu = iNgonNgu;
                //frmNfc.TopLevel = false;
                //frmNfc.Dock = DockStyle.Fill;
                //t.AttachedControl.Controls.Add(frmNfc);
                //frmNfc.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }

        private void BtDefectMode_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Defective mode";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Defective mode";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Defective mode";
                frmDefectiveMode defectFrm = new frmDefectiveMode();
                defectFrm.deDongTab = new frmDefectiveMode._deDongTab(vDOngTab);
                defectFrm.frm = this;
                defectFrm.iNgonNgu = iNgonNgu;
                defectFrm.TopLevel = false;
                defectFrm.Dock = DockStyle.Fill;
                defectFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(defectFrm);
                defectFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtMachine_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Machine list";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Machine list";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Machine list";
                frmMachine mcFrm = new frmMachine();
                mcFrm.deDongTab = new frmMachine._deDongTab(vDOngTab);
                mcFrm.frm = this;
                mcFrm.iNgonNgu = iNgonNgu;
                mcFrm.TopLevel = false;
                mcFrm.Dock = DockStyle.Fill;
                mcFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(mcFrm);
                mcFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtLosstime_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Losstime";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Losstime";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Losstime";
                frmLosstime losstimeFrm = new frmLosstime();
                losstimeFrm.deDongTab = new frmLosstime._deDongTab(vDOngTab);
                losstimeFrm.frm = this;
                losstimeFrm.iNgonNgu = iNgonNgu;
                losstimeFrm.TopLevel = false;
                losstimeFrm.Dock = DockStyle.Fill;
                losstimeFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(losstimeFrm);
                losstimeFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }


            ld.simpleCloseWait();
        }

        private void BtProdStatisticASM2_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Thống kê sản xuất NM2";
            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Production statistic (NM2)";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Production statistic (NM2)";
                ASPProject.LineProdStatisticASM2.frmProdStatisticView prodStaFrm = new ASPProject.LineProdStatisticASM2.frmProdStatisticView();
                prodStaFrm.deDongTab = new ASPProject.LineProdStatisticASM2.frmProdStatisticView._deDongTab(vDOngTab);
                prodStaFrm.frm = this;
                prodStaFrm.iNgonNgu = iNgonNgu;
                prodStaFrm.TopLevel = false;
                prodStaFrm.Dock = DockStyle.Fill;
                prodStaFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(prodStaFrm);
                prodStaFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtProdStatistic_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Thống kê sản xuất";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Production statistic";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Production statistic";
                frmProdStatisticView prodStaFrm = new frmProdStatisticView();
                prodStaFrm.deDongTab = new frmProdStatisticView._deDongTab(vDOngTab);
                prodStaFrm.frm = this;
                prodStaFrm.iNgonNgu = iNgonNgu;
                prodStaFrm.TopLevel = false;
                prodStaFrm.Dock = DockStyle.Fill;
                prodStaFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(prodStaFrm);
                prodStaFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }


            ld.simpleCloseWait();
        }

        private void BtTimekeeping_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Ký hiệu công";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Timekeeping";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Timekeeping";
                frmTimekeeping timekeepFrm = new frmTimekeeping();
                timekeepFrm.deDongTab = new frmTimekeeping._deDongTab(vDOngTab);
                timekeepFrm.frm = this;
                timekeepFrm.iNgonNgu = iNgonNgu;
                timekeepFrm.TopLevel = false;
                timekeepFrm.Dock = DockStyle.Fill;
                timekeepFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(timekeepFrm);
                timekeepFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }


            ld.simpleCloseWait();
        }

        private void BtAttendance_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Điểm danh";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Attendance";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Attendance";
                frmAttendanceEmployee attendanceFrm = new frmAttendanceEmployee();
                attendanceFrm.deDongTab = new frmAttendanceEmployee._deDongTab(vDOngTab);
                attendanceFrm.frm = this;
                attendanceFrm.iNgonNgu = iNgonNgu;
                attendanceFrm.TopLevel = false;
                attendanceFrm.Dock = DockStyle.Fill;
                attendanceFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(attendanceFrm);
                attendanceFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtAttendanceTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng điểm danh";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Attendance table";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Attendance table";
                frmAttendanceTableByMonth attendanceFrm = new frmAttendanceTableByMonth();
                attendanceFrm.deDongTab = new frmAttendanceTableByMonth._deDongTab(vDOngTab);
                attendanceFrm.frm = this;
                attendanceFrm.iNgonNgu = iNgonNgu;
                attendanceFrm.TopLevel = false;
                attendanceFrm.Dock = DockStyle.Fill;
                attendanceFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(attendanceFrm);
                attendanceFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtProdPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng kế hoạch sản xuất";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Production planning table";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Production planning table";
                frmProductionPlanTable frm = new frmProductionPlanTable();

                frm.deDongTab = new frmProductionPlanTable._deDongTab(vDOngTab);
                frm.frm = this;
                frm.iNgonNgu = iNgonNgu;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtScanQRData_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Dữ liệu Scan QR";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Scan QR Data";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Scan QR Data";
                frmProdScanQRCodeHeader frm = new frmProdScanQRCodeHeader();

                frm.deDongTab = new frmProdScanQRCodeHeader._deDongTab(vDOngTab);
                frm.frm = this;
                frm.iNgonNgu = iNgonNgu;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtHRAbsenceByStaff_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Phiếu quản lý phép";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "HR Absence Management Document";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "HR Absence Management Document";
                frmHRAbsenceDocByStaff frmHRStaff = new frmHRAbsenceDocByStaff();
                frmHRStaff.deDongTab = new frmHRAbsenceDocByStaff._deDongTab(vDOngTab);
                frmHRStaff.userName = sManv;
                frmHRStaff.frm = this;
                frmHRStaff.iNgonNgu = iNgonNgu;
                frmHRStaff.TopLevel = false;
                frmHRStaff.Dock = DockStyle.Fill;
                t.AttachedControl.Controls.Add(frmHRStaff);
                frmHRStaff.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }

        private void BtWOSOP_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Lệnh sản xuất - Công đoạn";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Work order - Stage";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Work order - Stage";
                frmWOSOP frm = new frmWOSOP();
                frm.deDongTab = new frmWOSOP._deDongTab(vDOngTab);
                frm.frm = this;
                frm.iNgonNgu = iNgonNgu;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }


            ld.simpleCloseWait();
        }

        private void BtQCChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "QC Output Chart";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "QC Output Chart";

            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "QC Output Chart";
                //frmIQCStatisticChart frm = new frmIQCStatisticChart();
                //frm.deDongTab = new frmIQCStatisticChart._deDongTab(vDOngTab);
                //frm.frm = this;
                //frm.iNgonNgu = iNgonNgu;
                //frm.TopLevel = false;
                //frm.Dock = DockStyle.Fill;
                //frm.username = this.sManv;
                //t.AttachedControl.Controls.Add(frm);
                ExternalIQC.Form1 frm = new ExternalIQC.Form1();
                frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }

        private void BtInternalAudit_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Internal Audit";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Internal Audit";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Internal Audit";

                frmInternalAudit frm = new frmInternalAudit();
                frm.deDongTab = new frmInternalAudit._deDongTab(vDOngTab);
                frm.frm = this;
                frm.iNgonNgu = iNgonNgu;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();

                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtSumReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng chi tiết giờ nhân viên theo công đoạn";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Detail employee by state";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "EmpByStage";
                frmPSDetailEmpByStage Frm = new frmPSDetailEmpByStage();
                Frm.deDongTab = new frmPSDetailEmpByStage._deDongTab(vDOngTab);
                Frm.frm = this;
                Frm.iNgonNgu = iNgonNgu;
                Frm.TopLevel = false;
                Frm.Dock = DockStyle.Fill;
                Frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(Frm);
                Frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtRptMachineStage_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng chi tiết giờ máy theo công đoạn";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Detail machine by state";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "MachineByStage";
                frmPSDetailMachineByStage Frm = new frmPSDetailMachineByStage();
                Frm.deDongTab = new frmPSDetailMachineByStage._deDongTab(vDOngTab);
                Frm.frm = this;
                Frm.iNgonNgu = iNgonNgu;
                Frm.TopLevel = false;
                Frm.Dock = DockStyle.Fill;
                Frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(Frm);
                Frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtRptMatStage_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng chi tiết vật tư theo công đoạn";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Detail material by state";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "MaterialByStage";
                frmPSDetailMaterialByStage Frm = new frmPSDetailMaterialByStage();
                Frm.deDongTab = new frmPSDetailMaterialByStage._deDongTab(vDOngTab);
                Frm.frm = this;
                Frm.iNgonNgu = iNgonNgu;
                Frm.TopLevel = false;
                Frm.Dock = DockStyle.Fill;
                Frm.userName = this.sManv;
                t.AttachedControl.Controls.Add(Frm);
                Frm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtProdORChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Productivity Chart";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Productivity Chart";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Productivity Chart";
                frmProductivityChart frmChart = new frmProductivityChart();
                frmChart.username = this.sManv;
                //frmOutChart.deDongTab = new frmExLosstime._deDongTab(vDOngTab);
                //frmOutChart.frm = this;
                //frmOutChart.iNgonNgu = iNgonNgu;
                frmChart.TopLevel = false;
                frmChart.Dock = DockStyle.Fill;
                //frmOutChart.userName = this.sManv;
                t.AttachedControl.Controls.Add(frmChart);
                frmChart.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtAbsenceDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Đơn xin nghỉ phép";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Absence Document";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Absence Document";
                frmHRAbsenceEmpDocEdit frmHrDoc = new frmHRAbsenceEmpDocEdit();
                frmHrDoc.userName = this.sManv;
                frmHrDoc.deDongTab = new frmHRAbsenceEmpDocEdit._deDongTab(vDOngTab);
                frmHrDoc.frm = this;
                frmHrDoc.iNgonNgu = iNgonNgu;
                frmHrDoc.TopLevel = false;
                frmHrDoc.Dock = DockStyle.Fill;

                t.AttachedControl.Controls.Add(frmHrDoc);
                frmHrDoc.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtRptMold_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng kê chi tiết Mold";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Detail Mold Report";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Detail Mold Report";
                frmPSRptDetailMold frmMold = new frmPSRptDetailMold();
                frmMold.userName = this.sManv;
                frmMold.deDongTab = new frmPSRptDetailMold._deDongTab(vDOngTab);
                frmMold.frm = this;
                frmMold.iNgonNgu = iNgonNgu;
                frmMold.TopLevel = false;
                frmMold.Dock = DockStyle.Fill;

                t.AttachedControl.Controls.Add(frmMold);
                frmMold.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtDetailTableJig_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Bảng kê chi tiết Jig";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Detail Jig Report";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Detail Jig Report";
                frmPSRptDetailJig frmJig = new frmPSRptDetailJig();
                frmJig.userName = this.sManv;
                frmJig.deDongTab = new frmPSRptDetailJig._deDongTab(vDOngTab);
                frmJig.frm = this;
                frmJig.iNgonNgu = iNgonNgu;
                frmJig.TopLevel = false;
                frmJig.Dock = DockStyle.Fill;

                t.AttachedControl.Controls.Add(frmJig);
                frmJig.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtSBLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Line - Scan thùng thành phẩm";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Line - Scan barcode bin";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Line - Scan barcode bin";
                frmScanBarcodeBinLine frmSBL = new frmScanBarcodeBinLine();
                frmSBL.userName = this.sManv;
                frmSBL.deDongTab = new frmScanBarcodeBinLine._deDongTab(vDOngTab);
                frmSBL.frm = this;
                frmSBL.iNgonNgu = iNgonNgu;
                frmSBL.TopLevel = false;
                frmSBL.Dock = DockStyle.Fill;

                t.AttachedControl.Controls.Add(frmSBL);
                frmSBL.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();

        }

        private void BtSumDataQRCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "Tổng hợp dữ liệu QR Code";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Tổng hợp dữ liệu QR Code";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Tổng hợp dữ liệu QR Code";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "";
                frmProdQRCodeSummary frmSBL = new frmProdQRCodeSummary();
                frmSBL.userName = this.sManv;
                frmSBL.deDongTab = new frmProdQRCodeSummary._deDongTab(vDOngTab);
                frmSBL.frm = this;
                frmSBL.iNgonNgu = iNgonNgu;
                frmSBL.TopLevel = false;
                frmSBL.Dock = DockStyle.Fill;

                t.AttachedControl.Controls.Add(frmSBL);
                frmSBL.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtAbsenceFollow_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Phiếu theo dõi phép";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Follow absence document";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Follow absence document";
                frmHRAbsenceDocByStaff frmHRDoc = new frmHRAbsenceDocByStaff();
                frmHRDoc.userName = this.sManv;
                frmHRDoc.deDongTab = new frmHRAbsenceDocByStaff._deDongTab(vDOngTab);
                frmHRDoc.frm = this;
                frmHRDoc.iNgonNgu = iNgonNgu;
                frmHRDoc.TopLevel = false;
                frmHRDoc.Dock = DockStyle.Fill;

                t.AttachedControl.Controls.Add(frmHRDoc);
                frmHRDoc.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtProdExLosstime_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Thống kê Losstime ngoài";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "External losstime statistic";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "ExLosstime";
                frmExLosstime exLossFrm = new frmExLosstime();
                exLossFrm.deDongTab = new frmExLosstime._deDongTab(vDOngTab);
                exLossFrm.frm = this;
                exLossFrm.iNgonNgu = iNgonNgu;
                exLossFrm.TopLevel = false;
                exLossFrm.Dock = DockStyle.Fill;
                exLossFrm.userName = this.sManv;
                t.AttachedControl.Controls.Add(exLossFrm);
                exLossFrm.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        private void BtOutputChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Output Chart";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Output Chart";
            }

            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "Output Chart";
                //InventoryDashboardForm frmOutChart = new InventoryDashboardForm();
                frmProdStatisticChart frmOutChart = new frmProdStatisticChart();
                frmOutChart.username = this.sManv;
                //frmOutChart.deDongTab = new frmExLosstime._deDongTab(vDOngTab);
                //frmOutChart.frm = this;
                //frmOutChart.iNgonNgu = iNgonNgu;
                frmOutChart.TopLevel = false;
                frmOutChart.Dock = DockStyle.Fill;
                //frmOutChart.username = this.sManv;
                t.AttachedControl.Controls.Add(frmOutChart);
                frmOutChart.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }

            ld.simpleCloseWait();
        }

        #endregion

        private void tabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {

            TabItem t = tabControl12.SelectedTab;
            tabControl12.Tabs.Remove(t);
        }

        private bool checkOpenTabs(string name)
        {
            for (int i = 0; i < tabControl12.Tabs.Count; i++)
            {
                //if (tabControl.TabPages[i].Text == name)
                if (tabControl12.Tabs[i].Text == name)
                {
                    tabControl12.SelectedTabIndex = i;
                    return true;
                }
            }
            return false;
        }
        public string sManv, sTennv, sBoPhan;
        public void GetModulePermission()
        {
            DataTable dtModulePermission = new DataTable();
            dtModulePermission = CheckModulePermission(sManv, "EMES_HRM");
            if (dtModulePermission.Rows.Count > 0)
            {
                ribEMES_HRM.Visible = true;
                ribbon.SelectedPage = ribEMES_HRM;
                dtModulePermission = CheckModulePermission(sManv, "EMES_HRM_VP");
                if (dtModulePermission.Rows.Count > 0)
                {
                    ribPageEMES_HRM_VP.Visible = true;
                }
                dtModulePermission = CheckModulePermission(sManv, "EMES_HRM_CN");
                if (dtModulePermission.Rows.Count > 0)
                {
                    ribPageEMES_HRM_CN.Visible = true;
                }
            }

            dtModulePermission = CheckModulePermission(sManv, "EMES_MRP");
            if (dtModulePermission.Rows.Count > 0)
            {
                ribEMES_SX.Visible = true;
                ribEMES_SX_INTEM.Visible = true;
                ribEMES_MRP_ASM2.Visible = false;

                ribbon.SelectedPage = ribEMES_SX;
            }

            dtModulePermission = CheckModulePermission(sManv, "EMES_MRP_2");
            if (dtModulePermission.Rows.Count > 0)
            {
                ribEMES_SX.Visible = true;
                ribEMES_SX_INTEM.Visible = false;
                ribEMES_MRP_ASM1.Visible = false;

                ribbon.SelectedPage = ribEMES_SX;
            }

            dtModulePermission = CheckModulePermission(sManv, "EMES_REPORT");
            if (dtModulePermission.Rows.Count > 0)
            {
                ribEMES_REPORT.Visible = true;
            }

            dtModulePermission = CheckModulePermission(sManv, "EMES_LIST");
            if (dtModulePermission.Rows.Count > 0)
            {
                ribEMES_List.Visible = true;
            }

            dtModulePermission = CheckModulePermission(sManv, "EMES_QA");
            if (dtModulePermission.Rows.Count > 0)
            {
                ribEMES_QA.Visible = true;
                ribbon.SelectedPage = ribEMES_QA;
            }
        }
        public void loadStatus()
        {
            barStaticNhanVien.Caption = sTennv;
            barMayChu.Caption = "192.168.102"; //AppC.AppSettings.Settings["Server"].Value;
            barDatabase.Caption = "ASP";  //AppC.AppSettings.Settings["Database"].Value;
        }
        int iNgonNgu;
        private void frmMain_Load(object sender, EventArgs e)
        {
            ribEMES_List.Visible = false;
            ribEMES_HRM.Visible = false;
            ribEMES_SX.Visible = false;
            ribEMES_QA.Visible = false; 
            ribEMES_REPORT.Visible = false;
            ribEMES_SX_INTEM.Visible = false;
            ribPageEMES_HRM_VP.Visible = false;
            ribPageEMES_HRM_CN.Visible = false;
            //ribEMES_SYSTEM.Visible = false;

            GetModulePermission();

            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = ribbon.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                barSubItem1.ItemLinks.Add(item);
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Blue";
            }

            if (!File.Exists("NgonNgu.config"))
            {
                File.Create("NgonNgu.config");
                FileInfo fi = new FileInfo("NgonNgu.config");
                fi.Attributes = FileAttributes.Hidden | FileAttributes.System;
            }
            if (!File.Exists("NgonNgu.config"))
            {
                //NgonNguVA.AppSettings.Settings.Add("NgonNgu.config", "0");
                //NgonNguVA.Save();
            }

            iNgonNgu = 0; // int.Parse(NgonNguVA.AppSettings.Settings["NgonNgu"].Value);
            if (iNgonNgu == 1)
            {
                btAnh.Enabled = false;
                loadEN();
            }
            if (iNgonNgu == 0)
            {
                btNgonNguViet.Enabled = false;
                loadVN();
            }


            loadStatus();
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");
            ld.simpleCloseWait();
            timer1.Enabled = true;
            //notifyIcon();
            InitializePrintLabelControl();
        }
        void OnPaintStyleClick(object sender, ItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            barThoiGian.Caption = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLogin lg = new frmLogin();
            lg.ShowDialog();
        }

        #region ngonngu
        public void loadEN()
        {

        }
        public void loadVN()
        {


        }
        #endregion
        public void loadLuuNgonNgu(int kieuNgonNgu)
        {
            //if (!File.Exists("NgonNgu.config"))
            //{
            //    File.Create("NgonNgu.config");
            //    FileInfo fi = new FileInfo("NgonNgu.config");
            //    fi.Attributes = FileAttributes.Hidden | FileAttributes.System;
            //}
            //if (!File.Exists("NgonNgu.config"))
            //{
            //    NgonNguVA.AppSettings.Settings.Add("NgonNgu.config", kieuNgonNgu.ToString());
            //    NgonNguVA.Save();
            //}
            //else
            //{
            //    NgonNguVA.AppSettings.Settings["NgonNgu.config"].Value = kieuNgonNgu.ToString();

            //    NgonNguVA.Save();
            //}
        }

        public delegate void Translate();
        public Translate LoadVI;
        public Translate LoadEN;

        bool bKTraMoTab = false;

        public void loadLaiTenTab()
        {
            foreach (TabItem item in tabControl12.Tabs)

            {
                if (item.Name == "ThongKe")
                {
                    if (iNgonNgu == 0)
                        item.Text = "Báo cáo tồn khi tổng hợp";
                    else
                        item.Text = "Report total";
                }
                if (item.Name == "DoanhThu")
                {
                    if (iNgonNgu == 0)
                        item.Text = "Thống kê doanh thu";
                    else
                        item.Text = "Revenue report";
                }
                if (item.Name == "PhanQuyen")
                {
                    if (iNgonNgu == 0)
                        item.Text = "Phân quyền";
                    else
                        item.Text = "Decentralization";
                }
                if (item.Name == "MatHang")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btMatHang.ToString();
                    else
                        item.Text = resEngLand.btMatHang.ToString();
                }
                if (item.Name == "NhomHang")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btNhomHang.ToString();
                    else
                        item.Text = resEngLand.btNhomHang.ToString();
                }
                if (item.Name == "DonViTinh")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btDonViTinh.ToString();
                    else
                        item.Text = resEngLand.btDonViTinh.ToString();
                }
                if (item.Name == "NhaCungCap")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btNhaCungCap.ToString();
                    else
                        item.Text = resEngLand.btNhaCungCap.ToString();
                }
                if (item.Name == "KhuVuc")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btKhuVuc.ToString();
                    else
                        item.Text = resEngLand.btKhuVuc.ToString();
                }
                if (item.Name == "Kho")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btKho.ToString();
                    else
                        item.Text = resEngLand.btKho.ToString();
                }
                if (item.Name == "NhanVien")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btNhanVien.ToString();
                    else
                        item.Text = resEngLand.btNhanVien.ToString();
                }
                if (item.Name == "KhachHang")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btKhachHang.ToString();
                    else
                        item.Text = resEngLand.btKhachHang.ToString();
                }
                if (item.Name == "CNCC")
                {
                    if (iNgonNgu == 0)
                    {
                        item.Text = "Công nợ nhà cung cấp";

                    }
                    else
                    {
                        item.Text = "Debt Custommer";

                    }
                }
                if (item.Name == "CNKH")
                {
                    if (iNgonNgu == 0)
                    {
                        item.Text = "Công nợ khách hàng";

                    }
                    else
                    {
                        item.Text = "Custommer's Debt";

                    }
                }
                if (item.Name == "BoPhan")
                {
                    if (iNgonNgu == 0)
                        item.Text = resVietNam.btBoPhan.ToString();
                    else
                        item.Text = resEngLand.btBoPhan.ToString();
                }
                if (item.Name == "HoaDonXuat")
                {
                    if (iNgonNgu == 0)
                    {
                        item.Text = resVietNam.btHoaDonXuat.ToString();

                    }
                    else
                    {
                        item.Text = resEngLand.btHoaDonXuat.ToString();

                    }
                }
                if (item.Name == "TKTongHop")
                {
                    if (iNgonNgu == 0)
                    {
                        item.Text = resVietNam.btTongHop.ToString();

                    }
                    else
                    {
                        item.Text = resEngLand.btTongHop.ToString();

                    }
                }
                if (item.Name == "Thue")
                {
                    if (iNgonNgu == 0)
                    {
                        item.Text = "Thuế";

                    }
                    else
                    {
                        item.Text = "Tax";

                    }
                }

                if (item.Name == "HoaDonNhap")
                {
                    if (iNgonNgu == 0)
                    {
                        item.Text = resVietNam.btHoaDonNhap.ToString();
                    }
                    else
                    {
                        item.Text = resEngLand.btHoaDonNhap.ToString();

                    }
                }

                if (item.Name == "TKMatHang")
                {
                    if (iNgonNgu == 0)
                    {
                        item.Text = "Thống kê" + resVietNam.btMatHang.ToString();
                    }
                    else
                    {
                        item.Text = "Static " + resEngLand.btMatHang.ToString();

                    }

                }
                //item.
            }
            //tabControl1.Text = sTieuDe;
        }
        string sTieuDe;

        private void vDOngTab()
        {
            foreach (TabItem item in tabControl12.Tabs)
            {
                if (item.IsSelected)
                {
                    tabControl12.Tabs.Remove(item);
                    return;
                }
            }
        }

        private void btDangXuat_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Hide();
            frm.ShowDialog();
        }

        private void btNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            bKTraMoTab = true;
            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = resVietNam.btNhanVien.ToString();

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = resEngLand.btNhanVien.ToString();

            }
            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "NhanVien";
                frmEmployee dt = new frmEmployee();
                dt.deDongTab = new frmEmployee._deDongTab(vDOngTab);
                dt.frm = this;
                dt.iNgonNgu = iNgonNgu;
                dt.TopLevel = false;
                dt.Dock = DockStyle.Fill;
                dt.userName = this.sManv;
                t.AttachedControl.Controls.Add(dt);
                dt.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }


        private void barSubItem1_Popup(object sender, EventArgs e)
        {
            //foreach (BarItemLink link in barSubItem1.ItemLinks)
            //    ((BarCheckItem)link.Item).Checked = link.Item.Caption == defaultLookAndFeel1.LookAndFeel.ActiveSkinName;
        }

        private void btPlanningMasterList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ld.CreateWaitDialog();
            ld.SetWaitDialogCaption("Đang tải dữ liệu - Vui Lòng Chờ");

            bKTraMoTab = true;
            sTieuDe = "";
            if (iNgonNgu == 0)
            {
                sTieuDe = "Planning master list";

            }
            if (iNgonNgu == 1)
            {
                sTieuDe = "Planning master list";

            }
            if (!checkOpenTabs(sTieuDe))
            {
                TabItem t = tabControl12.CreateTab(sTieuDe);
                t.Name = "NhanVien";
                frmPlanningMasterList dt = new frmPlanningMasterList();
                dt.deDongTab = new frmPlanningMasterList._deDongTab(vDOngTab);
                dt.frm = this;
                dt.iNgonNgu = iNgonNgu;
                dt.TopLevel = false;
                dt.Dock = DockStyle.Fill;
                dt.userName = this.sManv;
                t.AttachedControl.Controls.Add(dt);
                dt.Show();
                tabControl12.SelectedTabIndex = tabControl12.Tabs.Count - 1;
            }
            ld.simpleCloseWait();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btKetThuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (iNgonNgu == 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn thoát hay không ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                if (XtraMessageBox.Show("Do you want to exit ? ", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();

        }
    }
}