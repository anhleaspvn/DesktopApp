using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.LosstimeDTO
{
    public class LosstimeDTO
    {
        public string LosstimeID { get; set; }
        public string LosstimeName { get; set; }
        public string LosstimeType { get; set; }
        public string LineID { get; set; }
        public string EmpID { get; set; }
        public double LosstimeNum { get; set; } = 0;
        public double LosstimeNumTC { get; set; } = 0;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public string Username { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime StatisticDate { get; set; } 
    }
}
