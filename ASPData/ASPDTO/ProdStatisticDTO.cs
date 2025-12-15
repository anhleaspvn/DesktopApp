using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ProdStatisticDTO
{
    public class ProdStatisticDTO
    {
        public long AutoID { get; set; }
        public long HeaderID { get; set; }
        public string FieldID { get; set; }
        public string LineID { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime StatisticDate { get; set; }
        public DateTime ProdBeginDate { get; set; }
        public string ProdShift { get; set; }
        public string WODocNo { get; set; }
        public string GWODocNo { get; set; }
        public string ProductID { get; set; }
        public string ProductType { get; set; }
        public double ProdReqQuantity { get; set; } = 0;
        public string ProdStatus { get; set; }
        public double ProdStatisticQuantity { get; set; } = 0;
        public double ProdStatisticEmpQuantity { get; set; } = 0;
        public double ProdLossTime { get; set; } = 0;
        public double ProdReworkTime { get; set; } = 0;
        public double ProdSortTime { get; set; } = 0;
        public double FQCDFQuantity { get; set; } = 0;
        public double FQCScrapQuantity { get; set; } = 0;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Username { get; set; }
        public Boolean QRStart { get; set; } = false;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string MaterialReason { get; set; }
        public string ManReason { get; set; }
        public string MachineReason { get; set; }
        public string MethodReason { get; set; }
    }

    public class PSDetailEmp
    {
        public long HeaderID { get; set; }
        public long AutoID { get; set; }
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpPosition { get; set; }
        public bool IsDirect { get; set; }
        public string LineID { get; set; }
        public double EmpWorktime { get; set; } = 0;
        public double EmpOvertime { get; set; } = 0;

        public double EmpRework { get; set; } = 0;
        public double EmpSorting { get; set; } = 0;

        public double EmpOverRework { get; set; } = 0;
        public double EmpOverSorting { get; set; } = 0;

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class PSDetailDefect
    {
        public long HeaderID { get; set; }
        public string StageID { get; set; }
        public string DefectID { get; set; }
        public string DefectName { get; set; }
        public double FQCDFQuantity { get; set; } = 0;
        public double FQCScrapQuantity { get; set; } = 0;
        public double PrevFQCDFQuantity { get; set; } = 0;
        public double FQCReworkQuantity { get; set; } = 0;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class PSDetailLosstime
    {
        public long HeaderID { get; set; }
        public string LosstimeID { get; set; }
        public string LosstimeName { get; set; }
        public double LosstimeNum { get; set; } = 0;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class PSDetailMachine
    {
        public long HeaderID { get; set; }
        public string MachineID { get; set; }
        public string MachineName { get; set; }
        public double MachineTime { get; set; } = 0;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class PSDetailMold
    {
        public long HeaderID { get; set; }
        public string MoldID { get; set; }
        public string MoldName { get; set; }
        public double NumOfStamp { get; set; } = 0;
        public double ProdQuantity { get; set; } = 0;
        public string StampBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class PSDetailExProdWork
    {
        public long HeaderID { get; set; }
        public string EmpID { get; set; } = string.Empty;
        public string EmpName { get; set; } = string.Empty;
        public string ExProdWorkID { get; set; } = string.Empty;
        public string ExProdWorkName { get; set; } = string.Empty;
        public double ExProdWorkTime { get; set; } = 0;
        public double ExProdWorkTimeTC { get; set; } = 0;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }

    public class QRCodeFGsData
    {
        public string QRCode { get; set; }
        public string WODocNo { get; set; }
        public string ProductID { get; set; }
        public int ProdOrderNo { get; set; }
        public DateTime TestTime { get; set; } = DateTime.Now;
        public string TestResult { get; set; }
        public string FactoryID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

    }

    public class QRCodeMasterList
    {
        public long OrderNo { get; set; }
        public string WODocNo { get; set; }
        public string ProductID { get; set; }
        public double RequestQuantity { get; set; }
        public bool IsPrinted { get; set; }
        public int NumOfPrints { get; set; }
        public string LineID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }

    public class QRCodeLog
    {
        public string LogID { get; set; }
        public DateTime LogTime { get; set; } = DateTime.Now;
        public string StageID { get; set; }
        public string LogResult { get; set; }
        public string LineID { get; set; }
        public string QRCodeData { get; set; }
        public string GroupData { get; set; }
        public string Username { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public string JigID { get; set; }
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;
        public int CartNo { get; set; } = 0;
        public string ScanInfo { get; set; } = string.Empty;
    }

    public class PLineMachineIns
    {
        public long AutoID { get; set; }
        public DateTime DocDate { get; set; }
        public string LineID { get; set; }
        public string WODocNo { get; set; }
        public string ProductID { get; set; }
        public string StageID { get; set; }
        public string MachineID { get; set; }
        public string BladeID { get; set; }
        public string RequiredStatus { get; set; }
        public string MaterialID { get; set;  }
        public double MaterialQuantity { get; set; }
        public bool TechApproval { get; set; }
        public string TechName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string JigID { get; set;  }
        public double TargetTime { get; set; }
        public string Evaluation { get; set;  }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsPriority { get; set; }
    }
    public class PSScanBarcodeBin
    {
        public long AutoID { get; set; }
        public string CusID { get; set; }
        public string BinQuantity { get; set; }
        public string BinQuantitySum { get; set; }
        public string ShipDate { get; set; }
        public string Rev { get; set; }
        public string PkgGwt { get; set; }
        public string Desc { get; set; }
        public string MadeInVN { get; set; }
        public string PartNo { get; set; }
        public string ItemNo { get; set; }
        public string Quantity { get; set; }
        public double NW { get; set; }
        public double GW { get; set; }
        public string CartNo { get; set; }
        public string LotNo { get; set; }
        public string WO { get; set; }
        public string Cable { get; set; }
        public string BinSize { get; set; }
        public string ULStamp { get; set; }
        public string UL2Stamp { get; set; }
        public string SBDate { get; set; }
        public double N5 { get; set; }
        public double N25 { get; set; }
        public double N100 { get; set; }
        public double N250 { get; set; }
        public double N500 { get; set; }
        public double N1_25 { get; set; }
        public double N1_100 { get; set; }
        public double N1_250 { get; set; }
        public double N1_500 { get; set; }
        public string OriginalMaterial { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

        public string POText { get; set; } = string.Empty;
        public string POCode { get; set; } = string.Empty;
        public int IntType { get; set; } = 0;

        public DateTime PrintDate { get; set; } = DateTime.Now;
        public string Line { get; set; } = string.Empty;
        public string ProductIDVN { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string QRCodeVerify { get; set; } = string.Empty;
        public string QRCodeData { get; set; } = string.Empty;
        public string CustomerVerify { get; set; } = string.Empty;

        public Boolean QCVerify { get; set; } = false;
        public string QCVerify_Log { get; set; } = string.Empty;
        public string PrintUser { get; set; } = string.Empty;
        public double FirstBinQuantity { get; set; } = 0;
        public double LastBinQuantity { get; set; } = 0;
        public double SumQuantity { get; set; } = 0;
        public double LinkQQuantityPerBin { get; set; } = 0;
        public double N5_Line { get; set; } = 0;
        public double N25_Line { get; set; } = 0;
        public double N100_Line { get; set; } = 0;
        public double N250_Line { get; set; } = 0;
        public double N500_Line { get; set; } = 0;
        public double N1_25_Line { get; set; } = 0;
        public double N1_100_Line { get; set; } = 0;
        public double N1_250_Line { get; set; } = 0;
        public double N1_500_Line { get; set; } = 0;
        public string Supplier { get; set; } = string.Empty;
        public string ENGLevel { get; set; } = string.Empty;
        public string PartNo0 { get; set; } = string.Empty;
    }
}
