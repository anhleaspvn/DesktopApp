using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public class IQCActualCheck
    {
        public long AutoID { get; set; }
        public long HeaderID { get; set;  }
        public string IQCCheckID { get; set; }
        public string IQCCheckName { get; set; } = string.Empty;
        public string IQCDFID { get; set; } = string.Empty;
        public string IQCStandard { get; set; } = string.Empty;
        public string IQCStandardMin { get; set; } = string.Empty;
        public string IQCStandardMax { get; set; } = string.Empty;
        public string IQCCheckingContent { get; set; } = string.Empty;
        public double IQCEvalueActual { get; set; } = 0;
        public string IQCEvalueResult { get; set; } = string.Empty;
        public string IQCEvalueCheckTime { get; set; } = string.Empty;
        public string IQCPeriodTime { get; set; } = string.Empty;
        public string IQCDeviceID { get; set; } = string.Empty;
        public string IQCMeasuringToolID { get; set; } = string.Empty;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
