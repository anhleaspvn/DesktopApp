using System;
using ASPData.InternalAuditDTO;
using ASPData.InternalAuditDAO;

namespace ASPProject.InternalAudit
{
    public partial class frmInternalAuditEdit : DevExpress.XtraEditors.XtraForm
    {
        public long autoID;
        InternalAuditDTO auditDto = new InternalAuditDTO();
        InternalAuditDAO auditDao = new InternalAuditDAO();
        public frmInternalAuditEdit()
        {
            InitializeComponent();

            btCancel.Click += BtCancel_Click;
            btSave.Click += BtSave_Click;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            auditDto.AutoID = autoID;
            auditDto.Evidences = mmEvidences.Text;
            auditDto.Conclusion = mmConclusion.Text;
            auditDto.AuditorName = txtAuditorName.Text;
            auditDto.LastModifiedBy = string.Empty;
            auditDto.LastModifiedDate = DateTime.Now;

            auditDao.UpdateISOAuditByDept(auditDto);

            this.Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
