using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.TimekeepingDTO
{
    public class TimekeepingDTO
    {
        public string TimekeepID {  get; set; }
        public string TimekeepName { get; set;}

        public double TimekeepHours { get; set; }
        public double TimekeepHoursMain { get; set; }
        public double TimekeepHoursOver { get; set; }
        public TimeSpan DateBeginTime { get; set; }
        public TimeSpan DateEndTime { get; set; }
        public double TimeOffByDate {  get; set; }
        public double TimeOffByDateTC { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
