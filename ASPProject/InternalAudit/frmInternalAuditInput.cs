using ASPData.InternalAuditDAO;
using ASPData.InternalAuditDTO;
using ASPData.ASPDTO;
using ASPData.ASPDAO;
using ASPData;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Import.Html;
using System.Net.Mail;

namespace ASPProject.InternalAudit
{
    public partial class frmInternalAuditInput : DevExpress.XtraEditors.XtraForm
    {
        #region declare
        public string userName, deptID, factoryID;
        public int iNgonNgu, curIndex;

        InternalAuditDTO auditDto = new InternalAuditDTO();
        InternalAuditDAO auditDao = new InternalAuditDAO();

        ASPDTO aspDto = new ASPDTO();
        ASPDAO aspDao = new ASPDAO();

        BindingSource bdsAudit = new BindingSource();

        private readonly SQLHelper _sqlHelper = new SQLHelper();
        #endregion

        #region constructor
        public frmInternalAuditInput()
        {
            InitializeComponent();

            chkGLSigned.EditValue = false;
            chkHeadSigned.EditValue = false;
            chkDeptSigned.EditValue = false;

            gridAuditInputView.OptionsBehavior.Editable = false;

            this.Load += FrmInternalAuditInput_Load;
            this.gridAuditInput.DoubleClick += GridAuditInput_DoubleClick;

            btSendMail.Click += BtSendMail_Click;
            chkGLSigned.CheckedChanged += ChkGLSigned_CheckedChanged;
            chkHeadSigned.CheckedChanged += ChkHeadSigned_CheckedChanged;
            chkDeptSigned.CheckedChanged += ChkDeptSigned_CheckedChanged;
        }

        private void ChkDeptSigned_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAuditControl = aspDao.CheckPermission("ISOAuditControl", userName);

            if (chkDeptSigned.Checked == false && checkAuditControl == false)
            {
                chkDeptSigned.Checked = true;
                return;
            }

            try
            {
                auditDto.FactoryID = factoryID;
                auditDto.DeptID = deptID;
                auditDto.GLSigned = (bool)chkGLSigned.Checked;
                auditDto.HeadSigned = (bool)chkHeadSigned.Checked;
                auditDto.DeptSigned = (bool)chkDeptSigned.Checked;

                auditDao.UpdateISOApproval(auditDto);

                //XtraMessageBox.Show("Đã cập nhật thành công");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ChkHeadSigned_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAuditControl = aspDao.CheckPermission("ISOAuditControl", userName);

            if (chkHeadSigned.Checked == false && checkAuditControl == false)
            {
                chkHeadSigned.Checked = true;
                return;
            }

            try
            {
                auditDto.FactoryID = factoryID;
                auditDto.DeptID = deptID;
                auditDto.GLSigned = (bool)chkGLSigned.Checked;
                auditDto.HeadSigned = (bool)chkHeadSigned.Checked;
                auditDto.DeptSigned = (bool)chkDeptSigned.Checked;

                auditDao.UpdateISOApproval(auditDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ChkGLSigned_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAuditControl = aspDao.CheckPermission("ISOAuditControl", userName);

            if (chkGLSigned.Checked == false && checkAuditControl == false)
            {
                chkGLSigned.Checked = true;
                return;
            }

            try
            {
                auditDto.FactoryID = factoryID;
                auditDto.DeptID = deptID;
                auditDto.GLSigned = (bool)chkGLSigned.Checked;
                auditDto.HeadSigned = (bool)chkHeadSigned.Checked;
                auditDto.DeptSigned = (bool)chkDeptSigned.Checked;

                auditDao.UpdateISOApproval(auditDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region load
        private void FrmInternalAuditInput_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            auditDto.DeptID = deptID;
            auditDto.FactoryID = factoryID;

            DataTable dtAudit = auditDao.GetAllISOAuditByDept(auditDto);

            bdsAudit.DataSource = dtAudit;
            gridAuditInput.DataSource = bdsAudit;

            chkGLSigned.Checked = Convert.ToBoolean(dtAudit.Rows[0]["GLSigned"]);
            chkHeadSigned.Checked = Convert.ToBoolean(dtAudit.Rows[0]["HeadSigned"]);
            chkDeptSigned.Checked = Convert.ToBoolean(dtAudit.Rows[0]["DeptSigned"]);
        }
        #endregion

        #region event
        private void GridAuditInput_DoubleClick(object sender, EventArgs e)
        {
            bool checkAuditControl = aspDao.CheckPermission("ISOAuditControl", userName);

            if (chkGLSigned.Checked == true && chkHeadSigned.Checked == true && chkDeptSigned.Checked == true && checkAuditControl == false)
            {
                XtraMessageBox.Show("Tài liệu đã được duyệt, không cho phép chỉnh sửa.");
                return;
            }

            DataRow drCurrent = ((DataRowView)bdsAudit.Current).Row;
            frmInternalAuditEdit frmEdit = new frmInternalAuditEdit();

            if (drCurrent != null)
            {
                frmEdit.autoID = (long)Convert.ToDouble(drCurrent["AutoID"]);
            }
            frmEdit.ShowDialog();

            LoadData();
        }

        private void BtSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                string MailMngID = string.Empty;
                DataTable dtEmail = _sqlHelper.ExecQueryDataAsDataTable("SELECT * FROM ASPISOSendMail");

                if (dtEmail.Rows.Count == 0)
                    return;

                DataRow drSendMail = dtEmail.Rows[0];

                string strTitle = "ISO2024";
                string strbody = drSendMail["EmailContent"].ToString();
                string fromEmail = drSendMail["Email"].ToString();
                string password = drSendMail["EmailPassword"].ToString();
                string host = drSendMail["HostMail"].ToString() != string.Empty ? drSendMail["HostMail"].ToString() : "smtp.gmail.com";
                int post = drSendMail["Port"].ToString() != string.Empty ? Convert.ToInt32(drSendMail["Port"]) : 587;
                string CcEmail = drSendMail["EmailCC"].ToString();


                if (dtEmail.Rows.Count > 0)
                {
                    MailMngID = (string)dtEmail.Rows[0]["GLSignedEmail"] + "," + (string)dtEmail.Rows[0]["HeadSignedEmail"] + "," + (string)dtEmail.Rows[0]["DeptSignedEmail"];
                }


                // Lấy email nhận
                string toEmail = MailMngID;

                var smtpClient = new SmtpClient(host, post)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 10000
                };

                var mail = new MailMessage
                {
                    Body = strbody,
                    Subject = strTitle,
                    From = new MailAddress(fromEmail, "Test")
                };

                mail.To.Add(toEmail);
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                smtpClient.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {

            }

            XtraMessageBox.Show("Đã gửi mail thành công!");
        }
        #endregion

    }
}
