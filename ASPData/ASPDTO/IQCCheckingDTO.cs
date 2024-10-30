using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public class IQCCheckingDTO
    {
        public long HeaderID { get; set; }
        public string FactoryID { get; set; } = string.Empty;
        public DateTime DocDate { get; set; } = DateTime.MinValue;
        public string LineID { get; set; } = string.Empty;
        public string QCID { get; set; } = string.Empty;
        public string ProductID { get; set; } = string.Empty;
        public string WODocNo { get; set; } = string.Empty;
        public double ProdReqQuantity { get; set; } = 0;
        public string CustomerID { get; set; } = string.Empty;
        public string ProdStatus { get; set; } = string.Empty;
        public string CheckState { get; set; } = string.Empty;
        public string StageOfChecking { get; set; } = string.Empty;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string Username { get; set; }
    }
}
