using ASPData.ASPDAO;
using ASPData.ASPDTO;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPProject.InternalAudit
{
    public partial class frmInternalAudit : DevExpress.XtraEditors.XtraForm
    {
        public frmMain frm;
        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        public int iNgonNgu;
        public string userName;
        ASPDTO aspDto = new ASPDTO();
        ASPDAO aspDao = new ASPDAO();
        private string lockStatus;
        private string lockPlan;
        private string lockReport;
        private string lockSummary;
        private string lockCar;
        DataTable dtLockAudit = new DataTable();

        public frmInternalAudit()
        {
            InitializeComponent();

            this.Load += FrmInternalAudit_Load;

            btProgram.Click += BtViewProgram_Click;
            btPlan.Click += BtPlan_Click;
            btReport.Click += BtReport_Click;
            btSummary.Click += BtSummary_Click;
            btCar.Click += BtCar_Click;
            btLockAudit.Click += BtLockAudit_Click;
            btLockPlan.Click += BtLockPlan_Click;
            btLockReport.Click += BtLockReport_Click;
            btLockSummary.Click += BtLockSummary_Click;
            btLockCar.Click += BtLockCar_Click;
        }

        private void FrmInternalAudit_Load(object sender, EventArgs e)
        {
            aspDto.FuncID = "PlanAuditControl";
            aspDto.UserName = userName;

            dtLockAudit = aspDao.GetLockAdminList(aspDto);

            if (dtLockAudit.Rows.Count > 0)
                btLockPlan.Visible = true;
            else
                btLockPlan.Visible = false;

            lockPlan = (string)aspDao.GetLockFunc(aspDto);

            if (lockPlan == "Close")
                btLockPlan.Text = "OPEN PLAN";
            else
                btLockPlan.Text = "LOCK PLAN";

            aspDto.FuncID = "ReportAuditControl";
            aspDto.UserName = userName;

            dtLockAudit = aspDao.GetLockAdminList(aspDto);

            if (dtLockAudit.Rows.Count > 0)
                btLockReport.Visible = true;
            else
                btLockReport.Visible = false;

            lockReport = (string)aspDao.GetLockFunc(aspDto);

            if (lockReport == "Close")
                btLockReport.Text = "OPEN REPORT";
            else
                btLockReport.Text = "LOCK REPORT";

            aspDto.FuncID = "SummaryAuditControl";
            aspDto.UserName = userName;

            dtLockAudit = aspDao.GetLockAdminList(aspDto);

            if (dtLockAudit.Rows.Count > 0)
                btLockSummary.Visible = true;
            else
                btLockSummary.Visible = false;

            lockSummary = (string)aspDao.GetLockFunc(aspDto);

            if (lockSummary == "Close")
                btLockSummary.Text = "OPEN SUMMARY";
            else
                btLockSummary.Text = "LOCK SUMMARY";

            aspDto.FuncID = "CarAuditControl";
            aspDto.UserName = userName;

            dtLockAudit = aspDao.GetLockAdminList(aspDto);

            if (dtLockAudit.Rows.Count > 0)
                btLockCar.Visible = true;
            else
                btLockCar.Visible = false;

            lockCar = (string)aspDao.GetLockFunc(aspDto);

            if (lockCar == "Close")
                btLockCar.Text = "OPEN CAR";
            else
                btLockCar.Text = "LOCK CAR";

            aspDto.FuncID = "InternalAuditControl";
            aspDto.UserName = userName;

            dtLockAudit = aspDao.GetLockAdminList(aspDto);

            if (dtLockAudit.Rows.Count > 0)
                btLockAudit.Visible = true;
            else
                btLockAudit.Visible = false;

            lockStatus = (string)aspDao.GetLockFunc(aspDto);

            if (lockStatus == "Close")
                btLockAudit.Text = "OPEN ALL";
            else
                btLockAudit.Text = "LOCK ALL";
        }

        private void BtLockPlan_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "PlanAuditControl";

                switch (lockPlan)
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
                aspDao.LockFunc(aspDto);

                lockPlan = (string)aspDto.FuncValue;

                if (lockPlan == "Close")
                    btLockPlan.Text = "OPEN PLAN";
                else
                    btLockPlan.Text = "LOCK PLAN";

                XtraMessageBox.Show("Đã cập nhật thành công.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtLockReport_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "ReportAuditControl";

                switch (lockReport)
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
                aspDao.LockFunc(aspDto);

                lockReport = (string)aspDto.FuncValue;

                if (lockReport == "Close")
                    btLockReport.Text = "OPEN REPORT";
                else
                    btLockReport.Text = "LOCK REPORT";

                XtraMessageBox.Show("Đã cập nhật thành công.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtLockSummary_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "SummaryAuditControl";

                switch (lockSummary)
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
                aspDao.LockFunc(aspDto);

                lockSummary = (string)aspDto.FuncValue;

                if (lockSummary == "Close")
                    btLockSummary.Text = "OPEN SUMMARY";
                else
                    btLockSummary.Text = "LOCK SUMMARY";

                XtraMessageBox.Show("Đã cập nhật thành công.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtLockCar_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "CarAuditControl";

                switch (lockCar)
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
                aspDao.LockFunc(aspDto);

                lockCar = (string)aspDto.FuncValue;

                if (lockCar == "Close")
                    btLockCar.Text = "OPEN CAR";
                else
                    btLockCar.Text = "LOCK CAR";

                XtraMessageBox.Show("Đã cập nhật thành công.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtLockAudit_Click(object sender, EventArgs e)
        {
            try
            {
                aspDto.FuncID = "InternalAuditControl";

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
                aspDao.LockFunc(aspDto);

                lockStatus = (string)aspDto.FuncValue;

                if (lockStatus == "Close")
                    btLockAudit.Text = "OPEN ALL";
                else
                    btLockAudit.Text = "LOCK ALL";

                XtraMessageBox.Show("Đã cập nhật thành công.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtCar_Click(object sender, EventArgs e)
        {
            if (lockStatus == "Close" || lockCar == "Close")
            {
                XtraMessageBox.Show("Dữ liệu đã khoá !");
                return;
            }

            frmInternalAuditReport frmDetail = new frmInternalAuditReport();
            frmDetail.editType = 1;
            frmDetail.ShowDialog();
        }

        private void BtSummary_Click(object sender, EventArgs e)
        {
            if (lockStatus == "Close" || lockSummary == "Close")
            {
                XtraMessageBox.Show("Dữ liệu đã khoá !");
                return;
            }

            frmInternalAuditDetail frmDetail = new frmInternalAuditDetail();
            frmDetail.editType = 0;
            frmDetail.userName = this.userName;
            frmDetail.ShowDialog();
        }

        private void BtReport_Click(object sender, EventArgs e)
        {
            if (lockStatus == "Close" || lockReport == "Close")
            {
                XtraMessageBox.Show("Dữ liệu đã khoá !");
                return;
            }

            frmInternalAuditReport frmReport = new frmInternalAuditReport();
            frmReport.editType = 0;
            frmReport.userName = this.userName;
            frmReport.ShowDialog();
        }

        private void BtPlan_Click(object sender, EventArgs e)
        {
            if (lockStatus == "Close" || lockPlan == "Close")
            {
                XtraMessageBox.Show("Dữ liệu đã khoá !");
                return;
            }

            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "InternalAudit\\02 Internal audit plan\\Internal Audit Plan ASM1 & ASM2 - Airspeed VN Company - 2023.pdf");
        }

        private void BtViewProgram_Click(object sender, EventArgs e)
        {
            if (lockStatus == "Close")
            {
                XtraMessageBox.Show("Dữ liệu đã khoá !");
                return;
            } 
            
            System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "InternalAudit\\01 Internal audit program\\Internal Audit Program and Management Review Plan for 2024.pdf");
        }
    }
}
