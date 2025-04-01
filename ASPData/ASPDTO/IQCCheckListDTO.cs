using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public class IQCCheckListDTO
    {
        public long AutoID { get; set; }
        public long HeaderID { get; set; }
        public string IQCCheckID { get; set; } = string.Empty;
        public string IQCCheckName { get; set; } = string.Empty;
        public string IQCCheckCont { get; set; } = string.Empty;
        public double IQCTemplateQuantity { get; set; } = 0;
        public string IQCEvalueResult { get; set; } = string.Empty;
        public string IQCStandard { get; set; } = string.Empty;
        public double IQCEvalueActual { get; set; } = 0;
        public double DefectQuantity { get; set; } = 0;
        public string IQCPeriodTime { get; set; } = string.Empty;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
