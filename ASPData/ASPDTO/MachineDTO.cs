using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.MachineDTO
{
    public class MachineDTO
    {
        public string MachineID { get; set; }
        public string MachineName { get; set; }
        public int MaintenanceMonth { get; set; }
        public string MachineGroup { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
