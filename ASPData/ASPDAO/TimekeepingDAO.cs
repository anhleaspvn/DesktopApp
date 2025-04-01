using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class TimekeepingDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetAllTimekeepingEdit()
        {
            var dicParams = new Dictionary<string, object>();

            DataTable timekeepDt = new DataTable();
            timekeepDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetTimekeepingListEdit", dicParams);

            return timekeepDt;
        }

        public DataTable GetAllTimekeeping()
        {
            var dicParams = new Dictionary<string, object>();

            DataTable timekeepDt = new DataTable();
            timekeepDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetTimekeepingList", dicParams);

            return timekeepDt;
        }

        public DataTable CheckWorkhoursTimekeep(string timekeepID)
        {
            var dicParams = new Dictionary<string, object>() {
                { "@TimekeepID", timekeepID }
            };

            DataTable timekeepDt = new DataTable();
            timekeepDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPCheckWorkhoursTimekeep", dicParams);

            return timekeepDt;
        }

        public void DeleteTimekeeping(TimekeepingDTO.TimekeepingDTO timeKeepDTO)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@TimekeepID", timeKeepDTO.TimekeepID}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPDeleteTimekeeping", dicParams);
        }
        public void InsertTimekeeping(TimekeepingDTO.TimekeepingDTO timeKeepDTO)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@TimekeepID", timeKeepDTO.TimekeepID},
                { "@TimekeepName" , timeKeepDTO.TimekeepName},
                { "@TimekeepHours", timeKeepDTO.TimekeepHours },
                 { "@TimekeepHoursMain",  timeKeepDTO.TimekeepHoursMain},
                { "@TimekeepHoursOver", timeKeepDTO.TimekeepHoursOver },
                { "@DateBeginTime", timeKeepDTO.DateBeginTime },
                { "@DateEndTime", timeKeepDTO.DateEndTime },
                { "@TimeOffByDate", timeKeepDTO.TimeOffByDate },
                { "@TimeOffByDateTC", timeKeepDTO.TimeOffByDateTC },
                { "@CreatedBy", timeKeepDTO.CreatedBy},
                { "@CreatedDate", timeKeepDTO.CreatedDate}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPInsertTimekeepingV2", dicParams);
        }

        public void UpdateTimekeeping(TimekeepingDTO.TimekeepingDTO timeKeepDTO)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@TimekeepID", timeKeepDTO.TimekeepID},
                { "@TimekeepName" , timeKeepDTO.TimekeepName},
                { "@TimekeepHours", timeKeepDTO.TimekeepHours },
                { "@TimekeepHoursMain",  timeKeepDTO.TimekeepHoursMain},
                { "@TimekeepHoursOver", timeKeepDTO.TimekeepHoursOver },
                 { "@DateBeginTime", timeKeepDTO.DateBeginTime },
                { "@DateEndTime", timeKeepDTO.DateEndTime },
                { "@TimeOffByDate", timeKeepDTO.TimeOffByDate },
                { "@TimeOffByDateTC", timeKeepDTO.TimeOffByDateTC },
                { "@LastModifiedBy", timeKeepDTO.LastModifiedBy},
                { "@LastModifiedDate", timeKeepDTO.LastModifiedDate}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPUpdateTimekeepingV2", dicParams);
        }
    }
}
