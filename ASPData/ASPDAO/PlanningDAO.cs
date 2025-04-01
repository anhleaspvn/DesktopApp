using ASPData.PlanningDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class PlanningDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetPlanningMasterListByMonth(PlanningDTO.PlanningDTO planDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate",  planDto.FromDate },
                { "@ToDate", planDto.ToDate }
            };

            DataTable dt = new DataTable();
            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetMonthPlanningList", dicParams);

            return dt;
        }

        public DataTable GetPlanningMasterListByDay(PlanningDTO.PlanningDTO planDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate",  planDto.FromDate },
                { "@ToDate", planDto.ToDate }
            };

            DataTable dt = new DataTable();
            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetDayPlanningList", dicParams);

            return dt;
        }

        public void PlanningImportByMonth(PlanningDTO.PlanningDTO planDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Year", planDto.Year},
                { "@Month", planDto.Month },
                { "@LineID", planDto.LineID },
                { "@FGsPlan", planDto.FGsPlan },
                { "@MPsPlan", planDto.MPsPlan }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPPlanningImportByMonth", dicParams);
        }

        public void PlanningImportByDay(PlanningDTO.PlanningDTO planDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Year", planDto.Year},
                { "@Month", planDto.Month },
                { "@WODocNo", planDto.WODocNo },
                { "@ProductID", planDto.ProductID },
                { "@LineID", planDto.LineID },
                { "@ORDG", planDto.ORDG },
                { "@ORVN", planDto.ORVN },
                { "@D1", planDto.D1 },
                { "@D2", planDto.D2 },
                { "@D3", planDto.D3 },
                { "@D4", planDto.D4 },
                { "@D5", planDto.D5 },
                { "@D6", planDto.D6 },
                { "@D7", planDto.D7 },
                { "@D8", planDto.D8 },
                { "@D9", planDto.D9 },
                { "@D10", planDto.D10 },
                { "@D11", planDto.D11 },
                { "@D12", planDto.D12 },
                { "@D13", planDto.D13 },
                { "@D14", planDto.D14 },
                { "@D15", planDto.D15 },
                { "@D16", planDto.D16 },
                { "@D17", planDto.D17 },
                { "@D18", planDto.D18 },
                { "@D19", planDto.D19 },
                { "@D20", planDto.D20 },
                { "@D21", planDto.D21 },
                { "@D22", planDto.D22 },
                { "@D23", planDto.D23 },
                { "@D24", planDto.D24 },
                { "@D25", planDto.D25 },
                { "@D26", planDto.D26 },
                { "@D27", planDto.D27 },
                { "@D28", planDto.D28 },
                { "@D29", planDto.D29 },
                { "@D30", planDto.D30 },
                { "@D31", planDto.D31 }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPPlanningImportByDay", dicParams);
        }
    }
}
