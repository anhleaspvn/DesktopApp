using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.InternalAuditDTO
{
    public class InternalAuditDTO
    {
        public long AutoID { get; set; }
        public string Evidences { get; set; }
        public string Conclusion { get; set; }
        public string AuditorName { get; set; }
        public string DeptID { get; set; }
        public string FactoryID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public bool GLSigned { get; set; }
        public bool HeadSigned { get; set; }
        public bool DeptSigned { get; set; }
        public string GLSignedEmail { get; set; }
        public string HeadSignedEmail { get; set; }
        public string DeptSignedEmail { get; set; }
        public string GLSignedID { get; set; }
        public string HeadSignedID { get; set; }
        public string DeptSignedID { get; set; }
    }
}
