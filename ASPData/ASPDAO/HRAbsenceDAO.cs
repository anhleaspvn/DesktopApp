using ASPData.ASPDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class HRAbsenceDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public void InsertHRAbsence(HRAbsenceDTO hrDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Timestamp", hrDto.TimeStamp },
                { "@EmpID", hrDto.EmpID },
                { "@EmpName", hrDto.EmpName },
                { "@EmpPosition", hrDto.EmpPosition },
                { "@TimeOff", hrDto.TimeOff },
                { "@NumDateOff", hrDto.NumDateOff },
                { "@TypeOfAbsence", hrDto.TypeOfAbsence },
                { "@ReasonOfAbsence", hrDto.ReasonOfAbsence },
                { "@FactoryID", hrDto.FactoryID },
                { "@CreatedBy", hrDto.CreatedBy },
                { "@CreatedDate", hrDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertHRAbsence", dicParams);
        }

        public void InsertLinkQTimekeep(HRAbsenceDTO hrDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Stt", hrDto.Stt },
                { "@InsertDate", hrDto.InsertDate },
                { "@EmpID", hrDto.EmpID },
                { "@UpdateType", hrDto.UpdateType },
                { "@TimekeepID", hrDto.TimekeepID },
                { "@FromDate", hrDto.FromDate },
                { "@ToDate", hrDto.ToDate },
                { "@FactoryID", hrDto.FactoryID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertLinkQTimekeep", dicParams);
        }

        public DataTable CheckHRAbsence(HRAbsenceDTO hrDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpID", hrDto.EmpID },
                { "@TimeStamp", hrDto.TimeStamp }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPCheckHRAbsence", dicParams);

            return dt;
        }

        public DataTable GetHRSupEmpEmail(string username)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Username", username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPHRGetSupEmpEmail", dicParams);

            return dt;
        }

        public void UpdateHRAbsence(HRAbsenceDTO hrDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@TimeStamp", hrDto.TimeStamp },
                { "@AHDStatus", hrDto.AHDStatus },
                { "@HRStatus", hrDto.HRStatus },
                { "@DLDStatus", hrDto.DLDStatus },
                { "@AHDBy", hrDto.AHDBy },
                { "@AHDDate", hrDto.AHDDate },
                { "@HRBy", hrDto.HRBy },
                { "@HRDate", hrDto.HRDate },
                { "@DLDBy", hrDto.DLDBy },
                { "@DLDDate", hrDto.DLDDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateHRAbsence", dicParams);
        }

        public void InsertHRAbsenceEmp(HRAbsenceDTO hrDto)
        {
            DataTable dt = new DataTable();
 //           @EmpID VARCHAR(35),
	//@NumDateOff MONEY,
 //   @TypeOfAbsence NVARCHAR(150),
	//@ReasonOfAbsence NVARCHAR(MAX),
	//@CreatedBy VARCHAR(35),
	//@CreatedDate DATETIME

            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpID", hrDto.EmpID },
                { "@NumDateOff", hrDto.NumDateOff },
                { "@TimeOff", hrDto.TimeOff },
                { "@TypeOfAbsence", hrDto.TypeOfAbsence },
                { "@ReasonOfAbsence", hrDto.ReasonOfAbsence },
                { "@CreatedBy", hrDto.CreatedBy },
                { "@CreatedDate", hrDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertHRAbsenceDocForEmp", dicParams);
        }

        public DataTable GetHRAbsence(HRAbsenceDTO hrDto)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", hrDto.FromDate },
                { "@ToDate", hrDto.ToDate },
                { "@AHDStatus", hrDto.AHDStatus },
                { "@Username", hrDto.Username },
                { "@TypeEmp", hrDto.TypeEmp }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetHRAbsenceDepartmentV2", dicParams);

            return result;
        }

        public DataTable GetViewHRAbsenceStaff(HRAbsenceDTO hrDto)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", hrDto.FromDate },
                { "@ToDate", hrDto.ToDate },
                { "@EmpID", hrDto.EmpID },
                { "@Username", hrDto.Username }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPViewHRAbsenceStaff", dicParams);

            return result;
        }

        public DataTable GetHREmployeeList()
        {
            DataTable result = new DataTable();
            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPHRGetEmployeeList");

            return result;
        }

        public DataTable GetHREmployeeListV2(string username)
        {
            DataTable result = new DataTable();

          
            var dicParams = new Dictionary<string, object>()
            { 
                { "@Username", username }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPHRGetEmployeeListV2", dicParams);

            return result;
        }

        public DataTable HRCheckPermissionLeave(string EmpID)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpID", EmpID }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPHRCheckPermissionLeave", dicParams);

            return result;
        }

        public DataTable HRAbsenceGetMailEmp(string EmpID)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpID", EmpID }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPHRAbsenceGetMailEmp", dicParams);

            return result;
        }

        public string HRGetNewStt()
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Ma_DvCs", "A01" },
                { "@Module", "CO" },
                { "@Save", true }
            };

            string Stt = (string)_sqlhelper.ExecProcedureSacalar("Sp_GetNewStt", dicParams);

            return Stt;
        }

        public void UpdateCancelHRAbsence(HRAbsenceDTO hrDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@TimeStamp", hrDto.TimeStamp }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateCancelHRAbsence", dicParams);
        }

        public void EditHRAbsence(HRAbsenceDTO hrDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@TimeStamp", hrDto.TimeStamp },
                { "@TimeOff", hrDto.TimeOff },
                {"@NumDateOff", hrDto.TimeOff }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPEditHRAbsence", dicParams);
        }

    }
}
