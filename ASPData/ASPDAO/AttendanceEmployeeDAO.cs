using ASPData.ASPDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class AttendanceEmployeeDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();
        public DataTable GetAttendanceEmployee(AttendanceEmployeeDTO.AttendanceEmployeeDTO attEmpDto, string username)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@AttendanceDate", attEmpDto.AttendanceDate.Date },
                { "@LineID", attEmpDto.LineID },
                { "@Username",  username}
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAttendanceEmployee", dicParams);

            return dt;
        }

        public void UpdateAttendanceEmployee(AttendanceEmployeeDTO.AttendanceEmployeeDTO attEmpDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@AttendanceDate", attEmpDto.AttendanceDate.Date },
                { "@LineID", attEmpDto.LineID },
                { "@EmpID", attEmpDto.EmpID },
                { "@Timekeeping", attEmpDto.Timekeeping },
                { "@MorVege", attEmpDto.MorVege },
                { "@EveVege", attEmpDto.EveVege },
                { "@LunchTime", attEmpDto.LunchTime },
                { "@DinnerTime", attEmpDto.Dinnertime },
                { "@DateBeginTime", attEmpDto.DateBeginTime },
                { "@DateEndTime", attEmpDto.DateEndTime },
                { "@CreatedBy", attEmpDto.CreatedBy },
                { "@CreatedDate", attEmpDto.CreatedDate },
                { "@LastModifiedBy", attEmpDto.LastModifiedBy },
                { "@LastModifiedDate", attEmpDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateAttendanceEmployeeV3", dicParams);
        }

        public void DeleteAttendanceEmployee(AttendanceEmployeeDTO.AttendanceEmployeeDTO attEmpDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@AttendanceDate", attEmpDto.AttendanceDate.Date },
                { "@LineID", attEmpDto.LineID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteAttendanceEmployee", dicParams);
        }

        public void LockAttendance(ASPDTO.ASPDTO aspDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FuncID", aspDto.FuncID },
                { "@FuncValue", aspDto.FuncValue }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPLockAttendance", dicParams);
        }

        public object GetLockAttendance(ASPDTO.ASPDTO aspDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FuncID", aspDto.FuncID }
            };

            object funcValue = _sqlhelper.ExecProcedureSacalar("sp_ASPGetLockAttendance", dicParams);

            return funcValue;
        }

        public DataTable GetLockAttendanceAdminList(ASPDTO.ASPDTO aspDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FuncID", aspDto.FuncID },
                { "@Username", aspDto.UserName }
            };

            DataTable funcValue = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetLockAttendanceAdminList", dicParams);

            return funcValue;
        }

        public DataSet GetAttendanceSummary(DateTime AttendanceDate, string LineID, string Username, bool IsOverall)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@AttendanceDate", AttendanceDate},
                {"@LineID", LineID },
                {"@Username", Username },
                {"@IsOverall", IsOverall }
            };

            DataSet ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPGetAttendanceSummary", dicParams);

            return ds;
        }

        public DataTable GetAttendanceListByMonth(int Month, int Year, string LineID, string Username)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            DataTable dt = new DataTable();

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAttendanceListByMonth", dicParams);

            return dt;
        }
    }
}
