using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public class WOSOPDTO
    {
        public long AutoID { get; set; } = 0;
        public long HeaderID { get; set; } = 0;
        public long DFHeaderID { get; set; } = 0;
        public long EmpHeaderID { get; set; } = 0;
        public long MachineHeaderID { get; set; } = 0;
        public string EmpID { get; set; }   = string.Empty;
        public string WODocNo { get; set; } =string.Empty;
        public string LineID { get; set; } = string.Empty;
        public string ProductID { get; set; } = string.Empty;
        public string SOPID { get; set; } = string.Empty;
        public string StageID { get; set; } = string.Empty;
        public string StageName { get; set; } = string.Empty;
        public string MaterialID { get; set; } = string.Empty;
        public string MachineID { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool Assigned { get; set ; } = false;
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public double Quantity { get; set; } = 0;
        public double ReworkQuantity { get; set; } = 0;
        public double SortingQuantity { get; set; } = 0;
        public double CycleTime { get; set; } = 0;
        public double UsageBom { get; set; } = 0;
        public bool Type { get; set; } = false;
        public DateTime CheckInDt { get; set; } = DateTime.Now;
        public DateTime CheckInDtOld { get; set; } = DateTime.Now;
        public DateTime CheckOutDt { get; set;} = DateTime.Now;

        public DateTime CheckOutDtOld { get; set; } = DateTime.Now;
        public double ManPower { get; set; } = 0;

        public int ViewType { get; set; } = 0;
    }
}
