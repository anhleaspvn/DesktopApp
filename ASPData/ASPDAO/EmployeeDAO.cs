using ASPData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.EmployeeDAO
{
    public class EmployeeDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();
       
        public DataTable GetAllEmployee()
        {
            var dicParams = new Dictionary<string, object>();

            DataTable EmpDt = new DataTable();
            EmpDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllEmployee", dicParams);

            return EmpDt;
        }

        public DataTable GetAllEmployeeByLine(string LineID, DateTime AttendanceDate, string Username)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@LineID", LineID },
                { "@Username",  Username},
                { "@AttendanceDate",  AttendanceDate.Date}
            };

            DataTable EmpDt = new DataTable();
            EmpDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllEmployeeByLineForExLossTime", dicParams);

            return EmpDt;
        }

        public DataTable GetAllEmployeeByLineForExLosstime(string LineID, DateTime AttendanceDate, string Username)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@LineID", LineID },
                { "@AttendanceDate",  AttendanceDate.Date},
                { "@Username",  Username}
            };

            DataTable EmpDt = new DataTable();
            EmpDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetEmployeeListForExLosstime", dicParams);

            return EmpDt;
        }

        public void DeleteEmployee(EmployeeDTO.EmployeeDTO empDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@EmpID", empDto.EmpID}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPDeleteEmployee", dicParams);
        }

        public void InsertEmployee(EmployeeDTO.EmployeeDTO empDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@EmpID", empDto.EmpID},
                { "@EmpName", empDto.EmpName},
                { "@Position", empDto.Position },
                { "@Direct", empDto.Direct },
                { "@LineID", empDto.LineID },
                { "@QuitJob", empDto.QuitJob },
                { "@QuitMaternity", empDto.QuitMaternity },
                { "@HREmpID", empDto.HREmpID },
                { "@IsOfficialEmp", empDto.IsOfficialEmp },
                { "@Description", empDto.Description },
                { "@CreatedBy", empDto.CreatedBy},
                { "@CreatedDate", empDto.CreatedDate}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPInsertEmployee", dicParams);
        }
        public void UpdateEmployee(EmployeeDTO.EmployeeDTO empDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@EmpID", empDto.EmpID},
                { "@EmpName", empDto.EmpName},
                { "@Position", empDto.Position },
                { "@Direct", empDto.Direct },
                { "@LineID", empDto.LineID },
                { "@QuitJob", empDto.QuitJob },
                { "@QuitMaternity", empDto.QuitMaternity },
                { "@HREmpID", empDto.HREmpID },
                { "@IsOfficialEmp", empDto.IsOfficialEmp },
                { "@Description", empDto.Description },
                { "@LastModifiedBy", empDto.LastModifiedBy },
                { "@LastModifiedDate", empDto.LastModifiedDate }
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPUpdateEmployee", dicParams);
        }

        public void UpdateEmployeeLineID(EmployeeDTO.EmployeeDTO empDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@EmpID", empDto.EmpID},
                { "@LineID", empDto.LineID },
                { "@LastModifiedBy", empDto.LastModifiedBy },
                { "@LastModifiedDate", empDto.LastModifiedDate }
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPUpdateEmployeeLineID", dicParams);
        }

        public DataTable GetTimeOff(string TimeType)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>
            {
                { "@TimeType", TimeType }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetTimeOff", dicParams);

            return dt;
        }
    }
}
