using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.AttendanceEmployeeDTO
{
    public class AttendanceEmployeeDTO
    {
        public DateTime AttendanceDate { get; set; }
        public string LineID { get; set; }
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string Timekeeping { get; set; }
        public double MorVege { get; set; } = 0;
        public double EveVege { get; set; } = 0;
        public string LunchTime { get; set; }
        public string Dinnertime { get; set; }
        public TimeSpan DateBeginTime { get; set; }
        public TimeSpan DateEndTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set;}
    }

}
