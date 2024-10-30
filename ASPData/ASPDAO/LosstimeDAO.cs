using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class LosstimeDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetAllLosstime()
        {
            var dicParams = new Dictionary<string, object>();

            DataTable lossTimeDt = new DataTable();
            lossTimeDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllLosstime", dicParams);

            return lossTimeDt;
        }

        public void DeleteLosstime(LosstimeDTO.LosstimeDTO lossTimeDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@lossTimeID", lossTimeDto.LosstimeID}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPDeleteLosstime", dicParams);
        }

        public void InsertLosstime(LosstimeDTO.LosstimeDTO lossTimeDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@LosstimeID", lossTimeDto.LosstimeID},
                { "@LosstimeName" , lossTimeDto.LosstimeName},
                { "@CreatedBy", lossTimeDto.CreatedBy},
                { "@CreatedDate", lossTimeDto.CreatedDate}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPInsertLosstime", dicParams);
        }
        public void UpdateLosstime(LosstimeDTO.LosstimeDTO lossTimeDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@LosstimeID", lossTimeDto.LosstimeID},
                { "@LosstimeName" , lossTimeDto.LosstimeName},
                { "@LastModifiedBy", lossTimeDto.LastModifiedBy},
                { "@LastModifiedDate", lossTimeDto.LastModifiedDate}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPUpdateLosstime", dicParams);
        }

        public DataTable GetPSExLosstime(LosstimeDTO.LosstimeDTO lossTimeDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@StatisticDate", lossTimeDto.StatisticDate.Date },
                { "@LineID", lossTimeDto.LineID },
                { "@EmpID", lossTimeDto.EmpID },
                { "@Username", lossTimeDto.Username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetPSExLosstime", dicParams);

            return dt;
        }

        public void UpdateExLosstime(LosstimeDTO.LosstimeDTO lossTimeDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@StatisticDate", lossTimeDto.StatisticDate.Date },
                { "@LineID", lossTimeDto.LineID },
                { "@EmpID", lossTimeDto.EmpID },
                { "@LosstimeID", lossTimeDto.LosstimeID },
                { "@LosstimeNum", lossTimeDto.LosstimeNum },
                { "@LosstimeNumTC", lossTimeDto.LosstimeNumTC },
                { "@CreatedBy", lossTimeDto.CreatedBy },
                { "@CreatedDate", lossTimeDto.CreatedDate },
                { "@LastModifiedBy", lossTimeDto.LastModifiedBy },
                { "@LastModifiedDate", lossTimeDto.LastModifiedDate },
                { "@Description", lossTimeDto.Description }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateExLosstime", dicParams);
        }

        public void DeleteExLosstime(LosstimeDTO.LosstimeDTO lossTimeDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@StatisticDate", lossTimeDto.StatisticDate.Date },
                { "@LineID", lossTimeDto.LineID },
                { "@EmpID", lossTimeDto.EmpID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteExLosstime", dicParams);
        }

        public DataTable GetExLosstimeSummary(LosstimeDTO.LosstimeDTO lossTimeDto, string Username, bool IsOverall)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                  { "@StatisticDate", lossTimeDto.StatisticDate.Date },
                { "@LineID", lossTimeDto.LineID },
                { "@Username", Username },
                { "@IsOverall", IsOverall }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetExLosstimeSummary", dicParams);

            return dt;
        }
    }
}
