using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevComponents.DotNetBar;
using System.IO;
using DevExpress.XtraEditors;
using ASPProject.DefectiveMode;
using ASPProject.Losstime;
using ASPProject.LineProdStatistic;
using ASPProject.Timekeeping;
using ASPProject.AttendanceEmployee;
using ASPProject.ExLosstime;
using ASPData.ASPDAO;
using ASPProject.ExternalIQC;
using ASPProject.HRAbsenceDoc;
using ASPMachineMonitor;
using ASPProject.SOPStage;
using ASPProject.InternalAudit;
using ASPProject.Properties;
using DevExpress.XtraBars.Ribbon;
using System.Drawing;
using ASPProject.Machine;

namespace ASPProject
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ASPControl.Loadingggg ld = new ASPControl.Loadingggg();
        private readonly ASPDAO aspDao = new ASPDAO();

        public frmMain()
        {
            InitializeComponent();

            btExportReportExcel.ItemClick += BtExportReportExcel_ItemClick;
            btMachineChart.ItemClick += BtMachineChart_ItemClick;
            btDefectMode.ItemClick += BtDefectMode_ItemClick;
            btLosstime.ItemClick += BtLosstime_ItemClick;
            btProdStatistic.ItemClick += BtProdStatistic_ItemClick;
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

        private void Ribbon_Paint(object sender, PaintEventArgs e)
        {
            Image image = Resources.asplogo128x128;
            Rectangle RibbonBounds = ribbon.Bounds;
            Rectangle rect = new Rectangle(RibbonBounds.Right - 35, RibbonBounds.Y+49, image.Width, image.Height);
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
                ASPReportToExcel.ASPReportExcel aspRpt = new ASPReportToExcel.ASPReportExcel();
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
                ASPReportToExcel.ASPReportExcel aspRpt = new ASPReportToExcel.ASPReportExcel();
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
                frmIQCStatisticChart frm = new frmIQCStatisticChart();
                frm.deDongTab = new frmIQCStatisticChart._deDongTab(vDOngTab);
                frm.frm = this;
                frm.iNgonNgu = iNgonNgu;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.username = this.sManv;
                t.AttachedControl.Controls.Add(frm);
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
                frmProdStatisticChart frmOutChart = new frmProdStatisticChart();
                frmOutChart.username = this.sManv;
                //frmOutChart.deDongTab = new frmExLosstime._deDongTab(vDOngTab);
                //frmOutChart.frm = this;
                //frmOutChart.iNgonNgu = iNgonNgu;
                frmOutChart.TopLevel = false;
                frmOutChart.Dock = DockStyle.Fill;
                //frmOutChart.userName = this.sManv;
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
        public void veditTypeDangNhap()
        {
            bool permit = aspDao.CheckPermission("ListControl", this.sManv);

            if (!permit)
            {
                ribDanhMuc.Visible = false;
                rbMachineTime.Visible = false;
                btExportReportExcel.Visibility = BarItemVisibility.Never; ;
            }

            permit = aspDao.CheckPermission("ProductionReport", this.sManv);

            if (!permit)
            {
                btProdReport.Visibility = BarItemVisibility.Never;
            }

            if (sBoPhan == "MABP00001")
            {
                btNhapHang.Enabled = true;
                btCongNoNCC.Enabled = true;
                btHoaDonNhap.Enabled = true;
                btXuatHang.Enabled = false;
                btHoaDonXuat.Enabled = false;
                btCongNoKH.Enabled = false;
                ribNhanVien.Visible = false;
            }
            if (sBoPhan == "MABP00002")
            {

                btXuatHang.Enabled = true;
                btHoaDonXuat.Enabled = true;
                btCongNoKH.Enabled = true;
                btNhapHang.Enabled = false;
                btCongNoNCC.Enabled = false;
                btHoaDonNhap.Enabled = false;
                ribNhanVien.Visible = false;
            }

            if (sBoPhan == "MABP00004")
            {
                btNhapHang.Enabled = true;
                btCongNoNCC.Enabled = true;
                btHoaDonNhap.Enabled = true;
                btXuatHang.Enabled = true;
                btHoaDonXuat.Enabled = true;
                btCongNoKH.Enabled = true;

                ribNhanVien.Visible = true;
            }
            if (sBoPhan == "MABP00003")
            {
                btNhapHang.Enabled = true;
                btCongNoNCC.Enabled = true;
                btHoaDonNhap.Enabled = true;
                btXuatHang.Enabled = true;
                btHoaDonXuat.Enabled = true;
                btCongNoKH.Enabled = true;
                ribNhanVien.Visible = false;
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
            veditTypeDangNhap();

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