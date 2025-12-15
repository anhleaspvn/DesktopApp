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
        public string MaintenanceMonth { get; set; }
        public string MachineGroup { get; set; }
        public string ACCID { get; set; }
        public DateTime WarehouseEntryDate { get; set; }
        public string MachineOrigin { get; set; }
        public string TypeID { get; set; }
        public string Supplier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
