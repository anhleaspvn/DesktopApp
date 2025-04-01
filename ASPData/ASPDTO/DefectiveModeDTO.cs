using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.DefectiveModeDTO
{
    public class DefectiveModeDTO
    {
        public string DefectID { get; set; }
        public string DefectName { get; set; }
        public string DefectType { get; set; }  
        public string DefectLevel { get; set; }
        public string MainStep { get; set; }    
        public string Mold_Assembly { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
