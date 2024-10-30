using ASPData.ASPDTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class ASPDAO
    {
        private readonly SQLHelper _sqlHelper = new SQLHelper();
        public DataTable ASPLogin(ASPDTO.ASPDTO aspDto)
        {
            DataTable dtLogin = new DataTable();

            var dicParams = new Dictionary<string, object>
                {
                    { "@Username", aspDto.UserName }
                };

            var parameters = new DynamicParameters(dicParams);

            dtLogin = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPLogin", parameters);

            return dtLogin;
        }

        public bool CheckPermission(string funcID, string username)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@FuncID", funcID },
                { "@Username", username }
            };

            bool permit = Convert.ToBoolean(_sqlHelper.ExecProcedureSacalar("sp_ASPCheckPermission", dicParams));

            return permit;
        }

        public DataTable GetPermission(string username, string objectId)
        {
            DataTable res = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Username", username },
                { "@ObjectID", objectId }
            };

            res = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetPermissionByUser", dicParams);

            return res;
        }

        public DataTable GetReportByUser(string username)
        {
            DataTable res = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Username", username },
            };

            res = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetReportByUser", dicParams);

            return res;
        }

        public DataTable GetFactoryList()
        {
            DataTable dtFactoryList = new DataTable();

            dtFactoryList = _sqlHelper.ExecQueryDataAsDataTable("SELECT Ma_NhaMay, Ten_NhaMay FROM L81NHAMAYASP");

            return dtFactoryList;
        }

        public DataTable GetLineList()
        {
            DataTable dtLineList = new DataTable();

            dtLineList = _sqlHelper.ExecQueryDataAsDataTable("SELECT Ma_Day_Chuyen, Ten_Day_Chuyen FROM L81DMDAYCHUYENASP");

            return dtLineList;
        }

        public DataTable GetDepartmentList()
        {
            DataTable dt = new DataTable();

            dt = _sqlHelper.ExecQueryDataAsDataTable("SELECT DeptID, DeptName FROM ASPDepartment");

            return dt;
        }

        public void LockFunc(ASPDTO.ASPDTO aspDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FuncID", aspDto.FuncID },
                { "@FuncValue", aspDto.FuncValue }
            };

            _sqlHelper.ExecProcedureNonData("sp_ASPLockFunc", dicParams);
        }

        public DataTable GetLockAdminList(ASPDTO.ASPDTO aspDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FuncID", aspDto.FuncID },
                { "@Username", aspDto.UserName }
            };

            DataTable funcValue = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetLockAdminList", dicParams);

            return funcValue;
        }

        public object GetLockFunc(ASPDTO.ASPDTO aspDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FuncID", aspDto.FuncID }
            };

            object funcValue = _sqlHelper.ExecProcedureSacalar("sp_ASPGetLockFunc", dicParams);

            return funcValue;
        }
    }
}
