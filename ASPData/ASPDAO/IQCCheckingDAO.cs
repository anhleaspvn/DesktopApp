using ASPData.ASPDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class IQCCheckingDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetCheckStateList(string IQCCheckID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@IQCCheckID", IQCCheckID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetCheckStateList", dicParams);

            return dt;
        }

        public DataTable GetIQCCheckingContentList(string IQCCheckingContent)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@IQCCheckingContent", IQCCheckingContent }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPIQCCheckingContentList", dicParams);

            return dt;
        }

        public DataTable GetAllIQCChecking(string Username, DateTime FromDate, DateTime ToDate, string ProdStatus)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Username",  Username},
                { "@FromDate", FromDate },
                { "@ToDate", ToDate },
                { "@ProdStatus", ProdStatus }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllIQCChecking", dicParams);

            return result;
        }

        public DataSet GetAllDetailIQCChecking(long HeaderID)
        {
            DataSet result = new DataSet();
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            result = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPGetAllDetailIQCChecking", dicParams);

            return result;
        }
        public void DeleteIQCChecking(long HeaderID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteProductionStatistic", dicParams);
        }

        public void DeleteDetailIQCCheckContent(IQCCheckListDTO iqcListDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcListDto.HeaderID },
                { "@IQCCheckID", iqcListDto.IQCCheckID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteDetailIQCCheckContent", dicParams);
        }

        public void DeleteDetailIQCActualCheck(IQCCheckListDTO iqcListDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@AutoID", iqcListDto.AutoID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteDetailIQCActualCheck", dicParams);
        }

        public void InsertIQCCheckingHeader(IQCCheckingDTO iqcCheckingDTO)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcCheckingDTO.HeaderID },
                { "@FactoryID", iqcCheckingDTO.FactoryID },
                { "@DocDate", iqcCheckingDTO.DocDate },
                { "@LineID", iqcCheckingDTO.LineID },
                { "@QCID",  iqcCheckingDTO.QCID },
                { "@ProductID", iqcCheckingDTO.ProductID },
                { "@WODocNo", iqcCheckingDTO.WODocNo },
                { "@ProdReqQuantity", iqcCheckingDTO.ProdReqQuantity },
                { "@ProdStatus", iqcCheckingDTO.ProdStatus },
                { "@CustomerID", iqcCheckingDTO.CustomerID },
                { "@CheckState", iqcCheckingDTO.CheckState },
                { "@StateOfChecking", iqcCheckingDTO.StageOfChecking },
                { "@CreatedBy", iqcCheckingDTO.CreatedBy },
                { "@CreatedDate", iqcCheckingDTO.CreatedDate }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPInsertIQCCheckingHeader", dicParams);
        }

        public void UpdateIQCCheckingHeader(IQCCheckingDTO iqcCheckingDTO)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcCheckingDTO.HeaderID },
                { "@FactoryID", iqcCheckingDTO.FactoryID },
                { "@DocDate", iqcCheckingDTO.DocDate },
                { "@LineID", iqcCheckingDTO.LineID },
                { "@QCID",  iqcCheckingDTO.QCID },
                { "@ProductID", iqcCheckingDTO.ProductID },
                { "@WODocNo", iqcCheckingDTO.WODocNo },
                { "@ProdReqQuantity", iqcCheckingDTO.ProdReqQuantity },
                { "@ProdStatus", iqcCheckingDTO.ProdStatus },
                { "@CustomerID", iqcCheckingDTO.CustomerID },
                { "@CheckState", iqcCheckingDTO.CheckState },
                { "@StateOfChecking", iqcCheckingDTO.StageOfChecking },
                { "@LastModifiedBy", iqcCheckingDTO.LastModifiedBy },
                { "@LastModifiedDate", iqcCheckingDTO.LastModifiedDate }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPUpdateIQCCheckingHeader", dicParams);
        }

        public void DeleteIQCCheckingHeader(IQCCheckingDTO iqcCheckingDTO)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcCheckingDTO.HeaderID }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPDeleteIQCCheckingHeader", dicParams);
        }

        public void InsertIQCCheckContent(IQCCheckListDTO iqcCheckingDTO)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcCheckingDTO.HeaderID },
                { "@IQCCheckID",  iqcCheckingDTO.IQCCheckID},
                { "@IQCCheckName", iqcCheckingDTO.IQCCheckName },
                 { "@IQCCheckCont", iqcCheckingDTO.IQCCheckCont },
                { "@IQCTemplateQuantity", iqcCheckingDTO.IQCTemplateQuantity },
                { "@IQCEvalueResult", iqcCheckingDTO.IQCEvalueResult },
                { "@IQCPeriodTime", iqcCheckingDTO.IQCPeriodTime },
                { "@CreatedBy", iqcCheckingDTO.CreatedBy },
                { "@CreatedDate", iqcCheckingDTO.CreatedDate }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPInsertIQCCheckContent", dicParams);
        }

        public void UpdateIQCCheckContent(long AutoID, long HeaderID, string IQCCheckID, double IQCCheckQuantity, string IQCEvalueResult, string IQCPeriodTime)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@AutoID",  AutoID},
                { "@HeaderID", HeaderID },
                { "@IQCCheckID", IQCCheckID },
                { "@IQCCheckQuantity", IQCCheckQuantity },
                { "@IQCEvalueResult", IQCEvalueResult },
                { "@IQCPeriodTime", IQCPeriodTime }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPUpdateIQCCheckContent", dicParams);
        }

        public void InsertIQCActualCheck(IQCActualCheck iqcActualDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcActualDto.HeaderID },
                { "@IQCCheckID", iqcActualDto.IQCCheckID},
                { "@IQCCheckName", iqcActualDto.IQCCheckName },
                { "@IQCDFID", iqcActualDto.IQCDFID },
                { "@IQCStandardMin", iqcActualDto.IQCStandardMin },
                { "@IQCStandardMax", iqcActualDto.IQCStandardMax },
                { "@IQCEvalueActual", iqcActualDto.IQCEvalueActual },
                { "@IQCEvalueResult", iqcActualDto.IQCEvalueResult },
                { "@IQCEvalueCheckTime", iqcActualDto.IQCEvalueCheckTime },
                { "@IQCCheckingContent", iqcActualDto.IQCCheckingContent },
                { "@IQCDeviceID", iqcActualDto.IQCDeviceID },
                { "@IQCMeasuringToolID", iqcActualDto.IQCMeasuringToolID },
                { "@CreatedBy", iqcActualDto.CreatedBy },
                { "@CreatedDate", iqcActualDto.CreatedDate }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPInsertIQCActualCheck", dicParams);
        }

        public void UpdateIQCActualCheck(IQCActualCheck iqcActualDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcActualDto.HeaderID },
                { "@AutoID", iqcActualDto.AutoID },
                { "@IQCDFID", iqcActualDto.IQCDFID },
                { "@IQCStandardMin", iqcActualDto.IQCStandardMin },
                { "@IQCStandardMax", iqcActualDto.IQCStandardMax },
                { "@IQCEvalueActual", iqcActualDto.IQCEvalueActual },
                { "@IQCCheckingContent", iqcActualDto.IQCCheckingContent },
                { "@IQCEvalueResult", iqcActualDto.IQCEvalueResult },
                { "@IQCEvalueCheckTime", iqcActualDto.IQCEvalueCheckTime },
                { "@IQCDeviceID", iqcActualDto.IQCDeviceID },
                { "@IQCMeasuringToolID", iqcActualDto.IQCMeasuringToolID },
                { "@LastModifiedBy", iqcActualDto.LastModifiedBy },
                { "@LastModifiedDate", iqcActualDto.LastModifiedDate }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPUpdateIQCActualCheck", dicParams);
        }

        public DataTable GetWODocNoListByLine(string LineID, string WODocNo, int EditType)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@LineID", LineID },
                { "@DataID", "A01"},
                { "@WODocNo", WODocNo },
                { "@EditType", EditType }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetWODocNoListByLine", dicParams);

            return result;
        }

        public DataTable GetAllIQCCheckDefect(IQCCheckListDTO iqcDto)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", iqcDto.HeaderID },
                { "@IQCCheckID", iqcDto.IQCCheckID},
                { "@CreatedBy", iqcDto.CreatedBy },
                { "@CreatedDate", iqcDto.CreatedDate }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllIQCCheckDefect", dicParams);

            return result;
        }

        public void UpdateIQCCheckDefect(IQCCheckListDTO iqcDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@AutoID", iqcDto.AutoID },
                { "@DefectQuantity", iqcDto.DefectQuantity},
                { "@LastModifiedBy", iqcDto.LastModifiedBy },
                { "@LastModifiedDate", iqcDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateIQCCheckDefect", dicParams);
        }

        public DataTable GetDailyIQCDPPMChart(int Week, int Month, int Year)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPDailyIQCPPMChart", dicParams);

            return result;
        }

        public DataTable GetDailyIQCPPMByProcessChart(int Week, int Month, int Year)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPDailyIQCProcessPPMChart", dicParams);

            return result;
        }

        public DataTable GetDailyIQCPPMByProductChart(int Week, int Month, int Year)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPDailyIQCProductPPMChart", dicParams);

            return result;
        }

        public DataTable GetDailyIQCDefectPercentChart(int Week, int Month, int Year)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPDailyIQCDefectPercentChart", dicParams);

            return result;
        }
    }
}
