using ASPData.ASPDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class WOSOPDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetWOSOP(WOSOPDTO woDto)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@LineID", woDto.LineID },
                { "@Username", woDto.Username },
                { "@FromDate", woDto.FromDate },
                { "@ToDate", woDto.ToDate },
                { "@CreatedBy", woDto.CreatedBy },
                { "@CreatedDate", woDto.CreatedDate },
                { "@LastModifiedBy", woDto.LastModifiedBy },
                { "@LastModifiedDate", woDto.LastModifiedDate }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetWOSOP", dicParams);

            return result;
        }

        public DataTable GetWOSOPDetail(WOSOPDTO woDto)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@ProductID", woDto.ProductID }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetWOSOPDetail", dicParams);

            return result;
        }

        public void InsertWOSOPStage(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", woDto.HeaderID },
                { "@StageID", woDto.StageID },
                { "@StageName", woDto.StageName },
                { "@CreatedBy", woDto.CreatedBy },
                { "@CreatedDate", woDto.CreatedDate },
                { "@LastModifiedBy", woDto.LastModifiedBy },
                { "@LastModifiedDate", woDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertWOSOPStage", dicParams);
        }

        public void UpdateWOSOPStage(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", woDto.HeaderID },
                { "@StageID", woDto.StageID },
                { "@StageName", woDto.StageName },
                { "@CreatedBy", woDto.CreatedBy },
                { "@CreatedDate", woDto.CreatedDate },
                { "@LastModifiedBy", woDto.LastModifiedBy },
                { "@LastModifiedDate", woDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateWOSOPStage", dicParams);
        }

        public void UpdateWOSOPStageQuantity(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpHeaderID", woDto.EmpHeaderID },
                { "@StageID", woDto.StageID },
                { "@EmpID", woDto.EmpID },
                { "@MaterialID", woDto.MaterialID },
                { "@Quantity", woDto.Quantity },
                { "@ReworkQuantity", woDto.ReworkQuantity },
                { "@SortingQuantity", woDto.SortingQuantity },
                { "@MachineID", woDto.MachineID },
                { "@CheckInDt", woDto.CheckInDt },
                { "@CheckOutDt", woDto.CheckOutDt },
                { "@CheckInDtOld", woDto.CheckInDtOld }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateWOSOPStageQuantity", dicParams);
        }

        public void DeleteWOSOPStage(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", woDto.HeaderID },
                { "@StageID", woDto.StageID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteWOSOPStage", dicParams);
        }

        public void AddRemoveSOPStageByEmp(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpHeaderID", woDto.EmpHeaderID },
                { "@EmpID", woDto.EmpID },
                { "@StageID", woDto.StageID },
                { "@MaterialID", woDto.MaterialID },
                { "@Assigned", woDto.Assigned }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPAddRemoveSOPStageByEmp", dicParams);
        }

        public void AddRemoveSOPStageByMachine(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@MachineHeaderID", woDto.MachineHeaderID },
                { "@MachineID", woDto.MachineID },
                { "@StageID", woDto.StageID },
                { "@MaterialID", woDto.MaterialID },
                { "@Assigned", woDto.Assigned }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPAddRemoveSOPStageByMachine", dicParams);
        }

        public void AddRemoveSOPStageByDefect(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", woDto.HeaderID },
                { "@DFHeaderID", woDto.DFHeaderID },
                { "@StageID", woDto.StageID },
                { "@Assigned", woDto.Assigned }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPAddRemoveSOPStageByDefect", dicParams);
        }

        public void ImportExcelSOP(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@ProductID", woDto.ProductID },
                { "@StageID", woDto.StageID },
                { "@StageName", woDto.StageName },
                { "@MaterialID", woDto.MaterialID },
                { "@MachineID", woDto.MachineID },
                { "@CycleTime", woDto.CycleTime },
                { "@UsageBom", woDto.UsageBom },
                { "@ManPower", woDto.ManPower },
                { "@CreatedBy", woDto.CreatedBy },
                { "@CreatedDate", woDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPImportExcelSOP", dicParams);
        }

        public void LoadDataDetailSOPAll(WOSOPDTO woDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpHeaderID", woDto.EmpHeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPLoadDataDetailSOPAll", dicParams);
        }

        public DataTable LoadEmpByStageReport(WOSOPDTO woDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Ngay_Ct1", woDto.FromDate },
                { "@Ngay_Ct2", woDto.ToDate },
                { "@Ma_Day_Chuyen", woDto.LineID },
                { "@Username", woDto.Username },
                { "@ViewType", woDto.ViewType }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPEmpWorkTimeByStageV2", dicParams);

            return dt;
        }

        public DataTable LoadMachineByStageReport(WOSOPDTO woDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Ngay_Ct1", woDto.FromDate },
                { "@Ngay_Ct2", woDto.ToDate },
                { "@Ma_Day_Chuyen", woDto.LineID },
                { "@Username", woDto.Username },
                { "@ViewType", woDto.ViewType }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPMachineTimeByStage", dicParams);

            return dt;
        }

        public DataTable LoadMaterialByStageReport(string sqlProc, WOSOPDTO woDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Ngay_Ct1", woDto.FromDate },
                { "@Ngay_Ct2", woDto.ToDate },
                { "@Ma_Day_Chuyen", woDto.LineID },
                { "@Username", woDto.Username }
            };

            
            dt = _sqlhelper.ExecProcedureDataAsDataTable(sqlProc, dicParams);

            return dt;
        }

        public DataTable GetMachineList(string MachineID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@MachineID", MachineID }
            };

            dt = _sqlhelper.ExecQueryDataAsDataTable("SELECT MachineID, MachineName FROM ASPMachine WHERE (@MachineID = '' OR MachineID = @MachineID)", dicParams);

            return dt;
        }

        public DataTable GetEmployeeCapacity(WOSOPDTO woDto, string sqlProc)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", woDto.FromDate },
                { "@ToDate", woDto.ToDate },
                { "@Username", woDto.Username }
            };
          
           dt = _sqlhelper.ExecProcedureDataAsDataTable(sqlProc, dicParams);

           return dt;  
        }
    }
}
