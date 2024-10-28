using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.InternalAuditDAO
{
    public class InternalAuditDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetAllISOAuditByDept(InternalAuditDTO.InternalAuditDTO auditDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@DeptID",  auditDto.DeptID},
                { "@FactoryID",  auditDto.FactoryID}
            };

            DataTable ISODt = new DataTable();
            ISODt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllISOAuditByDept", dicParams);

            return ISODt;
        }

        public DataTable GetAllISOAuditEmail()
        {
            

            DataTable ISODt = new DataTable();
            ISODt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllISOAuditEmail");

            return ISODt;
        }

        public void UpdateISOAuditByDept(InternalAuditDTO.InternalAuditDTO auditDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@AutoID",  auditDto.AutoID},
                { "@Evidences",  auditDto.Evidences},
                { "@Conclusion", auditDto.Conclusion },
                { "@AuditorName", auditDto.AuditorName },
                { "@LastModifiedBy", auditDto.LastModifiedBy },
                { "@LastModifiedDate", auditDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateISOAuditHeader", dicParams);
        }

        public DataSet GetIAReport(InternalAuditDTO.InternalAuditDTO auditDto, string sqlProc)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FactoryID", auditDto.FactoryID },
                { "@DeptID", auditDto.DeptID }
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet(sqlProc, dicParams);

            return ds;
        }

        public void UpdateISOApproval(InternalAuditDTO.InternalAuditDTO auditDto)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FactoryID", auditDto.FactoryID },
                { "@DeptID", auditDto.DeptID },
                { "@GLSigned", auditDto.GLSigned },
                { "@HeadSigned", auditDto.HeadSigned },
                { "@DeptSigned", auditDto.DeptSigned }
            };

            _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPUpdateISOApproval", dicParams);
        }

        public void InsertISOAuditEmail(InternalAuditDTO.InternalAuditDTO auditDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FactoryID", auditDto.FactoryID },
                { "@DeptID", auditDto.DeptID },
                { "@GLSignedID", auditDto.GLSignedID },
                { "@HeadSignedID", auditDto.HeadSignedID },
                { "@DeptSignedID", auditDto.DeptSignedID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertISOAuditEmail", dicParams);
        }

        public void UpdateISOAuditEmail(InternalAuditDTO.InternalAuditDTO auditDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FactoryID", auditDto.FactoryID },
                { "@DeptID", auditDto.DeptID },
                { "@GLSignedID", auditDto.GLSignedID },
                { "@HeadSignedID", auditDto.HeadSignedID },
                { "@DeptSignedID", auditDto.DeptSignedID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateISOAuditEmail", dicParams);
        }

        public void DeleteISOAuditEmail(InternalAuditDTO.InternalAuditDTO auditDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FactoryID", auditDto.FactoryID },
                { "@DeptID", auditDto.DeptID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteISOAuditEmail", dicParams);
        }

        public DataTable GetISOStaff(InternalAuditDTO.InternalAuditDTO auditDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FactoryID", auditDto.FactoryID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPISOGetStaff", dicParams);

            return dt;
        }
    }
}
