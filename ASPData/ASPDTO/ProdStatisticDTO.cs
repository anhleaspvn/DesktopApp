using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ProdStatisticDTO
{
    public class ProdStatisticDTO
    {
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
        public DateTime CreatedDate { get; set;}
        public string LastModifiedBy { get; set;}
        public DateTime LastModifiedDate { get; set;}
    }

    public class PSDetailMachine
    {
        public long HeaderID { get; set; }
        public string MachineID { get; set; }
        public string MachineName { get; set; }
        public double MachineTime { get; set; } = 0;
        public string CreatedBy { get; set;}
        public DateTime CreatedDate { get; set;}
        public string LastModifiedBy { get; set;}
        public DateTime LastModifiedDate { get; set;}   
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
        public string ExProdWorkName { get;set; } = string.Empty;
        public double ExProdWorkTime { get; set; } = 0;
        public double ExProdWorkTimeTC { get; set; } = 0;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }
}
