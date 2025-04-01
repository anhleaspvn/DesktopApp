using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public class PSScanQRHeaderDTO
    {
        public long HeaderID { get; set; }
        public string QRCodeContent { get; set; }
        public string WODocNo { get; set; }
        public string LineID { get; set; }
        public string ProductID { get; set; }
        public double ProdReqQuantity { get; set; }
        public string SOPID { get; set; }
        public string QuaInstruction { get; set; }
        public string ToolJigID { get; set; }
        public string StageID { get; set; }
        public string StageName { get; set; }
        public string MaterialID { get; set; }
        public string MaterialName { get; set; }
        public string EmpID { get; set; }
        public double CycleTime { get; set; }
        public double WorkingTimeDG { get; set; }
        public double OutputRateDG { get; set; }
        public double StandardORVN { get; set; }
        public double ActualQty { get; set; }
        public double ActualQtyOK { get; set; }
        public double ActualQtyNG { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set;}
        public double ActualTime { get; set; }  
    }
}
