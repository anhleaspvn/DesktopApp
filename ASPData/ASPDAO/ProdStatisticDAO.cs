using System;
using System.Collections.Generic;
using System.Data;

namespace ASPData.ASPDAO
{
    public class ProdStatisticDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetAllScanQRHeader(DateTime FromDate, DateTime ToDate, string LineID, string WODocNo, string EmpID)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", FromDate },
                { "@ToDate", ToDate },
                { "@LineID", LineID },
                { "@WODocNo", WODocNo },
                { "@EmpID", EmpID }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetScanQRHeader", dicParams);

            return result;
        }
        public DataTable GetAllProductionStatistic(string Username, DateTime FromDate, DateTime ToDate, string ProdStatus, string WODocNo)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Username",  Username},
                { "@FromDate", FromDate },
                { "@ToDate", ToDate },
                { "@ProdStatus", ProdStatus },
                { "@WODocNo", WODocNo }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllProductionStatisticV2", dicParams);

            return result;
        }

        public DataTable DuplicateCheckWOProdStatistic(string WODocNo, DateTime StatisticDate)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@WODocNo", WODocNo },
                { "@StatisticDate", StatisticDate }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPProdCheckDuplicateWO", dicParams);

            return dt;
        }

        public DataSet GetAllDetailProdStatistic(long HeaderID)
        {
            DataSet result = new DataSet();
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            result = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPGetAllDetailProdStatistic", dicParams);

            return result;
        }

        public void DeleteProdStatistic(long HeaderID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeleteProductionStatistic", dicParams);
        }

        public DataTable GetFieldIDList(string FactoryID)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FactoryID", FactoryID }
            };

            result = _sqlhelper.ExecQueryDataAsDataTable("SELECT Ma_NNghe, Ten_NNghe FROM L81DMNNGHEASP WHERE Ma_NhaMay = @FactoryID ORDER BY Ma_NNghe ASC", dicParams);

            return result;
        }

        public DataTable GetTypeOfAbsence()
        {
            DataTable result = new DataTable();

            result = _sqlhelper.ExecQueryDataAsDataTable("SELECT TypeOfAbsence FROM ASPHRTimekeeping");

            return result;
        }

        public DataTable GetWODocNoList(string MemberID, string WODocNo, int EditType)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@MemberID", MemberID },
                { "@DataID", "A01"},
                { "@WODocNo", WODocNo },
                { "@EditType", EditType }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetWODocNoList", dicParams);

            return result;
        }

        public DataTable GetWODocNoListForView(string MemberID, string WODocNo, int EditType)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@MemberID", MemberID },
                { "@DataID", "A01"},
                { "@WODocNo", WODocNo },
                { "@EditType", EditType }
            };

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetWODocNoListForView", dicParams);

            return result;
        }

        public DataTable GetProductList(string MemberID)
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>();

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetProductList", dicParams);

            return result;
        }

        public DataTable GetEmployeeList(string EmpID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpID", EmpID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetEmployeeList", dicParams);

            return dt;
        }

        public DataTable GetEmployeeListByUsername(string EmpID, string Username)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@EmpID", EmpID },
                { "@Username", Username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetEmployeeListByUsername", dicParams);

            return dt;
        }

        public DataTable GetSubJobProdList(string SubJobID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@SubJobID", SubJobID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetSubJobProdList", dicParams);

            return dt;
        }

        public DataTable GetProductShiftList()
        {
            DataTable result = new DataTable();

            var dicParams = new Dictionary<string, object>();

            result = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetProductShift", dicParams);

            return result;
        }

        public DataTable GetWeeknameOfYear()
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>();

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetWeeknameOfYear", dicParams);

            return dt;
        }

        public DataTable GetDateOfMonth(int Month, int Year)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Month", Month },
                { "@Year", Year }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetDayNameOfMonth", dicParams);

            return dt;
        }

        public DataTable GetLinesByUser(string username)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Username", username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllLineIDByFactory", dicParams);

            return dt;
        }

        public DataTable GetMonthOfYear(int Year)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Year", Year }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetMonthOfYear", dicParams);

            return dt;
        }

        public DataTable GetListYear(int Year)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Year", Year }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetListYear", dicParams);

            return dt;
        }

        public DataTable GetListProdType()
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>();
           

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetListProdType", dicParams);

            return dt;
        }

        //get employee by line
        public void InsertEmpListByLine(long HeaderID, string LineID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID },
                { "@LineID", LineID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertEmpListByLine", dicParams);
        }

        public void InsertMachineListByLine(long HeaderID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertMachineListByLine", dicParams);
        }

        public void InsertPSDetailMachineList(long HeaderID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailMachineList", dicParams);
        }

        public void InsertPSDetailDefectModeList(long HeaderID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailDefectModeList", dicParams);
        }

        public void InsertPSDetailLosstimeList(long HeaderID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailLosstimeList", dicParams);
        }

        public void InsertPSDetailMoldList(long HeaderID)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailMoldList", dicParams);
        }

        //add, edit header
        public void InsertProdStatisticHeader(ProdStatisticDTO.ProdStatisticDTO prodStatisticDTO)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", prodStatisticDTO.HeaderID },
                { "@FieldID", prodStatisticDTO.FieldID },
                { "@LineID", prodStatisticDTO.LineID },
                { "@DocDate", prodStatisticDTO.DocDate },
                { "@StatisticDate", prodStatisticDTO.StatisticDate },
                { "@ProdBeginDate",  prodStatisticDTO.ProdBeginDate },
                { "@ProdShift", prodStatisticDTO.ProdShift },
                { "@WODocNo", prodStatisticDTO.WODocNo },
                { "@GWODocNo", prodStatisticDTO.GWODocNo },
                { "@ProductID", prodStatisticDTO.ProductID },
                { "@ProductType", prodStatisticDTO.ProductType },
                { "@ProdReqQuantity", prodStatisticDTO.ProdReqQuantity },
                { "@ProdStatus", prodStatisticDTO.ProdStatus },
                { "@ProdStatisticQuantity", prodStatisticDTO.ProdStatisticQuantity },
                { "@ProdStatisticEmpQuantity", prodStatisticDTO.ProdStatisticEmpQuantity },
                { "@QRStart", prodStatisticDTO.QRStart },
                { "@CreatedBy", prodStatisticDTO.CreatedBy },
                { "@CreatedDate", prodStatisticDTO.CreatedDate }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPInsertProdStatHeaderV2", dicParams);
        }

        public void UpdateProdStatisticHeader(ProdStatisticDTO.ProdStatisticDTO prodStatisticDTO)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", prodStatisticDTO.HeaderID },
                { "@FieldID", prodStatisticDTO.FieldID },
                { "@LineID", prodStatisticDTO.LineID },
                { "@DocDate", prodStatisticDTO.DocDate },
                { "@StatisticDate", prodStatisticDTO.StatisticDate },
                { "@ProdBeginDate",  prodStatisticDTO.ProdBeginDate },
                { "@ProdShift", prodStatisticDTO.ProdShift },
                { "@WODocNo", prodStatisticDTO.WODocNo },
                { "@GWODocNo", prodStatisticDTO.GWODocNo },
                { "@ProductID", prodStatisticDTO.ProductID },
                { "@ProductType", prodStatisticDTO.ProductType },
                { "@ProdReqQuantity", prodStatisticDTO.ProdReqQuantity },
                { "@ProdStatus", prodStatisticDTO.ProdStatus },
                { "@ProdStatisticQuantity", prodStatisticDTO.ProdStatisticQuantity },
                { "@ProdStatisticEmpQuantity", prodStatisticDTO.ProdStatisticEmpQuantity },
                { "@LastModifiedBy", prodStatisticDTO.LastModifiedBy },
                { "@LastModifiedDate", prodStatisticDTO.LastModifiedDate }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPUpdateProdStatHeader", dicParams);
        }

        //detail employee
        public void InsertPSDetailEmp(ProdStatisticDTO.PSDetailEmp psDetailEmp)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psDetailEmp.HeaderID  },
                { "@EmpID",  psDetailEmp.EmpID},
                { "@LineID", psDetailEmp.LineID },
                { "@EmpWorktime", psDetailEmp.EmpWorktime },
                { "@EmpOvertime", psDetailEmp.EmpOvertime },
                { "@EmpRework", psDetailEmp.EmpRework },
                { "@EmpSorting", psDetailEmp.EmpSorting },
                { "@EmpOverRework", psDetailEmp.EmpOverRework },
                { "@EmpOverSorting", psDetailEmp.EmpOverSorting },
                { "@CreatedDate", psDetailEmp.CreatedDate },
                { "@CreatedBy", psDetailEmp.CreatedBy }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailEmp", dicParams);
        }
        public void UpdatePSDetailEmp(ProdStatisticDTO.PSDetailEmp psDetailEmp)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psDetailEmp.HeaderID },
                { "@LineID",  psDetailEmp.LineID },
                { "@EmpID", psDetailEmp.EmpID },
                { "@EmpWorkingTime", psDetailEmp.EmpWorktime },
                { "@EmpOverTime", psDetailEmp.EmpOvertime },
                { "@EmpRework", psDetailEmp.EmpRework },
                { "@EmpSorting", psDetailEmp.EmpSorting },
                { "@EmpOverRework", psDetailEmp.EmpOverRework },
                { "@EmpOverSorting", psDetailEmp.EmpOverSorting },
                { "@LastModifiedDate", psDetailEmp.LastModifiedDate },
                { "@LastModifiedBy", psDetailEmp.LastModifiedBy }
            };

            var sqlExec = _sqlhelper.ExecProcedureNonData("sp_ASPUpdatePSDetailEmp", dicParams);
        }

        //detail defective mode
        public DataTable GetDefectModeList(string defectID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {

                { "@DefectID", defectID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetDefectModeList", dicParams);

            return dt;
        }

        public void InsertPSDetailDefect(ProdStatisticDTO.PSDetailDefect psDefectDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psDefectDto.HeaderID },
                { "@DefectID", psDefectDto.DefectID },
                { "@DefectName", psDefectDto.DefectName },
                { "@FQCDFQuantity", psDefectDto.FQCDFQuantity },
                { "@FQCScrapQuantity", psDefectDto.FQCScrapQuantity },
                { "@PrevFQCDFQuantity", psDefectDto.PrevFQCDFQuantity },
                { "@FQCReworkQuantity", psDefectDto.FQCReworkQuantity},
                { "@CreatedBy", psDefectDto.CreatedBy },
                { "@CreatedDate", psDefectDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailDefect", dicParams);
        }

        public void UpdatePSDetailDefect(ProdStatisticDTO.PSDetailDefect psDefectDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psDefectDto.HeaderID },
                { "@StageID", psDefectDto.StageID },
                { "@DefectID", psDefectDto.DefectID },
                { "@FQCDFQuantity", psDefectDto.FQCDFQuantity },
                { "@FQCScrapQuantity", psDefectDto.FQCScrapQuantity },
                { "@PrevFQCDFQuantity", psDefectDto.PrevFQCDFQuantity },
                { "@FQCReworkQuantity", psDefectDto.FQCReworkQuantity},
                { "@LastModifiedBy", psDefectDto.LastModifiedBy },
                { "@LastModifiedDate", psDefectDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdatePSDetailDefectV2", dicParams);
        }

        public void DeletePSDetailDefect(ProdStatisticDTO.PSDetailDefect psDefectDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                 { "@HeaderID", psDefectDto.HeaderID },
                { "@DefectID", psDefectDto.DefectID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeletePSDetailDefectV2", dicParams);
        }

        public void DeletePSDetailEmp(ProdStatisticDTO.PSDetailEmp psEmpDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                 { "@HeaderID", psEmpDto.HeaderID },
                { "@@EmpID", psEmpDto.AutoID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeletePSDetailEmp", dicParams);
        }

        //detail Machine time
        public DataTable GetMachineList(string MachineID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {

                { "@MachineID", MachineID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetMachineList", dicParams);

            return dt;
        }

        public DataTable GetMoldList(string MoldID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {

                { "@MoldID", MoldID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetMoldList", dicParams);

            return dt;
        }

        public void InsertPSDetailMachine(ProdStatisticDTO.PSDetailMachine psMachineDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psMachineDto.HeaderID },
                { "@MachineID", psMachineDto.MachineID },
                { "@MachineName", psMachineDto.MachineName },
                { "@MachineTime", psMachineDto.MachineTime },
                { "@CreatedBy", psMachineDto.CreatedBy },
                { "@CreatedDate", psMachineDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailMachine", dicParams);
        }

        public void InsertPSDetailMold(ProdStatisticDTO.PSDetailMold psMoldDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psMoldDto.HeaderID },
                { "@MoldID", psMoldDto.MoldID },
                { "@MoldName", psMoldDto.MoldName },
                { "@NumOfStamp", psMoldDto.NumOfStamp },
                { "@ProdQuantity", psMoldDto.ProdQuantity },
                { "@StampBy", psMoldDto.StampBy },
                { "@CreatedBy", psMoldDto.CreatedBy },
                { "@CreatedDate", psMoldDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailMold", dicParams);
        }

        public void UpdatePSDetailMachine(ProdStatisticDTO.PSDetailMachine psMachineDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psMachineDto.HeaderID },
                { "@MachineID", psMachineDto.MachineID },
                { "@MachineTime", psMachineDto.MachineTime },
                { "@LastModifiedBy", psMachineDto.LastModifiedBy },
                { "@LastModifiedDate", psMachineDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdatePSDetailMachine", dicParams);
        }

        public void UpdatePSDetailMold(ProdStatisticDTO.PSDetailMold psMoldDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psMoldDto.HeaderID },
                { "@MoldID", psMoldDto.MoldID },
                { "@NumOfStamp", psMoldDto.NumOfStamp },
                { "@ProdQuantity", psMoldDto.ProdQuantity },
                { "@StampBy", psMoldDto.StampBy },
                { "@LastModifiedBy", psMoldDto.LastModifiedBy },
                { "@LastModifiedDate", psMoldDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdatePSDetailMold", dicParams);
        }

        public void DeletePSDetailMachine(ProdStatisticDTO.PSDetailMachine psMachineDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                 { "@HeaderID", psMachineDto.HeaderID },
                { "@MachineID", psMachineDto.MachineID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeletePSDetailMachine", dicParams);
        }

        public void DeletePSDetailMold(ProdStatisticDTO.PSDetailMold psMoldDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                 { "@HeaderID", psMoldDto.HeaderID },
                { "@MoldID", psMoldDto.MoldID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeletePSDetailMold", dicParams);
        }

        //detail Losstime
        public DataTable GetLosstimeList(string LosstimeID)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {

                { "@LosstimeID", LosstimeID }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetLosstimeList", dicParams);

            return dt;
        }

        public void InsertPSDetailLosstime(ProdStatisticDTO.PSDetailLosstime psLosstimeDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psLosstimeDto.HeaderID },
                { "@LosstimeID", psLosstimeDto.LosstimeID },
                { "@LosstimeName", psLosstimeDto.LosstimeName },
                { "@LosstimeNum", psLosstimeDto.LosstimeNum },
                { "@CreatedBy", psLosstimeDto.CreatedBy },
                { "@CreatedDate", psLosstimeDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailLosstime", dicParams);
        }

        public void UpdatePSDetailLosstime(ProdStatisticDTO.PSDetailLosstime psLosstimeDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", psLosstimeDto.HeaderID },
                { "@LosstimeID", psLosstimeDto.LosstimeID },
                { "@LosstimeNum", psLosstimeDto.LosstimeNum },
                { "@LastModifiedBy", psLosstimeDto.LastModifiedBy },
                { "@LastModifiedDate", psLosstimeDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdatePSDetailLosstime", dicParams);
        }

        public void DeletePSDetailLosstime(ProdStatisticDTO.PSDetailLosstime psLosstimeDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                 { "@HeaderID", psLosstimeDto.HeaderID },
                { "@LosstimeID", psLosstimeDto.LosstimeID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeletePSDetailLosstime", dicParams);
        }

        public DataTable SummaryProdStatisticByDay(ProdStatisticDTO.ProdStatisticDTO prodDto, bool isOverall)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                 { "@StatisticDate", prodDto.StatisticDate },
                { "@LineID", prodDto.LineID },
                { "@Username",  prodDto.Username},
                { "@IsOverall", isOverall }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPSummaryProdStatisticByDay", dicParams);

            return dt;
        }

        public DateTime GetPSProdBeginDate(string LineID, string WODocNo)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@LineID", LineID },
                { "@WODocNo", WODocNo }
            };

            DateTime prodBeginDate = Convert.ToDateTime(_sqlhelper.ExecProcedureSacalar("sp_ASPGetProdBeginDate", dicParams));

            if (prodBeginDate.Year < 2000)
                prodBeginDate = Convert.ToDateTime("1900-01-01");

            return prodBeginDate;
        }

        public DataTable GetDailyAttendanceChartData(int Week, int Month, int Year, string LineID, string Username)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPDailyAttendanceChart", dicParams);

            return dt;
        }

        public DataTable GetPlanningChartData(int Year, string LineID, string Username)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPYearlyPlanningChart", dicParams);

            return dt;
        }

        public DataTable GetDefectChartData(int Week, int Month, int Year, string LineID, string Username)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPDailyDefectChart", dicParams);

            return dt;
        }

        public DataSet GetDailyYieldChartData(int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPDailyYieldChart", dicParams);

            return ds;
        }

        public DataSet GetOTDChartData(int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPYearlyPlanningSummaryChart", dicParams);

            return ds;
        }

        public DataSet GetDailyProductionChartData(int Week, int Month, int Year, string LineID, string Username, bool CheckByWeek)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
                { "@CheckByWeek", CheckByWeek },
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPDailyProductionChartV2", dicParams);

            return ds;
        }

        public DataSet GetDailyProductivityQuantityChart(string DayList, string LineList, string TypeProdList, int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@DayList", DayList },
                { "@LineList", LineList },
                { "@TypeProdList",  TypeProdList},
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPDailyProductivityQuantityChartV2", dicParams);

            return ds;
        }

        public DataSet GetMonthlyProductionChart(string MonthList, string LineList, string TypeProdList, int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@MonthList", MonthList },
                { "@LineList", LineList },
                { "@TypeProdList", TypeProdList },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPMonthlyProductionChartV2", dicParams);

            return ds;
        }

        public DataSet GetYearlyProductionChart(string YearList, string LineList, string TypeProdList, int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@YearList", YearList },
                { "@LineList", LineList },
                { "@TypeProdList",  TypeProdList}, 
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPYearlyProductionChartV2", dicParams);

            return ds;
        }


        public DataSet GetDailyProdScrapChartData(int Week, int Month, int Year, string LineID, string Username, bool CheckByWeek)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
                { "@CheckByWeek", CheckByWeek },
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPDailyProdScrapChart", dicParams);

            return ds;
        }

        public void InsertDailyProdScrapChartData(int Week, int Month, int Year, string LineID, string Username, bool CheckByWeek)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
                { "@CheckByWeek", CheckByWeek },
            };

            _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPInsertDailyProdScrapChart", dicParams);
        }

        public DataTable GetWeekByDate(DateTime dateNow)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@Date", dateNow }
            };

            DataTable dt = new DataTable();

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPFindWeeknameByDate", dicParams);

            return dt;
        }

        public DataTable GetDateByWeek(int intWeek, int Month, int Year)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@IntWeek", intWeek },
                { "@Month", Month },
                { "@Year", Year },
            };

            DataTable dt = new DataTable();

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPFindDateByWeek", dicParams);

            return dt;
        }

        public DataSet GetDailyProductivityChartData(int Week, int Month, int Year, string LineID, string Username, bool CheckByWeek)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@Week", Week },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
                { "@CheckByWeek", CheckByWeek }
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPDailyProductivityChartV2", dicParams);

            return ds;
        }

        public DataSet GetDailyProductivityPercentChartData(string DayList, string LineList, string TypeProdList, int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@DayList", DayList },
                { "@LineList", LineList },
                { "@TypeProdList", TypeProdList },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username },
                
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPDailyProductivityPercentChartV2", dicParams);

            return ds;
        }

        public DataSet GetMonthlyProductivityChartData(string MonthList, string LineList, string TypeProdList, int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@MonthList", MonthList },
                { "@LineList", LineList },
                { "@TypeProdList", TypeProdList },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPMonthlyProductivityChartV2", dicParams);

            return ds;
        }

        public DataSet GetYearlyProductivityChartData(string YearList, string LineList, string TypeProdList, int Month, int Year, string LineID, string Username)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@YearList", YearList },
                { "@LineList", LineList },
                { "@TypeProdList", TypeProdList },
                { "@Month", Month },
                { "@Year", Year },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet("sp_ASPYearlyProductivityChartV2", dicParams);

            return ds;
        }

        public DataTable GetProductionPlanning(DateTime FromDate, DateTime ToDate, string LineID, string Username)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", FromDate },
                { "@ToDate", ToDate },
                { "@LineID", LineID },
                { "@Username", Username }
            };

            DataTable dt = new DataTable();

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPProductionPlanningByDate", dicParams);

            return dt;
        }

        public void InsertPSDetailExProdWork(ProdStatisticDTO.PSDetailExProdWork prodDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", prodDto.HeaderID },
                { "@EmpID", prodDto.EmpID },
                { "@EmpName", prodDto.EmpName },
                { "@ExProdWorkID", prodDto.ExProdWorkID },
                { "@ExProdWorkName", prodDto.ExProdWorkName },
                { "@ExProdWorkTime", prodDto.ExProdWorkTime },
                { "@ExProdWorkTimeTC", prodDto.ExProdWorkTimeTC },
                { "@CreatedBy", prodDto.CreatedBy },
                { "@CreatedDate", prodDto.CreatedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPInsertPSDetailExProdWork", dicParams);
        }

        public void UpdatePSDetailExProdWork(ProdStatisticDTO.PSDetailExProdWork prodDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", prodDto.HeaderID },
                { "@EmpID", prodDto.EmpID },
                { "@ExProdWorkID", prodDto.ExProdWorkID },
                { "@ExProdWorkTime", prodDto.ExProdWorkTime },
                { "@ExProdWorkTimeTC", prodDto.ExProdWorkTimeTC },
                { "@LastModifiedBy", prodDto.LastModifiedBy },
                { "@LastModifiedDate", prodDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdatePSDetailExProdWork", dicParams);
        }

        public void DeletePSDetailExProdWork(ProdStatisticDTO.PSDetailExProdWork prodDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", prodDto.HeaderID },
                { "@EmpID", prodDto.EmpID },
                { "@ExProdWorkID", prodDto.ExProdWorkID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPDeletePSDetailExProdWork", dicParams);
        }

        public void UpdateStageTime(ProdStatisticDTO.ProdStatisticDTO prodDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", prodDto.HeaderID }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateStageTime", dicParams);
        }

        public void UpdateQRStart(ProdStatisticDTO.ProdStatisticDTO prodDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@HeaderID", prodDto.HeaderID },
                { "@QRStart", prodDto.QRStart }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPUpdateQRStart", dicParams);
        }

        public DataTable GetRptDetailMold(ProdStatisticDTO.ProdStatisticDTO prodDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", prodDto.FromDate },
                { "@ToDate", prodDto.ToDate },
                { "@Username", prodDto.Username }
            };

            dt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPRptDetailMold", dicParams);


            return dt;
        }

        public DataSet GetPSWorkingEmpReport(ProdStatisticDTO.ProdStatisticDTO prodDto, string sqlProc)
        {
            DataSet ds = new DataSet();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", prodDto.FromDate },
                { "@ToDate", prodDto.ToDate },
                { "@LineID", prodDto.LineID }
            };

            ds = _sqlhelper.ExecProcedureDataAsDataSet(sqlProc, dicParams);

            return ds;
        }
    }
}
